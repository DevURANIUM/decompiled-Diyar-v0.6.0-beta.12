import re

with open('extracted_app/CoCoTextService.dll', 'rb') as f:
    data = f.read()

# Find all ASCII and UTF-16 strings with length >= 4
ascii_strings = [s.decode('ascii', errors='ignore') for s in re.findall(rb'[\x20-\x7e]{4,}', data)]
utf16_strings = [s.decode('utf-16le', errors='ignore') for s in re.findall(rb'(?:[\x20-\x7e]\x00){4,}', data)]

all_strings = sorted(set(ascii_strings + utf16_strings))

print(f"Total strings extracted: {len(all_strings)}")
print("\n--- Pipe / IPC related ---")
for s in all_strings:
    if any(k in s.lower() for k in ['pipe', 'service', 'client', 'server', 'connect', 'disarm', 'token', 'pass', 'key', 'hook', 'inject']):
        print(" ", s)

print("\n--- Window / Process / Class names ---")
for s in all_strings:
    if any(k in s.lower() for k in ['class', 'window', 'getgui', 'focus', 'edit', 'input', 'event']):
        print(" ", s)
