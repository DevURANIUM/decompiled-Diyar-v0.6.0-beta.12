using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Betalgo.Ranul.OpenAI.ObjectModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RealtimeModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels;
using Betalgo.Ranul.OpenAI.ObjectModels.SharedModels;
using Microsoft.AI.Foundry.Local.Detail;
using Microsoft.AI.Foundry.Local.OpenAI;
using Microsoft.Extensions.Logging;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.AI.Foundry.Local.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: TargetFramework(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Microsoft Foundry Local SDK")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0+d7a9bdd1f66a303579adfa80b0c8dffb0c5cb59f")]
[assembly: AssemblyProduct("Microsoft.AI.Foundry.Local")]
[assembly: AssemblyTitle("Microsoft AI Foundry Local")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/microsoft/Foundry-Local")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: TypeForwardedTo(typeof(IsExternalInit))]
[assembly: TypeForwardedTo(typeof(RequiresLocationAttribute))]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]
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
namespace System.Runtime.CompilerServices
{
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class OverloadResolutionPriorityAttribute : Attribute
	{
		public int Priority { get; }

		public OverloadResolutionPriorityAttribute(int priority)
		{
			Priority = priority;
		}
	}
	[AttributeUsage(AttributeTargets.Parameter, Inherited = true, AllowMultiple = false)]
	[ExcludeFromCodeCoverage]
	internal sealed class ParamCollectionAttribute : Attribute
	{
	}
}
namespace Microsoft.AI.Foundry.Local
{
	internal sealed class Catalog : ICatalog, IDisposable
	{
		private readonly Dictionary<string, Model> _modelAliasToModel = new Dictionary<string, Model>();

		private readonly Dictionary<string, ModelVariant> _modelIdToModelVariant = new Dictionary<string, ModelVariant>();

		private DateTime _lastFetch;

		private readonly IModelLoadManager _modelLoadManager;

		private readonly ICoreInterop _coreInterop;

		private readonly ILogger _logger;

		private readonly AsyncLock _lock = new AsyncLock();

		public string Name { get; init; }

		private Catalog(IModelLoadManager modelLoadManager, ICoreInterop coreInterop, ILogger logger)
		{
			_modelLoadManager = modelLoadManager;
			_coreInterop = coreInterop;
			_logger = logger;
			_lastFetch = DateTime.MinValue;
			CoreInteropRequest commandInput = null;
			ICoreInterop.Response response = coreInterop.ExecuteCommand("get_catalog_name", commandInput);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error getting catalog name: " + response.Error, _logger);
			}
			Name = response.Data;
		}

		internal static async Task<Catalog> CreateAsync(IModelLoadManager modelManager, ICoreInterop coreInterop, ILogger logger, CancellationToken? ct = null)
		{
			Catalog catalog = new Catalog(modelManager, coreInterop, logger);
			await catalog.UpdateModels(ct).ConfigureAwait(continueOnCapturedContext: false);
			return catalog;
		}

		public async Task<List<IModel>> ListModelsAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => ListModelsImplAsync(ct), "Error listing models.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<IModel>> GetCachedModelsAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetCachedModelsImplAsync(ct), "Error getting cached models.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<List<IModel>> GetLoadedModelsAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetLoadedModelsImplAsync(ct), "Error getting loaded models.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IModel?> GetModelAsync(string modelAlias, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetModelImplAsync(modelAlias, ct), "Error getting model with alias '" + modelAlias + "'.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IModel?> GetModelVariantAsync(string modelId, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetModelVariantImplAsync(modelId, ct), "Error getting model variant with ID '" + modelId + "'.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IModel> GetLatestVersionAsync(IModel modelOrModelVariant, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetLatestVersionImplAsync(modelOrModelVariant, ct), "Error getting latest version for model with name '" + modelOrModelVariant.Info.Name + "'.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<List<IModel>> ListModelsImplAsync(CancellationToken? ct = null)
		{
			await UpdateModels(ct).ConfigureAwait(continueOnCapturedContext: false);
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				return _modelAliasToModel.Values.OrderBy((Model m) => m.Alias).Cast<IModel>().ToList();
			}
		}

		private async Task<List<IModel>> GetCachedModelsImplAsync(CancellationToken? ct = null)
		{
			await UpdateModels(ct).ConfigureAwait(continueOnCapturedContext: false);
			return await ResolveModelIdsAsync(await Utils.GetCachedModelIdsAsync(_coreInterop, ct).ConfigureAwait(continueOnCapturedContext: false), ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<List<IModel>> GetLoadedModelsImplAsync(CancellationToken? ct = null)
		{
			await UpdateModels(ct).ConfigureAwait(continueOnCapturedContext: false);
			return await ResolveModelIdsAsync(await _modelLoadManager.ListLoadedModelsAsync(ct).ConfigureAwait(continueOnCapturedContext: false), ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<List<IModel>> ResolveModelIdsAsync(string[] modelIds, CancellationToken? ct)
		{
			bool needsRefresh = false;
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				string[] array = modelIds;
				foreach (string key in array)
				{
					if (!_modelIdToModelVariant.ContainsKey(key))
					{
						needsRefresh = true;
						break;
					}
				}
			}
			if (needsRefresh)
			{
				await UpdateModels(ct, force: true).ConfigureAwait(continueOnCapturedContext: false);
			}
			List<IModel> resolved = new List<IModel>(modelIds.Length);
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				string[] array = modelIds;
				foreach (string key2 in array)
				{
					if (_modelIdToModelVariant.TryGetValue(key2, out ModelVariant value))
					{
						resolved.Add(value);
					}
				}
				return resolved;
			}
		}

		private async Task<Model?> GetModelImplAsync(string modelAlias, CancellationToken? ct = null)
		{
			if (string.IsNullOrWhiteSpace(modelAlias))
			{
				return null;
			}
			await UpdateModels(ct).ConfigureAwait(continueOnCapturedContext: false);
			Model value;
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				_modelAliasToModel.TryGetValue(modelAlias, out value);
			}
			if (value != null)
			{
				return value;
			}
			await UpdateModels(ct, force: true).ConfigureAwait(continueOnCapturedContext: false);
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				_modelAliasToModel.TryGetValue(modelAlias, out value);
			}
			return value;
		}

		private async Task<ModelVariant?> GetModelVariantImplAsync(string modelId, CancellationToken? ct = null)
		{
			if (string.IsNullOrWhiteSpace(modelId))
			{
				return null;
			}
			await UpdateModels(ct).ConfigureAwait(continueOnCapturedContext: false);
			ModelVariant value;
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				_modelIdToModelVariant.TryGetValue(modelId, out value);
			}
			if (value != null)
			{
				return value;
			}
			await UpdateModels(ct, force: true).ConfigureAwait(continueOnCapturedContext: false);
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				_modelIdToModelVariant.TryGetValue(modelId, out value);
			}
			return value;
		}

		private async Task<IModel> GetLatestVersionImplAsync(IModel modelOrModelVariant, CancellationToken? ct)
		{
			Model model;
			if (modelOrModelVariant is ModelVariant)
			{
				model = await GetModelImplAsync(modelOrModelVariant.Alias, ct);
			}
			else
			{
				model = modelOrModelVariant as Model;
				if (model == null)
				{
					model = await GetModelImplAsync(modelOrModelVariant.Alias, ct);
				}
			}
			if (model == null)
			{
				throw new FoundryLocalException("Model with alias '" + modelOrModelVariant.Alias + "' not found in catalog.", _logger);
			}
			IModel model2 = model.Variants.FirstOrDefault((IModel v) => v.Info.Name == modelOrModelVariant.Info.Name) ?? throw new FoundryLocalException($"Internal error. Mismatch between model (alias:{model.Alias}) and model variant (alias:{modelOrModelVariant.Alias}).", _logger);
			return (model2.Id == modelOrModelVariant.Id) ? modelOrModelVariant : model2;
		}

		private async Task UpdateModels(CancellationToken? ct, bool force = false)
		{
			if (!force && DateTime.Now - _lastFetch < TimeSpan.FromHours(6.0))
			{
				return;
			}
			CoreInteropRequest commandInput = null;
			ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("get_model_list", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error getting models: " + response.Error, _logger);
			}
			List<ModelInfo> models = JsonSerializer.Deserialize(response.Data, JsonSerializationContext.Default.ListModelInfo);
			if (models == null)
			{
				_logger.LogDebug("ListModelInfo deserialization error in UpdateModels. Data: " + response.Data);
				throw new FoundryLocalException("Failed to deserialize models from response.", _logger);
			}
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				HashSet<string> freshIds = new HashSet<string>(StringComparer.Ordinal);
				Dictionary<string, List<ModelInfo>> freshAliasGroups = new Dictionary<string, List<ModelInfo>>(StringComparer.Ordinal);
				foreach (ModelInfo item in models)
				{
					freshIds.Add(item.Id);
					if (!freshAliasGroups.TryGetValue(item.Alias, out List<ModelInfo> value))
					{
						value = new List<ModelInfo>();
						freshAliasGroups[item.Alias] = value;
					}
					value.Add(item);
				}
				foreach (string item2 in _modelIdToModelVariant.Keys.Where((string id) => !freshIds.Contains(id)).ToList())
				{
					_modelIdToModelVariant.Remove(item2);
				}
				foreach (string item3 in _modelAliasToModel.Keys.Where((string a) => !freshAliasGroups.ContainsKey(a)).ToList())
				{
					_modelAliasToModel.Remove(item3);
				}
				foreach (ModelInfo item4 in models)
				{
					if (_modelIdToModelVariant.TryGetValue(item4.Id, out ModelVariant value2))
					{
						value2.RefreshInfo(item4);
					}
					else
					{
						_modelIdToModelVariant[item4.Id] = new ModelVariant(item4, _modelLoadManager, _coreInterop, _logger);
					}
				}
				foreach (KeyValuePair<string, List<ModelInfo>> item5 in freshAliasGroups)
				{
					string key = item5.Key;
					List<ModelVariant> list = item5.Value.ConvertAll((ModelInfo i) => _modelIdToModelVariant[i.Id]);
					if (_modelAliasToModel.TryGetValue(key, out Model value3))
					{
						value3.RefreshVariants(list);
						continue;
					}
					Model model = new Model(list[0], _logger);
					for (int num = 1; num < list.Count; num++)
					{
						model.AddVariant(list[num]);
					}
					_modelAliasToModel[key] = model;
				}
				_lastFetch = DateTime.Now;
			}
		}

		internal void InvalidateCache()
		{
			_lastFetch = DateTime.MinValue;
		}

		public void Dispose()
		{
			_lock.Dispose();
		}
	}
	public class Configuration
	{
		public class WebService
		{
			public string? Urls { get; init; }

			public Uri? ExternalUrl { get; init; }
		}

		public required string AppName { get; set; }

		public string? AppDataDir { get; init; }

		public string? ModelCacheDir { get; init; }

		public string? LogsDir { get; init; }

		public LogLevel LogLevel { get; init; } = LogLevel.Warning;

		public WebService? Web { get; init; }

		public IDictionary<string, string>? AdditionalSettings { get; init; }

		internal void Validate()
		{
			if (string.IsNullOrEmpty(AppName))
			{
				throw new ArgumentException("Configuration AppName must be set to a valid application name.");
			}
			if (AppName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
			{
				throw new ArgumentException("Configuration AppName value contains invalid characters.");
			}
			WebService? web = Web;
			if (web != null && web.ExternalUrl?.Port == 0)
			{
				throw new ArgumentException("Configuration Web.ExternalUrl has invalid port of 0.");
			}
		}

		internal Dictionary<string, string> AsDictionary()
		{
			if (string.IsNullOrEmpty(AppName))
			{
				throw new FoundryLocalException("Configuration AppName must be set to a valid application name.");
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				{ "AppName", AppName },
				{
					"LogLevel",
					LogLevel.ToString()
				}
			};
			if (!string.IsNullOrEmpty(AppDataDir))
			{
				dictionary.Add("AppDataDir", AppDataDir);
			}
			if (!string.IsNullOrEmpty(ModelCacheDir))
			{
				dictionary.Add("ModelCacheDir", ModelCacheDir);
			}
			if (!string.IsNullOrEmpty(LogsDir))
			{
				dictionary.Add("LogsDir", LogsDir);
			}
			if (Web != null && Web.Urls != null)
			{
				dictionary["WebServiceUrls"] = Web.Urls;
			}
			if (AdditionalSettings != null)
			{
				foreach (KeyValuePair<string, string> additionalSetting in AdditionalSettings)
				{
					if (!string.IsNullOrEmpty(additionalSetting.Key))
					{
						dictionary[additionalSetting.Key] = additionalSetting.Value ?? string.Empty;
					}
				}
			}
			return dictionary;
		}
	}
	public class Model : IModel
	{
		private readonly ILogger _logger;

		private List<IModel> _variants;

		public IReadOnlyList<IModel> Variants => _variants;

		internal IModel SelectedVariant { get; set; }

		public string Alias { get; init; }

		public string Id => SelectedVariant.Id;

		public ModelInfo Info => SelectedVariant.Info;

		public Task<bool> IsCachedAsync(CancellationToken? ct = null)
		{
			return SelectedVariant.IsCachedAsync(ct);
		}

		public Task<bool> IsLoadedAsync(CancellationToken? ct = null)
		{
			return SelectedVariant.IsLoadedAsync(ct);
		}

		internal Model(ModelVariant modelVariant, ILogger logger)
		{
			_logger = logger;
			Alias = modelVariant.Alias;
			int num = 1;
			List<IModel> list = new List<IModel>(num);
			CollectionsMarshal.SetCount(list, num);
			CollectionsMarshal.AsSpan(list)[0] = modelVariant;
			_variants = list;
			SelectedVariant = modelVariant;
		}

		internal void AddVariant(ModelVariant variant)
		{
			if (Alias != variant.Alias)
			{
				throw new FoundryLocalException("Variant alias " + variant.Alias + " does not match model alias " + Alias, _logger);
			}
			List<IModel> variants = _variants;
			int num = 1 + variants.Count;
			List<IModel> list = new List<IModel>(num);
			CollectionsMarshal.SetCount(list, num);
			Span<IModel> span = CollectionsMarshal.AsSpan(list);
			int num2 = 0;
			Span<IModel> span2 = CollectionsMarshal.AsSpan(variants);
			span2.CopyTo(span.Slice(num2, span2.Length));
			num2 += span2.Length;
			span[num2] = variant;
			_variants = list;
			if (variant.Info.Cached && !SelectedVariant.Info.Cached)
			{
				SelectedVariant = variant;
			}
		}

		internal void RefreshVariants(IList<ModelVariant> variants)
		{
			if (variants == null || variants.Count == 0)
			{
				throw new FoundryLocalException("Cannot refresh model " + Alias + " with an empty variant list", _logger);
			}
			_variants = ((IEnumerable<IModel>)variants).ToList();
		}

		public void SelectVariant(IModel variant)
		{
			if (Variants.FirstOrDefault((IModel v) => v == variant) == null)
			{
				throw new FoundryLocalException("Input variant was not found in Variants.");
			}
			SelectedVariant = variant;
		}

		public async Task<string> GetPathAsync(CancellationToken? ct = null)
		{
			return await SelectedVariant.GetPathAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task DownloadAsync(Action<float>? downloadProgress = null, CancellationToken? ct = null)
		{
			await SelectedVariant.DownloadAsync(downloadProgress, ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task LoadAsync(CancellationToken? ct = null)
		{
			await SelectedVariant.LoadAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OpenAIChatClient> GetChatClientAsync(CancellationToken? ct = null)
		{
			return await SelectedVariant.GetChatClientAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OpenAIAudioClient> GetAudioClientAsync(CancellationToken? ct = null)
		{
			return await SelectedVariant.GetAudioClientAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OpenAIEmbeddingClient> GetEmbeddingClientAsync(CancellationToken? ct = null)
		{
			return await SelectedVariant.GetEmbeddingClientAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task UnloadAsync(CancellationToken? ct = null)
		{
			await SelectedVariant.UnloadAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task RemoveFromCacheAsync(CancellationToken? ct = null)
		{
			await SelectedVariant.RemoveFromCacheAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	internal class ModelVariant : IModel
	{
		private readonly IModelLoadManager _modelLoadManager;

		private readonly ICoreInterop _coreInterop;

		private readonly ILogger _logger;

		public ModelInfo Info { get; private set; }

		public string Id => Info.Id;

		public string Alias => Info.Alias;

		public int Version { get; private set; }

		public IReadOnlyList<IModel> Variants => new <>z__ReadOnlySingleElementList<IModel>(this);

		internal ModelVariant(ModelInfo modelInfo, IModelLoadManager modelLoadManager, ICoreInterop coreInterop, ILogger logger)
		{
			Info = modelInfo;
			Version = modelInfo.Version;
			_modelLoadManager = modelLoadManager;
			_coreInterop = coreInterop;
			_logger = logger;
		}

		internal void RefreshInfo(ModelInfo modelInfo)
		{
			Info = modelInfo;
			Version = modelInfo.Version;
		}

		public async Task<bool> IsLoadedAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => IsLoadedImplAsync(ct), "Error checking if model is loaded", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<bool> IsCachedAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => IsCachedImplAsync(ct), "Error checking if model is cached", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<string> GetPathAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetPathImplAsync(ct), "Error getting path for model", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task DownloadAsync(Action<float>? downloadProgress = null, CancellationToken? ct = null)
		{
			await Utils.CallWithExceptionHandling(() => DownloadImplAsync(downloadProgress, ct), "Error downloading model " + Id, _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task LoadAsync(CancellationToken? ct = null)
		{
			await Utils.CallWithExceptionHandling(() => _modelLoadManager.LoadAsync(Id, ct), "Error loading model", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task UnloadAsync(CancellationToken? ct = null)
		{
			await Utils.CallWithExceptionHandling(() => _modelLoadManager.UnloadAsync(Id, ct), "Error unloading model", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task RemoveFromCacheAsync(CancellationToken? ct = null)
		{
			await Utils.CallWithExceptionHandling(() => RemoveFromCacheImplAsync(ct), "Error removing model " + Id + " from cache", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OpenAIChatClient> GetChatClientAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetChatClientImplAsync(ct), "Error getting chat client for model", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OpenAIAudioClient> GetAudioClientAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetAudioClientImplAsync(ct), "Error getting audio client for model", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<OpenAIEmbeddingClient> GetEmbeddingClientAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetEmbeddingClientImplAsync(ct), "Error getting embedding client for model", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<bool> IsLoadedImplAsync(CancellationToken? ct = null)
		{
			return (await _modelLoadManager.ListLoadedModelsAsync(ct).ConfigureAwait(continueOnCapturedContext: false)).Contains(Id);
		}

		private async Task<bool> IsCachedImplAsync(CancellationToken? ct = null)
		{
			return (await Utils.GetCachedModelIdsAsync(_coreInterop, ct).ConfigureAwait(continueOnCapturedContext: false)).Contains(Id);
		}

		private async Task<string> GetPathImplAsync(CancellationToken? ct = null)
		{
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "Model", Id } }
			};
			ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("get_model_path", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException($"Error getting path for model {Id}: {response.Error}. Has it been downloaded?");
			}
			return response.Data;
		}

		private async Task DownloadImplAsync(Action<float>? downloadProgress = null, CancellationToken? ct = null)
		{
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "Model", Id } }
			};
			ICoreInterop.Response response;
			if (downloadProgress != null || (ct?.CanBeCanceled ?? false))
			{
				ICoreInterop.CallbackFn callback = (string progressString) =>
				{
					if (ct.HasValue)
					{
						ct.GetValueOrDefault().ThrowIfCancellationRequested();
					}
					if (downloadProgress != null && float.TryParse(progressString, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
					{
						downloadProgress(result);
					}
				};
				response = await _coreInterop.ExecuteCommandWithCallbackAsync("download_model", commandInput, callback, ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				response = await _coreInterop.ExecuteCommandAsync("download_model", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error downloading model " + Id + ": " + response.Error);
			}
		}

		private async Task RemoveFromCacheImplAsync(CancellationToken? ct = null)
		{
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "Model", Id } }
			};
			ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("remove_cached_model", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error removing model " + Id + " from cache: " + response.Error);
			}
		}

		private async Task<OpenAIChatClient> GetChatClientImplAsync(CancellationToken? ct = null)
		{
			if (!(await IsLoadedAsync(ct)))
			{
				throw new FoundryLocalException("Model " + Id + " is not loaded. Call LoadAsync first.");
			}
			return new OpenAIChatClient(Id);
		}

		private async Task<OpenAIAudioClient> GetAudioClientImplAsync(CancellationToken? ct = null)
		{
			if (!(await IsLoadedAsync(ct)))
			{
				throw new FoundryLocalException("Model " + Id + " is not loaded. Call LoadAsync first.");
			}
			return new OpenAIAudioClient(Id);
		}

		private async Task<OpenAIEmbeddingClient> GetEmbeddingClientImplAsync(CancellationToken? ct = null)
		{
			if (!(await IsLoadedAsync(ct)))
			{
				throw new FoundryLocalException("Model " + Id + " is not loaded. Call LoadAsync first.");
			}
			return new OpenAIEmbeddingClient(Id);
		}

		public void SelectVariant(IModel variant)
		{
			throw new FoundryLocalException("SelectVariant is not supported on a ModelVariant. Call Catalog.GetModelAsync(\"" + Alias + "\") to get an IModel with all variants available.");
		}
	}
	public record EpInfo
	{
		[JsonPropertyName("Name")]
		public required string Name { get; init; }

		[JsonPropertyName("IsRegistered")]
		public required bool IsRegistered { get; init; }
	}
	public record EpDownloadResult
	{
		[JsonPropertyName("Success")]
		public required bool Success { get; init; }

		[JsonPropertyName("Status")]
		public required string Status { get; init; }

		[JsonPropertyName("RegisteredEps")]
		public required string[] RegisteredEps { get; init; }

		[JsonPropertyName("FailedEps")]
		public required string[] FailedEps { get; init; }
	}
	public class FoundryLocalException : Exception
	{
		public FoundryLocalException(string message)
			: base(message)
		{
		}

		public FoundryLocalException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		internal FoundryLocalException(string message, ILogger logger)
			: base(message)
		{
			logger.LogError(message);
		}

		internal FoundryLocalException(string message, Exception innerException, ILogger logger)
			: base(message, innerException)
		{
			logger.LogError(innerException, message);
		}
	}
	public class FoundryLocalManager : IDisposable
	{
		private static FoundryLocalManager? instance;

		private static readonly AsyncLock asyncLock = new AsyncLock();

		internal static readonly string AssemblyVersion = typeof(FoundryLocalManager).Assembly.GetName().Version?.ToString() ?? "unknown";

		private readonly Configuration _config;

		private CoreInterop _coreInterop;

		private Catalog _catalog;

		private ModelLoadManager _modelManager;

		private readonly AsyncLock _lock = new AsyncLock();

		private bool _disposed;

		private readonly ILogger _logger;

		internal Configuration Configuration => _config;

		internal ILogger Logger => _logger;

		internal ICoreInterop CoreInterop => _coreInterop;

		public static bool IsInitialized => instance != null;

		public static FoundryLocalManager Instance => instance ?? throw new FoundryLocalException("FoundryLocalManager has not been created. Call CreateAsync first.");

		public string[]? Urls { get; private set; }

		public static async Task CreateAsync(Configuration configuration, ILogger logger, CancellationToken? ct = null)
		{
			using (await asyncLock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				if (instance != null)
				{
					throw new FoundryLocalException("FoundryLocalManager has already been created.", logger);
				}
				FoundryLocalManager manager = null;
				try
				{
					manager = new FoundryLocalManager(configuration, logger);
					await manager.InitializeAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
					instance = manager;
					manager = null;
				}
				catch (Exception ex)
				{
					manager?.Dispose();
					if ((ex is FoundryLocalException || ex is OperationCanceledException) ? true : false)
					{
						throw;
					}
					throw new FoundryLocalException("Error during initialization.", ex, logger);
				}
			}
		}

		public async Task<ICatalog> GetCatalogAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GetCatalogImplAsync(ct), "Error getting Catalog.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task StartWebServiceAsync(CancellationToken? ct = null)
		{
			await Utils.CallWithExceptionHandling(() => StartWebServiceImplAsync(ct), "Error starting web service.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task StopWebServiceAsync(CancellationToken? ct = null)
		{
			await Utils.CallWithExceptionHandling(() => StopWebServiceImplAsync(ct), "Error stopping web service.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public EpInfo[] DiscoverEps()
		{
			return Utils.CallWithExceptionHandling(DiscoverEpsImpl, "Error discovering execution providers.", _logger);
		}

		public async Task<EpDownloadResult> DownloadAndRegisterEpsAsync(CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => DownloadAndRegisterEpsImplAsync(null, null, ct), "Error downloading execution providers.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<EpDownloadResult> DownloadAndRegisterEpsAsync(IEnumerable<string> names, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => DownloadAndRegisterEpsImplAsync(names, null, ct), "Error downloading execution providers.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<EpDownloadResult> DownloadAndRegisterEpsAsync(Action<string, double> progressCallback, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => DownloadAndRegisterEpsImplAsync(null, progressCallback, ct), "Error downloading execution providers.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<EpDownloadResult> DownloadAndRegisterEpsAsync(IEnumerable<string> names, Action<string, double> progressCallback, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => DownloadAndRegisterEpsImplAsync(names, progressCallback, ct), "Error downloading execution providers.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		private FoundryLocalManager(Configuration configuration, ILogger logger)
		{
			_config = configuration ?? throw new ArgumentNullException("configuration");
			_logger = logger;
		}

		private async Task InitializeAsync(CancellationToken? ct = null)
		{
			_config.Validate();
			_coreInterop = new CoreInterop(_config, _logger);
			_modelManager = new ModelLoadManager(_config.Web?.ExternalUrl, _coreInterop, _logger);
			if (_config.ModelCacheDir == null)
			{
				return;
			}
			CoreInteropRequest commandInput = null;
			ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("get_cache_directory", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error getting current model cache directory: " + response.Error, _logger);
			}
			if (response.Data != _config.ModelCacheDir)
			{
				CoreInteropRequest commandInput2 = new CoreInteropRequest
				{
					Params = new Dictionary<string, string> { { "Directory", _config.ModelCacheDir } }
				};
				response = await _coreInterop.ExecuteCommandAsync("set_cache_directory", commandInput2, ct).ConfigureAwait(continueOnCapturedContext: false);
				if (response.Error != null)
				{
					throw new FoundryLocalException("Error setting model cache directory to '" + _config.ModelCacheDir + "': " + response.Error, _logger);
				}
			}
		}

		private EpInfo[] DiscoverEpsImpl()
		{
			ICoreInterop.Response response = _coreInterop.ExecuteCommand("discover_eps");
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error discovering execution providers: " + response.Error, _logger);
			}
			string data = response.Data;
			if (string.IsNullOrWhiteSpace(data))
			{
				return Array.Empty<EpInfo>();
			}
			return JsonSerializer.Deserialize(data, JsonSerializationContext.Default.EpInfoArray) ?? Array.Empty<EpInfo>();
		}

		private async Task<ICatalog> GetCatalogImplAsync(CancellationToken? ct = null)
		{
			if (_catalog == null)
			{
				using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
				{
					if (_catalog == null)
					{
						_catalog = await Catalog.CreateAsync(_modelManager, _coreInterop, _logger, ct).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
			}
			return _catalog;
		}

		private async Task StartWebServiceImplAsync(CancellationToken? ct = null)
		{
			if (_config?.Web?.Urls == null)
			{
				throw new FoundryLocalException("Web service configuration was not provided.", _logger);
			}
			using (await asyncLock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				CoreInteropRequest commandInput = null;
				ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("start_service", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
				if (response.Error != null)
				{
					throw new FoundryLocalException("Error starting web service: " + response.Error, _logger);
				}
				JsonTypeInfo<string[]> stringArray = JsonSerializationContext.Default.StringArray;
				string[] array = JsonSerializer.Deserialize(response.Data, stringArray);
				if (array == null || array.Length == 0)
				{
					throw new FoundryLocalException("Failed to get bound URLs from web service start response.", _logger);
				}
				Urls = array;
			}
		}

		private async Task StopWebServiceImplAsync(CancellationToken? ct = null)
		{
			if (_config?.Web?.Urls == null)
			{
				throw new FoundryLocalException("Web service configuration was not provided.", _logger);
			}
			using (await asyncLock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				CoreInteropRequest commandInput = null;
				ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("stop_service", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
				if (response.Error != null)
				{
					throw new FoundryLocalException("Error stopping web service: " + response.Error, _logger);
				}
				Urls = null;
			}
		}

		private async Task<EpDownloadResult> DownloadAndRegisterEpsImplAsync(IEnumerable<string>? names = null, Action<string, double>? progressCallback = null, CancellationToken? ct = null)
		{
			using (await asyncLock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				CoreInteropRequest commandInput = null;
				if (names != null)
				{
					string value = string.Join(",", names);
					if (!string.IsNullOrEmpty(value))
					{
						commandInput = new CoreInteropRequest
						{
							Params = new Dictionary<string, string> { { "Names", value } }
						};
					}
				}
				ICoreInterop.Response response;
				if (progressCallback != null || (ct?.CanBeCanceled ?? false))
				{
					ICoreInterop.CallbackFn callback = (string progressString) =>
					{
						if (ct.HasValue)
						{
							ct.GetValueOrDefault().ThrowIfCancellationRequested();
						}
						int num = progressString.IndexOf('|');
						if (num >= 0)
						{
							string text = progressString.Substring(0, num);
							if (double.TryParse(progressString.Substring(num + 1), NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
							{
								progressCallback?.Invoke(string.IsNullOrEmpty(text) ? "" : text, result);
							}
						}
					};
					response = await _coreInterop.ExecuteCommandWithCallbackAsync("download_and_register_eps", commandInput, callback, ct).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					response = await _coreInterop.ExecuteCommandAsync("download_and_register_eps", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (response.Error != null)
				{
					throw new FoundryLocalException("Error downloading execution providers: " + response.Error, _logger);
				}
				EpDownloadResult epDownloadResult = (string.IsNullOrEmpty(response.Data) ? new EpDownloadResult
				{
					Success = true,
					Status = "Completed",
					RegisteredEps = Array.Empty<string>(),
					FailedEps = Array.Empty<string>()
				} : (JsonSerializer.Deserialize(response.Data, JsonSerializationContext.Default.EpDownloadResult) ?? throw new FoundryLocalException("Failed to deserialize EP download result.", _logger)));
				if ((epDownloadResult.Success || epDownloadResult.RegisteredEps.Length != 0) && _catalog != null)
				{
					_catalog.InvalidateCache();
				}
				return epDownloadResult;
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
			{
				return;
			}
			if (disposing)
			{
				if (Urls != null)
				{
					try
					{
						StopWebServiceImplAsync().GetAwaiter().GetResult();
					}
					catch (Exception exception)
					{
						_logger.LogWarning(exception, "Error stopping web service during Dispose.");
					}
				}
				_catalog?.Dispose();
				_modelManager?.Dispose();
				_lock.Dispose();
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	[JsonConverter(typeof(JsonStringEnumConverter<DeviceType>))]
	public enum DeviceType
	{
		Invalid,
		CPU,
		GPU,
		NPU
	}
	public record PromptTemplate
	{
		[JsonPropertyName("system")]
		public string? System { get; init; }

		[JsonPropertyName("user")]
		public string? User { get; init; }

		[JsonPropertyName("assistant")]
		public string Assistant { get; init; }

		[JsonPropertyName("prompt")]
		public string Prompt { get; init; }
	}
	public record Runtime
	{
		[JsonPropertyName("deviceType")]
		public DeviceType DeviceType { get; init; }

		[JsonPropertyName("executionProvider")]
		public string ExecutionProvider { get; init; }
	}
	public record Parameter
	{
		public required string Name { get; set; }

		public string? Value { get; set; }
	}
	public record ModelSettings
	{
		[JsonPropertyName("parameters")]
		public Parameter[]? Parameters { get; set; }
	}
	public record ModelInfo
	{
		[JsonPropertyName("id")]
		public required string Id { get; init; }

		[JsonPropertyName("name")]
		public required string Name { get; init; }

		[JsonPropertyName("version")]
		public int Version { get; init; }

		[JsonPropertyName("alias")]
		public required string Alias { get; init; }

		[JsonPropertyName("displayName")]
		public string? DisplayName { get; init; }

		[JsonPropertyName("providerType")]
		public required string ProviderType { get; init; }

		[JsonPropertyName("uri")]
		public required string Uri { get; init; }

		[JsonPropertyName("modelType")]
		public required string ModelType { get; init; }

		[JsonPropertyName("promptTemplate")]
		public PromptTemplate? PromptTemplate { get; init; }

		[JsonPropertyName("publisher")]
		public string? Publisher { get; init; }

		[JsonPropertyName("modelSettings")]
		public ModelSettings? ModelSettings { get; init; }

		[JsonPropertyName("license")]
		public string? License { get; init; }

		[JsonPropertyName("licenseDescription")]
		public string? LicenseDescription { get; init; }

		[JsonPropertyName("cached")]
		public bool Cached { get; init; }

		[JsonPropertyName("task")]
		public string? Task { get; init; }

		[JsonPropertyName("runtime")]
		public Runtime? Runtime { get; init; }

		[JsonPropertyName("fileSizeMb")]
		public int? FileSizeMb { get; init; }

		[JsonPropertyName("supportsToolCalling")]
		public bool? SupportsToolCalling { get; init; }

		[JsonPropertyName("maxOutputTokens")]
		public long? MaxOutputTokens { get; init; }

		[JsonPropertyName("minFLVersion")]
		public string? MinFLVersion { get; init; }

		[JsonPropertyName("createdAt")]
		public long CreatedAtUnix { get; init; }

		[JsonPropertyName("contextLength")]
		public long? ContextLength { get; init; }

		[JsonPropertyName("inputModalities")]
		public string? InputModalities { get; init; }

		[JsonPropertyName("outputModalities")]
		public string? OutputModalities { get; init; }

		[JsonPropertyName("capabilities")]
		public string? Capabilities { get; init; }
	}
	public interface ICatalog
	{
		string Name { get; }

		Task<List<IModel>> ListModelsAsync(CancellationToken? ct = null);

		Task<IModel?> GetModelAsync(string modelAlias, CancellationToken? ct = null);

		Task<IModel?> GetModelVariantAsync(string modelId, CancellationToken? ct = null);

		Task<List<IModel>> GetCachedModelsAsync(CancellationToken? ct = null);

		Task<List<IModel>> GetLoadedModelsAsync(CancellationToken? ct = null);

		Task<IModel> GetLatestVersionAsync(IModel model, CancellationToken? ct = null);
	}
	public interface IModel
	{
		string Id { get; }

		string Alias { get; }

		ModelInfo Info { get; }

		IReadOnlyList<IModel> Variants { get; }

		Task<bool> IsCachedAsync(CancellationToken? ct = null);

		Task<bool> IsLoadedAsync(CancellationToken? ct = null);

		Task DownloadAsync(Action<float>? downloadProgress = null, CancellationToken? ct = null);

		Task<string> GetPathAsync(CancellationToken? ct = null);

		Task LoadAsync(CancellationToken? ct = null);

		Task RemoveFromCacheAsync(CancellationToken? ct = null);

		Task UnloadAsync(CancellationToken? ct = null);

		Task<OpenAIChatClient> GetChatClientAsync(CancellationToken? ct = null);

		Task<OpenAIAudioClient> GetAudioClientAsync(CancellationToken? ct = null);

		Task<OpenAIEmbeddingClient> GetEmbeddingClientAsync(CancellationToken? ct = null);

		void SelectVariant(IModel variant);
	}
	public enum LogLevel
	{
		Verbose,
		Debug,
		Information,
		Warning,
		Error,
		Fatal
	}
	public class OpenAIAudioClient
	{
		public record AudioSettings
		{
			public string? Language { get; set; }

			public float? Temperature { get; set; }
		}

		private readonly string _modelId;

		private readonly ICoreInterop _coreInterop = FoundryLocalManager.Instance.CoreInterop;

		private readonly ILogger _logger = FoundryLocalManager.Instance.Logger;

		public AudioSettings Settings { get; } = new AudioSettings();

		internal OpenAIAudioClient(string modelId)
		{
			_modelId = modelId;
		}

		public async Task<AudioCreateTranscriptionResponse> TranscribeAudioAsync(string audioFilePath, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => TranscribeAudioImplAsync(audioFilePath, ct), "Error during audio transcription.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async IAsyncEnumerable<AudioCreateTranscriptionResponse> TranscribeAudioStreamingAsync(string audioFilePath, [EnumeratorCancellation] CancellationToken ct)
		{
			await foreach (AudioCreateTranscriptionResponse item in Utils.CallWithExceptionHandling(() => TranscribeAudioStreamingImplAsync(audioFilePath, ct), "Error during streaming audio transcription.", _logger).ConfigureAwait(continueOnCapturedContext: false))
			{
				yield return item;
			}
		}

		public LiveAudioTranscriptionSession CreateLiveTranscriptionSession()
		{
			return new LiveAudioTranscriptionSession(_modelId);
		}

		private async Task<AudioCreateTranscriptionResponse> TranscribeAudioImplAsync(string audioFilePath, CancellationToken? ct)
		{
			AudioTranscriptionCreateRequestExtended request = AudioTranscriptionCreateRequestExtended.FromUserInput(_modelId, audioFilePath, Settings);
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { 
				{
					"OpenAICreateRequest",
					request.ToJson()
				} }
			};
			return (await _coreInterop.ExecuteCommandAsync("audio_transcribe", commandInput, ct ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false)).ToAudioTranscription(_logger);
		}

		private async IAsyncEnumerable<AudioCreateTranscriptionResponse> TranscribeAudioStreamingImplAsync(string audioFilePath, [EnumeratorCancellation] CancellationToken ct)
		{
			AudioTranscriptionCreateRequestExtended request = AudioTranscriptionCreateRequestExtended.FromUserInput(_modelId, audioFilePath, Settings);
			CoreInteropRequest request2 = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { 
				{
					"OpenAICreateRequest",
					request.ToJson()
				} }
			};
			Channel<AudioCreateTranscriptionResponse> channel = Channel.CreateUnbounded<AudioCreateTranscriptionResponse>(new UnboundedChannelOptions
			{
				SingleWriter = true,
				SingleReader = true,
				AllowSynchronousContinuations = true
			});
			Task.Run(async () =>
			{
				try
				{
					bool failed = false;
					ICoreInterop.Response response = await _coreInterop.ExecuteCommandWithCallbackAsync("audio_transcribe", request2, async (string callbackData) =>
					{
						try
						{
							if (!failed)
							{
								AudioCreateTranscriptionResponse item = callbackData.ToAudioTranscription(_logger);
								await channel.Writer.WriteAsync(item);
							}
						}
						catch (Exception innerException)
						{
							channel.Writer.TryComplete(new FoundryLocalException("Error processing streaming audio transcription callback data.", innerException, _logger));
							failed = true;
						}
					}, ct).ConfigureAwait(continueOnCapturedContext: false);
					if (response.Error != null)
					{
						channel.Writer.TryComplete(new FoundryLocalException("Error from audio_transcribe command: " + response.Error, _logger));
					}
					else
					{
						channel.Writer.TryComplete();
					}
				}
				catch (Exception ex) when (!(ex is OperationCanceledException))
				{
					channel.Writer.TryComplete(new FoundryLocalException("Error executing streaming audio transcription.", ex, _logger));
				}
				catch (OperationCanceledException)
				{
					channel.Writer.TryComplete();
				}
			}, ct);
			await foreach (AudioCreateTranscriptionResponse item2 in channel.Reader.ReadAllAsync(ct))
			{
				yield return item2;
			}
		}
	}
	public class OpenAIChatClient
	{
		public record ChatSettings
		{
			public float? FrequencyPenalty { get; set; }

			public int? MaxTokens { get; set; }

			public int? N { get; set; }

			public float? Temperature { get; set; }

			public float? PresencePenalty { get; set; }

			public int? RandomSeed { get; set; }

			internal bool? Stream { get; set; }

			public int? TopK { get; set; }

			public float? TopP { get; set; }

			public ResponseFormatExtended? ResponseFormat { get; set; }

			public ToolChoice? ToolChoice { get; set; }
		}

		private readonly string _modelId;

		private readonly ICoreInterop _coreInterop = FoundryLocalManager.Instance.CoreInterop;

		private readonly ILogger _logger = FoundryLocalManager.Instance.Logger;

		public ChatSettings Settings { get; } = new ChatSettings();

		internal OpenAIChatClient(string modelId)
		{
			_modelId = modelId;
		}

		public Task<ChatCompletionCreateResponse> CompleteChatAsync(IEnumerable<ChatMessage> messages, CancellationToken? ct = null)
		{
			return CompleteChatAsync(messages, null, ct);
		}

		public async Task<ChatCompletionCreateResponse> CompleteChatAsync(IEnumerable<ChatMessage> messages, IEnumerable<ToolDefinition>? tools, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => CompleteChatImplAsync(messages, tools, ct), "Error during chat completion.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public IAsyncEnumerable<ChatCompletionCreateResponse> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, CancellationToken ct)
		{
			return CompleteChatStreamingAsync(messages, null, ct);
		}

		public async IAsyncEnumerable<ChatCompletionCreateResponse> CompleteChatStreamingAsync(IEnumerable<ChatMessage> messages, IEnumerable<ToolDefinition>? tools, [EnumeratorCancellation] CancellationToken ct)
		{
			await foreach (ChatCompletionCreateResponse item in Utils.CallWithExceptionHandling(() => ChatStreamingImplAsync(messages, tools, ct), "Error during streaming chat completion.", _logger).ConfigureAwait(continueOnCapturedContext: false))
			{
				yield return item;
			}
		}

		private async Task<ChatCompletionCreateResponse> CompleteChatImplAsync(IEnumerable<ChatMessage> messages, IEnumerable<ToolDefinition>? tools, CancellationToken? ct)
		{
			Settings.Stream = false;
			string value = ChatCompletionCreateRequestExtended.FromUserInput(_modelId, messages, tools, Settings).ToJson();
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "OpenAICreateRequest", value } }
			};
			return (await _coreInterop.ExecuteCommandAsync("chat_completions", commandInput, ct ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false)).ToChatCompletion(_logger);
		}

		private async IAsyncEnumerable<ChatCompletionCreateResponse> ChatStreamingImplAsync(IEnumerable<ChatMessage> messages, IEnumerable<ToolDefinition>? tools, [EnumeratorCancellation] CancellationToken ct)
		{
			Settings.Stream = true;
			string value = ChatCompletionCreateRequestExtended.FromUserInput(_modelId, messages, tools, Settings).ToJson();
			CoreInteropRequest request = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "OpenAICreateRequest", value } }
			};
			Channel<ChatCompletionCreateResponse> channel = Channel.CreateUnbounded<ChatCompletionCreateResponse>(new UnboundedChannelOptions
			{
				SingleWriter = true,
				SingleReader = true,
				AllowSynchronousContinuations = true
			});
			Task.Run(async () =>
			{
				try
				{
					bool failed = false;
					ICoreInterop.Response response = await _coreInterop.ExecuteCommandWithCallbackAsync("chat_completions", request, async (string callbackData) =>
					{
						try
						{
							if (!failed)
							{
								ChatCompletionCreateResponse chatCompletionCreateResponse = callbackData.ToChatCompletion(_logger);
								List<ChatChoiceResponse> choices = chatCompletionCreateResponse.Choices;
								if (choices != null && choices.Count > 0)
								{
									await channel.Writer.WriteAsync(chatCompletionCreateResponse);
								}
							}
						}
						catch (Exception innerException)
						{
							channel.Writer.TryComplete(new FoundryLocalException("Error processing streaming chat completion callback data.", innerException, _logger));
							failed = true;
						}
					}, ct).ConfigureAwait(continueOnCapturedContext: false);
					if (!failed && response.Error != null)
					{
						channel.Writer.TryComplete(new FoundryLocalException("Error from chat_completions command: " + response.Error, _logger));
						failed = true;
					}
					else
					{
						channel.Writer.TryComplete();
					}
				}
				catch (Exception ex) when (!(ex is OperationCanceledException))
				{
					channel.Writer.TryComplete(new FoundryLocalException("Error executing streaming chat completion.", ex, _logger));
				}
				catch (OperationCanceledException)
				{
					channel.Writer.TryComplete();
				}
			}, ct);
			await foreach (ChatCompletionCreateResponse item in channel.Reader.ReadAllAsync(ct))
			{
				yield return item;
			}
		}
	}
	public class OpenAIEmbeddingClient
	{
		private readonly string _modelId;

		private readonly ICoreInterop _coreInterop = FoundryLocalManager.Instance.CoreInterop;

		private readonly ILogger _logger = FoundryLocalManager.Instance.Logger;

		internal OpenAIEmbeddingClient(string modelId)
		{
			_modelId = modelId;
		}

		public async Task<EmbeddingCreateResponse> GenerateEmbeddingAsync(string input, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GenerateEmbeddingImplAsync(input, ct), "Error during embedding generation.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<EmbeddingCreateResponse> GenerateEmbeddingsAsync(IEnumerable<string> inputs, CancellationToken? ct = null)
		{
			return await Utils.CallWithExceptionHandling(() => GenerateEmbeddingsImplAsync(inputs, ct), "Error during batch embedding generation.", _logger).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<EmbeddingCreateResponse> GenerateEmbeddingImplAsync(string input, CancellationToken? ct)
		{
			if (string.IsNullOrWhiteSpace(input))
			{
				throw new ArgumentException("Input must be a non-empty string.", "input");
			}
			string value = EmbeddingCreateRequestExtended.FromUserInput(_modelId, input).ToJson();
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "OpenAICreateRequest", value } }
			};
			return (await _coreInterop.ExecuteCommandAsync("embeddings", commandInput, ct ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false)).ToEmbeddingResponse(_logger);
		}

		private async Task<EmbeddingCreateResponse> GenerateEmbeddingsImplAsync(IEnumerable<string> inputs, CancellationToken? ct)
		{
			if (inputs == null || !inputs.Any())
			{
				throw new ArgumentException("Inputs must be a non-empty array of strings.", "inputs");
			}
			foreach (string input in inputs)
			{
				if (string.IsNullOrWhiteSpace(input))
				{
					throw new ArgumentException("Each input must be a non-empty string.", "inputs");
				}
			}
			string value = EmbeddingCreateRequestExtended.FromUserInput(_modelId, inputs).ToJson();
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "OpenAICreateRequest", value } }
			};
			return (await _coreInterop.ExecuteCommandAsync("embeddings", commandInput, ct ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false)).ToEmbeddingResponse(_logger);
		}
	}
	internal class Utils
	{
		internal static async Task<string[]> GetCachedModelIdsAsync(ICoreInterop coreInterop, CancellationToken? ct = null)
		{
			CoreInteropRequest commandInput = null;
			ICoreInterop.Response response = await coreInterop.ExecuteCommandAsync("get_cached_models", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error getting cached model ids: " + response.Error);
			}
			JsonTypeInfo<string[]> stringArray = JsonSerializationContext.Default.StringArray;
			return JsonSerializer.Deserialize(response.Data, stringArray) ?? throw new FoundryLocalException("Failed to deserialized cached model names. Json:'" + response.Data + "'");
		}

		internal static T CallWithExceptionHandling<T>(Func<T> func, string errorMsg, ILogger logger)
		{
			try
			{
				return func();
			}
			catch (Exception ex) when (!(ex is OperationCanceledException) && !(ex is FoundryLocalException))
			{
				throw new FoundryLocalException(errorMsg, ex, logger);
			}
		}
	}
}
namespace Microsoft.AI.Foundry.Local.OpenAI
{
	internal record AudioTranscriptionCreateRequestExtended : AudioCreateTranscriptionRequest
	{
		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		internal static AudioTranscriptionCreateRequestExtended FromUserInput(string modelId, string audioFilePath, OpenAIAudioClient.AudioSettings settings)
		{
			AudioTranscriptionCreateRequestExtended audioTranscriptionCreateRequestExtended = new AudioTranscriptionCreateRequestExtended
			{
				Model = modelId,
				FileName = audioFilePath,
				Language = settings.Language,
				Temperature = settings.Temperature
			};
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (settings.Language != null)
			{
				dictionary["language"] = settings.Language;
			}
			if (settings.Temperature.HasValue)
			{
				dictionary["temperature"] = settings.Temperature.Value.ToString(CultureInfo.InvariantCulture);
			}
			if (dictionary.Count > 0)
			{
				audioTranscriptionCreateRequestExtended.Metadata = dictionary;
			}
			return audioTranscriptionCreateRequestExtended;
		}
	}
	internal static class AudioTranscriptionRequestResponseExtensions
	{
		internal static string ToJson(this AudioCreateTranscriptionRequest request)
		{
			return JsonSerializer.Serialize(request, JsonSerializationContext.Default.AudioCreateTranscriptionRequest);
		}

		internal static AudioCreateTranscriptionResponse ToAudioTranscription(this ICoreInterop.Response response, ILogger logger)
		{
			if (response.Error != null)
			{
				logger.LogError("Error from audio_transcribe: {Error}", response.Error);
				throw new FoundryLocalException("Error from audio_transcribe command: " + response.Error);
			}
			return response.Data.ToAudioTranscription(logger);
		}

		internal static AudioCreateTranscriptionResponse ToAudioTranscription(this string responseData, ILogger logger)
		{
			JsonTypeInfo<AudioCreateTranscriptionResponse> audioCreateTranscriptionResponse = JsonSerializationContext.Default.AudioCreateTranscriptionResponse;
			AudioCreateTranscriptionResponse audioCreateTranscriptionResponse2 = JsonSerializer.Deserialize(responseData, audioCreateTranscriptionResponse);
			if (audioCreateTranscriptionResponse2 == null)
			{
				logger.LogError("Failed to deserialize AudioCreateTranscriptionResponse. Json={Data}", responseData);
				throw new FoundryLocalException("Failed to deserialize AudioCreateTranscriptionResponse");
			}
			return audioCreateTranscriptionResponse2;
		}
	}
	internal class ChatCompletionCreateRequestExtended : ChatCompletionCreateRequest
	{
		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("response_format")]
		public new ResponseFormatExtended? ResponseFormat { get; set; }

		internal static ChatCompletionCreateRequestExtended FromUserInput(string modelId, IEnumerable<ChatMessage> messages, IEnumerable<ToolDefinition>? tools, OpenAIChatClient.ChatSettings settings)
		{
			ChatCompletionCreateRequestExtended chatCompletionCreateRequestExtended = new ChatCompletionCreateRequestExtended
			{
				Model = modelId,
				Messages = messages.ToList(),
				Tools = tools?.ToList(),
				FrequencyPenalty = settings.FrequencyPenalty,
				MaxTokens = settings.MaxTokens,
				N = settings.N,
				Temperature = settings.Temperature,
				PresencePenalty = settings.PresencePenalty,
				Stream = settings.Stream,
				TopP = settings.TopP,
				ResponseFormat = settings.ResponseFormat,
				ToolChoice = settings.ToolChoice
			};
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (settings.TopK.HasValue)
			{
				dictionary["top_k"] = settings.TopK.Value.ToString(CultureInfo.InvariantCulture);
			}
			if (settings.RandomSeed.HasValue)
			{
				dictionary["random_seed"] = settings.RandomSeed.Value.ToString(CultureInfo.InvariantCulture);
			}
			if (dictionary.Count > 0)
			{
				chatCompletionCreateRequestExtended.Metadata = dictionary;
			}
			return chatCompletionCreateRequestExtended;
		}
	}
	internal static class ChatCompletionsRequestResponseExtensions
	{
		internal static string ToJson(this ChatCompletionCreateRequestExtended request)
		{
			return JsonSerializer.Serialize(request, JsonSerializationContext.Default.ChatCompletionCreateRequestExtended);
		}

		internal static ChatCompletionCreateResponse ToChatCompletion(this ICoreInterop.Response response, ILogger logger)
		{
			if (response.Error != null)
			{
				logger.LogError("Error from chat_completions: {Error}", response.Error);
				throw new FoundryLocalException("Error from chat_completions command: " + response.Error);
			}
			return response.Data.ToChatCompletion(logger);
		}

		internal static ChatCompletionCreateResponse ToChatCompletion(this string responseData, ILogger logger)
		{
			ChatCompletionCreateResponse chatCompletionCreateResponse = JsonSerializer.Deserialize(responseData, JsonSerializationContext.Default.ChatCompletionCreateResponse);
			if (chatCompletionCreateResponse == null)
			{
				logger.LogError("Failed to deserialize chat completion response: {ResponseData}", responseData);
				throw new JsonException("Failed to deserialize ChatCompletion");
			}
			return chatCompletionCreateResponse;
		}
	}
	internal record EmbeddingCreateRequestExtended : EmbeddingCreateRequest
	{
		internal static EmbeddingCreateRequestExtended FromUserInput(string modelId, string input)
		{
			return new EmbeddingCreateRequestExtended
			{
				Model = modelId,
				Input = input
			};
		}

		internal static EmbeddingCreateRequestExtended FromUserInput(string modelId, IEnumerable<string> inputs)
		{
			return new EmbeddingCreateRequestExtended
			{
				Model = modelId,
				InputAsList = inputs.ToList()
			};
		}
	}
	internal static class EmbeddingRequestResponseExtensions
	{
		internal static string ToJson(this EmbeddingCreateRequestExtended request)
		{
			return JsonSerializer.Serialize(request, JsonSerializationContext.Default.EmbeddingCreateRequestExtended);
		}

		internal static EmbeddingCreateResponse ToEmbeddingResponse(this ICoreInterop.Response response, ILogger logger)
		{
			if (response.Error != null)
			{
				logger.LogError("Error from embeddings: {Error}", response.Error);
				throw new FoundryLocalException("Error from embeddings command: " + response.Error);
			}
			if (string.IsNullOrWhiteSpace(response.Data))
			{
				logger.LogError("Embeddings command returned no data");
				throw new FoundryLocalException("Embeddings command returned null or empty response data");
			}
			return response.Data.ToEmbeddingResponse(logger);
		}

		internal static EmbeddingCreateResponse ToEmbeddingResponse(this string responseData, ILogger logger)
		{
			EmbeddingCreateResponse embeddingCreateResponse = JsonSerializer.Deserialize(responseData, JsonSerializationContext.Default.EmbeddingCreateResponse);
			if (embeddingCreateResponse == null)
			{
				logger.LogError("Failed to deserialize embedding response: {ResponseData}", responseData);
				throw new JsonException("Failed to deserialize EmbeddingCreateResponse");
			}
			return embeddingCreateResponse;
		}
	}
	public sealed class LiveAudioTranscriptionSession : IAsyncDisposable
	{
		public record LiveAudioTranscriptionOptions
		{
			public int SampleRate { get; set; } = 16000;

			public int Channels { get; set; } = 1;

			public int BitsPerSample { get; set; } = 16;

			public string? Language { get; set; }

			public int PushQueueCapacity { get; set; } = 100;

			internal LiveAudioTranscriptionOptions Snapshot()
			{
				return this with { };
			}
		}

		private readonly string _modelId;

		private readonly ICoreInterop _coreInterop = FoundryLocalManager.Instance.CoreInterop;

		private readonly ILogger _logger = FoundryLocalManager.Instance.Logger;

		private readonly AsyncLock _lock = new AsyncLock();

		private string? _sessionHandle;

		private bool _started;

		private bool _stopped;

		private Channel<LiveAudioTranscriptionResponse>? _outputChannel;

		private Channel<ReadOnlyMemory<byte>>? _pushChannel;

		private Task? _pushLoopTask;

		private CancellationTokenSource? _sessionCts;

		private LiveAudioTranscriptionOptions? _activeSettings;

		public LiveAudioTranscriptionOptions Settings { get; } = new LiveAudioTranscriptionOptions();

		internal LiveAudioTranscriptionSession(string modelId)
		{
			_modelId = modelId;
		}

		public async Task StartAsync(CancellationToken ct = default(CancellationToken))
		{
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				if (_started)
				{
					throw new FoundryLocalException("Streaming session already started. Call StopAsync first.");
				}
				_activeSettings = Settings.Snapshot();
				_outputChannel = Channel.CreateUnbounded<LiveAudioTranscriptionResponse>(new UnboundedChannelOptions
				{
					SingleWriter = true,
					SingleReader = true,
					AllowSynchronousContinuations = true
				});
				_pushChannel = Channel.CreateBounded<ReadOnlyMemory<byte>>(new BoundedChannelOptions(_activeSettings.PushQueueCapacity)
				{
					SingleReader = true,
					SingleWriter = false,
					FullMode = BoundedChannelFullMode.Wait
				});
				CoreInteropRequest request = new CoreInteropRequest
				{
					Params = new Dictionary<string, string>
					{
						{ "Model", _modelId },
						{
							"SampleRate",
							_activeSettings.SampleRate.ToString(CultureInfo.InvariantCulture)
						},
						{
							"Channels",
							_activeSettings.Channels.ToString(CultureInfo.InvariantCulture)
						},
						{
							"BitsPerSample",
							_activeSettings.BitsPerSample.ToString(CultureInfo.InvariantCulture)
						}
					}
				};
				if (_activeSettings.Language != null)
				{
					request.Params["Language"] = _activeSettings.Language;
				}
				ICoreInterop.Response response = await Task.Run(() => _coreInterop.StartAudioStream(request), ct).ConfigureAwait(continueOnCapturedContext: false);
				if (response.Error != null)
				{
					_outputChannel.Writer.TryComplete();
					throw new FoundryLocalException("Error starting audio stream session: " + response.Error, _logger);
				}
				_sessionHandle = response.Data ?? throw new FoundryLocalException("Native core did not return a session handle.", _logger);
				_started = true;
				_stopped = false;
				_sessionCts?.Dispose();
				_sessionCts = new CancellationTokenSource();
				_pushLoopTask = Task.Run(() => PushLoopAsync(_sessionCts.Token), CancellationToken.None);
			}
		}

		public async ValueTask AppendAsync(ReadOnlyMemory<byte> pcmData, CancellationToken ct = default(CancellationToken))
		{
			if (!_started || _stopped)
			{
				throw new FoundryLocalException("No active streaming session. Call StartAsync first.");
			}
			byte[] array = new byte[pcmData.Length];
			pcmData.CopyTo(array);
			await _pushChannel.Writer.WriteAsync(array, ct).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task PushLoopAsync(CancellationToken ct)
		{
			_ = 1;
			try
			{
				await foreach (ReadOnlyMemory<byte> item in _pushChannel.Reader.ReadAllAsync(ct).ConfigureAwait(continueOnCapturedContext: false))
				{
					CoreInteropRequest request = new CoreInteropRequest
					{
						Params = new Dictionary<string, string> { { "SessionHandle", _sessionHandle } }
					};
					ICoreInterop.Response response = _coreInterop.PushAudioData(request, item);
					if (response.Error != null)
					{
						FoundryLocalException error = new FoundryLocalException("Push failed (code=" + (CoreErrorResponse.TryParse(response.Error)?.Code ?? "UNKNOWN") + "): " + response.Error, _logger);
						_logger.LogError("Terminating push loop due to push failure: {Error}", response.Error);
						_outputChannel?.Writer.TryComplete(error);
						return;
					}
					if (string.IsNullOrEmpty(response.Data))
					{
						continue;
					}
					try
					{
						LiveAudioTranscriptionResponse liveAudioTranscriptionResponse = LiveAudioTranscriptionResponse.FromJson(response.Data);
						if (!string.IsNullOrEmpty(liveAudioTranscriptionResponse.Content?[0]?.Text))
						{
							_outputChannel?.Writer.TryWrite(liveAudioTranscriptionResponse);
						}
					}
					catch (Exception exception)
					{
						_logger.LogDebug(exception, "Could not parse push response as transcription result");
					}
				}
			}
			catch (OperationCanceledException)
			{
			}
			catch (Exception ex2)
			{
				_logger.LogError(ex2, "Push loop terminated with unexpected error");
				_outputChannel?.Writer.TryComplete(new FoundryLocalException("Push loop terminated unexpectedly.", ex2, _logger));
			}
		}

		public async IAsyncEnumerable<LiveAudioTranscriptionResponse> GetStream([EnumeratorCancellation] CancellationToken ct = default(CancellationToken))
		{
			if (_outputChannel == null)
			{
				throw new FoundryLocalException("No active streaming session. Call StartAsync first.");
			}
			await foreach (LiveAudioTranscriptionResponse item in _outputChannel.Reader.ReadAllAsync(ct).ConfigureAwait(continueOnCapturedContext: false))
			{
				yield return item;
			}
		}

		public async Task StopAsync(CancellationToken ct = default(CancellationToken))
		{
			using (await _lock.LockAsync().ConfigureAwait(continueOnCapturedContext: false))
			{
				if (!_started || _stopped)
				{
					return;
				}
				_stopped = true;
				_pushChannel?.Writer.TryComplete();
				if (_pushLoopTask != null)
				{
					await _pushLoopTask.ConfigureAwait(continueOnCapturedContext: false);
				}
				_sessionCts?.Cancel();
				CoreInteropRequest request = new CoreInteropRequest
				{
					Params = new Dictionary<string, string> { { "SessionHandle", _sessionHandle } }
				};
				ICoreInterop.Response response = null;
				try
				{
					response = await Task.Run(() => _coreInterop.StopAudioStream(request), ct).ConfigureAwait(continueOnCapturedContext: false);
				}
				catch (OperationCanceledException) when (ct.IsCancellationRequested)
				{
					_logger.LogWarning("StopAsync cancelled — performing best-effort native session stop.");
					try
					{
						response = await Task.Run(() => _coreInterop.StopAudioStream(request)).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception exception)
					{
						_logger.LogError(exception, "Best-effort native session stop failed.");
					}
					throw;
				}
				finally
				{
					if (response?.Data != null)
					{
						try
						{
							LiveAudioTranscriptionResponse liveAudioTranscriptionResponse = LiveAudioTranscriptionResponse.FromJson(response.Data);
							if (!string.IsNullOrEmpty(liveAudioTranscriptionResponse.Content?[0]?.Text))
							{
								_outputChannel?.Writer.TryWrite(liveAudioTranscriptionResponse);
							}
						}
						catch (Exception exception2)
						{
							_logger.LogDebug(exception2, "Could not parse stop response as transcription result");
						}
					}
					_sessionHandle = null;
					_started = false;
					_sessionCts?.Dispose();
					_sessionCts = null;
					_outputChannel?.Writer.TryComplete();
				}
				if (response?.Error == null)
				{
					return;
				}
				throw new FoundryLocalException("Error stopping audio stream session: " + response.Error, _logger);
			}
		}

		public async ValueTask DisposeAsync()
		{
			try
			{
				if (_started && !_stopped)
				{
					await StopAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			catch (Exception exception)
			{
				_logger.LogWarning(exception, "Error during DisposeAsync cleanup.");
			}
			finally
			{
				_sessionCts?.Dispose();
				_lock.Dispose();
			}
		}
	}
	public class LiveAudioTranscriptionResponse : ConversationItem
	{
		[JsonPropertyName("is_final")]
		public bool IsFinal { get; init; }

		[JsonPropertyName("start_time")]
		public double? StartTime { get; init; }

		[JsonPropertyName("end_time")]
		public double? EndTime { get; init; }

		[JsonPropertyName("language")]
		public string? Language { get; init; }

		internal static LiveAudioTranscriptionResponse FromJson(string json)
		{
			LiveAudioTranscriptionRaw liveAudioTranscriptionRaw = JsonSerializer.Deserialize(json, JsonSerializationContext.Default.LiveAudioTranscriptionRaw) ?? throw new FoundryLocalException("Failed to deserialize live audio transcription result");
			LiveAudioTranscriptionResponse liveAudioTranscriptionResponse = new LiveAudioTranscriptionResponse
			{
				IsFinal = liveAudioTranscriptionRaw.IsFinal,
				StartTime = liveAudioTranscriptionRaw.StartTime,
				EndTime = liveAudioTranscriptionRaw.EndTime,
				Language = liveAudioTranscriptionRaw.Language
			};
			int num = 1;
			List<ContentPart> list = new List<ContentPart>(num);
			CollectionsMarshal.SetCount(list, num);
			CollectionsMarshal.AsSpan(list)[0] = new ContentPart
			{
				Text = liveAudioTranscriptionRaw.Text,
				Transcript = liveAudioTranscriptionRaw.Text
			};
			liveAudioTranscriptionResponse.Content = list;
			return liveAudioTranscriptionResponse;
		}
	}
	internal record LiveAudioTranscriptionRaw
	{
		[JsonPropertyName("is_final")]
		public bool IsFinal { get; init; }

		[JsonPropertyName("text")]
		public string Text { get; init; } = string.Empty;

		[JsonPropertyName("start_time")]
		public double? StartTime { get; init; }

		[JsonPropertyName("end_time")]
		public double? EndTime { get; init; }

		[JsonPropertyName("language")]
		public string? Language { get; init; }
	}
	internal record CoreErrorResponse
	{
		[JsonPropertyName("code")]
		public string Code { get; init; } = "";

		[JsonPropertyName("message")]
		public string Message { get; init; } = "";

		[JsonPropertyName("isTransient")]
		public bool IsTransient { get; init; }

		internal static CoreErrorResponse? TryParse(string errorString)
		{
			try
			{
				return JsonSerializer.Deserialize(errorString, JsonSerializationContext.Default.CoreErrorResponse);
			}
			catch
			{
				return null;
			}
		}
	}
	public class ResponseFormatExtended : ResponseFormat
	{
		[JsonPropertyName("lark_grammar")]
		public string? LarkGrammar { get; set; }
	}
}
namespace Microsoft.AI.Foundry.Local.Detail
{
	public sealed class AsyncLock : IDisposable
	{
		private sealed class Releaser : IDisposable
		{
			private readonly SemaphoreSlim _semaphore;

			public Releaser(SemaphoreSlim semaphore)
			{
				_semaphore = semaphore;
			}

			public void Dispose()
			{
				_semaphore.Release();
			}
		}

		private readonly Task<IDisposable> _releaserTask;

		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

		private readonly IDisposable _releaser;

		public AsyncLock()
		{
			_releaser = new Releaser(_semaphore);
			_releaserTask = Task.FromResult(_releaser);
		}

		public void Dispose()
		{
			_semaphore.Dispose();
		}

		public IDisposable Lock()
		{
			_semaphore.Wait();
			return _releaser;
		}

		public Task<IDisposable> LockAsync()
		{
			Task task = _semaphore.WaitAsync();
			if (!task.IsCompleted)
			{
				return task.ContinueWith((Task _, object? releaser) => (IDisposable)releaser, _releaser, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
			}
			return _releaserTask;
		}
	}
	internal class CoreInterop : ICoreInterop
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private unsafe delegate void ExecuteCommandDelegate(ICoreInterop.RequestBuffer* req, ICoreInterop.ResponseBuffer* resp);

		internal class CallbackHelper
		{
			public ICoreInterop.CallbackFn Callback { get; }

			public Exception? Exception { get; set; }

			public CallbackHelper(ICoreInterop.CallbackFn callback)
			{
				Callback = callback ?? throw new ArgumentNullException("callback");
			}
		}

		internal const string LibraryName = "Microsoft.AI.Foundry.Local.Core";

		private readonly ILogger _logger;

		private static readonly bool IsWindows;

		private static readonly bool IsLinux;

		private static readonly bool IsMacOS;

		private static nint genaiLibHandle;

		private static nint ortLibHandle;

		private static readonly ICoreInterop.NativeCallbackFn handleCallbackDelegate;

		static CoreInterop()
		{
			IsWindows = OperatingSystem.IsWindows();
			IsLinux = OperatingSystem.IsLinux();
			IsMacOS = OperatingSystem.IsMacOS();
			genaiLibHandle = IntPtr.Zero;
			ortLibHandle = IntPtr.Zero;
			handleCallbackDelegate = HandleCallback;
			InitializeNativeLibraryResolver();
		}

		internal CoreInterop(Configuration config, ILogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException("logger");
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = config.AsDictionary()
			};
			ICoreInterop.Response response = ExecuteCommand("initialize", commandInput);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error initializing Foundry.Local.Core library: " + response.Error);
			}
			_logger.LogInformation("Foundry.Local.Core initialized successfully: {Response}", response.Data);
		}

		internal CoreInterop(ILogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException("logger");
		}

		private static void InitializeNativeLibraryResolver()
		{
			NativeLibrary.SetDllImportResolver(typeof(CoreInterop).Assembly, (string libraryName, Assembly assembly, DllImportSearchPath? searchPath) =>
			{
				if (libraryName == "Microsoft.AI.Foundry.Local.Core")
				{
					string text = Path.Combine(AppContext.BaseDirectory, AddLibraryExtension("Microsoft.AI.Foundry.Local.Core"));
					if (File.Exists(text) && NativeLibrary.TryLoad(text, out var handle))
					{
						if (IsWindows)
						{
							LoadOrtDllsIfInSameDir(AppContext.BaseDirectory);
						}
						return handle;
					}
					string text2;
					if (!IsWindows)
					{
						if (!IsLinux)
						{
							if (!IsMacOS)
							{
								throw new PlatformNotSupportedException();
							}
							text2 = "osx";
						}
						else
						{
							text2 = "linux";
						}
					}
					else
					{
						text2 = "win";
					}
					string text3 = text2;
					string text4 = RuntimeInformation.OSArchitecture.ToString().ToLowerInvariant();
					string text5 = Path.Combine(AppContext.BaseDirectory, "runtimes", text3 + "-" + text4, "native");
					text = Path.Combine(text5, AddLibraryExtension("Microsoft.AI.Foundry.Local.Core"));
					if (File.Exists(text) && NativeLibrary.TryLoad(text, out var handle2))
					{
						if (IsWindows)
						{
							LoadOrtDllsIfInSameDir(text5);
						}
						return handle2;
					}
				}
				return IntPtr.Zero;
			});
		}

		private static string AddLibraryExtension(string name)
		{
			if (!IsWindows)
			{
				if (!IsLinux)
				{
					if (!IsMacOS)
					{
						throw new PlatformNotSupportedException();
					}
					return name + ".dylib";
				}
				return name + ".so";
			}
			return name + ".dll";
		}

		private static void LoadOrtDllsIfInSameDir(string path)
		{
			string path2 = AddLibraryExtension("onnxruntime-genai");
			string path3 = AddLibraryExtension("onnxruntime");
			string path4 = Path.Combine(path, path2);
			TryLoadNativeLibrary(Path.Combine(path, path3), out ortLibHandle);
			TryLoadNativeLibrary(path4, out genaiLibHandle);
		}

		private static int HandleCallback(nint data, int length, nint callbackHelper)
		{
			string text = string.Empty;
			CallbackHelper callbackHelper2 = null;
			try
			{
				if (data != IntPtr.Zero && length > 0)
				{
					byte[] array = new byte[length];
					Marshal.Copy(data, array, 0, length);
					text = Encoding.UTF8.GetString(array);
				}
				callbackHelper2 = (CallbackHelper)GCHandle.FromIntPtr(callbackHelper).Target;
				callbackHelper2.Callback(text);
				return 0;
			}
			catch (OperationCanceledException exception)
			{
				if (callbackHelper2 != null && callbackHelper2.Exception == null)
				{
					callbackHelper2.Exception = exception;
				}
				return 1;
			}
			catch (Exception exception2)
			{
				FoundryLocalManager.Instance.Logger.LogError(exception2, "Error in callback. Callback data: " + text);
				if (callbackHelper2 != null && callbackHelper2.Exception == null)
				{
					callbackHelper2.Exception = exception2;
				}
				return 1;
			}
		}

		public unsafe ICoreInterop.Response ExecuteCommandImpl(string commandName, string? commandInput, ICoreInterop.CallbackFn? callback = null)
		{
			try
			{
				byte[] bytes = Encoding.UTF8.GetBytes(commandName);
				nint num = Marshal.AllocHGlobal(bytes.Length);
				Marshal.Copy(bytes, 0, num, bytes.Length);
				byte[] array = null;
				nint? num2 = null;
				if (commandInput != null)
				{
					array = Encoding.UTF8.GetBytes(commandInput);
					num2 = Marshal.AllocHGlobal(array.Length);
					Marshal.Copy(array, 0, num2.Value, array.Length);
				}
				ICoreInterop.RequestBuffer requestBuffer = new ICoreInterop.RequestBuffer
				{
					Command = num,
					CommandLength = bytes.Length,
					Data = (num2 ?? IntPtr.Zero),
					DataLength = (array?.Length ?? 0)
				};
				ICoreInterop.ResponseBuffer responseBuffer = default;
				Exception ex = null;
				if (callback != null)
				{
					CallbackHelper callbackHelper = new CallbackHelper(callback);
					nint functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate(handleCallbackDelegate);
					GCHandle value = GCHandle.Alloc(callbackHelper);
					nint userData = GCHandle.ToIntPtr(value);
					try
					{
						CoreExecuteCommandWithCallback(&requestBuffer, &responseBuffer, functionPointerForDelegate, userData);
					}
					finally
					{
						value.Free();
					}
					ex = callbackHelper.Exception;
				}
				else
				{
					CoreExecuteCommand(&requestBuffer, &responseBuffer);
				}
				ICoreInterop.Response response = new ICoreInterop.Response();
				if (responseBuffer.Data != IntPtr.Zero && responseBuffer.DataLength > 0)
				{
					byte[] array2 = new byte[responseBuffer.DataLength];
					Marshal.Copy(responseBuffer.Data, array2, 0, responseBuffer.DataLength);
					response.Data = Encoding.UTF8.GetString(array2);
					_logger.LogDebug("Command: " + commandName + " succeeded.");
				}
				if (responseBuffer.Error != IntPtr.Zero && responseBuffer.ErrorLength > 0)
				{
					response.Error = PtrToStringUtf8(responseBuffer.Error, responseBuffer.ErrorLength);
					_logger.LogDebug("Input:" + (commandInput ?? "null"));
					_logger.LogDebug("Command: " + commandName + " Error: " + response.Error);
				}
				Marshal.FreeHGlobal(responseBuffer.Data);
				Marshal.FreeHGlobal(responseBuffer.Error);
				Marshal.FreeHGlobal(num);
				if (commandInput != null)
				{
					Marshal.FreeHGlobal(num2.Value);
				}
				if (ex != null)
				{
					if (ex is OperationCanceledException ex2)
					{
						throw ex2;
					}
					throw new FoundryLocalException("Exception in callback handler. See InnerException for details", ex);
				}
				return response;
			}
			catch (Exception ex3) when (!(ex3 is OperationCanceledException))
			{
				throw new FoundryLocalException("Error executing command '" + commandName + "' with input " + (commandInput ?? "null"), ex3, _logger);
			}
		}

		public ICoreInterop.Response ExecuteCommand(string commandName, CoreInteropRequest? commandInput = null)
		{
			string commandInput2 = commandInput?.ToJson();
			return ExecuteCommandImpl(commandName, commandInput2);
		}

		public ICoreInterop.Response ExecuteCommandWithCallback(string commandName, CoreInteropRequest? commandInput, ICoreInterop.CallbackFn callback)
		{
			string commandInput2 = commandInput?.ToJson();
			return ExecuteCommandImpl(commandName, commandInput2, callback);
		}

		public Task<ICoreInterop.Response> ExecuteCommandAsync(string commandName, CoreInteropRequest? commandInput = null, CancellationToken? cancellationToken = null)
		{
			return Task.Run(cancellationToken: cancellationToken ?? CancellationToken.None, function: () => ExecuteCommand(commandName, commandInput));
		}

		public Task<ICoreInterop.Response> ExecuteCommandWithCallbackAsync(string commandName, CoreInteropRequest? commandInput, ICoreInterop.CallbackFn callback, CancellationToken? cancellationToken = null)
		{
			return Task.Run(cancellationToken: cancellationToken ?? CancellationToken.None, function: () => ExecuteCommandWithCallback(commandName, commandInput, callback));
		}

		private ICoreInterop.Response MarshalResponse(ICoreInterop.ResponseBuffer response)
		{
			ICoreInterop.Response response2 = new ICoreInterop.Response();
			if (response.Data != IntPtr.Zero && response.DataLength > 0)
			{
				byte[] array = new byte[response.DataLength];
				Marshal.Copy(response.Data, array, 0, response.DataLength);
				response2.Data = Encoding.UTF8.GetString(array);
			}
			if (response.Error != IntPtr.Zero && response.ErrorLength > 0)
			{
				response2.Error = PtrToStringUtf8(response.Error, response.ErrorLength);
			}
			Marshal.FreeHGlobal(response.Data);
			Marshal.FreeHGlobal(response.Error);
			return response2;
		}

		public ICoreInterop.Response StartAudioStream(CoreInteropRequest request)
		{
			return ExecuteCommand("audio_stream_start", request);
		}

		public unsafe ICoreInterop.Response PushAudioData(CoreInteropRequest request, ReadOnlyMemory<byte> audioData)
		{
			try
			{
				string s = request.ToJson();
				byte[] bytes = Encoding.UTF8.GetBytes("audio_stream_push");
				byte[] bytes2 = Encoding.UTF8.GetBytes(s);
				nint num = Marshal.AllocHGlobal(bytes.Length);
				Marshal.Copy(bytes, 0, num, bytes.Length);
				nint num2 = Marshal.AllocHGlobal(bytes2.Length);
				Marshal.Copy(bytes2, 0, num2, bytes2.Length);
				using MemoryHandle memoryHandle = audioData.Pin();
				ICoreInterop.StreamingRequestBuffer streamingRequestBuffer = new ICoreInterop.StreamingRequestBuffer
				{
					Command = num,
					CommandLength = bytes.Length,
					Data = num2,
					DataLength = bytes2.Length,
					BinaryData = (nint)memoryHandle.Pointer,
					BinaryDataLength = audioData.Length
				};
				ICoreInterop.ResponseBuffer response = default;
				try
				{
					CoreExecuteCommandWithBinary(&streamingRequestBuffer, &response);
				}
				finally
				{
					Marshal.FreeHGlobal(num);
					Marshal.FreeHGlobal(num2);
				}
				return MarshalResponse(response);
			}
			catch (Exception ex) when (!(ex is OperationCanceledException))
			{
				throw new FoundryLocalException("Error executing audio_stream_push", ex, _logger);
			}
		}

		public ICoreInterop.Response StopAudioStream(CoreInteropRequest request)
		{
			return ExecuteCommand("audio_stream_stop", request);
		}

		private static string PtrToStringUtf8(nint ptr, int length)
		{
			return Marshal.PtrToStringUTF8(ptr, length);
		}

		[DllImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "execute_command", ExactSpelling = true)]
		[LibraryImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "execute_command")]
		[UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
		private unsafe static extern void CoreExecuteCommand(ICoreInterop.RequestBuffer* request, ICoreInterop.ResponseBuffer* response);

		[DllImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "execute_command_with_callback", ExactSpelling = true)]
		[LibraryImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "execute_command_with_callback")]
		[UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
		private unsafe static extern void CoreExecuteCommandWithCallback(ICoreInterop.RequestBuffer* nativeRequest, ICoreInterop.ResponseBuffer* nativeResponse, nint callbackPtr, nint userData);

		[DllImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "execute_command_with_binary", ExactSpelling = true)]
		[LibraryImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "execute_command_with_binary")]
		[UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
		private unsafe static extern void CoreExecuteCommandWithBinary(ICoreInterop.StreamingRequestBuffer* nativeRequest, ICoreInterop.ResponseBuffer* nativeResponse);

		[DllImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "audio_stream_start", ExactSpelling = true)]
		[LibraryImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "audio_stream_start")]
		[UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
		private unsafe static extern void CoreAudioStreamStart(ICoreInterop.RequestBuffer* request, ICoreInterop.ResponseBuffer* response);

		[DllImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "audio_stream_push", ExactSpelling = true)]
		[LibraryImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "audio_stream_push")]
		[UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
		private unsafe static extern void CoreAudioStreamPush(ICoreInterop.StreamingRequestBuffer* request, ICoreInterop.ResponseBuffer* response);

		[DllImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "audio_stream_stop", ExactSpelling = true)]
		[LibraryImport("Microsoft.AI.Foundry.Local.Core", EntryPoint = "audio_stream_stop")]
		[UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvCdecl) })]
		private unsafe static extern void CoreAudioStreamStop(ICoreInterop.RequestBuffer* request, ICoreInterop.ResponseBuffer* response);

		private static bool TryLoadNativeLibrary(string path, out nint handle)
		{
			return NativeLibrary.TryLoad(path, out handle);
		}
	}
	public class CoreInteropRequest
	{
		public Dictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
	}
	internal static class RequestExtensions
	{
		public static string ToJson(this CoreInteropRequest request)
		{
			return JsonSerializer.Serialize(request, JsonSerializationContext.Default.CoreInteropRequest);
		}
	}
	internal interface ICoreInterop
	{
		internal record Response
		{
			internal string? Data;

			internal string? Error;
		}

		internal delegate void CallbackFn(string callbackData);

		internal struct RequestBuffer
		{
			public nint Command;

			public int CommandLength;

			public nint Data;

			public int DataLength;
		}

		internal struct ResponseBuffer
		{
			public nint Data;

			public int DataLength;

			public nint Error;

			public int ErrorLength;
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate int NativeCallbackFn(nint data, int length, nint userData);

		internal struct StreamingRequestBuffer
		{
			public nint Command;

			public int CommandLength;

			public nint Data;

			public int DataLength;

			public nint BinaryData;

			public int BinaryDataLength;
		}

		Response ExecuteCommand(string commandName, CoreInteropRequest? commandInput = null);

		Response ExecuteCommandWithCallback(string commandName, CoreInteropRequest? commandInput, CallbackFn callback);

		Task<Response> ExecuteCommandAsync(string commandName, CoreInteropRequest? commandInput = null, CancellationToken? ct = null);

		Task<Response> ExecuteCommandWithCallbackAsync(string commandName, CoreInteropRequest? commandInput, CallbackFn callback, CancellationToken? ct = null);

		Response StartAudioStream(CoreInteropRequest request);

		Response PushAudioData(CoreInteropRequest request, ReadOnlyMemory<byte> audioData);

		Response StopAudioStream(CoreInteropRequest request);
	}
	internal interface IModelLoadManager
	{
		internal Task LoadAsync(string modelName, CancellationToken? ct = null);

		internal Task UnloadAsync(string modelName, CancellationToken? ct = null);

		internal Task<string[]> ListLoadedModelsAsync(CancellationToken? ct = null);
	}
	[JsonSerializable(typeof(ModelInfo))]
	[JsonSerializable(typeof(List<ModelInfo>))]
	[JsonSerializable(typeof(CoreInteropRequest))]
	[JsonSerializable(typeof(ChatCompletionCreateRequestExtended))]
	[JsonSerializable(typeof(ChatCompletionCreateResponse))]
	[JsonSerializable(typeof(AudioCreateTranscriptionRequest))]
	[JsonSerializable(typeof(AudioCreateTranscriptionResponse))]
	[JsonSerializable(typeof(EmbeddingCreateRequestExtended))]
	[JsonSerializable(typeof(EmbeddingCreateResponse))]
	[JsonSerializable(typeof(string[]))]
	[JsonSerializable(typeof(EpInfo[]))]
	[JsonSerializable(typeof(EpDownloadResult))]
	[JsonSerializable(typeof(JsonElement))]
	[JsonSerializable(typeof(ResponseFormatExtended))]
	[JsonSerializable(typeof(ToolChoice))]
	[JsonSerializable(typeof(ToolDefinition))]
	[JsonSerializable(typeof(IList<ToolDefinition>))]
	[JsonSerializable(typeof(FunctionDefinition))]
	[JsonSerializable(typeof(IList<FunctionDefinition>))]
	[JsonSerializable(typeof(PropertyDefinition))]
	[JsonSerializable(typeof(IList<PropertyDefinition>))]
	[JsonSerializable(typeof(LiveAudioTranscriptionRaw))]
	[JsonSerializable(typeof(CoreErrorResponse))]
	[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = false)]
	[GeneratedCode("System.Text.Json.SourceGeneration", "8.0.14.26413")]
	internal class JsonSerializationContext : JsonSerializerContext, IJsonTypeInfoResolver
	{
		private JsonTypeInfo<bool>? _Boolean;

		private JsonTypeInfo<bool?>? _NullableBoolean;

		private JsonTypeInfo<byte[]>? _ByteArray;

		private JsonTypeInfo<double>? _Double;

		private JsonTypeInfo<double?>? _NullableDouble;

		private JsonTypeInfo<float>? _Single;

		private JsonTypeInfo<float?>? _NullableSingle;

		private JsonTypeInfo<AudioCreateTranscriptionRequest>? _AudioCreateTranscriptionRequest;

		private JsonTypeInfo<ChatMessage>? _ChatMessage;

		private JsonTypeInfo<FileSearchFilter>? _FileSearchFilter;

		private JsonTypeInfo<FileSearchTool>? _FileSearchTool;

		private JsonTypeInfo<FunctionCall>? _FunctionCall;

		private JsonTypeInfo<FunctionDefinition>? _FunctionDefinition;

		private JsonTypeInfo<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema>? _JsonSchema;

		private JsonTypeInfo<RankingOptions>? _RankingOptions;

		private JsonTypeInfo<ResponseFormat>? _ResponseFormat;

		private JsonTypeInfo<StreamOptions>? _StreamOptions;

		private JsonTypeInfo<ToolCall>? _ToolCall;

		private JsonTypeInfo<ToolChoice>? _ToolChoice;

		private JsonTypeInfo<ToolChoice.FunctionTool>? _FunctionTool;

		private JsonTypeInfo<ToolDefinition>? _ToolDefinition;

		private JsonTypeInfo<AudioCreateTranscriptionResponse>? _AudioCreateTranscriptionResponse;

		private JsonTypeInfo<AudioCreateTranscriptionResponse.Segment>? _Segment;

		private JsonTypeInfo<AudioCreateTranscriptionResponse.WordSegment>? _WordSegment;

		private JsonTypeInfo<ChatCompletionCreateResponse>? _ChatCompletionCreateResponse;

		private JsonTypeInfo<CompletionTokensDetails>? _CompletionTokensDetails;

		private JsonTypeInfo<EmbeddingCreateResponse>? _EmbeddingCreateResponse;

		private JsonTypeInfo<EmbeddingResponse>? _EmbeddingResponse;

		private JsonTypeInfo<Error>? _Error;

		private JsonTypeInfo<OpenAIInfo>? _OpenAIInfo;

		private JsonTypeInfo<PromptTokensDetails>? _PromptTokensDetails;

		private JsonTypeInfo<RateLimitInfo>? _RateLimitInfo;

		private JsonTypeInfo<ResponseHeaderValues>? _ResponseHeaderValues;

		private JsonTypeInfo<UsageResponse>? _UsageResponse;

		private JsonTypeInfo<ChatChoiceResponse>? _ChatChoiceResponse;

		private JsonTypeInfo<ChatChoiceResponse.ChatLogProbsResponse>? _ChatLogProbsResponse;

		private JsonTypeInfo<ChatChoiceResponse.ContentItem>? _ContentItem;

		private JsonTypeInfo<ChatChoiceResponse.ContentItemBase>? _ContentItemBase;

		private JsonTypeInfo<ChatChoiceResponse.FinishDetailsResponse>? _FinishDetailsResponse;

		private JsonTypeInfo<PropertyDefinition>? _PropertyDefinition;

		private JsonTypeInfo<CoreInteropRequest>? _CoreInteropRequest;

		private JsonTypeInfo<DeviceType>? _DeviceType;

		private JsonTypeInfo<EpDownloadResult>? _EpDownloadResult;

		private JsonTypeInfo<EpInfo>? _EpInfo;

		private JsonTypeInfo<EpInfo[]>? _EpInfoArray;

		private JsonTypeInfo<ModelInfo>? _ModelInfo;

		private JsonTypeInfo<ModelSettings>? _ModelSettings;

		private JsonTypeInfo<ChatCompletionCreateRequestExtended>? _ChatCompletionCreateRequestExtended;

		private JsonTypeInfo<CoreErrorResponse>? _CoreErrorResponse;

		private JsonTypeInfo<EmbeddingCreateRequestExtended>? _EmbeddingCreateRequestExtended;

		private JsonTypeInfo<LiveAudioTranscriptionRaw>? _LiveAudioTranscriptionRaw;

		private JsonTypeInfo<ResponseFormatExtended>? _ResponseFormatExtended;

		private JsonTypeInfo<Parameter>? _Parameter;

		private JsonTypeInfo<Parameter[]>? _ParameterArray;

		private JsonTypeInfo<PromptTemplate>? _PromptTemplate;

		private JsonTypeInfo<Runtime>? _Runtime;

		private JsonTypeInfo<Dictionary<string, IEnumerable<string>>>? _DictionaryStringIEnumerableString;

		private JsonTypeInfo<Dictionary<string, string>>? _DictionaryStringString;

		private JsonTypeInfo<IDictionary<string, PropertyDefinition>>? _IDictionaryStringPropertyDefinition;

		private JsonTypeInfo<IEnumerable<string>>? _IEnumerableString;

		private JsonTypeInfo<IList<ChatMessage>>? _IListChatMessage;

		private JsonTypeInfo<IList<FunctionDefinition>>? _IListFunctionDefinition;

		private JsonTypeInfo<IList<ToolCall>>? _IListToolCall;

		private JsonTypeInfo<IList<ToolDefinition>>? _IListToolDefinition;

		private JsonTypeInfo<IList<PropertyDefinition>>? _IListPropertyDefinition;

		private JsonTypeInfo<IList<string>>? _IListString;

		private JsonTypeInfo<List<double>>? _ListDouble;

		private JsonTypeInfo<List<FileSearchFilter>>? _ListFileSearchFilter;

		private JsonTypeInfo<List<AudioCreateTranscriptionResponse.Segment>>? _ListSegment;

		private JsonTypeInfo<List<AudioCreateTranscriptionResponse.WordSegment>>? _ListWordSegment;

		private JsonTypeInfo<List<EmbeddingResponse>>? _ListEmbeddingResponse;

		private JsonTypeInfo<List<ChatChoiceResponse.ContentItem>>? _ListContentItem;

		private JsonTypeInfo<List<ChatChoiceResponse.ContentItemBase>>? _ListContentItemBase;

		private JsonTypeInfo<List<ChatChoiceResponse>>? _ListChatChoiceResponse;

		private JsonTypeInfo<List<ModelInfo>>? _ListModelInfo;

		private JsonTypeInfo<List<int>>? _ListInt32;

		private JsonTypeInfo<List<string>>? _ListString;

		private JsonTypeInfo<DateTimeOffset>? _DateTimeOffset;

		private JsonTypeInfo<DateTimeOffset?>? _NullableDateTimeOffset;

		private JsonTypeInfo<Stream>? _Stream;

		private JsonTypeInfo<HttpStatusCode>? _HttpStatusCode;

		private JsonTypeInfo<JsonElement>? _JsonElement;

		private JsonTypeInfo<int>? _Int32;

		private JsonTypeInfo<int?>? _NullableInt32;

		private JsonTypeInfo<long>? _Int64;

		private JsonTypeInfo<long?>? _NullableInt64;

		private JsonTypeInfo<object>? _Object;

		private JsonTypeInfo<string>? _String;

		private JsonTypeInfo<string[]>? _StringArray;

		private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			WriteIndented = false
		};

		private static readonly JsonEncodedText PropName_Prompt = JsonEncodedText.Encode("Prompt");

		private static readonly JsonEncodedText PropName_ResponseFormat = JsonEncodedText.Encode("ResponseFormat");

		private static readonly JsonEncodedText PropName_Language = JsonEncodedText.Encode("Language");

		private static readonly JsonEncodedText PropName_TimestampGranularities = JsonEncodedText.Encode("TimestampGranularities");

		private static readonly JsonEncodedText PropName_File = JsonEncodedText.Encode("File");

		private static readonly JsonEncodedText PropName_FileStream = JsonEncodedText.Encode("FileStream");

		private static readonly JsonEncodedText PropName_FileName = JsonEncodedText.Encode("FileName");

		private static readonly JsonEncodedText PropName_Model = JsonEncodedText.Encode("Model");

		private static readonly JsonEncodedText PropName_Temperature = JsonEncodedText.Encode("Temperature");

		private static readonly JsonEncodedText PropName_max_num_results = JsonEncodedText.Encode("max_num_results");

		private static readonly JsonEncodedText PropName_ranking_options = JsonEncodedText.Encode("ranking_options");

		private static readonly JsonEncodedText PropName_filters = JsonEncodedText.Encode("filters");

		private static readonly JsonEncodedText PropName_name = JsonEncodedText.Encode("name");

		private static readonly JsonEncodedText PropName_arguments = JsonEncodedText.Encode("arguments");

		private static readonly JsonEncodedText PropName_description = JsonEncodedText.Encode("description");

		private static readonly JsonEncodedText PropName_parameters = JsonEncodedText.Encode("parameters");

		private static readonly JsonEncodedText PropName_strict = JsonEncodedText.Encode("strict");

		private static readonly JsonEncodedText PropName_schema = JsonEncodedText.Encode("schema");

		private static readonly JsonEncodedText PropName_ranker = JsonEncodedText.Encode("ranker");

		private static readonly JsonEncodedText PropName_score_threshold = JsonEncodedText.Encode("score_threshold");

		private static readonly JsonEncodedText PropName_type = JsonEncodedText.Encode("type");

		private static readonly JsonEncodedText PropName_json_schema = JsonEncodedText.Encode("json_schema");

		private static readonly JsonEncodedText PropName_include_usage = JsonEncodedText.Encode("include_usage");

		private static readonly JsonEncodedText PropName_index = JsonEncodedText.Encode("index");

		private static readonly JsonEncodedText PropName_id = JsonEncodedText.Encode("id");

		private static readonly JsonEncodedText PropName_function = JsonEncodedText.Encode("function");

		private static readonly JsonEncodedText PropName_text = JsonEncodedText.Encode("text");

		private static readonly JsonEncodedText PropName_task = JsonEncodedText.Encode("task");

		private static readonly JsonEncodedText PropName_language = JsonEncodedText.Encode("language");

		private static readonly JsonEncodedText PropName_duration = JsonEncodedText.Encode("duration");

		private static readonly JsonEncodedText PropName_words = JsonEncodedText.Encode("words");

		private static readonly JsonEncodedText PropName_segments = JsonEncodedText.Encode("segments");

		private static readonly JsonEncodedText PropName_StreamEvent = JsonEncodedText.Encode("StreamEvent");

		private static readonly JsonEncodedText PropName_IsDelta = JsonEncodedText.Encode("IsDelta");

		private static readonly JsonEncodedText PropName_Successful = JsonEncodedText.Encode("Successful");

		private static readonly JsonEncodedText PropName_error = JsonEncodedText.Encode("error");

		private static readonly JsonEncodedText PropName_HttpStatusCode = JsonEncodedText.Encode("HttpStatusCode");

		private static readonly JsonEncodedText PropName_HeaderValues = JsonEncodedText.Encode("HeaderValues");

		private static readonly JsonEncodedText PropName_object = JsonEncodedText.Encode("object");

		private static readonly JsonEncodedText PropName_seek = JsonEncodedText.Encode("seek");

		private static readonly JsonEncodedText PropName_start = JsonEncodedText.Encode("start");

		private static readonly JsonEncodedText PropName_end = JsonEncodedText.Encode("end");

		private static readonly JsonEncodedText PropName_tokens = JsonEncodedText.Encode("tokens");

		private static readonly JsonEncodedText PropName_temperature = JsonEncodedText.Encode("temperature");

		private static readonly JsonEncodedText PropName_avg_logprob = JsonEncodedText.Encode("avg_logprob");

		private static readonly JsonEncodedText PropName_compression_ratio = JsonEncodedText.Encode("compression_ratio");

		private static readonly JsonEncodedText PropName_no_speech_prob = JsonEncodedText.Encode("no_speech_prob");

		private static readonly JsonEncodedText PropName_transient = JsonEncodedText.Encode("transient");

		private static readonly JsonEncodedText PropName_word = JsonEncodedText.Encode("word");

		private static readonly JsonEncodedText PropName_model = JsonEncodedText.Encode("model");

		private static readonly JsonEncodedText PropName_choices = JsonEncodedText.Encode("choices");

		private static readonly JsonEncodedText PropName_usage = JsonEncodedText.Encode("usage");

		private static readonly JsonEncodedText PropName_system_fingerprint = JsonEncodedText.Encode("system_fingerprint");

		private static readonly JsonEncodedText PropName_service_tier = JsonEncodedText.Encode("service_tier");

		private static readonly JsonEncodedText PropName_created = JsonEncodedText.Encode("created");

		private static readonly JsonEncodedText PropName_CreatedAt = JsonEncodedText.Encode("CreatedAt");

		private static readonly JsonEncodedText PropName_reasoning_tokens = JsonEncodedText.Encode("reasoning_tokens");

		private static readonly JsonEncodedText PropName_audio_tokens = JsonEncodedText.Encode("audio_tokens");

		private static readonly JsonEncodedText PropName_data = JsonEncodedText.Encode("data");

		private static readonly JsonEncodedText PropName_embedding = JsonEncodedText.Encode("embedding");

		private static readonly JsonEncodedText PropName_Organization = JsonEncodedText.Encode("Organization");

		private static readonly JsonEncodedText PropName_ProcessingMs = JsonEncodedText.Encode("ProcessingMs");

		private static readonly JsonEncodedText PropName_Version = JsonEncodedText.Encode("Version");

		private static readonly JsonEncodedText PropName_cached_tokens = JsonEncodedText.Encode("cached_tokens");

		private static readonly JsonEncodedText PropName_LimitRequests = JsonEncodedText.Encode("LimitRequests");

		private static readonly JsonEncodedText PropName_LimitTokens = JsonEncodedText.Encode("LimitTokens");

		private static readonly JsonEncodedText PropName_LimitTokensUsageBased = JsonEncodedText.Encode("LimitTokensUsageBased");

		private static readonly JsonEncodedText PropName_RemainingRequests = JsonEncodedText.Encode("RemainingRequests");

		private static readonly JsonEncodedText PropName_RemainingTokens = JsonEncodedText.Encode("RemainingTokens");

		private static readonly JsonEncodedText PropName_RemainingTokensUsageBased = JsonEncodedText.Encode("RemainingTokensUsageBased");

		private static readonly JsonEncodedText PropName_ResetRequests = JsonEncodedText.Encode("ResetRequests");

		private static readonly JsonEncodedText PropName_ResetTokens = JsonEncodedText.Encode("ResetTokens");

		private static readonly JsonEncodedText PropName_ResetTokensUsageBased = JsonEncodedText.Encode("ResetTokensUsageBased");

		private static readonly JsonEncodedText PropName_Date = JsonEncodedText.Encode("Date");

		private static readonly JsonEncodedText PropName_Connection = JsonEncodedText.Encode("Connection");

		private static readonly JsonEncodedText PropName_AccessControlAllowOrigin = JsonEncodedText.Encode("AccessControlAllowOrigin");

		private static readonly JsonEncodedText PropName_CacheControl = JsonEncodedText.Encode("CacheControl");

		private static readonly JsonEncodedText PropName_Vary = JsonEncodedText.Encode("Vary");

		private static readonly JsonEncodedText PropName_XRequestId = JsonEncodedText.Encode("XRequestId");

		private static readonly JsonEncodedText PropName_StrictTransportSecurity = JsonEncodedText.Encode("StrictTransportSecurity");

		private static readonly JsonEncodedText PropName_CFCacheStatus = JsonEncodedText.Encode("CFCacheStatus");

		private static readonly JsonEncodedText PropName_SetCookie = JsonEncodedText.Encode("SetCookie");

		private static readonly JsonEncodedText PropName_Server = JsonEncodedText.Encode("Server");

		private static readonly JsonEncodedText PropName_CF_RAY = JsonEncodedText.Encode("CF_RAY");

		private static readonly JsonEncodedText PropName_AltSvc = JsonEncodedText.Encode("AltSvc");

		private static readonly JsonEncodedText PropName_All = JsonEncodedText.Encode("All");

		private static readonly JsonEncodedText PropName_RateLimits = JsonEncodedText.Encode("RateLimits");

		private static readonly JsonEncodedText PropName_OpenAI = JsonEncodedText.Encode("OpenAI");

		private static readonly JsonEncodedText PropName_prompt_tokens = JsonEncodedText.Encode("prompt_tokens");

		private static readonly JsonEncodedText PropName_completion_tokens = JsonEncodedText.Encode("completion_tokens");

		private static readonly JsonEncodedText PropName_total_tokens = JsonEncodedText.Encode("total_tokens");

		private static readonly JsonEncodedText PropName_completion_tokens_details = JsonEncodedText.Encode("completion_tokens_details");

		private static readonly JsonEncodedText PropName_prompt_tokens_details = JsonEncodedText.Encode("prompt_tokens_details");

		private static readonly JsonEncodedText PropName_delta = JsonEncodedText.Encode("delta");

		private static readonly JsonEncodedText PropName_message = JsonEncodedText.Encode("message");

		private static readonly JsonEncodedText PropName_finish_reason = JsonEncodedText.Encode("finish_reason");

		private static readonly JsonEncodedText PropName_finish_details = JsonEncodedText.Encode("finish_details");

		private static readonly JsonEncodedText PropName_logprobs = JsonEncodedText.Encode("logprobs");

		private static readonly JsonEncodedText PropName_content = JsonEncodedText.Encode("content");

		private static readonly JsonEncodedText PropName_top_logprobs = JsonEncodedText.Encode("top_logprobs");

		private static readonly JsonEncodedText PropName_token = JsonEncodedText.Encode("token");

		private static readonly JsonEncodedText PropName_logprob = JsonEncodedText.Encode("logprob");

		private static readonly JsonEncodedText PropName_bytes = JsonEncodedText.Encode("bytes");

		private static readonly JsonEncodedText PropName_stop = JsonEncodedText.Encode("stop");

		private static readonly JsonEncodedText PropName_Params = JsonEncodedText.Encode("Params");

		private static readonly JsonEncodedText PropName_Success = JsonEncodedText.Encode("Success");

		private static readonly JsonEncodedText PropName_Status = JsonEncodedText.Encode("Status");

		private static readonly JsonEncodedText PropName_RegisteredEps = JsonEncodedText.Encode("RegisteredEps");

		private static readonly JsonEncodedText PropName_FailedEps = JsonEncodedText.Encode("FailedEps");

		private static readonly JsonEncodedText PropName_Name = JsonEncodedText.Encode("Name");

		private static readonly JsonEncodedText PropName_IsRegistered = JsonEncodedText.Encode("IsRegistered");

		private static readonly JsonEncodedText PropName_version = JsonEncodedText.Encode("version");

		private static readonly JsonEncodedText PropName_alias = JsonEncodedText.Encode("alias");

		private static readonly JsonEncodedText PropName_displayName = JsonEncodedText.Encode("displayName");

		private static readonly JsonEncodedText PropName_providerType = JsonEncodedText.Encode("providerType");

		private static readonly JsonEncodedText PropName_uri = JsonEncodedText.Encode("uri");

		private static readonly JsonEncodedText PropName_modelType = JsonEncodedText.Encode("modelType");

		private static readonly JsonEncodedText PropName_promptTemplate = JsonEncodedText.Encode("promptTemplate");

		private static readonly JsonEncodedText PropName_publisher = JsonEncodedText.Encode("publisher");

		private static readonly JsonEncodedText PropName_modelSettings = JsonEncodedText.Encode("modelSettings");

		private static readonly JsonEncodedText PropName_license = JsonEncodedText.Encode("license");

		private static readonly JsonEncodedText PropName_licenseDescription = JsonEncodedText.Encode("licenseDescription");

		private static readonly JsonEncodedText PropName_cached = JsonEncodedText.Encode("cached");

		private static readonly JsonEncodedText PropName_runtime = JsonEncodedText.Encode("runtime");

		private static readonly JsonEncodedText PropName_fileSizeMb = JsonEncodedText.Encode("fileSizeMb");

		private static readonly JsonEncodedText PropName_supportsToolCalling = JsonEncodedText.Encode("supportsToolCalling");

		private static readonly JsonEncodedText PropName_maxOutputTokens = JsonEncodedText.Encode("maxOutputTokens");

		private static readonly JsonEncodedText PropName_minFLVersion = JsonEncodedText.Encode("minFLVersion");

		private static readonly JsonEncodedText PropName_createdAt = JsonEncodedText.Encode("createdAt");

		private static readonly JsonEncodedText PropName_contextLength = JsonEncodedText.Encode("contextLength");

		private static readonly JsonEncodedText PropName_inputModalities = JsonEncodedText.Encode("inputModalities");

		private static readonly JsonEncodedText PropName_outputModalities = JsonEncodedText.Encode("outputModalities");

		private static readonly JsonEncodedText PropName_capabilities = JsonEncodedText.Encode("capabilities");

		private static readonly JsonEncodedText PropName_code = JsonEncodedText.Encode("code");

		private static readonly JsonEncodedText PropName_isTransient = JsonEncodedText.Encode("isTransient");

		private static readonly JsonEncodedText PropName_input = JsonEncodedText.Encode("input");

		private static readonly JsonEncodedText PropName_dimensions = JsonEncodedText.Encode("dimensions");

		private static readonly JsonEncodedText PropName_encoding_format = JsonEncodedText.Encode("encoding_format");

		private static readonly JsonEncodedText PropName_is_final = JsonEncodedText.Encode("is_final");

		private static readonly JsonEncodedText PropName_start_time = JsonEncodedText.Encode("start_time");

		private static readonly JsonEncodedText PropName_end_time = JsonEncodedText.Encode("end_time");

		private static readonly JsonEncodedText PropName_lark_grammar = JsonEncodedText.Encode("lark_grammar");

		private static readonly JsonEncodedText PropName_Value = JsonEncodedText.Encode("Value");

		private static readonly JsonEncodedText PropName_system = JsonEncodedText.Encode("system");

		private static readonly JsonEncodedText PropName_user = JsonEncodedText.Encode("user");

		private static readonly JsonEncodedText PropName_assistant = JsonEncodedText.Encode("assistant");

		private static readonly JsonEncodedText PropName_prompt = JsonEncodedText.Encode("prompt");

		private static readonly JsonEncodedText PropName_deviceType = JsonEncodedText.Encode("deviceType");

		private static readonly JsonEncodedText PropName_executionProvider = JsonEncodedText.Encode("executionProvider");

		private static readonly JsonEncodedText PropName_CanRead = JsonEncodedText.Encode("CanRead");

		private static readonly JsonEncodedText PropName_CanSeek = JsonEncodedText.Encode("CanSeek");

		private static readonly JsonEncodedText PropName_CanTimeout = JsonEncodedText.Encode("CanTimeout");

		private static readonly JsonEncodedText PropName_CanWrite = JsonEncodedText.Encode("CanWrite");

		private static readonly JsonEncodedText PropName_Length = JsonEncodedText.Encode("Length");

		private static readonly JsonEncodedText PropName_Position = JsonEncodedText.Encode("Position");

		private static readonly JsonEncodedText PropName_ReadTimeout = JsonEncodedText.Encode("ReadTimeout");

		private static readonly JsonEncodedText PropName_WriteTimeout = JsonEncodedText.Encode("WriteTimeout");

		public JsonTypeInfo<bool> Boolean => _Boolean ?? (_Boolean = (JsonTypeInfo<bool>)Options.GetTypeInfo(typeof(bool)));

		public JsonTypeInfo<bool?> NullableBoolean => _NullableBoolean ?? (_NullableBoolean = (JsonTypeInfo<bool?>)Options.GetTypeInfo(typeof(bool?)));

		public JsonTypeInfo<byte[]> ByteArray => _ByteArray ?? (_ByteArray = (JsonTypeInfo<byte[]>)Options.GetTypeInfo(typeof(byte[])));

		public JsonTypeInfo<double> Double => _Double ?? (_Double = (JsonTypeInfo<double>)Options.GetTypeInfo(typeof(double)));

		public JsonTypeInfo<double?> NullableDouble => _NullableDouble ?? (_NullableDouble = (JsonTypeInfo<double?>)Options.GetTypeInfo(typeof(double?)));

		public JsonTypeInfo<float> Single => _Single ?? (_Single = (JsonTypeInfo<float>)Options.GetTypeInfo(typeof(float)));

		public JsonTypeInfo<float?> NullableSingle => _NullableSingle ?? (_NullableSingle = (JsonTypeInfo<float?>)Options.GetTypeInfo(typeof(float?)));

		public JsonTypeInfo<AudioCreateTranscriptionRequest> AudioCreateTranscriptionRequest => _AudioCreateTranscriptionRequest ?? (_AudioCreateTranscriptionRequest = (JsonTypeInfo<AudioCreateTranscriptionRequest>)Options.GetTypeInfo(typeof(AudioCreateTranscriptionRequest)));

		public JsonTypeInfo<ChatMessage> ChatMessage => _ChatMessage ?? (_ChatMessage = (JsonTypeInfo<ChatMessage>)Options.GetTypeInfo(typeof(ChatMessage)));

		public JsonTypeInfo<FileSearchFilter> FileSearchFilter => _FileSearchFilter ?? (_FileSearchFilter = (JsonTypeInfo<FileSearchFilter>)Options.GetTypeInfo(typeof(FileSearchFilter)));

		public JsonTypeInfo<FileSearchTool> FileSearchTool => _FileSearchTool ?? (_FileSearchTool = (JsonTypeInfo<FileSearchTool>)Options.GetTypeInfo(typeof(FileSearchTool)));

		public JsonTypeInfo<FunctionCall> FunctionCall => _FunctionCall ?? (_FunctionCall = (JsonTypeInfo<FunctionCall>)Options.GetTypeInfo(typeof(FunctionCall)));

		public JsonTypeInfo<FunctionDefinition> FunctionDefinition => _FunctionDefinition ?? (_FunctionDefinition = (JsonTypeInfo<FunctionDefinition>)Options.GetTypeInfo(typeof(FunctionDefinition)));

		public JsonTypeInfo<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema> JsonSchema => _JsonSchema ?? (_JsonSchema = (JsonTypeInfo<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema>)Options.GetTypeInfo(typeof(Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)));

		public JsonTypeInfo<RankingOptions> RankingOptions => _RankingOptions ?? (_RankingOptions = (JsonTypeInfo<RankingOptions>)Options.GetTypeInfo(typeof(RankingOptions)));

		public JsonTypeInfo<ResponseFormat> ResponseFormat => _ResponseFormat ?? (_ResponseFormat = (JsonTypeInfo<ResponseFormat>)Options.GetTypeInfo(typeof(ResponseFormat)));

		public JsonTypeInfo<StreamOptions> StreamOptions => _StreamOptions ?? (_StreamOptions = (JsonTypeInfo<StreamOptions>)Options.GetTypeInfo(typeof(StreamOptions)));

		public JsonTypeInfo<ToolCall> ToolCall => _ToolCall ?? (_ToolCall = (JsonTypeInfo<ToolCall>)Options.GetTypeInfo(typeof(ToolCall)));

		public JsonTypeInfo<ToolChoice> ToolChoice => _ToolChoice ?? (_ToolChoice = (JsonTypeInfo<ToolChoice>)Options.GetTypeInfo(typeof(ToolChoice)));

		public JsonTypeInfo<ToolChoice.FunctionTool> FunctionTool => _FunctionTool ?? (_FunctionTool = (JsonTypeInfo<ToolChoice.FunctionTool>)Options.GetTypeInfo(typeof(ToolChoice.FunctionTool)));

		public JsonTypeInfo<ToolDefinition> ToolDefinition => _ToolDefinition ?? (_ToolDefinition = (JsonTypeInfo<ToolDefinition>)Options.GetTypeInfo(typeof(ToolDefinition)));

		public JsonTypeInfo<AudioCreateTranscriptionResponse> AudioCreateTranscriptionResponse => _AudioCreateTranscriptionResponse ?? (_AudioCreateTranscriptionResponse = (JsonTypeInfo<AudioCreateTranscriptionResponse>)Options.GetTypeInfo(typeof(AudioCreateTranscriptionResponse)));

		public JsonTypeInfo<AudioCreateTranscriptionResponse.Segment> Segment => _Segment ?? (_Segment = (JsonTypeInfo<AudioCreateTranscriptionResponse.Segment>)Options.GetTypeInfo(typeof(AudioCreateTranscriptionResponse.Segment)));

		public JsonTypeInfo<AudioCreateTranscriptionResponse.WordSegment> WordSegment => _WordSegment ?? (_WordSegment = (JsonTypeInfo<AudioCreateTranscriptionResponse.WordSegment>)Options.GetTypeInfo(typeof(AudioCreateTranscriptionResponse.WordSegment)));

		public JsonTypeInfo<ChatCompletionCreateResponse> ChatCompletionCreateResponse => _ChatCompletionCreateResponse ?? (_ChatCompletionCreateResponse = (JsonTypeInfo<ChatCompletionCreateResponse>)Options.GetTypeInfo(typeof(ChatCompletionCreateResponse)));

		public JsonTypeInfo<CompletionTokensDetails> CompletionTokensDetails => _CompletionTokensDetails ?? (_CompletionTokensDetails = (JsonTypeInfo<CompletionTokensDetails>)Options.GetTypeInfo(typeof(CompletionTokensDetails)));

		public JsonTypeInfo<EmbeddingCreateResponse> EmbeddingCreateResponse => _EmbeddingCreateResponse ?? (_EmbeddingCreateResponse = (JsonTypeInfo<EmbeddingCreateResponse>)Options.GetTypeInfo(typeof(EmbeddingCreateResponse)));

		public JsonTypeInfo<EmbeddingResponse> EmbeddingResponse => _EmbeddingResponse ?? (_EmbeddingResponse = (JsonTypeInfo<EmbeddingResponse>)Options.GetTypeInfo(typeof(EmbeddingResponse)));

		public JsonTypeInfo<Error> Error => _Error ?? (_Error = (JsonTypeInfo<Error>)Options.GetTypeInfo(typeof(Error)));

		public JsonTypeInfo<OpenAIInfo> OpenAIInfo => _OpenAIInfo ?? (_OpenAIInfo = (JsonTypeInfo<OpenAIInfo>)Options.GetTypeInfo(typeof(OpenAIInfo)));

		public JsonTypeInfo<PromptTokensDetails> PromptTokensDetails => _PromptTokensDetails ?? (_PromptTokensDetails = (JsonTypeInfo<PromptTokensDetails>)Options.GetTypeInfo(typeof(PromptTokensDetails)));

		public JsonTypeInfo<RateLimitInfo> RateLimitInfo => _RateLimitInfo ?? (_RateLimitInfo = (JsonTypeInfo<RateLimitInfo>)Options.GetTypeInfo(typeof(RateLimitInfo)));

		public JsonTypeInfo<ResponseHeaderValues> ResponseHeaderValues => _ResponseHeaderValues ?? (_ResponseHeaderValues = (JsonTypeInfo<ResponseHeaderValues>)Options.GetTypeInfo(typeof(ResponseHeaderValues)));

		public JsonTypeInfo<UsageResponse> UsageResponse => _UsageResponse ?? (_UsageResponse = (JsonTypeInfo<UsageResponse>)Options.GetTypeInfo(typeof(UsageResponse)));

		public JsonTypeInfo<ChatChoiceResponse> ChatChoiceResponse => _ChatChoiceResponse ?? (_ChatChoiceResponse = (JsonTypeInfo<ChatChoiceResponse>)Options.GetTypeInfo(typeof(ChatChoiceResponse)));

		public JsonTypeInfo<ChatChoiceResponse.ChatLogProbsResponse> ChatLogProbsResponse => _ChatLogProbsResponse ?? (_ChatLogProbsResponse = (JsonTypeInfo<ChatChoiceResponse.ChatLogProbsResponse>)Options.GetTypeInfo(typeof(ChatChoiceResponse.ChatLogProbsResponse)));

		public JsonTypeInfo<ChatChoiceResponse.ContentItem> ContentItem => _ContentItem ?? (_ContentItem = (JsonTypeInfo<ChatChoiceResponse.ContentItem>)Options.GetTypeInfo(typeof(ChatChoiceResponse.ContentItem)));

		public JsonTypeInfo<ChatChoiceResponse.ContentItemBase> ContentItemBase => _ContentItemBase ?? (_ContentItemBase = (JsonTypeInfo<ChatChoiceResponse.ContentItemBase>)Options.GetTypeInfo(typeof(ChatChoiceResponse.ContentItemBase)));

		public JsonTypeInfo<ChatChoiceResponse.FinishDetailsResponse> FinishDetailsResponse => _FinishDetailsResponse ?? (_FinishDetailsResponse = (JsonTypeInfo<ChatChoiceResponse.FinishDetailsResponse>)Options.GetTypeInfo(typeof(ChatChoiceResponse.FinishDetailsResponse)));

		public JsonTypeInfo<PropertyDefinition> PropertyDefinition => _PropertyDefinition ?? (_PropertyDefinition = (JsonTypeInfo<PropertyDefinition>)Options.GetTypeInfo(typeof(PropertyDefinition)));

		public JsonTypeInfo<CoreInteropRequest> CoreInteropRequest => _CoreInteropRequest ?? (_CoreInteropRequest = (JsonTypeInfo<CoreInteropRequest>)Options.GetTypeInfo(typeof(CoreInteropRequest)));

		public JsonTypeInfo<DeviceType> DeviceType => _DeviceType ?? (_DeviceType = (JsonTypeInfo<DeviceType>)Options.GetTypeInfo(typeof(DeviceType)));

		public JsonTypeInfo<EpDownloadResult> EpDownloadResult => _EpDownloadResult ?? (_EpDownloadResult = (JsonTypeInfo<EpDownloadResult>)Options.GetTypeInfo(typeof(EpDownloadResult)));

		public JsonTypeInfo<EpInfo> EpInfo => _EpInfo ?? (_EpInfo = (JsonTypeInfo<EpInfo>)Options.GetTypeInfo(typeof(EpInfo)));

		public JsonTypeInfo<EpInfo[]> EpInfoArray => _EpInfoArray ?? (_EpInfoArray = (JsonTypeInfo<EpInfo[]>)Options.GetTypeInfo(typeof(EpInfo[])));

		public JsonTypeInfo<ModelInfo> ModelInfo => _ModelInfo ?? (_ModelInfo = (JsonTypeInfo<ModelInfo>)Options.GetTypeInfo(typeof(ModelInfo)));

		public JsonTypeInfo<ModelSettings> ModelSettings => _ModelSettings ?? (_ModelSettings = (JsonTypeInfo<ModelSettings>)Options.GetTypeInfo(typeof(ModelSettings)));

		public JsonTypeInfo<ChatCompletionCreateRequestExtended> ChatCompletionCreateRequestExtended => _ChatCompletionCreateRequestExtended ?? (_ChatCompletionCreateRequestExtended = (JsonTypeInfo<ChatCompletionCreateRequestExtended>)Options.GetTypeInfo(typeof(ChatCompletionCreateRequestExtended)));

		public JsonTypeInfo<CoreErrorResponse> CoreErrorResponse => _CoreErrorResponse ?? (_CoreErrorResponse = (JsonTypeInfo<CoreErrorResponse>)Options.GetTypeInfo(typeof(CoreErrorResponse)));

		public JsonTypeInfo<EmbeddingCreateRequestExtended> EmbeddingCreateRequestExtended => _EmbeddingCreateRequestExtended ?? (_EmbeddingCreateRequestExtended = (JsonTypeInfo<EmbeddingCreateRequestExtended>)Options.GetTypeInfo(typeof(EmbeddingCreateRequestExtended)));

		public JsonTypeInfo<LiveAudioTranscriptionRaw> LiveAudioTranscriptionRaw => _LiveAudioTranscriptionRaw ?? (_LiveAudioTranscriptionRaw = (JsonTypeInfo<LiveAudioTranscriptionRaw>)Options.GetTypeInfo(typeof(LiveAudioTranscriptionRaw)));

		public JsonTypeInfo<ResponseFormatExtended> ResponseFormatExtended => _ResponseFormatExtended ?? (_ResponseFormatExtended = (JsonTypeInfo<ResponseFormatExtended>)Options.GetTypeInfo(typeof(ResponseFormatExtended)));

		public JsonTypeInfo<Parameter> Parameter => _Parameter ?? (_Parameter = (JsonTypeInfo<Parameter>)Options.GetTypeInfo(typeof(Parameter)));

		public JsonTypeInfo<Parameter[]> ParameterArray => _ParameterArray ?? (_ParameterArray = (JsonTypeInfo<Parameter[]>)Options.GetTypeInfo(typeof(Parameter[])));

		public JsonTypeInfo<PromptTemplate> PromptTemplate => _PromptTemplate ?? (_PromptTemplate = (JsonTypeInfo<PromptTemplate>)Options.GetTypeInfo(typeof(PromptTemplate)));

		public JsonTypeInfo<Runtime> Runtime => _Runtime ?? (_Runtime = (JsonTypeInfo<Runtime>)Options.GetTypeInfo(typeof(Runtime)));

		public JsonTypeInfo<Dictionary<string, IEnumerable<string>>> DictionaryStringIEnumerableString => _DictionaryStringIEnumerableString ?? (_DictionaryStringIEnumerableString = (JsonTypeInfo<Dictionary<string, IEnumerable<string>>>)Options.GetTypeInfo(typeof(Dictionary<string, IEnumerable<string>>)));

		public JsonTypeInfo<Dictionary<string, string>> DictionaryStringString => _DictionaryStringString ?? (_DictionaryStringString = (JsonTypeInfo<Dictionary<string, string>>)Options.GetTypeInfo(typeof(Dictionary<string, string>)));

		public JsonTypeInfo<IDictionary<string, PropertyDefinition>> IDictionaryStringPropertyDefinition => _IDictionaryStringPropertyDefinition ?? (_IDictionaryStringPropertyDefinition = (JsonTypeInfo<IDictionary<string, PropertyDefinition>>)Options.GetTypeInfo(typeof(IDictionary<string, PropertyDefinition>)));

		public JsonTypeInfo<IEnumerable<string>> IEnumerableString => _IEnumerableString ?? (_IEnumerableString = (JsonTypeInfo<IEnumerable<string>>)Options.GetTypeInfo(typeof(IEnumerable<string>)));

		public JsonTypeInfo<IList<ChatMessage>> IListChatMessage => _IListChatMessage ?? (_IListChatMessage = (JsonTypeInfo<IList<ChatMessage>>)Options.GetTypeInfo(typeof(IList<ChatMessage>)));

		public JsonTypeInfo<IList<FunctionDefinition>> IListFunctionDefinition => _IListFunctionDefinition ?? (_IListFunctionDefinition = (JsonTypeInfo<IList<FunctionDefinition>>)Options.GetTypeInfo(typeof(IList<FunctionDefinition>)));

		public JsonTypeInfo<IList<ToolCall>> IListToolCall => _IListToolCall ?? (_IListToolCall = (JsonTypeInfo<IList<ToolCall>>)Options.GetTypeInfo(typeof(IList<ToolCall>)));

		public JsonTypeInfo<IList<ToolDefinition>> IListToolDefinition => _IListToolDefinition ?? (_IListToolDefinition = (JsonTypeInfo<IList<ToolDefinition>>)Options.GetTypeInfo(typeof(IList<ToolDefinition>)));

		public JsonTypeInfo<IList<PropertyDefinition>> IListPropertyDefinition => _IListPropertyDefinition ?? (_IListPropertyDefinition = (JsonTypeInfo<IList<PropertyDefinition>>)Options.GetTypeInfo(typeof(IList<PropertyDefinition>)));

		public JsonTypeInfo<IList<string>> IListString => _IListString ?? (_IListString = (JsonTypeInfo<IList<string>>)Options.GetTypeInfo(typeof(IList<string>)));

		public JsonTypeInfo<List<double>> ListDouble => _ListDouble ?? (_ListDouble = (JsonTypeInfo<List<double>>)Options.GetTypeInfo(typeof(List<double>)));

		public JsonTypeInfo<List<FileSearchFilter>> ListFileSearchFilter => _ListFileSearchFilter ?? (_ListFileSearchFilter = (JsonTypeInfo<List<FileSearchFilter>>)Options.GetTypeInfo(typeof(List<FileSearchFilter>)));

		public JsonTypeInfo<List<AudioCreateTranscriptionResponse.Segment>> ListSegment => _ListSegment ?? (_ListSegment = (JsonTypeInfo<List<AudioCreateTranscriptionResponse.Segment>>)Options.GetTypeInfo(typeof(List<AudioCreateTranscriptionResponse.Segment>)));

		public JsonTypeInfo<List<AudioCreateTranscriptionResponse.WordSegment>> ListWordSegment => _ListWordSegment ?? (_ListWordSegment = (JsonTypeInfo<List<AudioCreateTranscriptionResponse.WordSegment>>)Options.GetTypeInfo(typeof(List<AudioCreateTranscriptionResponse.WordSegment>)));

		public JsonTypeInfo<List<EmbeddingResponse>> ListEmbeddingResponse => _ListEmbeddingResponse ?? (_ListEmbeddingResponse = (JsonTypeInfo<List<EmbeddingResponse>>)Options.GetTypeInfo(typeof(List<EmbeddingResponse>)));

		public JsonTypeInfo<List<ChatChoiceResponse.ContentItem>> ListContentItem => _ListContentItem ?? (_ListContentItem = (JsonTypeInfo<List<ChatChoiceResponse.ContentItem>>)Options.GetTypeInfo(typeof(List<ChatChoiceResponse.ContentItem>)));

		public JsonTypeInfo<List<ChatChoiceResponse.ContentItemBase>> ListContentItemBase => _ListContentItemBase ?? (_ListContentItemBase = (JsonTypeInfo<List<ChatChoiceResponse.ContentItemBase>>)Options.GetTypeInfo(typeof(List<ChatChoiceResponse.ContentItemBase>)));

		public JsonTypeInfo<List<ChatChoiceResponse>> ListChatChoiceResponse => _ListChatChoiceResponse ?? (_ListChatChoiceResponse = (JsonTypeInfo<List<ChatChoiceResponse>>)Options.GetTypeInfo(typeof(List<ChatChoiceResponse>)));

		public JsonTypeInfo<List<ModelInfo>> ListModelInfo => _ListModelInfo ?? (_ListModelInfo = (JsonTypeInfo<List<ModelInfo>>)Options.GetTypeInfo(typeof(List<ModelInfo>)));

		public JsonTypeInfo<List<int>> ListInt32 => _ListInt32 ?? (_ListInt32 = (JsonTypeInfo<List<int>>)Options.GetTypeInfo(typeof(List<int>)));

		public JsonTypeInfo<List<string>> ListString => _ListString ?? (_ListString = (JsonTypeInfo<List<string>>)Options.GetTypeInfo(typeof(List<string>)));

		public JsonTypeInfo<DateTimeOffset> DateTimeOffset => _DateTimeOffset ?? (_DateTimeOffset = (JsonTypeInfo<DateTimeOffset>)Options.GetTypeInfo(typeof(DateTimeOffset)));

		public JsonTypeInfo<DateTimeOffset?> NullableDateTimeOffset => _NullableDateTimeOffset ?? (_NullableDateTimeOffset = (JsonTypeInfo<DateTimeOffset?>)Options.GetTypeInfo(typeof(DateTimeOffset?)));

		public JsonTypeInfo<Stream> Stream => _Stream ?? (_Stream = (JsonTypeInfo<Stream>)Options.GetTypeInfo(typeof(Stream)));

		public JsonTypeInfo<HttpStatusCode> HttpStatusCode => _HttpStatusCode ?? (_HttpStatusCode = (JsonTypeInfo<HttpStatusCode>)Options.GetTypeInfo(typeof(HttpStatusCode)));

		public JsonTypeInfo<JsonElement> JsonElement => _JsonElement ?? (_JsonElement = (JsonTypeInfo<JsonElement>)Options.GetTypeInfo(typeof(JsonElement)));

		public JsonTypeInfo<int> Int32 => _Int32 ?? (_Int32 = (JsonTypeInfo<int>)Options.GetTypeInfo(typeof(int)));

		public JsonTypeInfo<int?> NullableInt32 => _NullableInt32 ?? (_NullableInt32 = (JsonTypeInfo<int?>)Options.GetTypeInfo(typeof(int?)));

		public JsonTypeInfo<long> Int64 => _Int64 ?? (_Int64 = (JsonTypeInfo<long>)Options.GetTypeInfo(typeof(long)));

		public JsonTypeInfo<long?> NullableInt64 => _NullableInt64 ?? (_NullableInt64 = (JsonTypeInfo<long?>)Options.GetTypeInfo(typeof(long?)));

		public JsonTypeInfo<object> Object => _Object ?? (_Object = (JsonTypeInfo<object>)Options.GetTypeInfo(typeof(object)));

		public JsonTypeInfo<string> String => _String ?? (_String = (JsonTypeInfo<string>)Options.GetTypeInfo(typeof(string)));

		public JsonTypeInfo<string[]> StringArray => _StringArray ?? (_StringArray = (JsonTypeInfo<string[]>)Options.GetTypeInfo(typeof(string[])));

		public static JsonSerializationContext Default { get; } = new JsonSerializationContext(new JsonSerializerOptions(s_defaultOptions));

		protected override JsonSerializerOptions? GeneratedSerializerOptions { get; } = s_defaultOptions;

		private JsonTypeInfo<bool> Create_Boolean(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<bool> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool>(options, JsonMetadataServices.BooleanConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<bool?> Create_NullableBoolean(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<bool?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<bool>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<byte[]> Create_ByteArray(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<byte[]> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<byte[]>(options, JsonMetadataServices.ByteArrayConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<double> Create_Double(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<double> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<double>(options, JsonMetadataServices.DoubleConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<double?> Create_NullableDouble(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<double?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<double>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<double?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<float> Create_Single(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<float> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<float>(options, JsonMetadataServices.SingleConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<float?> Create_NullableSingle(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<float?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<float>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<float?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<AudioCreateTranscriptionRequest> Create_AudioCreateTranscriptionRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioCreateTranscriptionRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioCreateTranscriptionRequest> objectInfo = new JsonObjectInfoValues<AudioCreateTranscriptionRequest>
				{
					ObjectCreator = () => new AudioCreateTranscriptionRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioCreateTranscriptionRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = AudioCreateTranscriptionRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioCreateTranscriptionRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[9];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).Prompt,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).Prompt = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Prompt",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).ResponseFormat,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).ResponseFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseFormat",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).Language,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).Language = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Language",
				JsonPropertyName = null
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<List<string>> propertyInfo4 = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).TimestampGranularities,
				Setter = (object obj, List<string>? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).TimestampGranularities = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TimestampGranularities",
				JsonPropertyName = null
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<byte[]> propertyInfo5 = new JsonPropertyInfoValues<byte[]>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).File,
				Setter = (object obj, byte[]? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).File = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "File",
				JsonPropertyName = null
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<Stream> propertyInfo6 = new JsonPropertyInfoValues<Stream>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).FileStream,
				Setter = (object obj, Stream? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).FileStream = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FileStream",
				JsonPropertyName = null
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).FileName,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).FileName = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FileName",
				JsonPropertyName = null
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = null
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<float?> propertyInfo9 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionRequest),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionRequest)obj).Temperature,
				Setter = (object obj, float? value) =>
				{
					((AudioCreateTranscriptionRequest)obj).Temperature = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Temperature",
				JsonPropertyName = null
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			return array;
		}

		private void AudioCreateTranscriptionRequestSerializeHandler(Utf8JsonWriter writer, AudioCreateTranscriptionRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string prompt = value.Prompt;
			if (prompt != null)
			{
				writer.WriteString(PropName_Prompt, prompt);
			}
			string responseFormat = value.ResponseFormat;
			if (responseFormat != null)
			{
				writer.WriteString(PropName_ResponseFormat, responseFormat);
			}
			string language = value.Language;
			if (language != null)
			{
				writer.WriteString(PropName_Language, language);
			}
			List<string> timestampGranularities = value.TimestampGranularities;
			if (timestampGranularities != null)
			{
				writer.WritePropertyName(PropName_TimestampGranularities);
				ListStringSerializeHandler(writer, timestampGranularities);
			}
			byte[] file = value.File;
			if (file != null)
			{
				writer.WriteBase64String(PropName_File, file);
			}
			Stream fileStream = value.FileStream;
			if (fileStream != null)
			{
				writer.WritePropertyName(PropName_FileStream);
				StreamSerializeHandler(writer, fileStream);
			}
			string fileName = value.FileName;
			if (fileName != null)
			{
				writer.WriteString(PropName_FileName, fileName);
			}
			string model = value.Model;
			if (model != null)
			{
				writer.WriteString(PropName_Model, model);
			}
			float? temperature = value.Temperature;
			if (temperature.HasValue)
			{
				writer.WritePropertyName(PropName_Temperature);
				JsonSerializer.Serialize(writer, temperature, NullableSingle);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatMessage> Create_ChatMessage(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatMessage> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatMessage> objectInfo = new JsonObjectInfoValues<ChatMessage>
				{
					ObjectCreator = () => new ChatMessage(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ChatMessagePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ChatMessagePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[9];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = (object obj) => ((ChatMessage)obj).Role,
				Setter = (object obj, string? value) =>
				{
					((ChatMessage)obj).Role = value;
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
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Content",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = (object obj) => ((ChatMessage)obj).ReasoningContent,
				Setter = (object obj, string? value) =>
				{
					((ChatMessage)obj).ReasoningContent = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ReasoningContent",
				JsonPropertyName = "reasoning_content"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<IList<MessageContent>> propertyInfo4 = new JsonPropertyInfoValues<IList<MessageContent>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Contents",
				JsonPropertyName = null
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<object> propertyInfo5 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = (object obj) => ((ChatMessage)obj).ContentCalculated,
				Setter = (object obj, object? value) =>
				{
					((ChatMessage)obj).ContentCalculated = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentCalculated",
				JsonPropertyName = "content"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = (object obj) => ((ChatMessage)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((ChatMessage)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = (object obj) => ((ChatMessage)obj).ToolCallId,
				Setter = (object obj, string? value) =>
				{
					((ChatMessage)obj).ToolCallId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolCallId",
				JsonPropertyName = "tool_call_id"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<FunctionCall> propertyInfo8 = new JsonPropertyInfoValues<FunctionCall>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = (object obj) => ((ChatMessage)obj).FunctionCall,
				Setter = (object obj, FunctionCall? value) =>
				{
					((ChatMessage)obj).FunctionCall = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FunctionCall",
				JsonPropertyName = "function_call"
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<IList<ToolCall>> propertyInfo9 = new JsonPropertyInfoValues<IList<ToolCall>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatMessage),
				Converter = null,
				Getter = (object obj) => ((ChatMessage)obj).ToolCalls,
				Setter = (object obj, IList<ToolCall>? value) =>
				{
					((ChatMessage)obj).ToolCalls = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolCalls",
				JsonPropertyName = "tool_calls"
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			return array;
		}

		private JsonTypeInfo<FileSearchFilter> Create_FileSearchFilter(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<FileSearchFilter> jsonTypeInfo))
			{
				JsonObjectInfoValues<FileSearchFilter> objectInfo = new JsonObjectInfoValues<FileSearchFilter>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new FileSearchFilter((string)args[0]),
					PropertyMetadataInitializer = (JsonSerializerContext _) => FileSearchFilterPropInit(options),
					ConstructorParameterMetadataInitializer = FileSearchFilterCtorParamInit,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] FileSearchFilterPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FileSearchFilter),
				Converter = null,
				Getter = (object obj) => ((FileSearchFilter)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((FileSearchFilter)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FileSearchFilter),
				Converter = null,
				Getter = (object obj) => ((FileSearchFilter)obj).Key,
				Setter = (object obj, string? value) =>
				{
					((FileSearchFilter)obj).Key = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Key",
				JsonPropertyName = "key"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<object> propertyInfo3 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FileSearchFilter),
				Converter = null,
				Getter = (object obj) => ((FileSearchFilter)obj).Value,
				Setter = (object obj, object? value) =>
				{
					((FileSearchFilter)obj).Value = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Value",
				JsonPropertyName = "value"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<List<FileSearchFilter>> propertyInfo4 = new JsonPropertyInfoValues<List<FileSearchFilter>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FileSearchFilter),
				Converter = null,
				Getter = (object obj) => ((FileSearchFilter)obj).Filters,
				Setter = (object obj, List<FileSearchFilter>? value) =>
				{
					((FileSearchFilter)obj).Filters = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Filters",
				JsonPropertyName = "filters"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private static JsonParameterInfoValues[] FileSearchFilterCtorParamInit()
		{
			return new JsonParameterInfoValues[1]
			{
				new JsonParameterInfoValues
				{
					Name = "type",
					ParameterType = typeof(string),
					Position = 0,
					HasDefaultValue = false,
					DefaultValue = null
				}
			};
		}

		private JsonTypeInfo<FileSearchTool> Create_FileSearchTool(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<FileSearchTool> jsonTypeInfo))
			{
				JsonObjectInfoValues<FileSearchTool> objectInfo = new JsonObjectInfoValues<FileSearchTool>
				{
					ObjectCreator = () => new FileSearchTool(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => FileSearchToolPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = FileSearchToolSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] FileSearchToolPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<int?> propertyInfo = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FileSearchTool),
				Converter = null,
				Getter = (object obj) => ((FileSearchTool)obj).MaxNumberResults,
				Setter = (object obj, int? value) =>
				{
					((FileSearchTool)obj).MaxNumberResults = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxNumberResults",
				JsonPropertyName = "max_num_results"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<RankingOptions> propertyInfo2 = new JsonPropertyInfoValues<RankingOptions>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FileSearchTool),
				Converter = null,
				Getter = (object obj) => ((FileSearchTool)obj).RankingOptions,
				Setter = (object obj, RankingOptions? value) =>
				{
					((FileSearchTool)obj).RankingOptions = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "RankingOptions",
				JsonPropertyName = "ranking_options"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<FileSearchFilter> propertyInfo3 = new JsonPropertyInfoValues<FileSearchFilter>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FileSearchTool),
				Converter = null,
				Getter = (object obj) => ((FileSearchTool)obj).Filters,
				Setter = (object obj, FileSearchFilter? value) =>
				{
					((FileSearchTool)obj).Filters = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Filters",
				JsonPropertyName = "filters"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			return array;
		}

		private void FileSearchToolSerializeHandler(Utf8JsonWriter writer, FileSearchTool? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			int? maxNumberResults = value.MaxNumberResults;
			if (maxNumberResults.HasValue)
			{
				writer.WritePropertyName(PropName_max_num_results);
				JsonSerializer.Serialize(writer, maxNumberResults, NullableInt32);
			}
			RankingOptions rankingOptions = value.RankingOptions;
			if (rankingOptions != null)
			{
				writer.WritePropertyName(PropName_ranking_options);
				RankingOptionsSerializeHandler(writer, rankingOptions);
			}
			FileSearchFilter filters = value.Filters;
			if (filters != null)
			{
				writer.WritePropertyName(PropName_filters);
				JsonSerializer.Serialize(writer, filters, FileSearchFilter);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<FunctionCall> Create_FunctionCall(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<FunctionCall> jsonTypeInfo))
			{
				JsonObjectInfoValues<FunctionCall> objectInfo = new JsonObjectInfoValues<FunctionCall>
				{
					ObjectCreator = () => new FunctionCall(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => FunctionCallPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = FunctionCallSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] FunctionCallPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCall),
				Converter = null,
				Getter = (object obj) => ((FunctionCall)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((FunctionCall)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCall),
				Converter = null,
				Getter = (object obj) => ((FunctionCall)obj).Arguments,
				Setter = (object obj, string? value) =>
				{
					((FunctionCall)obj).Arguments = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Arguments",
				JsonPropertyName = "arguments"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void FunctionCallSerializeHandler(Utf8JsonWriter writer, FunctionCall? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_name, name);
			}
			string arguments = value.Arguments;
			if (arguments != null)
			{
				writer.WriteString(PropName_arguments, arguments);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<FunctionDefinition> Create_FunctionDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<FunctionDefinition> jsonTypeInfo))
			{
				JsonObjectInfoValues<FunctionDefinition> objectInfo = new JsonObjectInfoValues<FunctionDefinition>
				{
					ObjectCreator = () => new FunctionDefinition(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => FunctionDefinitionPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = FunctionDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] FunctionDefinitionPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionDefinition),
				Converter = null,
				Getter = (object obj) => ((FunctionDefinition)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((FunctionDefinition)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionDefinition),
				Converter = null,
				Getter = (object obj) => ((FunctionDefinition)obj).Description,
				Setter = (object obj, string? value) =>
				{
					((FunctionDefinition)obj).Description = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Description",
				JsonPropertyName = "description"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<PropertyDefinition> propertyInfo3 = new JsonPropertyInfoValues<PropertyDefinition>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionDefinition),
				Converter = null,
				Getter = (object obj) => ((FunctionDefinition)obj).Parameters,
				Setter = (object obj, PropertyDefinition? value) =>
				{
					((FunctionDefinition)obj).Parameters = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Parameters",
				JsonPropertyName = "parameters"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<bool?> propertyInfo4 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionDefinition),
				Converter = null,
				Getter = (object obj) => ((FunctionDefinition)obj).Strict,
				Setter = (object obj, bool? value) =>
				{
					((FunctionDefinition)obj).Strict = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Strict",
				JsonPropertyName = "strict"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void FunctionDefinitionSerializeHandler(Utf8JsonWriter writer, FunctionDefinition? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_name, name);
			}
			string description = value.Description;
			if (description != null)
			{
				writer.WriteString(PropName_description, description);
			}
			PropertyDefinition parameters = value.Parameters;
			if (parameters != null)
			{
				writer.WritePropertyName(PropName_parameters);
				JsonSerializer.Serialize(writer, parameters, PropertyDefinition);
			}
			bool? strict = value.Strict;
			if (strict.HasValue)
			{
				writer.WritePropertyName(PropName_strict);
				JsonSerializer.Serialize(writer, strict, NullableBoolean);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema> Create_JsonSchema(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema> jsonTypeInfo))
			{
				JsonObjectInfoValues<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema> objectInfo = new JsonObjectInfoValues<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema>
				{
					ObjectCreator = () => new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => JsonSchemaPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = JsonSchemaSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] JsonSchemaPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema),
				Converter = null,
				Getter = (object obj) => ((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Description,
				Setter = (object obj, string? value) =>
				{
					((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Description = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Description",
				JsonPropertyName = "description"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema),
				Converter = null,
				Getter = (object obj) => ((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<bool?> propertyInfo3 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema),
				Converter = null,
				Getter = (object obj) => ((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Strict,
				Setter = (object obj, bool? value) =>
				{
					((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Strict = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Strict",
				JsonPropertyName = "strict"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<PropertyDefinition> propertyInfo4 = new JsonPropertyInfoValues<PropertyDefinition>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema),
				Converter = null,
				Getter = (object obj) => ((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Schema,
				Setter = (object obj, PropertyDefinition? value) =>
				{
					((Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema)obj).Schema = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Schema",
				JsonPropertyName = "schema"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void JsonSchemaSerializeHandler(Utf8JsonWriter writer, Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string description = value.Description;
			if (description != null)
			{
				writer.WriteString(PropName_description, description);
			}
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_name, name);
			}
			bool? strict = value.Strict;
			if (strict.HasValue)
			{
				writer.WritePropertyName(PropName_strict);
				JsonSerializer.Serialize(writer, strict, NullableBoolean);
			}
			PropertyDefinition schema = value.Schema;
			if (schema != null)
			{
				writer.WritePropertyName(PropName_schema);
				JsonSerializer.Serialize(writer, schema, PropertyDefinition);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<RankingOptions> Create_RankingOptions(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RankingOptions> jsonTypeInfo))
			{
				JsonObjectInfoValues<RankingOptions> objectInfo = new JsonObjectInfoValues<RankingOptions>
				{
					ObjectCreator = () => new RankingOptions(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => RankingOptionsPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = RankingOptionsSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] RankingOptionsPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RankingOptions),
				Converter = null,
				Getter = (object obj) => ((RankingOptions)obj).Ranker,
				Setter = (object obj, string? value) =>
				{
					((RankingOptions)obj).Ranker = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Ranker",
				JsonPropertyName = "ranker"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<float> propertyInfo2 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RankingOptions),
				Converter = null,
				Getter = (object obj) => ((RankingOptions)obj).ScoreThreshold,
				Setter = (object obj, float value) =>
				{
					((RankingOptions)obj).ScoreThreshold = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ScoreThreshold",
				JsonPropertyName = "score_threshold"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void RankingOptionsSerializeHandler(Utf8JsonWriter writer, RankingOptions? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string ranker = value.Ranker;
			if (ranker != null)
			{
				writer.WriteString(PropName_ranker, ranker);
			}
			writer.WriteNumber(PropName_score_threshold, value.ScoreThreshold);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseFormat> Create_ResponseFormat(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseFormat> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseFormat> objectInfo = new JsonObjectInfoValues<ResponseFormat>
				{
					ObjectCreator = () => new ResponseFormat(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseFormatPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ResponseFormatSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseFormatPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseFormat),
				Converter = null,
				Getter = (object obj) => ((ResponseFormat)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((ResponseFormat)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema> propertyInfo2 = new JsonPropertyInfoValues<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseFormat),
				Converter = null,
				Getter = (object obj) => ((ResponseFormat)obj).JsonSchema,
				Setter = (object obj, Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema? value) =>
				{
					((ResponseFormat)obj).JsonSchema = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "JsonSchema",
				JsonPropertyName = "json_schema"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void ResponseFormatSerializeHandler(Utf8JsonWriter writer, ResponseFormat? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema jsonSchema = value.JsonSchema;
			if (jsonSchema != null)
			{
				writer.WritePropertyName(PropName_json_schema);
				JsonSchemaSerializeHandler(writer, jsonSchema);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<StreamOptions> Create_StreamOptions(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<StreamOptions> jsonTypeInfo))
			{
				JsonObjectInfoValues<StreamOptions> objectInfo = new JsonObjectInfoValues<StreamOptions>
				{
					ObjectCreator = () => new StreamOptions(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => StreamOptionsPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = StreamOptionsSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] StreamOptionsPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[1];
			JsonPropertyInfoValues<bool> propertyInfo = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(StreamOptions),
				Converter = null,
				Getter = (object obj) => ((StreamOptions)obj).IncludeUsage,
				Setter = (object obj, bool value) =>
				{
					((StreamOptions)obj).IncludeUsage = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "IncludeUsage",
				JsonPropertyName = "include_usage"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			return array;
		}

		private void StreamOptionsSerializeHandler(Utf8JsonWriter writer, StreamOptions? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteBoolean(PropName_include_usage, value.IncludeUsage);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ToolCall> Create_ToolCall(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ToolCall> jsonTypeInfo))
			{
				JsonObjectInfoValues<ToolCall> objectInfo = new JsonObjectInfoValues<ToolCall>
				{
					ObjectCreator = () => new ToolCall(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ToolCallPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ToolCallSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ToolCallPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<int> propertyInfo = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolCall),
				Converter = null,
				Getter = (object obj) => ((ToolCall)obj).Index,
				Setter = (object obj, int value) =>
				{
					((ToolCall)obj).Index = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Index",
				JsonPropertyName = "index"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolCall),
				Converter = null,
				Getter = (object obj) => ((ToolCall)obj).Id,
				Setter = (object obj, string? value) =>
				{
					((ToolCall)obj).Id = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolCall),
				Converter = null,
				Getter = (object obj) => ((ToolCall)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((ToolCall)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<FunctionCall> propertyInfo4 = new JsonPropertyInfoValues<FunctionCall>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolCall),
				Converter = null,
				Getter = (object obj) => ((ToolCall)obj).FunctionCall,
				Setter = (object obj, FunctionCall? value) =>
				{
					((ToolCall)obj).FunctionCall = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FunctionCall",
				JsonPropertyName = "function"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void ToolCallSerializeHandler(Utf8JsonWriter writer, ToolCall? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteNumber(PropName_index, value.Index);
			string id = value.Id;
			if (id != null)
			{
				writer.WriteString(PropName_id, id);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			FunctionCall functionCall = value.FunctionCall;
			if (functionCall != null)
			{
				writer.WritePropertyName(PropName_function);
				FunctionCallSerializeHandler(writer, functionCall);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ToolChoice> Create_ToolChoice(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ToolChoice> jsonTypeInfo))
			{
				JsonObjectInfoValues<ToolChoice> objectInfo = new JsonObjectInfoValues<ToolChoice>
				{
					ObjectCreator = () => new ToolChoice(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ToolChoicePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ToolChoiceSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ToolChoicePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolChoice),
				Converter = null,
				Getter = (object obj) => ((ToolChoice)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((ToolChoice)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<ToolChoice.FunctionTool> propertyInfo2 = new JsonPropertyInfoValues<ToolChoice.FunctionTool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolChoice),
				Converter = null,
				Getter = (object obj) => ((ToolChoice)obj).Function,
				Setter = (object obj, ToolChoice.FunctionTool? value) =>
				{
					((ToolChoice)obj).Function = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Function",
				JsonPropertyName = "function"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void ToolChoiceSerializeHandler(Utf8JsonWriter writer, ToolChoice? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			ToolChoice.FunctionTool function = value.Function;
			if (function != null)
			{
				writer.WritePropertyName(PropName_function);
				FunctionToolSerializeHandler(writer, function);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ToolChoice.FunctionTool> Create_FunctionTool(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ToolChoice.FunctionTool> jsonTypeInfo))
			{
				JsonObjectInfoValues<ToolChoice.FunctionTool> objectInfo = new JsonObjectInfoValues<ToolChoice.FunctionTool>
				{
					ObjectCreator = () => new ToolChoice.FunctionTool(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => FunctionToolPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = FunctionToolSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] FunctionToolPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[1];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolChoice.FunctionTool),
				Converter = null,
				Getter = (object obj) => ((ToolChoice.FunctionTool)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((ToolChoice.FunctionTool)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			return array;
		}

		private void FunctionToolSerializeHandler(Utf8JsonWriter writer, ToolChoice.FunctionTool? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_name, name);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ToolDefinition> Create_ToolDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ToolDefinition> jsonTypeInfo))
			{
				JsonObjectInfoValues<ToolDefinition> objectInfo = new JsonObjectInfoValues<ToolDefinition>
				{
					ObjectCreator = () => new ToolDefinition(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ToolDefinitionPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ToolDefinitionPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolDefinition),
				Converter = null,
				Getter = (object obj) => ((ToolDefinition)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((ToolDefinition)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<FileSearchTool> propertyInfo2 = new JsonPropertyInfoValues<FileSearchTool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolDefinition),
				Converter = null,
				Getter = (object obj) => ((ToolDefinition)obj).FileSearchTool,
				Setter = (object obj, FileSearchTool? value) =>
				{
					((ToolDefinition)obj).FileSearchTool = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FileSearchTool",
				JsonPropertyName = "file_search"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<FunctionDefinition> propertyInfo3 = new JsonPropertyInfoValues<FunctionDefinition>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolDefinition),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Function",
				JsonPropertyName = null
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<object> propertyInfo4 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolDefinition),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FunctionsAsObject",
				JsonPropertyName = null
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<object> propertyInfo5 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ToolDefinition),
				Converter = null,
				Getter = (object obj) => ((ToolDefinition)obj).FunctionCalculated,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FunctionCalculated",
				JsonPropertyName = "function"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			return array;
		}

		private JsonTypeInfo<AudioCreateTranscriptionResponse> Create_AudioCreateTranscriptionResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioCreateTranscriptionResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioCreateTranscriptionResponse> objectInfo = new JsonObjectInfoValues<AudioCreateTranscriptionResponse>
				{
					ObjectCreator = () => new AudioCreateTranscriptionResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioCreateTranscriptionResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = AudioCreateTranscriptionResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioCreateTranscriptionResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[13];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse)obj).Text,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionResponse)obj).Text = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Text",
				JsonPropertyName = "text"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse)obj).Task,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionResponse)obj).Task = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Task",
				JsonPropertyName = "task"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse)obj).Language,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionResponse)obj).Language = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Language",
				JsonPropertyName = "language"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<float> propertyInfo4 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse)obj).Duration,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse)obj).Duration = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Duration",
				JsonPropertyName = "duration"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<List<AudioCreateTranscriptionResponse.WordSegment>> propertyInfo5 = new JsonPropertyInfoValues<List<AudioCreateTranscriptionResponse.WordSegment>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse)obj).Words,
				Setter = (object obj, List<AudioCreateTranscriptionResponse.WordSegment>? value) =>
				{
					((AudioCreateTranscriptionResponse)obj).Words = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Words",
				JsonPropertyName = "words"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<List<AudioCreateTranscriptionResponse.Segment>> propertyInfo6 = new JsonPropertyInfoValues<List<AudioCreateTranscriptionResponse.Segment>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse)obj).Segments,
				Setter = (object obj, List<AudioCreateTranscriptionResponse.Segment>? value) =>
				{
					((AudioCreateTranscriptionResponse)obj).Segments = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Segments",
				JsonPropertyName = "segments"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).StreamEvent,
				Setter = (object obj, string? value) =>
				{
					((BaseResponse)obj).StreamEvent = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StreamEvent",
				JsonPropertyName = "StreamEvent"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<bool> propertyInfo8 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).IsDelta,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "IsDelta",
				JsonPropertyName = null
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<bool> propertyInfo9 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).Successful,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Successful",
				JsonPropertyName = null
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<Error> propertyInfo10 = new JsonPropertyInfoValues<Error>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).Error,
				Setter = (object obj, Error? value) =>
				{
					((BaseResponse)obj).Error = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Error",
				JsonPropertyName = "error"
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<HttpStatusCode> propertyInfo11 = new JsonPropertyInfoValues<HttpStatusCode>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).HttpStatusCode,
				Setter = (object obj, HttpStatusCode value) =>
				{
					((BaseResponse)obj).HttpStatusCode = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "HttpStatusCode",
				JsonPropertyName = null
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			JsonPropertyInfoValues<ResponseHeaderValues> propertyInfo12 = new JsonPropertyInfoValues<ResponseHeaderValues>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).HeaderValues,
				Setter = (object obj, ResponseHeaderValues? value) =>
				{
					((BaseResponse)obj).HeaderValues = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "HeaderValues",
				JsonPropertyName = null
			};
			array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
			JsonPropertyInfoValues<string> propertyInfo13 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ObjectBaseResponse),
				Converter = null,
				Getter = (object obj) => ((ObjectBaseResponse)obj).ObjectTypeName,
				Setter = (object obj, string? value) =>
				{
					((ObjectBaseResponse)obj).ObjectTypeName = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ObjectTypeName",
				JsonPropertyName = "object"
			};
			array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
			return array;
		}

		private void AudioCreateTranscriptionResponseSerializeHandler(Utf8JsonWriter writer, AudioCreateTranscriptionResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string text = value.Text;
			if (text != null)
			{
				writer.WriteString(PropName_text, text);
			}
			string task = value.Task;
			if (task != null)
			{
				writer.WriteString(PropName_task, task);
			}
			string language = value.Language;
			if (language != null)
			{
				writer.WriteString(PropName_language, language);
			}
			writer.WriteNumber(PropName_duration, value.Duration);
			List<AudioCreateTranscriptionResponse.WordSegment> words = value.Words;
			if (words != null)
			{
				writer.WritePropertyName(PropName_words);
				ListWordSegmentSerializeHandler(writer, words);
			}
			List<AudioCreateTranscriptionResponse.Segment> segments = value.Segments;
			if (segments != null)
			{
				writer.WritePropertyName(PropName_segments);
				ListSegmentSerializeHandler(writer, segments);
			}
			string streamEvent = value.StreamEvent;
			if (streamEvent != null)
			{
				writer.WriteString(PropName_StreamEvent, streamEvent);
			}
			writer.WriteBoolean(PropName_IsDelta, value.IsDelta);
			writer.WriteBoolean(PropName_Successful, value.Successful);
			Error error = value.Error;
			if (error != null)
			{
				writer.WritePropertyName(PropName_error);
				JsonSerializer.Serialize(writer, error, Error);
			}
			writer.WritePropertyName(PropName_HttpStatusCode);
			JsonSerializer.Serialize(writer, value.HttpStatusCode, HttpStatusCode);
			ResponseHeaderValues headerValues = value.HeaderValues;
			if (headerValues != null)
			{
				writer.WritePropertyName(PropName_HeaderValues);
				ResponseHeaderValuesSerializeHandler(writer, headerValues);
			}
			string objectTypeName = value.ObjectTypeName;
			if (objectTypeName != null)
			{
				writer.WriteString(PropName_object, objectTypeName);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioCreateTranscriptionResponse.Segment> Create_Segment(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioCreateTranscriptionResponse.Segment> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioCreateTranscriptionResponse.Segment> objectInfo = new JsonObjectInfoValues<AudioCreateTranscriptionResponse.Segment>
				{
					ObjectCreator = () => new AudioCreateTranscriptionResponse.Segment(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => SegmentPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = SegmentSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] SegmentPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[11];
			JsonPropertyInfoValues<int> propertyInfo = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Id,
				Setter = (object obj, int value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Id = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Seek,
				Setter = (object obj, int value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Seek = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Seek",
				JsonPropertyName = "seek"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<float> propertyInfo3 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Start,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Start = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Start",
				JsonPropertyName = "start"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<float> propertyInfo4 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).End,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).End = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "End",
				JsonPropertyName = "end"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Text,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Text = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Text",
				JsonPropertyName = "text"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<List<int>> propertyInfo6 = new JsonPropertyInfoValues<List<int>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Tokens,
				Setter = (object obj, List<int>? value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Tokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Tokens",
				JsonPropertyName = "tokens"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<float> propertyInfo7 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Temperature,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Temperature = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Temperature",
				JsonPropertyName = "temperature"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<float> propertyInfo8 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Avglogprob,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Avglogprob = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Avglogprob",
				JsonPropertyName = "avg_logprob"
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<float> propertyInfo9 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).CompressionRatio,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).CompressionRatio = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CompressionRatio",
				JsonPropertyName = "compression_ratio"
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<float> propertyInfo10 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Nospeechprob,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Nospeechprob = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Nospeechprob",
				JsonPropertyName = "no_speech_prob"
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<bool> propertyInfo11 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.Segment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.Segment)obj).Transient,
				Setter = (object obj, bool value) =>
				{
					((AudioCreateTranscriptionResponse.Segment)obj).Transient = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Transient",
				JsonPropertyName = "transient"
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			return array;
		}

		private void SegmentSerializeHandler(Utf8JsonWriter writer, AudioCreateTranscriptionResponse.Segment? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteNumber(PropName_id, value.Id);
			writer.WriteNumber(PropName_seek, value.Seek);
			writer.WriteNumber(PropName_start, value.Start);
			writer.WriteNumber(PropName_end, value.End);
			string text = value.Text;
			if (text != null)
			{
				writer.WriteString(PropName_text, text);
			}
			List<int> tokens = value.Tokens;
			if (tokens != null)
			{
				writer.WritePropertyName(PropName_tokens);
				ListInt32SerializeHandler(writer, tokens);
			}
			writer.WriteNumber(PropName_temperature, value.Temperature);
			writer.WriteNumber(PropName_avg_logprob, value.Avglogprob);
			writer.WriteNumber(PropName_compression_ratio, value.CompressionRatio);
			writer.WriteNumber(PropName_no_speech_prob, value.Nospeechprob);
			writer.WriteBoolean(PropName_transient, value.Transient);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioCreateTranscriptionResponse.WordSegment> Create_WordSegment(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioCreateTranscriptionResponse.WordSegment> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioCreateTranscriptionResponse.WordSegment> objectInfo = new JsonObjectInfoValues<AudioCreateTranscriptionResponse.WordSegment>
				{
					ObjectCreator = () => new AudioCreateTranscriptionResponse.WordSegment(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => WordSegmentPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = WordSegmentSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] WordSegmentPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.WordSegment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.WordSegment)obj).Word,
				Setter = (object obj, string? value) =>
				{
					((AudioCreateTranscriptionResponse.WordSegment)obj).Word = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Word",
				JsonPropertyName = "word"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<float> propertyInfo2 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.WordSegment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.WordSegment)obj).Start,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.WordSegment)obj).Start = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Start",
				JsonPropertyName = "start"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<float> propertyInfo3 = new JsonPropertyInfoValues<float>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioCreateTranscriptionResponse.WordSegment),
				Converter = null,
				Getter = (object obj) => ((AudioCreateTranscriptionResponse.WordSegment)obj).End,
				Setter = (object obj, float value) =>
				{
					((AudioCreateTranscriptionResponse.WordSegment)obj).End = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "End",
				JsonPropertyName = "end"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			return array;
		}

		private void WordSegmentSerializeHandler(Utf8JsonWriter writer, AudioCreateTranscriptionResponse.WordSegment? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string word = value.Word;
			if (word != null)
			{
				writer.WriteString(PropName_word, word);
			}
			writer.WriteNumber(PropName_start, value.Start);
			writer.WriteNumber(PropName_end, value.End);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatCompletionCreateResponse> Create_ChatCompletionCreateResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatCompletionCreateResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatCompletionCreateResponse> objectInfo = new JsonObjectInfoValues<ChatCompletionCreateResponse>
				{
					ObjectCreator = () => new ChatCompletionCreateResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ChatCompletionCreateResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ChatCompletionCreateResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ChatCompletionCreateResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[15];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateResponse)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = "model"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<List<ChatChoiceResponse>> propertyInfo2 = new JsonPropertyInfoValues<List<ChatChoiceResponse>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).Choices,
				Setter = (object obj, List<ChatChoiceResponse>? value) =>
				{
					((ChatCompletionCreateResponse)obj).Choices = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Choices",
				JsonPropertyName = "choices"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<UsageResponse> propertyInfo3 = new JsonPropertyInfoValues<UsageResponse>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).Usage,
				Setter = (object obj, UsageResponse? value) =>
				{
					((ChatCompletionCreateResponse)obj).Usage = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Usage",
				JsonPropertyName = "usage"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).SystemFingerPrint,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateResponse)obj).SystemFingerPrint = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "SystemFingerPrint",
				JsonPropertyName = "system_fingerprint"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).ServiceTier,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateResponse)obj).ServiceTier = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ServiceTier",
				JsonPropertyName = "service_tier"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<long> propertyInfo6 = new JsonPropertyInfoValues<long>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).CreatedAtUnix,
				Setter = (object obj, long value) =>
				{
					((ChatCompletionCreateResponse)obj).CreatedAtUnix = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CreatedAtUnix",
				JsonPropertyName = "created"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<DateTimeOffset> propertyInfo7 = new JsonPropertyInfoValues<DateTimeOffset>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).CreatedAt,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CreatedAt",
				JsonPropertyName = null
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateResponse),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateResponse)obj).Id,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateResponse)obj).Id = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id"
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).StreamEvent,
				Setter = (object obj, string? value) =>
				{
					((BaseResponse)obj).StreamEvent = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StreamEvent",
				JsonPropertyName = "StreamEvent"
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<bool> propertyInfo10 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).IsDelta,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "IsDelta",
				JsonPropertyName = null
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<bool> propertyInfo11 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).Successful,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Successful",
				JsonPropertyName = null
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			JsonPropertyInfoValues<Error> propertyInfo12 = new JsonPropertyInfoValues<Error>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).Error,
				Setter = (object obj, Error? value) =>
				{
					((BaseResponse)obj).Error = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Error",
				JsonPropertyName = "error"
			};
			array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
			JsonPropertyInfoValues<HttpStatusCode> propertyInfo13 = new JsonPropertyInfoValues<HttpStatusCode>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).HttpStatusCode,
				Setter = (object obj, HttpStatusCode value) =>
				{
					((BaseResponse)obj).HttpStatusCode = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "HttpStatusCode",
				JsonPropertyName = null
			};
			array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
			JsonPropertyInfoValues<ResponseHeaderValues> propertyInfo14 = new JsonPropertyInfoValues<ResponseHeaderValues>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).HeaderValues,
				Setter = (object obj, ResponseHeaderValues? value) =>
				{
					((BaseResponse)obj).HeaderValues = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "HeaderValues",
				JsonPropertyName = null
			};
			array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
			JsonPropertyInfoValues<string> propertyInfo15 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ObjectBaseResponse),
				Converter = null,
				Getter = (object obj) => ((ObjectBaseResponse)obj).ObjectTypeName,
				Setter = (object obj, string? value) =>
				{
					((ObjectBaseResponse)obj).ObjectTypeName = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ObjectTypeName",
				JsonPropertyName = "object"
			};
			array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
			return array;
		}

		private void ChatCompletionCreateResponseSerializeHandler(Utf8JsonWriter writer, ChatCompletionCreateResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string model = value.Model;
			if (model != null)
			{
				writer.WriteString(PropName_model, model);
			}
			List<ChatChoiceResponse> choices = value.Choices;
			if (choices != null)
			{
				writer.WritePropertyName(PropName_choices);
				ListChatChoiceResponseSerializeHandler(writer, choices);
			}
			UsageResponse usage = value.Usage;
			if (usage != null)
			{
				writer.WritePropertyName(PropName_usage);
				UsageResponseSerializeHandler(writer, usage);
			}
			string systemFingerPrint = value.SystemFingerPrint;
			if (systemFingerPrint != null)
			{
				writer.WriteString(PropName_system_fingerprint, systemFingerPrint);
			}
			string serviceTier = value.ServiceTier;
			if (serviceTier != null)
			{
				writer.WriteString(PropName_service_tier, serviceTier);
			}
			writer.WriteNumber(PropName_created, value.CreatedAtUnix);
			writer.WriteString(PropName_CreatedAt, value.CreatedAt);
			string id = value.Id;
			if (id != null)
			{
				writer.WriteString(PropName_id, id);
			}
			string streamEvent = value.StreamEvent;
			if (streamEvent != null)
			{
				writer.WriteString(PropName_StreamEvent, streamEvent);
			}
			writer.WriteBoolean(PropName_IsDelta, value.IsDelta);
			writer.WriteBoolean(PropName_Successful, value.Successful);
			Error error = value.Error;
			if (error != null)
			{
				writer.WritePropertyName(PropName_error);
				JsonSerializer.Serialize(writer, error, Error);
			}
			writer.WritePropertyName(PropName_HttpStatusCode);
			JsonSerializer.Serialize(writer, value.HttpStatusCode, HttpStatusCode);
			ResponseHeaderValues headerValues = value.HeaderValues;
			if (headerValues != null)
			{
				writer.WritePropertyName(PropName_HeaderValues);
				ResponseHeaderValuesSerializeHandler(writer, headerValues);
			}
			string objectTypeName = value.ObjectTypeName;
			if (objectTypeName != null)
			{
				writer.WriteString(PropName_object, objectTypeName);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<CompletionTokensDetails> Create_CompletionTokensDetails(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<CompletionTokensDetails> jsonTypeInfo))
			{
				JsonObjectInfoValues<CompletionTokensDetails> objectInfo = new JsonObjectInfoValues<CompletionTokensDetails>
				{
					ObjectCreator = () => new CompletionTokensDetails(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => CompletionTokensDetailsPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = CompletionTokensDetailsSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] CompletionTokensDetailsPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int> propertyInfo = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(CompletionTokensDetails),
				Converter = null,
				Getter = (object obj) => ((CompletionTokensDetails)obj).ReasoningTokens,
				Setter = (object obj, int value) =>
				{
					((CompletionTokensDetails)obj).ReasoningTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ReasoningTokens",
				JsonPropertyName = "reasoning_tokens"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(CompletionTokensDetails),
				Converter = null,
				Getter = (object obj) => ((CompletionTokensDetails)obj).AudioTokens,
				Setter = (object obj, int value) =>
				{
					((CompletionTokensDetails)obj).AudioTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AudioTokens",
				JsonPropertyName = "audio_tokens"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void CompletionTokensDetailsSerializeHandler(Utf8JsonWriter writer, CompletionTokensDetails? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteNumber(PropName_reasoning_tokens, value.ReasoningTokens);
			writer.WriteNumber(PropName_audio_tokens, value.AudioTokens);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<EmbeddingCreateResponse> Create_EmbeddingCreateResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<EmbeddingCreateResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<EmbeddingCreateResponse> objectInfo = new JsonObjectInfoValues<EmbeddingCreateResponse>
				{
					ObjectCreator = () => new EmbeddingCreateResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => EmbeddingCreateResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = EmbeddingCreateResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] EmbeddingCreateResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[10];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateResponse),
				Converter = null,
				Getter = (object obj) => ((EmbeddingCreateResponse)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((EmbeddingCreateResponse)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = "model"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<List<EmbeddingResponse>> propertyInfo2 = new JsonPropertyInfoValues<List<EmbeddingResponse>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateResponse),
				Converter = null,
				Getter = (object obj) => ((EmbeddingCreateResponse)obj).Data,
				Setter = (object obj, List<EmbeddingResponse>? value) =>
				{
					((EmbeddingCreateResponse)obj).Data = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Data",
				JsonPropertyName = "data"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<UsageResponse> propertyInfo3 = new JsonPropertyInfoValues<UsageResponse>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateResponse),
				Converter = null,
				Getter = (object obj) => ((EmbeddingCreateResponse)obj).Usage,
				Setter = (object obj, UsageResponse? value) =>
				{
					((EmbeddingCreateResponse)obj).Usage = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Usage",
				JsonPropertyName = "usage"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).StreamEvent,
				Setter = (object obj, string? value) =>
				{
					((BaseResponse)obj).StreamEvent = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StreamEvent",
				JsonPropertyName = "StreamEvent"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<bool> propertyInfo5 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).IsDelta,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "IsDelta",
				JsonPropertyName = null
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<bool> propertyInfo6 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).Successful,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Successful",
				JsonPropertyName = null
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<Error> propertyInfo7 = new JsonPropertyInfoValues<Error>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).Error,
				Setter = (object obj, Error? value) =>
				{
					((BaseResponse)obj).Error = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Error",
				JsonPropertyName = "error"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<HttpStatusCode> propertyInfo8 = new JsonPropertyInfoValues<HttpStatusCode>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).HttpStatusCode,
				Setter = (object obj, HttpStatusCode value) =>
				{
					((BaseResponse)obj).HttpStatusCode = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "HttpStatusCode",
				JsonPropertyName = null
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<ResponseHeaderValues> propertyInfo9 = new JsonPropertyInfoValues<ResponseHeaderValues>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(BaseResponse),
				Converter = null,
				Getter = (object obj) => ((BaseResponse)obj).HeaderValues,
				Setter = (object obj, ResponseHeaderValues? value) =>
				{
					((BaseResponse)obj).HeaderValues = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "HeaderValues",
				JsonPropertyName = null
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ObjectBaseResponse),
				Converter = null,
				Getter = (object obj) => ((ObjectBaseResponse)obj).ObjectTypeName,
				Setter = (object obj, string? value) =>
				{
					((ObjectBaseResponse)obj).ObjectTypeName = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ObjectTypeName",
				JsonPropertyName = "object"
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			return array;
		}

		private void EmbeddingCreateResponseSerializeHandler(Utf8JsonWriter writer, EmbeddingCreateResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string model = value.Model;
			if (model != null)
			{
				writer.WriteString(PropName_model, model);
			}
			List<EmbeddingResponse> data = value.Data;
			if (data != null)
			{
				writer.WritePropertyName(PropName_data);
				ListEmbeddingResponseSerializeHandler(writer, data);
			}
			UsageResponse usage = value.Usage;
			if (usage != null)
			{
				writer.WritePropertyName(PropName_usage);
				UsageResponseSerializeHandler(writer, usage);
			}
			string streamEvent = value.StreamEvent;
			if (streamEvent != null)
			{
				writer.WriteString(PropName_StreamEvent, streamEvent);
			}
			writer.WriteBoolean(PropName_IsDelta, value.IsDelta);
			writer.WriteBoolean(PropName_Successful, value.Successful);
			Error error = value.Error;
			if (error != null)
			{
				writer.WritePropertyName(PropName_error);
				JsonSerializer.Serialize(writer, error, Error);
			}
			writer.WritePropertyName(PropName_HttpStatusCode);
			JsonSerializer.Serialize(writer, value.HttpStatusCode, HttpStatusCode);
			ResponseHeaderValues headerValues = value.HeaderValues;
			if (headerValues != null)
			{
				writer.WritePropertyName(PropName_HeaderValues);
				ResponseHeaderValuesSerializeHandler(writer, headerValues);
			}
			string objectTypeName = value.ObjectTypeName;
			if (objectTypeName != null)
			{
				writer.WriteString(PropName_object, objectTypeName);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<EmbeddingResponse> Create_EmbeddingResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<EmbeddingResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<EmbeddingResponse> objectInfo = new JsonObjectInfoValues<EmbeddingResponse>
				{
					ObjectCreator = () => new EmbeddingResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => EmbeddingResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = EmbeddingResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] EmbeddingResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int?> propertyInfo = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingResponse),
				Converter = null,
				Getter = (object obj) => ((EmbeddingResponse)obj).Index,
				Setter = (object obj, int? value) =>
				{
					((EmbeddingResponse)obj).Index = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Index",
				JsonPropertyName = "index"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<List<double>> propertyInfo2 = new JsonPropertyInfoValues<List<double>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingResponse),
				Converter = null,
				Getter = (object obj) => ((EmbeddingResponse)obj).Embedding,
				Setter = (object obj, List<double>? value) =>
				{
					((EmbeddingResponse)obj).Embedding = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Embedding",
				JsonPropertyName = "embedding"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void EmbeddingResponseSerializeHandler(Utf8JsonWriter writer, EmbeddingResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			int? index = value.Index;
			if (index.HasValue)
			{
				writer.WritePropertyName(PropName_index);
				JsonSerializer.Serialize(writer, index, NullableInt32);
			}
			List<double> embedding = value.Embedding;
			if (embedding != null)
			{
				writer.WritePropertyName(PropName_embedding);
				ListDoubleSerializeHandler(writer, embedding);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<Error> Create_Error(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Error> jsonTypeInfo))
			{
				JsonObjectInfoValues<Error> objectInfo = new JsonObjectInfoValues<Error>
				{
					ObjectCreator = () => new Error(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ErrorPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ErrorPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[8];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = null,
				Getter = (object obj) => ((Error)obj).Code,
				Setter = (object obj, string? value) =>
				{
					((Error)obj).Code = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Code",
				JsonPropertyName = "code"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = null,
				Getter = (object obj) => ((Error)obj).Param,
				Setter = (object obj, string? value) =>
				{
					((Error)obj).Param = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Param",
				JsonPropertyName = "param"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = null,
				Getter = (object obj) => ((Error)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((Error)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<int?> propertyInfo4 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = null,
				Getter = (object obj) => ((Error)obj).Line,
				Setter = (object obj, int? value) =>
				{
					((Error)obj).Line = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Line",
				JsonPropertyName = "line"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Message",
				JsonPropertyName = null
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<List<string>> propertyInfo6 = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Messages",
				JsonPropertyName = null
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<object> propertyInfo7 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = (JsonConverter<object>)ExpandConverter(typeof(object), new Error.MessageConverter(), options),
				Getter = null,
				Setter = (object obj, object? value) =>
				{
					((Error)obj).MessageObject = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MessageObject",
				JsonPropertyName = "message"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Error),
				Converter = null,
				Getter = (object obj) => ((Error)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((Error)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id"
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			return array;
		}

		private JsonTypeInfo<OpenAIInfo> Create_OpenAIInfo(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<OpenAIInfo> jsonTypeInfo))
			{
				JsonObjectInfoValues<OpenAIInfo> objectInfo = new JsonObjectInfoValues<OpenAIInfo>
				{
					ObjectCreator = () => new OpenAIInfo(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => OpenAIInfoPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = OpenAIInfoSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] OpenAIInfoPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(OpenAIInfo),
				Converter = null,
				Getter = (object obj) => ((OpenAIInfo)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((OpenAIInfo)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(OpenAIInfo),
				Converter = null,
				Getter = (object obj) => ((OpenAIInfo)obj).Organization,
				Setter = (object obj, string? value) =>
				{
					((OpenAIInfo)obj).Organization = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Organization",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(OpenAIInfo),
				Converter = null,
				Getter = (object obj) => ((OpenAIInfo)obj).ProcessingMs,
				Setter = (object obj, string? value) =>
				{
					((OpenAIInfo)obj).ProcessingMs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ProcessingMs",
				JsonPropertyName = null
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(OpenAIInfo),
				Converter = null,
				Getter = (object obj) => ((OpenAIInfo)obj).Version,
				Setter = (object obj, string? value) =>
				{
					((OpenAIInfo)obj).Version = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Version",
				JsonPropertyName = null
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void OpenAIInfoSerializeHandler(Utf8JsonWriter writer, OpenAIInfo? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string model = value.Model;
			if (model != null)
			{
				writer.WriteString(PropName_Model, model);
			}
			string organization = value.Organization;
			if (organization != null)
			{
				writer.WriteString(PropName_Organization, organization);
			}
			string processingMs = value.ProcessingMs;
			if (processingMs != null)
			{
				writer.WriteString(PropName_ProcessingMs, processingMs);
			}
			string version = value.Version;
			if (version != null)
			{
				writer.WriteString(PropName_Version, version);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<PromptTokensDetails> Create_PromptTokensDetails(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<PromptTokensDetails> jsonTypeInfo))
			{
				JsonObjectInfoValues<PromptTokensDetails> objectInfo = new JsonObjectInfoValues<PromptTokensDetails>
				{
					ObjectCreator = () => new PromptTokensDetails(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => PromptTokensDetailsPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = PromptTokensDetailsSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] PromptTokensDetailsPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int?> propertyInfo = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PromptTokensDetails),
				Converter = null,
				Getter = (object obj) => ((PromptTokensDetails)obj).CachedTokens,
				Setter = (object obj, int? value) =>
				{
					((PromptTokensDetails)obj).CachedTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CachedTokens",
				JsonPropertyName = "cached_tokens"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<int?> propertyInfo2 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PromptTokensDetails),
				Converter = null,
				Getter = (object obj) => ((PromptTokensDetails)obj).AudioTokens,
				Setter = (object obj, int? value) =>
				{
					((PromptTokensDetails)obj).AudioTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AudioTokens",
				JsonPropertyName = "audio_tokens"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void PromptTokensDetailsSerializeHandler(Utf8JsonWriter writer, PromptTokensDetails? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			int? cachedTokens = value.CachedTokens;
			if (cachedTokens.HasValue)
			{
				writer.WritePropertyName(PropName_cached_tokens);
				JsonSerializer.Serialize(writer, cachedTokens, NullableInt32);
			}
			int? audioTokens = value.AudioTokens;
			if (audioTokens.HasValue)
			{
				writer.WritePropertyName(PropName_audio_tokens);
				JsonSerializer.Serialize(writer, audioTokens, NullableInt32);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<RateLimitInfo> Create_RateLimitInfo(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RateLimitInfo> jsonTypeInfo))
			{
				JsonObjectInfoValues<RateLimitInfo> objectInfo = new JsonObjectInfoValues<RateLimitInfo>
				{
					ObjectCreator = () => new RateLimitInfo(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => RateLimitInfoPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = RateLimitInfoSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] RateLimitInfoPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[9];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).LimitRequests,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).LimitRequests = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LimitRequests",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).LimitTokens,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).LimitTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LimitTokens",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).LimitTokensUsageBased,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).LimitTokensUsageBased = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LimitTokensUsageBased",
				JsonPropertyName = null
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).RemainingRequests,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).RemainingRequests = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "RemainingRequests",
				JsonPropertyName = null
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).RemainingTokens,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).RemainingTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "RemainingTokens",
				JsonPropertyName = null
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).RemainingTokensUsageBased,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).RemainingTokensUsageBased = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "RemainingTokensUsageBased",
				JsonPropertyName = null
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).ResetRequests,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).ResetRequests = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResetRequests",
				JsonPropertyName = null
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).ResetTokens,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).ResetTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResetTokens",
				JsonPropertyName = null
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitInfo),
				Converter = null,
				Getter = (object obj) => ((RateLimitInfo)obj).ResetTokensUsageBased,
				Setter = (object obj, string? value) =>
				{
					((RateLimitInfo)obj).ResetTokensUsageBased = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResetTokensUsageBased",
				JsonPropertyName = null
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			return array;
		}

		private void RateLimitInfoSerializeHandler(Utf8JsonWriter writer, RateLimitInfo? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string limitRequests = value.LimitRequests;
			if (limitRequests != null)
			{
				writer.WriteString(PropName_LimitRequests, limitRequests);
			}
			string limitTokens = value.LimitTokens;
			if (limitTokens != null)
			{
				writer.WriteString(PropName_LimitTokens, limitTokens);
			}
			string limitTokensUsageBased = value.LimitTokensUsageBased;
			if (limitTokensUsageBased != null)
			{
				writer.WriteString(PropName_LimitTokensUsageBased, limitTokensUsageBased);
			}
			string remainingRequests = value.RemainingRequests;
			if (remainingRequests != null)
			{
				writer.WriteString(PropName_RemainingRequests, remainingRequests);
			}
			string remainingTokens = value.RemainingTokens;
			if (remainingTokens != null)
			{
				writer.WriteString(PropName_RemainingTokens, remainingTokens);
			}
			string remainingTokensUsageBased = value.RemainingTokensUsageBased;
			if (remainingTokensUsageBased != null)
			{
				writer.WriteString(PropName_RemainingTokensUsageBased, remainingTokensUsageBased);
			}
			string resetRequests = value.ResetRequests;
			if (resetRequests != null)
			{
				writer.WriteString(PropName_ResetRequests, resetRequests);
			}
			string resetTokens = value.ResetTokens;
			if (resetTokens != null)
			{
				writer.WriteString(PropName_ResetTokens, resetTokens);
			}
			string resetTokensUsageBased = value.ResetTokensUsageBased;
			if (resetTokensUsageBased != null)
			{
				writer.WriteString(PropName_ResetTokensUsageBased, resetTokensUsageBased);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseHeaderValues> Create_ResponseHeaderValues(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseHeaderValues> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseHeaderValues> objectInfo = new JsonObjectInfoValues<ResponseHeaderValues>
				{
					ObjectCreator = () => new ResponseHeaderValues(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseHeaderValuesPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ResponseHeaderValuesSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseHeaderValuesPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[15];
			JsonPropertyInfoValues<DateTimeOffset?> propertyInfo = new JsonPropertyInfoValues<DateTimeOffset?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).Date,
				Setter = (object obj, DateTimeOffset? value) =>
				{
					((ResponseHeaderValues)obj).Date = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Date",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).Connection,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).Connection = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Connection",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).AccessControlAllowOrigin,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).AccessControlAllowOrigin = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AccessControlAllowOrigin",
				JsonPropertyName = null
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).CacheControl,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).CacheControl = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CacheControl",
				JsonPropertyName = null
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).Vary,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).Vary = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Vary",
				JsonPropertyName = null
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).XRequestId,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).XRequestId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "XRequestId",
				JsonPropertyName = null
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).StrictTransportSecurity,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).StrictTransportSecurity = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StrictTransportSecurity",
				JsonPropertyName = null
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).CFCacheStatus,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).CFCacheStatus = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CFCacheStatus",
				JsonPropertyName = null
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<List<string>> propertyInfo9 = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).SetCookie,
				Setter = (object obj, List<string>? value) =>
				{
					((ResponseHeaderValues)obj).SetCookie = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "SetCookie",
				JsonPropertyName = null
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).Server,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).Server = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Server",
				JsonPropertyName = null
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<string> propertyInfo11 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).CF_RAY,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).CF_RAY = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CF_RAY",
				JsonPropertyName = null
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).AltSvc,
				Setter = (object obj, string? value) =>
				{
					((ResponseHeaderValues)obj).AltSvc = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AltSvc",
				JsonPropertyName = null
			};
			array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
			JsonPropertyInfoValues<Dictionary<string, IEnumerable<string>>> propertyInfo13 = new JsonPropertyInfoValues<Dictionary<string, IEnumerable<string>>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).All,
				Setter = (object obj, Dictionary<string, IEnumerable<string>>? value) =>
				{
					((ResponseHeaderValues)obj).All = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "All",
				JsonPropertyName = null
			};
			array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
			JsonPropertyInfoValues<RateLimitInfo> propertyInfo14 = new JsonPropertyInfoValues<RateLimitInfo>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).RateLimits,
				Setter = (object obj, RateLimitInfo? value) =>
				{
					((ResponseHeaderValues)obj).RateLimits = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "RateLimits",
				JsonPropertyName = null
			};
			array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
			JsonPropertyInfoValues<OpenAIInfo> propertyInfo15 = new JsonPropertyInfoValues<OpenAIInfo>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseHeaderValues),
				Converter = null,
				Getter = (object obj) => ((ResponseHeaderValues)obj).OpenAI,
				Setter = (object obj, OpenAIInfo? value) =>
				{
					((ResponseHeaderValues)obj).OpenAI = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OpenAI",
				JsonPropertyName = null
			};
			array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
			return array;
		}

		private void ResponseHeaderValuesSerializeHandler(Utf8JsonWriter writer, ResponseHeaderValues? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			DateTimeOffset? date = value.Date;
			if (date.HasValue)
			{
				writer.WritePropertyName(PropName_Date);
				JsonSerializer.Serialize(writer, date, NullableDateTimeOffset);
			}
			string connection = value.Connection;
			if (connection != null)
			{
				writer.WriteString(PropName_Connection, connection);
			}
			string accessControlAllowOrigin = value.AccessControlAllowOrigin;
			if (accessControlAllowOrigin != null)
			{
				writer.WriteString(PropName_AccessControlAllowOrigin, accessControlAllowOrigin);
			}
			string cacheControl = value.CacheControl;
			if (cacheControl != null)
			{
				writer.WriteString(PropName_CacheControl, cacheControl);
			}
			string vary = value.Vary;
			if (vary != null)
			{
				writer.WriteString(PropName_Vary, vary);
			}
			string xRequestId = value.XRequestId;
			if (xRequestId != null)
			{
				writer.WriteString(PropName_XRequestId, xRequestId);
			}
			string strictTransportSecurity = value.StrictTransportSecurity;
			if (strictTransportSecurity != null)
			{
				writer.WriteString(PropName_StrictTransportSecurity, strictTransportSecurity);
			}
			string cFCacheStatus = value.CFCacheStatus;
			if (cFCacheStatus != null)
			{
				writer.WriteString(PropName_CFCacheStatus, cFCacheStatus);
			}
			List<string> setCookie = value.SetCookie;
			if (setCookie != null)
			{
				writer.WritePropertyName(PropName_SetCookie);
				ListStringSerializeHandler(writer, setCookie);
			}
			string server = value.Server;
			if (server != null)
			{
				writer.WriteString(PropName_Server, server);
			}
			string cF_RAY = value.CF_RAY;
			if (cF_RAY != null)
			{
				writer.WriteString(PropName_CF_RAY, cF_RAY);
			}
			string altSvc = value.AltSvc;
			if (altSvc != null)
			{
				writer.WriteString(PropName_AltSvc, altSvc);
			}
			Dictionary<string, IEnumerable<string>> all = value.All;
			if (all != null)
			{
				writer.WritePropertyName(PropName_All);
				DictionaryStringIEnumerableStringSerializeHandler(writer, all);
			}
			RateLimitInfo rateLimits = value.RateLimits;
			if (rateLimits != null)
			{
				writer.WritePropertyName(PropName_RateLimits);
				RateLimitInfoSerializeHandler(writer, rateLimits);
			}
			OpenAIInfo openAI = value.OpenAI;
			if (openAI != null)
			{
				writer.WritePropertyName(PropName_OpenAI);
				OpenAIInfoSerializeHandler(writer, openAI);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<UsageResponse> Create_UsageResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<UsageResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<UsageResponse> objectInfo = new JsonObjectInfoValues<UsageResponse>
				{
					ObjectCreator = () => new UsageResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => UsageResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = UsageResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] UsageResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<int> propertyInfo = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(UsageResponse),
				Converter = null,
				Getter = (object obj) => ((UsageResponse)obj).PromptTokens,
				Setter = (object obj, int value) =>
				{
					((UsageResponse)obj).PromptTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PromptTokens",
				JsonPropertyName = "prompt_tokens"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<int?> propertyInfo2 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(UsageResponse),
				Converter = null,
				Getter = (object obj) => ((UsageResponse)obj).CompletionTokens,
				Setter = (object obj, int? value) =>
				{
					((UsageResponse)obj).CompletionTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CompletionTokens",
				JsonPropertyName = "completion_tokens"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(UsageResponse),
				Converter = null,
				Getter = (object obj) => ((UsageResponse)obj).TotalTokens,
				Setter = (object obj, int value) =>
				{
					((UsageResponse)obj).TotalTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TotalTokens",
				JsonPropertyName = "total_tokens"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<CompletionTokensDetails> propertyInfo4 = new JsonPropertyInfoValues<CompletionTokensDetails>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(UsageResponse),
				Converter = null,
				Getter = (object obj) => ((UsageResponse)obj).CompletionTokensDetails,
				Setter = (object obj, CompletionTokensDetails? value) =>
				{
					((UsageResponse)obj).CompletionTokensDetails = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CompletionTokensDetails",
				JsonPropertyName = "completion_tokens_details"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<PromptTokensDetails> propertyInfo5 = new JsonPropertyInfoValues<PromptTokensDetails>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(UsageResponse),
				Converter = null,
				Getter = (object obj) => ((UsageResponse)obj).PromptTokensDetails,
				Setter = (object obj, PromptTokensDetails? value) =>
				{
					((UsageResponse)obj).PromptTokensDetails = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PromptTokensDetails",
				JsonPropertyName = "prompt_tokens_details"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			return array;
		}

		private void UsageResponseSerializeHandler(Utf8JsonWriter writer, UsageResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteNumber(PropName_prompt_tokens, value.PromptTokens);
			int? completionTokens = value.CompletionTokens;
			if (completionTokens.HasValue)
			{
				writer.WritePropertyName(PropName_completion_tokens);
				JsonSerializer.Serialize(writer, completionTokens, NullableInt32);
			}
			writer.WriteNumber(PropName_total_tokens, value.TotalTokens);
			CompletionTokensDetails completionTokensDetails = value.CompletionTokensDetails;
			if (completionTokensDetails != null)
			{
				writer.WritePropertyName(PropName_completion_tokens_details);
				CompletionTokensDetailsSerializeHandler(writer, completionTokensDetails);
			}
			PromptTokensDetails promptTokensDetails = value.PromptTokensDetails;
			if (promptTokensDetails != null)
			{
				writer.WritePropertyName(PropName_prompt_tokens_details);
				PromptTokensDetailsSerializeHandler(writer, promptTokensDetails);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatChoiceResponse> Create_ChatChoiceResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatChoiceResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatChoiceResponse> objectInfo = new JsonObjectInfoValues<ChatChoiceResponse>
				{
					ObjectCreator = () => new ChatChoiceResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ChatChoiceResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ChatChoiceResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ChatChoiceResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[6];
			JsonPropertyInfoValues<ChatMessage> propertyInfo = new JsonPropertyInfoValues<ChatMessage>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse)obj).Delta,
				Setter = (object obj, ChatMessage? value) =>
				{
					((ChatChoiceResponse)obj).Delta = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Delta",
				JsonPropertyName = "delta"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<ChatMessage> propertyInfo2 = new JsonPropertyInfoValues<ChatMessage>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse)obj).Message,
				Setter = (object obj, ChatMessage? value) =>
				{
					((ChatChoiceResponse)obj).Message = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Message",
				JsonPropertyName = "message"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<int?> propertyInfo3 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse)obj).Index,
				Setter = (object obj, int? value) =>
				{
					((ChatChoiceResponse)obj).Index = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Index",
				JsonPropertyName = "index"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse)obj).FinishReason,
				Setter = (object obj, string? value) =>
				{
					((ChatChoiceResponse)obj).FinishReason = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FinishReason",
				JsonPropertyName = "finish_reason"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<ChatChoiceResponse.FinishDetailsResponse> propertyInfo5 = new JsonPropertyInfoValues<ChatChoiceResponse.FinishDetailsResponse>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse)obj).FinishDetails,
				Setter = (object obj, ChatChoiceResponse.FinishDetailsResponse? value) =>
				{
					((ChatChoiceResponse)obj).FinishDetails = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FinishDetails",
				JsonPropertyName = "finish_details"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<ChatChoiceResponse.ChatLogProbsResponse> propertyInfo6 = new JsonPropertyInfoValues<ChatChoiceResponse.ChatLogProbsResponse>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse)obj).LogProbs,
				Setter = (object obj, ChatChoiceResponse.ChatLogProbsResponse? value) =>
				{
					((ChatChoiceResponse)obj).LogProbs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LogProbs",
				JsonPropertyName = "logprobs"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			return array;
		}

		private void ChatChoiceResponseSerializeHandler(Utf8JsonWriter writer, ChatChoiceResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			ChatMessage delta = value.Delta;
			if (delta != null)
			{
				writer.WritePropertyName(PropName_delta);
				JsonSerializer.Serialize(writer, delta, ChatMessage);
			}
			ChatMessage message = value.Message;
			if (message != null)
			{
				writer.WritePropertyName(PropName_message);
				JsonSerializer.Serialize(writer, message, ChatMessage);
			}
			int? index = value.Index;
			if (index.HasValue)
			{
				writer.WritePropertyName(PropName_index);
				JsonSerializer.Serialize(writer, index, NullableInt32);
			}
			string finishReason = value.FinishReason;
			if (finishReason != null)
			{
				writer.WriteString(PropName_finish_reason, finishReason);
			}
			ChatChoiceResponse.FinishDetailsResponse finishDetails = value.FinishDetails;
			if (finishDetails != null)
			{
				writer.WritePropertyName(PropName_finish_details);
				FinishDetailsResponseSerializeHandler(writer, finishDetails);
			}
			ChatChoiceResponse.ChatLogProbsResponse logProbs = value.LogProbs;
			if (logProbs != null)
			{
				writer.WritePropertyName(PropName_logprobs);
				ChatLogProbsResponseSerializeHandler(writer, logProbs);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatChoiceResponse.ChatLogProbsResponse> Create_ChatLogProbsResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatChoiceResponse.ChatLogProbsResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatChoiceResponse.ChatLogProbsResponse> objectInfo = new JsonObjectInfoValues<ChatChoiceResponse.ChatLogProbsResponse>
				{
					ObjectCreator = () => new ChatChoiceResponse.ChatLogProbsResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ChatLogProbsResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ChatLogProbsResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ChatLogProbsResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[1];
			JsonPropertyInfoValues<List<ChatChoiceResponse.ContentItem>> propertyInfo = new JsonPropertyInfoValues<List<ChatChoiceResponse.ContentItem>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ChatLogProbsResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ChatLogProbsResponse)obj).Content,
				Setter = (object obj, List<ChatChoiceResponse.ContentItem>? value) =>
				{
					((ChatChoiceResponse.ChatLogProbsResponse)obj).Content = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Content",
				JsonPropertyName = "content"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			return array;
		}

		private void ChatLogProbsResponseSerializeHandler(Utf8JsonWriter writer, ChatChoiceResponse.ChatLogProbsResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			List<ChatChoiceResponse.ContentItem> content = value.Content;
			if (content != null)
			{
				writer.WritePropertyName(PropName_content);
				ListContentItemSerializeHandler(writer, content);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatChoiceResponse.ContentItem> Create_ContentItem(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatChoiceResponse.ContentItem> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatChoiceResponse.ContentItem> objectInfo = new JsonObjectInfoValues<ChatChoiceResponse.ContentItem>
				{
					ObjectCreator = () => new ChatChoiceResponse.ContentItem(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ContentItemPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ContentItemSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ContentItemPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<List<ChatChoiceResponse.ContentItemBase>> propertyInfo = new JsonPropertyInfoValues<List<ChatChoiceResponse.ContentItemBase>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ContentItem),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ContentItem)obj).TopLogProbs,
				Setter = (object obj, List<ChatChoiceResponse.ContentItemBase>? value) =>
				{
					((ChatChoiceResponse.ContentItem)obj).TopLogProbs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TopLogProbs",
				JsonPropertyName = "top_logprobs"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ContentItemBase),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ContentItemBase)obj).Token,
				Setter = (object obj, string? value) =>
				{
					((ChatChoiceResponse.ContentItemBase)obj).Token = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Token",
				JsonPropertyName = "token"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<double> propertyInfo3 = new JsonPropertyInfoValues<double>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ContentItemBase),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ContentItemBase)obj).LogProb,
				Setter = (object obj, double value) =>
				{
					((ChatChoiceResponse.ContentItemBase)obj).LogProb = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LogProb",
				JsonPropertyName = "logprob"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<List<int>> propertyInfo4 = new JsonPropertyInfoValues<List<int>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ContentItemBase),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ContentItemBase)obj).Bytes,
				Setter = (object obj, List<int>? value) =>
				{
					((ChatChoiceResponse.ContentItemBase)obj).Bytes = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Bytes",
				JsonPropertyName = "bytes"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void ContentItemSerializeHandler(Utf8JsonWriter writer, ChatChoiceResponse.ContentItem? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			List<ChatChoiceResponse.ContentItemBase> topLogProbs = value.TopLogProbs;
			if (topLogProbs != null)
			{
				writer.WritePropertyName(PropName_top_logprobs);
				ListContentItemBaseSerializeHandler(writer, topLogProbs);
			}
			string token = value.Token;
			if (token != null)
			{
				writer.WriteString(PropName_token, token);
			}
			writer.WriteNumber(PropName_logprob, value.LogProb);
			List<int> bytes = value.Bytes;
			if (bytes != null)
			{
				writer.WritePropertyName(PropName_bytes);
				ListInt32SerializeHandler(writer, bytes);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatChoiceResponse.ContentItemBase> Create_ContentItemBase(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatChoiceResponse.ContentItemBase> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatChoiceResponse.ContentItemBase> objectInfo = new JsonObjectInfoValues<ChatChoiceResponse.ContentItemBase>
				{
					ObjectCreator = () => new ChatChoiceResponse.ContentItemBase(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ContentItemBasePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ContentItemBaseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ContentItemBasePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ContentItemBase),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ContentItemBase)obj).Token,
				Setter = (object obj, string? value) =>
				{
					((ChatChoiceResponse.ContentItemBase)obj).Token = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Token",
				JsonPropertyName = "token"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<double> propertyInfo2 = new JsonPropertyInfoValues<double>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ContentItemBase),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ContentItemBase)obj).LogProb,
				Setter = (object obj, double value) =>
				{
					((ChatChoiceResponse.ContentItemBase)obj).LogProb = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LogProb",
				JsonPropertyName = "logprob"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<List<int>> propertyInfo3 = new JsonPropertyInfoValues<List<int>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.ContentItemBase),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.ContentItemBase)obj).Bytes,
				Setter = (object obj, List<int>? value) =>
				{
					((ChatChoiceResponse.ContentItemBase)obj).Bytes = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Bytes",
				JsonPropertyName = "bytes"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			return array;
		}

		private void ContentItemBaseSerializeHandler(Utf8JsonWriter writer, ChatChoiceResponse.ContentItemBase? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string token = value.Token;
			if (token != null)
			{
				writer.WriteString(PropName_token, token);
			}
			writer.WriteNumber(PropName_logprob, value.LogProb);
			List<int> bytes = value.Bytes;
			if (bytes != null)
			{
				writer.WritePropertyName(PropName_bytes);
				ListInt32SerializeHandler(writer, bytes);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatChoiceResponse.FinishDetailsResponse> Create_FinishDetailsResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatChoiceResponse.FinishDetailsResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatChoiceResponse.FinishDetailsResponse> objectInfo = new JsonObjectInfoValues<ChatChoiceResponse.FinishDetailsResponse>
				{
					ObjectCreator = () => new ChatChoiceResponse.FinishDetailsResponse(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => FinishDetailsResponsePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = FinishDetailsResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] FinishDetailsResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.FinishDetailsResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.FinishDetailsResponse)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((ChatChoiceResponse.FinishDetailsResponse)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatChoiceResponse.FinishDetailsResponse),
				Converter = null,
				Getter = (object obj) => ((ChatChoiceResponse.FinishDetailsResponse)obj).Stop,
				Setter = (object obj, string? value) =>
				{
					((ChatChoiceResponse.FinishDetailsResponse)obj).Stop = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Stop",
				JsonPropertyName = "stop"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void FinishDetailsResponseSerializeHandler(Utf8JsonWriter writer, ChatChoiceResponse.FinishDetailsResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			string stop = value.Stop;
			if (stop != null)
			{
				writer.WriteString(PropName_stop, stop);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<PropertyDefinition> Create_PropertyDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<PropertyDefinition> jsonTypeInfo))
			{
				JsonObjectInfoValues<PropertyDefinition> objectInfo = new JsonObjectInfoValues<PropertyDefinition>
				{
					ObjectCreator = () => new PropertyDefinition(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => PropertyDefinitionPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] PropertyDefinitionPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[26];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<IList<string>> propertyInfo2 = new JsonPropertyInfoValues<IList<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = (JsonConverter<IList<string>>)ExpandConverter(typeof(IList<string>), new SingleOrArrayToListConverter(), options),
				Getter = (object obj) => ((PropertyDefinition)obj).TypeList,
				Setter = (object obj, IList<string>? value) =>
				{
					((PropertyDefinition)obj).TypeList = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TypeList",
				JsonPropertyName = "type"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Constant,
				Setter = (object obj, string? value) =>
				{
					((PropertyDefinition)obj).Constant = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Constant",
				JsonPropertyName = "const"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<IDictionary<string, PropertyDefinition>> propertyInfo4 = new JsonPropertyInfoValues<IDictionary<string, PropertyDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Properties,
				Setter = (object obj, IDictionary<string, PropertyDefinition>? value) =>
				{
					((PropertyDefinition)obj).Properties = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Properties",
				JsonPropertyName = "properties"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<IList<string>> propertyInfo5 = new JsonPropertyInfoValues<IList<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Required,
				Setter = (object obj, IList<string>? value) =>
				{
					((PropertyDefinition)obj).Required = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Required",
				JsonPropertyName = "required"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<bool?> propertyInfo6 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).AdditionalProperties,
				Setter = (object obj, bool? value) =>
				{
					((PropertyDefinition)obj).AdditionalProperties = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AdditionalProperties",
				JsonPropertyName = "additionalProperties"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Title,
				Setter = (object obj, string? value) =>
				{
					((PropertyDefinition)obj).Title = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Title",
				JsonPropertyName = "title"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Description,
				Setter = (object obj, string? value) =>
				{
					((PropertyDefinition)obj).Description = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Description",
				JsonPropertyName = "description"
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<IList<string>> propertyInfo9 = new JsonPropertyInfoValues<IList<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Enum,
				Setter = (object obj, IList<string>? value) =>
				{
					((PropertyDefinition)obj).Enum = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Enum",
				JsonPropertyName = "enum"
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<int?> propertyInfo10 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).MinProperties,
				Setter = (object obj, int? value) =>
				{
					((PropertyDefinition)obj).MinProperties = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MinProperties",
				JsonPropertyName = "minProperties"
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<int?> propertyInfo11 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).MaxProperties,
				Setter = (object obj, int? value) =>
				{
					((PropertyDefinition)obj).MaxProperties = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxProperties",
				JsonPropertyName = "maxProperties"
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			JsonPropertyInfoValues<float?> propertyInfo12 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).MultipleOf,
				Setter = (object obj, float? value) =>
				{
					((PropertyDefinition)obj).MultipleOf = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MultipleOf",
				JsonPropertyName = "multipleOf"
			};
			array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
			JsonPropertyInfoValues<float?> propertyInfo13 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Minimum,
				Setter = (object obj, float? value) =>
				{
					((PropertyDefinition)obj).Minimum = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Minimum",
				JsonPropertyName = "minimum"
			};
			array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
			JsonPropertyInfoValues<float?> propertyInfo14 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).ExclusiveMinimum,
				Setter = (object obj, float? value) =>
				{
					((PropertyDefinition)obj).ExclusiveMinimum = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ExclusiveMinimum",
				JsonPropertyName = "exclusiveMinimum"
			};
			array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
			JsonPropertyInfoValues<float?> propertyInfo15 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Maximum,
				Setter = (object obj, float? value) =>
				{
					((PropertyDefinition)obj).Maximum = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Maximum",
				JsonPropertyName = "maximum"
			};
			array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
			JsonPropertyInfoValues<float?> propertyInfo16 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).ExclusiveMaximum,
				Setter = (object obj, float? value) =>
				{
					((PropertyDefinition)obj).ExclusiveMaximum = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ExclusiveMaximum",
				JsonPropertyName = "exclusiveMaximum"
			};
			array[15] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo16);
			JsonPropertyInfoValues<string> propertyInfo17 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Format,
				Setter = (object obj, string? value) =>
				{
					((PropertyDefinition)obj).Format = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Format",
				JsonPropertyName = "format"
			};
			array[16] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo17);
			JsonPropertyInfoValues<string> propertyInfo18 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Pattern,
				Setter = (object obj, string? value) =>
				{
					((PropertyDefinition)obj).Pattern = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Pattern",
				JsonPropertyName = "pattern"
			};
			array[17] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo18);
			JsonPropertyInfoValues<int?> propertyInfo19 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).MinItems,
				Setter = (object obj, int? value) =>
				{
					((PropertyDefinition)obj).MinItems = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MinItems",
				JsonPropertyName = "minItems"
			};
			array[18] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo19);
			JsonPropertyInfoValues<int?> propertyInfo20 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).MaxItems,
				Setter = (object obj, int? value) =>
				{
					((PropertyDefinition)obj).MaxItems = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxItems",
				JsonPropertyName = "maxItems"
			};
			array[19] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo20);
			JsonPropertyInfoValues<PropertyDefinition> propertyInfo21 = new JsonPropertyInfoValues<PropertyDefinition>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Items,
				Setter = (object obj, PropertyDefinition? value) =>
				{
					((PropertyDefinition)obj).Items = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Items",
				JsonPropertyName = "items"
			};
			array[20] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo21);
			JsonPropertyInfoValues<IDictionary<string, PropertyDefinition>> propertyInfo22 = new JsonPropertyInfoValues<IDictionary<string, PropertyDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Defs,
				Setter = (object obj, IDictionary<string, PropertyDefinition>? value) =>
				{
					((PropertyDefinition)obj).Defs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Defs",
				JsonPropertyName = "$defs"
			};
			array[21] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo22);
			JsonPropertyInfoValues<IDictionary<string, PropertyDefinition>> propertyInfo23 = new JsonPropertyInfoValues<IDictionary<string, PropertyDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Definitions,
				Setter = (object obj, IDictionary<string, PropertyDefinition>? value) =>
				{
					((PropertyDefinition)obj).Definitions = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Definitions",
				JsonPropertyName = "definitions"
			};
			array[22] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo23);
			JsonPropertyInfoValues<string> propertyInfo24 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).Ref,
				Setter = (object obj, string? value) =>
				{
					((PropertyDefinition)obj).Ref = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Ref",
				JsonPropertyName = "$ref"
			};
			array[23] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo24);
			JsonPropertyInfoValues<IList<PropertyDefinition>> propertyInfo25 = new JsonPropertyInfoValues<IList<PropertyDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).AnyOf,
				Setter = (object obj, IList<PropertyDefinition>? value) =>
				{
					((PropertyDefinition)obj).AnyOf = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AnyOf",
				JsonPropertyName = "anyOf"
			};
			array[24] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo25);
			JsonPropertyInfoValues<IList<PropertyDefinition>> propertyInfo26 = new JsonPropertyInfoValues<IList<PropertyDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PropertyDefinition),
				Converter = null,
				Getter = (object obj) => ((PropertyDefinition)obj).OneOf,
				Setter = (object obj, IList<PropertyDefinition>? value) =>
				{
					((PropertyDefinition)obj).OneOf = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OneOf",
				JsonPropertyName = "oneOf"
			};
			array[25] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo26);
			return array;
		}

		private JsonTypeInfo<CoreInteropRequest> Create_CoreInteropRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<CoreInteropRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<CoreInteropRequest> objectInfo = new JsonObjectInfoValues<CoreInteropRequest>
				{
					ObjectCreator = () => new CoreInteropRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => CoreInteropRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = CoreInteropRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] CoreInteropRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[1];
			JsonPropertyInfoValues<Dictionary<string, string>> propertyInfo = new JsonPropertyInfoValues<Dictionary<string, string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(CoreInteropRequest),
				Converter = null,
				Getter = (object obj) => ((CoreInteropRequest)obj).Params,
				Setter = (object obj, Dictionary<string, string>? value) =>
				{
					((CoreInteropRequest)obj).Params = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Params",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			return array;
		}

		private void CoreInteropRequestSerializeHandler(Utf8JsonWriter writer, CoreInteropRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			Dictionary<string, string> dictionary = value.Params;
			if (dictionary != null)
			{
				writer.WritePropertyName(PropName_Params);
				DictionaryStringStringSerializeHandler(writer, dictionary);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<DeviceType> Create_DeviceType(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<DeviceType> jsonTypeInfo))
			{
				JsonConverter converter = ExpandConverter(typeof(DeviceType), new JsonStringEnumConverter<DeviceType>(), options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<DeviceType>(options, converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<EpDownloadResult> Create_EpDownloadResult(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<EpDownloadResult> jsonTypeInfo))
			{
				JsonObjectInfoValues<EpDownloadResult> objectInfo = new JsonObjectInfoValues<EpDownloadResult>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new EpDownloadResult
					{
						Success = (bool)args[0],
						Status = (string)args[1],
						RegisteredEps = (string[])args[2],
						FailedEps = (string[])args[3]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => EpDownloadResultPropInit(options),
					ConstructorParameterMetadataInitializer = EpDownloadResultCtorParamInit,
					SerializeHandler = EpDownloadResultSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] EpDownloadResultPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<bool> propertyInfo = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EpDownloadResult),
				Converter = null,
				Getter = (object obj) => ((EpDownloadResult)obj).Success,
				Setter = (object obj, bool value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Success",
				JsonPropertyName = "Success"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsRequired = true;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EpDownloadResult),
				Converter = null,
				Getter = (object obj) => ((EpDownloadResult)obj).Status,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Status",
				JsonPropertyName = "Status"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsRequired = true;
			JsonPropertyInfoValues<string[]> propertyInfo3 = new JsonPropertyInfoValues<string[]>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EpDownloadResult),
				Converter = null,
				Getter = (object obj) => ((EpDownloadResult)obj).RegisteredEps,
				Setter = (object obj, string[]? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "RegisteredEps",
				JsonPropertyName = "RegisteredEps"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsRequired = true;
			JsonPropertyInfoValues<string[]> propertyInfo4 = new JsonPropertyInfoValues<string[]>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EpDownloadResult),
				Converter = null,
				Getter = (object obj) => ((EpDownloadResult)obj).FailedEps,
				Setter = (object obj, string[]? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FailedEps",
				JsonPropertyName = "FailedEps"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsRequired = true;
			return array;
		}

		private void EpDownloadResultSerializeHandler(Utf8JsonWriter writer, EpDownloadResult? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteBoolean(PropName_Success, value.Success);
			string status = value.Status;
			if (status != null)
			{
				writer.WriteString(PropName_Status, status);
			}
			string[] registeredEps = value.RegisteredEps;
			if (registeredEps != null)
			{
				writer.WritePropertyName(PropName_RegisteredEps);
				StringArraySerializeHandler(writer, registeredEps);
			}
			string[] failedEps = value.FailedEps;
			if (failedEps != null)
			{
				writer.WritePropertyName(PropName_FailedEps);
				StringArraySerializeHandler(writer, failedEps);
			}
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] EpDownloadResultCtorParamInit()
		{
			return new JsonParameterInfoValues[4]
			{
				new JsonParameterInfoValues
				{
					Name = "Success",
					ParameterType = typeof(bool),
					Position = 0
				},
				new JsonParameterInfoValues
				{
					Name = "Status",
					ParameterType = typeof(string),
					Position = 1
				},
				new JsonParameterInfoValues
				{
					Name = "RegisteredEps",
					ParameterType = typeof(string[]),
					Position = 2
				},
				new JsonParameterInfoValues
				{
					Name = "FailedEps",
					ParameterType = typeof(string[]),
					Position = 3
				}
			};
		}

		private JsonTypeInfo<EpInfo> Create_EpInfo(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<EpInfo> jsonTypeInfo))
			{
				JsonObjectInfoValues<EpInfo> objectInfo = new JsonObjectInfoValues<EpInfo>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new EpInfo
					{
						Name = (string)args[0],
						IsRegistered = (bool)args[1]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => EpInfoPropInit(options),
					ConstructorParameterMetadataInitializer = EpInfoCtorParamInit,
					SerializeHandler = EpInfoSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] EpInfoPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EpInfo),
				Converter = null,
				Getter = (object obj) => ((EpInfo)obj).Name,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "Name"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsRequired = true;
			JsonPropertyInfoValues<bool> propertyInfo2 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EpInfo),
				Converter = null,
				Getter = (object obj) => ((EpInfo)obj).IsRegistered,
				Setter = (object obj, bool value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "IsRegistered",
				JsonPropertyName = "IsRegistered"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsRequired = true;
			return array;
		}

		private void EpInfoSerializeHandler(Utf8JsonWriter writer, EpInfo? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_Name, name);
			}
			writer.WriteBoolean(PropName_IsRegistered, value.IsRegistered);
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] EpInfoCtorParamInit()
		{
			return new JsonParameterInfoValues[2]
			{
				new JsonParameterInfoValues
				{
					Name = "Name",
					ParameterType = typeof(string),
					Position = 0
				},
				new JsonParameterInfoValues
				{
					Name = "IsRegistered",
					ParameterType = typeof(bool),
					Position = 1
				}
			};
		}

		private JsonTypeInfo<EpInfo[]> Create_EpInfoArray(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<EpInfo[]> jsonTypeInfo))
			{
				JsonCollectionInfoValues<EpInfo[]> collectionInfo = new JsonCollectionInfoValues<EpInfo[]>
				{
					ObjectCreator = null,
					SerializeHandler = EpInfoArraySerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void EpInfoArraySerializeHandler(Utf8JsonWriter writer, EpInfo[]? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Length; i++)
			{
				EpInfoSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<ModelInfo> Create_ModelInfo(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ModelInfo> jsonTypeInfo))
			{
				JsonObjectInfoValues<ModelInfo> objectInfo = new JsonObjectInfoValues<ModelInfo>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new ModelInfo
					{
						Id = (string)args[0],
						Name = (string)args[1],
						Version = (int)args[2],
						Alias = (string)args[3],
						DisplayName = (string)args[4],
						ProviderType = (string)args[5],
						Uri = (string)args[6],
						ModelType = (string)args[7],
						PromptTemplate = (PromptTemplate)args[8],
						Publisher = (string)args[9],
						ModelSettings = (ModelSettings)args[10],
						License = (string)args[11],
						LicenseDescription = (string)args[12],
						Cached = (bool)args[13],
						Task = (string)args[14],
						Runtime = (Runtime)args[15],
						FileSizeMb = (int?)args[16],
						SupportsToolCalling = (bool?)args[17],
						MaxOutputTokens = (long?)args[18],
						MinFLVersion = (string)args[19],
						CreatedAtUnix = (long)args[20],
						ContextLength = (long?)args[21],
						InputModalities = (string)args[22],
						OutputModalities = (string)args[23],
						Capabilities = (string)args[24]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => ModelInfoPropInit(options),
					ConstructorParameterMetadataInitializer = ModelInfoCtorParamInit,
					SerializeHandler = ModelInfoSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ModelInfoPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[25];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Id,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsRequired = true;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Name,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsRequired = true;
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Version,
				Setter = (object obj, int value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Version",
				JsonPropertyName = "version"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Alias,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Alias",
				JsonPropertyName = "alias"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsRequired = true;
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).DisplayName,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "DisplayName",
				JsonPropertyName = "displayName"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).ProviderType,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ProviderType",
				JsonPropertyName = "providerType"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			array[5].IsRequired = true;
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Uri,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Uri",
				JsonPropertyName = "uri"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			array[6].IsRequired = true;
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).ModelType,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ModelType",
				JsonPropertyName = "modelType"
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			array[7].IsRequired = true;
			JsonPropertyInfoValues<PromptTemplate> propertyInfo9 = new JsonPropertyInfoValues<PromptTemplate>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).PromptTemplate,
				Setter = (object obj, PromptTemplate? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PromptTemplate",
				JsonPropertyName = "promptTemplate"
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<string> propertyInfo10 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Publisher,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Publisher",
				JsonPropertyName = "publisher"
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<ModelSettings> propertyInfo11 = new JsonPropertyInfoValues<ModelSettings>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).ModelSettings,
				Setter = (object obj, ModelSettings? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ModelSettings",
				JsonPropertyName = "modelSettings"
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).License,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "License",
				JsonPropertyName = "license"
			};
			array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
			JsonPropertyInfoValues<string> propertyInfo13 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).LicenseDescription,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LicenseDescription",
				JsonPropertyName = "licenseDescription"
			};
			array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
			JsonPropertyInfoValues<bool> propertyInfo14 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Cached,
				Setter = (object obj, bool value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Cached",
				JsonPropertyName = "cached"
			};
			array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
			JsonPropertyInfoValues<string> propertyInfo15 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Task,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Task",
				JsonPropertyName = "task"
			};
			array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
			JsonPropertyInfoValues<Runtime> propertyInfo16 = new JsonPropertyInfoValues<Runtime>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Runtime,
				Setter = (object obj, Runtime? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Runtime",
				JsonPropertyName = "runtime"
			};
			array[15] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo16);
			JsonPropertyInfoValues<int?> propertyInfo17 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).FileSizeMb,
				Setter = (object obj, int? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FileSizeMb",
				JsonPropertyName = "fileSizeMb"
			};
			array[16] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo17);
			JsonPropertyInfoValues<bool?> propertyInfo18 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).SupportsToolCalling,
				Setter = (object obj, bool? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "SupportsToolCalling",
				JsonPropertyName = "supportsToolCalling"
			};
			array[17] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo18);
			JsonPropertyInfoValues<long?> propertyInfo19 = new JsonPropertyInfoValues<long?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).MaxOutputTokens,
				Setter = (object obj, long? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxOutputTokens",
				JsonPropertyName = "maxOutputTokens"
			};
			array[18] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo19);
			JsonPropertyInfoValues<string> propertyInfo20 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).MinFLVersion,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MinFLVersion",
				JsonPropertyName = "minFLVersion"
			};
			array[19] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo20);
			JsonPropertyInfoValues<long> propertyInfo21 = new JsonPropertyInfoValues<long>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).CreatedAtUnix,
				Setter = (object obj, long value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CreatedAtUnix",
				JsonPropertyName = "createdAt"
			};
			array[20] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo21);
			JsonPropertyInfoValues<long?> propertyInfo22 = new JsonPropertyInfoValues<long?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).ContextLength,
				Setter = (object obj, long? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContextLength",
				JsonPropertyName = "contextLength"
			};
			array[21] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo22);
			JsonPropertyInfoValues<string> propertyInfo23 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).InputModalities,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "InputModalities",
				JsonPropertyName = "inputModalities"
			};
			array[22] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo23);
			JsonPropertyInfoValues<string> propertyInfo24 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).OutputModalities,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputModalities",
				JsonPropertyName = "outputModalities"
			};
			array[23] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo24);
			JsonPropertyInfoValues<string> propertyInfo25 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelInfo),
				Converter = null,
				Getter = (object obj) => ((ModelInfo)obj).Capabilities,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Capabilities",
				JsonPropertyName = "capabilities"
			};
			array[24] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo25);
			return array;
		}

		private void ModelInfoSerializeHandler(Utf8JsonWriter writer, ModelInfo? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string id = value.Id;
			if (id != null)
			{
				writer.WriteString(PropName_id, id);
			}
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_name, name);
			}
			writer.WriteNumber(PropName_version, value.Version);
			string alias = value.Alias;
			if (alias != null)
			{
				writer.WriteString(PropName_alias, alias);
			}
			string displayName = value.DisplayName;
			if (displayName != null)
			{
				writer.WriteString(PropName_displayName, displayName);
			}
			string providerType = value.ProviderType;
			if (providerType != null)
			{
				writer.WriteString(PropName_providerType, providerType);
			}
			string uri = value.Uri;
			if (uri != null)
			{
				writer.WriteString(PropName_uri, uri);
			}
			string modelType = value.ModelType;
			if (modelType != null)
			{
				writer.WriteString(PropName_modelType, modelType);
			}
			PromptTemplate promptTemplate = value.PromptTemplate;
			if (promptTemplate != null)
			{
				writer.WritePropertyName(PropName_promptTemplate);
				PromptTemplateSerializeHandler(writer, promptTemplate);
			}
			string publisher = value.Publisher;
			if (publisher != null)
			{
				writer.WriteString(PropName_publisher, publisher);
			}
			ModelSettings modelSettings = value.ModelSettings;
			if (modelSettings != null)
			{
				writer.WritePropertyName(PropName_modelSettings);
				ModelSettingsSerializeHandler(writer, modelSettings);
			}
			string license = value.License;
			if (license != null)
			{
				writer.WriteString(PropName_license, license);
			}
			string licenseDescription = value.LicenseDescription;
			if (licenseDescription != null)
			{
				writer.WriteString(PropName_licenseDescription, licenseDescription);
			}
			writer.WriteBoolean(PropName_cached, value.Cached);
			string task = value.Task;
			if (task != null)
			{
				writer.WriteString(PropName_task, task);
			}
			Runtime runtime = value.Runtime;
			if (runtime != null)
			{
				writer.WritePropertyName(PropName_runtime);
				RuntimeSerializeHandler(writer, runtime);
			}
			int? fileSizeMb = value.FileSizeMb;
			if (fileSizeMb.HasValue)
			{
				writer.WritePropertyName(PropName_fileSizeMb);
				JsonSerializer.Serialize(writer, fileSizeMb, NullableInt32);
			}
			bool? supportsToolCalling = value.SupportsToolCalling;
			if (supportsToolCalling.HasValue)
			{
				writer.WritePropertyName(PropName_supportsToolCalling);
				JsonSerializer.Serialize(writer, supportsToolCalling, NullableBoolean);
			}
			long? maxOutputTokens = value.MaxOutputTokens;
			if (maxOutputTokens.HasValue)
			{
				writer.WritePropertyName(PropName_maxOutputTokens);
				JsonSerializer.Serialize(writer, maxOutputTokens, NullableInt64);
			}
			string minFLVersion = value.MinFLVersion;
			if (minFLVersion != null)
			{
				writer.WriteString(PropName_minFLVersion, minFLVersion);
			}
			writer.WriteNumber(PropName_createdAt, value.CreatedAtUnix);
			long? contextLength = value.ContextLength;
			if (contextLength.HasValue)
			{
				writer.WritePropertyName(PropName_contextLength);
				JsonSerializer.Serialize(writer, contextLength, NullableInt64);
			}
			string inputModalities = value.InputModalities;
			if (inputModalities != null)
			{
				writer.WriteString(PropName_inputModalities, inputModalities);
			}
			string outputModalities = value.OutputModalities;
			if (outputModalities != null)
			{
				writer.WriteString(PropName_outputModalities, outputModalities);
			}
			string capabilities = value.Capabilities;
			if (capabilities != null)
			{
				writer.WriteString(PropName_capabilities, capabilities);
			}
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] ModelInfoCtorParamInit()
		{
			return new JsonParameterInfoValues[25]
			{
				new JsonParameterInfoValues
				{
					Name = "Id",
					ParameterType = typeof(string),
					Position = 0
				},
				new JsonParameterInfoValues
				{
					Name = "Name",
					ParameterType = typeof(string),
					Position = 1
				},
				new JsonParameterInfoValues
				{
					Name = "Version",
					ParameterType = typeof(int),
					Position = 2
				},
				new JsonParameterInfoValues
				{
					Name = "Alias",
					ParameterType = typeof(string),
					Position = 3
				},
				new JsonParameterInfoValues
				{
					Name = "DisplayName",
					ParameterType = typeof(string),
					Position = 4
				},
				new JsonParameterInfoValues
				{
					Name = "ProviderType",
					ParameterType = typeof(string),
					Position = 5
				},
				new JsonParameterInfoValues
				{
					Name = "Uri",
					ParameterType = typeof(string),
					Position = 6
				},
				new JsonParameterInfoValues
				{
					Name = "ModelType",
					ParameterType = typeof(string),
					Position = 7
				},
				new JsonParameterInfoValues
				{
					Name = "PromptTemplate",
					ParameterType = typeof(PromptTemplate),
					Position = 8
				},
				new JsonParameterInfoValues
				{
					Name = "Publisher",
					ParameterType = typeof(string),
					Position = 9
				},
				new JsonParameterInfoValues
				{
					Name = "ModelSettings",
					ParameterType = typeof(ModelSettings),
					Position = 10
				},
				new JsonParameterInfoValues
				{
					Name = "License",
					ParameterType = typeof(string),
					Position = 11
				},
				new JsonParameterInfoValues
				{
					Name = "LicenseDescription",
					ParameterType = typeof(string),
					Position = 12
				},
				new JsonParameterInfoValues
				{
					Name = "Cached",
					ParameterType = typeof(bool),
					Position = 13
				},
				new JsonParameterInfoValues
				{
					Name = "Task",
					ParameterType = typeof(string),
					Position = 14
				},
				new JsonParameterInfoValues
				{
					Name = "Runtime",
					ParameterType = typeof(Runtime),
					Position = 15
				},
				new JsonParameterInfoValues
				{
					Name = "FileSizeMb",
					ParameterType = typeof(int?),
					Position = 16
				},
				new JsonParameterInfoValues
				{
					Name = "SupportsToolCalling",
					ParameterType = typeof(bool?),
					Position = 17
				},
				new JsonParameterInfoValues
				{
					Name = "MaxOutputTokens",
					ParameterType = typeof(long?),
					Position = 18
				},
				new JsonParameterInfoValues
				{
					Name = "MinFLVersion",
					ParameterType = typeof(string),
					Position = 19
				},
				new JsonParameterInfoValues
				{
					Name = "CreatedAtUnix",
					ParameterType = typeof(long),
					Position = 20
				},
				new JsonParameterInfoValues
				{
					Name = "ContextLength",
					ParameterType = typeof(long?),
					Position = 21
				},
				new JsonParameterInfoValues
				{
					Name = "InputModalities",
					ParameterType = typeof(string),
					Position = 22
				},
				new JsonParameterInfoValues
				{
					Name = "OutputModalities",
					ParameterType = typeof(string),
					Position = 23
				},
				new JsonParameterInfoValues
				{
					Name = "Capabilities",
					ParameterType = typeof(string),
					Position = 24
				}
			};
		}

		private JsonTypeInfo<ModelSettings> Create_ModelSettings(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ModelSettings> jsonTypeInfo))
			{
				JsonObjectInfoValues<ModelSettings> objectInfo = new JsonObjectInfoValues<ModelSettings>
				{
					ObjectCreator = () => new ModelSettings(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ModelSettingsPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ModelSettingsSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ModelSettingsPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[1];
			JsonPropertyInfoValues<Parameter[]> propertyInfo = new JsonPropertyInfoValues<Parameter[]>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ModelSettings),
				Converter = null,
				Getter = (object obj) => ((ModelSettings)obj).Parameters,
				Setter = (object obj, Parameter[]? value) =>
				{
					((ModelSettings)obj).Parameters = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Parameters",
				JsonPropertyName = "parameters"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			return array;
		}

		private void ModelSettingsSerializeHandler(Utf8JsonWriter writer, ModelSettings? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			Parameter[] parameters = value.Parameters;
			if (parameters != null)
			{
				writer.WritePropertyName(PropName_parameters);
				ParameterArraySerializeHandler(writer, parameters);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ChatCompletionCreateRequestExtended> Create_ChatCompletionCreateRequestExtended(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ChatCompletionCreateRequestExtended> jsonTypeInfo))
			{
				JsonObjectInfoValues<ChatCompletionCreateRequestExtended> objectInfo = new JsonObjectInfoValues<ChatCompletionCreateRequestExtended>
				{
					ObjectCreator = () => new ChatCompletionCreateRequestExtended(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ChatCompletionCreateRequestExtendedPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ChatCompletionCreateRequestExtendedPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[33];
			JsonPropertyInfoValues<Dictionary<string, string>> propertyInfo = new JsonPropertyInfoValues<Dictionary<string, string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequestExtended),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequestExtended)obj).Metadata,
				Setter = (object obj, Dictionary<string, string>? value) =>
				{
					((ChatCompletionCreateRequestExtended)obj).Metadata = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Metadata",
				JsonPropertyName = "metadata"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<ResponseFormatExtended> propertyInfo2 = new JsonPropertyInfoValues<ResponseFormatExtended>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequestExtended),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequestExtended)obj).ResponseFormat,
				Setter = (object obj, ResponseFormatExtended? value) =>
				{
					((ChatCompletionCreateRequestExtended)obj).ResponseFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseFormat",
				JsonPropertyName = "response_format"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<IList<ChatMessage>> propertyInfo3 = new JsonPropertyInfoValues<IList<ChatMessage>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).Messages,
				Setter = (object obj, IList<ChatMessage>? value) =>
				{
					((ChatCompletionCreateRequest)obj).Messages = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Messages",
				JsonPropertyName = "messages"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<float?> propertyInfo4 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).TopP,
				Setter = (object obj, float? value) =>
				{
					((ChatCompletionCreateRequest)obj).TopP = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TopP",
				JsonPropertyName = "top_p"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<int?> propertyInfo5 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).N,
				Setter = (object obj, int? value) =>
				{
					((ChatCompletionCreateRequest)obj).N = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "N",
				JsonPropertyName = "n"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<bool?> propertyInfo6 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).Stream,
				Setter = (object obj, bool? value) =>
				{
					((ChatCompletionCreateRequest)obj).Stream = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Stream",
				JsonPropertyName = "stream"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<StreamOptions> propertyInfo7 = new JsonPropertyInfoValues<StreamOptions>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).StreamOptions,
				Setter = (object obj, StreamOptions? value) =>
				{
					((ChatCompletionCreateRequest)obj).StreamOptions = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StreamOptions",
				JsonPropertyName = "stream_options"
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Stop",
				JsonPropertyName = null
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<IList<string>> propertyInfo9 = new JsonPropertyInfoValues<IList<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StopAsList",
				JsonPropertyName = null
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<IList<string>> propertyInfo10 = new JsonPropertyInfoValues<IList<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).StopCalculated,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StopCalculated",
				JsonPropertyName = "stop"
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<int?> propertyInfo11 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).MaxTokens,
				Setter = (object obj, int? value) =>
				{
					((ChatCompletionCreateRequest)obj).MaxTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxTokens",
				JsonPropertyName = "max_tokens"
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			JsonPropertyInfoValues<int?> propertyInfo12 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).MaxCompletionTokens,
				Setter = (object obj, int? value) =>
				{
					((ChatCompletionCreateRequest)obj).MaxCompletionTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxCompletionTokens",
				JsonPropertyName = "max_completion_tokens"
			};
			array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
			JsonPropertyInfoValues<float?> propertyInfo13 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).PresencePenalty,
				Setter = (object obj, float? value) =>
				{
					((ChatCompletionCreateRequest)obj).PresencePenalty = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PresencePenalty",
				JsonPropertyName = "presence_penalty"
			};
			array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
			JsonPropertyInfoValues<float?> propertyInfo14 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).FrequencyPenalty,
				Setter = (object obj, float? value) =>
				{
					((ChatCompletionCreateRequest)obj).FrequencyPenalty = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "FrequencyPenalty",
				JsonPropertyName = "frequency_penalty"
			};
			array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
			JsonPropertyInfoValues<object> propertyInfo15 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).LogitBias,
				Setter = (object obj, object? value) =>
				{
					((ChatCompletionCreateRequest)obj).LogitBias = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LogitBias",
				JsonPropertyName = "logit_bias"
			};
			array[14] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo15);
			JsonPropertyInfoValues<IList<ToolDefinition>> propertyInfo16 = new JsonPropertyInfoValues<IList<ToolDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Tools",
				JsonPropertyName = null
			};
			array[15] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo16);
			JsonPropertyInfoValues<object> propertyInfo17 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolsAsObject",
				JsonPropertyName = null
			};
			array[16] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo17);
			JsonPropertyInfoValues<object> propertyInfo18 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).ToolsCalculated,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolsCalculated",
				JsonPropertyName = "tools"
			};
			array[17] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo18);
			JsonPropertyInfoValues<ToolChoice> propertyInfo19 = new JsonPropertyInfoValues<ToolChoice>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolChoice",
				JsonPropertyName = null
			};
			array[18] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo19);
			JsonPropertyInfoValues<object> propertyInfo20 = new JsonPropertyInfoValues<object>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).ToolChoiceCalculated,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolChoiceCalculated",
				JsonPropertyName = "tool_choice"
			};
			array[19] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo20);
			JsonPropertyInfoValues<ResponseFormat> propertyInfo21 = new JsonPropertyInfoValues<ResponseFormat>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).ResponseFormat,
				Setter = (object obj, ResponseFormat? value) =>
				{
					((ChatCompletionCreateRequest)obj).ResponseFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseFormat",
				JsonPropertyName = "response_format"
			};
			array[20] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo21);
			JsonPropertyInfoValues<ChatCompletionCreateRequest.ResponseFormats?> propertyInfo22 = new JsonPropertyInfoValues<ChatCompletionCreateRequest.ResponseFormats?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ChatResponseFormat",
				JsonPropertyName = null
			};
			array[21] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo22);
			JsonPropertyInfoValues<int?> propertyInfo23 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).Seed,
				Setter = (object obj, int? value) =>
				{
					((ChatCompletionCreateRequest)obj).Seed = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Seed",
				JsonPropertyName = "seed"
			};
			array[22] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo23);
			JsonPropertyInfoValues<bool?> propertyInfo24 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).LogProbs,
				Setter = (object obj, bool? value) =>
				{
					((ChatCompletionCreateRequest)obj).LogProbs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LogProbs",
				JsonPropertyName = "logprobs"
			};
			array[23] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo24);
			JsonPropertyInfoValues<int?> propertyInfo25 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).TopLogprobs,
				Setter = (object obj, int? value) =>
				{
					((ChatCompletionCreateRequest)obj).TopLogprobs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TopLogprobs",
				JsonPropertyName = "top_logprobs"
			};
			array[24] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo25);
			JsonPropertyInfoValues<bool?> propertyInfo26 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).ParallelToolCalls,
				Setter = (object obj, bool? value) =>
				{
					((ChatCompletionCreateRequest)obj).ParallelToolCalls = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ParallelToolCalls",
				JsonPropertyName = "parallel_tool_calls"
			};
			array[25] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo26);
			JsonPropertyInfoValues<string> propertyInfo27 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateRequest)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = "model"
			};
			array[26] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo27);
			JsonPropertyInfoValues<string> propertyInfo28 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).ReasoningEffort,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateRequest)obj).ReasoningEffort = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ReasoningEffort",
				JsonPropertyName = "reasoning_effort"
			};
			array[27] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo28);
			JsonPropertyInfoValues<ChatCompletionCreateRequest.ReasoningEfforts?> propertyInfo29 = new JsonPropertyInfoValues<ChatCompletionCreateRequest.ReasoningEfforts?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ChatReasoningEffort",
				JsonPropertyName = null
			};
			array[28] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo29);
			JsonPropertyInfoValues<float?> propertyInfo30 = new JsonPropertyInfoValues<float?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).Temperature,
				Setter = (object obj, float? value) =>
				{
					((ChatCompletionCreateRequest)obj).Temperature = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Temperature",
				JsonPropertyName = "temperature"
			};
			array[29] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo30);
			JsonPropertyInfoValues<string> propertyInfo31 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).User,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateRequest)obj).User = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "User",
				JsonPropertyName = "user"
			};
			array[30] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo31);
			JsonPropertyInfoValues<string> propertyInfo32 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).ServiceTier,
				Setter = (object obj, string? value) =>
				{
					((ChatCompletionCreateRequest)obj).ServiceTier = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ServiceTier",
				JsonPropertyName = "service_tier"
			};
			array[31] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo32);
			JsonPropertyInfoValues<bool?> propertyInfo33 = new JsonPropertyInfoValues<bool?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ChatCompletionCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ChatCompletionCreateRequest)obj).Store,
				Setter = (object obj, bool? value) =>
				{
					((ChatCompletionCreateRequest)obj).Store = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Store",
				JsonPropertyName = "store"
			};
			array[32] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo33);
			return array;
		}

		private JsonTypeInfo<CoreErrorResponse> Create_CoreErrorResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<CoreErrorResponse> jsonTypeInfo))
			{
				JsonObjectInfoValues<CoreErrorResponse> objectInfo = new JsonObjectInfoValues<CoreErrorResponse>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new CoreErrorResponse
					{
						Code = (string)args[0],
						Message = (string)args[1],
						IsTransient = (bool)args[2]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => CoreErrorResponsePropInit(options),
					ConstructorParameterMetadataInitializer = CoreErrorResponseCtorParamInit,
					SerializeHandler = CoreErrorResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] CoreErrorResponsePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(CoreErrorResponse),
				Converter = null,
				Getter = (object obj) => ((CoreErrorResponse)obj).Code,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Code",
				JsonPropertyName = "code"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(CoreErrorResponse),
				Converter = null,
				Getter = (object obj) => ((CoreErrorResponse)obj).Message,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Message",
				JsonPropertyName = "message"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<bool> propertyInfo3 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(CoreErrorResponse),
				Converter = null,
				Getter = (object obj) => ((CoreErrorResponse)obj).IsTransient,
				Setter = (object obj, bool value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "IsTransient",
				JsonPropertyName = "isTransient"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			return array;
		}

		private void CoreErrorResponseSerializeHandler(Utf8JsonWriter writer, CoreErrorResponse? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string code = value.Code;
			if (code != null)
			{
				writer.WriteString(PropName_code, code);
			}
			string message = value.Message;
			if (message != null)
			{
				writer.WriteString(PropName_message, message);
			}
			writer.WriteBoolean(PropName_isTransient, value.IsTransient);
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] CoreErrorResponseCtorParamInit()
		{
			return new JsonParameterInfoValues[3]
			{
				new JsonParameterInfoValues
				{
					Name = "Code",
					ParameterType = typeof(string),
					Position = 0
				},
				new JsonParameterInfoValues
				{
					Name = "Message",
					ParameterType = typeof(string),
					Position = 1
				},
				new JsonParameterInfoValues
				{
					Name = "IsTransient",
					ParameterType = typeof(bool),
					Position = 2
				}
			};
		}

		private JsonTypeInfo<EmbeddingCreateRequestExtended> Create_EmbeddingCreateRequestExtended(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<EmbeddingCreateRequestExtended> jsonTypeInfo))
			{
				JsonObjectInfoValues<EmbeddingCreateRequestExtended> objectInfo = new JsonObjectInfoValues<EmbeddingCreateRequestExtended>
				{
					ObjectCreator = () => new EmbeddingCreateRequestExtended(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => EmbeddingCreateRequestExtendedPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = EmbeddingCreateRequestExtendedSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] EmbeddingCreateRequestExtendedPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[6];
			JsonPropertyInfoValues<List<string>> propertyInfo = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "InputAsList",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateRequest),
				Converter = null,
				Getter = null,
				Setter = null,
				IgnoreCondition = JsonIgnoreCondition.Always,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Input",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<IList<string>> propertyInfo3 = new JsonPropertyInfoValues<IList<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateRequest),
				Converter = null,
				Getter = (object obj) => ((EmbeddingCreateRequest)obj).InputCalculated,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "InputCalculated",
				JsonPropertyName = "input"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<int?> propertyInfo4 = new JsonPropertyInfoValues<int?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateRequest),
				Converter = null,
				Getter = (object obj) => ((EmbeddingCreateRequest)obj).Dimensions,
				Setter = (object obj, int? value) =>
				{
					((EmbeddingCreateRequest)obj).Dimensions = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Dimensions",
				JsonPropertyName = "dimensions"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateRequest),
				Converter = null,
				Getter = (object obj) => ((EmbeddingCreateRequest)obj).EncodingFormat,
				Setter = (object obj, string? value) =>
				{
					((EmbeddingCreateRequest)obj).EncodingFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EncodingFormat",
				JsonPropertyName = "encoding_format"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EmbeddingCreateRequest),
				Converter = null,
				Getter = (object obj) => ((EmbeddingCreateRequest)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((EmbeddingCreateRequest)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = "model"
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			return array;
		}

		private void EmbeddingCreateRequestExtendedSerializeHandler(Utf8JsonWriter writer, EmbeddingCreateRequestExtended? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			IList<string> inputCalculated = value.InputCalculated;
			if (inputCalculated != null)
			{
				writer.WritePropertyName(PropName_input);
				IListStringSerializeHandler(writer, inputCalculated);
			}
			int? dimensions = value.Dimensions;
			if (dimensions.HasValue)
			{
				writer.WritePropertyName(PropName_dimensions);
				JsonSerializer.Serialize(writer, dimensions, NullableInt32);
			}
			string encodingFormat = value.EncodingFormat;
			if (encodingFormat != null)
			{
				writer.WriteString(PropName_encoding_format, encodingFormat);
			}
			string model = value.Model;
			if (model != null)
			{
				writer.WriteString(PropName_model, model);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<LiveAudioTranscriptionRaw> Create_LiveAudioTranscriptionRaw(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<LiveAudioTranscriptionRaw> jsonTypeInfo))
			{
				JsonObjectInfoValues<LiveAudioTranscriptionRaw> objectInfo = new JsonObjectInfoValues<LiveAudioTranscriptionRaw>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new LiveAudioTranscriptionRaw
					{
						IsFinal = (bool)args[0],
						Text = (string)args[1],
						StartTime = (double?)args[2],
						EndTime = (double?)args[3],
						Language = (string)args[4]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => LiveAudioTranscriptionRawPropInit(options),
					ConstructorParameterMetadataInitializer = LiveAudioTranscriptionRawCtorParamInit,
					SerializeHandler = LiveAudioTranscriptionRawSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] LiveAudioTranscriptionRawPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<bool> propertyInfo = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(LiveAudioTranscriptionRaw),
				Converter = null,
				Getter = (object obj) => ((LiveAudioTranscriptionRaw)obj).IsFinal,
				Setter = (object obj, bool value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "IsFinal",
				JsonPropertyName = "is_final"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(LiveAudioTranscriptionRaw),
				Converter = null,
				Getter = (object obj) => ((LiveAudioTranscriptionRaw)obj).Text,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Text",
				JsonPropertyName = "text"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<double?> propertyInfo3 = new JsonPropertyInfoValues<double?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(LiveAudioTranscriptionRaw),
				Converter = null,
				Getter = (object obj) => ((LiveAudioTranscriptionRaw)obj).StartTime,
				Setter = (object obj, double? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StartTime",
				JsonPropertyName = "start_time"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<double?> propertyInfo4 = new JsonPropertyInfoValues<double?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(LiveAudioTranscriptionRaw),
				Converter = null,
				Getter = (object obj) => ((LiveAudioTranscriptionRaw)obj).EndTime,
				Setter = (object obj, double? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EndTime",
				JsonPropertyName = "end_time"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(LiveAudioTranscriptionRaw),
				Converter = null,
				Getter = (object obj) => ((LiveAudioTranscriptionRaw)obj).Language,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Language",
				JsonPropertyName = "language"
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			return array;
		}

		private void LiveAudioTranscriptionRawSerializeHandler(Utf8JsonWriter writer, LiveAudioTranscriptionRaw? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteBoolean(PropName_is_final, value.IsFinal);
			string text = value.Text;
			if (text != null)
			{
				writer.WriteString(PropName_text, text);
			}
			double? startTime = value.StartTime;
			if (startTime.HasValue)
			{
				writer.WritePropertyName(PropName_start_time);
				JsonSerializer.Serialize(writer, startTime, NullableDouble);
			}
			double? endTime = value.EndTime;
			if (endTime.HasValue)
			{
				writer.WritePropertyName(PropName_end_time);
				JsonSerializer.Serialize(writer, endTime, NullableDouble);
			}
			string language = value.Language;
			if (language != null)
			{
				writer.WriteString(PropName_language, language);
			}
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] LiveAudioTranscriptionRawCtorParamInit()
		{
			return new JsonParameterInfoValues[5]
			{
				new JsonParameterInfoValues
				{
					Name = "IsFinal",
					ParameterType = typeof(bool),
					Position = 0
				},
				new JsonParameterInfoValues
				{
					Name = "Text",
					ParameterType = typeof(string),
					Position = 1
				},
				new JsonParameterInfoValues
				{
					Name = "StartTime",
					ParameterType = typeof(double?),
					Position = 2
				},
				new JsonParameterInfoValues
				{
					Name = "EndTime",
					ParameterType = typeof(double?),
					Position = 3
				},
				new JsonParameterInfoValues
				{
					Name = "Language",
					ParameterType = typeof(string),
					Position = 4
				}
			};
		}

		private JsonTypeInfo<ResponseFormatExtended> Create_ResponseFormatExtended(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseFormatExtended> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseFormatExtended> objectInfo = new JsonObjectInfoValues<ResponseFormatExtended>
				{
					ObjectCreator = () => new ResponseFormatExtended(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseFormatExtendedPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = ResponseFormatExtendedSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseFormatExtendedPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseFormatExtended),
				Converter = null,
				Getter = (object obj) => ((ResponseFormatExtended)obj).LarkGrammar,
				Setter = (object obj, string? value) =>
				{
					((ResponseFormatExtended)obj).LarkGrammar = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "LarkGrammar",
				JsonPropertyName = "lark_grammar"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseFormat),
				Converter = null,
				Getter = (object obj) => ((ResponseFormat)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((ResponseFormat)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema> propertyInfo3 = new JsonPropertyInfoValues<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseFormat),
				Converter = null,
				Getter = (object obj) => ((ResponseFormat)obj).JsonSchema,
				Setter = (object obj, Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema? value) =>
				{
					((ResponseFormat)obj).JsonSchema = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "JsonSchema",
				JsonPropertyName = "json_schema"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			return array;
		}

		private void ResponseFormatExtendedSerializeHandler(Utf8JsonWriter writer, ResponseFormatExtended? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string larkGrammar = value.LarkGrammar;
			if (larkGrammar != null)
			{
				writer.WriteString(PropName_lark_grammar, larkGrammar);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema jsonSchema = value.JsonSchema;
			if (jsonSchema != null)
			{
				writer.WritePropertyName(PropName_json_schema);
				JsonSchemaSerializeHandler(writer, jsonSchema);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<Parameter> Create_Parameter(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Parameter> jsonTypeInfo))
			{
				JsonObjectInfoValues<Parameter> objectInfo = new JsonObjectInfoValues<Parameter>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new Parameter
					{
						Name = (string)args[0]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => ParameterPropInit(options),
					ConstructorParameterMetadataInitializer = ParameterCtorParamInit,
					SerializeHandler = ParameterSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ParameterPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Parameter),
				Converter = null,
				Getter = (object obj) => ((Parameter)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((Parameter)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsRequired = true;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Parameter),
				Converter = null,
				Getter = (object obj) => ((Parameter)obj).Value,
				Setter = (object obj, string? value) =>
				{
					((Parameter)obj).Value = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Value",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void ParameterSerializeHandler(Utf8JsonWriter writer, Parameter? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_Name, name);
			}
			string value2 = value.Value;
			if (value2 != null)
			{
				writer.WriteString(PropName_Value, value2);
			}
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] ParameterCtorParamInit()
		{
			return new JsonParameterInfoValues[1]
			{
				new JsonParameterInfoValues
				{
					Name = "Name",
					ParameterType = typeof(string),
					Position = 0
				}
			};
		}

		private JsonTypeInfo<Parameter[]> Create_ParameterArray(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Parameter[]> jsonTypeInfo))
			{
				JsonCollectionInfoValues<Parameter[]> collectionInfo = new JsonCollectionInfoValues<Parameter[]>
				{
					ObjectCreator = null,
					SerializeHandler = ParameterArraySerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ParameterArraySerializeHandler(Utf8JsonWriter writer, Parameter[]? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Length; i++)
			{
				ParameterSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<PromptTemplate> Create_PromptTemplate(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<PromptTemplate> jsonTypeInfo))
			{
				JsonObjectInfoValues<PromptTemplate> objectInfo = new JsonObjectInfoValues<PromptTemplate>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new PromptTemplate
					{
						System = (string)args[0],
						User = (string)args[1],
						Assistant = (string)args[2],
						Prompt = (string)args[3]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => PromptTemplatePropInit(options),
					ConstructorParameterMetadataInitializer = PromptTemplateCtorParamInit,
					SerializeHandler = PromptTemplateSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] PromptTemplatePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PromptTemplate),
				Converter = null,
				Getter = (object obj) => ((PromptTemplate)obj).System,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "System",
				JsonPropertyName = "system"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PromptTemplate),
				Converter = null,
				Getter = (object obj) => ((PromptTemplate)obj).User,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "User",
				JsonPropertyName = "user"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PromptTemplate),
				Converter = null,
				Getter = (object obj) => ((PromptTemplate)obj).Assistant,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Assistant",
				JsonPropertyName = "assistant"
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(PromptTemplate),
				Converter = null,
				Getter = (object obj) => ((PromptTemplate)obj).Prompt,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Prompt",
				JsonPropertyName = "prompt"
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void PromptTemplateSerializeHandler(Utf8JsonWriter writer, PromptTemplate? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string system = value.System;
			if (system != null)
			{
				writer.WriteString(PropName_system, system);
			}
			string user = value.User;
			if (user != null)
			{
				writer.WriteString(PropName_user, user);
			}
			string assistant = value.Assistant;
			if (assistant != null)
			{
				writer.WriteString(PropName_assistant, assistant);
			}
			string prompt = value.Prompt;
			if (prompt != null)
			{
				writer.WriteString(PropName_prompt, prompt);
			}
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] PromptTemplateCtorParamInit()
		{
			return new JsonParameterInfoValues[4]
			{
				new JsonParameterInfoValues
				{
					Name = "System",
					ParameterType = typeof(string),
					Position = 0
				},
				new JsonParameterInfoValues
				{
					Name = "User",
					ParameterType = typeof(string),
					Position = 1
				},
				new JsonParameterInfoValues
				{
					Name = "Assistant",
					ParameterType = typeof(string),
					Position = 2
				},
				new JsonParameterInfoValues
				{
					Name = "Prompt",
					ParameterType = typeof(string),
					Position = 3
				}
			};
		}

		private JsonTypeInfo<Runtime> Create_Runtime(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Runtime> jsonTypeInfo))
			{
				JsonObjectInfoValues<Runtime> objectInfo = new JsonObjectInfoValues<Runtime>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = (object[] args) => new Runtime
					{
						DeviceType = (DeviceType)args[0],
						ExecutionProvider = (string)args[1]
					},
					PropertyMetadataInitializer = (JsonSerializerContext _) => RuntimePropInit(options),
					ConstructorParameterMetadataInitializer = RuntimeCtorParamInit,
					SerializeHandler = RuntimeSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] RuntimePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<DeviceType> propertyInfo = new JsonPropertyInfoValues<DeviceType>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Runtime),
				Converter = null,
				Getter = (object obj) => ((Runtime)obj).DeviceType,
				Setter = (object obj, DeviceType value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "DeviceType",
				JsonPropertyName = "deviceType"
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(Runtime),
				Converter = null,
				Getter = (object obj) => ((Runtime)obj).ExecutionProvider,
				Setter = (object obj, string? value) =>
				{
					throw new InvalidOperationException("Setting init-only properties is not supported in source generation mode.");
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ExecutionProvider",
				JsonPropertyName = "executionProvider"
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void RuntimeSerializeHandler(Utf8JsonWriter writer, Runtime? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WritePropertyName(PropName_deviceType);
			JsonSerializer.Serialize(writer, value.DeviceType, DeviceType);
			string executionProvider = value.ExecutionProvider;
			if (executionProvider != null)
			{
				writer.WriteString(PropName_executionProvider, executionProvider);
			}
			writer.WriteEndObject();
		}

		private static JsonParameterInfoValues[] RuntimeCtorParamInit()
		{
			return new JsonParameterInfoValues[2]
			{
				new JsonParameterInfoValues
				{
					Name = "DeviceType",
					ParameterType = typeof(DeviceType),
					Position = 0
				},
				new JsonParameterInfoValues
				{
					Name = "ExecutionProvider",
					ParameterType = typeof(string),
					Position = 1
				}
			};
		}

		private JsonTypeInfo<Dictionary<string, IEnumerable<string>>> Create_DictionaryStringIEnumerableString(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Dictionary<string, IEnumerable<string>>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, IEnumerable<string>>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, IEnumerable<string>>>
				{
					ObjectCreator = () => new Dictionary<string, IEnumerable<string>>(),
					SerializeHandler = DictionaryStringIEnumerableStringSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, IEnumerable<string>>, string, IEnumerable<string>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void DictionaryStringIEnumerableStringSerializeHandler(Utf8JsonWriter writer, Dictionary<string, IEnumerable<string>>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			foreach (KeyValuePair<string, IEnumerable<string>> item in value)
			{
				writer.WritePropertyName(item.Key);
				IEnumerableStringSerializeHandler(writer, item.Value);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<Dictionary<string, string>> Create_DictionaryStringString(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Dictionary<string, string>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, string>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, string>>
				{
					ObjectCreator = () => new Dictionary<string, string>(),
					SerializeHandler = DictionaryStringStringSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, string>, string, string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void DictionaryStringStringSerializeHandler(Utf8JsonWriter writer, Dictionary<string, string>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			foreach (KeyValuePair<string, string> item in value)
			{
				writer.WriteString(item.Key, item.Value);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<IDictionary<string, PropertyDefinition>> Create_IDictionaryStringPropertyDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IDictionary<string, PropertyDefinition>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IDictionary<string, PropertyDefinition>> collectionInfo = new JsonCollectionInfoValues<IDictionary<string, PropertyDefinition>>
				{
					ObjectCreator = () => new Dictionary<string, PropertyDefinition>(),
					SerializeHandler = IDictionaryStringPropertyDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIDictionaryInfo<IDictionary<string, PropertyDefinition>, string, PropertyDefinition>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IDictionaryStringPropertyDefinitionSerializeHandler(Utf8JsonWriter writer, IDictionary<string, PropertyDefinition>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			foreach (KeyValuePair<string, PropertyDefinition> item in value)
			{
				writer.WritePropertyName(item.Key);
				JsonSerializer.Serialize(writer, item.Value, PropertyDefinition);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<IEnumerable<string>> Create_IEnumerableString(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IEnumerable<string>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IEnumerable<string>> collectionInfo = new JsonCollectionInfoValues<IEnumerable<string>>
				{
					ObjectCreator = null,
					SerializeHandler = IEnumerableStringSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIEnumerableInfo<IEnumerable<string>, string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IEnumerableStringSerializeHandler(Utf8JsonWriter writer, IEnumerable<string>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			foreach (string item in value)
			{
				writer.WriteStringValue(item);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<IList<ChatMessage>> Create_IListChatMessage(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IList<ChatMessage>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<ChatMessage>> collectionInfo = new JsonCollectionInfoValues<IList<ChatMessage>>
				{
					ObjectCreator = null,
					SerializeHandler = IListChatMessageSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<ChatMessage>, ChatMessage>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IListChatMessageSerializeHandler(Utf8JsonWriter writer, IList<ChatMessage>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				JsonSerializer.Serialize(writer, value[i], ChatMessage);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<IList<FunctionDefinition>> Create_IListFunctionDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IList<FunctionDefinition>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<FunctionDefinition>> collectionInfo = new JsonCollectionInfoValues<IList<FunctionDefinition>>
				{
					ObjectCreator = null,
					SerializeHandler = IListFunctionDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<FunctionDefinition>, FunctionDefinition>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IListFunctionDefinitionSerializeHandler(Utf8JsonWriter writer, IList<FunctionDefinition>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				FunctionDefinitionSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<IList<ToolCall>> Create_IListToolCall(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IList<ToolCall>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<ToolCall>> collectionInfo = new JsonCollectionInfoValues<IList<ToolCall>>
				{
					ObjectCreator = null,
					SerializeHandler = IListToolCallSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<ToolCall>, ToolCall>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IListToolCallSerializeHandler(Utf8JsonWriter writer, IList<ToolCall>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				ToolCallSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<IList<ToolDefinition>> Create_IListToolDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IList<ToolDefinition>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<ToolDefinition>> collectionInfo = new JsonCollectionInfoValues<IList<ToolDefinition>>
				{
					ObjectCreator = null,
					SerializeHandler = IListToolDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<ToolDefinition>, ToolDefinition>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IListToolDefinitionSerializeHandler(Utf8JsonWriter writer, IList<ToolDefinition>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				JsonSerializer.Serialize(writer, value[i], ToolDefinition);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<IList<PropertyDefinition>> Create_IListPropertyDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IList<PropertyDefinition>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<PropertyDefinition>> collectionInfo = new JsonCollectionInfoValues<IList<PropertyDefinition>>
				{
					ObjectCreator = null,
					SerializeHandler = IListPropertyDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<PropertyDefinition>, PropertyDefinition>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IListPropertyDefinitionSerializeHandler(Utf8JsonWriter writer, IList<PropertyDefinition>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				JsonSerializer.Serialize(writer, value[i], PropertyDefinition);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<IList<string>> Create_IListString(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<IList<string>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<string>> collectionInfo = new JsonCollectionInfoValues<IList<string>>
				{
					ObjectCreator = null,
					SerializeHandler = IListStringSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<string>, string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void IListStringSerializeHandler(Utf8JsonWriter writer, IList<string>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				writer.WriteStringValue(value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<double>> Create_ListDouble(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<double>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<double>> collectionInfo = new JsonCollectionInfoValues<List<double>>
				{
					ObjectCreator = () => new List<double>(),
					SerializeHandler = ListDoubleSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<double>, double>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListDoubleSerializeHandler(Utf8JsonWriter writer, List<double>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				writer.WriteNumberValue(value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<FileSearchFilter>> Create_ListFileSearchFilter(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<FileSearchFilter>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<FileSearchFilter>> collectionInfo = new JsonCollectionInfoValues<List<FileSearchFilter>>
				{
					ObjectCreator = () => new List<FileSearchFilter>(),
					SerializeHandler = ListFileSearchFilterSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<FileSearchFilter>, FileSearchFilter>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListFileSearchFilterSerializeHandler(Utf8JsonWriter writer, List<FileSearchFilter>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				JsonSerializer.Serialize(writer, value[i], FileSearchFilter);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<AudioCreateTranscriptionResponse.Segment>> Create_ListSegment(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<AudioCreateTranscriptionResponse.Segment>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<AudioCreateTranscriptionResponse.Segment>> collectionInfo = new JsonCollectionInfoValues<List<AudioCreateTranscriptionResponse.Segment>>
				{
					ObjectCreator = () => new List<AudioCreateTranscriptionResponse.Segment>(),
					SerializeHandler = ListSegmentSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<AudioCreateTranscriptionResponse.Segment>, AudioCreateTranscriptionResponse.Segment>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListSegmentSerializeHandler(Utf8JsonWriter writer, List<AudioCreateTranscriptionResponse.Segment>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				SegmentSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<AudioCreateTranscriptionResponse.WordSegment>> Create_ListWordSegment(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<AudioCreateTranscriptionResponse.WordSegment>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<AudioCreateTranscriptionResponse.WordSegment>> collectionInfo = new JsonCollectionInfoValues<List<AudioCreateTranscriptionResponse.WordSegment>>
				{
					ObjectCreator = () => new List<AudioCreateTranscriptionResponse.WordSegment>(),
					SerializeHandler = ListWordSegmentSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<AudioCreateTranscriptionResponse.WordSegment>, AudioCreateTranscriptionResponse.WordSegment>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListWordSegmentSerializeHandler(Utf8JsonWriter writer, List<AudioCreateTranscriptionResponse.WordSegment>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				WordSegmentSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<EmbeddingResponse>> Create_ListEmbeddingResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<EmbeddingResponse>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<EmbeddingResponse>> collectionInfo = new JsonCollectionInfoValues<List<EmbeddingResponse>>
				{
					ObjectCreator = () => new List<EmbeddingResponse>(),
					SerializeHandler = ListEmbeddingResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<EmbeddingResponse>, EmbeddingResponse>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListEmbeddingResponseSerializeHandler(Utf8JsonWriter writer, List<EmbeddingResponse>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				EmbeddingResponseSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<ChatChoiceResponse.ContentItem>> Create_ListContentItem(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ChatChoiceResponse.ContentItem>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<ChatChoiceResponse.ContentItem>> collectionInfo = new JsonCollectionInfoValues<List<ChatChoiceResponse.ContentItem>>
				{
					ObjectCreator = () => new List<ChatChoiceResponse.ContentItem>(),
					SerializeHandler = ListContentItemSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ChatChoiceResponse.ContentItem>, ChatChoiceResponse.ContentItem>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListContentItemSerializeHandler(Utf8JsonWriter writer, List<ChatChoiceResponse.ContentItem>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				ContentItemSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<ChatChoiceResponse.ContentItemBase>> Create_ListContentItemBase(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ChatChoiceResponse.ContentItemBase>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<ChatChoiceResponse.ContentItemBase>> collectionInfo = new JsonCollectionInfoValues<List<ChatChoiceResponse.ContentItemBase>>
				{
					ObjectCreator = () => new List<ChatChoiceResponse.ContentItemBase>(),
					SerializeHandler = ListContentItemBaseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ChatChoiceResponse.ContentItemBase>, ChatChoiceResponse.ContentItemBase>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListContentItemBaseSerializeHandler(Utf8JsonWriter writer, List<ChatChoiceResponse.ContentItemBase>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				ContentItemBaseSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<ChatChoiceResponse>> Create_ListChatChoiceResponse(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ChatChoiceResponse>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<ChatChoiceResponse>> collectionInfo = new JsonCollectionInfoValues<List<ChatChoiceResponse>>
				{
					ObjectCreator = () => new List<ChatChoiceResponse>(),
					SerializeHandler = ListChatChoiceResponseSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ChatChoiceResponse>, ChatChoiceResponse>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListChatChoiceResponseSerializeHandler(Utf8JsonWriter writer, List<ChatChoiceResponse>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				ChatChoiceResponseSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<ModelInfo>> Create_ListModelInfo(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ModelInfo>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<ModelInfo>> collectionInfo = new JsonCollectionInfoValues<List<ModelInfo>>
				{
					ObjectCreator = () => new List<ModelInfo>(),
					SerializeHandler = ListModelInfoSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ModelInfo>, ModelInfo>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListModelInfoSerializeHandler(Utf8JsonWriter writer, List<ModelInfo>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				ModelInfoSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<int>> Create_ListInt32(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<int>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<int>> collectionInfo = new JsonCollectionInfoValues<List<int>>
				{
					ObjectCreator = () => new List<int>(),
					SerializeHandler = ListInt32SerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<int>, int>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListInt32SerializeHandler(Utf8JsonWriter writer, List<int>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				writer.WriteNumberValue(value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<string>> Create_ListString(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<string>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<string>> collectionInfo = new JsonCollectionInfoValues<List<string>>
				{
					ObjectCreator = () => new List<string>(),
					SerializeHandler = ListStringSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<string>, string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListStringSerializeHandler(Utf8JsonWriter writer, List<string>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				writer.WriteStringValue(value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<DateTimeOffset> Create_DateTimeOffset(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<DateTimeOffset> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<DateTimeOffset>(options, JsonMetadataServices.DateTimeOffsetConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<DateTimeOffset?> Create_NullableDateTimeOffset(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<DateTimeOffset?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<DateTimeOffset>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<DateTimeOffset?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<Stream> Create_Stream(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Stream> jsonTypeInfo))
			{
				JsonObjectInfoValues<Stream> objectInfo = new JsonObjectInfoValues<Stream>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => StreamPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					SerializeHandler = StreamSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] StreamPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[8];
			JsonPropertyInfoValues<bool> propertyInfo = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).CanRead,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CanRead",
				JsonPropertyName = null
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<bool> propertyInfo2 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).CanSeek,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CanSeek",
				JsonPropertyName = null
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<bool> propertyInfo3 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).CanTimeout,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CanTimeout",
				JsonPropertyName = null
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<bool> propertyInfo4 = new JsonPropertyInfoValues<bool>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).CanWrite,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CanWrite",
				JsonPropertyName = null
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<long> propertyInfo5 = new JsonPropertyInfoValues<long>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).Length,
				Setter = null,
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Length",
				JsonPropertyName = null
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<long> propertyInfo6 = new JsonPropertyInfoValues<long>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).Position,
				Setter = (object obj, long value) =>
				{
					((Stream)obj).Position = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Position",
				JsonPropertyName = null
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<int> propertyInfo7 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).ReadTimeout,
				Setter = (object obj, int value) =>
				{
					((Stream)obj).ReadTimeout = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ReadTimeout",
				JsonPropertyName = null
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<int> propertyInfo8 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = true,
				DeclaringType = typeof(Stream),
				Converter = null,
				Getter = (object obj) => ((Stream)obj).WriteTimeout,
				Setter = (object obj, int value) =>
				{
					((Stream)obj).WriteTimeout = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "WriteTimeout",
				JsonPropertyName = null
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			return array;
		}

		private void StreamSerializeHandler(Utf8JsonWriter writer, Stream? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteBoolean(PropName_CanRead, value.CanRead);
			writer.WriteBoolean(PropName_CanSeek, value.CanSeek);
			writer.WriteBoolean(PropName_CanTimeout, value.CanTimeout);
			writer.WriteBoolean(PropName_CanWrite, value.CanWrite);
			writer.WriteNumber(PropName_Length, value.Length);
			writer.WriteNumber(PropName_Position, value.Position);
			writer.WriteNumber(PropName_ReadTimeout, value.ReadTimeout);
			writer.WriteNumber(PropName_WriteTimeout, value.WriteTimeout);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<HttpStatusCode> Create_HttpStatusCode(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<HttpStatusCode> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<HttpStatusCode>(options, JsonMetadataServices.GetEnumConverter<HttpStatusCode>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<JsonElement> Create_JsonElement(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<JsonElement> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<JsonElement>(options, JsonMetadataServices.JsonElementConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<int> Create_Int32(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<int> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int>(options, JsonMetadataServices.Int32Converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<int?> Create_NullableInt32(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<int?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<int>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<long> Create_Int64(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<long> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<long>(options, JsonMetadataServices.Int64Converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<long?> Create_NullableInt64(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<long?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<long>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<long?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<object> Create_Object(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<object> jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<object>(options, JsonMetadataServices.ObjectConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
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

		private JsonTypeInfo<string[]> Create_StringArray(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<string[]> jsonTypeInfo))
			{
				JsonCollectionInfoValues<string[]> collectionInfo = new JsonCollectionInfoValues<string[]>
				{
					ObjectCreator = null,
					SerializeHandler = StringArraySerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void StringArraySerializeHandler(Utf8JsonWriter writer, string[]? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Length; i++)
			{
				writer.WriteStringValue(value[i]);
			}
			writer.WriteEndArray();
		}

		public JsonSerializationContext()
			: base(null)
		{
		}

		public JsonSerializationContext(JsonSerializerOptions options)
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
			if (type == typeof(bool))
			{
				return Create_Boolean(options);
			}
			if (type == typeof(bool?))
			{
				return Create_NullableBoolean(options);
			}
			if (type == typeof(byte[]))
			{
				return Create_ByteArray(options);
			}
			if (type == typeof(double))
			{
				return Create_Double(options);
			}
			if (type == typeof(double?))
			{
				return Create_NullableDouble(options);
			}
			if (type == typeof(float))
			{
				return Create_Single(options);
			}
			if (type == typeof(float?))
			{
				return Create_NullableSingle(options);
			}
			if (type == typeof(AudioCreateTranscriptionRequest))
			{
				return Create_AudioCreateTranscriptionRequest(options);
			}
			if (type == typeof(ChatMessage))
			{
				return Create_ChatMessage(options);
			}
			if (type == typeof(FileSearchFilter))
			{
				return Create_FileSearchFilter(options);
			}
			if (type == typeof(FileSearchTool))
			{
				return Create_FileSearchTool(options);
			}
			if (type == typeof(FunctionCall))
			{
				return Create_FunctionCall(options);
			}
			if (type == typeof(FunctionDefinition))
			{
				return Create_FunctionDefinition(options);
			}
			if (type == typeof(Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema))
			{
				return Create_JsonSchema(options);
			}
			if (type == typeof(RankingOptions))
			{
				return Create_RankingOptions(options);
			}
			if (type == typeof(ResponseFormat))
			{
				return Create_ResponseFormat(options);
			}
			if (type == typeof(StreamOptions))
			{
				return Create_StreamOptions(options);
			}
			if (type == typeof(ToolCall))
			{
				return Create_ToolCall(options);
			}
			if (type == typeof(ToolChoice))
			{
				return Create_ToolChoice(options);
			}
			if (type == typeof(ToolChoice.FunctionTool))
			{
				return Create_FunctionTool(options);
			}
			if (type == typeof(ToolDefinition))
			{
				return Create_ToolDefinition(options);
			}
			if (type == typeof(AudioCreateTranscriptionResponse))
			{
				return Create_AudioCreateTranscriptionResponse(options);
			}
			if (type == typeof(AudioCreateTranscriptionResponse.Segment))
			{
				return Create_Segment(options);
			}
			if (type == typeof(AudioCreateTranscriptionResponse.WordSegment))
			{
				return Create_WordSegment(options);
			}
			if (type == typeof(ChatCompletionCreateResponse))
			{
				return Create_ChatCompletionCreateResponse(options);
			}
			if (type == typeof(CompletionTokensDetails))
			{
				return Create_CompletionTokensDetails(options);
			}
			if (type == typeof(EmbeddingCreateResponse))
			{
				return Create_EmbeddingCreateResponse(options);
			}
			if (type == typeof(EmbeddingResponse))
			{
				return Create_EmbeddingResponse(options);
			}
			if (type == typeof(Error))
			{
				return Create_Error(options);
			}
			if (type == typeof(OpenAIInfo))
			{
				return Create_OpenAIInfo(options);
			}
			if (type == typeof(PromptTokensDetails))
			{
				return Create_PromptTokensDetails(options);
			}
			if (type == typeof(RateLimitInfo))
			{
				return Create_RateLimitInfo(options);
			}
			if (type == typeof(ResponseHeaderValues))
			{
				return Create_ResponseHeaderValues(options);
			}
			if (type == typeof(UsageResponse))
			{
				return Create_UsageResponse(options);
			}
			if (type == typeof(ChatChoiceResponse))
			{
				return Create_ChatChoiceResponse(options);
			}
			if (type == typeof(ChatChoiceResponse.ChatLogProbsResponse))
			{
				return Create_ChatLogProbsResponse(options);
			}
			if (type == typeof(ChatChoiceResponse.ContentItem))
			{
				return Create_ContentItem(options);
			}
			if (type == typeof(ChatChoiceResponse.ContentItemBase))
			{
				return Create_ContentItemBase(options);
			}
			if (type == typeof(ChatChoiceResponse.FinishDetailsResponse))
			{
				return Create_FinishDetailsResponse(options);
			}
			if (type == typeof(PropertyDefinition))
			{
				return Create_PropertyDefinition(options);
			}
			if (type == typeof(CoreInteropRequest))
			{
				return Create_CoreInteropRequest(options);
			}
			if (type == typeof(DeviceType))
			{
				return Create_DeviceType(options);
			}
			if (type == typeof(EpDownloadResult))
			{
				return Create_EpDownloadResult(options);
			}
			if (type == typeof(EpInfo))
			{
				return Create_EpInfo(options);
			}
			if (type == typeof(EpInfo[]))
			{
				return Create_EpInfoArray(options);
			}
			if (type == typeof(ModelInfo))
			{
				return Create_ModelInfo(options);
			}
			if (type == typeof(ModelSettings))
			{
				return Create_ModelSettings(options);
			}
			if (type == typeof(ChatCompletionCreateRequestExtended))
			{
				return Create_ChatCompletionCreateRequestExtended(options);
			}
			if (type == typeof(CoreErrorResponse))
			{
				return Create_CoreErrorResponse(options);
			}
			if (type == typeof(EmbeddingCreateRequestExtended))
			{
				return Create_EmbeddingCreateRequestExtended(options);
			}
			if (type == typeof(LiveAudioTranscriptionRaw))
			{
				return Create_LiveAudioTranscriptionRaw(options);
			}
			if (type == typeof(ResponseFormatExtended))
			{
				return Create_ResponseFormatExtended(options);
			}
			if (type == typeof(Parameter))
			{
				return Create_Parameter(options);
			}
			if (type == typeof(Parameter[]))
			{
				return Create_ParameterArray(options);
			}
			if (type == typeof(PromptTemplate))
			{
				return Create_PromptTemplate(options);
			}
			if (type == typeof(Runtime))
			{
				return Create_Runtime(options);
			}
			if (type == typeof(Dictionary<string, IEnumerable<string>>))
			{
				return Create_DictionaryStringIEnumerableString(options);
			}
			if (type == typeof(Dictionary<string, string>))
			{
				return Create_DictionaryStringString(options);
			}
			if (type == typeof(IDictionary<string, PropertyDefinition>))
			{
				return Create_IDictionaryStringPropertyDefinition(options);
			}
			if (type == typeof(IEnumerable<string>))
			{
				return Create_IEnumerableString(options);
			}
			if (type == typeof(IList<ChatMessage>))
			{
				return Create_IListChatMessage(options);
			}
			if (type == typeof(IList<FunctionDefinition>))
			{
				return Create_IListFunctionDefinition(options);
			}
			if (type == typeof(IList<ToolCall>))
			{
				return Create_IListToolCall(options);
			}
			if (type == typeof(IList<ToolDefinition>))
			{
				return Create_IListToolDefinition(options);
			}
			if (type == typeof(IList<PropertyDefinition>))
			{
				return Create_IListPropertyDefinition(options);
			}
			if (type == typeof(IList<string>))
			{
				return Create_IListString(options);
			}
			if (type == typeof(List<double>))
			{
				return Create_ListDouble(options);
			}
			if (type == typeof(List<FileSearchFilter>))
			{
				return Create_ListFileSearchFilter(options);
			}
			if (type == typeof(List<AudioCreateTranscriptionResponse.Segment>))
			{
				return Create_ListSegment(options);
			}
			if (type == typeof(List<AudioCreateTranscriptionResponse.WordSegment>))
			{
				return Create_ListWordSegment(options);
			}
			if (type == typeof(List<EmbeddingResponse>))
			{
				return Create_ListEmbeddingResponse(options);
			}
			if (type == typeof(List<ChatChoiceResponse.ContentItem>))
			{
				return Create_ListContentItem(options);
			}
			if (type == typeof(List<ChatChoiceResponse.ContentItemBase>))
			{
				return Create_ListContentItemBase(options);
			}
			if (type == typeof(List<ChatChoiceResponse>))
			{
				return Create_ListChatChoiceResponse(options);
			}
			if (type == typeof(List<ModelInfo>))
			{
				return Create_ListModelInfo(options);
			}
			if (type == typeof(List<int>))
			{
				return Create_ListInt32(options);
			}
			if (type == typeof(List<string>))
			{
				return Create_ListString(options);
			}
			if (type == typeof(DateTimeOffset))
			{
				return Create_DateTimeOffset(options);
			}
			if (type == typeof(DateTimeOffset?))
			{
				return Create_NullableDateTimeOffset(options);
			}
			if (type == typeof(Stream))
			{
				return Create_Stream(options);
			}
			if (type == typeof(HttpStatusCode))
			{
				return Create_HttpStatusCode(options);
			}
			if (type == typeof(JsonElement))
			{
				return Create_JsonElement(options);
			}
			if (type == typeof(int))
			{
				return Create_Int32(options);
			}
			if (type == typeof(int?))
			{
				return Create_NullableInt32(options);
			}
			if (type == typeof(long))
			{
				return Create_Int64(options);
			}
			if (type == typeof(long?))
			{
				return Create_NullableInt64(options);
			}
			if (type == typeof(object))
			{
				return Create_Object(options);
			}
			if (type == typeof(string))
			{
				return Create_String(options);
			}
			if (type == typeof(string[]))
			{
				return Create_StringArray(options);
			}
			return null;
		}
	}
	internal sealed class ModelLoadManager : IModelLoadManager, IDisposable
	{
		private readonly Uri? _externalServiceUrl;

		private readonly HttpClient? _httpClient;

		private readonly ICoreInterop _coreInterop;

		private readonly ILogger _logger;

		internal ModelLoadManager(Uri? externalServiceUrl, ICoreInterop coreInterop, ILogger logger)
		{
			_externalServiceUrl = externalServiceUrl;
			_coreInterop = coreInterop;
			_logger = logger;
			if (_externalServiceUrl != null)
			{
				_httpClient = new HttpClient
				{
					BaseAddress = _externalServiceUrl
				};
				string input = "foundry-local-cs-sdk/" + FoundryLocalManager.AssemblyVersion;
				_httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(input);
			}
		}

		public async Task LoadAsync(string modelId, CancellationToken? ct = null)
		{
			if (_externalServiceUrl != null)
			{
				await WebLoadModelAsync(modelId, ct).ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "Model", modelId } }
			};
			ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("load_model", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error loading model " + modelId + ": " + response.Error);
			}
			_logger.LogInformation("Model {ModelId} loaded successfully: {Message}", modelId, response.Data);
		}

		public async Task UnloadAsync(string modelId, CancellationToken? ct = null)
		{
			if (_externalServiceUrl != null)
			{
				await WebUnloadModelAsync(modelId, ct).ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			CoreInteropRequest commandInput = new CoreInteropRequest
			{
				Params = new Dictionary<string, string> { { "Model", modelId } }
			};
			ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("unload_model", commandInput, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error unloading model " + modelId + ": " + response.Error);
			}
			_logger.LogInformation("Model {ModelId} unloaded successfully: {Message}", modelId, response.Data);
		}

		public async Task<string[]> ListLoadedModelsAsync(CancellationToken? ct = null)
		{
			if (_externalServiceUrl != null)
			{
				return await WebListLoadedModelAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			ICoreInterop.Response response = await _coreInterop.ExecuteCommandAsync("list_loaded_models", null, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (response.Error != null)
			{
				throw new FoundryLocalException("Error listing loaded models: " + response.Error);
			}
			_logger.LogDebug("Loaded models json: {Data}", response.Data);
			JsonTypeInfo<string[]> stringArray = JsonSerializationContext.Default.StringArray;
			return JsonSerializer.Deserialize(response.Data, stringArray) ?? Array.Empty<string>();
		}

		private async Task<string[]> WebListLoadedModelAsync(CancellationToken? ct = null)
		{
			using HttpResponseMessage response = await _httpClient.GetAsync("models/loaded", ct ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			if (!response.IsSuccessStatusCode)
			{
				throw new FoundryLocalException($"Error listing loaded models from {_externalServiceUrl}: {response.ReasonPhrase}");
			}
			string text = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			_logger.LogDebug("Loaded models json from {WebService}: {Data}", _externalServiceUrl, text);
			JsonTypeInfo<string[]> stringArray = JsonSerializationContext.Default.StringArray;
			return JsonSerializer.Deserialize(text, stringArray) ?? Array.Empty<string>();
		}

		private async Task WebLoadModelAsync(string modelId, CancellationToken? ct = null)
		{
			Dictionary<string, string> source = new Dictionary<string, string>();
			UriBuilder uriBuilder = new UriBuilder(_externalServiceUrl)
			{
				Path = "models/load/" + modelId,
				Query = string.Join("&", source.Select((KeyValuePair<string, string> kvp) => Uri.EscapeDataString(kvp.Key) + "=" + Uri.EscapeDataString(kvp.Value)))
			};
			using HttpResponseMessage response = await _httpClient.GetAsync(uriBuilder.Uri, ct ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			if (!response.IsSuccessStatusCode)
			{
				throw new FoundryLocalException($"Error loading model {modelId} from {_externalServiceUrl}: {response.ReasonPhrase}");
			}
			string text = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			_logger.LogInformation("Model {ModelId} loaded successfully from {WebService}: {Message}", modelId, _externalServiceUrl, text);
		}

		private async Task WebUnloadModelAsync(string modelId, CancellationToken? ct = null)
		{
			using HttpResponseMessage response = await _httpClient.GetAsync(new Uri("models/unload/" + modelId), ct ?? CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			if (!response.IsSuccessStatusCode)
			{
				throw new FoundryLocalException($"Error unloading model {modelId} from {_externalServiceUrl}: {response.ReasonPhrase}");
			}
			string text = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			_logger.LogInformation("Model {ModelId} unloaded successfully from {WebService}: {Message}", modelId, _externalServiceUrl, text);
		}

		public void Dispose()
		{
			_httpClient?.Dispose();
		}
	}
}
