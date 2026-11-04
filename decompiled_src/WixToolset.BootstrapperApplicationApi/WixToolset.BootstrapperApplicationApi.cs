using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.XPath;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETFramework,Version=v4.6.2", FrameworkDisplayName = ".NET Framework 4.6.2")]
[assembly: AssemblyCompany("WiX Toolset")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) .NET Foundation and contributors. All rights reserved.")]
[assembly: AssemblyDescription("Managed Bootstrapper Application API")]
[assembly: AssemblyFileVersion("5.0.0.0")]
[assembly: AssemblyInformationalVersion("5.0.0+41e11442b2ca93e444b60213b5ae99dcbab787d8")]
[assembly: AssemblyProduct("WiX Toolset")]
[assembly: AssemblyTitle("WixToolset.BootstrapperApplicationApi")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/wixtoolset/wix")]
[assembly: AssemblyVersion("5.0.0.0")]
namespace WixToolset.BootstrapperApplicationApi;

internal static class BalUtil
{
	[DllImport("mbanative.dll", ExactSpelling = true)]
	internal static extern int BalEscapeStringFromEngine([MarshalAs(UnmanagedType.Interface)] IBootstrapperEngine pEngine, [MarshalAs(UnmanagedType.LPWStr)] string wzIn, ref StrUtil.StrHandle psczOut);

	[DllImport("mbanative.dll", ExactSpelling = true)]
	internal static extern int BalFormatStringFromEngine([MarshalAs(UnmanagedType.Interface)] IBootstrapperEngine pEngine, [MarshalAs(UnmanagedType.LPWStr)] string wzFormat, ref StrUtil.StrHandle psczOut);

	[DllImport("mbanative.dll", ExactSpelling = true)]
	internal static extern int BalGetStringVariableFromEngine([MarshalAs(UnmanagedType.Interface)] IBootstrapperEngine pEngine, [MarshalAs(UnmanagedType.LPWStr)] string wzVariable, ref StrUtil.StrHandle psczOut);

	[DllImport("mbanative.dll", ExactSpelling = true)]
	internal static extern int BalGetVersionVariableFromEngine([MarshalAs(UnmanagedType.Interface)] IBootstrapperEngine pEngine, [MarshalAs(UnmanagedType.LPWStr)] string wzVariable, ref StrUtil.StrHandle psczOut);

	[DllImport("mbanative.dll", ExactSpelling = true)]
	internal static extern int BalGetRelatedBundleVariableFromEngine([MarshalAs(UnmanagedType.Interface)] IBootstrapperEngine pEngine, [MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.LPWStr)] string wzVariable, ref StrUtil.StrHandle psczOut);

	[DllImport("mbanative.dll", ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool BalVariableExistsFromEngine([MarshalAs(UnmanagedType.Interface)] IBootstrapperEngine pEngine, [MarshalAs(UnmanagedType.LPWStr)] string wzVariable);
}
[Obsolete("Bootstrapper applications now run out of proc and do not use a BootstrapperApplicationFactory. Remove your BootstrapperApplicationFactory class. See https://wixtoolset.org/docs/fiveforfour/ for more details.")]
public abstract class BaseBootstrapperApplicationFactory : IBootstrapperApplicationFactory
{
	public void Create(IntPtr pArgs, IntPtr pResults)
	{
		throw new NotImplementedException();
	}

	protected abstract IBootstrapperApplication Create(IEngine engine, IBootstrapperCommand bootstrapperCommand);

	public static void InitializeFromCreateArgs(IntPtr pArgs, out IEngine engine, out IBootstrapperCommand bootstrapperCommand)
	{
		throw new NotImplementedException();
	}

	public static void StoreBAInCreateResults(IntPtr pResults, IBootstrapperApplication ba)
	{
		throw new NotImplementedException();
	}
}
[ClassInterface(ClassInterfaceType.None)]
public abstract class BootstrapperApplication : MarshalByRefObject, IDefaultBootstrapperApplication, IBootstrapperApplication
{
	protected IEngine engine;

	public event EventHandler<CreateEventArgs> Create;

	public event EventHandler<DestroyEventArgs> Destroy;

	public event EventHandler<StartupEventArgs> Startup;

	public event EventHandler<ShutdownEventArgs> Shutdown;

	public event EventHandler<DetectBeginEventArgs> DetectBegin;

	public event EventHandler<DetectForwardCompatibleBundleEventArgs> DetectForwardCompatibleBundle;

	public event EventHandler<DetectUpdateBeginEventArgs> DetectUpdateBegin;

	public event EventHandler<DetectUpdateEventArgs> DetectUpdate;

	public event EventHandler<DetectUpdateCompleteEventArgs> DetectUpdateComplete;

	public event EventHandler<DetectRelatedBundleEventArgs> DetectRelatedBundle;

	public event EventHandler<DetectPackageBeginEventArgs> DetectPackageBegin;

	public event EventHandler<DetectCompatibleMsiPackageEventArgs> DetectCompatibleMsiPackage;

	public event EventHandler<DetectRelatedMsiPackageEventArgs> DetectRelatedMsiPackage;

	public event EventHandler<DetectPatchTargetEventArgs> DetectPatchTarget;

	public event EventHandler<DetectMsiFeatureEventArgs> DetectMsiFeature;

	public event EventHandler<DetectPackageCompleteEventArgs> DetectPackageComplete;

	public event EventHandler<DetectCompleteEventArgs> DetectComplete;

	public event EventHandler<PlanBeginEventArgs> PlanBegin;

	public event EventHandler<PlanRelatedBundleEventArgs> PlanRelatedBundle;

	public event EventHandler<PlanRelatedBundleTypeEventArgs> PlanRelatedBundleType;

	public event EventHandler<PlanRollbackBoundaryEventArgs> PlanRollbackBoundary;

	public event EventHandler<PlanPackageBeginEventArgs> PlanPackageBegin;

	public event EventHandler<PlanCompatibleMsiPackageBeginEventArgs> PlanCompatibleMsiPackageBegin;

	public event EventHandler<PlanCompatibleMsiPackageCompleteEventArgs> PlanCompatibleMsiPackageComplete;

	public event EventHandler<PlanPatchTargetEventArgs> PlanPatchTarget;

	public event EventHandler<PlanMsiFeatureEventArgs> PlanMsiFeature;

	public event EventHandler<PlanMsiPackageEventArgs> PlanMsiPackage;

	public event EventHandler<PlanPackageCompleteEventArgs> PlanPackageComplete;

	public event EventHandler<PlannedCompatiblePackageEventArgs> PlannedCompatiblePackage;

	public event EventHandler<PlannedPackageEventArgs> PlannedPackage;

	public event EventHandler<PlanCompleteEventArgs> PlanComplete;

	public event EventHandler<ApplyBeginEventArgs> ApplyBegin;

	public event EventHandler<ElevateBeginEventArgs> ElevateBegin;

	public event EventHandler<ElevateCompleteEventArgs> ElevateComplete;

	public event EventHandler<ProgressEventArgs> Progress;

	public event EventHandler<ErrorEventArgs> Error;

	public event EventHandler<RegisterBeginEventArgs> RegisterBegin;

	public event EventHandler<RegisterCompleteEventArgs> RegisterComplete;

	public event EventHandler<UnregisterBeginEventArgs> UnregisterBegin;

	public event EventHandler<UnregisterCompleteEventArgs> UnregisterComplete;

	public event EventHandler<CacheBeginEventArgs> CacheBegin;

	public event EventHandler<CachePackageBeginEventArgs> CachePackageBegin;

	public event EventHandler<CacheAcquireBeginEventArgs> CacheAcquireBegin;

	public event EventHandler<CacheAcquireProgressEventArgs> CacheAcquireProgress;

	public event EventHandler<CacheAcquireResolvingEventArgs> CacheAcquireResolving;

	public event EventHandler<CacheAcquireCompleteEventArgs> CacheAcquireComplete;

	public event EventHandler<CacheVerifyBeginEventArgs> CacheVerifyBegin;

	public event EventHandler<CacheVerifyProgressEventArgs> CacheVerifyProgress;

	public event EventHandler<CacheVerifyCompleteEventArgs> CacheVerifyComplete;

	public event EventHandler<CachePackageCompleteEventArgs> CachePackageComplete;

	public event EventHandler<CacheCompleteEventArgs> CacheComplete;

	public event EventHandler<ExecuteBeginEventArgs> ExecuteBegin;

	public event EventHandler<ExecutePackageBeginEventArgs> ExecutePackageBegin;

	public event EventHandler<ExecutePatchTargetEventArgs> ExecutePatchTarget;

	public event EventHandler<ExecuteMsiMessageEventArgs> ExecuteMsiMessage;

	public event EventHandler<ExecuteFilesInUseEventArgs> ExecuteFilesInUse;

	public event EventHandler<ExecutePackageCompleteEventArgs> ExecutePackageComplete;

	public event EventHandler<ExecuteCompleteEventArgs> ExecuteComplete;

	public event EventHandler<ApplyCompleteEventArgs> ApplyComplete;

	public event EventHandler<ApplyDowngradeEventArgs> ApplyDowngrade;

	public event EventHandler<ExecuteProgressEventArgs> ExecuteProgress;

	public event EventHandler<LaunchApprovedExeBeginEventArgs> LaunchApprovedExeBegin;

	public event EventHandler<LaunchApprovedExeCompleteEventArgs> LaunchApprovedExeComplete;

	public event EventHandler<BeginMsiTransactionBeginEventArgs> BeginMsiTransactionBegin;

	public event EventHandler<BeginMsiTransactionCompleteEventArgs> BeginMsiTransactionComplete;

	public event EventHandler<CommitMsiTransactionBeginEventArgs> CommitMsiTransactionBegin;

	public event EventHandler<CommitMsiTransactionCompleteEventArgs> CommitMsiTransactionComplete;

	public event EventHandler<RollbackMsiTransactionBeginEventArgs> RollbackMsiTransactionBegin;

	public event EventHandler<RollbackMsiTransactionCompleteEventArgs> RollbackMsiTransactionComplete;

	public event EventHandler<PauseAutomaticUpdatesBeginEventArgs> PauseAutomaticUpdatesBegin;

	public event EventHandler<PauseAutomaticUpdatesCompleteEventArgs> PauseAutomaticUpdatesComplete;

	public event EventHandler<SystemRestorePointBeginEventArgs> SystemRestorePointBegin;

	public event EventHandler<SystemRestorePointCompleteEventArgs> SystemRestorePointComplete;

	public event EventHandler<PlanForwardCompatibleBundleEventArgs> PlanForwardCompatibleBundle;

	public event EventHandler<CacheContainerOrPayloadVerifyBeginEventArgs> CacheContainerOrPayloadVerifyBegin;

	public event EventHandler<CacheContainerOrPayloadVerifyProgressEventArgs> CacheContainerOrPayloadVerifyProgress;

	public event EventHandler<CacheContainerOrPayloadVerifyCompleteEventArgs> CacheContainerOrPayloadVerifyComplete;

	public event EventHandler<CachePayloadExtractBeginEventArgs> CachePayloadExtractBegin;

	public event EventHandler<CachePayloadExtractProgressEventArgs> CachePayloadExtractProgress;

	public event EventHandler<CachePayloadExtractCompleteEventArgs> CachePayloadExtractComplete;

	public event EventHandler<PlanRestoreRelatedBundleEventArgs> PlanRestoreRelatedBundle;

	public event EventHandler<ExecuteProcessCancelEventArgs> ExecuteProcessCancel;

	public event EventHandler<DetectRelatedBundlePackageEventArgs> DetectRelatedBundlePackage;

	public event EventHandler<CachePackageNonVitalValidationFailureEventArgs> CachePackageNonVitalValidationFailure;

	protected BootstrapperApplication()
	{
	}

	[Obsolete("This constructor is no longer used. Use the default constructor. The engine object will be valid after handling the OnCreate() event.")]
	protected BootstrapperApplication(IEngine engine)
	{
		throw new NotImplementedException("This constructor is no longer used. Use the default constructor. The engine object will be valid after handling the OnCreate() event.");
	}

	protected abstract void Run();

	protected virtual void OnCreate(CreateEventArgs args)
	{
		engine = args.Engine;
		Create?.Invoke(this, args);
	}

	protected virtual void OnDestroy(DestroyEventArgs args)
	{
		Destroy?.Invoke(this, args);
	}

	protected virtual void OnStartup(StartupEventArgs args)
	{
		Startup?.Invoke(this, args);
		Thread thread = new Thread(Run);
		thread.Name = "UIThread";
		thread.SetApartmentState(ApartmentState.STA);
		thread.Start();
	}

	protected virtual void OnShutdown(ShutdownEventArgs args)
	{
		Shutdown?.Invoke(this, args);
	}

	protected virtual void OnDetectBegin(DetectBeginEventArgs args)
	{
		DetectBegin?.Invoke(this, args);
	}

	protected virtual void OnDetectForwardCompatibleBundle(DetectForwardCompatibleBundleEventArgs args)
	{
		DetectForwardCompatibleBundle?.Invoke(this, args);
	}

	protected virtual void OnDetectUpdateBegin(DetectUpdateBeginEventArgs args)
	{
		DetectUpdateBegin?.Invoke(this, args);
	}

	protected virtual void OnDetectUpdate(DetectUpdateEventArgs args)
	{
		DetectUpdate?.Invoke(this, args);
	}

	protected virtual void OnDetectUpdateComplete(DetectUpdateCompleteEventArgs args)
	{
		DetectUpdateComplete?.Invoke(this, args);
	}

	protected virtual void OnDetectRelatedBundle(DetectRelatedBundleEventArgs args)
	{
		DetectRelatedBundle?.Invoke(this, args);
	}

	protected virtual void OnDetectPackageBegin(DetectPackageBeginEventArgs args)
	{
		DetectPackageBegin?.Invoke(this, args);
	}

	protected virtual void OnDetectCompatibleMsiPackage(DetectCompatibleMsiPackageEventArgs args)
	{
		DetectCompatibleMsiPackage?.Invoke(this, args);
	}

	protected virtual void OnDetectRelatedMsiPackage(DetectRelatedMsiPackageEventArgs args)
	{
		DetectRelatedMsiPackage?.Invoke(this, args);
	}

	protected virtual void OnDetectPatchTarget(DetectPatchTargetEventArgs args)
	{
		DetectPatchTarget?.Invoke(this, args);
	}

	protected virtual void OnDetectMsiFeature(DetectMsiFeatureEventArgs args)
	{
		DetectMsiFeature?.Invoke(this, args);
	}

	protected virtual void OnDetectPackageComplete(DetectPackageCompleteEventArgs args)
	{
		DetectPackageComplete?.Invoke(this, args);
	}

	protected virtual void OnDetectComplete(DetectCompleteEventArgs args)
	{
		DetectComplete?.Invoke(this, args);
	}

	protected virtual void OnPlanBegin(PlanBeginEventArgs args)
	{
		PlanBegin?.Invoke(this, args);
	}

	protected virtual void OnPlanRelatedBundle(PlanRelatedBundleEventArgs args)
	{
		PlanRelatedBundle?.Invoke(this, args);
	}

	protected virtual void OnPlanRelatedBundleType(PlanRelatedBundleTypeEventArgs args)
	{
		PlanRelatedBundleType?.Invoke(this, args);
	}

	protected virtual void OnPlanRollbackBoundary(PlanRollbackBoundaryEventArgs args)
	{
		PlanRollbackBoundary?.Invoke(this, args);
	}

	protected virtual void OnPlanPackageBegin(PlanPackageBeginEventArgs args)
	{
		PlanPackageBegin?.Invoke(this, args);
	}

	protected virtual void OnPlanCompatibleMsiPackageBegin(PlanCompatibleMsiPackageBeginEventArgs args)
	{
		PlanCompatibleMsiPackageBegin?.Invoke(this, args);
	}

	protected virtual void OnPlanCompatibleMsiPackageComplete(PlanCompatibleMsiPackageCompleteEventArgs args)
	{
		PlanCompatibleMsiPackageComplete?.Invoke(this, args);
	}

	protected virtual void OnPlanPatchTarget(PlanPatchTargetEventArgs args)
	{
		PlanPatchTarget?.Invoke(this, args);
	}

	protected virtual void OnPlanMsiFeature(PlanMsiFeatureEventArgs args)
	{
		PlanMsiFeature?.Invoke(this, args);
	}

	protected virtual void OnPlanMsiPackage(PlanMsiPackageEventArgs args)
	{
		PlanMsiPackage?.Invoke(this, args);
	}

	protected virtual void OnPlanPackageComplete(PlanPackageCompleteEventArgs args)
	{
		PlanPackageComplete?.Invoke(this, args);
	}

	protected virtual void OnPlannedCompatiblePackage(PlannedCompatiblePackageEventArgs args)
	{
		PlannedCompatiblePackage?.Invoke(this, args);
	}

	protected virtual void OnPlannedPackage(PlannedPackageEventArgs args)
	{
		PlannedPackage?.Invoke(this, args);
	}

	protected virtual void OnPlanComplete(PlanCompleteEventArgs args)
	{
		PlanComplete?.Invoke(this, args);
	}

	protected virtual void OnApplyBegin(ApplyBeginEventArgs args)
	{
		ApplyBegin?.Invoke(this, args);
	}

	protected virtual void OnElevateBegin(ElevateBeginEventArgs args)
	{
		ElevateBegin?.Invoke(this, args);
	}

	protected virtual void OnElevateComplete(ElevateCompleteEventArgs args)
	{
		ElevateComplete?.Invoke(this, args);
	}

	protected virtual void OnProgress(ProgressEventArgs args)
	{
		Progress?.Invoke(this, args);
	}

	protected virtual void OnError(ErrorEventArgs args)
	{
		Error?.Invoke(this, args);
	}

	protected virtual void OnRegisterBegin(RegisterBeginEventArgs args)
	{
		RegisterBegin?.Invoke(this, args);
	}

	protected virtual void OnRegisterComplete(RegisterCompleteEventArgs args)
	{
		RegisterComplete?.Invoke(this, args);
	}

	protected virtual void OnUnregisterBegin(UnregisterBeginEventArgs args)
	{
		UnregisterBegin?.Invoke(this, args);
	}

	protected virtual void OnUnregisterComplete(UnregisterCompleteEventArgs args)
	{
		UnregisterComplete?.Invoke(this, args);
	}

	protected virtual void OnCacheBegin(CacheBeginEventArgs args)
	{
		CacheBegin?.Invoke(this, args);
	}

	protected virtual void OnCachePackageBegin(CachePackageBeginEventArgs args)
	{
		CachePackageBegin?.Invoke(this, args);
	}

	protected virtual void OnCacheAcquireBegin(CacheAcquireBeginEventArgs args)
	{
		CacheAcquireBegin?.Invoke(this, args);
	}

	protected virtual void OnCacheAcquireProgress(CacheAcquireProgressEventArgs args)
	{
		CacheAcquireProgress?.Invoke(this, args);
	}

	protected virtual void OnCacheAcquireResolving(CacheAcquireResolvingEventArgs args)
	{
		CacheAcquireResolving?.Invoke(this, args);
	}

	protected virtual void OnCacheAcquireComplete(CacheAcquireCompleteEventArgs args)
	{
		CacheAcquireComplete?.Invoke(this, args);
	}

	protected virtual void OnCacheVerifyBegin(CacheVerifyBeginEventArgs args)
	{
		CacheVerifyBegin?.Invoke(this, args);
	}

	protected virtual void OnCacheVerifyProgress(CacheVerifyProgressEventArgs args)
	{
		CacheVerifyProgress?.Invoke(this, args);
	}

	protected virtual void OnCacheVerifyComplete(CacheVerifyCompleteEventArgs args)
	{
		CacheVerifyComplete?.Invoke(this, args);
	}

	protected virtual void OnCachePackageComplete(CachePackageCompleteEventArgs args)
	{
		CachePackageComplete?.Invoke(this, args);
	}

	protected virtual void OnCacheComplete(CacheCompleteEventArgs args)
	{
		CacheComplete?.Invoke(this, args);
	}

	protected virtual void OnExecuteBegin(ExecuteBeginEventArgs args)
	{
		ExecuteBegin?.Invoke(this, args);
	}

	protected virtual void OnExecutePackageBegin(ExecutePackageBeginEventArgs args)
	{
		ExecutePackageBegin?.Invoke(this, args);
	}

	protected virtual void OnExecutePatchTarget(ExecutePatchTargetEventArgs args)
	{
		ExecutePatchTarget?.Invoke(this, args);
	}

	protected virtual void OnExecuteMsiMessage(ExecuteMsiMessageEventArgs args)
	{
		ExecuteMsiMessage?.Invoke(this, args);
	}

	protected virtual void OnExecuteFilesInUse(ExecuteFilesInUseEventArgs args)
	{
		ExecuteFilesInUse?.Invoke(this, args);
	}

	protected virtual void OnExecutePackageComplete(ExecutePackageCompleteEventArgs args)
	{
		ExecutePackageComplete?.Invoke(this, args);
	}

	protected virtual void OnExecuteComplete(ExecuteCompleteEventArgs args)
	{
		ExecuteComplete?.Invoke(this, args);
	}

	protected virtual void OnApplyComplete(ApplyCompleteEventArgs args)
	{
		ApplyComplete?.Invoke(this, args);
	}

	protected virtual void OnApplyDowngrade(ApplyDowngradeEventArgs args)
	{
		ApplyDowngrade?.Invoke(this, args);
	}

	protected virtual void OnExecuteProgress(ExecuteProgressEventArgs args)
	{
		ExecuteProgress?.Invoke(this, args);
	}

	protected virtual void OnLaunchApprovedExeBegin(LaunchApprovedExeBeginEventArgs args)
	{
		LaunchApprovedExeBegin?.Invoke(this, args);
	}

	protected virtual void OnLaunchApprovedExeComplete(LaunchApprovedExeCompleteEventArgs args)
	{
		LaunchApprovedExeComplete?.Invoke(this, args);
	}

	protected virtual void OnBeginMsiTransactionBegin(BeginMsiTransactionBeginEventArgs args)
	{
		BeginMsiTransactionBegin?.Invoke(this, args);
	}

	protected virtual void OnBeginMsiTransactionComplete(BeginMsiTransactionCompleteEventArgs args)
	{
		BeginMsiTransactionComplete?.Invoke(this, args);
	}

	protected virtual void OnCommitMsiTransactionBegin(CommitMsiTransactionBeginEventArgs args)
	{
		CommitMsiTransactionBegin?.Invoke(this, args);
	}

	protected virtual void OnCommitMsiTransactionComplete(CommitMsiTransactionCompleteEventArgs args)
	{
		CommitMsiTransactionComplete?.Invoke(this, args);
	}

	protected virtual void OnRollbackMsiTransactionBegin(RollbackMsiTransactionBeginEventArgs args)
	{
		RollbackMsiTransactionBegin?.Invoke(this, args);
	}

	protected virtual void OnRollbackMsiTransactionComplete(RollbackMsiTransactionCompleteEventArgs args)
	{
		RollbackMsiTransactionComplete?.Invoke(this, args);
	}

	protected virtual void OnPauseAutomaticUpdatesBegin(PauseAutomaticUpdatesBeginEventArgs args)
	{
		PauseAutomaticUpdatesBegin?.Invoke(this, args);
	}

	protected virtual void OnPauseAutomaticUpdatesComplete(PauseAutomaticUpdatesCompleteEventArgs args)
	{
		PauseAutomaticUpdatesComplete?.Invoke(this, args);
	}

	protected virtual void OnSystemRestorePointBegin(SystemRestorePointBeginEventArgs args)
	{
		SystemRestorePointBegin?.Invoke(this, args);
	}

	protected virtual void OnSystemRestorePointComplete(SystemRestorePointCompleteEventArgs args)
	{
		SystemRestorePointComplete?.Invoke(this, args);
	}

	protected virtual void OnPlanForwardCompatibleBundle(PlanForwardCompatibleBundleEventArgs args)
	{
		PlanForwardCompatibleBundle?.Invoke(this, args);
	}

	protected virtual void OnCacheContainerOrPayloadVerifyBegin(CacheContainerOrPayloadVerifyBeginEventArgs args)
	{
		CacheContainerOrPayloadVerifyBegin?.Invoke(this, args);
	}

	protected virtual void OnCacheContainerOrPayloadVerifyProgress(CacheContainerOrPayloadVerifyProgressEventArgs args)
	{
		CacheContainerOrPayloadVerifyProgress?.Invoke(this, args);
	}

	protected virtual void OnCacheContainerOrPayloadVerifyComplete(CacheContainerOrPayloadVerifyCompleteEventArgs args)
	{
		CacheContainerOrPayloadVerifyComplete?.Invoke(this, args);
	}

	protected virtual void OnCachePayloadExtractBegin(CachePayloadExtractBeginEventArgs args)
	{
		CachePayloadExtractBegin?.Invoke(this, args);
	}

	protected virtual void OnCachePayloadExtractProgress(CachePayloadExtractProgressEventArgs args)
	{
		CachePayloadExtractProgress?.Invoke(this, args);
	}

	protected virtual void OnCachePayloadExtractComplete(CachePayloadExtractCompleteEventArgs args)
	{
		CachePayloadExtractComplete?.Invoke(this, args);
	}

	protected virtual void OnPlanRestoreRelatedBundle(PlanRestoreRelatedBundleEventArgs args)
	{
		PlanRestoreRelatedBundle?.Invoke(this, args);
	}

	protected virtual void OnExecuteProcessCancel(ExecuteProcessCancelEventArgs args)
	{
		ExecuteProcessCancel?.Invoke(this, args);
	}

	protected virtual void OnDetectRelatedBundlePackage(DetectRelatedBundlePackageEventArgs args)
	{
		DetectRelatedBundlePackage?.Invoke(this, args);
	}

	protected virtual void OnCachePackageNonVitalValidationFailure(CachePackageNonVitalValidationFailureEventArgs args)
	{
		CachePackageNonVitalValidationFailure?.Invoke(this, args);
	}

	int IBootstrapperApplication.BAProc(int message, IntPtr pvArgs, IntPtr pvResults)
	{
		return -2147467263;
	}

	void IBootstrapperApplication.BAProcFallback(int message, IntPtr pvArgs, IntPtr pvResults, ref int phr)
	{
	}

	int IBootstrapperApplication.OnCreate(IBootstrapperEngine engine, ref Command command)
	{
		CreateEventArgs e = new CreateEventArgs(new Engine(engine), command.GetBootstrapperCommand());
		OnCreate(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnDestroy(bool reload)
	{
		DestroyEventArgs e = new DestroyEventArgs(reload);
		OnDestroy(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnStartup()
	{
		StartupEventArgs e = new StartupEventArgs();
		OnStartup(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnShutdown(ref BOOTSTRAPPER_SHUTDOWN_ACTION action)
	{
		ShutdownEventArgs e = new ShutdownEventArgs(action);
		OnShutdown(e);
		action = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectBegin(bool fCached, RegistrationType registrationType, int cPackages, ref bool fCancel)
	{
		DetectBeginEventArgs e = new DetectBeginEventArgs(fCached, registrationType, cPackages, fCancel);
		OnDetectBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectForwardCompatibleBundle(string wzBundleId, RelationType relationType, string wzBundleTag, bool fPerMachine, string wzVersion, bool fMissingFromCache, ref bool fCancel)
	{
		DetectForwardCompatibleBundleEventArgs e = new DetectForwardCompatibleBundleEventArgs(wzBundleId, relationType, wzBundleTag, fPerMachine, wzVersion, fMissingFromCache, fCancel);
		OnDetectForwardCompatibleBundle(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectUpdateBegin(string wzUpdateLocation, ref bool fCancel, ref bool fSkip)
	{
		DetectUpdateBeginEventArgs e = new DetectUpdateBeginEventArgs(wzUpdateLocation, fCancel, fSkip);
		OnDetectUpdateBegin(e);
		fCancel = e.Cancel;
		fSkip = e.Skip;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectUpdate(string wzUpdateLocation, long dw64Size, string wzHash, UpdateHashType hashAlgorithm, string wzVersion, string wzTitle, string wzSummary, string wzContentType, string wzContent, ref bool fCancel, ref bool fStopProcessingUpdates)
	{
		DetectUpdateEventArgs e = new DetectUpdateEventArgs(wzUpdateLocation, dw64Size, wzHash, hashAlgorithm, wzVersion, wzTitle, wzSummary, wzContentType, wzContent, fCancel, fStopProcessingUpdates);
		OnDetectUpdate(e);
		fCancel = e.Cancel;
		fStopProcessingUpdates = e.StopProcessingUpdates;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectUpdateComplete(int hrStatus, ref bool fIgnoreError)
	{
		DetectUpdateCompleteEventArgs e = new DetectUpdateCompleteEventArgs(hrStatus, fIgnoreError);
		OnDetectUpdateComplete(e);
		fIgnoreError = e.IgnoreError;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectRelatedBundle(string wzProductCode, RelationType relationType, string wzBundleTag, bool fPerMachine, string wzVersion, bool fMissingFromCache, ref bool fCancel)
	{
		DetectRelatedBundleEventArgs e = new DetectRelatedBundleEventArgs(wzProductCode, relationType, wzBundleTag, fPerMachine, wzVersion, fMissingFromCache, fCancel);
		OnDetectRelatedBundle(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectPackageBegin(string wzPackageId, ref bool fCancel)
	{
		DetectPackageBeginEventArgs e = new DetectPackageBeginEventArgs(wzPackageId, fCancel);
		OnDetectPackageBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectCompatibleMsiPackage(string wzPackageId, string wzCompatiblePackageId, string wzCompatiblePackageVersion, ref bool fCancel)
	{
		DetectCompatibleMsiPackageEventArgs e = new DetectCompatibleMsiPackageEventArgs(wzPackageId, wzCompatiblePackageId, wzCompatiblePackageVersion, fCancel);
		OnDetectCompatibleMsiPackage(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectRelatedMsiPackage(string wzPackageId, string wzUpgradeCode, string wzProductCode, bool fPerMachine, string wzVersion, RelatedOperation operation, ref bool fCancel)
	{
		DetectRelatedMsiPackageEventArgs e = new DetectRelatedMsiPackageEventArgs(wzPackageId, wzUpgradeCode, wzProductCode, fPerMachine, wzVersion, operation, fCancel);
		OnDetectRelatedMsiPackage(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectPatchTarget(string wzPackageId, string wzProductCode, PackageState patchState, ref bool fCancel)
	{
		DetectPatchTargetEventArgs e = new DetectPatchTargetEventArgs(wzPackageId, wzProductCode, patchState, fCancel);
		OnDetectPatchTarget(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectMsiFeature(string wzPackageId, string wzFeatureId, FeatureState state, ref bool fCancel)
	{
		DetectMsiFeatureEventArgs e = new DetectMsiFeatureEventArgs(wzPackageId, wzFeatureId, state, fCancel);
		OnDetectMsiFeature(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectPackageComplete(string wzPackageId, int hrStatus, PackageState state, bool fCached)
	{
		DetectPackageCompleteEventArgs e = new DetectPackageCompleteEventArgs(wzPackageId, hrStatus, state, fCached);
		OnDetectPackageComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectComplete(int hrStatus, bool fEligibleForCleanup)
	{
		DetectCompleteEventArgs e = new DetectCompleteEventArgs(hrStatus, fEligibleForCleanup);
		OnDetectComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanBegin(int cPackages, ref bool fCancel)
	{
		PlanBeginEventArgs e = new PlanBeginEventArgs(cPackages, fCancel);
		OnPlanBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanRelatedBundle(string wzBundleId, RequestState recommendedState, ref RequestState pRequestedState, ref bool fCancel)
	{
		PlanRelatedBundleEventArgs e = new PlanRelatedBundleEventArgs(wzBundleId, recommendedState, pRequestedState, fCancel);
		OnPlanRelatedBundle(e);
		pRequestedState = e.State;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanRelatedBundleType(string wzBundleId, RelatedBundlePlanType recommendedType, ref RelatedBundlePlanType pRequestedType, ref bool fCancel)
	{
		PlanRelatedBundleTypeEventArgs e = new PlanRelatedBundleTypeEventArgs(wzBundleId, recommendedType, pRequestedType, fCancel);
		OnPlanRelatedBundleType(e);
		pRequestedType = e.Type;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanRollbackBoundary(string wzRollbackBoundaryId, bool fRecommendedTransaction, ref bool fTransaction, ref bool fCancel)
	{
		PlanRollbackBoundaryEventArgs e = new PlanRollbackBoundaryEventArgs(wzRollbackBoundaryId, fRecommendedTransaction, fTransaction, fCancel);
		OnPlanRollbackBoundary(e);
		fTransaction = e.Transaction;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanPackageBegin(string wzPackageId, PackageState state, bool fCached, BOOTSTRAPPER_PACKAGE_CONDITION_RESULT installCondition, BOOTSTRAPPER_PACKAGE_CONDITION_RESULT repairCondition, RequestState recommendedState, BOOTSTRAPPER_CACHE_TYPE recommendedCacheType, ref RequestState pRequestedState, ref BOOTSTRAPPER_CACHE_TYPE pRequestedCacheType, ref bool fCancel)
	{
		PlanPackageBeginEventArgs e = new PlanPackageBeginEventArgs(wzPackageId, state, fCached, installCondition, repairCondition, recommendedState, recommendedCacheType, pRequestedState, pRequestedCacheType, fCancel);
		OnPlanPackageBegin(e);
		pRequestedState = e.State;
		pRequestedCacheType = e.CacheType;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanCompatibleMsiPackageBegin(string wzPackageId, string wzCompatiblePackageId, string wzCompatiblePackageVersion, bool recommendedRemove, ref bool pRequestedRemove, ref bool fCancel)
	{
		PlanCompatibleMsiPackageBeginEventArgs e = new PlanCompatibleMsiPackageBeginEventArgs(wzPackageId, wzCompatiblePackageId, wzCompatiblePackageVersion, recommendedRemove, pRequestedRemove, fCancel);
		OnPlanCompatibleMsiPackageBegin(e);
		pRequestedRemove = e.RequestRemove;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanCompatibleMsiPackageComplete(string wzPackageId, string wzCompatiblePackageId, int hrStatus, bool requestedRemove)
	{
		PlanCompatibleMsiPackageCompleteEventArgs e = new PlanCompatibleMsiPackageCompleteEventArgs(wzPackageId, wzCompatiblePackageId, hrStatus, requestedRemove);
		OnPlanCompatibleMsiPackageComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanPatchTarget(string wzPackageId, string wzProductCode, RequestState recommendedState, ref RequestState pRequestedState, ref bool fCancel)
	{
		PlanPatchTargetEventArgs e = new PlanPatchTargetEventArgs(wzPackageId, wzProductCode, recommendedState, pRequestedState, fCancel);
		OnPlanPatchTarget(e);
		pRequestedState = e.State;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanMsiFeature(string wzPackageId, string wzFeatureId, FeatureState recommendedState, ref FeatureState pRequestedState, ref bool fCancel)
	{
		PlanMsiFeatureEventArgs e = new PlanMsiFeatureEventArgs(wzPackageId, wzFeatureId, recommendedState, pRequestedState, fCancel);
		OnPlanMsiFeature(e);
		pRequestedState = e.State;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanMsiPackage(string wzPackageId, bool fExecute, ActionState action, BOOTSTRAPPER_MSI_FILE_VERSIONING recommendedFileVersioning, ref bool fCancel, ref BURN_MSI_PROPERTY actionMsiProperty, ref INSTALLUILEVEL uiLevel, ref bool fDisableExternalUiHandler, ref BOOTSTRAPPER_MSI_FILE_VERSIONING fileVersioning)
	{
		PlanMsiPackageEventArgs e = new PlanMsiPackageEventArgs(wzPackageId, fExecute, action, recommendedFileVersioning, fCancel, actionMsiProperty, uiLevel, fDisableExternalUiHandler, fileVersioning);
		OnPlanMsiPackage(e);
		fCancel = e.Cancel;
		actionMsiProperty = e.ActionMsiProperty;
		uiLevel = e.UiLevel;
		fDisableExternalUiHandler = e.DisableExternalUiHandler;
		fileVersioning = e.FileVersioning;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanPackageComplete(string wzPackageId, int hrStatus, RequestState requested)
	{
		PlanPackageCompleteEventArgs e = new PlanPackageCompleteEventArgs(wzPackageId, hrStatus, requested);
		OnPlanPackageComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlannedCompatiblePackage(string wzPackageId, string wzCompatiblePackageId, bool remove)
	{
		PlannedCompatiblePackageEventArgs e = new PlannedCompatiblePackageEventArgs(wzPackageId, wzCompatiblePackageId, remove);
		OnPlannedCompatiblePackage(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlannedPackage(string wzPackageId, ActionState execute, ActionState rollback, bool fPlannedCache, bool fPlannedUncache)
	{
		PlannedPackageEventArgs e = new PlannedPackageEventArgs(wzPackageId, execute, rollback, fPlannedCache, fPlannedUncache);
		OnPlannedPackage(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanComplete(int hrStatus)
	{
		PlanCompleteEventArgs e = new PlanCompleteEventArgs(hrStatus);
		OnPlanComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnApplyBegin(int dwPhaseCount, ref bool fCancel)
	{
		ApplyBeginEventArgs e = new ApplyBeginEventArgs(dwPhaseCount, fCancel);
		OnApplyBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnElevateBegin(ref bool fCancel)
	{
		ElevateBeginEventArgs e = new ElevateBeginEventArgs(fCancel);
		OnElevateBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnElevateComplete(int hrStatus)
	{
		ElevateCompleteEventArgs e = new ElevateCompleteEventArgs(hrStatus);
		OnElevateComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnProgress(int dwProgressPercentage, int dwOverallPercentage, ref bool fCancel)
	{
		ProgressEventArgs e = new ProgressEventArgs(dwProgressPercentage, dwOverallPercentage, fCancel);
		OnProgress(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnError(ErrorType errorType, string wzPackageId, int dwCode, string wzError, int dwUIHint, int cData, string[] rgwzData, Result nRecommendation, ref Result pResult)
	{
		ErrorEventArgs e = new ErrorEventArgs(errorType, wzPackageId, dwCode, wzError, dwUIHint, rgwzData, nRecommendation, pResult);
		OnError(e);
		pResult = e.Result;
		return e.HResult;
	}

	int IBootstrapperApplication.OnRegisterBegin(RegistrationType recommendedRegistrationType, ref bool fCancel, ref RegistrationType registrationType)
	{
		RegisterBeginEventArgs e = new RegisterBeginEventArgs(recommendedRegistrationType, fCancel, registrationType);
		OnRegisterBegin(e);
		fCancel = e.Cancel;
		registrationType = e.RegistrationType;
		return e.HResult;
	}

	int IBootstrapperApplication.OnRegisterComplete(int hrStatus)
	{
		RegisterCompleteEventArgs e = new RegisterCompleteEventArgs(hrStatus);
		OnRegisterComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheBegin(ref bool fCancel)
	{
		CacheBeginEventArgs e = new CacheBeginEventArgs(fCancel);
		OnCacheBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCachePackageBegin(string wzPackageId, int cCachePayloads, long dw64PackageCacheSize, bool fVital, ref bool fCancel)
	{
		CachePackageBeginEventArgs e = new CachePackageBeginEventArgs(wzPackageId, cCachePayloads, dw64PackageCacheSize, fVital, fCancel);
		OnCachePackageBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheAcquireBegin(string wzPackageOrContainerId, string wzPayloadId, string wzSource, string wzDownloadUrl, string wzPayloadContainerId, CacheOperation recommendation, ref CacheOperation action, ref bool fCancel)
	{
		CacheAcquireBeginEventArgs e = new CacheAcquireBeginEventArgs(wzPackageOrContainerId, wzPayloadId, wzSource, wzDownloadUrl, wzPayloadContainerId, recommendation, action, fCancel);
		OnCacheAcquireBegin(e);
		action = e.Action;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheAcquireProgress(string wzPackageOrContainerId, string wzPayloadId, long dw64Progress, long dw64Total, int dwOverallPercentage, ref bool fCancel)
	{
		CacheAcquireProgressEventArgs e = new CacheAcquireProgressEventArgs(wzPackageOrContainerId, wzPayloadId, dw64Progress, dw64Total, dwOverallPercentage, fCancel);
		OnCacheAcquireProgress(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheAcquireResolving(string wzPackageOrContainerId, string wzPayloadId, string[] searchPaths, int cSearchPaths, bool fFoundLocal, int dwRecommendedSearchPath, string wzDownloadUrl, string wzPayloadContainerId, CacheResolveOperation recommendation, ref int dwChosenSearchPath, ref CacheResolveOperation action, ref bool fCancel)
	{
		CacheAcquireResolvingEventArgs e = new CacheAcquireResolvingEventArgs(wzPackageOrContainerId, wzPayloadId, searchPaths, fFoundLocal, dwRecommendedSearchPath, wzDownloadUrl, wzPayloadContainerId, recommendation, dwChosenSearchPath, action, fCancel);
		OnCacheAcquireResolving(e);
		dwChosenSearchPath = e.ChosenSearchPath;
		action = e.Action;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheAcquireComplete(string wzPackageOrContainerId, string wzPayloadId, int hrStatus, BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION action)
	{
		CacheAcquireCompleteEventArgs e = new CacheAcquireCompleteEventArgs(wzPackageOrContainerId, wzPayloadId, hrStatus, recommendation, action);
		OnCacheAcquireComplete(e);
		action = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheVerifyBegin(string wzPackageOrContainerId, string wzPayloadId, ref bool fCancel)
	{
		CacheVerifyBeginEventArgs e = new CacheVerifyBeginEventArgs(wzPackageOrContainerId, wzPayloadId, fCancel);
		OnCacheVerifyBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheVerifyProgress(string wzPackageOrContainerId, string wzPayloadId, long dw64Progress, long dw64Total, int dwOverallPercentage, CacheVerifyStep verifyStep, ref bool fCancel)
	{
		CacheVerifyProgressEventArgs e = new CacheVerifyProgressEventArgs(wzPackageOrContainerId, wzPayloadId, dw64Progress, dw64Total, dwOverallPercentage, verifyStep, fCancel);
		OnCacheVerifyProgress(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheVerifyComplete(string wzPackageOrContainerId, string wzPayloadId, int hrStatus, BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION action)
	{
		CacheVerifyCompleteEventArgs e = new CacheVerifyCompleteEventArgs(wzPackageOrContainerId, wzPayloadId, hrStatus, recommendation, action);
		OnCacheVerifyComplete(e);
		action = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCachePackageComplete(string wzPackageId, int hrStatus, BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION action)
	{
		CachePackageCompleteEventArgs e = new CachePackageCompleteEventArgs(wzPackageId, hrStatus, recommendation, action);
		OnCachePackageComplete(e);
		action = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheComplete(int hrStatus)
	{
		CacheCompleteEventArgs e = new CacheCompleteEventArgs(hrStatus);
		OnCacheComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecuteBegin(int cExecutingPackages, ref bool fCancel)
	{
		ExecuteBeginEventArgs e = new ExecuteBeginEventArgs(cExecutingPackages, fCancel);
		OnExecuteBegin(e);
		e.Cancel = fCancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecutePackageBegin(string wzPackageId, bool fExecute, ActionState action, INSTALLUILEVEL uiLevel, bool fDisableExternalUiHandler, ref bool fCancel)
	{
		ExecutePackageBeginEventArgs e = new ExecutePackageBeginEventArgs(wzPackageId, fExecute, action, uiLevel, fDisableExternalUiHandler, fCancel);
		OnExecutePackageBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecutePatchTarget(string wzPackageId, string wzTargetProductCode, ref bool fCancel)
	{
		ExecutePatchTargetEventArgs e = new ExecutePatchTargetEventArgs(wzPackageId, wzTargetProductCode, fCancel);
		OnExecutePatchTarget(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecuteProgress(string wzPackageId, int dwProgressPercentage, int dwOverallPercentage, ref bool fCancel)
	{
		ExecuteProgressEventArgs e = new ExecuteProgressEventArgs(wzPackageId, dwProgressPercentage, dwOverallPercentage, fCancel);
		OnExecuteProgress(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecuteMsiMessage(string wzPackageId, InstallMessage messageType, int dwUIHint, string wzMessage, int cData, string[] rgwzData, Result nRecommendation, ref Result pResult)
	{
		ExecuteMsiMessageEventArgs e = new ExecuteMsiMessageEventArgs(wzPackageId, messageType, dwUIHint, wzMessage, rgwzData, nRecommendation, pResult);
		OnExecuteMsiMessage(e);
		pResult = e.Result;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecuteFilesInUse(string wzPackageId, int cFiles, string[] rgwzFiles, Result nRecommendation, FilesInUseType source, ref Result pResult)
	{
		ExecuteFilesInUseEventArgs e = new ExecuteFilesInUseEventArgs(wzPackageId, rgwzFiles, nRecommendation, source, pResult);
		OnExecuteFilesInUse(e);
		pResult = e.Result;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecutePackageComplete(string wzPackageId, int hrStatus, ApplyRestart restart, BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION pAction)
	{
		ExecutePackageCompleteEventArgs e = new ExecutePackageCompleteEventArgs(wzPackageId, hrStatus, restart, recommendation, pAction);
		OnExecutePackageComplete(e);
		pAction = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecuteComplete(int hrStatus)
	{
		ExecuteCompleteEventArgs e = new ExecuteCompleteEventArgs(hrStatus);
		OnExecuteComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnUnregisterBegin(RegistrationType recommendedRegistrationType, ref RegistrationType registrationType)
	{
		UnregisterBeginEventArgs e = new UnregisterBeginEventArgs(recommendedRegistrationType, registrationType);
		OnUnregisterBegin(e);
		registrationType = e.RegistrationType;
		return e.HResult;
	}

	int IBootstrapperApplication.OnUnregisterComplete(int hrStatus)
	{
		UnregisterCompleteEventArgs e = new UnregisterCompleteEventArgs(hrStatus);
		OnUnregisterComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnApplyComplete(int hrStatus, ApplyRestart restart, BOOTSTRAPPER_APPLYCOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_APPLYCOMPLETE_ACTION pAction)
	{
		ApplyCompleteEventArgs e = new ApplyCompleteEventArgs(hrStatus, restart, recommendation, pAction);
		OnApplyComplete(e);
		pAction = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnApplyDowngrade(int hrRecommendation, ref int hrStatus)
	{
		ApplyDowngradeEventArgs e = new ApplyDowngradeEventArgs(hrRecommendation, hrStatus);
		OnApplyDowngrade(e);
		hrStatus = e.Status;
		return e.HResult;
	}

	int IBootstrapperApplication.OnLaunchApprovedExeBegin(ref bool fCancel)
	{
		LaunchApprovedExeBeginEventArgs e = new LaunchApprovedExeBeginEventArgs(fCancel);
		OnLaunchApprovedExeBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnLaunchApprovedExeComplete(int hrStatus, int processId)
	{
		LaunchApprovedExeCompleteEventArgs e = new LaunchApprovedExeCompleteEventArgs(hrStatus, processId);
		OnLaunchApprovedExeComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnBeginMsiTransactionBegin(string transactionId, ref bool fCancel)
	{
		BeginMsiTransactionBeginEventArgs e = new BeginMsiTransactionBeginEventArgs(transactionId, fCancel);
		OnBeginMsiTransactionBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnBeginMsiTransactionComplete(string transactionId, int hrStatus)
	{
		BeginMsiTransactionCompleteEventArgs e = new BeginMsiTransactionCompleteEventArgs(transactionId, hrStatus);
		OnBeginMsiTransactionComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnCommitMsiTransactionBegin(string transactionId, ref bool fCancel)
	{
		CommitMsiTransactionBeginEventArgs e = new CommitMsiTransactionBeginEventArgs(transactionId, fCancel);
		OnCommitMsiTransactionBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCommitMsiTransactionComplete(string transactionId, int hrStatus, ApplyRestart restart, BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION pAction)
	{
		CommitMsiTransactionCompleteEventArgs e = new CommitMsiTransactionCompleteEventArgs(transactionId, hrStatus, restart, recommendation, pAction);
		OnCommitMsiTransactionComplete(e);
		pAction = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnRollbackMsiTransactionBegin(string transactionId)
	{
		RollbackMsiTransactionBeginEventArgs e = new RollbackMsiTransactionBeginEventArgs(transactionId);
		OnRollbackMsiTransactionBegin(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnRollbackMsiTransactionComplete(string transactionId, int hrStatus, ApplyRestart restart, BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION pAction)
	{
		RollbackMsiTransactionCompleteEventArgs e = new RollbackMsiTransactionCompleteEventArgs(transactionId, hrStatus, restart, recommendation, pAction);
		OnRollbackMsiTransactionComplete(e);
		pAction = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnPauseAutomaticUpdatesBegin()
	{
		PauseAutomaticUpdatesBeginEventArgs e = new PauseAutomaticUpdatesBeginEventArgs();
		OnPauseAutomaticUpdatesBegin(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPauseAutomaticUpdatesComplete(int hrStatus)
	{
		PauseAutomaticUpdatesCompleteEventArgs e = new PauseAutomaticUpdatesCompleteEventArgs(hrStatus);
		OnPauseAutomaticUpdatesComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnSystemRestorePointBegin()
	{
		SystemRestorePointBeginEventArgs e = new SystemRestorePointBeginEventArgs();
		OnSystemRestorePointBegin(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnSystemRestorePointComplete(int hrStatus)
	{
		SystemRestorePointCompleteEventArgs e = new SystemRestorePointCompleteEventArgs(hrStatus);
		OnSystemRestorePointComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanForwardCompatibleBundle(string wzBundleId, RelationType relationType, string wzBundleTag, bool fPerMachine, string wzVersion, bool fRecommendedIgnoreBundle, ref bool fCancel, ref bool fIgnoreBundle)
	{
		PlanForwardCompatibleBundleEventArgs e = new PlanForwardCompatibleBundleEventArgs(wzBundleId, relationType, wzBundleTag, fPerMachine, wzVersion, fRecommendedIgnoreBundle, fCancel, fIgnoreBundle);
		OnPlanForwardCompatibleBundle(e);
		fCancel = e.Cancel;
		fIgnoreBundle = e.IgnoreBundle;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheContainerOrPayloadVerifyBegin(string wzPackageOrContainerId, string wzPayloadId, ref bool fCancel)
	{
		CacheContainerOrPayloadVerifyBeginEventArgs e = new CacheContainerOrPayloadVerifyBeginEventArgs(wzPackageOrContainerId, wzPayloadId, fCancel);
		OnCacheContainerOrPayloadVerifyBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheContainerOrPayloadVerifyProgress(string wzPackageOrContainerId, string wzPayloadId, long dw64Progress, long dw64Total, int dwOverallPercentage, ref bool fCancel)
	{
		CacheContainerOrPayloadVerifyProgressEventArgs e = new CacheContainerOrPayloadVerifyProgressEventArgs(wzPackageOrContainerId, wzPayloadId, dw64Progress, dw64Total, dwOverallPercentage, fCancel);
		OnCacheContainerOrPayloadVerifyProgress(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCacheContainerOrPayloadVerifyComplete(string wzPackageOrContainerId, string wzPayloadId, int hrStatus)
	{
		CacheContainerOrPayloadVerifyCompleteEventArgs e = new CacheContainerOrPayloadVerifyCompleteEventArgs(wzPackageOrContainerId, wzPayloadId, hrStatus);
		OnCacheContainerOrPayloadVerifyComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnCachePayloadExtractBegin(string wzContainerId, string wzPayloadId, ref bool fCancel)
	{
		CachePayloadExtractBeginEventArgs e = new CachePayloadExtractBeginEventArgs(wzContainerId, wzPayloadId, fCancel);
		OnCachePayloadExtractBegin(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCachePayloadExtractProgress(string wzContainerId, string wzPayloadId, long dw64Progress, long dw64Total, int dwOverallPercentage, ref bool fCancel)
	{
		CachePayloadExtractProgressEventArgs e = new CachePayloadExtractProgressEventArgs(wzContainerId, wzPayloadId, dw64Progress, dw64Total, dwOverallPercentage, fCancel);
		OnCachePayloadExtractProgress(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCachePayloadExtractComplete(string wzContainerId, string wzPayloadId, int hrStatus)
	{
		CachePayloadExtractCompleteEventArgs e = new CachePayloadExtractCompleteEventArgs(wzContainerId, wzPayloadId, hrStatus);
		OnCachePayloadExtractComplete(e);
		return e.HResult;
	}

	int IBootstrapperApplication.OnPlanRestoreRelatedBundle(string wzBundleId, RequestState recommendedState, ref RequestState pRequestedState, ref bool fCancel)
	{
		PlanRestoreRelatedBundleEventArgs e = new PlanRestoreRelatedBundleEventArgs(wzBundleId, recommendedState, pRequestedState, fCancel);
		OnPlanRestoreRelatedBundle(e);
		pRequestedState = e.State;
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnExecuteProcessCancel(string wzPackageId, int processId, BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION recommendation, ref BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION pAction)
	{
		ExecuteProcessCancelEventArgs e = new ExecuteProcessCancelEventArgs(wzPackageId, processId, recommendation, pAction);
		OnExecuteProcessCancel(e);
		pAction = e.Action;
		return e.HResult;
	}

	int IBootstrapperApplication.OnDetectRelatedBundlePackage(string wzPackageId, string wzProductCode, RelationType relationType, bool fPerMachine, string wzVersion, ref bool fCancel)
	{
		DetectRelatedBundlePackageEventArgs e = new DetectRelatedBundlePackageEventArgs(wzPackageId, wzProductCode, relationType, fPerMachine, wzVersion, fCancel);
		OnDetectRelatedBundlePackage(e);
		fCancel = e.Cancel;
		return e.HResult;
	}

	int IBootstrapperApplication.OnCachePackageNonVitalValidationFailure(string wzPackageId, int hrStatus, BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION recommendation, ref BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION action)
	{
		CachePackageNonVitalValidationFailureEventArgs e = new CachePackageNonVitalValidationFailureEventArgs(wzPackageId, hrStatus, recommendation, action);
		OnCachePackageNonVitalValidationFailure(e);
		action = e.Action;
		return e.HResult;
	}
}
public class BootstrapperApplicationData : IBootstrapperApplicationData
{
	public const string DefaultFileName = "BootstrapperApplicationData.xml";

	public const string XMLNamespace = "http://wixtoolset.org/schemas/v4/BootstrapperApplicationData";

	public static readonly DirectoryInfo DefaultFolder;

	public static readonly FileInfo DefaultFile;

	public FileInfo BADataFile { get; private set; }

	public IBundleInfo Bundle { get; private set; }

	static BootstrapperApplicationData()
	{
		DefaultFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
		DefaultFile = new FileInfo(Path.Combine(DefaultFolder.FullName, "BootstrapperApplicationData.xml"));
	}

	public BootstrapperApplicationData()
		: this(DefaultFile)
	{
	}

	public BootstrapperApplicationData(FileInfo baDataFile)
	{
		BADataFile = baDataFile;
		using FileStream stream = BADataFile.OpenRead();
		Bundle = BundleInfo.ParseBundleFromStream(stream);
	}

	public static string GetAttribute(XPathNavigator node, string attributeName)
	{
		return node.SelectSingleNode("@" + attributeName)?.Value;
	}

	public static bool? GetYesNoAttribute(XPathNavigator node, string attributeName)
	{
		return GetAttribute(node, attributeName)?.Equals("yes", StringComparison.InvariantCulture);
	}
}
[Obsolete("Bootstrapper applications now run out of proc and do not use a BootstrapperApplicationFactory. Remove your BootstrapperApplicationFactory class. See https://wixtoolset.org/docs/fiveforfour/ for more details.")]
[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
public sealed class BootstrapperApplicationFactoryAttribute : Attribute
{
	public Type BootstrapperApplicationFactoryType
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public BootstrapperApplicationFactoryAttribute(Type bootstrapperApplicationFactoryType)
	{
		throw new NotImplementedException();
	}
}
[Serializable]
[GeneratedCode("WixToolset.Bootstrapper.InteropCodeGenerator", "1.0.0.0")]
public struct Command
{
	[MarshalAs(UnmanagedType.I4)]
	internal int cbSize;

	[MarshalAs(UnmanagedType.U4)]
	private readonly LaunchAction action;

	[MarshalAs(UnmanagedType.U4)]
	private readonly Display display;

	private readonly IntPtr wzCommandLine;

	[MarshalAs(UnmanagedType.I4)]
	private readonly int nCmdShow;

	[MarshalAs(UnmanagedType.U4)]
	private readonly ResumeType resume;

	private readonly IntPtr hwndSplashScreen;

	[MarshalAs(UnmanagedType.I4)]
	private readonly RelationType relation;

	[MarshalAs(UnmanagedType.Bool)]
	private readonly bool passthrough;

	private readonly IntPtr wzLayoutDirectory;

	private readonly IntPtr wzBootstrapperWorkingFolder;

	private readonly IntPtr wzBootstrapperApplicationDataPath;

	public IBootstrapperCommand GetBootstrapperCommand()
	{
		return new BootstrapperCommand(action, display, Marshal.PtrToStringUni(wzCommandLine), nCmdShow, resume, hwndSplashScreen, relation, passthrough, Marshal.PtrToStringUni(wzLayoutDirectory), Marshal.PtrToStringUni(wzBootstrapperWorkingFolder), Marshal.PtrToStringUni(wzBootstrapperApplicationDataPath));
	}
}
public sealed class BootstrapperCommand : IBootstrapperCommand
{
	public LaunchAction Action { get; }

	public Display Display { get; }

	public string CommandLine { get; }

	public int CmdShow { get; }

	public ResumeType Resume { get; }

	public IntPtr SplashScreen { get; }

	public RelationType Relation { get; }

	public bool Passthrough { get; }

	public string LayoutDirectory { get; }

	public string BootstrapperWorkingFolder { get; }

	public string BootstrapperApplicationDataPath { get; }

	public BootstrapperCommand(LaunchAction action, Display display, string commandLine, int cmdShow, ResumeType resume, IntPtr splashScreen, RelationType relation, bool passthrough, string layoutDirectory, string bootstrapperWorkingFolder, string bootstrapperApplicationDataPath)
	{
		Action = action;
		Display = display;
		CommandLine = commandLine;
		CmdShow = cmdShow;
		Resume = resume;
		SplashScreen = splashScreen;
		Relation = relation;
		Passthrough = passthrough;
		LayoutDirectory = layoutDirectory;
		BootstrapperWorkingFolder = bootstrapperWorkingFolder;
		BootstrapperApplicationDataPath = bootstrapperApplicationDataPath;
	}

	public IMbaCommand ParseCommandLine()
	{
		string[] array = ParseCommandLineToArgs(CommandLine);
		List<string> list = new List<string>();
		List<KeyValuePair<string, string>> list2 = new List<KeyValuePair<string, string>>();
		Restart restart = Restart.Unknown;
		string[] array2 = array;
		foreach (string text in array2)
		{
			bool flag = false;
			if (text[0] == '-' || text[0] == '/')
			{
				string text2 = text.Substring(1).ToLowerInvariant();
				if (!(text2 == "norestart"))
				{
					if (text2 == "forcerestart")
					{
						if (restart == Restart.Unknown)
						{
							restart = Restart.Always;
						}
					}
					else
					{
						flag = true;
					}
				}
				else if (restart == Restart.Unknown)
				{
					restart = Restart.Never;
				}
			}
			else
			{
				int num = text.IndexOf('=');
				if (num == -1)
				{
					flag = true;
				}
				else
				{
					string key = text.Substring(0, num);
					string value = text.Substring(checked(num + 1));
					list2.Add(new KeyValuePair<string, string>(key, value));
				}
			}
			if (flag)
			{
				list.Add(text);
			}
		}
		if (restart == Restart.Unknown)
		{
			restart = ((Display < Display.Full) ? Restart.Automatic : Restart.Prompt);
		}
		return new MbaCommand
		{
			Restart = restart,
			UnknownCommandLineArgs = list.ToArray(),
			Variables = list2.ToArray()
		};
	}

	public static string[] ParseCommandLineToArgs(string commandLine)
	{
		if (commandLine == null)
		{
			return new string[0];
		}
		int pNumArgs = 0;
		IntPtr intPtr = NativeMethods.CommandLineToArgvW("ignored " + commandLine, out pNumArgs);
		if (IntPtr.Zero == intPtr)
		{
			throw new Win32Exception();
		}
		checked
		{
			try
			{
				string[] array = new string[pNumArgs - 1];
				for (int i = 1; i < pNumArgs; i++)
				{
					IntPtr ptr = Marshal.ReadIntPtr(intPtr, i * IntPtr.Size);
					array[i - 1] = Marshal.PtrToStringUni(ptr);
				}
				return array;
			}
			finally
			{
				NativeMethods.LocalFree(intPtr);
			}
		}
	}
}
public class BundleInfo : IBundleInfo
{
	public bool PerMachine { get; internal set; }

	public string Name { get; internal set; }

	public string LogVariable { get; internal set; }

	public IOverridableVariables OverridableVariables { get; internal set; }

	public IDictionary<string, IPackageInfo> Packages { get; internal set; }

	internal BundleInfo()
	{
		Packages = new Dictionary<string, IPackageInfo>();
	}

	public IPackageInfo AddRelatedBundleAsPackage(string productCode, RelationType relationType, bool perMachine, string version)
	{
		IPackageInfo relatedBundleAsPackage = PackageInfo.GetRelatedBundleAsPackage(productCode, relationType, perMachine, version);
		Packages.Add(relatedBundleAsPackage.Id, relatedBundleAsPackage);
		return relatedBundleAsPackage;
	}

	public IPackageInfo AddUpdateBundleAsPackage(string packageId)
	{
		IPackageInfo updateBundleAsPackage = PackageInfo.GetUpdateBundleAsPackage(packageId);
		Packages.Add(updateBundleAsPackage.Id, updateBundleAsPackage);
		return updateBundleAsPackage;
	}

	public static IBundleInfo ParseBundleFromStream(Stream stream)
	{
		return ParseBundleFromXml(new XPathDocument(stream).CreateNavigator());
	}

	public static IBundleInfo ParseBundleFromXml(XPathNavigator root)
	{
		BundleInfo bundleInfo = new BundleInfo();
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(root.NameTable);
		xmlNamespaceManager.AddNamespace("p", "http://wixtoolset.org/schemas/v4/BootstrapperApplicationData");
		XPathNavigator xPathNavigator = root.SelectSingleNode("/p:BootstrapperApplicationData/p:WixBundleProperties", xmlNamespaceManager);
		if (xPathNavigator == null)
		{
			throw new Exception("Failed to select bundle information.");
		}
		bool? yesNoAttribute = BootstrapperApplicationData.GetYesNoAttribute(xPathNavigator, "PerMachine");
		if (yesNoAttribute.HasValue)
		{
			bundleInfo.PerMachine = yesNoAttribute.Value;
		}
		bundleInfo.Name = BootstrapperApplicationData.GetAttribute(xPathNavigator, "DisplayName");
		bundleInfo.LogVariable = BootstrapperApplicationData.GetAttribute(xPathNavigator, "LogPathVariable");
		bundleInfo.OverridableVariables = OverridableVariablesInfo.ParseFromXml(root);
		bundleInfo.Packages = PackageInfo.ParsePackagesFromXml(root);
		return bundleInfo;
	}
}
public sealed class Engine : IEngine
{
	private IBootstrapperEngine engine;

	public int PackageCount
	{
		get
		{
			engine.GetPackageCount(out var pcPackages);
			return pcPackages;
		}
	}

	internal Engine(IBootstrapperEngine engine)
	{
		this.engine = engine;
	}

	public void Apply(IntPtr hwndParent)
	{
		engine.Apply(hwndParent);
	}

	public void CloseSplashScreen()
	{
		engine.CloseSplashScreen();
	}

	public int CompareVersions(string version1, string version2)
	{
		engine.CompareVersions(version1, version2, out var pnResult);
		return pnResult;
	}

	public bool ContainsVariable(string name)
	{
		return BalUtil.BalVariableExistsFromEngine(engine, name);
	}

	public void Detect()
	{
		Detect(IntPtr.Zero);
	}

	public void Detect(IntPtr hwndParent)
	{
		engine.Detect(hwndParent);
	}

	public bool Elevate(IntPtr hwndParent)
	{
		int num = engine.Elevate(hwndParent);
		if (num == 0 || -2147023649 == num)
		{
			return true;
		}
		if (-2147023673 == num)
		{
			return false;
		}
		throw new Win32Exception(num);
	}

	public string EscapeString(string input)
	{
		StrUtil.StrHandle psczOut = new StrUtil.StrHandle();
		try
		{
			int num = BalUtil.BalEscapeStringFromEngine(engine, input, ref psczOut);
			if (num != 0)
			{
				throw new Win32Exception(num);
			}
			return psczOut.ToUniString();
		}
		finally
		{
			psczOut.Dispose();
		}
	}

	public bool EvaluateCondition(string condition)
	{
		engine.EvaluateCondition(condition, out var pf);
		return pf;
	}

	public string FormatString(string format)
	{
		StrUtil.StrHandle psczOut = new StrUtil.StrHandle();
		try
		{
			int num = BalUtil.BalFormatStringFromEngine(engine, format, ref psczOut);
			if (num != 0)
			{
				throw new Win32Exception(num);
			}
			return psczOut.ToUniString();
		}
		finally
		{
			psczOut.Dispose();
		}
	}

	public long GetVariableNumeric(string name)
	{
		int variableNumeric = engine.GetVariableNumeric(name, out var pllValue);
		if (variableNumeric != 0)
		{
			throw new Win32Exception(variableNumeric);
		}
		return pllValue;
	}

	public SecureString GetVariableSecureString(string name)
	{
		StrUtil.StrHandle psczOut = new StrUtil.StrHandle();
		try
		{
			int num = BalUtil.BalGetStringVariableFromEngine(engine, name, ref psczOut);
			if (num != 0)
			{
				throw new Win32Exception(num);
			}
			return psczOut.ToSecureString();
		}
		finally
		{
			psczOut.Dispose();
		}
	}

	public string GetVariableString(string name)
	{
		StrUtil.StrHandle psczOut = new StrUtil.StrHandle();
		try
		{
			int num = BalUtil.BalGetStringVariableFromEngine(engine, name, ref psczOut);
			if (num != 0)
			{
				throw new Win32Exception(num);
			}
			return psczOut.ToUniString();
		}
		finally
		{
			psczOut.Dispose();
		}
	}

	public string GetVariableVersion(string name)
	{
		StrUtil.StrHandle psczOut = new StrUtil.StrHandle();
		try
		{
			int num = BalUtil.BalGetVersionVariableFromEngine(engine, name, ref psczOut);
			if (num != 0)
			{
				throw new Win32Exception(num);
			}
			return psczOut.ToUniString();
		}
		finally
		{
			psczOut.Dispose();
		}
	}

	public string GetRelatedBundleVariable(string bundleId, string name)
	{
		StrUtil.StrHandle psczOut = new StrUtil.StrHandle();
		try
		{
			int num = BalUtil.BalGetRelatedBundleVariableFromEngine(engine, bundleId, name, ref psczOut);
			if (num != 0)
			{
				throw new Win32Exception(num);
			}
			return psczOut.ToUniString();
		}
		finally
		{
			psczOut.Dispose();
		}
	}

	public void LaunchApprovedExe(IntPtr hwndParent, string approvedExeForElevationId, string arguments)
	{
		LaunchApprovedExe(hwndParent, approvedExeForElevationId, arguments, 0);
	}

	public void LaunchApprovedExe(IntPtr hwndParent, string approvedExeForElevationId, string arguments, int waitForInputIdleTimeout)
	{
		engine.LaunchApprovedExe(hwndParent, approvedExeForElevationId, arguments, waitForInputIdleTimeout);
	}

	public void Log(LogLevel level, string message)
	{
		engine.Log(level, message);
	}

	public void Plan(LaunchAction action)
	{
		engine.Plan(action);
	}

	public void SetUpdate(string localSource, string downloadSource, long size, UpdateHashType hashType, string hash, string updatePackageId)
	{
		engine.SetUpdate(localSource, downloadSource, size, hashType, hash, updatePackageId);
	}

	public void SetUpdateSource(string url)
	{
		engine.SetUpdateSource(url);
	}

	public void SetLocalSource(string packageOrContainerId, string payloadId, string path)
	{
		engine.SetLocalSource(packageOrContainerId, payloadId, path);
	}

	public void SetDownloadSource(string packageOrContainerId, string payloadId, string url, string user, string password)
	{
		engine.SetDownloadSource(packageOrContainerId, payloadId, url, user, password);
	}

	public void SetVariableNumeric(string name, long value)
	{
		engine.SetVariableNumeric(name, value);
	}

	public void SetVariableString(string name, SecureString value, bool formatted)
	{
		IntPtr intPtr = Marshal.SecureStringToCoTaskMemUnicode(value);
		try
		{
			engine.SetVariableString(name, intPtr, formatted);
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void SetVariableString(string name, string value, bool formatted)
	{
		IntPtr intPtr = Marshal.StringToCoTaskMemUni(value);
		try
		{
			engine.SetVariableString(name, intPtr, formatted);
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public void SetVariableVersion(string name, string value)
	{
		IntPtr intPtr = Marshal.StringToCoTaskMemUni(value);
		try
		{
			engine.SetVariableVersion(name, intPtr);
		}
		finally
		{
			Marshal.FreeCoTaskMem(intPtr);
		}
	}

	public int SendEmbeddedError(int errorCode, string message, int uiHint)
	{
		int pnResult = 0;
		engine.SendEmbeddedError(errorCode, message, uiHint, out pnResult);
		return pnResult;
	}

	public int SendEmbeddedProgress(int progressPercentage, int overallPercentage)
	{
		int pnResult = 0;
		engine.SendEmbeddedProgress(progressPercentage, overallPercentage, out pnResult);
		return pnResult;
	}

	public void Quit(int exitCode)
	{
		engine.Quit(exitCode);
	}
}
[Serializable]
public abstract class HResultEventArgs : EventArgs
{
	public int HResult { get; set; }

	public HResultEventArgs()
	{
	}
}
[Serializable]
public abstract class CancellableHResultEventArgs : HResultEventArgs
{
	public bool Cancel { get; set; }

	public CancellableHResultEventArgs(bool cancelRecommendation)
	{
		Cancel = cancelRecommendation;
	}
}
[Serializable]
public abstract class ResultEventArgs : HResultEventArgs
{
	public Result Recommendation { get; private set; }

	public Result Result { get; set; }

	public ResultEventArgs(Result recommendation, Result result)
	{
		Recommendation = recommendation;
		Result = result;
	}
}
[Serializable]
public abstract class StatusEventArgs : HResultEventArgs
{
	public int Status { get; private set; }

	public StatusEventArgs(int hrStatus)
	{
		Status = hrStatus;
	}
}
public abstract class ActionEventArgs<T> : StatusEventArgs
{
	public T Recommendation { get; private set; }

	public T Action { get; set; }

	public ActionEventArgs(int hrStatus, T recommendation, T action)
		: base(hrStatus)
	{
		Recommendation = recommendation;
		Action = action;
	}
}
[Serializable]
public abstract class CancellableActionEventArgs<T> : CancellableHResultEventArgs
{
	public T Recommendation { get; private set; }

	public T Action { get; set; }

	public CancellableActionEventArgs(bool cancelRecommendation, T recommendation, T action)
		: base(cancelRecommendation)
	{
		Recommendation = recommendation;
		Action = action;
	}
}
[Serializable]
public abstract class CacheProgressBaseEventArgs : CancellableHResultEventArgs
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public long Progress { get; private set; }

	public long Total { get; private set; }

	public int OverallPercentage { get; private set; }

	public CacheProgressBaseEventArgs(string packageOrContainerId, string payloadId, long progress, long total, int overallPercentage, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
		Progress = progress;
		Total = total;
		OverallPercentage = overallPercentage;
	}
}
[Serializable]
public class CreateEventArgs : HResultEventArgs
{
	public IEngine Engine { get; }

	public IBootstrapperCommand Command { get; }

	public CreateEventArgs(IEngine engine, IBootstrapperCommand command)
	{
		Engine = engine;
		Command = command;
	}
}
[Serializable]
public class DestroyEventArgs : HResultEventArgs
{
	public bool Reload { get; }

	public DestroyEventArgs(bool reload)
	{
		Reload = reload;
	}
}
[Serializable]
public class StartupEventArgs : HResultEventArgs
{
}
[Serializable]
public class ShutdownEventArgs : HResultEventArgs
{
	public BOOTSTRAPPER_SHUTDOWN_ACTION Action { get; set; }

	public ShutdownEventArgs(BOOTSTRAPPER_SHUTDOWN_ACTION action)
	{
		Action = action;
	}
}
[Serializable]
public class DetectBeginEventArgs : CancellableHResultEventArgs
{
	public bool Cached { get; private set; }

	public RegistrationType RegistrationType { get; private set; }

	public int PackageCount { get; private set; }

	public DetectBeginEventArgs(bool cached, RegistrationType registrationType, int packageCount, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		Cached = cached;
		RegistrationType = registrationType;
		PackageCount = packageCount;
	}
}
[Serializable]
public class DetectForwardCompatibleBundleEventArgs : CancellableHResultEventArgs
{
	public string BundleId { get; private set; }

	public RelationType RelationType { get; private set; }

	public string BundleTag { get; private set; }

	public bool PerMachine { get; private set; }

	public string Version { get; private set; }

	public bool MissingFromCache { get; set; }

	public DetectForwardCompatibleBundleEventArgs(string bundleId, RelationType relationType, string bundleTag, bool perMachine, string version, bool missingFromCache, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		BundleId = bundleId;
		RelationType = relationType;
		BundleTag = bundleTag;
		PerMachine = perMachine;
		Version = version;
		MissingFromCache = missingFromCache;
	}
}
[Serializable]
public class DetectUpdateBeginEventArgs : CancellableHResultEventArgs
{
	public string UpdateLocation { get; private set; }

	public bool Skip { get; set; }

	public DetectUpdateBeginEventArgs(string updateLocation, bool cancelRecommendation, bool skipRecommendation)
		: base(cancelRecommendation)
	{
		UpdateLocation = updateLocation;
		Skip = skipRecommendation;
	}
}
[Serializable]
public class DetectUpdateEventArgs : CancellableHResultEventArgs
{
	public string UpdateLocation { get; private set; }

	public long Size { get; private set; }

	public string Hash { get; }

	public UpdateHashType HashAlgorithm { get; }

	public string Version { get; private set; }

	public string Title { get; private set; }

	public string Summary { get; private set; }

	public string ContentType { get; private set; }

	public string Content { get; private set; }

	public bool StopProcessingUpdates { get; set; }

	public DetectUpdateEventArgs(string updateLocation, long size, string hash, UpdateHashType hashAlgorithm, string version, string title, string summary, string contentType, string content, bool cancelRecommendation, bool stopRecommendation)
		: base(cancelRecommendation)
	{
		UpdateLocation = updateLocation;
		Size = size;
		Hash = hash;
		HashAlgorithm = hashAlgorithm;
		Version = version;
		Title = title;
		Summary = summary;
		ContentType = contentType;
		Content = content;
		StopProcessingUpdates = stopRecommendation;
	}
}
[Serializable]
public class DetectUpdateCompleteEventArgs : StatusEventArgs
{
	public bool IgnoreError { get; set; }

	public DetectUpdateCompleteEventArgs(int hrStatus, bool ignoreRecommendation)
		: base(hrStatus)
	{
		IgnoreError = ignoreRecommendation;
	}
}
[Serializable]
public class DetectRelatedBundleEventArgs : CancellableHResultEventArgs
{
	public string ProductCode { get; private set; }

	public RelationType RelationType { get; private set; }

	public string BundleTag { get; private set; }

	public bool PerMachine { get; private set; }

	public string Version { get; private set; }

	public bool MissingFromCache { get; set; }

	public DetectRelatedBundleEventArgs(string productCode, RelationType relationType, string bundleTag, bool perMachine, string version, bool missingFromCache, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		ProductCode = productCode;
		RelationType = relationType;
		BundleTag = bundleTag;
		PerMachine = perMachine;
		Version = version;
		MissingFromCache = missingFromCache;
	}
}
[Serializable]
public class DetectPackageBeginEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public DetectPackageBeginEventArgs(string packageId, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
	}
}
[Serializable]
public class DetectCompatibleMsiPackageEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string CompatiblePackageId { get; private set; }

	public string CompatiblePackageVersion { get; private set; }

	public DetectCompatibleMsiPackageEventArgs(string packageId, string compatiblePackageId, string compatiblePackageVersion, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		CompatiblePackageId = compatiblePackageId;
		CompatiblePackageVersion = compatiblePackageVersion;
	}
}
[Serializable]
public class DetectRelatedMsiPackageEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string UpgradeCode { get; private set; }

	public string ProductCode { get; private set; }

	public bool PerMachine { get; private set; }

	public string Version { get; private set; }

	public RelatedOperation Operation { get; private set; }

	public DetectRelatedMsiPackageEventArgs(string packageId, string upgradeCode, string productCode, bool perMachine, string version, RelatedOperation operation, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		UpgradeCode = upgradeCode;
		ProductCode = productCode;
		PerMachine = perMachine;
		Version = version;
		Operation = operation;
	}
}
public class DetectPatchTargetEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string ProductCode { get; private set; }

	public PackageState State { get; private set; }

	public DetectPatchTargetEventArgs(string packageId, string productCode, PackageState state, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		ProductCode = productCode;
		State = state;
	}
}
public class DetectMsiFeatureEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string FeatureId { get; private set; }

	public FeatureState State { get; private set; }

	public DetectMsiFeatureEventArgs(string packageId, string featureId, FeatureState state, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		FeatureId = featureId;
		State = state;
	}
}
[Serializable]
public class DetectPackageCompleteEventArgs : StatusEventArgs
{
	public string PackageId { get; private set; }

	public PackageState State { get; private set; }

	public bool Cached { get; private set; }

	public DetectPackageCompleteEventArgs(string packageId, int hrStatus, PackageState state, bool cached)
		: base(hrStatus)
	{
		PackageId = packageId;
		State = state;
		Cached = cached;
	}
}
[Serializable]
public class DetectCompleteEventArgs : StatusEventArgs
{
	public bool EligibleForCleanup { get; private set; }

	public DetectCompleteEventArgs(int hrStatus, bool eligibleForCleanup)
		: base(hrStatus)
	{
		EligibleForCleanup = eligibleForCleanup;
	}
}
[Serializable]
public class PlanBeginEventArgs : CancellableHResultEventArgs
{
	public int PackageCount { get; private set; }

	public PlanBeginEventArgs(int packageCount, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageCount = packageCount;
	}
}
[Serializable]
public class PlanRelatedBundleEventArgs : CancellableHResultEventArgs
{
	public string BundleId { get; private set; }

	public RequestState RecommendedState { get; private set; }

	public RequestState State { get; set; }

	public PlanRelatedBundleEventArgs(string bundleId, RequestState recommendedState, RequestState state, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		BundleId = bundleId;
		RecommendedState = recommendedState;
		State = state;
	}
}
[Serializable]
public class PlanRelatedBundleTypeEventArgs : CancellableHResultEventArgs
{
	public string BundleId { get; private set; }

	public RelatedBundlePlanType RecommendedType { get; private set; }

	public RelatedBundlePlanType Type { get; set; }

	public PlanRelatedBundleTypeEventArgs(string bundleId, RelatedBundlePlanType recommendedType, RelatedBundlePlanType type, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		BundleId = bundleId;
		RecommendedType = recommendedType;
		Type = type;
	}
}
[Serializable]
public class PlanPackageBeginEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public PackageState CurrentState { get; private set; }

	public bool Cached { get; private set; }

	public BOOTSTRAPPER_PACKAGE_CONDITION_RESULT InstallCondition { get; private set; }

	public BOOTSTRAPPER_PACKAGE_CONDITION_RESULT RepairCondition { get; private set; }

	public RequestState RecommendedState { get; private set; }

	public BOOTSTRAPPER_CACHE_TYPE RecommendedCacheType { get; private set; }

	public RequestState State { get; set; }

	public BOOTSTRAPPER_CACHE_TYPE CacheType { get; set; }

	public PlanPackageBeginEventArgs(string packageId, PackageState currentState, bool cached, BOOTSTRAPPER_PACKAGE_CONDITION_RESULT installCondition, BOOTSTRAPPER_PACKAGE_CONDITION_RESULT repairCondition, RequestState recommendedState, BOOTSTRAPPER_CACHE_TYPE recommendedCacheType, RequestState state, BOOTSTRAPPER_CACHE_TYPE cacheType, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		CurrentState = currentState;
		Cached = cached;
		InstallCondition = installCondition;
		RepairCondition = repairCondition;
		RecommendedState = recommendedState;
		RecommendedCacheType = recommendedCacheType;
		State = state;
		CacheType = cacheType;
	}
}
[Serializable]
public class PlanCompatibleMsiPackageBeginEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string CompatiblePackageId { get; private set; }

	public string CompatiblePackageVersion { get; private set; }

	public bool RecommendedRemove { get; private set; }

	public bool RequestRemove { get; set; }

	public PlanCompatibleMsiPackageBeginEventArgs(string packageId, string compatiblePackageId, string compatiblePackageVersion, bool recommendedRemove, bool requestRemove, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		CompatiblePackageId = compatiblePackageId;
		CompatiblePackageVersion = compatiblePackageVersion;
		RecommendedRemove = recommendedRemove;
		RequestRemove = requestRemove;
	}
}
[Serializable]
public class PlanCompatibleMsiPackageCompleteEventArgs : StatusEventArgs
{
	public string PackageId { get; private set; }

	public string CompatiblePackageId { get; private set; }

	public bool RequestedRemove { get; private set; }

	public PlanCompatibleMsiPackageCompleteEventArgs(string packageId, string compatiblePackageId, int hrStatus, bool requestedRemove)
		: base(hrStatus)
	{
		PackageId = packageId;
		CompatiblePackageId = compatiblePackageId;
		RequestedRemove = requestedRemove;
	}
}
[Serializable]
public class PlanRollbackBoundaryEventArgs : CancellableHResultEventArgs
{
	public string RollbackBoundaryId { get; private set; }

	public bool RecommendedTransaction { get; private set; }

	public bool Transaction { get; set; }

	public PlanRollbackBoundaryEventArgs(string rollbackBoundaryId, bool recommendedTransaction, bool transaction, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		RollbackBoundaryId = rollbackBoundaryId;
		RecommendedTransaction = recommendedTransaction;
		Transaction = transaction;
	}
}
[Serializable]
public class PlanPatchTargetEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string ProductCode { get; private set; }

	public RequestState RecommendedState { get; private set; }

	public RequestState State { get; set; }

	public PlanPatchTargetEventArgs(string packageId, string productCode, RequestState recommendedState, RequestState state, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		ProductCode = productCode;
		RecommendedState = recommendedState;
		State = state;
	}
}
[Serializable]
public class PlanMsiFeatureEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string FeatureId { get; private set; }

	public FeatureState RecommendedState { get; private set; }

	public FeatureState State { get; set; }

	public PlanMsiFeatureEventArgs(string packageId, string featureId, FeatureState recommendedState, FeatureState state, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		FeatureId = featureId;
		RecommendedState = recommendedState;
		State = state;
	}
}
[Serializable]
public class PlanMsiPackageEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public bool ShouldExecute { get; private set; }

	public ActionState Action { get; private set; }

	public BOOTSTRAPPER_MSI_FILE_VERSIONING RecommendedFileVersioning { get; private set; }

	public BURN_MSI_PROPERTY ActionMsiProperty { get; set; }

	public INSTALLUILEVEL UiLevel { get; set; }

	public bool DisableExternalUiHandler { get; set; }

	public BOOTSTRAPPER_MSI_FILE_VERSIONING FileVersioning { get; set; }

	public PlanMsiPackageEventArgs(string packageId, bool shouldExecute, ActionState action, BOOTSTRAPPER_MSI_FILE_VERSIONING recommendedFileVersioning, bool cancelRecommendation, BURN_MSI_PROPERTY actionMsiProperty, INSTALLUILEVEL uiLevel, bool disableExternalUiHandler, BOOTSTRAPPER_MSI_FILE_VERSIONING fileVersioning)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		ShouldExecute = shouldExecute;
		Action = action;
		RecommendedFileVersioning = recommendedFileVersioning;
		ActionMsiProperty = actionMsiProperty;
		UiLevel = uiLevel;
		DisableExternalUiHandler = disableExternalUiHandler;
		FileVersioning = fileVersioning;
	}
}
[Serializable]
public class PlanPackageCompleteEventArgs : StatusEventArgs
{
	public string PackageId { get; private set; }

	public RequestState Requested { get; private set; }

	public PlanPackageCompleteEventArgs(string packageId, int hrStatus, RequestState requested)
		: base(hrStatus)
	{
		PackageId = packageId;
		Requested = requested;
	}
}
[Serializable]
public class PlannedCompatiblePackageEventArgs : HResultEventArgs
{
	public string PackageId { get; private set; }

	public string CompatiblePackageId { get; private set; }

	public bool Remove { get; private set; }

	public PlannedCompatiblePackageEventArgs(string packageId, string compatiblePackageId, bool remove)
	{
		PackageId = packageId;
		CompatiblePackageId = compatiblePackageId;
		Remove = remove;
	}
}
[Serializable]
public class PlannedPackageEventArgs : HResultEventArgs
{
	public string PackageId { get; private set; }

	public ActionState Execute { get; private set; }

	public ActionState Rollback { get; private set; }

	public bool Cache { get; private set; }

	public bool Uncache { get; private set; }

	public PlannedPackageEventArgs(string packageId, ActionState execute, ActionState rollback, bool cache, bool uncache)
	{
		PackageId = packageId;
		Execute = execute;
		Rollback = rollback;
		Cache = cache;
		Uncache = uncache;
	}
}
[Serializable]
public class PlanCompleteEventArgs : StatusEventArgs
{
	public PlanCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class PlanForwardCompatibleBundleEventArgs : CancellableHResultEventArgs
{
	public string BundleId { get; private set; }

	public RelationType RelationType { get; private set; }

	public string BundleTag { get; private set; }

	public bool PerMachine { get; private set; }

	public string Version { get; private set; }

	public bool RecommendedIgnoreBundle { get; set; }

	public bool IgnoreBundle { get; set; }

	public PlanForwardCompatibleBundleEventArgs(string bundleId, RelationType relationType, string bundleTag, bool perMachine, string version, bool recommendedIgnoreBundle, bool cancelRecommendation, bool ignoreBundle)
		: base(cancelRecommendation)
	{
		BundleId = bundleId;
		RelationType = relationType;
		BundleTag = bundleTag;
		PerMachine = perMachine;
		Version = version;
		RecommendedIgnoreBundle = recommendedIgnoreBundle;
		IgnoreBundle = ignoreBundle;
	}
}
[Serializable]
public class ApplyBeginEventArgs : CancellableHResultEventArgs
{
	public int PhaseCount { get; private set; }

	public ApplyBeginEventArgs(int phaseCount, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PhaseCount = phaseCount;
	}
}
[Serializable]
public class ElevateBeginEventArgs : CancellableHResultEventArgs
{
	public ElevateBeginEventArgs(bool cancelRecommendation)
		: base(cancelRecommendation)
	{
	}
}
[Serializable]
public class ElevateCompleteEventArgs : StatusEventArgs
{
	public ElevateCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class ProgressEventArgs : CancellableHResultEventArgs
{
	public int ProgressPercentage { get; private set; }

	public int OverallPercentage { get; private set; }

	public ProgressEventArgs(int progressPercentage, int overallPercentage, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		ProgressPercentage = progressPercentage;
		OverallPercentage = overallPercentage;
	}
}
[Serializable]
public class ErrorEventArgs : ResultEventArgs
{
	public ErrorType ErrorType { get; private set; }

	public string PackageId { get; private set; }

	public int ErrorCode { get; private set; }

	public string ErrorMessage { get; private set; }

	public int UIHint { get; private set; }

	public IList<string> Data { get; private set; }

	public ErrorEventArgs(ErrorType errorType, string packageId, int errorCode, string errorMessage, int dwUIHint, string[] data, Result recommendation, Result result)
		: base(recommendation, result)
	{
		ErrorType = errorType;
		PackageId = packageId;
		ErrorCode = errorCode;
		ErrorMessage = errorMessage;
		UIHint = dwUIHint;
		Data = new ReadOnlyCollection<string>(data ?? new string[0]);
	}
}
[Serializable]
public class RegisterBeginEventArgs : CancellableHResultEventArgs
{
	public RegistrationType RecommendedRegistrationType { get; private set; }

	public RegistrationType RegistrationType { get; set; }

	public RegisterBeginEventArgs(RegistrationType recommendedRegistrationType, bool cancelRecommendation, RegistrationType registrationType)
		: base(cancelRecommendation)
	{
		RecommendedRegistrationType = recommendedRegistrationType;
		RegistrationType = registrationType;
	}
}
[Serializable]
public class RegisterCompleteEventArgs : StatusEventArgs
{
	public RegisterCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class UnregisterBeginEventArgs : HResultEventArgs
{
	public RegistrationType RecommendedRegistrationType { get; private set; }

	public RegistrationType RegistrationType { get; set; }

	public UnregisterBeginEventArgs(RegistrationType recommendedRegistrationType, RegistrationType registrationType)
	{
		RecommendedRegistrationType = recommendedRegistrationType;
		RegistrationType = registrationType;
	}
}
[Serializable]
public class UnregisterCompleteEventArgs : StatusEventArgs
{
	public UnregisterCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class CacheBeginEventArgs : CancellableHResultEventArgs
{
	public CacheBeginEventArgs(bool cancelRecommendation)
		: base(cancelRecommendation)
	{
	}
}
[Serializable]
public class CacheAcquireBeginEventArgs : CancellableActionEventArgs<CacheOperation>
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public string Source { get; private set; }

	public string DownloadUrl { get; private set; }

	public string PayloadContainerId { get; private set; }

	public CacheAcquireBeginEventArgs(string packageOrContainerId, string payloadId, string source, string downloadUrl, string payloadContainerId, CacheOperation recommendation, CacheOperation action, bool cancelRecommendation)
		: base(cancelRecommendation, recommendation, action)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
		Source = source;
		DownloadUrl = downloadUrl;
		PayloadContainerId = payloadContainerId;
	}
}
[Serializable]
public class CacheAcquireProgressEventArgs : CacheProgressBaseEventArgs
{
	public CacheAcquireProgressEventArgs(string packageOrContainerId, string payloadId, long progress, long total, int overallPercentage, bool cancelRecommendation)
		: base(packageOrContainerId, payloadId, progress, total, overallPercentage, cancelRecommendation)
	{
	}
}
[Serializable]
public class CacheAcquireCompleteEventArgs : ActionEventArgs<BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION>
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public CacheAcquireCompleteEventArgs(string packageOrContainerId, string payloadId, int hrStatus, BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION recommendation, BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
	}
}
[Serializable]
public class CacheVerifyBeginEventArgs : CancellableHResultEventArgs
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public CacheVerifyBeginEventArgs(string packageOrContainerId, string payloadId, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
	}
}
[Serializable]
public class CacheVerifyProgressEventArgs : CacheProgressBaseEventArgs
{
	public CacheVerifyStep Step { get; private set; }

	public CacheVerifyProgressEventArgs(string packageOrContainerId, string payloadId, long progress, long total, int overallPercentage, CacheVerifyStep verifyStep, bool cancelRecommendation)
		: base(packageOrContainerId, payloadId, progress, total, overallPercentage, cancelRecommendation)
	{
		Step = verifyStep;
	}
}
[Serializable]
public class CacheVerifyCompleteEventArgs : ActionEventArgs<BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION>
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public CacheVerifyCompleteEventArgs(string packageOrContainerId, string payloadId, int hrStatus, BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION recommendation, BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
	}
}
[Serializable]
public class CacheCompleteEventArgs : StatusEventArgs
{
	public CacheCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class ExecuteBeginEventArgs : CancellableHResultEventArgs
{
	public int PackageCount { get; private set; }

	public ExecuteBeginEventArgs(int packageCount, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageCount = packageCount;
	}
}
[Serializable]
public class ExecutePackageBeginEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public bool ShouldExecute { get; private set; }

	public ActionState Action { get; private set; }

	public INSTALLUILEVEL UiLevel { get; private set; }

	public bool DisableExternalUiHandler { get; private set; }

	public ExecutePackageBeginEventArgs(string packageId, bool shouldExecute, ActionState action, INSTALLUILEVEL uiLevel, bool disableExternalUiHandler, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		ShouldExecute = shouldExecute;
		Action = action;
		UiLevel = uiLevel;
		DisableExternalUiHandler = disableExternalUiHandler;
	}
}
[Serializable]
public class ExecutePatchTargetEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string TargetProductCode { get; private set; }

	public ExecutePatchTargetEventArgs(string packageId, string targetProductCode, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		TargetProductCode = targetProductCode;
	}
}
[Serializable]
public class ExecuteMsiMessageEventArgs : ResultEventArgs
{
	public string PackageId { get; private set; }

	public InstallMessage MessageType { get; private set; }

	public int UIHint { get; private set; }

	public string Message { get; private set; }

	public IList<string> Data { get; private set; }

	public ExecuteMsiMessageEventArgs(string packageId, InstallMessage messageType, int dwUIHint, string message, string[] data, Result recommendation, Result result)
		: base(recommendation, result)
	{
		PackageId = packageId;
		MessageType = messageType;
		UIHint = dwUIHint;
		Message = message;
		Data = new ReadOnlyCollection<string>(data ?? new string[0]);
	}
}
[Serializable]
public class ExecuteFilesInUseEventArgs : ResultEventArgs
{
	public string PackageId { get; private set; }

	public IList<string> Files { get; private set; }

	public FilesInUseType Source { get; private set; }

	public ExecuteFilesInUseEventArgs(string packageId, string[] files, Result recommendation, FilesInUseType source, Result result)
		: base(recommendation, result)
	{
		PackageId = packageId;
		Files = new ReadOnlyCollection<string>(files ?? new string[0]);
		Source = source;
	}
}
[Serializable]
public class ExecutePackageCompleteEventArgs : ActionEventArgs<BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION>
{
	public string PackageId { get; private set; }

	public ApplyRestart Restart { get; private set; }

	public ExecutePackageCompleteEventArgs(string packageId, int hrStatus, ApplyRestart restart, BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION recommendation, BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		PackageId = packageId;
		Restart = restart;
	}
}
[Serializable]
public class ExecuteCompleteEventArgs : StatusEventArgs
{
	public ExecuteCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class ApplyCompleteEventArgs : ActionEventArgs<BOOTSTRAPPER_APPLYCOMPLETE_ACTION>
{
	public ApplyRestart Restart { get; private set; }

	public ApplyCompleteEventArgs(int hrStatus, ApplyRestart restart, BOOTSTRAPPER_APPLYCOMPLETE_ACTION recommendation, BOOTSTRAPPER_APPLYCOMPLETE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		Restart = restart;
	}
}
[Serializable]
public class ApplyDowngradeEventArgs : HResultEventArgs
{
	public int Recommendation { get; private set; }

	public int Status { get; set; }

	public ApplyDowngradeEventArgs(int hrRecommendation, int hrStatus)
	{
		Recommendation = hrRecommendation;
		Status = hrStatus;
	}
}
[Serializable]
public class CacheAcquireResolvingEventArgs : CancellableActionEventArgs<CacheResolveOperation>
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public string[] SearchPaths { get; private set; }

	public bool FoundLocal { get; private set; }

	public int RecommendedSearchPath { get; private set; }

	public string DownloadUrl { get; private set; }

	public string PayloadContainerId { get; private set; }

	public int ChosenSearchPath { get; set; }

	public CacheAcquireResolvingEventArgs(string packageOrContainerId, string payloadId, string[] searchPaths, bool foundLocal, int recommendedSearchPath, string downloadUrl, string payloadContainerId, CacheResolveOperation recommendation, int chosenSearchPath, CacheResolveOperation action, bool cancel)
		: base(cancel, recommendation, action)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
		SearchPaths = searchPaths;
		FoundLocal = foundLocal;
		RecommendedSearchPath = recommendedSearchPath;
		DownloadUrl = downloadUrl;
		PayloadContainerId = payloadContainerId;
		ChosenSearchPath = chosenSearchPath;
	}
}
[Serializable]
public class CachePackageBeginEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public long CachePayloads { get; private set; }

	public long PackageCacheSize { get; private set; }

	public bool Vital { get; private set; }

	public CachePackageBeginEventArgs(string packageId, int cachePayloads, long packageCacheSize, bool vital, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		CachePayloads = cachePayloads;
		PackageCacheSize = packageCacheSize;
		Vital = vital;
	}
}
[Serializable]
public class CachePackageCompleteEventArgs : ActionEventArgs<BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION>
{
	public string PackageId { get; private set; }

	public CachePackageCompleteEventArgs(string packageId, int hrStatus, BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION recommendation, BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		PackageId = packageId;
	}
}
[Serializable]
public class ExecuteProgressEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public int ProgressPercentage { get; private set; }

	public int OverallPercentage { get; private set; }

	public ExecuteProgressEventArgs(string packageId, int progressPercentage, int overallPercentage, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		ProgressPercentage = progressPercentage;
		OverallPercentage = overallPercentage;
	}
}
[Serializable]
public class LaunchApprovedExeBeginEventArgs : CancellableHResultEventArgs
{
	public LaunchApprovedExeBeginEventArgs(bool cancelRecommendation)
		: base(cancelRecommendation)
	{
	}
}
[Serializable]
public class LaunchApprovedExeCompleteEventArgs : StatusEventArgs
{
	public int ProcessId { get; private set; }

	public LaunchApprovedExeCompleteEventArgs(int hrStatus, int processId)
		: base(hrStatus)
	{
		ProcessId = processId;
	}
}
[Serializable]
public class BeginMsiTransactionBeginEventArgs : CancellableHResultEventArgs
{
	public string TransactionId { get; private set; }

	public BeginMsiTransactionBeginEventArgs(string transactionId, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		TransactionId = transactionId;
	}
}
[Serializable]
public class BeginMsiTransactionCompleteEventArgs : StatusEventArgs
{
	public string TransactionId { get; private set; }

	public BeginMsiTransactionCompleteEventArgs(string transactionId, int hrStatus)
		: base(hrStatus)
	{
		TransactionId = transactionId;
	}
}
[Serializable]
public class CommitMsiTransactionBeginEventArgs : CancellableHResultEventArgs
{
	public string TransactionId { get; private set; }

	public CommitMsiTransactionBeginEventArgs(string transactionId, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		TransactionId = transactionId;
	}
}
[Serializable]
public class CommitMsiTransactionCompleteEventArgs : ActionEventArgs<BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION>
{
	public string TransactionId { get; private set; }

	public ApplyRestart Restart { get; private set; }

	public CommitMsiTransactionCompleteEventArgs(string transactionId, int hrStatus, ApplyRestart restart, BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION recommendation, BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		TransactionId = transactionId;
		Restart = restart;
	}
}
[Serializable]
public class RollbackMsiTransactionBeginEventArgs : HResultEventArgs
{
	public string TransactionId { get; private set; }

	public RollbackMsiTransactionBeginEventArgs(string transactionId)
	{
		TransactionId = transactionId;
	}
}
[Serializable]
public class RollbackMsiTransactionCompleteEventArgs : ActionEventArgs<BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION>
{
	public string TransactionId { get; private set; }

	public ApplyRestart Restart { get; private set; }

	public RollbackMsiTransactionCompleteEventArgs(string transactionId, int hrStatus, ApplyRestart restart, BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION recommendation, BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		TransactionId = transactionId;
		Restart = restart;
	}
}
[Serializable]
public class PauseAutomaticUpdatesBeginEventArgs : HResultEventArgs
{
}
[Serializable]
public class PauseAutomaticUpdatesCompleteEventArgs : StatusEventArgs
{
	public PauseAutomaticUpdatesCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class SystemRestorePointBeginEventArgs : HResultEventArgs
{
}
[Serializable]
public class SystemRestorePointCompleteEventArgs : StatusEventArgs
{
	public SystemRestorePointCompleteEventArgs(int hrStatus)
		: base(hrStatus)
	{
	}
}
[Serializable]
public class CacheContainerOrPayloadVerifyBeginEventArgs : CancellableHResultEventArgs
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public CacheContainerOrPayloadVerifyBeginEventArgs(string packageOrContainerId, string payloadId, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
	}
}
[Serializable]
public class CacheContainerOrPayloadVerifyProgressEventArgs : CacheProgressBaseEventArgs
{
	public CacheContainerOrPayloadVerifyProgressEventArgs(string packageOrContainerId, string payloadId, long progress, long total, int overallPercentage, bool cancelRecommendation)
		: base(packageOrContainerId, payloadId, progress, total, overallPercentage, cancelRecommendation)
	{
	}
}
[Serializable]
public class CacheContainerOrPayloadVerifyCompleteEventArgs : StatusEventArgs
{
	public string PackageOrContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public CacheContainerOrPayloadVerifyCompleteEventArgs(string packageOrContainerId, string payloadId, int hrStatus)
		: base(hrStatus)
	{
		PackageOrContainerId = packageOrContainerId;
		PayloadId = payloadId;
	}
}
[Serializable]
public class CachePayloadExtractBeginEventArgs : CancellableHResultEventArgs
{
	public string ContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public CachePayloadExtractBeginEventArgs(string containerId, string payloadId, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		ContainerId = containerId;
		PayloadId = payloadId;
	}
}
[Serializable]
public class CachePayloadExtractProgressEventArgs : CacheProgressBaseEventArgs
{
	public CachePayloadExtractProgressEventArgs(string containerId, string payloadId, long progress, long total, int overallPercentage, bool cancelRecommendation)
		: base(containerId, payloadId, progress, total, overallPercentage, cancelRecommendation)
	{
	}
}
[Serializable]
public class CachePayloadExtractCompleteEventArgs : StatusEventArgs
{
	public string ContainerId { get; private set; }

	public string PayloadId { get; private set; }

	public CachePayloadExtractCompleteEventArgs(string containerId, string payloadId, int hrStatus)
		: base(hrStatus)
	{
		ContainerId = containerId;
		PayloadId = payloadId;
	}
}
[Serializable]
public class PlanRestoreRelatedBundleEventArgs : CancellableHResultEventArgs
{
	public string BundleId { get; private set; }

	public RequestState RecommendedState { get; private set; }

	public RequestState State { get; set; }

	public PlanRestoreRelatedBundleEventArgs(string bundleId, RequestState recommendedState, RequestState state, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		BundleId = bundleId;
		RecommendedState = recommendedState;
		State = state;
	}
}
[Serializable]
public class ExecuteProcessCancelEventArgs : HResultEventArgs
{
	public string PackageId { get; private set; }

	public int ProcessId { get; private set; }

	public BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION Recommendation { get; private set; }

	public BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION Action { get; set; }

	public ExecuteProcessCancelEventArgs(string packageId, int processId, BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION recommendation, BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION action)
	{
		PackageId = packageId;
		ProcessId = processId;
		Recommendation = recommendation;
		Action = action;
	}
}
[Serializable]
public class DetectRelatedBundlePackageEventArgs : CancellableHResultEventArgs
{
	public string PackageId { get; private set; }

	public string ProductCode { get; private set; }

	public RelationType RelationType { get; private set; }

	public bool PerMachine { get; private set; }

	public string Version { get; private set; }

	public DetectRelatedBundlePackageEventArgs(string packageId, string productCode, RelationType relationType, bool perMachine, string version, bool cancelRecommendation)
		: base(cancelRecommendation)
	{
		PackageId = packageId;
		ProductCode = productCode;
		RelationType = relationType;
		PerMachine = perMachine;
		Version = version;
	}
}
[Serializable]
public class CachePackageNonVitalValidationFailureEventArgs : ActionEventArgs<BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION>
{
	public string PackageId { get; private set; }

	public CachePackageNonVitalValidationFailureEventArgs(string packageId, int hrStatus, BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION recommendation, BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION action)
		: base(hrStatus, recommendation, action)
	{
		PackageId = packageId;
	}
}
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("53C31D56-49C0-426B-AB06-099D717C67FE")]
public interface IBootstrapperApplication
{
	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int BAProc(int message, IntPtr pvArgs, IntPtr pvResults);

	void BAProcFallback(int message, IntPtr pvArgs, IntPtr pvResults, ref int phr);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCreate(IBootstrapperEngine engine, ref Command command);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDestroy(bool reload);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnStartup();

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnShutdown(ref BOOTSTRAPPER_SHUTDOWN_ACTION action);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectBegin([MarshalAs(UnmanagedType.Bool)] bool fCached, [MarshalAs(UnmanagedType.U4)] RegistrationType registrationType, [MarshalAs(UnmanagedType.U4)] int cPackages, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectForwardCompatibleBundle([MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.U4)] RelationType relationType, [MarshalAs(UnmanagedType.LPWStr)] string wzBundleTag, [MarshalAs(UnmanagedType.Bool)] bool fPerMachine, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion, [MarshalAs(UnmanagedType.Bool)] bool fMissingFromCache, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectUpdateBegin([MarshalAs(UnmanagedType.LPWStr)] string wzUpdateLocation, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel, [MarshalAs(UnmanagedType.Bool)] ref bool fSkip);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectUpdate([MarshalAs(UnmanagedType.LPWStr)] string wzUpdateLocation, [MarshalAs(UnmanagedType.U8)] long dw64Size, [MarshalAs(UnmanagedType.LPWStr)] string wzHash, [MarshalAs(UnmanagedType.U4)] UpdateHashType hashAlgorithm, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion, [MarshalAs(UnmanagedType.LPWStr)] string wzTitle, [MarshalAs(UnmanagedType.LPWStr)] string wzSummary, [MarshalAs(UnmanagedType.LPWStr)] string wzContentType, [MarshalAs(UnmanagedType.LPWStr)] string wzContent, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel, [MarshalAs(UnmanagedType.Bool)] ref bool fStopProcessingUpdates);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectUpdateComplete(int hrStatus, [MarshalAs(UnmanagedType.Bool)] ref bool fIgnoreError);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectRelatedBundle([MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.U4)] RelationType relationType, [MarshalAs(UnmanagedType.LPWStr)] string wzBundleTag, [MarshalAs(UnmanagedType.Bool)] bool fPerMachine, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion, [MarshalAs(UnmanagedType.Bool)] bool fMissingFromCache, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectPackageBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectCompatibleMsiPackage([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzCompatiblePackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzCompatiblePackageVersion, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectRelatedMsiPackage([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzUpgradeCode, [MarshalAs(UnmanagedType.LPWStr)] string wzProductCode, [MarshalAs(UnmanagedType.Bool)] bool fPerMachine, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion, [MarshalAs(UnmanagedType.U4)] RelatedOperation operation, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectPatchTarget([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzProductCode, [MarshalAs(UnmanagedType.U4)] PackageState patchState, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectMsiFeature([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzFeatureId, [MarshalAs(UnmanagedType.U4)] FeatureState state, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectPackageComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, int hrStatus, [MarshalAs(UnmanagedType.U4)] PackageState state, [MarshalAs(UnmanagedType.Bool)] bool fCached);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectComplete(int hrStatus, [MarshalAs(UnmanagedType.Bool)] bool fEligibleForCleanup);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanBegin([MarshalAs(UnmanagedType.U4)] int cPackages, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanRelatedBundle([MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.U4)] RequestState recommendedState, [MarshalAs(UnmanagedType.U4)] ref RequestState pRequestedState, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanRollbackBoundary([MarshalAs(UnmanagedType.LPWStr)] string wzRollbackBoundaryId, [MarshalAs(UnmanagedType.Bool)] bool fRecommendedTransaction, [MarshalAs(UnmanagedType.Bool)] ref bool fTransaction, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanPackageBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.U4)] PackageState state, [MarshalAs(UnmanagedType.Bool)] bool fCached, [MarshalAs(UnmanagedType.U4)] BOOTSTRAPPER_PACKAGE_CONDITION_RESULT installCondition, [MarshalAs(UnmanagedType.U4)] BOOTSTRAPPER_PACKAGE_CONDITION_RESULT repairCondition, [MarshalAs(UnmanagedType.U4)] RequestState recommendedState, [MarshalAs(UnmanagedType.U4)] BOOTSTRAPPER_CACHE_TYPE recommendedCacheType, [MarshalAs(UnmanagedType.U4)] ref RequestState pRequestedState, [MarshalAs(UnmanagedType.U4)] ref BOOTSTRAPPER_CACHE_TYPE pRequestedCacheType, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanCompatibleMsiPackageBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzCompatiblePackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzCompatiblePackageVersion, [MarshalAs(UnmanagedType.Bool)] bool fRecommendedRemove, [MarshalAs(UnmanagedType.Bool)] ref bool fRequestRemove, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanCompatibleMsiPackageComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzCompatiblePackageId, int hrStatus, [MarshalAs(UnmanagedType.Bool)] bool fRequestedRemove);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanPatchTarget([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzProductCode, [MarshalAs(UnmanagedType.U4)] RequestState recommendedState, [MarshalAs(UnmanagedType.U4)] ref RequestState pRequestedState, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanMsiFeature([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzFeatureId, [MarshalAs(UnmanagedType.U4)] FeatureState recommendedState, [MarshalAs(UnmanagedType.U4)] ref FeatureState pRequestedState, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanMsiPackage([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.Bool)] bool fExecute, [MarshalAs(UnmanagedType.U4)] ActionState action, [MarshalAs(UnmanagedType.U4)] BOOTSTRAPPER_MSI_FILE_VERSIONING recommendedFileVersioning, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel, [MarshalAs(UnmanagedType.U4)] ref BURN_MSI_PROPERTY actionMsiProperty, [MarshalAs(UnmanagedType.U4)] ref INSTALLUILEVEL uiLevel, [MarshalAs(UnmanagedType.Bool)] ref bool fDisableExternalUiHandler, [MarshalAs(UnmanagedType.U4)] ref BOOTSTRAPPER_MSI_FILE_VERSIONING fileVersioning);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanPackageComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, int hrStatus, [MarshalAs(UnmanagedType.U4)] RequestState requested);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlannedCompatiblePackage([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzCompatiblePackageId, [MarshalAs(UnmanagedType.Bool)] bool fRemove);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlannedPackage([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.U4)] ActionState execute, [MarshalAs(UnmanagedType.U4)] ActionState rollback, [MarshalAs(UnmanagedType.Bool)] bool fPlannedCache, [MarshalAs(UnmanagedType.Bool)] bool fPlannedUncache);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnApplyBegin([MarshalAs(UnmanagedType.U4)] int dwPhaseCount, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnElevateBegin([MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnElevateComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnProgress([MarshalAs(UnmanagedType.U4)] int dwProgressPercentage, [MarshalAs(UnmanagedType.U4)] int dwOverallPercentage, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnError([MarshalAs(UnmanagedType.U4)] ErrorType errorType, [MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.U4)] int dwCode, [MarshalAs(UnmanagedType.LPWStr)] string wzError, [MarshalAs(UnmanagedType.I4)] int dwUIHint, [MarshalAs(UnmanagedType.U4)] int cData, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 5)] string[] rgwzData, [MarshalAs(UnmanagedType.I4)] Result nRecommendation, [MarshalAs(UnmanagedType.I4)] ref Result pResult);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnRegisterBegin([MarshalAs(UnmanagedType.I4)] RegistrationType recommendedRegistrationType, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel, [MarshalAs(UnmanagedType.I4)] ref RegistrationType pRegistrationType);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnRegisterComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheBegin([MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCachePackageBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.U4)] int cCachePayloads, [MarshalAs(UnmanagedType.U8)] long dw64PackageCacheSize, [MarshalAs(UnmanagedType.Bool)] bool fVital, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheAcquireBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.LPWStr)] string wzSource, [MarshalAs(UnmanagedType.LPWStr)] string wzDownloadUrl, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadContainerId, [MarshalAs(UnmanagedType.U4)] CacheOperation recommendation, [MarshalAs(UnmanagedType.I4)] ref CacheOperation action, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheAcquireProgress([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.U8)] long dw64Progress, [MarshalAs(UnmanagedType.U8)] long dw64Total, [MarshalAs(UnmanagedType.U4)] int dwOverallPercentage, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheAcquireResolving([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[] searchPaths, [MarshalAs(UnmanagedType.U4)] int cSearchPaths, [MarshalAs(UnmanagedType.Bool)] bool fFoundLocal, [MarshalAs(UnmanagedType.U4)] int dwRecommendedSearchPath, [MarshalAs(UnmanagedType.LPWStr)] string wzDownloadUrl, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadContainerId, [MarshalAs(UnmanagedType.I4)] CacheResolveOperation recommendation, [MarshalAs(UnmanagedType.U4)] ref int dwChosenSearchPath, [MarshalAs(UnmanagedType.I4)] ref CacheResolveOperation action, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheAcquireComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, int hrStatus, BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION pAction);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheVerifyBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheVerifyProgress([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.U8)] long dw64Progress, [MarshalAs(UnmanagedType.U8)] long dw64Total, [MarshalAs(UnmanagedType.U4)] int dwOverallPercentage, [MarshalAs(UnmanagedType.I4)] CacheVerifyStep verifyStep, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheVerifyComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, int hrStatus, BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION action);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCachePackageComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, int hrStatus, BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION recommendation, ref BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION action);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecuteBegin([MarshalAs(UnmanagedType.U4)] int cExecutingPackages, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecutePackageBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.Bool)] bool fExecute, [MarshalAs(UnmanagedType.U4)] ActionState action, [MarshalAs(UnmanagedType.U4)] INSTALLUILEVEL uiLevel, [MarshalAs(UnmanagedType.Bool)] bool fDisableExternalUiHandler, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecutePatchTarget([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzTargetProductCode, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecuteProgress([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.U4)] int dwProgressPercentage, [MarshalAs(UnmanagedType.U4)] int dwOverallPercentage, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecuteMsiMessage([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.U4)] InstallMessage messageType, [MarshalAs(UnmanagedType.I4)] int dwUIHint, [MarshalAs(UnmanagedType.LPWStr)] string wzMessage, [MarshalAs(UnmanagedType.U4)] int cData, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 4)] string[] rgwzData, [MarshalAs(UnmanagedType.I4)] Result nRecommendation, [MarshalAs(UnmanagedType.I4)] ref Result pResult);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecuteFilesInUse([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.U4)] int cFiles, [In][MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] rgwzFiles, [MarshalAs(UnmanagedType.I4)] Result nRecommendation, [MarshalAs(UnmanagedType.I4)] FilesInUseType source, [MarshalAs(UnmanagedType.I4)] ref Result pResult);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecutePackageComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, int hrStatus, [MarshalAs(UnmanagedType.U4)] ApplyRestart restart, [MarshalAs(UnmanagedType.I4)] BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION recommendation, [MarshalAs(UnmanagedType.I4)] ref BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION pAction);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecuteComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnUnregisterBegin([MarshalAs(UnmanagedType.I4)] RegistrationType recommendedRegistrationType, [MarshalAs(UnmanagedType.I4)] ref RegistrationType pRegistrationType);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnUnregisterComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnApplyComplete(int hrStatus, [MarshalAs(UnmanagedType.U4)] ApplyRestart restart, [MarshalAs(UnmanagedType.I4)] BOOTSTRAPPER_APPLYCOMPLETE_ACTION recommendation, [MarshalAs(UnmanagedType.I4)] ref BOOTSTRAPPER_APPLYCOMPLETE_ACTION pAction);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnLaunchApprovedExeBegin([MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnLaunchApprovedExeComplete(int hrStatus, int processId);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnBeginMsiTransactionBegin([MarshalAs(UnmanagedType.LPWStr)] string wzTransactionId, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnBeginMsiTransactionComplete([MarshalAs(UnmanagedType.LPWStr)] string wzTransactionId, int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCommitMsiTransactionBegin([MarshalAs(UnmanagedType.LPWStr)] string wzTransactionId, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCommitMsiTransactionComplete([MarshalAs(UnmanagedType.LPWStr)] string wzTransactionId, int hrStatus, [MarshalAs(UnmanagedType.U4)] ApplyRestart restart, [MarshalAs(UnmanagedType.I4)] BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION recommendation, [MarshalAs(UnmanagedType.I4)] ref BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION pAction);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnRollbackMsiTransactionBegin([MarshalAs(UnmanagedType.LPWStr)] string wzTransactionId);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnRollbackMsiTransactionComplete([MarshalAs(UnmanagedType.LPWStr)] string wzTransactionId, int hrStatus, [MarshalAs(UnmanagedType.U4)] ApplyRestart restart, [MarshalAs(UnmanagedType.I4)] BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION recommendation, [MarshalAs(UnmanagedType.I4)] ref BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION pAction);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPauseAutomaticUpdatesBegin();

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPauseAutomaticUpdatesComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnSystemRestorePointBegin();

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnSystemRestorePointComplete(int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanForwardCompatibleBundle([MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.U4)] RelationType relationType, [MarshalAs(UnmanagedType.LPWStr)] string wzBundleTag, [MarshalAs(UnmanagedType.Bool)] bool fPerMachine, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion, [MarshalAs(UnmanagedType.Bool)] bool fRecommendedIgnoreBundle, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel, [MarshalAs(UnmanagedType.Bool)] ref bool fIgnoreBundle);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheContainerOrPayloadVerifyBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheContainerOrPayloadVerifyProgress([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.U8)] long dw64Progress, [MarshalAs(UnmanagedType.U8)] long dw64Total, [MarshalAs(UnmanagedType.U4)] int dwOverallPercentage, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCacheContainerOrPayloadVerifyComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCachePayloadExtractBegin([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCachePayloadExtractProgress([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.U8)] long dw64Progress, [MarshalAs(UnmanagedType.U8)] long dw64Total, [MarshalAs(UnmanagedType.U4)] int dwOverallPercentage, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCachePayloadExtractComplete([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanRestoreRelatedBundle([MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.U4)] RequestState recommendedState, [MarshalAs(UnmanagedType.U4)] ref RequestState pRequestedState, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnPlanRelatedBundleType([MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.U4)] RelatedBundlePlanType recommendedType, [MarshalAs(UnmanagedType.U4)] ref RelatedBundlePlanType pRequestedType, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnApplyDowngrade([MarshalAs(UnmanagedType.I4)] int hrRecommended, [MarshalAs(UnmanagedType.I4)] ref int hrStatus);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnExecuteProcessCancel([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, int processId, [MarshalAs(UnmanagedType.I4)] BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION recommendation, [MarshalAs(UnmanagedType.I4)] ref BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION pAction);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnDetectRelatedBundlePackage([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, [MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.U4)] RelationType relationType, [MarshalAs(UnmanagedType.Bool)] bool fPerMachine, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion, [MarshalAs(UnmanagedType.Bool)] ref bool fCancel);

	[PreserveSig]
	[return: MarshalAs(UnmanagedType.I4)]
	int OnCachePackageNonVitalValidationFailure([MarshalAs(UnmanagedType.LPWStr)] string wzPackageId, int hrStatus, BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION recommendation, ref BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION action);
}
public enum Display
{
	Unknown,
	Embedded,
	None,
	Passive,
	Full
}
public enum InstallMessage
{
	FatalExit = 0,
	Error = 16777216,
	Warning = 33554432,
	User = 50331648,
	Info = 67108864,
	FilesInUse = 83886080,
	ResolveSource = 100663296,
	OutOfDiskSpace = 117440512,
	ActionStart = 134217728,
	ActionData = 150994944,
	Progress = 167772160,
	CommonData = 184549376,
	Initialize = 201326592,
	Terminate = 218103808,
	ShowDialog = 234881024,
	Performance = 251658240,
	RMFilesInUse = 419430400,
	InstallStart = 436207616,
	InstallEnd = 452984832
}
public enum Restart
{
	Unknown,
	Never,
	Prompt,
	Automatic,
	Always
}
public enum RegistrationType
{
	None,
	InProgress,
	Full
}
public enum Result
{
	Error = -1,
	None,
	Ok,
	Cancel,
	Abort,
	Retry,
	Ignore,
	Yes,
	No,
	Close,
	Help,
	TryAgain,
	Continue
}
public enum ResumeType
{
	None,
	Invalid,
	Interrupted,
	Reboot,
	Suspend,
	Arp
}
public enum ErrorType
{
	Elevate,
	WindowsInstaller,
	ExePackage,
	HttpServerAuthentication,
	HttpProxyAuthentication,
	Apply
}
public enum FilesInUseType
{
	Msi,
	MsiRm,
	Netfx
}
public enum RelatedOperation
{
	None,
	Downgrade,
	MinorUpdate,
	MajorUpgrade,
	Remove,
	Install,
	Repair
}
public enum CacheOperation
{
	None,
	Copy,
	Download,
	Extract
}
public enum CacheResolveOperation
{
	None,
	Local,
	Download,
	Container,
	Retry
}
public enum CacheVerifyStep
{
	Stage,
	Hash,
	Finalize
}
public enum ApplyRestart
{
	None,
	RestartRequired,
	RestartInitiated
}
public enum RelationType
{
	None,
	Detect,
	Upgrade,
	Addon,
	Patch,
	DependentAddon,
	DependentPatch,
	Update,
	ChainPackage
}
public enum RelatedBundlePlanType
{
	None,
	Downgrade,
	Upgrade,
	Addon,
	Patch,
	DependentAddon,
	DependentPatch
}
[Flags]
public enum EndSessionReasons
{
	Unknown = 0,
	CloseApplication = 1,
	Critical = 0x40000000,
	Logoff = int.MinValue
}
public enum BOOTSTRAPPER_APPLYCOMPLETE_ACTION
{
	None,
	Restart
}
public enum BOOTSTRAPPER_CACHE_TYPE
{
	Remove,
	Keep,
	Force
}
public enum BOOTSTRAPPER_CACHEACQUIRECOMPLETE_ACTION
{
	None,
	Retry
}
public enum BOOTSTRAPPER_CACHEPACKAGECOMPLETE_ACTION
{
	None,
	Ignore,
	Retry
}
public enum BOOTSTRAPPER_CACHEPACKAGENONVITALVALIDATIONFAILURE_ACTION
{
	None,
	Acquire
}
public enum BOOTSTRAPPER_CACHEVERIFYCOMPLETE_ACTION
{
	None,
	RetryVerification,
	RetryAcquisition
}
public enum BOOTSTRAPPER_EXECUTEPACKAGECOMPLETE_ACTION
{
	None,
	Ignore,
	Retry,
	Restart,
	Suspend
}
public enum BOOTSTRAPPER_EXECUTEMSITRANSACTIONCOMPLETE_ACTION
{
	None,
	Restart
}
public enum BOOTSTRAPPER_EXECUTEPROCESSCANCEL_ACTION
{
	Abandon,
	Wait
}
public enum BOOTSTRAPPER_PACKAGE_CONDITION_RESULT
{
	Default,
	False,
	True
}
public enum BOOTSTRAPPER_RESOLVESOURCE_ACTION
{
	None,
	Retry,
	Download
}
public enum BOOTSTRAPPER_SHUTDOWN_ACTION
{
	None,
	Restart,
	ReloadBootstrapper,
	SkipCleanup
}
public enum BOOTSTRAPPER_MSI_FILE_VERSIONING
{
	Older,
	Equal,
	All
}
public enum BURN_MSI_PROPERTY
{
	None,
	Install,
	Modify,
	Repair,
	Uninstall
}
[Flags]
public enum INSTALLUILEVEL
{
	NoChange = 0,
	Default = 1,
	None = 2,
	Basic = Default | None,
	Reduced = 4,
	Full = Default | Reduced,
	EndDialog = 0x80,
	ProgressOnly = 0x40,
	HideCancel = 0x20,
	SourceResOnly = 0x100,
	UacOnly = 0x200
}
public interface IBootstrapperApplicationData
{
	FileInfo BADataFile { get; }

	IBundleInfo Bundle { get; }
}
[Obsolete("Bootstrapper applications now run out of proc and do not use a BootstrapperApplicationFactory. Remove your BootstrapperApplicationFactory class. See https://wixtoolset.org/docs/fiveforfour/ for more details.")]
public interface IBootstrapperApplicationFactory
{
	void Create(IntPtr pArgs, IntPtr pResults);
}
public interface IBootstrapperCommand
{
	LaunchAction Action { get; }

	Display Display { get; }

	string CommandLine { get; }

	int CmdShow { get; }

	ResumeType Resume { get; }

	IntPtr SplashScreen { get; }

	RelationType Relation { get; }

	bool Passthrough { get; }

	string LayoutDirectory { get; }

	string BootstrapperWorkingFolder { get; }

	string BootstrapperApplicationDataPath { get; }

	IMbaCommand ParseCommandLine();
}
[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("6480D616-27A0-44D7-905B-81512C29C2FB")]
[GeneratedCode("WixToolset.Bootstrapper.InteropCodeGenerator", "1.0.0.0")]
public interface IBootstrapperEngine
{
	void GetPackageCount([MarshalAs(UnmanagedType.U4)] out int pcPackages);

	[PreserveSig]
	int GetVariableNumeric([MarshalAs(UnmanagedType.LPWStr)] string wzVariable, out long pllValue);

	[PreserveSig]
	int GetVariableString([MarshalAs(UnmanagedType.LPWStr)] string wzVariable, IntPtr wzValue, ref IntPtr pcchValue);

	[PreserveSig]
	int GetVariableVersion([MarshalAs(UnmanagedType.LPWStr)] string wzVariable, IntPtr wzValue, ref IntPtr pcchValue);

	[PreserveSig]
	int FormatString([MarshalAs(UnmanagedType.LPWStr)] string wzIn, [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzOut, ref IntPtr pcchOut);

	[PreserveSig]
	int EscapeString([MarshalAs(UnmanagedType.LPWStr)] string wzIn, [Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzOut, ref IntPtr pcchOut);

	void EvaluateCondition([MarshalAs(UnmanagedType.LPWStr)] string wzCondition, [MarshalAs(UnmanagedType.Bool)] out bool pf);

	void Log([MarshalAs(UnmanagedType.U4)] LogLevel level, [MarshalAs(UnmanagedType.LPWStr)] string wzMessage);

	void SendEmbeddedError([MarshalAs(UnmanagedType.U4)] int dwErrorCode, [MarshalAs(UnmanagedType.LPWStr)] string wzMessage, [MarshalAs(UnmanagedType.U4)] int dwUIHint, [MarshalAs(UnmanagedType.I4)] out int pnResult);

	void SendEmbeddedProgress([MarshalAs(UnmanagedType.U4)] int dwProgressPercentage, [MarshalAs(UnmanagedType.U4)] int dwOverallProgressPercentage, [MarshalAs(UnmanagedType.I4)] out int pnResult);

	void SetUpdate([MarshalAs(UnmanagedType.LPWStr)] string wzLocalSource, [MarshalAs(UnmanagedType.LPWStr)] string wzDownloadSource, [MarshalAs(UnmanagedType.U8)] long qwValue, [MarshalAs(UnmanagedType.U4)] UpdateHashType hashType, [MarshalAs(UnmanagedType.LPWStr)] string wzHash, [MarshalAs(UnmanagedType.LPWStr)] string wzUpdatePackageId);

	void SetLocalSource([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.LPWStr)] string wzPath);

	void SetDownloadSource([MarshalAs(UnmanagedType.LPWStr)] string wzPackageOrContainerId, [MarshalAs(UnmanagedType.LPWStr)] string wzPayloadId, [MarshalAs(UnmanagedType.LPWStr)] string wzUrl, [MarshalAs(UnmanagedType.LPWStr)] string wzUser, [MarshalAs(UnmanagedType.LPWStr)] string wzPassword);

	void SetVariableNumeric([MarshalAs(UnmanagedType.LPWStr)] string wzVariable, long llValue);

	void SetVariableString([MarshalAs(UnmanagedType.LPWStr)] string wzVariable, IntPtr wzValue, [MarshalAs(UnmanagedType.Bool)] bool fFormatted);

	void SetVariableVersion([MarshalAs(UnmanagedType.LPWStr)] string wzVariable, IntPtr wzValue);

	void CloseSplashScreen();

	void Detect(IntPtr hwndParent);

	void Plan([MarshalAs(UnmanagedType.U4)] LaunchAction action);

	[PreserveSig]
	int Elevate(IntPtr hwndParent);

	void Apply(IntPtr hwndParent);

	void Quit([MarshalAs(UnmanagedType.U4)] int dwExitCode);

	void LaunchApprovedExe(IntPtr hwndParent, [MarshalAs(UnmanagedType.LPWStr)] string wzApprovedExeForElevationId, [MarshalAs(UnmanagedType.LPWStr)] string wzArguments, [MarshalAs(UnmanagedType.U4)] int dwWaitForInputIdleTimeout);

	void SetUpdateSource([MarshalAs(UnmanagedType.LPWStr)] string url);

	void CompareVersions([MarshalAs(UnmanagedType.LPWStr)] string wzVersion1, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion2, [MarshalAs(UnmanagedType.I4)] out int pnResult);

	[PreserveSig]
	int GetRelatedBundleVariable([MarshalAs(UnmanagedType.LPWStr)] string wzBundleId, [MarshalAs(UnmanagedType.LPWStr)] string wzVariable, IntPtr wzValue, ref IntPtr pcchValue);
}
public enum ActionState
{
	None,
	Uninstall,
	Install,
	Modify,
	Repair,
	MinorUpgrade
}
public enum LaunchAction
{
	Unknown,
	Help,
	Layout,
	UnsafeUninstall,
	Uninstall,
	Cache,
	Install,
	Modify,
	Repair,
	UpdateReplace,
	UpdateReplaceEmbedded
}
public enum LogLevel
{
	None,
	Standard,
	Verbose,
	Debug,
	Error
}
public enum UpdateHashType
{
	None,
	Sha512
}
public enum PackageState
{
	Unknown = 0,
	Obsolete = 1,
	Absent = 2,
	Present = 3,
	Superseded = 4,
	[Obsolete("Use DetectPackageCompleteEventArgs.Cached instead.")]
	Cached = Present
}
public enum RequestState
{
	None,
	ForceAbsent,
	Absent,
	Cache,
	Present,
	ForcePresent,
	Repair
}
public enum FeatureState
{
	Unknown,
	Absent,
	Advertised,
	Local,
	Source
}
public interface IBundleInfo
{
	string LogVariable { get; }

	string Name { get; }

	IOverridableVariables OverridableVariables { get; }

	IDictionary<string, IPackageInfo> Packages { get; }

	bool PerMachine { get; }

	IPackageInfo AddRelatedBundleAsPackage(string productCode, RelationType relationType, bool perMachine, string version);

	IPackageInfo AddUpdateBundleAsPackage(string packageId);
}
public interface IDefaultBootstrapperApplication : IBootstrapperApplication
{
	event EventHandler<ApplyBeginEventArgs> ApplyBegin;

	event EventHandler<ApplyCompleteEventArgs> ApplyComplete;

	event EventHandler<ApplyDowngradeEventArgs> ApplyDowngrade;

	event EventHandler<BeginMsiTransactionBeginEventArgs> BeginMsiTransactionBegin;

	event EventHandler<BeginMsiTransactionCompleteEventArgs> BeginMsiTransactionComplete;

	event EventHandler<CacheAcquireBeginEventArgs> CacheAcquireBegin;

	event EventHandler<CacheAcquireCompleteEventArgs> CacheAcquireComplete;

	event EventHandler<CacheAcquireProgressEventArgs> CacheAcquireProgress;

	event EventHandler<CacheAcquireResolvingEventArgs> CacheAcquireResolving;

	event EventHandler<CacheBeginEventArgs> CacheBegin;

	event EventHandler<CacheCompleteEventArgs> CacheComplete;

	event EventHandler<CacheContainerOrPayloadVerifyBeginEventArgs> CacheContainerOrPayloadVerifyBegin;

	event EventHandler<CacheContainerOrPayloadVerifyCompleteEventArgs> CacheContainerOrPayloadVerifyComplete;

	event EventHandler<CacheContainerOrPayloadVerifyProgressEventArgs> CacheContainerOrPayloadVerifyProgress;

	event EventHandler<CachePackageBeginEventArgs> CachePackageBegin;

	event EventHandler<CachePackageCompleteEventArgs> CachePackageComplete;

	event EventHandler<CachePackageNonVitalValidationFailureEventArgs> CachePackageNonVitalValidationFailure;

	event EventHandler<CachePayloadExtractBeginEventArgs> CachePayloadExtractBegin;

	event EventHandler<CachePayloadExtractCompleteEventArgs> CachePayloadExtractComplete;

	event EventHandler<CachePayloadExtractProgressEventArgs> CachePayloadExtractProgress;

	event EventHandler<CacheVerifyBeginEventArgs> CacheVerifyBegin;

	event EventHandler<CacheVerifyCompleteEventArgs> CacheVerifyComplete;

	event EventHandler<CacheVerifyProgressEventArgs> CacheVerifyProgress;

	event EventHandler<CommitMsiTransactionBeginEventArgs> CommitMsiTransactionBegin;

	event EventHandler<CommitMsiTransactionCompleteEventArgs> CommitMsiTransactionComplete;

	event EventHandler<CreateEventArgs> Create;

	event EventHandler<DestroyEventArgs> Destroy;

	event EventHandler<DetectBeginEventArgs> DetectBegin;

	event EventHandler<DetectCompatibleMsiPackageEventArgs> DetectCompatibleMsiPackage;

	event EventHandler<DetectCompleteEventArgs> DetectComplete;

	event EventHandler<DetectForwardCompatibleBundleEventArgs> DetectForwardCompatibleBundle;

	event EventHandler<DetectMsiFeatureEventArgs> DetectMsiFeature;

	event EventHandler<DetectPackageBeginEventArgs> DetectPackageBegin;

	event EventHandler<DetectPackageCompleteEventArgs> DetectPackageComplete;

	event EventHandler<DetectPatchTargetEventArgs> DetectPatchTarget;

	event EventHandler<DetectRelatedBundleEventArgs> DetectRelatedBundle;

	event EventHandler<DetectRelatedBundlePackageEventArgs> DetectRelatedBundlePackage;

	event EventHandler<DetectRelatedMsiPackageEventArgs> DetectRelatedMsiPackage;

	event EventHandler<DetectUpdateEventArgs> DetectUpdate;

	event EventHandler<DetectUpdateBeginEventArgs> DetectUpdateBegin;

	event EventHandler<DetectUpdateCompleteEventArgs> DetectUpdateComplete;

	event EventHandler<ElevateBeginEventArgs> ElevateBegin;

	event EventHandler<ElevateCompleteEventArgs> ElevateComplete;

	event EventHandler<ErrorEventArgs> Error;

	event EventHandler<ExecuteBeginEventArgs> ExecuteBegin;

	event EventHandler<ExecuteCompleteEventArgs> ExecuteComplete;

	event EventHandler<ExecuteFilesInUseEventArgs> ExecuteFilesInUse;

	event EventHandler<ExecuteMsiMessageEventArgs> ExecuteMsiMessage;

	event EventHandler<ExecutePackageBeginEventArgs> ExecutePackageBegin;

	event EventHandler<ExecutePackageCompleteEventArgs> ExecutePackageComplete;

	event EventHandler<ExecuteProcessCancelEventArgs> ExecuteProcessCancel;

	event EventHandler<ExecutePatchTargetEventArgs> ExecutePatchTarget;

	event EventHandler<ExecuteProgressEventArgs> ExecuteProgress;

	event EventHandler<LaunchApprovedExeBeginEventArgs> LaunchApprovedExeBegin;

	event EventHandler<LaunchApprovedExeCompleteEventArgs> LaunchApprovedExeComplete;

	event EventHandler<PauseAutomaticUpdatesBeginEventArgs> PauseAutomaticUpdatesBegin;

	event EventHandler<PauseAutomaticUpdatesCompleteEventArgs> PauseAutomaticUpdatesComplete;

	event EventHandler<PlanBeginEventArgs> PlanBegin;

	event EventHandler<PlanCompatibleMsiPackageBeginEventArgs> PlanCompatibleMsiPackageBegin;

	event EventHandler<PlanCompatibleMsiPackageCompleteEventArgs> PlanCompatibleMsiPackageComplete;

	event EventHandler<PlanCompleteEventArgs> PlanComplete;

	event EventHandler<PlanForwardCompatibleBundleEventArgs> PlanForwardCompatibleBundle;

	event EventHandler<PlannedCompatiblePackageEventArgs> PlannedCompatiblePackage;

	event EventHandler<PlannedPackageEventArgs> PlannedPackage;

	event EventHandler<PlanMsiFeatureEventArgs> PlanMsiFeature;

	event EventHandler<PlanMsiPackageEventArgs> PlanMsiPackage;

	event EventHandler<PlanPackageBeginEventArgs> PlanPackageBegin;

	event EventHandler<PlanPackageCompleteEventArgs> PlanPackageComplete;

	event EventHandler<PlanPatchTargetEventArgs> PlanPatchTarget;

	event EventHandler<PlanRelatedBundleEventArgs> PlanRelatedBundle;

	event EventHandler<PlanRelatedBundleTypeEventArgs> PlanRelatedBundleType;

	event EventHandler<PlanRestoreRelatedBundleEventArgs> PlanRestoreRelatedBundle;

	event EventHandler<PlanRollbackBoundaryEventArgs> PlanRollbackBoundary;

	event EventHandler<ProgressEventArgs> Progress;

	event EventHandler<RegisterBeginEventArgs> RegisterBegin;

	event EventHandler<RegisterCompleteEventArgs> RegisterComplete;

	event EventHandler<RollbackMsiTransactionBeginEventArgs> RollbackMsiTransactionBegin;

	event EventHandler<RollbackMsiTransactionCompleteEventArgs> RollbackMsiTransactionComplete;

	event EventHandler<ShutdownEventArgs> Shutdown;

	event EventHandler<StartupEventArgs> Startup;

	event EventHandler<SystemRestorePointBeginEventArgs> SystemRestorePointBegin;

	event EventHandler<SystemRestorePointCompleteEventArgs> SystemRestorePointComplete;

	event EventHandler<UnregisterBeginEventArgs> UnregisterBegin;

	event EventHandler<UnregisterCompleteEventArgs> UnregisterComplete;
}
public interface IEngine
{
	int PackageCount { get; }

	void Apply(IntPtr hwndParent);

	void CloseSplashScreen();

	int CompareVersions(string version1, string version2);

	bool ContainsVariable(string name);

	void Detect();

	void Detect(IntPtr hwndParent);

	bool Elevate(IntPtr hwndParent);

	string EscapeString(string input);

	bool EvaluateCondition(string condition);

	string FormatString(string format);

	long GetVariableNumeric(string name);

	SecureString GetVariableSecureString(string name);

	string GetVariableString(string name);

	string GetVariableVersion(string name);

	string GetRelatedBundleVariable(string bundleId, string name);

	void LaunchApprovedExe(IntPtr hwndParent, string approvedExeForElevationId, string arguments);

	void LaunchApprovedExe(IntPtr hwndParent, string approvedExeForElevationId, string arguments, int waitForInputIdleTimeout);

	void Log(LogLevel level, string message);

	void Plan(LaunchAction action);

	void SetUpdate(string localSource, string downloadSource, long size, UpdateHashType hashType, string hash, string updatePackageId);

	void SetUpdateSource(string url);

	void SetLocalSource(string packageOrContainerId, string payloadId, string path);

	void SetDownloadSource(string packageOrContainerId, string payloadId, string url, string user, string password);

	void SetVariableNumeric(string name, long value);

	void SetVariableString(string name, SecureString value, bool formatted);

	void SetVariableString(string name, string value, bool formatted);

	void SetVariableVersion(string name, string value);

	int SendEmbeddedError(int errorCode, string message, int uiHint);

	int SendEmbeddedProgress(int progressPercentage, int overallPercentage);

	void Quit(int exitCode);
}
public interface IMbaCommand
{
	Restart Restart { get; }

	string[] UnknownCommandLineArgs { get; }

	KeyValuePair<string, string>[] Variables { get; }

	void SetOverridableVariables(IOverridableVariables overridableVariables, IEngine engine);
}
public interface IOverridableVariableInfo
{
	string Name { get; }
}
public enum VariableCommandLineType
{
	CaseSensitive,
	CaseInsensitive
}
public interface IOverridableVariables
{
	VariableCommandLineType CommandLineType { get; }

	IDictionary<string, IOverridableVariableInfo> Variables { get; }
}
public interface IPackageInfo
{
	BOOTSTRAPPER_CACHE_TYPE CacheType { get; }

	object CustomData { get; set; }

	string Description { get; }

	string DisplayInternalUICondition { get; }

	string DisplayName { get; }

	string Id { get; }

	string InstallCondition { get; }

	string RepairCondition { get; }

	bool Permanent { get; }

	bool PrereqPackage { get; }

	string PrereqLicenseFile { get; }

	string PrereqLicenseUrl { get; }

	PrimaryPackageType PrimaryPackageType { get; }

	string ProductCode { get; }

	PackageType Type { get; }

	string UpgradeCode { get; }

	string Version { get; }

	bool Vital { get; }
}
public static class ManagedBootstrapperApplication
{
	public static void Run(IBootstrapperApplication application)
	{
		MbaNative.BootstrapperApplicationRun(application);
	}
}
internal sealed class MbaCommand : IMbaCommand
{
	public Restart Restart { get; internal set; }

	public string[] UnknownCommandLineArgs { get; internal set; }

	public KeyValuePair<string, string>[] Variables { get; internal set; }

	internal MbaCommand()
	{
	}

	public void SetOverridableVariables(IOverridableVariables overridableVariables, IEngine engine)
	{
		KeyValuePair<string, string>[] variables = Variables;
		for (int i = 0; i < variables.Length; i++)
		{
			KeyValuePair<string, string> keyValuePair = variables[i];
			string key = keyValuePair.Key;
			if (!overridableVariables.Variables.TryGetValue(key, out var value))
			{
				engine.Log(LogLevel.Error, $"Ignoring attempt to set non-overridable variable: '{key}'.");
			}
			else
			{
				engine.SetVariableString(value.Name, keyValuePair.Value, formatted: false);
			}
		}
	}
}
internal static class MbaNative
{
	[DllImport("mbanative.dll", ExactSpelling = true, PreserveSig = false)]
	internal static extern void BalDebuggerCheck();

	[DllImport("mbanative.dll", ExactSpelling = true, PreserveSig = false)]
	internal static extern void BootstrapperApplicationRun([MarshalAs(UnmanagedType.Interface)] IBootstrapperApplication pBA);
}
internal static class NativeMethods
{
	internal const int S_OK = 0;

	internal const int E_MOREDATA = -2147024662;

	internal const int E_INSUFFICIENT_BUFFER = -2147024774;

	internal const int E_CANCELLED = -2147023673;

	internal const int E_ALREADYINITIALIZED = -2147023649;

	internal const int E_NOTFOUND = -2147023728;

	internal const int E_NOTIMPL = -2147467263;

	internal const int E_UNEXPECTED = -2147418113;

	[DllImport("shell32.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

	[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
	internal static extern IntPtr LocalFree(IntPtr hMem);
}
internal abstract class SafeHandleZeroIsDefaultAndInvalid : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public SafeHandleZeroIsDefaultAndInvalid()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}
}
internal class OverridableVariableInfo : IOverridableVariableInfo
{
	public string Name { get; internal set; }

	internal OverridableVariableInfo()
	{
	}
}
public class OverridableVariablesInfo : IOverridableVariables
{
	public VariableCommandLineType CommandLineType { get; internal set; }

	public IDictionary<string, IOverridableVariableInfo> Variables { get; internal set; }

	internal OverridableVariablesInfo()
	{
	}

	public static IOverridableVariables ParseFromXml(XPathNavigator root)
	{
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(root.NameTable);
		xmlNamespaceManager.AddNamespace("p", "http://wixtoolset.org/schemas/v4/BootstrapperApplicationData");
		XPathNavigator xPathNavigator = root.SelectSingleNode("/p:BootstrapperApplicationData/p:WixStdbaCommandLine", xmlNamespaceManager);
		XPathNodeIterator xPathNodeIterator = root.Select("/p:BootstrapperApplicationData/p:WixStdbaOverridableVariable", xmlNamespaceManager);
		OverridableVariablesInfo overridableVariablesInfo = new OverridableVariablesInfo();
		IEqualityComparer<string> comparer;
		if (xPathNavigator == null)
		{
			overridableVariablesInfo.CommandLineType = VariableCommandLineType.CaseSensitive;
			comparer = StringComparer.InvariantCulture;
		}
		else
		{
			string attribute = BootstrapperApplicationData.GetAttribute(xPathNavigator, "Variables");
			if (attribute == null)
			{
				throw new Exception("Failed to get command line variable type.");
			}
			if (attribute.Equals("caseInsensitive", StringComparison.InvariantCulture))
			{
				overridableVariablesInfo.CommandLineType = VariableCommandLineType.CaseInsensitive;
				comparer = StringComparer.InvariantCultureIgnoreCase;
			}
			else
			{
				if (!attribute.Equals("caseSensitive", StringComparison.InvariantCulture))
				{
					throw new Exception($"Unknown command line variable type: '{attribute}'");
				}
				overridableVariablesInfo.CommandLineType = VariableCommandLineType.CaseSensitive;
				comparer = StringComparer.InvariantCulture;
			}
		}
		overridableVariablesInfo.Variables = new Dictionary<string, IOverridableVariableInfo>(comparer);
		foreach (XPathNavigator item in xPathNodeIterator)
		{
			OverridableVariableInfo overridableVariableInfo = new OverridableVariableInfo();
			string attribute2 = BootstrapperApplicationData.GetAttribute(item, "Name");
			if (attribute2 == null)
			{
				throw new Exception("Failed to get name for overridable variable.");
			}
			overridableVariableInfo.Name = attribute2;
			overridableVariablesInfo.Variables.Add(overridableVariableInfo.Name, overridableVariableInfo);
		}
		return overridableVariablesInfo;
	}
}
public enum PackageType
{
	Unknown,
	Exe,
	Msi,
	Msp,
	Msu,
	UpgradeBundle,
	AddonBundle,
	PatchBundle,
	UpdateBundle,
	ChainBundle
}
public enum PrimaryPackageType
{
	None,
	Default,
	X86,
	X64,
	ARM64
}
public class PackageInfo : IPackageInfo
{
	public string Id { get; internal set; }

	public string DisplayName { get; internal set; }

	public string Description { get; internal set; }

	public PackageType Type { get; internal set; }

	public bool Permanent { get; internal set; }

	public bool Vital { get; internal set; }

	public string DisplayInternalUICondition { get; internal set; }

	public string ProductCode { get; internal set; }

	public string UpgradeCode { get; internal set; }

	public string Version { get; internal set; }

	public string InstallCondition { get; internal set; }

	public string RepairCondition { get; internal set; }

	public BOOTSTRAPPER_CACHE_TYPE CacheType { get; internal set; }

	public bool PrereqPackage { get; internal set; }

	public string PrereqLicenseFile { get; internal set; }

	public string PrereqLicenseUrl { get; internal set; }

	public PrimaryPackageType PrimaryPackageType { get; internal set; }

	public object CustomData { get; set; }

	internal PackageInfo()
	{
	}

	public static IDictionary<string, IPackageInfo> ParsePackagesFromXml(XPathNavigator root)
	{
		Dictionary<string, IPackageInfo> dictionary = new Dictionary<string, IPackageInfo>();
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(root.NameTable);
		xmlNamespaceManager.AddNamespace("p", "http://wixtoolset.org/schemas/v4/BootstrapperApplicationData");
		foreach (XPathNavigator item in root.Select("/p:BootstrapperApplicationData/p:WixPackageProperties", xmlNamespaceManager))
		{
			PackageInfo packageInfo = new PackageInfo();
			string attribute = BootstrapperApplicationData.GetAttribute(item, "Package");
			if (attribute == null)
			{
				throw new Exception("Failed to get package identifier for package.");
			}
			packageInfo.Id = attribute;
			packageInfo.DisplayName = BootstrapperApplicationData.GetAttribute(item, "DisplayName");
			packageInfo.Description = BootstrapperApplicationData.GetAttribute(item, "Description");
			PackageType? packageTypeAttribute = GetPackageTypeAttribute(item, "PackageType");
			if (!packageTypeAttribute.HasValue)
			{
				throw new Exception("Failed to get package type for package.");
			}
			packageInfo.Type = packageTypeAttribute.Value;
			bool? yesNoAttribute = BootstrapperApplicationData.GetYesNoAttribute(item, "Permanent");
			if (!yesNoAttribute.HasValue)
			{
				throw new Exception("Failed to get permanent settings for package.");
			}
			packageInfo.Permanent = yesNoAttribute.Value;
			bool? yesNoAttribute2 = BootstrapperApplicationData.GetYesNoAttribute(item, "Vital");
			if (!yesNoAttribute2.HasValue)
			{
				throw new Exception("Failed to get vital setting for package.");
			}
			packageInfo.Vital = yesNoAttribute2.Value;
			packageInfo.ProductCode = BootstrapperApplicationData.GetAttribute(item, "ProductCode");
			packageInfo.UpgradeCode = BootstrapperApplicationData.GetAttribute(item, "UpgradeCode");
			packageInfo.Version = BootstrapperApplicationData.GetAttribute(item, "Version");
			packageInfo.InstallCondition = BootstrapperApplicationData.GetAttribute(item, "InstallCondition");
			packageInfo.RepairCondition = BootstrapperApplicationData.GetAttribute(item, "RepairCondition");
			BOOTSTRAPPER_CACHE_TYPE? cacheTypeAttribute = GetCacheTypeAttribute(item, "Cache");
			if (!cacheTypeAttribute.HasValue)
			{
				throw new Exception("Failed to get cache type for package.");
			}
			packageInfo.CacheType = cacheTypeAttribute.Value;
			dictionary.Add(packageInfo.Id, packageInfo);
		}
		ParseBalPackageInfoFromXml(root, xmlNamespaceManager, dictionary);
		return dictionary;
	}

	public static BOOTSTRAPPER_CACHE_TYPE? GetCacheTypeAttribute(XPathNavigator node, string attributeName)
	{
		string attribute = BootstrapperApplicationData.GetAttribute(node, attributeName);
		if (attribute == null)
		{
			return null;
		}
		if (attribute.Equals("keep", StringComparison.InvariantCulture))
		{
			return BOOTSTRAPPER_CACHE_TYPE.Keep;
		}
		if (attribute.Equals("force", StringComparison.InvariantCulture))
		{
			return BOOTSTRAPPER_CACHE_TYPE.Force;
		}
		return BOOTSTRAPPER_CACHE_TYPE.Remove;
	}

	public static PackageType? GetPackageTypeAttribute(XPathNavigator node, string attributeName)
	{
		string attribute = BootstrapperApplicationData.GetAttribute(node, attributeName);
		if (attribute == null)
		{
			return null;
		}
		if (attribute.Equals("Bundle", StringComparison.InvariantCulture))
		{
			return PackageType.ChainBundle;
		}
		if (attribute.Equals("Exe", StringComparison.InvariantCulture))
		{
			return PackageType.Exe;
		}
		if (attribute.Equals("Msi", StringComparison.InvariantCulture))
		{
			return PackageType.Msi;
		}
		if (attribute.Equals("Msp", StringComparison.InvariantCulture))
		{
			return PackageType.Msp;
		}
		if (attribute.Equals("Msu", StringComparison.InvariantCulture))
		{
			return PackageType.Msu;
		}
		return PackageType.Unknown;
	}

	public static IPackageInfo GetRelatedBundleAsPackage(string id, RelationType relationType, bool perMachine, string version)
	{
		PackageInfo packageInfo = new PackageInfo();
		packageInfo.Id = id;
		packageInfo.Version = version;
		switch (relationType)
		{
		case RelationType.Addon:
			packageInfo.Type = PackageType.AddonBundle;
			break;
		case RelationType.Patch:
			packageInfo.Type = PackageType.PatchBundle;
			break;
		case RelationType.Upgrade:
			packageInfo.Type = PackageType.UpgradeBundle;
			break;
		default:
			throw new Exception($"Unknown related bundle type: {relationType}");
		}
		return packageInfo;
	}

	public static IPackageInfo GetUpdateBundleAsPackage(string id)
	{
		return new PackageInfo
		{
			Id = id,
			Type = PackageType.UpdateBundle
		};
	}

	internal static void ParseBalPackageInfoFromXml(XPathNavigator root, XmlNamespaceManager namespaceManager, Dictionary<string, IPackageInfo> packagesById)
	{
		foreach (XPathNavigator item in root.Select("/p:BootstrapperApplicationData/p:WixBalPackageInfo", namespaceManager))
		{
			string attribute = BootstrapperApplicationData.GetAttribute(item, "PackageId");
			if (attribute == null)
			{
				throw new Exception("Failed to get package identifier for WixBalPackageInfo.");
			}
			if (!packagesById.TryGetValue(attribute, out var value))
			{
				throw new Exception($"Failed to find package specified in WixBalPackageInfo: {attribute}");
			}
			((PackageInfo)value).DisplayInternalUICondition = BootstrapperApplicationData.GetAttribute(item, "DisplayInternalUICondition");
		}
		foreach (XPathNavigator item2 in root.Select("/p:BootstrapperApplicationData/p:WixPrereqInformation", namespaceManager))
		{
			string attribute2 = BootstrapperApplicationData.GetAttribute(item2, "PackageId");
			if (attribute2 == null)
			{
				throw new Exception("Failed to get package identifier for WixPrereqInformation.");
			}
			if (!packagesById.TryGetValue(attribute2, out var value2))
			{
				throw new Exception($"Failed to find package specified in WixPrereqInformation: {attribute2}");
			}
			PackageInfo packageInfo = (PackageInfo)value2;
			packageInfo.PrereqPackage = true;
			packageInfo.PrereqLicenseFile = BootstrapperApplicationData.GetAttribute(item2, "LicenseFile");
			packageInfo.PrereqLicenseUrl = BootstrapperApplicationData.GetAttribute(item2, "LicenseUrl");
		}
	}
}
internal static class StrUtil
{
	internal sealed class StrHandle : SafeHandleZeroIsDefaultAndInvalid
	{
		protected override bool ReleaseHandle()
		{
			StrFree(handle);
			return true;
		}

		public string ToUniString()
		{
			return Marshal.PtrToStringUni(handle);
		}

		public SecureString ToSecureString()
		{
			if (handle == IntPtr.Zero)
			{
				return null;
			}
			SecureString secureString = new SecureString();
			int num = 0;
			while (true)
			{
				char c = (char)checked((ushort)Marshal.ReadInt16(handle, num * 2));
				if (c == '\0')
				{
					break;
				}
				secureString.AppendChar(c);
				num = checked(num + 1);
			}
			return secureString;
		}
	}

	[DllImport("mbanative.dll", ExactSpelling = true)]
	internal static extern void StrFree(IntPtr scz);
}
public static class VerUtil
{
	internal struct VersionReleaseLabelStruct
	{
		public bool fNumeric;

		public uint dwValue;

		public IntPtr cchLabelOffset;

		public int cchLabel;
	}

	internal struct VersionStruct
	{
		public IntPtr sczVersion;

		public char chPrefix;

		public uint dwMajor;

		public uint dwMinor;

		public uint dwPatch;

		public uint dwRevision;

		public int cReleaseLabels;

		public IntPtr rgReleaseLabels;

		public IntPtr cchMetadataOffset;

		public bool fInvalid;

		public bool fHasMajor;

		public bool fHasMinor;

		public bool fHasPatch;

		public bool fHasRevision;
	}

	internal sealed class VersionHandle : SafeHandleZeroIsDefaultAndInvalid
	{
		protected override bool ReleaseHandle()
		{
			VerFreeVersion(handle);
			return true;
		}
	}

	[DllImport("mbanative.dll", ExactSpelling = true, PreserveSig = false)]
	internal static extern int VerCompareParsedVersions(VersionHandle pVersion1, VersionHandle pVersion2);

	[DllImport("mbanative.dll", ExactSpelling = true, PreserveSig = false)]
	internal static extern int VerCompareStringVersions([MarshalAs(UnmanagedType.LPWStr)] string wzVersion1, [MarshalAs(UnmanagedType.LPWStr)] string wzVersion2, [MarshalAs(UnmanagedType.Bool)] bool fStrict);

	[DllImport("mbanative.dll", ExactSpelling = true, PreserveSig = false)]
	internal static extern VersionHandle VerCopyVersion(VersionHandle pSource);

	[DllImport("mbanative.dll", ExactSpelling = true)]
	internal static extern void VerFreeVersion(IntPtr pVersion);

	[DllImport("mbanative.dll", ExactSpelling = true, PreserveSig = false)]
	internal static extern VersionHandle VerParseVersion([MarshalAs(UnmanagedType.LPWStr)] string wzVersion, [MarshalAs(UnmanagedType.U4)] uint cchValue, [MarshalAs(UnmanagedType.Bool)] bool fStrict);

	[DllImport("mbanative.dll", ExactSpelling = true, PreserveSig = false)]
	internal static extern VersionHandle VerVersionFromQword([MarshalAs(UnmanagedType.I8)] long qwVersion);

	internal static string VersionStringFromOffset(IntPtr wzVersion, IntPtr cchOffset, int? cchLength = null)
	{
		checked
		{
			long num = cchOffset.ToInt64() * 2;
			IntPtr ptr = new IntPtr(wzVersion.ToInt64() + num);
			if (cchLength.HasValue)
			{
				return Marshal.PtrToStringUni(ptr, cchLength.Value);
			}
			return Marshal.PtrToStringUni(ptr);
		}
	}

	public static int CompareParsedVersions(VerUtilVersion version1, VerUtilVersion version2)
	{
		return VerCompareParsedVersions(version1.GetHandle(), version2.GetHandle());
	}

	public static int CompareStringVersions(string version1, string version2, bool strict)
	{
		return VerCompareStringVersions(version1, version2, strict);
	}

	public static VerUtilVersion CopyVersion(VerUtilVersion version)
	{
		return new VerUtilVersion(VerCopyVersion(version.GetHandle()));
	}

	public static VerUtilVersion ParseVersion(string version, bool strict)
	{
		return new VerUtilVersion(VerParseVersion(version, 0u, strict));
	}

	public static VerUtilVersion VersionFromQword(long version)
	{
		return new VerUtilVersion(VerVersionFromQword(version));
	}
}
public sealed class VerUtilVersion : IDisposable
{
	public string Version { get; private set; }

	public char Prefix { get; private set; }

	public uint Major { get; private set; }

	public uint Minor { get; private set; }

	public uint Patch { get; private set; }

	public uint Revision { get; private set; }

	public VerUtilVersionReleaseLabel[] ReleaseLabels { get; private set; }

	public string Metadata { get; private set; }

	public bool IsInvalid { get; private set; }

	public bool HasMajor { get; private set; }

	public bool HasMinor { get; private set; }

	public bool HasPatch { get; private set; }

	public bool HasRevision { get; private set; }

	private VerUtil.VersionHandle Handle { get; set; }

	internal VerUtilVersion(VerUtil.VersionHandle handle)
	{
		Handle = handle;
		VerUtil.VersionStruct versionStruct = (VerUtil.VersionStruct)Marshal.PtrToStructure(handle.DangerousGetHandle(), typeof(VerUtil.VersionStruct));
		Version = Marshal.PtrToStringUni(versionStruct.sczVersion);
		Prefix = versionStruct.chPrefix;
		Major = versionStruct.dwMajor;
		Minor = versionStruct.dwMinor;
		Patch = versionStruct.dwPatch;
		Revision = versionStruct.dwRevision;
		ReleaseLabels = new VerUtilVersionReleaseLabel[versionStruct.cReleaseLabels];
		Metadata = VerUtil.VersionStringFromOffset(versionStruct.sczVersion, versionStruct.cchMetadataOffset);
		IsInvalid = versionStruct.fInvalid;
		HasMajor = versionStruct.fHasMajor;
		HasMinor = versionStruct.fHasMinor;
		HasPatch = versionStruct.fHasPatch;
		HasRevision = versionStruct.fHasRevision;
		checked
		{
			for (int i = 0; i < versionStruct.cReleaseLabels; i++)
			{
				int num = i * Marshal.SizeOf(typeof(VerUtil.VersionReleaseLabelStruct));
				IntPtr pReleaseLabel = new IntPtr(versionStruct.rgReleaseLabels.ToInt64() + num);
				ReleaseLabels[i] = new VerUtilVersionReleaseLabel(pReleaseLabel, versionStruct.sczVersion);
			}
		}
	}

	public void Dispose()
	{
		if (Handle != null)
		{
			Handle.Dispose();
			Handle = null;
		}
	}

	internal VerUtil.VersionHandle GetHandle()
	{
		if (Handle == null)
		{
			throw new ObjectDisposedException(Version);
		}
		return Handle;
	}
}
public sealed class VerUtilVersionReleaseLabel
{
	public bool IsNumeric { get; private set; }

	public uint Value { get; private set; }

	public string Label { get; private set; }

	internal VerUtilVersionReleaseLabel(IntPtr pReleaseLabel, IntPtr wzVersion)
	{
		VerUtil.VersionReleaseLabelStruct versionReleaseLabelStruct = (VerUtil.VersionReleaseLabelStruct)Marshal.PtrToStructure(pReleaseLabel, typeof(VerUtil.VersionReleaseLabelStruct));
		IsNumeric = versionReleaseLabelStruct.fNumeric;
		Value = versionReleaseLabelStruct.dwValue;
		Label = VerUtil.VersionStringFromOffset(wzVersion, versionReleaseLabelStruct.cchLabelOffset, versionReleaseLabelStruct.cchLabel);
	}
}
