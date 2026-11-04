import struct
import os

def parse_pe_imports_exports(pe_path):
    with open(pe_path, 'rb') as f:
        data = f.read()

    e_lfanew = struct.unpack_from('<I', data, 0x3c)[0]
    magic = struct.unpack_from('<H', data, e_lfanew + 24)[0]
    is_64 = (magic == 0x20b)
    
    # Data directories
    data_dir_offset = e_lfanew + 24 + (112 if is_64 else 96)
    export_rva, export_size = struct.unpack_from('<II', data, data_dir_offset)
    import_rva, import_size = struct.unpack_from('<II', data, data_dir_offset + 8)

    num_sections = struct.unpack_from('<H', data, e_lfanew + 6)[0]
    opt_size = struct.unpack_from('<H', data, e_lfanew + 20)[0]
    sec_offset = e_lfanew + 24 + opt_size

    sections = []
    for i in range(num_sections):
        s_data = data[sec_offset + i*40 : sec_offset + (i+1)*40]
        s_name = s_data[:8].rstrip(b'\x00').decode('latin1', errors='ignore')
        vsize, vaddr, rsize, raddr = struct.unpack_from('<IIII', s_data, 8)
        sections.append((s_name, vaddr, vsize, raddr, rsize))

    def rva_to_offset(rva):
        for s_name, vaddr, vsize, raddr, rsize in sections:
            if vaddr <= rva < vaddr + vsize:
                return raddr + (rva - vaddr)
        return None

    print(f"=== {os.path.basename(pe_path)} ===")
    print(f"Arch: {'x64' if is_64 else 'x86'}")
    
    # Exports
    if export_rva:
        exp_off = rva_to_offset(export_rva)
        if exp_off:
            num_funcs, num_names, funcs_rva, names_rva, ords_rva = struct.unpack_from('<IIIII', data, exp_off + 20)
            names_off = rva_to_offset(names_rva)
            print(f"Exported functions ({num_names}):")
            for i in range(min(num_names, 50)):
                n_rva = struct.unpack_from('<I', data, names_off + i*4)[0]
                n_off = rva_to_offset(n_rva)
                if n_off:
                    end = data.find(b'\x00', n_off)
                    print(f"  {data[n_off:end].decode('latin1', errors='ignore')}")

    # Imports
    if import_rva:
        imp_off = rva_to_offset(import_rva)
        if imp_off:
            print("\nImported DLLs & Functions:")
            idx = 0
            while True:
                desc = data[imp_off + idx*20 : imp_off + (idx+1)*20]
                if not any(desc):
                    break
                orig_first_thunk, _, _, name_rva, first_thunk = struct.unpack_from('<IIIII', desc)
                n_off = rva_to_offset(name_rva)
                dll_name = data[n_off:data.find(b'\x00', n_off)].decode('latin1', errors='ignore')
                
                # Read functions
                thunk_rva = orig_first_thunk if orig_first_thunk else first_thunk
                thunk_off = rva_to_offset(thunk_rva)
                funcs = []
                if thunk_off:
                    step = 8 if is_64 else 4
                    t_idx = 0
                    while True:
                        val = struct.unpack_from('<Q' if is_64 else '<I', data, thunk_off + t_idx*step)[0]
                        if val == 0:
                            break
                        if not (val & (1 << (63 if is_64 else 31))):
                            fname_off = rva_to_offset(val) + 2
                            fname = data[fname_off:data.find(b'\x00', fname_off)].decode('latin1', errors='ignore')
                            funcs.append(fname)
                        t_idx += 1
                print(f"  [{dll_name}] ({len(funcs)} functions): {', '.join(funcs[:8])}{'...' if len(funcs)>8 else ''}")
                idx += 1

parse_pe_imports_exports('extracted_app/CoCoTextService.dll')
parse_pe_imports_exports('extracted_app/CoCoTextServiceCtl.exe')
