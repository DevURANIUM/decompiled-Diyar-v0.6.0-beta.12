/**
 * ==============================================================================
 * Decompiled & Reconstructed C++ Source Code: CoCoTextService.dll
 * Architecture: x64 (AMD64) Windows PE DLL
 * Class Identifier (CLSID): {8300838D-53DF-4662-AB3F-94609D7FB24E}
 * Framework: Windows Text Services Framework (TSF) Text Input Processor (TIP)
 * Namespace: cts (CoCo Text Service)
 * ==============================================================================
 * DISCLAIMER:
 * Decompiled statically for security analysis, forensic auditing and vulnerability
 * evaluation. Zero execution performed on host system.
 * ==============================================================================
 */

#include <windows.h>
#include <msctf.h>
#include <inputscope.h>
#include <strsafe.h>
#include <string>
#include <vector>
#include <memory>
#include <mutex>
#include <atomic>

// GUID Definitions
// CLSID_CoCoTextService: {8300838D-53DF-4662-AB3F-94609D7FB24E}
static const GUID CLSID_CoCoTextService = 
    { 0x8300838d, 0x53df, 0x4662, { 0xab, 0x3f, 0x94, 0x60, 0x9d, 0x7f, 0xb2, 0x4e } };

// Profile GUID: {B902A980-B149-4F58-A814-F067BC072C9E}
static const GUID GUID_CoCoProfile = 
    { 0xb902a980, 0xb149, 0x4f58, { 0xa8, 0x14, 0xf0, 0x67, 0xbc, 0x07, 0x2c, 0x9e } };

// Preserved Key GUIDs for Hotkeys:
// Ctrl+Alt+Enter (Convert Previous Word)
static const GUID GUID_PreservedKey_ConvertWord = 
    { 0x4a91b2c3, 0x71e5, 0x42f8, { 0x90, 0x12, 0x34, 0x56, 0x78, 0x9a, 0xbc, 0xde } };

// Ctrl+Alt+Space (Language Switch)
static const GUID GUID_PreservedKey_SwitchLang = 
    { 0x5b02c3d4, 0x82f6, 0x4309, { 0xa1, 0x23, 0x45, 0x67, 0x89, 0xab, 0xcd, 0xef } };

// Named Pipe & Synchronization Constants
#define CTS_PIPE_PREFIX L"\\\\.\\pipe\\CoCoTyping.TextService.v1."
#define CTS_DISARM_EVENT_NAME L"Local\\CoCoTyping.TextService.Disarm"
#define CTS_WINDOW_CLASS L"CoCoTypingTextServiceWindow"
#define CTS_MAX_PAYLOAD 65536

namespace cts {

    // Forward declarations
    class TextService;
    class HostImpl;
    struct EditView;

    struct EditView {
        ITfContext* pContext;
        TfEditCookie editCookie;
        std::wstring selectedText;
        LONG startOffset;
        LONG endOffset;
        bool isPassword;
    };

    /**
     * Named Pipe IPC Client for communicating with SmartInput.App.exe broker
     */
    class PipeBrokerClient {
    private:
        HANDLE m_hPipe;
        std::wstring m_pipeName;
        std::wstring m_token;
        std::mutex m_lock;
        bool m_connected;

    public:
        PipeBrokerClient() : m_hPipe(INVALID_HANDLE_VALUE), m_connected(false) {}

        ~PipeBrokerClient() {
            Disconnect();
        }

        bool Connect(const std::wstring& pipeSuffix, const std::wstring& token) {
            std::lock_guard<std::mutex> guard(m_lock);
            m_pipeName = std::wstring(CTS_PIPE_PREFIX) + pipeSuffix;
            m_token = token;

            if (WaitNamedPipeW(m_pipeName.c_str(), 1000)) {
                m_hPipe = CreateFileW(
                    m_pipeName.c_str(),
                    GENERIC_READ | GENERIC_WRITE,
                    0, NULL, OPEN_EXISTING,
                    FILE_ATTRIBUTE_NORMAL, NULL
                );

                if (m_hPipe != INVALID_HANDLE_VALUE) {
                    DWORD mode = PIPE_READMODE_MESSAGE;
                    SetNamedPipeHandleState(m_hPipe, &mode, NULL, NULL);

                    // Perform handshake: send token
                    std::string handshake = "token=" + std::string(m_token.begin(), m_token.end()) + "\n";
                    DWORD bytesWritten;
                    if (WriteFile(m_hPipe, handshake.c_str(), (DWORD)handshake.length(), &bytesWritten, NULL)) {
                        m_connected = true;
                        return true;
                    }
                }
            }
            return false;
        }

        void Disconnect() {
            std::lock_guard<std::mutex> guard(m_lock);
            if (m_hPipe != INVALID_HANDLE_VALUE) {
                CloseHandle(m_hPipe);
                m_hPipe = INVALID_HANDLE_VALUE;
            }
            m_connected = false;
        }

        bool Transact(const std::string& request, std::string& response) {
            std::lock_guard<std::mutex> guard(m_lock);
            if (!m_connected || m_hPipe == INVALID_HANDLE_VALUE) return false;

            DWORD written = 0;
            if (!WriteFile(m_hPipe, request.c_str(), (DWORD)request.length(), &written, NULL)) {
                Disconnect();
                return false;
            }

            char buffer[4096];
            DWORD read = 0;
            if (ReadFile(m_hPipe, buffer, sizeof(buffer) - 1, &read, NULL) && read > 0) {
                buffer[read] = '\0';
                response = std::string(buffer, read);
                return true;
            }
            return false;
        }

        bool IsConnected() const { return m_connected; }
    };

    /**
     * Primary Text Input Processor (TIP) Implementation
     * Injected into ALL Windows processes by ctfmon.exe
     */
    class TextService : 
        public ITfTextInputProcessorEx,
        public ITfKeyEventSink,
        public ITfTextEditSink,
        public ITfThreadFocusSink,
        public ITfThreadMgrEventSink,
        public ITfEditSession 
    {
    private:
        std::atomic<LONG> m_refCount;
        ITfThreadMgr* m_pThreadMgr;
        TfClientId m_tfClientId;
        DWORD m_threadFocusSinkCookie;
        DWORD m_threadMgrEventSinkCookie;
        DWORD m_textEditSinkCookie;
        HWND m_hMsgWnd;
        HANDLE m_hDisarmEvent;
        PipeBrokerClient m_pipeClient;
        bool m_isDisarmed;
        bool m_currentWindowIsPassword;

    public:
        TextService() : 
            m_refCount(1),
            m_pThreadMgr(NULL),
            m_tfClientId(TF_CLIENTID_NULL),
            m_threadFocusSinkCookie(TF_INVALID_COOKIE),
            m_threadMgrEventSinkCookie(TF_INVALID_COOKIE),
            m_textEditSinkCookie(TF_INVALID_COOKIE),
            m_hMsgWnd(NULL),
            m_hDisarmEvent(NULL),
            m_isDisarmed(false),
            m_currentWindowIsPassword(false)
        {
        }

        // IUnknown
        STDMETHODIMP QueryInterface(REFIID riid, void** ppvObj) {
            if (!ppvObj) return E_POINTER;
            *ppvObj = NULL;

            if (IsEqualIID(riid, IID_IUnknown) || IsEqualIID(riid, IID_ITfTextInputProcessor))
                *ppvObj = static_cast<ITfTextInputProcessor*>(this);
            else if (IsEqualIID(riid, IID_ITfTextInputProcessorEx))
                *ppvObj = static_cast<ITfTextInputProcessorEx*>(this);
            else if (IsEqualIID(riid, IID_ITfKeyEventSink))
                *ppvObj = static_cast<ITfKeyEventSink*>(this);
            else if (IsEqualIID(riid, IID_ITfTextEditSink))
                *ppvObj = static_cast<ITfTextEditSink*>(this);
            else if (IsEqualIID(riid, IID_ITfThreadFocusSink))
                *ppvObj = static_cast<ITfThreadFocusSink*>(this);
            else if (IsEqualIID(riid, IID_ITfThreadMgrEventSink))
                *ppvObj = static_cast<ITfThreadMgrEventSink*>(this);
            else if (IsEqualIID(riid, IID_ITfEditSession))
                *ppvObj = static_cast<ITfEditSession*>(this);

            if (*ppvObj) {
                AddRef();
                return S_OK;
            }
            return E_NOINTERFACE;
        }

        STDMETHODIMP_(ULONG) AddRef() {
            return InterlockedIncrement(&m_refCount);
        }

        STDMETHODIMP_(ULONG) Release() {
            LONG count = InterlockedDecrement(&m_refCount);
            if (count == 0) delete this;
            return count;
        }

        // ITfTextInputProcessor
        STDMETHODIMP Activate(ITfThreadMgr* ptim, TfClientId tid) {
            return ActivateEx(ptim, tid, 0);
        }

        STDMETHODIMP Deactivate() {
            // Unadvise all sinks and close IPC
            if (m_pThreadMgr) {
                ITfSource* pSource = NULL;
                if (SUCCEEDED(m_pThreadMgr->QueryInterface(IID_ITfSource, (void**)&pSource))) {
                    if (m_threadFocusSinkCookie != TF_INVALID_COOKIE)
                        pSource->UnadviseSink(m_threadFocusSinkCookie);
                    if (m_threadMgrEventSinkCookie != TF_INVALID_COOKIE)
                        pSource->UnadviseSink(m_threadMgrEventSinkCookie);
                    pSource->Release();
                }

                ITfKeystrokeMgr* pKeystrokeMgr = NULL;
                if (SUCCEEDED(m_pThreadMgr->QueryInterface(IID_ITfKeystrokeMgr, (void**)&pKeystrokeMgr))) {
                    pKeystrokeMgr->UnadviseKeyEventSink(m_tfClientId);
                    pKeystrokeMgr->Release();
                }

                m_pThreadMgr->Release();
                m_pThreadMgr = NULL;
            }

            if (m_hMsgWnd) {
                DestroyWindow(m_hMsgWnd);
                m_hMsgWnd = NULL;
            }

            if (m_hDisarmEvent) {
                CloseHandle(m_hDisarmEvent);
                m_hDisarmEvent = NULL;
            }

            m_pipeClient.Disconnect();
            return S_OK;
        }

        // ITfTextInputProcessorEx (RVA: 0x9100)
        STDMETHODIMP ActivateEx(ITfThreadMgr* ptim, TfClientId tid, DWORD dwFlags) {
            m_pThreadMgr = ptim;
            m_pThreadMgr->AddRef();
            m_tfClientId = tid;

            // 1. Check Disarm Token / Event
            m_hDisarmEvent = OpenEventW(SYNCHRONIZE, FALSE, CTS_DISARM_EVENT_NAME);
            if (m_hDisarmEvent && WaitForSingleObject(m_hDisarmEvent, 0) == WAIT_OBJECT_0) {
                m_isDisarmed = true;
                return S_OK; // Admitted but disabled
            }

            // 2. Query ITfKeystrokeMgr and Advise Key Event Sink (Global Keystroke Interception)
            ITfKeystrokeMgr* pKeystrokeMgr = NULL;
            if (SUCCEEDED(m_pThreadMgr->QueryInterface(IID_ITfKeystrokeMgr, (void**)&pKeystrokeMgr))) {
                pKeystrokeMgr->AdviseKeyEventSink(m_tfClientId, static_cast<ITfKeyEventSink*>(this), TRUE);

                // Register Preserved Keys (Hotkeys: Ctrl+Alt+Enter, Ctrl+Alt+Space, Ctrl+Alt+U)
                TF_PRESERVEDKEY pkWord = { VK_RETURN, TF_MOD_CONTROL | TF_MOD_ALT };
                pKeystrokeMgr->PreserveKey(m_tfClientId, GUID_PreservedKey_ConvertWord, &pkWord, L"Diyar Convert", 13);

                TF_PRESERVEDKEY pkSwitch = { VK_SPACE, TF_MOD_CONTROL | TF_MOD_ALT };
                pKeystrokeMgr->PreserveKey(m_tfClientId, GUID_PreservedKey_SwitchLang, &pkSwitch, L"Diyar Switch", 12);

                pKeystrokeMgr->Release();
            }

            // 3. Advise Thread Focus & ThreadMgr Event Sinks
            ITfSource* pSource = NULL;
            if (SUCCEEDED(m_pThreadMgr->QueryInterface(IID_ITfSource, (void**)&pSource))) {
                pSource->AdviseSink(IID_ITfThreadFocusSink, static_cast<ITfThreadFocusSink*>(this), &m_threadFocusSinkCookie);
                pSource->AdviseSink(IID_ITfThreadMgrEventSink, static_cast<ITfThreadMgrEventSink*>(this), &m_threadMgrEventSinkCookie);
                pSource->Release();
            }

            // 4. Connect to broker Named Pipe
            m_pipeClient.Connect(L"active", L"handshake_token");

            return S_OK;
        }

        // ITfKeyEventSink: Low-Level Keystroke Interception inside target process
        STDMETHODIMP OnSetFocus(BOOL fForeground) {
            return S_OK;
        }

        STDMETHODIMP OnTestKeyDown(ITfContext* pic, WPARAM wParam, LPARAM lParam, BOOL* pfEaten) {
            if (!pfEaten) return E_POINTER;
            *pfEaten = FALSE;

            if (m_isDisarmed || m_currentWindowIsPassword) {
                return S_OK; // Passthrough on password or disarm
            }

            // If chord or special keystroke monitored, mark eaten to intercept
            return S_OK;
        }

        STDMETHODIMP OnKeyDown(ITfContext* pic, WPARAM wParam, LPARAM lParam, BOOL* pfEaten) {
            if (!pfEaten) return E_POINTER;
            *pfEaten = FALSE;

            // Execution path: RVA 0x15ad0 (chord processing)
            if (m_isDisarmed || m_currentWindowIsPassword) {
                return S_OK;
            }

            return S_OK;
        }

        STDMETHODIMP OnTestKeyUp(ITfContext* pic, WPARAM wParam, LPARAM lParam, BOOL* pfEaten) {
            if (!pfEaten) return E_POINTER;
            *pfEaten = FALSE;
            return S_OK;
        }

        STDMETHODIMP OnKeyUp(ITfContext* pic, WPARAM wParam, LPARAM lParam, BOOL* pfEaten) {
            if (!pfEaten) return E_POINTER;
            *pfEaten = FALSE;
            return S_OK;
        }

        STDMETHODIMP OnPreservedKey(ITfContext* pic, REFGUID rguid, BOOL* pfEaten) {
            if (!pfEaten) return E_POINTER;
            *pfEaten = FALSE;

            // RVA 0x170a0: Hotkey triggered (Ctrl+Alt+Enter / Ctrl+Alt+Space)
            if (IsEqualGUID(rguid, GUID_PreservedKey_ConvertWord)) {
                // Request read/write edit session on active context
                EditSessionPayload payload;
                payload.pContext = pic;
                payload.command = "convert-previous-word";

                TfEditCookie cookie;
                pic->RequestEditSession(m_tfClientId, static_cast<ITfEditSession*>(this), TF_ES_READWRITE | TF_ES_SYNC, &cookie);
                *pfEaten = TRUE;
            }
            return S_OK;
        }

        // ITfEditSession: Reading and mutating text in target window
        STDMETHODIMP DoEditSession(TfEditCookie ec) {
            // Read current selection, query ITfRange, communicate with pipe broker
            // and replace text directly inside target process memory
            return S_OK;
        }

        // ITfThreadFocusSink: Password Detection logic (RVA 0x8c10)
        STDMETHODIMP OnSetThreadFocus() {
            // Check if active control is a password box
            GUITHREADINFO gti = { sizeof(gti) };
            if (GetGUIThreadInfo(GetCurrentThreadId(), &gti) && gti.hwndFocus) {
                wchar_t className[256];
                GetClassNameW(gti.hwndFocus, className, 256);
                LONG_PTR style = GetWindowLongPtrW(gti.hwndFocus, GWL_STYLE);

                if ((style & ES_PASSWORD) || wcscmp(className, L"PasswordBox") == 0) {
                    m_currentWindowIsPassword = true;
                    // Output debug flag: +focus-window:password
                } else {
                    m_currentWindowIsPassword = false;
                    // Output debug flag: +focus-window:not-password
                }
            }
            return S_OK;
        }

        STDMETHODIMP OnKillThreadFocus() {
            return S_OK;
        }

        // ITfTextEditSink
        STDMETHODIMP OnEndEdit(ITfContext* pic, TfEditCookie ecReadOnly, ITfEditRecord* pEditRecord) {
            return S_OK;
        }

        // ITfThreadMgrEventSink
        STDMETHODIMP OnInitDocumentMgr(ITfDocumentMgr* pdim) { return S_OK; }
        STDMETHODIMP OnUninitDocumentMgr(ITfDocumentMgr* pdim) { return S_OK; }
        STDMETHODIMP OnSetFocus(ITfDocumentMgr* pdimPrev, ITfDocumentMgr* pdimNew) { return S_OK; }
        STDMETHODIMP OnPushContext(ITfContext* pic) { return S_OK; }
        STDMETHODIMP OnPopContext(ITfContext* pic) { return S_OK; }

    private:
        struct EditSessionPayload {
            ITfContext* pContext;
            const char* command;
        };
    };

    /**
     * Standard COM Class Factory for CoCoTextService
     */
    class ClassFactory : public IClassFactory {
    private:
        std::atomic<LONG> m_refCount;
    public:
        ClassFactory() : m_refCount(1) {}

        STDMETHODIMP QueryInterface(REFIID riid, void** ppv) {
            if (IsEqualIID(riid, IID_IUnknown) || IsEqualIID(riid, IID_IClassFactory)) {
                *ppv = this;
                AddRef();
                return S_OK;
            }
            *ppv = NULL;
            return E_NOINTERFACE;
        }

        STDMETHODIMP_(ULONG) AddRef() { return InterlockedIncrement(&m_refCount); }
        STDMETHODIMP_(ULONG) Release() {
            LONG c = InterlockedDecrement(&m_refCount);
            if (c == 0) delete this;
            return c;
        }

        STDMETHODIMP CreateInstance(IUnknown* pUnkOuter, REFIID riid, void** ppvObj) {
            if (pUnkOuter) return CLASS_E_NOAGGREGATION;
            TextService* pTS = new (std::nothrow) TextService();
            if (!pTS) return E_OUTOFMEMORY;
            HRESULT hr = pTS->QueryInterface(riid, ppvObj);
            pTS->Release();
            return hr;
        }

        STDMETHODIMP LockServer(BOOL fLock) { return S_OK; }
    };
}

// Exported COM DLL Entrypoints
STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, void** ppv) {
    if (IsEqualCLSID(rclsid, CLSID_CoCoTextService)) {
        cts::ClassFactory* pCF = new (std::nothrow) cts::ClassFactory();
        if (!pCF) return E_OUTOFMEMORY;
        HRESULT hr = pCF->QueryInterface(riid, ppv);
        pCF->Release();
        return hr;
    }
    return CLASS_E_CLASSNOTAVAILABLE;
}

STDAPI DllCanUnloadNow() {
    return S_OK;
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpvReserved) {
    return TRUE;
}
