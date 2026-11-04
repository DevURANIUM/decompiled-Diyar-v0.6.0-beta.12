using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Diyar.Setup.Logic;
using Microsoft.CodeAnalysis;
using Microsoft.Win32;
using WixToolset.BootstrapperApplicationApi;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETFramework,Version=v4.7.2", FrameworkDisplayName = ".NET Framework 4.7.2")]
[assembly: AssemblyCompany("Webpack")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) 2026 IranUX. All rights reserved.")]
[assembly: AssemblyFileVersion("0.6.302.37")]
[assembly: AssemblyInformationalVersion("0.6.0-beta.12+1067fa6d75b7fbb34a023a09c9716a95d6187838")]
[assembly: AssemblyProduct("Diyar")]
[assembly: AssemblyTitle("Diyar.Setup")]
[assembly: InternalsVisibleTo("Diyar.Setup.Tests")]
[assembly: AssemblyVersion("0.6.0.0")]
[module: RefSafetyRules(11)]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
	[CompilerGenerated]
	[Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
	[CompilerGenerated]
	[Embedded]
	[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
	internal sealed class RefSafetyRulesAttribute : Attribute
	{
		public readonly int Version;

		public RefSafetyRulesAttribute(int P_0)
		{
			Version = P_0;
		}
	}
}
namespace Diyar.Setup
{
	internal static class Capture
	{
		public static int Run(string folder)
		{
			Directory.CreateDirectory(folder);
			List<string> list = new List<string>();
			bool result = false;
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "release.ini");
			ReleaseInfo release = ReleaseInfo.Parse(File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>(), "0.6.0-beta.5");
			PageFacts facts = new PageFacts
			{
				DisplayVersion = "0.6.0-beta.5",
				InstalledVersion = "0.6.0-beta.4",
				DiyarRunning = true,
				Release = release
			};
			List<KeyValuePair<string, Action<SetupWindow>>> list2 = new List<KeyValuePair<string, Action<SetupWindow>>>
			{
				Page("install", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.Install, w.Text.Language), permissionRefused: false, (PlannedAction _) =>
					{
					});
				}),
				Page("install-other-app-language", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.Install, w.Text.Other.Language, startup: false), permissionRefused: false, (PlannedAction _) =>
					{
					});
				}),
				Page("install-permission", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.Install, w.Text.Language), permissionRefused: true, (PlannedAction _) =>
					{
					});
				}),
				Page("update", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.Update, w.Text.Language), permissionRefused: false, (PlannedAction _) =>
					{
					});
				}),
				Page("maintenance", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.Maintenance, w.Text.Language), permissionRefused: false, (PlannedAction _) =>
					{
					});
				}),
				Page("uninstall", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.Uninstall, w.Text.Language), permissionRefused: false, (PlannedAction _) =>
					{
					});
				}),
				Page("newer", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.NewerInstalled, w.Text.Language), permissionRefused: false, (PlannedAction _) =>
					{
					});
				}),
				Page("progress", (SetupWindow w) =>
				{
					w.ShowProgress(SetupPages.ProgressTitle(PlannedAction.Install, SetupMode.Update), SetupPages.ProgressStatus(PlannedAction.Install, SetupMode.Update), () =>
					{
					});
					w.SetProgress(45);
				}),
				Page("progress-cancelling", (SetupWindow w) =>
				{
					w.ShowProgress(SetupPages.ProgressTitle(PlannedAction.Install, SetupMode.Update), (SetupText t) => t.Cancelling, () =>
					{
					}, cancelling: true);
					w.SetProgress(45);
				}),
				Page("done-install", (SetupWindow w) =>
				{
					SetupPages.Done(w, With(facts, SetupMode.Install, w.Text.Language), new Outcome
					{
						Action = PlannedAction.Install,
						Succeeded = true,
						Started = true
					});
				}),
				Page("done-update", (SetupWindow w) =>
				{
					SetupPages.Done(w, With(facts, SetupMode.Update, w.Text.Language), new Outcome
					{
						Action = PlannedAction.Install,
						Succeeded = true,
						Started = true
					});
				}),
				Page("done-update-open", (SetupWindow w) =>
				{
					SetupPages.Done(w, With(facts, SetupMode.Update, w.Text.Language), new Outcome
					{
						Action = PlannedAction.Install,
						Succeeded = true,
						OpenDiyar = () =>
						{
						}
					});
				}),
				Page("done-restart", (SetupWindow w) =>
				{
					SetupPages.Done(w, With(facts, SetupMode.Uninstall, w.Text.Language), new Outcome
					{
						Action = PlannedAction.Uninstall,
						Succeeded = true,
						Restart = true
					});
				}),
				Page("failed", (SetupWindow w) =>
				{
					SetupPages.Done(w, With(facts, SetupMode.Update, w.Text.Language), new Outcome
					{
						Action = PlannedAction.Install,
						Error = "Error 1603: a sample Windows Installer message."
					});
				}),
				Page("help", (SetupWindow w) =>
				{
					SetupPages.Start(w, With(facts, SetupMode.Help, w.Text.Language), permissionRefused: false, (PlannedAction _) =>
					{
					});
				})
			};
			bool[] array = new bool[2] { false, true };
			foreach (bool flag in array)
			{
				SetupLanguage[] array2 = new SetupLanguage[2]
				{
					SetupLanguage.English,
					SetupLanguage.Persian
				};
				foreach (SetupLanguage setupLanguage in array2)
				{
					foreach (KeyValuePair<string, Action<SetupWindow>> item in list2)
					{
						string text = "setup-" + ((setupLanguage == SetupLanguage.Persian) ? "fa" : "en") + "-" + (flag ? "dark" : "light") + "-" + item.Key;
						try
						{
							Draw(System.IO.Path.Combine(folder, text + ".png"), SetupTheme.Load(flag), SetupText.For(setupLanguage), item.Value);
							list.Add("PASS " + text);
						}
						catch (Exception ex)
						{
							result = true;
							list.Add("FAIL " + text + ": " + ex.GetType().Name + ": " + ex.Message);
						}
					}
				}
			}
			File.WriteAllLines(System.IO.Path.Combine(folder, "capture-results.txt"), list);
			return result ? 1 : 0;
		}

		private static KeyValuePair<string, Action<SetupWindow>> Page(string name, Action<SetupWindow> draw)
		{
			return new KeyValuePair<string, Action<SetupWindow>>(name, draw);
		}

		private static PageFacts With(PageFacts facts, SetupMode mode, SetupLanguage appLanguage, bool startup = true)
		{
			return new PageFacts
			{
				Mode = mode,
				DisplayVersion = facts.DisplayVersion,
				InstalledVersion = facts.InstalledVersion,
				DiyarRunning = facts.DiyarRunning,
				Release = facts.Release,
				Choices = new InstallChoices
				{
					AppLanguage = appLanguage,
					Startup = startup
				}
			};
		}

		private static void Draw(string path, SetupTheme theme, SetupText text, Action<SetupWindow> page)
		{
			SetupWindow setupWindow = new SetupWindow(theme, text)
			{
				ShowActivated = false,
				ShowInTaskbar = false,
				WindowStartupLocation = WindowStartupLocation.Manual,
				FitToScreen = false,
				Left = -20000.0,
				Top = -20000.0
			};
			try
			{
				setupWindow.Show();
				page(setupWindow);
				setupWindow.Dispatcher.Invoke(() =>
				{
				}, DispatcherPriority.ApplicationIdle);
				FrameworkElement frameworkElement = (FrameworkElement)setupWindow.Content;
				RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)Math.Ceiling(frameworkElement.ActualWidth * 2.0), (int)Math.Ceiling(frameworkElement.ActualHeight * 2.0), 192.0, 192.0, PixelFormats.Pbgra32);
				DrawingVisual drawingVisual = new DrawingVisual();
				using (DrawingContext drawingContext = drawingVisual.RenderOpen())
				{
					drawingContext.DrawRectangle(theme.Background, null, new Rect(0.0, 0.0, frameworkElement.ActualWidth, frameworkElement.ActualHeight));
					if (setupWindow.FlowDirection == FlowDirection.RightToLeft)
					{
						drawingContext.PushTransform(new MatrixTransform(-1.0, 0.0, 0.0, 1.0, frameworkElement.ActualWidth, 0.0));
					}
					VisualBrush brush = new VisualBrush(frameworkElement)
					{
						ViewboxUnits = BrushMappingMode.Absolute,
						Viewbox = new Rect(0.0, 0.0, frameworkElement.ActualWidth, frameworkElement.ActualHeight),
						Stretch = Stretch.Fill
					};
					drawingContext.DrawRectangle(brush, null, new Rect(0.0, 0.0, frameworkElement.ActualWidth, frameworkElement.ActualHeight));
					if (setupWindow.FlowDirection == FlowDirection.RightToLeft)
					{
						drawingContext.Pop();
					}
				}
				renderTargetBitmap.Render(drawingVisual);
				PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
				pngBitmapEncoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
				using FileStream stream = File.Create(path);
				pngBitmapEncoder.Save(stream);
			}
			finally
			{
				setupWindow.Close();
			}
		}
	}
	internal sealed class DiyarBootstrapper : BootstrapperApplication
	{
		private const string MsiPackageId = "CoCoTypingMsi";

		private const int ErrorCancelled = -2147023673;

		private const int ErrorInstallUserExit = -2147023294;

		private readonly RunningDiyar _running;

		private IBootstrapperCommand? _command;

		private Dispatcher? _dispatcher;

		private SetupWindow? _window;

		private HwndSource? _hiddenOwner;

		private IntPtr _windowHandle;

		private SetupLanguage _language;

		private readonly InstallChoices _choices = new InstallChoices();

		private ReleaseInfo _release = ReleaseInfo.Parse(Array.Empty<string>(), string.Empty);

		private bool _testBuild;

		private string _bundleVersion = string.Empty;

		private string _displayVersion = string.Empty;

		private string _installedVersion = string.Empty;

		private bool _packagePresent;

		private bool _relatedOlder;

		private bool _relatedNewer;

		private readonly HashSet<string> _replacedNewer = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		private SetupMode _mode = SetupMode.Unsupported;

		private PlannedAction _planned;

		private bool _windowShown;

		private bool _applying;

		private bool _executeBegan;

		private volatile bool _cancelRequested;

		private volatile bool _pastPointOfNoReturn;

		private Func<SetupText, string> _progressStatus = (SetupText t) => t.WaitingForPermission;

		private string? _lastError;

		private int _exitCode;

		private bool _restartRequired;

		private bool RunByAnotherSetup
		{
			get
			{
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0014: Invalid comparison between Unknown and I4
				if (_command != null)
				{
					return (int)_command.Relation > 0;
				}
				return false;
			}
		}

		public DiyarBootstrapper()
		{
			_running = new RunningDiyar(Log);
			((BootstrapperApplication)this).DetectRelatedBundle += Guard<DetectRelatedBundleEventArgs>("DetectRelatedBundle", (EventHandler<DetectRelatedBundleEventArgs>)OnRelatedBundle, false);
			((BootstrapperApplication)this).PlanRelatedBundleType += Guard<PlanRelatedBundleTypeEventArgs>("PlanRelatedBundleType", (EventHandler<PlanRelatedBundleTypeEventArgs>)((object _, PlanRelatedBundleTypeEventArgs e) =>
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				//IL_001a: Invalid comparison between Unknown and I4
				if (_replacedNewer.Contains(e.BundleId) && (int)e.Type == 1)
				{
					e.Type = (RelatedBundlePlanType)2;
					Log("Installed setup " + e.BundleId + " is newer by number but replaced (test build); removed as an upgrade.");
				}
			}), false);
			((BootstrapperApplication)this).DetectRelatedMsiPackage += Guard<DetectRelatedMsiPackageEventArgs>("DetectRelatedMsiPackage", (EventHandler<DetectRelatedMsiPackageEventArgs>)OnRelatedMsiPackage, false);
			((BootstrapperApplication)this).DetectPackageComplete += Guard<DetectPackageCompleteEventArgs>("DetectPackageComplete", (EventHandler<DetectPackageCompleteEventArgs>)OnPackageDetected, false);
			((BootstrapperApplication)this).DetectComplete += Guard<DetectCompleteEventArgs>("DetectComplete", (EventHandler<DetectCompleteEventArgs>)OnDetected, true);
			((BootstrapperApplication)this).PlanComplete += Guard<PlanCompleteEventArgs>("PlanComplete", (EventHandler<PlanCompleteEventArgs>)OnPlanned, true);
			((BootstrapperApplication)this).ElevateComplete += Guard<ElevateCompleteEventArgs>("ElevateComplete", (EventHandler<ElevateCompleteEventArgs>)OnElevated, false);
			((BootstrapperApplication)this).ExecuteBegin += Guard<ExecuteBeginEventArgs>("ExecuteBegin", (EventHandler<ExecuteBeginEventArgs>)OnExecuteBegin, false);
			((BootstrapperApplication)this).Progress += Guard<ProgressEventArgs>("Progress", (EventHandler<ProgressEventArgs>)((object _, ProgressEventArgs e) =>
			{
				Ui(() =>
				{
					_window?.SetProgress(e.OverallPercentage);
				});
				((CancellableHResultEventArgs)e).Cancel = SetupFlow.HonoursCancel(_cancelRequested, _pastPointOfNoReturn);
			}), false);
			((BootstrapperApplication)this).ExecuteProgress += Guard<ExecuteProgressEventArgs>("ExecuteProgress", (EventHandler<ExecuteProgressEventArgs>)((object _, ExecuteProgressEventArgs e) =>
			{
				Ui(() =>
				{
					_window?.SetProgress(e.OverallPercentage);
				});
				((CancellableHResultEventArgs)e).Cancel = SetupFlow.HonoursCancel(_cancelRequested, _pastPointOfNoReturn);
			}), false);
			((BootstrapperApplication)this).ExecuteMsiMessage += Guard<ExecuteMsiMessageEventArgs>("ExecuteMsiMessage", (EventHandler<ExecuteMsiMessageEventArgs>)((object _, ExecuteMsiMessageEventArgs e) =>
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Invalid comparison between Unknown and I4
				if ((int)e.MessageType == 16777216 && !string.IsNullOrWhiteSpace(e.Message))
				{
					_lastError = e.Message;
				}
				if (SetupFlow.HonoursCancel(_cancelRequested, _pastPointOfNoReturn))
				{
					((ResultEventArgs)e).Result = (Result)2;
				}
			}), false);
			((BootstrapperApplication)this).Error += Guard<ErrorEventArgs>("Error", (EventHandler<ErrorEventArgs>)((object _, ErrorEventArgs e) =>
			{
				//IL_000f: Unknown result type (might be due to invalid IL or missing references)
				Log(string.Format("Error {0} in {1}: code {2}, UI hint {3}: {4}", new object[5] { e.ErrorType, e.PackageId, e.ErrorCode, e.UIHint, e.ErrorMessage }));
				if (!string.IsNullOrWhiteSpace(e.ErrorMessage))
				{
					_lastError = e.ErrorMessage;
				}
			}), false);
			((BootstrapperApplication)this).ExecutePackageBegin += Guard<ExecutePackageBeginEventArgs>("ExecutePackageBegin", (EventHandler<ExecutePackageBeginEventArgs>)((object _, ExecutePackageBeginEventArgs e) =>
			{
				//IL_000d: Unknown result type (might be due to invalid IL or missing references)
				Log(string.Format("Package {0} begins: {1}{2}.", e.PackageId, e.Action, e.ShouldExecute ? string.Empty : " (rollback)"));
			}), false);
			((BootstrapperApplication)this).ExecuteFilesInUse += Guard<ExecuteFilesInUseEventArgs>("ExecuteFilesInUse", (EventHandler<ExecuteFilesInUseEventArgs>)((object _, ExecuteFilesInUseEventArgs e) =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				Log(string.Format("Files in use ({0}), continuing without closing: {1}", e.Source, string.Join(", ", e.Files ?? Array.Empty<string>())));
				((ResultEventArgs)e).Result = (Result)5;
			}), false);
			((BootstrapperApplication)this).ExecutePackageComplete += Guard<ExecutePackageCompleteEventArgs>("ExecutePackageComplete", (EventHandler<ExecutePackageCompleteEventArgs>)((object _, ExecutePackageCompleteEventArgs e) =>
			{
				//IL_0018: Unknown result type (might be due to invalid IL or missing references)
				Log($"Package {e.PackageId} finished: 0x{((StatusEventArgs)e).Status:X8}, restart {e.Restart}.");
				if (!_pastPointOfNoReturn && SetupFlow.EndsCancellation(e.PackageId, ((StatusEventArgs)e).Status))
				{
					_pastPointOfNoReturn = true;
					Ui(() =>
					{
						if (_applying)
						{
							ShowProgress(_progressStatus);
						}
					});
				}
			}), false);
			((BootstrapperApplication)this).ApplyComplete += Guard<ApplyCompleteEventArgs>("ApplyComplete", (EventHandler<ApplyCompleteEventArgs>)OnApplied, false);
		}

		private EventHandler<T> Guard<T>(string name, EventHandler<T> handler, bool endsRun = false) where T : EventArgs
		{
			return (object sender, T e) =>
			{
				try
				{
					handler(sender, e);
				}
				catch (Exception arg)
				{
					Log($"{name} failed: {arg}");
					if (endsRun)
					{
						Ui(() =>
						{
							Failed(-2147467259);
						});
					}
				}
			};
		}

		protected override void OnCreate(CreateEventArgs args)
		{
			((BootstrapperApplication)this).OnCreate(args);
			_command = args.Command;
		}

		protected override void Run()
		{
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Invalid comparison between Unknown and I4
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Invalid comparison between Unknown and I4
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			_testBuild = string.Equals(Variable("DiyarTestBuild"), "true", StringComparison.OrdinalIgnoreCase);
			_bundleVersion = Variable("WixBundleVersion");
			_displayVersion = SetupFlow.DisplayVersion(Variable("DiyarDisplayVersion"), _bundleVersion);
			_release = LoadRelease(_displayVersion);
			IBootstrapperCommand? command = _command;
			Display display = (Display)((command == null) ? 4 : ((int)command.Display));
			_windowShown = (int)display == 4 || (int)display == 0;
			Program.Quiet = !_windowShown;
			object[] array = new object[5] { _displayVersion, _bundleVersion, null, null, null };
			IBootstrapperCommand? command2 = _command;
			array[2] = ((command2 != null) ? new Nullable(command2.Action) : ((Nullable)null));
			array[3] = display;
			array[4] = _testBuild;
			Log(string.Format("Diyar setup {0} ({1}), action {2}, display {3}, test build {4}.", array));
			Thread thread = new Thread(() =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				UiThread(display);
			});
			thread.IsBackground = false;
			thread.Name = "Diyar setup window";
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
			int num = SetupFlow.ExitCode(_exitCode, _restartRequired, _cancelRequested);
			Log(string.Format("Exit code {0} (status 0x{1:X8}, restart {2}).", num, _exitCode, _restartRequired ? "required" : "not required"));
			WriteResultFile(num);
			base.engine.Quit(num);
		}

		private void WriteResultFile(int exitCode)
		{
			string text = SetupFlow.ResultFilePath(Variable("WixBundleLog"), _windowShown);
			if (text != null)
			{
				string text2 = SetupFlow.ResultFileText(exitCode, _exitCode, _displayVersion, _restartRequired);
				if (SetupResultWriter.TryWrite(text, text2, out string error))
				{
					Log($"Result file written: exit code {exitCode}.");
				}
				else
				{
					Log("Result file not written: " + error);
				}
			}
		}

		private void UiThread(Display display)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				ShowWindowAndDetect(display);
			}
			catch (Exception exception)
			{
				Fail(exception, display);
			}
		}

		private void Fail(Exception exception, Display display)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Invalid comparison between Unknown and I4
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Invalid comparison between Unknown and I4
			Log($"The setup window failed: {exception}");
			if (_exitCode == 0)
			{
				_exitCode = -2147467259;
			}
			Program.Report(exception, (int)display != 4 && (int)display > 0);
			try
			{
				_window?.Close();
			}
			catch (Exception)
			{
			}
			_dispatcher?.InvokeShutdown();
		}

		private void ShowWindowAndDetect(Display display)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Invalid comparison between Unknown and I4
			_dispatcher = Dispatcher.CurrentDispatcher;
			_dispatcher.UnhandledException += (object _, DispatcherUnhandledExceptionEventArgs e) =>
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				e.Handled = true;
				Fail(e.Exception, display);
			};
			_language = SetupFlow.InitialLanguage(CultureInfo.CurrentUICulture);
			_choices.AppLanguage = _language;
			if (_windowShown || (int)display == 3)
			{
				_window = new SetupWindow(SetupTheme.Load(), SetupText.For(_language));
				_window.LanguageChanged += (object _, EventArgs _) =>
				{
					_language = _window.Text.Language;
				};
				_window.Closing += (object _, CancelEventArgs e) =>
				{
					if (_applying)
					{
						e.Cancel = true;
						RequestCancel();
					}
				};
				_window.Closed += (object _, EventArgs _) =>
				{
					if (_exitCode == 0 && !_applying && _planned == PlannedAction.None)
					{
						_exitCode = -2147023294;
					}
					_dispatcher.InvokeShutdown();
				};
				_window.ShowProgress((SetupText t) => t.WindowTitle, (SetupText t) => t.Checking, null);
				_window.SourceInitialized += (object _, EventArgs _) =>
				{
					_windowHandle = new WindowInteropHelper(_window).Handle;
				};
				_window.Show();
			}
			else
			{
				_hiddenOwner = new HwndSource(new HwndSourceParameters("Diyar setup")
				{
					WindowStyle = 0,
					Width = 0,
					Height = 0
				});
				_windowHandle = _hiddenOwner.Handle;
			}
			base.engine.Detect();
			Dispatcher.Run();
		}

		private void OnRelatedBundle(object? sender, DetectRelatedBundleEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			if ((int)e.RelationType == 2)
			{
				int num = base.engine.CompareVersions(e.Version, _bundleVersion);
				if (num < 0)
				{
					_relatedOlder = true;
				}
				else if (num > 0 && SetupFlow.MayReplaceNewer(_testBuild, e.Version))
				{
					_relatedOlder = true;
					_replacedNewer.Add(e.ProductCode);
				}
				else if (num > 0)
				{
					_relatedNewer = true;
				}
				string label = null;
				try
				{
					label = base.engine.GetRelatedBundleVariable(e.ProductCode, "DiyarDisplayVersion");
				}
				catch (Exception ex) when (ex is Win32Exception || ex is COMException)
				{
				}
				_installedVersion = SetupFlow.DisplayVersion(label, e.Version);
				Log("Installed Diyar setup " + e.Version + " (" + _installedVersion + "): " + ((num < 0) ? "older" : ((num > 0) ? "newer" : "same")) + ".");
			}
		}

		private void OnRelatedMsiPackage(object? sender, DetectRelatedMsiPackageEventArgs e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Invalid comparison between Unknown and I4
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Invalid comparison between Unknown and I4
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			if ((int)e.Operation == 3)
			{
				_relatedOlder = true;
			}
			else if ((int)e.Operation == 1)
			{
				_relatedNewer = true;
			}
			if (_installedVersion.Length == 0)
			{
				_installedVersion = SetupFlow.DisplayVersion(null, e.Version);
			}
			Log($"Installed Diyar MSI {e.Version}: {e.Operation}.");
		}

		private void OnPackageDetected(object? sender, DetectPackageCompleteEventArgs e)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Invalid comparison between Unknown and I4
			if (e.PackageId == "CoCoTypingMsi")
			{
				_packagePresent = (int)e.State == 3;
			}
		}

		private void OnDetected(object? sender, DetectCompleteEventArgs e)
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			if (((StatusEventArgs)e).Status < 0)
			{
				Log($"Detection failed: 0x{((StatusEventArgs)e).Status:X8}.");
				Ui(() =>
				{
					Failed(((StatusEventArgs)e).Status);
				});
				return;
			}
			InstalledRelation installedRelation = SetupFlow.Relation(_packagePresent, _relatedOlder, _relatedNewer);
			IBootstrapperCommand? command = _command;
			_mode = SetupFlow.Mode(Requested((LaunchAction)((command == null) ? 6 : ((int)command.Action))), installedRelation, _testBuild);
			if (_installedVersion.Length == 0)
			{
				_installedVersion = _displayVersion;
			}
			Log($"Installed: {installedRelation}; page: {_mode}.");
			Ui(() =>
			{
				if (_windowShown)
				{
					ShowStart(permissionRefused: false);
				}
				else
				{
					Begin(SetupFlow.Unattended(_mode));
				}
			});
		}

		private void ShowStart(bool permissionRefused)
		{
			PageFacts pageFacts = Facts();
			pageFacts.DiyarRunning = Process.GetProcessesByName("SmartInput.WinUI").Length != 0;
			SetupPages.Start(_window, pageFacts, permissionRefused, Begin);
		}

		private PageFacts Facts()
		{
			return new PageFacts
			{
				Mode = _mode,
				DisplayVersion = _displayVersion,
				InstalledVersion = _installedVersion,
				LogPath = Variable("WixBundleLog"),
				Release = _release,
				Choices = _choices
			};
		}

		private void Begin(PlannedAction action)
		{
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			_planned = action;
			if (action == PlannedAction.None)
			{
				Log($"Nothing to do unattended on page {_mode}.");
				int status = ((_mode == SetupMode.NewerInstalled) ? (-2147023258) : 0);
				if (_window != null && !_windowShown)
				{
					_exitCode = status;
					ShowStart(permissionRefused: false);
					DispatcherTimer timer = new DispatcherTimer
					{
						Interval = TimeSpan.FromSeconds(8.0)
					};
					timer.Tick += (object _, EventArgs _) =>
					{
						timer.Stop();
						Finish(status);
					};
					timer.Start();
				}
				else
				{
					Finish(status);
				}
				return;
			}
			base.engine.SetVariableString("DiyarStartup", SetupFlow.StartupValue(_mode, _choices.Startup, RunningDiyar.StartupShortcutExists()), false);
			base.engine.SetVariableString("DiyarLanguage", SetupFlow.LanguageValue(_mode, _choices.AppLanguage), false);
			_applying = true;
			_cancelRequested = false;
			_pastPointOfNoReturn = false;
			_executeBegan = false;
			_lastError = null;
			ShowProgress((SetupText t) => t.WaitingForPermission);
			Log(string.Format("Planning {0} (startup {1}, language '{2}').", action, Variable("DiyarStartup"), Variable("DiyarLanguage")));
			IEngine engine = base.engine;
			engine.Plan(action switch
			{
				PlannedAction.Uninstall => (LaunchAction)4, 
				PlannedAction.Repair => (LaunchAction)8, 
				_ => (LaunchAction)6, 
			});
		}

		private void OnPlanned(object? sender, PlanCompleteEventArgs e)
		{
			if (((StatusEventArgs)e).Status < 0)
			{
				Log($"Planning failed: 0x{((StatusEventArgs)e).Status:X8}.");
				Ui(() =>
				{
					Failed(((StatusEventArgs)e).Status);
				});
				return;
			}
			try
			{
				base.engine.Apply(_windowHandle);
			}
			catch (Exception ex)
			{
				Log($"Apply could not start: {ex.Message} (0x{ex.HResult:X8}).");
				int status = ((ex.HResult < 0) ? ex.HResult : (-2147467259));
				Ui(() =>
				{
					Failed(status);
				});
			}
		}

		private void OnElevated(object? sender, ElevateCompleteEventArgs e)
		{
			if (((StatusEventArgs)e).Status >= 0)
			{
				Ui(() =>
				{
					ShowProgress(SetupPages.ProgressStatus(_planned, _mode));
				});
			}
		}

		private void OnExecuteBegin(object? sender, ExecuteBeginEventArgs e)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			_executeBegan = true;
			if (RunByAnotherSetup)
			{
				IBootstrapperCommand? command = _command;
				Log($"Run by another setup ({((command != null) ? new Nullable(command.Relation) : ((Nullable)null))}); Diyar is left to it.");
				return;
			}
			Ui(() =>
			{
				ShowProgress((SetupText t) => t.ClosingDiyar);
			});
			try
			{
				_running.Close();
			}
			catch (Exception ex)
			{
				Log("Closing Diyar failed, left to Windows Installer: " + ex.Message);
			}
			Ui(() =>
			{
				ShowProgress(SetupPages.ProgressStatus(_planned, _mode));
			});
		}

		private void OnApplied(object? sender, ApplyCompleteEventArgs e)
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Invalid comparison between Unknown and I4
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			bool succeeded = ((StatusEventArgs)e).Status >= 0;
			bool restart = (int)e.Restart == 1;
			_restartRequired = restart;
			bool started = false;
			try
			{
				Log($"Apply finished: 0x{((StatusEventArgs)e).Status:X8}, restart {e.Restart}, exit code {SetupFlow.ExitCode(((StatusEventArgs)e).Status, restart, _cancelRequested)}; " + "MSI log " + Variable("WixBundleLog_CoCoTypingMsi") + ".");
				if (SetupFlow.RemovesStartupRunValues(_planned, succeeded, RunByAnotherSetup))
				{
					_running.RemoveStartupRunValues();
				}
				if (!RunByAnotherSetup && SetupFlow.StartDiyarAfterwards(_planned, _mode, _windowShown, _running.WasRunning, succeeded, restart))
				{
					started = _running.Start(InstalledExe(), !_windowShown);
				}
			}
			catch (Exception arg)
			{
				Log($"After the apply: {arg}");
				started = false;
			}
			finally
			{
				Ui(() =>
				{
					_applying = false;
					if (!succeeded && !_executeBegan && !_cancelRequested && (((StatusEventArgs)e).Status == -2147023673 || ((StatusEventArgs)e).Status == -2147023294) && _windowShown)
					{
						_planned = PlannedAction.None;
						ShowStart(permissionRefused: true);
					}
					else
					{
						if (_windowShown)
						{
							ShowDone(succeeded, started, restart, ((StatusEventArgs)e).Status);
						}
						Finish(((StatusEventArgs)e).Status, !_windowShown);
					}
				});
			}
		}

		private void ShowDone(bool succeeded, bool started, bool restart, int status)
		{
			SetupPages.Done(_window, Facts(), new Outcome
			{
				Action = _planned,
				Succeeded = succeeded,
				Cancelled = (!succeeded && (_cancelRequested || status == -2147023673 || status == -2147023294)),
				Started = started,
				Restart = restart,
				Error = _lastError,
				OpenDiyar = (SetupFlow.OffersOpenDiyar(_planned, succeeded, started, restart) ? new Action(OpenDiyar) : null)
			});
		}

		private void OpenDiyar()
		{
			_running.Start(InstalledExe(), toTray: false);
			_window?.Close();
		}

		private string InstalledExe()
		{
			return base.engine.FormatString("[ProgramFiles64Folder]Webpack\\Diyar\\SmartInput.WinUI.exe");
		}

		private void Failed(int status)
		{
			_applying = false;
			if (_windowShown)
			{
				ShowDone(succeeded: false, started: false, restart: false, status);
			}
			Finish(status, !_windowShown);
		}

		private void Finish(int status, bool closeWindow = true)
		{
			_exitCode = status;
			if (_window == null)
			{
				_dispatcher?.InvokeShutdown();
			}
			else if (closeWindow)
			{
				_window.Close();
			}
		}

		private ReleaseInfo LoadRelease(string buildVersion)
		{
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "release.ini");
			try
			{
				return ReleaseInfo.Parse(File.Exists(path) ? File.ReadAllLines(path) : Array.Empty<string>(), buildVersion);
			}
			catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
			{
				Log("Could not read release.ini: " + ex.Message);
				return ReleaseInfo.Parse(Array.Empty<string>(), buildVersion);
			}
		}

		private void RequestCancel()
		{
			if (!_applying || _pastPointOfNoReturn)
			{
				return;
			}
			_cancelRequested = true;
			Log("Cancel requested.");
			_dispatcher?.BeginInvoke((Action)(() =>
			{
				if (_applying)
				{
					ShowProgress(_progressStatus);
				}
			}));
		}

		private void ShowProgress(Func<SetupText, string> status)
		{
			_progressStatus = status;
			CancelOffer cancelOffer = SetupFlow.Cancel(_cancelRequested, _pastPointOfNoReturn);
			_window?.ShowProgress(SetupPages.ProgressTitle(_planned, _mode), (cancelOffer == CancelOffer.Cancelling) ? ((Func<SetupText, string>)((SetupText t) => t.Cancelling)) : status, (cancelOffer == CancelOffer.Gone) ? null : new Action(RequestCancel), cancelOffer == CancelOffer.Cancelling);
		}

		private static RequestedAction Requested(LaunchAction action)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected I4, but got Unknown
			switch (action - 1)
			{
			case 5:
				return RequestedAction.Install;
			case 2:
			case 3:
				return RequestedAction.Uninstall;
			case 7:
				return RequestedAction.Repair;
			case 6:
				return RequestedAction.Modify;
			case 0:
				return RequestedAction.Help;
			default:
				return RequestedAction.Other;
			}
		}

		private string Variable(string name)
		{
			try
			{
				return base.engine.ContainsVariable(name) ? (base.engine.GetVariableString(name) ?? string.Empty) : string.Empty;
			}
			catch (Exception ex) when (ex is Win32Exception || ex is COMException)
			{
				return string.Empty;
			}
		}

		private void Ui(Action action)
		{
			Dispatcher dispatcher = _dispatcher;
			if (dispatcher != null && !dispatcher.HasShutdownStarted)
			{
				if (dispatcher.CheckAccess())
				{
					action();
				}
				else
				{
					dispatcher.BeginInvoke(action);
				}
			}
		}

		private void Log(string message)
		{
			try
			{
				IEngine engine = base.engine;
				if (engine != null)
				{
					engine.Log((LogLevel)1, "Diyar setup: " + message);
				}
			}
			catch (Exception ex) when (ex is Win32Exception || ex is COMException)
			{
			}
		}
	}
	internal static class Program
	{
		public const string FailureFileName = "Diyar.Setup-error.txt";

		public static volatile bool Quiet;

		private static int Main(string[] args)
		{
			AppDomain.CurrentDomain.UnhandledException += (object _, UnhandledExceptionEventArgs e) =>
			{
				Report(e.ExceptionObject as Exception, Quiet);
			};
			if (args.Length == 2 && args[0] == "--capture")
			{
				return OnStaThread(() => Capture.Run(args[1]));
			}
			ManagedBootstrapperApplication.Run((IBootstrapperApplication)(object)new DiyarBootstrapper());
			return 0;
		}

		private static int OnStaThread(Func<int> run)
		{
			int result = 1;
			Thread thread = new Thread(() =>
			{
				result = run();
			});
			thread.Name = "Diyar setup capture";
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
			return result;
		}

		public static void Report(Exception? exception, bool quiet)
		{
			string text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} Diyar setup could not continue.{Environment.NewLine}{exception}";
			string text2 = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Diyar.Setup-error.txt");
			try
			{
				File.AppendAllText(text2, text + Environment.NewLine + Environment.NewLine);
			}
			catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
			{
				text2 = string.Empty;
			}
			if (quiet)
			{
				return;
			}
			try
			{
				MessageBox.Show("Diyar setup could not open its window." + Environment.NewLine + Environment.NewLine + exception?.GetType().Name + ": " + exception?.Message + ((text2.Length == 0) ? string.Empty : (Environment.NewLine + Environment.NewLine + "Details: " + text2)), "Diyar Setup", MessageBoxButton.OK, MessageBoxImage.Hand);
			}
			catch (Exception)
			{
			}
		}
	}
	internal sealed class RunningDiyar
	{
		private const string ProcessName = "SmartInput.WinUI";

		private const string RunKeyPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Run";

		private static readonly TimeSpan ExitWait = TimeSpan.FromSeconds(10.0);

		private readonly Action<string> _log;

		public bool WasRunning { get; private set; }

		public string? RunningPath { get; private set; }

		public RunningDiyar(Action<string> log)
		{
			_log = log;
		}

		public bool Close()
		{
			int sessionId = Process.GetCurrentProcess().SessionId;
			List<Process> list = new List<Process>();
			Process[] processesByName = Process.GetProcessesByName("SmartInput.WinUI");
			foreach (Process process in processesByName)
			{
				bool flag;
				try
				{
					flag = process.SessionId == sessionId;
				}
				catch (InvalidOperationException)
				{
					flag = false;
				}
				if (flag)
				{
					list.Add(process);
				}
				else
				{
					process.Dispose();
				}
			}
			WasRunning = list.Count > 0;
			bool result = true;
			foreach (Process item in list)
			{
				using (item)
				{
					int id = item.Id;
					try
					{
						if (RunningPath == null)
						{
							string text = (RunningPath = item.MainModule?.FileName);
						}
					}
					catch (Win32Exception)
					{
					}
					catch (InvalidOperationException)
					{
						goto end_IL_0088;
					}
					try
					{
						if (!RequestExit(id))
						{
							_log($"Diyar process {id} has no exit request; Windows Installer closes it.");
							result = false;
							continue;
						}
						TimeSpan exitWait = ExitWait;
						if (item.WaitForExit((int)exitWait.TotalMilliseconds))
						{
							_log($"Diyar process {id} exited.");
							continue;
						}
						Action<string> log = _log;
						object arg = id;
						exitWait = ExitWait;
						log($"Diyar process {arg} did not exit within {exitWait.TotalSeconds:0} s; Windows Installer closes it.");
						result = false;
					}
					catch (Exception ex4) when (ex4 is Win32Exception || ex4 is InvalidOperationException || ex4 is UnauthorizedAccessException)
					{
						_log($"Diyar process {id} could not be asked to exit ({ex4.Message}); Windows Installer closes it.");
						result = false;
					}
					end_IL_0088:;
				}
			}
			return result;
		}

		public bool Start(string installedPath, bool toTray)
		{
			string text = ((RunningPath != null && File.Exists(RunningPath)) ? RunningPath : installedPath);
			if (!File.Exists(text))
			{
				_log("Diyar was not started: " + text + " does not exist.");
				return false;
			}
			try
			{
				string text2 = (toTray ? "--startup" : string.Empty);
				if (IsElevated())
				{
					Process.Start(new ProcessStartInfo("explorer.exe", "\"" + text + "\"")
					{
						UseShellExecute = false
					})?.Dispose();
					_log("Started Diyar through Explorer (setup is elevated): " + text);
				}
				else
				{
					Process.Start(new ProcessStartInfo(text, text2)
					{
						UseShellExecute = true,
						WorkingDirectory = (System.IO.Path.GetDirectoryName(text) ?? string.Empty)
					})?.Dispose();
					_log("Started Diyar " + text2 + ": " + text);
				}
				return true;
			}
			catch (Exception ex) when (ex is Win32Exception || ex is InvalidOperationException)
			{
				_log("Diyar was not started: " + ex.Message);
				return false;
			}
		}

		public static bool StartupShortcutExists()
		{
			Environment.SpecialFolder[] array = new Environment.SpecialFolder[2]
			{
				Environment.SpecialFolder.CommonStartup,
				Environment.SpecialFolder.Startup
			};
			for (int i = 0; i < array.Length; i++)
			{
				string folderPath = Environment.GetFolderPath(array[i]);
				if (!string.IsNullOrEmpty(folderPath) && File.Exists(System.IO.Path.Combine(folderPath, "Diyar.lnk")))
				{
					return true;
				}
			}
			return false;
		}

		public void RemoveStartupRunValues()
		{
			try
			{
				using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", writable: true);
				if (registryKey == null)
				{
					return;
				}
				foreach (string item in new string[1] { "Diyar" }.Concat(SetupFlow.LegacyStartupRunValueNames))
				{
					if (registryKey.GetValue(item) != null)
					{
						registryKey.DeleteValue(item, throwOnMissingValue: false);
						_log("Removed the startup entry HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Run\\" + item + ".");
					}
				}
			}
			catch (Exception ex) when (ex is SecurityException || ex is UnauthorizedAccessException || ex is IOException)
			{
				_log("The startup entry could not be removed: " + ex.Message);
			}
		}

		private static bool RequestExit(int processId)
		{
			if (!EventWaitHandle.TryOpenExisting($"Local\\SmartInput.App.Exit.{processId}", out EventWaitHandle result))
			{
				return false;
			}
			using (result)
			{
				return result.Set();
			}
		}

		private static bool IsElevated()
		{
			using WindowsIdentity ntIdentity = WindowsIdentity.GetCurrent();
			return new WindowsPrincipal(ntIdentity).IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
	internal sealed class InstallChoices
	{
		public bool Startup { get; set; } = true;

		public SetupLanguage AppLanguage { get; set; }
	}
	internal sealed class PageFacts
	{
		public SetupMode Mode { get; set; }

		public string DisplayVersion { get; set; } = string.Empty;

		public string InstalledVersion { get; set; } = string.Empty;

		public bool DiyarRunning { get; set; }

		public string? LogPath { get; set; }

		public ReleaseInfo Release { get; set; } = ReleaseInfo.Parse(Array.Empty<string>(), string.Empty);

		public InstallChoices Choices { get; set; } = new InstallChoices();
	}
	internal sealed class Outcome
	{
		public PlannedAction Action { get; set; }

		public bool Succeeded { get; set; }

		public bool Cancelled { get; set; }

		public bool Started { get; set; }

		public bool Restart { get; set; }

		public string? Error { get; set; }

		public Action? OpenDiyar { get; set; }
	}
	internal static class SetupPages
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class <>c
		{
			public static readonly <>c <>9 = new <>c();

			public static Func<SetupText, string> <>9__0_0;

			public static Func<SetupText, string> <>9__0_1;

			public static Func<SetupText, string> <>9__0_2;

			public static Func<SetupText, string> <>9__0_23;

			public static Func<SetupText, string> <>9__0_24;

			public static Func<SetupText, string> <>9__0_4;

			public static Func<SetupText, string> <>9__0_5;

			public static Func<SetupText, string> <>9__0_6;

			public static Func<SetupText, string> <>9__0_26;

			public static Func<SetupText, string> <>9__0_8;

			public static Func<SetupText, string> <>9__0_9;

			public static Func<SetupText, string> <>9__0_11;

			public static Func<SetupText, string> <>9__0_12;

			public static Func<SetupText, string> <>9__0_30;

			public static Func<SetupText, string> <>9__0_14;

			public static Func<SetupText, string> <>9__0_15;

			public static Func<SetupText, string> <>9__0_17;

			public static Func<SetupText, string> <>9__0_18;

			public static Func<SetupText, string> <>9__1_0;

			public static Func<SetupText, string> <>9__1_1;

			public static Func<SetupText, string> <>9__1_2;

			public static Func<SetupText, string> <>9__1_3;

			public static Func<SetupText, string> <>9__2_0;

			public static Func<SetupText, string> <>9__2_1;

			public static Func<SetupText, string> <>9__2_2;

			public static Func<SetupText, string> <>9__2_3;

			public static Func<SetupText, string> <>9__3_0;

			public static Func<SetupText, string> <>9__3_1;

			public static Func<SetupText, string> <>9__3_2;

			public static Func<SetupText, string> <>9__3_3;

			public static Func<SetupText, string> <>9__3_4;

			public static Func<SetupText, string> <>9__3_5;

			public static Func<SetupText, string> <>9__3_6;

			public static Func<SetupText, string> <>9__3_7;

			public static Func<SetupText, string> <>9__3_9;

			internal string <Start>b__0_0(SetupText t)
			{
				return t.WindowTitle;
			}

			internal string <Start>b__0_1(SetupText t)
			{
				return t.WelcomeTitle;
			}

			internal string <Start>b__0_2(SetupText t)
			{
				return t.WelcomeSubtitle;
			}

			internal string <Start>b__0_23(SetupText t)
			{
				return t.ReadyTitle;
			}

			internal string <Start>b__0_24(SetupText t)
			{
				return t.ReadyNote;
			}

			internal string <Start>b__0_4(SetupText t)
			{
				return t.UpdateWindowTitle;
			}

			internal string <Start>b__0_5(SetupText t)
			{
				return t.UpdateTitle;
			}

			internal string <Start>b__0_6(SetupText t)
			{
				return t.Tagline;
			}

			internal string <Start>b__0_26(SetupText t)
			{
				return t.UpdateReadyTitle;
			}

			internal string <Start>b__0_8(SetupText t)
			{
				return t.MaintenanceTitle;
			}

			internal string <Start>b__0_9(SetupText t)
			{
				return t.Tagline;
			}

			internal string <Start>b__0_11(SetupText t)
			{
				return t.UninstallTitle;
			}

			internal string <Start>b__0_12(SetupText t)
			{
				return t.Tagline;
			}

			internal string <Start>b__0_30(SetupText t)
			{
				return t.UninstallReadyTitle;
			}

			internal string <Start>b__0_14(SetupText t)
			{
				return t.NewerTitle;
			}

			internal string <Start>b__0_15(SetupText t)
			{
				return t.Tagline;
			}

			internal string <Start>b__0_17(SetupText t)
			{
				return t.HelpTitle;
			}

			internal string <Start>b__0_18(SetupText t)
			{
				return t.Tagline;
			}

			internal string <ProgressTitle>b__1_0(SetupText t)
			{
				return t.UninstallTitle;
			}

			internal string <ProgressTitle>b__1_1(SetupText t)
			{
				return t.UpdateTitle;
			}

			internal string <ProgressTitle>b__1_2(SetupText t)
			{
				return t.RepairTitle;
			}

			internal string <ProgressTitle>b__1_3(SetupText t)
			{
				return t.WelcomeTitle;
			}

			internal string <ProgressStatus>b__2_0(SetupText t)
			{
				return t.Removing;
			}

			internal string <ProgressStatus>b__2_1(SetupText t)
			{
				return t.Repairing;
			}

			internal string <ProgressStatus>b__2_2(SetupText t)
			{
				return t.Updating;
			}

			internal string <ProgressStatus>b__2_3(SetupText t)
			{
				return t.Installing;
			}

			internal string <Done>b__3_0(SetupText t)
			{
				return t.CancelledTitle;
			}

			internal string <Done>b__3_1(SetupText t)
			{
				return t.FailedTitle;
			}

			internal string <Done>b__3_2(SetupText t)
			{
				return t.DoneRemoved;
			}

			internal string <Done>b__3_3(SetupText t)
			{
				return t.DoneRepaired;
			}

			internal string <Done>b__3_4(SetupText t)
			{
				return t.DoneUpdated;
			}

			internal string <Done>b__3_5(SetupText t)
			{
				return t.DoneInstalledRunning;
			}

			internal string <Done>b__3_6(SetupText t)
			{
				return t.DoneInstalled;
			}

			internal string <Done>b__3_7(SetupText t)
			{
				return t.Tagline;
			}

			internal string <Done>b__3_9(SetupText t)
			{
				return t.DoneNote;
			}
		}

		public static void Start(SetupWindow window, PageFacts facts, bool permissionRefused, Action<PlannedAction> begin)
		{
			SetupTheme theme = window.Theme;
			if (facts.Mode != SetupMode.Update)
			{
				window.Frame((SetupText t) => t.WindowTitle, 688.0);
			}
			switch (facts.Mode)
			{
			case SetupMode.Install:
				window.ShowPage((SetupText t) => t.WelcomeTitle, (SetupText t) => t.WelcomeSubtitle, (SetupText text, PageParts parts) =>
				{
					Refused(window, parts, permissionRefused);
					parts.Body.Children.Add(window.Section(text.LanguageSection));
					FrameworkElement control = theme.Segmented(text.PersianName, theme.PersianFont, text.EnglishName, theme.LatinFont, text.Language == SetupLanguage.Persian, TextRuns.PlainFor(text, text.SetupLanguageTitle), (bool persian) =>
					{
						window.ChooseLanguage(persian ? SetupLanguage.Persian : SetupLanguage.English);
					});
					FrameworkElement control2 = theme.Segmented(text.PersianName, theme.PersianFont, text.EnglishName, theme.LatinFont, facts.Choices.AppLanguage == SetupLanguage.Persian, TextRuns.PlainFor(text, text.AppLanguageTitle), (bool persian) =>
					{
						facts.Choices.AppLanguage = (persian ? SetupLanguage.Persian : SetupLanguage.English);
					});
					parts.Body.Children.Add(window.Card(window.Row(text.SetupLanguageTitle, text.SetupLanguageDescription, control, 95.0), window.Row(text.AppLanguageTitle, text.AppLanguageDescription, control2, 95.0)));
					FrameworkElement control3 = theme.Toggle(facts.Choices.Startup, text.On, text.Off, window.Font, TextRuns.PlainFor(text, text.StartupTitle), (bool on) =>
					{
						facts.Choices.Startup = on;
					});
					parts.Body.Children.Add(window.Card(window.Row(text.StartupTitle, text.StartupDescription, control3, 85.0)));
					About(window, text, facts, parts);
					parts.FooterTitle = (SetupText t) => t.ReadyTitle;
					parts.FooterNote = (SetupText t) => t.ReadyNote;
					Licence(window, text, facts, parts);
					Cancel(window, text, parts);
					Primary(window, parts, text.InstallButton, arrow: true, () =>
					{
						begin(PlannedAction.Install);
					});
				});
				break;
			case SetupMode.Update:
				window.Frame((SetupText t) => t.UpdateWindowTitle, 608.0);
				window.ShowPage((SetupText t) => t.UpdateTitle, (SetupText t) => t.Tagline, (SetupText text, PageParts parts) =>
				{
					Refused(window, parts, permissionRefused);
					parts.Body.Children.Add(window.Section(text.UpdateSection));
					Border border = window.Card(Versions(window, text, facts), WhatHappens(window, text, facts));
					border.Margin = new Thickness(0.0, 0.0, 0.0, 16.0);
					parts.Body.Children.Add(border);
					parts.Body.Children.Add(Kept(window, text));
					About(window, text, facts, parts);
					parts.FooterTitle = (SetupText t) => t.UpdateReadyTitle;
					Licence(window, text, facts, parts);
					Cancel(window, text, parts);
					Primary(window, parts, text.UpdateButton, arrow: true, () =>
					{
						begin(PlannedAction.Install);
					}).MinWidth = 166.0;
				});
				break;
			case SetupMode.Maintenance:
				window.ShowPage((SetupText t) => t.MaintenanceTitle, (SetupText t) => t.Tagline, (SetupText text, PageParts parts) =>
				{
					Refused(window, parts, permissionRefused);
					parts.Body.Children.Add(window.Section(text.MaintenanceSection));
					parts.Body.Children.Add(window.Card(window.Row(text.RepairTitle, text.RepairDescription, Secondary(window, text.RepairButton, () =>
					{
						begin(PlannedAction.Repair);
					})), window.Row(text.UninstallRowTitle, text.UninstallRowDescription, Secondary(window, text.UninstallButton, () =>
					{
						begin(PlannedAction.Uninstall);
					}))));
					About(window, text, facts, parts);
					Licence(window, text, facts, parts);
					Primary(window, parts, text.CloseButton, arrow: false, window.Close);
				}, facts.DisplayVersion);
				break;
			case SetupMode.Uninstall:
				window.ShowPage((SetupText t) => t.UninstallTitle, (SetupText t) => t.Tagline, (SetupText text, PageParts parts) =>
				{
					Refused(window, parts, permissionRefused);
					parts.Body.Children.Add(window.Section(text.UninstallSection));
					parts.Body.Children.Add(window.Card(window.Row(text.UninstallRowTitle, text.UninstallBody)));
					About(window, text, facts, parts);
					parts.FooterTitle = (SetupText t) => t.UninstallReadyTitle;
					Cancel(window, text, parts);
					Primary(window, parts, text.UninstallButton, arrow: false, () =>
					{
						begin(PlannedAction.Uninstall);
					});
				});
				break;
			case SetupMode.NewerInstalled:
				window.ShowPage((SetupText t) => t.NewerTitle, (SetupText t) => t.Tagline, (SetupText text, PageParts parts) =>
				{
					parts.Body.Children.Add(window.Card(window.Row(string.Empty, Array.Empty<string>(), text.NewerBody, new string[1] { facts.InstalledVersion })));
					About(window, text, facts, parts);
					Primary(window, parts, text.CloseButton, arrow: false, window.Close);
				});
				break;
			default:
				window.ShowPage((SetupText t) => t.HelpTitle, (SetupText t) => t.Tagline, (SetupText text, PageParts parts) =>
				{
					TextBlock child = new TextBlock
					{
						Text = text.HelpBody,
						FontFamily = theme.LatinFont,
						FontSize = 13.0,
						LineHeight = 22.0,
						Foreground = theme.Text,
						TextWrapping = TextWrapping.Wrap,
						FlowDirection = FlowDirection.LeftToRight,
						Margin = new Thickness(22.0, 20.0, 22.0, 20.0)
					};
					Border element = theme.CardPanel(child);
					parts.Body.Children.Add(element);
					Primary(window, parts, text.CloseButton, arrow: false, window.Close);
				});
				break;
			}
		}

		public static Func<SetupText, string> ProgressTitle(PlannedAction action, SetupMode mode)
		{
			if (action == PlannedAction.Uninstall)
			{
				return (SetupText t) => t.UninstallTitle;
			}
			if (mode == SetupMode.Update)
			{
				return (SetupText t) => t.UpdateTitle;
			}
			if (action == PlannedAction.Repair)
			{
				return (SetupText t) => t.RepairTitle;
			}
			return (SetupText t) => t.WelcomeTitle;
		}

		public static Func<SetupText, string> ProgressStatus(PlannedAction action, SetupMode mode)
		{
			switch (action)
			{
			case PlannedAction.Uninstall:
				return (SetupText t) => t.Removing;
			case PlannedAction.Repair:
				return (SetupText t) => t.Repairing;
			default:
			{
				Func<SetupText, string> func;
				if (mode != SetupMode.Update)
				{
					func = <>c.<>9__2_3;
					if (func == null)
					{
						return <>c.<>9__2_3 = (SetupText t) => t.Installing;
					}
				}
				else
				{
					func = (SetupText t) => t.Updating;
				}
				return func;
			}
			}
		}

		public static void Done(SetupWindow window, PageFacts facts, Outcome outcome)
		{
			Func<SetupText, string> title;
			if (outcome.Succeeded)
			{
				if (outcome.Action == PlannedAction.Uninstall)
				{
					title = (SetupText t) => t.DoneRemoved;
				}
				else if (outcome.Action == PlannedAction.Repair)
				{
					title = (SetupText t) => t.DoneRepaired;
				}
				else if (facts.Mode != SetupMode.Update)
				{
					title = (outcome.Started ? ((Func<SetupText, string>)((SetupText t) => t.DoneInstalledRunning)) : ((Func<SetupText, string>)((SetupText t) => t.DoneInstalled)));
				}
				else
				{
					title = (SetupText t) => t.DoneUpdated;
				}
			}
			else
			{
				title = (outcome.Cancelled ? ((Func<SetupText, string>)((SetupText t) => t.CancelledTitle)) : ((Func<SetupText, string>)((SetupText t) => t.FailedTitle)));
			}
			window.ShowPage(title, (SetupText t) => t.Tagline, (SetupText text, PageParts parts) =>
			{
				StackPanel stackPanel = new StackPanel
				{
					Margin = new Thickness(22.0, 22.0, 22.0, 6.0)
				};
				if (!outcome.Succeeded)
				{
					stackPanel.Children.Add(window.Paragraph(outcome.Cancelled ? text.CancelledBody : text.FailedBody, false));
					if (!outcome.Cancelled && !string.IsNullOrWhiteSpace(outcome.Error))
					{
						string text2 = outcome.Error.Trim();
						TextBlock textBlock = window.Paragraph(string.Empty, true);
						textBlock.Inlines.Add(new Run(text2));
						textBlock.FontFamily = window.Theme.LatinFont;
						textBlock.FlowDirection = (HasArabicScript(text2) ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
						textBlock.Foreground = window.Theme.Danger;
						stackPanel.Children.Add(textBlock);
					}
					string log = facts.LogPath;
					if (!outcome.Cancelled && !string.IsNullOrEmpty(log) && File.Exists(log))
					{
						TextBlock textBlock2 = window.Link(text.OpenLog, () =>
						{
							Open(log);
						});
						textBlock2.Margin = new Thickness(0.0, 0.0, 0.0, 16.0);
						stackPanel.Children.Add(textBlock2);
					}
				}
				else
				{
					if (facts.Mode == SetupMode.Update && outcome.Action == PlannedAction.Install)
					{
						stackPanel.Children.Add(window.Paragraph(text.DoneUpdatedVersion, false, facts.DisplayVersion));
					}
					if (outcome.Started && facts.Mode == SetupMode.Install)
					{
						stackPanel.Children.Add(window.Paragraph(text.DoneTrayHint, false));
					}
					if (outcome.Action == PlannedAction.Uninstall)
					{
						stackPanel.Children.Add(window.Paragraph(text.UninstallBody, true));
					}
					if (outcome.Restart)
					{
						TextBlock textBlock3 = window.Paragraph(text.RestartNeeded, false);
						textBlock3.FontWeight = FontWeights.Bold;
						stackPanel.Children.Add(textBlock3);
					}
				}
				if (stackPanel.Children.Count > 0)
				{
					parts.Body.Children.Add(window.Theme.CardPanel(stackPanel));
				}
				parts.FooterNote = (SetupText t) => t.DoneNote;
				if (outcome.OpenDiyar != null)
				{
					Button button = window.Theme.Button(TextRuns.PlainFor(text, text.OpenDiyarButton), primary: false, window.Font);
					button.Margin = new Thickness(0.0, 0.0, 12.0, 0.0);
					button.Click += (object _, RoutedEventArgs _) =>
					{
						outcome.OpenDiyar();
					};
					parts.Actions.Children.Add(button);
				}
				Primary(window, parts, text.CloseButton, arrow: false, window.Close);
			});
		}

		private static FrameworkElement Versions(SetupWindow window, SetupText text, PageFacts facts)
		{
			SetupTheme theme = window.Theme;
			Grid grid = new Grid
			{
				Margin = new Thickness(24.0, 22.0, 24.0, 22.0),
				ColumnDefinitions = 
				{
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Star)
					},
					new ColumnDefinition
					{
						Width = GridLength.Auto
					},
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Star)
					}
				},
				Children = { (UIElement)VersionColumn(window, text.CurrentVersion, facts.InstalledVersion, current: true) }
			};
			Border element = new Border
			{
				Width = 40.0,
				Height = 40.0,
				CornerRadius = new CornerRadius(6.0),
				Background = theme.Background,
				VerticalAlignment = VerticalAlignment.Center,
				Child = theme.Arrow(theme.Heading)
			};
			Grid.SetColumn(element, 1);
			grid.Children.Add(element);
			FrameworkElement frameworkElement = VersionColumn(window, text.NewVersion, facts.DisplayVersion, current: false);
			frameworkElement.Margin = new Thickness(32.0, 0.0, 0.0, 0.0);
			Grid.SetColumn(frameworkElement, 2);
			grid.Children.Add(frameworkElement);
			return grid;
		}

		private static FrameworkElement VersionColumn(SetupWindow window, string label, string version, bool current)
		{
			SetupTheme theme = window.Theme;
			StackPanel stackPanel = new StackPanel
			{
				VerticalAlignment = VerticalAlignment.Center
			};
			TextBlock textBlock = new TextBlock
			{
				FontSize = 13.0,
				Foreground = theme.SecondaryText
			};
			SetupWindow.Lines(textBlock, 20.0);
			window.Fill(textBlock, label);
			stackPanel.Children.Add(textBlock);
			TextBlock textBlock2 = new TextBlock
			{
				Text = (string.IsNullOrWhiteSpace(version) ? window.Text.NotSet : version),
				FontFamily = theme.LatinFont,
				FontSize = 22.0,
				FontWeight = (current ? FontWeights.Normal : FontWeights.Bold),
				Foreground = (current ? theme.SecondaryText : theme.Heading),
				FlowDirection = FlowDirection.LeftToRight,
				HorizontalAlignment = HorizontalAlignment.Left,
				Margin = new Thickness(0.0, 8.0, 0.0, 0.0)
			};
			SetupWindow.Lines(textBlock2, 30.0);
			stackPanel.Children.Add(textBlock2);
			return stackPanel;
		}

		private static FrameworkElement WhatHappens(SetupWindow window, SetupText text, PageFacts facts)
		{
			StackPanel stackPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal,
				Margin = new Thickness(24.0, 0.0, 24.0, 0.0),
				Height = 54.0,
				Children = { (UIElement)window.Theme.RefreshGlyph() }
			};
			TextBlock textBlock = new TextBlock
			{
				FontSize = 14.0,
				Foreground = window.Theme.Text,
				Margin = new Thickness(12.0, 0.0, 0.0, 0.0),
				VerticalAlignment = VerticalAlignment.Center
			};
			SetupWindow.Lines(textBlock, 22.0);
			window.Fill(textBlock, facts.DiyarRunning ? text.UpdateRunning : text.UpdateNotRunning);
			stackPanel.Children.Add(textBlock);
			return stackPanel;
		}

		private static FrameworkElement Kept(SetupWindow window, SetupText text)
		{
			StackPanel stackPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal,
				Margin = new Thickness(0.0, 0.0, 0.0, 24.0),
				Children = { (UIElement)window.Theme.ShieldGlyph() }
			};
			TextBlock textBlock = new TextBlock
			{
				FontSize = 13.0,
				Foreground = window.Theme.SecondaryText,
				Margin = new Thickness(10.0, 0.0, 0.0, 0.0),
				VerticalAlignment = VerticalAlignment.Center
			};
			SetupWindow.Lines(textBlock, 20.0);
			window.Fill(textBlock, text.SettingsKept);
			stackPanel.Children.Add(textBlock);
			return stackPanel;
		}

		private static void About(SetupWindow window, SetupText text, PageFacts facts, PageParts parts)
		{
			SetupTheme theme = window.Theme;
			parts.Body.Children.Add(window.Section(text.AboutSection));
			Grid grid = new Grid
			{
				Margin = new Thickness(0.0, 2.0, 0.0, 0.0)
			};
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1.0, GridUnitType.Star)
			});
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = GridLength.Auto
			});
			StackPanel stackPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal,
				VerticalAlignment = VerticalAlignment.Center
			};
			stackPanel.Children.Add(Fact(window, text.VersionLabel, facts.Release.Version, text.NotSet));
			stackPanel.Children.Add(new Border
			{
				Width = 1.0,
				Height = 16.0,
				Background = theme.Border,
				Margin = new Thickness(16.0, 0.0, 16.0, 0.0),
				VerticalAlignment = VerticalAlignment.Center
			});
			stackPanel.Children.Add(Fact(window, text.ReleaseDateLabel, facts.Release.ReleaseDate, text.NotSet));
			grid.Children.Add(stackPanel);
			StackPanel stackPanel2 = new StackPanel
			{
				Orientation = Orientation.Horizontal,
				FlowDirection = FlowDirection.LeftToRight
			};
			stackPanel2.Children.Add(theme.ExternalGlyph());
			stackPanel2.Children.Add(new TextBlock
			{
				Text = facts.Release.WebsiteLabel,
				FontFamily = theme.LatinFont,
				FontSize = 14.0,
				FontWeight = FontWeights.SemiBold,
				Foreground = theme.Heading,
				Margin = new Thickness(8.0, 0.0, 0.0, 0.0),
				VerticalAlignment = VerticalAlignment.Center
			});
			Button button = theme.LinkButton(stackPanel2, TextRuns.PlainFor(text, text.Website) + ": " + facts.Release.Website, underline: false);
			button.Click += (object _, RoutedEventArgs _) =>
			{
				Open(facts.Release.Website);
			};
			Grid.SetColumn(button, 1);
			grid.Children.Add(button);
			parts.Body.Children.Add(grid);
		}

		private static FrameworkElement Fact(SetupWindow window, string label, string value, string notSet)
		{
			StackPanel stackPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal,
				VerticalAlignment = VerticalAlignment.Center
			};
			TextBlock textBlock = new TextBlock
			{
				FontSize = 12.0,
				Foreground = window.Theme.SecondaryText,
				VerticalAlignment = VerticalAlignment.Center
			};
			window.Fill(textBlock, label);
			stackPanel.Children.Add(textBlock);
			stackPanel.Children.Add(new TextBlock
			{
				Text = (string.IsNullOrWhiteSpace(value) ? notSet : value.Trim()),
				FontFamily = window.Theme.LatinFont,
				FontSize = 13.0,
				Foreground = window.Theme.Text,
				FlowDirection = FlowDirection.LeftToRight,
				Margin = new Thickness(14.0, 0.0, 0.0, 0.0),
				VerticalAlignment = VerticalAlignment.Center
			});
			return stackPanel;
		}

		private static void Refused(SetupWindow window, PageParts parts, bool refused)
		{
			if (refused)
			{
				TextBlock textBlock = window.Paragraph(window.Text.PermissionRefused, false);
				textBlock.Foreground = window.Theme.Danger;
				textBlock.Margin = new Thickness(0.0, 0.0, 0.0, 14.0);
				parts.Body.Children.Add(textBlock);
			}
		}

		private static void Licence(SetupWindow window, SetupText text, PageFacts facts, PageParts parts)
		{
			TextBlock content = new TextBlock
			{
				Text = text.LicenceTerms,
				FontFamily = window.Theme.FontFor(HasArabicScript(text.LicenceTerms)),
				FontSize = 14.0,
				FontWeight = FontWeights.SemiBold,
				Foreground = window.Theme.Heading
			};
			Button button = window.Theme.LinkButton(content, text.LicenceTerms, underline: true);
			button.Margin = new Thickness(0.0, 0.0, 18.0, 0.0);
			button.Click += (object _, RoutedEventArgs _) =>
			{
				if (facts.Release.LicenceUrl.Length > 0)
				{
					Open(facts.Release.LicenceUrl);
				}
				else
				{
					ShowLicense(window);
				}
			};
			parts.Actions.Children.Add(button);
		}

		private static void Cancel(SetupWindow window, SetupText text, PageParts parts)
		{
			Button button = window.Theme.Button(text.CancelButton, primary: false, window.Font);
			button.Margin = new Thickness(0.0, 0.0, 12.0, 0.0);
			button.IsCancel = true;
			button.Click += (object _, RoutedEventArgs _) =>
			{
				window.Close();
			};
			parts.Actions.Children.Add(button);
		}

		private static Button Primary(SetupWindow window, PageParts parts, string template, bool arrow, Action click)
		{
			Button button = window.Theme.Button(TextRuns.PlainFor(window.Text, template), primary: true, window.Font, arrow);
			button.Click += (object _, RoutedEventArgs _) =>
			{
				click();
			};
			parts.Actions.Children.Add(button);
			return button;
		}

		private static Button Secondary(SetupWindow window, string text, Action click)
		{
			Button button = window.Theme.Button(text, primary: false, window.Font);
			button.MinWidth = 104.0;
			button.Height = 40.0;
			button.Click += (object _, RoutedEventArgs _) =>
			{
				click();
			};
			return button;
		}

		private static bool HasArabicScript(string text)
		{
			foreach (char c in text)
			{
				if (c >= '\u0600' && c <= 'ۿ')
				{
					return true;
				}
			}
			return false;
		}

		private static void ShowLicense(SetupWindow owner)
		{
			string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LICENSE.txt");
			Window window = new Window();
			window.Owner = owner;
			window.Title = owner.Text.LicenseTitle;
			window.Width = 600.0;
			window.Height = 520.0;
			window.ResizeMode = ResizeMode.CanResize;
			window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
			window.Background = owner.Theme.Background;
			window.Icon = owner.Icon;
			window.Content = new ScrollViewer
			{
				Padding = new Thickness(28.0),
				Content = new TextBlock
				{
					Text = (File.Exists(path) ? File.ReadAllText(path) : "https://diyar.digital"),
					TextWrapping = TextWrapping.Wrap,
					FontFamily = owner.Theme.LatinFont,
					FontSize = 13.0,
					LineHeight = 21.0,
					Foreground = owner.Theme.Text,
					FlowDirection = FlowDirection.LeftToRight
				}
			};
			window.ShowDialog();
		}

		private static void Open(string target)
		{
			try
			{
				Process.Start(new ProcessStartInfo(target)
				{
					UseShellExecute = true
				})?.Dispose();
			}
			catch (Exception ex) when (ex is Win32Exception || ex is InvalidOperationException)
			{
			}
		}
	}
	internal sealed class SetupTheme
	{
		public static readonly Color Navy = Color.FromRgb(7, 26, 53);

		private static Geometry? _mark;

		public bool Dark { get; }

		public FontFamily LatinFont { get; } = new FontFamily("Segoe UI");

		public FontFamily PersianFont { get; }

		public Brush Background { get; }

		public Brush Card { get; }

		public Brush Border { get; }

		public Brush Heading { get; }

		public Brush Text { get; }

		public Brush SecondaryText { get; }

		public Brush Accent { get; }

		public Brush AccentHover { get; }

		public Brush OnAccent { get; }

		public Brush Track { get; }

		public Brush ToggleOff { get; }

		public Brush Hover { get; }

		public Brush Danger { get; }

		private SetupTheme(bool dark, FontFamily persianFont)
		{
			Dark = dark;
			PersianFont = persianFont;
			Background = Brush(dark ? Color.FromRgb(28, 28, 28) : Color.FromRgb(248, 247, 243));
			Card = Brush(dark ? Color.FromRgb(39, 39, 39) : Colors.White);
			Border = Brush(dark ? Color.FromRgb(61, 61, 61) : Color.FromRgb(222, 223, 222));
			Heading = Brush(dark ? Colors.White : Navy);
			Text = Brush(dark ? Color.FromRgb(242, 242, 242) : Color.FromRgb(22, 36, 58));
			SecondaryText = Brush(dark ? Color.FromRgb(169, 175, 184) : Color.FromRgb(104, 113, 125));
			Accent = Brush(dark ? Colors.White : Navy);
			AccentHover = Brush(dark ? Color.FromRgb(226, 230, 238) : Color.FromRgb(20, 44, 82));
			OnAccent = Brush(dark ? Navy : Colors.White);
			Track = Brush(dark ? Color.FromRgb(51, 51, 51) : Color.FromRgb(240, 241, 241));
			ToggleOff = Brush(dark ? Color.FromRgb(90, 90, 90) : Color.FromRgb(201, 205, 210));
			Hover = Brush(dark ? Color.FromRgb(48, 48, 48) : Color.FromRgb(239, 238, 233));
			Danger = Brush(dark ? Color.FromRgb(byte.MaxValue, 153, 164) : Color.FromRgb(196, 43, 28));
		}

		public static SetupTheme Load(bool? forceDark = null)
		{
			bool dark = forceDark ?? AppsUseDarkTheme();
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			FontFamily persianFont = (File.Exists(System.IO.Path.Combine(baseDirectory, "Shabnam-FD.ttf")) ? new FontFamily(new Uri(baseDirectory.EndsWith("\\", StringComparison.Ordinal) ? baseDirectory : (baseDirectory + "\\")), "./#Shabnam FD") : new FontFamily("Segoe UI"));
			return new SetupTheme(dark, persianFont);
		}

		private static bool AppsUseDarkTheme()
		{
			try
			{
				using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize");
				return registryKey?.GetValue("AppsUseLightTheme") is int num && num == 0;
			}
			catch (Exception ex) when (ex is UnauthorizedAccessException || ex is SecurityException || ex is IOException)
			{
				return false;
			}
		}

		public FontFamily FontFor(bool rightToLeft)
		{
			if (!rightToLeft)
			{
				return LatinFont;
			}
			return PersianFont;
		}

		public FrameworkElement Logo(double size)
		{
			System.Windows.Shapes.Path child = new System.Windows.Shapes.Path
			{
				Data = Mark(),
				Fill = Brushes.White,
				Stretch = Stretch.Uniform,
				Margin = new Thickness(size * 0.22)
			};
			return new Border
			{
				Width = size,
				Height = size,
				CornerRadius = new CornerRadius(size * 0.17),
				Background = new SolidColorBrush(Color.FromRgb(1, 19, 46)),
				BorderBrush = (Dark ? Border : null),
				BorderThickness = new Thickness(Dark ? 1 : 0),
				FlowDirection = FlowDirection.LeftToRight,
				Child = child
			};
		}

		public Border CardPanel(UIElement child)
		{
			return new Border
			{
				Background = Card,
				BorderBrush = Border,
				BorderThickness = new Thickness(1.0),
				CornerRadius = new CornerRadius(10.0),
				Child = child,
				SnapsToDevicePixels = true
			};
		}

		public Button Button(string text, bool primary, FontFamily font, bool arrow = false)
		{
			object content = text;
			if (arrow)
			{
				StackPanel stackPanel = new StackPanel
				{
					Orientation = Orientation.Horizontal,
					Children = { (UIElement)new TextBlock
					{
						Text = text,
						VerticalAlignment = VerticalAlignment.Center
					} }
				};
				FrameworkElement frameworkElement = Arrow(OnAccent);
				frameworkElement.Margin = new Thickness(12.0, 1.0, 0.0, 0.0);
				stackPanel.Children.Add(frameworkElement);
				content = stackPanel;
			}
			Button button = new Button
			{
				Content = content,
				FontFamily = font,
				FontSize = 14.0,
				FontWeight = (primary ? FontWeights.Bold : FontWeights.Normal),
				MinWidth = (primary ? 156 : 84),
				Height = 46.0,
				Padding = new Thickness(22.0, 0.0, 22.0, 0.0),
				Cursor = Cursors.Hand,
				Foreground = (primary ? OnAccent : Text),
				Background = (primary ? Accent : Background),
				BorderBrush = (primary ? Accent : Border),
				BorderThickness = new Thickness(1.0),
				Template = ButtonTemplate(primary),
				IsDefault = primary
			};
			AutomationProperties.SetName(button, text);
			return button;
		}

		public Button LinkButton(UIElement content, string automationName, bool underline)
		{
			ControlTemplate controlTemplate = new ControlTemplate(typeof(Button));
			FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(ContentPresenter));
			frameworkElementFactory.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
			FrameworkElementFactory frameworkElementFactory2 = new FrameworkElementFactory(typeof(Border), "Line");
			frameworkElementFactory2.SetValue(System.Windows.Controls.Border.BorderThicknessProperty, new Thickness(0.0, 0.0, 0.0, underline ? 1 : 0));
			frameworkElementFactory2.SetValue(System.Windows.Controls.Border.BorderBrushProperty, Heading);
			frameworkElementFactory2.SetValue(System.Windows.Controls.Border.PaddingProperty, new Thickness(0.0, 0.0, 0.0, 2.0));
			frameworkElementFactory2.SetValue(System.Windows.Controls.Border.BackgroundProperty, Brushes.Transparent);
			frameworkElementFactory2.AppendChild(frameworkElementFactory);
			controlTemplate.VisualTree = frameworkElementFactory2;
			Trigger trigger = new Trigger
			{
				Property = UIElement.IsKeyboardFocusedProperty,
				Value = true
			};
			trigger.Setters.Add(new Setter(System.Windows.Controls.Border.BorderThicknessProperty, new Thickness(0.0, 0.0, 0.0, 2.0), "Line"));
			controlTemplate.Triggers.Add(trigger);
			Trigger trigger2 = new Trigger
			{
				Property = UIElement.IsMouseOverProperty,
				Value = true
			};
			trigger2.Setters.Add(new Setter(UIElement.OpacityProperty, 0.75));
			controlTemplate.Triggers.Add(trigger2);
			Button button = new Button
			{
				Content = content,
				Template = controlTemplate,
				Cursor = Cursors.Hand,
				Foreground = Heading,
				VerticalAlignment = VerticalAlignment.Center,
				ToolTip = automationName
			};
			AutomationProperties.SetName(button, automationName);
			return button;
		}

		public FrameworkElement Arrow(Brush stroke)
		{
			return Glyph("M0,5 H11 M7,1 L11,5 L7,9", stroke, 12.0, 10.0, mirror: true);
		}

		public FrameworkElement RefreshGlyph()
		{
			return Glyph("M14,8 A6,6 0 1 1 12.2,3.8 M12.8,0.6 L12.5,4.3 L8.9,4", SecondaryText, 16.0, 16.0, mirror: false);
		}

		public FrameworkElement ShieldGlyph()
		{
			return Glyph("M8,1 L14,3.4 V8 C14,11.6 11.4,14 8,15 C4.6,14 2,11.6 2,8 V3.4 Z M5.2,8.1 L7.2,10.1 L10.8,6.3", Heading, 16.0, 16.0, mirror: false);
		}

		private static FrameworkElement Glyph(string data, Brush stroke, double width, double height, bool mirror)
		{
			System.Windows.Shapes.Path path = new System.Windows.Shapes.Path
			{
				Data = Geometry.Parse(data),
				Stroke = stroke,
				StrokeThickness = 1.6,
				StrokeStartLineCap = PenLineCap.Round,
				StrokeEndLineCap = PenLineCap.Round,
				StrokeLineJoin = PenLineJoin.Round,
				Width = width,
				Height = height,
				VerticalAlignment = VerticalAlignment.Center
			};
			if (!mirror)
			{
				path.FlowDirection = FlowDirection.LeftToRight;
			}
			return path;
		}

		public FrameworkElement ExternalGlyph()
		{
			return new System.Windows.Shapes.Path
			{
				Data = Geometry.Parse("M7.5,1 H12 V5.5 M12,1 L6,7 M10,8 V12 H1 V3 H5"),
				Stroke = Heading,
				StrokeThickness = 1.5,
				StrokeStartLineCap = PenLineCap.Round,
				StrokeEndLineCap = PenLineCap.Round,
				StrokeLineJoin = PenLineJoin.Round,
				Width = 13.0,
				Height = 13.0,
				VerticalAlignment = VerticalAlignment.Center,
				FlowDirection = FlowDirection.LeftToRight
			};
		}

		public FrameworkElement Segmented(string first, FontFamily firstFont, string second, FontFamily secondFont, bool firstChosen, string automationName, Action<bool> chosen)
		{
			string text = "segment-" + Guid.NewGuid().ToString("N");
			StackPanel stackPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal
			};
			RadioButton radioButton = Segment(first, firstFont, text, firstChosen);
			RadioButton radioButton2 = Segment(second, secondFont, text, !firstChosen);
			radioButton.Checked += (object _, RoutedEventArgs _) =>
			{
				chosen(obj: true);
			};
			radioButton2.Checked += (object _, RoutedEventArgs _) =>
			{
				chosen(obj: false);
			};
			stackPanel.Children.Add(radioButton);
			stackPanel.Children.Add(radioButton2);
			AutomationProperties.SetName(stackPanel, automationName);
			return new Border
			{
				Background = Track,
				CornerRadius = new CornerRadius(8.0),
				Padding = new Thickness(3.0),
				Child = stackPanel,
				VerticalAlignment = VerticalAlignment.Center
			};
		}

		private RadioButton Segment(string label, FontFamily font, string group, bool chosen)
		{
			System.Windows.Shapes.Path check = new System.Windows.Shapes.Path
			{
				Data = Geometry.Parse("M0,4.5 L3.5,8 L10,1"),
				Stroke = OnAccent,
				StrokeThickness = 1.6,
				StrokeStartLineCap = PenLineCap.Round,
				StrokeEndLineCap = PenLineCap.Round,
				StrokeLineJoin = PenLineJoin.Round,
				Width = 11.0,
				Height = 9.0,
				Margin = new Thickness(0.0, 0.0, 8.0, 0.0),
				VerticalAlignment = VerticalAlignment.Center,
				FlowDirection = FlowDirection.LeftToRight
			};
			TextBlock text = new TextBlock
			{
				Text = label,
				FontFamily = font,
				FontSize = 14.0,
				VerticalAlignment = VerticalAlignment.Center
			};
			StackPanel stackPanel = new StackPanel
			{
				Orientation = Orientation.Horizontal,
				HorizontalAlignment = HorizontalAlignment.Center
			};
			stackPanel.Children.Add(check);
			stackPanel.Children.Add(text);
			ControlTemplate controlTemplate = new ControlTemplate(typeof(RadioButton));
			FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Border), "Chrome");
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.CornerRadiusProperty, new CornerRadius(6.0));
			frameworkElementFactory.SetBinding(System.Windows.Controls.Border.BackgroundProperty, Bound(Control.BackgroundProperty));
			frameworkElementFactory.SetBinding(System.Windows.Controls.Border.BorderBrushProperty, Bound(Control.BorderBrushProperty));
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.BorderThicknessProperty, new Thickness(0.0));
			FrameworkElementFactory frameworkElementFactory2 = new FrameworkElementFactory(typeof(ContentPresenter));
			frameworkElementFactory2.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
			frameworkElementFactory2.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
			frameworkElementFactory.AppendChild(frameworkElementFactory2);
			controlTemplate.VisualTree = frameworkElementFactory;
			Trigger trigger = new Trigger
			{
				Property = UIElement.IsKeyboardFocusedProperty,
				Value = true
			};
			trigger.Setters.Add(new Setter(System.Windows.Controls.Border.BorderThicknessProperty, new Thickness(2.0), "Chrome"));
			controlTemplate.Triggers.Add(trigger);
			RadioButton button = new RadioButton
			{
				GroupName = group,
				Content = stackPanel,
				Template = controlTemplate,
				Width = 120.0,
				Height = 38.0,
				Cursor = Cursors.Hand,
				BorderBrush = Brush(Dark ? Navy : Color.FromRgb(153, 194, byte.MaxValue)),
				IsChecked = chosen
			};
			AutomationProperties.SetName(button, label);
			button.Checked += (object _, RoutedEventArgs _) =>
			{
				Paint();
			};
			button.Unchecked += (object _, RoutedEventArgs _) =>
			{
				Paint();
			};
			Paint();
			return button;
			void Paint()
			{
				bool valueOrDefault = button.IsChecked == true;
				button.Background = (valueOrDefault ? Accent : Brushes.Transparent);
				text.Foreground = (valueOrDefault ? OnAccent : SecondaryText);
				text.FontWeight = (valueOrDefault ? FontWeights.Bold : FontWeights.Normal);
				check.Visibility = ((!valueOrDefault) ? Visibility.Collapsed : Visibility.Visible);
			}
		}

		public FrameworkElement Toggle(bool on, string onText, string offText, FontFamily font, string automationName, Action<bool> changed)
		{
			ControlTemplate controlTemplate = new ControlTemplate(typeof(ToggleButton));
			FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Border), "Track");
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.CornerRadiusProperty, new CornerRadius(11.0));
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.BackgroundProperty, ToggleOff);
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.BorderBrushProperty, Brushes.Transparent);
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.BorderThicknessProperty, new Thickness(0.0));
			FrameworkElementFactory frameworkElementFactory2 = new FrameworkElementFactory(typeof(Ellipse), "Knob");
			frameworkElementFactory2.SetValue(FrameworkElement.WidthProperty, 16.0);
			frameworkElementFactory2.SetValue(FrameworkElement.HeightProperty, 16.0);
			frameworkElementFactory2.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
			frameworkElementFactory2.SetValue(FrameworkElement.MarginProperty, new Thickness(3.0, 0.0, 3.0, 0.0));
			frameworkElementFactory2.SetValue(Shape.FillProperty, Brushes.White);
			frameworkElementFactory.AppendChild(frameworkElementFactory2);
			controlTemplate.VisualTree = frameworkElementFactory;
			Trigger trigger = new Trigger
			{
				Property = ToggleButton.IsCheckedProperty,
				Value = true
			};
			trigger.Setters.Add(new Setter(System.Windows.Controls.Border.BackgroundProperty, Accent, "Track"));
			trigger.Setters.Add(new Setter(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Right, "Knob"));
			trigger.Setters.Add(new Setter(Shape.FillProperty, OnAccent, "Knob"));
			controlTemplate.Triggers.Add(trigger);
			Trigger trigger2 = new Trigger
			{
				Property = UIElement.IsKeyboardFocusedProperty,
				Value = true
			};
			trigger2.Setters.Add(new Setter(System.Windows.Controls.Border.BorderBrushProperty, Brush(Color.FromRgb(153, 194, byte.MaxValue)), "Track"));
			trigger2.Setters.Add(new Setter(System.Windows.Controls.Border.BorderThicknessProperty, new Thickness(2.0), "Track"));
			controlTemplate.Triggers.Add(trigger2);
			ToggleButton toggleButton = new ToggleButton
			{
				Template = controlTemplate,
				Width = 44.0,
				Height = 22.0,
				IsChecked = on,
				Cursor = Cursors.Hand,
				FlowDirection = FlowDirection.LeftToRight,
				VerticalAlignment = VerticalAlignment.Center
			};
			AutomationProperties.SetName(toggleButton, automationName);
			TextBlock state = new TextBlock
			{
				FontFamily = font,
				FontSize = 12.0,
				Foreground = SecondaryText,
				Margin = new Thickness(0.0, 0.0, 20.0, 0.0),
				VerticalAlignment = VerticalAlignment.Center,
				Text = (on ? onText : offText)
			};
			toggleButton.Checked += (object _, RoutedEventArgs _) =>
			{
				state.Text = onText;
				changed(obj: true);
			};
			toggleButton.Unchecked += (object _, RoutedEventArgs _) =>
			{
				state.Text = offText;
				changed(obj: false);
			};
			return new StackPanel
			{
				Orientation = Orientation.Horizontal,
				VerticalAlignment = VerticalAlignment.Center,
				Children = 
				{
					(UIElement)state,
					(UIElement)toggleButton
				}
			};
		}

		public ProgressBar ProgressBar()
		{
			return new ProgressBar
			{
				Height = 6.0,
				Minimum = 0.0,
				Maximum = 100.0,
				Foreground = Accent,
				Background = Track,
				BorderThickness = new Thickness(0.0),
				Template = ProgressTemplate()
			};
		}

		private ControlTemplate ButtonTemplate(bool primary)
		{
			ControlTemplate controlTemplate = new ControlTemplate(typeof(Button));
			FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Border), "Chrome");
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.CornerRadiusProperty, new CornerRadius(6.0));
			frameworkElementFactory.SetBinding(System.Windows.Controls.Border.BackgroundProperty, Bound(Control.BackgroundProperty));
			frameworkElementFactory.SetBinding(System.Windows.Controls.Border.BorderBrushProperty, Bound(Control.BorderBrushProperty));
			frameworkElementFactory.SetBinding(System.Windows.Controls.Border.BorderThicknessProperty, Bound(Control.BorderThicknessProperty));
			frameworkElementFactory.SetBinding(System.Windows.Controls.Border.PaddingProperty, Bound(Control.PaddingProperty));
			FrameworkElementFactory frameworkElementFactory2 = new FrameworkElementFactory(typeof(ContentPresenter));
			frameworkElementFactory2.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Center);
			frameworkElementFactory2.SetValue(FrameworkElement.VerticalAlignmentProperty, VerticalAlignment.Center);
			frameworkElementFactory.AppendChild(frameworkElementFactory2);
			controlTemplate.VisualTree = frameworkElementFactory;
			Trigger trigger = new Trigger
			{
				Property = UIElement.IsMouseOverProperty,
				Value = true
			};
			trigger.Setters.Add(new Setter(System.Windows.Controls.Border.BackgroundProperty, primary ? AccentHover : Hover, "Chrome"));
			controlTemplate.Triggers.Add(trigger);
			Trigger trigger2 = new Trigger
			{
				Property = UIElement.IsKeyboardFocusedProperty,
				Value = true
			};
			trigger2.Setters.Add(new Setter(System.Windows.Controls.Border.BorderBrushProperty, primary ? Brush(Color.FromRgb(153, 194, byte.MaxValue)) : Accent, "Chrome"));
			trigger2.Setters.Add(new Setter(System.Windows.Controls.Border.BorderThicknessProperty, new Thickness(2.0), "Chrome"));
			controlTemplate.Triggers.Add(trigger2);
			Trigger trigger3 = new Trigger
			{
				Property = UIElement.IsEnabledProperty,
				Value = false
			};
			trigger3.Setters.Add(new Setter(UIElement.OpacityProperty, 0.45));
			controlTemplate.Triggers.Add(trigger3);
			return controlTemplate;
		}

		private static ControlTemplate ProgressTemplate()
		{
			ControlTemplate controlTemplate = new ControlTemplate(typeof(ProgressBar));
			FrameworkElementFactory frameworkElementFactory = new FrameworkElementFactory(typeof(Border), "PART_Track");
			frameworkElementFactory.SetValue(System.Windows.Controls.Border.CornerRadiusProperty, new CornerRadius(3.0));
			frameworkElementFactory.SetBinding(System.Windows.Controls.Border.BackgroundProperty, Bound(Control.BackgroundProperty));
			FrameworkElementFactory frameworkElementFactory2 = new FrameworkElementFactory(typeof(Grid));
			frameworkElementFactory2.AppendChild(frameworkElementFactory);
			FrameworkElementFactory frameworkElementFactory3 = new FrameworkElementFactory(typeof(Border), "PART_Indicator");
			frameworkElementFactory3.SetValue(FrameworkElement.HorizontalAlignmentProperty, HorizontalAlignment.Left);
			frameworkElementFactory3.SetValue(System.Windows.Controls.Border.CornerRadiusProperty, new CornerRadius(3.0));
			frameworkElementFactory3.SetBinding(System.Windows.Controls.Border.BackgroundProperty, Bound(Control.ForegroundProperty));
			frameworkElementFactory2.AppendChild(frameworkElementFactory3);
			controlTemplate.VisualTree = frameworkElementFactory2;
			return controlTemplate;
		}

		private static Geometry Mark()
		{
			if (_mark != null)
			{
				return _mark;
			}
			Geometry geometry = Geometry.Empty;
			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Diyar.Setup.diyar-logo.svg"))
			{
				if (stream != null)
				{
					using StreamReader streamReader = new StreamReader(stream);
					Match match = Regex.Match(streamReader.ReadToEnd(), "\\sd=\"([^\"]+)\"");
					if (match.Success)
					{
						geometry = Geometry.Parse("F0 " + match.Groups[1].Value);
					}
				}
			}
			geometry.Freeze();
			_mark = geometry;
			return geometry;
		}

		private static Binding Bound(DependencyProperty property)
		{
			return new Binding(property.Name)
			{
				RelativeSource = RelativeSource.TemplatedParent
			};
		}

		private static SolidColorBrush Brush(Color color)
		{
			SolidColorBrush solidColorBrush = new SolidColorBrush(color);
			solidColorBrush.Freeze();
			return solidColorBrush;
		}
	}
	internal sealed class PageParts
	{
		public StackPanel Body { get; }

		public StackPanel Actions { get; }

		public Func<SetupText, string>? FooterTitle { get; set; }

		public Func<SetupText, string>? FooterNote { get; set; }

		public string[] FooterNoteValues { get; set; } = Array.Empty<string>();

		public PageParts(StackPanel body, StackPanel actions)
		{
			Body = body;
			Actions = actions;
		}
	}
	internal sealed class SetupWindow : Window
	{
		private readonly SetupTheme _theme;

		private readonly TextBlock _eyebrow = new TextBlock();

		private readonly TextBlock _title = new TextBlock();

		private readonly TextBlock _subtitle = new TextBlock();

		private readonly StackPanel _body = new StackPanel();

		private readonly TextBlock _footerTitle = new TextBlock();

		private readonly TextBlock _footerNote = new TextBlock();

		private readonly StackPanel _actions = new StackPanel
		{
			Orientation = Orientation.Horizontal,
			VerticalAlignment = VerticalAlignment.Center
		};

		private readonly Grid _root;

		private readonly Border _footer;

		private Action _redraw = () =>
		{
		};

		private ProgressBar? _progress;

		public const double DefaultClientHeight = 688.0;

		public const double UpdateClientHeight = 608.0;

		public Func<SetupText, string> WindowTitleOf { get; private set; } = (SetupText t) => t.WindowTitle;

		public bool FitToScreen { get; set; } = true;

		public SetupText Text { get; private set; }

		public FontFamily Font => _theme.FontFor(Text.RightToLeft);

		public SetupTheme Theme => _theme;

		public event EventHandler? LanguageChanged;

		public SetupWindow(SetupTheme theme, SetupText text)
		{
			_theme = theme;
			Text = text;
			SizeToContent = SizeToContent.WidthAndHeight;
			ResizeMode = ResizeMode.CanMinimize;
			WindowStartupLocation = WindowStartupLocation.Manual;
			Background = theme.Background;
			Foreground = theme.Text;
			UseLayoutRounding = true;
			SnapsToDevicePixels = true;
			TextOptions.SetTextFormattingMode(this, TextFormattingMode.Ideal);
			Icon = RenderIcon(theme);
			Grid grid = (_root = new Grid
			{
				Width = 918.0,
				Height = 688.0
			});
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = GridLength.Auto
			});
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = new GridLength(1.0, GridUnitType.Star)
			});
			grid.RowDefinitions.Add(new RowDefinition
			{
				Height = GridLength.Auto
			});
			Grid grid2 = new Grid
			{
				Margin = new Thickness(40.0, 32.0, 40.0, 0.0)
			};
			grid2.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = GridLength.Auto
			});
			grid2.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(20.0)
			});
			grid2.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1.0, GridUnitType.Star)
			});
			FrameworkElement frameworkElement = theme.Logo(66.0);
			frameworkElement.VerticalAlignment = VerticalAlignment.Top;
			frameworkElement.Margin = new Thickness(0.0, 15.0, 0.0, 0.0);
			grid2.Children.Add(frameworkElement);
			StackPanel stackPanel = new StackPanel();
			_eyebrow.FontFamily = theme.LatinFont;
			_eyebrow.FontSize = 11.0;
			Lines(_eyebrow, 16.0);
			_eyebrow.FontWeight = FontWeights.SemiBold;
			_eyebrow.Foreground = theme.SecondaryText;
			_title.FontSize = 26.0;
			Lines(_title, 36.0);
			_title.FontWeight = FontWeights.Bold;
			_title.Foreground = theme.Heading;
			_title.Margin = new Thickness(0.0, 4.0, 0.0, 0.0);
			_title.TextWrapping = TextWrapping.Wrap;
			_subtitle.FontSize = 13.0;
			Lines(_subtitle, 22.0);
			_subtitle.Foreground = theme.SecondaryText;
			_subtitle.Margin = new Thickness(0.0, 10.0, 0.0, 0.0);
			_subtitle.TextWrapping = TextWrapping.Wrap;
			stackPanel.Children.Add(_eyebrow);
			stackPanel.Children.Add(_title);
			stackPanel.Children.Add(_subtitle);
			Grid.SetColumn(stackPanel, 2);
			grid2.Children.Add(stackPanel);
			grid.Children.Add(grid2);
			_body.Margin = new Thickness(40.0, 34.0, 40.0, 0.0);
			Grid.SetRow(_body, 1);
			grid.Children.Add(_body);
			Border border = (_footer = new Border
			{
				BorderBrush = theme.Border,
				BorderThickness = new Thickness(0.0, 1.0, 0.0, 0.0),
				Padding = new Thickness(40.0, 23.0, 40.0, 32.0)
			});
			Grid grid3 = new Grid
			{
				ColumnDefinitions = 
				{
					new ColumnDefinition
					{
						Width = new GridLength(1.0, GridUnitType.Star)
					},
					new ColumnDefinition
					{
						Width = GridLength.Auto
					}
				}
			};
			StackPanel stackPanel2 = new StackPanel
			{
				VerticalAlignment = VerticalAlignment.Center,
				Margin = new Thickness(0.0, 0.0, 24.0, 0.0)
			};
			_footerTitle.FontSize = 15.0;
			Lines(_footerTitle, 22.0);
			_footerTitle.FontWeight = FontWeights.Bold;
			_footerTitle.Foreground = theme.Text;
			_footerTitle.TextWrapping = TextWrapping.Wrap;
			_footerNote.FontSize = 12.0;
			Lines(_footerNote, 18.0);
			_footerNote.Foreground = theme.SecondaryText;
			_footerNote.Margin = new Thickness(0.0, 6.0, 0.0, 0.0);
			_footerNote.TextWrapping = TextWrapping.Wrap;
			stackPanel2.Children.Add(_footerTitle);
			stackPanel2.Children.Add(_footerNote);
			grid3.Children.Add(stackPanel2);
			Grid.SetColumn(_actions, 1);
			grid3.Children.Add(_actions);
			border.Child = grid3;
			Grid.SetRow(border, 2);
			grid.Children.Add(border);
			Content = grid;
			SizeChanged += (object _, SizeChangedEventArgs _) =>
			{
				Place();
			};
			Loaded += (object _, RoutedEventArgs _) =>
			{
				Place();
			};
			ApplyLanguage();
		}

		public void Frame(Func<SetupText, string> windowTitle, double clientHeight)
		{
			WindowTitleOf = windowTitle;
			_footer.Padding = new Thickness(40.0, 23.0, 40.0, (clientHeight < 688.0) ? 50 : 32);
			Title = TextRuns.PlainFor(Text, windowTitle(Text));
			if (!(Math.Abs(_root.Height - clientHeight) < 0.5))
			{
				_root.Height = clientHeight;
			}
		}

		private void Place()
		{
			if (FitToScreen && IsLoaded)
			{
				Rect workArea = SystemParameters.WorkArea;
				double num = ((_root.LayoutTransform is ScaleTransform scaleTransform) ? scaleTransform.ScaleX : 1.0);
				double chromeWidth = Math.Max(0.0, ActualWidth - _root.Width * num);
				double chromeHeight = Math.Max(0.0, ActualHeight - _root.Height * num);
				double num2 = SetupLayout.FitScale(_root.Width, _root.Height, chromeWidth, chromeHeight, workArea.Width, workArea.Height);
				if (Math.Abs(num2 - num) > 0.001)
				{
					_root.LayoutTransform = ((num2 < 1.0) ? new ScaleTransform(num2, num2) : Transform.Identity);
					return;
				}
				Left = workArea.Left + Math.Max(0.0, (workArea.Width - ActualWidth) / 2.0);
				Top = workArea.Top + Math.Max(0.0, (workArea.Height - ActualHeight) / 2.0);
			}
		}

		public void SetText(SetupText text)
		{
			Text = text;
			ApplyLanguage();
			_redraw();
		}

		public void ChooseLanguage(SetupLanguage language)
		{
			if (language != Text.Language)
			{
				Dispatcher.BeginInvoke((Action)(() =>
				{
					SetText(SetupText.For(language));
					LanguageChanged?.Invoke(this, EventArgs.Empty);
				}));
			}
		}

		public void ShowPage(Func<SetupText, string> title, Func<SetupText, string>? subtitle, Action<SetupText, PageParts> draw, params string[] titleValues)
		{
			_progress = null;
			_redraw = () =>
			{
				Fill(_title, title(Text), titleValues);
				string text = subtitle?.Invoke(Text) ?? string.Empty;
				Fill(_subtitle, text);
				_subtitle.Visibility = ((text.Length == 0) ? Visibility.Collapsed : Visibility.Visible);
				_body.Children.Clear();
				_actions.Children.Clear();
				PageParts pageParts = new PageParts(_body, _actions);
				draw(Text, pageParts);
				string text2 = pageParts.FooterTitle?.Invoke(Text) ?? string.Empty;
				string text3 = pageParts.FooterNote?.Invoke(Text) ?? string.Empty;
				Fill(_footerTitle, text2);
				Fill(_footerNote, text3, pageParts.FooterNoteValues);
				_footerTitle.Visibility = ((text2.Length == 0) ? Visibility.Collapsed : Visibility.Visible);
				_footerNote.Visibility = ((text3.Length == 0) ? Visibility.Collapsed : Visibility.Visible);
				_footerNote.Margin = new Thickness(0.0, (text2.Length != 0) ? 6 : 0, 0.0, 0.0);
			};
			_redraw();
		}

		public void ShowProgress(Func<SetupText, string> title, Func<SetupText, string> status, Action? cancel, bool cancelling = false)
		{
			double percent = _progress?.Value ?? 0.0;
			ShowPage(title, (SetupText t) => t.Tagline, (SetupText text, PageParts parts) =>
			{
				StackPanel stackPanel = new StackPanel
				{
					Margin = new Thickness(22.0, 24.0, 22.0, 26.0)
				};
				TextBlock element = RowTitle(status(text));
				stackPanel.Children.Add(element);
				ProgressBar progressBar = _theme.ProgressBar();
				progressBar.Margin = new Thickness(0.0, 16.0, 0.0, 0.0);
				progressBar.Value = percent;
				AutomationProperties.SetName(progressBar, TextRuns.PlainFor(text, status(text)));
				stackPanel.Children.Add(progressBar);
				parts.Body.Children.Add(_theme.CardPanel(stackPanel));
				parts.FooterNote = (SetupText t) => t.ProgressNote;
				if (cancel != null)
				{
					Button cancelButton = _theme.Button(text.CancelButton, primary: false, Font);
					cancelButton.IsEnabled = !cancelling;
					cancelButton.Click += (object _, RoutedEventArgs _) =>
					{
						cancelButton.IsEnabled = false;
						cancel();
					};
					parts.Actions.Children.Add(cancelButton);
				}
				_progress = progressBar;
			});
		}

		public void SetProgress(int percent)
		{
			if (_progress != null)
			{
				_progress.Value = Math.Max(_progress.Value, Math.Min(100, Math.Max(0, percent)));
			}
		}

		public TextBlock Section(string template)
		{
			TextBlock textBlock = new TextBlock
			{
				FontSize = 12.0,
				Foreground = _theme.SecondaryText,
				Margin = new Thickness(0.0, 0.0, 0.0, 12.0)
			};
			Lines(textBlock, 18.0);
			Fill(textBlock, template);
			return textBlock;
		}

		public Border Card(params FrameworkElement[] rows)
		{
			StackPanel stackPanel = new StackPanel();
			for (int i = 0; i < rows.Length; i++)
			{
				if (i > 0)
				{
					stackPanel.Children.Add(new Border
					{
						Height = 1.0,
						Background = _theme.Border
					});
				}
				stackPanel.Children.Add(rows[i]);
			}
			Border border = _theme.CardPanel(stackPanel);
			border.Margin = new Thickness(0.0, 0.0, 0.0, 20.0);
			return border;
		}

		public FrameworkElement Row(string title, string description, FrameworkElement? control = null, double minHeight = 93.0)
		{
			return Row(title, Array.Empty<string>(), description, Array.Empty<string>(), control, minHeight);
		}

		public FrameworkElement Row(string title, string[] titleValues, string description, string[] descriptionValues, FrameworkElement? control = null, double minHeight = 93.0)
		{
			Grid grid = new Grid
			{
				MinHeight = minHeight,
				Margin = new Thickness(22.0, 0.0, 22.0, 0.0)
			};
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = new GridLength(1.0, GridUnitType.Star)
			});
			grid.ColumnDefinitions.Add(new ColumnDefinition
			{
				Width = GridLength.Auto
			});
			StackPanel stackPanel = new StackPanel
			{
				VerticalAlignment = VerticalAlignment.Center,
				Margin = new Thickness(0.0, 12.0, (control != null) ? 24 : 0, 12.0)
			};
			if (title.Length > 0)
			{
				stackPanel.Children.Add(RowTitle(title, titleValues));
			}
			if (description.Length > 0)
			{
				TextBlock textBlock = new TextBlock
				{
					FontSize = 12.0,
					LineHeight = 18.0,
					LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
					Foreground = _theme.SecondaryText,
					TextWrapping = TextWrapping.Wrap,
					Margin = new Thickness(0.0, (title.Length > 0) ? 6 : 0, 0.0, 0.0)
				};
				Fill(textBlock, description, descriptionValues);
				stackPanel.Children.Add(textBlock);
			}
			grid.Children.Add(stackPanel);
			if (control != null)
			{
				control.VerticalAlignment = VerticalAlignment.Center;
				Grid.SetColumn(control, 1);
				grid.Children.Add(control);
			}
			return grid;
		}

		public TextBlock RowTitle(string template, params string[] values)
		{
			TextBlock textBlock = new TextBlock
			{
				FontSize = 15.0,
				FontWeight = FontWeights.Bold,
				Foreground = _theme.Text,
				TextWrapping = TextWrapping.Wrap
			};
			Lines(textBlock, 22.0);
			Fill(textBlock, template, values);
			return textBlock;
		}

		public TextBlock Paragraph(string template, bool secondary, params string[] values)
		{
			TextBlock textBlock = new TextBlock
			{
				TextWrapping = TextWrapping.Wrap,
				FontSize = 13.0,
				LineHeight = 22.0,
				LineStackingStrategy = LineStackingStrategy.BlockLineHeight,
				Foreground = (secondary ? _theme.SecondaryText : _theme.Text),
				Margin = new Thickness(0.0, 0.0, 0.0, 16.0)
			};
			Fill(textBlock, template, values);
			return textBlock;
		}

		public TextBlock Link(string template, Action click)
		{
			TextBlock textBlock = new TextBlock
			{
				FontSize = 13.0
			};
			Hyperlink hyperlink = new Hyperlink
			{
				Foreground = _theme.Heading,
				Cursor = Cursors.Hand
			};
			Run[] array = Runs(template);
			foreach (Run item in array)
			{
				hyperlink.Inlines.Add(item);
			}
			hyperlink.Click += (object _, RoutedEventArgs _) =>
			{
				click();
			};
			textBlock.Inlines.Add(hyperlink);
			return textBlock;
		}

		public void Fill(TextBlock block, string template, params string[] values)
		{
			block.Inlines.Clear();
			Run[] array = Runs(template, values);
			foreach (Run item in array)
			{
				block.Inlines.Add(item);
			}
			AutomationProperties.SetName(block, TextRuns.PlainFor(Text, template, values));
		}

		private Run[] Runs(string template, params string[] values)
		{
			IReadOnlyList<TextRun> readOnlyList = TextRuns.SplitFor(Text, template, values);
			Run[] array = new Run[readOnlyList.Count];
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				array[i] = new Run(readOnlyList[i].Text);
				if (readOnlyList[i].IsValue)
				{
					array[i].FontFamily = _theme.LatinFont;
					array[i].FlowDirection = FlowDirection.LeftToRight;
				}
			}
			return array;
		}

		private void ApplyLanguage()
		{
			FlowDirection = (Text.RightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			FontFamily = Font;
			Title = TextRuns.PlainFor(Text, WindowTitleOf(Text));
			_eyebrow.Text = Text.Eyebrow;
			_eyebrow.FlowDirection = FlowDirection.LeftToRight;
			_eyebrow.HorizontalAlignment = HorizontalAlignment.Left;
		}

		public static void Lines(TextBlock block, double lineHeight)
		{
			block.LineHeight = lineHeight;
			block.LineStackingStrategy = LineStackingStrategy.BlockLineHeight;
		}

		private static BitmapSource RenderIcon(SetupTheme theme)
		{
			FrameworkElement frameworkElement = theme.Logo(64.0);
			frameworkElement.Measure(new Size(64.0, 64.0));
			frameworkElement.Arrange(new Rect(0.0, 0.0, 64.0, 64.0));
			RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(64, 64, 96.0, 96.0, PixelFormats.Pbgra32);
			renderTargetBitmap.Render(frameworkElement);
			renderTargetBitmap.Freeze();
			return renderTargetBitmap;
		}
	}
}
namespace Diyar.Setup.Logic
{
	internal sealed class ReleaseInfo
	{
		public const string DefaultWebsite = "https://diyar.digital";

		public const string FileName = "release.ini";

		public string Version { get; private set; } = string.Empty;

		public string ReleaseDate { get; private set; } = string.Empty;

		public string Website { get; private set; } = "https://diyar.digital";

		public string LicenceUrl { get; private set; } = string.Empty;

		public string WebsiteLabel
		{
			get
			{
				string text = Website;
				int num = text.IndexOf("://", StringComparison.Ordinal);
				if (num >= 0)
				{
					text = text.Substring(num + 3);
				}
				return text.TrimEnd(new char[1] { '/' });
			}
		}

		public static ReleaseInfo Parse(IEnumerable<string> lines, string buildVersion)
		{
			ReleaseInfo releaseInfo = new ReleaseInfo();
			foreach (string line in lines)
			{
				string text = line.Trim();
				if (text.Length == 0 || text[0] == ';' || text[0] == '#')
				{
					continue;
				}
				int num = text.IndexOf('=');
				if (num > 0)
				{
					string key = text.Substring(0, num).Trim();
					string text2 = text.Substring(num + 1).Trim();
					if (Is(key, "version"))
					{
						releaseInfo.Version = text2;
					}
					else if (Is(key, "releaseDate"))
					{
						releaseInfo.ReleaseDate = text2;
					}
					else if (Is(key, "website") && IsWebAddress(text2))
					{
						releaseInfo.Website = text2;
					}
					else if (Is(key, "licenceUrl") && IsWebAddress(text2))
					{
						releaseInfo.LicenceUrl = text2;
					}
				}
			}
			if (releaseInfo.Version.Length == 0)
			{
				releaseInfo.Version = buildVersion ?? string.Empty;
			}
			return releaseInfo;
		}

		public static bool IsWebAddress(string value)
		{
			if (Uri.TryCreate(value, UriKind.Absolute, out Uri result))
			{
				if (!(result.Scheme == Uri.UriSchemeHttps))
				{
					return result.Scheme == Uri.UriSchemeHttp;
				}
				return true;
			}
			return false;
		}

		private static bool Is(string key, string name)
		{
			return string.Equals(key, name, StringComparison.OrdinalIgnoreCase);
		}
	}
	internal enum RequestedAction
	{
		Install,
		Uninstall,
		Repair,
		Modify,
		Help,
		Other
	}
	internal enum InstalledRelation
	{
		None,
		Older,
		Same,
		Newer
	}
	internal enum SetupMode
	{
		Install,
		Update,
		Maintenance,
		Uninstall,
		NewerInstalled,
		Help,
		Unsupported
	}
	internal enum PlannedAction
	{
		None,
		Install,
		Repair,
		Uninstall
	}
	internal static class SetupFlow
	{
		private const int ErrorInstallUserExit = -2147023294;

		private const int ErrorCancelled = -2147023673;

		public const string MsiPackageId = "CoCoTypingMsi";

		public const string StartupRunValueName = "Diyar";

		public static readonly string[] LegacyStartupRunValueNames = new string[2] { "SmartInput", "CoCo Typing" };

		public const int TestBuildVersionFloor = 10000;

		public static SetupMode Mode(RequestedAction requested, InstalledRelation installed, bool testBuild)
		{
			switch (requested)
			{
			case RequestedAction.Help:
				return SetupMode.Help;
			case RequestedAction.Uninstall:
				return SetupMode.Uninstall;
			case RequestedAction.Repair:
				if (installed != InstalledRelation.Same)
				{
					return Mode(RequestedAction.Install, installed, testBuild);
				}
				return SetupMode.Maintenance;
			case RequestedAction.Modify:
				if (installed != InstalledRelation.Same)
				{
					return SetupMode.Uninstall;
				}
				return SetupMode.Maintenance;
			case RequestedAction.Install:
				switch (installed)
				{
				case InstalledRelation.Same:
					return SetupMode.Maintenance;
				case InstalledRelation.Older:
					return SetupMode.Update;
				case InstalledRelation.Newer:
					if (!testBuild)
					{
						return SetupMode.NewerInstalled;
					}
					return SetupMode.Update;
				default:
					return SetupMode.Install;
				}
			default:
				return SetupMode.Unsupported;
			}
		}

		public static PlannedAction Unattended(SetupMode mode)
		{
			switch (mode)
			{
			case SetupMode.Install:
			case SetupMode.Update:
				return PlannedAction.Install;
			case SetupMode.Maintenance:
				return PlannedAction.Repair;
			case SetupMode.Uninstall:
				return PlannedAction.Uninstall;
			default:
				return PlannedAction.None;
			}
		}

		public static bool StartDiyarAfterwards(PlannedAction action, SetupMode mode, bool windowShown, bool wasRunning, bool succeeded, bool restartRequired)
		{
			if (restartRequired)
			{
				return false;
			}
			switch (action)
			{
			case PlannedAction.Uninstall:
				return !succeeded & wasRunning;
			case PlannedAction.None:
				return false;
			default:
				if (!succeeded)
				{
					return wasRunning;
				}
				if (wasRunning)
				{
					return true;
				}
				return (mode == SetupMode.Install) & windowShown;
			}
		}

		public static int ExitCode(int status, bool restartRequired, bool cancelRequested)
		{
			if (status >= 0)
			{
				if (!restartRequired)
				{
					return 0;
				}
				return 3010;
			}
			if (!cancelRequested)
			{
				switch (status)
				{
				case -2147023294:
					break;
				case -2147023673:
					return 1223;
				default:
					if (((status >> 16) & 0x1FFF) == 7)
					{
						return status & 0xFFFF;
					}
					return status;
				}
			}
			return 1602;
		}

		public static string? ResultFilePath(string? bundleLogPath, bool windowShown)
		{
			if (windowShown || string.IsNullOrWhiteSpace(bundleLogPath))
			{
				return null;
			}
			return bundleLogPath + ".result";
		}

		public static string ResultFileText(int exitCode, int status, string displayVersion, bool restartRequired)
		{
			return "exitCode=" + exitCode.ToString(CultureInfo.InvariantCulture) + "\r\nstatus=0x" + status.ToString("X8", CultureInfo.InvariantCulture) + "\r\nversion=" + displayVersion + "\r\nrestart=" + (restartRequired ? "1" : "0") + "\r\n";
		}

		public static bool EndsCancellation(string? packageId, int status)
		{
			if (status >= 0)
			{
				return string.Equals(packageId, "CoCoTypingMsi", StringComparison.Ordinal);
			}
			return false;
		}

		public static bool HonoursCancel(bool cancelRequested, bool pastPointOfNoReturn)
		{
			if (cancelRequested)
			{
				return !pastPointOfNoReturn;
			}
			return false;
		}

		public static CancelOffer Cancel(bool cancelRequested, bool pastPointOfNoReturn)
		{
			if (pastPointOfNoReturn)
			{
				return CancelOffer.Gone;
			}
			if (!cancelRequested)
			{
				return CancelOffer.Offered;
			}
			return CancelOffer.Cancelling;
		}

		public static bool OffersOpenDiyar(PlannedAction action, bool succeeded, bool started, bool restartRequired)
		{
			if (succeeded && !started && !restartRequired)
			{
				if (action != PlannedAction.Install)
				{
					return action == PlannedAction.Repair;
				}
				return true;
			}
			return false;
		}

		public static string StartupValue(SetupMode mode, bool checkboxChecked, bool startupShortcutExists)
		{
			if (!((mode == SetupMode.Install) ? checkboxChecked : startupShortcutExists))
			{
				return "0";
			}
			return "1";
		}

		public static bool RemovesStartupRunValues(PlannedAction action, bool succeeded, bool runByAnotherSetup)
		{
			if ((action == PlannedAction.Uninstall) & succeeded)
			{
				return !runByAnotherSetup;
			}
			return false;
		}

		public static string LanguageValue(SetupMode mode, SetupLanguage language)
		{
			if (mode != SetupMode.Install)
			{
				return string.Empty;
			}
			if (language != SetupLanguage.Persian)
			{
				return "en";
			}
			return "fa";
		}

		public static SetupLanguage InitialLanguage(CultureInfo uiCulture)
		{
			if (!string.Equals(uiCulture.TwoLetterISOLanguageName, "fa", StringComparison.OrdinalIgnoreCase))
			{
				return SetupLanguage.English;
			}
			return SetupLanguage.Persian;
		}

		public static string DisplayVersion(string? label, string? fourPartVersion)
		{
			if (!string.IsNullOrWhiteSpace(label))
			{
				return label.Trim();
			}
			if (string.IsNullOrWhiteSpace(fourPartVersion))
			{
				return string.Empty;
			}
			string[] array = fourPartVersion.Trim().Split(new char[1] { '.' });
			if (array.Length < 3)
			{
				return fourPartVersion.Trim();
			}
			string text = string.Join(".", array, 0, 3);
			if (array.Length < 4 || !int.TryParse(array[3], NumberStyles.None, CultureInfo.InvariantCulture, out var result))
			{
				return text;
			}
			if (result == 9000)
			{
				return text;
			}
			if (result > 500 && result < 1000)
			{
				return $"{text}-preview.{result - 500}";
			}
			if (result > 1000 && result < 2000)
			{
				return $"{text}-alpha.{result - 1000}";
			}
			if (result > 2000 && result < 3000)
			{
				return $"{text}-beta.{result - 2000}";
			}
			if (result > 3000 && result < 4000)
			{
				return $"{text}-rc.{result - 3000}";
			}
			return text;
		}

		public static bool IsTestBuildVersion(string? fourPartVersion)
		{
			if (string.IsNullOrWhiteSpace(fourPartVersion))
			{
				return false;
			}
			string[] array = fourPartVersion.Trim().Split(new char[1] { '.' });
			if (array.Length >= 4 && int.TryParse(array[3], NumberStyles.None, CultureInfo.InvariantCulture, out var result))
			{
				return result >= 10000;
			}
			return false;
		}

		public static bool MayReplaceNewer(bool thisIsTestBuild, string? installedVersion)
		{
			if (!thisIsTestBuild)
			{
				return IsTestBuildVersion(installedVersion);
			}
			return true;
		}

		public static InstalledRelation Relation(bool packagePresent, bool relatedOlder, bool relatedNewer)
		{
			if (packagePresent)
			{
				return InstalledRelation.Same;
			}
			if (relatedNewer)
			{
				return InstalledRelation.Newer;
			}
			if (relatedOlder)
			{
				return InstalledRelation.Older;
			}
			return InstalledRelation.None;
		}
	}
	internal enum CancelOffer
	{
		Offered,
		Cancelling,
		Gone
	}
	internal enum SetupLanguage
	{
		English,
		Persian
	}
	internal static class SetupLayout
	{
		public const double MinimumScale = 0.7;

		public static double FitScale(double width, double height, double chromeWidth, double chromeHeight, double areaWidth, double areaHeight)
		{
			if (width <= 0.0 || height <= 0.0)
			{
				return 1.0;
			}
			double num = Math.Min((areaWidth - chromeWidth) / width, (areaHeight - chromeHeight) / height);
			if (double.IsNaN(num) || num >= 1.0)
			{
				return 1.0;
			}
			return Math.Max(0.7, num);
		}
	}
	internal static class SetupResultWriter
	{
		public static bool TryWrite(string path, string text, out string? error)
		{
			string text2 = path + ".tmp";
			try
			{
				File.WriteAllText(text2, text, new ASCIIEncoding());
				if (File.Exists(path))
				{
					File.Replace(text2, path, null);
				}
				else
				{
					File.Move(text2, path);
				}
				error = null;
				return true;
			}
			catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException || ex is ArgumentException || ex is NotSupportedException)
			{
				error = ex.GetType().Name + ": " + ex.Message;
				try
				{
					if (File.Exists(text2))
					{
						File.Delete(text2);
					}
				}
				catch (Exception ex2) when (ex2 is IOException || ex2 is UnauthorizedAccessException)
				{
				}
				return false;
			}
		}
	}
	internal sealed class SetupText
	{
		public static readonly SetupText English = new SetupText
		{
			Language = SetupLanguage.English,
			AppName = "Diyar",
			WindowTitle = "Diyar Setup",
			Eyebrow = "DIYAR FOR WINDOWS",
			PersianName = "فارسی",
			EnglishName = "English",
			Tagline = "Type Persian with your English keyboard.",
			WelcomeTitle = "Welcome to {app}",
			WelcomeSubtitle = "Type Persian with your English keyboard. Set {app} up for yourself before you install.",
			LanguageSection = "Language settings",
			SetupLanguageTitle = "Setup language",
			SetupLanguageDescription = "The language of this window and the setup steps",
			AppLanguageTitle = "Default app language",
			AppLanguageDescription = "The language {app} shows after setup; separate from the setup language",
			StartupTitle = "Start with Windows",
			StartupDescription = "{app} is ready to type as soon as you sign in to Windows.",
			On = "On",
			Off = "Off",
			AboutSection = "About this version",
			VersionLabel = "Version",
			ReleaseDateLabel = "Release date",
			NotSet = "—",
			Website = "Official website",
			ReadyTitle = "Everything is ready to start.",
			ReadyNote = "You can change these settings later in the app.",
			LicenceTerms = "Licence terms",
			CancelButton = "Cancel",
			InstallButton = "Install {app}",
			UpdateWindowTitle = "Diyar Update",
			UpdateTitle = "Update {app}",
			UpdateSection = "This update",
			CurrentVersion = "Current version",
			NewVersion = "New version",
			UpdateVersions = "From {0} to {1}",
			UpdateRunning = "{app} closes for a moment and opens again by itself.",
			UpdateNotRunning = "{app} is not running, so nothing needs to close.",
			UpdateReadyTitle = "Ready to update.",
			SettingsKept = "Your settings and personal dictionary are kept.",
			UpdateButton = "Update",
			MaintenanceTitle = "{app} {0} is installed",
			MaintenanceSection = "What would you like to do?",
			RepairTitle = "Repair",
			RepairDescription = "Puts back any missing or damaged file. Your settings stay as they are.",
			UninstallRowTitle = "Uninstall",
			UninstallRowDescription = "Removes {app} from this computer.",
			RepairButton = "Repair",
			UninstallButton = "Uninstall",
			UninstallTitle = "Uninstall {app}",
			UninstallSection = "Before you go",
			UninstallBody = "Your settings and personal dictionary stay in your Windows profile, so a later install picks them up again.",
			UninstallReadyTitle = "Ready to remove {app}.",
			NewerTitle = "A newer {app} is installed",
			NewerBody = "{app} {0} is already on this computer. To go back to this version, uninstall it first.",
			CloseButton = "Close",
			Checking = "Checking what is installed…",
			WaitingForPermission = "Waiting for Windows to allow the change…",
			ClosingDiyar = "Closing {app}…",
			Cancelling = "Cancelling…",
			Installing = "Installing {app}…",
			Updating = "Updating {app}…",
			Repairing = "Repairing {app}…",
			Removing = "Removing {app}…",
			ProgressNote = "This takes a moment. Your other programs can stay open.",
			PermissionRefused = "{app} needs administrator permission to make this change. Choose Yes when Windows asks.",
			DoneInstalledRunning = "{app} is installed and running",
			DoneInstalled = "{app} is installed",
			DoneTrayHint = "Its icon is in the notification area, next to the clock.",
			DoneUpdated = "{app} is up to date",
			DoneUpdatedVersion = "Version {0}",
			DoneRepaired = "{app} was repaired",
			DoneRemoved = "{app} was removed",
			RestartNeeded = "Restart Windows to finish.",
			DoneNote = "You can close this window.",
			OpenDiyarButton = "Open {app}",
			FailedTitle = "Setup could not finish",
			FailedBody = "Setup undid its changes.",
			CancelledTitle = "Setup was cancelled",
			CancelledBody = "Nothing was changed.",
			OpenLog = "Open the setup log",
			LicenseTitle = "Licence terms",
			HelpTitle = "{app} Setup",
			HelpBody = "setup.exe [/passive | /quiet] [/uninstall | /repair] [/log <file>]\n\n/passive shows only the progress window; /quiet shows nothing. Diyar opens again afterwards when it was running."
		};

		public static readonly SetupText Persian = new SetupText
		{
			Language = SetupLanguage.Persian,
			AppName = "Diyar",
			WindowTitle = "Diyar Setup",
			Eyebrow = "DIYAR FOR WINDOWS",
			PersianName = "فارسی",
			EnglishName = "English",
			Tagline = "با صفحه\u200cکلید انگلیسی، فارسی تایپ کنید.",
			WelcomeTitle = "به {app} خوش آمدید",
			WelcomeSubtitle = "با صفحه\u200cکلید انگلیسی، فارسی تایپ کنید. پیش از نصب، {app} را برای خودتان تنظیم کنید.",
			LanguageSection = "تنظیمات زبان",
			SetupLanguageTitle = "زبان راه\u200cاندازی",
			SetupLanguageDescription = "زبان نمایش همین صفحه و مراحل نصب",
			AppLanguageTitle = "زبان پیش\u200cفرض برنامه",
			AppLanguageDescription = "زبان نمایش {app} پس از نصب؛ مستقل از زبان راه\u200cاندازی",
			StartupTitle = "اجرای خودکار با شروع ویندوز",
			StartupDescription = "با ورود به ویندوز، {app} آماده\u0654 تایپ باشد.",
			On = "فعال",
			Off = "غیرفعال",
			AboutSection = "درباره\u0654 این نسخه",
			VersionLabel = "نسخه",
			ReleaseDateLabel = "تاریخ انتشار",
			NotSet = "—",
			Website = "وب\u200cسایت رسمی",
			ReadyTitle = "همه\u200cچیز برای شروع آماده است.",
			ReadyNote = "این تنظیمات را بعدا\u064b هم می\u200cتوانید در برنامه تغییر دهید.",
			LicenceTerms = "Licence terms",
			CancelButton = "انصراف",
			InstallButton = "نصب {app}",
			UpdateWindowTitle = "Diyar Update",
			UpdateTitle = "به\u200cروزرسانی {app}",
			UpdateSection = "این به\u200cروزرسانی",
			CurrentVersion = "نسخه\u0654 فعلی",
			NewVersion = "نسخه\u0654 جدید",
			UpdateVersions = "از نسخه\u0654 {0} به {1}",
			UpdateRunning = "{app} برای لحظه\u200cای بسته می\u200cشود و خودش دوباره باز می\u200cشود.",
			UpdateNotRunning = "{app} در حال اجرا نیست، پس چیزی بسته نمی\u200cشود.",
			UpdateReadyTitle = "آماده\u0654 به\u200cروزرسانی است.",
			SettingsKept = "تنظیمات و واژه\u200cنامه\u0654 شخصی شما حفظ می\u200cشوند.",
			UpdateButton = "به\u200cروزرسانی",
			MaintenanceTitle = "{app} {0} نصب است",
			MaintenanceSection = "چه کاری انجام شود؟",
			RepairTitle = "تعمیر",
			RepairDescription = "هر فایلی را که کم شده یا خراب است برمی\u200cگرداند. تنظیمات شما سر جایش می\u200cماند.",
			UninstallRowTitle = "حذف",
			UninstallRowDescription = "{app} را از این کامپیوتر پاک می\u200cکند.",
			RepairButton = "تعمیر",
			UninstallButton = "حذف",
			UninstallTitle = "حذف {app}",
			UninstallSection = "پیش از حذف",
			UninstallBody = "تنظیمات و فرهنگ لغت شخصی شما در پروفایل ویندوزتان می\u200cماند و نصب بعدی دوباره از آن\u200cها استفاده می\u200cکند.",
			UninstallReadyTitle = "آماده\u0654 حذف {app}.",
			NewerTitle = "نسخه\u0654 تازه\u200cتری از {app} نصب است",
			NewerBody = "{app} {0} از قبل روی این کامپیوتر نصب است. برای برگشتن به این نسخه، اول آن را حذف کنید.",
			CloseButton = "بستن",
			Checking = "در حال بررسی نسخه\u0654 نصب\u200cشده…",
			WaitingForPermission = "در انتظار اجازه\u0654 ویندوز…",
			ClosingDiyar = "در حال بستن {app}…",
			Cancelling = "در حال لغو…",
			Installing = "در حال نصب {app}…",
			Updating = "در حال به\u200cروزرسانی {app}…",
			Repairing = "در حال تعمیر {app}…",
			Removing = "در حال حذف {app}…",
			ProgressNote = "چند لحظه طول می\u200cکشد. برنامه\u200cهای دیگرتان می\u200cتوانند باز بمانند.",
			PermissionRefused = "{app} برای این کار اجازه\u0654 مدیر لازم دارد. وقتی ویندوز پرسید، «بله» را بزنید.",
			DoneInstalledRunning = "{app} نصب شد و در حال اجراست",
			DoneInstalled = "{app} نصب شد",
			DoneTrayHint = "آیکونش کنار ساعت ویندوز است.",
			DoneUpdated = "{app} به\u200cروز شد",
			DoneUpdatedVersion = "نسخه\u0654 {0}",
			DoneRepaired = "{app} تعمیر شد",
			DoneRemoved = "{app} حذف شد",
			RestartNeeded = "برای تمام شدن کار، ویندوز را دوباره راه\u200cاندازی کنید.",
			DoneNote = "می\u200cتوانید این پنجره را ببندید.",
			OpenDiyarButton = "باز کردن {app}",
			FailedTitle = "نصب کامل نشد",
			FailedBody = "تغییرات نصب برگردانده شد.",
			CancelledTitle = "نصب لغو شد",
			CancelledBody = "چیزی تغییر نکرد.",
			OpenLog = "باز کردن گزارش نصب",
			LicenseTitle = "Licence terms",
			HelpTitle = "راه\u200cاندازی {app}",
			HelpBody = English.HelpBody
		};

		public bool RightToLeft => Language == SetupLanguage.Persian;

		public SetupText Other
		{
			get
			{
				if (Language != SetupLanguage.Persian)
				{
					return Persian;
				}
				return English;
			}
		}

		public SetupLanguage Language { get; private set; }

		public string AppName { get; private set; } = string.Empty;

		public string WindowTitle { get; private set; } = string.Empty;

		public string Eyebrow { get; private set; } = string.Empty;

		public string PersianName { get; private set; } = string.Empty;

		public string EnglishName { get; private set; } = string.Empty;

		public string Tagline { get; private set; } = string.Empty;

		public string WelcomeTitle { get; private set; } = string.Empty;

		public string WelcomeSubtitle { get; private set; } = string.Empty;

		public string LanguageSection { get; private set; } = string.Empty;

		public string SetupLanguageTitle { get; private set; } = string.Empty;

		public string SetupLanguageDescription { get; private set; } = string.Empty;

		public string AppLanguageTitle { get; private set; } = string.Empty;

		public string AppLanguageDescription { get; private set; } = string.Empty;

		public string StartupTitle { get; private set; } = string.Empty;

		public string StartupDescription { get; private set; } = string.Empty;

		public string On { get; private set; } = string.Empty;

		public string Off { get; private set; } = string.Empty;

		public string AboutSection { get; private set; } = string.Empty;

		public string VersionLabel { get; private set; } = string.Empty;

		public string ReleaseDateLabel { get; private set; } = string.Empty;

		public string NotSet { get; private set; } = string.Empty;

		public string Website { get; private set; } = string.Empty;

		public string ReadyTitle { get; private set; } = string.Empty;

		public string ReadyNote { get; private set; } = string.Empty;

		public string LicenceTerms { get; private set; } = string.Empty;

		public string CancelButton { get; private set; } = string.Empty;

		public string InstallButton { get; private set; } = string.Empty;

		public string UpdateWindowTitle { get; private set; } = string.Empty;

		public string UpdateTitle { get; private set; } = string.Empty;

		public string CurrentVersion { get; private set; } = string.Empty;

		public string NewVersion { get; private set; } = string.Empty;

		public string UpdateSection { get; private set; } = string.Empty;

		public string UpdateVersions { get; private set; } = string.Empty;

		public string UpdateRunning { get; private set; } = string.Empty;

		public string UpdateNotRunning { get; private set; } = string.Empty;

		public string UpdateReadyTitle { get; private set; } = string.Empty;

		public string SettingsKept { get; private set; } = string.Empty;

		public string UpdateButton { get; private set; } = string.Empty;

		public string MaintenanceTitle { get; private set; } = string.Empty;

		public string MaintenanceSection { get; private set; } = string.Empty;

		public string RepairTitle { get; private set; } = string.Empty;

		public string RepairDescription { get; private set; } = string.Empty;

		public string UninstallRowTitle { get; private set; } = string.Empty;

		public string UninstallRowDescription { get; private set; } = string.Empty;

		public string RepairButton { get; private set; } = string.Empty;

		public string UninstallButton { get; private set; } = string.Empty;

		public string UninstallTitle { get; private set; } = string.Empty;

		public string UninstallSection { get; private set; } = string.Empty;

		public string UninstallBody { get; private set; } = string.Empty;

		public string UninstallReadyTitle { get; private set; } = string.Empty;

		public string NewerTitle { get; private set; } = string.Empty;

		public string NewerBody { get; private set; } = string.Empty;

		public string CloseButton { get; private set; } = string.Empty;

		public string Checking { get; private set; } = string.Empty;

		public string WaitingForPermission { get; private set; } = string.Empty;

		public string ClosingDiyar { get; private set; } = string.Empty;

		public string Cancelling { get; private set; } = string.Empty;

		public string Installing { get; private set; } = string.Empty;

		public string Updating { get; private set; } = string.Empty;

		public string Repairing { get; private set; } = string.Empty;

		public string Removing { get; private set; } = string.Empty;

		public string ProgressNote { get; private set; } = string.Empty;

		public string PermissionRefused { get; private set; } = string.Empty;

		public string DoneInstalledRunning { get; private set; } = string.Empty;

		public string DoneInstalled { get; private set; } = string.Empty;

		public string DoneTrayHint { get; private set; } = string.Empty;

		public string DoneUpdated { get; private set; } = string.Empty;

		public string DoneUpdatedVersion { get; private set; } = string.Empty;

		public string DoneRepaired { get; private set; } = string.Empty;

		public string DoneRemoved { get; private set; } = string.Empty;

		public string RestartNeeded { get; private set; } = string.Empty;

		public string DoneNote { get; private set; } = string.Empty;

		public string OpenDiyarButton { get; private set; } = string.Empty;

		public string FailedTitle { get; private set; } = string.Empty;

		public string FailedBody { get; private set; } = string.Empty;

		public string CancelledTitle { get; private set; } = string.Empty;

		public string CancelledBody { get; private set; } = string.Empty;

		public string OpenLog { get; private set; } = string.Empty;

		public string LicenseTitle { get; private set; } = string.Empty;

		public string HelpTitle { get; private set; } = string.Empty;

		public string HelpBody { get; private set; } = string.Empty;

		private SetupText()
		{
		}

		public static SetupText For(SetupLanguage language)
		{
			if (language != SetupLanguage.Persian)
			{
				return English;
			}
			return Persian;
		}
	}
	internal readonly struct TextRun(string text, bool isValue)
	{
		public string Text { get; } = text;

		public bool IsValue { get; } = isValue;
	}
	internal static class TextRuns
	{
		public const string ProductName = "Diyar";

		public static IReadOnlyList<TextRun> Split(string template, params string[] values)
		{
			return Split(template, "Diyar", appIsValue: true, values);
		}

		public static IReadOnlyList<TextRun> SplitFor(SetupText text, string template, params string[] values)
		{
			return Split(template, text.AppName, !IsPersianScript(text.AppName), values);
		}

		private static bool IsPersianScript(string value)
		{
			foreach (char c in value)
			{
				if (c >= '\u0600' && c <= 'ۿ')
				{
					return true;
				}
			}
			return false;
		}

		public static string PlainFor(SetupText text, string template, params string[] values)
		{
			return Join(SplitFor(text, template, values));
		}

		private static IReadOnlyList<TextRun> Split(string template, string appName, bool appIsValue, string[] values)
		{
			List<TextRun> list = new List<TextRun>();
			StringBuilder stringBuilder = new StringBuilder();
			int num = 0;
			while (num < template.Length)
			{
				int num2 = ((template[num] == '{') ? template.IndexOf('}', num + 1) : (-1));
				string text = null;
				bool flag = true;
				if (num2 > num)
				{
					string text2 = template.Substring(num + 1, num2 - num - 1);
					int result;
					if (text2 == "app")
					{
						text = appName;
						flag = appIsValue;
					}
					else if (int.TryParse(text2, out result) && result >= 0 && result < values.Length)
					{
						text = values[result];
					}
				}
				if (text == null)
				{
					stringBuilder.Append(template[num]);
					num++;
					continue;
				}
				if (!flag)
				{
					stringBuilder.Append(text);
					num = num2 + 1;
					continue;
				}
				if (stringBuilder.Length > 0)
				{
					list.Add(new TextRun(stringBuilder.ToString(), isValue: false));
					stringBuilder.Clear();
				}
				if (text.Length > 0)
				{
					list.Add(new TextRun(text, isValue: true));
				}
				num = num2 + 1;
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(new TextRun(stringBuilder.ToString(), isValue: false));
			}
			return list;
		}

		public static string Plain(string template, params string[] values)
		{
			return Join(Split(template, values));
		}

		private static string Join(IReadOnlyList<TextRun> runs)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (TextRun run in runs)
			{
				stringBuilder.Append(run.Text);
			}
			return stringBuilder.ToString();
		}
	}
}
