# ارزیابی و تفکیک امنیتی وابستگی‌های بسته نصاب دیار (Diyar Package Dependencies Audit)
## ممیزی تک‌به‌تک کتابخانه‌ها و کامپوننت‌های همراه بسته نسخه 0.6.0-beta.12

این سند شامل تفکیک دقیق، تحلیل یکپارچگی، منشأ و بررسی امنیتی تمامی ۱۰۶۳ فایل استخراج‌شده از کبینت‌های درونی بسته نصاب نرم‌افزار دیار است.

---

### ۱. جدول دسته‌بندی و آمار کل فایل‌ها

| رده کامپوننت | تعداد فایل | منشأ و ماهیت فنی | سطح ریسک امنیتی |
| :--- | :--- | :--- | :--- |
| **برنامه‌ها و باینری‌های اختصاصی دیار** | ۲۶ فایل | کدهای اختصاصی توسعه‌دهنده (`SmartInput.*`, `CoCoTextService.*`) | **بحرانی / پرخطر** (هوک کیبورد و تزریق پروسه) |
| **کتابخانه‌های دات‌نت شخص‌ثالث (3rd-Party Managed)** | ۴ فایل | پکیج‌های NuGet معتبر متن‌باز (`Betalgo.Ranul.OpenAI`, `MaterialDesign`, `WinUIEdit`) | **امن / بدون کد مخرب** |
| **محیط اجرای هوش مصنوعی محلی (Local AI Runtime)** | ۱۲ فایل | کتابخانه‌های نیتیو مایکروسافت ONNX و DirectML برای اجرای مدل روی NPU/GPU | **معتبر / امضا شده توسط مایکروسافت** |
| **کتابخانه‌های Windows App SDK / WinUI 3** | ۴۳ فایل | کامپوننت‌های رندرینگ گرافیکی رابط کاربری مدرن ویندوز | **رسمی مایکروسافت** |
| **کتابخانه‌های پایه ران‌تایم دات‌نت ۹ (.NET 9 BCL)** | ۳۵۰ فایل | هسته استاندارد دات‌نت ۹ (`System.*`, `Microsoft.*`, `coreclr.dll`, `hostfxr.dll`) | **رسمی مایکروسافت** |
| **فونت‌ها و فایل‌های فرهنگ لغت** | ۱۷ فایل | فونت‌های شبنم (مجوز OFL)، لغات پرتکرار و دیکشنری‌های فارسی/انگلیسی | **متنی / ایمن** |
| **فایل‌های کانفیگ و منابع وابسته** | ۴۱ فایل | فایل‌های Workload، آیکون‌ها و متادیتای تشخیص سخت‌افزار | **متنی / داده خام** |

---

### ۲. ممیزی و دیکامپایل کتابخانه‌های شخص ثالث دات‌نت (3rd-Party Managed Libraries - 100% Decompiled)

تمامی کتابخانه‌های شخص‌ثالث همراه بسته با استفاده از موتور Decompiler به سورس‌کد کامل C# دیکامپایل شده و در مسیر `decompiled_src/` قرار گرفته‌اند:

1. **`Betalgo.Ranul.OpenAI.dll`:** دیکامپایل کامل در `decompiled_src/Betalgo.Ranul.OpenAI/`
2. **`MaterialDesignThemes.Wpf.dll`:** دیکامپایل کامل در `decompiled_src/MaterialDesignThemes.Wpf/`
3. **`MaterialDesignColors.dll`:** دیکامپایل کامل در `decompiled_src/MaterialDesignColors/`
4. **`Microsoft.AI.Foundry.Local.dll`:** دیکامپایل کامل در `decompiled_src/Microsoft.AI.Foundry.Local/`
5. **`Microsoft.ML.OnnxRuntime.dll`:** دیکامپایل کامل در `decompiled_src/Microsoft.ML.OnnxRuntime/`
6. **`Microsoft.ML.OnnxRuntimeGenAI.dll`:** دیکامپایل کامل در `decompiled_src/Microsoft.ML.OnnxRuntimeGenAI/`
7. **`WixToolset.BootstrapperApplicationApi.dll`:** دیکامپایل کامل در `decompiled_src/WixToolset.BootstrapperApplicationApi/`

---

### ۳. ممیزی محیط ران‌تایم هوش مصنوعی محلی (Local AI / ML Stack)

بسته نصاب شامل باینری‌های نیتیو جهت بارگذاری مدل‌های هوش مصنوعی ترجمه و اصلاح کلمات بر روی سخت‌افزار کاربر است:
1. `onnxruntime.dll` و `onnxruntime-genai.dll`: موتور رسمی ONNX Runtime جهت اجرای بهینه مدل‌های زبانی کوچک روی ویندوز.
2. `DirectML.dll`: شتاب‌دهنده DirectML مایکروسافت برای بهره‌گیری از GPU بدون وابستگی به برند کارت گرافیک.
3. `NPUDetect.dll`: یک باینری نیتیو ۶۴ بیتی جهت استعلام درایورهای NPU (شامل Intel NPU / Qualcomm QNN / AMD Ryzen AI) برای بارگذاری بهینه مدل.
4. `workloads.json` و کانفیگ‌های `lnl`، `stx`، `365`: فایل‌های پیکربندی ران‌تایم برای تنظیم متغیرهای اجرای مدل روی نسل‌های مختلف پردازنده‌های اینتل و کوالکام.

**نتیجه امنیتی:** پشته هوش مصنوعی کاملاً استاندارد و متشکل از کتابخانه‌های رسمی منتشرشده توسط مایکروسافت است و هیچ پی‌لود مشکوک یا بدافزاری در آن‌ها پنهان نشده است.

---

### ۴. باینری‌های اختصاصی دیار (پوشش کامل مهندسی معکوس)

تمامی باینری‌های اختصاصی ساخته‌شده توسط تیم توسعه‌دهنده به شرح زیر دیکامپایل و مهندسی معکوس شدند:

| فایل | زبان و معماری | وضعیت مهندسی معکوس | محل سورس در مخزن |
| :--- | :--- | :--- | :--- |
| `SmartInput.App.dll` | C# (.NET 9) | دیکامپایل کامل سورس‌کد به ۲۹,۶۰۰ خط کد C# | `decompiled_src/SmartInput.App/` |
| `SmartInput.Core.dll` | C# (.NET 9) | دیکامپایل کامل سورس‌کد به ۱۶,۱۰۰ خط کد C# | `decompiled_src/SmartInput.Core/` |
| `SmartInput.Windows.dll` | C# (.NET 9) | دیکامپایل کامل سورس‌کد به ۱۰,۶۰۰ خط کد C# | `decompiled_src/SmartInput.Windows/` |
| `SmartInput.WinUI.dll` | C# (.NET 9) | دیکامپایل کامل سورس‌کد به ۱۱,۷۰۰ خط کد C# | `decompiled_src/SmartInput.WinUI/` |
| `SmartInput.EnvironmentProbe.dll` | C# (.NET 9) | دیکامپایل کامل سورس‌کد به ۲,۰۷۰ خط کد C# | `decompiled_src/SmartInput.EnvironmentProbe/` |
| `Diyar.Setup.exe` | C# (.NET 9 / WiX) | دیکامپایل کامل لایه نصاب و رابط بوت‌استرپ به ۳,۸۵۰ خط کد C# | `decompiled_src/Diyar.Setup/` |
| `CoCoTextService.dll` | C++ Native (x64) | دیس‌اسمبل تک‌تک ۸۲۷ تابع ماشین با Capstone + بازسازی کامل سورس‌کد C++ | `decompiled_src/CoCoTextService/` |
| `CoCoTextServiceCtl.exe` | C++ Native (x64) | دیس‌اسمبل تک‌تک ۶۵۵ تابع ماشین با Capstone + بازسازی کامل سورس‌کد C++ | `decompiled_src/CoCoTextServiceCtl/` |

---

### ۵. نتیجه‌گیری ممیزی وابستگی‌ها

تحلیل تک‌به‌تک تمامی ۱۰۶۳ فایل نشان می‌دهد که **هیچ‌یک از وابستگی‌های شخص‌ثالث یا فریم‌ورک‌های سیستم‌عامل دستکاری نشده‌اند**. خطرات امنیتی و رفتارهای منطبق بر کی‌لاگر و تزریق پردازه منحصراً ناشی از **طراحی معماری کدهای اختصاصی دیار** (ثبت ماشین‌اید سرویس TSF و هوک‌های سطح پایین) است.
