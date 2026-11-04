#define TRACE
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Numerics.Tensors;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime.CompileApi;
using Microsoft.ML.OnnxRuntime.Tensors;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.ML.OnnxRuntime.Tests.Common, PublicKey=002400000480000094000000060200000024000052534131000400000100010059013e94e4bc70136ca4c35f33acd6b62974536b698f9c7a21cee18d805c7ad860ad9eebfdc47a96ba2f8d03f4cf1c36b9d30787e276c7b9833b5bf2a6eba7e919e6b90083078a352262aed1d842e5f70a3085cbcf4c56ae851b161137920961c23fcc246598d61d258ccc615c927b2441359eea666a99ce1c3c07dca18fb0e1")]
[assembly: InternalsVisibleTo("Microsoft.ML.OnnxRuntime.Tests.NetCoreApp, PublicKey=002400000480000094000000060200000024000052534131000400000100010059013e94e4bc70136ca4c35f33acd6b62974536b698f9c7a21cee18d805c7ad860ad9eebfdc47a96ba2f8d03f4cf1c36b9d30787e276c7b9833b5bf2a6eba7e919e6b90083078a352262aed1d842e5f70a3085cbcf4c56ae851b161137920961c23fcc246598d61d258ccc615c927b2441359eea666a99ce1c3c07dca18fb0e1")]
[assembly: InternalsVisibleTo("Microsoft.ML.OnnxRuntime.Tests.MAUI, PublicKey=002400000480000094000000060200000024000052534131000400000100010059013e94e4bc70136ca4c35f33acd6b62974536b698f9c7a21cee18d805c7ad860ad9eebfdc47a96ba2f8d03f4cf1c36b9d30787e276c7b9833b5bf2a6eba7e919e6b90083078a352262aed1d842e5f70a3085cbcf4c56ae851b161137920961c23fcc246598d61d258ccc615c927b2441359eea666a99ce1c3c07dca18fb0e1")]
[assembly: TargetFramework(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("RelWithDebInfo")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("This package contains ONNX Runtime for .Net platforms")]
[assembly: AssemblyFileVersion("1.26.0.0")]
[assembly: AssemblyInformationalVersion("1.26.0+8c546c37b43caaca1fa25db430dab94b901cf277")]
[assembly: AssemblyProduct("Microsoft.ML.OnnxRuntime")]
[assembly: AssemblyTitle("Microsoft.ML.OnnxRuntime C# Bindings")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/microsoft/onnxruntime")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.26.0.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]
namespace Microsoft.ML.OnnxRuntime
{
	[Flags]
	public enum OrtCompileApiFlags : uint
	{
		NONE = 0u,
		ERROR_IF_NO_NODES_COMPILED = 1u,
		ERROR_IF_OUTPUT_FILE_EXISTS = 2u
	}
	public class OrtModelCompilationOptions : IDisposable
	{
		public delegate void WriteBufferToDestinationDelegate(ReadOnlySpan<byte> buffer);

		public delegate OrtExternalInitializerInfo GetInitializerLocationDelegate(string initializerName, IReadOnlyOrtValue initializerValue, IReadOnlyExternalInitializerInfo originalInitializerLocation);

		private class WriteBufferToDestinationConnector
		{
			private readonly WriteBufferToDestinationDelegate _userDelegate;

			internal WriteBufferToDestinationConnector(WriteBufferToDestinationDelegate writeBufferDelegate)
			{
				_userDelegate = writeBufferDelegate;
			}

			public unsafe static nint WriteBufferToDestinationDelegateWrapper(nint state, nint buffer, nuint bufferNumBytes)
			{
				try
				{
					WriteBufferToDestinationConnector writeBufferToDestinationConnector = (WriteBufferToDestinationConnector)GCHandle.FromIntPtr(state).Target;
					ReadOnlySpan<byte> buffer2 = new ReadOnlySpan<byte>(((IntPtr)buffer).ToPointer(), checked((int)bufferNumBytes));
					writeBufferToDestinationConnector._userDelegate(buffer2);
				}
				catch (Exception ex)
				{
					string s = "The C# WriteBufferToDestination delegate threw an exception: " + ex.Message;
					return NativeMethods.OrtCreateStatus(1u, NativeOnnxValueHelper.StringToZeroTerminatedUtf8(s));
				}
				return IntPtr.Zero;
			}
		}

		private class GetInitializerLocationConnector
		{
			private readonly GetInitializerLocationDelegate _userDelegate;

			internal GetInitializerLocationConnector(GetInitializerLocationDelegate getInitializerLocationDelegate)
			{
				_userDelegate = getInitializerLocationDelegate;
			}

			public static nint GetInitializerLocationDelegateWrapper(nint state, nint initializerName, nint initializerValue, nint originalInitializerLocation, out nint newInitializerLocationOutput)
			{
				newInitializerLocationOutput = IntPtr.Zero;
				try
				{
					GetInitializerLocationConnector getInitializerLocationConnector = (GetInitializerLocationConnector)GCHandle.FromIntPtr(state).Target;
					string initializerName2 = NativeOnnxValueHelper.StringFromNativeUtf8(initializerName);
					IReadOnlyOrtValue initializerValue2 = new OrtValue(initializerValue, owned: false);
					IReadOnlyExternalInitializerInfo originalInitializerLocation2 = null;
					if (originalInitializerLocation != IntPtr.Zero)
					{
						originalInitializerLocation2 = new OrtExternalInitializerInfo(originalInitializerLocation);
					}
					OrtExternalInitializerInfo ortExternalInitializerInfo = getInitializerLocationConnector._userDelegate(initializerName2, initializerValue2, originalInitializerLocation2);
					if (ortExternalInitializerInfo != null)
					{
						byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(ortExternalInitializerInfo.GetFilePath());
						nint num = NativeMethods.OrtCreateExternalInitializerInfo(platformSerializedString, ortExternalInitializerInfo.GetFileOffset(), (nuint)ortExternalInitializerInfo.GetByteSize(), out newInitializerLocationOutput);
						if (num != IntPtr.Zero)
						{
							return num;
						}
					}
					else
					{
						newInitializerLocationOutput = IntPtr.Zero;
					}
				}
				catch (Exception ex)
				{
					string s = "The C# GetInitializerLocation delegate threw an exception: " + ex.Message;
					return NativeMethods.OrtCreateStatus(1u, NativeOnnxValueHelper.StringToZeroTerminatedUtf8(s));
				}
				return IntPtr.Zero;
			}
		}

		private class DelegateResources<Connector, Delegate> : IDisposable where Connector : class where Delegate : class
		{
			private Connector _connector;

			private Delegate _delegate;

			private GCHandle _connectorHandle;

			private GCHandle _delegateHandle;

			private bool _disposed;

			public DelegateResources(Connector connector, Delegate @delegate)
			{
				_connector = connector;
				_delegate = @delegate;
				_connectorHandle = GCHandle.Alloc(_connector);
				_delegateHandle = GCHandle.Alloc(_delegate);
			}

			internal nint GetFunctionPointerForDelegate()
			{
				return Marshal.GetFunctionPointerForDelegate(_delegate);
			}

			internal nint GetConnectorHandleAsPointer()
			{
				return GCHandle.ToIntPtr(_connectorHandle);
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
					if (_connectorHandle.IsAllocated)
					{
						_connectorHandle.Free();
						_connector = null;
					}
					if (_delegateHandle.IsAllocated)
					{
						_delegateHandle.Free();
						_delegate = null;
					}
					_disposed = true;
				}
			}

			~DelegateResources()
			{
				Dispose(disposing: false);
			}
		}

		private nint _handle;

		private bool _disposed;

		private DelegateResources<WriteBufferToDestinationConnector, NativeMethods.DOrtWriteBufferToDestinationDelegate> _writeBufferToDestinationDelegateState;

		private DelegateResources<GetInitializerLocationConnector, NativeMethods.DOrtGetInitializerLocationDelegate> _getInitializerLocationDelegateState;

		public OrtModelCompilationOptions(SessionOptions sessionOptions)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtCreateModelCompilationOptionsFromSessionOptions(OrtEnv.Instance().Handle, sessionOptions.Handle, out _handle));
		}

		public void CompileModel()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtCompileModel(OrtEnv.Instance().Handle, _handle));
		}

		public void SetInputModelPath(string path)
		{
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(path);
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetInputModelPath(_handle, platformSerializedString));
		}

		public void SetInputModelFromBuffer(byte[] buffer)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetInputModelFromBuffer(_handle, buffer, (nuint)buffer.Length));
		}

		public void SetOutputModelPath(string path)
		{
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(path);
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetOutputModelPath(_handle, platformSerializedString));
		}

		public void SetOutputModelExternalInitializersFile(string filePath, ulong threshold)
		{
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(filePath);
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetOutputModelExternalInitializersFile(_handle, platformSerializedString, new UIntPtr(threshold)));
		}

		internal void SetOutputModelBuffer(OrtAllocator allocator, ref nint outputModelBufferPtr, ref nuint outputModelBufferSizePtr)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetOutputModelBuffer(_handle, allocator.Pointer, ref outputModelBufferPtr, ref outputModelBufferSizePtr));
		}

		public void SetEpContextEmbedMode(bool embed)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetEpContextEmbedMode(_handle, embed));
		}

		public void SetFlags(OrtCompileApiFlags flags)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetFlags(_handle, (uint)flags));
		}

		public void SetEpContextBinaryInformation(string outputDirectory, string modelName)
		{
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(outputDirectory);
			byte[] platformSerializedString2 = NativeOnnxValueHelper.GetPlatformSerializedString(modelName);
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetEpContextBinaryInformation(_handle, platformSerializedString, platformSerializedString2));
		}

		public void SetGraphOptimizationLevel(GraphOptimizationLevel graphOptimizationLevel)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetGraphOptimizationLevel(_handle, graphOptimizationLevel));
		}

		public void SetOutputModelWriteDelegate(WriteBufferToDestinationDelegate writeBufferDelegate)
		{
			_writeBufferToDestinationDelegateState?.Dispose();
			_writeBufferToDestinationDelegateState = new DelegateResources<WriteBufferToDestinationConnector, NativeMethods.DOrtWriteBufferToDestinationDelegate>(new WriteBufferToDestinationConnector(writeBufferDelegate), WriteBufferToDestinationConnector.WriteBufferToDestinationDelegateWrapper);
			nint functionPointerForDelegate = _writeBufferToDestinationDelegateState.GetFunctionPointerForDelegate();
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetOutputModelWriteFunc(_handle, functionPointerForDelegate, _writeBufferToDestinationDelegateState.GetConnectorHandleAsPointer()));
		}

		public void SetOutputModelGetInitializerLocationDelegate(GetInitializerLocationDelegate getInitializerLocationDelegate)
		{
			_getInitializerLocationDelegateState?.Dispose();
			_getInitializerLocationDelegateState = new DelegateResources<GetInitializerLocationConnector, NativeMethods.DOrtGetInitializerLocationDelegate>(new GetInitializerLocationConnector(getInitializerLocationDelegate), GetInitializerLocationConnector.GetInitializerLocationDelegateWrapper);
			nint functionPointerForDelegate = _getInitializerLocationDelegateState.GetFunctionPointerForDelegate();
			NativeApiStatus.VerifySuccess(NativeMethods.CompileApi.OrtModelCompilationOptions_SetOutputModelGetInitializerLocationFunc(_handle, functionPointerForDelegate, _getInitializerLocationDelegateState.GetConnectorHandleAsPointer()));
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
				if (disposing)
				{
					_writeBufferToDestinationDelegateState?.Dispose();
					_getInitializerLocationDelegateState?.Dispose();
				}
				NativeMethods.CompileApi.OrtReleaseModelCompilationOptions(_handle);
				_handle = IntPtr.Zero;
				_disposed = true;
			}
		}

		~OrtModelCompilationOptions()
		{
			Dispose(disposing: false);
		}
	}
	public interface IDisposableReadOnlyCollection<T> : IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IDisposable
	{
	}
	internal class DisposableList<T> : List<T>, IDisposableReadOnlyCollection<T>, IReadOnlyCollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IDisposable where T : IDisposable
	{
		private bool _disposed;

		public DisposableList()
		{
		}

		public DisposableList(int count)
			: base(count)
		{
		}

		public DisposableList(IEnumerable<T> collection)
			: base(collection)
		{
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed || !disposing)
			{
				return;
			}
			for (int num = Count - 1; num >= 0; num--)
			{
				T val = base[num];
				if (val != null)
				{
					val.Dispose();
				}
			}
			Clear();
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	public class DisposableNamedOnnxValue : NamedOnnxValue, IDisposable
	{
		private IOrtValueOwner _ortValueHolder;

		private bool _disposed;

		public TensorElementType ElementType { get; }

		private DisposableNamedOnnxValue(string name, object value, TensorElementType elementType, IOrtValueOwner ortValueHolder)
			: base(name, value, OnnxValueType.ONNX_TYPE_TENSOR)
		{
			_ortValueHolder = ortValueHolder;
			ElementType = elementType;
		}

		private DisposableNamedOnnxValue(string name, object value, OnnxValueType onnxValueType, IOrtValueOwner ortValueHolder)
			: base(name, value, onnxValueType)
		{
			_ortValueHolder = ortValueHolder;
			ElementType = TensorElementType.DataTypeMax;
		}

		private DisposableNamedOnnxValue(string name, object value, MapHelper mapHelper, IOrtValueOwner ortValueHolder)
			: base(name, value, mapHelper)
		{
			_ortValueHolder = ortValueHolder;
			ElementType = TensorElementType.DataTypeMax;
		}

		internal override nint InputToOrtValueHandle(NodeMetadata metadata, out IDisposable memoryHolder)
		{
			if (_ortValueHolder == null)
			{
				throw new InvalidOperationException("The instance of this class does not own an OrtValue");
			}
			memoryHolder = null;
			return _ortValueHolder.Value.Handle;
		}

		internal override nint OutputToOrtValueHandle(NodeMetadata metadata, out IDisposable memoryOwner)
		{
			return InputToOrtValueHandle(metadata, out memoryOwner);
		}

		internal static DisposableNamedOnnxValue CreateFromOrtValue(string name, ref OrtValue ortValue)
		{
			return CreateFromOrtValue(name, ref ortValue, OrtAllocator.DefaultInstance);
		}

		internal static DisposableNamedOnnxValue CreateFromOrtValue(string name, ref OrtValue ortValue, OrtAllocator allocator)
		{
			OnnxValueType onnxType = ortValue.OnnxType;
			return onnxType switch
			{
				OnnxValueType.ONNX_TYPE_TENSOR => FromNativeTensor(name, ref ortValue), 
				OnnxValueType.ONNX_TYPE_SEQUENCE => FromNativeSequence(name, ref ortValue, allocator), 
				OnnxValueType.ONNX_TYPE_MAP => FromNativeMap(name, ref ortValue, allocator), 
				_ => throw new NotSupportedException($"OnnxValueType : {onnxType} is not supported"), 
			};
		}

		private static DisposableNamedOnnxValue FromNativeTensor(string name, ref OrtValue ortValue)
		{
			OrtTensorTypeAndShapeInfo tensorTypeAndShape = ortValue.GetTensorTypeAndShape();
			switch (tensorTypeAndShape.ElementDataType)
			{
			case TensorElementType.Float:
				return FromNativeTensor<float>(name, ref ortValue);
			case TensorElementType.Double:
				return FromNativeTensor<double>(name, ref ortValue);
			case TensorElementType.Int16:
				return FromNativeTensor<short>(name, ref ortValue);
			case TensorElementType.UInt16:
				return FromNativeTensor<ushort>(name, ref ortValue);
			case TensorElementType.Int32:
				return FromNativeTensor<int>(name, ref ortValue);
			case TensorElementType.UInt32:
				return FromNativeTensor<uint>(name, ref ortValue);
			case TensorElementType.Int64:
				return FromNativeTensor<long>(name, ref ortValue);
			case TensorElementType.UInt64:
				return FromNativeTensor<ulong>(name, ref ortValue);
			case TensorElementType.UInt8:
				return FromNativeTensor<byte>(name, ref ortValue);
			case TensorElementType.Int8:
				return FromNativeTensor<sbyte>(name, ref ortValue);
			case TensorElementType.String:
			{
				int[] shape = Array.ConvertAll(tensorTypeAndShape.Shape, Convert.ToInt32);
				return FromNativeStringTensor(name, shape, ref ortValue);
			}
			case TensorElementType.Bool:
				return FromNativeTensor<bool>(name, ref ortValue);
			case TensorElementType.Float16:
				return FromNativeTensor<Float16>(name, ref ortValue);
			case TensorElementType.BFloat16:
				return FromNativeTensor<BFloat16>(name, ref ortValue);
			default:
				throw new NotSupportedException($"Tensor of element type: {tensorTypeAndShape.ElementDataType} is not supported");
			}
		}

		private static DisposableNamedOnnxValue FromNativeStringTensor(string name, int[] shape, ref OrtValue ortValue)
		{
			DenseTensor<string> value = new DenseTensor<string>(ortValue.GetStringTensorAsArray(), shape);
			DisposableNamedOnnxValue result = new DisposableNamedOnnxValue(name, value, TensorElementType.String, ortValue);
			ortValue = null;
			return result;
		}

		private static DisposableNamedOnnxValue FromNativeTensor<T>(string name, ref OrtValue ortValue)
		{
			OrtValueTensor<T> ortValueTensor = new OrtValueTensor<T>(ref ortValue);
			try
			{
				DenseTensor<T> value = new DenseTensor<T>(ortValueTensor.Memory, ortValueTensor.Dimensions);
				return new DisposableNamedOnnxValue(name, value, ortValueTensor.ElementType, ortValueTensor);
			}
			catch (Exception)
			{
				ortValueTensor.Dispose();
				throw;
			}
		}

		private static DisposableNamedOnnxValue FromNativeSequence(string name, ref OrtValue ortValueSequence, OrtAllocator allocator)
		{
			int valueCount = ortValueSequence.GetValueCount();
			DisposableList<DisposableNamedOnnxValue> disposableList = new DisposableList<DisposableNamedOnnxValue>(valueCount);
			try
			{
				for (int i = 0; i < valueCount; i++)
				{
					OrtValue ortValue = ortValueSequence.GetValue(i, allocator);
					try
					{
						disposableList.Add(CreateFromOrtValue(string.Empty, ref ortValue, allocator));
					}
					finally
					{
						ortValue?.Dispose();
					}
				}
				NativeOrtValueCollectionOwner ortValueHolder = new NativeOrtValueCollectionOwner(ref ortValueSequence, disposableList);
				return new DisposableNamedOnnxValue(name, disposableList, OnnxValueType.ONNX_TYPE_SEQUENCE, ortValueHolder);
			}
			catch (Exception)
			{
				disposableList.Dispose();
				throw;
			}
		}

		private static DisposableNamedOnnxValue FromNativeMap(string name, ref OrtValue ortValueMap, OrtAllocator allocator)
		{
			DisposableNamedOnnxValue result = null;
			Span<OrtValue> disposables = new OrtValue[2];
			DisposableArray<OrtValue> disposableArray = new DisposableArray<OrtValue>(disposables);
			try
			{
				disposables[0] = ortValueMap.GetValue(0, allocator);
				disposables[1] = ortValueMap.GetValue(1, allocator);
				OrtTensorTypeAndShapeInfo tensorTypeAndShape = disposables[0].GetTensorTypeAndShape();
				OrtTensorTypeAndShapeInfo tensorTypeAndShape2 = disposables[1].GetTensorTypeAndShape();
				int[] keysShape = Array.ConvertAll(tensorTypeAndShape.Shape, Convert.ToInt32);
				int[] valsShape = Array.ConvertAll(tensorTypeAndShape2.Shape, Convert.ToInt32);
				result = tensorTypeAndShape.ElementDataType switch
				{
					TensorElementType.Int64 => tensorTypeAndShape2.ElementDataType switch
					{
						TensorElementType.Float => FromNativeMapElements<long, float>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						TensorElementType.Double => FromNativeMapElements<long, double>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						TensorElementType.Int64 => FromNativeMapElements<long, long>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						TensorElementType.String => FromNativeMapElements<long, string>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						_ => throw new NotSupportedException($"Map value type: {tensorTypeAndShape2.ElementDataType} is not supported"), 
					}, 
					TensorElementType.String => tensorTypeAndShape2.ElementDataType switch
					{
						TensorElementType.Float => FromNativeMapElements<string, float>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						TensorElementType.Double => FromNativeMapElements<string, double>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						TensorElementType.Int64 => FromNativeMapElements<string, long>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						TensorElementType.String => FromNativeMapElements<string, string>(name, ref ortValueMap, keysShape, ref disposables[0], valsShape, ref disposables[1]), 
						_ => throw new NotSupportedException($"Map value type: {tensorTypeAndShape2.ElementDataType} is not supported"), 
					}, 
					_ => throw new NotSupportedException($"Map key type: {tensorTypeAndShape.ElementDataType} is not supported"), 
				};
			}
			finally
			{
				disposableArray.Dispose();
			}
			return result;
		}

		private static DisposableNamedOnnxValue FromNativeMapElements<K, V>(string name, ref OrtValue ortValueMap, int[] keysShape, ref OrtValue ortValueTensorKeys, int[] valsShape, ref OrtValue ortValueTensorValues)
		{
			if (typeof(K) == typeof(string))
			{
				DenseTensor<string> denseTensorKeys = new DenseTensor<string>(ortValueTensorKeys.GetStringTensorAsArray(), keysShape);
				if (typeof(V) == typeof(string))
				{
					DenseTensor<string> denseTensorValues = new DenseTensor<string>(ortValueTensorValues.GetStringTensorAsArray(), valsShape);
					Dictionary<string, string> value = Enumerable.Range(0, (int)denseTensorKeys.Length).ToDictionary((int i) => denseTensorKeys[new int[1] { i }], (int i) => denseTensorValues[new int[1] { i }]);
					MapHelper mapHelper = new MapHelper(denseTensorKeys, denseTensorValues);
					DisposableNamedOnnxValue result = new DisposableNamedOnnxValue(name, value, mapHelper, ortValueMap);
					ortValueMap = null;
					return result;
				}
				OrtValueTensor<V> ortValueTensor = new OrtValueTensor<V>(ref ortValueTensorValues);
				try
				{
					DenseTensor<V> values = new DenseTensor<V>(ortValueTensor.Memory, ortValueTensor.Dimensions);
					return FromMapDenseTensors(name, ref ortValueMap, denseTensorKeys, values, ortValueTensor);
				}
				catch (Exception)
				{
					ortValueTensor.Dispose();
					throw;
				}
			}
			DisposableList<IDisposable> disposableList = new DisposableList<IDisposable>(2);
			try
			{
				OrtValueTensor<K> ortValueTensor2 = new OrtValueTensor<K>(ref ortValueTensorKeys);
				disposableList.Add(ortValueTensor2);
				DenseTensor<K> keys = new DenseTensor<K>(ortValueTensor2.Memory, ortValueTensor2.Dimensions);
				if (typeof(V) == typeof(string))
				{
					DenseTensor<string> values2 = new DenseTensor<string>(ortValueTensorValues.GetStringTensorAsArray(), valsShape);
					return FromMapDenseTensors(name, ref ortValueMap, keys, values2, disposableList);
				}
				OrtValueTensor<V> ortValueTensor3 = new OrtValueTensor<V>(ref ortValueTensorValues);
				disposableList.Add(ortValueTensor3);
				DenseTensor<V> values3 = new DenseTensor<V>(ortValueTensor3.Memory, ortValueTensor3.Dimensions);
				return FromMapDenseTensors(name, ref ortValueMap, keys, values3, disposableList);
			}
			catch (Exception)
			{
				disposableList.Dispose();
				throw;
			}
		}

		private static DisposableNamedOnnxValue FromMapDenseTensors<K, V>(string name, ref OrtValue ortValueMap, DenseTensor<K> keys, DenseTensor<V> values, IDisposable disposables)
		{
			Dictionary<K, V> value = Enumerable.Range(0, (int)keys.Length).ToDictionary((int i) => keys[new int[1] { i }], (int i) => values[new int[1] { i }]);
			MapHelper mapHelper = new MapHelper(keys, values);
			NativeOrtValueCollectionOwner ortValueHolder = new NativeOrtValueCollectionOwner(ref ortValueMap, disposables);
			return new DisposableNamedOnnxValue(name, value, mapHelper, ortValueHolder);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing && _ortValueHolder != null)
				{
					_ortValueHolder.Dispose();
					_ortValueHolder = null;
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
		}
	}
	internal enum ErrorCode
	{
		Ok,
		Fail,
		InvalidArgument,
		NoSuchFile,
		NoModel,
		EngineError,
		RuntimeException,
		InvalidProtobuf,
		ModelLoaded,
		NotImplemented,
		InvalidGraph,
		ShapeInferenceNotRegistered,
		RequirementNotRegistered
	}
	public class OnnxRuntimeException : Exception
	{
		private static Dictionary<ErrorCode, string> errorCodeToString = new Dictionary<ErrorCode, string>
		{
			{
				ErrorCode.Ok,
				"Ok"
			},
			{
				ErrorCode.Fail,
				"Fail"
			},
			{
				ErrorCode.InvalidArgument,
				"InvalidArgument"
			},
			{
				ErrorCode.NoSuchFile,
				"NoSuchFile"
			},
			{
				ErrorCode.NoModel,
				"NoModel"
			},
			{
				ErrorCode.EngineError,
				"EngineError"
			},
			{
				ErrorCode.RuntimeException,
				"RuntimeException"
			},
			{
				ErrorCode.InvalidProtobuf,
				"InvalidProtobuf"
			},
			{
				ErrorCode.ModelLoaded,
				"ModelLoaded"
			},
			{
				ErrorCode.NotImplemented,
				"NotImplemented"
			},
			{
				ErrorCode.InvalidGraph,
				"InvalidGraph"
			},
			{
				ErrorCode.ShapeInferenceNotRegistered,
				"ShapeInferenceNotRegistered"
			},
			{
				ErrorCode.RequirementNotRegistered,
				"RequirementNotRegistered"
			}
		};

		internal OnnxRuntimeException(ErrorCode errorCode, string message)
			: base("[ErrorCode:" + errorCodeToString[errorCode] + "] " + message)
		{
		}
	}
	public class FixedBufferOnnxValue : IDisposable
	{
		private bool _disposed;

		internal OrtValue Value { get; private set; }

		internal OnnxValueType OnnxValueType { get; private set; }

		internal TensorElementType ElementType { get; private set; }

		private FixedBufferOnnxValue(ref OrtValue ortValue, OnnxValueType onnxValueType, TensorElementType elementType)
		{
			Value = ortValue;
			ortValue = null;
			OnnxValueType = onnxValueType;
			ElementType = elementType;
		}

		public static FixedBufferOnnxValue CreateFromTensor<T>(Microsoft.ML.OnnxRuntime.Tensors.Tensor<T> value)
		{
			OrtValue ortValue = OrtValue.CreateFromTensorObject(value, out var elementType);
			return new FixedBufferOnnxValue(ref ortValue, OnnxValueType.ONNX_TYPE_TENSOR, elementType);
		}

		public static FixedBufferOnnxValue CreateFromMemory<T>(OrtMemoryInfo memoryInfo, Memory<T> memory, TensorElementType elementType, long[] shape, long bytesSize) where T : unmanaged
		{
			if (elementType == TensorElementType.String)
			{
				throw new ArgumentException("String data type is not supported");
			}
			OrtValue ortValue = OrtValue.CreateTensorValueFromMemory(memoryInfo, memory, shape);
			try
			{
				return new FixedBufferOnnxValue(ref ortValue, OnnxValueType.ONNX_TYPE_TENSOR, elementType);
			}
			catch (Exception)
			{
				ortValue?.Dispose();
				throw;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					Value.Dispose();
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	public class InferenceSession : IDisposable
	{
		private delegate string NameExtractor<in TInput>(TInput input);

		private delegate nint OrtValueHandleExtractor(NamedOnnxValue value, NodeMetadata metadata, out IDisposable memOwner);

		private delegate NodeMetadata MetadataLookup(string nodeName);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void OrtCallbackDelegate(nint userData, nint[] outputs, uint numOutputs, nint status);

		private delegate void UserCallbackDelegate(IReadOnlyCollection<OrtValue> outputs, nint status);

		private class CallbackHost
		{
			public IReadOnlyCollection<string> inputNames { get; }

			public IReadOnlyCollection<OrtValue> inputValues { get; }

			public IReadOnlyCollection<string> outputNames { get; }

			public IReadOnlyCollection<OrtValue> outputValues { get; }

			public UserCallbackDelegate callback { get; }

			public nint[] rawInputNames { get; }

			public nint[] rawInputValues { get; }

			public nint[] rawOutputNames { get; }

			public nint[] rawOutputValues { get; }

			public CallbackHost(InferenceSession session, IReadOnlyCollection<string> cbInputNames, IReadOnlyCollection<OrtValue> cbinputValues, IReadOnlyCollection<string> cbOutputNames, IReadOnlyCollection<OrtValue> cbOutputValues, UserCallbackDelegate userCallback)
			{
				inputNames = cbInputNames;
				inputValues = cbinputValues;
				outputNames = cbOutputNames;
				outputValues = cbOutputValues;
				callback = userCallback;
				rawInputNames = LookupUtf8Names(inputNames, (string n) => n, session.LookupInputMetadata);
				rawInputValues = inputValues.Select((OrtValue v) => v.Handle).ToArray();
				rawOutputNames = LookupUtf8Names(outputNames, (string n) => n, session.LookupOutputMetadata);
				rawOutputValues = outputValues.Select((OrtValue v) => v.Handle).ToArray();
			}
		}

		private nint _nativeHandle;

		private Dictionary<string, NodeMetadata> _inputMetadata;

		private List<string> _inputNames;

		private Dictionary<string, NodeMetadata> _outputMetadata;

		private List<string> _outputNames;

		private Dictionary<string, NodeMetadata> _overridableInitializerMetadata;

		private List<nint> _namesMemoryPtrs;

		private SessionOptions _builtInSessionOptions;

		private RunOptions _builtInRunOptions;

		private ModelMetadata _modelMetadata;

		private bool _disposed;

		private ulong _profilingStartTimeNs;

		private static OrtCallbackDelegate ortCallback = OrtCallback;

		public IReadOnlyDictionary<string, NodeMetadata> InputMetadata => _inputMetadata;

		public IReadOnlyList<string> InputNames => _inputNames;

		public IReadOnlyDictionary<string, NodeMetadata> OutputMetadata => _outputMetadata;

		public IReadOnlyList<string> OutputNames => _outputNames;

		public IReadOnlyDictionary<string, NodeMetadata> OverridableInitializerMetadata => _overridableInitializerMetadata;

		public ModelMetadata ModelMetadata
		{
			get
			{
				if (_modelMetadata != null)
				{
					return _modelMetadata;
				}
				_modelMetadata = new ModelMetadata(this);
				return _modelMetadata;
			}
		}

		public ulong ProfilingStartTimeNs => _profilingStartTimeNs;

		internal nint Handle => _nativeHandle;

		public InferenceSession(string modelPath)
		{
			_builtInSessionOptions = new SessionOptions();
			Init(modelPath, _builtInSessionOptions);
		}

		public InferenceSession(string modelPath, PrePackedWeightsContainer prepackedWeightsContainer)
		{
			_builtInSessionOptions = new SessionOptions();
			Init(modelPath, _builtInSessionOptions, prepackedWeightsContainer);
		}

		public InferenceSession(string modelPath, SessionOptions options)
		{
			Init(modelPath, options);
		}

		public InferenceSession(string modelPath, SessionOptions options, PrePackedWeightsContainer prepackedWeightsContainer)
		{
			Init(modelPath, options, prepackedWeightsContainer);
		}

		public InferenceSession(byte[] model)
		{
			_builtInSessionOptions = new SessionOptions();
			Init(model, _builtInSessionOptions);
		}

		public InferenceSession(byte[] model, PrePackedWeightsContainer prepackedWeightsContainer)
		{
			_builtInSessionOptions = new SessionOptions();
			Init(model, _builtInSessionOptions, prepackedWeightsContainer);
		}

		public InferenceSession(byte[] model, SessionOptions options)
		{
			Init(model, options);
		}

		public InferenceSession(byte[] model, SessionOptions options, PrePackedWeightsContainer prepackedWeightsContainer)
		{
			Init(model, options, prepackedWeightsContainer);
		}

		public IDisposableReadOnlyCollection<OrtMemoryInfo> GetMemoryInfosForInputs()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetInputCount(_nativeHandle, out var count));
			if (count == UIntPtr.Zero)
			{
				return new DisposableList<OrtMemoryInfo>();
			}
			nint[] array = new nint[count];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetMemoryInfoForInputs(_nativeHandle, array, count));
			return new DisposableList<OrtMemoryInfo>(array.Select((nint ptr) => new OrtMemoryInfo(ptr, owned: false)));
		}

		public IDisposableReadOnlyCollection<OrtMemoryInfo> GetMemoryInfosForOutputs()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetOutputCount(_nativeHandle, out var count));
			if (count == UIntPtr.Zero)
			{
				return new DisposableList<OrtMemoryInfo>();
			}
			nint[] array = new nint[count];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetMemoryInfoForOutputs(_nativeHandle, array, count));
			return new DisposableList<OrtMemoryInfo>(array.Select((nint ptr) => new OrtMemoryInfo(ptr, owned: false)));
		}

		public IReadOnlyList<OrtEpDevice> GetEpDeviceForInputs()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetInputCount(_nativeHandle, out var count));
			if (count == UIntPtr.Zero)
			{
				return Array.Empty<OrtEpDevice>();
			}
			nint[] array = new nint[count];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetEpDeviceForInputs(_nativeHandle, array, count));
			return array.Select((nint ptr) => (ptr != IntPtr.Zero) ? new OrtEpDevice(ptr) : null).ToList().AsReadOnly();
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<NamedOnnxValue> inputs)
		{
			return Run(inputs, _outputNames);
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<string> outputNames)
		{
			return Run(inputs, outputNames, _builtInRunOptions);
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<string> outputNames, RunOptions options)
		{
			nint[] inputNames = LookupUtf8Names(inputs, (NamedOnnxValue v) => v.Name, LookupInputMetadata);
			nint[] outputNames2 = LookupUtf8Names(outputNames, (string n) => n, LookupOutputMetadata);
			nint[] ortValuesHandles = GetOrtValuesHandles(inputs, LookupInputMetadata, ExtractOrtValueHandleForInput, out var disposer);
			try
			{
				using DisposableOrtValueHandleArray disposableOrtValueHandleArray = RunImpl(options, inputNames, ortValuesHandles, outputNames2);
				return CreateDisposableResult(disposableOrtValueHandleArray.Span, outputNames);
			}
			finally
			{
				disposer.Dispose();
			}
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<string> inputNames, IReadOnlyCollection<FixedBufferOnnxValue> inputValues)
		{
			return Run(inputNames, inputValues, _outputNames, _builtInRunOptions);
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<string> inputNames, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<string> outputNames)
		{
			return Run(inputNames, inputValues, outputNames, _builtInRunOptions);
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> Run(IReadOnlyCollection<string> inputNames, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<string> outputNames, RunOptions options)
		{
			if (inputNames.Count != inputValues.Count)
			{
				throw new ArgumentException($"Length of {"inputNames"} ({inputNames.Count}) must match that of {"inputValues"} ({inputValues.Count}).");
			}
			nint[] inputNames2 = LookupUtf8Names(inputNames, (string n) => n, LookupInputMetadata);
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues, input: true);
			nint[] outputNames2 = LookupUtf8Names(outputNames, (string n) => n, LookupOutputMetadata);
			using DisposableOrtValueHandleArray disposableOrtValueHandleArray = RunImpl(options, inputNames2, ortValuesHandles, outputNames2);
			return CreateDisposableResult(disposableOrtValueHandleArray.Span, outputNames);
		}

		public void Run(IReadOnlyCollection<string> inputNames, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<string> outputNames, IReadOnlyCollection<FixedBufferOnnxValue> outputValues)
		{
			Run(inputNames, inputValues, outputNames, outputValues, _builtInRunOptions);
		}

		public void Run(IReadOnlyCollection<string> inputNames, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<string> outputNames, IReadOnlyCollection<FixedBufferOnnxValue> outputValues, RunOptions options)
		{
			if (inputNames.Count != inputValues.Count)
			{
				throw new ArgumentException($"Length of {"inputNames"} ({inputNames.Count}) must match that of {"inputValues"} ({inputValues.Count}).");
			}
			if (outputNames.Count != outputValues.Count)
			{
				throw new ArgumentException($"Length of {"outputNames"} ({outputNames.Count}) must match that of {"outputValues"} ({outputValues.Count}).");
			}
			nint[] inputNames2 = LookupUtf8Names(inputNames, (string n) => n, LookupInputMetadata);
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues, input: true);
			nint[] outputNames2 = LookupUtf8Names(outputNames, (string n) => n, LookupOutputMetadata);
			nint[] ortValuesHandles2 = GetOrtValuesHandles(outputValues, input: false);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRun(_nativeHandle, options.Handle, inputNames2, ortValuesHandles, (nuint)inputNames.Count, outputNames2, (nuint)outputNames.Count, ortValuesHandles2));
		}

		public void Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<NamedOnnxValue> outputs)
		{
			Run(inputs, outputs, _builtInRunOptions);
		}

		public void Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<NamedOnnxValue> outputs, RunOptions options)
		{
			nint[] inputNames = LookupUtf8Names(inputs, (NamedOnnxValue i) => i.Name, LookupInputMetadata);
			nint[] outputNames = LookupUtf8Names(outputs, (NamedOnnxValue o) => o.Name, LookupOutputMetadata);
			nint[] ortValuesHandles = GetOrtValuesHandles(inputs, LookupInputMetadata, ExtractOrtValueHandleForInput, out var disposer);
			try
			{
				nint[] ortValuesHandles2 = GetOrtValuesHandles(outputs, LookupOutputMetadata, ExtractOrtValueHandleForOutput, out var disposer2);
				try
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtRun(_nativeHandle, options.Handle, inputNames, ortValuesHandles, (nuint)inputs.Count, outputNames, (nuint)outputs.Count, ortValuesHandles2));
				}
				finally
				{
					disposer2.Dispose();
				}
			}
			finally
			{
				disposer.Dispose();
			}
		}

		public void Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<string> outputNames, IReadOnlyCollection<FixedBufferOnnxValue> outputValues)
		{
			Run(inputs, outputNames, outputValues, _builtInRunOptions);
		}

		public void Run(IReadOnlyCollection<NamedOnnxValue> inputs, IReadOnlyCollection<string> outputNames, IReadOnlyCollection<FixedBufferOnnxValue> outputValues, RunOptions options)
		{
			if (outputNames.Count != outputValues.Count)
			{
				throw new ArgumentException($"Length of {"outputNames"} ({outputNames.Count}) must match that of {"outputValues"} ({outputValues.Count}).");
			}
			nint[] inputNames = LookupUtf8Names(inputs, (NamedOnnxValue i) => i.Name, LookupInputMetadata);
			nint[] outputNames2 = LookupUtf8Names(outputNames, (string n) => n, LookupOutputMetadata);
			nint[] ortValuesHandles = GetOrtValuesHandles(outputValues, input: false);
			nint[] ortValuesHandles2 = GetOrtValuesHandles(inputs, LookupInputMetadata, ExtractOrtValueHandleForInput, out var disposer);
			try
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtRun(_nativeHandle, options.Handle, inputNames, ortValuesHandles2, (nuint)inputs.Count, outputNames2, (nuint)outputNames.Count, ortValuesHandles));
			}
			finally
			{
				disposer.Dispose();
			}
		}

		public void Run(IReadOnlyCollection<string> inputNames, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<NamedOnnxValue> outputs)
		{
			Run(inputNames, inputValues, outputs, _builtInRunOptions);
		}

		public void Run(IReadOnlyCollection<string> inputNames, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<NamedOnnxValue> outputs, RunOptions options)
		{
			if (inputNames.Count != inputValues.Count)
			{
				throw new ArgumentException($"Length of {"inputNames"} ({inputNames.Count}) must match that of {"inputValues"} ({inputValues.Count}).");
			}
			nint[] inputNames2 = LookupUtf8Names(inputNames, (string n) => n, LookupInputMetadata);
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues, input: true);
			nint[] outputNames = LookupUtf8Names(outputs, (NamedOnnxValue o) => o.Name, LookupOutputMetadata);
			nint[] ortValuesHandles2 = GetOrtValuesHandles(outputs, LookupOutputMetadata, ExtractOrtValueHandleForOutput, out var disposer);
			try
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtRun(_nativeHandle, options.Handle, inputNames2, ortValuesHandles, (nuint)inputNames.Count, outputNames, (nuint)outputs.Count, ortValuesHandles2));
			}
			finally
			{
				disposer.Dispose();
			}
		}

		public IDisposableReadOnlyCollection<OrtValue> Run(RunOptions runOptions, IReadOnlyCollection<string> inputNames, IReadOnlyCollection<OrtValue> inputValues, IReadOnlyCollection<string> outputNames)
		{
			if (inputNames.Count != inputValues.Count)
			{
				throw new ArgumentException($"Length of {"inputNames"} ({inputNames.Count}) must match that of {"inputValues"} ({inputValues.Count}).");
			}
			nint[] inputNames2 = LookupUtf8Names(inputNames, (string n) => n, LookupInputMetadata);
			nint[] inputValues2 = inputValues.Select((OrtValue v) => v.Handle).ToArray();
			nint[] outputNames2 = LookupUtf8Names(outputNames, (string n) => n, LookupOutputMetadata);
			using DisposableOrtValueHandleArray disposableHandles = RunImpl(runOptions, inputNames2, inputValues2, outputNames2);
			return CreateDisposableResult(disposableHandles);
		}

		public IDisposableReadOnlyCollection<OrtValue> Run(RunOptions runOptions, IReadOnlyDictionary<string, OrtValue> inputs, IReadOnlyCollection<string> outputNames)
		{
			nint[] array = new nint[inputs.Count];
			nint[] array2 = new nint[inputs.Count];
			int num = 0;
			foreach (KeyValuePair<string, OrtValue> input in inputs)
			{
				array[num] = LookupInputMetadata(input.Key).ZeroTerminatedName;
				array2[num] = input.Value.Handle;
				num++;
			}
			nint[] outputNames2 = LookupUtf8Names(outputNames, (string n) => n, LookupOutputMetadata);
			using DisposableOrtValueHandleArray disposableHandles = RunImpl(runOptions, array, array2, outputNames2);
			return CreateDisposableResult(disposableHandles);
		}

		private static IDisposableReadOnlyCollection<OrtValue> CreateDisposableResult(DisposableOrtValueHandleArray disposableHandles)
		{
			DisposableList<OrtValue> disposableList = new DisposableList<OrtValue>(disposableHandles.Span.Length);
			try
			{
				for (int i = 0; i < disposableHandles.Span.Length; i++)
				{
					disposableList.Add(new OrtValue(disposableHandles.Span[i]));
					disposableHandles.Span[i] = IntPtr.Zero;
				}
				return disposableList;
			}
			catch (Exception)
			{
				disposableList.Dispose();
				throw;
			}
		}

		public void Run(RunOptions runOptions, IReadOnlyCollection<string> inputNames, IReadOnlyCollection<OrtValue> inputValues, IReadOnlyCollection<string> outputNames, IReadOnlyCollection<OrtValue> outputValues)
		{
			if (inputNames.Count != inputValues.Count)
			{
				throw new ArgumentException($"Length of {"inputNames"} ({inputNames.Count}) must match that of {"inputValues"} ({inputValues.Count}).");
			}
			if (outputNames.Count != outputValues.Count)
			{
				throw new ArgumentException($"Length of {"outputNames"} ({outputNames.Count}) must match that of {"outputValues"} ({outputValues.Count}).");
			}
			if (runOptions == null)
			{
				runOptions = _builtInRunOptions;
			}
			nint[] inputNames2 = LookupUtf8Names(inputNames, (string n) => n, LookupInputMetadata);
			nint[] inputValues2 = inputValues.Select((OrtValue v) => v.Handle).ToArray();
			nint[] outputNames2 = LookupUtf8Names(outputNames, (string n) => n, LookupOutputMetadata);
			nint[] outputValues2 = outputValues.Select((OrtValue v) => v.Handle).ToArray();
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRun(_nativeHandle, runOptions.Handle, inputNames2, inputValues2, (nuint)inputNames.Count, outputNames2, (nuint)outputNames.Count, outputValues2));
		}

		public OrtIoBinding CreateIoBinding()
		{
			return new OrtIoBinding(this);
		}

		public void RunWithBinding(RunOptions runOptions, OrtIoBinding ioBinding)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRunWithBinding(Handle, runOptions.Handle, ioBinding.Handle));
		}

		public IDisposableReadOnlyCollection<OrtValue> RunWithBoundResults(RunOptions runOptions, OrtIoBinding ioBinding)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRunWithBinding(Handle, runOptions.Handle, ioBinding.Handle));
			return ioBinding.GetOutputValues();
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> RunWithBindingAndNames(RunOptions runOptions, OrtIoBinding ioBinding, string[] names = null)
		{
			string[] array = names;
			if (array == null || names.Length == 0)
			{
				array = ioBinding.GetOutputNames();
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRunWithBinding(Handle, runOptions.Handle, ioBinding.Handle));
			OrtValue[] outputOrtValues = ioBinding.GetOutputOrtValues();
			DisposableArray<OrtValue> disposableArray = new DisposableArray<OrtValue>(outputOrtValues);
			try
			{
				DisposableList<DisposableNamedOnnxValue> disposableList = new DisposableList<DisposableNamedOnnxValue>(outputOrtValues.Length);
				try
				{
					for (int i = 0; i < array.Length; i++)
					{
						disposableList.Add(DisposableNamedOnnxValue.CreateFromOrtValue(array[i], ref outputOrtValues[i]));
					}
					return disposableList;
				}
				catch (Exception)
				{
					disposableList.Dispose();
					throw;
				}
			}
			finally
			{
				disposableArray.Dispose();
			}
		}

		public string EndProfiling()
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionEndProfiling(_nativeHandle, defaultInstance.Pointer, out var profile_file));
			return NativeOnnxValueHelper.StringFromNativeUtf8(profile_file, defaultInstance);
		}

		private NodeMetadata LookupInputMetadata(string nodeName)
		{
			if (!_inputMetadata.TryGetValue(nodeName, out var value) && !_overridableInitializerMetadata.TryGetValue(nodeName, out value))
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Input name: '" + nodeName + "' is not in the metadata");
			}
			return value;
		}

		private NodeMetadata LookupOutputMetadata(string nodeName)
		{
			if (!_outputMetadata.TryGetValue(nodeName, out var value))
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Output name: '" + nodeName + "' is not in the metadata");
			}
			return value;
		}

		private static nint ExtractOrtValueHandleForInput(NamedOnnxValue input, NodeMetadata metadata, out IDisposable memOwner)
		{
			return input.InputToOrtValueHandle(metadata, out memOwner);
		}

		private static nint ExtractOrtValueHandleForOutput(NamedOnnxValue output, NodeMetadata metadata, out IDisposable memOwner)
		{
			return output.OutputToOrtValueHandle(metadata, out memOwner);
		}

		private static nint[] LookupUtf8Names<T>(IReadOnlyCollection<T> values, NameExtractor<T> nameExtractor, MetadataLookup metaLookup)
		{
			nint[] array = new nint[values.Count];
			for (int i = 0; i < values.Count; i++)
			{
				string nodeName = nameExtractor(values.ElementAt(i));
				NodeMetadata nodeMetadata = metaLookup(nodeName);
				array[i] = nodeMetadata.ZeroTerminatedName;
			}
			return array;
		}

		private static nint[] GetOrtValuesHandles(IReadOnlyCollection<NamedOnnxValue> values, MetadataLookup metaLookup, OrtValueHandleExtractor ortValueExtractor, out DisposableArray<IDisposable> disposer)
		{
			IDisposable[] array = new IDisposable[values.Count];
			DisposableArray<IDisposable> disposableArray = new DisposableArray<IDisposable>(array);
			try
			{
				nint[] array2 = new nint[values.Count];
				for (int i = 0; i < values.Count; i++)
				{
					NamedOnnxValue namedOnnxValue = values.ElementAt(i);
					NodeMetadata metadata = metaLookup(namedOnnxValue.Name);
					array2[i] = ortValueExtractor(namedOnnxValue, metadata, out var memOwner);
					if (memOwner != null)
					{
						array[i] = memOwner;
					}
				}
				disposer = disposableArray;
				return array2;
			}
			catch (Exception)
			{
				disposableArray.Dispose();
				throw;
			}
		}

		private static nint[] GetOrtValuesHandles(IReadOnlyCollection<FixedBufferOnnxValue> values, bool input)
		{
			nint[] array = new nint[values.Count];
			for (int i = 0; i < values.Count; i++)
			{
				FixedBufferOnnxValue fixedBufferOnnxValue = values.ElementAt(i);
				if (!input && fixedBufferOnnxValue.ElementType == TensorElementType.String)
				{
					throw new NotSupportedException("Using string type FixedBufferOnnxValue in outputs is not supported.");
				}
				array[i] = fixedBufferOnnxValue.Value.Handle;
			}
			return array;
		}

		private DisposableOrtValueHandleArray RunImpl(RunOptions options, nint[] inputNames, nint[] inputValues, nint[] outputNames)
		{
			nint[] array = new nint[outputNames.Length];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRun(_nativeHandle, options.Handle, inputNames, inputValues, (nuint)inputNames.Length, outputNames, (nuint)outputNames.Length, array));
			return new DisposableOrtValueHandleArray(array);
		}

		private static IDisposableReadOnlyCollection<DisposableNamedOnnxValue> CreateDisposableResult(Span<nint> valueHandles, IReadOnlyCollection<string> outputNames)
		{
			DisposableList<DisposableNamedOnnxValue> disposableList = new DisposableList<DisposableNamedOnnxValue>(valueHandles.Length);
			try
			{
				for (int i = 0; i < valueHandles.Length; i++)
				{
					OrtValue ortValue = new OrtValue(valueHandles[i]);
					disposableList.Add(DisposableNamedOnnxValue.CreateFromOrtValue(outputNames.ElementAt(i), ref ortValue));
					valueHandles[i] = IntPtr.Zero;
				}
				return disposableList;
			}
			catch (OnnxRuntimeException)
			{
				disposableList.Dispose();
				throw;
			}
		}

		private static void OrtCallback(nint userData, nint[] outputs, uint numOutputs, nint status)
		{
			GCHandle gCHandle = GCHandle.FromIntPtr(userData);
			CallbackHost callbackHost = (CallbackHost)gCHandle.Target;
			try
			{
				callbackHost.callback(callbackHost.outputValues, status);
			}
			finally
			{
				gCHandle.Free();
			}
		}

		private unsafe void RunAsyncInternal(RunOptions options, IReadOnlyCollection<string> inputNames, IReadOnlyCollection<OrtValue> inputValues, IReadOnlyCollection<string> outputNames, IReadOnlyCollection<OrtValue> outputValues, UserCallbackDelegate callback)
		{
			CallbackHost callbackHost = new CallbackHost(this, inputNames, inputValues, outputNames, outputValues, callback);
			GCHandle value = GCHandle.Alloc(callbackHost, GCHandleType.Normal);
			try
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtRunAsync(_nativeHandle, options?.Handle ?? ((nint)(void*)null), callbackHost.rawInputNames, callbackHost.rawInputValues, (nuint)callbackHost.rawInputNames.Length, callbackHost.rawOutputNames, (nuint)callbackHost.rawOutputNames.Length, callbackHost.rawOutputValues, Marshal.GetFunctionPointerForDelegate(ortCallback), GCHandle.ToIntPtr(value)));
			}
			catch (OnnxRuntimeException)
			{
				value.Free();
				throw;
			}
		}

		public async Task<IReadOnlyCollection<OrtValue>> RunAsync(RunOptions options, IReadOnlyCollection<string> inputNames, IReadOnlyCollection<OrtValue> inputValues, IReadOnlyCollection<string> outputNames, IReadOnlyCollection<OrtValue> outputValues)
		{
			TaskCompletionSource<IReadOnlyCollection<OrtValue>> promise = new TaskCompletionSource<IReadOnlyCollection<OrtValue>>();
			RunAsyncInternal(options, inputNames, inputValues, outputNames, outputValues, (IReadOnlyCollection<OrtValue> outputs, nint status) =>
			{
				try
				{
					NativeApiStatus.VerifySuccess(status);
					promise.SetResult(outputs);
				}
				catch (Exception exception)
				{
					promise.SetException(exception);
				}
			});
			return await promise.Task;
		}

		private void Init(string modelPath, SessionOptions options, PrePackedWeightsContainer prepackedWeightsContainer = null)
		{
			nint handle = OrtEnv.Instance().Handle;
			nint session;
			if (prepackedWeightsContainer == null)
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateSession(handle, NativeOnnxValueHelper.GetPlatformSerializedString(modelPath), options.Handle, out session));
			}
			else
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateSessionWithPrepackedWeightsContainer(handle, NativeOnnxValueHelper.GetPlatformSerializedString(modelPath), options.Handle, prepackedWeightsContainer.Pointer, out session));
			}
			InitWithSessionHandle(session);
		}

		private void Init(byte[] modelData, SessionOptions options, PrePackedWeightsContainer prepackedWeightsContainer = null)
		{
			nint handle = OrtEnv.Instance().Handle;
			nint session;
			if (prepackedWeightsContainer == null)
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateSessionFromArray(handle, modelData, (nuint)modelData.Length, options.Handle, out session));
			}
			else
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateSessionFromArrayWithPrepackedWeightsContainer(handle, modelData, (nuint)modelData.Length, options.Handle, prepackedWeightsContainer.Pointer, out session));
			}
			InitWithSessionHandle(session);
		}

		private void InitWithSessionHandle(nint session)
		{
			_nativeHandle = session;
			try
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetInputCount(_nativeHandle, out var count));
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetOutputCount(_nativeHandle, out var count2));
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetOverridableInitializerCount(_nativeHandle, out var count3));
				int capacity = (int)count + (int)count2 + (int)count3;
				_namesMemoryPtrs = new List<nint>(capacity);
				_inputMetadata = new Dictionary<string, NodeMetadata>((int)count);
				_inputNames = new List<string>((int)count);
				for (ulong num = 0uL; num < count; num++)
				{
					NodeMetadata inputMetadata = GetInputMetadata(num);
					string inputName = GetInputName(num, out var utf);
					_namesMemoryPtrs.Add(utf);
					inputMetadata.ZeroTerminatedName = utf;
					_inputNames.Add(inputName);
					_inputMetadata[inputName] = inputMetadata;
				}
				_outputMetadata = new Dictionary<string, NodeMetadata>((int)count2);
				_outputNames = new List<string>((int)count2);
				for (ulong num2 = 0uL; num2 < count2; num2++)
				{
					NodeMetadata outputMetadata = GetOutputMetadata(num2);
					string outputName = GetOutputName(num2, out var utf2);
					_namesMemoryPtrs.Add(utf2);
					outputMetadata.ZeroTerminatedName = utf2;
					_outputNames.Add(outputName);
					_outputMetadata[outputName] = outputMetadata;
				}
				_overridableInitializerMetadata = new Dictionary<string, NodeMetadata>((int)count3);
				for (ulong num3 = 0uL; num3 < count3; num3++)
				{
					NodeMetadata overridableInitializerMetadata = GetOverridableInitializerMetadata(num3);
					string overridableInitializerName = GetOverridableInitializerName(num3, out var utf3);
					_namesMemoryPtrs.Add(utf3);
					overridableInitializerMetadata.ZeroTerminatedName = utf3;
					_overridableInitializerMetadata[overridableInitializerName] = overridableInitializerMetadata;
				}
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetProfilingStartTimeNs(_nativeHandle, out var startTime));
				_profilingStartTimeNs = startTime;
			}
			catch (Exception)
			{
				DisposeImpl(disposing: true);
				throw;
			}
			_builtInRunOptions = new RunOptions();
		}

		private string GetOutputName(ulong index, out nint utf8)
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetOutputName(_nativeHandle, (nuint)index, defaultInstance.Pointer, out var name));
			NativeOnnxValueHelper.StringAndUtf8FromNative(defaultInstance, name, out var str, out utf8);
			return str;
		}

		private string GetInputName(ulong index, out nint utf8)
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetInputName(_nativeHandle, (nuint)index, defaultInstance.Pointer, out var name));
			NativeOnnxValueHelper.StringAndUtf8FromNative(defaultInstance, name, out var str, out utf8);
			return str;
		}

		private string GetOverridableInitializerName(ulong index, out nint utf8)
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetOverridableInitializerName(_nativeHandle, (nuint)index, defaultInstance.Pointer, out var name));
			NativeOnnxValueHelper.StringAndUtf8FromNative(defaultInstance, name, out var str, out utf8);
			return str;
		}

		private NodeMetadata GetInputMetadata(ulong index)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetInputTypeInfo(_nativeHandle, (nuint)index, out var typeInfo));
			try
			{
				return GetMetadataFromTypeInfo(typeInfo);
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(typeInfo);
			}
		}

		private NodeMetadata GetOutputMetadata(ulong index)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetOutputTypeInfo(_nativeHandle, (nuint)index, out var typeInfo));
			try
			{
				return GetMetadataFromTypeInfo(typeInfo);
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(typeInfo);
			}
		}

		private NodeMetadata GetOverridableInitializerMetadata(ulong index)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetOverridableInitializerTypeInfo(_nativeHandle, (nuint)index, out var typeInfo));
			try
			{
				return GetMetadataFromTypeInfo(typeInfo);
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(typeInfo);
			}
		}

		internal static NodeMetadata GetMetadataFromTypeInfo(nint typeInfo)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetOnnxTypeFromTypeInfo(typeInfo, out var onnxtype));
			OnnxValueType onnxValueType = (OnnxValueType)onnxtype;
			switch (onnxValueType)
			{
			case OnnxValueType.ONNX_TYPE_TENSOR:
			case OnnxValueType.ONNX_TYPE_SPARSETENSOR:
				return GetTensorNodeMetadata(onnxValueType, typeInfo);
			case OnnxValueType.ONNX_TYPE_SEQUENCE:
				return GetSequenceMetadataFromTypeInfo(typeInfo);
			case OnnxValueType.ONNX_TYPE_MAP:
				return GetMapMetadataFromTypeInfo(typeInfo);
			case OnnxValueType.ONNX_TYPE_OPTIONAL:
				return GetOptionalMetadataFromTypeInfo(typeInfo);
			default:
				throw new OnnxRuntimeException(ErrorCode.NotImplemented, $"Value type: '{onnxValueType}' not supported in this code");
			}
		}

		internal static NodeMetadata GetSequenceMetadataFromTypeInfo(nint typeInfo)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToSequenceTypeInfo(typeInfo, out var sequenceTypeInfo));
			if (sequenceTypeInfo == IntPtr.Zero)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "TypeInfo cast to SequenceTypeInfo failed. The object does not represent a sequence");
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetSequenceElementType(sequenceTypeInfo, out var elementTypeInfo));
			try
			{
				return new NodeMetadata(new SequenceMetadata(GetMetadataFromTypeInfo(elementTypeInfo)));
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(elementTypeInfo);
			}
		}

		internal static NodeMetadata GetMapMetadataFromTypeInfo(nint typeInfo)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToMapTypeInfo(typeInfo, out var mapTypeInfo));
			if (mapTypeInfo == IntPtr.Zero)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "TypeInfo cast to MapTypeInfo failed. The object does not represent a map");
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetMapKeyType(mapTypeInfo, out var tensorElementType));
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetMapValueType(mapTypeInfo, out var type_info));
			try
			{
				NodeMetadata metadataFromTypeInfo = GetMetadataFromTypeInfo(type_info);
				return new NodeMetadata(new MapMetadata((TensorElementType)tensorElementType, metadataFromTypeInfo));
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(type_info);
			}
		}

		internal static NodeMetadata GetOptionalMetadataFromTypeInfo(nint typeInfo)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToOptionalTypeInfo(typeInfo, out var optionalTypeInfo));
			if (optionalTypeInfo == IntPtr.Zero)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "TypeInfo cast to OptionalTypeInfo failed. The object does not represent a optional value");
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetOptionalContainedTypeInfo(optionalTypeInfo, out var containedTypeInfo));
			try
			{
				return new NodeMetadata(new OptionalMetadata(GetMetadataFromTypeInfo(containedTypeInfo)));
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(containedTypeInfo);
			}
		}

		internal static NodeMetadata GetTensorNodeMetadata(OnnxValueType valueType, nint typeInfo)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToTensorInfo(typeInfo, out var typeAndShapeInfo));
			if (typeAndShapeInfo == IntPtr.Zero)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "TypeInfo cast to TensorTypeInfo failed. The object does not represent a tensor");
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorElementType(typeAndShapeInfo, out var output));
			TensorElementType elementType = (TensorElementType)output;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetDimensionsCount(typeAndShapeInfo, out var output2));
			long[] array = new long[(uint)output2];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetDimensions(typeAndShapeInfo, array, output2));
			int[] array2 = new int[(uint)output2];
			for (int i = 0; (long)i < (long)output2; i++)
			{
				array2[i] = (int)array[i];
			}
			nint[] array3 = new nint[(uint)output2];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetSymbolicDimensions(typeAndShapeInfo, array3, output2));
			string[] array4 = new string[(uint)output2];
			for (int j = 0; j < (int)output2; j++)
			{
				array4[j] = NativeOnnxValueHelper.StringFromNativeUtf8(array3[j]);
			}
			TensorTypeAndShape typeAndShape = new TensorTypeAndShape(elementType, array2, array4);
			return new NodeMetadata(valueType, typeAndShape);
		}

		~InferenceSession()
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
				DisposeImpl(disposing);
			}
		}

		private void DisposeImpl(bool disposing)
		{
			if (disposing)
			{
				if (_namesMemoryPtrs != null)
				{
					foreach (nint namesMemoryPtr in _namesMemoryPtrs)
					{
						Marshal.FreeHGlobal(namesMemoryPtr);
					}
					_namesMemoryPtrs = null;
				}
				if (_builtInSessionOptions != null)
				{
					_builtInSessionOptions.Dispose();
					_builtInSessionOptions = null;
				}
				if (_builtInRunOptions != null)
				{
					_builtInRunOptions.Dispose();
					_builtInRunOptions = null;
				}
			}
			if (_nativeHandle != IntPtr.Zero)
			{
				NativeMethods.OrtReleaseSession(_nativeHandle);
				_nativeHandle = IntPtr.Zero;
			}
			_disposed = true;
		}
	}
	public class TensorTypeAndShape
	{
		public TensorElementType ElementDataType { get; }

		public int[] Dimensions { get; }

		public string[] SymbolicDimensions { get; }

		public TensorElementTypeInfo ElementTypeInfo { get; }

		internal TensorTypeAndShape(TensorElementType elementType, int[] dimensions, string[] symbolicDimensions)
		{
			ElementTypeInfo = TensorBase.GetElementTypeInfo(elementType);
			if (ElementTypeInfo == null)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Unregistered TensorElementType value of: " + elementType);
			}
			ElementDataType = elementType;
			Dimensions = dimensions;
			SymbolicDimensions = symbolicDimensions;
		}
	}
	public class SequenceMetadata
	{
		public NodeMetadata ElementMeta { get; }

		internal SequenceMetadata(NodeMetadata elementData)
		{
			ElementMeta = elementData;
		}
	}
	public class OptionalMetadata
	{
		public NodeMetadata ElementMeta { get; }

		internal OptionalMetadata(NodeMetadata elementData)
		{
			ElementMeta = elementData;
		}
	}
	public class MapMetadata
	{
		public TensorElementType KeyDataType { get; }

		public NodeMetadata ValueMetadata { get; }

		internal MapMetadata(TensorElementType keyDataType, NodeMetadata valueMetadata)
		{
			KeyDataType = keyDataType;
			ValueMetadata = valueMetadata;
		}
	}
	public class NodeMetadata
	{
		private readonly object _metadata;

		public OnnxValueType OnnxValueType { get; }

		internal nint ZeroTerminatedName { get; set; }

		public int[] Dimensions
		{
			get
			{
				CheckTensor();
				return (_metadata as TensorTypeAndShape).Dimensions;
			}
		}

		public string[] SymbolicDimensions
		{
			get
			{
				CheckTensor();
				return (_metadata as TensorTypeAndShape).SymbolicDimensions;
			}
		}

		public Type ElementType
		{
			get
			{
				CheckTensor();
				return (_metadata as TensorTypeAndShape).ElementTypeInfo.TensorType;
			}
		}

		public TensorElementType ElementDataType
		{
			get
			{
				CheckTensor();
				return (_metadata as TensorTypeAndShape).ElementDataType;
			}
		}

		public bool IsString
		{
			get
			{
				CheckTensor();
				return (_metadata as TensorTypeAndShape).ElementTypeInfo.IsString;
			}
		}

		public bool IsTensor
		{
			get
			{
				if (OnnxValueType != OnnxValueType.ONNX_TYPE_TENSOR)
				{
					return OnnxValueType == OnnxValueType.ONNX_TYPE_SPARSETENSOR;
				}
				return true;
			}
		}

		internal NodeMetadata(OnnxValueType onnxValueType, TensorTypeAndShape typeAndShape)
		{
			OnnxValueType = onnxValueType;
			CheckTensor();
			_metadata = typeAndShape;
		}

		internal NodeMetadata(MapMetadata mapMetadata)
		{
			OnnxValueType = OnnxValueType.ONNX_TYPE_MAP;
			_metadata = mapMetadata;
		}

		internal NodeMetadata(SequenceMetadata sequenceMetadata)
		{
			OnnxValueType = OnnxValueType.ONNX_TYPE_SEQUENCE;
			_metadata = sequenceMetadata;
		}

		internal NodeMetadata(OptionalMetadata optMetadata)
		{
			OnnxValueType = OnnxValueType.ONNX_TYPE_OPTIONAL;
			_metadata = optMetadata;
		}

		private void CheckTensor()
		{
			if (!IsTensor)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "OnnxValueType must either be a tensor or sparse tensor");
			}
		}

		public MapMetadata AsMapMetadata()
		{
			if (OnnxValueType != OnnxValueType.ONNX_TYPE_MAP)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "Instance does not contain Map metadata");
			}
			return _metadata as MapMetadata;
		}

		public SequenceMetadata AsSequenceMetadata()
		{
			if (OnnxValueType != OnnxValueType.ONNX_TYPE_SEQUENCE)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "Instance does not contain Sequence metadata");
			}
			return _metadata as SequenceMetadata;
		}

		public OptionalMetadata AsOptionalMetadata()
		{
			if (OnnxValueType != OnnxValueType.ONNX_TYPE_OPTIONAL)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "Instance does not contain Optional metadata");
			}
			return _metadata as OptionalMetadata;
		}
	}
	public class ModelMetadata
	{
		private string _producerName;

		private string _graphName;

		private string _domain;

		private string _description;

		private string _graphDescription;

		private long _version;

		private Dictionary<string, string> _customMetadataMap = new Dictionary<string, string>();

		public string ProducerName => _producerName;

		public string GraphName => _graphName;

		public string Domain => _domain;

		public string Description => _description;

		public string GraphDescription => _graphDescription;

		public long Version => _version;

		public Dictionary<string, string> CustomMetadataMap => _customMetadataMap;

		internal unsafe ModelMetadata(InferenceSession session)
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionGetModelMetadata(session.Handle, out var modelMetadata));
			try
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataGetProducerName(modelMetadata, defaultInstance.Pointer, out var value));
				_producerName = NativeOnnxValueHelper.StringFromNativeUtf8(value, defaultInstance);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataGetGraphName(modelMetadata, defaultInstance.Pointer, out var value2));
				_graphName = NativeOnnxValueHelper.StringFromNativeUtf8(value2, defaultInstance);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataGetDomain(modelMetadata, defaultInstance.Pointer, out var value3));
				_domain = NativeOnnxValueHelper.StringFromNativeUtf8(value3, defaultInstance);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataGetDescription(modelMetadata, defaultInstance.Pointer, out var value4));
				_description = NativeOnnxValueHelper.StringFromNativeUtf8(value4, defaultInstance);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataGetGraphDescription(modelMetadata, defaultInstance.Pointer, out var value5));
				_graphDescription = NativeOnnxValueHelper.StringFromNativeUtf8(value5, defaultInstance);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataGetVersion(modelMetadata, out _version));
				NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataGetCustomMetadataMapKeys(modelMetadata, defaultInstance.Pointer, out var keys, out var numKeys));
				try
				{
					Span<nint> span = new Span<nint>(((IntPtr)keys).ToPointer(), (int)numKeys);
					using DisposableList<OrtMemoryAllocation> disposableList = new DisposableList<OrtMemoryAllocation>((int)numKeys);
					Span<nint> span2 = span;
					for (int i = 0; i < span2.Length; i++)
					{
						nint pointer = span2[i];
						disposableList.Add(new OrtMemoryAllocation(defaultInstance, pointer, 0u));
					}
					span2 = span;
					for (int i = 0; i < span2.Length; i++)
					{
						nint num = span2[i];
						NativeApiStatus.VerifySuccess(NativeMethods.OrtModelMetadataLookupCustomMetadataMap(modelMetadata, defaultInstance.Pointer, num, out var value6));
						string value7 = NativeOnnxValueHelper.StringFromNativeUtf8(value6, defaultInstance);
						string key = NativeOnnxValueHelper.StringFromNativeUtf8(num);
						_customMetadataMap[key] = value7;
					}
				}
				finally
				{
					defaultInstance.FreeMemory(keys);
				}
			}
			finally
			{
				NativeMethods.OrtReleaseModelMetadata(modelMetadata);
			}
		}
	}
	internal class ManagedTypeProjection
	{
		internal static OrtValue CreateProjection(NamedOnnxValue namedOnnxValue, NodeMetadata metadata)
		{
			NodeMetadata nodeMetadata = metadata;
			if (metadata.OnnxValueType == OnnxValueType.ONNX_TYPE_OPTIONAL)
			{
				nodeMetadata = metadata.AsOptionalMetadata().ElementMeta;
			}
			if (namedOnnxValue.ValueType != nodeMetadata.OnnxValueType)
			{
				throw new OnnxRuntimeException(ErrorCode.RuntimeException, $"NamedOnnxValue: {namedOnnxValue.Name} has value type: {namedOnnxValue.ValueType} expected: {nodeMetadata.OnnxValueType} after optional type adjustment");
			}
			return namedOnnxValue.ValueType switch
			{
				OnnxValueType.ONNX_TYPE_TENSOR => CreateTensorProjection(namedOnnxValue, nodeMetadata), 
				OnnxValueType.ONNX_TYPE_SEQUENCE => CreateSequenceProjection(namedOnnxValue, nodeMetadata), 
				OnnxValueType.ONNX_TYPE_MAP => CreateMapProjection(namedOnnxValue, nodeMetadata), 
				_ => throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "ManagedTypeProjection can only project tensors, sequences, maps and optional types"), 
			};
		}

		private static OrtValue CreateSequenceProjection(NamedOnnxValue namedOnnxValue, NodeMetadata metadata)
		{
			NodeMetadata elementMeta = metadata.AsSequenceMetadata().ElementMeta;
			OnnxValueType onnxValueType = elementMeta.OnnxValueType;
			IEnumerable<NamedOnnxValue> enumerable = namedOnnxValue.AsEnumerable<NamedOnnxValue>() ?? throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "NamedOnnxValue: " + namedOnnxValue.Name + " sequence does not contain NamedOnnxValue elements");
			int count = 0;
			if (enumerable is ICollection<NamedOnnxValue> collection)
			{
				count = collection.Count;
			}
			DisposableList<OrtValue> compositeMembers = new DisposableList<OrtValue>(count);
			try
			{
				foreach (NamedOnnxValue item in enumerable)
				{
					if (onnxValueType != item.ValueType)
					{
						throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"NamedOnnxValue: {namedOnnxValue.Name} sequence element expected to be {onnxValueType}, received {item.ValueType}");
					}
					compositeMembers.Add(CreateProjection(item, elementMeta));
				}
				return OrtValue.CreateSequence(ref compositeMembers);
			}
			catch (Exception)
			{
				compositeMembers?.Dispose();
				throw;
			}
		}

		private static OrtValue CreateMapProjection(NamedOnnxValue node, NodeMetadata elementMeta)
		{
			MapMetadata mapMetadata = elementMeta.AsMapMetadata();
			NodeMetadata valueMetadata = mapMetadata.ValueMetadata;
			if (valueMetadata.OnnxValueType != OnnxValueType.ONNX_TYPE_TENSOR)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Node: " + node.Name + " onnxruntime only supports maps with primitive types values");
			}
			Span<OrtValue> disposables = new OrtValue[2];
			DisposableArray<OrtValue> disposableArray = new DisposableArray<OrtValue>(disposables);
			try
			{
				TensorBase dictionaryKeys = node.GetDictionaryKeys();
				disposables[0] = OrtValue.CreateFromTensorObject(dictionaryKeys, out var elementType);
				if (elementType != mapMetadata.KeyDataType)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Map key data type supplied: {elementType} metadata expected: {mapMetadata.KeyDataType}");
				}
				TensorBase dictionaryValues = node.GetDictionaryValues();
				disposables[1] = OrtValue.CreateFromTensorObject(dictionaryValues, out var elementType2);
				if (elementType2 != valueMetadata.ElementDataType)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Map value data type supplied: {elementType2} metadata expected: {valueMetadata.ElementDataType}");
				}
				return OrtValue.CreateMap(ref disposables[0], ref disposables[1]);
			}
			catch (Exception)
			{
				disposableArray.Dispose();
				throw;
			}
		}

		private static OrtValue CreateTensorProjection(NamedOnnxValue node, NodeMetadata elementMeta)
		{
			if (!(node.Value is TensorBase))
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"NamedOnnxValue contains: {node.Value.GetType()}, expecting a Tensor<T>");
			}
			OrtValue ortValue = OrtValue.CreateFromTensorObject(node.Value as TensorBase, out var elementType);
			try
			{
				if (elementType != elementMeta.ElementDataType)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Tensor element data type discovered: {elementType} metadata expected: {elementMeta.ElementDataType}");
				}
				return ortValue;
			}
			catch (Exception)
			{
				ortValue.Dispose();
				throw;
			}
		}
	}
	internal class MapHelper
	{
		internal TensorBase Keys { get; }

		internal TensorBase Values { get; }

		internal MapHelper(TensorBase keys, TensorBase values)
		{
			Keys = keys;
			Values = values;
		}
	}
	public class NamedOnnxValue
	{
		private object _value;

		private string _name;

		private MapHelper _mapHelper;

		public OnnxValueType ValueType { get; internal set; }

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		[Obsolete("Use constructors with valueType or static factory methods")]
		protected NamedOnnxValue(string name, object value)
		{
			_name = name;
			_value = value;
			ValueType = OnnxValueType.ONNX_TYPE_UNKNOWN;
		}

		internal NamedOnnxValue(string name, object value, OnnxValueType valueType)
		{
			_name = name;
			_value = value;
			ValueType = valueType;
			if (valueType == OnnxValueType.ONNX_TYPE_MAP)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Use another __ctor for maps");
			}
		}

		internal NamedOnnxValue(string name, object value, MapHelper helper)
		{
			_name = name;
			_value = value;
			ValueType = OnnxValueType.ONNX_TYPE_MAP;
			_mapHelper = helper;
		}

		public static NamedOnnxValue CreateFromTensor<T>(string name, Microsoft.ML.OnnxRuntime.Tensors.Tensor<T> value)
		{
			return new NamedOnnxValue(name, value, OnnxValueType.ONNX_TYPE_TENSOR);
		}

		public static NamedOnnxValue CreateFromSequence<T>(string name, IEnumerable<T> value)
		{
			return new NamedOnnxValue(name, value, OnnxValueType.ONNX_TYPE_SEQUENCE);
		}

		public static NamedOnnxValue CreateFromMap<K, V>(string name, IDictionary<K, V> value)
		{
			return CreateFromMap(name, value.Keys, value.Values);
		}

		internal static NamedOnnxValue CreateFromMap<K, V>(string name, ICollection<K> keys, ICollection<V> values)
		{
			DenseTensor<K> keys2 = new DenseTensor<K>(keys.ToArray(), new int[1] { keys.Count });
			DenseTensor<V> values2 = new DenseTensor<V>(values.ToArray(), new int[1] { values.Count });
			return new NamedOnnxValue(name, values, new MapHelper(keys2, values2));
		}

		public Microsoft.ML.OnnxRuntime.Tensors.Tensor<T> AsTensor<T>()
		{
			return _value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<T>;
		}

		public IEnumerable<T> AsEnumerable<T>()
		{
			return _value as IEnumerable<T>;
		}

		public IDictionary<K, V> AsDictionary<K, V>()
		{
			return _value as IDictionary<K, V>;
		}

		internal virtual nint InputToOrtValueHandle(NodeMetadata metadata, out IDisposable memoryOwner)
		{
			return ((OrtValue)(memoryOwner = ManagedTypeProjection.CreateProjection(this, metadata))).Handle;
		}

		internal virtual nint OutputToOrtValueHandle(NodeMetadata metadata, out IDisposable memoryOwner)
		{
			if (metadata.OnnxValueType == OnnxValueType.ONNX_TYPE_TENSOR)
			{
				return ((OrtValue)(memoryOwner = ManagedTypeProjection.CreateProjection(this, metadata))).Handle;
			}
			if (metadata.OnnxValueType == OnnxValueType.ONNX_TYPE_OPTIONAL && metadata.AsOptionalMetadata().ElementMeta.OnnxValueType == OnnxValueType.ONNX_TYPE_TENSOR)
			{
				return ((OrtValue)(memoryOwner = ManagedTypeProjection.CreateProjection(this, metadata))).Handle;
			}
			throw new OnnxRuntimeException(ErrorCode.NotImplemented, $"Can not create output OrtValue for NamedOnnxValue '{metadata.OnnxValueType}' type. Only tensors can be pre-allocated for outputs  Use Run() overloads that return DisposableNamedOnnxValue to get access to all Onnx value types that may be returned as output.");
		}

		internal TensorBase GetDictionaryKeys()
		{
			if (ValueType != OnnxValueType.ONNX_TYPE_MAP)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "This NamedOnnxValue instance does not contain a dictionary");
			}
			return _mapHelper.Keys;
		}

		internal TensorBase GetDictionaryValues()
		{
			if (ValueType != OnnxValueType.ONNX_TYPE_MAP)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "This NamedOnnxValue instance does not contain a dictionary");
			}
			return _mapHelper.Values;
		}
	}
	internal class NativeApiStatus
	{
		private static string GetErrorMessage(nint status)
		{
			return NativeOnnxValueHelper.StringFromNativeUtf8(NativeMethods.OrtGetErrorMessage(status));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void VerifySuccess(nint nativeStatus)
		{
			if (nativeStatus != IntPtr.Zero)
			{
				try
				{
					ErrorCode errorCode = NativeMethods.OrtGetErrorCode(nativeStatus);
					string errorMessage = GetErrorMessage(nativeStatus);
					throw new OnnxRuntimeException(errorCode, errorMessage);
				}
				finally
				{
					NativeMethods.OrtReleaseStatus(nativeStatus);
				}
			}
		}
	}
	public struct OrtApiBase
	{
		public nint GetApi;

		public nint GetVersionString;
	}
	public struct OrtApi
	{
		public nint CreateStatus;

		public nint GetErrorCode;

		public nint GetErrorMessage;

		public nint CreateEnv;

		public nint CreateEnvWithCustomLogger;

		public nint EnableTelemetryEvents;

		public nint DisableTelemetryEvents;

		public nint CreateSession;

		public nint CreateSessionFromArray;

		public nint Run;

		public nint CreateSessionOptions;

		public nint SetOptimizedModelFilePath;

		public nint CloneSessionOptions;

		public nint SetSessionExecutionMode;

		public nint EnableProfiling;

		public nint DisableProfiling;

		public nint EnableMemPattern;

		public nint DisableMemPattern;

		public nint EnableCpuMemArena;

		public nint DisableCpuMemArena;

		public nint SetSessionLogId;

		public nint SetSessionLogVerbosityLevel;

		public nint SetSessionLogSeverityLevel;

		public nint SetSessionGraphOptimizationLevel;

		public nint SetIntraOpNumThreads;

		public nint SetInterOpNumThreads;

		public nint CreateCustomOpDomain;

		public nint CustomOpDomain_Add;

		public nint AddCustomOpDomain;

		public nint RegisterCustomOpsLibrary;

		public nint SessionGetInputCount;

		public nint SessionGetOutputCount;

		public nint SessionGetOverridableInitializerCount;

		public nint SessionGetInputTypeInfo;

		public nint SessionGetOutputTypeInfo;

		public nint SessionGetOverridableInitializerTypeInfo;

		public nint SessionGetInputName;

		public nint SessionGetOutputName;

		public nint SessionGetOverridableInitializerName;

		public nint CreateRunOptions;

		public nint RunOptionsSetRunLogVerbosityLevel;

		public nint RunOptionsSetRunLogSeverityLevel;

		public nint RunOptionsSetRunTag;

		public nint RunOptionsGetRunLogVerbosityLevel;

		public nint RunOptionsGetRunLogSeverityLevel;

		public nint RunOptionsGetRunTag;

		public nint RunOptionsSetTerminate;

		public nint RunOptionsUnsetTerminate;

		public nint CreateTensorAsOrtValue;

		public nint CreateTensorWithDataAsOrtValue;

		public nint IsTensor;

		public nint GetTensorMutableData;

		public nint FillStringTensor;

		public nint GetStringTensorDataLength;

		public nint GetStringTensorContent;

		public nint CastTypeInfoToTensorInfo;

		public nint GetOnnxTypeFromTypeInfo;

		public nint CreateTensorTypeAndShapeInfo;

		public nint SetTensorElementType;

		public nint SetDimensions;

		public nint GetTensorElementType;

		public nint GetDimensionsCount;

		public nint GetDimensions;

		public nint GetSymbolicDimensions;

		public nint GetTensorShapeElementCount;

		public nint GetTensorTypeAndShape;

		public nint GetTypeInfo;

		public nint GetValueType;

		public nint CreateMemoryInfo;

		public nint CreateCpuMemoryInfo;

		public nint CompareMemoryInfo;

		public nint MemoryInfoGetName;

		public nint MemoryInfoGetId;

		public nint MemoryInfoGetMemType;

		public nint MemoryInfoGetType;

		public nint AllocatorAlloc;

		public nint AllocatorFree;

		public nint AllocatorGetInfo;

		public nint GetAllocatorWithDefaultOptions;

		public nint AddFreeDimensionOverride;

		public nint GetValue;

		public nint GetValueCount;

		public nint CreateValue;

		public nint CreateOpaqueValue;

		public nint GetOpaqueValue;

		public nint KernelInfoGetAttribute_float;

		public nint KernelInfoGetAttribute_int64;

		public nint KernelInfoGetAttribute_string;

		public nint KernelContext_GetInputCount;

		public nint KernelContext_GetOutputCount;

		public nint KernelContext_GetInput;

		public nint KernelContext_GetOutput;

		public nint ReleaseEnv;

		public nint ReleaseStatus;

		public nint ReleaseMemoryInfo;

		public nint ReleaseSession;

		public nint ReleaseValue;

		public nint ReleaseRunOptions;

		public nint ReleaseTypeInfo;

		public nint ReleaseTensorTypeAndShapeInfo;

		public nint ReleaseSessionOptions;

		public nint ReleaseCustomOpDomain;

		public nint GetDenotationFromTypeInfo;

		public nint CastTypeInfoToMapTypeInfo;

		public nint CastTypeInfoToSequenceTypeInfo;

		public nint GetMapKeyType;

		public nint GetMapValueType;

		public nint GetSequenceElementType;

		public nint ReleaseMapTypeInfo;

		public nint ReleaseSequenceTypeInfo;

		public nint SessionEndProfiling;

		public nint SessionGetModelMetadata;

		public nint ModelMetadataGetProducerName;

		public nint ModelMetadataGetGraphName;

		public nint ModelMetadataGetDomain;

		public nint ModelMetadataGetDescription;

		public nint ModelMetadataLookupCustomMetadataMap;

		public nint ModelMetadataGetVersion;

		public nint ReleaseModelMetadata;

		public nint CreateEnvWithGlobalThreadPools;

		public nint DisablePerSessionThreads;

		public nint CreateThreadingOptions;

		public nint ReleaseThreadingOptions;

		public nint ModelMetadataGetCustomMetadataMapKeys;

		public nint AddFreeDimensionOverrideByName;

		public nint GetAvailableProviders;

		public nint ReleaseAvailableProviders;

		public nint GetStringTensorElementLength;

		public nint GetStringTensorElement;

		public nint FillStringTensorElement;

		public nint AddSessionConfigEntry;

		public nint CreateAllocator;

		public nint ReleaseAllocator;

		public nint RunWithBinding;

		public nint CreateIoBinding;

		public nint ReleaseIoBinding;

		public nint BindInput;

		public nint BindOutput;

		public nint BindOutputToDevice;

		public nint GetBoundOutputNames;

		public nint GetBoundOutputValues;

		public nint ClearBoundInputs;

		public nint ClearBoundOutputs;

		public nint TensorAt;

		public nint CreateAndRegisterAllocator;

		public nint SetLanguageProjection;

		public nint SessionGetProfilingStartTimeNs;

		public nint SetGlobalIntraOpNumThreads;

		public nint SetGlobalInterOpNumThreads;

		public nint SetGlobalSpinControl;

		public nint AddInitializer;

		public nint CreateEnvWithCustomLoggerAndGlobalThreadPools;

		public nint SessionOptionsAppendExecutionProvider_CUDA;

		public nint SessionOptionsAppendExecutionProvider_ROCM;

		public nint SessionOptionsAppendExecutionProvider_OpenVINO;

		public nint SetGlobalDenormalAsZero;

		public nint CreateArenaCfg;

		public nint ReleaseArenaCfg;

		public nint ModelMetadataGetGraphDescription;

		public nint SessionOptionsAppendExecutionProvider_TensorRT;

		public nint SetCurrentGpuDeviceId;

		public nint GetCurrentGpuDeviceId;

		public nint KernelInfoGetAttributeArray_float;

		public nint KernelInfoGetAttributeArray_int64;

		public nint CreateArenaCfgV2;

		public nint AddRunConfigEntry;

		public nint CreatePrepackedWeightsContainer;

		public nint ReleasePrepackedWeightsContainer;

		public nint CreateSessionWithPrepackedWeightsContainer;

		public nint CreateSessionFromArrayWithPrepackedWeightsContainer;

		public nint SessionOptionsAppendExecutionProvider_TensorRT_V2;

		public nint CreateTensorRTProviderOptions;

		public nint UpdateTensorRTProviderOptions;

		public nint GetTensorRTProviderOptionsAsString;

		public nint ReleaseTensorRTProviderOptions;

		public nint EnableOrtCustomOps;

		public nint RegisterAllocator;

		public nint UnregisterAllocator;

		public nint IsSparseTensor;

		public nint CreateSparseTensorAsOrtValue;

		public nint FillSparseTensorCoo;

		public nint FillSparseTensorCsr;

		public nint FillSparseTensorBlockSparse;

		public nint CreateSparseTensorWithValuesAsOrtValue;

		public nint UseCooIndices;

		public nint UseCsrIndices;

		public nint UseBlockSparseIndices;

		public nint GetSparseTensorFormat;

		public nint GetSparseTensorValuesTypeAndShape;

		public nint GetSparseTensorValues;

		public nint GetSparseTensorIndicesTypeShape;

		public nint GetSparseTensorIndices;

		public nint HasValue;

		public nint KernelContext_GetGPUComputeStream;

		public nint GetTensorMemoryInfo;

		public nint GetExecutionProviderApi;

		public nint SessionOptionsSetCustomCreateThreadFn;

		public nint SessionOptionsSetCustomThreadCreationOptions;

		public nint SessionOptionsSetCustomJoinThreadFn;

		public nint SetGlobalCustomCreateThreadFn;

		public nint SetGlobalCustomThreadCreationOptions;

		public nint SetGlobalCustomJoinThreadFn;

		public nint SynchronizeBoundInputs;

		public nint SynchronizeBoundOutputs;

		public nint SessionOptionsAppendExecutionProvider_CUDA_V2;

		public nint CreateCUDAProviderOptions;

		public nint UpdateCUDAProviderOptions;

		public nint GetCUDAProviderOptionsAsString;

		public nint ReleaseCUDAProviderOptions;

		public nint SessionOptionsAppendExecutionProvider_MIGraphX;

		public nint AddExternalInitializers;

		public nint CreateOpAttr;

		public nint ReleaseOpAttr;

		public nint CreateOp;

		public nint InvokeOp;

		public nint ReleaseOp;

		public nint SessionOptionsAppendExecutionProvider;

		public nint CopyKernelInfo;

		public nint ReleaseKernelInfo;

		public nint GetTrainingApi;

		public nint SessionOptionsAppendExecutionProvider_CANN;

		public nint CreateCANNProviderOptions;

		public nint UpdateCANNProviderOptions;

		public nint GetCANNProviderOptionsAsString;

		public nint ReleaseCANNProviderOptions;

		public nint MemoryInfoGetDeviceType;

		public nint UpdateEnvWithCustomLogLevel;

		public nint SetGlobalIntraOpThreadAffinity;

		public nint RegisterCustomOpsLibrary_V2;

		public nint RegisterCustomOpsUsingFunction;

		public nint KernelInfo_GetInputCount;

		public nint KernelInfo_GetOutputCount;

		public nint KernelInfo_GetInputName;

		public nint KernelInfo_GetOutputName;

		public nint KernelInfo_GetInputTypeInfo;

		public nint KernelInfo_GetOutputTypeInfo;

		public nint KernelInfoGetAttribute_tensor;

		public nint HasSessionConfigEntry;

		public nint GetSessionConfigEntry;

		public nint SessionOptionsAppendExecutionProvider_Dnnl;

		public nint CreateDnnlProviderOptions;

		public nint UpdateDnnlProviderOptions;

		public nint GetDnnlProviderOptionsAsString;

		public nint ReleaseDnnlProviderOptions;

		public nint KernelInfo_GetNodeName;

		public nint KernelInfo_GetLogger;

		public nint KernelContext_GetLogger;

		public nint Logger_LogMessage;

		public nint Logger_GetLoggingSeverityLevel;

		public nint KernelInfoGetConstantInput_tensor;

		public nint CastTypeInfoToOptionalTypeInfo;

		public nint GetOptionalContainedTypeInfo;

		public nint GetResizedStringTensorElementBuffer;

		public nint KernelContext_GetAllocator;

		public nint GetBuildInfoString;

		public nint CreateROCMProviderOptions;

		public nint UpdateROCMProviderOptions;

		public nint GetROCMProviderOptionsAsString;

		public nint ReleaseROCMProviderOptions;

		public nint CreateAndRegisterAllocatorV2;

		public nint RunAsync;

		public nint UpdateTensorRTProviderOptionsWithValue;

		public nint GetTensorRTProviderOptionsByName;

		public nint UpdateCUDAProviderOptionsWithValue;

		public nint GetCUDAProviderOptionsByName;

		public nint KernelContext_GetResource;

		public nint SetUserLoggingFunction;

		public nint ShapeInferContext_GetInputCount;

		public nint ShapeInferContext_GetInputTypeShape;

		public nint ShapeInferContext_GetAttribute;

		public nint ShapeInferContext_SetOutputTypeShape;

		public nint SetSymbolicDimensions;

		public nint ReadOpAttr;

		public nint SetDeterministicCompute;

		public nint KernelContext_ParallelFor;

		public nint SessionOptionsAppendExecutionProvider_OpenVINO_V2;

		public nint SessionOptionsAppendExecutionProvider_VitisAI;

		public nint KernelContext_GetScratchBuffer;

		public nint KernelInfoGetAllocator;

		public nint AddExternalInitializersFromFilesInMemory;

		public nint CreateLoraAdapter;

		public nint CreateLoraAdapterFromArray;

		public nint ReleaseLoraAdapter;

		public nint RunOptionsAddActiveLoraAdapter;

		public nint SetEpDynamicOptions;

		public nint ReleaseValueInfo;

		public nint ReleaseNode;

		public nint ReleaseGraph;

		public nint ReleaseModel;

		public nint GetValueInfoName;

		public nint GetValueInfoTypeInfo;

		public nint GetModelEditorApi;

		public nint CreateTensorWithDataAndDeleterAsOrtValue;

		public nint SessionOptionsSetLoadCancellationFlag;

		public nint GetCompileApi;

		public nint CreateKeyValuePairs;

		public nint AddKeyValuePair;

		public nint GetKeyValue;

		public nint GetKeyValuePairs;

		public nint RemoveKeyValuePair;

		public nint ReleaseKeyValuePairs;

		public nint RegisterExecutionProviderLibrary;

		public nint UnregisterExecutionProviderLibrary;

		public nint GetEpDevices;

		public nint SessionOptionsAppendExecutionProvider_V2;

		public nint SessionOptionsSetEpSelectionPolicy;

		public nint SessionOptionsSetEpSelectionPolicyDelegate;

		public nint HardwareDevice_Type;

		public nint HardwareDevice_VendorId;

		public nint HardwareDevice_Vendor;

		public nint HardwareDevice_DeviceId;

		public nint HardwareDevice_Metadata;

		public nint EpDevice_EpName;

		public nint EpDevice_EpVendor;

		public nint EpDevice_EpMetadata;

		public nint EpDevice_EpOptions;

		public nint EpDevice_Device;

		public nint GetEpApi;

		public nint GetTensorSizeInBytes;

		public nint AllocatorGetStats;

		public nint CreateMemoryInfo_V2;

		public nint MemoryInfoGetDeviceMemType;

		public nint MemoryInfoGetVendorId;

		public nint ValueInfo_GetValueProducer;

		public nint ValueInfo_GetValueNumConsumers;

		public nint ValueInfo_GetValueConsumers;

		public nint ValueInfo_GetInitializerValue;

		public nint ValueInfo_GetExternalInitializerInfo;

		public nint ValueInfo_IsRequiredGraphInput;

		public nint ValueInfo_IsOptionalGraphInput;

		public nint ValueInfo_IsGraphOutput;

		public nint ValueInfo_IsConstantInitializer;

		public nint ValueInfo_IsFromOuterScope;

		public nint Graph_GetName;

		public nint Graph_GetModelPath;

		public nint Graph_GetOnnxIRVersion;

		public nint Graph_GetNumOperatorSets;

		public nint Graph_GetOperatorSets;

		public nint Graph_GetNumInputs;

		public nint Graph_GetInputs;

		public nint Graph_GetNumOutputs;

		public nint Graph_GetOutputs;

		public nint Graph_GetNumInitializers;

		public nint Graph_GetInitializers;

		public nint Graph_GetNumNodes;

		public nint Graph_GetNodes;

		public nint Graph_GetParentNode;

		public nint Graph_GetGraphView;

		public nint Node_GetId;

		public nint Node_GetName;

		public nint Node_GetOperatorType;

		public nint Node_GetDomain;

		public nint Node_GetSinceVersion;

		public nint Node_GetNumInputs;

		public nint Node_GetInputs;

		public nint Node_GetNumOutputs;

		public nint Node_GetOutputs;

		public nint Node_GetNumImplicitInputs;

		public nint Node_GetImplicitInputs;

		public nint Node_GetNumAttributes;

		public nint Node_GetAttributes;

		public nint Node_GetAttributeByName;

		public nint Node_GetTensorAttributeAsOrtValue;

		public nint OpAttr_GetType;

		public nint OpAttr_GetName;

		public nint Node_GetNumSubgraphs;

		public nint Node_GetSubgraphs;

		public nint Node_GetGraph;

		public nint Node_GetEpName;

		public nint ReleaseExternalInitializerInfo;

		public nint ExternalInitializerInfo_GetFilePath;

		public nint ExternalInitializerInfo_GetFileOffset;

		public nint ExternalInitializerInfo_GetByteSize;

		public nint GetRunConfigEntry;

		public nint EpDevice_MemoryInfo;

		public nint CreateSharedAllocator;

		public nint GetSharedAllocator;

		public nint ReleaseSharedAllocator;

		public nint GetTensorData;

		public nint GetSessionOptionsConfigEntries;

		public nint SessionGetMemoryInfoForInputs;

		public nint SessionGetMemoryInfoForOutputs;

		public nint SessionGetEpDeviceForInputs;

		public nint CreateSyncStreamForEpDevice;

		public nint SyncStream_GetHandle;

		public nint ReleaseSyncStream;

		public nint CopyTensors;

		public nint Graph_GetModelMetadata;

		public nint GetModelCompatibilityForEpDevices;

		public nint CreateExternalInitializerInfo;

		public nint TensorTypeAndShape_HasShape;

		public nint KernelInfo_GetConfigEntries;

		public nint KernelInfo_GetOperatorDomain;

		public nint KernelInfo_GetOperatorType;

		public nint KernelInfo_GetOperatorSinceVersion;

		public nint GetInteropApi;

		public nint SessionGetEpDeviceForOutputs;

		public nint GetNumHardwareDevices;

		public nint GetHardwareDevices;

		public nint GetHardwareDeviceEpIncompatibilityDetails;

		public nint DeviceEpIncompatibilityDetails_GetReasonsBitmask;

		public nint DeviceEpIncompatibilityDetails_GetNotes;

		public nint DeviceEpIncompatibilityDetails_GetErrorCode;

		public nint ReleaseDeviceEpIncompatibilityDetails;

		public nint GetCompatibilityInfoFromModel;

		public nint GetCompatibilityInfoFromModelBytes;

		public nint CreateEnvWithOptions;

		public nint Session_GetEpGraphAssignmentInfo;

		public nint EpAssignedSubgraph_GetEpName;

		public nint EpAssignedSubgraph_GetNodes;

		public nint EpAssignedNode_GetName;

		public nint EpAssignedNode_GetDomain;

		public nint EpAssignedNode_GetOperatorType;

		public nint RunOptionsSetSyncStream;

		public nint GetTensorElementTypeAndShapeDataReference;

		public nint RunOptionsEnableProfiling;

		public nint RunOptionsDisableProfiling;
	}
	internal static class NativeMethods
	{
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate ref OrtApi DOrtGetApi(uint version);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetVersionString();

		internal class NativeLib
		{
			internal const string DllName = "onnxruntime";
		}

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateEnv(OrtLoggingLevel defaultLoggingLevel, byte[] logId, out nint env);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateEnvWithCustomLogger(nint loggingFunction, nint loggerParam, OrtLoggingLevel defaultLoggingLevel, byte[] logId, out nint env);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateEnvWithGlobalThreadPools(OrtLoggingLevel defaultWarningLevel, byte[] logId, nint threadingOptions, out nint env);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateEnvWithCustomLoggerAndGlobalThreadPools(nint loggingFunction, nint loggerParam, OrtLoggingLevel logSeverityLevel, byte[] logId, nint threadingOptions, out nint env);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseEnv(nint env);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEnableTelemetryEvents(nint env);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDisableTelemetryEvents(nint env);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtUpdateEnvWithCustomLogLevel(nint env, OrtLoggingLevel custom_log_level);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DCreateAndRegisterAllocatorV2(nint environment, nint provderType, nint memInfo, nint arenaCfg, nint[] providerOptionsKeys, nint[] providerOptionsValues, nuint numKeys);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateSharedAllocator(nint ortEnv, nint epDevice, OrtDeviceMemoryType deviceMemoryType, OrtAllocatorType allocatorType, nint allocatorOptions, out nint allocator);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetSharedAllocator(nint env, nint memInfo, out nint allocator);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtReleaseSharedAllocator(nint env, nint epDevice, OrtDeviceMemoryType deviceMemoryType);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCopyTensors(nint env, nint[] srcTensors, nint[] dstTensors, nint stream, nuint numTensors);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateTensorRTProviderOptions(out nint trtProviderOptionsInstance);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtUpdateTensorRTProviderOptions(nint trtProviderOptionsInstance, nint[] providerOptionsKeys, nint[] providerOptionsValues, nuint numKeys);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTensorRTProviderOptionsAsString(nint trtProviderOptionsInstance, nint allocator, out nint ptr);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseTensorRTProviderOptions(nint trtProviderOptionsInstance);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateCUDAProviderOptions(out nint cudaProviderOptionsInstance);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtUpdateCUDAProviderOptions(nint cudaProviderOptionsInstance, nint[] providerOptionsKeys, nint[] providerOptionsValues, nuint numKeys);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetCUDAProviderOptionsAsString(nint cudaProviderOptionsInstance, nint allocator, out nint ptr);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseCUDAProviderOptions(nint cudaProviderOptionsInstance);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateROCMProviderOptions(out nint rocmProviderOptionsInstance);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtUpdateROCMProviderOptions(nint rocmProviderOptionsInstance, nint[] providerOptionsKeys, nint[] providerOptionsValues, nuint numKeys);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetROCMProviderOptionsAsString(nint rocmProviderOptionsInstance, nint allocator, out nint ptr);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseROCMProviderOptions(nint rocmProviderOptionsInstance);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate ErrorCode DOrtGetErrorCode(nint status);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetErrorMessage(nint status);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseStatus(nint statusPtr);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateStatus(uint code, byte[] msg);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateSession(nint environment, byte[] modelPath, nint sessionOptions, out nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateSessionWithPrepackedWeightsContainer(nint environment, byte[] modelPath, nint sessionOptions, nint prepackedWeightsContainer, out nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateSessionFromArray(nint environment, byte[] modelData, nuint modelSize, nint sessionOptions, out nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateSessionFromArrayWithPrepackedWeightsContainer(nint environment, byte[] modelData, nuint modelSize, nint sessionOptions, nint prepackedWeightsContainer, out nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRun(nint session, nint runOptions, nint[] inputNames, nint[] inputValues, nuint inputCount, nint[] outputNames, nuint outputCount, nint[] outputValues);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunWithBinding(nint session, nint runOptions, nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetInputCount(nint session, out nuint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetOutputCount(nint session, out nuint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetOverridableInitializerCount(nint session, out nuint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetInputName(nint session, nuint index, nint allocator, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetOutputName(nint session, nuint index, nint allocator, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionEndProfiling(nint session, nint allocator, out nint profile_file);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetOverridableInitializerName(nint session, nuint index, nint allocator, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetInputTypeInfo(nint session, nuint index, out nint typeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetOutputTypeInfo(nint session, nuint index, out nint typeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetOverridableInitializerTypeInfo(nint session, nuint index, out nint typeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetMemoryInfoForInputs(nint session, nint[] inputsMemoryInfos, nuint numInputs);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetMemoryInfoForOutputs(nint session, nint[] outputsMemoryInfos, nuint numOutputs);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetEpDeviceForInputs(nint session, nint[] devices, nuint numInputs);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseTypeInfo(nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseSession(nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetProfilingStartTimeNs(nint session, out nuint startTime);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunAsync(nint session, nint runOptions, nint[] inputNames, nint[] inputValues, nuint inputCount, nint[] outputNames, nuint outputCount, nint[] outputValues, nint callback, nint user_data);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateSessionOptions(out nint sessionOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseSessionOptions(nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCloneSessionOptions(nint sessionOptions, out nint output);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetSessionExecutionMode(nint options, ExecutionMode execution_mode);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionOptionsSetLoadCancellationFlag(nint options, bool value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetOptimizedModelFilePath(nint options, byte[] optimizedModelFilepath);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEnableProfiling(nint options, byte[] profilePathPrefix);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDisableProfiling(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEnableMemPattern(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDisableMemPattern(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEnableCpuMemArena(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDisableCpuMemArena(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDisablePerSessionThreads(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetSessionLogId(nint options, byte[] logId);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetSessionLogVerbosityLevel(nint options, int sessionLogVerbosityLevel);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetSessionLogSeverityLevel(nint options, OrtLoggingLevel sessionLogSeverityLevel);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetIntraOpNumThreads(nint options, int intraOpNumThreads);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetInterOpNumThreads(nint options, int interOpNumThreads);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetSessionGraphOptimizationLevel(nint options, GraphOptimizationLevel graphOptimizationLevel);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAddSessionConfigEntry(nint options, byte[] configKey, byte[] configValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsAppendExecutionProvider_TensorRT(nint options, nint trtProviderOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsAppendExecutionProvider_TensorRT_V2(nint options, nint trtProviderOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsAppendExecutionProvider_CUDA(nint options, nint cudaProviderOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsAppendExecutionProvider_CUDA_V2(nint options, nint cudaProviderOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsAppendExecutionProvider_ROCM(nint options, nint rocmProviderOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAddFreeDimensionOverride(nint options, byte[] dimDenotation, long dimValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAddFreeDimensionOverrideByName(nint options, byte[] dimName, long dimValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRegisterCustomOpsLibrary(nint options, byte[] libraryPath, out nint libraryHandle);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRegisterCustomOpsLibrary_V2(nint options, byte[] libraryPath);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAddInitializer(nint options, byte[] name, nint ortValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsAppendExecutionProvider(nint options, byte[] providerName, nint[] providerOptionsKeys, nint[] providerOptionsValues, nuint numKeys);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateLoraAdapter(byte[] adapter_path, nint allocator, out nint lora_adapter);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateLoraAdapterFromArray(byte[] bytes, nuint size, nint allocator, out nint lora_adapter);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseLoraAdapter(nint lora_adapter);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateRunOptions(out nint runOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseRunOptions(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsSetRunLogVerbosityLevel(nint options, int value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsSetRunLogSeverityLevel(nint options, OrtLoggingLevel value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsSetRunTag(nint options, byte[] runTag);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsGetRunLogVerbosityLevel(nint options, out int verbosityLevel);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsGetRunLogSeverityLevel(nint options, out OrtLoggingLevel severityLevel);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsGetRunTag(nint options, out nint runtag);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsSetTerminate(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsUnsetTerminate(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRunOptionsAddActiveLoraAdapter(nint options, nint lora_adapter);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAddRunConfigEntry(nint options, byte[] configKey, byte[] configValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateThreadingOptions(out nint threadingOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtReleaseThreadingOptions(nint threadingOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtThreadingOptionsSetGlobalInterOpNumThreads(nint threadingOptions, int numThreads);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtThreadingOptionsSetGlobalIntraOpNumThreads(nint threadingOptions, int numThreads);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtThreadingOptionsSetGlobalDenormalAsZero(nint threadingOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtThreadingOptionsSetGlobalSpinControl(nint threadingOptions, int allowSpinning);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateMemoryInfo(byte[] name, OrtAllocatorType allocatorType, int identifier, OrtMemType memType, out nint allocatorInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateMemoryInfoV2(byte[] name, OrtMemoryInfoDeviceType memInfoDeviceType, uint vendorId, int deviceId, OrtDeviceMemoryType deviceMemoryType, nuint alignment, OrtAllocatorType allocatorType, out nint allocatorInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateCpuMemoryInfo(OrtAllocatorType allocatorType, OrtMemType memoryType, out nint allocatorInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseMemoryInfo(nint allocatorInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCompareMemoryInfo(nint info1, nint info2, out int result);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtMemoryInfoGetName(nint mem_info, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtMemoryInfoGetId(nint mem_info, out int id);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtMemoryInfoGetMemType(nint mem_info, out OrtMemType mem_type);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtMemoryInfoGetType(nint mem_info, out OrtAllocatorType alloc_type);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate OrtDeviceMemoryType DOrtMemoryInfoGetDeviceMemType(nint memoryInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate uint DOrtMemoryInfoGetVendorId(nint memoryInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetAllocatorWithDefaultOptions(out nint allocator);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAllocatorGetInfo(nint ptr, out nint info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateArenaCfg(nuint maxMemory, int arenaExtendStrategy, int initialChunkSizeBytes, int maxDeadBytesPerChunk, out nint arenaCfg);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseArenaCfg(nint arenaCfg);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateAllocator(nint session, nint info, out nint allocator);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseAllocator(nint allocator);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAllocatorAlloc(nint allocator, nuint size, out nint p);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAllocatorFree(nint allocator, nint p);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateIoBinding(nint session, out nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseIoBinding(nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtBindInput(nint io_binding, byte[] name, nint ort_value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSynchronizeBoundInputs(nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtBindOutput(nint io_binding, byte[] name, nint ort_value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtBindOutputToDevice(nint io_binding, byte[] name, nint mem_info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSynchronizeBoundOutputs(nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetBoundOutputNames(nint io_binding, nint allocator, out nint buffer, out nint lengths, out nuint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetBoundOutputValues(nint io_binding, nint allocator, out nint ortvalues, out nuint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtClearBoundInputs(nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtClearBoundOutputs(nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtTensorAt(nint io_binding);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateAndRegisterAllocator(nint env, nint memInfo, nint arenaCfg);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtUnregisterAllocator(nint env, nint memInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetLanguageProjection(nint environment, int projection);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionGetModelMetadata(nint session, out nint modelMetadata);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataGetProducerName(nint modelMetadata, nint allocator, out nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataGetGraphName(nint modelMetadata, nint allocator, out nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataGetDomain(nint modelMetadata, nint allocator, out nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataGetDescription(nint modelMetadata, nint allocator, out nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataGetGraphDescription(nint modelMetadata, nint allocator, out nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataGetVersion(nint modelMetadata, out long value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataGetCustomMetadataMapKeys(nint modelMetadata, nint allocator, out nint keys, out long numKeys);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelMetadataLookupCustomMetadataMap(nint modelMetadata, nint allocator, nint key, out nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseModelMetadata(nint modelMetadata);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtHasValue(nint value, out nint hasValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetValue(nint value, int index, nint allocator, out nint outputValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetValueType(nint value, out nint onnxtype);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetOnnxTypeFromTypeInfo(nint typeinfo, out nint onnxtype);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetValueCount(nint value, out nint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateValue(nint[] values, nuint num_values, nint onnxValueType, out nint ortValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTypeInfo(nint value, out nint typeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateTensorAsOrtValue(nint allocator, long[] shape, nuint shape_len, TensorElementType type, out nint outputValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateTensorWithDataAsOrtValue(nint allocatorInfo, nint dataBufferHandle, nuint dataLength, long[] shape, nuint shapeLength, TensorElementType type, out nint outputValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtValueIsTensor(nint ortValue, out nint val);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtValueIsSparseTensor(nint ortValue, out nint val);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTensorMutableData(nint value, out nint dataBufferHandle);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTensorSizeInBytes(nint ortValue, out nuint tensorSizeInBytes);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtFillStringTensor(nint value, nint[] s, nuint s_len);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetResizedStringTensorElementBuffer(nint value, nuint index, nuint length_in_bytes, out nint buffer);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetStringTensorContent(nint value, byte[] dst_buffer, nuint dst_buffer_len, nuint[] offsets, nuint offsets_len);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetStringTensorDataLength(nint value, out nuint len);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetStringTensorElementLength(nint value, nuint index, out nuint len);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetStringTensorElement(nint value, nuint bufferLength, nuint elementIndex, byte[] buffer);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCastTypeInfoToTensorInfo(nint typeInfo, out nint typeAndShapeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTensorTypeAndShape(nint value, out nint typeAndShapeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseTensorTypeAndShapeInfo(nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTensorElementType(nint typeAndShapeInfo, out nint output);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetDimensionsCount(nint typeAndShapeInfo, out nuint output);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetDimensions(nint typeAndShapeInfo, long[] dim_values, nuint dim_values_length);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetSymbolicDimensions(nint typeAndShapeInfo, nint[] dim_params, nuint dim_params_length);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTensorShapeElementCount(nint typeAndShapeInfo, out nuint output);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTensorMemoryInfo(nint ortValue, out nint ortMemoryInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DCastTypeInfoToMapTypeInfo(nint typeInfo, out nint mapTypeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DGetMapKeyType(nint mapTypeInfo, out nint tensorElementType);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DGetMapValueType(nint map_type_info, out nint type_info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DCastTypeInfoToSequenceTypeInfo(nint typeInfo, out nint sequenceTypeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DGetSequenceElementType(nint sequenceTypeInfo, out nint elementTypeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCastTypeInfoToOptionalTypeInfo(nint typeInfo, out nint optionalTypeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DGetOptionalContainedTypeInfo(nint optTypeInfo, out nint containedTypeInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseValue(nint value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate ref OrtCompileApi DOrtGetCompileApi();

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtWriteBufferToDestinationDelegate(nint state, nint buffer, nuint bufferNumBytes);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetInitializerLocationDelegate(nint state, nint initializerName, nint initializerValue, nint externalInfo, out nint newExternalInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseExternalInitializerInfo(nint info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateExternalInitializerInfo(byte[] filePath, long fileOffset, nuint byteSize, out nint outInfo);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtExternalInitializerInfo_GetFilePath(nint info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate long DOrtExternalInitializerInfo_GetFileOffset(nint info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nuint DOrtExternalInitializerInfo_GetByteSize(nint info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetNumHardwareDevices(nint env, out nuint numDevices);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetHardwareDevices(nint env, [Out] nint[] devices, nuint numDevices);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetHardwareDeviceEpIncompatibilityDetails(nint env, byte[] epName, nint hw, out nint details);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDeviceEpIncompatibilityDetails_GetReasonsBitmask(nint details, out uint reasonsBitmask);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDeviceEpIncompatibilityDetails_GetNotes(nint details, out nint notes);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtDeviceEpIncompatibilityDetails_GetErrorCode(nint details, out int errorCode);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseDeviceEpIncompatibilityDetails(nint details);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtCreateKeyValuePairs(out nint kvps);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtAddKeyValuePair(nint kvps, byte[] key, byte[] value);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetKeyValue(nint kvps, byte[] key);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtGetKeyValuePairs(nint kvps, out nint keys, out nint values, out nuint numEntries);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtRemoveKeyValuePair(nint kvps, byte[] key);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseKeyValuePairs(nint kvps);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate int DOrtHardwareDevice_Type(nint device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate uint DOrtHardwareDevice_VendorId(nint device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtHardwareDevice_Vendor(nint device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate uint DOrtHardwareDevice_DeviceId(nint device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtHardwareDevice_Metadata(nint device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEpDevice_EpName(nint ep_device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEpDevice_EpVendor(nint ep_device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEpDevice_EpMetadata(nint ep_device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEpDevice_EpOptions(nint ep_device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEpDevice_Device(nint ep_device);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEpDevice_MemoryInfo(nint ep_device, OrtDeviceMemoryType deviceMemoryType);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateSyncStreamForEpDevice(nint epDevice, nint streamOptions, out nint stream);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSyncStream_GetHandle(nint stream);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtReleaseSyncStream(nint stream);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRegisterExecutionProviderLibrary(nint env, byte[] registration_name, byte[] path);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtUnregisterExecutionProviderLibrary(nint env, byte[] registration_name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetEpDevices(nint env, out nint ep_devices, out nuint num_ep_devices);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetModelCompatibilityForEpDevices(nint[] ep_devices, nuint num_ep_devices, byte[] compatibility_info, out int out_status);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSessionOptionsAppendExecutionProvider_V2(nint sess_options, nint env, nint[] ep_devices, nuint num_ep_devices, nint ep_option_keys, nint ep_option_vals, nuint num_ep_options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEpSelectionDelegate(nint epDevices, uint numDevices, nint modelMetadata, nint runtimeMetadata, nint selected, uint maxSelected, out nuint numSelected, nint state);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsSetEpSelectionPolicy(nint session_options, int policy);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DSessionOptionsSetEpSelectionPolicyDelegate(nint session_options, nint selection_delegate, nint state);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetAvailableProviders(out nint providers, out int numProviders);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtReleaseAvailableProviders(nint providers, int numProviders);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreatePrepackedWeightsContainer(out nint prepackedWeightsContainer);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleasePrepackedWeightsContainer(nint prepackedWeightsContainer);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetCompatibilityInfoFromModel(byte[] model_path, byte[] ep_type, nint allocator, out nint compatibility_info);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetCompatibilityInfoFromModelBytes(byte[] model_data, nuint model_data_length, byte[] ep_type, nint allocator, out nint compatibility_info);

		private static OrtApi api_;

		internal static Microsoft.ML.OnnxRuntime.CompileApi.NativeMethods CompileApi;

		public static DOrtGetVersionString OrtGetVersionString;

		public static DOrtCreateEnv OrtCreateEnv;

		public static DOrtCreateEnvWithCustomLogger OrtCreateEnvWithCustomLogger;

		public static DOrtCreateEnvWithGlobalThreadPools OrtCreateEnvWithGlobalThreadPools;

		public static DOrtCreateEnvWithCustomLoggerAndGlobalThreadPools OrtCreateEnvWithCustomLoggerAndGlobalThreadPools;

		public static DOrtReleaseEnv OrtReleaseEnv;

		public static DOrtEnableTelemetryEvents OrtEnableTelemetryEvents;

		public static DOrtDisableTelemetryEvents OrtDisableTelemetryEvents;

		public static DOrtUpdateEnvWithCustomLogLevel OrtUpdateEnvWithCustomLogLevel;

		public static DCreateAndRegisterAllocatorV2 OrtCreateAndRegisterAllocatorV2;

		public static DOrtCreateSharedAllocator OrtCreateSharedAllocator;

		public static DOrtGetSharedAllocator OrtGetSharedAllocator;

		public static DOrtReleaseSharedAllocator OrtReleaseSharedAllocator;

		public static DOrtCopyTensors OrtCopyTensors;

		public static DOrtCreateTensorRTProviderOptions OrtCreateTensorRTProviderOptions;

		public static DOrtUpdateTensorRTProviderOptions OrtUpdateTensorRTProviderOptions;

		public static DOrtGetTensorRTProviderOptionsAsString OrtGetTensorRTProviderOptionsAsString;

		public static DOrtReleaseTensorRTProviderOptions OrtReleaseTensorRTProviderOptions;

		public static DOrtCreateCUDAProviderOptions OrtCreateCUDAProviderOptions;

		public static DOrtUpdateCUDAProviderOptions OrtUpdateCUDAProviderOptions;

		public static DOrtGetCUDAProviderOptionsAsString OrtGetCUDAProviderOptionsAsString;

		public static DOrtReleaseCUDAProviderOptions OrtReleaseCUDAProviderOptions;

		public static DOrtCreateROCMProviderOptions OrtCreateROCMProviderOptions;

		public static DOrtUpdateROCMProviderOptions OrtUpdateROCMProviderOptions;

		public static DOrtGetROCMProviderOptionsAsString OrtGetROCMProviderOptionsAsString;

		public static DOrtReleaseROCMProviderOptions OrtReleaseROCMProviderOptions;

		public static DOrtGetErrorCode OrtGetErrorCode;

		public static DOrtGetErrorMessage OrtGetErrorMessage;

		public static DOrtReleaseStatus OrtReleaseStatus;

		public static DOrtCreateStatus OrtCreateStatus;

		public static DOrtCreateSession OrtCreateSession;

		public static DOrtCreateSessionWithPrepackedWeightsContainer OrtCreateSessionWithPrepackedWeightsContainer;

		public static DOrtCreateSessionFromArray OrtCreateSessionFromArray;

		public static DOrtCreateSessionFromArrayWithPrepackedWeightsContainer OrtCreateSessionFromArrayWithPrepackedWeightsContainer;

		public static DOrtRun OrtRun;

		public static DOrtRunWithBinding OrtRunWithBinding;

		public static DOrtSessionGetInputCount OrtSessionGetInputCount;

		public static DOrtSessionGetOutputCount OrtSessionGetOutputCount;

		public static DOrtSessionGetOverridableInitializerCount OrtSessionGetOverridableInitializerCount;

		public static DOrtSessionGetInputName OrtSessionGetInputName;

		public static DOrtSessionGetOutputName OrtSessionGetOutputName;

		public static DOrtSessionEndProfiling OrtSessionEndProfiling;

		public static DOrtSessionGetOverridableInitializerName OrtSessionGetOverridableInitializerName;

		public static DOrtSessionGetInputTypeInfo OrtSessionGetInputTypeInfo;

		public static DOrtSessionGetOutputTypeInfo OrtSessionGetOutputTypeInfo;

		public static DOrtSessionGetOverridableInitializerTypeInfo OrtSessionGetOverridableInitializerTypeInfo;

		public static DOrtSessionGetMemoryInfoForInputs OrtSessionGetMemoryInfoForInputs;

		public static DOrtSessionGetMemoryInfoForOutputs OrtSessionGetMemoryInfoForOutputs;

		public static DOrtSessionGetEpDeviceForInputs OrtSessionGetEpDeviceForInputs;

		public static DOrtReleaseTypeInfo OrtReleaseTypeInfo;

		public static DOrtReleaseSession OrtReleaseSession;

		public static DOrtSessionGetProfilingStartTimeNs OrtSessionGetProfilingStartTimeNs;

		public static DOrtRunAsync OrtRunAsync;

		public static DOrtCreateSessionOptions OrtCreateSessionOptions;

		public static DOrtReleaseSessionOptions OrtReleaseSessionOptions;

		public static DOrtCloneSessionOptions OrtCloneSessionOptions;

		public static DOrtSetSessionExecutionMode OrtSetSessionExecutionMode;

		public static DOrtSessionOptionsSetLoadCancellationFlag OrtSessionOptionsSetLoadCancellationFlag;

		public static DOrtSetOptimizedModelFilePath OrtSetOptimizedModelFilePath;

		public static DOrtEnableProfiling OrtEnableProfiling;

		public static DOrtDisableProfiling OrtDisableProfiling;

		public static DOrtEnableMemPattern OrtEnableMemPattern;

		public static DOrtDisableMemPattern OrtDisableMemPattern;

		public static DOrtEnableCpuMemArena OrtEnableCpuMemArena;

		public static DOrtDisableCpuMemArena OrtDisableCpuMemArena;

		public static DOrtDisablePerSessionThreads OrtDisablePerSessionThreads;

		public static DOrtSetSessionLogId OrtSetSessionLogId;

		public static DOrtSetSessionLogVerbosityLevel OrtSetSessionLogVerbosityLevel;

		public static DOrtSetSessionLogSeverityLevel OrtSetSessionLogSeverityLevel;

		public static DOrtSetIntraOpNumThreads OrtSetIntraOpNumThreads;

		public static DOrtSetInterOpNumThreads OrtSetInterOpNumThreads;

		public static DOrtSetSessionGraphOptimizationLevel OrtSetSessionGraphOptimizationLevel;

		public static DOrtAddSessionConfigEntry OrtAddSessionConfigEntry;

		public static DSessionOptionsAppendExecutionProvider_TensorRT SessionOptionsAppendExecutionProvider_TensorRT;

		public static DSessionOptionsAppendExecutionProvider_TensorRT_V2 SessionOptionsAppendExecutionProvider_TensorRT_V2;

		public static DSessionOptionsAppendExecutionProvider_CUDA SessionOptionsAppendExecutionProvider_CUDA;

		public static DSessionOptionsAppendExecutionProvider_CUDA_V2 SessionOptionsAppendExecutionProvider_CUDA_V2;

		public static DSessionOptionsAppendExecutionProvider_ROCM SessionOptionsAppendExecutionProvider_ROCM;

		public static DOrtAddFreeDimensionOverride OrtAddFreeDimensionOverride;

		public static DOrtAddFreeDimensionOverrideByName OrtAddFreeDimensionOverrideByName;

		public static DOrtRegisterCustomOpsLibrary OrtRegisterCustomOpsLibrary;

		public static DOrtRegisterCustomOpsLibrary_V2 OrtRegisterCustomOpsLibrary_V2;

		public static DOrtAddInitializer OrtAddInitializer;

		public static DSessionOptionsAppendExecutionProvider SessionOptionsAppendExecutionProvider;

		public static DOrtCreateLoraAdapter OrtCreateLoraAdapter;

		public static DOrtCreateLoraAdapterFromArray OrtCreateLoraAdapterFromArray;

		public static DOrtReleaseLoraAdapter OrtReleaseLoraAdapter;

		public static DOrtCreateRunOptions OrtCreateRunOptions;

		public static DOrtReleaseRunOptions OrtReleaseRunOptions;

		public static DOrtRunOptionsSetRunLogVerbosityLevel OrtRunOptionsSetRunLogVerbosityLevel;

		public static DOrtRunOptionsSetRunLogSeverityLevel OrtRunOptionsSetRunLogSeverityLevel;

		public static DOrtRunOptionsSetRunTag OrtRunOptionsSetRunTag;

		public static DOrtRunOptionsGetRunLogVerbosityLevel OrtRunOptionsGetRunLogVerbosityLevel;

		public static DOrtRunOptionsGetRunLogSeverityLevel OrtRunOptionsGetRunLogSeverityLevel;

		public static DOrtRunOptionsGetRunTag OrtRunOptionsGetRunTag;

		public static DOrtRunOptionsSetTerminate OrtRunOptionsSetTerminate;

		public static DOrtRunOptionsUnsetTerminate OrtRunOptionsUnsetTerminate;

		public static DOrtRunOptionsAddActiveLoraAdapter OrtRunOptionsAddActiveLoraAdapter;

		public static DOrtAddRunConfigEntry OrtAddRunConfigEntry;

		public static DOrtCreateThreadingOptions OrtCreateThreadingOptions;

		public static DOrtReleaseThreadingOptions OrtReleaseThreadingOptions;

		public static DOrtThreadingOptionsSetGlobalInterOpNumThreads OrtThreadingOptionsSetGlobalInterOpNumThreads;

		public static DOrtThreadingOptionsSetGlobalIntraOpNumThreads OrtThreadingOptionsSetGlobalIntraOpNumThreads;

		public static DOrtThreadingOptionsSetGlobalDenormalAsZero OrtThreadingOptionsSetGlobalDenormalAsZero;

		public static DOrtThreadingOptionsSetGlobalSpinControl OrtThreadingOptionsSetGlobalSpinControl;

		public static DOrtCreateMemoryInfo OrtCreateMemoryInfo;

		public static DOrtCreateMemoryInfoV2 OrtCreateMemoryInfoV2;

		public static DOrtCreateCpuMemoryInfo OrtCreateCpuMemoryInfo;

		public static DOrtReleaseMemoryInfo OrtReleaseMemoryInfo;

		public static DOrtCompareMemoryInfo OrtCompareMemoryInfo;

		public static DOrtMemoryInfoGetName OrtMemoryInfoGetName;

		public static DOrtMemoryInfoGetId OrtMemoryInfoGetId;

		public static DOrtMemoryInfoGetMemType OrtMemoryInfoGetMemType;

		public static DOrtMemoryInfoGetType OrtMemoryInfoGetType;

		public static DOrtMemoryInfoGetDeviceMemType OrtMemoryInfoGetDeviceMemType;

		public static DOrtMemoryInfoGetVendorId OrtMemoryInfoGetVendorId;

		public static DOrtGetAllocatorWithDefaultOptions OrtGetAllocatorWithDefaultOptions;

		public static DOrtAllocatorGetInfo OrtAllocatorGetInfo;

		public static DOrtCreateArenaCfg OrtCreateArenaCfg;

		public static DOrtReleaseArenaCfg OrtReleaseArenaCfg;

		public static DOrtCreateAllocator OrtCreateAllocator;

		public static DOrtReleaseAllocator OrtReleaseAllocator;

		public static DOrtAllocatorAlloc OrtAllocatorAlloc;

		public static DOrtAllocatorFree OrtAllocatorFree;

		public static DOrtCreateIoBinding OrtCreateIoBinding;

		public static DOrtReleaseIoBinding OrtReleaseIoBinding;

		public static DOrtBindInput OrtBindInput;

		public static DOrtSynchronizeBoundInputs OrtSynchronizeBoundInputs;

		public static DOrtBindOutput OrtBindOutput;

		public static DOrtBindOutputToDevice OrtBindOutputToDevice;

		public static DOrtSynchronizeBoundOutputs OrtSynchronizeBoundOutputs;

		public static DOrtGetBoundOutputNames OrtGetBoundOutputNames;

		public static DOrtGetBoundOutputValues OrtGetBoundOutputValues;

		public static DOrtClearBoundInputs OrtClearBoundInputs;

		public static DOrtClearBoundOutputs OrtClearBoundOutputs;

		public static DOrtTensorAt OrtTensorAt;

		public static DOrtCreateAndRegisterAllocator OrtCreateAndRegisterAllocator;

		public static DOrtUnregisterAllocator OrtUnregisterAllocator;

		public static DOrtSetLanguageProjection OrtSetLanguageProjection;

		public static DOrtSessionGetModelMetadata OrtSessionGetModelMetadata;

		public static DOrtModelMetadataGetProducerName OrtModelMetadataGetProducerName;

		public static DOrtModelMetadataGetGraphName OrtModelMetadataGetGraphName;

		public static DOrtModelMetadataGetDomain OrtModelMetadataGetDomain;

		public static DOrtModelMetadataGetDescription OrtModelMetadataGetDescription;

		public static DOrtModelMetadataGetGraphDescription OrtModelMetadataGetGraphDescription;

		public static DOrtModelMetadataGetVersion OrtModelMetadataGetVersion;

		public static DOrtModelMetadataGetCustomMetadataMapKeys OrtModelMetadataGetCustomMetadataMapKeys;

		public static DOrtModelMetadataLookupCustomMetadataMap OrtModelMetadataLookupCustomMetadataMap;

		public static DOrtReleaseModelMetadata OrtReleaseModelMetadata;

		public static DOrtHasValue OrtHasValue;

		public static DOrtGetValue OrtGetValue;

		public static DOrtGetValueType OrtGetValueType;

		public static DOrtGetOnnxTypeFromTypeInfo OrtGetOnnxTypeFromTypeInfo;

		public static DOrtGetValueCount OrtGetValueCount;

		public static DOrtCreateValue OrtCreateValue;

		public static DOrtGetTypeInfo OrtGetTypeInfo;

		public static DOrtCreateTensorAsOrtValue OrtCreateTensorAsOrtValue;

		public static DOrtCreateTensorWithDataAsOrtValue OrtCreateTensorWithDataAsOrtValue;

		public static DOrtValueIsTensor OrtValueIsTensor;

		public static DOrtValueIsSparseTensor OrtValueIsSparseTensor;

		public static DOrtGetTensorMutableData OrtGetTensorMutableData;

		public static DOrtGetTensorSizeInBytes OrtGetTensorSizeInBytes;

		public static DOrtFillStringTensor OrtFillStringTensor;

		public static DOrtGetResizedStringTensorElementBuffer OrtGetResizedStringTensorElementBuffer;

		public static DOrtGetStringTensorContent OrtGetStringTensorContent;

		public static DOrtGetStringTensorDataLength OrtGetStringTensorDataLength;

		public static DOrtGetStringTensorElementLength OrtGetStringTensorElementLength;

		public static DOrtGetStringTensorElement OrtGetStringTensorElement;

		public static DOrtCastTypeInfoToTensorInfo OrtCastTypeInfoToTensorInfo;

		public static DOrtGetTensorTypeAndShape OrtGetTensorTypeAndShape;

		public static DOrtReleaseTensorTypeAndShapeInfo OrtReleaseTensorTypeAndShapeInfo;

		public static DOrtGetTensorElementType OrtGetTensorElementType;

		public static DOrtGetDimensionsCount OrtGetDimensionsCount;

		public static DOrtGetDimensions OrtGetDimensions;

		public static DOrtGetSymbolicDimensions OrtGetSymbolicDimensions;

		public static DOrtGetTensorShapeElementCount OrtGetTensorShapeElementCount;

		public static DOrtGetTensorMemoryInfo OrtGetTensorMemoryInfo;

		public static DCastTypeInfoToMapTypeInfo OrtCastTypeInfoToMapTypeInfo;

		public static DGetMapKeyType OrtGetMapKeyType;

		public static DGetMapValueType OrtGetMapValueType;

		public static DCastTypeInfoToSequenceTypeInfo OrtCastTypeInfoToSequenceTypeInfo;

		public static DGetSequenceElementType OrtGetSequenceElementType;

		public static DOrtCastTypeInfoToOptionalTypeInfo OrtCastTypeInfoToOptionalTypeInfo;

		public static DGetOptionalContainedTypeInfo OrtGetOptionalContainedTypeInfo;

		public static DOrtReleaseValue OrtReleaseValue;

		public static DOrtGetCompileApi OrtGetCompileApi;

		public static DOrtReleaseExternalInitializerInfo OrtReleaseExternalInitializerInfo;

		public static DOrtCreateExternalInitializerInfo OrtCreateExternalInitializerInfo;

		public static DOrtExternalInitializerInfo_GetFilePath OrtExternalInitializerInfo_GetFilePath;

		public static DOrtExternalInitializerInfo_GetFileOffset OrtExternalInitializerInfo_GetFileOffset;

		public static DOrtExternalInitializerInfo_GetByteSize OrtExternalInitializerInfo_GetByteSize;

		public static DOrtGetNumHardwareDevices OrtGetNumHardwareDevices;

		public static DOrtGetHardwareDevices OrtGetHardwareDevices;

		public static DOrtGetHardwareDeviceEpIncompatibilityDetails OrtGetHardwareDeviceEpIncompatibilityDetails;

		public static DOrtDeviceEpIncompatibilityDetails_GetReasonsBitmask OrtDeviceEpIncompatibilityDetails_GetReasonsBitmask;

		public static DOrtDeviceEpIncompatibilityDetails_GetNotes OrtDeviceEpIncompatibilityDetails_GetNotes;

		public static DOrtDeviceEpIncompatibilityDetails_GetErrorCode OrtDeviceEpIncompatibilityDetails_GetErrorCode;

		public static DOrtReleaseDeviceEpIncompatibilityDetails OrtReleaseDeviceEpIncompatibilityDetails;

		public static DOrtCreateKeyValuePairs OrtCreateKeyValuePairs;

		public static DOrtAddKeyValuePair OrtAddKeyValuePair;

		public static DOrtGetKeyValue OrtGetKeyValue;

		public static DOrtGetKeyValuePairs OrtGetKeyValuePairs;

		public static DOrtRemoveKeyValuePair OrtRemoveKeyValuePair;

		public static DOrtReleaseKeyValuePairs OrtReleaseKeyValuePairs;

		public static DOrtHardwareDevice_Type OrtHardwareDevice_Type;

		public static DOrtHardwareDevice_VendorId OrtHardwareDevice_VendorId;

		public static DOrtHardwareDevice_Vendor OrtHardwareDevice_Vendor;

		public static DOrtHardwareDevice_DeviceId OrtHardwareDevice_DeviceId;

		public static DOrtHardwareDevice_Metadata OrtHardwareDevice_Metadata;

		public static DOrtEpDevice_EpName OrtEpDevice_EpName;

		public static DOrtEpDevice_EpVendor OrtEpDevice_EpVendor;

		public static DOrtEpDevice_EpMetadata OrtEpDevice_EpMetadata;

		public static DOrtEpDevice_EpOptions OrtEpDevice_EpOptions;

		public static DOrtEpDevice_Device OrtEpDevice_Device;

		public static DOrtEpDevice_MemoryInfo OrtEpDevice_MemoryInfo;

		public static DOrtCreateSyncStreamForEpDevice OrtCreateSyncStreamForEpDevice;

		public static DOrtSyncStream_GetHandle OrtSyncStream_GetHandle;

		public static DOrtReleaseSyncStream OrtReleaseSyncStream;

		public static DOrtRegisterExecutionProviderLibrary OrtRegisterExecutionProviderLibrary;

		public static DOrtUnregisterExecutionProviderLibrary OrtUnregisterExecutionProviderLibrary;

		public static DOrtGetEpDevices OrtGetEpDevices;

		public static DOrtGetModelCompatibilityForEpDevices OrtGetModelCompatibilityForEpDevices;

		public static DOrtSessionOptionsAppendExecutionProvider_V2 OrtSessionOptionsAppendExecutionProvider_V2;

		public static DSessionOptionsSetEpSelectionPolicy OrtSessionOptionsSetEpSelectionPolicy;

		public static DSessionOptionsSetEpSelectionPolicyDelegate OrtSessionOptionsSetEpSelectionPolicyDelegate;

		public static DOrtGetAvailableProviders OrtGetAvailableProviders;

		public static DOrtReleaseAvailableProviders OrtReleaseAvailableProviders;

		public static DOrtCreatePrepackedWeightsContainer OrtCreatePrepackedWeightsContainer;

		public static DOrtReleasePrepackedWeightsContainer OrtReleasePrepackedWeightsContainer;

		public static DOrtGetCompatibilityInfoFromModel OrtGetCompatibilityInfoFromModel;

		public static DOrtGetCompatibilityInfoFromModelBytes OrtGetCompatibilityInfoFromModelBytes;

		static NativeMethods()
		{
			if (!OrtEnv.DisableDllImportResolver)
			{
				try
				{
					NativeLibrary.SetDllImportResolver(typeof(NativeMethods).Assembly, DllImportResolver);
				}
				catch (InvalidOperationException)
				{
					Trace.WriteLine("[OnnxRuntime] A DllImportResolver is already registered for this assembly. OnnxRuntime's built-in resolver will not be used. To suppress this message, set OrtEnv.DisableDllImportResolver = true before using any OnnxRuntime APIs.");
				}
			}
			api_ = ((DOrtGetApi)Marshal.GetDelegateForFunctionPointer(OrtGetApiBase().GetApi, typeof(DOrtGetApi)))(14u);
			OrtGetVersionString = (DOrtGetVersionString)Marshal.GetDelegateForFunctionPointer(OrtGetApiBase().GetVersionString, typeof(DOrtGetVersionString));
			OrtCreateStatus = (DOrtCreateStatus)Marshal.GetDelegateForFunctionPointer(api_.CreateStatus, typeof(DOrtCreateStatus));
			OrtCreateEnv = (DOrtCreateEnv)Marshal.GetDelegateForFunctionPointer(api_.CreateEnv, typeof(DOrtCreateEnv));
			OrtCreateEnvWithCustomLogger = (DOrtCreateEnvWithCustomLogger)Marshal.GetDelegateForFunctionPointer(api_.CreateEnvWithCustomLogger, typeof(DOrtCreateEnvWithCustomLogger));
			OrtCreateEnvWithGlobalThreadPools = (DOrtCreateEnvWithGlobalThreadPools)Marshal.GetDelegateForFunctionPointer(api_.CreateEnvWithGlobalThreadPools, typeof(DOrtCreateEnvWithGlobalThreadPools));
			OrtCreateEnvWithCustomLoggerAndGlobalThreadPools = (DOrtCreateEnvWithCustomLoggerAndGlobalThreadPools)Marshal.GetDelegateForFunctionPointer(api_.CreateEnvWithCustomLoggerAndGlobalThreadPools, typeof(DOrtCreateEnvWithCustomLoggerAndGlobalThreadPools));
			OrtReleaseEnv = (DOrtReleaseEnv)Marshal.GetDelegateForFunctionPointer(api_.ReleaseEnv, typeof(DOrtReleaseEnv));
			OrtEnableTelemetryEvents = (DOrtEnableTelemetryEvents)Marshal.GetDelegateForFunctionPointer(api_.EnableTelemetryEvents, typeof(DOrtEnableTelemetryEvents));
			OrtDisableTelemetryEvents = (DOrtDisableTelemetryEvents)Marshal.GetDelegateForFunctionPointer(api_.DisableTelemetryEvents, typeof(DOrtDisableTelemetryEvents));
			OrtGetErrorCode = (DOrtGetErrorCode)Marshal.GetDelegateForFunctionPointer(api_.GetErrorCode, typeof(DOrtGetErrorCode));
			OrtGetErrorMessage = (DOrtGetErrorMessage)Marshal.GetDelegateForFunctionPointer(api_.GetErrorMessage, typeof(DOrtGetErrorMessage));
			OrtReleaseStatus = (DOrtReleaseStatus)Marshal.GetDelegateForFunctionPointer(api_.ReleaseStatus, typeof(DOrtReleaseStatus));
			OrtCreateSession = (DOrtCreateSession)Marshal.GetDelegateForFunctionPointer(api_.CreateSession, typeof(DOrtCreateSession));
			OrtCreateSessionWithPrepackedWeightsContainer = (DOrtCreateSessionWithPrepackedWeightsContainer)Marshal.GetDelegateForFunctionPointer(api_.CreateSessionWithPrepackedWeightsContainer, typeof(DOrtCreateSessionWithPrepackedWeightsContainer));
			OrtCreateSessionFromArray = (DOrtCreateSessionFromArray)Marshal.GetDelegateForFunctionPointer(api_.CreateSessionFromArray, typeof(DOrtCreateSessionFromArray));
			OrtCreateSessionFromArrayWithPrepackedWeightsContainer = (DOrtCreateSessionFromArrayWithPrepackedWeightsContainer)Marshal.GetDelegateForFunctionPointer(api_.CreateSessionFromArrayWithPrepackedWeightsContainer, typeof(DOrtCreateSessionFromArrayWithPrepackedWeightsContainer));
			OrtRun = (DOrtRun)Marshal.GetDelegateForFunctionPointer(api_.Run, typeof(DOrtRun));
			OrtRunWithBinding = (DOrtRunWithBinding)Marshal.GetDelegateForFunctionPointer(api_.RunWithBinding, typeof(DOrtRunWithBinding));
			OrtSessionGetInputCount = (DOrtSessionGetInputCount)Marshal.GetDelegateForFunctionPointer(api_.SessionGetInputCount, typeof(DOrtSessionGetInputCount));
			OrtSessionGetOutputCount = (DOrtSessionGetOutputCount)Marshal.GetDelegateForFunctionPointer(api_.SessionGetOutputCount, typeof(DOrtSessionGetOutputCount));
			OrtSessionGetOverridableInitializerCount = (DOrtSessionGetOverridableInitializerCount)Marshal.GetDelegateForFunctionPointer(api_.SessionGetOverridableInitializerCount, typeof(DOrtSessionGetOverridableInitializerCount));
			OrtSessionGetInputName = (DOrtSessionGetInputName)Marshal.GetDelegateForFunctionPointer(api_.SessionGetInputName, typeof(DOrtSessionGetInputName));
			OrtSessionGetOutputName = (DOrtSessionGetOutputName)Marshal.GetDelegateForFunctionPointer(api_.SessionGetOutputName, typeof(DOrtSessionGetOutputName));
			OrtSessionEndProfiling = (DOrtSessionEndProfiling)Marshal.GetDelegateForFunctionPointer(api_.SessionEndProfiling, typeof(DOrtSessionEndProfiling));
			OrtSessionGetOverridableInitializerName = (DOrtSessionGetOverridableInitializerName)Marshal.GetDelegateForFunctionPointer(api_.SessionGetOverridableInitializerName, typeof(DOrtSessionGetOverridableInitializerName));
			OrtSessionGetInputTypeInfo = (DOrtSessionGetInputTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.SessionGetInputTypeInfo, typeof(DOrtSessionGetInputTypeInfo));
			OrtSessionGetOutputTypeInfo = (DOrtSessionGetOutputTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.SessionGetOutputTypeInfo, typeof(DOrtSessionGetOutputTypeInfo));
			OrtSessionGetOverridableInitializerTypeInfo = (DOrtSessionGetOverridableInitializerTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.SessionGetOverridableInitializerTypeInfo, typeof(DOrtSessionGetOverridableInitializerTypeInfo));
			OrtSessionGetMemoryInfoForInputs = (DOrtSessionGetMemoryInfoForInputs)Marshal.GetDelegateForFunctionPointer(api_.SessionGetMemoryInfoForInputs, typeof(DOrtSessionGetMemoryInfoForInputs));
			OrtSessionGetMemoryInfoForOutputs = (DOrtSessionGetMemoryInfoForOutputs)Marshal.GetDelegateForFunctionPointer(api_.SessionGetMemoryInfoForOutputs, typeof(DOrtSessionGetMemoryInfoForOutputs));
			OrtSessionGetEpDeviceForInputs = (DOrtSessionGetEpDeviceForInputs)Marshal.GetDelegateForFunctionPointer(api_.SessionGetEpDeviceForInputs, typeof(DOrtSessionGetEpDeviceForInputs));
			OrtReleaseTypeInfo = (DOrtReleaseTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.ReleaseTypeInfo, typeof(DOrtReleaseTypeInfo));
			OrtReleaseSession = (DOrtReleaseSession)Marshal.GetDelegateForFunctionPointer(api_.ReleaseSession, typeof(DOrtReleaseSession));
			OrtSessionGetProfilingStartTimeNs = (DOrtSessionGetProfilingStartTimeNs)Marshal.GetDelegateForFunctionPointer(api_.SessionGetProfilingStartTimeNs, typeof(DOrtSessionGetProfilingStartTimeNs));
			OrtCreateSessionOptions = (DOrtCreateSessionOptions)Marshal.GetDelegateForFunctionPointer(api_.CreateSessionOptions, typeof(DOrtCreateSessionOptions));
			OrtReleaseSessionOptions = (DOrtReleaseSessionOptions)Marshal.GetDelegateForFunctionPointer(api_.ReleaseSessionOptions, typeof(DOrtReleaseSessionOptions));
			OrtCloneSessionOptions = (DOrtCloneSessionOptions)Marshal.GetDelegateForFunctionPointer(api_.CloneSessionOptions, typeof(DOrtCloneSessionOptions));
			OrtSetSessionExecutionMode = (DOrtSetSessionExecutionMode)Marshal.GetDelegateForFunctionPointer(api_.SetSessionExecutionMode, typeof(DOrtSetSessionExecutionMode));
			OrtSessionOptionsSetLoadCancellationFlag = (DOrtSessionOptionsSetLoadCancellationFlag)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsSetLoadCancellationFlag, typeof(DOrtSessionOptionsSetLoadCancellationFlag));
			OrtSetOptimizedModelFilePath = (DOrtSetOptimizedModelFilePath)Marshal.GetDelegateForFunctionPointer(api_.SetOptimizedModelFilePath, typeof(DOrtSetOptimizedModelFilePath));
			OrtEnableProfiling = (DOrtEnableProfiling)Marshal.GetDelegateForFunctionPointer(api_.EnableProfiling, typeof(DOrtEnableProfiling));
			OrtDisableProfiling = (DOrtDisableProfiling)Marshal.GetDelegateForFunctionPointer(api_.DisableProfiling, typeof(DOrtDisableProfiling));
			OrtEnableMemPattern = (DOrtEnableMemPattern)Marshal.GetDelegateForFunctionPointer(api_.EnableMemPattern, typeof(DOrtEnableMemPattern));
			OrtDisableMemPattern = (DOrtDisableMemPattern)Marshal.GetDelegateForFunctionPointer(api_.DisableMemPattern, typeof(DOrtDisableMemPattern));
			OrtEnableCpuMemArena = (DOrtEnableCpuMemArena)Marshal.GetDelegateForFunctionPointer(api_.EnableCpuMemArena, typeof(DOrtEnableCpuMemArena));
			OrtDisableCpuMemArena = (DOrtDisableCpuMemArena)Marshal.GetDelegateForFunctionPointer(api_.DisableCpuMemArena, typeof(DOrtDisableCpuMemArena));
			OrtDisablePerSessionThreads = (DOrtDisablePerSessionThreads)Marshal.GetDelegateForFunctionPointer(api_.DisablePerSessionThreads, typeof(DOrtDisablePerSessionThreads));
			OrtSetSessionLogId = (DOrtSetSessionLogId)Marshal.GetDelegateForFunctionPointer(api_.SetSessionLogId, typeof(DOrtSetSessionLogId));
			OrtSetSessionLogVerbosityLevel = (DOrtSetSessionLogVerbosityLevel)Marshal.GetDelegateForFunctionPointer(api_.SetSessionLogVerbosityLevel, typeof(DOrtSetSessionLogVerbosityLevel));
			OrtSetSessionLogSeverityLevel = (DOrtSetSessionLogSeverityLevel)Marshal.GetDelegateForFunctionPointer(api_.SetSessionLogSeverityLevel, typeof(DOrtSetSessionLogSeverityLevel));
			OrtSetInterOpNumThreads = (DOrtSetInterOpNumThreads)Marshal.GetDelegateForFunctionPointer(api_.SetInterOpNumThreads, typeof(DOrtSetInterOpNumThreads));
			OrtSetIntraOpNumThreads = (DOrtSetIntraOpNumThreads)Marshal.GetDelegateForFunctionPointer(api_.SetIntraOpNumThreads, typeof(DOrtSetIntraOpNumThreads));
			OrtSetSessionGraphOptimizationLevel = (DOrtSetSessionGraphOptimizationLevel)Marshal.GetDelegateForFunctionPointer(api_.SetSessionGraphOptimizationLevel, typeof(DOrtSetSessionGraphOptimizationLevel));
			OrtRegisterCustomOpsLibrary = (DOrtRegisterCustomOpsLibrary)Marshal.GetDelegateForFunctionPointer(api_.RegisterCustomOpsLibrary, typeof(DOrtRegisterCustomOpsLibrary));
			OrtRegisterCustomOpsLibrary_V2 = (DOrtRegisterCustomOpsLibrary_V2)Marshal.GetDelegateForFunctionPointer(api_.RegisterCustomOpsLibrary_V2, typeof(DOrtRegisterCustomOpsLibrary_V2));
			OrtAddSessionConfigEntry = (DOrtAddSessionConfigEntry)Marshal.GetDelegateForFunctionPointer(api_.AddSessionConfigEntry, typeof(DOrtAddSessionConfigEntry));
			OrtAddInitializer = (DOrtAddInitializer)Marshal.GetDelegateForFunctionPointer(api_.AddInitializer, typeof(DOrtAddInitializer));
			SessionOptionsAppendExecutionProvider_TensorRT = (DSessionOptionsAppendExecutionProvider_TensorRT)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsAppendExecutionProvider_TensorRT, typeof(DSessionOptionsAppendExecutionProvider_TensorRT));
			OrtCreateRunOptions = (DOrtCreateRunOptions)Marshal.GetDelegateForFunctionPointer(api_.CreateRunOptions, typeof(DOrtCreateRunOptions));
			OrtReleaseRunOptions = (DOrtReleaseRunOptions)Marshal.GetDelegateForFunctionPointer(api_.ReleaseRunOptions, typeof(DOrtReleaseRunOptions));
			OrtRunOptionsSetRunLogVerbosityLevel = (DOrtRunOptionsSetRunLogVerbosityLevel)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsSetRunLogVerbosityLevel, typeof(DOrtRunOptionsSetRunLogVerbosityLevel));
			OrtRunOptionsSetRunLogSeverityLevel = (DOrtRunOptionsSetRunLogSeverityLevel)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsSetRunLogSeverityLevel, typeof(DOrtRunOptionsSetRunLogSeverityLevel));
			OrtRunOptionsSetRunTag = (DOrtRunOptionsSetRunTag)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsSetRunTag, typeof(DOrtRunOptionsSetRunTag));
			OrtRunOptionsGetRunLogVerbosityLevel = (DOrtRunOptionsGetRunLogVerbosityLevel)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsGetRunLogVerbosityLevel, typeof(DOrtRunOptionsGetRunLogVerbosityLevel));
			OrtRunOptionsGetRunLogSeverityLevel = (DOrtRunOptionsGetRunLogSeverityLevel)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsGetRunLogSeverityLevel, typeof(DOrtRunOptionsGetRunLogSeverityLevel));
			OrtRunOptionsGetRunTag = (DOrtRunOptionsGetRunTag)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsGetRunTag, typeof(DOrtRunOptionsGetRunTag));
			OrtRunOptionsSetTerminate = (DOrtRunOptionsSetTerminate)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsSetTerminate, typeof(DOrtRunOptionsSetTerminate));
			OrtRunOptionsUnsetTerminate = (DOrtRunOptionsUnsetTerminate)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsUnsetTerminate, typeof(DOrtRunOptionsUnsetTerminate));
			OrtCreateThreadingOptions = (DOrtCreateThreadingOptions)Marshal.GetDelegateForFunctionPointer(api_.CreateThreadingOptions, typeof(DOrtCreateThreadingOptions));
			OrtReleaseThreadingOptions = (DOrtReleaseThreadingOptions)Marshal.GetDelegateForFunctionPointer(api_.ReleaseThreadingOptions, typeof(DOrtReleaseThreadingOptions));
			OrtThreadingOptionsSetGlobalInterOpNumThreads = (DOrtThreadingOptionsSetGlobalInterOpNumThreads)Marshal.GetDelegateForFunctionPointer(api_.SetGlobalInterOpNumThreads, typeof(DOrtThreadingOptionsSetGlobalInterOpNumThreads));
			OrtThreadingOptionsSetGlobalIntraOpNumThreads = (DOrtThreadingOptionsSetGlobalIntraOpNumThreads)Marshal.GetDelegateForFunctionPointer(api_.SetGlobalIntraOpNumThreads, typeof(DOrtThreadingOptionsSetGlobalIntraOpNumThreads));
			OrtThreadingOptionsSetGlobalDenormalAsZero = (DOrtThreadingOptionsSetGlobalDenormalAsZero)Marshal.GetDelegateForFunctionPointer(api_.SetGlobalDenormalAsZero, typeof(DOrtThreadingOptionsSetGlobalDenormalAsZero));
			OrtThreadingOptionsSetGlobalSpinControl = (DOrtThreadingOptionsSetGlobalSpinControl)Marshal.GetDelegateForFunctionPointer(api_.SetGlobalSpinControl, typeof(DOrtThreadingOptionsSetGlobalSpinControl));
			OrtAddRunConfigEntry = (DOrtAddRunConfigEntry)Marshal.GetDelegateForFunctionPointer(api_.AddRunConfigEntry, typeof(DOrtAddRunConfigEntry));
			OrtCreateArenaCfg = (DOrtCreateArenaCfg)Marshal.GetDelegateForFunctionPointer(api_.CreateArenaCfg, typeof(DOrtCreateArenaCfg));
			OrtReleaseArenaCfg = (DOrtReleaseArenaCfg)Marshal.GetDelegateForFunctionPointer(api_.ReleaseArenaCfg, typeof(DOrtReleaseArenaCfg));
			OrtReleaseAllocator = (DOrtReleaseAllocator)Marshal.GetDelegateForFunctionPointer(api_.ReleaseAllocator, typeof(DOrtReleaseAllocator));
			OrtCreateMemoryInfo = (DOrtCreateMemoryInfo)Marshal.GetDelegateForFunctionPointer(api_.CreateMemoryInfo, typeof(DOrtCreateMemoryInfo));
			OrtCreateCpuMemoryInfo = (DOrtCreateCpuMemoryInfo)Marshal.GetDelegateForFunctionPointer(api_.CreateCpuMemoryInfo, typeof(DOrtCreateCpuMemoryInfo));
			OrtReleaseMemoryInfo = (DOrtReleaseMemoryInfo)Marshal.GetDelegateForFunctionPointer(api_.ReleaseMemoryInfo, typeof(DOrtReleaseMemoryInfo));
			OrtCompareMemoryInfo = (DOrtCompareMemoryInfo)Marshal.GetDelegateForFunctionPointer(api_.CompareMemoryInfo, typeof(DOrtCompareMemoryInfo));
			OrtMemoryInfoGetName = (DOrtMemoryInfoGetName)Marshal.GetDelegateForFunctionPointer(api_.MemoryInfoGetName, typeof(DOrtMemoryInfoGetName));
			OrtMemoryInfoGetId = (DOrtMemoryInfoGetId)Marshal.GetDelegateForFunctionPointer(api_.MemoryInfoGetId, typeof(DOrtMemoryInfoGetId));
			OrtMemoryInfoGetMemType = (DOrtMemoryInfoGetMemType)Marshal.GetDelegateForFunctionPointer(api_.MemoryInfoGetMemType, typeof(DOrtMemoryInfoGetMemType));
			OrtMemoryInfoGetType = (DOrtMemoryInfoGetType)Marshal.GetDelegateForFunctionPointer(api_.MemoryInfoGetType, typeof(DOrtMemoryInfoGetType));
			OrtGetAllocatorWithDefaultOptions = (DOrtGetAllocatorWithDefaultOptions)Marshal.GetDelegateForFunctionPointer(api_.GetAllocatorWithDefaultOptions, typeof(DOrtGetAllocatorWithDefaultOptions));
			OrtCreateMemoryInfoV2 = (DOrtCreateMemoryInfoV2)Marshal.GetDelegateForFunctionPointer(api_.CreateMemoryInfo_V2, typeof(DOrtCreateMemoryInfoV2));
			OrtMemoryInfoGetDeviceMemType = (DOrtMemoryInfoGetDeviceMemType)Marshal.GetDelegateForFunctionPointer(api_.MemoryInfoGetDeviceMemType, typeof(DOrtMemoryInfoGetDeviceMemType));
			OrtMemoryInfoGetVendorId = (DOrtMemoryInfoGetVendorId)Marshal.GetDelegateForFunctionPointer(api_.MemoryInfoGetVendorId, typeof(DOrtMemoryInfoGetVendorId));
			OrtCreateAllocator = (DOrtCreateAllocator)Marshal.GetDelegateForFunctionPointer(api_.CreateAllocator, typeof(DOrtCreateAllocator));
			OrtReleaseAllocator = (DOrtReleaseAllocator)Marshal.GetDelegateForFunctionPointer(api_.ReleaseAllocator, typeof(DOrtReleaseAllocator));
			OrtAllocatorAlloc = (DOrtAllocatorAlloc)Marshal.GetDelegateForFunctionPointer(api_.AllocatorAlloc, typeof(DOrtAllocatorAlloc));
			OrtAllocatorFree = (DOrtAllocatorFree)Marshal.GetDelegateForFunctionPointer(api_.AllocatorFree, typeof(DOrtAllocatorFree));
			OrtAllocatorGetInfo = (DOrtAllocatorGetInfo)Marshal.GetDelegateForFunctionPointer(api_.AllocatorGetInfo, typeof(DOrtAllocatorGetInfo));
			OrtAddFreeDimensionOverride = (DOrtAddFreeDimensionOverride)Marshal.GetDelegateForFunctionPointer(api_.AddFreeDimensionOverride, typeof(DOrtAddFreeDimensionOverride));
			OrtAddFreeDimensionOverrideByName = (DOrtAddFreeDimensionOverrideByName)Marshal.GetDelegateForFunctionPointer(api_.AddFreeDimensionOverrideByName, typeof(DOrtAddFreeDimensionOverrideByName));
			OrtCreateIoBinding = (DOrtCreateIoBinding)Marshal.GetDelegateForFunctionPointer(api_.CreateIoBinding, typeof(DOrtCreateIoBinding));
			OrtReleaseIoBinding = (DOrtReleaseIoBinding)Marshal.GetDelegateForFunctionPointer(api_.ReleaseIoBinding, typeof(DOrtReleaseIoBinding));
			OrtBindInput = (DOrtBindInput)Marshal.GetDelegateForFunctionPointer(api_.BindInput, typeof(DOrtBindInput));
			OrtSynchronizeBoundInputs = (DOrtSynchronizeBoundInputs)Marshal.GetDelegateForFunctionPointer(api_.SynchronizeBoundInputs, typeof(DOrtSynchronizeBoundInputs));
			OrtBindOutput = (DOrtBindOutput)Marshal.GetDelegateForFunctionPointer(api_.BindOutput, typeof(DOrtBindOutput));
			OrtBindOutputToDevice = (DOrtBindOutputToDevice)Marshal.GetDelegateForFunctionPointer(api_.BindOutputToDevice, typeof(DOrtBindOutputToDevice));
			OrtSynchronizeBoundOutputs = (DOrtSynchronizeBoundOutputs)Marshal.GetDelegateForFunctionPointer(api_.SynchronizeBoundOutputs, typeof(DOrtSynchronizeBoundOutputs));
			OrtGetBoundOutputNames = (DOrtGetBoundOutputNames)Marshal.GetDelegateForFunctionPointer(api_.GetBoundOutputNames, typeof(DOrtGetBoundOutputNames));
			OrtGetBoundOutputValues = (DOrtGetBoundOutputValues)Marshal.GetDelegateForFunctionPointer(api_.GetBoundOutputValues, typeof(DOrtGetBoundOutputValues));
			OrtClearBoundInputs = (DOrtClearBoundInputs)Marshal.GetDelegateForFunctionPointer(api_.ClearBoundInputs, typeof(DOrtClearBoundInputs));
			OrtClearBoundOutputs = (DOrtClearBoundOutputs)Marshal.GetDelegateForFunctionPointer(api_.ClearBoundOutputs, typeof(DOrtClearBoundOutputs));
			OrtTensorAt = (DOrtTensorAt)Marshal.GetDelegateForFunctionPointer(api_.TensorAt, typeof(DOrtTensorAt));
			OrtCreateAndRegisterAllocator = (DOrtCreateAndRegisterAllocator)Marshal.GetDelegateForFunctionPointer(api_.CreateAndRegisterAllocator, typeof(DOrtCreateAndRegisterAllocator));
			OrtUnregisterAllocator = (DOrtUnregisterAllocator)Marshal.GetDelegateForFunctionPointer(api_.UnregisterAllocator, typeof(DOrtUnregisterAllocator));
			OrtSetLanguageProjection = (DOrtSetLanguageProjection)Marshal.GetDelegateForFunctionPointer(api_.SetLanguageProjection, typeof(DOrtSetLanguageProjection));
			OrtHasValue = (DOrtHasValue)Marshal.GetDelegateForFunctionPointer(api_.HasValue, typeof(DOrtHasValue));
			OrtGetValue = (DOrtGetValue)Marshal.GetDelegateForFunctionPointer(api_.GetValue, typeof(DOrtGetValue));
			OrtGetValueCount = (DOrtGetValueCount)Marshal.GetDelegateForFunctionPointer(api_.GetValueCount, typeof(DOrtGetValueCount));
			OrtCreateValue = (DOrtCreateValue)Marshal.GetDelegateForFunctionPointer(api_.CreateValue, typeof(DOrtCreateValue));
			OrtGetValueType = (DOrtGetValueType)Marshal.GetDelegateForFunctionPointer(api_.GetValueType, typeof(DOrtGetValueType));
			OrtGetOnnxTypeFromTypeInfo = (DOrtGetOnnxTypeFromTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.GetOnnxTypeFromTypeInfo, typeof(DOrtGetOnnxTypeFromTypeInfo));
			OrtGetTypeInfo = (DOrtGetTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.GetTypeInfo, typeof(DOrtGetTypeInfo));
			OrtCreateTensorAsOrtValue = (DOrtCreateTensorAsOrtValue)Marshal.GetDelegateForFunctionPointer(api_.CreateTensorAsOrtValue, typeof(DOrtCreateTensorAsOrtValue));
			OrtCreateTensorWithDataAsOrtValue = (DOrtCreateTensorWithDataAsOrtValue)Marshal.GetDelegateForFunctionPointer(api_.CreateTensorWithDataAsOrtValue, typeof(DOrtCreateTensorWithDataAsOrtValue));
			OrtValueIsTensor = (DOrtValueIsTensor)Marshal.GetDelegateForFunctionPointer(api_.IsTensor, typeof(DOrtValueIsTensor));
			OrtValueIsSparseTensor = (DOrtValueIsSparseTensor)Marshal.GetDelegateForFunctionPointer(api_.IsSparseTensor, typeof(DOrtValueIsSparseTensor));
			OrtGetTensorMutableData = (DOrtGetTensorMutableData)Marshal.GetDelegateForFunctionPointer(api_.GetTensorMutableData, typeof(DOrtGetTensorMutableData));
			OrtGetTensorSizeInBytes = (DOrtGetTensorSizeInBytes)Marshal.GetDelegateForFunctionPointer(api_.GetTensorSizeInBytes, typeof(DOrtGetTensorSizeInBytes));
			OrtFillStringTensor = (DOrtFillStringTensor)Marshal.GetDelegateForFunctionPointer(api_.FillStringTensor, typeof(DOrtFillStringTensor));
			OrtGetResizedStringTensorElementBuffer = (DOrtGetResizedStringTensorElementBuffer)Marshal.GetDelegateForFunctionPointer(api_.GetResizedStringTensorElementBuffer, typeof(DOrtGetResizedStringTensorElementBuffer));
			OrtGetStringTensorContent = (DOrtGetStringTensorContent)Marshal.GetDelegateForFunctionPointer(api_.GetStringTensorContent, typeof(DOrtGetStringTensorContent));
			OrtGetStringTensorDataLength = (DOrtGetStringTensorDataLength)Marshal.GetDelegateForFunctionPointer(api_.GetStringTensorDataLength, typeof(DOrtGetStringTensorDataLength));
			OrtGetStringTensorElementLength = (DOrtGetStringTensorElementLength)Marshal.GetDelegateForFunctionPointer(api_.GetStringTensorElementLength, typeof(DOrtGetStringTensorElementLength));
			OrtGetStringTensorElement = (DOrtGetStringTensorElement)Marshal.GetDelegateForFunctionPointer(api_.GetStringTensorElement, typeof(DOrtGetStringTensorElement));
			OrtCastTypeInfoToTensorInfo = (DOrtCastTypeInfoToTensorInfo)Marshal.GetDelegateForFunctionPointer(api_.CastTypeInfoToTensorInfo, typeof(DOrtCastTypeInfoToTensorInfo));
			OrtGetTensorTypeAndShape = (DOrtGetTensorTypeAndShape)Marshal.GetDelegateForFunctionPointer(api_.GetTensorTypeAndShape, typeof(DOrtGetTensorTypeAndShape));
			OrtReleaseTensorTypeAndShapeInfo = (DOrtReleaseTensorTypeAndShapeInfo)Marshal.GetDelegateForFunctionPointer(api_.ReleaseTensorTypeAndShapeInfo, typeof(DOrtReleaseTensorTypeAndShapeInfo));
			OrtGetTensorElementType = (DOrtGetTensorElementType)Marshal.GetDelegateForFunctionPointer(api_.GetTensorElementType, typeof(DOrtGetTensorElementType));
			OrtGetDimensionsCount = (DOrtGetDimensionsCount)Marshal.GetDelegateForFunctionPointer(api_.GetDimensionsCount, typeof(DOrtGetDimensionsCount));
			OrtGetDimensions = (DOrtGetDimensions)Marshal.GetDelegateForFunctionPointer(api_.GetDimensions, typeof(DOrtGetDimensions));
			OrtGetSymbolicDimensions = (DOrtGetSymbolicDimensions)Marshal.GetDelegateForFunctionPointer(api_.GetSymbolicDimensions, typeof(DOrtGetSymbolicDimensions));
			OrtGetTensorShapeElementCount = (DOrtGetTensorShapeElementCount)Marshal.GetDelegateForFunctionPointer(api_.GetTensorShapeElementCount, typeof(DOrtGetTensorShapeElementCount));
			OrtGetTensorMemoryInfo = (DOrtGetTensorMemoryInfo)Marshal.GetDelegateForFunctionPointer(api_.GetTensorMemoryInfo, typeof(DOrtGetTensorMemoryInfo));
			OrtGetMapKeyType = (DGetMapKeyType)Marshal.GetDelegateForFunctionPointer(api_.GetMapKeyType, typeof(DGetMapKeyType));
			OrtCastTypeInfoToMapTypeInfo = (DCastTypeInfoToMapTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.CastTypeInfoToMapTypeInfo, typeof(DCastTypeInfoToMapTypeInfo));
			OrtGetMapValueType = (DGetMapValueType)Marshal.GetDelegateForFunctionPointer(api_.GetMapValueType, typeof(DGetMapValueType));
			OrtCastTypeInfoToSequenceTypeInfo = (DCastTypeInfoToSequenceTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.CastTypeInfoToSequenceTypeInfo, typeof(DCastTypeInfoToSequenceTypeInfo));
			OrtGetSequenceElementType = (DGetSequenceElementType)Marshal.GetDelegateForFunctionPointer(api_.GetSequenceElementType, typeof(DGetSequenceElementType));
			OrtCastTypeInfoToOptionalTypeInfo = (DOrtCastTypeInfoToOptionalTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.CastTypeInfoToOptionalTypeInfo, typeof(DOrtCastTypeInfoToOptionalTypeInfo));
			OrtGetOptionalContainedTypeInfo = (DGetOptionalContainedTypeInfo)Marshal.GetDelegateForFunctionPointer(api_.GetOptionalContainedTypeInfo, typeof(DGetOptionalContainedTypeInfo));
			OrtReleaseValue = (DOrtReleaseValue)Marshal.GetDelegateForFunctionPointer(api_.ReleaseValue, typeof(DOrtReleaseValue));
			OrtSessionGetModelMetadata = (DOrtSessionGetModelMetadata)Marshal.GetDelegateForFunctionPointer(api_.SessionGetModelMetadata, typeof(DOrtSessionGetModelMetadata));
			OrtModelMetadataGetProducerName = (DOrtModelMetadataGetProducerName)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataGetProducerName, typeof(DOrtModelMetadataGetProducerName));
			OrtModelMetadataGetGraphName = (DOrtModelMetadataGetGraphName)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataGetGraphName, typeof(DOrtModelMetadataGetGraphName));
			OrtModelMetadataGetDomain = (DOrtModelMetadataGetDomain)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataGetDomain, typeof(DOrtModelMetadataGetDomain));
			OrtModelMetadataGetDescription = (DOrtModelMetadataGetDescription)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataGetDescription, typeof(DOrtModelMetadataGetDescription));
			OrtModelMetadataGetGraphDescription = (DOrtModelMetadataGetGraphDescription)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataGetGraphDescription, typeof(DOrtModelMetadataGetGraphDescription));
			OrtModelMetadataGetVersion = (DOrtModelMetadataGetVersion)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataGetVersion, typeof(DOrtModelMetadataGetVersion));
			OrtModelMetadataGetCustomMetadataMapKeys = (DOrtModelMetadataGetCustomMetadataMapKeys)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataGetCustomMetadataMapKeys, typeof(DOrtModelMetadataGetCustomMetadataMapKeys));
			OrtModelMetadataLookupCustomMetadataMap = (DOrtModelMetadataLookupCustomMetadataMap)Marshal.GetDelegateForFunctionPointer(api_.ModelMetadataLookupCustomMetadataMap, typeof(DOrtModelMetadataLookupCustomMetadataMap));
			OrtReleaseModelMetadata = (DOrtReleaseModelMetadata)Marshal.GetDelegateForFunctionPointer(api_.ReleaseModelMetadata, typeof(DOrtReleaseModelMetadata));
			OrtGetAvailableProviders = (DOrtGetAvailableProviders)Marshal.GetDelegateForFunctionPointer(api_.GetAvailableProviders, typeof(DOrtGetAvailableProviders));
			OrtReleaseAvailableProviders = (DOrtReleaseAvailableProviders)Marshal.GetDelegateForFunctionPointer(api_.ReleaseAvailableProviders, typeof(DOrtReleaseAvailableProviders));
			OrtCreatePrepackedWeightsContainer = (DOrtCreatePrepackedWeightsContainer)Marshal.GetDelegateForFunctionPointer(api_.CreatePrepackedWeightsContainer, typeof(DOrtCreatePrepackedWeightsContainer));
			OrtReleasePrepackedWeightsContainer = (DOrtReleasePrepackedWeightsContainer)Marshal.GetDelegateForFunctionPointer(api_.ReleasePrepackedWeightsContainer, typeof(DOrtReleasePrepackedWeightsContainer));
			SessionOptionsAppendExecutionProvider_TensorRT_V2 = (DSessionOptionsAppendExecutionProvider_TensorRT_V2)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsAppendExecutionProvider_TensorRT_V2, typeof(DSessionOptionsAppendExecutionProvider_TensorRT_V2));
			OrtCreateTensorRTProviderOptions = (DOrtCreateTensorRTProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.CreateTensorRTProviderOptions, typeof(DOrtCreateTensorRTProviderOptions));
			OrtUpdateTensorRTProviderOptions = (DOrtUpdateTensorRTProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.UpdateTensorRTProviderOptions, typeof(DOrtUpdateTensorRTProviderOptions));
			OrtGetTensorRTProviderOptionsAsString = (DOrtGetTensorRTProviderOptionsAsString)Marshal.GetDelegateForFunctionPointer(api_.GetTensorRTProviderOptionsAsString, typeof(DOrtGetTensorRTProviderOptionsAsString));
			OrtReleaseTensorRTProviderOptions = (DOrtReleaseTensorRTProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.ReleaseTensorRTProviderOptions, typeof(DOrtReleaseTensorRTProviderOptions));
			SessionOptionsAppendExecutionProvider_CUDA = (DSessionOptionsAppendExecutionProvider_CUDA)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsAppendExecutionProvider_CUDA, typeof(DSessionOptionsAppendExecutionProvider_CUDA));
			SessionOptionsAppendExecutionProvider_CUDA_V2 = (DSessionOptionsAppendExecutionProvider_CUDA_V2)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsAppendExecutionProvider_CUDA_V2, typeof(DSessionOptionsAppendExecutionProvider_CUDA_V2));
			OrtCreateCUDAProviderOptions = (DOrtCreateCUDAProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.CreateCUDAProviderOptions, typeof(DOrtCreateCUDAProviderOptions));
			OrtUpdateCUDAProviderOptions = (DOrtUpdateCUDAProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.UpdateCUDAProviderOptions, typeof(DOrtUpdateCUDAProviderOptions));
			OrtGetCUDAProviderOptionsAsString = (DOrtGetCUDAProviderOptionsAsString)Marshal.GetDelegateForFunctionPointer(api_.GetCUDAProviderOptionsAsString, typeof(DOrtGetCUDAProviderOptionsAsString));
			OrtReleaseCUDAProviderOptions = (DOrtReleaseCUDAProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.ReleaseCUDAProviderOptions, typeof(DOrtReleaseCUDAProviderOptions));
			SessionOptionsAppendExecutionProvider = (DSessionOptionsAppendExecutionProvider)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsAppendExecutionProvider, typeof(DSessionOptionsAppendExecutionProvider));
			OrtUpdateEnvWithCustomLogLevel = (DOrtUpdateEnvWithCustomLogLevel)Marshal.GetDelegateForFunctionPointer(api_.UpdateEnvWithCustomLogLevel, typeof(DOrtUpdateEnvWithCustomLogLevel));
			SessionOptionsAppendExecutionProvider_ROCM = (DSessionOptionsAppendExecutionProvider_ROCM)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsAppendExecutionProvider_ROCM, typeof(DSessionOptionsAppendExecutionProvider_ROCM));
			OrtCreateROCMProviderOptions = (DOrtCreateROCMProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.CreateROCMProviderOptions, typeof(DOrtCreateROCMProviderOptions));
			OrtUpdateROCMProviderOptions = (DOrtUpdateROCMProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.UpdateROCMProviderOptions, typeof(DOrtUpdateROCMProviderOptions));
			OrtGetROCMProviderOptionsAsString = (DOrtGetROCMProviderOptionsAsString)Marshal.GetDelegateForFunctionPointer(api_.GetROCMProviderOptionsAsString, typeof(DOrtGetROCMProviderOptionsAsString));
			OrtReleaseROCMProviderOptions = (DOrtReleaseROCMProviderOptions)Marshal.GetDelegateForFunctionPointer(api_.ReleaseROCMProviderOptions, typeof(DOrtReleaseROCMProviderOptions));
			OrtCreateAndRegisterAllocatorV2 = (DCreateAndRegisterAllocatorV2)Marshal.GetDelegateForFunctionPointer(api_.CreateAndRegisterAllocatorV2, typeof(DCreateAndRegisterAllocatorV2));
			OrtRunAsync = (DOrtRunAsync)Marshal.GetDelegateForFunctionPointer(api_.RunAsync, typeof(DOrtRunAsync));
			OrtCreateLoraAdapter = (DOrtCreateLoraAdapter)Marshal.GetDelegateForFunctionPointer(api_.CreateLoraAdapter, typeof(DOrtCreateLoraAdapter));
			OrtCreateLoraAdapterFromArray = (DOrtCreateLoraAdapterFromArray)Marshal.GetDelegateForFunctionPointer(api_.CreateLoraAdapterFromArray, typeof(DOrtCreateLoraAdapterFromArray));
			OrtReleaseLoraAdapter = (DOrtReleaseLoraAdapter)Marshal.GetDelegateForFunctionPointer(api_.ReleaseLoraAdapter, typeof(DOrtReleaseLoraAdapter));
			OrtRunOptionsAddActiveLoraAdapter = (DOrtRunOptionsAddActiveLoraAdapter)Marshal.GetDelegateForFunctionPointer(api_.RunOptionsAddActiveLoraAdapter, typeof(DOrtRunOptionsAddActiveLoraAdapter));
			OrtGetCompileApi = (DOrtGetCompileApi)Marshal.GetDelegateForFunctionPointer(api_.GetCompileApi, typeof(DOrtGetCompileApi));
			CompileApi = new Microsoft.ML.OnnxRuntime.CompileApi.NativeMethods(OrtGetCompileApi);
			OrtCreateKeyValuePairs = (DOrtCreateKeyValuePairs)Marshal.GetDelegateForFunctionPointer(api_.CreateKeyValuePairs, typeof(DOrtCreateKeyValuePairs));
			OrtAddKeyValuePair = (DOrtAddKeyValuePair)Marshal.GetDelegateForFunctionPointer(api_.AddKeyValuePair, typeof(DOrtAddKeyValuePair));
			OrtGetKeyValue = (DOrtGetKeyValue)Marshal.GetDelegateForFunctionPointer(api_.GetKeyValue, typeof(DOrtGetKeyValue));
			OrtGetKeyValuePairs = (DOrtGetKeyValuePairs)Marshal.GetDelegateForFunctionPointer(api_.GetKeyValuePairs, typeof(DOrtGetKeyValuePairs));
			OrtRemoveKeyValuePair = (DOrtRemoveKeyValuePair)Marshal.GetDelegateForFunctionPointer(api_.RemoveKeyValuePair, typeof(DOrtRemoveKeyValuePair));
			OrtReleaseKeyValuePairs = (DOrtReleaseKeyValuePairs)Marshal.GetDelegateForFunctionPointer(api_.ReleaseKeyValuePairs, typeof(DOrtReleaseKeyValuePairs));
			OrtHardwareDevice_Type = (DOrtHardwareDevice_Type)Marshal.GetDelegateForFunctionPointer(api_.HardwareDevice_Type, typeof(DOrtHardwareDevice_Type));
			OrtHardwareDevice_VendorId = (DOrtHardwareDevice_VendorId)Marshal.GetDelegateForFunctionPointer(api_.HardwareDevice_VendorId, typeof(DOrtHardwareDevice_VendorId));
			OrtHardwareDevice_Vendor = (DOrtHardwareDevice_Vendor)Marshal.GetDelegateForFunctionPointer(api_.HardwareDevice_Vendor, typeof(DOrtHardwareDevice_Vendor));
			OrtHardwareDevice_DeviceId = (DOrtHardwareDevice_DeviceId)Marshal.GetDelegateForFunctionPointer(api_.HardwareDevice_DeviceId, typeof(DOrtHardwareDevice_DeviceId));
			OrtHardwareDevice_Metadata = (DOrtHardwareDevice_Metadata)Marshal.GetDelegateForFunctionPointer(api_.HardwareDevice_Metadata, typeof(DOrtHardwareDevice_Metadata));
			OrtEpDevice_EpName = (DOrtEpDevice_EpName)Marshal.GetDelegateForFunctionPointer(api_.EpDevice_EpName, typeof(DOrtEpDevice_EpName));
			OrtEpDevice_EpVendor = (DOrtEpDevice_EpVendor)Marshal.GetDelegateForFunctionPointer(api_.EpDevice_EpVendor, typeof(DOrtEpDevice_EpVendor));
			OrtEpDevice_EpMetadata = (DOrtEpDevice_EpMetadata)Marshal.GetDelegateForFunctionPointer(api_.EpDevice_EpMetadata, typeof(DOrtEpDevice_EpMetadata));
			OrtEpDevice_EpOptions = (DOrtEpDevice_EpOptions)Marshal.GetDelegateForFunctionPointer(api_.EpDevice_EpOptions, typeof(DOrtEpDevice_EpOptions));
			OrtEpDevice_Device = (DOrtEpDevice_Device)Marshal.GetDelegateForFunctionPointer(api_.EpDevice_Device, typeof(DOrtEpDevice_Device));
			OrtEpDevice_MemoryInfo = (DOrtEpDevice_MemoryInfo)Marshal.GetDelegateForFunctionPointer(api_.EpDevice_MemoryInfo, typeof(DOrtEpDevice_MemoryInfo));
			OrtRegisterExecutionProviderLibrary = (DOrtRegisterExecutionProviderLibrary)Marshal.GetDelegateForFunctionPointer(api_.RegisterExecutionProviderLibrary, typeof(DOrtRegisterExecutionProviderLibrary));
			OrtUnregisterExecutionProviderLibrary = (DOrtUnregisterExecutionProviderLibrary)Marshal.GetDelegateForFunctionPointer(api_.UnregisterExecutionProviderLibrary, typeof(DOrtUnregisterExecutionProviderLibrary));
			OrtGetEpDevices = (DOrtGetEpDevices)Marshal.GetDelegateForFunctionPointer(api_.GetEpDevices, typeof(DOrtGetEpDevices));
			OrtSessionOptionsAppendExecutionProvider_V2 = (DOrtSessionOptionsAppendExecutionProvider_V2)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsAppendExecutionProvider_V2, typeof(DOrtSessionOptionsAppendExecutionProvider_V2));
			OrtSessionOptionsSetEpSelectionPolicy = (DSessionOptionsSetEpSelectionPolicy)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsSetEpSelectionPolicy, typeof(DSessionOptionsSetEpSelectionPolicy));
			OrtSessionOptionsSetEpSelectionPolicyDelegate = (DSessionOptionsSetEpSelectionPolicyDelegate)Marshal.GetDelegateForFunctionPointer(api_.SessionOptionsSetEpSelectionPolicyDelegate, typeof(DSessionOptionsSetEpSelectionPolicyDelegate));
			OrtReleaseExternalInitializerInfo = (DOrtReleaseExternalInitializerInfo)Marshal.GetDelegateForFunctionPointer(api_.ReleaseExternalInitializerInfo, typeof(DOrtReleaseExternalInitializerInfo));
			OrtExternalInitializerInfo_GetFilePath = (DOrtExternalInitializerInfo_GetFilePath)Marshal.GetDelegateForFunctionPointer(api_.ExternalInitializerInfo_GetFilePath, typeof(DOrtExternalInitializerInfo_GetFilePath));
			OrtExternalInitializerInfo_GetFileOffset = (DOrtExternalInitializerInfo_GetFileOffset)Marshal.GetDelegateForFunctionPointer(api_.ExternalInitializerInfo_GetFileOffset, typeof(DOrtExternalInitializerInfo_GetFileOffset));
			OrtExternalInitializerInfo_GetByteSize = (DOrtExternalInitializerInfo_GetByteSize)Marshal.GetDelegateForFunctionPointer(api_.ExternalInitializerInfo_GetByteSize, typeof(DOrtExternalInitializerInfo_GetByteSize));
			OrtGetModelCompatibilityForEpDevices = (DOrtGetModelCompatibilityForEpDevices)Marshal.GetDelegateForFunctionPointer(api_.GetModelCompatibilityForEpDevices, typeof(DOrtGetModelCompatibilityForEpDevices));
			OrtCreateExternalInitializerInfo = (DOrtCreateExternalInitializerInfo)Marshal.GetDelegateForFunctionPointer(api_.CreateExternalInitializerInfo, typeof(DOrtCreateExternalInitializerInfo));
			OrtGetNumHardwareDevices = (DOrtGetNumHardwareDevices)Marshal.GetDelegateForFunctionPointer(api_.GetNumHardwareDevices, typeof(DOrtGetNumHardwareDevices));
			OrtGetHardwareDevices = (DOrtGetHardwareDevices)Marshal.GetDelegateForFunctionPointer(api_.GetHardwareDevices, typeof(DOrtGetHardwareDevices));
			OrtGetHardwareDeviceEpIncompatibilityDetails = (DOrtGetHardwareDeviceEpIncompatibilityDetails)Marshal.GetDelegateForFunctionPointer(api_.GetHardwareDeviceEpIncompatibilityDetails, typeof(DOrtGetHardwareDeviceEpIncompatibilityDetails));
			OrtDeviceEpIncompatibilityDetails_GetReasonsBitmask = (DOrtDeviceEpIncompatibilityDetails_GetReasonsBitmask)Marshal.GetDelegateForFunctionPointer(api_.DeviceEpIncompatibilityDetails_GetReasonsBitmask, typeof(DOrtDeviceEpIncompatibilityDetails_GetReasonsBitmask));
			OrtDeviceEpIncompatibilityDetails_GetNotes = (DOrtDeviceEpIncompatibilityDetails_GetNotes)Marshal.GetDelegateForFunctionPointer(api_.DeviceEpIncompatibilityDetails_GetNotes, typeof(DOrtDeviceEpIncompatibilityDetails_GetNotes));
			OrtDeviceEpIncompatibilityDetails_GetErrorCode = (DOrtDeviceEpIncompatibilityDetails_GetErrorCode)Marshal.GetDelegateForFunctionPointer(api_.DeviceEpIncompatibilityDetails_GetErrorCode, typeof(DOrtDeviceEpIncompatibilityDetails_GetErrorCode));
			OrtReleaseDeviceEpIncompatibilityDetails = (DOrtReleaseDeviceEpIncompatibilityDetails)Marshal.GetDelegateForFunctionPointer(api_.ReleaseDeviceEpIncompatibilityDetails, typeof(DOrtReleaseDeviceEpIncompatibilityDetails));
			OrtCreateSharedAllocator = (DOrtCreateSharedAllocator)Marshal.GetDelegateForFunctionPointer(api_.CreateSharedAllocator, typeof(DOrtCreateSharedAllocator));
			OrtGetSharedAllocator = (DOrtGetSharedAllocator)Marshal.GetDelegateForFunctionPointer(api_.GetSharedAllocator, typeof(DOrtGetSharedAllocator));
			OrtReleaseSharedAllocator = (DOrtReleaseSharedAllocator)Marshal.GetDelegateForFunctionPointer(api_.ReleaseSharedAllocator, typeof(DOrtReleaseSharedAllocator));
			OrtCreateSyncStreamForEpDevice = (DOrtCreateSyncStreamForEpDevice)Marshal.GetDelegateForFunctionPointer(api_.CreateSyncStreamForEpDevice, typeof(DOrtCreateSyncStreamForEpDevice));
			OrtSyncStream_GetHandle = (DOrtSyncStream_GetHandle)Marshal.GetDelegateForFunctionPointer(api_.SyncStream_GetHandle, typeof(DOrtSyncStream_GetHandle));
			OrtReleaseSyncStream = (DOrtReleaseSyncStream)Marshal.GetDelegateForFunctionPointer(api_.ReleaseSyncStream, typeof(DOrtReleaseSyncStream));
			OrtCopyTensors = (DOrtCopyTensors)Marshal.GetDelegateForFunctionPointer(api_.CopyTensors, typeof(DOrtCopyTensors));
			OrtGetCompatibilityInfoFromModel = (DOrtGetCompatibilityInfoFromModel)Marshal.GetDelegateForFunctionPointer(api_.GetCompatibilityInfoFromModel, typeof(DOrtGetCompatibilityInfoFromModel));
			OrtGetCompatibilityInfoFromModelBytes = (DOrtGetCompatibilityInfoFromModelBytes)Marshal.GetDelegateForFunctionPointer(api_.GetCompatibilityInfoFromModelBytes, typeof(DOrtGetCompatibilityInfoFromModelBytes));
		}

		[UnconditionalSuppressMessage("SingleFile", "IL3000:Avoid accessing Assembly file path when publishing as a single file", Justification = "We also check AppContext.BaseDirectory as a fallback")]
		private static nint DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
		{
			try
			{
				if (libraryName == "onnxruntime" || libraryName == "ortextensions")
				{
					string text = null;
					if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
					{
						text = libraryName + ".dll";
					}
					else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
					{
						text = "lib" + libraryName + ".so";
					}
					else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
					{
						text = "lib" + libraryName + ".dylib";
					}
					if (text != null)
					{
						if (NativeLibrary.TryLoad(text, assembly, searchPath, out var handle))
						{
							return handle;
						}
						string text2 = null;
						try
						{
							text2 = assembly.Location;
						}
						catch
						{
						}
						if (!string.IsNullOrEmpty(text2))
						{
							string directoryName = Path.GetDirectoryName(text2);
							string runtimeIdentifier = RuntimeInformation.RuntimeIdentifier;
							string[] array;
							if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
							{
								array = new string[3] { runtimeIdentifier, "win-x64", "win-arm64" };
							}
							else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
							{
								array = new string[3] { runtimeIdentifier, "linux-x64", "linux-arm64" };
							}
							else
							{
								array = ((!RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) ? new string[1] { runtimeIdentifier } : new string[3] { runtimeIdentifier, "osx-arm64", "osx-x64" });
							}
							string[] array2 = array;
							foreach (string text3 in array2)
							{
								string text4 = Path.Combine(new string[5] { directoryName, "runtimes", text3, "native", text });
								if (File.Exists(text4) && NativeLibrary.TryLoad(text4, assembly, searchPath, out handle))
								{
									LogLibLoad("[DllImportResolver] Loaded " + text + " from: " + text4);
									return handle;
								}
							}
						}
						try
						{
							string baseDirectory = AppContext.BaseDirectory;
							if (!string.IsNullOrEmpty(baseDirectory))
							{
								string text5 = Path.Combine(baseDirectory, text);
								if (NativeLibrary.TryLoad(text5, assembly, searchPath, out handle))
								{
									LogLibLoad("[DllImportResolver] Loaded " + text + " from: " + text5);
									return handle;
								}
								string runtimeIdentifier2 = RuntimeInformation.RuntimeIdentifier;
								text5 = Path.Combine(new string[5] { baseDirectory, "runtimes", runtimeIdentifier2, "native", text });
								if (NativeLibrary.TryLoad(text5, assembly, searchPath, out handle))
								{
									LogLibLoad("[DllImportResolver] Loaded " + text + " from: " + text5);
									return handle;
								}
							}
						}
						catch
						{
						}
						LogLibLoad($"[DllImportResolver] Failed loading {text} (RID: {RuntimeInformation.RuntimeIdentifier}, Assembly: {text2})");
					}
				}
			}
			catch (Exception value)
			{
				try
				{
					Trace.WriteLine($"[DllImportResolver] Exception during resolution: {value}");
				}
				catch
				{
				}
			}
			return IntPtr.Zero;
		}

		private static void LogLibLoad(string message)
		{
			Trace.WriteLine(message);
			if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ORT_LOADER_VERBOSITY")))
			{
				Console.WriteLine(message);
			}
		}

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern ref OrtApiBase OrtGetApiBase();

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_CPU(nint options, int use_arena);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_CoreML(nint options, uint coreml_flags);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_Dnnl(nint options, int use_arena);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_CUDA(nint options, int device_id);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_ROCM(nint options, int device_id);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_DML(nint options, int device_id);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_OpenVINO(nint options, byte[] device_id);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_Tensorrt(nint options, int device_id);

		[DllImport("onnxruntime", CharSet = CharSet.Ansi)]
		public static extern nint OrtSessionOptionsAppendExecutionProvider_MIGraphX(nint options, int device_id);
	}
	internal static class OrtExtensionsNativeMethods
	{
		internal const string ExtensionsDllName = "ortextensions";

		[DllImport("ortextensions", CharSet = CharSet.Ansi)]
		public static extern nint RegisterCustomOps(nint sessionOptions, ref OrtApiBase ortApiBase);
	}
	internal static class NativeOnnxValueHelper
	{
		internal static byte[] StringToZeroTerminatedUtf8(string s)
		{
			byte[] array = new byte[Encoding.UTF8.GetByteCount(s) + 1];
			Encoding.UTF8.GetBytes(s, 0, s.Length, array, 0);
			array[^1] = 0;
			return array;
		}

		internal unsafe static void StringToUtf8NativeMemory(char* strPtr, int strLength, nint ptr, int nativeBufferSize)
		{
			int bytes = Encoding.UTF8.GetBytes(strPtr, strLength, (byte*)ptr, nativeBufferSize);
			if (bytes != nativeBufferSize)
			{
				throw new OnnxRuntimeException(ErrorCode.RuntimeException, $"Failed to convert to UTF8. Expected bytes: {nativeBufferSize}, written: {bytes}");
			}
		}

		internal unsafe static string StringFromNativeUtf8(nint nativeUtf8, OrtAllocator allocator = null)
		{
			try
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
			finally
			{
				allocator?.FreeMemory(nativeUtf8);
			}
		}

		internal unsafe static void StringAndUtf8FromNative(OrtAllocator allocator, nint nativeUtf8, out string str, out nint utf8)
		{
			try
			{
				int i;
				for (i = 0; *(byte*)(nativeUtf8 + i) != 0; i++)
				{
				}
				if (i == 0)
				{
					str = string.Empty;
					utf8 = IntPtr.Zero;
					return;
				}
				Span<byte> span = new Span<byte>(((IntPtr)nativeUtf8).ToPointer(), i);
				utf8 = Marshal.AllocHGlobal(i + 1);
				try
				{
					Span<byte> destination = new Span<byte>(((IntPtr)utf8).ToPointer(), i + 1);
					span.CopyTo(destination);
					destination[i] = 0;
					byte* bytes = (byte*)nativeUtf8;
					str = Encoding.UTF8.GetString(bytes, i);
				}
				catch (Exception)
				{
					Marshal.FreeHGlobal(utf8);
					throw;
				}
			}
			finally
			{
				allocator.FreeMemory(nativeUtf8);
			}
		}

		internal static byte[] GetPlatformSerializedString(string str)
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				return Encoding.Unicode.GetBytes(str + "\0");
			}
			return StringToZeroTerminatedUtf8(str);
		}

		internal unsafe static string StringFromNativePathString(nint strPtr)
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				if (strPtr == IntPtr.Zero)
				{
					return string.Empty;
				}
				int i;
				for (i = 0; Marshal.ReadInt16(strPtr, i * 2) != 0; i++)
				{
				}
				if (i == 0)
				{
					return string.Empty;
				}
				return Encoding.Unicode.GetString((byte*)strPtr, i * 2);
			}
			return StringFromNativeUtf8(strPtr);
		}
	}
	internal ref struct DisposableArray<T> where T : IDisposable
	{
		internal Span<T> Span { get; private set; }

		internal DisposableArray(Span<T> disposables)
		{
			Span = disposables;
		}

		public void Dispose()
		{
			for (int num = Span.Length - 1; num >= 0; num--)
			{
				ref T reference = ref Span[num];
				T val = default;
				if (val == null)
				{
					val = reference;
					reference = ref val;
					if (val == null)
					{
						continue;
					}
				}
				reference.Dispose();
			}
		}
	}
	internal ref struct DisposableOrtValueHandleArray
	{
		internal Span<nint> Span { get; private set; }

		internal DisposableOrtValueHandleArray(Span<nint> handles)
		{
			Span = handles;
		}

		public void Dispose()
		{
			for (int num = Span.Length - 1; num >= 0; num--)
			{
				if (Span[num] != IntPtr.Zero)
				{
					NativeMethods.OrtReleaseValue(Span[num]);
				}
			}
		}
	}
	public struct MarshaledString : IDisposable
	{
		internal int Length { get; private set; }

		internal nint Value { get; private set; }

		internal unsafe MarshaledString(string input)
		{
			int num;
			nint value;
			if (input == null)
			{
				num = 0;
				value = IntPtr.Zero;
			}
			else
			{
				byte[] obj = ((input.Length != 0) ? Encoding.UTF8.GetBytes(input) : ArrayUtilities.GetEmpty<byte>());
				num = obj.Length;
				value = Marshal.AllocHGlobal(num + 1);
				Span<byte> destination = new Span<byte>(((IntPtr)value).ToPointer(), num + 1);
				obj.AsSpan(0, num).CopyTo(destination);
				destination[num] = 0;
			}
			Length = num;
			Value = value;
		}

		public void Dispose()
		{
			if (Value != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(Value);
				Value = IntPtr.Zero;
				Length = 0;
			}
		}
	}
	public ref struct MarshaledStringArray
	{
		private MarshaledString[] _values;

		internal ReadOnlySpan<MarshaledString> Values => _values;

		internal MarshaledStringArray(Microsoft.ML.OnnxRuntime.Tensors.Tensor<string> inputs)
		{
			if (inputs.Length == 0L)
			{
				_values = null;
				return;
			}
			_values = new MarshaledString[inputs.Length];
			for (int i = 0; i < inputs.Length; i++)
			{
				_values[i] = new MarshaledString(inputs.GetValue(i));
			}
		}

		internal MarshaledStringArray(IEnumerable<string> inputs)
		{
			if (inputs == null)
			{
				_values = null;
				return;
			}
			_values = new MarshaledString[inputs.Count()];
			int num = 0;
			foreach (string input in inputs)
			{
				_values[num++] = new MarshaledString(input);
			}
		}

		internal void Fill(nint[] pDestination)
		{
			if (_values != null)
			{
				for (int i = 0; i < _values.Length; i++)
				{
					pDestination[i] = Values[i].Value;
				}
			}
		}

		public void Dispose()
		{
			if (_values != null)
			{
				for (int i = 0; i < _values.Length; i++)
				{
					_values[i].Dispose();
				}
				_values = null;
			}
		}
	}
	internal class ProviderOptionsUpdater
	{
		internal static void Update(Dictionary<string, string> providerOptions, nint handle, Func<nint, nint[], nint[], nuint, nint> updateFunc)
		{
			MarshaledStringArray marshaledStringArray = default;
			MarshaledStringArray marshaledStringArray2 = default;
			try
			{
				marshaledStringArray = new MarshaledStringArray(providerOptions.Keys);
				marshaledStringArray2 = new MarshaledStringArray(providerOptions.Values);
				nint[] array = new nint[providerOptions.Count];
				marshaledStringArray.Fill(array);
				nint[] array2 = new nint[providerOptions.Count];
				marshaledStringArray2.Fill(array2);
				NativeApiStatus.VerifySuccess(updateFunc(handle, array, array2, (nuint)providerOptions.Count));
			}
			finally
			{
				marshaledStringArray.Dispose();
				marshaledStringArray2.Dispose();
			}
		}
	}
	public enum OrtAllocatorType
	{
		DeviceAllocator,
		ArenaAllocator
	}
	public enum OrtMemType
	{
		CpuInput = -2,
		CpuOutput = -1,
		Cpu = CpuOutput,
		Default = 0
	}
	public enum OrtDeviceMemoryType
	{
		DEFAULT = 0,
		HOST_ACCESSIBLE = 5
	}
	public enum OrtMemoryInfoDeviceType
	{
		CPU,
		GPU,
		FPGA,
		NPU
	}
	public class OrtArenaCfg : SafeHandle
	{
		internal nint Pointer => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtArenaCfg(uint maxMemory, int arenaExtendStrategy, int initialChunkSizeBytes, int maxDeadBytesPerChunk)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateArenaCfg(maxMemory, arenaExtendStrategy, initialChunkSizeBytes, maxDeadBytesPerChunk, out handle));
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseArenaCfg(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtMemoryInfo : SafeHandle
	{
		private static readonly Lazy<OrtMemoryInfo> _defaultCpuAllocInfo = new Lazy<OrtMemoryInfo>(CreateCpuMemoryInfo);

		private readonly bool _owned;

		public static readonly byte[] allocatorCPU = Encoding.UTF8.GetBytes("Cpu\0");

		public static readonly byte[] allocatorCUDA = Encoding.UTF8.GetBytes("Cuda\0");

		public static readonly byte[] allocatorCUDA_PINNED = Encoding.UTF8.GetBytes("CudaPinned\0");

		public static readonly byte[] allocatorHIP = Encoding.UTF8.GetBytes("Hip\0");

		public static readonly byte[] allocatorHIP_PINNED = Encoding.UTF8.GetBytes("HipPinned\0");

		public static OrtMemoryInfo DefaultInstance => _defaultCpuAllocInfo.Value;

		internal nint Pointer => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public string Name
		{
			get
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtMemoryInfoGetName(handle, out var name));
				return NativeOnnxValueHelper.StringFromNativeUtf8(name);
			}
		}

		public int Id
		{
			get
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtMemoryInfoGetId(handle, out var id));
				return id;
			}
		}

		private static OrtMemoryInfo CreateCpuMemoryInfo()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateCpuMemoryInfo(OrtAllocatorType.DeviceAllocator, OrtMemType.CpuOutput, out var allocatorInfo));
			return new OrtMemoryInfo(allocatorInfo, owned: true);
		}

		internal OrtMemoryInfo(nint allocInfo, bool owned)
			: base(allocInfo, ownsHandle: true)
		{
			_owned = owned;
		}

		public OrtMemoryInfo(byte[] utf8AllocatorName, OrtAllocatorType allocatorType, int deviceId, OrtMemType memoryType)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateMemoryInfo(utf8AllocatorName, allocatorType, deviceId, memoryType, out handle));
			_owned = true;
		}

		public OrtMemoryInfo(string allocatorName, OrtAllocatorType allocatorType, int deviceId, OrtMemType memoryType)
			: this(NativeOnnxValueHelper.StringToZeroTerminatedUtf8(allocatorName), allocatorType, deviceId, memoryType)
		{
		}

		public OrtMemoryInfo(string allocatorName, OrtMemoryInfoDeviceType deviceType, uint vendorId, int deviceId, OrtDeviceMemoryType deviceMemoryType, ulong alignment, OrtAllocatorType allocatorType)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateMemoryInfoV2(NativeOnnxValueHelper.StringToZeroTerminatedUtf8(allocatorName), deviceType, vendorId, deviceId, deviceMemoryType, (nuint)alignment, allocatorType, out handle));
		}

		public OrtMemType GetMemoryType()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtMemoryInfoGetMemType(handle, out var mem_type));
			return mem_type;
		}

		public OrtAllocatorType GetAllocatorType()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtMemoryInfoGetType(handle, out var alloc_type));
			return alloc_type;
		}

		public OrtDeviceMemoryType GetDeviceMemoryType()
		{
			return NativeMethods.OrtMemoryInfoGetDeviceMemType(handle);
		}

		public uint GetVendorId()
		{
			return NativeMethods.OrtMemoryInfoGetVendorId(handle);
		}

		public override bool Equals(object obj)
		{
			if (!(obj is OrtMemoryInfo other))
			{
				return false;
			}
			return Equals(other);
		}

		public bool Equals(OrtMemoryInfo other)
		{
			if (this == other)
			{
				return true;
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCompareMemoryInfo(handle, other.Pointer, out var result));
			return result == 0;
		}

		public override int GetHashCode()
		{
			return ((IntPtr)Pointer).ToInt32();
		}

		protected override bool ReleaseHandle()
		{
			if (_owned)
			{
				NativeMethods.OrtReleaseMemoryInfo(handle);
			}
			handle = IntPtr.Zero;
			return true;
		}
	}
	[Obsolete("Create OrtValue over an arbitrary piece of memory and use it where appropriate.")]
	public class OrtExternalAllocation
	{
		public OrtMemoryInfo Info { get; private set; }

		public long[] Shape { get; private set; }

		public TensorElementType ElementType { get; private set; }

		public nint Pointer { get; private set; }

		public long Size { get; private set; }

		public OrtExternalAllocation(OrtMemoryInfo memInfo, long[] shape, TensorElementType elementType, nint pointer, long sizeInBytes)
		{
			TensorElementTypeInfo tensorElementTypeInfo = TensorBase.GetElementTypeInfo(elementType) ?? throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Tensor element type: {elementType} is not supported");
			if (tensorElementTypeInfo.IsString)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Strings are not supported by this API");
			}
			long sizeForShape = ShapeUtils.GetSizeForShape(shape);
			long num = sizeForShape * tensorElementTypeInfo.TypeSize;
			if (num > sizeInBytes)
			{
				string message = $"Shape of {sizeForShape} elements requires a buffer of at least {num} bytes. Provided: {sizeInBytes} bytes";
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, message);
			}
			Info = memInfo;
			Shape = shape;
			ElementType = elementType;
			Pointer = pointer;
			Size = sizeInBytes;
		}
	}
	public class OrtMemoryAllocation : SafeHandle
	{
		private OrtAllocator _allocator;

		internal nint Pointer => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public uint Size { get; private set; }

		public OrtMemoryInfo Info => _allocator.Info;

		internal OrtMemoryAllocation(OrtAllocator allocator, nint pointer, uint size)
			: base(pointer, ownsHandle: true)
		{
			_allocator = allocator;
			Size = size;
		}

		protected override bool ReleaseHandle()
		{
			_allocator.FreeMemory(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtAllocator : SafeHandle
	{
		private static readonly Lazy<OrtAllocator> _defaultInstance = new Lazy<OrtAllocator>(GetDefaultCpuAllocator);

		private readonly bool _owned;

		public static OrtAllocator DefaultInstance => _defaultInstance.Value;

		internal nint Pointer => handle;

		public OrtMemoryInfo Info
		{
			get
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtAllocatorGetInfo(handle, out var info));
				return new OrtMemoryInfo(info, owned: false);
			}
		}

		public override bool IsInvalid => handle == IntPtr.Zero;

		private static OrtAllocator GetDefaultCpuAllocator()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetAllocatorWithDefaultOptions(out var allocator));
			return new OrtAllocator(allocator, owned: false);
		}

		internal OrtAllocator(nint allocator, bool owned)
			: base(allocator, ownsHandle: true)
		{
			_owned = owned;
		}

		public OrtAllocator(InferenceSession session, OrtMemoryInfo memInfo)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateAllocator(session.Handle, memInfo.Pointer, out handle));
			_owned = true;
		}

		public OrtMemoryAllocation Allocate(uint size)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtAllocatorAlloc(handle, size, out var p));
			return new OrtMemoryAllocation(this, p, size);
		}

		internal void FreeMemory(nint allocation)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtAllocatorFree(handle, allocation));
		}

		protected override bool ReleaseHandle()
		{
			if (_owned)
			{
				NativeMethods.OrtReleaseAllocator(handle);
			}
			handle = IntPtr.Zero;
			return true;
		}
	}
	public enum OrtCompiledModelCompatibility
	{
		EP_NOT_APPLICABLE,
		EP_SUPPORTED_OPTIMAL,
		EP_SUPPORTED_PREFER_RECOMPILATION,
		EP_UNSUPPORTED
	}
	[Flags]
	public enum OrtDeviceEpIncompatibilityReason : uint
	{
		None = 0u,
		DriverIncompatible = 1u,
		DeviceIncompatible = 2u,
		MissingDependency = 4u,
		Unknown = 0x80000000u
	}
	public delegate void DOrtLoggingFunction(nint param, OrtLoggingLevel severity, string category, string logId, string codeLocation, string message);
	public struct EnvironmentCreationOptions
	{
		public string logId;

		public OrtLoggingLevel? logLevel;

		public OrtThreadingOptions threadOptions;

		public nint? loggingParam;

		public DOrtLoggingFunction loggingFunction;
	}
	public sealed class OrtEnv : SafeHandle
	{
		private delegate void DOrtLoggingFunctionInternal(nint param, nint severity, nint category, nint logid, nint codeLocation, nint message);

		private static readonly int ORT_PROJECTION_CSHARP = 2;

		private static readonly byte[] _defaultLogId = NativeOnnxValueHelper.StringToZeroTerminatedUtf8("CSharpOnnxRuntime");

		private static EnvironmentCreationOptions? _createOptions;

		private static Lazy<OrtEnv> _instance = new Lazy<OrtEnv>(CreateInstance);

		private static readonly DOrtLoggingFunctionInternal _loggingFunctionInternal = LoggingFunctionThunk;

		private static DOrtLoggingFunction _userLoggingFunction;

		private OrtLoggingLevel _envLogLevel;

		public static bool DisableDllImportResolver { get; set; } = false;

		public static bool IsCreated => _instance.IsValueCreated;

		public OrtLoggingLevel EnvLogLevel
		{
			get
			{
				return _envLogLevel;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtUpdateEnvWithCustomLogLevel(Handle, value));
				_envLogLevel = value;
			}
		}

		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		private OrtEnv(nint handle, OrtLoggingLevel logLevel)
			: base(handle, ownsHandle: true)
		{
			_envLogLevel = logLevel;
		}

		private static void LoggingFunctionThunk(nint param, nint severity, nint category, nint logid, nint codeLocation, nint message)
		{
			string category2 = NativeOnnxValueHelper.StringFromNativeUtf8(category);
			string logId = NativeOnnxValueHelper.StringFromNativeUtf8(logid);
			string codeLocation2 = NativeOnnxValueHelper.StringFromNativeUtf8(codeLocation);
			string message2 = NativeOnnxValueHelper.StringFromNativeUtf8(message);
			_userLoggingFunction(param, (OrtLoggingLevel)severity, category2, logId, codeLocation2, message2);
		}

		private static OrtEnv CreateInstance()
		{
			OrtEnv ortEnv = null;
			if (!_createOptions.HasValue)
			{
				return CreateDefaultEnv(OrtLoggingLevel.ORT_LOGGING_LEVEL_WARNING, _defaultLogId);
			}
			EnvironmentCreationOptions value = _createOptions.Value;
			byte[] logIdUtf = (string.IsNullOrEmpty(value.logId) ? _defaultLogId : NativeOnnxValueHelper.StringToZeroTerminatedUtf8(value.logId));
			OrtLoggingLevel logLevel = value.logLevel ?? OrtLoggingLevel.ORT_LOGGING_LEVEL_WARNING;
			OrtThreadingOptions threadOptions = value.threadOptions;
			DOrtLoggingFunction loggingFunction = value.loggingFunction;
			nint num = value.loggingParam ?? IntPtr.Zero;
			if (threadOptions == null && loggingFunction == null)
			{
				return CreateDefaultEnv(logLevel, logIdUtf);
			}
			if (threadOptions == null)
			{
				return CreateWithCustomLogger(logLevel, logIdUtf, num, loggingFunction);
			}
			if (loggingFunction == null)
			{
				return CreateWithThreadingOptions(logLevel, logIdUtf, threadOptions);
			}
			return CreateEnvWithCustomLoggerAndGlobalThreadPools(logLevel, logIdUtf, num, threadOptions, loggingFunction);
		}

		private static OrtEnv CreateDefaultEnv(OrtLoggingLevel logLevel, byte[] logIdUtf8)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateEnv(logLevel, logIdUtf8, out var env));
			OrtEnv ortEnv = new OrtEnv(env, logLevel);
			SetLanguageProjection(ortEnv);
			return ortEnv;
		}

		private static OrtEnv CreateWithCustomLogger(OrtLoggingLevel logLevel, byte[] logIdUtf8, nint loggerParam, DOrtLoggingFunction loggingFunction)
		{
			_userLoggingFunction = loggingFunction;
			nint functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(_loggingFunctionInternal);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateEnvWithCustomLogger(functionPointerForDelegate, loggerParam, logLevel, logIdUtf8, out var env));
			OrtEnv ortEnv = new OrtEnv(env, logLevel);
			SetLanguageProjection(ortEnv);
			return ortEnv;
		}

		private static OrtEnv CreateWithThreadingOptions(OrtLoggingLevel logLevel, byte[] logIdUtf8, OrtThreadingOptions threadingOptions)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateEnvWithGlobalThreadPools(logLevel, logIdUtf8, threadingOptions.Handle, out var env));
			OrtEnv ortEnv = new OrtEnv(env, logLevel);
			SetLanguageProjection(ortEnv);
			return ortEnv;
		}

		private static OrtEnv CreateEnvWithCustomLoggerAndGlobalThreadPools(OrtLoggingLevel logLevel, byte[] logIdUtf8, nint logParam, OrtThreadingOptions threadingOptions, DOrtLoggingFunction loggingFunction)
		{
			_userLoggingFunction = loggingFunction;
			nint functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(_loggingFunctionInternal);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateEnvWithCustomLoggerAndGlobalThreadPools(functionPointerForDelegate, logParam, logLevel, logIdUtf8, threadingOptions.Handle, out var env));
			OrtEnv ortEnv = new OrtEnv(env, logLevel);
			SetLanguageProjection(ortEnv);
			return ortEnv;
		}

		private static void SetLanguageProjection(OrtEnv env)
		{
			try
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetLanguageProjection(env.Handle, ORT_PROJECTION_CSHARP));
			}
			catch (Exception)
			{
				env.Dispose();
				throw;
			}
		}

		public static OrtEnv Instance()
		{
			return _instance.Value;
		}

		public static OrtEnv CreateInstanceWithOptions(ref EnvironmentCreationOptions options)
		{
			if (_instance.IsValueCreated)
			{
				throw new OnnxRuntimeException(ErrorCode.RuntimeException, "OrtEnv singleton instance already exists, supplied options would not have effect");
			}
			_createOptions = options;
			return _instance.Value;
		}

		public void EnableTelemetryEvents()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtEnableTelemetryEvents(Handle));
		}

		public void DisableTelemetryEvents()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtDisableTelemetryEvents(Handle));
		}

		public void CreateAndRegisterAllocator(OrtMemoryInfo memInfo, OrtArenaCfg arenaCfg)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateAndRegisterAllocator(Handle, memInfo.Pointer, arenaCfg.Pointer));
		}

		public void CreateAndRegisterAllocator(string providerType, OrtMemoryInfo memInfo, OrtArenaCfg arenaCfg, IReadOnlyDictionary<string, string> provider_options)
		{
			MarshaledStringArray marshaledStringArray = default;
			MarshaledStringArray marshaledStringArray2 = default;
			nint[] array = new nint[provider_options.Count];
			nint[] array2 = new nint[provider_options.Count];
			try
			{
				marshaledStringArray = new MarshaledStringArray(provider_options.Keys);
				marshaledStringArray2 = new MarshaledStringArray(provider_options.Values);
				marshaledStringArray.Fill(array);
				marshaledStringArray2.Fill(array2);
				using MarshaledString marshaledString = new MarshaledString(providerType);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateAndRegisterAllocatorV2(Handle, marshaledString.Value, memInfo.Pointer, arenaCfg.Pointer, array, array2, (nuint)provider_options.Count));
			}
			finally
			{
				marshaledStringArray2.Dispose();
				marshaledStringArray.Dispose();
			}
		}

		public void UnregisterAllocator(OrtMemoryInfo memInfo)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtUnregisterAllocator(Handle, memInfo.Pointer));
		}

		public OrtAllocator CreateSharedAllocator(OrtEpDevice epDevice, OrtDeviceMemoryType deviceMemoryType, OrtAllocatorType ortAllocatorType, IReadOnlyDictionary<string, string> allocatorOptions)
		{
			using OrtKeyValuePairs ortKeyValuePairs = new OrtKeyValuePairs(allocatorOptions);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateSharedAllocator(Handle, epDevice.Handle, deviceMemoryType, ortAllocatorType, ortKeyValuePairs.Handle, out var allocator));
			return new OrtAllocator(allocator, owned: false);
		}

		public OrtAllocator GetSharedAllocator(OrtMemoryInfo memoryInfo)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetSharedAllocator(Handle, memoryInfo.Pointer, out var allocator));
			if (allocator == IntPtr.Zero)
			{
				return null;
			}
			return new OrtAllocator(allocator, owned: false);
		}

		public void ReleaseSharedAllocator(OrtEpDevice epDevice, OrtDeviceMemoryType deviceMemoryType)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtReleaseSharedAllocator(Handle, epDevice.Handle, deviceMemoryType));
		}

		public string GetVersionString()
		{
			return NativeOnnxValueHelper.StringFromNativeUtf8(NativeMethods.OrtGetVersionString());
		}

		public string[] GetAvailableProviders()
		{
			nint providers = IntPtr.Zero;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetAvailableProviders(out providers, out var numProviders));
			try
			{
				string[] array = new string[numProviders];
				for (int i = 0; i < numProviders; i++)
				{
					array[i] = NativeOnnxValueHelper.StringFromNativeUtf8(Marshal.ReadIntPtr(providers, IntPtr.Size * i));
				}
				return array;
			}
			finally
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtReleaseAvailableProviders(providers, numProviders));
			}
		}

		public OrtCompiledModelCompatibility GetModelCompatibilityForEpDevices(IReadOnlyList<OrtEpDevice> epDevices, string compatibilityInfo)
		{
			if (epDevices == null || epDevices.Count == 0)
			{
				throw new ArgumentException("epDevices must be non-empty", "epDevices");
			}
			nint[] array = new nint[epDevices.Count];
			for (int i = 0; i < epDevices.Count; i++)
			{
				array[i] = epDevices[i].Handle;
			}
			byte[] compatibility_info = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(compatibilityInfo);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetModelCompatibilityForEpDevices(array, (nuint)array.Length, compatibility_info, out var out_status));
			return (OrtCompiledModelCompatibility)out_status;
		}

		public string GetCompatibilityInfoFromModel(string modelPath, string epType)
		{
			if (string.IsNullOrEmpty(modelPath))
			{
				throw new ArgumentException("modelPath must be non-empty", "modelPath");
			}
			if (string.IsNullOrEmpty(epType))
			{
				throw new ArgumentException("epType must be non-empty", "epType");
			}
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(modelPath);
			byte[] ep_type = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(epType);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetCompatibilityInfoFromModel(platformSerializedString, ep_type, defaultInstance.Pointer, out var compatibility_info));
			if (compatibility_info == IntPtr.Zero)
			{
				return null;
			}
			return NativeOnnxValueHelper.StringFromNativeUtf8(compatibility_info, defaultInstance);
		}

		public string GetCompatibilityInfoFromModelBytes(byte[] modelData, string epType)
		{
			if (modelData == null || modelData.Length == 0)
			{
				throw new ArgumentException("modelData must be non-empty", "modelData");
			}
			if (string.IsNullOrEmpty(epType))
			{
				throw new ArgumentException("epType must be non-empty", "epType");
			}
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			byte[] ep_type = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(epType);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetCompatibilityInfoFromModelBytes(modelData, (nuint)modelData.Length, ep_type, defaultInstance.Pointer, out var compatibility_info));
			if (compatibility_info == IntPtr.Zero)
			{
				return null;
			}
			return NativeOnnxValueHelper.StringFromNativeUtf8(compatibility_info, defaultInstance);
		}

		public int GetNumHardwareDevices()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetNumHardwareDevices(Handle, out var numDevices));
			return checked((int)numDevices);
		}

		public IReadOnlyList<OrtHardwareDevice> GetHardwareDevices()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetNumHardwareDevices(Handle, out var numDevices));
			int num = checked((int)numDevices);
			if (num == 0)
			{
				return Array.Empty<OrtHardwareDevice>();
			}
			nint[] array = new nint[num];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetHardwareDevices(Handle, array, numDevices));
			OrtHardwareDevice[] array2 = new OrtHardwareDevice[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = new OrtHardwareDevice(array[i]);
			}
			return array2;
		}

		public OrtDeviceEpIncompatibilityDetails GetHardwareDeviceEpIncompatibilityDetails(string epName, OrtHardwareDevice hardwareDevice)
		{
			if (epName == null)
			{
				throw new ArgumentNullException("epName");
			}
			if (epName.Length == 0)
			{
				throw new ArgumentException("epName must be non-empty", "epName");
			}
			if (hardwareDevice == null)
			{
				throw new ArgumentNullException("hardwareDevice");
			}
			byte[] epName2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(epName);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetHardwareDeviceEpIncompatibilityDetails(Handle, epName2, hardwareDevice.Handle, out var details));
			return new OrtDeviceEpIncompatibilityDetails(details);
		}

		public void RegisterExecutionProviderLibrary(string registrationName, string libraryPath)
		{
			byte[] registration_name = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(registrationName);
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(libraryPath);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRegisterExecutionProviderLibrary(handle, registration_name, platformSerializedString));
		}

		public void UnregisterExecutionProviderLibrary(string registrationName)
		{
			byte[] registration_name = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(registrationName);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtUnregisterExecutionProviderLibrary(handle, registration_name));
		}

		public IReadOnlyList<OrtEpDevice> GetEpDevices()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetEpDevices(handle, out var ep_devices, out var num_ep_devices));
			int num = (int)num_ep_devices;
			List<OrtEpDevice> list = new List<OrtEpDevice>(num);
			nint[] array = new nint[num];
			Marshal.Copy(ep_devices, array, 0, num);
			nint[] array2 = array;
			foreach (nint epDeviceHandle in array2)
			{
				list.Add(new OrtEpDevice(epDeviceHandle));
			}
			return list.AsReadOnly();
		}

		public void CopyTensors(IReadOnlyList<OrtValue> srcValues, IReadOnlyList<OrtValue> dstValues, OrtSyncStream stream)
		{
			nint stream2 = stream?.Handle ?? IntPtr.Zero;
			nint[] array = new nint[srcValues.Count];
			nint[] array2 = new nint[dstValues.Count];
			for (int i = 0; i < array.Length; i++)
			{
				if (srcValues[i] == null)
				{
					throw new ArgumentNullException($"srcValues[{i}]");
				}
				if (dstValues[i] == null)
				{
					throw new ArgumentNullException($"dstValues[{i}]");
				}
				array[i] = srcValues[i].Handle;
				array2[i] = dstValues[i].Handle;
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCopyTensors(handle, array, array2, stream2, (nuint)array.Length));
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseEnv(handle);
			handle = IntPtr.Zero;
			_instance = new Lazy<OrtEnv>(CreateInstance);
			return true;
		}
	}
	public sealed class OrtDeviceEpIncompatibilityDetails : IDisposable
	{
		private nint _handle;

		private bool _disposed;

		public OrtDeviceEpIncompatibilityReason ReasonsBitmask
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException("OrtDeviceEpIncompatibilityDetails");
				}
				NativeApiStatus.VerifySuccess(NativeMethods.OrtDeviceEpIncompatibilityDetails_GetReasonsBitmask(_handle, out var reasonsBitmask));
				return (OrtDeviceEpIncompatibilityReason)reasonsBitmask;
			}
		}

		public string Notes
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException("OrtDeviceEpIncompatibilityDetails");
				}
				NativeApiStatus.VerifySuccess(NativeMethods.OrtDeviceEpIncompatibilityDetails_GetNotes(_handle, out var notes));
				if (notes == IntPtr.Zero)
				{
					return null;
				}
				return NativeOnnxValueHelper.StringFromNativeUtf8(notes);
			}
		}

		public int ErrorCode
		{
			get
			{
				if (_disposed)
				{
					throw new ObjectDisposedException("OrtDeviceEpIncompatibilityDetails");
				}
				NativeApiStatus.VerifySuccess(NativeMethods.OrtDeviceEpIncompatibilityDetails_GetErrorCode(_handle, out var errorCode));
				return errorCode;
			}
		}

		internal OrtDeviceEpIncompatibilityDetails(nint handle)
		{
			_handle = handle;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (_handle != IntPtr.Zero)
				{
					NativeMethods.OrtReleaseDeviceEpIncompatibilityDetails(_handle);
					_handle = IntPtr.Zero;
				}
				_disposed = true;
			}
		}

		~OrtDeviceEpIncompatibilityDetails()
		{
			Dispose(disposing: false);
		}
	}
	public class OrtSyncStream : SafeHandle
	{
		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		internal OrtSyncStream(nint streamHandle)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			handle = streamHandle;
		}

		public nint GetHandle()
		{
			return NativeMethods.OrtSyncStream_GetHandle(handle);
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseSyncStream(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtEpDevice
	{
		private readonly nint _handle;

		internal nint Handle => _handle;

		public string EpName => NativeOnnxValueHelper.StringFromNativeUtf8(NativeMethods.OrtEpDevice_EpName(_handle));

		public string EpVendor => NativeOnnxValueHelper.StringFromNativeUtf8(NativeMethods.OrtEpDevice_EpVendor(_handle));

		public OrtKeyValuePairs EpMetadata => new OrtKeyValuePairs(NativeMethods.OrtEpDevice_EpMetadata(_handle));

		public OrtKeyValuePairs EpOptions => new OrtKeyValuePairs(NativeMethods.OrtEpDevice_EpOptions(_handle));

		public OrtHardwareDevice HardwareDevice => new OrtHardwareDevice(NativeMethods.OrtEpDevice_Device(_handle));

		internal OrtEpDevice(nint epDeviceHandle)
		{
			_handle = epDeviceHandle;
		}

		public OrtMemoryInfo GetMemoryInfo(OrtDeviceMemoryType deviceMemoryType)
		{
			return new OrtMemoryInfo(NativeMethods.OrtEpDevice_MemoryInfo(_handle, deviceMemoryType), owned: false);
		}

		public OrtSyncStream CreateSyncStream(IReadOnlyDictionary<string, string> streamOptions)
		{
			OrtKeyValuePairs ortKeyValuePairs = null;
			nint streamOptions2 = IntPtr.Zero;
			try
			{
				if (streamOptions != null)
				{
					ortKeyValuePairs = new OrtKeyValuePairs(streamOptions);
					streamOptions2 = ortKeyValuePairs.Handle;
				}
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateSyncStreamForEpDevice(_handle, streamOptions2, out var stream));
				return new OrtSyncStream(stream);
			}
			finally
			{
				ortKeyValuePairs?.Dispose();
			}
		}
	}
	public class OrtExternalInitializerInfo : SafeHandle, IReadOnlyExternalInitializerInfo
	{
		private readonly bool _ownsHandle = true;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtExternalInitializerInfo(string filePath, long fileOffset, long byteSize)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(filePath);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateExternalInitializerInfo(platformSerializedString, fileOffset, (nuint)byteSize, out handle));
			_ownsHandle = true;
		}

		internal OrtExternalInitializerInfo(nint constHandle, bool ownsHandle = false)
			: base(IntPtr.Zero, ownsHandle)
		{
			SetHandle(constHandle);
			_ownsHandle = ownsHandle;
		}

		public string GetFilePath()
		{
			nint num = NativeMethods.OrtExternalInitializerInfo_GetFilePath(handle);
			if (num == IntPtr.Zero)
			{
				return string.Empty;
			}
			return NativeOnnxValueHelper.StringFromNativePathString(num);
		}

		public long GetFileOffset()
		{
			return NativeMethods.OrtExternalInitializerInfo_GetFileOffset(handle);
		}

		public long GetByteSize()
		{
			return checked((long)NativeMethods.OrtExternalInitializerInfo_GetByteSize(handle));
		}

		protected override bool ReleaseHandle()
		{
			if (!_ownsHandle)
			{
				return false;
			}
			NativeMethods.OrtReleaseExternalInitializerInfo(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public interface IReadOnlyExternalInitializerInfo
	{
		string GetFilePath();

		long GetFileOffset();

		long GetByteSize();
	}
	internal class BitOpsUtils
	{
		internal const uint SingleBiasedExponentMask = 2139095040u;

		internal const int SingleBiasedExponentShift = 23;

		internal const uint SingleSignMask = 2147483648u;

		internal const int SingleSignShift = 31;

		internal const uint SingleMostSignificantSigBit = 4194304u;

		internal const uint SingleTrailingSignificandMask = 8388607u;

		internal static int LeadingZeroCount(uint num)
		{
			if (num == 0)
			{
				return 32;
			}
			int num2 = 0;
			while ((num & 0xF0000000u) == 0)
			{
				num2 += 4;
				num <<= 4;
			}
			while ((num & 0x80000000u) == 0)
			{
				num2++;
				num <<= 1;
			}
			return num2;
		}

		internal unsafe static uint SingleToUInt32Bits(float single)
		{
			uint result = default;
			Buffer.MemoryCopy(&single, &result, 4L, 4L);
			return result;
		}

		internal unsafe static float UInt32BitsToSingle(uint singleBits)
		{
			float result = default;
			Buffer.MemoryCopy(&singleBits, &result, 4L, 4L);
			return result;
		}

		internal static ushort SingleBitsToBFloat16Bits(uint singleBits)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return (ushort)(singleBits & 0xFFFF);
			}
			return (ushort)(singleBits >> 16);
		}

		internal static uint BFloat16BitsToSingleBits(ushort bfloatBits)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return bfloatBits;
			}
			return (uint)(bfloatBits << 16);
		}

		internal static float CreateSingleNaN(bool sign, ulong significand)
		{
			uint num = (sign ? 1u : 0u) << 31;
			uint num2 = (uint)(significand >> 41);
			return UInt32BitsToSingle(num | 0x7FC00000 | num2);
		}

		internal static float CreateSingle(bool sign, byte exponent, uint significand)
		{
			uint num = (sign ? 1u : 0u) << 31;
			uint num2 = (uint)(exponent << 23) + significand;
			return UInt32BitsToSingle(num + num2);
		}
	}
	public readonly struct Float16 : IComparable, IComparable<Float16>, IEquatable<Float16>
	{
		internal const ushort SignMask = 32768;

		internal const int SignShift = 15;

		internal const byte ShiftedSignMask = 1;

		internal const ushort BiasedExponentMask = 31744;

		internal const int BiasedExponentShift = 10;

		internal const byte ShiftedBiasedExponentMask = 31;

		internal const ushort TrailingSignificandMask = 1023;

		internal const byte MinSign = 0;

		internal const byte MaxSign = 1;

		internal const byte MinBiasedExponent = 0;

		internal const byte MaxBiasedExponent = 31;

		internal const byte ExponentBias = 15;

		internal const sbyte MinExponent = -14;

		internal const sbyte MaxExponent = 15;

		private const ushort PositiveZeroBits = 0;

		private const ushort NegativeZeroBits = 32768;

		private const ushort OneBits = 15360;

		private const ushort EpsilonBits = 1024;

		private const ushort PositiveInfinityBits = 31744;

		private const ushort NegativeInfinityBits = 64512;

		private const ushort PositiveQNaNBits = 32256;

		private const ushort NegativeQNaNBits = 65024;

		private const ushort MinValueBits = 64511;

		private const ushort MaxValueBits = 31743;

		private const ushort PositiveOneBits = 15360;

		private const ushort NegativeOneBits = 48128;

		private const ushort EBits = 16752;

		private const ushort PiBits = 16968;

		private const ushort TauBits = 17992;

		public readonly ushort value;

		public static Float16 Epsilon => new Float16(1024);

		public static Float16 Pi => new Float16(16968);

		public static Float16 PositiveInfinity => new Float16(31744);

		public static Float16 NegativeInfinity => new Float16(64512);

		public static Float16 NaN => new Float16(65024);

		public static Float16 Zero => new Float16(0);

		public static Float16 One => new Float16(15360);

		public static Float16 NegativeZero => new Float16(32768);

		public static Float16 MinValue => new Float16(64511);

		public static Float16 MaxValue => new Float16(31743);

		internal byte BiasedExponent => ExtractBiasedExponentFromBits(value);

		internal sbyte Exponent => (sbyte)(BiasedExponent - 15);

		internal ushort Significand => (ushort)(TrailingSignificand | ((BiasedExponent != 0) ? 1024 : 0));

		internal ushort TrailingSignificand => ExtractTrailingSignificandFromBits(value);

		public Float16(ushort v)
		{
			value = v;
		}

		private Float16(bool sign, ushort exp, ushort sig)
		{
			value = (ushort)((int)((sign ? 1u : 0u) << 15) + (exp << 10) + sig);
		}

		internal static byte ExtractBiasedExponentFromBits(ushort bits)
		{
			return (byte)((bits >> 10) & 0x1F);
		}

		internal static ushort ExtractTrailingSignificandFromBits(ushort bits)
		{
			return (ushort)(bits & 0x3FF);
		}

		public static bool operator <(Float16 left, Float16 right)
		{
			if (IsNaN(left) || IsNaN(right))
			{
				return false;
			}
			bool flag = IsNegative(left);
			if (flag != IsNegative(right))
			{
				if (flag)
				{
					return !AreZero(left, right);
				}
				return false;
			}
			if (left.value != right.value)
			{
				return (left.value < right.value) ^ flag;
			}
			return false;
		}

		public static bool operator >(Float16 left, Float16 right)
		{
			return right < left;
		}

		public static bool operator <=(Float16 left, Float16 right)
		{
			if (IsNaN(left) || IsNaN(right))
			{
				return false;
			}
			bool flag = IsNegative(left);
			if (flag != IsNegative(right))
			{
				if (!flag)
				{
					return AreZero(left, right);
				}
				return true;
			}
			if (left.value != right.value)
			{
				return (left.value < right.value) ^ flag;
			}
			return true;
		}

		public static bool operator >=(Float16 left, Float16 right)
		{
			return right <= left;
		}

		public static bool operator ==(Float16 left, Float16 right)
		{
			if (IsNaN(left) || IsNaN(right))
			{
				return false;
			}
			return left.value == right.value;
		}

		public static bool operator !=(Float16 left, Float16 right)
		{
			return !(left == right);
		}

		public static bool IsFinite(Float16 value)
		{
			return StripSign(value) < 31744;
		}

		public static bool IsInfinity(Float16 value)
		{
			return StripSign(value) == 31744;
		}

		public static bool IsNaN(Float16 value)
		{
			return StripSign(value) > 31744;
		}

		public static bool IsNegative(Float16 value)
		{
			return (short)value.value < 0;
		}

		public static bool IsNegativeInfinity(Float16 value)
		{
			return value.value == 64512;
		}

		public static bool IsNormal(Float16 value)
		{
			uint num = StripSign(value);
			if (num < 31744 && num != 0)
			{
				return (num & 0x7C00) != 0;
			}
			return false;
		}

		public static bool IsPositiveInfinity(Float16 value)
		{
			return value.value == 31744;
		}

		public static bool IsSubnormal(Float16 value)
		{
			uint num = StripSign(value);
			if (num < 31744 && num != 0)
			{
				return (num & 0x7C00) == 0;
			}
			return false;
		}

		public int CompareTo(object obj)
		{
			if (!(obj is Float16))
			{
				if (obj != null)
				{
					throw new ArgumentException("Object must be of type Float16");
				}
				return 1;
			}
			return CompareTo((Float16)obj);
		}

		public int CompareTo(Float16 other)
		{
			if (this < other)
			{
				return -1;
			}
			if (this > other)
			{
				return 1;
			}
			if (this == other)
			{
				return 0;
			}
			if (IsNaN(this))
			{
				if (!IsNaN(other))
				{
					return -1;
				}
				return 0;
			}
			return 1;
		}

		public bool Equals(Float16 other)
		{
			if (value != other.value && !AreZero(this, other))
			{
				if (IsNaN(this))
				{
					return IsNaN(other);
				}
				return false;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj is Float16 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (IsNaNOrZero(this))
			{
				return value & 0x7C00;
			}
			return value;
		}

		public override string ToString()
		{
			return $"{value} : {ToFloat()}";
		}

		public float ToFloat()
		{
			return (float)this;
		}

		public static explicit operator Float16(float value)
		{
			uint num = BitOpsUtils.SingleToUInt32Bits(value);
			bool flag = (num & 0x80000000u) >> 31 != 0;
			int num2 = (int)(num & 0x7F800000) >> 23;
			uint num3 = num & 0x7FFFFF;
			if (num2 == 255)
			{
				if (num3 != 0)
				{
					return CreateFloat16NaN(flag, (ulong)num3 << 41);
				}
				if (!flag)
				{
					return PositiveInfinity;
				}
				return NegativeInfinity;
			}
			uint num4 = (num3 >> 9) | (((num3 & 0x1FF) != 0) ? 1u : 0u);
			if (((uint)num2 | num4) == 0)
			{
				return new Float16(flag, 0, 0);
			}
			return new Float16(RoundPackToFloat16(flag, (short)(num2 - 113), (ushort)(num4 | 0x4000)));
		}

		public static explicit operator float(Float16 value)
		{
			bool flag = IsNegative(value);
			int num = value.BiasedExponent;
			uint num2 = value.TrailingSignificand;
			switch (num)
			{
			case 31:
				if (num2 != 0)
				{
					return BitOpsUtils.CreateSingleNaN(flag, (ulong)num2 << 54);
				}
				if (!flag)
				{
					return float.PositiveInfinity;
				}
				return float.NegativeInfinity;
			case 0:
			{
				if (num2 == 0)
				{
					if (!flag)
					{
						return 0f;
					}
					return -0f;
				}
				(int Exp, uint Sig) tuple = NormSubnormalF16Sig(num2);
				num = tuple.Exp;
				num2 = tuple.Sig;
				num--;
				break;
			}
			}
			return BitOpsUtils.CreateSingle(flag, (byte)(num + 112), num2 << 13);
		}

		public static Float16 Negate(Float16 value)
		{
			if (!IsNaN(value))
			{
				return new Float16((ushort)(value.value ^ 0x8000));
			}
			return value;
		}

		private static bool AreZero(Float16 left, Float16 right)
		{
			return (ushort)((left.value | right.value) & -32769) == 0;
		}

		public static bool IsNaNOrZero(Float16 value)
		{
			uint num = StripSign(value);
			if (num != 0)
			{
				return num > 31744;
			}
			return true;
		}

		private static uint StripSign(Float16 value)
		{
			return (ushort)(value.value & -32769);
		}

		private static (int Exp, uint Sig) NormSubnormalF16Sig(uint sig)
		{
			int num = BitOpsUtils.LeadingZeroCount(sig) - 16 - 5;
			return (Exp: 1 - num, Sig: sig << num);
		}

		private static Float16 CreateFloat16NaN(bool sign, ulong significand)
		{
			uint num = (sign ? 1u : 0u) << 15;
			ushort num2 = (ushort)(significand >> 54);
			return new Float16((ushort)(num | 0x7E00 | num2));
		}

		private static ushort RoundPackToFloat16(bool sign, short exp, ushort sig)
		{
			int num = sig & 0xF;
			if ((uint)exp >= 29u)
			{
				if (exp < 0)
				{
					sig = (ushort)ShiftRightJam(sig, -exp);
					exp = 0;
					num = sig & 0xF;
				}
				else if (exp > 29 || sig + 8 >= 32768)
				{
					if (!sign)
					{
						return 31744;
					}
					return 64512;
				}
			}
			sig = (ushort)(sig + 8 >> 4);
			sig &= (ushort)(~((((num ^ 8) == 0) ? 1u : 0u) & 1u));
			if (sig == 0)
			{
				exp = 0;
			}
			return new Float16(sign, (ushort)exp, sig).value;
		}

		private static uint ShiftRightJam(uint i, int dist)
		{
			if (dist >= 31)
			{
				return (i != 0) ? 1u : 0u;
			}
			return (i >> dist) | ((i << -dist != 0) ? 1u : 0u);
		}

		private static ulong ShiftRightJam(ulong l, int dist)
		{
			if (dist >= 63)
			{
				return (ulong)((l != 0) ? 1 : 0);
			}
			return (l >> dist) | (ulong)((l << -dist != 0) ? 1 : 0);
		}
	}
	public readonly struct BFloat16 : IComparable, IComparable<BFloat16>, IEquatable<BFloat16>
	{
		internal const ushort SignMask = 32768;

		internal const int SignShift = 15;

		internal const byte ShiftedSignMask = 1;

		internal const ushort BiasedExponentMask = 32640;

		internal const int BiasedExponentShift = 7;

		internal const byte ShiftedBiasedExponentMask = byte.MaxValue;

		internal const ushort TrailingSignificandMask = 127;

		internal const byte MinSign = 0;

		internal const byte MaxSign = 1;

		internal const byte MinBiasedExponent = 0;

		internal const byte MaxBiasedExponent = byte.MaxValue;

		internal const byte ExponentBias = 127;

		internal const sbyte MinExponent = -126;

		internal const sbyte MaxExponent = sbyte.MaxValue;

		private const ushort PositiveZeroBits = 0;

		private const ushort NegativeZeroBits = 32768;

		private const ushort OneBits = 16256;

		private const ushort PositiveInfinityBits = 32640;

		private const ushort NegativeInfinityBits = 65408;

		private const ushort PositiveQNaNBits = 32705;

		private const ushort NegativeQNaNBits = 65473;

		private const ushort MinValueBits = 65407;

		private const ushort MaxValueBits = 32639;

		private const ushort EpsilonBits = 128;

		private const ushort PiBits = 16457;

		private const uint RoundingBase = 32767u;

		public readonly ushort value;

		public static BFloat16 Epsilon => new BFloat16(128);

		public static BFloat16 Pi => new BFloat16(16457);

		public static BFloat16 PositiveInfinity => new BFloat16(32640);

		public static BFloat16 NegativeInfinity => new BFloat16(65408);

		public static BFloat16 NaN => new BFloat16(65473);

		public static BFloat16 Zero => new BFloat16(0);

		public static BFloat16 One => new BFloat16(16256);

		public static BFloat16 NegativeZero => new BFloat16(32768);

		public static BFloat16 MinValue => new BFloat16(65407);

		public static BFloat16 MaxValue => new BFloat16(32639);

		internal byte BiasedExponent => ExtractBiasedExponentFromBits(value);

		internal ushort TrailingSignificand => ExtractTrailingSignificandFromBits(value);

		public BFloat16(ushort v)
		{
			value = v;
		}

		internal static byte ExtractBiasedExponentFromBits(ushort bits)
		{
			return (byte)((bits >> 7) & 0xFF);
		}

		internal static ushort ExtractTrailingSignificandFromBits(ushort bits)
		{
			return (ushort)(bits & 0x7F);
		}

		public static bool operator <(BFloat16 left, BFloat16 right)
		{
			if (IsNaN(left) || IsNaN(right))
			{
				return false;
			}
			bool flag = IsNegative(left);
			if (flag != IsNegative(right))
			{
				if (flag)
				{
					return !AreZero(left, right);
				}
				return false;
			}
			if (left.value != right.value)
			{
				return (left.value < right.value) ^ flag;
			}
			return false;
		}

		public static bool operator >(BFloat16 left, BFloat16 right)
		{
			return right < left;
		}

		public static bool operator <=(BFloat16 left, BFloat16 right)
		{
			if (IsNaN(left) || IsNaN(right))
			{
				return false;
			}
			bool flag = IsNegative(left);
			if (flag != IsNegative(right))
			{
				if (!flag)
				{
					return AreZero(left, right);
				}
				return true;
			}
			if (left.value != right.value)
			{
				return (left.value < right.value) ^ flag;
			}
			return true;
		}

		public static bool operator >=(BFloat16 left, BFloat16 right)
		{
			return right <= left;
		}

		public static bool operator ==(BFloat16 left, BFloat16 right)
		{
			if (IsNaN(left) || IsNaN(right))
			{
				return false;
			}
			return left.value == right.value;
		}

		public static bool operator !=(BFloat16 left, BFloat16 right)
		{
			return !(left == right);
		}

		public static bool IsFinite(BFloat16 value)
		{
			return StripSign(value) < 32640;
		}

		public static bool IsInfinity(BFloat16 value)
		{
			return StripSign(value) == 32640;
		}

		public static bool IsNaN(BFloat16 value)
		{
			return StripSign(value) > 32640;
		}

		public static bool IsNegative(BFloat16 value)
		{
			return (short)value.value < 0;
		}

		public static bool IsNegativeInfinity(BFloat16 value)
		{
			return value.value == 65408;
		}

		public static bool IsNormal(BFloat16 value)
		{
			uint num = StripSign(value);
			if (num < 32640 && num != 0)
			{
				return (num & 0x7F80) != 0;
			}
			return false;
		}

		public static bool IsPositiveInfinity(BFloat16 value)
		{
			return value.value == 32640;
		}

		public static bool IsSubnormal(BFloat16 value)
		{
			uint num = StripSign(value);
			if (num < 32640 && num != 0)
			{
				return (num & 0x7F80) == 0;
			}
			return false;
		}

		public int CompareTo(object obj)
		{
			if (!(obj is BFloat16))
			{
				if (obj != null)
				{
					throw new ArgumentException("Object must be of type BFloat16");
				}
				return 1;
			}
			return CompareTo((BFloat16)obj);
		}

		public int CompareTo(BFloat16 other)
		{
			if (this < other)
			{
				return -1;
			}
			if (this > other)
			{
				return 1;
			}
			if (this == other)
			{
				return 0;
			}
			if (IsNaN(this))
			{
				if (!IsNaN(other))
				{
					return -1;
				}
				return 0;
			}
			return 1;
		}

		public bool Equals(BFloat16 other)
		{
			if (value != other.value && !AreZero(this, other))
			{
				if (IsNaN(this))
				{
					return IsNaN(other);
				}
				return false;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj is BFloat16 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (IsNaNOrZero(this))
			{
				return value & 0x7F80;
			}
			return value;
		}

		public override string ToString()
		{
			return $"{value} : {ToFloat()}";
		}

		public float ToFloat()
		{
			return (float)this;
		}

		public static explicit operator BFloat16(float value)
		{
			if (float.IsNaN(value))
			{
				return NaN;
			}
			uint num = BitOpsUtils.SingleToUInt32Bits(value);
			ushort num2 = BitOpsUtils.SingleBitsToBFloat16Bits(num);
			num2 = BitOpsUtils.SingleBitsToBFloat16Bits(num + (uint)((num2 & 1) + 32767));
			return new BFloat16(num2);
		}

		public static explicit operator float(BFloat16 value)
		{
			bool flag = IsNegative(value);
			int biasedExponent = value.BiasedExponent;
			uint trailingSignificand = value.TrailingSignificand;
			switch (biasedExponent)
			{
			case 255:
				if (trailingSignificand != 0)
				{
					return BitOpsUtils.CreateSingleNaN(flag, (ulong)trailingSignificand << 56);
				}
				if (!flag)
				{
					return float.PositiveInfinity;
				}
				return float.NegativeInfinity;
			case 0:
				if (trailingSignificand == 0)
				{
					if (!flag)
					{
						return 0f;
					}
					return -0f;
				}
				break;
			}
			return BitOpsUtils.UInt32BitsToSingle(BitOpsUtils.BFloat16BitsToSingleBits(value.value));
		}

		public static BFloat16 Negate(BFloat16 value)
		{
			if (!IsNaN(value))
			{
				return new BFloat16((ushort)(value.value ^ 0x8000));
			}
			return value;
		}

		public static bool IsNaNOrZero(BFloat16 value)
		{
			uint num = StripSign(value);
			if (num != 0)
			{
				return num > 32640;
			}
			return true;
		}

		private static bool AreZero(BFloat16 left, BFloat16 right)
		{
			return (ushort)((left.value | right.value) & -32769) == 0;
		}

		private static uint StripSign(BFloat16 value)
		{
			return (ushort)(value.value & -32769);
		}
	}
	public enum OrtHardwareDeviceType
	{
		CPU,
		GPU,
		NPU
	}
	public class OrtHardwareDevice
	{
		private readonly nint _handle;

		public OrtHardwareDeviceType Type => (OrtHardwareDeviceType)NativeMethods.OrtHardwareDevice_Type(_handle);

		public uint VendorId => NativeMethods.OrtHardwareDevice_VendorId(_handle);

		public string Vendor => NativeOnnxValueHelper.StringFromNativeUtf8(NativeMethods.OrtHardwareDevice_Vendor(_handle));

		public uint DeviceId => NativeMethods.OrtHardwareDevice_DeviceId(_handle);

		public OrtKeyValuePairs Metadata => new OrtKeyValuePairs(NativeMethods.OrtHardwareDevice_Metadata(_handle));

		internal nint Handle => _handle;

		internal OrtHardwareDevice(nint deviceHandle)
		{
			_handle = deviceHandle;
		}
	}
	public class OrtIoBinding : SafeHandle
	{
		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		internal OrtIoBinding(InferenceSession session)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateIoBinding(session.Handle, out handle));
		}

		public void BindInput(string name, OrtValue ortValue)
		{
			BindInputOrOutput(name, ortValue.Handle, isInput: true);
		}

		public void BindInput(string name, TensorElementType elementType, long[] shape, OrtMemoryAllocation allocation)
		{
			BindOrtAllocation(name, elementType, shape, allocation, isInput: true);
		}

		[Obsolete("This BindInput overload is deprecated. Create OrtValue over an arbitrary piece of memory.")]
		public void BindInput(string name, OrtExternalAllocation allocation)
		{
			BindExternalAllocation(name, allocation, isInput: true);
		}

		[Obsolete("This BindInput overload is deprecated. Use of OrtValue based overload is recommended.")]
		public void BindInput(string name, FixedBufferOnnxValue fixedValue)
		{
			if (fixedValue.OnnxValueType != OnnxValueType.ONNX_TYPE_TENSOR)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Binding works only with Tensors");
			}
			BindInputOrOutput(name, fixedValue.Value.Handle, isInput: true);
		}

		public void SynchronizeBoundInputs()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSynchronizeBoundInputs(handle));
		}

		public void BindOutput(string name, OrtValue ortValue)
		{
			BindInputOrOutput(name, ortValue.Handle, isInput: false);
		}

		public void BindOutput(string name, TensorElementType elementType, long[] shape, OrtMemoryAllocation allocation)
		{
			BindOrtAllocation(name, elementType, shape, allocation, isInput: false);
		}

		[Obsolete("This BindOutput overload is deprecated. Create OrtValue over an arbitrary piece of memory.")]
		public void BindOutput(string name, OrtExternalAllocation allocation)
		{
			BindExternalAllocation(name, allocation, isInput: false);
		}

		[Obsolete("This BindOutput overload is deprecated. Use of OrtValue based overload is recommended.")]
		public void BindOutput(string name, FixedBufferOnnxValue fixedValue)
		{
			if (fixedValue.OnnxValueType != OnnxValueType.ONNX_TYPE_TENSOR)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Binding works only with Tensors");
			}
			BindInputOrOutput(name, fixedValue.Value.Handle, isInput: false);
		}

		public void BindOutputToDevice(string name, OrtMemoryInfo memInfo)
		{
			byte[] name2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(name);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtBindOutputToDevice(handle, name2, memInfo.Pointer));
		}

		public void SynchronizeBoundOutputs()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSynchronizeBoundOutputs(handle));
		}

		private void BindOrtAllocation(string name, TensorElementType elementType, long[] shape, OrtMemoryAllocation allocation, bool isInput)
		{
			using OrtValue ortValue = OrtValue.CreateTensorValueWithData(allocation.Info, elementType, shape, allocation.Pointer, allocation.Size);
			BindInputOrOutput(name, ortValue.Handle, isInput);
		}

		private void BindExternalAllocation(string name, OrtExternalAllocation allocation, bool isInput)
		{
			using OrtValue ortValue = OrtValue.CreateTensorValueWithData(allocation.Info, allocation.ElementType, allocation.Shape, allocation.Pointer, allocation.Size);
			BindInputOrOutput(name, ortValue.Handle, isInput);
		}

		private void BindInputOrOutput(string name, nint ortValue, bool isInput)
		{
			byte[] name2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(name);
			if (isInput)
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtBindInput(handle, name2, ortValue));
			}
			else
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtBindOutput(handle, name2, ortValue));
			}
		}

		public unsafe string[] GetOutputNames()
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetBoundOutputNames(handle, defaultInstance.Pointer, out var buffer, out var lengths, out var count));
			if ((long)count == 0L)
			{
				return Array.Empty<string>();
			}
			int num = (int)count;
			Span<nint> span = new Span<nint>(((IntPtr)lengths).ToPointer(), num);
			try
			{
				string[] array = new string[num];
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					int num3 = (int)span[i];
					nint num4 = new IntPtr(((IntPtr)buffer).ToInt64() + num2);
					array[i] = Encoding.UTF8.GetString((byte*)((IntPtr)num4).ToPointer(), num3);
					num2 += num3;
				}
				return array;
			}
			finally
			{
				defaultInstance.FreeMemory(lengths);
				defaultInstance.FreeMemory(buffer);
			}
		}

		public IDisposableReadOnlyCollection<OrtValue> GetOutputValues()
		{
			return new DisposableList<OrtValue>(GetOutputOrtValues());
		}

		internal unsafe OrtValue[] GetOutputOrtValues()
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetBoundOutputValues(handle, defaultInstance.Pointer, out var ortvalues, out var count));
			if ((long)count == 0L)
			{
				return Array.Empty<OrtValue>();
			}
			int num = (int)count;
			Span<nint> span = new Span<nint>(((IntPtr)ortvalues).ToPointer(), num);
			try
			{
				OrtValue[] array = new OrtValue[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = new OrtValue(span[i]);
				}
				return array;
			}
			catch (Exception)
			{
				for (int j = 0; j < span.Length; j++)
				{
					NativeMethods.OrtReleaseValue(span[j]);
				}
				throw;
			}
			finally
			{
				defaultInstance.FreeMemory(ortvalues);
			}
		}

		public void ClearBoundInputs()
		{
			NativeMethods.OrtClearBoundInputs(handle);
		}

		public void ClearBoundOutputs()
		{
			NativeMethods.OrtClearBoundOutputs(handle);
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseIoBinding(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtKeyValuePairs : SafeHandle
	{
		private readonly bool _createdHandle;

		private Dictionary<string, string> _keyValuePairs;

		public IReadOnlyDictionary<string, string> Entries => _keyValuePairs;

		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtKeyValuePairs()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeMethods.OrtCreateKeyValuePairs(out handle);
			_createdHandle = true;
			_keyValuePairs = new Dictionary<string, string>();
		}

		internal OrtKeyValuePairs(nint constHandle)
			: base(constHandle, ownsHandle: false)
		{
			_createdHandle = false;
			_keyValuePairs = GetLatest();
		}

		public OrtKeyValuePairs(IReadOnlyDictionary<string, string> keyValuePairs)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeMethods.OrtCreateKeyValuePairs(out handle);
			_createdHandle = true;
			_keyValuePairs = new Dictionary<string, string>(keyValuePairs?.Count ?? 0);
			if (keyValuePairs == null || keyValuePairs.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<string, string> keyValuePair in keyValuePairs)
			{
				Add(keyValuePair.Key, keyValuePair.Value);
			}
		}

		public void Add(string key, string value)
		{
			if (!_createdHandle)
			{
				throw new InvalidOperationException("Add can only be called on instances you created.");
			}
			byte[] key2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(key);
			byte[] value2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(value);
			NativeMethods.OrtAddKeyValuePair(handle, key2, value2);
			_keyValuePairs[key] = value;
		}

		public void Refresh()
		{
			_keyValuePairs = GetLatest();
		}

		public void Remove(string key)
		{
			if (!_createdHandle)
			{
				throw new InvalidOperationException("Remove can only be called on instances you created.");
			}
			byte[] key2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(key);
			NativeMethods.OrtRemoveKeyValuePair(handle, key2);
			_keyValuePairs.Remove(key);
		}

		internal void GetKeyValuePairHandles(out nint keysHandle, out nint valuesHandle, out nuint numEntries)
		{
			if (IsInvalid)
			{
				throw new InvalidOperationException("GetKeyValuePairHandles: Invalid instance.");
			}
			NativeMethods.OrtGetKeyValuePairs(handle, out keysHandle, out valuesHandle, out numEntries);
		}

		private Dictionary<string, string> GetLatest()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (IsInvalid)
			{
				return dictionary;
			}
			NativeMethods.OrtGetKeyValuePairs(handle, out var keys, out var values, out var numEntries);
			ulong num = ((UIntPtr)numEntries).ToUInt64();
			int num2 = 0;
			ulong num3 = 0uL;
			while (num3 < num)
			{
				nint nativeUtf = Marshal.ReadIntPtr(keys, num2);
				nint nativeUtf2 = Marshal.ReadIntPtr(values, num2);
				string key = NativeOnnxValueHelper.StringFromNativeUtf8(nativeUtf);
				string value = NativeOnnxValueHelper.StringFromNativeUtf8(nativeUtf2);
				dictionary.Add(key, value);
				num3++;
				num2 += IntPtr.Size;
			}
			return dictionary;
		}

		protected override bool ReleaseHandle()
		{
			if (_createdHandle)
			{
				NativeMethods.OrtReleaseKeyValuePairs(handle);
				handle = IntPtr.Zero;
			}
			return true;
		}
	}
	public enum OrtLoggingLevel
	{
		ORT_LOGGING_LEVEL_VERBOSE,
		ORT_LOGGING_LEVEL_INFO,
		ORT_LOGGING_LEVEL_WARNING,
		ORT_LOGGING_LEVEL_ERROR,
		ORT_LOGGING_LEVEL_FATAL
	}
	public class OrtLoraAdapter : SafeHandle
	{
		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public static OrtLoraAdapter Create(string adapterPath, OrtAllocator ortAllocator)
		{
			byte[] platformSerializedString = NativeOnnxValueHelper.GetPlatformSerializedString(adapterPath);
			nint allocator = ortAllocator?.Pointer ?? IntPtr.Zero;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateLoraAdapter(platformSerializedString, allocator, out var lora_adapter));
			return new OrtLoraAdapter(lora_adapter);
		}

		public static OrtLoraAdapter Create(byte[] bytes, OrtAllocator ortAllocator)
		{
			nint allocator = ortAllocator?.Pointer ?? IntPtr.Zero;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateLoraAdapterFromArray(bytes, new UIntPtr((uint)bytes.Length), allocator, out var lora_adapter));
			return new OrtLoraAdapter(lora_adapter);
		}

		internal OrtLoraAdapter(nint adapter)
			: base(adapter, ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseLoraAdapter(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtThreadingOptions : SafeHandle
	{
		internal nint Handle => handle;

		public int GlobalInterOpNumThreads
		{
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtThreadingOptionsSetGlobalInterOpNumThreads(handle, value));
			}
		}

		public int GlobalIntraOpNumThreads
		{
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtThreadingOptionsSetGlobalIntraOpNumThreads(handle, value));
			}
		}

		public bool GlobalSpinControl
		{
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtThreadingOptionsSetGlobalSpinControl(handle, value ? 1 : 0));
			}
		}

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtThreadingOptions()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateThreadingOptions(out handle));
		}

		public void SetGlobalDenormalAsZero()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtThreadingOptionsSetGlobalDenormalAsZero(handle));
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseThreadingOptions(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtTypeInfo
	{
		private OrtTensorTypeAndShapeInfo? _tensorTypeAndShape;

		private OrtSequenceOrOptionalTypeInfo? _sequenceOrOptional;

		private OrtMapTypeInfo? _mapTypeInfo;

		public OnnxValueType OnnxType { get; private set; }

		public OrtTensorTypeAndShapeInfo TensorTypeAndShapeInfo
		{
			get
			{
				if (OnnxType != OnnxValueType.ONNX_TYPE_TENSOR && OnnxType != OnnxValueType.ONNX_TYPE_SPARSETENSOR)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "TypeInfo does not represent a tensor/sparsetensor");
				}
				return _tensorTypeAndShape.Value;
			}
		}

		public OrtSequenceOrOptionalTypeInfo SequenceTypeInfo
		{
			get
			{
				if (OnnxType != OnnxValueType.ONNX_TYPE_SEQUENCE)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "TypeInfo does not represent a sequence");
				}
				return _sequenceOrOptional.Value;
			}
		}

		public OrtMapTypeInfo MapTypeInfo
		{
			get
			{
				if (OnnxType != OnnxValueType.ONNX_TYPE_MAP)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "TypeInfo does not represent a map");
				}
				return _mapTypeInfo.Value;
			}
		}

		public OrtSequenceOrOptionalTypeInfo OptionalTypeInfo
		{
			get
			{
				if (OnnxType != OnnxValueType.ONNX_TYPE_OPTIONAL)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "TypeInfo does not represent a optional");
				}
				return _sequenceOrOptional.Value;
			}
		}

		internal OrtTypeInfo(nint handle)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetOnnxTypeFromTypeInfo(handle, out var onnxtype));
			OnnxType = (OnnxValueType)onnxtype;
			switch (OnnxType)
			{
			case OnnxValueType.ONNX_TYPE_TENSOR:
			case OnnxValueType.ONNX_TYPE_SPARSETENSOR:
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToTensorInfo(handle, out var typeAndShapeInfo));
				if (typeAndShapeInfo == IntPtr.Zero)
				{
					throw new OnnxRuntimeException(ErrorCode.Fail, "Type Information indicates a tensor, but casting to TensorInfo fails");
				}
				_tensorTypeAndShape = new OrtTensorTypeAndShapeInfo(typeAndShapeInfo);
				break;
			}
			case OnnxValueType.ONNX_TYPE_SEQUENCE:
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToSequenceTypeInfo(handle, out var sequenceTypeInfo));
				if (sequenceTypeInfo == IntPtr.Zero)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "TypeInfo cast to SequenceTypeInfo failed. The object does not represent a sequence");
				}
				_sequenceOrOptional = new OrtSequenceOrOptionalTypeInfo(sequenceTypeInfo);
				break;
			}
			case OnnxValueType.ONNX_TYPE_MAP:
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToMapTypeInfo(handle, out var mapTypeInfo));
				if (mapTypeInfo == IntPtr.Zero)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "TypeInfo cast to MapTypeInfo failed. The object does not represent a map");
				}
				_mapTypeInfo = new OrtMapTypeInfo(mapTypeInfo);
				break;
			}
			case OnnxValueType.ONNX_TYPE_OPTIONAL:
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCastTypeInfoToOptionalTypeInfo(handle, out var optionalTypeInfo));
				if (optionalTypeInfo == IntPtr.Zero)
				{
					throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "TypeInfo cast to OptionalTypeInfo failed. The object does not represent a optional");
				}
				_sequenceOrOptional = new OrtSequenceOrOptionalTypeInfo(optionalTypeInfo);
				break;
			}
			default:
				throw new OnnxRuntimeException(ErrorCode.NotImplemented, $"OnnxValueType: {OnnxType} is not supported here");
			}
		}
	}
	public struct OrtTensorTypeAndShapeInfo
	{
		public TensorElementType ElementDataType { get; private set; }

		public bool IsString => ElementDataType == TensorElementType.String;

		public long ElementCount { get; private set; }

		public int DimensionsCount => Shape.Length;

		public long[] Shape { get; private set; }

		internal OrtTensorTypeAndShapeInfo(nint handle)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorElementType(handle, out var output));
			ElementDataType = (TensorElementType)output;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorShapeElementCount(handle, out var output2));
			ElementCount = (long)output2;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetDimensionsCount(handle, out var output3));
			Shape = new long[(uint)output3];
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetDimensions(handle, Shape, output3));
		}
	}
	public struct OrtSequenceOrOptionalTypeInfo
	{
		public OrtTypeInfo ElementType { get; private set; }

		internal OrtSequenceOrOptionalTypeInfo(nint handle)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetSequenceElementType(handle, out var elementTypeInfo));
			try
			{
				ElementType = new OrtTypeInfo(elementTypeInfo);
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(elementTypeInfo);
			}
		}
	}
	public struct OrtMapTypeInfo
	{
		public TensorElementType KeyType { get; private set; }

		public OrtTypeInfo ValueType { get; private set; }

		internal OrtMapTypeInfo(nint handle)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetMapKeyType(handle, out var tensorElementType));
			KeyType = (TensorElementType)tensorElementType;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetMapValueType(handle, out var type_info));
			try
			{
				ValueType = new OrtTypeInfo(type_info);
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(type_info);
			}
		}
	}
	public enum OnnxValueType
	{
		ONNX_TYPE_UNKNOWN,
		ONNX_TYPE_TENSOR,
		ONNX_TYPE_SEQUENCE,
		ONNX_TYPE_MAP,
		ONNX_TYPE_OPAQUE,
		ONNX_TYPE_SPARSETENSOR,
		ONNX_TYPE_OPTIONAL
	}
	public interface IReadOnlyOrtValue
	{
		OnnxValueType OnnxType { get; }

		bool IsTensor { get; }

		bool IsSparseTensor { get; }

		OrtTypeInfo GetTypeInfo();

		OrtTensorTypeAndShapeInfo GetTensorTypeAndShape();

		long GetTensorSizeInBytes();

		OrtMemoryInfo GetTensorMemoryInfo();

		ReadOnlySpan<T> GetTensorDataAsSpan<T>() where T : unmanaged;

		[Experimental("SYSLIB5001")]
		ReadOnlyTensorSpan<T> GetTensorDataAsTensorSpan<T>() where T : unmanaged;

		int GetValueCount();

		OrtValue GetValue(int index, OrtAllocator allocator);

		ReadOnlyMemory<char> GetStringElementAsMemory(int index);

		string GetStringElement(int index);

		ReadOnlySpan<byte> GetStringElementAsSpan(int index);

		string[] GetStringTensorAsArray();
	}
	public class OrtValue : IOrtValueOwner, IDisposable, IReadOnlyOrtValue
	{
		public delegate void SequenceElementVisitor(OrtValue ortValue, int index);

		public delegate void MapVisitor(OrtValue keys, OrtValue values);

		private DisposableList<OrtValue> _compositeMembers;

		private nint _handle;

		private MemoryHandle? _memHandle;

		private bool _disposed;

		private bool _owned = true;

		internal nint Handle => _handle;

		public OrtValue Value => this;

		public OnnxValueType OnnxType { get; private set; }

		public bool IsTensor => OnnxType == OnnxValueType.ONNX_TYPE_TENSOR;

		public bool IsSparseTensor => OnnxType == OnnxValueType.ONNX_TYPE_SPARSETENSOR;

		internal OrtValue(nint handle, bool owned = true)
		{
			_handle = handle;
			InitOnnxType();
			_owned = owned;
		}

		internal OrtValue(nint handle, OnnxValueType onnxValueType)
		{
			if (onnxValueType == OnnxValueType.ONNX_TYPE_UNKNOWN)
			{
				throw new ArgumentException("onnxValueType argument is passed as unknown");
			}
			_handle = handle;
			OnnxType = onnxValueType;
		}

		internal OrtValue(nint handle, OnnxValueType onnxValueType, ref DisposableList<OrtValue> compositeMembers)
		{
			if (onnxValueType == OnnxValueType.ONNX_TYPE_UNKNOWN)
			{
				throw new ArgumentException("onnxValueType argument is passed as unknown");
			}
			_handle = handle;
			OnnxType = onnxValueType;
			_compositeMembers = compositeMembers;
			compositeMembers = null;
		}

		private OrtValue(nint handle, MemoryHandle memHandle)
		{
			_handle = handle;
			_memHandle = memHandle;
			OnnxType = OnnxValueType.ONNX_TYPE_TENSOR;
		}

		private void InitOnnxType()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetValueType(Handle, out var onnxtype));
			OnnxType = (OnnxValueType)onnxtype;
		}

		public int GetValueCount()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetValueCount(Handle, out var count));
			return (int)count;
		}

		public OrtValue GetValue(int index, OrtAllocator allocator)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetValue(Handle, index, allocator.Pointer, out var outputValue));
			return new OrtValue(outputValue);
		}

		public ReadOnlySpan<T> GetTensorDataAsSpan<T>() where T : unmanaged
		{
			return MemoryMarshal.Cast<byte, T>(GetTensorBufferRawData(typeof(T)));
		}

		[Experimental("SYSLIB5001")]
		public ReadOnlyTensorSpan<T> GetTensorDataAsTensorSpan<T>() where T : unmanaged
		{
			Span<T> span = MemoryMarshal.Cast<byte, T>(GetTensorBufferRawData(typeof(T)));
			return new ReadOnlyTensorSpan<T>(lengths: Array.ConvertAll(GetTypeInfo().TensorTypeAndShapeInfo.Shape, (long x) => (nint)x), span: span, strides: default);
		}

		public Span<T> GetTensorMutableDataAsSpan<T>() where T : unmanaged
		{
			return MemoryMarshal.Cast<byte, T>(GetTensorBufferRawData(typeof(T)));
		}

		[Experimental("SYSLIB5001")]
		public TensorSpan<T> GetTensorMutableDataAsTensorSpan<T>() where T : unmanaged
		{
			Span<T> span = MemoryMarshal.Cast<byte, T>(GetTensorBufferRawData(typeof(T)));
			nint[] array = Array.ConvertAll(GetTypeInfo().TensorTypeAndShapeInfo.Shape, (long x) => (nint)x);
			return new TensorSpan<T>(span, array, default);
		}

		public Span<byte> GetTensorMutableRawData()
		{
			return GetTensorBufferRawData(typeof(byte));
		}

		[Experimental("SYSLIB5001")]
		public TensorSpan<byte> GetTensorSpanMutableRawData<T>() where T : unmanaged
		{
			Span<byte> tensorBufferRawData = GetTensorBufferRawData(typeof(T));
			nint[] array = Array.ConvertAll(GetTypeInfo().TensorTypeAndShapeInfo.Shape, (long x) => (nint)x);
			return new TensorSpan<byte>(tensorBufferRawData, array, default);
		}

		public long GetTensorSizeInBytes()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorSizeInBytes(Handle, out var tensorSizeInBytes));
			return (long)tensorSizeInBytes;
		}

		public ReadOnlyMemory<char> GetStringElementAsMemory(int index)
		{
			char[] stringTensorElementChars = GetStringTensorElementChars(index);
			if (stringTensorElementChars.Length == 0)
			{
				return ReadOnlyMemory<char>.Empty;
			}
			return new ReadOnlyMemory<char>(stringTensorElementChars);
		}

		public unsafe string GetStringElement(int index)
		{
			GetStringTensorElementBuffer((nuint)index, out var bytesLen, out var bufferPtr);
			if (bytesLen == 0)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString((byte*)((IntPtr)bufferPtr).ToPointer(), (int)bytesLen);
		}

		public unsafe ReadOnlySpan<byte> GetStringElementAsSpan(int index)
		{
			GetStringTensorElementBuffer((nuint)index, out var bytesLen, out var bufferPtr);
			if (bytesLen == 0)
			{
				return ReadOnlySpan<byte>.Empty;
			}
			return new ReadOnlySpan<byte>(((IntPtr)bufferPtr).ToPointer(), (int)bytesLen);
		}

		public string[] GetStringTensorAsArray()
		{
			GetTensorElementTypeAndCount(out var count, out var elementType);
			if (elementType != TensorElementType.String)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, $"GetStringTensorAsArray() is only supported for string tensors. This OrtValue contains a {elementType} tensor.");
			}
			string[] array = new string[count];
			for (int i = 0; i < count; i++)
			{
				array[i] = GetStringElement(i);
			}
			return array;
		}

		public OrtTypeInfo GetTypeInfo()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTypeInfo(Handle, out var typeInfo));
			try
			{
				return new OrtTypeInfo(typeInfo);
			}
			finally
			{
				NativeMethods.OrtReleaseTypeInfo(typeInfo);
			}
		}

		public OrtTensorTypeAndShapeInfo GetTensorTypeAndShape()
		{
			OnnxValueType onnxType = OnnxType;
			if (onnxType != OnnxValueType.ONNX_TYPE_TENSOR && onnxType != OnnxValueType.ONNX_TYPE_SPARSETENSOR)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"This OrtValue type contains: {onnxType}, not a tensor or sparse tensor");
			}
			NativeMethods.OrtGetTensorTypeAndShape(Handle, out var typeAndShapeInfo);
			try
			{
				return new OrtTensorTypeAndShapeInfo(typeAndShapeInfo);
			}
			finally
			{
				NativeMethods.OrtReleaseTensorTypeAndShapeInfo(typeAndShapeInfo);
			}
		}

		public OrtMemoryInfo GetTensorMemoryInfo()
		{
			OnnxValueType onnxType = OnnxType;
			if (onnxType != OnnxValueType.ONNX_TYPE_TENSOR && onnxType != OnnxValueType.ONNX_TYPE_SPARSETENSOR)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"This OrtValue type contains: {onnxType}, not a tensor or sparse tensor");
			}
			NativeMethods.OrtGetTensorMemoryInfo(Handle, out var ortMemoryInfo);
			return new OrtMemoryInfo(ortMemoryInfo, owned: false);
		}

		private void GetTensorElementTypeAndCount(out long count, out TensorElementType elementType)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorTypeAndShape(Handle, out var typeAndShapeInfo));
			try
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorElementType(typeAndShapeInfo, out var output));
				NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorShapeElementCount(typeAndShapeInfo, out var output2));
				elementType = (TensorElementType)output;
				count = (long)output2;
			}
			finally
			{
				NativeMethods.OrtReleaseTensorTypeAndShapeInfo(typeAndShapeInfo);
			}
		}

		private unsafe char[] GetStringTensorElementChars(int index)
		{
			GetStringTensorElementBuffer((nuint)index, out var bytesLen, out var bufferPtr);
			if (bytesLen == 0)
			{
				return Array.Empty<char>();
			}
			int charCount = Encoding.UTF8.GetCharCount((byte*)((IntPtr)bufferPtr).ToPointer(), (int)bytesLen);
			char[] array = new char[charCount];
			fixed (char* chars = array)
			{
				Encoding.UTF8.GetChars((byte*)((IntPtr)bufferPtr).ToPointer(), (int)bytesLen, chars, charCount);
			}
			return array;
		}

		private void GetStringTensorElementBuffer(nuint index, out uint bytesLen, out nint bufferPtr)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetStringTensorElementLength(Handle, index, out var len));
			bytesLen = (uint)len;
			if (bytesLen == 0)
			{
				bufferPtr = IntPtr.Zero;
			}
			else
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtGetResizedStringTensorElementBuffer(Handle, index, len, out bufferPtr));
			}
		}

		private unsafe Span<byte> GetTensorBufferRawData(Type requestedType)
		{
			if (OnnxType != OnnxValueType.ONNX_TYPE_TENSOR)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"This OrtValue type contains: {OnnxType}, not a tensor");
			}
			GetTensorElementTypeAndCount(out var count, out var elementType);
			if (elementType == TensorElementType.String)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Strings are not supported by this API");
			}
			TensorElementTypeInfo tensorElementTypeInfo = TensorBase.GetElementTypeInfo(elementType) ?? throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Element type: {elementType} is not registered type.");
			if (requestedType != typeof(byte) && requestedType != tensorElementTypeInfo.TensorType)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Requested type: {requestedType} does not match the actual type: {tensorElementTypeInfo.TensorType}");
			}
			if (count == 0L)
			{
				return Span<byte>.Empty;
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorMutableData(Handle, out var dataBufferHandle));
			long num = count * tensorElementTypeInfo.TypeSize;
			return new Span<byte>(((IntPtr)dataBufferHandle).ToPointer(), (int)num);
		}

		public static OrtValue CreateTensorValueWithData(OrtMemoryInfo memInfo, TensorElementType elementType, long[] shape, nint dataBufferPtr, long bufferLengthInBytes)
		{
			TensorElementTypeInfo tensorElementTypeInfo = TensorBase.GetElementTypeInfo(elementType) ?? throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Tensor element type: {elementType} is not supported");
			if (tensorElementTypeInfo.IsString)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Cannot map managed strings buffer to native OrtValue. Use string specific interfaces");
			}
			long sizeForShape = ShapeUtils.GetSizeForShape(shape);
			long num = sizeForShape * tensorElementTypeInfo.TypeSize;
			if (num > bufferLengthInBytes)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Shape: {shape} has: {sizeForShape} elements requires a buffer of at least {num} bytes. Provided: {bufferLengthInBytes} bytes");
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateTensorWithDataAsOrtValue(memInfo.Pointer, dataBufferPtr, (nuint)bufferLengthInBytes, shape, (nuint)shape.Length, elementType, out var outputValue));
			return new OrtValue(outputValue, OnnxValueType.ONNX_TYPE_TENSOR);
		}

		public unsafe static OrtValue CreateTensorValueFromMemory<T>(OrtMemoryInfo memoryInfo, Memory<T> memory, long[] shape) where T : unmanaged
		{
			TensorTypeInfo tensorTypeInfo = TensorBase.GetTypeInfo(typeof(T)) ?? throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Tensor of type: {typeof(T)} is not supported");
			if (tensorTypeInfo.IsString)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Cannot map managed strings buffer to native OrtValue. Use string specific interfaces.");
			}
			long sizeForShape = ShapeUtils.GetSizeForShape(shape);
			if (sizeForShape > memory.Length)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Managed memory size: {memory.Length} elements is less than shape size: {sizeForShape} elements");
			}
			int num = memory.Length * tensorTypeInfo.TypeSize;
			MemoryHandle memHandle = memory.Pin();
			try
			{
				nint dataBufferHandle = new IntPtr(memHandle.Pointer);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateTensorWithDataAsOrtValue(memoryInfo.Pointer, dataBufferHandle, (nuint)num, shape, (nuint)shape.Length, tensorTypeInfo.ElementType, out var outputValue));
				return new OrtValue(outputValue, memHandle);
			}
			catch (Exception)
			{
				memHandle.Dispose();
				throw;
			}
		}

		public static OrtValue CreateTensorValueFromMemory<T>(T[] data, long[] shape) where T : unmanaged
		{
			return CreateTensorValueFromMemory(OrtMemoryInfo.DefaultInstance, new Memory<T>(data), shape);
		}

		[Experimental("SYSLIB5001")]
		public unsafe static OrtValue CreateTensorValueFromSystemNumericsTensorObject<T>(System.Numerics.Tensors.Tensor<T> tensor) where T : unmanaged
		{
			if (!IsContiguousAndDense(tensor))
			{
				System.Numerics.Tensors.Tensor<T> tensor2 = System.Numerics.Tensors.Tensor.Create<T>(tensor.Lengths);
				tensor.CopyTo(tensor2);
				tensor = tensor2;
			}
			GCHandle handle = GCHandle.Alloc((T[])tensor.GetType().GetField("_values", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(tensor), GCHandleType.Pinned);
			MemoryHandle memHandle = new MemoryHandle(Unsafe.AsPointer(in tensor.GetPinnableReference()), handle);
			try
			{
				nint zero = IntPtr.Zero;
				zero = (nint)memHandle.Pointer;
				nint dataLength = tensor.FlattenedLength * sizeof(T);
				long[] shape = Array.ConvertAll(tensor.Lengths.ToArray(), (Converter<nint, long>)((nint x) => x));
				TensorTypeInfo tensorTypeInfo = TensorBase.GetTypeInfo(typeof(T)) ?? throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Tensor of type: {typeof(T)} is not supported");
				NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateTensorWithDataAsOrtValue(OrtMemoryInfo.DefaultInstance.Pointer, zero, (nuint)dataLength, shape, (nuint)tensor.Rank, tensorTypeInfo.ElementType, out var outputValue));
				return new OrtValue(outputValue, memHandle);
			}
			catch (Exception)
			{
				memHandle.Dispose();
				throw;
			}
		}

		[Experimental("SYSLIB5001")]
		private static bool IsContiguousAndDense<T>(System.Numerics.Tensors.Tensor<T> tensor) where T : unmanaged
		{
			ReadOnlySpan<nint> strides = tensor.Strides;
			if (strides[strides.Length - 1] != 1)
			{
				return false;
			}
			for (int num = tensor.Rank - 2; num >= 0; num--)
			{
				if (tensor.Strides[num] != TensorPrimitives.Product<nint>(tensor.Lengths.Slice(num + 1, tensor.Lengths.Length - num - 1)))
				{
					return false;
				}
			}
			return true;
		}

		public static OrtValue CreateAllocatedTensorValue(OrtAllocator allocator, TensorElementType elementType, long[] shape)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateTensorAsOrtValue(allocator.Pointer, shape, (nuint)shape.Length, elementType, out var outputValue));
			return new OrtValue(outputValue, OnnxValueType.ONNX_TYPE_TENSOR);
		}

		internal unsafe static OrtValue CreateFromTensorObject(TensorBase value, out TensorElementType elementType)
		{
			TensorTypeInfo typeInfo = value.GetTypeInfo();
			OrtValue ortValue = null;
			TensorElementType elementType2 = typeInfo.ElementType;
			int typeSize = typeInfo.TypeSize;
			if (typeInfo.IsString)
			{
				ortValue = CreateFromStringTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<string>);
			}
			else
			{
				MemoryHandle pinnedHandle;
				int dataBufferLength;
				long[] shape;
				int rank;
				switch (elementType2)
				{
				case TensorElementType.Float:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<float>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.Double:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<double>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.Int32:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<int>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.UInt32:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<uint>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.Int64:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<long>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.UInt64:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<ulong>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.Int16:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<short>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.UInt16:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<ushort>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.UInt8:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<byte>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.Int8:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<sbyte>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.Bool:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<bool>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.Float16:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<Float16>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				case TensorElementType.BFloat16:
					PinAsTensor(value as Microsoft.ML.OnnxRuntime.Tensors.Tensor<BFloat16>, typeSize, out pinnedHandle, out dataBufferLength, out shape, out rank);
					break;
				default:
					throw new NotSupportedException("Element type: " + elementType2.ToString() + " is not of a supported type");
				}
				try
				{
					nint zero = IntPtr.Zero;
					zero = (nint)pinnedHandle.Pointer;
					NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateTensorWithDataAsOrtValue(OrtMemoryInfo.DefaultInstance.Pointer, zero, (nuint)dataBufferLength, shape, (nuint)rank, elementType2, out var outputValue));
					ortValue = new OrtValue(outputValue, pinnedHandle);
				}
				catch (Exception)
				{
					pinnedHandle.Dispose();
					throw;
				}
			}
			elementType = elementType2;
			return ortValue;
		}

		public static OrtValue CreateTensorWithEmptyStrings(OrtAllocator allocator, long[] shape)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateTensorAsOrtValue(allocator.Pointer, shape, (nuint)shape.Length, TensorElementType.String, out var outputValue));
			return new OrtValue(outputValue, OnnxValueType.ONNX_TYPE_TENSOR);
		}

		public unsafe void StringTensorSetElementAt(ReadOnlySpan<char> str, int index)
		{
			fixed (char* strPtr = str)
			{
				FillStringTensorElement(strPtr, str.Length, index);
			}
		}

		public void StringTensorSetElementAt(ReadOnlyMemory<char> rom, int index)
		{
			StringTensorSetElementAt(rom.Span, index);
		}

		public unsafe void StringTensorSetElementAt(ReadOnlySpan<byte> utf8Bytes, int index)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetResizedStringTensorElementBuffer(Handle, (nuint)index, (nuint)utf8Bytes.Length, out var buffer));
			if (utf8Bytes.Length != 0)
			{
				Span<byte> destination = new Span<byte>(((IntPtr)buffer).ToPointer(), utf8Bytes.Length);
				utf8Bytes.CopyTo(destination);
			}
		}

		public unsafe static OrtValue CreateFromStringTensor(Microsoft.ML.OnnxRuntime.Tensors.Tensor<string> tensor)
		{
			if (tensor == null)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "Expecting a valid string tensor");
			}
			long[] shape = Array.ConvertAll(tensor.Dimensions.ToArray(), Convert.ToInt64);
			OrtValue ortValue = CreateTensorWithEmptyStrings(OrtAllocator.DefaultInstance, shape);
			try
			{
				long length = tensor.Length;
				for (int i = 0; i < length; i++)
				{
					string text = tensor.GetValue(i) ?? throw new ArgumentNullException($"Tensor<string> contains null reference at index:{i}");
					fixed (char* strPtr = text)
					{
						ortValue.FillStringTensorElement(strPtr, text.Length, i);
					}
				}
				return ortValue;
			}
			catch (Exception)
			{
				ortValue.Dispose();
				throw;
			}
		}

		public static OrtValue CreateSequence(ICollection<OrtValue> ortValues)
		{
			if (ortValues == null)
			{
				throw new ArgumentNullException("ortValues");
			}
			if (ortValues.IsReadOnly)
			{
				throw new ArgumentException("ortValues argument can not be a readonly collection");
			}
			DisposableList<OrtValue> compositeMembers = new DisposableList<OrtValue>(ortValues);
			try
			{
				OrtValue result = CreateSequence(ref compositeMembers);
				ortValues.Clear();
				return result;
			}
			catch (Exception)
			{
				compositeMembers?.Clear();
				throw;
			}
		}

		internal static OrtValue CreateSequence(ref DisposableList<OrtValue> compositeMembers)
		{
			nint[] array = new nint[compositeMembers.Count];
			for (int i = 0; i < compositeMembers.Count; i++)
			{
				array[i] = compositeMembers[i].Handle;
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateValue(array, (nuint)array.Length, 2, out var ortValue));
			return new OrtValue(ortValue, OnnxValueType.ONNX_TYPE_SEQUENCE, ref compositeMembers);
		}

		public void ProcessSequence(SequenceElementVisitor visitor, OrtAllocator allocator)
		{
			if (OnnxType != OnnxValueType.ONNX_TYPE_SEQUENCE)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"OrtValue.OnnxType of {OnnxType} is not a sequence");
			}
			int valueCount = GetValueCount();
			for (int i = 0; i < valueCount; i++)
			{
				using OrtValue ortValue = GetValue(i, allocator);
				visitor(ortValue, i);
			}
		}

		public static OrtValue CreateMap(ref OrtValue keys, ref OrtValue values)
		{
			if (keys == null || values == null)
			{
				throw new ArgumentNullException("keys or/and values are null");
			}
			nint[] array = new nint[2] { keys.Handle, values.Handle };
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateValue(array, (nuint)array.Length, 3, out var ortValue));
			DisposableList<OrtValue> compositeMembers = new DisposableList<OrtValue> { keys, values };
			keys = null;
			values = null;
			return new OrtValue(ortValue, OnnxValueType.ONNX_TYPE_MAP, ref compositeMembers);
		}

		public static OrtValue CreateMap<K, V>(K[] keys, V[] values) where K : unmanaged where V : unmanaged
		{
			if (keys == null || values == null)
			{
				throw new ArgumentNullException("Keys or/and values are null");
			}
			if (keys.Length != values.Length)
			{
				throw new ArgumentException("Expecting keys and values same len. " + $"Received keys: {keys.Length}, Values: {values.Length}");
			}
			long[] shape = new long[1] { keys.Length };
			Span<OrtValue> disposables = new OrtValue[2];
			DisposableArray<OrtValue> disposableArray = new DisposableArray<OrtValue>(disposables);
			try
			{
				disposables[0] = CreateTensorValueFromMemory(keys, shape);
				disposables[1] = CreateTensorValueFromMemory(values, shape);
				return CreateMap(ref disposables[0], ref disposables[1]);
			}
			catch (Exception)
			{
				disposableArray.Dispose();
				throw;
			}
		}

		public static OrtValue CreateMapWithStringKeys<V>(IReadOnlyCollection<string> keys, V[] values) where V : unmanaged
		{
			if (keys == null || values == null)
			{
				throw new ArgumentNullException("Keys or/and values are null");
			}
			if (keys.Count != values.Length)
			{
				throw new ArgumentException("Expecting keys and values same len. " + $"Received keys: {keys.Count}, Values: {values.Length}");
			}
			long[] shape = new long[1] { keys.Count };
			Span<OrtValue> disposables = new OrtValue[2];
			DisposableArray<OrtValue> disposableArray = new DisposableArray<OrtValue>(disposables);
			try
			{
				disposables[0] = CreateTensorWithEmptyStrings(OrtAllocator.DefaultInstance, shape);
				int num = 0;
				foreach (string key in keys)
				{
					disposables[0].StringTensorSetElementAt(key, num++);
				}
				disposables[1] = CreateTensorValueFromMemory(values, shape);
				return CreateMap(ref disposables[0], ref disposables[1]);
			}
			catch (Exception)
			{
				disposableArray.Dispose();
				throw;
			}
		}

		public static OrtValue CreateMapWithStringValues<K>(K[] keys, IReadOnlyCollection<string> values) where K : unmanaged
		{
			if (keys == null || values == null)
			{
				throw new ArgumentNullException("Keys or/and values are null");
			}
			if (keys.Length != values.Count)
			{
				throw new ArgumentException("Expecting keys and values same len. " + $"Received keys: {keys.Length}, Values: {values.Count}");
			}
			long[] shape = new long[1] { keys.Length };
			Span<OrtValue> disposables = new OrtValue[2];
			DisposableArray<OrtValue> disposableArray = new DisposableArray<OrtValue>(disposables);
			try
			{
				disposables[0] = CreateTensorValueFromMemory(keys, shape);
				disposables[1] = CreateTensorWithEmptyStrings(OrtAllocator.DefaultInstance, shape);
				int num = 0;
				foreach (string value in values)
				{
					disposables[1].StringTensorSetElementAt(value, num++);
				}
				return CreateMap(ref disposables[0], ref disposables[1]);
			}
			catch (Exception)
			{
				disposableArray.Dispose();
				throw;
			}
		}

		public void ProcessMap(MapVisitor visitor, OrtAllocator allocator)
		{
			if (OnnxType != OnnxValueType.ONNX_TYPE_MAP)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, "This OrtValue does not represent a map");
			}
			using OrtValue keys = GetValue(0, allocator);
			using OrtValue values = GetValue(1, allocator);
			visitor(keys, values);
		}

		private unsafe void FillStringTensorElement(char* strPtr, int strLength, int index)
		{
			nint buffer;
			if (strLength == 0)
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtGetResizedStringTensorElementBuffer(Handle, (nuint)index, UIntPtr.Zero, out buffer));
				return;
			}
			int byteCount = Encoding.UTF8.GetByteCount(strPtr, strLength);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetResizedStringTensorElementBuffer(Handle, (nuint)index, (nuint)byteCount, out buffer));
			NativeOnnxValueHelper.StringToUtf8NativeMemory(strPtr, strLength, buffer, byteCount);
		}

		private static void PinAsTensor<T>(Microsoft.ML.OnnxRuntime.Tensors.Tensor<T> tensor, int elementSize, out MemoryHandle pinnedHandle, out int dataBufferLength, out long[] shape, out int rank)
		{
			if (tensor == null)
			{
				throw new OnnxRuntimeException(ErrorCode.Fail, "Cast to Tensor<T> failed. BUG check!");
			}
			if (tensor.IsReversedStride)
			{
				throw new NotSupportedException("Tensor of reverseStride is not supported");
			}
			DenseTensor<T> denseTensor = (tensor as DenseTensor<T>) ?? tensor.ToDenseTensor();
			shape = Array.ConvertAll(denseTensor.Dimensions.ToArray(), Convert.ToInt64);
			rank = denseTensor.Rank;
			dataBufferLength = denseTensor.Buffer.Length * elementSize;
			pinnedHandle = denseTensor.Buffer.Pin();
		}

		~OrtValue()
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
				if (disposing)
				{
					_memHandle?.Dispose();
					_memHandle = null;
					_compositeMembers?.Dispose();
					_compositeMembers = null;
				}
				if (_owned)
				{
					NativeMethods.OrtReleaseValue(_handle);
				}
				_handle = IntPtr.Zero;
				_disposed = true;
			}
		}
	}
	internal interface IOrtValueOwner : IDisposable
	{
		OrtValue Value { get; }
	}
	internal class NativeOrtValueCollectionOwner : IOrtValueOwner, IDisposable
	{
		private OrtValue _ortValue;

		private IDisposable _disposables;

		private bool _disposed;

		public OrtValue Value => _ortValue;

		internal NativeOrtValueCollectionOwner(ref OrtValue ortValue, IDisposable disposables)
		{
			_ortValue = ortValue;
			ortValue = null;
			_disposables = disposables;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				if (_disposables != null)
				{
					_disposables.Dispose();
					_disposables = null;
				}
				if (_ortValue != null)
				{
					_ortValue.Dispose();
					_ortValue = null;
				}
				_disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	internal class OrtValueTensor<T> : MemoryManager<T>, IOrtValueOwner, IDisposable
	{
		private OrtValue _ortValue;

		private readonly nint _dataBufferPointer;

		public OrtValue Value => _ortValue;

		public bool IsDisposed { get; private set; }

		public int[] Dimensions { get; }

		public int Rank => Dimensions.Length;

		public int Count { get; }

		public int ElementWidth { get; }

		public TensorElementType ElementType { get; }

		public OrtValueTensor(ref OrtValue ortValue)
		{
			OrtTensorTypeAndShapeInfo tensorTypeAndShape = ortValue.GetTensorTypeAndShape();
			TensorElementType elementDataType = tensorTypeAndShape.ElementDataType;
			TensorElementTypeInfo tensorElementTypeInfo = TensorBase.GetElementTypeInfo(elementDataType) ?? throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"Unable to query type information for data type: {elementDataType}");
			if (typeof(T) != tensorElementTypeInfo.TensorType)
			{
				throw new OnnxRuntimeException(ErrorCode.InvalidArgument, $"The OrtValueTensor<T> type being instantiated for T = [{typeof(T)}] while supplied OrtValue contains T = [{tensorElementTypeInfo.TensorType}]");
			}
			ElementType = elementDataType;
			ElementWidth = tensorElementTypeInfo.TypeSize;
			Count = (int)tensorTypeAndShape.ElementCount;
			Dimensions = Array.ConvertAll(tensorTypeAndShape.Shape, Convert.ToInt32);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorMutableData(ortValue.Handle, out _dataBufferPointer));
			_ortValue = ortValue;
			ortValue = null;
		}

		public unsafe override Span<T> GetSpan()
		{
			_ = (Span<T>)null;
			return new Span<T>((void*)_dataBufferPointer, Count);
		}

		public unsafe override MemoryHandle Pin(int elementIndex = 0)
		{
			if (elementIndex >= Count)
			{
				throw new ArgumentOutOfRangeException("elementIndex");
			}
			return new MemoryHandle(((IntPtr)new IntPtr(((IntPtr)_dataBufferPointer).ToInt64() + (long)elementIndex * (long)ElementWidth)).ToPointer());
		}

		public override void Unpin()
		{
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (!IsDisposed)
			{
				if (_ortValue != null)
				{
					_ortValue.Dispose();
					_ortValue = null;
				}
				IsDisposed = true;
			}
		}
	}
	public class PrePackedWeightsContainer : SafeHandle
	{
		internal nint Pointer => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public PrePackedWeightsContainer()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreatePrepackedWeightsContainer(out handle));
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleasePrepackedWeightsContainer(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtTensorRTProviderOptions : SafeHandle
	{
		private int _deviceId;

		private string _deviceIdStr = "device_id";

		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtTensorRTProviderOptions()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateTensorRTProviderOptions(out handle));
		}

		public string GetOptions()
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetTensorRTProviderOptionsAsString(handle, defaultInstance.Pointer, out var ptr));
			return NativeOnnxValueHelper.StringFromNativeUtf8(ptr, defaultInstance);
		}

		private static nint UpdateTRTOptions(nint handle, nint[] keys, nint[] values, nuint count)
		{
			return NativeMethods.OrtUpdateTensorRTProviderOptions(handle, keys, values, count);
		}

		public void UpdateOptions(Dictionary<string, string> providerOptions)
		{
			ProviderOptionsUpdater.Update(providerOptions, handle, UpdateTRTOptions);
			if (providerOptions.ContainsKey(_deviceIdStr))
			{
				_deviceId = int.Parse(providerOptions[_deviceIdStr]);
			}
		}

		public int GetDeviceId()
		{
			return _deviceId;
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseTensorRTProviderOptions(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtCUDAProviderOptions : SafeHandle
	{
		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtCUDAProviderOptions()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateCUDAProviderOptions(out handle));
		}

		public string GetOptions()
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetCUDAProviderOptionsAsString(handle, defaultInstance.Pointer, out var ptr));
			return NativeOnnxValueHelper.StringFromNativeUtf8(ptr, defaultInstance);
		}

		private static nint UpdateCUDAProviderOptions(nint handle, nint[] keys, nint[] values, nuint count)
		{
			return NativeMethods.OrtUpdateCUDAProviderOptions(handle, keys, values, count);
		}

		public void UpdateOptions(Dictionary<string, string> providerOptions)
		{
			ProviderOptionsUpdater.Update(providerOptions, handle, UpdateCUDAProviderOptions);
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseCUDAProviderOptions(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class OrtROCMProviderOptions : SafeHandle
	{
		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtROCMProviderOptions()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateROCMProviderOptions(out handle));
		}

		public string GetOptions()
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			NativeApiStatus.VerifySuccess(NativeMethods.OrtGetROCMProviderOptionsAsString(handle, defaultInstance.Pointer, out var ptr));
			return NativeOnnxValueHelper.StringFromNativeUtf8(ptr, defaultInstance);
		}

		private static nint UpdateROCMProviderOptions(nint handle, nint[] keys, nint[] values, nuint count)
		{
			return NativeMethods.OrtUpdateROCMProviderOptions(handle, keys, values, count);
		}

		public void UpdateOptions(Dictionary<string, string> providerOptions)
		{
			ProviderOptionsUpdater.Update(providerOptions, handle, UpdateROCMProviderOptions);
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseROCMProviderOptions(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public class ProviderOptionsValueHelper
	{
		public static void StringToDict(string s, Dictionary<string, string> dict)
		{
			string[] array = s.Split(';');
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('=');
				if (array2.Length != 2)
				{
					throw new ArgumentException("Make sure input string contains key-value paris, e.g. key1=value1;key2=value2...", "s");
				}
				dict.Add(array2[0], array2[1]);
			}
		}
	}
	[Flags]
	public enum CoreMLFlags : uint
	{
		COREML_FLAG_USE_NONE = 0u,
		COREML_FLAG_USE_CPU_ONLY = 1u,
		COREML_FLAG_ENABLE_ON_SUBGRAPH = 2u,
		COREML_FLAG_ONLY_ENABLE_DEVICE_WITH_ANE = 4u,
		COREML_FLAG_ONLY_ALLOW_STATIC_INPUT_SHAPES = 8u,
		COREML_FLAG_CREATE_MLPROGRAM = 0x10u,
		COREML_FLAG_USE_CPU_AND_GPU = 0x20u,
		COREML_FLAG_LAST = COREML_FLAG_USE_CPU_AND_GPU
	}
	[Flags]
	public enum NnapiFlags
	{
		NNAPI_FLAG_USE_NONE = 0,
		NNAPI_FLAG_USE_FP16 = 1,
		NNAPI_FLAG_USE_NCHW = 2,
		NNAPI_FLAG_CPU_DISABLED = 4,
		NNAPI_FLAG_CPU_ONLY = 8,
		NNAPI_FLAG_LAST = NNAPI_FLAG_CPU_ONLY
	}
	public class RunOptions : SafeHandle
	{
		private OrtLoggingLevel _logSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_WARNING;

		private int _logVerbosityLevel;

		private string _logId = "";

		private bool _terminate;

		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public OrtLoggingLevel LogSeverityLevel
		{
			get
			{
				return _logSeverityLevel;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtRunOptionsSetRunLogSeverityLevel(handle, value));
				_logSeverityLevel = value;
			}
		}

		public int LogVerbosityLevel
		{
			get
			{
				return _logVerbosityLevel;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtRunOptionsSetRunLogVerbosityLevel(handle, value));
				_logVerbosityLevel = value;
			}
		}

		public string LogId
		{
			get
			{
				return _logId;
			}
			set
			{
				byte[] runTag = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(value);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtRunOptionsSetRunTag(handle, runTag));
				_logId = value;
			}
		}

		public bool Terminate
		{
			get
			{
				return _terminate;
			}
			set
			{
				if (!_terminate & value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtRunOptionsSetTerminate(handle));
					_terminate = true;
				}
				else if (_terminate && !value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtRunOptionsUnsetTerminate(handle));
					_terminate = false;
				}
			}
		}

		public RunOptions()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateRunOptions(out handle));
		}

		public void AddRunConfigEntry(string configKey, string configValue)
		{
			byte[] configKey2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(configKey);
			byte[] configValue2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(configValue);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtAddRunConfigEntry(handle, configKey2, configValue2));
		}

		public void AddActiveLoraAdapter(OrtLoraAdapter loraAdapter)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRunOptionsAddActiveLoraAdapter(handle, loraAdapter.Handle));
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseRunOptions(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public enum GraphOptimizationLevel
	{
		ORT_DISABLE_ALL = 0,
		ORT_ENABLE_BASIC = 1,
		ORT_ENABLE_EXTENDED = 2,
		ORT_ENABLE_LAYOUT = 3,
		ORT_ENABLE_ALL = 99
	}
	public enum ExecutionMode
	{
		ORT_SEQUENTIAL,
		ORT_PARALLEL
	}
	public enum ExecutionProviderDevicePolicy
	{
		DEFAULT,
		PREFER_CPU,
		PREFER_NPU,
		PREFER_GPU,
		MAX_PERFORMANCE,
		MAX_EFFICIENCY,
		MIN_OVERALL_POWER
	}
	public class SessionOptions : SafeHandle
	{
		private class ExecutionProviderAppender
		{
			private byte[] _utf8ProviderName;

			internal ExecutionProviderAppender(byte[] providerName)
			{
				_utf8ProviderName = providerName;
			}

			public nint Appender(nint handle, nint[] optKeys, nint[] optValues, nuint optCount)
			{
				return NativeMethods.SessionOptionsAppendExecutionProvider(handle, _utf8ProviderName, optKeys, optValues, optCount);
			}
		}

		public delegate List<OrtEpDevice> EpSelectionDelegate(IReadOnlyList<OrtEpDevice> epDevices, OrtKeyValuePairs modelMetadata, OrtKeyValuePairs runtimeMetadata, uint maxSelections);

		internal class EpSelectionPolicyConnector
		{
			private readonly EpSelectionDelegate _csharpDelegate;

			internal EpSelectionPolicyConnector(EpSelectionDelegate selectionDelegate)
			{
				_csharpDelegate = selectionDelegate;
			}

			public unsafe static nint EpSelectionPolicyWrapper(nint epDevicesIn, uint numDevices, nint modelMetadataIn, nint runtimeMetadataIn, nint selectedOut, uint maxSelected, out nuint numSelected, nint state)
			{
				numSelected = UIntPtr.Zero;
				try
				{
					EpSelectionPolicyConnector epSelectionPolicyConnector = (EpSelectionPolicyConnector)GCHandle.FromIntPtr(state).Target;
					void* pointer = ((IntPtr)epDevicesIn).ToPointer();
					Span<nint> span = new Span<nint>(pointer, checked((int)numDevices));
					List<OrtEpDevice> list = new List<OrtEpDevice>();
					for (int i = 0; i < numDevices; i++)
					{
						list.Add(new OrtEpDevice(span[i]));
					}
					OrtKeyValuePairs modelMetadata = new OrtKeyValuePairs(modelMetadataIn);
					OrtKeyValuePairs runtimeMetadata = new OrtKeyValuePairs(runtimeMetadataIn);
					List<OrtEpDevice> list2 = epSelectionPolicyConnector._csharpDelegate(list, modelMetadata, runtimeMetadata, maxSelected);
					if (list2.Count > maxSelected)
					{
						string s = $"The number of selected devices ({list2.Count}) returned by the C# selection delegate exceeds the maximum ({maxSelected}).";
						return NativeMethods.OrtCreateStatus(1u, NativeOnnxValueHelper.StringToZeroTerminatedUtf8(s));
					}
					numSelected = (nuint)list2.Count;
					void* pointer2 = ((IntPtr)selectedOut).ToPointer();
					Span<nint> span2 = new Span<nint>(pointer2, (int)maxSelected);
					int num = 0;
					foreach (OrtEpDevice item in list2)
					{
						span2[num] = item.Handle;
						num++;
					}
				}
				catch (Exception ex)
				{
					string s2 = "The C# selection delegate threw an exception: " + ex.Message;
					return NativeMethods.OrtCreateStatus(1u, NativeOnnxValueHelper.StringToZeroTerminatedUtf8(s2));
				}
				return IntPtr.Zero;
			}
		}

		private static string[] cudaDelayLoadedLibs = new string[0];

		private static string[] trtDelayLoadedLibs = new string[0];

		private bool _enableMemoryPattern = true;

		private bool _enableProfiling;

		private string _optimizedModelFilePath = "";

		private bool _enableCpuMemArena = true;

		private string _logId = string.Empty;

		private OrtLoggingLevel _logSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_WARNING;

		private int _logVerbosityLevel;

		private int _intraOpNumThreads;

		private int _interOpNumThreads;

		private GraphOptimizationLevel _graphOptimizationLevel = GraphOptimizationLevel.ORT_ENABLE_ALL;

		private ExecutionMode _executionMode;

		private EpSelectionPolicyConnector _epSelectionPolicyConnector;

		private GCHandle _epSelectionPolicyConnectorHandle;

		private NativeMethods.DOrtEpSelectionDelegate _epSelectionPolicyDelegate;

		private GCHandle _epSelectionPolicyDelegateHandle;

		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		public bool EnableMemoryPattern
		{
			get
			{
				return _enableMemoryPattern;
			}
			set
			{
				if (!_enableMemoryPattern & value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtEnableMemPattern(handle));
					_enableMemoryPattern = true;
				}
				else if (_enableMemoryPattern && !value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtDisableMemPattern(handle));
					_enableMemoryPattern = false;
				}
			}
		}

		public string ProfileOutputPathPrefix { get; set; } = "onnxruntime_profile_";

		public bool EnableProfiling
		{
			get
			{
				return _enableProfiling;
			}
			set
			{
				if (!_enableProfiling & value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtEnableProfiling(handle, NativeOnnxValueHelper.GetPlatformSerializedString(ProfileOutputPathPrefix)));
					_enableProfiling = true;
				}
				else if (_enableProfiling && !value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtDisableProfiling(handle));
					_enableProfiling = false;
				}
			}
		}

		public string OptimizedModelFilePath
		{
			get
			{
				return _optimizedModelFilePath;
			}
			set
			{
				if (value != _optimizedModelFilePath)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtSetOptimizedModelFilePath(handle, NativeOnnxValueHelper.GetPlatformSerializedString(value)));
					_optimizedModelFilePath = value;
				}
			}
		}

		public bool EnableCpuMemArena
		{
			get
			{
				return _enableCpuMemArena;
			}
			set
			{
				if (!_enableCpuMemArena & value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtEnableCpuMemArena(handle));
					_enableCpuMemArena = true;
				}
				else if (_enableCpuMemArena && !value)
				{
					NativeApiStatus.VerifySuccess(NativeMethods.OrtDisableCpuMemArena(handle));
					_enableCpuMemArena = false;
				}
			}
		}

		public string LogId
		{
			get
			{
				return _logId;
			}
			set
			{
				byte[] logId = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(value);
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetSessionLogId(handle, logId));
				_logId = value;
			}
		}

		public OrtLoggingLevel LogSeverityLevel
		{
			get
			{
				return _logSeverityLevel;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetSessionLogSeverityLevel(handle, value));
				_logSeverityLevel = value;
			}
		}

		public int LogVerbosityLevel
		{
			get
			{
				return _logVerbosityLevel;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetSessionLogVerbosityLevel(handle, value));
				_logVerbosityLevel = value;
			}
		}

		public int IntraOpNumThreads
		{
			get
			{
				return _intraOpNumThreads;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetIntraOpNumThreads(handle, value));
				_intraOpNumThreads = value;
			}
		}

		public int InterOpNumThreads
		{
			get
			{
				return _interOpNumThreads;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetInterOpNumThreads(handle, value));
				_interOpNumThreads = value;
			}
		}

		public GraphOptimizationLevel GraphOptimizationLevel
		{
			get
			{
				return _graphOptimizationLevel;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetSessionGraphOptimizationLevel(handle, value));
				_graphOptimizationLevel = value;
			}
		}

		public ExecutionMode ExecutionMode
		{
			get
			{
				return _executionMode;
			}
			set
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSetSessionExecutionMode(handle, value));
				_executionMode = value;
			}
		}

		public SessionOptions()
			: base(IntPtr.Zero, ownsHandle: true)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtCreateSessionOptions(out handle));
			OrtEnv.Instance();
		}

		public static SessionOptions MakeSessionOptionWithCudaProvider(int deviceId = 0)
		{
			CheckCudaExecutionProviderDLLs();
			SessionOptions sessionOptions = new SessionOptions();
			try
			{
				sessionOptions.AppendExecutionProvider_CUDA(deviceId);
				return sessionOptions;
			}
			catch (Exception)
			{
				sessionOptions.Dispose();
				throw;
			}
		}

		public static SessionOptions MakeSessionOptionWithCudaProvider(OrtCUDAProviderOptions cudaProviderOptions)
		{
			CheckCudaExecutionProviderDLLs();
			SessionOptions sessionOptions = new SessionOptions();
			try
			{
				sessionOptions.AppendExecutionProvider_CUDA(cudaProviderOptions);
				return sessionOptions;
			}
			catch (Exception)
			{
				sessionOptions.Dispose();
				throw;
			}
		}

		public static SessionOptions MakeSessionOptionWithTensorrtProvider(int deviceId = 0)
		{
			CheckTensorrtExecutionProviderDLLs();
			SessionOptions sessionOptions = new SessionOptions();
			try
			{
				sessionOptions.AppendExecutionProvider_Tensorrt(deviceId);
				sessionOptions.AppendExecutionProvider_CUDA(deviceId);
				return sessionOptions;
			}
			catch (Exception)
			{
				sessionOptions.Dispose();
				throw;
			}
		}

		public static SessionOptions MakeSessionOptionWithTensorrtProvider(OrtTensorRTProviderOptions trtProviderOptions)
		{
			CheckTensorrtExecutionProviderDLLs();
			SessionOptions sessionOptions = new SessionOptions();
			try
			{
				sessionOptions.AppendExecutionProvider_Tensorrt(trtProviderOptions);
				sessionOptions.AppendExecutionProvider_CUDA(trtProviderOptions.GetDeviceId());
				return sessionOptions;
			}
			catch (Exception)
			{
				sessionOptions.Dispose();
				throw;
			}
		}

		public static SessionOptions MakeSessionOptionWithRocmProvider(int deviceId = 0)
		{
			CheckRocmExecutionProviderDLLs();
			SessionOptions sessionOptions = new SessionOptions();
			try
			{
				sessionOptions.AppendExecutionProvider_ROCm(deviceId);
				return sessionOptions;
			}
			catch (Exception)
			{
				sessionOptions.Dispose();
				throw;
			}
		}

		public static SessionOptions MakeSessionOptionWithRocmProvider(OrtROCMProviderOptions rocmProviderOptions)
		{
			CheckRocmExecutionProviderDLLs();
			SessionOptions sessionOptions = new SessionOptions();
			try
			{
				sessionOptions.AppendExecutionProvider_ROCm(rocmProviderOptions);
				return sessionOptions;
			}
			catch (Exception)
			{
				sessionOptions.Dispose();
				throw;
			}
		}

		public void AppendExecutionProvider_CPU(int useArena = 1)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_CPU(handle, useArena));
		}

		public void AppendExecutionProvider_Dnnl(int useArena = 1)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_Dnnl(handle, useArena));
		}

		public void AppendExecutionProvider_CUDA(int deviceId = 0)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_CUDA(handle, deviceId));
		}

		public void AppendExecutionProvider_CUDA(OrtCUDAProviderOptions cudaProviderOptions)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.SessionOptionsAppendExecutionProvider_CUDA_V2(handle, cudaProviderOptions.Handle));
		}

		public void AppendExecutionProvider_DML(int deviceId = 0)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_DML(handle, deviceId));
		}

		public void AppendExecutionProvider_OpenVINO(string deviceId = "")
		{
			byte[] device_id = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(deviceId);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_OpenVINO(handle, device_id));
		}

		public void AppendExecutionProvider_Tensorrt(int deviceId = 0)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_Tensorrt(handle, deviceId));
		}

		public void AppendExecutionProvider_Tensorrt(OrtTensorRTProviderOptions trtProviderOptions)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.SessionOptionsAppendExecutionProvider_TensorRT_V2(handle, trtProviderOptions.Handle));
		}

		public void AppendExecutionProvider_ROCm(int deviceId = 0)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_ROCM(handle, deviceId));
		}

		public void AppendExecutionProvider_ROCm(OrtROCMProviderOptions rocmProviderOptions)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.SessionOptionsAppendExecutionProvider_ROCM(handle, rocmProviderOptions.Handle));
		}

		public void AppendExecutionProvider_MIGraphX(int deviceId = 0)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_MIGraphX(handle, deviceId));
		}

		public void AppendExecutionProvider_Nnapi(NnapiFlags nnapiFlags = NnapiFlags.NNAPI_FLAG_USE_NONE)
		{
			throw new NotSupportedException("The NNAPI Execution Provider is not supported in this build");
		}

		public void AppendExecutionProvider_CoreML(CoreMLFlags coremlFlags = CoreMLFlags.COREML_FLAG_USE_NONE)
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_CoreML(handle, (uint)coremlFlags));
				return;
			}
			throw new NotSupportedException("The CoreML Execution Provider is not supported in this build");
		}

		public void AppendExecutionProvider(string providerName, Dictionary<string, string> providerOptions = null)
		{
			if (providerOptions == null)
			{
				providerOptions = new Dictionary<string, string>();
			}
			ExecutionProviderAppender executionProviderAppender = new ExecutionProviderAppender(NativeOnnxValueHelper.StringToZeroTerminatedUtf8(providerName));
			ProviderOptionsUpdater.Update(providerOptions, handle, executionProviderAppender.Appender);
		}

		public void AppendExecutionProvider(OrtEnv env, IReadOnlyList<OrtEpDevice> epDevices, IReadOnlyDictionary<string, string> epOptions)
		{
			if (epDevices == null || epDevices.Count == 0)
			{
				throw new ArgumentException("No execution provider devices were specified.");
			}
			nint[] array = new nint[epDevices.Count];
			for (int i = 0; i < epDevices.Count; i++)
			{
				array[i] = epDevices[i].Handle;
			}
			if (epOptions != null && epOptions.Count > 0)
			{
				using (OrtKeyValuePairs ortKeyValuePairs = new OrtKeyValuePairs(epOptions))
				{
					ortKeyValuePairs.GetKeyValuePairHandles(out var keysHandle, out var valuesHandle, out var numEntries);
					NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_V2(handle, env.Handle, array, (nuint)epDevices.Count, keysHandle, valuesHandle, numEntries));
					return;
				}
			}
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsAppendExecutionProvider_V2(handle, env.Handle, array, (nuint)epDevices.Count, IntPtr.Zero, IntPtr.Zero, UIntPtr.Zero));
		}

		public void RegisterCustomOpLibrary(string libraryPath)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRegisterCustomOpsLibrary_V2(handle, NativeOnnxValueHelper.GetPlatformSerializedString(libraryPath)));
		}

		public void RegisterCustomOpLibraryV2(string libraryPath, out nint libraryHandle)
		{
			byte[] libraryPath2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(libraryPath);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtRegisterCustomOpsLibrary(handle, libraryPath2, out libraryHandle));
		}

		public void RegisterOrtExtensions()
		{
			try
			{
				OrtApiBase ortApiBase = NativeMethods.OrtGetApiBase();
				NativeApiStatus.VerifySuccess(OrtExtensionsNativeMethods.RegisterCustomOps(handle, ref ortApiBase));
			}
			catch (DllNotFoundException)
			{
				throw new OnnxRuntimeException(ErrorCode.NoSuchFile, "The ONNX Runtime extensions library was not found. The Microsoft.ML.OnnxRuntime.Extensions NuGet package must be referenced by the project to use 'OrtExtensions.RegisterCustomOps.");
			}
		}

		public void AddInitializer(string name, OrtValue ortValue)
		{
			byte[] name2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(name);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtAddInitializer(handle, name2, ortValue.Handle));
		}

		public void AddSessionConfigEntry(string configKey, string configValue)
		{
			byte[] configKey2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(configKey);
			byte[] configValue2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(configValue);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtAddSessionConfigEntry(handle, configKey2, configValue2));
		}

		public void AddFreeDimensionOverride(string dimDenotation, long dimValue)
		{
			byte[] dimDenotation2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(dimDenotation);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtAddFreeDimensionOverride(handle, dimDenotation2, dimValue));
		}

		public void AddFreeDimensionOverrideByName(string dimName, long dimValue)
		{
			byte[] dimName2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(dimName);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtAddFreeDimensionOverrideByName(handle, dimName2, dimValue));
		}

		public void SetEpSelectionPolicy(ExecutionProviderDevicePolicy policy)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsSetEpSelectionPolicy(handle, (int)policy));
		}

		public void SetEpSelectionPolicyDelegate(EpSelectionDelegate selectionDelegate = null)
		{
			_epSelectionPolicyConnector = new EpSelectionPolicyConnector(selectionDelegate);
			_epSelectionPolicyDelegate = EpSelectionPolicyConnector.EpSelectionPolicyWrapper;
			_epSelectionPolicyConnectorHandle = GCHandle.Alloc(_epSelectionPolicyConnector);
			_epSelectionPolicyDelegateHandle = GCHandle.Alloc(_epSelectionPolicyDelegate);
			nint functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(_epSelectionPolicyDelegate);
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsSetEpSelectionPolicyDelegate(handle, functionPointerForDelegate, GCHandle.ToIntPtr(_epSelectionPolicyConnectorHandle)));
		}

		public void DisablePerSessionThreads()
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtDisablePerSessionThreads(handle));
		}

		public void SetLoadCancellationFlag(bool value)
		{
			NativeApiStatus.VerifySuccess(NativeMethods.OrtSessionOptionsSetLoadCancellationFlag(handle, value));
		}

		[DllImport("kernel32.dll")]
		private static extern nint LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll")]
		private static extern uint GetSystemDirectory([Out] StringBuilder lpBuffer, uint uSize);

		private static bool CheckCudaExecutionProviderDLLs()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				string[] array = cudaDelayLoadedLibs;
				foreach (string text in array)
				{
					if (LoadLibrary(text) == IntPtr.Zero)
					{
						StringBuilder stringBuilder = new StringBuilder(string.Empty, 2048);
						GetSystemDirectory(stringBuilder, (uint)stringBuilder.Capacity);
						throw new OnnxRuntimeException(ErrorCode.NoSuchFile, $"kernel32.LoadLibrary():'{text}' not found. CUDA is required for GPU execution. . Verify it is available in the system directory={stringBuilder}. Else copy it to the output folder.");
					}
				}
			}
			return true;
		}

		private static bool CheckTensorrtExecutionProviderDLLs()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				string[] array = trtDelayLoadedLibs;
				foreach (string text in array)
				{
					if (LoadLibrary(text) == IntPtr.Zero)
					{
						StringBuilder stringBuilder = new StringBuilder(string.Empty, 2048);
						GetSystemDirectory(stringBuilder, (uint)stringBuilder.Capacity);
						throw new OnnxRuntimeException(ErrorCode.NoSuchFile, $"kernel32.LoadLibrary():'{text}' not found. TensorRT/CUDA are required for GPU execution. . Verify it is available in the system directory={stringBuilder}. Else copy it to the output folder.");
					}
				}
			}
			return true;
		}

		private static bool CheckRocmExecutionProviderDLLs()
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				throw new NotSupportedException("ROCm Execution Provider is not currently supported on Windows.");
			}
			return true;
		}

		protected override bool ReleaseHandle()
		{
			NativeMethods.OrtReleaseSessionOptions(handle);
			handle = IntPtr.Zero;
			if (_epSelectionPolicyConnectorHandle.IsAllocated)
			{
				_epSelectionPolicyConnectorHandle.Free();
				_epSelectionPolicyConnector = null;
			}
			if (_epSelectionPolicyDelegateHandle.IsAllocated)
			{
				_epSelectionPolicyDelegateHandle.Free();
				_epSelectionPolicyDelegate = null;
			}
			return true;
		}
	}
	public static class SessionOptionsContainer
	{
		private static Lazy<Action<SessionOptions>> _defaultHandler;

		private static readonly Dictionary<string, Lazy<Action<SessionOptions>>> _configurationHandlers = new Dictionary<string, Lazy<Action<SessionOptions>>>();

		private static Lazy<Action<SessionOptions>> DefaultHandler
		{
			get
			{
				if (_defaultHandler == null)
				{
					return _defaultHandler = new Lazy<Action<SessionOptions>>(() => (SessionOptions options) =>
					{
					});
				}
				return _defaultHandler;
			}
		}

		public static void Register(Action<SessionOptions> defaultHandler)
		{
			_defaultHandler = new Lazy<Action<SessionOptions>>(() => defaultHandler);
		}

		public static void Register(string configuration, Action<SessionOptions> handler)
		{
			_configurationHandlers[configuration] = new Lazy<Action<SessionOptions>>(() => handler);
		}

		public static SessionOptions Create(string configuration = null, bool useDefaultAsFallback = true)
		{
			return new SessionOptions().ApplyConfiguration(configuration, useDefaultAsFallback);
		}

		public static void Reset()
		{
			_defaultHandler = null;
			_configurationHandlers.Clear();
		}

		public static SessionOptions ApplyConfiguration(this SessionOptions options, string configuration = null, bool useDefaultAsFallback = true)
		{
			Resolve(configuration, useDefaultAsFallback)(options);
			return options;
		}

		private static Action<SessionOptions> Resolve(string configuration = null, bool useDefaultAsFallback = true)
		{
			if (string.IsNullOrWhiteSpace(configuration))
			{
				return DefaultHandler.Value;
			}
			if (_configurationHandlers.TryGetValue(configuration, out var value))
			{
				return value.Value;
			}
			if (useDefaultAsFallback)
			{
				return DefaultHandler.Value;
			}
			throw new KeyNotFoundException("Configuration not found for '" + configuration + "'");
		}
	}
	public class CheckpointState : SafeHandle
	{
		internal enum PropertyType : long
		{
			Int,
			Float,
			String
		}

		internal nint Handle => handle;

		public override bool IsInvalid => handle == IntPtr.Zero;

		private CheckpointState(nint checkpointHandle)
			: base(checkpointHandle, ownsHandle: true)
		{
		}

		private unsafe void AddPropertyImpl<T>(string propertyName, PropertyType propertyType, T propertyValue) where T : unmanaged
		{
			byte[] propertyName2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(propertyName);
			fixed (T* propertyValue2 = new T[1] { propertyValue })
			{
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtAddProperty(handle, propertyName2, propertyType, (nint)propertyValue2));
			}
		}

		public static CheckpointState LoadCheckpoint(string checkpointPath)
		{
			if (!NativeTrainingMethods.TrainingEnabled())
			{
				throw new InvalidOperationException("This package does not contain the training API. Please install the Microsoft.ML.OnnxRuntime.Training NuGet package.\n");
			}
			_ = OrtEnv.Instance().Handle;
			nint checkpointState = IntPtr.Zero;
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtLoadCheckpoint(NativeOnnxValueHelper.GetPlatformSerializedString(checkpointPath), out checkpointState));
			return new CheckpointState(checkpointState);
		}

		public static void SaveCheckpoint(CheckpointState state, string checkpointPath, bool includeOptimizerState = false)
		{
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtSaveCheckpoint(state.Handle, NativeOnnxValueHelper.GetPlatformSerializedString(checkpointPath), includeOptimizerState));
		}

		public void AddProperty(string propertyName, long propertyValue)
		{
			AddPropertyImpl(propertyName, PropertyType.Int, propertyValue);
		}

		public void AddProperty(string propertyName, float propertyValue)
		{
			AddPropertyImpl(propertyName, PropertyType.Float, propertyValue);
		}

		public unsafe void AddProperty(string propertyName, string propertyValue)
		{
			byte[] propertyName2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(propertyName);
			fixed (byte* propertyValue2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(propertyValue))
			{
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtAddProperty(handle, propertyName2, PropertyType.String, (nint)propertyValue2));
			}
		}

		public unsafe object GetProperty(string propertyName)
		{
			byte[] propertyName2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(propertyName);
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			nint propertyValue = IntPtr.Zero;
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetProperty(handle, propertyName2, defaultInstance.Pointer, out var propertyType, out propertyValue));
			try
			{
				return propertyType switch
				{
					PropertyType.Int => (object)(*(long*)propertyValue), 
					PropertyType.Float => *(float*)propertyValue, 
					PropertyType.String => NativeOnnxValueHelper.StringFromNativeUtf8(propertyValue), 
					_ => throw new ArgumentException("Expected the property type to be one of long, float or string. Unknown type retrieved " + (IntPtr)propertyValue), 
				};
			}
			finally
			{
				defaultInstance.FreeMemory(propertyValue);
			}
		}

		public void UpdateParameter(string parameterName, OrtValue parameter)
		{
			if (parameter.OnnxType != OnnxValueType.ONNX_TYPE_TENSOR)
			{
				throw new ArgumentException("Incorrect buffer received. Expected a tensor parameter.");
			}
			byte[] parameterName2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(parameterName);
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtUpdateParameter(handle, parameterName2, parameter.Handle));
		}

		public OrtValue GetParameter(string parameterName)
		{
			byte[] parameterName2 = NativeOnnxValueHelper.StringToZeroTerminatedUtf8(parameterName);
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetParameter(handle, parameterName2, OrtAllocator.DefaultInstance.Pointer, out var parameter));
			return new OrtValue(parameter);
		}

		protected override bool ReleaseHandle()
		{
			NativeTrainingMethods.OrtReleaseCheckpointState(handle);
			handle = IntPtr.Zero;
			return true;
		}
	}
	public struct OrtTrainingApi
	{
		public nint LoadCheckpoint;

		public nint SaveCheckpoint;

		public nint CreateTrainingSession;

		public nint CreateTrainingSessionFromBuffer;

		public nint TrainingSessionGetTrainingModelOutputCount;

		public nint TrainingSessionGetEvalModelOutputCount;

		public nint TrainingSessionGetTrainingModelOutputName;

		public nint TrainingSessionGetEvalModelOutputName;

		public nint LazyResetGrad;

		public nint TrainStep;

		public nint EvalStep;

		public nint SetLearningRate;

		public nint GetLearningRate;

		public nint OptimizerStep;

		public nint RegisterLinearLRScheduler;

		public nint SchedulerStep;

		public nint GetParametersSize;

		public nint CopyParametersToBuffer;

		public nint CopyBufferToParameters;

		public nint ReleaseTrainingSession;

		public nint ReleaseCheckpointState;

		public nint ExportModelForInferencing;

		public nint SetSeed;

		public nint TrainingSessionGetTrainingModelInputCount;

		public nint TrainingSessionGetEvalModelInputCount;

		public nint TrainingSessionGetTrainingModelInputName;

		public nint TrainingSessionGetEvalModelInputName;

		public nint AddProperty;

		public nint GetProperty;

		public nint LoadCheckpointFromBuffer;

		public nint GetParameterTypeAndShape;

		public nint UpdateParameter;

		public nint GetParameter;
	}
	internal static class NativeTrainingMethods
	{
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate ref OrtApi DOrtGetApi(uint version);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTrainingApi(uint version);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtLoadCheckpoint(byte[] checkpointPath, out nint checkpointState);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSaveCheckpoint(nint checkpointState, byte[] checkpointPath, bool includeOptimizerState);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateTrainingSession(nint environment, nint sessionOptions, nint checkpointState, byte[] trainModelPath, byte[] evalModelPath, byte[] optimizerModelPath, out nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTrainingModelOutputCount(nint session, out nuint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetEvalModelOutputCount(nint session, out nuint count);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTrainingModelOutputName(nint session, nuint index, nint allocator, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetEvalModelOutputName(nint session, nuint index, nint allocator, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtLazyResetGrad(nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtTrainStep(nint session, nint runOptions, nuint inputCount, nint[] inputValues, nuint outputCount, nint[] outputValues);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtEvalStep(nint session, nint runOptions, nuint inputCount, nint[] inputValues, nuint outputCount, nint[] outputValues);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtOptimizerStep(nint session, nint runOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetLearningRate(nint session, float learningRate);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetLearningRate(nint session, out float learningRate);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtRegisterLinearLRScheduler(nint session, long warmupStepCount, long totalStepCount, float learningRate);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSchedulerStep(nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetParametersSize(nint session, out nuint buffer_size, bool only_trainable);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCopyParametersToBuffer(nint session, nint buffer, bool only_trainable);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCopyBufferToParameters(nint session, nint buffer, bool only_trainable);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseTrainingSession(nint session);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseCheckpointState(nint checkpointState);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtExportModelForInferencing(nint session, byte[] inferenceModelPath, nuint graphOutputCount, nint[] graphOutputNames);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtSetSeed(long seed);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTrainingModelInputCount(nint session, out nuint inputCount);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetEvalModelInputCount(nint session, out nuint inputCount);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetTrainingModelInputName(nint session, nuint index, nint allocator, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetEvalModelInputName(nint session, nuint index, nint allocator, out nint name);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtAddProperty(nint checkpointState, byte[] propertyName, CheckpointState.PropertyType propertyType, nint propertyValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetProperty(nint checkpointState, byte[] propertyName, nint allocator, out CheckpointState.PropertyType propertyType, out nint propertyValue);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetParameterTypeAndShape(nint checkpointState, byte[] parameterName, out nint parameterTypeAndShape);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtUpdateParameter(nint checkpointState, byte[] parameterName, nint parameter);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtGetParameter(nint checkpointState, byte[] parameterName, nint allocator, out nint parameter);

		private static OrtApi api_;

		private static OrtTrainingApi trainingApi_;

		private static nint trainingApiPtr;

		public static DOrtGetTrainingApi OrtGetTrainingApi;

		public static DOrtLoadCheckpoint OrtLoadCheckpoint;

		public static DOrtSaveCheckpoint OrtSaveCheckpoint;

		public static DOrtCreateTrainingSession OrtCreateTrainingSession;

		public static DOrtGetTrainingModelOutputCount OrtGetTrainingModelOutputCount;

		public static DOrtGetEvalModelOutputCount OrtGetEvalModelOutputCount;

		public static DOrtGetTrainingModelOutputName OrtGetTrainingModelOutputName;

		public static DOrtGetEvalModelOutputName OrtGetEvalModelOutputName;

		public static DOrtLazyResetGrad OrtLazyResetGrad;

		public static DOrtTrainStep OrtTrainStep;

		public static DOrtEvalStep OrtEvalStep;

		public static DOrtOptimizerStep OrtOptimizerStep;

		public static DOrtSetLearningRate OrtSetLearningRate;

		public static DOrtGetLearningRate OrtGetLearningRate;

		public static DOrtRegisterLinearLRScheduler OrtRegisterLinearLRScheduler;

		public static DOrtSchedulerStep OrtSchedulerStep;

		public static DOrtGetParametersSize OrtGetParametersSize;

		public static DOrtCopyParametersToBuffer OrtCopyParametersToBuffer;

		public static DOrtCopyBufferToParameters OrtCopyBufferToParameters;

		public static DOrtReleaseTrainingSession OrtReleaseTrainingSession;

		public static DOrtReleaseCheckpointState OrtReleaseCheckpointState;

		public static DOrtExportModelForInferencing OrtExportModelForInferencing;

		public static DOrtSetSeed OrtSetSeed;

		public static DOrtGetTrainingModelInputCount OrtGetTrainingModelInputCount;

		public static DOrtGetEvalModelInputCount OrtGetEvalModelInputCount;

		public static DOrtGetTrainingModelInputName OrtGetTrainingModelInputName;

		public static DOrtGetEvalModelInputName OrtGetEvalModelInputName;

		public static DOrtAddProperty OrtAddProperty;

		public static DOrtGetProperty OrtGetProperty;

		public static DOrtGetParameterTypeAndShape OrtGetParameterTypeAndShape;

		public static DOrtUpdateParameter OrtUpdateParameter;

		public static DOrtGetParameter OrtGetParameter;

		static NativeTrainingMethods()
		{
			api_ = ((DOrtGetApi)Marshal.GetDelegateForFunctionPointer(NativeMethods.OrtGetApiBase().GetApi, typeof(DOrtGetApi)))(26u);
			OrtGetTrainingApi = (DOrtGetTrainingApi)Marshal.GetDelegateForFunctionPointer(api_.GetTrainingApi, typeof(DOrtGetTrainingApi));
			trainingApiPtr = OrtGetTrainingApi(26u);
			if (trainingApiPtr != IntPtr.Zero)
			{
				trainingApi_ = (OrtTrainingApi)Marshal.PtrToStructure(trainingApiPtr, typeof(OrtTrainingApi));
				OrtLoadCheckpoint = (DOrtLoadCheckpoint)Marshal.GetDelegateForFunctionPointer(trainingApi_.LoadCheckpoint, typeof(DOrtLoadCheckpoint));
				OrtSaveCheckpoint = (DOrtSaveCheckpoint)Marshal.GetDelegateForFunctionPointer(trainingApi_.SaveCheckpoint, typeof(DOrtSaveCheckpoint));
				OrtCreateTrainingSession = (DOrtCreateTrainingSession)Marshal.GetDelegateForFunctionPointer(trainingApi_.CreateTrainingSession, typeof(DOrtCreateTrainingSession));
				OrtGetTrainingModelOutputCount = (DOrtGetTrainingModelOutputCount)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetTrainingModelOutputCount, typeof(DOrtGetTrainingModelOutputCount));
				OrtGetEvalModelOutputCount = (DOrtGetEvalModelOutputCount)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetEvalModelOutputCount, typeof(DOrtGetEvalModelOutputCount));
				OrtGetTrainingModelOutputName = (DOrtGetTrainingModelOutputName)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetTrainingModelOutputName, typeof(DOrtGetTrainingModelOutputName));
				OrtGetEvalModelOutputName = (DOrtGetEvalModelOutputName)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetEvalModelOutputName, typeof(DOrtGetEvalModelOutputName));
				OrtLazyResetGrad = (DOrtLazyResetGrad)Marshal.GetDelegateForFunctionPointer(trainingApi_.LazyResetGrad, typeof(DOrtLazyResetGrad));
				OrtTrainStep = (DOrtTrainStep)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainStep, typeof(DOrtTrainStep));
				OrtEvalStep = (DOrtEvalStep)Marshal.GetDelegateForFunctionPointer(trainingApi_.EvalStep, typeof(DOrtEvalStep));
				OrtSetLearningRate = (DOrtSetLearningRate)Marshal.GetDelegateForFunctionPointer(trainingApi_.SetLearningRate, typeof(DOrtSetLearningRate));
				OrtGetLearningRate = (DOrtGetLearningRate)Marshal.GetDelegateForFunctionPointer(trainingApi_.GetLearningRate, typeof(DOrtGetLearningRate));
				OrtOptimizerStep = (DOrtOptimizerStep)Marshal.GetDelegateForFunctionPointer(trainingApi_.OptimizerStep, typeof(DOrtOptimizerStep));
				OrtRegisterLinearLRScheduler = (DOrtRegisterLinearLRScheduler)Marshal.GetDelegateForFunctionPointer(trainingApi_.RegisterLinearLRScheduler, typeof(DOrtRegisterLinearLRScheduler));
				OrtSchedulerStep = (DOrtSchedulerStep)Marshal.GetDelegateForFunctionPointer(trainingApi_.SchedulerStep, typeof(DOrtSchedulerStep));
				OrtGetParametersSize = (DOrtGetParametersSize)Marshal.GetDelegateForFunctionPointer(trainingApi_.GetParametersSize, typeof(DOrtGetParametersSize));
				OrtCopyParametersToBuffer = (DOrtCopyParametersToBuffer)Marshal.GetDelegateForFunctionPointer(trainingApi_.CopyParametersToBuffer, typeof(DOrtCopyParametersToBuffer));
				OrtCopyBufferToParameters = (DOrtCopyBufferToParameters)Marshal.GetDelegateForFunctionPointer(trainingApi_.CopyBufferToParameters, typeof(DOrtCopyBufferToParameters));
				OrtReleaseTrainingSession = (DOrtReleaseTrainingSession)Marshal.GetDelegateForFunctionPointer(trainingApi_.ReleaseTrainingSession, typeof(DOrtReleaseTrainingSession));
				OrtReleaseCheckpointState = (DOrtReleaseCheckpointState)Marshal.GetDelegateForFunctionPointer(trainingApi_.ReleaseCheckpointState, typeof(DOrtReleaseCheckpointState));
				OrtExportModelForInferencing = (DOrtExportModelForInferencing)Marshal.GetDelegateForFunctionPointer(trainingApi_.ExportModelForInferencing, typeof(DOrtExportModelForInferencing));
				OrtSetSeed = (DOrtSetSeed)Marshal.GetDelegateForFunctionPointer(trainingApi_.SetSeed, typeof(DOrtSetSeed));
				OrtGetTrainingModelInputCount = (DOrtGetTrainingModelInputCount)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetTrainingModelInputCount, typeof(DOrtGetTrainingModelInputCount));
				OrtGetEvalModelInputCount = (DOrtGetEvalModelInputCount)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetEvalModelInputCount, typeof(DOrtGetEvalModelInputCount));
				OrtGetTrainingModelInputName = (DOrtGetTrainingModelInputName)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetTrainingModelInputName, typeof(DOrtGetTrainingModelInputName));
				OrtGetEvalModelInputName = (DOrtGetEvalModelInputName)Marshal.GetDelegateForFunctionPointer(trainingApi_.TrainingSessionGetEvalModelInputName, typeof(DOrtGetEvalModelInputName));
				OrtAddProperty = (DOrtAddProperty)Marshal.GetDelegateForFunctionPointer(trainingApi_.AddProperty, typeof(DOrtAddProperty));
				OrtGetProperty = (DOrtGetProperty)Marshal.GetDelegateForFunctionPointer(trainingApi_.GetProperty, typeof(DOrtGetProperty));
				OrtGetParameterTypeAndShape = (DOrtGetParameterTypeAndShape)Marshal.GetDelegateForFunctionPointer(trainingApi_.GetParameterTypeAndShape, typeof(DOrtGetParameterTypeAndShape));
				OrtUpdateParameter = (DOrtUpdateParameter)Marshal.GetDelegateForFunctionPointer(trainingApi_.UpdateParameter, typeof(DOrtUpdateParameter));
				OrtGetParameter = (DOrtGetParameter)Marshal.GetDelegateForFunctionPointer(trainingApi_.GetParameter, typeof(DOrtGetParameter));
			}
		}

		public static bool TrainingEnabled()
		{
			if (trainingApiPtr == IntPtr.Zero)
			{
				return false;
			}
			return true;
		}
	}
	public class TrainingUtils
	{
		public static void SetSeed(long seed)
		{
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtSetSeed(seed));
		}
	}
	internal enum LRScheduler
	{
		None,
		Constant,
		Linear
	}
	public class TrainingSession : IDisposable
	{
		private nint _nativeHandle;

		private ulong _trainOutputCount;

		private ulong _evalOutputCount;

		private List<string> _trainOutputNames;

		private List<string> _evalOutputNames;

		private List<string> _trainInputNames;

		private List<string> _evalInputNames;

		private SessionOptions _builtInSessionOptions;

		private RunOptions _builtInRunOptions;

		private LRScheduler _scheduler;

		private bool _disposed;

		internal nint Handle => _nativeHandle;

		public TrainingSession(CheckpointState state, string trainModelPath, string evalModelPath, string optimizerModelPath)
		{
			Init(null, state, NativeOnnxValueHelper.GetPlatformSerializedString(trainModelPath), NativeOnnxValueHelper.GetPlatformSerializedString(evalModelPath), NativeOnnxValueHelper.GetPlatformSerializedString(optimizerModelPath));
		}

		public TrainingSession(CheckpointState state, string trainModelPath, string optimizerModelPath)
		{
			Init(null, state, NativeOnnxValueHelper.GetPlatformSerializedString(trainModelPath), null, NativeOnnxValueHelper.GetPlatformSerializedString(optimizerModelPath));
		}

		public TrainingSession(SessionOptions options, CheckpointState state, string trainModelPath, string evalModelPath, string optimizerModelPath)
		{
			Init(options, state, NativeOnnxValueHelper.GetPlatformSerializedString(trainModelPath), NativeOnnxValueHelper.GetPlatformSerializedString(evalModelPath), NativeOnnxValueHelper.GetPlatformSerializedString(optimizerModelPath));
		}

		public void TrainStep(IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<FixedBufferOnnxValue> outputValues)
		{
			TrainStep(_builtInRunOptions, inputValues, outputValues);
		}

		public void TrainStep(RunOptions options, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<FixedBufferOnnxValue> outputValues)
		{
			if (_trainOutputCount != (ulong)Enumerable.Count(outputValues))
			{
				throw new ArgumentException($"Length of {"outputValues"} ({outputValues.Count}) must match that of train model ({_trainOutputCount}).");
			}
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues, input: true);
			nint[] ortValuesHandles2 = GetOrtValuesHandles(outputValues, input: false);
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtTrainStep(_nativeHandle, options.Handle, (nuint)inputValues.Count, ortValuesHandles, (nuint)outputValues.Count, ortValuesHandles2));
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> TrainStep(IReadOnlyCollection<FixedBufferOnnxValue> inputValues)
		{
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues, input: true);
			nint[] array = new nint[(uint)_trainOutputCount];
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtTrainStep(_nativeHandle, _builtInRunOptions.Handle, (nuint)inputValues.Count, ortValuesHandles, (nuint)_trainOutputCount, array));
			DisposableArray<OrtValue> disposableArray = ConvertNativeHandlesToOrtValues(array);
			try
			{
				DisposableList<DisposableNamedOnnxValue> disposableList = new DisposableList<DisposableNamedOnnxValue>(_trainOutputNames.Count);
				try
				{
					for (int i = 0; i < disposableArray.Span.Length; i++)
					{
						disposableList.Add(DisposableNamedOnnxValue.CreateFromOrtValue(_trainOutputNames[i], ref disposableArray.Span[i]));
					}
				}
				catch (OnnxRuntimeException)
				{
					disposableList.Dispose();
					throw;
				}
				return disposableList;
			}
			finally
			{
				disposableArray.Dispose();
			}
		}

		public IDisposableReadOnlyCollection<DisposableNamedOnnxValue> TrainStep(RunOptions options, IReadOnlyCollection<FixedBufferOnnxValue> inputValues)
		{
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues, input: true);
			nint[] array = new nint[(uint)_trainOutputCount];
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtTrainStep(_nativeHandle, options.Handle, (nuint)inputValues.Count, ortValuesHandles, (nuint)_trainOutputCount, array));
			DisposableArray<OrtValue> disposableArray = ConvertNativeHandlesToOrtValues(array);
			try
			{
				DisposableList<DisposableNamedOnnxValue> disposableList = new DisposableList<DisposableNamedOnnxValue>(_trainOutputNames.Count);
				try
				{
					for (int i = 0; i < disposableArray.Span.Length; i++)
					{
						disposableList.Add(DisposableNamedOnnxValue.CreateFromOrtValue(_trainOutputNames[i], ref disposableArray.Span[i]));
					}
				}
				catch (OnnxRuntimeException)
				{
					disposableList.Dispose();
					throw;
				}
				return disposableList;
			}
			finally
			{
				disposableArray.Dispose();
			}
		}

		public IDisposableReadOnlyCollection<OrtValue> TrainStep(IReadOnlyCollection<OrtValue> inputValues)
		{
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues);
			nint[] array = new nint[(uint)_trainOutputCount];
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtTrainStep(_nativeHandle, IntPtr.Zero, (nuint)inputValues.Count, ortValuesHandles, (nuint)_trainOutputCount, array));
			using DisposableOrtValueHandleArray disposableHandles = new DisposableOrtValueHandleArray(array);
			return CreateDisposableResult(disposableHandles);
		}

		private DisposableArray<OrtValue> ConvertNativeHandlesToOrtValues(nint[] nativeHandles)
		{
			DisposableOrtValueHandleArray disposableOrtValueHandleArray = new DisposableOrtValueHandleArray(nativeHandles);
			try
			{
				OrtValue[] array = new OrtValue[nativeHandles.Length];
				DisposableArray<OrtValue> result = new DisposableArray<OrtValue>(array);
				try
				{
					for (int i = 0; i < nativeHandles.Length; i++)
					{
						array[i] = new OrtValue(nativeHandles[i]);
						nativeHandles[i] = IntPtr.Zero;
					}
					return result;
				}
				catch (Exception)
				{
					result.Dispose();
					throw;
				}
			}
			catch (Exception)
			{
				disposableOrtValueHandleArray.Dispose();
				throw;
			}
		}

		public void LazyResetGrad()
		{
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtLazyResetGrad(_nativeHandle));
		}

		public void EvalStep(IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<FixedBufferOnnxValue> outputValues)
		{
			EvalStep(_builtInRunOptions, inputValues, outputValues);
		}

		public void EvalStep(RunOptions options, IReadOnlyCollection<FixedBufferOnnxValue> inputValues, IReadOnlyCollection<FixedBufferOnnxValue> outputValues)
		{
			if (_evalOutputCount != (ulong)Enumerable.Count(outputValues))
			{
				throw new ArgumentException($"Length of {"outputValues"} ({outputValues.Count}) must match that of eval model ({_evalOutputCount}).");
			}
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues, input: true);
			nint[] ortValuesHandles2 = GetOrtValuesHandles(outputValues, input: false);
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtEvalStep(_nativeHandle, options.Handle, (nuint)inputValues.Count, ortValuesHandles, (nuint)outputValues.Count, ortValuesHandles2));
		}

		public IDisposableReadOnlyCollection<OrtValue> EvalStep(IReadOnlyCollection<OrtValue> inputValues)
		{
			nint[] ortValuesHandles = GetOrtValuesHandles(inputValues);
			nint[] array = new nint[(uint)_evalOutputCount];
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtEvalStep(_nativeHandle, IntPtr.Zero, (nuint)inputValues.Count, ortValuesHandles, (nuint)_evalOutputCount, array));
			using DisposableOrtValueHandleArray disposableHandles = new DisposableOrtValueHandleArray(array);
			return CreateDisposableResult(disposableHandles);
		}

		public void SetLearningRate(float learningRate)
		{
			if (_scheduler != LRScheduler.None && _scheduler != LRScheduler.Constant)
			{
				throw new InvalidOperationException("Cannot set constant LR while using LR scheduler.");
			}
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtSetLearningRate(_nativeHandle, learningRate));
			_scheduler = LRScheduler.Constant;
		}

		public float GetLearningRate()
		{
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetLearningRate(_nativeHandle, out var learningRate));
			return learningRate;
		}

		public void RegisterLinearLRScheduler(long warmupStepCount, long totalStepCount, float initialLearningRate)
		{
			if (_scheduler != LRScheduler.None && _scheduler != LRScheduler.Constant)
			{
				throw new InvalidOperationException("Cannot set LR scheduler while using constant LR.");
			}
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtRegisterLinearLRScheduler(_nativeHandle, warmupStepCount, totalStepCount, initialLearningRate));
			_scheduler = LRScheduler.Linear;
		}

		public void SchedulerStep()
		{
			if (_scheduler == LRScheduler.Constant || _scheduler == LRScheduler.None)
			{
				throw new InvalidOperationException("Cannot take scheduler step without registering a valid LR scheduler.");
			}
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtSchedulerStep(_nativeHandle));
		}

		public void OptimizerStep()
		{
			OptimizerStep(_builtInRunOptions);
		}

		public void OptimizerStep(RunOptions options)
		{
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtOptimizerStep(_nativeHandle, options.Handle));
		}

		public void ExportModelForInferencing(string inferenceModelPath, IReadOnlyCollection<string> graphOutputNames)
		{
			using DisposableList<IDisposable> cleanupList = new DisposableList<IDisposable>();
			nint[] graphOutputNames2 = ConvertNamesToUtf8(graphOutputNames, cleanupList);
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtExportModelForInferencing(_nativeHandle, NativeOnnxValueHelper.GetPlatformSerializedString(inferenceModelPath), (nuint)graphOutputNames.Count, graphOutputNames2));
		}

		public OrtValue ToBuffer(bool onlyTrainable)
		{
			nuint buffer_size = UIntPtr.Zero;
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetParametersSize(_nativeHandle, out buffer_size, onlyTrainable));
			_ = new float[((UIntPtr)buffer_size).ToUInt64()];
			long[] shape = new long[1] { (long)buffer_size };
			OrtValue ortValue = OrtValue.CreateAllocatedTensorValue(OrtAllocator.DefaultInstance, TensorElementType.Float, shape);
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtCopyParametersToBuffer(_nativeHandle, ortValue.Handle, onlyTrainable));
			return ortValue;
		}

		public void FromBuffer(OrtValue ortValue, bool onlyTrainable)
		{
			if (ortValue.OnnxType != OnnxValueType.ONNX_TYPE_TENSOR)
			{
				throw new ArgumentException("Incorrect buffer received. Expected a tensor buffer.");
			}
			OrtTensorTypeAndShapeInfo tensorTypeAndShape = ortValue.GetTensorTypeAndShape();
			if (tensorTypeAndShape.ElementDataType != TensorElementType.Float)
			{
				throw new ArgumentException("Incorrect buffer received. Expected a tensor buffer of type float.");
			}
			nuint buffer_size = UIntPtr.Zero;
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetParametersSize(_nativeHandle, out buffer_size, onlyTrainable));
			if (tensorTypeAndShape.ElementCount != (long)buffer_size)
			{
				throw new ArgumentException("Incorrect buffer size received. Expected size to be " + (UIntPtr)buffer_size + ". Actual size: " + tensorTypeAndShape.ElementCount);
			}
			NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtCopyBufferToParameters(_nativeHandle, ortValue.Handle, onlyTrainable));
		}

		public List<string> OutputNames(bool training)
		{
			if (!training)
			{
				return _evalOutputNames;
			}
			return _trainOutputNames;
		}

		public List<string> InputNames(bool training)
		{
			if (!training)
			{
				return _evalInputNames;
			}
			return _trainInputNames;
		}

		private void Init(SessionOptions sessOptions, CheckpointState state, byte[] trainModelPath, byte[] evalModelPath, byte[] optimizerModelPath)
		{
			if (!NativeTrainingMethods.TrainingEnabled())
			{
				throw new InvalidOperationException("This package does not contain the training API. Please install the Microsoft.ML.OnnxRuntime.Training NuGet package.\n");
			}
			SessionOptions sessionOptions = sessOptions;
			if (sessOptions == null)
			{
				_builtInSessionOptions = new SessionOptions();
				sessionOptions = _builtInSessionOptions;
			}
			nint handle = OrtEnv.Instance().Handle;
			try
			{
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtCreateTrainingSession(handle, sessionOptions.Handle, state.Handle, trainModelPath, evalModelPath, optimizerModelPath, out _nativeHandle));
				nuint count = UIntPtr.Zero;
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetTrainingModelOutputCount(_nativeHandle, out count));
				_trainOutputCount = ((UIntPtr)count).ToUInt64();
				_trainOutputNames = new List<string>();
				for (ulong num = 0uL; num < _trainOutputCount; num++)
				{
					_trainOutputNames.Add(GetOutputName(num, training: true));
				}
				_trainInputNames = new List<string>();
				nuint inputCount = UIntPtr.Zero;
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetTrainingModelInputCount(_nativeHandle, out inputCount));
				for (ulong num2 = 0uL; num2 < ((UIntPtr)inputCount).ToUInt64(); num2++)
				{
					_trainInputNames.Add(GetInputName(num2, training: true));
				}
				if (evalModelPath != null)
				{
					count = UIntPtr.Zero;
					NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetEvalModelOutputCount(_nativeHandle, out count));
					_evalOutputCount = ((UIntPtr)count).ToUInt64();
					_evalOutputNames = new List<string>();
					for (ulong num3 = 0uL; num3 < _evalOutputCount; num3++)
					{
						_evalOutputNames.Add(GetOutputName(num3, training: false));
					}
					_evalInputNames = new List<string>();
					inputCount = UIntPtr.Zero;
					NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetEvalModelInputCount(_nativeHandle, out inputCount));
					for (ulong num4 = 0uL; num4 < ((UIntPtr)inputCount).ToUInt64(); num4++)
					{
						_evalInputNames.Add(GetInputName(num4, training: false));
					}
				}
				_builtInRunOptions = new RunOptions();
			}
			catch (Exception)
			{
				CleanupHelper(disposing: true);
				throw;
			}
		}

		private string GetOutputName(ulong index, bool training)
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			nint name;
			if (training)
			{
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetTrainingModelOutputName(_nativeHandle, (nuint)index, defaultInstance.Pointer, out name));
			}
			else
			{
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetEvalModelOutputName(_nativeHandle, (nuint)index, defaultInstance.Pointer, out name));
			}
			return NativeOnnxValueHelper.StringFromNativeUtf8(name, defaultInstance);
		}

		private string GetInputName(ulong index, bool training)
		{
			OrtAllocator defaultInstance = OrtAllocator.DefaultInstance;
			nint name;
			if (training)
			{
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetTrainingModelInputName(_nativeHandle, (nuint)index, defaultInstance.Pointer, out name));
			}
			else
			{
				NativeApiStatus.VerifySuccess(NativeTrainingMethods.OrtGetEvalModelInputName(_nativeHandle, (nuint)index, defaultInstance.Pointer, out name));
			}
			return NativeOnnxValueHelper.StringFromNativeUtf8(name, defaultInstance);
		}

		private nint[] GetOrtValuesHandles(IReadOnlyCollection<FixedBufferOnnxValue> values, bool input)
		{
			nint[] array = new nint[values.Count];
			for (int i = 0; i < values.Count; i++)
			{
				FixedBufferOnnxValue fixedBufferOnnxValue = values.ElementAt(i);
				if (!input && fixedBufferOnnxValue.ElementType == TensorElementType.String)
				{
					throw new NotSupportedException("Using string type FixedBufferOnnxValue in outputs is not supported.");
				}
				array[i] = fixedBufferOnnxValue.Value.Handle;
			}
			return array;
		}

		private nint[] GetOrtValuesHandles(IReadOnlyCollection<OrtValue> inputValues)
		{
			nint[] array = new nint[inputValues.Count];
			for (int i = 0; i < inputValues.Count; i++)
			{
				array[i] = inputValues.ElementAt(i).Handle;
			}
			return array;
		}

		private static IDisposableReadOnlyCollection<OrtValue> CreateDisposableResult(DisposableOrtValueHandleArray disposableHandles)
		{
			DisposableList<OrtValue> disposableList = new DisposableList<OrtValue>(disposableHandles.Span.Length);
			try
			{
				for (int i = 0; i < disposableHandles.Span.Length; i++)
				{
					disposableList.Add(new OrtValue(disposableHandles.Span[i]));
					disposableHandles.Span[i] = IntPtr.Zero;
				}
				return disposableList;
			}
			catch (Exception)
			{
				disposableList.Dispose();
				throw;
			}
		}

		private unsafe nint[] ConvertNamesToUtf8(IReadOnlyCollection<string> names, DisposableList<IDisposable> cleanupList)
		{
			cleanupList.Capacity += names.Count;
			nint[] array = new nint[names.Count];
			for (int i = 0; i < names.Count; i++)
			{
				MemoryHandle memoryHandle = new Memory<byte>(NativeOnnxValueHelper.StringToZeroTerminatedUtf8(names.ElementAt(i))).Pin();
				array[i] = (nint)memoryHandle.Pointer;
				cleanupList.Add(memoryHandle);
			}
			return array;
		}

		~TrainingSession()
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
				CleanupHelper(disposing);
				_disposed = true;
			}
		}

		private void CleanupHelper(bool disposing)
		{
			if (disposing)
			{
				if (_builtInRunOptions != null)
				{
					_builtInRunOptions.Dispose();
					_builtInRunOptions = null;
				}
				if (_builtInSessionOptions != null)
				{
					_builtInSessionOptions.Dispose();
					_builtInSessionOptions = null;
				}
			}
			if (_nativeHandle != IntPtr.Zero)
			{
				NativeTrainingMethods.OrtReleaseTrainingSession(_nativeHandle);
				_nativeHandle = IntPtr.Zero;
			}
		}
	}
}
namespace Microsoft.ML.OnnxRuntime.Tensors
{
	public static class ShapeUtils
	{
		public static long GetSizeForShape(ReadOnlySpan<long> shape)
		{
			long num = 1L;
			ReadOnlySpan<long> readOnlySpan = shape;
			for (int i = 0; i < readOnlySpan.Length; i++)
			{
				long num2 = readOnlySpan[i];
				if (num2 < 0)
				{
					throw new ArgumentOutOfRangeException($"Shape must not have negative elements: {num2}");
				}
				num = checked(num * num2);
			}
			return num;
		}

		public static long[] GetStrides(ReadOnlySpan<long> dimensions)
		{
			long[] array = new long[dimensions.Length];
			if (dimensions.Length == 0)
			{
				return array;
			}
			long num = 1L;
			for (int num2 = array.Length - 1; num2 >= 0; num2--)
			{
				array[num2] = num;
				if (dimensions[num2] < 0)
				{
					throw new ArgumentException($"Dimension {num2} is negative");
				}
				num *= dimensions[num2];
			}
			return array;
		}

		public static long GetIndex(ReadOnlySpan<long> strides, ReadOnlySpan<long> indices, int startFromDimension = 0)
		{
			long num = 0L;
			for (int i = startFromDimension; i < indices.Length; i++)
			{
				num += strides[i] * indices[i];
			}
			return num;
		}
	}
	public static class ArrayTensorExtensions
	{
		public static DenseTensor<T> ToTensor<T>(this T[] array)
		{
			int[] array2 = new int[1] { array.Length };
			T[] array3 = new T[array.Length];
			array.CopyTo(array3, 0);
			return new DenseTensor<T>(new Memory<T>(array3), array2);
		}

		public static DenseTensor<T> ToTensor<T>(this T[,] array, bool reverseStride = false)
		{
			if (reverseStride)
			{
				return new DenseTensor<T>(array, reverseStride);
			}
			T[] array2 = new T[array.Length];
			int[] array3 = new int[2]
			{
				array.GetLength(0),
				array.GetLength(1)
			};
			long num = 0L;
			foreach (T val in array)
			{
				array2[num++] = val;
			}
			return new DenseTensor<T>(new Memory<T>(array2), array3);
		}

		public static DenseTensor<T> ToTensor<T>(this T[,,] array, bool reverseStride = false)
		{
			if (reverseStride)
			{
				return new DenseTensor<T>(array, reverseStride);
			}
			T[] array2 = new T[array.Length];
			int[] array3 = new int[3]
			{
				array.GetLength(0),
				array.GetLength(1),
				array.GetLength(2)
			};
			long num = 0L;
			foreach (T val in array)
			{
				array2[num++] = val;
			}
			return new DenseTensor<T>(new Memory<T>(array2), array3);
		}

		public static DenseTensor<T> ToTensor<T>(this T[,,,] array, bool reverseStride = false)
		{
			if (reverseStride)
			{
				return new DenseTensor<T>(array, reverseStride);
			}
			T[] array2 = new T[array.Length];
			int[] array3 = new int[4]
			{
				array.GetLength(0),
				array.GetLength(1),
				array.GetLength(2),
				array.GetLength(3)
			};
			long num = 0L;
			foreach (T val in array)
			{
				array2[num++] = val;
			}
			return new DenseTensor<T>(new Memory<T>(array2), array3);
		}

		public static DenseTensor<T> ToTensor<T>(this Array array, bool reverseStride = false)
		{
			return new DenseTensor<T>(array, reverseStride);
		}
	}
	internal static class ArrayUtilities
	{
		private static class EmptyArray<T>
		{
			public static readonly T[] Value = new T[0];
		}

		public const int StackallocMax = 16;

		public static long GetProduct(ReadOnlySpan<int> dimensions, int startIndex = 0)
		{
			long num = 1L;
			for (int i = startIndex; i < dimensions.Length; i++)
			{
				if (dimensions[i] < 0)
				{
					throw new ArgumentOutOfRangeException($"{"dimensions"}[{i}]");
				}
				num = checked(num * dimensions[i]);
			}
			return num;
		}

		public static bool IsAscending(ReadOnlySpan<int> values)
		{
			for (int i = 1; i < values.Length; i++)
			{
				if (values[i] < values[i - 1])
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsDescending(ReadOnlySpan<int> values)
		{
			for (int i = 1; i < values.Length; i++)
			{
				if (values[i] > values[i - 1])
				{
					return false;
				}
			}
			return true;
		}

		public static int[] GetStrides(ReadOnlySpan<int> dimensions, bool reverseStride = false)
		{
			int[] array = new int[dimensions.Length];
			if (dimensions.Length == 0)
			{
				return array;
			}
			int num = 1;
			if (reverseStride)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = num;
					num *= dimensions[i];
				}
			}
			else
			{
				for (int num2 = array.Length - 1; num2 >= 0; num2--)
				{
					array[num2] = num;
					num *= dimensions[num2];
				}
			}
			return array;
		}

		public static void SplitStrides(int[] strides, int[] splitAxes, int[] newStrides, int stridesOffset, int[] splitStrides, int splitStridesOffset)
		{
			int num = 0;
			for (int i = 0; i < strides.Length; i++)
			{
				int num2 = strides[i];
				bool flag = false;
				for (int j = 0; j < splitAxes.Length; j++)
				{
					if (splitAxes[j] == i)
					{
						splitStrides[splitStridesOffset + j] = num2;
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					newStrides[stridesOffset + num++] = num2;
				}
			}
		}

		public static int GetIndex(int[] strides, ReadOnlySpan<int> indices, int startFromDimension = 0)
		{
			int num = 0;
			for (int i = startFromDimension; i < indices.Length; i++)
			{
				num += strides[i] * indices[i];
			}
			return num;
		}

		public static void GetIndices(ReadOnlySpan<int> strides, bool reverseStride, int index, int[] indices, int startFromDimension = 0)
		{
			if (indices.Length != 0)
			{
				int num = index;
				for (int i = startFromDimension; i < strides.Length; i++)
				{
					int num2 = (reverseStride ? (strides.Length - 1 - i) : i);
					int num3 = strides[num2];
					indices[num2] = num / num3;
					num %= num3;
				}
			}
		}

		public static void GetIndices(ReadOnlySpan<int> strides, bool reverseStride, int index, Span<int> indices, int startFromDimension = 0)
		{
			if (indices.Length != 0)
			{
				int num = index;
				for (int i = startFromDimension; i < strides.Length; i++)
				{
					int index2 = (reverseStride ? (strides.Length - 1 - i) : i);
					int num2 = strides[index2];
					indices[index2] = num / num2;
					num %= num2;
				}
			}
		}

		public static int TransformIndexByStrides(int index, int[] sourceStrides, bool sourceReverseStride, int[] transformStrides)
		{
			if (sourceStrides.Length == 0)
			{
				return 0;
			}
			int num = 0;
			int num2 = index;
			for (int i = 0; i < sourceStrides.Length; i++)
			{
				int num3 = (sourceReverseStride ? (sourceStrides.Length - 1 - i) : i);
				int num4 = sourceStrides[num3];
				int num5 = transformStrides[num3];
				num += num5 * (num2 / num4);
				num2 %= num4;
			}
			return num;
		}

		public static T[] GetEmpty<T>()
		{
			return EmptyArray<T>.Value;
		}
	}
	public class DenseTensor<T> : Tensor<T>
	{
		private readonly Memory<T> memory;

		public Memory<T> Buffer => memory;

		internal DenseTensor(Array fromArray, bool reverseStride = false)
			: base(fromArray, reverseStride)
		{
			T[] array = new T[fromArray.Length];
			int num = 0;
			if (reverseStride)
			{
				int[] sourceStrides = ArrayUtilities.GetStrides(dimensions);
				foreach (object item in fromArray)
				{
					int num2 = ArrayUtilities.TransformIndexByStrides(num++, sourceStrides, sourceReverseStride: false, strides);
					array[num2] = (T)item;
				}
			}
			else
			{
				foreach (object item2 in fromArray)
				{
					array[num++] = (T)item2;
				}
			}
			memory = array;
		}

		public DenseTensor(int length)
			: base(length)
		{
			memory = new T[length];
		}

		public DenseTensor(ReadOnlySpan<int> dimensions, bool reverseStride = false)
			: base(dimensions, reverseStride)
		{
			memory = new T[Length];
		}

		public DenseTensor(Memory<T> memory, ReadOnlySpan<int> dimensions, bool reverseStride = false)
			: base(dimensions, reverseStride)
		{
			this.memory = memory;
			if (Length != memory.Length)
			{
				throw new ArgumentException($"Length of {"memory"} ({memory.Length}) must match product of {"dimensions"} ({Length}).");
			}
		}

		public override T GetValue(int index)
		{
			return Buffer.Span[index];
		}

		public override void SetValue(int index, T value)
		{
			Buffer.Span[index] = value;
		}

		protected override void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Length < arrayIndex + Length)
			{
				throw new ArgumentException("The number of elements in the Tensor is greater than the available space from index to the end of the destination array.", "array");
			}
			Buffer.Span.CopyTo(array.AsSpan(arrayIndex));
		}

		protected override int IndexOf(T item)
		{
			if (MemoryMarshal.TryGetArray((ReadOnlyMemory<T>)Buffer, out ArraySegment<T> segment))
			{
				int num = Array.IndexOf(segment.Array, item, segment.Offset, segment.Count);
				if (num != -1)
				{
					num -= segment.Offset;
				}
				return num;
			}
			return base.IndexOf(item);
		}

		public override Tensor<T> Clone()
		{
			return new DenseTensor<T>(new Memory<T>(memory.ToArray()), dimensions, IsReversedStride);
		}

		public override Tensor<TResult> CloneEmpty<TResult>(ReadOnlySpan<int> dimensions)
		{
			return new DenseTensor<TResult>(dimensions, IsReversedStride);
		}

		public override Tensor<T> Reshape(ReadOnlySpan<int> dimensions)
		{
			if (ArrayUtilities.GetProduct(dimensions) != Length)
			{
				throw new ArgumentException("Cannot reshape array due to mismatch in lengths, currently {Length} would become {newSize}.", "dimensions");
			}
			return new DenseTensor<T>(Buffer, dimensions, IsReversedStride);
		}
	}
	public enum TensorElementType
	{
		Float = 1,
		UInt8,
		Int8,
		UInt16,
		Int16,
		Int32,
		Int64,
		String,
		Bool,
		Float16,
		Double,
		UInt32,
		UInt64,
		Complex64,
		Complex128,
		BFloat16,
		DataTypeMax
	}
	public class TensorTypeInfo
	{
		public TensorElementType ElementType { get; private set; }

		public int TypeSize { get; private set; }

		public bool IsString => ElementType == TensorElementType.String;

		public TensorTypeInfo(TensorElementType elementType, int typeSize)
		{
			ElementType = elementType;
			TypeSize = typeSize;
		}
	}
	public class TensorElementTypeInfo
	{
		public Type TensorType { get; private set; }

		public int TypeSize { get; private set; }

		public bool IsString { get; private set; }

		public TensorElementTypeInfo(Type type, int typeSize)
		{
			TensorType = type;
			TypeSize = typeSize;
			IsString = type == typeof(string);
		}
	}
	public class TensorBase
	{
		private static readonly Dictionary<Type, TensorTypeInfo> typeInfoMap;

		private static readonly Dictionary<TensorElementType, TensorElementTypeInfo> tensorElementTypeInfoMap;

		private readonly Type _primitiveType;

		static TensorBase()
		{
			typeInfoMap = new Dictionary<Type, TensorTypeInfo>
			{
				{
					typeof(float),
					new TensorTypeInfo(TensorElementType.Float, 4)
				},
				{
					typeof(byte),
					new TensorTypeInfo(TensorElementType.UInt8, 1)
				},
				{
					typeof(sbyte),
					new TensorTypeInfo(TensorElementType.Int8, 1)
				},
				{
					typeof(ushort),
					new TensorTypeInfo(TensorElementType.UInt16, 2)
				},
				{
					typeof(short),
					new TensorTypeInfo(TensorElementType.Int16, 2)
				},
				{
					typeof(int),
					new TensorTypeInfo(TensorElementType.Int32, 4)
				},
				{
					typeof(long),
					new TensorTypeInfo(TensorElementType.Int64, 8)
				},
				{
					typeof(string),
					new TensorTypeInfo(TensorElementType.String, -1)
				},
				{
					typeof(bool),
					new TensorTypeInfo(TensorElementType.Bool, 1)
				},
				{
					typeof(Float16),
					new TensorTypeInfo(TensorElementType.Float16, 2)
				},
				{
					typeof(double),
					new TensorTypeInfo(TensorElementType.Double, 8)
				},
				{
					typeof(uint),
					new TensorTypeInfo(TensorElementType.UInt32, 4)
				},
				{
					typeof(ulong),
					new TensorTypeInfo(TensorElementType.UInt64, 8)
				},
				{
					typeof(BFloat16),
					new TensorTypeInfo(TensorElementType.BFloat16, 2)
				}
			};
			tensorElementTypeInfoMap = new Dictionary<TensorElementType, TensorElementTypeInfo>();
			foreach (KeyValuePair<Type, TensorTypeInfo> item in typeInfoMap)
			{
				tensorElementTypeInfoMap.Add(item.Value.ElementType, new TensorElementTypeInfo(item.Key, item.Value.TypeSize));
			}
		}

		protected TensorBase(Type primitiveType)
		{
			_primitiveType = primitiveType;
		}

		public static TensorTypeInfo GetTypeInfo(Type type)
		{
			TensorTypeInfo value = null;
			typeInfoMap.TryGetValue(type, out value);
			return value;
		}

		public static TensorElementTypeInfo GetElementTypeInfo(TensorElementType elementType)
		{
			TensorElementTypeInfo value = null;
			tensorElementTypeInfoMap.TryGetValue(elementType, out value);
			return value;
		}

		public TensorTypeInfo GetTypeInfo()
		{
			return GetTypeInfo(_primitiveType);
		}
	}
	public static class Tensor
	{
		public static Tensor<T> CreateIdentity<T>(int size)
		{
			return CreateIdentity(size, columMajor: false, Tensor<T>.One);
		}

		public static Tensor<T> CreateIdentity<T>(int size, bool columMajor)
		{
			return CreateIdentity(size, columMajor, Tensor<T>.One);
		}

		public static Tensor<T> CreateIdentity<T>(int size, bool columMajor, T oneValue)
		{
			Span<int> span = stackalloc int[2];
			span[0] = (span[1] = size);
			DenseTensor<T> denseTensor = new DenseTensor<T>(span, columMajor);
			for (int i = 0; i < size; i++)
			{
				denseTensor.SetValue(i * size + i, oneValue);
			}
			return denseTensor;
		}

		public static Tensor<T> CreateFromDiagonal<T>(Tensor<T> diagonal)
		{
			return CreateFromDiagonal(diagonal, 0);
		}

		public static Tensor<T> CreateFromDiagonal<T>(Tensor<T> diagonal, int offset)
		{
			if (diagonal.Rank < 1)
			{
				throw new ArgumentException("Tensor diagonal must have at least one dimension.", "diagonal");
			}
			int num = diagonal.dimensions[0];
			int num2 = diagonal.dimensions.Length + 1;
			Span<int> span = ((num2 >= 16) ? ((Span<int>)new int[num2]) : stackalloc int[num2]);
			Span<int> span2 = span;
			int num3 = num + Math.Abs(offset);
			span2[0] = (span2[1] = num3);
			for (int i = 1; i < diagonal.dimensions.Length; i++)
			{
				span2[i + 1] = diagonal.dimensions[i];
			}
			Tensor<T> tensor = diagonal.CloneEmpty(span2);
			long num4 = diagonal.Length / num;
			int num5 = ((!diagonal.IsReversedStride || diagonal.Rank <= 1) ? 1 : diagonal.strides[1]);
			int num6 = ((!tensor.IsReversedStride || tensor.Rank <= 2) ? 1 : tensor.strides[2]);
			for (int j = 0; j < num; j++)
			{
				int num7 = ((offset < 0) ? (j - offset) : j);
				int num8 = ((offset > 0) ? (j + offset) : j);
				int num9 = num7 * tensor.strides[0] + num8 * tensor.strides[1];
				int num10 = j * diagonal.strides[0];
				for (int k = 0; k < num4; k++)
				{
					tensor.SetValue(num9 + k * num6, diagonal.GetValue(num10 + k * num5));
				}
			}
			return tensor;
		}
	}
	[DebuggerDisplay("{GetArrayString(false)}")]
	public abstract class Tensor<T> : TensorBase, IList, ICollection, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>, IReadOnlyList<T>, IReadOnlyCollection<T>, IStructuralComparable, IStructuralEquatable
	{
		internal readonly int[] dimensions;

		internal readonly int[] strides;

		private readonly bool isReversedStride;

		private readonly long length;

		internal static T Zero
		{
			get
			{
				if (typeof(T) == typeof(bool))
				{
					return (T)(object)false;
				}
				if (typeof(T) == typeof(byte))
				{
					return (T)(object)(byte)0;
				}
				if (typeof(T) == typeof(char))
				{
					return (T)(object)'\0';
				}
				if (typeof(T) == typeof(decimal))
				{
					return (T)(object)0m;
				}
				if (typeof(T) == typeof(double))
				{
					return (T)(object)0.0;
				}
				if (typeof(T) == typeof(float))
				{
					return (T)(object)0f;
				}
				if (typeof(T) == typeof(int))
				{
					return (T)(object)0;
				}
				if (typeof(T) == typeof(long))
				{
					return (T)(object)0L;
				}
				if (typeof(T) == typeof(sbyte))
				{
					return (T)(object)(sbyte)0;
				}
				if (typeof(T) == typeof(short))
				{
					return (T)(object)(short)0;
				}
				if (typeof(T) == typeof(uint))
				{
					return (T)(object)0u;
				}
				if (typeof(T) == typeof(ulong))
				{
					return (T)(object)0uL;
				}
				if (typeof(T) == typeof(ushort))
				{
					return (T)(object)(ushort)0;
				}
				if (typeof(T) == typeof(Float16))
				{
					return (T)(object)(ushort)0;
				}
				if (typeof(T) == typeof(BFloat16))
				{
					return (T)(object)(ushort)0;
				}
				if (typeof(T) == typeof(string))
				{
					return (T)(object)"0";
				}
				throw new NotSupportedException();
			}
		}

		internal static T One
		{
			get
			{
				if (typeof(T) == typeof(bool))
				{
					return (T)(object)true;
				}
				if (typeof(T) == typeof(byte))
				{
					return (T)(object)(byte)1;
				}
				if (typeof(T) == typeof(char))
				{
					return (T)(object)'\u0001';
				}
				if (typeof(T) == typeof(decimal))
				{
					return (T)(object)1m;
				}
				if (typeof(T) == typeof(double))
				{
					return (T)(object)1.0;
				}
				if (typeof(T) == typeof(float))
				{
					return (T)(object)1f;
				}
				if (typeof(T) == typeof(int))
				{
					return (T)(object)1;
				}
				if (typeof(T) == typeof(long))
				{
					return (T)(object)1L;
				}
				if (typeof(T) == typeof(sbyte))
				{
					return (T)(object)(sbyte)1;
				}
				if (typeof(T) == typeof(short))
				{
					return (T)(object)(short)1;
				}
				if (typeof(T) == typeof(uint))
				{
					return (T)(object)1u;
				}
				if (typeof(T) == typeof(ulong))
				{
					return (T)(object)1uL;
				}
				if (typeof(T) == typeof(ushort))
				{
					return (T)(object)(ushort)1;
				}
				if (typeof(T) == typeof(Float16))
				{
					return (T)(object)(ushort)15360;
				}
				if (typeof(T) == typeof(BFloat16))
				{
					return (T)(object)(ushort)16256;
				}
				if (typeof(T) == typeof(string))
				{
					return (T)(object)"1";
				}
				throw new NotSupportedException();
			}
		}

		public long Length => length;

		public int Rank => dimensions.Length;

		public bool IsReversedStride => isReversedStride;

		public ReadOnlySpan<int> Dimensions => dimensions;

		public ReadOnlySpan<int> Strides => strides;

		public virtual T this[params int[] indices]
		{
			get
			{
				if (indices == null)
				{
					throw new ArgumentNullException("indices");
				}
				ReadOnlySpan<int> indices2 = new ReadOnlySpan<int>(indices);
				return this[indices2];
			}
			set
			{
				if (indices == null)
				{
					throw new ArgumentNullException("indices");
				}
				ReadOnlySpan<int> indices2 = new ReadOnlySpan<int>(indices);
				this[indices2] = value;
			}
		}

		public virtual T this[ReadOnlySpan<int> indices]
		{
			get
			{
				return GetValue(ArrayUtilities.GetIndex(strides, indices));
			}
			set
			{
				SetValue(ArrayUtilities.GetIndex(strides, indices), value);
			}
		}

		int ICollection.Count => (int)Length;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		object IList.this[int index]
		{
			get
			{
				return GetValue(index);
			}
			set
			{
				try
				{
					SetValue(index, (T)value);
				}
				catch (InvalidCastException)
				{
					throw new ArgumentException($"The value \"{value}\" is not of type \"{typeof(T)}\" and cannot be used in this generic collection.");
				}
			}
		}

		public bool IsFixedSize => true;

		public bool IsReadOnly => false;

		int ICollection<T>.Count => (int)Length;

		int IReadOnlyCollection<T>.Count => (int)Length;

		T IList<T>.this[int index]
		{
			get
			{
				return GetValue(index);
			}
			set
			{
				SetValue(index, value);
			}
		}

		T IReadOnlyList<T>.this[int index] => GetValue(index);

		protected Tensor(int length)
			: base(typeof(T))
		{
			dimensions = new int[1] { length };
			strides = new int[1] { 1 };
			isReversedStride = false;
			this.length = length;
		}

		protected Tensor(ReadOnlySpan<int> dimensions, bool reverseStride)
			: base(typeof(T))
		{
			this.dimensions = new int[dimensions.Length];
			long num = 1L;
			for (int i = 0; i < dimensions.Length; i++)
			{
				if (dimensions[i] < 0)
				{
					throw new ArgumentOutOfRangeException("dimensions", "Dimensions must be non-negative");
				}
				this.dimensions[i] = dimensions[i];
				num *= dimensions[i];
			}
			strides = ArrayUtilities.GetStrides(dimensions, reverseStride);
			isReversedStride = reverseStride;
			length = num;
		}

		protected Tensor(Array fromArray, bool reverseStride)
			: base(typeof(T))
		{
			if (fromArray == null)
			{
				throw new ArgumentNullException("fromArray");
			}
			dimensions = new int[fromArray.Rank];
			long num = 1L;
			for (int i = 0; i < dimensions.Length; i++)
			{
				dimensions[i] = fromArray.GetLength(i);
				num *= dimensions[i];
			}
			strides = ArrayUtilities.GetStrides(dimensions, reverseStride);
			isReversedStride = reverseStride;
			length = num;
		}

		public virtual void Fill(T value)
		{
			for (int i = 0; i < Length; i++)
			{
				SetValue(i, value);
			}
		}

		public abstract Tensor<T> Clone();

		public virtual Tensor<T> CloneEmpty()
		{
			return CloneEmpty<T>(dimensions);
		}

		public virtual Tensor<T> CloneEmpty(ReadOnlySpan<int> dimensions)
		{
			return CloneEmpty<T>(dimensions);
		}

		public virtual Tensor<TResult> CloneEmpty<TResult>()
		{
			return CloneEmpty<TResult>(dimensions);
		}

		public abstract Tensor<TResult> CloneEmpty<TResult>(ReadOnlySpan<int> dimensions);

		public Tensor<T> GetDiagonal()
		{
			return GetDiagonal(0);
		}

		public Tensor<T> GetDiagonal(int offset)
		{
			if (Rank < 2)
			{
				throw new InvalidOperationException("Cannot compute diagonal of Tensor with Rank less than 2.");
			}
			int num = dimensions[0];
			int num2 = dimensions[1];
			int val = ((offset < 0) ? (num + offset) : num);
			int val2 = ((offset > 0) ? (num2 - offset) : num2);
			int num3 = Math.Min(val, val2);
			if (num3 <= 0)
			{
				throw new ArgumentException($"Cannot compute diagonal with offset {offset}", "offset");
			}
			int num4 = Rank - 1;
			Span<int> span = ((num4 >= 16) ? ((Span<int>)new int[num4]) : stackalloc int[num4]);
			Span<int> span2 = span;
			span2[0] = num3;
			for (int i = 2; i < dimensions.Length; i++)
			{
				span2[i - 1] = dimensions[i];
			}
			Tensor<T> tensor = CloneEmpty(span2);
			long num5 = tensor.Length / tensor.Dimensions[0];
			int num6 = ((!tensor.IsReversedStride || tensor.Rank <= 1) ? 1 : tensor.strides[1]);
			int num7 = ((!IsReversedStride || Rank <= 2) ? 1 : strides[2]);
			for (int j = 0; j < num3; j++)
			{
				int num8 = ((offset < 0) ? (j - offset) : j);
				int num9 = ((offset > 0) ? (j + offset) : j);
				int num10 = num8 * strides[0] + num9 * strides[1];
				int num11 = j * tensor.strides[0];
				for (int k = 0; k < num5; k++)
				{
					tensor.SetValue(num11 + k * num6, GetValue(num10 + k * num7));
				}
			}
			return tensor;
		}

		public Tensor<T> GetTriangle()
		{
			return GetTriangle(0, upper: false);
		}

		public Tensor<T> GetTriangle(int offset)
		{
			return GetTriangle(offset, upper: false);
		}

		public Tensor<T> GetUpperTriangle()
		{
			return GetTriangle(0, upper: true);
		}

		public Tensor<T> GetUpperTriangle(int offset)
		{
			return GetTriangle(offset, upper: true);
		}

		public Tensor<T> GetTriangle(int offset, bool upper)
		{
			if (Rank < 2)
			{
				throw new InvalidOperationException("Cannot compute triangle of Tensor with Rank less than 2.");
			}
			int num = dimensions[0];
			int num2 = dimensions[1];
			int num3 = Math.Max(num, num2);
			Tensor<T> tensor = CloneEmpty();
			long num4 = Length / (num * num2);
			int num5 = ((!IsReversedStride || Rank <= 2) ? 1 : strides[2]);
			for (int i = 0; i < num3; i++)
			{
				int num6 = ((offset > 0) ? (i - offset) : i);
				int num7 = ((offset > 0) ? i : (i + offset));
				if (num6 < 0)
				{
					if (upper)
					{
						continue;
					}
					num6 = 0;
				}
				if (num7 < 0)
				{
					if (!upper)
					{
						continue;
					}
					num7 = 0;
				}
				while (num7 < num2 && num6 < num)
				{
					int num8 = num6 * strides[0] + num7 * tensor.strides[1];
					for (int j = 0; j < num4; j++)
					{
						int index = num8 + j * num5;
						tensor.SetValue(index, GetValue(index));
					}
					if (upper)
					{
						num7++;
					}
					else
					{
						num6++;
					}
				}
			}
			return tensor;
		}

		public abstract Tensor<T> Reshape(ReadOnlySpan<int> dimensions);

		public abstract T GetValue(int index);

		public abstract void SetValue(int index, T value);

		public static int Compare(Tensor<T> left, Tensor<T> right)
		{
			return StructuralComparisons.StructuralComparer.Compare(left, right);
		}

		public static bool Equals(Tensor<T> left, Tensor<T> right)
		{
			return StructuralComparisons.StructuralEqualityComparer.Equals(left, right);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)this).GetEnumerator();
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array is T[] array2)
			{
				CopyTo(array2, index);
				return;
			}
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Rank != 1)
			{
				throw new ArgumentException("Only single dimensional arrays are supported for the requested action.", "array");
			}
			if (array.Length < index + Length)
			{
				throw new ArgumentException("The number of elements in the Tensor is greater than the available space from index to the end of the destination array.", "array");
			}
			for (int i = 0; i < length; i++)
			{
				array.SetValue(GetValue(i), index + i);
			}
		}

		int IList.Add(object value)
		{
			throw new InvalidOperationException();
		}

		void IList.Clear()
		{
			Fill(default);
		}

		bool IList.Contains(object value)
		{
			if (IsCompatibleObject(value))
			{
				return Contains((T)value);
			}
			return false;
		}

		int IList.IndexOf(object value)
		{
			if (IsCompatibleObject(value))
			{
				return IndexOf((T)value);
			}
			return -1;
		}

		void IList.Insert(int index, object value)
		{
			throw new InvalidOperationException();
		}

		void IList.Remove(object value)
		{
			throw new InvalidOperationException();
		}

		void IList.RemoveAt(int index)
		{
			throw new InvalidOperationException();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			for (int i = 0; i < Length; i++)
			{
				yield return GetValue(i);
			}
		}

		void ICollection<T>.Add(T item)
		{
			throw new InvalidOperationException();
		}

		void ICollection<T>.Clear()
		{
			Fill(default);
		}

		bool ICollection<T>.Contains(T item)
		{
			return Contains(item);
		}

		protected virtual bool Contains(T item)
		{
			if (Length != 0L)
			{
				return IndexOf(item) != -1;
			}
			return false;
		}

		void ICollection<T>.CopyTo(T[] array, int arrayIndex)
		{
			CopyTo(array, arrayIndex);
		}

		protected virtual void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (array.Length < arrayIndex + Length)
			{
				throw new ArgumentException("The number of elements in the Tensor is greater than the available space from index to the end of the destination array.", "array");
			}
			for (int i = 0; i < length; i++)
			{
				array[arrayIndex + i] = GetValue(i);
			}
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new InvalidOperationException();
		}

		int IList<T>.IndexOf(T item)
		{
			return IndexOf(item);
		}

		protected virtual int IndexOf(T item)
		{
			for (int i = 0; i < Length; i++)
			{
				if (GetValue(i).Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		void IList<T>.Insert(int index, T item)
		{
			throw new InvalidOperationException();
		}

		void IList<T>.RemoveAt(int index)
		{
			throw new InvalidOperationException();
		}

		int IStructuralComparable.CompareTo(object other, IComparer comparer)
		{
			if (other == null)
			{
				return 1;
			}
			if (other is Tensor<T>)
			{
				return CompareTo((Tensor<T>)other, comparer);
			}
			if (other is Array other2)
			{
				return CompareTo(other2, comparer);
			}
			throw new ArgumentException($"Cannot compare {"Tensor"} to {other.GetType()}.", "other");
		}

		private int CompareTo(Tensor<T> other, IComparer comparer)
		{
			if (Rank != other.Rank)
			{
				throw new ArgumentException($"Cannot compare {"Tensor"} with Rank {Rank} to {"other"} with Rank {other.Rank}.", "other");
			}
			for (int i = 0; i < dimensions.Length; i++)
			{
				if (dimensions[i] != other.dimensions[i])
				{
					throw new ArgumentException($"Cannot compare {"Tensor"}s with differning dimension {i}, {dimensions[i]} != {other.dimensions[i]}.", "other");
				}
			}
			int num = 0;
			if (IsReversedStride == other.IsReversedStride)
			{
				for (int j = 0; j < Length; j++)
				{
					num = comparer.Compare(GetValue(j), other.GetValue(j));
					if (num != 0)
					{
						break;
					}
				}
			}
			else
			{
				Span<int> span = ((Rank >= 16) ? ((Span<int>)new int[Rank]) : stackalloc int[Rank]);
				Span<int> span2 = span;
				for (int k = 0; k < Length; k++)
				{
					ArrayUtilities.GetIndices(strides, IsReversedStride, k, span2);
					num = comparer.Compare(this[span2], other[span2]);
					if (num != 0)
					{
						break;
					}
				}
			}
			return num;
		}

		private int CompareTo(Array other, IComparer comparer)
		{
			if (Rank != other.Rank)
			{
				throw new ArgumentException($"Cannot compare {"Tensor"} with Rank {Rank} to {"Array"} with rank {other.Rank}.", "other");
			}
			for (int i = 0; i < dimensions.Length; i++)
			{
				int num = other.GetLength(i);
				if (dimensions[i] != num)
				{
					throw new ArgumentException($"Cannot compare {"Tensor"} to {"Array"} with differning dimension {i}, {dimensions[i]} != {num}.", "other");
				}
			}
			int num2 = 0;
			int[] indices = new int[Rank];
			for (int j = 0; j < Length; j++)
			{
				ArrayUtilities.GetIndices(strides, IsReversedStride, j, indices);
				num2 = comparer.Compare(GetValue(j), other.GetValue(indices));
				if (num2 != 0)
				{
					break;
				}
			}
			return num2;
		}

		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
		{
			if (other == null)
			{
				return false;
			}
			if (other is Tensor<T>)
			{
				return Equals((Tensor<T>)other, comparer);
			}
			if (other is Array other2)
			{
				return Equals(other2, comparer);
			}
			throw new ArgumentException($"Cannot compare {"Tensor"} to {other.GetType()}.", "other");
		}

		private bool Equals(Tensor<T> other, IEqualityComparer comparer)
		{
			if (Rank != other.Rank)
			{
				throw new ArgumentException($"Cannot compare {"Tensor"} with Rank {Rank} to {"other"} with Rank {other.Rank}.", "other");
			}
			for (int i = 0; i < dimensions.Length; i++)
			{
				if (dimensions[i] != other.dimensions[i])
				{
					throw new ArgumentException($"Cannot compare {"Tensor"}s with differning dimension {i}, {dimensions[i]} != {other.dimensions[i]}.", "other");
				}
			}
			if (IsReversedStride == other.IsReversedStride)
			{
				for (int j = 0; j < Length; j++)
				{
					if (!comparer.Equals(GetValue(j), other.GetValue(j)))
					{
						return false;
					}
				}
			}
			else
			{
				Span<int> span = ((Rank >= 16) ? ((Span<int>)new int[Rank]) : stackalloc int[Rank]);
				Span<int> span2 = span;
				for (int k = 0; k < Length; k++)
				{
					ArrayUtilities.GetIndices(strides, IsReversedStride, k, span2);
					if (!comparer.Equals(this[span2], other[span2]))
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool Equals(Array other, IEqualityComparer comparer)
		{
			if (Rank != other.Rank)
			{
				throw new ArgumentException($"Cannot compare {"Tensor"} with Rank {Rank} to {"Array"} with rank {other.Rank}.", "other");
			}
			for (int i = 0; i < dimensions.Length; i++)
			{
				int num = other.GetLength(i);
				if (dimensions[i] != num)
				{
					throw new ArgumentException($"Cannot compare {"Tensor"} to {"Array"} with differning dimension {i}, {dimensions[i]} != {num}.", "other");
				}
			}
			int[] indices = new int[Rank];
			for (int j = 0; j < Length; j++)
			{
				ArrayUtilities.GetIndices(strides, IsReversedStride, j, indices);
				if (!comparer.Equals(GetValue(j), other.GetValue(indices)))
				{
					return false;
				}
			}
			return true;
		}

		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
		{
			int num = 0;
			for (int i = 0; i < Length; i++)
			{
				num ^= comparer.GetHashCode(GetValue(i));
			}
			return num;
		}

		public virtual DenseTensor<T> ToDenseTensor()
		{
			DenseTensor<T> denseTensor = new DenseTensor<T>(Dimensions, IsReversedStride);
			for (int i = 0; i < Length; i++)
			{
				denseTensor.SetValue(i, GetValue(i));
			}
			return denseTensor;
		}

		public string GetArrayString(bool includeWhitespace = true)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int[] array = ArrayUtilities.GetStrides(dimensions);
			int[] array2 = new int[Rank];
			int num = Rank - 1;
			int num2 = dimensions[num];
			_ = Length / num2;
			int num3 = 0;
			for (int i = 0; i < Length; i += num2)
			{
				ArrayUtilities.GetIndices(array, reverseStride: false, i, array2);
				while (num3 < num && array2[num3] == 0)
				{
					if (includeWhitespace)
					{
						Indent(stringBuilder, num3);
					}
					num3++;
					stringBuilder.Append('{');
					if (includeWhitespace)
					{
						stringBuilder.AppendLine();
					}
				}
				for (int j = 0; j < num2; j++)
				{
					array2[num] = j;
					if (j == 0)
					{
						if (includeWhitespace)
						{
							Indent(stringBuilder, num3);
						}
						stringBuilder.Append('{');
					}
					else
					{
						stringBuilder.Append(',');
					}
					stringBuilder.Append(this[array2]);
				}
				stringBuilder.Append('}');
				int num4 = Rank - 2;
				while (num4 >= 0)
				{
					int num5 = dimensions[num4] - 1;
					if (array2[num4] == num5)
					{
						num3--;
						if (includeWhitespace)
						{
							stringBuilder.AppendLine();
							Indent(stringBuilder, num3);
						}
						stringBuilder.Append('}');
						num4--;
						continue;
					}
					stringBuilder.Append(',');
					if (includeWhitespace)
					{
						stringBuilder.AppendLine();
					}
					break;
				}
			}
			return stringBuilder.ToString();
		}

		private static void Indent(StringBuilder builder, int tabs, int spacesPerTab = 4)
		{
			for (int i = 0; i < tabs; i++)
			{
				for (int j = 0; j < spacesPerTab; j++)
				{
					builder.Append(' ');
				}
			}
		}

		private static bool IsCompatibleObject(object value)
		{
			if (!(value is T))
			{
				if (value == null)
				{
					return default(T) == null;
				}
				return false;
			}
			return true;
		}
	}
}
namespace Microsoft.ML.OnnxRuntime.CompileApi
{
	public struct OrtCompileApi
	{
		public nint ReleaseModelCompilationOptions;

		public nint CreateModelCompilationOptionsFromSessionOptions;

		public nint ModelCompilationOptions_SetInputModelPath;

		public nint ModelCompilationOptions_SetInputModelFromBuffer;

		public nint ModelCompilationOptions_SetOutputModelPath;

		public nint ModelCompilationOptions_SetOutputModelExternalInitializersFile;

		public nint ModelCompilationOptions_SetOutputModelBuffer;

		public nint ModelCompilationOptions_SetEpContextEmbedMode;

		public nint CompileModel;

		public nint ModelCompilationOptions_SetFlags;

		public nint ModelCompilationOptions_SetEpContextBinaryInformation;

		public nint ModelCompilationOptions_SetGraphOptimizationLevel;

		public nint ModelCompilationOptions_SetOutputModelWriteFunc;

		public nint ModelCompilationOptions_SetOutputModelGetInitializerLocationFunc;

		public nint ModelCompilationOptions_SetInputModel;
	}
	internal class NativeMethods
	{
		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate void DOrtReleaseModelCompilationOptions(nint options);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCreateModelCompilationOptionsFromSessionOptions(nint env, nint sessionOptions, out nint outOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetInputModelPath(nint options, byte[] inputModelPath);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetInputModelFromBuffer(nint options, byte[] inputModelData, nuint inputModelDataSize);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetOutputModelPath(nint options, byte[] outputModelPath);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetOutputModelExternalInitializersFile(nint options, byte[] externalInitializersFilePath, nuint externalInitializerSizeThreshold);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetOutputModelBuffer(nint options, nint allocator, ref nint outputModelBufferPtr, ref nuint outputModelBufferSizePtr);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetEpContextEmbedMode(nint options, bool embedEpContextInModel);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtCompileModel(nint env, nint modelOptions);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetFlags(nint options, uint flags);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetEpContextBinaryInformation(nint options, byte[] outputDirectory, byte[] modelName);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetGraphOptimizationLevel(nint options, GraphOptimizationLevel graphOptimizationLevel);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetOutputModelWriteFunc(nint options, nint writeFunc, nint state);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetOutputModelGetInitializerLocationFunc(nint options, nint handleInitializerFunc, nint state);

		[UnmanagedFunctionPointer(CallingConvention.Winapi)]
		public delegate nint DOrtModelCompilationOptions_SetInputModel(nint options, nint inputModel);

		private static OrtCompileApi _compileApi;

		public DOrtReleaseModelCompilationOptions OrtReleaseModelCompilationOptions;

		public DOrtCreateModelCompilationOptionsFromSessionOptions OrtCreateModelCompilationOptionsFromSessionOptions;

		public DOrtModelCompilationOptions_SetInputModelPath OrtModelCompilationOptions_SetInputModelPath;

		public DOrtModelCompilationOptions_SetInputModelFromBuffer OrtModelCompilationOptions_SetInputModelFromBuffer;

		public DOrtModelCompilationOptions_SetOutputModelPath OrtModelCompilationOptions_SetOutputModelPath;

		public DOrtModelCompilationOptions_SetOutputModelExternalInitializersFile OrtModelCompilationOptions_SetOutputModelExternalInitializersFile;

		public DOrtModelCompilationOptions_SetOutputModelBuffer OrtModelCompilationOptions_SetOutputModelBuffer;

		public DOrtModelCompilationOptions_SetEpContextEmbedMode OrtModelCompilationOptions_SetEpContextEmbedMode;

		public DOrtCompileModel OrtCompileModel;

		public DOrtModelCompilationOptions_SetFlags OrtModelCompilationOptions_SetFlags;

		public DOrtModelCompilationOptions_SetEpContextBinaryInformation OrtModelCompilationOptions_SetEpContextBinaryInformation;

		public DOrtModelCompilationOptions_SetGraphOptimizationLevel OrtModelCompilationOptions_SetGraphOptimizationLevel;

		public DOrtModelCompilationOptions_SetOutputModelWriteFunc OrtModelCompilationOptions_SetOutputModelWriteFunc;

		public DOrtModelCompilationOptions_SetOutputModelGetInitializerLocationFunc OrtModelCompilationOptions_SetOutputModelGetInitializerLocationFunc;

		public DOrtModelCompilationOptions_SetInputModel OrtModelCompilationOptions_SetInputModel;

		internal NativeMethods(Microsoft.ML.OnnxRuntime.NativeMethods.DOrtGetCompileApi getCompileApi)
		{
			_compileApi = getCompileApi();
			OrtReleaseModelCompilationOptions = (DOrtReleaseModelCompilationOptions)Marshal.GetDelegateForFunctionPointer(_compileApi.ReleaseModelCompilationOptions, typeof(DOrtReleaseModelCompilationOptions));
			OrtCreateModelCompilationOptionsFromSessionOptions = (DOrtCreateModelCompilationOptionsFromSessionOptions)Marshal.GetDelegateForFunctionPointer(_compileApi.CreateModelCompilationOptionsFromSessionOptions, typeof(DOrtCreateModelCompilationOptionsFromSessionOptions));
			OrtModelCompilationOptions_SetInputModelPath = (DOrtModelCompilationOptions_SetInputModelPath)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetInputModelPath, typeof(DOrtModelCompilationOptions_SetInputModelPath));
			OrtModelCompilationOptions_SetInputModelFromBuffer = (DOrtModelCompilationOptions_SetInputModelFromBuffer)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetInputModelFromBuffer, typeof(DOrtModelCompilationOptions_SetInputModelFromBuffer));
			OrtModelCompilationOptions_SetOutputModelPath = (DOrtModelCompilationOptions_SetOutputModelPath)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetOutputModelPath, typeof(DOrtModelCompilationOptions_SetOutputModelPath));
			OrtModelCompilationOptions_SetOutputModelExternalInitializersFile = (DOrtModelCompilationOptions_SetOutputModelExternalInitializersFile)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetOutputModelExternalInitializersFile, typeof(DOrtModelCompilationOptions_SetOutputModelExternalInitializersFile));
			OrtModelCompilationOptions_SetOutputModelBuffer = (DOrtModelCompilationOptions_SetOutputModelBuffer)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetOutputModelBuffer, typeof(DOrtModelCompilationOptions_SetOutputModelBuffer));
			OrtModelCompilationOptions_SetEpContextEmbedMode = (DOrtModelCompilationOptions_SetEpContextEmbedMode)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetEpContextEmbedMode, typeof(DOrtModelCompilationOptions_SetEpContextEmbedMode));
			OrtCompileModel = (DOrtCompileModel)Marshal.GetDelegateForFunctionPointer(_compileApi.CompileModel, typeof(DOrtCompileModel));
			OrtModelCompilationOptions_SetFlags = (DOrtModelCompilationOptions_SetFlags)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetFlags, typeof(DOrtModelCompilationOptions_SetFlags));
			OrtModelCompilationOptions_SetEpContextBinaryInformation = (DOrtModelCompilationOptions_SetEpContextBinaryInformation)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetEpContextBinaryInformation, typeof(DOrtModelCompilationOptions_SetEpContextBinaryInformation));
			OrtModelCompilationOptions_SetGraphOptimizationLevel = (DOrtModelCompilationOptions_SetGraphOptimizationLevel)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetGraphOptimizationLevel, typeof(DOrtModelCompilationOptions_SetGraphOptimizationLevel));
			OrtModelCompilationOptions_SetOutputModelWriteFunc = (DOrtModelCompilationOptions_SetOutputModelWriteFunc)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetOutputModelWriteFunc, typeof(DOrtModelCompilationOptions_SetOutputModelWriteFunc));
			OrtModelCompilationOptions_SetOutputModelGetInitializerLocationFunc = (DOrtModelCompilationOptions_SetOutputModelGetInitializerLocationFunc)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetOutputModelGetInitializerLocationFunc, typeof(DOrtModelCompilationOptions_SetOutputModelGetInitializerLocationFunc));
			OrtModelCompilationOptions_SetInputModel = (DOrtModelCompilationOptions_SetInputModel)Marshal.GetDelegateForFunctionPointer(_compileApi.ModelCompilationOptions_SetInputModel, typeof(DOrtModelCompilationOptions_SetInputModel));
		}
	}
}
