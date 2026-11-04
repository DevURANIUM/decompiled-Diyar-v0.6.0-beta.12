import re
import os

decomp_dir = r"decompiled_src"

patterns = [
    r'HttpClient',
    r'WebClient',
    r'HttpRequestMessage',
    r'HttpWebRequest',
    r'TcpClient',
    r'UdpClient',
    r'Socket',
    r'GetAsync',
    r'PostAsync',
    r'SendAsync',
    r'WebSocket',
    r'OpenAIClient',
    r'OpenAIService',
    r'api\.cognitive\.microsofttranslator\.com',
    r'diyar\.digital',
    r'iranux\.site',
    r'Process\.Start',
]

for root, dirs, files in os.walk(decomp_dir):
    for f in files:
        if f.endswith('.cs'):
            path = os.path.join(root, f)
            with open(path, 'r', encoding='utf-8', errors='ignore') as fp:
                lines = fp.readlines()
                print(f"\n==========================================")
                print(f"SEARCHING IN: {f}")
                print(f"==========================================")
                for i, line in enumerate(lines):
                    for p in patterns:
                        if re.search(r'\b' + p + r'\b', line, re.IGNORECASE):
                            print(f"[{f}:{i+1}] {line.strip()[:140]}")
