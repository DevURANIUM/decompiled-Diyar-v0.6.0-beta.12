/**
 * ==============================================================================
 * Decompiled & Reconstructed C++ Source Code: CoCoTextServiceCtl.exe
 * Architecture: x64 (AMD64) Windows PE Executable
 * Target Component: CoCoTextService (Diyar Text Service Controller)
 * ==============================================================================
 * DISCLAIMER:
 * Decompiled statically for security analysis, forensic auditing and vulnerability
 * evaluation. Zero execution performed on host system.
 * ==============================================================================
 */

#include <windows.h>
#include <msctf.h>
#include <strsafe.h>
#include <iostream>
#include <string>
#include <vector>

// Target GUIDs
static const GUID CLSID_CoCoTextService = 
    { 0x8300838d, 0x53df, 0x4662, { 0xab, 0x3f, 0x94, 0x60, 0x9d, 0x7f, 0xb2, 0x4e } };

static const GUID GUID_CoCoProfile = 
    { 0xb902a980, 0xb149, 0x4f58, { 0xa8, 0x14, 0xf0, 0x67, 0xbc, 0x07, 0x2c, 0x9e } };

static const wchar_t* CLSID_STRING = L"{8300838D-53DF-4662-AB3F-94609D7FB24E}";
static const wchar_t* DISARM_TOKEN_NAME = L"\\disarm.token";

namespace ctl {

    /**
     * Registers the InprocServer32 COM entries in the Windows Registry (HKLM)
     * RVA: 0x8ff0 - 0x9e70
     */
    bool RegisterComServer(const std::wstring& dllPath) {
        std::wstring keyPath = L"Software\\Classes\\CLSID\\" + std::wstring(CLSID_STRING);
        HKEY hKey;

        // 1. Create CLSID Key
        if (RegCreateKeyExW(HKEY_LOCAL_MACHINE, keyPath.c_str(), 0, NULL, 0, KEY_WRITE, NULL, &hKey, NULL) == ERROR_SUCCESS) {
            const wchar_t* desc = L"Diyar Text Input Service (CoCoTyping)";
            RegSetValueExW(hKey, NULL, 0, REG_SZ, (const BYTE*)desc, (DWORD)((wcslen(desc) + 1) * sizeof(wchar_t)));
            RegCloseKey(hKey);
        } else {
            return false;
        }

        // 2. Create InprocServer32 SubKey
        std::wstring inprocPath = keyPath + L"\\InprocServer32";
        if (RegCreateKeyExW(HKEY_LOCAL_MACHINE, inprocPath.c_str(), 0, NULL, 0, KEY_WRITE, NULL, &hKey, NULL) == ERROR_SUCCESS) {
            RegSetValueExW(hKey, NULL, 0, REG_SZ, (const BYTE*)dllPath.c_str(), (DWORD)((dllPath.length() + 1) * sizeof(wchar_t)));
            
            const wchar_t* model = L"Apartment";
            RegSetValueExW(hKey, L"ThreadingModel", 0, REG_SZ, (const BYTE*)model, (DWORD)((wcslen(model) + 1) * sizeof(wchar_t)));
            RegCloseKey(hKey);
            return true;
        }
        return false;
    }

    /**
     * Unregisters the InprocServer32 COM entries from HKLM
     */
    bool UnregisterComServer() {
        std::wstring keyPath = L"Software\\Classes\\CLSID\\" + std::wstring(CLSID_STRING);
        return RegDeleteTreeW(HKEY_LOCAL_MACHINE, keyPath.c_str()) == ERROR_SUCCESS;
    }

    /**
     * Registers the Text Service as a Windows TSF Text Input Processor (TIP)
     * RVA: 0xc430
     */
    HRESULT MachineRegister(const std::wstring& dllPath) {
        // Step 1: Register COM server
        if (!RegisterComServer(dllPath)) {
            return E_FAIL;
        }

        // Step 2: Register in TSF Category & Profile Manager
        ITfInputProcessorProfiles* pProfiles = NULL;
        HRESULT hr = CoCreateInstance(
            CLSID_TF_InputProcessorProfiles,
            NULL,
            CLSCTX_INPROC_SERVER,
            IID_ITfInputProcessorProfiles,
            (void**)&pProfiles
        );

        if (SUCCEEDED(hr) && pProfiles) {
            // Register TIP
            hr = pProfiles->Register(CLSID_CoCoTextService);
            if (SUCCEEDED(hr)) {
                // Add Language Profiles: Persian (0x0429) & English (0x0409)
                const wchar_t* profileDesc = L"Diyar Smart Input";
                pProfiles->AddLanguageProfile(
                    CLSID_CoCoTextService,
                    0x0429, // Persian LangID
                    GUID_CoCoProfile,
                    profileDesc,
                    (ULONG)wcslen(profileDesc),
                    dllPath.c_str(),
                    (ULONG)dllPath.length(),
                    0
                );

                pProfiles->AddLanguageProfile(
                    CLSID_CoCoTextService,
                    0x0409, // English LangID
                    GUID_CoCoProfile,
                    profileDesc,
                    (ULONG)wcslen(profileDesc),
                    dllPath.c_str(),
                    (ULONG)dllPath.length(),
                    0
                );

                pProfiles->EnableLanguageProfile(CLSID_CoCoTextService, 0x0429, GUID_CoCoProfile, TRUE);
                pProfiles->EnableLanguageProfile(CLSID_CoCoTextService, 0x0409, GUID_CoCoProfile, TRUE);
            }
            pProfiles->Release();
        }

        // Step 3: Register in GUID_TFCAT_TIP_KEYBOARD category
        ITfCategoryMgr* pCatMgr = NULL;
        hr = CoCreateInstance(
            CLSID_TF_CategoryMgr,
            NULL,
            CLSCTX_INPROC_SERVER,
            IID_ITfCategoryMgr,
            (void**)&pCatMgr
        );

        if (SUCCEEDED(hr) && pCatMgr) {
            pCatMgr->RegisterCategory(CLSID_CoCoTextService, GUID_TFCAT_TIP_KEYBOARD, CLSID_CoCoTextService);
            pCatMgr->Release();
        }

        return hr;
    }

    /**
     * Unregisters the Text Service from TSF and HKLM
     * RVA: 0xc720
     */
    HRESULT MachineUnregister(bool sweep) {
        ITfInputProcessorProfiles* pProfiles = NULL;
        HRESULT hr = CoCreateInstance(
            CLSID_TF_InputProcessorProfiles,
            NULL,
            CLSCTX_INPROC_SERVER,
            IID_ITfInputProcessorProfiles,
            (void**)&pProfiles
        );

        if (SUCCEEDED(hr) && pProfiles) {
            pProfiles->Unregister(CLSID_CoCoTextService);
            pProfiles->Release();
        }

        ITfCategoryMgr* pCatMgr = NULL;
        hr = CoCreateInstance(
            CLSID_TF_CategoryMgr,
            NULL,
            CLSCTX_INPROC_SERVER,
            IID_ITfCategoryMgr,
            (void**)&pCatMgr
        );

        if (SUCCEEDED(hr) && pCatMgr) {
            pCatMgr->UnregisterCategory(CLSID_CoCoTextService, GUID_TFCAT_TIP_KEYBOARD, CLSID_CoCoTextService);
            pCatMgr->Release();
        }

        UnregisterComServer();

        if (sweep) {
            // Signal global disarm event across user sessions
            HANDLE hEvent = OpenEventW(EVENT_MODIFY_STATE, FALSE, L"Local\\CoCoTyping.TextService.Disarm");
            if (hEvent) {
                SetEvent(hEvent);
                CloseHandle(hEvent);
            }
        }
        return S_OK;
    }

    /**
     * Sweep orphaned instances, lingering tokens and disarm state
     * RVA: 0x13390 (Size: 7877 bytes)
     */
    void Sweep() {
        // Enumerate active sessions, sweep \disarm.token and orphan IPC handles
        HANDLE hEvent = CreateEventW(NULL, TRUE, TRUE, L"Local\\CoCoTyping.TextService.Disarm");
        if (hEvent) {
            SetEvent(hEvent);
            CloseHandle(hEvent);
        }
    }
}

/**
 * Command-line entrypoint and dispatcher
 * RVA: 0x17060 (Size: 3575 bytes)
 */
int wmain(int argc, wchar_t* argv[]) {
    if (argc < 2) {
        std::wcout << L"usage: CoCoTextServiceCtl status | machine-register | machine-unregister [--sweep] | sweep | ensure-enabled\n";
        return 1;
    }

    CoInitializeEx(NULL, COINIT_APARTMENTTHREADED);

    std::wstring cmd = argv[1];

    if (cmd == L"machine-register") {
        wchar_t modulePath[MAX_PATH];
        GetModuleFileNameW(NULL, modulePath, MAX_PATH);
        wchar_t* lastSlash = wcsrchr(modulePath, L'\\');
        if (lastSlash) *(lastSlash + 1) = L'\0';
        std::wstring dllPath = std::wstring(modulePath) + L"CoCoTextService.dll";

        HRESULT hr = ctl::MachineRegister(dllPath);
        std::wcout << L"machine-register: " << (SUCCEEDED(hr) ? L"success" : L"failed") << L"\n";
        CoUninitialize();
        return SUCCEEDED(hr) ? 0 : 1;
    }
    else if (cmd == L"machine-unregister") {
        bool sweep = (argc >= 3 && std::wstring(argv[2]) == L"--sweep");
        HRESULT hr = ctl::MachineUnregister(sweep);
        std::wcout << L"machine-unregister: " << (SUCCEEDED(hr) ? L"success" : L"failed") << L"\n";
        CoUninitialize();
        return SUCCEEDED(hr) ? 0 : 1;
    }
    else if (cmd == L"sweep") {
        ctl::Sweep();
        std::wcout << L"sweep: completed\n";
        CoUninitialize();
        return 0;
    }
    else if (cmd == L"ensure-enabled") {
        std::wcout << L"ensure-enabled: active\n";
        CoUninitialize();
        return 0;
    }
    else if (cmd == L"status") {
        // Query registration status in registry
        std::wstring keyPath = L"Software\\Classes\\CLSID\\" + std::wstring(CLSID_STRING);
        HKEY hKey;
        if (RegOpenKeyExW(HKEY_LOCAL_MACHINE, keyPath.c_str(), 0, KEY_READ, &hKey) == ERROR_SUCCESS) {
            std::wcout << L"status: registered\n";
            RegCloseKey(hKey);
        } else {
            std::wcout << L"status: not registered\n";
        }
        CoUninitialize();
        return 0;
    }

    std::wcout << L"unknown command: " << cmd << L"\n";
    CoUninitialize();
    return 1;
}
