using System;
using System.Buffers;
using System.Buffers.Binary;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Text.RegularExpressions.Generated;
using System.Threading;
using System.Threading.Tasks;
using SmartInput.Core.Detection;
using SmartInput.Core.Dictionaries;
using SmartInput.Core.Models;
using SmartInput.Core.Settings;
using SmartInput.Core.Text.Localization;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETCoreApp,Version=v10.0", FrameworkDisplayName = ".NET 10.0")]
[assembly: AssemblyCompany("SmartInput.Core")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+1067fa6d75b7fbb34a023a09c9716a95d6187838")]
[assembly: AssemblyProduct("SmartInput.Core")]
[assembly: AssemblyTitle("SmartInput.Core")]
[assembly: InternalsVisibleTo("SmartInput.Core.Tests")]
[assembly: AssemblyVersion("1.0.0.0")]
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
[CompilerGenerated]
internal sealed class <>z__ReadOnlyList<T> : IEnumerable, ICollection, IList, IEnumerable<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection<T>, IList<T>
{
	[CompilerGenerated]
	private readonly List<T> _items;

	int ICollection.Count => _items.Count;

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

	int IReadOnlyCollection<T>.Count => _items.Count;

	T IReadOnlyList<T>.this[int index] => _items[index];

	int ICollection<T>.Count => _items.Count;

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

	public <>z__ReadOnlyList(List<T> items)
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
		return _items.Contains(item);
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		_items.CopyTo(array, arrayIndex);
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	int IList<T>.IndexOf(T item)
	{
		return _items.IndexOf(item);
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
[CompilerGenerated]
internal sealed class <>z__ReadOnlySingleElementList<T> : IEnumerable, ICollection, IList, IEnumerable<T>, IReadOnlyCollection<T>, IReadOnlyList<T>, ICollection<T>, IList<T>
{
	private sealed class Enumerator : IDisposable, IEnumerator, IEnumerator<T>
	{
		[CompilerGenerated]
		private readonly T _item;

		[CompilerGenerated]
		private bool _moveNextCalled;

		object IEnumerator.Current => _item;

		T IEnumerator<T>.Current => _item;

		public Enumerator(T item)
		{
			_item = item;
		}

		bool IEnumerator.MoveNext()
		{
			if (!_moveNextCalled)
			{
				return _moveNextCalled = true;
			}
			return false;
		}

		void IEnumerator.Reset()
		{
			_moveNextCalled = false;
		}

		void IDisposable.Dispose()
		{
		}
	}

	[CompilerGenerated]
	private readonly T _item;

	int ICollection.Count => 1;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	object? IList.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return _item;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	bool IList.IsFixedSize => true;

	bool IList.IsReadOnly => true;

	int IReadOnlyCollection<T>.Count => 1;

	T IReadOnlyList<T>.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return _item;
		}
	}

	int ICollection<T>.Count => 1;

	bool ICollection<T>.IsReadOnly => true;

	T IList<T>.this[int index]
	{
		get
		{
			if (index != 0)
			{
				throw new IndexOutOfRangeException();
			}
			return _item;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public <>z__ReadOnlySingleElementList(T item)
	{
		_item = item;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(_item);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		array.SetValue(_item, index);
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
		return EqualityComparer<T>.Default.Equals(_item, (T)value);
	}

	int IList.IndexOf(object? value)
	{
		if (!EqualityComparer<T>.Default.Equals(_item, (T)value))
		{
			return -1;
		}
		return 0;
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
		return new Enumerator(_item);
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
		return EqualityComparer<T>.Default.Equals(_item, item);
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		array[arrayIndex] = _item;
	}

	bool ICollection<T>.Remove(T item)
	{
		throw new NotSupportedException();
	}

	int IList<T>.IndexOf(T item)
	{
		if (!EqualityComparer<T>.Default.Equals(_item, item))
		{
			return -1;
		}
		return 0;
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
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Shape_0 : Regex
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
					if ((uint)num < (uint)inputSpan.Length && num == 0)
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
					int pos = 0;
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					if (readOnlySpan.IsEmpty || !char.IsBetween(readOnlySpan[0], '1', '9'))
					{
						return false;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num2 = num;
					int i;
					for (i = 0; i < 5 && (uint)i < (uint)readOnlySpan.Length && char.IsAsciiDigit(readOnlySpan[i]); i++)
					{
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					num3 = num;
					while (true)
					{
						num4 = 0;
						while (true)
						{
							<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
							num4++;
							if (!readOnlySpan.IsEmpty)
							{
								switch (readOnlySpan[0])
								{
								case '.':
								{
									num++;
									readOnlySpan = inputSpan.Slice(num);
									int j;
									for (j = 0; j < 6 && (uint)j < (uint)readOnlySpan.Length && char.IsAsciiDigit(readOnlySpan[j]); j++)
									{
									}
									if (j == 0)
									{
										break;
									}
									readOnlySpan = readOnlySpan.Slice(j);
									num += j;
									goto IL_0189;
								}
								case ',':
									if ((uint)readOnlySpan.Length < 4u || !char.IsAsciiDigit(readOnlySpan[1]) || !char.IsAsciiDigit(readOnlySpan[2]) || !char.IsAsciiDigit(readOnlySpan[3]))
									{
										break;
									}
									num += 4;
									readOnlySpan = inputSpan.Slice(num);
									goto IL_0189;
								}
							}
							goto IL_0192;
							IL_01b8:
							if (!readOnlySpan.IsEmpty && (readOnlySpan[0] | 2) == 46)
							{
								readOnlySpan = readOnlySpan.Slice(1);
								num++;
							}
							if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
							{
								runtextpos = num;
								Capture(0, start, num);
								return true;
							}
							goto IL_0192;
							IL_0189:
							if (num4 == 0)
							{
								continue;
							}
							goto IL_01b8;
							IL_0192:
							if (--num4 < 0)
							{
								break;
							}
							num = runstack[--pos];
							readOnlySpan = inputSpan.Slice(num);
							goto IL_01b8;
						}
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 >= num3)
						{
							break;
						}
						num = --num3;
						readOnlySpan = inputSpan.Slice(num);
					}
					return false;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Shape_0 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Shape_0();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Shape_0()
		{
			pattern = "^[1-9][0-9]{0,5}(?:\\.[0-9]{1,6}|,[0-9]{3})?[.,]?$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WwwAddress_1 : Regex
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
					if (num <= inputSpan.Length - 5 && num == 0)
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
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					if ((uint)span.Length < 4u || !span.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					num += 4;
					span = inputSpan.Slice(num);
					int i;
					for (i = 0; (uint)i < (uint)span.Length && !char.IsWhiteSpace(span[i]); i++)
					{
					}
					if (i == 0)
					{
						return false;
					}
					span = span.Slice(i);
					num += i;
					if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
					{
						return false;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WwwAddress_1 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WwwAddress_1();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WwwAddress_1()
		{
			pattern = "^www\\.[^\\s]+$";
			roptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WellKnownDomain_2 : Regex
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
					if (num <= inputSpan.Length - 4 && num == 0)
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
					int arg = 0;
					int arg2 = 0;
					int num4 = 0;
					int num5 = 0;
					int pos = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					num4 = 0;
					while (true)
					{
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
						num4++;
						char c;
						if (!span.IsEmpty && !(((c = span[0]) < '\u0080') ? (!char.IsAsciiLetterOrDigit(c)) : (!RegexRunner.CharInClass(c, "\0\b\00:A[a{KÅ"))))
						{
							num++;
							span = inputSpan.Slice(num);
							num5 = 0;
							goto IL_0090;
						}
						goto IL_0265;
						IL_020c:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num5);
						if (!span.IsEmpty && span[0] == '.')
						{
							num++;
							span = inputSpan.Slice(num);
							continue;
						}
						goto IL_021d;
						IL_0653:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 2u || !span.StartsWith("me", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_0694;
						}
						num2 = 12;
						num += 2;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0090:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
						num5++;
						arg = num;
						int i;
						for (i = 0; i < 61 && (uint)i < (uint)span.Length; i++)
						{
							if (!(((c = span[i]) < '\u0080') ? (("\0\0\u2000Ͽ\ufffe߿\ufffe߿"[(int)c >> 4] & (1 << (c & 0xF))) != 0) : RegexRunner.CharInClass(c, "\0\n\0-.0:A[a{KÅ")))
							{
								break;
							}
						}
						span = span.Slice(i);
						num += i;
						arg2 = num;
						goto IL_016d;
						IL_0401:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 3u || !span.StartsWith("edu", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_0441;
						}
						num2 = 5;
						num += 3;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0441:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 3u || !span.StartsWith("gov", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_0481;
						}
						num2 = 6;
						num += 3;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0265:
						if (--num4 < 0)
						{
							return false;
						}
						num = runstack[--pos];
						span = inputSpan.Slice(num);
						if (num4 == 0)
						{
							return false;
						}
						num3 = num;
						if ((uint)span.Length < 3u || !span.StartsWith("com", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_02dc;
						}
						num2 = 0;
						num += 3;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_055c:
						num += 2;
						span = inputSpan.Slice(num);
						goto IL_056a;
						IL_056a:
						num2 = 8;
						goto IL_0723;
						IL_0481:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 4u || !span.StartsWith("info", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_04c1;
						}
						num2 = 7;
						num += 4;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0571:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 2u || !span.StartsWith("co", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_05b2;
						}
						num2 = 9;
						num += 2;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_021d:
						num5 = runstack[--pos];
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num5 != 0)
						{
							goto IL_0114;
						}
						goto IL_0265;
						IL_04c1:
						num = num3;
						span = inputSpan.Slice(num);
						if (!span.IsEmpty && (span[0] | 0x20) == 97 && (uint)span.Length >= 2u)
						{
							char c2 = span[1];
							if ((uint)c2 <= 80u)
							{
								if (c2 == 'I')
								{
									goto IL_055c;
								}
								if (c2 == 'P')
								{
									goto IL_0522;
								}
							}
							else
							{
								if (c2 == 'i')
								{
									goto IL_055c;
								}
								if (c2 == 'p')
								{
									goto IL_0522;
								}
							}
						}
						goto IL_0571;
						IL_02dc:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 3u || !span.StartsWith("org", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_031c;
						}
						num2 = 1;
						num += 3;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0694:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 2u || !span.StartsWith("tv", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_0290;
						}
						num2 = 13;
						num += 2;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_05b2:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 2u || (span[0] | 0x20) != 117 || ((((c = span[1]) | 0x20) != 107) & (c != 'K')))
						{
							goto IL_0612;
						}
						num2 = 10;
						num += 2;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_031c:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 3u || !span.StartsWith("net", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_035c;
						}
						num2 = 2;
						num += 3;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_016d:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, arg, arg2);
						if (span.IsEmpty || (((c = span[0]) < '\u0080') ? (!char.IsAsciiLetterOrDigit(c)) : (!RegexRunner.CharInClass(c, "\0\b\00:A[a{KÅ"))))
						{
							goto IL_0114;
						}
						num++;
						span = inputSpan.Slice(num);
						if (num5 == 0)
						{
							goto IL_0090;
						}
						goto IL_020c;
						IL_0114:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPop(runstack, ref pos, out arg2, out arg);
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (arg < arg2 && (arg2 = inputSpan.Slice(arg, arg2 - arg).LastIndexOfAny(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndDigitsAndKelvinSign)) >= 0)
						{
							arg2 += arg;
							num = arg2;
							span = inputSpan.Slice(num);
							goto IL_016d;
						}
						if (--num5 >= 0)
						{
							num = runstack[--pos];
							span = inputSpan.Slice(num);
							goto IL_020c;
						}
						goto IL_0265;
						IL_035c:
						num = num3;
						span = inputSpan.Slice(num);
						ulong num6;
						if ((uint)span.Length < 2u || (span[0] | 0x20) != 105 || (long)((ulong)(-8070450529832009728L << (int)(num6 = (uint)(span[1] - 79))) & (num6 - 64)) >= 0L)
						{
							goto IL_03c1;
						}
						num2 = 3;
						num += 2;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0612:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 2u || !span.StartsWith("de", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_0653;
						}
						num2 = 11;
						num += 2;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0723:
						while (true)
						{
							if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
							{
								if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								switch (num2)
								{
								case 13:
									break;
								case 0:
									goto IL_02dc;
								case 1:
									goto IL_031c;
								case 2:
									goto IL_035c;
								case 3:
									goto IL_03c1;
								case 4:
									goto IL_0401;
								case 5:
									goto IL_0441;
								case 6:
									goto IL_0481;
								case 7:
									goto IL_04c1;
								case 8:
									goto IL_0571;
								case 9:
									goto IL_05b2;
								case 10:
									goto IL_0612;
								case 11:
									goto IL_0653;
								case 12:
									goto IL_0694;
								default:
									continue;
								}
								break;
							}
							runtextpos = num;
							Capture(0, start, num);
							return true;
						}
						goto IL_0290;
						IL_0290:
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num4 == 0)
						{
							break;
						}
						goto IL_021d;
						IL_03c1:
						num = num3;
						span = inputSpan.Slice(num);
						if ((uint)span.Length < 3u || !span.StartsWith("dev", StringComparison.OrdinalIgnoreCase))
						{
							goto IL_0401;
						}
						num2 = 4;
						num += 3;
						span = inputSpan.Slice(num);
						goto IL_0723;
						IL_0522:
						if ((uint)span.Length >= 3u && (span[1] | 0x20) == 112 && (span[2] | 0x20) == 112)
						{
							num += 3;
							span = inputSpan.Slice(num);
							goto IL_056a;
						}
						goto IL_0571;
					}
					return false;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WellKnownDomain_2 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WellKnownDomain_2();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WellKnownDomain_2()
		{
			pattern = "^(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\\.)+(?:com|org|net|ir|io|dev|edu|gov|info|app|ai|co|uk|de|me|tv)$";
			roptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__SnakeCaseIdentifier_3 : Regex
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
					if (num <= inputSpan.Length - 3 && num == 0)
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
					int pos = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					int num3 = span.IndexOfAnyExcept('_');
					if (num3 < 0)
					{
						num3 = span.Length;
					}
					span = span.Slice(num3);
					num += num3;
					if (span.IsEmpty || !char.IsAsciiLetter(span[0]))
					{
						return false;
					}
					int num4 = span.Slice(1).IndexOfAnyExcept(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndDigits);
					if (num4 < 0)
					{
						num4 = span.Length - 1;
					}
					span = span.Slice(num4);
					num += num4;
					num++;
					span = inputSpan.Slice(num);
					num2 = 0;
					while (true)
					{
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
						num2++;
						int num5 = span.IndexOfAnyExcept('_');
						if (num5 < 0)
						{
							num5 = span.Length;
						}
						if (num5 == 0)
						{
							break;
						}
						span = span.Slice(num5);
						num += num5;
						int num6 = span.IndexOfAnyExcept(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndDigits);
						if (num6 < 0)
						{
							num6 = span.Length;
						}
						if (num6 == 0)
						{
							break;
						}
						span = span.Slice(num6);
						num += num6;
					}
					do
					{
						if (--num2 < 0)
						{
							return false;
						}
						num = runstack[--pos];
						span = inputSpan.Slice(num);
						if (num2 == 0)
						{
							return false;
						}
						int num7 = span.IndexOfAnyExcept('_');
						if (num7 < 0)
						{
							num7 = span.Length;
						}
						span = span.Slice(num7);
						num += num7;
					}
					while (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'));
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__SnakeCaseIdentifier_3 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__SnakeCaseIdentifier_3();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__SnakeCaseIdentifier_3()
		{
			pattern = "^_*[A-Za-z][A-Za-z0-9]*(?:_+[A-Za-z0-9]+)+_*$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CallExpression_4 : Regex
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
					if (num <= inputSpan.Length - 3 && num == 0)
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
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					ulong num2;
					if (readOnlySpan.IsEmpty || (long)((ulong)(-261993005120L << (int)(num2 = (uint)(readOnlySpan[0] - 65))) & (num2 - 64)) >= 0L)
					{
						return false;
					}
					int num3 = readOnlySpan.Slice(1).IndexOfAnyExcept(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndDigitsAndDotUnderscore);
					if (num3 < 0)
					{
						num3 = readOnlySpan.Length - 1;
					}
					readOnlySpan = readOnlySpan.Slice(num3);
					num += num3;
					if (!readOnlySpan.Slice(1).StartsWith("()"))
					{
						return false;
					}
					if (4 < readOnlySpan.Length || (3 < readOnlySpan.Length && readOnlySpan[3] != '\n'))
					{
						return false;
					}
					Capture(0, start, runtextpos = num + 3);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CallExpression_4 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CallExpression_4();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CallExpression_4()
		{
			pattern = "^[A-Za-z_][A-Za-z0-9_.]*\\(\\)$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__LettersJoinedToDigits_5 : Regex
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
					if ((uint)num < (uint)inputSpan.Length && num == 0)
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
					int num6 = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					int num7 = num;
					if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					int num8 = num6;
					num2 = num;
					int num9 = span.IndexOf('\n');
					if (num9 < 0)
					{
						num9 = span.Length;
					}
					span = span.Slice(num9);
					num += num9;
					num3 = num;
					while (span.IsEmpty || !char.IsAsciiLetter(span[0]))
					{
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 >= num3 || (num3 = inputSpan.Slice(num2, num3 - num2).LastIndexOfAny(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLetters)) < 0)
						{
							return false;
						}
						num3 += num2;
						num = num3;
						span = inputSpan.Slice(num);
					}
					num6 = num8;
					num = num7;
					span = inputSpan.Slice(num);
					int num10 = num;
					if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					int num11 = num6;
					num4 = num;
					int num12 = span.IndexOf('\n');
					if (num12 < 0)
					{
						num12 = span.Length;
					}
					span = span.Slice(num12);
					num += num12;
					num5 = num;
					while (span.IsEmpty || !char.IsAsciiDigit(span[0]))
					{
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num4 >= num5 || (num5 = inputSpan.Slice(num4, num5 - num4).LastIndexOfAnyInRange('0', '9')) < 0)
						{
							return false;
						}
						num5 += num4;
						num = num5;
						span = inputSpan.Slice(num);
					}
					num6 = num11;
					num = num10;
					span = inputSpan.Slice(num);
					int num13 = span.IndexOfAnyExcept(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndDigitsAndDashDot);
					if (num13 < 0)
					{
						num13 = span.Length;
					}
					if (num13 == 0)
					{
						return false;
					}
					span = span.Slice(num13);
					num += num13;
					if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
					{
						return false;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__LettersJoinedToDigits_5 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__LettersJoinedToDigits_5();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__LettersJoinedToDigits_5()
		{
			pattern = "^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9.\\-]+$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Url_6 : Regex
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
					if (num <= inputSpan.Length - 8 && num == 0)
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
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						UncaptureUntil(0);
						return false;
					}
					num2 = num;
					if (span.IsEmpty)
					{
						UncaptureUntil(0);
						return false;
					}
					switch (span[0])
					{
					case 'H':
					case 'h':
						if ((uint)span.Length < 4u || !span.Slice(1).StartsWith("ttp", StringComparison.OrdinalIgnoreCase))
						{
							UncaptureUntil(0);
							return false;
						}
						if ((uint)span.Length > 4u && (span[4] | 0x20) == 115)
						{
							span = span.Slice(1);
							num++;
						}
						num += 4;
						span = inputSpan.Slice(num);
						break;
					case 'F':
					case 'f':
						if ((uint)span.Length < 3u || !span.Slice(1).StartsWith("tp", StringComparison.OrdinalIgnoreCase))
						{
							UncaptureUntil(0);
							return false;
						}
						num += 3;
						span = inputSpan.Slice(num);
						break;
					default:
						UncaptureUntil(0);
						return false;
					}
					Capture(1, num2, num);
					char c;
					if ((uint)span.Length < 5u || !span.StartsWith("://", StringComparison.OrdinalIgnoreCase) || (((c = span[3]) < '\u0080') ? (("쇿\uffff㿦翿\uffff\uffff\uffff\uffff"[(int)c >> 4] & (1 << (c & 0xF))) == 0) : (!RegexRunner.CharInClass(c, "\u0001\u0006\u0001#%.0?@d"))) || span[4] == '\n')
					{
						UncaptureUntil(0);
						return false;
					}
					int i;
					for (i = 5; (uint)i < (uint)span.Length && !char.IsWhiteSpace(span[i]); i++)
					{
					}
					span = span.Slice(i);
					num += i;
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

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Url_6 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Url_6();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Url_6()
		{
			pattern = "^(https?|ftp)://[^\\s/$.?#].[^\\s]*$";
			roptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 2;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Email_7 : Regex
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
					if (num <= inputSpan.Length - 5 && num == 0)
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
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					int i;
					for (i = 0; (uint)i < (uint)readOnlySpan.Length; i++)
					{
						char c;
						if (!(((c = readOnlySpan[i]) < '\u0080') ? (("쇿\uffff\ufffe\uffff\ufffe\uffff\uffff\uffff"[(int)c >> 4] & (1 << (c & 0xF))) != 0) : RegexRunner.CharInClass(c, "\u0001\u0002\u0001@Ad")))
						{
							break;
						}
					}
					if (i == 0)
					{
						return false;
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					if (readOnlySpan.IsEmpty || readOnlySpan[0] != '@')
					{
						return false;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					num2 = num;
					int j;
					for (j = 0; (uint)j < (uint)readOnlySpan.Length; j++)
					{
						char c;
						if (!(((c = readOnlySpan[j]) < '\u0080') ? (("쇿\uffff\ufffe\uffff\ufffe\uffff\uffff\uffff"[(int)c >> 4] & (1 << (c & 0xF))) != 0) : RegexRunner.CharInClass(c, "\u0001\u0002\u0001@Ad")))
						{
							break;
						}
					}
					if (j == 0)
					{
						return false;
					}
					readOnlySpan = readOnlySpan.Slice(j);
					num += j;
					num3 = num;
					num2++;
					while (true)
					{
						if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '.')
						{
							num++;
							readOnlySpan = inputSpan.Slice(num);
							int k;
							for (k = 0; (uint)k < (uint)readOnlySpan.Length; k++)
							{
								char c;
								if (!(((c = readOnlySpan[k]) < '\u0080') ? (("쇿\uffff\ufffe\uffff\ufffe\uffff\uffff\uffff"[(int)c >> 4] & (1 << (c & 0xF))) != 0) : RegexRunner.CharInClass(c, "\u0001\u0002\u0001@Ad")))
								{
									break;
								}
							}
							if (k != 0)
							{
								readOnlySpan = readOnlySpan.Slice(k);
								num += k;
								if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
								{
									break;
								}
							}
						}
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 >= num3 || (num3 = inputSpan.Slice(num2, num3 - num2).LastIndexOf('.')) < 0)
						{
							return false;
						}
						num3 += num2;
						num = num3;
						readOnlySpan = inputSpan.Slice(num);
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Email_7 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Email_7();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Email_7()
		{
			pattern = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
			roptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Ipv4WithOptionalPort_8 : Regex
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
					if (num <= inputSpan.Length - 7 && num == 0)
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
					int arg = 0;
					int arg2 = 0;
					int arg3 = 0;
					int arg4 = 0;
					int num6 = 0;
					int num7 = 0;
					int pos = 0;
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					num3 = num;
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '2' && (uint)readOnlySpan.Length >= 2u)
					{
						switch (readOnlySpan[1])
						{
						case '5':
							if ((uint)readOnlySpan.Length < 3u || !char.IsBetween(readOnlySpan[2], '0', '5'))
							{
								break;
							}
							num += 3;
							readOnlySpan = inputSpan.Slice(num);
							goto IL_00e7;
						case '0':
						case '1':
						case '2':
						case '3':
						case '4':
							{
								if ((uint)readOnlySpan.Length < 3u || !char.IsDigit(readOnlySpan[2]))
								{
									break;
								}
								num += 3;
								readOnlySpan = inputSpan.Slice(num);
								goto IL_00e7;
							}
							IL_00e7:
							num2 = 0;
							goto IL_01ab;
						}
					}
					goto IL_00ee;
					IL_0126:
					if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
					{
						CheckTimeout();
					}
					if (num4 >= num5)
					{
						return false;
					}
					num = --num5;
					readOnlySpan = inputSpan.Slice(num);
					goto IL_014d;
					IL_014d:
					int i;
					for (i = 0; i < 2 && (uint)i < (uint)readOnlySpan.Length && char.IsDigit(readOnlySpan[i]); i++)
					{
					}
					if (i == 0)
					{
						goto IL_0126;
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					num2 = 1;
					goto IL_01ab;
					IL_01ab:
					while (true)
					{
						num6 = 0;
						while (true)
						{
							<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
							num6++;
							int num8;
							if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '.')
							{
								num8 = num;
								if ((uint)readOnlySpan.Length >= 2u && readOnlySpan[1] == '2' && (uint)readOnlySpan.Length >= 3u)
								{
									switch (readOnlySpan[2])
									{
									case '5':
										if ((uint)readOnlySpan.Length < 4u || !char.IsBetween(readOnlySpan[3], '0', '5'))
										{
											break;
										}
										num += 4;
										readOnlySpan = inputSpan.Slice(num);
										goto IL_0290;
									case '0':
									case '1':
									case '2':
									case '3':
									case '4':
										{
											if ((uint)readOnlySpan.Length < 4u || !char.IsDigit(readOnlySpan[3]))
											{
												break;
											}
											num += 4;
											readOnlySpan = inputSpan.Slice(num);
											goto IL_0290;
										}
										IL_0290:
										<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, 0, num8);
										goto IL_041c;
									}
								}
								goto IL_02a5;
							}
							goto IL_0426;
							IL_0473:
							num7 = 0;
							while (true)
							{
								<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
								num7++;
								if (!readOnlySpan.IsEmpty && readOnlySpan[0] == ':')
								{
									num++;
									readOnlySpan = inputSpan.Slice(num);
									int j;
									for (j = 0; j < 5 && (uint)j < (uint)readOnlySpan.Length && char.IsDigit(readOnlySpan[j]); j++)
									{
									}
									if (j != 0)
									{
										readOnlySpan = readOnlySpan.Slice(j);
										num += j;
										if (num7 == 0)
										{
											continue;
										}
										goto IL_051a;
									}
								}
								goto IL_04f4;
								IL_051a:
								if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
								{
									runtextpos = num;
									Capture(0, start, num);
									return true;
								}
								goto IL_04f4;
								IL_04f4:
								if (--num7 < 0)
								{
									break;
								}
								num = runstack[--pos];
								readOnlySpan = inputSpan.Slice(num);
								goto IL_051a;
							}
							if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							if (num6 == 0)
							{
								break;
							}
							goto IL_03e0;
							IL_02ec:
							<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPop(runstack, ref pos, out arg2, out arg);
							if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							if (arg < arg2)
							{
								num = --arg2;
								readOnlySpan = inputSpan.Slice(num);
								goto IL_0325;
							}
							goto IL_0426;
							IL_02a5:
							num = num8;
							readOnlySpan = inputSpan.Slice(num);
							num++;
							readOnlySpan = inputSpan.Slice(num);
							arg = num;
							if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '1')
							{
								readOnlySpan = readOnlySpan.Slice(1);
								num++;
							}
							arg2 = num;
							goto IL_0325;
							IL_03bd:
							<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, arg3, arg4);
							<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, 1, num8);
							goto IL_041c;
							IL_041c:
							if (num6 < 3)
							{
								continue;
							}
							goto IL_0473;
							IL_0426:
							if (--num6 < 0)
							{
								break;
							}
							num = runstack[--pos];
							readOnlySpan = inputSpan.Slice(num);
							if (num6 == 0)
							{
								break;
							}
							if (num6 < 3)
							{
								goto IL_03e0;
							}
							goto IL_0473;
							IL_03e0:
							if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
							{
								CheckTimeout();
							}
							num8 = runstack[--pos];
							int num9 = runstack[--pos];
							if (num9 == 0)
							{
								goto IL_02a5;
							}
							if (num9 == 1)
							{
								<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPop(runstack, ref pos, out arg4, out arg3);
								if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								if (arg3 >= arg4)
								{
									goto IL_02ec;
								}
								num = --arg4;
								readOnlySpan = inputSpan.Slice(num);
								goto IL_03bd;
							}
							goto IL_041c;
							IL_0325:
							<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, arg, arg2);
							arg3 = num;
							int k;
							for (k = 0; k < 2 && (uint)k < (uint)readOnlySpan.Length && char.IsDigit(readOnlySpan[k]); k++)
							{
							}
							if (k == 0)
							{
								goto IL_02ec;
							}
							readOnlySpan = readOnlySpan.Slice(k);
							num += k;
							arg4 = num;
							arg3++;
							goto IL_03bd;
						}
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 == 0)
						{
							break;
						}
						if (num2 != 1)
						{
							continue;
						}
						goto IL_0126;
					}
					goto IL_00ee;
					IL_00ee:
					num = num3;
					readOnlySpan = inputSpan.Slice(num);
					num4 = num;
					if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '1')
					{
						readOnlySpan = readOnlySpan.Slice(1);
						num++;
					}
					num5 = num;
					goto IL_014d;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Ipv4WithOptionalPort_8 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Ipv4WithOptionalPort_8();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Ipv4WithOptionalPort_8()
		{
			pattern = "^(?:25[0-5]|2[0-4]\\d|1?\\d?\\d)(?:\\.(?:25[0-5]|2[0-4]\\d|1?\\d?\\d)){3}(?::\\d{1,5})?$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Domain_9 : Regex
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
					if (num <= inputSpan.Length - 4 && num == 0)
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
					int arg = 0;
					int arg2 = 0;
					int num2 = 0;
					int num3 = 0;
					int pos = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					num2 = 0;
					while (true)
					{
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
						num2++;
						char c;
						if (!span.IsEmpty && !(((c = span[0]) < '\u0080') ? (!char.IsAsciiLetterOrDigit(c)) : (!RegexRunner.CharInClass(c, "\0\b\00:A[a{KÅ"))))
						{
							num++;
							span = inputSpan.Slice(num);
							num3 = 0;
							goto IL_008a;
						}
						goto IL_0259;
						IL_010d:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPop(runstack, ref pos, out arg2, out arg);
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (arg < arg2 && (arg2 = inputSpan.Slice(arg, arg2 - arg).LastIndexOfAny(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndDigitsAndKelvinSign)) >= 0)
						{
							arg2 += arg;
							num = arg2;
							span = inputSpan.Slice(num);
							goto IL_0162;
						}
						if (--num3 >= 0)
						{
							num = runstack[--pos];
							span = inputSpan.Slice(num);
							goto IL_0200;
						}
						goto IL_0259;
						IL_0211:
						num3 = runstack[--pos];
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num3 != 0)
						{
							goto IL_010d;
						}
						goto IL_0259;
						IL_0162:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, arg, arg2);
						if (span.IsEmpty || (((c = span[0]) < '\u0080') ? (!char.IsAsciiLetterOrDigit(c)) : (!RegexRunner.CharInClass(c, "\0\b\00:A[a{KÅ"))))
						{
							goto IL_010d;
						}
						num++;
						span = inputSpan.Slice(num);
						if (num3 == 0)
						{
							goto IL_008a;
						}
						goto IL_0200;
						IL_0200:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num3);
						if (!span.IsEmpty && span[0] == '.')
						{
							num++;
							span = inputSpan.Slice(num);
							continue;
						}
						goto IL_0211;
						IL_008a:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
						num3++;
						arg = num;
						int i;
						for (i = 0; i < 61 && (uint)i < (uint)span.Length; i++)
						{
							if (!(((c = span[i]) < '\u0080') ? (("\0\0\u2000Ͽ\ufffe߿\ufffe߿"[(int)c >> 4] & (1 << (c & 0xF))) != 0) : RegexRunner.CharInClass(c, "\0\n\0-.0:A[a{KÅ")))
							{
								break;
							}
						}
						span = span.Slice(i);
						num += i;
						arg2 = num;
						goto IL_0162;
						IL_0259:
						if (--num2 < 0)
						{
							return false;
						}
						num = runstack[--pos];
						span = inputSpan.Slice(num);
						if (num2 == 0)
						{
							return false;
						}
						int num4 = span.IndexOfAnyExcept(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndKelvinSign);
						if (num4 < 0)
						{
							num4 = span.Length;
						}
						if (num4 >= 2)
						{
							span = span.Slice(num4);
							num += num4;
							if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
							{
								break;
							}
						}
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 == 0)
						{
							return false;
						}
						goto IL_0211;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Domain_9 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Domain_9();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Domain_9()
		{
			pattern = "^(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\\.)+[a-z]{2,}$";
			roptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WindowsPath_10 : Regex
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
					if (num <= inputSpan.Length - 3 && num == 0)
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
					int arg = 0;
					int arg2 = 0;
					int arg3 = 0;
					int num3 = 0;
					int pos = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					if ((uint)span.Length < 3u || !char.IsAsciiLetter(span[0]) || !span.Slice(1).StartsWith(":\\", StringComparison.OrdinalIgnoreCase))
					{
						return false;
					}
					num += 3;
					span = inputSpan.Slice(num);
					num3 = 0;
					while (true)
					{
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
						num3++;
						num2 = num;
						int num4 = span.IndexOfAny(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_ascii_240000040400D40000000000000010);
						if (num4 < 0)
						{
							num4 = span.Length;
						}
						if (num4 != 0)
						{
							span = span.Slice(num4);
							num += num4;
							arg = num;
							num2++;
							goto IL_00f5;
						}
						while (true)
						{
							if (--num3 < 0)
							{
								return false;
							}
							num = runstack[--pos];
							span = inputSpan.Slice(num);
							if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
							{
								if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
								{
									CheckTimeout();
								}
								if (num3 != 0)
								{
									<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPop(runstack, ref pos, out arg3, out arg2);
									if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (arg2 < arg3)
									{
										break;
									}
									<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPop(runstack, ref pos, out arg, out num2);
									if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (num2 >= arg)
									{
										continue;
									}
									goto IL_00e5;
								}
								return false;
							}
							runtextpos = num;
							Capture(0, start, num);
							return true;
						}
						num = --arg3;
						span = inputSpan.Slice(num);
						goto IL_0169;
						IL_0169:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, arg2, arg3);
						continue;
						IL_00f5:
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num2, arg);
						arg2 = num;
						if (!span.IsEmpty && span[0] == '\\')
						{
							span = span.Slice(1);
							num++;
						}
						arg3 = num;
						goto IL_0169;
						IL_00e5:
						num = --arg;
						span = inputSpan.Slice(num);
						goto IL_00f5;
					}
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WindowsPath_10 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WindowsPath_10();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WindowsPath_10()
		{
			pattern = "^[a-zA-Z]:\\\\(?:[^<>:\"|?*\\r\\n]+\\\\?)*$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__UnixPath_11 : Regex
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
					if (num <= inputSpan.Length - 2 && num == 0)
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
					int num6 = 0;
					int pos = 0;
					ReadOnlySpan<char> span = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					num2 = num;
					char c;
					if (!span.IsEmpty && (((c = span[0]) == '/') | (c == '~')))
					{
						span = span.Slice(1);
						num++;
					}
					num3 = num;
					while (true)
					{
						num6 = 0;
						while (true)
						{
							<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
							num6++;
							int num7 = span.IndexOfAny('\0', '/');
							if (num7 < 0)
							{
								num7 = span.Length;
							}
							if (num7 == 0)
							{
								break;
							}
							span = span.Slice(num7);
							num += num7;
							if (span.IsEmpty || span[0] != '/')
							{
								break;
							}
							num++;
							span = inputSpan.Slice(num);
						}
						while (--num6 >= 0)
						{
							num = runstack[--pos];
							span = inputSpan.Slice(num);
							if (num6 == 0)
							{
								break;
							}
							num4 = num;
							int num8 = span.IndexOfAny('\0', '/');
							if (num8 < 0)
							{
								num8 = span.Length;
							}
							span = span.Slice(num8);
							num += num8;
							num5 = num;
							while (true)
							{
								if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
								{
									if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
									{
										CheckTimeout();
									}
									if (num4 >= num5)
									{
										break;
									}
									num = --num5;
									span = inputSpan.Slice(num);
									continue;
								}
								runtextpos = num;
								Capture(0, start, num);
								return true;
							}
						}
						if (<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_hasTimeout)
						{
							CheckTimeout();
						}
						if (num2 >= num3)
						{
							break;
						}
						num = --num3;
						span = inputSpan.Slice(num);
					}
					return false;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__UnixPath_11 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__UnixPath_11();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__UnixPath_11()
		{
			pattern = "^(?:~|/)?(?:[^/\\0]+/)+[^/\\0]*$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__DotPrefix_12 : Regex
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
					if (num <= inputSpan.Length - 2 && num == 0)
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
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					if ((uint)readOnlySpan.Length < 2u || readOnlySpan[0] != '.' || !char.IsAsciiLetterOrDigit(readOnlySpan[1]))
					{
						return false;
					}
					int num2 = readOnlySpan.Slice(2).IndexOfAnyExcept(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_asciiLettersAndDigitsAndDashDotUnderscore);
					if (num2 < 0)
					{
						num2 = readOnlySpan.Length - 2;
					}
					readOnlySpan = readOnlySpan.Slice(num2);
					num += num2;
					if (3 < readOnlySpan.Length || (2 < readOnlySpan.Length && readOnlySpan[2] != '\n'))
					{
						return false;
					}
					Capture(0, start, runtextpos = num + 2);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__DotPrefix_12 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__DotPrefix_12();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__DotPrefix_12()
		{
			pattern = "^\\.[A-Za-z0-9][A-Za-z0-9._-]*$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__VersionToken_13 : Regex
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
					if (num <= inputSpan.Length - 4 && num == 0)
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
					int pos = 0;
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					if (readOnlySpan.IsEmpty || (readOnlySpan[0] | 0x20) != 118)
					{
						return false;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					int i;
					for (i = 0; (uint)i < (uint)readOnlySpan.Length && char.IsDigit(readOnlySpan[i]); i++)
					{
					}
					if (i == 0)
					{
						return false;
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					num2 = 0;
					while (true)
					{
						<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.StackPush(ref runstack, ref pos, num);
						num2++;
						if (!readOnlySpan.IsEmpty && readOnlySpan[0] == '.')
						{
							num++;
							readOnlySpan = inputSpan.Slice(num);
							int j;
							for (j = 0; (uint)j < (uint)readOnlySpan.Length && char.IsDigit(readOnlySpan[j]); j++)
							{
							}
							if (j != 0)
							{
								readOnlySpan = readOnlySpan.Slice(j);
								num += j;
								if (num2 < 3)
								{
									continue;
								}
								goto IL_0121;
							}
						}
						goto IL_00fb;
						IL_0121:
						if (num >= inputSpan.Length - 1 && ((uint)num >= (uint)inputSpan.Length || inputSpan[num] == '\n'))
						{
							break;
						}
						goto IL_00fb;
						IL_00fb:
						if (--num2 < 0)
						{
							return false;
						}
						num = runstack[--pos];
						readOnlySpan = inputSpan.Slice(num);
						if (num2 == 0)
						{
							return false;
						}
						goto IL_0121;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__VersionToken_13 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__VersionToken_13();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__VersionToken_13()
		{
			pattern = "^v\\d+(?:\\.\\d+){1,3}$";
			roptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__PullRequestOrIssue_14 : Regex
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
					if (num <= inputSpan.Length - 2 && num == 0)
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
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					if (readOnlySpan.IsEmpty)
					{
						return false;
					}
					switch (readOnlySpan[0])
					{
					case 'P':
					case 'p':
					{
						if ((uint)readOnlySpan.Length < 3u || !readOnlySpan.Slice(1).StartsWith("r-", StringComparison.OrdinalIgnoreCase))
						{
							return false;
						}
						num += 3;
						readOnlySpan = inputSpan.Slice(num);
						int j;
						for (j = 0; (uint)j < (uint)readOnlySpan.Length && char.IsDigit(readOnlySpan[j]); j++)
						{
						}
						if (j == 0)
						{
							return false;
						}
						readOnlySpan = readOnlySpan.Slice(j);
						num += j;
						break;
					}
					case '#':
					{
						num++;
						readOnlySpan = inputSpan.Slice(num);
						int i;
						for (i = 0; (uint)i < (uint)readOnlySpan.Length && char.IsDigit(readOnlySpan[i]); i++)
						{
						}
						if (i == 0)
						{
							return false;
						}
						readOnlySpan = readOnlySpan.Slice(i);
						num += i;
						break;
					}
					default:
						return false;
					}
					if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
					{
						return false;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__PullRequestOrIssue_14 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__PullRequestOrIssue_14();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__PullRequestOrIssue_14()
		{
			pattern = "^(?:PR-\\d+|#\\d+)$";
			roptions = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Acronym_15 : Regex
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
					if (num <= inputSpan.Length - 2 && num == 0)
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
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					int i;
					for (i = 0; i < 10 && (uint)i < (uint)readOnlySpan.Length && char.IsAsciiLetterUpper(readOnlySpan[i]); i++)
					{
					}
					if (i < 2)
					{
						return false;
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
					{
						return false;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Acronym_15 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Acronym_15();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Acronym_15()
		{
			pattern = "^[A-Z]{2,10}$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal sealed class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CodeIdentifier_16 : Regex
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
					if (num <= inputSpan.Length - 2 && num == 0)
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
					ReadOnlySpan<char> readOnlySpan = inputSpan.Slice(num);
					if (num != 0)
					{
						return false;
					}
					ulong num2;
					if (readOnlySpan.IsEmpty || (long)((ulong)(-261993005120L << (int)(num2 = (uint)(readOnlySpan[0] - 65))) & (num2 - 64)) >= 0L)
					{
						return false;
					}
					num++;
					readOnlySpan = inputSpan.Slice(num);
					int i;
					for (i = 0; i < 63 && (uint)i < (uint)readOnlySpan.Length; i++)
					{
						char c;
						if ((c = readOnlySpan[i]) >= '{')
						{
							break;
						}
						if (("\0\0\0Ͽ\ufffe蟿\ufffe߿"[(int)c >> 4] & (1 << (c & 0xF))) == 0)
						{
							break;
						}
					}
					if (i == 0)
					{
						return false;
					}
					readOnlySpan = readOnlySpan.Slice(i);
					num += i;
					if (num < inputSpan.Length - 1 || ((uint)num < (uint)inputSpan.Length && inputSpan[num] != '\n'))
					{
						return false;
					}
					runtextpos = num;
					Capture(0, start, num);
					return true;
				}
			}

			protected override RegexRunner CreateInstance()
			{
				return new Runner();
			}
		}

		internal static readonly <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CodeIdentifier_16 Instance = new <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CodeIdentifier_16();

		private <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CodeIdentifier_16()
		{
			pattern = "^[A-Za-z_][A-Za-z0-9_]{1,63}$";
			roptions = RegexOptions.CultureInvariant;
			Regex.ValidateMatchTimeout(<RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout);
			internalMatchTimeout = <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities.s_defaultTimeout;
			factory = new RunnerFactory();
			capsize = 1;
		}
	}
	[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
	internal static class <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Utilities
	{
		internal static readonly TimeSpan s_defaultTimeout = ((AppContext.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") is TimeSpan timeSpan) ? timeSpan : Regex.InfiniteMatchTimeout);

		internal static readonly bool s_hasTimeout = s_defaultTimeout != Regex.InfiniteMatchTimeout;

		internal static readonly SearchValues<char> s_asciiLetters = SearchValues.Create("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

		internal static readonly SearchValues<char> s_asciiLettersAndDigits = SearchValues.Create("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

		internal static readonly SearchValues<char> s_asciiLettersAndDigitsAndDashDot = SearchValues.Create("-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");

		internal static readonly SearchValues<char> s_asciiLettersAndDigitsAndDashDotUnderscore = SearchValues.Create("-.0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz");

		internal static readonly SearchValues<char> s_asciiLettersAndDigitsAndDotUnderscore = SearchValues.Create(".0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ_abcdefghijklmnopqrstuvwxyz");

		internal static readonly SearchValues<char> s_asciiLettersAndDigitsAndKelvinSign = SearchValues.Create("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzK");

		internal static readonly SearchValues<char> s_asciiLettersAndKelvinSign = SearchValues.Create("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzK");

		internal static readonly SearchValues<char> s_ascii_240000040400D40000000000000010 = SearchValues.Create("\n\r\"*:<>?|");

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void StackPop(int[] stack, ref int pos, out int arg0, out int arg1)
		{
			arg0 = stack[--pos];
			arg1 = stack[--pos];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void StackPush(ref int[] stack, ref int pos, int arg0)
		{
			int[] array = stack;
			int num = pos;
			if ((uint)num < (uint)array.Length)
			{
				array[num] = arg0;
				pos++;
			}
			else
			{
				WithResize(ref stack, ref pos, arg0);
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			static void WithResize(ref int[] reference, ref int reference2, int arg1)
			{
				Array.Resize(ref reference, reference2 * 2);
				StackPush(ref reference, ref reference2, arg1);
			}
		}

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
namespace SmartInput.Core.Updates
{
	public enum InstallerVerdict
	{
		Verified,
		SizeMismatch,
		HashMismatch
	}
	public static class InstallerVerification
	{
		public static InstallerVerdict Verify(Stream stream, long expectedSize, string expectedSha256)
		{
			ArgumentNullException.ThrowIfNull(stream, "stream");
			if (stream.Length != expectedSize)
			{
				return InstallerVerdict.SizeMismatch;
			}
			byte[] array;
			try
			{
				array = Convert.FromHexString(expectedSha256 ?? string.Empty);
			}
			catch (FormatException)
			{
				return InstallerVerdict.HashMismatch;
			}
			if (array.Length != 32)
			{
				return InstallerVerdict.HashMismatch;
			}
			stream.Position = 0L;
			byte[] array2 = SHA256.HashData(stream);
			if (stream.Position != expectedSize)
			{
				return InstallerVerdict.SizeMismatch;
			}
			if (!CryptographicOperations.FixedTimeEquals(array2, array))
			{
				return InstallerVerdict.HashMismatch;
			}
			return InstallerVerdict.Verified;
		}
	}
	public static class SetupCommandLine
	{
		public const string Passive = "/passive";

		public const string NoRestart = "/norestart";

		public const string Log = "/log";

		public static string Arguments(string logPath)
		{
			if (string.IsNullOrWhiteSpace(logPath) || logPath.IndexOfAny(new char[4] { '"', '\r', '\n', '\0' }) >= 0 || logPath.EndsWith('\\') || !Path.IsPathFullyQualified(logPath))
			{
				throw new ArgumentException("The setup log path must be a full path without quotes.", "logPath");
			}
			return $"{"/passive"} {"/norestart"} {"/log"} \"{logPath}\"";
		}
	}
	public enum ManifestFailure
	{
		None,
		InvalidManifest,
		ManifestExpired,
		ManifestReplayed,
		NoValidRelease
	}
	public enum EntryRefusal
	{
		TestLabel,
		InvalidVersion,
		InsecureReleasePage,
		InsecureSetupUrl,
		InvalidSetupSha256,
		SetupSizeOutOfBounds
	}
	public sealed record RefusedEntry(string Channel, string? Version, EntryRefusal Reason);
	public sealed record UpdateCandidate(string Version, string Channel, Uri ReleasePageUri, Uri? SetupUri, string? SetupSha256, long? SetupSize, long Serial)
	{
		public bool IsInstallable => (object)SetupUri != null;
	}
	public enum ManifestVerdictKind
	{
		UpToDate,
		Available,
		Refused
	}
	public sealed record ManifestVerdict(ManifestVerdictKind Kind, UpdateCandidate? Newest, ManifestFailure Failure, string Detail, IReadOnlyList<RefusedEntry> RefusedEntries)
	{
		public UpdateCandidate? Candidate
		{
			get
			{
				if (Kind != ManifestVerdictKind.Available)
				{
					return null;
				}
				return Newest;
			}
		}
	}
	public static class ManifestPolicy
	{
		public static readonly TimeSpan MaximumValidity = TimeSpan.FromDays(400);

		public static readonly TimeSpan MaximumClockSkew = TimeSpan.FromDays(7);

		public const long MinimumSetupBytes = 1048576L;

		public const long MaximumSetupBytes = 419430400L;

		public const string StableChannel = "stable";

		public const string PreviewChannel = "preview";

		private static readonly Regex Sha256Pattern = new Regex("^[a-fA-F0-9]{64}$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		public static ManifestVerdict Evaluate(UpdateManifestPayload payload, SemanticVersion installed, bool includePreviews, DateTimeOffset now, long highestSerialSeen)
		{
			ArgumentNullException.ThrowIfNull(payload, "payload");
			ArgumentNullException.ThrowIfNull(installed, "installed");
			if (payload.SchemaVersion != 2)
			{
				return Refused(ManifestFailure.InvalidManifest, $"schemaVersion {payload.SchemaVersion}");
			}
			if (!string.Equals(payload.Product, "Diyar", StringComparison.Ordinal))
			{
				return Refused(ManifestFailure.InvalidManifest, "product");
			}
			if (payload.Serial <= 0)
			{
				return Refused(ManifestFailure.InvalidManifest, "serial");
			}
			DateTime? issuedUtc = payload.IssuedUtc;
			if (issuedUtc.HasValue)
			{
				DateTime valueOrDefault = issuedUtc.GetValueOrDefault();
				if (valueOrDefault.Kind == DateTimeKind.Utc)
				{
					issuedUtc = payload.ExpiresUtc;
					if (issuedUtc.HasValue)
					{
						DateTime valueOrDefault2 = issuedUtc.GetValueOrDefault();
						if (valueOrDefault2.Kind == DateTimeKind.Utc)
						{
							if (valueOrDefault2 <= valueOrDefault)
							{
								return Refused(ManifestFailure.InvalidManifest, "expires before issued");
							}
							if (valueOrDefault2 - valueOrDefault > MaximumValidity)
							{
								return Refused(ManifestFailure.InvalidManifest, "valid too long");
							}
							if (valueOrDefault > now.UtcDateTime + MaximumClockSkew)
							{
								return Refused(ManifestFailure.InvalidManifest, "issued in the future");
							}
							if (now.UtcDateTime > valueOrDefault2)
							{
								return Refused(ManifestFailure.ManifestExpired, $"expired {valueOrDefault2:yyyy-MM-dd}");
							}
							if (payload.Serial < highestSerialSeen)
							{
								return Refused(ManifestFailure.ManifestReplayed, $"serial {payload.Serial} below {highestSerialSeen}");
							}
							List<RefusedEntry> list = new List<RefusedEntry>();
							List<(SemanticVersion, UpdateCandidate)> list2 = new List<(SemanticVersion, UpdateCandidate)>();
							Consider("stable", payload.Stable, payload.Serial, list2, list);
							if (includePreviews)
							{
								Consider("preview", payload.Preview, payload.Serial, list2, list);
							}
							if (list2.Count == 0)
							{
								return new ManifestVerdict(ManifestVerdictKind.Refused, null, ManifestFailure.NoValidRelease, "no valid release", list);
							}
							(SemanticVersion, UpdateCandidate) tuple = list2.OrderByDescending(((SemanticVersion Version, UpdateCandidate Candidate) entry) => entry.Version, Comparer<SemanticVersion>.Default).First();
							if (tuple.Item1.CompareTo(installed) <= 0)
							{
								return new ManifestVerdict(ManifestVerdictKind.UpToDate, tuple.Item2, ManifestFailure.None, string.Empty, list);
							}
							return new ManifestVerdict(ManifestVerdictKind.Available, tuple.Item2, ManifestFailure.None, string.Empty, list);
						}
					}
				}
			}
			return Refused(ManifestFailure.InvalidManifest, "dates are not UTC");
		}

		public static EntryRefusal? CheckEntry(ManifestChannelEntry entry, out SemanticVersion? version)
		{
			ArgumentNullException.ThrowIfNull(entry, "entry");
			version = null;
			if (SemanticVersion.HasTestLabel(entry.Version))
			{
				return EntryRefusal.TestLabel;
			}
			if (!SemanticVersion.TryParse(entry.Version, out version))
			{
				return EntryRefusal.InvalidVersion;
			}
			if (!IsHttps(entry.ReleasePageUrl))
			{
				return EntryRefusal.InsecureReleasePage;
			}
			ManifestSetupFile setup = entry.Setup;
			if (setup != null)
			{
				if (!IsHttps(setup.Url))
				{
					return EntryRefusal.InsecureSetupUrl;
				}
				if (setup.Sha256 == null || !Sha256Pattern.IsMatch(setup.Sha256))
				{
					return EntryRefusal.InvalidSetupSha256;
				}
				if (setup.Size < 1048576 || setup.Size > 419430400)
				{
					return EntryRefusal.SetupSizeOutOfBounds;
				}
			}
			return null;
		}

		private static void Consider(string channel, ManifestChannelEntry? entry, long serial, List<(SemanticVersion, UpdateCandidate)> candidates, List<RefusedEntry> refused)
		{
			if (entry != null)
			{
				EntryRefusal? entryRefusal = CheckEntry(entry, out SemanticVersion version);
				if (entryRefusal.HasValue)
				{
					refused.Add(new RefusedEntry(channel, entry.Version, entryRefusal.Value));
					return;
				}
				ManifestSetupFile setup = entry.Setup;
				candidates.Add((version, new UpdateCandidate(entry.Version.Trim(), channel, new Uri(entry.ReleasePageUrl, UriKind.Absolute), (setup == null) ? null : new Uri(setup.Url, UriKind.Absolute), setup?.Sha256.ToLowerInvariant(), setup?.Size, serial)));
			}
		}

		private static bool IsHttps(string? value)
		{
			if (Uri.TryCreate(value, UriKind.Absolute, out Uri result) && result.Scheme == Uri.UriSchemeHttps)
			{
				return !string.IsNullOrEmpty(result.Host);
			}
			return false;
		}

		private static ManifestVerdict Refused(ManifestFailure failure, string detail)
		{
			return new ManifestVerdict(ManifestVerdictKind.Refused, null, failure, detail, Array.Empty<RefusedEntry>());
		}
	}
	public enum SignatureStatus
	{
		Valid,
		Unsigned,
		Invalid
	}
	public sealed record SignatureVerdict(SignatureStatus Status, string? KeyId, int Checked, IReadOnlyList<string> UnknownKeyIds, int OtherAlgorithms);
	public static class ManifestSignatureVerifier
	{
		public const string Algorithm = "ES256";

		public const string DomainTag = "diyar-update-manifest-v2\n";

		public const int SignatureBytes = 64;

		private static readonly ConcurrentDictionary<string, ECDsa> ImportedKeys = new ConcurrentDictionary<string, ECDsa>(StringComparer.Ordinal);

		public const int P256SubjectPublicKeyInfoBytes = 91;

		private static ReadOnlySpan<byte> P256SubjectPublicKeyInfoPrefix => new byte[27]
		{
			48, 89, 48, 19, 6, 7, 42, 134, 72, 206,
			61, 2, 1, 6, 8, 42, 134, 72, 206, 61,
			3, 1, 7, 3, 66, 0, 4
		};

		public static byte[] SignedBytes(ReadOnlySpan<byte> payload)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("diyar-update-manifest-v2\n");
			byte[] array = new byte[bytes.Length + payload.Length];
			bytes.CopyTo(array, 0);
			payload.CopyTo(array.AsSpan(bytes.Length));
			return array;
		}

		public static SignatureVerdict Verify(SignedManifestEnvelope envelope, IReadOnlyList<TrustedKey> keys)
		{
			ArgumentNullException.ThrowIfNull(envelope, "envelope");
			ArgumentNullException.ThrowIfNull(keys, "keys");
			if (envelope.SignedPayload == null)
			{
				return new SignatureVerdict(SignatureStatus.Unsigned, null, 0, Array.Empty<string>(), 0);
			}
			byte[] data = SignedBytes(envelope.SignedPayload);
			List<string> list = new List<string>();
			int num = 0;
			int num2 = 0;
			foreach (ManifestSignature signature in envelope.Signatures)
			{
				if (!string.Equals(signature.Alg, "ES256", StringComparison.Ordinal))
				{
					num++;
					continue;
				}
				List<TrustedKey> list2 = keys.Where((TrustedKey key) => string.Equals(key.KeyId, signature.KeyId, StringComparison.Ordinal)).ToList();
				if (list2.Count == 0)
				{
					list.Add(signature.KeyId);
					continue;
				}
				foreach (TrustedKey item in list2)
				{
					num2++;
					if (VerifyOne(data, signature.Sig, item))
					{
						return new SignatureVerdict(SignatureStatus.Valid, item.KeyId, num2, list, num);
					}
				}
			}
			return new SignatureVerdict(SignatureStatus.Invalid, null, num2, list, num);
		}

		private static bool VerifyOne(byte[] data, string signatureBase64, TrustedKey key)
		{
			try
			{
				byte[] array = Convert.FromBase64String(signatureBase64);
				if (array.Length != 64)
				{
					return false;
				}
				ECDsa eCDsa = Import(key.SubjectPublicKeyInfoBase64);
				if (eCDsa == null)
				{
					return false;
				}
				lock (eCDsa)
				{
					return eCDsa.VerifyData(data, array, HashAlgorithmName.SHA256, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);
				}
			}
			catch (FormatException)
			{
				return false;
			}
			catch (CryptographicException)
			{
				return false;
			}
		}

		private static ECDsa? Import(string subjectPublicKeyInfoBase64)
		{
			if (ImportedKeys.TryGetValue(subjectPublicKeyInfoBase64, out ECDsa value))
			{
				return value;
			}
			byte[] array = Convert.FromBase64String(subjectPublicKeyInfoBase64);
			if (array.Length != 91 || !((ReadOnlySpan<byte>)array.AsSpan()).StartsWith(P256SubjectPublicKeyInfoPrefix))
			{
				return null;
			}
			ECDsa eCDsa = ECDsa.Create();
			try
			{
				eCDsa.ImportSubjectPublicKeyInfo(array, out var bytesRead);
				if (bytesRead != array.Length)
				{
					eCDsa.Dispose();
					return null;
				}
			}
			catch
			{
				eCDsa.Dispose();
				throw;
			}
			ECDsa orAdd = ImportedKeys.GetOrAdd(subjectPublicKeyInfoBase64, eCDsa);
			if (orAdd != eCDsa)
			{
				eCDsa.Dispose();
			}
			return orAdd;
		}
	}
	public sealed record PendingUpdateMarker(string ExpectedVersion, string PreviousVersion, DateTimeOffset StartedUtc, string SetupPath, string LogPath, bool WindowWasVisible)
	{
		public enum ReadState
		{
			Missing,
			Damaged,
			Read
		}

		public const int MaximumBytes = 16384;

		private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			PropertyNameCaseInsensitive = true,
			UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
			WriteIndented = true
		};

		public string ToJson()
		{
			return JsonSerializer.Serialize(this, Options);
		}

		public static PendingUpdateMarker? Parse(string? json)
		{
			if (string.IsNullOrWhiteSpace(json) || json.Length > 16384)
			{
				return null;
			}
			PendingUpdateMarker pendingUpdateMarker;
			try
			{
				pendingUpdateMarker = JsonSerializer.Deserialize<PendingUpdateMarker>(json, Options);
			}
			catch (JsonException)
			{
				return null;
			}
			catch (NotSupportedException)
			{
				return null;
			}
			if ((object)pendingUpdateMarker == null || !UpdateFileNames.IsFileVersion(pendingUpdateMarker.ExpectedVersion) || string.IsNullOrEmpty(pendingUpdateMarker.PreviousVersion) || string.IsNullOrEmpty(pendingUpdateMarker.LogPath) || string.IsNullOrEmpty(pendingUpdateMarker.SetupPath) || !(pendingUpdateMarker.StartedUtc != default(DateTimeOffset)))
			{
				return null;
			}
			return pendingUpdateMarker;
		}

		public static (ReadState State, PendingUpdateMarker? Marker) Read(string path)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(path);
				if (!fileInfo.Exists)
				{
					return (State: ReadState.Missing, Marker: null);
				}
				if (fileInfo.Length > 16384)
				{
					return (State: ReadState.Damaged, Marker: null);
				}
				PendingUpdateMarker pendingUpdateMarker = Parse(File.ReadAllText(path));
				return ((object)pendingUpdateMarker == null) ? (State: ReadState.Damaged, Marker: null) : (State: ReadState.Read, Marker: pendingUpdateMarker);
			}
			catch (Exception ex) when ((ex is IOException || ex is UnauthorizedAccessException) ? true : false)
			{
				return (State: ReadState.Damaged, Marker: null);
			}
		}

		public void Write(string path)
		{
			string text = path + ".tmp";
			File.WriteAllText(text, ToJson());
			File.Move(text, path, overwrite: true);
		}
	}
	public sealed class SemanticVersion : IComparable<SemanticVersion>
	{
		private static readonly Regex VersionPattern = new Regex("^(0|[1-9]\\d*)\\.(0|[1-9]\\d*)\\.(0|[1-9]\\d*)(?:-([0-9A-Za-z-]+(?:\\.[0-9A-Za-z-]+)*))?(?:\\+[0-9A-Za-z-]+(?:\\.[0-9A-Za-z-]+)*)?$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		private static readonly char[] LabelSeparators = new char[2] { '-', '+' };

		private readonly string[] _prerelease;

		public int Major { get; }

		public int Minor { get; }

		public int Patch { get; }

		private SemanticVersion(int major, int minor, int patch, string[] prerelease)
		{
			Major = major;
			Minor = minor;
			Patch = patch;
			_prerelease = prerelease;
		}

		public static bool TryParse(string? value, out SemanticVersion? version)
		{
			version = null;
			if (string.IsNullOrWhiteSpace(value))
			{
				return false;
			}
			Match match = VersionPattern.Match(value.Trim());
			if (!match.Success || !int.TryParse(match.Groups[1].Value, out var result) || !int.TryParse(match.Groups[2].Value, out var result2) || !int.TryParse(match.Groups[3].Value, out var result3))
			{
				return false;
			}
			string[] array = ((!match.Groups[4].Success) ? Array.Empty<string>() : match.Groups[4].Value.Split('.'));
			if (array.Any((string identifier) => identifier.Length > 1 && identifier[0] == '0' && identifier.All(char.IsDigit)))
			{
				return false;
			}
			version = new SemanticVersion(result, result2, result3, array);
			return true;
		}

		public static bool HasTestLabel(string? value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				return false;
			}
			string text = value.Trim();
			int num = text.IndexOfAny(LabelSeparators);
			if (num >= 0)
			{
				return text.Substring(num).Contains("test", StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		public int CompareTo(SemanticVersion? other)
		{
			if (other == null)
			{
				return 1;
			}
			int num = Major.CompareTo(other.Major);
			if (num == 0)
			{
				num = Minor.CompareTo(other.Minor);
			}
			if (num == 0)
			{
				num = Patch.CompareTo(other.Patch);
			}
			if (num != 0)
			{
				return num;
			}
			if (_prerelease.Length == 0)
			{
				return (other._prerelease.Length != 0) ? 1 : 0;
			}
			if (other._prerelease.Length == 0)
			{
				return -1;
			}
			for (int i = 0; i < Math.Max(_prerelease.Length, other._prerelease.Length); i++)
			{
				if (i >= _prerelease.Length)
				{
					return -1;
				}
				if (i >= other._prerelease.Length)
				{
					return 1;
				}
				bool flag = int.TryParse(_prerelease[i], out var result);
				bool flag2 = int.TryParse(other._prerelease[i], out var result2);
				int num2;
				if (flag & flag2)
				{
					num2 = result.CompareTo(result2);
				}
				else
				{
					num2 = (flag ? (-1) : (flag2 ? 1 : string.Compare(_prerelease[i], other._prerelease[i], StringComparison.OrdinalIgnoreCase)));
				}
				if (num2 != 0)
				{
					return num2;
				}
			}
			return 0;
		}
	}
	public enum SetupOutcome
	{
		Succeeded,
		RestartRequired,
		Cancelled,
		PermissionRefused,
		NewerInstalled,
		Failed
	}
	public static class SetupExitCodes
	{
		public const int Success = 0;

		public const int SuccessRestartRequired = 3010;

		public const int UserCancelled = 1602;

		public const int PermissionRefused = 1223;

		public const int NewerVersionInstalled = 1638;

		public static SetupOutcome Classify(int exitCode)
		{
			return exitCode switch
			{
				0 => SetupOutcome.Succeeded, 
				3010 => SetupOutcome.RestartRequired, 
				1602 => SetupOutcome.Cancelled, 
				1223 => SetupOutcome.PermissionRefused, 
				1638 => SetupOutcome.NewerInstalled, 
				_ => SetupOutcome.Failed, 
			};
		}
	}
	public sealed record SetupResultFile(int ExitCode, string? Status, string? Version, bool RestartRequired)
	{
		public const int MaximumBytes = 4096;

		public static SetupResultFile? Parse(string? text)
		{
			if (string.IsNullOrEmpty(text) || text.Length > 4096)
			{
				return null;
			}
			int? num = null;
			string status = null;
			string version = null;
			bool restartRequired = false;
			string[] array = text.Split('\n');
			for (int i = 0; i < array.Length; i++)
			{
				string text2 = array[i].TrimEnd('\r');
				int num2 = text2.IndexOf('=');
				if (num2 > 0)
				{
					string text3 = text2.Substring(0, num2).Trim();
					string text4 = text2.Substring(num2 + 1).Trim();
					switch (text3)
					{
					case "exitCode":
					{
						num = (int.TryParse(text4, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var result) ? new int?(result) : ((int?)null));
						break;
					}
					case "status":
						status = ((text4.Length == 0) ? null : text4);
						break;
					case "version":
						version = ((text4.Length == 0) ? null : text4);
						break;
					case "restart":
						restartRequired = text4 == "1";
						break;
					}
				}
			}
			if (num.HasValue)
			{
				return new SetupResultFile(num.Value, status, version, restartRequired);
			}
			return null;
		}

		public static SetupResultFile? Read(string path)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(path);
				if (!fileInfo.Exists || fileInfo.Length > 4096)
				{
					return null;
				}
				return Parse(File.ReadAllText(path));
			}
			catch (IOException)
			{
				return null;
			}
			catch (UnauthorizedAccessException)
			{
				return null;
			}
		}
	}
	public enum SignedManifestOutcome
	{
		ReadSchemaOne,
		EnvelopeInvalid,
		Unsigned,
		SignatureInvalid,
		PayloadInvalid,
		Refused,
		UpToDate,
		Available
	}
	public enum SchemaOneReason
	{
		None,
		NoTrustRoots,
		NotRequired
	}
	public sealed record SignedManifestCheckOptions(IReadOnlyList<TrustedKey> TrustRoots, bool RequireSignedManifest, SemanticVersion Installed, bool IncludePreviews, DateTimeOffset Now, long HighestSerialSeen);
	public sealed record SignedManifestCheckResult(SignedManifestOutcome Outcome, SchemaOneReason SchemaOneReason, string Detail, SignatureVerdict? Signature, UpdateManifestPayload? Payload, ManifestVerdict? Verdict, bool OuterMismatch)
	{
		public UpdateCandidate? Candidate
		{
			get
			{
				if (Outcome != SignedManifestOutcome.Available)
				{
					return null;
				}
				return Verdict?.Candidate;
			}
		}

		public long? AcceptedSerial
		{
			get
			{
				SignedManifestOutcome outcome = Outcome;
				if ((uint)(outcome - 6) > 1u)
				{
					return null;
				}
				return Payload?.Serial;
			}
		}

		public string SignedLogValue
		{
			get
			{
				if (SchemaOneReason == SchemaOneReason.NoTrustRoots)
				{
					return "nokeys";
				}
				SignatureVerdict signature = Signature;
				return ((object)signature == null) ? "-" : (signature.Status switch
				{
					SignatureStatus.Valid => "valid:" + signature.KeyId, 
					SignatureStatus.Unsigned => "none", 
					_ => "invalid", 
				});
			}
		}

		public string LogFields
		{
			get
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(52, 5);
				defaultInterpolatedStringHandler.AppendLiteral("signed=");
				defaultInterpolatedStringHandler.AppendFormatted(SignedLogValue);
				defaultInterpolatedStringHandler.AppendLiteral(" serial=");
				defaultInterpolatedStringHandler.AppendFormatted((Payload == null) ? "-" : Payload.Serial.ToString(CultureInfo.InvariantCulture));
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendLiteral("expires=");
				DateTime? dateTime = Payload?.ExpiresUtc;
				defaultInterpolatedStringHandler.AppendFormatted((!dateTime.HasValue) ? "-" : dateTime.GetValueOrDefault().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendLiteral("unknownKeys=");
				defaultInterpolatedStringHandler.AppendFormatted(Signature?.UnknownKeyIds.Count ?? 0);
				defaultInterpolatedStringHandler.AppendLiteral(" outerMismatch=");
				defaultInterpolatedStringHandler.AppendFormatted(OuterMismatch ? "true" : "false");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}

		public const string NotEvaluatedLogFields = "signed=- serial=- expires=- unknownKeys=0 outerMismatch=false";
	}
	public static class SignedManifestCheck
	{
		public static SignedManifestCheckResult Evaluate(ReadOnlySpan<byte> body, SignedManifestCheckOptions options)
		{
			ArgumentNullException.ThrowIfNull(options, "options");
			ArgumentNullException.ThrowIfNull(options.TrustRoots, "options.TrustRoots");
			ArgumentNullException.ThrowIfNull(options.Installed, "options.Installed");
			if (options.TrustRoots.Count == 0)
			{
				return new SignedManifestCheckResult(SignedManifestOutcome.ReadSchemaOne, SchemaOneReason.NoTrustRoots, "no trusted key", null, null, null, OuterMismatch: false);
			}
			if (!SignedManifestEnvelope.TryParse(body, out SignedManifestEnvelope envelope, out string problem))
			{
				return new SignedManifestCheckResult(SignedManifestOutcome.EnvelopeInvalid, SchemaOneReason.None, problem, null, null, null, OuterMismatch: false);
			}
			SignatureVerdict signatureVerdict = ManifestSignatureVerifier.Verify(envelope, options.TrustRoots);
			switch (signatureVerdict.Status)
			{
			case SignatureStatus.Unsigned:
				if (!options.RequireSignedManifest)
				{
					return new SignedManifestCheckResult(SignedManifestOutcome.ReadSchemaOne, SchemaOneReason.NotRequired, "no signed payload", signatureVerdict, null, null, OuterMismatch: false);
				}
				return new SignedManifestCheckResult(SignedManifestOutcome.Unsigned, SchemaOneReason.None, "no signed payload", signatureVerdict, null, null, OuterMismatch: false);
			case SignatureStatus.Invalid:
				return new SignedManifestCheckResult(SignedManifestOutcome.SignatureInvalid, SchemaOneReason.None, $"checked {signatureVerdict.Checked}", signatureVerdict, null, null, OuterMismatch: false);
			default:
			{
				if (!UpdateManifestPayload.TryParse(envelope.SignedPayload, out UpdateManifestPayload payload, out problem))
				{
					return new SignedManifestCheckResult(SignedManifestOutcome.PayloadInvalid, SchemaOneReason.None, problem, signatureVerdict, null, null, OuterMismatch: false);
				}
				bool outerMismatch = OuterMismatch(envelope, payload, options.IncludePreviews);
				ManifestVerdict manifestVerdict = ManifestPolicy.Evaluate(payload, options.Installed, options.IncludePreviews, options.Now, options.HighestSerialSeen);
				return new SignedManifestCheckResult(manifestVerdict.Kind switch
				{
					ManifestVerdictKind.Available => SignedManifestOutcome.Available, 
					ManifestVerdictKind.UpToDate => SignedManifestOutcome.UpToDate, 
					_ => SignedManifestOutcome.Refused, 
				}, SchemaOneReason.None, manifestVerdict.Detail, signatureVerdict, payload, manifestVerdict, outerMismatch);
			}
			}
		}

		public static bool OuterMismatch(SignedManifestEnvelope envelope, UpdateManifestPayload payload, bool includePreviews)
		{
			ArgumentNullException.ThrowIfNull(envelope, "envelope");
			ArgumentNullException.ThrowIfNull(payload, "payload");
			if (SameVersion(envelope.OuterStableVersion, payload.Stable?.Version))
			{
				if (includePreviews)
				{
					return !SameVersion(envelope.OuterPreviewVersion, payload.Preview?.Version);
				}
				return false;
			}
			return true;
		}

		private static bool SameVersion(string? outer, string? signed)
		{
			return string.Equals(outer?.Trim(), signed?.Trim(), StringComparison.Ordinal);
		}
	}
	public sealed record ManifestSignature(string KeyId, string Alg, string Sig);
	public sealed class SignedManifestEnvelope
	{
		public const int MaximumBytes = 1048576;

		public const string NotJsonProblem = "not JSON";

		public const int OuterSchemaVersion = 1;

		private static readonly JsonDocumentOptions DocumentOptions = new JsonDocumentOptions
		{
			AllowDuplicateProperties = false,
			MaxDepth = 16
		};

		public byte[]? SignedPayload { get; }

		public IReadOnlyList<ManifestSignature> Signatures { get; }

		public string? OuterStableVersion { get; }

		public string? OuterPreviewVersion { get; }

		private SignedManifestEnvelope(byte[]? signedPayload, IReadOnlyList<ManifestSignature> signatures, string? outerStableVersion, string? outerPreviewVersion)
		{
			SignedPayload = signedPayload;
			Signatures = signatures;
			OuterStableVersion = outerStableVersion;
			OuterPreviewVersion = outerPreviewVersion;
		}

		public static bool TryParse(ReadOnlySpan<byte> json, out SignedManifestEnvelope? envelope, out string problem)
		{
			envelope = null;
			if (json.Length > 1048576)
			{
				problem = "too large";
				return false;
			}
			try
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(json.ToArray(), DocumentOptions);
				JsonElement rootElement = jsonDocument.RootElement;
				if (rootElement.ValueKind != JsonValueKind.Object)
				{
					problem = "not an object";
					return false;
				}
				if (!rootElement.TryGetProperty("schemaVersion", out var value) || value.ValueKind != JsonValueKind.Number || !value.TryGetInt32(out var value2) || value2 != 1)
				{
					problem = "schemaVersion";
					return false;
				}
				byte[] array = null;
				if (rootElement.TryGetProperty("signed", out var value3) && value3.ValueKind != JsonValueKind.Null)
				{
					if (value3.ValueKind != JsonValueKind.String)
					{
						problem = "signed is not a string";
						return false;
					}
					try
					{
						array = Convert.FromBase64String(value3.GetString());
					}
					catch (FormatException)
					{
						problem = "signed is not base64";
						return false;
					}
					if (array.Length == 0)
					{
						problem = "signed is empty";
						return false;
					}
				}
				List<ManifestSignature> list = new List<ManifestSignature>();
				if (rootElement.TryGetProperty("signatures", out var value4) && value4.ValueKind != JsonValueKind.Null)
				{
					if (value4.ValueKind != JsonValueKind.Array)
					{
						problem = "signatures is not an array";
						return false;
					}
					foreach (JsonElement item in value4.EnumerateArray())
					{
						list.Add((item.ValueKind == JsonValueKind.Object) ? new ManifestSignature(StringMember(item, "keyId"), StringMember(item, "alg"), StringMember(item, "sig")) : new ManifestSignature(string.Empty, string.Empty, string.Empty));
					}
				}
				envelope = new SignedManifestEnvelope(array, list, OuterVersion(rootElement, "stable"), OuterVersion(rootElement, "preview"));
				problem = string.Empty;
				return true;
			}
			catch (JsonException)
			{
				problem = "not JSON";
				return false;
			}
		}

		private static string StringMember(JsonElement element, string name)
		{
			if (!element.TryGetProperty(name, out var value) || value.ValueKind != JsonValueKind.String)
			{
				return string.Empty;
			}
			return value.GetString();
		}

		private static string? OuterVersion(JsonElement root, string channel)
		{
			if (!root.TryGetProperty(channel, out var value) || value.ValueKind != JsonValueKind.Object || !value.TryGetProperty("version", out var value2) || value2.ValueKind != JsonValueKind.String)
			{
				return null;
			}
			return value2.GetString();
		}
	}
	public sealed record UpdateFolderEntry(string Name, DateTimeOffset LastWriteUtc);
	public static class UpdateCleanup
	{
		public static readonly TimeSpan Expiry = TimeSpan.FromDays(14);

		public static IReadOnlyList<string> Select(IEnumerable<UpdateFolderEntry> entries, string installedVersion, DateTimeOffset now, string? keepVersion = null, string? offeredVersion = null)
		{
			SemanticVersion.TryParse(installedVersion, out SemanticVersion version);
			SemanticVersion version2 = null;
			SemanticVersion version3 = null;
			if (keepVersion != null)
			{
				SemanticVersion.TryParse(keepVersion, out version2);
			}
			if (offeredVersion != null)
			{
				SemanticVersion.TryParse(offeredVersion, out version3);
			}
			List<string> list = new List<string>();
			foreach (UpdateFolderEntry entry in entries)
			{
				if (UpdateFileNames.TryClassify(entry.Name, out UpdateFileKind kind, out SemanticVersion version4) && (version2 == null || version4.CompareTo(version2) != 0))
				{
					bool flag = now - entry.LastWriteUtc > Expiry;
					bool flag2 = version != null && version4.CompareTo(version) <= 0;
					bool flag3 = version3 != null && version4.CompareTo(version3) != 0;
					if (kind switch
					{
						UpdateFileKind.Setup => flag2 | flag3, 
						UpdateFileKind.Partial => flag2 | flag3 | flag, 
						_ => flag, 
					})
					{
						list.Add(entry.Name);
					}
				}
			}
			return list;
		}
	}
	public enum DownloadResponsePlan
	{
		WriteFromStart,
		Append,
		Redirect,
		DeletePartialAndRestart,
		SizeMismatch,
		HttpError
	}
	public static class UpdateDownloadRules
	{
		public const int MaximumRedirects = 5;

		public const int ChunkBytes = 65536;

		public const long FreeSpaceMargin = 67108864L;

		public static readonly TimeSpan StallTimeout = TimeSpan.FromSeconds(30L);

		public static readonly TimeSpan ProgressInterval = TimeSpan.FromMilliseconds(250L);

		public static readonly IReadOnlyList<TimeSpan> RetryDelays = new <>z__ReadOnlyArray<TimeSpan>(new TimeSpan[3]
		{
			TimeSpan.FromSeconds(2L),
			TimeSpan.FromSeconds(5L),
			TimeSpan.FromSeconds(10L)
		});

		public static DownloadResponsePlan Plan(int statusCode, long? contentLength, long? rangeStart, long size, long offset)
		{
			switch (statusCode)
			{
			case 200:
				return (contentLength.HasValue && contentLength != size) ? DownloadResponsePlan.SizeMismatch : DownloadResponsePlan.WriteFromStart;
			case 206:
				return (offset > 0 && (!rangeStart.HasValue || rangeStart == offset) && (!contentLength.HasValue || contentLength == size - offset)) ? DownloadResponsePlan.Append : DownloadResponsePlan.SizeMismatch;
			case 301:
			case 302:
			case 303:
			case 307:
			case 308:
				return DownloadResponsePlan.Redirect;
			case 416:
				return DownloadResponsePlan.DeletePartialAndRestart;
			default:
				return DownloadResponsePlan.HttpError;
			}
		}

		public static bool TryFollowRedirect(Uri? location, int hop, out Uri? next, out bool tooMany)
		{
			next = null;
			tooMany = hop > 5;
			if (tooMany || (object)location == null || !location.IsAbsoluteUri || location.Scheme != Uri.UriSchemeHttps)
			{
				return false;
			}
			next = location;
			return true;
		}

		public static long RequiredFreeSpace(long size, long partialLength)
		{
			return Math.Max(0L, size - partialLength) + 67108864;
		}

		public static bool ShouldResume(long bytesReceivedThisClick, int resumesSoFar)
		{
			if (bytesReceivedThisClick > 0)
			{
				return resumesSoFar < RetryDelays.Count;
			}
			return false;
		}

		public static string Megabytes(long bytes)
		{
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(3, 1, invariantCulture);
			handler.AppendFormatted((double)Math.Max(0L, bytes) / 1048576.0, "0.0");
			handler.AppendLiteral(" MB");
			return string.Create(invariantCulture, ref handler);
		}
	}
	public enum UpdateFileKind
	{
		Setup,
		Partial,
		Log,
		Result,
		PackageLog
	}
	public static class UpdateFileNames
	{
		public const string MarkerFileName = "pending-update.json";

		private const string PartialSuffix = ".partial";

		private const string ResultSuffix = ".result";

		private static readonly Regex OursPattern = new Regex("^(?:Diyar-(?<v>[0-9A-Za-z.+-]+)-win-x64-setup\\.exe(?<partial>\\.partial)?|setup-(?<v>[0-9A-Za-z.+-]+)\\.log(?:(?<result>\\.result)|(?<package>_[0-9]{3}_[0-9A-Za-z]+\\.log))?)$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

		public static string SetupFileName(string version)
		{
			return "Diyar-" + Checked(version) + "-win-x64-setup.exe";
		}

		public static string PartialFileName(string version)
		{
			return SetupFileName(version) + ".partial";
		}

		public static string SetupLogFileName(string version)
		{
			return "setup-" + Checked(version) + ".log";
		}

		public static string SetupResultFileName(string version)
		{
			return SetupLogFileName(version) + ".result";
		}

		public static bool IsOurs(string? fileName, out SemanticVersion? version)
		{
			UpdateFileKind kind;
			return TryClassify(fileName, out kind, out version);
		}

		public static bool TryClassify(string? fileName, out UpdateFileKind kind, out SemanticVersion? version)
		{
			kind = UpdateFileKind.Setup;
			version = null;
			if (string.IsNullOrEmpty(fileName))
			{
				return false;
			}
			Match match = OursPattern.Match(fileName);
			if (!match.Success || !IsPlainVersion(match.Groups["v"].Value) || !SemanticVersion.TryParse(match.Groups["v"].Value, out version))
			{
				version = null;
				return false;
			}
			kind = (match.Groups["partial"].Success ? UpdateFileKind.Partial : (match.Groups["result"].Success ? UpdateFileKind.Result : (match.Groups["package"].Success ? UpdateFileKind.PackageLog : (fileName.StartsWith("setup-", StringComparison.Ordinal) ? UpdateFileKind.Log : UpdateFileKind.Setup))));
			return true;
		}

		public static bool IsFileVersion(string? version)
		{
			SemanticVersion version2;
			if (IsPlainVersion(version))
			{
				return SemanticVersion.TryParse(version, out version2);
			}
			return false;
		}

		private static string Checked(string version)
		{
			if (!IsPlainVersion(version) || !SemanticVersion.TryParse(version, out SemanticVersion _))
			{
				throw new ArgumentException("An update file name needs a semantic version.", "version");
			}
			return version;
		}

		private static bool IsPlainVersion(string? version)
		{
			if (!string.IsNullOrEmpty(version))
			{
				return version.All((char character) =>
				{
					bool flag = char.IsAsciiLetterOrDigit(character);
					if (!flag)
					{
						bool flag2;
						switch (character)
						{
						case '+':
						case '-':
						case '.':
							flag2 = true;
							break;
						default:
							flag2 = false;
							break;
						}
						flag = flag2;
					}
					return flag;
				});
			}
			return false;
		}
	}
	public sealed class UpdateManifestPayload
	{
		public const int CurrentSchemaVersion = 2;

		public const string ProductName = "Diyar";

		private static readonly JsonSerializerOptions ReadOptions = new JsonSerializerOptions
		{
			PropertyNameCaseInsensitive = true,
			UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip,
			NumberHandling = JsonNumberHandling.Strict,
			AllowDuplicateProperties = false,
			MaxDepth = 16
		};

		private static readonly JsonSerializerOptions WriteOptions = new JsonSerializerOptions
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			NumberHandling = JsonNumberHandling.Strict
		};

		private static readonly JsonSerializerOptions ReviewOptions = new JsonSerializerOptions(WriteOptions)
		{
			WriteIndented = true
		};

		[JsonPropertyName("schemaVersion")]
		public int SchemaVersion { get; init; }

		[JsonPropertyName("product")]
		public string? Product { get; init; }

		[JsonPropertyName("serial")]
		public long Serial { get; init; }

		[JsonPropertyName("issuedUtc")]
		public DateTime? IssuedUtc { get; init; }

		[JsonPropertyName("expiresUtc")]
		public DateTime? ExpiresUtc { get; init; }

		[JsonPropertyName("stable")]
		public ManifestChannelEntry? Stable { get; init; }

		[JsonPropertyName("preview")]
		public ManifestChannelEntry? Preview { get; init; }

		public static bool TryParse(ReadOnlySpan<byte> utf8Json, out UpdateManifestPayload? payload, out string problem)
		{
			try
			{
				payload = JsonSerializer.Deserialize<UpdateManifestPayload>(utf8Json, ReadOptions);
				problem = ((payload == null) ? "null" : string.Empty);
				return payload != null;
			}
			catch (JsonException ex)
			{
				payload = null;
				problem = ((ex.Path == null) ? "not JSON" : ("bad value at " + ex.Path));
				return false;
			}
		}

		public byte[] ToUtf8Bytes()
		{
			return JsonSerializer.SerializeToUtf8Bytes(this, WriteOptions);
		}

		public string ToReviewJson()
		{
			return JsonSerializer.Serialize(this, ReviewOptions);
		}
	}
	public sealed class ManifestChannelEntry
	{
		[JsonPropertyName("version")]
		public string? Version { get; init; }

		[JsonPropertyName("releasePageUrl")]
		public string? ReleasePageUrl { get; init; }

		[JsonPropertyName("setup")]
		public ManifestSetupFile? Setup { get; init; }
	}
	public sealed class ManifestSetupFile
	{
		[JsonPropertyName("url")]
		public string? Url { get; init; }

		[JsonPropertyName("sha256")]
		public string? Sha256 { get; init; }

		[JsonPropertyName("size")]
		public long Size { get; init; }
	}
	public enum UpdateOutcomeKind
	{
		None,
		Damaged,
		InProgress,
		Updated,
		UpdatedRestartPending,
		Superseded,
		PermissionRefused,
		Cancelled,
		NewerInstalled,
		Failed,
		Unknown
	}
	public sealed record UpdateRunCarry(string Version, UpdateRunState State, UpdateRunFailure Failure, int? ExitCode, string? LogPath);
	public sealed record UpdateOutcome(UpdateOutcomeKind Kind, PendingUpdateMarker? Marker = null, SetupResultFile? Result = null)
	{
		public static UpdateOutcome None { get; } = new UpdateOutcome(UpdateOutcomeKind.None);

		public string? Version => Marker?.ExpectedVersion;

		public bool IsSettled
		{
			get
			{
				UpdateOutcomeKind kind = Kind;
				bool flag = ((kind == UpdateOutcomeKind.None || kind == UpdateOutcomeKind.InProgress) ? true : false);
				return !flag;
			}
		}

		public bool Succeeded
		{
			get
			{
				UpdateOutcomeKind kind = Kind;
				if ((uint)(kind - 3) <= 1u)
				{
					return true;
				}
				return false;
			}
		}

		public bool DidNotFinish
		{
			get
			{
				UpdateOutcomeKind kind = Kind;
				if ((uint)(kind - 6) <= 4u)
				{
					return true;
				}
				return false;
			}
		}

		public UpdateRunCarry? Carry
		{
			get
			{
				string version = Version;
				if (version == null)
				{
					return null;
				}
				return Kind switch
				{
					UpdateOutcomeKind.PermissionRefused => new UpdateRunCarry(version, UpdateRunState.PermissionRefused, UpdateRunFailure.None, Result?.ExitCode, Marker.LogPath), 
					UpdateOutcomeKind.Cancelled => new UpdateRunCarry(version, UpdateRunState.Cancelled, UpdateRunFailure.None, Result?.ExitCode, Marker.LogPath), 
					UpdateOutcomeKind.Failed => new UpdateRunCarry(version, UpdateRunState.Failed, UpdateRunFailure.SetupFailed, Result?.ExitCode, Marker.LogPath), 
					_ => null, 
				};
			}
		}

		public bool ShowsWindow(DateTimeOffset now)
		{
			PendingUpdateMarker marker = Marker;
			if ((object)marker != null && marker.WindowWasVisible && (Succeeded || DidNotFinish))
			{
				return UpdateOutcomeRules.IsRecent(marker, now);
			}
			return false;
		}
	}
	public static class UpdateOutcomeRules
	{
		public static readonly TimeSpan RecentRun = TimeSpan.FromMinutes(30L);

		public static bool IsRecent(PendingUpdateMarker marker, DateTimeOffset now)
		{
			TimeSpan timeSpan = now - marker.StartedUtc;
			if (timeSpan < RecentRun)
			{
				return timeSpan > -RecentRun;
			}
			return false;
		}

		public static UpdateOutcome Classify(PendingUpdateMarker.ReadState markerState, PendingUpdateMarker? marker, SetupResultFile? result, string installedVersion, DateTimeOffset now)
		{
			if (markerState == PendingUpdateMarker.ReadState.Damaged)
			{
				return new UpdateOutcome(UpdateOutcomeKind.Damaged);
			}
			if ((object)marker == null)
			{
				return UpdateOutcome.None;
			}
			SemanticVersion.TryParse(marker.ExpectedVersion, out SemanticVersion version);
			string text = result?.Version;
			if (text != null && (!SemanticVersion.TryParse(text, out SemanticVersion version2) || version2.CompareTo(version) != 0))
			{
				result = null;
			}
			bool flag = (object)result != null && (result.RestartRequired || SetupExitCodes.Classify(result.ExitCode) == SetupOutcome.RestartRequired);
			if (SemanticVersion.TryParse(installedVersion, out SemanticVersion version3))
			{
				int num = version3.CompareTo(version);
				if (num == 0)
				{
					return new UpdateOutcome(flag ? UpdateOutcomeKind.UpdatedRestartPending : UpdateOutcomeKind.Updated, marker, result);
				}
				if (num > 0)
				{
					return new UpdateOutcome(UpdateOutcomeKind.Superseded, marker, result);
				}
			}
			if ((object)result == null)
			{
				return new UpdateOutcome(IsRecent(marker, now) ? UpdateOutcomeKind.InProgress : UpdateOutcomeKind.Unknown, marker);
			}
			return new UpdateOutcome(SetupExitCodes.Classify(result.ExitCode) switch
			{
				SetupOutcome.RestartRequired => UpdateOutcomeKind.UpdatedRestartPending, 
				SetupOutcome.Cancelled => UpdateOutcomeKind.Cancelled, 
				SetupOutcome.PermissionRefused => UpdateOutcomeKind.PermissionRefused, 
				SetupOutcome.NewerInstalled => UpdateOutcomeKind.NewerInstalled, 
				SetupOutcome.Failed => UpdateOutcomeKind.Failed, 
				_ => UpdateOutcomeKind.Unknown, 
			}, marker, result);
		}
	}
	public enum UpdateRunState
	{
		Idle,
		Available,
		Downloading,
		Verifying,
		Ready,
		Installing,
		PermissionRefused,
		Cancelled,
		RestartWindows,
		RestartDiyar,
		Failed
	}
	public enum UpdateRunFailure
	{
		None,
		DownloadFailed,
		FileRejected,
		NotEnoughSpace,
		BlockedBySecurity,
		NewerInstalled,
		SetupFailed,
		LaunchFailed
	}
	public enum UpdateRunAction
	{
		None,
		Download,
		Install,
		RestartDiyar
	}
	public sealed record UpdateTarget(string Version, Uri ReleasePageUri, Uri SetupUri, string Sha256, long Size);
	public sealed record UpdateRunStatus(UpdateRunState State, UpdateTarget? Target, long BytesReceived = 0L, UpdateRunFailure Failure = UpdateRunFailure.None, int? ExitCode = null, string? LogPath = null)
	{
		public static UpdateRunStatus Idle { get; } = new UpdateRunStatus(UpdateRunState.Idle, null, 0L);

		public bool IsBusy
		{
			get
			{
				UpdateRunState state = State;
				if ((uint)(state - 2) <= 1u || state == UpdateRunState.Installing)
				{
					return true;
				}
				return false;
			}
		}

		public UpdateRunAction Action => UpdateRunRules.ActionFor(this);
	}
	public static class UpdateRunRules
	{
		public const int VirusInfectedError = 225;

		public const int VirusDeletedError = 226;

		public const int CancelledError = 1223;

		public static UpdateRunAction ActionFor(UpdateRunStatus status)
		{
			if ((object)status.Target == null)
			{
				return UpdateRunAction.None;
			}
			UpdateRunAction result;
			switch (status.State)
			{
			case UpdateRunState.Available:
				result = UpdateRunAction.Download;
				break;
			case UpdateRunState.Ready:
			case UpdateRunState.PermissionRefused:
			case UpdateRunState.Cancelled:
				result = UpdateRunAction.Install;
				break;
			case UpdateRunState.RestartDiyar:
				result = UpdateRunAction.RestartDiyar;
				break;
			case UpdateRunState.Failed:
			{
				UpdateRunAction updateRunAction;
				switch (status.Failure)
				{
				case UpdateRunFailure.DownloadFailed:
				case UpdateRunFailure.FileRejected:
				case UpdateRunFailure.NotEnoughSpace:
					updateRunAction = UpdateRunAction.Download;
					break;
				case UpdateRunFailure.SetupFailed:
				case UpdateRunFailure.LaunchFailed:
					updateRunAction = UpdateRunAction.Install;
					break;
				default:
					updateRunAction = UpdateRunAction.None;
					break;
				}
				result = updateRunAction;
				break;
			}
			default:
				result = UpdateRunAction.None;
				break;
			}
			return result;
		}

		public static (UpdateRunState State, UpdateRunFailure Failure) AfterExit(int exitCode)
		{
			return SetupExitCodes.Classify(exitCode) switch
			{
				SetupOutcome.Succeeded => (State: UpdateRunState.RestartDiyar, Failure: UpdateRunFailure.None), 
				SetupOutcome.RestartRequired => (State: UpdateRunState.RestartWindows, Failure: UpdateRunFailure.None), 
				SetupOutcome.Cancelled => (State: UpdateRunState.Cancelled, Failure: UpdateRunFailure.None), 
				SetupOutcome.PermissionRefused => (State: UpdateRunState.PermissionRefused, Failure: UpdateRunFailure.None), 
				SetupOutcome.NewerInstalled => (State: UpdateRunState.Failed, Failure: UpdateRunFailure.NewerInstalled), 
				_ => (State: UpdateRunState.Failed, Failure: UpdateRunFailure.SetupFailed), 
			};
		}

		public static (UpdateRunState State, UpdateRunFailure Failure) AfterStartError(int win32Error)
		{
			switch (win32Error)
			{
			case 225:
			case 226:
				return (State: UpdateRunState.Failed, Failure: UpdateRunFailure.BlockedBySecurity);
			case 1223:
				return (State: UpdateRunState.PermissionRefused, Failure: UpdateRunFailure.None);
			default:
				return (State: UpdateRunState.Failed, Failure: UpdateRunFailure.LaunchFailed);
			}
		}
	}
	public sealed class UpdateRunMachine
	{
		private UpdateRunCarry? _carry;

		public UpdateRunStatus Status { get; private set; } = UpdateRunStatus.Idle;

		public bool Offer(UpdateTarget? target)
		{
			bool flag = Status.IsBusy;
			if (!flag)
			{
				UpdateRunState state = Status.State;
				bool flag2 = (uint)(state - 8) <= 1u;
				flag = flag2;
			}
			if (flag)
			{
				return false;
			}
			UpdateRunCarry carry = _carry;
			_carry = null;
			if ((object)target == null)
			{
				return Set(UpdateRunStatus.Idle);
			}
			if (Status.Target == target && Status.State != UpdateRunState.Idle)
			{
				return false;
			}
			if ((object)carry != null && string.Equals(carry.Version, target.Version, StringComparison.Ordinal))
			{
				return Set(new UpdateRunStatus(carry.State, target, 0L, carry.Failure, carry.ExitCode, carry.LogPath));
			}
			return Set(new UpdateRunStatus(UpdateRunState.Available, target, 0L));
		}

		public bool CarryOver(UpdateRunCarry carry)
		{
			if (Status.State != UpdateRunState.Idle || (object)Status.Target != null)
			{
				return false;
			}
			UpdateRunState state = carry.State;
			if (((uint)(state - 6) > 1u && state != UpdateRunState.Failed) || 1 == 0)
			{
				return false;
			}
			if (carry.State == UpdateRunState.Failed && carry.Failure != UpdateRunFailure.SetupFailed)
			{
				return false;
			}
			_carry = carry;
			return true;
		}

		public bool BeginDownload()
		{
			if (Status.Action == UpdateRunAction.Download)
			{
				return Set(Status with
				{
					State = UpdateRunState.Downloading,
					Failure = UpdateRunFailure.None,
					ExitCode = null
				});
			}
			return false;
		}

		public bool Progress(long bytesReceived)
		{
			if (Status.State == UpdateRunState.Downloading)
			{
				return Set(Status with
				{
					BytesReceived = bytesReceived
				});
			}
			return false;
		}

		public bool DownloadCancelled()
		{
			if (Status.State == UpdateRunState.Downloading)
			{
				return Set(Status with
				{
					State = UpdateRunState.Available
				});
			}
			return false;
		}

		public bool DownloadFailed(UpdateRunFailure failure)
		{
			if (Status.State == UpdateRunState.Downloading)
			{
				return Set(Status with
				{
					State = UpdateRunState.Failed,
					Failure = failure
				});
			}
			return false;
		}

		public bool BeginVerify()
		{
			if (Status.State == UpdateRunState.Downloading || (!Status.IsBusy && Status.Action == UpdateRunAction.Install))
			{
				return Set(Status with
				{
					State = UpdateRunState.Verifying,
					Failure = UpdateRunFailure.None,
					ExitCode = null
				});
			}
			return false;
		}

		public bool Verified()
		{
			if (Status.State == UpdateRunState.Verifying)
			{
				return Set(Status with
				{
					State = UpdateRunState.Ready,
					BytesReceived = Status.Target.Size
				});
			}
			return false;
		}

		public bool Rejected(UpdateRunFailure failure)
		{
			if (Status.State == UpdateRunState.Verifying)
			{
				return Set(Status with
				{
					State = UpdateRunState.Failed,
					Failure = failure,
					BytesReceived = 0L
				});
			}
			return false;
		}

		public bool BeginInstall(string logPath)
		{
			if (Status.State == UpdateRunState.Ready || (!Status.IsBusy && Status.Action == UpdateRunAction.Install))
			{
				return Set(Status with
				{
					State = UpdateRunState.Installing,
					Failure = UpdateRunFailure.None,
					ExitCode = null,
					LogPath = logPath
				});
			}
			return false;
		}

		public bool StartFailed(int win32Error)
		{
			if (Status.State != UpdateRunState.Installing)
			{
				return false;
			}
			var (state, failure) = UpdateRunRules.AfterStartError(win32Error);
			return Set(Status with
			{
				State = state,
				Failure = failure,
				ExitCode = win32Error
			});
		}

		public bool LaunchRefused()
		{
			if (Status.State == UpdateRunState.Installing)
			{
				return Set(Status with
				{
					State = UpdateRunState.Failed,
					Failure = UpdateRunFailure.LaunchFailed
				});
			}
			return false;
		}

		public bool SetupExited(int exitCode)
		{
			if (Status.State != UpdateRunState.Installing)
			{
				return false;
			}
			var (state, failure) = UpdateRunRules.AfterExit(exitCode);
			return Set(Status with
			{
				State = state,
				Failure = failure,
				ExitCode = exitCode
			});
		}

		public bool Fault()
		{
			return Status.State switch
			{
				UpdateRunState.Downloading => DownloadFailed(UpdateRunFailure.DownloadFailed), 
				UpdateRunState.Verifying => Rejected(UpdateRunFailure.DownloadFailed), 
				UpdateRunState.Installing => Set(Status with
				{
					State = UpdateRunState.Failed,
					Failure = UpdateRunFailure.LaunchFailed
				}), 
				_ => false, 
			};
		}

		public void ShowForVerification(UpdateRunStatus status)
		{
			Status = status;
		}

		private bool Set(UpdateRunStatus next)
		{
			if (next == Status)
			{
				return false;
			}
			Status = next;
			return true;
		}
	}
	public sealed record TrustedKey(string KeyId, string SubjectPublicKeyInfoBase64);
	public static class UpdateTrustRoots
	{
		public const string TestKeyIdPrefix = "diyar-test";

		public static IReadOnlyList<TrustedKey> Keys { get; } = new <>z__ReadOnlySingleElementList<TrustedKey>(new TrustedKey("diyar-2026-a", "MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAE2REJIzNHGcCdDpy7E9zWjHLiytP+/afOEc6xVplxcCrCG/X+oHHwg60YvqSPSs3f6tY0C2lJ3lejezt0gtUVPw=="));

		public static IReadOnlyList<string> TestFixturePublicKeys { get; } = new <>z__ReadOnlyArray<string>(new string[2] { "MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEhmEh7PucJ9gYPRL8YVT5xRAZEXAKduhhxTDkj5t+VGgePFuBDSpsWkxk6yxcy28byjhxZhGoEaVPrFpuzV4oyw==", "MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAEWT+2lzDB6TyNDpPVNUiFc5GVH3wKSBKR97U19Z/UDgGKPvKLRm3dp+Dp/BSXRMHxjb4xEmPiHX9O8SoYPzPP2Q==" });

		public static bool IsTestKey(string? keyId, string? subjectPublicKeyInfoBase64)
		{
			if (keyId == null || !keyId.StartsWith("diyar-test", StringComparison.OrdinalIgnoreCase))
			{
				if (subjectPublicKeyInfoBase64 != null)
				{
					return TestFixturePublicKeys.Contains(subjectPublicKeyInfoBase64, StringComparer.Ordinal);
				}
				return false;
			}
			return true;
		}
	}
}
namespace SmartInput.Core.Text
{
	public static class ParagraphDirectionPolicy
	{
		public const char RightToLeftMark = '\u200f';

		public const char RightToLeftEmbedding = '\u202b';

		public const string Prefix = "\u200f\u202b";

		public const int MaximumPrefixLength = 40;

		public const int MaximumPrefixTokens = 6;

		public static readonly char[] DirectionMarks = new char[11]
		{
			'\u200e', '\u200f', '\u202a', '\u202b', '\u202c', '\u202d', '\u202e', '\u2066', '\u2067', '\u2068',
			'\u2069'
		};

		public static string Mark(string text)
		{
			return "\u200f\u202b" + text;
		}

		public static bool StartsWithPrefix(string text)
		{
			return text.StartsWith("\u200f\u202b", StringComparison.Ordinal);
		}

		public static bool IsDirectionMark(char c)
		{
			switch (c)
			{
			case '\u200e':
			case '\u200f':
			case '\u202a':
			case '\u202b':
			case '\u202c':
			case '\u202d':
			case '\u202e':
			case '\u2066':
			case '\u2067':
			case '\u2068':
			case '\u2069':
				return true;
			default:
				return false;
			}
		}

		public static int StartOfTrailingMarkRun(ReadOnlySpan<char> text)
		{
			int num = text.Length;
			while (num > 0 && IsDirectionMark(text[num - 1]))
			{
				num--;
			}
			return num;
		}

		public static ParagraphStartRewrite EvaluateRewrite(string paragraphStart)
		{
			if (paragraphStart.Length == 0)
			{
				return ParagraphStartRewrite.Refuse("empty");
			}
			if (paragraphStart.Length > 40)
			{
				return ParagraphStartRewrite.Refuse("too-long");
			}
			if (!paragraphStart.EndsWith(' ') || paragraphStart.StartsWith(' ') || paragraphStart.Contains("  ", StringComparison.Ordinal))
			{
				return ParagraphStartRewrite.Refuse("spacing");
			}
			for (int i = 0; i < paragraphStart.Length; i++)
			{
				bool flag;
				switch (paragraphStart[i])
				{
				case ' ':
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
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
					flag = true;
					break;
				default:
					flag = false;
					break;
				}
				if (!flag)
				{
					return ParagraphStartRewrite.Refuse("character");
				}
			}
			string[] array = paragraphStart.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (array.Length > 6)
			{
				return ParagraphStartRewrite.Refuse("too-many-words");
			}
			if (array[0].All(char.IsAsciiDigit))
			{
				return ParagraphStartRewrite.Refuse("list-number");
			}
			return ParagraphStartRewrite.Allow;
		}
	}
	public readonly record struct ParagraphStartRewrite(bool Allowed, string Reason)
	{
		public static ParagraphStartRewrite Allow { get; } = new ParagraphStartRewrite(Allowed: true, "allowed");

		public static ParagraphStartRewrite Refuse(string reason)
		{
			return new ParagraphStartRewrite(Allowed: false, reason);
		}
	}
	public static class PersianAmountFormatter
	{
		public const char GroupSeparator = '٬';

		public const char DecimalSeparator = '٫';

		public static bool TryExtractTrailing(string textBeforeCurrency, out string source, out string spacing, out string formatted)
		{
			return TryExtractTrailing(textBeforeCurrency, requireWordBoundary: false, out source, out spacing, out formatted);
		}

		public static bool TryExtractTrailing(string textBeforeCurrency, bool requireWordBoundary, out string source, out string spacing, out string formatted)
		{
			source = string.Empty;
			spacing = string.Empty;
			formatted = string.Empty;
			if (textBeforeCurrency.Length == 0)
			{
				return false;
			}
			int num = textBeforeCurrency.Length;
			while (num > 0 && textBeforeCurrency[num - 1] == ' ')
			{
				num--;
			}
			if (num == textBeforeCurrency.Length)
			{
				return false;
			}
			int num2 = num;
			while (num2 > 0 && IsAmountCharacter(textBeforeCurrency[num2 - 1]))
			{
				num2--;
			}
			if (num2 == num)
			{
				return false;
			}
			if (requireWordBoundary && !StartsAtWordBoundary(textBeforeCurrency, num2))
			{
				return false;
			}
			int num3 = num2;
			string text = textBeforeCurrency.Substring(num3, num - num3);
			if (!TryFormat(text, out formatted))
			{
				formatted = string.Empty;
				return false;
			}
			source = text;
			spacing = textBeforeCurrency.Substring(num);
			return true;
		}

		public static bool TryFormat(string value, out string formatted)
		{
			formatted = string.Empty;
			if (string.IsNullOrWhiteSpace(value))
			{
				return false;
			}
			string text = value.Trim();
			string text2 = string.Empty;
			char c = text[0];
			if ((c == '+' || c == '-' || c == '−') ? true : false)
			{
				text2 = text[0].ToString();
				text = text.Substring(1);
			}
			StringBuilder stringBuilder = new StringBuilder(text.Length);
			StringBuilder stringBuilder2 = new StringBuilder();
			bool flag = false;
			string text3 = text;
			foreach (char c2 in text3)
			{
				if (TryGetDigit(c2, out var digit))
				{
					(flag ? stringBuilder2 : stringBuilder).Append(digit);
					continue;
				}
				bool flag2 = !flag;
				if (flag2)
				{
					bool flag3 = ((c2 == ',' || c2 == '٬') ? true : false);
					flag2 = flag3;
				}
				if (!flag2)
				{
					flag2 = !flag;
					if (flag2)
					{
						bool flag3 = ((c2 == '.' || c2 == '٫') ? true : false);
						flag2 = flag3;
					}
					if (!flag2)
					{
						return false;
					}
					flag = true;
				}
			}
			if (stringBuilder.Length == 0 || (flag && stringBuilder2.Length == 0))
			{
				return false;
			}
			string value2 = GroupInteger(stringBuilder.ToString());
			formatted = text2 + ToPersianDigits(value2);
			if (flag)
			{
				formatted = formatted + "٫" + ToPersianDigits(stringBuilder2.ToString());
			}
			return true;
		}

		private static string GroupInteger(string digits)
		{
			int num = digits.Length % 3;
			if (num == 0)
			{
				num = Math.Min(3, digits.Length);
			}
			StringBuilder stringBuilder = new StringBuilder(digits.Length + digits.Length / 3);
			stringBuilder.Append(digits, 0, num);
			for (int i = num; i < digits.Length; i += 3)
			{
				stringBuilder.Append('٬');
				stringBuilder.Append(digits, i, 3);
			}
			return stringBuilder.ToString();
		}

		private static string ToPersianDigits(string value)
		{
			char[] array = value.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				char c = array[i];
				if (c >= '0' && c <= '9')
				{
					array[i] = (char)(1776 + array[i] - 48);
				}
			}
			return new string(array);
		}

		private static bool TryGetDigit(char character, out char digit)
		{
			if (character >= '0' && character <= '9')
			{
				digit = character;
				return true;
			}
			if (character >= '۰' && character <= '۹')
			{
				digit = (char)(48 + character - 1776);
				return true;
			}
			if (character >= '٠' && character <= '٩')
			{
				digit = (char)(48 + character - 1632);
				return true;
			}
			digit = '\0';
			return false;
		}

		public static bool StartsAtWordBoundary(string text, int index)
		{
			if (index <= 0)
			{
				return true;
			}
			char c = text[index - 1];
			bool flag = char.IsWhiteSpace(c);
			if (!flag)
			{
				bool flag2;
				switch (c)
				{
				case '"':
				case '(':
				case '[':
				case '{':
				case '«':
				case '“':
					flag2 = true;
					break;
				default:
					flag2 = false;
					break;
				}
				flag = flag2;
			}
			if (!flag)
			{
				return IsDirectionMark(c);
			}
			return true;
		}

		private static bool IsDirectionMark(char character)
		{
			switch (character)
			{
			case '\u200e':
			case '\u200f':
			case '\u202a':
			case '\u202b':
			case '\u202c':
			case '\u202d':
			case '\u202e':
			case '\u2066':
			case '\u2067':
			case '\u2068':
			case '\u2069':
				return true;
			default:
				return false;
			}
		}

		private static bool IsAmountCharacter(char character)
		{
			bool flag;
			switch (character)
			{
			case '+':
			case ',':
			case '-':
			case '.':
			case '٫':
			case '٬':
			case '−':
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			if (!flag && (character < '0' || character > '9') && (character < '۰' || character > '۹'))
			{
				if (character >= '٠')
				{
					return character <= '٩';
				}
				return false;
			}
			return true;
		}
	}
	public static class PersianPunctuation
	{
		public const char Comma = '،';

		public const char Semicolon = '؛';

		public const char QuestionMark = '؟';

		public const char PercentSign = '٪';

		private static readonly IReadOnlyDictionary<char, char> LocalizedCharacters = new Dictionary<char, char>
		{
			[','] = '،',
			[';'] = '؛',
			['?'] = '؟',
			['%'] = '٪'
		};

		private static readonly IReadOnlyDictionary<char, char> AsciiCharacters = LocalizedCharacters.ToDictionary((KeyValuePair<char, char> pair) => pair.Value, (KeyValuePair<char, char> pair) => pair.Key);

		public static string Localize(string value)
		{
			return Replace(value, LocalizedCharacters);
		}

		public static string Delocalize(string value)
		{
			return Replace(value, AsciiCharacters);
		}

		public static bool TryLocalize(char value, out char localized)
		{
			return LocalizedCharacters.TryGetValue(value, out localized);
		}

		public static bool IsAsciiLocalizable(char value)
		{
			return LocalizedCharacters.ContainsKey(value);
		}

		private static string Replace(string value, IReadOnlyDictionary<char, char> replacements)
		{
			StringBuilder stringBuilder = null;
			for (int i = 0; i < value.Length; i++)
			{
				if (!replacements.TryGetValue(value[i], out var value2))
				{
					stringBuilder?.Append(value[i]);
					continue;
				}
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(value.Length).Append(value, 0, i);
				}
				stringBuilder.Append(value2);
			}
			return stringBuilder?.ToString() ?? value;
		}
	}
	public enum PunctuationContextLanguage
	{
		Unknown,
		English,
		Persian
	}
	public static class PunctuationContextPolicy
	{
		public static PunctuationContextLanguage WordBeforeCaretLanguage(string knownTextBeforeCaret)
		{
			return WordBeforeCaretLanguage(knownTextBeforeCaret, textStartsAtWordBoundary: true);
		}

		public static PunctuationContextLanguage WordBeforeCaretLanguage(string knownTextBeforeCaret, bool textStartsAtWordBoundary)
		{
			string text = RemoveDirectionMarks(knownTextBeforeCaret ?? string.Empty);
			int num = text.Length;
			while (num > 0 && char.IsWhiteSpace(text[num - 1]))
			{
				num--;
			}
			int num2 = num;
			while (num2 > 0 && !char.IsWhiteSpace(text[num2 - 1]))
			{
				num2--;
			}
			if (num2 == num)
			{
				return PunctuationContextLanguage.Unknown;
			}
			bool flag = false;
			for (int i = num2; i < num; i++)
			{
				if (IsLatinLetter(text[i]))
				{
					return PunctuationContextLanguage.English;
				}
				flag |= IsPersianLetter(text[i]);
			}
			if (!flag || !((num2 > 0) | textStartsAtWordBoundary))
			{
				return PunctuationContextLanguage.Unknown;
			}
			return PunctuationContextLanguage.Persian;
		}

		public static string LastWord(string text)
		{
			string text2 = RemoveDirectionMarks(text ?? string.Empty).TrimEnd();
			int num = text2.Length;
			while (num > 0 && !char.IsWhiteSpace(text2[num - 1]))
			{
				num--;
			}
			return text2.Substring(num);
		}

		public static bool IsDirectionMark(char value)
		{
			if (!ParagraphDirectionPolicy.IsDirectionMark(value))
			{
				return value == '\u061c';
			}
			return true;
		}

		private static string RemoveDirectionMarks(string text)
		{
			for (int i = 0; i < text.Length; i++)
			{
				if (IsDirectionMark(text[i]))
				{
					return new string(text.Where((char c) => !IsDirectionMark(c)).ToArray());
				}
			}
			return text;
		}

		private static bool IsLatinLetter(char value)
		{
			bool flag;
			switch (value)
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
				flag = true;
				break;
			default:
				flag = false;
				break;
			}
			if (!flag)
			{
				if (value >= 'À' && value <= 'ɏ')
				{
					return char.IsLetter(value);
				}
				return false;
			}
			return true;
		}

		private static bool IsPersianLetter(char value)
		{
			if (value >= 'ﭐ')
			{
				if (value >= 'ﹰ')
				{
					if (value <= '\ufeff')
					{
						goto IL_0034;
					}
				}
				else if (value <= '﷿')
				{
					goto IL_0034;
				}
			}
			else if (value >= '\u0600' && value <= 'ۿ')
			{
				goto IL_0034;
			}
			bool flag = false;
			goto IL_003a;
			IL_0034:
			flag = true;
			goto IL_003a;
			IL_003a:
			if (flag)
			{
				return char.IsLetter(value);
			}
			return false;
		}
	}
}
namespace SmartInput.Core.Text.Localization
{
	public static class InterfaceFormat
	{
		public const string EnglishDatePattern = "yyyy-MM-dd HH:mm";

		public const string PersianGroupSeparator = "٬";

		private static readonly PersianCalendar Jalali = new PersianCalendar();

		private static readonly NumberFormatInfo PersianNumbers = NumberFormatInfo.ReadOnly(new NumberFormatInfo
		{
			NumberGroupSeparator = "٬",
			NumberDecimalSeparator = "٫",
			NegativeSign = "-"
		});

		public static string Date(DateTime local, UiLanguage language)
		{
			if (language != UiLanguage.Persian)
			{
				return local.ToString("yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture);
			}
			IFormatProvider invariantCulture;
			if (local < Jalali.MinSupportedDateTime || local > Jalali.MaxSupportedDateTime)
			{
				invariantCulture = CultureInfo.InvariantCulture;
				IFormatProvider provider = invariantCulture;
				DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(4, 5, invariantCulture);
				handler.AppendFormatted(local.Year, "0000");
				handler.AppendLiteral("/");
				handler.AppendFormatted(local.Month, "00");
				handler.AppendLiteral("/");
				handler.AppendFormatted(local.Day, "00");
				handler.AppendLiteral(" ");
				handler.AppendFormatted(local.Hour, "00");
				handler.AppendLiteral(":");
				handler.AppendFormatted(local.Minute, "00");
				return string.Create(provider, ref handler);
			}
			invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider provider2 = invariantCulture;
			DefaultInterpolatedStringHandler handler2 = new DefaultInterpolatedStringHandler(4, 5, invariantCulture);
			handler2.AppendFormatted(Jalali.GetYear(local), "0000");
			handler2.AppendLiteral("/");
			handler2.AppendFormatted(Jalali.GetMonth(local), "00");
			handler2.AppendLiteral("/");
			handler2.AppendFormatted(Jalali.GetDayOfMonth(local), "00");
			handler2.AppendLiteral(" ");
			handler2.AppendFormatted(local.Hour, "00");
			handler2.AppendLiteral(":");
			handler2.AppendFormatted(local.Minute, "00");
			return string.Create(provider2, ref handler2);
		}

		public static string DateValue(DateTime local, UiLanguage language)
		{
			string text = Date(local, language);
			if (language != UiLanguage.Persian)
			{
				return text;
			}
			return $"{'\u2067'}{text}{'\u2069'}";
		}

		public static string Count(long value, UiLanguage language)
		{
			IFormatProvider formatProvider;
			if (language != UiLanguage.Persian)
			{
				IFormatProvider currentCulture = CultureInfo.CurrentCulture;
				formatProvider = currentCulture;
			}
			else
			{
				IFormatProvider currentCulture = PersianNumbers;
				formatProvider = currentCulture;
			}
			return value.ToString("N0", formatProvider);
		}
	}
	public enum MessageKey
	{
		StartupStartsHidden,
		StartupThroughInstaller,
		StartupOff,
		StartupOlderInstallation,
		StartupStatusUnreadable,
		StartupEnableFailed,
		StartupDisableNeedsPermission,
		StartupNotAccepted,
		StartupEntryStillActive,
		ShortcutsNoneRegistered,
		ShortcutsOneNotRegistered,
		ShortcutsSomeNotRegistered,
		ShortcutsOthersWork,
		ShortcutsChooseDifferentKeys,
		ShortcutsCauseMixed,
		ShortcutCauseTaken,
		ShortcutsCauseTaken,
		ShortcutCauseDuplicate,
		ShortcutsCauseDuplicate,
		ShortcutCauseInvalid,
		ShortcutsCauseInvalid,
		UpdateUrlInvalid,
		UpdateInstalledVersionInvalid,
		UpdateHttpStatus,
		UpdateFormatUnsupported,
		UpdateNoValidRelease,
		UpdateUpToDate,
		UpdateAvailable,
		UpdateTimedOut,
		UpdateCheckFailed,
		UpdateManifestUnsigned,
		UpdateManifestSignatureInvalid,
		UpdateManifestExpired,
		UpdateManifestReplayed,
		TranslationBusy,
		TranslationAlreadyRunning,
		TranslationOff,
		TranslationProtectedField,
		TranslationSelectText,
		TranslationSelectionTooLong,
		TranslationAddAzureKey,
		TranslationSetUpLocalModel,
		TranslationUnsafeFormat,
		TranslationSelectionChanged,
		TranslationDone,
		TranslationFailed,
		TranslationUndoOff,
		TranslationNothingRecentToUndo,
		TranslationRestored,
		CloudTranslationUnavailable,
		LocalTranslationUnavailable,
		NoTranslationToUndo,
		AzureConfigured,
		AzureAddKey,
		AzureRejectedKey,
		AzureQuotaReached,
		AzureHttpStatus,
		AzureSaveKeyFirst,
		AzureConnectionVerified,
		AzureUnreachable,
		AzureNotVerified,
		AzureRegionInvalid,
		LocalModelReady,
		LocalModelSetupRequired,
		LocalRuntimeAccessDenied,
		LocalModelCatalogUnavailable,
		LocalModelUnavailable,
		LanguageEnglish,
		LanguagePersian,
		LanguageArabic,
		LanguageUrdu,
		LanguageFrench,
		LanguageGerman,
		LanguageSpanish,
		LanguageTurkish,
		LanguageRussian,
		LanguageChineseSimplified,
		LanguageJapanese,
		LanguageKorean,
		LanguageHindi,
		ModelBalanced,
		ModelBalancedSize,
		ModelBalancedSummary,
		ModelCompact,
		ModelCompactSize,
		ModelCompactSummary,
		ModelQuality,
		ModelQualitySize,
		ModelQualitySummary,
		LayoutPersianStandard,
		LayoutPersian,
		LayoutEnglishUs,
		LayoutEnglishUsInternational,
		LayoutNotInstalledByWindows,
		LayoutInstallUnsupported,
		LayoutInstalled,
		LayoutAddedAfterSignIn,
		FontScopeWebFallback,
		FontScopeEditor,
		FontScopeMessages,
		FontScopeAllProfiles,
		FontScopeNewEmail,
		FontScopeNewDocuments,
		FontStatusNotInstalled,
		FontStatusOpenAppOnce,
		FontStatusManualSetup,
		FontStatusFailed,
		FontStatusReady,
		FontStatusApplied,
		FontStatusRestored,
		FontStatusNoBackup,
		FontStatusInvalidJson,
		FontStatusAppliedToProfiles,
		FontStatusReadyProfiles,
		FontStatusReadyStopBackground,
		FontStatusCloseAllWindows,
		FontStatusClose,
		FontStatusAppliedRestart,
		FontStatusRestoredRestart,
		FontStatusAppliedNewDocuments,
		FontStatusCloseWord,
		UnreadableFileCopyKept,
		UnreadableFileBlocked,
		UnreadableEmptyFile,
		UnreadableNoEntriesList,
		UnreadableNoCandidatesList,
		UnreadableNewerFormat,
		ConvertedAndAdded,
		ConvertedAlreadyPersonal,
		ConvertedAlreadyBuiltIn,
		ConvertedKeptEnglishForSession,
		ConvertedAndForgotEnglish,
		ConvertedNotAdded,
		ConvertedNotSaved,
		ConvertedBack,
		Converted,
		WordLanguageUnknownNotAdded,
		WordNotAddedNotSaved,
		WordAddedToPersonal,
		WordAlreadyPersonal,
		WordAlreadyBuiltIn,
		WordNotAddedBecause,
		WordRejectedNotAdded,
		DictionaryAdded,
		DictionaryAlreadyPersonal,
		DictionaryAlreadyBuiltIn,
		DictionaryRejected,
		TermLanguageUnknown,
		TermLanguageUnclear,
		TermEmpty,
		TermTooLong,
		TermHasControlCharacter,
		TermHasSpace,
		TermIsLink,
		ReviewKeptInQueue,
		ReviewQueueNotUpdated,
		ReviewLanguageNotSupported,
		ImportUnsupportedFile,
		ImportJsonNoEntries,
		ImportJsonError,
		ImportHeaderError,
		ImportCsvNoHeader,
		ImportCsvNoTermColumn,
		ImportLineError,
		ImportLineMetadataInvalid,
		ImportLineLanguageUnclear,
		ImportLineLanguageUnclearText,
		ImportLineRejected,
		ExportUnsupportedFile,
		ReviewQueueNotSaved,
		GesturePressModifierAndKey,
		GestureIncludeModifier,
		GestureRequired,
		GestureInvalid,
		GestureNeedsModifierAndKey,
		NothingWasChanged,
		SelectWordFirst,
		SelectOneWord,
		WordHasDigits,
		WordIsTechnical,
		WordMixesScripts,
		WordWouldNotChange,
		NoWordToConvert,
		LastWordHasSpace,
		WordHasNoLetters,
		NoPersianMapping,
		NoEnglishMapping,
		NoLatinMapping,
		KeyHasNoPersianLetter,
		LetterNotOnPersianKeys,
		LetterAmbiguousBack,
		SelectedWordUnavailable,
		CancelledAfterShortcut,
		SelectedWordBusy,
		ConversionNotConfirmed,
		EditorRefusedChange,
		TextMayHaveChanged,
		NoWordBeforeCaret,
		TextIsSelected,
		ProtectedFieldNothingRead,
		FieldReadOnly,
		FinishComposing,
		FieldUnsupported,
		HostUnsupported,
		BrokerNoAnswer,
		NothingToUndoHere,
		EditedSinceCorrection,
		OtherFieldCorrection,
		OriginalSentUnconfirmed,
		RestoredAndWithdrawn,
		RestoredDictionaryNotUpdated,
		RestoredOriginal,
		ConversionResultUnconfirmed,
		HotkeyEditCommandsOff,
		PreviousWordTypeFirst,
		PreviousWordNeedsAutomatic,
		FieldProtected,
		SelectionNotReadable,
		NonDictionaryWordsUnavailable,
		SelectionReadBusy,
		EditorNoAnswer,
		SelectionReadFailed,
		TextServiceMissing,
		ManualCorrectionCouldNotStart,
		ManualChordsMustDiffer,
		ManualSettingsNotPublished,
		TypingPaused,
		TypingResumed,
		TrayPause,
		TrayResume,
		TrayPausedTooltip,
		TrayOpen,
		TrayCheckForUpdates,
		TrayExit,
		TrayUpdateTitle,
		TrayUpdateText,
		EntryLanguageNeutral,
		EntryLanguageUnknown,
		TranslationTookTooLong,
		TranslationCancelledNothingChanged,
		TranslationNoConfirmedToUndo,
		TranslationClipboardEmpty,
		TranslationClipboardWriteFailed,
		TranslationServiceNoAnswer,
		TranslationServiceUnreachable,
		TranslationClipboardTooLong,
		TranslationCopiedToClipboard,
		TranslationSelectionUnreadable,
		TranslationEditorUnsupported,
		TranslationMultiLineUnsupported,
		TranslationPreviousCommandBusy,
		TranslationReadTimedOut,
		TranslationReadFailed,
		TranslationWriteTimedOut,
		TranslationWriteFailed,
		TranslationUnconfirmed,
		TranslationRestoreUnconfirmed,
		TranslationClipboardUnavailable,
		TranslationUndoMoved,
		TranslationUndoContradicted,
		TranslationUndoClipboardOff,
		TranslationFocusChanged,
		TranslationControlRefused,
		AzureTemporarilyUnavailable,
		AzureTryAgainIn,
		LanguageAutomatic,
		LocalModelAnswerCutOff,
		TrayUpdateClickText,
		SettingsFileHoldsNoSettings,
		SettingsFileUnreadable,
		SettingsFileKeptAs,
		SettingsFileNotSetAside,
		FontStatusWrittenToProfiles,
		FontStatusWrittenRestart,
		FontStatusReverted,
		FontStatusFontNotInstalled,
		FontStatusFontNotInstalledUse,
		FontCheckTitle,
		FontCheckIntro
	}
	public static class MessageText
	{
		public const string FontCheckPersianSample = "سلام! این متن فارسی باید با قلم انتخاب\u200cشده دیده شود. ۱۲۳۴۵۶۷۸۹۰";

		public const string FontCheckLatinSample = "The quick brown fox jumps over the lazy dog. 1234567890";

		private static readonly Dictionary<MessageKey, string> English = new Dictionary<MessageKey, string>
		{
			[MessageKey.StartupStartsHidden] = "Starts hidden in the notification area when you sign in.",
			[MessageKey.StartupThroughInstaller] = "Starts with Windows through the installer startup option.",
			[MessageKey.StartupOff] = "Does not start with Windows.",
			[MessageKey.StartupOlderInstallation] = "The startup entry points to an older installation. Turn startup on to repair it.",
			[MessageKey.StartupStatusUnreadable] = "Windows startup status could not be read for this user.",
			[MessageKey.StartupEnableFailed] = "Diyar could not enable Windows startup for this user.",
			[MessageKey.StartupDisableNeedsPermission] = "Windows startup is managed by the installer and could not be disabled without permission.",
			[MessageKey.StartupNotAccepted] = "Windows did not accept the startup registration.",
			[MessageKey.StartupEntryStillActive] = "A Windows or installer startup entry is still active.",
			[MessageKey.ShortcutsNoneRegistered] = "No keyboard shortcut could be registered: {0}.",
			[MessageKey.ShortcutsOneNotRegistered] = "One shortcut could not be registered: {0}.",
			[MessageKey.ShortcutsSomeNotRegistered] = "{0} shortcuts could not be registered: {1}.",
			[MessageKey.ShortcutsOthersWork] = "The other shortcuts are working.",
			[MessageKey.ShortcutsChooseDifferentKeys] = "Choose different keys in Settings > Shortcuts.",
			[MessageKey.ShortcutsCauseMixed] = "They are either already in use or not a valid combination.",
			[MessageKey.ShortcutCauseTaken] = "It is used by another application.",
			[MessageKey.ShortcutsCauseTaken] = "They are used by other applications.",
			[MessageKey.ShortcutCauseDuplicate] = "It repeats another Diyar shortcut.",
			[MessageKey.ShortcutsCauseDuplicate] = "They repeat other Diyar shortcuts.",
			[MessageKey.ShortcutCauseInvalid] = "It is not a valid key combination.",
			[MessageKey.ShortcutsCauseInvalid] = "They are not valid key combinations.",
			[MessageKey.UpdateUrlInvalid] = "Enter a complete HTTPS update URL.",
			[MessageKey.UpdateInstalledVersionInvalid] = "The installed application version is invalid.",
			[MessageKey.UpdateHttpStatus] = "The update service returned HTTP {0}.",
			[MessageKey.UpdateFormatUnsupported] = "The update information format is not supported.",
			[MessageKey.UpdateNoValidRelease] = "No valid release is listed in the update service.",
			[MessageKey.UpdateUpToDate] = "Diyar {0} is up to date.",
			[MessageKey.UpdateAvailable] = "Diyar {0} is available.",
			[MessageKey.UpdateTimedOut] = "The update check timed out.",
			[MessageKey.UpdateCheckFailed] = "Updates could not be checked right now.",
			[MessageKey.UpdateManifestUnsigned] = "The update information is not signed and cannot be trusted.",
			[MessageKey.UpdateManifestSignatureInvalid] = "The update information could not be verified.",
			[MessageKey.UpdateManifestExpired] = "The update information is out of date. Try again later.",
			[MessageKey.UpdateManifestReplayed] = "The update information is older than what Diyar has already seen.",
			[MessageKey.TranslationBusy] = "Translation is busy",
			[MessageKey.TranslationAlreadyRunning] = "Translation is already running",
			[MessageKey.TranslationOff] = "Translation is off",
			[MessageKey.TranslationProtectedField] = "Translation is unavailable in protected fields",
			[MessageKey.TranslationSelectText] = "Select text to translate",
			[MessageKey.TranslationSelectionTooLong] = "Selection is longer than {0} characters",
			[MessageKey.TranslationAddAzureKey] = "Add your Azure Translator API key in Settings",
			[MessageKey.TranslationSetUpLocalModel] = "Set up the local model in Settings",
			[MessageKey.TranslationUnsafeFormat] = "The model returned an unsafe translation format",
			[MessageKey.TranslationSelectionChanged] = "Selection changed; original text was kept",
			[MessageKey.TranslationDone] = "Translated to {0}",
			[MessageKey.TranslationFailed] = "Translation failed",
			[MessageKey.TranslationUndoOff] = "Translation undo is disabled",
			[MessageKey.TranslationNothingRecentToUndo] = "No recent translation to undo",
			[MessageKey.TranslationRestored] = "Translation restored to the original text",
			[MessageKey.CloudTranslationUnavailable] = "Cloud translation is unavailable",
			[MessageKey.LocalTranslationUnavailable] = "Local translation is unavailable",
			[MessageKey.NoTranslationToUndo] = "No translation to undo",
			[MessageKey.AzureConfigured] = "Azure Translator is configured",
			[MessageKey.AzureAddKey] = "Add your Azure Translator API key",
			[MessageKey.AzureRejectedKey] = "Azure Translator rejected the API key or region",
			[MessageKey.AzureQuotaReached] = "Azure Translator quota or rate limit reached",
			[MessageKey.AzureHttpStatus] = "Azure Translator returned HTTP {0}",
			[MessageKey.AzureSaveKeyFirst] = "Save an Azure Translator API key first",
			[MessageKey.AzureConnectionVerified] = "Connection verified. The API key and region are valid.",
			[MessageKey.AzureUnreachable] = "Azure could not be reached. Check the internet connection.",
			[MessageKey.AzureNotVerified] = "The Azure connection could not be verified.",
			[MessageKey.AzureRegionInvalid] = "Enter {0} or the Azure location code, for example {1}.",
			[MessageKey.LocalModelReady] = "Ready for offline translation",
			[MessageKey.LocalModelSetupRequired] = "Model setup required",
			[MessageKey.LocalRuntimeAccessDenied] = "Local AI runtime access was denied",
			[MessageKey.LocalModelCatalogUnavailable] = "Local model catalog is unavailable",
			[MessageKey.LocalModelUnavailable] = "Local AI model is unavailable",
			[MessageKey.LanguageEnglish] = "English",
			[MessageKey.LanguagePersian] = "Persian / Farsi",
			[MessageKey.LanguageArabic] = "Arabic",
			[MessageKey.LanguageUrdu] = "Urdu",
			[MessageKey.LanguageFrench] = "French",
			[MessageKey.LanguageGerman] = "German",
			[MessageKey.LanguageSpanish] = "Spanish",
			[MessageKey.LanguageTurkish] = "Turkish",
			[MessageKey.LanguageRussian] = "Russian",
			[MessageKey.LanguageChineseSimplified] = "Chinese (Simplified)",
			[MessageKey.LanguageJapanese] = "Japanese",
			[MessageKey.LanguageKorean] = "Korean",
			[MessageKey.LanguageHindi] = "Hindi",
			[MessageKey.ModelBalanced] = "Balanced",
			[MessageKey.ModelBalancedSize] = "about 1.8 GB",
			[MessageKey.ModelBalancedSummary] = "Recommended quality and speed",
			[MessageKey.ModelCompact] = "Compact",
			[MessageKey.ModelCompactSize] = "about 0.8 GB",
			[MessageKey.ModelCompactSummary] = "Faster with lower translation quality",
			[MessageKey.ModelQuality] = "Quality",
			[MessageKey.ModelQualitySize] = "about 6.2 GB",
			[MessageKey.ModelQualitySummary] = "Higher quality with greater hardware demand",
			[MessageKey.LayoutPersianStandard] = "Persian (Standard)",
			[MessageKey.LayoutPersian] = "Persian",
			[MessageKey.LayoutEnglishUs] = "English (United States) - US",
			[MessageKey.LayoutEnglishUsInternational] = "English (United States) - United States-International",
			[MessageKey.LayoutNotInstalledByWindows] = "Windows did not install {0}. Add it in Settings > Time & language > Language & region.",
			[MessageKey.LayoutInstallUnsupported] = "This version of Windows cannot install layouts from Diyar. Add {0} in Settings > Time & language > Language & region.",
			[MessageKey.LayoutInstalled] = "{0} is installed.",
			[MessageKey.LayoutAddedAfterSignIn] = "{0} was added. It appears after you sign out and back in.",
			[MessageKey.FontScopeWebFallback] = "Pages without their own font",
			[MessageKey.FontScopeEditor] = "Editor font",
			[MessageKey.FontScopeMessages] = "Message fonts",
			[MessageKey.FontScopeAllProfiles] = "All profiles",
			[MessageKey.FontScopeNewEmail] = "New email messages",
			[MessageKey.FontScopeNewDocuments] = "New documents",
			[MessageKey.FontStatusNotInstalled] = "Not installed",
			[MessageKey.FontStatusOpenAppOnce] = "Open app once",
			[MessageKey.FontStatusManualSetup] = "Manual setup",
			[MessageKey.FontStatusFailed] = "Failed",
			[MessageKey.FontStatusReady] = "Ready",
			[MessageKey.FontStatusApplied] = "Applied",
			[MessageKey.FontStatusRestored] = "Restored",
			[MessageKey.FontStatusNoBackup] = "No backup available",
			[MessageKey.FontStatusInvalidJson] = "Settings file is not valid JSON",
			[MessageKey.FontStatusAppliedToProfiles] = "Applied to {0} profile(s)",
			[MessageKey.FontStatusReadyProfiles] = "Ready - {0} profile(s)",
			[MessageKey.FontStatusReadyStopBackground] = "Ready - {0} profile(s); background {1} will be stopped",
			[MessageKey.FontStatusCloseAllWindows] = "Close all {0} windows",
			[MessageKey.FontStatusClose] = "Close {0}",
			[MessageKey.FontStatusAppliedRestart] = "Applied to {0} profile(s) - restart {1}",
			[MessageKey.FontStatusRestoredRestart] = "Restored - restart {0}",
			[MessageKey.FontStatusAppliedNewDocuments] = "Applied to new documents",
			[MessageKey.FontStatusCloseWord] = "Close Word",
			[MessageKey.UnreadableFileCopyKept] = "{0} could not be read ({1}). A copy was kept as {2}.",
			[MessageKey.UnreadableFileBlocked] = "{0} could not be read ({1}) and a copy could not be kept, so it will not be changed: adding, editing or deleting words is blocked until a copy can be kept. Free disk space or fix the folder's permissions, then retry; the file itself has not been touched.",
			[MessageKey.UnreadableEmptyFile] = "empty file",
			[MessageKey.UnreadableNoEntriesList] = "no entries list",
			[MessageKey.UnreadableNoCandidatesList] = "no candidates list",
			[MessageKey.UnreadableNewerFormat] = "format version {0} is newer than this app understands",
			[MessageKey.ConvertedAndAdded] = "Converted; '{0}' was added to your personal dictionary.",
			[MessageKey.ConvertedAlreadyPersonal] = "Converted; the word is already in your personal dictionary.",
			[MessageKey.ConvertedAlreadyBuiltIn] = "Converted; the word is already available in the built-in dictionary.",
			[MessageKey.ConvertedKeptEnglishForSession] = "Converted; '{0}' stays English until Diyar restarts.",
			[MessageKey.ConvertedAndForgotEnglish] = "Converted; '{0}' is no longer kept English, so it converts again.",
			[MessageKey.ConvertedNotAdded] = "Converted; the word could not be added to the dictionary.",
			[MessageKey.ConvertedNotSaved] = "Converted, but not saved.",
			[MessageKey.ConvertedBack] = "Converted back.",
			[MessageKey.Converted] = "Converted.",
			[MessageKey.WordLanguageUnknownNotAdded] = "Can't tell this word's language from its letters, so it was not added.",
			[MessageKey.WordNotAddedNotSaved] = "Not added: the dictionary could not be saved ({0}). Your dictionary and your text are unchanged.",
			[MessageKey.WordAddedToPersonal] = "'{0}' was added to your personal dictionary.",
			[MessageKey.WordAlreadyPersonal] = "Already in your personal dictionary.",
			[MessageKey.WordAlreadyBuiltIn] = "Already available in the built-in dictionary.",
			[MessageKey.WordNotAddedBecause] = "Not added: {0}",
			[MessageKey.WordRejectedNotAdded] = "Not added: the word was rejected.",
			[MessageKey.DictionaryAdded] = "{0} added",
			[MessageKey.DictionaryAlreadyPersonal] = "{0} already in your personal dictionary",
			[MessageKey.DictionaryAlreadyBuiltIn] = "{0} already available in the built-in dictionary",
			[MessageKey.DictionaryRejected] = "{0} rejected",
			[MessageKey.TermLanguageUnknown] = "{0}: unknown language",
			[MessageKey.TermLanguageUnclear] = "{0}: the language could not be told from its letters; choose Persian or English",
			[MessageKey.TermEmpty] = "the word is empty",
			[MessageKey.TermTooLong] = "longer than {0} characters",
			[MessageKey.TermHasControlCharacter] = "contains a control character",
			[MessageKey.TermHasSpace] = "one word at a time (it contains a space)",
			[MessageKey.TermIsLink] = "a link is not a word",
			[MessageKey.ReviewKeptInQueue] = "kept in the queue: {0}",
			[MessageKey.ReviewQueueNotUpdated] = "saved to your personal dictionary, but {0} proposal(s) could not be removed from the word review queue ({1}). They are still listed; accepting them again is safe and only clears them.",
			[MessageKey.ReviewLanguageNotSupported] = "{0}: its language ({1}) is not Persian or English",
			[MessageKey.ImportUnsupportedFile] = "Only UTF-8 JSON, CSV, and TXT dictionary files are supported.",
			[MessageKey.ImportJsonNoEntries] = "The JSON file has no entries array.",
			[MessageKey.ImportJsonError] = "JSON: {0}",
			[MessageKey.ImportHeaderError] = "Header: {0}",
			[MessageKey.ImportCsvNoHeader] = "The CSV file has no header row.",
			[MessageKey.ImportCsvNoTermColumn] = "The CSV header must contain a '{0}' or '{1}' column.",
			[MessageKey.ImportLineError] = "Line {0}: {1}",
			[MessageKey.ImportLineMetadataInvalid] = "Line {0}: one or more metadata values are invalid.",
			[MessageKey.ImportLineLanguageUnclear] = "Line {0}: the language could not be told from the letters; state Persian or English.",
			[MessageKey.ImportLineLanguageUnclearText] = "Line {0}: the language could not be told from the letters; use JSON or CSV with a language.",
			[MessageKey.ImportLineRejected] = "Line {0}: {1}.",
			[MessageKey.ExportUnsupportedFile] = "Only JSON, CSV, and TXT dictionary files are supported.",
			[MessageKey.ReviewQueueNotSaved] = "The word review queue could not be saved ({0}). Nothing was changed. Check that {1} is not open in another program and the disk has room, then try again.",
			[MessageKey.GesturePressModifierAndKey] = "Press a modifier and one other key.",
			[MessageKey.GestureIncludeModifier] = "Include Ctrl, Alt, Shift, or the Windows key.",
			[MessageKey.GestureRequired] = "Shortcut is required.",
			[MessageKey.GestureInvalid] = "Invalid shortcut: {0}.",
			[MessageKey.GestureNeedsModifierAndKey] = "Use at least one modifier and one key.",
			[MessageKey.NothingWasChanged] = "Nothing was changed.",
			[MessageKey.SelectWordFirst] = "Select a word first.",
			[MessageKey.SelectOneWord] = "Select one word.",
			[MessageKey.WordHasDigits] = "A word with digits is left as it is.",
			[MessageKey.WordIsTechnical] = "A link, address, email, path or code-like word is left as it is.",
			[MessageKey.WordMixesScripts] = "The word mixes Persian and Latin letters, so its mapping is not clear.",
			[MessageKey.WordWouldNotChange] = "The word would not change.",
			[MessageKey.NoWordToConvert] = "There is no word to convert.",
			[MessageKey.LastWordHasSpace] = "The last word contains a space or a control character.",
			[MessageKey.WordHasNoLetters] = "The word has no letters to convert.",
			[MessageKey.NoPersianMapping] = "No Persian mapping is available.",
			[MessageKey.NoEnglishMapping] = "The English keyboard mapping is not available.",
			[MessageKey.NoLatinMapping] = "No Latin mapping is available.",
			[MessageKey.KeyHasNoPersianLetter] = "'{0}' has no Persian letter on its key.",
			[MessageKey.LetterNotOnPersianKeys] = "'{0}' is not typed by any key of the Persian mapping.",
			[MessageKey.LetterAmbiguousBack] = "'{0}' is typed by keys that give different Latin letters, so it cannot be mapped back.",
			[MessageKey.SelectedWordUnavailable] = "Convert selected word is not available here yet. Nothing was changed.",
			[MessageKey.CancelledAfterShortcut] = "Cancelled: you typed or moved after the shortcut. Nothing was changed.",
			[MessageKey.SelectedWordBusy] = "Still converting the previous selection. Nothing was changed.",
			[MessageKey.ConversionNotConfirmed] = "The conversion was sent, but the editor has not confirmed it. Nothing was saved.",
			[MessageKey.EditorRefusedChange] = "The editor did not accept the change. Nothing was changed.",
			[MessageKey.TextMayHaveChanged] = "The text may have changed; check it. Nothing was saved.",
			[MessageKey.NoWordBeforeCaret] = "There is no word right before the caret. Nothing was changed.",
			[MessageKey.TextIsSelected] = "Text is selected: Toggle last typed word works at the caret; use Convert selected word for a selection. Nothing was changed.",
			[MessageKey.ProtectedFieldNothingRead] = "This is a protected field. Nothing was read or changed.",
			[MessageKey.FieldReadOnly] = "This field is read-only. Nothing was changed.",
			[MessageKey.FinishComposing] = "Finish the text being composed first. Nothing was changed.",
			[MessageKey.FieldUnsupported] = "This field does not support manual correction yet. Nothing was changed.",
			[MessageKey.HostUnsupported] = "Manual correction is not supported in this application yet. Nothing was changed.",
			[MessageKey.BrokerNoAnswer] = "Diyar did not answer in time. Nothing was changed.",
			[MessageKey.NothingToUndoHere] = "There is no manual correction to undo here.",
			[MessageKey.EditedSinceCorrection] = "The text changed after the correction, so it was not undone. Nothing was changed.",
			[MessageKey.OtherFieldCorrection] = "The last correction was made in another field. Nothing was changed.",
			[MessageKey.OriginalSentUnconfirmed] = "The original was sent back, but the editor has not confirmed it. The dictionary was not changed.",
			[MessageKey.RestoredAndWithdrawn] = "Restored the original word; what this correction added to your personal dictionary was withdrawn.",
			[MessageKey.RestoredDictionaryNotUpdated] = "Restored the original word, but the dictionary could not be updated.",
			[MessageKey.RestoredOriginal] = "Restored the original word.",
			[MessageKey.ConversionResultUnconfirmed] = "The conversion was sent, but this editor's result cannot be confirmed. Nothing was saved.",
			[MessageKey.HotkeyEditCommandsOff] = "This shortcut is turned off in this test build: keys typed while it edits could reach another field. Typing and conversion as you type are unaffected.",
			[MessageKey.PreviousWordTypeFirst] = "Convert previous word acts on the word you just typed; type a word, then press the shortcut.",
			[MessageKey.PreviousWordNeedsAutomatic] = "Convert previous word works while Diyar is on in Automatic correction.",
			[MessageKey.FieldProtected] = "This field is protected or restricted.",
			[MessageKey.SelectionNotReadable] = "Select a word first. If one is selected, this editor does not let Diyar read it.",
			[MessageKey.NonDictionaryWordsUnavailable] = "Convert non-dictionary words is not available in this build. Nothing was changed.",
			[MessageKey.SelectionReadBusy] = "Still reading the previous selection. Nothing was added.",
			[MessageKey.EditorNoAnswer] = "The editor did not answer in time. Nothing was added.",
			[MessageKey.SelectionReadFailed] = "The selection could not be read. Nothing was added.",
			[MessageKey.TextServiceMissing] = "The Diyar text service is not installed, so Convert selected word ({0}), Toggle last typed word ({1}) and Undo last manual correction ({2}) do nothing. Install Diyar with its setup program to add it.",
			[MessageKey.ManualCorrectionCouldNotStart] = "Manual correction could not start: {0}",
			[MessageKey.ManualChordsMustDiffer] = "The Convert selected word and Undo last manual correction shortcuts must be two different Ctrl or Alt combinations.",
			[MessageKey.ManualSettingsNotPublished] = "Manual correction settings could not be published: {0}",
			[MessageKey.TypingPaused] = "Diyar paused. Keys work as plain Windows until you resume.",
			[MessageKey.TypingResumed] = "Diyar resumed.",
			[MessageKey.TrayPause] = "Pause typing",
			[MessageKey.TrayResume] = "Resume typing",
			[MessageKey.TrayPausedTooltip] = "Diyar · Paused",
			[MessageKey.TrayOpen] = "Open Diyar",
			[MessageKey.TrayCheckForUpdates] = "Check for updates",
			[MessageKey.TrayExit] = "Exit",
			[MessageKey.TrayUpdateTitle] = "Diyar update available",
			[MessageKey.TrayUpdateText] = "Version {0} is ready. Open Settings to review and download it.",
			[MessageKey.EntryLanguageNeutral] = "Neutral",
			[MessageKey.EntryLanguageUnknown] = "unknown",
			[MessageKey.TranslationTookTooLong] = "Translation took too long and was stopped. Nothing was changed.",
			[MessageKey.TranslationCancelledNothingChanged] = "Translation cancelled. Nothing was changed.",
			[MessageKey.TranslationNoConfirmedToUndo] = "No confirmed translation to undo",
			[MessageKey.TranslationClipboardEmpty] = "The clipboard holds no text. Copy text first; nothing was changed.",
			[MessageKey.TranslationClipboardWriteFailed] = "The translation could not be placed on the clipboard. Nothing was changed.",
			[MessageKey.TranslationServiceNoAnswer] = "The translation service did not answer in time. Nothing was changed.",
			[MessageKey.TranslationServiceUnreachable] = "The translation service could not be reached. Check the internet connection.",
			[MessageKey.TranslationClipboardTooLong] = "The clipboard text is longer than {0} characters",
			[MessageKey.TranslationCopiedToClipboard] = "Translated to {0} and copied to the clipboard. Paste it where you need it.",
			[MessageKey.TranslationSelectionUnreadable] = "This editor does not let Diyar read the selection. Nothing was changed.",
			[MessageKey.TranslationEditorUnsupported] = "Translation is not supported in this editor. Nothing was changed.",
			[MessageKey.TranslationMultiLineUnsupported] = "Multi-line selections can be translated only in plain text fields in this version. Nothing was changed.",
			[MessageKey.TranslationPreviousCommandBusy] = "Still working on the previous command. Nothing was changed.",
			[MessageKey.TranslationReadTimedOut] = "The editor did not answer in time. Nothing was changed.",
			[MessageKey.TranslationReadFailed] = "The selection could not be read. Nothing was changed.",
			[MessageKey.TranslationWriteTimedOut] = "The editor did not answer in time. Check the text.",
			[MessageKey.TranslationWriteFailed] = "The editor stopped answering while the text was being written. Check the text.",
			[MessageKey.TranslationUnconfirmed] = "The translation was sent, but this editor has not confirmed it. Check the text; the application's own Undo restores it.",
			[MessageKey.TranslationRestoreUnconfirmed] = "The original text was sent back, but this editor has not confirmed it. Check the text.",
			[MessageKey.TranslationClipboardUnavailable] = "The clipboard could not be used. Nothing was changed.",
			[MessageKey.TranslationUndoMoved] = "You typed or moved since the translation; use the application's Undo.",
			[MessageKey.TranslationUndoContradicted] = "The translated text is no longer where it was written; use the application's Undo.",
			[MessageKey.TranslationUndoClipboardOff] = "This translation went through the clipboard, which is now turned off; use the application's Undo.",
			[MessageKey.TranslationFocusChanged] = "The field in focus changed. Nothing was changed.",
			[MessageKey.TranslationControlRefused] = "The field did not accept the translation. Nothing was changed.",
			[MessageKey.AzureTemporarilyUnavailable] = "Azure Translator is temporarily unavailable",
			[MessageKey.AzureTryAgainIn] = "{0}. Try again in {1} seconds.",
			[MessageKey.LanguageAutomatic] = "Automatic (Persian ↔ English)",
			[MessageKey.LocalModelAnswerCutOff] = "The local model's answer was cut off; select less text.",
			[MessageKey.TrayUpdateClickText] = "Version {0} is available. Click to see it in Diyar's update settings.",
			[MessageKey.SettingsFileHoldsNoSettings] = "The settings file holds no settings object.",
			[MessageKey.SettingsFileUnreadable] = "The settings file could not be read ({0}).",
			[MessageKey.SettingsFileKeptAs] = "{0} It was kept as {1} in {2}; default settings are in use until you change one.",
			[MessageKey.SettingsFileNotSetAside] = "{0} It could not be set aside; default settings are in use until you change one, which replaces it.",
			[MessageKey.FontStatusWrittenToProfiles] = "Set in {0} profile(s); pages that choose their own font are unchanged",
			[MessageKey.FontStatusWrittenRestart] = "Set in {0} profile(s) - restart {1} to confirm",
			[MessageKey.FontStatusReverted] = "{0} changed this setting back - apply the font again",
			[MessageKey.FontStatusFontNotInstalled] = "{0} is not installed in Windows",
			[MessageKey.FontStatusFontNotInstalledUse] = "{0} is not installed in Windows - choose {1}",
			[MessageKey.FontCheckTitle] = "Font check",
			[MessageKey.FontCheckIntro] = "This page sets no font of its own, so {0} shows it in its default font. If the two lines below appear in {1}, {0} uses {1} for pages without their own font. Websites that choose their own font keep it."
		};

		private static readonly Dictionary<MessageKey, string> Persian = new Dictionary<MessageKey, string>
		{
			[MessageKey.StartupStartsHidden] = "هنگام ورود به ویندوز، به\u200cصورت پنهان در ناحیه\u0654 اعلان اجرا می\u200cشود.",
			[MessageKey.StartupThroughInstaller] = "از طریق گزینه\u0654 اجرای خودکار نصب\u200cکننده، همراه ویندوز اجرا می\u200cشود.",
			[MessageKey.StartupOff] = "همراه ویندوز اجرا نمی\u200cشود.",
			[MessageKey.StartupOlderInstallation] = "ثبت اجرای خودکار به نصب قدیمی\u200cتری اشاره می\u200cکند. برای اصلاح آن، «اجرا هنگام شروع ویندوز» را روشن کنید.",
			[MessageKey.StartupStatusUnreadable] = "وضعیت اجرا با ویندوز برای این کاربر خوانده نشد.",
			[MessageKey.StartupEnableFailed] = "Diyar نتوانست اجرا با ویندوز را برای این کاربر روشن کند.",
			[MessageKey.StartupDisableNeedsPermission] = "اجرا با ویندوز را نصب\u200cکننده تنظیم کرده است و بدون دسترسی مدیر خاموش نمی\u200cشود.",
			[MessageKey.StartupNotAccepted] = "ویندوز ثبت اجرای خودکار را نپذیرفت.",
			[MessageKey.StartupEntryStillActive] = "هنوز یک ثبت اجرای خودکار از ویندوز یا نصب\u200cکننده فعال است.",
			[MessageKey.ShortcutsNoneRegistered] = "هیچ میان\u200cبر صفحه\u200cکلیدی ثبت نشد: {0}.",
			[MessageKey.ShortcutsOneNotRegistered] = "یک میان\u200cبر ثبت نشد: {0}.",
			[MessageKey.ShortcutsSomeNotRegistered] = "{0} میان\u200cبر ثبت نشد: {1}.",
			[MessageKey.ShortcutsOthersWork] = "میان\u200cبرهای دیگر کار می\u200cکنند.",
			[MessageKey.ShortcutsChooseDifferentKeys] = "در «تنظیمات › میان\u200cبرها» کلیدهای دیگری انتخاب کنید.",
			[MessageKey.ShortcutsCauseMixed] = "یا هم\u200cاکنون جای دیگری به کار می\u200cروند یا ترکیب کلید معتبری نیستند.",
			[MessageKey.ShortcutCauseTaken] = "برنامه\u0654 دیگری از آن استفاده می\u200cکند.",
			[MessageKey.ShortcutsCauseTaken] = "برنامه\u200cهای دیگری از آن\u200cها استفاده می\u200cکنند.",
			[MessageKey.ShortcutCauseDuplicate] = "با میان\u200cبر دیگری از Diyar یکی است.",
			[MessageKey.ShortcutsCauseDuplicate] = "با میان\u200cبرهای دیگری از Diyar یکی هستند.",
			[MessageKey.ShortcutCauseInvalid] = "ترکیب کلید معتبری نیست.",
			[MessageKey.ShortcutsCauseInvalid] = "ترکیب کلید معتبری نیستند.",
			[MessageKey.UpdateUrlInvalid] = "نشانی کامل HTTPS را برای به\u200cروزرسانی وارد کنید.",
			[MessageKey.UpdateInstalledVersionInvalid] = "نسخه\u0654 برنامه\u0654 نصب\u200cشده معتبر نیست.",
			[MessageKey.UpdateHttpStatus] = "سرویس به\u200cروزرسانی پاسخ HTTP {0} داد.",
			[MessageKey.UpdateFormatUnsupported] = "قالب اطلاعات به\u200cروزرسانی پشتیبانی نمی\u200cشود.",
			[MessageKey.UpdateNoValidRelease] = "هیچ نسخه\u0654 معتبری در سرویس به\u200cروزرسانی فهرست نشده است.",
			[MessageKey.UpdateUpToDate] = "نسخه\u0654 {0} از Diyar به\u200cروز است.",
			[MessageKey.UpdateAvailable] = "نسخه\u0654 {0} از Diyar منتشر شده است.",
			[MessageKey.UpdateTimedOut] = "مهلت بررسی به\u200cروزرسانی تمام شد.",
			[MessageKey.UpdateCheckFailed] = "اکنون نمی\u200cتوان به\u200cروزرسانی را بررسی کرد.",
			[MessageKey.UpdateManifestUnsigned] = "اطلاعات به\u200cروزرسانی امضا ندارد و قابل اعتماد نیست.",
			[MessageKey.UpdateManifestSignatureInvalid] = "اطلاعات به\u200cروزرسانی تأیید نشد.",
			[MessageKey.UpdateManifestExpired] = "اطلاعات به\u200cروزرسانی قدیمی است. بعدا\u064b دوباره تلاش کنید.",
			[MessageKey.UpdateManifestReplayed] = "اطلاعات به\u200cروزرسانی قدیمی\u200cتر از چیزی است که Diyar قبلا\u064b دیده است.",
			[MessageKey.TranslationBusy] = "ترجمه هنوز مشغول کار قبلی است",
			[MessageKey.TranslationAlreadyRunning] = "یک ترجمه در حال انجام است",
			[MessageKey.TranslationOff] = "ترجمه خاموش است",
			[MessageKey.TranslationProtectedField] = "ترجمه در کادرهای محافظت\u200cشده در دسترس نیست",
			[MessageKey.TranslationSelectText] = "متنی را برای ترجمه انتخاب کنید",
			[MessageKey.TranslationSelectionTooLong] = "متن انتخاب\u200cشده بیش از {0} نویسه است",
			[MessageKey.TranslationAddAzureKey] = "کلید API سرویس Azure Translator را در تنظیمات وارد کنید",
			[MessageKey.TranslationSetUpLocalModel] = "مدل روی دستگاه را در تنظیمات راه\u200cاندازی کنید",
			[MessageKey.TranslationUnsafeFormat] = "قالب ترجمه\u200cای که مدل برگرداند امن نیست",
			[MessageKey.TranslationSelectionChanged] = "متن انتخاب\u200cشده تغییر کرد؛ متن اصلی دست\u200cنخورده ماند",
			[MessageKey.TranslationDone] = "به {0} ترجمه شد",
			[MessageKey.TranslationFailed] = "ترجمه انجام نشد",
			[MessageKey.TranslationUndoOff] = "بازگردانی ترجمه خاموش است",
			[MessageKey.TranslationNothingRecentToUndo] = "ترجمه\u0654 اخیری برای بازگردانی وجود ندارد",
			[MessageKey.TranslationRestored] = "متن اصلی به\u200cجای ترجمه بازگردانده شد",
			[MessageKey.CloudTranslationUnavailable] = "ترجمه\u0654 ابری در دسترس نیست",
			[MessageKey.LocalTranslationUnavailable] = "ترجمه روی دستگاه در دسترس نیست",
			[MessageKey.NoTranslationToUndo] = "ترجمه\u200cای برای بازگردانی وجود ندارد",
			[MessageKey.AzureConfigured] = "Azure Translator تنظیم شده است",
			[MessageKey.AzureAddKey] = "کلید API سرویس Azure Translator را وارد کنید",
			[MessageKey.AzureRejectedKey] = "Azure Translator کلید API یا ناحیه را نپذیرفت",
			[MessageKey.AzureQuotaReached] = "به سقف سهمیه یا سرعت Azure Translator رسیده\u200cاید",
			[MessageKey.AzureHttpStatus] = "Azure Translator پاسخ HTTP {0} داد",
			[MessageKey.AzureSaveKeyFirst] = "اول یک کلید API سرویس Azure Translator ذخیره کنید",
			[MessageKey.AzureConnectionVerified] = "اتصال تأیید شد. کلید API و ناحیه درست هستند.",
			[MessageKey.AzureUnreachable] = "دسترسی به Azure ممکن نشد. اتصال اینترنت را بررسی کنید.",
			[MessageKey.AzureNotVerified] = "اتصال Azure تأیید نشد.",
			[MessageKey.AzureRegionInvalid] = "{0} یا کد موقعیت Azure را وارد کنید؛ مثلا\u064b {1}.",
			[MessageKey.LocalModelReady] = "آماده\u0654 ترجمه بدون اینترنت",
			[MessageKey.LocalModelSetupRequired] = "مدل باید راه\u200cاندازی شود",
			[MessageKey.LocalRuntimeAccessDenied] = "اجازه\u0654 دسترسی به محیط اجرای هوش مصنوعی روی دستگاه داده نشد",
			[MessageKey.LocalModelCatalogUnavailable] = "فهرست مدل\u200cهای روی دستگاه در دسترس نیست",
			[MessageKey.LocalModelUnavailable] = "مدل هوش مصنوعی روی دستگاه در دسترس نیست",
			[MessageKey.LanguageEnglish] = "انگلیسی",
			[MessageKey.LanguagePersian] = "فارسی",
			[MessageKey.LanguageArabic] = "عربی",
			[MessageKey.LanguageUrdu] = "اردو",
			[MessageKey.LanguageFrench] = "فرانسوی",
			[MessageKey.LanguageGerman] = "آلمانی",
			[MessageKey.LanguageSpanish] = "اسپانیایی",
			[MessageKey.LanguageTurkish] = "ترکی",
			[MessageKey.LanguageRussian] = "روسی",
			[MessageKey.LanguageChineseSimplified] = "چینی (ساده\u200cشده)",
			[MessageKey.LanguageJapanese] = "ژاپنی",
			[MessageKey.LanguageKorean] = "کره\u200cای",
			[MessageKey.LanguageHindi] = "هندی",
			[MessageKey.ModelBalanced] = "متعادل",
			[MessageKey.ModelBalancedSize] = "حدود 1٫8 گیگابایت",
			[MessageKey.ModelBalancedSummary] = "کیفیت و سرعت پیشنهادی",
			[MessageKey.ModelCompact] = "فشرده",
			[MessageKey.ModelCompactSize] = "حدود 0٫8 گیگابایت",
			[MessageKey.ModelCompactSummary] = "سریع\u200cتر، با کیفیت ترجمه\u0654 پایین\u200cتر",
			[MessageKey.ModelQuality] = "باکیفیت",
			[MessageKey.ModelQualitySize] = "حدود 6٫2 گیگابایت",
			[MessageKey.ModelQualitySummary] = "کیفیت بالاتر، با نیاز به سخت\u200cافزار قوی\u200cتر",
			[MessageKey.LayoutPersianStandard] = "فارسی (استاندارد)",
			[MessageKey.LayoutPersian] = "فارسی",
			[MessageKey.LayoutEnglishUs] = "انگلیسی (ایالات متحده) - US",
			[MessageKey.LayoutEnglishUsInternational] = "انگلیسی (ایالات متحده) - بین\u200cالمللی ایالات متحده",
			[MessageKey.LayoutNotInstalledByWindows] = "ویندوز {0} را نصب نکرد. آن را از «تنظیمات ویندوز › زمان و زبان › زبان و منطقه» اضافه کنید.",
			[MessageKey.LayoutInstallUnsupported] = "این نسخه\u0654 ویندوز نمی\u200cتواند چیدمان را از طریق Diyar نصب کند. {0} را از «تنظیمات ویندوز › زمان و زبان › زبان و منطقه» اضافه کنید.",
			[MessageKey.LayoutInstalled] = "{0} نصب شد.",
			[MessageKey.LayoutAddedAfterSignIn] = "{0} اضافه شد و پس از خروج از حساب و ورود دوباره نمایش داده می\u200cشود.",
			[MessageKey.FontScopeWebFallback] = "صفحه\u200cهای بدون قلم اختصاصی",
			[MessageKey.FontScopeEditor] = "قلم ویرایشگر",
			[MessageKey.FontScopeMessages] = "قلم\u200cهای پیام",
			[MessageKey.FontScopeAllProfiles] = "همه\u0654 نمایه\u200cها",
			[MessageKey.FontScopeNewEmail] = "پیام\u200cهای ایمیل تازه",
			[MessageKey.FontScopeNewDocuments] = "سندهای تازه",
			[MessageKey.FontStatusNotInstalled] = "نصب نشده",
			[MessageKey.FontStatusOpenAppOnce] = "برنامه را یک بار باز کنید",
			[MessageKey.FontStatusManualSetup] = "تنظیم دستی",
			[MessageKey.FontStatusFailed] = "انجام نشد",
			[MessageKey.FontStatusReady] = "آماده",
			[MessageKey.FontStatusApplied] = "اعمال شد",
			[MessageKey.FontStatusRestored] = "بازگردانده شد",
			[MessageKey.FontStatusNoBackup] = "نسخه\u0654 پشتیبان موجود نیست",
			[MessageKey.FontStatusInvalidJson] = "فایل تنظیمات یک JSON معتبر نیست",
			[MessageKey.FontStatusAppliedToProfiles] = "روی {0} نمایه اعمال شد",
			[MessageKey.FontStatusReadyProfiles] = "آماده؛ {0} نمایه",
			[MessageKey.FontStatusReadyStopBackground] = "آماده؛ {0} نمایه. {1} که در پس\u200cزمینه اجرا می\u200cشود بسته خواهد شد",
			[MessageKey.FontStatusCloseAllWindows] = "همه\u0654 پنجره\u200cهای {0} را ببندید",
			[MessageKey.FontStatusClose] = "{0} را ببندید",
			[MessageKey.FontStatusAppliedRestart] = "روی {0} نمایه اعمال شد؛ {1} را دوباره باز کنید",
			[MessageKey.FontStatusRestoredRestart] = "بازگردانده شد؛ {0} را دوباره باز کنید",
			[MessageKey.FontStatusAppliedNewDocuments] = "روی سندهای تازه اعمال شد",
			[MessageKey.FontStatusCloseWord] = "Word را ببندید",
			[MessageKey.UnreadableFileCopyKept] = "فایل {0} خوانده نشد ({1}). یک نسخه\u0654 پشتیبان از آن با نام {2} نگه داشته شد.",
			[MessageKey.UnreadableFileBlocked] = "فایل {0} خوانده نشد ({1}) و از آن نسخه\u0654 پشتیبان هم گرفته نشد، پس تغییری در آن داده نمی\u200cشود: تا وقتی نسخه\u0654 پشتیبان گرفته نشود، افزودن، ویرایش و حذف واژه\u200cها ممکن نیست. فضای دیسک را آزاد کنید یا دسترسی\u200cهای پوشه را درست کنید و دوباره تلاش کنید؛ به خود فایل دست زده نشده است.",
			[MessageKey.UnreadableEmptyFile] = "فایل خالی است",
			[MessageKey.UnreadableNoEntriesList] = "فهرست واژه\u200cها را ندارد",
			[MessageKey.UnreadableNoCandidatesList] = "فهرست پیشنهادها را ندارد",
			[MessageKey.UnreadableNewerFormat] = "نسخه\u0654 قالب آن ({0}) از آنچه این برنامه می\u200cشناسد تازه\u200cتر است",
			[MessageKey.ConvertedAndAdded] = "تبدیل شد؛ «{0}» به واژه\u200cنامه\u0654 شخصی شما افزوده شد.",
			[MessageKey.ConvertedAlreadyPersonal] = "تبدیل شد؛ این واژه از پیش در واژه\u200cنامه\u0654 شخصی شما هست.",
			[MessageKey.ConvertedAlreadyBuiltIn] = "تبدیل شد؛ این واژه از پیش در واژه\u200cنامه\u0654 پایه هست.",
			[MessageKey.ConvertedKeptEnglishForSession] = "تبدیل شد؛ «{0}» تا اجرای دوباره\u0654 Diyar انگلیسی می\u200cماند.",
			[MessageKey.ConvertedAndForgotEnglish] = "تبدیل شد؛ «{0}» دیگر انگلیسی نگه داشته نمی\u200cشود و دوباره تبدیل می\u200cشود.",
			[MessageKey.ConvertedNotAdded] = "تبدیل شد، ولی این واژه به واژه\u200cنامه افزوده نشد.",
			[MessageKey.ConvertedNotSaved] = "تبدیل شد، ولی ذخیره نشد.",
			[MessageKey.ConvertedBack] = "به حالت قبل برگشت.",
			[MessageKey.Converted] = "تبدیل شد.",
			[MessageKey.WordLanguageUnknownNotAdded] = "زبان این واژه از روی حروفش معلوم نیست، پس افزوده نشد.",
			[MessageKey.WordNotAddedNotSaved] = "افزوده نشد: واژه\u200cنامه ذخیره نشد ({0}). واژه\u200cنامه و متن شما تغییری نکرده\u200cاند.",
			[MessageKey.WordAddedToPersonal] = "«{0}» به واژه\u200cنامه\u0654 شخصی شما افزوده شد.",
			[MessageKey.WordAlreadyPersonal] = "از پیش در واژه\u200cنامه\u0654 شخصی شما هست.",
			[MessageKey.WordAlreadyBuiltIn] = "از پیش در واژه\u200cنامه\u0654 پایه هست.",
			[MessageKey.WordNotAddedBecause] = "افزوده نشد: {0}",
			[MessageKey.WordRejectedNotAdded] = "افزوده نشد: واژه پذیرفته نشد.",
			[MessageKey.DictionaryAdded] = "{0} واژه افزوده شد",
			[MessageKey.DictionaryAlreadyPersonal] = "{0} واژه از پیش در واژه\u200cنامه\u0654 شخصی شما هست",
			[MessageKey.DictionaryAlreadyBuiltIn] = "{0} واژه از پیش در واژه\u200cنامه\u0654 پایه هست",
			[MessageKey.DictionaryRejected] = "{0} واژه پذیرفته نشد",
			[MessageKey.TermLanguageUnknown] = "{0}: زبان نامعلوم",
			[MessageKey.TermLanguageUnclear] = "{0}: زبان از روی حروف معلوم نیست؛ فارسی یا انگلیسی را انتخاب کنید",
			[MessageKey.TermEmpty] = "واژه خالی است",
			[MessageKey.TermTooLong] = "بیش از {0} نویسه است",
			[MessageKey.TermHasControlCharacter] = "نویسه\u0654 کنترلی دارد",
			[MessageKey.TermHasSpace] = "هر بار فقط یک واژه (فاصله دارد)",
			[MessageKey.TermIsLink] = "پیوند واژه نیست",
			[MessageKey.ReviewKeptInQueue] = "در صف ماند: {0}",
			[MessageKey.ReviewQueueNotUpdated] = "در واژه\u200cنامه\u0654 شخصی شما ذخیره شد، ولی {0} پیشنهاد از صف بازبینی واژه\u200cها برداشته نشد ({1}). این پیشنهادها هنوز در فهرست هستند؛ پذیرفتن دوباره\u0654 آن\u200cها بی\u200cخطر است و فقط آن\u200cها را از صف برمی\u200cدارد.",
			[MessageKey.ReviewLanguageNotSupported] = "{0}: زبان آن ({1}) فارسی یا انگلیسی نیست",
			[MessageKey.ImportUnsupportedFile] = "فقط فایل\u200cهای واژه\u200cنامه\u0654 JSON، CSV و TXT با رمزگذاری UTF-8 پشتیبانی می\u200cشوند.",
			[MessageKey.ImportJsonNoEntries] = "فایل JSON آرایه\u0654 entries ندارد.",
			[MessageKey.ImportJsonError] = "خطای JSON: {0}",
			[MessageKey.ImportHeaderError] = "سطر عنوان: {0}",
			[MessageKey.ImportCsvNoHeader] = "فایل CSV سطر عنوان ندارد.",
			[MessageKey.ImportCsvNoTermColumn] = "سطر عنوان فایل CSV باید ستون {0} یا {1} داشته باشد.",
			[MessageKey.ImportLineError] = "سطر {0}: {1}",
			[MessageKey.ImportLineMetadataInvalid] = "سطر {0}: یک یا چند مقدار فراداده معتبر نیست.",
			[MessageKey.ImportLineLanguageUnclear] = "سطر {0}: زبان از روی حروف معلوم نیست؛ فارسی یا انگلیسی بودن آن را بنویسید.",
			[MessageKey.ImportLineLanguageUnclearText] = "سطر {0}: زبان از روی حروف معلوم نیست؛ از فایل JSON یا CSV همراه با زبان استفاده کنید.",
			[MessageKey.ImportLineRejected] = "سطر {0}: {1}.",
			[MessageKey.ExportUnsupportedFile] = "فقط فایل\u200cهای واژه\u200cنامه\u0654 JSON، CSV و TXT پشتیبانی می\u200cشوند.",
			[MessageKey.ReviewQueueNotSaved] = "صف بازبینی واژه\u200cها ذخیره نشد ({0}). هیچ تغییری داده نشد. مطمئن شوید {1} در برنامه\u0654 دیگری باز نیست و دیسک جا دارد، سپس دوباره تلاش کنید.",
			[MessageKey.GesturePressModifierAndKey] = "یک کلید کمکی و یک کلید دیگر را با هم بزنید.",
			[MessageKey.GestureIncludeModifier] = "کلید Ctrl، Alt، Shift یا Windows را هم بزنید.",
			[MessageKey.GestureRequired] = "میان\u200cبر لازم است.",
			[MessageKey.GestureInvalid] = "میان\u200cبر نامعتبر است: {0}.",
			[MessageKey.GestureNeedsModifierAndKey] = "دست\u200cکم یک کلید کمکی و یک کلید دیگر به کار ببرید.",
			[MessageKey.NothingWasChanged] = "هیچ تغییری داده نشد.",
			[MessageKey.SelectWordFirst] = "اول یک واژه را انتخاب کنید.",
			[MessageKey.SelectOneWord] = "فقط یک واژه را انتخاب کنید.",
			[MessageKey.WordHasDigits] = "واژه\u200cای که رقم دارد همان\u200cطور که هست می\u200cماند.",
			[MessageKey.WordIsTechnical] = "پیوند، نشانی، ایمیل، مسیر یا واژه\u200cای که شبیه کد است همان\u200cطور که هست می\u200cماند.",
			[MessageKey.WordMixesScripts] = "این واژه حروف فارسی و لاتین را با هم دارد، پس معلوم نیست به چه تبدیل شود.",
			[MessageKey.WordWouldNotChange] = "این واژه با تبدیل تغییری نمی\u200cکند.",
			[MessageKey.NoWordToConvert] = "واژه\u200cای برای تبدیل وجود ندارد.",
			[MessageKey.LastWordHasSpace] = "واژه\u0654 آخر فاصله یا نویسه\u0654 کنترلی دارد.",
			[MessageKey.WordHasNoLetters] = "این واژه حرفی برای تبدیل ندارد.",
			[MessageKey.NoPersianMapping] = "نگاشت فارسی در دسترس نیست.",
			[MessageKey.NoEnglishMapping] = "نگاشت صفحه\u200cکلید انگلیسی در دسترس نیست.",
			[MessageKey.NoLatinMapping] = "نگاشت لاتین در دسترس نیست.",
			[MessageKey.KeyHasNoPersianLetter] = "کلید «{0}» حرف فارسی ندارد.",
			[MessageKey.LetterNotOnPersianKeys] = "هیچ کلیدی در نگاشت فارسی «{0}» را تایپ نمی\u200cکند.",
			[MessageKey.LetterAmbiguousBack] = "«{0}» با کلیدهایی تایپ می\u200cشود که حروف لاتین متفاوتی می\u200cدهند، پس نمی\u200cتوان آن را برگرداند.",
			[MessageKey.SelectedWordUnavailable] = "«تبدیل واژه\u0654 انتخاب\u200cشده» هنوز اینجا در دسترس نیست. هیچ تغییری داده نشد.",
			[MessageKey.CancelledAfterShortcut] = "لغو شد: پس از زدن میان\u200cبر، چیزی تایپ کردید یا نشانگر را جابه\u200cجا کردید. هیچ تغییری داده نشد.",
			[MessageKey.SelectedWordBusy] = "هنوز انتخاب قبلی در حال تبدیل است. هیچ تغییری داده نشد.",
			[MessageKey.ConversionNotConfirmed] = "تبدیل فرستاده شد، ولی ویرایشگر آن را تأیید نکرده است. چیزی ذخیره نشد.",
			[MessageKey.EditorRefusedChange] = "ویرایشگر این تغییر را نپذیرفت. هیچ تغییری داده نشد.",
			[MessageKey.TextMayHaveChanged] = "ممکن است متن تغییر کرده باشد؛ آن را بررسی کنید. چیزی ذخیره نشد.",
			[MessageKey.NoWordBeforeCaret] = "درست پیش از نشانگر واژه\u200cای نیست. هیچ تغییری داده نشد.",
			[MessageKey.TextIsSelected] = "متنی انتخاب شده است: «تبدیل واژه\u0654 آخر» در جای نشانگر کار می\u200cکند؛ برای متن انتخاب\u200cشده از «تبدیل واژه\u0654 انتخاب\u200cشده» استفاده کنید. هیچ تغییری داده نشد.",
			[MessageKey.ProtectedFieldNothingRead] = "این کادر محافظت\u200cشده است. چیزی خوانده یا تغییر داده نشد.",
			[MessageKey.FieldReadOnly] = "این کادر فقط\u200cخواندنی است. هیچ تغییری داده نشد.",
			[MessageKey.FinishComposing] = "اول نوشتن متنی را که در حال ترکیب است تمام کنید. هیچ تغییری داده نشد.",
			[MessageKey.FieldUnsupported] = "این کادر هنوز از اصلاح دستی پشتیبانی نمی\u200cکند. هیچ تغییری داده نشد.",
			[MessageKey.HostUnsupported] = "اصلاح دستی هنوز در این برنامه پشتیبانی نمی\u200cشود. هیچ تغییری داده نشد.",
			[MessageKey.BrokerNoAnswer] = "Diyar به\u200cموقع پاسخ نداد. هیچ تغییری داده نشد.",
			[MessageKey.NothingToUndoHere] = "اینجا اصلاح دستی\u200cای برای بازگردانی وجود ندارد.",
			[MessageKey.EditedSinceCorrection] = "متن پس از اصلاح تغییر کرده است، پس اصلاح بازگردانده نشد. هیچ تغییری داده نشد.",
			[MessageKey.OtherFieldCorrection] = "آخرین اصلاح در کادر دیگری انجام شده است. هیچ تغییری داده نشد.",
			[MessageKey.OriginalSentUnconfirmed] = "متن اصلی برای بازگرداندن فرستاده شد، ولی ویرایشگر آن را تأیید نکرده است. واژه\u200cنامه تغییری نکرد.",
			[MessageKey.RestoredAndWithdrawn] = "واژه\u0654 اصلی بازگردانده شد؛ آنچه این اصلاح به واژه\u200cنامه\u0654 شخصی شما افزوده بود برداشته شد.",
			[MessageKey.RestoredDictionaryNotUpdated] = "واژه\u0654 اصلی بازگردانده شد، ولی واژه\u200cنامه به\u200cروز نشد.",
			[MessageKey.RestoredOriginal] = "واژه\u0654 اصلی بازگردانده شد.",
			[MessageKey.ConversionResultUnconfirmed] = "تبدیل فرستاده شد، ولی نتیجه\u0654 آن در این ویرایشگر قابل تأیید نیست. چیزی ذخیره نشد.",
			[MessageKey.HotkeyEditCommandsOff] = "این میان\u200cبر در این نسخه\u0654 آزمایشی خاموش است: کلیدهایی که هنگام ویرایش آن تایپ شوند ممکن است به کادر دیگری برسند. تایپ و تبدیل در حین تایپ مثل همیشه کار می\u200cکنند.",
			[MessageKey.PreviousWordTypeFirst] = "«تبدیل واژه\u0654 قبلی» روی واژه\u200cای کار می\u200cکند که همین حالا تایپ کرده\u200cاید؛ یک واژه تایپ کنید و سپس میان\u200cبر را بزنید.",
			[MessageKey.PreviousWordNeedsAutomatic] = "«تبدیل واژه\u0654 قبلی» فقط وقتی کار می\u200cکند که Diyar روشن و در حالت «اصلاح خودکار» باشد.",
			[MessageKey.FieldProtected] = "این کادر محافظت\u200cشده یا محدود است.",
			[MessageKey.SelectionNotReadable] = "اول یک واژه را انتخاب کنید. اگر واژه\u200cای انتخاب شده است، این ویرایشگر به Diyar اجازه\u0654 خواندن آن را نمی\u200cدهد.",
			[MessageKey.NonDictionaryWordsUnavailable] = "«تبدیل واژه\u200cهای خارج از واژه\u200cنامه» در این نسخه در دسترس نیست. هیچ تغییری داده نشد.",
			[MessageKey.SelectionReadBusy] = "هنوز متن انتخاب\u200cشده\u0654 قبلی در حال خواندن است. چیزی افزوده نشد.",
			[MessageKey.EditorNoAnswer] = "ویرایشگر به\u200cموقع پاسخ نداد. چیزی افزوده نشد.",
			[MessageKey.SelectionReadFailed] = "متن انتخاب\u200cشده خوانده نشد. چیزی افزوده نشد.",
			[MessageKey.TextServiceMissing] = "سرویس متن Diyar نصب نیست، پس «تبدیل واژه\u0654 انتخاب\u200cشده» ({0})، «تبدیل واژه\u0654 آخر» ({1}) و «بازگردانی آخرین اصلاح دستی» ({2}) کاری انجام نمی\u200cدهند. برای افزودن آن، Diyar را با نصب\u200cکننده\u200cاش نصب کنید.",
			[MessageKey.ManualCorrectionCouldNotStart] = "اصلاح دستی راه\u200cاندازی نشد: {0}",
			[MessageKey.ManualChordsMustDiffer] = "میان\u200cبرهای «تبدیل واژه\u0654 انتخاب\u200cشده» و «بازگردانی آخرین اصلاح دستی» باید دو ترکیب متفاوت با Ctrl یا Alt باشند.",
			[MessageKey.ManualSettingsNotPublished] = "تنظیمات اصلاح دستی به سرویس متن فرستاده نشد: {0}",
			[MessageKey.TypingPaused] = "تایپ با Diyar متوقف شد. تا وقتی ادامه ندهید، کلیدها مثل خود ویندوز کار می\u200cکنند.",
			[MessageKey.TypingResumed] = "تایپ با Diyar ادامه یافت.",
			[MessageKey.TrayPause] = "توقف تایپ",
			[MessageKey.TrayResume] = "ادامه\u0654 تایپ",
			[MessageKey.TrayPausedTooltip] = "Diyar · متوقف",
			[MessageKey.TrayOpen] = "باز کردن Diyar",
			[MessageKey.TrayCheckForUpdates] = "بررسی به\u200cروزرسانی",
			[MessageKey.TrayExit] = "خروج",
			[MessageKey.TrayUpdateTitle] = "به\u200cروزرسانی Diyar در دسترس است",
			[MessageKey.TrayUpdateText] = "نسخه\u0654 {0} در دسترس است. برای بررسی و دریافت آن، تنظیمات را باز کنید.",
			[MessageKey.EntryLanguageNeutral] = "خنثی",
			[MessageKey.EntryLanguageUnknown] = "نامشخص",
			[MessageKey.TranslationTookTooLong] = "ترجمه بیش از حد طول کشید و متوقف شد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationCancelledNothingChanged] = "ترجمه لغو شد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationNoConfirmedToUndo] = "ترجمه\u0654 تأییدشده\u200cای برای بازگردانی وجود ندارد",
			[MessageKey.TranslationClipboardEmpty] = "کلیپ\u200cبورد متنی ندارد. اول متنی را کپی کنید؛ هیچ تغییری داده نشد.",
			[MessageKey.TranslationClipboardWriteFailed] = "ترجمه در کلیپ\u200cبورد گذاشته نشد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationServiceNoAnswer] = "سرویس ترجمه به\u200cموقع پاسخ نداد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationServiceUnreachable] = "دسترسی به سرویس ترجمه ممکن نشد. اتصال اینترنت را بررسی کنید.",
			[MessageKey.TranslationClipboardTooLong] = "متن کلیپ\u200cبورد بیش از {0} نویسه است",
			[MessageKey.TranslationCopiedToClipboard] = "به {0} ترجمه و در کلیپ\u200cبورد کپی شد. آن را هر جا که لازم دارید بچسبانید.",
			[MessageKey.TranslationSelectionUnreadable] = "این ویرایشگر به Diyar اجازه\u0654 خواندن متن انتخاب\u200cشده را نمی\u200cدهد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationEditorUnsupported] = "ترجمه در این ویرایشگر پشتیبانی نمی\u200cشود. هیچ تغییری داده نشد.",
			[MessageKey.TranslationMultiLineUnsupported] = "در این نسخه، متن چندخطی را فقط در کادرهای متن ساده می\u200cتوان ترجمه کرد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationPreviousCommandBusy] = "هنوز فرمان قبلی در حال انجام است. هیچ تغییری داده نشد.",
			[MessageKey.TranslationReadTimedOut] = "ویرایشگر به\u200cموقع پاسخ نداد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationReadFailed] = "متن انتخاب\u200cشده خوانده نشد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationWriteTimedOut] = "ویرایشگر به\u200cموقع پاسخ نداد. متن را بررسی کنید.",
			[MessageKey.TranslationWriteFailed] = "ویرایشگر هنگام نوشتن متن از پاسخ دادن بازماند. متن را بررسی کنید.",
			[MessageKey.TranslationUnconfirmed] = "ترجمه فرستاده شد، ولی این ویرایشگر آن را تأیید نکرده است. متن را بررسی کنید؛ «بازگردانی» خود برنامه متن قبلی را برمی\u200cگرداند.",
			[MessageKey.TranslationRestoreUnconfirmed] = "متن اصلی برای بازگرداندن فرستاده شد، ولی این ویرایشگر آن را تأیید نکرده است. متن را بررسی کنید.",
			[MessageKey.TranslationClipboardUnavailable] = "استفاده از کلیپ\u200cبورد ممکن نشد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationUndoMoved] = "پس از ترجمه چیزی تایپ کردید یا نشانگر را جابه\u200cجا کردید؛ از «بازگردانی» خود برنامه استفاده کنید.",
			[MessageKey.TranslationUndoContradicted] = "متن ترجمه\u200cشده دیگر در جایی که نوشته شد نیست؛ از «بازگردانی» خود برنامه استفاده کنید.",
			[MessageKey.TranslationUndoClipboardOff] = "این ترجمه از راه کلیپ\u200cبورد نوشته شد که اکنون خاموش است؛ از «بازگردانی» خود برنامه استفاده کنید.",
			[MessageKey.TranslationFocusChanged] = "کادر فعال تغییر کرد. هیچ تغییری داده نشد.",
			[MessageKey.TranslationControlRefused] = "کادر ترجمه را نپذیرفت. هیچ تغییری داده نشد.",
			[MessageKey.AzureTemporarilyUnavailable] = "Azure Translator موقتا\u064b در دسترس نیست",
			[MessageKey.AzureTryAgainIn] = "{0}. پس از {1} ثانیه دوباره تلاش کنید.",
			[MessageKey.LanguageAutomatic] = "خودکار (فارسی ↔ انگلیسی)",
			[MessageKey.LocalModelAnswerCutOff] = "پاسخ مدل روی دستگاه نیمه\u200cکاره ماند؛ متن کوتاه\u200cتری انتخاب کنید.",
			[MessageKey.TrayUpdateClickText] = "نسخه\u0654 {0} در دسترس است. برای دیدن آن در تنظیمات به\u200cروزرسانی Diyar کلیک کنید.",
			[MessageKey.SettingsFileHoldsNoSettings] = "فایل تنظیمات هیچ تنظیمی ندارد.",
			[MessageKey.SettingsFileUnreadable] = "فایل تنظیمات خوانده نشد ({0}).",
			[MessageKey.SettingsFileKeptAs] = "{0} این فایل با نام {1} در {2} نگه داشته شد؛ تا وقتی تنظیمی را تغییر ندهید، تنظیمات پیش\u200cفرض به کار می\u200cرود.",
			[MessageKey.SettingsFileNotSetAside] = "{0} کنار گذاشتن این فایل ممکن نشد؛ تا وقتی تنظیمی را تغییر ندهید، تنظیمات پیش\u200cفرض به کار می\u200cرود و نخستین تغییر جای این فایل را می\u200cگیرد.",
			[MessageKey.FontStatusWrittenToProfiles] = "در {0} نمایه تنظیم شد؛ صفحه\u200cهایی که قلم خودشان را دارند تغییر نمی\u200cکنند",
			[MessageKey.FontStatusWrittenRestart] = "در {0} نمایه تنظیم شد؛ برای تأیید، {1} را دوباره باز کنید",
			[MessageKey.FontStatusReverted] = "{0} این تنظیم را برگردانده است؛ قلم را دوباره اعمال کنید",
			[MessageKey.FontStatusFontNotInstalled] = "{0} در ویندوز نصب نیست",
			[MessageKey.FontStatusFontNotInstalledUse] = "{0} در ویندوز نصب نیست؛ {1} را انتخاب کنید",
			[MessageKey.FontCheckTitle] = "بررسی قلم",
			[MessageKey.FontCheckIntro] = "این صفحه قلم اختصاصی ندارد، پس {0} آن را با قلم پیش\u200cفرض خودش نشان می\u200cدهد. اگر دو سطر زیر با قلم {1} دیده می\u200cشوند، {0} برای صفحه\u200cهای بدون قلم اختصاصی از {1} استفاده می\u200cکند. وب\u200cسایت\u200cهایی که قلم خودشان را تعیین می\u200cکنند همان قلم را نگه می\u200cدارند."
		};

		public static string Get(MessageKey key)
		{
			return Get(key, TextCatalog.Language);
		}

		public static string Get(MessageKey key, UiLanguage language)
		{
			return TextCatalog.Lookup(key, language, English, Persian);
		}

		public static string Format(MessageKey key, params object?[] values)
		{
			return FormatIn(key, TextCatalog.Language, values);
		}

		public static string FormatIn(MessageKey key, UiLanguage language, params object?[] values)
		{
			return TextCatalog.Format(Get(key, language), values, language == UiLanguage.Persian);
		}

		public static IReadOnlyDictionary<MessageKey, string> Table(UiLanguage language)
		{
			if (language != UiLanguage.Persian)
			{
				return English;
			}
			return Persian;
		}
	}
	public static class TextCatalog
	{
		public const char LeftToRightIsolate = '\u2066';

		public const char FirstStrongIsolate = '\u2068';

		public const char RightToLeftIsolate = '\u2067';

		public const char PopDirectionalIsolate = '\u2069';

		private static volatile UiLanguage _language = UiLanguage.English;

		private static readonly char[] PathSeparators = new char[2] { '\\', '/' };

		private static readonly Regex MiWithSpace = new Regex("(?<![\\p{L}\u200c])ن?می (?=\\p{L})", RegexOptions.CultureInvariant);

		private static readonly Regex SpaceBeforePunctuation = new Regex(" [،؛؟.:»)]", RegexOptions.CultureInvariant);

		public static UiLanguage Language
		{
			get
			{
				return _language;
			}
			set
			{
				_language = Resolve(value);
			}
		}

		public static bool IsPersian => _language == UiLanguage.Persian;

		public static UiLanguage Resolve(UiLanguage stored)
		{
			if (!Enum.IsDefined(stored))
			{
				return UiLanguage.English;
			}
			return stored;
		}

		public static string Lookup<TKey>(TKey key, UiLanguage language, IReadOnlyDictionary<TKey, string> english, IReadOnlyDictionary<TKey, string> persian) where TKey : struct, Enum
		{
			if (language == UiLanguage.Persian && persian.TryGetValue(key, out string value) && value.Length > 0)
			{
				return value;
			}
			if (!english.TryGetValue(key, out string value2) || value2.Length <= 0)
			{
				return key.ToString();
			}
			return value2;
		}

		public static string Format(string template, IReadOnlyList<object?> values, bool isolate)
		{
			StringBuilder stringBuilder = new StringBuilder(template.Length + 32);
			foreach (TemplatePart item in Parse(template))
			{
				if (!item.IsValue)
				{
					stringBuilder.Append(item.Text);
					continue;
				}
				if (item.Value >= values.Count)
				{
					throw new FormatException($"The template uses {{{item.Value}}} but has {values.Count} value(s).");
				}
				string value = Convert.ToString(values[item.Value], CultureInfo.InvariantCulture) ?? string.Empty;
				if (isolate && !IsIsolated(value))
				{
					stringBuilder.Append(OpeningIsolate(value)).Append(value).Append('\u2069');
				}
				else
				{
					stringBuilder.Append(value);
				}
			}
			return stringBuilder.ToString();
		}

		public static IReadOnlyList<TemplatePart> Parse(string template)
		{
			List<TemplatePart> list = new List<TemplatePart>();
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < template.Length; i++)
			{
				char c = template[i];
				if (c == '{' && i + 1 < template.Length && template[i + 1] == '{')
				{
					stringBuilder.Append('{');
					i++;
					continue;
				}
				if (c == '}' && i + 1 < template.Length && template[i + 1] == '}')
				{
					stringBuilder.Append('}');
					i++;
					continue;
				}
				switch (c)
				{
				case '}':
					throw new FormatException($"Unmatched '}}' at {i} in \"{template}\".");
				default:
					stringBuilder.Append(c);
					break;
				case '{':
				{
					int num = template.IndexOf('}', i + 1);
					string text;
					if (num >= 0)
					{
						int num2 = i + 1;
						text = template.Substring(num2, num - num2);
					}
					else
					{
						text = string.Empty;
					}
					string text2 = text;
					if (text2.Length == 0 || text2.Length > 2 || !text2.All(char.IsAsciiDigit))
					{
						string text3;
						if (num >= 0)
						{
							int num2 = i;
							text3 = template.Substring(num2, num + 1 - num2);
						}
						else
						{
							text3 = template.Substring(i);
						}
						string value = text3;
						throw new FormatException($"Only {{n}} is a value; found \"{value}\" in \"{template}\".");
					}
					if (stringBuilder.Length > 0)
					{
						list.Add(new TemplatePart(stringBuilder.ToString(), -1));
						stringBuilder.Clear();
					}
					list.Add(new TemplatePart(string.Empty, int.Parse(text2, CultureInfo.InvariantCulture)));
					i = num;
					break;
				}
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(new TemplatePart(stringBuilder.ToString(), -1));
			}
			return list;
		}

		public static IReadOnlySet<int> Placeholders(string template)
		{
			return (from part in Parse(template)
				where part.IsValue
				select part.Value).ToHashSet();
		}

		public static IReadOnlyList<string> FindProblems(IEnumerable<string> keys, IReadOnlyDictionary<string, string> english, IReadOnlyDictionary<string, string> persian, IReadOnlyCollection<string>? sameInBothLanguages = null)
		{
			List<string> list = new List<string>();
			List<string> list2 = keys.ToList();
			foreach (string key in list2)
			{
				bool num = english.TryGetValue(key, out string value) && !string.IsNullOrWhiteSpace(value);
				bool flag = persian.TryGetValue(key, out string value2) && !string.IsNullOrWhiteSpace(value2);
				if (!num)
				{
					list.Add(key + ": no English text.");
				}
				if (!flag)
				{
					list.Add(key + ": no Persian text.");
				}
				if (!num || !flag)
				{
					continue;
				}
				string text = value;
				string text2 = value2;
				IReadOnlySet<int> readOnlySet;
				IReadOnlySet<int> readOnlySet2;
				try
				{
					readOnlySet = Placeholders(text);
					readOnlySet2 = Placeholders(text2);
				}
				catch (FormatException ex)
				{
					list.Add(key + ": " + ex.Message);
					continue;
				}
				if (!readOnlySet.SetEquals(readOnlySet2))
				{
					list.Add($"{key}: English uses {{{string.Join("}, {", readOnlySet.Order())}}} and Persian uses {{{string.Join("}, {", readOnlySet2.Order())}}}.");
				}
				if (!readOnlySet.SetEquals(Enumerable.Range(0, readOnlySet.Count)))
				{
					list.Add(key + ": values must be numbered from {0} without gaps.");
				}
				if (sameInBothLanguages == null || !sameInBothLanguages.Contains(key))
				{
					if (string.Equals(text, text2, StringComparison.Ordinal))
					{
						list.Add(key + ": the Persian text is a copy of the English.");
					}
					if (!text2.Any(IsPersianLetter))
					{
						list.Add(key + ": the Persian text has no Persian letter.");
					}
					list.AddRange(from problem in PersianStyleProblems(text2)
						select key + ": " + problem);
				}
			}
			foreach (string item in english.Keys.Concat(persian.Keys).Distinct().Except(list2))
			{
				list.Add(item + ": in a table but not a key.");
			}
			return list;
		}

		public static IReadOnlyList<string> FindProblems<TKey>(IReadOnlyDictionary<TKey, string> english, IReadOnlyDictionary<TKey, string> persian, IReadOnlyCollection<TKey>? sameInBothLanguages = null) where TKey : struct, Enum
		{
			return FindProblems(Enum.GetNames<TKey>(), english.ToDictionary((KeyValuePair<TKey, string> pair) => pair.Key.ToString(), (KeyValuePair<TKey, string> pair) => pair.Value), persian.ToDictionary((KeyValuePair<TKey, string> pair) => pair.Key.ToString(), (KeyValuePair<TKey, string> pair) => pair.Value), sameInBothLanguages?.Select((TKey key) => key.ToString()).ToList());
		}

		public static IReadOnlyList<string> PersianStyleProblems(string text)
		{
			List<string> list = new List<string>();
			if (text.IndexOfAny(new char[3] { ',', ';', '?' }) >= 0)
			{
				list.Add("uses an English , ; or ? - write ، ؛ ؟");
			}
			if (text.Contains('!'))
			{
				list.Add("uses !, which interface text never does");
			}
			if (text.Contains('"'))
			{
				list.Add("uses straight quotes - quote a label with « »");
			}
			if (text.IndexOfAny(new char[2] { 'ي', 'ك' }) >= 0)
			{
				list.Add("uses the Arabic ي or ك - write ی and ک");
			}
			if (MiWithSpace.IsMatch(text))
			{
				list.Add("writes می or نمی with a space - join it with a half-space (U+200C)");
			}
			if (text.Contains("ه\u200cی ", StringComparison.Ordinal) || text.EndsWith("ه\u200cی", StringComparison.Ordinal))
			{
				list.Add("writes the ezafe as ه\u200cی - write ه\u0654");
			}
			if (text.Contains("\u200c ", StringComparison.Ordinal) || text.Contains(" \u200c", StringComparison.Ordinal))
			{
				list.Add("has a half-space next to a space");
			}
			if (SpaceBeforePunctuation.IsMatch(text))
			{
				list.Add("has a space before punctuation");
			}
			if (text.Contains("  ", StringComparison.Ordinal))
			{
				list.Add("has a double space");
			}
			if (text.Length > 0)
			{
				if (!char.IsWhiteSpace(text[0]))
				{
					if (!char.IsWhiteSpace(text[text.Length - 1]))
					{
						goto IL_014d;
					}
				}
				list.Add("starts or ends with a space");
			}
			goto IL_014d;
			IL_014d:
			return list;
		}

		public static bool IsPersianLetter(char c)
		{
			if (c >= '\u0600' && c <= 'ۿ')
			{
				return char.IsLetter(c);
			}
			return false;
		}

		public static bool IsProseValue(object? value)
		{
			bool flag = ((value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint || value is long || value is ulong) ? true : false);
			if (!flag && (!(value is string value2) || !IsGroupedCount(value2)))
			{
				if (value != null)
				{
					return IsPersianPhrase(Convert.ToString(value, CultureInfo.InvariantCulture) ?? string.Empty);
				}
				return false;
			}
			return true;
		}

		private static bool IsGroupedCount(string value)
		{
			if (value.Length >= 3 && char.IsAsciiDigit(value[0]))
			{
				if (char.IsAsciiDigit(value[value.Length - 1]) && value.Contains("٬", StringComparison.Ordinal))
				{
					return value.All((char c) => char.IsAsciiDigit(c) || c == "٬"[0]);
				}
			}
			return false;
		}

		public static bool IsPersianPhrase(string value)
		{
			if (value.Any(IsPersianLetter))
			{
				return value.IndexOfAny(PathSeparators) < 0;
			}
			return false;
		}

		public static char OpeningIsolate(string value)
		{
			if (!IsPersianPhrase(value))
			{
				return '\u2068';
			}
			return '\u2067';
		}

		public static bool IsIsolated(string value)
		{
			bool flag = value.Length < 2;
			if (!flag)
			{
				bool flag2;
				switch (value[0])
				{
				case '\u2066':
				case '\u2067':
				case '\u2068':
					flag2 = true;
					break;
				default:
					flag2 = false;
					break;
				}
				flag = !flag2;
			}
			if (!flag)
			{
				if (value[value.Length - 1] == '\u2069')
				{
					int num = 0;
					for (int i = 0; i < value.Length; i++)
					{
						switch (value[i])
						{
						case '\u2066':
						case '\u2067':
						case '\u2068':
							flag = true;
							break;
						default:
							flag = false;
							break;
						}
						if (flag)
						{
							num++;
						}
						else if (value[i] == '\u2069' && --num == 0)
						{
							return i == value.Length - 1;
						}
					}
					return false;
				}
			}
			return false;
		}
	}
	public readonly record struct TemplatePart(string Text, int Value)
	{
		public bool IsValue => Value >= 0;
	}
}
namespace SmartInput.Core.Settings
{
	public enum AmbiguousInputPriority
	{
		Persian,
		English,
		Normal,
		Contextual
	}
	public static class AmbiguousInputPriorityPolicy
	{
		public static bool? ConvertsWordRecognizedInBoth(AmbiguousInputPriority priority, bool englishRecognized, bool persianRecognized)
		{
			bool flag = (uint)priority <= 1u;
			if (!(flag & englishRecognized & persianRecognized))
			{
				return null;
			}
			return priority == AmbiguousInputPriority.Persian;
		}

		public static bool? ConvertsWordRecognizedInBoth(AmbiguousInputPriority priority, bool englishRecognized, bool persianRecognized, BilingualContext context)
		{
			if (priority != AmbiguousInputPriority.Contextual)
			{
				return ConvertsWordRecognizedInBoth(priority, englishRecognized, persianRecognized);
			}
			if (!(englishRecognized & persianRecognized) || !BilingualWordPolicy.ConvertsByContext(context))
			{
				return null;
			}
			return true;
		}

		public static bool ConvertsIsolatedLetter(AmbiguousInputPriority priority)
		{
			return priority == AmbiguousInputPriority.Persian;
		}

		public static bool TypesWawAtOnce(AmbiguousInputPriority priority)
		{
			return priority == AmbiguousInputPriority.Persian;
		}
	}
	public sealed record AppSettings
	{
		public int SchemaVersion { get; init; } = 3;

		public GeneralSettings General { get; init; } = new GeneralSettings();

		public CorrectionSettings Correction { get; init; } = new CorrectionSettings();

		public DictionarySettings Dictionary { get; init; } = new DictionarySettings();

		public TranslationSettings Translation { get; init; } = new TranslationSettings();

		public HotkeySettings Hotkeys { get; init; } = new HotkeySettings();

		public LastWordSettings LastWord { get; init; } = new LastWordSettings();

		public SelectedWordSettings SelectedWord { get; init; } = new SelectedWordSettings();

		[JsonIgnore]
		public bool SavesSelectedWordCorrections => SelectedWord.EffectiveSaveToPersonalDictionary(Dictionary.AutoAddForcedConversions);

		[JsonIgnore]
		public bool SavesLastWordCorrections => LastWord.EffectiveSaveToPersonalDictionary(Dictionary.AutoAddForcedConversions);

		public const int CurrentSchemaVersion = 3;
	}
	public enum CapsLockBehavior
	{
		SwitchToEnglish = 0,
		SwitchToPersian = 1,
		AutomaticCorrectionWhileOn = 2,
		ManualCorrectionWhileOn = 4
	}
	public enum CapsLockLayoutTarget
	{
		None,
		English,
		Persian,
		PreviousLayout
	}
	public readonly record struct CapsLockDecision(bool ProcessCorrection, CorrectionMode CorrectionMode, bool NormalizeEnglishLetterCase = false);
	public static class CapsLockBehaviorPolicy
	{
		internal const int RetiredWindowsDefault = 3;

		public static bool IsLanguageSwitch(CapsLockBehavior behavior)
		{
			if ((uint)behavior <= 1u)
			{
				return true;
			}
			return false;
		}

		public static bool IsCorrectionWhileOn(CapsLockBehavior behavior)
		{
			if (behavior == CapsLockBehavior.AutomaticCorrectionWhileOn || behavior == CapsLockBehavior.ManualCorrectionWhileOn)
			{
				return true;
			}
			return false;
		}

		public static CapsLockBehavior Normalize(CapsLockBehavior behavior)
		{
			if (!Enum.IsDefined(behavior))
			{
				return CapsLockBehavior.SwitchToEnglish;
			}
			return behavior;
		}

		public static CapsLockDecision Resolve(TypingMode typingMode, CorrectionMode configuredCorrectionMode, CapsLockBehavior behavior, CapsLockEnglishTypingStyle englishTypingStyle, bool capsLockEnabled)
		{
			switch (typingMode)
			{
			case TypingMode.AutomaticCorrection:
			case TypingMode.ManualCorrection:
				if (!capsLockEnabled)
				{
					return new CapsLockDecision(ProcessCorrection: true, configuredCorrectionMode);
				}
				return new CapsLockDecision(ProcessCorrection: false, configuredCorrectionMode);
			default:
				return new CapsLockDecision(ProcessCorrection: false, configuredCorrectionMode);
			case TypingMode.CapsLockSwitch:
				if (!capsLockEnabled)
				{
					return new CapsLockDecision(ProcessCorrection: false, configuredCorrectionMode);
				}
				return Normalize(behavior) switch
				{
					CapsLockBehavior.SwitchToEnglish => new CapsLockDecision(ProcessCorrection: false, configuredCorrectionMode, englishTypingStyle == CapsLockEnglishTypingStyle.NormalCase), 
					CapsLockBehavior.AutomaticCorrectionWhileOn => new CapsLockDecision(ProcessCorrection: true, CorrectionMode.Automatic, NormalizeEnglishLetterCase: true), 
					CapsLockBehavior.ManualCorrectionWhileOn => new CapsLockDecision(ProcessCorrection: true, CorrectionMode.Manual, NormalizeEnglishLetterCase: true), 
					_ => new CapsLockDecision(ProcessCorrection: false, configuredCorrectionMode), 
				};
			}
		}

		public static bool TypesPersianDirectly(TypingMode typingMode, CapsLockBehavior behavior, bool capsLockEnabled, bool manualTypesDirectly)
		{
			if ((manualTypesDirectly & capsLockEnabled) && typingMode == TypingMode.CapsLockSwitch)
			{
				return Normalize(behavior) == CapsLockBehavior.ManualCorrectionWhileOn;
			}
			return false;
		}

		public static CorrectionMode ResolveCorrectionMode(TypingMode typingMode, CapsLockBehavior behavior, CorrectionMode configuredCorrectionMode)
		{
			if (typingMode != TypingMode.CapsLockSwitch)
			{
				return configuredCorrectionMode;
			}
			return Normalize(behavior) switch
			{
				CapsLockBehavior.AutomaticCorrectionWhileOn => CorrectionMode.Automatic, 
				CapsLockBehavior.ManualCorrectionWhileOn => CorrectionMode.Manual, 
				_ => configuredCorrectionMode, 
			};
		}

		public static CapsLockLayoutTarget ResolveLayoutTarget(CapsLockBehavior behavior, bool capsLockEnabled)
		{
			switch (Normalize(behavior))
			{
			case CapsLockBehavior.SwitchToEnglish:
				return capsLockEnabled ? CapsLockLayoutTarget.English : CapsLockLayoutTarget.Persian;
			case CapsLockBehavior.SwitchToPersian:
				return (!capsLockEnabled) ? CapsLockLayoutTarget.English : CapsLockLayoutTarget.Persian;
			case CapsLockBehavior.AutomaticCorrectionWhileOn:
			case CapsLockBehavior.ManualCorrectionWhileOn:
				return capsLockEnabled ? CapsLockLayoutTarget.English : CapsLockLayoutTarget.PreviousLayout;
			default:
				return CapsLockLayoutTarget.None;
			}
		}

		public static bool TryGetNormalCaseCharacter(int virtualKey, bool shiftDown, out char character)
		{
			if ((virtualKey < 65 || virtualKey > 90) ? true : false)
			{
				character = '\0';
				return false;
			}
			character = (char)((shiftDown ? 65 : 97) + virtualKey - 65);
			return true;
		}
	}
	public enum CapsLockEnglishTypingStyle
	{
		CapitalLetters,
		NormalCase
	}
	public enum CorrectionMode
	{
		Manual,
		Safe,
		Automatic
	}
	public sealed record CorrectionSettings
	{
		public CorrectionMode Mode { get; init; } = CorrectionMode.Automatic;

		public TypingEngine Engine { get; init; }

		public AmbiguousInputPriority AmbiguousInputPriority { get; init; } = AmbiguousInputPriority.Normal;

		public WordFormRecognition WordFormRecognition { get; init; } = WordFormRecognition.Full;

		public bool CorrectOnSpace { get; init; } = true;

		public bool CorrectOnEnter { get; init; } = true;

		public bool CorrectOnTab { get; init; } = true;

		public bool StabilizeMixedDirectionText { get; init; } = true;

		public bool ParagraphDirectionPrefix { get; init; } = true;

		public bool RewriteParagraphStartForDirection { get; init; } = true;

		public bool FormatPersianAmounts { get; init; } = true;

		public bool GuardAmountExpansion { get; init; } = true;

		public bool CorrectPersianTypos { get; init; }

		public bool UndoConversionOnBackspace { get; init; }

		public bool ReopenConvertedWordOnBackspace { get; init; } = true;

		public bool CapsLockManualTypesDirectly { get; init; } = true;

		public bool DirectTypingTypesAllLayoutCharacters { get; init; } = true;

		public bool WawAtOnceOnlyInPersianWords { get; init; } = true;

		public bool ProtectPaymentFields { get; init; } = true;

		public bool GuardVisibleFirstTokenRecovery { get; init; } = true;

		public bool VisibleRecoveryNeedsTypedKeys { get; init; } = true;

		public bool PersianHoldIsPersianContext { get; init; } = true;

		public bool PersianOnlyKeyMayBeEnglishTypo { get; init; } = true;

		public bool PersianOnlyKeyInsertionMayBeEnglishTypo { get; init; } = true;

		public bool ProtectEnglishInWholeTextConversion { get; init; } = true;

		public bool CommonPersianAdditions { get; init; } = true;

		public bool PunctuationKeyWordsConvert { get; init; } = true;

		public bool ContextualIgnoresCapitalizedTerms { get; init; } = true;

		public bool RestoreContextAfterRetype { get; init; } = true;

		public bool ForgetContextWhenTypedTextIsDeleted { get; init; } = true;

		public bool ReopenNeedsTrustedEditor { get; init; } = true;

		public bool ShortWordsIgnoreCapitalizedTerms { get; init; } = true;

		public bool BilingualKeptWordIsNeutralContext { get; init; } = true;

		public bool DirectionMarksAreWordBoundary { get; init; } = true;

		public bool PunctuationFollowsWordBeforeCaret { get; init; } = true;

		public bool PeriodMarkWaitsForBoundary { get; init; } = true;

		public bool PersianDigitsInPersianText { get; init; }

		public bool KeepEnglishInEnglishOnlyApps { get; init; } = true;

		public bool KeepNonTextTargetsUntouched { get; init; } = true;

		public PlaceIdList EnglishOnlyPlacesTurnedOff { get; init; } = PlaceIdList.Empty;

		public bool TrackEditorOwnedCorrections { get; init; } = true;

		public bool TrackTextServiceCorrections { get; init; } = true;

		public bool LearnEnglishFromManualCorrections { get; init; } = true;

		public bool ResetWordOnLayoutChange { get; init; } = true;

		public EnglishHoldKey EnglishHoldKey { get; init; }

		public HoldLanguage HoldLanguage { get; init; }

		public EnglishHoldKey PersianHoldKey { get; init; }

		public bool HoldKeyYieldsToShortcuts { get; init; } = true;

		public bool HeldBoundaryEndsEnglishLock { get; init; } = true;

		public bool CapitalizeEnglishAfterPersian { get; init; }

		public int AutomaticTargetThreshold { get; init; } = 60;

		public int AutomaticMarginThreshold { get; init; } = 25;

		public int UndoBackspaceWindowMs { get; init; } = 1200;

		public int UndoCtrlZWindowMs { get; init; } = 10000;
	}
	public sealed record DictionarySettings
	{
		public bool AutoAddForcedConversions { get; init; }
	}
	public enum EnglishHoldKey
	{
		None,
		LeftShift,
		RightShift,
		LeftCtrl,
		RightCtrl,
		LeftAlt,
		RightAlt,
		CapsLock
	}
	public static class EnglishHoldKeyPolicy
	{
		public static int VirtualKey(EnglishHoldKey key)
		{
			return key switch
			{
				EnglishHoldKey.LeftShift => 160, 
				EnglishHoldKey.RightShift => 161, 
				EnglishHoldKey.LeftCtrl => 162, 
				EnglishHoldKey.RightCtrl => 163, 
				EnglishHoldKey.LeftAlt => 164, 
				EnglishHoldKey.RightAlt => 165, 
				EnglishHoldKey.CapsLock => 20, 
				_ => 0, 
			};
		}

		public static bool IsEngaged(TypingMode typingMode, EnglishHoldKey key)
		{
			bool flag = (uint)typingMode <= 1u;
			if (flag && key != EnglishHoldKey.None)
			{
				return Enum.IsDefined(key);
			}
			return false;
		}

		public static bool IsHoldKey(TypingMode typingMode, EnglishHoldKey key, int virtualKey)
		{
			if (key != EnglishHoldKey.CapsLock && IsEngaged(typingMode, key))
			{
				return VirtualKey(key) == virtualKey;
			}
			return false;
		}

		public static bool IsCapsLockEnglishOn(TypingMode typingMode, EnglishHoldKey key, bool capsLockOn)
		{
			if ((key == EnglishHoldKey.CapsLock) & capsLockOn)
			{
				return IsEngaged(typingMode, key);
			}
			return false;
		}
	}
	public enum EnglishOnlyPlaceGroup
	{
		Field,
		Terminal,
		Launcher,
		DatabaseTool,
		RemoteDesktop,
		PasswordManager
	}
	public sealed record EnglishOnlyPlace(string Id, EnglishOnlyPlaceGroup Group, string? ProductName, IReadOnlyList<string> Processes, IReadOnlyList<string> WindowClasses);
	public static class EnglishOnlyPlaces
	{
		public const string BrowserAddressBar = "field:browser-address-bar";

		public const string WebAddressField = "field:web-address";

		public static IReadOnlyList<EnglishOnlyPlace> Fields { get; } = new <>z__ReadOnlyArray<EnglishOnlyPlace>(new EnglishOnlyPlace[2]
		{
			new EnglishOnlyPlace("field:browser-address-bar", EnglishOnlyPlaceGroup.Field, null, Array.Empty<string>(), Array.Empty<string>()),
			new EnglishOnlyPlace("field:web-address", EnglishOnlyPlaceGroup.Field, null, Array.Empty<string>(), Array.Empty<string>())
		});

		public static IReadOnlyList<EnglishOnlyPlace> Applications { get; } = new <>z__ReadOnlyArray<EnglishOnlyPlace>(new EnglishOnlyPlace[28]
		{
			App("app:windows-terminal", EnglishOnlyPlaceGroup.Terminal, "Windows Terminal", new string[2] { "windowsterminal", "openconsole" }, new string[1] { "CASCADIA_HOSTING_WINDOW_CLASS" }),
			App("app:console", EnglishOnlyPlaceGroup.Terminal, "Command Prompt / Windows PowerShell (console)", new string[3] { "conhost", "cmd", "powershell" }, new string[2] { "ConsoleWindowClass", "PseudoConsoleWindow" }),
			App("app:pwsh", EnglishOnlyPlaceGroup.Terminal, "PowerShell 7", new string[1] { "pwsh" }),
			App("app:wezterm", EnglishOnlyPlaceGroup.Terminal, "WezTerm", new string[1] { "wezterm-gui" }),
			App("app:alacritty", EnglishOnlyPlaceGroup.Terminal, "Alacritty", new string[1] { "alacritty" }),
			App("app:mintty", EnglishOnlyPlaceGroup.Terminal, "Git Bash (mintty)", new string[1] { "mintty" }, new string[1] { "mintty" }),
			App("app:putty", EnglishOnlyPlaceGroup.Terminal, "PuTTY", new string[1] { "putty" }, new string[1] { "PuTTY" }),
			App("app:kitty", EnglishOnlyPlaceGroup.Terminal, "KiTTY", new string[1] { "kitty" }),
			App("app:conemu", EnglishOnlyPlaceGroup.Terminal, "ConEmu / Cmder", new string[2] { "conemu", "conemu64" }, new string[1] { "VirtualConsoleClass" }),
			App("app:hyper", EnglishOnlyPlaceGroup.Terminal, "Hyper", new string[1] { "hyper" }),
			App("app:tabby", EnglishOnlyPlaceGroup.Terminal, "Tabby", new string[1] { "tabby" }),
			App("app:mobaxterm", EnglishOnlyPlaceGroup.Terminal, "MobaXterm", new string[1] { "mobaxterm" }),
			App("app:securecrt", EnglishOnlyPlaceGroup.Terminal, "SecureCRT", new string[1] { "securecrt" }),
			App("app:termius", EnglishOnlyPlaceGroup.Terminal, "Termius", new string[1] { "termius" }),
			App("app:powertoys-run", EnglishOnlyPlaceGroup.Launcher, "PowerToys Run", new string[1] { "PowerToys.PowerLauncher" }),
			App("app:everything", EnglishOnlyPlaceGroup.Launcher, "Everything", new string[1] { "Everything" }),
			App("app:ssms", EnglishOnlyPlaceGroup.DatabaseTool, "SQL Server Management Studio", new string[1] { "ssms" }),
			App("app:dbeaver", EnglishOnlyPlaceGroup.DatabaseTool, "DBeaver", new string[1] { "dbeaver" }),
			App("app:heidisql", EnglishOnlyPlaceGroup.DatabaseTool, "HeidiSQL", new string[1] { "heidisql" }),
			App("app:pgadmin", EnglishOnlyPlaceGroup.DatabaseTool, "pgAdmin 4", new string[1] { "pgadmin4" }),
			App("app:mysql-workbench", EnglishOnlyPlaceGroup.DatabaseTool, "MySQL Workbench", new string[1] { "mysqlworkbench" }),
			App("app:remote-desktop", EnglishOnlyPlaceGroup.RemoteDesktop, "Remote Desktop Connection (mstsc)", new string[1] { "mstsc" }),
			App("app:anydesk", EnglishOnlyPlaceGroup.RemoteDesktop, "AnyDesk", new string[1] { "anydesk" }),
			App("app:teamviewer", EnglishOnlyPlaceGroup.RemoteDesktop, "TeamViewer", new string[1] { "teamviewer" }),
			App("app:keepass", EnglishOnlyPlaceGroup.PasswordManager, "KeePass", new string[1] { "keepass" }),
			App("app:keepassxc", EnglishOnlyPlaceGroup.PasswordManager, "KeePassXC", new string[1] { "keepassxc" }),
			App("app:bitwarden", EnglishOnlyPlaceGroup.PasswordManager, "Bitwarden", new string[1] { "bitwarden" }),
			App("app:1password", EnglishOnlyPlaceGroup.PasswordManager, "1Password", new string[1] { "1password" })
		});

		public static EnglishOnlyPlace? ApplicationForProcess(string? processName)
		{
			if (!string.IsNullOrEmpty(processName))
			{
				return Applications.FirstOrDefault((EnglishOnlyPlace place) => place.Processes.Contains(processName, StringComparer.OrdinalIgnoreCase));
			}
			return null;
		}

		public static EnglishOnlyPlace? ApplicationForWindowClass(string? windowClass)
		{
			if (!string.IsNullOrEmpty(windowClass))
			{
				return Applications.FirstOrDefault((EnglishOnlyPlace place) => place.WindowClasses.Contains(windowClass, StringComparer.Ordinal));
			}
			return null;
		}

		public static bool KeepsEnglish(CorrectionSettings correction, string placeId)
		{
			PlaceIdList englishOnlyPlacesTurnedOff = correction.EnglishOnlyPlacesTurnedOff;
			if (englishOnlyPlacesTurnedOff != null && englishOnlyPlacesTurnedOff.Count > 0)
			{
				return !englishOnlyPlacesTurnedOff.Contains(placeId, StringComparer.Ordinal);
			}
			return true;
		}

		public static PlaceIdList WithPlace(IReadOnlyList<string>? turnedOff, string placeId, bool keepsEnglish)
		{
			HashSet<string> hashSet = new HashSet<string>(turnedOff ?? Array.Empty<string>(), StringComparer.Ordinal);
			if (keepsEnglish)
			{
				hashSet.Remove(placeId);
			}
			else
			{
				hashSet.Add(placeId);
			}
			List<string> known = (from place in Fields.Concat(Applications)
				select place.Id).Where(hashSet.Contains).ToList();
			known.AddRange(hashSet.Where((string id) => !known.Contains(id, StringComparer.Ordinal)).Order(StringComparer.Ordinal));
			return PlaceIdList.From(known);
		}

		private static EnglishOnlyPlace App(string id, EnglishOnlyPlaceGroup group, string name, string[] processes, string[]? classes = null)
		{
			return new EnglishOnlyPlace(id, group, name, processes, classes ?? Array.Empty<string>());
		}
	}
	public sealed record GeneralSettings
	{
		public bool Enabled { get; init; } = true;

		public bool? RunAtWindowsStartup { get; init; }

		public TypingMode TypingMode { get; init; }

		public CapsLockBehavior CapsLockBehavior { get; init; }

		public CapsLockEnglishTypingStyle CapsLockEnglishTypingStyle { get; init; }

		public PersianKeyboardLayout PersianKeyboardLayout { get; init; }

		public string? PreferredEnglishLayoutId { get; init; }

		public string? PreferredPersianLayoutId { get; init; }

		[JsonPropertyName("uiFontFamily")]
		public string TypingFontFamily { get; init; } = "Shabnam";

		public UiLanguage UiLanguage { get; init; }

		public bool CheckForUpdatesAutomatically { get; init; } = true;

		public bool IncludePreviewUpdates { get; init; } = true;

		public string UpdateFeedUrl { get; init; } = "https://diyar.digital/update.json";

		public bool RequireSignedUpdateManifest { get; init; } = true;

		public bool InstallUpdatesInApp { get; init; } = true;

		public bool DebugMode { get; init; }

		public bool ShiftLanguageSwitchEnabled { get; init; }

		public DetectedLanguage ShiftLanguageSwitchDefaultLanguage { get; init; } = DetectedLanguage.English;

		public DetectedLanguage ShiftLanguageSwitchSecondaryLanguage { get; init; } = DetectedLanguage.Persian;

		public ShiftSwitchTriggerKey ShiftLanguageSwitchTriggerKey { get; init; }

		public bool ShiftSwitchKeepsEmbeddingOpen { get; init; } = true;

		public const string DefaultTypingFontFamily = "Shabnam";

		public const string DefaultUpdateFeedUrl = "https://diyar.digital/update.json";

		public static readonly IReadOnlyList<string> RetiredUpdateFeedUrls = new <>z__ReadOnlyArray<string>(new string[2] { "https://diyar.iranux.site/update.json", "https://www.iranux.site/coco-typing/update.json" });
	}
	public readonly record struct HoldKeyBindings(EnglishHoldKey English, EnglishHoldKey Persian)
	{
		public static HoldKeyBindings From(CorrectionSettings correction)
		{
			EnglishHoldKey englishHoldKey = Defined(correction.EnglishHoldKey);
			EnglishHoldKey englishHoldKey2 = Defined(correction.PersianHoldKey);
			if (correction.HoldLanguage == HoldLanguage.Persian && englishHoldKey2 == EnglishHoldKey.None)
			{
				return new HoldKeyBindings(EnglishHoldKey.None, englishHoldKey);
			}
			return new HoldKeyBindings(englishHoldKey, (!Conflict(englishHoldKey, englishHoldKey2)) ? englishHoldKey2 : EnglishHoldKey.None);
		}

		public static bool Conflict(EnglishHoldKey first, EnglishHoldKey second)
		{
			if (first != EnglishHoldKey.None && second != EnglishHoldKey.None)
			{
				if (first != second)
				{
					if (Modifier(first) == Modifier(second))
					{
						return Modifier(first) != 0;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public bool TryGetHeldKeyLanguage(TypingMode typingMode, int virtualKey, out HoldLanguage language)
		{
			if (EnglishHoldKeyPolicy.IsHoldKey(typingMode, English, virtualKey))
			{
				language = HoldLanguage.English;
				return true;
			}
			if (EnglishHoldKeyPolicy.IsHoldKey(typingMode, Persian, virtualKey))
			{
				language = HoldLanguage.Persian;
				return true;
			}
			language = HoldLanguage.English;
			return false;
		}

		public HoldLanguage? CapsLockLanguage(TypingMode typingMode, bool capsLockOn)
		{
			if (!EnglishHoldKeyPolicy.IsCapsLockEnglishOn(typingMode, English, capsLockOn))
			{
				if (!EnglishHoldKeyPolicy.IsCapsLockEnglishOn(typingMode, Persian, capsLockOn))
				{
					return null;
				}
				return HoldLanguage.Persian;
			}
			return HoldLanguage.English;
		}

		private static EnglishHoldKey Defined(EnglishHoldKey key)
		{
			if (!Enum.IsDefined(key))
			{
				return EnglishHoldKey.None;
			}
			return key;
		}

		private static int Modifier(EnglishHoldKey key)
		{
			switch (key)
			{
			case EnglishHoldKey.LeftShift:
			case EnglishHoldKey.RightShift:
				return 1;
			case EnglishHoldKey.LeftCtrl:
			case EnglishHoldKey.RightCtrl:
				return 2;
			case EnglishHoldKey.LeftAlt:
			case EnglishHoldKey.RightAlt:
				return 3;
			default:
				return 0;
			}
		}
	}
	public enum HoldLanguage
	{
		English,
		Persian
	}
	public sealed record HotkeySettings
	{
		public string ConvertPreviousWord { get; init; } = "Ctrl+Alt+Space";

		public string UndoLastConversion { get; init; } = "Ctrl+Alt+Z";

		public string ToggleSelectedText { get; init; } = "Ctrl+Alt+Enter";

		public string AddSelectedToDictionary { get; init; } = "Ctrl+Alt+D";

		public string TranslateSelectedText { get; init; } = "Ctrl+Alt+T";

		public string ConvertNonDictionaryWords { get; init; } = "Ctrl+Alt+N";

		public string UndoManualCorrection { get; init; } = "Ctrl+Alt+U";

		public string TranslateClipboard { get; init; } = "Ctrl+Alt+Shift+T";

		public string PauseResume { get; init; } = "Ctrl+Alt+P";
	}
	public sealed record LastWordSettings
	{
		public bool Enabled { get; init; }

		public bool? SaveToPersonalDictionary { get; init; }

		public bool EffectiveSaveToPersonalDictionary(bool legacyAutoAdd)
		{
			return SaveToPersonalDictionary ?? legacyAutoAdd;
		}
	}
	public enum PersianKeyboardLayout
	{
		Automatic,
		PersianStandard,
		Persian
	}
	[JsonConverter(typeof(PlaceIdListJsonConverter))]
	[CollectionBuilder(typeof(PlaceIdList), "Create")]
	public sealed class PlaceIdList : IReadOnlyList<string>, IEnumerable<string>, IEnumerable, IReadOnlyCollection<string>, IEquatable<PlaceIdList>
	{
		private readonly string[] _items;

		public static PlaceIdList Empty { get; } = new PlaceIdList(Array.Empty<string>());

		public int Count => _items.Length;

		public string this[int index] => _items[index];

		private PlaceIdList(string[] items)
		{
			_items = items;
		}

		public static PlaceIdList Create(ReadOnlySpan<string> items)
		{
			if (!items.IsEmpty)
			{
				return new PlaceIdList(items.ToArray());
			}
			return Empty;
		}

		public static PlaceIdList From(IEnumerable<string>? items)
		{
			if (items != null)
			{
				return Create(items.ToArray());
			}
			return Empty;
		}

		public static implicit operator PlaceIdList(string[]? items)
		{
			return From(items);
		}

		public IEnumerator<string> GetEnumerator()
		{
			return ((IEnumerable<string>)_items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public bool Equals(PlaceIdList? other)
		{
			if (other != null)
			{
				return ((ReadOnlySpan<string>)_items.AsSpan()).SequenceEqual((ReadOnlySpan<string>)other._items);
			}
			return false;
		}

		public override bool Equals(object? obj)
		{
			return Equals(obj as PlaceIdList);
		}

		public override int GetHashCode()
		{
			HashCode hashCode = default;
			string[] items = _items;
			foreach (string value in items)
			{
				hashCode.Add(value, StringComparer.Ordinal);
			}
			return hashCode.ToHashCode();
		}

		public override string ToString()
		{
			return "[" + string.Join(",", _items) + "]";
		}
	}
	public sealed class PlaceIdListJsonConverter : JsonConverter<PlaceIdList>
	{
		public override bool HandleNull => true;

		public override PlaceIdList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.Null)
			{
				return PlaceIdList.From(JsonSerializer.Deserialize<string[]>(ref reader, options));
			}
			return PlaceIdList.Empty;
		}

		public override void Write(Utf8JsonWriter writer, PlaceIdList value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			foreach (string item in value ?? PlaceIdList.Empty)
			{
				writer.WriteStringValue(item);
			}
			writer.WriteEndArray();
		}
	}
	public sealed record SelectedWordSettings
	{
		public bool? SaveToPersonalDictionary { get; init; }

		public bool EffectiveSaveToPersonalDictionary(bool legacyAutoAdd)
		{
			return SaveToPersonalDictionary ?? legacyAutoAdd;
		}
	}
	public enum ShiftSwitchTriggerKey
	{
		Left,
		Right
	}
	public static class ShortcutCommandPolicy
	{
		public const int ToggleLastWord = 0;

		public const int UndoLastTranslation = 1;

		public const int ConvertSelectedWord = 2;

		public const int AddSelectedWord = 3;

		public const int TranslateSelectedText = 4;

		public const int ConvertNonDictionaryWords = 5;

		public const int UndoManualCorrection = 6;

		public const int TranslateClipboard = 7;

		public const int PauseResume = 8;

		public static IReadOnlyList<int> Listed { get; } = new <>z__ReadOnlyArray<int>(new int[8] { 8, 2, 0, 6, 3, 4, 7, 1 });

		public static bool IsOwnedByTextService(int command)
		{
			if (command == 0 || command == 2 || command == 6)
			{
				return true;
			}
			return false;
		}

		public static bool IsTranslation(int command)
		{
			if (command == 4 || command == 7)
			{
				return true;
			}
			return false;
		}

		public static bool IsRegistered(int command, bool lastWordActive, bool translationEnabled, bool selectedWordRouteAvailable)
		{
			switch (command)
			{
			case 1:
			case 4:
			case 7:
				return translationEnabled;
			case 0:
			case 2:
			case 6:
				return false;
			case 3:
				return true;
			case 8:
				return true;
			default:
				return false;
			}
		}
	}
	public enum ShortcutFailureReason
	{
		Invalid,
		Duplicate,
		TakenByAnotherApplication
	}
	public readonly record struct ShortcutFailure(string Label, string Value, ShortcutFailureReason Reason);
	public static class ShortcutRegistrationPolicy
	{
		public delegate bool TryParseGesture<TGesture>(string value, out TGesture gesture);

		public static IReadOnlyList<ShortcutFailure> RegisterEach<TGesture>(IReadOnlyList<string> labels, IReadOnlyList<string> values, TryParseGesture<TGesture> parse, Func<int, TGesture, bool> register, Func<int, bool>? isActive = null)
		{
			List<ShortcutFailure> list = new List<ShortcutFailure>();
			List<TGesture> list2 = new List<TGesture>();
			for (int i = 0; i < values.Count; i++)
			{
				if (isActive == null || isActive(i))
				{
					if (!parse(values[i], out var gesture))
					{
						list.Add(new ShortcutFailure(labels[i], values[i], ShortcutFailureReason.Invalid));
					}
					else if (list2.Contains(gesture))
					{
						list.Add(new ShortcutFailure(labels[i], values[i], ShortcutFailureReason.Duplicate));
					}
					else if (!register(i, gesture))
					{
						list.Add(new ShortcutFailure(labels[i], values[i], ShortcutFailureReason.TakenByAnotherApplication));
					}
					else
					{
						list2.Add(gesture);
					}
				}
			}
			return list;
		}

		public static string? Describe(IReadOnlyList<ShortcutFailure> failures, int total)
		{
			return Describe(failures, total, TextCatalog.Language);
		}

		public static string? Describe(IReadOnlyList<ShortcutFailure> failures, int total, UiLanguage language)
		{
			if (failures.Count == 0)
			{
				return null;
			}
			bool persian = language == UiLanguage.Persian;
			string text = string.Join(persian ? "، " : ", ", failures.Select((ShortcutFailure failure) => TextCatalog.Format("{0} ({1})", new <>z__ReadOnlyArray<object>(new object[2] { failure.Label, failure.Value }), persian)));
			string value = MessageText.Get(Cause(failures), language);
			string value2 = MessageText.Get(MessageKey.ShortcutsChooseDifferentKeys, language);
			if (failures.Count < total)
			{
				string value3 = ((failures.Count == 1) ? Fill(MessageKey.ShortcutsOneNotRegistered, language, text) : Fill(MessageKey.ShortcutsSomeNotRegistered, language, failures.Count, text));
				return $"{value3} {value} {MessageText.Get(MessageKey.ShortcutsOthersWork, language)} {value2}";
			}
			return $"{Fill(MessageKey.ShortcutsNoneRegistered, language, text)} {value} {value2}";
		}

		private static string Fill(MessageKey key, UiLanguage language, params object?[] values)
		{
			return TextCatalog.Format(MessageText.Get(key, language), values.Select((object value) => Isolated(value, language)).ToArray(), language == UiLanguage.Persian);
		}

		private static object? Isolated(object? value, UiLanguage language)
		{
			if (language != UiLanguage.Persian || !(value is string value2) || TextCatalog.IsIsolated(value2))
			{
				return value;
			}
			return $"{'\u2067'}{value2}{'\u2069'}";
		}

		private static MessageKey Cause(IReadOnlyList<ShortcutFailure> failures)
		{
			List<ShortcutFailureReason> list = failures.Select((ShortcutFailure failure) => failure.Reason).Distinct().ToList();
			if (list.Count > 1)
			{
				return MessageKey.ShortcutsCauseMixed;
			}
			return list[0] switch
			{
				ShortcutFailureReason.TakenByAnotherApplication => (failures.Count == 1) ? MessageKey.ShortcutCauseTaken : MessageKey.ShortcutsCauseTaken, 
				ShortcutFailureReason.Duplicate => (failures.Count == 1) ? MessageKey.ShortcutCauseDuplicate : MessageKey.ShortcutsCauseDuplicate, 
				_ => (failures.Count == 1) ? MessageKey.ShortcutCauseInvalid : MessageKey.ShortcutsCauseInvalid, 
			};
		}
	}
	public sealed record TranslationLanguage(string Code, MessageKey Name, string PromptName, bool IsRightToLeft)
	{
		public string DisplayName => MessageText.Get(Name);

		public override string ToString()
		{
			return DisplayName;
		}
	}
	public static class TranslationLanguageCatalog
	{
		public const string AutomaticCode = "auto";

		public static IReadOnlyList<TranslationLanguage> Languages { get; } = new <>z__ReadOnlyArray<TranslationLanguage>(new TranslationLanguage[13]
		{
			new TranslationLanguage("en", MessageKey.LanguageEnglish, "English", IsRightToLeft: false),
			new TranslationLanguage("fa", MessageKey.LanguagePersian, "Persian (Farsi)", IsRightToLeft: true),
			new TranslationLanguage("ar", MessageKey.LanguageArabic, "Arabic", IsRightToLeft: true),
			new TranslationLanguage("ur", MessageKey.LanguageUrdu, "Urdu", IsRightToLeft: true),
			new TranslationLanguage("fr", MessageKey.LanguageFrench, "French", IsRightToLeft: false),
			new TranslationLanguage("de", MessageKey.LanguageGerman, "German", IsRightToLeft: false),
			new TranslationLanguage("es", MessageKey.LanguageSpanish, "Spanish", IsRightToLeft: false),
			new TranslationLanguage("tr", MessageKey.LanguageTurkish, "Turkish", IsRightToLeft: false),
			new TranslationLanguage("ru", MessageKey.LanguageRussian, "Russian", IsRightToLeft: false),
			new TranslationLanguage("zh-Hans", MessageKey.LanguageChineseSimplified, "Simplified Chinese", IsRightToLeft: false),
			new TranslationLanguage("ja", MessageKey.LanguageJapanese, "Japanese", IsRightToLeft: false),
			new TranslationLanguage("ko", MessageKey.LanguageKorean, "Korean", IsRightToLeft: false),
			new TranslationLanguage("hi", MessageKey.LanguageHindi, "Hindi", IsRightToLeft: false)
		});

		public static TranslationLanguage English { get; } = Languages[0];

		public static TranslationLanguage Persian { get; } = Languages[1];

		public static TranslationLanguage Automatic { get; } = new TranslationLanguage("auto", MessageKey.LanguageAutomatic, English.PromptName, IsRightToLeft: false);

		public static IReadOnlyList<TranslationLanguage> Targets { get; }

		public static bool IsAutomatic(string? code)
		{
			return string.Equals(code, "auto", StringComparison.OrdinalIgnoreCase);
		}

		public static TranslationLanguage Resolve(string? code)
		{
			return Targets.FirstOrDefault((TranslationLanguage language) => string.Equals(language.Code, code, StringComparison.OrdinalIgnoreCase)) ?? English;
		}

		static TranslationLanguageCatalog()
		{
			TranslationLanguage automatic = Automatic;
			IReadOnlyList<TranslationLanguage> languages = Languages;
			int num = 0;
			TranslationLanguage[] array = new TranslationLanguage[1 + languages.Count];
			array[num] = automatic;
			num++;
			foreach (TranslationLanguage item in languages)
			{
				array[num] = item;
				num++;
			}
			Targets = new <>z__ReadOnlyArray<TranslationLanguage>(array);
		}
	}
	public sealed record TranslationModelOption(string Alias, MessageKey Name, MessageKey Size, MessageKey Summary)
	{
		public string DisplayName => MessageText.Get(Name);

		public string DownloadSize => MessageText.Get(Size);

		public string Description => MessageText.Get(Summary);

		public override string ToString()
		{
			return DisplayName + " (" + DownloadSize + ")";
		}
	}
	public static class TranslationModelCatalog
	{
		public static IReadOnlyList<TranslationModelOption> Models { get; } = new <>z__ReadOnlyArray<TranslationModelOption>(new TranslationModelOption[3]
		{
			new TranslationModelOption("qwen2.5-1.5b", MessageKey.ModelBalanced, MessageKey.ModelBalancedSize, MessageKey.ModelBalancedSummary),
			new TranslationModelOption("qwen2.5-0.5b", MessageKey.ModelCompact, MessageKey.ModelCompactSize, MessageKey.ModelCompactSummary),
			new TranslationModelOption("qwen2.5-7b", MessageKey.ModelQuality, MessageKey.ModelQualitySize, MessageKey.ModelQualitySummary)
		});

		public static TranslationModelOption Resolve(string? alias)
		{
			return Models.FirstOrDefault((TranslationModelOption model) => string.Equals(model.Alias, alias, StringComparison.OrdinalIgnoreCase)) ?? Models[0];
		}
	}
	public sealed record TranslationProviderOption(string Id, string DisplayName, string PrivacyLabel)
	{
		public override string ToString()
		{
			return DisplayName;
		}
	}
	public static class TranslationProviderCatalog
	{
		public static IReadOnlyList<TranslationProviderOption> Providers { get; } = new <>z__ReadOnlyArray<TranslationProviderOption>(new TranslationProviderOption[2]
		{
			new TranslationProviderOption("local", "On-device", "Text stays on this computer"),
			new TranslationProviderOption("azure", "Azure Translator", "Selected text is sent to Microsoft Azure")
		});

		public static TranslationProviderOption Resolve(string? id)
		{
			return Providers.FirstOrDefault((TranslationProviderOption provider) => string.Equals(provider.Id, id, StringComparison.OrdinalIgnoreCase)) ?? Providers[0];
		}
	}
	public sealed record TranslationSettings
	{
		public bool Enabled { get; init; }

		public string Provider { get; init; } = "local";

		public string TargetLanguage { get; init; } = "en";

		public string ModelAlias { get; init; } = "qwen2.5-1.5b";

		public bool UpdateParagraphDirection { get; init; } = true;

		public bool UndoWithUndoShortcut { get; init; } = true;

		public bool AllowClipboardFallback { get; init; } = true;

		public bool WarmUpLocalModel { get; init; }

		public string AzureRegion { get; init; } = "global";

		public const string LocalProvider = "local";

		public const string AzureProvider = "azure";

		public const string DefaultTargetLanguage = "en";

		public const string DefaultModelAlias = "qwen2.5-1.5b";
	}
	public enum TypingEngine
	{
		Smart,
		Classic
	}
	public static class TypingEnginePolicy
	{
		public static TypingEngine Resolve(TypingMode typingMode, TypingEngine chosen)
		{
			return TypingEngine.Smart;
		}

		public static bool IsSelectable(TypingMode typingMode)
		{
			return false;
		}
	}
	public enum TypingMode
	{
		AutomaticCorrection,
		ManualCorrection,
		CapsLockSwitch,
		ShiftLanguageSwitch
	}
	public enum UiLanguage
	{
		English,
		Persian
	}
	public enum WordFormRecognition
	{
		Off,
		Enclitics,
		Full
	}
	public static class WordFormRecognitionPolicy
	{
		public static bool RecognizesStandaloneEnclitics(WordFormRecognition value)
		{
			if ((uint)(value - 1) <= 1u)
			{
				return true;
			}
			return false;
		}

		public static bool AnalyzesSuffixes(WordFormRecognition value)
		{
			return value == WordFormRecognition.Full;
		}
	}
}
namespace SmartInput.Core.Models
{
	public enum DetectedLanguage
	{
		Unknown,
		Persian,
		English
	}
}
namespace SmartInput.Core.Keyboard
{
	public sealed class KeyboardLayoutDefinition
	{
		private readonly Dictionary<KeyboardLayoutKey, string> _mappings;

		private readonly Dictionary<char, KeyboardLayoutKey> _reverse;

		private const int SpaceKey = 32;

		private const int Oem102Key = 226;

		public string Id { get; }

		public string Name { get; }

		public string Language { get; }

		public string Version { get; }

		public string Source { get; }

		public string? WindowsLayoutId { get; }

		public string VersionedId => Id + "@" + Version;

		public IReadOnlyDictionary<KeyboardLayoutKey, string> Mappings => _mappings;

		public KeyboardLayoutDefinition(string id, string name, string language, string version, string source, string? windowsLayoutId, IReadOnlyDictionary<KeyboardLayoutKey, string> mappings)
		{
			Id = id;
			Name = name;
			Language = language;
			Version = version;
			Source = source;
			WindowsLayoutId = windowsLayoutId;
			_mappings = new Dictionary<KeyboardLayoutKey, string>(mappings);
			_reverse = new Dictionary<char, KeyboardLayoutKey>();
			foreach (var (value, text2) in (from pair in _mappings
				where pair.Value.Length == 1
				orderby pair.Key.Modifiers
				select pair).ThenBy((KeyValuePair<KeyboardLayoutKey, string> pair) =>
			{
				int virtualKey = pair.Key.VirtualKey;
				return (virtualKey == 32 || virtualKey == 226) ? true : false;
			}).ThenBy((KeyValuePair<KeyboardLayoutKey, string> pair) => pair.Key.VirtualKey))
			{
				_reverse.TryAdd(text2[0], value);
			}
		}

		public string? MapKey(int virtualKey, KeyModifiers modifiers)
		{
			if (!_mappings.TryGetValue(new KeyboardLayoutKey(virtualKey, modifiers), out string value))
			{
				return null;
			}
			return value;
		}

		public string? MapKey(KeyboardLayoutKey key)
		{
			return MapKey(key.VirtualKey, key.Modifiers);
		}

		public string? MapSequence(IEnumerable<KeyboardLayoutKey> keys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyboardLayoutKey key in keys)
			{
				string text = MapKey(key);
				if (text == null)
				{
					return null;
				}
				stringBuilder.Append(text);
			}
			return stringBuilder.ToString();
		}

		public bool IsValidMapping(KeyboardLayoutKey key)
		{
			return _mappings.ContainsKey(key);
		}

		public bool TryGetReverseMapping(char character, out KeyboardLayoutKey key)
		{
			return _reverse.TryGetValue(character, out key);
		}

		public bool IsWordCharacterKey(KeyboardLayoutKey key)
		{
			string text = MapKey(key);
			if (text != null && text.Length == 1)
			{
				return IsWordCharacter(text[0]);
			}
			return false;
		}

		public static bool IsWordCharacter(char character)
		{
			bool flag = character == '\u200c';
			if (!flag)
			{
				UnicodeCategory unicodeCategory = char.GetUnicodeCategory(character);
				bool flag2 = (((uint)unicodeCategory <= 1u || (uint)(unicodeCategory - 3) <= 2u) ? true : false);
				flag = flag2;
			}
			return flag;
		}

		public override string ToString()
		{
			return Name + " (" + VersionedId + ")";
		}
	}
	[Flags]
	public enum KeyModifiers
	{
		None = 0,
		Shift = 1,
		AltGr = 2
	}
	public readonly record struct KeyboardLayoutKey(int VirtualKey, KeyModifiers Modifiers)
	{
		public override string ToString()
		{
			if (Modifiers == KeyModifiers.None)
			{
				return $"0x{VirtualKey:X2}";
			}
			return $"{Modifiers}+0x{VirtualKey:X2}";
		}
	}
	public static class KeyboardLayoutRegistry
	{
		private sealed record Loaded(IReadOnlyList<KeyboardLayoutDefinition> Layouts, IReadOnlyList<string> Errors);

		private sealed record LayoutFile(string? Id, string? Name, string? Language, string? Version, string? Source, string? WindowsLayoutId, IReadOnlyList<LayoutKeyEntry>? Keys);

		private sealed record LayoutKeyEntry(string? Vk, string? Normal, string? Shift, string? AltGr);

		public const string EnglishUsId = "en-us";

		public const string PersianStandardId = "fa-standard";

		public const string PersianLegacyId = "fa-legacy";

		private const string ResourcePrefix = "SmartInput.KeyboardLayouts.";

		public static readonly IReadOnlyList<int> RequiredVirtualKeys;

		private static readonly Lazy<Loaded> BuiltIn;

		private static readonly JsonSerializerOptions JsonOptions;

		public static IReadOnlyList<string> LoadErrors => BuiltIn.Value.Errors;

		public static string SourceIdentity
		{
			get
			{
				if (!TryGetLayout("en-us", out KeyboardLayoutDefinition layout))
				{
					return "en-us";
				}
				return layout.VersionedId;
			}
		}

		public static IReadOnlyList<KeyboardLayoutDefinition> GetSupportedLayouts()
		{
			return BuiltIn.Value.Layouts;
		}

		public static KeyboardLayoutDefinition GetLayout(string id)
		{
			if (!TryGetLayout(id, out KeyboardLayoutDefinition layout))
			{
				throw new KeyNotFoundException("Keyboard layout '" + id + "' is not available.");
			}
			return layout;
		}

		public static bool TryGetLayout(string id, out KeyboardLayoutDefinition layout)
		{
			layout = BuiltIn.Value.Layouts.FirstOrDefault((KeyboardLayoutDefinition candidate) => string.Equals(candidate.Id, id, StringComparison.OrdinalIgnoreCase));
			return layout != null;
		}

		public static IReadOnlyList<KeyboardLayoutDefinition> GetPersianTargets(PersianKeyboardLayout setting)
		{
			return (setting switch
			{
				PersianKeyboardLayout.PersianStandard => (IEnumerable<string>)new <>z__ReadOnlySingleElementList<string>("fa-standard"), 
				PersianKeyboardLayout.Persian => new <>z__ReadOnlySingleElementList<string>("fa-legacy"), 
				_ => new <>z__ReadOnlyArray<string>(new string[2] { "fa-standard", "fa-legacy" }), 
			}).Select((string id) => (!TryGetLayout(id, out KeyboardLayoutDefinition layout)) ? null : layout).OfType<KeyboardLayoutDefinition>().ToArray();
		}

		public static string GetTargetIdentity(PersianKeyboardLayout setting)
		{
			return string.Join('+', from layout in GetPersianTargets(setting)
				select layout.VersionedId);
		}

		public static KeyboardLayoutDefinition? Parse(string json, out IReadOnlyList<string> errors)
		{
			List<string> problems = new List<string>();
			errors = problems;
			LayoutFile layoutFile;
			try
			{
				layoutFile = JsonSerializer.Deserialize<LayoutFile>(json, JsonOptions);
			}
			catch (JsonException ex)
			{
				problems.Add("Invalid JSON: " + ex.Message);
				return null;
			}
			if ((object)layoutFile == null)
			{
				problems.Add("The definition is empty.");
				return null;
			}
			string label = (string.IsNullOrWhiteSpace(layoutFile.Id) ? "(no id)" : layoutFile.Id);
			RequireText(layoutFile.Id, "id");
			RequireText(layoutFile.Name, "name");
			RequireText(layoutFile.Language, "language");
			RequireText(layoutFile.Version, "version");
			RequireText(layoutFile.Source, "source");
			Dictionary<KeyboardLayoutKey, string> mappings = new Dictionary<KeyboardLayoutKey, string>();
			foreach (LayoutKeyEntry item in layoutFile.Keys ?? Array.Empty<LayoutKeyEntry>())
			{
				if (!TryParseVirtualKey(item.Vk, out var virtualKey))
				{
					problems.Add(label + ": invalid virtual key '" + item.Vk + "'.");
					continue;
				}
				Add(new KeyboardLayoutKey(virtualKey, KeyModifiers.None), item.Normal);
				Add(new KeyboardLayoutKey(virtualKey, KeyModifiers.Shift), item.Shift);
				Add(new KeyboardLayoutKey(virtualKey, KeyModifiers.AltGr), item.AltGr);
			}
			foreach (int requiredVirtualKey in RequiredVirtualKeys)
			{
				KeyModifiers[] array = new KeyModifiers[2]
				{
					KeyModifiers.None,
					KeyModifiers.Shift
				};
				foreach (KeyModifiers modifiers in array)
				{
					if (!mappings.ContainsKey(new KeyboardLayoutKey(requiredVirtualKey, modifiers)))
					{
						problems.Add($"{label}: required key {new KeyboardLayoutKey(requiredVirtualKey, modifiers)} is not mapped.");
					}
				}
			}
			if (problems.Count <= 0)
			{
				return new KeyboardLayoutDefinition(layoutFile.Id, layoutFile.Name, layoutFile.Language, layoutFile.Version, layoutFile.Source, layoutFile.WindowsLayoutId, mappings);
			}
			return null;
			void Add(KeyboardLayoutKey key, string? output)
			{
				if (output != null)
				{
					if (!mappings.TryAdd(key, output))
					{
						problems.Add($"{label}: key {key} is defined twice.");
					}
					else if (!IsValidOutput(output))
					{
						problems.Add($"{label}: key {key} types invalid text.");
					}
				}
			}
			void RequireText(string? value, string field)
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					problems.Add(label + ": '" + field + "' is required.");
				}
			}
		}

		internal static bool IsValidOutput(string output)
		{
			if (output.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < output.Length; i++)
			{
				char c = output[i];
				if (char.IsSurrogate(c))
				{
					if (!char.IsHighSurrogate(c) || i + 1 >= output.Length || !char.IsLowSurrogate(output[i + 1]))
					{
						return false;
					}
					i++;
				}
				else
				{
					UnicodeCategory unicodeCategory = char.GetUnicodeCategory(c);
					if ((unicodeCategory == UnicodeCategory.Control || unicodeCategory == UnicodeCategory.PrivateUse || unicodeCategory == UnicodeCategory.OtherNotAssigned) ? true : false)
					{
						return false;
					}
				}
			}
			return true;
		}

		private static bool TryParseVirtualKey(string? text, out int virtualKey)
		{
			virtualKey = 0;
			if (text != null && text.Length > 2 && text.StartsWith("0x", StringComparison.OrdinalIgnoreCase) && int.TryParse(text.AsSpan(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out virtualKey))
			{
				int num = virtualKey;
				if (num > 0)
				{
					return num < 255;
				}
				return false;
			}
			return false;
		}

		private static Loaded LoadBuiltIn()
		{
			Assembly assembly = typeof(KeyboardLayoutRegistry).Assembly;
			List<KeyboardLayoutDefinition> list = new List<KeyboardLayoutDefinition>();
			List<string> list2 = new List<string>();
			foreach (string name in (from text in assembly.GetManifestResourceNames()
				where text.StartsWith("SmartInput.KeyboardLayouts.", StringComparison.Ordinal)
				select text).Order(StringComparer.Ordinal))
			{
				using Stream stream = assembly.GetManifestResourceStream(name);
				using StreamReader streamReader = new StreamReader(stream);
				KeyboardLayoutDefinition layout = Parse(streamReader.ReadToEnd(), out IReadOnlyList<string> errors);
				if (layout == null)
				{
					list2.AddRange(errors.Select((string error) => name + ": " + error));
				}
				else if (list.Any((KeyboardLayoutDefinition existing) => string.Equals(existing.Id, layout.Id, StringComparison.OrdinalIgnoreCase)))
				{
					list2.Add(name + ": layout id '" + layout.Id + "' is already defined.");
				}
				else
				{
					list.Add(layout);
				}
			}
			return new Loaded(list, list2);
		}

		static KeyboardLayoutRegistry()
		{
			List<int> list = new List<int>();
			list.AddRange(Enumerable.Range(48, 10));
			list.AddRange(Enumerable.Range(65, 26));
			list.Add(186);
			list.Add(187);
			list.Add(188);
			list.Add(189);
			list.Add(190);
			list.Add(191);
			list.Add(192);
			list.Add(219);
			list.Add(220);
			list.Add(221);
			list.Add(222);
			RequiredVirtualKeys = new <>z__ReadOnlyList<int>(list);
			BuiltIn = new Lazy<Loaded>(LoadBuiltIn);
			JsonOptions = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true,
				ReadCommentHandling = JsonCommentHandling.Skip,
				AllowTrailingCommas = true
			};
		}
	}
}
namespace SmartInput.Core.Environments
{
	public enum CapabilityName
	{
		ReadLocalContext,
		ReadCaretRange,
		ReadSelectionRanges,
		SelectRangeInterface,
		SetWholeValueInterface,
		NativeSelectionRead,
		ReadCompositionState,
		ReadParagraphDirection,
		SetParagraphDirectionInterface,
		ReadAlignment,
		SetAlignmentInterface,
		PreserveRichFormatting,
		AtomicRangeEdit,
		ObserveTextChanges,
		ObserveSelectionChanges,
		UnicodeInputAcceptance,
		TextChangeSubscription,
		SelectionChangeSubscription
	}
	public sealed record CapabilityEvidence
	{
		public required CapabilityName Name { get; init; }

		public ReportedSupport ReportedSupport { get; init; }

		public ObservationStatus ObservationStatus { get; init; }

		public string EvidenceSource { get; init; } = string.Empty;

		public string ReasonCode { get; init; } = string.Empty;

		public int ObservedEpoch { get; init; }

		public long ObservedAtHostTicks { get; init; }

		public static long ElapsedSinceObservation(CapabilityEvidence evidence, long currentHostTicks, long ticksPerMillisecond)
		{
			if (ticksPerMillisecond <= 0)
			{
				throw new ArgumentOutOfRangeException("ticksPerMillisecond");
			}
			long num = currentHostTicks - evidence.ObservedAtHostTicks;
			if (num > 0)
			{
				return num / ticksPerMillisecond;
			}
			return 0L;
		}
	}
	public static class CapabilityEvidenceSet
	{
		public static ImmutableArray<CapabilityEvidence> Empty { get; } = ImmutableArray<CapabilityEvidence>.Empty;

		public static bool HasNoPhase1Probe(CapabilityName name)
		{
			switch (name)
			{
			case CapabilityName.SelectRangeInterface:
			case CapabilityName.SetWholeValueInterface:
			case CapabilityName.SetParagraphDirectionInterface:
			case CapabilityName.SetAlignmentInterface:
			case CapabilityName.PreserveRichFormatting:
			case CapabilityName.AtomicRangeEdit:
			case CapabilityName.UnicodeInputAcceptance:
				return true;
			default:
				return false;
			}
		}

		public static ImmutableArray<CapabilityEvidence> AllNotAttempted()
		{
			CapabilityName[] values = Enum.GetValues<CapabilityName>();
			ImmutableArray<CapabilityEvidence>.Builder builder = ImmutableArray.CreateBuilder<CapabilityEvidence>(values.Length);
			CapabilityName[] array = values;
			foreach (CapabilityName name in array)
			{
				builder.Add(new CapabilityEvidence
				{
					Name = name,
					ReasonCode = (HasNoPhase1Probe(name) ? "ProbeNotImplemented" : string.Empty)
				});
			}
			return builder.ToImmutable();
		}
	}
	public static class EnvironmentReasonCodes
	{
		public const string ProtectionUnknown = "ProtectionUnknown";

		public const string PasswordReported = "PasswordReported";

		public const string FocusChanged = "FocusChanged";

		public const string SurfaceUnresolved = "SurfaceUnresolved";

		public const string ProviderTimeout = "ProviderTimeout";

		public const string AccessDenied = "AccessDenied";

		public const string ElementGone = "ElementGone";

		public const string CaretInactive = "CaretInactive";

		public const string MultipleSelections = "MultipleSelections";

		public const string NoLocalTextRange = "NoLocalTextRange";

		public const string CompositionActive = "CompositionActive";

		public const string CompositionUnknown = "CompositionUnknown";

		public const string ReadOnlyReported = "ReadOnlyReported";

		public const string ConflictingMetadata = "ConflictingMetadata";

		public const string ProfileUnvalidated = "ProfileUnvalidated";

		public const string ContextTruncated = "ContextTruncated";

		public const string NoAtomicEditContract = "NoAtomicEditContract";

		public const string ObserverUnavailable = "ObserverUnavailable";

		public const string RemoteOrTerminalOrCodeSurface = "RemoteOrTerminalOrCodeSurface";

		public const string OwnApplicationSurface = "OwnApplicationSurface";

		public const string DesktopOrSessionUnavailable = "DesktopOrSessionUnavailable";

		public const string NonTextControl = "NonTextControl";

		public const string SelectionEvidenceIncomplete = "SelectionEvidenceIncomplete";

		public const string SuspectedStaleOrContradictory = "SuspectedStaleOrContradictory";

		public const string ProbeNotImplemented = "ProbeNotImplemented";

		public const string ChangeOutsideSampledRangePossible = "ChangeOutsideSampledRangePossible";

		public const string ProviderContractViolation = "ProviderContractViolation";

		public const string AttributeMixed = "AttributeMixed";

		public const string AttributeUnsupported = "AttributeUnsupported";

		public const string AttributeReported = "AttributeReported";

		public const string AttributeReadFailed = "AttributeReadFailed";

		public const string RegistrationOnly = "RegistrationOnly";

		public const string NoEventsDelivered = "NoEventsDelivered";

		public const string EventsDelivered = "EventsDelivered";

		public const string SessionResumed = "SessionResumed";

		public const string ContextChangeReported = "ContextChangeReported";

		public static IReadOnlySet<string> All { get; } = (from field in typeof(EnvironmentReasonCodes).GetFields(BindingFlags.Static | BindingFlags.Public)
			where field.IsLiteral && field.FieldType == typeof(string)
			select (string)field.GetRawConstantValue()).ToHashSet(StringComparer.Ordinal);
	}
	public sealed record EnvironmentAssessmentInputs
	{
		public ProtectionState Protection { get; init; }

		public bool DesktopOrSessionUnavailable { get; init; }

		public IdentityStrength IdentityStrength { get; init; }

		public Editability Editability { get; init; }

		public bool IsPositivelyNonText { get; init; }

		public bool IsMetadataOnlySurface { get; init; }

		public CompositionState Composition { get; init; }

		public bool HasLocalReadRoute { get; init; }

		public ContextHealth ContextHealth { get; init; }

		public bool CaretOrSelectionEvidenceComplete { get; init; }

		public bool SuspectedStaleOrContradictory { get; init; }
	}
	public sealed record EnvironmentAssessment
	{
		public required AssessmentKind Kind { get; init; }

		public required bool ContentReadsPermitted { get; init; }

		public bool TextMutationAuthorized { get; }

		public required ImmutableArray<string> ReasonCodes { get; init; }
	}
	public static class EnvironmentAssessmentPolicy
	{
		public static EnvironmentAssessment Assess(EnvironmentAssessmentInputs inputs)
		{
			ArgumentNullException.ThrowIfNull(inputs, "inputs");
			if (inputs.Protection == ProtectionState.Protected)
			{
				return Build(AssessmentKind.Protected, false, "PasswordReported");
			}
			if (inputs.DesktopOrSessionUnavailable)
			{
				return Build(AssessmentKind.Unavailable, false, "DesktopOrSessionUnavailable");
			}
			if (inputs.IdentityStrength == IdentityStrength.None || inputs.Protection == ProtectionState.Unknown)
			{
				string text = ((inputs.IdentityStrength == IdentityStrength.None) ? "SurfaceUnresolved" : "ProtectionUnknown");
				return Build(AssessmentKind.Unknown, false, text);
			}
			if (inputs.Editability == Editability.ReadOnly || inputs.IsPositivelyNonText)
			{
				string text2 = (inputs.IsPositivelyNonText ? "NonTextControl" : "ReadOnlyReported");
				return Build(AssessmentKind.NotEditable, false, text2);
			}
			if (inputs.IsMetadataOnlySurface)
			{
				return Build(AssessmentKind.MetadataOnly, false, "RemoteOrTerminalOrCodeSurface");
			}
			if (inputs.Composition == CompositionState.ActiveReported)
			{
				return Build(AssessmentKind.CompositionInProgress, false, "CompositionActive");
			}
			if (!inputs.HasLocalReadRoute)
			{
				return Build(AssessmentKind.MetadataOnly, false, "NoLocalTextRange", "NoAtomicEditContract");
			}
			bool flag = inputs.SuspectedStaleOrContradictory;
			if (!flag)
			{
				ContextHealth contextHealth = inputs.ContextHealth;
				bool flag2 = (uint)(contextHealth - 3) <= 1u;
				flag = flag2;
			}
			if (flag)
			{
				return Build(AssessmentKind.Degraded, false, "SuspectedStaleOrContradictory");
			}
			if (inputs.ContextHealth == ContextHealth.ReadObserved || inputs.ContextHealth == ContextHealth.ChangeObserved)
			{
				if (inputs.CaretOrSelectionEvidenceComplete)
				{
					return Build(AssessmentKind.ContextAndSelectionObserved, true, "NoAtomicEditContract");
				}
				return Build(AssessmentKind.ContextObserved, true, "SelectionEvidenceIncomplete", "NoAtomicEditContract");
			}
			return Build(AssessmentKind.MetadataOnly, false, "CompositionUnknown", "NoLocalTextRange");
		}

		private static EnvironmentAssessment Build(AssessmentKind kind, bool contentReadsPermitted, params string[] reasonCodes)
		{
			return new EnvironmentAssessment
			{
				Kind = kind,
				ContentReadsPermitted = contentReadsPermitted,
				ReasonCodes = ImmutableArray.Create(reasonCodes)
			};
		}
	}
	public enum ReportedSupport
	{
		Unknown,
		Supported,
		Unsupported
	}
	public enum ObservationStatus
	{
		NotAttempted,
		Succeeded,
		Unsupported,
		TimedOut,
		AccessDenied,
		ElementGone,
		Invalid,
		Failed
	}
	public enum ProtectionState
	{
		Unknown,
		Protected,
		OrdinaryReported
	}
	public enum Editability
	{
		Unknown,
		ReadOnly,
		EditableReported
	}
	public enum IdentityStrength
	{
		None,
		WindowOnly,
		ElementScoped
	}
	public enum ContextHealth
	{
		Unknown,
		ReadObserved,
		ChangeObserved,
		SuspectedStale,
		Contradictory
	}
	public enum TextOrderEvidence
	{
		Unknown,
		FixtureValidatedLogical,
		ProviderConflict
	}
	public enum CompositionState
	{
		Unknown,
		ActiveReported,
		InactiveReported
	}
	public enum ObservationMode
	{
		MetadataOnly,
		BoundedContext
	}
	public enum FieldRole
	{
		Unknown,
		GeneralText,
		Search,
		AddressOrSearch,
		Url,
		Email,
		Numeric,
		Code,
		Terminal,
		Password,
		NonText
	}
	public enum RoleEvidenceKind
	{
		None,
		ProviderDeclared,
		ValidatedProfile,
		Structural,
		HintOnly
	}
	public enum SurfaceKind
	{
		Unknown,
		NativeEdit,
		NativeRichEdit,
		AccessibleEdit,
		AccessibleDocument,
		BrowserChrome,
		BrowserPage,
		RemoteSurface,
		NonText
	}
	public enum AssessmentKind
	{
		Protected,
		Unavailable,
		Unknown,
		NotEditable,
		MetadataOnly,
		CompositionInProgress,
		ContextObserved,
		ContextAndSelectionObserved,
		Degraded
	}
	public sealed record EnvironmentObservationOptions
	{
		public static EnvironmentObservationOptions Default { get; } = new EnvironmentObservationOptions();

		public TimeSpan FocusProbeDebounce { get; init; } = TimeSpan.FromMilliseconds(30L);

		public TimeSpan TextSelectionEventCoalescing { get; init; } = TimeSpan.FromMilliseconds(75L);

		public TimeSpan MetadataFocusReconciliationInterval { get; init; } = TimeSpan.FromMilliseconds(500L);

		public TimeSpan UiaConnectionTimeout { get; init; } = TimeSpan.FromMilliseconds(250L);

		public TimeSpan UiaTransactionTimeout { get; init; } = TimeSpan.FromMilliseconds(250L);

		public TimeSpan TotalProbeSchedulingBudget { get; init; } = TimeSpan.FromMilliseconds(500L);

		public TimeSpan HelperRequestWatchdog { get; init; } = TimeSpan.FromMilliseconds(1500L);

		public TimeSpan HelperStartupDeadline { get; init; } = TimeSpan.FromSeconds(5L);

		public TimeSpan ShutdownGrace { get; init; } = TimeSpan.FromMilliseconds(500L);

		public int MaxAutomaticRestartsPerRollingWindow { get; init; } = 2;

		public TimeSpan RestartRollingWindow { get; init; } = TimeSpan.FromSeconds(60L);

		public TimeSpan RestartCooldown { get; init; } = TimeSpan.FromSeconds(60L);

		public TimeSpan FocusMetadataAgeLimit { get; init; } = TimeSpan.FromMilliseconds(1500L);

		public int MaxAncestorTraversalNodes { get; init; } = 6;

		public int MaxIdentityAncestorNodes { get; init; } = 16;

		public int MaxContextReadsPerSecond { get; init; } = 5;

		public TimeSpan RawContextRetentionLimit { get; init; } = TimeSpan.FromSeconds(2L);

		public int MaxExportHistoryEvents { get; init; } = 1000;

		public int MaxFramePayloadBytes { get; init; } = 65536;

		public int MaxJsonDepth { get; init; } = 16;

		public int MaxStructuralStringLength { get; init; } = 256;

		public int MaxRuntimeIdLength { get; init; } = 128;

		public int MaxAncestryNodes { get; init; } = 6;

		public int MaxCharacterUnitsBeforeCaret { get; init; } = 128;

		public int MaxCharacterUnitsAfterCaret { get; init; } = 32;

		public int MaxContextTextUtf16CodeUnits { get; init; } = 256;

		public TimeSpan NativeMessageTimeout { get; init; } = TimeSpan.FromMilliseconds(50L);
	}
	public sealed record EnvironmentProfileAncestorCondition
	{
		public string? AutomationIdPattern { get; init; }

		public string? ControlTypePattern { get; init; }

		public string? ClassNamePattern { get; init; }
	}
	public sealed record EnvironmentProfile
	{
		public required string ProfileId { get; init; }

		public required int ProfileVersion { get; init; }

		public required string ProcessExecutableBaseName { get; init; }

		public string? MinTestedApplicationVersion { get; init; }

		public string? MaxTestedApplicationVersion { get; init; }

		public string? UiaFrameworkId { get; init; }

		public string? ExactOrPatternConstrainedAutomationId { get; init; }

		public ImmutableArray<EnvironmentProfileAncestorCondition> AncestorConditions { get; init; } = ImmutableArray<EnvironmentProfileAncestorCondition>.Empty;

		public ImmutableArray<string> ExclusionAutomationIds { get; init; } = ImmutableArray<string>.Empty;

		public required FieldRole InferredRole { get; init; }

		public ImmutableArray<string> FixtureReferences { get; init; } = ImmutableArray<string>.Empty;
	}
	public sealed record EnvironmentProfileMatchQuery
	{
		public required string ProcessExecutableBaseName { get; init; }

		public string? ApplicationVersion { get; init; }

		public string? UiaFrameworkId { get; init; }

		public string? AutomationId { get; init; }

		public ImmutableArray<string> AncestorAutomationIds { get; init; } = ImmutableArray<string>.Empty;
	}
	public sealed record EnvironmentProfileMatch
	{
		public required EnvironmentProfile Profile { get; init; }

		public required bool IsValidated { get; init; }
	}
	public sealed class EnvironmentProfileRegistry
	{
		private readonly ImmutableArray<EnvironmentProfile> _profiles;

		public static EnvironmentProfileRegistry Empty { get; } = new EnvironmentProfileRegistry(Array.Empty<EnvironmentProfile>());

		public ImmutableArray<EnvironmentProfile> Profiles => _profiles;

		public EnvironmentProfileRegistry(IEnumerable<EnvironmentProfile> profiles)
		{
			ArgumentNullException.ThrowIfNull(profiles, "profiles");
			_profiles = profiles.ToImmutableArray();
		}

		public EnvironmentProfileMatch? Match(EnvironmentProfileMatchQuery query)
		{
			ArgumentNullException.ThrowIfNull(query, "query");
			foreach (EnvironmentProfile profile in _profiles)
			{
				if (string.Equals(profile.ProcessExecutableBaseName, query.ProcessExecutableBaseName, StringComparison.OrdinalIgnoreCase))
				{
					string exactOrPatternConstrainedAutomationId = profile.ExactOrPatternConstrainedAutomationId;
					if ((exactOrPatternConstrainedAutomationId == null || exactOrPatternConstrainedAutomationId.Length <= 0 || string.Equals(exactOrPatternConstrainedAutomationId, query.AutomationId, StringComparison.Ordinal)) && !profile.ExclusionAutomationIds.Contains(query.AutomationId ?? string.Empty, StringComparer.Ordinal))
					{
						bool isValidated = IsWithinTestedRange(profile, query.ApplicationVersion);
						return new EnvironmentProfileMatch
						{
							Profile = profile,
							IsValidated = isValidated
						};
					}
				}
			}
			return null;
		}

		private static bool IsWithinTestedRange(EnvironmentProfile profile, string? applicationVersion)
		{
			if (applicationVersion == null)
			{
				return false;
			}
			if (!Version.TryParse(NormalizeVersion(applicationVersion), out Version result))
			{
				return false;
			}
			string minTestedApplicationVersion = profile.MinTestedApplicationVersion;
			if (minTestedApplicationVersion != null && minTestedApplicationVersion.Length > 0 && Version.TryParse(NormalizeVersion(minTestedApplicationVersion), out Version result2) && result < result2)
			{
				return false;
			}
			string maxTestedApplicationVersion = profile.MaxTestedApplicationVersion;
			if (maxTestedApplicationVersion != null && maxTestedApplicationVersion.Length > 0 && Version.TryParse(NormalizeVersion(maxTestedApplicationVersion), out Version result3) && result > result3)
			{
				return false;
			}
			return true;
		}

		private static string NormalizeVersion(string raw)
		{
			if (!raw.Contains('.'))
			{
				return raw + ".0";
			}
			return raw;
		}
	}
	public sealed record EnvironmentTokens
	{
		public required Guid ObserverSessionId { get; init; }

		public required int HelperGeneration { get; init; }

		public required int FocusEpoch { get; init; }

		public required int SurfaceEpoch { get; init; }

		public required int ObservedChangeSequence { get; init; }

		public required int RequestId { get; init; }

		public bool MatchesCurrent(EnvironmentTokens candidate)
		{
			ArgumentNullException.ThrowIfNull(candidate, "candidate");
			if (ObserverSessionId == candidate.ObserverSessionId && HelperGeneration == candidate.HelperGeneration && FocusEpoch == candidate.FocusEpoch && SurfaceEpoch == candidate.SurfaceEpoch)
			{
				return RequestId == candidate.RequestId;
			}
			return false;
		}
	}
	public sealed record TypingSurfaceStructuralFacts
	{
		public ProtectionState Protection { get; init; }

		public Editability Editability { get; init; }

		public bool IsRemoteOrTerminalSurface { get; init; }

		public bool IsCodeSurface { get; init; }

		public bool IsOwnApplicationSurface { get; init; }

		public bool IsExplicitlyExcludedApplication { get; init; }

		public EnvironmentProfileMatch? ProfileMatch { get; init; }

		public FieldRole? DeclaredSemanticRole { get; init; }

		public string? DeclaredSemanticRuleId { get; init; }

		public bool HasEditableEditOrDocumentSurface { get; init; }

		public bool IsPositivelyNonText { get; init; }

		public ImmutableArray<string> CandidateHints { get; init; } = ImmutableArray<string>.Empty;
	}
	public sealed record FieldRoleClassification
	{
		public required FieldRole Role { get; init; }

		public required RoleEvidenceKind Evidence { get; init; }

		public string? RuleId { get; init; }

		public ImmutableArray<string> RoleCandidates { get; init; } = ImmutableArray<string>.Empty;

		public bool IsMetadataOnlySurface { get; init; }
	}
	public static class FieldRoleClassifier
	{
		public static IReadOnlySet<string> BuiltInRuleIds { get; } = new HashSet<string>(StringComparer.Ordinal) { "ProtectionImpliesPassword", "RemoteOrTerminalSurface", "CodeSurface", "DeclaredSemanticMetadata", "EditableSurfaceNoSpecificRole", "PositivelyNonText", "OwnApplicationSurface", "ExplicitlyExcludedApplication" };

		public static FieldRoleClassification Classify(TypingSurfaceStructuralFacts facts)
		{
			ArgumentNullException.ThrowIfNull(facts, "facts");
			ImmutableArray<string> candidates = facts.CandidateHints;
			if (facts.Protection == ProtectionState.Protected)
			{
				return Result(FieldRole.Password, RoleEvidenceKind.ProviderDeclared, "ProtectionImpliesPassword", candidates, isMetadataOnly: true);
			}
			if (facts.IsRemoteOrTerminalSurface)
			{
				EnvironmentProfileMatch profileMatch = facts.ProfileMatch;
				return Result(((object)profileMatch != null && profileMatch.IsValidated) ? profileMatch.Profile.InferredRole : FieldRole.Terminal, RoleEvidenceKind.Structural, "RemoteOrTerminalSurface", candidates, isMetadataOnly: true);
			}
			if (facts.IsCodeSurface)
			{
				return Result(FieldRole.Code, RoleEvidenceKind.Structural, "CodeSurface", candidates, isMetadataOnly: true);
			}
			if (facts.IsOwnApplicationSurface || facts.IsExplicitlyExcludedApplication)
			{
				string ruleId = (facts.IsOwnApplicationSurface ? "OwnApplicationSurface" : "ExplicitlyExcludedApplication");
				return Result(facts.HasEditableEditOrDocumentSurface ? FieldRole.GeneralText : FieldRole.Unknown, RoleEvidenceKind.Structural, ruleId, candidates, isMetadataOnly: true);
			}
			EnvironmentProfileMatch profileMatch2 = facts.ProfileMatch;
			if ((object)profileMatch2 != null && profileMatch2.IsValidated)
			{
				return Result(profileMatch2.Profile.InferredRole, RoleEvidenceKind.ValidatedProfile, profileMatch2.Profile.ProfileId, candidates);
			}
			EnvironmentProfileMatch profileMatch3 = facts.ProfileMatch;
			if ((object)profileMatch3 != null && !profileMatch3.IsValidated)
			{
				candidates = candidates.Add("UnvalidatedProfile:" + profileMatch3.Profile.ProfileId);
			}
			FieldRole? declaredSemanticRole = facts.DeclaredSemanticRole;
			if (declaredSemanticRole.HasValue)
			{
				FieldRole valueOrDefault = declaredSemanticRole.GetValueOrDefault();
				if (valueOrDefault != FieldRole.Unknown)
				{
					return Result(valueOrDefault, RoleEvidenceKind.ProviderDeclared, facts.DeclaredSemanticRuleId ?? "DeclaredSemanticMetadata", candidates);
				}
			}
			if (facts.HasEditableEditOrDocumentSurface)
			{
				return Result(FieldRole.GeneralText, RoleEvidenceKind.Structural, "EditableSurfaceNoSpecificRole", candidates);
			}
			if (facts.IsPositivelyNonText)
			{
				return Result(FieldRole.NonText, RoleEvidenceKind.Structural, "PositivelyNonText", candidates);
			}
			return Result(FieldRole.Unknown, RoleEvidenceKind.None, null, candidates);
		}

		private static FieldRoleClassification Result(FieldRole role, RoleEvidenceKind evidence, string? ruleId, ImmutableArray<string> candidates, bool isMetadataOnly = false)
		{
			return new FieldRoleClassification
			{
				Role = role,
				Evidence = evidence,
				RuleId = ruleId,
				RoleCandidates = candidates,
				IsMetadataOnlySurface = isMetadataOnly
			};
		}
	}
	public interface ITypingEnvironmentSource
	{
		TypingEnvironmentSnapshot Current { get; }

		event EventHandler<TypingEnvironmentSnapshot>? SnapshotChanged;
	}
	public sealed record EnvironmentProbeTiming
	{
		public TimeSpan ProbeDuration { get; init; }

		public int TimeoutCount { get; init; }

		public int HelperRestartCount { get; init; }

		public int DroppedOrCoalescedRequestCount { get; init; }
	}
	public sealed record TypingEnvironmentSnapshot
	{
		public int SchemaVersion { get; init; } = 1;

		public required EnvironmentTokens Tokens { get; init; }

		public DateTimeOffset ObservedAtUtc { get; init; }

		public long CompletedTimestampHostTicks { get; init; }

		public IdentityStrength IdentityStrength { get; init; }

		public SurfaceKind SurfaceKind { get; init; }

		public FieldRole Role { get; init; }

		public RoleEvidenceKind RoleEvidence { get; init; }

		public string? RoleRuleId { get; init; }

		public ImmutableArray<string> RoleCandidates { get; init; } = ImmutableArray<string>.Empty;

		public ProtectionState Protection { get; init; }

		public Editability Editability { get; init; }

		public CompositionState Composition { get; init; }

		public ImmutableArray<CapabilityEvidence> Capabilities { get; init; } = CapabilityEvidenceSet.Empty;

		public ContextHealth ContextHealth { get; init; }

		public TextOrderEvidence TextOrderEvidence { get; init; }

		public required EnvironmentAssessment Assessment { get; init; }

		public EnvironmentProbeTiming Timing { get; init; } = new EnvironmentProbeTiming();

		public const int CurrentSchemaVersion = 1;

		public static TypingEnvironmentSnapshot Invalidated(EnvironmentTokens tokens, long completedTimestampHostTicks, DateTimeOffset observedAtUtc, string reasonCode)
		{
			return new TypingEnvironmentSnapshot
			{
				Tokens = tokens,
				ObservedAtUtc = observedAtUtc,
				CompletedTimestampHostTicks = completedTimestampHostTicks,
				IdentityStrength = IdentityStrength.None,
				SurfaceKind = SurfaceKind.Unknown,
				Role = FieldRole.Unknown,
				RoleEvidence = RoleEvidenceKind.None,
				Protection = ProtectionState.Unknown,
				Editability = Editability.Unknown,
				Composition = CompositionState.Unknown,
				Capabilities = CapabilityEvidenceSet.Empty,
				ContextHealth = ContextHealth.Unknown,
				TextOrderEvidence = TextOrderEvidence.Unknown,
				Assessment = new EnvironmentAssessment
				{
					Kind = AssessmentKind.Unknown,
					ContentReadsPermitted = false,
					ReasonCodes = ImmutableArray.Create(reasonCode)
				}
			};
		}
	}
	public enum TypingTargetRestriction
	{
		None,
		EnglishOnly,
		PassThrough
	}
	public sealed record TypingTargetDecision(TypingTargetRestriction Restriction, string Reason)
	{
		public static TypingTargetDecision NoEvidence { get; } = new TypingTargetDecision(TypingTargetRestriction.None, "NoCurrentEnvironmentEvidence");

		public bool Restricts => Restriction != TypingTargetRestriction.None;
	}
	public static class TypingTargetPolicy
	{
		private static readonly HashSet<string> InvalidationReasons = new HashSet<string>(StringComparer.Ordinal) { "FocusChanged", "ObserverUnavailable", "DesktopOrSessionUnavailable" };

		public static TimeSpan DefaultMaxEvidenceAge { get; } = TimeSpan.FromSeconds(2L);

		public static TypingTargetDecision Decide(TypingEnvironmentSnapshot? snapshot, DateTimeOffset now, TimeSpan maxEvidenceAge)
		{
			if ((object)snapshot == null || now - snapshot.ObservedAtUtc > maxEvidenceAge || now < snapshot.ObservedAtUtc - maxEvidenceAge)
			{
				return TypingTargetDecision.NoEvidence;
			}
			if (snapshot.Assessment.ReasonCodes.Any(InvalidationReasons.Contains) && snapshot.IdentityStrength == IdentityStrength.None)
			{
				return TypingTargetDecision.NoEvidence;
			}
			if (snapshot.Protection == ProtectionState.Protected || snapshot.Assessment.Kind == AssessmentKind.Protected)
			{
				return new TypingTargetDecision(TypingTargetRestriction.PassThrough, "PasswordReported");
			}
			if (snapshot.Assessment.Kind == AssessmentKind.NotEditable || snapshot.Editability == Editability.ReadOnly)
			{
				return new TypingTargetDecision(TypingTargetRestriction.PassThrough, "ReadOnlyReported");
			}
			if (snapshot.RoleEvidence != RoleEvidenceKind.None)
			{
				switch (snapshot.Role)
				{
				case FieldRole.Password:
					return new TypingTargetDecision(TypingTargetRestriction.PassThrough, "PasswordReported");
				case FieldRole.AddressOrSearch:
				case FieldRole.Url:
				case FieldRole.Email:
				case FieldRole.Numeric:
					return new TypingTargetDecision(TypingTargetRestriction.EnglishOnly, "EnglishOnlyRole:" + snapshot.Role);
				}
			}
			return new TypingTargetDecision(TypingTargetRestriction.None, "NoRestriction");
		}
	}
}
namespace SmartInput.Core.Environments.Protocol
{
	public enum ProbeMessageKind
	{
		Hello,
		HelloAccepted,
		Probe,
		ProbeResult,
		Invalidate,
		Stop,
		Stopped,
		ContextChanged
	}
	public sealed record ProbeFrame
	{
		public required int ProtocolVersion { get; init; }

		public required int HelperGeneration { get; init; }

		public required int RequestId { get; init; }

		public required ProbeMessageKind MessageKind { get; init; }

		public JsonElement Payload { get; init; }
	}
	public sealed record HelloPayload
	{
		public required string ProbeExecutableVersion { get; init; }
	}
	public sealed record HelloAcceptedPayload
	{
		public required int AcceptedProtocolVersion { get; init; }
	}
	public sealed record ProbeRequestPayload
	{
		public required ObservationMode Mode { get; init; }

		public required EnvironmentTokens Tokens { get; init; }
	}
	public sealed record ProbeResultPayload
	{
		public required TypingEnvironmentSnapshot Snapshot { get; init; }

		public int SurfaceSerial { get; init; }
	}
	public sealed record InvalidatePayload
	{
		public required int SubscriptionGeneration { get; init; }

		public string? LastObservedSurfaceToken { get; init; }
	}
	public enum ContextChangeKind
	{
		Text,
		Selection
	}
	public sealed record ContextChangedPayload
	{
		public required ContextChangeKind Kind { get; init; }

		public required long ChangeEventCount { get; init; }
	}
	public sealed record StopPayload;
	public sealed record StoppedPayload;
	public enum ProbeProtocolFailureKind
	{
		InvalidLength,
		TruncatedFrame,
		OversizedPayload,
		MalformedJson,
		InvalidEnumValue,
		ExceedsMaxDepth,
		UnsupportedProtocolVersion,
		StreamClosed
	}
	public sealed class ProbeProtocolException : Exception
	{
		public ProbeProtocolFailureKind FailureKind { get; }

		public ProbeProtocolException(ProbeProtocolFailureKind failureKind, string message)
			: base(message)
		{
			FailureKind = failureKind;
		}
	}
	public static class ProbeFrameCodec
	{
		public const int CurrentProtocolVersion = 1;

		private static JsonSerializerOptions CreateOptions(int maxDepth)
		{
			return new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
				Converters = { (JsonConverter)new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
				MaxDepth = maxDepth,
				NumberHandling = JsonNumberHandling.Strict
			};
		}

		public static async Task WriteFrameAsync(Stream stream, ProbeFrame frame, EnvironmentObservationOptions options, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(stream, "stream");
			ArgumentNullException.ThrowIfNull(frame, "frame");
			ArgumentNullException.ThrowIfNull(options, "options");
			byte[] payload = JsonSerializer.SerializeToUtf8Bytes(frame, CreateOptions(options.MaxJsonDepth));
			if (payload.Length > options.MaxFramePayloadBytes)
			{
				throw new ProbeProtocolException(ProbeProtocolFailureKind.OversizedPayload, $"Frame payload of {payload.Length} bytes exceeds the {options.MaxFramePayloadBytes}-byte limit.");
			}
			Span<byte> destination = stackalloc byte[4];
			BinaryPrimitives.WriteInt32LittleEndian(destination, payload.Length);
			await stream.WriteAsync(destination.ToArray(), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await stream.WriteAsync(payload, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await stream.FlushAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static async Task<ProbeFrame> ReadFrameAsync(Stream stream, EnvironmentObservationOptions options, CancellationToken cancellationToken)
		{
			ArgumentNullException.ThrowIfNull(stream, "stream");
			ArgumentNullException.ThrowIfNull(options, "options");
			byte[] lengthBuffer = new byte[4];
			int num = await ReadExactAsync(stream, lengthBuffer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (num == 0)
			{
				throw new ProbeProtocolException(ProbeProtocolFailureKind.StreamClosed, "The pipe was closed before a frame length arrived.");
			}
			if (num < lengthBuffer.Length)
			{
				throw new ProbeProtocolException(ProbeProtocolFailureKind.TruncatedFrame, "The frame length prefix was truncated.");
			}
			int declaredLength = BinaryPrimitives.ReadInt32LittleEndian(lengthBuffer);
			if (declaredLength <= 0 || declaredLength > options.MaxFramePayloadBytes)
			{
				throw new ProbeProtocolException(ProbeProtocolFailureKind.InvalidLength, $"Declared frame length {declaredLength} is outside the valid 1..{options.MaxFramePayloadBytes} range.");
			}
			byte[] payload = new byte[declaredLength];
			if (await ReadExactAsync(stream, payload, cancellationToken).ConfigureAwait(continueOnCapturedContext: false) < declaredLength)
			{
				throw new ProbeProtocolException(ProbeProtocolFailureKind.TruncatedFrame, "The frame payload was shorter than its declared length.");
			}
			ProbeFrame probeFrame;
			try
			{
				probeFrame = JsonSerializer.Deserialize<ProbeFrame>(payload, CreateOptions(options.MaxJsonDepth)) ?? throw new ProbeProtocolException(ProbeProtocolFailureKind.MalformedJson, "Frame payload deserialized to null.");
			}
			catch (JsonException ex)
			{
				throw new ProbeProtocolException(ClassifyJsonFailure(ex), "Frame payload was not valid JSON: " + ex.Message);
			}
			if (probeFrame.ProtocolVersion != 1)
			{
				throw new ProbeProtocolException(ProbeProtocolFailureKind.UnsupportedProtocolVersion, $"Frame declared protocol version {probeFrame.ProtocolVersion}, expected {1}.");
			}
			return probeFrame;
		}

		public static T DecodePayload<T>(ProbeFrame frame, EnvironmentObservationOptions options)
		{
			ArgumentNullException.ThrowIfNull(frame, "frame");
			ArgumentNullException.ThrowIfNull(options, "options");
			try
			{
				T val = JsonSerializer.Deserialize<T>(frame.Payload.GetRawText(), CreateOptions(options.MaxJsonDepth));
				if (val == null)
				{
					throw new ProbeProtocolException(ProbeProtocolFailureKind.MalformedJson, "Frame payload body deserialized to null.");
				}
				return val;
			}
			catch (JsonException ex)
			{
				throw new ProbeProtocolException(ClassifyJsonFailure(ex), "Frame payload body was invalid: " + ex.Message);
			}
		}

		private static ProbeProtocolFailureKind ClassifyJsonFailure(JsonException ex)
		{
			if (!ex.Message.Contains("could not be converted", StringComparison.OrdinalIgnoreCase))
			{
				return ProbeProtocolFailureKind.MalformedJson;
			}
			return ProbeProtocolFailureKind.InvalidEnumValue;
		}

		public static ProbeFrame EncodePayload<T>(int helperGeneration, int requestId, ProbeMessageKind kind, T payloadBody, EnvironmentObservationOptions options)
		{
			ArgumentNullException.ThrowIfNull(options, "options");
			JsonElement payload = JsonSerializer.SerializeToElement(payloadBody, CreateOptions(options.MaxJsonDepth));
			return new ProbeFrame
			{
				ProtocolVersion = 1,
				HelperGeneration = helperGeneration,
				RequestId = requestId,
				MessageKind = kind,
				Payload = payload
			};
		}

		private static async Task<int> ReadExactAsync(Stream stream, byte[] buffer, CancellationToken cancellationToken)
		{
			int totalRead;
			int num;
			for (totalRead = 0; totalRead < buffer.Length; totalRead += num)
			{
				num = await stream.ReadAsync(buffer.AsMemory(totalRead, buffer.Length - totalRead), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (num == 0)
				{
					break;
				}
			}
			return totalRead;
		}
	}
}
namespace SmartInput.Core.Dictionaries
{
	public enum DictionaryEntrySource
	{
		BuiltIn,
		Personal
	}
	public sealed record DictionaryCatalogItem
	{
		public Guid? UserEntryId { get; init; }

		public required string Term { get; init; }

		public required EntryLanguage Language { get; init; }

		public required DictionaryCategory Category { get; init; }

		public required DictionaryEntrySource Source { get; init; }

		public bool PreventConversion { get; init; }

		public bool Enabled { get; init; } = true;

		public bool AutoLearned { get; init; }

		public bool IsBuiltIn => Source == DictionaryEntrySource.BuiltIn;

		public string SourceLabel
		{
			get
			{
				if (!IsBuiltIn)
				{
					return "Personal";
				}
				return "Built-in";
			}
		}
	}
	public sealed record DictionaryCatalogPage(IReadOnlyList<DictionaryCatalogItem> Items, int TotalCount, int PageIndex, int PageSize)
	{
		public int PageCount => Math.Max(1, (int)Math.Ceiling((double)TotalCount / (double)PageSize));
	}
	public enum EntryLanguage
	{
		Persian,
		English,
		Neutral
	}
	public enum DictionaryCategory
	{
		General,
		Technical,
		Name,
		Acronym,
		Command,
		Currency
	}
	public sealed record DictionaryEntry
	{
		public required Guid Id { get; init; }

		public required string Term { get; init; }

		public required EntryLanguage Language { get; init; }

		public DictionaryCategory Category { get; init; }

		public bool CaseSensitive { get; init; }

		public bool AutoReturnAfterWord { get; init; }

		public bool PreventConversion { get; init; }

		public bool Enabled { get; init; } = true;

		public string? ApplicationProcessName { get; init; }

		public string? Notes { get; init; }

		public bool AutoLearned { get; init; }

		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public IReadOnlyList<Guid>? AutoLearnedBy { get; init; }
	}
	public static class LexiconLoader
	{
		private sealed record LexiconMetadata
		{
			public IReadOnlyList<string> TechnicalEnglish { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> HighFrequencyEnglish { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> HighFrequencyPersian { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> CurrencyPersian { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> AdditionalPersian { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> ReviewedPersianAdditions { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> ShortcutEnglish { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> PersianPriorityShortWords { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> PersianPrepositionBases { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> PersianFunctionWords { get; init; } = Array.Empty<string>();

			public IReadOnlyList<string> PersianEnclitics { get; init; } = Array.Empty<string>();

			public IReadOnlyList<PersianSuffixEntry> PersianSuffixes { get; init; } = Array.Empty<PersianSuffixEntry>();
		}

		private sealed record PersianSuffixEntry
		{
			public string? Form { get; init; }

			public string? AttachesAfter { get; init; }

			public int MinBase { get; init; }

			public string? Zwnj { get; init; }

			public IReadOnlyList<string>? MayFollow { get; init; }
		}

		private sealed record UserDictionaryFile(int SchemaVersion, IReadOnlyList<DictionaryEntry> Entries);

		public const int UserDictionaryFormatVersion = 1;

		private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			PropertyNameCaseInsensitive = true
		};

		public static LexiconStore LoadFromFiles(string? builtinEnglishPath, string? builtinPersianPath, string? userDictionaryPath, string? metadataPath = null, string? persianFrequencyPath = null, string? persianAdditionsPath = null)
		{
			LexiconStore lexiconStore = new LexiconStore();
			if (builtinEnglishPath != null && File.Exists(builtinEnglishPath))
			{
				IEnumerable<string> words = ReadWordLines(builtinEnglishPath);
				lexiconStore.LoadBuiltinEnglish(words);
			}
			if (builtinPersianPath != null && File.Exists(builtinPersianPath))
			{
				IEnumerable<string> words2 = ReadWordLines(builtinPersianPath);
				lexiconStore.LoadBuiltinPersian(words2);
			}
			IReadOnlyList<string> words3 = Array.Empty<string>();
			if (metadataPath != null && File.Exists(metadataPath))
			{
				LexiconMetadata lexiconMetadata = ReadMetadata(metadataPath);
				words3 = lexiconMetadata.ReviewedPersianAdditions;
				lexiconStore.LoadTechnicalTerms(lexiconMetadata.TechnicalEnglish);
				lexiconStore.LoadHighFrequencyEnglish(lexiconMetadata.HighFrequencyEnglish);
				lexiconStore.LoadHighFrequencyPersian(lexiconMetadata.HighFrequencyPersian);
				lexiconStore.LoadCurrencyUnits(lexiconMetadata.CurrencyPersian);
				lexiconStore.LoadShortcutTerms(lexiconMetadata.ShortcutEnglish);
				lexiconStore.LoadPersianPriorityShortWords(lexiconMetadata.PersianPriorityShortWords);
				lexiconStore.LoadPersianPrepositionBases(lexiconMetadata.PersianPrepositionBases);
				lexiconStore.LoadPersianFunctionWords(lexiconMetadata.PersianFunctionWords);
				lexiconStore.LoadPersianEnclitics(lexiconMetadata.PersianEnclitics);
				lexiconStore.LoadPersianSuffixes((from entry in lexiconMetadata.PersianSuffixes
					where (object)entry != null
					select PersianSuffixRule.Create(entry.Form, entry.AttachesAfter, entry.MinBase, entry.Zwnj, entry.MayFollow)).OfType<PersianSuffixRule>());
				lexiconStore.LoadBuiltinPersian(lexiconMetadata.AdditionalPersian);
			}
			if (persianAdditionsPath != null && File.Exists(persianAdditionsPath))
			{
				lexiconStore.LoadCommonPersianAdditions(ReadWordLines(persianAdditionsPath));
				lexiconStore.LoadCommonPersianAdditions(words3);
			}
			if (persianFrequencyPath != null && File.Exists(persianFrequencyPath))
			{
				lexiconStore.LoadPersianFrequency(ReadWordLines(persianFrequencyPath));
			}
			lexiconStore.UserDictionaryPath = userDictionaryPath;
			if (userDictionaryPath != null && File.Exists(userDictionaryPath))
			{
				IReadOnlyList<DictionaryEntry> entries = ReadUserDictionary(userDictionaryPath);
				lexiconStore.UpsertUserEntries(entries);
			}
			return lexiconStore;
		}

		public static void SaveUserDictionary(string path, IReadOnlyList<DictionaryEntry> entries)
		{
			UnreadableFileBackup.ThrowIfBlocked(path);
			Directory.CreateDirectory(Path.GetDirectoryName(path) ?? ".");
			string contents = JsonSerializer.Serialize(new UserDictionaryFile(1, entries), JsonOptions);
			string text = path + ".tmp";
			File.WriteAllText(text, contents, Encoding.UTF8);
			File.Move(text, path, overwrite: true);
		}

		private static IEnumerable<string> ReadWordLines(string path)
		{
			return from l in File.ReadAllLines(path, Encoding.UTF8)
				select l.Trim() into l
				where l.Length > 0 && !l.StartsWith('#')
				select l;
		}

		private static IReadOnlyList<DictionaryEntry> ReadUserDictionary(string path)
		{
			try
			{
				UserDictionaryFile userDictionaryFile = JsonSerializer.Deserialize<UserDictionaryFile>(File.ReadAllText(path, Encoding.UTF8), JsonOptions);
				if ((object)userDictionaryFile == null || userDictionaryFile.SchemaVersion > 1 || userDictionaryFile.Entries == null)
				{
					if ((object)userDictionaryFile != null)
					{
						if (userDictionaryFile.Entries != null)
						{
							UnreadableFileBackup.Keep(path, MessageKey.UnreadableNewerFormat, userDictionaryFile.SchemaVersion);
						}
						else
						{
							UnreadableFileBackup.Keep(path, MessageKey.UnreadableNoEntriesList);
						}
					}
					else
					{
						UnreadableFileBackup.Keep(path, MessageKey.UnreadableEmptyFile);
					}
					return Array.Empty<DictionaryEntry>();
				}
				return userDictionaryFile.Entries.Where((DictionaryEntry entry) => (object)entry != null && entry.Term != null).ToList();
			}
			catch (Exception ex) when ((ex is JsonException || ex is IOException || ex is UnauthorizedAccessException || ex is NotSupportedException) ? true : false)
			{
				UnreadableFileBackup.Keep(path, ex.GetType().Name);
				return Array.Empty<DictionaryEntry>();
			}
		}

		private static LexiconMetadata ReadMetadata(string path)
		{
			try
			{
				return JsonSerializer.Deserialize<LexiconMetadata>(File.ReadAllText(path, Encoding.UTF8), JsonOptions) ?? new LexiconMetadata();
			}
			catch
			{
				return new LexiconMetadata();
			}
		}
	}
	public sealed class LexiconStore
	{
		private sealed class UserTermIndexes
		{
			private readonly TermIndex[] _all = CreateTermIndexes();

			private readonly TermIndex[] _prevented = CreateTermIndexes();

			public static UserTermIndexes Empty { get; } = new UserTermIndexes();

			public static UserTermIndexes Create(IEnumerable<DictionaryEntry> entries)
			{
				UserTermIndexes userTermIndexes = new UserTermIndexes();
				foreach (DictionaryEntry entry in entries)
				{
					if (!entry.Enabled || !Enum.IsDefined(entry.Language))
					{
						continue;
					}
					string text = NormalizeUserTerm(entry.Term);
					if (text.Length != 0)
					{
						userTermIndexes._all[(int)entry.Language].Add(text, entry.CaseSensitive);
						if (entry.PreventConversion)
						{
							userTermIndexes._prevented[(int)entry.Language].Add(text, entry.CaseSensitive);
						}
					}
				}
				return userTermIndexes;
			}

			public bool IsMatch(string term, DetectedLanguage language, bool preventedOnly)
			{
				TermIndex[] array = (preventedOnly ? _prevented : _all);
				string term2 = NormalizeUserTerm(term);
				int num = language switch
				{
					DetectedLanguage.Persian => 0, 
					DetectedLanguage.English => 1, 
					_ => -1, 
				};
				if (!array[2].Contains(term2))
				{
					if (num >= 0)
					{
						return array[num].Contains(term2);
					}
					return false;
				}
				return true;
			}

			private static TermIndex[] CreateTermIndexes()
			{
				return new TermIndex[3]
				{
					new TermIndex(),
					new TermIndex(),
					new TermIndex()
				};
			}
		}

		private sealed class TermIndex
		{
			private readonly HashSet<string> _caseSensitive = new HashSet<string>(StringComparer.Ordinal);

			private readonly HashSet<string> _caseInsensitive = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

			public void Add(string term, bool caseSensitive)
			{
				(caseSensitive ? _caseSensitive : _caseInsensitive).Add(term);
			}

			public bool Contains(string term)
			{
				if (!_caseSensitive.Contains(term))
				{
					return _caseInsensitive.Contains(term);
				}
				return true;
			}
		}

		private List<DictionaryEntry> _userEntries = new List<DictionaryEntry>();

		private UserTermIndexes _userTermIndexes = UserTermIndexes.Empty;

		private readonly HashSet<string> _englishWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private readonly HashSet<string> _strongEnglishProtectionWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private readonly HashSet<string> _persianWords = new HashSet<string>(StringComparer.Ordinal);

		private readonly HashSet<string> _technicalTerms = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private readonly HashSet<string> _highFrequencyEnglish = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private readonly HashSet<string> _highFrequencyPersian = new HashSet<string>(StringComparer.Ordinal);

		private readonly HashSet<string> _currencyUnits = new HashSet<string>(StringComparer.Ordinal);

		private readonly HashSet<string> _shortcutTerms = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private readonly List<string> _builtinEnglishCatalog = new List<string>();

		private readonly List<string> _builtinPersianCatalog = new List<string>();

		private readonly HashSet<string> _commonPersianAdditions = new HashSet<string>(StringComparer.Ordinal);

		private HashSet<string> _sessionEnglishPreferences = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private HashSet<string> _persianPriorityShortWords = new HashSet<string>(StringComparer.Ordinal);

		private HashSet<string> _persianPrepositionBases = new HashSet<string>(StringComparer.Ordinal);

		private HashSet<string> _persianEnclitics = new HashSet<string>(StringComparer.Ordinal);

		private IReadOnlyList<PersianSuffixRule> _persianSuffixes = Array.Empty<PersianSuffixRule>();

		private Dictionary<string, int> _persianFrequencyRanks = new Dictionary<string, int>(StringComparer.Ordinal);

		private HashSet<string> _persianFunctionWords = new HashSet<string>(StringComparer.Ordinal);

		public int BuiltinEnglishWordCount => _englishWords.Count;

		public int BuiltinPersianWordCount => _persianWords.Count;

		public int CommonPersianAdditionCount => _commonPersianAdditions.Count;

		public string? UserDictionaryPath { get; internal set; }

		public IReadOnlyList<PersianSuffixRule> PersianSuffixes => _persianSuffixes;

		public int PersianFrequencyWordCount => _persianFrequencyRanks.Count;

		public void LoadBuiltinEnglish(IEnumerable<string> words)
		{
			int num = 0;
			foreach (string word in words)
			{
				string text = word.Trim();
				if (text.Length != 0 && _englishWords.Add(text))
				{
					_builtinEnglishCatalog.Add(text);
					num++;
					if ((text.Length >= 3 && num <= 8000) || num <= 1500)
					{
						_strongEnglishProtectionWords.Add(text);
					}
				}
			}
		}

		public void LoadBuiltinPersian(IEnumerable<string> words)
		{
			foreach (string word in words)
			{
				string text = NormalizePersian(word.Trim());
				if (text.Length != 0 && _persianWords.Add(text))
				{
					_builtinPersianCatalog.Add(text);
				}
			}
		}

		public void LoadCommonPersianAdditions(IEnumerable<string> words)
		{
			foreach (string word in words)
			{
				string text = NormalizePersian(word.Trim());
				if (text.Length != 0 && _persianWords.Add(text))
				{
					_builtinPersianCatalog.Add(text);
					_commonPersianAdditions.Add(text);
				}
			}
		}

		public bool IsCommonPersianAddition(string term)
		{
			return _commonPersianAdditions.Contains(NormalizePersian(term.Trim()));
		}

		public void LoadTechnicalTerms(IEnumerable<string> words)
		{
			foreach (string item in NormalizeWords(words, normalizePersian: false))
			{
				_technicalTerms.Add(item);
				AddBuiltinEnglishCatalogWord(item);
			}
		}

		public void LoadHighFrequencyEnglish(IEnumerable<string> words)
		{
			foreach (string item in NormalizeWords(words, normalizePersian: false))
			{
				_highFrequencyEnglish.Add(item);
				AddBuiltinEnglishCatalogWord(item);
			}
		}

		public void LoadHighFrequencyPersian(IEnumerable<string> words)
		{
			foreach (string item in NormalizeWords(words, normalizePersian: true))
			{
				_highFrequencyPersian.Add(item);
				AddBuiltinPersianCatalogWord(item);
			}
		}

		public void LoadCurrencyUnits(IEnumerable<string> words)
		{
			foreach (string item in NormalizeWords(words, normalizePersian: true))
			{
				_currencyUnits.Add(item);
				AddBuiltinPersianCatalogWord(item);
			}
		}

		public void LoadShortcutTerms(IEnumerable<string> words)
		{
			foreach (string item in NormalizeWords(words, normalizePersian: false))
			{
				_shortcutTerms.Add(item);
				AddBuiltinEnglishCatalogWord(item);
			}
		}

		public void UpsertUserEntries(IEnumerable<DictionaryEntry> entries)
		{
			List<DictionaryEntry> list = entries.ToList();
			UserTermIndexes userTermIndexes = UserTermIndexes.Create(list);
			_userEntries = list;
			_userTermIndexes = userTermIndexes;
		}

		public IReadOnlyList<DictionaryEntry> GetUserEntries()
		{
			return _userEntries;
		}

		public bool IsUserPrevented(string term, DetectedLanguage language)
		{
			return _userTermIndexes.IsMatch(term, language, preventedOnly: true);
		}

		public bool IsUserExactMatch(string term, DetectedLanguage language)
		{
			return _userTermIndexes.IsMatch(term, language, preventedOnly: false);
		}

		public void AddSessionEnglishPreference(string term)
		{
			string text = term.Trim();
			if (text.Length != 0)
			{
				_sessionEnglishPreferences = new HashSet<string>(_sessionEnglishPreferences, StringComparer.OrdinalIgnoreCase) { text };
			}
		}

		public bool RemoveSessionEnglishPreference(string term)
		{
			string text = term.Trim();
			if (text.Length == 0 || !_sessionEnglishPreferences.Contains(text))
			{
				return false;
			}
			HashSet<string> hashSet = new HashSet<string>(_sessionEnglishPreferences, StringComparer.OrdinalIgnoreCase);
			hashSet.Remove(text);
			_sessionEnglishPreferences = hashSet;
			return true;
		}

		public bool IsSessionEnglishPreference(string term)
		{
			return _sessionEnglishPreferences.Contains(term.Trim());
		}

		public void LoadPersianPriorityShortWords(IEnumerable<string> words)
		{
			_persianPriorityShortWords = new HashSet<string>(NormalizeWords(words, normalizePersian: true), StringComparer.Ordinal);
		}

		public void LoadPersianPrepositionBases(IEnumerable<string> words)
		{
			_persianPrepositionBases = new HashSet<string>(NormalizeWords(words, normalizePersian: true), StringComparer.Ordinal);
		}

		public bool IsPersianPriorityShortWord(string term)
		{
			return _persianPriorityShortWords.Contains(NormalizePersian(term));
		}

		public bool IsPersianPrepositionBase(string term)
		{
			return _persianPrepositionBases.Contains(NormalizePersian(term));
		}

		public void LoadPersianEnclitics(IEnumerable<string> words)
		{
			_persianEnclitics = new HashSet<string>(NormalizeWords(words, normalizePersian: true), StringComparer.Ordinal);
		}

		public void LoadPersianSuffixes(IEnumerable<PersianSuffixRule> rules)
		{
			_persianSuffixes = rules.Select((PersianSuffixRule rule) => rule with
			{
				Form = NormalizePersian(rule.Form),
				MayFollow = rule.MayFollow.Select(NormalizePersian).ToArray()
			}).ToArray();
		}

		public bool IsPersianEnclitic(string term)
		{
			return _persianEnclitics.Contains(NormalizePersian(term));
		}

		public void LoadPersianFrequency(IEnumerable<string> words)
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>(StringComparer.Ordinal);
			foreach (string item in NormalizeWords(words, normalizePersian: true))
			{
				dictionary.TryAdd(item, dictionary.Count + 1);
			}
			_persianFrequencyRanks = dictionary;
		}

		public void LoadPersianFunctionWords(IEnumerable<string> words)
		{
			_persianFunctionWords = new HashSet<string>(NormalizeWords(words, normalizePersian: true), StringComparer.Ordinal);
		}

		public bool IsCommonPersian(string term, int maximumRank)
		{
			if (_persianFrequencyRanks.TryGetValue(NormalizePersian(term.Trim()), out var value))
			{
				return value <= maximumRank;
			}
			return false;
		}

		public bool IsPersianFunctionWord(string term)
		{
			return _persianFunctionWords.Contains(NormalizePersian(term.Trim()));
		}

		public bool IsTechnicalMatch(string term)
		{
			return _technicalTerms.Contains(term);
		}

		public bool IsCurrencyUnit(string term)
		{
			return _currencyUnits.Contains(NormalizePersian(term));
		}

		public bool IsShortcutExpression(string term)
		{
			string[] array = term.Split('+', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			if (array.Length < 2)
			{
				return false;
			}
			return array.All((string part) =>
			{
				bool flag = _shortcutTerms.Contains(part) || (part.Length == 1 && char.IsAsciiLetterOrDigit(part[0]));
				if (!flag)
				{
					int length = part.Length;
					bool flag2 = (uint)(length - 2) <= 1u;
					bool flag3 = flag2;
					if (flag3)
					{
						char c = part[0];
						bool flag4 = ((c == 'F' || c == 'f') ? true : false);
						flag3 = flag4;
					}
					flag = flag3 && int.TryParse(part.AsSpan(1), out var result) && result >= 1 && result <= 12;
				}
				return flag;
			});
		}

		public bool IsBuiltinWord(string term, DetectedLanguage language)
		{
			string text = NormalizePersian(term);
			return language switch
			{
				DetectedLanguage.English => IsBuiltinEnglishWord(text), 
				DetectedLanguage.Persian => _persianWords.Contains(text), 
				_ => _englishWords.Contains(text) || _persianWords.Contains(text), 
			};
		}

		public bool IsHighFrequency(string term, DetectedLanguage language)
		{
			return language switch
			{
				DetectedLanguage.English => _highFrequencyEnglish.Contains(term), 
				DetectedLanguage.Persian => _highFrequencyPersian.Contains(NormalizePersian(term)), 
				_ => false, 
			};
		}

		public bool IsNormalFrequency(string term, DetectedLanguage language)
		{
			if (!IsHighFrequency(term, language))
			{
				return IsBuiltinWord(term, language);
			}
			return false;
		}

		public bool IsStrongEnglishProtection(string term)
		{
			return IsEnglishWordInSet(term, _strongEnglishProtectionWords);
		}

		public bool ContainsCatalogTerm(string term, EntryLanguage language)
		{
			return language switch
			{
				EntryLanguage.English => _englishWords.Contains(term), 
				EntryLanguage.Persian => _persianWords.Contains(NormalizePersian(term)), 
				_ => _englishWords.Contains(term) || _persianWords.Contains(NormalizePersian(term)), 
			};
		}

		public DictionaryCatalogPage QueryCatalog(string? search, EntryLanguage? language, int pageIndex, int pageSize, DictionaryEntrySource? source = null)
		{
			pageSize = Math.Clamp(pageSize, 1, 1000);
			pageIndex = Math.Max(0, pageIndex);
			string query = search?.Trim() ?? string.Empty;
			int num = pageIndex * pageSize;
			int total = 0;
			List<DictionaryCatalogItem> list = new List<DictionaryCatalogItem>(pageSize);
			IEnumerable<DictionaryEntry> enumerable2;
			if (source != DictionaryEntrySource.BuiltIn)
			{
				IEnumerable<DictionaryEntry> enumerable = _userEntries.OrderBy((DictionaryEntry entry) => entry.Term, StringComparer.CurrentCultureIgnoreCase);
				enumerable2 = enumerable;
			}
			else
			{
				enumerable2 = Enumerable.Empty<DictionaryEntry>();
			}
			foreach (DictionaryEntry item in enumerable2)
			{
				if ((!language.HasValue || item.Language == language) && MatchesSearch(item.Term, query))
				{
					if (total >= num && list.Count < pageSize)
					{
						list.Add(new DictionaryCatalogItem
						{
							UserEntryId = item.Id,
							Term = item.Term,
							Language = item.Language,
							Category = item.Category,
							Source = DictionaryEntrySource.Personal,
							PreventConversion = item.PreventConversion,
							Enabled = item.Enabled,
							AutoLearned = item.AutoLearned
						});
					}
					total++;
				}
			}
			bool flag = source != DictionaryEntrySource.Personal;
			if (flag)
			{
				bool flag2 = ((!language.HasValue || language == EntryLanguage.English) ? true : false);
				flag = flag2;
			}
			if (flag)
			{
				AddBuiltinCatalogMatches(_builtinEnglishCatalog, EntryLanguage.English, query, num, pageSize, list, ref total);
			}
			flag = source != DictionaryEntrySource.Personal;
			if (flag)
			{
				bool flag2 = ((!language.HasValue || language.GetValueOrDefault() == EntryLanguage.Persian) ? true : false);
				flag = flag2;
			}
			if (flag)
			{
				AddBuiltinCatalogMatches(_builtinPersianCatalog, EntryLanguage.Persian, query, num, pageSize, list, ref total);
			}
			return new DictionaryCatalogPage(list, total, pageIndex, pageSize);
		}

		private void AddBuiltinCatalogMatches(IEnumerable<string> words, EntryLanguage language, string query, int skip, int pageSize, ICollection<DictionaryCatalogItem> items, ref int total)
		{
			foreach (string word in words)
			{
				if (MatchesSearch(word, query))
				{
					if (total >= skip && items.Count < pageSize)
					{
						bool flag = language == EntryLanguage.English && _technicalTerms.Contains(word);
						bool flag2 = language == EntryLanguage.Persian && _currencyUnits.Contains(word);
						items.Add(new DictionaryCatalogItem
						{
							Term = word,
							Language = language,
							Category = (flag2 ? DictionaryCategory.Currency : (flag ? DictionaryCategory.Technical : DictionaryCategory.General)),
							Source = DictionaryEntrySource.BuiltIn,
							PreventConversion = (language == EntryLanguage.English)
						});
					}
					total++;
				}
			}
		}

		private static bool MatchesSearch(string term, string query)
		{
			if (query.Length != 0)
			{
				return term.Contains(query, StringComparison.CurrentCultureIgnoreCase);
			}
			return true;
		}

		private void AddBuiltinEnglishCatalogWord(string word)
		{
			if (_englishWords.Add(word))
			{
				_builtinEnglishCatalog.Add(word);
			}
		}

		private void AddBuiltinPersianCatalogWord(string word)
		{
			if (_persianWords.Add(word))
			{
				_builtinPersianCatalog.Add(word);
			}
		}

		private static IEnumerable<string> NormalizeWords(IEnumerable<string> words, bool normalizePersian)
		{
			foreach (string word in words)
			{
				string text = word.Trim();
				if (text.Length > 0)
				{
					yield return normalizePersian ? NormalizePersian(text) : text;
				}
			}
		}

		private bool IsBuiltinEnglishWord(string term)
		{
			return IsEnglishWordInSet(term, _englishWords);
		}

		private static bool IsEnglishWordInSet(string term, IReadOnlySet<string> words)
		{
			return words.Contains(term);
		}

		public static string NormalizeUserTerm(string term)
		{
			return NormalizePersian(term.Trim());
		}

		private static string NormalizePersian(string term)
		{
			if (term.IndexOfAny(new char[2] { 'ي', 'ك' }) >= 0)
			{
				return term.Replace('ي', 'ی').Replace('ك', 'ک');
			}
			return term;
		}
	}
	public enum PersianSuffixAttachment
	{
		Any,
		Consonant,
		ConsonantOrAlef,
		He,
		Vowel
	}
	public enum PersianSuffixZwnj
	{
		Optional,
		Required,
		Never
	}
	public sealed record PersianSuffixRule(string Form, PersianSuffixAttachment AttachesAfter, int MinimumBase, PersianSuffixZwnj Zwnj, IReadOnlyList<string> MayFollow)
	{
		public static PersianSuffixRule? Create(string? form, string? attachesAfter, int minimumBase, string? zwnj, IEnumerable<string>? mayFollow)
		{
			string text = form?.Trim() ?? string.Empty;
			if (text.Length == 0 || !Enum.TryParse<PersianSuffixAttachment>(attachesAfter, ignoreCase: true, out var result) || !Enum.IsDefined(result) || !Enum.TryParse<PersianSuffixZwnj>(zwnj, ignoreCase: true, out var result2) || !Enum.IsDefined(result2) || minimumBase < 1)
			{
				return null;
			}
			string[] mayFollow2 = (from entry in mayFollow ?? Enumerable.Empty<string>()
				select entry?.Trim() ?? string.Empty into entry
				where entry.Length > 0
				select entry).ToArray();
			return new PersianSuffixRule(text, result, minimumBase, result2, mayFollow2);
		}
	}
	public static class UnreadableFileBackup
	{
		private sealed record Reason(MessageKey? Key, object?[] Values)
		{
			public string Text
			{
				get
				{
					MessageKey? key = Key;
					string? text;
					if (key.HasValue)
					{
						MessageKey valueOrDefault = key.GetValueOrDefault();
						text = MessageText.Format(valueOrDefault, Values);
					}
					else
					{
						text = Convert.ToString(Values[0], CultureInfo.InvariantCulture);
						if (text == null)
						{
							return string.Empty;
						}
					}
					return text;
				}
			}
		}

		private sealed record Problem(MessageKey Template, string File, Reason Reason, string? Copy)
		{
			public string Text
			{
				get
				{
					if (Copy != null)
					{
						return MessageText.Format(Template, File, Reason.Text, Copy);
					}
					return MessageText.Format(Template, File, Reason.Text);
				}
			}
		}

		private static readonly object Sync = new object();

		private static readonly Dictionary<string, (Problem Problem, Reason Reason)> Blocked = new Dictionary<string, (Problem, Reason)>(StringComparer.OrdinalIgnoreCase);

		private static Problem? lastProblem;

		public static string? LastProblem => Volatile.Read(in lastProblem)?.Text;

		public static string? Keep(string path, string reason)
		{
			return Keep(path, new Reason(null, new object[1] { reason }));
		}

		public static string? Keep(string path, MessageKey reason, params object?[] values)
		{
			return Keep(path, new Reason(reason, values));
		}

		private static string? Keep(string path, Reason reason)
		{
			string fullPath = Path.GetFullPath(path);
			try
			{
				string text = $"{path}.unreadable-{DateTime.UtcNow:yyyyMMdd-HHmmssfff}";
				File.Copy(path, text, overwrite: false);
				Volatile.Write(ref lastProblem, new Problem(MessageKey.UnreadableFileCopyKept, Path.GetFileName(path), reason, Path.GetFileName(text)));
				lock (Sync)
				{
					Blocked.Remove(fullPath);
				}
				return text;
			}
			catch (Exception ex) when ((ex is IOException || ex is UnauthorizedAccessException) ? true : false)
			{
				Problem problem = new Problem(MessageKey.UnreadableFileBlocked, Path.GetFileName(path), reason, null);
				Volatile.Write(ref lastProblem, problem);
				lock (Sync)
				{
					Blocked[fullPath] = (problem, reason);
				}
				return null;
			}
		}

		public static string? BlockedReason(string path)
		{
			lock (Sync)
			{
				(Problem, Reason) value;
				return Blocked.TryGetValue(Path.GetFullPath(path), out value) ? value.Item1.Text : null;
			}
		}

		public static void ThrowIfBlocked(string path)
		{
			string text = BlockedReason(path);
			if (text != null)
			{
				throw new StoreWriteBlockedException(text);
			}
		}

		public static bool Retry(string path)
		{
			Reason item;
			lock (Sync)
			{
				if (!Blocked.TryGetValue(Path.GetFullPath(path), out (Problem, Reason) value))
				{
					return true;
				}
				item = value.Item2;
			}
			return Keep(path, item) != null;
		}
	}
	public sealed class StoreWriteBlockedException : IOException
	{
		public StoreWriteBlockedException(string message)
			: base(message)
		{
		}
	}
}
namespace SmartInput.Core.Diagnostics
{
	public sealed record CrashContext(string Version, string Commit, string FileVersion, string InstallKind, string Os, string Runtime, DateTimeOffset ProcessStart, bool IsVerification, bool StartedHidden);
	public sealed class CrashTestException : Exception
	{
		public CrashTestException(string site)
			: base("Planted test fault at " + site)
		{
		}
	}
	public static class CrashRecorder
	{
		public const int MaximumRecordBytes = 65536;

		private const int BreadcrumbCapacity = 64;

		private static readonly object BreadcrumbGate = new object();

		private static readonly (DateTime At, string Name, string? Value)[] Breadcrumbs = new (DateTime, string, string)[64];

		private static int _breadcrumbCount;

		private static volatile CrashContext? _context;

		private static volatile string? _directory;

		private static volatile string _typingMode = "unknown";

		private static volatile bool _typingEnabled = true;

		private static readonly object WriteGate = new object();

		[ThreadStatic]
		private static bool _recordingOnThisThread;

		private static Exception? _lastRecorded;

		public static string? DirectoryPath => _directory;

		public static string DefaultDirectory { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SmartInput", "Crashes");

		public static void Configure(string directory, CrashContext context)
		{
			_directory = Path.GetFullPath(directory);
			_context = context;
		}

		public static void SetState(string typingMode, bool enabled)
		{
			_typingMode = typingMode;
			_typingEnabled = enabled;
		}

		public static void Breadcrumb(string name, string? value = null)
		{
			lock (BreadcrumbGate)
			{
				Breadcrumbs[_breadcrumbCount % 64] = (At: DateTime.UtcNow, Name: name, Value: value);
				_breadcrumbCount++;
			}
		}

		public static string? Record(string source, Exception? exception, bool isTerminating = true)
		{
			return Write("crash", source, exception, isTerminating);
		}

		public static string? RecordFault(string source, Exception? exception)
		{
			return Write("fault", source, exception, isTerminating: false);
		}

		private static string? Write(string kind, string source, Exception? exception, bool isTerminating)
		{
			string directory = _directory;
			if (directory != null)
			{
				CrashContext context = _context;
				if ((object)context != null)
				{
					if (_recordingOnThisThread)
					{
						return null;
					}
					_recordingOnThisThread = true;
					bool lockTaken = false;
					try
					{
						Monitor.TryEnter(WriteGate, TimeSpan.FromSeconds(2L), ref lockTaken);
						if (exception != null && Volatile.Read(in _lastRecorded) == exception)
						{
							return null;
						}
						Volatile.Write(ref _lastRecorded, exception);
						DateTimeOffset now = DateTimeOffset.Now;
						byte[] array = CrashRecordWriter.ToJson(context, kind, source, exception, isTerminating, now, Environment.CurrentManagedThreadId, Thread.CurrentThread.Name, _typingMode, _typingEnabled, BreadcrumbSnapshot(), FaultRing.Summarize(), DiagnosticLog.IsEnabled);
						Directory.CreateDirectory(directory);
						IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
						DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(8, 4, invariantCulture);
						handler.AppendFormatted(kind);
						handler.AppendLiteral("-");
						handler.AppendFormatted(now, "yyyyMMdd-HHmmss-fff");
						handler.AppendLiteral("-");
						handler.AppendFormatted(Environment.ProcessId);
						handler.AppendLiteral("-");
						handler.AppendFormatted(Safe(source));
						handler.AppendLiteral(".json");
						string text = Path.Combine(directory, string.Create(invariantCulture, ref handler));
						using (FileStream fileStream = new FileStream(text, FileMode.CreateNew, FileAccess.Write, FileShare.Read, 4096, FileOptions.WriteThrough))
						{
							fileStream.Write(array);
						}
						if (DiagnosticLog.IsEnabled)
						{
							DiagnosticMessageHandler message = new DiagnosticMessageHandler(17, 4, out var shouldAppend);
							if (shouldAppend)
							{
								message.AppendFormatted(kind);
								message.AppendLiteral(" record (");
								message.AppendFormatted(source);
								message.AppendLiteral("): ");
								message.AppendFormatted(exception?.GetType().FullName ?? "(no exception)");
								message.AppendLiteral(" (0x");
								message.AppendFormatted(exception?.HResult ?? 0, "X8");
								message.AppendLiteral(")");
							}
							DiagnosticLog.Write("Crash", ref message);
							DiagnosticLog.Flush(TimeSpan.FromMilliseconds(500L));
						}
						return text;
					}
					catch
					{
						return null;
					}
					finally
					{
						if (lockTaken)
						{
							Monitor.Exit(WriteGate);
						}
						_recordingOnThisThread = false;
					}
				}
			}
			return null;
		}

		private static string Safe(string source)
		{
			StringBuilder stringBuilder = new StringBuilder(source.Length);
			foreach (char c in source)
			{
				stringBuilder.Append((char.IsAsciiLetterOrDigit(c) || c == '-') ? c : '_');
			}
			return stringBuilder.ToString();
		}

		private static IReadOnlyList<(DateTime At, string Name, string? Value)> BreadcrumbSnapshot()
		{
			lock (BreadcrumbGate)
			{
				int num = Math.Min(_breadcrumbCount, 64);
				List<(DateTime, string, string)> list = new List<(DateTime, string, string)>(num);
				for (int i = _breadcrumbCount - num; i < _breadcrumbCount; i++)
				{
					list.Add(Breadcrumbs[i % 64]);
				}
				return list;
			}
		}

		internal static void ResetForTests()
		{
			_directory = null;
			_context = null;
			_typingMode = "unknown";
			_typingEnabled = true;
			Volatile.Write(ref _lastRecorded, null);
			lock (BreadcrumbGate)
			{
				_breadcrumbCount = 0;
			}
		}
	}
	public static class CrashRecordWriter
	{
		private const int MaximumInnerDepth = 5;

		private const int MaximumStackChars = 12000;

		public static byte[] ToJson(CrashContext context, string kind, string source, Exception? exception, bool isTerminating, DateTimeOffset now, int threadId, string? threadName, string typingMode, bool typingEnabled, IReadOnlyList<(DateTime At, string Name, string? Value)> breadcrumbs, IReadOnlyList<FaultSummary> faults, bool debugLogOn)
		{
			byte[] array = Build(context, kind, source, exception, isTerminating, now, threadId, threadName, typingMode, typingEnabled, breadcrumbs, faults, debugLogOn, 12000);
			if (array.Length > 65536)
			{
				return Build(context, kind, source, exception, isTerminating, now, threadId, threadName, typingMode, typingEnabled, breadcrumbs.TakeLast(16).ToList(), faults.Take(16).ToList(), debugLogOn, 2000);
			}
			return array;
		}

		private static byte[] Build(CrashContext context, string kind, string source, Exception? exception, bool isTerminating, DateTimeOffset now, int threadId, string? threadName, string typingMode, bool typingEnabled, IReadOnlyList<(DateTime At, string Name, string? Value)> breadcrumbs, IReadOnlyList<FaultSummary> faults, bool debugLogOn, int stackChars)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, new JsonWriterOptions
			{
				Indented = true,
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
			}))
			{
				utf8JsonWriter.WriteStartObject();
				utf8JsonWriter.WriteString("kind", kind);
				utf8JsonWriter.WriteString("source", source);
				utf8JsonWriter.WriteBoolean("isTerminating", isTerminating);
				utf8JsonWriter.WriteString("time", now.ToString("O", CultureInfo.InvariantCulture));
				utf8JsonWriter.WriteString("version", context.Version);
				utf8JsonWriter.WriteString("commit", context.Commit);
				utf8JsonWriter.WriteString("fileVersion", context.FileVersion);
				utf8JsonWriter.WriteString("installKind", context.InstallKind);
				utf8JsonWriter.WriteString("os", context.Os);
				utf8JsonWriter.WriteString("runtime", context.Runtime);
				utf8JsonWriter.WriteNumber("processId", Environment.ProcessId);
				utf8JsonWriter.WriteString("processStart", context.ProcessStart.ToString("O", CultureInfo.InvariantCulture));
				utf8JsonWriter.WriteNumber("processUptimeSeconds", Math.Round((now - context.ProcessStart).TotalSeconds, 1));
				utf8JsonWriter.WriteNumber("systemUptimeSeconds", Environment.TickCount64 / 1000);
				utf8JsonWriter.WriteBoolean("startedHidden", context.StartedHidden);
				utf8JsonWriter.WriteBoolean("verification", context.IsVerification);
				utf8JsonWriter.WriteString("typingMode", typingMode);
				utf8JsonWriter.WriteBoolean("typingEnabled", typingEnabled);
				utf8JsonWriter.WriteBoolean("debugLogOn", debugLogOn);
				utf8JsonWriter.WriteNumber("threadId", threadId);
				utf8JsonWriter.WriteString("threadName", threadName ?? "");
				utf8JsonWriter.WritePropertyName("exception");
				if (exception == null)
				{
					utf8JsonWriter.WriteNullValue();
				}
				else
				{
					WriteException(utf8JsonWriter, exception, 0, stackChars);
				}
				utf8JsonWriter.WriteStartArray("breadcrumbs");
				foreach (var (dateTime, value, text) in breadcrumbs)
				{
					utf8JsonWriter.WriteStartObject();
					utf8JsonWriter.WriteString("at", dateTime.ToString("O", CultureInfo.InvariantCulture));
					utf8JsonWriter.WriteString("name", value);
					if (text != null)
					{
						utf8JsonWriter.WriteString("value", text);
					}
					utf8JsonWriter.WriteEndObject();
				}
				utf8JsonWriter.WriteEndArray();
				WriteFaults(utf8JsonWriter, faults);
				utf8JsonWriter.WriteEndObject();
			}
			return memoryStream.ToArray();
		}

		public static void WriteFaults(Utf8JsonWriter writer, IReadOnlyList<FaultSummary> faults)
		{
			writer.WriteStartArray("faults");
			foreach (FaultSummary fault in faults)
			{
				writer.WriteStartObject();
				writer.WriteString("site", fault.Site.ToString());
				writer.WriteString("type", fault.TypeName);
				IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
				DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(2, 1, invariantCulture);
				handler.AppendLiteral("0x");
				handler.AppendFormatted(fault.HResult, "X8");
				writer.WriteString("hresult", string.Create(invariantCulture, ref handler));
				writer.WriteNumber("count", fault.Count);
				writer.WriteNumber("firstMs", fault.FirstMs);
				writer.WriteNumber("lastMs", fault.LastMs);
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
		}

		private static void WriteException(Utf8JsonWriter writer, Exception exception, int depth, int stackChars)
		{
			writer.WriteStartObject();
			Type type = exception.GetType();
			writer.WriteString("type", type.FullName ?? type.Name);
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider provider = invariantCulture;
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(2, 1, invariantCulture);
			handler.AppendLiteral("0x");
			handler.AppendFormatted(exception.HResult, "X8");
			writer.WriteString("hresult", string.Create(provider, ref handler));
			if (exception is ExternalException { ErrorCode: var errorCode })
			{
				invariantCulture = CultureInfo.InvariantCulture;
				IFormatProvider provider2 = invariantCulture;
				DefaultInterpolatedStringHandler handler2 = new DefaultInterpolatedStringHandler(2, 1, invariantCulture);
				handler2.AppendLiteral("0x");
				handler2.AppendFormatted(errorCode, "X8");
				writer.WriteString("errorCode", string.Create(provider2, ref handler2));
			}
			if (ExceptionMessagePolicy.Allows(type))
			{
				writer.WriteString("message", exception.Message);
			}
			else
			{
				writer.WriteString("message", "(withheld)");
				writer.WriteNumber("messageLength", exception.Message.Length);
			}
			string text = exception.StackTrace ?? "";
			writer.WriteString("stack", (text.Length <= stackChars) ? text : (text.Substring(0, stackChars) + " ..."));
			object obj;
			if (!(exception is AggregateException ex2))
			{
				Exception innerException = exception.InnerException;
				obj = ((innerException != null) ? ReadOnlyCollection.CreateCollection<Exception>((Exception)innerException) : ReadOnlyCollection.CreateCollection(default(ReadOnlySpan<Exception>)));
			}
			else
			{
				obj = ex2.InnerExceptions;
			}
			ReadOnlyCollection<Exception> readOnlyCollection = (ReadOnlyCollection<Exception>)obj;
			if (readOnlyCollection.Count > 0 && depth < 5)
			{
				writer.WriteStartArray("inner");
				foreach (Exception item in readOnlyCollection.Take(8))
				{
					WriteException(writer, item, depth + 1, stackChars / 2);
				}
				writer.WriteEndArray();
			}
			writer.WriteEndObject();
		}
	}
	public enum DiagnosticDetail
	{
		Incidents,
		Full
	}
	public sealed record DiagnosticJournalLimits
	{
		public DiagnosticDetail Detail { get; init; } = DiagnosticDetail.Full;

		public int OperationRing { get; init; } = 128;

		public int ContextRing { get; init; } = 128;

		public int IncidentBefore { get; init; } = 20;

		public int IncidentAfter { get; init; } = 10;

		public TimeSpan IncidentExpiry { get; init; } = TimeSpan.FromSeconds(5L);

		public TimeSpan SameIncidentWindow { get; init; } = TimeSpan.FromSeconds(60L);

		public int MaxIncidentsPerMinute { get; init; } = 6;

		public int QueueCapacity { get; init; } = 4096;

		public int MaxRecordChars { get; init; } = 65536;

		public int MaxFieldChars { get; init; } = 320;

		public int MaxNoteChars { get; init; } = 2048;

		public int MaxNotesPerOperation { get; init; } = 32;

		public int MaxOpenOperations { get; init; } = 64;

		public TimeSpan ApplicationSummaryInterval { get; init; } = TimeSpan.FromMinutes(10L);

		public int MaxApplications { get; init; } = 64;
	}
	public sealed class DiagnosticJournal : IDisposable
	{
		private enum Kind
		{
			Begin,
			Stage,
			Note,
			End,
			Context,
			Incident,
			Repeat,
			Settings,
			Sync,
			Report,
			Summary,
			Session,
			Target,
			Tally,
			Latency,
			Fact,
			Apps
		}

		private readonly struct Item
		{
			public Kind Kind { get; init; }

			public long Mono { get; init; }

			public int Op { get; init; }

			public int Rev { get; init; }

			public int Ctx { get; init; }

			public string Name { get; init; }

			public string? Text { get; init; }

			public long Value { get; init; }

			public object?[]? Pairs { get; init; }

			public object? Payload { get; init; }
		}

		private sealed class OpState
		{
			public int Id;

			public long Start;

			public string Name = string.Empty;

			public int Rev;

			public int Ctx;

			public List<KeyValuePair<string, string>> Fields = new List<KeyValuePair<string, string>>();

			public List<string> Stages = new List<string>();

			public List<string> Notes = new List<string>();

			public int NotesDropped;
		}

		private sealed record Entry(long Mono, string Json, string Name = "", int Repeat = 1, string Base = "", string Ref = "");

		private sealed class Pending
		{
			public required string Json;

			public required List<string> After;

			public required long Deadline;

			public int Id;
		}

		private sealed class Repeats
		{
			public long Count;

			public long First;

			public long Last;

			public string Sample = string.Empty;
		}

		private sealed class DurationStat
		{
			public long Count;

			public long TotalTicks;

			public long MaxTicks;
		}

		private sealed class LatencyTally
		{
			public long Count;

			public long Sum;

			public long Max;

			public readonly long[] Buckets = new long[LatencyBounds.Length + 1];

			public void Add(long milliseconds)
			{
				long num = Math.Max(0L, milliseconds);
				Count++;
				Sum += num;
				Max = Math.Max(Max, num);
				int i;
				for (i = 0; i < LatencyBounds.Length && num > LatencyBounds[i]; i++)
				{
				}
				Buckets[i]++;
			}

			public string Percentile(double fraction)
			{
				long num = (long)Math.Ceiling((double)Count * fraction);
				long num2 = 0L;
				for (int i = 0; i < Buckets.Length; i++)
				{
					if (num <= 0)
					{
						break;
					}
					num2 += Buckets[i];
					if (num2 >= num)
					{
						return BucketName(i);
					}
				}
				return "n/a";
			}

			public static string BucketName(int bucket)
			{
				if (bucket >= LatencyBounds.Length)
				{
					return ">" + LatencyBounds[^1].ToString(CultureInfo.InvariantCulture);
				}
				return "<=" + LatencyBounds[bucket].ToString(CultureInfo.InvariantCulture);
			}
		}

		private sealed class AppTally
		{
			public long FirstMs;

			public long LastMs;

			public string Title = string.Empty;

			public readonly SortedDictionary<string, long> Counts = new SortedDictionary<string, long>(StringComparer.Ordinal);

			public readonly SortedDictionary<string, LatencyTally> Latency = new SortedDictionary<string, LatencyTally>(StringComparer.Ordinal);

			public readonly SortedDictionary<string, string> Facts = new SortedDictionary<string, string>(StringComparer.Ordinal);
		}

		public const int FormatVersion = 1;

		private readonly Action<string> _sink;

		private readonly Func<long> _now;

		private readonly long _ticksPerMillisecond;

		private readonly DiagnosticJournalLimits _limits;

		private readonly BlockingCollection<Item> _queue;

		private readonly Thread _thread;

		private readonly ConcurrentDictionary<string, long[]> _counters = new ConcurrentDictionary<string, long[]>();

		private readonly List<Func<string>> _summarySources = new List<Func<string>>();

		private readonly object _headerGate = new object();

		private readonly List<string> _headerLines = new List<string>();

		private int _nextOp;

		private int _current;

		private int _revision;

		private int _contextGeneration;

		private int _incidentIds;

		private int _targetIds;

		private long _dropped;

		private long _truncated;

		private long _suppressedIncidents;

		private long _overwrittenOps;

		private long _overwrittenContext;

		private long _coalesced;

		private readonly string _sessionId;

		private readonly DateTimeOffset _startedAt;

		private readonly long _startTicks;

		private readonly Dictionary<int, OpState> _open = new Dictionary<int, OpState>();

		private readonly LinkedList<Entry> _ops = new LinkedList<Entry>();

		private readonly LinkedList<Entry> _context = new LinkedList<Entry>();

		private readonly List<Pending> _pending = new List<Pending>();

		private readonly Dictionary<string, long> _incidentLast = new Dictionary<string, long>();

		private readonly Dictionary<string, Repeats> _repeats = new Dictionary<string, Repeats>();

		private readonly Queue<long> _incidentTimes = new Queue<long>();

		private Dictionary<string, string> _settings = new Dictionary<string, string>();

		private long _lastRepeatFlush;

		private readonly Dictionary<string, AppTally> _apps = new Dictionary<string, AppTally>(StringComparer.Ordinal);

		private string _currentApp = "(no target described yet)";

		private bool _appsChanged;

		private long _lastAppsWrite;

		private readonly ConcurrentDictionary<string, DurationStat> _durations = new ConcurrentDictionary<string, DurationStat>();

		private const string NoTargetYet = "(no target described yet)";

		private const string OtherApplications = "(other applications)";

		private static readonly long[] LatencyBounds = new long[12]
		{
			1L, 2L, 5L, 10L, 20L, 50L, 100L, 200L, 500L, 1000L,
			2000L, 5000L
		};

		private static readonly HashSet<string> Coalesced = new HashSet<string>(StringComparer.Ordinal) { "target.epoch", "worker.request" };

		private static readonly HashSet<string> StructuralNames = new HashSet<string>(StringComparer.Ordinal)
		{
			"t", "ms", "dur", "ctx", "rev", "op", "id", "key", "outcome", "name",
			"stages", "notes", "notesDropped", "before", "after", "open", "full", "changes", "label", "session",
			"v", "started", "clock", "detail", "tid", "app", "records"
		};

		public string SessionId => _sessionId;

		public DiagnosticDetail Detail => _limits.Detail;

		public int Revision => Volatile.Read(in _revision);

		public int ContextGeneration => Volatile.Read(in _contextGeneration);

		public int CurrentOperation => Volatile.Read(in _current);

		public long Dropped => Interlocked.Read(in _dropped);

		public long Truncated => Interlocked.Read(in _truncated);

		public long SuppressedIncidents => Interlocked.Read(in _suppressedIncidents);

		public long OverwrittenOperations => Interlocked.Read(in _overwrittenOps);

		public long Timestamp => _now();

		public DiagnosticJournal(Action<string> sink, DiagnosticJournalLimits? limits = null, Func<long>? clock = null)
		{
			_sink = sink;
			_limits = limits ?? new DiagnosticJournalLimits();
			_now = clock ?? new Func<long>(Stopwatch.GetTimestamp);
			_ticksPerMillisecond = ((clock == null) ? (Stopwatch.Frequency / 1000) : 1);
			_startTicks = _now();
			_lastRepeatFlush = _startTicks;
			_lastAppsWrite = _startTicks;
			_startedAt = DateTimeOffset.Now;
			_sessionId = _startedAt.ToString("yyyyMMdd-HHmmss", CultureInfo.InvariantCulture) + "-" + Environment.ProcessId.ToString(CultureInfo.InvariantCulture);
			_queue = new BlockingCollection<Item>(new ConcurrentQueue<Item>(), _limits.QueueCapacity);
			_thread = new Thread(Run)
			{
				IsBackground = true,
				Name = "Diyar diagnostic journal",
				Priority = ThreadPriority.BelowNormal
			};
			_thread.Start();
		}

		public IReadOnlyList<string> HeaderLines()
		{
			lock (_headerGate)
			{
				return new <>z__ReadOnlyArray<string>(_headerLines.ToArray());
			}
		}

		public void AddSummarySource(Func<string> describe)
		{
			_summarySources.Add(describe);
		}

		public void Count(string name)
		{
			Interlocked.Increment(ref _counters.GetOrAdd(name, (string _) => new long[1])[0]);
		}

		public long CounterValue(string name)
		{
			if (!_counters.TryGetValue(name, out long[] value))
			{
				return 0L;
			}
			return Interlocked.Read(in value[0]);
		}

		public void RecordDuration(string name, long startTimestamp)
		{
			long num = Math.Max(0L, _now() - startTimestamp);
			DurationStat orAdd = _durations.GetOrAdd(name, (string _) => new DurationStat());
			Interlocked.Increment(ref orAdd.Count);
			Interlocked.Add(ref orAdd.TotalTicks, num);
			long num2;
			while ((num2 = Interlocked.Read(in orAdd.MaxTicks)) < num && Interlocked.CompareExchange(ref orAdd.MaxTicks, num, num2) != num2)
			{
			}
		}

		public (long Count, double MeanMs, double MaxMs) DurationValue(string name)
		{
			if (!_durations.TryGetValue(name, out DurationStat value) || Interlocked.Read(in value.Count) <= 0)
			{
				return (Count: 0L, MeanMs: 0.0, MaxMs: 0.0);
			}
			return (Count: Interlocked.Read(in value.Count), MeanMs: (double)Interlocked.Read(in value.TotalTicks) / (double)_ticksPerMillisecond / (double)Interlocked.Read(in value.Count), MaxMs: (double)Interlocked.Read(in value.MaxTicks) / (double)_ticksPerMillisecond);
		}

		public int BeginOperation(string name, params object?[] pairs)
		{
			int num = Interlocked.Increment(ref _nextOp);
			Volatile.Write(ref _current, num);
			Enqueue(new Item
			{
				Kind = Kind.Begin,
				Op = num,
				Name = name,
				Pairs = pairs,
				Rev = Revision,
				Ctx = ContextGeneration
			});
			return num;
		}

		public void Stage(int op, string stage, string? detail = null)
		{
			Enqueue(new Item
			{
				Kind = Kind.Stage,
				Op = op,
				Name = stage,
				Text = detail
			});
		}

		public void Note(string area, string text)
		{
			if (area == "Environment" && text.Contains("Dispatching probe request", StringComparison.Ordinal))
			{
				Count("environment.probe.dispatch");
				return;
			}
			Enqueue(new Item
			{
				Kind = Kind.Note,
				Op = CurrentOperation,
				Name = area,
				Text = text
			});
		}

		public void EndOperation(int op, string outcome, params object?[] pairs)
		{
			Enqueue(new Item
			{
				Kind = Kind.End,
				Op = op,
				Name = outcome,
				Pairs = pairs
			});
			Interlocked.CompareExchange(ref _current, 0, op);
		}

		public int Invalidate(string reason, params object?[] pairs)
		{
			int num = Interlocked.Increment(ref _contextGeneration);
			Count("invalidate." + reason);
			Enqueue(new Item
			{
				Kind = Kind.Context,
				Name = "inval",
				Text = reason,
				Pairs = pairs,
				Ctx = num,
				Op = CurrentOperation
			});
			return num;
		}

		public void Event(string name, params object?[] pairs)
		{
			Enqueue(new Item
			{
				Kind = Kind.Context,
				Name = name,
				Pairs = pairs,
				Ctx = ContextGeneration,
				Op = CurrentOperation
			});
		}

		public void Incident(string key, string reason, params object?[] pairs)
		{
			Enqueue(new Item
			{
				Kind = Kind.Incident,
				Name = key,
				Text = reason,
				Pairs = pairs,
				Op = CurrentOperation
			});
		}

		public void Repeated(string key, string sample)
		{
			Enqueue(new Item
			{
				Kind = Kind.Repeat,
				Name = key,
				Text = sample
			});
		}

		public int Target(string application, params object?[] pairs)
		{
			int num = Interlocked.Increment(ref _targetIds);
			Enqueue(new Item
			{
				Kind = Kind.Target,
				Op = num,
				Name = application,
				Pairs = pairs,
				Ctx = ContextGeneration
			}, force: true);
			return num;
		}

		public void Tally(string name)
		{
			Enqueue(new Item
			{
				Kind = Kind.Tally,
				Name = name
			});
		}

		public void TallyLatency(string name, long milliseconds)
		{
			Enqueue(new Item
			{
				Kind = Kind.Latency,
				Name = name,
				Value = milliseconds
			});
		}

		public void TallyFact(string name, string value)
		{
			Enqueue(new Item
			{
				Kind = Kind.Fact,
				Name = name,
				Text = value
			});
		}

		public void WriteApplicationSummary(string reason)
		{
			Enqueue(new Item
			{
				Kind = Kind.Apps,
				Text = reason
			}, force: true);
		}

		public int PublishSettings(string label, IReadOnlyDictionary<string, string> values, bool full = false)
		{
			int num = Interlocked.Increment(ref _revision);
			Enqueue(new Item
			{
				Kind = Kind.Settings,
				Name = label,
				Rev = num,
				Payload = new Dictionary<string, string>(values),
				Ctx = (full ? 1 : 0)
			}, force: true);
			return num;
		}

		public void StartSession(IReadOnlyDictionary<string, string> environment)
		{
			Enqueue(new Item
			{
				Kind = Kind.Session,
				Payload = new Dictionary<string, string>(environment)
			}, force: true);
		}

		public bool Drain(TimeSpan timeout)
		{
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
			if (!_queue.TryAdd(new Item
			{
				Kind = Kind.Sync,
				Payload = taskCompletionSource
			}, 0))
			{
				return false;
			}
			return taskCompletionSource.Task.Wait(timeout);
		}

		public Task<string> CaptureReport(string? expected, string? label = null)
		{
			TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
			if (!_queue.TryAdd(new Item
			{
				Kind = Kind.Report,
				Name = (label ?? "problem"),
				Text = expected,
				Payload = taskCompletionSource,
				Mono = _now(),
				Rev = Revision,
				Ctx = ContextGeneration
			}, 0))
			{
				taskCompletionSource.TrySetResult("{\"t\":\"report\",\"error\":\"queue full\"}");
			}
			return taskCompletionSource.Task;
		}

		public Task<string> Summarize()
		{
			TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
			if (!_queue.TryAdd(new Item
			{
				Kind = Kind.Summary,
				Payload = taskCompletionSource,
				Mono = _now()
			}, 0))
			{
				taskCompletionSource.TrySetResult("summary unavailable: queue full");
			}
			return taskCompletionSource.Task;
		}

		public void Dispose()
		{
			try
			{
				TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
				if (_queue.TryAdd(new Item
				{
					Kind = Kind.Summary,
					Payload = taskCompletionSource,
					Mono = _now(),
					Name = "final"
				}, 0))
				{
					taskCompletionSource.Task.Wait(TimeSpan.FromSeconds(2L));
				}
			}
			catch (Exception)
			{
			}
			_queue.CompleteAdding();
			_thread.Join(TimeSpan.FromSeconds(2L));
		}

		private void Enqueue(Item item, bool force = false)
		{
			Item item2;
			if (item.Mono != 0L)
			{
				item2 = item;
			}
			else
			{
				Item item3 = item;
				item3.Mono = _now();
				item2 = item3;
			}
			Item item4 = item2;
			bool flag;
			try
			{
				flag = _queue.TryAdd(item4, 0);
			}
			catch (InvalidOperationException)
			{
				flag = false;
			}
			if (!flag)
			{
				Interlocked.Increment(ref _dropped);
			}
		}

		private void Run()
		{
			try
			{
				while (!_queue.IsCompleted)
				{
					if (_queue.TryTake(out var item, 500))
					{
						try
						{
							Process(item);
						}
						catch (Exception)
						{
							Interlocked.Increment(ref _dropped);
						}
					}
					Tick();
				}
			}
			catch (ObjectDisposedException)
			{
			}
		}

		private void Tick()
		{
			long num = _now();
			for (int num2 = _pending.Count - 1; num2 >= 0; num2--)
			{
				if (num >= _pending[num2].Deadline)
				{
					WriteIncident(_pending[num2]);
					_pending.RemoveAt(num2);
				}
			}
			if (_repeats.Count > 0 && (num - _lastRepeatFlush) / _ticksPerMillisecond > 30000)
			{
				FlushRepeats();
			}
			if (_appsChanged && (num - _lastAppsWrite) / _ticksPerMillisecond >= (long)_limits.ApplicationSummaryInterval.TotalMilliseconds)
			{
				WriteApplications("periodic", num);
			}
		}

		private void Process(Item item)
		{
			switch (item.Kind)
			{
			case Kind.Begin:
				if (_open.Count >= _limits.MaxOpenOperations)
				{
					OpState opState = _open.Values.MinBy((OpState state) => state.Start);
					_open.Remove(opState.Id);
					FinishOperation(opState, item.Mono, "abandoned", new List<KeyValuePair<string, string>>());
				}
				_open[item.Op] = new OpState
				{
					Id = item.Op,
					Start = item.Mono,
					Name = item.Name,
					Rev = item.Rev,
					Ctx = item.Ctx,
					Fields = Pairs(item.Pairs)
				};
				break;
			case Kind.Stage:
			{
				if (_open.TryGetValue(item.Op, out OpState value3))
				{
					value3.Stages.Add(Cut($"[\"{Escape(item.Name)}\",{Ms(item.Mono - value3.Start)},\"{Escape(Field(item.Text))}\"]"));
				}
				break;
			}
			case Kind.Note:
			{
				if (_open.TryGetValue(item.Op, out OpState value5))
				{
					if (value5.Notes.Count < _limits.MaxNotesPerOperation)
					{
						value5.Notes.Add(NoteField(item.Name + ": " + item.Text));
					}
					else
					{
						value5.NotesDropped++;
					}
					break;
				}
				AddContext(item.Mono, $"{{\"t\":\"note\",\"ms\":{Ms(item.Mono - _startTicks)},\"area\":\"{Escape(item.Name)}\",\"text\":\"{Escape(NoteField(item.Text))}\"}}", "note");
				break;
			}
			case Kind.End:
			{
				if (_open.Remove(item.Op, out OpState value2))
				{
					FinishOperation(value2, item.Mono, item.Name, Pairs(item.Pairs));
				}
				break;
			}
			case Kind.Context:
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("{\"t\":\"").Append(Escape(item.Name)).Append("\",\"ms\":")
					.Append(Ms(item.Mono - _startTicks))
					.Append(",\"ctx\":")
					.Append(item.Ctx.ToString(CultureInfo.InvariantCulture));
				if (item.Op != 0)
				{
					stringBuilder.Append(",\"op\":").Append(item.Op.ToString(CultureInfo.InvariantCulture));
				}
				if (item.Text != null)
				{
					stringBuilder.Append(",\"reason\":\"").Append(Escape(Field(item.Text))).Append('"');
				}
				AppendPairs(stringBuilder, Pairs(item.Pairs));
				stringBuilder.Append('}');
				AddContext(item.Mono, stringBuilder.ToString(), item.Name);
				break;
			}
			case Kind.Incident:
				BeginIncident(item);
				break;
			case Kind.Repeat:
			{
				if (!_repeats.TryGetValue(item.Name, out Repeats value4))
				{
					Dictionary<string, Repeats> repeats = _repeats;
					string name = item.Name;
					Repeats repeats2 = new Repeats
					{
						First = item.Mono
					};
					value4 = repeats2;
					repeats[name] = repeats2;
				}
				value4.Count++;
				value4.Last = item.Mono;
				value4.Sample = Field(item.Text);
				break;
			}
			case Kind.Settings:
				PublishSettingsLine(item);
				break;
			case Kind.Session:
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				stringBuilder3.Append("{\"t\":\"session\",\"v\":").Append(1).Append(",\"session\":\"")
					.Append(Escape(_sessionId))
					.Append("\",\"started\":\"")
					.Append(_startedAt.ToString("o", CultureInfo.InvariantCulture))
					.Append("\",\"clock\":\"ms since start (monotonic)\"")
					.Append(",\"detail\":\"")
					.Append((_limits.Detail == DiagnosticDetail.Full) ? "full" : "incidents")
					.Append('"');
				AppendPairs(stringBuilder3, ((Dictionary<string, string>)item.Payload).Select((KeyValuePair<string, string> p) => p).ToList());
				stringBuilder3.Append('}');
				WriteHeader(stringBuilder3.ToString(), "session");
				break;
			}
			case Kind.Report:
				((TaskCompletionSource<string>)item.Payload).TrySetResult(BuildReport(item));
				break;
			case Kind.Summary:
			{
				FlushRepeats();
				string text5 = BuildSummary(item.Mono);
				if (item.Name == "final")
				{
					foreach (Pending item2 in _pending)
					{
						WriteIncident(item2);
					}
					_pending.Clear();
					WriteApplications("final", item.Mono);
					Write("{\"t\":\"summary\",\"final\":true,\"text\":\"" + Escape(text5) + "\"}");
				}
				((TaskCompletionSource<string>)item.Payload).TrySetResult(text5);
				break;
			}
			case Kind.Sync:
				((TaskCompletionSource<bool>)item.Payload).TrySetResult(result: true);
				break;
			case Kind.Target:
			{
				List<KeyValuePair<string, string>> list = Pairs(item.Pairs);
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.Append("{\"t\":\"target\",\"tid\":").Append(item.Op.ToString(CultureInfo.InvariantCulture)).Append(",\"ms\":")
					.Append(Ms(item.Mono - _startTicks))
					.Append(",\"ctx\":")
					.Append(item.Ctx.ToString(CultureInfo.InvariantCulture))
					.Append(",\"app\":\"")
					.Append(Escape(item.Name))
					.Append('"');
				AppendPairs(stringBuilder2, list);
				stringBuilder2.Append('}');
				string text = Cut(stringBuilder2.ToString());
				_currentApp = item.Name;
				AppTally appTally2 = CurrentApp(item.Mono);
				Increment(appTally2, "target.events");
				foreach (var (text4, title) in list)
				{
					if (text4 == "title")
					{
						appTally2.Title = title;
					}
				}
				WriteHeader(text, "target");
				AddContext(item.Mono, text, "target", written: true);
				break;
			}
			case Kind.Tally:
				Increment(CurrentApp(item.Mono), item.Name);
				break;
			case Kind.Latency:
			{
				AppTally appTally = CurrentApp(item.Mono);
				if (!appTally.Latency.TryGetValue(item.Name, out LatencyTally value))
				{
					value = (appTally.Latency[item.Name] = new LatencyTally());
				}
				value.Add(item.Value);
				break;
			}
			case Kind.Fact:
				CurrentApp(item.Mono).Facts[item.Name] = Field(item.Text);
				break;
			case Kind.Apps:
				WriteApplications(item.Text ?? "requested", item.Mono);
				break;
			}
		}

		private AppTally CurrentApp(long mono)
		{
			string text = _currentApp;
			if (!_apps.TryGetValue(text, out AppTally value))
			{
				if (_apps.Count >= _limits.MaxApplications)
				{
					text = "(other applications)";
				}
				if (!_apps.TryGetValue(text, out value))
				{
					Dictionary<string, AppTally> apps = _apps;
					string key = text;
					AppTally appTally = new AppTally
					{
						FirstMs = Ms(mono - _startTicks)
					};
					value = appTally;
					apps[key] = appTally;
				}
			}
			value.LastMs = Ms(mono - _startTicks);
			_appsChanged = true;
			return value;
		}

		private static void Increment(AppTally app, string name)
		{
			app.Counts[name] = (app.Counts.TryGetValue(name, out var value) ? (value + 1) : 1);
		}

		private void WriteApplications(string reason, long mono)
		{
			_appsChanged = false;
			_lastAppsWrite = mono;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\"t\":\"apps\",\"reason\":\"").Append(Escape(reason)).Append("\",\"ms\":")
				.Append(Ms(mono - _startTicks))
				.Append(",\"session\":\"")
				.Append(Escape(_sessionId))
				.Append("\",\"basis\":\"cumulative since the session started; each count belongs to the target described last when it was recorded\"")
				.Append(",\"apps\":")
				.Append(BuildApplications())
				.Append('}');
			Write(stringBuilder.ToString());
		}

		private string BuildApplications()
		{
			List<string> list = new List<string>(_apps.Count);
			foreach (var (value, appTally2) in _apps.OrderBy((KeyValuePair<string, AppTally> a) => a.Key, StringComparer.Ordinal))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("{\"app\":\"").Append(Escape(value)).Append("\",\"title\":\"")
					.Append(Escape(appTally2.Title))
					.Append("\",\"firstMs\":")
					.Append(appTally2.FirstMs.ToString(CultureInfo.InvariantCulture))
					.Append(",\"lastMs\":")
					.Append(appTally2.LastMs.ToString(CultureInfo.InvariantCulture))
					.Append(",\"counts\":{")
					.Append(string.Join(',', appTally2.Counts.Select((KeyValuePair<string, long> c) => "\"" + Escape(c.Key) + "\":" + c.Value.ToString(CultureInfo.InvariantCulture))))
					.Append("},\"latencyMs\":{")
					.Append(string.Join(',', appTally2.Latency.Select((KeyValuePair<string, LatencyTally> l) => "\"" + Escape(l.Key) + "\":" + DescribeLatency(l.Value))))
					.Append("},\"facts\":{")
					.Append(string.Join(',', appTally2.Facts.Select((KeyValuePair<string, string> f) => "\"" + Escape(f.Key) + "\":\"" + Escape(f.Value) + "\"")))
					.Append("}}");
				list.Add(stringBuilder.ToString());
			}
			return "[" + string.Join(',', list) + "]";
		}

		private static string DescribeLatency(LatencyTally latency)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\"n\":").Append(latency.Count.ToString(CultureInfo.InvariantCulture)).Append(",\"mean\":")
				.Append(((latency.Count == 0L) ? 0 : (latency.Sum / latency.Count)).ToString(CultureInfo.InvariantCulture))
				.Append(",\"p50\":\"")
				.Append(latency.Percentile(0.5))
				.Append("\",\"p95\":\"")
				.Append(latency.Percentile(0.95))
				.Append("\",\"max\":")
				.Append(latency.Max.ToString(CultureInfo.InvariantCulture))
				.Append(",\"hist\":{");
			bool flag = true;
			for (int i = 0; i < latency.Buckets.Length; i++)
			{
				if (latency.Buckets[i] != 0L)
				{
					if (!flag)
					{
						stringBuilder.Append(',');
					}
					flag = false;
					stringBuilder.Append('"').Append(LatencyTally.BucketName(i)).Append("\":")
						.Append(latency.Buckets[i].ToString(CultureInfo.InvariantCulture));
				}
			}
			return stringBuilder.Append("}}").ToString();
		}

		private void FinishOperation(OpState op, long now, string outcome, List<KeyValuePair<string, string>> endFields)
		{
			string text = BuildOperationJson(op, now, outcome, endFields, op.Notes.Count, int.MaxValue, stages: true, int.MaxValue);
			if (text.Length > _limits.MaxRecordChars)
			{
				text = BuildOperationJson(op, now, outcome, endFields, 4, 90, stages: true, 100);
				Interlocked.Increment(ref _truncated);
			}
			if (text.Length > _limits.MaxRecordChars)
			{
				text = BuildOperationJson(op, now, outcome, endFields, 0, 0, stages: false, 60);
			}
			text = Cut(text);
			if (_limits.Detail == DiagnosticDetail.Full)
			{
				Write(text);
			}
			AppTally app = CurrentApp(now);
			Increment(app, op.Name);
			Increment(app, op.Name + "." + outcome);
			string text2 = "op:" + op.Id.ToString(CultureInfo.InvariantCulture);
			_ops.AddLast(new Entry(now, text, "", 1, "", text2));
			if (_ops.Count > _limits.OperationRing)
			{
				_ops.RemoveFirst();
				Interlocked.Increment(ref _overwrittenOps);
			}
			FeedPending(text, text2);
		}

		private string BuildOperationJson(OpState op, long now, string outcome, List<KeyValuePair<string, string>> endFields, int notes, int noteChars, bool stages, int fieldChars)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\"t\":\"op\",\"op\":").Append(op.Id.ToString(CultureInfo.InvariantCulture)).Append(",\"name\":\"")
				.Append(Escape(op.Name))
				.Append("\",\"ms\":")
				.Append(Ms(op.Start - _startTicks))
				.Append(",\"dur\":")
				.Append(Ms(now - op.Start))
				.Append(",\"rev\":")
				.Append(op.Rev.ToString(CultureInfo.InvariantCulture))
				.Append(",\"ctx\":")
				.Append(op.Ctx.ToString(CultureInfo.InvariantCulture))
				.Append(",\"outcome\":\"")
				.Append(Escape(outcome))
				.Append('"');
			AppendPairs(stringBuilder, ShortenValues(op.Fields, fieldChars));
			AppendPairs(stringBuilder, ShortenValues(endFields, fieldChars));
			if (stages && op.Stages.Count > 0)
			{
				stringBuilder.Append(",\"stages\":[").Append(string.Join(',', op.Stages)).Append(']');
			}
			List<string> list = op.Notes.Skip(Math.Max(0, op.Notes.Count - notes)).ToList();
			if (list.Count > 0)
			{
				stringBuilder.Append(",\"notes\":[").Append(string.Join(',', list.Select((string n) => "\"" + Escape((n.Length > noteChars) ? (n.Substring(0, noteChars) + "…") : n) + "\""))).Append(']');
			}
			int num = op.NotesDropped + (op.Notes.Count - list.Count);
			if (num > 0)
			{
				stringBuilder.Append(",\"notesDropped\":").Append(num.ToString(CultureInfo.InvariantCulture));
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}

		private static List<KeyValuePair<string, string>> ShortenValues(List<KeyValuePair<string, string>> pairs, int limit)
		{
			if (limit != int.MaxValue)
			{
				return pairs.Select((KeyValuePair<string, string> p) => (p.Value.Length <= limit) ? p : new KeyValuePair<string, string>(p.Key, p.Value.Substring(0, limit) + "…")).ToList();
			}
			return pairs;
		}

		private void AddContext(long mono, string json, string name = "", bool written = false)
		{
			json = Cut(json);
			if (_limits.Detail == DiagnosticDetail.Full && !written)
			{
				Write(json);
			}
			string text = ((name.Length > 0) ? name : "note") + "@" + Ms(mono - _startTicks).ToString(CultureInfo.InvariantCulture);
			if (Coalesced.Contains(name))
			{
				for (LinkedListNode<Entry> linkedListNode = _context.Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
				{
					if (linkedListNode.Value.Name == name)
					{
						int num = linkedListNode.Value.Repeat + 1;
						string text2 = ((linkedListNode.Value.Base.Length > 0) ? linkedListNode.Value.Base : linkedListNode.Value.Json);
						LinkedListNode<Entry> linkedListNode2 = linkedListNode;
						Entry entry = linkedListNode.Value with
						{
							Repeat = num,
							Base = text2
						};
						string text3 = text2;
						entry.Json = text3.Substring(0, text3.Length - 1) + $",\"repeat\":{num},\"lastMs\":{Ms(mono - _startTicks)}}}";
						linkedListNode2.Value = entry;
						Interlocked.Increment(ref _coalesced);
						return;
					}
					if (!Coalesced.Contains(linkedListNode.Value.Name) && !linkedListNode.Value.Name.StartsWith("worker.", StringComparison.Ordinal))
					{
						break;
					}
				}
			}
			_context.AddLast(new Entry(mono, json, name, 1, "", text));
			if (_context.Count > _limits.ContextRing)
			{
				_context.RemoveFirst();
				Interlocked.Increment(ref _overwrittenContext);
			}
			FeedPending(json, text);
		}

		private string IncidentRecord(string json, string reference)
		{
			if (_limits.Detail != DiagnosticDetail.Full)
			{
				return json;
			}
			return "\"" + Escape(reference) + "\"";
		}

		private void FeedPending(string json, string reference)
		{
			for (int num = _pending.Count - 1; num >= 0; num--)
			{
				_pending[num].After.Add(IncidentRecord(json, reference));
				if (_pending[num].After.Count >= _limits.IncidentAfter)
				{
					WriteIncident(_pending[num]);
					_pending.RemoveAt(num);
				}
			}
		}

		private void BeginIncident(Item item)
		{
			Count("incident.raised");
			long mono = item.Mono;
			double num = _limits.SameIncidentWindow.TotalMilliseconds * (double)_ticksPerMillisecond;
			while (_incidentTimes.Count > 0 && mono - _incidentTimes.Peek() > 60000 * _ticksPerMillisecond)
			{
				_incidentTimes.Dequeue();
			}
			if ((_incidentLast.TryGetValue(item.Name, out var value) && (double)(mono - value) < num) || _incidentTimes.Count >= _limits.MaxIncidentsPerMinute)
			{
				Interlocked.Increment(ref _suppressedIncidents);
				Repeated("incident-suppressed:" + item.Name, item.Text ?? string.Empty);
				return;
			}
			_incidentLast[item.Name] = mono;
			_incidentTimes.Enqueue(mono);
			int id = Interlocked.Increment(ref _incidentIds);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\"t\":\"incident\",\"id\":").Append(id.ToString(CultureInfo.InvariantCulture)).Append(",\"key\":\"")
				.Append(Escape(item.Name))
				.Append("\",\"reason\":\"")
				.Append(Escape(Field(item.Text)))
				.Append("\",\"ms\":")
				.Append(Ms(mono - _startTicks))
				.Append(",\"rev\":")
				.Append(Revision.ToString(CultureInfo.InvariantCulture))
				.Append(",\"ctx\":")
				.Append(ContextGeneration.ToString(CultureInfo.InvariantCulture));
			if (item.Op != 0)
			{
				stringBuilder.Append(",\"op\":").Append(item.Op.ToString(CultureInfo.InvariantCulture));
			}
			AppendPairs(stringBuilder, Pairs(item.Pairs));
			if (item.Op != 0 && _open.TryGetValue(item.Op, out OpState value2))
			{
				stringBuilder.Append(",\"open\":\"").Append(Escape(Field(value2.Name + ": " + string.Join(" | ", value2.Fields.Select((KeyValuePair<string, string> f) => f.Key + "=" + f.Value))))).Append('"');
			}
			if (_limits.Detail == DiagnosticDetail.Full)
			{
				stringBuilder.Append(",\"records\":\"before and after name records written to this log: op:N is the op record with that op id, name@ms the context event of that type and time\"");
			}
			IEnumerable<string> values = from e in (from e in _ops.Select((Entry e) => e).Concat(_context)
					orderby e.Mono
					select e).TakeLast(_limits.IncidentBefore)
				select IncidentRecord(e.Json, e.Ref);
			stringBuilder.Append(",\"before\":[").Append(string.Join(',', values)).Append(']');
			_pending.Add(new Pending
			{
				Json = stringBuilder.ToString(),
				After = new List<string>(),
				Id = id,
				Deadline = mono + (long)(_limits.IncidentExpiry.TotalMilliseconds * (double)_ticksPerMillisecond)
			});
		}

		private void WriteIncident(Pending pending)
		{
			Write(pending.Json + ",\"after\":[" + string.Join(',', pending.After) + "]}");
		}

		private void FlushRepeats()
		{
			_lastRepeatFlush = _now();
			foreach (var (value, repeats2) in _repeats)
			{
				Write($"{{\"t\":\"agg\",\"key\":\"{Escape(value)}\",\"count\":{repeats2.Count},\"first\":{Ms(repeats2.First - _startTicks)},\"last\":{Ms(repeats2.Last - _startTicks)},\"sample\":\"{Escape(repeats2.Sample)}\"}}");
			}
			_repeats.Clear();
		}

		private void PublishSettingsLine(Item item)
		{
			Dictionary<string, string> values = (Dictionary<string, string>)item.Payload;
			bool flag = item.Ctx == 1 || _settings.Count == 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\"t\":\"settings\",\"rev\":").Append(item.Rev.ToString(CultureInfo.InvariantCulture)).Append(",\"label\":\"")
				.Append(Escape(item.Name))
				.Append("\",\"ms\":")
				.Append(Ms(item.Mono - _startTicks));
			if (flag)
			{
				stringBuilder.Append(",\"full\":true");
				AppendPairs(stringBuilder, values.OrderBy((KeyValuePair<string, string> p) => p.Key, StringComparer.Ordinal).ToList());
			}
			else
			{
				List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
				foreach (var (key, text3) in values.OrderBy((KeyValuePair<string, string> p) => p.Key, StringComparer.Ordinal))
				{
					if (!_settings.TryGetValue(key, out string value))
					{
						list.Add(new KeyValuePair<string, string>(key, "(new) " + text3));
					}
					else if (value != text3)
					{
						list.Add(new KeyValuePair<string, string>(key, value + " -> " + text3));
					}
				}
				foreach (string item2 in _settings.Keys.Where((string k) => !values.ContainsKey(k)))
				{
					list.Add(new KeyValuePair<string, string>(item2, _settings[item2] + " -> (removed)"));
				}
				if (list.Count == 0)
				{
					_settings = values;
					return;
				}
				stringBuilder.Append(",\"changes\":").Append(list.Count.ToString(CultureInfo.InvariantCulture));
				AppendPairs(stringBuilder, list);
			}
			stringBuilder.Append('}');
			_settings = values;
			string line = stringBuilder.ToString();
			if (flag)
			{
				WriteHeader(line, "settings-full");
			}
			else
			{
				WriteHeader(line, null);
			}
		}

		private void WriteHeader(string line, string? replaceTag)
		{
			lock (_headerGate)
			{
				if (replaceTag != null)
				{
					string text;
					if (replaceTag == "session")
					{
						text = "\"t\":\"session\"";
					}
					else
					{
						text = ((!(replaceTag == "target")) ? "\"full\":true" : "{\"t\":\"target\"");
					}
					string marker = text;
					_headerLines.RemoveAll((string existing) => existing.Contains(marker, StringComparison.Ordinal));
					if (replaceTag == "settings-full")
					{
						_headerLines.RemoveAll((string existing) => existing.StartsWith("{\"t\":\"settings\"", StringComparison.Ordinal));
					}
				}
				_headerLines.Add(line);
				while (_headerLines.Count > 40)
				{
					int num = _headerLines.FindIndex((string l) => l.StartsWith("{\"t\":\"settings\"", StringComparison.Ordinal) && !l.Contains("\"full\":true", StringComparison.Ordinal));
					if (num < 0)
					{
						break;
					}
					_headerLines.RemoveAt(num);
				}
			}
			Write(line);
		}

		private string BuildReport(Item item)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{\"t\":\"report\",\"v\":").Append(1).Append(",\"session\":\"")
				.Append(Escape(_sessionId))
				.Append("\",\"label\":\"")
				.Append(Escape(item.Name))
				.Append("\",\"at\":\"")
				.Append(DateTimeOffset.Now.ToString("o", CultureInfo.InvariantCulture))
				.Append("\",\"ms\":")
				.Append(Ms(item.Mono - _startTicks))
				.Append(",\"rev\":")
				.Append(item.Rev.ToString(CultureInfo.InvariantCulture))
				.Append(",\"ctx\":")
				.Append(item.Ctx.ToString(CultureInfo.InvariantCulture));
			if (item.Text != null)
			{
				stringBuilder.Append(",\"expected\":\"").Append(Escape(Field(item.Text))).Append('"');
			}
			stringBuilder.Append(",\"settings\":[").Append(string.Join(',', HeaderLines())).Append(']');
			stringBuilder.Append(",\"ops\":[").Append(string.Join(',', _ops.Select((Entry e) => e.Json))).Append(']');
			stringBuilder.Append(",\"context\":[").Append(string.Join(',', _context.Select((Entry e) => e.Json))).Append(']');
			stringBuilder.Append(",\"apps\":").Append(BuildApplications());
			stringBuilder.Append(",\"summary\":\"").Append(Escape(BuildSummary(item.Mono))).Append("\"}");
			return stringBuilder.ToString();
		}

		private string BuildSummary(long now)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider provider = invariantCulture;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(51, 4, stringBuilder2, invariantCulture);
			handler.AppendLiteral("session ");
			handler.AppendFormatted(_sessionId);
			handler.AppendLiteral(", ");
			handler.AppendFormatted(Ms(now - _startTicks));
			handler.AppendLiteral(" ms; settings rev ");
			handler.AppendFormatted(Revision);
			handler.AppendLiteral(", context generation ");
			handler.AppendFormatted(ContextGeneration);
			handler.AppendLiteral("; ");
			stringBuilder3.Append(provider, ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder4 = stringBuilder2;
			invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider provider2 = invariantCulture;
			handler = new StringBuilder.AppendInterpolatedStringHandler(68, 4, stringBuilder2, invariantCulture);
			handler.AppendLiteral("kept ");
			handler.AppendFormatted(_ops.Count);
			handler.AppendLiteral(" operations (");
			handler.AppendFormatted(_overwrittenOps);
			handler.AppendLiteral(" overwritten) and ");
			handler.AppendFormatted(_context.Count);
			handler.AppendLiteral(" context events (");
			handler.AppendFormatted(_overwrittenContext);
			handler.AppendLiteral(" overwritten); ");
			stringBuilder4.Append(provider2, ref handler);
			stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder5 = stringBuilder2;
			invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider provider3 = invariantCulture;
			handler = new StringBuilder.AppendInterpolatedStringHandler(101, 5, stringBuilder2, invariantCulture);
			handler.AppendLiteral("coalesced ");
			handler.AppendFormatted(Interlocked.Read(in _coalesced));
			handler.AppendLiteral(" repeated context events, dropped ");
			handler.AppendFormatted(Dropped);
			handler.AppendLiteral(", truncated ");
			handler.AppendFormatted(Truncated);
			handler.AppendLiteral(", suppressed incidents ");
			handler.AppendFormatted(SuppressedIncidents);
			handler.AppendLiteral(", incidents written ");
			handler.AppendFormatted(_incidentIds);
			handler.AppendLiteral(". ");
			stringBuilder5.Append(provider3, ref handler);
			stringBuilder.Append("Counters: ").Append(string.Join(", ", from c in _counters.OrderBy((KeyValuePair<string, long[]> c) => c.Key, StringComparer.Ordinal)
				select $"{c.Key}={Interlocked.Read(in c.Value[0])}"));
			if (!_durations.IsEmpty)
			{
				stringBuilder.Append(". Durations (ms): ").Append(string.Join(", ", _durations.OrderBy((KeyValuePair<string, DurationStat> d) => d.Key, StringComparer.Ordinal).Select((KeyValuePair<string, DurationStat> d) =>
				{
					(long Count, double MeanMs, double MaxMs) tuple = DurationValue(d.Key);
					long item = tuple.Count;
					double item2 = tuple.MeanMs;
					double item3 = tuple.MaxMs;
					IFormatProvider invariantCulture2 = CultureInfo.InvariantCulture;
					DefaultInterpolatedStringHandler handler2 = new DefaultInterpolatedStringHandler(14, 4, invariantCulture2);
					handler2.AppendFormatted(d.Key);
					handler2.AppendLiteral(" n=");
					handler2.AppendFormatted(item);
					handler2.AppendLiteral(" mean=");
					handler2.AppendFormatted(item2, "0.###");
					handler2.AppendLiteral(" max=");
					handler2.AppendFormatted(item3, "0.###");
					return string.Create(invariantCulture2, ref handler2);
				})));
			}
			foreach (Func<string> summarySource in _summarySources)
			{
				try
				{
					stringBuilder.Append(". ").Append(summarySource());
				}
				catch (Exception)
				{
					stringBuilder.Append(". (a timing source failed)");
				}
			}
			return stringBuilder.ToString();
		}

		private void Write(string line)
		{
			try
			{
				_sink(Cut(line, keepTail: false));
			}
			catch (Exception)
			{
				Interlocked.Increment(ref _dropped);
			}
		}

		private long Ms(long ticks)
		{
			return ticks / _ticksPerMillisecond;
		}

		private string Field(string? value)
		{
			return Limit(value, _limits.MaxFieldChars);
		}

		private string NoteField(string? value)
		{
			return Limit(value, _limits.MaxNoteChars);
		}

		private string Limit(string? value, int limit)
		{
			if (value == null)
			{
				value = string.Empty;
			}
			if (value.Length <= limit)
			{
				return value;
			}
			Interlocked.Increment(ref _truncated);
			return value.Substring(0, limit) + "…[+" + (value.Length - limit).ToString(CultureInfo.InvariantCulture) + "]";
		}

		private string Cut(string json, bool keepTail = true)
		{
			int num = (keepTail ? _limits.MaxRecordChars : (_limits.MaxRecordChars * 40));
			if (json.Length <= num)
			{
				return json;
			}
			Interlocked.Increment(ref _truncated);
			string value = ((json.Length > 80) ? json.Substring(0, 80) : json);
			return $"{{\"t\":\"cut\",\"chars\":{json.Length},\"head\":\"{Escape(value)}\"}}";
		}

		private List<KeyValuePair<string, string>> Pairs(object?[]? pairs)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>((pairs != null) ? (pairs.Length / 2) : 0);
			int num = 0;
			while (pairs != null && num + 1 < pairs.Length)
			{
				list.Add(new KeyValuePair<string, string>(pairs[num]?.ToString() ?? "?", Field(Format(pairs[num + 1]))));
				num += 2;
			}
			return list;
		}

		private static string Format(object? value)
		{
			if (value != null)
			{
				if (!(value is string result))
				{
					if (!(value is bool))
					{
						if (value is IFormattable formattable)
						{
							return formattable.ToString(null, CultureInfo.InvariantCulture);
						}
						return value.ToString() ?? string.Empty;
					}
					return ((bool)value) ? "true" : "false";
				}
				return result;
			}
			return "null";
		}

		private static void AppendPairs(StringBuilder sb, List<KeyValuePair<string, string>> pairs)
		{
			foreach (var (text3, value) in pairs)
			{
				string value2 = (StructuralNames.Contains(text3) ? ("f." + text3) : text3);
				sb.Append(",\"").Append(Escape(value2)).Append("\":\"")
					.Append(Escape(value))
					.Append('"');
			}
		}

		public static string Escape(string? value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = null;
			for (int i = 0; i < value.Length; i++)
			{
				char c = value[i];
				string text;
				switch (c)
				{
				case '"':
					text = "\\\"";
					break;
				case '\\':
					text = "\\\\";
					break;
				case '\n':
					text = "\\n";
					break;
				case '\r':
					text = "\\r";
					break;
				case '\t':
					text = "\\t";
					break;
				default:
				{
					UnicodeCategory unicodeCategory = char.GetUnicodeCategory(c);
					if (((uint)(unicodeCategory - 12) <= 3u || unicodeCategory == UnicodeCategory.PrivateUse || unicodeCategory == UnicodeCategory.OtherNotAssigned) ? true : false)
					{
						int num = c;
						text = "\\u" + num.ToString("X4", CultureInfo.InvariantCulture);
					}
					else
					{
						text = null;
					}
					break;
				}
				}
				string text2 = text;
				if (text2 == null)
				{
					stringBuilder?.Append(c);
					continue;
				}
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(value, 0, i, value.Length + 16);
				}
				stringBuilder.Append(text2);
			}
			return stringBuilder?.ToString() ?? value;
		}
	}
	public static class DiagnosticLog
	{
		public const long MaximumFileBytes = 20971520L;

		public const long CompactMaximumFileBytes = 5242880L;

		public const long FullDetailMaximumFileBytes = 8388608L;

		public const int FullDetailRetainedFiles = 8;

		private static readonly object Gate = new object();

		private static BlockingCollection<string>? _queue;

		private static Thread? _writer;

		private static long _accepted;

		private static long _finished;

		private static volatile bool _enabled;

		private static volatile bool _compact;

		private static DiagnosticDetail _detail = DiagnosticDetail.Full;

		private static DiagnosticJournal? _journal;

		private static long _maximumBytes = 20971520L;

		private static volatile int _retainedFiles = 2;

		private static readonly TimeSpan NormalJoin = TimeSpan.FromSeconds(2L);

		private static readonly TimeSpan DeletingJoin = TimeSpan.FromSeconds(10L);

		public static bool IsEnabled => _enabled;

		public static bool VerboseEnabled
		{
			get
			{
				if (_enabled)
				{
					return !_compact;
				}
				return false;
			}
		}

		public static DiagnosticJournal? Journal => _journal;

		public static DiagnosticDetail Detail => _detail;

		public static (int Files, long BytesEach) Rotation => (Files: _retainedFiles, BytesEach: Interlocked.Read(in _maximumBytes));

		public static string ReportsDirectory => Path.Combine(Path.GetDirectoryName(CurrentPath ?? DefaultPath), "reports");

		public static string? CurrentPath { get; private set; }

		public static string DefaultPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SmartInput", "Logs", "diyar-debug.log");

		internal static void OverrideMaximumBytesForTests(long bytes)
		{
			Interlocked.Exchange(ref _maximumBytes, bytes);
		}

		public static void Configure(string? path, bool compact = false, DiagnosticDetail detail = DiagnosticDetail.Full)
		{
			lock (Gate)
			{
				string target = (string.IsNullOrWhiteSpace(path) ? null : Path.GetFullPath(path));
				if (string.Equals(target, CurrentPath, StringComparison.OrdinalIgnoreCase) && (target == null || (compact == _compact && (!compact || detail == _detail))))
				{
					return;
				}
				StopWriter();
				if (target == null)
				{
					return;
				}
				Directory.CreateDirectory(Path.GetDirectoryName(target));
				BlockingCollection<string> queue = new BlockingCollection<string>(new ConcurrentQueue<string>(), 50000);
				Interlocked.Exchange(ref _accepted, 0L);
				Interlocked.Exchange(ref _finished, 0L);
				Thread thread = new Thread(() =>
				{
					WriteLoop(queue, target);
				})
				{
					IsBackground = true,
					Name = "Diyar debug log",
					Priority = ThreadPriority.BelowNormal
				};
				_queue = queue;
				_writer = thread;
				CurrentPath = target;
				_compact = compact;
				_detail = detail;
				bool flag = compact && detail == DiagnosticDetail.Full;
				long value;
				if (flag)
				{
					value = 8388608L;
				}
				else
				{
					value = (compact ? 5242880 : 20971520);
				}
				Interlocked.Exchange(ref _maximumBytes, value);
				_retainedFiles = (flag ? 8 : 2);
				if (compact)
				{
					_journal = new DiagnosticJournal((string line) =>
					{
						Enqueue(queue, line);
					}, new DiagnosticJournalLimits
					{
						Detail = detail
					});
				}
				_enabled = true;
				thread.Start();
			}
		}

		public static void Write(string area, ref DiagnosticMessageHandler message)
		{
			if (_enabled)
			{
				Write(area, message.ToStringAndClear());
			}
		}

		public static void Write(string area, string message)
		{
			if (!_enabled)
			{
				return;
			}
			if (_compact)
			{
				_journal?.Note(area, message);
				return;
			}
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(4, 3, invariantCulture);
			handler.AppendFormatted(DateTime.Now, "yyyy-MM-dd HH:mm:ss.fff");
			handler.AppendLiteral(" [");
			handler.AppendFormatted(area);
			handler.AppendLiteral("] ");
			handler.AppendFormatted(Visible(message));
			string line = string.Create(invariantCulture, ref handler);
			BlockingCollection<string> queue = _queue;
			if (queue != null)
			{
				Enqueue(queue, line);
			}
		}

		public static void Flush(TimeSpan timeout)
		{
			DateTime dateTime = DateTime.UtcNow + timeout;
			long num = Interlocked.Read(in _accepted);
			while (_queue != null && Interlocked.Read(in _finished) < num && DateTime.UtcNow < dateTime)
			{
				Thread.Sleep(5);
			}
		}

		private static void Enqueue(BlockingCollection<string> queue, string line)
		{
			Interlocked.Increment(ref _accepted);
			bool flag;
			try
			{
				flag = queue.TryAdd(line);
			}
			catch (Exception ex) when ((ex is ObjectDisposedException || ex is InvalidOperationException) ? true : false)
			{
				flag = false;
			}
			if (!flag)
			{
				Interlocked.Decrement(ref _accepted);
			}
		}

		public static void Stop(bool clearTemporary)
		{
			lock (Gate)
			{
				string currentPath = CurrentPath;
				StopWriter(clearTemporary ? DeletingJoin : NormalJoin);
				if (clearTemporary && currentPath != null)
				{
					DeleteLogFiles(currentPath);
				}
			}
		}

		public static void Clear()
		{
			lock (Gate)
			{
				string? path = CurrentPath ?? DefaultPath;
				string currentPath = CurrentPath;
				StopWriter(DeletingJoin);
				DeleteLogFiles(path);
				if (currentPath != null)
				{
					Configure(currentPath, _compact, _detail);
				}
			}
		}

		public static string Visible(string? value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value ?? string.Empty;
			}
			StringBuilder stringBuilder = null;
			for (int i = 0; i < value.Length; i++)
			{
				char c = value[i];
				string text;
				switch (c)
				{
				case '\r':
					text = "\\r";
					break;
				case '\n':
					text = "\\n";
					break;
				case '\t':
					text = "\\t";
					break;
				default:
				{
					UnicodeCategory unicodeCategory = char.GetUnicodeCategory(c);
					bool flag = (uint)(unicodeCategory - 14) <= 1u;
					text = ((!flag) ? null : $"\\u{c:X4}");
					break;
				}
				}
				string text2 = text;
				if (text2 == null)
				{
					stringBuilder?.Append(c);
					continue;
				}
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(value, 0, i, value.Length + 16);
				}
				stringBuilder.Append(text2);
			}
			return stringBuilder?.ToString() ?? value;
		}

		public static string Escaped(string? value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return value ?? string.Empty;
			}
			StringBuilder stringBuilder = null;
			for (int i = 0; i < value.Length; i++)
			{
				char c = value[i];
				bool flag = c != ' ';
				if (flag)
				{
					bool flag2 = char.IsWhiteSpace(c);
					if (!flag2)
					{
						UnicodeCategory unicodeCategory = char.GetUnicodeCategory(c);
						bool flag3 = (((uint)(unicodeCategory - 11) <= 4u || unicodeCategory == UnicodeCategory.PrivateUse || unicodeCategory == UnicodeCategory.OtherNotAssigned) ? true : false);
						flag2 = flag3;
					}
					flag = flag2;
				}
				if (!flag)
				{
					stringBuilder?.Append(c);
					continue;
				}
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(value, 0, i, value.Length + 16);
				}
				StringBuilder stringBuilder2 = stringBuilder.Append("\\u");
				int num = c;
				stringBuilder2.Append(num.ToString("X4", CultureInfo.InvariantCulture));
			}
			return stringBuilder?.ToString() ?? value;
		}

		public static void Command(DiagnosticJournal? journal, string name, params object?[] pairs)
		{
			if (journal != null)
			{
				journal.Event(name, pairs);
			}
			else
			{
				if (!_enabled)
				{
					return;
				}
				StringBuilder stringBuilder = new StringBuilder(name);
				for (int i = 0; i + 1 < pairs.Length; i += 2)
				{
					stringBuilder.Append(' ').Append(pairs[i]).Append('=');
					if (pairs[i + 1] is string value)
					{
						stringBuilder.Append('\'').Append(value).Append('\'');
					}
					else
					{
						stringBuilder.Append(Convert.ToString(pairs[i + 1], CultureInfo.InvariantCulture));
					}
				}
				Write("Command", stringBuilder.ToString());
			}
		}

		public static void Command(string name, params object?[] pairs)
		{
			Command(_journal, name, pairs);
		}

		public static string Tail(string? value, int length = 60)
		{
			if (!string.IsNullOrEmpty(value) && value.Length > length)
			{
				return "…" + value.Substring(value.Length - length);
			}
			return value ?? string.Empty;
		}

		public static string PreviousPath(string path, int age = 1)
		{
			return Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".previous" + ((age <= 1) ? string.Empty : age.ToString(CultureInfo.InvariantCulture)) + ".log");
		}

		private static void DeleteLogFiles(string path)
		{
			TryDelete(path);
			for (int i = 1; i < 8; i++)
			{
				TryDelete(PreviousPath(path, i));
			}
		}

		private static void StopWriter()
		{
			StopWriter(NormalJoin);
		}

		private static void StopWriter(TimeSpan join)
		{
			_enabled = false;
			DiagnosticJournal? journal = _journal;
			_journal = null;
			journal?.Dispose();
			BlockingCollection<string>? queue = _queue;
			Thread writer = _writer;
			_queue = null;
			_writer = null;
			CurrentPath = null;
			queue?.CompleteAdding();
			writer?.Join(join);
			queue?.Dispose();
		}

		private static void WriteLoop(BlockingCollection<string> queue, string path)
		{
			try
			{
				bool flag = false;
				int num = 0;
				foreach (string item2 in queue.GetConsumingEnumerable())
				{
					StringBuilder stringBuilder = new StringBuilder(item2).AppendLine();
					int num2 = 1;
					string item;
					while (stringBuilder.Length < 65536 && queue.TryTake(out item))
					{
						stringBuilder.AppendLine(item);
						num2++;
					}
					try
					{
						if (RollIfNeeded(path))
						{
							DiagnosticJournal journal = _journal;
							if (journal != null)
							{
								File.AppendAllLines(path, journal.HeaderLines(), Encoding.UTF8);
								flag = !flag || num > 1;
								if (flag)
								{
									journal.WriteApplicationSummary("rotation");
								}
								num = 0;
							}
						}
						File.AppendAllText(path, stringBuilder.ToString(), Encoding.UTF8);
						num++;
					}
					catch (IOException)
					{
					}
					catch (UnauthorizedAccessException)
					{
					}
					finally
					{
						if (queue == _queue)
						{
							Interlocked.Add(ref _finished, num2);
						}
					}
				}
			}
			catch (ObjectDisposedException)
			{
			}
		}

		private static bool RollIfNeeded(string path)
		{
			FileInfo fileInfo = new FileInfo(path);
			if (!fileInfo.Exists || fileInfo.Length < Interlocked.Read(in _maximumBytes))
			{
				return false;
			}
			int retainedFiles = _retainedFiles;
			TryDelete(PreviousPath(path, retainedFiles - 1));
			for (int num = retainedFiles - 2; num >= 1; num--)
			{
				string text = PreviousPath(path, num);
				if (File.Exists(text))
				{
					File.Move(text, PreviousPath(path, num + 1), overwrite: true);
				}
			}
			File.Move(path, PreviousPath(path), overwrite: true);
			return true;
		}

		private static void TryDelete(string path)
		{
			try
			{
				File.Delete(path);
			}
			catch (IOException)
			{
			}
			catch (UnauthorizedAccessException)
			{
			}
		}
	}
	[InterpolatedStringHandler]
	public ref struct DiagnosticMessageHandler
	{
		private DefaultInterpolatedStringHandler _inner;

		private readonly bool _enabled;

		public DiagnosticMessageHandler(int literalLength, int formattedCount, out bool shouldAppend)
		{
			_enabled = (shouldAppend = DiagnosticLog.IsEnabled);
			_inner = (_enabled ? new DefaultInterpolatedStringHandler(literalLength, formattedCount, CultureInfo.InvariantCulture) : default(DefaultInterpolatedStringHandler));
		}

		public void AppendLiteral(string value)
		{
			_inner.AppendLiteral(value);
		}

		public void AppendFormatted<T>(T value)
		{
			_inner.AppendFormatted(value);
		}

		public void AppendFormatted<T>(T value, string? format)
		{
			_inner.AppendFormatted(value, format);
		}

		public void AppendFormatted(string? value)
		{
			_inner.AppendFormatted(value);
		}

		internal string ToStringAndClear()
		{
			if (!_enabled)
			{
				return string.Empty;
			}
			return _inner.ToStringAndClear();
		}
	}
	public static class DiagnosticReports
	{
		public static (string Hwnd, long AtMs)? LastTypingWindow(string reportJson)
		{
			try
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(reportJson);
				(string, long)? result = null;
				string[] array = new string[2] { "ops", "context" };
				foreach (string propertyName in array)
				{
					if (!jsonDocument.RootElement.TryGetProperty(propertyName, out var value))
					{
						continue;
					}
					foreach (JsonElement item in value.EnumerateArray())
					{
						if (item.TryGetProperty("hwnd", out var value2))
						{
							string text = value2.GetString();
							if (text != null && text.Length > 0 && item.TryGetProperty("ms", out var value3) && value3.TryGetInt64(out var value4) && (!result.HasValue || value4 >= result.Value.Item2))
							{
								result = (text, value4);
							}
						}
					}
				}
				return result;
			}
			catch (JsonException)
			{
				return null;
			}
		}

		public static string DescribeAge(long reportMs, long recordMs)
		{
			return (reportMs - recordMs).ToString(CultureInfo.InvariantCulture) + " ms before the report was captured";
		}
	}
	public static class ExceptionMessagePolicy
	{
		private static readonly HashSet<string> Allowed = new HashSet<string>(StringComparer.Ordinal)
		{
			"System.ComponentModel.Win32Exception", "System.Runtime.InteropServices.COMException", "System.OutOfMemoryException", "System.InsufficientExecutionStackException", "System.NullReferenceException", "System.InvalidCastException", "System.IndexOutOfRangeException", "System.TypeLoadException", "System.MissingMethodException", "System.EntryPointNotFoundException",
			"System.DllNotFoundException", "System.StackOverflowException", "System.AccessViolationException", "System.DivideByZeroException", "System.OverflowException"
		};

		public static bool Allows(Type exceptionType)
		{
			string fullName = exceptionType.FullName;
			if (fullName != null)
			{
				return Allowed.Contains(fullName);
			}
			return false;
		}
	}
	public enum FaultSite
	{
		HookKeyHandler,
		HookForeignInput,
		MouseHook,
		EditorWork,
		Watchdog,
		ForegroundHint,
		Observer,
		Probe,
		Shortcut,
		Tray,
		Ui,
		WinForms,
		Task,
		Exit,
		Startup
	}
	public readonly record struct FaultEntry(FaultSite Site, string TypeName, int HResult, long AtMs);
	public sealed record FaultSummary(FaultSite Site, string TypeName, int HResult, int Count, long FirstMs, long LastMs);
	public static class FaultRing
	{
		private const int Capacity = 64;

		private static readonly FaultSite[] Sites = new FaultSite[64];

		private static readonly Type?[] Types = new Type[64];

		private static readonly int[] HResults = new int[64];

		private static readonly long[] Times = new long[64];

		private static readonly long[] Stamps = new long[64];

		private static readonly long Origin = Environment.TickCount64;

		private static long _next;

		public static int Count => (int)Math.Min(2147483647L, Interlocked.Read(in _next));

		public static long Version => Interlocked.Read(in _next);

		public static void Note(FaultSite site, Exception? exception)
		{
			long num = Interlocked.Increment(ref _next);
			int num2 = (int)((num - 1) % 64);
			Volatile.Write(ref Stamps[num2], 0L);
			Sites[num2] = site;
			Types[num2] = exception?.GetType();
			HResults[num2] = exception?.HResult ?? 0;
			Times[num2] = Environment.TickCount64 - Origin;
			Volatile.Write(ref Stamps[num2], num);
		}

		public static IReadOnlyList<FaultEntry> Snapshot()
		{
			long num = Interlocked.Read(in _next);
			long num2 = Math.Max(1L, num - 64 + 1);
			List<FaultEntry> list = new List<FaultEntry>((int)(num - num2 + 1));
			for (long num3 = num2; num3 <= num; num3++)
			{
				int num4 = (int)((num3 - 1) % 64);
				if (Volatile.Read(in Stamps[num4]) == num3)
				{
					FaultEntry item = new FaultEntry(Sites[num4], Types[num4]?.FullName ?? "(none)", HResults[num4], Times[num4]);
					if (Volatile.Read(in Stamps[num4]) == num3)
					{
						list.Add(item);
					}
				}
			}
			return list;
		}

		public static IReadOnlyList<FaultSummary> Summarize()
		{
			return (from entry in Snapshot()
				group entry by (Site: entry.Site, TypeName: entry.TypeName) into @group
				select new FaultSummary(@group.Key.Site, @group.Key.TypeName, @group.Last().HResult, @group.Count(), @group.First().AtMs, @group.Last().AtMs)).ToList();
		}

		internal static void ResetForTests()
		{
			Interlocked.Exchange(ref _next, 0L);
			Array.Clear(Stamps);
		}
	}
	public sealed record SessionMarker(int Pid, DateTimeOffset Start, string Version, string Commit, bool StartedHidden, string TypingMode, DateTimeOffset LastSeen, bool Clean, bool Noticed, string? Outcome, IReadOnlyList<FaultSummary> Faults)
	{
		public int FaultCount => Faults.Sum((FaultSummary fault) => fault.Count);
	}
	public enum SessionOutcome
	{
		CleanExit,
		CrashedWithRecord,
		EndedWithoutRecord,
		Unknown
	}
	public static class SessionMarkerStore
	{
		private const string Prefix = "session-";

		public static string PathFor(string directory, int pid)
		{
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(5, 2, invariantCulture);
			handler.AppendFormatted("session-");
			handler.AppendFormatted(pid);
			handler.AppendLiteral(".json");
			return Path.Combine(directory, string.Create(invariantCulture, ref handler));
		}

		public static SessionMarker Begin(string directory, CrashContext context, string typingMode)
		{
			DateTimeOffset now = DateTimeOffset.Now;
			SessionMarker sessionMarker = new SessionMarker(Environment.ProcessId, context.ProcessStart, context.Version, context.Commit, context.StartedHidden, typingMode, now, Clean: false, Noticed: false, null, Array.Empty<FaultSummary>());
			Save(directory, sessionMarker);
			return sessionMarker;
		}

		public static bool Save(string directory, SessionMarker marker)
		{
			try
			{
				Directory.CreateDirectory(directory);
				string text = PathFor(directory, marker.Pid);
				string text2 = text + ".tmp";
				File.WriteAllBytes(text2, ToJson(marker));
				File.Move(text2, text, overwrite: true);
				return true;
			}
			catch (Exception ex) when ((ex is IOException || ex is UnauthorizedAccessException) ? true : false)
			{
				return false;
			}
		}

		public static IReadOnlyList<SessionMarker> LoadOthers(string directory, int currentPid)
		{
			List<SessionMarker> list = new List<SessionMarker>();
			if (!Directory.Exists(directory))
			{
				return list;
			}
			foreach (string item in Directory.EnumerateFiles(directory, "session-*.json"))
			{
				try
				{
					SessionMarker sessionMarker = Parse(File.ReadAllText(item));
					if ((object)sessionMarker != null && sessionMarker.Pid != currentPid)
					{
						list.Add(sessionMarker);
					}
				}
				catch (Exception ex) when ((ex is IOException || ex is UnauthorizedAccessException) ? true : false)
				{
				}
			}
			return list.OrderBy((SessionMarker marker) => marker.Start).ToList();
		}

		public static void Prune(string directory, int keep = 20)
		{
			if (!Directory.Exists(directory))
			{
				return;
			}
			string[] array = new string[3] { "session-*.json", "crash-*.json", "fault-*.json" };
			foreach (string searchPattern in array)
			{
				foreach (FileInfo item in (from file in new DirectoryInfo(directory).EnumerateFiles(searchPattern)
					orderby file.LastWriteTimeUtc descending
					select file).Skip(keep))
				{
					try
					{
						item.Delete();
					}
					catch (Exception ex) when ((ex is IOException || ex is UnauthorizedAccessException) ? true : false)
					{
					}
				}
			}
		}

		public static IReadOnlyList<string> CrashRecordsOf(string directory, SessionMarker marker)
		{
			if (!Directory.Exists(directory))
			{
				return Array.Empty<string>();
			}
			List<string> list = new List<string>();
			foreach (string item in Directory.EnumerateFiles(directory, "crash-*.json"))
			{
				string fileName = Path.GetFileName(item);
				if (RecordBelongsTo(fileName, marker))
				{
					list.Add(fileName);
				}
			}
			return list;
		}

		public static bool RecordBelongsTo(string fileName, SessionMarker marker)
		{
			string[] array = Path.GetFileNameWithoutExtension(fileName).Split('-');
			if (array.Length < 6 || array[0] != "crash" || array[4] != marker.Pid.ToString(CultureInfo.InvariantCulture))
			{
				return false;
			}
			if (DateTime.TryParseExact($"{array[1]}-{array[2]}-{array[3]}", "yyyyMMdd-HHmmss-fff", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var result))
			{
				return result >= marker.Start.LocalDateTime.AddSeconds(-1.0);
			}
			return false;
		}

		public static byte[] ToJson(SessionMarker marker)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (Utf8JsonWriter utf8JsonWriter = new Utf8JsonWriter(memoryStream, new JsonWriterOptions
			{
				Indented = true
			}))
			{
				utf8JsonWriter.WriteStartObject();
				utf8JsonWriter.WriteNumber("pid", marker.Pid);
				utf8JsonWriter.WriteString("start", marker.Start.ToString("O", CultureInfo.InvariantCulture));
				utf8JsonWriter.WriteString("version", marker.Version);
				utf8JsonWriter.WriteString("commit", marker.Commit);
				utf8JsonWriter.WriteBoolean("startedHidden", marker.StartedHidden);
				utf8JsonWriter.WriteString("typingMode", marker.TypingMode);
				utf8JsonWriter.WriteString("lastSeen", marker.LastSeen.ToString("O", CultureInfo.InvariantCulture));
				utf8JsonWriter.WriteBoolean("clean", marker.Clean);
				utf8JsonWriter.WriteBoolean("noticed", marker.Noticed);
				if (marker.Outcome != null)
				{
					utf8JsonWriter.WriteString("outcome", marker.Outcome);
				}
				CrashRecordWriter.WriteFaults(utf8JsonWriter, marker.Faults);
				utf8JsonWriter.WriteEndObject();
			}
			return memoryStream.ToArray();
		}

		public static SessionMarker? Parse(string json)
		{
			try
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(json);
				JsonElement rootElement = jsonDocument.RootElement;
				List<FaultSummary> list = new List<FaultSummary>();
				if (rootElement.TryGetProperty("faults", out var value) && value.ValueKind == JsonValueKind.Array)
				{
					foreach (JsonElement item in value.EnumerateArray())
					{
						if (!Enum.TryParse<FaultSite>(item.GetProperty("site").GetString(), out var result))
						{
							continue;
						}
						int num;
						if (item.TryGetProperty("hresult", out var value2))
						{
							string text = value2.GetString();
							if (text != null && text.Length > 2 && int.TryParse(text.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
							{
								num = result2;
								goto IL_00c6;
							}
						}
						num = 0;
						goto IL_00c6;
						IL_00c6:
						int hResult = num;
						list.Add(new FaultSummary(result, item.GetProperty("type").GetString() ?? "", hResult, item.GetProperty("count").GetInt32(), item.GetProperty("firstMs").GetInt64(), item.GetProperty("lastMs").GetInt64()));
					}
				}
				JsonElement value3;
				JsonElement value4;
				JsonElement value5;
				JsonElement value6;
				return new SessionMarker(rootElement.GetProperty("pid").GetInt32(), DateTimeOffset.Parse(rootElement.GetProperty("start").GetString(), CultureInfo.InvariantCulture), rootElement.GetProperty("version").GetString() ?? "", rootElement.GetProperty("commit").GetString() ?? "", rootElement.TryGetProperty("startedHidden", out value3) && value3.GetBoolean(), rootElement.TryGetProperty("typingMode", out value4) ? (value4.GetString() ?? "") : "", DateTimeOffset.Parse(rootElement.GetProperty("lastSeen").GetString(), CultureInfo.InvariantCulture), rootElement.GetProperty("clean").GetBoolean(), rootElement.TryGetProperty("noticed", out value5) && value5.GetBoolean(), rootElement.TryGetProperty("outcome", out value6) ? value6.GetString() : null, list);
			}
			catch (Exception ex) when ((ex is JsonException || ex is KeyNotFoundException || ex is InvalidOperationException || ex is FormatException) ? true : false)
			{
				return null;
			}
		}
	}
	public static class SessionOutcomeClassifier
	{
		public sealed record Judgement(IReadOnlyList<SessionMarker> NewlyJudged, (SessionOutcome Outcome, SessionMarker Marker)? Newest, (SessionOutcome Outcome, SessionMarker Marker)? ToNotice);

		public static SessionOutcome Classify(SessionMarker marker, IReadOnlyList<string> crashRecordsOfPid, Func<SessionMarker, bool> stillRunning)
		{
			if (stillRunning(marker))
			{
				return SessionOutcome.Unknown;
			}
			if (marker.Clean)
			{
				return SessionOutcome.CleanExit;
			}
			if (crashRecordsOfPid.Count <= 0)
			{
				return SessionOutcome.EndedWithoutRecord;
			}
			return SessionOutcome.CrashedWithRecord;
		}

		public static Judgement JudgeAll(IReadOnlyList<SessionMarker> markers, Func<SessionMarker, IReadOnlyList<string>> crashRecordsOf, Func<SessionMarker, bool> stillRunning)
		{
			List<SessionMarker> list = new List<SessionMarker>();
			(SessionOutcome, SessionMarker)? tuple = null;
			foreach (SessionMarker item2 in markers.OrderBy((SessionMarker marker) => marker.Start))
			{
				SessionMarker sessionMarker = item2;
				if (item2.Outcome == null)
				{
					SessionOutcome sessionOutcome = Classify(item2, crashRecordsOf(item2), stillRunning);
					if (sessionOutcome == SessionOutcome.Unknown)
					{
						continue;
					}
					sessionMarker = item2 with
					{
						Outcome = sessionOutcome.ToString()
					};
					list.Add(sessionMarker);
				}
				if (Enum.TryParse<SessionOutcome>(sessionMarker.Outcome, out var result) && result != SessionOutcome.Unknown)
				{
					tuple = (result, sessionMarker);
				}
			}
			(SessionOutcome, SessionMarker) valueOrDefault = default;
			int num;
			if (tuple.HasValue)
			{
				valueOrDefault = tuple.GetValueOrDefault();
				num = 1;
			}
			else
			{
				num = 0;
			}
			bool flag = (byte)num != 0;
			if (flag)
			{
				SessionOutcome item = valueOrDefault.Item1;
				bool flag2 = (uint)(item - 1) <= 1u;
				flag = flag2;
			}
			(SessionOutcome, SessionMarker)? toNotice = ((flag && !valueOrDefault.Item2.Noticed) ? tuple : (((SessionOutcome, SessionMarker)?)null));
			return new Judgement(list, tuple, toNotice);
		}
	}
	public static class SettingsSnapshot
	{
		private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
		{
			Converters = { (JsonConverter)new JsonStringEnumConverter() },
			IncludeFields = false
		};

		public static Dictionary<string, string> Flatten(object settings, string prefix = "")
		{
			prefix = prefix.TrimEnd('.');
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.Ordinal);
			using JsonDocument jsonDocument = JsonDocument.Parse(JsonSerializer.SerializeToUtf8Bytes(settings, settings.GetType(), Options));
			Walk(jsonDocument.RootElement, prefix, dictionary);
			return dictionary;
		}

		private static void Walk(JsonElement element, string path, Dictionary<string, string> into)
		{
			switch (element.ValueKind)
			{
			case JsonValueKind.Object:
			{
				foreach (JsonProperty item in element.EnumerateObject())
				{
					Walk(item.Value, (path.Length == 0) ? item.Name : (path + "." + item.Name), into);
				}
				break;
			}
			case JsonValueKind.Array:
			{
				int num = 0;
				foreach (JsonElement item2 in element.EnumerateArray())
				{
					Walk(item2, path + "[" + num++.ToString(CultureInfo.InvariantCulture) + "]", into);
				}
				if (num == 0)
				{
					into[path] = "[]";
				}
				break;
			}
			case JsonValueKind.String:
				into[path] = element.GetString() ?? string.Empty;
				break;
			case JsonValueKind.Null:
				into[path] = "null";
				break;
			default:
				into[path] = element.GetRawText();
				break;
			}
		}
	}
}
namespace SmartInput.Core.Detection
{
	public readonly record struct BilingualContext(bool PreviousWordIsPersian, bool WordBeforePreviousIsPersian, bool PreviousWordIsPersianFunctionWord, int EnglishWordsInParagraph, bool TargetIsCommonPersian, bool SourceIsHighFrequencyEnglish);
	public static class BilingualWordPolicy
	{
		public static bool ConvertsByContext(BilingualContext context)
		{
			if (context.TargetIsCommonPersian && !context.SourceIsHighFrequencyEnglish && context.PreviousWordIsPersian)
			{
				if (!context.WordBeforePreviousIsPersian && !context.PreviousWordIsPersianFunctionWord)
				{
					return context.EnglishWordsInParagraph == 0;
				}
				return true;
			}
			return false;
		}

		public static BilingualContext Describe(LexiconStore lexiconStore, DetectionRequest request, string source, string target, int commonPersianWordRank)
		{
			return new BilingualContext(request.PreviousWordIsPersian, request.WordBeforePreviousIsPersian, request.PreviousWordText != null && lexiconStore.IsPersianFunctionWord(request.PreviousWordText), request.EnglishProseWordsInParagraph ?? request.EnglishWordsInParagraph, lexiconStore.IsCommonPersian(target, commonPersianWordRank), lexiconStore.IsHighFrequency(source, DetectedLanguage.English));
		}
	}
	public enum LearnedPreference
	{
		None,
		TemporaryEnglish,
		PermanentEnglish
	}
	public static class ConversionLearningPolicy
	{
		public static LearnedPreference ForRejections(int rejections, DecisionPolicy? policy = null)
		{
			if (rejections > 0)
			{
				if (rejections < (policy ?? DecisionPolicy.Default).RejectionsForPermanentEnglish)
				{
					return LearnedPreference.TemporaryEnglish;
				}
				return LearnedPreference.PermanentEnglish;
			}
			return LearnedPreference.None;
		}

		public static LearnedPreference ForRestore(int rejections, bool keysAreEnglishWord, bool persianIsKnown, DecisionPolicy? policy = null)
		{
			if (rejections > 0)
			{
				if (rejections < (policy ?? DecisionPolicy.Default).RejectionsForPermanentEnglish || (!keysAreEnglishWord && persianIsKnown))
				{
					return LearnedPreference.TemporaryEnglish;
				}
				return LearnedPreference.PermanentEnglish;
			}
			return LearnedPreference.None;
		}

		public static bool ForgetsEnglish(int persianConversions, bool entryIsAutomatic, DecisionPolicy? policy = null)
		{
			if (entryIsAutomatic)
			{
				return persianConversions >= (policy ?? DecisionPolicy.Default).ConversionsToForgetEnglish;
			}
			return false;
		}

		public static string Key(string typed, string sourceLayoutId, string targetLayoutId)
		{
			return $"{sourceLayoutId}|{targetLayoutId}|{typed.Trim().ToLowerInvariant()}";
		}
	}
	public sealed record DecisionPolicy
	{
		public static DecisionPolicy Default { get; } = new DecisionPolicy();

		public int ProtectedSourceScore { get; init; } = 120;

		public int UserDictionaryScore { get; init; } = 120;

		public int HighFrequencyWordScore { get; init; } = 70;

		public int NormalFrequencyWordScore { get; init; } = 50;

		public int BuiltinWordScore { get; init; } = 20;

		public int TechnicalTargetScore { get; init; } = 100;

		public int ColloquialObjectFormScore { get; init; } = 70;

		public int DerivedPersianFormScore { get; init; } = 70;

		public int DerivedPersianFormMaximumChain { get; init; } = 2;

		public int DerivedPersianFormMinimumBase { get; init; } = 3;

		public int DerivedPersianFormMinimumBaseForOneLetterSuffix { get; init; } = 4;

		public int StrongPatternTargetScore { get; init; } = 125;

		public int MaximumContextScore { get; init; } = 60;

		public int ActiveLanguageScore { get; init; } = 25;

		public int CrossLanguageScore { get; init; } = 25;

		public int WrongLayoutShapeScore { get; init; } = 55;

		public double WrongLayoutMaximumVowelRatio { get; init; } = 0.25;

		public int PersianOnlyKeyScore { get; init; } = 80;

		public int EnglishTypoScore { get; init; } = 60;

		public int EnglishTypoMinimumLength { get; init; } = 4;

		public int EnglishContractionScore { get; init; } = 80;

		public int MixedScriptPenalty { get; init; } = 50;

		public int ControlCharacterPenalty { get; init; } = 100;

		public int ShortWordLength { get; init; } = 2;

		public int ShortWordMarginThreshold { get; init; } = 50;

		public int UnknownWordMarginThreshold { get; init; } = 80;

		public int CommonPersianWordRank { get; init; } = 5000;

		public int RejectionsForPermanentEnglish { get; init; } = 2;

		public int ConversionsToForgetEnglish { get; init; } = 2;
	}
	public sealed record DetectionRequest(string Source, string Target, bool IsAutomaticTrigger, DetectedLanguage ActiveLanguage, CorrectionSettings Settings, string? ProtectionSource = null, int PersianContextScore = 0, bool AllowSingleCharacterTarget = false, bool AllowUnknownPersianTarget = false, bool PreviousWordIsPersian = false, int PersianWordsInParagraph = 0, int EnglishWordsInParagraph = 0, bool WordBeforePreviousIsPersian = false, string? PreviousWordText = null, bool AllowPersianDigits = false, int? EnglishProseWordsInParagraph = null);
	public sealed record DetectionResult(int SourceScore, int TargetScore, bool BlockingRuleMatched, bool ShouldAutoCorrect, bool ShouldAllowManualCorrection, string? BlockingReason, string? Route = null)
	{
		public ProtectedTokenKind ProtectedKind { get; init; }

		public int KeyboardEvidence { get; init; }

		public int EnglishTypoEvidence { get; init; }

		public string? EnglishTypoShape { get; init; }

		public int RequiredMargin { get; init; }

		public bool ShortWordAllowed { get; init; } = true;

		public PersianFormKind DerivedForm { get; init; }

		public bool KeptAsBilingualByContext { get; init; }
	}
	public static class EnglishTypoShapes
	{
		public const string Letters = "letters";

		public const string SlipSubstitution = "slip-substitution";

		public const string SlipInsertion = "slip-insertion";

		public const string Contraction = "contraction";
	}
	public static class EnglishCapitalPolicy
	{
		private const int FirstLetterKey = 65;

		private const int LastLetterKey = 90;

		public static bool WantsCapital(bool previousWordPersian, int virtualKey, bool shiftDown, bool controlDown, bool altDown, bool windowsDown, bool capsLockOn, bool capsLockIsHoldKey)
		{
			if (previousWordPersian && virtualKey >= 65 && virtualKey <= 90 && !shiftDown && !controlDown && !altDown && !windowsDown)
			{
				return !capsLockOn | capsLockIsHoldKey;
			}
			return false;
		}

		public static bool TryGetCapital(int virtualKey, out char capital)
		{
			if (virtualKey >= 65 && virtualKey <= 90)
			{
				capital = (char)(65 + (virtualKey - 65));
				return true;
			}
			capital = '\0';
			return false;
		}
	}
	public static class HeldKeyPolicy
	{
		public const int RepeatsThatAreNoLongerAWord = 4;

		public const string BlockingReason = "The token repeats one letter more than any word does: a held key, not a word.";

		public static bool LooksLikeAHeldKey(string token)
		{
			if (token.Length < 4)
			{
				return false;
			}
			int num = 1;
			for (int i = 1; i < token.Length; i++)
			{
				if (token[i] != token[i - 1] || !char.IsLetter(token[i]))
				{
					num = 1;
				}
				else if (++num >= 4)
				{
					return true;
				}
			}
			return false;
		}
	}
	public interface IDetectionEngine
	{
		TypingEngine Engine { get; }

		DetectionResult Evaluate(DetectionRequest request);

		bool IsEnglishWord(string word);
	}
	public static class PersianDigitPolicy
	{
		public const int MaxDigits = 6;

		public static bool IsEligibleShape(string token)
		{
			if (!string.IsNullOrEmpty(token))
			{
				return Shape().IsMatch(token);
			}
			return false;
		}

		public static bool Allows(AmbiguousInputPriority priority, bool previousWordIsPersian, bool previousWordIsEnglish)
		{
			return priority switch
			{
				AmbiguousInputPriority.Persian => !previousWordIsEnglish, 
				AmbiguousInputPriority.English => false, 
				_ => previousWordIsPersian, 
			};
		}

		public static bool IsDigitForm(string source, string target)
		{
			if (!IsEligibleShape(source) || target.Length != source.Length)
			{
				return false;
			}
			for (int i = 0; i < source.Length; i++)
			{
				char c = source[i];
				char c2 = target[i];
				if (char.IsAsciiDigit(c))
				{
					if (char.IsAsciiDigit(c2) || char.GetUnicodeCategory(c2) != UnicodeCategory.DecimalDigitNumber || (int)char.GetNumericValue(c2) != c - 48)
					{
						return false;
					}
					continue;
				}
				bool num;
				if (i != source.Length - 1)
				{
					if (c2 == c)
					{
						goto IL_007c;
					}
					num = !char.IsPunctuation(c2);
				}
				else
				{
					num = c2 != c;
				}
				if (!num)
				{
					continue;
				}
				goto IL_007c;
				IL_007c:
				return false;
			}
			return true;
		}

		[GeneratedRegex("^[1-9][0-9]{0,5}(?:\\.[0-9]{1,6}|,[0-9]{3})?[.,]?$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex Shape()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Shape_0.Instance;
		}
	}
	public static class PersianEncliticTokenPolicy
	{
		public static bool StandsWithoutPersianContext(bool targetIsListedEnclitic, bool sourceIsEnglishWord, bool sourceIsInEnglishDictionary)
		{
			if (targetIsListedEnclitic && !sourceIsEnglishWord)
			{
				return !sourceIsInEnglishDictionary;
			}
			return false;
		}
	}
	public enum PersianFormKind
	{
		None,
		CuratedShortWord,
		ZwnjVariant,
		BasePlusSuffix,
		PrepositionPronoun,
		BasePlusSuffixChain
	}
	public static class PersianFormPolicy
	{
		private const char Zwnj = '\u200c';

		private const string VerbPrefix = "می";

		private const string NegatedVerbPrefix = "نمی";

		private const string Plural = "ها";

		public static PersianFormKind Classify(LexiconStore lexicon, string target)
		{
			if (target.Length >= 2 && target.All((char ch) => ch == '\u200c' || IsPersianLetter(ch)) && target[0] != '\u200c')
			{
				if (target[target.Length - 1] != '\u200c')
				{
					if (lexicon.IsPersianPriorityShortWord(target))
					{
						return PersianFormKind.CuratedShortWord;
					}
					if (lexicon.IsBuiltinWord(target, DetectedLanguage.Persian) || target.Count((char ch) => ch == '\u200c') > 1)
					{
						return PersianFormKind.None;
					}
					if (!IsZwnjVariant(lexicon, target))
					{
						return ClassifySuffix(lexicon, target);
					}
					return PersianFormKind.ZwnjVariant;
				}
			}
			return PersianFormKind.None;
		}

		public static PersianFormKind ClassifyWordForm(LexiconStore lexicon, string target, DecisionPolicy policy)
		{
			if (target.Length >= 2 && target.All((char ch) => ch == '\u200c' || IsPersianLetter(ch)) && target[0] != '\u200c')
			{
				if (target[target.Length - 1] != '\u200c' && target.Count((char ch) => ch == '\u200c') <= 1 && !lexicon.IsBuiltinWord(target, DetectedLanguage.Persian) && !IsPersonalPersianWord(lexicon, target))
				{
					if (!IsZwnjVariant(lexicon, target))
					{
						return ClassifySuffixChain(lexicon, target, policy);
					}
					return PersianFormKind.ZwnjVariant;
				}
			}
			return PersianFormKind.None;
		}

		private static PersianFormKind ClassifySuffixChain(LexiconStore lexicon, string target, DecisionPolicy policy)
		{
			IReadOnlyList<PersianSuffixRule> persianSuffixes = lexicon.PersianSuffixes;
			if (persianSuffixes.Count == 0 || policy.DerivedPersianFormMaximumChain < 1)
			{
				return PersianFormKind.None;
			}
			int num = target.IndexOf('\u200c');
			string text = ((num >= 0) ? target.Remove(num, 1) : target);
			foreach (PersianSuffixRule item in persianSuffixes)
			{
				if (!text.EndsWith(item.Form, StringComparison.Ordinal) || text.Length <= item.Form.Length)
				{
					continue;
				}
				int num2 = text.Length - item.Form.Length;
				if (!ZwnjAllowed(item, num, num2))
				{
					continue;
				}
				string text2 = text.Substring(0, num2);
				if ((num < 0 || num == num2) && StemAccepts(lexicon, text2, item, policy))
				{
					return PersianFormKind.BasePlusSuffix;
				}
				if (policy.DerivedPersianFormMaximumChain < 2)
				{
					continue;
				}
				foreach (PersianSuffixRule item2 in persianSuffixes)
				{
					if (item.MayFollow.Contains(item2.Form, StringComparer.Ordinal) && text2.EndsWith(item2.Form, StringComparison.Ordinal) && text2.Length > item2.Form.Length)
					{
						int num3 = text2.Length - item2.Form.Length;
						if ((num < 0 || num == num3 || num == num2) && ZwnjAllowed(item2, num, num3) && StemAccepts(lexicon, text2.Substring(0, num3), item2, policy))
						{
							return PersianFormKind.BasePlusSuffixChain;
						}
					}
				}
			}
			return PersianFormKind.None;
		}

		private static bool ZwnjAllowed(PersianSuffixRule suffix, int zwnjBefore, int suffixStart)
		{
			return suffix.Zwnj switch
			{
				PersianSuffixZwnj.Required => zwnjBefore == suffixStart, 
				PersianSuffixZwnj.Never => zwnjBefore != suffixStart, 
				_ => true, 
			};
		}

		private static bool StemAccepts(LexiconStore lexicon, string stem, PersianSuffixRule suffix, DecisionPolicy policy)
		{
			int num = Math.Max(suffix.MinimumBase, (suffix.Form.Length == 1) ? policy.DerivedPersianFormMinimumBaseForOneLetterSuffix : policy.DerivedPersianFormMinimumBase);
			if (stem.Length < num)
			{
				return false;
			}
			char c = stem[stem.Length - 1];
			bool flag;
			switch (suffix.AttachesAfter)
			{
			case PersianSuffixAttachment.Consonant:
				flag = !IsVowelLike(c);
				break;
			case PersianSuffixAttachment.ConsonantOrAlef:
				flag = !IsVowelLike(c) || c == 'ا';
				break;
			case PersianSuffixAttachment.He:
				flag = c == 'ه';
				break;
			case PersianSuffixAttachment.Vowel:
			{
				bool flag2 = ((c == 'آ' || c == 'ا' || c == 'و') ? true : false);
				flag = flag2;
				break;
			}
			default:
				flag = true;
				break;
			}
			if (flag)
			{
				if (!lexicon.IsBuiltinWord(stem, DetectedLanguage.Persian))
				{
					return IsPersonalPersianWord(lexicon, stem);
				}
				return true;
			}
			return false;
		}

		private static bool IsPersonalPersianWord(LexiconStore lexicon, string word)
		{
			if (lexicon.IsUserExactMatch(word, DetectedLanguage.Persian))
			{
				return !lexicon.IsUserPrevented(word, DetectedLanguage.Persian);
			}
			return false;
		}

		private static bool IsZwnjVariant(LexiconStore lexicon, string target)
		{
			int num = target.IndexOf('\u200c');
			if (num >= 0)
			{
				if (IsDefinedZwnjPosition(target, num))
				{
					return lexicon.IsBuiltinWord(target.Remove(num, 1), DetectedLanguage.Persian);
				}
				return false;
			}
			string[] array = new string[2] { "نمی", "می" };
			foreach (string text in array)
			{
				if (target.StartsWith(text, StringComparison.Ordinal) && target.Length >= text.Length + 2 && lexicon.IsBuiltinWord(text + "\u200c" + target.Substring(text.Length), DetectedLanguage.Persian))
				{
					return true;
				}
			}
			if (target.EndsWith("ها", StringComparison.Ordinal) && target.Length >= "ها".Length + 2)
			{
				int i = "ها".Length;
				return lexicon.IsBuiltinWord(target.Substring(0, target.Length - i) + "\u200cها", DetectedLanguage.Persian);
			}
			return false;
		}

		private static bool IsDefinedZwnjPosition(string withZwnj, int at)
		{
			if ((at != "می".Length || !withZwnj.StartsWith("می", StringComparison.Ordinal) || withZwnj.Length <= at + 2) && (at != "نمی".Length || !withZwnj.StartsWith("نمی", StringComparison.Ordinal) || withZwnj.Length <= at + 2))
			{
				if (withZwnj.Length - at - 1 == "ها".Length && withZwnj.EndsWith("ها", StringComparison.Ordinal))
				{
					return at >= 2;
				}
				return false;
			}
			return true;
		}

		private static PersianFormKind ClassifySuffix(LexiconStore lexicon, string target)
		{
			int num = target.IndexOf('\u200c');
			string text = target;
			bool flag;
			if (num >= 0)
			{
				switch (target.Substring(num + 1))
				{
				case "ها":
				case "ام":
				case "ات":
				case "اش":
					flag = true;
					break;
				default:
					flag = false;
					break;
				}
				if (!flag)
				{
					return PersianFormKind.None;
				}
				text = target.Remove(num, 1);
			}
			flag = num < 0 && text.Length == 3;
			if (flag)
			{
				string text2 = text;
				char c = text2[text2.Length - 1];
				bool flag2 = ((c == 'ت' || c == 'ش' || c == 'م') ? true : false);
				flag = flag2;
			}
			if (flag)
			{
				string text3 = text;
				if (lexicon.IsPersianPrepositionBase(text3.Substring(0, text3.Length - 1)))
				{
					return PersianFormKind.PrepositionPronoun;
				}
			}
			string[] array = new string[8] { "ها", "ام", "ات", "اش", "ی", "م", "ت", "ش" };
			foreach (string text4 in array)
			{
				if (text.EndsWith(text4, StringComparison.Ordinal) && text.Length > text4.Length && (num < 0 || num == text.Length - text4.Length))
				{
					string text3 = text;
					int length = text4.Length;
					string text5 = text3.Substring(0, text3.Length - length);
					if (AttachmentAllowed(text5, text4, num >= 0) && lexicon.IsBuiltinWord(text5, DetectedLanguage.Persian))
					{
						return PersianFormKind.BasePlusSuffix;
					}
				}
			}
			return PersianFormKind.None;
		}

		private static bool AttachmentAllowed(string baseWord, string suffix, bool joinedWithZwnj)
		{
			char c = baseWord[baseWord.Length - 1];
			bool flag = !IsVowelLike(c);
			switch (suffix)
			{
			case "ها":
				return baseWord.Length >= 3;
			case "ی":
				return (!joinedWithZwnj && baseWord.Length >= 4) & flag;
			case "م":
			case "ت":
			case "ش":
				return !joinedWithZwnj && baseWord.Length >= 4 && (flag || c == 'ا');
			default:
				return baseWord.Length >= 4 && c == 'ه';
			}
		}

		private static bool IsVowelLike(char letter)
		{
			switch (letter)
			{
			case 'ء':
			case 'آ':
			case 'ؤ':
			case 'ئ':
			case 'ا':
			case 'ه':
			case 'و':
			case 'ی':
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
	public sealed class PersianTypoCorrector
	{
		private const string PersianAlphabet = "آاأإءؤئبپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی";

		private readonly LexiconStore _lexicon;

		public PersianTypoCorrector(LexiconStore lexicon)
		{
			_lexicon = lexicon;
		}

		public bool TryCorrect(string source, out string corrected)
		{
			corrected = source;
			string text = LexiconStore.NormalizeUserTerm(source);
			int length = text.Length;
			bool flag = ((length < 4 || length > 24) ? true : false);
			if (flag || !text.All(IsPersianLetter) || IsKnown(text))
			{
				return false;
			}
			string text2 = null;
			foreach (string item in EnumerateCandidates(text))
			{
				if (!(item == text) && !(item == text2) && IsKnown(item))
				{
					if (text2 != null)
					{
						return false;
					}
					text2 = item;
				}
			}
			if (text2 == null || _lexicon.IsUserPrevented(text2, DetectedLanguage.Persian) || (!_lexicon.IsHighFrequency(text2, DetectedLanguage.Persian) && !_lexicon.IsUserExactMatch(text2, DetectedLanguage.Persian)))
			{
				return false;
			}
			corrected = text2;
			return true;
		}

		public static bool IsPersianLetter(char value)
		{
			if (value >= '\u0600' && value <= 'ۿ')
			{
				return char.IsLetter(value);
			}
			return false;
		}

		private bool IsKnown(string word)
		{
			if (!_lexicon.IsBuiltinWord(word, DetectedLanguage.Persian) && !_lexicon.IsHighFrequency(word, DetectedLanguage.Persian))
			{
				return _lexicon.IsUserExactMatch(word, DetectedLanguage.Persian);
			}
			return true;
		}

		private static IEnumerable<string> EnumerateCandidates(string word)
		{
			for (int index = 0; index < word.Length; index++)
			{
				yield return word.Remove(index, 1);
				if (index + 1 < word.Length && word[index] != word[index + 1])
				{
					char[] array = word.ToCharArray();
					ref char reference = ref array[index];
					ref char reference2 = ref array[index + 1];
					char c = array[index + 1];
					char c2 = array[index];
					reference = c;
					reference2 = c2;
					yield return new string(array);
				}
			}
			for (int index = 0; index <= word.Length; index++)
			{
				string text = "آاأإءؤئبپتثجچحخدذرزژسشصضطظعغفقکگلمنوهی";
				for (int i = 0; i < text.Length; i++)
				{
					char letter = text[i];
					yield return word.Insert(index, letter.ToString());
					if (index < word.Length && word[index] != letter)
					{
						char[] array2 = word.ToCharArray();
						array2[index] = letter;
						yield return new string(array2);
					}
				}
			}
		}
	}
	public enum ProtectedTokenKind
	{
		None,
		Url,
		Email,
		IpAddress,
		FilePath,
		Domain,
		Version,
		Issue,
		Acronym,
		Code,
		Number
	}
	public static class DetectionRoutes
	{
		public const string PersianDictionary = "PersianDictionary";

		public const string KeyboardEvidence = "KeyboardEvidence";

		public const string LanguagePriority = "LanguagePriority";

		public const string IsolatedLetter = "IsolatedLetter";

		public const string PersianDigits = "PersianDigits";
	}
	public static class PunctuationKeyWordPolicy
	{
		public const int MinimumKeys = 2;

		public static bool IsPunctuationOnlyWord(string source, string target)
		{
			if (source.Length < 2 || target.Length != source.Length)
			{
				return false;
			}
			bool flag = true;
			string text = source;
			foreach (char c in text)
			{
				if (!char.IsAscii(c) || !char.IsPunctuation(c))
				{
					return false;
				}
				flag &= c == source[0];
			}
			if (flag)
			{
				return false;
			}
			text = target;
			foreach (char c2 in text)
			{
				if (c2 < '\u0600' || c2 > 'ۿ' || !char.IsLetter(c2))
				{
					return false;
				}
			}
			return true;
		}

		public static bool HasPersianContext(bool previousWordIsPersian, int persianWordsInParagraph, int englishWordsInParagraph)
		{
			if (!previousWordIsPersian)
			{
				if (persianWordsInParagraph > 0)
				{
					return persianWordsInParagraph >= englishWordsInParagraph;
				}
				return false;
			}
			return true;
		}

		public static string Describe(string source, string target)
		{
			if (IsPunctuationOnlyWord(source, target))
			{
				return "all";
			}
			if (source.Length >= 3 && source.Any(char.IsAsciiLetter))
			{
				bool flag;
				switch (source[0])
				{
				case ',':
				case ';':
				case '[':
				case ']':
					flag = true;
					break;
				default:
					flag = false;
					break;
				}
				if (flag && char.IsAsciiLetter(source[1]))
				{
					return "edge:lead";
				}
				char c = source[source.Length - 1];
				if ((c == '[' || c == ']') ? true : false)
				{
					if (char.IsAsciiLetter(source[source.Length - 2]))
					{
						return "edge:trail";
					}
				}
			}
			return "none";
		}
	}
	public static class ShortPersianWordPolicy
	{
		public static bool CanAutoConvert(int targetLength, int shortWordLength, bool previousWordIsPersian, int persianWordsInParagraph, int englishWordsInParagraph)
		{
			if (targetLength <= shortWordLength)
			{
				return IsPersianContext(previousWordIsPersian, persianWordsInParagraph, englishWordsInParagraph);
			}
			return true;
		}

		public static bool CanAutoConvert(int targetLength, int shortWordLength, bool previousWordIsPersian, int persianWordsInParagraph, int englishWordsInParagraph, int englishProseWordsInParagraph)
		{
			if (targetLength <= shortWordLength)
			{
				return IsPersianContext(previousWordIsPersian, persianWordsInParagraph, englishWordsInParagraph, englishProseWordsInParagraph);
			}
			return true;
		}

		public static bool IsPersianContext(bool previousWordIsPersian, int persianWordsInParagraph, int englishWordsInParagraph)
		{
			if (!previousWordIsPersian && englishWordsInParagraph != 0)
			{
				return persianWordsInParagraph >= englishWordsInParagraph;
			}
			return true;
		}

		public static bool IsPersianContext(bool previousWordIsPersian, int persianWordsInParagraph, int englishWordsInParagraph, int englishProseWordsInParagraph)
		{
			if (!previousWordIsPersian && englishWordsInParagraph != 0)
			{
				if (persianWordsInParagraph >= 1)
				{
					return persianWordsInParagraph >= englishProseWordsInParagraph;
				}
				return false;
			}
			return true;
		}
	}
	public static class SinglePersianCharacterPolicy
	{
		public static bool CanAutoConvert(bool isAutomaticTrigger, int keyCount, int leadingSpaceCount, bool previousLanguageIsPersian)
		{
			return (isAutomaticTrigger && keyCount == 1 && leadingSpaceCount == 1) & previousLanguageIsPersian;
		}

		public static bool CanAutoConvert(bool isAutomaticTrigger, int keyCount, int leadingSpaceCount, bool previousLanguageIsPersian, AmbiguousInputPriority priority, bool keyIsLetter, bool keyTypesWaw, bool atStartOfEmptyText = false)
		{
			if ((uint)(priority - 2) > 1u)
			{
				if (!keyIsLetter)
				{
					if (!keyTypesWaw)
					{
						return CanAutoConvert(isAutomaticTrigger, keyCount, leadingSpaceCount, previousLanguageIsPersian);
					}
					return false;
				}
				if (isAutomaticTrigger && keyCount == 1 && (leadingSpaceCount == 1 || ((leadingSpaceCount == 0) & atStartOfEmptyText)))
				{
					return AmbiguousInputPriorityPolicy.ConvertsIsolatedLetter(priority);
				}
				return false;
			}
			return CanAutoConvert(isAutomaticTrigger, keyCount, leadingSpaceCount, previousLanguageIsPersian);
		}
	}
	public sealed class TechnicalPatternDetector
	{
		public bool IsStrongPattern(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			if (!Url().IsMatch(text) && !Email().IsMatch(text) && !Ipv4WithOptionalPort().IsMatch(text) && !Domain().IsMatch(text) && !WindowsPath().IsMatch(text) && !UnixPath().IsMatch(text) && !DotPrefix().IsMatch(text) && !VersionToken().IsMatch(text) && !PullRequestOrIssue().IsMatch(text) && !Acronym().IsMatch(text))
			{
				return CodeIdentifier().IsMatch(text);
			}
			return true;
		}

		public bool IsSourceProtectionPattern(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return false;
			}
			if (!Url().IsMatch(text) && !Email().IsMatch(text) && !Ipv4WithOptionalPort().IsMatch(text) && !WindowsPath().IsMatch(text) && !UnixPath().IsMatch(text) && !DotPrefix().IsMatch(text) && !VersionToken().IsMatch(text) && !PullRequestOrIssue().IsMatch(text))
			{
				return Acronym().IsMatch(text);
			}
			return true;
		}

		public ProtectedTokenKind Classify(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				return ProtectedTokenKind.None;
			}
			if (Url().IsMatch(text) || WwwAddress().IsMatch(text))
			{
				return ProtectedTokenKind.Url;
			}
			if (Email().IsMatch(text))
			{
				return ProtectedTokenKind.Email;
			}
			if (Ipv4WithOptionalPort().IsMatch(text))
			{
				return ProtectedTokenKind.IpAddress;
			}
			if (WindowsPath().IsMatch(text) || UnixPath().IsMatch(text) || DotPrefix().IsMatch(text))
			{
				return ProtectedTokenKind.FilePath;
			}
			if (WellKnownDomain().IsMatch(text))
			{
				return ProtectedTokenKind.Domain;
			}
			if (VersionToken().IsMatch(text))
			{
				return ProtectedTokenKind.Version;
			}
			if (PullRequestOrIssue().IsMatch(text))
			{
				return ProtectedTokenKind.Issue;
			}
			if (Acronym().IsMatch(text))
			{
				return ProtectedTokenKind.Acronym;
			}
			if (SnakeCaseIdentifier().IsMatch(text) || CallExpression().IsMatch(text))
			{
				return ProtectedTokenKind.Code;
			}
			if (LettersJoinedToDigits().IsMatch(text))
			{
				return ProtectedTokenKind.Number;
			}
			return ProtectedTokenKind.None;
		}

		[GeneratedRegex("^www\\.[^\\s]+$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex WwwAddress()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WwwAddress_1.Instance;
		}

		[GeneratedRegex("^(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\\.)+(?:com|org|net|ir|io|dev|edu|gov|info|app|ai|co|uk|de|me|tv)$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex WellKnownDomain()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WellKnownDomain_2.Instance;
		}

		[GeneratedRegex("^_*[A-Za-z][A-Za-z0-9]*(?:_+[A-Za-z0-9]+)+_*$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex SnakeCaseIdentifier()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__SnakeCaseIdentifier_3.Instance;
		}

		[GeneratedRegex("^[A-Za-z_][A-Za-z0-9_.]*\\(\\)$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex CallExpression()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CallExpression_4.Instance;
		}

		[GeneratedRegex("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z0-9.\\-]+$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex LettersJoinedToDigits()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__LettersJoinedToDigits_5.Instance;
		}

		[GeneratedRegex("^(https?|ftp)://[^\\s/$.?#].[^\\s]*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex Url()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Url_6.Instance;
		}

		[GeneratedRegex("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex Email()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Email_7.Instance;
		}

		[GeneratedRegex("^(?:25[0-5]|2[0-4]\\d|1?\\d?\\d)(?:\\.(?:25[0-5]|2[0-4]\\d|1?\\d?\\d)){3}(?::\\d{1,5})?$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex Ipv4WithOptionalPort()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Ipv4WithOptionalPort_8.Instance;
		}

		[GeneratedRegex("^(?:[a-z0-9](?:[a-z0-9-]{0,61}[a-z0-9])?\\.)+[a-z]{2,}$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex Domain()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Domain_9.Instance;
		}

		[GeneratedRegex("^[a-zA-Z]:\\\\(?:[^<>:\"|?*\\r\\n]+\\\\?)*$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex WindowsPath()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__WindowsPath_10.Instance;
		}

		[GeneratedRegex("^(?:~|/)?(?:[^/\\0]+/)+[^/\\0]*$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex UnixPath()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__UnixPath_11.Instance;
		}

		[GeneratedRegex("^\\.[A-Za-z0-9][A-Za-z0-9._-]*$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex DotPrefix()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__DotPrefix_12.Instance;
		}

		[GeneratedRegex("^v\\d+(?:\\.\\d+){1,3}$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex VersionToken()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__VersionToken_13.Instance;
		}

		[GeneratedRegex("^(?:PR-\\d+|#\\d+)$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex PullRequestOrIssue()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__PullRequestOrIssue_14.Instance;
		}

		[GeneratedRegex("^[A-Z]{2,10}$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex Acronym()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__Acronym_15.Instance;
		}

		[GeneratedRegex("^[A-Za-z_][A-Za-z0-9_]{1,63}$", RegexOptions.CultureInvariant)]
		[GeneratedCode("System.Text.RegularExpressions.Generator", "10.0.14.42308")]
		private static Regex CodeIdentifier()
		{
			return <RegexGenerator_g>F7D71E0883F153C77C25C1FCE1368B266B9F3F0D480BD5F17C3704E626ADA6241__CodeIdentifier_16.Instance;
		}
	}
	public static class UppercaseLatinPolicy
	{
		public static bool HasUppercaseLatin(string text)
		{
			return text.Any((char character) => character >= 'A' && character <= 'Z');
		}
	}
	public enum WawAtOnceRule
	{
		None,
		NonWordCharacter,
		CapitalOnNonPersianKey,
		EnglishWordPrefix
	}
	public readonly record struct WawAtOnceKey(char Latin, bool IsPersianWordCharacter, bool IsCapitalOnNonPersianKey);
	public static class WawAtOncePolicy
	{
		public static WawAtOnceRule Withheld(bool enabled, IReadOnlyList<WawAtOnceKey> token, bool previousWordIsEnglish, Func<string, bool> isEnglishWord)
		{
			if (!enabled)
			{
				return WawAtOnceRule.None;
			}
			if (token.Count == 0)
			{
				return WawAtOnceRule.None;
			}
			foreach (WawAtOnceKey item in token)
			{
				if (!item.IsPersianWordCharacter)
				{
					return WawAtOnceRule.NonWordCharacter;
				}
			}
			foreach (WawAtOnceKey item2 in token)
			{
				if (item2.IsCapitalOnNonPersianKey)
				{
					return WawAtOnceRule.CapitalOnNonPersianKey;
				}
			}
			StringBuilder stringBuilder = new StringBuilder(token.Count);
			foreach (WawAtOnceKey item3 in token)
			{
				if (char.IsAsciiLetter(item3.Latin))
				{
					stringBuilder.Append(char.ToLowerInvariant(item3.Latin));
				}
			}
			if (!previousWordIsEnglish || stringBuilder.Length < 2 || !isEnglishWord(stringBuilder.ToString()))
			{
				return WawAtOnceRule.None;
			}
			return WawAtOnceRule.EnglishWordPrefix;
		}
	}
}
namespace SmartInput.Core.Detection.Smart
{
	public sealed class SmartDetectionEngine : IDetectionEngine
	{
		private const char ZeroWidthNonJoiner = '\u200c';

		private const char ArabicBlockStart = '\u0600';

		private const char ArabicBlockEnd = 'ۿ';

		private readonly LexiconStore _lexiconStore;

		private readonly TechnicalPatternDetector _technicalPatternDetector;

		private readonly DecisionPolicy _policy;

		private const char Waw = 'و';

		public TypingEngine Engine => TypingEngine.Smart;

		public DecisionPolicy Policy => _policy;

		public SmartDetectionEngine(LexiconStore lexiconStore, TechnicalPatternDetector technicalPatternDetector, DecisionPolicy? policy = null)
		{
			_lexiconStore = lexiconStore;
			_technicalPatternDetector = technicalPatternDetector;
			_policy = policy ?? DecisionPolicy.Default;
		}

		public DetectionResult Evaluate(DetectionRequest request)
		{
			string text = Normalize(request.Source);
			string text2 = Normalize(request.Target);
			string text3 = Normalize(request.ProtectionSource ?? request.Source);
			if (request.AllowPersianDigits && request.IsAutomaticTrigger && PersianDigitPolicy.IsDigitForm(text, text2) && _technicalPatternDetector.Classify(text3) == ProtectedTokenKind.None)
			{
				return new DetectionResult(0, 0, BlockingRuleMatched: false, ShouldAutoCorrect: true, ShouldAllowManualCorrection: false, null, "PersianDigits");
			}
			if (IsBlockedByIdentityOrInvalidTarget(text, text2, request.IsAutomaticTrigger, request.AllowSingleCharacterTarget, out string reason))
			{
				return Blocked(0, reason);
			}
			if (HeldKeyPolicy.LooksLikeAHeldKey(text))
			{
				return Blocked(0, "The token repeats one letter more than any word does: a held key, not a word.");
			}
			DetectedLanguage detectedLanguage = DetectLanguage(text);
			DetectedLanguage detectedLanguage2 = DetectLanguage(text2);
			if (request.IsAutomaticTrigger && HasUppercaseLatin(text3))
			{
				return Blocked(_policy.ProtectedSourceScore, "Uppercase Latin input is protected from automatic conversion.");
			}
			bool flag = request.AllowSingleCharacterTarget && text.Length == 1 && char.IsPunctuation(text[0]);
			bool flag2 = request.Settings.PunctuationKeyWordsConvert && request.IsAutomaticTrigger && detectedLanguage == DetectedLanguage.Unknown && PunctuationKeyWordPolicy.IsPunctuationOnlyWord(text, text2);
			if (flag2 && !PunctuationKeyWordPolicy.HasPersianContext(request.PreviousWordIsPersian, request.PersianWordsInParagraph, request.EnglishWordsInParagraph))
			{
				return Blocked(0, $"Punctuation-key word: the local context is not Persian (prev={request.PreviousWordIsPersian}, P={request.PersianWordsInParagraph}, E={request.EnglishWordsInParagraph}).");
			}
			if (request.IsAutomaticTrigger && (request.ActiveLanguage != DetectedLanguage.English || (detectedLanguage != DetectedLanguage.English && !flag && !flag2) || detectedLanguage2 != DetectedLanguage.Persian))
			{
				return Blocked(0, "Automatic correction only supports English-layout input to Persian.");
			}
			if (request.IsAutomaticTrigger)
			{
				ProtectedTokenKind protectedTokenKind = _technicalPatternDetector.Classify(text3);
				if (protectedTokenKind != ProtectedTokenKind.None)
				{
					int protectedSourceScore = _policy.ProtectedSourceScore;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Protected token: ");
					defaultInterpolatedStringHandler.AppendFormatted(protectedTokenKind);
					defaultInterpolatedStringHandler.AppendLiteral(".");
					return Blocked(protectedSourceScore, defaultInterpolatedStringHandler.ToStringAndClear()) with
					{
						ProtectedKind = protectedTokenKind
					};
				}
				if (_lexiconStore.IsSessionEnglishPreference(text))
				{
					return Blocked(_policy.ProtectedSourceScore, "Restored to English earlier in this session.");
				}
			}
			int num = 0;
			int num2 = 0;
			bool flag3 = _lexiconStore.IsUserExactMatch(text2, detectedLanguage2);
			bool flag4 = _lexiconStore.IsHighFrequency(text2, detectedLanguage2);
			bool flag5 = _lexiconStore.IsBuiltinWord(text2, detectedLanguage2);
			bool flag6 = detectedLanguage2 == DetectedLanguage.Persian && IsColloquialObjectForm(text2);
			bool flag7 = flag3 | flag4 | flag5 | flag6;
			DetectedLanguage language = (flag2 ? DetectedLanguage.English : detectedLanguage);
			if (_lexiconStore.IsUserPrevented(text, language) || _lexiconStore.IsTechnicalMatch(text) || _lexiconStore.IsShortcutExpression(text3) || _technicalPatternDetector.IsSourceProtectionPattern(text3))
			{
				return Blocked(num + _policy.ProtectedSourceScore, "Source token is protected by prevent-conversion or technical pattern.");
			}
			bool flag8 = request.IsAutomaticTrigger;
			if (flag8)
			{
				CorrectionMode mode = request.Settings.Mode;
				bool flag9 = (uint)(mode - 1) <= 1u;
				flag8 = flag9;
			}
			bool flag10 = flag8;
			AmbiguousInputPriority ambiguousInputPriority = request.Settings.AmbiguousInputPriority;
			bool flag11 = request.IsAutomaticTrigger && detectedLanguage == DetectedLanguage.English && _lexiconStore.IsStrongEnglishProtection(text);
			WordFormRecognition wordFormRecognition = request.Settings.WordFormRecognition;
			PersianFormKind persianFormKind = PersianFormKind.None;
			if (flag10 && detectedLanguage2 == DetectedLanguage.Persian)
			{
				if (ambiguousInputPriority == AmbiguousInputPriority.Persian)
				{
					persianFormKind = PersianFormPolicy.Classify(_lexiconStore, text2);
					if (persianFormKind == PersianFormKind.None && WordFormRecognitionPolicy.AnalyzesSuffixes(wordFormRecognition))
					{
						persianFormKind = PersianFormPolicy.ClassifyWordForm(_lexiconStore, text2, _policy);
					}
				}
				else if (WordFormRecognitionPolicy.AnalyzesSuffixes(wordFormRecognition) && !flag7 && IsPlausibleUnknownPersian(text, text2) && ShortPersianWordPolicy.IsPersianContext(request.PreviousWordIsPersian, request.PersianWordsInParagraph, request.EnglishWordsInParagraph, ShortWordEnglishProse(request)) && !flag11 && !IsEnglishWord(text))
				{
					persianFormKind = PersianFormPolicy.ClassifyWordForm(_lexiconStore, text2, _policy);
					flag8 = ((persianFormKind == PersianFormKind.BasePlusSuffix || persianFormKind == PersianFormKind.BasePlusSuffixChain) ? true : false);
					if (flag8 && IsLikelyEnglishTypo(text))
					{
						persianFormKind = PersianFormKind.None;
					}
				}
			}
			if (persianFormKind != PersianFormKind.None)
			{
				flag7 = true;
			}
			flag8 = ((persianFormKind == PersianFormKind.BasePlusSuffix || persianFormKind == PersianFormKind.BasePlusSuffixChain) ? true : false);
			if (flag8 && (flag11 || IsEnglishWord(text)))
			{
				persianFormKind = PersianFormKind.None;
				flag7 = flag3 | flag4 | flag5 | flag6;
			}
			if (flag10 && AmbiguousInputPriorityPolicy.ConvertsIsolatedLetter(ambiguousInputPriority) && request.AllowSingleCharacterTarget && text.Length == 1 && char.IsAsciiLetter(text[0]) && text2.Length == 1 && IsPersianLetter(text2[0]))
			{
				return new DetectionResult(0, 0, BlockingRuleMatched: false, ShouldAutoCorrect: true, ShouldAllowManualCorrection: true, null, "IsolatedLetter");
			}
			if (_lexiconStore.IsUserExactMatch(text, detectedLanguage))
			{
				num += _policy.UserDictionaryScore;
			}
			if (flag3)
			{
				num2 += _policy.UserDictionaryScore;
			}
			if (_lexiconStore.IsTechnicalMatch(text2))
			{
				num2 += _policy.TechnicalTargetScore;
			}
			if (_technicalPatternDetector.IsStrongPattern(text2))
			{
				num2 += _policy.StrongPatternTargetScore;
			}
			num += GetLexicalScore(text, detectedLanguage);
			num2 += GetLexicalScore(text2, detectedLanguage2);
			if (flag6)
			{
				num2 += _policy.ColloquialObjectFormScore;
			}
			if (persianFormKind != PersianFormKind.None && !flag5)
			{
				num2 += _policy.DerivedPersianFormScore;
			}
			if (detectedLanguage2 == DetectedLanguage.Persian && request.PersianContextScore > 0)
			{
				num2 += Math.Min(request.PersianContextScore, _policy.MaximumContextScore);
			}
			if (request.ActiveLanguage == detectedLanguage)
			{
				num += _policy.ActiveLanguageScore;
			}
			if (request.ActiveLanguage != DetectedLanguage.Unknown && detectedLanguage2 != DetectedLanguage.Unknown && request.ActiveLanguage != detectedLanguage2)
			{
				num2 += _policy.CrossLanguageScore;
			}
			bool flag12 = LooksLikeWrongLayoutSource(text, detectedLanguage, detectedLanguage2);
			if (flag12)
			{
				num2 += _policy.WrongLayoutShapeScore;
			}
			if (HasImplausibleMixedScripts(text2))
			{
				num2 -= _policy.MixedScriptPenalty;
			}
			if (ContainsControlCharacters(text2))
			{
				num2 -= _policy.ControlCharacterPenalty;
			}
			int num3 = ((text2.Length <= _policy.ShortWordLength) ? Math.Max(request.Settings.AutomaticMarginThreshold, _policy.ShortWordMarginThreshold) : request.Settings.AutomaticMarginThreshold);
			bool flag13 = ShortPersianWordPolicy.CanAutoConvert(text2.Length, _policy.ShortWordLength, request.PreviousWordIsPersian, request.PersianWordsInParagraph, request.EnglishWordsInParagraph, ShortWordEnglishProse(request)) || persianFormKind == PersianFormKind.CuratedShortWord || (flag10 && WordFormRecognitionPolicy.RecognizesStandaloneEnclitics(wordFormRecognition) && detectedLanguage2 == DetectedLanguage.Persian && PersianEncliticTokenPolicy.StandsWithoutPersianContext(_lexiconStore.IsPersianEnclitic(text2), flag11 || IsEnglishWord(text), _lexiconStore.IsBuiltinWord(text, DetectedLanguage.English)));
			bool flag14 = (flag10 & flag13 & flag7) && num2 >= request.Settings.AutomaticTargetThreshold;
			bool flag15 = flag14 && num2 - num >= num3;
			BilingualContext context = ((flag10 && ambiguousInputPriority == AmbiguousInputPriority.Contextual) ? BilingualWordPolicy.Describe(_lexiconStore, request, text, text2, _policy.CommonPersianWordRank) : default(BilingualContext));
			bool? flag16 = (flag10 ? AmbiguousInputPriorityPolicy.ConvertsWordRecognizedInBoth(ambiguousInputPriority, flag11 || IsEnglishWord(text), flag14, context) : ((bool?)null));
			if (flag11 && flag16 != true)
			{
				return Blocked(_policy.ProtectedSourceScore, "Source token is protected by prevent-conversion or technical pattern.") with
				{
					KeptAsBilingualByContext = (((flag10 && ambiguousInputPriority == AmbiguousInputPriority.Contextual) & flag14) && context.TargetIsCommonPersian && !context.SourceIsHighFrequencyEnglish)
				};
			}
			int num4 = 0;
			int num5 = 0;
			string text4 = null;
			bool flag17 = false;
			if (((flag10 && !flag16.HasValue && !flag15) & flag13) && request.AllowUnknownPersianTarget && !IsEnglishWord(text) && IsPlausibleUnknownPersian(text, text2))
			{
				num4 = (HasInteriorPersianOnlyKey(text, text2) ? _policy.PersianOnlyKeyScore : 0) + (flag12 ? _policy.WrongLayoutShapeScore : 0);
				text4 = EnglishTypoShapeOf(text, request.Settings.PersianOnlyKeyMayBeEnglishTypo, request.Settings.PersianOnlyKeyMayBeEnglishTypo && request.Settings.PersianOnlyKeyInsertionMayBeEnglishTypo);
				bool flag18 = LooksLikeEnglishContraction(text);
				num5 = ((text4 != null) ? _policy.EnglishTypoScore : 0) + (flag18 ? _policy.EnglishContractionScore : 0);
				if (text4 == null)
				{
					text4 = (flag18 ? "contraction" : null);
				}
				flag17 = num4 - num5 >= _policy.UnknownWordMarginThreshold;
			}
			bool shouldAutoCorrect = flag16 ?? (flag15 | flag17);
			bool shouldAllowManualCorrection = !ContainsControlCharacters(text2) && !string.Equals(text, text2, StringComparison.Ordinal) && !IsAllDigitsOrPunctuation(text2);
			return new DetectionResult(num, num2, BlockingRuleMatched: false, shouldAutoCorrect, shouldAllowManualCorrection, null, (flag16 == false) ? null : (flag15 ? "PersianDictionary" : ((flag16 == true) ? "LanguagePriority" : (flag17 ? "KeyboardEvidence" : null))))
			{
				KeyboardEvidence = num4,
				EnglishTypoEvidence = num5,
				EnglishTypoShape = text4,
				RequiredMargin = num3,
				ShortWordAllowed = flag13,
				DerivedForm = persianFormKind
			};
		}

		private static int ShortWordEnglishProse(DetectionRequest request)
		{
			if (!request.Settings.ShortWordsIgnoreCapitalizedTerms)
			{
				return request.EnglishWordsInParagraph;
			}
			return request.EnglishProseWordsInParagraph ?? request.EnglishWordsInParagraph;
		}

		private static DetectionResult Blocked(int sourceScore, string reason)
		{
			return new DetectionResult(sourceScore, 0, BlockingRuleMatched: true, ShouldAutoCorrect: false, ShouldAllowManualCorrection: false, reason);
		}

		public bool IsEnglishWord(string source)
		{
			if (!_lexiconStore.IsUserExactMatch(source, DetectedLanguage.English))
			{
				return GetLexicalScore(source, DetectedLanguage.English) > 0;
			}
			return true;
		}

		public bool IsLikelyEnglishTypo(string source)
		{
			return IsLikelyEnglishTypo(source, persianOnlyKeyMayBeATypo: false);
		}

		public bool IsLikelyEnglishTypo(string source, bool persianOnlyKeyMayBeATypo)
		{
			return EnglishTypoShapeOf(source, persianOnlyKeyMayBeATypo, persianOnlyKeyInsertionMayBeATypo: false) != null;
		}

		public bool IsLikelyEnglishTypo(string source, bool persianOnlyKeyMayBeATypo, bool persianOnlyKeyInsertionMayBeATypo)
		{
			return EnglishTypoShapeOf(source, persianOnlyKeyMayBeATypo, persianOnlyKeyInsertionMayBeATypo) != null;
		}

		private string? EnglishTypoShapeOf(string source, bool persianOnlyKeyMayBeATypo, bool persianOnlyKeyInsertionMayBeATypo)
		{
			string text = new string(source.Where((char ch) =>
			{
				bool flag = ((ch == '\'' || ch == '-') ? true : false);
				return !flag;
			}).ToArray());
			if (text.Length < _policy.EnglishTypoMinimumLength)
			{
				return null;
			}
			if (!text.All((char ch) =>
			{
				switch (ch)
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
				if (!persianOnlyKeyMayBeATypo)
				{
					return null;
				}
				int num = IndexOfSinglePersianOnlyKey(text);
				if (num < 0)
				{
					return null;
				}
				string text2 = text.ToLowerInvariant();
				if (IsOneLetterAwayAt(text2, num))
				{
					return "slip-substitution";
				}
				if (!persianOnlyKeyInsertionMayBeATypo || !IsTypoNeighbor(text2.Remove(num, 1)))
				{
					return null;
				}
				return "slip-insertion";
			}
			string text3 = text.ToLowerInvariant();
			if (_lexiconStore.IsBuiltinWord(text3, DetectedLanguage.English))
			{
				return "letters";
			}
			char[] array = new char[text3.Length + 1];
			for (int num2 = 0; num2 <= text3.Length; num2++)
			{
				if (num2 < text3.Length && IsTypoNeighbor(string.Concat(text3.AsSpan(0, num2), text3.AsSpan(num2 + 1))))
				{
					return "letters";
				}
				if (num2 + 1 < text3.Length)
				{
					text3.CopyTo(0, array, 0, text3.Length);
					ref char reference = ref array[num2];
					ref char reference2 = ref array[num2 + 1];
					char c = array[num2 + 1];
					char c2 = array[num2];
					reference = c;
					reference2 = c2;
					if (IsTypoNeighbor(new string(array, 0, text3.Length)))
					{
						return "letters";
					}
				}
				for (char c3 = 'a'; c3 <= 'z'; c3 = (char)(c3 + 1))
				{
					if (num2 < text3.Length && c3 != text3[num2])
					{
						text3.CopyTo(0, array, 0, text3.Length);
						array[num2] = c3;
						if (IsTypoNeighbor(new string(array, 0, text3.Length)))
						{
							return "letters";
						}
					}
					if (IsTypoNeighbor(string.Concat(text3.AsSpan(0, num2), new ReadOnlySpan<char>((char)c3), text3.AsSpan(num2))))
					{
						return "letters";
					}
				}
			}
			return null;
		}

		private bool IsTypoNeighbor(string candidate)
		{
			if (candidate.Length >= _policy.EnglishTypoMinimumLength)
			{
				return _lexiconStore.IsBuiltinWord(candidate, DetectedLanguage.English);
			}
			return false;
		}

		internal static int IndexOfSinglePersianOnlyKey(string letters)
		{
			int num = -1;
			for (int i = 0; i < letters.Length; i++)
			{
				if (!char.IsAsciiLetter(letters[i]))
				{
					if (char.IsAsciiDigit(letters[i]) || num >= 0)
					{
						return -1;
					}
					num = i;
				}
			}
			return num;
		}

		private bool IsOneLetterAwayAt(string word, int index)
		{
			char[] array = word.ToCharArray();
			for (char c = 'a'; c <= 'z'; c = (char)(c + 1))
			{
				array[index] = c;
				if (IsTypoNeighbor(new string(array)))
				{
					return true;
				}
			}
			return false;
		}

		internal static bool HasInteriorPersianOnlyKey(string source, string target)
		{
			if (source.Length != target.Length || source.Length < 3)
			{
				return false;
			}
			for (int i = 1; i < source.Length - 1; i++)
			{
				bool flag = !char.IsAsciiLetter(source[i]) && !char.IsAsciiDigit(source[i]);
				if (flag)
				{
					char c = source[i];
					bool flag2 = ((c == '\'' || c == '-') ? true : false);
					flag = !flag2;
				}
				if (flag && IsPersianLetter(target[i]))
				{
					return true;
				}
			}
			return false;
		}

		internal static bool LooksLikeEnglishContraction(string source)
		{
			int apostrophe = source.IndexOf('\'');
			if (apostrophe > 0 && apostrophe < source.Length - 1 && source.LastIndexOf('\'') == apostrophe && source.Length - apostrophe - 1 <= 3)
			{
				return source.Where((char _, int index) => index != apostrophe).All(char.IsAsciiLetter);
			}
			return false;
		}

		public bool IsColloquialObjectForm(string target)
		{
			if (target.Length >= 3)
			{
				if (target[target.Length - 1] == 'و')
				{
					string text = target.Substring(0, target.Length - 1);
					bool flag;
					switch (text[text.Length - 1])
					{
					case 'ء':
					case 'آ':
					case 'ا':
					case 'ه':
					case 'و':
					case 'ی':
						flag = true;
						break;
					default:
						flag = false;
						break;
					}
					if (!flag)
					{
						if (GetLexicalScore(text, DetectedLanguage.Persian) <= 0)
						{
							return _lexiconStore.IsUserExactMatch(text, DetectedLanguage.Persian);
						}
						return true;
					}
					return false;
				}
			}
			return false;
		}

		internal static bool IsPlausibleUnknownPersian(string source, string target)
		{
			if (source.Length <= 24 && source.Any((char ch) =>
			{
				switch (ch)
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
			}) && !source.Any(char.IsDigit) && target.Length >= 2)
			{
				return target.All((char ch) => ch == '\u200c' || IsPersianLetter(ch));
			}
			return false;
		}

		private static bool IsPersianLetter(char character)
		{
			if (character >= '\u0600' && character <= 'ۿ')
			{
				return char.IsLetter(character);
			}
			return false;
		}

		private int GetLexicalScore(string term, DetectedLanguage language)
		{
			if (language == DetectedLanguage.English && term.Length <= 2 && !_lexiconStore.IsStrongEnglishProtection(term))
			{
				return 0;
			}
			int num = 0;
			if (_lexiconStore.IsHighFrequency(term, language))
			{
				num += _policy.HighFrequencyWordScore;
			}
			else if (_lexiconStore.IsNormalFrequency(term, language))
			{
				num += _policy.NormalFrequencyWordScore;
			}
			if (_lexiconStore.IsBuiltinWord(term, language))
			{
				num += _policy.BuiltinWordScore;
			}
			return num;
		}

		private static string Normalize(string input)
		{
			return input.Trim().Replace('ي', 'ی').Replace('ك', 'ک');
		}

		private static bool IsBlockedByIdentityOrInvalidTarget(string source, string target, bool isAutomaticTrigger, bool allowSingleCharacterTarget, out string reason)
		{
			if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target))
			{
				reason = "Source or target is empty.";
				return true;
			}
			if (string.Equals(source, target, StringComparison.Ordinal))
			{
				reason = "Target equals source after normalization.";
				return true;
			}
			if (isAutomaticTrigger && target.Length == 1 && !allowSingleCharacterTarget)
			{
				reason = "Single-character candidate is blocked for auto-correction.";
				return true;
			}
			if (IsAllDigitsOrPunctuation(target))
			{
				reason = "Target is all digits/punctuation.";
				return true;
			}
			reason = string.Empty;
			return false;
		}

		private static bool IsAllDigitsOrPunctuation(string text)
		{
			return text.All((char ch) => char.IsDigit(ch) || char.IsPunctuation(ch) || char.IsWhiteSpace(ch));
		}

		private static bool ContainsControlCharacters(string text)
		{
			return text.Any((char ch) => char.IsControl(ch));
		}

		private static bool HasUppercaseLatin(string text)
		{
			return UppercaseLatinPolicy.HasUppercaseLatin(text);
		}

		private bool LooksLikeWrongLayoutSource(string source, DetectedLanguage sourceLanguage, DetectedLanguage targetLanguage)
		{
			if (source.Length < 3)
			{
				return false;
			}
			if (sourceLanguage == DetectedLanguage.English && targetLanguage == DetectedLanguage.Persian)
			{
				int num = 0;
				int num2 = 0;
				foreach (char c in source)
				{
					if (!char.IsWhiteSpace(c))
					{
						bool flag;
						switch (c)
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
							flag = true;
							break;
						default:
							flag = false;
							break;
						}
						if (!flag && !char.IsPunctuation(c))
						{
							return false;
						}
						num++;
						switch (c)
						{
						case 'A':
						case 'E':
						case 'I':
						case 'O':
						case 'U':
						case 'a':
						case 'e':
						case 'i':
						case 'o':
						case 'u':
							flag = true;
							break;
						default:
							flag = false;
							break;
						}
						if (flag)
						{
							num2++;
						}
					}
				}
				if (num < 3)
				{
					return false;
				}
				return (double)num2 / (double)num <= _policy.WrongLayoutMaximumVowelRatio;
			}
			if (sourceLanguage == DetectedLanguage.Persian && targetLanguage == DetectedLanguage.English)
			{
				return source.Any((char ch) => ch >= '\u0600' && ch <= 'ۿ');
			}
			return false;
		}

		private static bool HasImplausibleMixedScripts(string text)
		{
			bool flag = text.Any((char ch) =>
			{
				switch (ch)
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
			});
			bool flag2 = text.Any((char ch) => ch >= '\u0600' && ch <= 'ۿ');
			return flag & flag2;
		}

		private static DetectedLanguage DetectLanguage(string text)
		{
			bool flag = text.Any((char ch) =>
			{
				switch (ch)
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
			});
			bool flag2 = text.Any((char ch) => ch >= '\u0600' && ch <= 'ۿ');
			if (flag2 && !flag)
			{
				return DetectedLanguage.Persian;
			}
			if (flag && !flag2)
			{
				return DetectedLanguage.English;
			}
			return DetectedLanguage.Unknown;
		}

		public static bool StartsWithCapitalLetter(string text)
		{
			int i;
			for (i = 0; i < text.Length && (char.IsPunctuation(text[i]) || char.IsWhiteSpace(text[i])); i++)
			{
			}
			if (i >= text.Length)
			{
				return false;
			}
			return char.IsUpper(text[i]);
		}

		public static string ConvertDigitsToPersian(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			char[] array = text.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] >= '0' && array[i] <= '9')
				{
					array[i] = (char)(1776 + (array[i] - 48));
				}
			}
			return new string(array);
		}
	}
}
namespace SmartInput.Core.Detection.Classic
{
	public sealed class ClassicDetectionEngine : IDetectionEngine
	{
		private readonly LexiconStore _lexiconStore;

		private readonly TechnicalPatternDetector _technicalPatternDetector;

		public TypingEngine Engine => TypingEngine.Classic;

		public ClassicDetectionEngine(LexiconStore lexiconStore, TechnicalPatternDetector technicalPatternDetector)
		{
			_lexiconStore = lexiconStore;
			_technicalPatternDetector = technicalPatternDetector;
		}

		public DetectionResult Evaluate(DetectionRequest request)
		{
			string text = Normalize(request.Source);
			string text2 = Normalize(request.Target);
			string text3 = Normalize(request.ProtectionSource ?? request.Source);
			if (IsBlockedByIdentityOrInvalidTarget(text, text2, request.IsAutomaticTrigger, request.AllowSingleCharacterTarget, out string reason))
			{
				return new DetectionResult(0, 0, BlockingRuleMatched: true, ShouldAutoCorrect: false, ShouldAllowManualCorrection: false, reason);
			}
			if (HeldKeyPolicy.LooksLikeAHeldKey(text))
			{
				return new DetectionResult(0, 0, BlockingRuleMatched: true, ShouldAutoCorrect: false, ShouldAllowManualCorrection: false, "The token repeats one letter more than any word does: a held key, not a word.");
			}
			DetectedLanguage detectedLanguage = DetectLanguage(text);
			DetectedLanguage detectedLanguage2 = DetectLanguage(text2);
			if (request.IsAutomaticTrigger && HasUppercaseLatin(text3))
			{
				return new DetectionResult(120, 0, BlockingRuleMatched: true, ShouldAutoCorrect: false, ShouldAllowManualCorrection: false, "Uppercase Latin input is protected from automatic conversion.");
			}
			bool flag = request.AllowSingleCharacterTarget && text.Length == 1 && char.IsPunctuation(text[0]);
			if (request.IsAutomaticTrigger && (request.ActiveLanguage != DetectedLanguage.English || (detectedLanguage != DetectedLanguage.English && !flag) || detectedLanguage2 != DetectedLanguage.Persian))
			{
				return new DetectionResult(0, 0, BlockingRuleMatched: true, ShouldAutoCorrect: false, ShouldAllowManualCorrection: false, "Automatic correction only supports English-layout input to Persian.");
			}
			int num = 0;
			int num2 = 0;
			bool flag2 = _lexiconStore.IsUserExactMatch(text2, detectedLanguage2);
			bool flag3 = _lexiconStore.IsHighFrequency(text2, detectedLanguage2);
			bool flag4 = _lexiconStore.IsBuiltinWord(text2, detectedLanguage2);
			bool flag5 = flag2 | flag3 | flag4;
			if (_lexiconStore.IsUserPrevented(text, detectedLanguage) || _lexiconStore.IsTechnicalMatch(text) || _lexiconStore.IsShortcutExpression(text3) || _technicalPatternDetector.IsSourceProtectionPattern(text3))
			{
				return ProtectedSource();
			}
			bool flag6 = request.IsAutomaticTrigger;
			if (flag6)
			{
				CorrectionMode mode = request.Settings.Mode;
				bool flag7 = (uint)(mode - 1) <= 1u;
				flag6 = flag7;
			}
			bool flag8 = flag6;
			AmbiguousInputPriority ambiguousInputPriority = request.Settings.AmbiguousInputPriority;
			bool flag9 = request.IsAutomaticTrigger && detectedLanguage == DetectedLanguage.English && _lexiconStore.IsStrongEnglishProtection(text);
			WordFormRecognition wordFormRecognition = request.Settings.WordFormRecognition;
			PersianFormKind persianFormKind = PersianFormKind.None;
			if (flag8 && detectedLanguage2 == DetectedLanguage.Persian)
			{
				if (ambiguousInputPriority == AmbiguousInputPriority.Persian)
				{
					persianFormKind = PersianFormPolicy.Classify(_lexiconStore, text2);
					if (persianFormKind == PersianFormKind.None && WordFormRecognitionPolicy.AnalyzesSuffixes(wordFormRecognition))
					{
						persianFormKind = PersianFormPolicy.ClassifyWordForm(_lexiconStore, text2, DecisionPolicy.Default);
					}
				}
				else if (WordFormRecognitionPolicy.AnalyzesSuffixes(wordFormRecognition) && !flag5 && IsPlausibleUnknownPersian(text, text2) && ShortPersianWordPolicy.IsPersianContext(request.PreviousWordIsPersian, request.PersianWordsInParagraph, request.EnglishWordsInParagraph) && !flag9 && !IsEnglishWord(text))
				{
					persianFormKind = PersianFormPolicy.ClassifyWordForm(_lexiconStore, text2, DecisionPolicy.Default);
				}
			}
			if (persianFormKind != PersianFormKind.None)
			{
				flag5 = true;
			}
			flag6 = ((persianFormKind == PersianFormKind.BasePlusSuffix || persianFormKind == PersianFormKind.BasePlusSuffixChain) ? true : false);
			if (flag6 && (flag9 || IsEnglishWord(text)))
			{
				persianFormKind = PersianFormKind.None;
				flag5 = flag2 | flag3 | flag4;
			}
			if (flag8 && AmbiguousInputPriorityPolicy.ConvertsIsolatedLetter(ambiguousInputPriority) && request.AllowSingleCharacterTarget && text.Length == 1 && char.IsAsciiLetter(text[0]) && text2.Length == 1)
			{
				char c = text2[0];
				if (c >= '\u0600' && c <= 'ۿ' && char.IsLetter(text2[0]))
				{
					return new DetectionResult(0, 0, BlockingRuleMatched: false, ShouldAutoCorrect: true, ShouldAllowManualCorrection: true, null, "IsolatedLetter");
				}
			}
			if (_lexiconStore.IsUserExactMatch(text, detectedLanguage))
			{
				num += 120;
			}
			if (flag2)
			{
				num2 += 120;
			}
			if (_lexiconStore.IsTechnicalMatch(text2))
			{
				num2 += 100;
			}
			if (_technicalPatternDetector.IsStrongPattern(text2))
			{
				num2 += 95;
				num2 += 30;
			}
			num += GetLexicalScore(text, detectedLanguage);
			num2 += GetLexicalScore(text2, detectedLanguage2);
			if (persianFormKind != PersianFormKind.None && !flag4)
			{
				num2 += DecisionPolicy.Default.DerivedPersianFormScore;
			}
			if (detectedLanguage2 == DetectedLanguage.Persian && request.PersianContextScore > 0)
			{
				num2 += Math.Min(request.PersianContextScore, 60);
			}
			if (request.ActiveLanguage == detectedLanguage)
			{
				num += 25;
			}
			if (request.ActiveLanguage != DetectedLanguage.Unknown && detectedLanguage2 != DetectedLanguage.Unknown && request.ActiveLanguage != detectedLanguage2)
			{
				num2 += 25;
			}
			if (LooksLikeWrongLayoutSource(text, detectedLanguage, detectedLanguage2))
			{
				num2 += 55;
			}
			if (HasImplausibleMixedScripts(text2))
			{
				num2 -= 50;
			}
			if (ContainsControlCharacters(text2))
			{
				num2 -= 100;
			}
			bool flag10 = (flag8 & flag5) && num2 >= request.Settings.AutomaticTargetThreshold;
			bool flag11 = flag10 && num2 - num >= request.Settings.AutomaticMarginThreshold;
			bool? flag12 = (flag8 ? AmbiguousInputPriorityPolicy.ConvertsWordRecognizedInBoth(ambiguousInputPriority, flag9 || IsEnglishWord(text), (flag10 && ShortPersianWordPolicy.CanAutoConvert(text2.Length, DecisionPolicy.Default.ShortWordLength, request.PreviousWordIsPersian, request.PersianWordsInParagraph, request.EnglishWordsInParagraph)) || (flag10 && persianFormKind == PersianFormKind.CuratedShortWord) || (flag10 && WordFormRecognitionPolicy.RecognizesStandaloneEnclitics(wordFormRecognition) && PersianEncliticTokenPolicy.StandsWithoutPersianContext(_lexiconStore.IsPersianEnclitic(text2), flag9 || IsEnglishWord(text), _lexiconStore.IsBuiltinWord(text, DetectedLanguage.English))), (ambiguousInputPriority == AmbiguousInputPriority.Contextual) ? BilingualWordPolicy.Describe(_lexiconStore, request, text, text2, DecisionPolicy.Default.CommonPersianWordRank) : default(BilingualContext)) : ((bool?)null));
			if (flag9 && flag12 != true)
			{
				return ProtectedSource();
			}
			bool flag13 = flag8 && !flag12.HasValue && !flag11 && request.AllowUnknownPersianTarget && !IsEnglishWord(text) && IsPlausibleUnknownPersian(text, text2);
			bool flag14 = flag12 ?? (flag11 | flag13);
			bool flag15 = !ContainsControlCharacters(text2) && !string.Equals(text, text2, StringComparison.Ordinal) && !IsAllDigitsOrPunctuation(text2);
			int sourceScore = num;
			int targetScore = num2;
			bool shouldAutoCorrect = flag14;
			bool shouldAllowManualCorrection = flag15;
			string? route;
			if (flag12 == false)
			{
				route = null;
			}
			else if (flag11)
			{
				route = "PersianDictionary";
			}
			else if (flag12 == true)
			{
				route = "LanguagePriority";
			}
			else
			{
				route = (flag13 ? "NotEnglish" : null);
			}
			return new DetectionResult(sourceScore, targetScore, BlockingRuleMatched: false, shouldAutoCorrect, shouldAllowManualCorrection, null, route);
		}

		private static DetectionResult ProtectedSource()
		{
			return new DetectionResult(120, 0, BlockingRuleMatched: true, ShouldAutoCorrect: false, ShouldAllowManualCorrection: false, "Source token is protected by prevent-conversion or technical pattern.");
		}

		public bool IsEnglishWord(string source)
		{
			if (!_lexiconStore.IsUserExactMatch(source, DetectedLanguage.English))
			{
				return GetLexicalScore(source, DetectedLanguage.English) > 0;
			}
			return true;
		}

		internal static bool IsPlausibleUnknownPersian(string source, string target)
		{
			if (source.Length <= 24 && source.Any((char ch) =>
			{
				switch (ch)
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
			}) && !source.Any(char.IsDigit) && target.Length >= 2)
			{
				return target.All((char ch) => ch == '\u200c' || (ch >= '\u0600' && ch <= 'ۿ' && char.IsLetter(ch)));
			}
			return false;
		}

		private int GetLexicalScore(string term, DetectedLanguage language)
		{
			if (language == DetectedLanguage.English && term.Length <= 2 && !_lexiconStore.IsStrongEnglishProtection(term))
			{
				return 0;
			}
			int num = 0;
			if (_lexiconStore.IsHighFrequency(term, language))
			{
				num += 70;
			}
			else if (_lexiconStore.IsNormalFrequency(term, language))
			{
				num += 50;
			}
			if (_lexiconStore.IsBuiltinWord(term, language))
			{
				num += 20;
			}
			return num;
		}

		private static string Normalize(string input)
		{
			return input.Trim().Replace('ي', 'ی').Replace('ك', 'ک');
		}

		private static bool IsBlockedByIdentityOrInvalidTarget(string source, string target, bool isAutomaticTrigger, bool allowSingleCharacterTarget, out string reason)
		{
			if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(target))
			{
				reason = "Source or target is empty.";
				return true;
			}
			if (string.Equals(source, target, StringComparison.Ordinal))
			{
				reason = "Target equals source after normalization.";
				return true;
			}
			if (isAutomaticTrigger && target.Length == 1 && !allowSingleCharacterTarget)
			{
				reason = "Single-character candidate is blocked for auto-correction.";
				return true;
			}
			if (IsAllDigitsOrPunctuation(target))
			{
				reason = "Target is all digits/punctuation.";
				return true;
			}
			reason = string.Empty;
			return false;
		}

		private static bool IsAllDigitsOrPunctuation(string text)
		{
			return text.All((char ch) => char.IsDigit(ch) || char.IsPunctuation(ch) || char.IsWhiteSpace(ch));
		}

		private static bool ContainsControlCharacters(string text)
		{
			return text.Any((char ch) => char.IsControl(ch));
		}

		private static bool HasUppercaseLatin(string text)
		{
			return text.Any((char ch) => ch >= 'A' && ch <= 'Z');
		}

		private static bool LooksLikeWrongLayoutSource(string source, DetectedLanguage sourceLanguage, DetectedLanguage targetLanguage)
		{
			if (source.Length < 3)
			{
				return false;
			}
			if (sourceLanguage == DetectedLanguage.English && targetLanguage == DetectedLanguage.Persian)
			{
				int num = 0;
				int num2 = 0;
				foreach (char c in source)
				{
					if (!char.IsWhiteSpace(c))
					{
						bool flag;
						switch (c)
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
							flag = true;
							break;
						default:
							flag = false;
							break;
						}
						if (!flag && !char.IsPunctuation(c))
						{
							return false;
						}
						num++;
						switch (c)
						{
						case 'A':
						case 'E':
						case 'I':
						case 'O':
						case 'U':
						case 'a':
						case 'e':
						case 'i':
						case 'o':
						case 'u':
							flag = true;
							break;
						default:
							flag = false;
							break;
						}
						if (flag)
						{
							num2++;
						}
					}
				}
				if (num < 3)
				{
					return false;
				}
				return (double)num2 / (double)num <= 0.25;
			}
			if (sourceLanguage == DetectedLanguage.Persian && targetLanguage == DetectedLanguage.English)
			{
				return source.Any((char ch) => ch >= '\u0600' && ch <= 'ۿ');
			}
			return false;
		}

		private static bool HasImplausibleMixedScripts(string text)
		{
			bool flag = text.Any((char ch) =>
			{
				switch (ch)
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
			});
			bool flag2 = text.Any((char ch) => ch >= '\u0600' && ch <= 'ۿ');
			return flag & flag2;
		}

		private static DetectedLanguage DetectLanguage(string text)
		{
			bool flag = text.Any((char ch) =>
			{
				switch (ch)
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
			});
			bool flag2 = text.Any((char ch) => ch >= '\u0600' && ch <= 'ۿ');
			if (flag2 && !flag)
			{
				return DetectedLanguage.Persian;
			}
			if (flag && !flag2)
			{
				return DetectedLanguage.English;
			}
			return DetectedLanguage.Unknown;
		}

		public static bool StartsWithCapitalLetter(string text)
		{
			int i;
			for (i = 0; i < text.Length && (char.IsPunctuation(text[i]) || char.IsWhiteSpace(text[i])); i++)
			{
			}
			if (i >= text.Length)
			{
				return false;
			}
			return char.IsUpper(text[i]);
		}

		public static string ConvertDigitsToPersian(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return text;
			}
			char[] array = text.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] >= '0' && array[i] <= '9')
				{
					array[i] = (char)(1776 + (array[i] - 48));
				}
			}
			return new string(array);
		}
	}
}
