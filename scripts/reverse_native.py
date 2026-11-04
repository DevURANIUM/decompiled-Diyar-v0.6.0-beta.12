import pefile
import capstone
import struct
import os

def analyze_native_binary(pe_path):
    pe = pefile.PE(pe_path)
    base_name = os.path.basename(pe_path)
    print(f"\n=======================================================")
    print(f"DEEP DISASSEMBLY & REVERSE ENGINEERING: {base_name}")
    print(f"=======================================================")

    image_base = pe.OPTIONAL_HEADER.ImageBase
    raw_data = pe.get_memory_mapped_image()

    text_sec = None
    rdata_sec = None
    for s in pe.sections:
        sname = s.Name.rstrip(b'\x00').decode('latin1', errors='ignore')
        if sname == '.text': text_sec = s
        elif sname == '.rdata': rdata_sec = s

    if not text_sec:
        print("No .text section found")
        return

    text_bytes = text_sec.get_data()
    text_rva = text_sec.VirtualAddress
    text_va = image_base + text_rva

    md = capstone.Cs(capstone.CS_ARCH_X86, capstone.CS_MODE_64)
    md.detail = True

    # Build function table from .pdata
    functions = []
    if hasattr(pe, 'DIRECTORY_ENTRY_EXCEPTION'):
        for entry in pe.DIRECTORY_ENTRY_EXCEPTION:
            begin = entry.struct.BeginAddress
            end = entry.struct.EndAddress
            unwind = entry.struct.UnwindData
            functions.append((begin, end))
    functions.sort(key=lambda x: x[0])
    print(f"Loaded {len(functions)} functions from RUNTIME_FUNCTION (.pdata)")

    def find_func_for_rva(rva):
        for b, e in functions:
            if b <= rva < e:
                return (b, e)
        return (None, None)

    # Search for key strings and their xrefs in code
    target_strings = [
        "CoCoTyping.TextService",
        "disarm",
        "password",
        "ITfKeystrokeMgr",
        "PreserveKey",
        "machine-register",
        "machine-unregister",
        "sweep",
        "Software\\Classes\\CLSID",
        "Pipe",
        "token",
        "admitted",
        "chord",
        "focus"
    ]

    string_rvas = {}
    for ts in target_strings:
        b_str = ts.encode('latin1')
        b_wstr = ts.encode('utf-16le')
        pos = 0
        while True:
            pos = raw_data.find(b_str, pos)
            if pos == -1: break
            string_rvas[pos] = (ts, "ascii")
            pos += 1
        pos = 0
        while True:
            pos = raw_data.find(b_wstr, pos)
            if pos == -1: break
            string_rvas[pos] = (ts, "utf-16")
            pos += 1

    print(f"Located {len(string_rvas)} string instances in binary.")

    # Disassemble .text to find RIP-relative references (lea r, [rip + disp])
    xrefs = {}
    for insn in md.disasm(text_bytes, text_va):
        # Look for rip-relative memory operand
        for op in insn.operands:
            if op.type == capstone.x86.X86_OP_MEM and op.mem.base == capstone.x86.X86_REG_RIP:
                target_va = insn.address + insn.size + op.mem.disp
                target_rva = target_va - image_base
                if target_rva in string_rvas:
                    insn_rva = insn.address - image_base
                    fb, fe = find_func_for_rva(insn_rva)
                    str_val, enc = string_rvas[target_rva]
                    if fb not in xrefs:
                        xrefs[fb] = []
                    xrefs[fb].append((insn_rva, str_val, insn))

    print(f"\nFunctions referencing target security/IPC strings: {len(xrefs)}")
    for fb, refs in sorted(xrefs.items(), key=lambda x: len(x[1]), reverse=True):
        fe = next((e for b, e in functions if b == fb), 0)
        print(f"\n>>> Function at RVA 0x{fb:x} - 0x{fe:x} (Size: {fe - fb} bytes):")
        for irva, sval, insn in refs[:8]:
            print(f"    [0x{irva:x}] {insn.mnemonic} {insn.op_str}  --> String: '{sval}'")

analyze_native_binary('extracted_app/CoCoTextService.dll')
analyze_native_binary('extracted_app/CoCoTextServiceCtl.exe')
