import pefile
import struct
import os

def analyze_rtti_and_vtables(pe_path):
    pe = pefile.PE(pe_path)
    print(f"\n==========================================")
    print(f"RTTI & VTABLE ANALYSIS: {os.path.basename(pe_path)}")
    print(f"==========================================")
    
    # Locate .rdata and .data
    rdata = None
    data = None
    text = None
    for s in pe.sections:
        name = s.Name.rstrip(b'\x00').decode('latin1', errors='ignore')
        if name == '.rdata': rdata = s
        elif name == '.data': data = s
        elif name == '.text': text = s
        
    image_base = pe.OPTIONAL_HEADER.ImageBase
    raw_data = pe.get_memory_mapped_image()

    # Search for RTTI Complete Object Locator in 64-bit:
    # struct _RTTICompleteObjectLocator {
    #     DWORD signature; // 1 in 64-bit
    #     DWORD offset; // offset of vfptr
    #     DWORD cdOffset;
    #     DWORD pTypeDescriptor; // RVA to TypeDescriptor
    #     DWORD pClassDescriptor; // RVA to _RTTIClassHierarchyDescriptor
    #     DWORD pSelf; // RVA to _RTTICompleteObjectLocator
    # }
    
    type_descriptors = {}
    # Find TypeDescriptors: starts with vfptr to type_info::vftable, then 8 bytes null/ptr, then ".?AV..." or ".?AU..."
    pos = 0
    while True:
        pos = raw_data.find(b'.?A', pos)
        if pos == -1: break
        # Walk back to find start of name
        end = raw_data.find(b'\x00', pos)
        if end != -1:
            mangled = raw_data[pos:end].decode('latin1', errors='ignore')
            # In MSVC 64-bit TypeDescriptor, mangled name is at offset 16 from TypeDescriptor start
            td_rva = pos - 16
            type_descriptors[td_rva] = mangled
        pos = end if end != -1 else pos + 1

    print(f"Found {len(type_descriptors)} C++ Classes/Types from RTTI:")
    for rva, name in sorted(type_descriptors.items(), key=lambda x: x[1]):
        if any(term in name for term in ['cts', 'TextService', 'ITf', 'Edit', 'Sink', 'Host', 'Pipe', 'Event', 'Probe', 'Ctl']):
            print(f"  {name}")
            
    # Also dump .pdata function count
    if hasattr(pe, 'DIRECTORY_ENTRY_EXCEPTION'):
        entries = pe.DIRECTORY_ENTRY_EXCEPTION
        print(f"\nTotal x64 functions in .pdata (RUNTIME_FUNCTION table): {len(entries)}")

analyze_rtti_and_vtables('extracted_app/CoCoTextService.dll')
analyze_rtti_and_vtables('extracted_app/CoCoTextServiceCtl.exe')
