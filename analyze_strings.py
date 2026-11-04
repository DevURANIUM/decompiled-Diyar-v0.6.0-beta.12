import re
import os
import sys

def extract_strings(filepath, min_len=4):
    with open(filepath, 'rb') as f:
        data = f.read()
    
    # ASCII strings
    ascii_strings = re.findall(rb'[\x20-\x7e]{' + str(min_len).encode() + rb',}', data)
    # UTF-16LE strings
    utf16_strings = re.findall(rb'(?:[\x20-\x7e]\x00){' + str(min_len).encode() + rb',}', data)
    
    res = [s.decode('ascii', errors='ignore') for s in ascii_strings]
    res += [s.decode('utf-16le', errors='ignore') for s in utf16_strings]
    return res

interesting_patterns = [
    re.compile(r'https?://[^\s"\'<>]+', re.IGNORECASE),
    re.compile(r'\b(?:\d{1,3}\.){3}\d{1,3}\b'),
    re.compile(r'[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,5}'),
    re.compile(r'(?:api[_-]?key|token|secret|password|bearer|auth|credentials)[\s:=]+[^\s"\'<>]{8,}', re.IGNORECASE),
    re.compile(r'(?:SOFTWARE|SYSTEM)\\[^\s"\'<>]+', re.IGNORECASE),
    re.compile(r'(?:telegram|discord|webhook|pastebin|ngrok|c2|bot)', re.IGNORECASE),
]

target_files = [
    'extracted_app/CoCoTextService.dll',
    'extracted_app/CoCoTextServiceCtl.exe',
    'extracted_app/SmartInput.App.dll',
    'extracted_app/SmartInput.Core.dll',
    'extracted_app/SmartInput.WinUI.dll',
    'extracted_app/SmartInput.Windows.dll',
    'extracted_app/SmartInput.EnvironmentProbe.dll',
    'extracted_app/RestartAgent.exe',
]

for tf in target_files:
    if not os.path.exists(tf):
        print(f"File not found: {tf}")
        continue
    print(f"\n==========================================")
    print(f"ANALYZING: {tf} (size: {os.path.getsize(tf)} bytes)")
    print(f"==========================================")
    strings = extract_strings(tf)
    
    # URLs
    urls = set()
    for s in strings:
        for m in re.finditer(r'https?://[^\s"\'<>]+', s):
            urls.add(m.group(0))
    if urls:
        print("\n--- URLs Found ---")
        for u in sorted(urls):
            print("  ", u)
            
    # Registry keys
    reg_keys = set()
    for s in strings:
        for m in re.finditer(r'(?:Software|System|HKEY_[A-Z_]+)\\[a-zA-Z0-9_\\-]+', s, re.IGNORECASE):
            reg_keys.add(m.group(0))
    if reg_keys:
        print("\n--- Registry Keys ---")
        for r in sorted(reg_keys):
            print("  ", r)

    # Keywords of interest
    keywords = ['keylog', 'hook', 'inject', 'socket', 'pipe', 'telemetry', 'upload', 'download', 'execute', 'payload', 'stealer', 'crypto', 'wallet', 'token', 'pass', 'intercept', 'keystroke']
    matching_keywords = {}
    for kw in keywords:
        matches = [s for s in strings if kw in s.lower()]
        if matches:
            matching_keywords[kw] = matches[:10] # limit 10
            
    if matching_keywords:
        print("\n--- Interesting Keyword Hits ---")
        for kw, hits in matching_keywords.items():
            print(f"  [{kw}] ({len(hits)} occurrences shown):")
            for h in hits[:5]:
                print(f"     -> {h.strip()[:120]}")
