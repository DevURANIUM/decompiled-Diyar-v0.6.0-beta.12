import subprocess
import os

targets = [
    ("extracted_app/Betalgo.Ranul.OpenAI.dll", "decompiled_src/Betalgo.Ranul.OpenAI/Betalgo.Ranul.OpenAI.cs"),
    ("extracted_app/MaterialDesignColors.dll", "decompiled_src/MaterialDesignColors/MaterialDesignColors.cs"),
    ("extracted_app/MaterialDesignThemes.Wpf.dll", "decompiled_src/MaterialDesignThemes.Wpf/MaterialDesignThemes.Wpf.cs"),
    ("extracted_app/WinUIEdit.dll", "decompiled_src/WinUIEdit/WinUIEdit.cs"),
    ("extracted_app/Microsoft.AI.Foundry.Local.dll", "decompiled_src/Microsoft.AI.Foundry.Local/Microsoft.AI.Foundry.Local.cs"),
    ("extracted_app/Microsoft.ML.OnnxRuntime.dll", "decompiled_src/Microsoft.ML.OnnxRuntime/Microsoft.ML.OnnxRuntime.cs"),
    ("extracted_app/Microsoft.ML.OnnxRuntimeGenAI.dll", "decompiled_src/Microsoft.ML.OnnxRuntimeGenAI/Microsoft.ML.OnnxRuntimeGenAI.cs"),
    ("extracted_cab/u1", "decompiled_src/WixToolset.BootstrapperApplicationApi/WixToolset.BootstrapperApplicationApi.cs"),
]

for inp, out in targets:
    if os.path.exists(inp):
        cmd = ["dotnet", "run", "--project", "decompiler_tool", "--", os.path.abspath(inp), os.path.abspath(out)]
        res = subprocess.run(cmd, capture_output=True, text=True)
        print(f"[{os.path.basename(inp)}] -> {out} : Exit code {res.returncode}")
        if res.stdout:
            print("  ", res.stdout.strip()[:100])
        if res.returncode != 0 and res.stderr:
            print("  ERR:", res.stderr.strip()[:100])
