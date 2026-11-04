using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Interop.UIAutomationClient;
using SmartInput.Core.Environments;
using SmartInput.Core.Environments.Protocol;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETCoreApp,Version=v10.0", FrameworkDisplayName = ".NET 10.0")]
[assembly: AssemblyCompany("SmartInput.EnvironmentProbe")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+1067fa6d75b7fbb34a023a09c9716a95d6187838")]
[assembly: AssemblyProduct("SmartInput.EnvironmentProbe")]
[assembly: AssemblyTitle("SmartInput.EnvironmentProbe")]
[assembly: TargetPlatform("Windows7.0")]
[assembly: SupportedOSPlatform("Windows7.0")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: RefSafetyRules(11)]
namespace SmartInput.EnvironmentProbe;

public sealed record BoundedContextOutcome
{
	public required ObservationStatus CaretRangeStatus { get; init; }

	public required ObservationStatus SelectionStatus { get; init; }

	public bool CaretActive { get; init; }

	public int SelectionRangeCount { get; init; }

	public bool ReadSucceeded { get; init; }

	public ObservationStatus ReadFailureStatus { get; init; }

	public ContextHealth Health { get; init; }

	public bool ChangeOutsideSampledRangePossible { get; init; }

	public bool ContractViolation { get; init; }

	public bool RangeLeftElement { get; init; }

	public int ReturnedUtf16Length { get; init; }

	public RangeAttributeReading ReadOnlyAttribute { get; init; }

	public RangeAttributeReading AlignmentAttribute { get; init; }

	public RangeAttributeReading FlowDirectionAttribute { get; init; }
}
public static class BoundedContextReader
{
	public static BoundedContextOutcome TryRead(IUIAutomationElement focusedElement, EnvironmentObservationOptions options)
	{
		ArgumentNullException.ThrowIfNull(focusedElement, "focusedElement");
		IUIAutomation iUIAutomation = new CUIAutomation8Class();
		try
		{
			return TryRead(new UiaProbeElement(focusedElement, iUIAutomation), options);
		}
		finally
		{
			Marshal.FinalReleaseComObject(iUIAutomation);
		}
	}

	public static BoundedContextOutcome TryRead(IProbeElement focusedElement, EnvironmentObservationOptions options, ContextChangeTracker? tracker = null, string identityKey = "")
	{
		ArgumentNullException.ThrowIfNull(focusedElement, "focusedElement");
		ArgumentNullException.ThrowIfNull(options, "options");
		IProbeTextSource probeTextSource;
		try
		{
			probeTextSource = focusedElement.OpenTextSource();
		}
		catch (Exception exception)
		{
			return FailedWith(ProbeFailureMapper.Map(exception));
		}
		if (probeTextSource == null)
		{
			return Unsupported();
		}
		if (probeTextSource.SupportsCaretRange)
		{
			IProbeTextRange caretRange;
			bool isActive;
			try
			{
				caretRange = probeTextSource.GetCaretRange(out isActive);
			}
			catch (Exception exception2)
			{
				return FailedWith(ProbeFailureMapper.Map(exception2));
			}
			if ((caretRange != null) & isActive)
			{
				return ReadBoundedRangeAroundCaret(focusedElement, caretRange, options, tracker, identityKey);
			}
			return ReadSelectionFallback(focusedElement, probeTextSource, options, caretRangeAttempted: true, tracker, identityKey);
		}
		return ReadSelectionFallback(focusedElement, probeTextSource, options, caretRangeAttempted: false, tracker, identityKey);
	}

	private static BoundedContextOutcome ReadBoundedRangeAroundCaret(IProbeElement focusedElement, IProbeTextRange caretRange, EnvironmentObservationOptions options, ContextChangeTracker? tracker, string identityKey)
	{
		try
		{
			IProbeTextRange probeTextRange = caretRange.Clone();
			int value = probeTextRange.MoveStartByCharacters(-options.MaxCharacterUnitsBeforeCaret);
			int value2 = probeTextRange.MoveEndByCharacters(options.MaxCharacterUnitsAfterCaret);
			if (Math.Abs(value) > options.MaxCharacterUnitsBeforeCaret || Math.Abs(value2) > options.MaxCharacterUnitsAfterCaret)
			{
				return Violation(caretActive: true, caretRangeAttempted: true);
			}
			if (!probeTextRange.IsEnclosedBy(focusedElement))
			{
				return Violation(caretActive: true, caretRangeAttempted: true) with
				{
					RangeLeftElement = true
				};
			}
			RangeAttributeReading readOnlyAttribute = ReadAttribute(probeTextRange, RangeAttributeKind.IsReadOnly);
			RangeAttributeReading alignmentAttribute = ReadAttribute(probeTextRange, RangeAttributeKind.HorizontalAlignment);
			RangeAttributeReading flowDirectionAttribute = ReadAttribute(probeTextRange, RangeAttributeKind.FlowDirection);
			BoundedContextOutcome boundedContextOutcome = ReadAndJudge(probeTextRange, options, tracker, identityKey);
			return boundedContextOutcome with
			{
				CaretRangeStatus = boundedContextOutcome.CaretRangeStatus,
				CaretActive = true,
				SelectionStatus = ObservationStatus.NotAttempted,
				ReadOnlyAttribute = readOnlyAttribute,
				AlignmentAttribute = alignmentAttribute,
				FlowDirectionAttribute = flowDirectionAttribute
			};
		}
		catch (Exception exception)
		{
			ObservationStatus observationStatus = ProbeFailureMapper.Map(exception);
			return new BoundedContextOutcome
			{
				CaretRangeStatus = observationStatus,
				SelectionStatus = ObservationStatus.NotAttempted,
				CaretActive = true,
				ReadSucceeded = false,
				ReadFailureStatus = observationStatus
			};
		}
	}

	private static BoundedContextOutcome ReadSelectionFallback(IProbeElement focusedElement, IProbeTextSource source, EnvironmentObservationOptions options, bool caretRangeAttempted, ContextChangeTracker? tracker, string identityKey)
	{
		ObservationStatus caretRangeStatus = (caretRangeAttempted ? ObservationStatus.Failed : ObservationStatus.NotAttempted);
		IReadOnlyList<IProbeTextRange> selection;
		try
		{
			selection = source.GetSelection();
		}
		catch (Exception exception)
		{
			ObservationStatus observationStatus = ProbeFailureMapper.Map(exception);
			return new BoundedContextOutcome
			{
				CaretRangeStatus = caretRangeStatus,
				SelectionStatus = observationStatus,
				ReadSucceeded = false,
				ReadFailureStatus = observationStatus
			};
		}
		int num = selection?.Count ?? 0;
		if (num == 0)
		{
			return new BoundedContextOutcome
			{
				CaretRangeStatus = caretRangeStatus,
				SelectionStatus = ObservationStatus.Unsupported,
				SelectionRangeCount = 0,
				ReadSucceeded = false
			};
		}
		if (num > 1)
		{
			return new BoundedContextOutcome
			{
				CaretRangeStatus = caretRangeStatus,
				SelectionStatus = ObservationStatus.Succeeded,
				SelectionRangeCount = num,
				ReadSucceeded = false
			};
		}
		try
		{
			IProbeTextRange probeTextRange = selection[0].Clone();
			string text = probeTextRange.GetText(1);
			if (text != null && text.Length == 0)
			{
				int value = probeTextRange.MoveStartByCharacters(-options.MaxCharacterUnitsBeforeCaret);
				int value2 = probeTextRange.MoveEndByCharacters(options.MaxCharacterUnitsAfterCaret);
				if (Math.Abs(value) > options.MaxCharacterUnitsBeforeCaret || Math.Abs(value2) > options.MaxCharacterUnitsAfterCaret)
				{
					return Violation(caretActive: false, caretRangeAttempted) with
					{
						SelectionRangeCount = 1
					};
				}
				if (!probeTextRange.IsEnclosedBy(focusedElement))
				{
					return Violation(caretActive: false, caretRangeAttempted) with
					{
						SelectionRangeCount = 1,
						RangeLeftElement = true
					};
				}
			}
			RangeAttributeReading readOnlyAttribute = ReadAttribute(probeTextRange, RangeAttributeKind.IsReadOnly);
			RangeAttributeReading alignmentAttribute = ReadAttribute(probeTextRange, RangeAttributeKind.HorizontalAlignment);
			RangeAttributeReading flowDirectionAttribute = ReadAttribute(probeTextRange, RangeAttributeKind.FlowDirection);
			BoundedContextOutcome boundedContextOutcome = ReadAndJudge(probeTextRange, options, tracker, identityKey);
			return boundedContextOutcome with
			{
				CaretRangeStatus = caretRangeStatus,
				SelectionStatus = (boundedContextOutcome.ReadSucceeded ? ObservationStatus.Succeeded : ((boundedContextOutcome.ReadFailureStatus != ObservationStatus.NotAttempted) ? boundedContextOutcome.ReadFailureStatus : ObservationStatus.Failed)),
				SelectionRangeCount = 1,
				ReadOnlyAttribute = readOnlyAttribute,
				AlignmentAttribute = alignmentAttribute,
				FlowDirectionAttribute = flowDirectionAttribute
			};
		}
		catch (Exception exception2)
		{
			ObservationStatus observationStatus2 = ProbeFailureMapper.Map(exception2);
			return new BoundedContextOutcome
			{
				CaretRangeStatus = caretRangeStatus,
				SelectionStatus = observationStatus2,
				SelectionRangeCount = 1,
				ReadSucceeded = false,
				ReadFailureStatus = observationStatus2
			};
		}
	}

	private static BoundedContextOutcome ReadAndJudge(IProbeTextRange clone, EnvironmentObservationOptions options, ContextChangeTracker? tracker, string identityKey)
	{
		string text;
		try
		{
			text = clone.GetText(options.MaxContextTextUtf16CodeUnits);
		}
		catch (Exception exception)
		{
			ObservationStatus observationStatus = ProbeFailureMapper.Map(exception);
			return new BoundedContextOutcome
			{
				CaretRangeStatus = observationStatus,
				SelectionStatus = ObservationStatus.NotAttempted,
				ReadSucceeded = false,
				ReadFailureStatus = observationStatus
			};
		}
		if (text == null)
		{
			return new BoundedContextOutcome
			{
				CaretRangeStatus = ObservationStatus.Failed,
				SelectionStatus = ObservationStatus.NotAttempted,
				ReadSucceeded = false,
				ReadFailureStatus = ObservationStatus.Failed
			};
		}
		if (text.Length > options.MaxContextTextUtf16CodeUnits)
		{
			return Violation(caretActive: false, caretRangeAttempted: true) with
			{
				ReturnedUtf16Length = 0
			};
		}
		ContextObservationVerdict contextObservationVerdict = tracker?.Observe(identityKey, text) ?? new ContextObservationVerdict(ContextHealth.ReadObserved, ChangeEventSincePriorRead: false, PriorSampleComparable: false);
		return new BoundedContextOutcome
		{
			CaretRangeStatus = ObservationStatus.Succeeded,
			SelectionStatus = ObservationStatus.NotAttempted,
			ReadSucceeded = true,
			ReturnedUtf16Length = text.Length,
			Health = contextObservationVerdict.Health,
			ChangeOutsideSampledRangePossible = (contextObservationVerdict.Health == ContextHealth.ReadObserved && contextObservationVerdict.ChangeEventSincePriorRead)
		};
	}

	private static RangeAttributeReading ReadAttribute(IProbeTextRange range, RangeAttributeKind kind)
	{
		try
		{
			return range.GetAttribute(kind);
		}
		catch (Exception)
		{
			return new RangeAttributeReading(RangeAttributeState.Failed);
		}
	}

	private static BoundedContextOutcome Violation(bool caretActive, bool caretRangeAttempted)
	{
		return new BoundedContextOutcome
		{
			CaretRangeStatus = (caretRangeAttempted ? ObservationStatus.Invalid : ObservationStatus.NotAttempted),
			SelectionStatus = ObservationStatus.NotAttempted,
			CaretActive = caretActive,
			ReadSucceeded = false,
			ReadFailureStatus = ObservationStatus.Invalid,
			ContractViolation = true
		};
	}

	private static BoundedContextOutcome FailedWith(ObservationStatus status)
	{
		return new BoundedContextOutcome
		{
			CaretRangeStatus = status,
			SelectionStatus = status,
			ReadSucceeded = false,
			ReadFailureStatus = status
		};
	}

	private static BoundedContextOutcome Unsupported()
	{
		return new BoundedContextOutcome
		{
			CaretRangeStatus = ObservationStatus.Unsupported,
			SelectionStatus = ObservationStatus.Unsupported,
			ReadSucceeded = false
		};
	}
}
public readonly record struct ContextObservationVerdict(ContextHealth Health, bool ChangeEventSincePriorRead, bool PriorSampleComparable);
public sealed class ContextChangeTracker
{
	private readonly object _gate = new object();

	private readonly TimeProvider _clock;

	private readonly TimeSpan _retention;

	private string? _priorSample;

	private string? _priorIdentityKey;

	private long _priorSampleTimestamp;

	private long _changeEventCount;

	private long _changeEventCountAtPriorSample;

	public long ChangeEventCount
	{
		get
		{
			lock (_gate)
			{
				return _changeEventCount;
			}
		}
	}

	public bool HasRetainedSample
	{
		get
		{
			lock (_gate)
			{
				return _priorSample != null;
			}
		}
	}

	public ContextChangeTracker(TimeSpan retention, TimeProvider? clock = null)
	{
		_retention = retention;
		_clock = clock ?? TimeProvider.System;
	}

	public void NoteChangeEvent()
	{
		lock (_gate)
		{
			_changeEventCount++;
		}
	}

	public void Reset()
	{
		lock (_gate)
		{
			ClearSample();
		}
	}

	public ContextObservationVerdict Observe(string identityKey, string sampleText)
	{
		ArgumentNullException.ThrowIfNull(identityKey, "identityKey");
		ArgumentNullException.ThrowIfNull(sampleText, "sampleText");
		lock (_gate)
		{
			long timestamp = _clock.GetTimestamp();
			bool flag = _priorSample != null && string.Equals(_priorIdentityKey, identityKey, StringComparison.Ordinal) && _clock.GetElapsedTime(_priorSampleTimestamp, timestamp) <= _retention;
			bool flag2 = _changeEventCount != _changeEventCountAtPriorSample;
			ContextHealth health = ContextHealth.ReadObserved;
			if (flag && !string.Equals(_priorSample, sampleText, StringComparison.Ordinal))
			{
				health = ContextHealth.ChangeObserved;
			}
			_priorSample = sampleText;
			_priorIdentityKey = identityKey;
			_priorSampleTimestamp = timestamp;
			_changeEventCountAtPriorSample = _changeEventCount;
			return new ContextObservationVerdict(health, flag & flag2, flag);
		}
	}

	private void ClearSample()
	{
		_priorSample = null;
		_priorIdentityKey = null;
		_changeEventCountAtPriorSample = _changeEventCount;
	}
}
public sealed record FocusedSurfaceObservation(IdentityStrength IdentityStrength, int[]? RuntimeId, int ProcessId, int NativeWindowHandle, int ControlTypeId, string ClassName, string AutomationId, ProtectionState Protection, Editability Editability, bool HasValuePattern, bool HasTextPattern, bool HasTextEditPattern, List<string> AncestorClassNames, List<int> AncestorControlTypes, IReadOnlyList<int>? AncestorWindowHandles = null);
public static class UIA_PatternIds
{
	public const int UIA_ValuePatternId = 10002;

	public const int UIA_TextPatternId = 10014;

	public const int UIA_TextPattern2Id = 10024;

	public const int UIA_TextEditPatternId = 10032;
}
public static class IdentityResolver
{
	public static IdentityStrength Resolve(int[]? runtimeId, int nativeWindowHandle, IReadOnlyList<int> ancestorWindowHandles, int foregroundRootWindow, Func<int, int> getRootWindow, int maxRuntimeIdLength)
	{
		ArgumentNullException.ThrowIfNull(ancestorWindowHandles, "ancestorWindowHandles");
		ArgumentNullException.ThrowIfNull(getRootWindow, "getRootWindow");
		if (runtimeId == null || runtimeId.Length <= 0 || runtimeId.Length > maxRuntimeIdLength)
		{
			if (nativeWindowHandle == 0)
			{
				return IdentityStrength.None;
			}
			return IdentityStrength.WindowOnly;
		}
		if (nativeWindowHandle != 0)
		{
			return IdentityStrength.ElementScoped;
		}
		if (foregroundRootWindow == 0)
		{
			return IdentityStrength.None;
		}
		foreach (int ancestorWindowHandle in ancestorWindowHandles)
		{
			if (ancestorWindowHandle != 0)
			{
				int num = getRootWindow(ancestorWindowHandle);
				return (ancestorWindowHandle == foregroundRootWindow || num == foregroundRootWindow) ? IdentityStrength.ElementScoped : IdentityStrength.None;
			}
		}
		return IdentityStrength.None;
	}

	public static string KeyFor(int[]? runtimeId, int processId)
	{
		if (runtimeId == null || runtimeId.Length <= 0)
		{
			return string.Empty;
		}
		return $"{processId}:{string.Join('.', runtimeId)}";
	}
}
public static class NativeMetadataReader
{
	public readonly record struct NativeSelectionResult(ObservationStatus Status, int Start, int End);

	private const uint EM_GETSEL = 176u;

	private const uint SMTO_ABORTIFHUNG = 2u;

	private const uint SMTO_ERRORONEXIT = 32u;

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern nint SendMessageTimeout(nint hWnd, uint msg, nint wParam, nint lParam, uint fuFlags, uint uTimeout, out nint lpdwResult);

	public static NativeSelectionResult TryGetSelection(nint windowHandle, EnvironmentObservationOptions options)
	{
		if (windowHandle == IntPtr.Zero)
		{
			return new NativeSelectionResult(ObservationStatus.Invalid, 0, 0);
		}
		nint num;
		nint lpdwResult;
		try
		{
			num = SendMessageTimeout(windowHandle, 176u, IntPtr.Zero, IntPtr.Zero, 34u, (uint)options.NativeMessageTimeout.TotalMilliseconds, out lpdwResult);
		}
		catch (Exception)
		{
			return new NativeSelectionResult(ObservationStatus.Failed, 0, 0);
		}
		int lastError = ((num == IntPtr.Zero) ? Marshal.GetLastWin32Error() : 0);
		return Decode(num != IntPtr.Zero, lastError, ((IntPtr)lpdwResult).ToInt64());
	}

	public static NativeSelectionResult Decode(bool callSucceeded, int lastError, long packedMessageResult)
	{
		if (!callSucceeded)
		{
			return new NativeSelectionResult((lastError != 0) ? ObservationStatus.TimedOut : ObservationStatus.Failed, 0, 0);
		}
		long num = packedMessageResult & 0xFFFFFFFFu;
		if (num == uint.MaxValue)
		{
			return new NativeSelectionResult(ObservationStatus.Unsupported, 0, 0);
		}
		int num2 = (int)(num & 0xFFFF);
		int num3 = (int)((num >> 16) & 0xFFFF);
		if (num2 > num3)
		{
			return new NativeSelectionResult(ObservationStatus.Invalid, 0, 0);
		}
		return new NativeSelectionResult(ObservationStatus.Succeeded, num2, num3);
	}
}
public interface IProbeElement
{
	bool IsPassword();

	int[] RuntimeId();

	int ProcessId();

	int NativeWindowHandle();

	int ControlType();

	string ClassName();

	string AutomationId();

	IProbeElement? Parent();

	bool HasValuePattern();

	bool ValuePatternIsReadOnly();

	bool HasTextPattern();

	bool HasTextEditPattern();

	IProbeTextSource? OpenTextSource();

	IProbeCompositionSource? OpenCompositionSource();
}
public interface IProbeTextSource
{
	bool SupportsCaretRange { get; }

	IProbeTextRange? GetCaretRange(out bool isActive);

	IReadOnlyList<IProbeTextRange> GetSelection();
}
public interface IProbeTextRange
{
	IProbeTextRange Clone();

	int MoveStartByCharacters(int count);

	int MoveEndByCharacters(int count);

	string GetText(int maxLength);

	RangeAttributeReading GetAttribute(RangeAttributeKind kind);

	bool IsEnclosedBy(IProbeElement element);
}
public interface IProbeCompositionSource
{
	bool IsCompositionActive();
}
public interface IProbeFocusSource
{
	IProbeElement? GetFocusedElement();

	int GetForegroundRootWindow();

	int GetRootWindow(int windowHandle);

	NativeMetadataReader.NativeSelectionResult ReadNativeSelection(int windowHandle);
}
public enum RangeAttributeKind
{
	IsReadOnly,
	HorizontalAlignment,
	FlowDirection
}
public enum RangeAttributeState
{
	NotAttempted,
	Value,
	Mixed,
	Unsupported,
	Failed
}
public readonly record struct RangeAttributeReading(RangeAttributeState State, int Value = 0);
public interface IProbeChangeSubscriber : IDisposable
{
	ChangeSubscriptionResult Subscribe(IProbeElement element, Action<ContextChangeKind> onChange);

	void Unsubscribe();
}
public readonly record struct ChangeSubscriptionResult(ObservationStatus TextChanges, ObservationStatus SelectionChanges);
public readonly record struct ChangeDeliveryCounts(int TextEvents, int SelectionEvents);
public static class ProbeFailureMapper
{
	private const int UiaETimeout = -2146233083;

	private const int UiaEElementNotAvailable = -2147220991;

	private const int UiaENotSupported = -2147220988;

	private const int EAccessDenied = -2147024891;

	private const int RpcEDisconnected = -2147417848;

	private const int RpcServerUnavailable = -2147023174;

	public static ObservationStatus Map(Exception exception)
	{
		ArgumentNullException.ThrowIfNull(exception, "exception");
		if (!(exception is TimeoutException))
		{
			if (!(exception is OperationCanceledException))
			{
				if (!(exception is UnauthorizedAccessException))
				{
					if (!(exception is NotSupportedException))
					{
						if (exception is COMException ex)
						{
							return MapHResult(ex.HResult);
						}
						return ObservationStatus.Failed;
					}
					return ObservationStatus.Unsupported;
				}
				return ObservationStatus.AccessDenied;
			}
			return ObservationStatus.TimedOut;
		}
		return ObservationStatus.TimedOut;
	}

	public static string ReasonCodeFor(ObservationStatus status)
	{
		return status switch
		{
			ObservationStatus.TimedOut => "ProviderTimeout", 
			ObservationStatus.AccessDenied => "AccessDenied", 
			ObservationStatus.ElementGone => "ElementGone", 
			ObservationStatus.Invalid => "ProviderContractViolation", 
			_ => string.Empty, 
		};
	}

	private static ObservationStatus MapHResult(int hresult)
	{
		return hresult switch
		{
			-2146233083 => ObservationStatus.TimedOut, 
			-2147220991 => ObservationStatus.ElementGone, 
			-2147417848 => ObservationStatus.ElementGone, 
			-2147023174 => ObservationStatus.ElementGone, 
			-2147220988 => ObservationStatus.Unsupported, 
			-2147024891 => ObservationStatus.AccessDenied, 
			_ => ObservationStatus.Failed, 
		};
	}
}
public sealed class ProbeOrchestrator
{
	private readonly IProbeFocusSource _focus;

	private readonly EnvironmentObservationOptions _options;

	private readonly ContextChangeTracker _tracker;

	private readonly IProbeChangeSubscriber? _subscriber;

	private readonly Action<ContextChangeKind>? _onContextChanged;

	private string _subscribedKey = string.Empty;

	private ChangeSubscriptionResult? _subscription;

	private int _textEventsSinceSubscribe;

	private int _selectionEventsSinceSubscribe;

	private string _probeIdentityKey = string.Empty;

	private string _lastSurfaceKey = string.Empty;

	private int _surfaceSerial;

	public ContextChangeTracker Tracker => _tracker;

	public int SurfaceSerial => Volatile.Read(in _surfaceSerial);

	private ChangeDeliveryCounts? DeliveryCounts()
	{
		ChangeSubscriptionResult? subscription = _subscription;
		if (subscription.HasValue)
		{
			return new ChangeDeliveryCounts(Volatile.Read(in _textEventsSinceSubscribe), Volatile.Read(in _selectionEventsSinceSubscribe));
		}
		return null;
	}

	public ProbeOrchestrator(IProbeFocusSource focus, EnvironmentObservationOptions options, ContextChangeTracker? tracker = null, IProbeChangeSubscriber? subscriber = null, Action<ContextChangeKind>? onContextChanged = null)
	{
		_focus = focus ?? throw new ArgumentNullException("focus");
		_options = options ?? throw new ArgumentNullException("options");
		_tracker = tracker ?? new ContextChangeTracker(options.RawContextRetentionLimit);
		_subscriber = subscriber;
		_onContextChanged = onContextChanged;
	}

	public TypingEnvironmentSnapshot Probe(EnvironmentTokens tokens, ObservationMode mode)
	{
		_probeIdentityKey = string.Empty;
		TypingEnvironmentSnapshot typingEnvironmentSnapshot = null;
		try
		{
			typingEnvironmentSnapshot = ProbeCore(tokens, mode);
			return typingEnvironmentSnapshot;
		}
		finally
		{
			string text = (((object)typingEnvironmentSnapshot != null && typingEnvironmentSnapshot.IdentityStrength == IdentityStrength.ElementScoped) ? _probeIdentityKey : string.Empty);
			if (text.Length == 0 || !string.Equals(text, _lastSurfaceKey, StringComparison.Ordinal))
			{
				Interlocked.Increment(ref _surfaceSerial);
			}
			_lastSurfaceKey = text;
		}
	}

	private TypingEnvironmentSnapshot ProbeCore(EnvironmentTokens tokens, ObservationMode mode)
	{
		ArgumentNullException.ThrowIfNull(tokens, "tokens");
		IProbeElement focusedElement;
		try
		{
			focusedElement = _focus.GetFocusedElement();
		}
		catch (Exception exception)
		{
			ReleaseSurface();
			return Unresolved(tokens, ProbeFailureMapper.Map(exception));
		}
		if (focusedElement == null)
		{
			ReleaseSurface();
			return Unresolved(tokens, ObservationStatus.Failed);
		}
		FocusedSurfaceObservation focusedSurfaceObservation;
		try
		{
			focusedSurfaceObservation = ReadMetadata(focusedElement);
		}
		catch (Exception exception2)
		{
			ReleaseSurface();
			return Unresolved(tokens, ProbeFailureMapper.Map(exception2));
		}
		string identityKey = (_probeIdentityKey = IdentityResolver.KeyFor(focusedSurfaceObservation.RuntimeId, focusedSurfaceObservation.ProcessId));
		if (!StillSameSurface(focusedSurfaceObservation, requireOrdinary: false))
		{
			ReleaseSurface();
			return Unresolved(tokens, ObservationStatus.Failed, "FocusChanged");
		}
		if (mode != ObservationMode.BoundedContext)
		{
			ReleaseSurface();
			return SnapshotBuilder.FromObservation(focusedSurfaceObservation, tokens);
		}
		FieldRoleClassification item = SnapshotBuilder.Classify(focusedSurfaceObservation).Classification;
		if (!SnapshotBuilder.IsEligibleForBoundedContext(focusedSurfaceObservation, item))
		{
			ReleaseSurface();
			return SnapshotBuilder.FromObservation(focusedSurfaceObservation, tokens);
		}
		if (!StillSameSurface(focusedSurfaceObservation, requireOrdinary: true))
		{
			ReleaseSurface();
			return Unresolved(tokens, ObservationStatus.Failed, "FocusChanged");
		}
		CompositionState compositionState = ReadComposition(focusedElement);
		if (compositionState == CompositionState.ActiveReported)
		{
			_tracker.Reset();
			ChangeSubscriptionResult? subscription = _subscription;
			ChangeDeliveryCounts? changeDelivery = DeliveryCounts();
			return SnapshotBuilder.FromObservation(focusedSurfaceObservation, tokens, null, compositionState, null, subscription, changeDelivery);
		}
		BoundedContextOutcome boundedContextOutcome = null;
		NativeMetadataReader.NativeSelectionResult? nativeSelection = null;
		try
		{
			if (focusedSurfaceObservation.HasTextPattern)
			{
				boundedContextOutcome = BoundedContextReader.TryRead(focusedElement, _options, _tracker, identityKey);
			}
			else if (string.Equals(focusedSurfaceObservation.ClassName, "Edit", StringComparison.Ordinal) && focusedSurfaceObservation.NativeWindowHandle != 0)
			{
				nativeSelection = _focus.ReadNativeSelection(focusedSurfaceObservation.NativeWindowHandle);
			}
		}
		catch (Exception)
		{
			boundedContextOutcome = null;
		}
		if (!StillSameSurface(focusedSurfaceObservation, requireOrdinary: true))
		{
			ReleaseSurface();
			return Unresolved(tokens, ObservationStatus.Failed, "FocusChanged");
		}
		if ((object)boundedContextOutcome != null && boundedContextOutcome.ReadSucceeded)
		{
			EnsureSubscribed(focusedElement, identityKey);
		}
		return SnapshotBuilder.FromObservation(focusedSurfaceObservation, tokens, boundedContextOutcome, compositionState, nativeSelection, _subscription, DeliveryCounts());
	}

	public static TypingEnvironmentSnapshot Unresolved(EnvironmentTokens tokens, ObservationStatus failure, string? reasonOverride = null)
	{
		var (kind, text) = failure switch
		{
			ObservationStatus.AccessDenied => (AssessmentKind.Unavailable, "AccessDenied"), 
			ObservationStatus.ElementGone => (AssessmentKind.Unavailable, "ElementGone"), 
			ObservationStatus.TimedOut => (AssessmentKind.Unknown, "ProviderTimeout"), 
			_ => (AssessmentKind.Unknown, "SurfaceUnresolved"), 
		};
		return new TypingEnvironmentSnapshot
		{
			Tokens = tokens,
			ObservedAtUtc = DateTimeOffset.UtcNow,
			CompletedTimestampHostTicks = Stopwatch.GetTimestamp(),
			IdentityStrength = IdentityStrength.None,
			SurfaceKind = SurfaceKind.Unknown,
			Role = FieldRole.Unknown,
			RoleEvidence = RoleEvidenceKind.None,
			Protection = ProtectionState.Unknown,
			Editability = Editability.Unknown,
			Composition = CompositionState.Unknown,
			Capabilities = CapabilityEvidenceSet.AllNotAttempted(),
			ContextHealth = ContextHealth.Unknown,
			TextOrderEvidence = TextOrderEvidence.Unknown,
			Assessment = new EnvironmentAssessment
			{
				Kind = kind,
				ContentReadsPermitted = false,
				ReasonCodes = ImmutableArray.Create(reasonOverride ?? text)
			}
		};
	}

	private FocusedSurfaceObservation ReadMetadata(IProbeElement focused)
	{
		ProtectionState protectionState = ReadProtection(focused);
		int[] runtimeId = Try(focused.RuntimeId, null);
		int processId = Try(focused.ProcessId, 0);
		int num = Try(focused.NativeWindowHandle, 0);
		int controlTypeId = Try(focused.ControlType, 0);
		string className = Bound(Try(focused.ClassName, string.Empty));
		string automationId = Bound(Try(focused.AutomationId, string.Empty));
		bool flag = Try(focused.HasValuePattern, fallback: false);
		bool hasTextPattern = Try(focused.HasTextPattern, fallback: false);
		bool hasTextEditPattern = Try(focused.HasTextEditPattern, fallback: false);
		Editability editability = Editability.Unknown;
		if (flag)
		{
			try
			{
				editability = (focused.ValuePatternIsReadOnly() ? Editability.ReadOnly : Editability.EditableReported);
			}
			catch (Exception)
			{
				editability = Editability.Unknown;
			}
		}
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		List<int> list3 = new List<int>();
		bool flag2 = false;
		IProbeElement probeElement = null;
		int num2 = 0;
		try
		{
			probeElement = focused.Parent();
			while (probeElement != null && num2 < _options.MaxAncestorTraversalNodes)
			{
				switch (ReadProtection(probeElement))
				{
				case ProtectionState.Protected:
					protectionState = ProtectionState.Protected;
					break;
				case ProtectionState.Unknown:
					flag2 = true;
					break;
				}
				list.Add(Bound(Try(probeElement.ClassName, string.Empty)));
				list2.Add(Try(probeElement.ControlType, 0));
				list3.Add(Try(probeElement.NativeWindowHandle, 0));
				probeElement = probeElement.Parent();
				num2++;
			}
		}
		catch (Exception)
		{
			probeElement = null;
		}
		List<int> list4 = new List<int>(list3);
		if (num == 0 && !list3.Exists((int handle) => handle != 0))
		{
			try
			{
				while (probeElement != null && num2 < _options.MaxIdentityAncestorNodes)
				{
					int num3 = Try(probeElement.NativeWindowHandle, 0);
					list4.Add(num3);
					if (num3 == 0)
					{
						probeElement = probeElement.Parent();
						num2++;
						continue;
					}
					break;
				}
			}
			catch (Exception)
			{
			}
		}
		if ((protectionState == ProtectionState.OrdinaryReported) & flag2)
		{
			protectionState = ProtectionState.Unknown;
		}
		int foregroundRootWindow = Try(_focus.GetForegroundRootWindow, 0);
		return new FocusedSurfaceObservation(IdentityResolver.Resolve(runtimeId, num, list4, foregroundRootWindow, (int handle) => Try(() => _focus.GetRootWindow(handle), 0), _options.MaxRuntimeIdLength), runtimeId, processId, num, controlTypeId, className, automationId, protectionState, editability, flag, hasTextPattern, hasTextEditPattern, list, list2, list3);
	}

	private static ProtectionState ReadProtection(IProbeElement element)
	{
		try
		{
			return element.IsPassword() ? ProtectionState.Protected : ProtectionState.OrdinaryReported;
		}
		catch (Exception)
		{
			return ProtectionState.Unknown;
		}
	}

	private bool StillSameSurface(FocusedSurfaceObservation original, bool requireOrdinary)
	{
		try
		{
			IProbeElement focusedElement = _focus.GetFocusedElement();
			if (focusedElement == null)
			{
				return false;
			}
			int[] array = focusedElement.RuntimeId();
			int[] runtimeId = original.RuntimeId;
			if (runtimeId != null && runtimeId.Length > 0 && !((ReadOnlySpan<int>)original.RuntimeId.AsSpan()).SequenceEqual((ReadOnlySpan<int>)array))
			{
				return false;
			}
			if (focusedElement.ProcessId() != original.ProcessId || focusedElement.NativeWindowHandle() != original.NativeWindowHandle)
			{
				return false;
			}
			return !requireOrdinary || !focusedElement.IsPassword();
		}
		catch (Exception)
		{
			return false;
		}
	}

	private CompositionState ReadComposition(IProbeElement focused)
	{
		try
		{
			IProbeCompositionSource probeCompositionSource = focused.OpenCompositionSource();
			if (probeCompositionSource == null)
			{
				return CompositionState.Unknown;
			}
			return probeCompositionSource.IsCompositionActive() ? CompositionState.ActiveReported : CompositionState.InactiveReported;
		}
		catch (Exception)
		{
			return CompositionState.Unknown;
		}
	}

	private void EnsureSubscribed(IProbeElement focused, string identityKey)
	{
		if (_subscriber == null)
		{
			return;
		}
		if (string.Equals(_subscribedKey, identityKey, StringComparison.Ordinal))
		{
			ChangeSubscriptionResult? subscription = _subscription;
			if (subscription.HasValue)
			{
				return;
			}
		}
		try
		{
			Volatile.Write(ref _textEventsSinceSubscribe, 0);
			Volatile.Write(ref _selectionEventsSinceSubscribe, 0);
			_subscription = _subscriber.Subscribe(focused, (ContextChangeKind kind) =>
			{
				if (kind == ContextChangeKind.Text)
				{
					Interlocked.Increment(ref _textEventsSinceSubscribe);
				}
				else
				{
					Interlocked.Increment(ref _selectionEventsSinceSubscribe);
				}
				_tracker.NoteChangeEvent();
				_onContextChanged?.Invoke(kind);
			});
			_subscribedKey = identityKey;
		}
		catch (Exception exception)
		{
			ObservationStatus observationStatus = ProbeFailureMapper.Map(exception);
			_subscription = new ChangeSubscriptionResult(observationStatus, observationStatus);
			_subscribedKey = string.Empty;
		}
	}

	private void ReleaseSurface()
	{
		_tracker.Reset();
		_subscribedKey = string.Empty;
		_subscription = null;
		try
		{
			_subscriber?.Unsubscribe();
		}
		catch (Exception)
		{
		}
	}

	private string Bound(string value)
	{
		if (value.Length > _options.MaxStructuralStringLength)
		{
			return value.Substring(0, _options.MaxStructuralStringLength);
		}
		return value;
	}

	private static T Try<T>(Func<T> read, T fallback)
	{
		try
		{
			return read();
		}
		catch (Exception)
		{
			return fallback;
		}
	}
}
public static class Program
{
	public static async Task<int> Main(string[] args)
	{
		EnvironmentObservationOptions options = EnvironmentObservationOptions.Default;
		Stream stdout;
		SemaphoreSlim writeGate;
		int result;
		await using (Stream stdin = Console.OpenStandardInput())
		{
			stdout = Console.OpenStandardOutput();
			int num;
			try
			{
				writeGate = new SemaphoreSlim(1, 1);
				try
				{
					UiaProbeFocusSource uia = null;
					UiaChangeSubscriber subscriber = null;
					try
					{
						try
						{
							uia = new UiaProbeFocusSource(options);
							subscriber = new UiaChangeSubscriber(uia.Automation);
						}
						catch (Exception)
						{
							uia = null;
							subscriber = null;
						}
						string probeExecutableVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "0.0.0";
						await WriteAsync(ProbeFrameCodec.EncodePayload(0, 0, ProbeMessageKind.Hello, new HelloPayload
						{
							ProbeExecutableVersion = probeExecutableVersion
						}, options)).ConfigureAwait(continueOnCapturedContext: false);
						ProbeFrame probeFrame = await ProbeFrameCodec.ReadFrameAsync(stdin, options, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
						int helperGeneration;
						ContextChangeTracker tracker;
						int notifyPending;
						if (probeFrame.MessageKind != ProbeMessageKind.HelloAccepted)
						{
							await Console.Error.WriteLineAsync($"ProtocolError: expected helloAccepted, got {probeFrame.MessageKind}").ConfigureAwait(continueOnCapturedContext: false);
							num = 1;
						}
						else
						{
							helperGeneration = probeFrame.HelperGeneration;
							tracker = new ContextChangeTracker(options.RawContextRetentionLimit);
							notifyPending = 0;
							ProbeOrchestrator orchestrator = ((uia == null) ? null : new ProbeOrchestrator(uia, options, tracker, subscriber, OnContextChanged));
							while (true)
							{
								ProbeFrame probeFrame2;
								try
								{
									probeFrame2 = await ProbeFrameCodec.ReadFrameAsync(stdin, options, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
								}
								catch (ProbeProtocolException ex2) when (ex2.FailureKind == ProbeProtocolFailureKind.StreamClosed)
								{
									num = 0;
									break;
								}
								switch (probeFrame2.MessageKind)
								{
								case ProbeMessageKind.Stop:
									await WriteAsync(ProbeFrameCodec.EncodePayload(helperGeneration, 0, ProbeMessageKind.Stopped, new StoppedPayload(), options)).ConfigureAwait(continueOnCapturedContext: false);
									num = 0;
									goto end_IL_03c7;
								case ProbeMessageKind.Probe:
								{
									ProbeRequestPayload probeRequestPayload = ProbeFrameCodec.DecodePayload<ProbeRequestPayload>(probeFrame2, options);
									TypingEnvironmentSnapshot snapshot = SafeProbe(orchestrator, probeRequestPayload.Tokens, probeRequestPayload.Mode);
									await WriteAsync(ProbeFrameCodec.EncodePayload(helperGeneration, probeFrame2.RequestId, ProbeMessageKind.ProbeResult, new ProbeResultPayload
									{
										Snapshot = snapshot,
										SurfaceSerial = (orchestrator?.SurfaceSerial ?? 0)
									}, options)).ConfigureAwait(continueOnCapturedContext: false);
									break;
								}
								}
								continue;
								end_IL_03c7:
								break;
							}
						}
						void OnContextChanged(ContextChangeKind kind)
						{
							if (Interlocked.Exchange(ref notifyPending, 1) != 1)
							{
								Task.Run(async () =>
								{
									_ = 1;
									try
									{
										await Task.Delay(options.TextSelectionEventCoalescing).ConfigureAwait(continueOnCapturedContext: false);
										Interlocked.Exchange(ref notifyPending, 0);
										ProbeFrame frame = ProbeFrameCodec.EncodePayload(helperGeneration, 0, ProbeMessageKind.ContextChanged, new ContextChangedPayload
										{
											Kind = kind,
											ChangeEventCount = tracker.ChangeEventCount
										}, options);
										await WriteAsync(frame).ConfigureAwait(continueOnCapturedContext: false);
									}
									catch (Exception)
									{
									}
								});
							}
						}
					}
					catch (ProbeProtocolException ex3)
					{
						await Console.Error.WriteLineAsync($"ProtocolError: {ex3.FailureKind}").ConfigureAwait(continueOnCapturedContext: false);
						num = 1;
					}
					catch (Exception ex4)
					{
						await Console.Error.WriteLineAsync("Fatal: " + ex4.GetType().Name).ConfigureAwait(continueOnCapturedContext: false);
						num = 1;
					}
					finally
					{
						subscriber?.Dispose();
						uia?.Dispose();
					}
				}
				finally
				{
					if (writeGate != null)
					{
						((IDisposable)writeGate).Dispose();
					}
				}
			}
			finally
			{
				if (stdout != null)
				{
					await stdout.DisposeAsync();
				}
			}
			result = num;
		}
		return result;
		async Task WriteAsync(ProbeFrame frame)
		{
			await writeGate.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				await ProbeFrameCodec.WriteFrameAsync(stdout, frame, options, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				writeGate.Release();
			}
		}
	}

	private static TypingEnvironmentSnapshot SafeProbe(ProbeOrchestrator? orchestrator, EnvironmentTokens tokens, ObservationMode mode)
	{
		if (orchestrator == null)
		{
			return ProbeOrchestrator.Unresolved(tokens, ObservationStatus.Failed);
		}
		try
		{
			return orchestrator.Probe(tokens, mode);
		}
		catch (Exception)
		{
			return ProbeOrchestrator.Unresolved(tokens, ObservationStatus.Failed);
		}
	}
}
public static class UIA_ControlTypeIds
{
	public const int UIA_ButtonControlTypeId = 50000;

	public const int UIA_CheckBoxControlTypeId = 50002;

	public const int UIA_EditControlTypeId = 50004;

	public const int UIA_ImageControlTypeId = 50026;

	public const int UIA_RadioButtonControlTypeId = 50013;

	public const int UIA_DocumentControlTypeId = 50030;
}
public static class SnapshotBuilder
{
	private static readonly HashSet<int> NonTextControlTypeIds = new HashSet<int> { 50000, 50002, 50026, 50013 };

	public static (FieldRoleClassification Classification, bool HasEditableSurface, bool IsPositivelyNonText) Classify(FocusedSurfaceObservation observation)
	{
		bool flag = observation.HasValuePattern || observation.HasTextPattern;
		bool flag2 = !flag && NonTextControlTypeIds.Contains(observation.ControlTypeId);
		return (Classification: FieldRoleClassifier.Classify(new TypingSurfaceStructuralFacts
		{
			Protection = observation.Protection,
			Editability = observation.Editability,
			HasEditableEditOrDocumentSurface = flag,
			IsPositivelyNonText = flag2
		}), HasEditableSurface: flag, IsPositivelyNonText: flag2);
	}

	public static bool IsEligibleForBoundedContext(FocusedSurfaceObservation observation, FieldRoleClassification classification)
	{
		if (observation.IdentityStrength == IdentityStrength.ElementScoped && observation.Protection == ProtectionState.OrdinaryReported && !classification.IsMetadataOnlySurface)
		{
			return observation.Editability == Editability.EditableReported;
		}
		return false;
	}

	public static TypingEnvironmentSnapshot FromObservation(FocusedSurfaceObservation observation, EnvironmentTokens tokens, BoundedContextOutcome? contextOutcome = null, CompositionState composition = CompositionState.Unknown, NativeMetadataReader.NativeSelectionResult? nativeSelection = null, ChangeSubscriptionResult? changeSubscription = null, ChangeDeliveryCounts? changeDelivery = null)
	{
		(FieldRoleClassification Classification, bool HasEditableSurface, bool IsPositivelyNonText) tuple = Classify(observation);
		FieldRoleClassification item = tuple.Classification;
		bool item2 = tuple.IsPositivelyNonText;
		bool flag = contextOutcome?.ReadSucceeded ?? false;
		bool hasLocalReadRoute = (object)contextOutcome != null && (contextOutcome.CaretRangeStatus != ObservationStatus.Unsupported || contextOutcome.SelectionStatus != ObservationStatus.Unsupported);
		EnvironmentAssessmentInputs environmentAssessmentInputs = new EnvironmentAssessmentInputs
		{
			Protection = observation.Protection,
			DesktopOrSessionUnavailable = false,
			IdentityStrength = observation.IdentityStrength,
			Editability = observation.Editability,
			IsPositivelyNonText = item2,
			IsMetadataOnlySurface = item.IsMetadataOnlySurface,
			Composition = composition,
			HasLocalReadRoute = hasLocalReadRoute,
			ContextHealth = (((object)contextOutcome != null && contextOutcome.ContractViolation) ? ContextHealth.Contradictory : (flag ? ((contextOutcome.Health == ContextHealth.Unknown) ? ContextHealth.ReadObserved : contextOutcome.Health) : ContextHealth.Unknown)),
			CaretOrSelectionEvidenceComplete = flag,
			SuspectedStaleOrContradictory = false
		};
		EnvironmentAssessment environmentAssessment = EnvironmentAssessmentPolicy.Assess(environmentAssessmentInputs);
		if ((object)contextOutcome != null && contextOutcome.SelectionRangeCount > 1 && !environmentAssessment.ReasonCodes.Contains("MultipleSelections"))
		{
			environmentAssessment = environmentAssessment with
			{
				ReasonCodes = environmentAssessment.ReasonCodes.Add("MultipleSelections")
			};
		}
		environmentAssessment = AppendContextReasons(environmentAssessment, observation, contextOutcome);
		return new TypingEnvironmentSnapshot
		{
			Tokens = tokens,
			ObservedAtUtc = DateTimeOffset.UtcNow,
			CompletedTimestampHostTicks = Stopwatch.GetTimestamp(),
			IdentityStrength = observation.IdentityStrength,
			SurfaceKind = ClassifySurfaceKind(observation),
			Role = item.Role,
			RoleEvidence = item.Evidence,
			RoleRuleId = item.RuleId,
			RoleCandidates = item.RoleCandidates,
			Protection = observation.Protection,
			Editability = observation.Editability,
			Composition = composition,
			Capabilities = BuildCapabilities(observation, contextOutcome, nativeSelection, changeSubscription, changeDelivery),
			ContextHealth = environmentAssessmentInputs.ContextHealth,
			TextOrderEvidence = TextOrderEvidence.Unknown,
			Assessment = environmentAssessment
		};
	}

	private static EnvironmentAssessment AppendContextReasons(EnvironmentAssessment assessment, FocusedSurfaceObservation observation, BoundedContextOutcome? outcome)
	{
		if ((object)outcome == null)
		{
			return assessment;
		}
		ImmutableArray<string> reasons = assessment.ReasonCodes;
		if (outcome.ContractViolation)
		{
			Add("ProviderContractViolation");
		}
		if (outcome.ReadFailureStatus == ObservationStatus.TimedOut)
		{
			Add("ProviderTimeout");
		}
		else if (outcome.ReadFailureStatus == ObservationStatus.AccessDenied)
		{
			Add("AccessDenied");
		}
		else if (outcome.ReadFailureStatus == ObservationStatus.ElementGone)
		{
			Add("ElementGone");
		}
		if (outcome.ChangeOutsideSampledRangePossible)
		{
			Add("ChangeOutsideSampledRangePossible");
		}
		if (outcome.ReadOnlyAttribute.State == RangeAttributeState.Mixed || outcome.AlignmentAttribute.State == RangeAttributeState.Mixed || outcome.FlowDirectionAttribute.State == RangeAttributeState.Mixed)
		{
			Add("AttributeMixed");
		}
		RangeAttributeReading readOnlyAttribute = outcome.ReadOnlyAttribute;
		if (readOnlyAttribute.State == RangeAttributeState.Value && readOnlyAttribute.Value != 0 && observation.Editability == Editability.EditableReported)
		{
			Add("ConflictingMetadata");
		}
		return assessment with
		{
			ReasonCodes = reasons
		};
		void Add(string reason)
		{
			if (!reasons.Contains(reason))
			{
				reasons = reasons.Add(reason);
			}
		}
	}

	private static CapabilityEvidence ApplyAttribute(CapabilityEvidence entry, RangeAttributeReading? reading, string source)
	{
		if (!reading.HasValue || reading.Value.State == RangeAttributeState.NotAttempted)
		{
			return entry;
		}
		return reading.Value.State switch
		{
			RangeAttributeState.Value => entry with
			{
				ReportedSupport = ReportedSupport.Supported,
				ObservationStatus = ObservationStatus.Succeeded,
				EvidenceSource = source,
				ReasonCode = "AttributeReported"
			}, 
			RangeAttributeState.Mixed => entry with
			{
				ReportedSupport = ReportedSupport.Supported,
				ObservationStatus = ObservationStatus.Succeeded,
				EvidenceSource = source,
				ReasonCode = "AttributeMixed"
			}, 
			RangeAttributeState.Unsupported => entry with
			{
				ReportedSupport = ReportedSupport.Unsupported,
				ObservationStatus = ObservationStatus.Unsupported,
				EvidenceSource = source,
				ReasonCode = "AttributeUnsupported"
			}, 
			_ => entry with
			{
				ReportedSupport = ReportedSupport.Unknown,
				ObservationStatus = ObservationStatus.Failed,
				EvidenceSource = source,
				ReasonCode = "AttributeReadFailed"
			}, 
		};
	}

	private static ReportedSupport SupportFor(ObservationStatus registration)
	{
		return registration switch
		{
			ObservationStatus.Unsupported => ReportedSupport.Unsupported, 
			ObservationStatus.Succeeded => ReportedSupport.Supported, 
			_ => ReportedSupport.Unknown, 
		};
	}

	private static CapabilityEvidence ApplyRegistration(CapabilityEvidence entry, ObservationStatus registration, string source)
	{
		return entry with
		{
			ReportedSupport = SupportFor(registration),
			ObservationStatus = registration,
			EvidenceSource = source + ".registration",
			ReasonCode = ((registration == ObservationStatus.Succeeded) ? "RegistrationOnly" : ProbeFailureMapper.ReasonCodeFor(registration))
		};
	}

	private static CapabilityEvidence ApplyDelivery(CapabilityEvidence entry, ObservationStatus registration, int delivered, string source)
	{
		if (registration != ObservationStatus.Succeeded)
		{
			return entry with
			{
				ReportedSupport = SupportFor(registration),
				ObservationStatus = ObservationStatus.NotAttempted,
				EvidenceSource = source,
				ReasonCode = ProbeFailureMapper.ReasonCodeFor(registration)
			};
		}
		if (delivered <= 0)
		{
			return entry with
			{
				ReportedSupport = ReportedSupport.Unknown,
				ObservationStatus = ObservationStatus.NotAttempted,
				EvidenceSource = source,
				ReasonCode = "NoEventsDelivered"
			};
		}
		return entry with
		{
			ReportedSupport = ReportedSupport.Supported,
			ObservationStatus = ObservationStatus.Succeeded,
			EvidenceSource = source,
			ReasonCode = "EventsDelivered"
		};
	}

	private static SurfaceKind ClassifySurfaceKind(FocusedSurfaceObservation observation)
	{
		if (string.Equals(observation.ClassName, "Edit", StringComparison.Ordinal))
		{
			return SurfaceKind.NativeEdit;
		}
		if (observation.ClassName.Contains("RICHEDIT", StringComparison.OrdinalIgnoreCase))
		{
			return SurfaceKind.NativeRichEdit;
		}
		if (observation.ControlTypeId == 50030)
		{
			return SurfaceKind.AccessibleDocument;
		}
		if (observation.ControlTypeId == 50004)
		{
			return SurfaceKind.AccessibleEdit;
		}
		return SurfaceKind.Unknown;
	}

	private static ImmutableArray<CapabilityEvidence> BuildCapabilities(FocusedSurfaceObservation observation, BoundedContextOutcome? contextOutcome, NativeMetadataReader.NativeSelectionResult? nativeSelection, ChangeSubscriptionResult? changeSubscription, ChangeDeliveryCounts? changeDelivery)
	{
		ImmutableArray<CapabilityEvidence>.Builder builder = CapabilityEvidenceSet.AllNotAttempted().ToBuilder();
		for (int i = 0; i < builder.Count; i++)
		{
			CapabilityEvidence capabilityEvidence = builder[i];
			switch (capabilityEvidence.Name)
			{
			case CapabilityName.ReadLocalContext:
				if ((object)contextOutcome != null)
				{
					builder[i] = capabilityEvidence with
					{
						ReportedSupport = (observation.HasTextPattern ? ReportedSupport.Supported : ReportedSupport.Unknown),
						ObservationStatus = (contextOutcome.ReadSucceeded ? ObservationStatus.Succeeded : ((contextOutcome.ReadFailureStatus != ObservationStatus.NotAttempted) ? contextOutcome.ReadFailureStatus : contextOutcome.CaretRangeStatus)),
						ReasonCode = (contextOutcome.ContractViolation ? "ProviderContractViolation" : ProbeFailureMapper.ReasonCodeFor(contextOutcome.ReadFailureStatus)),
						EvidenceSource = "TextPattern2"
					};
				}
				else if (observation.HasTextPattern || observation.HasValuePattern)
				{
					builder[i] = capabilityEvidence with
					{
						ReportedSupport = ReportedSupport.Supported,
						EvidenceSource = (observation.HasTextPattern ? "TextPattern" : "ValuePattern")
					};
				}
				break;
			case CapabilityName.ReadCaretRange:
				if ((object)contextOutcome != null)
				{
					builder[i] = capabilityEvidence with
					{
						ReportedSupport = (observation.HasTextPattern ? ReportedSupport.Supported : ReportedSupport.Unsupported),
						ObservationStatus = contextOutcome.CaretRangeStatus,
						EvidenceSource = "TextPattern2.GetCaretRange"
					};
				}
				break;
			case CapabilityName.ReadSelectionRanges:
				if ((object)contextOutcome != null)
				{
					builder[i] = capabilityEvidence with
					{
						ReportedSupport = (observation.HasTextPattern ? ReportedSupport.Supported : ReportedSupport.Unsupported),
						ObservationStatus = contextOutcome.SelectionStatus,
						EvidenceSource = "TextPattern.GetSelection"
					};
				}
				break;
			case CapabilityName.NativeSelectionRead:
				if (nativeSelection.HasValue)
				{
					NativeMetadataReader.NativeSelectionResult valueOrDefault = nativeSelection.GetValueOrDefault();
					builder[i] = capabilityEvidence with
					{
						ReportedSupport = ReportedSupport.Supported,
						ObservationStatus = valueOrDefault.Status,
						EvidenceSource = "EM_GETSEL"
					};
				}
				break;
			case CapabilityName.ReadParagraphDirection:
				builder[i] = ApplyAttribute(capabilityEvidence, contextOutcome?.FlowDirectionAttribute, "TextFlowDirections");
				break;
			case CapabilityName.ReadAlignment:
				builder[i] = ApplyAttribute(capabilityEvidence, contextOutcome?.AlignmentAttribute, "HorizontalTextAlignment");
				break;
			case CapabilityName.TextChangeSubscription:
				if (changeSubscription.HasValue)
				{
					builder[i] = ApplyRegistration(capabilityEvidence, changeSubscription.GetValueOrDefault().TextChanges, "UIA.TextChangedEvent");
				}
				break;
			case CapabilityName.SelectionChangeSubscription:
				if (changeSubscription.HasValue)
				{
					builder[i] = ApplyRegistration(capabilityEvidence, changeSubscription.GetValueOrDefault().SelectionChanges, "UIA.TextSelectionChangedEvent");
				}
				break;
			case CapabilityName.ObserveTextChanges:
				if (changeSubscription.HasValue)
				{
					builder[i] = ApplyDelivery(capabilityEvidence, changeSubscription.GetValueOrDefault().TextChanges, changeDelivery?.TextEvents ?? 0, "UIA.TextChangedEvent");
				}
				break;
			case CapabilityName.ObserveSelectionChanges:
				if (changeSubscription.HasValue)
				{
					builder[i] = ApplyDelivery(capabilityEvidence, changeSubscription.GetValueOrDefault().SelectionChanges, changeDelivery?.SelectionEvents ?? 0, "UIA.TextSelectionChangedEvent");
				}
				break;
			case CapabilityName.ReadCompositionState:
				if (observation.HasTextEditPattern)
				{
					builder[i] = capabilityEvidence with
					{
						ReportedSupport = ReportedSupport.Supported,
						EvidenceSource = "TextEditPattern"
					};
				}
				break;
			}
		}
		return builder.ToImmutable();
	}
}
public static class UIA_TextAttributeIds
{
	public const int UIA_HorizontalTextAlignmentAttributeId = 40009;

	public const int UIA_IsReadOnlyAttributeId = 40015;

	public const int UIA_TextFlowDirectionsAttributeId = 40028;

	public const int UIA_Text_TextChangedEventId = 20015;

	public const int UIA_Text_TextSelectionChangedEventId = 20014;
}
public sealed class UiaProbeElement : IProbeElement
{
	private readonly IUIAutomation _automation;

	internal IUIAutomationElement Element { get; }

	public UiaProbeElement(IUIAutomationElement element, IUIAutomation automation)
	{
		Element = element ?? throw new ArgumentNullException("element");
		_automation = automation ?? throw new ArgumentNullException("automation");
	}

	public bool IsPassword()
	{
		return Element.CurrentIsPassword != 0;
	}

	public int[] RuntimeId()
	{
		return Element.GetRuntimeId() ?? Array.Empty<int>();
	}

	public int ProcessId()
	{
		return Element.CurrentProcessId;
	}

	public int NativeWindowHandle()
	{
		return ((IntPtr)Element.CurrentNativeWindowHandle).ToInt32();
	}

	public int ControlType()
	{
		return Element.CurrentControlType;
	}

	public string ClassName()
	{
		return Element.CurrentClassName ?? string.Empty;
	}

	public string AutomationId()
	{
		return Element.CurrentAutomationId ?? string.Empty;
	}

	public IProbeElement? Parent()
	{
		IUIAutomationElement parentElement = _automation.ControlViewWalker.GetParentElement(Element);
		if (parentElement != null)
		{
			return new UiaProbeElement(parentElement, _automation);
		}
		return null;
	}

	public bool HasValuePattern()
	{
		return Element.GetCurrentPattern(10002) is IUIAutomationValuePattern;
	}

	public bool ValuePatternIsReadOnly()
	{
		if (!(Element.GetCurrentPattern(10002) is IUIAutomationValuePattern iUIAutomationValuePattern))
		{
			throw new NotSupportedException();
		}
		return iUIAutomationValuePattern.CurrentIsReadOnly != 0;
	}

	public bool HasTextPattern()
	{
		return Element.GetCurrentPattern(10014) is IUIAutomationTextPattern;
	}

	public bool HasTextEditPattern()
	{
		return Element.GetCurrentPattern(10032) is IUIAutomationTextEditPattern;
	}

	public IProbeTextSource? OpenTextSource()
	{
		object currentPattern = Element.GetCurrentPattern(10014);
		if (!(currentPattern is IUIAutomationTextPattern2 iUIAutomationTextPattern))
		{
			if (currentPattern is IUIAutomationTextPattern pattern)
			{
				return new UiaProbeTextSource(pattern, null, _automation);
			}
			return null;
		}
		return new UiaProbeTextSource(iUIAutomationTextPattern, iUIAutomationTextPattern, _automation);
	}

	public IProbeCompositionSource? OpenCompositionSource()
	{
		if (!(Element.GetCurrentPattern(10032) is IUIAutomationTextEditPattern pattern))
		{
			return null;
		}
		return new UiaProbeCompositionSource(pattern);
	}
}
internal sealed class UiaProbeTextSource : IProbeTextSource
{
	private readonly IUIAutomationTextPattern _pattern;

	private readonly IUIAutomationTextPattern2? _pattern2;

	private readonly IUIAutomation _automation;

	public bool SupportsCaretRange => _pattern2 != null;

	public UiaProbeTextSource(IUIAutomationTextPattern pattern, IUIAutomationTextPattern2? pattern2, IUIAutomation automation)
	{
		_pattern = pattern;
		_pattern2 = pattern2;
		_automation = automation;
	}

	public IProbeTextRange? GetCaretRange(out bool isActive)
	{
		isActive = false;
		if (_pattern2 == null)
		{
			return null;
		}
		IUIAutomationTextRange caretRange = _pattern2.GetCaretRange(out var isActive2);
		isActive = isActive2 != 0;
		if (caretRange != null)
		{
			return new UiaProbeTextRange(caretRange, _automation);
		}
		return null;
	}

	public IReadOnlyList<IProbeTextRange> GetSelection()
	{
		IUIAutomationTextRangeArray selection = _pattern.GetSelection();
		int num = selection?.Length ?? 0;
		List<IProbeTextRange> list = new List<IProbeTextRange>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(new UiaProbeTextRange(selection.GetElement(i), _automation));
		}
		return list;
	}
}
internal sealed class UiaProbeTextRange : IProbeTextRange
{
	private readonly IUIAutomationTextRange _range;

	private readonly IUIAutomation _automation;

	public UiaProbeTextRange(IUIAutomationTextRange range, IUIAutomation automation)
	{
		_range = range;
		_automation = automation;
	}

	public IProbeTextRange Clone()
	{
		return new UiaProbeTextRange(_range.Clone(), _automation);
	}

	public int MoveStartByCharacters(int count)
	{
		return _range.MoveEndpointByUnit(TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start, TextUnit.TextUnit_Character, count);
	}

	public int MoveEndByCharacters(int count)
	{
		return _range.MoveEndpointByUnit(TextPatternRangeEndpoint.TextPatternRangeEndpoint_End, TextUnit.TextUnit_Character, count);
	}

	public string GetText(int maxLength)
	{
		if (maxLength <= 0)
		{
			throw new ArgumentOutOfRangeException("maxLength");
		}
		return _range.GetText(maxLength);
	}

	public bool IsEnclosedBy(IProbeElement element)
	{
		if (!(element is UiaProbeElement uiaProbeElement))
		{
			return false;
		}
		IUIAutomationElement enclosingElement = _range.GetEnclosingElement();
		if (enclosingElement != null)
		{
			return _automation.CompareElements(enclosingElement, uiaProbeElement.Element) != 0;
		}
		return false;
	}

	public RangeAttributeReading GetAttribute(RangeAttributeKind kind)
	{
		int attr = kind switch
		{
			RangeAttributeKind.IsReadOnly => 40015, 
			RangeAttributeKind.HorizontalAlignment => 40009, 
			RangeAttributeKind.FlowDirection => 40028, 
			_ => throw new ArgumentOutOfRangeException("kind"), 
		};
		object attributeValue = _range.GetAttributeValue(attr);
		if (attributeValue == _automation.ReservedMixedAttributeValue)
		{
			return new RangeAttributeReading(RangeAttributeState.Mixed);
		}
		if (attributeValue == _automation.ReservedNotSupportedValue)
		{
			return new RangeAttributeReading(RangeAttributeState.Unsupported);
		}
		if (!(attributeValue is int value))
		{
			if (attributeValue is bool value2)
			{
				return new RangeAttributeReading(RangeAttributeState.Value, value2 ? 1 : 0);
			}
			return new RangeAttributeReading(RangeAttributeState.Failed);
		}
		return new RangeAttributeReading(RangeAttributeState.Value, value);
	}
}
internal sealed class UiaProbeCompositionSource : IProbeCompositionSource
{
	private readonly IUIAutomationTextEditPattern _pattern;

	public UiaProbeCompositionSource(IUIAutomationTextEditPattern pattern)
	{
		_pattern = pattern;
	}

	public bool IsCompositionActive()
	{
		IUIAutomationTextRange activeComposition = _pattern.GetActiveComposition();
		if (activeComposition == null)
		{
			return false;
		}
		return !string.IsNullOrEmpty(activeComposition.GetText(1));
	}
}
public sealed class UiaProbeFocusSource : IProbeFocusSource, IDisposable
{
	private const uint GaRoot = 2u;

	private readonly IUIAutomation2 _automation;

	private readonly EnvironmentObservationOptions _options;

	internal IUIAutomation Automation => _automation;

	[DllImport("user32.dll")]
	private static extern nint GetForegroundWindow();

	[DllImport("user32.dll")]
	private static extern nint GetAncestor(nint hwnd, uint flags);

	public UiaProbeFocusSource(EnvironmentObservationOptions options)
	{
		_options = options;
		_automation = new CUIAutomation8Class();
		try
		{
			_automation.AutoSetFocus = 0;
		}
		catch (COMException)
		{
		}
		try
		{
			_automation.ConnectionTimeout = (uint)options.UiaConnectionTimeout.TotalMilliseconds;
			_automation.TransactionTimeout = (uint)options.UiaTransactionTimeout.TotalMilliseconds;
		}
		catch (COMException)
		{
		}
	}

	public IProbeElement? GetFocusedElement()
	{
		IUIAutomationElement focusedElement = _automation.GetFocusedElement();
		if (focusedElement != null)
		{
			return new UiaProbeElement(focusedElement, _automation);
		}
		return null;
	}

	public int GetForegroundRootWindow()
	{
		nint foregroundWindow = GetForegroundWindow();
		if (foregroundWindow != IntPtr.Zero)
		{
			return ((IntPtr)foregroundWindow).ToInt32();
		}
		return 0;
	}

	public int GetRootWindow(int windowHandle)
	{
		if (windowHandle == 0)
		{
			return 0;
		}
		nint ancestor = GetAncestor(new IntPtr(windowHandle), 2u);
		if (ancestor != IntPtr.Zero)
		{
			return ((IntPtr)ancestor).ToInt32();
		}
		return 0;
	}

	public NativeMetadataReader.NativeSelectionResult ReadNativeSelection(int windowHandle)
	{
		return NativeMetadataReader.TryGetSelection(new IntPtr(windowHandle), _options);
	}

	public void Dispose()
	{
		try
		{
			Marshal.FinalReleaseComObject(_automation);
		}
		catch (Exception)
		{
		}
	}
}
public sealed class UiaChangeSubscriber : IProbeChangeSubscriber, IDisposable
{
	private sealed class Handler : IUIAutomationEventHandler
	{
		private readonly ContextChangeKind _kind;

		public Action<ContextChangeKind>? Callback { get; set; }

		public Handler(ContextChangeKind kind)
		{
			_kind = kind;
		}

		public void HandleAutomationEvent(IUIAutomationElement sender, int eventId)
		{
			Callback?.Invoke(_kind);
		}
	}

	private readonly IUIAutomation _automation;

	private readonly Handler _textHandler;

	private readonly Handler _selectionHandler;

	private IUIAutomationElement? _subscribed;

	public UiaChangeSubscriber(IUIAutomation automation)
	{
		_automation = automation ?? throw new ArgumentNullException("automation");
		_textHandler = new Handler(ContextChangeKind.Text);
		_selectionHandler = new Handler(ContextChangeKind.Selection);
	}

	public ChangeSubscriptionResult Subscribe(IProbeElement element, Action<ContextChangeKind> onChange)
	{
		ArgumentNullException.ThrowIfNull(element, "element");
		ArgumentNullException.ThrowIfNull(onChange, "onChange");
		Unsubscribe();
		if (!(element is UiaProbeElement uiaProbeElement))
		{
			return new ChangeSubscriptionResult(ObservationStatus.Unsupported, ObservationStatus.Unsupported);
		}
		_textHandler.Callback = onChange;
		_selectionHandler.Callback = onChange;
		ObservationStatus textChanges = TryAdd(20015, uiaProbeElement.Element, _textHandler);
		ObservationStatus selectionChanges = TryAdd(20014, uiaProbeElement.Element, _selectionHandler);
		_subscribed = uiaProbeElement.Element;
		return new ChangeSubscriptionResult(textChanges, selectionChanges);
	}

	public void Unsubscribe()
	{
		IUIAutomationElement subscribed = _subscribed;
		_subscribed = null;
		_textHandler.Callback = null;
		_selectionHandler.Callback = null;
		if (subscribed != null)
		{
			TryRemove(20015, subscribed, _textHandler);
			TryRemove(20014, subscribed, _selectionHandler);
		}
	}

	public void Dispose()
	{
		Unsubscribe();
	}

	private ObservationStatus TryAdd(int eventId, IUIAutomationElement element, Handler handler)
	{
		try
		{
			_automation.AddAutomationEventHandler(eventId, element, TreeScope.TreeScope_Element, null, handler);
			return ObservationStatus.Succeeded;
		}
		catch (Exception exception)
		{
			return ProbeFailureMapper.Map(exception);
		}
	}

	private void TryRemove(int eventId, IUIAutomationElement element, Handler handler)
	{
		try
		{
			_automation.RemoveAutomationEventHandler(eventId, element, handler);
		}
		catch (Exception)
		{
		}
	}
}
