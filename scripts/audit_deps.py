import os
import hashlib

categories = {
    "Custom Proprietary Applications (Diyar)": [],
    "Third-Party Managed Libraries (.NET)": [],
    "Local AI & Machine Learning Runtime": [],
    "Microsoft Windows App SDK / WinUI 3 Runtime": [],
    "Microsoft .NET 9 BCL & Runtime Files": [],
    "Fonts & Dictionaries": [],
    "Configuration & Miscellaneous": []
}

app_dir = 'extracted_app'

for f in sorted(os.listdir(app_dir)):
    p = os.path.join(app_dir, f)
    if os.path.isdir(p): continue
    size = os.path.getsize(p)
    
    # Categorize
    if f.startswith('SmartInput.') or f.startswith('CoCoTextService') or f.startswith('coco-') or f.startswith('diyar'):
        categories["Custom Proprietary Applications (Diyar)"].append((f, size))
    elif f in ['Betalgo.Ranul.OpenAI.dll', 'MaterialDesignThemes.Wpf.dll', 'MaterialDesignColors.dll', 'WinUIEdit.dll']:
        categories["Third-Party Managed Libraries (.NET)"].append((f, size))
    elif any(k in f.lower() for k in ['onnx', 'directml', 'npudetect', 'foundry']):
        categories["Local AI & Machine Learning Runtime"].append((f, size))
    elif any(k in f.lower() for k in ['winui', 'xaml', 'dwrite', 'dwm', 'mrm', 'reachframework', 'presentation', 'windowsbase', 'interop.uiautomation']):
        categories["Microsoft Windows App SDK / WinUI 3 Runtime"].append((f, size))
    elif f.endswith('.ttf') or f.endswith('.txt') or 'frequency' in f or 'dictionary' in f:
        categories["Fonts & Dictionaries"].append((f, size))
    elif f.startswith('System.') or f.startswith('Microsoft.') or f.startswith('clr') or f.startswith('mscor') or f in ['coreclr.dll', 'hostfxr.dll', 'hostpolicy.dll', 'netstandard.dll']:
        categories["Microsoft .NET 9 BCL & Runtime Files"].append((f, size))
    else:
        categories["Configuration & Miscellaneous"].append((f, size))

for cat, items in categories.items():
    print(f"=== {cat} ({len(items)} files) ===")
    for name, size in items[:8]:
        print(f"  {name:40} : {size:>10} bytes")
    if len(items) > 8:
        print(f"  ... and {len(items) - 8} more files.")
