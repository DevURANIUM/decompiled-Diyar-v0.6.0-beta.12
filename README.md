# Security Analysis & Comprehensive Reverse Engineering of Diyar
### تحلیل، ارزیابی امنیتی و مهندسی معکوس جامع بسته نصاب نرم‌افزار دیار (Diyar / CoCo Typing)

[![Security Analysis](https://img.shields.io/badge/Security-Analysis%20%26%20Audit-red.svg)](docs/SECURITY_REPORT_EN.md)
[![Reverse Engineering](https://img.shields.io/badge/Reverse%20Engineering-100%25%20Decompiled-blue.svg)](decompiled_src/)
[![Framework](https://img.shields.io/badge/.NET-9.0-purple.svg)](decompiled_src/)
[![Native C++](https://img.shields.io/badge/Native%20C++-Reconstructed-green.svg)](decompiled_src/)
[![MITRE ATT&CK](https://img.shields.io/badge/MITRE%20ATT%26CK-Mapped-orange.svg)](docs/SECURITY_REPORT_EN.md)

---

## 📌 معرفی پرونده (Overview)

این مخزن شامل اسناد ممیزی امنیتی، مهندسی معکوس عمیق، دیکامپایل خط‌به‌خط تمامی کدهای دات‌نت و بازسازی کامل کدهای C++ نیتیو بسته نصاب **«دیار» (Diyar / CoCo Typing)** نسخه `0.6.0-beta.12` می‌باشد. تمامی مراحل بدون اجرای باینری‌ها و به شیوه **ایزوله استاتیک (Zero-Execution Static Analysis)** انجام شده است.

This repository provides full decompiled source code, native C++ reconstructed implementations, and a comprehensive security audit of the **Diyar (CoCo Typing / SmartInput)** installer package v`0.6.0-beta.12`.

---

## 📁 ساختار پوشه‌بندی مخزن (Repository Layout)

```text
├── docs/                                  # مستندات و گزارش‌های تحلیل امنیتی
│   ├── SECURITY_REPORT_FA.md              # گزارش تفصیلی به زبان فارسی (همراه با تحلیل نیتیو TSF)
│   ├── SECURITY_REPORT_EN.md              # English Technical Security & MITRE ATT&CK Audit
│   └── DEPENDENCIES_SECURITY_AUDIT.md     # ممیزی تک‌به‌تک ۱۰۶۳ فایل وابستگی بسته
│
├── decompiled_src/                        # سورس‌کدهای کامل دیکامپایل و بازسازی‌شده
│   ├── SmartInput.App/                    # هسته دات‌نت ۹، سرویس پایپ‌ها و هندلرهای آپدیت
│   ├── SmartInput.Core/                   # متدهای ارزیابی فیلدهای متنی و قوانین پسورد
│   ├── SmartInput.Windows/                # هوک‌های سراسری کیبورد (WH_KEYBOARD_LL) و کلیپ‌بورد
│   ├── SmartInput.WinUI/                  # اینترفیس گرافیکی مدرن WinUI
│   ├── SmartInput.EnvironmentProbe/       # پروب UI Automation برای رصد پنجره‌ها و متن
│   ├── Diyar.Setup/                       # دیکامپایل رابط و بوت‌استرپ نصاب
│   ├── CoCoTextService/                   # بازسازی C++ و دیس‌اسمبل کامل تمامی ۸۲۷ تابع با Capstone
│   ├── CoCoTextServiceCtl/                # بازسازی C++ و دیس‌اسمبل کامل تمامی ۶۵۵ تابع با Capstone
│   ├── Betalgo.Ranul.OpenAI/              # دیکامپایل کلاینت OpenAI
│   ├── MaterialDesignThemes.Wpf/          # دیکامپایل متریال دیزاین WPF
│   ├── MaterialDesignColors/              # دیکامپایل پالت رنگ متریال
│   ├── Microsoft.AI.Foundry.Local/        # دیکامپایل رابط هوش مصنوعی محلی
│   ├── Microsoft.ML.OnnxRuntime/          # دیکامپایل ران‌تایم ONNX دات‌نت
│   ├── Microsoft.ML.OnnxRuntimeGenAI/     # دیکامپایل ران‌تایم هوش مصنوعی مولد
│   └── WixToolset.BootstrapperApplicationApi/ # دیکامپایل کتابخانه بوت‌استرپ WiX
│
├── scripts/                               # اسکریپت‌های تحلیلی، دیس‌اسمبل و ممیزی استاتیک
│   ├── analyze_rtti.py                    # استخراج کلاس‌های RTTI و جدول فانکشن‌های x64
│   ├── reverse_native.py                  # دیس‌اسمبل و ردیابی ارجاعات رشته‌های امنیتی
│   ├── audit_deps.py                      # ممیزی و دسته‌بندی تک‌به‌تک وابستگی‌های بسته
│   ├── analyze_strings.py                 # استخراج الگوها، آدرس‌ها و توکن‌ها
│   ├── dump_msi.ps1                       # استخراج و مپینگ جداول MSI
│   ├── organize_files.ps1                 # استخراج فایل‌های کبینت و نام‌گذاری واقعی
│   └── search_net.py                      # پایش عمیق کلیه سوکت‌ها، پروسه‌ها و درخواست‌های شبکه
│
├── tools/                                 # ابزارهای دیکامپایل مورد استفاده
│   └── decompiler_tool/                   # ابزار کنسول C# مبتنی بر ICSharpCode.Decompiler
│
└── README.md                              # راهنمای جامع مخزن
```

---

## 🔍 پوشش ۱۰۰٪ مهندسی معکوس باینری‌های بسته (Decompilation Coverage)

| نام باینری | معماری و زبان | وضعیت دیکامپایل و بازسازی | لاین‌های سورس کد |
| :--- | :--- | :--- | :--- |
| `SmartInput.App.dll` | C# (.NET 9) | دیکامپایل کامل به C# | ۲۹,۶۰۲ خط |
| `SmartInput.Core.dll` | C# (.NET 9) | دیکامپایل کامل به C# | ۱۶,۱۲۹ خط |
| `SmartInput.Windows.dll` | C# (.NET 9) | دیکامپایل کامل به C# | ۱۰,۶۲۵ خط |
| `SmartInput.WinUI.dll` | C# (.NET 9) | دیکامپایل کامل به C# | ۱۱,۷۲۴ خط |
| `SmartInput.EnvironmentProbe.dll` | C# (.NET 9) | دیکامپایل کامل به C# | ۲,۰۷۸ خط |
| Diyar.Setup.exe | C# (.NET 9 / WiX) | دیکامپایل کامل لایه نصاب به C# | ۳,۸۵۰ خط کد C# |
| CoCoTextService.dll | C++ Native (x64) | دیس‌اسمبل کامل تمامی ۸۲۷ تابع با Capstone + بازسازی C++ | ۳۳,۴۵۰ خط ASM + سورس C++ |
| CoCoTextServiceCtl.exe | C++ Native (x64) | دیس‌اسمبل کامل تمامی ۶۵۵ تابع با Capstone + بازسازی C++ | ۲۲,۱۵۰ خط ASM + سورس C++ |
| Betalgo.Ranul.OpenAI.dll | C# (.NET) | دیکامپایل کامل به C# | ۷,۲۱۰ خط کد C# |
| MaterialDesignThemes.Wpf.dll | C# (.NET) | دیکامپایل کامل به C# | ۳۱,۵۵۰ خط کد C# |
| MaterialDesignColors.dll | C# (.NET) | دیکامپایل کامل به C# | ۴,۱۲۰ خط کد C# |
| Microsoft.AI.Foundry.Local.dll | C# (.NET) | دیکامپایل کامل به C# | ۵,۸۲۰ خط کد C# |
| Microsoft.ML.OnnxRuntime.dll | C# (.NET) | دیکامپایل کامل به C# | ۱۲,۴۳۰ خط کد C# |
| Microsoft.ML.OnnxRuntimeGenAI.dll | C# (.NET) | دیکامپایل کامل به C# | ۳,۹۴۰ خط کد C# |
| WixToolset.BootstrapperApplicationApi.dll | C# (.NET) | دیکامپایل کامل به C# | ۳,۱۸۰ خط کد C# |

---

## 🛡️ شاخص‌های شناسایی و ردپاها (IoCs)

- **Setup Hash (SHA-256):** `ef07bd6e7722478d74352d52315e5b08901aff144898ec15088b76607402afde`
- **CLSID:** `{8300838D-53DF-4662-AB3F-94609D7FB24E}`
- **TSF Profile GUID:** `{B902A980-B149-4F58-A814-F067BC072C9E}`
- **MSI Product Code:** `{D88E77C1-2284-44CC-9974-F983FDD0D8D2}`
- **Named Pipe:** `\\.\pipe\CoCoTyping.TextService.v1.*`
- **Synchronization Events:** `Local\CoCoTyping.TextService.Disarm`
- **Network Endpoints:** `https://diyar.digital/update.json`, `https://api.cognitive.microsofttranslator.com/`

---

## 📑 دسترسی به گزارش‌های تکمیلی (Full Reports)

* 🇮🇷 [گزارش تفصیلی فارسی تحلیل امنیتی بدافزار دیار](docs/SECURITY_REPORT_FA.md)
* 🇬🇧 [English Technical Security Audit & Threat Model](docs/SECURITY_REPORT_EN.md)
* 🔍 [ممیزی تک‌به‌تک ۱۰۶۳ فایل وابستگی بسته](docs/DEPENDENCIES_SECURITY_AUDIT.md)

---

## ⚖️ سلب مسئولیت (Disclaimer)

این مخزن صرفاً با اهداف پژوهشی، ممیزی امنیت نرم‌افزار و تحلیل آسیب‌پذیری‌ها تهیه و منتشر شده است. استفاده از محتوای این پروژه صرفاً برای تحقیقات امنیتی و ارتقای امنیت سایبری مجاز است.

This repository is published solely for educational, security research, and vulnerability analysis purposes.
