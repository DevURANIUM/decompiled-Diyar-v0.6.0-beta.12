using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Automation.Text;
using Microsoft.Win32;
using SmartInput.Core.Diagnostics;
using SmartInput.Core.Environments;
using SmartInput.Core.Environments.Protocol;
using SmartInput.Core.Settings;
using SmartInput.Core.Text;
using SmartInput.Core.Text.Localization;
using SmartInput.Windows.Environments.Interop;
using SmartInput.Windows.Hooks;
using SmartInput.Windows.Input;
using SmartInput.Windows.Interop;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("SmartInput.Windows.Tests")]
[assembly: TargetFramework(".NETCoreApp,Version=v10.0", FrameworkDisplayName = ".NET 10.0")]
[assembly: AssemblyCompany("SmartInput.Windows")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("0.6.302.37")]
[assembly: AssemblyInformationalVersion("0.6.0-beta.12+1067fa6d75b7fbb34a023a09c9716a95d6187838")]
[assembly: AssemblyProduct("SmartInput.Windows")]
[assembly: AssemblyTitle("SmartInput.Windows")]
[assembly: InternalsVisibleTo("SmartInput.App.Tests")]
[assembly: TargetPlatform("Windows7.0")]
[assembly: SupportedOSPlatform("Windows7.0")]
[assembly: AssemblyVersion("0.6.0.0")]
[module: RefSafetyRules(11)]
[CompilerGenerated]
internal sealed class <>z__ReadOnlyArray<T> : IEnumerable, ICollection, IList, IEnumerable<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection<T>, IList<T>
{
	[CompilerGenerated]
	private readonly T[] _items;

	int ICollection.Count => _items.Length;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	object? IList.this[int index]
	{
		get
		{
			return _items[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	bool IList.IsFixedSize => true;

	bool IList.IsReadOnly => true;

	int IReadOnlyCollection<T>.Count => _items.Length;

	T IReadOnlyList<T>.this[int index] => _items[index];

	int ICollection<T>.Count => _items.Length;

	bool ICollection<T>.IsReadOnly => true;

	T IList<T>.this[int index]
	{
		get
		{
			return _items[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public <>z__ReadOnlyArray(T[] items)
	{
		_items = items;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)_items).GetEnumerator();
	}

	void ICollection.CopyTo(Array array, int index)
	{
		((ICollection)_items).CopyTo(array, index);
	}

	int IList.Add(object? value)
	{
		throw new NotSupportedException();
	}

	void IList.Clear()
	{
		throw new NotSupportedException();
	}

	bool IList.Contains(object? value)
	{
		return ((IList)_items).Contains(value);
	}

	int IList.IndexOf(object? value)
	{
		return ((IList)_items).IndexOf(value);
	}

	void IList.Insert(int index, object? value)
	{
		throw new NotSupportedException();
	}

	void IList.Remove(object? value)
	{
		throw new NotSupportedException();
	}

	void IList.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return ((IEnumerable<T>)_items).GetEnumerator();
	}

	void ICollection<T>.Add(T item)
	{
		throw new NotSupportedException();
	}

	void ICollection<T>.Clear()
	{
		throw new NotSupportedException();
	}

	bool ICollection<T>.Contains(T item)
	{
		return ((ICollection<T>)_items).Contains(item);
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		((ICollection<T>)_items).CopyTo(array, arrayIndex);
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	int IList<T>.IndexOf(T item)
	{
		return ((IList<T>)_items).IndexOf(item);
	}

	void IList<T>.Insert(int index, T item)
	{
		throw new NotSupportedException();
	}

	void IList<T>.RemoveAt(int index)
	{
		throw new NotSupportedException();
	}
}
namespace System.Text.RegularExpressions.Generated
{
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__ProtocolErrorLine_0 : Regex
	{
		private sealed class RunnerFactory : RegexRunnerFactory
		{
			private sealed class Runner : RegexRunner
			{
				protected override void Scan(ReadOnlySpan<char> inputSpan)
				{
					if (TryFindNextPossibleStartingPosition(inputSpan) && !TryMatchAtCurrentPosition(inputSpan))
					{
						runtextpos = inputSpan.Length;
					}
				}

				private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
				{
					int num = runtextpos;
					if (num <= inputSpan.Length - 27 && num == 0)
					{
						return true;
					}
					runtextpos = inputSpan.Length;
					return false;
				}

				private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
				{
					int num = runtextpos;
					int start = num;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						UncaptureUntil(0);
						return false;
					}
					if (!span.StartsWith("ProtocolError: "))
					{
						UncaptureUntil(0);
						return false;
					}
					num += 15;
					span = inputSpan.Slice(num);
					num5 = num;
					num4 = num;
					num3 = Crawlpos();
					if (!span.StartsWith("InvalidLength"))
					{
						goto IL_008a;
					}
					num2 = 0;
					num += 13;
					span = inputSpan.Slice(num);
					goto IL_0279;
					IL_008a:
					num = num4;
					span = inputSpan.Slice(num);
					UncaptureUntil(num3);
					if (!span.StartsWith("TruncatedFrame"))
					{
						goto IL_00c7;
					}
					num2 = 1;
					num += 14;
					span = inputSpan.Slice(num);
					goto IL_0279;
					IL_00c7:
					num = num4;
					span = inputSpan.Slice(num);
					UncaptureUntil(num3);
					if (!span.StartsWith("OversizedPayload"))
					{
						goto IL_0104;
					}
					num2 = 2;
					num += 16;
					span = inputSpan.Slice(num);
					goto IL_0279;
					IL_0141:
					num = num4;
					span = inputSpan.Slice(num);
					UncaptureUntil(num3);
					if (!span.StartsWith("InvalidEnumValue"))
					{
						goto IL_017e;
					}
					num2 = 4;
					num += 16;
					span = inputSpan.Slice(num);
					goto IL_0279;
					IL_0279:
					while (true)
					{
						Capture(1, num5, num);
						if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
						{
							if (<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							switch (num2)
							{
							case 0:
								break;
							case 1:
								goto IL_00c7;
							case 2:
								goto IL_0104;
							case 3:
								goto IL_0141;
							case 4:
								goto IL_017e;
							case 5:
								goto IL_01bb;
							case 6:
								goto IL_01f8;
							case 7:
								UncaptureUntil(0);
								return false;
							default:
								continue;
							}
							break;
						}
						runtextpos = num;
						Capture(0, start, num);
						return true;
					}
					goto IL_008a;
					IL_0104:
					num = num4;
					span = inputSpan.Slice(num);
					UncaptureUntil(num3);
					if (!span.StartsWith("MalformedJson"))
					{
						goto IL_0141;
					}
					num2 = 3;
					num += 13;
					span = inputSpan.Slice(num);
					goto IL_0279;
					IL_01f8:
					num = num4;
					span = inputSpan.Slice(num);
					UncaptureUntil(num3);
					if (!span.StartsWith("StreamClosed"))
					{
						UncaptureUntil(0);
						return false;
					}
					num2 = 7;
					num += 12;
					span = inputSpan.Slice(num);
					goto IL_0279;
					IL_01bb:
					num = num4;
					span = inputSpan.Slice(num);
					UncaptureUntil(num3);
					if (!span.StartsWith("UnsupportedProtocolVersion"))
					{
						goto IL_01f8;
					}
					num2 = 6;
					num += 26;
					span = inputSpan.Slice(num);
					goto IL_0279;
					IL_017e:
					num = num4;
					span = inputSpan.Slice(num);
					UncaptureUntil(num3);
					if (!span.StartsWith("ExceedsMaxDepth"))
					{
						goto IL_01bb;
					}
					num2 = 5;
					num += 15;
					span = inputSpan.Slice(num);
					goto IL_0279;
					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					void UncaptureUntil(int capturePosition)
					{
						while (Crawlpos() > capturePosition)
						{
							Uncapture();
						}
					}
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__ProtocolErrorLine_0 Instance = new <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__ProtocolErrorLine_0();

		private <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__ProtocolErrorLine_0()
		{
			pattern = "^ProtocolError: (InvalidLength|TruncatedFrame|OversizedPayload|MalformedJson|InvalidEnumValue|ExceedsMaxDepth|UnsupportedProtocolVersion|StreamClosed)$";
			roptions = RegexOptions.None;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 2;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__UnexpectedFrameLine_1 : Regex
	{
		private sealed class RunnerFactory : RegexRunnerFactory
		{
			private sealed class Runner : RegexRunner
			{
				protected override void Scan(ReadOnlySpan<char> inputSpan)
				{
					if (TryFindNextPossibleStartingPosition(inputSpan) && !TryMatchAtCurrentPosition(inputSpan))
					{
						runtextpos = inputSpan.Length;
					}
				}

				private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
				{
					int num = runtextpos;
					if (num <= inputSpan.Length - 47 && num == 0)
					{
						return true;
					}
					runtextpos = inputSpan.Length;
					return false;
				}

				private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
				{
					int num = runtextpos;
					int start = num;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int pos = 0;
					int num6 = 0;
					int num7 = 0;
					int num8 = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						UncaptureUntil(0);
						return false;
					}
					if (!span.StartsWith("ProtocolError: expected helloAccepted, got "))
					{
						UncaptureUntil(0);
						return false;
					}
					num += 43;
					span = inputSpan.Slice(num);
					num2 = num;
					if (span.IsEmpty)
					{
						UncaptureUntil(0);
						return false;
					}
					switch (span[0])
					{
					case 'H':
						if (!span.Slice(1).StartsWith("ello"))
						{
							UncaptureUntil(0);
							return false;
						}
						num += 5;
						span = inputSpan.Slice(num);
						num6 = pos;
						num3 = 0;
						do
						{
							<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
							num3++;
							if (span.StartsWith("Accepted"))
							{
								num += 8;
								span = inputSpan.Slice(num);
								continue;
							}
							if (--num3 < 0)
							{
								UncaptureUntil(0);
								return false;
							}
							num = runstack[--pos];
							UncaptureUntil(runstack[--pos]);
							span = inputSpan.Slice(num);
							break;
						}
						while (num3 == 0);
						pos = num6;
						break;
					case 'P':
						if (!span.Slice(1).StartsWith("robe"))
						{
							UncaptureUntil(0);
							return false;
						}
						num += 5;
						span = inputSpan.Slice(num);
						num7 = pos;
						num4 = 0;
						do
						{
							<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
							num4++;
							if (span.StartsWith("Result"))
							{
								num += 6;
								span = inputSpan.Slice(num);
								continue;
							}
							if (--num4 < 0)
							{
								UncaptureUntil(0);
								return false;
							}
							num = runstack[--pos];
							UncaptureUntil(runstack[--pos]);
							span = inputSpan.Slice(num);
							break;
						}
						while (num4 == 0);
						pos = num7;
						break;
					case 'I':
						if (!span.Slice(1).StartsWith("nvalidate"))
						{
							UncaptureUntil(0);
							return false;
						}
						num += 10;
						span = inputSpan.Slice(num);
						break;
					case 'S':
						if (!span.Slice(1).StartsWith("top"))
						{
							UncaptureUntil(0);
							return false;
						}
						num += 4;
						span = inputSpan.Slice(num);
						num8 = pos;
						num5 = 0;
						do
						{
							<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.StackPush(ref runstack, ref pos, Crawlpos(), num);
							num5++;
							if (span.StartsWith("ped"))
							{
								num += 3;
								span = inputSpan.Slice(num);
								continue;
							}
							if (--num5 < 0)
							{
								UncaptureUntil(0);
								return false;
							}
							num = runstack[--pos];
							UncaptureUntil(runstack[--pos]);
							span = inputSpan.Slice(num);
							break;
						}
						while (num5 == 0);
						pos = num8;
						break;
					case 'C':
						if (!span.Slice(1).StartsWith("ontextChanged"))
						{
							UncaptureUntil(0);
							return false;
						}
						num += 14;
						span = inputSpan.Slice(num);
						break;
					default:
						UncaptureUntil(0);
						return false;
					}
					Capture(1, num2, num);
					if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
					{
						UncaptureUntil(0);
						return false;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					void UncaptureUntil(int capturePosition)
					{
						while (Crawlpos() > capturePosition)
						{
							Uncapture();
						}
					}
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__UnexpectedFrameLine_1 Instance = new <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__UnexpectedFrameLine_1();

		private <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__UnexpectedFrameLine_1()
		{
			pattern = "^ProtocolError: expected helloAccepted, got (Hello|HelloAccepted|Probe|ProbeResult|Invalidate|Stop|Stopped|ContextChanged)$";
			roptions = RegexOptions.None;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 2;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__FatalLine_2 : Regex
	{
		private sealed class RunnerFactory : RegexRunnerFactory
		{
			private sealed class Runner : RegexRunner
			{
				protected override void Scan(ReadOnlySpan<char> inputSpan)
				{
					if (TryFindNextPossibleStartingPosition(inputSpan) && !TryMatchAtCurrentPosition(inputSpan))
					{
						runtextpos = inputSpan.Length;
					}
				}

				private bool TryFindNextPossibleStartingPosition(ReadOnlySpan<char> inputSpan)
				{
					int num = runtextpos;
					if (num <= inputSpan.Length - 17 && num == 0)
					{
						return true;
					}
					runtextpos = inputSpan.Length;
					return false;
				}

				private bool TryMatchAtCurrentPosition(ReadOnlySpan<char> inputSpan)
				{
					int num = runtextpos;
					int start = num;
					int num2 = 0;
					int num3 = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					if (!span.StartsWith("Fatal: "))
					{
						return false;
					}
					num += 7;
					span = inputSpan.Slice(num);
					num2 = num;
					int i;
					for (i = 0; i < 60 && (uint)i < (uint)span.Length && char.IsAsciiLetter(span[i]); i++)
					{
					}
					if (i == 0)
					{
						return false;
					}
					span = span.Slice(i);
					num += i;
					num3 = num;
					num2++;
					while (!span.StartsWith("Exception") || 10 < span.Length || (9 < span.Length && span[9] != '\n'))
					{
						if (<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 >= num3 || (num3 = inputSpan.Slice(num2, Math.Min(inputSpan.Length, num3 + 8) - num2).LastIndexOf("Exception")) < 0)
						{
							return false;
						}
						num3 += num2;
						num = num3;
						span = inputSpan.Slice(num);
					}
					Capture(0, start, runtextpos = num + 9);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__FatalLine_2 Instance = new <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__FatalLine_2();

		private <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__FatalLine_2()
		{
			pattern = "^Fatal: [A-Za-z]{1,60}Exception$";
			roptions = RegexOptions.None;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal static class <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__Utilities
	{
		internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

		internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void StackPush(ref int[] stack, ref int pos, int arg0, int arg1)
		{
			int[] array = stack;
			int num = pos;
			if ((uint)(num + 1) < (uint)array.Length)
			{
				array[num] = arg0;
				array[num + 1] = arg1;
				pos += 2;
			}
			else
			{
				WithResize(ref stack, ref pos, arg0, arg1);
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			static void WithResize(ref int[] reference, ref int reference2, int arg2, int arg3)
			{
				Array.Resize(ref reference, (reference2 + 1) * 2);
				StackPush(ref reference, ref reference2, arg2, arg3);
			}
		}
	}
}
namespace SmartInput.Windows.Layouts
{
	public enum ActiveLanguage
	{
		Unknown,
		English,
		Persian
	}
	public class ForegroundLayoutService
	{
		private const int LayoutChangeConfirmationAttempts = 8;

		private const int LayoutChangeConfirmationDelayMs = 10;

		public string? PreferredEnglishKlid { get; set; }

		public string? PreferredPersianKlid { get; set; }

		public ActiveLanguage GetActiveLanguage()
		{
			return GetActiveLayout().Language;
		}

		public virtual KeyboardLayoutSnapshot GetActiveLayout()
		{
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return default;
			}
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(foregroundWindow, out var lpdwProcessId);
			if (windowThreadProcessId == 0)
			{
				return default;
			}
			NativeMethods.GUITHREADINFO lpgui = new NativeMethods.GUITHREADINFO
			{
				cbSize = (uint)Marshal.SizeOf<NativeMethods.GUITHREADINFO>()
			};
			if (NativeMethods.GetGUIThreadInfo(windowThreadProcessId, ref lpgui) && lpgui.hwndFocus != IntPtr.Zero)
			{
				windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(lpgui.hwndFocus, out lpdwProcessId);
			}
			nint keyboardLayout = NativeMethods.GetKeyboardLayout(windowThreadProcessId);
			return new KeyboardLayoutSnapshot(KeyboardLayoutInventory.LanguageOf(keyboardLayout), keyboardLayout);
		}

		public KeyboardLayoutSnapshot GetCounterpartLayout(ActiveLanguage sourceLanguage, PersianKeyboardLayout preferredPersianLayout = PersianKeyboardLayout.Automatic)
		{
			ActiveLanguage activeLanguage = sourceLanguage switch
			{
				ActiveLanguage.English => ActiveLanguage.Persian, 
				ActiveLanguage.Persian => ActiveLanguage.English, 
				_ => ActiveLanguage.Unknown, 
			};
			if (activeLanguage != ActiveLanguage.Unknown)
			{
				return GetInstalledLayout(activeLanguage, preferredPersianLayout);
			}
			return default;
		}

		public virtual KeyboardLayoutSnapshot GetInstalledLayout(ActiveLanguage language, PersianKeyboardLayout preferredPersianLayout = PersianKeyboardLayout.Automatic)
		{
			KeyboardLayoutPair keyboardLayoutPair = KeyboardLayoutInventory.ResolvePair(KeyboardLayoutInventory.GetInstalled(), PreferredEnglishKlid, PreferredPersianKlid, preferredPersianLayout);
			InstalledKeyboardLayout installedKeyboardLayout = language switch
			{
				ActiveLanguage.English => keyboardLayoutPair.English, 
				ActiveLanguage.Persian => keyboardLayoutPair.Persian, 
				_ => null, 
			};
			if ((object)installedKeyboardLayout != null)
			{
				return new KeyboardLayoutSnapshot(language, installedKeyboardLayout.Handle);
			}
			return default;
		}

		public bool TryRequestForegroundLayout(ActiveLanguage language, PersianKeyboardLayout preferredPersianLayout = PersianKeyboardLayout.Automatic, bool waitForConfirmation = true)
		{
			return TryRequestForegroundLayout(GetInstalledLayout(language, preferredPersianLayout), waitForConfirmation);
		}

		public virtual bool TryRequestForegroundLayout(KeyboardLayoutSnapshot layout, bool waitForConfirmation = true)
		{
			if (layout.Handle == IntPtr.Zero)
			{
				return false;
			}
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return false;
			}
			nint num = foregroundWindow;
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(foregroundWindow, out var lpdwProcessId);
			if (windowThreadProcessId == 0)
			{
				return false;
			}
			NativeMethods.GUITHREADINFO lpgui = new NativeMethods.GUITHREADINFO
			{
				cbSize = (uint)Marshal.SizeOf<NativeMethods.GUITHREADINFO>()
			};
			if (NativeMethods.GetGUIThreadInfo(windowThreadProcessId, ref lpgui) && lpgui.hwndFocus != IntPtr.Zero)
			{
				num = lpgui.hwndFocus;
				windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(num, out lpdwProcessId);
			}
			if (IsLayoutActive(num, layout.Handle))
			{
				return true;
			}
			bool flag = NativeMethods.PostMessage(num, 80u, IntPtr.Zero, layout.Handle);
			if (foregroundWindow != num)
			{
				flag |= NativeMethods.PostMessage(foregroundWindow, 80u, IntPtr.Zero, layout.Handle);
			}
			if (!flag || !waitForConfirmation)
			{
				return flag;
			}
			for (int i = 0; i < 8; i++)
			{
				Thread.Sleep(10);
				if (IsLayoutActive(num, layout.Handle))
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsLayoutActive(nint targetWindow, nint expectedLayout)
		{
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(targetWindow, out var _);
			if (windowThreadProcessId != 0)
			{
				return NativeMethods.GetKeyboardLayout(windowThreadProcessId) == expectedLayout;
			}
			return false;
		}
	}
	public sealed record InstalledKeyboardLayout(nint Handle, string Klid, ActiveLanguage Language, string DisplayName)
	{
		public PersianKeyboardLayout? PersianVariant
		{
			get
			{
				string text = Klid.ToUpperInvariant();
				if (!(text == "00050429"))
				{
					if (text == "00000429")
					{
						return PersianKeyboardLayout.Persian;
					}
					return null;
				}
				return PersianKeyboardLayout.PersianStandard;
			}
		}
	}
	public sealed record KeyboardLayoutPair(InstalledKeyboardLayout? English, InstalledKeyboardLayout? Persian)
	{
		public bool HasEnglish => (object)English != null;

		public bool HasPersian => (object)Persian != null;
	}
	public sealed record InstallableKeyboardLayout(string LanguageId, string Klid, MessageKey Name)
	{
		public string DisplayName => MessageText.Get(Name);

		public string InputProfile => LanguageId + ":" + Klid;
	}
	public static class KeyboardLayoutInventory
	{
		public const string PersianStandardKlid = "00050429";

		public const string PersianLegacyKlid = "00000429";

		public const string EnglishUsKlid = "00000409";

		private const string LayoutsKey = "SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts";

		private static readonly TimeSpan CacheLifetime = TimeSpan.FromSeconds(5L);

		private static readonly object Gate = new object();

		private static IReadOnlyList<InstalledKeyboardLayout> _cached = Array.Empty<InstalledKeyboardLayout>();

		private static DateTime _cachedAtUtc = DateTime.MinValue;

		public static IReadOnlyList<InstallableKeyboardLayout> InstallablePersian { get; } = new <>z__ReadOnlyArray<InstallableKeyboardLayout>(new InstallableKeyboardLayout[2]
		{
			new InstallableKeyboardLayout("0429", "00050429", MessageKey.LayoutPersianStandard),
			new InstallableKeyboardLayout("0429", "00000429", MessageKey.LayoutPersian)
		});

		public static IReadOnlyList<InstallableKeyboardLayout> InstallableEnglish { get; } = new <>z__ReadOnlyArray<InstallableKeyboardLayout>(new InstallableKeyboardLayout[2]
		{
			new InstallableKeyboardLayout("0409", "00000409", MessageKey.LayoutEnglishUs),
			new InstallableKeyboardLayout("0409", "00020409", MessageKey.LayoutEnglishUsInternational)
		});

		public static IReadOnlyList<InstalledKeyboardLayout> GetInstalled(bool refresh = false)
		{
			lock (Gate)
			{
				if (!refresh && DateTime.UtcNow - _cachedAtUtc < CacheLifetime)
				{
					return _cached;
				}
				DiagnosticJournal? journal = DiagnosticLog.Journal;
				long startTimestamp = journal?.Timestamp ?? 0;
				_cached = ReadInstalled();
				journal?.RecordDuration("layout.inventory.refresh@" + (Thread.CurrentThread.Name ?? "unnamed"), startTimestamp);
				_cachedAtUtc = DateTime.UtcNow;
				return _cached;
			}
		}

		public static KeyboardLayoutPair ResolvePair(IReadOnlyList<InstalledKeyboardLayout> installed, string? preferredEnglishKlid, string? preferredPersianKlid, PersianKeyboardLayout mappingSetting = PersianKeyboardLayout.Automatic)
		{
			InstalledKeyboardLayout? english = Pick(installed, ActiveLanguage.English, preferredEnglishKlid, (InstalledKeyboardLayout layout) => (!string.Equals(layout.Klid, "00000409", StringComparison.OrdinalIgnoreCase)) ? 1 : 0);
			InstalledKeyboardLayout persian = Pick(installed, ActiveLanguage.Persian, preferredPersianKlid, (InstalledKeyboardLayout layout) => (mappingSetting == PersianKeyboardLayout.Automatic || layout.PersianVariant != mappingSetting) ? ((layout.PersianVariant == PersianKeyboardLayout.PersianStandard) ? 1 : ((!layout.PersianVariant.HasValue) ? 3 : 2)) : 0);
			return new KeyboardLayoutPair(english, persian);
		}

		public static PersianKeyboardLayout ResolveMapping(PersianKeyboardLayout setting, InstalledKeyboardLayout? defaultPersian)
		{
			if (setting == PersianKeyboardLayout.Automatic)
			{
				return (defaultPersian?.PersianVariant).GetValueOrDefault();
			}
			return setting;
		}

		public static bool TryInstall(InstallableKeyboardLayout layout, out string message)
		{
			try
			{
				if (!NativeMethods.InstallLayoutOrTip(layout.InputProfile, 0u))
				{
					message = MessageText.Format(MessageKey.LayoutNotInstalledByWindows, layout.DisplayName);
					return false;
				}
			}
			catch (Exception ex) when ((ex is DllNotFoundException || ex is EntryPointNotFoundException) ? true : false)
			{
				message = MessageText.Format(MessageKey.LayoutInstallUnsupported, layout.DisplayName);
				return false;
			}
			bool flag = GetInstalled(refresh: true).Any((InstalledKeyboardLayout candidate) => string.Equals(candidate.Klid, layout.Klid, StringComparison.OrdinalIgnoreCase));
			message = (flag ? MessageText.Format(MessageKey.LayoutInstalled, layout.DisplayName) : MessageText.Format(MessageKey.LayoutAddedAfterSignIn, layout.DisplayName));
			return true;
		}

		public static ActiveLanguage LanguageOf(nint handle)
		{
			return ((int)(((IntPtr)handle).ToInt64() & 0xFFFF) & 0x3FF) switch
			{
				41 => ActiveLanguage.Persian, 
				9 => ActiveLanguage.English, 
				_ => ActiveLanguage.Unknown, 
			};
		}

		internal static string KlidOf(nint handle, Func<int, string?> layoutIdLookup)
		{
			long num = ((IntPtr)handle).ToInt64();
			int num2 = (int)(num & 0xFFFF);
			int num3 = (int)((num >> 16) & 0xFFFF);
			if ((num3 & 0xF000) == 61440)
			{
				return layoutIdLookup(num3 & 0xFFF) ?? $"0000{num2:X4}";
			}
			if (num3 != num2 && num3 != 0)
			{
				return $"{num3:X4}{num2:X4}";
			}
			return $"0000{num2:X4}";
		}

		private static InstalledKeyboardLayout? Pick(IReadOnlyList<InstalledKeyboardLayout> installed, ActiveLanguage language, string? preferredKlid, Func<InstalledKeyboardLayout, int> rank)
		{
			List<InstalledKeyboardLayout> source = installed.Where((InstalledKeyboardLayout layout) => layout.Language == language).ToList();
			if (!string.IsNullOrWhiteSpace(preferredKlid))
			{
				InstalledKeyboardLayout installedKeyboardLayout = source.FirstOrDefault((InstalledKeyboardLayout layout) => string.Equals(layout.Klid, preferredKlid, StringComparison.OrdinalIgnoreCase));
				if ((object)installedKeyboardLayout != null)
				{
					return installedKeyboardLayout;
				}
			}
			return source.OrderBy(rank).FirstOrDefault();
		}

		private static IReadOnlyList<InstalledKeyboardLayout> ReadInstalled()
		{
			int keyboardLayoutList = NativeMethods.GetKeyboardLayoutList(0, Array.Empty<nint>());
			if (keyboardLayoutList <= 0)
			{
				return Array.Empty<InstalledKeyboardLayout>();
			}
			nint[] array = new nint[keyboardLayoutList];
			int keyboardLayoutList2 = NativeMethods.GetKeyboardLayoutList(array.Length, array);
			Lazy<Dictionary<int, string>> layoutIds = new Lazy<Dictionary<int, string>>(ReadLayoutIds);
			return array.Take(Math.Max(0, keyboardLayoutList2)).Select((nint handle) =>
			{
				string klid = KlidOf(handle, (int id) => layoutIds.Value.GetValueOrDefault(id));
				return new InstalledKeyboardLayout(handle, klid, LanguageOf(handle), DisplayNameOf(klid));
			}).ToList();
		}

		private static Dictionary<int, string> ReadLayoutIds()
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			try
			{
				using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts");
				string[] array = registryKey?.GetSubKeyNames() ?? Array.Empty<string>();
				foreach (string text in array)
				{
					using RegistryKey registryKey2 = registryKey.OpenSubKey(text);
					if (registryKey2?.GetValue("Layout Id") is string s && int.TryParse(s, NumberStyles.HexNumber, null, out var result))
					{
						dictionary[result] = text.ToUpperInvariant();
					}
				}
			}
			catch (Exception ex) when ((ex is SecurityException || ex is UnauthorizedAccessException || ex is IOException) ? true : false)
			{
			}
			return dictionary;
		}

		private static string DisplayNameOf(string klid)
		{
			try
			{
				using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts\\" + klid);
				if (registryKey?.GetValue("Layout Display Name") is string text && text.StartsWith('@'))
				{
					StringBuilder stringBuilder = new StringBuilder(256);
					if (NativeMethods.SHLoadIndirectString(text, stringBuilder, stringBuilder.Capacity, IntPtr.Zero) == 0)
					{
						return stringBuilder.ToString();
					}
				}
				if (registryKey?.GetValue("Layout Text") is string { Length: >0 } text2)
				{
					return text2;
				}
			}
			catch (Exception ex) when ((ex is SecurityException || ex is UnauthorizedAccessException || ex is IOException || ex is COMException) ? true : false)
			{
			}
			return klid;
		}
	}
	public readonly record struct KeyboardLayoutSnapshot(ActiveLanguage Language, nint Handle)
	{
		public bool IsKnown
		{
			get
			{
				if (Language != ActiveLanguage.Unknown)
				{
					return Handle != IntPtr.Zero;
				}
				return false;
			}
		}
	}
	public sealed class KeyboardLayoutTextService
	{
		private const int PersianLangId = 1065;

		private const uint LegacyPersianLayout = 69796905u;

		private static readonly IReadOnlyDictionary<int, char> EnglishMap = new Dictionary<int, char>
		{
			[81] = 'q',
			[87] = 'w',
			[69] = 'e',
			[82] = 'r',
			[84] = 't',
			[89] = 'y',
			[85] = 'u',
			[73] = 'i',
			[79] = 'o',
			[80] = 'p',
			[65] = 'a',
			[83] = 's',
			[68] = 'd',
			[70] = 'f',
			[71] = 'g',
			[72] = 'h',
			[74] = 'j',
			[75] = 'k',
			[76] = 'l',
			[90] = 'z',
			[88] = 'x',
			[67] = 'c',
			[86] = 'v',
			[66] = 'b',
			[78] = 'n',
			[77] = 'm',
			[219] = '[',
			[221] = ']',
			[186] = ';',
			[222] = '\'',
			[188] = ',',
			[190] = '.',
			[191] = '/'
		};

		private static readonly IReadOnlyDictionary<int, char> PersianStandardMap = new Dictionary<int, char>
		{
			[81] = 'ض',
			[87] = 'ص',
			[69] = 'ث',
			[82] = 'ق',
			[84] = 'ف',
			[89] = 'غ',
			[85] = 'ع',
			[73] = 'ه',
			[79] = 'خ',
			[80] = 'ح',
			[65] = 'ش',
			[83] = 'س',
			[68] = 'ی',
			[70] = 'ب',
			[71] = 'ل',
			[72] = 'ا',
			[74] = 'ت',
			[75] = 'ن',
			[76] = 'م',
			[90] = 'ظ',
			[88] = 'ط',
			[67] = 'ز',
			[86] = 'ر',
			[66] = 'ذ',
			[78] = 'د',
			[77] = 'پ',
			[219] = 'ج',
			[221] = 'چ',
			[186] = 'ک',
			[222] = 'گ',
			[188] = 'و',
			[190] = '.',
			[191] = '/'
		};

		private static readonly IReadOnlyDictionary<int, char> PersianLegacyMap = new Dictionary<int, char>(PersianStandardMap)
		{
			[77] = 'ئ',
			[220] = 'پ'
		};

		public bool TryRender(IReadOnlyList<int> virtualKeys, KeyboardLayoutSnapshot layout, out string text)
		{
			text = string.Empty;
			if (!layout.IsKnown || virtualKeys.Count == 0)
			{
				return false;
			}
			IReadOnlyDictionary<int, char> map = GetMap(layout);
			if (map == null)
			{
				return false;
			}
			char[] array = new char[virtualKeys.Count];
			for (int i = 0; i < virtualKeys.Count; i++)
			{
				if (!map.TryGetValue(virtualKeys[i], out array[i]))
				{
					return false;
				}
			}
			text = new string(array);
			return true;
		}

		private static IReadOnlyDictionary<int, char>? GetMap(KeyboardLayoutSnapshot layout)
		{
			if (layout.Language == ActiveLanguage.English)
			{
				return EnglishMap;
			}
			if (layout.Language != ActiveLanguage.Persian)
			{
				return null;
			}
			uint num = (uint)((IntPtr)layout.Handle).ToInt64();
			if ((num & 0xFFFF) != 1065)
			{
				return null;
			}
			if (num != 69796905)
			{
				return PersianStandardMap;
			}
			return PersianLegacyMap;
		}
	}
}
namespace SmartInput.Windows.Interop
{
	internal static class NativeMethods
	{
		internal struct MSG
		{
			public nint Hwnd;

			public uint Message;

			public nint WParam;

			public nint LParam;

			public uint Time;

			public int PointX;

			public int PointY;
		}

		internal delegate nint LowLevelKeyboardProc(int nCode, nint wParam, nint lParam);

		internal delegate nint SubclassProc(nint hWnd, uint msg, nint wParam, nint lParam, nuint subclassId, nuint referenceData);

		internal struct GUITHREADINFO
		{
			public uint cbSize;

			public uint flags;

			public nint hwndActive;

			public nint hwndFocus;

			public nint hwndCapture;

			public nint hwndMenuOwner;

			public nint hwndMoveSize;

			public nint hwndCaret;

			public RECT rcCaret;
		}

		internal struct RECT
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;
		}

		internal struct KBDLLHOOKSTRUCT
		{
			public uint VkCode;

			public uint ScanCode;

			public uint Flags;

			public uint Time;

			public nuint DwExtraInfo;
		}

		internal struct INPUT
		{
			public uint type;

			public InputUnion U;
		}

		[StructLayout(LayoutKind.Explicit)]
		internal struct InputUnion
		{
			[FieldOffset(0)]
			public MOUSEINPUT mi;

			[FieldOffset(0)]
			public KEYBDINPUT ki;

			[FieldOffset(0)]
			public HARDWAREINPUT hi;
		}

		internal struct MOUSEINPUT
		{
			public int dx;

			public int dy;

			public uint mouseData;

			public uint dwFlags;

			public uint time;

			public nuint dwExtraInfo;
		}

		internal struct KEYBDINPUT
		{
			public ushort wVk;

			public ushort wScan;

			public uint dwFlags;

			public uint time;

			public nuint dwExtraInfo;
		}

		internal struct HARDWAREINPUT
		{
			public uint uMsg;

			public ushort wParamL;

			public ushort wParamH;
		}

		internal const int WhKeyboardLl = 13;

		internal const int WhMouseLl = 14;

		internal const int WmLButtonDown = 513;

		internal const int WmRButtonDown = 516;

		internal const int WmMButtonDown = 519;

		internal const int WmXButtonDown = 523;

		internal const int WmKeyDown = 256;

		internal const int WmKeyUp = 257;

		internal const int WmSysKeyDown = 260;

		internal const int WmSysKeyUp = 261;

		internal const int WmInputLanguageChangeRequest = 80;

		internal const int LlkhfInjected = 16;

		internal const uint InputKeyboard = 1u;

		internal const uint KeyeventfExtendedkey = 1u;

		internal const uint KeyeventfKeyup = 2u;

		internal const uint KeyeventfUnicode = 4u;

		internal const uint KeyeventfScancode = 8u;

		internal static readonly nuint SmartInputInjectedInputMarker = new UIntPtr(1397313104u);

		internal const int LlkhfExtended = 1;

		internal const uint WmQuit = 18u;

		internal const uint PmNoRemove = 0u;

		internal const int VkPacket = 231;

		internal const uint WmQueryEndSession = 17u;

		internal const uint WmEndSession = 22u;

		internal const uint WmNcDestroy = 130u;

		internal const long EndSessionCloseApp = 1L;

		internal const uint RestartNoCrash = 1u;

		internal const uint RestartNoHang = 2u;

		internal const uint RestartNoReboot = 8u;

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		internal static extern nint SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, nint hMod, uint dwThreadId);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool UnhookWindowsHookEx(nint hhk);

		[DllImport("user32.dll")]
		internal static extern int GetMessage(out MSG message, nint window, uint filterMin, uint filterMax);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool PeekMessage(out MSG message, nint window, uint filterMin, uint filterMax, uint remove);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool TranslateMessage(ref MSG message);

		[DllImport("user32.dll")]
		internal static extern nint DispatchMessage(ref MSG message);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool PostThreadMessage(uint threadId, uint message, nint wParam, nint lParam);

		[DllImport("kernel32.dll")]
		internal static extern uint GetCurrentThreadId();

		[DllImport("user32.dll")]
		internal static extern uint InSendMessageEx(nint reserved);

		[DllImport("user32.dll")]
		internal static extern nint CallNextHookEx(nint hhk, int nCode, nint wParam, nint lParam);

		[DllImport("user32.dll")]
		internal static extern nint GetForegroundWindow();

		[DllImport("user32.dll")]
		internal static extern uint GetWindowThreadProcessId(nint hWnd, out uint lpdwProcessId);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool GetGUIThreadInfo(uint idThread, ref GUITHREADINFO lpgui);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool PostMessage(nint hWnd, uint msg, nint wParam, nint lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		internal static extern nint SendMessage(nint hWnd, uint msg, nint wParam, string lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		internal static extern int GetClassName(nint hWnd, StringBuilder className, int maxCount);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		internal static extern int GetWindowText(nint hWnd, StringBuilder text, int maxCount);

		[DllImport("user32.dll")]
		internal static extern nint GetKeyboardLayout(uint idThread);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int GetKeyboardLayoutList(int nBuff, nint[] lpList);

		[DllImport("user32.dll")]
		internal static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, nint dwhkl);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern int ToUnicodeEx(uint wVirtKey, uint wScanCode, byte[] lpKeyState, [Out][MarshalAs(UnmanagedType.LPWStr)] char[] pwszBuff, int cchBuff, uint wFlags, nint dwhkl);

		[DllImport("user32.dll", SetLastError = true)]
		internal static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool RegisterHotKey(nint hWnd, int id, uint fsModifiers, uint vk);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool UnregisterHotKey(nint hWnd, int id);

		[DllImport("user32.dll")]
		internal static extern short GetAsyncKeyState(int virtualKey);

		[DllImport("user32.dll", EntryPoint = "SendMessageW")]
		internal static extern nint SendMessage(nint hWnd, uint msg, nint wParam, nint lParam);

		[DllImport("comctl32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool SetWindowSubclass(nint hWnd, SubclassProc subclassProc, nuint subclassId, nuint referenceData);

		[DllImport("comctl32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool RemoveWindowSubclass(nint hWnd, SubclassProc subclassProc, nuint subclassId);

		[DllImport("comctl32.dll")]
		internal static extern nint DefSubclassProc(nint hWnd, uint msg, nint wParam, nint lParam);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		internal static extern int RegisterApplicationRestart(string commandLine, uint flags);

		[DllImport("input.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool InstallLayoutOrTip(string profile, uint flags);

		[DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
		internal static extern int SHLoadIndirectString(string source, StringBuilder output, int outputSize, nint reserved);
	}
}
namespace SmartInput.Windows.Input
{
	public static class BidiControlCharacters
	{
		private enum StrongDirection
		{
			Unknown,
			LeftToRight,
			RightToLeft
		}

		public const char LeftToRightMark = '\u200e';

		public const char RightToLeftMark = '\u200f';

		public const char RightToLeftEmbedding = '\u202b';

		public const char PopDirectionalFormatting = '\u202c';

		public const char LeftToRightIsolate = '\u2066';

		public const char RightToLeftIsolate = '\u2067';

		public const char PopDirectionalIsolate = '\u2069';

		public const int MaximumRewrittenParagraphPrefixLength = 200;

		public static bool IsDirectionControl(char value)
		{
			return ParagraphDirectionPolicy.IsDirectionMark(value);
		}

		public static bool EndsWithPrecedingText(string textBeforeCaret, string precedingText)
		{
			string text = RemoveDirectionControls(precedingText);
			if (text.Length == 0)
			{
				return false;
			}
			string text2 = RemoveDirectionControls(textBeforeCaret);
			if (text2.Length > 0)
			{
				if (!text2.EndsWith(text, StringComparison.OrdinalIgnoreCase))
				{
					if (text2.Length >= 2)
					{
						return text.EndsWith(text2, StringComparison.OrdinalIgnoreCase);
					}
					return false;
				}
				return true;
			}
			return false;
		}

		private static string RemoveDirectionControls(string value)
		{
			if (!value.Any(IsDirectionControl))
			{
				return value;
			}
			return new string(value.Where((char c) => !IsDirectionControl(c)).ToArray());
		}

		public static string StartRightToLeftEmbedding(string value)
		{
			if (!value.StartsWith('\u202b'))
			{
				return "\u202b" + value;
			}
			return value;
		}

		public static bool CanPromoteParagraphToRightToLeft(string paragraphPrefix, string source)
		{
			if (source.Length == 0 || paragraphPrefix.Length < source.Length || !paragraphPrefix.EndsWith(source, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			return true;
		}

		public static bool CanRewriteParagraphPrefix(string paragraphPrefix, string source)
		{
			if (paragraphPrefix.Length < source.Length)
			{
				return false;
			}
			ReadOnlySpan<char> span = paragraphPrefix.AsSpan(0, paragraphPrefix.Length - source.Length);
			if (span.Length <= 200)
			{
				return !span.Contains('￼');
			}
			return false;
		}

		public static string RemoveLeadingRightToLeftEmbedding(string value)
		{
			if (!value.StartsWith('\u202b'))
			{
				return value;
			}
			return value.Substring(1);
		}

		public static string RemoveParagraphStabilization(string value)
		{
			return RemoveLeadingRightToLeftEmbedding(value.StartsWith("\u200f\u202b", StringComparison.Ordinal) ? value.Substring("\u200f\u202b".Length) : value).Replace('\u200e'.ToString(), string.Empty, StringComparison.Ordinal);
		}

		public static string StabilizeTerminalLeftToRightPunctuation(string value)
		{
			if (value.Length == 0)
			{
				return value;
			}
			StringBuilder stringBuilder = new StringBuilder(value.Length + 2);
			StrongDirection strongDirection = StrongDirection.Unknown;
			for (int i = 0; i < value.Length; i++)
			{
				char c = value[i];
				stringBuilder.Append(c);
				if (IsLatinLetter(c))
				{
					strongDirection = StrongDirection.LeftToRight;
				}
				else if (IsPersianLetter(c))
				{
					strongDirection = StrongDirection.RightToLeft;
				}
				else if (strongDirection == StrongDirection.LeftToRight && IsTerminalAsciiPunctuation(c) && IsRunBoundary(value, i + 1) && (i + 1 >= value.Length || value[i + 1] != '\u200e'))
				{
					stringBuilder.Append('\u200e');
				}
			}
			return stringBuilder.ToString();
		}

		public static string AppendLeftToRightMark(string punctuation)
		{
			if (!punctuation.EndsWith('\u200e'))
			{
				return punctuation + "\u200e";
			}
			return punctuation;
		}

		public static string Isolate(string value, bool rightToLeft)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value;
			}
			int i;
			for (i = 0; i < value.Length && char.IsWhiteSpace(value[i]); i++)
			{
			}
			int num = value.Length - 1;
			while (num >= i && char.IsWhiteSpace(value[num]))
			{
				num--;
			}
			if (i > num)
			{
				return value;
			}
			char c = (rightToLeft ? '\u2067' : '\u2066');
			string[] array = new string[5]
			{
				value.Substring(0, i),
				c.ToString(),
				null,
				null,
				null
			};
			int num2 = i;
			array[2] = value.Substring(num2, num + 1 - num2);
			array[3] = "\u2069";
			array[4] = value.Substring(num + 1);
			return string.Concat(array);
		}

		public static string Remove(string value)
		{
			return value.Replace('\u200e'.ToString(), string.Empty, StringComparison.Ordinal).Replace('\u200f'.ToString(), string.Empty, StringComparison.Ordinal).Replace('\u202b'.ToString(), string.Empty, StringComparison.Ordinal)
				.Replace('\u202c'.ToString(), string.Empty, StringComparison.Ordinal)
				.Replace('\u2066'.ToString(), string.Empty, StringComparison.Ordinal)
				.Replace('\u2067'.ToString(), string.Empty, StringComparison.Ordinal)
				.Replace('\u2069'.ToString(), string.Empty, StringComparison.Ordinal);
		}

		private static bool IsTerminalAsciiPunctuation(char character)
		{
			switch (character)
			{
			case '!':
			case '%':
			case ',':
			case '.':
			case ':':
			case ';':
			case '?':
				return true;
			default:
				return false;
			}
		}

		private static bool IsRunBoundary(string value, int index)
		{
			if (index >= value.Length)
			{
				return true;
			}
			bool flag = char.IsWhiteSpace(value[index]);
			if (!flag)
			{
				bool flag2;
				switch (value[index])
				{
				case ')':
				case '>':
				case ']':
				case '}':
					flag2 = true;
					break;
				default:
					flag2 = false;
					break;
				}
				flag = flag2;
			}
			return flag;
		}

		private static bool IsLatinLetter(char character)
		{
			switch (character)
			{
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
			case 'G':
			case 'H':
			case 'I':
			case 'J':
			case 'K':
			case 'L':
			case 'M':
			case 'N':
			case 'O':
			case 'P':
			case 'Q':
			case 'R':
			case 'S':
			case 'T':
			case 'U':
			case 'V':
			case 'W':
			case 'X':
			case 'Y':
			case 'Z':
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
				return true;
			default:
				return false;
			}
		}

		private static bool IsPersianLetter(char character)
		{
			if (character >= '\u0600' && character <= 'ۿ')
			{
				return char.IsLetter(character);
			}
			return false;
		}
	}
	public sealed record EditorCapabilities(bool NativeEdit = false, bool TextPattern = false, bool OffsetsAreStored = false, bool PaintedOrder = false, bool FindsOwnText = false, bool ConfirmsSelection = false, bool StaleText = false)
	{
		public bool ShouldRetryOffsetReads
		{
			get
			{
				if (!PaintedOrder)
				{
					return !StaleText;
				}
				return false;
			}
		}

		public string Summary => $"nativeEdit={NativeEdit} textPattern={TextPattern} offsetsStored={OffsetsAreStored} paintedOrder={PaintedOrder} findsOwnText={FindsOwnText} confirmsSelection={ConfirmsSelection} staleText={StaleText}";
	}
	public static class EditorCapabilityStore
	{
		private static readonly ConcurrentDictionary<string, EditorCapabilities> Known = new ConcurrentDictionary<string, EditorCapabilities>(StringComparer.Ordinal);

		public static IReadOnlyDictionary<string, EditorCapabilities> All => Known;

		public static string Key(string app, string windowClass)
		{
			return app + "|" + windowClass;
		}

		public static EditorCapabilities For(string key)
		{
			if (!Known.TryGetValue(key, out EditorCapabilities value))
			{
				return new EditorCapabilities();
			}
			return value;
		}

		public static EditorCapabilities Learn(string key, Func<EditorCapabilities, EditorCapabilities> observe)
		{
			return Known.AddOrUpdate(key, (string _) => observe(new EditorCapabilities()), (string _, EditorCapabilities current) => observe(current));
		}

		public static void Observe(string key, Func<EditorCapabilities, EditorCapabilities> observe, string evidence = "", string? word = null, string? editorText = null)
		{
			EditorCapabilities editorCapabilities = For(key);
			EditorCapabilities editorCapabilities2 = Learn(key, observe);
			if (editorCapabilities2 == editorCapabilities || !DiagnosticLog.IsEnabled)
			{
				return;
			}
			DiagnosticJournal journal = DiagnosticLog.Journal;
			if (journal != null)
			{
				journal.Event("capability", "editor", key, "changed", DescribeChange(editorCapabilities, editorCapabilities2), "now", editorCapabilities2.Summary, "evidence", (evidence.Length > 0) ? evidence : "(not stated by the caller)", "word", (word == null) ? "-" : DiagnosticLog.Tail(word, 40), "editorText", (editorText == null) ? "-" : DiagnosticLog.Tail(editorText));
				journal.Tally("capability.changed");
				journal.TallyFact("capabilities " + key, editorCapabilities2.Summary);
			}
			else
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(10, 2, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendFormatted(key);
					message.AppendLiteral(" learned: ");
					message.AppendFormatted(editorCapabilities2.Summary);
				}
				DiagnosticLog.Write("Target", ref message);
			}
		}

		internal static string DescribeChange(EditorCapabilities before, EditorCapabilities after)
		{
			List<string> changes = new List<string>(7);
			Compare("nativeEdit", before.NativeEdit, after.NativeEdit);
			Compare("textPattern", before.TextPattern, after.TextPattern);
			Compare("offsetsStored", before.OffsetsAreStored, after.OffsetsAreStored);
			Compare("paintedOrder", before.PaintedOrder, after.PaintedOrder);
			Compare("findsOwnText", before.FindsOwnText, after.FindsOwnText);
			Compare("confirmsSelection", before.ConfirmsSelection, after.ConfirmsSelection);
			Compare("staleText", before.StaleText, after.StaleText);
			if (changes.Count != 0)
			{
				return string.Join(", ", changes);
			}
			return "none";
			void Compare(string name, bool old, bool now)
			{
				if (old != now)
				{
					changes.Add($"{name} {old}->{now}");
				}
			}
		}

		internal static void Clear()
		{
			Known.Clear();
		}
	}
	public static class EnglishOnlyApplicationRoute
	{
		private sealed record Answer(nint Window, uint ProcessId, nint Foreground, uint ForegroundProcessId, EnglishOnlyApplicationMatch? Match);

		private static Answer? _last;

		public static string? Classify(string? processName, string? windowClass)
		{
			return KindOf(Identify(processName, windowClass));
		}

		public static string? ClassifyProcess(string? processName)
		{
			return KindOf(EnglishOnlyPlaces.ApplicationForProcess(processName));
		}

		public static EnglishOnlyPlace? Identify(string? processName, string? windowClass)
		{
			return EnglishOnlyPlaces.ApplicationForProcess(processName) ?? EnglishOnlyPlaces.ApplicationForWindowClass(windowClass);
		}

		public static string? KindOf(EnglishOnlyPlace? place)
		{
			return place?.Group switch
			{
				EnglishOnlyPlaceGroup.Terminal => "terminal", 
				EnglishOnlyPlaceGroup.Launcher => "launcher", 
				EnglishOnlyPlaceGroup.DatabaseTool => "database tool", 
				EnglishOnlyPlaceGroup.RemoteDesktop => "remote desktop", 
				EnglishOnlyPlaceGroup.PasswordManager => "password manager", 
				_ => null, 
			};
		}

		public static EnglishOnlyApplicationMatch? Focused()
		{
			nint num = UnicodeBatchLossRoute.FocusedWindow();
			if (num == IntPtr.Zero)
			{
				return null;
			}
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			NativeMethods.GetWindowThreadProcessId(num, out var lpdwProcessId);
			uint lpdwProcessId2 = 0u;
			if (foregroundWindow != IntPtr.Zero)
			{
				NativeMethods.GetWindowThreadProcessId(foregroundWindow, out lpdwProcessId2);
			}
			Answer answer = Volatile.Read(in _last);
			if ((object)answer != null && answer.Window == num && answer.ProcessId == lpdwProcessId && answer.Foreground == foregroundWindow && answer.ForegroundProcessId == lpdwProcessId2)
			{
				return answer.Match;
			}
			string text = UnicodeBatchLossRoute.ProcessNameOf(num);
			EnglishOnlyPlace englishOnlyPlace = Identify(text, UnicodeBatchLossRoute.ClassNameOf(num));
			if ((object)englishOnlyPlace == null && foregroundWindow != IntPtr.Zero && lpdwProcessId2 != lpdwProcessId)
			{
				text = UnicodeBatchLossRoute.ProcessNameOf(foregroundWindow);
				englishOnlyPlace = EnglishOnlyPlaces.ApplicationForProcess(text);
			}
			EnglishOnlyApplicationMatch englishOnlyApplicationMatch = (((object)englishOnlyPlace == null) ? null : new EnglishOnlyApplicationMatch(englishOnlyPlace.Id, KindOf(englishOnlyPlace) + " (" + ((text.Length > 0) ? text : "by window class") + ")"));
			Volatile.Write(ref _last, new Answer(num, lpdwProcessId, foregroundWindow, lpdwProcessId2, englishOnlyApplicationMatch));
			return englishOnlyApplicationMatch;
		}
	}
	public sealed record EnglishOnlyApplicationMatch(string PlaceId, string Description);
	public sealed class GlobalHotkeyRegistrar
	{
		private const int VkShift = 16;

		private const int VkControl = 17;

		private const int VkMenu = 18;

		private const int VkLeftWindows = 91;

		private const int VkRightWindows = 92;

		private readonly nint _windowHandle;

		public GlobalHotkeyRegistrar(nint windowHandle)
		{
			_windowHandle = windowHandle;
		}

		public bool Register(int id, uint modifiers, uint virtualKey)
		{
			return NativeMethods.RegisterHotKey(_windowHandle, id, modifiers, virtualKey);
		}

		public void Unregister(int id)
		{
			NativeMethods.UnregisterHotKey(_windowHandle, id);
		}

		public static bool AreShortcutModifiersReleased()
		{
			if (!IsPressed(16) && !IsPressed(17) && !IsPressed(18) && !IsPressed(91))
			{
				return !IsPressed(92);
			}
			return false;
		}

		private static bool IsPressed(int virtualKey)
		{
			return (NativeMethods.GetAsyncKeyState(virtualKey) & 0x8000) != 0;
		}
	}
	public static class HardwareKeyboardAutocorrect
	{
		public static readonly string[] SettingsKeys = new string[2] { "Software\\Microsoft\\Input\\Settings", "Software\\Microsoft\\TabletTip\\1.7" };

		private const long RefreshMilliseconds = 30000L;

		private static readonly object Gate = new object();

		private static bool _read;

		private static bool _on;

		private static long _readAt;

		public static bool IsOn()
		{
			lock (Gate)
			{
				return !_read || _on;
			}
		}

		public static string Describe()
		{
			lock (Gate)
			{
				string result;
				if (_read)
				{
					result = (_on ? "on" : "off");
				}
				else
				{
					result = "not read yet";
				}
				return result;
			}
		}

		public static void RefreshIfStale()
		{
			long tickCount = Environment.TickCount64;
			lock (Gate)
			{
				if (_read && tickCount - _readAt < 30000)
				{
					return;
				}
			}
			bool flag = ReadFromRegistry();
			lock (Gate)
			{
				_on = flag;
				_read = true;
				_readAt = tickCount;
			}
		}

		public static bool Evaluate(IEnumerable<KeyValuePair<string, object?>> values)
		{
			return values.Any((KeyValuePair<string, object> value) =>
			{
				bool flag = value.Key.StartsWith("EnableHwkbAutocorrection", StringComparison.OrdinalIgnoreCase);
				if (flag)
				{
					object value2 = value.Value;
					bool flag2 = ((value2 is int num) ? (num != 0) : ((value2 is long num2) ? (num2 != 0) : (value2 is string s && int.TryParse(s, out var result) && result != 0)));
					flag = flag2;
				}
				return flag;
			});
		}

		public static bool IsPerLanguageSubkeyPath(string relativePath)
		{
			string[] array = relativePath.Split('\\');
			if (array.Length == 3 && array[0].StartsWith("proc_", StringComparison.OrdinalIgnoreCase) && array[1].StartsWith("loc_", StringComparison.OrdinalIgnoreCase))
			{
				return array[2].StartsWith("im_", StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		private static bool ReadFromRegistry()
		{
			string[] settingsKeys = SettingsKeys;
			foreach (string name in settingsKeys)
			{
				try
				{
					using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(name);
					if (registryKey != null && (IsOnIn(registryKey) || IsOnInPerLanguageSubkeys(registryKey)))
					{
						return true;
					}
				}
				catch (Exception ex) when ((ex is SecurityException || ex is UnauthorizedAccessException || ex is IOException) ? true : false)
				{
				}
			}
			return false;
		}

		private static bool IsOnIn(RegistryKey key)
		{
			return Evaluate(from name in key.GetValueNames()
				select new KeyValuePair<string, object>(name, key.GetValue(name)));
		}

		private static bool IsOnInPerLanguageSubkeys(RegistryKey settings)
		{
			foreach (string item in from name in settings.GetSubKeyNames()
				where name.StartsWith("proc_", StringComparison.OrdinalIgnoreCase)
				select name)
			{
				using RegistryKey registryKey = settings.OpenSubKey(item);
				if (registryKey == null)
				{
					continue;
				}
				foreach (string item2 in from name in registryKey.GetSubKeyNames()
					where name.StartsWith("loc_", StringComparison.OrdinalIgnoreCase)
					select name)
				{
					using RegistryKey registryKey2 = registryKey.OpenSubKey(item2);
					if (registryKey2 == null)
					{
						continue;
					}
					string[] subKeyNames = registryKey2.GetSubKeyNames();
					foreach (string text in subKeyNames)
					{
						if (!IsPerLanguageSubkeyPath($"{item}\\{item2}\\{text}"))
						{
							continue;
						}
						using RegistryKey registryKey3 = registryKey2.OpenSubKey(text);
						if (registryKey3 != null && IsOnIn(registryKey3))
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}
	public interface IInputInjector
	{
		int LastSendInputError { get; }

		string LastReplacementSource { get; }

		string LastReplacementTarget { get; }

		bool LastReplacementStartedRightToLeftEmbedding { get; }

		string LastFocusRestoreDiagnostic { get; }

		string LastParagraphCaptureDiagnostic { get; }

		bool LastReplacementContradictedEditor { get; }

		bool HasOpenSelection { get; }

		Func<bool>? ShouldAbandonReplacement { get; set; }

		bool EditorTextIsKnownStale { get; }

		bool InjectedInputAhead => InjectedInputOrder.IsAhead;

		bool WithoutAutomation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool ProtectPaymentFields
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool ProtectAddressBars
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		bool ProtectWebAddressFields
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		bool ReplacePreviousToken(string source, string replacement, ushort? trailingVirtualKey = null, bool setRightToLeft = false, string? trailingText = null, bool paragraphIsRightToLeft = false, bool startRightToLeftEmbedding = false, bool paragraphHasRightToLeftEmbedding = false, bool removeRightToLeftEmbedding = false, bool releaseActiveModifiers = false, bool requireExactSourceMatch = false, string precedingText = "", bool useKeyBuffer = false);

		bool CollapseOpenSelection(bool preferKeyboard = false);

		void ForgetLastReplacementRefusal();

		void LogTypingTargetWhenItChanges();

		void ObserveStaleEditorText();

		bool IsReadUntrustedForRewrite(string text)
		{
			return false;
		}

		bool FocusedEditorLosesUnicodeBatches()
		{
			return false;
		}

		ParagraphDirectionHost FocusedParagraphDirectionHost()
		{
			return ParagraphDirectionHost.None;
		}

		bool FocusedEditorKeepsAsciiDigits()
		{
			return false;
		}

		EnglishOnlyApplicationMatch? FocusedEnglishOnlyApplication()
		{
			return null;
		}

		bool SendKeyAndResetParagraphDirection(ushort? trailingVirtualKey)
		{
			return false;
		}

		bool SendTextThenKey(string text, ushort trailingVirtualKey)
		{
			return false;
		}

		bool HardwareKeyboardAutocorrectIsOn()
		{
			return false;
		}

		void RefreshHardwareKeyboardAutocorrect()
		{
		}

		bool ReplayKeyEvents(IReadOnlyList<KeyboardEvent> keys)
		{
			NativeMethods.INPUT[] array = InjectedInputOrder.BuildReplay(keys);
			return InjectedInputOrder.Send(array) == array.Length;
		}

		TypingTargetFacts? DescribeTargetForJournal()
		{
			return null;
		}

		long GetForegroundTargetIdentity();

		long GetFocusedElementIdentity();

		long GetForegroundWindowIdentity();

		bool TryGetCurrentParagraphPrefixText(string source, out string paragraphPrefix);

		bool TryReadParagraphPrefixWithTrace(out string paragraphPrefix, out ParagraphReadTrace? trace)
		{
			trace = null;
			return TryGetCurrentParagraphPrefixText(string.Empty, out paragraphPrefix);
		}

		bool IsProtectedTechnicalField();

		bool IsProtectedTechnicalField(out string checkedControlType)
		{
			checkedControlType = string.Empty;
			return IsProtectedTechnicalField();
		}

		bool TryReplaceExactTextBeforeCaret(string expected, string replacement, Func<bool>? writeOverSelection = null)
		{
			return false;
		}

		bool CompleteRightToLeftEmbeddingAndSend(ushort trailingVirtualKey);

		bool SendUnicodeText(string text);

		bool TryDeletePreviousTextExact(string text);

		bool ReplaceSelectedText(string replacement);

		bool SelectionCoversCurrentParagraph();

		bool TryGetSelectedText(out string selectedText);

		bool IsSelectedTextUnchanged(string expectedText);

		bool TryGetCurrentEditableText(out string editableText);

		bool TrySelectCurrentEditableText(string expectedText);

		bool TryRestoreTextFocusAfterMenuActivation();

		bool TryGetCurrentParagraphText(out string paragraphText);

		bool TrySelectCurrentParagraphText(string expectedText);

		bool ApplyParagraphDirection(bool rightToLeft);

		bool SendControlShortcutWithoutActiveModifiers(ushort key);
	}
	public static class InjectedInputOrder
	{
		private const long StaleAfterMilliseconds = 500L;

		private static int _inFlight;

		private static long _lastSentAt;

		public static bool IsAhead
		{
			get
			{
				if (Volatile.Read(in _inFlight) <= 0)
				{
					return false;
				}
				if (Environment.TickCount64 - Volatile.Read(in _lastSentAt) > 500)
				{
					Interlocked.Exchange(ref _inFlight, 0);
					return false;
				}
				return true;
			}
		}

		public static void Observed()
		{
			int num;
			do
			{
				num = Volatile.Read(in _inFlight);
			}
			while (num > 0 && Interlocked.CompareExchange(ref _inFlight, num - 1, num) != num);
		}

		internal static uint Send(NativeMethods.INPUT[] inputs)
		{
			if (inputs.Length == 0)
			{
				return 0u;
			}
			Interlocked.Add(ref _inFlight, inputs.Length);
			Volatile.Write(ref _lastSentAt, Environment.TickCount64);
			uint num = NativeMethods.SendInput((uint)inputs.Length, inputs, Marshal.SizeOf<NativeMethods.INPUT>());
			if (num < inputs.Length)
			{
				Interlocked.Add(ref _inFlight, -(inputs.Length - (int)num));
			}
			return num;
		}

		internal static NativeMethods.INPUT[] BuildReplay(IReadOnlyList<KeyboardEvent> keys)
		{
			NativeMethods.INPUT[] array = new NativeMethods.INPUT[keys.Count];
			for (int i = 0; i < keys.Count; i++)
			{
				KeyboardEvent keyboardEvent = keys[i];
				uint num = ((!keyboardEvent.IsKeyDown) ? 2u : 0u);
				ushort wVk = (ushort)keyboardEvent.VirtualKey;
				if (keyboardEvent.VirtualKey == 231)
				{
					num |= 4;
					wVk = 0;
				}
				else if (keyboardEvent.IsExtended)
				{
					num |= 1;
				}
				array[i] = new NativeMethods.INPUT
				{
					type = 1u,
					U = new NativeMethods.InputUnion
					{
						ki = new NativeMethods.KEYBDINPUT
						{
							wVk = wVk,
							wScan = (ushort)keyboardEvent.ScanCode,
							dwFlags = num,
							time = 0u,
							dwExtraInfo = NativeMethods.SmartInputInjectedInputMarker
						}
					}
				};
			}
			return array;
		}
	}
	public sealed class InputInjector : IInputInjector
	{
		internal enum PreviousTextSelection
		{
			Selected,
			Unreadable,
			Mismatch,
			ConfirmedNotSelectable,
			Lagging
		}

		private readonly record struct ForegroundLayoutContext(nint TargetWindow, nint TopLevelWindow, nint KeyboardLayout, bool IsEnglish);

		private const ushort VkControl = 17;

		private const ushort VkShift = 16;

		private const ushort VkAlt = 18;

		private const ushort VkBack = 8;

		private const ushort VkEscape = 27;

		private const ushort VkReturn = 13;

		private const ushort VkSpace = 32;

		private const ushort VkLeftWindows = 91;

		private const ushort VkRightWindows = 92;

		private const ushort VkRight = 39;

		private static readonly SelectionGuard Selection = new SelectionGuard(TryCollapseSelectionThroughAutomation, SendCollapseKey);

		private const char ScanCodeLeftShift = '*';

		private const char ScanCodeRightShift = '6';

		private const uint EmReplaceSelection = 194u;

		private volatile bool _protectPaymentFields;

		private volatile bool _protectAddressBars = true;

		private volatile bool _protectWebAddressFields = true;

		private static string _lastTargetDescription = string.Empty;

		private static (nint Window, long Element) _lastTargetIdentity;

		private static (nint Window, string Key) _lastEditorKey;

		[ThreadStatic]
		private static bool t_withoutAutomation;

		private const int PreviousTextSelectionAttempts = 4;

		private const int PreviousTextSelectionRetryDelayMs = 10;

		public string LastParagraphCaptureDiagnostic { get; private set; } = string.Empty;

		public string LastFocusRestoreDiagnostic { get; private set; } = string.Empty;

		public int LastSendInputError { get; private set; }

		public string LastReplacementSource { get; private set; } = string.Empty;

		public string LastReplacementTarget { get; private set; } = string.Empty;

		public bool LastReplacementStartedRightToLeftEmbedding { get; private set; }

		public bool LastReplacementContradictedEditor { get; private set; }

		public Func<bool>? ShouldAbandonReplacement { get; set; }

		public bool ProtectPaymentFields
		{
			get
			{
				return _protectPaymentFields;
			}
			set
			{
				_protectPaymentFields = value;
			}
		}

		public bool ProtectAddressBars
		{
			get
			{
				return _protectAddressBars;
			}
			set
			{
				_protectAddressBars = value;
			}
		}

		public bool ProtectWebAddressFields
		{
			get
			{
				return _protectWebAddressFields;
			}
			set
			{
				_protectWebAddressFields = value;
			}
		}

		public bool EditorTextIsKnownStale => EditorCapabilityStore.For(CurrentEditorKey()).StaleText;

		public bool WithoutAutomation
		{
			get
			{
				return t_withoutAutomation;
			}
			set
			{
				t_withoutAutomation = value;
			}
		}

		public bool HasOpenSelection => Selection.IsOpen;

		public void ForgetLastReplacementRefusal()
		{
			LastReplacementContradictedEditor = false;
		}

		public bool ReplacePreviousToken(string source, string replacement, ushort? trailingVirtualKey = null, bool setRightToLeft = false, string? trailingText = null, bool paragraphIsRightToLeft = false, bool startRightToLeftEmbedding = false, bool paragraphHasRightToLeftEmbedding = false, bool removeRightToLeftEmbedding = false, bool releaseActiveModifiers = false, bool requireExactSourceMatch = false, string precedingText = "", bool useKeyBuffer = false)
		{
			LastReplacementSource = string.Empty;
			LastReplacementTarget = string.Empty;
			LastReplacementStartedRightToLeftEmbedding = false;
			if (t_withoutAutomation)
			{
				useKeyBuffer = true;
			}
			LastReplacementContradictedEditor = false;
			if (source.Length == 0 || replacement.Length == 0)
			{
				return false;
			}
			if (!t_withoutAutomation)
			{
				LogTypingTargetWhenItChanges();
			}
			if (releaseActiveModifiers && !ReleaseActiveModifiers())
			{
				return false;
			}
			int length = source.Length;
			string text = replacement;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = setRightToLeft;
			string paragraphPrefix2;
			if (removeRightToLeftEmbedding && !t_withoutAutomation && TrySelectCurrentParagraphPrefix(source, out string paragraphPrefix))
			{
				length = paragraphPrefix.Length;
				flag2 = true;
				string text2 = paragraphPrefix;
				int length2 = source.Length;
				text = BidiControlCharacters.RemoveParagraphStabilization(text2.Substring(0, text2.Length - length2) + replacement);
			}
			else if (startRightToLeftEmbedding && !useKeyBuffer && TryGetCurrentParagraphPrefix(source, out paragraphPrefix2, selectRange: false) && paragraphPrefix2.StartsWith('\u202b'))
			{
				PreviousTextSelection previousTextSelection = SelectPreviousText(source, precedingText, useKeyBuffer, requireExactSourceMatch);
				if (previousTextSelection == PreviousTextSelection.Mismatch)
				{
					return RefuseReplacement(source, "the editor does not hold the source text");
				}
				flag2 = previousTextSelection == PreviousTextSelection.Selected;
			}
			else if (startRightToLeftEmbedding)
			{
				if (!useKeyBuffer && !EditorCapabilityStore.For(CurrentEditorKey()).PaintedOrder && TryGetCurrentParagraphPrefix(source, out string paragraphPrefix3, selectRange: false) && BidiControlCharacters.CanPromoteParagraphToRightToLeft(paragraphPrefix3, source) && BidiControlCharacters.CanRewriteParagraphPrefix(paragraphPrefix3, source) && TrySelectCurrentParagraphPrefix(source, out paragraphPrefix3))
				{
					length = paragraphPrefix3.Length;
					flag2 = true;
					string text2 = paragraphPrefix3;
					int length2 = source.Length;
					string text3 = text2.Substring(0, text2.Length - length2) + replacement;
					flag = !paragraphPrefix3.StartsWith('\u202b');
					text = (flag ? BidiControlCharacters.StartRightToLeftEmbedding(BidiControlCharacters.StabilizeTerminalLeftToRightPunctuation(text3)) : text3);
				}
				else
				{
					PreviousTextSelection previousTextSelection2 = SelectPreviousText(source, precedingText, useKeyBuffer, requireExactSourceMatch);
					if (previousTextSelection2 == PreviousTextSelection.Mismatch)
					{
						return RefuseReplacement(source, "the editor does not hold the source text");
					}
					flag2 = previousTextSelection2 == PreviousTextSelection.Selected;
					text = BidiControlCharacters.StartRightToLeftEmbedding(replacement);
					flag = true;
				}
			}
			else
			{
				PreviousTextSelection previousTextSelection3 = SelectPreviousText(source, precedingText, useKeyBuffer, requireExactSourceMatch);
				if (previousTextSelection3 == PreviousTextSelection.Mismatch)
				{
					return RefuseReplacement(source, "the editor does not hold the source text");
				}
				flag2 = previousTextSelection3 == PreviousTextSelection.Selected;
				if (startRightToLeftEmbedding)
				{
					text = BidiControlCharacters.StartRightToLeftEmbedding(replacement);
					flag = true;
				}
				else if (removeRightToLeftEmbedding)
				{
					text += "\u202c";
				}
			}
			if (requireExactSourceMatch && !flag2)
			{
				return RefuseReplacement(source, "the editor did not confirm the source text by selecting it");
			}
			Func<bool>? shouldAbandonReplacement = ShouldAbandonReplacement;
			bool shouldAppend;
			if (shouldAbandonReplacement != null && shouldAbandonReplacement())
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(68, 2, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Abandoned '");
					message.AppendFormatted(source);
					message.AppendLiteral("' -> '");
					message.AppendFormatted(replacement);
					message.AppendLiteral("': a key was typed while the editor was being read.");
				}
				DiagnosticLog.Write("Replace", ref message);
				CollapseSelection(preferKeyboard: true);
				return false;
			}
			bool flag4 = trailingVirtualKey == 13 && (flag | paragraphHasRightToLeftEmbedding);
			bool flag5 = flag3 && !paragraphIsRightToLeft;
			ForegroundLayoutContext context = ((flag2 | flag5 | flag4) ? CaptureForegroundLayout() : default(ForegroundLayoutContext));
			bool flag6 = flag5 && context.IsEnglish;
			Selection.MarkConsumed();
			bool flag7 = flag2 && TryReplaceSelectedText(context.TargetWindow, text);
			List<NativeMethods.INPUT> list = new List<NativeMethods.INPUT>(length * 2 + text.Length * 2 + 8);
			if (!flag2)
			{
				for (int i = 0; i < length; i++)
				{
					list.Add(CreateKeyInput(8, '\0', 0u));
					list.Add(CreateKeyInput(8, '\0', 2u));
				}
			}
			if (!flag7)
			{
				string text2 = text;
				foreach (char scanCode in text2)
				{
					list.Add(CreateKeyInput(0, scanCode, 4u));
					list.Add(CreateKeyInput(0, scanCode, 6u));
				}
			}
			if (flag6)
			{
				AddControlShiftShortcut(list, '6');
			}
			else if (removeRightToLeftEmbedding)
			{
				AddControlShiftShortcut(list, '*');
			}
			if (flag4)
			{
				AddUnicodeCharacter(list, '\u202c');
			}
			if (trailingVirtualKey.HasValue)
			{
				if (trailingVirtualKey.Value == 32)
				{
					list.Add(CreateKeyInput(0, ' ', 4u));
					list.Add(CreateKeyInput(0, ' ', 6u));
				}
				else
				{
					list.Add(CreateKeyInput(trailingVirtualKey.Value, '\0', 0u));
					list.Add(CreateKeyInput(trailingVirtualKey.Value, '\0', 2u));
				}
				if (flag4)
				{
					AddControlShiftShortcut(list, '*');
				}
			}
			else if (!string.IsNullOrEmpty(trailingText))
			{
				string text2 = trailingText;
				foreach (char scanCode2 in text2)
				{
					list.Add(CreateKeyInput(0, scanCode2, 4u));
					list.Add(CreateKeyInput(0, scanCode2, 6u));
				}
			}
			bool flag8 = list.Count == 0 || SendInputs(list);
			DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(104, 9, out shouldAppend);
			if (shouldAppend)
			{
				message2.AppendLiteral("Replace '");
				message2.AppendFormatted(source);
				message2.AppendLiteral("' -> '");
				message2.AppendFormatted(text);
				message2.AppendLiteral("': selectedInEditor=");
				message2.AppendFormatted(flag2);
				message2.AppendLiteral(" nativeEdit=");
				message2.AppendFormatted(flag7);
				message2.AppendLiteral(" backspaces=");
				message2.AppendFormatted((!flag2) ? length : 0);
				message2.AppendLiteral(" startedEmbedding=");
				message2.AppendFormatted(flag);
				message2.AppendLiteral(" rtlShortcut=");
				message2.AppendFormatted(flag6);
				message2.AppendLiteral(" sent=");
				message2.AppendFormatted(flag8);
				message2.AppendLiteral(" error=");
				message2.AppendFormatted(LastSendInputError);
				message2.AppendLiteral(".");
			}
			DiagnosticLog.Write("Replace", ref message2);
			if (flag8)
			{
				LastReplacementSource = source;
				LastReplacementTarget = replacement;
				LastReplacementStartedRightToLeftEmbedding = flag;
			}
			if (flag8 && (flag6 | removeRightToLeftEmbedding | flag4 | flag7))
			{
				RestoreForegroundLayoutNowOrLater(context);
			}
			return flag8;
		}

		public bool IsReadUntrustedForRewrite(string text)
		{
			if (!UnfaithfulTextRoute.ContainsArabicScript(text))
			{
				return false;
			}
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null)
				{
					return false;
				}
				using Process process = Process.GetProcessById(focusedElement.Current.ProcessId);
				return UnfaithfulTextRoute.IsDemonstratedRoute(process.ProcessName, focusedElement.Current.NativeWindowHandle);
			}
			catch (Exception ex) when ((ex is ElementNotAvailableException || ex is InvalidOperationException || ex is COMException || ex is ArgumentException || ex is Win32Exception) ? true : false)
			{
				return false;
			}
		}

		public bool FocusedEditorLosesUnicodeBatches()
		{
			return UnicodeBatchLossRoute.IsFocused();
		}

		public ParagraphDirectionHost FocusedParagraphDirectionHost()
		{
			return ParagraphDirectionRoute.Focused();
		}

		public bool FocusedEditorKeepsAsciiDigits()
		{
			return PersianDigitRoute.Focused();
		}

		public EnglishOnlyApplicationMatch? FocusedEnglishOnlyApplication()
		{
			return EnglishOnlyApplicationRoute.Focused();
		}

		public bool HardwareKeyboardAutocorrectIsOn()
		{
			return HardwareKeyboardAutocorrect.IsOn();
		}

		public void RefreshHardwareKeyboardAutocorrect()
		{
			HardwareKeyboardAutocorrect.RefreshIfStale();
		}

		public long GetForegroundTargetIdentity()
		{
			return ((IntPtr)CaptureForegroundLayout().TargetWindow).ToInt64();
		}

		public long GetFocusedElementIdentity()
		{
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null)
				{
					return 0L;
				}
				HashCode hashCode = default;
				hashCode.Add(focusedElement.Current.ProcessId);
				hashCode.Add(focusedElement.Current.NativeWindowHandle);
				int[] runtimeId = focusedElement.GetRuntimeId();
				foreach (int value in runtimeId)
				{
					hashCode.Add(value);
				}
				return hashCode.ToHashCode();
			}
			catch (ElementNotAvailableException)
			{
				return 0L;
			}
			catch (InvalidOperationException)
			{
				return 0L;
			}
			catch (COMException)
			{
				return 0L;
			}
		}

		public long GetForegroundWindowIdentity()
		{
			return ((IntPtr)NativeMethods.GetForegroundWindow()).ToInt64();
		}

		private static string CurrentEditorKey()
		{
			nint targetWindow = CaptureForegroundLayout().TargetWindow;
			if (targetWindow == _lastEditorKey.Window && !string.IsNullOrEmpty(_lastEditorKey.Key))
			{
				return _lastEditorKey.Key;
			}
			string app = "?";
			string windowClass = "?";
			if (targetWindow != IntPtr.Zero)
			{
				NativeMethods.GetWindowThreadProcessId(targetWindow, out var lpdwProcessId);
				try
				{
					using Process process = Process.GetProcessById((int)lpdwProcessId);
					app = process.ProcessName;
				}
				catch (Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException) ? true : false)
				{
				}
				StringBuilder stringBuilder = new StringBuilder(256);
				if (NativeMethods.GetClassName(targetWindow, stringBuilder, stringBuilder.Capacity) != 0)
				{
					windowClass = stringBuilder.ToString();
				}
			}
			_lastEditorKey = (Window: targetWindow, Key: EditorCapabilityStore.Key(app, windowClass));
			return _lastEditorKey.Key;
		}

		public string DescribeTypingTarget()
		{
			if (!DiagnosticLog.IsEnabled)
			{
				return string.Empty;
			}
			ForegroundLayoutContext foregroundLayoutContext = CaptureForegroundLayout();
			(nint, long) tuple = (foregroundLayoutContext.TargetWindow, GetFocusedElementIdentity());
			(nint, long) tuple2 = tuple;
			(nint, long) lastTargetIdentity = _lastTargetIdentity;
			if (tuple2.Item1 == lastTargetIdentity.Item1 && tuple2.Item2 == lastTargetIdentity.Item2 && _lastTargetDescription.Length > 0)
			{
				return _lastTargetDescription;
			}
			_lastTargetIdentity = tuple;
			_lastTargetDescription = BuildTargetDescription(foregroundLayoutContext.TargetWindow);
			return _lastTargetDescription;
		}

		public void LogTypingTargetWhenItChanges()
		{
			if (DiagnosticLog.IsEnabled)
			{
				string lastTargetDescription = _lastTargetDescription;
				string text = DescribeTypingTarget();
				if (text.Length > 0 && !string.Equals(text, lastTargetDescription, StringComparison.Ordinal))
				{
					DiagnosticLog.Write("Target", text);
				}
			}
		}

		public TypingTargetFacts? DescribeTargetForJournal()
		{
			if (!DiagnosticLog.IsEnabled)
			{
				return null;
			}
			ForegroundLayoutContext foregroundLayoutContext = CaptureForegroundLayout();
			string text = CurrentEditorKey();
			return TypingTargetFacts.Describe(foregroundLayoutContext.TargetWindow, foregroundLayoutContext.TopLevelWindow, text, EditorCapabilityStore.For(text).Summary, FocusedEditorLosesUnicodeBatches(), includeElement: true);
		}

		public void ObserveStaleEditorText()
		{
			string text = CurrentEditorKey();
			if (!EditorCapabilityStore.For(text).StaleText)
			{
				EditorCapabilityStore.Observe(text, (EditorCapabilities known) => known with
				{
					StaleText = true
				}, "the editor returned exactly the same text for a later, different word");
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(93, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("  this editor's text has stopped following what is typed; its reads are no longer retried (");
					message.AppendFormatted(text);
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message);
			}
		}

		private static string BuildTargetDescription(nint targetWindow)
		{
			string value = "?";
			string text = "?";
			if (targetWindow != IntPtr.Zero)
			{
				NativeMethods.GetWindowThreadProcessId(targetWindow, out var lpdwProcessId);
				try
				{
					using Process process = Process.GetProcessById((int)lpdwProcessId);
					value = process.ProcessName;
				}
				catch (Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException) ? true : false)
				{
				}
				StringBuilder stringBuilder = new StringBuilder(256);
				if (NativeMethods.GetClassName(targetWindow, stringBuilder, stringBuilder.Capacity) != 0)
				{
					text = stringBuilder.ToString();
				}
			}
			string text2 = "?";
			bool value2 = text.Contains("Edit", StringComparison.OrdinalIgnoreCase);
			string value3 = "none";
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement != null)
				{
					text2 = focusedElement.Current.ControlType.ProgrammaticName.Replace("ControlType.", string.Empty);
					string automationId = focusedElement.Current.AutomationId;
					if (automationId != null && automationId.Length > 0)
					{
						text2 = text2 + "#" + automationId;
					}
					value3 = (focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var _) ? "TextPattern" : "none");
				}
			}
			catch (Exception ex2) when ((ex2 is ElementNotAvailableException || ex2 is InvalidOperationException || ex2 is COMException) ? true : false)
			{
			}
			return $"app={value} class={text} control={text2} textPattern={value3} nativeEdit={value2}";
		}

		public bool TryGetCurrentParagraphPrefixText(string source, out string paragraphPrefix)
		{
			return TryGetCurrentParagraphPrefix(source, out paragraphPrefix, selectRange: false);
		}

		public bool TryReadParagraphPrefixWithTrace(out string paragraphPrefix, out ParagraphReadTrace? trace)
		{
			return TryGetCurrentParagraphPrefix(trace: trace = ParagraphReadTrace.Begin("TextPattern"), source: string.Empty, paragraphPrefix: out paragraphPrefix, selectRange: false);
		}

		public bool IsProtectedTechnicalField()
		{
			string checkedControlType;
			return IsProtectedTechnicalField(out checkedControlType);
		}

		public bool IsProtectedTechnicalField(out string checkedControlType)
		{
			checkedControlType = string.Empty;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null)
				{
					return false;
				}
				string processName = string.Empty;
				try
				{
					using Process process = Process.GetProcessById(focusedElement.Current.ProcessId);
					processName = process.ProcessName;
				}
				catch (ArgumentException)
				{
				}
				string value = string.Empty;
				if (focusedElement.TryGetCurrentPattern(ValuePattern.Pattern, out var patternObject) && patternObject is ValuePattern { Current: var current })
				{
					value = current.Value ?? string.Empty;
				}
				string text = focusedElement.Current.ControlType.ProgrammaticName;
				if (text.StartsWith("ControlType.", StringComparison.Ordinal))
				{
					text = text.Substring("ControlType.".Length);
				}
				checkedControlType = text;
				TechnicalTextFieldSnapshot technicalTextFieldSnapshot = new TechnicalTextFieldSnapshot(processName, text, focusedElement.Current.Name ?? string.Empty, focusedElement.Current.AutomationId ?? string.Empty, focusedElement.Current.ClassName ?? string.Empty, value, focusedElement.Current.IsPassword);
				string text2 = TechnicalTextFieldClassifier.ProtectionReason(technicalTextFieldSnapshot, _protectPaymentFields, _protectAddressBars, _protectWebAddressFields);
				TypingTargetFacts.RememberCheckedElement(technicalTextFieldSnapshot, text2);
				return TechnicalTextFieldClassifier.Protects(text2);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException ex4)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(119, 2, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("The protected-field check could not read the field: COM error 0x");
					message.AppendFormatted(ex4.HResult, "X8");
					message.AppendLiteral(" (");
					message.AppendFormatted(DescribeCallContext());
					message.AppendLiteral("); only the detector's evidence applies to this word.");
				}
				DiagnosticLog.Write("Replace", ref message);
				DiagnosticLog.Journal?.Incident($"com:0x{ex4.HResult:X8}", "UI Automation call failed: protected-field check", "hresult", $"0x{ex4.HResult:X8}", "where", DescribeCallContext(), "thread", $"{Environment.CurrentManagedThreadId} '{Thread.CurrentThread.Name}' {Thread.CurrentThread.GetApartmentState()}");
				return false;
			}
			catch (Win32Exception)
			{
				return false;
			}
			catch (UnauthorizedAccessException)
			{
				return false;
			}
		}

		public bool CompleteRightToLeftEmbeddingAndSend(ushort trailingVirtualKey)
		{
			ForegroundLayoutContext context = CaptureForegroundLayout();
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(8);
			AddUnicodeCharacter(inputs, '\u202c');
			AddVirtualKeyPress(inputs, trailingVirtualKey);
			AddControlShiftShortcut(inputs, '*');
			bool flag = SendInputs(inputs);
			if (flag)
			{
				RestoreForegroundLayoutNowOrLater(context);
			}
			return flag;
		}

		public bool SendKeyAndResetParagraphDirection(ushort? trailingVirtualKey)
		{
			ForegroundLayoutContext context = CaptureForegroundLayout();
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(8);
			if (trailingVirtualKey.HasValue)
			{
				ushort valueOrDefault = trailingVirtualKey.GetValueOrDefault();
				AddVirtualKeyPress(inputs, valueOrDefault);
			}
			AddControlShiftShortcut(inputs, '*');
			bool flag = SendInputs(inputs);
			DiagnosticMessageHandler message = new DiagnosticMessageHandler(73, 3, out var shouldAppend);
			if (shouldAppend)
			{
				message.AppendLiteral("Paragraph direction reset after the key 0x");
				message.AppendFormatted(trailingVirtualKey.GetValueOrDefault(), "X2");
				message.AppendLiteral(": Ctrl+Left Shift sent=");
				message.AppendFormatted(flag);
				message.AppendLiteral(" error=");
				message.AppendFormatted(LastSendInputError);
				message.AppendLiteral(".");
			}
			DiagnosticLog.Write("Replace", ref message);
			if (flag)
			{
				RestoreForegroundLayoutNowOrLater(context);
			}
			return flag;
		}

		public bool SendTextThenKey(string text, ushort trailingVirtualKey)
		{
			if (text.Length == 0)
			{
				return false;
			}
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(text.Length * 2 + 2);
			foreach (char character in text)
			{
				AddUnicodeCharacter(inputs, character);
			}
			AddVirtualKeyPress(inputs, trailingVirtualKey);
			return SendInputs(inputs);
		}

		public bool SendUnicodeText(string text)
		{
			if (text.Length == 0)
			{
				return false;
			}
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(text.Length * 2);
			foreach (char character in text)
			{
				AddUnicodeCharacter(inputs, character);
			}
			return SendInputs(inputs);
		}

		public bool TryDeletePreviousTextExact(string text)
		{
			if (text.Length == 0)
			{
				return false;
			}
			if (!TrySelectPreviousText(text))
			{
				CollapseSelection(preferKeyboard: false);
				return false;
			}
			ForegroundLayoutContext foregroundLayoutContext = CaptureForegroundLayout();
			Selection.MarkConsumed();
			return TryReplaceSelectedText(foregroundLayoutContext.TargetWindow, string.Empty);
		}

		public bool TryReplaceExactTextBeforeCaret(string expected, string replacement, Func<bool>? writeOverSelection = null)
		{
			LastReplacementContradictedEditor = false;
			if (expected.Length == 0 || replacement.Length == 0 || t_withoutAutomation)
			{
				return false;
			}
			PreviousTextSelection previousTextSelection = SelectPreviousText(expected, "", useKeyBuffer: false, editorMustConfirm: true);
			bool shouldAppend;
			if (previousTextSelection != PreviousTextSelection.Selected)
			{
				LastReplacementContradictedEditor = previousTextSelection == PreviousTextSelection.Mismatch;
				CollapseSelection(preferKeyboard: false);
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(86, 2, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Exact replacement of ");
					message.AppendFormatted(expected.Length);
					message.AppendLiteral(" chars refused: the editor did not confirm it by selecting it (");
					message.AppendFormatted(previousTextSelection);
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message);
				return false;
			}
			Func<bool>? shouldAbandonReplacement = ShouldAbandonReplacement;
			if (shouldAbandonReplacement != null && shouldAbandonReplacement())
			{
				DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(87, 1, out shouldAppend);
				if (shouldAppend)
				{
					message2.AppendLiteral("Exact replacement of ");
					message2.AppendFormatted(expected.Length);
					message2.AppendLiteral(" chars abandoned: a key was typed while the editor was being read.");
				}
				DiagnosticLog.Write("Replace", ref message2);
				CollapseSelection(preferKeyboard: true);
				return false;
			}
			Selection.MarkConsumed();
			bool flag = writeOverSelection?.Invoke() ?? SendUnicodeText(replacement);
			DiagnosticMessageHandler message3 = new DiagnosticMessageHandler(89, 5, out shouldAppend);
			if (shouldAppend)
			{
				message3.AppendLiteral("Exact replacement of ");
				message3.AppendFormatted(expected.Length);
				message3.AppendLiteral(" chars with ");
				message3.AppendFormatted(replacement.Length);
				message3.AppendLiteral(" chars: selectedInEditor=true viaCallback=");
				message3.AppendFormatted(writeOverSelection != null);
				message3.AppendLiteral(" sent=");
				message3.AppendFormatted(flag);
				message3.AppendLiteral(" error=");
				message3.AppendFormatted(LastSendInputError);
				message3.AppendLiteral(".");
			}
			DiagnosticLog.Write("Replace", ref message3);
			if (flag)
			{
				LastReplacementSource = expected;
				LastReplacementTarget = replacement;
			}
			else
			{
				Selection.MarkOpen();
				CollapseSelection(preferKeyboard: false);
			}
			return flag;
		}

		public bool SendControlShortcut(ushort key)
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(4)
			{
				CreateKeyInput(17, '\0', 0u),
				CreateKeyInput(key, '\0', 0u),
				CreateKeyInput(key, '\0', 2u),
				CreateKeyInput(17, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		public bool ReplaceSelectedText(string replacement)
		{
			if (replacement.Length == 0)
			{
				return false;
			}
			Selection.MarkConsumed();
			try
			{
				if (TryReplaceSelectedText(new IntPtr(AutomationElement.FocusedElement.Current.NativeWindowHandle), replacement))
				{
					return true;
				}
			}
			catch (ElementNotAvailableException)
			{
			}
			catch (COMException)
			{
			}
			return TryReplaceSelectedText(CaptureForegroundLayout().TargetWindow, replacement);
		}

		public bool SelectionCoversCurrentParagraph()
		{
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return false;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1)
				{
					return false;
				}
				string text = selection[0].GetText(-1).TrimEnd(new char[2] { '\r', '\n' });
				if (text.Length == 0)
				{
					return false;
				}
				TextPatternRange textPatternRange = selection[0].Clone();
				textPatternRange.ExpandToEnclosingUnit(TextUnit.Paragraph);
				return string.Equals(text, textPatternRange.GetText(-1).TrimEnd(new char[2] { '\r', '\n' }), StringComparison.Ordinal);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool TryGetSelectedText(out string selectedText)
		{
			if (!TryGetSelectedTextRead(out selectedText))
			{
				return false;
			}
			if (IsReadUntrustedForRewrite(selectedText))
			{
				DiagnosticLog.Write("Read", "The selected text was not used: this editor's Persian text is not faithful (KL-044).");
				selectedText = string.Empty;
				return false;
			}
			return true;
		}

		private bool TryGetSelectedTextRead(out string selectedText)
		{
			selectedText = string.Empty;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return false;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1 || selection[0].CompareEndpoints(TextPatternRangeEndpoint.Start, selection[0], TextPatternRangeEndpoint.End) == 0)
				{
					return false;
				}
				selectedText = selection[0].GetText(-1);
				return !string.IsNullOrWhiteSpace(selectedText);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool IsSelectedTextUnchanged(string expectedText)
		{
			if (TryGetSelectedText(out string selectedText))
			{
				return string.Equals(selectedText, expectedText, StringComparison.Ordinal);
			}
			return false;
		}

		public bool TryGetCurrentEditableText(out string editableText)
		{
			if (!TryGetCurrentEditableTextRead(out editableText))
			{
				return false;
			}
			if (IsReadUntrustedForRewrite(editableText))
			{
				DiagnosticLog.Write("Read", "The field text was not used: this editor's Persian text is not faithful (KL-044).");
				editableText = string.Empty;
				return false;
			}
			return true;
		}

		private bool TryGetCurrentEditableTextRead(out string editableText)
		{
			editableText = string.Empty;
			try
			{
				if (!TryGetCurrentEditableRange(out TextPattern _, out TextPatternRange range, out editableText))
				{
					return false;
				}
				return range != null && !string.IsNullOrWhiteSpace(editableText);
			}
			catch (ElementNotAvailableException)
			{
				editableText = string.Empty;
				return false;
			}
			catch (InvalidOperationException)
			{
				editableText = string.Empty;
				return false;
			}
			catch (COMException)
			{
				editableText = string.Empty;
				return false;
			}
		}

		public bool TrySelectCurrentEditableText(string expectedText)
		{
			try
			{
				if (!TryGetCurrentEditableRange(out TextPattern textPattern, out TextPatternRange range, out string editableText) || !string.Equals(editableText, expectedText, StringComparison.Ordinal))
				{
					return false;
				}
				range.Select();
				Selection.MarkOpen();
				return WaitForSelectedText(textPattern, expectedText);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool TryRestoreTextFocusAfterMenuActivation()
		{
			LastFocusRestoreDiagnostic = string.Empty;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || (focusedElement.Current.ControlType != ControlType.MenuItem && focusedElement.Current.ControlType != ControlType.MenuBar))
				{
					LastFocusRestoreDiagnostic = (((object)focusedElement == null) ? "No focused automation element" : ("Focus is " + focusedElement.Current.ControlType.ProgrammaticName + ", not a menu"));
					return false;
				}
				NativeMethods.INPUT[] inputs = new NativeMethods.INPUT[2]
				{
					CreateKeyInput(27, '\0', 0u),
					CreateKeyInput(27, '\0', 2u)
				};
				if (SendInputs(inputs))
				{
					if (WaitForFocusedTextPattern(out string controlType))
					{
						LastParagraphCaptureDiagnostic = "Editor focus restored after dismissing the accelerator menu";
						return true;
					}
					LastFocusRestoreDiagnostic = (string.IsNullOrEmpty(controlType) ? "Escape sent, but Windows reported no stable focused element" : ("Escape sent; focus remained on " + controlType));
				}
				else
				{
					LastFocusRestoreDiagnostic = $"Could not send Escape (Win32 error {LastSendInputError})";
				}
				nint foregroundWindow = NativeMethods.GetForegroundWindow();
				if (foregroundWindow == IntPtr.Zero)
				{
					LastFocusRestoreDiagnostic += "; no foreground window";
					return false;
				}
				AutomationElement automationElement = AutomationElement.FromHandle(foregroundWindow);
				OrCondition condition = new OrCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
				AutomationElementCollection automationElementCollection = automationElement.FindAll(TreeScope.Descendants, condition);
				LastFocusRestoreDiagnostic += $"; foreground={((IntPtr)foregroundWindow).ToInt64()}, text candidates={automationElementCollection.Count}";
				foreach (AutomationElement item in automationElementCollection)
				{
					if (item.Current.IsEnabled && item.Current.IsKeyboardFocusable && item.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject))
					{
						item.SetFocus();
						Thread.Sleep(50);
						AutomationElement focusedElement2 = AutomationElement.FocusedElement;
						if ((object)focusedElement2 != null && focusedElement2.TryGetCurrentPattern(TextPattern.Pattern, out patternObject))
						{
							LastParagraphCaptureDiagnostic = "Editor focus restored through Windows UI Automation";
							return true;
						}
					}
				}
			}
			catch (ElementNotAvailableException)
			{
				LastFocusRestoreDiagnostic += "; automation element became unavailable";
			}
			catch (InvalidOperationException)
			{
				LastFocusRestoreDiagnostic += "; automation focus operation was rejected";
			}
			catch (COMException)
			{
				LastFocusRestoreDiagnostic += "; Windows UI Automation returned a COM error";
			}
			return false;
		}

		private static bool WaitForFocusedTextPattern(out string controlType)
		{
			controlType = string.Empty;
			for (int i = 0; i < 12; i++)
			{
				Thread.Sleep(25);
				try
				{
					AutomationElement focusedElement = AutomationElement.FocusedElement;
					if ((object)focusedElement != null)
					{
						controlType = focusedElement.Current.ControlType.ProgrammaticName;
						if (focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var _))
						{
							return true;
						}
					}
				}
				catch (ElementNotAvailableException)
				{
				}
				catch (InvalidOperationException)
				{
				}
				catch (COMException)
				{
				}
			}
			return false;
		}

		public bool TryGetCurrentParagraphText(out string paragraphText)
		{
			if (!TryGetCurrentParagraphTextRead(out paragraphText))
			{
				return false;
			}
			if (IsReadUntrustedForRewrite(paragraphText))
			{
				DiagnosticLog.Write("Read", "The paragraph text was not used: this editor's Persian text is not faithful (KL-044).");
				paragraphText = string.Empty;
				return false;
			}
			return true;
		}

		private bool TryGetCurrentParagraphTextRead(out string paragraphText)
		{
			paragraphText = string.Empty;
			try
			{
				if (!TryGetCurrentParagraphRange(out TextPattern _, out TextPatternRange range, out paragraphText, out string diagnostic))
				{
					LastParagraphCaptureDiagnostic = diagnostic;
					return false;
				}
				LastParagraphCaptureDiagnostic = "Current paragraph captured";
				return paragraphText.Length > 0 && range != null;
			}
			catch (ElementNotAvailableException)
			{
				LastParagraphCaptureDiagnostic = "Focused element became unavailable";
				paragraphText = string.Empty;
				return false;
			}
			catch (InvalidOperationException)
			{
				LastParagraphCaptureDiagnostic = "Focused element does not expose a usable text range";
				paragraphText = string.Empty;
				return false;
			}
			catch (COMException)
			{
				LastParagraphCaptureDiagnostic = "Windows UI Automation could not read the current paragraph";
				paragraphText = string.Empty;
				return false;
			}
		}

		public bool TrySelectCurrentParagraphText(string expectedText)
		{
			try
			{
				if (!TryGetCurrentParagraphRange(out TextPattern textPattern, out TextPatternRange range, out string paragraphText) || !string.Equals(paragraphText, expectedText, StringComparison.Ordinal))
				{
					return false;
				}
				range.Select();
				Selection.MarkOpen();
				return WaitForSelectedText(textPattern, expectedText);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool ApplyParagraphDirection(bool rightToLeft)
		{
			ForegroundLayoutContext context = CaptureForegroundLayout();
			if (context.TargetWindow == IntPtr.Zero)
			{
				return false;
			}
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(4);
			AddControlShiftShortcut(inputs, rightToLeft ? '6' : '*');
			bool flag = SendInputs(inputs);
			if (flag)
			{
				RestoreForegroundLayout(context);
			}
			return flag;
		}

		public bool SendControlShortcutWithoutActiveModifiers(ushort key)
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(10)
			{
				CreateKeyInput(17, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(18, '\0', 2u),
				CreateKeyInput(17, '\0', 0u),
				CreateKeyInput(key, '\0', 0u),
				CreateKeyInput(key, '\0', 2u),
				CreateKeyInput(17, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(18, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		private bool ReleaseActiveModifiers()
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(5)
			{
				CreateKeyInput(18, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(17, '\0', 2u),
				CreateKeyInput(91, '\0', 2u),
				CreateKeyInput(92, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		public bool SendControlShiftShortcut(ushort key)
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(6)
			{
				CreateKeyInput(17, '\0', 0u),
				CreateKeyInput(16, '\0', 0u),
				CreateKeyInput(key, '\0', 0u),
				CreateKeyInput(key, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(17, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		private bool SendInputs(IReadOnlyList<NativeMethods.INPUT> inputs)
		{
			NativeMethods.INPUT[] array = inputs.ToArray();
			uint num = InjectedInputOrder.Send(array);
			LastSendInputError = ((num != (uint)array.Length) ? Marshal.GetLastWin32Error() : 0);
			return num == (uint)array.Length;
		}

		private static ForegroundLayoutContext CaptureForegroundLayout()
		{
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return default;
			}
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(foregroundWindow, out var lpdwProcessId);
			if (windowThreadProcessId == 0)
			{
				return default;
			}
			nint num = foregroundWindow;
			uint idThread = windowThreadProcessId;
			NativeMethods.GUITHREADINFO lpgui = new NativeMethods.GUITHREADINFO
			{
				cbSize = (uint)Marshal.SizeOf<NativeMethods.GUITHREADINFO>()
			};
			if (NativeMethods.GetGUIThreadInfo(windowThreadProcessId, ref lpgui) && lpgui.hwndFocus != IntPtr.Zero)
			{
				num = lpgui.hwndFocus;
				idThread = NativeMethods.GetWindowThreadProcessId(num, out lpdwProcessId);
			}
			nint keyboardLayout = NativeMethods.GetKeyboardLayout(idThread);
			bool isEnglish = (GetLanguageId(keyboardLayout) & 0x3FF) == 9;
			return new ForegroundLayoutContext(num, foregroundWindow, keyboardLayout, isEnglish);
		}

		private static void RestoreForegroundLayoutNowOrLater(ForegroundLayoutContext context)
		{
			if (t_withoutAutomation)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(74, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Layout after the edit left to the typing pipeline's watch (layout was 0x");
					message.AppendFormatted(((IntPtr)context.KeyboardLayout).ToInt64(), "X8");
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message);
			}
			else
			{
				RestoreForegroundLayout(context);
			}
		}

		private static void RestoreForegroundLayout(ForegroundLayoutContext context)
		{
			Thread.Sleep(25);
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(context.TargetWindow, out var _);
			bool shouldAppend;
			if (windowThreadProcessId != 0 && NativeMethods.GetKeyboardLayout(windowThreadProcessId) == context.KeyboardLayout)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(56, 1, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Layout check after the edit: still 0x");
					message.AppendFormatted(((IntPtr)context.KeyboardLayout).ToInt64(), "X8");
					message.AppendLiteral("; nothing restored.");
				}
				DiagnosticLog.Write("Replace", ref message);
				return;
			}
			DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(69, 2, out shouldAppend);
			if (shouldAppend)
			{
				message2.AppendLiteral("Layout check after the edit: the editor switched to 0x");
				message2.AppendFormatted((windowThreadProcessId == 0) ? 0 : ((IntPtr)NativeMethods.GetKeyboardLayout(windowThreadProcessId)).ToInt64(), "X8");
				message2.AppendLiteral("; restoring 0x");
				message2.AppendFormatted(((IntPtr)context.KeyboardLayout).ToInt64(), "X8");
				message2.AppendLiteral(".");
			}
			DiagnosticLog.Write("Replace", ref message2);
			NativeMethods.PostMessage(context.TargetWindow, 80u, IntPtr.Zero, context.KeyboardLayout);
			if (context.TopLevelWindow != context.TargetWindow)
			{
				NativeMethods.PostMessage(context.TopLevelWindow, 80u, IntPtr.Zero, context.KeyboardLayout);
			}
		}

		private static ushort GetLanguageId(nint keyboardLayout)
		{
			return (ushort)(((IntPtr)keyboardLayout).ToInt64() & 0xFFFF);
		}

		private static bool TrySelectPreviousText(string source)
		{
			return SelectPreviousText(source) == PreviousTextSelection.Selected;
		}

		private static PreviousTextSelection SelectPreviousText(string source, string precedingText = "", bool useKeyBuffer = false, bool editorMustConfirm = false)
		{
			bool shouldAppend;
			if (useKeyBuffer)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(57, 1, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Using the key buffer for '");
					message.AppendFormatted(source);
					message.AppendLiteral("'; the editor text is not read.");
				}
				DiagnosticLog.Write("Replace", ref message);
				return PreviousTextSelection.Unreadable;
			}
			int num = 1;
			PreviousTextSelection? previousTextSelection2;
			while (true)
			{
				EditorCapabilities editorCapabilities = EditorCapabilityStore.For(CurrentEditorKey());
				PreviousTextSelection previousTextSelection = ResolveInPaintedOrderEditor(SelectPreviousTextOnce(source, precedingText), editorCapabilities.PaintedOrder);
				DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(62, 5, out shouldAppend);
				if (shouldAppend)
				{
					message2.AppendLiteral("Select previous text attempt ");
					message2.AppendFormatted(num);
					message2.AppendLiteral(": source='");
					message2.AppendFormatted(source);
					message2.AppendLiteral("' preceding='");
					message2.AppendFormatted(precedingText);
					message2.AppendLiteral("' result=");
					message2.AppendFormatted(previousTextSelection);
					message2.AppendFormatted(editorCapabilities.PaintedOrder ? " (this editor paints out of order, so a lagging read is not trusted)" : string.Empty);
					message2.AppendLiteral(".");
				}
				DiagnosticLog.Write("Replace", ref message2);
				if (!ShouldReadAgain(previousTextSelection, num, editorCapabilities.ShouldRetryOffsetReads))
				{
					return previousTextSelection;
				}
				previousTextSelection2 = ResolveAfterClosingSelection(CollapseSelection(preferKeyboard: false), editorMustConfirm);
				if (previousTextSelection2.HasValue)
				{
					break;
				}
				Thread.Sleep(10);
				num++;
			}
			PreviousTextSelection valueOrDefault = previousTextSelection2.GetValueOrDefault();
			DiagnosticMessageHandler message3 = new DiagnosticMessageHandler(94, 1, out shouldAppend);
			if (shouldAppend)
			{
				message3.AppendLiteral("Stopped reading '");
				message3.AppendFormatted(source);
				message3.AppendLiteral("': closing the selection moved the caret, so its position is no longer known.");
			}
			DiagnosticLog.Write("Replace", ref message3);
			return valueOrDefault;
		}

		private static PreviousTextSelection SelectPreviousTextOnce(string source, string precedingText)
		{
			int length = source.Length;
			TextPattern textPattern2;
			TextPatternRange textPatternRange;
			bool shouldAppend;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return PreviousTextSelection.Unreadable;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1)
				{
					return PreviousTextSelection.Unreadable;
				}
				textPattern2 = textPattern;
				textPatternRange = selection[0];
			}
			catch (ElementNotAvailableException)
			{
				return PreviousTextSelection.Unreadable;
			}
			catch (InvalidOperationException)
			{
				return PreviousTextSelection.Unreadable;
			}
			catch (COMException ex3)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(46, 2, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("The editor could not be read: COM error 0x");
					message.AppendFormatted(ex3.HResult, "X8");
					message.AppendLiteral(" (");
					message.AppendFormatted(DescribeCallContext());
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message);
				DiagnosticLog.Journal?.Incident($"com:0x{ex3.HResult:X8}", "UI Automation call failed: reading the editor before a replacement", "hresult", $"0x{ex3.HResult:X8}", "where", DescribeCallContext(), "thread", $"{Environment.CurrentManagedThreadId} '{Thread.CurrentThread.Name}' {Thread.CurrentThread.GetApartmentState()}");
				return PreviousTextSelection.Unreadable;
			}
			try
			{
				TextPatternRange textPatternRange2 = textPatternRange.Clone();
				textPatternRange2.MoveEndpointByRange(TextPatternRangeEndpoint.Start, textPatternRange, TextPatternRangeEndpoint.End);
				int num = textPatternRange2.MoveEndpointByUnit(TextPatternRangeEndpoint.Start, TextUnit.Character, -(length + 1));
				string text = textPatternRange2.GetText(-1);
				DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(43, 3, out shouldAppend);
				if (shouldAppend)
				{
					message2.AppendLiteral("  editor text before caret='");
					message2.AppendFormatted(text);
					message2.AppendLiteral("' (moved ");
					message2.AppendFormatted(-num);
					message2.AppendLiteral(" of ");
					message2.AppendFormatted(length + 1);
					message2.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message2);
				if (-num < length)
				{
					return Classify(text, source, precedingText);
				}
				string actualText = text;
				int num2 = 0;
				while (!MatchesPhysicalSourceText(actualText, source) && num2 < 3)
				{
					if (textPatternRange2.MoveEndpointByUnit(TextPatternRangeEndpoint.Start, TextUnit.Character, 1) != 1)
					{
						return EndsWithSource(text, source) ? PreviousTextSelection.ConfirmedNotSelectable : PreviousTextSelection.Mismatch;
					}
					actualText = textPatternRange2.GetText(-1);
					num2++;
				}
				if (!MatchesPhysicalSourceText(actualText, source))
				{
					if (EndsWithSource(text, source))
					{
						return PreviousTextSelection.ConfirmedNotSelectable;
					}
					if (TrySelectByFindText(textPattern2, textPatternRange, source))
					{
						return (!WaitForSelectedText(textPattern2, source)) ? PreviousTextSelection.Mismatch : PreviousTextSelection.Selected;
					}
					return Classify(text, source, precedingText);
				}
				textPatternRange2.Select();
				Selection.MarkOpen();
				bool confirmed = WaitForSelectedText(textPattern2, source);
				EditorCapabilityStore.Observe(CurrentEditorKey(), (EditorCapabilities known) => known with
				{
					TextPattern = true,
					OffsetsAreStored = true,
					ConfirmsSelection = (known.ConfirmsSelection | confirmed)
				}, confirmed ? "a range built from character offsets selected the word and the editor confirmed the selection" : "a range built from character offsets selected the word; the selection was not confirmed", source);
				return (!confirmed) ? PreviousTextSelection.Mismatch : PreviousTextSelection.Selected;
			}
			catch (ElementNotAvailableException)
			{
				return PreviousTextSelection.Mismatch;
			}
			catch (InvalidOperationException)
			{
				return PreviousTextSelection.Mismatch;
			}
			catch (COMException ex6)
			{
				DiagnosticMessageHandler message3 = new DiagnosticMessageHandler(58, 2, out shouldAppend);
				if (shouldAppend)
				{
					message3.AppendLiteral("The editor's text could not be confirmed: COM error 0x");
					message3.AppendFormatted(ex6.HResult, "X8");
					message3.AppendLiteral(" (");
					message3.AppendFormatted(DescribeCallContext());
					message3.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message3);
				DiagnosticLog.Journal?.Incident($"com:0x{ex6.HResult:X8}", "UI Automation call failed: confirming the editor text", "hresult", $"0x{ex6.HResult:X8}", "where", DescribeCallContext(), "thread", $"{Environment.CurrentManagedThreadId} '{Thread.CurrentThread.Name}' {Thread.CurrentThread.GetApartmentState()}");
				return PreviousTextSelection.Mismatch;
			}
		}

		internal static PreviousTextSelection Classify(string textBeforeCaret, string source, string precedingText)
		{
			if (IsVisuallyReordered(textBeforeCaret, source, precedingText))
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(92, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("  the editor returned '");
					message.AppendFormatted(textBeforeCaret);
					message.AppendLiteral("' in painted order, not stored order: offsets cannot be trusted here.");
				}
				DiagnosticLog.Write("Replace", ref message);
				EditorCapabilityStore.Observe(CurrentEditorKey(), (EditorCapabilities known) => known with
				{
					PaintedOrder = true,
					OffsetsAreStored = false
				}, "the text before the caret was returned in painted order, not stored order", source, textBeforeCaret);
				return PreviousTextSelection.Mismatch;
			}
			if (!IsLaggingBehind(textBeforeCaret, source, precedingText))
			{
				return PreviousTextSelection.Mismatch;
			}
			return PreviousTextSelection.Lagging;
		}

		private static bool TrySelectByFindText(TextPattern textPattern, TextPatternRange caret, string source)
		{
			bool shouldAppend = default;
			try
			{
				TextPatternRange textPatternRange = textPattern.DocumentRange.Clone();
				textPatternRange.MoveEndpointByRange(TextPatternRangeEndpoint.End, caret, TextPatternRangeEndpoint.Start);
				TextPatternRange textPatternRange2 = textPatternRange.FindText(source, backward: true, ignoreCase: false);
				if (textPatternRange2 == null || textPatternRange2.CompareEndpoints(TextPatternRangeEndpoint.End, caret, TextPatternRangeEndpoint.Start) != 0)
				{
					return false;
				}
				textPatternRange2.Select();
				Selection.MarkOpen();
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(48, 1, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("  selected '");
					message.AppendFormatted(source);
					message.AppendLiteral("' through the editor's own FindText.");
				}
				DiagnosticLog.Write("Replace", ref message);
				EditorCapabilityStore.Observe(CurrentEditorKey(), (EditorCapabilities known) => known with
				{
					FindsOwnText = true
				}, "the editor's FindText found the word directly before the caret", source);
				return true;
			}
			catch (Exception ex) when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				shouldAppend = ((ex is ElementNotAvailableException || ex is InvalidOperationException || ex is COMException || ex is ArgumentException || ex is NotSupportedException) ? true : false);
				return shouldAppend;
			}).Invoke())
			{
				return false;
			}
		}

		internal static bool IsLaggingBehind(string textBeforeCaret, string source, string precedingText = "")
		{
			for (int num = source.Length - 1; num >= 0; num--)
			{
				string value = source.Substring(0, num);
				if (!textBeforeCaret.EndsWith(value, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				int num2 = num;
				string text = textBeforeCaret.Substring(0, textBeforeCaret.Length - num2);
				if (text.Length != 0)
				{
					if (!char.IsWhiteSpace(text[text.Length - 1]))
					{
						if (!BidiControlCharacters.IsDirectionControl(text[text.Length - 1]) && (num != 0 || !BidiControlCharacters.EndsWithPrecedingText(text, precedingText)))
						{
							continue;
						}
					}
				}
				return true;
			}
			return false;
		}

		internal static PreviousTextSelection ResolveInPaintedOrderEditor(PreviousTextSelection selection, bool editorPaintsOutOfOrder)
		{
			if (!editorPaintsOutOfOrder || selection != PreviousTextSelection.Lagging)
			{
				return selection;
			}
			return PreviousTextSelection.Mismatch;
		}

		internal static bool AllowsBlindBackspaces(PreviousTextSelection selection)
		{
			if (selection == PreviousTextSelection.Unreadable || (uint)(selection - 3) <= 1u)
			{
				return true;
			}
			return false;
		}

		internal static bool AllowsBlindBackspaces(PreviousTextSelection selection, bool editorMustConfirm)
		{
			if (!editorMustConfirm)
			{
				return AllowsBlindBackspaces(selection);
			}
			return false;
		}

		internal static bool ShouldReadAgain(PreviousTextSelection result, int attempt)
		{
			return ShouldReadAgain(result, attempt, retriesAreWorthwhile: true);
		}

		internal static bool ShouldReadAgain(PreviousTextSelection result, int attempt, bool retriesAreWorthwhile)
		{
			bool flag = retriesAreWorthwhile;
			if (flag)
			{
				bool flag2 = ((result == PreviousTextSelection.Mismatch || result == PreviousTextSelection.Lagging) ? true : false);
				flag = flag2;
			}
			if (flag)
			{
				return attempt < 4;
			}
			return false;
		}

		internal static PreviousTextSelection? ResolveAfterClosingSelection(bool caretMoved, bool editorMustConfirm)
		{
			if (!(caretMoved & editorMustConfirm))
			{
				return null;
			}
			return PreviousTextSelection.Mismatch;
		}

		internal static bool IsVisuallyReordered(string textBeforeCaret, string source, string precedingText)
		{
			if (source.Length == 0 || precedingText.Length == 0 || textBeforeCaret.Length == 0)
			{
				return false;
			}
			if (EndsWithSource(textBeforeCaret, source))
			{
				return false;
			}
			int num = textBeforeCaret.LastIndexOf(precedingText, StringComparison.Ordinal);
			if (num <= 0)
			{
				return false;
			}
			return textBeforeCaret.Substring(0, num).Any(source.Contains);
		}

		internal static bool EndsWithSource(string textBeforeCaret, string source)
		{
			if (source.Length > 0 && textBeforeCaret.Length >= source.Length)
			{
				int length = source.Length;
				return MatchesPhysicalSourceText(textBeforeCaret.Substring(textBeforeCaret.Length - length), source);
			}
			return false;
		}

		private static bool TrySelectCurrentParagraphPrefix(string source, out string paragraphPrefix)
		{
			return TryGetCurrentParagraphPrefix(source, out paragraphPrefix, selectRange: true);
		}

		private static bool TryGetCurrentParagraphRange(out TextPattern textPattern, out TextPatternRange range, out string paragraphText)
		{
			string diagnostic;
			return TryGetCurrentParagraphRange(out textPattern, out range, out paragraphText, out diagnostic);
		}

		private static bool TryGetCurrentParagraphRange(out TextPattern textPattern, out TextPatternRange range, out string paragraphText, out string diagnostic)
		{
			textPattern = null;
			range = null;
			paragraphText = string.Empty;
			diagnostic = string.Empty;
			AutomationElement focusedElement = AutomationElement.FocusedElement;
			if ((object)focusedElement == null)
			{
				diagnostic = "No focused UI Automation element";
				return false;
			}
			if (!focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern2))
			{
				diagnostic = "Focused " + focusedElement.Current.ControlType.ProgrammaticName + " does not support TextPattern";
				return false;
			}
			TextPatternRange[] selection = textPattern2.GetSelection();
			if (selection.Length != 1)
			{
				diagnostic = $"Expected one caret range but found {selection.Length}";
				return false;
			}
			if (selection[0].CompareEndpoints(TextPatternRangeEndpoint.Start, selection[0], TextPatternRangeEndpoint.End) != 0)
			{
				diagnostic = "The active text range is a selection, not a caret";
				return false;
			}
			TextPatternRange textPatternRange = selection[0].Clone();
			textPatternRange.ExpandToEnclosingUnit(TextUnit.Paragraph);
			string text = textPatternRange.GetText(-1);
			while (text.EndsWith('\r') || text.EndsWith('\n'))
			{
				if (textPatternRange.MoveEndpointByUnit(TextPatternRangeEndpoint.End, TextUnit.Character, -1) != -1)
				{
					return false;
				}
				text = textPatternRange.GetText(-1);
			}
			textPattern = textPattern2;
			range = textPatternRange;
			paragraphText = text;
			diagnostic = ((paragraphText.Length == 0) ? "The current paragraph is empty" : "Current paragraph captured");
			return paragraphText.Length > 0;
		}

		private static bool TryGetCurrentEditableRange(out TextPattern textPattern, out TextPatternRange range, out string editableText)
		{
			textPattern = null;
			range = null;
			editableText = string.Empty;
			AutomationElement focusedElement = AutomationElement.FocusedElement;
			if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern2))
			{
				return false;
			}
			TextPatternRange[] selection = textPattern2.GetSelection();
			if (selection.Length != 1 || selection[0].CompareEndpoints(TextPatternRangeEndpoint.Start, selection[0], TextPatternRangeEndpoint.End) != 0)
			{
				return false;
			}
			TextPatternRange textPatternRange = textPattern2.DocumentRange.Clone();
			string text = textPatternRange.GetText(-1);
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			textPattern = textPattern2;
			range = textPatternRange;
			editableText = text;
			return true;
		}

		private static string DescribeCallContext()
		{
			Thread currentThread = Thread.CurrentThread;
			return $"thread='{currentThread.Name ?? "unnamed"}' apartment={currentThread.GetApartmentState()} inSendMessage=0x{NativeMethods.InSendMessageEx(IntPtr.Zero):X}";
		}

		private static bool TryGetCurrentParagraphPrefix(string source, out string paragraphPrefix, bool selectRange, ParagraphReadTrace? trace = null)
		{
			paragraphPrefix = string.Empty;
			AutomationElement element = null;
			TextPattern textPattern = null;
			TextPatternRange caretRange = null;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				element = focusedElement;
				if ((object)focusedElement == null)
				{
					trace?.Fail("no-focused-element");
					return false;
				}
				if (!focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern2))
				{
					trace?.Fail("no-text-pattern");
					return false;
				}
				textPattern = textPattern2;
				TextPatternRange[] selection = textPattern2.GetSelection();
				if (selection.Length != 1)
				{
					trace?.Fail($"selection-count={selection.Length}");
					return false;
				}
				caretRange = selection[0];
				if (selection[0].GetText(1).Length != 0)
				{
					trace?.Fail("selection-is-not-a-caret");
					return false;
				}
				TextPatternRange textPatternRange = selection[0].Clone();
				textPatternRange.ExpandToEnclosingUnit(TextUnit.Paragraph);
				textPatternRange.MoveEndpointByRange(TextPatternRangeEndpoint.End, selection[0], TextPatternRangeEndpoint.Start);
				paragraphPrefix = textPatternRange.GetText(-1);
				trace?.Answered(paragraphPrefix);
				if (paragraphPrefix.Length >= source.Length)
				{
					string obj = paragraphPrefix;
					int length = source.Length;
					if (MatchesPhysicalSourceText(obj.Substring(obj.Length - length), source))
					{
						if (selectRange)
						{
							textPatternRange.Select();
							Selection.MarkOpen();
							if (!WaitForSelectedText(textPattern2, paragraphPrefix))
							{
								paragraphPrefix = string.Empty;
								return false;
							}
						}
						trace?.Succeed();
						return true;
					}
				}
				trace?.Fail("answer-does-not-end-with-the-requested-source");
				paragraphPrefix = string.Empty;
				return false;
			}
			catch (ElementNotAvailableException)
			{
				trace?.Fail("exception:ElementNotAvailableException");
				paragraphPrefix = string.Empty;
				return false;
			}
			catch (InvalidOperationException)
			{
				trace?.Fail("exception:InvalidOperationException");
				paragraphPrefix = string.Empty;
				return false;
			}
			catch (COMException ex3)
			{
				trace?.Fail($"exception:COM 0x{ex3.HResult:X8}");
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(53, 2, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("The editor's text could not be read: COM error 0x");
					message.AppendFormatted(ex3.HResult, "X8");
					message.AppendLiteral(" (");
					message.AppendFormatted(DescribeCallContext());
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message);
				DiagnosticLog.Journal?.Incident($"com:0x{ex3.HResult:X8}", "UI Automation call failed: reading the editor text", "hresult", $"0x{ex3.HResult:X8}", "where", DescribeCallContext(), "thread", $"{Environment.CurrentManagedThreadId} '{Thread.CurrentThread.Name}' {Thread.CurrentThread.GetApartmentState()}");
				paragraphPrefix = string.Empty;
				return false;
			}
			finally
			{
				trace?.Finish(element, textPattern, caretRange);
			}
		}

		public bool CollapseOpenSelection(bool preferKeyboard = false)
		{
			return CollapseSelection(preferKeyboard);
		}

		private bool RefuseReplacement(string source, string reason)
		{
			LastReplacementContradictedEditor = true;
			DiagnosticMessageHandler message = new DiagnosticMessageHandler(24, 2, out var shouldAppend);
			if (shouldAppend)
			{
				message.AppendLiteral("Refused to replace '");
				message.AppendFormatted(source);
				message.AppendLiteral("': ");
				message.AppendFormatted(reason);
				message.AppendLiteral(".");
			}
			DiagnosticLog.Write("Replace", ref message);
			CollapseSelection(preferKeyboard: false);
			return false;
		}

		private static bool CollapseSelection(bool preferKeyboard)
		{
			if (!Selection.IsOpen)
			{
				return false;
			}
			bool flag = Selection.Close(preferKeyboard);
			DiagnosticLog.Write("Replace", flag ? "Closed the selection with the Right arrow; the caret position is no longer certain." : "Closed the selection made for the replacement; the caret is where it was.");
			return flag;
		}

		private static bool TryCollapseSelectionThroughAutomation()
		{
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return false;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1)
				{
					return false;
				}
				if (selection[0].GetText(-1).Length == 0)
				{
					return true;
				}
				TextPatternRange textPatternRange = selection[0].Clone();
				textPatternRange.MoveEndpointByRange(TextPatternRangeEndpoint.Start, textPatternRange, TextPatternRangeEndpoint.End);
				textPatternRange.Select();
				TextPatternRange[] selection2 = textPattern.GetSelection();
				return selection2.Length == 1 && selection2[0].GetText(-1).Length == 0;
			}
			catch (Exception ex) when ((ex is ElementNotAvailableException || ex is InvalidOperationException || ex is COMException) ? true : false)
			{
				return false;
			}
		}

		private static void SendCollapseKey()
		{
			InjectedInputOrder.Send(new NativeMethods.INPUT[2]
			{
				CreateKeyInput(39, '\0', 0u),
				CreateKeyInput(39, '\0', 2u)
			});
		}

		private static bool WaitForSelectedText(TextPattern textPattern, string expectedText)
		{
			for (int i = 0; i < 5; i++)
			{
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length == 1 && MatchesPhysicalSourceText(selection[0].GetText(-1), expectedText))
				{
					return true;
				}
				Thread.Sleep(5);
			}
			TextPatternRange[] selection2 = textPattern.GetSelection();
			if (selection2.Length == 1)
			{
				TextPatternRange textPatternRange = selection2[0].Clone();
				textPatternRange.MoveEndpointByRange(TextPatternRangeEndpoint.Start, textPatternRange, TextPatternRangeEndpoint.End);
				textPatternRange.Select();
			}
			return false;
		}

		private static bool MatchesPhysicalSourceText(string actualText, string expectedText)
		{
			if (string.Equals(actualText, expectedText, StringComparison.Ordinal))
			{
				return true;
			}
			if (actualText.Length == expectedText.Length && expectedText.All((char character) =>
			{
				switch (character)
				{
				case 'A':
				case 'B':
				case 'C':
				case 'D':
				case 'E':
				case 'F':
				case 'G':
				case 'H':
				case 'I':
				case 'J':
				case 'K':
				case 'L':
				case 'M':
				case 'N':
				case 'O':
				case 'P':
				case 'Q':
				case 'R':
				case 'S':
				case 'T':
				case 'U':
				case 'V':
				case 'W':
				case 'X':
				case 'Y':
				case 'Z':
				case 'a':
				case 'b':
				case 'c':
				case 'd':
				case 'e':
				case 'f':
				case 'g':
				case 'h':
				case 'i':
				case 'j':
				case 'k':
				case 'l':
				case 'm':
				case 'n':
				case 'o':
				case 'p':
				case 'q':
				case 'r':
				case 's':
				case 't':
				case 'u':
				case 'v':
				case 'w':
				case 'x':
				case 'y':
				case 'z':
					return true;
				default:
					return false;
				}
			}))
			{
				return string.Equals(actualText, expectedText, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		private static bool TryReplaceSelectedText(nint targetWindow, string replacement)
		{
			if (targetWindow == IntPtr.Zero)
			{
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			if (NativeMethods.GetClassName(targetWindow, stringBuilder, stringBuilder.Capacity) == 0)
			{
				return false;
			}
			if (!stringBuilder.ToString().Contains("Edit", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			NativeMethods.SendMessage(targetWindow, 194u, new IntPtr(1), replacement);
			return true;
		}

		private static void AddControlShiftShortcut(ICollection<NativeMethods.INPUT> inputs, char shiftScanCode)
		{
			inputs.Add(CreateKeyInput(17, '\0', 0u));
			inputs.Add(CreateKeyInput(0, shiftScanCode, 8u));
			inputs.Add(CreateKeyInput(0, shiftScanCode, 10u));
			inputs.Add(CreateKeyInput(17, '\0', 2u));
		}

		private static void AddVirtualKeyPress(ICollection<NativeMethods.INPUT> inputs, ushort virtualKey)
		{
			inputs.Add(CreateKeyInput(virtualKey, '\0', 0u));
			inputs.Add(CreateKeyInput(virtualKey, '\0', 2u));
		}

		private static void AddUnicodeCharacter(ICollection<NativeMethods.INPUT> inputs, char character)
		{
			inputs.Add(CreateKeyInput(0, character, 4u));
			inputs.Add(CreateKeyInput(0, character, 6u));
		}

		private static NativeMethods.INPUT CreateKeyInput(ushort virtualKey, char scanCode, uint flags)
		{
			return new NativeMethods.INPUT
			{
				type = 1u,
				U = new NativeMethods.InputUnion
				{
					ki = new NativeMethods.KEYBDINPUT
					{
						wVk = virtualKey,
						wScan = scanCode,
						dwFlags = flags,
						time = 0u,
						dwExtraInfo = NativeMethods.SmartInputInjectedInputMarker
					}
				}
			};
		}
	}
	public static class NonTextTargetPolicy
	{
		private static readonly HashSet<string> NonTextControlTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Menu", "MenuBar", "MenuItem", "Button", "SplitButton" };

		public static bool IsNonTextControl(string? controlType)
		{
			if (!string.IsNullOrEmpty(controlType))
			{
				return NonTextControlTypes.Contains(controlType);
			}
			return false;
		}
	}
	[Flags]
	public enum ParagraphDirectionHost
	{
		None = 0,
		OwnsParagraphDirection = 1,
		RefusesPrefixRewrite = 2
	}
	public static class ParagraphDirectionRoute
	{
		private sealed record Answer(nint Window, uint ProcessId, nint Foreground, uint ForegroundProcessId, ParagraphDirectionHost Host);

		private static Answer? _last;

		private static readonly string[] NativeDirectionClasses = new string[4] { "_WwG", "Edit", "RICHEDIT50W", "RichEditD2DPT" };

		private static readonly string[] ConsoleClasses = new string[6] { "ConsoleWindowClass", "CASCADIA_HOSTING_WINDOW_CLASS", "PseudoConsoleWindow", "mintty", "VirtualConsoleClass", "PuTTY" };

		private static readonly string[] RefusingProcesses = new string[16]
		{
			"WINWORD", "OUTLOOK", "POWERPNT", "EXCEL", "ONENOTE", "MSACCESS", "olk", "ms-teams", "Notepad", "wordpad",
			"WindowsTerminal", "OpenConsole", "conhost", "cmd", "powershell", "pwsh"
		};

		private static readonly string[] WindowsFormsNativeDirectionPrefixes = new string[3] { "WindowsForms10.EDIT.", "WindowsForms10.RichEdit20", "WindowsForms10.RICHEDIT50W." };

		public static ParagraphDirectionHost Classify(string processName, string windowClass)
		{
			ParagraphDirectionHost paragraphDirectionHost = ParagraphDirectionHost.None;
			if (IsNativeDirectionClass(windowClass))
			{
				paragraphDirectionHost |= ParagraphDirectionHost.OwnsParagraphDirection | ParagraphDirectionHost.RefusesPrefixRewrite;
			}
			if (ConsoleClasses.Contains(windowClass, StringComparer.Ordinal) || RefusingProcesses.Contains(processName, StringComparer.OrdinalIgnoreCase))
			{
				paragraphDirectionHost |= ParagraphDirectionHost.RefusesPrefixRewrite;
			}
			return paragraphDirectionHost;
		}

		public static ParagraphDirectionHost Classify(string processName, string windowClass, string? foregroundProcessName)
		{
			ParagraphDirectionHost paragraphDirectionHost = Classify(processName, windowClass);
			if (foregroundProcessName == null || RefusingProcesses.Contains(foregroundProcessName, StringComparer.OrdinalIgnoreCase))
			{
				paragraphDirectionHost |= ParagraphDirectionHost.RefusesPrefixRewrite;
			}
			return paragraphDirectionHost;
		}

		public static ParagraphDirectionHost Focused()
		{
			nint num = UnicodeBatchLossRoute.FocusedWindow();
			if (num == IntPtr.Zero)
			{
				return ParagraphDirectionHost.None;
			}
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			NativeMethods.GetWindowThreadProcessId(num, out var lpdwProcessId);
			uint lpdwProcessId2 = 0u;
			if (foregroundWindow != IntPtr.Zero)
			{
				NativeMethods.GetWindowThreadProcessId(foregroundWindow, out lpdwProcessId2);
			}
			Answer answer = Volatile.Read(in _last);
			if ((object)answer != null && answer.Window == num && answer.ProcessId == lpdwProcessId && answer.Foreground == foregroundWindow && answer.ForegroundProcessId == lpdwProcessId2)
			{
				return answer.Host;
			}
			string text = UnicodeBatchLossRoute.ProcessNameOf(num);
			if (foregroundWindow == IntPtr.Zero)
			{
				return Classify(text, UnicodeBatchLossRoute.ClassNameOf(num), null);
			}
			string foregroundProcessName = ((lpdwProcessId2 == lpdwProcessId) ? text : UnicodeBatchLossRoute.ProcessNameOf(foregroundWindow));
			ParagraphDirectionHost paragraphDirectionHost = Classify(text, UnicodeBatchLossRoute.ClassNameOf(num), foregroundProcessName);
			Volatile.Write(ref _last, new Answer(num, lpdwProcessId, foregroundWindow, lpdwProcessId2, paragraphDirectionHost));
			return paragraphDirectionHost;
		}

		private static bool IsNativeDirectionClass(string windowClass)
		{
			if (!NativeDirectionClasses.Contains(windowClass, StringComparer.Ordinal) && !windowClass.StartsWith("RichEdit20", StringComparison.Ordinal))
			{
				return WindowsFormsNativeDirectionPrefixes.Any((string prefix) => windowClass.StartsWith(prefix, StringComparison.Ordinal));
			}
			return true;
		}
	}
	public sealed record ElementObservation(int ProcessId, string ProcessName, string ControlType, string Framework, string ClassName, string AutomationId, int NativeWindowHandle, bool HasKeyboardFocus, string RuntimeId, bool? SameElementFocusedAgain, string Name, string HelpText, string? Value);
	public sealed record DocumentObservation(string DocumentText, bool? CaretAtStart, bool? CaretAtEnd);
	public sealed class ParagraphReadTrace
	{
		private const int DocumentProbeLength = 512;

		private const int SampleLength = 16;

		private const int IdentityLength = 40;

		private static long lastReadId;

		private static (int Pid, string Name) cachedProcess;

		private readonly object gate = new object();

		private readonly Func<long> nowMilliseconds;

		private readonly List<KeyValuePair<string, string>> original = new List<KeyValuePair<string, string>>();

		private readonly List<KeyValuePair<string, string>> later = new List<KeyValuePair<string, string>>();

		private readonly long startedAt;

		private long endedAt = -1L;

		private AutomationElement? focused;

		private TextPattern? pattern;

		private TextPatternRange? caret;

		private string answer = string.Empty;

		private string outcome = "not-finished";

		private bool laterRecorded;

		public long ReadId { get; }

		internal Func<ElementObservation?>? ElementSource { get; set; }

		internal Func<DocumentObservation?>? DocumentSource { get; set; }

		public IReadOnlyList<KeyValuePair<string, string>> Original
		{
			get
			{
				lock (gate)
				{
					return new <>z__ReadOnlyArray<KeyValuePair<string, string>>(original.ToArray());
				}
			}
		}

		public IReadOnlyList<KeyValuePair<string, string>> Later
		{
			get
			{
				lock (gate)
				{
					return new <>z__ReadOnlyArray<KeyValuePair<string, string>>(later.ToArray());
				}
			}
		}

		public string Reference
		{
			get
			{
				lock (gate)
				{
					return $"#{ReadId} {outcome} len={answer.Length.ToString(CultureInfo.InvariantCulture)}";
				}
			}
		}

		private ParagraphReadTrace(long readId, Func<long> clock)
		{
			ReadId = readId;
			nowMilliseconds = clock;
			startedAt = clock();
		}

		internal static ParagraphReadTrace Begin(string route, Func<long>? clock = null)
		{
			ParagraphReadTrace paragraphReadTrace = new ParagraphReadTrace(Interlocked.Increment(ref lastReadId), clock ?? new Func<long>(StopwatchMilliseconds));
			paragraphReadTrace.AddOriginal("route", route);
			paragraphReadTrace.AddOriginal("thread", Environment.CurrentManagedThreadId.ToString(CultureInfo.InvariantCulture));
			return paragraphReadTrace;
		}

		private static long StopwatchMilliseconds()
		{
			return Stopwatch.GetTimestamp() * 1000 / Stopwatch.Frequency;
		}

		internal void AddOriginal(string name, string value)
		{
			lock (gate)
			{
				original.Add(new KeyValuePair<string, string>(name, value));
			}
		}

		internal void Fail(string reason)
		{
			lock (gate)
			{
				outcome = reason;
			}
		}

		internal void Succeed()
		{
			lock (gate)
			{
				outcome = "ok";
			}
		}

		internal void Answered(string text)
		{
			lock (gate)
			{
				answer = text;
			}
			AddOriginal("answerLen", text.Length.ToString(CultureInfo.InvariantCulture));
			if (text.Length <= 32)
			{
				AddOriginal("answer", DiagnosticLog.Visible(text));
				return;
			}
			AddOriginal("answerHead", DiagnosticLog.Visible(text.Substring(0, 16)));
			AddOriginal("answerTail", DiagnosticLog.Visible(text.Substring(text.Length - 16)));
		}

		internal void Finish(AutomationElement? element, TextPattern? textPattern, TextPatternRange? caretRange)
		{
			long num = nowMilliseconds();
			lock (gate)
			{
				focused = element;
				pattern = textPattern;
				caret = caretRange;
				endedAt = num;
				original.Add(new KeyValuePair<string, string>("readOutcome", outcome));
				original.Add(new KeyValuePair<string, string>("readMs", (num - startedAt).ToString(CultureInfo.InvariantCulture)));
			}
		}

		public void Skip(string reason)
		{
			lock (gate)
			{
				if (!laterRecorded)
				{
					laterRecorded = true;
					focused = null;
					pattern = null;
					caret = null;
					later.Add(new KeyValuePair<string, string>("status", "skipped:" + reason));
					later.Add(new KeyValuePair<string, string>("basis", "nothing was asked of the element; only the original read is recorded"));
				}
			}
		}

		public void Enrich(Func<bool> keepGoing)
		{
			AutomationElement element;
			TextPattern textPattern;
			TextPatternRange caretRange;
			lock (gate)
			{
				if (laterRecorded)
				{
					return;
				}
				laterRecorded = true;
				element = focused;
				textPattern = pattern;
				caretRange = caret;
				focused = null;
				pattern = null;
				caret = null;
			}
			long begunAt = nowMilliseconds();
			ElementObservation element2 = null;
			DocumentObservation documentObservation = null;
			string elementStatus = "not-held";
			string text = "not-held";
			string caretStatus = "not-held";
			if (!keepGoing())
			{
				RecordLater(begunAt, nowMilliseconds(), null, "abandoned:session-ended", null, "abandoned:session-ended", "abandoned:session-ended");
				return;
			}
			Func<ElementObservation> elementSource = ElementSource;
			if (elementSource != null)
			{
				(element2, elementStatus) = Observe(elementSource);
			}
			else if ((object)element != null)
			{
				(element2, elementStatus) = Observe(() => ObserveElement(element));
			}
			if (!keepGoing())
			{
				RecordLater(begunAt, nowMilliseconds(), element2, elementStatus, null, "abandoned:session-ended", "abandoned:session-ended");
				return;
			}
			Func<DocumentObservation> documentSource = DocumentSource;
			if (documentSource != null)
			{
				(DocumentObservation? Value, string Status) tuple3 = Observe(documentSource);
				documentObservation = tuple3.Value;
				text = tuple3.Status;
				caretStatus = (((object)documentObservation == null) ? text : "ok");
			}
			else if (textPattern != null)
			{
				(DocumentObservation? Value, string Status) tuple4 = Observe(() => ObserveDocument(textPattern, caretRange));
				documentObservation = tuple4.Value;
				text = tuple4.Status;
				if (caretRange == null)
				{
					caretStatus = "not-held";
				}
				else
				{
					caretStatus = (((object)documentObservation == null) ? text : "ok");
				}
			}
			RecordLater(begunAt, nowMilliseconds(), element2, elementStatus, documentObservation, text, caretStatus);
		}

		private static (T? Value, string Status) Observe<T>(Func<T?> ask) where T : class
		{
			try
			{
				T val = ask();
				return (Value: val, Status: (val == null) ? "not-available" : "ok");
			}
			catch (Exception ex) when ((ex is ElementNotAvailableException || ex is InvalidOperationException || ex is COMException) ? true : false)
			{
				return (Value: null, Status: "failed:" + ex.GetType().Name);
			}
		}

		internal void RecordLater(long begunAt, long endedAtLater, ElementObservation? element, string elementStatus, DocumentObservation? document, string documentStatus, string caretStatus)
		{
			string text;
			long num;
			lock (gate)
			{
				text = answer;
				num = endedAt;
			}
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("status", "observed"),
				new KeyValuePair<string, string>("basis", "asked after the read; may differ from what the read saw"),
				new KeyValuePair<string, string>("sinceReadEndMs", (num < 0) ? "unknown(read not finished)" : (begunAt - num).ToString(CultureInfo.InvariantCulture)),
				new KeyValuePair<string, string>("askedForMs", (endedAtLater - begunAt).ToString(CultureInfo.InvariantCulture)),
				new KeyValuePair<string, string>("sinceReadEndAtDoneMs", (num < 0) ? "unknown(read not finished)" : (endedAtLater - num).ToString(CultureInfo.InvariantCulture)),
				new KeyValuePair<string, string>("elementStatus", elementStatus)
			};
			if ((object)element != null)
			{
				list.Add(new KeyValuePair<string, string>("pid", element.ProcessId.ToString(CultureInfo.InvariantCulture)));
				list.Add(new KeyValuePair<string, string>("proc", Cap(element.ProcessName)));
				list.Add(new KeyValuePair<string, string>("type", Cap(element.ControlType)));
				list.Add(new KeyValuePair<string, string>("framework", Cap(element.Framework)));
				list.Add(new KeyValuePair<string, string>("class", Cap(element.ClassName)));
				list.Add(new KeyValuePair<string, string>("autoId", Cap(element.AutomationId)));
				list.Add(new KeyValuePair<string, string>("elemHwnd", (element.NativeWindowHandle == 0) ? "0(no window of its own)" : element.NativeWindowHandle.ToString("X", CultureInfo.InvariantCulture)));
				list.Add(new KeyValuePair<string, string>("hasKeyboardFocus", element.HasKeyboardFocus ? "true" : "false"));
				list.Add(new KeyValuePair<string, string>("runtimeId", Cap(element.RuntimeId)));
				list.Add(new KeyValuePair<string, string>("sameElementFocusedAgain", Tri(element.SameElementFocusedAgain)));
				AddTextSource(list, "name", element.Name, text);
				AddTextSource(list, "help", element.HelpText, text);
				if (element.Value == null)
				{
					list.Add(new KeyValuePair<string, string>("value", "no ValuePattern"));
				}
				else
				{
					AddTextSource(list, "value", element.Value, text);
				}
			}
			list.Add(new KeyValuePair<string, string>("documentStatus", documentStatus));
			if ((object)document != null)
			{
				bool flag = document.DocumentText.Length >= 512;
				list.Add(new KeyValuePair<string, string>("docLen", document.DocumentText.Length.ToString(CultureInfo.InvariantCulture) + (flag ? "+" : string.Empty)));
				list.Add(new KeyValuePair<string, string>("docHead", Sample(document.DocumentText)));
				List<KeyValuePair<string, string>> list2 = list;
				string value;
				if (flag)
				{
					value = "document longer than the probe";
				}
				else if (text.Length != 0)
				{
					if (string.Equals(document.DocumentText, text, StringComparison.Ordinal))
					{
						value = "answer is the whole document (exact)";
					}
					else
					{
						value = (document.DocumentText.StartsWith(text, StringComparison.Ordinal) ? "document starts with the answer (exact)" : "different");
					}
				}
				else
				{
					value = "empty answer";
				}
				list2.Add(new KeyValuePair<string, string>("answerVsDocument", value));
			}
			list.Add(new KeyValuePair<string, string>("caretStatus", caretStatus));
			if ((object)document != null)
			{
				list.Add(new KeyValuePair<string, string>("caretAtDocStart", Tri(document.CaretAtStart)));
				list.Add(new KeyValuePair<string, string>("caretAtDocEnd", Tri(document.CaretAtEnd)));
			}
			lock (gate)
			{
				later.AddRange(list);
			}
		}

		private static void AddTextSource(List<KeyValuePair<string, string>> list, string label, string text, string answerText)
		{
			list.Add(new KeyValuePair<string, string>(label + "Len", text.Length.ToString(CultureInfo.InvariantCulture)));
			if (text.Length > 0)
			{
				list.Add(new KeyValuePair<string, string>(label + "Sample", Sample(text)));
			}
			List<KeyValuePair<string, string>> list2 = list;
			string key = "answerVsLater" + char.ToUpperInvariant(label[0]) + label.Substring(1);
			string value;
			if (answerText.Length != 0)
			{
				if (string.Equals(answerText, text, StringComparison.Ordinal))
				{
					value = "equal (exact)";
				}
				else
				{
					value = (string.Equals(answerText.Trim(), text.Trim(), StringComparison.Ordinal) ? "equal only after trimming" : "different");
				}
			}
			else
			{
				value = "empty answer";
			}
			list2.Add(new KeyValuePair<string, string>(key, value));
		}

		private static string Tri(bool? value)
		{
			if (!value.HasValue)
			{
				return "unavailable";
			}
			if (value != true)
			{
				return "false";
			}
			return "true";
		}

		private static string Sample(string text)
		{
			return DiagnosticLog.Visible((text.Length <= 16) ? text : (text.Substring(0, 16) + "…"));
		}

		private static string Cap(string? value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				return DiagnosticLog.Visible((value.Length <= 40) ? value : (value.Substring(0, 40) + "…"));
			}
			return "(none)";
		}

		private static ElementObservation ObserveElement(AutomationElement element)
		{
			AutomationElement.AutomationElementInformation current = element.Current;
			int[] array = element.GetRuntimeId() ?? Array.Empty<int>();
			AutomationElement focusedElement = AutomationElement.FocusedElement;
			bool? flag;
			if ((object)focusedElement != null)
			{
				int[] runtimeId = focusedElement.GetRuntimeId();
				flag = ((runtimeId != null) ? new bool?(((ReadOnlySpan<int>)array.AsSpan()).SequenceEqual((ReadOnlySpan<int>)runtimeId)) : ((bool?)null));
			}
			else
			{
				flag = false;
			}
			bool? sameElementFocusedAgain = flag;
			string value = null;
			if (element.TryGetCurrentPattern(ValuePattern.Pattern, out var patternObject) && patternObject is ValuePattern { Current: var current2 })
			{
				value = current2.Value ?? string.Empty;
			}
			return new ElementObservation(current.ProcessId, ProcessName(current.ProcessId), current.ControlType.ProgrammaticName.Replace("ControlType.", string.Empty, StringComparison.Ordinal), current.FrameworkId ?? string.Empty, current.ClassName ?? string.Empty, current.AutomationId ?? string.Empty, current.NativeWindowHandle, current.HasKeyboardFocus, string.Join('.', array), sameElementFocusedAgain, current.Name ?? string.Empty, current.HelpText ?? string.Empty, value);
		}

		private static DocumentObservation ObserveDocument(TextPattern textPattern, TextPatternRange? caretRange)
		{
			TextPatternRange documentRange = textPattern.DocumentRange;
			string text = documentRange.GetText(512);
			bool? caretAtStart = null;
			bool? caretAtEnd = null;
			if (caretRange != null)
			{
				caretAtStart = caretRange.CompareEndpoints(TextPatternRangeEndpoint.Start, documentRange, TextPatternRangeEndpoint.Start) == 0;
				caretAtEnd = caretRange.CompareEndpoints(TextPatternRangeEndpoint.End, documentRange, TextPatternRangeEndpoint.End) == 0;
			}
			return new DocumentObservation(text, caretAtStart, caretAtEnd);
		}

		private static string ProcessName(int processId)
		{
			(int, string) tuple = cachedProcess;
			if (tuple.Item1 == processId)
			{
				return tuple.Item2;
			}
			string text = "?";
			try
			{
				using Process process = Process.GetProcessById(processId);
				text = process.ProcessName;
			}
			catch (Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException) ? true : false)
			{
			}
			cachedProcess = (Pid: processId, Name: text);
			return text;
		}
	}
	public static class PersianDigitRoute
	{
		private sealed record Answer(nint Window, uint ProcessId, nint Foreground, uint ForegroundProcessId, bool Excluded);

		private static Answer? _last;

		private static readonly string[] Spreadsheets = new string[5] { "excel", "soffice", "et", "gnumeric", "calc" };

		private static readonly string[] CodeEditors = new string[22]
		{
			"code", "code - insiders", "cursor", "windsurf", "devenv", "rider64", "idea64", "pycharm64", "webstorm64", "clion64",
			"goland64", "phpstorm64", "rubymine64", "datagrip64", "androidstudio64", "sublime_text", "notepad++", "atom", "zed", "gvim",
			"nvim-qt", "emacs"
		};

		internal static readonly string[] Terminals = new string[15]
		{
			"windowsterminal", "openconsole", "conhost", "cmd", "powershell", "pwsh", "wezterm-gui", "alacritty", "mintty", "putty",
			"conemu", "conemu64", "kitty", "hyper", "tabby"
		};

		internal static readonly string[] ConsoleClasses = new string[6] { "ConsoleWindowClass", "CASCADIA_HOSTING_WINDOW_CLASS", "PseudoConsoleWindow", "mintty", "VirtualConsoleClass", "PuTTY" };

		public static bool IsExcluded(string processName, string windowClass)
		{
			if (!IsExcludedProcess(processName))
			{
				return ConsoleClasses.Contains(windowClass, StringComparer.Ordinal);
			}
			return true;
		}

		public static bool IsExcludedProcess(string? processName)
		{
			if (!string.IsNullOrEmpty(processName))
			{
				if (!Spreadsheets.Contains(processName, StringComparer.OrdinalIgnoreCase) && !CodeEditors.Contains(processName, StringComparer.OrdinalIgnoreCase))
				{
					return Terminals.Contains(processName, StringComparer.OrdinalIgnoreCase);
				}
				return true;
			}
			return false;
		}

		public static bool Focused()
		{
			nint num = UnicodeBatchLossRoute.FocusedWindow();
			if (num == IntPtr.Zero)
			{
				return false;
			}
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			NativeMethods.GetWindowThreadProcessId(num, out var lpdwProcessId);
			uint lpdwProcessId2 = 0u;
			if (foregroundWindow != IntPtr.Zero)
			{
				NativeMethods.GetWindowThreadProcessId(foregroundWindow, out lpdwProcessId2);
			}
			Answer answer = Volatile.Read(in _last);
			if ((object)answer != null && answer.Window == num && answer.ProcessId == lpdwProcessId && answer.Foreground == foregroundWindow && answer.ForegroundProcessId == lpdwProcessId2)
			{
				return answer.Excluded;
			}
			bool flag = IsExcluded(UnicodeBatchLossRoute.ProcessNameOf(num), UnicodeBatchLossRoute.ClassNameOf(num));
			if (!flag && foregroundWindow != IntPtr.Zero && lpdwProcessId2 != lpdwProcessId)
			{
				flag = IsExcludedProcess(UnicodeBatchLossRoute.ProcessNameOf(foregroundWindow));
			}
			Volatile.Write(ref _last, new Answer(num, lpdwProcessId, foregroundWindow, lpdwProcessId2, flag));
			return flag;
		}
	}
	public static class PhysicalKeyState
	{
		public static bool IsDown(int virtualKey)
		{
			return (NativeMethods.GetAsyncKeyState(virtualKey) & 0x8000) != 0;
		}
	}
	internal sealed class SelectionGuard
	{
		private readonly Func<bool> _closeThroughAutomation;

		private readonly Action _closeWithEditorKey;

		public bool IsOpen { get; private set; }

		public SelectionGuard(Func<bool> closeThroughAutomation, Action closeWithEditorKey)
		{
			_closeThroughAutomation = closeThroughAutomation;
			_closeWithEditorKey = closeWithEditorKey;
		}

		public void MarkOpen()
		{
			IsOpen = true;
		}

		public void MarkConsumed()
		{
			IsOpen = false;
		}

		public bool Close(bool preferKeyboard)
		{
			if (!IsOpen)
			{
				return false;
			}
			IsOpen = false;
			if (!preferKeyboard && _closeThroughAutomation())
			{
				return false;
			}
			_closeWithEditorKey();
			return true;
		}
	}
	public static class TechnicalTextFieldClassifier
	{
		private static readonly HashSet<string> BrowserProcesses = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "arc", "brave", "chrome", "firefox", "msedge", "opera", "opera_gx", "vivaldi" };

		private static readonly string[] AddressFieldMarkers = new string[4] { "address and search", "address bar", "location bar", "url bar" };

		private static readonly string[] StrongAddressFieldMarkers = new string[2] { "omnibox", "urlbar" };

		private static readonly HashSet<string> UrlSchemes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "about", "chrome", "edge", "file", "ftp", "http", "https", "ws", "wss" };

		private static readonly string[] PaymentFieldMarkers = new string[12]
		{
			"name-on-card", "nameoncard", "cardholder", "card-number", "cardnumber", "card number", "cc-name", "cc-number", "cc-exp", "cc-csc",
			"cvc", "cvv"
		};

		public const string NotProtected = "none";

		public const string AddressBarTurnedOff = "none:address-bar-turned-off";

		public const string WebAddressTurnedOff = "none:url-value-turned-off";

		public static bool IsProtected(TechnicalTextFieldSnapshot field, bool protectPaymentFields = false, bool protectAddressBars = true, bool protectWebAddressValues = true)
		{
			return Protects(ProtectionReason(field, protectPaymentFields, protectAddressBars, protectWebAddressValues));
		}

		public static bool Protects(string reason)
		{
			return !reason.StartsWith("none", StringComparison.Ordinal);
		}

		public static string ProtectionReason(TechnicalTextFieldSnapshot field, bool protectPaymentFields = false, bool protectAddressBars = true, bool protectWebAddressValues = true)
		{
			if (field.IsPassword)
			{
				return "password";
			}
			if (!protectAddressBars && IsAddressBar(field))
			{
				return "none:address-bar-turned-off";
			}
			string result = "none";
			if (LooksLikeUrl(field.Value))
			{
				if (protectWebAddressValues)
				{
					return "url-value";
				}
				result = "none:url-value-turned-off";
			}
			if (!string.Equals(field.ControlType, "Edit", StringComparison.OrdinalIgnoreCase))
			{
				return result;
			}
			InlineArray3<string> buffer = default;
			buffer[0] = field.Name;
			buffer[1] = field.AutomationId;
			buffer[2] = field.ClassName;
			string metadata = string.Join(' ', (ReadOnlySpan<string?>)buffer);
			if (StrongAddressFieldMarkers.Any((string marker) => metadata.Contains(marker, StringComparison.OrdinalIgnoreCase)))
			{
				return "address-bar";
			}
			if (protectPaymentFields)
			{
				string text = PaymentFieldMarkers.FirstOrDefault((string marker) => metadata.Contains(marker, StringComparison.OrdinalIgnoreCase));
				if (text != null)
				{
					return "payment:" + text;
				}
			}
			if (!BrowserProcesses.Contains(field.ProcessName))
			{
				return result;
			}
			if (!AddressFieldMarkers.Any((string marker) => metadata.Contains(marker, StringComparison.OrdinalIgnoreCase)))
			{
				return result;
			}
			return "address-bar";
		}

		public static bool IsAddressBar(TechnicalTextFieldSnapshot field)
		{
			if (!string.Equals(field.ControlType, "Edit", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			InlineArray3<string> buffer = default;
			buffer[0] = field.Name;
			buffer[1] = field.AutomationId;
			buffer[2] = field.ClassName;
			string metadata = string.Join(' ', (ReadOnlySpan<string?>)buffer);
			if (!StrongAddressFieldMarkers.Any((string marker) => metadata.Contains(marker, StringComparison.OrdinalIgnoreCase)))
			{
				if (BrowserProcesses.Contains(field.ProcessName))
				{
					return AddressFieldMarkers.Any((string marker) => metadata.Contains(marker, StringComparison.OrdinalIgnoreCase));
				}
				return false;
			}
			return true;
		}

		public static bool LooksLikeUrl(string value)
		{
			string text = value.Trim();
			if (text.Length == 0 || text.Any(char.IsWhiteSpace))
			{
				return false;
			}
			bool flag = Uri.TryCreate(text, UriKind.Absolute, out Uri result) && UrlSchemes.Contains(result.Scheme);
			if (flag)
			{
				bool flag2 = !string.IsNullOrWhiteSpace(result.Host);
				if (!flag2)
				{
					bool flag3;
					switch (result.Scheme)
					{
					case "about":
					case "chrome":
					case "edge":
					case "file":
						flag3 = true;
						break;
					default:
						flag3 = false;
						break;
					}
					flag2 = flag3;
				}
				flag = flag2;
			}
			if (flag)
			{
				return true;
			}
			if (text.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			int num = text.IndexOf('/');
			string text2 = ((num >= 0) ? text.Substring(0, num) : text);
			bool flag4 = text2.Count((char character) => character == '.') == 3 && IPAddress.TryParse(text2, out IPAddress address) && address.AddressFamily == AddressFamily.InterNetwork;
			if (text2.Contains('.') && text2.Length >= 4 && text2.All((char character) =>
			{
				bool flag5 = char.IsLetterOrDigit(character);
				if (!flag5)
				{
					bool flag6 = ((character == '-' || character == '.') ? true : false);
					flag5 = flag6;
				}
				return flag5;
			}))
			{
				return text2.Any(char.IsLetter) | flag4;
			}
			return false;
		}
	}
	public sealed record TechnicalTextFieldSnapshot(string ProcessName, string ControlType, string Name, string AutomationId, string ClassName, string Value, bool IsPassword);
	public sealed record TypingTargetFacts(string Process, string WindowClass, string TopLevelClass, string Title, string ElementControlType, string ElementClass, string ElementAutomationId, string ElementName, string EditorKey, string Capabilities, bool LosesUnicodeBatches, string ProtectionReason = "")
	{
		public string Application
		{
			get
			{
				string text = ElementClass.Trim();
				int num = text.IndexOf(' ', StringComparison.Ordinal);
				string text2 = ((num < 0) ? text : text.Substring(0, num));
				return Process + "|" + ((text2.Length > 0) ? text2 : WindowClass);
			}
		}

		public string Signature
		{
			get
			{
				InlineArray7<string> buffer = default;
				buffer[0] = Process;
				buffer[1] = WindowClass;
				buffer[2] = TopLevelClass;
				buffer[3] = Title;
				buffer[4] = ElementControlType;
				buffer[5] = ElementClass;
				buffer[6] = ElementAutomationId;
				return string.Join('|', (ReadOnlySpan<string?>)buffer);
			}
		}

		public const int TitleLength = 100;

		private const int ElementTextLength = 40;

		private static TechnicalTextFieldSnapshot? lastCheckedElement;

		private static string lastProtectionReason = string.Empty;

		internal static void RememberCheckedElement(TechnicalTextFieldSnapshot snapshot, string protectionReason = "")
		{
			if (DiagnosticLog.IsEnabled)
			{
				Volatile.Write(ref lastProtectionReason, protectionReason);
				Volatile.Write(ref lastCheckedElement, snapshot);
			}
		}

		internal static TypingTargetFacts Describe(nint targetWindow, nint topLevelWindow, string editorKey, string capabilities, bool losesUnicodeBatches, bool includeElement)
		{
			string process = "?";
			if (targetWindow != IntPtr.Zero || topLevelWindow != IntPtr.Zero)
			{
				NativeMethods.GetWindowThreadProcessId((targetWindow != IntPtr.Zero) ? targetWindow : topLevelWindow, out var lpdwProcessId);
				try
				{
					using Process process2 = System.Diagnostics.Process.GetProcessById((int)lpdwProcessId);
					process = process2.ProcessName;
				}
				catch (Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException) ? true : false)
				{
				}
			}
			TechnicalTextFieldSnapshot technicalTextFieldSnapshot = (includeElement ? Volatile.Read(in lastCheckedElement) : null);
			return new TypingTargetFacts(process, ClassOf(targetWindow), ClassOf(topLevelWindow), TitleOf(topLevelWindow), technicalTextFieldSnapshot?.ControlType ?? string.Empty, Cut(technicalTextFieldSnapshot?.ClassName), Cut(technicalTextFieldSnapshot?.AutomationId), Cut(technicalTextFieldSnapshot?.Name), editorKey, capabilities, losesUnicodeBatches, ((object)technicalTextFieldSnapshot == null) ? string.Empty : Volatile.Read(in lastProtectionReason));
		}

		private static string ClassOf(nint window)
		{
			if (window == IntPtr.Zero)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			if (NativeMethods.GetClassName(window, stringBuilder, stringBuilder.Capacity) == 0)
			{
				return string.Empty;
			}
			return stringBuilder.ToString();
		}

		private static string TitleOf(nint window)
		{
			if (window == IntPtr.Zero)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder(201);
			if (NativeMethods.GetWindowText(window, stringBuilder, stringBuilder.Capacity) <= 0)
			{
				return string.Empty;
			}
			string text = stringBuilder.ToString();
			if (text.Length > 100)
			{
				return text.Substring(0, 100) + "…";
			}
			return text;
		}

		private static string Cut(string? value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (value.Length > 40)
				{
					return value.Substring(0, 40) + "…";
				}
				return value;
			}
			return string.Empty;
		}
	}
	public static class UnfaithfulTextRoute
	{
		public static bool ContainsArabicScript(string? text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			foreach (char c in text)
			{
				if (c >= 'ﭐ')
				{
					if (c >= 'ﹰ')
					{
						if (c <= '\ufeff')
						{
							goto IL_0066;
						}
					}
					else if (c <= '﷿')
					{
						goto IL_0066;
					}
				}
				else if (c >= 'ݐ')
				{
					if (c <= 'ݿ' || c == '\u200c')
					{
						goto IL_0066;
					}
				}
				else if (c >= '\u0600' && c <= 'ۿ')
				{
					goto IL_0066;
				}
				bool flag = false;
				goto IL_006c;
				IL_0066:
				flag = true;
				goto IL_006c;
				IL_006c:
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		public static bool IsDemonstratedRoute(string processName, int nativeWindowHandle)
		{
			if (nativeWindowHandle == 0)
			{
				return string.Equals(processName, "msedge", StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		public static bool Refuses(string processName, int nativeWindowHandle, string? text)
		{
			if (IsDemonstratedRoute(processName, nativeWindowHandle))
			{
				return ContainsArabicScript(text);
			}
			return false;
		}
	}
	public static class UnicodeBatchLossRoute
	{
		private sealed record Answer(nint Window, bool OnRoute);

		private static Answer? _last;

		public static bool IsDemonstratedRoute(string processName, string windowClass)
		{
			if (string.Equals(processName, "Notepad", StringComparison.OrdinalIgnoreCase))
			{
				return string.Equals(windowClass, "RichEditD2DPT", StringComparison.Ordinal);
			}
			return false;
		}

		public static bool IsFocused()
		{
			nint num = FocusedWindow();
			if (num == IntPtr.Zero)
			{
				return false;
			}
			Answer answer = Volatile.Read(in _last);
			if ((object)answer != null && answer.Window == num)
			{
				return answer.OnRoute;
			}
			bool flag = IsDemonstratedRoute(ProcessNameOf(num), ClassNameOf(num));
			Volatile.Write(ref _last, new Answer(num, flag));
			return flag;
		}

		internal static nint FocusedWindow()
		{
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(foregroundWindow, out var _);
			NativeMethods.GUITHREADINFO lpgui = new NativeMethods.GUITHREADINFO
			{
				cbSize = (uint)Marshal.SizeOf<NativeMethods.GUITHREADINFO>()
			};
			if (windowThreadProcessId == 0 || !NativeMethods.GetGUIThreadInfo(windowThreadProcessId, ref lpgui) || lpgui.hwndFocus == IntPtr.Zero)
			{
				return foregroundWindow;
			}
			return lpgui.hwndFocus;
		}

		internal static string ClassNameOf(nint window)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			if (NativeMethods.GetClassName(window, stringBuilder, stringBuilder.Capacity) == 0)
			{
				return string.Empty;
			}
			return stringBuilder.ToString();
		}

		internal static string ProcessNameOf(nint window)
		{
			NativeMethods.GetWindowThreadProcessId(window, out var lpdwProcessId);
			try
			{
				using Process process = Process.GetProcessById((int)lpdwProcessId);
				return process.ProcessName;
			}
			catch (Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException) ? true : false)
			{
				return string.Empty;
			}
		}
	}
	public enum ClipboardTextRead
	{
		Text,
		NoText,
		Unavailable
	}
	public static class Win32Clipboard
	{
		private const uint CfUnicodeText = 13u;

		private const uint GmemMoveable = 2u;

		private const int OpenAttempts = 8;

		private const int OpenRetryDelayMilliseconds = 15;

		private static readonly Lazy<uint[]> ExclusionFormats = new Lazy<uint[]>(() => new uint[3]
		{
			RegisterClipboardFormatW("ExcludeClipboardContentFromMonitorProcessing"),
			RegisterClipboardFormatW("CanIncludeInClipboardHistory"),
			RegisterClipboardFormatW("CanUploadToCloudClipboard")
		});

		public static uint SequenceNumber => GetClipboardSequenceNumber();

		public static bool TryGetText(out string text)
		{
			return ReadText(out text) == ClipboardTextRead.Text;
		}

		public static ClipboardTextRead ReadText(out string text)
		{
			text = string.Empty;
			if (!IsClipboardFormatAvailable(13u))
			{
				return ClipboardTextRead.NoText;
			}
			if (!TryOpen())
			{
				return ClipboardTextRead.Unavailable;
			}
			try
			{
				nint clipboardData = GetClipboardData(13u);
				if (clipboardData == IntPtr.Zero)
				{
					return ClipboardTextRead.Unavailable;
				}
				nint num = GlobalLock(clipboardData);
				if (num == IntPtr.Zero)
				{
					return ClipboardTextRead.Unavailable;
				}
				try
				{
					text = Marshal.PtrToStringUni(num) ?? string.Empty;
					return ClipboardTextRead.Text;
				}
				finally
				{
					GlobalUnlock(clipboardData);
				}
			}
			finally
			{
				CloseClipboard();
			}
		}

		public static bool TrySetText(string text)
		{
			if (!TryOpen())
			{
				return false;
			}
			try
			{
				if (!EmptyClipboard())
				{
					return false;
				}
				if (!TryPlace(13u, (text.Length + 1) * 2, (nint destination) =>
				{
					Marshal.Copy(text.ToCharArray(), 0, destination, text.Length);
				}))
				{
					return false;
				}
				bool flag = true;
				uint[] value = ExclusionFormats.Value;
				foreach (uint num2 in value)
				{
					if (num2 != 0)
					{
						flag &= TryPlace(num2, 4, (nint destination) =>
						{
							Marshal.WriteInt32(destination, 0);
						});
					}
				}
				return flag;
			}
			finally
			{
				CloseClipboard();
			}
		}

		public static bool TryClear()
		{
			if (!TryOpen())
			{
				return false;
			}
			try
			{
				return EmptyClipboard();
			}
			finally
			{
				CloseClipboard();
			}
		}

		private static bool TryPlace(uint format, int bytes, Action<nint> write)
		{
			nint num = GlobalAlloc(2u, (uint)bytes);
			if (num == IntPtr.Zero)
			{
				return false;
			}
			nint num2 = GlobalLock(num);
			if (num2 == IntPtr.Zero)
			{
				GlobalFree(num);
				return false;
			}
			try
			{
				for (int i = 0; i < bytes; i++)
				{
					Marshal.WriteByte(num2, i, 0);
				}
				write(num2);
			}
			finally
			{
				GlobalUnlock(num);
			}
			if (SetClipboardData(format, num) == IntPtr.Zero)
			{
				GlobalFree(num);
				return false;
			}
			return true;
		}

		private static bool TryOpen()
		{
			for (int i = 0; i < 8; i++)
			{
				if (OpenClipboard(IntPtr.Zero))
				{
					return true;
				}
				Thread.Sleep(15);
			}
			return false;
		}

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool OpenClipboard(nint hWndNewOwner);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool CloseClipboard();

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EmptyClipboard();

		[DllImport("user32.dll", SetLastError = true)]
		private static extern nint GetClipboardData(uint format);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern nint SetClipboardData(uint format, nint memory);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsClipboardFormatAvailable(uint format);

		[DllImport("user32.dll")]
		private static extern uint GetClipboardSequenceNumber();

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern uint RegisterClipboardFormatW(string format);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern nint GlobalAlloc(uint flags, nuint bytes);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern nint GlobalFree(nint memory);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern nint GlobalLock(nint memory);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GlobalUnlock(nint memory);
	}
	public enum EditReplacementOutcome
	{
		Replaced,
		Refused,
		Indeterminate
	}
	public sealed record EditReplacementResult(EditReplacementOutcome Outcome, string Detail);
	public static class Win32EditReplacement
	{
		private struct GuiThreadInfo
		{
			public uint cbSize;

			public uint flags;

			public nint hwndActive;

			public nint hwndFocus;

			public nint hwndCapture;

			public nint hwndMenuOwner;

			public nint hwndMoveSize;

			public nint hwndCaret;

			public Rect rcCaret;
		}

		private struct Rect
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;
		}

		private const uint WmGetText = 13u;

		private const uint WmGetTextLength = 14u;

		private const uint EmGetSel = 176u;

		private const uint EmSetSel = 177u;

		private const uint EmReplaceSel = 194u;

		private const int GwlStyle = -16;

		private const long EsPassword = 32L;

		private const long EsReadOnly = 2048L;

		private const uint SmtoBlock = 1u;

		private const uint SmtoAbortIfHung = 2u;

		private const uint SmtoErrorOnExit = 32u;

		public const int MaxTextLength = 65535;

		public const uint MessageTimeoutMilliseconds = 25u;

		private const uint Flags = 35u;

		public static bool IsSupportedControl(nint window, out string reason)
		{
			if (window == IntPtr.Zero || !IsWindow(window))
			{
				reason = "no focused control";
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			GetClassName(window, stringBuilder, stringBuilder.Capacity);
			string text = stringBuilder.ToString();
			if (!string.Equals(text, "Edit", StringComparison.OrdinalIgnoreCase) && !text.StartsWith("WindowsForms10.EDIT.", StringComparison.OrdinalIgnoreCase))
			{
				reason = "control class '" + text + "' is not a classic Edit control";
				return false;
			}
			if ((((IntPtr)GetWindowLongPtr(window, -16)).ToInt64() & 0x820) != 0L)
			{
				reason = "password or read-only field";
				return false;
			}
			reason = string.Empty;
			return true;
		}

		public static nint FocusedControl()
		{
			nint foregroundWindow = GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return IntPtr.Zero;
			}
			GuiThreadInfo info = new GuiThreadInfo
			{
				cbSize = (uint)Marshal.SizeOf<GuiThreadInfo>()
			};
			if (!GetGUIThreadInfo(GetWindowThreadProcessId(foregroundWindow, out var _), ref info))
			{
				return IntPtr.Zero;
			}
			return info.hwndFocus;
		}

		public static EditReplacementResult ReplaceBeforeCaret(nint window, string expected, string replacement, Action<string>? boundary = null)
		{
			if (expected.Length == 0)
			{
				return Refuse("nothing to replace");
			}
			if (!IsSupportedControl(window, out string reason))
			{
				return Refuse(reason);
			}
			if (!TryGetSelection(window, out var start, out var end) || !TryGetText(window, out string text))
			{
				return Refuse("the control did not answer");
			}
			if (start != end)
			{
				return Refuse("text is selected in the control");
			}
			int num = end;
			int num2 = num - expected.Length;
			if (num > text.Length || num2 < 0 || !string.Equals(text.Substring(num2, expected.Length), expected, StringComparison.Ordinal) || (num2 > 0 && char.IsLetterOrDigit(text[num2 - 1])))
			{
				return Refuse("the control does not hold the word right before the caret");
			}
			boundary?.Invoke("read");
			if (!TryGetSelection(window, out start, out end) || start != num || end != num || !TryGetText(window, out string text2) || !string.Equals(text2, text, StringComparison.Ordinal))
			{
				return Refuse("the control's caret or text changed after it was read; nothing was changed");
			}
			if (!Send(window, 177u, num2, num))
			{
				Deselect(window);
				return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control stopped answering while the word was being selected");
			}
			if (!TryGetSelection(window, out start, out end) || start != num2 || end != num || !TryGetText(window, out string text3) || !string.Equals(text3, text, StringComparison.Ordinal))
			{
				Deselect(window);
				return Refuse("the control changed while the word was being selected; nothing was replaced");
			}
			boundary?.Invoke("selected");
			if (!SendText(window, 194u, 1, replacement))
			{
				Deselect(window);
				return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control stopped answering during the replacement");
			}
			string b = text.Substring(0, num2) + replacement + text.Substring(num);
			int num3 = num2 + replacement.Length;
			if (TryGetText(window, out string text4) && string.Equals(text4, b, StringComparison.Ordinal) && TryGetSelection(window, out start, out end) && start == num3 && end == num3)
			{
				return new EditReplacementResult(EditReplacementOutcome.Replaced, "replaced and read back");
			}
			return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control's text or caret after the replacement is not the expected one");
		}

		public static EditReplacementResult ReplaceSelection(nint window, string expectedSelected, string replacement, out int selectionStart, Action<string>? boundary = null)
		{
			selectionStart = -1;
			if (expectedSelected.Length == 0 || replacement.Length == 0)
			{
				return Refuse("nothing to replace");
			}
			if (!IsSupportedControl(window, out string reason))
			{
				return Refuse(reason);
			}
			if (!TryGetSelection(window, out var start, out var end) || !TryGetText(window, out string text))
			{
				return Refuse("the control did not answer");
			}
			if (start == end)
			{
				return Refuse("nothing is selected in the control");
			}
			if (end > text.Length || end - start != expectedSelected.Length || !string.Equals(text.Substring(start, end - start), expectedSelected, StringComparison.Ordinal))
			{
				return Refuse("the control's selection is not the text that was translated");
			}
			boundary?.Invoke("read");
			if (!TryGetSelection(window, out var start2, out var end2) || start2 != start || end2 != end || !TryGetText(window, out string text2) || !string.Equals(text2, text, StringComparison.Ordinal))
			{
				return Refuse("the control's selection or text changed after it was read; nothing was changed");
			}
			if (!SendText(window, 194u, 1, replacement))
			{
				return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control stopped answering during the replacement");
			}
			selectionStart = start;
			string b = text.Substring(0, start) + replacement + text.Substring(end);
			int num = start + replacement.Length;
			if (TryGetText(window, out string text3) && string.Equals(text3, b, StringComparison.Ordinal) && TryGetSelection(window, out var start3, out var end3) && start3 == num && end3 == num)
			{
				return new EditReplacementResult(EditReplacementOutcome.Replaced, "replaced and read back");
			}
			return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control's text or caret after the replacement is not the expected one");
		}

		public static EditReplacementResult RestoreSelection(nint window, int start, string translated, string source, Action<string>? boundary = null)
		{
			if (start < 0 || translated.Length == 0 || source.Length == 0)
			{
				return Refuse("nothing to restore");
			}
			if (!IsSupportedControl(window, out string reason))
			{
				return Refuse(reason);
			}
			if (!TryGetSelection(window, out var start2, out var end) || !TryGetText(window, out string text))
			{
				return Refuse("the control did not answer");
			}
			int num = start + translated.Length;
			if (start2 != end || end != num)
			{
				return Refuse("the caret is no longer right after the translation");
			}
			if (num > text.Length || !string.Equals(text.Substring(start, translated.Length), translated, StringComparison.Ordinal))
			{
				return Refuse("the control no longer holds the translation where it was written");
			}
			boundary?.Invoke("read");
			if (!TryGetSelection(window, out start2, out end) || start2 != num || end != num || !TryGetText(window, out string text2) || !string.Equals(text2, text, StringComparison.Ordinal))
			{
				return Refuse("the control's caret or text changed after it was read; nothing was changed");
			}
			if (!Send(window, 177u, start, num))
			{
				Deselect(window);
				return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control stopped answering while the translation was being selected");
			}
			if (!TryGetSelection(window, out start2, out end) || start2 != start || end != num || !TryGetText(window, out string text3) || !string.Equals(text3, text, StringComparison.Ordinal))
			{
				Deselect(window);
				return Refuse("the control changed while the translation was being selected; nothing was replaced");
			}
			boundary?.Invoke("selected");
			if (!SendText(window, 194u, 1, source))
			{
				Deselect(window);
				return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control stopped answering during the restore");
			}
			string b = text.Substring(0, start) + source + text.Substring(num);
			int num2 = start + source.Length;
			if (TryGetText(window, out string text4) && string.Equals(text4, b, StringComparison.Ordinal) && TryGetSelection(window, out var start3, out var end2) && start3 == num2 && end2 == num2)
			{
				return new EditReplacementResult(EditReplacementOutcome.Replaced, "restored and read back");
			}
			return new EditReplacementResult(EditReplacementOutcome.Indeterminate, "the control's text or caret after the restore is not the expected one");
		}

		private static EditReplacementResult Refuse(string detail)
		{
			return new EditReplacementResult(EditReplacementOutcome.Refused, detail);
		}

		private static void Deselect(nint window)
		{
			Send(window, 177u, -1, 0);
		}

		private static bool TryGetSelection(nint window, out int start, out int end)
		{
			start = (end = -1);
			if (SendMessageTimeoutW(window, 176u, IntPtr.Zero, IntPtr.Zero, 35u, 25u, out var result) == IntPtr.Zero)
			{
				return false;
			}
			uint num = (uint)((UIntPtr)result).ToUInt64();
			start = (int)(num & 0xFFFF);
			end = (int)(num >> 16);
			return true;
		}

		private static bool TryGetText(nint window, out string text)
		{
			text = string.Empty;
			if (SendMessageTimeoutW(window, 14u, IntPtr.Zero, IntPtr.Zero, 35u, 25u, out var result) == IntPtr.Zero || ((UIntPtr)result).ToUInt64() > 65535)
			{
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder((int)((UIntPtr)result).ToUInt64() + 1);
			if (SendMessageTimeoutW(window, 13u, new IntPtr(stringBuilder.Capacity), stringBuilder, 35u, 25u, out var _) == IntPtr.Zero)
			{
				return false;
			}
			text = stringBuilder.ToString();
			return true;
		}

		private static bool Send(nint window, uint message, int wParam, int lParam)
		{
			nuint result;
			return SendMessageTimeoutW(window, message, new IntPtr(wParam), new IntPtr(lParam), 35u, 25u, out result) != IntPtr.Zero;
		}

		private static bool SendText(nint window, uint message, int wParam, string lParam)
		{
			nuint result;
			return SendMessageTimeoutW(window, message, new IntPtr(wParam), lParam, 35u, 25u, out result) != IntPtr.Zero;
		}

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern nint SendMessageTimeoutW(nint hWnd, uint msg, nint wParam, nint lParam, uint flags, uint timeout, out nuint result);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern nint SendMessageTimeoutW(nint hWnd, uint msg, nint wParam, string lParam, uint flags, uint timeout, out nuint result);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern nint SendMessageTimeoutW(nint hWnd, uint msg, nint wParam, StringBuilder lParam, uint flags, uint timeout, out nuint result);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int GetClassName(nint hWnd, StringBuilder className, int maxCount);

		[DllImport("user32.dll", EntryPoint = "GetWindowLongPtrW")]
		private static extern nint GetWindowLongPtr(nint hWnd, int index);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWindow(nint hWnd);

		[DllImport("user32.dll")]
		private static extern nint GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(nint hWnd, out uint processId);

		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetGUIThreadInfo(uint threadId, ref GuiThreadInfo info);
	}
}
namespace SmartInput.Windows.Input.Classic
{
	public sealed class ClassicInputInjector : IInputInjector
	{
		internal enum PreviousTextSelection
		{
			Selected,
			Unreadable,
			Mismatch,
			ConfirmedNotSelectable,
			Lagging
		}

		private readonly record struct ForegroundLayoutContext(nint TargetWindow, nint TopLevelWindow, nint KeyboardLayout, bool IsEnglish);

		private const ushort VkControl = 17;

		private const ushort VkShift = 16;

		private const ushort VkAlt = 18;

		private const ushort VkBack = 8;

		private const ushort VkEscape = 27;

		private const ushort VkReturn = 13;

		private const ushort VkSpace = 32;

		private const ushort VkLeftWindows = 91;

		private const ushort VkRightWindows = 92;

		private const char ScanCodeLeftShift = '*';

		private const char ScanCodeRightShift = '6';

		private const uint EmReplaceSelection = 194u;

		[ThreadStatic]
		private static bool t_withoutAutomation;

		private const int PreviousTextSelectionAttempts = 4;

		private const int PreviousTextSelectionRetryDelayMs = 10;

		public string LastParagraphCaptureDiagnostic { get; private set; } = string.Empty;

		public string LastFocusRestoreDiagnostic { get; private set; } = string.Empty;

		public bool LastReplacementContradictedEditor => false;

		public bool HasOpenSelection => false;

		public bool EditorTextIsKnownStale => false;

		public int LastSendInputError { get; private set; }

		public string LastReplacementSource { get; private set; } = string.Empty;

		public string LastReplacementTarget { get; private set; } = string.Empty;

		public bool LastReplacementStartedRightToLeftEmbedding { get; private set; }

		public Func<bool>? ShouldAbandonReplacement { get; set; }

		public bool WithoutAutomation
		{
			get
			{
				return t_withoutAutomation;
			}
			set
			{
				t_withoutAutomation = value;
			}
		}

		public bool CollapseOpenSelection(bool preferKeyboard = false)
		{
			return false;
		}

		public void ForgetLastReplacementRefusal()
		{
		}

		public void LogTypingTargetWhenItChanges()
		{
		}

		public void ObserveStaleEditorText()
		{
		}

		public bool ReplacePreviousToken(string source, string replacement, ushort? trailingVirtualKey = null, bool setRightToLeft = false, string? trailingText = null, bool paragraphIsRightToLeft = false, bool startRightToLeftEmbedding = false, bool paragraphHasRightToLeftEmbedding = false, bool removeRightToLeftEmbedding = false, bool releaseActiveModifiers = false, bool requireExactSourceMatch = false, string precedingText = "", bool useKeyBuffer = false)
		{
			LastReplacementSource = string.Empty;
			LastReplacementTarget = string.Empty;
			LastReplacementStartedRightToLeftEmbedding = false;
			if (t_withoutAutomation)
			{
				useKeyBuffer = true;
			}
			if (source.Length == 0 || replacement.Length == 0)
			{
				return false;
			}
			if (releaseActiveModifiers && !ReleaseActiveModifiers())
			{
				return false;
			}
			int length = source.Length;
			string text = replacement;
			bool flag = false;
			bool flag2 = false;
			bool flag3 = setRightToLeft;
			string paragraphPrefix2;
			if (removeRightToLeftEmbedding && !t_withoutAutomation && TrySelectCurrentParagraphPrefix(source, out string paragraphPrefix))
			{
				length = paragraphPrefix.Length;
				flag2 = true;
				string text2 = paragraphPrefix;
				int length2 = source.Length;
				text = BidiControlCharacters.RemoveParagraphStabilization(text2.Substring(0, text2.Length - length2) + replacement);
			}
			else if (startRightToLeftEmbedding && !useKeyBuffer && TryGetCurrentParagraphPrefix(source, out paragraphPrefix2, selectRange: false) && paragraphPrefix2.StartsWith('\u202b'))
			{
				PreviousTextSelection previousTextSelection = SelectPreviousText(source, precedingText, useKeyBuffer);
				if (previousTextSelection == PreviousTextSelection.Mismatch)
				{
					return false;
				}
				flag2 = previousTextSelection == PreviousTextSelection.Selected;
			}
			else if (startRightToLeftEmbedding)
			{
				if (!useKeyBuffer && TryGetCurrentParagraphPrefix(source, out string paragraphPrefix3, selectRange: false) && BidiControlCharacters.CanPromoteParagraphToRightToLeft(paragraphPrefix3, source) && BidiControlCharacters.CanRewriteParagraphPrefix(paragraphPrefix3, source) && TrySelectCurrentParagraphPrefix(source, out paragraphPrefix3))
				{
					length = paragraphPrefix3.Length;
					flag2 = true;
					string text2 = paragraphPrefix3;
					int length2 = source.Length;
					string text3 = text2.Substring(0, text2.Length - length2) + replacement;
					flag = !paragraphPrefix3.StartsWith('\u202b');
					text = (flag ? BidiControlCharacters.StartRightToLeftEmbedding(BidiControlCharacters.StabilizeTerminalLeftToRightPunctuation(text3)) : text3);
				}
				else
				{
					PreviousTextSelection previousTextSelection2 = SelectPreviousText(source, precedingText, useKeyBuffer);
					if (previousTextSelection2 == PreviousTextSelection.Mismatch)
					{
						return false;
					}
					flag2 = previousTextSelection2 == PreviousTextSelection.Selected;
					text = BidiControlCharacters.StartRightToLeftEmbedding(replacement);
					flag = true;
				}
			}
			else
			{
				PreviousTextSelection previousTextSelection3 = SelectPreviousText(source, precedingText, useKeyBuffer);
				if (previousTextSelection3 == PreviousTextSelection.Mismatch)
				{
					return false;
				}
				flag2 = previousTextSelection3 == PreviousTextSelection.Selected;
				if (startRightToLeftEmbedding)
				{
					text = BidiControlCharacters.StartRightToLeftEmbedding(replacement);
					flag = true;
				}
				else if (removeRightToLeftEmbedding)
				{
					text += "\u202c";
				}
			}
			if (requireExactSourceMatch && !flag2)
			{
				return false;
			}
			Func<bool>? shouldAbandonReplacement = ShouldAbandonReplacement;
			bool shouldAppend;
			if (shouldAbandonReplacement != null && shouldAbandonReplacement())
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(68, 2, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Abandoned '");
					message.AppendFormatted(source);
					message.AppendLiteral("' -> '");
					message.AppendFormatted(replacement);
					message.AppendLiteral("': a key was typed while the editor was being read.");
				}
				DiagnosticLog.Write("Replace", ref message);
				return false;
			}
			bool flag4 = trailingVirtualKey == 13 && (flag | paragraphHasRightToLeftEmbedding);
			bool flag5 = flag3 && !paragraphIsRightToLeft;
			ForegroundLayoutContext context = ((flag2 | flag5 | flag4) ? CaptureForegroundLayout() : default(ForegroundLayoutContext));
			bool flag6 = flag5 && context.IsEnglish;
			bool flag7 = flag2 && TryReplaceSelectedText(context.TargetWindow, text);
			List<NativeMethods.INPUT> list = new List<NativeMethods.INPUT>(length * 2 + text.Length * 2 + 8);
			if (!flag2)
			{
				for (int i = 0; i < length; i++)
				{
					list.Add(CreateKeyInput(8, '\0', 0u));
					list.Add(CreateKeyInput(8, '\0', 2u));
				}
			}
			if (!flag7)
			{
				string text2 = text;
				foreach (char scanCode in text2)
				{
					list.Add(CreateKeyInput(0, scanCode, 4u));
					list.Add(CreateKeyInput(0, scanCode, 6u));
				}
			}
			if (flag6)
			{
				AddControlShiftShortcut(list, '6');
			}
			else if (removeRightToLeftEmbedding)
			{
				AddControlShiftShortcut(list, '*');
			}
			if (flag4)
			{
				AddUnicodeCharacter(list, '\u202c');
			}
			if (trailingVirtualKey.HasValue)
			{
				if (trailingVirtualKey.Value == 32)
				{
					list.Add(CreateKeyInput(0, ' ', 4u));
					list.Add(CreateKeyInput(0, ' ', 6u));
				}
				else
				{
					list.Add(CreateKeyInput(trailingVirtualKey.Value, '\0', 0u));
					list.Add(CreateKeyInput(trailingVirtualKey.Value, '\0', 2u));
				}
				if (flag4)
				{
					AddControlShiftShortcut(list, '*');
				}
			}
			else if (!string.IsNullOrEmpty(trailingText))
			{
				string text2 = trailingText;
				foreach (char scanCode2 in text2)
				{
					list.Add(CreateKeyInput(0, scanCode2, 4u));
					list.Add(CreateKeyInput(0, scanCode2, 6u));
				}
			}
			bool flag8 = list.Count == 0 || SendInputs(list);
			DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(104, 9, out shouldAppend);
			if (shouldAppend)
			{
				message2.AppendLiteral("Replace '");
				message2.AppendFormatted(source);
				message2.AppendLiteral("' -> '");
				message2.AppendFormatted(text);
				message2.AppendLiteral("': selectedInEditor=");
				message2.AppendFormatted(flag2);
				message2.AppendLiteral(" nativeEdit=");
				message2.AppendFormatted(flag7);
				message2.AppendLiteral(" backspaces=");
				message2.AppendFormatted((!flag2) ? length : 0);
				message2.AppendLiteral(" startedEmbedding=");
				message2.AppendFormatted(flag);
				message2.AppendLiteral(" rtlShortcut=");
				message2.AppendFormatted(flag6);
				message2.AppendLiteral(" sent=");
				message2.AppendFormatted(flag8);
				message2.AppendLiteral(" error=");
				message2.AppendFormatted(LastSendInputError);
				message2.AppendLiteral(".");
			}
			DiagnosticLog.Write("Replace", ref message2);
			if (flag8)
			{
				LastReplacementSource = source;
				LastReplacementTarget = replacement;
				LastReplacementStartedRightToLeftEmbedding = flag;
			}
			if (flag8 && (flag6 | removeRightToLeftEmbedding | flag4 | flag7))
			{
				RestoreForegroundLayoutNowOrLater(context);
			}
			return flag8;
		}

		public bool FocusedEditorLosesUnicodeBatches()
		{
			return UnicodeBatchLossRoute.IsFocused();
		}

		public long GetForegroundTargetIdentity()
		{
			return ((IntPtr)CaptureForegroundLayout().TargetWindow).ToInt64();
		}

		public TypingTargetFacts? DescribeTargetForJournal()
		{
			if (!DiagnosticLog.IsEnabled)
			{
				return null;
			}
			ForegroundLayoutContext foregroundLayoutContext = CaptureForegroundLayout();
			return TypingTargetFacts.Describe(foregroundLayoutContext.TargetWindow, foregroundLayoutContext.TopLevelWindow, string.Empty, "not kept by the Classic engine", FocusedEditorLosesUnicodeBatches(), includeElement: false);
		}

		public long GetFocusedElementIdentity()
		{
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null)
				{
					return 0L;
				}
				HashCode hashCode = default;
				hashCode.Add(focusedElement.Current.ProcessId);
				hashCode.Add(focusedElement.Current.NativeWindowHandle);
				int[] runtimeId = focusedElement.GetRuntimeId();
				foreach (int value in runtimeId)
				{
					hashCode.Add(value);
				}
				return hashCode.ToHashCode();
			}
			catch (ElementNotAvailableException)
			{
				return 0L;
			}
			catch (InvalidOperationException)
			{
				return 0L;
			}
			catch (COMException)
			{
				return 0L;
			}
		}

		public long GetForegroundWindowIdentity()
		{
			return ((IntPtr)NativeMethods.GetForegroundWindow()).ToInt64();
		}

		public bool TryGetCurrentParagraphPrefixText(string source, out string paragraphPrefix)
		{
			return TryGetCurrentParagraphPrefix(source, out paragraphPrefix, selectRange: false);
		}

		public bool IsProtectedTechnicalField()
		{
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null)
				{
					return false;
				}
				string processName = string.Empty;
				try
				{
					using Process process = Process.GetProcessById(focusedElement.Current.ProcessId);
					processName = process.ProcessName;
				}
				catch (ArgumentException)
				{
				}
				string value = string.Empty;
				if (focusedElement.TryGetCurrentPattern(ValuePattern.Pattern, out var patternObject) && patternObject is ValuePattern { Current: var current })
				{
					value = current.Value ?? string.Empty;
				}
				string text = focusedElement.Current.ControlType.ProgrammaticName;
				if (text.StartsWith("ControlType.", StringComparison.Ordinal))
				{
					text = text.Substring("ControlType.".Length);
				}
				return TechnicalTextFieldClassifier.IsProtected(new TechnicalTextFieldSnapshot(processName, text, focusedElement.Current.Name ?? string.Empty, focusedElement.Current.AutomationId ?? string.Empty, focusedElement.Current.ClassName ?? string.Empty, value, focusedElement.Current.IsPassword));
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
			catch (Win32Exception)
			{
				return false;
			}
			catch (UnauthorizedAccessException)
			{
				return false;
			}
		}

		public bool CompleteRightToLeftEmbeddingAndSend(ushort trailingVirtualKey)
		{
			ForegroundLayoutContext context = CaptureForegroundLayout();
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(8);
			AddUnicodeCharacter(inputs, '\u202c');
			AddVirtualKeyPress(inputs, trailingVirtualKey);
			AddControlShiftShortcut(inputs, '*');
			bool flag = SendInputs(inputs);
			if (flag)
			{
				RestoreForegroundLayoutNowOrLater(context);
			}
			return flag;
		}

		public bool SendUnicodeText(string text)
		{
			if (text.Length == 0)
			{
				return false;
			}
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(text.Length * 2);
			foreach (char character in text)
			{
				AddUnicodeCharacter(inputs, character);
			}
			return SendInputs(inputs);
		}

		public bool TryDeletePreviousTextExact(string text)
		{
			if (text.Length == 0)
			{
				return false;
			}
			if (!TrySelectPreviousText(text))
			{
				return false;
			}
			return TryReplaceSelectedText(CaptureForegroundLayout().TargetWindow, string.Empty);
		}

		public bool SendControlShortcut(ushort key)
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(4)
			{
				CreateKeyInput(17, '\0', 0u),
				CreateKeyInput(key, '\0', 0u),
				CreateKeyInput(key, '\0', 2u),
				CreateKeyInput(17, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		public bool ReplaceSelectedText(string replacement)
		{
			if (replacement.Length == 0)
			{
				return false;
			}
			try
			{
				if (TryReplaceSelectedText(new IntPtr(AutomationElement.FocusedElement.Current.NativeWindowHandle), replacement))
				{
					return true;
				}
			}
			catch (ElementNotAvailableException)
			{
			}
			return TryReplaceSelectedText(CaptureForegroundLayout().TargetWindow, replacement);
		}

		public bool SelectionCoversCurrentParagraph()
		{
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return false;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1)
				{
					return false;
				}
				string text = selection[0].GetText(-1).TrimEnd(new char[2] { '\r', '\n' });
				if (text.Length == 0)
				{
					return false;
				}
				TextPatternRange textPatternRange = selection[0].Clone();
				textPatternRange.ExpandToEnclosingUnit(TextUnit.Paragraph);
				return string.Equals(text, textPatternRange.GetText(-1).TrimEnd(new char[2] { '\r', '\n' }), StringComparison.Ordinal);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool TryGetSelectedText(out string selectedText)
		{
			selectedText = string.Empty;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return false;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1 || selection[0].CompareEndpoints(TextPatternRangeEndpoint.Start, selection[0], TextPatternRangeEndpoint.End) == 0)
				{
					return false;
				}
				selectedText = selection[0].GetText(-1);
				return !string.IsNullOrWhiteSpace(selectedText);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool IsSelectedTextUnchanged(string expectedText)
		{
			if (TryGetSelectedText(out string selectedText))
			{
				return string.Equals(selectedText, expectedText, StringComparison.Ordinal);
			}
			return false;
		}

		public bool TryGetCurrentEditableText(out string editableText)
		{
			editableText = string.Empty;
			try
			{
				if (!TryGetCurrentEditableRange(out TextPattern _, out TextPatternRange range, out editableText))
				{
					return false;
				}
				return range != null && !string.IsNullOrWhiteSpace(editableText);
			}
			catch (ElementNotAvailableException)
			{
				editableText = string.Empty;
				return false;
			}
			catch (InvalidOperationException)
			{
				editableText = string.Empty;
				return false;
			}
			catch (COMException)
			{
				editableText = string.Empty;
				return false;
			}
		}

		public bool TrySelectCurrentEditableText(string expectedText)
		{
			try
			{
				if (!TryGetCurrentEditableRange(out TextPattern textPattern, out TextPatternRange range, out string editableText) || !string.Equals(editableText, expectedText, StringComparison.Ordinal))
				{
					return false;
				}
				range.Select();
				return WaitForSelectedText(textPattern, expectedText);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool TryRestoreTextFocusAfterMenuActivation()
		{
			LastFocusRestoreDiagnostic = string.Empty;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || (focusedElement.Current.ControlType != ControlType.MenuItem && focusedElement.Current.ControlType != ControlType.MenuBar))
				{
					LastFocusRestoreDiagnostic = (((object)focusedElement == null) ? "No focused automation element" : ("Focus is " + focusedElement.Current.ControlType.ProgrammaticName + ", not a menu"));
					return false;
				}
				NativeMethods.INPUT[] inputs = new NativeMethods.INPUT[2]
				{
					CreateKeyInput(27, '\0', 0u),
					CreateKeyInput(27, '\0', 2u)
				};
				if (SendInputs(inputs))
				{
					if (WaitForFocusedTextPattern(out string controlType))
					{
						LastParagraphCaptureDiagnostic = "Editor focus restored after dismissing the accelerator menu";
						return true;
					}
					LastFocusRestoreDiagnostic = (string.IsNullOrEmpty(controlType) ? "Escape sent, but Windows reported no stable focused element" : ("Escape sent; focus remained on " + controlType));
				}
				else
				{
					LastFocusRestoreDiagnostic = $"Could not send Escape (Win32 error {LastSendInputError})";
				}
				nint foregroundWindow = NativeMethods.GetForegroundWindow();
				if (foregroundWindow == IntPtr.Zero)
				{
					LastFocusRestoreDiagnostic += "; no foreground window";
					return false;
				}
				AutomationElement automationElement = AutomationElement.FromHandle(foregroundWindow);
				OrCondition condition = new OrCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Document), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
				AutomationElementCollection automationElementCollection = automationElement.FindAll(TreeScope.Descendants, condition);
				LastFocusRestoreDiagnostic += $"; foreground={((IntPtr)foregroundWindow).ToInt64()}, text candidates={automationElementCollection.Count}";
				foreach (AutomationElement item in automationElementCollection)
				{
					if (item.Current.IsEnabled && item.Current.IsKeyboardFocusable && item.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject))
					{
						item.SetFocus();
						Thread.Sleep(50);
						AutomationElement focusedElement2 = AutomationElement.FocusedElement;
						if ((object)focusedElement2 != null && focusedElement2.TryGetCurrentPattern(TextPattern.Pattern, out patternObject))
						{
							LastParagraphCaptureDiagnostic = "Editor focus restored through Windows UI Automation";
							return true;
						}
					}
				}
			}
			catch (ElementNotAvailableException)
			{
				LastFocusRestoreDiagnostic += "; automation element became unavailable";
			}
			catch (InvalidOperationException)
			{
				LastFocusRestoreDiagnostic += "; automation focus operation was rejected";
			}
			catch (COMException)
			{
				LastFocusRestoreDiagnostic += "; Windows UI Automation returned a COM error";
			}
			return false;
		}

		private static bool WaitForFocusedTextPattern(out string controlType)
		{
			controlType = string.Empty;
			for (int i = 0; i < 12; i++)
			{
				Thread.Sleep(25);
				try
				{
					AutomationElement focusedElement = AutomationElement.FocusedElement;
					if ((object)focusedElement != null)
					{
						controlType = focusedElement.Current.ControlType.ProgrammaticName;
						if (focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var _))
						{
							return true;
						}
					}
				}
				catch (ElementNotAvailableException)
				{
				}
				catch (InvalidOperationException)
				{
				}
				catch (COMException)
				{
				}
			}
			return false;
		}

		public bool TryGetCurrentParagraphText(out string paragraphText)
		{
			paragraphText = string.Empty;
			try
			{
				if (!TryGetCurrentParagraphRange(out TextPattern _, out TextPatternRange range, out paragraphText, out string diagnostic))
				{
					LastParagraphCaptureDiagnostic = diagnostic;
					return false;
				}
				LastParagraphCaptureDiagnostic = "Current paragraph captured";
				return paragraphText.Length > 0 && range != null;
			}
			catch (ElementNotAvailableException)
			{
				LastParagraphCaptureDiagnostic = "Focused element became unavailable";
				paragraphText = string.Empty;
				return false;
			}
			catch (InvalidOperationException)
			{
				LastParagraphCaptureDiagnostic = "Focused element does not expose a usable text range";
				paragraphText = string.Empty;
				return false;
			}
			catch (COMException)
			{
				LastParagraphCaptureDiagnostic = "Windows UI Automation could not read the current paragraph";
				paragraphText = string.Empty;
				return false;
			}
		}

		public bool TrySelectCurrentParagraphText(string expectedText)
		{
			try
			{
				if (!TryGetCurrentParagraphRange(out TextPattern textPattern, out TextPatternRange range, out string paragraphText) || !string.Equals(paragraphText, expectedText, StringComparison.Ordinal))
				{
					return false;
				}
				range.Select();
				return WaitForSelectedText(textPattern, expectedText);
			}
			catch (ElementNotAvailableException)
			{
				return false;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
			catch (COMException)
			{
				return false;
			}
		}

		public bool ApplyParagraphDirection(bool rightToLeft)
		{
			ForegroundLayoutContext context = CaptureForegroundLayout();
			if (context.TargetWindow == IntPtr.Zero)
			{
				return false;
			}
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(4);
			AddControlShiftShortcut(inputs, rightToLeft ? '6' : '*');
			bool flag = SendInputs(inputs);
			if (flag)
			{
				RestoreForegroundLayout(context);
			}
			return flag;
		}

		public bool SendControlShortcutWithoutActiveModifiers(ushort key)
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(10)
			{
				CreateKeyInput(17, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(18, '\0', 2u),
				CreateKeyInput(17, '\0', 0u),
				CreateKeyInput(key, '\0', 0u),
				CreateKeyInput(key, '\0', 2u),
				CreateKeyInput(17, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(18, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		private bool ReleaseActiveModifiers()
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(5)
			{
				CreateKeyInput(18, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(17, '\0', 2u),
				CreateKeyInput(91, '\0', 2u),
				CreateKeyInput(92, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		public bool SendControlShiftShortcut(ushort key)
		{
			List<NativeMethods.INPUT> inputs = new List<NativeMethods.INPUT>(6)
			{
				CreateKeyInput(17, '\0', 0u),
				CreateKeyInput(16, '\0', 0u),
				CreateKeyInput(key, '\0', 0u),
				CreateKeyInput(key, '\0', 2u),
				CreateKeyInput(16, '\0', 2u),
				CreateKeyInput(17, '\0', 2u)
			};
			return SendInputs(inputs);
		}

		private bool SendInputs(IReadOnlyList<NativeMethods.INPUT> inputs)
		{
			NativeMethods.INPUT[] array = inputs.ToArray();
			uint num = InjectedInputOrder.Send(array);
			LastSendInputError = ((num != (uint)array.Length) ? Marshal.GetLastWin32Error() : 0);
			return num == (uint)array.Length;
		}

		private static ForegroundLayoutContext CaptureForegroundLayout()
		{
			nint foregroundWindow = NativeMethods.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return default;
			}
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(foregroundWindow, out var lpdwProcessId);
			if (windowThreadProcessId == 0)
			{
				return default;
			}
			nint num = foregroundWindow;
			uint idThread = windowThreadProcessId;
			NativeMethods.GUITHREADINFO lpgui = new NativeMethods.GUITHREADINFO
			{
				cbSize = (uint)Marshal.SizeOf<NativeMethods.GUITHREADINFO>()
			};
			if (NativeMethods.GetGUIThreadInfo(windowThreadProcessId, ref lpgui) && lpgui.hwndFocus != IntPtr.Zero)
			{
				num = lpgui.hwndFocus;
				idThread = NativeMethods.GetWindowThreadProcessId(num, out lpdwProcessId);
			}
			nint keyboardLayout = NativeMethods.GetKeyboardLayout(idThread);
			bool isEnglish = (GetLanguageId(keyboardLayout) & 0x3FF) == 9;
			return new ForegroundLayoutContext(num, foregroundWindow, keyboardLayout, isEnglish);
		}

		private static void RestoreForegroundLayoutNowOrLater(ForegroundLayoutContext context)
		{
			if (t_withoutAutomation)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(74, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Layout after the edit left to the typing pipeline's watch (layout was 0x");
					message.AppendFormatted(((IntPtr)context.KeyboardLayout).ToInt64(), "X8");
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message);
			}
			else
			{
				RestoreForegroundLayout(context);
			}
		}

		private static void RestoreForegroundLayout(ForegroundLayoutContext context)
		{
			Thread.Sleep(25);
			uint windowThreadProcessId = NativeMethods.GetWindowThreadProcessId(context.TargetWindow, out var _);
			bool shouldAppend;
			if (windowThreadProcessId != 0 && NativeMethods.GetKeyboardLayout(windowThreadProcessId) == context.KeyboardLayout)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(56, 1, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Layout check after the edit: still 0x");
					message.AppendFormatted(((IntPtr)context.KeyboardLayout).ToInt64(), "X8");
					message.AppendLiteral("; nothing restored.");
				}
				DiagnosticLog.Write("Replace", ref message);
				return;
			}
			DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(69, 2, out shouldAppend);
			if (shouldAppend)
			{
				message2.AppendLiteral("Layout check after the edit: the editor switched to 0x");
				message2.AppendFormatted((windowThreadProcessId == 0) ? 0 : ((IntPtr)NativeMethods.GetKeyboardLayout(windowThreadProcessId)).ToInt64(), "X8");
				message2.AppendLiteral("; restoring 0x");
				message2.AppendFormatted(((IntPtr)context.KeyboardLayout).ToInt64(), "X8");
				message2.AppendLiteral(".");
			}
			DiagnosticLog.Write("Replace", ref message2);
			NativeMethods.PostMessage(context.TargetWindow, 80u, IntPtr.Zero, context.KeyboardLayout);
			if (context.TopLevelWindow != context.TargetWindow)
			{
				NativeMethods.PostMessage(context.TopLevelWindow, 80u, IntPtr.Zero, context.KeyboardLayout);
			}
		}

		private static ushort GetLanguageId(nint keyboardLayout)
		{
			return (ushort)(((IntPtr)keyboardLayout).ToInt64() & 0xFFFF);
		}

		private static bool TrySelectPreviousText(string source)
		{
			return SelectPreviousText(source) == PreviousTextSelection.Selected;
		}

		private static PreviousTextSelection SelectPreviousText(string source, string precedingText = "", bool useKeyBuffer = false)
		{
			bool shouldAppend;
			if (useKeyBuffer)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(57, 1, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Using the key buffer for '");
					message.AppendFormatted(source);
					message.AppendLiteral("'; the editor text is not read.");
				}
				DiagnosticLog.Write("Replace", ref message);
				return PreviousTextSelection.Unreadable;
			}
			int num = 1;
			PreviousTextSelection previousTextSelection;
			while (true)
			{
				previousTextSelection = SelectPreviousTextOnce(source, precedingText);
				DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(62, 4, out shouldAppend);
				if (shouldAppend)
				{
					message2.AppendLiteral("Select previous text attempt ");
					message2.AppendFormatted(num);
					message2.AppendLiteral(": source='");
					message2.AppendFormatted(source);
					message2.AppendLiteral("' preceding='");
					message2.AppendFormatted(precedingText);
					message2.AppendLiteral("' result=");
					message2.AppendFormatted(previousTextSelection);
					message2.AppendLiteral(".");
				}
				DiagnosticLog.Write("Replace", ref message2);
				shouldAppend = ((previousTextSelection == PreviousTextSelection.Mismatch || previousTextSelection == PreviousTextSelection.Lagging) ? true : false);
				if (!shouldAppend || num >= 4)
				{
					break;
				}
				Thread.Sleep(10);
				num++;
			}
			return previousTextSelection;
		}

		private static PreviousTextSelection SelectPreviousTextOnce(string source, string precedingText)
		{
			int length = source.Length;
			TextPattern textPattern2;
			TextPatternRange textPatternRange;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return PreviousTextSelection.Unreadable;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1)
				{
					return PreviousTextSelection.Unreadable;
				}
				textPattern2 = textPattern;
				textPatternRange = selection[0];
			}
			catch (ElementNotAvailableException)
			{
				return PreviousTextSelection.Unreadable;
			}
			catch (InvalidOperationException)
			{
				return PreviousTextSelection.Unreadable;
			}
			try
			{
				TextPatternRange textPatternRange2 = textPatternRange.Clone();
				textPatternRange2.MoveEndpointByRange(TextPatternRangeEndpoint.Start, textPatternRange, TextPatternRangeEndpoint.End);
				int num = textPatternRange2.MoveEndpointByUnit(TextPatternRangeEndpoint.Start, TextUnit.Character, -(length + 1));
				string text = textPatternRange2.GetText(-1);
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(43, 3, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("  editor text before caret='");
					message.AppendFormatted(text);
					message.AppendLiteral("' (moved ");
					message.AppendFormatted(-num);
					message.AppendLiteral(" of ");
					message.AppendFormatted(length + 1);
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Replace", ref message);
				if (-num < length)
				{
					return IsLaggingBehind(text, source, precedingText) ? PreviousTextSelection.Lagging : PreviousTextSelection.Mismatch;
				}
				string actualText = text;
				int num2 = 0;
				while (!MatchesPhysicalSourceText(actualText, source) && num2 < 3)
				{
					if (textPatternRange2.MoveEndpointByUnit(TextPatternRangeEndpoint.Start, TextUnit.Character, 1) != 1)
					{
						return EndsWithSource(text, source) ? PreviousTextSelection.ConfirmedNotSelectable : PreviousTextSelection.Mismatch;
					}
					actualText = textPatternRange2.GetText(-1);
					num2++;
				}
				if (!MatchesPhysicalSourceText(actualText, source))
				{
					PreviousTextSelection result = (EndsWithSource(text, source) ? PreviousTextSelection.ConfirmedNotSelectable : (IsLaggingBehind(text, source, precedingText) ? PreviousTextSelection.Lagging : PreviousTextSelection.Mismatch));
					return result;
				}
				textPatternRange2.Select();
				return (!WaitForSelectedText(textPattern2, source)) ? PreviousTextSelection.Mismatch : PreviousTextSelection.Selected;
			}
			catch (ElementNotAvailableException)
			{
				return PreviousTextSelection.Mismatch;
			}
			catch (InvalidOperationException)
			{
				return PreviousTextSelection.Mismatch;
			}
		}

		internal static bool IsLaggingBehind(string textBeforeCaret, string source, string precedingText = "")
		{
			for (int num = source.Length - 1; num >= 0; num--)
			{
				string value = source.Substring(0, num);
				if (!textBeforeCaret.EndsWith(value, StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}
				int num2 = num;
				string text = textBeforeCaret.Substring(0, textBeforeCaret.Length - num2);
				if (text.Length != 0)
				{
					if (!char.IsWhiteSpace(text[text.Length - 1]))
					{
						if (!BidiControlCharacters.IsDirectionControl(text[text.Length - 1]) && (num != 0 || !BidiControlCharacters.EndsWithPrecedingText(text, precedingText)))
						{
							continue;
						}
					}
				}
				return true;
			}
			return false;
		}

		internal static bool AllowsBlindBackspaces(PreviousTextSelection selection)
		{
			if (selection == PreviousTextSelection.Unreadable || (uint)(selection - 3) <= 1u)
			{
				return true;
			}
			return false;
		}

		internal static bool EndsWithSource(string textBeforeCaret, string source)
		{
			if (source.Length > 0 && textBeforeCaret.Length >= source.Length)
			{
				int length = source.Length;
				return MatchesPhysicalSourceText(textBeforeCaret.Substring(textBeforeCaret.Length - length), source);
			}
			return false;
		}

		private static bool TrySelectCurrentParagraphPrefix(string source, out string paragraphPrefix)
		{
			return TryGetCurrentParagraphPrefix(source, out paragraphPrefix, selectRange: true);
		}

		private static bool TryGetCurrentParagraphRange(out TextPattern textPattern, out TextPatternRange range, out string paragraphText)
		{
			string diagnostic;
			return TryGetCurrentParagraphRange(out textPattern, out range, out paragraphText, out diagnostic);
		}

		private static bool TryGetCurrentParagraphRange(out TextPattern textPattern, out TextPatternRange range, out string paragraphText, out string diagnostic)
		{
			textPattern = null;
			range = null;
			paragraphText = string.Empty;
			diagnostic = string.Empty;
			AutomationElement focusedElement = AutomationElement.FocusedElement;
			if ((object)focusedElement == null)
			{
				diagnostic = "No focused UI Automation element";
				return false;
			}
			if (!focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern2))
			{
				diagnostic = "Focused " + focusedElement.Current.ControlType.ProgrammaticName + " does not support TextPattern";
				return false;
			}
			TextPatternRange[] selection = textPattern2.GetSelection();
			if (selection.Length != 1)
			{
				diagnostic = $"Expected one caret range but found {selection.Length}";
				return false;
			}
			if (selection[0].CompareEndpoints(TextPatternRangeEndpoint.Start, selection[0], TextPatternRangeEndpoint.End) != 0)
			{
				diagnostic = "The active text range is a selection, not a caret";
				return false;
			}
			TextPatternRange textPatternRange = selection[0].Clone();
			textPatternRange.ExpandToEnclosingUnit(TextUnit.Paragraph);
			string text = textPatternRange.GetText(-1);
			while (text.EndsWith('\r') || text.EndsWith('\n'))
			{
				if (textPatternRange.MoveEndpointByUnit(TextPatternRangeEndpoint.End, TextUnit.Character, -1) != -1)
				{
					return false;
				}
				text = textPatternRange.GetText(-1);
			}
			textPattern = textPattern2;
			range = textPatternRange;
			paragraphText = text;
			diagnostic = ((paragraphText.Length == 0) ? "The current paragraph is empty" : "Current paragraph captured");
			return paragraphText.Length > 0;
		}

		private static bool TryGetCurrentEditableRange(out TextPattern textPattern, out TextPatternRange range, out string editableText)
		{
			textPattern = null;
			range = null;
			editableText = string.Empty;
			AutomationElement focusedElement = AutomationElement.FocusedElement;
			if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern2))
			{
				return false;
			}
			TextPatternRange[] selection = textPattern2.GetSelection();
			if (selection.Length != 1 || selection[0].CompareEndpoints(TextPatternRangeEndpoint.Start, selection[0], TextPatternRangeEndpoint.End) != 0)
			{
				return false;
			}
			TextPatternRange textPatternRange = textPattern2.DocumentRange.Clone();
			string text = textPatternRange.GetText(-1);
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			textPattern = textPattern2;
			range = textPatternRange;
			editableText = text;
			return true;
		}

		private static bool TryGetCurrentParagraphPrefix(string source, out string paragraphPrefix, bool selectRange)
		{
			paragraphPrefix = string.Empty;
			try
			{
				AutomationElement focusedElement = AutomationElement.FocusedElement;
				if ((object)focusedElement == null || !focusedElement.TryGetCurrentPattern(TextPattern.Pattern, out var patternObject) || !(patternObject is TextPattern textPattern))
				{
					return false;
				}
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length != 1 || selection[0].GetText(1).Length != 0)
				{
					return false;
				}
				TextPatternRange textPatternRange = selection[0].Clone();
				textPatternRange.ExpandToEnclosingUnit(TextUnit.Paragraph);
				textPatternRange.MoveEndpointByRange(TextPatternRangeEndpoint.End, selection[0], TextPatternRangeEndpoint.Start);
				paragraphPrefix = textPatternRange.GetText(-1);
				if (paragraphPrefix.Length >= source.Length)
				{
					string obj = paragraphPrefix;
					int length = source.Length;
					if (MatchesPhysicalSourceText(obj.Substring(obj.Length - length), source))
					{
						if (selectRange)
						{
							textPatternRange.Select();
							if (!WaitForSelectedText(textPattern, paragraphPrefix))
							{
								paragraphPrefix = string.Empty;
								return false;
							}
						}
						return true;
					}
				}
				paragraphPrefix = string.Empty;
				return false;
			}
			catch (ElementNotAvailableException)
			{
				paragraphPrefix = string.Empty;
				return false;
			}
			catch (InvalidOperationException)
			{
				paragraphPrefix = string.Empty;
				return false;
			}
		}

		private static bool WaitForSelectedText(TextPattern textPattern, string expectedText)
		{
			for (int i = 0; i < 5; i++)
			{
				TextPatternRange[] selection = textPattern.GetSelection();
				if (selection.Length == 1 && MatchesPhysicalSourceText(selection[0].GetText(-1), expectedText))
				{
					return true;
				}
				Thread.Sleep(5);
			}
			TextPatternRange[] selection2 = textPattern.GetSelection();
			if (selection2.Length == 1)
			{
				TextPatternRange textPatternRange = selection2[0].Clone();
				textPatternRange.MoveEndpointByRange(TextPatternRangeEndpoint.Start, textPatternRange, TextPatternRangeEndpoint.End);
				textPatternRange.Select();
			}
			return false;
		}

		private static bool MatchesPhysicalSourceText(string actualText, string expectedText)
		{
			if (string.Equals(actualText, expectedText, StringComparison.Ordinal))
			{
				return true;
			}
			if (actualText.Length == expectedText.Length && expectedText.All((char character) =>
			{
				switch (character)
				{
				case 'A':
				case 'B':
				case 'C':
				case 'D':
				case 'E':
				case 'F':
				case 'G':
				case 'H':
				case 'I':
				case 'J':
				case 'K':
				case 'L':
				case 'M':
				case 'N':
				case 'O':
				case 'P':
				case 'Q':
				case 'R':
				case 'S':
				case 'T':
				case 'U':
				case 'V':
				case 'W':
				case 'X':
				case 'Y':
				case 'Z':
				case 'a':
				case 'b':
				case 'c':
				case 'd':
				case 'e':
				case 'f':
				case 'g':
				case 'h':
				case 'i':
				case 'j':
				case 'k':
				case 'l':
				case 'm':
				case 'n':
				case 'o':
				case 'p':
				case 'q':
				case 'r':
				case 's':
				case 't':
				case 'u':
				case 'v':
				case 'w':
				case 'x':
				case 'y':
				case 'z':
					return true;
				default:
					return false;
				}
			}))
			{
				return string.Equals(actualText, expectedText, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		private static bool TryReplaceSelectedText(nint targetWindow, string replacement)
		{
			if (targetWindow == IntPtr.Zero)
			{
				return false;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			if (NativeMethods.GetClassName(targetWindow, stringBuilder, stringBuilder.Capacity) == 0)
			{
				return false;
			}
			if (!stringBuilder.ToString().Contains("Edit", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			NativeMethods.SendMessage(targetWindow, 194u, new IntPtr(1), replacement);
			return true;
		}

		private static void AddControlShiftShortcut(ICollection<NativeMethods.INPUT> inputs, char shiftScanCode)
		{
			inputs.Add(CreateKeyInput(17, '\0', 0u));
			inputs.Add(CreateKeyInput(0, shiftScanCode, 8u));
			inputs.Add(CreateKeyInput(0, shiftScanCode, 10u));
			inputs.Add(CreateKeyInput(17, '\0', 2u));
		}

		private static void AddVirtualKeyPress(ICollection<NativeMethods.INPUT> inputs, ushort virtualKey)
		{
			inputs.Add(CreateKeyInput(virtualKey, '\0', 0u));
			inputs.Add(CreateKeyInput(virtualKey, '\0', 2u));
		}

		private static void AddUnicodeCharacter(ICollection<NativeMethods.INPUT> inputs, char character)
		{
			inputs.Add(CreateKeyInput(0, character, 4u));
			inputs.Add(CreateKeyInput(0, character, 6u));
		}

		private static NativeMethods.INPUT CreateKeyInput(ushort virtualKey, char scanCode, uint flags)
		{
			return new NativeMethods.INPUT
			{
				type = 1u,
				U = new NativeMethods.InputUnion
				{
					ki = new NativeMethods.KEYBDINPUT
					{
						wVk = virtualKey,
						wScan = scanCode,
						dwFlags = flags,
						time = 0u,
						dwExtraInfo = NativeMethods.SmartInputInjectedInputMarker
					}
				}
			};
		}
	}
}
namespace SmartInput.Windows.Hooks
{
	public sealed class GlobalKeyboardHook : IDisposable
	{
		private readonly Func<KeyboardEvent, bool> _onKeyboardEvent;

		private readonly bool _ignoreInjectedEvents;

		private readonly Action? _onForeignInjectedKeyDown;

		private NativeMethods.LowLevelKeyboardProc? _hookProc;

		private LowLevelHookThread? _thread;

		public GlobalKeyboardHook(Func<KeyboardEvent, bool> onKeyboardEvent, bool ignoreInjectedEvents = true, Action? onForeignInjectedKeyDown = null)
		{
			_onKeyboardEvent = onKeyboardEvent;
			_ignoreInjectedEvents = ignoreInjectedEvents;
			_onForeignInjectedKeyDown = onForeignInjectedKeyDown;
		}

		public void Start()
		{
			if (_thread == null)
			{
				_hookProc = HookCallback;
				_thread = new LowLevelHookThread("Diyar keyboard hook", 13, _hookProc);
			}
		}

		public void Dispose()
		{
			_thread?.Dispose();
			_thread = null;
			_hookProc = null;
		}

		private nint HookCallback(int nCode, nint wParam, nint lParam)
		{
			if (nCode >= 0)
			{
				bool flag = wParam == 256 || wParam == 260;
				bool flag2 = wParam == 257 || wParam == 261;
				if (flag | flag2)
				{
					NativeMethods.KBDLLHOOKSTRUCT kBDLLHOOKSTRUCT = Marshal.PtrToStructure<NativeMethods.KBDLLHOOKSTRUCT>(lParam);
					bool flag3 = (kBDLLHOOKSTRUCT.Flags & 0x10) == 16;
					if (kBDLLHOOKSTRUCT.DwExtraInfo == NativeMethods.SmartInputInjectedInputMarker)
					{
						InjectedInputOrder.Observed();
					}
					else
					{
						bool shouldAppend;
						if ((flag3 && _ignoreInjectedEvents) & flag)
						{
							Action onForeignInjectedKeyDown = _onForeignInjectedKeyDown;
							if (onForeignInjectedKeyDown != null)
							{
								try
								{
									onForeignInjectedKeyDown();
								}
								catch (Exception ex)
								{
									FaultRing.Note(FaultSite.HookForeignInput, ex);
									DiagnosticMessageHandler message = new DiagnosticMessageHandler(37, 1, out shouldAppend);
									if (shouldAppend)
									{
										message.AppendLiteral("The foreign-input observer failed (");
										message.AppendFormatted(ex.GetType().FullName);
										message.AppendLiteral(").");
									}
									DiagnosticLog.Write("Hook", ref message);
								}
								goto IL_017f;
							}
						}
						if (!flag3 || !_ignoreInjectedEvents)
						{
							bool flag4;
							try
							{
								flag4 = _onKeyboardEvent(new KeyboardEvent((int)kBDLLHOOKSTRUCT.VkCode, flag, (int)kBDLLHOOKSTRUCT.ScanCode, (kBDLLHOOKSTRUCT.Flags & 1) != 0));
							}
							catch (Exception ex2)
							{
								FaultRing.Note(FaultSite.HookKeyHandler, ex2);
								DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(58, 1, out shouldAppend);
								if (shouldAppend)
								{
									message2.AppendLiteral("The key handler failed (");
									message2.AppendFormatted(ex2.GetType().FullName);
									message2.AppendLiteral("); the key was passed on as typed.");
								}
								DiagnosticLog.Write("Hook", ref message2);
								flag4 = false;
							}
							if (flag4)
							{
								return 1;
							}
						}
					}
				}
			}
			goto IL_017f;
			IL_017f:
			return NativeMethods.CallNextHookEx(_thread?.HookHandle ?? IntPtr.Zero, nCode, wParam, lParam);
		}
	}
	public sealed class GlobalMouseClickHook : IDisposable
	{
		private readonly Action _onButtonDown;

		private NativeMethods.LowLevelKeyboardProc? _hookProc;

		private LowLevelHookThread? _thread;

		public GlobalMouseClickHook(Action onButtonDown)
		{
			_onButtonDown = onButtonDown;
		}

		public void Start()
		{
			if (_thread == null)
			{
				_hookProc = HookCallback;
				_thread = new LowLevelHookThread("Diyar mouse hook", 14, _hookProc);
			}
		}

		public void Dispose()
		{
			_thread?.Dispose();
			_thread = null;
			_hookProc = null;
		}

		internal static bool IsButtonDown(int message)
		{
			switch (message)
			{
			case 513:
			case 516:
			case 519:
			case 523:
				return true;
			default:
				return false;
			}
		}

		private nint HookCallback(int nCode, nint wParam, nint lParam)
		{
			if (nCode >= 0 && IsButtonDown((int)wParam))
			{
				try
				{
					_onButtonDown();
				}
				catch (Exception exception)
				{
					FaultRing.Note(FaultSite.MouseHook, exception);
				}
			}
			return NativeMethods.CallNextHookEx(_thread?.HookHandle ?? IntPtr.Zero, nCode, wParam, lParam);
		}
	}
	public static class HookReinstallPolicy
	{
		public const int DefaultTimeoutMilliseconds = 300;

		private const string DesktopKey = "Control Panel\\Desktop";

		private const string TimeoutValue = "LowLevelHooksTimeout";

		public static bool ShouldReinstall(double callbackMilliseconds, int timeoutMilliseconds)
		{
			return callbackMilliseconds >= (double)timeoutMilliseconds;
		}

		public static int ResolveTimeoutMilliseconds(object? registryValue)
		{
			if (!(registryValue is int num))
			{
				if (registryValue is long num2 && num2 > 0 && num2 <= int.MaxValue)
				{
					return (int)num2;
				}
			}
			else if (num > 0)
			{
				return num;
			}
			return 300;
		}

		public static int ReadTimeoutMilliseconds()
		{
			try
			{
				using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", writable: false);
				return ResolveTimeoutMilliseconds(registryKey?.GetValue("LowLevelHooksTimeout"));
			}
			catch (Exception ex) when ((ex is SecurityException || ex is IOException || ex is UnauthorizedAccessException) ? true : false)
			{
				return 300;
			}
		}
	}
	public readonly record struct KeyboardEvent(int VirtualKey, bool IsKeyDown, int ScanCode = 0, bool IsExtended = false);
	internal sealed class LowLevelHookThread : IDisposable
	{
		private const uint WmReinstallHook = 32769u;

		private readonly Thread _thread;

		private readonly string _name;

		private readonly int _hookType;

		private readonly NativeMethods.LowLevelKeyboardProc _inner;

		private readonly NativeMethods.LowLevelKeyboardProc _callback;

		private readonly int _callbackTimeoutMilliseconds;

		private uint _threadId;

		private nint _hookHandle;

		private int _installError;

		private int _reinstallRequested;

		private int _reinstalls;

		private double _slowCallbackMilliseconds;

		public nint HookHandle => _hookHandle;

		internal int ReinstallCount => Volatile.Read(in _reinstalls);

		internal int CallbackTimeoutMilliseconds => _callbackTimeoutMilliseconds;

		public LowLevelHookThread(string name, int hookType, NativeMethods.LowLevelKeyboardProc callback, int? callbackTimeoutMilliseconds = null)
		{
			LowLevelHookThread lowLevelHookThread = this;
			_name = name;
			_hookType = hookType;
			_inner = callback;
			_callback = TimedCallback;
			_callbackTimeoutMilliseconds = callbackTimeoutMilliseconds ?? HookReinstallPolicy.ReadTimeoutMilliseconds();
			ManualResetEventSlim installed = new ManualResetEventSlim();
			try
			{
				_thread = new Thread(() =>
				{
					lowLevelHookThread.Run(installed);
				})
				{
					IsBackground = true,
					Name = name,
					Priority = ThreadPriority.AboveNormal
				};
				_thread.Start();
				installed.Wait();
				if (_hookHandle == IntPtr.Zero)
				{
					_thread.Join(TimeSpan.FromSeconds(1L));
					throw new InvalidOperationException($"Failed to install the {name} (error {_installError}).");
				}
			}
			finally
			{
				if (installed != null)
				{
					((IDisposable)installed).Dispose();
				}
			}
		}

		private nint TimedCallback(int nCode, nint wParam, nint lParam)
		{
			long timestamp = Stopwatch.GetTimestamp();
			try
			{
				return _inner(nCode, wParam, lParam);
			}
			finally
			{
				NoteCallbackDuration(Stopwatch.GetElapsedTime(timestamp));
			}
		}

		internal bool NoteCallbackDuration(TimeSpan duration)
		{
			if (!HookReinstallPolicy.ShouldReinstall(duration.TotalMilliseconds, _callbackTimeoutMilliseconds))
			{
				return false;
			}
			_slowCallbackMilliseconds = duration.TotalMilliseconds;
			RequestReinstall();
			return true;
		}

		internal void RequestReinstall()
		{
			if (Interlocked.Exchange(ref _reinstallRequested, 1) == 0 && _threadId != 0)
			{
				NativeMethods.PostThreadMessage(_threadId, 32769u, IntPtr.Zero, IntPtr.Zero);
			}
		}

		private void Run(ManualResetEventSlim installed)
		{
			_threadId = NativeMethods.GetCurrentThreadId();
			NativeMethods.PeekMessage(out var _, IntPtr.Zero, 0u, 0u, 0u);
			_hookHandle = NativeMethods.SetWindowsHookEx(_hookType, _callback, IntPtr.Zero, 0u);
			_installError = ((_hookHandle == IntPtr.Zero) ? Marshal.GetLastWin32Error() : 0);
			installed.Set();
			if (_hookHandle == IntPtr.Zero)
			{
				return;
			}
			NativeMethods.MSG message2;
			while (NativeMethods.GetMessage(out message2, IntPtr.Zero, 0u, 0u) > 0)
			{
				if (message2.Hwnd == IntPtr.Zero && message2.Message == 32769)
				{
					Reinstall();
					continue;
				}
				NativeMethods.TranslateMessage(ref message2);
				NativeMethods.DispatchMessage(ref message2);
			}
			NativeMethods.UnhookWindowsHookEx(_hookHandle);
			_hookHandle = IntPtr.Zero;
		}

		private void Reinstall()
		{
			nint hookHandle = _hookHandle;
			bool flag = hookHandle != IntPtr.Zero && NativeMethods.UnhookWindowsHookEx(hookHandle);
			nint num = NativeMethods.SetWindowsHookEx(_hookType, _callback, IntPtr.Zero, 0u);
			int num2 = ((num == IntPtr.Zero) ? Marshal.GetLastWin32Error() : 0);
			_hookHandle = num;
			if (num != IntPtr.Zero)
			{
				Interlocked.Increment(ref _reinstalls);
			}
			double slowCallbackMilliseconds = _slowCallbackMilliseconds;
			Volatile.Write(ref _reinstallRequested, 0);
			DiagnosticMessageHandler message = new DiagnosticMessageHandler(156, 5, out var shouldAppend);
			if (shouldAppend)
			{
				message.AppendFormatted(_name);
				message.AppendLiteral(": a callback took ");
				message.AppendFormatted(slowCallbackMilliseconds, "0.0");
				message.AppendLiteral(" ms, at or beyond LowLevelHooksTimeout (");
				message.AppendFormatted(_callbackTimeoutMilliseconds);
				message.AppendLiteral(" ms), after which Windows removes a hook without notice; the hook was ");
				message.AppendFormatted((num != IntPtr.Zero) ? "installed again" : $"not installed again (error {num2})");
				message.AppendLiteral(" (previous hook unhooked: ");
				message.AppendFormatted(flag);
				message.AppendLiteral(").");
			}
			DiagnosticLog.Write("Hook", ref message);
			DiagnosticLog.Journal?.Incident("hook-reinstalled", "a hook callback reached LowLevelHooksTimeout, so the hook was installed again", "hook", _name, "durationMs", slowCallbackMilliseconds.ToString("0.0", CultureInfo.InvariantCulture), "timeoutMs", _callbackTimeoutMilliseconds, "reinstalled", num != IntPtr.Zero, "error", num2, "unhooked", flag);
		}

		public void Dispose()
		{
			if (_threadId != 0 && _thread.IsAlive)
			{
				NativeMethods.PostThreadMessage(_threadId, 18u, IntPtr.Zero, IntPtr.Zero);
				_thread.Join(TimeSpan.FromSeconds(2L));
			}
		}
	}
}
namespace SmartInput.Windows.Environments
{
	public sealed class EndSessionHandler : IDisposable
	{
		private static readonly nuint SubclassId = new UIntPtr(1u);

		private readonly nint _window;

		private readonly Action<bool> _onEndSession;

		private readonly NativeMethods.SubclassProc _procedure;

		private bool _installed;

		public bool IsInstalled => _installed;

		public EndSessionHandler(nint window, Action<bool> onEndSession)
		{
			_window = window;
			_onEndSession = onEndSession;
			_procedure = Procedure;
			_installed = window != IntPtr.Zero && NativeMethods.SetWindowSubclass(window, _procedure, SubclassId, UIntPtr.Zero);
		}

		public static bool RegisterApplicationRestart(string arguments)
		{
			int num = NativeMethods.RegisterApplicationRestart(arguments, 11u);
			if (num < 0)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(98, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("RegisterApplicationRestart failed (0x");
					message.AppendFormatted(num, "X8");
					message.AppendLiteral("); the installer will not start Diyar again after an upgrade.");
				}
				DiagnosticLog.Write("Session", ref message);
			}
			return num >= 0;
		}

		public bool RequestCloseApp()
		{
			nint lParam = new IntPtr(1L);
			bool flag = NativeMethods.SendMessage(_window, 17u, IntPtr.Zero, lParam) != IntPtr.Zero;
			if (flag)
			{
				NativeMethods.SendMessage(_window, 22u, new IntPtr(1), lParam);
			}
			return flag;
		}

		private nint Procedure(nint hWnd, uint msg, nint wParam, nint lParam, nuint subclassId, nuint referenceData)
		{
			switch (msg)
			{
			case 17u:
				NativeMethods.DefSubclassProc(hWnd, msg, wParam, lParam);
				return new IntPtr(1);
			case 22u:
				if (wParam != IntPtr.Zero)
				{
					bool flag = (((IntPtr)lParam).ToInt64() & 1) != 0;
					DiagnosticMessageHandler message = new DiagnosticMessageHandler(48, 1, out var shouldAppend);
					if (shouldAppend)
					{
						message.AppendLiteral("End of session: ");
						message.AppendFormatted(flag ? "the Restart Manager (an installer) asked Diyar to close" : "Windows is signing out or shutting down");
						message.AppendLiteral("; exiting through the Exit path.");
					}
					DiagnosticLog.Write("Session", ref message);
					try
					{
						_onEndSession(flag);
					}
					catch (Exception ex)
					{
						DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(33, 1, out shouldAppend);
						if (shouldAppend)
						{
							message2.AppendLiteral("Exit on end of session failed (");
							message2.AppendFormatted(ex.GetType().FullName);
							message2.AppendLiteral(").");
						}
						DiagnosticLog.Write("Session", ref message2);
					}
				}
				return IntPtr.Zero;
			case 130u:
				Remove();
				break;
			}
			return NativeMethods.DefSubclassProc(hWnd, msg, wParam, lParam);
		}

		private void Remove()
		{
			if (_installed)
			{
				_installed = false;
				NativeMethods.RemoveWindowSubclass(_window, _procedure, SubclassId);
			}
		}

		public void Dispose()
		{
			Remove();
		}
	}
	public sealed class EnvironmentObserverClient : ITypingEnvironmentSource, IAsyncDisposable
	{
		private readonly ProbeProcessHost _probeHost;

		private readonly IForegroundSignalSource _foregroundSignal;

		private readonly EnvironmentSnapshotStore _store;

		private readonly EnvironmentObservationOptions _options;

		private readonly TimeProvider _timeProvider;

		private readonly ObservationMode _mode;

		private readonly ISessionStateSource? _sessionState;

		private bool _sessionAvailable = true;

		private readonly Guid _observerSessionId = Guid.NewGuid();

		private readonly object _gate = new object();

		private int _focusEpoch;

		private const int SurfaceEpoch = 0;

		private int _requestId;

		private CancellationTokenSource? _debounceCts;

		private CancellationTokenSource? _changeDebounceCts;

		private int _observedChangeSequence;

		private bool _surfaceBaselineValid;

		private int _baselineSerial;

		private int _baselineGeneration;

		private bool _reconcileInFlight;

		private bool _baselinePending;

		private ITimer? _reconciliationTimer;

		private bool _started;

		private bool _disposed;

		private readonly object _publishGate = new object();

		public TypingEnvironmentSnapshot Current => _store.Current;

		public event EventHandler<TypingEnvironmentSnapshot>? SnapshotChanged
		{
			add
			{
				_store.Changed += value;
			}
			remove
			{
				_store.Changed -= value;
			}
		}

		public EnvironmentObserverClient(ProbeProcessHost probeHost, IForegroundSignalSource foregroundSignal, ObservationMode mode, EnvironmentObservationOptions? options = null, TimeProvider? timeProvider = null, ISessionStateSource? sessionState = null)
		{
			_sessionState = sessionState;
			_sessionAvailable = sessionState == null || sessionState.Current == SessionAvailability.Available;
			_probeHost = probeHost ?? throw new ArgumentNullException("probeHost");
			_foregroundSignal = foregroundSignal ?? throw new ArgumentNullException("foregroundSignal");
			_mode = mode;
			_options = options ?? EnvironmentObservationOptions.Default;
			_timeProvider = timeProvider ?? TimeProvider.System;
			_store = new EnvironmentSnapshotStore(BuildInvalidatedSnapshot("ObserverUnavailable"));
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			lock (_gate)
			{
				if (_started || _disposed)
				{
					return Task.CompletedTask;
				}
				_started = true;
			}
			_foregroundSignal.FocusHintChanged += OnFocusHintChanged;
			_probeHost.ContextChanged += OnContextChanged;
			if (_sessionState != null)
			{
				_sessionState.SessionStateChanged += OnSessionStateChanged;
			}
			_reconciliationTimer = _timeProvider.CreateTimer((object? _) =>
			{
				_sessionState?.Refresh();
				_ = ReconcileNowAsync();
			}, null, _options.MetadataFocusReconciliationInterval, _options.MetadataFocusReconciliationInterval);
			bool flag;
			lock (_gate)
			{
				if (_sessionState != null)
				{
					_sessionAvailable = _sessionState.Current == SessionAvailability.Available;
				}
				flag = !_sessionAvailable;
			}
			if (flag)
			{
				PublishSerialized(BuildUnavailableSnapshot());
				return Task.CompletedTask;
			}
			OnFocusHintChanged(this, EventArgs.Empty);
			return Task.CompletedTask;
		}

		private void OnFocusHintChanged(object? sender, EventArgs e)
		{
			int num;
			CancellationTokenSource cancellationTokenSource;
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable)
				{
					return;
				}
				num = ++_focusEpoch;
				_surfaceBaselineValid = false;
				_baselinePending = true;
				_debounceCts?.Cancel();
				cancellationTokenSource = (_debounceCts = new CancellationTokenSource());
			}
			PublishIfCurrent(num, BuildInvalidatedSnapshot("FocusChanged"));
			DebounceAndProbeAsync(num, cancellationTokenSource.Token);
		}

		private async Task DebounceAndProbeAsync(int focusEpochAtSchedule, CancellationToken debounceToken)
		{
			try
			{
				await DebounceAndProbeCoreAsync(focusEpochAtSchedule, debounceToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				lock (_gate)
				{
					if (_focusEpoch == focusEpochAtSchedule)
					{
						_baselinePending = false;
					}
				}
			}
		}

		private async Task DebounceAndProbeCoreAsync(int focusEpochAtSchedule, CancellationToken debounceToken)
		{
			try
			{
				await Task.Delay(_options.FocusProbeDebounce, _timeProvider, debounceToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
				return;
			}
			EnvironmentTokens tokens;
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable || focusEpochAtSchedule != _focusEpoch)
				{
					return;
				}
				tokens = new EnvironmentTokens
				{
					ObserverSessionId = _observerSessionId,
					HelperGeneration = _probeHost.HelperGeneration,
					FocusEpoch = focusEpochAtSchedule,
					SurfaceEpoch = 0,
					ObservedChangeSequence = _observedChangeSequence,
					RequestId = ++_requestId
				};
			}
			ProbeOutcome probeOutcome = await _probeHost.ProbeAsync(_mode, tokens).ConfigureAwait(continueOnCapturedContext: false);
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable || focusEpochAtSchedule != _focusEpoch)
				{
					return;
				}
			}
			if (probeOutcome.Status == ProbeOutcomeStatus.Succeeded && (object)probeOutcome.Result != null)
			{
				AcceptProbeResult(focusEpochAtSchedule, probeOutcome.Result);
				return;
			}
			string reasonCode = ((probeOutcome.ReasonCode.Length > 0) ? probeOutcome.ReasonCode : "ObserverUnavailable");
			PublishIfCurrent(focusEpochAtSchedule, BuildInvalidatedSnapshot(reasonCode));
		}

		public async Task ReconcileNowAsync()
		{
			int epoch;
			EnvironmentTokens tokens;
			lock (_gate)
			{
				if (_disposed || !_started || !_sessionAvailable || _baselinePending || _reconcileInFlight)
				{
					return;
				}
				_reconcileInFlight = true;
				epoch = _focusEpoch;
				tokens = new EnvironmentTokens
				{
					ObserverSessionId = _observerSessionId,
					HelperGeneration = _probeHost.HelperGeneration,
					FocusEpoch = epoch,
					SurfaceEpoch = 0,
					ObservedChangeSequence = _observedChangeSequence,
					RequestId = ++_requestId
				};
			}
			try
			{
				ProbeOutcome probeOutcome = await _probeHost.ProbeAsync(_mode, tokens).ConfigureAwait(continueOnCapturedContext: false);
				lock (_gate)
				{
					if (_disposed || !_sessionAvailable || epoch != _focusEpoch)
					{
						return;
					}
				}
				if (probeOutcome.Status == ProbeOutcomeStatus.Succeeded && (object)probeOutcome.Result != null)
				{
					AcceptProbeResult(epoch, probeOutcome.Result);
				}
				else if (probeOutcome.Status != ProbeOutcomeStatus.Superseded)
				{
					string reasonCode = ((probeOutcome.ReasonCode.Length > 0) ? probeOutcome.ReasonCode : "ObserverUnavailable");
					PublishIfCurrent(epoch, BuildInvalidatedSnapshot(reasonCode));
				}
			}
			finally
			{
				lock (_gate)
				{
					_reconcileInFlight = false;
				}
			}
		}

		private void AcceptProbeResult(int epoch, ProbeResultPayload payload)
		{
			bool flag = false;
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable || _focusEpoch != epoch)
				{
					return;
				}
				int helperGeneration = payload.Snapshot.Tokens.HelperGeneration;
				if (_surfaceBaselineValid)
				{
					flag = payload.SurfaceSerial == 0 || _baselineSerial == 0 || payload.SurfaceSerial != _baselineSerial || helperGeneration != _baselineGeneration;
				}
				else
				{
					_baselineSerial = payload.SurfaceSerial;
					_baselineGeneration = helperGeneration;
					_surfaceBaselineValid = true;
				}
			}
			if (flag)
			{
				AdvanceForDiscoveredTransition(epoch);
			}
			else
			{
				PublishProbeResult(epoch, payload.Snapshot);
			}
		}

		private void AdvanceForDiscoveredTransition(int epochAtDiscovery)
		{
			int num;
			CancellationTokenSource cancellationTokenSource;
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable || _focusEpoch != epochAtDiscovery)
				{
					return;
				}
				num = ++_focusEpoch;
				_surfaceBaselineValid = false;
				_baselinePending = true;
				_debounceCts?.Cancel();
				_changeDebounceCts?.Cancel();
				cancellationTokenSource = (_debounceCts = new CancellationTokenSource());
			}
			PublishIfCurrent(num, BuildInvalidatedSnapshot("FocusChanged"));
			DebounceAndProbeAsync(num, cancellationTokenSource.Token);
		}

		private void OnContextChanged(ContextChangedPayload payload)
		{
			int focusEpoch;
			int num;
			CancellationTokenSource cancellationTokenSource;
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable)
				{
					return;
				}
				focusEpoch = _focusEpoch;
				num = ++_observedChangeSequence;
				_changeDebounceCts?.Cancel();
				cancellationTokenSource = (_changeDebounceCts = new CancellationTokenSource());
			}
			TypingEnvironmentSnapshot current = _store.Current;
			if (current.Tokens.FocusEpoch == focusEpoch && current.Tokens.HelperGeneration == _probeHost.HelperGeneration && current.Tokens.RequestId != 0)
			{
				PublishIfCurrent(focusEpoch, InvalidateContextEvidence(current, num));
			}
			CoalesceAndReprobeAsync(focusEpoch, num, cancellationTokenSource.Token);
		}

		private static TypingEnvironmentSnapshot InvalidateContextEvidence(TypingEnvironmentSnapshot current, int sequence)
		{
			EnvironmentAssessment assessment = current.Assessment;
			AssessmentKind kind = assessment.Kind;
			bool flag = (uint)(kind - 6) <= 1u;
			bool flag2 = flag;
			ImmutableArray<string> reasonCodes = (assessment.ReasonCodes.Contains("ContextChangeReported") ? assessment.ReasonCodes : assessment.ReasonCodes.Add("ContextChangeReported"));
			return current with
			{
				Tokens = current.Tokens with
				{
					ObservedChangeSequence = sequence
				},
				ContextHealth = ContextHealth.Unknown,
				Assessment = assessment with
				{
					Kind = (flag2 ? AssessmentKind.MetadataOnly : assessment.Kind),
					ContentReadsPermitted = (!flag2 && assessment.ContentReadsPermitted),
					ReasonCodes = reasonCodes
				}
			};
		}

		private async Task CoalesceAndReprobeAsync(int focusEpochAtSchedule, int sequenceAtSchedule, CancellationToken token)
		{
			try
			{
				await Task.Delay(_options.TextSelectionEventCoalescing, _timeProvider, token).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
				return;
			}
			EnvironmentTokens tokens;
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable || focusEpochAtSchedule != _focusEpoch || sequenceAtSchedule != _observedChangeSequence)
				{
					return;
				}
				tokens = new EnvironmentTokens
				{
					ObserverSessionId = _observerSessionId,
					HelperGeneration = _probeHost.HelperGeneration,
					FocusEpoch = focusEpochAtSchedule,
					SurfaceEpoch = 0,
					ObservedChangeSequence = sequenceAtSchedule,
					RequestId = ++_requestId
				};
			}
			ProbeOutcome probeOutcome = await _probeHost.ProbeAsync(_mode, tokens).ConfigureAwait(continueOnCapturedContext: false);
			lock (_gate)
			{
				if (_disposed || !_sessionAvailable || focusEpochAtSchedule != _focusEpoch || sequenceAtSchedule != _observedChangeSequence)
				{
					return;
				}
			}
			if (probeOutcome.Status == ProbeOutcomeStatus.Succeeded && (object)probeOutcome.Result != null)
			{
				AcceptProbeResult(focusEpochAtSchedule, probeOutcome.Result);
				return;
			}
			string reasonCode = ((probeOutcome.ReasonCode.Length > 0) ? probeOutcome.ReasonCode : "ObserverUnavailable");
			PublishIfCurrent(focusEpochAtSchedule, BuildInvalidatedSnapshot(reasonCode));
		}

		private void OnSessionStateChanged(object? sender, SessionAvailability availability)
		{
			CancellationTokenSource cancellationTokenSource = null;
			int focusEpochAtSchedule;
			lock (_gate)
			{
				if (_disposed)
				{
					return;
				}
				bool flag = availability == SessionAvailability.Available;
				if (flag == _sessionAvailable)
				{
					return;
				}
				_sessionAvailable = flag;
				focusEpochAtSchedule = ++_focusEpoch;
				_surfaceBaselineValid = false;
				_baselinePending = flag;
				_debounceCts?.Cancel();
				_changeDebounceCts?.Cancel();
				if (flag)
				{
					cancellationTokenSource = (_debounceCts = new CancellationTokenSource());
				}
			}
			if (cancellationTokenSource == null)
			{
				PublishSerialized(BuildUnavailableSnapshot());
				return;
			}
			PublishSerialized(BuildInvalidatedSnapshot("SessionResumed"));
			DebounceAndProbeAsync(focusEpochAtSchedule, cancellationTokenSource.Token);
		}

		private TypingEnvironmentSnapshot BuildUnavailableSnapshot()
		{
			return BuildInvalidatedSnapshot("DesktopOrSessionUnavailable") with
			{
				Assessment = new EnvironmentAssessment
				{
					Kind = AssessmentKind.Unavailable,
					ContentReadsPermitted = false,
					ReasonCodes = ImmutableCollectionsMarshal.AsImmutableArray(new string[1] { "DesktopOrSessionUnavailable" })
				}
			};
		}

		private void PublishIfCurrent(int epoch, TypingEnvironmentSnapshot snapshot)
		{
			lock (_publishGate)
			{
				lock (_gate)
				{
					if (_disposed || !_sessionAvailable || _focusEpoch != epoch)
					{
						return;
					}
				}
				_store.Publish(snapshot);
			}
		}

		private void PublishSerialized(TypingEnvironmentSnapshot snapshot)
		{
			lock (_publishGate)
			{
				_store.Publish(snapshot);
			}
		}

		private int ReadObservedChangeSequence()
		{
			lock (_gate)
			{
				return _observedChangeSequence;
			}
		}

		private void PublishProbeResult(int epoch, TypingEnvironmentSnapshot snapshot)
		{
			int num = ReadObservedChangeSequence();
			PublishIfCurrent(epoch, (snapshot.Tokens.ObservedChangeSequence < num) ? InvalidateContextEvidence(snapshot, num) : snapshot);
			int num2 = ReadObservedChangeSequence();
			if (num2 != num)
			{
				PublishIfCurrent(epoch, InvalidateContextEvidence(snapshot, num2));
			}
		}

		private TypingEnvironmentSnapshot BuildInvalidatedSnapshot(string reasonCode)
		{
			int focusEpoch;
			lock (_gate)
			{
				focusEpoch = _focusEpoch;
			}
			return TypingEnvironmentSnapshot.Invalidated(new EnvironmentTokens
			{
				ObserverSessionId = _observerSessionId,
				HelperGeneration = _probeHost.HelperGeneration,
				FocusEpoch = focusEpoch,
				SurfaceEpoch = 0,
				ObservedChangeSequence = 0,
				RequestId = 0
			}, _timeProvider.GetTimestamp(), _timeProvider.GetUtcNow(), reasonCode);
		}

		public ValueTask DisposeAsync()
		{
			lock (_gate)
			{
				if (_disposed)
				{
					return ValueTask.CompletedTask;
				}
				_disposed = true;
				_changeDebounceCts?.Cancel();
				_debounceCts?.Cancel();
			}
			_foregroundSignal.FocusHintChanged -= OnFocusHintChanged;
			_probeHost.ContextChanged -= OnContextChanged;
			if (_sessionState != null)
			{
				_sessionState.SessionStateChanged -= OnSessionStateChanged;
			}
			_reconciliationTimer?.Dispose();
			return ValueTask.CompletedTask;
		}
	}
	public static class EnvironmentObserverComposition
	{
		public const string EnvironmentVariableName = "SMARTINPUT_ENVIRONMENT_OBSERVER";

		public static ObservationMode? ParseMode(string? raw)
		{
			if (string.IsNullOrWhiteSpace(raw))
			{
				return ObservationMode.MetadataOnly;
			}
			string text = raw.Trim().ToLowerInvariant();
			ObservationMode? result;
			if (text == "metadata")
			{
				result = ObservationMode.MetadataOnly;
			}
			else
			{
				result = ((!(text == "context")) ? ((ObservationMode?)null) : new ObservationMode?(ObservationMode.BoundedContext));
			}
			return result;
		}

		public static EnvironmentObserverHandle? TryCreate(string? rawMode, bool isVerificationSession, string helperExecutablePath, Action<string>? diagnosticSink = null, Func<IForegroundSignalSource>? foregroundSourceFactory = null, EnvironmentObservationOptions? options = null, Func<ISessionStateSource>? sessionStateFactory = null)
		{
			if (isVerificationSession)
			{
				return null;
			}
			ObservationMode? observationMode = ParseMode(rawMode);
			if (!observationMode.HasValue)
			{
				return null;
			}
			ProbeProcessHost probeProcessHost = new ProbeProcessHost(helperExecutablePath, null, options, null, diagnosticSink);
			IForegroundSignalSource foregroundSignalSource;
			if (foregroundSourceFactory != null)
			{
				foregroundSignalSource = foregroundSourceFactory();
			}
			else
			{
				IForegroundSignalSource foregroundSignalSource2 = new ForegroundMonitor();
				foregroundSignalSource = foregroundSignalSource2;
			}
			IForegroundSignalSource foregroundSignalSource3 = foregroundSignalSource;
			ISessionStateSource sessionStateSource;
			if (sessionStateFactory != null)
			{
				sessionStateSource = sessionStateFactory();
			}
			else
			{
				ISessionStateSource sessionStateSource2 = new SessionStateMonitor();
				sessionStateSource = sessionStateSource2;
			}
			ISessionStateSource sessionStateSource3 = sessionStateSource;
			EnvironmentObserverClient client = new EnvironmentObserverClient(probeProcessHost, foregroundSignalSource3, observationMode.Value, options, null, sessionStateSource3);
			return new EnvironmentObserverHandle(probeProcessHost, foregroundSignalSource3, client, observationMode.Value, sessionStateSource3);
		}
	}
	public sealed class EnvironmentObserverHandle : IAsyncDisposable
	{
		private readonly ProbeProcessHost _host;

		private readonly IForegroundSignalSource _foreground;

		private readonly ISessionStateSource _session;

		private int _disposed;

		public EnvironmentObserverClient Client { get; }

		public ObservationMode Mode { get; }

		public int? HelperProcessId => _host.CurrentProcessId;

		internal EnvironmentObserverHandle(ProbeProcessHost host, IForegroundSignalSource foreground, EnvironmentObserverClient client, ObservationMode mode, ISessionStateSource session)
		{
			_session = session;
			_host = host;
			_foreground = foreground;
			Client = client;
			Mode = mode;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await _host.StartAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (_foreground is ForegroundMonitor foregroundMonitor)
			{
				foregroundMonitor.Start();
			}
			if (_session is SessionStateMonitor sessionStateMonitor)
			{
				sessionStateMonitor.Start();
				sessionStateMonitor.Refresh();
			}
			await Client.StartAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async ValueTask DisposeAsync()
		{
			if (Interlocked.Exchange(ref _disposed, 1) == 0)
			{
				await BoundedAsync(() => Client.DisposeAsync().AsTask(), TimeSpan.FromSeconds(2L)).ConfigureAwait(continueOnCapturedContext: false);
				if (_foreground is IDisposable disposable)
				{
					disposable.Dispose();
				}
				(_session as IDisposable)?.Dispose();
				await BoundedAsync(() => _host.DisposeAsync().AsTask(), TimeSpan.FromSeconds(2L)).ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private static async Task BoundedAsync(Func<Task> step, TimeSpan timeout)
		{
			try
			{
				await step().WaitAsync(timeout).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex) when ((ex is TimeoutException || ex is AggregateException || ex is InvalidOperationException) ? true : false)
			{
			}
		}
	}
	public sealed class EnvironmentProfileFile
	{
		public string ProfileId { get; set; } = string.Empty;

		public int ProfileVersion { get; set; }

		public string ProcessExecutableBaseName { get; set; } = string.Empty;

		public string? MinTestedApplicationVersion { get; set; }

		public string? MaxTestedApplicationVersion { get; set; }

		public string? UiaFrameworkId { get; set; }

		public string? ExactOrPatternConstrainedAutomationId { get; set; }

		public List<EnvironmentProfileAncestorConditionFile> AncestorConditions { get; set; } = new List<EnvironmentProfileAncestorConditionFile>();

		public List<string> ExclusionAutomationIds { get; set; } = new List<string>();

		public string InferredRole { get; set; } = string.Empty;

		public List<string> FixtureReferences { get; set; } = new List<string>();
	}
	public sealed class EnvironmentProfileAncestorConditionFile
	{
		public string? AutomationIdPattern { get; set; }

		public string? ControlTypePattern { get; set; }

		public string? ClassNamePattern { get; set; }
	}
	public sealed record EnvironmentProfileLoadDiagnostic(string FileName, string ReasonCode);
	public sealed record EnvironmentProfileLoadResult(EnvironmentProfileRegistry Registry, ImmutableArray<EnvironmentProfileLoadDiagnostic> Diagnostics);
	public static class EnvironmentProfileFileLoader
	{
		private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			MaxDepth = 8
		};

		public static EnvironmentProfileLoadResult LoadFromDirectory(string directoryPath)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(directoryPath, "directoryPath");
			ImmutableArray<EnvironmentProfile>.Builder builder = ImmutableArray.CreateBuilder<EnvironmentProfile>();
			ImmutableArray<EnvironmentProfileLoadDiagnostic>.Builder builder2 = ImmutableArray.CreateBuilder<EnvironmentProfileLoadDiagnostic>();
			if (!Directory.Exists(directoryPath))
			{
				return new EnvironmentProfileLoadResult(EnvironmentProfileRegistry.Empty, builder2.ToImmutable());
			}
			foreach (string item in Directory.EnumerateFiles(directoryPath, "*.json", SearchOption.TopDirectoryOnly).OrderBy((string f) => f, StringComparer.Ordinal))
			{
				string fileName = Path.GetFileName(item);
				try
				{
					EnvironmentProfileFile environmentProfileFile = JsonSerializer.Deserialize<EnvironmentProfileFile>(File.ReadAllText(item), JsonOptions);
					EnvironmentProfile profile;
					string reasonCode;
					if (environmentProfileFile == null)
					{
						builder2.Add(new EnvironmentProfileLoadDiagnostic(fileName, "EmptyOrNullDocument"));
					}
					else if (!TryConvert(environmentProfileFile, out profile, out reasonCode))
					{
						builder2.Add(new EnvironmentProfileLoadDiagnostic(fileName, reasonCode));
					}
					else
					{
						builder.Add(profile);
					}
				}
				catch (JsonException)
				{
					builder2.Add(new EnvironmentProfileLoadDiagnostic(fileName, "MalformedJson"));
				}
				catch (IOException)
				{
					builder2.Add(new EnvironmentProfileLoadDiagnostic(fileName, "ReadFailed"));
				}
			}
			return new EnvironmentProfileLoadResult(new EnvironmentProfileRegistry(builder), builder2.ToImmutable());
		}

		private static bool TryConvert(EnvironmentProfileFile file, out EnvironmentProfile profile, out string reasonCode)
		{
			profile = null;
			reasonCode = string.Empty;
			if (string.IsNullOrWhiteSpace(file.ProfileId) || string.IsNullOrWhiteSpace(file.ProcessExecutableBaseName) || string.IsNullOrWhiteSpace(file.InferredRole))
			{
				reasonCode = "MissingRequiredField";
				return false;
			}
			if (file.ProfileVersion <= 0)
			{
				reasonCode = "InvalidProfileVersion";
				return false;
			}
			if (!Enum.TryParse<FieldRole>(file.InferredRole, ignoreCase: true, out var result))
			{
				reasonCode = "InvalidInferredRole";
				return false;
			}
			profile = new EnvironmentProfile
			{
				ProfileId = file.ProfileId,
				ProfileVersion = file.ProfileVersion,
				ProcessExecutableBaseName = file.ProcessExecutableBaseName,
				MinTestedApplicationVersion = file.MinTestedApplicationVersion,
				MaxTestedApplicationVersion = file.MaxTestedApplicationVersion,
				UiaFrameworkId = file.UiaFrameworkId,
				ExactOrPatternConstrainedAutomationId = file.ExactOrPatternConstrainedAutomationId,
				AncestorConditions = ImmutableCollectionsMarshal.AsImmutableArray(file.AncestorConditions.Select((EnvironmentProfileAncestorConditionFile a) => new EnvironmentProfileAncestorCondition
				{
					AutomationIdPattern = a.AutomationIdPattern,
					ControlTypePattern = a.ControlTypePattern,
					ClassNamePattern = a.ClassNamePattern
				}).ToArray()),
				ExclusionAutomationIds = ImmutableCollectionsMarshal.AsImmutableArray(file.ExclusionAutomationIds.ToArray()),
				InferredRole = result,
				FixtureReferences = ImmutableCollectionsMarshal.AsImmutableArray(file.FixtureReferences.ToArray())
			};
			return true;
		}
	}
	public sealed class EnvironmentSnapshotStore
	{
		private TypingEnvironmentSnapshot _current;

		public TypingEnvironmentSnapshot Current => Volatile.Read(in _current);

		public event EventHandler<TypingEnvironmentSnapshot>? Changed;

		public EnvironmentSnapshotStore(TypingEnvironmentSnapshot initial)
		{
			_current = initial;
		}

		public void Publish(TypingEnvironmentSnapshot snapshot)
		{
			ArgumentNullException.ThrowIfNull(snapshot, "snapshot");
			Volatile.Write(ref _current, snapshot);
			Changed?.Invoke(this, snapshot);
		}
	}
	public sealed class ForegroundMonitor : IForegroundSignalSource, IDisposable
	{
		private delegate void WinEventDelegate(nint hWinEventHook, uint eventType, nint hwnd, int idObject, int idChild, uint idEventThread, uint idEventTime);

		private struct MSG
		{
			public nint hwnd;

			public uint message;

			public nint wParam;

			public nint lParam;

			public uint time;

			public int ptX;

			public int ptY;
		}

		private const uint EVENT_SYSTEM_FOREGROUND = 3u;

		private const uint EVENT_OBJECT_FOCUS = 32773u;

		private const uint WINEVENT_OUTOFCONTEXT = 0u;

		private const uint WINEVENT_SKIPOWNPROCESS = 2u;

		private const uint WM_QUIT = 18u;

		private readonly object _gate = new object();

		private Thread? _thread;

		private volatile uint _threadId;

		private nint _hook1 = IntPtr.Zero;

		private nint _hook2 = IntPtr.Zero;

		private WinEventDelegate? _callback;

		private bool _disposed;

		private readonly ManualResetEventSlim _threadReady = new ManualResetEventSlim(initialState: false);

		public event EventHandler? FocusHintChanged;

		[DllImport("user32.dll", SetLastError = true)]
		private static extern nint SetWinEventHook(uint eventMin, uint eventMax, nint hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

		[DllImport("user32.dll", SetLastError = true)]
		private static extern bool UnhookWinEvent(nint hWinEventHook);

		[DllImport("user32.dll")]
		private static extern int GetMessage(out MSG lpMsg, nint hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

		[DllImport("user32.dll")]
		private static extern bool TranslateMessage(ref MSG lpMsg);

		[DllImport("user32.dll")]
		private static extern nint DispatchMessage(ref MSG lpMsg);

		[DllImport("user32.dll")]
		private static extern bool PostThreadMessage(uint idThread, uint msg, nint wParam, nint lParam);

		[DllImport("kernel32.dll")]
		private static extern uint GetCurrentThreadId();

		public void Start()
		{
			lock (_gate)
			{
				if (_thread != null)
				{
					return;
				}
				_thread = new Thread(ThreadMain)
				{
					IsBackground = true,
					Name = "SmartInput.Environments.ForegroundMonitor"
				};
				_thread.Start();
			}
			_threadReady.Wait(TimeSpan.FromSeconds(5L));
		}

		private void ThreadMain()
		{
			_threadId = GetCurrentThreadId();
			_callback = OnWinEvent;
			_hook1 = SetWinEventHook(3u, 3u, IntPtr.Zero, _callback, 0u, 0u, 2u);
			_hook2 = SetWinEventHook(32773u, 32773u, IntPtr.Zero, _callback, 0u, 0u, 2u);
			_threadReady.Set();
			MSG lpMsg;
			while (GetMessage(out lpMsg, IntPtr.Zero, 0u, 0u) > 0)
			{
				TranslateMessage(ref lpMsg);
				DispatchMessage(ref lpMsg);
			}
			if (_hook1 != IntPtr.Zero)
			{
				UnhookWinEvent(_hook1);
				_hook1 = IntPtr.Zero;
			}
			if (_hook2 != IntPtr.Zero)
			{
				UnhookWinEvent(_hook2);
				_hook2 = IntPtr.Zero;
			}
		}

		private void OnWinEvent(nint hWinEventHook, uint eventType, nint hwnd, int idObject, int idChild, uint idEventThread, uint idEventTime)
		{
			try
			{
				FocusHintChanged?.Invoke(this, EventArgs.Empty);
			}
			catch (Exception exception)
			{
				FaultRing.Note(FaultSite.ForegroundHint, exception);
			}
		}

		public void Dispose()
		{
			lock (_gate)
			{
				if (_disposed)
				{
					return;
				}
				_disposed = true;
				if (_thread != null && _threadId != 0)
				{
					PostThreadMessage(_threadId, 18u, IntPtr.Zero, IntPtr.Zero);
					_thread.Join(TimeSpan.FromSeconds(2L));
				}
				_thread = null;
			}
			_threadReady.Dispose();
		}
	}
	public static class HelperStderrSanitizer
	{
		[GeneratedRegex("^ProtocolError: (InvalidLength|TruncatedFrame|OversizedPayload|MalformedJson|InvalidEnumValue|ExceedsMaxDepth|UnsupportedProtocolVersion|StreamClosed)$")]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex ProtocolErrorLine()
		{
			return <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__ProtocolErrorLine_0.Instance;
		}

		[GeneratedRegex("^ProtocolError: expected helloAccepted, got (Hello|HelloAccepted|Probe|ProbeResult|Invalidate|Stop|Stopped|ContextChanged)$")]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex UnexpectedFrameLine()
		{
			return <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__UnexpectedFrameLine_1.Instance;
		}

		[GeneratedRegex("^Fatal: [A-Za-z]{1,60}Exception$")]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex FatalLine()
		{
			return <RegexGenerator_g>F1C771B2F7895FCD8FD7042587F7C1578B0F67A3F3B708EBE502183DFBFC19F77__FatalLine_2.Instance;
		}

		public static IReadOnlyList<string> Sanitize(string raw)
		{
			ArgumentNullException.ThrowIfNull(raw, "raw");
			List<string> list = new List<string>();
			string[] array = raw.Split('\n', StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].TrimEnd('\r');
				if (text.Length != 0)
				{
					list.Add(IsKnownCode(text) ? text : $"[helper stderr line withheld: {text.Length} chars]");
				}
			}
			return list;
		}

		public static string SanitizeToSingleLine(string raw)
		{
			IReadOnlyList<string> readOnlyList = Sanitize(raw);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < readOnlyList.Count && i < 8; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(" | ");
				}
				stringBuilder.Append(readOnlyList[i]);
			}
			if (readOnlyList.Count > 8)
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(25, 1, stringBuilder2);
				handler.AppendLiteral(" | [");
				handler.AppendFormatted(readOnlyList.Count - 8);
				handler.AppendLiteral(" more lines withheld]");
				stringBuilder2.Append(ref handler);
			}
			return stringBuilder.ToString();
		}

		private static bool IsKnownCode(string line)
		{
			if (!ProtocolErrorLine().IsMatch(line) && !UnexpectedFrameLine().IsMatch(line))
			{
				return FatalLine().IsMatch(line);
			}
			return true;
		}
	}
	public interface IForegroundSignalSource
	{
		event EventHandler? FocusHintChanged;
	}
	public enum ProbeOutcomeStatus
	{
		Succeeded,
		TimedOut,
		Failed,
		Superseded,
		Unavailable
	}
	public sealed record ProbeOutcome
	{
		public required ProbeOutcomeStatus Status { get; init; }

		public ProbeResultPayload? Result { get; init; }

		public string ReasonCode { get; init; } = string.Empty;

		public static ProbeOutcome Unavailable(string reasonCode)
		{
			return new ProbeOutcome
			{
				Status = ProbeOutcomeStatus.Unavailable,
				ReasonCode = reasonCode
			};
		}

		public static ProbeOutcome Superseded()
		{
			return new ProbeOutcome
			{
				Status = ProbeOutcomeStatus.Superseded,
				ReasonCode = "Superseded"
			};
		}

		public static ProbeOutcome TimedOut(string reasonCode)
		{
			return new ProbeOutcome
			{
				Status = ProbeOutcomeStatus.TimedOut,
				ReasonCode = reasonCode
			};
		}

		public static ProbeOutcome Failed(string reasonCode)
		{
			return new ProbeOutcome
			{
				Status = ProbeOutcomeStatus.Failed,
				ReasonCode = reasonCode
			};
		}

		public static ProbeOutcome Succeeded(ProbeResultPayload result)
		{
			return new ProbeOutcome
			{
				Status = ProbeOutcomeStatus.Succeeded,
				Result = result
			};
		}
	}
	public sealed class ProbeProcessHost : IAsyncDisposable
	{
		private readonly record struct DispatchTicket(ProbeRequestPayload Request, TaskCompletionSource<ProbeOutcome> Tcs, int Generation, Stream Stdin, CancellationToken Lifetime);

		private readonly string _executablePath;

		private readonly IReadOnlyList<string> _arguments;

		private readonly EnvironmentObservationOptions _options;

		private readonly TimeProvider _timeProvider;

		private readonly Action<string>? _diagnosticSink;

		private readonly object _gate = new object();

		private Process? _process;

		private JobObjectOwner? _job;

		private Stream? _stdin;

		private Stream? _stdout;

		private CancellationTokenSource? _lifetimeCts;

		private int _helperGeneration;

		private int _readyGeneration = -1;

		private int _launchesInProgress;

		private int _nextRequestId;

		private int _pendingRequestId = -1;

		private TaskCompletionSource<ProbeOutcome>? _inFlight;

		private (ProbeRequestPayload Request, TaskCompletionSource<ProbeOutcome> Tcs)? _queuedNext;

		private CancellationTokenSource? _pendingWatchdogCts;

		private readonly List<long> _restartTimestampsUtcTicks = new List<long>();

		private DateTimeOffset? _cooldownUntilUtc;

		private bool _disposed;

		private bool _stopRequested;

		public int HelperGeneration
		{
			get
			{
				lock (_gate)
				{
					return _helperGeneration;
				}
			}
		}

		public bool IsUnavailable
		{
			get
			{
				lock (_gate)
				{
					return IsCooldownActiveLocked();
				}
			}
		}

		public int RestartCount
		{
			get
			{
				lock (_gate)
				{
					return _restartTimestampsUtcTicks.Count;
				}
			}
		}

		internal Func<Task>? TestOnlyAfterRestartLaunchHookAsync { get; set; }

		public int? CurrentProcessId
		{
			get
			{
				lock (_gate)
				{
					if (_process == null)
					{
						return null;
					}
					try
					{
						return _process.Id;
					}
					catch (InvalidOperationException)
					{
						return null;
					}
				}
			}
		}

		internal Func<int, Task>? TestOnlyAfterHandshakeHookAsync { get; set; }

		public event Action<ContextChangedPayload>? ContextChanged;

		public ProbeProcessHost(string executablePath, IReadOnlyList<string>? arguments = null, EnvironmentObservationOptions? options = null, TimeProvider? timeProvider = null, Action<string>? diagnosticSink = null)
		{
			ArgumentException.ThrowIfNullOrWhiteSpace(executablePath, "executablePath");
			_executablePath = executablePath;
			_arguments = arguments ?? Array.Empty<string>();
			_options = options ?? EnvironmentObservationOptions.Default;
			_timeProvider = timeProvider ?? TimeProvider.System;
			_diagnosticSink = diagnosticSink;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			try
			{
				await LaunchAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch
			{
				FailQueuedAsUnavailable();
				throw;
			}
			PromoteQueuedIfReady();
		}

		public Task<ProbeOutcome> ProbeAsync(ObservationMode mode, EnvironmentTokens tokens)
		{
			ProbeRequestPayload probeRequestPayload = new ProbeRequestPayload
			{
				Mode = mode,
				Tokens = tokens
			};
			TaskCompletionSource<ProbeOutcome> taskCompletionSource = new TaskCompletionSource<ProbeOutcome>(TaskCreationOptions.RunContinuationsAsynchronously);
			DispatchTicket? dispatchTicket = null;
			bool flag = false;
			lock (_gate)
			{
				if (_disposed)
				{
					taskCompletionSource.SetResult(ProbeOutcome.Unavailable("ObserverUnavailable"));
					return taskCompletionSource.Task;
				}
				if (IsCooldownActiveLocked())
				{
					taskCompletionSource.SetResult(ProbeOutcome.Unavailable("ObserverUnavailable"));
					return taskCompletionSource.Task;
				}
				if (_inFlight == null && IsReadyLocked())
				{
					_inFlight = taskCompletionSource;
					dispatchTicket = TakeTicketLocked(probeRequestPayload, taskCompletionSource);
				}
				else
				{
					_queuedNext?.Tcs.TrySetResult(ProbeOutcome.Superseded());
					_queuedNext = (probeRequestPayload, taskCompletionSource);
					flag = _inFlight == null && _launchesInProgress == 0 && _process == null;
					if (flag)
					{
						_launchesInProgress++;
					}
				}
			}
			if (dispatchTicket.HasValue)
			{
				DispatchTicket valueOrDefault = dispatchTicket.GetValueOrDefault();
				SendRequestAsync(valueOrDefault);
			}
			else if (flag)
			{
				RelaunchIdleHelperAsync();
			}
			return taskCompletionSource.Task;
		}

		private bool IsReadyLocked()
		{
			if (!_disposed && _process != null && _lifetimeCts != null)
			{
				return _readyGeneration == _helperGeneration;
			}
			return false;
		}

		private DispatchTicket TakeTicketLocked(ProbeRequestPayload request, TaskCompletionSource<ProbeOutcome> tcs)
		{
			return new DispatchTicket(request, tcs, _helperGeneration, _stdin, _lifetimeCts.Token);
		}

		private void PromoteQueuedIfReady()
		{
			DispatchTicket? dispatchTicket = null;
			lock (_gate)
			{
				if (_inFlight == null)
				{
					(ProbeRequestPayload, TaskCompletionSource<ProbeOutcome>)? queuedNext = _queuedNext;
					if (queuedNext.HasValue)
					{
						(ProbeRequestPayload, TaskCompletionSource<ProbeOutcome>) valueOrDefault = queuedNext.GetValueOrDefault();
						if (IsReadyLocked())
						{
							_inFlight = valueOrDefault.Item2;
							_queuedNext = null;
							dispatchTicket = TakeTicketLocked(valueOrDefault.Item1, valueOrDefault.Item2);
						}
					}
				}
			}
			if (dispatchTicket.HasValue)
			{
				DispatchTicket valueOrDefault2 = dispatchTicket.GetValueOrDefault();
				SendRequestAsync(valueOrDefault2);
			}
		}

		private async Task RelaunchIdleHelperAsync()
		{
			try
			{
				await LaunchAsync(CancellationToken.None, alreadyCounted: true).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex)
			{
				_diagnosticSink?.Invoke("Probe helper launch failed: " + ex.Message);
				lock (_gate)
				{
					_cooldownUntilUtc = _timeProvider.GetUtcNow() + _options.RestartCooldown;
				}
				FailQueuedAsUnavailable();
				return;
			}
			PromoteQueuedIfReady();
		}

		private async Task LaunchAsync(CancellationToken cancellationToken, bool alreadyCounted = false)
		{
			if (!alreadyCounted)
			{
				lock (_gate)
				{
					_launchesInProgress++;
				}
			}
			try
			{
				await LaunchCoreAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				lock (_gate)
				{
					_launchesInProgress--;
				}
			}
		}

		private async Task LaunchCoreAsync(CancellationToken cancellationToken)
		{
			JobObjectOwner job = JobObjectOwner.Create();
			ProcessStartInfo processStartInfo = new ProcessStartInfo
			{
				FileName = _executablePath,
				UseShellExecute = false,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				CreateNoWindow = true
			};
			foreach (string argument in _arguments)
			{
				processStartInfo.ArgumentList.Add(argument);
			}
			Process process = new Process
			{
				StartInfo = processStartInfo,
				EnableRaisingEvents = true
			};
			try
			{
				if (!process.Start())
				{
					job.Dispose();
					throw new InvalidOperationException("Failed to start probe helper at '" + _executablePath + "'.");
				}
				Log($"Child started, pid={process.Id}");
				job.Assign(process.SafeHandle.DangerousGetHandle());
				Log($"Child pid={process.Id} assigned to job object");
			}
			catch
			{
				job.Dispose();
				try
				{
					if (!process.HasExited)
					{
						process.Kill(entireProcessTree: true);
					}
				}
				catch
				{
				}
				throw;
			}
			CancellationTokenSource lifetimeCts = new CancellationTokenSource();
			Stream stdin;
			Stream stdout;
			int myGeneration;
			lock (_gate)
			{
				_process = process;
				_job = job;
				_stdin = process.StandardInput.BaseStream;
				_stdout = process.StandardOutput.BaseStream;
				stdin = _stdin;
				stdout = _stdout;
				_lifetimeCts = lifetimeCts;
				_helperGeneration++;
				myGeneration = _helperGeneration;
				_readyGeneration = -1;
				_pendingRequestId = -1;
				_stopRequested = false;
			}
			process.Exited += (object? _, EventArgs _) =>
			{
				OnProcessExited(myGeneration, ExitCodeOf(process));
			};
			DrainStandardErrorAsync(process.StandardError, lifetimeCts.Token);
			using CancellationTokenSource startupDeadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, lifetimeCts.Token);
			startupDeadline.CancelAfter(_options.HelperStartupDeadline);
			try
			{
				await HandshakeAsync(startupDeadline.Token, myGeneration, stdout, stdin).ConfigureAwait(continueOnCapturedContext: false);
				Log($"Handshake complete, generation={myGeneration}");
			}
			catch
			{
				AbandonFailedLaunch(myGeneration, lifetimeCts, process, job);
				throw;
			}
			Func<int, Task> testOnlyAfterHandshakeHookAsync = TestOnlyAfterHandshakeHookAsync;
			if (testOnlyAfterHandshakeHookAsync != null)
			{
				await testOnlyAfterHandshakeHookAsync(myGeneration).ConfigureAwait(continueOnCapturedContext: false);
			}
			bool flag;
			lock (_gate)
			{
				flag = !_disposed && _helperGeneration == myGeneration && _lifetimeCts == lifetimeCts;
				if (flag)
				{
					_readyGeneration = myGeneration;
				}
			}
			if (!flag)
			{
				Log($"Handshake completed for obsolete generation={myGeneration}; not ready");
			}
			else
			{
				Task.Run(() => ReaderLoopAsync(lifetimeCts.Token, myGeneration));
			}
		}

		private void AbandonFailedLaunch(int generation, CancellationTokenSource lifetimeCts, Process process, JobObjectOwner job)
		{
			lock (_gate)
			{
				if (_helperGeneration == generation && _lifetimeCts == lifetimeCts)
				{
					_process = null;
					_job = null;
					_lifetimeCts = null;
					_stdin = null;
					_stdout = null;
					_readyGeneration = -1;
				}
			}
			try
			{
				lifetimeCts.Cancel();
			}
			catch (ObjectDisposedException)
			{
			}
			job.Dispose();
			try
			{
				process.Dispose();
			}
			catch (InvalidOperationException)
			{
			}
		}

		private async Task HandshakeAsync(CancellationToken cancellationToken, int generation, Stream stdout, Stream stdin)
		{
			ProbeFrame probeFrame;
			try
			{
				probeFrame = await ProbeFrameCodec.ReadFrameAsync(stdout, _options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
				throw new TimeoutException("The probe helper did not complete its handshake within the startup deadline.");
			}
			if (probeFrame.MessageKind != ProbeMessageKind.Hello)
			{
				throw new InvalidOperationException($"Expected a Hello frame first, got {probeFrame.MessageKind}.");
			}
			ProbeFrame frame = ProbeFrameCodec.EncodePayload(generation, 0, ProbeMessageKind.HelloAccepted, new HelloAcceptedPayload
			{
				AcceptedProtocolVersion = 1
			}, _options);
			await ProbeFrameCodec.WriteFrameAsync(stdin, frame, _options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task SendRequestAsync(DispatchTicket ticket)
		{
			Stream stdin = ticket.Stdin;
			CancellationToken lifetime = ticket.Lifetime;
			int generation = ticket.Generation;
			int requestId;
			CancellationTokenSource watchdogCts;
			lock (_gate)
			{
				if (_disposed || _helperGeneration != generation)
				{
					if (_inFlight == ticket.Tcs)
					{
						_inFlight = null;
					}
					ticket.Tcs.TrySetResult(ProbeOutcome.Unavailable("ObserverUnavailable"));
					return;
				}
				requestId = (_pendingRequestId = ++_nextRequestId);
				watchdogCts = (_pendingWatchdogCts = CancellationTokenSource.CreateLinkedTokenSource(lifetime));
			}
			Log($"Dispatching probe request requestId={requestId} generation={generation}");
			try
			{
				ProbeFrame frame = ProbeFrameCodec.EncodePayload(generation, requestId, ProbeMessageKind.Probe, ticket.Request, _options);
				await ProbeFrameCodec.WriteFrameAsync(stdin, frame, _options, lifetime).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception ex) when (!(ex is OperationCanceledException))
			{
				CompletePendingAndAdvance(requestId, generation, ProbeOutcome.Failed("ObserverUnavailable"), acceptAnyPending: false, helperUnusable: true);
				await HandleFatalChildConditionAsync(generation, "SendFailed").ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			try
			{
				await Task.Delay(_options.HelperRequestWatchdog, _timeProvider, watchdogCts.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
				return;
			}
			Log($"Watchdog expired requestId={requestId} generation={generation}");
			if (CompletePendingAndAdvance(requestId, generation, ProbeOutcome.TimedOut("ProviderTimeout"), acceptAnyPending: false, helperUnusable: true))
			{
				await HandleFatalChildConditionAsync(generation, "Watchdog").ConfigureAwait(continueOnCapturedContext: false);
			}
		}

		private void HandleContextChangedFrame(ProbeFrame frame, int readerGeneration)
		{
			lock (_gate)
			{
				if (_disposed || readerGeneration != _helperGeneration || frame.HelperGeneration != _helperGeneration)
				{
					_diagnosticSink?.Invoke("Discarded a context-changed notice from a stale or mismatched helper generation.");
					return;
				}
			}
			ContextChangedPayload item;
			try
			{
				item = ProbeFrameCodec.DecodePayload<ContextChangedPayload>(frame, _options);
			}
			catch (ProbeProtocolException)
			{
				return;
			}
			Action<ContextChangedPayload> action = ContextChanged;
			if (action == null)
			{
				return;
			}
			ThreadPool.UnsafeQueueUserWorkItem(((Action<ContextChangedPayload> Handler, ContextChangedPayload Payload) state) =>
			{
				try
				{
					state.Handler(state.Payload);
				}
				catch (Exception)
				{
				}
			}, (action, item), preferLocal: false);
		}

		private async Task ReaderLoopAsync(CancellationToken cancellationToken, int myGeneration)
		{
			Stream stdout;
			lock (_gate)
			{
				stdout = _stdout;
			}
			while (!cancellationToken.IsCancellationRequested)
			{
				ProbeFrame frame;
				try
				{
					frame = await ProbeFrameCodec.ReadFrameAsync(stdout, _options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (OperationCanceledException)
				{
					Log("Reader loop canceled (lifetime ended)");
					break;
				}
				catch (ProbeProtocolException ex2)
				{
					Log($"Reader loop protocol violation: {ex2.FailureKind}");
					CompletePendingAndAdvance(-1, myGeneration, ProbeOutcome.Failed("ObserverUnavailable"), acceptAnyPending: true, helperUnusable: true);
					string reason = ((ex2.FailureKind == ProbeProtocolFailureKind.StreamClosed) ? "StreamClosed" : "MalformedFrame");
					await HandleFatalChildConditionAsync(myGeneration, reason).ConfigureAwait(continueOnCapturedContext: false);
					break;
				}
				if (frame.MessageKind == ProbeMessageKind.ContextChanged)
				{
					HandleContextChangedFrame(frame, myGeneration);
				}
				else
				{
					if (frame.MessageKind != ProbeMessageKind.ProbeResult)
					{
						continue;
					}
					ProbeResultPayload result;
					try
					{
						result = ProbeFrameCodec.DecodePayload<ProbeResultPayload>(frame, _options);
					}
					catch (ProbeProtocolException)
					{
						continue;
					}
					lock (_gate)
					{
						if (frame.RequestId != _pendingRequestId || frame.HelperGeneration != _helperGeneration)
						{
							_diagnosticSink?.Invoke("Discarded a late probe response whose tokens no longer match.");
							continue;
						}
					}
					CompletePendingAndAdvance(frame.RequestId, frame.HelperGeneration, ProbeOutcome.Succeeded(result));
				}
			}
		}

		private bool CompletePendingAndAdvance(int requestId, int generation, ProbeOutcome outcome, bool acceptAnyPending = false, bool helperUnusable = false)
		{
			TaskCompletionSource<ProbeOutcome> taskCompletionSource = null;
			DispatchTicket? dispatchTicket = null;
			lock (_gate)
			{
				bool flag = acceptAnyPending || (requestId == _pendingRequestId && generation == _helperGeneration);
				if ((_inFlight != null) & flag)
				{
					taskCompletionSource = _inFlight;
					_inFlight = null;
					_pendingRequestId = -1;
					_pendingWatchdogCts?.Cancel();
					_pendingWatchdogCts = null;
					if (helperUnusable && generation == _helperGeneration)
					{
						_readyGeneration = -1;
					}
					(ProbeRequestPayload, TaskCompletionSource<ProbeOutcome>)? queuedNext = _queuedNext;
					if (queuedNext.HasValue)
					{
						(ProbeRequestPayload, TaskCompletionSource<ProbeOutcome>) valueOrDefault = queuedNext.GetValueOrDefault();
						if (IsReadyLocked())
						{
							_inFlight = valueOrDefault.Item2;
							_queuedNext = null;
							dispatchTicket = TakeTicketLocked(valueOrDefault.Item1, valueOrDefault.Item2);
						}
					}
				}
			}
			taskCompletionSource?.TrySetResult(outcome);
			if (dispatchTicket.HasValue)
			{
				DispatchTicket valueOrDefault2 = dispatchTicket.GetValueOrDefault();
				SendRequestAsync(valueOrDefault2);
			}
			return taskCompletionSource != null;
		}

		private void OnProcessExited(int myGeneration, int? exitCode = null)
		{
			try
			{
				OnProcessExitedCore(myGeneration, exitCode);
			}
			catch (Exception ex)
			{
				FaultRing.Note(FaultSite.Probe, ex);
				Log("Child process exit handling failed (" + ex.GetType().FullName + ")");
			}
		}

		private static int? ExitCodeOf(Process process)
		{
			try
			{
				return process.ExitCode;
			}
			catch (Exception)
			{
				return null;
			}
		}

		private void OnProcessExitedCore(int myGeneration, int? exitCode)
		{
			bool stopRequested;
			lock (_gate)
			{
				stopRequested = _stopRequested;
			}
			Log($"Child process exited, generation={myGeneration}, wasStopRequested={stopRequested}, exitCode={((!exitCode.HasValue) ? "unknown" : exitCode.GetValueOrDefault().ToString(CultureInfo.InvariantCulture))}");
			if (!stopRequested)
			{
				CompletePendingAndAdvance(-1, myGeneration, ProbeOutcome.Failed("ElementGone"), acceptAnyPending: true, helperUnusable: true);
				HandleFatalChildConditionAsync(myGeneration, "ProcessExited");
			}
		}

		private async Task HandleFatalChildConditionAsync(int generationAtFailure, string reason)
		{
			Process process;
			JobObjectOwner job;
			CancellationTokenSource lifetimeCts;
			TaskCompletionSource<ProbeOutcome> inFlight;
			lock (_gate)
			{
				if (_disposed || _helperGeneration != generationAtFailure)
				{
					return;
				}
				process = _process;
				job = _job;
				lifetimeCts = _lifetimeCts;
				_process = null;
				_job = null;
				_lifetimeCts = null;
				_stdin = null;
				_stdout = null;
				_readyGeneration = -1;
				inFlight = _inFlight;
				_inFlight = null;
				_pendingRequestId = -1;
				_pendingWatchdogCts?.Cancel();
				_pendingWatchdogCts = null;
				_launchesInProgress++;
			}
			try
			{
				inFlight?.TrySetResult(ProbeOutcome.Failed("ObserverUnavailable"));
				lifetimeCts?.Cancel();
				job?.Dispose();
				process?.Dispose();
				bool flag;
				lock (_gate)
				{
					PruneOldRestartTimestampsLocked();
					_restartTimestampsUtcTicks.Add(_timeProvider.GetUtcNow().Ticks);
					flag = _restartTimestampsUtcTicks.Count <= _options.MaxAutomaticRestartsPerRollingWindow;
					if (!flag)
					{
						_cooldownUntilUtc = _timeProvider.GetUtcNow() + _options.RestartCooldown;
					}
				}
				_diagnosticSink?.Invoke($"Probe helper generation {generationAtFailure} ended ({reason}); restart={flag}");
				if (!flag)
				{
					FailQueuedAsUnavailable();
					return;
				}
				lock (_gate)
				{
					if (_disposed)
					{
						return;
					}
				}
				try
				{
					await LaunchAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (Exception ex)
				{
					_diagnosticSink?.Invoke("Probe helper restart failed: " + ex.Message);
					lock (_gate)
					{
						_cooldownUntilUtc = _timeProvider.GetUtcNow() + _options.RestartCooldown;
					}
					FailQueuedAsUnavailable();
					return;
				}
				Func<Task> testOnlyAfterRestartLaunchHookAsync = TestOnlyAfterRestartLaunchHookAsync;
				if (testOnlyAfterRestartLaunchHookAsync != null)
				{
					await testOnlyAfterRestartLaunchHookAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				bool disposed;
				lock (_gate)
				{
					disposed = _disposed;
				}
				if (disposed)
				{
					await TearDownCurrentChildAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					PromoteQueuedIfReady();
				}
			}
			finally
			{
				lock (_gate)
				{
					_launchesInProgress--;
				}
			}
		}

		private void Log(string message)
		{
			_diagnosticSink?.Invoke($"{_timeProvider.GetUtcNow():HH:mm:ss.fff} {message}");
		}

		private void FailQueuedAsUnavailable()
		{
			TaskCompletionSource<ProbeOutcome> taskCompletionSource;
			lock (_gate)
			{
				taskCompletionSource = _queuedNext?.Tcs;
				_queuedNext = null;
			}
			taskCompletionSource?.TrySetResult(ProbeOutcome.Unavailable("ObserverUnavailable"));
		}

		private void PruneOldRestartTimestampsLocked()
		{
			long cutoff = (_timeProvider.GetUtcNow() - _options.RestartRollingWindow).Ticks;
			_restartTimestampsUtcTicks.RemoveAll((long ticks) => ticks < cutoff);
		}

		private bool IsCooldownActiveLocked()
		{
			DateTimeOffset? cooldownUntilUtc = _cooldownUntilUtc;
			if (cooldownUntilUtc.HasValue)
			{
				DateTimeOffset valueOrDefault = cooldownUntilUtc.GetValueOrDefault();
				return valueOrDefault > _timeProvider.GetUtcNow();
			}
			return false;
		}

		private async Task DrainStandardErrorAsync(StreamReader stderr, CancellationToken cancellationToken)
		{
			StringBuilder buffer = new StringBuilder();
			try
			{
				char[] charBuffer = new char[256];
				while (!cancellationToken.IsCancellationRequested)
				{
					int num = await stderr.ReadAsync(charBuffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (num != 0)
					{
						buffer.Append(charBuffer, 0, num);
						if (buffer.Length > 4096)
						{
							buffer.Remove(0, buffer.Length - 4096);
						}
						continue;
					}
					break;
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (IOException)
			{
			}
			finally
			{
				if (buffer.Length > 0)
				{
					_diagnosticSink?.Invoke("Probe helper stderr (sanitized): " + HelperStderrSanitizer.SanitizeToSingleLine(buffer.ToString()));
				}
			}
		}

		public async ValueTask DisposeAsync()
		{
			Process process;
			JobObjectOwner job;
			CancellationTokenSource lifetimeCts;
			Stream stdin;
			int helperGeneration;
			lock (_gate)
			{
				if (_disposed)
				{
					return;
				}
				_disposed = true;
				_stopRequested = true;
				process = _process;
				job = _job;
				lifetimeCts = _lifetimeCts;
				stdin = _stdin;
				helperGeneration = _helperGeneration;
				_process = null;
				_job = null;
				_lifetimeCts = null;
				_stdin = null;
				_stdout = null;
				_readyGeneration = -1;
				_inFlight?.TrySetResult(ProbeOutcome.Unavailable("ObserverUnavailable"));
				_inFlight = null;
				_queuedNext?.Tcs.TrySetResult(ProbeOutcome.Unavailable("ObserverUnavailable"));
				_queuedNext = null;
			}
			Log($"Disposal starting, generation={helperGeneration}");
			await TearDownChildAsync(process, job, lifetimeCts, stdin, helperGeneration).ConfigureAwait(continueOnCapturedContext: false);
			Log("Disposal complete");
		}

		private async Task TearDownCurrentChildAsync()
		{
			Process process;
			JobObjectOwner job;
			CancellationTokenSource lifetimeCts;
			Stream stdin;
			int helperGeneration;
			lock (_gate)
			{
				process = _process;
				job = _job;
				lifetimeCts = _lifetimeCts;
				stdin = _stdin;
				helperGeneration = _helperGeneration;
				_process = null;
				_job = null;
				_lifetimeCts = null;
				_stdin = null;
				_stdout = null;
				_readyGeneration = -1;
			}
			await TearDownChildAsync(process, job, lifetimeCts, stdin, helperGeneration).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task TearDownChildAsync(Process? process, JobObjectOwner? job, CancellationTokenSource? lifetimeCts, Stream? stdin, int generation)
		{
			if (stdin != null && IsRunning(process))
			{
				try
				{
					Log($"Sending shutdown Stop frame, generation={generation}");
					using CancellationTokenSource stopCts = new CancellationTokenSource(_options.ShutdownGrace);
					ProbeFrame frame = ProbeFrameCodec.EncodePayload(generation, 0, ProbeMessageKind.Stop, new StopPayload(), _options);
					await ProbeFrameCodec.WriteFrameAsync(stdin, frame, _options, stopCts.Token).ConfigureAwait(continueOnCapturedContext: false);
					await Task.Delay(_options.ShutdownGrace, _timeProvider, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch
				{
				}
			}
			lifetimeCts?.Cancel();
			Log($"Closing job object, generation={generation}");
			job?.Dispose();
			if (process != null)
			{
				try
				{
					if (IsRunning(process))
					{
						process.Kill(entireProcessTree: true);
					}
				}
				catch
				{
				}
				try
				{
					process.Dispose();
				}
				catch
				{
				}
			}
			lifetimeCts?.Dispose();
		}

		private static bool IsRunning(Process? process)
		{
			if (process == null)
			{
				return false;
			}
			try
			{
				return !process.HasExited;
			}
			catch (InvalidOperationException)
			{
				return false;
			}
		}
	}
	public enum SessionAvailability
	{
		Available,
		Unavailable
	}
	public interface ISessionStateSource
	{
		SessionAvailability Current { get; }

		event EventHandler<SessionAvailability>? SessionStateChanged;

		SessionAvailability Refresh();
	}
	public static class SessionTransitions
	{
		public static SessionAvailability? Classify(int wtsEvent)
		{
			return wtsEvent switch
			{
				1 => (SessionAvailability?)SessionAvailability.Available, 
				2 => SessionAvailability.Unavailable, 
				3 => SessionAvailability.Available, 
				4 => SessionAvailability.Unavailable, 
				5 => SessionAvailability.Available, 
				6 => SessionAvailability.Unavailable, 
				7 => SessionAvailability.Unavailable, 
				8 => SessionAvailability.Available, 
				_ => null, 
			};
		}
	}
	public sealed class SessionStateMonitor : ISessionStateSource, IDisposable
	{
		private delegate nint WndProc(nint hwnd, uint message, nint wParam, nint lParam);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct WndClassEx
		{
			public uint cbSize;

			public uint style;

			public nint lpfnWndProc;

			public int cbClsExtra;

			public int cbWndExtra;

			public nint hInstance;

			public nint hIcon;

			public nint hCursor;

			public nint hbrBackground;

			public string? lpszMenuName;

			public string lpszClassName;

			public nint hIconSm;
		}

		private struct Msg
		{
			public nint hwnd;

			public uint message;

			public nint wParam;

			public nint lParam;

			public uint time;

			public int ptX;

			public int ptY;
		}

		private const int WmWtsSessionChange = 689;

		private const uint WmQuit = 18u;

		private static readonly nint HwndMessage = new IntPtr(-3);

		private const string WindowClassName = "SmartInput.SessionStateMonitor";

		private readonly Func<bool> _inputDesktopReachable;

		private readonly object _gate = new object();

		private readonly ManualResetEventSlim _ready = new ManualResetEventSlim(initialState: false);

		private static readonly WndProc StaticWindowProc = RouteWindowMessage;

		private static readonly ConcurrentDictionary<nint, SessionStateMonitor> Instances = new ConcurrentDictionary<nint, SessionStateMonitor>();

		private Thread? _thread;

		private nint _hwnd;

		private volatile uint _threadId;

		private bool _sessionUnavailable;

		private SessionAvailability _last;

		private bool _disposed;

		private readonly Channel<SessionAvailability> _notifications = Channel.CreateUnbounded<SessionAvailability>(new UnboundedChannelOptions
		{
			SingleReader = true
		});

		private int _dispatcherStarted;

		internal nint WindowHandle => _hwnd;

		public bool IsRegistered { get; private set; }

		public SessionAvailability Current
		{
			get
			{
				lock (_gate)
				{
					return _last;
				}
			}
		}

		public event EventHandler<SessionAvailability>? SessionStateChanged;

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern ushort RegisterClassExW(ref WndClassEx windowClass);

		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern nint CreateWindowExW(uint exStyle, string className, string? windowName, uint style, int x, int y, int width, int height, nint parent, nint menu, nint instance, nint param);

		[DllImport("user32.dll")]
		private static extern nint DefWindowProcW(nint hwnd, uint message, nint wParam, nint lParam);

		[DllImport("user32.dll")]
		private static extern bool DestroyWindow(nint hwnd);

		[DllImport("user32.dll")]
		private static extern int GetMessageW(out Msg message, nint hwnd, uint min, uint max);

		[DllImport("user32.dll")]
		private static extern bool TranslateMessage(ref Msg message);

		[DllImport("user32.dll")]
		private static extern nint DispatchMessageW(ref Msg message);

		[DllImport("user32.dll")]
		private static extern bool PostThreadMessageW(uint threadId, uint message, nint wParam, nint lParam);

		[DllImport("kernel32.dll")]
		private static extern uint GetCurrentThreadId();

		[DllImport("user32.dll")]
		private static extern nint OpenInputDesktop(uint flags, bool inherit, uint desiredAccess);

		[DllImport("user32.dll")]
		private static extern bool CloseDesktop(nint desktop);

		[DllImport("wtsapi32.dll", SetLastError = true)]
		private static extern bool WTSRegisterSessionNotification(nint hwnd, int flags);

		[DllImport("wtsapi32.dll")]
		private static extern bool WTSUnRegisterSessionNotification(nint hwnd);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		private static extern nint GetModuleHandleW(string? moduleName);

		private void EnsureDispatcher()
		{
			if (Interlocked.Exchange(ref _dispatcherStarted, 1) != 0)
			{
				return;
			}
			Task.Run(async () =>
			{
				await foreach (SessionAvailability item in _notifications.Reader.ReadAllAsync().ConfigureAwait(continueOnCapturedContext: false))
				{
					try
					{
						SessionStateChanged?.Invoke(null, item);
					}
					catch (Exception)
					{
					}
				}
			});
		}

		public SessionStateMonitor(Func<bool>? inputDesktopReachable = null)
		{
			_inputDesktopReachable = inputDesktopReachable ?? new Func<bool>(IsInputDesktopReachable);
		}

		public static bool IsInputDesktopReachable()
		{
			nint num = OpenInputDesktop(0u, inherit: false, 1u);
			if (num == IntPtr.Zero)
			{
				return false;
			}
			CloseDesktop(num);
			return true;
		}

		public void Start()
		{
			lock (_gate)
			{
				if (_thread != null || _disposed)
				{
					return;
				}
				_thread = new Thread(ThreadMain)
				{
					IsBackground = true,
					Name = "SmartInput.Environments.SessionStateMonitor"
				};
				_thread.Start();
			}
			_ready.Wait(TimeSpan.FromSeconds(5L));
		}

		private void ThreadMain()
		{
			_threadId = GetCurrentThreadId();
			WndClassEx windowClass = new WndClassEx
			{
				cbSize = (uint)Marshal.SizeOf<WndClassEx>(),
				lpfnWndProc = Marshal.GetFunctionPointerForDelegate(StaticWindowProc),
				hInstance = GetModuleHandleW(null),
				lpszClassName = "SmartInput.SessionStateMonitor"
			};
			RegisterClassExW(ref windowClass);
			_hwnd = CreateWindowExW(0u, "SmartInput.SessionStateMonitor", null, 0u, 0, 0, 0, 0, HwndMessage, IntPtr.Zero, windowClass.hInstance, IntPtr.Zero);
			if (_hwnd != IntPtr.Zero)
			{
				Instances[_hwnd] = this;
				IsRegistered = WTSRegisterSessionNotification(_hwnd, 0);
			}
			_ready.Set();
			Msg message;
			while (_hwnd != IntPtr.Zero && GetMessageW(out message, IntPtr.Zero, 0u, 0u) > 0)
			{
				TranslateMessage(ref message);
				DispatchMessageW(ref message);
			}
			if (_hwnd != IntPtr.Zero)
			{
				if (IsRegistered)
				{
					WTSUnRegisterSessionNotification(_hwnd);
				}
				Instances.TryRemove(_hwnd, out SessionStateMonitor _);
				DestroyWindow(_hwnd);
				_hwnd = IntPtr.Zero;
			}
		}

		private static nint RouteWindowMessage(nint hwnd, uint message, nint wParam, nint lParam)
		{
			if (!Instances.TryGetValue(hwnd, out SessionStateMonitor value))
			{
				return DefWindowProcW(hwnd, message, wParam, lParam);
			}
			return value.WindowProc(hwnd, message, wParam, lParam);
		}

		private nint WindowProc(nint hwnd, uint message, nint wParam, nint lParam)
		{
			if (message == 689)
			{
				SessionAvailability? sessionAvailability = SessionTransitions.Classify((int)((IntPtr)wParam).ToInt64());
				if (sessionAvailability.HasValue)
				{
					SessionAvailability valueOrDefault = sessionAvailability.GetValueOrDefault();
					lock (_gate)
					{
						_sessionUnavailable = valueOrDefault == SessionAvailability.Unavailable;
					}
					Evaluate();
				}
				return IntPtr.Zero;
			}
			return DefWindowProcW(hwnd, message, wParam, lParam);
		}

		public SessionAvailability Refresh()
		{
			return Evaluate();
		}

		private SessionAvailability Evaluate()
		{
			bool flag;
			try
			{
				flag = _inputDesktopReachable();
			}
			catch (Exception)
			{
				flag = false;
			}
			SessionAvailability sessionAvailability;
			bool flag2;
			lock (_gate)
			{
				sessionAvailability = ((_sessionUnavailable || !flag) ? SessionAvailability.Unavailable : SessionAvailability.Available);
				flag2 = sessionAvailability != _last;
				_last = sessionAvailability;
			}
			if (flag2)
			{
				_notifications.Writer.TryWrite(sessionAvailability);
				EnsureDispatcher();
			}
			return sessionAvailability;
		}

		public void Dispose()
		{
			Thread thread;
			lock (_gate)
			{
				if (_disposed)
				{
					return;
				}
				_disposed = true;
				_notifications.Writer.TryComplete();
				_notifications.Writer.TryComplete();
				thread = _thread;
				_ = _hwnd;
				_thread = null;
			}
			if (thread != null)
			{
				if (_threadId != 0)
				{
					PostThreadMessageW(_threadId, 18u, IntPtr.Zero, IntPtr.Zero);
				}
				thread.Join(TimeSpan.FromSeconds(2L));
			}
			_ready.Dispose();
		}
	}
}
namespace SmartInput.Windows.Environments.Interop
{
	public sealed class JobObjectOwner : IDisposable
	{
		private struct IoCounters
		{
			public ulong ReadOperationCount;

			public ulong WriteOperationCount;

			public ulong OtherOperationCount;

			public ulong ReadTransferCount;

			public ulong WriteTransferCount;

			public ulong OtherTransferCount;
		}

		private struct JobObjectBasicLimitInformation
		{
			public long PerProcessUserTimeLimit;

			public long PerJobUserTimeLimit;

			public uint LimitFlags;

			public nuint MinimumWorkingSetSize;

			public nuint MaximumWorkingSetSize;

			public uint ActiveProcessLimit;

			public nuint Affinity;

			public uint PriorityClass;

			public uint SchedulingClass;
		}

		private struct JobObjectExtendedLimitInformation
		{
			public JobObjectBasicLimitInformation BasicLimitInformation;

			public IoCounters IoInfo;

			public nuint ProcessMemoryLimit;

			public nuint JobMemoryLimit;

			public nuint PeakProcessMemoryUsed;

			public nuint PeakJobMemoryUsed;
		}

		private const uint JobObjectInfoClassExtendedLimitInformation = 9u;

		private const uint JobObjectLimitKillOnJobClose = 8192u;

		private readonly object _gate = new object();

		private nint _jobHandle;

		private bool _disposed;

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern nint CreateJobObjectW(nint lpJobAttributes, string? lpName);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool SetInformationJobObject(nint hJob, uint jobObjectInfoClass, ref JobObjectExtendedLimitInformation lpJobObjectInfo, uint cbJobObjectInfoLength);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool AssignProcessToJobObject(nint hJob, nint hProcess);

		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool CloseHandle(nint hObject);

		private JobObjectOwner(nint jobHandle)
		{
			_jobHandle = jobHandle;
		}

		public static JobObjectOwner Create()
		{
			nint num = CreateJobObjectW(IntPtr.Zero, null);
			if (num == IntPtr.Zero)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				throw new InvalidOperationException($"CreateJobObjectW failed with Win32 error {lastWin32Error}.");
			}
			JobObjectExtendedLimitInformation lpJobObjectInfo = new JobObjectExtendedLimitInformation
			{
				BasicLimitInformation = new JobObjectBasicLimitInformation
				{
					LimitFlags = 8192u
				}
			};
			if (!SetInformationJobObject(num, 9u, ref lpJobObjectInfo, (uint)Marshal.SizeOf<JobObjectExtendedLimitInformation>()))
			{
				int lastWin32Error2 = Marshal.GetLastWin32Error();
				CloseHandle(num);
				throw new InvalidOperationException($"SetInformationJobObject failed with Win32 error {lastWin32Error2}.");
			}
			return new JobObjectOwner(num);
		}

		public void Assign(nint processHandle)
		{
			lock (_gate)
			{
				ObjectDisposedException.ThrowIf(_disposed, this);
				if (!AssignProcessToJobObject(_jobHandle, processHandle))
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					throw new InvalidOperationException($"AssignProcessToJobObject failed with Win32 error {lastWin32Error}.");
				}
			}
		}

		public void Dispose()
		{
			lock (_gate)
			{
				if (!_disposed)
				{
					if (_jobHandle != IntPtr.Zero)
					{
						CloseHandle(_jobHandle);
						_jobHandle = IntPtr.Zero;
					}
					_disposed = true;
				}
			}
		}
	}
}
