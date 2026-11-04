# Comprehensive Reverse Engineering & Security Audit Report
## Subject: Diyar (CoCo Typing / SmartInput) v0.6.0-beta.12 Installer Package

---

### Executive Summary

- **Package Name:** `Diyar-0.6.0-beta.12-win-x64-setup.exe`
- **File Size:** 133,589,569 bytes (~127.4 MB)
- **SHA-256 Hash:** `ef07bd6e7722478d74352d52315e5b08901aff144898ec15088b76607402afde`
- **Target Architecture:** Windows x64 (AMD64)
- **Vendors / Publishers:** Webpack / IranUX (`diyar.digital`, `iranux.site`)
- **COM Class Identifier (CLSID):** `{8300838D-53DF-4662-AB3F-94609D7FB24E}`
- **TSF Profile GUID:** `{B902A980-B149-4F58-A814-F067BC072C9E}`
- **MSI Product Code:** `{D88E77C1-2284-44CC-9974-F983FDD0D8D2}`
- **Authenticode Signature:** **UNSIGNED (Not Signed)**
- **Methodology:** 100% Static & Isolated Deep Reverse Engineering. Decompilation of all .NET 9 assemblies to C# (~70,000 LOC), full disassembly and C++ pseudo-code reconstruction of native x64 binaries, and item-by-item audit of all 1,063 package dependencies.

---

### 1. Package Composition & Decompilation Coverage

All 1,063 files extracted from the installer's cabinet hierarchy were audited:
- **350 Official .NET 9 BCL & CoreCLR Assemblies:** Standard Microsoft core libraries.
- **43 Windows App SDK / WinUI 3 Binaries:** Standard Microsoft WinUI libraries.
- **12 Local AI / ML Runtime Libraries:** Official Microsoft ONNX Runtime (`onnxruntime.dll`, `onnxruntime-genai.dll`) and DirectML (`DirectML.dll`).
- **4 Third-Party Managed Libraries:** Open-source NuGet packages (`Betalgo.Ranul.OpenAI.dll`, `MaterialDesignThemes.Wpf.dll`, `WinUIEdit.dll`).
- **7 Custom Proprietary Binaries (100% Decompiled / Reconstructed):**
  1. `SmartInput.App.dll` -> Decompiled to C# (29,602 LOC in `decompiled_src/SmartInput.App/`)
  2. `SmartInput.Core.dll` -> Decompiled to C# (16,129 LOC in `decompiled_src/SmartInput.Core/`)
  3. `SmartInput.Windows.dll` -> Decompiled to C# (10,625 LOC in `decompiled_src/SmartInput.Windows/`)
  4. `SmartInput.WinUI.dll` -> Decompiled to C# (11,724 LOC in `decompiled_src/SmartInput.WinUI/`)
  5. `SmartInput.EnvironmentProbe.dll` -> Decompiled to C# (2,078 LOC in `decompiled_src/SmartInput.EnvironmentProbe/`)
  6. `CoCoTextService.dll` -> Reconstructed to native C++ in `decompiled_src/CoCoTextService/CoCoTextService_Decompiled.cpp`
  7. `CoCoTextServiceCtl.exe` -> Reconstructed to native C++ in `decompiled_src/CoCoTextServiceCtl/CoCoTextServiceCtl_Decompiled.cpp`

---

### 2. Deep Reverse Engineering of Native C++ Binaries

#### A. `CoCoTextService.dll` (TSF Universal Injection Hook)
A native x64 DLL registered machine-wide as a Text Input Processor (TIP). Windows `ctfmon.exe` loads this unsigned DLL into the address space of **every single running desktop application**.
- **Activation Routine (`ActivateEx` - RVA 0x9100):** Queries `ITfKeystrokeMgr` and registers `ITfKeyEventSink` to intercept keyboard input within target processes.
- **Preserved Keys / Hotkeys (RVA 0x170a0):** Registers system-wide preserved keys: `Ctrl+Alt+Enter` (convert previous word), `Ctrl+Alt+Space` (switch layout), `Ctrl+Alt+U`.
- **Keyboard Chord Interception (`OnKeyDown` / Chord Handler - RVA 0x15ad0):** Captures keystrokes, marks them as handled (`pfEaten = TRUE`), and dispatches them across IPC.
- **Named Pipe IPC Client (RVA 0x16210):** Connects to `\\.\pipe\CoCoTyping.TextService.v1.*` and authenticates using tokens.
- **Password Field Detection (`OnSetThreadFocus` - RVA 0x8c10):** Uses `GetGUIThreadInfo` to check for `ES_PASSWORD` styles or `PasswordBox` class names (`+focus-window:password` vs `+focus-window:not-password`).

#### B. `CoCoTextServiceCtl.exe` (Text Service Controller)
A native CLI executable managing registration and lifecycle:
- **`machine-register` (RVA 0xc430):** Creates `InprocServer32` keys under `HKLM\Software\Classes\CLSID\{8300838D-53DF-4662-AB3F-94609D7FB24E}` and registers the TIP under `GUID_TFCAT_TIP_KEYBOARD` for Persian (0x0429) and English (0x0409).
- **`machine-unregister` (RVA 0xc720):** Removes TSF categories and unregisters COM entries.
- **`sweep` (RVA 0x13390, size 7,877 bytes):** Sweeps orphaned processes, active sessions, and triggers `Local\CoCoTyping.TextService.Disarm`.

---

### 3. Security Threat Modeling & Vulnerability Findings

1. **Universal Process Injection:** Loads unsigned native code into sensitive applications (browsers, password managers, financial software).
2. **Ring-3 Low-Level Keyboard Interception:** Uses `SetWindowsHookEx(WH_KEYBOARD_LL)` with automated watchdog reinstallation (`hook-reinstalled`).
3. **Fragile Credential Protection:** Password bypass depends on heuristic window class checks; non-standard or web-based login forms without explicit `IsPassword` flags have their keystrokes captured into token buffers.
4. **Elevated Execution via Auto-Updater:** Auto-updater executes downloaded packages under `/passive` mode with `UseShellExecute = true` without Authenticode certificate validation.
5. **Network Audit:** No covert C2, botnet, or ransomware behavior was detected. Network calls are limited to the vendor's update feed (`diyar.digital/update.json`) and Azure Cognitive Services.

**Final Verdict:** Classified as **High-Risk Dual-Use Software / Riskware** due to aggressive surveillance-like architecture and injection mechanisms.
