import re
import os

decomp_dir = r"decompiled_src"

patterns = [
    r'File\.(?:Write|Append|Create|OpenWrite)',
    r'StreamWriter',
    r'FileStream',
    r'BinaryWriter',
]

for root, dirs, files in os.walk(decomp_dir):
    for f in files:
        if f.endswith('.cs'):
            path = os.path.join(root, f)
            with open(path, 'r', encoding='utf-8', errors='ignore') as fp:
                lines = fp.readlines()
                hits = []
                for i, line in enumerate(lines):
                    for p in patterns:
                        if re.search(p, line):
                            hits.append((i+1, line.strip()))
                if hits:
                    print(f"\n=== {f} ({len(hits)} hits) ===")
                    for line_no, line in hits[:25]:
                        print(f"[{line_no}] {line[:120]}")
