using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.AI;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]
namespace Microsoft.ML.OnnxRuntimeGenAI;

public class Adapters : SafeHandle
{
	internal nint Handle => handle;

	public override bool IsInvalid => handle == IntPtr.Zero;

	public Adapters(Model model)
		: base(IntPtr.Zero, ownsHandle: true)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateAdapters(model.Handle, out handle));
	}

	public void LoadAdapter(string adapterPath, string adapterName)
	{
		Result.VerifySuccess(NativeMethods.OgaLoadAdapter(handle, StringUtils.ToUtf8(adapterPath), StringUtils.ToUtf8(adapterName)));
	}

	public void UnloadAdapter(string adapterName)
	{
		Result.VerifySuccess(NativeMethods.OgaUnloadAdapter(handle, StringUtils.ToUtf8(adapterName)));
	}

	protected override bool ReleaseHandle()
	{
		NativeMethods.OgaDestroyAdapters(handle);
		handle = IntPtr.Zero;
		return true;
	}
}
public class Audios : IDisposable
{
	private nint _audiosHandle;

	private bool _disposed = false;

	internal nint Handle => _audiosHandle;

	private Audios(nint audiosHandle)
	{
		_audiosHandle = audiosHandle;
	}

	public static Audios Load(string[] audioPaths)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateStringArray(out var stringArray));
		foreach (string str in audioPaths)
		{
			Result.VerifySuccess(NativeMethods.OgaStringArrayAddString(stringArray, StringUtils.ToUtf8(str)));
		}
		Result.VerifySuccess(NativeMethods.OgaLoadAudios(stringArray, out var audios));
		NativeMethods.OgaDestroyStringArray(stringArray);
		return new Audios(audios);
	}

	public unsafe static Audios Load(byte[] audioBytesData)
	{
		nint[] array = new nint[1];
		nuint[] audio_data_sizes = new nuint[1] { (nuint)audioBytesData.Length };
		fixed (byte* ptr = audioBytesData)
		{
			array[0] = (nint)ptr;
			Result.VerifySuccess(NativeMethods.OgaLoadAudiosFromBuffers(array, audio_data_sizes, 1u, out var audios));
			return new Audios(audios);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyAudios(_audiosHandle);
			_audiosHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class Config : IDisposable
{
	private nint _configHandle;

	private bool _disposed = false;

	internal nint Handle => _configHandle;

	public Config(string modelPath)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateConfig(StringUtils.ToUtf8(modelPath), out _configHandle));
	}

	public void ClearProviders()
	{
		Result.VerifySuccess(NativeMethods.OgaConfigClearProviders(_configHandle));
	}

	public void AppendProvider(string provider)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigAppendProvider(_configHandle, StringUtils.ToUtf8(provider)));
	}

	public void SetProviderOption(string provider, string option, string value)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigSetProviderOption(_configHandle, StringUtils.ToUtf8(provider), StringUtils.ToUtf8(option), StringUtils.ToUtf8(value)));
	}

	public unsafe void AddModelData(string modelFilename, byte[] modelData)
	{
		fixed (byte* model_data = modelData)
		{
			Result.VerifySuccess(NativeMethods.OgaConfigAddModelData(_configHandle, StringUtils.ToUtf8(modelFilename), model_data, (nuint)modelData.Length));
		}
	}

	public void RemoveModelData(string modelFilename)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigRemoveModelData(_configHandle, StringUtils.ToUtf8(modelFilename)));
	}

	public void Overlay(string json)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigOverlay(_configHandle, StringUtils.ToUtf8(json)));
	}

	public void SetDecoderProviderOptionsHardwareDeviceType(string provider, string hardware_device_type)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigSetDecoderProviderOptionsHardwareDeviceType(_configHandle, StringUtils.ToUtf8(provider), StringUtils.ToUtf8(hardware_device_type)));
	}

	public void SetDecoderProviderOptionsHardwareDeviceId(string provider, uint hardware_device_id)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigSetDecoderProviderOptionsHardwareDeviceId(_configHandle, StringUtils.ToUtf8(provider), hardware_device_id));
	}

	public void SetDecoderProviderOptionsHardwareVendorId(string provider, uint hardware_vendor_id)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigSetDecoderProviderOptionsHardwareVendorId(_configHandle, StringUtils.ToUtf8(provider), hardware_vendor_id));
	}

	public void ClearDecoderProviderOptionsHardwareDeviceType(string provider)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigClearDecoderProviderOptionsHardwareDeviceType(_configHandle, StringUtils.ToUtf8(provider)));
	}

	public void ClearDecoderProviderOptionsHardwareDeviceId(string provider)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigClearDecoderProviderOptionsHardwareDeviceId(_configHandle, StringUtils.ToUtf8(provider)));
	}

	public void ClearDecoderProviderOptionsHardwareVendorId(string provider)
	{
		Result.VerifySuccess(NativeMethods.OgaConfigClearDecoderProviderOptionsHardwareVendorId(_configHandle, StringUtils.ToUtf8(provider)));
	}

	~Config()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyConfig(_configHandle);
			_configHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class OnnxRuntimeGenAIException : Exception
{
	internal OnnxRuntimeGenAIException(string message)
		: base(message)
	{
	}
}
public class Generator : IDisposable
{
	private nint _generatorHandle;

	private bool _disposed = false;

	public Generator(Model model, GeneratorParams generatorParams)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateGenerator(model.Handle, generatorParams.Handle, out _generatorHandle));
	}

	public bool IsDone()
	{
		return NativeMethods.OgaGenerator_IsDone(_generatorHandle) != 0;
	}

	public void SetModelInput(string name, Tensor value)
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_SetModelInput(_generatorHandle, StringUtils.ToUtf8(name), value.Handle));
	}

	public void SetInputs(NamedTensors namedTensors)
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_SetInputs(_generatorHandle, namedTensors.Handle));
	}

	public unsafe void AppendTokens(ReadOnlySpan<int> inputIDs)
	{
		fixed (int* inputIDs2 = inputIDs)
		{
			Result.VerifySuccess(NativeMethods.OgaGenerator_AppendTokens(_generatorHandle, inputIDs2, (nuint)inputIDs.Length));
		}
	}

	public void AppendTokenSequences(Sequences sequences)
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_AppendTokenSequences(_generatorHandle, sequences.Handle));
	}

	public ulong TokenCount()
	{
		return ((UIntPtr)NativeMethods.OgaGenerator_TokenCount(_generatorHandle)).ToUInt64();
	}

	public void GenerateNextToken()
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_GenerateNextToken(_generatorHandle));
	}

	public void RewindTo(ulong newLength)
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_RewindTo(_generatorHandle, (nuint)newLength));
	}

	public unsafe ReadOnlySpan<int> GetNextTokens()
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_GetNextTokens(_generatorHandle, out var outTokenIds, out var outTokenCount));
		return new ReadOnlySpan<int>(((IntPtr)outTokenIds).ToPointer(), (int)((UIntPtr)outTokenCount).ToUInt64());
	}

	public unsafe ReadOnlySpan<int> GetSequence(ulong index)
	{
		ulong num = ((UIntPtr)NativeMethods.OgaGenerator_GetSequenceCount(_generatorHandle, (nuint)index)).ToUInt64();
		return new ReadOnlySpan<int>(((IntPtr)NativeMethods.OgaGenerator_GetSequenceData(_generatorHandle, (nuint)index)).ToPointer(), (int)num);
	}

	public Tensor GetInput(string inputName)
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_GetInput(_generatorHandle, StringUtils.ToUtf8(inputName), out var tensor));
		return new Tensor(tensor);
	}

	public Tensor GetOutput(string outputName)
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_GetOutput(_generatorHandle, StringUtils.ToUtf8(outputName), out var tensor));
		return new Tensor(tensor);
	}

	public void SetActiveAdapter(Adapters adapters, string adapterName)
	{
		Result.VerifySuccess(NativeMethods.OgaSetActiveAdapter(_generatorHandle, adapters.Handle, StringUtils.ToUtf8(adapterName)));
	}

	public void SetRuntimeOption(string key, string value)
	{
		Result.VerifySuccess(NativeMethods.OgaGenerator_SetRuntimeOption(_generatorHandle, StringUtils.ToUtf8(key), StringUtils.ToUtf8(value)));
	}

	~Generator()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyGenerator(_generatorHandle);
			_generatorHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class GeneratorParams : IDisposable
{
	private nint _generatorParamsHandle;

	private bool _disposed = false;

	internal nint Handle => _generatorParamsHandle;

	public GeneratorParams(Model model)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateGeneratorParams(model.Handle, out _generatorParamsHandle));
	}

	public void SetSearchOption(string searchOption, double value)
	{
		Result.VerifySuccess(NativeMethods.OgaGeneratorParamsSetSearchNumber(_generatorParamsHandle, StringUtils.ToUtf8(searchOption), value));
	}

	public void SetSearchOption(string searchOption, bool value)
	{
		Result.VerifySuccess(NativeMethods.OgaGeneratorParamsSetSearchBool(_generatorParamsHandle, StringUtils.ToUtf8(searchOption), value));
	}

	public void SetGuidance(string type, string data, bool enableFFTokens = false)
	{
		Result.VerifySuccess(NativeMethods.OgaGeneratorParamsSetGuidance(_generatorParamsHandle, StringUtils.ToUtf8(type), StringUtils.ToUtf8(data), enableFFTokens));
	}

	public double GetSearchNumber(string searchOption)
	{
		Result.VerifySuccess(NativeMethods.OgaGeneratorParamsGetSearchNumber(_generatorParamsHandle, StringUtils.ToUtf8(searchOption), out var value));
		return value;
	}

	public bool GetSearchBool(string searchOption)
	{
		Result.VerifySuccess(NativeMethods.OgaGeneratorParamsGetSearchBool(_generatorParamsHandle, StringUtils.ToUtf8(searchOption), out var value));
		return value;
	}

	~GeneratorParams()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyGeneratorParams(_generatorParamsHandle);
			_generatorParamsHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class Images : IDisposable
{
	private nint _imagesHandle;

	private bool _disposed = false;

	internal nint Handle => _imagesHandle;

	private Images(nint imagesHandle)
	{
		_imagesHandle = imagesHandle;
	}

	public static Images Load(string[] imagePaths)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateStringArray(out var stringArray));
		foreach (string str in imagePaths)
		{
			Result.VerifySuccess(NativeMethods.OgaStringArrayAddString(stringArray, StringUtils.ToUtf8(str)));
		}
		Result.VerifySuccess(NativeMethods.OgaLoadImages(stringArray, out var images));
		NativeMethods.OgaDestroyStringArray(stringArray);
		return new Images(images);
	}

	public unsafe static Images Load(byte[] imageBytesData)
	{
		nint[] array = new nint[1];
		nuint[] image_data_sizes = new nuint[1] { (nuint)imageBytesData.Length };
		fixed (byte* ptr = imageBytesData)
		{
			array[0] = (nint)ptr;
			Result.VerifySuccess(NativeMethods.OgaLoadImagesFromBuffers(array, image_data_sizes, 1u, out var images));
			return new Images(images);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyImages(_imagesHandle);
			_imagesHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class Model : IDisposable
{
	private nint _modelHandle;

	private bool _disposed = false;

	internal nint Handle => _modelHandle;

	public Model(string modelPath)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateModel(StringUtils.ToUtf8(modelPath), out _modelHandle));
	}

	public Model(Config config)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateModelFromConfig(config.Handle, out _modelHandle));
	}

	public string GetModelType()
	{
		nint type = IntPtr.Zero;
		try
		{
			Result.VerifySuccess(NativeMethods.OgaModelGetType(_modelHandle, out type));
			return StringUtils.FromUtf8(type);
		}
		finally
		{
			NativeMethods.OgaDestroyString(type);
		}
	}

	~Model()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (_modelHandle != IntPtr.Zero)
			{
				NativeMethods.OgaDestroyModel(_modelHandle);
				_modelHandle = IntPtr.Zero;
			}
			_disposed = true;
		}
	}
}
public class MultiModalProcessor : IDisposable
{
	private nint _processorHandle;

	private bool _disposed = false;

	internal nint Handle => _processorHandle;

	public MultiModalProcessor(Model model)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateMultiModalProcessor(model.Handle, out _processorHandle));
	}

	public NamedTensors ProcessImages(string prompt, Images images)
	{
		nint images2 = images?.Handle ?? IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaProcessorProcessImages(_processorHandle, StringUtils.ToUtf8(prompt), images2, out var namedTensors));
		return new NamedTensors(namedTensors);
	}

	public NamedTensors ProcessImages(string[] prompts, Images images)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateStringArray(out var stringArray));
		foreach (string str in prompts)
		{
			Result.VerifySuccess(NativeMethods.OgaStringArrayAddString(stringArray, StringUtils.ToUtf8(str)));
		}
		nint images2 = images?.Handle ?? IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaProcessorProcessImagesAndPrompts(_processorHandle, stringArray, images2, out var namedTensors));
		NativeMethods.OgaDestroyStringArray(stringArray);
		return new NamedTensors(namedTensors);
	}

	public NamedTensors ProcessAudios(string prompt, Audios audios)
	{
		nint audios2 = audios?.Handle ?? IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaProcessorProcessAudios(_processorHandle, StringUtils.ToUtf8(prompt), audios2, out var namedTensors));
		return new NamedTensors(namedTensors);
	}

	public NamedTensors ProcessAudios(string[] prompts, Audios audios)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateStringArray(out var stringArray));
		foreach (string str in prompts)
		{
			Result.VerifySuccess(NativeMethods.OgaStringArrayAddString(stringArray, StringUtils.ToUtf8(str)));
		}
		nint audios2 = audios?.Handle ?? IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaProcessorProcessAudiosAndPrompts(_processorHandle, stringArray, audios2, out var namedTensors));
		NativeMethods.OgaDestroyStringArray(stringArray);
		return new NamedTensors(namedTensors);
	}

	public NamedTensors ProcessImagesAndAudios(string prompt, Images images, Audios audios)
	{
		nint images2 = images?.Handle ?? IntPtr.Zero;
		nint audios2 = audios?.Handle ?? IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaProcessorProcessImagesAndAudios(_processorHandle, StringUtils.ToUtf8(prompt), images2, audios2, out var namedTensors));
		return new NamedTensors(namedTensors);
	}

	public NamedTensors ProcessImagesAndAudios(string[] prompts, Images images, Audios audios)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateStringArray(out var stringArray));
		foreach (string str in prompts)
		{
			Result.VerifySuccess(NativeMethods.OgaStringArrayAddString(stringArray, StringUtils.ToUtf8(str)));
		}
		nint images2 = images?.Handle ?? IntPtr.Zero;
		nint audios2 = audios?.Handle ?? IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaProcessorProcessImagesAndAudiosAndPrompts(_processorHandle, stringArray, images2, audios2, out var namedTensors));
		NativeMethods.OgaDestroyStringArray(stringArray);
		return new NamedTensors(namedTensors);
	}

	public unsafe string Decode(ReadOnlySpan<int> sequence)
	{
		nint outStr = IntPtr.Zero;
		fixed (int* sequence2 = sequence)
		{
			Result.VerifySuccess(NativeMethods.OgaProcessorDecode(_processorHandle, sequence2, (nuint)sequence.Length, out outStr));
		}
		try
		{
			return StringUtils.FromUtf8(outStr);
		}
		finally
		{
			NativeMethods.OgaDestroyString(outStr);
		}
	}

	public TokenizerStream CreateStream()
	{
		nint tokenizerStream = IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaCreateTokenizerStreamFromProcessor(_processorHandle, out tokenizerStream));
		return new TokenizerStream(tokenizerStream);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyMultiModalProcessor(_processorHandle);
			_processorHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
internal static class NativeMethods
{
	internal class NativeLib
	{
		internal const string DllName = "onnxruntime-genai";
	}

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaResultGetError(nint result);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaSetLogBool(byte[] name, bool value);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaSetLogString(byte[] name, byte[] value);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyResult(nint result);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateConfig(byte[] configPath, out nint config);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyConfig(nint config);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigClearProviders(nint config);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigAppendProvider(nint config, byte[] provider_name);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigSetProviderOption(nint config, byte[] provider_name, byte[] option_name, byte[] option_value);

	[DllImport("onnxruntime-genai")]
	public unsafe static extern nint OgaConfigAddModelData(nint config, byte[] model_filename, byte* model_data, nuint model_data_length);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigRemoveModelData(nint config, byte[] model_filename);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigOverlay(nint config, byte[] json);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigSetDecoderProviderOptionsHardwareDeviceType(nint config, byte[] provider_name, byte[] hardware_device_type);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigSetDecoderProviderOptionsHardwareDeviceId(nint config, byte[] provider_name, uint hardware_device_id);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigSetDecoderProviderOptionsHardwareVendorId(nint config, byte[] provider_name, uint hardware_vendor_id);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigClearDecoderProviderOptionsHardwareDeviceType(nint config, byte[] provider_name);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigClearDecoderProviderOptionsHardwareDeviceId(nint config, byte[] provider_name);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaConfigClearDecoderProviderOptionsHardwareVendorId(nint config, byte[] provider_name);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateModel(byte[] configPath, out nint model);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateModelFromConfig(nint config, out nint model);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaModelGetType(nint model, out nint type);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyModel(nint model);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateGeneratorParams(nint model, out nint generatorParams);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyGeneratorParams(nint generatorParams);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGeneratorParamsSetSearchNumber(nint generatorParams, byte[] searchOption, double value);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGeneratorParamsSetSearchBool(nint generatorParams, byte[] searchOption, bool value);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGeneratorParamsSetGuidance(nint generatorParams, byte[] type, byte[] data, bool enable_ff_tokens);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGeneratorParamsGetSearchNumber(nint generatorParams, byte[] searchOption, out double value);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGeneratorParamsGetSearchBool(nint generatorParams, byte[] searchOption, out bool value);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateGenerator(nint model, nint generatorParams, out nint generator);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyGenerator(nint generator);

	[DllImport("onnxruntime-genai")]
	public static extern byte OgaGenerator_IsDone(nint generator);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_GetNextTokens(nint generator, out nint outTokenIds, out nuint outTokenCount);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_GenerateNextToken(nint generator);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_SetModelInput(nint generator, byte[] name, nint tensor);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_SetInputs(nint generator, nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public unsafe static extern nint OgaGenerator_AppendTokens(nint generator, int* inputIDs, nuint tokenCount);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_AppendTokenSequences(nint generator, nint sequences);

	[DllImport("onnxruntime-genai")]
	public static extern nuint OgaGenerator_TokenCount(nint generator);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_RewindTo(nint generator, nuint newLength);

	[DllImport("onnxruntime-genai")]
	public static extern nuint OgaGenerator_GetSequenceCount(nint generator, nuint index);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_GetSequenceData(nint generator, nuint index);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_GetInput(nint generator, byte[] inputName, out nint tensor);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_GetOutput(nint generator, byte[] outputName, out nint tensor);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaSetActiveAdapter(nint generator, nint adapters, byte[] adapterName);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGenerator_SetRuntimeOption(nint generator, byte[] key, byte[] value);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateSequences(out nint sequences);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroySequences(nint sequences);

	[DllImport("onnxruntime-genai")]
	public static extern nuint OgaSequencesCount(nint sequences);

	[DllImport("onnxruntime-genai")]
	public static extern nuint OgaSequencesGetSequenceCount(nint sequences, nuint sequenceIndex);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaSequencesGetSequenceData(nint sequences, nuint sequenceIndex);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaAppendTokenToSequence(int token, nint sequences, nuint sequenceIndex);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateTokenizer(nint model, out nint tokenizer);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyTokenizer(nint tokenizer);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaUpdateTokenizerOptions(nint tokenizer, string[] keys, string[] values, nuint numOptions);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTokenizerGetBosTokenId(nint tokenizer, out int outBosTokenId);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTokenizerGetEosTokenIds(nint tokenizer, out nint outEosTokenIds, out nuint outTokenCount);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTokenizerGetPadTokenId(nint tokenizer, out int outPadTokenId);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTokenizerEncode(nint tokenizer, byte[] strings, nint sequences);

	[DllImport("onnxruntime-genai")]
	public unsafe static extern nint OgaTokenizerDecode(nint tokenizer, int* sequence, nuint sequenceLength, out nint outStr);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTokenizerApplyChatTemplate(nint tokenizer, byte[] template_string, byte[] message, byte[] tool_calls, bool add_gen_prompt, out nint outStr);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyString(nint str);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateTokenizerStream(nint tokenizer, out nint tokenizerStream);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateTokenizerStreamFromProcessor(nint processor, out nint tokenizerStream);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyTokenizerStream(nint tokenizerStream);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTokenizerStreamDecode(nint tokenizerStream, int token, out nint outStr);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateTensorFromBuffer(nint data, long[] shapeDims, nuint shapeDimsCount, ElementType elementType, out nint tensor);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyTensor(nint tensor);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTensorGetType(nint tensor, out ElementType elementType);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTensorGetShapeRank(nint tensor, out nuint rank);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTensorGetShape(nint tensor, long[] shapeDims, nuint shapeDimsCount);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaTensorGetData(nint tensor, out nint data);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaSetCurrentGpuDeviceId(int deviceId);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaGetCurrentGpuDeviceId(out nint deviceId);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaShutdown();

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateMultiModalProcessor(nint model, out nint processor);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyMultiModalProcessor(nint processor);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaProcessorProcessImages(nint processor, byte[] prompt, nint images, out nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaProcessorProcessImagesAndPrompts(nint processor, nint prompts, nint images, out nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaProcessorProcessAudios(nint processor, byte[] prompt, nint audios, out nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaProcessorProcessAudiosAndPrompts(nint processor, nint prompts, nint audios, out nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaProcessorProcessImagesAndAudios(nint processor, byte[] prompt, nint images, nint audios, out nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaProcessorProcessImagesAndAudiosAndPrompts(nint processor, nint prompts, nint images, nint audios, out nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public unsafe static extern nint OgaProcessorDecode(nint processor, int* sequence, nuint sequenceLength, out nint outStr);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaLoadImages(nint imagePaths, out nint images);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaLoadImagesFromBuffers(nint[] image_data, nuint[] image_data_sizes, nuint count, out nint images);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaLoadAudios(nint audioPaths, out nint audios);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaLoadAudiosFromBuffers(nint[] audio_data, nuint[] audio_data_sizes, nuint count, out nint audios);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyImages(nint images);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyAudios(nint audios);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyNamedTensors(nint namedTensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateStringArray(out nint stringArray);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaStringArrayAddString(nint stringArray, byte[] str);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyStringArray(nint stringArray);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateAdapters(nint model, out nint adapters);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyAdapters(nint adapters);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaLoadAdapter(nint adapters, byte[] adapterFilePath, byte[] adapterName);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaUnloadAdapter(nint adapters, byte[] adapterName);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaCreateStreamingProcessor(nint model, out nint processor);

	[DllImport("onnxruntime-genai")]
	public static extern void OgaDestroyStreamingProcessor(nint processor);

	[DllImport("onnxruntime-genai")]
	public unsafe static extern nint OgaStreamingProcessorProcess(nint processor, float* audioData, nuint numSamples, out nint out_named_tensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaStreamingProcessorFlush(nint processor, out nint out_named_tensors);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaStreamingProcessorSetOption(nint processor, byte[] key, byte[] value);

	[DllImport("onnxruntime-genai")]
	public static extern nint OgaStreamingProcessorGetOption(nint processor, byte[] key, out nint value);
}
public sealed class OnnxRuntimeGenAIChatClient : IChatClient, IDisposable
{
	private sealed class SerializableMessage
	{
		[JsonPropertyName("role")]
		public string Role { get; set; } = string.Empty;

		[JsonPropertyName("content")]
		public string Content { get; set; } = string.Empty;
	}

	private sealed class CachedGenerator(Generator generator) : IDisposable
	{
		public Generator Generator { get; } = generator;

		public string? ConversationId { get; set; }

		public void Dispose()
		{
			Generator?.Dispose();
		}
	}

	[JsonSerializable(typeof(SerializableMessage))]
	[GeneratedCode("System.Text.Json.SourceGeneration", "8.0.14.22922")]
	private class OnnxJsonContext : JsonSerializerContext, IJsonTypeInfoResolver
	{
		private JsonTypeInfo<SerializableMessage>? _SerializableMessage;

		private JsonTypeInfo<string>? _String;

		private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions();

		private static readonly JsonEncodedText PropName_role = JsonEncodedText.Encode("role");

		private static readonly JsonEncodedText PropName_content = JsonEncodedText.Encode("content");

		public JsonTypeInfo<SerializableMessage> SerializableMessage => _SerializableMessage ?? (_SerializableMessage = (JsonTypeInfo<SerializableMessage>)Options.GetTypeInfo(typeof(SerializableMessage)));

		public JsonTypeInfo<string> String => _String ?? (_String = (JsonTypeInfo<string>)Options.GetTypeInfo(typeof(string)));

		public static OnnxJsonContext Default { get; } = new OnnxJsonContext(new JsonSerializerOptions(s_defaultOptions));

		protected override JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;

		private JsonTypeInfo<SerializableMessage> Create_SerializableMessage(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<SerializableMessage> jsonTypeInfo))
			{
				JsonObjectInfoValues<SerializableMessage> objectInfo = new JsonObjectInfoValues<SerializableMessage>
				{
					ObjectCreator = () => new SerializableMessage(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => SerializableMessagePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = SerializableMessageSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] SerializableMessagePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SerializableMessage),
				Converter = null,
				Getter = (object obj) => ((SerializableMessage)obj).Role,
				Setter = (object obj, string? value) =>
				{
					((SerializableMessage)obj).Role = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Role",
				JsonPropertyName = "role"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SerializableMessage),
				Converter = null,
				Getter = (object obj) => ((SerializableMessage)obj).Content,
				Setter = (object obj, string? value) =>
				{
					((SerializableMessage)obj).Content = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Content",
				JsonPropertyName = "content"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void SerializableMessageSerializeHandler(Utf8JsonWriter writer, SerializableMessage? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteString(PropName_role, value.Role);
			writer.WriteString(PropName_content, value.Content);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<string> Create_String(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<string> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<string>(options, JsonMetadataServices.StringConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		public OnnxJsonContext()
			: base(null)
		{
		}

		public OnnxJsonContext(JsonSerializerOptions options)
			: base(options)
		{
		}

		private static bool TryGetTypeInfoForRuntimeCustomConverter<TJsonMetadataType>(JsonSerializerOptions options, out JsonTypeInfo<TJsonMetadataType> jsonTypeInfo)
		{
			JsonConverter runtimeConverterForType = GetRuntimeConverterForType(typeof(TJsonMetadataType), options);
			if (runtimeConverterForType != null)
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<TJsonMetadataType>(options, runtimeConverterForType);
				return true;
			}
			jsonTypeInfo = null;
			return false;
		}

		private static JsonConverter? GetRuntimeConverterForType(Type type, JsonSerializerOptions options)
		{
			for (int i = 0; i < options.Converters.Count; i++)
			{
				JsonConverter jsonConverter = options.Converters[i];
				if (jsonConverter != null && jsonConverter.CanConvert(type))
				{
					return ExpandConverter(type, jsonConverter, options, validateCanConvert: false);
				}
			}
			return null;
		}

		private static JsonConverter ExpandConverter(Type type, JsonConverter converter, JsonSerializerOptions options, bool validateCanConvert = true)
		{
			if (validateCanConvert && !converter.CanConvert(type))
			{
				throw new InvalidOperationException($"The converter '{converter.GetType()}' is not compatible with the type '{type}'.");
			}
			if (converter is JsonConverterFactory jsonConverterFactory)
			{
				converter = jsonConverterFactory.CreateConverter(type, options);
				if (converter == null || converter is JsonConverterFactory)
				{
					throw new InvalidOperationException($"The converter '{jsonConverterFactory.GetType()}' cannot return null or a JsonConverterFactory instance.");
				}
			}
			return converter;
		}

		public override JsonTypeInfo? GetTypeInfo(Type type)
		{
			Options.TryGetTypeInfo(type, out JsonTypeInfo typeInfo);
			return typeInfo;
		}

		JsonTypeInfo? IJsonTypeInfoResolver.GetTypeInfo(Type type, JsonSerializerOptions options)
		{
			if (type == typeof(SerializableMessage))
			{
				return Create_SerializableMessage(options);
			}
			if (type == typeof(string))
			{
				return Create_String(options);
			}
			return null;
		}
	}

	private sealed class YieldAwaiter : INotifyCompletion
	{
		public static YieldAwaiter Instance { get; } = new YieldAwaiter();

		public bool IsCompleted => false;

		public YieldAwaiter GetAwaiter()
		{
			return this;
		}

		public void OnCompleted(Action continuation)
		{
			Task.Run(continuation);
		}

		public void UnsafeOnCompleted(Action continuation)
		{
			Task.Run(continuation);
		}

		public void GetResult()
		{
		}
	}

	private readonly OnnxRuntimeGenAIChatClientOptions? _options;

	private readonly Model _model;

	private readonly Config? _config;

	private readonly Tokenizer _tokenizer;

	private readonly bool _ownsModel;

	private readonly bool _ownsConfig;

	private readonly ChatClientMetadata _metadata;

	private CachedGenerator? _cachedGenerator;

	public OnnxRuntimeGenAIChatClient(string modelPath, OnnxRuntimeGenAIChatClientOptions? options = null)
	{
		if (modelPath == null)
		{
			throw new ArgumentNullException("modelPath");
		}
		_ownsModel = true;
		_ownsConfig = false;
		_config = null;
		_model = new Model(modelPath);
		_tokenizer = new Tokenizer(_model);
		_options = options;
		_metadata = new ChatClientMetadata("onnx", new Uri("file://" + modelPath), modelPath);
	}

	public OnnxRuntimeGenAIChatClient(Model model, bool ownsModel = true, OnnxRuntimeGenAIChatClientOptions? options = null)
	{
		if (model == null)
		{
			throw new ArgumentNullException("model");
		}
		_ownsModel = ownsModel;
		_ownsConfig = false;
		_config = null;
		_model = model;
		_tokenizer = new Tokenizer(_model);
		_options = options;
		_metadata = new ChatClientMetadata("onnx");
	}

	public OnnxRuntimeGenAIChatClient(Config config, bool ownsConfig = true, OnnxRuntimeGenAIChatClientOptions? options = null)
	{
		if (config == null)
		{
			throw new ArgumentNullException("config");
		}
		_ownsModel = true;
		_ownsConfig = ownsConfig;
		_config = config;
		_model = new Model(_config);
		_tokenizer = new Tokenizer(_model);
		_options = options;
		_metadata = new ChatClientMetadata("onnx");
	}

	public void Dispose()
	{
		Interlocked.Exchange(ref _cachedGenerator, null)?.Dispose();
		_tokenizer.Dispose();
		if (_ownsModel)
		{
			_model.Dispose();
		}
		if (_ownsConfig)
		{
			_config?.Dispose();
		}
	}

	public Task<ChatResponse> GetResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, CancellationToken cancellationToken = default(CancellationToken))
	{
		return GetStreamingResponseAsync(messages, options, cancellationToken).ToChatResponseAsync(cancellationToken);
	}

	public async IAsyncEnumerable<ChatResponseUpdate> GetStreamingResponseAsync(IEnumerable<ChatMessage> messages, ChatOptions? options = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
	{
		if (messages == null)
		{
			throw new ArgumentNullException("messages");
		}
		bool enableCaching = _options?.EnableCaching ?? false;
		Func<IEnumerable<ChatMessage>, ChatOptions?, string> formatter = _options?.PromptFormatter;
		string formattedPrompt = ((formatter != null) ? formatter(messages, options) : FormatPromptDefault(messages, options));
		using (Sequences tokens = _tokenizer.Encode(formattedPrompt))
		{
			int inputTokens = tokens[0uL].Length;
			CachedGenerator generator = Interlocked.Exchange(ref _cachedGenerator, null);
			if (generator == null || generator.ConversationId == null || generator.ConversationId != options?.ConversationId)
			{
				generator?.Dispose();
				using GeneratorParams p = new GeneratorParams(_model);
				UpdateGeneratorParamsFromOptions(p, options, enableCaching, inputTokens);
				generator = new CachedGenerator(new Generator(_model, p));
			}
			generator.ConversationId = (enableCaching ? Guid.NewGuid().ToString("N") : null);
			try
			{
				string messageId = Guid.NewGuid().ToString("N");
				string responseId = Guid.NewGuid().ToString("N");
				generator.Generator.AppendTokenSequences(tokens);
				int outputTokens = 0;
				using TokenizerStream tokenizerStream = _tokenizer.CreateStream();
				while (!generator.Generator.IsDone())
				{
					int? num = options?.MaxOutputTokens;
					int num2;
					if (num.HasValue)
					{
						int maxOutputTokens = num.GetValueOrDefault();
						num2 = ((outputTokens >= maxOutputTokens) ? 1 : 0);
					}
					else
					{
						num2 = 0;
					}
					if (num2 != 0)
					{
						break;
					}
					cancellationToken.ThrowIfCancellationRequested();
					await YieldAwaiter.Instance;
					generator.Generator.GenerateNextToken();
					string next = tokenizerStream.Decode(GetLastToken(generator.Generator.GetSequence(0uL)));
					if (IsStop(next, options))
					{
						break;
					}
					outputTokens++;
					yield return new ChatResponseUpdate(ChatRole.Assistant, next)
					{
						CreatedAt = DateTimeOffset.UtcNow,
						MessageId = messageId,
						ResponseId = responseId
					};
				}
				yield return new ChatResponseUpdate
				{
					ConversationId = generator.ConversationId,
					Contents = new List<AIContent>(1)
					{
						new UsageContent(new UsageDetails
						{
							InputTokenCount = inputTokens,
							OutputTokenCount = outputTokens,
							TotalTokenCount = inputTokens + outputTokens
						})
					},
					CreatedAt = DateTimeOffset.UtcNow,
					FinishReason = ((options != null && options.MaxOutputTokens <= outputTokens) ? ChatFinishReason.Length : ChatFinishReason.Stop),
					MessageId = messageId,
					ResponseId = responseId,
					Role = ChatRole.Assistant
				};
			}
			finally
			{
				if (generator.ConversationId == null || Interlocked.CompareExchange(ref _cachedGenerator, generator, null) != null)
				{
					generator.Dispose();
				}
			}
		}
		static int GetLastToken(ReadOnlySpan<int> span)
		{
			return span[span.Length - 1];
		}
	}

	object? IChatClient.GetService(Type serviceType, object? serviceKey)
	{
		if ((object)serviceType == null)
		{
			throw new ArgumentNullException("serviceType");
		}
		object? result;
		if (serviceKey != null)
		{
			result = null;
		}
		else if (serviceType == typeof(ChatClientMetadata))
		{
			result = _metadata;
		}
		else if (serviceType == typeof(Model))
		{
			result = _model;
		}
		else if (serviceType == typeof(Tokenizer))
		{
			result = _tokenizer;
		}
		else if (serviceType == typeof(Config))
		{
			result = _config;
		}
		else
		{
			result = ((serviceType?.IsInstanceOfType(this) ?? false) ? this : null);
		}
		return result;
	}

	private bool IsStop(string token, ChatOptions? options)
	{
		return (options?.StopSequences?.Contains(token) ?? false) || (_options?.StopSequences?.Contains(token) ?? false);
	}

	private string FormatPromptDefault(IEnumerable<ChatMessage> messages, ChatOptions? options)
	{
		SerializableMessage serializableMessage = new SerializableMessage();
		StringBuilder stringBuilder = new StringBuilder();
		string value = "";
		stringBuilder.Append('[');
		string text = options?.Instructions;
		if (text != null)
		{
			serializableMessage.Role = ChatRole.System.Value;
			serializableMessage.Content = text;
			stringBuilder.Append(JsonSerializer.Serialize(serializableMessage, OnnxJsonContext.Default.SerializableMessage));
			value = ",";
		}
		foreach (ChatMessage message in messages)
		{
			string text2 = message.Text;
			if (text2 != null)
			{
				stringBuilder.Append(value);
				value = ",";
				serializableMessage.Role = message.Role.Value;
				serializableMessage.Content = text2;
				stringBuilder.Append(JsonSerializer.Serialize(serializableMessage, OnnxJsonContext.Default.SerializableMessage));
			}
		}
		stringBuilder.Append(']');
		return _tokenizer.ApplyChatTemplate(null, stringBuilder.ToString(), null, add_generation_prompt: true);
	}

	private static void UpdateGeneratorParamsFromOptions(GeneratorParams generatorParams, ChatOptions? options, bool enableCaching, int inputTokens)
	{
		if (options == null)
		{
			return;
		}
		int? maxOutputTokens = options.MaxOutputTokens;
		if (maxOutputTokens.HasValue)
		{
			int valueOrDefault = maxOutputTokens.GetValueOrDefault();
			if (!enableCaching)
			{
				try
				{
					generatorParams.SetSearchOption("max_length", inputTokens + valueOrDefault);
				}
				catch (OnnxRuntimeGenAIException)
				{
				}
			}
		}
		if (options.Temperature.HasValue)
		{
			generatorParams.SetSearchOption("temperature", options.Temperature.Value);
		}
		if (options.PresencePenalty.HasValue)
		{
			generatorParams.SetSearchOption("repetition_penalty", options.PresencePenalty.Value);
		}
		if (options.TopP.HasValue || options.TopK.HasValue)
		{
			if (options.TopP.HasValue)
			{
				generatorParams.SetSearchOption("top_p", options.TopP.Value);
			}
			if (options.TopK.HasValue)
			{
				generatorParams.SetSearchOption("top_k", options.TopK.Value);
			}
			generatorParams.SetSearchOption("do_sample", value: true);
		}
		if (options.Seed.HasValue)
		{
			generatorParams.SetSearchOption("random_seed", options.Seed.Value);
		}
		AdditionalPropertiesDictionary additionalProperties = options.AdditionalProperties;
		if (additionalProperties != null)
		{
			foreach (KeyValuePair<string, object> item in additionalProperties)
			{
				if (item.Value is bool value)
				{
					generatorParams.SetSearchOption(item.Key, value);
				}
				else if (item.Value != null)
				{
					try
					{
						double value2 = Convert.ToDouble(item.Value);
						generatorParams.SetSearchOption(item.Key, value2);
					}
					catch
					{
					}
				}
			}
		}
		if (options.ResponseFormat is ChatResponseFormatJson chatResponseFormatJson)
		{
			JsonElement? schema = chatResponseFormatJson.Schema;
			generatorParams.SetGuidance("json_schema", (!schema.HasValue) ? "{}" : schema.GetValueOrDefault().ToString());
		}
	}
}
public sealed class OnnxRuntimeGenAIChatClientOptions
{
	public IList<string>? StopSequences { get; set; }

	public Func<IEnumerable<ChatMessage>, ChatOptions?, string>? PromptFormatter { get; set; }

	public bool EnableCaching { get; set; }
}
internal class Result
{
	private static string GetErrorMessage(nint nativeResult)
	{
		return StringUtils.FromUtf8(NativeMethods.OgaResultGetError(nativeResult));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void VerifySuccess(nint nativeResult)
	{
		if (nativeResult != IntPtr.Zero)
		{
			try
			{
				string errorMessage = GetErrorMessage(nativeResult);
				throw new OnnxRuntimeGenAIException(errorMessage);
			}
			finally
			{
				NativeMethods.OgaDestroyResult(nativeResult);
			}
		}
	}
}
public class Sequences : IDisposable
{
	private nint _sequencesHandle;

	private bool _disposed = false;

	private ulong _numSequences;

	internal nint Handle => _sequencesHandle;

	public ulong NumSequences => _numSequences;

	public unsafe ReadOnlySpan<int> this[ulong sequenceIndex]
	{
		get
		{
			if (sequenceIndex >= _numSequences)
			{
				throw new ArgumentOutOfRangeException("sequenceIndex");
			}
			ulong num = ((UIntPtr)NativeMethods.OgaSequencesGetSequenceCount(_sequencesHandle, (nuint)sequenceIndex)).ToUInt64();
			return new ReadOnlySpan<int>(((IntPtr)NativeMethods.OgaSequencesGetSequenceData(_sequencesHandle, (nuint)sequenceIndex)).ToPointer(), (int)num);
		}
	}

	internal Sequences(nint sequencesHandle)
	{
		_sequencesHandle = sequencesHandle;
		_numSequences = ((UIntPtr)NativeMethods.OgaSequencesCount(_sequencesHandle)).ToUInt64();
	}

	public void Append(int token, ulong sequenceIndex)
	{
		if (sequenceIndex >= _numSequences)
		{
			throw new ArgumentOutOfRangeException("sequenceIndex");
		}
		Result.VerifySuccess(NativeMethods.OgaAppendTokenToSequence(token, _sequencesHandle, (nuint)sequenceIndex));
	}

	~Sequences()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroySequences(_sequencesHandle);
			_sequencesHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class StreamingProcessor : IDisposable
{
	private nint _processorHandle;

	private bool _disposed = false;

	internal nint Handle => _processorHandle;

	public StreamingProcessor(Model model)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateStreamingProcessor(model.Handle, out _processorHandle));
	}

	public unsafe NamedTensors? Process(float[] audioData)
	{
		nint out_named_tensors = IntPtr.Zero;
		fixed (float* audioData2 = audioData)
		{
			Result.VerifySuccess(NativeMethods.OgaStreamingProcessorProcess(_processorHandle, audioData2, (nuint)audioData.Length, out out_named_tensors));
		}
		return (out_named_tensors != IntPtr.Zero) ? new NamedTensors(out_named_tensors) : null;
	}

	public NamedTensors? Flush()
	{
		nint out_named_tensors = IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaStreamingProcessorFlush(_processorHandle, out out_named_tensors));
		return (out_named_tensors != IntPtr.Zero) ? new NamedTensors(out_named_tensors) : null;
	}

	public void SetOption(string key, string value)
	{
		Result.VerifySuccess(NativeMethods.OgaStreamingProcessorSetOption(_processorHandle, StringUtils.ToUtf8(key), StringUtils.ToUtf8(value)));
	}

	public string GetOption(string key)
	{
		nint value = IntPtr.Zero;
		try
		{
			Result.VerifySuccess(NativeMethods.OgaStreamingProcessorGetOption(_processorHandle, StringUtils.ToUtf8(key), out value));
			return StringUtils.FromUtf8(value);
		}
		finally
		{
			NativeMethods.OgaDestroyString(value);
		}
	}

	~StreamingProcessor()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyStreamingProcessor(_processorHandle);
			_processorHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public enum ElementType : long
{
	undefined,
	float32,
	uint8,
	int8,
	uint16,
	int16,
	int32,
	int64,
	string_t,
	bool_t,
	float16,
	float64,
	uint32,
	uint64
}
public class Tensor : IDisposable
{
	private nint _tensorHandle;

	private bool _disposed = false;

	internal nint Handle => _tensorHandle;

	public Tensor(nint data, long[] shape, ElementType type)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateTensorFromBuffer(data, shape, (nuint)shape.Length, type, out _tensorHandle));
	}

	internal Tensor(nint tensorHandle)
	{
		_tensorHandle = tensorHandle;
		_disposed = false;
	}

	~Tensor()
	{
		Dispose(disposing: false);
	}

	public ElementType Type()
	{
		Result.VerifySuccess(NativeMethods.OgaTensorGetType(_tensorHandle, out var elementType));
		return elementType;
	}

	public long[] Shape()
	{
		Result.VerifySuccess(NativeMethods.OgaTensorGetShapeRank(_tensorHandle, out var rank));
		long[] array = new long[((UIntPtr)rank).ToUInt64()];
		Result.VerifySuccess(NativeMethods.OgaTensorGetShape(_tensorHandle, array, rank));
		return array;
	}

	public static long ElementsFromShape(long[] shape)
	{
		long num = 1L;
		foreach (long num2 in shape)
		{
			num *= num2;
		}
		return num;
	}

	public long NumElements()
	{
		return ElementsFromShape(Shape());
	}

	public unsafe ReadOnlySpan<T> GetData<T>()
	{
		long num = NumElements();
		Result.VerifySuccess(NativeMethods.OgaTensorGetData(Handle, out var data));
		return new ReadOnlySpan<T>(((IntPtr)data).ToPointer(), (int)num);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyTensor(_tensorHandle);
			_tensorHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class NamedTensors : IDisposable
{
	private nint _namedTensorsHandle;

	private bool _disposed = false;

	internal nint Handle => _namedTensorsHandle;

	internal NamedTensors(nint namedTensorsHandle)
	{
		_namedTensorsHandle = namedTensorsHandle;
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyNamedTensors(_namedTensorsHandle);
			_namedTensorsHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class Tokenizer : IDisposable
{
	private nint _tokenizerHandle;

	private bool _disposed = false;

	public Tokenizer(Model model)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateTokenizer(model.Handle, out _tokenizerHandle));
	}

	public Sequences EncodeBatch(string[] strings)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateSequences(out var sequences));
		try
		{
			foreach (string str in strings)
			{
				Result.VerifySuccess(NativeMethods.OgaTokenizerEncode(_tokenizerHandle, StringUtils.ToUtf8(str), sequences));
			}
			return new Sequences(sequences);
		}
		catch
		{
			NativeMethods.OgaDestroySequences(sequences);
			throw;
		}
	}

	public string[] DecodeBatch(Sequences sequences)
	{
		string[] array = new string[sequences.NumSequences];
		for (ulong num = 0uL; num < sequences.NumSequences; num++)
		{
			array[num] = Decode(sequences[num]);
		}
		return array;
	}

	public void UpdateOptions(Dictionary<string, string> options)
	{
		if (options == null)
		{
			throw new ArgumentNullException("options");
		}
		string[] array = new string[options.Count];
		string[] array2 = new string[options.Count];
		int num = 0;
		foreach (KeyValuePair<string, string> option in options)
		{
			array[num] = option.Key;
			array2[num] = option.Value;
			num++;
		}
		Result.VerifySuccess(NativeMethods.OgaUpdateTokenizerOptions(_tokenizerHandle, array, array2, (nuint)options.Count));
	}

	public Sequences Encode(string str)
	{
		Result.VerifySuccess(NativeMethods.OgaCreateSequences(out var sequences));
		try
		{
			Result.VerifySuccess(NativeMethods.OgaTokenizerEncode(_tokenizerHandle, StringUtils.ToUtf8(str), sequences));
			return new Sequences(sequences);
		}
		catch
		{
			NativeMethods.OgaDestroySequences(sequences);
			throw;
		}
	}

	public unsafe string Decode(ReadOnlySpan<int> sequence)
	{
		nint outStr = IntPtr.Zero;
		fixed (int* sequence2 = sequence)
		{
			Result.VerifySuccess(NativeMethods.OgaTokenizerDecode(_tokenizerHandle, sequence2, (nuint)sequence.Length, out outStr));
		}
		try
		{
			return StringUtils.FromUtf8(outStr);
		}
		finally
		{
			NativeMethods.OgaDestroyString(outStr);
		}
	}

	public string ApplyChatTemplate(string template_str, string messages, string tools, bool add_generation_prompt)
	{
		nint outStr = IntPtr.Zero;
		try
		{
			Result.VerifySuccess(NativeMethods.OgaTokenizerApplyChatTemplate(_tokenizerHandle, StringUtils.ToUtf8(template_str), StringUtils.ToUtf8(messages), StringUtils.ToUtf8(tools), add_generation_prompt, out outStr));
			return StringUtils.FromUtf8(outStr);
		}
		finally
		{
			NativeMethods.OgaDestroyString(outStr);
		}
	}

	public int GetBosTokenId()
	{
		Result.VerifySuccess(NativeMethods.OgaTokenizerGetBosTokenId(_tokenizerHandle, out var outBosTokenId));
		return outBosTokenId;
	}

	public unsafe ReadOnlySpan<int> GetEosTokenIds()
	{
		Result.VerifySuccess(NativeMethods.OgaTokenizerGetEosTokenIds(_tokenizerHandle, out var outEosTokenIds, out var outTokenCount));
		return new ReadOnlySpan<int>(((IntPtr)outEosTokenIds).ToPointer(), (int)((UIntPtr)outTokenCount).ToUInt64());
	}

	public int GetPadTokenId()
	{
		Result.VerifySuccess(NativeMethods.OgaTokenizerGetPadTokenId(_tokenizerHandle, out var outPadTokenId));
		return outPadTokenId;
	}

	public TokenizerStream CreateStream()
	{
		nint tokenizerStream = IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaCreateTokenizerStream(_tokenizerHandle, out tokenizerStream));
		return new TokenizerStream(tokenizerStream);
	}

	~Tokenizer()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyTokenizer(_tokenizerHandle);
			_tokenizerHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class TokenizerStream : IDisposable
{
	private nint _tokenizerStreamHandle;

	private bool _disposed = false;

	internal nint Handle => _tokenizerStreamHandle;

	internal TokenizerStream(nint tokenizerStreamHandle)
	{
		_tokenizerStreamHandle = tokenizerStreamHandle;
	}

	public string Decode(int token)
	{
		nint outStr = IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaTokenizerStreamDecode(_tokenizerStreamHandle, token, out outStr));
		return StringUtils.FromUtf8(outStr);
	}

	~TokenizerStream()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaDestroyTokenizerStream(_tokenizerStreamHandle);
			_tokenizerStreamHandle = IntPtr.Zero;
			_disposed = true;
		}
	}
}
public class OgaHandle : IDisposable
{
	private bool _disposed = false;

	~OgaHandle()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			NativeMethods.OgaShutdown();
			_disposed = true;
		}
	}
}
public class Utils
{
	public static void SetCurrentGpuDeviceId(int device_id)
	{
		Result.VerifySuccess(NativeMethods.OgaSetCurrentGpuDeviceId(device_id));
	}

	public static int GetCurrentGpuDeviceId()
	{
		nint deviceId = IntPtr.Zero;
		Result.VerifySuccess(NativeMethods.OgaGetCurrentGpuDeviceId(out deviceId));
		return (int)((IntPtr)deviceId).ToInt64();
	}

	public static void SetLogBool(string name, bool value)
	{
		Result.VerifySuccess(NativeMethods.OgaSetLogBool(StringUtils.ToUtf8(name), value));
	}

	public static void SetLogString(string name, string value)
	{
		Result.VerifySuccess(NativeMethods.OgaSetLogString(StringUtils.ToUtf8(name), StringUtils.ToUtf8(value)));
	}
}
internal class StringUtils
{
	internal static byte[] EmptyByteArray = new byte[1];

	internal static byte[] ToUtf8(string str)
	{
		if (string.IsNullOrEmpty(str))
		{
			return EmptyByteArray;
		}
		int byteCount = Encoding.UTF8.GetByteCount(str);
		byte[] array = new byte[byteCount + 1];
		Encoding.UTF8.GetBytes(str, 0, str.Length, array, 0);
		array[^1] = 0;
		return array;
	}

	internal unsafe static string FromUtf8(nint nativeUtf8)
	{
		int i;
		for (i = 0; *(byte*)(nativeUtf8 + i) != 0; i++)
		{
		}
		if (i == 0)
		{
			return string.Empty;
		}
		return Encoding.UTF8.GetString((byte*)nativeUtf8, i);
	}
}
