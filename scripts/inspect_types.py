import re
import os

decomp_dir = r"decompiled_src"

for root, dirs, files in os.walk(decomp_dir):
    for f in files:
        if f.endswith('.cs'):
            path = os.path.join(root, f)
            print(f"=== {f} ===")
            with open(path, 'r', encoding='utf-8', errors='ignore') as fp:
                content = fp.read()
                namespaces = set(re.findall(r'namespace\s+([\w\.]+)', content))
                classes = re.findall(r'(?:public|internal|private)\s+(?:static\s+|sealed\s+|abstract\s+)?(?:class|interface|struct|enum)\s+(\w+)', content)
                print(f"Namespaces ({len(namespaces)}):", sorted(namespaces))
                print(f"Total classes/types: {len(classes)}")
                print(f"Sample classes: {classes[:25]}\n")
