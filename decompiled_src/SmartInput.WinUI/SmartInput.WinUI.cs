using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using ABI.Microsoft.UI.Xaml;
using ABI.Microsoft.UI.Xaml.Markup;
using ABI.System;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Input;
using Microsoft.UI.Text;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Shapes;
using Microsoft.UI.Xaml.XamlTypeInfo;
using Microsoft.Win32;
using Microsoft.Windows.ApplicationModel.WindowsAppRuntime.Common;
using Microsoft.Windows.Foundation.UndockedRegFreeWinRTCS;
using SmartInput.App.Services;
using SmartInput.App.Services.ApplicationFonts;
using SmartInput.App.Services.TextService;
using SmartInput.App.Services.Translation;
using SmartInput.App.Services.Updates;
using SmartInput.App.Tray;
using SmartInput.Core.Detection;
using SmartInput.Core.Diagnostics;
using SmartInput.Core.Dictionaries;
using SmartInput.Core.Environments;
using SmartInput.Core.Keyboard;
using SmartInput.Core.Models;
using SmartInput.Core.Settings;
using SmartInput.Core.Text.Localization;
using SmartInput.Core.Updates;
using SmartInput.Windows.Environments;
using SmartInput.Windows.Input;
using SmartInput.Windows.Layouts;
using SmartInput.WinUI.Services;
using SmartInput.WinUI.SmartInput_WinUI_XamlTypeInfo;
using SmartInput.WinUI.Text;
using SmartInput.WinUI.Views;
using Windows.Foundation.Metadata;
using Windows.Graphics;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Core;
using WinRT;
using WinRT.Interop;
using WinRT.SmartInput_WinUIGenericHelpers;
using WinRT.SmartInput_WinUIVtableClasses;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETCoreApp,Version=v10.0", FrameworkDisplayName = ".NET 10.0")]
[assembly: AssemblyCompany("Webpack")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) 2026 IranUX. All rights reserved.")]
[assembly: AssemblyFileVersion("0.6.302.37")]
[assembly: AssemblyInformationalVersion("0.6.0-beta.12+1067fa6d75b7fbb34a023a09c9716a95d6187838")]
[assembly: AssemblyProduct("Diyar")]
[assembly: AssemblyTitle("SmartInput.WinUI")]
[assembly: AssemblyMetadata("DiyarReleaseDate", "2026-10-30")]
[assembly: TargetPlatform("Windows10.0.26100.0")]
[assembly: SupportedOSPlatform("Windows10.0.17763.0")]
[assembly: AssemblyVersion("0.6.0.0")]
[module: RefSafetyRules(11)]
internal class <Module>
{
	static <Module>()
	{
		Microsoft.Windows.ApplicationModel.WindowsAppRuntime.Common.AutoInitialize.InitializeWindowsAppSDK();
		GlobalVtableLookup.InitializeGlobalVtableLookup();
	}
}
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
namespace WinRT.SmartInput_WinUIGenericHelpers
{
	internal static class GlobalVtableLookup
	{
		[ModuleInitializer]
		internal static void InitializeGlobalVtableLookup()
		{
			ComWrappersSupport.RegisterTypeComInterfaceEntriesLookup(LookupVtableEntries);
			ComWrappersSupport.RegisterTypeRuntimeClassNameLookup(LookupRuntimeClassName);
		}

		private static ComWrappers.ComInterfaceEntry[] LookupVtableEntries(System.Type type)
		{
			switch (type.ToString())
			{
			case "SmartInput.App.Services.Translation.UnavailableTranslationFeature":
			case "SmartInput.App.Services.Translation.TranslationFeature":
			case "SmartInput.App.Services.Updates.ManifestUpdateService":
			case "System.Threading.Tasks.Task":
			case "System.Threading.Tasks.Task`1[Microsoft.UI.Xaml.Controls.ContentDialogResult]":
				return new ComWrappers.ComInterfaceEntry[1]
				{
					new ComWrappers.ComInterfaceEntry
					{
						IID = IDisposableMethods.IID,
						Vtable = IDisposableMethods.AbiToProjectionVftablePtr
					}
				};
			default:
				return null;
			}
		}

		private static string LookupRuntimeClassName(System.Type type)
		{
			switch (type.ToString())
			{
			case "SmartInput.App.Services.Translation.UnavailableTranslationFeature":
			case "SmartInput.App.Services.Translation.TranslationFeature":
			case "SmartInput.App.Services.Updates.ManifestUpdateService":
			case "System.Threading.Tasks.Task":
			case "System.Threading.Tasks.Task`1[Microsoft.UI.Xaml.Controls.ContentDialogResult]":
				return "Windows.Foundation.IClosable";
			default:
				return null;
			}
		}
	}
}
namespace WinRT.SmartInput_WinUIVtableClasses
{
	internal sealed class SmartInput_WinUI_Services_TypingSessionWinRTTypeDetails : IWinRTExposedTypeDetails
	{
		public ComWrappers.ComInterfaceEntry[] GetExposedInterfaces()
		{
			return new ComWrappers.ComInterfaceEntry[1]
			{
				new ComWrappers.ComInterfaceEntry
				{
					IID = IDisposableMethods.IID,
					Vtable = IDisposableMethods.AbiToProjectionVftablePtr
				}
			};
		}
	}
	internal sealed class SmartInput_WinUI_SmartInput_WinUI_XamlTypeInfo_XamlMemberWinRTTypeDetails : IWinRTExposedTypeDetails
	{
		public ComWrappers.ComInterfaceEntry[] GetExposedInterfaces()
		{
			return new ComWrappers.ComInterfaceEntry[1]
			{
				new ComWrappers.ComInterfaceEntry
				{
					IID = IXamlMemberMethods.IID,
					Vtable = IXamlMemberMethods.AbiToProjectionVftablePtr
				}
			};
		}
	}
	internal sealed class SmartInput_WinUI_AppWinRTTypeDetails : IWinRTExposedTypeDetails
	{
		public ComWrappers.ComInterfaceEntry[] GetExposedInterfaces()
		{
			return new ComWrappers.ComInterfaceEntry[2]
			{
				new ComWrappers.ComInterfaceEntry
				{
					IID = IApplicationOverridesMethods.IID,
					Vtable = IApplicationOverridesMethods.AbiToProjectionVftablePtr
				},
				new ComWrappers.ComInterfaceEntry
				{
					IID = IXamlMetadataProviderMethods.IID,
					Vtable = IXamlMetadataProviderMethods.AbiToProjectionVftablePtr
				}
			};
		}
	}
	internal sealed class SmartInput_WinUI_SmartInput_WinUI_XamlTypeInfo_XamlMetaDataProviderWinRTTypeDetails : IWinRTExposedTypeDetails
	{
		public ComWrappers.ComInterfaceEntry[] GetExposedInterfaces()
		{
			return new ComWrappers.ComInterfaceEntry[1]
			{
				new ComWrappers.ComInterfaceEntry
				{
					IID = IXamlMetadataProviderMethods.IID,
					Vtable = IXamlMetadataProviderMethods.AbiToProjectionVftablePtr
				}
			};
		}
	}
	internal sealed class SmartInput_WinUI_SmartInput_WinUI_XamlTypeInfo_XamlSystemBaseTypeWinRTTypeDetails : IWinRTExposedTypeDetails
	{
		public ComWrappers.ComInterfaceEntry[] GetExposedInterfaces()
		{
			return new ComWrappers.ComInterfaceEntry[1]
			{
				new ComWrappers.ComInterfaceEntry
				{
					IID = IXamlTypeMethods.IID,
					Vtable = IXamlTypeMethods.AbiToProjectionVftablePtr
				}
			};
		}
	}
}
namespace Microsoft.Windows.ApplicationModel.WindowsAppRuntime.Common
{
	internal class AutoInitialize
	{
		[ModuleInitializer]
		internal static void InitializeWindowsAppSDK()
		{
			Microsoft.Windows.Foundation.UndockedRegFreeWinRTCS.AutoInitialize.AccessWindowsAppSDK();
		}
	}
}
namespace Microsoft.Windows.Foundation.UndockedRegFreeWinRTCS
{
	internal static class NativeMethods
	{
		[DllImport("Microsoft.WindowsAppRuntime.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
		internal static extern int WindowsAppRuntime_EnsureIsLoaded();
	}
	internal class AutoInitialize
	{
		internal static void AccessWindowsAppSDK()
		{
			Environment.SetEnvironmentVariable("MICROSOFT_WINDOWSAPPRUNTIME_BASE_DIRECTORY", AppContext.BaseDirectory);
			Environment.SetEnvironmentVariable("MICROSOFT_WINDOWSAPPRUNTIME_BASE_DIRECTORY_PID", Environment.ProcessId.ToString(CultureInfo.InvariantCulture));
			NativeMethods.WindowsAppRuntime_EnsureIsLoaded();
		}
	}
}
namespace SmartInput.WinUI
{
	[WinRTRuntimeClassName("Microsoft.UI.Xaml.IApplicationOverrides")]
	[WinRTExposedType(typeof(SmartInput_WinUI_AppWinRTTypeDetails))]
	public class App : Microsoft.UI.Xaml.Application, IXamlMetadataProvider
	{
		private static readonly string Informational = typeof(App).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "unknown";

		private MainWindow? _window;

		private TypingSession? _session;

		private TrayIconController? _tray;

		private Mutex? _mutex;

		private string? _verification;

		private const int MaximumContinuedWindowFaults = 3;

		private int _continuedWindowFaults;

		private int _recordedWinFormsFaults;

		private bool _launched;

		private EventWaitHandle? _exitRequest;

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		private bool _contentLoaded;

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		private XamlMetaDataProvider __appProvider;

		public static string Version { get; } = Informational.Split('+')[0];

		public static string Commit { get; } = Informational.Contains('+') ? Informational.Substring(Informational.IndexOf('+') + 1) : "unknown";

		public static string VersionAndBuild { get; } = (Commit == "unknown") ? Version : (Version + " (build " + Commit.Substring(0, Math.Min(12, Commit.Length)) + ")");

		public static string? ReleaseDate { get; } = FormatReleaseDate(typeof(App).Assembly.GetCustomAttributes(typeof(AssemblyMetadataAttribute), inherit: false).OfType<AssemblyMetadataAttribute>().FirstOrDefault((AssemblyMetadataAttribute a) => a.Key == "DiyarReleaseDate")?.Value);

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		[DebuggerNonUserCode]
		private XamlMetaDataProvider _AppProvider
		{
			get
			{
				if (__appProvider == null)
				{
					__appProvider = new XamlMetaDataProvider();
				}
				return __appProvider;
			}
		}

		private static string? FormatReleaseDate(string? stamped)
		{
			if (!string.IsNullOrWhiteSpace(stamped))
			{
				if (!DateOnly.TryParseExact(stamped, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
				{
					return stamped;
				}
				return $"{result.Day} {result.ToString("MMMM", CultureInfo.InvariantCulture)} {result.Year}";
			}
			return null;
		}

		public App()
		{
			CrashRecorder.Configure(CrashRecorder.DefaultDirectory, new CrashContext(Version, Commit, "", "unknown", RuntimeInformation.OSDescription, RuntimeInformation.FrameworkDescription, System.DateTimeOffset.Now, IsVerification: false, Environment.GetCommandLineArgs().Contains("--startup")));
			AppDomain.CurrentDomain.UnhandledException += (object _, System.UnhandledExceptionEventArgs e) =>
			{
				CrashRecorder.Record("appdomain", e.ExceptionObject as System.Exception, e.IsTerminating);
			};
			TaskScheduler.UnobservedTaskException += (object? _, UnobservedTaskExceptionEventArgs e) =>
			{
				FaultRing.Note(FaultSite.Task, e.Exception);
			};
			UnhandledException += OnWindowException;
			InitializeComponent();
		}

		private void OnWindowException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
		{
			System.Exception exception = e.Exception;
			if (_launched)
			{
				MainWindow window = _window;
				if ((object)window != null && !window.ExitRequested && exception != null && !IsFatal(exception) && Interlocked.Increment(ref _continuedWindowFaults) <= 3)
				{
					e.Handled = true;
					FaultRing.Note(FaultSite.Ui, exception);
					CrashRecorder.RecordFault("xaml", exception);
					try
					{
						_window?.Notice(UiText.Get(UiKey.WindowErrorTypingContinues), InfoBarSeverity.Warning);
						return;
					}
					catch (System.Exception exception2)
					{
						FaultRing.Note(FaultSite.Ui, exception2);
						return;
					}
				}
			}
			CrashRecorder.Record("xaml", exception);
		}

		private void OnWinFormsException(object sender, ThreadExceptionEventArgs e)
		{
			FaultRing.Note(FaultSite.WinForms, e.Exception);
			if (IsFatal(e.Exception))
			{
				CrashRecorder.Record("winforms", e.Exception);
				Environment.FailFast("Diyar.WinFormsCorruptedState", e.Exception);
			}
			else if (Interlocked.Increment(ref _recordedWinFormsFaults) <= 3)
			{
				CrashRecorder.RecordFault("winforms", e.Exception);
			}
		}

		private static bool IsFatal(System.Exception exception)
		{
			if (exception is OutOfMemoryException || exception is AccessViolationException || exception is StackOverflowException || exception is InvalidProgramException || exception is BadImageFormatException || exception is TypeLoadException || exception is SEHException)
			{
				return true;
			}
			return false;
		}

		protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
		{
			System.Windows.Forms.Application.ThreadException += OnWinFormsException;
			try
			{
				string[] commandLineArgs = Environment.GetCommandLineArgs();
				int num = Array.IndexOf(commandLineArgs, "--seed-profile");
				if (num >= 0 && num + 1 < commandLineArgs.Length)
				{
					SeedProfile(commandLineArgs[num + 1], commandLineArgs);
					Exit();
					return;
				}
				int num2 = Array.IndexOf(commandLineArgs, "--verify");
				string text = (_verification = ((num2 >= 0 && num2 + 1 < commandLineArgs.Length) ? System.IO.Path.GetFullPath(commandLineArgs[num2 + 1]) : null));
				if (text == null)
				{
					TextCatalog.Language = new AppSettingsStore().PeekUiLanguage();
					_mutex = new Mutex(initiallyOwned: true, "Local\\SmartInput.App.SingleInstance", out var createdNew);
					if (!createdNew)
					{
						ShowBox(UiText.Get(UiKey.AlreadyRunning), "Diyar");
						Exit();
						return;
					}
				}
				_session = new TypingSession((text == null) ? null : System.IO.Path.Combine(text, "profile"));
				_window = new MainWindow(_session);
				_window.Exiting += () =>
				{
					ExitStep(() =>
					{
						_window.Shortcuts?.Dispose();
					});
					ExitStep(() =>
					{
						_tray?.Dispose();
					});
					ExitStep(() =>
					{
						_session.Dispose();
					});
					ExitStep(() =>
					{
						_mutex?.Dispose();
					});
					_session.MarkCleanExit();
					if (_window.RestartRequested)
					{
						string processPath = Environment.ProcessPath;
						if (processPath != null)
						{
							ExitStep(() =>
							{
								Process.Start(new ProcessStartInfo(processPath)
								{
									UseShellExecute = false
								})?.Dispose();
							});
						}
					}
					Exit();
				};
				if (text != null)
				{
					_window.Activate();
					Verification.VerifyAsync(_window, text);
					return;
				}
				_tray = new TrayIconController(_window.Open, () =>
				{
					_window.Open();
					_window.Navigate("settings");
					_window.ShowSettings(0);
					_window.CheckUpdatesAsync();
				}, _window.ExitApp, TextCatalog.Language, () =>
				{
					_window.Open();
					_window.Navigate("settings");
					_window.ShowSettings(0);
					_window.ShowPendingUpdate();
				}, _window.TogglePause);
				_tray.SetPaused(!_session.Settings.General.Enabled);
				_session.Changed += () =>
				{
					_window.DispatcherQueue.TryEnqueue(() =>
					{
						_tray?.SetPaused(!_session.Settings.General.Enabled);
					});
				};
				_window.LanguageChanged += (UiLanguage language) =>
				{
					_tray?.SetLanguage(language);
				};
				EndSessionHandler.RegisterApplicationRestart("--startup");
				_window.Shortcuts = new ShortcutHost(_session, (string message3) =>
				{
					_window.Notice(message3);
					_tray.ShowShortcutNotice(message3);
				}, _window.DispatcherQueue);
				_session.ShortcutNotice += (string message3) =>
				{
					_window.Notice(message3);
					_tray.ShowShortcutNotice(message3);
				};
				string translating = null;
				_session.TranslationRuns.RunningChanged += (TranslationRun? run) =>
				{
					if (run == null)
					{
						if (translating != null)
						{
							_window.CloseNotice(translating);
						}
						translating = null;
					}
					else
					{
						string text2 = ShortcutHost.Values(_session.Settings.Hotkeys)[run.Command];
						translating = UiText.Format(UiKey.TranslatingPressAgainToCancel, text2);
						_window.Notice(translating, InfoBarSeverity.Informational, UiText.Get(UiKey.CancelOperation), () =>
						{
							_session.CancelTranslation();
						});
						_tray.ShowShortcutNotice(translating);
					}
				};
				if (!_window.Shortcuts.Register(_session.Settings.Hotkeys, out string error))
				{
					_window.Notice(error, InfoBarSeverity.Warning);
				}
				_exitRequest = new EventWaitHandle(initialState: false, EventResetMode.AutoReset, $"Local\\SmartInput.App.Exit.{Environment.ProcessId}");
				ThreadPool.RegisterWaitForSingleObject(_exitRequest, (object? _, bool _) =>
				{
					_window.DispatcherQueue.TryEnqueue(() =>
					{
						_window.ExitApp();
					});
				}, null, -1, executeOnlyOnce: true);
				_session.Start();
				_session.BeginSessionMarker();
				string settingsProblem = _session.SettingsProblem;
				if (settingsProblem != null && settingsProblem.Length > 0)
				{
					_window.Notice(settingsProblem, InfoBarSeverity.Warning);
					_tray.ShowShortcutNotice(settingsProblem);
				}
				string textServiceProblem = _session.TextServiceProblem;
				if (textServiceProblem != null && textServiceProblem.Length > 0)
				{
					_window.Notice(textServiceProblem, InfoBarSeverity.Warning);
					_tray.ShowShortcutNotice(textServiceProblem);
				}
				UpdateOutcome updateOutcome = _session.UpdateOutcome;
				if (!commandLineArgs.Contains("--startup") || updateOutcome.ShowsWindow(System.DateTimeOffset.UtcNow))
				{
					_window.Activate();
				}
				else
				{
					_window.AppWindow.Hide();
				}
				_session.LogLaunch(commandLineArgs, _window.AppWindow.IsVisible);
				_session.UpdateInstall.WindowVisible = () => _window.AppWindow.IsVisible;
				(SessionOutcome, SessionMarker)? unexpectedPreviousSession = _session.UnexpectedPreviousSession;
				if (unexpectedPreviousSession.HasValue)
				{
					string message = UiText.Get((unexpectedPreviousSession.GetValueOrDefault().Item1 == SessionOutcome.CrashedWithRecord) ? UiKey.ClosedUnexpectedly : UiKey.ClosedWithoutRecord);
					_window.Notice(message, InfoBarSeverity.Warning, UiText.Get(UiKey.OpenCrashFolder), () =>
					{
						OpenFolder(_session.CrashDirectory);
					});
					if (!_window.AppWindow.IsVisible)
					{
						_tray.ShowShortcutNotice(message);
					}
					_session.MarkPreviousSessionNoticed();
				}
				ShowUpdateOutcome(updateOutcome);
				if (updateOutcome.Kind == UpdateOutcomeKind.InProgress)
				{
					WaitForUpdateOutcomeAsync();
				}
				_launched = true;
				CrashTestTrigger.Arm(_window, _session);
				if (_session.Settings.General.CheckForUpdatesAutomatically)
				{
					CheckStartupUpdatesAsync();
				}
			}
			catch (System.Exception ex)
			{
				CrashRecorder.Record("startup", ex);
				DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(21, 4, out var shouldAppend);
				if (shouldAppend)
				{
					message2.AppendLiteral("Startup failed: ");
					message2.AppendFormatted(ex.GetType().FullName);
					message2.AppendLiteral(" (0x");
					message2.AppendFormatted(ex.HResult, "X8");
					message2.AppendLiteral(")");
					message2.AppendFormatted(Environment.NewLine);
					message2.AppendFormatted(ex.StackTrace);
				}
				DiagnosticLog.Write("Session", ref message2);
				_window?.Shortcuts?.Dispose();
				_tray?.Dispose();
				_session?.Dispose();
				_mutex?.Dispose();
				if (_verification != null)
				{
					Directory.CreateDirectory(_verification);
					File.WriteAllText(System.IO.Path.Combine(_verification, "verification-error.txt"), ex.ToString());
				}
				else
				{
					ShowBox(TextCatalog.IsPersian ? (ex.Message + "\u200e") : ex.Message, UiText.Get(UiKey.CouldNotStart));
				}
				Environment.ExitCode = 1;
				Exit();
			}
		}

		private static void ExitStep(Action step)
		{
			try
			{
				step();
			}
			catch (System.Exception exception)
			{
				FaultRing.Note(FaultSite.Exit, exception);
			}
		}

		private static void OpenFolder(string folder)
		{
			Directory.CreateDirectory(folder);
			Process.Start(new ProcessStartInfo("explorer.exe", "\"" + folder + "\"")
			{
				UseShellExecute = true
			});
		}

		private static void ShowBox(string text, string caption)
		{
			MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, TextCatalog.IsPersian ? (MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) : ((MessageBoxOptions)0));
		}

		private static void SeedProfile(string resultPath, string[] arguments)
		{
			string contents;
			if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SMARTINPUT_SETTINGS_DIRECTORY")))
			{
				contents = "{\"error\":\"SMARTINPUT_SETTINGS_DIRECTORY is required\"}";
			}
			else
			{
				AppSettingsStore appSettingsStore = new AppSettingsStore();
				AppSettings appSettings = appSettingsStore.Load();
				int num = Array.IndexOf(arguments, "--saves");
				if (num >= 0 && num + 1 < arguments.Length && bool.TryParse(arguments[num + 1], out var result))
				{
					appSettings = appSettings with
					{
						SelectedWord = appSettings.SelectedWord with
						{
							SaveToPersonalDictionary = result
						}
					};
				}
				appSettingsStore.Save(appSettings);
				AppSettings appSettings2 = new AppSettingsStore().Load();
				contents = JsonSerializer.Serialize(new
				{
					saveToPersonalDictionary = appSettings2.SelectedWord.SaveToPersonalDictionary,
					effectiveSaves = appSettings2.SavesSelectedWordCorrections,
					convert = appSettings2.Hotkeys.ToggleSelectedText,
					undo = appSettings2.Hotkeys.UndoManualCorrection,
					enabled = appSettings2.General.Enabled
				});
			}
			File.WriteAllText(resultPath, contents);
		}

		private void ShowUpdateOutcome(UpdateOutcome outcome)
		{
			if ((object)_window == null)
			{
				return;
			}
			string text = _window.ShowUpdateOutcome(outcome);
			if (text != null)
			{
				bool isVisible = _window.AppWindow.IsVisible;
				if (!isVisible)
				{
					_tray?.ShowShortcutNotice(text);
				}
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(27, 2, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Outcome shown kind=");
					message.AppendFormatted(outcome.Kind);
					message.AppendLiteral(" window=");
					message.AppendFormatted(isVisible ? "visible" : "hidden");
				}
				DiagnosticLog.Write("Updates", ref message);
			}
		}

		private async Task WaitForUpdateOutcomeAsync()
		{
			try
			{
				UpdateOutcome outcome = await _session.UpdateInstall.WaitForOutcomeAsync(System.TimeSpan.FromSeconds(2L), System.TimeSpan.FromMinutes(2L), CancellationToken.None);
				if (!outcome.IsSettled)
				{
					return;
				}
				_window?.DispatcherQueue.TryEnqueue(() =>
				{
					if ((object)_window != null && !_window.ExitRequested)
					{
						if (outcome.ShowsWindow(System.DateTimeOffset.UtcNow) && !_window.AppWindow.IsVisible)
						{
							_window.Open();
						}
						ShowUpdateOutcome(outcome);
					}
				});
			}
			catch (System.Exception ex)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(26, 2, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Outcome wait failed: ");
					message.AppendFormatted(ex.GetType().FullName);
					message.AppendLiteral(" (0x");
					message.AppendFormatted(ex.HResult, "X8");
					message.AppendLiteral(")");
				}
				DiagnosticLog.Write("Updates", ref message);
			}
		}

		private async Task CheckStartupUpdatesAsync()
		{
			try
			{
				UpdateCheckResult updateCheckResult = await _session.RunStartupUpdateCheckAsync();
				if ((object)updateCheckResult != null && updateCheckResult.Status == UpdateCheckStatus.UpdateAvailable)
				{
					UpdateRelease release = updateCheckResult.Release;
					if ((object)release != null)
					{
						_tray?.ShowUpdateAvailable(release.Version);
						_window?.ShowUpdateNotice(release);
					}
				}
			}
			catch (System.Exception ex)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(27, 2, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Startup check failed: ");
					message.AppendFormatted(ex.GetType().FullName);
					message.AppendLiteral(" (0x");
					message.AppendFormatted(ex.HResult, "X8");
					message.AppendLiteral(")");
				}
				DiagnosticLog.Write("Updates", ref message);
			}
		}

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!_contentLoaded)
			{
				_contentLoaded = true;
				System.Uri resourceLocator = new System.Uri("ms-appx:///App.xaml");
				Microsoft.UI.Xaml.Application.LoadComponent(this, resourceLocator);
			}
		}

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		[DebuggerNonUserCode]
		public IXamlType GetXamlType(System.Type type)
		{
			return _AppProvider.GetXamlType(type);
		}

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		[DebuggerNonUserCode]
		public IXamlType GetXamlType(string fullName)
		{
			return _AppProvider.GetXamlType(fullName);
		}

		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		[DebuggerNonUserCode]
		public Microsoft.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
		{
			return _AppProvider.GetXmlnsDefinitions();
		}
	}
	internal sealed class MainWindow : Microsoft.UI.Xaml.Window
	{
		private NavigationView _navigation;

		private ContentControl _page;

		private InfoBar _notice;

		private TextBlock _title;

		private Microsoft.UI.Xaml.Controls.Button _power;

		private string _currentTag = "settings";

		private bool _dialogOpen;

		private bool _exit;

		private readonly EndSessionHandler _endSession;

		private static readonly UiKey[] CategoryNames = new UiKey[6]
		{
			UiKey.CategoryGeneral,
			UiKey.CategoryTechnical,
			UiKey.CategoryName,
			UiKey.CategoryAcronym,
			UiKey.CategoryCommand,
			UiKey.CategoryCurrency
		};

		private bool _reviewMode;

		private bool _builtInMode;

		private Action? _refreshDictionary;

		private const string ContainerStyle = "<Style xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" TargetType=\"ListViewItem\" BasedOn=\"{StaticResource DefaultListViewItemStyle}\">\r\n  <Setter Property=\"HorizontalContentAlignment\" Value=\"Stretch\"/>\r\n  <Setter Property=\"MinHeight\" Value=\"48\"/>\r\n  <Setter Property=\"Padding\" Value=\"8,4\"/>\r\n</Style>";

		private const string RowTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n  <Grid ColumnSpacing=\"16\" Padding=\"12,4,8,4\">\r\n    <Grid.ColumnDefinitions><ColumnDefinition Width=\"3*\"/><ColumnDefinition Width=\"2*\"/><ColumnDefinition Width=\"*\"/><ColumnDefinition Width=\"2*\"/></Grid.ColumnDefinitions>\r\n    <TextBlock Text=\"{Binding Word}\" FontFamily=\"{Binding Font}\" FlowDirection=\"{Binding Direction}\" HorizontalAlignment=\"Left\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\"/>\r\n    <TextBlock Grid.Column=\"1\" Text=\"{Binding Detail}\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\"/>\r\n    <TextBlock Grid.Column=\"2\" Text=\"{Binding Source}\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\" Foreground=\"{ThemeResource TextFillColorSecondaryBrush}\"/>\r\n    <TextBlock Grid.Column=\"3\" Text=\"{Binding Status}\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\" Foreground=\"{ThemeResource TextFillColorSecondaryBrush}\"/>\r\n  </Grid>\r\n</DataTemplate>";

		private int _settingsTab;

		private SelectorBar? _settingsSelector;

		private ContentControl? _settingsContent;

		internal static readonly string[] SettingsTabs = new string[5] { "general", "typing", "translation", "fonts", "shortcuts" };

		private static readonly UiKey[] SettingsTabNames = new UiKey[5]
		{
			UiKey.TabGeneral,
			UiKey.TabTyping,
			UiKey.TabTranslation,
			UiKey.TabFonts,
			UiKey.TabShortcuts
		};

		private StackPanel? _updatePanel;

		private UpdateRunState? _updatePanelState;

		private Microsoft.UI.Xaml.Controls.ProgressBar? _downloadBar;

		private TextBlock? _downloadText;

		private const string SupportUrl = "https://diyar.digital/";

		private const string SupportSite = "diyar.digital";

		private const string PublisherUrl = "https://webpack.site/";

		private const string PublisherSite = "webpack.site";

		private const string DeveloperUrl = "https://www.iranux.site/";

		private const string DeveloperSite = "www.iranux.site";

		private const string DonationUrl = "https://nowpayments.io/donation/iranux";

		private static readonly (TypingMode Mode, UiKey Label, UiKey Description)[] PrimaryModes = new (TypingMode, UiKey, UiKey)[2]
		{
			(TypingMode.AutomaticCorrection, UiKey.ModeAutomaticCorrection, UiKey.ModeAutomaticCorrectionDescription),
			(TypingMode.ManualCorrection, UiKey.ModePersianTypingDirect, UiKey.ModePersianTypingDirectDescription)
		};

		private static readonly (TypingMode Mode, UiKey Label, UiKey Description)[] OtherModes = new (TypingMode, UiKey, UiKey)[2]
		{
			(TypingMode.CapsLockSwitch, UiKey.ModeCapsLockSwitch, UiKey.ModeCapsLockSwitchDescription),
			(TypingMode.ShiftLanguageSwitch, UiKey.ModeShiftSwitch, UiKey.ModeShiftSwitchDescription)
		};

		private static readonly (EnglishOnlyPlaceGroup Group, UiKey Title)[] ApplicationGroups = new (EnglishOnlyPlaceGroup, UiKey)[5]
		{
			(EnglishOnlyPlaceGroup.Terminal, UiKey.EnglishOnlyTerminals),
			(EnglishOnlyPlaceGroup.Launcher, UiKey.EnglishOnlyLaunchers),
			(EnglishOnlyPlaceGroup.DatabaseTool, UiKey.EnglishOnlyDatabaseTools),
			(EnglishOnlyPlaceGroup.RemoteDesktop, UiKey.EnglishOnlyRemoteDesktops),
			(EnglishOnlyPlaceGroup.PasswordManager, UiKey.EnglishOnlyPasswordManagers)
		};

		private static readonly AmbiguousInputPriority[] PriorityValues = new AmbiguousInputPriority[4]
		{
			AmbiguousInputPriority.Normal,
			AmbiguousInputPriority.Contextual,
			AmbiguousInputPriority.Persian,
			AmbiguousInputPriority.English
		};

		private static readonly (UiKey Label, UiKey Description)[] PriorityOptions_ = new (UiKey, UiKey)[4]
		{
			(UiKey.PriorityNormal, UiKey.PriorityNormalDescription),
			(UiKey.PriorityContextual, UiKey.PriorityContextualDescription),
			(UiKey.LanguagePersian, UiKey.PriorityPersianDescription),
			(UiKey.LanguageEnglish, UiKey.PriorityEnglishDescription)
		};

		private const string PersianCommaChord = "Shift+7";

		private static readonly WordFormRecognition[] WordFormValues = new WordFormRecognition[3]
		{
			WordFormRecognition.Full,
			WordFormRecognition.Enclitics,
			WordFormRecognition.Off
		};

		private static readonly (UiKey Label, UiKey Description)[] WordFormOptions_ = new (UiKey, UiKey)[3]
		{
			(UiKey.WordFormsFull, UiKey.WordFormsFullDescription),
			(UiKey.WordFormsEnclitics, UiKey.WordFormsEncliticsDescription),
			(UiKey.Off, UiKey.WordFormsOffDescription)
		};

		internal new static MainWindow? Current { get; private set; }

		internal TypingSession Session { get; }

		internal ShortcutHost? Shortcuts { get; set; }

		internal Grid Root { get; } = (Grid)Microsoft.UI.Xaml.Markup.XamlReader.Load("<Grid xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' Background='{ThemeResource ApplicationPageBackgroundThemeBrush}'/>");

		internal ContentDialog? ActiveDialog { get; private set; }

		internal Microsoft.UI.Xaml.Controls.Button PowerButton => _power;

		internal bool ExitRequested => _exit;

		internal bool RestartRequested { get; private set; }

		internal InfoBar NoticeBar => _notice;

		internal Microsoft.UI.Xaml.Controls.ListView? DictionaryList { get; private set; }

		internal CommandBar? DictionaryCommands { get; private set; }

		internal Microsoft.UI.Xaml.Controls.ComboBox? LanguageChoice { get; private set; }

		internal StackPanel? UpdatePanelElement => _updatePanel;

		internal IReadOnlyDictionary<HelpTopic, Microsoft.UI.Xaml.FrameworkElement> HelpSections { get; private set; } = new Dictionary<HelpTopic, Microsoft.UI.Xaml.FrameworkElement>();

		internal UiLanguage HelpLanguageShown { get; private set; }

		internal event Action? Exiting;

		internal event Action<UiLanguage>? LanguageChanged;

		public MainWindow(TypingSession session)
		{
			Current = this;
			Session = session;
			Title = "Diyar";
			AppWindow.Resize(new SizeInt32(1280, 820));
			string text = System.IO.Path.Combine(AppContext.BaseDirectory, "Assets", "Branding", "diyar.ico");
			if (File.Exists(text))
			{
				AppWindow.SetIcon(text);
			}
			Content = Root;
			BuildShell();
			Session.Changed += SessionChanged;
			Session.PauseToggled += PauseToggled;
			Session.UpdateInstall.StatusChanged += UpdateStatusChanged;
			AppWindow.Closing += (AppWindow _, AppWindowClosingEventArgs e) =>
			{
				if (!_exit && !Session.IsVerification)
				{
					e.Cancel = true;
					AppWindow.Hide();
				}
			};
			Closed += (object _, Microsoft.UI.Xaml.WindowEventArgs _) =>
			{
				Session.Changed -= SessionChanged;
				Session.PauseToggled -= PauseToggled;
				Session.UpdateInstall.StatusChanged -= UpdateStatusChanged;
				Exiting?.Invoke();
				Current = null;
			};
			_endSession = new EndSessionHandler(WindowNative.GetWindowHandle(this), (bool _) =>
			{
				ExitApp();
			});
		}

		internal void ApplyLanguage(UiLanguage language)
		{
			if (Session.Settings.General.UiLanguage != language)
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						UiLanguage = language
					}
				});
			}
			BuildShell();
			LanguageChanged?.Invoke(TextCatalog.Language);
		}

		[MemberNotNull(new string[] { "_navigation", "_page", "_notice", "_title", "_power" })]
		private void BuildShell()
		{
			Ui.ApplyLanguageResources(TextCatalog.Language);
			Root.FlowDirection = Ui.Direction;
			_navigation = new NavigationView
			{
				IsBackButtonVisible = NavigationViewBackButtonVisible.Collapsed,
				IsSettingsVisible = false,
				PaneDisplayMode = NavigationViewPaneDisplayMode.Auto,
				OpenPaneLength = 224.0,
				ExpandedModeThresholdWidth = 1000.0,
				CompactModeThresholdWidth = 680.0
			};
			_page = new ContentControl
			{
				HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
				VerticalContentAlignment = VerticalAlignment.Stretch
			};
			_notice = Ui.Localize(new InfoBar
			{
				IsClosable = true,
				Margin = new Microsoft.UI.Xaml.Thickness(0.0, 0.0, 0.0, 16.0)
			});
			_title = Ui.Localize(new TextBlock
			{
				Style = Ui.Style("CocoPageTitle")
			}, strong: true);
			Root.Children.Clear();
			Root.Children.Add(_navigation);
			AddNavigation(UiKey.NavSettings, "settings", new SymbolIcon(Symbol.Setting));
			AddNavigation(UiKey.NavDictionary, "dictionary", new SymbolIcon(Symbol.Library));
			AddNavigation(UiKey.NavHelp, "help", new FontIcon
			{
				Glyph = char.ConvertFromUtf32(57627),
				MirroredWhenRightToLeft = Ui.Persian
			});
			AddNavigation(UiKey.NavAbout, "about", new SymbolIcon(Symbol.ContactInfo));
			_power = Ui.Button(UiText.Get(UiKey.PauseTypingAssistant), () =>
			{
				Session.TogglePause();
				return Task.CompletedTask;
			});
			_power.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch;
			_power.Margin = new Microsoft.UI.Xaml.Thickness(12.0, 8.0, 12.0, 20.0);
			_navigation.PaneFooter = _power;
			_navigation.DisplayModeChanged += (NavigationView _, NavigationViewDisplayModeChangedEventArgs _) =>
			{
				UpdatePower();
			};
			_navigation.PaneOpened += (NavigationView _, object _) =>
			{
				UpdatePower();
			};
			_navigation.PaneClosed += (NavigationView _, object _) =>
			{
				UpdatePower();
			};
			_navigation.SizeChanged += (object _, Microsoft.UI.Xaml.SizeChangedEventArgs _) =>
			{
				UpdatePower();
			};
			Grid grid = new Grid
			{
				Padding = new Microsoft.UI.Xaml.Thickness(32.0, 24.0, 24.0, 16.0),
				RowSpacing = 0.0
			};
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = Microsoft.UI.Xaml.GridLength.Auto
			});
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = Microsoft.UI.Xaml.GridLength.Auto
			});
			grid.RowDefinitions.Add(new RowDefinition());
			grid.Children.Add(_title);
			grid.Children.Add(_notice);
			grid.Children.Add(_page);
			Grid.SetRow(_notice, 1);
			Grid.SetRow(_page, 2);
			_navigation.Content = grid;
			_navigation.SelectionChanged += (NavigationView _, NavigationViewSelectionChangedEventArgs e) =>
			{
				if (e.SelectedItem is NavigationViewItem navigationViewItem)
				{
					Navigate((string)navigationViewItem.Tag);
				}
			};
			SessionChanged();
			_navigation.SelectedItem = _navigation.MenuItems.OfType<NavigationViewItem>().FirstOrDefault((NavigationViewItem x) => object.Equals(x.Tag, _currentTag)) ?? _navigation.MenuItems[0];
		}

		internal bool RequestCloseApp()
		{
			return _endSession.RequestCloseApp();
		}

		private void AddNavigation(UiKey label, string tag, IconElement icon)
		{
			_navigation.MenuItems.Add(Ui.Localize(Ui.Named(new NavigationViewItem
			{
				Content = UiText.Get(label),
				Tag = tag,
				Icon = icon
			}, UiText.Get(label))));
		}

		internal void Navigate(string tag)
		{
			NavigationViewItem navigationViewItem = _navigation.MenuItems.OfType<NavigationViewItem>().FirstOrDefault((NavigationViewItem x) => object.Equals(x.Tag, tag));
			if ((object)navigationViewItem != null && navigationViewItem != _navigation.SelectedItem)
			{
				_navigation.SelectedItem = navigationViewItem;
				return;
			}
			_currentTag = tag;
			_notice.IsOpen = false;
			TextBlock title = _title;
			title.Text = UiText.Get(tag switch
			{
				"dictionary" => UiKey.NavDictionary, 
				"help" => UiKey.NavHelp, 
				"about" => UiKey.NavAbout, 
				_ => UiKey.NavSettings, 
			});
			ContentControl page = _page;
			page.Content = tag switch
			{
				"dictionary" => (object)DictionaryPage(), 
				"help" => HelpPage(Ui.Persian), 
				"about" => AboutPage(), 
				_ => SettingsPage(), 
			};
		}

		internal void Open()
		{
			AppWindow.Show();
			Activate();
		}

		internal void ExitApp()
		{
			_exit = true;
			Close();
		}

		internal void RestartApp()
		{
			RestartRequested = true;
			ExitApp();
		}

		private void SessionChanged()
		{
			DispatcherQueue.TryEnqueue(UpdatePower);
		}

		private void PauseToggled()
		{
			DispatcherQueue.TryEnqueue(() =>
			{
				if (_navigation.SelectedItem is NavigationViewItem { Tag: string tag } && tag == "settings")
				{
					ShowSettings(_settingsTab);
				}
			});
		}

		internal void TogglePause()
		{
			Session.TogglePause();
		}

		private void UpdatePower()
		{
			bool enabled = Session.Settings.General.Enabled;
			bool isPaneOpen = _navigation.IsPaneOpen;
			_power.Content = (isPaneOpen ? ((Microsoft.UI.Xaml.FrameworkElement)Ui.Actions(new SymbolIcon(enabled ? Symbol.Pause : Symbol.Play), Ui.Text(enabled ? UiKey.PowerActive : UiKey.PowerPaused))) : ((Microsoft.UI.Xaml.FrameworkElement)new SymbolIcon(enabled ? Symbol.Pause : Symbol.Play)));
			_power.Padding = new Microsoft.UI.Xaml.Thickness(isPaneOpen ? 20.0 : 8.0, 8.0, isPaneOpen ? 20.0 : 8.0, 8.0);
			_power.Margin = new Microsoft.UI.Xaml.Thickness(isPaneOpen ? 12.0 : 4.0, 8.0, isPaneOpen ? 12.0 : 4.0, 20.0);
			Ui.Named(_power, UiText.Get(enabled ? UiKey.PauseTypingAssistant : UiKey.ResumeTypingAssistant));
			ToolTipService.SetToolTip(_power, Ui.Tip(UiText.Get(enabled ? UiKey.PowerActiveTip : UiKey.PowerPausedTip)));
		}

		internal void Notice(string message, InfoBarSeverity severity = InfoBarSeverity.Informational, string? actionLabel = null, Action? action = null)
		{
			DispatcherQueue.TryEnqueue(() =>
			{
				_notice.Content = null;
				_notice.Message = message;
				_notice.Severity = severity;
				_notice.ActionButton = ((actionLabel != null && action != null) ? Ui.Button(actionLabel, () =>
				{
					action();
					return Task.CompletedTask;
				}) : null);
				_notice.IsOpen = true;
			});
		}

		internal void CloseNotice(string message)
		{
			DispatcherQueue.TryEnqueue(() =>
			{
				if (_notice.IsOpen && _notice.Message == message)
				{
					_notice.IsOpen = false;
					_notice.ActionButton = null;
				}
			});
		}

		internal void Notice(UiKey key, InfoBarSeverity severity = InfoBarSeverity.Informational, params object?[] values)
		{
			if (!Ui.Persian || values.Length == 0)
			{
				Notice(UiText.Format(key, values), severity);
				return;
			}
			DispatcherQueue.TryEnqueue(() =>
			{
				_notice.Message = string.Empty;
				_notice.Content = Ui.Rich(key, secondary: false, values);
				_notice.ActionButton = null;
				_notice.Severity = severity;
				_notice.IsOpen = true;
			});
		}

		internal void NoticeWithAction(UiKey key, InfoBarSeverity severity, string actionLabel, Action action, params object?[] values)
		{
			DispatcherQueue.TryEnqueue(() =>
			{
				if (Ui.Persian && values.Length != 0)
				{
					_notice.Message = string.Empty;
					_notice.Content = Ui.Rich(key, secondary: false, values);
				}
				else
				{
					_notice.Content = null;
					_notice.Message = UiText.Format(key, values);
				}
				_notice.ActionButton = Ui.Button(actionLabel, () =>
				{
					action();
					return Task.CompletedTask;
				});
				_notice.Severity = severity;
				_notice.IsOpen = true;
			});
		}

		internal async Task<ContentDialogResult> Dialog(string title, Microsoft.UI.Xaml.UIElement content, string? primary = null, string? close = null)
		{
			if (_dialogOpen)
			{
				return ContentDialogResult.None;
			}
			_dialogOpen = true;
			Shortcuts?.Suspend(value: true);
			try
			{
				ActiveDialog = Ui.Localize(new ContentDialog
				{
					XamlRoot = Root.XamlRoot,
					Title = title,
					Content = content,
					PrimaryButtonText = (primary ?? ""),
					CloseButtonText = (close ?? UiText.Get(UiKey.Cancel)),
					DefaultButton = ((primary != null) ? ContentDialogButton.Primary : ContentDialogButton.Close),
					RequestedTheme = Root.ActualTheme,
					FlowDirection = Root.FlowDirection
				});
				return await ActiveDialog.ShowAsync();
			}
			finally
			{
				ActiveDialog = null;
				_dialogOpen = false;
				Shortcuts?.Suspend(value: false);
			}
		}

		private Task<ContentDialogResult> Confirm(string title, string body, string action)
		{
			return Dialog(title, Ui.Text(body), action);
		}

		internal void ShowReview(bool review)
		{
			_reviewMode = review;
			_builtInMode = false;
			Navigate("dictionary");
		}

		internal void ShowDictionary(bool builtIn)
		{
			_reviewMode = false;
			_builtInMode = builtIn;
			Navigate("dictionary");
		}

		internal void ShowPersianHelp()
		{
			ShowHelp(persian: true);
		}

		internal void ShowHelp(bool persian)
		{
			Navigate("help");
			_page.Content = HelpPage(persian);
		}

		private static string LanguageName(EntryLanguage language)
		{
			return UiText.Get(language switch
			{
				EntryLanguage.Persian => UiKey.LanguagePersian, 
				EntryLanguage.English => UiKey.LanguageEnglish, 
				_ => UiKey.LanguageNeutral, 
			});
		}

		private Microsoft.UI.Xaml.UIElement DictionaryPage()
		{
			Grid root = new Grid
			{
				RowSpacing = 16.0
			};
			for (int i = 0; i < 5; i++)
			{
				root.RowDefinitions.Add(new RowDefinition
				{
					Height = ((i == 3) ? new Microsoft.UI.Xaml.GridLength(1.0, Microsoft.UI.Xaml.GridUnitType.Star) : Microsoft.UI.Xaml.GridLength.Auto)
				});
			}
			SelectorBar tabs = Ui.Named(new SelectorBar(), UiText.Get(UiKey.DictionaryViews));
			UiKey[] array = new UiKey[3]
			{
				UiKey.PersonalDictionary,
				UiKey.BuiltInDictionary,
				UiKey.WordReviewQueue
			};
			foreach (UiKey key in array)
			{
				tabs.Items.Add(Ui.Localize(new SelectorBarItem
				{
					Text = UiText.Get(key)
				}));
			}
			tabs.SelectedItem = tabs.Items[_reviewMode ? 2 : (_builtInMode ? 1 : 0)];
			tabs.SelectionChanged += (SelectorBar _, SelectorBarSelectionChangedEventArgs _) =>
			{
				_reviewMode = tabs.SelectedItem == tabs.Items[2];
				_builtInMode = tabs.SelectedItem == tabs.Items[1];
				_page.Content = DictionaryPage();
			};
			Row(tabs, 0);
			AutoSuggestBox search = Ui.Named(new AutoSuggestBox
			{
				PlaceholderText = UiText.Get(_reviewMode ? UiKey.SearchWordReviewQueue : (_builtInMode ? UiKey.SearchBuiltInDictionary : UiKey.SearchPersonalDictionary)),
				QueryIcon = new SymbolIcon(Symbol.Find),
				Height = 40.0,
				VerticalAlignment = VerticalAlignment.Center
			}, UiText.Get(UiKey.SearchDictionary));
			int pageIndex = 0;
			int pageCount = 1;
			EntryLanguage? language = null;
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice("", new <>z__ReadOnlyArray<string>(new string[3]
			{
				UiText.Get(UiKey.AllLanguages),
				UiText.Get(UiKey.LanguagePersian),
				UiText.Get(UiKey.LanguageEnglish)
			}), 0, (int index) =>
			{
				language = ((index == 0) ? ((EntryLanguage?)null) : new EntryLanguage?((EntryLanguage)(index - 1)));
				pageIndex = 0;
				_refreshDictionary?.Invoke();
			});
			Ui.Named(comboBox, UiText.Get(UiKey.FilterDictionaryLanguage));
			ToggleSwitch toggleSwitch = Ui.Toggle(UiText.Get(UiKey.AutoAddConfirmedCorrections), Session.Settings.Dictionary.AutoAddForcedConversions, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Dictionary = s.Dictionary with
					{
						AutoAddForcedConversions = value
					}
				});
			});
			Row(Ui.Pair(search, _reviewMode ? ((Microsoft.UI.Xaml.Controls.Control)toggleSwitch) : ((Microsoft.UI.Xaml.Controls.Control)comboBox)), 1);
			CommandBar commands = new CommandBar
			{
				DefaultLabelPosition = CommandBarDefaultLabelPosition.Right,
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
				IsDynamicOverflowEnabled = true
			};
			Row(commands, 2);
			DictionaryCommands = commands;
			Microsoft.UI.Xaml.Controls.ListView control = new Microsoft.UI.Xaml.Controls.ListView
			{
				SelectionMode = ListViewSelectionMode.Multiple,
				IsMultiSelectCheckBoxEnabled = true,
				HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
				ItemTemplate = (Microsoft.UI.Xaml.DataTemplate)Microsoft.UI.Xaml.Markup.XamlReader.Load("<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">\r\n  <Grid ColumnSpacing=\"16\" Padding=\"12,4,8,4\">\r\n    <Grid.ColumnDefinitions><ColumnDefinition Width=\"3*\"/><ColumnDefinition Width=\"2*\"/><ColumnDefinition Width=\"*\"/><ColumnDefinition Width=\"2*\"/></Grid.ColumnDefinitions>\r\n    <TextBlock Text=\"{Binding Word}\" FontFamily=\"{Binding Font}\" FlowDirection=\"{Binding Direction}\" HorizontalAlignment=\"Left\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\"/>\r\n    <TextBlock Grid.Column=\"1\" Text=\"{Binding Detail}\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\"/>\r\n    <TextBlock Grid.Column=\"2\" Text=\"{Binding Source}\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\" Foreground=\"{ThemeResource TextFillColorSecondaryBrush}\"/>\r\n    <TextBlock Grid.Column=\"3\" Text=\"{Binding Status}\" VerticalAlignment=\"Center\" TextTrimming=\"CharacterEllipsis\" Foreground=\"{ThemeResource TextFillColorSecondaryBrush}\"/>\r\n  </Grid>\r\n</DataTemplate>"),
				Padding = new Microsoft.UI.Xaml.Thickness(0.0),
				ItemContainerStyle = (Microsoft.UI.Xaml.Style)Microsoft.UI.Xaml.Markup.XamlReader.Load("<Style xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" TargetType=\"ListViewItem\" BasedOn=\"{StaticResource DefaultListViewItemStyle}\">\r\n  <Setter Property=\"HorizontalContentAlignment\" Value=\"Stretch\"/>\r\n  <Setter Property=\"MinHeight\" Value=\"48\"/>\r\n  <Setter Property=\"Padding\" Value=\"8,4\"/>\r\n</Style>")
			};
			UiKey key2;
			if (_reviewMode)
			{
				key2 = UiKey.WordReviewQueue;
			}
			else
			{
				key2 = (_builtInMode ? UiKey.BuiltInDictionaryWords : UiKey.PersonalDictionaryWords);
			}
			Microsoft.UI.Xaml.Controls.ListView list = Ui.Named(control, UiText.Get(key2));
			DictionaryList = list;
			Grid grid = new Grid();
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = Microsoft.UI.Xaml.GridLength.Auto
			});
			grid.RowDefinitions.Add(new RowDefinition());
			Grid grid2 = new Grid
			{
				ColumnSpacing = 16.0,
				Padding = new Microsoft.UI.Xaml.Thickness(48.0, 12.0, 16.0, 12.0)
			};
			int[] array2 = new int[4] { 3, 2, 1, 2 };
			foreach (int num in array2)
			{
				grid2.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = new Microsoft.UI.Xaml.GridLength(num, Microsoft.UI.Xaml.GridUnitType.Star)
				});
			}
			UiKey[] array3 = ((!_reviewMode) ? new UiKey[4]
			{
				UiKey.Word,
				UiKey.WordLanguage,
				UiKey.ColumnDictionary,
				_builtInMode ? UiKey.ColumnStatus : UiKey.ColumnStatusConversion
			} : new UiKey[4]
			{
				UiKey.ColumnProposedWord,
				UiKey.ColumnTypedAs,
				UiKey.WordLanguage,
				UiKey.ColumnAwaitingReview
			});
			for (int num2 = 0; num2 < array3.Length; num2++)
			{
				TextBlock textBlock = Ui.Text(array3[num2], secondary: true);
				grid2.Children.Add(textBlock);
				Grid.SetColumn(textBlock, num2);
			}
			grid.Children.Add(grid2);
			grid.Children.Add(list);
			Grid.SetRow(list, 1);
			TextBlock empty = Ui.Text(_reviewMode ? UiKey.NoWordsAwaitingReview : UiKey.NoMatchingWords, secondary: true);
			empty.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center;
			empty.VerticalAlignment = VerticalAlignment.Center;
			grid.Children.Add(empty);
			Grid.SetRow(empty, 1);
			Row(grid, 3);
			TextBlock count = Ui.Text("", secondary: true);
			TextBlock pageNumber = Ui.Text("", secondary: true);
			Microsoft.UI.Xaml.Controls.Button previous = Ui.Icon(UiText.Get(UiKey.PreviousPage), Symbol.Back, () =>
			{
				pageIndex--;
				_refreshDictionary?.Invoke();
				return Task.CompletedTask;
			}, 40.0, mirror: true);
			Microsoft.UI.Xaml.Controls.Button next = Ui.Icon(UiText.Get(UiKey.NextPage), Symbol.Forward, () =>
			{
				pageIndex++;
				_refreshDictionary?.Invoke();
				return Task.CompletedTask;
			}, 40.0, mirror: true);
			StackPanel stackPanel = Ui.Actions(previous, pageNumber, next);
			stackPanel.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Right;
			Row(Ui.Pair(count, stackPanel), 4);
			List<DictionaryRow> rows = new List<DictionaryRow>();
			int total = 0;
			AppBarButton edit = null;
			AppBarButton delete = null;
			AppBarButton addReview = null;
			if (!_builtInMode)
			{
				if (!_reviewMode)
				{
					Command(UiKey.AddWords, Symbol.Add, AddWordsAsync);
					Command(UiKey.Import, Symbol.OpenFile, ImportAsync);
					Command(UiKey.Export, Symbol.Save, async () =>
					{
						HashSet<Guid?> ids = (from x in Selected()
							select x.Id).ToHashSet();
						IReadOnlyList<SmartInput.Core.Dictionaries.DictionaryEntry> all = Session.Dictionary.GetAll();
						IReadOnlyList<SmartInput.Core.Dictionaries.DictionaryEntry> readOnlyList2;
						if (ids.Count != 0)
						{
							IReadOnlyList<SmartInput.Core.Dictionaries.DictionaryEntry> readOnlyList = all.Where((SmartInput.Core.Dictionaries.DictionaryEntry x) => ids.Contains(x.Id)).ToArray();
							readOnlyList2 = readOnlyList;
						}
						else
						{
							readOnlyList2 = all;
						}
						IReadOnlyList<SmartInput.Core.Dictionaries.DictionaryEntry> entries = readOnlyList2;
						if (entries.Count == 0)
						{
							Notice(UiText.Get(UiKey.NoPersonalWordsToExport));
						}
						else
						{
							FileSavePicker fileSavePicker = new FileSavePicker
							{
								SuggestedFileName = "Diyar-personal-dictionary",
								FileTypeChoices = 
								{
									{
										UiText.Get(UiKey.PersonalDictionaryFileType),
										(IList<string>)new List<string>(1) { ".json" }
									},
									{
										"CSV",
										(IList<string>)new List<string>(1) { ".csv" }
									}
								}
							};
							InitializeWithWindow.Initialize(fileSavePicker, WindowNative.GetWindowHandle(this));
							StorageFile storageFile = await fileSavePicker.PickSaveFileAsync();
							if ((object)storageFile != null)
							{
								int num3 = new DictionaryExportService().Export(storageFile.Path, entries);
								Notice(UiText.Format(UiKey.ExportedPersonalWords, UiText.Count(num3)), InfoBarSeverity.Success);
							}
						}
					});
				}
				else
				{
					addReview = Command(UiKey.AcceptSelected, Symbol.Accept, () => AcceptReviewAsync(from x in Selected()
						where x.Id.HasValue
						select x.Id.Value));
					Command(UiKey.AcceptAll, Symbol.Accept, async () =>
					{
						IReadOnlyList<ManualConversionCandidate> candidates = Session.Review.GetAll();
						if (candidates.Count != 0 && await ConfirmAcceptAllAsync(candidates.Count) == ContentDialogResult.Primary)
						{
							await AcceptReviewAsync(candidates.Select((ManualConversionCandidate x) => x.Id));
						}
					}, secondary: true);
				}
			}
			if (BlockedReason() != null)
			{
				Command(UiKey.RetryKeepingCopy, Symbol.Refresh, () =>
				{
					bool flag = (_reviewMode ? Session.Review.TryRetryPreservation() : Session.Dictionary.TryRetryPreservation());
					Notice(flag ? UiText.Get(UiKey.CopyKept) : (BlockedReason() ?? ""), flag ? InfoBarSeverity.Success : InfoBarSeverity.Error);
					return Task.CompletedTask;
				});
			}
			Command(UiKey.SelectPage, Symbol.SelectAll, () =>
			{
				list.SelectAll();
				return Task.CompletedTask;
			}, secondary: true, refresh: false);
			Command(UiKey.ClearSelection, Symbol.ClearSelection, () =>
			{
				list.SelectedItems.Clear();
				return Task.CompletedTask;
			}, secondary: true, refresh: false);
			Command(UiKey.DictionaryHelp, Symbol.Help, () => ShowHelpTopicAsync(HelpTopic.Dictionary), secondary: true, refresh: false);
			if (!_reviewMode && !_builtInMode)
			{
				edit = Command(UiKey.Edit, Symbol.Edit, async () =>
				{
					DictionaryRow[] selected = Selected();
					if (selected.Length == 1 && selected[0].Id.HasValue)
					{
						await EditWordAsync(Session.Dictionary.GetAll().First((SmartInput.Core.Dictionaries.DictionaryEntry x) =>
						{
							Guid id = x.Id;
							Guid? id2 = selected[0].Id;
							return id == id2;
						}));
					}
				});
			}
			if (!_builtInMode)
			{
				delete = Command(_reviewMode ? UiKey.Reject : UiKey.Delete, Symbol.Delete, async () =>
				{
					DictionaryRow[] selected = (from x in Selected()
						where x.Id.HasValue
						select x).ToArray();
					if (selected.Length != 0 && await ConfirmRemovalAsync(_reviewMode, selected.Length) == ContentDialogResult.Primary)
					{
						if (_reviewMode)
						{
							Session.Review.RemoveMany(selected.Select((DictionaryRow x) => x.Id.Value));
						}
						else
						{
							Session.Dictionary.RemoveMany(selected.Select((DictionaryRow x) => x.Id.Value));
						}
					}
				});
			}
			if (!_builtInMode)
			{
				Command(_reviewMode ? UiKey.RejectAll : UiKey.DeleteAllPersonalWords, Symbol.Delete, async () =>
				{
					if (await ConfirmAllAsync(_reviewMode) == ContentDialogResult.Primary)
					{
						if (_reviewMode)
						{
							Session.Review.Clear();
						}
						else
						{
							Session.Dictionary.Clear();
						}
					}
				}, secondary: true);
			}
			list.SelectionChanged += (object _, SelectionChangedEventArgs _) =>
			{
				SelectionChanged();
			};
			_refreshDictionary = Refresh;
			Microsoft.UI.Dispatching.DispatcherQueueTimer timer = DispatcherQueue.CreateTimer();
			timer.Interval = System.TimeSpan.FromMilliseconds(180L);
			timer.IsRepeating = false;
			timer.Tick += (Microsoft.UI.Dispatching.DispatcherQueueTimer _, object _) =>
			{
				pageIndex = 0;
				Refresh();
			};
			search.TextChanged += (AutoSuggestBox _, AutoSuggestBoxTextChangedEventArgs e) =>
			{
				if (e.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
				{
					timer.Stop();
					timer.Start();
				}
			};
			search.QuerySubmitted += (AutoSuggestBox _, AutoSuggestBoxQuerySubmittedEventArgs _) =>
			{
				timer.Stop();
				pageIndex = 0;
				Refresh();
			};
			root.Unloaded += (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
			{
				timer.Stop();
			};
			Refresh();
			string text = BlockedReason();
			if (text != null)
			{
				Notice(text, InfoBarSeverity.Error);
			}
			else if (_reviewMode && Session.Review.UnsavedReason != null)
			{
				Notice(UiText.Get(UiKey.UnsavedProposals), InfoBarSeverity.Warning);
			}
			else
			{
				string lastProblem = UnreadableFileBackup.LastProblem;
				if (lastProblem != null)
				{
					Notice(UiKey.NothingWasOverwritten, InfoBarSeverity.Warning, lastProblem);
				}
			}
			return root;
			string? BlockedReason()
			{
				if (!_builtInMode)
				{
					if (!_reviewMode)
					{
						return Session.Dictionary.WriteBlockedReason;
					}
					return Session.Review.WriteBlockedReason;
				}
				return null;
			}
			AppBarButton Command(UiKey key3, Symbol icon, Func<Task> action, bool secondary = false, bool refresh = true)
			{
				string text2 = UiText.Get(key3);
				IconElement icon2 = ((icon == Symbol.Help) ? ((IconElement)new FontIcon
				{
					Glyph = char.ConvertFromUtf32((int)icon),
					MirroredWhenRightToLeft = Ui.Persian
				}) : ((IconElement)new SymbolIcon(icon)));
				AppBarButton button = Ui.Localize(Ui.Named(new AppBarButton
				{
					Label = text2,
					Icon = icon2
				}, text2));
				button.Click += async (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
				{
					button.IsEnabled = false;
					try
					{
						await action();
					}
					catch (System.Exception ex)
					{
						Notice(ex.Message, InfoBarSeverity.Error);
					}
					finally
					{
						button.IsEnabled = true;
						if (refresh)
						{
							_refreshDictionary?.Invoke();
						}
						else
						{
							SelectionChanged();
						}
					}
				};
				if (secondary)
				{
					commands.SecondaryCommands.Add(button);
				}
				else
				{
					commands.PrimaryCommands.Add(button);
				}
				return button;
			}
			void Refresh()
			{
				if (_reviewMode)
				{
					IReadOnlyList<ManualConversionCandidate> all = Session.Review.GetAll(search.Text);
					total = all.Count;
					pageCount = Math.Max(1, (int)Math.Ceiling((double)total / 100.0));
					pageIndex = Math.Clamp(pageIndex, 0, pageCount - 1);
					rows = (from x in all.Skip(pageIndex * 100).Take(100)
						select new DictionaryRow(x.Id, x.PersianWord, x.TypedText, LanguageName(x.Language), x.Language == EntryLanguage.Persian, UiText.Format(UiKey.ReviewUses, UiText.Count(x.UseCount), UiText.Date(x.LastSeenUtc)))).ToList();
				}
				else
				{
					DictionaryCatalogPage dictionaryCatalogPage = Session.Dictionary.QueryCatalog(search.Text, language, pageIndex, 100, (!_builtInMode) ? DictionaryEntrySource.Personal : DictionaryEntrySource.BuiltIn);
					total = dictionaryCatalogPage.TotalCount;
					pageCount = dictionaryCatalogPage.PageCount;
					pageIndex = dictionaryCatalogPage.PageIndex;
					rows = dictionaryCatalogPage.Items.Select((DictionaryCatalogItem x) => new DictionaryRow(x.UserEntryId, x.Term, LanguageName(x.Language), UiText.Get(x.IsBuiltIn ? UiKey.SourceBuiltIn : UiKey.SourcePersonal), x.Language == EntryLanguage.Persian, x.IsBuiltIn ? UiText.Get(UiKey.StatusReadOnly) : (UiText.Get(x.AutoLearned ? UiKey.StatusAddedAutomatically : UiKey.StatusAccepted) + " · " + UiText.Get((!x.Enabled) ? UiKey.StatusDisabled : (x.PreventConversion ? UiKey.StatusProtected : UiKey.StatusAllowed))))).ToList();
				}
				list.ItemsSource = rows;
				empty.Visibility = ((rows.Count != 0) ? Visibility.Collapsed : Visibility.Visible);
				pageNumber.Text = $"{pageIndex + 1} / {pageCount}";
				previous.IsEnabled = pageIndex > 0;
				next.IsEnabled = pageIndex + 1 < pageCount;
				SelectionChanged();
			}
			void Row(Microsoft.UI.Xaml.FrameworkElement element, int row)
			{
				root.Children.Add(element);
				Grid.SetRow(element, row);
			}
			DictionaryRow[] Selected()
			{
				return list.SelectedItems.Cast<DictionaryRow>().ToArray();
			}
			void SelectionChanged()
			{
				DictionaryRow[] array4 = Selected();
				if ((object)edit != null)
				{
					edit.IsEnabled = array4.Length == 1 && array4[0].Id.HasValue;
				}
				if ((object)delete != null)
				{
					delete.IsEnabled = array4.Any((DictionaryRow x) => x.Id.HasValue);
				}
				if ((object)addReview != null)
				{
					addReview.IsEnabled = array4.Length != 0;
				}
				count.Text = ((array4.Length == 0) ? UiText.Format(UiKey.WordCount, UiText.Count(total)) : UiText.Format(UiKey.SelectedOnPage, UiText.Count(array4.Length), UiText.Count(total)));
			}
		}

		internal async Task AddWordsAsync()
		{
			Microsoft.UI.Xaml.Controls.TextBox words = Ui.Input(UiText.Get(UiKey.Words));
			words.AcceptsReturn = true;
			words.Height = 144.0;
			words.TextWrapping = TextWrapping.Wrap;
			words.VerticalContentAlignment = VerticalAlignment.Top;
			Microsoft.UI.Xaml.Controls.ComboBox lang = Ui.Choice(UiText.Get(UiKey.WordLanguage), new <>z__ReadOnlyArray<string>(new string[3]
			{
				UiText.Get(UiKey.DetectFromLetters),
				UiText.Get(UiKey.LanguagePersian),
				UiText.Get(UiKey.LanguageEnglish)
			}), 0, (int _) =>
			{
			});
			if (await Dialog(UiText.Get(UiKey.AddToPersonalDictionary), Ui.Stack(words, lang), UiText.Get(UiKey.AddWords)) != ContentDialogResult.Primary)
			{
				return;
			}
			string[] array = words.Text.Split(new char[6] { ' ', '\t', '\r', '\n', ',', ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
			EntryLanguage? chosen = ((lang.SelectedIndex == 0) ? ((EntryLanguage?)null) : new EntryLanguage?((EntryLanguage)(lang.SelectedIndex - 1)));
			DictionaryAddResult dictionaryAddResult = Session.Dictionary.AddTermsDetailed(array, chosen);
			EntryLanguage[] array2 = new EntryLanguage[2]
			{
				EntryLanguage.Persian,
				EntryLanguage.English
			};
			foreach (EntryLanguage language in array2)
			{
				if (chosen.HasValue && chosen != language)
				{
					continue;
				}
				Session.Review.RemoveWords(array.Where((string term) => chosen.HasValue || ((language != EntryLanguage.Persian) ? term.Any((char c) =>
				{
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
						return true;
					default:
						return false;
					}
				}) : term.Any((char c) => c >= '\u0600' && c <= 'ۿ'))), language);
			}
			Notice(dictionaryAddResult.Summary(), (dictionaryAddResult.RejectedCount <= 0) ? InfoBarSeverity.Success : InfoBarSeverity.Warning);
		}

		private Task AcceptReviewAsync(IEnumerable<Guid> ids)
		{
			ReviewAcceptanceResult reviewAcceptanceResult = ReviewAcceptance.Accept(Session.Dictionary, Session.Review, ids);
			Notice(reviewAcceptanceResult.Summary(), (!reviewAcceptanceResult.QueueUpdated) ? InfoBarSeverity.Warning : ((reviewAcceptanceResult.Rejected <= 0) ? InfoBarSeverity.Success : InfoBarSeverity.Warning));
			return Task.CompletedTask;
		}

		private async Task ImportAsync()
		{
			FileOpenPicker fileOpenPicker = new FileOpenPicker();
			string[] array = new string[3] { ".json", ".csv", ".txt" };
			foreach (string item in array)
			{
				fileOpenPicker.FileTypeFilter.Add(item);
			}
			InitializeWithWindow.Initialize(fileOpenPicker, WindowNative.GetWindowHandle(this));
			StorageFile storageFile = await fileOpenPicker.PickSingleFileAsync();
			if ((object)storageFile != null)
			{
				DictionaryImportResult dictionaryImportResult = new DictionaryImportService().Import(storageFile.Path, Session.Dictionary);
				Notice(UiText.Format(UiKey.ImportSummary, UiText.Count(dictionaryImportResult.AddedCount), UiText.Count(dictionaryImportResult.DuplicateCount - dictionaryImportResult.AlreadyBuiltInCount), UiText.Count(dictionaryImportResult.AlreadyBuiltInCount), UiText.Count(dictionaryImportResult.InvalidCount)), (dictionaryImportResult.InvalidCount <= 0) ? InfoBarSeverity.Success : InfoBarSeverity.Warning);
			}
		}

		internal async Task EditWordAsync(SmartInput.Core.Dictionaries.DictionaryEntry entry)
		{
			Microsoft.UI.Xaml.Controls.TextBox word = Ui.Input(UiText.Get(UiKey.Word), entry.Term);
			string label = UiText.Get(UiKey.WordLanguage);
			IEnumerable<string> values;
			if (entry.Language != EntryLanguage.Neutral)
			{
				IEnumerable<string> enumerable = new <>z__ReadOnlyArray<string>(new string[2]
				{
					UiText.Get(UiKey.LanguagePersian),
					UiText.Get(UiKey.LanguageEnglish)
				});
				values = enumerable;
			}
			else
			{
				IEnumerable<string> enumerable = new <>z__ReadOnlyArray<string>(new string[3]
				{
					UiText.Get(UiKey.LanguagePersian),
					UiText.Get(UiKey.LanguageEnglish),
					UiText.Get(UiKey.NeutralOlderEntry)
				});
				values = enumerable;
			}
			Microsoft.UI.Xaml.Controls.ComboBox lang = Ui.Choice(label, values, (int)entry.Language, (int _) =>
			{
			});
			Microsoft.UI.Xaml.Controls.ComboBox category = Ui.Choice(UiText.Get(UiKey.Category), CategoryNames.Select((UiKey name) => UiText.Get(name)), (int)entry.Category, (int _) =>
			{
			});
			Microsoft.UI.Xaml.Controls.CheckBox protect = Ui.Localize(new Microsoft.UI.Xaml.Controls.CheckBox
			{
				Content = UiText.Get(UiKey.ProtectFromAutomaticConversion),
				IsChecked = entry.PreventConversion
			});
			Microsoft.UI.Xaml.Controls.CheckBox enabled = Ui.Localize(new Microsoft.UI.Xaml.Controls.CheckBox
			{
				Content = UiText.Get(UiKey.EntryEnabled),
				IsChecked = entry.Enabled
			});
			if (await Dialog(UiText.Get(UiKey.EditPersonalWord), Ui.Stack(word, Ui.Pair(lang, category), protect, enabled), UiText.Get(UiKey.Save)) == ContentDialogResult.Primary)
			{
				bool flag = Session.Dictionary.Update(entry with
				{
					Term = word.Text.Trim(),
					Language = (EntryLanguage)lang.SelectedIndex,
					Category = (DictionaryCategory)category.SelectedIndex,
					PreventConversion = (protect.IsChecked == true),
					Enabled = (enabled.IsChecked == true)
				});
				Notice(UiText.Get(flag ? UiKey.WordSaved : UiKey.WordNotSaved), flag ? InfoBarSeverity.Success : InfoBarSeverity.Warning);
			}
		}

		internal Task<ContentDialogResult> ConfirmRemovalAsync(bool review, int count)
		{
			return Confirm(UiText.Get(review ? UiKey.RejectProposedWordsQuestion : UiKey.DeletePersonalWordsQuestion), UiText.Format(review ? UiKey.RejectProposedWordsBody : UiKey.DeletePersonalWordsBody, UiText.Count(count)), UiText.Get(review ? UiKey.Reject : UiKey.Delete));
		}

		internal Task<ContentDialogResult> ConfirmAcceptAllAsync(int count)
		{
			return Confirm(UiText.Get(UiKey.AcceptAllQuestion), UiText.Format(UiKey.AcceptAllBody, UiText.Count(count)), UiText.Get(UiKey.AcceptAll));
		}

		internal Task<ContentDialogResult> ConfirmAllAsync(bool review)
		{
			return Confirm(UiText.Get(review ? UiKey.RejectAllQuestion : UiKey.DeleteAllPersonalWordsQuestion), UiText.Get(review ? UiKey.RejectAllBody : UiKey.DeleteAllBody), UiText.Get(review ? UiKey.RejectAll : UiKey.DeleteAll));
		}

		private Microsoft.UI.Xaml.UIElement FontsPage()
		{
			string[] fontNames = Fonts.SystemFontFamilies.Select((System.Windows.Media.FontFamily x) => x.Source).Concat(new <>z__ReadOnlyArray<string>(new string[2] { "Shabnam", "Shabnam FD" })).Distinct(StringComparer.OrdinalIgnoreCase)
				.Order()
				.ToArray();
			string selected = Session.Settings.General.TypingFontFamily;
			TextBlock preview = Ui.Text("سلام، به کوکو تایپینگ خوش آمدید. ۱۲۳۴۵۶۷۸۹۰");
			preview.FontFamily = Ui.PersianFont;
			preview.FontSize = 22.0;
			preview.FlowDirection = Microsoft.UI.Xaml.FlowDirection.RightToLeft;
			StackPanel apps = new StackPanel
			{
				Spacing = 8.0
			};
			TextBlock status = Ui.Text("", secondary: true);
			List<(ApplicationFontTargetInfo App, Microsoft.UI.Xaml.Controls.CheckBox Check)> choices = new List<(ApplicationFontTargetInfo, Microsoft.UI.Xaml.Controls.CheckBox)>();
			bool busy = false;
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice(UiText.Get(UiKey.TypingFont), fontNames, Array.FindIndex(fontNames, (string x) => string.Equals(x, selected, StringComparison.OrdinalIgnoreCase)), (int index) =>
			{
				selected = fontNames[index];
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						TypingFontFamily = selected
					}
				});
				preview.FontFamily = (selected.StartsWith("Shabnam", StringComparison.OrdinalIgnoreCase) ? Ui.PersianFont : new Microsoft.UI.Xaml.Media.FontFamily(selected));
			});
			ScrollViewer scrollViewer = Ui.Page(Ui.Section(UiText.Get(UiKey.TypingFont), comboBox, preview), Ui.Section(UiText.Get(UiKey.ApplicationDefaults), HelpButton(HelpTopic.Fonts), new Microsoft.UI.Xaml.UIElement[4]
			{
				Ui.Actions(Ui.Icon(UiText.Get(UiKey.RefreshApplications), Symbol.Refresh, () => Refresh(thorough: true, announce: true)), Ui.Button(UiText.Get(UiKey.SelectSupported), () =>
				{
					foreach (var item in choices)
					{
						item.Check.IsChecked = item.App.CanApply;
					}
					return Task.CompletedTask;
				})),
				apps,
				status,
				Ui.Actions(Ui.Button(UiText.Get(UiKey.ApplyFont), () => ChangeFonts(restore: false), primary: true, Symbol.Font), Ui.Button(UiText.Get(UiKey.RestorePrevious), () => ChangeFonts(restore: true), primary: false, Symbol.Undo))
			}));
			scrollViewer.Loaded += async (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
			{
				try
				{
					await Refresh(thorough: false, announce: true);
				}
				catch (System.Exception ex)
				{
					Notice(ex.Message, InfoBarSeverity.Error);
				}
			};
			return scrollViewer;
			async Task ChangeFonts(bool restore)
			{
				string[] ids = (from x in choices
					where x.Check.IsChecked == true
					select x.App.Id).ToArray();
				if (ids.Length == 0)
				{
					Notice(UiText.Get(UiKey.SelectAtLeastOneApp), InfoBarSeverity.Warning);
				}
				else if (!Session.IsVerification && await Confirm(UiText.Get(restore ? UiKey.RestorePreviousFontsQuestion : UiKey.ApplyFontQuestion), string.Join(UiText.ListSeparator, from x in choices
					where x.Check.IsChecked == true
					select x.App.DisplayName), UiText.Get(restore ? UiKey.Restore : UiKey.Apply)) == ContentDialogResult.Primary)
				{
					IReadOnlyList<ApplicationFontTargetInfo> readOnlyList = ((!restore) ? (await Session.Fonts.ApplyAsync(ids, selected)) : (await Session.Fonts.RestoreAsync(ids)));
					IReadOnlyList<ApplicationFontTargetInfo> results = readOnlyList;
					await Refresh();
					ApplicationFontTargetInfo[] array = results.Where((ApplicationFontTargetInfo x) =>
					{
						ApplicationFontTargetState state = x.State;
						return ((uint)(state - 3) <= 3u || (uint)(state - 8) <= 1u) ? true : false;
					}).ToArray();
					bool flag = results.Any((ApplicationFontTargetInfo x) =>
					{
						ApplicationFontTargetState state = x.State;
						return (state == ApplicationFontTargetState.RestartRequired || state == ApplicationFontTargetState.Written) ? true : false;
					});
					string text = string.Join("\n", results.Select((ApplicationFontTargetInfo x) => TextCatalog.Format("{0}: {1}", new <>z__ReadOnlyArray<object>(new object[2] { x.DisplayName, x.Status }), Ui.Persian)));
					if (array.Length == results.Count)
					{
						text = UiText.Get(UiKey.NoApplicationChanged) + "\n" + text;
					}
					else if (array.Length != 0)
					{
						text = UiText.Format(UiKey.SomeApplicationsChanged, results.Count - array.Length, results.Count) + "\n" + text;
					}
					if (!restore && results.Any((ApplicationFontTargetInfo x) => x.State == ApplicationFontTargetState.Written && Session.Fonts.CanOpenFontCheck(x.Id)))
					{
						text = text + "\n" + UiText.Get(UiKey.FontBrowsersNote);
					}
					if (results.Any((ApplicationFontTargetInfo x) => x.State == ApplicationFontTargetState.FontNotInstalled))
					{
						text = text + "\n" + UiText.Format(UiKey.FontNotInstalledNote, selected);
					}
					Notice(text, (array.Length != 0) ? InfoBarSeverity.Warning : ((!flag) ? InfoBarSeverity.Success : InfoBarSeverity.Informational));
				}
			}
			async Task Refresh(bool thorough = false, bool announce = false)
			{
				if (busy)
				{
					return;
				}
				busy = true;
				try
				{
					IReadOnlyList<ApplicationFontTargetInfo> readOnlyList = ((!Session.IsVerification) ? (await Session.Fonts.InspectAsync(selected, thorough)) : Verification.FontTargets);
					IReadOnlyList<ApplicationFontTargetInfo> readOnlyList2 = readOnlyList;
					Render(readOnlyList2);
					string[] array = (from x in readOnlyList2
						where x.IsInstalled && x.State == ApplicationFontTargetState.Reverted
						select x.DisplayName).ToArray();
					if (announce && array.Length != 0)
					{
						Notice(UiText.Format(UiKey.FontsRevertedNotice, string.Join(UiText.ListSeparator, array)), InfoBarSeverity.Warning);
					}
				}
				finally
				{
					busy = false;
				}
			}
			void Render(IReadOnlyList<ApplicationFontTargetInfo> targets)
			{
				apps.Children.Clear();
				choices.Clear();
				ApplicationFontTargetInfo[] array = targets.Where((ApplicationFontTargetInfo x) => x.IsInstalled).ToArray();
				int num = targets.Count - array.Length;
				ApplicationFontTargetInfo[] array2 = array;
				foreach (ApplicationFontTargetInfo applicationFontTargetInfo in array2)
				{
					Microsoft.UI.Xaml.Controls.CheckBox checkBox = Ui.Named(new Microsoft.UI.Xaml.Controls.CheckBox
					{
						Content = applicationFontTargetInfo.DisplayName,
						IsEnabled = applicationFontTargetInfo.CanApply,
						MinHeight = 40.0
					}, applicationFontTargetInfo.DisplayName);
					StackPanel stackPanel = Ui.Stack(Ui.Text(applicationFontTargetInfo.Scope), Ui.Text(applicationFontTargetInfo.Status, secondary: true));
					stackPanel.Spacing = 4.0;
					ApplicationFontTargetState state = applicationFontTargetInfo.State;
					bool flag = ((state == ApplicationFontTargetState.Applied || (uint)(state - 7) <= 1u) ? true : false);
					if (flag && Session.Fonts.CanOpenFontCheck(applicationFontTargetInfo.Id))
					{
						ApplicationFontTargetInfo browser = applicationFontTargetInfo;
						Microsoft.UI.Xaml.Controls.Button button = Ui.Button(UiText.Get(UiKey.ShowFontInBrowser), () =>
						{
							if (!Session.IsVerification && !Session.Fonts.OpenFontCheck(browser.Id, selected))
							{
								Notice(UiText.Format(UiKey.FontCheckNotOpened, browser.DisplayName), InfoBarSeverity.Warning);
							}
							return Task.CompletedTask;
						}, primary: false, Symbol.View);
						Ui.Named(button, TextCatalog.Format("{0}: {1}", new <>z__ReadOnlyArray<object>(new object[2]
						{
							UiText.Get(UiKey.ShowFontInBrowser),
							browser.DisplayName
						}), Ui.Persian));
						stackPanel.Children.Add(Ui.Actions(button));
					}
					apps.Children.Add(Ui.Pair(checkBox, stackPanel));
					choices.Add((applicationFontTargetInfo, checkBox));
				}
				int num3 = array.Count((ApplicationFontTargetInfo x) => x.CanApply);
				status.Text = ((array.Length == 0) ? UiText.Get(UiKey.NoSupportedAppDetected) : UiText.Format(UiKey.FontAppsSummary, num3, array.Length, num));
			}
		}

		private Grid SettingsPage()
		{
			Grid grid = new Grid
			{
				RowSpacing = 24.0
			};
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = Microsoft.UI.Xaml.GridLength.Auto
			});
			grid.RowDefinitions.Add(new RowDefinition());
			_settingsSelector = Ui.Named(new SelectorBar(), UiText.Get(UiKey.SettingsCategories));
			UiKey[] settingsTabNames = SettingsTabNames;
			foreach (UiKey key in settingsTabNames)
			{
				_settingsSelector.Items.Add(Ui.Localize(new SelectorBarItem
				{
					Text = UiText.Get(key)
				}));
			}
			_settingsContent = new ContentControl
			{
				HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
				VerticalContentAlignment = VerticalAlignment.Stretch
			};
			_settingsSelector.SelectionChanged += (SelectorBar _, SelectorBarSelectionChangedEventArgs _) =>
			{
				int num = _settingsSelector.Items.IndexOf(_settingsSelector.SelectedItem);
				if (num >= 0)
				{
					ShowSettings(num);
				}
			};
			grid.Children.Add(_settingsSelector);
			grid.Children.Add(_settingsContent);
			Grid.SetRow(_settingsContent, 1);
			_settingsSelector.SelectedItem = _settingsSelector.Items[_settingsTab];
			return grid;
		}

		internal void ShowSettings(int index)
		{
			_settingsTab = index;
			if ((object)_settingsSelector != null && (object)_settingsContent != null)
			{
				if (_settingsSelector.SelectedItem != _settingsSelector.Items[index])
				{
					_settingsSelector.SelectedItem = _settingsSelector.Items[index];
					return;
				}
				_notice.IsOpen = false;
				ContentControl settingsContent = _settingsContent;
				settingsContent.Content = index switch
				{
					1 => (object)TypingPage(), 
					2 => TranslationPage(), 
					3 => FontsPage(), 
					4 => ShortcutsPage(), 
					_ => GeneralPage(), 
				};
			}
		}

		private Microsoft.UI.Xaml.UIElement GeneralPage()
		{
			GeneralSettings general = Session.Settings.General;
			TextBlock startupStatus = Ui.Text(Session.StartupStatus().Message, secondary: true);
			ToggleSwitch toggleSwitch = Ui.Toggle(UiText.Get(UiKey.RunWhenWindowsStarts), Session.StartupStatus().IsEnabled, (bool value) =>
			{
				StartupRegistrationResult startupRegistrationResult = Session.SetStartup(value);
				startupStatus.Text = startupRegistrationResult.Message;
				Notice(startupRegistrationResult.Message, startupRegistrationResult.Succeeded ? InfoBarSeverity.Success : InfoBarSeverity.Error);
			});
			TextBlock feed = Ui.Value(Session.Updates.FeedUri.AbsoluteUri, secondary: true);
			feed.IsTextSelectionEnabled = true;
			Microsoft.UI.Xaml.Controls.Button right = Ui.Icon(UiText.Get(UiKey.EditUpdateUrl), Symbol.Edit, async () =>
			{
				Microsoft.UI.Xaml.Controls.TextBox input = Ui.Input(UiText.Get(UiKey.UpdateManifestUrl), Session.Updates.FeedUri.AbsoluteUri, latin: true);
				if (await Dialog(UiText.Get(UiKey.UpdateSource), input, UiText.Get(UiKey.Save)) == ContentDialogResult.Primary)
				{
					string absoluteUri = Session.Updates.FeedUri.AbsoluteUri;
					if (!Session.Updates.TrySetFeedUri(input.Text, out string error))
					{
						Notice(error, InfoBarSeverity.Error);
					}
					else
					{
						try
						{
							Session.Save((AppSettings s) => s with
							{
								General = s.General with
								{
									UpdateFeedUrl = Session.Updates.FeedUri.AbsoluteUri
								}
							});
						}
						catch
						{
							Session.Updates.TrySetFeedUri(absoluteUri, out string _);
							throw;
						}
						feed.Text = Session.Updates.FeedUri.AbsoluteUri;
						Notice(UiText.Get(UiKey.UpdateSourceSaved), InfoBarSeverity.Success);
					}
				}
			});
			return Ui.Page(LanguageSection(), Ui.Section(UiText.Get(UiKey.TypingAssistant), HelpButton(HelpTopic.GettingStarted), new Microsoft.UI.Xaml.UIElement[1] { Ui.Toggle(UiText.Get(UiKey.EnableCocoTyping), general.Enabled, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						Enabled = value
					}
				});
			}) }), Ui.Section(UiText.Get(UiKey.Startup), HelpButton(HelpTopic.StartupAndUpdates), new Microsoft.UI.Xaml.UIElement[2] { toggleSwitch, startupStatus }), Ui.Section(UiText.Get(UiKey.Updates), HelpButton(HelpTopic.StartupAndUpdates), new Microsoft.UI.Xaml.UIElement[4]
			{
				Ui.Pair(Ui.Toggle(UiText.Get(UiKey.CheckForUpdatesAtStartup), general.CheckForUpdatesAutomatically, (bool value) =>
				{
					Session.Save((AppSettings s) => s with
					{
						General = s.General with
						{
							CheckForUpdatesAutomatically = value
						}
					});
				}), Ui.Choice(UiText.Get(UiKey.ReleaseChannel), new <>z__ReadOnlyArray<string>(new string[2]
				{
					UiText.Get(UiKey.StableReleases),
					UiText.Get(UiKey.StableAndPreviewReleases)
				}), general.IncludePreviewUpdates ? 1 : 0, (int index) =>
				{
					Session.Save((AppSettings s) => s with
					{
						General = s.General with
						{
							IncludePreviewUpdates = (index == 1)
						}
					});
				})),
				Ui.Pair(Ui.Stack(Ui.Text(UiKey.UpdateSource), feed), right),
				Ui.Actions(Ui.Button(UiText.Get(UiKey.CheckForUpdates), CheckUpdatesAsync, primary: false, Symbol.Sync), Ui.Fact(UiKey.InstalledVersion, App.VersionAndBuild, secondary: true)),
				UpdatePanel()
			}), DiagnosticsSection(general));
		}

		private Microsoft.UI.Xaml.UIElement LanguageSection()
		{
			UiLanguage uiLanguage = TextCatalog.Resolve(Session.Settings.General.UiLanguage);
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice(UiText.Get(UiKey.InterfaceLanguage), new <>z__ReadOnlyArray<ComboBoxItem>(new ComboBoxItem[2]
			{
				Ui.LanguageItem("English", UiLanguage.English),
				Ui.LanguageItem("فارسی", UiLanguage.Persian)
			}), (uiLanguage == UiLanguage.Persian) ? 1 : 0, (int index) =>
			{
				UiLanguage language = ((index == 1) ? UiLanguage.Persian : UiLanguage.English);
				if (language != TextCatalog.Resolve(Session.Settings.General.UiLanguage))
				{
					Session.Save((AppSettings s) => s with
					{
						General = s.General with
						{
							UiLanguage = language
						}
					});
					DispatcherQueue.TryEnqueue(() =>
					{
						ApplyLanguage(language);
					});
				}
			});
			ToolTipService.SetToolTip(comboBox, Ui.Tip(UiText.Get(UiKey.InterfaceLanguageTip)));
			LanguageChoice = comboBox;
			return Ui.Section(UiText.Get(UiKey.LanguageCardTitle), HelpButton(HelpTopic.InterfaceLanguage), new Microsoft.UI.Xaml.UIElement[2]
			{
				comboBox,
				Ui.Text(UiKey.InterfaceLanguageNote, secondary: true)
			});
		}

		private Microsoft.UI.Xaml.UIElement DiagnosticsSection(GeneralSettings general)
		{
			TextBlock status = Ui.Text(string.Empty, secondary: true);
			status.IsTextSelectionEnabled = true;
			ShowDebugStatus(status);
			ToggleSwitch item = Ui.Toggle(UiText.Get(UiKey.DebugMode), Session.DebugEffective, (bool value) =>
			{
				Session.SetDebug(value);
				ShowDebugStatus(status);
			});
			string title = UiText.Get(UiKey.Diagnostics);
			Microsoft.UI.Xaml.Controls.Button headerAction = HelpButton(HelpTopic.Troubleshooting);
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			list.Add(item);
			list.Add(Ui.Text(UiKey.DebugModeExplanation, secondary: true));
			list.Add(status);
			list.Add(Ui.Actions(Ui.Button(UiText.Get(UiKey.ReportTypingProblem), async () =>
			{
				TypingSession.ProblemCapture captured = Session.CaptureProblemReport();
				Microsoft.UI.Xaml.Controls.TextBox expected = Ui.Input(UiText.Get(UiKey.ExpectedTextPrompt));
				if (!Session.DebugEffective)
				{
					Notice(UiText.Get(UiKey.TurnDebugOnFirst), InfoBarSeverity.Warning);
				}
				else
				{
					ContentDialogResult answer = await Dialog(UiText.Get(UiKey.ReportTypingProblem), expected, UiText.Get(UiKey.SaveReport));
					string text = await Session.SaveProblemReportAsync(captured, (answer == ContentDialogResult.Primary) ? expected.Text : null);
					if (text == null)
					{
						Notice(UiText.Get(UiKey.NothingSavedDebugOff), InfoBarSeverity.Warning);
					}
					else if (answer == ContentDialogResult.Primary)
					{
						Notice(UiKey.ReportSaved, InfoBarSeverity.Success, text);
					}
					else
					{
						Notice(UiKey.ReportSavedWithoutExpected, InfoBarSeverity.Informational, text);
					}
				}
			}, primary: false, Symbol.Flag), Ui.Button(UiText.Get(UiKey.OpenLogFolder), () =>
			{
				string directoryName = System.IO.Path.GetDirectoryName(TypingSession.DebugLogPath ?? DiagnosticLog.DefaultPath);
				Directory.CreateDirectory(directoryName);
				Process.Start(new ProcessStartInfo("explorer.exe", "\"" + directoryName + "\"")
				{
					UseShellExecute = true
				});
				return Task.CompletedTask;
			}, primary: false, Symbol.OpenLocal), Ui.Button(UiText.Get(UiKey.ClearLog), () =>
			{
				DiagnosticLog.Clear();
				Notice(UiText.Get(UiKey.LogCleared), InfoBarSeverity.Success);
				return Task.CompletedTask;
			}, primary: false, Symbol.Delete)));
			list.AddRange(CrashStatus());
			list.Add(Ui.Text(UiKey.CrashFolderNote, secondary: true));
			list.Add(Ui.Actions(Ui.Button(UiText.Get(UiKey.OpenCrashFolder), () =>
			{
				Directory.CreateDirectory(Session.CrashDirectory);
				Process.Start(new ProcessStartInfo("explorer.exe", "\"" + Session.CrashDirectory + "\"")
				{
					UseShellExecute = true
				});
				return Task.CompletedTask;
			}, primary: false, Symbol.OpenLocal)));
			return Ui.Section(title, headerAction, list.ToArray());
		}

		private List<Microsoft.UI.Xaml.UIElement> CrashStatus()
		{
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			(SessionOutcome, System.DateTimeOffset)? lastSessionOutcome = Session.LastSessionOutcome;
			if (lastSessionOutcome.HasValue)
			{
				(SessionOutcome, System.DateTimeOffset) valueOrDefault = lastSessionOutcome.GetValueOrDefault();
				UiKey key = valueOrDefault.Item1 switch
				{
					SessionOutcome.CleanExit => UiKey.LastSessionEndedNormally, 
					SessionOutcome.CrashedWithRecord => UiKey.LastSessionCrashed, 
					_ => UiKey.LastSessionEndedWithoutRecord, 
				};
				TextBlock textBlock = Ui.Text(string.Empty, secondary: true);
				Ui.SetRich(textBlock, key, InterfaceFormat.Date(valueOrDefault.Item2.LocalDateTime, TextCatalog.Language));
				list.Add(textBlock);
			}
			TextBlock textBlock2 = Ui.Text(string.Empty, secondary: true);
			Ui.SetRich(textBlock2, UiKey.HandledFaultsThisSession, UiText.Count(FaultRing.Count));
			list.Add(textBlock2);
			return list;
		}

		private void ShowDebugStatus(TextBlock status)
		{
			string debugLogPath = TypingSession.DebugLogPath;
			if (debugLogPath == null)
			{
				Ui.SetRich(status, UiKey.DebugStatusOff, DiagnosticLog.DefaultPath);
			}
			else if (Session.DebugOnForThisRunOnly)
			{
				Ui.SetRich(status, UiKey.DebugStatusOnForThisRun, "SMARTINPUT_LOG_PATH", debugLogPath);
			}
			else
			{
				Ui.SetRich(status, UiKey.DebugStatusOn, debugLogPath);
			}
		}

		internal async Task CheckUpdatesAsync()
		{
			if (Session.IsVerification)
			{
				Notice(UiText.Get(UiKey.UpdatesDisabledInVerification));
				return;
			}
			Notice(UiText.Get(UiKey.CheckingForUpdates));
			UpdateCheckResult updateCheckResult = await Session.UpdateChecks.CheckNowAsync(Session.Settings.General.IncludePreviewUpdates);
			RefreshUpdatePanel();
			if ((object)updateCheckResult != null && updateCheckResult.Status == UpdateCheckStatus.UpdateAvailable)
			{
				UpdateRelease release = updateCheckResult.Release;
				if ((object)release != null)
				{
					ShowUpdateNotice(release);
					bool offer = Session.UpdateInstall.CanInstall(release);
					if ((await ShowUpdateAvailableAsync(updateCheckResult.Message, release.ReleasePageUri, offer) == ContentDialogResult.Primary) & offer)
					{
						StartUpdateDownload();
					}
					return;
				}
			}
			Notice(updateCheckResult.Message, (updateCheckResult.Status == UpdateCheckStatus.Unavailable) ? InfoBarSeverity.Warning : InfoBarSeverity.Informational);
		}

		internal void ShowUpdateNotice(UpdateRelease release)
		{
			DispatcherQueue.TryEnqueue(() =>
			{
				bool flag = Session.UpdateInstall.CanInstall(release);
				_notice.Message = UiText.Format(UiKey.UpdateNoticeText, release.Version);
				_notice.Severity = InfoBarSeverity.Informational;
				_notice.Content = (flag ? Ui.Link(UiText.Get(UiKey.ViewRelease), release.ReleasePageUri.AbsoluteUri) : null);
				_notice.ActionButton = (flag ? ((Microsoft.UI.Xaml.Controls.Primitives.ButtonBase)Ui.Button(UiText.Get(UiKey.UpdateNow), () =>
				{
					StartUpdateDownload();
					return Task.CompletedTask;
				}, primary: true)) : ((Microsoft.UI.Xaml.Controls.Primitives.ButtonBase)Ui.Link(UiText.Get(UiKey.ViewRelease), release.ReleasePageUri.AbsoluteUri)));
				_notice.IsOpen = true;
				RefreshUpdatePanel();
			});
		}

		internal string? ShowUpdateOutcome(UpdateOutcome outcome)
		{
			string version = outcome.Version;
			if (version == null)
			{
				return null;
			}
			if (outcome.Kind == UpdateOutcomeKind.Updated)
			{
				Notice(UiKey.UpdatedToText, InfoBarSeverity.Success, version);
				return UiText.Format(UiKey.UpdatedToText, version);
			}
			if (outcome.Kind == UpdateOutcomeKind.UpdatedRestartPending)
			{
				Notice(UiKey.UpdateRestartWindowsText, InfoBarSeverity.Informational, version);
				return UiText.Format(UiKey.UpdateRestartWindowsText, version);
			}
			if (!outcome.DidNotFinish)
			{
				return null;
			}
			string log = outcome.Marker?.LogPath;
			if (log != null && File.Exists(log))
			{
				NoticeWithAction(UiKey.UpdateDidNotFinishText, InfoBarSeverity.Warning, UiText.Get(UiKey.OpenSetupLog), () =>
				{
					OpenWithShell(log);
				}, version);
			}
			else
			{
				Notice(UiKey.UpdateDidNotFinishText, InfoBarSeverity.Warning, version);
			}
			RefreshUpdatePanel();
			return UiText.Format(UiKey.UpdateDidNotFinishText, version);
		}

		internal void ShowPendingUpdate()
		{
			UpdateRelease pending = Session.UpdateChecks.Pending;
			if ((object)pending != null)
			{
				ShowUpdateNotice(pending);
			}
		}

		private void StartUpdateDownload()
		{
			Navigate("settings");
			ShowSettings(0);
			Session.UpdateInstall.DownloadAsync();
		}

		private StackPanel UpdatePanel()
		{
			_updatePanel = new StackPanel
			{
				Spacing = 8.0
			};
			_updatePanelState = null;
			RefreshUpdatePanel();
			return _updatePanel;
		}

		private void UpdateStatusChanged(UpdateRunStatus status)
		{
			DispatcherQueue.TryEnqueue(RefreshUpdatePanel);
		}

		private void RefreshUpdatePanel()
		{
			if ((object)_updatePanel == null)
			{
				return;
			}
			UpdateRunStatus status = Session.UpdateInstall.Status;
			if ((object)status != null && status.State == UpdateRunState.Downloading)
			{
				UpdateTarget target = status.Target;
				if ((object)target != null && _updatePanelState == UpdateRunState.Downloading && (object)_downloadBar != null && (object)_downloadText != null)
				{
					_downloadBar.Value = Percent(status.BytesReceived, target.Size);
					Ui.SetRich(_downloadText, UiKey.UpdateDownloadingText, target.Version, UpdateDownloadRules.Megabytes(status.BytesReceived), UpdateDownloadRules.Megabytes(target.Size));
					return;
				}
			}
			_updatePanel.Children.Clear();
			_downloadBar = null;
			_downloadText = null;
			_updatePanelState = status.State;
			foreach (Microsoft.UI.Xaml.UIElement item in UpdateCard(status))
			{
				_updatePanel.Children.Add(item);
			}
			_updatePanel.Visibility = ((_updatePanel.Children.Count <= 0) ? Visibility.Collapsed : Visibility.Visible);
		}

		private List<Microsoft.UI.Xaml.UIElement> UpdateCard(UpdateRunStatus status)
		{
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			UpdateTarget target = status.Target;
			if ((object)target == null)
			{
				UpdateRelease pending = Session.UpdateChecks.Pending;
				if ((object)pending != null)
				{
					list.Add(Ui.Rich(UiKey.PendingUpdateText, false, pending.Version));
					list.Add(Ui.Link(UiText.Get(UiKey.ViewReleaseAndInstallers), pending.ReleasePageUri.AbsoluteUri));
				}
				return list;
			}
			HyperlinkButton hyperlinkButton = Ui.Link(UiText.Get(UiKey.ViewRelease), target.ReleasePageUri.AbsoluteUri);
			switch (status.State)
			{
			case UpdateRunState.Available:
				list.Add(Ui.Rich(UiKey.UpdateAvailableCardText, false, target.Version, UpdateDownloadRules.Megabytes(target.Size)));
				list.Add(Ui.Actions(UpdateButton(UiKey.UpdateNow), hyperlinkButton));
				break;
			case UpdateRunState.Downloading:
				_downloadText = Ui.Rich(UiKey.UpdateDownloadingText, false, target.Version, UpdateDownloadRules.Megabytes(status.BytesReceived), UpdateDownloadRules.Megabytes(target.Size));
				_downloadBar = Ui.Progress(UiText.Get(UiKey.UpdateDownloadProgressName), Percent(status.BytesReceived, target.Size));
				list.Add(_downloadText);
				list.Add(_downloadBar);
				list.Add(Ui.Actions(Ui.Button(UiText.Get(UiKey.CancelDownload), () =>
				{
					Session.UpdateInstall.CancelDownload();
					return Task.CompletedTask;
				})));
				break;
			case UpdateRunState.Verifying:
				list.Add(Ui.Text(UiKey.UpdateVerifyingText));
				list.Add(Ui.Progress(UiText.Get(UiKey.UpdateVerifyingText)));
				break;
			case UpdateRunState.Ready:
				list.Add(Ui.Rich(UiKey.UpdateReadyText, false, target.Version));
				list.Add(Ui.Actions(UpdateButton(UiKey.InstallAndRestart)));
				break;
			case UpdateRunState.Installing:
				list.Add(Ui.Rich(UiKey.UpdateInstallingText, false, target.Version));
				list.Add(Ui.Progress(UiText.Format(UiKey.UpdateInstallingText, target.Version)));
				break;
			case UpdateRunState.PermissionRefused:
				list.Add(Ui.Text(UiKey.UpdatePermissionRefusedText));
				list.Add(Ui.Actions(UpdateButton(UiKey.TryAgain)));
				break;
			case UpdateRunState.Cancelled:
				list.Add(Ui.Text(UiKey.UpdateCancelledText));
				list.Add(Ui.Actions(UpdateButton(UiKey.InstallAndRestart)));
				break;
			case UpdateRunState.RestartWindows:
				list.Add(Ui.Rich(UiKey.UpdateRestartWindowsText, false, target.Version));
				break;
			case UpdateRunState.RestartDiyar:
				list.Add(Ui.Rich(UiKey.UpdateRestartDiyarText, false, target.Version));
				list.Add(Ui.Actions(UpdateButton(UiKey.RestartDiyar)));
				break;
			case UpdateRunState.Failed:
			{
				list.Add(UpdateFailureText(status, target));
				List<Microsoft.UI.Xaml.UIElement> list2 = new List<Microsoft.UI.Xaml.UIElement>();
				if (status.Action != UpdateRunAction.None)
				{
					list2.Add(UpdateButton(UiKey.TryAgain));
				}
				string log = status.LogPath;
				if (log != null && File.Exists(log))
				{
					list2.Add(Ui.Button(UiText.Get(UiKey.OpenSetupLog), () =>
					{
						OpenWithShell(log);
						return Task.CompletedTask;
					}, primary: false, Symbol.Document));
				}
				if (status.Failure == UpdateRunFailure.BlockedBySecurity)
				{
					string folder = System.IO.Path.GetDirectoryName(status.LogPath);
					if (folder != null && folder.Length > 0)
					{
						list2.Add(Ui.Button(UiText.Get(UiKey.OpenUpdateFolder), () =>
						{
							OpenWithShell(folder);
							return Task.CompletedTask;
						}, primary: false, Symbol.OpenLocal));
					}
				}
				list2.Add(hyperlinkButton);
				list.Add(Ui.Actions(list2.ToArray()));
				break;
			}
			}
			return list;
		}

		private Microsoft.UI.Xaml.Controls.Button UpdateButton(UiKey label)
		{
			return Ui.Button(UiText.Get(label), () =>
			{
				switch (Session.UpdateInstall.Status.Action)
				{
				case UpdateRunAction.Download:
					Session.UpdateInstall.DownloadAsync();
					break;
				case UpdateRunAction.Install:
					Session.UpdateInstall.InstallAsync();
					break;
				case UpdateRunAction.RestartDiyar:
					RestartApp();
					break;
				}
				return Task.CompletedTask;
			}, primary: true);
		}

		private static TextBlock UpdateFailureText(UpdateRunStatus status, UpdateTarget target)
		{
			return status.Failure switch
			{
				UpdateRunFailure.FileRejected => Ui.Text(UiKey.UpdateFileRejectedText), 
				UpdateRunFailure.NotEnoughSpace => Ui.Rich(UiKey.UpdateNotEnoughSpaceText, false, UpdateDownloadRules.Megabytes(UpdateDownloadRules.RequiredFreeSpace(target.Size, status.BytesReceived))), 
				UpdateRunFailure.BlockedBySecurity => Ui.Text(UiKey.UpdateBlockedBySecurityText), 
				UpdateRunFailure.NewerInstalled => Ui.Text(UiKey.UpdateNewerInstalledText), 
				UpdateRunFailure.SetupFailed => Ui.Rich(UiKey.UpdateFailedText, false, status.ExitCode.GetValueOrDefault()), 
				UpdateRunFailure.LaunchFailed => Ui.Text(UiKey.UpdateLaunchFailedText), 
				_ => Ui.Text(UiKey.UpdateDownloadFailedText), 
			};
		}

		private static double Percent(long bytes, long size)
		{
			if (size > 0)
			{
				return Math.Clamp((double)bytes * 100.0 / (double)size, 0.0, 100.0);
			}
			return 0.0;
		}

		private static void OpenWithShell(string path)
		{
			Process.Start(new ProcessStartInfo(path)
			{
				UseShellExecute = true
			});
		}

		internal Task<ContentDialogResult> ShowUpdateAvailableAsync(string message, System.Uri releasePage, bool offerInstall = false)
		{
			return Dialog(UiText.Get(UiKey.UpdateAvailable), Ui.Stack(Ui.Text(message), Ui.Link(UiText.Get(UiKey.ViewReleaseAndInstallers), releasePage.AbsoluteUri)), offerInstall ? UiText.Get(UiKey.DownloadAndInstall) : null, UiText.Get(UiKey.Close));
		}

		private Microsoft.UI.Xaml.UIElement HelpPage(bool persian, HelpTopic? scrollTo = null)
		{
			UiLanguage uiLanguage = (persian ? UiLanguage.Persian : UiLanguage.English);
			SelectorBar languages = HelpLanguageSwitch(persian);
			languages.SelectionChanged += (SelectorBar _, SelectorBarSelectionChangedEventArgs _) =>
			{
				_page.Content = HelpPage(languages.SelectedItem == languages.Items[1]);
			};
			Dictionary<HelpTopic, Microsoft.UI.Xaml.FrameworkElement> dictionary = new Dictionary<HelpTopic, Microsoft.UI.Xaml.FrameworkElement>();
			StackPanel stackPanel = Ui.Stack();
			foreach (HelpEntry item in HelpContent.All)
			{
				StackPanel stackPanel2 = HelpTopicSection(item.Topic, item.In(uiLanguage), persian);
				dictionary[item.Topic] = stackPanel2;
				stackPanel.Children.Add(stackPanel2);
			}
			HelpSections = dictionary;
			HelpLanguageShown = uiLanguage;
			VariableSizedWrapGrid variableSizedWrapGrid = new VariableSizedWrapGrid
			{
				Orientation = Microsoft.UI.Xaml.Controls.Orientation.Horizontal,
				ItemWidth = 240.0
			};
			foreach (HelpEntry item2 in HelpContent.All)
			{
				Microsoft.UI.Xaml.FrameworkElement target = dictionary[item2.Topic];
				string title = item2.In(uiLanguage).Title;
				HyperlinkButton hyperlinkButton = Ui.Named(new HyperlinkButton
				{
					Content = HelpProse(title, persian),
					Padding = new Microsoft.UI.Xaml.Thickness(0.0, 4.0, 8.0, 4.0)
				}, HelpContent.Plain(title));
				ApplyHelpLanguage(hyperlinkButton, persian);
				hyperlinkButton.Click += (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
				{
					target.StartBringIntoView(new Microsoft.UI.Xaml.BringIntoViewOptions
					{
						VerticalAlignmentRatio = 0.0
					});
				};
				variableSizedWrapGrid.Children.Add(hyperlinkButton);
			}
			TextBlock textBlock = Ui.Text(UiText.Get(UiKey.HelpIntro, uiLanguage), secondary: true);
			textBlock.TextWrapping = TextWrapping.Wrap;
			ApplyHelpLanguage(textBlock, persian);
			StackPanel stackPanel3 = Ui.Stack(textBlock, HelpHeading(UiText.Get(UiKey.HelpContents, uiLanguage), persian, variableSizedWrapGrid), ShortcutSummary(persian), stackPanel, HelpHeading(UiText.Get(UiKey.HelpSupport, uiLanguage), persian, HelpParagraph(UiText.FormatIn(UiKey.HelpSupportText, uiLanguage, App.VersionAndBuild), persian), Ui.Link("diyar.digital", "https://diyar.digital/", value: true)));
			stackPanel3.FlowDirection = (persian ? Microsoft.UI.Xaml.FlowDirection.RightToLeft : Microsoft.UI.Xaml.FlowDirection.LeftToRight);
			ScrollViewer scrollViewer = Ui.Page(languages, stackPanel3);
			if (scrollTo.HasValue)
			{
				HelpTopic valueOrDefault = scrollTo.GetValueOrDefault();
				if (dictionary.TryGetValue(valueOrDefault, out var destination))
				{
					scrollViewer.Loaded += (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
					{
						destination.StartBringIntoView(new Microsoft.UI.Xaml.BringIntoViewOptions
						{
							VerticalAlignmentRatio = 0.0,
							AnimationDesired = false
						});
					};
				}
			}
			return scrollViewer;
		}

		private static SelectorBar HelpLanguageSwitch(bool persian)
		{
			SelectorBar selectorBar = Ui.Named(new SelectorBar(), UiText.Get(UiKey.HelpLanguage));
			SelectorBarItem selectorBarItem = new SelectorBarItem
			{
				Text = "English"
			};
			SelectorBarItem selectorBarItem2 = new SelectorBarItem
			{
				Text = "فارسی"
			};
			if (Ui.Persian)
			{
				Ui.Localize(selectorBarItem, UiLanguage.English);
				Ui.Localize(selectorBarItem2, UiLanguage.Persian);
			}
			selectorBar.Items.Add(selectorBarItem);
			selectorBar.Items.Add(selectorBarItem2);
			selectorBar.SelectedItem = selectorBar.Items[persian ? 1 : 0];
			return selectorBar;
		}

		private Microsoft.UI.Xaml.UIElement ShortcutSummary(bool persian)
		{
			UiLanguage language = (persian ? UiLanguage.Persian : UiLanguage.English);
			string[] array = ShortcutHost.Values(Session.Settings.Hotkeys);
			StackPanel stackPanel = Ui.Stack();
			stackPanel.Spacing = 8.0;
			foreach (int activeCommand in ShortcutHost.ActiveCommands)
			{
				TextBlock left = HelpParagraph(UiText.Get(ShortcutHost.Commands[activeCommand], language), persian);
				TextBlock textBlock = Ui.Value(array[activeCommand]);
				textBlock.HorizontalAlignment = (persian ? Microsoft.UI.Xaml.HorizontalAlignment.Right : Microsoft.UI.Xaml.HorizontalAlignment.Left);
				textBlock.FontFamily = new Microsoft.UI.Xaml.Media.FontFamily("Consolas");
				stackPanel.Children.Add(Ui.Pair(left, textBlock));
			}
			return HelpHeading(UiText.Get(UiKey.HelpYourShortcuts, language), persian, HelpParagraph(UiText.Get(UiKey.HelpShortcutsNote, language), persian, secondary: true), stackPanel);
		}

		private static StackPanel HelpTopicSection(HelpTopic topic, HelpText text, bool persian)
		{
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement> { HelpProse(text.Summary, persian) };
			if (text.Points.Count > 0)
			{
				list.Add(HelpPoints(text, persian));
			}
			if (topic == HelpTopic.Glossary)
			{
				list.Add(GlossaryRows(persian));
			}
			StackPanel stackPanel = HelpHeading(text.Title, persian, list.ToArray());
			TextBlock textBlock = (TextBlock)stackPanel.Children[0];
			SetHelpText(textBlock, text.Title, persian);
			textBlock.Tag = "help-prose";
			AutomationProperties.SetName(textBlock, HelpContent.Plain(text.Title));
			return stackPanel;
		}

		private static Grid GlossaryRows(bool persian)
		{
			UiLanguage language = (persian ? UiLanguage.Persian : UiLanguage.English);
			UiLanguage language2 = ((!persian) ? UiLanguage.Persian : UiLanguage.English);
			Grid grid = new Grid
			{
				ColumnSpacing = 20.0,
				RowSpacing = 8.0
			};
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = Microsoft.UI.Xaml.GridLength.Auto
			});
			TextBlock textBlock = HelpParagraph(persian ? "فارسی" : "English", persian);
			TextBlock textBlock2 = HelpParagraph(string.Empty, persian: true);
			Ui.AddValue(textBlock2, persian ? "English" : "فارسی", persian: true);
			if (persian)
			{
				textBlock.FontFamily = Ui.PersianStrongFont;
			}
			textBlock2.FontFamily = Ui.PersianStrongFont;
			TextBlock[] array = new TextBlock[2] { textBlock, textBlock2 };
			foreach (TextBlock obj in array)
			{
				obj.FontWeight = FontWeights.SemiBold;
				AutomationProperties.SetHeadingLevel(obj, AutomationHeadingLevel.Level3);
			}
			Grid.SetColumn(textBlock2, 1);
			grid.Children.Add(textBlock);
			grid.Children.Add(textBlock2);
			for (int j = 0; j < HelpContent.GlossaryKeys.Count; j++)
			{
				UiKey key = HelpContent.GlossaryKeys[j];
				int value = j + 1;
				grid.RowDefinitions.Add(new RowDefinition
				{
					Height = Microsoft.UI.Xaml.GridLength.Auto
				});
				TextBlock textBlock3 = HelpParagraph(UiText.Get(key, language), persian);
				TextBlock textBlock4 = HelpParagraph(string.Empty, persian: true);
				Ui.AddValue(textBlock4, UiText.Get(key, language2), persian: true);
				Grid.SetRow(textBlock3, value);
				Grid.SetRow(textBlock4, value);
				Grid.SetColumn(textBlock4, 1);
				grid.Children.Add(textBlock3);
				grid.Children.Add(textBlock4);
			}
			return grid;
		}

		private static StackPanel HelpHeading(string title, bool persian, params Microsoft.UI.Xaml.UIElement[] content)
		{
			StackPanel stackPanel = new StackPanel
			{
				Spacing = 12.0,
				Margin = new Microsoft.UI.Xaml.Thickness(0.0, 0.0, 0.0, 24.0)
			};
			TextBlock textBlock = new TextBlock
			{
				Text = title,
				Style = Ui.Style("SubtitleTextBlockStyle"),
				Margin = new Microsoft.UI.Xaml.Thickness(0.0, 0.0, 0.0, 8.0),
				TextWrapping = TextWrapping.Wrap
			};
			AutomationProperties.SetHeadingLevel(textBlock, AutomationHeadingLevel.Level2);
			stackPanel.Children.Add(textBlock);
			foreach (Microsoft.UI.Xaml.UIElement item in content)
			{
				stackPanel.Children.Add(item);
			}
			ApplyHelpLanguage(textBlock, persian);
			if (persian)
			{
				textBlock.FontFamily = Ui.PersianStrongFont;
			}
			return stackPanel;
		}

		private static StackPanel HelpPoints(HelpText text, bool persian)
		{
			StackPanel stackPanel = new StackPanel
			{
				Spacing = 8.0
			};
			for (int i = 0; i < text.Points.Count; i++)
			{
				string text2 = (text.NumberedPoints ? ((persian ? ToPersianDigits(i + 1) : (i + 1).ToString()) + ".") : "•");
				Grid grid = new Grid
				{
					ColumnSpacing = 10.0
				};
				grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = new Microsoft.UI.Xaml.GridLength(20.0)
				});
				grid.ColumnDefinitions.Add(new ColumnDefinition());
				TextBlock textBlock = HelpParagraph(text2, persian);
				textBlock.VerticalAlignment = VerticalAlignment.Top;
				TextBlock textBlock2 = HelpProse(text.Points[i], persian);
				grid.Children.Add(textBlock);
				grid.Children.Add(textBlock2);
				Grid.SetColumn(textBlock2, 1);
				stackPanel.Children.Add(grid);
			}
			return stackPanel;
		}

		private static TextBlock HelpProse(string text, bool persian)
		{
			TextBlock textBlock = HelpParagraph(string.Empty, persian);
			SetHelpText(textBlock, text, persian);
			textBlock.Tag = "help-prose";
			return textBlock;
		}

		private static void SetHelpText(TextBlock block, string text, bool persian)
		{
			block.Inlines.Clear();
			foreach (HelpPart item in HelpContent.Parts(text))
			{
				if (item.IsSpan)
				{
					Ui.AddValue(block, item.Text, persian);
					continue;
				}
				block.Inlines.Add(new Run
				{
					Text = item.Text
				});
			}
		}

		private static TextBlock HelpParagraph(string text, bool persian, bool secondary = false)
		{
			TextBlock textBlock = Ui.Text(text, secondary);
			textBlock.TextWrapping = TextWrapping.Wrap;
			textBlock.VerticalAlignment = VerticalAlignment.Top;
			ApplyHelpLanguage(textBlock, persian);
			return textBlock;
		}

		private static void ApplyHelpLanguage(Microsoft.UI.Xaml.FrameworkElement element, bool persian)
		{
			if (!persian)
			{
				Ui.Localize(element, UiLanguage.English);
				return;
			}
			element.Language = "fa-IR";
			element.FlowDirection = Microsoft.UI.Xaml.FlowDirection.RightToLeft;
			Microsoft.UI.Xaml.Media.FontFamily fontFamily = (Microsoft.UI.Xaml.Media.FontFamily)Microsoft.UI.Xaml.Application.Current.Resources["CocoPersianFont"];
			if (!(element is TextBlock textBlock))
			{
				if (element is Microsoft.UI.Xaml.Controls.Control control)
				{
					control.FontFamily = fontFamily;
				}
			}
			else
			{
				textBlock.FontFamily = fontFamily;
				textBlock.LineHeight = 28.0;
				textBlock.TextReadingOrder = TextReadingOrder.Default;
			}
		}

		private static string ToPersianDigits(int value)
		{
			return string.Concat(from digit in value.ToString()
				select (char)(1776 + (digit - 48)));
		}

		internal Microsoft.UI.Xaml.Controls.Button HelpButton(HelpTopic topic)
		{
			HelpEntry helpEntry = HelpContent.Get(topic);
			return Ui.Icon(UiText.Format(UiKey.HelpButtonName, HelpContent.Plain(helpEntry.In(TextCatalog.Language).Title)), Symbol.Help, () => ShowHelpTopicAsync(topic), 28.0, Ui.Persian);
		}

		internal async Task ShowHelpTopicAsync(HelpTopic topic, bool? persian = null)
		{
			HelpEntry entry = HelpContent.Get(topic);
			bool help = persian ?? Ui.Persian;
			ContentControl content = new ContentControl
			{
				HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch
			};
			SelectorBar languages = HelpLanguageSwitch(help);
			languages.SelectionChanged += (SelectorBar _, SelectorBarSelectionChangedEventArgs _) =>
			{
				help = languages.SelectedItem == languages.Items[1];
				Render();
			};
			Render();
			StackPanel stackPanel = Ui.Stack(languages, new ScrollViewer
			{
				Content = content,
				MaxHeight = 420.0,
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
			});
			stackPanel.MinWidth = 440.0;
			if (await Dialog(HelpContent.Plain(entry.In(TextCatalog.Language).Title), stackPanel, UiText.Get(UiKey.OpenFullHelp), UiText.Get(UiKey.Close)) == ContentDialogResult.Primary)
			{
				Navigate("help");
				_page.Content = HelpPage(help, topic);
			}
			void Render()
			{
				StackPanel stackPanel2 = HelpTopicSection(topic, entry.In(help ? UiLanguage.Persian : UiLanguage.English), help);
				stackPanel2.Children.RemoveAt(0);
				stackPanel2.Margin = new Microsoft.UI.Xaml.Thickness(0.0);
				stackPanel2.FlowDirection = (help ? Microsoft.UI.Xaml.FlowDirection.RightToLeft : Microsoft.UI.Xaml.FlowDirection.LeftToRight);
				content.Content = stackPanel2;
			}
		}

		private Microsoft.UI.Xaml.UIElement AboutPage()
		{
			Image logo = new Image
			{
				Width = 96.0,
				Height = 96.0,
				Stretch = Microsoft.UI.Xaml.Media.Stretch.Uniform,
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center,
				FlowDirection = Microsoft.UI.Xaml.FlowDirection.LeftToRight
			};
			logo.Loaded += (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
			{
				ShowLogo();
			};
			logo.ActualThemeChanged += (Microsoft.UI.Xaml.FrameworkElement _, object _) =>
			{
				ShowLogo();
			};
			TextBlock textBlock = Ui.Localize(new TextBlock
			{
				Text = "Diyar",
				Style = Ui.Style("SubtitleTextBlockStyle"),
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center
			}, strong: true);
			AutomationProperties.SetHeadingLevel(textBlock, AutomationHeadingLevel.Level2);
			StackPanel stackPanel = new StackPanel
			{
				Spacing = 8.0,
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Left
			};
			stackPanel.Children.Add(logo);
			stackPanel.Children.Add(textBlock);
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>
			{
				stackPanel,
				Ui.Text(UiKey.AboutTagline),
				Ui.Text(UiKey.AboutDedication),
				Ui.Fact(UiKey.AboutVersion, App.VersionAndBuild, secondary: true)
			};
			string releaseDate = App.ReleaseDate;
			if (releaseDate != null)
			{
				list.Add(Ui.Fact(UiKey.AboutReleaseDate, releaseDate, secondary: true));
			}
			list.Add(Ui.Text(UiKey.AboutPreview, secondary: true));
			return Ui.Page(Ui.Card(null, list.ToArray()), Ui.Section(UiText.Get(UiKey.AboutSupportTitle), Ui.Text(UiKey.AboutSupportText), Ui.Link(UiText.Get(UiKey.AboutSupportLink), "https://nowpayments.io/donation/iranux")), Ui.Section("Webpack", Ui.Link("diyar.digital", "https://diyar.digital/", value: true), Ui.Link("webpack.site", "https://webpack.site/", value: true), Ui.Link("www.iranux.site", "https://www.iranux.site/", value: true), Ui.Text(UiKey.AboutCopyright, secondary: true)), Ui.Section(UiText.Get(UiKey.License), Ui.Text(UiKey.LicenseSummary), Ui.Actions(Ui.Button(UiText.Get(UiKey.ReadLicense), () => ShowDocumentAsync(UiText.Get(UiKey.License), "LICENSE.txt")), Ui.Button(UiText.Get(UiKey.ThirdPartyNotices), () => ShowDocumentAsync(UiText.Get(UiKey.ThirdPartyNotices), "THIRD_PARTY_NOTICES.md")))));
			void ShowLogo()
			{
				logo.Source = new SvgImageSource(new System.Uri((logo.ActualTheme == ElementTheme.Dark) ? "ms-appx:///Assets/Branding/diyar-logo-light.svg" : "ms-appx:///Assets/Branding/diyar-logo-navy.svg"));
			}
		}

		private async Task ShowDocumentAsync(string title, string filename)
		{
			string path = System.IO.Path.Combine(AppContext.BaseDirectory, filename);
			TextBlock textBlock = ((!File.Exists(path)) ? Ui.Text(UiKey.DocumentMissing) : Ui.Value(await File.ReadAllTextAsync(path)));
			TextBlock textBlock2 = textBlock;
			textBlock2.IsTextSelectionEnabled = true;
			await Dialog(title, new ScrollViewer
			{
				Content = textBlock2,
				MaxHeight = 440.0,
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
			}, null, UiText.Get(UiKey.Close));
		}

		private void SaveTypingMode(TypingMode newMode)
		{
			Session.Save((AppSettings s) =>
			{
				AppSettings appSettings = s with
				{
					General = s.General with
					{
						TypingMode = newMode,
						ShiftLanguageSwitchEnabled = (newMode == TypingMode.ShiftLanguageSwitch)
					}
				};
				AppSettings appSettings2 = appSettings;
				appSettings2.Correction = newMode switch
				{
					TypingMode.AutomaticCorrection => s.Correction with
					{
						Mode = CorrectionMode.Automatic
					}, 
					TypingMode.ManualCorrection => s.Correction with
					{
						Mode = CorrectionMode.Manual
					}, 
					_ => s.Correction, 
				};
				return appSettings;
			});
			ShowSettings(_settingsTab);
		}

		private Microsoft.UI.Xaml.UIElement TypingPage()
		{
			AppSettings settings = Session.Settings;
			TypingMode mode = settings.General.TypingMode;
			int num = Array.FindIndex(PrimaryModes, ((TypingMode Mode, UiKey Label, UiKey Description) option) => option.Mode == mode);
			int num2 = Array.FindIndex(OtherModes, ((TypingMode Mode, UiKey Label, UiKey Description) option) => option.Mode == mode);
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice(UiText.Get(UiKey.TypingMode), PrimaryModes.Select(((TypingMode Mode, UiKey Label, UiKey Description) option) => UiText.Get(option.Label)), num, (int index) =>
			{
				SaveTypingMode(PrimaryModes[index].Mode);
			});
			if (num < 0)
			{
				comboBox.PlaceholderText = UiText.Get(UiKey.AnotherModeSelected);
			}
			Microsoft.UI.Xaml.Controls.ComboBox comboBox2 = Ui.Choice(UiText.Get(UiKey.OtherMode), OtherModes.Select(((TypingMode Mode, UiKey Label, UiKey Description) option) => UiText.Get(option.Label)), num2, (int index) =>
			{
				SaveTypingMode(OtherModes[index].Mode);
			});
			if (num2 < 0)
			{
				comboBox2.PlaceholderText = UiText.Get(UiKey.NotInUse);
			}
			UiKey key;
			if (num >= 0)
			{
				key = PrimaryModes[num].Description;
			}
			else
			{
				key = ((num2 >= 0) ? OtherModes[num2].Description : PrimaryModes[0].Description);
			}
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			list.Add(Ui.Section(UiText.Get(UiKey.TypingMode), HelpButton(HelpTopic.TypingModes), new Microsoft.UI.Xaml.UIElement[4]
			{
				comboBox,
				Ui.Text(key, secondary: true),
				Ui.Text(UiKey.OnlyOneModeActive, secondary: true),
				Ui.Expander(UiText.Get(UiKey.OtherModes), num2 >= 0, comboBox2, Ui.Text(UiKey.OtherModesExplanation, secondary: true))
			}));
			List<Microsoft.UI.Xaml.UIElement> list2 = list;
			switch (mode)
			{
			case TypingMode.AutomaticCorrection:
			case TypingMode.ManualCorrection:
				list2.Add(CorrectionModeCard(settings, mode));
				break;
			case TypingMode.CapsLockSwitch:
				list2.Add(CapsLockModeCard(settings));
				break;
			case TypingMode.ShiftLanguageSwitch:
				list2.Add(ShiftSwitchModeCard(settings));
				break;
			}
			list2.Add(EnglishOnlyPlacesSection(settings));
			list2.Add(KeyboardSection(settings));
			return Ui.Page(list2.ToArray());
		}

		private Microsoft.UI.Xaml.UIElement EnglishOnlyPlacesSection(AppSettings settings)
		{
			CorrectionSettings correction = settings.Correction;
			ToggleSwitch toggleSwitch = Ui.Toggle(UiText.Get(UiKey.PlacePasswordField), value: true, (bool _) =>
			{
			}, UiText.Get(UiKey.PlacePasswordFieldTip));
			toggleSwitch.IsEnabled = false;
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			list.Add(Ui.Text(UiKey.EnglishOnlyPlacesIntro, secondary: true));
			list.Add(Ui.Group(UiText.Get(UiKey.EnglishOnlyFields), null, PlaceToggle(correction, "field:browser-address-bar", UiText.Get(UiKey.PlaceBrowserAddressBar), UiText.Get(UiKey.PlaceBrowserAddressBarTip)), PlaceToggle(correction, "field:web-address", UiText.Get(UiKey.PlaceWebAddressField), UiText.Get(UiKey.PlaceWebAddressFieldTip)), Ui.Toggle(UiText.Get(UiKey.PlacePaymentCardField), correction.ProtectPaymentFields, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						ProtectPaymentFields = value
					}
				});
			}, UiText.Get(UiKey.PlacePaymentCardFieldTip)), toggleSwitch, Ui.Text(UiKey.EnglishOnlyFieldsNote, secondary: true)));
			List<Microsoft.UI.Xaml.UIElement> list2 = list;
			List<Microsoft.UI.Xaml.UIElement> list3 = new List<Microsoft.UI.Xaml.UIElement> { Ui.Text(UiKey.EnglishOnlyApplicationsNote, secondary: true) };
			(EnglishOnlyPlaceGroup, UiKey)[] applicationGroups = ApplicationGroups;
			for (int num = 0; num < applicationGroups.Length; num++)
			{
				(EnglishOnlyPlaceGroup, UiKey) tuple = applicationGroups[num];
				EnglishOnlyPlaceGroup group = tuple.Item1;
				UiKey item = tuple.Item2;
				List<EnglishOnlyPlace> source = EnglishOnlyPlaces.Applications.Where((EnglishOnlyPlace place) => place.Group == group).ToList();
				int num2 = Enumerable.Count(source, (EnglishOnlyPlace place) => !EnglishOnlyPlaces.KeepsEnglish(correction, place.Id));
				list3.Add(Ui.Expander(UiText.Get(item), num2 > 0, ((IEnumerable<EnglishOnlyPlace>)source).Select((Func<EnglishOnlyPlace, Microsoft.UI.Xaml.UIElement>)((EnglishOnlyPlace place) => PlaceToggle(correction, place.Id, place.ProductName, null, latin: true))).ToArray()));
			}
			list2.Add(Ui.Group(UiText.Get(UiKey.EnglishOnlyApplications), null, list3.ToArray()));
			return Ui.Section(UiText.Get(UiKey.EnglishOnlyPlacesTitle), HelpButton(HelpTopic.AutomaticCorrection), list2.ToArray());
		}

		private ToggleSwitch PlaceToggle(CorrectionSettings correction, string placeId, string label, string? tooltip, bool latin = false)
		{
			return Ui.Toggle(label, EnglishOnlyPlaces.KeepsEnglish(correction, placeId), (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						EnglishOnlyPlacesTurnedOff = EnglishOnlyPlaces.WithPlace(s.Correction.EnglishOnlyPlacesTurnedOff, placeId, value)
					}
				});
			}, tooltip, latin);
		}

		private Microsoft.UI.Xaml.UIElement KeyboardSection(AppSettings settings)
		{
			GeneralSettings general = settings.General;
			IReadOnlyList<InstalledKeyboardLayout> installed = KeyboardLayoutInventory.GetInstalled(refresh: true);
			KeyboardLayoutPair keyboardLayoutPair = KeyboardLayoutInventory.ResolvePair(installed, general.PreferredEnglishLayoutId, general.PreferredPersianLayoutId, general.PersianKeyboardLayout);
			PersianKeyboardLayout mapping = KeyboardLayoutInventory.ResolveMapping(general.PersianKeyboardLayout, keyboardLayoutPair.Persian);
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			list.Add(Ui.Choice(UiText.Get(UiKey.PersianKeyboardLayout), new <>z__ReadOnlyArray<string>(new string[3]
			{
				UiText.Get(UiKey.DetectInstalledLayout),
				UiText.Get(UiKey.PersianStandardLayout),
				UiText.Get(UiKey.WindowsPersianLayout)
			}), (int)general.PersianKeyboardLayout, (int value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						PersianKeyboardLayout = (PersianKeyboardLayout)value
					}
				});
			}));
			list.Add(Ui.Text(MappingSentence(mapping), secondary: true));
			List<Microsoft.UI.Xaml.UIElement> list2 = list;
			string text = UiText.Get(UiKey.NotInstalled);
			list2.Add(Ui.Rich(UiKey.LayoutsInUse, true, keyboardLayoutPair.English?.DisplayName ?? text, keyboardLayoutPair.Persian?.DisplayName ?? text));
			AddDefaultLayoutChoice(list2, installed, ActiveLanguage.English, UiText.Get(UiKey.DefaultEnglishLayout), general.PreferredEnglishLayoutId, (string? klid) =>
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						PreferredEnglishLayoutId = klid
					}
				});
			});
			AddDefaultLayoutChoice(list2, installed, ActiveLanguage.Persian, UiText.Get(UiKey.DefaultPersianLayout), general.PreferredPersianLayoutId, (string? klid) =>
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						PreferredPersianLayoutId = klid
					}
				});
			});
			if (!keyboardLayoutPair.HasEnglish)
			{
				list2.Add(MissingLayout(UiKey.EnglishNotInstalled, KeyboardLayoutInventory.InstallableEnglish));
			}
			if (!keyboardLayoutPair.HasPersian)
			{
				list2.Add(MissingLayout(UiKey.PersianNotInstalled, KeyboardLayoutInventory.InstallablePersian));
			}
			return Ui.Section(UiText.Get(UiKey.Keyboard), HelpButton(HelpTopic.KeyboardLayout), list2.ToArray());
		}

		private static UiKey MappingSentence(PersianKeyboardLayout mapping)
		{
			return mapping switch
			{
				PersianKeyboardLayout.PersianStandard => UiKey.KeysTypeAsPersianStandard, 
				PersianKeyboardLayout.Persian => UiKey.KeysTypeAsWindowsPersian, 
				_ => UiKey.KeysTypeAsEitherLayout, 
			};
		}

		private static void AddDefaultLayoutChoice(List<Microsoft.UI.Xaml.UIElement> content, IReadOnlyList<InstalledKeyboardLayout> installed, ActiveLanguage language, string label, string? preferred, Action<string?> save)
		{
			List<InstalledKeyboardLayout> layouts = installed.Where((InstalledKeyboardLayout layout) => layout.Language == language).ToList();
			if (layouts.Count >= 2)
			{
				int selected = layouts.FindIndex((InstalledKeyboardLayout layout) => string.Equals(layout.Klid, preferred, StringComparison.OrdinalIgnoreCase)) + 1;
				List<string> list = new List<string>();
				list.Add(UiText.Get(UiKey.Automatic));
				list.AddRange(layouts.Select((InstalledKeyboardLayout layout) => layout.DisplayName));
				content.Add(Ui.Choice(label, new <>z__ReadOnlyList<string>(list), selected, (int index) =>
				{
					save((index == 0) ? null : layouts[index - 1].Klid);
				}));
			}
		}

		private Microsoft.UI.Xaml.UIElement MissingLayout(UiKey explanation, IReadOnlyList<InstallableKeyboardLayout> choices)
		{
			int selected = 0;
			Microsoft.UI.Xaml.Controls.ComboBox left = Ui.Choice(UiText.Get(UiKey.LayoutToInstall), choices.Select((InstallableKeyboardLayout layout) => layout.DisplayName).ToArray(), 0, (int index) =>
			{
				selected = index;
			});
			return Ui.Stack(Ui.Text(explanation), Ui.Pair(left, Ui.Button(UiText.Get(UiKey.Install), () =>
			{
				bool flag = KeyboardLayoutInventory.TryInstall(choices[selected], out string message);
				Notice(message, flag ? InfoBarSeverity.Success : InfoBarSeverity.Error);
				ShowSettings(1);
				return Task.CompletedTask;
			}, primary: true, Symbol.Download)));
		}

		private static string[] EnglishHoldKeyLabels()
		{
			return new string[8]
			{
				UiText.Get(UiKey.Off),
				UiText.Get(UiKey.KeyLeftShift),
				UiText.Get(UiKey.KeyRightShift),
				UiText.Get(UiKey.KeyLeftCtrl),
				UiText.Get(UiKey.KeyRightCtrl),
				UiText.Get(UiKey.KeyLeftAlt),
				UiText.Get(UiKey.KeyRightAlt),
				"Caps Lock"
			};
		}

		private Microsoft.UI.Xaml.UIElement[] PriorityOptions(AppSettings settings)
		{
			int num = Math.Max(0, Array.IndexOf(PriorityValues, settings.Correction.AmbiguousInputPriority));
			TextBlock note = Ui.Rich(PriorityOptions_[num].Description, true, "Shift+7");
			note.TextWrapping = TextWrapping.Wrap;
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Named(Ui.Choice(string.Empty, PriorityOptions_.Select(((UiKey Label, UiKey Description) option) => UiText.Get(option.Label)), num, (int index) =>
			{
				AmbiguousInputPriority priority = PriorityValues[index];
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						AmbiguousInputPriority = priority
					}
				});
				Ui.SetRich(note, PriorityOptions_[index].Description, "Shift+7");
			}), UiText.Get(UiKey.PriorityForAmbiguousInput));
			TextBlock textBlock = Ui.Text(UiKey.PriorityScope, secondary: true);
			return new Microsoft.UI.Xaml.UIElement[1] { Ui.Group(UiText.Get(UiKey.PriorityForAmbiguousInput), null, comboBox, note, textBlock) };
		}

		private Microsoft.UI.Xaml.UIElement[] WordFormOptions(AppSettings settings)
		{
			int num = Math.Max(0, Array.IndexOf(WordFormValues, settings.Correction.WordFormRecognition));
			TextBlock note = Ui.Text(WordFormOptions_[num].Description, secondary: true);
			note.TextWrapping = TextWrapping.Wrap;
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Named(Ui.Choice(string.Empty, WordFormOptions_.Select(((UiKey Label, UiKey Description) option) => UiText.Get(option.Label)), num, (int index) =>
			{
				WordFormRecognition wordForms = WordFormValues[index];
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						WordFormRecognition = wordForms
					}
				});
				note.Text = UiText.Get(WordFormOptions_[index].Description);
			}), UiText.Get(UiKey.WordFormsChoice));
			ToolTipService.SetToolTip(comboBox, Ui.Tip(UiText.Get(UiKey.WordFormsTip)));
			return new Microsoft.UI.Xaml.UIElement[1] { Ui.Group(UiText.Get(UiKey.WordForms), HelpButton(HelpTopic.AutomaticCorrection), comboBox, note) };
		}

		private Microsoft.UI.Xaml.UIElement[] HoldKeyOptions(AppSettings settings, TypingMode mode)
		{
			HoldKeyBindings bindings = HoldKeyBindings.From(settings.Correction);
			if (mode == TypingMode.ManualCorrection)
			{
				return DirectTypingHoldOptions(settings, bindings);
			}
			EnglishHoldKey english = bindings.English;
			EnglishHoldKey persian = bindings.Persian;
			TextBlock englishNote = Ui.Text(string.Empty, secondary: true);
			englishNote.TextWrapping = TextWrapping.Wrap;
			TextBlock persianNote = Ui.Text(string.Empty, secondary: true);
			persianNote.TextWrapping = TextWrapping.Wrap;
			ToggleSwitch capital = CapitalizeEnglishToggle(settings);
			capital.IsEnabled = english != EnglishHoldKey.None;
			ToggleSwitch heldBoundary = HeldBoundaryToggle(settings);
			heldBoundary.IsEnabled = EndsLockAtHeldBoundary(english);
			Microsoft.UI.Xaml.Controls.ComboBox left = Ui.Named(Ui.Choice(UiText.Get(UiKey.HoldKeyForEnglish), EnglishHoldKeyLabels(), (int)english, (int index) =>
			{
				if (HoldKeyBindings.Conflict((EnglishHoldKey)index, persian))
				{
					throw new InvalidOperationException(UiText.Get(UiKey.HoldKeysConflict));
				}
				english = (EnglishHoldKey)index;
				SaveHoldKeys(english, persian);
				capital.IsEnabled = english != EnglishHoldKey.None;
				heldBoundary.IsEnabled = EndsLockAtHeldBoundary(english);
				ShowNotes();
			}), UiText.Get(UiKey.HoldKeyForEnglish));
			Microsoft.UI.Xaml.Controls.ComboBox right = Ui.Named(Ui.Choice(UiText.Get(UiKey.HoldKeyForPersian), EnglishHoldKeyLabels(), (int)persian, (int index) =>
			{
				if (HoldKeyBindings.Conflict(english, (EnglishHoldKey)index))
				{
					throw new InvalidOperationException(UiText.Get(UiKey.HoldKeysConflict));
				}
				persian = (EnglishHoldKey)index;
				SaveHoldKeys(english, persian);
				ShowNotes();
			}), UiText.Get(UiKey.HoldKeyForPersian));
			ShowNotes();
			TextBlock textBlock = Ui.Text(UiKey.AutomaticCapsLockRule, secondary: true);
			textBlock.TextWrapping = TextWrapping.Wrap;
			return new Microsoft.UI.Xaml.UIElement[1] { Ui.Group(UiText.Get(UiKey.CapsLockAndHoldKey), null, Ui.Pair(left, right), englishNote, persianNote, capital, ShortcutsToggle(settings), heldBoundary, textBlock) };
			void ShowNotes()
			{
				if (english == EnglishHoldKey.None && persian == EnglishHoldKey.None)
				{
					Ui.SetRich(englishNote, UiKey.HoldNoteOff);
					englishNote.Visibility = Visibility.Visible;
					persianNote.Visibility = Visibility.Collapsed;
				}
				else
				{
					englishNote.Visibility = ((english == EnglishHoldKey.None) ? Visibility.Collapsed : Visibility.Visible);
					persianNote.Visibility = ((persian == EnglishHoldKey.None) ? Visibility.Collapsed : Visibility.Visible);
					if (english != EnglishHoldKey.None)
					{
						ShowHoldNote(englishNote, HoldNote(english, HoldLanguage.English), english);
					}
					if (persian != EnglishHoldKey.None)
					{
						ShowHoldNote(persianNote, HoldNote(persian, HoldLanguage.Persian), persian);
					}
				}
			}
		}

		private void SaveHoldKeys(EnglishHoldKey english, EnglishHoldKey persian)
		{
			Session.Save((AppSettings s) => s with
			{
				Correction = s.Correction with
				{
					EnglishHoldKey = english,
					PersianHoldKey = persian,
					HoldLanguage = HoldLanguage.English
				}
			});
		}

		private ToggleSwitch ShortcutsToggle(AppSettings settings)
		{
			return Ui.Toggle(UiText.Get(UiKey.HoldKeyYieldsToShortcuts), settings.Correction.HoldKeyYieldsToShortcuts, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						HoldKeyYieldsToShortcuts = value
					}
				});
			}, UiText.Get(UiKey.HoldKeyYieldsToShortcutsTip));
		}

		private ToggleSwitch HeldBoundaryToggle(AppSettings settings)
		{
			return Ui.Toggle(UiText.Get(UiKey.HeldBoundaryEndsEnglishLock), settings.Correction.HeldBoundaryEndsEnglishLock, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						HeldBoundaryEndsEnglishLock = value
					}
				});
			}, UiText.Get(UiKey.HeldBoundaryEndsEnglishLockTip));
		}

		private static bool EndsLockAtHeldBoundary(EnglishHoldKey english)
		{
			bool flag = ((english == EnglishHoldKey.None || english == EnglishHoldKey.CapsLock) ? true : false);
			return !flag;
		}

		private ToggleSwitch CapitalizeEnglishToggle(AppSettings settings)
		{
			return Ui.Toggle(UiText.Get(UiKey.CapitalizeEnglishAfterPersian), settings.Correction.CapitalizeEnglishAfterPersian, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						CapitalizeEnglishAfterPersian = value
					}
				});
			}, UiText.Get(UiKey.CapitalizeEnglishTip));
		}

		private Microsoft.UI.Xaml.UIElement[] DirectTypingHoldOptions(AppSettings settings, HoldKeyBindings bindings)
		{
			EnglishHoldKey english = bindings.English;
			EnglishHoldKey persian = bindings.Persian;
			TextBlock note = Ui.Text(string.Empty, secondary: true);
			note.TextWrapping = TextWrapping.Wrap;
			ShowHoldNote(note, DirectHoldNote(english), english);
			InfoBar warning = Ui.Warning(string.Empty, UiText.Get(UiKey.HoldKeyWarning));
			Microsoft.UI.Xaml.Controls.ComboBox keyChoice = null;
			Microsoft.UI.Xaml.Controls.Button useEnglish = null;
			useEnglish = Ui.Button(UiText.Get(UiKey.UseItForEnglish), () =>
			{
				EnglishHoldKey englishHoldKey = persian;
				persian = EnglishHoldKey.None;
				english = englishHoldKey;
				SaveHoldKeys(english, persian);
				if ((object)keyChoice != null)
				{
					keyChoice.SelectedIndex = (int)english;
				}
				UpdateWarning();
				return Task.CompletedTask;
			});
			ToolTipService.SetToolTip(useEnglish, Ui.Tip(UiText.Get(UiKey.UseItForEnglishTip)));
			ToggleSwitch capital = CapitalizeEnglishToggle(settings);
			capital.IsEnabled = english != EnglishHoldKey.None;
			ToggleSwitch heldBoundary = HeldBoundaryToggle(settings);
			heldBoundary.IsEnabled = EndsLockAtHeldBoundary(english);
			keyChoice = Ui.Named(Ui.Choice(UiText.Get(UiKey.HoldKeyForEnglish), EnglishHoldKeyLabels(), (int)english, (int index) =>
			{
				if (HoldKeyBindings.Conflict((EnglishHoldKey)index, persian))
				{
					throw new InvalidOperationException(UiText.Get(UiKey.HoldKeysConflict));
				}
				english = (EnglishHoldKey)index;
				SaveHoldKeys(english, persian);
				capital.IsEnabled = english != EnglishHoldKey.None;
				heldBoundary.IsEnabled = EndsLockAtHeldBoundary(english);
				ShowHoldNote(note, DirectHoldNote(english), english);
				UpdateWarning();
			}), UiText.Get(UiKey.HoldKeyForTypingEnglish));
			UpdateWarning();
			TextBlock textBlock = Ui.Text(UiKey.DirectCapsLockRule, secondary: true);
			textBlock.TextWrapping = TextWrapping.Wrap;
			return new Microsoft.UI.Xaml.UIElement[1] { Ui.Group(UiText.Get(UiKey.CapsLockAndHoldKey), null, keyChoice, note, warning, capital, ShortcutsToggle(settings), heldBoundary, textBlock) };
			void UpdateWarning()
			{
				if (english == EnglishHoldKey.None && persian == EnglishHoldKey.None)
				{
					warning.Message = UiText.Get(UiKey.NoHoldKeyWarning);
					warning.ActionButton = null;
					warning.IsOpen = true;
				}
				else if (english == EnglishHoldKey.None)
				{
					warning.Message = UiText.Get(UiKey.HoldKeyTypesPersianWarning);
					warning.ActionButton = useEnglish;
					warning.IsOpen = true;
				}
				else
				{
					warning.ActionButton = null;
					warning.IsOpen = false;
				}
			}
		}

		private static UiKey HoldNote(EnglishHoldKey key, HoldLanguage language)
		{
			switch (key)
			{
			case EnglishHoldKey.None:
				return UiKey.HoldNoteOff;
			case EnglishHoldKey.CapsLock:
				if (language == HoldLanguage.Persian)
				{
					return UiKey.HoldNoteCapsLockPersian;
				}
				return UiKey.HoldNoteCapsLockEnglish;
			default:
				if (language == HoldLanguage.Persian)
				{
					return UiKey.HoldNoteKeyPersian;
				}
				return UiKey.HoldNoteKeyEnglish;
			}
		}

		private static UiKey DirectHoldNote(EnglishHoldKey key)
		{
			return key switch
			{
				EnglishHoldKey.None => UiKey.DirectHoldNoteNone, 
				EnglishHoldKey.CapsLock => UiKey.DirectHoldNoteCapsLock, 
				_ => UiKey.DirectHoldNoteKey, 
			};
		}

		private static void ShowHoldNote(TextBlock note, UiKey sentence, EnglishHoldKey key)
		{
			if ((key == EnglishHoldKey.None || key == EnglishHoldKey.CapsLock) ? true : false)
			{
				Ui.SetRich(note, sentence);
				return;
			}
			Ui.SetRich(note, sentence, EnglishHoldKeyLabels()[(int)key]);
			note.Inlines.Add(new Run
			{
				Text = " " + UiText.Get(UiKey.ModifierKeyNote)
			});
		}

		private Microsoft.UI.Xaml.UIElement CorrectionModeCard(AppSettings settings, TypingMode mode)
		{
			bool flag = mode == TypingMode.ManualCorrection;
			string title = UiText.Get(flag ? UiKey.ModePersianTypingDirect : UiKey.CorrectionBehavior);
			Microsoft.UI.Xaml.Controls.Button headerAction = HelpButton(flag ? HelpTopic.ManualTyping : HelpTopic.AutomaticCorrection);
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			list.Add(Ui.Text(flag ? UiKey.DirectTypingCardText : UiKey.AutomaticCorrectionCardText, secondary: true));
			list.AddRange(HoldKeyOptions(settings, mode));
			list.AddRange((mode == TypingMode.AutomaticCorrection) ? PriorityOptions(settings) : Array.Empty<Microsoft.UI.Xaml.UIElement>());
			list.AddRange((mode == TypingMode.AutomaticCorrection) ? WordFormOptions(settings) : Array.Empty<Microsoft.UI.Xaml.UIElement>());
			list.Add(Ui.Group(UiText.Get(UiKey.Spelling), null, Ui.Toggle(UiText.Get(UiKey.CorrectPersianTypos), settings.Correction.CorrectPersianTypos, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						CorrectPersianTypos = value
					}
				});
			})));
			list.AddRange((mode != TypingMode.AutomaticCorrection) ? Array.Empty<Microsoft.UI.Xaml.UIElement>() : new Microsoft.UI.Xaml.UIElement[2]
			{
				LayoutChangeGroup(settings),
				PersianDigitsGroup(settings)
			});
			list.Add(flag ? TextDirectionGroup(settings, amounts: false, UiKey.DirectTypingAmountNote) : TextDirectionGroup(settings, amounts: true));
			list.Add(Ui.Group(UiText.Get(UiKey.KeysThatFinishAWord), null, Ui.Rich(UiKey.KeysThatFinishAWordNote, true, ". ! ?"), Ui.Pair(Ui.Toggle(UiText.Get(UiKey.SpaceKey), settings.Correction.CorrectOnSpace, (bool value) =>
			{
				SaveFinishingKey((CorrectionSettings s) => s with
				{
					CorrectOnSpace = value
				});
			}), Ui.Toggle("Enter", settings.Correction.CorrectOnEnter, (bool value) =>
			{
				SaveFinishingKey((CorrectionSettings s) => s with
				{
					CorrectOnEnter = value
				});
			})), Ui.Toggle("Tab", settings.Correction.CorrectOnTab, (bool value) =>
			{
				SaveFinishingKey((CorrectionSettings s) => s with
				{
					CorrectOnTab = value
				});
			})));
			return Ui.Card(title, headerAction, list.ToArray());
		}

		private Microsoft.UI.Xaml.UIElement PersianDigitsGroup(AppSettings settings)
		{
			return Ui.Group(UiText.Get(UiKey.Numbers), null, Ui.Toggle(UiText.Get(UiKey.PersianDigitsInPersianText), settings.Correction.PersianDigitsInPersianText, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						PersianDigitsInPersianText = value
					}
				});
			}, UiText.Get(UiKey.PersianDigitsTip)), Ui.Rich(UiKey.PersianDigitsNote, true, "Enter", "Tab", "3.5"));
		}

		private Microsoft.UI.Xaml.UIElement LayoutChangeGroup(AppSettings settings)
		{
			ToggleSwitch toggleSwitch = Ui.Toggle(UiText.Get(UiKey.StartNewWordAfterLayoutSwitch), settings.Correction.ResetWordOnLayoutChange, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						ResetWordOnLayoutChange = value
					}
				});
			}, UiText.Get(UiKey.StartNewWordAfterLayoutSwitchTip));
			return Ui.Group(UiText.Get(UiKey.KeyboardLayoutGroup), null, toggleSwitch, Ui.Text(UiKey.LayoutSwitchNote, secondary: true));
		}

		private void SaveFinishingKey(Func<CorrectionSettings, CorrectionSettings> change)
		{
			Session.Save((AppSettings s) =>
			{
				CorrectionSettings correctionSettings = change(s.Correction);
				if (!correctionSettings.CorrectOnSpace && !correctionSettings.CorrectOnEnter && !correctionSettings.CorrectOnTab)
				{
					throw new InvalidOperationException(UiText.Get(UiKey.AtLeastOneFinishingKey));
				}
				return s with
				{
					Correction = correctionSettings
				};
			});
		}

		private static List<(string Label, CapsLockBehavior? Behavior)> CapsLockActions(CapsLockBehavior stored, bool typesDirectly)
		{
			List<(string, CapsLockBehavior?)> list = new List<(string, CapsLockBehavior?)>
			{
				(UiText.Get(UiKey.CapsLockSwitchLanguage), null),
				(UiText.Get(typesDirectly ? UiKey.CapsLockDirectWhileOn : UiKey.CapsLockManualWhileOn), CapsLockBehavior.ManualCorrectionWhileOn)
			};
			if (stored == CapsLockBehavior.AutomaticCorrectionWhileOn)
			{
				list.Insert(1, (UiText.Get(UiKey.CapsLockAutomaticWhileOnLegacy), CapsLockBehavior.AutomaticCorrectionWhileOn));
			}
			return list;
		}

		private static UiKey CapsLockActionDescription(CapsLockBehavior behavior, bool typesDirectly)
		{
			switch (behavior)
			{
			case CapsLockBehavior.AutomaticCorrectionWhileOn:
				return UiKey.CapsLockAutomaticDescription;
			case CapsLockBehavior.ManualCorrectionWhileOn:
				if (typesDirectly)
				{
					return UiKey.CapsLockDirectDescription;
				}
				return UiKey.CapsLockManualDescription;
			default:
				return UiKey.CapsLockSwitchDescription;
			}
		}

		private Microsoft.UI.Xaml.UIElement CapsLockModeCard(AppSettings settings)
		{
			CapsLockBehavior behavior = CapsLockBehaviorPolicy.Normalize(settings.General.CapsLockBehavior);
			bool capsLockManualTypesDirectly = settings.Correction.CapsLockManualTypesDirectly;
			TextBlock textBlock = Ui.Text(CapsLockActionDescription(behavior, capsLockManualTypesDirectly), secondary: true);
			textBlock.TextWrapping = TextWrapping.Wrap;
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice(UiText.Get(UiKey.WindowsLanguageWhileCapsLockOn), new <>z__ReadOnlyArray<string>(new string[2]
			{
				UiText.Get(UiKey.LanguageEnglish),
				UiText.Get(UiKey.LanguagePersian)
			}), (behavior == CapsLockBehavior.SwitchToPersian) ? 1 : 0, (int index) =>
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						CapsLockBehavior = ((index == 1) ? CapsLockBehavior.SwitchToPersian : CapsLockBehavior.SwitchToEnglish)
					}
				});
				ShowSettings(_settingsTab);
			});
			Microsoft.UI.Xaml.Controls.ComboBox right = Ui.Choice(UiText.Get(UiKey.EnglishLetterCase), new <>z__ReadOnlyArray<string>(new string[2]
			{
				UiText.Get(UiKey.NormalLetterCase),
				UiText.Get(UiKey.CapitalLetters)
			}), (settings.General.CapsLockEnglishTypingStyle != CapsLockEnglishTypingStyle.NormalCase) ? 1 : 0, (int index) =>
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						CapsLockEnglishTypingStyle = ((index == 0) ? CapsLockEnglishTypingStyle.NormalCase : CapsLockEnglishTypingStyle.CapitalLetters)
					}
				});
			});
			List<(string Label, CapsLockBehavior? Behavior)> actions = CapsLockActions(behavior, capsLockManualTypesDirectly);
			int selected = Math.Max(0, actions.FindIndex(((string Label, CapsLockBehavior? Behavior) entry) => entry.Behavior == behavior));
			Microsoft.UI.Xaml.Controls.ComboBox item = Ui.Choice(UiText.Get(UiKey.WhenCapsLockIsOn), actions.Select(((string Label, CapsLockBehavior? Behavior) entry) => entry.Label), selected, (int index) =>
			{
				CapsLockBehavior? chosen = actions[index].Behavior;
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						CapsLockBehavior = (chosen ?? (CapsLockBehaviorPolicy.IsLanguageSwitch(s.General.CapsLockBehavior) ? s.General.CapsLockBehavior : CapsLockBehavior.SwitchToEnglish))
					}
				});
				ShowSettings(_settingsTab);
			});
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement> { item, textBlock };
			if (CapsLockBehaviorPolicy.IsLanguageSwitch(behavior))
			{
				list.Add(Ui.Group(UiText.Get(UiKey.LanguageGroup), null, (behavior == CapsLockBehavior.SwitchToEnglish) ? ((Microsoft.UI.Xaml.FrameworkElement)Ui.Pair(comboBox, right)) : ((Microsoft.UI.Xaml.FrameworkElement)comboBox)));
				list.Add(Ui.Group(UiText.Get(UiKey.TextDirectionAndAmounts), HelpButton(HelpTopic.TextDirection), Ui.Text(UiKey.CapsLockSwitchNoDirection, secondary: true)));
			}
			else if ((behavior == CapsLockBehavior.ManualCorrectionWhileOn) & capsLockManualTypesDirectly)
			{
				list.Add(TextDirectionGroup(settings, amounts: false, UiKey.DirectTypingAmountNote));
			}
			else
			{
				list.Add(TextDirectionGroup(settings, amounts: true));
			}
			return Ui.Card(UiText.Get(UiKey.ModeCapsLockSwitch), HelpButton(HelpTopic.CapsLock), list.ToArray());
		}

		private Microsoft.UI.Xaml.UIElement ShiftSwitchModeCard(AppSettings settings)
		{
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice(UiText.Get(UiKey.ShiftSwitchTarget), new <>z__ReadOnlyArray<string>(new string[2]
			{
				UiText.Get(UiKey.LanguageEnglish),
				UiText.Get(UiKey.LanguagePersian)
			}), (settings.General.ShiftLanguageSwitchSecondaryLanguage == DetectedLanguage.Persian) ? 1 : 0, (int index) =>
			{
				DetectedLanguage secondary = ((index == 1) ? DetectedLanguage.Persian : DetectedLanguage.English);
				DetectedLanguage otherLanguage = ((secondary != DetectedLanguage.Persian) ? DetectedLanguage.Persian : DetectedLanguage.English);
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						ShiftLanguageSwitchSecondaryLanguage = secondary,
						ShiftLanguageSwitchDefaultLanguage = otherLanguage
					}
				});
			});
			Microsoft.UI.Xaml.Controls.ComboBox comboBox2 = Ui.Choice(UiText.Get(UiKey.SwitchKey), new <>z__ReadOnlyArray<string>(new string[2]
			{
				UiText.Get(UiKey.SwitchKeyLeftShift),
				UiText.Get(UiKey.SwitchKeyRightShift)
			}), (int)settings.General.ShiftLanguageSwitchTriggerKey, (int index) =>
			{
				Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						ShiftLanguageSwitchTriggerKey = (ShiftSwitchTriggerKey)index
					}
				});
			});
			return Ui.Card(UiText.Get(UiKey.ModeShiftSwitch), HelpButton(HelpTopic.ShiftSwitch), new Microsoft.UI.Xaml.UIElement[5]
			{
				comboBox2,
				comboBox,
				Ui.Text(UiKey.ShiftSwitchExplanation, secondary: true),
				Ui.Rich(UiKey.ShiftSwitchShiftedCharacters, true, "< > ? : \""),
				TextDirectionGroup(settings, amounts: false)
			});
		}

		private Microsoft.UI.Xaml.UIElement TextDirectionGroup(AppSettings settings, bool amounts, UiKey noAmountsNote = UiKey.NoAmountsNote)
		{
			ToggleSwitch toggleSwitch = Ui.Toggle(UiText.Get(UiKey.StabilizeMixedText), settings.Correction.StabilizeMixedDirectionText, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						StabilizeMixedDirectionText = value
					}
				});
			});
			if (!amounts)
			{
				return Ui.Group(UiText.Get(UiKey.TextDirection), HelpButton(HelpTopic.TextDirection), toggleSwitch, Ui.Text(noAmountsNote, secondary: true));
			}
			return Ui.Group(UiText.Get(UiKey.TextDirectionAndAmounts), HelpButton(HelpTopic.TextDirection), Ui.Pair(toggleSwitch, Ui.Toggle(UiText.Get(UiKey.FormatCurrencyAmounts), settings.Correction.FormatPersianAmounts, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						FormatPersianAmounts = value
					}
				});
			})));
		}

		private Microsoft.UI.Xaml.UIElement ShortcutsPage()
		{
			string[] array = ShortcutHost.Values(Session.Settings.Hotkeys);
			List<Microsoft.UI.Xaml.UIElement> list = new List<Microsoft.UI.Xaml.UIElement>();
			foreach (int activeCommand in ShortcutHost.ActiveCommands)
			{
				int id = activeCommand;
				string text = UiText.Get(ShortcutHost.Commands[id]);
				Microsoft.UI.Xaml.Controls.Button button = Ui.Button(array[id], async () =>
				{
					await RecordShortcutAsync(id);
				});
				button.MinWidth = 210.0;
				button.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Right;
				if (Ui.Persian)
				{
					button.FontFamily = Ui.ChromeFont;
					button.FlowDirection = Microsoft.UI.Xaml.FlowDirection.LeftToRight;
				}
				Ui.Named(button, UiText.Format(UiKey.ChangeShortcutName, text));
				list.Add(Ui.Pair(Ui.Text(text), button));
			}
			list.Add(Ui.Text(UiKey.ShortcutsHandledInApps, secondary: true));
			bool textServiceInstalled = TypingSession.TextServiceInstalled;
			ToggleSwitch item = Ui.Toggle(UiText.Get(UiKey.SaveSelectedWordCorrections), Session.Settings.SavesSelectedWordCorrections, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					SelectedWord = s.SelectedWord with
					{
						SaveToPersonalDictionary = value
					}
				});
			});
			List<Microsoft.UI.Xaml.UIElement> list2 = new List<Microsoft.UI.Xaml.UIElement>
			{
				Ui.Text(UiKey.ConvertSelectedWordExplanation, secondary: true),
				Ui.Text(textServiceInstalled ? UiKey.TextServiceWorks : UiKey.TextServiceNotInstalled, secondary: true),
				item,
				Ui.Text(UiKey.WhenOffNoWordAdded, secondary: true)
			};
			ToggleSwitch item2 = Ui.Toggle(UiText.Get(UiKey.EnableToggleLastWord), Session.Settings.LastWord.Enabled, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					LastWord = s.LastWord with
					{
						Enabled = value
					}
				});
			});
			ToggleSwitch item3 = Ui.Toggle(UiText.Get(UiKey.SaveLastWordCorrections), Session.Settings.SavesLastWordCorrections, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					LastWord = s.LastWord with
					{
						SaveToPersonalDictionary = value
					}
				});
			});
			List<Microsoft.UI.Xaml.UIElement> list3 = new List<Microsoft.UI.Xaml.UIElement>();
			list3.Add(Ui.Rich(UiKey.ToggleLastWordExplanation, true, Session.Settings.Hotkeys.ConvertPreviousWord));
			list3.Add(item2);
			list3.Add(item3);
			list3.Add(Ui.Text(UiKey.NonDictionaryWordsUnavailable, secondary: true));
			List<Microsoft.UI.Xaml.UIElement> list4 = list3;
			return Ui.Page(Ui.Section(UiText.Get(UiKey.CommandConvertSelectedWord), list2.ToArray()), Ui.Section(UiText.Get(UiKey.CommandToggleLastWord), list4.ToArray()), Ui.Section(UiText.Get(UiKey.KeyboardShortcuts), HelpButton(HelpTopic.Shortcuts), list.ToArray()));
		}

		internal async Task RecordShortcutAsync(int command)
		{
			if (_dialogOpen)
			{
				return;
			}
			_dialogOpen = true;
			Shortcuts?.Suspend(value: true);
			HotkeySettings original = Session.Settings.Hotkeys;
			string value = "";
			Microsoft.UI.Xaml.Controls.TextBox recording = Ui.Input(UiText.Get(UiKey.NewShortcut), "", latin: true);
			recording.IsReadOnly = true;
			recording.PlaceholderText = UiText.Get(UiKey.PressKeyCombination);
			InfoBar error = Ui.Localize(new InfoBar
			{
				IsClosable = false,
				Severity = InfoBarSeverity.Warning
			});
			ContentDialog dialog = Ui.Localize(new ContentDialog
			{
				XamlRoot = Root.XamlRoot,
				Title = UiText.Get(ShortcutHost.Commands[command]),
				PrimaryButtonText = UiText.Get(UiKey.SaveShortcut),
				IsPrimaryButtonEnabled = false,
				CloseButtonText = UiText.Get(UiKey.Cancel),
				DefaultButton = ContentDialogButton.None,
				FlowDirection = Root.FlowDirection,
				Content = Ui.Stack(Ui.Text(UiKey.RecorderInstructions), Ui.Rich(UiKey.CurrentShortcut, true, ShortcutHost.Values(original)[command]), recording, error)
			});
			dialog.Opened += (ContentDialog _, ContentDialogOpenedEventArgs _) =>
			{
				recording.Focus(FocusState.Programmatic);
			};
			recording.PreviewKeyDown += Capture;
			ActiveDialog = dialog;
			dialog.PrimaryButtonClick += (ContentDialog _, ContentDialogButtonClickEventArgs e) =>
			{
				string[] values = ShortcutHost.Values(original);
				values[command] = value;
				HotkeySettings updated = ShortcutHost.SettingsFrom(values);
				string[] array = ShortcutHost.ActiveCommands.Select((int index) => values[index]).ToArray();
				if (array.Distinct(StringComparer.OrdinalIgnoreCase).Count() != array.Length)
				{
					error.Message = UiText.Get(UiKey.ShortcutInUse);
					error.IsOpen = true;
					e.Cancel = true;
				}
				else
				{
					if (Shortcuts == null || Shortcuts.Register(updated, out string error2))
					{
						try
						{
							Session.Save((AppSettings s) => s with
							{
								Hotkeys = updated
							});
							return;
						}
						catch (System.Exception ex)
						{
							error.Message = ex.Message;
							error.IsOpen = true;
							e.Cancel = true;
							return;
						}
					}
					error.Message = error2;
					error.IsOpen = true;
					e.Cancel = true;
				}
			};
			try
			{
				if (await dialog.ShowAsync() == ContentDialogResult.Primary)
				{
					ShowSettings(4);
					Notice(UiText.Get(UiKey.ShortcutSaved), InfoBarSeverity.Success);
				}
			}
			finally
			{
				ActiveDialog = null;
				recording.PreviewKeyDown -= Capture;
				_dialogOpen = false;
				Shortcuts?.Suspend(value: false);
			}
			void Capture(object sender, KeyRoutedEventArgs e)
			{
				VirtualKey key = e.Key;
				if ((key != VirtualKey.Tab && key != VirtualKey.Escape) || 1 == 0)
				{
					e.Handled = true;
					ModifierKeys modifierKeys = ModifierKeys.None;
					if (Down(VirtualKey.Control))
					{
						modifierKeys |= ModifierKeys.Control;
					}
					if (Down(VirtualKey.Menu))
					{
						modifierKeys |= ModifierKeys.Alt;
					}
					if (Down(VirtualKey.Shift))
					{
						modifierKeys |= ModifierKeys.Shift;
					}
					if (Down(VirtualKey.LeftWindows) || Down(VirtualKey.RightWindows))
					{
						modifierKeys |= ModifierKeys.Windows;
					}
					if (HotkeyGesture.TryFormat(KeyInterop.KeyFromVirtualKey((int)e.Key), modifierKeys, out string value2, out string _))
					{
						if (modifierKeys.HasFlag(ModifierKeys.Windows))
						{
							error.Message = UiText.Get(UiKey.NoWindowsKey);
							error.IsOpen = true;
							dialog.IsPrimaryButtonEnabled = false;
						}
						else
						{
							value = value2;
							recording.Text = value2;
							error.IsOpen = false;
							dialog.IsPrimaryButtonEnabled = true;
						}
					}
				}
			}
			static bool Down(VirtualKey key)
			{
				return InputKeyboardSource.GetKeyStateForCurrentThread(key).HasFlag(CoreVirtualKeyStates.Down);
			}
		}

		private Microsoft.UI.Xaml.UIElement TranslationPage()
		{
			TranslationSettings settings = Session.Settings.Translation;
			ContentControl providerContent = new ContentControl
			{
				HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch
			};
			Microsoft.UI.Xaml.Controls.ComboBox left = Ui.Choice(UiText.Get(UiKey.TranslationService), new <>z__ReadOnlyArray<string>(new string[2]
			{
				UiText.Get(UiKey.OnDeviceModel),
				"Microsoft Azure Translator"
			}), (settings.Provider == "azure") ? 1 : 0, (int index) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						Provider = ((index == 1) ? "azure" : "local")
					}
				});
				ProviderContent();
			});
			IReadOnlyList<TranslationLanguage> targets = TranslationLanguageCatalog.Targets;
			Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice(UiText.Get(UiKey.TargetLanguage), targets.Select((TranslationLanguage x) => x.DisplayName), targets.ToList().FindIndex((TranslationLanguage x) => x.Code == settings.TargetLanguage), (int index) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						TargetLanguage = targets[index].Code
					}
				});
			});
			ToolTipService.SetToolTip(comboBox, Ui.Tip(UiText.Get(UiKey.TranslationTargetTip)));
			ProviderContent();
			return Ui.Page(Ui.Section(UiText.Get(UiKey.TabTranslation), HelpButton(HelpTopic.Translation), new Microsoft.UI.Xaml.UIElement[3]
			{
				Ui.Toggle(UiText.Get(UiKey.EnableTranslationShortcut), settings.Enabled, (bool value) =>
				{
					Session.Save((AppSettings s) => s with
					{
						Translation = s.Translation with
						{
							Enabled = value
						}
					});
				}),
				Ui.Pair(left, comboBox),
				Ui.Rich(UiKey.TranslationShortcutsNote, true, Session.Settings.Hotkeys.TranslateSelectedText, Session.Settings.Hotkeys.TranslateClipboard)
			}), providerContent, Ui.Section(UiText.Get(UiKey.TranslatedText), Ui.Pair(Ui.Toggle(UiText.Get(UiKey.MatchParagraphDirection), settings.UpdateParagraphDirection, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						UpdateParagraphDirection = value
					}
				});
			}), Ui.Toggle(UiText.Get(UiKey.AllowUndoTranslation), settings.UndoWithUndoShortcut, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						UndoWithUndoShortcut = value
					}
				});
			})), Ui.Toggle(UiText.Get(UiKey.AllowClipboardFallback), settings.AllowClipboardFallback, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						AllowClipboardFallback = value
					}
				});
			}, UiText.Get(UiKey.AllowClipboardFallbackTip))));
			void ProviderContent()
			{
				providerContent.Content = ((Session.Settings.Translation.Provider == "azure") ? AzurePage() : LocalTranslationPage());
			}
		}

		private Microsoft.UI.Xaml.UIElement AzurePage()
		{
			PasswordBox key = Ui.Secret(UiText.Get(UiKey.ApiKey), UiText.Get(UiKey.AzureApiKey));
			Microsoft.UI.Xaml.Controls.TextBox region = Ui.Input(UiText.Get(UiKey.ResourceRegion), Session.Settings.Translation.AzureRegion, latin: true);
			InfoBar status = Ui.Localize(new InfoBar
			{
				IsOpen = true,
				IsClosable = false,
				Severity = InfoBarSeverity.Informational,
				Message = UiText.Get(Session.Translation.HasCloudCredential() ? UiKey.KeyStoredSecurely : UiKey.NoApiKeySaved)
			});
			Microsoft.UI.Xaml.Controls.Button button = Ui.Button(UiText.Get(UiKey.SaveConnection), () =>
			{
				if (!AzureTranslationConfiguration.TryNormalizeRegion(region.Text, out string normalized, out string error))
				{
					UpdateStatus(error, InfoBarSeverity.Error);
					return Task.CompletedTask;
				}
				if (key.Password.Length > 0 && !Session.Translation.SaveCloudCredential(key.Password))
				{
					UpdateStatus(UiText.Get(UiKey.KeyCouldNotBeStored), InfoBarSeverity.Error);
					return Task.CompletedTask;
				}
				if (!Session.Translation.HasCloudCredential())
				{
					UpdateStatus(UiText.Get(UiKey.EnterAzureKeyFirst), InfoBarSeverity.Warning);
					return Task.CompletedTask;
				}
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						AzureRegion = normalized
					}
				});
				key.Password = "";
				region.Text = normalized;
				UpdateStatus(UiText.Get(UiKey.ConnectionSaved), InfoBarSeverity.Success);
				return Task.CompletedTask;
			}, primary: true, Symbol.Save);
			Microsoft.UI.Xaml.Controls.Button button2 = Ui.Button(UiText.Get(UiKey.TestConnection), async () =>
			{
				if (!string.Equals(region.Text.Trim(), Session.Settings.Translation.AzureRegion, StringComparison.OrdinalIgnoreCase) || key.Password.Length > 0)
				{
					UpdateStatus(UiText.Get(UiKey.SaveBeforeTesting), InfoBarSeverity.Warning);
				}
				else
				{
					UpdateStatus(UiText.Get(UiKey.TestingConnection), InfoBarSeverity.Informational);
					TranslationModelStatus translationModelStatus = await Session.Translation.TestCloudConnectionAsync();
					UpdateStatus(translationModelStatus.Message, translationModelStatus.IsReady ? InfoBarSeverity.Success : InfoBarSeverity.Error);
				}
			});
			Microsoft.UI.Xaml.Controls.Button button3 = Ui.Button(UiText.Get(UiKey.RemoveSavedKey), async () =>
			{
				if (await Confirm(UiText.Get(UiKey.RemoveSavedKeyQuestion), UiText.Get(UiKey.RemoveSavedKeyBody), UiText.Get(UiKey.Remove)) == ContentDialogResult.Primary)
				{
					Session.Translation.DeleteCloudCredential();
					key.Password = "";
					UpdateStatus(UiText.Get(UiKey.SavedKeyRemoved), InfoBarSeverity.Success);
				}
			});
			return Ui.Section(UiText.Get(UiKey.AzureConnection), Ui.Button(UiText.Get(UiKey.SetupHelp), ShowAzureHelpAsync, primary: false, Symbol.Help, Ui.Persian), Ui.Pair(key, region), Ui.Text(UiKey.AzureSendsOnlySelected, secondary: true), status, Ui.Actions(button, button2), button3);
			void UpdateStatus(string message, InfoBarSeverity severity)
			{
				status.Message = message;
				status.Severity = severity;
			}
		}

		internal async Task ShowAzureHelpAsync()
		{
			await Dialog(UiText.Get(UiKey.AzureSetupTitle), Ui.Stack(Ui.Text(UiKey.AzureSetupStep1), Ui.Rich(UiKey.AzureSetupStep2, false, "Keys and Endpoint", "Key 1", "Key 2"), Ui.Rich(UiKey.AzureSetupStep3, false, "Location", "australiaeast", "global"), Ui.Text(UiKey.AzureSetupStep4), Ui.Text(UiKey.AzureSetupCosts, secondary: true), Ui.Link(UiText.Get(UiKey.TranslatorSetupDocs), "https://learn.microsoft.com/azure/ai-services/translator/how-to/create-translator-resource"), Ui.Link(UiText.Get(UiKey.OpenAzurePortal), "https://portal.azure.com/")), null, UiText.Get(UiKey.Close));
		}

		private Microsoft.UI.Xaml.UIElement LocalTranslationPage()
		{
			InfoBar status = Ui.Localize(new InfoBar
			{
				IsClosable = false
			});
			Microsoft.UI.Xaml.Controls.ProgressBar progress = new Microsoft.UI.Xaml.Controls.ProgressBar
			{
				Minimum = 0.0,
				Maximum = 100.0,
				Visibility = Visibility.Collapsed
			};
			Microsoft.UI.Xaml.Controls.ComboBox model = Ui.Choice(UiText.Get(UiKey.OnDeviceModel), TranslationModelCatalog.Models.Select((TranslationModelOption x) => x.ToString()), TranslationModelCatalog.Models.ToList().FindIndex((TranslationModelOption x) => x.Alias == Session.Settings.Translation.ModelAlias), (int index) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						ModelAlias = TranslationModelCatalog.Models[index].Alias
					}
				});
			});
			CancellationTokenSource download = null;
			Microsoft.UI.Xaml.Controls.Button cancel = Ui.Button(UiText.Get(UiKey.CancelDownload), () =>
			{
				download?.Cancel();
				return Task.CompletedTask;
			});
			cancel.Visibility = Visibility.Collapsed;
			ToolTipService.SetToolTip(cancel, Ui.Tip(UiText.Get(UiKey.CancelDownloadTip)));
			ToggleSwitch toggleSwitch = Ui.Toggle(UiText.Get(UiKey.WarmUpLocalModel), Session.Settings.Translation.WarmUpLocalModel, (bool value) =>
			{
				Session.Save((AppSettings s) => s with
				{
					Translation = s.Translation with
					{
						WarmUpLocalModel = value
					}
				});
			}, UiText.Get(UiKey.WarmUpLocalModelTip));
			return Ui.Section(UiText.Get(UiKey.OnDeviceTranslation), model, Ui.Text(UiKey.FirstDownloadNeedsInternet, secondary: true), progress, status, Ui.Actions(Ui.Button(UiText.Get(UiKey.CheckModel), async () =>
			{
				Status(await Session.Translation.CheckModelAsync());
			}), Ui.Button(UiText.Get(UiKey.DownloadModel), async () =>
			{
				progress.Visibility = Visibility.Visible;
				model.IsEnabled = false;
				cancel.Visibility = Visibility.Visible;
				using CancellationTokenSource source = new CancellationTokenSource();
				download = source;
				try
				{
					Status(await Session.Translation.SetupModelAsync(new Progress<float>((float value) =>
					{
						progress.Value = value;
					}), source.Token));
				}
				catch (OperationCanceledException)
				{
					Status(new TranslationModelStatus(TranslationModelState.Unknown, UiText.Get(UiKey.ModelDownloadCancelled)));
				}
				finally
				{
					download = null;
					progress.Visibility = Visibility.Collapsed;
					model.IsEnabled = true;
					cancel.Visibility = Visibility.Collapsed;
				}
			}, primary: true, Symbol.Download), cancel), toggleSwitch, Ui.Text(UiKey.WarmUpLocalModelNote, secondary: true));
			void Status(TranslationModelStatus result)
			{
				status.IsOpen = true;
				status.Message = result.Message;
				status.Severity = (result.IsReady ? InfoBarSeverity.Success : InfoBarSeverity.Informational);
			}
		}
	}
	internal static class Verification
	{
		private static readonly ShortcutFailure[] FixtureShortcutFailures = new ShortcutFailure[2]
		{
			new ShortcutFailure(ShortcutHost.Labels[1], "Ctrl+Alt+Z", ShortcutFailureReason.TakenByAnotherApplication),
			new ShortcutFailure(ShortcutHost.Labels[4], "Ctrl+Alt+T", ShortcutFailureReason.TakenByAnotherApplication)
		};

		private const string FixtureReportPath = "C:\\Users\\Client\\AppData\\Local\\SmartInput\\Reports\\typing-problem-20261008-1430.txt";

		internal static IReadOnlyList<ApplicationFontTargetInfo> FontTargets => new <>z__ReadOnlyArray<ApplicationFontTargetInfo>(new ApplicationFontTargetInfo[4]
		{
			new ApplicationFontTargetInfo("notepad", "Notepad", MessageText.Get(MessageKey.FontScopeEditor), IsInstalled: true, CanApply: false, ApplicationFontTargetState.ManualSetup, MessageText.Get(MessageKey.FontStatusManualSetup)),
			new ApplicationFontTargetInfo("word", "Microsoft Word", MessageText.Get(MessageKey.FontScopeNewDocuments), IsInstalled: true, CanApply: true, ApplicationFontTargetState.Ready, MessageText.Get(MessageKey.FontStatusReady)),
			new ApplicationFontTargetInfo("edge", "Microsoft Edge", MessageText.Get(MessageKey.FontScopeWebFallback), IsInstalled: true, CanApply: true, ApplicationFontTargetState.Written, MessageText.Format(MessageKey.FontStatusWrittenToProfiles, 2)),
			new ApplicationFontTargetInfo("firefox", "Mozilla Firefox", MessageText.Get(MessageKey.FontScopeWebFallback), IsInstalled: true, CanApply: false, ApplicationFontTargetState.FontNotInstalled, MessageText.Format(MessageKey.FontStatusFontNotInstalledUse, "Shabnam", "Shabnam FD"))
		});

		internal static async Task VerifyAsync(MainWindow window, string output)
		{
			Directory.CreateDirectory(output);
			List<string> results = new List<string>();
			try
			{
				await Task.Delay(1200);
				window.Root.RequestedTheme = ElementTheme.Light;
				window.Session.Save((AppSettings s) => s with
				{
					Correction = s.Correction with
					{
						Engine = TypingEngine.Classic
					}
				});
				int[] array = new int[2] { 1280, 960 };
				foreach (int width in array)
				{
					double rasterizationScale = window.Root.XamlRoot.RasterizationScale;
					window.AppWindow.Resize(new SizeInt32((int)((double)width * rasterizationScale), (int)(820.0 * rasterizationScale)));
					await Task.Delay(300);
					window.Navigate("settings");
					for (int page = 0; page < MainWindow.SettingsTabs.Length; page++)
					{
						window.ShowSettings(page);
						await SaveAsync(window, output, $"{width}-settings-{MainWindow.SettingsTabs[page]}", results);
						if (page == 1)
						{
							RequireNoEngineChoice(window, $"{width}-settings-typing (Automatic correction)", results);
						}
					}
					window.Session.Save((AppSettings s) => s with
					{
						General = s.General with
						{
							TypingMode = TypingMode.ManualCorrection
						},
						Correction = s.Correction with
						{
							Mode = CorrectionMode.Manual
						}
					});
					window.ShowSettings(1);
					await SaveAsync(window, output, $"{width}-settings-typing-direct", results);
					RequireNoEngineChoice(window, $"{width}-settings-typing-direct", results);
					window.Session.Save((AppSettings s) => s with
					{
						General = s.General with
						{
							TypingMode = TypingMode.CapsLockSwitch,
							CapsLockBehavior = CapsLockBehavior.ManualCorrectionWhileOn
						}
					});
					window.ShowSettings(1);
					await SaveAsync(window, output, $"{width}-settings-typing-capslock", results);
					RequireNoEngineChoice(window, $"{width}-settings-typing-capslock", results);
					window.Session.Save((AppSettings s) => s with
					{
						General = s.General with
						{
							TypingMode = TypingMode.AutomaticCorrection,
							CapsLockBehavior = CapsLockBehavior.SwitchToEnglish
						},
						Correction = s.Correction with
						{
							Mode = CorrectionMode.Automatic
						}
					});
					window.Session.Save((AppSettings s) => s with
					{
						Translation = s.Translation with
						{
							Provider = "azure"
						}
					});
					window.ShowSettings(2);
					await SaveAsync(window, output, $"{width}-azure", results);
					window.Session.Dictionary.AddTerms(new <>z__ReadOnlyArray<string>(new string[2] { "verification-a", "verification-b" }), EntryLanguage.English);
					window.ShowDictionary(builtIn: false);
					await SaveAsync(window, output, $"{width}-dictionary", results);
					Microsoft.UI.Xaml.Controls.ListView dictionaryList = window.DictionaryList;
					if (dictionaryList.Items.Count < 2)
					{
						throw new InvalidOperationException("Personal dictionary failed to load.");
					}
					dictionaryList.SelectedItems.Add(dictionaryList.Items[0]);
					dictionaryList.SelectedItems.Add(dictionaryList.Items[1]);
					if (dictionaryList.SelectedItems.Count != 2)
					{
						throw new InvalidOperationException("Native multi-selection failed.");
					}
					dictionaryList.SelectedItems.Clear();
					window.ShowDictionary(builtIn: true);
					await SaveAsync(window, output, $"{width}-dictionary-builtin", results);
					if (window.DictionaryList.Items.Count < 2)
					{
						throw new InvalidOperationException("Built-in dictionary failed to load.");
					}
					window.Session.Review.Record("verification-one", "واژه\u200cآزمایشی");
					window.Session.Review.Record("verification-two", "آزمایش\u200cدوم");
					window.ShowReview(review: true);
					await SaveAsync(window, output, $"{width}-review", results);
					RequireReviewDates(window, UiLanguage.English, $"{width}-review", results);
					dictionaryList = window.DictionaryList;
					dictionaryList.SelectedItems.Add(dictionaryList.Items[0]);
					dictionaryList.SelectedItems.Add(dictionaryList.Items[1]);
					if (dictionaryList.SelectedItems.Count != 2)
					{
						throw new InvalidOperationException("Review multi-selection failed.");
					}
					await SaveAsync(window, output, $"{width}-review-selected", results);
					await SaveBlockedDictionaryAsync(window, output, $"{width}", results);
					await RequireEnglishCheckCanFailAsync(window, output, $"{width}-add-words-dialog", results);
					window.ShowReview(review: false);
					string[] array2 = new string[2] { "help", "about" };
					foreach (string text in array2)
					{
						window.Navigate(text);
						await SaveAsync(window, output, $"{width}-{text}", results);
					}
					window.Navigate("help");
					RequireHelpLanguage(window, UiLanguage.English, $"{width}-help", results);
					window.ShowPersianHelp();
					await SaveAsync(window, output, $"{width}-help-persian", results);
					RequireHelpLanguage(window, UiLanguage.Persian, $"{width}-help-persian", results);
					RequirePersianHelpProse(window.Root, $"{width}-help-persian", results);
					bool[] array3 = new bool[2] { false, true };
					foreach (bool persian in array3)
					{
						Task help = window.ShowHelpTopicAsync(HelpTopic.CapsLock, persian);
						await Task.Delay(600);
						ContentDialog helpDialog = window.ActiveDialog;
						if ((object)helpDialog == null || helpDialog.PrimaryButtonText != UiText.Get(UiKey.OpenFullHelp, UiLanguage.English))
						{
							throw new InvalidOperationException("Contextual help dialog did not open.");
						}
						await SaveElementAsync(helpDialog, output, $"{width}-help-dialog-{(persian ? "persian" : "english")}", results);
						helpDialog.Hide();
						await help;
					}
				}
				double rasterizationScale2 = window.Root.XamlRoot.RasterizationScale;
				window.AppWindow.Resize(new SizeInt32((int)(1280.0 * rasterizationScale2), (int)(820.0 * rasterizationScale2)));
				await Task.Delay(300);
				await SaveUpdateStatesAsync(window, output, "1280", results);
				Microsoft.UI.Xaml.Controls.ComboBox comboBox = Ui.Choice("Verification choice", new <>z__ReadOnlyArray<string>(new string[2] { "First", "Second" }), 0, (int _) =>
				{
					throw new IOException("Expected verification save failure.");
				});
				comboBox.SelectedIndex = 1;
				if (comboBox.SelectedIndex != 0)
				{
					throw new InvalidOperationException("Failed choice save was not restored.");
				}
				ToggleSwitch toggleSwitch = Ui.Toggle("Verification toggle", value: false, (bool _) =>
				{
					throw new IOException("Expected verification save failure.");
				});
				toggleSwitch.IsOn = true;
				if (toggleSwitch.IsOn)
				{
					throw new InvalidOperationException("Failed toggle save was not restored.");
				}
				results.Add("PASS: failed settings saves restore choice and toggle values.");
				HotkeySettings originalShortcuts = window.Session.Settings.Hotkeys;
				window.Navigate("settings");
				window.ShowSettings(4);
				Task recording = window.RecordShortcutAsync(0);
				await Task.Delay(300);
				if ((object)window.ActiveDialog == null || window.ActiveDialog.IsPrimaryButtonEnabled || window.ActiveDialog.CloseButtonText != UiText.Get(UiKey.Cancel))
				{
					throw new InvalidOperationException("Shortcut recording lacks a cancellable initial state.");
				}
				window.ActiveDialog.Hide();
				await recording;
				if (window.Session.Settings.Hotkeys != originalShortcuts)
				{
					throw new InvalidOperationException("Cancelling changed shortcuts.");
				}
				results.Add("PASS: shortcut dialog cancellation preserves all shortcuts.");
				window.Root.RequestedTheme = ElementTheme.Dark;
				window.Navigate("settings");
				window.ShowSettings(0);
				await SaveAsync(window, output, "dark-general", results);
				await VerifyPersianInterfaceAsync(window, output, results);
				RequireCommonPersianAdditions(window, results);
				await File.WriteAllLinesAsync(System.IO.Path.Combine(output, "verification.txt"), results.Append("PASS: dictionary multi-selection and all pages rendered without desktop input."));
			}
			catch (System.Exception ex)
			{
				Environment.ExitCode = 1;
				await File.WriteAllTextAsync(System.IO.Path.Combine(output, "verification-error.txt"), ex.ToString());
			}
			finally
			{
				bool flag = window.RequestCloseApp();
				bool flag2 = flag && window.ExitRequested;
				File.AppendAllLines(System.IO.Path.Combine(output, "verification.txt"), new <>z__ReadOnlySingleElementList<string>(flag2 ? "PASS: the Restart Manager's end-session request exited through the Exit path." : $"FAIL: end-session request (agreed={flag}) did not exit through the Exit path."));
				if (!flag2)
				{
					Environment.ExitCode = 1;
					window.ExitApp();
				}
			}
		}

		private static void RequireCommonPersianAdditions(MainWindow window, List<string> results)
		{
			int commonPersianAdditionCount = LexiconLoader.LoadFromFiles(null, DictionaryPaths.BuiltinPersian, null, DictionaryPaths.Metadata, null, DictionaryPaths.PersianCommonAdditions).CommonPersianAdditionCount;
			int commonPersianAdditionsLoaded = window.Session.CommonPersianAdditionsLoaded;
			bool commonPersianAdditions = window.Session.Settings.Correction.CommonPersianAdditions;
			if (commonPersianAdditions && commonPersianAdditionCount > 0 && commonPersianAdditionsLoaded == commonPersianAdditionCount)
			{
				results.Add($"PASS: the dictionary loaded {commonPersianAdditionsLoaded} common Persian additions with the default setting on (ADR-062).");
				return;
			}
			Environment.ExitCode = 1;
			results.Add($"FAIL: the dictionary loaded {commonPersianAdditionsLoaded} common Persian additions, expected {commonPersianAdditionCount} with the setting {(commonPersianAdditions ? "on" : "off")} (ADR-062).");
		}

		private static async Task VerifyPersianInterfaceAsync(MainWindow window, string output, List<string> results)
		{
			IReadOnlyList<string> readOnlyList = TextCatalog.FindProblems(UiText.Table(UiLanguage.English), UiText.Table(UiLanguage.Persian));
			if (readOnlyList.Count > 0)
			{
				throw new InvalidOperationException("Interface catalog: " + string.Join(" ", readOnlyList));
			}
			results.Add($"PASS: the interface catalog has English and Persian text for all {Enum.GetValues<UiKey>().Length} keys (ADR-057).");
			IReadOnlyList<string> readOnlyList2 = TextCatalog.FindProblems(MessageText.Table(UiLanguage.English), MessageText.Table(UiLanguage.Persian));
			if (readOnlyList2.Count > 0)
			{
				throw new InvalidOperationException("Message catalog: " + string.Join(" ", readOnlyList2));
			}
			results.Add($"PASS: the message catalog has English and Persian text for all {Enum.GetValues<MessageKey>().Length} keys (ADR-057).");
			window.Root.RequestedTheme = ElementTheme.Light;
			await SwitchOnLanguageCardAsync(window, output, UiLanguage.Persian, results);
			RequireShell(window, UiLanguage.Persian, Microsoft.UI.Xaml.FlowDirection.RightToLeft, results);
			RequireRichValues(results);
			int[] array = new int[2] { 1280, 960 };
			foreach (int width in array)
			{
				double rasterizationScale = window.Root.XamlRoot.RasterizationScale;
				window.AppWindow.Resize(new SizeInt32((int)((double)width * rasterizationScale), (int)(820.0 * rasterizationScale)));
				await Task.Delay(300);
				window.Navigate("settings");
				window.ShowSettings(0);
				await SaveAsync(window, output, $"fa-{width}-settings-general", results);
				RequireNoEnglishCatalogText(window, $"fa-{width}-settings-general", results);
				RequireHelpButtonGlyph(window, mirrored: true, $"fa-{width}-settings-general", results);
				await SavePersianSettingsTabsAsync(window, output, width, results);
				await SavePersianDictionaryAsync(window, output, width, results);
				window.Navigate("settings");
				window.ShowSettings(0);
				window.Notice(UiKey.ReportSaved, InfoBarSeverity.Success, "C:\\Users\\Client\\AppData\\Local\\SmartInput\\Reports\\typing-problem-20261008-1430.txt");
				await SaveAsync(window, output, $"fa-{width}-notice-path", results);
				RequireNoticePath(window, UiLanguage.Persian, $"fa-{width}-notice-path", results);
				await SaveShortcutNoticeAsync(window, output, $"fa-{width}-notice-shortcuts", results);
				window.Navigate("help");
				await SaveAsync(window, output, $"fa-{width}-help", results);
				RequireHelpLanguage(window, UiLanguage.Persian, $"fa-{width}-help", results);
				await SavePersianHelpTopicsAsync(window, output, $"fa-{width}-help", results);
				window.ShowHelp(persian: false);
				await SaveAsync(window, output, $"fa-{width}-help-english", results);
				RequireHelpLanguage(window, UiLanguage.English, $"fa-{width}-help-english", results);
				RequireLatinProseCheckCanFail(window, $"fa-{width}-help-english", results);
				window.Navigate("about");
				await SaveAsync(window, output, $"fa-{width}-about", results);
				bool[] array2 = new bool[2] { true, false };
				foreach (bool persian in array2)
				{
					Task help = window.ShowHelpTopicAsync(HelpTopic.CapsLock, persian);
					await Task.Delay(600);
					ContentDialog helpDialog = window.ActiveDialog;
					if ((object)helpDialog == null || helpDialog.PrimaryButtonText != UiText.Get(UiKey.OpenFullHelp, UiLanguage.Persian) || helpDialog.FlowDirection != Microsoft.UI.Xaml.FlowDirection.RightToLeft)
					{
						throw new InvalidOperationException("The contextual help dialog is not in the Persian interface.");
					}
					await SaveElementAsync(helpDialog, output, $"fa-{width}-help-dialog-{(persian ? "persian" : "english")}", results);
					if (persian)
					{
						RequirePersianHelpProse(helpDialog, $"fa-{width}-help-dialog-persian", results);
					}
					helpDialog.Hide();
					await help;
				}
				await SaveUpdateDialogAsync(window, output, $"fa-{width}-update-dialog", results);
			}
			await SaveUpdateStatesAsync(window, output, "fa-960", results);
			window.Root.RequestedTheme = ElementTheme.Dark;
			window.Navigate("settings");
			window.ShowSettings(0);
			await SaveAsync(window, output, "fa-dark-general", results);
			window.ShowSettings(1);
			await SaveAsync(window, output, "fa-dark-typing", results);
			window.ShowSettings(4);
			await SaveAsync(window, output, "fa-dark-shortcuts", results);
			window.Root.RequestedTheme = ElementTheme.Light;
			await SwitchOnLanguageCardAsync(window, output, UiLanguage.English, results);
			RequireShell(window, UiLanguage.English, Microsoft.UI.Xaml.FlowDirection.LeftToRight, results);
			double rasterizationScale2 = window.Root.XamlRoot.RasterizationScale;
			window.AppWindow.Resize(new SizeInt32((int)(1280.0 * rasterizationScale2), (int)(820.0 * rasterizationScale2)));
			await Task.Delay(300);
			window.Navigate("settings");
			window.ShowSettings(0);
			await SaveAsync(window, output, "en-after-switch-general", results);
			RequireHelpButtonGlyph(window, mirrored: false, "en-after-switch-general", results);
			window.Notice(UiKey.ReportSaved, InfoBarSeverity.Success, "C:\\Users\\Client\\AppData\\Local\\SmartInput\\Reports\\typing-problem-20261008-1430.txt");
			await SaveAsync(window, output, "en-after-switch-notice-path", results);
			RequireNoticePath(window, UiLanguage.English, "en-after-switch-notice-path", results);
			await SaveShortcutNoticeAsync(window, output, "en-after-switch-notice-shortcuts", results);
			window.Navigate("settings");
			window.ShowSettings(1);
			await SaveAsync(window, output, "en-after-switch-typing", results);
			window.ShowDictionary(builtIn: false);
			await SaveAsync(window, output, "en-after-switch-dictionary", results);
			RequireHelpButtonGlyph(window, mirrored: false, "en-after-switch-dictionary", results, dictionary: true);
			window.ShowReview(review: true);
			await SaveAsync(window, output, "en-after-switch-review", results);
			RequireReviewDates(window, UiLanguage.English, "en-after-switch-review", results);
			window.ShowReview(review: false);
			window.Navigate("help");
			await SaveAsync(window, output, "en-after-switch-help", results);
			RequireHelpLanguage(window, UiLanguage.English, "en-after-switch-help", results);
			await SaveUpdateDialogAsync(window, output, "en-after-switch-update-dialog", results);
			if (window.Session.Settings.General.UiLanguage != UiLanguage.English || TextCatalog.Language != UiLanguage.English)
			{
				throw new InvalidOperationException("The switch back to English was not saved.");
			}
			results.Add("PASS: the interface switched English → Persian → English live on the Language card, saved in the isolated profile (ADR-057).");
		}

		private static async Task SwitchOnLanguageCardAsync(MainWindow window, string output, UiLanguage language, List<string> results)
		{
			UiLanguage from = TextCatalog.Language;
			string prefix = ((from == UiLanguage.Persian) ? "fa" : "en");
			double rasterizationScale = window.Root.XamlRoot.RasterizationScale;
			window.AppWindow.Resize(new SizeInt32((int)(1280.0 * rasterizationScale), (int)(820.0 * rasterizationScale)));
			window.Navigate("settings");
			window.ShowSettings(0);
			await Task.Delay(300);
			Microsoft.UI.Xaml.Controls.ComboBox card = window.LanguageChoice ?? throw new InvalidOperationException("Settings › General has no Language card.");
			RequireLanguageCard(card, from, prefix + "-language-card", results);
			await SaveAsync(window, output, prefix + "-language-card", results);
			card.SelectedIndex = ((language == UiLanguage.Persian) ? 1 : 0);
			await Task.Delay(600);
			if (window.Session.Settings.General.UiLanguage != language || TextCatalog.Language != language)
			{
				throw new InvalidOperationException($"The Language card did not switch the interface to {language}.");
			}
			Microsoft.UI.Xaml.Controls.ComboBox languageChoice = window.LanguageChoice;
			if ((object)languageChoice == null || (object)languageChoice == card)
			{
				throw new InvalidOperationException($"The Language card switched to {language}, but the shell was not built again.");
			}
			RequireLanguageCard(languageChoice, language, prefix + "-to-" + ((language == UiLanguage.Persian) ? "fa" : "en") + "-language-card", results);
		}

		private static void RequireLanguageCard(Microsoft.UI.Xaml.Controls.ComboBox choice, UiLanguage language, string name, List<string> results)
		{
			string text = UiText.Get(UiKey.InterfaceLanguage, language);
			if (choice.Header as string != text || AutomationProperties.GetName(choice) != text)
			{
				throw new InvalidOperationException(name + ": the language choice is not labelled and named \"" + text + "\".");
			}
			if (!(ToolTipService.GetToolTip(choice) is Microsoft.UI.Xaml.Controls.ToolTip { Content: string content }) || content != UiText.Get(UiKey.InterfaceLanguageTip, language))
			{
				throw new InvalidOperationException($"{name}: the language choice has no tooltip in {language}.");
			}
			if (choice.Items.Count != 2 || !(choice.Items[0] is ComboBoxItem { Content: string content2 } comboBoxItem) || !(content2 == "English") || !(choice.Items[1] is ComboBoxItem { Content: string content3 } comboBoxItem2) || !(content3 == "فارسی") || comboBoxItem.FlowDirection != comboBoxItem2.FlowDirection || comboBoxItem.FlowDirection != ((language == UiLanguage.Persian) ? Microsoft.UI.Xaml.FlowDirection.RightToLeft : Microsoft.UI.Xaml.FlowDirection.LeftToRight) || AutomationProperties.GetName(comboBoxItem) != "English" || AutomationProperties.GetName(comboBoxItem2) != "فارسی" || comboBoxItem2.FontFamily?.Source != Ui.PersianFont.Source)
			{
				throw new InvalidOperationException(name + ": the language choice does not offer English and فارسی, each in its own language.");
			}
			if (choice.SelectedIndex != ((language == UiLanguage.Persian) ? 1 : 0))
			{
				throw new InvalidOperationException($"{name}: the language choice does not show {language} selected.");
			}
			results.Add($"PASS: {name}: the Language card offers English and فارسی, labelled, named and with a tooltip in {language} (ADR-057).");
		}

		private static async Task SaveShortcutNoticeAsync(MainWindow window, string output, string name, List<string> results)
		{
			UiLanguage language = TextCatalog.Language;
			var (message, text) = ShortcutHost.Report(FixtureShortcutFailures, 4);
			if (message.Length == 0)
			{
				throw new InvalidOperationException(name + ": no message for two failed shortcuts.");
			}
			if (text != ShortcutRegistrationPolicy.Describe(FixtureShortcutFailures, 4, UiLanguage.English) || text.Any(TextCatalog.IsPersianLetter) || !text.StartsWith("2 shortcuts could not be registered: ", StringComparison.Ordinal))
			{
				throw new InvalidOperationException(name + ": the diagnostics report is not the English one: " + text);
			}
			window.Navigate("settings");
			window.ShowSettings(0);
			window.Notice(message, InfoBarSeverity.Warning);
			await SaveAsync(window, output, name, results);
			string value = UiText.Get(UiKey.CommandUndoLastTranslation, language);
			if (!(window.NoticeBar.Message == message) || !message.Contains(value, StringComparison.Ordinal) || !((language != UiLanguage.Persian) ? (message.StartsWith("2 shortcuts could not be registered: ", StringComparison.Ordinal) && message.EndsWith("The other shortcuts are working. Choose different keys in Settings > Shortcuts.", StringComparison.Ordinal)) : (message.Any(TextCatalog.IsPersianLetter) && message.Contains($"{'\u2068'}Ctrl+Alt+Z{'\u2069'}", StringComparison.Ordinal) && !message.Contains("could not be registered", StringComparison.Ordinal))))
			{
				throw new InvalidOperationException(name + ": the shortcut notice says \"" + window.NoticeBar.Message + "\".");
			}
			results.Add($"PASS: {name}: the shortcut-registration notice is the Services message in {language}, each chord isolated, and the diagnostics report stays English (ADR-057).");
		}

		private static async Task SavePersianSettingsTabsAsync(MainWindow window, string output, int width, List<string> results)
		{
			window.Navigate("settings");
			(string, TypingMode, CorrectionMode)[] array = new (string, TypingMode, CorrectionMode)[4]
			{
				("settings-typing", TypingMode.AutomaticCorrection, CorrectionMode.Automatic),
				("settings-typing-direct", TypingMode.ManualCorrection, CorrectionMode.Manual),
				("settings-typing-capslock", TypingMode.CapsLockSwitch, CorrectionMode.Automatic),
				("settings-typing-shift", TypingMode.ShiftLanguageSwitch, CorrectionMode.Automatic)
			};
			(string Name, TypingMode Mode, CorrectionMode Correction)[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				var (name, mode, correction) = array2[i];
				window.Session.Save((AppSettings s) => s with
				{
					General = s.General with
					{
						TypingMode = mode,
						ShiftLanguageSwitchEnabled = (mode == TypingMode.ShiftLanguageSwitch),
						CapsLockBehavior = ((mode == TypingMode.CapsLockSwitch) ? CapsLockBehavior.ManualCorrectionWhileOn : CapsLockBehavior.SwitchToEnglish)
					},
					Correction = s.Correction with
					{
						Mode = correction
					}
				});
				window.ShowSettings(1);
				await SaveAsync(window, output, $"fa-{width}-{name}", results);
				RequireNoEngineChoice(window, $"fa-{width}-{name}", results);
				RequireNoEnglishCatalogText(window, $"fa-{width}-{name}", results);
			}
			EnglishHoldKey englishHoldKey = window.Session.Settings.Correction.EnglishHoldKey;
			EnglishHoldKey persianHoldKey = window.Session.Settings.Correction.PersianHoldKey;
			EnglishHoldKey persianHoldKey2 = persianHoldKey;
			EnglishHoldKey holdKey = englishHoldKey;
			window.Session.Save((AppSettings s) => s with
			{
				General = s.General with
				{
					TypingMode = TypingMode.AutomaticCorrection,
					ShiftLanguageSwitchEnabled = false,
					CapsLockBehavior = CapsLockBehavior.SwitchToEnglish
				},
				Correction = s.Correction with
				{
					Mode = CorrectionMode.Automatic,
					EnglishHoldKey = EnglishHoldKey.LeftShift,
					PersianHoldKey = EnglishHoldKey.CapsLock
				},
				Translation = s.Translation with
				{
					Provider = "local"
				}
			});
			window.ShowSettings(1);
			await SaveAsync(window, output, $"fa-{width}-settings-typing-holdkey", results);
			RequireNoEnglishCatalogText(window, $"fa-{width}-settings-typing-holdkey", results);
			RequirePersianPhrase(window, UiText.Get(UiKey.KeyLeftShift), $"fa-{width}-settings-typing-holdkey", results);
			window.Session.Save((AppSettings s) => s with
			{
				Correction = s.Correction with
				{
					EnglishHoldKey = holdKey,
					PersianHoldKey = persianHoldKey2
				}
			});
			int[] array3 = new int[3] { 2, 3, 4 };
			foreach (int tab in array3)
			{
				window.ShowSettings(tab);
				await SaveAsync(window, output, $"fa-{width}-settings-{MainWindow.SettingsTabs[tab]}", results);
				RequireNoEnglishCatalogText(window, $"fa-{width}-settings-{MainWindow.SettingsTabs[tab]}", results);
			}
			window.Session.Save((AppSettings s) => s with
			{
				Translation = s.Translation with
				{
					Provider = "azure"
				}
			});
			window.ShowSettings(2);
			await SaveAsync(window, output, $"fa-{width}-azure", results);
			RequireNoEnglishCatalogText(window, $"fa-{width}-azure", results);
			Task azureHelp = window.ShowAzureHelpAsync();
			await Task.Delay(600);
			ContentDialog azureDialog = window.ActiveDialog;
			if ((object)azureDialog == null || azureDialog.CloseButtonText != UiText.Get(UiKey.Close) || azureDialog.FlowDirection != Microsoft.UI.Xaml.FlowDirection.RightToLeft)
			{
				throw new InvalidOperationException("The Azure setup dialog is not in the Persian interface.");
			}
			await SaveElementAsync(azureDialog, output, $"fa-{width}-azure-help", results);
			azureDialog.Hide();
			await azureHelp;
			window.Session.Save((AppSettings s) => s with
			{
				Translation = s.Translation with
				{
					Provider = "local"
				}
			});
			window.ShowSettings(4);
			HotkeySettings originalShortcuts = window.Session.Settings.Hotkeys;
			Task recording = window.RecordShortcutAsync(0);
			await Task.Delay(600);
			ContentDialog recorder = window.ActiveDialog;
			if ((object)recorder == null || recorder.CloseButtonText != UiText.Get(UiKey.Cancel) || recorder.PrimaryButtonText != UiText.Get(UiKey.SaveShortcut) || recorder.FlowDirection != Microsoft.UI.Xaml.FlowDirection.RightToLeft)
			{
				throw new InvalidOperationException("The shortcut recorder is not in the Persian interface.");
			}
			await SaveElementAsync(recorder, output, $"fa-{width}-shortcut-recorder", results);
			recorder.Hide();
			await recording;
			if (window.Session.Settings.Hotkeys != originalShortcuts)
			{
				throw new InvalidOperationException("Cancelling the Persian recorder changed shortcuts.");
			}
		}

		private static async Task SavePersianDictionaryAsync(MainWindow window, string output, int width, List<string> results)
		{
			window.Session.Dictionary.AddTerms(new <>z__ReadOnlyArray<string>(new string[2] { "verification-a", "verification-b" }), EntryLanguage.English);
			window.Session.Dictionary.AddTerms(new <>z__ReadOnlySingleElementList<string>("آزمونک"), EntryLanguage.Persian);
			window.Session.Review.Record("verification-one", "واژه\u200cآزمایشی");
			window.Session.Review.Record("verification-two", "آزمایش\u200cدوم");
			window.Session.Review.Record(";jhf", "کتاب");
			(string, bool)[] array = new (string, bool)[2]
			{
				("dictionary", false),
				("dictionary-builtin", true)
			};
			for (int i = 0; i < array.Length; i++)
			{
				var (name, builtIn) = array[i];
				window.ShowDictionary(builtIn);
				await SaveAsync(window, output, $"fa-{width}-{name}", results);
				RequireNoEnglishCatalogText(window, $"fa-{width}-{name}", results, UiText.Get(UiKey.Word));
				if (!builtIn)
				{
					RequireHelpButtonGlyph(window, mirrored: true, $"fa-{width}-{name}", results, dictionary: true);
				}
			}
			window.ShowReview(review: true);
			await SaveAsync(window, output, $"fa-{width}-review", results);
			RequireNoEnglishCatalogText(window, $"fa-{width}-review", results, UiText.Get(UiKey.ColumnProposedWord));
			RequireReviewDates(window, UiLanguage.Persian, $"fa-{width}-review", results);
			Microsoft.UI.Xaml.Controls.ListView list = window.DictionaryList;
			list.SelectedItems.Add(list.Items[0]);
			list.SelectedItems.Add(list.Items[1]);
			if (list.SelectedItems.Count != 2)
			{
				throw new InvalidOperationException("Persian review multi-selection failed.");
			}
			await SaveAsync(window, output, $"fa-{width}-review-selected", results);
			RequireNoEnglishCatalogText(window, $"fa-{width}-review-selected", results, UiText.Get(UiKey.ColumnProposedWord));
			list.SelectedItems.Clear();
			await RequirePersianDialogAsync(window, window.ConfirmAcceptAllAsync(window.Session.Review.GetAll().Count), UiKey.AcceptAll, output, $"fa-{width}-accept-all-confirm", results);
			await RequirePersianDialogAsync(window, window.ConfirmAllAsync(review: true), UiKey.RejectAll, output, $"fa-{width}-reject-all-confirm", results);
			await RequirePersianDialogAsync(window, window.ConfirmRemovalAsync(review: true, 2), UiKey.Reject, output, $"fa-{width}-reject-confirm", results);
			await SaveBlockedDictionaryAsync(window, output, $"fa-{width}", results);
			window.ShowDictionary(builtIn: false);
			await SaveOverflowAsync(window, output, $"fa-{width}-dictionary-overflow", results);
			await RequirePersianDialogAsync(window, window.AddWordsAsync(), UiKey.AddWords, output, $"fa-{width}-add-words-dialog", results);
			window.Session.Dictionary.AddTerms(new <>z__ReadOnlySingleElementList<string>("آزمونک"), EntryLanguage.Persian);
			SmartInput.Core.Dictionaries.DictionaryEntry entry = window.Session.Dictionary.GetAll().FirstOrDefault((SmartInput.Core.Dictionaries.DictionaryEntry dictionaryEntry) => dictionaryEntry.Term == "آزمونک") ?? throw new InvalidOperationException($"fa-{width}-edit-word-dialog: the personal dictionary did not keep the added Persian word.");
			await RequirePersianDialogAsync(window, window.EditWordAsync(entry), UiKey.Save, output, $"fa-{width}-edit-word-dialog", results);
			await RequirePersianDialogAsync(window, window.ConfirmRemovalAsync(review: false, 2), UiKey.Delete, output, $"fa-{width}-delete-confirm", results);
			await RequirePersianDialogAsync(window, window.ConfirmAllAsync(review: false), UiKey.DeleteAll, output, $"fa-{width}-delete-all-confirm", results);
		}

		private static async Task SaveOverflowAsync(MainWindow window, string output, string name, List<string> results)
		{
			await Task.Delay(300);
			CommandBar bar = window.DictionaryCommands ?? throw new InvalidOperationException(name + ": the Dictionary page has no command bar.");
			bar.IsOpen = true;
			try
			{
				await Task.Delay(450);
				CommandBarOverflowPresenter presenter = (from popup in Microsoft.UI.Xaml.Media.VisualTreeHelper.GetOpenPopupsForXamlRoot(window.Root.XamlRoot)
					where (object)popup.Child != null
					select popup).SelectMany((Popup popup) => Descendants(popup.Child)).Concat(Descendants(bar)).OfType<CommandBarOverflowPresenter>()
					.FirstOrDefault() ?? throw new InvalidOperationException(name + ": the overflow menu did not open.");
				if (presenter.FlowDirection != Microsoft.UI.Xaml.FlowDirection.RightToLeft)
				{
					throw new InvalidOperationException($"{name}: the overflow menu is {presenter.FlowDirection}, not right to left.");
				}
				await SaveElementAsync(presenter, output, name, results);
				RequireNoEnglishCatalogText(presenter, name, results, UiText.Get(UiKey.SelectPage));
				results.Add("PASS: " + name + " is right to left.");
			}
			finally
			{
				bar.IsOpen = false;
			}
		}

		private static IEnumerable<Microsoft.UI.Xaml.DependencyObject> Descendants(Microsoft.UI.Xaml.DependencyObject root)
		{
			Stack<Microsoft.UI.Xaml.DependencyObject> pending = new Stack<Microsoft.UI.Xaml.DependencyObject>();
			pending.Push(root);
			while (pending.Count > 0)
			{
				Microsoft.UI.Xaml.DependencyObject node = pending.Pop();
				yield return node;
				if (node is Popup { Child: { } child })
				{
					pending.Push(child);
				}
				for (int num = Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChildrenCount(node) - 1; num >= 0; num--)
				{
					pending.Push(Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChild(node, num));
				}
			}
		}

		private static async Task SaveBlockedDictionaryAsync(MainWindow window, string output, string prefix, List<string> results)
		{
			bool persian = prefix.StartsWith("fa-", StringComparison.Ordinal);
			string path = System.IO.Path.Combine(output, "profile", "dictionary.json");
			File.WriteAllText(path, "{\"schemaVersion\":1,\"entries\":[]}");
			string path2 = System.IO.Path.Combine(output, "profile", "review.json");
			using (new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
			{
				using (new FileStream(path2, FileMode.Open, FileAccess.Read, FileShare.None))
				{
					if (UnreadableFileBackup.Keep(path, "IOException") != null || UnreadableFileBackup.Keep(path2, "IOException") != null)
					{
						throw new InvalidOperationException("Fixture failed: the locked file could be copied.");
					}
					window.ShowDictionary(builtIn: false);
					await SaveAsync(window, output, prefix + "-dictionary-blocked", results);
					if (persian)
					{
						RequireNoEnglishCatalogText(window, prefix + "-dictionary-blocked", results, UiText.Get(UiKey.Word));
					}
					window.ShowReview(review: true);
					await SaveAsync(window, output, prefix + "-review-blocked", results);
					if (persian)
					{
						RequireNoEnglishCatalogText(window, prefix + "-review-blocked", results, UiText.Get(UiKey.ColumnProposedWord));
					}
					if (window.Session.Dictionary.WriteBlockedReason == null || window.Session.Review.WriteBlockedReason == null)
					{
						throw new InvalidOperationException("Blocked state was not reported.");
					}
					string text = window.Session.Dictionary.WriteBlockedReason ?? string.Empty;
					string value = MessageText.Get(MessageKey.UnreadableFileBlocked, UiLanguage.English).Split('(')[0].Replace("{0}", "", StringComparison.Ordinal).Trim();
					if (persian != text.Any(TextCatalog.IsPersianLetter) || persian == text.Contains(value, StringComparison.Ordinal))
					{
						throw new InvalidOperationException(prefix + ": the blocked notice is not in the interface language: " + text);
					}
					results.Add("PASS: " + prefix + "-dictionary-blocked: the unreadable-file notice from Services is in the interface language (ADR-057).");
				}
			}
			if (!window.Session.Dictionary.TryRetryPreservation() || !window.Session.Review.TryRetryPreservation())
			{
				throw new InvalidOperationException("Retry did not lift the block once the copy was possible.");
			}
		}

		private static async Task RequirePersianDialogAsync(MainWindow window, Task pending, UiKey primary, string output, string name, List<string> results)
		{
			await Task.Delay(600);
			ContentDialog dialog = window.ActiveDialog;
			if ((object)dialog == null || dialog.PrimaryButtonText != UiText.Get(primary) || dialog.CloseButtonText != UiText.Get(UiKey.Cancel) || dialog.FlowDirection != Microsoft.UI.Xaml.FlowDirection.RightToLeft)
			{
				throw new InvalidOperationException(name + ": the dialog is not in the Persian interface.");
			}
			await SaveElementAsync(dialog, output, name, results);
			RequireNoEnglishCatalogText(dialog, name, results, (string)dialog.Title, dialog.PrimaryButtonText, dialog.CloseButtonText);
			dialog.Hide();
			await pending;
		}

		private static async Task RequireEnglishCheckCanFailAsync(MainWindow window, string output, string name, List<string> results)
		{
			window.ShowDictionary(builtIn: false);
			Task pending = window.AddWordsAsync();
			await Task.Delay(600);
			ContentDialog dialog = window.ActiveDialog ?? throw new InvalidOperationException("The English Add words dialog did not open.");
			await SaveElementAsync(dialog, output, name, results);
			string found = FirstEnglishCatalogText(dialog, out var read, new HashSet<string>(StringComparer.Ordinal));
			dialog.Hide();
			await pending;
			if (found == null)
			{
				throw new InvalidOperationException($"The English-text check found no English catalog text in the English Add words dialog ({read} texts read): it cannot fail.");
			}
			results.Add("PASS: the English-text check finds \"" + found + "\" in the English Add words dialog (negative control, ADR-019).");
		}

		private static void RequireRichValues(List<string> results)
		{
			string date = UiText.Date(new System.DateTimeOffset(2026, 10, 8, 11, 0, 0, System.TimeSpan.Zero));
			List<Run> source = Ui.Rich(UiKey.ReviewUses, false, 3, date).Inlines.OfType<Run>().ToList();
			if (!TextCatalog.IsIsolated(date) || !source.Any((Run run2) => run2.Text == date))
			{
				throw new InvalidOperationException(string.Concat("Ui.Rich wrapped the isolated date again: \"", string.Concat(source.Select((Run run2) => run2.Text)), "\"."));
			}
			string count = UiText.Count(45123L);
			Run run = Ui.Rich(UiKey.WordCount, false, count).Inlines.OfType<Run>().FirstOrDefault((Run run2) => run2.Text.Contains(count, StringComparison.Ordinal)) ?? throw new InvalidOperationException("Ui.Rich lost the grouped count.");
			if (run.Text != $"{'\u2068'}{count}{'\u2069'}" || run.FontFamily?.Source == Ui.ChromeFont.Source)
			{
				throw new InvalidOperationException("Ui.Rich showed the grouped count \"" + count + "\" as a Latin value.");
			}
			results.Add("PASS: Ui.Rich keeps an isolated Jalali date as it is and a grouped count in the interface font (ADR-057).");
		}

		private static void RequireReviewDates(MainWindow window, UiLanguage language, string name, List<string> results)
		{
			List<DictionaryRow> list = window.DictionaryList.Items.OfType<DictionaryRow>().ToList();
			Dictionary<Guid, ManualConversionCandidate> dictionary = window.Session.Review.GetAll().ToDictionary((ManualConversionCandidate candidate) => candidate.Id);
			if (list.Count == 0)
			{
				throw new InvalidOperationException(name + ": the word review queue shows no row.");
			}
			foreach (DictionaryRow item in list)
			{
				ManualConversionCandidate manualConversionCandidate = dictionary[item.Id.Value];
				DateTime dateTime = manualConversionCandidate.LastSeenUtc.ToLocalTime().DateTime;
				bool num;
				if (language != UiLanguage.English)
				{
					if (!item.Status.Contains($"{'\u2067'}{InterfaceFormat.Date(dateTime, UiLanguage.Persian)}{'\u2069'}", StringComparison.Ordinal))
					{
						goto IL_0152;
					}
					num = !item.Status.Contains(manualConversionCandidate.LastSeenDisplay, StringComparison.Ordinal);
				}
				else
				{
					num = item.Status == $"{manualConversionCandidate.UseCount:N0} use(s) · {manualConversionCandidate.LastSeenDisplay}";
				}
				if (num)
				{
					continue;
				}
				goto IL_0152;
				IL_0152:
				throw new InvalidOperationException($"{name}: the row for \"{item.Word}\" says \"{item.Status}\".");
			}
			results.Add($"PASS: {name}: every word review row shows its date {((language == UiLanguage.Persian) ? "in the Jalali calendar" : "as before")}.");
		}

		private static void RequireNoEnglishCatalogText(MainWindow window, string name, List<string> results, params string[] mustSee)
		{
			RequireNoEnglishCatalogText(window.Root, name, results, mustSee);
		}

		private static void RequireNoEnglishCatalogText(Microsoft.UI.Xaml.DependencyObject root, string name, List<string> results, params string[] mustSee)
		{
			HashSet<string> seen = new HashSet<string>(StringComparer.Ordinal);
			string text = FirstEnglishCatalogText(root, out var read, seen);
			if (text != null)
			{
				throw new InvalidOperationException(name + " shows English catalog text in the Persian interface: \"" + text + "\"");
			}
			if (read == 0)
			{
				throw new InvalidOperationException(name + ": the English-text check read no text, so it checked nothing.");
			}
			string text2 = mustSee.FirstOrDefault((string item) => !seen.Contains(item));
			if (text2 != null)
			{
				throw new InvalidOperationException(name + ": the English-text check never reached \"" + text2 + "\".");
			}
			results.Add($"PASS: {name} shows no English text from the catalog ({read} texts read) (ADR-057).");
		}

		private static string? FirstEnglishCatalogText(Microsoft.UI.Xaml.DependencyObject root, out int read, ISet<string> seen)
		{
			HashSet<string> hashSet = (from entry in UiText.Table(UiLanguage.English)
				where entry.Value != UiText.Get(entry.Key, UiLanguage.Persian)
				select entry.Value).Concat(from entry in MessageText.Table(UiLanguage.English)
				where entry.Value.Contains(' ') && entry.Value != MessageText.Get(entry.Key, UiLanguage.Persian)
				select entry.Value).ToHashSet(StringComparer.Ordinal);
			read = 0;
			Stack<Microsoft.UI.Xaml.DependencyObject> stack = new Stack<Microsoft.UI.Xaml.DependencyObject>();
			stack.Push(root);
			while (stack.Count > 0)
			{
				Microsoft.UI.Xaml.DependencyObject dependencyObject = stack.Pop();
				if (dependencyObject is Microsoft.UI.Xaml.UIElement { Visibility: Visibility.Collapsed })
				{
					continue;
				}
				List<string> list = new List<string>();
				if (dependencyObject is TextBlock textBlock)
				{
					list.Add(textBlock.Text);
				}
				if (dependencyObject is Microsoft.UI.Xaml.Controls.ComboBox comboBox)
				{
					list.AddRange(new <>z__ReadOnlyArray<string>(new string[2]
					{
						comboBox.Header as string,
						comboBox.PlaceholderText
					}));
				}
				if (dependencyObject is ToggleSwitch toggleSwitch)
				{
					list.AddRange(new <>z__ReadOnlyArray<string>(new string[3]
					{
						toggleSwitch.Header as string,
						toggleSwitch.OnContent as string,
						toggleSwitch.OffContent as string
					}));
				}
				foreach (string item in list)
				{
					if (!string.IsNullOrEmpty(item))
					{
						read++;
						seen.Add(item);
						if (hashSet.Contains(item))
						{
							return item;
						}
					}
				}
				if (!(dependencyObject is Microsoft.UI.Xaml.Controls.ComboBox))
				{
					for (int num = Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChildrenCount(dependencyObject) - 1; num >= 0; num--)
					{
						stack.Push(Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChild(dependencyObject, num));
					}
				}
			}
			return null;
		}

		private static async Task SavePersianHelpTopicsAsync(MainWindow window, string output, string prefix, List<string> results)
		{
			HelpTopic[] values = Enum.GetValues<HelpTopic>();
			for (int i = 0; i < values.Length; i++)
			{
				HelpTopic helpTopic = values[i];
				if (!window.HelpSections.TryGetValue(helpTopic, out Microsoft.UI.Xaml.FrameworkElement section))
				{
					throw new InvalidOperationException($"{prefix}: the Help page has no {helpTopic} section.");
				}
				section.StartBringIntoView(new Microsoft.UI.Xaml.BringIntoViewOptions
				{
					VerticalAlignmentRatio = 0.0,
					AnimationDesired = false
				});
				string name = prefix + "-" + Kebab(helpTopic.ToString());
				await SaveAsync(window, output, name, results);
				RequirePersianHelpProse(section, name, results);
				RequireNoEnglishCatalogText(section, name, results);
				section = null;
			}
			Microsoft.UI.Xaml.FrameworkElement root = window.HelpSections[HelpTopic.Glossary];
			string settings = $"{'\u2066'}{UiText.Get(UiKey.NavSettings, UiLanguage.English)}{'\u2069'}";
			if (!Descendants(root).OfType<TextBlock>().Any((TextBlock block) => block.Inlines.OfType<Run>().Any((Run run) => run.Text == settings && run.FontFamily?.Source == Ui.ChromeFont.Source)))
			{
				throw new InvalidOperationException(prefix + "-glossary: the English names are not isolated Latin values in the chrome font.");
			}
			results.Add("PASS: " + prefix + "-glossary shows each English name as an isolated Latin value in the chrome font.");
		}

		private static void RequireHelpLanguage(MainWindow window, UiLanguage language, string name, List<string> results)
		{
			if (window.HelpLanguageShown != language)
			{
				throw new InvalidOperationException($"{name}: the Help page is in {window.HelpLanguageShown}, not {language}.");
			}
			results.Add($"PASS: {name}: the Help page is in {language}.");
		}

		private static void RequirePersianHelpProse(Microsoft.UI.Xaml.DependencyObject root, string name, List<string> results)
		{
			string text = FirstLatinHelpProse(root, out var read);
			if (text != null)
			{
				throw new InvalidOperationException(name + ": Persian help prose shows Latin text outside an isolated run: \"" + text + "\"");
			}
			if (read == 0)
			{
				throw new InvalidOperationException(name + ": the Persian help prose check read no prose, so it checked nothing.");
			}
			results.Add($"PASS: {name}: the Persian help prose has no Latin text outside its isolated runs ({read} paragraphs read) (ADR-057).");
		}

		private static void RequireLatinProseCheckCanFail(MainWindow window, string name, List<string> results)
		{
			if (FirstLatinHelpProse(window.HelpSections[HelpTopic.GettingStarted], out var _) == null)
			{
				throw new InvalidOperationException(name + ": the Persian help prose check found no Latin text in the English Help, so it cannot fail.");
			}
			results.Add("PASS: " + name + ": the Persian help prose check finds the English Help's Latin prose (negative control).");
		}

		private static string? FirstLatinHelpProse(Microsoft.UI.Xaml.DependencyObject root, out int read)
		{
			read = 0;
			string text;
			foreach (Microsoft.UI.Xaml.DependencyObject item in Descendants(root))
			{
				if (!(item is TextBlock textBlock))
				{
					continue;
				}
				text = textBlock.Tag as string;
				if (text == null || !(text == "help-prose") || textBlock.Visibility != Visibility.Visible)
				{
					continue;
				}
				read++;
				List<Run> source = textBlock.Inlines.OfType<Run>().ToList();
				string text2 = string.Concat(source.Select((Run run2) => run2.Text));
				if (OutsideIsolates(text2).Any(char.IsAsciiLetter))
				{
					text = text2;
				}
				else
				{
					Run run = source.FirstOrDefault((Run run2) => run2.Text.StartsWith('\u2066') && run2.FontFamily?.Source != Ui.ChromeFont.Source);
					if ((object)run == null)
					{
						continue;
					}
					text = run.Text + " (not in the chrome font)";
				}
				goto IL_011e;
			}
			return null;
			IL_011e:
			return text;
		}

		private static string OutsideIsolates(string text)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			foreach (char c in text)
			{
				bool flag;
				switch (c)
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
				else if (c == '\u2069' && num > 0)
				{
					num--;
				}
				else if (num == 0)
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		private static string Kebab(string name)
		{
			return string.Concat(name.Select((char c, int i) => (!char.IsUpper(c) || i <= 0) ? char.ToLowerInvariant(c).ToString() : ("-" + char.ToLowerInvariant(c))));
		}

		private static void RequirePersianPhrase(MainWindow window, string phrase, string name, List<string> results)
		{
			string value = $"{'\u2067'}{phrase}{'\u2069'}";
			Stack<Microsoft.UI.Xaml.DependencyObject> stack = new Stack<Microsoft.UI.Xaml.DependencyObject>();
			stack.Push(window.Root);
			while (stack.Count > 0)
			{
				Microsoft.UI.Xaml.DependencyObject dependencyObject = stack.Pop();
				if (dependencyObject is Microsoft.UI.Xaml.UIElement { Visibility: Visibility.Collapsed })
				{
					continue;
				}
				if (dependencyObject is TextBlock textBlock)
				{
					List<Run> source = textBlock.Inlines.OfType<Run>().ToList();
					if (string.Concat(source.Select((Run run) => run.Text)).Contains(value, StringComparison.Ordinal))
					{
						if (!source.Any((Run run) => run.Text.Contains("Shift", StringComparison.Ordinal) && run.FontFamily?.Source == Ui.ChromeFont.Source))
						{
							throw new InvalidOperationException(name + ": the keycap in \"" + phrase + "\" is not in the chrome font.");
						}
						results.Add($"PASS: {name} shows \"{phrase}\" as a right-to-left isolate with its keycap in the chrome font.");
						return;
					}
				}
				for (int num = Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChildrenCount(dependencyObject) - 1; num >= 0; num--)
				{
					stack.Push(Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChild(dependencyObject, num));
				}
			}
			throw new InvalidOperationException(name + ": no text shows \"" + phrase + "\" as a right-to-left isolate.");
		}

		private static void RequireNoticePath(MainWindow window, UiLanguage language, string name, List<string> results)
		{
			InfoBar noticeBar = window.NoticeBar;
			if (language == UiLanguage.Persian)
			{
				string path = $"{'\u2066'}{"C:\\Users\\Client\\AppData\\Local\\SmartInput\\Reports\\typing-problem-20261008-1430.txt"}{'\u2069'}";
				if (!string.IsNullOrEmpty(noticeBar.Message) || !(noticeBar.Content is TextBlock textBlock) || !textBlock.Inlines.OfType<Run>().Any((Run run) => run.Text == path && run.FontFamily?.Source == Ui.ChromeFont.Source))
				{
					throw new InvalidOperationException(name + ": the Persian notice does not show the path as a left-to-right run, alone.");
				}
			}
			else if (noticeBar.Content != null || noticeBar.Message != UiText.Format(UiKey.ReportSaved, "C:\\Users\\Client\\AppData\\Local\\SmartInput\\Reports\\typing-problem-20261008-1430.txt"))
			{
				throw new InvalidOperationException(name + ": the English notice is not the plain sentence.");
			}
			results.Add($"PASS: {name}: the notice shows the path as {((language == UiLanguage.Persian) ? "an isolated Latin run" : "plain text")}.");
		}

		private static void RequireShell(MainWindow window, UiLanguage language, Microsoft.UI.Xaml.FlowDirection direction, List<string> results)
		{
			if (window.Root.FlowDirection != direction)
			{
				throw new InvalidOperationException($"{language} interface: the window is {window.Root.FlowDirection}.");
			}
			string text = UiText.Get(window.Session.Settings.General.Enabled ? UiKey.PauseTypingAssistant : UiKey.ResumeTypingAssistant, language);
			string name = AutomationProperties.GetName(window.PowerButton);
			if (name != text)
			{
				throw new InvalidOperationException($"{language} interface: the Pause button is named \"{name}\", not \"{text}\".");
			}
			results.Add($"PASS: {language} interface: the window is {direction} and the Pause button is named \"{text}\".");
		}

		private static void RequireHelpButtonGlyph(MainWindow window, bool mirrored, string name, List<string> results, bool dictionary = false)
		{
			string helpGlyph = char.ConvertFromUtf32(57627);
			string namePrefix = UiText.Get(UiKey.HelpButtonName).Split("{0}")[0];
			List<FontIcon> list = (from icon in (from button in Descendants(window.Root).OfType<Microsoft.UI.Xaml.Controls.Button>()
					where (AutomationProperties.GetName(button) ?? string.Empty).StartsWith(namePrefix, StringComparison.Ordinal)
					select button.Content).OfType<FontIcon>()
				where icon.Glyph == helpGlyph
				select icon).ToList();
			if (!dictionary && list.Count == 0)
			{
				throw new InvalidOperationException(name + ": the page shows no help button.");
			}
			if (!(Descendants(window.Root).OfType<NavigationViewItem>().FirstOrDefault((NavigationViewItem item) => object.Equals(item.Tag, "help"))?.Icon is FontIcon fontIcon) || fontIcon.Glyph != helpGlyph)
			{
				throw new InvalidOperationException(name + ": the Help navigation item shows no help glyph that can mirror.");
			}
			List<FontIcon> list2 = (from icon in (from button in Descendants(window.Root).OfType<CommandBar>().SelectMany((CommandBar bar) => bar.PrimaryCommands.Concat(bar.SecondaryCommands)).OfType<AppBarButton>()
					select button.Icon).OfType<FontIcon>()
				where icon.Glyph == helpGlyph
				select icon).ToList();
			if (dictionary && list2.Count == 0)
			{
				throw new InvalidOperationException(name + ": the Dictionary command bar shows no Help command with a help glyph that can mirror.");
			}
			List<FontIcon> list3 = list.Append(fontIcon).Concat(list2).Concat(from icon in Descendants(window.Root).OfType<FontIcon>()
				where icon.Glyph == helpGlyph
				select icon)
				.Distinct()
				.ToList();
			if (list3.Any((FontIcon icon) => icon.MirroredWhenRightToLeft != mirrored))
			{
				throw new InvalidOperationException(name + ": a help glyph's question mark is " + (mirrored ? "not mirrored" : "mirrored") + ".");
			}
			results.Add($"PASS: {name}: {list3.Count} help glyph(s) (section buttons, the Help navigation item{(dictionary ? ", the Dictionary Help command" : string.Empty)}) show the question mark {(mirrored ? "mirrored (؟)" : "unmirrored (?)")}.");
		}

		private static async Task SaveUpdateDialogAsync(MainWindow window, string output, string name, List<string> results)
		{
			Task<ContentDialogResult> update = window.ShowUpdateAvailableAsync(MessageText.Format(MessageKey.UpdateAvailable, "9.9.9"), new System.Uri("https://www.iranux.site/"), offerInstall: true);
			await Task.Delay(600);
			ContentDialog dialog = window.ActiveDialog;
			if ((object)dialog == null || dialog.CloseButtonText != UiText.Get(UiKey.Close) || dialog.PrimaryButtonText != UiText.Get(UiKey.DownloadAndInstall))
			{
				throw new InvalidOperationException(name + ": the update dialog did not open with Download and install.");
			}
			await SaveElementAsync(dialog, output, name, results);
			dialog.Hide();
			await update;
		}

		private static async Task SaveUpdateStatesAsync(MainWindow window, string output, string prefix, List<string> results)
		{
			UpdateInstallCoordinator install = window.Session.UpdateInstall;
			UpdateTarget target = new UpdateTarget("9.9.9", new System.Uri("https://diyar.digital/releases/9.9.9"), new System.Uri("https://diyar.digital/downloads/Diyar-9.9.9-win-x64-setup.exe"), new string('a', 64), 71234567L);
			install.ShowForVerification(new UpdateRunStatus(UpdateRunState.Available, target, 0L));
			await install.DownloadAsync();
			await install.InstallAsync();
			if (install.Enabled || install.Status.State != UpdateRunState.Available)
			{
				throw new InvalidOperationException(prefix + "-update: the update coordinator acted in a verification session.");
			}
			results.Add("PASS: " + prefix + "-update: the update coordinator refuses to download or install in verification (ADR-082).");
			string log = System.IO.Path.Combine(output, "profile", "Updates", "setup-9.9.9.log");
			(string, UpdateRunStatus)[] array = new (string, UpdateRunStatus)[6]
			{
				("available", new UpdateRunStatus(UpdateRunState.Available, target, 0L)),
				("downloading", new UpdateRunStatus(UpdateRunState.Downloading, target, target.Size * 42 / 100)),
				("ready", new UpdateRunStatus(UpdateRunState.Ready, target, target.Size)),
				("installing", new UpdateRunStatus(UpdateRunState.Installing, target, 0L, UpdateRunFailure.None, null, log)),
				("permission-refused", new UpdateRunStatus(UpdateRunState.PermissionRefused, target, 0L, UpdateRunFailure.None, 1223, log)),
				("failed", new UpdateRunStatus(UpdateRunState.Failed, target, 0L, UpdateRunFailure.SetupFailed, 1603, log))
			};
			(string Name, UpdateRunStatus Status)[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				var (name, status) = array2[i];
				install.ShowForVerification(status);
				window.Navigate("settings");
				window.ShowSettings(0);
				await Task.Delay(300);
				StackPanel stackPanel = window.UpdatePanelElement ?? throw new InvalidOperationException(prefix + "-update-" + name + ": Settings › General has no Updates panel.");
				if (stackPanel.Visibility != Visibility.Visible || stackPanel.Children.Count == 0)
				{
					throw new InvalidOperationException(prefix + "-update-" + name + ": the Updates panel is empty.");
				}
				if (name == "downloading")
				{
					Microsoft.UI.Xaml.Controls.ProgressBar progressBar = stackPanel.Children.OfType<Microsoft.UI.Xaml.Controls.ProgressBar>().SingleOrDefault();
					if ((object)progressBar == null || progressBar.IsIndeterminate || Math.Abs(progressBar.Value - 42.0) > 0.5 || AutomationProperties.GetName(progressBar) != UiText.Get(UiKey.UpdateDownloadProgressName))
					{
						throw new InvalidOperationException(prefix + "-update-downloading: no named determinate progress bar at 42 %.");
					}
					results.Add("PASS: " + prefix + "-update-downloading: the progress bar is named and at 42 %.");
				}
				stackPanel.StartBringIntoView();
				await SaveAsync(window, output, prefix + "-update-" + name, results);
			}
			install.ShowForVerification(UpdateRunStatus.Idle);
			await SaveUpdateOutcomesAsync(window, output, prefix, log, results);
		}

		private static async Task SaveUpdateOutcomesAsync(MainWindow window, string output, string prefix, string log, List<string> results)
		{
			Directory.CreateDirectory(System.IO.Path.GetDirectoryName(log));
			File.WriteAllText(log, "verification");
			PendingUpdateMarker marker = new PendingUpdateMarker("9.9.9", App.Version, System.DateTimeOffset.UtcNow, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(log), UpdateFileNames.SetupFileName("9.9.9")), log, WindowWasVisible: true);
			(string, UpdateOutcome, UiKey, bool)[] array = new (string, UpdateOutcome, UiKey, bool)[2]
			{
				("updated", new UpdateOutcome(UpdateOutcomeKind.Updated, marker), UiKey.UpdatedToText, false),
				("did-not-finish", new UpdateOutcome(UpdateOutcomeKind.Failed, marker, new SetupResultFile(1603, "0x80070643", "9.9.9", RestartRequired: false)), UiKey.UpdateDidNotFinishText, true)
			};
			(string Name, UpdateOutcome Outcome, UiKey Text, bool LogButton)[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				var (name, outcome, text, logButton) = array2[i];
				window.Navigate("settings");
				window.ShowSettings(0);
				await Task.Delay(200);
				if (window.ShowUpdateOutcome(outcome) != UiText.Format(text, "9.9.9"))
				{
					throw new InvalidOperationException(prefix + "-update-outcome-" + name + ": the outcome did not give its sentence.");
				}
				await Task.Delay(300);
				InfoBar noticeBar = window.NoticeBar;
				Microsoft.UI.Xaml.Controls.Button button = noticeBar.ActionButton as Microsoft.UI.Xaml.Controls.Button;
				if (!noticeBar.IsOpen || ((!logButton) ? ((object)button != null) : ((object)button == null || AutomationProperties.GetName(button) != UiText.Get(UiKey.OpenSetupLog))))
				{
					throw new InvalidOperationException(prefix + "-update-outcome-" + name + ": the notice is not open with its action.");
				}
				results.Add($"PASS: {prefix}-update-outcome-{name}: the start notice after an update is shown{(logButton ? " with Open the setup log" : string.Empty)} (ADR-082).");
				await SaveAsync(window, output, prefix + "-update-outcome-" + name, results);
			}
		}

		private static void RequireNoEngineChoice(MainWindow window, string name, List<string> results)
		{
			Stack<Microsoft.UI.Xaml.DependencyObject> stack = new Stack<Microsoft.UI.Xaml.DependencyObject>();
			stack.Push(window.Root);
			while (stack.Count > 0)
			{
				Microsoft.UI.Xaml.DependencyObject dependencyObject = stack.Pop();
				List<string> list = new List<string> { AutomationProperties.GetName(dependencyObject) };
				if (dependencyObject is TextBlock textBlock)
				{
					list.Add(textBlock.Text);
				}
				if (dependencyObject is Microsoft.UI.Xaml.Controls.ComboBox comboBox)
				{
					list.AddRange(comboBox.Items.Select((object item) => item?.ToString()));
				}
				string text = list.FirstOrDefault(NamesAnEngine);
				if (text != null)
				{
					throw new InvalidOperationException(name + " names an engine (ADR-056): \"" + text + "\"");
				}
				for (int num = Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChildrenCount(dependencyObject) - 1; num >= 0; num--)
				{
					stack.Push(Microsoft.UI.Xaml.Media.VisualTreeHelper.GetChild(dependencyObject, num));
				}
			}
			results.Add("PASS: " + name + " offers no engine choice, with Classic stored (ADR-056).");
			static bool NamesAnEngine(string? text2)
			{
				if (!string.IsNullOrEmpty(text2))
				{
					if (!text2.Contains("engine", StringComparison.OrdinalIgnoreCase) && !text2.Contains("Classic", StringComparison.OrdinalIgnoreCase))
					{
						return text2.Contains("موتور", StringComparison.Ordinal);
					}
					return true;
				}
				return false;
			}
		}

		private static Task SaveAsync(MainWindow window, string output, string name, List<string> results)
		{
			return SaveElementAsync(window.Root, output, name, results);
		}

		private static async Task SaveElementAsync(Microsoft.UI.Xaml.UIElement element, string output, string name, List<string> results)
		{
			await Task.Delay(450);
			RenderTargetBitmap bitmap = new RenderTargetBitmap();
			await bitmap.RenderAsync(element);
			if (bitmap.PixelWidth < 100 || bitmap.PixelHeight < 100)
			{
				throw new InvalidOperationException("Blank layout: " + name);
			}
			byte[] pixels = (await bitmap.GetPixelsAsync()).ToArray();
			if (pixels.Distinct().Take(16).Count() < 16)
			{
				throw new InvalidOperationException("Blank pixels: " + name);
			}
			using InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream();
			BitmapEncoder bitmapEncoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
			bitmapEncoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, (uint)bitmap.PixelWidth, (uint)bitmap.PixelHeight, 96.0, 96.0, pixels);
			await bitmapEncoder.FlushAsync();
			stream.Seek(0uL);
			using FileStream file = File.Create(System.IO.Path.Combine(output, name + ".png"));
			await stream.AsStreamForRead().CopyToAsync(file);
			results.Add($"PASS: {name} ({bitmap.PixelWidth} x {bitmap.PixelHeight})");
		}
	}
	internal sealed record DictionaryRow(Guid? Id, string Word, string Detail, string Source, bool Persian, string Status)
	{
		public Microsoft.UI.Xaml.Media.FontFamily Font
		{
			get
			{
				if (!Persian)
				{
					return Ui.ChromeFont;
				}
				return Ui.PersianFont;
			}
		}

		public Microsoft.UI.Xaml.FlowDirection Direction
		{
			get
			{
				if (!Persian)
				{
					return Microsoft.UI.Xaml.FlowDirection.LeftToRight;
				}
				return Microsoft.UI.Xaml.FlowDirection.RightToLeft;
			}
		}

		public override string ToString()
		{
			return $"{Word}, {Detail}, {Source}, {Status}";
		}
	}
	public static class Program
	{
		[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
		[DebuggerNonUserCode]
		[STAThread]
		private static void Main(string[] args)
		{
			ComWrappersSupport.InitializeComWrappers();
			Microsoft.UI.Xaml.Application.Start((Microsoft.UI.Xaml.ApplicationInitializationCallbackParams p) =>
			{
				SynchronizationContext.SetSynchronizationContext(new DispatcherQueueSynchronizationContext(Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread()));
				new App();
			});
		}
	}
}
namespace SmartInput.WinUI.SmartInput_WinUI_XamlTypeInfo
{
	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
	[DebuggerNonUserCode]
	[WinRTRuntimeClassName("Microsoft.UI.Xaml.Markup.IXamlMetadataProvider")]
	[WinRTExposedType(typeof(SmartInput_WinUI_SmartInput_WinUI_XamlTypeInfo_XamlMetaDataProviderWinRTTypeDetails))]
	public sealed class XamlMetaDataProvider : IXamlMetadataProvider
	{
		private XamlTypeInfoProvider _provider;

		private XamlTypeInfoProvider Provider
		{
			get
			{
				if (_provider == null)
				{
					_provider = new XamlTypeInfoProvider();
				}
				return _provider;
			}
		}

		[DefaultOverload]
		public IXamlType GetXamlType(System.Type type)
		{
			return Provider.GetXamlTypeByType(type);
		}

		public IXamlType GetXamlType(string fullName)
		{
			return Provider.GetXamlTypeByName(fullName);
		}

		public Microsoft.UI.Xaml.Markup.XmlnsDefinition[] GetXmlnsDefinitions()
		{
			return new Microsoft.UI.Xaml.Markup.XmlnsDefinition[0];
		}
	}
	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
	[DebuggerNonUserCode]
	internal class XamlTypeInfoProvider
	{
		private Dictionary<string, IXamlType> _xamlTypeCacheByName = new Dictionary<string, IXamlType>();

		private Dictionary<System.Type, IXamlType> _xamlTypeCacheByType = new Dictionary<System.Type, IXamlType>();

		private Dictionary<string, IXamlMember> _xamlMembers = new Dictionary<string, IXamlMember>();

		private string[] _typeNameTable;

		private System.Type[] _typeTable;

		private List<IXamlMetadataProvider> _otherProviders;

		private List<IXamlMetadataProvider> OtherProviders
		{
			get
			{
				if (_otherProviders == null)
				{
					List<IXamlMetadataProvider> list = new List<IXamlMetadataProvider>();
					IXamlMetadataProvider item = new XamlControlsXamlMetaDataProvider();
					list.Add(item);
					_otherProviders = list;
				}
				return _otherProviders;
			}
		}

		public IXamlType GetXamlTypeByType(System.Type type)
		{
			IXamlType value;
			lock (_xamlTypeCacheByType)
			{
				if (_xamlTypeCacheByType.TryGetValue(type, out value))
				{
					return value;
				}
				int num = LookupTypeIndexByType(type);
				if (num != -1)
				{
					value = CreateXamlType(num);
				}
				XamlUserType xamlUserType = value as XamlUserType;
				if (value == null || (xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType))
				{
					IXamlType xamlType = CheckOtherMetadataProvidersForType(type);
					if (xamlType != null && (xamlType.IsConstructible || value == null))
					{
						value = xamlType;
					}
				}
				if (value != null)
				{
					_xamlTypeCacheByName.Add(value.FullName, value);
					_xamlTypeCacheByType.Add(value.UnderlyingType, value);
				}
			}
			return value;
		}

		public IXamlType GetXamlTypeByName(string typeName)
		{
			if (string.IsNullOrEmpty(typeName))
			{
				return null;
			}
			IXamlType value;
			lock (_xamlTypeCacheByType)
			{
				if (_xamlTypeCacheByName.TryGetValue(typeName, out value))
				{
					return value;
				}
				int num = LookupTypeIndexByName(typeName);
				if (num != -1)
				{
					value = CreateXamlType(num);
				}
				XamlUserType xamlUserType = value as XamlUserType;
				if (value == null || (xamlUserType != null && xamlUserType.IsReturnTypeStub && !xamlUserType.IsLocalType))
				{
					IXamlType xamlType = CheckOtherMetadataProvidersForName(typeName);
					if (xamlType != null && (xamlType.IsConstructible || value == null))
					{
						value = xamlType;
					}
				}
				if (value != null)
				{
					_xamlTypeCacheByName.Add(value.FullName, value);
					_xamlTypeCacheByType.Add(value.UnderlyingType, value);
				}
			}
			return value;
		}

		public IXamlMember GetMemberByLongName(string longMemberName)
		{
			if (string.IsNullOrEmpty(longMemberName))
			{
				return null;
			}
			IXamlMember value;
			lock (_xamlMembers)
			{
				if (_xamlMembers.TryGetValue(longMemberName, out value))
				{
					return value;
				}
				value = CreateXamlMember(longMemberName);
				if (value != null)
				{
					_xamlMembers.Add(longMemberName, value);
				}
			}
			return value;
		}

		private void InitTypeTables()
		{
			_typeNameTable = new string[11];
			_typeNameTable[0] = "Microsoft.UI.Xaml.Controls.XamlControlsResources";
			_typeNameTable[1] = "Microsoft.UI.Xaml.ResourceDictionary";
			_typeNameTable[2] = "Object";
			_typeNameTable[3] = "Boolean";
			_typeNameTable[4] = "Microsoft.UI.Xaml.Thickness";
			_typeNameTable[5] = "System.ValueType";
			_typeNameTable[6] = "Double";
			_typeNameTable[7] = "Microsoft.UI.Xaml.Controls.TreeViewNode";
			_typeNameTable[8] = "Microsoft.UI.Xaml.DependencyObject";
			_typeNameTable[9] = "System.Collections.Generic.IList`1<Microsoft.UI.Xaml.Controls.TreeViewNode>";
			_typeNameTable[10] = "Int32";
			_typeTable = new System.Type[11];
			_typeTable[0] = typeof(XamlControlsResources);
			_typeTable[1] = typeof(Microsoft.UI.Xaml.ResourceDictionary);
			_typeTable[2] = typeof(object);
			_typeTable[3] = typeof(bool);
			_typeTable[4] = typeof(Microsoft.UI.Xaml.Thickness);
			_typeTable[5] = typeof(ValueType);
			_typeTable[6] = typeof(double);
			_typeTable[7] = typeof(TreeViewNode);
			_typeTable[8] = typeof(Microsoft.UI.Xaml.DependencyObject);
			_typeTable[9] = typeof(IList<TreeViewNode>);
			_typeTable[10] = typeof(int);
		}

		private int LookupTypeIndexByName(string typeName)
		{
			if (_typeNameTable == null)
			{
				InitTypeTables();
			}
			for (int i = 0; i < _typeNameTable.Length; i++)
			{
				if (string.CompareOrdinal(_typeNameTable[i], typeName) == 0)
				{
					return i;
				}
			}
			return -1;
		}

		private int LookupTypeIndexByType(System.Type type)
		{
			if (_typeTable == null)
			{
				InitTypeTables();
			}
			for (int i = 0; i < _typeTable.Length; i++)
			{
				if (type == _typeTable[i])
				{
					return i;
				}
			}
			return -1;
		}

		private object Activate_0_XamlControlsResources()
		{
			return new XamlControlsResources();
		}

		private object Activate_7_TreeViewNode()
		{
			return new TreeViewNode();
		}

		private void StaticInitializer_0_XamlControlsResources()
		{
			RuntimeHelpers.RunClassConstructor(typeof(XamlControlsResources).TypeHandle);
		}

		private void StaticInitializer_4_Thickness()
		{
			RuntimeHelpers.RunClassConstructor(typeof(Microsoft.UI.Xaml.Thickness).TypeHandle);
		}

		private void StaticInitializer_5_ValueType()
		{
			RuntimeHelpers.RunClassConstructor(typeof(ValueType).TypeHandle);
		}

		private void StaticInitializer_7_TreeViewNode()
		{
			RuntimeHelpers.RunClassConstructor(typeof(TreeViewNode).TypeHandle);
		}

		private void StaticInitializer_9_IList()
		{
			RuntimeHelpers.RunClassConstructor(typeof(IList<TreeViewNode>).TypeHandle);
		}

		private void MapAdd_0_XamlControlsResources(object instance, object key, object item)
		{
			((IDictionary<object, object>)instance).Add(key, item);
		}

		private void VectorAdd_9_IList(object instance, object item)
		{
			ICollection<TreeViewNode> collection = (ICollection<TreeViewNode>)instance;
			TreeViewNode item2 = (TreeViewNode)item;
			collection.Add(item2);
		}

		private IXamlType CreateXamlType(int typeIndex)
		{
			XamlSystemBaseType result = null;
			string fullName = _typeNameTable[typeIndex];
			System.Type type = _typeTable[typeIndex];
			switch (typeIndex)
			{
			case 0:
			{
				XamlUserType xamlUserType4 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Microsoft.UI.Xaml.ResourceDictionary"));
				xamlUserType4.Activator = Activate_0_XamlControlsResources;
				xamlUserType4.StaticInitializer = StaticInitializer_0_XamlControlsResources;
				xamlUserType4.DictionaryAdd = MapAdd_0_XamlControlsResources;
				xamlUserType4.AddMemberName("UseCompactResources");
				result = xamlUserType4;
				break;
			}
			case 1:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 2:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 3:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 4:
			{
				XamlUserType xamlUserType3 = new XamlUserType(this, fullName, type, GetXamlTypeByName("System.ValueType"));
				xamlUserType3.StaticInitializer = StaticInitializer_4_Thickness;
				xamlUserType3.AddMemberName("Left");
				xamlUserType3.AddMemberName("Top");
				xamlUserType3.AddMemberName("Right");
				xamlUserType3.AddMemberName("Bottom");
				result = xamlUserType3;
				break;
			}
			case 5:
				result = new XamlUserType(this, fullName, type, GetXamlTypeByName("Object"))
				{
					StaticInitializer = StaticInitializer_5_ValueType
				};
				break;
			case 6:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 7:
			{
				XamlUserType xamlUserType2 = new XamlUserType(this, fullName, type, GetXamlTypeByName("Microsoft.UI.Xaml.DependencyObject"));
				xamlUserType2.Activator = Activate_7_TreeViewNode;
				xamlUserType2.StaticInitializer = StaticInitializer_7_TreeViewNode;
				xamlUserType2.AddMemberName("Children");
				xamlUserType2.AddMemberName("Content");
				xamlUserType2.AddMemberName("Depth");
				xamlUserType2.AddMemberName("HasChildren");
				xamlUserType2.AddMemberName("HasUnrealizedChildren");
				xamlUserType2.AddMemberName("IsExpanded");
				xamlUserType2.AddMemberName("Parent");
				xamlUserType2.SetIsBindable();
				result = xamlUserType2;
				break;
			}
			case 8:
				result = new XamlSystemBaseType(fullName, type);
				break;
			case 9:
			{
				XamlUserType xamlUserType = new XamlUserType(this, fullName, type, null);
				xamlUserType.StaticInitializer = StaticInitializer_9_IList;
				xamlUserType.CollectionAdd = VectorAdd_9_IList;
				xamlUserType.SetIsReturnTypeStub();
				result = xamlUserType;
				break;
			}
			case 10:
				result = new XamlSystemBaseType(fullName, type);
				break;
			}
			return result;
		}

		private IXamlType CheckOtherMetadataProvidersForName(string typeName)
		{
			IXamlType xamlType = null;
			IXamlType result = null;
			foreach (IXamlMetadataProvider otherProvider in OtherProviders)
			{
				xamlType = otherProvider.GetXamlType(typeName);
				if (xamlType != null)
				{
					if (xamlType.IsConstructible)
					{
						return xamlType;
					}
					result = xamlType;
				}
			}
			return result;
		}

		private IXamlType CheckOtherMetadataProvidersForType(System.Type type)
		{
			IXamlType xamlType = null;
			IXamlType result = null;
			foreach (IXamlMetadataProvider otherProvider in OtherProviders)
			{
				xamlType = otherProvider.GetXamlType(type);
				if (xamlType != null)
				{
					if (xamlType.IsConstructible)
					{
						return xamlType;
					}
					result = xamlType;
				}
			}
			return result;
		}

		private object get_0_XamlControlsResources_UseCompactResources(object instance)
		{
			return ((XamlControlsResources)instance).UseCompactResources;
		}

		private void set_0_XamlControlsResources_UseCompactResources(object instance, object Value)
		{
			((XamlControlsResources)instance).UseCompactResources = (bool)Value;
		}

		private object get_1_Thickness_Left(object instance)
		{
			return ((Microsoft.UI.Xaml.Thickness)instance).Left;
		}

		private void set_1_Thickness_Left(object instance, object Value)
		{
			Microsoft.UI.Xaml.Thickness thickness = (Microsoft.UI.Xaml.Thickness)instance;
			thickness.Left = (double)Value;
		}

		private object get_2_Thickness_Top(object instance)
		{
			return ((Microsoft.UI.Xaml.Thickness)instance).Top;
		}

		private void set_2_Thickness_Top(object instance, object Value)
		{
			Microsoft.UI.Xaml.Thickness thickness = (Microsoft.UI.Xaml.Thickness)instance;
			thickness.Top = (double)Value;
		}

		private object get_3_Thickness_Right(object instance)
		{
			return ((Microsoft.UI.Xaml.Thickness)instance).Right;
		}

		private void set_3_Thickness_Right(object instance, object Value)
		{
			Microsoft.UI.Xaml.Thickness thickness = (Microsoft.UI.Xaml.Thickness)instance;
			thickness.Right = (double)Value;
		}

		private object get_4_Thickness_Bottom(object instance)
		{
			return ((Microsoft.UI.Xaml.Thickness)instance).Bottom;
		}

		private void set_4_Thickness_Bottom(object instance, object Value)
		{
			Microsoft.UI.Xaml.Thickness thickness = (Microsoft.UI.Xaml.Thickness)instance;
			thickness.Bottom = (double)Value;
		}

		private object get_5_TreeViewNode_Children(object instance)
		{
			return ((TreeViewNode)instance).Children;
		}

		private object get_6_TreeViewNode_Content(object instance)
		{
			return ((TreeViewNode)instance).Content;
		}

		private void set_6_TreeViewNode_Content(object instance, object Value)
		{
			((TreeViewNode)instance).Content = Value;
		}

		private object get_7_TreeViewNode_Depth(object instance)
		{
			return ((TreeViewNode)instance).Depth;
		}

		private object get_8_TreeViewNode_HasChildren(object instance)
		{
			return ((TreeViewNode)instance).HasChildren;
		}

		private object get_9_TreeViewNode_HasUnrealizedChildren(object instance)
		{
			return ((TreeViewNode)instance).HasUnrealizedChildren;
		}

		private void set_9_TreeViewNode_HasUnrealizedChildren(object instance, object Value)
		{
			((TreeViewNode)instance).HasUnrealizedChildren = (bool)Value;
		}

		private object get_10_TreeViewNode_IsExpanded(object instance)
		{
			return ((TreeViewNode)instance).IsExpanded;
		}

		private void set_10_TreeViewNode_IsExpanded(object instance, object Value)
		{
			((TreeViewNode)instance).IsExpanded = (bool)Value;
		}

		private object get_11_TreeViewNode_Parent(object instance)
		{
			return ((TreeViewNode)instance).Parent;
		}

		private IXamlMember CreateXamlMember(string longMemberName)
		{
			XamlMember xamlMember = null;
			switch (longMemberName)
			{
			case "Microsoft.UI.Xaml.Controls.XamlControlsResources.UseCompactResources":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.XamlControlsResources");
				xamlMember = new XamlMember(this, "UseCompactResources", "Boolean");
				xamlMember.SetIsDependencyProperty();
				xamlMember.Getter = get_0_XamlControlsResources_UseCompactResources;
				xamlMember.Setter = set_0_XamlControlsResources_UseCompactResources;
				break;
			case "Microsoft.UI.Xaml.Thickness.Left":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Thickness");
				xamlMember = new XamlMember(this, "Left", "Double");
				xamlMember.Getter = get_1_Thickness_Left;
				xamlMember.Setter = set_1_Thickness_Left;
				break;
			case "Microsoft.UI.Xaml.Thickness.Top":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Thickness");
				xamlMember = new XamlMember(this, "Top", "Double");
				xamlMember.Getter = get_2_Thickness_Top;
				xamlMember.Setter = set_2_Thickness_Top;
				break;
			case "Microsoft.UI.Xaml.Thickness.Right":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Thickness");
				xamlMember = new XamlMember(this, "Right", "Double");
				xamlMember.Getter = get_3_Thickness_Right;
				xamlMember.Setter = set_3_Thickness_Right;
				break;
			case "Microsoft.UI.Xaml.Thickness.Bottom":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Thickness");
				xamlMember = new XamlMember(this, "Bottom", "Double");
				xamlMember.Getter = get_4_Thickness_Bottom;
				xamlMember.Setter = set_4_Thickness_Bottom;
				break;
			case "Microsoft.UI.Xaml.Controls.TreeViewNode.Children":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember = new XamlMember(this, "Children", "System.Collections.Generic.IList`1<Microsoft.UI.Xaml.Controls.TreeViewNode>");
				xamlMember.Getter = get_5_TreeViewNode_Children;
				xamlMember.SetIsReadOnly();
				break;
			case "Microsoft.UI.Xaml.Controls.TreeViewNode.Content":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember = new XamlMember(this, "Content", "Object");
				xamlMember.SetIsDependencyProperty();
				xamlMember.Getter = get_6_TreeViewNode_Content;
				xamlMember.Setter = set_6_TreeViewNode_Content;
				break;
			case "Microsoft.UI.Xaml.Controls.TreeViewNode.Depth":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember = new XamlMember(this, "Depth", "Int32");
				xamlMember.SetIsDependencyProperty();
				xamlMember.Getter = get_7_TreeViewNode_Depth;
				xamlMember.SetIsReadOnly();
				break;
			case "Microsoft.UI.Xaml.Controls.TreeViewNode.HasChildren":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember = new XamlMember(this, "HasChildren", "Boolean");
				xamlMember.SetIsDependencyProperty();
				xamlMember.Getter = get_8_TreeViewNode_HasChildren;
				xamlMember.SetIsReadOnly();
				break;
			case "Microsoft.UI.Xaml.Controls.TreeViewNode.HasUnrealizedChildren":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember = new XamlMember(this, "HasUnrealizedChildren", "Boolean");
				xamlMember.Getter = get_9_TreeViewNode_HasUnrealizedChildren;
				xamlMember.Setter = set_9_TreeViewNode_HasUnrealizedChildren;
				break;
			case "Microsoft.UI.Xaml.Controls.TreeViewNode.IsExpanded":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember = new XamlMember(this, "IsExpanded", "Boolean");
				xamlMember.SetIsDependencyProperty();
				xamlMember.Getter = get_10_TreeViewNode_IsExpanded;
				xamlMember.Setter = set_10_TreeViewNode_IsExpanded;
				break;
			case "Microsoft.UI.Xaml.Controls.TreeViewNode.Parent":
				_ = (XamlUserType)GetXamlTypeByName("Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember = new XamlMember(this, "Parent", "Microsoft.UI.Xaml.Controls.TreeViewNode");
				xamlMember.Getter = get_11_TreeViewNode_Parent;
				xamlMember.SetIsReadOnly();
				break;
			}
			return xamlMember;
		}
	}
	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
	[DebuggerNonUserCode]
	[WinRTRuntimeClassName("Microsoft.UI.Xaml.Markup.IXamlType")]
	[WinRTExposedType(typeof(SmartInput_WinUI_SmartInput_WinUI_XamlTypeInfo_XamlSystemBaseTypeWinRTTypeDetails))]
	internal class XamlSystemBaseType : IXamlType
	{
		private string _fullName;

		private System.Type _underlyingType;

		public string FullName => _fullName;

		public System.Type UnderlyingType => _underlyingType;

		public virtual IXamlType BaseType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual IXamlMember ContentProperty
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsArray
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsCollection
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsConstructible
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsDictionary
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsMarkupExtension
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsBindable
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsReturnTypeStub
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual bool IsLocalType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual IXamlType ItemType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual IXamlType KeyType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public virtual IXamlType BoxedType
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public XamlSystemBaseType(string fullName, System.Type underlyingType)
		{
			_fullName = fullName;
			_underlyingType = underlyingType;
		}

		public virtual IXamlMember GetMember(string name)
		{
			throw new NotImplementedException();
		}

		public virtual object ActivateInstance()
		{
			throw new NotImplementedException();
		}

		public virtual void AddToMap(object instance, object key, object item)
		{
			throw new NotImplementedException();
		}

		public virtual void AddToVector(object instance, object item)
		{
			throw new NotImplementedException();
		}

		public virtual void RunInitializer()
		{
			throw new NotImplementedException();
		}

		public virtual object CreateFromString(string input)
		{
			throw new NotImplementedException();
		}
	}
	internal delegate object Activator();
	internal delegate void StaticInitializer();
	internal delegate void AddToCollection(object instance, object item);
	internal delegate void AddToDictionary(object instance, object key, object item);
	internal delegate object CreateFromStringMethod(string args);
	internal delegate object BoxInstanceMethod(object instance);
	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
	[DebuggerNonUserCode]
	[WinRTRuntimeClassName("Microsoft.UI.Xaml.Markup.IXamlType")]
	[WinRTExposedType(typeof(SmartInput_WinUI_SmartInput_WinUI_XamlTypeInfo_XamlSystemBaseTypeWinRTTypeDetails))]
	internal class XamlUserType : XamlSystemBaseType, IXamlType
	{
		private XamlTypeInfoProvider _provider;

		private IXamlType _baseType;

		private IXamlType _boxedType;

		private bool _isArray;

		private bool _isMarkupExtension;

		private bool _isBindable;

		private bool _isReturnTypeStub;

		private bool _isLocalType;

		private string _contentPropertyName;

		private string _itemTypeName;

		private string _keyTypeName;

		private Dictionary<string, string> _memberNames;

		private Dictionary<string, object> _enumValues;

		public override IXamlType BaseType => _baseType;

		public override bool IsArray => _isArray;

		public override bool IsCollection => CollectionAdd != null;

		public override bool IsConstructible => Activator != null;

		public override bool IsDictionary => DictionaryAdd != null;

		public override bool IsMarkupExtension => _isMarkupExtension;

		public override bool IsBindable => _isBindable;

		public override bool IsReturnTypeStub => _isReturnTypeStub;

		public override bool IsLocalType => _isLocalType;

		public override IXamlType BoxedType => _boxedType;

		public override IXamlMember ContentProperty => _provider.GetMemberByLongName(_contentPropertyName);

		public override IXamlType ItemType => _provider.GetXamlTypeByName(_itemTypeName);

		public override IXamlType KeyType => _provider.GetXamlTypeByName(_keyTypeName);

		public Activator Activator { get; set; }

		public StaticInitializer StaticInitializer { get; set; }

		public AddToCollection CollectionAdd { get; set; }

		public AddToDictionary DictionaryAdd { get; set; }

		public CreateFromStringMethod CreateFromStringMethod { get; set; }

		public BoxInstanceMethod BoxInstance { get; set; }

		public XamlUserType(XamlTypeInfoProvider provider, string fullName, System.Type fullType, IXamlType baseType)
			: base(fullName, fullType)
		{
			_provider = provider;
			_baseType = baseType;
		}

		public override IXamlMember GetMember(string name)
		{
			if (_memberNames == null)
			{
				return null;
			}
			if (_memberNames.TryGetValue(name, out var value))
			{
				return _provider.GetMemberByLongName(value);
			}
			return null;
		}

		public override object ActivateInstance()
		{
			return Activator();
		}

		public override void AddToMap(object instance, object key, object item)
		{
			DictionaryAdd(instance, key, item);
		}

		public override void AddToVector(object instance, object item)
		{
			CollectionAdd(instance, item);
		}

		public override void RunInitializer()
		{
			StaticInitializer();
		}

		public override object CreateFromString(string input)
		{
			if (BoxedType != null)
			{
				return BoxInstance(BoxedType.CreateFromString(input));
			}
			if (CreateFromStringMethod != null)
			{
				return CreateFromStringMethod(input);
			}
			if (_enumValues != null)
			{
				long num = 0L;
				string[] array = input.Split(',');
				foreach (string text in array)
				{
					long num2 = 0L;
					try
					{
						if (_enumValues.TryGetValue(text.Trim(), out var value))
						{
							num2 = Convert.ToInt64(value);
						}
						else
						{
							try
							{
								num2 = Convert.ToInt64(text.Trim());
							}
							catch (FormatException)
							{
								foreach (string key in _enumValues.Keys)
								{
									if (string.Compare(text.Trim(), key, StringComparison.OrdinalIgnoreCase) == 0 && _enumValues.TryGetValue(key.Trim(), out value))
									{
										num2 = Convert.ToInt64(value);
										break;
									}
								}
							}
						}
						num |= num2;
					}
					catch (FormatException)
					{
						throw new ArgumentException(input, FullName);
					}
				}
				return Convert.ChangeType(num, Enum.GetUnderlyingType(UnderlyingType));
			}
			throw new ArgumentException(input, FullName);
		}

		public void SetContentPropertyName(string contentPropertyName)
		{
			_contentPropertyName = contentPropertyName;
		}

		public void SetIsArray()
		{
			_isArray = true;
		}

		public void SetIsMarkupExtension()
		{
			_isMarkupExtension = true;
		}

		public void SetIsBindable()
		{
			_isBindable = true;
		}

		public void SetIsReturnTypeStub()
		{
			_isReturnTypeStub = true;
		}

		public void SetIsLocalType()
		{
			_isLocalType = true;
		}

		public void SetItemTypeName(string itemTypeName)
		{
			_itemTypeName = itemTypeName;
		}

		public void SetKeyTypeName(string keyTypeName)
		{
			_keyTypeName = keyTypeName;
		}

		public void SetBoxedType(IXamlType boxedType)
		{
			_boxedType = boxedType;
		}

		public object BoxType<T>(object instance) where T : struct
		{
			return (T)instance;
		}

		public void AddMemberName(string shortName)
		{
			if (_memberNames == null)
			{
				_memberNames = new Dictionary<string, string>();
			}
			_memberNames.Add(shortName, FullName + "." + shortName);
		}

		public void AddEnumValue(string name, object value)
		{
			if (_enumValues == null)
			{
				_enumValues = new Dictionary<string, object>();
			}
			_enumValues.Add(name, value);
		}
	}
	internal delegate object Getter(object instance);
	internal delegate void Setter(object instance, object value);
	[GeneratedCode("Microsoft.UI.Xaml.Markup.Compiler", " 3.0.0.2608")]
	[DebuggerNonUserCode]
	[WinRTRuntimeClassName("Microsoft.UI.Xaml.Markup.IXamlMember")]
	[WinRTExposedType(typeof(SmartInput_WinUI_SmartInput_WinUI_XamlTypeInfo_XamlMemberWinRTTypeDetails))]
	internal class XamlMember : IXamlMember
	{
		private XamlTypeInfoProvider _provider;

		private string _name;

		private bool _isAttachable;

		private bool _isDependencyProperty;

		private bool _isReadOnly;

		private string _typeName;

		private string _targetTypeName;

		public string Name => _name;

		public IXamlType Type => _provider.GetXamlTypeByName(_typeName);

		public IXamlType TargetType => _provider.GetXamlTypeByName(_targetTypeName);

		public bool IsAttachable => _isAttachable;

		public bool IsDependencyProperty => _isDependencyProperty;

		public bool IsReadOnly => _isReadOnly;

		public Getter Getter { get; set; }

		public Setter Setter { get; set; }

		public XamlMember(XamlTypeInfoProvider provider, string name, string typeName)
		{
			_name = name;
			_typeName = typeName;
			_provider = provider;
		}

		public void SetTargetTypeName(string targetTypeName)
		{
			_targetTypeName = targetTypeName;
		}

		public void SetIsAttachable()
		{
			_isAttachable = true;
		}

		public void SetIsDependencyProperty()
		{
			_isDependencyProperty = true;
		}

		public void SetIsReadOnly()
		{
			_isReadOnly = true;
		}

		public object GetValue(object instance)
		{
			if (Getter != null)
			{
				return Getter(instance);
			}
			throw new InvalidOperationException("GetValue");
		}

		public void SetValue(object instance, object value)
		{
			if (Setter != null)
			{
				Setter(instance, value);
				return;
			}
			throw new InvalidOperationException("SetValue");
		}
	}
}
namespace SmartInput.WinUI.Views
{
	internal enum HelpTopic
	{
		GettingStarted,
		TypingModes,
		AutomaticCorrection,
		ManualTyping,
		CapsLock,
		ShiftSwitch,
		KeyboardLayout,
		Correcting,
		Dictionary,
		TextDirection,
		Translation,
		Fonts,
		Shortcuts,
		StartupAndUpdates,
		Troubleshooting,
		InterfaceLanguage,
		Glossary
	}
	internal sealed record HelpText(string Title, string Summary, IReadOnlyList<string> Points, bool NumberedPoints = false);
	internal sealed record HelpEntry(HelpTopic Topic, HelpText English, HelpText Persian)
	{
		public HelpText In(UiLanguage language)
		{
			if (language != UiLanguage.Persian)
			{
				return English;
			}
			return Persian;
		}
	}
	internal readonly record struct HelpPart(string Text, bool IsSpan);
	internal static class HelpContent
	{
		public const char SpanMark = '`';

		public const string ProseTag = "help-prose";

		private static IReadOnlyList<HelpEntry>? _all;

		private static readonly Dictionary<HelpTopic, HelpText> English = new Dictionary<HelpTopic, HelpText>
		{
			[HelpTopic.GettingStarted] = new HelpText("Getting started", "Diyar lets you type Persian while Windows stays on the English (US) keyboard. Press the keys where the Persian letters sit on a Persian keyboard, and Diyar writes Persian in the app you are typing in.", new <>z__ReadOnlyArray<string>(new string[6] { "Check that the status at the bottom of the side bar reads Active · Pause (Diyar is on).", "Keep the Windows keyboard on English (United States).", "Start with the Automatic correction typing mode in Settings › Typing.", "Type a Persian word and finish it with Space, Enter, Tab or punctuation.", "Correction runs on this PC, and what you type is never sent anywhere. Only text you select and translate with Azure Translator leaves this PC.", "If a word stays in English letters, type it with Caps Lock: under Settings › Typing › Caps Lock and hold key, choose Caps Lock as the Key for Persian. Then turn Caps Lock on, type the word (each key types its Persian letter), and turn Caps Lock off to continue." }), NumberedPoints: true),
			[HelpTopic.TypingModes] = new HelpText("Choosing a typing mode", "Exactly one typing mode is active at a time. Selecting a mode turns the others off, and Settings › Typing shows only the options of the selected mode. There are two main modes; the two others are under Other modes.", new <>z__ReadOnlyArray<string>(new string[4] { "Automatic correction converts recognized Persian words when you finish them. Best for everyday writing that mixes Persian and English.", "Persian typing (direct) types each key's Persian letter the moment you press it, as on a Persian keyboard; nothing you typed is read or replaced. English is typed with the hold key, so choose one (Caps Lock is recommended).", "Other modes: Caps Lock switch lets Caps Lock change the Windows language, or type Persian directly only while it is on.", "Other modes: Shift key switch types in your second Windows language for as long as you hold the Shift key you chose as the switch key." })),
			[HelpTopic.AutomaticCorrection] = new HelpText("Automatic correction", "A word becomes Persian when the evidence shows it was typed for the Persian layout: it is a known Persian word, or one of its keys is a Persian letter but only punctuation in English, such as , or ; inside the word. English words, words missing from both dictionaries, capitalized words, technical terms, web and email addresses, file paths, numbers and shortcuts stay as you typed them.", new <>z__ReadOnlyArray<string>(new string[18]
			{
				"Inside an English paragraph, only known Persian words convert, and a one- or two-letter Persian word such as و, من or در stays as typed: two-letter English fragments are written with the same keys. Names, acronyms and addresses such as LNG or name@example.com do not count as English, so Persian sentences containing them still convert short words.", "The , key is the letter و on the Persian keyboard, in every position of a word: کار, becomes کارو. Type the Persian comma ، with Shift+7, as on the Persian Standard keyboard. Words ending in ا, آ, ه, و, ی or ء keep the comma, because Persian writes خانه\u200cرو.", "After a Persian word the ? key types the Persian question mark ؟, also while the hold key types Persian and in Persian typing (direct). %, !, . and : stay as typed, punctuation after an address, path, version, time or number is never changed, and brackets are never swapped: the editor mirrors them in right-to-left text.", "Before replacing a word, Diyar checks the text in your editor. If a key or mouse click moved the cursor, the word is left as typed so that no other text is touched.", "Toggle last typed word (Ctrl+Alt+Space) converts the word right before the cursor, with or without the space after it: Latin keyboard text becomes Persian and Persian becomes the Latin keys. Press it again before typing anything to get the exact original back. It needs the Diyar text service, which the setup program installs.", "Backspace after a converted word deletes one letter, as in any editor. To turn the word back into the keys you typed, press Toggle last typed word (Ctrl+Alt+Space) right after it; press it again to convert it back.", "Caps Lock and hold key: choose a Key for English, a Key for Persian, or both. While you hold the Key for English you type plain English with nothing corrected, and while you hold the Key for Persian each key types its Persian letter, as on a Persian keyboard. Release the key to return to correction; what you already typed is not changed. Caps Lock is recommended for one of them: it works as an on/off switch (while it is on, its language is typed) and no other key loses its job. The two keys must differ and cannot be both sides of one Shift, Ctrl or Alt; if you hold both, the one pressed first counts. A chosen Shift, Ctrl or Alt key no longer does its usual job anywhere.", "While Caps Lock is on, unless Caps Lock is the hold key, correction pauses and Windows types capitals.", "With Capital first letter for English after Persian on (off by default, next to the hold key), the first letter of an English word typed with the hold key right after a Persian word is a capital; names written in lowercase (npm, git) get one too, so press Backspace and retype the letter, or type it with Shift to choose the case yourself.", "With Let Windows shortcuts use the hold key on (the default), a hold key pressed together with Win, Ctrl or Alt goes to Windows as part of the shortcut: Win+Shift+S and Ctrl+Shift+T work with Left Shift as a hold key. Pressed first, the hold key joins the shortcut only while nothing has been typed with it yet, so Ctrl+Z in the middle of a held word stays Undo.",
				"With End the English word at a Space typed with the hold key on (the default), a Space, Enter or Tab typed while you still hold the key for English ends the English word, so the next word you type after releasing the key is corrected as usual. A Backspace, an arrow key or a shortcut pressed after the release keeps the held word English until its next Space.", "Persian word forms: a known Persian word followed by up to two suffixes the dictionary does not list - ها, های, تر, ترین, ی, م, ت, ش, مان, تان, شان, ام, ای, رو and a few more - becomes Persian next to Persian text: درخت\u200cها, درختهاش, اطلاعاتی. A word typed without its half-space after می (میرسیم) counts too. Keys that spell an English word stay English, a word with suffixes also stays when its keys are an English typo, and inside English text nothing changes. Separate endings such as ها and رو also convert right after an English word: Button ها رو. Choose Separate endings only, or Off to decide these words exactly as before. Not recognized: stem changes such as خستگی, longer chains, and a Persian ending glued to a Latin word.", "Priority for ambiguous input decides a word that is both a known English word and a known Persian word, such as fun (بعد) or leg (مثل): Normal keeps a common English word English, Persian makes it Persian and English keeps it English. Contextual makes it Persian only when its Persian reading is a common Persian word and the words before it are Persian - two Persian words in a row, a Persian word such as به or برای, or a message with no English in it yet - and keeps it English after an English word, as the first word, and when it is one of the commonest English words such as and, how or do. Persian and English also decide a single letter typed on its own and the comma key.", "Correct confident Persian spelling mistakes fixes common typing errors in converted words.", "Start a new word after a keyboard-layout switch: when you switch the Windows layout with Alt+Shift, Win+Space or the language bar in the middle of a word, the letters typed before the switch are left as they are and only what you type after it is checked when the word is finished. Turn it off to have the keys typed under both layouts treated as one word, as in earlier versions.", "Under Keys that finish a word, choose which keys finish one: Space, Enter and Tab. They are a set, not alternatives - any key you turn on checks the word. Punctuation such as . ! ? always finishes a word.", "Persian digits in Persian text (off by default, under Settings › Typing › Automatic correction › Numbers): when it is on, a number of up to six digits that you finish with Space, Enter or Tab becomes the digits of your Persian layout if the word before it is Persian, so 3.5 becomes ۳٫۵. A comma counts as a separator only before exactly three digits (1,000). Numbers with a leading zero, times, dates, addresses, versions and anything in a spreadsheet, code editor or terminal stay as typed. Backspace reopens a converted number like a word, and a digit typed right after a Persian digit is a Persian digit; the Windows Persian layout types ASCII digits, so nothing changes there.", "English-only places, under Settings › Typing: Diyar leaves your keys as typed in a browser's address bar, in a field that holds a web address, in payment card and password fields and, in Automatic correction, in terminals, launchers, database tools, remote desktop and password managers. Switch any of them off to type there with your typing mode, as everywhere else. Password fields are always protected. A shell inside Windows Terminal, such as PowerShell, follows Windows Terminal's switch."
			})),
			[HelpTopic.ManualTyping] = new HelpText("Persian typing (direct)", "Each key types its Persian letter the moment you press it, as on a Persian keyboard. Diyar never reads, replaces or deletes what you typed in this mode.", new <>z__ReadOnlyArray<string>(new string[8] { "Shift gives the shifted letter, as on a Persian keyboard: آ (Shift+H) and ژ (Shift+C); on Persian Standard, Shift+B is the half-space. No dictionary is used, so a capital letter does not keep a word English.", "English: choose a Key for English under Caps Lock and hold key. While you hold it, or while Caps Lock is on when Caps Lock is the key, the keys type plain English. Caps Lock is recommended: it works as an on/off switch, so no other key loses its job. With no key set there is no way to type English in this mode except switching the Windows keyboard language or pausing Diyar.", "With Capital first letter for English after Persian on (off by default, next to the hold key), the first letter of an English word typed with the hold key right after a Persian word is a capital; names written in lowercase (npm, git) get one too, so press Backspace and retype the letter, or type it with Shift to choose the case yourself.", "With Let Windows shortcuts use the hold key on (the default), a hold key pressed together with Win, Ctrl or Alt goes to Windows as part of the shortcut: Win+Shift+S and Ctrl+Shift+T work with Left Shift as a hold key. Pressed first, the hold key joins the shortcut only while nothing has been typed with it yet, so Ctrl+Z in the middle of a held word stays Undo.", "With End the English word at a Space typed with the hold key on (the default), a Space, Enter or Tab typed while you still hold the key for English ends the English word, so the next word you type after releasing the key is typed in Persian again. A Backspace, an arrow key or a shortcut pressed after the release keeps the held word English until its next Space.", "Backspace deletes one letter. On a symbol key, Shift types the Persian keyboard's own symbol or mark, as the Windows Persian keyboard does: the diacritics, ٪, ×, ریال, the Persian comma ،, the guillemets and the brackets. Digits and other punctuation stay as typed.", "Caps Lock does not pause this mode unless it is the hold key: the keys still type Persian letters while it is on.", "Every letter key types Persian in every application except protected fields, including single-key shortcuts in games and editors; pause Diyar there." })),
			[HelpTopic.CapsLock] = new HelpText("Caps Lock switch", "Under When Caps Lock is on, choose what Caps Lock does.", new <>z__ReadOnlyArray<string>(new string[5] { "Switch Windows language: turning Caps Lock on switches Windows to the language you choose, English or Persian, and turning it off switches to the other one. Nothing is corrected. With English you can also set the English letter case: normal letter case or capital letters.", "Persian typing (direct) while on: while Caps Lock is on, each key types its Persian letter the moment you press it, exactly like Persian typing (direct). Nothing is read or replaced, and Backspace deletes one letter.", "With Persian typing while on, a Persian keyboard switches to English when Caps Lock turns on, and your previous language returns when it turns off.", "Auto correction while on is no longer offered. A profile that already uses it keeps it, shown as (legacy): it works like Automatic correction while Caps Lock is on, with letters in normal case.", "Both languages must already be installed in Windows: switching never installs one. Add a missing language under Keyboard with Install." })),
			[HelpTopic.ShiftSwitch] = new HelpText("Shift key switch", "Hold the switch key to type in your second Windows language, and release it to return to the first. Nothing is corrected while this mode is selected.", new <>z__ReadOnlyArray<string>(new string[3] { "Choose which Shift key switches the language. The other Shift key keeps its usual role, so capitals, English punctuation such as < > ? : \" and Persian letters such as آ and ژ stay available while you hold the switch key.", "When the second language is English, the first letter is capitalized for you and Caps Lock works normally.", "Both languages must already be installed in Windows." })),
			[HelpTopic.KeyboardLayout] = new HelpText("Persian keyboard layout", "Select the Persian layout you learned to type on, so each key produces the letter you expect.", new <>z__ReadOnlyArray<string>(new string[5] { "Persian Standard follows the national standard layout (ISIRI 9147). Windows Persian is the older Windows layout.", "Detect installed layout uses the Persian layout installed in Windows.", "If letters that need Shift, such as ژ or آ, come out wrong, choose your exact layout.", "When more than one English or Persian layout is installed, choose the one Diyar switches to under Default English layout and Default Persian layout.", "If English or Persian is not installed in Windows, choose one under Layout to install and press Install; Diyar adds it for your account without administrator rights." })),
			[HelpTopic.Correcting] = new HelpText("Correcting and undoing", "Every conversion can be corrected or undone from the keyboard.", new <>z__ReadOnlyArray<string>(new string[6] { "In Automatic correction, press Toggle last typed word (Ctrl+Alt+Space) right after a converted word to turn it back into the keys you typed, and press it again to convert it back. Backspace deletes one letter.", "Undo last translation (Ctrl+Alt+Z) restores the latest translation; it is registered only while translation is on.", "Add selected word to personal dictionary (Ctrl+Alt+D) saves the one word you selected, in its language, without changing your text. With nothing selected it says so; it never uses an older word.", "Convert selected word (Ctrl+Alt+Enter) converts the one word you selected; pressing it again on the unchanged result puts back the exact original. Toggle last typed word (Ctrl+Alt+Space) does the same for the word right before the cursor. Undo last manual correction (Ctrl+Alt+U) restores the last of these corrections and withdraws what it added to your personal dictionary.", "These three work inside the application you type in through the Diyar text service (installed by the setup program). Password, read-only and composing fields are refused, and nothing is changed when the text moved or changed in between.", "Convert non-dictionary words (Ctrl+Alt+N) is not available and is not registered in this build." })),
			[HelpTopic.Dictionary] = new HelpText("Dictionaries and learning", "Diyar reads three separate things: the built-in dictionary, your personal dictionary, and the word review queue.", new <>z__ReadOnlyArray<string>(new string[4] { "Built-in dictionary: the Persian and English vocabulary that ships with the app. It is read-only and is refreshed by app updates; nothing you do changes it.", "Personal dictionary: words you accepted, each marked Persian or English. It is kept in your profile and survives updates. During recognition it is used alongside the built-in dictionary under the same mode and priority rules; adding a word does not guarantee it converts in every editor. Deleting a personal word does not delete a built-in word.", "Word review queue: words proposed after a confirmed correction, waiting for you. A proposal does not affect recognition until you accept it. Accepting adds it to the personal dictionary; rejecting removes it. Turn on Add confirmed corrections to my personal dictionary automatically to skip the queue.", "Add your own words with Add words, or press Ctrl+Alt+D to add the selected text. Import merges a JSON, CSV or TXT file into the personal dictionary and reports how many words were added, already there, already built in or rejected. Export writes personal words only, with each word's language." })),
			[HelpTopic.TextDirection] = new HelpText("Mixed text, direction and amounts", "Diyar keeps Persian and English in the right order.", new <>z__ReadOnlyArray<string>(new string[4] { "Automatic correction switches a paragraph to right to left only after it converts a Persian word. Persian typing (direct) never changes a paragraph's direction.", "Stabilize mixed Persian and English text keeps word and punctuation order correct in editors that ignore the Windows direction shortcut. It marks a right-to-left paragraph once, with an invisible Unicode direction mark at its start, and never closes it; Enter adds nothing, and the next paragraph gets its own mark. In Persian typing (direct) and the Shift key switch the mark goes before the first Persian letter. Turn it off for source code or data files; then no direction marks are added.", "In Automatic correction, when a paragraph starts with short plain English text you just typed, such as github, that start is typed again behind the mark so the line reads right to left, unless the editor shows it differently from the keys you typed. It is never typed again in an editor that corrects text by itself, in Word, Notepad or a console, or while Windows autocorrect for hardware keyboards is on: the mark then goes before the Persian word, and the paragraph may stay left to right.", "Format Persian currency amounts works when Automatic correction converts تومان or ریال typed with English keys (j,lhk, vdhg) at Space, Enter, Tab or punctuation, and in the Caps Lock actions that convert finished words. The number typed just before it, separated only by spaces, is rewritten with Persian digits and thousands grouping, as in ۱٬۰۰۰ تومان. A number joined to other characters (a date, a time, code-1000) is left as it is, and so is a number that was already on screen before you clicked into the text. Units typed on the Persian keyboard and other words such as هزار تومان, میلیون or ت are never formatted, and nothing is formatted in Persian typing (direct) or by Toggle last typed word. Where Backspace reopens a converted word, after an amount it reopens only the unit; the number stays formatted." })),
			[HelpTopic.Translation] = new HelpText("Translation and privacy", "Translate selected text without leaving the app you are working in.", new <>z__ReadOnlyArray<string>(new string[11]
			{
				"Turn on Enable translation shortcut, choose a translation service and a target language, select text, then press Translate selected text (Ctrl+Alt+T). The selection is replaced only if the same text is still selected in the same app.", "On-device translation keeps text on this PC after a one-time model download.", "Azure Translator uses your own Azure key and an internet connection, and sends only the selected text. The key is stored in Windows Credential Manager.", "The notice says what happened: the text is reported translated only after Diyar has read the translation back from the editor; when it was sent but could not be read back, the notice says it is not confirmed, so check the editor; and when nothing was changed, the notice says why it was refused.", "Within 15 seconds of a confirmed translation, Undo last translation (Ctrl+Alt+Z) restores the original text, while Allow undo with the Undo last translation shortcut is on. It replaces only the translation the editor still shows at the caret.", "Use the clipboard where the editor cannot be read: some editors cannot be read directly. With this on, the selection is copied and the translation pasted; the copy stays out of clipboard history and cloud sync, and the previous clipboard text is put back. With it off, those selections are refused and the clipboard is never touched.", "Automatic (Persian ↔ English) as the target language translates a mostly Persian or Arabic selection to English and any other selection to Persian, so one shortcut serves both directions. A selection without letters, such as numbers only, goes to English. Choose a language instead to translate every selection into it.", "While a translation runs, a notice says so. Press the same translate shortcut again, or Cancel in the notice, to stop it; a cancelled translation changes nothing. A translation that takes longer than 120 seconds is stopped on its own.", "Translate clipboard text (Ctrl+Alt+Shift+T) translates the text on the clipboard and puts the translation back on the clipboard, without touching the text you are editing, so it works in every application and for several lines at once. The translation stays out of clipboard history and cloud sync; paste it where you need it. It cannot be undone: copy the original again if you need it.", "When Azure Translator answers that the quota or rate limit was reached, or that it is temporarily unavailable, Diyar waits as long as Azure asks, up to a few seconds, and tries again, at most three times, before it tells you.",
				"Load the model when Diyar starts (on-device translation only, off by default) loads the downloaded model in the background once after start-up or after you turn it on, so the first translation does not wait for it; the model then stays in memory while Diyar runs. Cancel download stops the model download."
			})),
			[HelpTopic.Fonts] = new HelpText("Typing font and application fonts", "Set your preferred Persian font as the default font of supported applications.", new <>z__ReadOnlyArray<string>(new string[7] { "Choose a typing font, select the applications to update, then click Apply font. Only supported applications installed on this PC are listed.", "Changed directly: Microsoft Word (new documents); Edge and Chrome (with their Beta, Dev and Canary editions), Brave, Vivaldi, Opera and Firefox (pages without their own font); Thunderbird (message fonts); Visual Studio Code (editor font); Windows Terminal (all profiles). Notepad, Outlook and LibreOffice Writer are listed as Manual setup: set the font in the application itself.", "Choose a font installed in Windows: another application cannot use a font it does not find, so Diyar refuses one that is not installed and names the installed Shabnam FD in its place. The installer adds Shabnam and Shabnam FD.", "Close all windows of a browser before applying. A browser's row then reads Written: the browser uses the font only on pages that do not choose their own, and most websites do. Show in browser opens a page without a font of its own, to see the font the browser now uses. Firefox and Thunderbird need a restart.", "When an application changes the setting back (a browser saving its own settings, sync, or a change you made in the application), its row reads Reverted and a notice names it: apply the font again. Refresh applications also asks a closed Word for its Normal style.", "Restore previous puts back each application's earlier setting exactly.", "Messaging apps such as WhatsApp and Telegram have no font setting that another program can change." })),
			[HelpTopic.Shortcuts] = new HelpText("Keyboard shortcuts", "Every shortcut can be changed under Settings › Shortcuts; where each one works is described in its topic.", new <>z__ReadOnlyArray<string>(new string[4] { "A shortcut combines Ctrl, Alt or Shift with one other key. The Windows key is not used, so system shortcuts stay intact.", "A shortcut assigned to two commands is reported and not saved, and so is one another program has already registered with Windows. Convert selected word, Toggle last typed word and Undo last manual correction belong to the Diyar text service, so a clash with another program's shortcut for one of those three is not detected.", "Modifier-only combinations such as Alt+Shift are reserved by Windows for switching the keyboard.", "Pause or resume typing (Ctrl+Alt+P by default) works in every application, also while Diyar is paused. It does the same as the Pause button in the main window and the Pause typing item in the notification-area menu. While Diyar is paused it touches no key: the keyboard works as plain Windows, and the notification-area icon is dimmed and reads Diyar · Paused. Paused stays paused until you resume, even after a restart." })),
			[HelpTopic.StartupAndUpdates] = new HelpText("Startup and updates", "Diyar runs quietly in the notification area.", new <>z__ReadOnlyArray<string>(new string[7] { "Run when Windows starts opens Diyar in the notification area when you sign in.", "Closing the window keeps Diyar running. Use its notification-area icon to open it again, pause or resume typing, or exit.", "Check for updates at startup reads the Diyar release information over a secure connection about a minute and a half after Diyar starts, at most once a day. If the network is not ready yet, it tries once more ten minutes later. Check for updates checks at once. Both are under Settings › General › Updates, with the Release channel.", "When a newer version is available, a Windows notification and a notice in the window say so; click the notification to open Settings › General › Updates. Nothing is downloaded or installed until you click. On the Updates card, Update now downloads the installer and checks it against the publisher's signed release information; a file that does not match is deleted and never run. Install and restart Diyar then runs it: Diyar closes, the update is installed and Diyar opens again by itself. Windows asks for permission once and may name the publisher as unknown, because the installer is not signed with a code-signing certificate. View release opens the release page, where you can also download the installer and run it yourself.", "When Diyar opens again after an update, it says Diyar was updated to the new version, and shows its window if it was open when you clicked. If the update did not finish (the permission was refused, setup was cancelled or failed, or the computer restarted during it), Diyar says so: Open the setup log shows what happened, and Try again installs the installer already downloaded, after checking it again. The installer, its log and an unfinished download are kept in %LOCALAPPDATA%\\SmartInput\\Updates: an installer is deleted once its version is installed, and an unfinished download and the setup logs after 14 days.", "Test builds are never offered as updates.", "Diyar's publisher signs the release information. Once this copy of Diyar holds the publisher's key, it checks that signature and the information's date before it shows any version: if the check fails, Settings › General › Updates says the update information could not be verified, is not signed, or is out of date, and offers nothing. An update source you enter must serve the publisher's own file, unchanged." })),
			[HelpTopic.Troubleshooting] = new HelpText("Troubleshooting", "Most problems have a quick fix.", new <>z__ReadOnlyArray<string>(new string[6] { "Nothing converts: check that the status reads Active · Pause, Windows is on English (US), and the typing mode is Automatic correction or Persian typing (direct).", "A Persian word stays in English letters: add the word to your dictionary.", "An English word was converted: press Toggle last typed word (Ctrl+Alt+Space) right away to get the keys you typed back, and add the word to your dictionary as English.", "Password fields, browser address bars and apps running as administrator are protected or cannot be changed.", "Words appear in the wrong order: keep Stabilize mixed Persian and English text on, or use the editor's right-to-left command.", "Reporting a problem: turn on Debug mode in Settings › General › Diagnostics, repeat what went wrong, then send the log from Open log folder or a saved report. The log records the words you type with what was decided and done, samples of the text your editor showed before the cursor, the application, window title and field you typed into, the settings in force, keyboard-layout changes and the records around anything that went wrong (every word is written to the file, with a per-application summary every 10 minutes; up to a full day is kept, eight files of 8 MiB). Sending it shares that text, so do not type passwords or private text while it is on. Use Report recent typing problem right after it happens, before anything else: turning Debug mode off afterwards clears the temporary log and the recent history, and only saved reports are kept." })),
			[HelpTopic.InterfaceLanguage] = new HelpText("Interface language", "Interface language under Settings › General switches Diyar's window, tray menu and messages between English and فارسی at once; typing works the same in either. Help has its own English/فارسی switch.", new <>z__ReadOnlyArray<string>(new string[3] { "The change takes effect at once, without a restart, and is kept for the next start. Typing, conversion and your shortcuts work exactly the same in either language.", "In Persian, the names of products, applications and fonts, keys such as Caps Lock, and paths stay in Latin letters. Windows' own dialogs, such as the file pickers, follow the Windows display language.", "Help opens in the interface language. To read the English names, for example when you report a problem, switch Help to English or read the Glossary topic, which lists each setting in both languages." })),
			[HelpTopic.Glossary] = new HelpText("Glossary", "The names of the settings and commands in English and in Persian, so you can follow help or an answer written in the other language.", Array.Empty<string>())
		};

		private static readonly Dictionary<HelpTopic, HelpText> Persian = new Dictionary<HelpTopic, HelpText>
		{
			[HelpTopic.GettingStarted] = new HelpText("شروع کار", "با `Diyar` می\u200cتوانید فارسی تایپ کنید و صفحه\u200cکلید ویندوز را روی انگلیسی نگه دارید. هر حرف فارسی را با همان کلیدی بزنید که روی صفحه\u200cکلید فارسی دارد؛ `Diyar` در همان برنامه\u200cای که در آن می\u200cنویسید فارسی تایپ می\u200cکند.", new <>z__ReadOnlyArray<string>(new string[6] { "پایین نوار کناری را نگاه کنید: باید «فعال · توقف» را ببینید، یعنی `Diyar` روشن است.", "صفحه\u200cکلید ویندوز را روی `English (United States)` نگه دارید.", "برای شروع، در «تنظیمات › تایپ» حالت «اصلاح خودکار» را انتخاب کنید.", "یک واژه\u0654 فارسی تایپ کنید و آن را با فاصله، `Enter`، `Tab` یا یک نشانه\u0654 نگارشی تمام کنید.", "اصلاح روی همین رایانه انجام می\u200cشود و آنچه تایپ می\u200cکنید به هیچ جا فرستاده نمی\u200cشود. فقط متنی که خودتان انتخاب کنید و با `Azure Translator` ترجمه کنید از این رایانه بیرون می\u200cرود.", "اگر واژه\u200cای با حروف انگلیسی ماند، آن را با `Caps Lock` تایپ کنید. در «تنظیمات › تایپ › `Caps Lock` و کلید نگه\u200cداشتن»، `Caps Lock` را به\u200cعنوان «کلید برای فارسی» انتخاب کنید. سپس `Caps Lock` را روشن کنید و واژه را بنویسید؛ هر کلید حرف فارسی خودش را تایپ می\u200cکند. برای ادامه، `Caps Lock` را خاموش کنید." }), NumberedPoints: true),
			[HelpTopic.TypingModes] = new HelpText("انتخاب حالت تایپ", "در هر لحظه فقط یک حالت تایپ فعال است. با انتخاب یک حالت، حالت\u200cهای دیگر خاموش می\u200cشوند و «تنظیمات › تایپ» فقط گزینه\u200cهای همان حالت را نشان می\u200cدهد. دو حالت اصلی هست و دو حالت دیگر زیر «حالت\u200cهای دیگر» آمده\u200cاند.", new <>z__ReadOnlyArray<string>(new string[4] { "«اصلاح خودکار» واژه\u0654 فارسی شناخته\u200cشده را همین که تمامش کنید فارسی می\u200cکند. برای نوشتن روزمره، که فارسی و انگلیسی را با هم دارد، بهترین انتخاب است.", "«تایپ مستقیم فارسی» با زدن هر کلید، همان لحظه حرف فارسی آن را می\u200cنویسد، درست مثل صفحه\u200cکلید فارسی. چیزی از آنچه نوشته\u200cاید خوانده یا جایگزین نمی\u200cشود. انگلیسی را با «کلید نگه\u200cداشتن» تایپ می\u200cکنید، پس یک کلید انتخاب کنید؛ `Caps Lock` پیشنهاد می\u200cشود.", "«حالت\u200cهای دیگر»: در «تعویض زبان با `Caps Lock`»، کلید `Caps Lock` زبان ویندوز را عوض می\u200cکند، یا فقط تا وقتی روشن است فارسی را مستقیم تایپ می\u200cکند.", "«حالت\u200cهای دیگر»: در «تعویض زبان با `Shift`»، تا وقتی `Shift`ی را که به\u200cعنوان «کلید تعویض» انتخاب کرده\u200cاید نگه داشته\u200cاید، با زبان دوم ویندوز تایپ می\u200cکنید." })),
			[HelpTopic.AutomaticCorrection] = new HelpText("اصلاح خودکار", "واژه\u200cای فارسی می\u200cشود که شواهد نشان دهد برای چیدمان فارسی تایپ شده است: یا واژه\u0654 فارسی شناخته\u200cشده\u200cای است، یا یکی از کلیدهایش در فارسی حرف است و در انگلیسی فقط نشانه\u0654 نگارشی، مثل `,` یا `;` در میان واژه. واژه\u200cهای انگلیسی، واژه\u200cهایی که در هیچ\u200cکدام از دو واژه\u200cنامه نیستند، واژه\u200cهایی که با حرف بزرگ شروع می\u200cشوند، اصطلاحات فنی، نشانی وب و ایمیل، مسیر فایل، عدد و میان\u200cبر همان\u200cطور که تایپ کرده\u200cاید می\u200cمانند.", new <>z__ReadOnlyArray<string>(new string[18]
			{
				"در بندی که انگلیسی است، فقط واژه\u200cهای فارسی شناخته\u200cشده تبدیل می\u200cشوند و واژه\u0654 یک یا دوحرفی فارسی مثل «`و`»، «`من`» یا «`در`» همان\u200cطور که تایپ شده می\u200cماند، چون همان کلیدها در انگلیسی هم تکه\u200cهای دوحرفی رایجی می\u200cسازند. نام\u200cها، سرواژه\u200cها و نشانی\u200cهایی مثل `LNG` یا `name@example.com` انگلیسی به حساب نمی\u200cآیند؛ پس در جمله\u0654 فارسی\u200cای که آن\u200cها را دارد، واژه\u200cهای کوتاه هم تبدیل می\u200cشوند.", "کلید `,` روی صفحه\u200cکلید فارسی حرف «`و`» است، هر جای واژه که باشد: «`کار,`» می\u200cشود «`کارو`». ویرگول فارسی «`،`» را مثل صفحه\u200cکلید «استاندارد فارسی» با `Shift+7` بزنید. واژه\u200cای که به یکی از حرف\u200cهای `ا آ ه و ی ء` تمام شود ویرگول را نگه می\u200cدارد، چون در فارسی «`خانه\u200cرو`» می\u200cنویسیم، نه «`خانهو`».", "پس از واژه\u0654 فارسی، کلید `?` علامت پرسش فارسی «`؟`» را می\u200cنویسد؛ وقتی کلید نگه\u200cداشتن فارسی تایپ می\u200cکند و در «تایپ مستقیم فارسی» هم همین\u200cطور است. `% ! . :` همان\u200cطور که تایپ شده\u200cاند می\u200cمانند، نشانه\u0654 نگارشی پس از نشانی، مسیر، نسخه، ساعت یا عدد هرگز تغییر نمی\u200cکند و کمانک و قلاب هرگز جابه\u200cجا نمی\u200cشوند: ویرایشگر خودش آن\u200cها را در متن راست\u200cبه\u200cچپ قرینه نشان می\u200cدهد.", "`Diyar` پیش از جایگزین کردن واژه، متن ویرایشگر را بررسی می\u200cکند. اگر کلیدی یا کلیک ماوس نشانگر را جابه\u200cجا کرده باشد، واژه همان\u200cطور که تایپ شده می\u200cماند تا به متن دیگری دست نخورد.", "«تبدیل واژه\u0654 آخر» (`Ctrl+Alt+Space`) واژه\u0654 درست پیش از نشانگر را تبدیل می\u200cکند، با یا بدون فاصله\u0654 پس از آن: متنی که با حروف لاتین تایپ شده فارسی می\u200cشود و متن فارسی به کلیدهای لاتینش برمی\u200cگردد. اگر پیش از تایپ هر چیز دیگری دوباره آن را بزنید، دقیقا\u064b متن اصلی برمی\u200cگردد. این فرمان به سرویس متن `Diyar` نیاز دارد که نصب\u200cکننده\u0654 برنامه آن را نصب می\u200cکند.", "`Backspace` پس از واژه\u0654 تبدیل\u200cشده، مثل هر ویرایشگری یک حرف را پاک می\u200cکند. برای برگرداندن واژه به کلیدهایی که زده بودید، درست پس از آن «تبدیل واژه\u0654 آخر» (`Ctrl+Alt+Space`) را بزنید؛ با زدن دوباره، واژه دوباره تبدیل می\u200cشود.", "«`Caps Lock` و کلید نگه\u200cداشتن»: «کلید برای انگلیسی»، «کلید برای فارسی» یا هر دو را انتخاب کنید. تا وقتی «کلید برای انگلیسی» را نگه داشته\u200cاید متن انگلیسی ساده و بدون اصلاح تایپ می\u200cشود، و تا وقتی «کلید برای فارسی» را نگه داشته\u200cاید هر کلید حرف فارسی خودش را می\u200cنویسد، مثل صفحه\u200cکلید فارسی. با رها کردن کلید، اصلاح دوباره کار می\u200cکند و آنچه نوشته\u200cاید تغییر نمی\u200cکند. برای یکی از آن\u200cها `Caps Lock` پیشنهاد می\u200cشود: مثل یک کلید روشن/خاموش کار می\u200cکند (تا وقتی روشن است، زبان همان کلید تایپ می\u200cشود) و هیچ کلید دیگری کارش را از دست نمی\u200cدهد. دو کلید باید فرق داشته باشند و نمی\u200cتوانند دو سمت\u0650 یک `Shift`، `Ctrl` یا `Alt` باشند؛ اگر هر دو را نگه دارید، کلیدی که اول زده\u200cاید حساب می\u200cشود. اگر `Shift`، `Ctrl` یا `Alt` را انتخاب کنید، آن کلید دیگر در هیچ برنامه\u200cای کار همیشگی\u200cاش را نمی\u200cکند.", "اگر `Caps Lock` کلید نگه\u200cداشتن نباشد، تا وقتی روشن است اصلاح متوقف می\u200cشود و ویندوز حروف بزرگ تایپ می\u200cکند.", "وقتی «حرف اول انگلیسی بعد از فارسی بزرگ شود» روشن است (به\u200cطور پیش\u200cفرض خاموش و کنار کلید نگه\u200cداشتن)، حرف اول کلمه\u0654 انگلیسی که درست بعد از یک کلمه\u0654 فارسی با کلید نگه\u200cداشتن تایپ می\u200cشود، حرف بزرگ است؛ نام\u200cهایی که با حرف کوچک نوشته می\u200cشوند (`npm`، `git`) هم بزرگ می\u200cشوند، پس `Backspace` بزنید و حرف را دوباره تایپ کنید، یا با `Shift` خودتان حالت حرف را تعیین کنید.", "وقتی «میانبرهای ویندوز از کلید نگه\u200cداشتن استفاده کنند» روشن است (پیش\u200cفرض)، کلید نگه\u200cداشتنی که همراه `Win`، `Ctrl` یا `Alt` زده شود بخشی از میانبر است و به ویندوز می\u200cرسد: وقتی `Shift` سمت چپ کلید نگه\u200cداشتن است، `Win+Shift+S` و `Ctrl+Shift+T` کار می\u200cکنند. اگر اول کلید نگه\u200cداشتن را بزنید، فقط تا وقتی چیزی با آن تایپ نشده به میانبر می\u200cرسد؛ پس `Ctrl+Z` وسط کلمه\u200cای که با نگه\u200cداشتن تایپ می\u200cکنید همچنان واگرد است.",
				"وقتی «کلمه\u0654 انگلیسی با فاصله\u200cای که با کلید نگه\u200cداشتن زده شود تمام شود» روشن است (پیش\u200cفرض)، فاصله، `Enter` یا `Tab` که وقتی هنوز کلید انگلیسی را نگه داشته\u200cاید زده شود کلمه\u0654 انگلیسی را تمام می\u200cکند؛ پس کلمه\u200cای که پس از رها کردن کلید تایپ می\u200cکنید مثل همیشه اصلاح می\u200cشود. `Backspace`، کلیدهای جهت\u200cنما یا میانبری که پس از رها کردن زده شود، کلمه\u0654 نگه\u200cداشته را تا فاصله\u0654 بعدی انگلیسی نگه می\u200cدارد.", "«شکل\u200cهای واژه\u0654 فارسی»: واژه\u0654 فارسی شناخته\u200cشده\u200cای که تا دو پسوند نیامده در واژه\u200cنامه به دنبال دارد، مثل `ها، های، تر، ترین، ی، م، ت، ش، مان، تان، شان، ام، ای، رو` و چند پسوند دیگر، در کنار متن فارسی فارسی می\u200cشود: «`درخت\u200cها`»، «`درختهاش`»، «`اطلاعاتی`». واژه\u200cای که پس از «`می`» بدون نیم\u200cفاصله تایپ شود («`میرسیم`») هم شناخته می\u200cشود. کلیدهایی که واژه\u0654 انگلیسی می\u200cسازند انگلیسی می\u200cمانند، واژه\u0654 پسونددار هم اگر کلیدهایش غلط تایپی یک واژه\u0654 انگلیسی باشد همان\u200cطور می\u200cماند، و در متن انگلیسی چیزی تغییر نمی\u200cکند. پسوندهای جدا مثل «`ها`» و «`رو`» درست پس از واژه\u0654 انگلیسی هم تبدیل می\u200cشوند: «`Button ها رو`». «فقط پسوندهای جدا» را برگزینید، یا «خاموش» را تا این واژه\u200cها دقیقا\u064b مثل گذشته بررسی شوند. این\u200cها شناخته نمی\u200cشوند: تغییر ریشه مثل «`خستگی`»، زنجیره\u0654 بلندتر پسوندها و پسوند فارسی چسبیده به واژه\u0654 لاتین.", "«اولویت واژه\u200cهای دوپهلو» درباره\u0654 واژه\u200cای تصمیم می\u200cگیرد که هم واژه\u0654 انگلیسی شناخته\u200cشده است و هم واژه\u0654 فارسی شناخته\u200cشده، مثل `fun` («`بعد`») یا `leg` («`مثل`»). با «عادی»، واژه\u0654 رایج انگلیسی به همان شکل انگلیسی می\u200cماند؛ با «فارسی» چنین واژه\u200cای فارسی می\u200cشود و با «انگلیسی» انگلیسی می\u200cماند. «بر پایه\u0654 متن» آن را فقط وقتی فارسی می\u200cکند که خوانش فارسی\u200cاش واژه\u0654 رایجی باشد و واژه\u200cهای پیش از آن فارسی باشند: دو واژه\u0654 فارسی پشت سر هم، واژه\u0654 فارسی\u200cای مثل «`به`» یا «`برای`»، یا پیامی که هنوز هیچ واژه\u0654 انگلیسی ندارد. پس از واژه\u0654 انگلیسی، در جایگاه واژه\u0654 اول، و برای رایج\u200cترین واژه\u200cهای انگلیسی مثل `and`، `how` یا `do` آن را انگلیسی نگه می\u200cدارد. «فارسی» و «انگلیسی» تکلیف حرفی را که تنها تایپ شود و کلید ویرگول را هم روشن می\u200cکنند.", "«اصلاح غلط\u200cهای املایی فارسی در صورت اطمینان» غلط\u200cهای تایپی رایج را در واژه\u200cهای تبدیل\u200cشده درست می\u200cکند.", "«شروع واژه\u0654 تازه پس از تغییر چیدمان صفحه\u200cکلید»: اگر در میانه\u0654 یک واژه چیدمان ویندوز را با `Alt+Shift`، `Win+Space` یا نوار زبان عوض کنید، حرف\u200cهایی که پیش از تغییر تایپ کرده\u200cاید همان\u200cطور می\u200cمانند و فقط آنچه پس از آن تایپ می\u200cکنید هنگام پایان واژه بررسی می\u200cشود. اگر این گزینه را خاموش کنید، کلیدهایی که با هر دو چیدمان زده\u200cاید مثل نسخه\u200cهای پیشین یک واژه به حساب می\u200cآیند.", "در «کلیدهای پایان واژه» تعیین کنید کدام کلیدها واژه را تمام کنند: فاصله، `Enter` و `Tab`. می\u200cتوانید هر سه را با هم روشن کنید؛ با زدن هر کدام که روشن باشد، واژه بررسی می\u200cشود. نشانه\u200cهایی مثل `. ! ?` همیشه واژه را تمام می\u200cکنند.", "«رقم\u200cهای فارسی در متن فارسی» (به\u200cطور پیش\u200cفرض خاموش است): وقتی روشن باشد، عددی تا شش رقم که با فاصله، `Enter` یا `Tab` تمام می\u200cکنید و واژه\u0654 پیش از آن فارسی است، به رقم\u200cهای صفحه\u200cکلید فارسی شما تبدیل می\u200cشود، مثلا\u064b `3.5` به ۳٫۵. ویرگول فقط پیش از سه رقم دقیقا\u064b جداکننده به حساب می\u200cآید (`1,000`). عددی که با صفر شروع شود، ساعت، تاریخ، نشانی، نسخه و هر چه در صفحه\u200cگسترده، ویرایشگر کد و ترمینال تایپ شود همان\u200cطور که تایپ شده می\u200cماند. `Backspace` عدد تبدیل\u200cشده را مثل واژه باز می\u200cکند و رقمی که درست پس از رقم فارسی تایپ شود فارسی است؛ صفحه\u200cکلید فارسی ویندوز رقم لاتین تایپ می\u200cکند و در آن چیزی تغییر نمی\u200cکند.", "«جاهای فقط انگلیسی» در زبانه\u0654 تایپ: `Diyar` در نوار نشانی مرورگر، کادری که یک نشانی وب در آن است، کادرهای کارت بانکی و رمز عبور و در اصلاح خودکار در ترمینال\u200cها، اجراکننده\u200cها، ابزارهای پایگاه داده، دسترسی از راه دور و برنامه\u200cهای مدیریت رمز عبور، کلیدها را همان\u200cطور که زده\u200cاید می\u200cگذارد. هر کدام را خاموش کنید تا آن\u200cجا هم مثل بقیه\u0654 جاها با حالت تایپ شما تایپ شود. کادر رمز عبور همیشه محافظت می\u200cشود. خط فرمانی که داخل `Windows Terminal` باز است، مثل `PowerShell`، از تنظیم `Windows Terminal` پیروی می\u200cکند."
			})),
			[HelpTopic.ManualTyping] = new HelpText("تایپ مستقیم فارسی", "هر کلید همان لحظه\u200cای که آن را می\u200cزنید حرف فارسی\u200cاش را می\u200cنویسد، درست مثل صفحه\u200cکلید فارسی. در این حالت `Diyar` آنچه را نوشته\u200cاید هرگز نمی\u200cخواند، جایگزین نمی\u200cکند و پاک نمی\u200cکند.", new <>z__ReadOnlyArray<string>(new string[8] { "`Shift` حرف دوم کلید را می\u200cدهد، مثل صفحه\u200cکلید فارسی: «`آ`» با `Shift+H` و «`ژ`» با `Shift+C`. در چیدمان «استاندارد فارسی»، `Shift+B` نیم\u200cفاصله است. هیچ واژه\u200cنامه\u200cای به کار نمی\u200cرود، پس حرف بزرگ واژه را انگلیسی نگه نمی\u200cدارد.", "انگلیسی: در «`Caps Lock` و کلید نگه\u200cداشتن» یک «کلید برای انگلیسی» انتخاب کنید. تا وقتی آن را نگه داشته\u200cاید، یا اگر `Caps Lock` را انتخاب کرده\u200cاید تا وقتی روشن است، کلیدها انگلیسی ساده تایپ می\u200cکنند. `Caps Lock` پیشنهاد می\u200cشود: مثل یک کلید روشن/خاموش کار می\u200cکند، پس هیچ کلید دیگری کارش را از دست نمی\u200cدهد. اگر هیچ کلیدی انتخاب نشده باشد، در این حالت فقط با عوض کردن زبان صفحه\u200cکلید ویندوز یا توقف موقت `Diyar` می\u200cتوانید انگلیسی بنویسید.", "وقتی «حرف اول انگلیسی بعد از فارسی بزرگ شود» روشن است (به\u200cطور پیش\u200cفرض خاموش و کنار کلید نگه\u200cداشتن)، حرف اول کلمه\u0654 انگلیسی که درست بعد از یک کلمه\u0654 فارسی با کلید نگه\u200cداشتن تایپ می\u200cشود، حرف بزرگ است؛ نام\u200cهایی که با حرف کوچک نوشته می\u200cشوند (`npm`، `git`) هم بزرگ می\u200cشوند، پس `Backspace` بزنید و حرف را دوباره تایپ کنید، یا با `Shift` خودتان حالت حرف را تعیین کنید.", "وقتی «میانبرهای ویندوز از کلید نگه\u200cداشتن استفاده کنند» روشن است (پیش\u200cفرض)، کلید نگه\u200cداشتنی که همراه `Win`، `Ctrl` یا `Alt` زده شود بخشی از میانبر است و به ویندوز می\u200cرسد: وقتی `Shift` سمت چپ کلید نگه\u200cداشتن است، `Win+Shift+S` و `Ctrl+Shift+T` کار می\u200cکنند. اگر اول کلید نگه\u200cداشتن را بزنید، فقط تا وقتی چیزی با آن تایپ نشده به میانبر می\u200cرسد؛ پس `Ctrl+Z` وسط کلمه\u200cای که با نگه\u200cداشتن تایپ می\u200cکنید همچنان واگرد است.", "وقتی «کلمه\u0654 انگلیسی با فاصله\u200cای که با کلید نگه\u200cداشتن زده شود تمام شود» روشن است (پیش\u200cفرض)، فاصله، `Enter` یا `Tab` که وقتی هنوز کلید انگلیسی را نگه داشته\u200cاید زده شود کلمه\u0654 انگلیسی را تمام می\u200cکند؛ پس کلمه\u200cای که پس از رها کردن کلید تایپ می\u200cکنید دوباره فارسی تایپ می\u200cشود. `Backspace`، کلیدهای جهت\u200cنما یا میانبری که پس از رها کردن زده شود، کلمه\u0654 نگه\u200cداشته را تا فاصله\u0654 بعدی انگلیسی نگه می\u200cدارد.", "`Backspace` یک حرف را پاک می\u200cکند. با `Shift`، کلیدهای نشانه همان نشانه\u200cای را تایپ می\u200cکنند که صفحه\u200cکلید فارسی ویندوز می\u200cدهد: حرکت\u200cها و تنوین، ٪، ×، ریال، ویرگول فارسی، گیومه و کروشه\u200cها. رقم\u200cها و دیگر نشانه\u200cها همان\u200cطور که تایپ شده\u200cاند می\u200cمانند.", "`Caps Lock` این حالت را متوقف نمی\u200cکند، مگر اینکه کلید نگه\u200cداشتن باشد؛ تا وقتی روشن است هم کلیدها حرف فارسی می\u200cنویسند.", "هر کلید حرفی در همه\u0654 برنامه\u200cها، جز کادرهای محافظت\u200cشده، فارسی می\u200cنویسد؛ میان\u200cبرهای تک\u200cکلیدی بازی\u200cها و ویرایشگرها هم از این قاعده بیرون نیستند. در چنین جاهایی `Diyar` را موقتا\u064b متوقف کنید." })),
			[HelpTopic.CapsLock] = new HelpText("تعویض زبان با `Caps Lock`", "در «وقتی `Caps Lock` روشن است» تعیین کنید `Caps Lock` چه کاری بکند.", new <>z__ReadOnlyArray<string>(new string[5] { "«تعویض زبان ویندوز»: با روشن کردن `Caps Lock` زبان ویندوز به زبانی که انتخاب کرده\u200cاید (انگلیسی یا فارسی) عوض می\u200cشود و با خاموش کردنش به زبان دیگر. چیزی اصلاح نمی\u200cشود. اگر انگلیسی را انتخاب کنید، در «نوع حروف انگلیسی» می\u200cتوانید «حروف عادی» یا «حروف بزرگ» را هم برگزینید.", "«تایپ مستقیم فارسی تا وقتی روشن است»: تا وقتی `Caps Lock` روشن است، هر کلید همان لحظه حرف فارسی\u200cاش را می\u200cنویسد، درست مثل «تایپ مستقیم فارسی». چیزی خوانده یا جایگزین نمی\u200cشود و `Backspace` یک حرف را پاک می\u200cکند.", "در این گزینه، اگر زبان صفحه\u200cکلید ویندوز فارسی باشد، با روشن شدن `Caps Lock` به انگلیسی عوض می\u200cشود و با خاموش شدنش زبان قبلی برمی\u200cگردد.", "«اصلاح خودکار تا وقتی روشن است» دیگر در فهرست گزینه\u200cها نیست. نمایه\u200cای که از قبل آن را دارد، همان را با پسوند (قدیمی) نگه می\u200cدارد: تا وقتی `Caps Lock` روشن است، مثل «اصلاح خودکار» کار می\u200cکند و حروف عادی تایپ می\u200cشوند.", "هر دو زبان باید از پیش در ویندوز نصب باشند؛ تعویض زبان هیچ زبانی را نصب نمی\u200cکند. زبانی را که نصب نیست، در بخش «صفحه\u200cکلید» با «نصب» اضافه کنید." })),
			[HelpTopic.ShiftSwitch] = new HelpText("تعویض زبان با `Shift`", "تا وقتی «کلید تعویض» را نگه داشته\u200cاید، با زبان دوم ویندوز تایپ می\u200cکنید و با رها کردنش به زبان اول برمی\u200cگردید. تا وقتی این حالت انتخاب شده است، چیزی اصلاح نمی\u200cشود.", new <>z__ReadOnlyArray<string>(new string[3] { "انتخاب کنید کدام `Shift` زبان را عوض کند. کلید `Shift` دیگری (همان که انتخاب نکرده\u200cاید) کار همیشگی\u200cاش را می\u200cکند؛ پس هنگام نگه\u200cداشتن کلید تعویض هم حروف بزرگ، نشانه\u200cهای انگلیسی مثل `< > ? : \"` و حروف فارسی مثل «`آ`» و «`ژ`» در دسترس\u200cاند.", "اگر زبان دوم انگلیسی باشد، نخستین حرف خودبه\u200cخود بزرگ نوشته می\u200cشود و `Caps Lock` مثل همیشه کار می\u200cکند.", "هر دو زبان باید از پیش در ویندوز نصب باشند." })),
			[HelpTopic.KeyboardLayout] = new HelpText("چیدمان صفحه\u200cکلید فارسی", "چیدمانی را انتخاب کنید که تایپ فارسی را با آن یاد گرفته\u200cاید تا هر کلید همان حرفی را بنویسد که انتظار دارید.", new <>z__ReadOnlyArray<string>(new string[5] { "«استاندارد فارسی» همان چیدمان استاندارد ملی (`ISIRI 9147`) است و «فارسی ویندوز» چیدمان قدیمی\u200cتر ویندوز.", "«تشخیص چیدمان نصب\u200cشده» از چیدمان فارسی\u200cای استفاده می\u200cکند که در ویندوز نصب است.", "اگر حرف\u200cهایی که با `Shift` نوشته می\u200cشوند، مثل «`ژ`» یا «`آ`»، اشتباه درمی\u200cآیند، چیدمان دقیق خودتان را انتخاب کنید.", "اگر بیش از یک چیدمان انگلیسی یا فارسی نصب است، در «چیدمان پیش\u200cفرض انگلیسی» و «چیدمان پیش\u200cفرض فارسی» چیدمانی را انتخاب کنید که `Diyar` به آن می\u200cرود.", "اگر زبان انگلیسی یا فارسی در ویندوز نصب نیست، در «چیدمان برای نصب» یکی را انتخاب کنید و «نصب» را بزنید. `Diyar` آن را بدون نیاز به دسترسی مدیر، برای حساب شما اضافه می\u200cکند." })),
			[HelpTopic.Correcting] = new HelpText("اصلاح و بازگردانی", "هر تبدیلی را می\u200cتوان با صفحه\u200cکلید اصلاح کرد یا برگرداند.", new <>z__ReadOnlyArray<string>(new string[6] { "در «اصلاح خودکار»، اگر درست پس از واژه\u0654 تبدیل\u200cشده «تبدیل واژه\u0654 آخر» (`Ctrl+Alt+Space`) را بزنید، واژه به کلیدهایی که زده بودید برمی\u200cگردد؛ با زدن دوباره، دوباره تبدیل می\u200cشود. `Backspace` یک حرف را پاک می\u200cکند.", "«بازگردانی آخرین ترجمه» (`Ctrl+Alt+Z`) آخرین ترجمه را برمی\u200cگرداند. این میان\u200cبر فقط وقتی ثبت می\u200cشود که ترجمه روشن باشد.", "«افزودن واژه\u0654 انتخاب\u200cشده به واژه\u200cنامه\u0654 شخصی» (`Ctrl+Alt+D`) همان یک واژه\u200cای را که انتخاب کرده\u200cاید، با زبان خودش، ذخیره می\u200cکند و به متن شما دست نمی\u200cزند. اگر چیزی انتخاب نشده باشد همین را می\u200cگوید و هرگز سراغ واژه\u0654 قبلی\u200cای نمی\u200cرود.", "«تبدیل واژه\u0654 انتخاب\u200cشده» (`Ctrl+Alt+Enter`) همان یک واژه\u0654 انتخاب\u200cشده را تبدیل می\u200cکند؛ اگر دوباره آن را روی نتیجه\u0654 دست\u200cنخورده بزنید، دقیقا\u064b متن اصلی برمی\u200cگردد. «تبدیل واژه\u0654 آخر» (`Ctrl+Alt+Space`) همین کار را با واژه\u0654 درست پیش از نشانگر می\u200cکند. «بازگردانی آخرین اصلاح دستی» (`Ctrl+Alt+U`) آخرین اصلاح از این دو را برمی\u200cگرداند و آنچه را به واژه\u200cنامه\u0654 شخصی\u200cتان افزوده بود پس می\u200cگیرد.", "این سه فرمان از راه سرویس متن `Diyar`، که نصب\u200cکننده آن را نصب می\u200cکند، درون همان برنامه\u200cای کار می\u200cکنند که در آن تایپ می\u200cکنید. در کادرهای رمز عبور و فقط\u200cخواندنی، و روی متنی که هنوز در حال ترکیب است، کاری انجام نمی\u200cشود؛ اگر متن در این فاصله جابه\u200cجا یا عوض شده باشد هم چیزی تغییر نمی\u200cکند.", "«تبدیل واژه\u200cهای خارج از واژه\u200cنامه» (`Ctrl+Alt+N`) در این نسخه در دسترس نیست و ثبت نمی\u200cشود." })),
			[HelpTopic.Dictionary] = new HelpText("واژه\u200cنامه\u200cها و یادگیری", "`Diyar` با سه چیز جدا کار می\u200cکند: «واژه\u200cنامه\u0654 پایه»، «واژه\u200cنامه\u0654 شخصی» و «صف بازبینی واژه\u200cها».", new <>z__ReadOnlyArray<string>(new string[4] { "«واژه\u200cنامه\u0654 پایه»: واژه\u200cهای فارسی و انگلیسی\u200cای که همراه برنامه می\u200cآیند. فقط\u200cخواندنی است و با به\u200cروزرسانی برنامه تازه می\u200cشود؛ هیچ کاری از شما آن را تغییر نمی\u200cدهد.", "«واژه\u200cنامه\u0654 شخصی»: واژه\u200cهایی که پذیرفته\u200cاید، هر کدام با زبان خودش، فارسی یا انگلیسی. در نمایه\u0654 شما نگه\u200cداری می\u200cشود و با به\u200cروزرسانی از بین نمی\u200cرود. هنگام تشخیص، کنار واژه\u200cنامه\u0654 پایه و با همان قاعده\u200cهای حالت و اولویت به کار می\u200cرود؛ افزودن یک واژه تضمین نمی\u200cکند که در هر ویرایشگری تبدیل شود. حذف واژه\u200cای از واژه\u200cنامه\u0654 شخصی، همان واژه را از واژه\u200cنامه\u0654 پایه حذف نمی\u200cکند.", "«صف بازبینی واژه\u200cها»: واژه\u200cهایی که پس از یک اصلاح تأییدشده پیشنهاد شده\u200cاند و منتظر تصمیم شما هستند. پیشنهاد تا وقتی آن را نپذیرید بر تشخیص اثری ندارد. با پذیرفتن، واژه به واژه\u200cنامه\u0654 شخصی افزوده می\u200cشود و با رد کردن، از صف بیرون می\u200cرود. برای دور زدن صف، «افزودن خودکار اصلاح\u200cهای تأییدشده به واژه\u200cنامه\u0654 شخصی» را روشن کنید.", "واژه\u200cهای خودتان را با «افزودن واژه\u200cها» اضافه کنید، یا متن انتخاب\u200cشده را با `Ctrl+Alt+D` بیفزایید. «وارد کردن» یک فایل `JSON`، `CSV` یا `TXT` را با واژه\u200cنامه\u0654 شخصی ادغام می\u200cکند و نشان می\u200cدهد چند واژه افزوده شد، چند واژه از پیش بود، چند واژه در واژه\u200cنامه\u0654 پایه بود و چند واژه نامعتبر بود. «صادر کردن» فقط واژه\u200cهای شخصی را همراه زبان هر واژه می\u200cنویسد." })),
			[HelpTopic.TextDirection] = new HelpText("متن ترکیبی، جهت و مبلغ", "`Diyar` فارسی و انگلیسی را به ترتیب درست نگه می\u200cدارد.", new <>z__ReadOnlyArray<string>(new string[4] { "«اصلاح خودکار» جهت بند را فقط پس از تبدیل یک واژه\u0654 فارسی راست\u200cبه\u200cچپ می\u200cکند. «تایپ مستقیم فارسی» هرگز جهت بند را عوض نمی\u200cکند.", "«پایدار نگه\u200cداشتن متن ترکیبی فارسی و انگلیسی» ترتیب واژه\u200cها و نشانه\u200cها را در ویرایشگرهایی که میان\u200cبر جهت ویندوز را نادیده می\u200cگیرند درست نگه می\u200cدارد. این گزینه بند راست\u200cبه\u200cچپ را فقط یک بار، با یک نشانه\u0654 نامرئی جهت یونیکد در آغاز آن، علامت می\u200cزند و هرگز آن را نمی\u200cبندد؛ `Enter` چیزی نمی\u200cافزاید و بند بعدی نشانه\u0654 خودش را می\u200cگیرد. در «تایپ مستقیم فارسی» و «تعویض زبان با `Shift`» این نشانه پیش از نخستین حرف فارسی می\u200cآید. برای کد برنامه\u200cنویسی یا فایل\u200cهای داده آن را خاموش کنید؛ در این صورت هیچ نشانه\u0654 جهتی افزوده نمی\u200cشود.", "در «اصلاح خودکار»، اگر بند با متن کوتاه و ساده\u0654 انگلیسی\u200cای شروع شود که همین حالا تایپ کرده\u200cاید، مثل `github`، همان آغاز پشت نشانه دوباره تایپ می\u200cشود تا سطر راست\u200cبه\u200cچپ خوانده شود، مگر اینکه ویرایشگر آن را متفاوت با کلیدهایی که زده\u200cاید نشان دهد. این آغاز هرگز دوباره تایپ نمی\u200cشود اگر ویرایشگر خودش متن را اصلاح کند، در `Word`، `Notepad` یا پنجره\u0654 خط فرمان، یا وقتی تصحیح خودکار ویندوز برای صفحه\u200cکلید سخت\u200cافزاری روشن است: در این حالت نشانه پیش از واژه\u0654 فارسی می\u200cآید و ممکن است بند چپ\u200cبه\u200cراست بماند.", "«قالب\u200cبندی مبلغ\u200cهای تومان و ریال» وقتی کار می\u200cکند که «اصلاح خودکار» واژه\u0654 «`تومان`» یا «`ریال`» را که با کلیدهای انگلیسی (`j,lhk` یا `vdhg`) تایپ شده، هنگام زدن فاصله، `Enter`، `Tab` یا یک نشانه\u0654 نگارشی تبدیل کند؛ گزینه\u200cهای `Caps Lock` که واژه\u0654 تمام\u200cشده را تبدیل می\u200cکنند هم همین\u200cطورند. در این صورت عددی که درست پیش از واحد تایپ شده و فقط با فاصله از آن جداست، با رقم فارسی و جداکننده\u0654 هزارگان نوشته می\u200cشود، مثل «`۱٬۰۰۰ تومان`». عددی که به نویسه\u0654 دیگری چسبیده باشد (تاریخ، ساعت یا `code-1000`) دست نمی\u200cخورد؛ عددی هم که پیش از آنکه در متن کلیک کنید در متن بوده همان\u200cطور می\u200cماند. واحدی که با صفحه\u200cکلید فارسی تایپ شود و واژه\u200cهایی مثل «`هزار تومان`»، «`میلیون`» یا «`ت`» هیچ\u200cوقت قالب\u200cبندی نمی\u200cشوند. در «تایپ مستقیم فارسی» و با «تبدیل واژه\u0654 آخر» هم هیچ مبلغی قالب\u200cبندی نمی\u200cشود. هر جا `Backspace` واژه\u0654 تبدیل\u200cشده را باز کند، پس از مبلغ فقط واحد را باز می\u200cکند و عدد قالب\u200cبندی\u200cشده می\u200cماند." })),
			[HelpTopic.Translation] = new HelpText("ترجمه و حریم خصوصی", "متن انتخاب\u200cشده را بدون بیرون رفتن از برنامه\u200cای که در آن کار می\u200cکنید ترجمه کنید.", new <>z__ReadOnlyArray<string>(new string[11]
			{
				"«فعال بودن میان\u200cبر ترجمه» را روشن کنید، «سرویس ترجمه» و «زبان مقصد» را برگزینید، متن را انتخاب کنید و «ترجمه\u0654 متن انتخاب\u200cشده» (`Ctrl+Alt+T`) را بزنید. متن فقط وقتی جایگزین می\u200cشود که همان متن هنوز در همان برنامه انتخاب شده باشد.", "«ترجمه روی دستگاه» پس از یک بار دریافت مدل، متن را روی همین رایانه نگه می\u200cدارد.", "`Azure Translator` با کلید `Azure` خودتان و اتصال اینترنت کار می\u200cکند و فقط متن انتخاب\u200cشده را می\u200cفرستد. کلید در `Windows Credential Manager` نگه\u200cداری می\u200cشود.", "پیام نتیجه می\u200cگوید چه شد: ترجمه فقط وقتی انجام\u200cشده اعلام می\u200cشود که `Diyar` آن را از ویرایشگر بازخوانده باشد؛ اگر ترجمه فرستاده شد ولی بازخوانی نشد، پیام می\u200cگوید تأیید نشده است، پس ویرایشگر را بررسی کنید؛ و اگر هیچ چیز تغییر نکرده باشد، پیام دلیل رد شدن را می\u200cگوید.", "تا 15 ثانیه پس از یک ترجمه\u0654 تأییدشده، «بازگردانی آخرین ترجمه» (`Ctrl+Alt+Z`) متن اصلی را برمی\u200cگرداند، به شرط آنکه «امکان بازگردانی با میان\u200cبر «بازگردانی آخرین ترجمه»» روشن باشد. فقط ترجمه\u200cای جایگزین می\u200cشود که ویرایشگر هنوز کنار نشانگر نشان می\u200cدهد.", "«استفاده از کلیپ\u200cبورد جایی که ویرایشگر خواندنی نیست»: برخی ویرایشگرها را نمی\u200cتوان مستقیم خواند. با روشن بودن این گزینه، متن انتخاب\u200cشده کپی و ترجمه جای\u200cگذاری می\u200cشود؛ این کپی به تاریخچه\u0654 کلیپ\u200cبورد و همگام\u200cسازی ابری نمی\u200cرود و متن قبلی کلیپ\u200cبورد برمی\u200cگردد. با خاموش بودن آن، چنین انتخاب\u200cهایی رد می\u200cشوند و به کلیپ\u200cبورد دست زده نمی\u200cشود.", "اگر «زبان مقصد» «خودکار (فارسی ↔ انگلیسی)» باشد، متنی که بیشترش فارسی یا عربی است به انگلیسی و هر متن دیگری به فارسی ترجمه می\u200cشود؛ پس یک میان\u200cبر برای هر دو جهت کافی است. متنی که هیچ حرفی ندارد، مثلا\u064b فقط عدد، به انگلیسی می\u200cرود. برای ترجمه\u0654 همه\u0654 متن\u200cها به یک زبان، به جای آن همان زبان را برگزینید.", "تا وقتی ترجمه در جریان است، پیامی آن را نشان می\u200cدهد. برای توقف، همان میان\u200cبر ترجمه را دوباره بزنید یا در پیام «لغو» را بزنید؛ ترجمه\u0654 لغوشده هیچ چیز را تغییر نمی\u200cدهد. ترجمه\u200cای که بیش از 120 ثانیه طول بکشد خودبه\u200cخود متوقف می\u200cشود.", "«ترجمه\u0654 متن کلیپ\u200cبورد» (`Ctrl+Alt+Shift+T`) متن روی کلیپ\u200cبورد را ترجمه می\u200cکند و ترجمه را دوباره روی کلیپ\u200cبورد می\u200cگذارد، بی\u200cآنکه به متنی که ویرایش می\u200cکنید دست بزند؛ پس در هر برنامه\u200cای و برای چند خط با هم کار می\u200cکند. ترجمه به تاریخچه\u0654 کلیپ\u200cبورد و همگام\u200cسازی ابری نمی\u200cرود؛ آن را هر جا لازم دارید جای\u200cگذاری کنید. این ترجمه بازگرداندنی نیست: اگر متن اصلی را لازم دارید، دوباره آن را کپی کنید.", "اگر `Azure Translator` پاسخ دهد که سهمیه یا محدودیت نرخ پر شده یا موقتا\u064b در دسترس نیست، `Diyar` به اندازه\u200cای که `Azure` می\u200cخواهد، تا چند ثانیه، صبر می\u200cکند و دوباره تلاش می\u200cکند؛ حداکثر سه بار، و سپس به شما خبر می\u200cدهد.",
				"«بارگذاری مدل هنگام شروع `Diyar`» (فقط برای ترجمه\u0654 روی دستگاه؛ به\u200cطور پیش\u200cفرض خاموش) مدل دریافت\u200cشده را یک بار پس از شروع برنامه یا پس از روشن کردن این گزینه در پس\u200cزمینه بارگذاری می\u200cکند تا نخستین ترجمه منتظر آن نماند؛ مدل سپس تا وقتی `Diyar` اجرا می\u200cشود در حافظه می\u200cماند. «لغو دریافت» دریافت مدل را متوقف می\u200cکند."
			})),
			[HelpTopic.Fonts] = new HelpText("قلم تایپ و قلم برنامه\u200cها", "قلم فارسی دلخواهتان را قلم پیش\u200cفرض برنامه\u200cهای پشتیبانی\u200cشده کنید.", new <>z__ReadOnlyArray<string>(new string[7] { "«قلم تایپ» را انتخاب کنید، برنامه\u200cها را برگزینید و «اعمال قلم» را بزنید. فقط برنامه\u200cهای پشتیبانی\u200cشده\u200cای در فهرست می\u200cآیند که روی این رایانه نصب\u200cاند.", "این برنامه\u200cها مستقیم تغییر می\u200cکنند: `Microsoft Word` (سندهای تازه)؛ `Edge` و `Chrome` (همراه نسخه\u200cهای `Beta`، `Dev` و `Canary`)، `Brave`، `Vivaldi`، `Opera` و `Firefox` (صفحه\u200cهای بدون قلم اختصاصی)؛ `Thunderbird` (قلم\u200cهای پیام)؛ `Visual Studio Code` (قلم ویرایشگر)؛ `Windows Terminal` (همه\u0654 نمایه\u200cها). `Notepad`، `Outlook` و `LibreOffice Writer` با وضعیت «تنظیم دستی» در فهرست می\u200cآیند: قلم را در خود آن برنامه تنظیم کنید.", "قلمی را انتخاب کنید که در ویندوز نصب است: برنامه\u0654 دیگر نمی\u200cتواند از قلمی که پیدا نمی\u200cکند استفاده کند، پس `Diyar` قلم نصب\u200cنشده را اعمال نمی\u200cکند و `Shabnam FD` نصب\u200cشده را به جایش پیشنهاد می\u200cدهد. نصب\u200cکننده\u0654 `Diyar` قلم\u200cهای `Shabnam` و `Shabnam FD` را نصب می\u200cکند.", "پیش از اعمال، همه\u0654 پنجره\u200cهای مرورگر را ببندید. پس از آن، وضعیت مرورگر می\u200cگوید قلم تنظیم شده است، نه اعمال: مرورگر این قلم را فقط در صفحه\u200cهایی به کار می\u200cبرد که قلم خودشان را تعیین نکرده\u200cاند و بیشتر وب\u200cسایت\u200cها قلم خودشان را دارند. «نمایش در مرورگر» صفحه\u200cای بدون قلم اختصاصی باز می\u200cکند تا قلمی را که مرورگر اکنون به کار می\u200cبرد ببینید. `Firefox` و `Thunderbird` باید دوباره باز شوند.", "اگر برنامه\u200cای تنظیم را برگرداند (مرورگری که تنظیمات خودش را ذخیره می\u200cکند، همگام\u200cسازی، یا تغییری که خودتان در برنامه دادید)، وضعیت آن برنامه همین را می\u200cگوید و پیامی نامش را می\u200cآورد: قلم را دوباره اعمال کنید. «به\u200cروزرسانی فهرست برنامه\u200cها» سبک `Normal` را هم از `Word` بسته می\u200cپرسد.", "«بازگرداندن تنظیم قبلی» تنظیم پیشین هر برنامه را دقیقا\u064b برمی\u200cگرداند.", "پیام\u200cرسان\u200cهایی مثل `WhatsApp` و `Telegram` تنظیم قلمی ندارند که برنامه\u0654 دیگری بتواند تغییرش دهد." })),
			[HelpTopic.Shortcuts] = new HelpText("میان\u200cبرهای صفحه\u200cکلید", "هر میان\u200cبر را می\u200cتوان در «تنظیمات › میان\u200cبرها» تغییر داد؛ اینکه هر کدام کجا کار می\u200cکند در بخش خودش آمده است.", new <>z__ReadOnlyArray<string>(new string[4] { "هر میان\u200cبر ترکیبی از `Ctrl`، `Alt` یا `Shift` با یک کلید دیگر است. کلید `Windows` به کار نمی\u200cرود تا میان\u200cبرهای خود ویندوز دست\u200cنخورده بمانند.", "میان\u200cبری که برای دو فرمان تعریف شده باشد گزارش می\u200cشود و ذخیره نمی\u200cشود؛ میان\u200cبری هم که برنامه\u0654 دیگری پیش\u200cتر در ویندوز ثبت کرده است. «تبدیل واژه\u0654 انتخاب\u200cشده»، «تبدیل واژه\u0654 آخر» و «بازگردانی آخرین اصلاح دستی» از راه سرویس متن `Diyar` کار می\u200cکنند، پس اگر برنامه\u0654 دیگری همان میان\u200cبر را برای خودش داشته باشد، این تداخل تشخیص داده نمی\u200cشود.", "ترکیبی که فقط از کلیدهای کمکی ساخته شده باشد، مثل `Alt+Shift`، در اختیار ویندوز است و زبان صفحه\u200cکلید را عوض می\u200cکند.", "«توقف یا ادامه\u0654 تایپ» (به\u200cطور پیش\u200cفرض `Ctrl+Alt+P`) در همه\u0654 برنامه\u200cها، حتی وقتی `Diyar` متوقف است، کار می\u200cکند. همان کاری را می\u200cکند که دکمه\u0654 توقف در پنجره\u0654 اصلی و گزینه\u0654 توقف تایپ در منوی ناحیه\u0654 اعلان می\u200cکنند. تا وقتی `Diyar` متوقف است به هیچ کلیدی دست نمی\u200cزند: صفحه\u200cکلید مثل خود ویندوز کار می\u200cکند و نشان ناحیه\u0654 اعلان کم\u200cرنگ می\u200cشود و راهنمای آن نشان می\u200cدهد که `Diyar` متوقف است. توقف تا ادامه می\u200cماند، حتی پس از راه\u200cاندازی دوباره." })),
			[HelpTopic.StartupAndUpdates] = new HelpText("اجرا با ویندوز و به\u200cروزرسانی", "`Diyar` بی\u200cسروصدا در ناحیه\u0654 اعلان ویندوز کار می\u200cکند.", new <>z__ReadOnlyArray<string>(new string[7] { "«اجرا هنگام شروع ویندوز» `Diyar` را هنگام ورود به ویندوز در ناحیه\u0654 اعلان باز می\u200cکند.", "با بستن پنجره، `Diyar` بسته نمی\u200cشود. برای باز کردن دوباره، توقف یا ادامه\u0654 تایپ، یا خروج، از نماد آن در ناحیه\u0654 اعلان استفاده کنید.", "«بررسی به\u200cروزرسانی هنگام شروع» حدود یک دقیقه و نیم پس از اجرای `Diyar`، و حداکثر روزی یک بار، اطلاعات انتشار `Diyar` را از راه اتصال امن می\u200cخواند. اگر شبکه هنوز آماده نباشد، ده دقیقه بعد یک بار دیگر تلاش می\u200cکند. «بررسی به\u200cروزرسانی» همان لحظه بررسی می\u200cکند. هر دو، همراه با «کانال انتشار»، در «تنظیمات › عمومی › به\u200cروزرسانی» هستند.", "وقتی نسخه\u0654 تازه\u200cتری منتشر شده باشد، یک اعلان ویندوز و یک پیام در پنجره\u0654 برنامه خبر می\u200cدهند؛ با کلیک روی اعلان، «تنظیمات › عمومی › به\u200cروزرسانی» باز می\u200cشود. تا شما کلیک نکنید، چیزی دریافت یا نصب نمی\u200cشود. همان\u200cجا «به\u200cروزرسانی» نصب\u200cکننده را دریافت می\u200cکند و آن را با اطلاعات انتشار امضاشده\u0654 ناشر می\u200cسنجد؛ فایلی که مطابقت نداشته باشد حذف می\u200cشود و هرگز اجرا نمی\u200cشود. سپس «نصب و بازکردن دوباره\u0654 `Diyar`» آن را اجرا می\u200cکند: `Diyar` بسته می\u200cشود، به\u200cروزرسانی نصب می\u200cشود و `Diyar` خودش دوباره باز می\u200cشود. ویندوز یک بار اجازه می\u200cپرسد و شاید ناشر را ناشناس بنامد، چون نصب\u200cکننده با گواهی امضای کد امضا نشده است. «دیدن صفحه\u0654 انتشار» صفحه\u0654 انتشار را باز می\u200cکند که می\u200cتوانید نصب\u200cکننده را از آن\u200cجا هم دریافت و خودتان اجرا کنید.", "وقتی `Diyar` پس از به\u200cروزرسانی دوباره باز می\u200cشود، می\u200cگوید به نسخه\u0654 تازه به\u200cروز شد، و اگر هنگام کلیک پنجره\u200cاش باز بود، آن را نشان می\u200cدهد. اگر به\u200cروزرسانی کامل نشده باشد (اجازه داده نشد، نصب لغو شد یا ناموفق بود، یا رایانه در میانه\u0654 آن دوباره راه\u200cاندازی شد)، `Diyar` همین را می\u200cگوید: «بازکردن گزارش نصب» نشان می\u200cدهد چه پیش آمد، و «تلاش دوباره» نصب\u200cکننده\u0654 دریافت\u200cشده را پس از بررسی دوباره نصب می\u200cکند. نصب\u200cکننده، گزارش آن و دریافت نیمه\u200cکاره در `%LOCALAPPDATA%\\SmartInput\\Updates` نگه داشته می\u200cشوند: نصب\u200cکننده پس از نصب شدن نسخه\u200cاش حذف می\u200cشود، و دریافت نیمه\u200cکاره و گزارش\u200cهای نصب پس از 14 روز.", "نسخه\u200cهای آزمایشی هرگز به\u200cعنوان به\u200cروزرسانی پیشنهاد نمی\u200cشوند.", "ناشر `Diyar` اطلاعات انتشار را امضا می\u200cکند. از زمانی که این نسخه از `Diyar` کلید ناشر را داشته باشد، پیش از نشان دادن هر نسخه، آن امضا و تاریخ اطلاعات را بررسی می\u200cکند: اگر بررسی ناموفق باشد، «تنظیمات › عمومی › به\u200cروزرسانی» می\u200cگوید اطلاعات به\u200cروزرسانی تأیید نشد، امضا ندارد یا قدیمی است، و چیزی پیشنهاد نمی\u200cکند. نشانی به\u200cروزرسانی\u200cای که خودتان وارد می\u200cکنید باید همان فایل ناشر را بی\u200cتغییر ارائه کند." })),
			[HelpTopic.Troubleshooting] = new HelpText("رفع اشکال", "بیشتر مشکل\u200cها راه\u200cحل ساده\u200cای دارند.", new <>z__ReadOnlyArray<string>(new string[6] { "هیچ واژه\u200cای تبدیل نمی\u200cشود: بررسی کنید پایین نوار کناری «فعال · توقف» نوشته شده باشد، زبان ویندوز `English (US)` باشد و «حالت تایپ» «اصلاح خودکار» یا «تایپ مستقیم فارسی» باشد.", "واژه\u0654 فارسی با حروف انگلیسی می\u200cماند: واژه را به واژه\u200cنامه\u0654 شخصی بیفزایید.", "واژه\u200cای انگلیسی تبدیل شد: بی\u200cدرنگ «تبدیل واژه\u0654 آخر» (`Ctrl+Alt+Space`) را بزنید تا کلیدهایی که زده بودید برگردند، و واژه را با زبان انگلیسی به واژه\u200cنامه\u0654 شخصی بیفزایید.", "کادرهای رمز عبور، نوار نشانی مرورگرها و برنامه\u200cهایی که با دسترسی مدیر اجرا می\u200cشوند محافظت\u200cشده\u200cاند یا نمی\u200cتوان متنشان را تغییر داد.", "ترتیب واژه\u200cها به هم می\u200cریزد: «پایدار نگه\u200cداشتن متن ترکیبی فارسی و انگلیسی» را روشن نگه دارید یا از فرمان راست\u200cبه\u200cچپ خود ویرایشگر استفاده کنید.", "گزارش مشکل: در «تنظیمات › عمومی › عیب\u200cیابی»، «حالت اشکال\u200cزدایی» را روشن کنید، کاری را که درست انجام نشد تکرار کنید و لاگ را از «باز کردن پوشه\u0654 لاگ» یا یک گزارش ذخیره\u200cشده را بفرستید. این لاگ واژه\u200cهایی را که تایپ می\u200cکنید همراه با تصمیم و کار برنامه ثبت می\u200cکند، و نیز نمونه\u200cهایی از متنی که ویرایشگر پیش از نشانگر نشان داده، نام برنامه، عنوان پنجره و کادری که در آن تایپ کرده\u200cاید، تنظیمات فعال، تغییرهای چیدمان صفحه\u200cکلید و رکوردهای پیرامون هر خطا (هر واژه در فایل نوشته می\u200cشود و هر 10 دقیقه خلاصه\u200cای برای هر برنامه؛ تا یک روز کامل، هشت فایل 8 مگابایتی، نگه داشته می\u200cشود). فرستادن آن این متن\u200cها را در اختیار گیرنده می\u200cگذارد، پس تا روشن است رمز عبور یا متن خصوصی تایپ نکنید. درست پس از رخ دادن مشکل و پیش از هر کار دیگری، «گزارش مشکل تایپ اخیر» را بزنید. با خاموش کردن حالت اشکال\u200cزدایی، لاگ موقت و سابقه\u0654 اخیر پاک می\u200cشوند و فقط گزارش\u200cهای ذخیره\u200cشده می\u200cمانند." })),
			[HelpTopic.InterfaceLanguage] = new HelpText("زبان برنامه", "«زبان برنامه» در «تنظیمات › عمومی» زبان پنجره، منوی ناحیه\u0654 اعلان و پیام\u200cهای `Diyar` را همان لحظه بین انگلیسی و فارسی عوض می\u200cکند؛ تایپ در هر دو زبان یکسان کار می\u200cکند. «راهنما» کلید انگلیسی/فارسی خودش را دارد.", new <>z__ReadOnlyArray<string>(new string[3] { "زبان همان لحظه و بدون اجرای دوباره\u0654 برنامه عوض می\u200cشود و برای اجرای بعدی هم می\u200cماند. تایپ، تبدیل و میان\u200cبرهای شما در هر دو زبان دقیقا\u064b همان\u200cطور کار می\u200cکنند.", "در فارسی هم نام محصول\u200cها، برنامه\u200cها و قلم\u200cها، کلیدهایی مثل `Caps Lock` و مسیرها با حروف لاتین می\u200cمانند. پنجره\u200cهای خود ویندوز، مثل پنجره\u0654 انتخاب فایل، از زبان نمایش ویندوز پیروی می\u200cکنند.", "«راهنما» به زبان برنامه باز می\u200cشود. برای خواندن نام\u200cهای انگلیسی، مثلا\u064b هنگام گزارش مشکل، «راهنما» را به انگلیسی ببرید یا بخش واژه\u200cنامه\u0654 اصطلاحات را بخوانید که نام هر تنظیم را به هر دو زبان آورده است." })),
			[HelpTopic.Glossary] = new HelpText("واژه\u200cنامه\u0654 اصطلاحات", "نام تنظیم\u200cها و فرمان\u200cها به فارسی و انگلیسی. با این فهرست می\u200cتوانید راهنما یا پاسخی را که به زبان دیگر نوشته شده است دنبال کنید.", Array.Empty<string>())
		};

		public static IReadOnlyList<HelpEntry> All
		{
			get
			{
				IReadOnlyList<HelpEntry>? readOnlyList = _all;
				if (readOnlyList == null)
				{
					List<HelpEntry> list = new List<HelpEntry>();
					list.AddRange(from topic in Enum.GetValues<HelpTopic>()
						select new HelpEntry(topic, English[topic], Persian[topic]));
					readOnlyList = (_all = new <>z__ReadOnlyList<HelpEntry>(list));
				}
				return readOnlyList;
			}
		}

		public static IReadOnlyList<UiKey> GlossaryKeys { get; } = new <>z__ReadOnlyArray<UiKey>(new UiKey[100]
		{
			UiKey.NavSettings,
			UiKey.TabGeneral,
			UiKey.TabTyping,
			UiKey.TabTranslation,
			UiKey.TabFonts,
			UiKey.TabShortcuts,
			UiKey.NavDictionary,
			UiKey.NavHelp,
			UiKey.PowerActive,
			UiKey.TypingMode,
			UiKey.ModeAutomaticCorrection,
			UiKey.ModePersianTypingDirect,
			UiKey.OtherModes,
			UiKey.ModeCapsLockSwitch,
			UiKey.ModeShiftSwitch,
			UiKey.CapsLockAndHoldKey,
			UiKey.HoldKey,
			UiKey.HoldKeyForEnglish,
			UiKey.HoldKeyForPersian,
			UiKey.TargetLanguage,
			UiKey.LanguagePersian,
			UiKey.LanguageEnglish,
			UiKey.CapitalizeEnglishAfterPersian,
			UiKey.HoldKeyYieldsToShortcuts,
			UiKey.HeldBoundaryEndsEnglishLock,
			UiKey.PriorityForAmbiguousInput,
			UiKey.PriorityNormal,
			UiKey.PriorityContextual,
			UiKey.WordForms,
			UiKey.WordFormsEnclitics,
			UiKey.Off,
			UiKey.CorrectPersianTypos,
			UiKey.StartNewWordAfterLayoutSwitch,
			UiKey.KeysThatFinishAWord,
			UiKey.PersianDigitsInPersianText,
			UiKey.EnglishOnlyPlacesTitle,
			UiKey.Keyboard,
			UiKey.PersianKeyboardLayout,
			UiKey.PersianStandardLayout,
			UiKey.WindowsPersianLayout,
			UiKey.DetectInstalledLayout,
			UiKey.DefaultEnglishLayout,
			UiKey.DefaultPersianLayout,
			UiKey.LayoutToInstall,
			UiKey.Install,
			UiKey.WhenCapsLockIsOn,
			UiKey.CapsLockSwitchLanguage,
			UiKey.CapsLockDirectWhileOn,
			UiKey.CapsLockAutomaticWhileOnLegacy,
			UiKey.EnglishLetterCase,
			UiKey.NormalLetterCase,
			UiKey.CapitalLetters,
			UiKey.SwitchKey,
			UiKey.TextDirectionAndAmounts,
			UiKey.StabilizeMixedText,
			UiKey.FormatCurrencyAmounts,
			UiKey.CommandToggleLastWord,
			UiKey.CommandConvertSelectedWord,
			UiKey.CommandUndoManualCorrection,
			UiKey.CommandAddSelectedWord,
			UiKey.CommandTranslateSelectedText,
			UiKey.CommandTranslateClipboard,
			UiKey.CommandPauseResume,
			UiKey.CommandUndoLastTranslation,
			UiKey.CommandConvertNonDictionaryWords,
			UiKey.BuiltInDictionary,
			UiKey.PersonalDictionary,
			UiKey.WordReviewQueue,
			UiKey.AutoAddConfirmedCorrections,
			UiKey.AddWords,
			UiKey.Import,
			UiKey.Export,
			UiKey.EnableTranslationShortcut,
			UiKey.TranslationService,
			UiKey.OnDeviceTranslation,
			UiKey.AllowUndoTranslation,
			UiKey.AllowClipboardFallback,
			UiKey.CancelOperation,
			UiKey.WarmUpLocalModel,
			UiKey.CancelDownload,
			UiKey.TypingFont,
			UiKey.ApplyFont,
			UiKey.RestorePrevious,
			UiKey.RefreshApplications,
			UiKey.ShowFontInBrowser,
			UiKey.Updates,
			UiKey.RunWhenWindowsStarts,
			UiKey.CheckForUpdatesAtStartup,
			UiKey.CheckForUpdates,
			UiKey.UpdateNow,
			UiKey.InstallAndRestart,
			UiKey.ViewRelease,
			UiKey.OpenSetupLog,
			UiKey.TryAgain,
			UiKey.ReleaseChannel,
			UiKey.Diagnostics,
			UiKey.DebugMode,
			UiKey.OpenLogFolder,
			UiKey.ReportTypingProblem,
			UiKey.InterfaceLanguage
		});

		public static HelpEntry Get(HelpTopic topic)
		{
			return All.First((HelpEntry entry) => entry.Topic == topic);
		}

		public static string Plain(string text)
		{
			return text.Replace('`'.ToString(), string.Empty, StringComparison.Ordinal);
		}

		public static IReadOnlyList<HelpPart> Parts(string text)
		{
			List<HelpPart> list = new List<HelpPart>();
			string[] array = text.Split('`');
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Length > 0)
				{
					list.Add(new HelpPart(array[i], i % 2 == 1));
				}
			}
			return list;
		}
	}
	internal static class Ui
	{
		internal static class Space
		{
			public const double Tight = 8.0;

			public const double Inside = 12.0;

			public const double Between = 20.0;

			public const double Below = 24.0;

			public const double Gutter = 12.0;
		}

		public const double PersianLineHeight = 24.0;

		private const string FactGap = "\u2002";

		private const double MaximumContentWidth = 1040.0;

		public static bool Persian => TextCatalog.IsPersian;

		public static Microsoft.UI.Xaml.FlowDirection Direction
		{
			get
			{
				if (!Persian)
				{
					return Microsoft.UI.Xaml.FlowDirection.LeftToRight;
				}
				return Microsoft.UI.Xaml.FlowDirection.RightToLeft;
			}
		}

		public static Microsoft.UI.Xaml.Media.FontFamily ChromeFont => (Microsoft.UI.Xaml.Media.FontFamily)Microsoft.UI.Xaml.Application.Current.Resources["CocoChromeFont"];

		public static Microsoft.UI.Xaml.Media.FontFamily PersianFont => (Microsoft.UI.Xaml.Media.FontFamily)Microsoft.UI.Xaml.Application.Current.Resources["CocoPersianFont"];

		public static Microsoft.UI.Xaml.Media.FontFamily PersianStrongFont => (Microsoft.UI.Xaml.Media.FontFamily)Microsoft.UI.Xaml.Application.Current.Resources["CocoPersianStrongFont"];

		public static T Named<T>(T control, string name) where T : Microsoft.UI.Xaml.FrameworkElement
		{
			AutomationProperties.SetName(control, name);
			return control;
		}

		public static Microsoft.UI.Xaml.Style Style(string key)
		{
			return (Microsoft.UI.Xaml.Style)Microsoft.UI.Xaml.Application.Current.Resources[key];
		}

		public static void ApplyLanguageResources(UiLanguage language)
		{
			Microsoft.UI.Xaml.ResourceDictionary resources = Microsoft.UI.Xaml.Application.Current.Resources;
			if (language == UiLanguage.Persian)
			{
				resources["ContentControlThemeFontFamily"] = PersianFont;
			}
			else if (resources.ContainsKey("ContentControlThemeFontFamily"))
			{
				resources.Remove("ContentControlThemeFontFamily");
			}
		}

		public static T Localize<T>(T element, bool strong = false) where T : Microsoft.UI.Xaml.FrameworkElement
		{
			return Localize(element, TextCatalog.Language, strong);
		}

		public static T Localize<T>(T element, UiLanguage language, bool strong = false) where T : Microsoft.UI.Xaml.FrameworkElement
		{
			if (language == UiLanguage.Persian)
			{
				element.Language = "fa-IR";
				if (!(element is TextBlock textBlock))
				{
					if (element is Microsoft.UI.Xaml.Controls.Control control)
					{
						control.FontFamily = PersianFont;
					}
				}
				else
				{
					textBlock.FontFamily = (strong ? PersianStrongFont : PersianFont);
					if (textBlock.Text.Length == 0 || textBlock.Text.Any(TextCatalog.IsPersianLetter))
					{
						textBlock.TextReadingOrder = TextReadingOrder.Default;
					}
					if (!strong)
					{
						textBlock.LineHeight = 24.0;
					}
				}
			}
			else if (Persian)
			{
				element.Language = "en-US";
				if (!(element is TextBlock textBlock2))
				{
					if (element is Microsoft.UI.Xaml.Controls.Control control2)
					{
						control2.FontFamily = ChromeFont;
					}
				}
				else
				{
					textBlock2.FontFamily = ChromeFont;
					textBlock2.ClearValue(TextBlock.TextReadingOrderProperty);
					textBlock2.ClearValue(TextBlock.LineHeightProperty);
				}
			}
			return element;
		}

		public static Microsoft.UI.Xaml.Controls.ToolTip Tip(string text)
		{
			return Localize(new Microsoft.UI.Xaml.Controls.ToolTip
			{
				Content = text,
				FlowDirection = Direction
			});
		}

		public static TextBlock Text(string value, bool secondary = false)
		{
			return Localize(new TextBlock
			{
				Text = value,
				Style = Style(secondary ? "CocoSecondary" : "CocoBody"),
				VerticalAlignment = VerticalAlignment.Center
			});
		}

		public static TextBlock Text(UiKey key, bool secondary = false)
		{
			return Text(UiText.Get(key), secondary);
		}

		public static TextBlock Value(string value, bool secondary = false)
		{
			TextBlock textBlock = new TextBlock
			{
				Text = value,
				Style = Style(secondary ? "CocoSecondary" : "CocoBody"),
				VerticalAlignment = VerticalAlignment.Center,
				FlowDirection = Microsoft.UI.Xaml.FlowDirection.LeftToRight
			};
			if (Persian)
			{
				textBlock.FontFamily = ChromeFont;
				textBlock.Language = "en-US";
				textBlock.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Left;
			}
			return textBlock;
		}

		public static TextBlock Fact(UiKey label, string value, bool secondary = false)
		{
			TextBlock textBlock = Text(string.Empty, secondary);
			textBlock.Inlines.Add(new Run
			{
				Text = UiText.Get(label) + "\u2002"
			});
			AddValue(textBlock, value, Persian);
			if (Persian && textBlock.Inlines[textBlock.Inlines.Count - 1] is Run run)
			{
				run.Language = "en-US";
			}
			return textBlock;
		}

		public static TextBlock Rich(UiKey key, bool secondary, params object?[] values)
		{
			TextBlock textBlock = Text(string.Empty, secondary);
			SetRich(textBlock, key, values);
			return textBlock;
		}

		public static void SetRich(TextBlock block, UiKey key, params object?[] values)
		{
			block.Inlines.Clear();
			foreach (TemplatePart item in TextCatalog.Parse(UiText.Get(key)))
			{
				if (!item.IsValue)
				{
					block.Inlines.Add(new Run
					{
						Text = item.Text
					});
				}
				else
				{
					AddValue(block, values[item.Value], Persian);
				}
			}
		}

		public static void AddValue(TextBlock block, object? raw, bool persian)
		{
			string text = Convert.ToString(raw, CultureInfo.InvariantCulture) ?? string.Empty;
			if (!persian)
			{
				block.Inlines.Add(new Run
				{
					Text = text
				});
			}
			else if (TextCatalog.IsIsolated(text))
			{
				block.Inlines.Add(new Run
				{
					Text = text
				});
			}
			else if (TextCatalog.IsPersianPhrase(text))
			{
				AddPersianPhrase(block, text);
			}
			else if (TextCatalog.IsProseValue(raw))
			{
				block.Inlines.Add(new Run
				{
					Text = $"{'\u2068'}{text}{'\u2069'}"
				});
			}
			else
			{
				block.Inlines.Add(new Run
				{
					Text = $"{'\u2066'}{text}{'\u2069'}",
					FontFamily = ChromeFont
				});
			}
		}

		private static void AddPersianPhrase(TextBlock block, string value)
		{
			List<Run> list = new List<Run>();
			int num = 0;
			while (num < value.Length)
			{
				bool flag = char.IsAsciiLetter(value[num]);
				int i;
				for (i = num + 1; i < value.Length && (flag ? IsLatin(value[i]) : (!char.IsAsciiLetter(value[i]))); i++)
				{
				}
				Run run;
				if (!flag)
				{
					run = new Run();
					Run run2 = run;
					int num2 = num;
					run2.Text = value.Substring(num2, i - num2);
				}
				else
				{
					run = new Run();
					Run run3 = run;
					int num2 = num;
					run3.Text = value.Substring(num2, i - num2);
					run.FontFamily = ChromeFont;
				}
				list.Add(run);
				num = i;
			}
			list[0].Text = "\u2067" + list[0].Text;
			list[list.Count - 1].Text += "\u2069";
			foreach (Run item in list)
			{
				block.Inlines.Add(item);
			}
			static bool IsLatin(char c)
			{
				if (!char.IsAsciiLetterOrDigit(c))
				{
					return c == '+';
				}
				return true;
			}
		}

		public static StackPanel Stack(params Microsoft.UI.Xaml.UIElement[] children)
		{
			StackPanel stackPanel = new StackPanel
			{
				Spacing = 20.0
			};
			foreach (Microsoft.UI.Xaml.UIElement item in children)
			{
				stackPanel.Children.Add(item);
			}
			return stackPanel;
		}

		public static StackPanel Actions(params Microsoft.UI.Xaml.UIElement[] children)
		{
			StackPanel stackPanel = Stack(children);
			stackPanel.Orientation = Microsoft.UI.Xaml.Controls.Orientation.Horizontal;
			stackPanel.Spacing = 8.0;
			return stackPanel;
		}

		public static Microsoft.UI.Xaml.Controls.Button Button(string label, Func<Task> action, bool primary = false, Symbol? icon = null, bool mirrorIcon = false)
		{
			Microsoft.UI.Xaml.Controls.Button button = Localize(Named(new Microsoft.UI.Xaml.Controls.Button
			{
				Style = Style(primary ? "CocoAccentButton" : "CocoButton")
			}, label));
			button.Content = ((!icon.HasValue) ? ((IEquatable<string?>)label) : ((IEquatable<string?>)Actions(new FontIcon
			{
				Glyph = char.ConvertFromUtf32((int)icon.Value),
				FontSize = 16.0,
				MirroredWhenRightToLeft = mirrorIcon
			}, Text(label))));
			button.Click += async (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
			{
				button.IsEnabled = false;
				try
				{
					await action();
				}
				catch (System.Exception ex)
				{
					MainWindow.Current?.Notice(ex.Message, InfoBarSeverity.Error);
				}
				finally
				{
					button.IsEnabled = true;
				}
			};
			return button;
		}

		public static Microsoft.UI.Xaml.Controls.Button Icon(string name, Symbol icon, Func<Task> action, double size = 40.0, bool mirror = false)
		{
			Microsoft.UI.Xaml.Controls.Button button = Button(name, action);
			button.Content = new FontIcon
			{
				Glyph = char.ConvertFromUtf32((int)icon),
				FontSize = ((size <= 32.0) ? 14 : 20),
				MirroredWhenRightToLeft = mirror
			};
			button.Width = size;
			button.Height = size;
			button.MinWidth = size;
			button.MinHeight = size;
			button.Padding = new Microsoft.UI.Xaml.Thickness(0.0);
			button.CornerRadius = new Microsoft.UI.Xaml.CornerRadius(size / 2.0);
			ToolTipService.SetToolTip(button, Tip(name));
			return button;
		}

		public static Microsoft.UI.Xaml.Controls.TextBox Input(string label, string value = "", bool latin = false)
		{
			Microsoft.UI.Xaml.Controls.TextBox textBox = Localize(Named(new Microsoft.UI.Xaml.Controls.TextBox
			{
				Header = label,
				Text = value,
				Style = Style("CocoInput")
			}, label));
			if (latin && Persian)
			{
				textBox.TextAlignment = TextAlignment.Left;
				textBox.Header = LatinValueBox(textBox, label);
			}
			return textBox;
		}

		public static PasswordBox Secret(string label, string name)
		{
			PasswordBox passwordBox = Localize(Named(new PasswordBox
			{
				Header = label,
				MinHeight = 40.0,
				PasswordRevealMode = PasswordRevealMode.Hidden
			}, name));
			if (Persian)
			{
				passwordBox.Header = LatinValueBox(passwordBox, label);
			}
			return passwordBox;
		}

		private static TextBlock LatinValueBox(Microsoft.UI.Xaml.Controls.Control box, string label)
		{
			box.FontFamily = ChromeFont;
			box.FlowDirection = Microsoft.UI.Xaml.FlowDirection.LeftToRight;
			TextBlock textBlock = Text(label);
			textBlock.FlowDirection = Microsoft.UI.Xaml.FlowDirection.RightToLeft;
			return textBlock;
		}

		public static Microsoft.UI.Xaml.Controls.ComboBox Choice(string label, IEnumerable<string> values, int selected, Action<int> changed)
		{
			return ChoiceOf(label, values, selected, changed);
		}

		public static Microsoft.UI.Xaml.Controls.ComboBox Choice(string label, IEnumerable<ComboBoxItem> items, int selected, Action<int> changed)
		{
			return ChoiceOf(label, items, selected, changed);
		}

		public static ComboBoxItem LanguageItem(string name, UiLanguage language)
		{
			ComboBoxItem comboBoxItem = new ComboBoxItem
			{
				Content = name,
				FlowDirection = Direction
			};
			if (language == UiLanguage.Persian || Persian)
			{
				Localize(comboBoxItem, language);
			}
			AutomationProperties.SetName(comboBoxItem, name);
			return comboBoxItem;
		}

		private static Microsoft.UI.Xaml.Controls.ComboBox ChoiceOf<T>(string label, IEnumerable<T> values, int selected, Action<int> changed) where T : notnull
		{
			Microsoft.UI.Xaml.Controls.ComboBox box = Localize(Named(new Microsoft.UI.Xaml.Controls.ComboBox
			{
				Header = ((label.Length == 0) ? null : label),
				Style = Style("CocoCombo"),
				VerticalAlignment = VerticalAlignment.Top
			}, label));
			foreach (T value in values)
			{
				box.Items.Add(value);
			}
			box.SelectedIndex = selected;
			bool restoring = false;
			box.SelectionChanged += (object _, SelectionChangedEventArgs _) =>
			{
				if (restoring || box.SelectedIndex < 0)
				{
					return;
				}
				try
				{
					changed(box.SelectedIndex);
					selected = box.SelectedIndex;
				}
				catch (System.Exception ex)
				{
					restoring = true;
					try
					{
						box.SelectedIndex = selected;
					}
					finally
					{
						restoring = false;
					}
					MainWindow.Current?.Notice(ex.Message, InfoBarSeverity.Error);
				}
			};
			return box;
		}

		public static ToggleSwitch Toggle(string label, bool value, Action<bool> changed, string? tooltip = null, bool latin = false)
		{
			ToggleSwitch toggle = Localize(Named(new ToggleSwitch
			{
				Header = (latin ? ((IEquatable<string?>)(object)Value(label)) : ((IEquatable<string?>)label)),
				IsOn = value,
				OnContent = UiText.Get(UiKey.On),
				OffContent = UiText.Get(UiKey.Off)
			}, label));
			if (tooltip != null)
			{
				ToolTipService.SetToolTip(toggle, Tip(tooltip));
			}
			bool restoring = false;
			toggle.Toggled += (object _, Microsoft.UI.Xaml.RoutedEventArgs _) =>
			{
				if (restoring)
				{
					return;
				}
				try
				{
					changed(toggle.IsOn);
					value = toggle.IsOn;
				}
				catch (System.Exception ex)
				{
					restoring = true;
					try
					{
						toggle.IsOn = value;
					}
					finally
					{
						restoring = false;
					}
					MainWindow.Current?.Notice(ex.Message, InfoBarSeverity.Error);
				}
			};
			return toggle;
		}

		public static Grid Pair(Microsoft.UI.Xaml.FrameworkElement left, Microsoft.UI.Xaml.FrameworkElement right)
		{
			Grid grid = new Grid
			{
				ColumnSpacing = 24.0
			};
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = Microsoft.UI.Xaml.GridLength.Auto
			});
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = Microsoft.UI.Xaml.GridLength.Auto
			});
			grid.Children.Add(left);
			grid.Children.Add(right);
			Grid.SetColumn(right, 1);
			grid.SizeChanged += (object _, Microsoft.UI.Xaml.SizeChangedEventArgs e) =>
			{
				bool flag = e.NewSize.Width < 660.0;
				grid.RowSpacing = (flag ? 12.0 : 0.0);
				Grid.SetColumn(right, (!flag) ? 1 : 0);
				Grid.SetRow(right, flag ? 1 : 0);
				Grid.SetColumnSpan(left, (!flag) ? 1 : 2);
				Grid.SetColumnSpan(right, (!flag) ? 1 : 2);
			};
			return grid;
		}

		public static Border Section(string title, params Microsoft.UI.Xaml.UIElement[] content)
		{
			return Card(title, content);
		}

		public static Border Section(string title, Microsoft.UI.Xaml.FrameworkElement headerAction, Microsoft.UI.Xaml.UIElement[] content)
		{
			return Card(title, headerAction, content);
		}

		public static Border Card(string title, Microsoft.UI.Xaml.FrameworkElement headerAction, Microsoft.UI.Xaml.UIElement[] content)
		{
			Border border = Card(null, content);
			((StackPanel)border.Child).Children.Insert(0, Header(title, headerAction, new Microsoft.UI.Xaml.Thickness(0.0)));
			return border;
		}

		public static StackPanel Group(string title, Microsoft.UI.Xaml.FrameworkElement? headerAction, params Microsoft.UI.Xaml.UIElement[] content)
		{
			StackPanel stackPanel = new StackPanel
			{
				Spacing = 12.0,
				Margin = new Microsoft.UI.Xaml.Thickness(0.0, 20.0, 0.0, 0.0)
			};
			TextBlock textBlock = Localize(new TextBlock
			{
				Text = title,
				Style = Style("BodyStrongTextBlockStyle"),
				VerticalAlignment = VerticalAlignment.Center,
				TextWrapping = TextWrapping.Wrap
			}, strong: true);
			AutomationProperties.SetHeadingLevel(textBlock, AutomationHeadingLevel.Level3);
			if ((object)headerAction == null)
			{
				stackPanel.Children.Add(textBlock);
			}
			else
			{
				Grid grid = new Grid
				{
					ColumnSpacing = 8.0
				};
				grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = Microsoft.UI.Xaml.GridLength.Auto
				});
				grid.ColumnDefinitions.Add(new ColumnDefinition
				{
					Width = Microsoft.UI.Xaml.GridLength.Auto
				});
				grid.ColumnDefinitions.Add(new ColumnDefinition());
				headerAction.VerticalAlignment = VerticalAlignment.Center;
				grid.Children.Add(textBlock);
				grid.Children.Add(headerAction);
				Grid.SetColumn(headerAction, 1);
				stackPanel.Children.Add(grid);
			}
			foreach (Microsoft.UI.Xaml.UIElement item in content)
			{
				stackPanel.Children.Add(item);
			}
			return stackPanel;
		}

		private static Grid Header(string title, Microsoft.UI.Xaml.FrameworkElement action, Microsoft.UI.Xaml.Thickness margin)
		{
			TextBlock textBlock = Localize(new TextBlock
			{
				Text = title,
				Style = Style("SubtitleTextBlockStyle"),
				VerticalAlignment = VerticalAlignment.Center,
				TextWrapping = TextWrapping.Wrap
			}, strong: true);
			AutomationProperties.SetHeadingLevel(textBlock, AutomationHeadingLevel.Level2);
			Grid grid = new Grid
			{
				Margin = margin,
				ColumnSpacing = 8.0,
				ColumnDefinitions = 
				{
					new ColumnDefinition
					{
						Width = Microsoft.UI.Xaml.GridLength.Auto
					},
					new ColumnDefinition
					{
						Width = Microsoft.UI.Xaml.GridLength.Auto
					},
					new ColumnDefinition()
				}
			};
			action.VerticalAlignment = VerticalAlignment.Center;
			grid.Children.Add(textBlock);
			grid.Children.Add(action);
			Grid.SetColumn(action, 1);
			return grid;
		}

		public static Border Card(string? title, params Microsoft.UI.Xaml.UIElement[] content)
		{
			StackPanel stackPanel = Stack();
			if (!string.IsNullOrEmpty(title))
			{
				TextBlock textBlock = Localize(new TextBlock
				{
					Text = title,
					Style = Style("SubtitleTextBlockStyle")
				}, strong: true);
				AutomationProperties.SetHeadingLevel(textBlock, AutomationHeadingLevel.Level2);
				stackPanel.Children.Add(textBlock);
			}
			foreach (Microsoft.UI.Xaml.UIElement item in content)
			{
				stackPanel.Children.Add(item);
			}
			return new Border
			{
				Background = (Microsoft.UI.Xaml.Media.Brush)Microsoft.UI.Xaml.Application.Current.Resources["CardBackgroundFillColorDefaultBrush"],
				BorderBrush = (Microsoft.UI.Xaml.Media.Brush)Microsoft.UI.Xaml.Application.Current.Resources["CardStrokeColorDefaultBrush"],
				BorderThickness = new Microsoft.UI.Xaml.Thickness(1.0),
				CornerRadius = new Microsoft.UI.Xaml.CornerRadius(8.0),
				Padding = new Microsoft.UI.Xaml.Thickness(20.0),
				Margin = new Microsoft.UI.Xaml.Thickness(0.0, 0.0, 0.0, 24.0),
				Child = stackPanel
			};
		}

		public static Expander Expander(string title, bool expanded, params Microsoft.UI.Xaml.UIElement[] content)
		{
			StackPanel stackPanel = new StackPanel
			{
				Spacing = 12.0
			};
			foreach (Microsoft.UI.Xaml.UIElement item in content)
			{
				stackPanel.Children.Add(item);
			}
			return Localize(Named(new Expander
			{
				Header = title,
				Content = stackPanel,
				IsExpanded = expanded,
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch,
				HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch
			}, title));
		}

		public static InfoBar Warning(string message, string name)
		{
			return Localize(Named(new InfoBar
			{
				Severity = InfoBarSeverity.Warning,
				Message = message,
				IsOpen = true,
				IsClosable = false
			}, name));
		}

		public static Microsoft.UI.Xaml.Controls.ProgressBar Progress(string name, double? percent = null)
		{
			return Localize(Named(new Microsoft.UI.Xaml.Controls.ProgressBar
			{
				Minimum = 0.0,
				Maximum = 100.0,
				Value = Math.Clamp(percent.GetValueOrDefault(), 0.0, 100.0),
				IsIndeterminate = !percent.HasValue,
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch
			}, name));
		}

		public static Rectangle Divider()
		{
			return new Rectangle
			{
				Height = 1.0,
				Fill = (Microsoft.UI.Xaml.Media.Brush)Microsoft.UI.Xaml.Application.Current.Resources["CardStrokeColorDefaultBrush"],
				Margin = new Microsoft.UI.Xaml.Thickness(0.0, 4.0, 0.0, 20.0),
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Stretch
			};
		}

		public static ScrollViewer Page(params Microsoft.UI.Xaml.UIElement[] content)
		{
			Border body = new Border
			{
				Child = Stack(content),
				HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Left,
				Padding = new Microsoft.UI.Xaml.Thickness(0.0, 0.0, 20.0, 24.0)
			};
			ScrollViewer scrollViewer = new ScrollViewer();
			scrollViewer.Content = body;
			scrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
			scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
			scrollViewer.HorizontalContentAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Left;
			scrollViewer.SizeChanged += (object _, Microsoft.UI.Xaml.SizeChangedEventArgs e) =>
			{
				body.Width = Math.Max(0.0, Math.Min(1040.0, e.NewSize.Width));
			};
			return scrollViewer;
		}

		public static HyperlinkButton Link(string label, string url, bool value = false)
		{
			HyperlinkButton hyperlinkButton = Named(new HyperlinkButton
			{
				Content = label,
				NavigateUri = new System.Uri(url),
				Padding = new Microsoft.UI.Xaml.Thickness(0.0, 8.0, 0.0, 8.0)
			}, label);
			if (!value)
			{
				return Localize(hyperlinkButton);
			}
			if (Persian)
			{
				hyperlinkButton.FlowDirection = Microsoft.UI.Xaml.FlowDirection.LeftToRight;
				hyperlinkButton.FontFamily = ChromeFont;
				hyperlinkButton.HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Left;
			}
			return hyperlinkButton;
		}
	}
}
namespace SmartInput.WinUI.Text
{
	internal enum UiKey
	{
		NavSettings,
		NavDictionary,
		NavHelp,
		NavAbout,
		PowerActive,
		PowerPaused,
		PauseTypingAssistant,
		ResumeTypingAssistant,
		PowerActiveTip,
		PowerPausedTip,
		Cancel,
		Close,
		Save,
		On,
		Off,
		CancelOperation,
		SettingsCategories,
		TabGeneral,
		TabTyping,
		TabTranslation,
		TabFonts,
		TabShortcuts,
		TypingAssistant,
		EnableCocoTyping,
		Startup,
		RunWhenWindowsStarts,
		StartupIsolatedInVerification,
		StartupSavedInVerification,
		Updates,
		CheckForUpdatesAtStartup,
		ReleaseChannel,
		StableReleases,
		StableAndPreviewReleases,
		UpdateSource,
		EditUpdateUrl,
		UpdateManifestUrl,
		UpdateSourceSaved,
		CheckForUpdates,
		InstalledVersion,
		UpdatesDisabledInVerification,
		CheckingForUpdates,
		UpdateAvailable,
		ViewReleaseAndInstallers,
		UpdateNoticeText,
		ViewRelease,
		PendingUpdateText,
		Diagnostics,
		DebugMode,
		DebugModeExplanation,
		DebugStatusOn,
		DebugStatusOnForThisRun,
		DebugStatusOff,
		ReportTypingProblem,
		ExpectedTextPrompt,
		TurnDebugOnFirst,
		SaveReport,
		NothingSavedDebugOff,
		ReportSaved,
		ReportSavedWithoutExpected,
		OpenLogFolder,
		ClearLog,
		LogCleared,
		CrashFolderNote,
		OpenCrashFolder,
		LastSessionEndedNormally,
		LastSessionCrashed,
		LastSessionEndedWithoutRecord,
		HandledFaultsThisSession,
		ClosedUnexpectedly,
		ClosedWithoutRecord,
		WindowErrorTypingContinues,
		HelpLanguage,
		HelpButtonName,
		OpenFullHelp,
		HelpIntro,
		HelpContents,
		HelpYourShortcuts,
		HelpShortcutsNote,
		HelpSupport,
		HelpSupportText,
		CommandToggleLastWord,
		CommandUndoLastTranslation,
		CommandConvertSelectedWord,
		CommandAddSelectedWord,
		CommandTranslateSelectedText,
		CommandConvertNonDictionaryWords,
		CommandUndoManualCorrection,
		CommandTranslateClipboard,
		CommandPauseResume,
		TranslatingPressAgainToCancel,
		AboutTagline,
		AboutDedication,
		AboutSupportTitle,
		AboutSupportText,
		AboutSupportLink,
		AboutVersion,
		AboutReleaseDate,
		AboutPreview,
		AboutCopyright,
		License,
		LicenseSummary,
		ReadLicense,
		ThirdPartyNotices,
		DocumentMissing,
		TypingMode,
		ModeAutomaticCorrection,
		ModeAutomaticCorrectionDescription,
		ModePersianTypingDirect,
		ModePersianTypingDirectDescription,
		ModeCapsLockSwitch,
		ModeCapsLockSwitchDescription,
		ModeShiftSwitch,
		ModeShiftSwitchDescription,
		AnotherModeSelected,
		OtherMode,
		NotInUse,
		OnlyOneModeActive,
		OtherModes,
		OtherModesExplanation,
		Keyboard,
		PersianKeyboardLayout,
		DetectInstalledLayout,
		PersianStandardLayout,
		WindowsPersianLayout,
		KeysTypeAsPersianStandard,
		KeysTypeAsWindowsPersian,
		KeysTypeAsEitherLayout,
		LayoutsInUse,
		NotInstalled,
		DefaultEnglishLayout,
		DefaultPersianLayout,
		Automatic,
		EnglishNotInstalled,
		PersianNotInstalled,
		LayoutToInstall,
		Install,
		LanguageEnglish,
		LanguagePersian,
		KeyLeftShift,
		KeyRightShift,
		KeyLeftCtrl,
		KeyRightCtrl,
		KeyLeftAlt,
		KeyRightAlt,
		HoldKey,
		HoldKeyForEnglish,
		HoldKeyForPersian,
		HoldKeysConflict,
		TargetLanguage,
		CapsLockAndHoldKey,
		AutomaticCapsLockRule,
		DirectCapsLockRule,
		CapitalizeEnglishAfterPersian,
		HoldKeyYieldsToShortcuts,
		HoldKeyYieldsToShortcutsTip,
		HeldBoundaryEndsEnglishLock,
		HeldBoundaryEndsEnglishLockTip,
		CapitalizeEnglishTip,
		HoldKeyWarning,
		UseItForEnglish,
		UseItForEnglishTip,
		NoHoldKeyWarning,
		HoldKeyTypesPersianWarning,
		HoldKeyForTypingEnglish,
		HoldNoteOff,
		HoldNoteCapsLockPersian,
		HoldNoteKeyPersian,
		HoldNoteCapsLockEnglish,
		HoldNoteKeyEnglish,
		DirectHoldNoteNone,
		DirectHoldNoteCapsLock,
		DirectHoldNoteKey,
		ModifierKeyNote,
		PriorityForAmbiguousInput,
		PriorityNormal,
		PriorityNormalDescription,
		PriorityPersianDescription,
		PriorityEnglishDescription,
		PriorityContextual,
		PriorityContextualDescription,
		PriorityScope,
		WordForms,
		WordFormsChoice,
		WordFormsTip,
		WordFormsFull,
		WordFormsFullDescription,
		WordFormsEnclitics,
		WordFormsEncliticsDescription,
		WordFormsOffDescription,
		KeyboardLayoutGroup,
		StartNewWordAfterLayoutSwitch,
		StartNewWordAfterLayoutSwitchTip,
		LayoutSwitchNote,
		CorrectionBehavior,
		DirectTypingCardText,
		AutomaticCorrectionCardText,
		Spelling,
		CorrectPersianTypos,
		KeysThatFinishAWord,
		KeysThatFinishAWordNote,
		SpaceKey,
		AtLeastOneFinishingKey,
		WhenCapsLockIsOn,
		CapsLockSwitchLanguage,
		CapsLockDirectWhileOn,
		CapsLockManualWhileOn,
		CapsLockAutomaticWhileOnLegacy,
		CapsLockAutomaticDescription,
		CapsLockDirectDescription,
		CapsLockManualDescription,
		CapsLockSwitchDescription,
		WindowsLanguageWhileCapsLockOn,
		EnglishLetterCase,
		NormalLetterCase,
		CapitalLetters,
		LanguageGroup,
		CapsLockSwitchNoDirection,
		SwitchKey,
		SwitchKeyLeftShift,
		SwitchKeyRightShift,
		ShiftSwitchTarget,
		ShiftSwitchExplanation,
		ShiftSwitchShiftedCharacters,
		TextDirection,
		TextDirectionAndAmounts,
		StabilizeMixedText,
		FormatCurrencyAmounts,
		NoAmountsNote,
		DirectTypingAmountNote,
		Numbers,
		PersianDigitsInPersianText,
		PersianDigitsTip,
		PersianDigitsNote,
		TranslationService,
		OnDeviceModel,
		EnableTranslationShortcut,
		TranslatedText,
		MatchParagraphDirection,
		AllowUndoTranslation,
		TranslationTargetTip,
		TranslationShortcutsNote,
		AllowClipboardFallback,
		AllowClipboardFallbackTip,
		CancelDownload,
		CancelDownloadTip,
		WarmUpLocalModel,
		WarmUpLocalModelTip,
		WarmUpLocalModelNote,
		ModelDownloadCancelled,
		ApiKey,
		AzureApiKey,
		ResourceRegion,
		KeyStoredSecurely,
		NoApiKeySaved,
		SaveConnection,
		KeyCouldNotBeStored,
		EnterAzureKeyFirst,
		ConnectionSaved,
		TestConnection,
		SaveBeforeTesting,
		TestingConnection,
		RemoveSavedKey,
		RemoveSavedKeyQuestion,
		RemoveSavedKeyBody,
		Remove,
		SavedKeyRemoved,
		AzureConnection,
		SetupHelp,
		AzureSendsOnlySelected,
		AzureSetupTitle,
		AzureSetupStep1,
		AzureSetupStep2,
		AzureSetupStep3,
		AzureSetupStep4,
		AzureSetupCosts,
		TranslatorSetupDocs,
		OpenAzurePortal,
		OnDeviceTranslation,
		FirstDownloadNeedsInternet,
		CheckModel,
		DownloadModel,
		TypingFont,
		NoSupportedAppDetected,
		FontAppsSummary,
		SelectAtLeastOneApp,
		RestorePreviousFontsQuestion,
		ApplyFontQuestion,
		Restore,
		Apply,
		NoApplicationChanged,
		SomeApplicationsChanged,
		ApplicationDefaults,
		RefreshApplications,
		SelectSupported,
		ApplyFont,
		RestorePrevious,
		KeyboardShortcuts,
		ChangeShortcutName,
		ShortcutsHandledInApps,
		ConvertSelectedWordExplanation,
		TextServiceNotInstalled,
		TextServiceWorks,
		SaveSelectedWordCorrections,
		WhenOffNoWordAdded,
		EnableToggleLastWord,
		SaveLastWordCorrections,
		ToggleLastWordExplanation,
		NonDictionaryWordsUnavailable,
		NewShortcut,
		PressKeyCombination,
		SaveShortcut,
		RecorderInstructions,
		CurrentShortcut,
		NoWindowsKey,
		ShortcutInUse,
		ShortcutSaved,
		DictionaryViews,
		PersonalDictionary,
		BuiltInDictionary,
		WordReviewQueue,
		SearchWordReviewQueue,
		SearchBuiltInDictionary,
		SearchPersonalDictionary,
		SearchDictionary,
		AllLanguages,
		FilterDictionaryLanguage,
		AutoAddConfirmedCorrections,
		PersonalDictionaryWords,
		BuiltInDictionaryWords,
		ColumnProposedWord,
		ColumnTypedAs,
		ColumnAwaitingReview,
		ColumnDictionary,
		ColumnStatus,
		ColumnStatusConversion,
		Word,
		WordLanguage,
		NoWordsAwaitingReview,
		NoMatchingWords,
		PreviousPage,
		NextPage,
		AddWords,
		Import,
		Export,
		NoPersonalWordsToExport,
		PersonalDictionaryFileType,
		ExportedPersonalWords,
		AcceptSelected,
		AcceptAll,
		AcceptAllQuestion,
		AcceptAllBody,
		RetryKeepingCopy,
		CopyKept,
		SelectPage,
		ClearSelection,
		DictionaryHelp,
		Edit,
		EditPersonalWord,
		NeutralOlderEntry,
		Category,
		CategoryGeneral,
		CategoryTechnical,
		CategoryName,
		CategoryAcronym,
		CategoryCommand,
		CategoryCurrency,
		ProtectFromAutomaticConversion,
		EntryEnabled,
		WordSaved,
		WordNotSaved,
		Reject,
		Delete,
		RejectProposedWordsQuestion,
		DeletePersonalWordsQuestion,
		RejectProposedWordsBody,
		DeletePersonalWordsBody,
		RejectAll,
		DeleteAll,
		DeleteAllPersonalWords,
		RejectAllQuestion,
		DeleteAllPersonalWordsQuestion,
		RejectAllBody,
		DeleteAllBody,
		WordCount,
		SelectedOnPage,
		SourceBuiltIn,
		SourcePersonal,
		LanguageNeutral,
		StatusReadOnly,
		StatusAddedAutomatically,
		StatusAccepted,
		StatusDisabled,
		StatusProtected,
		StatusAllowed,
		ReviewUses,
		UnsavedProposals,
		NothingWasOverwritten,
		Words,
		DetectFromLetters,
		AddToPersonalDictionary,
		ImportSummary,
		LanguageCardTitle,
		InterfaceLanguage,
		InterfaceLanguageTip,
		InterfaceLanguageNote,
		AlreadyRunning,
		CouldNotStart,
		EnglishOnlyPlacesTitle,
		EnglishOnlyPlacesIntro,
		EnglishOnlyFields,
		PlaceBrowserAddressBar,
		PlaceBrowserAddressBarTip,
		PlaceWebAddressField,
		PlaceWebAddressFieldTip,
		PlacePaymentCardField,
		PlacePaymentCardFieldTip,
		PlacePasswordField,
		PlacePasswordFieldTip,
		EnglishOnlyFieldsNote,
		EnglishOnlyApplications,
		EnglishOnlyApplicationsNote,
		EnglishOnlyTerminals,
		EnglishOnlyLaunchers,
		EnglishOnlyDatabaseTools,
		EnglishOnlyRemoteDesktops,
		EnglishOnlyPasswordManagers,
		FontBrowsersNote,
		FontNotInstalledNote,
		FontsRevertedNotice,
		ShowFontInBrowser,
		FontCheckNotOpened,
		UpdateNow,
		DownloadAndInstall,
		UpdateAvailableCardText,
		UpdateDownloadingText,
		UpdateDownloadProgressName,
		UpdateVerifyingText,
		UpdateReadyText,
		InstallAndRestart,
		UpdateInstallingText,
		UpdatePermissionRefusedText,
		UpdateCancelledText,
		UpdateRestartWindowsText,
		UpdateRestartDiyarText,
		RestartDiyar,
		UpdateDownloadFailedText,
		UpdateFileRejectedText,
		UpdateNotEnoughSpaceText,
		UpdateBlockedBySecurityText,
		UpdateNewerInstalledText,
		UpdateFailedText,
		UpdateLaunchFailedText,
		TryAgain,
		OpenSetupLog,
		OpenUpdateFolder,
		UpdatedToText,
		UpdateDidNotFinishText
	}
	internal static class UiText
	{
		public const string ProductName = "Diyar";

		public const string CompanyName = "Webpack";

		public const string EnglishName = "English";

		public const string PersianName = "فارسی";

		public const string KeyCapsLock = "Caps Lock";

		public const string KeyEnter = "Enter";

		public const string KeyTab = "Tab";

		public const string KeyBackspace = "Backspace";

		public const string AzureTranslatorName = "Microsoft Azure Translator";

		public const string AzureKeysAndEndpoint = "Keys and Endpoint";

		public const string AzureKey1 = "Key 1";

		public const string AzureKey2 = "Key 2";

		public const string AzureLocation = "Location";

		public const string AzureRegionExample = "australiaeast";

		public const string AzureGlobalRegion = "global";

		public const string FontPreviewSample = "سلام، به کوکو تایپینگ خوش آمدید. ۱۲۳۴۵۶۷۸۹۰";

		private static readonly Dictionary<UiKey, string> English = new Dictionary<UiKey, string>
		{
			[UiKey.NavSettings] = "Settings",
			[UiKey.NavDictionary] = "Dictionary",
			[UiKey.NavHelp] = "Help",
			[UiKey.NavAbout] = "About",
			[UiKey.PowerActive] = "Active · Pause",
			[UiKey.PowerPaused] = "Paused · Resume",
			[UiKey.PauseTypingAssistant] = "Pause typing assistant",
			[UiKey.ResumeTypingAssistant] = "Resume typing assistant",
			[UiKey.PowerActiveTip] = "Active · Pause typing assistant",
			[UiKey.PowerPausedTip] = "Paused · Resume typing assistant",
			[UiKey.Cancel] = "Cancel",
			[UiKey.Close] = "Close",
			[UiKey.Save] = "Save",
			[UiKey.On] = "On",
			[UiKey.Off] = "Off",
			[UiKey.CancelOperation] = "Cancel",
			[UiKey.SettingsCategories] = "Settings categories",
			[UiKey.TabGeneral] = "General",
			[UiKey.TabTyping] = "Typing",
			[UiKey.TabTranslation] = "Translation",
			[UiKey.TabFonts] = "Fonts",
			[UiKey.TabShortcuts] = "Shortcuts",
			[UiKey.TypingAssistant] = "Typing assistant",
			[UiKey.EnableCocoTyping] = "Enable Diyar",
			[UiKey.Startup] = "Startup",
			[UiKey.RunWhenWindowsStarts] = "Run when Windows starts",
			[UiKey.StartupIsolatedInVerification] = "Startup registration is isolated during verification.",
			[UiKey.StartupSavedInVerification] = "Saved in verification profile.",
			[UiKey.Updates] = "Updates",
			[UiKey.CheckForUpdatesAtStartup] = "Check for updates at startup",
			[UiKey.ReleaseChannel] = "Release channel",
			[UiKey.StableReleases] = "Stable releases",
			[UiKey.StableAndPreviewReleases] = "Stable and preview releases",
			[UiKey.UpdateSource] = "Update source",
			[UiKey.EditUpdateUrl] = "Edit update URL",
			[UiKey.UpdateManifestUrl] = "HTTPS update manifest URL",
			[UiKey.UpdateSourceSaved] = "Update source saved.",
			[UiKey.CheckForUpdates] = "Check for updates",
			[UiKey.InstalledVersion] = "Installed version",
			[UiKey.UpdatesDisabledInVerification] = "Update requests are disabled in verification.",
			[UiKey.CheckingForUpdates] = "Checking for updates...",
			[UiKey.UpdateAvailable] = "Update available",
			[UiKey.ViewReleaseAndInstallers] = "View release and installers",
			[UiKey.UpdateNoticeText] = "Diyar {0} is available.",
			[UiKey.ViewRelease] = "View release",
			[UiKey.PendingUpdateText] = "Version {0} is available. Download the installer from the release page and run it; Diyar does not download or install it.",
			[UiKey.Diagnostics] = "Diagnostics",
			[UiKey.DebugMode] = "Debug mode (compact diagnostic log)",
			[UiKey.DebugModeExplanation] = "Debug mode keeps a local diagnostic log. It records every word you type with what Diyar decided and did, samples of the text your editor showed before the cursor, the application, window title and field you typed into, what it learned about each editor, the settings in force, keyboard-layout changes and a snapshot around anything that went wrong, with a per-application summary every 10 minutes. Up to a full day is kept (eight files of 8 MiB). The log and saved reports contain your typed text, your editor's text and window titles. They stay on this PC until you send them, and sending a report shares them. Save a report BEFORE turning it off: turning it off deletes the temporary log and the recent history in memory; saved problem reports are kept. Do not type passwords or private text while it is on.",
			[UiKey.DebugStatusOn] = "On. Logging to {0}",
			[UiKey.DebugStatusOnForThisRun] = "On for this run because {0} is set; the switch turns it off. Logging to {1}",
			[UiKey.DebugStatusOff] = "Off. When on, the log is written to {0}",
			[UiKey.ReportTypingProblem] = "Report recent typing problem",
			[UiKey.ExpectedTextPrompt] = "What did you expect? (optional)",
			[UiKey.TurnDebugOnFirst] = "Turn Debug mode on first: there is no recent history to report.",
			[UiKey.SaveReport] = "Save report",
			[UiKey.NothingSavedDebugOff] = "Nothing was saved: Debug mode is off.",
			[UiKey.ReportSaved] = "Report saved to {0}",
			[UiKey.ReportSavedWithoutExpected] = "Report saved without an expected text to {0}",
			[UiKey.OpenLogFolder] = "Open log folder",
			[UiKey.ClearLog] = "Clear log",
			[UiKey.LogCleared] = "The debug log was cleared.",
			[UiKey.CrashFolderNote] = "When Diyar closes because of an error, it saves a crash record even with Debug mode off. Crash records hold no typed text, window titles or clipboard: only the version, Windows, the typing mode and where the error happened. To report a crash, send the files in the crash folder.",
			[UiKey.OpenCrashFolder] = "Open crash folder",
			[UiKey.LastSessionEndedNormally] = "Last session ended normally on {0}.",
			[UiKey.LastSessionCrashed] = "Last session closed because of an error on {0}; a crash record was saved.",
			[UiKey.LastSessionEndedWithoutRecord] = "Last session did not end through Diyar's own exit on {0}: Windows or another program may have closed it, or it crashed in a way Diyar could not record.",
			[UiKey.HandledFaultsThisSession] = "Errors caught this session without closing Diyar: {0}",
			[UiKey.ClosedUnexpectedly] = "Diyar closed because of an error last time. A crash record with no typed text was saved; please send the files in the crash folder to the developers.",
			[UiKey.ClosedWithoutRecord] = "Diyar's last session did not end normally. If it closed by itself, please send the files in the crash folder to the developers, with the time it happened.",
			[UiKey.WindowErrorTypingContinues] = "An error occurred in Diyar's window. Typing goes on, and the error was saved in the crash folder.",
			[UiKey.HelpLanguage] = "Help language",
			[UiKey.HelpButtonName] = "Help: {0}",
			[UiKey.OpenFullHelp] = "Open full Help",
			[UiKey.HelpIntro] = "The complete Diyar guide. Select a topic to jump to it. Every section of Settings also has a help (?) button that shows the same explanation.",
			[UiKey.HelpContents] = "Contents",
			[UiKey.HelpYourShortcuts] = "Your shortcuts",
			[UiKey.HelpShortcutsNote] = "These shortcuts work in every application. Change them in Settings › Shortcuts.",
			[UiKey.HelpSupport] = "Support",
			[UiKey.HelpSupportText] = "Version {0}. For questions, problem reports and suggestions, visit the Diyar website.",
			[UiKey.CommandToggleLastWord] = "Toggle last typed word",
			[UiKey.CommandUndoLastTranslation] = "Undo last translation",
			[UiKey.CommandConvertSelectedWord] = "Convert selected word",
			[UiKey.CommandAddSelectedWord] = "Add selected word to personal dictionary",
			[UiKey.CommandTranslateSelectedText] = "Translate selected text",
			[UiKey.CommandConvertNonDictionaryWords] = "Convert non-dictionary words",
			[UiKey.CommandUndoManualCorrection] = "Undo last manual correction",
			[UiKey.CommandTranslateClipboard] = "Translate clipboard text",
			[UiKey.CommandPauseResume] = "Pause or resume typing",
			[UiKey.TranslatingPressAgainToCancel] = "Translating... Press {0} again to cancel.",
			[UiKey.AboutTagline] = "Persian typing for an English keyboard",
			[UiKey.AboutDedication] = "Developed far from home, in memory of home.",
			[UiKey.AboutSupportTitle] = "Support us",
			[UiKey.AboutSupportText] = "If you enjoy using Diyar and it has made your work easier, please support us so it can keep being developed for free.",
			[UiKey.AboutSupportLink] = "Donate",
			[UiKey.AboutVersion] = "Version",
			[UiKey.AboutReleaseDate] = "Release date",
			[UiKey.AboutPreview] = "Preview release for evaluation. Features may change before the stable release.",
			[UiKey.AboutCopyright] = "Copyright © 2026 IranUX. All rights reserved.",
			[UiKey.License] = "License",
			[UiKey.LicenseSummary] = "Free for end users under the supplied license. Redistribution, resale, modification and commercial reuse require permission from IranUX.",
			[UiKey.ReadLicense] = "Read license",
			[UiKey.ThirdPartyNotices] = "Third-party notices",
			[UiKey.DocumentMissing] = "This document is missing from the application package.",
			[UiKey.TypingMode] = "Typing mode",
			[UiKey.ModeAutomaticCorrection] = "Automatic correction",
			[UiKey.ModeAutomaticCorrectionDescription] = "Words typed for the Persian layout become Persian when you finish them, without pressing anything; English words stay English.",
			[UiKey.ModePersianTypingDirect] = "Persian typing (direct)",
			[UiKey.ModePersianTypingDirectDescription] = "Each key types its Persian letter the moment you press it, as on a Persian keyboard. Nothing you typed is read or replaced; English is typed with the hold key.",
			[UiKey.ModeCapsLockSwitch] = "Caps Lock switch",
			[UiKey.ModeCapsLockSwitchDescription] = "Caps Lock switches the Windows keyboard language, or types Persian directly only while it is on.",
			[UiKey.ModeShiftSwitch] = "Shift key switch",
			[UiKey.ModeShiftSwitchDescription] = "Holding Shift switches an installed keyboard language while it stays down.",
			[UiKey.AnotherModeSelected] = "Another mode is selected under Other modes",
			[UiKey.OtherMode] = "Other mode",
			[UiKey.NotInUse] = "Not in use",
			[UiKey.OnlyOneModeActive] = "Selecting a mode replaces the others — only one is ever active while you type.",
			[UiKey.OtherModes] = "Other modes",
			[UiKey.OtherModesExplanation] = "Caps Lock switch: Caps Lock changes the Windows keyboard language, or types Persian directly only while it is on. Shift key switch: hold one Shift key to type in your second Windows language.",
			[UiKey.Keyboard] = "Keyboard",
			[UiKey.PersianKeyboardLayout] = "Persian keyboard layout",
			[UiKey.DetectInstalledLayout] = "Detect installed layout",
			[UiKey.PersianStandardLayout] = "Persian Standard",
			[UiKey.WindowsPersianLayout] = "Windows Persian",
			[UiKey.KeysTypeAsPersianStandard] = "English keys type Persian as on Persian (Standard). Applies wherever Persian letters are typed or switched to, in every typing mode.",
			[UiKey.KeysTypeAsWindowsPersian] = "English keys type Persian as on Windows Persian. Applies wherever Persian letters are typed or switched to, in every typing mode.",
			[UiKey.KeysTypeAsEitherLayout] = "English keys type Persian as on either Persian layout (none installed; the best match is chosen per word). Applies wherever Persian letters are typed or switched to, in every typing mode.",
			[UiKey.LayoutsInUse] = "Windows layouts in use: English — {0}; Persian — {1}.",
			[UiKey.NotInstalled] = "not installed",
			[UiKey.DefaultEnglishLayout] = "Default English layout",
			[UiKey.DefaultPersianLayout] = "Default Persian layout",
			[UiKey.Automatic] = "Automatic",
			[UiKey.EnglishNotInstalled] = "English is not installed in Windows. Automatic correction needs an English layout to type on.",
			[UiKey.PersianNotInstalled] = "Persian is not installed in Windows. Correction still works; the Caps Lock and Shift language switches need it to switch to.",
			[UiKey.LayoutToInstall] = "Layout to install",
			[UiKey.Install] = "Install",
			[UiKey.LanguageEnglish] = "English",
			[UiKey.LanguagePersian] = "Persian",
			[UiKey.KeyLeftShift] = "Left Shift",
			[UiKey.KeyRightShift] = "Right Shift",
			[UiKey.KeyLeftCtrl] = "Left Ctrl",
			[UiKey.KeyRightCtrl] = "Right Ctrl",
			[UiKey.KeyLeftAlt] = "Left Alt",
			[UiKey.KeyRightAlt] = "Right Alt",
			[UiKey.HoldKey] = "Hold key",
			[UiKey.HoldKeyForEnglish] = "Key for English",
			[UiKey.HoldKeyForPersian] = "Key for Persian",
			[UiKey.HoldKeysConflict] = "This key cannot be used here: it is already the other key, or the other side of the same key (both Shift keys, both Ctrl keys or both Alt keys). A hold key no longer does its usual job, so both sides would leave no Shift, Ctrl or Alt at all.",
			[UiKey.TargetLanguage] = "Target language",
			[UiKey.CapsLockAndHoldKey] = "Caps Lock and hold key",
			[UiKey.AutomaticCapsLockRule] = "Caps Lock: unless Caps Lock is the hold key, correction pauses while it is on and Windows types capitals.",
			[UiKey.DirectCapsLockRule] = "Caps Lock: unless Caps Lock is the hold key, it does not pause this mode; keys still type Persian letters while it is on.",
			[UiKey.CapitalizeEnglishAfterPersian] = "Capital first letter for English after Persian",
			[UiKey.HoldKeyYieldsToShortcuts] = "Let Windows shortcuts use the hold key",
			[UiKey.HoldKeyYieldsToShortcutsTip] = "On: a hold key pressed together with Win, Ctrl or Alt is part of a shortcut, so Win+Shift+S and Ctrl+Shift+T work. If you press the hold key first, the shortcut gets it only while nothing has been typed with it yet, so Ctrl+Z in the middle of a held word stays Undo. Off: the hold key never reaches Windows.",
			[UiKey.HeldBoundaryEndsEnglishLock] = "End the English word at a Space typed with the hold key",
			[UiKey.HeldBoundaryEndsEnglishLockTip] = "On: a Space, Enter or Tab typed while you still hold the key for English ends the English word, so the next word you type after releasing the key is corrected as usual (typed in Persian in Persian typing (direct)). A Backspace, an arrow key or a shortcut pressed after the release keeps the held word English until its next Space. Off: the next word stays English until its Space, as before.",
			[UiKey.CapitalizeEnglishTip] = "When you type an English word with the hold key right after a Persian word, its first letter is typed as a capital (فایل Readme). A letter you type with Shift, a word that starts with a symbol or number, and the first word of a line are left as typed. Names that are written in lowercase, such as npm, get a capital too: press Backspace and retype the letter.",
			[UiKey.HoldKeyWarning] = "Hold key warning",
			[UiKey.UseItForEnglish] = "Use it for English",
			[UiKey.UseItForEnglishTip] = "Makes the key for Persian the key for English, in this mode and in Automatic correction",
			[UiKey.NoHoldKeyWarning] = "No hold key is set, so this mode has no way to type English: you would have to switch the Windows keyboard language or pause Diyar. Choose a key above; Caps Lock is recommended.",
			[UiKey.HoldKeyTypesPersianWarning] = "The only hold key is the key for Persian, set in Automatic correction. This mode already types Persian, so here it does nothing and English cannot be typed.",
			[UiKey.HoldKeyForTypingEnglish] = "Hold key for typing English",
			[UiKey.HoldNoteOff] = "Off. Choose a key for English, a key for Persian, or both: while you hold one, that language is typed without correction. Caps Lock is recommended for one of them: it works as an on/off switch, and no other key loses its usual job.",
			[UiKey.HoldNoteCapsLockPersian] = "While Caps Lock is on, each key types its Persian letter, as on a Persian keyboard. Turn Caps Lock off to return to automatic correction; what you already typed is not changed.",
			[UiKey.HoldNoteKeyPersian] = "While you hold {0}, each key types its Persian letter, as on a Persian keyboard. Release it to return to automatic correction; what you already typed is not changed.",
			[UiKey.HoldNoteCapsLockEnglish] = "While Caps Lock is on, you type plain English and nothing is corrected. Turn Caps Lock off to return to automatic correction.",
			[UiKey.HoldNoteKeyEnglish] = "While you hold {0}, you type plain English and nothing is corrected. Release it to return to automatic correction.",
			[UiKey.DirectHoldNoteNone] = "This is how you type English in this mode. Choose a key; Caps Lock is recommended.",
			[UiKey.DirectHoldNoteCapsLock] = "This is how you type English in this mode: while Caps Lock is on, the keys type plain English (hold Shift for a capital). Turn Caps Lock off to type Persian again.",
			[UiKey.DirectHoldNoteKey] = "This is how you type English in this mode: while you hold {0}, the keys type plain English. Release it to type Persian again.",
			[UiKey.ModifierKeyNote] = "This key no longer does its usual job anywhere while it is set; Caps Lock is recommended instead, because it is never withheld from Windows.",
			[UiKey.PriorityForAmbiguousInput] = "Priority for ambiguous input",
			[UiKey.PriorityNormal] = "Normal (recommended)",
			[UiKey.PriorityNormalDescription] = "Words are decided as before this setting existed: a Persian word it knows becomes Persian, and a common English word stays English even when its keys also spell a Persian word. A single letter and the comma key follow the word before them.",
			[UiKey.PriorityPersianDescription] = "A word that is both a known English word and a known Persian word, such as fun (بعد) or leg (مثل), becomes Persian. A single letter typed on its own becomes its Persian letter (d → ی), and the comma key types و at once, anywhere in a word; type the Persian comma ، with {0}.",
			[UiKey.PriorityEnglishDescription] = "A word that is both a known English word and a known Persian word, such as fun or leg, stays English. A single letter typed on its own stays English, and the comma key types a comma.",
			[UiKey.PriorityContextual] = "Contextual",
			[UiKey.PriorityContextualDescription] = "Normal, plus one exception: a word that is both a known English word and a common Persian word, such as fun (بعد) or leg (مثل), becomes Persian when the words before it are Persian - two Persian words in a row, a Persian word such as به or برای, or a message with no English in it yet. After an English word, as the first word, and for the commonest English words such as and, how or do, it stays English. A single letter and the comma key are as under Normal.",
			[UiKey.PriorityScope] = "Contextual, Persian and English only settle words both languages recognize; Persian and English also settle single letters and the comma key. Words only one language recognizes, unknown words, protected fields and technical terms are handled the same in all four.",
			[UiKey.WordForms] = "Persian word forms",
			[UiKey.WordFormsChoice] = "Recognize Persian words with suffixes",
			[UiKey.WordFormsTip] = "Whether a known Persian word followed by suffixes, such as درخت\u200cها, is recognized",
			[UiKey.WordFormsFull] = "Words with suffixes (recommended)",
			[UiKey.WordFormsFullDescription] = "A known Persian word with suffixes the dictionary does not list becomes Persian next to Persian text: درخت\u200cها, درختهاش, اطلاعاتی. A word typed without its ZWNJ after می counts too (میرسیم). Keys that spell an English word stay English, a word with suffixes also stays when its keys are an English typo, and nothing changes inside English text. Separate endings such as ها and رو also convert after an English word: Button ها رو.",
			[UiKey.WordFormsEnclitics] = "Separate endings only",
			[UiKey.WordFormsEncliticsDescription] = "Only the separate endings, such as ها and رو, convert after an English word: Button ih becomes Button ها. A word with suffixes is decided as before.",
			[UiKey.WordFormsOffDescription] = "Words with suffixes and separate endings are decided exactly as before this setting existed.",
			[UiKey.KeyboardLayoutGroup] = "Keyboard layout",
			[UiKey.StartNewWordAfterLayoutSwitch] = "Start a new word after a keyboard-layout switch",
			[UiKey.StartNewWordAfterLayoutSwitchTip] = "On: switching the Windows keyboard layout with Alt+Shift, Win+Space or the language bar ends the word being typed, so nothing typed before the switch is replaced. Off: the keys typed under both layouts count as one word, as in earlier versions.",
			[UiKey.LayoutSwitchNote] = "When you switch the Windows keyboard layout in the middle of a word, the letters typed before the switch are left as they are and the word is checked only from the switch on. Layouts Diyar switches itself are not affected.",
			[UiKey.CorrectionBehavior] = "Correction behavior",
			[UiKey.DirectTypingCardText] = "Each key types its Persian letter the moment you press it, as on a Persian keyboard; Shift gives the shifted letter, such as آ or ژ. On a symbol key, Shift types the Persian keyboard's own symbol or mark, as the Windows Persian keyboard does: the diacritics, ٪, ×, ریال, the Persian comma ،, « » and the brackets. Nothing you typed is read or replaced, Backspace deletes one letter, and digits and other punctuation stay as typed. No dictionary is used, so a capital letter does not keep a word English: type English with the hold key below.",
			[UiKey.AutomaticCorrectionCardText] = "Known Persian words, and words whose keys can only be Persian, become Persian as you type. English words, unknown words, capitalized words, addresses, numbers and technical terms stay as typed. Toggle last typed word (Ctrl+Alt+Space) right after a converted word turns it back into the keys you typed.",
			[UiKey.Spelling] = "Spelling",
			[UiKey.CorrectPersianTypos] = "Correct confident Persian spelling mistakes",
			[UiKey.KeysThatFinishAWord] = "Keys that finish a word",
			[UiKey.KeysThatFinishAWordNote] = "A word is checked when you press any of these. They are not alternatives - turn on every key you finish a word with. Punctuation such as {0} always finishes a word.",
			[UiKey.SpaceKey] = "Space",
			[UiKey.AtLeastOneFinishingKey] = "At least one key must finish a word. Turn another key on before turning this one off.",
			[UiKey.WhenCapsLockIsOn] = "When Caps Lock is on",
			[UiKey.CapsLockSwitchLanguage] = "Switch Windows language",
			[UiKey.CapsLockDirectWhileOn] = "Persian typing (direct) while on",
			[UiKey.CapsLockManualWhileOn] = "Manual typing while on",
			[UiKey.CapsLockAutomaticWhileOnLegacy] = "Auto correction while on (legacy)",
			[UiKey.CapsLockAutomaticDescription] = "While Caps Lock is on, Diyar corrects as you type, exactly like Automatic correction mode. A Persian keyboard switches to English automatically, and your previous language comes back when Caps Lock turns off. Letters are typed in normal case; hold Shift for a capital. This action is kept for your settings but is no longer offered; choosing another one removes it from the list.",
			[UiKey.CapsLockDirectDescription] = "While Caps Lock is on, each key types its Persian letter the moment you press it, exactly like Persian typing (direct): nothing is read or replaced, Shift gives the shifted letter (آ, ژ) and Backspace deletes one letter. A Persian keyboard switches to English automatically, and your previous language comes back when Caps Lock turns off.",
			[UiKey.CapsLockManualDescription] = "While Caps Lock is on, the English keys are typed and each finished word is replaced with Persian; a word that starts with a capital (hold Shift) stays English. This is the earlier behavior, kept because direct typing is turned off in this profile's settings file. A Persian keyboard switches to English automatically, and your previous language comes back when Caps Lock turns off.",
			[UiKey.CapsLockSwitchDescription] = "Caps Lock only switches the Windows keyboard language: on selects the language below, off switches to the other one. Nothing is corrected or converted. Both languages must already be installed in Windows.",
			[UiKey.WindowsLanguageWhileCapsLockOn] = "Windows language while Caps Lock is on",
			[UiKey.EnglishLetterCase] = "English letter case",
			[UiKey.NormalLetterCase] = "Normal letter case",
			[UiKey.CapitalLetters] = "Capital letters",
			[UiKey.LanguageGroup] = "Language",
			[UiKey.CapsLockSwitchNoDirection] = "Windows types directly in this behaviour, so Diyar does not touch the text and cannot stabilize its direction or format amounts. Choose Persian typing (direct) while on above to stabilize the direction; amounts are formatted only by Automatic correction.",
			[UiKey.SwitchKey] = "Switch key",
			[UiKey.SwitchKeyLeftShift] = "Left Shift (Right Shift gives special/shifted characters)",
			[UiKey.SwitchKeyRightShift] = "Right Shift (Left Shift gives special/shifted characters)",
			[UiKey.ShiftSwitchTarget] = "While the switch key is held, switch to",
			[UiKey.ShiftSwitchExplanation] = "Holding the switch key above requests the installed language above for the focused editor for as long as it stays down, then restores the other installed language on release. This switches the real Windows keyboard — Diyar does not correct or convert while this mode is selected.",
			[UiKey.ShiftSwitchShiftedCharacters] = "While the switch key is held, also hold the other Shift key for a special or shifted character: capital letters, English punctuation like {0}, or special Persian letters like آ and ژ. Caps Lock keeps its normal effect on English letters. With Space it types the half-space (نیم\u200cفاصله).",
			[UiKey.TextDirection] = "Text direction",
			[UiKey.TextDirectionAndAmounts] = "Text direction and amounts",
			[UiKey.StabilizeMixedText] = "Stabilize mixed Persian and English text",
			[UiKey.FormatCurrencyAmounts] = "Format Persian currency amounts",
			[UiKey.NoAmountsNote] = "Keeps word and punctuation order stable when Persian and English share a line. Amount formatting is not offered here, because it is part of converting a word and nothing is converted in this mode.",
			[UiKey.DirectTypingAmountNote] = "Keeps word and punctuation order stable when Persian and English share a line. Amount formatting is not offered here: it applies only when Automatic correction converts a currency word typed with English keys, and in this mode each key types its letter at once.",
			[UiKey.Numbers] = "Numbers",
			[UiKey.PersianDigitsInPersianText] = "Persian digits in Persian text",
			[UiKey.PersianDigitsTip] = "Whether a number of up to six digits typed after Persian text becomes Persian digits, such as ۳ or ۱۵۰, when you finish it",
			[UiKey.PersianDigitsNote] = "Off by default. When on, a number you finish with Space, {0} or {1} becomes the digits of your Persian layout if the word before it is Persian (or, with Persian priority, if it does not follow English text). A decimal point, or a comma before exactly three digits, becomes a Persian separator, so {2} becomes ۳٫۵. Numbers with a leading zero, more than six digits, a comma not followed by exactly three digits, more than one separator, times, dates, addresses and versions stay as typed, and so does everything in spreadsheets, code editors and terminals. The Windows Persian layout types ASCII digits, so it changes nothing there.",
			[UiKey.TranslationService] = "Translation service",
			[UiKey.OnDeviceModel] = "On-device model",
			[UiKey.EnableTranslationShortcut] = "Enable translation shortcut",
			[UiKey.TranslatedText] = "Translated text",
			[UiKey.MatchParagraphDirection] = "Match paragraph direction to target language",
			[UiKey.AllowUndoTranslation] = "Allow undo with the Undo last translation shortcut",
			[UiKey.TranslationTargetTip] = "Automatic translates a mostly Persian or Arabic selection to English and any other selection to Persian. An explicit language translates every selection into it.",
			[UiKey.TranslationShortcutsNote] = "Automatic (Persian ↔ English) reads each selection: mostly Persian or Arabic script is translated to English, anything else to Persian. {0} translates the selection in place; {1} translates the clipboard text and puts the translation back on the clipboard without touching your text. Pressing either again while a translation runs cancels it.",
			[UiKey.AllowClipboardFallback] = "Use the clipboard where the editor cannot be read",
			[UiKey.AllowClipboardFallbackTip] = "Only where the selection cannot be read or written directly. The copy is kept out of clipboard history and cloud sync, and the previous clipboard text is put back. Off: such selections are refused and the clipboard is never touched.",
			[UiKey.CancelDownload] = "Cancel download",
			[UiKey.CancelDownloadTip] = "Stops the download in progress. The model is not set up until a download finishes.",
			[UiKey.WarmUpLocalModel] = "Load the model when Diyar starts",
			[UiKey.WarmUpLocalModelTip] = "Loads the downloaded model once in the background after start-up, or when this is turned on, so the first translation does not wait for it. The model then stays in memory while Diyar runs. Off: the model loads at the first translation.",
			[UiKey.WarmUpLocalModelNote] = "Off, which is the default, keeps the model out of memory until the first translation; that translation then takes longer.",
			[UiKey.ModelDownloadCancelled] = "Model download cancelled. Download it again when you are ready.",
			[UiKey.ApiKey] = "API key",
			[UiKey.AzureApiKey] = "Azure API key",
			[UiKey.ResourceRegion] = "Resource region",
			[UiKey.KeyStoredSecurely] = "A key is stored securely for this Windows account.",
			[UiKey.NoApiKeySaved] = "No API key saved.",
			[UiKey.SaveConnection] = "Save connection",
			[UiKey.KeyCouldNotBeStored] = "The key could not be stored. Nothing was saved.",
			[UiKey.EnterAzureKeyFirst] = "Enter your Azure Translator key first.",
			[UiKey.ConnectionSaved] = "Connection saved. Test it before translating.",
			[UiKey.TestConnection] = "Test connection",
			[UiKey.SaveBeforeTesting] = "Save your changes before testing the connection.",
			[UiKey.TestingConnection] = "Testing connection...",
			[UiKey.RemoveSavedKey] = "Remove saved key",
			[UiKey.RemoveSavedKeyQuestion] = "Remove saved key?",
			[UiKey.RemoveSavedKeyBody] = "Translation with Azure will be unavailable until you save another key.",
			[UiKey.Remove] = "Remove",
			[UiKey.SavedKeyRemoved] = "Saved key removed.",
			[UiKey.AzureConnection] = "Azure connection",
			[UiKey.SetupHelp] = "Setup help",
			[UiKey.AzureSendsOnlySelected] = "Only text you explicitly select for translation is sent to Microsoft Azure.",
			[UiKey.AzureSetupTitle] = "Set up Azure Translator",
			[UiKey.AzureSetupStep1] = "1. Create a Translator resource in your own Microsoft Azure account.",
			[UiKey.AzureSetupStep2] = "2. Open {0}. Copy {1} or {2} into API key.",
			[UiKey.AzureSetupStep3] = "3. Copy the {0} value into Resource region, for example {1}. Use {2} for a global Translator resource.",
			[UiKey.AzureSetupStep4] = "4. Save the connection, then select Test connection.",
			[UiKey.AzureSetupCosts] = "Azure requires internet access. Your account's plan, quota and charges apply. Diyar does not include an Azure subscription.",
			[UiKey.TranslatorSetupDocs] = "Microsoft Translator setup documentation",
			[UiKey.OpenAzurePortal] = "Open Azure portal",
			[UiKey.OnDeviceTranslation] = "On-device translation",
			[UiKey.FirstDownloadNeedsInternet] = "The first model download needs internet access. Translation then runs on this device.",
			[UiKey.CheckModel] = "Check model",
			[UiKey.DownloadModel] = "Download model",
			[UiKey.TypingFont] = "Typing font",
			[UiKey.NoSupportedAppDetected] = "No supported application was detected on this PC.",
			[UiKey.FontAppsSummary] = "{0} of {1} detected applications can be changed · {2} supported apps not installed here",
			[UiKey.SelectAtLeastOneApp] = "Select at least one supported application.",
			[UiKey.RestorePreviousFontsQuestion] = "Restore previous fonts?",
			[UiKey.ApplyFontQuestion] = "Apply font to selected apps?",
			[UiKey.Restore] = "Restore",
			[UiKey.Apply] = "Apply",
			[UiKey.NoApplicationChanged] = "No application was changed.",
			[UiKey.SomeApplicationsChanged] = "{0} of {1} changed.",
			[UiKey.ApplicationDefaults] = "Application defaults",
			[UiKey.RefreshApplications] = "Refresh applications",
			[UiKey.SelectSupported] = "Select supported",
			[UiKey.ApplyFont] = "Apply font",
			[UiKey.RestorePrevious] = "Restore previous",
			[UiKey.KeyboardShortcuts] = "Keyboard shortcuts",
			[UiKey.ChangeShortcutName] = "Change shortcut: {0}",
			[UiKey.ShortcutsHandledInApps] = "Convert selected word, Toggle last typed word and Undo last manual correction are handled inside the application you type in, not registered with Windows. Add selected word works on the word you selected and never edits your text. Translate selected text, Translate clipboard text and Undo last translation work while translation is on; Translate clipboard text translates what is on the clipboard and puts the translation back there, never touching the text you are editing. Pressing a translate shortcut again while a translation runs cancels it.",
			[UiKey.ConvertSelectedWordExplanation] = "Select one word and press Convert selected word: Latin keyboard text becomes Persian, and Persian becomes the Latin keys that type it. Press it again on the unchanged result to get the exact original back. Undo last manual correction puts back the exact word you converted, as long as nothing was typed or changed there since.",
			[UiKey.TextServiceNotInstalled] = "Not installed: these shortcuts need the Diyar text service, which is not registered for your account (install Diyar with its setup program). Nothing is changed until it is.",
			[UiKey.TextServiceWorks] = "Works in every application that gives Diyar an editing context. Password, read-only and composing fields are refused, and every change is read back before it counts.",
			[UiKey.SaveSelectedWordCorrections] = "Save successful selected-word corrections to my personal dictionary",
			[UiKey.WhenOffNoWordAdded] = "When this is off, a conversion adds no word and makes no review proposal.",
			[UiKey.EnableToggleLastWord] = "Enable Toggle last typed word",
			[UiKey.SaveLastWordCorrections] = "Save successful last-word corrections to my personal dictionary",
			[UiKey.ToggleLastWordExplanation] = "Press {0} right after a word (with or without the space after it): Latin keyboard text becomes Persian, and Persian becomes the Latin keys. Press it again before typing anything to get the exact original back. Undo last manual correction also restores it.",
			[UiKey.NonDictionaryWordsUnavailable] = "Convert non-dictionary words cannot run in this build, so it has no shortcut.",
			[UiKey.NewShortcut] = "New shortcut",
			[UiKey.PressKeyCombination] = "Press a key combination",
			[UiKey.SaveShortcut] = "Save shortcut",
			[UiKey.RecorderInstructions] = "Press Ctrl or Alt with another key. Escape cancels without changing your shortcut.",
			[UiKey.CurrentShortcut] = "Current: {0}",
			[UiKey.NoWindowsKey] = "Choose a shortcut without the Windows key to avoid system shortcuts.",
			[UiKey.ShortcutInUse] = "Another action already uses this shortcut.",
			[UiKey.ShortcutSaved] = "Shortcut saved.",
			[UiKey.DictionaryViews] = "Dictionary views",
			[UiKey.PersonalDictionary] = "Personal dictionary",
			[UiKey.BuiltInDictionary] = "Built-in dictionary",
			[UiKey.WordReviewQueue] = "Word review queue",
			[UiKey.SearchWordReviewQueue] = "Search the word review queue",
			[UiKey.SearchBuiltInDictionary] = "Search the built-in dictionary",
			[UiKey.SearchPersonalDictionary] = "Search your personal dictionary",
			[UiKey.SearchDictionary] = "Search dictionary",
			[UiKey.AllLanguages] = "All languages",
			[UiKey.FilterDictionaryLanguage] = "Filter dictionary language",
			[UiKey.AutoAddConfirmedCorrections] = "Add confirmed corrections to my personal dictionary automatically",
			[UiKey.PersonalDictionaryWords] = "Personal dictionary words",
			[UiKey.BuiltInDictionaryWords] = "Built-in dictionary words",
			[UiKey.ColumnProposedWord] = "Proposed word",
			[UiKey.ColumnTypedAs] = "Typed as",
			[UiKey.ColumnAwaitingReview] = "Awaiting review",
			[UiKey.ColumnDictionary] = "Dictionary",
			[UiKey.ColumnStatus] = "Status",
			[UiKey.ColumnStatusConversion] = "Status · conversion",
			[UiKey.Word] = "Word",
			[UiKey.WordLanguage] = "Language",
			[UiKey.NoWordsAwaitingReview] = "No words are waiting in the word review queue",
			[UiKey.NoMatchingWords] = "No matching words",
			[UiKey.PreviousPage] = "Previous page",
			[UiKey.NextPage] = "Next page",
			[UiKey.AddWords] = "Add words",
			[UiKey.Import] = "Import",
			[UiKey.Export] = "Export",
			[UiKey.NoPersonalWordsToExport] = "There are no personal words to export. Only personal words are exported, never the built-in dictionary.",
			[UiKey.PersonalDictionaryFileType] = "Personal dictionary JSON",
			[UiKey.ExportedPersonalWords] = "Exported {0} personal words.",
			[UiKey.AcceptSelected] = "Accept selected",
			[UiKey.AcceptAll] = "Accept all",
			[UiKey.AcceptAllQuestion] = "Accept all proposed words?",
			[UiKey.AcceptAllBody] = "Add {0} proposed words to your personal dictionary? Words already in either dictionary are skipped.",
			[UiKey.RetryKeepingCopy] = "Retry keeping a copy",
			[UiKey.CopyKept] = "A copy of the unreadable file was kept. Changes can be saved again.",
			[UiKey.SelectPage] = "Select page",
			[UiKey.ClearSelection] = "Clear selection",
			[UiKey.DictionaryHelp] = "Dictionary help",
			[UiKey.Edit] = "Edit",
			[UiKey.EditPersonalWord] = "Edit personal word",
			[UiKey.NeutralOlderEntry] = "Neutral (older entry)",
			[UiKey.Category] = "Category",
			[UiKey.CategoryGeneral] = "General",
			[UiKey.CategoryTechnical] = "Technical",
			[UiKey.CategoryName] = "Name",
			[UiKey.CategoryAcronym] = "Acronym",
			[UiKey.CategoryCommand] = "Command",
			[UiKey.CategoryCurrency] = "Currency",
			[UiKey.ProtectFromAutomaticConversion] = "Protect from automatic conversion",
			[UiKey.EntryEnabled] = "Enabled",
			[UiKey.WordSaved] = "Word saved.",
			[UiKey.WordNotSaved] = "The word is empty, not a single word, or already in this language's dictionary.",
			[UiKey.Reject] = "Reject",
			[UiKey.Delete] = "Delete",
			[UiKey.RejectProposedWordsQuestion] = "Reject proposed words?",
			[UiKey.DeletePersonalWordsQuestion] = "Delete personal words?",
			[UiKey.RejectProposedWordsBody] = "Reject {0} proposed words? They leave the queue and nothing is added.",
			[UiKey.DeletePersonalWordsBody] = "Delete {0} words from your personal dictionary? A word that is also in the built-in dictionary is still recognized through it.",
			[UiKey.RejectAll] = "Reject all",
			[UiKey.DeleteAll] = "Delete all",
			[UiKey.DeleteAllPersonalWords] = "Delete all personal words",
			[UiKey.RejectAllQuestion] = "Reject all proposed words?",
			[UiKey.DeleteAllPersonalWordsQuestion] = "Delete all personal words?",
			[UiKey.RejectAllBody] = "Every proposal leaves the queue and nothing is added. This cannot be undone.",
			[UiKey.DeleteAllBody] = "This cannot be undone. Built-in words are not affected, so a word that is also built in is still recognized.",
			[UiKey.WordCount] = "{0} words",
			[UiKey.SelectedOnPage] = "{0} selected on this page · {1} words",
			[UiKey.SourceBuiltIn] = "Built-in",
			[UiKey.SourcePersonal] = "Personal",
			[UiKey.LanguageNeutral] = "Neutral",
			[UiKey.StatusReadOnly] = "Read-only",
			[UiKey.StatusAddedAutomatically] = "Added automatically",
			[UiKey.StatusAccepted] = "Accepted",
			[UiKey.StatusDisabled] = "Disabled",
			[UiKey.StatusProtected] = "Protected",
			[UiKey.StatusAllowed] = "Allowed",
			[UiKey.ReviewUses] = "{0} use(s) · {1}",
			[UiKey.UnsavedProposals] = "Some proposals recorded while you were typing are kept in memory only: the queue file could not be saved. They will be saved with the next change that succeeds, and are lost if Diyar closes first.",
			[UiKey.NothingWasOverwritten] = "{0} Nothing was overwritten.",
			[UiKey.Words] = "Words",
			[UiKey.DetectFromLetters] = "Detect from the letters",
			[UiKey.AddToPersonalDictionary] = "Add to your personal dictionary",
			[UiKey.ImportSummary] = "Imported into your personal dictionary: {0} added · {1} already there · {2} already in the built-in dictionary · {3} rejected",
			[UiKey.LanguageCardTitle] = "Language · زبان",
			[UiKey.InterfaceLanguage] = "Interface language",
			[UiKey.InterfaceLanguageTip] = "The language of Diyar's window, tray menu and messages",
			[UiKey.InterfaceLanguageNote] = "Changes at once, without a restart. Typing, conversion and your shortcuts work exactly the same in either language.",
			[UiKey.AlreadyRunning] = "Diyar is already running. Open it from the Windows system tray. Close the earlier version before starting the WinUI edition.",
			[UiKey.CouldNotStart] = "Diyar could not start",
			[UiKey.EnglishOnlyPlacesTitle] = "English-only places",
			[UiKey.EnglishOnlyPlacesIntro] = "In every place switched on here Diyar changes nothing you type, so your keys stay exactly as typed. Switch a place off to type there with your typing mode, as everywhere else.",
			[UiKey.EnglishOnlyFields] = "Fields, in every mode",
			[UiKey.PlaceBrowserAddressBar] = "Browser address bar",
			[UiKey.PlaceBrowserAddressBarTip] = "Chrome, Edge, Firefox and the other browsers. Off: Persian can be typed there, and Automatic correction converts words there too.",
			[UiKey.PlaceWebAddressField] = "Fields that hold a web address",
			[UiKey.PlaceWebAddressFieldTip] = "A box whose whole text is a web address or a host name, in any application.",
			[UiKey.PlacePaymentCardField] = "Payment card fields",
			[UiKey.PlacePaymentCardFieldTip] = "Card number, name on card, expiry date and security code boxes of a payment form.",
			[UiKey.PlacePasswordField] = "Password fields",
			[UiKey.PlacePasswordFieldTip] = "Always protected: Diyar never changes what you type in a password field.",
			[UiKey.EnglishOnlyFieldsNote] = "With the address bar off, the browser's own suggestion that follows the caret can get in the way of a conversion in Automatic correction; if a word comes out wrong, switch it back on.",
			[UiKey.EnglishOnlyApplications] = "Applications, in Automatic correction",
			[UiKey.EnglishOnlyApplicationsNote] = "In these applications and their dialogs Automatic correction converts nothing; your shortcuts and the other typing modes work as usual. A shell inside Windows Terminal, such as PowerShell or cmd, follows Windows Terminal's switch.",
			[UiKey.EnglishOnlyTerminals] = "Terminals",
			[UiKey.EnglishOnlyLaunchers] = "Launchers and file search",
			[UiKey.EnglishOnlyDatabaseTools] = "Database tools",
			[UiKey.EnglishOnlyRemoteDesktops] = "Remote desktop",
			[UiKey.EnglishOnlyPasswordManagers] = "Password managers",
			[UiKey.FontBrowsersNote] = "Browsers use this font only on pages that do not choose their own. Show in browser opens a page that uses it.",
			[UiKey.FontNotInstalledNote] = "{0} is not installed in Windows, so no application can use it. Choose a font installed in Windows.",
			[UiKey.FontsRevertedNotice] = "These applications changed their font setting back: {0}. Apply the font again.",
			[UiKey.ShowFontInBrowser] = "Show in browser",
			[UiKey.FontCheckNotOpened] = "{0} could not be opened.",
			[UiKey.UpdateNow] = "Update now",
			[UiKey.DownloadAndInstall] = "Download and install",
			[UiKey.UpdateAvailableCardText] = "Version {0} is available ({1}).",
			[UiKey.UpdateDownloadingText] = "Downloading Diyar {0}… {1} of {2}",
			[UiKey.UpdateDownloadProgressName] = "Update download progress",
			[UiKey.UpdateVerifyingText] = "Checking the downloaded file…",
			[UiKey.UpdateReadyText] = "Diyar {0} is ready to install. Diyar closes, installs the update and opens again. Windows asks for permission once.",
			[UiKey.InstallAndRestart] = "Install and restart Diyar",
			[UiKey.UpdateInstallingText] = "Installing Diyar {0}… Diyar closes and opens again by itself.",
			[UiKey.UpdatePermissionRefusedText] = "Windows did not allow the update. Nothing was changed.",
			[UiKey.UpdateCancelledText] = "The update was cancelled. Nothing was changed.",
			[UiKey.UpdateRestartWindowsText] = "Diyar {0} is installed. Restart Windows to finish.",
			[UiKey.UpdateRestartDiyarText] = "Diyar {0} is installed. Restart Diyar to use it.",
			[UiKey.RestartDiyar] = "Restart Diyar",
			[UiKey.UpdateDownloadFailedText] = "The download could not be completed.",
			[UiKey.UpdateFileRejectedText] = "The downloaded file does not match the published release and was deleted.",
			[UiKey.UpdateNotEnoughSpaceText] = "Not enough free space to download the update ({0} needed).",
			[UiKey.UpdateBlockedBySecurityText] = "Windows Security blocked the downloaded installer.",
			[UiKey.UpdateNewerInstalledText] = "A newer Diyar is already installed.",
			[UiKey.UpdateFailedText] = "The update could not be installed (code {0}).",
			[UiKey.UpdateLaunchFailedText] = "The installer could not be started.",
			[UiKey.TryAgain] = "Try again",
			[UiKey.OpenSetupLog] = "Open the setup log",
			[UiKey.OpenUpdateFolder] = "Open the download folder",
			[UiKey.UpdatedToText] = "Diyar was updated to {0}.",
			[UiKey.UpdateDidNotFinishText] = "The update to Diyar {0} did not finish. You can try again from Settings."
		};

		private static readonly Dictionary<UiKey, string> Persian = new Dictionary<UiKey, string>
		{
			[UiKey.NavSettings] = "تنظیمات",
			[UiKey.NavDictionary] = "واژه\u200cنامه",
			[UiKey.NavHelp] = "راهنما",
			[UiKey.NavAbout] = "درباره\u0654 برنامه",
			[UiKey.PowerActive] = "فعال · توقف",
			[UiKey.PowerPaused] = "متوقف · ادامه",
			[UiKey.PauseTypingAssistant] = "توقف موقت دستیار تایپ",
			[UiKey.ResumeTypingAssistant] = "ادامه\u0654 کار دستیار تایپ",
			[UiKey.PowerActiveTip] = "فعال · توقف موقت دستیار تایپ",
			[UiKey.PowerPausedTip] = "متوقف · ادامه\u0654 کار دستیار تایپ",
			[UiKey.Cancel] = "انصراف",
			[UiKey.Close] = "بستن",
			[UiKey.Save] = "ذخیره",
			[UiKey.On] = "روشن",
			[UiKey.Off] = "خاموش",
			[UiKey.CancelOperation] = "لغو",
			[UiKey.SettingsCategories] = "دسته\u200cهای تنظیمات",
			[UiKey.TabGeneral] = "عمومی",
			[UiKey.TabTyping] = "تایپ",
			[UiKey.TabTranslation] = "ترجمه",
			[UiKey.TabFonts] = "قلم\u200cها",
			[UiKey.TabShortcuts] = "میان\u200cبرها",
			[UiKey.TypingAssistant] = "دستیار تایپ",
			[UiKey.EnableCocoTyping] = "فعال بودن Diyar",
			[UiKey.Startup] = "اجرا با ویندوز",
			[UiKey.RunWhenWindowsStarts] = "اجرا هنگام شروع ویندوز",
			[UiKey.StartupIsolatedInVerification] = "در حالت آزمایشی، اجرا با ویندوز فقط در نمایه\u0654 آزمایشی ثبت می\u200cشود.",
			[UiKey.StartupSavedInVerification] = "در نمایه\u0654 آزمایشی ذخیره شد.",
			[UiKey.Updates] = "به\u200cروزرسانی",
			[UiKey.CheckForUpdatesAtStartup] = "بررسی به\u200cروزرسانی هنگام شروع",
			[UiKey.ReleaseChannel] = "کانال انتشار",
			[UiKey.StableReleases] = "نسخه\u200cهای پایدار",
			[UiKey.StableAndPreviewReleases] = "نسخه\u200cهای پایدار و پیش\u200cنمایش",
			[UiKey.UpdateSource] = "منبع به\u200cروزرسانی",
			[UiKey.EditUpdateUrl] = "ویرایش نشانی به\u200cروزرسانی",
			[UiKey.UpdateManifestUrl] = "نشانی فهرست به\u200cروزرسانی (HTTPS)",
			[UiKey.UpdateSourceSaved] = "منبع به\u200cروزرسانی ذخیره شد.",
			[UiKey.CheckForUpdates] = "بررسی به\u200cروزرسانی",
			[UiKey.InstalledVersion] = "نسخه\u0654 نصب\u200cشده",
			[UiKey.UpdatesDisabledInVerification] = "در اجرای آزمایشی، درخواست به\u200cروزرسانی فرستاده نمی\u200cشود.",
			[UiKey.CheckingForUpdates] = "در حال بررسی به\u200cروزرسانی…",
			[UiKey.UpdateAvailable] = "نسخه\u0654 تازه",
			[UiKey.ViewReleaseAndInstallers] = "صفحه\u0654 انتشار و فایل\u200cهای نصب",
			[UiKey.UpdateNoticeText] = "نسخه\u0654 {0} از Diyar در دسترس است.",
			[UiKey.ViewRelease] = "دیدن صفحه\u0654 انتشار",
			[UiKey.PendingUpdateText] = "نسخه\u0654 {0} در دسترس است. نصب\u200cکننده را از صفحه\u0654 انتشار دریافت و اجرا کنید؛ Diyar خودش آن را دریافت یا نصب نمی\u200cکند.",
			[UiKey.Diagnostics] = "عیب\u200cیابی",
			[UiKey.DebugMode] = "حالت اشکال\u200cزدایی (لاگ فشرده\u0654 عیب\u200cیابی)",
			[UiKey.DebugModeExplanation] = "حالت اشکال\u200cزدایی یک لاگ عیب\u200cیابی روی همین رایانه نگه می\u200cدارد. این لاگ هر واژه\u200cای را که تایپ می\u200cکنید همراه با تصمیم و کاری که Diyar برای آن انجام داد ثبت می\u200cکند، به\u200cعلاوه\u0654 نمونه\u200cهایی از متنی که ویرایشگر پیش از نشانگر نشان می\u200cداد، برنامه، عنوان پنجره و کادری که در آن تایپ کردید، آنچه درباره\u0654 هر ویرایشگر آموخت، تنظیمات فعال، تغییرهای چیدمان صفحه\u200cکلید و وضعیت برنامه پیرامون هر خطا، همراه با خلاصه\u200cای برای هر برنامه در هر 10 دقیقه. تا یک روز کامل نگه داشته می\u200cشود (هشت فایل 8 مگابایتی). لاگ و گزارش\u200cهای ذخیره\u200cشده متن تایپ\u200cشده\u0654 شما، متن ویرایشگر و عنوان پنجره\u200cها را در خود دارند. این\u200cها تا وقتی خودتان آن\u200cها را نفرستید روی همین رایانه می\u200cمانند و فرستادن گزارش، آن\u200cها را هم می\u200cفرستد. حتما\u064b پیش از خاموش کردن، گزارش را ذخیره کنید؛ خاموش کردن، لاگ موقت و سابقه\u0654 اخیر در حافظه را پاک می\u200cکند، ولی گزارش\u200cهای ذخیره\u200cشده می\u200cمانند. تا وقتی روشن است، رمز عبور یا متن خصوصی تایپ نکنید.",
			[UiKey.DebugStatusOn] = "روشن. لاگ در این مسیر نوشته می\u200cشود: {0}",
			[UiKey.DebugStatusOnForThisRun] = "برای این اجرا روشن است، چون {0} تنظیم شده است؛ با همین گزینه خاموش می\u200cشود. لاگ در این مسیر نوشته می\u200cشود: {1}",
			[UiKey.DebugStatusOff] = "خاموش. وقتی روشن باشد، لاگ در این مسیر نوشته می\u200cشود: {0}",
			[UiKey.ReportTypingProblem] = "گزارش مشکل تایپ اخیر",
			[UiKey.ExpectedTextPrompt] = "چه متنی باید تایپ می\u200cشد؟ (اختیاری)",
			[UiKey.TurnDebugOnFirst] = "اول حالت اشکال\u200cزدایی را روشن کنید؛ هنوز سابقه\u200cای برای گزارش وجود ندارد.",
			[UiKey.SaveReport] = "ذخیره\u0654 گزارش",
			[UiKey.NothingSavedDebugOff] = "چیزی ذخیره نشد؛ حالت اشکال\u200cزدایی خاموش است.",
			[UiKey.ReportSaved] = "گزارش در این مسیر ذخیره شد: {0}",
			[UiKey.ReportSavedWithoutExpected] = "گزارش بدون متن مورد انتظار در این مسیر ذخیره شد: {0}",
			[UiKey.OpenLogFolder] = "باز کردن پوشه\u0654 لاگ",
			[UiKey.ClearLog] = "پاک کردن لاگ",
			[UiKey.LogCleared] = "لاگ اشکال\u200cزدایی پاک شد.",
			[UiKey.CrashFolderNote] = "وقتی Diyar به\u200cخاطر یک خطا بسته شود، حتی با حالت اشکال\u200cزدایی خاموش یک گزارش خرابی ذخیره می\u200cکند. گزارش خرابی هیچ متن تایپ\u200cشده، عنوان پنجره یا محتوای کلیپ\u200cبورد ندارد؛ فقط نسخه، ویندوز، حالت تایپ و جای خطا در آن است. برای گزارش یک خرابی، فایل\u200cهای پوشه\u0654 گزارش\u200cهای خرابی را بفرستید.",
			[UiKey.OpenCrashFolder] = "باز کردن پوشه\u0654 گزارش\u200cهای خرابی",
			[UiKey.LastSessionEndedNormally] = "اجرای قبلی در {0} به\u200cطور عادی بسته شد.",
			[UiKey.LastSessionCrashed] = "اجرای قبلی در {0} به\u200cخاطر یک خطا بسته شد؛ گزارش خرابی ذخیره شد.",
			[UiKey.LastSessionEndedWithoutRecord] = "اجرای قبلی در {0} از راه خروج خود Diyar بسته نشد: شاید ویندوز یا برنامه\u0654 دیگری آن را بسته باشد، یا به شکلی از کار افتاده که Diyar نتوانسته ثبتش کند.",
			[UiKey.HandledFaultsThisSession] = "خطاهایی که در این اجرا گرفته شد و Diyar بسته نشد: {0}",
			[UiKey.ClosedUnexpectedly] = "Diyar دفعه\u0654 قبل به\u200cخاطر یک خطا بسته شد. یک گزارش خرابی بدون هیچ متن تایپ\u200cشده\u200cای ذخیره شد؛ لطفا\u064b فایل\u200cهای پوشه\u0654 گزارش\u200cهای خرابی را برای سازندگان بفرستید.",
			[UiKey.ClosedWithoutRecord] = "اجرای قبلی Diyar به\u200cطور عادی تمام نشد. اگر خودبه\u200cخود بسته شد، لطفا\u064b فایل\u200cهای پوشه\u0654 گزارش\u200cهای خرابی را همراه با زمان اتفاق برای سازندگان بفرستید.",
			[UiKey.WindowErrorTypingContinues] = "در پنجره\u0654 Diyar خطایی رخ داد. تایپ ادامه دارد و خطا در پوشه\u0654 گزارش\u200cهای خرابی ذخیره شد.",
			[UiKey.HelpLanguage] = "زبان راهنما",
			[UiKey.HelpButtonName] = "راهنما: {0}",
			[UiKey.OpenFullHelp] = "باز کردن راهنمای کامل",
			[UiKey.HelpIntro] = "راهنمای کامل Diyar. برای رفتن به هر بخش، روی عنوان آن کلیک کنید. در تنظیمات هم کنار هر بخش یک دکمه\u0654 راهنما (؟) هست که همین توضیح را نشان می\u200cدهد.",
			[UiKey.HelpContents] = "فهرست",
			[UiKey.HelpYourShortcuts] = "میان\u200cبرهای شما",
			[UiKey.HelpShortcutsNote] = "این میان\u200cبرها در همه\u0654 برنامه\u200cها کار می\u200cکنند. برای تغییرشان به «تنظیمات › میان\u200cبرها» بروید.",
			[UiKey.HelpSupport] = "پشتیبانی",
			[UiKey.HelpSupportText] = "نسخه\u0654 {0}. برای پرسش، گزارش مشکل یا پیشنهاد، به وب\u200cسایت Diyar سر بزنید.",
			[UiKey.CommandToggleLastWord] = "تبدیل واژه\u0654 آخر",
			[UiKey.CommandUndoLastTranslation] = "بازگردانی آخرین ترجمه",
			[UiKey.CommandConvertSelectedWord] = "تبدیل واژه\u0654 انتخاب\u200cشده",
			[UiKey.CommandAddSelectedWord] = "افزودن واژه\u0654 انتخاب\u200cشده به واژه\u200cنامه\u0654 شخصی",
			[UiKey.CommandTranslateSelectedText] = "ترجمه\u0654 متن انتخاب\u200cشده",
			[UiKey.CommandConvertNonDictionaryWords] = "تبدیل واژه\u200cهای خارج از واژه\u200cنامه",
			[UiKey.CommandUndoManualCorrection] = "بازگردانی آخرین اصلاح دستی",
			[UiKey.CommandTranslateClipboard] = "ترجمه\u0654 متن کلیپ\u200cبورد",
			[UiKey.CommandPauseResume] = "توقف یا ادامه\u0654 تایپ",
			[UiKey.TranslatingPressAgainToCancel] = "در حال ترجمه… برای لغو، {0} را دوباره بزنید.",
			[UiKey.AboutTagline] = "تایپ فارسی با صفحه\u200cکلید انگلیسی",
			[UiKey.AboutDedication] = "توسعه یافته دور از دیار، به یاد دیار.",
			[UiKey.AboutSupportTitle] = "حمایت از ما",
			[UiKey.AboutSupportText] = "اگر از استفاده از این برنامه لذت می\u200cبرید و کار را برای شما آسان کرده است، برای حمایت از ما و ادامه\u0654 توسعه\u0654 رایگان، لطفا\u064b از ما حمایت کنید.",
			[UiKey.AboutSupportLink] = "کمک مالی",
			[UiKey.AboutVersion] = "نسخه",
			[UiKey.AboutReleaseDate] = "تاریخ انتشار",
			[UiKey.AboutPreview] = "این نسخه\u0654 پیش\u200cنمایش برای ارزیابی است. ممکن است ویژگی\u200cها پیش از انتشار نسخه\u0654 پایدار تغییر کنند.",
			[UiKey.AboutCopyright] = "حق نشر © 2026 IranUX. همه\u0654 حقوق محفوظ است.",
			[UiKey.License] = "مجوز",
			[UiKey.LicenseSummary] = "استفاده از این برنامه برای کاربران نهایی، طبق مجوز همراه آن، رایگان است. توزیع دوباره، فروش دوباره، تغییر و استفاده\u0654 تجاری فقط با اجازه\u0654 IranUX ممکن است.",
			[UiKey.ReadLicense] = "خواندن مجوز",
			[UiKey.ThirdPartyNotices] = "مجوزهای اجزای شخص ثالث",
			[UiKey.DocumentMissing] = "این سند در بسته\u0654 برنامه وجود ندارد.",
			[UiKey.TypingMode] = "حالت تایپ",
			[UiKey.ModeAutomaticCorrection] = "اصلاح خودکار",
			[UiKey.ModeAutomaticCorrectionDescription] = "واژه\u200cای که برای صفحه\u200cکلید فارسی تایپ شده باشد، همین که آن را تمام کنید خودبه\u200cخود فارسی می\u200cشود، بی\u200cآنکه کلیدی بزنید؛ واژه\u200cهای انگلیسی انگلیسی می\u200cمانند.",
			[UiKey.ModePersianTypingDirect] = "تایپ مستقیم فارسی",
			[UiKey.ModePersianTypingDirectDescription] = "هر کلید همان لحظه\u200cای که آن را می\u200cزنید حرف فارسی خودش را تایپ می\u200cکند، درست مثل صفحه\u200cکلید فارسی. چیزی از آنچه تایپ کرده\u200cاید خوانده یا جایگزین نمی\u200cشود؛ انگلیسی را با کلید نگه\u200cداشتن تایپ می\u200cکنید.",
			[UiKey.ModeCapsLockSwitch] = "تعویض زبان با Caps Lock",
			[UiKey.ModeCapsLockSwitchDescription] = "Caps Lock زبان صفحه\u200cکلید ویندوز را عوض می\u200cکند، یا فقط تا وقتی روشن است فارسی را مستقیم تایپ می\u200cکند.",
			[UiKey.ModeShiftSwitch] = "تعویض زبان با Shift",
			[UiKey.ModeShiftSwitchDescription] = "تا وقتی Shift را نگه داشته\u200cاید، صفحه\u200cکلید به زبان دیگری که در ویندوز نصب است عوض می\u200cشود.",
			[UiKey.AnotherModeSelected] = "حالت دیگری در «حالت\u200cهای دیگر» انتخاب شده است",
			[UiKey.OtherMode] = "حالت دیگر",
			[UiKey.NotInUse] = "انتخاب نشده",
			[UiKey.OnlyOneModeActive] = "با انتخاب هر حالت، حالت\u200cهای دیگر کنار می\u200cروند؛ هنگام تایپ همیشه فقط یکی فعال است.",
			[UiKey.OtherModes] = "حالت\u200cهای دیگر",
			[UiKey.OtherModesExplanation] = "«تعویض زبان با Caps Lock»: Caps Lock زبان صفحه\u200cکلید ویندوز را عوض می\u200cکند، یا فقط تا وقتی روشن است فارسی را مستقیم تایپ می\u200cکند. «تعویض زبان با Shift»: یکی از دو کلید Shift را نگه دارید تا به زبان دوم ویندوز تایپ کنید.",
			[UiKey.Keyboard] = "صفحه\u200cکلید",
			[UiKey.PersianKeyboardLayout] = "چیدمان صفحه\u200cکلید فارسی",
			[UiKey.DetectInstalledLayout] = "تشخیص چیدمان نصب\u200cشده",
			[UiKey.PersianStandardLayout] = "استاندارد فارسی",
			[UiKey.WindowsPersianLayout] = "فارسی ویندوز",
			[UiKey.KeysTypeAsPersianStandard] = "کلیدهای انگلیسی حروف فارسی را مانند چیدمان «استاندارد فارسی» تایپ می\u200cکنند. این تنظیم در همه\u0654 حالت\u200cهای تایپ، هر جا حرف فارسی تایپ شود یا زبان به فارسی عوض شود، به کار می\u200cرود.",
			[UiKey.KeysTypeAsWindowsPersian] = "کلیدهای انگلیسی حروف فارسی را مانند چیدمان «فارسی ویندوز» تایپ می\u200cکنند. این تنظیم در همه\u0654 حالت\u200cهای تایپ، هر جا حرف فارسی تایپ شود یا زبان به فارسی عوض شود، به کار می\u200cرود.",
			[UiKey.KeysTypeAsEitherLayout] = "کلیدهای انگلیسی حروف فارسی را مانند یکی از دو چیدمان فارسی تایپ می\u200cکنند (هیچ\u200cکدام نصب نیست؛ برای هر واژه نزدیک\u200cترین چیدمان انتخاب می\u200cشود). این تنظیم در همه\u0654 حالت\u200cهای تایپ، هر جا حرف فارسی تایپ شود یا زبان به فارسی عوض شود، به کار می\u200cرود.",
			[UiKey.LayoutsInUse] = "چیدمان انگلیسی ویندوز: {0}؛ چیدمان فارسی ویندوز: {1}.",
			[UiKey.NotInstalled] = "نصب نشده",
			[UiKey.DefaultEnglishLayout] = "چیدمان پیش\u200cفرض انگلیسی",
			[UiKey.DefaultPersianLayout] = "چیدمان پیش\u200cفرض فارسی",
			[UiKey.Automatic] = "خودکار",
			[UiKey.EnglishNotInstalled] = "زبان انگلیسی در ویندوز نصب نیست. «اصلاح خودکار» برای تایپ به یک چیدمان انگلیسی نیاز دارد.",
			[UiKey.PersianNotInstalled] = "زبان فارسی در ویندوز نصب نیست. «اصلاح خودکار» همچنان کار می\u200cکند، ولی تعویض زبان با Caps Lock و Shift برای رفتن به فارسی به آن نیاز دارد.",
			[UiKey.LayoutToInstall] = "چیدمان برای نصب",
			[UiKey.Install] = "نصب",
			[UiKey.LanguageEnglish] = "انگلیسی",
			[UiKey.LanguagePersian] = "فارسی",
			[UiKey.KeyLeftShift] = "Shift چپ",
			[UiKey.KeyRightShift] = "Shift راست",
			[UiKey.KeyLeftCtrl] = "Ctrl چپ",
			[UiKey.KeyRightCtrl] = "Ctrl راست",
			[UiKey.KeyLeftAlt] = "Alt چپ",
			[UiKey.KeyRightAlt] = "Alt راست",
			[UiKey.HoldKey] = "کلید نگه\u200cداشتن",
			[UiKey.HoldKeyForEnglish] = "کلید برای انگلیسی",
			[UiKey.HoldKeyForPersian] = "کلید برای فارسی",
			[UiKey.HoldKeysConflict] = "این کلید را اینجا نمی\u200cتوان انتخاب کرد: یا همان کلید دیگر است، یا سمت دیگر همان کلید (هر دو Shift، هر دو Ctrl یا هر دو Alt). کلید نگه\u200cداشتن دیگر کار همیشگی\u200cاش را نمی\u200cکند، پس با انتخاب هر دو سمت، هیچ Shift، Ctrl یا Alt باقی نمی\u200cماند.",
			[UiKey.TargetLanguage] = "زبان مقصد",
			[UiKey.CapsLockAndHoldKey] = "Caps Lock و کلید نگه\u200cداشتن",
			[UiKey.AutomaticCapsLockRule] = "Caps Lock: اگر Caps Lock کلید نگه\u200cداشتن نباشد، تا وقتی روشن است اصلاح متوقف می\u200cشود و ویندوز حروف بزرگ تایپ می\u200cکند.",
			[UiKey.DirectCapsLockRule] = "Caps Lock: اگر Caps Lock کلید نگه\u200cداشتن نباشد، این حالت را متوقف نمی\u200cکند؛ تا وقتی روشن است هم کلیدها حروف فارسی تایپ می\u200cکنند.",
			[UiKey.CapitalizeEnglishAfterPersian] = "حرف اول انگلیسی بعد از فارسی بزرگ شود",
			[UiKey.HoldKeyYieldsToShortcuts] = "میانبرهای ویندوز از کلید نگه\u200cداشتن استفاده کنند",
			[UiKey.HoldKeyYieldsToShortcutsTip] = "روشن: کلید نگه\u200cداشتنی که همراه Win، Ctrl یا Alt زده شود بخشی از میانبر است، پس Win+Shift+S و Ctrl+Shift+T کار می\u200cکنند. اگر اول کلید نگه\u200cداشتن را بزنید، فقط تا وقتی چیزی با آن تایپ نشده به میانبر می\u200cرسد؛ پس Ctrl+Z وسط کلمه\u200cای که با نگه\u200cداشتن تایپ می\u200cکنید همچنان واگرد است. خاموش: کلید نگه\u200cداشتن هیچ\u200cوقت به ویندوز نمی\u200cرسد.",
			[UiKey.HeldBoundaryEndsEnglishLock] = "کلمه\u0654 انگلیسی با فاصله\u200cای که با کلید نگه\u200cداشتن زده شود تمام شود",
			[UiKey.HeldBoundaryEndsEnglishLockTip] = "روشن: فاصله، Enter یا Tab که وقتی هنوز کلید انگلیسی را نگه داشته\u200cاید زده شود کلمه\u0654 انگلیسی را تمام می\u200cکند؛ پس کلمه\u200cای که پس از رها کردن کلید تایپ می\u200cکنید مثل همیشه اصلاح می\u200cشود (در حالت تایپ مستقیم فارسی، فارسی تایپ می\u200cشود). Backspace، کلیدهای جهت\u200cنما یا میانبری که پس از رها کردن زده شود، کلمه\u0654 نگه\u200cداشته را تا فاصله\u0654 بعدی انگلیسی نگه می\u200cدارد. خاموش: کلمه\u0654 بعدی تا فاصله\u200cاش انگلیسی می\u200cماند، مثل گذشته.",
			[UiKey.CapitalizeEnglishTip] = "وقتی درست بعد از یک کلمه\u0654 فارسی، کلمه\u200cای انگلیسی را با کلید نگه\u200cداشتن تایپ می\u200cکنید، حرف اولش بزرگ تایپ می\u200cشود (فایل Readme). حرفی که با Shift تایپ کنید، کلمه\u200cای که با علامت یا عدد شروع شود و اولین کلمه\u0654 خط همان\u200cطور که تایپ کرده\u200cاید می\u200cمانند. نام\u200cهایی که با حرف کوچک نوشته می\u200cشوند، مثل npm، هم بزرگ می\u200cشوند: Backspace بزنید و حرف را دوباره تایپ کنید.",
			[UiKey.HoldKeyWarning] = "هشدار کلید نگه\u200cداشتن",
			[UiKey.UseItForEnglish] = "استفاده برای انگلیسی",
			[UiKey.UseItForEnglishTip] = "کلید فارسی را، در این حالت و در «اصلاح خودکار»، کلید انگلیسی می\u200cکند",
			[UiKey.NoHoldKeyWarning] = "هیچ کلید نگه\u200cداشتنی تنظیم نشده است، پس در این حالت راهی برای تایپ انگلیسی نیست و باید زبان صفحه\u200cکلید ویندوز را عوض کنید یا Diyar را موقتا\u064b متوقف کنید. یک کلید را در بالا انتخاب کنید؛ Caps Lock پیشنهاد می\u200cشود.",
			[UiKey.HoldKeyTypesPersianWarning] = "تنها کلید نگه\u200cداشتن، کلید فارسی است که در «اصلاح خودکار» انتخاب شده است. این حالت خودش فارسی تایپ می\u200cکند؛ پس اینجا این کلید کاری نمی\u200cکند و نمی\u200cتوان انگلیسی تایپ کرد.",
			[UiKey.HoldKeyForTypingEnglish] = "کلید نگه\u200cداشتن برای تایپ انگلیسی",
			[UiKey.HoldNoteOff] = "خاموش. یک کلید برای انگلیسی، یک کلید برای فارسی یا هر دو را انتخاب کنید: تا وقتی یکی را نگه داشته\u200cاید، آن زبان بدون اصلاح تایپ می\u200cشود. برای یکی از آن\u200cها Caps Lock پیشنهاد می\u200cشود: مانند یک کلید روشن/خاموش کار می\u200cکند و هیچ کلید دیگری کار معمول خود را از دست نمی\u200cدهد.",
			[UiKey.HoldNoteCapsLockPersian] = "تا وقتی Caps Lock روشن است، هر کلید حرف فارسی خودش را تایپ می\u200cکند، مثل صفحه\u200cکلید فارسی. برای برگشت به اصلاح خودکار، Caps Lock را خاموش کنید؛ آنچه تایپ کرده\u200cاید تغییر نمی\u200cکند.",
			[UiKey.HoldNoteKeyPersian] = "تا وقتی {0} را نگه داشته\u200cاید، هر کلید حرف فارسی خودش را تایپ می\u200cکند، مثل صفحه\u200cکلید فارسی. برای برگشت به اصلاح خودکار، آن را رها کنید؛ آنچه تایپ کرده\u200cاید تغییر نمی\u200cکند.",
			[UiKey.HoldNoteCapsLockEnglish] = "تا وقتی Caps Lock روشن است، انگلیسی ساده تایپ می\u200cکنید و چیزی اصلاح نمی\u200cشود. برای برگشت به اصلاح خودکار، Caps Lock را خاموش کنید.",
			[UiKey.HoldNoteKeyEnglish] = "تا وقتی {0} را نگه داشته\u200cاید، انگلیسی ساده تایپ می\u200cکنید و چیزی اصلاح نمی\u200cشود. برای برگشت به اصلاح خودکار، آن را رها کنید.",
			[UiKey.DirectHoldNoteNone] = "در این حالت، انگلیسی را با کلید نگه\u200cداشتن تایپ می\u200cکنید. یک کلید انتخاب کنید؛ Caps Lock پیشنهاد می\u200cشود.",
			[UiKey.DirectHoldNoteCapsLock] = "در این حالت، انگلیسی را این\u200cطور تایپ می\u200cکنید: تا وقتی Caps Lock روشن است، کلیدها انگلیسی ساده تایپ می\u200cکنند (برای حرف بزرگ، Shift را نگه دارید). برای اینکه دوباره فارسی تایپ کنید، Caps Lock را خاموش کنید.",
			[UiKey.DirectHoldNoteKey] = "در این حالت، انگلیسی را این\u200cطور تایپ می\u200cکنید: تا وقتی {0} را نگه داشته\u200cاید، کلیدها انگلیسی ساده تایپ می\u200cکنند. برای اینکه دوباره فارسی تایپ کنید، آن را رها کنید.",
			[UiKey.ModifierKeyNote] = "تا وقتی این کلید تنظیم شده است، هیچ\u200cجا کار معمول خود را انجام نمی\u200cدهد؛ به\u200cجای آن Caps Lock پیشنهاد می\u200cشود، چون هرگز از دسترس ویندوز خارج نمی\u200cشود.",
			[UiKey.PriorityForAmbiguousInput] = "اولویت واژه\u200cهای دوپهلو",
			[UiKey.PriorityNormal] = "عادی (پیشنهادی)",
			[UiKey.PriorityNormalDescription] = "واژه\u200cها همان\u200cطور سنجیده می\u200cشوند که پیش از این تنظیم سنجیده می\u200cشدند: واژه\u0654 فارسی شناخته\u200cشده فارسی می\u200cشود و واژه\u0654 رایج انگلیسی، حتی اگر کلیدهای آن یک واژه\u0654 فارسی هم بسازند، انگلیسی می\u200cماند. تک\u200cحرف و کلید ویرگول از واژه\u0654 پیش از خود پیروی می\u200cکنند.",
			[UiKey.PriorityPersianDescription] = "واژه\u200cای که هم واژه\u0654 انگلیسی شناخته\u200cشده است و هم واژه\u0654 فارسی شناخته\u200cشده، مانند fun (بعد) یا leg (مثل)، فارسی می\u200cشود. تک\u200cحرفی که جدا تایپ شود حرف فارسی خودش می\u200cشود (d می\u200cشود «ی») و کلید ویرگول، هر جای واژه، همان لحظه «و» تایپ می\u200cکند؛ ویرگول فارسی «،» را با {0} تایپ کنید.",
			[UiKey.PriorityEnglishDescription] = "واژه\u200cای که هم واژه\u0654 انگلیسی شناخته\u200cشده است و هم واژه\u0654 فارسی شناخته\u200cشده، مانند fun یا leg، انگلیسی می\u200cماند. تک\u200cحرفی که جدا تایپ شود انگلیسی می\u200cماند و کلید ویرگول، ویرگول انگلیسی تایپ می\u200cکند.",
			[UiKey.PriorityContextual] = "بر پایه\u0654 متن",
			[UiKey.PriorityContextualDescription] = "مانند «عادی»، با یک استثنا: واژه\u200cای که هم واژه\u0654 انگلیسی شناخته\u200cشده است و هم واژه\u0654 رایج فارسی، مانند fun (بعد) یا leg (مثل)، وقتی واژه\u200cهای پیش از آن فارسی باشند فارسی می\u200cشود؛ یعنی پس از دو واژه\u0654 فارسی پشت سر هم، پس از واژه\u0654 فارسی\u200cای مانند «به» یا «برای»، یا در پیامی که هنوز هیچ واژه\u0654 انگلیسی ندارد. پس از یک واژه\u0654 انگلیسی، به\u200cعنوان نخستین واژه، و برای رایج\u200cترین واژه\u200cهای انگلیسی مانند and، how یا do، انگلیسی می\u200cماند. تک\u200cحرف و کلید ویرگول مانند «عادی» رفتار می\u200cکنند.",
			[UiKey.PriorityScope] = "گزینه\u200cهای «بر پایه\u0654 متن»، «فارسی» و «انگلیسی» فقط درباره\u0654 واژه\u200cهایی که هر دو زبان می\u200cشناسند تصمیم می\u200cگیرند؛ «فارسی» و «انگلیسی» درباره\u0654 تک\u200cحرف\u200cها و کلید ویرگول هم تصمیم می\u200cگیرند. واژه\u200cهایی که فقط یک زبان می\u200cشناسد، واژه\u200cهای ناشناخته، کادرهای محافظت\u200cشده و اصطلاحات فنی در هر چهار گزینه یکسان پردازش می\u200cشوند.",
			[UiKey.WordForms] = "شکل\u200cهای واژه\u0654 فارسی",
			[UiKey.WordFormsChoice] = "شناختن واژه\u200cهای فارسی پسونددار",
			[UiKey.WordFormsTip] = "اینکه واژه\u0654 فارسی شناخته\u200cشده\u200cای که پسوند گرفته است، مانند درخت\u200cها، شناخته شود یا نه",
			[UiKey.WordFormsFull] = "واژه\u200cهای پسونددار (پیشنهادی)",
			[UiKey.WordFormsFullDescription] = "واژه\u0654 فارسی شناخته\u200cشده\u200cای که پسوندهایی دارد که در واژه\u200cنامه نیامده\u200cاند، در کنار متن فارسی به فارسی تبدیل می\u200cشود: درخت\u200cها، درختهاش، اطلاعاتی. واژه\u200cای که پس از «می» بدون نیم\u200cفاصله تایپ شود هم شمرده می\u200cشود (میرسیم). کلیدهایی که یک واژه\u0654 انگلیسی می\u200cسازند انگلیسی می\u200cمانند، واژه\u0654 پسونددار اگر کلیدهایش غلط تایپی یک واژه\u0654 انگلیسی باشد هم انگلیسی می\u200cماند و درون متن انگلیسی چیزی تغییر نمی\u200cکند. پسوندهای جدا مانند «ها» و «رو» پس از یک واژه\u0654 انگلیسی هم تبدیل می\u200cشوند: Button ها رو.",
			[UiKey.WordFormsEnclitics] = "فقط پسوندهای جدا",
			[UiKey.WordFormsEncliticsDescription] = "فقط پسوندهای جدا، مانند «ها» و «رو»، پس از یک واژه\u0654 انگلیسی تبدیل می\u200cشوند: Button ih به Button ها تبدیل می\u200cشود. درباره\u0654 واژه\u0654 پسونددار مانند گذشته تصمیم گرفته می\u200cشود.",
			[UiKey.WordFormsOffDescription] = "درباره\u0654 واژه\u200cهای پسونددار و پسوندهای جدا دقیقا\u064b مانند پیش از وجود این تنظیم تصمیم گرفته می\u200cشود.",
			[UiKey.KeyboardLayoutGroup] = "چیدمان صفحه\u200cکلید",
			[UiKey.StartNewWordAfterLayoutSwitch] = "شروع واژه\u0654 تازه پس از تغییر چیدمان صفحه\u200cکلید",
			[UiKey.StartNewWordAfterLayoutSwitchTip] = "روشن: تغییر چیدمان صفحه\u200cکلید ویندوز با Alt+Shift، Win+Space یا نوار زبان، واژه\u200cای را که در حال تایپ است به پایان می\u200cرساند، پس چیزی که پیش از تغییر تایپ شده جایگزین نمی\u200cشود. خاموش: کلیدهایی که با هر دو چیدمان تایپ شده\u200cاند یک واژه شمرده می\u200cشوند، مانند نسخه\u200cهای قبلی.",
			[UiKey.LayoutSwitchNote] = "اگر در میانه\u0654 یک واژه چیدمان صفحه\u200cکلید ویندوز را تغییر دهید، حرف\u200cهایی که پیش از تغییر تایپ شده\u200cاند همان\u200cطور می\u200cمانند و واژه فقط از جای تغییر به بعد سنجیده می\u200cشود. چیدمان\u200cهایی که خود Diyar تغییر می\u200cدهد شامل این قاعده نمی\u200cشوند.",
			[UiKey.CorrectionBehavior] = "رفتار اصلاح",
			[UiKey.DirectTypingCardText] = "هر کلید همان لحظه\u200cای که آن را می\u200cزنید حرف فارسی خودش را تایپ می\u200cکند، مثل صفحه\u200cکلید فارسی؛ با Shift حرف دوم کلید تایپ می\u200cشود، مانند «آ» یا «ژ». با Shift، کلیدهای نشانه همان نشانه\u200cای را تایپ می\u200cکنند که صفحه\u200cکلید فارسی ویندوز می\u200cدهد: حرکت\u200cها و تنوین، ٪، ×، ریال، ویرگول فارسی، گیومه و کروشه\u200cها. چیزی از آنچه تایپ کرده\u200cاید خوانده یا جایگزین نمی\u200cشود، Backspace یک حرف را پاک می\u200cکند و رقم\u200cها و دیگر نشانه\u200cها همان\u200cطور که تایپ شده\u200cاند می\u200cمانند. هیچ واژه\u200cنامه\u200cای به کار نمی\u200cرود، پس حرف بزرگ واژه را انگلیسی نگه نمی\u200cدارد؛ انگلیسی را با «کلید نگه\u200cداشتن» در پایین تایپ کنید.",
			[UiKey.AutomaticCorrectionCardText] = "واژه\u200cهای فارسی شناخته\u200cشده و واژه\u200cهایی که از کلیدهای آن\u200cها فقط واژه\u200cای فارسی درمی\u200cآید، هنگام تایپ فارسی می\u200cشوند. واژه\u200cهای انگلیسی، واژه\u200cهای ناشناخته، واژه\u200cهایی که با حرف بزرگ شروع می\u200cشوند، نشانی\u200cها، عددها و اصطلاحات فنی همان\u200cطور که تایپ شده\u200cاند می\u200cمانند. اگر درست پس از واژه\u0654 تبدیل\u200cشده «تبدیل واژه\u0654 آخر» (Ctrl+Alt+Space) را بزنید، واژه به همان کلیدهایی که زده\u200cاید برمی\u200cگردد.",
			[UiKey.Spelling] = "املا",
			[UiKey.CorrectPersianTypos] = "اصلاح غلط\u200cهای املایی فارسی در صورت اطمینان",
			[UiKey.KeysThatFinishAWord] = "کلیدهای پایان واژه",
			[UiKey.KeysThatFinishAWordNote] = "با زدن هر کدام از این کلیدها واژه بررسی می\u200cشود. این\u200cها جایگزین هم نیستند؛ هر کلیدی را که با آن واژه را تمام می\u200cکنید روشن کنید. نشانه\u200cهایی مانند {0} همیشه واژه را تمام می\u200cکنند.",
			[UiKey.SpaceKey] = "فاصله",
			[UiKey.AtLeastOneFinishingKey] = "دست\u200cکم یک کلید باید واژه را تمام کند. پیش از خاموش کردن این کلید، کلید دیگری را روشن کنید.",
			[UiKey.WhenCapsLockIsOn] = "وقتی Caps Lock روشن است",
			[UiKey.CapsLockSwitchLanguage] = "تعویض زبان ویندوز",
			[UiKey.CapsLockDirectWhileOn] = "تایپ مستقیم فارسی تا وقتی روشن است",
			[UiKey.CapsLockManualWhileOn] = "تایپ دستی تا وقتی روشن است",
			[UiKey.CapsLockAutomaticWhileOnLegacy] = "اصلاح خودکار تا وقتی روشن است (قدیمی)",
			[UiKey.CapsLockAutomaticDescription] = "تا وقتی Caps Lock روشن است، Diyar هنگام تایپ اصلاح می\u200cکند، درست مثل حالت «اصلاح خودکار». اگر زبان صفحه\u200cکلید ویندوز فارسی باشد، خودبه\u200cخود به انگلیسی عوض می\u200cشود و با خاموش شدن Caps Lock زبان قبلی برمی\u200cگردد. حروف به\u200cصورت عادی تایپ می\u200cشوند؛ برای حرف بزرگ، Shift را نگه دارید. این گزینه برای حفظ تنظیمات شما مانده است ولی دیگر پیشنهاد نمی\u200cشود؛ اگر گزینه\u0654 دیگری انتخاب کنید، از فهرست حذف می\u200cشود.",
			[UiKey.CapsLockDirectDescription] = "تا وقتی Caps Lock روشن است، هر کلید همان لحظه حرف فارسی خودش را تایپ می\u200cکند، درست مثل «تایپ مستقیم فارسی»: چیزی خوانده یا جایگزین نمی\u200cشود، با Shift حرف دوم کلید تایپ می\u200cشود («آ»، «ژ») و Backspace یک حرف را پاک می\u200cکند. اگر زبان صفحه\u200cکلید ویندوز فارسی باشد، خودبه\u200cخود به انگلیسی عوض می\u200cشود و با خاموش شدن Caps Lock زبان قبلی برمی\u200cگردد.",
			[UiKey.CapsLockManualDescription] = "تا وقتی Caps Lock روشن است، کلیدهای انگلیسی تایپ می\u200cشوند و هر واژه پس از تمام شدن با فارسی جایگزین می\u200cشود؛ واژه\u200cای که با حرف بزرگ شروع شود (با نگه\u200cداشتن Shift) انگلیسی می\u200cماند. این رفتار قبلی برنامه است؛ چون تایپ مستقیم در فایل تنظیمات این نمایه خاموش است، همین رفتار به کار می\u200cرود. اگر زبان صفحه\u200cکلید ویندوز فارسی باشد، خودبه\u200cخود به انگلیسی عوض می\u200cشود و با خاموش شدن Caps Lock زبان قبلی برمی\u200cگردد.",
			[UiKey.CapsLockSwitchDescription] = "در این حالت، Caps Lock فقط زبان صفحه\u200cکلید ویندوز را عوض می\u200cکند: با روشن کردن آن، زبانی که پایین\u200cتر انتخاب کرده\u200cاید فعال می\u200cشود و با خاموش کردن آن، زبان دیگر. چیزی اصلاح یا تبدیل نمی\u200cشود. هر دو زبان باید از قبل در ویندوز نصب باشند.",
			[UiKey.WindowsLanguageWhileCapsLockOn] = "زبان ویندوز وقتی Caps Lock روشن است",
			[UiKey.EnglishLetterCase] = "نوع حروف انگلیسی",
			[UiKey.NormalLetterCase] = "حروف عادی",
			[UiKey.CapitalLetters] = "حروف بزرگ",
			[UiKey.LanguageGroup] = "زبان",
			[UiKey.CapsLockSwitchNoDirection] = "در این حالت ویندوز خودش تایپ می\u200cکند، پس Diyar به متن دست نمی\u200cزند و نمی\u200cتواند جهت آن را پایدار نگه دارد یا مبلغ\u200cها را قالب\u200cبندی کند. برای پایدار نگه\u200cداشتن جهت، در بالا «تایپ مستقیم فارسی تا وقتی روشن است» را انتخاب کنید؛ مبلغ\u200cها فقط در «اصلاح خودکار» قالب\u200cبندی می\u200cشوند.",
			[UiKey.SwitchKey] = "کلید تعویض",
			[UiKey.SwitchKeyLeftShift] = "Shift چپ (Shift راست برای نویسه\u200cهای ویژه)",
			[UiKey.SwitchKeyRightShift] = "Shift راست (Shift چپ برای نویسه\u200cهای ویژه)",
			[UiKey.ShiftSwitchTarget] = "زبان هنگام نگه\u200cداشتن کلید تعویض",
			[UiKey.ShiftSwitchExplanation] = "تا وقتی کلید تعویض را نگه داشته\u200cاید، زبان صفحه\u200cکلید ویرایشگر فعال به زبانی که در بالا انتخاب کرده\u200cاید عوض می\u200cشود و با رها کردن آن، زبان دیگر برمی\u200cگردد. این کار زبان واقعی صفحه\u200cکلید ویندوز را عوض می\u200cکند؛ تا وقتی این حالت انتخاب شده است، Diyar چیزی را اصلاح یا تبدیل نمی\u200cکند.",
			[UiKey.ShiftSwitchShiftedCharacters] = "هنگام نگه\u200cداشتن کلید تعویض، برای نویسه\u200cهای ویژه کلید Shift دیگر را هم نگه دارید: حروف بزرگ، نشانه\u200cهای انگلیسی مانند {0} یا حروف ویژه\u0654 فارسی مانند «آ» و «ژ». Caps Lock روی حروف انگلیسی همان اثر همیشگی را دارد. با کلید فاصله، نیم\u200cفاصله تایپ می\u200cشود.",
			[UiKey.TextDirection] = "جهت متن",
			[UiKey.TextDirectionAndAmounts] = "جهت متن و مبلغ\u200cها",
			[UiKey.StabilizeMixedText] = "پایدار نگه\u200cداشتن متن ترکیبی فارسی و انگلیسی",
			[UiKey.FormatCurrencyAmounts] = "قالب\u200cبندی مبلغ\u200cهای تومان و ریال",
			[UiKey.NoAmountsNote] = "وقتی فارسی و انگلیسی در یک سطر می\u200cآیند، ترتیب واژه\u200cها و نشانه\u200cها را پایدار نگه می\u200cدارد. قالب\u200cبندی مبلغ اینجا ارائه نمی\u200cشود، چون بخشی از تبدیل واژه است و در این حالت چیزی تبدیل نمی\u200cشود.",
			[UiKey.DirectTypingAmountNote] = "وقتی فارسی و انگلیسی در یک سطر می\u200cآیند، ترتیب واژه\u200cها و نشانه\u200cها را پایدار نگه می\u200cدارد. قالب\u200cبندی مبلغ اینجا ارائه نمی\u200cشود: فقط وقتی انجام می\u200cشود که «اصلاح خودکار» واژه\u200cای مانند «تومان» یا «ریال» را که با کلیدهای انگلیسی تایپ شده است تبدیل کند، و در این حالت هر کلید همان لحظه حرف خودش را تایپ می\u200cکند.",
			[UiKey.Numbers] = "عددها",
			[UiKey.PersianDigitsInPersianText] = "رقم\u200cهای فارسی در متن فارسی",
			[UiKey.PersianDigitsTip] = "اینکه عددی تا شش رقم که پس از متن فارسی تایپ می\u200cشود، با پایان یافتن، به رقم\u200cهای فارسی مانند ۳ یا ۱۵۰ تبدیل شود یا نه",
			[UiKey.PersianDigitsNote] = "به\u200cطور پیش\u200cفرض خاموش است. وقتی روشن باشد، عددی که با فاصله، {0} یا {1} تمام می\u200cکنید، در صورتی که واژه\u0654 پیش از آن فارسی باشد (یا در اولویت فارسی، اگر پس از متن انگلیسی نیامده باشد) به رقم\u200cهای صفحه\u200cکلید فارسی شما تبدیل می\u200cشود. یک ممیز، یا ویرگولی که سه رقم دقیقا\u064b پس از آن بیاید، به جداکننده\u0654 فارسی تبدیل می\u200cشود و {2} به ۳٫۵ در می\u200cآید. عددی که با صفر شروع شود، بیش از شش رقم داشته باشد، ویرگولش با سه رقم دقیقا\u064b دنبال نشود، بیش از یک جداکننده داشته باشد، یا ساعت، تاریخ، نشانی و نسخه باشد، و هرچه در صفحه\u200cگسترده، ویرایشگر کد و ترمینال تایپ شود، همان\u200cگونه که تایپ شده می\u200cماند. صفحه\u200cکلید فارسی ویندوز رقم\u200cهای لاتین تایپ می\u200cکند و در آن چیزی تغییر نمی\u200cکند.",
			[UiKey.TranslationService] = "سرویس ترجمه",
			[UiKey.OnDeviceModel] = "مدل روی دستگاه",
			[UiKey.EnableTranslationShortcut] = "فعال بودن میان\u200cبر ترجمه",
			[UiKey.TranslatedText] = "متن ترجمه\u200cشده",
			[UiKey.MatchParagraphDirection] = "هم\u200cجهت کردن بند با زبان مقصد",
			[UiKey.AllowUndoTranslation] = "امکان بازگردانی با میان\u200cبر «بازگردانی آخرین ترجمه»",
			[UiKey.TranslationTargetTip] = "«خودکار» متنی را که بیشتر فارسی یا عربی است به انگلیسی و هر متن دیگری را به فارسی ترجمه می\u200cکند. اگر زبان مشخصی انتخاب کنید، همه\u0654 متن\u200cها به همان زبان ترجمه می\u200cشوند.",
			[UiKey.TranslationShortcutsNote] = "«خودکار (فارسی ↔ انگلیسی)» هر متن انتخاب\u200cشده را می\u200cخواند: متنی که بیشتر به خط فارسی یا عربی است به انگلیسی و هر متن دیگری به فارسی ترجمه می\u200cشود. {0} متن انتخاب\u200cشده را در همان جا ترجمه می\u200cکند؛ {1} متن کلیپ\u200cبورد را ترجمه می\u200cکند و ترجمه را دوباره در کلیپ\u200cبورد می\u200cگذارد و به متن شما دست نمی\u200cزند. اگر هنگام انجام ترجمه یکی از این دو را دوباره بزنید، ترجمه لغو می\u200cشود.",
			[UiKey.AllowClipboardFallback] = "استفاده از کلیپ\u200cبورد جایی که ویرایشگر خواندنی نیست",
			[UiKey.AllowClipboardFallbackTip] = "فقط جایی که متن انتخاب\u200cشده را نمی\u200cتوان مستقیم خواند یا نوشت. این رونوشت به تاریخچه\u0654 کلیپ\u200cبورد و همگام\u200cسازی ابری نمی\u200cرود و متن قبلی کلیپ\u200cبورد دوباره سر جایش گذاشته می\u200cشود. خاموش: چنین متن\u200cهایی پذیرفته نمی\u200cشوند و به کلیپ\u200cبورد هرگز دست زده نمی\u200cشود.",
			[UiKey.CancelDownload] = "لغو دریافت",
			[UiKey.CancelDownloadTip] = "دریافت در حال انجام را متوقف می\u200cکند. تا وقتی دریافتی کامل نشود، مدل راه\u200cاندازی نمی\u200cشود.",
			[UiKey.WarmUpLocalModel] = "بارگذاری مدل هنگام شروع Diyar",
			[UiKey.WarmUpLocalModelTip] = "مدل دریافت\u200cشده را پس از شروع برنامه، یا وقتی این گزینه روشن شود، یک بار در پس\u200cزمینه بارگذاری می\u200cکند تا نخستین ترجمه منتظر آن نماند. سپس تا وقتی Diyar در حال اجراست، مدل در حافظه می\u200cماند. خاموش: مدل هنگام نخستین ترجمه بارگذاری می\u200cشود.",
			[UiKey.WarmUpLocalModelNote] = "حالت خاموش، که پیش\u200cفرض است، مدل را تا نخستین ترجمه بارگذاری نمی\u200cکند؛ پس آن ترجمه بیشتر طول می\u200cکشد.",
			[UiKey.ModelDownloadCancelled] = "دریافت مدل لغو شد. هر وقت آماده بودید، دوباره آن را دریافت کنید.",
			[UiKey.ApiKey] = "کلید API",
			[UiKey.AzureApiKey] = "کلید API سرویس Azure",
			[UiKey.ResourceRegion] = "ناحیه\u0654 منبع (Region)",
			[UiKey.KeyStoredSecurely] = "یک کلید به\u200cصورت امن برای این حساب ویندوز ذخیره شده است.",
			[UiKey.NoApiKeySaved] = "هیچ کلید API ذخیره نشده است.",
			[UiKey.SaveConnection] = "ذخیره\u0654 اتصال",
			[UiKey.KeyCouldNotBeStored] = "کلید ذخیره نشد و هیچ تغییری اعمال نشد.",
			[UiKey.EnterAzureKeyFirst] = "اول کلید Azure Translator خود را وارد کنید.",
			[UiKey.ConnectionSaved] = "اتصال ذخیره شد. پیش از ترجمه، آن را آزمایش کنید.",
			[UiKey.TestConnection] = "آزمایش اتصال",
			[UiKey.SaveBeforeTesting] = "پیش از آزمایش اتصال، تغییرهای خود را ذخیره کنید.",
			[UiKey.TestingConnection] = "در حال آزمایش اتصال…",
			[UiKey.RemoveSavedKey] = "حذف کلید ذخیره\u200cشده",
			[UiKey.RemoveSavedKeyQuestion] = "کلید ذخیره\u200cشده حذف شود؟",
			[UiKey.RemoveSavedKeyBody] = "تا وقتی کلید دیگری ذخیره نکنید، ترجمه با Azure در دسترس نخواهد بود.",
			[UiKey.Remove] = "حذف",
			[UiKey.SavedKeyRemoved] = "کلید ذخیره\u200cشده حذف شد.",
			[UiKey.AzureConnection] = "اتصال Azure",
			[UiKey.SetupHelp] = "راهنمای راه\u200cاندازی",
			[UiKey.AzureSendsOnlySelected] = "فقط متنی که خودتان برای ترجمه انتخاب می\u200cکنید به Microsoft Azure فرستاده می\u200cشود.",
			[UiKey.AzureSetupTitle] = "راه\u200cاندازی Azure Translator",
			[UiKey.AzureSetupStep1] = "1. در حساب Microsoft Azure خودتان یک منبع Translator بسازید.",
			[UiKey.AzureSetupStep2] = "2. بخش {0} را باز کنید و {1} یا {2} را در «کلید API» کپی کنید.",
			[UiKey.AzureSetupStep3] = "3. مقدار {0} را در «ناحیه\u0654 منبع» کپی کنید؛ مثلا\u064b {1}. برای منبع سراسری Translator، {2} را بنویسید.",
			[UiKey.AzureSetupStep4] = "4. اتصال را ذخیره کنید و سپس «آزمایش اتصال» را بزنید.",
			[UiKey.AzureSetupCosts] = "Azure به اینترنت نیاز دارد. طرح، سهمیه و هزینه\u200cهای حساب خودتان اعمال می\u200cشود. اشتراک Azure همراه Diyar نیست.",
			[UiKey.TranslatorSetupDocs] = "مستندات راه\u200cاندازی Microsoft Translator",
			[UiKey.OpenAzurePortal] = "باز کردن پورتال Azure",
			[UiKey.OnDeviceTranslation] = "ترجمه روی دستگاه",
			[UiKey.FirstDownloadNeedsInternet] = "نخستین دریافت مدل به اینترنت نیاز دارد. پس از آن، ترجمه روی همین دستگاه انجام می\u200cشود.",
			[UiKey.CheckModel] = "بررسی مدل",
			[UiKey.DownloadModel] = "دریافت مدل",
			[UiKey.TypingFont] = "قلم تایپ",
			[UiKey.NoSupportedAppDetected] = "هیچ برنامه\u0654 پشتیبانی\u200cشده\u200cای روی این رایانه پیدا نشد.",
			[UiKey.FontAppsSummary] = "از {1} برنامه\u0654 پیداشده، {0} برنامه قابل تغییر است · {2} برنامه\u0654 پشتیبانی\u200cشده روی این رایانه نصب نیست",
			[UiKey.SelectAtLeastOneApp] = "دست\u200cکم یک برنامه\u0654 پشتیبانی\u200cشده را انتخاب کنید.",
			[UiKey.RestorePreviousFontsQuestion] = "قلم\u200cهای قبلی بازگردانده شوند؟",
			[UiKey.ApplyFontQuestion] = "قلم روی برنامه\u200cهای انتخاب\u200cشده اعمال شود؟",
			[UiKey.Restore] = "بازگرداندن",
			[UiKey.Apply] = "اعمال",
			[UiKey.NoApplicationChanged] = "هیچ برنامه\u200cای تغییر نکرد.",
			[UiKey.SomeApplicationsChanged] = "از {1} برنامه، {0} برنامه تغییر کرد.",
			[UiKey.ApplicationDefaults] = "قلم پیش\u200cفرض برنامه\u200cها",
			[UiKey.RefreshApplications] = "به\u200cروزرسانی فهرست برنامه\u200cها",
			[UiKey.SelectSupported] = "انتخاب برنامه\u200cهای پشتیبانی\u200cشده",
			[UiKey.ApplyFont] = "اعمال قلم",
			[UiKey.RestorePrevious] = "بازگرداندن تنظیم قبلی",
			[UiKey.KeyboardShortcuts] = "میان\u200cبرهای صفحه\u200cکلید",
			[UiKey.ChangeShortcutName] = "تغییر میان\u200cبر: {0}",
			[UiKey.ShortcutsHandledInApps] = "«تبدیل واژه\u0654 انتخاب\u200cشده»، «تبدیل واژه\u0654 آخر» و «بازگردانی آخرین اصلاح دستی» درون برنامه\u200cای که در آن تایپ می\u200cکنید اجرا می\u200cشوند و در ویندوز ثبت نمی\u200cشوند. «افزودن واژه\u0654 انتخاب\u200cشده» روی واژه\u200cای که انتخاب کرده\u200cاید کار می\u200cکند و هرگز متن شما را ویرایش نمی\u200cکند. «ترجمه\u0654 متن انتخاب\u200cشده»، «ترجمه\u0654 متن کلیپ\u200cبورد» و «بازگردانی آخرین ترجمه» وقتی کار می\u200cکنند که ترجمه روشن باشد. «ترجمه\u0654 متن کلیپ\u200cبورد» متن کلیپ\u200cبورد را ترجمه می\u200cکند و ترجمه را دوباره در کلیپ\u200cبورد می\u200cگذارد و به متنی که در حال ویرایش آن هستید دست نمی\u200cزند. اگر هنگام انجام ترجمه میان\u200cبر ترجمه را دوباره بزنید، ترجمه لغو می\u200cشود.",
			[UiKey.ConvertSelectedWordExplanation] = "یک واژه را انتخاب کنید و میان\u200cبر «تبدیل واژه\u0654 انتخاب\u200cشده» را بزنید: متنی که با حروف لاتین تایپ شده است فارسی می\u200cشود و متن فارسی به همان کلیدهای لاتینی برمی\u200cگردد که آن را می\u200cسازند. اگر میان\u200cبر را دوباره روی نتیجه\u0654 دست\u200cنخورده بزنید، دقیقا\u064b متن اصلی برمی\u200cگردد. «بازگردانی آخرین اصلاح دستی» همان واژه\u200cای را که تبدیل کرده\u200cاید دقیقا\u064b برمی\u200cگرداند، به شرط آنکه از آن پس چیزی آنجا تایپ یا تغییر داده نشده باشد.",
			[UiKey.TextServiceNotInstalled] = "نصب نشده است: این میان\u200cبرها به سرویس متن Diyar نیاز دارند که برای حساب شما ثبت نشده است (Diyar را با نصب\u200cکننده\u0654 آن نصب کنید). تا آن زمان چیزی تغییر نمی\u200cکند.",
			[UiKey.TextServiceWorks] = "در هر برنامه\u200cای که به Diyar امکان ویرایش متن بدهد کار می\u200cکند. کادرهای رمز عبور و فقط\u200cخواندنی و متنی که هنوز در حال ترکیب است پذیرفته نمی\u200cشوند و هر تغییر پیش از آنکه به حساب بیاید، از ویرایشگر بازخوانده می\u200cشود.",
			[UiKey.SaveSelectedWordCorrections] = "ذخیره\u0654 تبدیل\u200cهای موفق واژه\u0654 انتخاب\u200cشده در واژه\u200cنامه\u0654 شخصی من",
			[UiKey.WhenOffNoWordAdded] = "وقتی این گزینه خاموش است، تبدیل هیچ واژه\u200cای اضافه نمی\u200cکند و پیشنهادی برای بازبینی نمی\u200cسازد.",
			[UiKey.EnableToggleLastWord] = "فعال بودن «تبدیل واژه\u0654 آخر»",
			[UiKey.SaveLastWordCorrections] = "ذخیره\u0654 تبدیل\u200cهای موفق واژه\u0654 آخر در واژه\u200cنامه\u0654 شخصی من",
			[UiKey.ToggleLastWordExplanation] = "درست پس از یک واژه، با یا بدون فاصله\u0654 پس از آن، {0} را بزنید: متنی که با حروف لاتین تایپ شده است فارسی می\u200cشود و متن فارسی به کلیدهای لاتین برمی\u200cگردد. اگر پیش از تایپ هر چیز دیگری دوباره آن را بزنید، دقیقا\u064b متن اصلی برمی\u200cگردد. «بازگردانی آخرین اصلاح دستی» هم آن را برمی\u200cگرداند.",
			[UiKey.NonDictionaryWordsUnavailable] = "«تبدیل واژه\u200cهای خارج از واژه\u200cنامه» در این نسخه اجرا نمی\u200cشود، پس میان\u200cبری ندارد.",
			[UiKey.NewShortcut] = "میان\u200cبر تازه",
			[UiKey.PressKeyCombination] = "یک ترکیب کلید بزنید",
			[UiKey.SaveShortcut] = "ذخیره\u0654 میان\u200cبر",
			[UiKey.RecorderInstructions] = "کلید Ctrl یا Alt را همراه با یک کلید دیگر بزنید. برای لغو بدون تغییر میان\u200cبر، Escape را بزنید.",
			[UiKey.CurrentShortcut] = "میان\u200cبر فعلی: {0}",
			[UiKey.NoWindowsKey] = "میان\u200cبری بدون کلید Windows انتخاب کنید تا با میان\u200cبرهای سیستم تداخل نداشته باشد.",
			[UiKey.ShortcutInUse] = "فرمان دیگری از این میان\u200cبر استفاده می\u200cکند.",
			[UiKey.ShortcutSaved] = "میان\u200cبر ذخیره شد.",
			[UiKey.DictionaryViews] = "بخش\u200cهای واژه\u200cنامه",
			[UiKey.PersonalDictionary] = "واژه\u200cنامه\u0654 شخصی",
			[UiKey.BuiltInDictionary] = "واژه\u200cنامه\u0654 پایه",
			[UiKey.WordReviewQueue] = "صف بازبینی واژه\u200cها",
			[UiKey.SearchWordReviewQueue] = "جست\u200cوجو در صف بازبینی واژه\u200cها",
			[UiKey.SearchBuiltInDictionary] = "جست\u200cوجو در واژه\u200cنامه\u0654 پایه",
			[UiKey.SearchPersonalDictionary] = "جست\u200cوجو در واژه\u200cنامه\u0654 شخصی شما",
			[UiKey.SearchDictionary] = "جست\u200cوجوی واژه\u200cنامه",
			[UiKey.AllLanguages] = "همه\u0654 زبان\u200cها",
			[UiKey.FilterDictionaryLanguage] = "فیلتر زبان واژه\u200cنامه",
			[UiKey.AutoAddConfirmedCorrections] = "افزودن خودکار اصلاح\u200cهای تأییدشده به واژه\u200cنامه\u0654 شخصی",
			[UiKey.PersonalDictionaryWords] = "واژه\u200cهای واژه\u200cنامه\u0654 شخصی",
			[UiKey.BuiltInDictionaryWords] = "واژه\u200cهای واژه\u200cنامه\u0654 پایه",
			[UiKey.ColumnProposedWord] = "واژه\u0654 پیشنهادی",
			[UiKey.ColumnTypedAs] = "شکل تایپ\u200cشده",
			[UiKey.ColumnAwaitingReview] = "در انتظار بازبینی",
			[UiKey.ColumnDictionary] = "واژه\u200cنامه",
			[UiKey.ColumnStatus] = "وضعیت",
			[UiKey.ColumnStatusConversion] = "وضعیت · تبدیل",
			[UiKey.Word] = "واژه",
			[UiKey.WordLanguage] = "زبان",
			[UiKey.NoWordsAwaitingReview] = "صف بازبینی واژه\u200cها خالی است",
			[UiKey.NoMatchingWords] = "واژه\u200cای پیدا نشد",
			[UiKey.PreviousPage] = "صفحه\u0654 قبل",
			[UiKey.NextPage] = "صفحه\u0654 بعد",
			[UiKey.AddWords] = "افزودن واژه\u200cها",
			[UiKey.Import] = "وارد کردن",
			[UiKey.Export] = "صادر کردن",
			[UiKey.NoPersonalWordsToExport] = "واژه\u0654 شخصی\u200cای برای صادر کردن وجود ندارد. فقط واژه\u200cهای شخصی صادر می\u200cشوند، نه واژه\u200cنامه\u0654 پایه.",
			[UiKey.PersonalDictionaryFileType] = "واژه\u200cنامه\u0654 شخصی",
			[UiKey.ExportedPersonalWords] = "{0} واژه\u0654 شخصی صادر شد.",
			[UiKey.AcceptSelected] = "پذیرفتن انتخاب\u200cشده\u200cها",
			[UiKey.AcceptAll] = "پذیرفتن همه",
			[UiKey.AcceptAllQuestion] = "همه\u0654 واژه\u200cهای پیشنهادی پذیرفته شوند؟",
			[UiKey.AcceptAllBody] = "{0} واژه\u0654 پیشنهادی به واژه\u200cنامه\u0654 شخصی شما افزوده شود؟ واژه\u200cهایی که از پیش در یکی از دو واژه\u200cنامه هستند، کنار گذاشته می\u200cشوند.",
			[UiKey.RetryKeepingCopy] = "تلاش دوباره برای پشتیبان\u200cگیری",
			[UiKey.CopyKept] = "از فایلی که خوانده نمی\u200cشد نسخه\u0654 پشتیبان گرفته شد. اکنون می\u200cتوان تغییرها را دوباره ذخیره کرد.",
			[UiKey.SelectPage] = "انتخاب این صفحه",
			[UiKey.ClearSelection] = "لغو انتخاب",
			[UiKey.DictionaryHelp] = "راهنمای واژه\u200cنامه",
			[UiKey.Edit] = "ویرایش",
			[UiKey.EditPersonalWord] = "ویرایش واژه\u0654 شخصی",
			[UiKey.NeutralOlderEntry] = "خنثی (مدخل قدیمی)",
			[UiKey.Category] = "دسته",
			[UiKey.CategoryGeneral] = "عمومی",
			[UiKey.CategoryTechnical] = "فنی",
			[UiKey.CategoryName] = "نام خاص",
			[UiKey.CategoryAcronym] = "سرواژه",
			[UiKey.CategoryCommand] = "فرمان",
			[UiKey.CategoryCurrency] = "واحد پول",
			[UiKey.ProtectFromAutomaticConversion] = "محافظت در برابر تبدیل خودکار",
			[UiKey.EntryEnabled] = "فعال",
			[UiKey.WordSaved] = "واژه ذخیره شد.",
			[UiKey.WordNotSaved] = "واژه خالی است، یک واژه\u0654 تنها نیست یا از پیش در واژه\u200cنامه\u0654 این زبان وجود دارد.",
			[UiKey.Reject] = "رد کردن",
			[UiKey.Delete] = "حذف",
			[UiKey.RejectProposedWordsQuestion] = "واژه\u200cهای پیشنهادی رد شوند؟",
			[UiKey.DeletePersonalWordsQuestion] = "واژه\u200cهای شخصی حذف شوند؟",
			[UiKey.RejectProposedWordsBody] = "{0} واژه\u0654 پیشنهادی رد شود؟ این واژه\u200cها از صف بیرون می\u200cروند و چیزی افزوده نمی\u200cشود.",
			[UiKey.DeletePersonalWordsBody] = "{0} واژه از واژه\u200cنامه\u0654 شخصی شما حذف شود؟ واژه\u200cای که در واژه\u200cنامه\u0654 پایه هم هست، همچنان شناخته می\u200cشود.",
			[UiKey.RejectAll] = "رد کردن همه",
			[UiKey.DeleteAll] = "حذف همه",
			[UiKey.DeleteAllPersonalWords] = "حذف همه\u0654 واژه\u200cهای شخصی",
			[UiKey.RejectAllQuestion] = "همه\u0654 واژه\u200cهای پیشنهادی رد شوند؟",
			[UiKey.DeleteAllPersonalWordsQuestion] = "همه\u0654 واژه\u200cهای شخصی حذف شوند؟",
			[UiKey.RejectAllBody] = "همه\u0654 پیشنهادها از صف بیرون می\u200cروند و چیزی افزوده نمی\u200cشود. این کار برگشت\u200cپذیر نیست.",
			[UiKey.DeleteAllBody] = "این کار برگشت\u200cپذیر نیست. واژه\u200cهای واژه\u200cنامه\u0654 پایه دست نمی\u200cخورند، پس واژه\u200cای که در واژه\u200cنامه\u0654 پایه هم هست، همچنان شناخته می\u200cشود.",
			[UiKey.WordCount] = "{0} واژه",
			[UiKey.SelectedOnPage] = "{0} مورد در این صفحه انتخاب شده · {1} واژه",
			[UiKey.SourceBuiltIn] = "پایه",
			[UiKey.SourcePersonal] = "شخصی",
			[UiKey.LanguageNeutral] = "خنثی",
			[UiKey.StatusReadOnly] = "فقط\u200cخواندنی",
			[UiKey.StatusAddedAutomatically] = "افزوده\u0654 خودکار",
			[UiKey.StatusAccepted] = "پذیرفته\u200cشده",
			[UiKey.StatusDisabled] = "غیرفعال",
			[UiKey.StatusProtected] = "محافظت\u200cشده",
			[UiKey.StatusAllowed] = "مجاز",
			[UiKey.ReviewUses] = "{0} بار استفاده · {1}",
			[UiKey.UnsavedProposals] = "برخی پیشنهادهایی که هنگام تایپ ثبت شدند فقط در حافظه مانده\u200cاند، چون فایل صف بازبینی ذخیره نشد. این پیشنهادها همراه نخستین تغییری که با موفقیت ذخیره شود، ذخیره می\u200cشوند و اگر Diyar پیش از آن بسته شود، از دست می\u200cروند.",
			[UiKey.NothingWasOverwritten] = "{0} چیزی بازنویسی نشد.",
			[UiKey.Words] = "واژه\u200cها",
			[UiKey.DetectFromLetters] = "تشخیص از روی حروف",
			[UiKey.AddToPersonalDictionary] = "افزودن به واژه\u200cنامه\u0654 شخصی شما",
			[UiKey.ImportSummary] = "نتیجه\u0654 وارد کردن به واژه\u200cنامه\u0654 شخصی شما: {0} افزوده\u200cشده · {1} از پیش موجود · {2} از پیش در واژه\u200cنامه\u0654 پایه · {3} نامعتبر",
			[UiKey.LanguageCardTitle] = "زبان · Language",
			[UiKey.InterfaceLanguage] = "زبان برنامه",
			[UiKey.InterfaceLanguageTip] = "زبان پنجره، منوی ناحیه\u0654 اعلان و پیام\u200cهای Diyar",
			[UiKey.InterfaceLanguageNote] = "زبان بی\u200cدرنگ و بدون اجرای دوباره\u0654 برنامه عوض می\u200cشود. تایپ، تبدیل و میان\u200cبرهای شما در هر دو زبان دقیقا\u064b همان\u200cطور کار می\u200cکنند.",
			[UiKey.AlreadyRunning] = "Diyar هم\u200cاکنون در حال اجراست. آن را از ناحیه\u0654 اعلان ویندوز باز کنید. پیش از اجرای نسخه\u0654 WinUI، نسخه\u0654 قبلی را ببندید.",
			[UiKey.CouldNotStart] = "Diyar اجرا نشد",
			[UiKey.EnglishOnlyPlacesTitle] = "جاهای فقط انگلیسی",
			[UiKey.EnglishOnlyPlacesIntro] = "در هر جایی که این\u200cجا روشن است Diyar هیچ چیزی از تایپ شما را تغییر نمی\u200cدهد و کلیدها همان\u200cطور که زده\u200cاید می\u200cمانند. هر جا را خاموش کنید تا آن\u200cجا هم مثل بقیه\u0654 جاها با حالت تایپ شما تایپ شود.",
			[UiKey.EnglishOnlyFields] = "کادرها، در همه\u0654 حالت\u200cها",
			[UiKey.PlaceBrowserAddressBar] = "نوار نشانی مرورگر",
			[UiKey.PlaceBrowserAddressBarTip] = "Chrome، Edge، Firefox و مرورگرهای دیگر. خاموش: آن\u200cجا هم فارسی تایپ می\u200cشود و اصلاح خودکار واژه\u200cها را تبدیل می\u200cکند.",
			[UiKey.PlaceWebAddressField] = "کادرهایی که یک نشانی وب در آن\u200cهاست",
			[UiKey.PlaceWebAddressFieldTip] = "کادری که همه\u0654 متن آن یک نشانی وب یا نام یک میزبان است، در هر برنامه\u200cای.",
			[UiKey.PlacePaymentCardField] = "کادرهای کارت بانکی",
			[UiKey.PlacePaymentCardFieldTip] = "کادرهای شماره\u0654 کارت، نام دارنده\u0654 کارت، تاریخ انقضا و کد امنیتی در فرم پرداخت.",
			[UiKey.PlacePasswordField] = "کادرهای رمز عبور",
			[UiKey.PlacePasswordFieldTip] = "همیشه محافظت می\u200cشود: Diyar هرگز چیزی را که در کادر رمز عبور تایپ می\u200cکنید تغییر نمی\u200cدهد.",
			[UiKey.EnglishOnlyFieldsNote] = "وقتی نوار نشانی خاموش است، پیشنهادی که خود مرورگر جلوی نشانگر نشان می\u200cدهد ممکن است در اصلاح خودکار جلوی تبدیل درست را بگیرد. اگر واژه\u200cای اشتباه درآمد، آن را دوباره روشن کنید.",
			[UiKey.EnglishOnlyApplications] = "برنامه\u200cها، در اصلاح خودکار",
			[UiKey.EnglishOnlyApplicationsNote] = "در این برنامه\u200cها و پنجره\u200cهای آن\u200cها اصلاح خودکار چیزی را تبدیل نمی\u200cکند. میان\u200cبرها و حالت\u200cهای دیگر تایپ مثل همیشه کار می\u200cکنند. خط فرمانی که داخل Windows Terminal باز است، مثل PowerShell یا cmd، از تنظیم Windows Terminal پیروی می\u200cکند.",
			[UiKey.EnglishOnlyTerminals] = "ترمینال\u200cها",
			[UiKey.EnglishOnlyLaunchers] = "اجراکننده\u200cها و جستجوی فایل",
			[UiKey.EnglishOnlyDatabaseTools] = "ابزارهای پایگاه داده",
			[UiKey.EnglishOnlyRemoteDesktops] = "دسترسی از راه دور",
			[UiKey.EnglishOnlyPasswordManagers] = "برنامه\u200cهای مدیریت رمز عبور",
			[UiKey.FontBrowsersNote] = "مرورگرها این قلم را فقط در صفحه\u200cهایی به کار می\u200cبرند که قلم خودشان را تعیین نکرده\u200cاند. «نمایش در مرورگر» صفحه\u200cای را باز می\u200cکند که این قلم را نشان می\u200cدهد.",
			[UiKey.FontNotInstalledNote] = "{0} در ویندوز نصب نیست، پس هیچ برنامه\u200cای نمی\u200cتواند از آن استفاده کند. قلمی را انتخاب کنید که در ویندوز نصب است.",
			[UiKey.FontsRevertedNotice] = "این برنامه\u200cها تنظیم قلم را برگردانده\u200cاند: {0}. قلم را دوباره اعمال کنید.",
			[UiKey.ShowFontInBrowser] = "نمایش در مرورگر",
			[UiKey.FontCheckNotOpened] = "{0} باز نشد.",
			[UiKey.UpdateNow] = "به\u200cروزرسانی",
			[UiKey.DownloadAndInstall] = "دریافت و نصب",
			[UiKey.UpdateAvailableCardText] = "نسخه\u0654 {0} در دسترس است ({1}).",
			[UiKey.UpdateDownloadingText] = "در حال دریافت Diyar {0}… {1} از {2}",
			[UiKey.UpdateDownloadProgressName] = "پیشرفت دریافت به\u200cروزرسانی",
			[UiKey.UpdateVerifyingText] = "در حال بررسی فایل دریافت\u200cشده…",
			[UiKey.UpdateReadyText] = "Diyar {0} آماده\u0654 نصب است. Diyar بسته می\u200cشود، به\u200cروزرسانی نصب می\u200cشود و دوباره باز می\u200cشود. ویندوز یک بار اجازه می\u200cپرسد.",
			[UiKey.InstallAndRestart] = "نصب و بازکردن دوباره\u0654 Diyar",
			[UiKey.UpdateInstallingText] = "در حال نصب Diyar {0}… Diyar خودش بسته و دوباره باز می\u200cشود.",
			[UiKey.UpdatePermissionRefusedText] = "ویندوز اجازه\u0654 به\u200cروزرسانی نداد. چیزی تغییر نکرد.",
			[UiKey.UpdateCancelledText] = "به\u200cروزرسانی لغو شد. چیزی تغییر نکرد.",
			[UiKey.UpdateRestartWindowsText] = "Diyar {0} نصب شد. برای پایان کار، ویندوز را دوباره راه\u200cاندازی کنید.",
			[UiKey.UpdateRestartDiyarText] = "Diyar {0} نصب شد. برای استفاده، Diyar را دوباره باز کنید.",
			[UiKey.RestartDiyar] = "بازکردن دوباره\u0654 Diyar",
			[UiKey.UpdateDownloadFailedText] = "دریافت کامل نشد.",
			[UiKey.UpdateFileRejectedText] = "فایل دریافت\u200cشده با نسخه\u0654 منتشرشده مطابقت ندارد و حذف شد.",
			[UiKey.UpdateNotEnoughSpaceText] = "فضای خالی برای دریافت به\u200cروزرسانی کافی نیست ({0} لازم است).",
			[UiKey.UpdateBlockedBySecurityText] = "امنیت ویندوز نصب\u200cکننده\u0654 دریافت\u200cشده را مسدود کرد.",
			[UiKey.UpdateNewerInstalledText] = "نسخه\u0654 جدیدتری از Diyar از قبل نصب شده است.",
			[UiKey.UpdateFailedText] = "به\u200cروزرسانی نصب نشد (کد {0}).",
			[UiKey.UpdateLaunchFailedText] = "نصب\u200cکننده اجرا نشد.",
			[UiKey.TryAgain] = "تلاش دوباره",
			[UiKey.OpenSetupLog] = "بازکردن گزارش نصب",
			[UiKey.OpenUpdateFolder] = "بازکردن پوشه\u0654 دریافت",
			[UiKey.UpdatedToText] = "Diyar به نسخه\u0654 {0} به\u200cروز شد.",
			[UiKey.UpdateDidNotFinishText] = "به\u200cروزرسانی به نسخه\u0654 {0} کامل نشد. می\u200cتوانید از تنظیمات دوباره تلاش کنید."
		};

		public static string ListSeparator
		{
			get
			{
				if (!TextCatalog.IsPersian)
				{
					return ", ";
				}
				return "، ";
			}
		}

		public static string Count(long value)
		{
			return InterfaceFormat.Count(value, TextCatalog.Language);
		}

		public static string Date(System.DateTimeOffset moment)
		{
			return InterfaceFormat.DateValue(moment.ToLocalTime().DateTime, TextCatalog.Language);
		}

		public static string Get(UiKey key)
		{
			return Get(key, TextCatalog.Language);
		}

		public static string Get(UiKey key, UiLanguage language)
		{
			return TextCatalog.Lookup(key, language, English, Persian);
		}

		public static string Format(UiKey key, params object?[] values)
		{
			return FormatIn(key, TextCatalog.Language, values);
		}

		public static string FormatIn(UiKey key, UiLanguage language, params object?[] values)
		{
			return TextCatalog.Format(Get(key, language), values, language == UiLanguage.Persian);
		}

		public static IReadOnlyDictionary<UiKey, string> Table(UiLanguage language)
		{
			if (language != UiLanguage.Persian)
			{
				return English;
			}
			return Persian;
		}
	}
}
namespace SmartInput.WinUI.Services
{
	internal static class CrashTestTrigger
	{
		public const string Variable = "SMARTINPUT_CRASH_TEST";

		public static void Arm(MainWindow window, TypingSession session)
		{
			if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SMARTINPUT_SETTINGS_DIRECTORY")))
			{
				return;
			}
			string site = Environment.GetEnvironmentVariable("SMARTINPUT_CRASH_TEST");
			if (site == null || site.Length <= 0 || session.IsVerification)
			{
				return;
			}
			Microsoft.UI.Dispatching.DispatcherQueue queue = window.DispatcherQueue;
			System.Windows.Forms.Timer delay = new System.Windows.Forms.Timer
			{
				Interval = 2000
			};
			delay.Tick += (object? _, EventArgs _) =>
			{
				delay.Stop();
				delay.Dispose();
				switch (site)
				{
				case "ui":
					queue.TryEnqueue(() =>
					{
						throw new CrashTestException(site);
					});
					break;
				case "winforms":
				{
					System.Windows.Forms.Timer tick = new System.Windows.Forms.Timer
					{
						Interval = 10
					};
					tick.Tick += (object? obj, EventArgs e) =>
					{
						tick.Stop();
						throw new CrashTestException(site);
					};
					tick.Start();
					break;
				}
				case "pool":
				{
					Thread thread = new Thread(() =>
					{
						throw new CrashTestException(site);
					});
					thread.IsBackground = true;
					thread.Name = "Diyar crash test";
					thread.Start();
					break;
				}
				case "task":
					PlantUnobservedTask(site);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					break;
				}
			};
			delay.Start();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void PlantUnobservedTask(string site)
		{
			((IAsyncResult)Task.Run(() =>
			{
				throw new CrashTestException(site);
			})).AsyncWaitHandle.WaitOne(System.TimeSpan.FromSeconds(2L));
		}
	}
	internal sealed class ShortcutHost : NativeWindow, IDisposable
	{
		private readonly GlobalHotkeyRegistrar _registrar;

		private readonly TypingSession _session;

		private readonly Action<string> _notice;

		private readonly Microsoft.UI.Dispatching.DispatcherQueue _queue;

		private bool _suspended;

		private bool _busy;

		private bool _disposed;

		private string? _registeredSignature;

		public static UiKey[] Commands { get; } = new UiKey[9]
		{
			UiKey.CommandToggleLastWord,
			UiKey.CommandUndoLastTranslation,
			UiKey.CommandConvertSelectedWord,
			UiKey.CommandAddSelectedWord,
			UiKey.CommandTranslateSelectedText,
			UiKey.CommandConvertNonDictionaryWords,
			UiKey.CommandUndoManualCorrection,
			UiKey.CommandTranslateClipboard,
			UiKey.CommandPauseResume
		};

		public static string[] Labels { get; } = Commands.Select((UiKey key) => UiText.Get(key, UiLanguage.English)).ToArray();

		public static IReadOnlyList<int> ActiveCommands => ShortcutCommandPolicy.Listed;

		private int ActiveCount => Enumerable.Range(0, Labels.Length).Count(IsActive);

		public static string[] Values(HotkeySettings s)
		{
			return new string[9] { s.ConvertPreviousWord, s.UndoLastConversion, s.ToggleSelectedText, s.AddSelectedToDictionary, s.TranslateSelectedText, s.ConvertNonDictionaryWords, s.UndoManualCorrection, s.TranslateClipboard, s.PauseResume };
		}

		public static HotkeySettings SettingsFrom(string[] values)
		{
			return new HotkeySettings
			{
				ConvertPreviousWord = values[0],
				UndoLastConversion = values[1],
				ToggleSelectedText = values[2],
				AddSelectedToDictionary = values[3],
				TranslateSelectedText = values[4],
				ConvertNonDictionaryWords = values[5],
				UndoManualCorrection = values[6],
				TranslateClipboard = values[7],
				PauseResume = values[8]
			};
		}

		public ShortcutHost(TypingSession session, Action<string> notice, Microsoft.UI.Dispatching.DispatcherQueue queue)
		{
			_session = session;
			_notice = notice;
			_queue = queue;
			CreateHandle(new CreateParams
			{
				Caption = "Diyar shortcuts",
				Parent = new IntPtr(-3)
			});
			_registrar = new GlobalHotkeyRegistrar(Handle);
			_session.Changed += OnSessionChanged;
		}

		public bool Register(HotkeySettings settings, out string error)
		{
			string[] values = Values(settings);
			Unregister();
			IReadOnlyList<ShortcutFailure> readOnlyList = ShortcutRegistrationPolicy.RegisterEach(Labels, values, delegate(string value, out HotkeyGesture gesture)
			{
				string error2;
				return HotkeyGesture.TryParse(value, out gesture, out error2);
			}, (int index, HotkeyGesture gesture) => _registrar.Register(20481 + index, gesture.Modifiers, gesture.VirtualKey), IsActive);
			(string Shown, string Logged) tuple = Report(readOnlyList, ActiveCount);
			string item = tuple.Shown;
			string item2 = tuple.Logged;
			error = item;
			_registeredSignature = Signature(settings);
			_session.NoteShortcutRegistration(readOnlyList.Count == 0, item2);
			return readOnlyList.Count == 0;
		}

		internal static (string Shown, string Logged) Report(IReadOnlyList<ShortcutFailure> failures, int activeCount)
		{
			return (Shown: ShortcutRegistrationPolicy.Describe(Displayed(failures), activeCount) ?? string.Empty, Logged: ShortcutRegistrationPolicy.Describe(failures, activeCount, UiLanguage.English) ?? string.Empty);
		}

		internal static IReadOnlyList<ShortcutFailure> Displayed(IReadOnlyList<ShortcutFailure> failures)
		{
			List<ShortcutFailure> list = new List<ShortcutFailure>();
			list.AddRange(failures.Select((ShortcutFailure failure) =>
			{
				int num = Array.IndexOf(Labels, failure.Label);
				return (num < 0) ? failure : failure with
				{
					Label = UiText.Get(Commands[num])
				};
			}));
			return new <>z__ReadOnlyList<ShortcutFailure>(list);
		}

		private bool IsActive(int index)
		{
			return ShortcutCommandPolicy.IsRegistered(index, _session.LastWordHotkeyActive, _session.Settings.Translation.Enabled, _session.SelectedWordHotkeyActive);
		}

		private string Signature(HotkeySettings settings)
		{
			return string.Join("|", Values(settings).Select((string value, int index) => (!IsActive(index)) ? "-" : value));
		}

		private void OnSessionChanged()
		{
			if (_disposed || _suspended || _registeredSignature == Signature(_session.Settings.Hotkeys))
			{
				return;
			}
			_queue.TryEnqueue(() =>
			{
				if (!_disposed && !_suspended && !(_registeredSignature == Signature(_session.Settings.Hotkeys)) && !Register(_session.Settings.Hotkeys, out string error))
				{
					_notice(error);
				}
			});
		}

		public void Suspend(bool value)
		{
			_suspended = value;
			_session.SuspendTyping(value);
			string error;
			if (value)
			{
				Unregister();
			}
			else if (!Register(_session.Settings.Hotkeys, out error))
			{
				_notice(error);
			}
		}

		private void Unregister()
		{
			for (int i = 0; i < Labels.Length; i++)
			{
				_registrar.Unregister(20481 + i);
			}
		}

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 786)
			{
				try
				{
					OnHotkey(((IntPtr)m.WParam).ToInt32() - 20481);
					return;
				}
				catch (System.Exception ex)
				{
					FaultRing.Note(FaultSite.Shortcut, ex);
					DiagnosticMessageHandler message = new DiagnosticMessageHandler(31, 2, out var shouldAppend);
					if (shouldAppend)
					{
						message.AppendLiteral("A shortcut press failed (");
						message.AppendFormatted(ex.GetType().FullName);
						message.AppendLiteral(", 0x");
						message.AppendFormatted(ex.HResult, "X8");
						message.AppendLiteral(").");
					}
					DiagnosticLog.Write("Shortcuts", ref message);
					return;
				}
			}
			base.WndProc(ref m);
		}

		private void OnHotkey(int command)
		{
			InputMarker marker = _session.CaptureInputMarker();
			if (_suspended)
			{
				return;
			}
			if (_busy)
			{
				if (ShortcutCommandPolicy.IsTranslation(command))
				{
					_session.CancelTranslation();
				}
			}
			else
			{
				_queue.TryEnqueue(() =>
				{
					DispatchAsync(command, marker);
				});
			}
		}

		private async Task DispatchAsync(int command, InputMarker marker)
		{
			if (_busy || _suspended || _disposed)
			{
				return;
			}
			_busy = true;
			try
			{
				if ((command == 1 || command == 4) ? true : false)
				{
					for (int i = 0; i < 40; i++)
					{
						if (GlobalHotkeyRegistrar.AreShortcutModifiersReleased())
						{
							break;
						}
						await Task.Delay(15);
					}
					if (_disposed || _suspended || !GlobalHotkeyRegistrar.AreShortcutModifiersReleased())
					{
						return;
					}
				}
				if (!_disposed && !_suspended)
				{
					string text = await _session.RunShortcutAsync(command, marker);
					if (text != null)
					{
						_notice(text);
					}
				}
			}
			catch (System.Exception ex)
			{
				FaultRing.Note(FaultSite.Shortcut, ex);
				_notice(ex.Message);
			}
			finally
			{
				_busy = false;
			}
		}

		public void Dispose()
		{
			_disposed = true;
			_session.Changed -= OnSessionChanged;
			Unregister();
			DestroyHandle();
		}
	}
	[WinRTRuntimeClassName("Windows.Foundation.IClosable")]
	[WinRTExposedType(typeof(SmartInput_WinUI_Services_TypingSessionWinRTTypeDetails))]
	internal sealed class TypingSession : IDisposable
	{
		private enum AddWordLog
		{
			Start,
			CancelledBeforeRead,
			CancelledAfterRead,
			Busy,
			TimedOut,
			Failed
		}

		public sealed record ProblemCapture(Task<string> Report, string ForegroundAtCapture);

		private SessionMarker? _marker;

		private System.Threading.Timer? _markerTimer;

		private long _markerFaultVersion;

		private readonly object _markerGate = new object();

		private readonly AppSettingsStore _store;

		private readonly TypingAssistantController? _controller;

		private readonly StartupRegistrationService? _startup;

		private readonly ForcedConversionLearningService _learning;

		private readonly ConversionLearningStore _conversionLearning;

		private readonly EnglishPreferenceLearning _english;

		private readonly LexiconStore _lexicon;

		private SelectedWordOperation? _selectedWord;

		private ForcedConversionLearningResult? _lastContribution;

		private string? _lastContributionWord;

		private bool _typingSuspended;

		private readonly CancellationTokenSource _updateCancellation = new CancellationTokenSource();

		private EnvironmentObserverHandle? _environmentObserver;

		private readonly TranslationModelWarmUp? _warmUp;

		private static readonly System.TimeSpan TranslationTimeout = System.TimeSpan.FromSeconds(120L);

		private static readonly System.TimeSpan UndoTimeout = System.TimeSpan.FromSeconds(15L);

		private static readonly System.TimeSpan SelectionReadTimeout = System.TimeSpan.FromSeconds(3L);

		internal const string LogPathVariable = "SMARTINPUT_LOG_PATH";

		private const string LogFormatVariable = "SMARTINPUT_LOG_FORMAT";

		private const string LogDetailVariable = "SMARTINPUT_LOG_DETAIL";

		private bool _debugForcedByPath;

		private bool _debugSettingAtLastApply;

		private bool _debugInitialized;

		private bool _diagnosticsSessionPending;

		private string _shortcutRegistration = "not registered yet";

		private TextServicePublication? _textServicePublication;

		private TextServiceBroker? _textServiceBroker;

		private ManualCorrectionCoordinator? _textServiceCoordinator;

		private long _textServiceRevision;

		private string? _publishedTextServiceSignature;

		public string CrashDirectory { get; private set; } = CrashRecorder.DefaultDirectory;

		public (SessionOutcome Outcome, SessionMarker Marker)? UnexpectedPreviousSession { get; private set; }

		public (SessionOutcome Outcome, System.DateTimeOffset LastSeen)? LastSessionOutcome { get; private set; }

		public AppSettings Settings { get; private set; }

		public UserDictionaryService Dictionary { get; }

		public ManualConversionReviewService Review { get; }

		public ITranslationFeature Translation { get; }

		public IUpdateService Updates { get; }

		internal UpdateCheckCoordinator UpdateChecks { get; }

		internal UpdateInstallCoordinator UpdateInstall { get; }

		internal UpdateOutcome UpdateOutcome { get; }

		public IApplicationFontService Fonts { get; } = new ApplicationFontService();

		public bool IsVerification { get; }

		internal int CommonPersianAdditionsLoaded => _lexicon.CommonPersianAdditionCount;

		internal SelectedWordOperation SelectedWord => _selectedWord ?? (_selectedWord = new SelectedWordOperation(new UnavailableSelectedWordEditor(), () => _controller.ManualMapping, () => Settings.SavesSelectedWordCorrections, new CorrectionLearningService(Dictionary, () => DiagnosticLog.Journal, "selectedword", _english), () => DiagnosticLog.Journal));

		public bool LastWordHotkeyActive => LastWordExecutionRoute.HotkeyIsActive(Settings.LastWord, LastWordExecutionRoute.Current);

		public bool SelectedWordHotkeyActive => false;

		public ITypingEnvironmentSource? EnvironmentObserver => _environmentObserver?.Client;

		internal TranslationRunGate TranslationRuns { get; } = new TranslationRunGate();

		public static string? DebugLogPath => DiagnosticLog.CurrentPath;

		public string? SettingsProblem => _store.LoadProblem;

		public static string CancelledMessage => MessageText.Get(MessageKey.CancelledAfterShortcut);

		public bool DebugEffective => DiagnosticLog.IsEnabled;

		public bool DebugOnForThisRunOnly
		{
			get
			{
				if (DiagnosticLog.IsEnabled && _debugForcedByPath)
				{
					return !Settings.General.DebugMode;
				}
				return false;
			}
		}

		public static bool TextServiceInstalled => TextServiceDllPath != null;

		public static string? TextServiceDllPath
		{
			get
			{
				try
				{
					using RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey("CLSID\\{8300838D-53DF-4662-AB3F-94609D7FB24E}\\InprocServer32");
					return (registryKey?.GetValue(null) is string text && File.Exists(text)) ? text : null;
				}
				catch (System.Exception ex) when ((ex is SecurityException || ex is UnauthorizedAccessException || ex is IOException) ? true : false)
				{
					return null;
				}
			}
		}

		public static string TextServiceMissingMessage => MessageText.Format(MessageKey.TextServiceMissing, "Ctrl+Alt+Enter", "Ctrl+Alt+Space", "Ctrl+Alt+U");

		public static IReadOnlyList<TextServiceHost> TextServiceHosts { get; } = TextServiceHostPolicy.Product;

		public string TextServiceProblem { get; private set; } = string.Empty;

		public event Action? Changed;

		public event Action? PauseToggled;

		public event Action<string>? ShortcutNotice;

		private void ConfigureCrashRecording(string? verificationDirectory)
		{
			try
			{
				bool flag = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SMARTINPUT_SETTINGS_DIRECTORY"));
				TypingSession typingSession = this;
				string crashDirectory;
				if (verificationDirectory != null)
				{
					crashDirectory = System.IO.Path.Combine(verificationDirectory, "crashes");
				}
				else
				{
					crashDirectory = (flag ? System.IO.Path.Combine(_store.DirectoryPath, "crashes") : CrashRecorder.DefaultDirectory);
				}
				typingSession.CrashDirectory = crashDirectory;
				CrashRecorder.Configure(CrashDirectory, new CrashContext(App.Version, BuildCommit(), FileVersion(), InstallKind(), $"{RuntimeInformation.OSDescription} ({Environment.OSVersion.VersionString}, {RuntimeInformation.OSArchitecture})", RuntimeInformation.FrameworkDescription, ProcessStart(), IsVerification, Environment.GetCommandLineArgs().Contains("--startup")));
				CrashRecorder.SetState(Settings.General.TypingMode.ToString(), Settings.General.Enabled);
				CrashRecorder.Breadcrumb("session.created", IsVerification ? "verification" : null);
			}
			catch (System.Exception ex)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(34, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Crash recording is unavailable (");
					message.AppendFormatted(ex.GetType().FullName);
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Crash", ref message);
			}
		}

		public void BeginSessionMarker()
		{
			try
			{
				CrashContext context = new CrashContext(App.Version, BuildCommit(), "", "", "", "", ProcessStart(), IsVerification, Environment.GetCommandLineArgs().Contains("--startup"));
				JudgePreviousSessions();
				SessionMarkerStore.Prune(CrashDirectory);
				lock (_markerGate)
				{
					_marker = SessionMarkerStore.Begin(CrashDirectory, context, Settings.General.TypingMode.ToString());
				}
				CrashRecorder.Breadcrumb("session.started");
				_markerTimer = new System.Threading.Timer((object? _) =>
				{
					RefreshMarker(clean: false);
				}, null, System.TimeSpan.FromSeconds(5L), System.TimeSpan.FromSeconds(5L));
			}
			catch (System.Exception ex)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(43, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("The session marker could not be written (");
					message.AppendFormatted(ex.GetType().FullName);
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Crash", ref message);
			}
		}

		public void MarkCleanExit()
		{
			try
			{
				_markerTimer?.Dispose();
				_markerTimer = null;
				CrashRecorder.Breadcrumb("exit.clean");
				RefreshMarker(clean: true);
			}
			catch (System.Exception ex)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(46, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("The clean-exit marker could not be written (");
					message.AppendFormatted(ex.GetType().FullName);
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Crash", ref message);
			}
		}

		public void MarkPreviousSessionNoticed()
		{
			(SessionOutcome, SessionMarker)? unexpectedPreviousSession = UnexpectedPreviousSession;
			if (unexpectedPreviousSession.HasValue)
			{
				SessionMarker item = unexpectedPreviousSession.GetValueOrDefault().Item2;
				SessionMarkerStore.Save(CrashDirectory, item with
				{
					Noticed = true
				});
			}
		}

		private void RefreshMarker(bool clean)
		{
			try
			{
				lock (_markerGate)
				{
					SessionMarker marker = _marker;
					if ((object)marker != null)
					{
						long version = FaultRing.Version;
						if (clean || (!marker.Clean && version != _markerFaultVersion))
						{
							_markerFaultVersion = version;
							_marker = marker with
							{
								LastSeen = System.DateTimeOffset.Now,
								Clean = clean,
								TypingMode = Settings.General.TypingMode.ToString(),
								Faults = FaultRing.Summarize()
							};
							SessionMarkerStore.Save(CrashDirectory, _marker);
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(43, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("The session marker could not be updated (");
					message.AppendFormatted(ex.GetType().FullName);
					message.AppendLiteral(").");
				}
				DiagnosticLog.Write("Crash", ref message);
			}
		}

		private void JudgePreviousSessions()
		{
			SessionOutcomeClassifier.Judgement judgement = SessionOutcomeClassifier.JudgeAll(SessionMarkerStore.LoadOthers(CrashDirectory, Environment.ProcessId), (SessionMarker marker) => SessionMarkerStore.CrashRecordsOf(CrashDirectory, marker), StillRunning);
			foreach (SessionMarker item in judgement.NewlyJudged)
			{
				SessionMarkerStore.Save(CrashDirectory, item);
			}
			(SessionOutcome, SessionMarker)? newest = judgement.Newest;
			if (newest.HasValue)
			{
				(SessionOutcome, SessionMarker) valueOrDefault = newest.GetValueOrDefault();
				LastSessionOutcome = (valueOrDefault.Item1, valueOrDefault.Item2.LastSeen);
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(46, 4, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("Previous session ");
					message.AppendFormatted(valueOrDefault.Item2.Pid);
					message.AppendLiteral(" (");
					message.AppendFormatted(valueOrDefault.Item2.Version);
					message.AppendLiteral(") ended: ");
					message.AppendFormatted(valueOrDefault.Item1);
					message.AppendLiteral("; handled faults ");
					message.AppendFormatted(valueOrDefault.Item2.FaultCount);
					message.AppendLiteral(".");
				}
				DiagnosticLog.Write("Crash", ref message);
			}
			UnexpectedPreviousSession = judgement.ToNotice;
		}

		private static bool StillRunning(SessionMarker marker)
		{
			try
			{
				using Process process = Process.GetProcessById(marker.Pid);
				return Math.Abs((process.StartTime - marker.Start.LocalDateTime).TotalSeconds) < 2.0;
			}
			catch (System.Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException || ex is Win32Exception || ex is NotSupportedException) ? true : false)
			{
				return false;
			}
		}

		private static System.DateTimeOffset ProcessStart()
		{
			try
			{
				using Process process = Process.GetCurrentProcess();
				return new System.DateTimeOffset(process.StartTime);
			}
			catch (System.Exception ex) when ((ex is InvalidOperationException || ex is Win32Exception || ex is NotSupportedException) ? true : false)
			{
				return System.DateTimeOffset.Now;
			}
		}

		private static string FileVersion()
		{
			try
			{
				string processPath = Environment.ProcessPath;
				return (processPath != null) ? (FileVersionInfo.GetVersionInfo(processPath).FileVersion ?? "") : "";
			}
			catch (System.Exception ex) when ((ex is IOException || ex is ArgumentException) ? true : false)
			{
				return "";
			}
		}

		public TypingSession(string? verificationDirectory = null)
		{
			IsVerification = verificationDirectory != null;
			_store = new AppSettingsStore(verificationDirectory);
			Settings = _store.Load();
			TextCatalog.Language = Settings.General.UiLanguage;
			ApplyDebugMode();
			ConfigureCrashRecording(verificationDirectory);
			LexiconStore lexiconStore = (_lexicon = LexiconLoader.LoadFromFiles(DictionaryPaths.BuiltinEnglish, DictionaryPaths.BuiltinPersian, (verificationDirectory == null) ? DictionaryPaths.UserDictionary : System.IO.Path.Combine(verificationDirectory, "dictionary.json"), DictionaryPaths.Metadata, DictionaryPaths.PersianFrequency, Settings.Correction.CommonPersianAdditions ? DictionaryPaths.PersianCommonAdditions : null));
			_conversionLearning = new ConversionLearningStore((verificationDirectory == null) ? DictionaryPaths.ConversionLearning : System.IO.Path.Combine(verificationDirectory, "conversion-learning.json"));
			Dictionary = new UserDictionaryService(lexiconStore, IsVerification ? ((Action<IReadOnlyList<SmartInput.Core.Dictionaries.DictionaryEntry>>)((IReadOnlyList<SmartInput.Core.Dictionaries.DictionaryEntry> _) =>
			{
			})) : null);
			Review = new ManualConversionReviewService((verificationDirectory == null) ? null : System.IO.Path.Combine(verificationDirectory, "review.json"));
			_learning = new ForcedConversionLearningService(Dictionary, Review);
			_english = new EnglishPreferenceLearning(_conversionLearning, lexiconStore, Dictionary, () => Settings.Correction.LearnEnglishFromManualCorrections, () => KeyboardLayoutRegistry.GetTargetIdentity(_controller?.ManualMapping ?? Settings.General.PersianKeyboardLayout));
			UpdateCheckStateStore state = new UpdateCheckStateStore(System.IO.Path.Combine(_store.DirectoryPath, "update-state.json"));
			Updates = ManifestUpdateService.CreateForApplication(App.Version, Settings.General.UpdateFeedUrl, null, state, Settings.General.RequireSignedUpdateManifest);
			UpdateChecks = new UpdateCheckCoordinator(Updates, state, new UpdateCheckSchedule(TimeProvider.System), App.Version);
			UpdateInstall = UpdateInstallCoordinator.CreateForApplication(App.Version, Settings.General.InstallUpdatesInApp, verificationDirectory);
			UpdateChecks.PendingChanged += UpdateInstall.Offer;
			UpdateOutcome = UpdateInstall.ReadStartOutcome();
			if (IsVerification)
			{
				Translation = new UnavailableTranslationFeature();
				BeginDiagnosticsSession();
				return;
			}
			_startup = StartupRegistrationService.CreateForCurrentUser(Environment.ProcessPath);
			_startup.Synchronize(Settings.General.RunAtWindowsStartup);
			TryStartEnvironmentObserver();
			_controller = new TypingAssistantController(Settings, lexiconStore, null, null, _environmentObserver?.Client);
			_controller.ManualConversionsCompleted += OnConverted;
			_controller.ManualConversionUndone += OnUndone;
			_controller.EnglishWordRestored += OnEnglishRestored;
			_controller.PreviousWordCommandNotice += OnPreviousWordNotice;
			BeginDiagnosticsSession();
			TranslationProviderRouter provider = new TranslationProviderRouter(() => new FoundryLocalTranslationProvider(), () => new AzureTranslationProvider(new WindowsTranslationCredentialStore()));
			Translation = new TranslationFeature(provider, _controller.TranslationSelectionEditor, () => Settings.Translation, (TranslationSettings value) =>
			{
				Save((AppSettings s) => s with
				{
					Translation = value
				});
			}, _controller.TranslationClipboard);
			_warmUp = new TranslationModelWarmUp(provider, () => Settings.Translation);
		}

		public bool CancelTranslation()
		{
			return TranslationRuns.CancelCurrent();
		}

		private void TryStartEnvironmentObserver()
		{
			try
			{
				string helperExecutablePath = System.IO.Path.Combine(AppContext.BaseDirectory, "EnvironmentProbe", "SmartInput.EnvironmentProbe.exe");
				_environmentObserver = EnvironmentObserverComposition.TryCreate(Environment.GetEnvironmentVariable("SMARTINPUT_ENVIRONMENT_OBSERVER"), IsVerification, helperExecutablePath, (string msg) =>
				{
					DiagnosticLog.Write("Environment", msg);
				});
			}
			catch (System.Exception ex) when ((ex is InvalidOperationException || ex is Win32Exception || ex is IOException) ? true : false)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(21, 1, out var shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("ObserverUnavailable: ");
					message.AppendFormatted(ex.GetType().Name);
				}
				DiagnosticLog.Write("Environment", ref message);
				_environmentObserver = null;
			}
		}

		private async void StartEnvironmentObserverAsync()
		{
			if (_environmentObserver == null)
			{
				return;
			}
			try
			{
				await _environmentObserver.StartAsync(CancellationToken.None);
			}
			catch (System.Exception ex)
			{
				bool shouldAppend = ((ex is InvalidOperationException || ex is TimeoutException || ex is Win32Exception || ex is IOException) ? true : false);
				if (!shouldAppend)
				{
					FaultRing.Note(FaultSite.Observer, ex);
				}
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(21, 1, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("ObserverUnavailable: ");
					message.AppendFormatted(ex.GetType().Name);
				}
				DiagnosticLog.Write("Environment", ref message);
			}
		}

		public void Start()
		{
			_controller?.Start();
			StartTextService();
			StartEnvironmentObserverAsync();
			_warmUp?.Apply();
		}

		internal Task<UpdateCheckResult?> RunStartupUpdateCheckAsync()
		{
			return UpdateChecks.RunStartupCheckAsync(() => Settings.General.CheckForUpdatesAutomatically, () => Settings.General.IncludePreviewUpdates, _updateCancellation.Token);
		}

		public void Save(Func<AppSettings, AppSettings> update)
		{
			AppSettings appSettings = update(Settings);
			_store.Save(appSettings);
			Settings = appSettings;
			TextCatalog.Language = appSettings.General.UiLanguage;
			CrashRecorder.SetState(appSettings.General.TypingMode.ToString(), appSettings.General.Enabled);
			CrashRecorder.Breadcrumb("settings.saved", appSettings.General.TypingMode.ToString());
			bool isEnabled = DiagnosticLog.IsEnabled;
			_controller?.UpdateCorrectionSettings(appSettings.Correction);
			_controller?.UpdateGeneralSettings(appSettings.General with
			{
				Enabled = (appSettings.General.Enabled && !_typingSuspended)
			});
			_controller?.UpdateDictionarySettings(appSettings.Dictionary);
			_controller?.UpdateTranslationSettings(appSettings.Translation);
			_controller?.UpdateHotkeys(appSettings.Hotkeys);
			_warmUp?.Apply();
			PublishTextService();
			ApplyDebugMode();
			if (isEnabled && DiagnosticLog.IsEnabled)
			{
				PublishDiagnosticSettings("settings-changed");
			}
			Changed?.Invoke();
		}

		public string TogglePause()
		{
			bool resume = !Settings.General.Enabled;
			Save((AppSettings s) => s with
			{
				General = s.General with
				{
					Enabled = resume
				}
			});
			DiagnosticMessageHandler message = new DiagnosticMessageHandler(26, 2, out var shouldAppend);
			if (shouldAppend)
			{
				message.AppendLiteral("Typing ");
				message.AppendFormatted(resume ? "resumed" : "paused");
				message.AppendLiteral(": General.Enabled=");
				message.AppendFormatted(resume);
				message.AppendLiteral(".");
			}
			DiagnosticLog.Write("Session", ref message);
			PauseToggled?.Invoke();
			return MessageText.Get(resume ? MessageKey.TypingResumed : MessageKey.TypingPaused);
		}

		public void SuspendTyping(bool suspend)
		{
			_typingSuspended = suspend;
			_controller?.UpdateGeneralSettings(Settings.General with
			{
				Enabled = (!suspend && Settings.General.Enabled)
			});
			PublishTextService();
		}

		public StartupRegistrationResult StartupStatus()
		{
			return _startup?.GetStatus() ?? new StartupRegistrationResult(Settings.General.RunAtWindowsStartup == true, Succeeded: true, UiText.Get(UiKey.StartupIsolatedInVerification));
		}

		public StartupRegistrationResult SetStartup(bool value)
		{
			StartupRegistrationResult obj = _startup?.SetEnabled(value) ?? new StartupRegistrationResult(value, Succeeded: true, UiText.Get(UiKey.StartupSavedInVerification));
			if (obj.Succeeded)
			{
				Save((AppSettings s) => s with
				{
					General = s.General with
					{
						RunAtWindowsStartup = value
					}
				});
			}
			return obj;
		}

		public InputMarker CaptureInputMarker()
		{
			return _controller?.CaptureInputMarker() ?? default(InputMarker);
		}

		private async Task<string?> RunShortcutCoreAsync(int command, InputMarker marker)
		{
			if (_controller == null)
			{
				return null;
			}
			switch (command)
			{
			case 0:
				return _controller.PreviousWordShortcutMessage();
			case 1:
			{
				using CancellationTokenSource timeout = new CancellationTokenSource(UndoTimeout);
				TranslationActionResult translationActionResult = await Translation.UndoLastTranslationAsync(timeout.Token);
				return translationActionResult.Succeeded ? null : translationActionResult.Message;
			}
			case 2:
			{
				SelectedWordResult selectedWordResult = SelectedWord.Run(() => _controller.IsInputCurrent(marker));
				Changed?.Invoke();
				return selectedWordResult.Message;
			}
			case 3:
				return await AddSelectedWordAsync(marker);
			case 4:
			{
				using TranslationRun run = TranslationRuns.Begin(command, TranslationTimeout);
				if (run == null)
				{
					return MessageText.Get(MessageKey.TranslationAlreadyRunning);
				}
				return run.Describe(await Translation.TranslateSelectedTextAsync(marker, run.Token));
			}
			case 5:
				return MessageText.Get(MessageKey.NonDictionaryWordsUnavailable);
			case 8:
				return TogglePause();
			case 7:
			{
				using TranslationRun run = TranslationRuns.Begin(command, TranslationTimeout);
				if (run == null)
				{
					return MessageText.Get(MessageKey.TranslationAlreadyRunning);
				}
				return run.Describe(await Translation.TranslateClipboardAsync(run.Token));
			}
			default:
				return null;
			}
		}

		private async Task<string> AddSelectedWordAsync(InputMarker marker)
		{
			LogAddWord(AddWordLog.Start);
			if (!_controller.IsInputCurrent(marker))
			{
				LogAddWord(AddWordLog.CancelledBeforeRead);
				return CancelledMessage;
			}
			ExplicitSelectionAttempt explicitSelectionAttempt = await _controller.SelectionWorker.ReadAsync(_controller.ReadExplicitSelection, SelectionReadTimeout);
			switch (explicitSelectionAttempt.State)
			{
			case ExplicitSelectionAttemptState.Busy:
				LogAddWord(AddWordLog.Busy);
				return MessageText.Get(MessageKey.SelectionReadBusy);
			case ExplicitSelectionAttemptState.TimedOut:
				LogAddWord(AddWordLog.TimedOut);
				return MessageText.Get(MessageKey.EditorNoAnswer);
			case ExplicitSelectionAttemptState.Failed:
				LogAddWord(AddWordLog.Failed);
				return MessageText.Get(MessageKey.SelectionReadFailed);
			default:
			{
				ExplicitSelectionRead read = explicitSelectionAttempt.Read;
				LogAddWordRead(read);
				if (!read.IsRead)
				{
					return read.Refusal;
				}
				if (!_controller.IsInputCurrent(marker))
				{
					LogAddWord(AddWordLog.CancelledAfterRead);
					return CancelledMessage;
				}
				ExplicitAdditionResult explicitAdditionResult = ExplicitWordAddition.Add(read.Text, Dictionary, Review);
				Changed?.Invoke();
				return explicitAdditionResult.Message;
			}
			}
		}

		private void OnConverted(IReadOnlyList<ManualConversionResult> words)
		{
			if (_english.Enabled)
			{
				foreach (ManualConversionResult item in words.Where((ManualConversionResult word) => word.Language == EntryLanguage.Persian))
				{
					_english.ConvertedToPersian(item.TypedText, item.PersianWord, "hook");
				}
			}
			_lastContribution = _learning.Process(words, Settings.Dictionary.AutoAddForcedConversions);
			_lastContributionWord = ((words.Count == 1) ? words[0].PersianWord : null);
			Changed?.Invoke();
		}

		private void OnPreviousWordNotice(string message)
		{
			ShortcutNotice?.Invoke(message);
		}

		private void OnEnglishRestored(RestoredEnglishWord restored)
		{
			string word = restored.Word;
			if (_english.Enabled)
			{
				try
				{
					_english.Restored(word, restored.Persian, "hook", restored.SourceLayoutId, restored.TargetLayoutId);
				}
				catch (System.Exception ex) when ((ex is IOException || ex is UnauthorizedAccessException) ? true : false)
				{
				}
				Changed?.Invoke();
				return;
			}
			LearnedPreference learnedPreference = _conversionLearning.RecordRejection(word, restored.SourceLayoutId, restored.TargetLayoutId);
			_lexicon.AddSessionEnglishPreference(word);
			bool shouldAppend = default;
			if (learnedPreference != LearnedPreference.PermanentEnglish)
			{
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(60, 3, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("ConversionRejected '");
					message.AppendFormatted(word);
					message.AppendLiteral("' (");
					message.AppendFormatted(restored.SourceLayoutId);
					message.AppendLiteral(" -> ");
					message.AppendFormatted(restored.TargetLayoutId);
					message.AppendLiteral("): kept English for this session.");
				}
				DiagnosticLog.Write("Session", ref message);
				return;
			}
			try
			{
				int value = Dictionary.AddTerms(new <>z__ReadOnlySingleElementList<string>(word), EntryLanguage.English);
				DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(73, 2, out shouldAppend);
				if (shouldAppend)
				{
					message2.AppendLiteral("ConversionRejected '");
					message2.AppendFormatted(word);
					message2.AppendLiteral("' again: learned as a personal English word (added=");
					message2.AppendFormatted(value);
					message2.AppendLiteral(").");
				}
				DiagnosticLog.Write("Session", ref message2);
			}
			catch (System.Exception ex2) when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				shouldAppend = ((ex2 is IOException || ex2 is UnauthorizedAccessException) ? true : false);
				return shouldAppend;
			}).Invoke())
			{
			}
			Changed?.Invoke();
		}

		private void OnUndone(object? sender, ManualConversionResult word)
		{
			if (_english.Enabled && word.Language == EntryLanguage.Persian)
			{
				_english.WithdrawConversion(word.TypedText);
			}
			ForcedConversionLearningResult lastContribution = _lastContribution;
			if ((object)lastContribution != null && _lastContributionWord == word.PersianWord)
			{
				_learning.Withdraw(lastContribution);
				_lastContribution = null;
				_lastContributionWord = null;
			}
			Changed?.Invoke();
		}

		public void Dispose()
		{
			StopTextService();
			if (_controller != null)
			{
				_controller.ManualConversionsCompleted -= OnConverted;
				_controller.ManualConversionUndone -= OnUndone;
				_controller.EnglishWordRestored -= OnEnglishRestored;
				_controller.PreviousWordCommandNotice -= OnPreviousWordNotice;
			}
			_controller?.Dispose();
			_warmUp?.Dispose();
			Translation.Dispose();
			DisposeEnvironmentObserver();
			_updateCancellation.Cancel();
			UpdateInstall.Dispose();
			DiagnosticLog.Write("Session", "Diyar closed.");
			DiagnosticLog.Configure(null);
			Updates.Dispose();
		}

		private void DisposeEnvironmentObserver()
		{
			try
			{
				_environmentObserver?.DisposeAsync().AsTask().Wait(System.TimeSpan.FromSeconds(5L));
			}
			catch (System.Exception ex) when ((ex is AggregateException || ex is TimeoutException) ? true : false)
			{
			}
		}

		public void SetDebug(bool value)
		{
			_debugForcedByPath = false;
			Save((AppSettings s) => s with
			{
				General = s.General with
				{
					DebugMode = value
				}
			});
		}

		private void ApplyDebugMode()
		{
			string environmentVariable = Environment.GetEnvironmentVariable("SMARTINPUT_LOG_PATH");
			if (!_debugInitialized)
			{
				_debugInitialized = true;
				_debugForcedByPath = !string.IsNullOrWhiteSpace(environmentVariable);
				_debugSettingAtLastApply = Settings.General.DebugMode;
			}
			else if (Settings.General.DebugMode != _debugSettingAtLastApply)
			{
				_debugForcedByPath = false;
				_debugSettingAtLastApply = Settings.General.DebugMode;
			}
			bool num = _debugForcedByPath || (Settings.General.DebugMode && !IsVerification);
			bool isEnabled = DiagnosticLog.IsEnabled;
			if (!num)
			{
				if (isEnabled)
				{
					DiagnosticLog.Stop(clearTemporary: true);
				}
				return;
			}
			string path = ((!string.IsNullOrWhiteSpace(environmentVariable)) ? environmentVariable : DiagnosticLog.DefaultPath);
			bool flag = string.Equals(Environment.GetEnvironmentVariable("SMARTINPUT_LOG_FORMAT"), "legacy", StringComparison.OrdinalIgnoreCase);
			DiagnosticDetail detail = ((!string.Equals(Environment.GetEnvironmentVariable("SMARTINPUT_LOG_DETAIL"), "incidents", StringComparison.OrdinalIgnoreCase)) ? DiagnosticDetail.Full : DiagnosticDetail.Incidents);
			DiagnosticLog.Configure(path, !flag, detail);
			if (DiagnosticLog.IsEnabled && !isEnabled)
			{
				if (flag)
				{
					WriteLegacySessionLines();
					return;
				}
				_diagnosticsSessionPending = true;
				BeginDiagnosticsSession();
			}
		}

		private void BeginDiagnosticsSession()
		{
			DiagnosticJournal journal = DiagnosticLog.Journal;
			if (journal != null && _diagnosticsSessionPending && (_controller != null || IsVerification))
			{
				_diagnosticsSessionPending = false;
				_controller?.RegisterDiagnostics(journal);
				journal.StartSession(SessionEnvironment());
				PublishDiagnosticSettings("session-start", full: true);
			}
		}

		private void PublishDiagnosticSettings(string label, bool full = false)
		{
			DiagnosticLog.Journal?.PublishSettings(label, EffectiveSettings(), full);
		}

		public void NoteShortcutRegistration(bool allRegistered, string error)
		{
			_shortcutRegistration = (allRegistered ? "all Windows hotkeys registered" : ("failed: " + error));
			PublishDiagnosticSettings("shortcuts-registered");
		}

		private Dictionary<string, string> EffectiveSettings()
		{
			Dictionary<string, string> dictionary = SettingsSnapshot.Flatten(Settings, "settings.");
			GeneralSettings general = Settings.General;
			CorrectionSettings correction = Settings.Correction;
			TypingEngine typingEngine = TypingEnginePolicy.Resolve(general.TypingMode, correction.Engine);
			dictionary["effective.enabled"] = (general.Enabled && !_typingSuspended).ToString(CultureInfo.InvariantCulture);
			dictionary["effective.typingMode"] = general.TypingMode.ToString();
			dictionary["effective.uiLanguage"] = TextCatalog.Language.ToString();
			dictionary["effective.correctionMode"] = correction.Mode.ToString();
			dictionary["effective.priority"] = correction.AmbiguousInputPriority.ToString();
			dictionary["effective.wordForms"] = correction.WordFormRecognition.ToString();
			dictionary["effective.trackEditorOwnedCorrections"] = (general.TypingMode == TypingMode.AutomaticCorrection && correction.TrackEditorOwnedCorrections).ToString(CultureInfo.InvariantCulture);
			dictionary["effective.learnEnglishFromManualCorrections"] = correction.LearnEnglishFromManualCorrections.ToString(CultureInfo.InvariantCulture);
			dictionary["effective.trackTextServiceCorrections"] = (general.TypingMode == TypingMode.AutomaticCorrection && correction.TrackTextServiceCorrections).ToString(CultureInfo.InvariantCulture);
			dictionary["effective.lastWord.savesToPersonalDictionary"] = Settings.SavesLastWordCorrections.ToString(CultureInfo.InvariantCulture);
			dictionary["effective.engine.requested"] = correction.Engine.ToString();
			dictionary["effective.engine.resolvedByPolicy"] = typingEngine.ToString();
			dictionary["effective.engine.policy"] = ((correction.Engine == typingEngine) ? "only Smart runs (ADR-056)" : $"only Smart runs (ADR-056); the stored {correction.Engine} is frozen in the code and not run");
			dictionary["effective.engine.running"] = ((_controller == null) ? "no controller (verification session)" : _controller.RunningEngine.ToString());
			IReadOnlyList<InstalledKeyboardLayout> installed = KeyboardLayoutInventory.GetInstalled();
			KeyboardLayoutPair keyboardLayoutPair = KeyboardLayoutInventory.ResolvePair(installed, general.PreferredEnglishLayoutId, general.PreferredPersianLayoutId, general.PersianKeyboardLayout);
			PersianKeyboardLayout setting = KeyboardLayoutInventory.ResolveMapping(general.PersianKeyboardLayout, keyboardLayoutPair.Persian);
			dictionary["effective.mapping.selected"] = general.PersianKeyboardLayout.ToString();
			dictionary["effective.mapping.resolved"] = setting.ToString();
			dictionary["effective.mapping.version"] = KeyboardLayoutRegistry.GetTargetIdentity(setting);
			dictionary["effective.mapping.english"] = KeyboardLayoutRegistry.SourceIdentity;
			dictionary["effective.layoutPair.english"] = keyboardLayoutPair.English?.Klid ?? "none";
			dictionary["effective.layoutPair.persian"] = keyboardLayoutPair.Persian?.Klid ?? "none";
			dictionary["windows.installedInputLayouts"] = string.Join("; ", installed.Select((InstalledKeyboardLayout l) => $"{l.DisplayName} [{l.Klid} {l.Language}]"));
			dictionary["effective.shortcuts.registration"] = _shortcutRegistration;
			dictionary["effective.textService.installed"] = TextServiceInstalled.ToString(CultureInfo.InvariantCulture);
			dictionary["effective.textService.published"] = (_textServicePublication != null).ToString(CultureInfo.InvariantCulture);
			dictionary["effective.textService.hosts"] = string.Join(';', TextServiceHosts.Select((TextServiceHost h) => h.Executable + (h.TextStoreIsAuthoritative ? "" : "(unconfirmed)")));
			if (_controller != null)
			{
				dictionary["effective.shortcuts.convertPreviousWordOnHook"] = _controller.PreviousWordOnHookAvailable.ToString(CultureInfo.InvariantCulture);
				dictionary["effective.shortcuts.hotkeyEditCommands"] = _controller.HotkeyEditCommandsAvailable.ToString(CultureInfo.InvariantCulture);
			}
			dictionary["dictionary.builtinEnglish"] = DescribeDictionaryFile(DictionaryPaths.BuiltinEnglish, _lexicon.BuiltinEnglishWordCount);
			dictionary["dictionary.builtinPersian"] = DescribeDictionaryFile(DictionaryPaths.BuiltinPersian, _lexicon.BuiltinPersianWordCount);
			dictionary["dictionary.persianAdditions"] = ((_lexicon.CommonPersianAdditionCount > 0) ? (DescribeDictionaryFile(DictionaryPaths.PersianCommonAdditions, _lexicon.CommonPersianAdditionCount) + "; loaded") : "off");
			dictionary["dictionary.detectionMetadata"] = DescribeDictionaryFile(DictionaryPaths.Metadata, -1);
			dictionary["dictionary.userEntries"] = _lexicon.GetUserEntries().Count.ToString(CultureInfo.InvariantCulture);
			return dictionary;
		}

		private static string DescribeDictionaryFile(string path, int count)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(path);
				string text = (fileInfo.Exists ? $"{fileInfo.Length} bytes, modified {fileInfo.LastWriteTimeUtc:yyyy-MM-ddTHH:mm:ssZ}" : "file missing");
				return (count >= 0) ? $"{count} words; {text}" : text;
			}
			catch (IOException)
			{
				return "unreadable";
			}
		}

		private Dictionary<string, string> SessionEnvironment()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				["app.version"] = App.Version,
				["app.commit"] = BuildCommit(),
				["app.build"] = App.VersionAndBuild,
				["app.directory"] = AppContext.BaseDirectory,
				["app.installKind"] = InstallKind(),
				["os"] = RuntimeInformation.OSDescription,
				["os.version"] = Environment.OSVersion.VersionString,
				["runtime"] = RuntimeInformation.FrameworkDescription,
				["process.architecture"] = RuntimeInformation.ProcessArchitecture.ToString(),
				["os.architecture"] = RuntimeInformation.OSArchitecture.ToString(),
				["profile.settingsDirectory"] = Environment.GetEnvironmentVariable("SMARTINPUT_SETTINGS_DIRECTORY") ?? "(default: %APPDATA%\\SmartInput)",
				["profile.isolated"] = (IsVerification || !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("SMARTINPUT_SETTINGS_DIRECTORY"))).ToString(CultureInfo.InvariantCulture),
				["log.path"] = DiagnosticLog.CurrentPath ?? "(none)",
				["log.format"] = "compact v" + 1.ToString(CultureInfo.InvariantCulture),
				["log.detail"] = ((DiagnosticLog.Detail == DiagnosticDetail.Full) ? "full: every word and context event as it completes, plus incidents and per-application summaries (SMARTINPUT_LOG_DETAIL=incidents for incident windows only)" : "incidents: incident windows, aggregates and per-application summaries only (SMARTINPUT_LOG_DETAIL=incidents)")
			};
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(14, 2, invariantCulture);
			handler.AppendFormatted(DiagnosticLog.Rotation.Files);
			handler.AppendLiteral(" files of ");
			handler.AppendFormatted(DiagnosticLog.Rotation.BytesEach / 1048576);
			handler.AppendLiteral(" MiB");
			dictionary["log.rotation"] = string.Create(invariantCulture, ref handler);
			dictionary["log.contains"] = "typed text, editor text samples and window titles of the typing targets; it stays on this PC";
			dictionary["log.debugForcedByPathVariable"] = _debugForcedByPath.ToString(CultureInfo.InvariantCulture);
			dictionary["windows.displayUILanguage"] = CultureInfo.CurrentUICulture.Name;
			dictionary["windows.installedUILanguage"] = CultureInfo.InstalledUICulture.Name;
			dictionary["windows.regionalCulture"] = CultureInfo.CurrentCulture.Name;
			dictionary["windows.observedTargetLayout"] = "not observed at session start (the foreground window is Diyar's own); see layout.observed events";
			Dictionary<string, string> dictionary2 = dictionary;
			foreach (System.Collections.DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
			{
				if (environmentVariable.Key is string text && text.StartsWith("SMARTINPUT_", StringComparison.OrdinalIgnoreCase))
				{
					dictionary2["override." + text] = environmentVariable.Value?.ToString() ?? string.Empty;
				}
			}
			return dictionary2;
		}

		private static string InstallKind()
		{
			string baseDirectory = AppContext.BaseDirectory;
			Environment.SpecialFolder[] array = new Environment.SpecialFolder[2]
			{
				Environment.SpecialFolder.ProgramFiles,
				Environment.SpecialFolder.ProgramFilesX86
			};
			for (int i = 0; i < array.Length; i++)
			{
				string folderPath = Environment.GetFolderPath(array[i]);
				if (folderPath.Length > 0 && baseDirectory.StartsWith(folderPath.TrimEnd('\\') + "\\", StringComparison.OrdinalIgnoreCase))
				{
					return "installed (Program Files)";
				}
			}
			return "portable";
		}

		private static string BuildCommit()
		{
			if (App.Commit != "unknown")
			{
				return App.Commit;
			}
			try
			{
				string path = System.IO.Path.Combine(AppContext.BaseDirectory, "BUILD-INFO.txt");
				if (File.Exists(path))
				{
					return File.ReadLines(path).FirstOrDefault((string l) => l.StartsWith("Commit:", StringComparison.OrdinalIgnoreCase)) ?? "BUILD-INFO.txt has no Commit line";
				}
			}
			catch (IOException)
			{
			}
			return typeof(TypingSession).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "unknown";
		}

		internal void LogLaunch(string[] arguments, bool windowVisible)
		{
			if (!DiagnosticLog.IsEnabled)
			{
				return;
			}
			string text;
			try
			{
				using Process process = Process.GetCurrentProcess();
				text = ((long)(DateTime.Now - process.StartTime).TotalMilliseconds).ToString(CultureInfo.InvariantCulture) + " ms";
			}
			catch (System.Exception ex) when ((ex is InvalidOperationException || ex is Win32Exception || ex is NotSupportedException) ? true : false)
			{
				text = "unknown";
			}
			bool flag = arguments.Contains("--startup");
			System.TimeSpan timeSpan = System.TimeSpan.FromMilliseconds(Environment.TickCount64);
			DiagnosticLog.Command("app.launch", "args", string.Join(' ', from argument in arguments.Skip(1)
				select DiagnosticLog.Escaped(argument)), "startupArgument", flag, "runAtStartupSetting", Settings.General.RunAtWindowsStartup?.ToString() ?? "unset", "registeredStartup", _startup?.DescribeForLog() ?? "not read (isolated profile)", "systemUptimeMs", Environment.TickCount64, "systemUptime", $"{(int)timeSpan.TotalHours}h {timeSpan.Minutes}m {timeSpan.Seconds}s", "processAge", text, "mainWindow", flag ? "started hidden to the tray (--startup)" : "shown (activated)", "windowVisibleAfter", windowVisible, "version", App.VersionAndBuild, "pid", Environment.ProcessId);
		}

		private string DescribeControllerForLog()
		{
			int bufferVersion;
			return _controller?.DescribeCommandStateForLog(out bufferVersion) ?? "no controller";
		}

		private static void LogAddWord(AddWordLog point)
		{
			if (DiagnosticLog.IsEnabled)
			{
				switch (point)
				{
				case AddWordLog.Start:
					DiagnosticLog.Command("cmd.add-word", "stage", "start", "command", "Add selected word to dictionary", "route", "UI Automation TextPattern (no clipboard, no key)");
					break;
				case AddWordLog.CancelledBeforeRead:
					DiagnosticLog.Command("cmd.add-word", "stage", "result", "outcome", "Cancelled", "reason", "a key, click, focus, settings or layout change arrived between the shortcut and the read");
					break;
				case AddWordLog.CancelledAfterRead:
					DiagnosticLog.Command("cmd.add-word", "stage", "result", "outcome", "Cancelled", "reason", "input changed while the selection was being read; the text read is dropped");
					break;
				case AddWordLog.Busy:
					DiagnosticLog.Command("cmd.add-word", "stage", "result", "outcome", "Error", "reason", "another selection read is still running (busy)");
					break;
				case AddWordLog.TimedOut:
					DiagnosticLog.Command("cmd.add-word", "stage", "result", "outcome", "Error", "reason", "the editor did not answer the selection read in time", "timeoutMs", (long)SelectionReadTimeout.TotalMilliseconds);
					break;
				default:
					DiagnosticLog.Command("cmd.add-word", "stage", "result", "outcome", "Error", "reason", "the selection read failed");
					break;
				}
			}
		}

		private static void LogAddWordRead(ExplicitSelectionRead read)
		{
			if (DiagnosticLog.IsEnabled)
			{
				DiagnosticLog.Command("cmd.add-word", "stage", "read", "route", "TextPattern", "isRead", read.IsRead, "text", DiagnosticLog.Escaped(read.Text), "length", read.Text.Length, "refused", read.IsRead ? "none" : "disabled or protected field, or the editor's selection was not readable through TextPattern (the injector does not say which)");
				if (!read.IsRead)
				{
					DiagnosticLog.Command("cmd.add-word", "stage", "result", "outcome", "Error", "reason", "selection not read");
				}
			}
		}

		public async Task<string?> RunShortcutAsync(int command, InputMarker marker = default(InputMarker))
		{
			TypingAssistantController controller = _controller;
			if (controller == null || !DiagnosticLog.IsEnabled)
			{
				return await RunShortcutCoreAsync(command, marker);
			}
			string name = ShortcutLogName(command);
			long started = Environment.TickCount64;
			string text = controller.DescribeCommandStateForLog(out var versionBefore);
			DiagnosticLog.Command("cmd.shortcut", "stage", "start", "command", name, "id", command, "route", "registered hotkey, window thread", "before", text);
			string notice = null;
			string outcome = "Completed";
			try
			{
				notice = await RunShortcutCoreAsync(command, marker);
				if (notice != null)
				{
					outcome = "Completed with a notice";
				}
				return notice;
			}
			catch (System.Exception ex)
			{
				outcome = "Threw " + ex.GetType().Name;
				throw;
			}
			finally
			{
				string text2 = controller.DescribeCommandStateForLog(out var bufferVersion);
				DiagnosticLog.Command("cmd.shortcut", "stage", "result", "command", name, "outcome", outcome, "noticeShown", notice != null, "noticeLength", notice?.Length ?? 0, "ms", Environment.TickCount64 - started, "bufferVersion", $"{versionBefore}->{bufferVersion}", "bufferUpdated", versionBefore != bufferVersion, "after", text2);
			}
		}

		private static string ShortcutLogName(int command)
		{
			return command switch
			{
				0 => "Toggle last typed word (text service owns it; the registered hotkey only answers)", 
				1 => "Undo last translation", 
				2 => "Convert selected word (registered-hotkey route)", 
				3 => "Add selected word to dictionary", 
				4 => "Translate selected text", 
				5 => "Convert non-dictionary words (no route in this build)", 
				6 => "Undo last manual correction", 
				7 => "Translate clipboard text", 
				8 => "Pause or resume typing", 
				_ => "Unknown command " + command, 
			};
		}

		private void WriteLegacySessionLines()
		{
			GeneralSettings general = Settings.General;
			CorrectionSettings correction = Settings.Correction;
			DiagnosticMessageHandler message = new DiagnosticMessageHandler(52, 3, out var shouldAppend);
			if (shouldAppend)
			{
				message.AppendLiteral("Debug mode on (legacy verbose log). Diyar ");
				message.AppendFormatted(App.VersionAndBuild);
				message.AppendLiteral(", ");
				message.AppendFormatted(Environment.OSVersion);
				message.AppendLiteral(", .NET ");
				message.AppendFormatted(Environment.Version);
				message.AppendLiteral(".");
			}
			DiagnosticLog.Write("Session", ref message);
			IReadOnlyList<InstalledKeyboardLayout> installed = KeyboardLayoutInventory.GetInstalled(refresh: true);
			KeyboardLayoutPair keyboardLayoutPair = KeyboardLayoutInventory.ResolvePair(installed, general.PreferredEnglishLayoutId, general.PreferredPersianLayoutId, general.PersianKeyboardLayout);
			DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(67, 4, out shouldAppend);
			if (shouldAppend)
			{
				message2.AppendLiteral("Installed layouts: ");
				message2.AppendFormatted(string.Join(", ", installed.Select((InstalledKeyboardLayout l) => $"{l.DisplayName} [{l.Klid} {l.Language}]")));
				message2.AppendLiteral(". Default pair: English=");
				message2.AppendFormatted(keyboardLayoutPair.English?.Klid ?? "none");
				message2.AppendLiteral(" Persian=");
				message2.AppendFormatted(keyboardLayoutPair.Persian?.Klid ?? "none");
				message2.AppendLiteral("; key mapping=");
				message2.AppendFormatted(KeyboardLayoutInventory.ResolveMapping(general.PersianKeyboardLayout, keyboardLayoutPair.Persian));
				message2.AppendLiteral(".");
			}
			DiagnosticLog.Write("Session", ref message2);
			DiagnosticMessageHandler message3 = new DiagnosticMessageHandler(1176, 49, out shouldAppend);
			if (shouldAppend)
			{
				message3.AppendLiteral("Settings: enabled=");
				message3.AppendFormatted(general.Enabled);
				message3.AppendLiteral(" mode=");
				message3.AppendFormatted(general.TypingMode);
				message3.AppendLiteral(" correction=");
				message3.AppendFormatted(correction.Mode);
				message3.AppendLiteral(" capsLock=");
				message3.AppendFormatted(general.CapsLockBehavior);
				message3.AppendLiteral(" englishHoldKey=");
				message3.AppendFormatted(correction.EnglishHoldKey);
				message3.AppendLiteral(" persianHoldKey=");
				message3.AppendFormatted(correction.PersianHoldKey);
				message3.AppendLiteral(" holdKeyYieldsToShortcuts=");
				message3.AppendFormatted(correction.HoldKeyYieldsToShortcuts);
				message3.AppendLiteral(" heldBoundaryEndsEnglishLock=");
				message3.AppendFormatted(correction.HeldBoundaryEndsEnglishLock);
				message3.AppendLiteral(" holdLanguage=");
				message3.AppendFormatted(correction.HoldLanguage);
				message3.AppendLiteral(" keyboard=");
				message3.AppendFormatted(general.PersianKeyboardLayout);
				message3.AppendLiteral(" typos=");
				message3.AppendFormatted(correction.CorrectPersianTypos);
				message3.AppendLiteral(" stabilize=");
				message3.AppendFormatted(correction.StabilizeMixedDirectionText);
				message3.AppendLiteral(" backspaceUndo=");
				message3.AppendFormatted(correction.UndoConversionOnBackspace);
				message3.AppendLiteral(" backspaceReopen=");
				message3.AppendFormatted(correction.ReopenConvertedWordOnBackspace);
				message3.AppendLiteral(" capsLockManualTypesDirectly=");
				message3.AppendFormatted(correction.CapsLockManualTypesDirectly);
				message3.AppendLiteral(" directTypingAllLayoutCharacters=");
				message3.AppendFormatted(correction.DirectTypingTypesAllLayoutCharacters);
				message3.AppendLiteral(" wawAtOnceOnlyInPersianWords=");
				message3.AppendFormatted(correction.WawAtOnceOnlyInPersianWords);
				message3.AppendLiteral(" protectPaymentFields=");
				message3.AppendFormatted(correction.ProtectPaymentFields);
				message3.AppendLiteral(" amounts=");
				message3.AppendFormatted(correction.FormatPersianAmounts);
				message3.AppendLiteral(" guardAmountExpansion=");
				message3.AppendFormatted(correction.GuardAmountExpansion);
				message3.AppendLiteral(" shiftSwitchKeepsEmbeddingOpen=");
				message3.AppendFormatted(general.ShiftSwitchKeepsEmbeddingOpen);
				message3.AppendLiteral(" paragraphDirectionPrefix=");
				message3.AppendFormatted(correction.ParagraphDirectionPrefix);
				message3.AppendLiteral(" rewriteParagraphStartForDirection=");
				message3.AppendFormatted(correction.RewriteParagraphStartForDirection);
				message3.AppendLiteral(" trackEditorOwned=");
				message3.AppendFormatted(correction.TrackEditorOwnedCorrections);
				message3.AppendLiteral(" trackTextService=");
				message3.AppendFormatted(correction.TrackTextServiceCorrections);
				message3.AppendLiteral(" learnEnglishFromManualCorrections=");
				message3.AppendFormatted(correction.LearnEnglishFromManualCorrections);
				message3.AppendLiteral(" resetWordOnLayoutChange=");
				message3.AppendFormatted(correction.ResetWordOnLayoutChange);
				message3.AppendLiteral(" guardVisibleFirstTokenRecovery=");
				message3.AppendFormatted(correction.GuardVisibleFirstTokenRecovery);
				message3.AppendLiteral(" visibleRecoveryNeedsTypedKeys=");
				message3.AppendFormatted(correction.VisibleRecoveryNeedsTypedKeys);
				message3.AppendLiteral(" persianHoldContext=");
				message3.AppendFormatted(correction.PersianHoldIsPersianContext);
				message3.AppendLiteral(" persianOnlyKeyTypo=");
				message3.AppendFormatted(correction.PersianOnlyKeyMayBeEnglishTypo);
				message3.AppendLiteral(" commonPersianAdditions=");
				message3.AppendFormatted(correction.CommonPersianAdditions);
				message3.AppendLiteral(" punctuationKeyWordsConvert=");
				message3.AppendFormatted(correction.PunctuationKeyWordsConvert);
				message3.AppendLiteral(" persianDigits=");
				message3.AppendFormatted(correction.PersianDigitsInPersianText);
				message3.AppendLiteral(" capitalizeEnglishAfterPersian=");
				message3.AppendFormatted(correction.CapitalizeEnglishAfterPersian);
				message3.AppendLiteral(" keepEnglishInEnglishOnlyApps=");
				message3.AppendFormatted(correction.KeepEnglishInEnglishOnlyApps);
				message3.AppendLiteral(" keepNonTextTargetsUntouched=");
				message3.AppendFormatted(correction.KeepNonTextTargetsUntouched);
				message3.AppendLiteral(" englishOnlyPlacesTurnedOff=");
				message3.AppendFormatted(correction.EnglishOnlyPlacesTurnedOff ?? PlaceIdList.Empty);
				message3.AppendLiteral(" contextualIgnoresCapitalized=");
				message3.AppendFormatted(correction.ContextualIgnoresCapitalizedTerms);
				message3.AppendLiteral(" restoreContextAfterRetype=");
				message3.AppendFormatted(correction.RestoreContextAfterRetype);
				message3.AppendLiteral(" forgetContextWhenTypedTextIsDeleted=");
				message3.AppendFormatted(correction.ForgetContextWhenTypedTextIsDeleted);
				message3.AppendLiteral(" reopenNeedsTrustedEditor=");
				message3.AppendFormatted(correction.ReopenNeedsTrustedEditor);
				message3.AppendLiteral(" shortWordsIgnoreCapitalizedTerms=");
				message3.AppendFormatted(correction.ShortWordsIgnoreCapitalizedTerms);
				message3.AppendLiteral(" bilingualKeptWordIsNeutralContext=");
				message3.AppendFormatted(correction.BilingualKeptWordIsNeutralContext);
				message3.AppendLiteral(" directionMarksAreWordBoundary=");
				message3.AppendFormatted(correction.DirectionMarksAreWordBoundary);
				message3.AppendLiteral(" persianOnlyKeyInsertionTypo=");
				message3.AppendFormatted(correction.PersianOnlyKeyInsertionMayBeEnglishTypo);
				message3.AppendLiteral(" punctuationFollowsWordBeforeCaret=");
				message3.AppendFormatted(correction.PunctuationFollowsWordBeforeCaret);
				message3.AppendLiteral(" periodMarkWaitsForBoundary=");
				message3.AppendFormatted(correction.PeriodMarkWaitsForBoundary);
				message3.AppendLiteral(" windowsHardwareKeyboardAutocorrect=");
				message3.AppendFormatted(HardwareKeyboardAutocorrectForLog());
				message3.AppendLiteral(".");
			}
			DiagnosticLog.Write("Session", ref message3);
		}

		private static string HardwareKeyboardAutocorrectForLog()
		{
			HardwareKeyboardAutocorrect.RefreshIfStale();
			return HardwareKeyboardAutocorrect.Describe();
		}

		public ProblemCapture CaptureProblemReport()
		{
			string foregroundAtCapture = DescribeWindow(((IntPtr)GetForegroundWindow()).ToInt64());
			DiagnosticJournal journal = DiagnosticLog.Journal;
			return new ProblemCapture((journal == null) ? Task.FromResult(string.Empty) : journal.CaptureReport(null, "problem"), foregroundAtCapture);
		}

		public async Task<string?> SaveProblemReportAsync(ProblemCapture capture, string? expected)
		{
			string text = await capture.Report;
			if (text.Length == 0)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (!string.IsNullOrWhiteSpace(expected))
			{
				stringBuilder.Append("\"expected\":\"").Append(DiagnosticJournal.Escape((expected.Length > 200) ? expected.Substring(0, 200) : expected)).Append("\",");
			}
			stringBuilder.Append("\"capturedWhileForeground\":\"").Append(DiagnosticJournal.Escape(capture.ForegroundAtCapture)).Append("\",");
			(string, long)? tuple = DiagnosticReports.LastTypingWindow(text);
			if (tuple.HasValue)
			{
				(string, long) valueOrDefault = tuple.GetValueOrDefault();
				long @int = JsonDocument.Parse(text).RootElement.GetProperty("ms").GetInt64();
				stringBuilder.Append("\"lastTypingTarget\":\"").Append(DiagnosticJournal.Escape(DescribeWindow(Convert.ToInt64(valueOrDefault.Item1, 16)) + "; a window, not proof of the field; newest record " + DiagnosticReports.DescribeAge(@int, valueOrDefault.Item2))).Append("\",");
			}
			else
			{
				stringBuilder.Append("\"lastTypingTarget\":\"no word or invalidation recorded a window in the retained history\",");
			}
			text = "{\"t\":\"report\"," + stringBuilder?.ToString() + text.Substring("{\"t\":\"report\",".Length);
			string reportsDirectory = DiagnosticLog.ReportsDirectory;
			Directory.CreateDirectory(reportsDirectory);
			string path = System.IO.Path.Combine(reportsDirectory, $"problem-{DateTime.Now:yyyyMMdd-HHmmss-fff}.json");
			await File.WriteAllTextAsync(path, text, Encoding.UTF8);
			return path;
		}

		private static string DescribeWindow(long handle)
		{
			nint window = new IntPtr(handle);
			if (handle == 0L || !IsWindow(window))
			{
				if (handle != 0L)
				{
					return $"0x{handle:X} (no longer exists)";
				}
				return "none";
			}
			GetWindowThreadProcessId(window, out var processId);
			string value = "unknown process";
			try
			{
				value = Process.GetProcessById((int)processId).ProcessName;
			}
			catch (System.Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException || ex is Win32Exception) ? true : false)
			{
			}
			StringBuilder stringBuilder = new StringBuilder(128);
			GetClassName(window, stringBuilder, stringBuilder.Capacity);
			return $"0x{handle:X}: process {value}, window class {stringBuilder}";
		}

		[DllImport("user32.dll")]
		private static extern nint GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern bool IsWindow(nint window);

		[DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(nint window, out uint processId);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern int GetClassName(nint window, StringBuilder text, int maxCount);

		private static void EnsureTextServiceEnabledForUser()
		{
			string textServiceDllPath = TextServiceDllPath;
			if (textServiceDllPath == null)
			{
				return;
			}
			string ctl = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(textServiceDllPath), "CoCoTextServiceCtl.exe");
			if (ctl == null || !File.Exists(ctl))
			{
				return;
			}
			Task.Run(() =>
			{
				bool shouldAppend = default;
				try
				{
					using Process process = Process.Start(new ProcessStartInfo(ctl, "ensure-enabled")
					{
						CreateNoWindow = true,
						UseShellExecute = false,
						RedirectStandardOutput = true
					});
					string value = process?.StandardOutput.ReadToEnd().Trim();
					process?.WaitForExit(10000);
					DiagnosticMessageHandler message = new DiagnosticMessageHandler(24, 2, out shouldAppend);
					if (shouldAppend)
					{
						message.AppendLiteral("ensure-enabled: ");
						message.AppendFormatted(value);
						message.AppendLiteral(" (exit ");
						message.AppendFormatted(process?.ExitCode);
						message.AppendLiteral(")");
					}
					DiagnosticLog.Write("TextService", ref message);
				}
				catch (System.Exception ex) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					shouldAppend = ((ex is Win32Exception || ex is InvalidOperationException || ex is IOException) ? true : false);
					return shouldAppend;
				}).Invoke())
				{
					DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(30, 1, out var shouldAppend2);
					if (shouldAppend2)
					{
						message2.AppendLiteral("ensure-enabled could not run: ");
						message2.AppendFormatted(ex.GetType().Name);
					}
					DiagnosticLog.Write("TextService", ref message2);
				}
			});
		}

		private void StartTextService()
		{
			if (IsVerification || _controller == null || _textServiceBroker != null)
			{
				return;
			}
			SynchronizationContext context = SynchronizationContext.Current;
			ManualCorrectionCoordinator coordinator = (_textServiceCoordinator = new ManualCorrectionCoordinator(() => _controller.ManualMapping, () => Settings.SavesSelectedWordCorrections, new CorrectionLearningService(Dictionary, () => DiagnosticLog.Journal, "selectedword", _english), Dispatch, (string obj) =>
			{
				ShortcutNotice?.Invoke(obj);
				Changed?.Invoke();
			}, TextServiceHosts, null, (string outcome) =>
			{
				DiagnosticMessageHandler message3 = new DiagnosticMessageHandler(21, 1, out var shouldAppend3);
				if (shouldAppend3)
				{
					message3.AppendLiteral("deferred first word: ");
					message3.AppendFormatted(outcome);
				}
				DiagnosticLog.Write("TextService", ref message3);
				DiagnosticLog.Journal?.Tally("deferred.result." + DeferredResult(outcome));
			}, () => Settings.SavesLastWordCorrections, (string source, string target) =>
			{
				_controller?.NoteEditorOwnedCorrectionVerified(source, target);
			}, DescribeControllerForLog, () => _controller?.CaptureTextServiceMarker(), (TextServiceEdit edit) =>
			{
				_controller?.NoteTextServiceWordReplaced(edit);
			}, (string command) => _controller?.TextServiceEditWouldBeRecorded(command) ?? false));
			_controller.EditorOwnedCorrection = RequestDeferredFirstWord;
			_controller.CancelEditorOwnedCorrection = () =>
			{
				_textServiceCoordinator?.CancelPending();
			};
			bool shouldAppend = default;
			DiagnosticMessageHandler message = new DiagnosticMessageHandler(21, 2, out shouldAppend);
			if (shouldAppend)
			{
				message.AppendLiteral("Diyar ");
				message.AppendFormatted(App.VersionAndBuild);
				message.AppendLiteral("; text service ");
				message.AppendFormatted(TextServiceDllPath ?? "NOT INSTALLED");
			}
			DiagnosticLog.Write("TextService", ref message);
			if (TextServiceInstalled)
			{
				EnsureTextServiceEnabledForUser();
			}
			else
			{
				TextServiceProblem = TextServiceMissingMessage;
			}
			try
			{
				_textServicePublication = new TextServicePublication();
				_textServiceBroker = new TextServiceBroker(coordinator);
				_textServiceBroker.Start();
				PublishTextService();
			}
			catch (System.Exception ex) when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				shouldAppend = ((ex is IOException || ex is UnauthorizedAccessException || ex is WaitHandleCannotBeOpenedException) ? true : false);
				return shouldAppend;
			}).Invoke())
			{
				TextServiceProblem = MessageText.Format(MessageKey.ManualCorrectionCouldNotStart, ex.Message);
				DiagnosticMessageHandler message2 = new DiagnosticMessageHandler(21, 1, out var shouldAppend2);
				if (shouldAppend2)
				{
					message2.AppendLiteral("broker start failed: ");
					message2.AppendFormatted(ex.GetType().Name);
				}
				DiagnosticLog.Write("TextService", ref message2);
			}
			void Dispatch(Action action)
			{
				if (context == null)
				{
					action();
				}
				else
				{
					context.Post((object? _) =>
					{
						action();
					}, null);
				}
			}
		}

		private void PublishTextService()
		{
			if (_textServicePublication == null || _textServiceBroker == null)
			{
				return;
			}
			TextServiceChord? textServiceChord = ChordOf(Settings.Hotkeys.ToggleSelectedText);
			TextServiceChord? textServiceChord2 = ChordOf(Settings.Hotkeys.UndoManualCorrection);
			bool flag = textServiceChord.HasValue && textServiceChord.GetValueOrDefault().IsValid && textServiceChord2.HasValue && textServiceChord2.GetValueOrDefault().IsValid && textServiceChord != textServiceChord2;
			TypingSession typingSession = this;
			string textServiceProblem;
			if (flag)
			{
				textServiceProblem = (TextServiceInstalled ? string.Empty : TextServiceMissingMessage);
			}
			else
			{
				textServiceProblem = MessageText.Get(MessageKey.ManualChordsMustDiffer);
			}
			typingSession.TextServiceProblem = textServiceProblem;
			bool flag2 = (Settings.General.Enabled && !_typingSuspended) & flag;
			TextServiceChord? textServiceChord3 = (Settings.LastWord.Enabled ? ChordOf(Settings.Hotkeys.ConvertPreviousWord) : ((TextServiceChord?)null));
			if (!textServiceChord3.HasValue || !textServiceChord3.GetValueOrDefault().IsValid || textServiceChord3 == textServiceChord || textServiceChord3 == textServiceChord2)
			{
				textServiceChord3 = null;
			}
			string[] array = TextServiceHostPolicy.Published(TextServiceHosts).ToArray();
			bool directionMarksAreWordBoundary = Settings.Correction.DirectionMarksAreWordBoundary;
			string text = $"{flag2}|{textServiceChord}|{textServiceChord2}|{textServiceChord3}|{directionMarksAreWordBoundary}|{string.Join('|', array)}";
			if (text == _publishedTextServiceSignature)
			{
				return;
			}
			bool shouldAppend = default;
			try
			{
				_textServicePublication.Publish(new TextServicePublicationContent(Environment.ProcessId, _textServiceBroker.FullPipeName, _textServiceBroker.Token, ++_textServiceRevision, flag2, array, textServiceChord.GetValueOrDefault(), textServiceChord2.GetValueOrDefault(), textServiceChord3.GetValueOrDefault(), directionMarksAreWordBoundary));
				_publishedTextServiceSignature = text;
				DiagnosticMessageHandler message = new DiagnosticMessageHandler(74, 7, out shouldAppend);
				if (shouldAppend)
				{
					message.AppendLiteral("published revision ");
					message.AppendFormatted(_textServiceRevision);
					message.AppendLiteral(" enabled=");
					message.AppendFormatted(flag2);
					message.AppendLiteral(" convert=");
					message.AppendFormatted(Settings.Hotkeys.ToggleSelectedText);
					message.AppendLiteral(" undo=");
					message.AppendFormatted(Settings.Hotkeys.UndoManualCorrection);
					message.AppendLiteral(" lastWord=");
					message.AppendFormatted((!textServiceChord3.HasValue) ? "off" : Settings.Hotkeys.ConvertPreviousWord);
					message.AppendLiteral(" markBoundary=");
					message.AppendFormatted(directionMarksAreWordBoundary);
					message.AppendLiteral(" hosts=");
					message.AppendFormatted(string.Join('|', array));
				}
				DiagnosticLog.Write("TextService", ref message);
				string environmentVariable = Environment.GetEnvironmentVariable("SMARTINPUT_STATE_REPORT");
				if (environmentVariable != null && environmentVariable.Length > 0)
				{
					File.WriteAllText(environmentVariable, JsonSerializer.Serialize(new
					{
						pid = Environment.ProcessId,
						revision = _textServiceRevision,
						enabled = flag2,
						effectiveSaves = Settings.SavesSelectedWordCorrections,
						convert = Settings.Hotkeys.ToggleSelectedText,
						undo = Settings.Hotkeys.UndoManualCorrection
					}));
				}
			}
			catch (System.Exception ex) when (((Func<bool>)delegate
			{
				// Could not convert BlockContainer to single expression
				shouldAppend = ((ex is IOException || ex is UnauthorizedAccessException) ? true : false);
				return shouldAppend;
			}).Invoke())
			{
				TextServiceProblem = MessageText.Format(MessageKey.ManualSettingsNotPublished, ex.Message);
			}
		}

		internal static string DeferredResult(string outcome)
		{
			int num = outcome.IndexOf(": ", StringComparison.Ordinal);
			if (num < 0)
			{
				return "unparsed";
			}
			string text = outcome.Substring(num + 2).TrimStart();
			int num2 = text.IndexOf(' ');
			string text2 = ((num2 < 0) ? text : text.Substring(0, num2));
			if (text2.Length != 0)
			{
				return text2;
			}
			return "empty";
		}

		private static TextServiceChord? ChordOf(string value)
		{
			if (!HotkeyGesture.TryParse(value, out HotkeyGesture gesture, out string _) || (gesture.Modifiers & 8) != 0)
			{
				return null;
			}
			return new TextServiceChord(gesture.VirtualKey, gesture.Modifiers & 7);
		}

		private bool RequestDeferredFirstWord(string source, string target)
		{
			ManualCorrectionCoordinator textServiceCoordinator = _textServiceCoordinator;
			if (textServiceCoordinator == null || _textServicePublication == null)
			{
				return false;
			}
			GetWindowThreadProcessId(GetForegroundWindow(), out var processId);
			if (processId == 0)
			{
				return false;
			}
			string executable;
			try
			{
				executable = Process.GetProcessById((int)processId).ProcessName + ".exe";
			}
			catch (System.Exception ex) when ((ex is ArgumentException || ex is InvalidOperationException) ? true : false)
			{
				return false;
			}
			if ((object)TextServiceHostPolicy.Find(TextServiceHosts, executable) == null)
			{
				return false;
			}
			if (!EventWaitHandle.TryOpenExisting($"Local\\CoCoTyping.TextService.Pending.{processId}", out EventWaitHandle result))
			{
				return false;
			}
			using (result)
			{
				textServiceCoordinator.ArmPending((int)processId, source, target);
				result.Set();
			}
			return true;
		}

		private void StopTextService()
		{
			_textServiceCoordinator?.CancelPending();
			if (_controller != null)
			{
				_controller.EditorOwnedCorrection = null;
				_controller.CancelEditorOwnedCorrection = null;
			}
			_textServiceCoordinator = null;
			_textServicePublication?.Dispose();
			_textServicePublication = null;
			_textServiceBroker?.Dispose();
			_textServiceBroker = null;
		}
	}
}
