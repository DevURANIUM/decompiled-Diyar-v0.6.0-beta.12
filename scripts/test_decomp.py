import pefile
import capstone
import struct
import os

pe = pefile.PE('extracted_app/CoCoTextService.dll')
image_base = pe.OPTIONAL_HEADER.ImageBase

# Map all imported functions by IAT / thunk RVA
imports = {}
for entry in pe.DIRECTORY_ENTRY_IMPORT:
    dll = entry.dll.decode('latin1', errors='ignore')
    for imp in entry.imports:
        if imp.name:
            imports[imp.address - image_base] = (dll, imp.name.decode('latin1', errors='ignore'))

# Strings
raw = pe.get_memory_mapped_image()
def get_str(rva):
    if rva < len(raw):
        # check ascii
        end_a = raw.find(b'\x00', rva)
        if end_a != -1 and end_a - rva >= 3:
            s = raw[rva:end_a]
            if all(32 <= b <= 126 for b in s):
                return s.decode('ascii')
        # check utf16
        end_w = raw.find(b'\x00\x00', rva)
        if end_w != -1 and (end_w - rva) % 2 == 0 and end_w - rva >= 6:
            try:
                s = raw[rva:end_w].decode('utf-16le')
                if all(ord(c) >= 32 and ord(c) < 127 for c in s):
                    return s
            except:
                pass
    return None

md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
md.detail = True

# Inspect function 0x9100 (Activate / Initialize)
text_sec = [s for s in pe.sections if s.Name.startswith(b'.text')][0]
text_bytes = text_sec.get_data()
text_rva = text_sec.VirtualAddress

def decompile_func(func_rva, func_len):
    offset = func_rva - text_rva
    code = text_bytes[offset : offset + func_len]
    print(f"--- Decompiling func 0x{func_rva:x} (len {func_len}) ---")
    for insn in md.disasm(code, image_base + func_rva):
        line = f"0x{insn.address - image_base:x}: {insn.mnemonic} {insn.op_str}"
        # resolve rip-rel
        for op in insn.operands:
            if op.type == capstone.x86.X86_OP_MEM and op.mem.base == capstone.x86.X86_REG_RIP:
                target_rva = insn.address + insn.size + op.mem.disp - image_base
                if target_rva in imports:
                    line += f"  ; Import: {imports[target_rva][0]}!{imports[target_rva][1]}"
                else:
                    s = get_str(target_rva)
                    if s: line += f"  ; Str: \"{s}\""
        print("  ", line)

print("Function 0x170a0 (PreserveKey):")
decompile_func(0x170a0, 300)
