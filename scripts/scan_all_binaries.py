import os
import pefile

def is_dotnet(file_path):
    try:
        pe = pefile.PE(file_path, fast_load=True)
        # Check COM Descriptor Directory (index 14)
        if len(pe.OPTIONAL_HEADER.DATA_DIRECTORY) > 14:
            com_dir = pe.OPTIONAL_HEADER.DATA_DIRECTORY[14]
            if com_dir.VirtualAddress != 0 and com_dir.Size != 0:
                return True
    except Exception:
        pass
    return False

dotnet_files = []
native_files = []

for base_dir in ['extracted_app', 'extracted_cab']:
    if not os.path.exists(base_dir): continue
    for f in os.listdir(base_dir):
        p = os.path.join(base_dir, f)
        if os.path.isfile(p) and (f.endswith('.dll') or f.endswith('.exe')):
            if is_dotnet(p):
                dotnet_files.append(p)
            else:
                native_files.append(p)

print(f"Total .NET Assemblies found: {len(dotnet_files)}")
print(f"Total Native PE binaries found: {len(native_files)}")

print("\n--- Custom & 3rd Party .NET Assemblies ---")
for p in dotnet_files:
    fname = os.path.basename(p)
    if not fname.startswith('System.') and not fname.startswith('Microsoft.NETCore') and not fname.startswith('mscorlib') and not fname.startswith('WindowsBase') and not fname.startswith('Presentation'):
        print(f"  {fname:45} : {os.path.getsize(p):>10} bytes ({p})")

print("\n--- Native PE Binaries ---")
for p in native_files:
    fname = os.path.basename(p)
    print(f"  {fname:45} : {os.path.getsize(p):>10} bytes ({p})")
