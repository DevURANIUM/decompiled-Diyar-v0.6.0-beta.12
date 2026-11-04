import pefile
import capstone
import struct
import os

def full_disassemble(pe_path, out_asm_path):
    print(f"Disassembling {pe_path} -> {out_asm_path}...")
    pe = pefile.PE(pe_path)
    image_base = pe.OPTIONAL_HEADER.ImageBase

    # Imports
    imports = {}
    if hasattr(pe, 'DIRECTORY_ENTRY_IMPORT'):
        for entry in pe.DIRECTORY_ENTRY_IMPORT:
            dll = entry.dll.decode('latin1', errors='ignore')
            for imp in entry.imports:
                if imp.name:
                    imports[imp.address - image_base] = f"{dll}!{imp.name.decode('latin1', errors='ignore')}"

    # Strings
    raw = pe.get_memory_mapped_image()
    def get_str(rva):
        if rva < len(raw):
            end_a = raw.find(b'\x00', rva)
            if end_a != -1 and 3 <= end_a - rva <= 200:
                s = raw[rva:end_a]
                if all(32 <= b <= 126 for b in s):
                    return s.decode('ascii')
            end_w = raw.find(b'\x00\x00', rva)
            if end_w != -1 and (end_w - rva) % 2 == 0 and 6 <= end_w - rva <= 400:
                try:
                    s = raw[rva:end_w].decode('utf-16le')
                    if all(32 <= ord(c) < 127 for c in s):
                        return s
                except:
                    pass
        return None

    # Functions from .pdata
    functions = []
    if hasattr(pe, 'DIRECTORY_ENTRY_EXCEPTION'):
        for entry in pe.DIRECTORY_ENTRY_EXCEPTION:
            begin = entry.struct.BeginAddress
            end = entry.struct.EndAddress
            functions.append((begin, end))
    functions.sort(key=lambda x: x[0])

    text_sec = [s for s in pe.sections if s.Name.startswith(b'.text')][0]
    text_data = text_sec.get_data()
    text_rva = text_sec.VirtualAddress

    md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
    md.detail = True

    os.makedirs(os.path.dirname(os.path.abspath(out_asm_path)), exist_ok=True)
    with open(out_asm_path, 'w', encoding='utf-8') as out:
        out.write(f"; ==============================================================================\n")
        out.write(f"; Complete Function-by-Function Native Disassembly: {os.path.basename(pe_path)}\n")
        out.write(f"; Architecture: x86_64 (AMD64) | Base Address: 0x{image_base:x}\n")
        out.write(f"; Total Exception-Registered Functions: {len(functions)}\n")
        out.write(f"; ==============================================================================\n\n")

        for idx, (f_begin, f_end) in enumerate(functions):
            f_size = f_end - f_begin
            out.write(f"\n; ------------------------------------------------------------------------------\n")
            out.write(f"; Function [{idx+1}/{len(functions)}]: sub_{f_begin:08X} (RVA: 0x{f_begin:X} - 0x{f_end:X}, Size: {f_size} bytes)\n")
            out.write(f"; ------------------------------------------------------------------------------\n")
            out.write(f"sub_{f_begin:08X} proc\n")

            offset = f_begin - text_rva
            if 0 <= offset < len(text_data):
                f_bytes = text_data[offset : min(offset + f_size, len(text_data))]
                for insn in md.disasm(f_bytes, image_base + f_begin):
                    comment = ""
                    for op in insn.operands:
                        if op.type == capstone.x86.X86_OP_MEM and op.mem.base == capstone.x86.X86_REG_RIP:
                            target_rva = insn.address + insn.size + op.mem.disp - image_base
                            if target_rva in imports:
                                comment = f" ; Import: {imports[target_rva]}"
                            else:
                                s = get_str(target_rva)
                                if s:
                                    comment = f" ; \"{s}\""
                    hex_bytes = " ".join(f"{b:02X}" for b in insn.bytes)
                    out.write(f"    0x{insn.address:012X}:  {hex_bytes:24}  {insn.mnemonic:8} {insn.op_str}{comment}\n")
            out.write(f"sub_{f_begin:08X} endp\n")

    print(f"-> Successfully generated full disassembly: {out_asm_path} ({len(functions)} functions)")

full_disassemble('extracted_app/CoCoTextService.dll', 'decompiled_src/CoCoTextService/CoCoTextService_Complete_Disassembly.asm')
full_disassemble('extracted_app/CoCoTextServiceCtl.exe', 'decompiled_src/CoCoTextServiceCtl/CoCoTextServiceCtl_Complete_Disassembly.asm')
