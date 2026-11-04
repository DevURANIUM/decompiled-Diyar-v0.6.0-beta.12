import os, re

target = 'decompiled_src/SmartInput.App/SmartInput.App.cs'
with open(target, 'r', encoding='utf-8') as f:
    lines = f.readlines()

in_ts = False
for i, line in enumerate(lines):
    if 'namespace SmartInput.App.Services.TextService' in line:
        in_ts = True
        print(f"Start of TextService namespace at line {i+1}")
    elif in_ts and line.startswith('namespace '):
        print(f"End of TextService namespace at line {i+1}")
        break
    if in_ts:
        if any(keyword in line for keyword in ['class ', 'interface ', 'struct ', 'enum ', 'public ', 'internal ']):
            if any(term in line for term in ['Pipe', 'Connect', 'Key', 'Token', 'Disarm', 'Message', 'Send', 'Read', 'Write', 'State']):
                print(f"[{i+1}] {line.strip()[:120]}")
