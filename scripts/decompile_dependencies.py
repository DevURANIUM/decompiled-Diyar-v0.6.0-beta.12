import os
import subprocess

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

# We can use our decompiler_tool or run a custom decompiler runner in C#
print("Targets to decompile:", len(targets))
