using System;
using System.IO;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;

namespace DecompilerTool;

class Program
{
    static int Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: decompiler_tool <input-assembly-path> <output-cs-path>");
            return 1;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Error: Input file not found: {inputPath}");
            return 1;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(Path.GetFullPath(outputPath))!);

        var settings = new DecompilerSettings
        {
            ThrowOnAssemblyResolveErrors = false,
            RemoveDeadCode = false,
            ShowXmlDocumentation = true
        };

        try
        {
            Console.WriteLine($"Decompiling {Path.GetFileName(inputPath)} -> {outputPath}...");
            var decompiler = new CSharpDecompiler(inputPath, settings);
            string code = decompiler.DecompileWholeModuleAsString();
            File.WriteAllText(outputPath, code);
            Console.WriteLine($"-> Done ({code.Length} characters).");
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Decompilation error for {inputPath}: {ex.Message}");
            return 1;
        }
    }
}
