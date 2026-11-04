using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Betalgo.Ranul.OpenAI.Builders;
using Betalgo.Ranul.OpenAI.EndpointProviders;
using Betalgo.Ranul.OpenAI.Extensions;
using Betalgo.Ranul.OpenAI.Interfaces;
using Betalgo.Ranul.OpenAI.Managers;
using Betalgo.Ranul.OpenAI.ObjectModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RealtimeModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.BatchResponseModel;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.FileResponseModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.FineTuneResponseModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.FineTuningJobResponseModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.ImageResponseModel;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.ModelResponseModels;
using Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.VectorStoreResponseModels;
using Betalgo.Ranul.OpenAI.ObjectModels.SharedModels;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETCoreApp,Version=v9.0", FrameworkDisplayName = ".NET 9.0")]
[assembly: AssemblyCompany("Betalgo Up Ltd.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Betalgo Up Ltd.")]
[assembly: AssemblyDescription(".NET library for the OpenAI services by Betalgo Ranul")]
[assembly: AssemblyFileVersion("9.1.0.0")]
[assembly: AssemblyInformationalVersion("9.1.0+a7607aa6a7029d729b2393fceb56327b237be8d0")]
[assembly: AssemblyProduct("OpenAI .NET library by Betalgo Ranul")]
[assembly: AssemblyTitle("Betalgo.Ranul.OpenAI")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/betalgo/openai.git")]
[assembly: AssemblyVersion("9.1.0.0")]
[module: RefSafetyRules(11)]
namespace Betalgo.Ranul.OpenAI
{
	public enum ProviderType
	{
		OpenAI = 1,
		Azure
	}
	public class OpenAIOptions
	{
		private const string OpenAIDefaultApiVersion = "v1";

		private const string OpenAIDefaultBaseDomain = "https://api.openai.com/";

		private const string AzureOpenAIDefaultApiVersion = "2023-12-01-preview";

		private const string OpenAIDefaultAssistantsApiVersion = "v2";

		public static readonly string SettingKey = "OpenAIServiceOptions";

		private string? _apiVersion;

		private string? _baseDomain;

		public ProviderType ProviderType { get; set; } = ProviderType.OpenAI;

		public string? Assistants => "assistants=v2";

		public string? Organization { get; set; }

		public string ApiKey { get; set; }

		public string ApiVersion
		{
			get
			{
				string text = _apiVersion;
				if (text == null)
				{
					text = (_apiVersion = ProviderType switch
					{
						ProviderType.OpenAI => "v1", 
						ProviderType.Azure => "2023-12-01-preview", 
						_ => throw new ArgumentOutOfRangeException("ProviderType"), 
					});
				}
				return text;
			}
			set
			{
				_apiVersion = value;
			}
		}

		public string BaseRealTimeSocketUrl { get; set; } = "wss://api.openai.com/v1/realtime";

		public string BaseDomain
		{
			get
			{
				string text = _baseDomain;
				if (text == null)
				{
					text = (_baseDomain = ProviderType switch
					{
						ProviderType.OpenAI => "https://api.openai.com/", 
						ProviderType.Azure => (ResourceName == null) ? null : ("https://" + ResourceName + ".openai.azure.com/"), 
						_ => throw new ArgumentOutOfRangeException("ProviderType"), 
					});
				}
				return text;
			}
			set
			{
				_baseDomain = value;
			}
		}

		public string? DeploymentId { get; set; }

		public string? ResourceName { get; set; }

		[Obsolete("Use Default Model Id")]
		public string? DefaultEngineId
		{
			get
			{
				return DefaultModelId;
			}
			set
			{
				DefaultModelId = value;
			}
		}

		public bool ValidateApiOptions { get; set; } = true;

		public string? DefaultModelId { get; set; }

		public bool UseBeta { get; set; }

		private static OpenAIOptions CreateAzureSettings(string apiKey, string deploymentId, string resourceName, string? apiVersion)
		{
			return new OpenAIOptions
			{
				ProviderType = ProviderType.Azure,
				ResourceName = resourceName,
				DeploymentId = deploymentId,
				ApiKey = apiKey,
				ApiVersion = (apiVersion ?? "2023-12-01-preview")
			};
		}

		private static OpenAIOptions CreateAzureSettingsWithBaseDomain(string apiKey, string deploymentId, string baseDomain, string? apiVersion)
		{
			return new OpenAIOptions
			{
				ProviderType = ProviderType.Azure,
				BaseDomain = baseDomain,
				DeploymentId = deploymentId,
				ApiKey = apiKey,
				ApiVersion = (apiVersion ?? "2023-12-01-preview")
			};
		}

		public void Validate()
		{
			if (!ValidateApiOptions)
			{
				return;
			}
			if (string.IsNullOrEmpty(ApiKey))
			{
				throw new ArgumentNullException("ApiKey");
			}
			if (string.IsNullOrEmpty(ApiVersion))
			{
				throw new ArgumentNullException("ApiVersion");
			}
			if (string.IsNullOrEmpty(BaseDomain))
			{
				if (ProviderType == ProviderType.Azure && string.IsNullOrEmpty(ResourceName))
				{
					throw new ArgumentNullException("ResourceName");
				}
				throw new ArgumentNullException("BaseDomain");
			}
			if (ProviderType == ProviderType.Azure)
			{
				if (string.IsNullOrEmpty(DeploymentId))
				{
					throw new ArgumentNullException("DeploymentId");
				}
				if (BaseDomain.Equals("https://.openai.azure.com/"))
				{
					throw new ArgumentNullException("ResourceName");
				}
			}
			else if (ProviderType == ProviderType.OpenAI)
			{
				if (!string.IsNullOrEmpty(DeploymentId))
				{
					throw new ArgumentException("DeploymentId is not supported for OpenAI Provider. Set ProviderType to Azure or remove DeploymentId");
				}
				if (!string.IsNullOrEmpty(ResourceName))
				{
					throw new ArgumentException("ResourceName is not supported for OpenAI Provider. Set ProviderType to Azure or remove ResourceName");
				}
			}
		}
	}
}
namespace Betalgo.Ranul.OpenAI.Tokenizer.GPT3
{
	internal static class EmbeddedResource
	{
		private static readonly string? Namespace = typeof(EmbeddedResource).Namespace;

		internal static string Read(string name)
		{
			Assembly assembly = typeof(EmbeddedResource).GetTypeInfo().Assembly;
			if (assembly == null)
			{
				throw new NullReferenceException($"[{Namespace}] {name} assembly not found");
			}
			using Stream stream = assembly.GetManifestResourceStream(Namespace + "." + name);
			if (stream == null)
			{
				throw new NullReferenceException($"[{Namespace}] {name} resource not found");
			}
			using StreamReader streamReader = new StreamReader(stream);
			return streamReader.ReadToEnd();
		}
	}
	internal static class TokenizerGpt3Settings
	{
		private static readonly Lazy<Dictionary<string, int>> EncoderLazy = new Lazy<Dictionary<string, int>>(BuildEncoder);

		private static readonly Lazy<Dictionary<Tuple<string, string>, int>> BpeRanksLazy = new Lazy<Dictionary<Tuple<string, string>, int>>(BuildBpeRanks);

		private static readonly string? Namespace = typeof(TokenizerGpt3Settings).Namespace;

		internal static Dictionary<string, int> Encoder => EncoderLazy.Value;

		internal static Dictionary<Tuple<string, string>, int> BpeRanks => BpeRanksLazy.Value;

		private static Dictionary<Tuple<string, string>, int> BuildBpeRanks()
		{
			string[] array = EmbeddedResource.Read("vocab.bpe").Split('\n');
			List<Tuple<string, string>> list = new ArraySegment<string>(array, 1, array.Length - 1).Where((string x) => x.Trim().Length > 0).Select((string x) =>
			{
				string[] array2 = x.Split(' ');
				return new Tuple<string, string>(array2[0], array2[1]);
			}).ToList();
			return DictZip(list, Range(0, list.Count));
		}

		private static Dictionary<string, int> BuildEncoder()
		{
			return JsonSerializer.Deserialize<Dictionary<string, int>>(EmbeddedResource.Read("encoder.json"), new JsonSerializerOptions()) ?? throw new NullReferenceException("[" + Namespace + "] encoder.json deserialization returned NULL");
		}

		private static Dictionary<Tuple<string, string>, int> DictZip(IReadOnlyList<Tuple<string, string>> x, IReadOnlyList<int> y)
		{
			Dictionary<Tuple<string, string>, int> dictionary = new Dictionary<Tuple<string, string>, int>();
			for (int i = 0; i < x.Count; i++)
			{
				dictionary.Add(x[i], y[i]);
			}
			return dictionary;
		}

		private static List<int> Range(int x, int y)
		{
			return Enumerable.Range(x, y - x).ToList();
		}
	}
	public static class TokenizerGpt3
	{
		private static readonly ConcurrentDictionary<string, string> BpeCache = new ConcurrentDictionary<string, string>();

		private static readonly ConcurrentDictionary<int, char> BytesToUnicodeCache = InitializeBytesToUnicodeCache();

		private static readonly Regex EncodingRegex = new Regex("'s|'t|'re|'ve|'m|'ll|'d| ?\\p{L}+| ?\\p{N}+| ?[^\\s\\p{L}\\p{N}]+|\\s+(?!\\S)|\\s+", RegexOptions.Compiled);

		public static IEnumerable<int> Encode(string text, bool cleanUpCREOL = false)
		{
			if (string.IsNullOrEmpty(text))
			{
				yield break;
			}
			if (cleanUpCREOL)
			{
				text = text.Replace("\r", "");
			}
			foreach (string newToken in GetNewTokens(text))
			{
				yield return TokenizerGpt3Settings.Encoder[newToken];
			}
		}

		public static int TokenCount(string text, bool cleanUpCREOL = false)
		{
			if (string.IsNullOrEmpty(text))
			{
				return 0;
			}
			if (cleanUpCREOL)
			{
				text = text.Replace("\r", "");
			}
			return GetNewTokens(text).Count();
		}

		private static IEnumerable<string> GetNewTokens(string text)
		{
			ConcurrentDictionary<int, char> byteEncoder = BytesToUnicodeCache;
			MatchCollection source = EncodingRegex.Matches(text);
			foreach (Match item in source.Cast<Match>())
			{
				string[] array = BytePairEncoding(new string(Array.ConvertAll(Encoding.UTF8.GetBytes(item.Value), (byte x) => byteEncoder[x]))).Split(' ');
				string[] array2 = array;
				for (int num = 0; num < array2.Length; num++)
				{
					yield return array2[num];
				}
			}
		}

		private static int Ord(string x)
		{
			return char.ConvertToUtf32(x, 0);
		}

		private static ConcurrentDictionary<int, char> InitializeBytesToUnicodeCache()
		{
			List<int> list = Enumerable.Range(Ord("!"), Ord("~") + 1 - Ord("!")).Concat(Enumerable.Range(Ord("¡"), Ord("¬") + 1 - Ord("¡"))).Concat(Enumerable.Range(Ord("®"), Ord("ÿ") + 1 - Ord("®")))
				.ToList();
			List<char> list2 = list.Select((int x) => (char)x).ToList();
			int num = 0;
			for (int num2 = 0; num2 < 256; num2++)
			{
				if (!list.Contains(num2))
				{
					list.Add(num2);
					list2.Add((char)(256 + num++));
				}
			}
			return new ConcurrentDictionary<int, char>(list.Zip(list2, (int k, char v) => new { k, v }).ToDictionary(x => x.k, x => x.v));
		}

		private static string BytePairEncoding(string token)
		{
			if (BpeCache.TryGetValue(token, out string value))
			{
				return value;
			}
			List<string> list = token.ToList().Select((char x) =>
			{
				char c = x;
				return c.ToString();
			}).ToList();
			Dictionary<string, List<string>> pairs = GetPairs(list);
			if (pairs.Count == 0)
			{
				BpeCache.TryAdd(token, token);
				return token;
			}
			while (true)
			{
				SortedDictionary<long, Tuple<string, string>> sortedDictionary = new SortedDictionary<long, Tuple<string, string>>();
				foreach (Tuple<string, string> item3 in pairs.SelectMany((KeyValuePair<string, List<string>> pair) => pair.Value.Select((string pairValue) => new Tuple<string, string>(pair.Key, pairValue))))
				{
					if (TokenizerGpt3Settings.BpeRanks.TryGetValue(item3, out var value2))
					{
						sortedDictionary[value2] = item3;
					}
					else
					{
						sortedDictionary[100000000000L] = item3;
					}
				}
				Tuple<string, string> tuple = sortedDictionary[sortedDictionary.Keys.Min()];
				if (!TokenizerGpt3Settings.BpeRanks.ContainsKey(tuple))
				{
					break;
				}
				string item = tuple.Item1;
				string item2 = tuple.Item2;
				List<string> list2 = new List<string>();
				int num = 0;
				while (num < list.Count)
				{
					int num2 = list.IndexOf(item, num);
					if (num2 == -1)
					{
						ArraySegment<string> arraySegment = new ArraySegment<string>(list.Select((string x) => x.ToString()).ToArray(), num, list.Count - num);
						list2.AddRange(arraySegment);
						break;
					}
					ArraySegment<string> arraySegment2 = new ArraySegment<string>(list.Select((string x) => x.ToString()).ToArray(), num, num2 - num);
					list2.AddRange(arraySegment2);
					num = num2;
					if (list[num] == item && num < list.Count - 1 && list[num + 1] == item2)
					{
						list2.Add(item + item2);
						num += 2;
					}
					else
					{
						list2.Add(list[num]);
						num++;
					}
				}
				list = list2;
				if (list.Count == 1)
				{
					break;
				}
				pairs = GetPairs(list);
			}
			string text = string.Join(" ", list);
			BpeCache.TryAdd(token, text);
			return text;
		}

		private static Dictionary<string, List<string>> GetPairs(IReadOnlyList<string> word)
		{
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			string key = word[0];
			for (int i = 1; i < word.Count; i++)
			{
				string text = word[i];
				if (!dictionary.ContainsKey(key))
				{
					dictionary[key] = new List<string>();
				}
				dictionary[key].Add(text);
				key = text;
			}
			return dictionary;
		}
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels
{
	public class MessageContentConverter : JsonConverter<MessageContentOneOfType>
	{
		public override MessageContentOneOfType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.TokenType switch
			{
				JsonTokenType.String => new MessageContentOneOfType
				{
					AsString = reader.GetString()
				}, 
				JsonTokenType.StartArray => new MessageContentOneOfType
				{
					AsList = JsonSerializer.Deserialize<List<MessageContent>>(ref reader, options)
				}, 
				_ => throw new JsonException(), 
			};
		}

		public override void Write(Utf8JsonWriter writer, MessageContentOneOfType? value, JsonSerializerOptions options)
		{
			if (value != null && value.AsString != null)
			{
				writer.WriteStringValue(value.AsString);
			}
			else if (value?.AsList != null)
			{
				JsonSerializer.Serialize(writer, value.AsList, options);
			}
			else
			{
				writer.WriteNullValue();
			}
		}
	}
	public class ResponseFormatOptionConverter : JsonConverter<ResponseFormatOneOfType>
	{
		public override ResponseFormatOneOfType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.TokenType switch
			{
				JsonTokenType.String => new ResponseFormatOneOfType
				{
					AsString = reader.GetString()
				}, 
				JsonTokenType.StartObject => new ResponseFormatOneOfType
				{
					AsObject = JsonSerializer.Deserialize<ResponseFormat>(ref reader, options)
				}, 
				_ => throw new JsonException(), 
			};
		}

		public override void Write(Utf8JsonWriter writer, ResponseFormatOneOfType? value, JsonSerializerOptions options)
		{
			if (value != null && value.AsString != null)
			{
				writer.WriteStringValue(value.AsString);
			}
			else if (value?.AsObject != null)
			{
				JsonSerializer.Serialize(writer, value.AsObject, options);
			}
			else
			{
				writer.WriteNullValue();
			}
		}
	}
	public class AssistantsApiToolChoiceConverter : JsonConverter<AssistantsApiToolChoiceOneOfType>
	{
		public override AssistantsApiToolChoiceOneOfType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.TokenType switch
			{
				JsonTokenType.String => new AssistantsApiToolChoiceOneOfType
				{
					AsString = reader.GetString()
				}, 
				JsonTokenType.StartObject => new AssistantsApiToolChoiceOneOfType
				{
					AsObject = JsonSerializer.Deserialize<ToolChoice>(ref reader, options)
				}, 
				_ => throw new JsonException(), 
			};
		}

		public override void Write(Utf8JsonWriter writer, AssistantsApiToolChoiceOneOfType? value, JsonSerializerOptions options)
		{
			if (value != null && value.AsString != null)
			{
				writer.WriteStringValue(value.AsString);
			}
			else if (value?.AsObject != null)
			{
				JsonSerializer.Serialize(writer, value.AsObject, options);
			}
			else
			{
				writer.WriteNullValue();
			}
		}
	}
	public class SingleOrArrayToListConverter : JsonConverter<IList<string?>>
	{
		public override IList<string?>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			switch (reader.TokenType)
			{
			case JsonTokenType.String:
			{
				int num = 1;
				List<string> list2 = new List<string>(num);
				CollectionsMarshal.SetCount(list2, num);
				Span<string> span = CollectionsMarshal.AsSpan(list2);
				int index = 0;
				span[index] = reader.GetString();
				return list2;
			}
			case JsonTokenType.StartArray:
			{
				List<string> list = new List<string>();
				while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
				{
					switch (reader.TokenType)
					{
					case JsonTokenType.String:
						list.Add(reader.GetString());
						break;
					case JsonTokenType.Null:
						list.Add(null);
						break;
					default:
						throw new JsonException($"Unexpected token in type array: {reader.TokenType}");
					}
				}
				return list;
			}
			default:
				throw new JsonException($"Unexpected token parsing type: {reader.TokenType}");
			}
		}

		public override void Write(Utf8JsonWriter writer, IList<string?>? value, JsonSerializerOptions options)
		{
			if (value == null || value.Count == 0)
			{
				writer.WriteNullValue();
				return;
			}
			if (value.Count == 1)
			{
				writer.WriteStringValue(value[0]);
				return;
			}
			writer.WriteStartArray();
			foreach (string item in value)
			{
				if (item == null)
				{
					writer.WriteNullValue();
				}
				else
				{
					writer.WriteStringValue(item);
				}
			}
			writer.WriteEndArray();
		}
	}
	[JsonConverter(typeof(MessageContentConverter))]
	public class MessageContentOneOfType
	{
		[JsonIgnore]
		public string? AsString { get; set; }

		[JsonIgnore]
		public List<MessageContent>? AsList { get; set; }

		public MessageContentOneOfType(string? contentAsString = null)
		{
			AsString = contentAsString;
		}

		public MessageContentOneOfType(List<MessageContent>? contentAsList = null)
		{
			AsList = contentAsList;
		}

		public MessageContentOneOfType()
		{
		}
	}
	public static class Models
	{
		public enum BaseModel
		{
			Ada,
			Babbage,
			Curie,
			Davinci,
			Cushman,
			None
		}

		public enum Model
		{
			Ada,
			Babbage,
			Curie,
			Davinci,
			TextAdaV1,
			TextBabbageV1,
			TextCurieV1,
			TextDavinciV1,
			TextDavinciV2,
			TextDavinciV3,
			CurieInstructBeta,
			DavinciInstructBeta,
			CurieSimilarityFast,
			TextSimilarityAdaV1,
			TextSimilarityBabbageV1,
			TextSimilarityCurieV1,
			TextSimilarityDavinciV1,
			TextSearchAdaDocV1,
			TextSearchBabbageDocV1,
			TextSearchCurieDocV1,
			TextSearchDavinciDocV1,
			TextSearchAdaQueryV1,
			TextSearchBabbageQueryV1,
			TextSearchCurieQueryV1,
			TextSearchDavinciQueryV1,
			TextEditDavinciV1,
			CodeEditDavinciV1,
			TextEmbeddingAdaV2,
			TextEmbeddingV3Small,
			TextEmbeddingV3Large,
			CodeSearchAdaCodeV1,
			CodeSearchBabbageCodeV1,
			CodeSearchAdaTextV1,
			CodeSearchBabbageTextV1,
			CodeDavinciV1,
			CodeCushmanV1,
			CodeDavinciV2,
			[Obsolete("Use Gpt_3_5_Turbo instead")]
			ChatGpt3_5Turbo,
			Gpt_3_5_Turbo,
			[Obsolete("Use Gpt_3_5_Turbo_0301 instead")]
			ChatGpt3_5Turbo0301,
			Gpt_3_5_Turbo_0301,
			Gpt_3_5_Turbo_16k,
			Gpt_3_5_Turbo_16k_0613,
			Gpt_3_5_Turbo_0613,
			Gpt_3_5_Turbo_1106,
			Gpt_3_5_Turbo_0125,
			Gpt_3_5_Turbo_Instruct,
			Gpt_4,
			Gpt_4_0314,
			Gpt_4_0613,
			Gpt_4_32k,
			Gpt_4_32k_0314,
			Gpt_4_32k_0613,
			Gpt_4_1106_preview,
			Gpt_4_0125_preview,
			Gpt_4_vision_preview,
			Gpt_4_turbo_preview,
			Gpt_4_turbo,
			Gpt_4_turbo_2024_04_09,
			Gpt_4_1,
			Gpt_4_1_2025_04_14,
			Gpt_4_1_mini,
			Gpt_4_1_mini_2025_04_14,
			Gpt_4_1_nano,
			Gpt_4_1_nano_2025_04_14,
			Gpt_4o,
			Gpt_4o_2024_05_13,
			Gpt_4o_2024_08_06,
			Gpt_4o_mini,
			Gpt_4o_mini_2024_07_18,
			Chatgpt_4o_latest,
			WhisperV1,
			Dall_e_2,
			Dall_e_3,
			Tts_1,
			Tts_1_hd,
			Text_moderation_007,
			Text_moderation_latest,
			Text_moderation_stable,
			O1,
			O1_2024_12_17,
			O1_preview,
			O1_preview_2024_09_12,
			O1_mini,
			O1_mini_2024_09_12,
			O1_pro_2025_03_19,
			O3_2025_04_16,
			O3_mini,
			O3_mini_2025_01_31,
			O4_mini_2025_04_16,
			Gpt_4o_realtime_preview_2024_10_01
		}

		public enum Subject
		{
			Text,
			InstructBeta,
			SimilarityFast,
			TextSimilarity,
			TextSearchDocument,
			TextSearchQuery,
			CodeSearchCode,
			CodeSearchText,
			Code,
			CodeEdit,
			Edit,
			TextEmbedding,
			TextModeration
		}

		public static string Gpt_4 => "gpt-4";

		public static string Gpt_4_32k => "gpt-4-32k";

		public static string Gpt_4_0314 => "gpt-4-0314";

		public static string Gpt_4_32k_0314 => "gpt-4-32k-0314";

		public static string Gpt_4_0613 => "gpt-4-0613";

		public static string Gpt_4_32k_0613 => "gpt-4-32k-0613";

		public static string Gpt_4_1106_preview => "gpt-4-1106-preview";

		public static string Gpt_4_0125_preview => "gpt-4-0125-preview";

		public static string Gpt_4_vision_preview => "gpt-4-vision-preview";

		public static string Gpt_4_turbo_preview => "gpt-4-turbo-preview";

		public static string Gpt_4_turbo => "gpt-4-turbo";

		public static string Gpt_4_turbo_2024_04_09 => "gpt-4-turbo-2024-04-09";

		public static string Gpt_4_1 => "gpt-4.1";

		public static string Gpt_4_1_2025_04_14 => "gpt-4.1-2025-04-14";

		public static string Gpt_4_1_mini => "gpt-4.1-mini";

		public static string Gpt_4_1_mini_2025_04_14 => "gpt-4.1-mini-2025-04-14";

		public static string Gpt_4_1_nano => "gpt-4.1-nano";

		public static string Gpt_4_1_nano_2025_04_14 => "gpt-4.1-nano-2025-04-14";

		public static string Gpt_4o => "gpt-4o";

		public static string Gpt_4o_2024_05_13 => "gpt-4o-2024-05-13";

		public static string Gpt_4o_2024_08_06 => "gpt-4o-2024-08-06";

		public static string Gpt_4o_mini => "gpt-4o-mini";

		public static string Gpt_4o_mini_2024_07_18 => "gpt-4o-mini-2024-07-18";

		public static string Chatgpt_4o_latest => "chatgpt-4o-latest";

		public static string Gpt_4o_realtime_preview_2024_10_01 => "gpt-4o-realtime-preview-2024-10-01";

		public static string Ada => "ada";

		public static string Babbage => "babbage";

		public static string Curie => "curie";

		public static string Davinci => "davinci";

		public static string CurieInstructBeta => BaseModel.Curie.ModelNameBuilder(Subject.InstructBeta);

		public static string DavinciInstructBeta => BaseModel.Davinci.ModelNameBuilder(Subject.InstructBeta);

		public static string TextDavinciV1 => BaseModel.Davinci.ModelNameBuilder(Subject.Text, "001");

		public static string TextDavinciV2 => BaseModel.Davinci.ModelNameBuilder(Subject.Text, "002");

		public static string TextDavinciV3 => BaseModel.Davinci.ModelNameBuilder(Subject.Text, "003");

		public static string TextAdaV1 => BaseModel.Ada.ModelNameBuilder(Subject.Text, "001");

		public static string TextBabbageV1 => BaseModel.Babbage.ModelNameBuilder(Subject.Text, "001");

		public static string TextCurieV1 => BaseModel.Curie.ModelNameBuilder(Subject.Text, "001");

		public static string CurieSimilarityFast => BaseModel.Curie.ModelNameBuilder(Subject.SimilarityFast);

		public static string CodeDavinciV1 => BaseModel.Davinci.ModelNameBuilder(Subject.Code, "001");

		public static string CodeCushmanV1 => BaseModel.Cushman.ModelNameBuilder(Subject.Code, "001");

		public static string CodeDavinciV2 => BaseModel.Davinci.ModelNameBuilder(Subject.Code, "002");

		public static string TextSimilarityAdaV1 => BaseModel.Ada.ModelNameBuilder(Subject.TextSimilarity, "001");

		public static string TextSimilarityBabbageV1 => BaseModel.Babbage.ModelNameBuilder(Subject.TextSimilarity, "001");

		public static string TextSimilarityCurieV1 => BaseModel.Curie.ModelNameBuilder(Subject.TextSimilarity, "001");

		public static string TextSimilarityDavinciV1 => BaseModel.Davinci.ModelNameBuilder(Subject.TextSimilarity, "001");

		public static string TextSearchAdaDocV1 => BaseModel.Ada.ModelNameBuilder(Subject.TextSearchDocument, "001");

		public static string TextSearchBabbageDocV1 => BaseModel.Babbage.ModelNameBuilder(Subject.TextSearchDocument, "001");

		public static string TextSearchCurieDocV1 => BaseModel.Curie.ModelNameBuilder(Subject.TextSearchDocument, "001");

		public static string TextSearchDavinciDocV1 => BaseModel.Davinci.ModelNameBuilder(Subject.TextSearchDocument, "001");

		public static string TextSearchAdaQueryV1 => BaseModel.Ada.ModelNameBuilder(Subject.TextSearchQuery, "001");

		public static string TextSearchBabbageQueryV1 => BaseModel.Babbage.ModelNameBuilder(Subject.TextSearchQuery, "001");

		public static string TextSearchCurieQueryV1 => BaseModel.Curie.ModelNameBuilder(Subject.TextSearchQuery, "001");

		public static string TextSearchDavinciQueryV1 => BaseModel.Davinci.ModelNameBuilder(Subject.TextSearchQuery, "001");

		public static string TextEditDavinciV1 => BaseModel.Davinci.ModelNameBuilder(Subject.Edit, "001");

		public static string CodeEditDavinciV1 => BaseModel.Davinci.ModelNameBuilder(Subject.CodeEdit, "001");

		public static string CodeSearchAdaCodeV1 => BaseModel.Ada.ModelNameBuilder(Subject.CodeSearchCode, "001");

		public static string CodeSearchBabbageCodeV1 => BaseModel.Babbage.ModelNameBuilder(Subject.CodeSearchCode, "001");

		public static string CodeSearchAdaTextV1 => BaseModel.Ada.ModelNameBuilder(Subject.CodeSearchText, "001");

		public static string CodeSearchBabbageTextV1 => BaseModel.Babbage.ModelNameBuilder(Subject.CodeSearchText, "001");

		public static string TextEmbeddingAdaV2 => BaseModel.Ada.ModelNameBuilder(Subject.TextEmbedding, "002");

		public static string TextEmbeddingV3Small => BaseModel.None.ModelNameBuilder(Subject.TextEmbedding, "3-small");

		public static string TextEmbeddingV3Large => BaseModel.None.ModelNameBuilder(Subject.TextEmbedding, "3-large");

		public static string TextModeration007 => BaseModel.None.ModelNameBuilder(Subject.TextModeration, "007");

		public static string TextModerationLatest => BaseModel.None.ModelNameBuilder(Subject.TextModeration, "latest");

		public static string TextModerationStable => BaseModel.None.ModelNameBuilder(Subject.TextModeration, "stable");

		[Obsolete("Use Gpt_3_5_Turbo instead, this is just a naming change,the field will be removed in next versions")]
		public static string ChatGpt3_5Turbo => "gpt-3.5-turbo";

		public static string Gpt_3_5_Turbo => "gpt-3.5-turbo";

		public static string Gpt_3_5_Turbo_16k => "gpt-3.5-turbo-16k";

		[Obsolete("Use Gpt_3_5_Turbo_0301 instead, this is just a naming change,the field will be removed in next versions")]
		public static string ChatGpt3_5Turbo0301 => "gpt-3.5-turbo-0301";

		public static string Gpt_3_5_Turbo_0301 => "gpt-3.5-turbo-0301";

		public static string Gpt_3_5_Turbo_0613 => "gpt-3.5-turbo-0613";

		public static string Gpt_3_5_Turbo_1106 => "gpt-3.5-turbo-1106";

		public static string Gpt_3_5_Turbo_0125 => "gpt-3.5-turbo-0125";

		public static string Gpt_3_5_Turbo_16k_0613 => "gpt-3.5-turbo-16k-0613";

		public static string Gpt_3_5_Turbo_Instruct => "gpt-3.5-turbo-instruct";

		public static string WhisperV1 => "whisper-1";

		public static string Dall_e_2 => "dall-e-2";

		public static string Dall_e_3 => "dall-e-3";

		public static string Tts_1 => "tts-1";

		public static string Tts_1_hd => "tts-1-hd";

		public static string O1_preview => "o1-preview";

		public static string O1_mini => "o1-mini";

		public static string O1_preview_2024_09_12 => "o1-preview-2024-09-12";

		public static string O1_mini_2024_09_12 => "o1-mini-2024-09-12";

		public static string O1 => "o1";

		public static string O1_2024_12_17 => "o1-2024-12-17";

		public static string O3_mini => "o3-mini";

		public static string O3_mini_2025_01_31 => "o3-mini-2025-01-31";

		public static string O1_pro_2025_03_19 => "o1-pro-2025-03-19";

		public static string O3_2025_04_16 => "o3-2025-04-16";

		public static string O4_mini_2025_04_16 => "o4-mini-2025-04-16";

		public static string ModelNameBuilder(this BaseModel baseModel, Subject? subject = null, string? version = null)
		{
			return ModelNameBuilder((baseModel == BaseModel.None) ? null : baseModel.EnumToString(), subject?.EnumToString(baseModel.EnumToString()), version);
		}

		public static string ModelNameBuilder(string? baseModel, string? subject, string? version)
		{
			string text = subject ?? baseModel ?? "";
			if (!string.IsNullOrEmpty(version))
			{
				text = text + "-" + version;
			}
			return text;
		}

		public static string EnumToString(this Model model)
		{
			return model switch
			{
				Model.Ada => Ada, 
				Model.Babbage => Babbage, 
				Model.Curie => Curie, 
				Model.CurieInstructBeta => CurieInstructBeta, 
				Model.Davinci => Davinci, 
				Model.DavinciInstructBeta => DavinciInstructBeta, 
				Model.TextDavinciV1 => TextDavinciV1, 
				Model.TextDavinciV2 => TextDavinciV2, 
				Model.TextDavinciV3 => TextDavinciV3, 
				Model.TextAdaV1 => TextAdaV1, 
				Model.TextBabbageV1 => TextBabbageV1, 
				Model.TextCurieV1 => TextCurieV1, 
				Model.CurieSimilarityFast => CurieSimilarityFast, 
				Model.CodeDavinciV1 => CodeDavinciV1, 
				Model.CodeCushmanV1 => CodeCushmanV1, 
				Model.CodeDavinciV2 => CodeDavinciV2, 
				Model.TextSimilarityAdaV1 => TextSimilarityAdaV1, 
				Model.TextSimilarityBabbageV1 => TextSimilarityBabbageV1, 
				Model.TextSimilarityCurieV1 => TextSimilarityCurieV1, 
				Model.TextSimilarityDavinciV1 => TextSimilarityDavinciV1, 
				Model.TextSearchAdaDocV1 => TextSearchAdaDocV1, 
				Model.TextSearchBabbageDocV1 => TextSearchBabbageDocV1, 
				Model.TextSearchCurieDocV1 => TextSearchCurieDocV1, 
				Model.TextSearchDavinciDocV1 => TextSearchDavinciDocV1, 
				Model.TextSearchAdaQueryV1 => TextSearchAdaQueryV1, 
				Model.TextSearchBabbageQueryV1 => TextSearchBabbageQueryV1, 
				Model.TextSearchCurieQueryV1 => TextSearchCurieQueryV1, 
				Model.TextSearchDavinciQueryV1 => TextSearchDavinciQueryV1, 
				Model.CodeSearchAdaCodeV1 => CodeSearchAdaCodeV1, 
				Model.CodeSearchBabbageCodeV1 => CodeSearchBabbageCodeV1, 
				Model.CodeSearchAdaTextV1 => CodeSearchAdaTextV1, 
				Model.CodeSearchBabbageTextV1 => CodeSearchBabbageTextV1, 
				Model.TextEditDavinciV1 => TextEditDavinciV1, 
				Model.CodeEditDavinciV1 => CodeEditDavinciV1, 
				Model.ChatGpt3_5Turbo => ChatGpt3_5Turbo, 
				Model.Gpt_3_5_Turbo => Gpt_3_5_Turbo, 
				Model.ChatGpt3_5Turbo0301 => ChatGpt3_5Turbo0301, 
				Model.Gpt_3_5_Turbo_0301 => Gpt_3_5_Turbo_0301, 
				Model.Gpt_3_5_Turbo_0613 => Gpt_3_5_Turbo_0613, 
				Model.Gpt_3_5_Turbo_1106 => Gpt_3_5_Turbo_1106, 
				Model.Gpt_3_5_Turbo_0125 => Gpt_3_5_Turbo_0125, 
				Model.Gpt_3_5_Turbo_16k_0613 => Gpt_3_5_Turbo_16k_0613, 
				Model.Gpt_3_5_Turbo_16k => Gpt_3_5_Turbo_16k, 
				Model.Gpt_3_5_Turbo_Instruct => Gpt_3_5_Turbo_Instruct, 
				Model.WhisperV1 => WhisperV1, 
				Model.TextEmbeddingAdaV2 => TextEmbeddingAdaV2, 
				Model.TextEmbeddingV3Small => TextEmbeddingV3Small, 
				Model.TextEmbeddingV3Large => TextEmbeddingV3Large, 
				Model.Gpt_4 => Gpt_4, 
				Model.Gpt_4_0314 => Gpt_4_0314, 
				Model.Gpt_4_32k => Gpt_4_32k, 
				Model.Gpt_4_32k_0314 => Gpt_4_32k_0314, 
				Model.Gpt_4_0613 => Gpt_4_0613, 
				Model.Gpt_4_32k_0613 => Gpt_4_32k_0613, 
				Model.Dall_e_2 => Dall_e_2, 
				Model.Dall_e_3 => Dall_e_3, 
				Model.Gpt_4_1106_preview => Gpt_4_1106_preview, 
				Model.Gpt_4_0125_preview => Gpt_4_0125_preview, 
				Model.Gpt_4_vision_preview => Gpt_4_vision_preview, 
				Model.Gpt_4_turbo_preview => Gpt_4_turbo_preview, 
				Model.Gpt_4_turbo => Gpt_4_turbo, 
				Model.Gpt_4_turbo_2024_04_09 => Gpt_4_turbo_2024_04_09, 
				Model.Gpt_4_1 => Gpt_4_1, 
				Model.Gpt_4_1_2025_04_14 => Gpt_4_1_2025_04_14, 
				Model.Gpt_4_1_mini => Gpt_4_1_mini, 
				Model.Gpt_4_1_mini_2025_04_14 => Gpt_4_1_mini_2025_04_14, 
				Model.Gpt_4_1_nano => Gpt_4_1_nano, 
				Model.Gpt_4_1_nano_2025_04_14 => Gpt_4_1_nano_2025_04_14, 
				Model.Gpt_4o => Gpt_4o, 
				Model.Gpt_4o_2024_05_13 => Gpt_4o_2024_05_13, 
				Model.Gpt_4o_2024_08_06 => Gpt_4o_2024_08_06, 
				Model.Gpt_4o_mini => Gpt_4o_mini, 
				Model.Gpt_4o_mini_2024_07_18 => Gpt_4o_mini_2024_07_18, 
				Model.Chatgpt_4o_latest => Chatgpt_4o_latest, 
				Model.Tts_1 => Tts_1, 
				Model.Tts_1_hd => Tts_1_hd, 
				Model.Text_moderation_007 => TextModeration007, 
				Model.Text_moderation_latest => TextModerationLatest, 
				Model.Text_moderation_stable => TextModerationStable, 
				Model.O1_mini => O1_mini, 
				Model.O1_mini_2024_09_12 => O1_mini_2024_09_12, 
				Model.O1_preview => O1_preview, 
				Model.O1_preview_2024_09_12 => O1_preview_2024_09_12, 
				Model.O1 => O1, 
				Model.O1_2024_12_17 => O1_2024_12_17, 
				Model.O3_mini => O3_mini, 
				Model.O3_mini_2025_01_31 => O3_mini_2025_01_31, 
				Model.Gpt_4o_realtime_preview_2024_10_01 => Gpt_4o_realtime_preview_2024_10_01, 
				Model.O1_pro_2025_03_19 => O1_pro_2025_03_19, 
				Model.O3_2025_04_16 => O3_2025_04_16, 
				Model.O4_mini_2025_04_16 => O4_mini_2025_04_16, 
				_ => throw new ArgumentOutOfRangeException("model", model, null), 
			};
		}

		private static string? EnumToString(this BaseModel baseModel)
		{
			return baseModel switch
			{
				BaseModel.Ada => Ada, 
				BaseModel.Babbage => Babbage, 
				BaseModel.Curie => Curie, 
				BaseModel.Davinci => Davinci, 
				BaseModel.Cushman => "cushman", 
				BaseModel.None => null, 
				_ => throw new ArgumentOutOfRangeException("baseModel", baseModel, null), 
			};
		}

		public static string EnumToString(this Subject subject, string? baseModel)
		{
			if (baseModel == null)
			{
				return subject switch
				{
					Subject.TextEmbedding => "text-embedding", 
					Subject.TextModeration => "text-moderation", 
					_ => throw new ArgumentOutOfRangeException("subject", subject, null), 
				};
			}
			return string.Format(subject switch
			{
				Subject.Text => "text-{0}", 
				Subject.InstructBeta => "{0}-instruct-beta", 
				Subject.SimilarityFast => "{0}-similarity-fast", 
				Subject.TextSimilarity => "text-similarity-{0}", 
				Subject.TextSearchDocument => "text-search-{0}-doc", 
				Subject.TextSearchQuery => "text-search-{0}-query", 
				Subject.CodeSearchCode => "code-search-{0}-code", 
				Subject.CodeSearchText => "code-search-{0}-text", 
				Subject.Code => "code-{0}", 
				Subject.CodeEdit => "code-{0}-edit", 
				Subject.Edit => "text-{0}-edit", 
				Subject.TextEmbedding => "text-embedding-{0}", 
				_ => throw new ArgumentOutOfRangeException("subject", subject, null), 
			}, baseModel);
		}
	}
	public class StaticValues
	{
		public static class CompletionStatics
		{
			public static class ResponseFormat
			{
				public static string JsonSchema => "json_schema";

				public static string Json => "json_object";

				public static string Text => "text";
			}

			public static class ReasoningEffort
			{
				public static string Low => "low";

				public static string Medium => "medium";

				public static string High => "high";
			}

			public static class ToolType
			{
				public static string Function => "function";
			}

			public static class ToolChoiceType
			{
				public static string Function => ToolType.Function;

				public static string Auto => "auto";

				public static string None => "none";

				public static string Required => "required";
			}
		}

		public static class ImageStatics
		{
			public static class Size
			{
				public static string Size256 => "256x256";

				public static string Size512 => "512x512";

				public static string Size1024 => "1024x1024";

				public static string Size1792x1024 => "1792x1024";

				public static string Size1024x1792 => "1024x1792";
			}

			public static class ResponseFormat
			{
				public static string Url => "url";

				public static string Base64 => "b64_json";
			}

			public static class Style
			{
				public static string Vivid => "vivid";

				public static string Natural => "natural";
			}

			public static class Quality
			{
				public static string Standard => "standard";

				public static string Hd => "hd";
			}

			public static class ImageFileTypes
			{
				public static string Jpeg => "JPEG";

				public static string Png => "PNG";

				public static string Webp => "WEBP";

				public static string Gif => "GIF";
			}

			public static class ImageDetailTypes
			{
				public static string High => "high";

				public static string Low => "low";

				public static string Auto => "auto";
			}
		}

		public static class AudioStatics
		{
			public static class ResponseFormat
			{
				public static string Json => "json";

				public static string Text => "text";

				public static string Srt => "srt";

				public static string VerboseJson => "verbose_json";

				public static string Vtt => "vtt";
			}

			public static class TimestampGranularity
			{
				public static string Word => "word";

				public static string Segment => "segment";
			}

			public static class CreateSpeechResponseFormat
			{
				public static string Mp3 => "mp3";

				public static string Opus => "opus";

				public static string Aac => "aac";

				public static string Flac => "flac";
			}

			public static class Voice
			{
				public static string Alloy => "alloy";

				public static string Echo => "echo";

				public static string Fable => "fable";

				public static string Nova => "nova";

				public static string Onyx => "onyx";

				public static string Shimmer => "shimmer";
			}

			public enum VoicesTextToSpeechEnum
			{
				alloy,
				ash,
				ballad,
				coral,
				echo,
				fable,
				nova,
				onyx,
				sage,
				shimmer
			}

			public enum VoicesRealtimeEnum
			{
				alloy,
				ash,
				ballad,
				coral,
				echo,
				sage,
				shimmer,
				verse
			}
		}

		public static class ChatMessageRoles
		{
			public static string System => "system";

			public static string User => "user";

			public static string Assistant => "assistant";

			public static string Tool => "tool";

			public static string Function => "function";
		}

		public static class AssistantsStatics
		{
			public static class ToolCallTypes
			{
				public static string CodeInterpreter => "code_interpreter";

				public static string FileSearch => "file_search";

				public static string Function => "function";
			}

			public static class MessageStatics
			{
				public static class Roles
				{
					public static string User => "user";

					public static string Assistant => "assistant";
				}

				public static class Content
				{
					public static class Annotations
					{
						public static string FileCitation => "file_citation";

						public static string FilePath => "file_path";
					}

					public static string ImageFile => "image_file";

					public static string Text => "text";
				}
			}

			public static class RunStatus
			{
				public static string Queued => "queued";

				public static string InProgress => "in_progress";

				public static string RequiresAction => "requires_action";

				public static string Cancelling => "cancelling";

				public static string Cancelled => "cancelled";

				public static string Failed => "failed";

				public static string Completed => "completed";

				public static string Expired => "expired";

				public static string Incomplete => "incomplete";
			}

			public static class RequiredActionTypes
			{
				public static string SubmitToolOutputs => "submit_tool_outputs";
			}
		}

		public static class VectorStoreStatics
		{
			public static class ChunkingStrategyType
			{
				public static string Auto => "auto";

				public static string Static => "static";
			}
		}
	}
	public static class UploadFilePurposes
	{
		public enum UploadFilePurpose
		{
			FineTune,
			FineTuneResults,
			Assistants,
			AssistantsOutput,
			Vision,
			Batch,
			BatchOutput
		}

		public const string Assistants = "assistants";

		public const string AssistantsOutput = "assistants_output";

		public const string Vision = "vision";

		public const string Batch = "batch";

		public const string BatchOutput = "batch_output";

		public const string FineTune = "fine-tune";

		public const string FineTuneResults = "fine-tune-results";

		public static string EnumToString(this UploadFilePurpose uploadFilePurpose)
		{
			return uploadFilePurpose switch
			{
				UploadFilePurpose.Assistants => "assistants", 
				UploadFilePurpose.Vision => "vision", 
				UploadFilePurpose.Batch => "batch", 
				UploadFilePurpose.FineTune => "fine-tune", 
				UploadFilePurpose.BatchOutput => "batch_output", 
				UploadFilePurpose.AssistantsOutput => "assistants_output", 
				UploadFilePurpose.FineTuneResults => "fine-tune-results", 
				_ => throw new ArgumentOutOfRangeException("uploadFilePurpose", uploadFilePurpose, null), 
			};
		}

		public static UploadFilePurpose ToEnum(string filePurpose)
		{
			return filePurpose switch
			{
				"assistants" => UploadFilePurpose.Assistants, 
				"vision" => UploadFilePurpose.Vision, 
				"batch" => UploadFilePurpose.Batch, 
				"fine-tune" => UploadFilePurpose.FineTune, 
				"batch_output" => UploadFilePurpose.BatchOutput, 
				"assistants_output" => UploadFilePurpose.AssistantsOutput, 
				"fine-tune-results" => UploadFilePurpose.FineTuneResults, 
				_ => throw new ArgumentOutOfRangeException("filePurpose", filePurpose, null), 
			};
		}
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.SharedModels
{
	public record AssistantFileResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("assistant_id")]
		public string AssistantId { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
	public record AssistantResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt, IOpenAIModels.IModel, IOpenAIModels.IMetaData, IOpenAIModels.ITools
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("file_ids")]
		public List<string> FileIds { get; set; }

		[JsonPropertyName("tool_resources")]
		public ToolResources? ToolResources { get; set; }

		[JsonPropertyName("response_format")]
		public ResponseFormatOneOfType ResponseFormatOneOfType { get; set; }

		[JsonPropertyName("temperature")]
		public float? Temperature { get; set; }

		[JsonPropertyName("top_p")]
		public double? TopP { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string> Metadata { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("tools")]
		public List<ToolDefinition> Tools { get; set; }
	}
	public record ChatChoiceResponse
	{
		public class FinishDetailsResponse
		{
			[JsonPropertyName("type")]
			public string Type { get; set; }

			[JsonPropertyName("stop")]
			public string Stop { get; set; }
		}

		public record ChatLogProbsResponse
		{
			[JsonPropertyName("content")]
			public List<ContentItem> Content { get; set; }
		}

		public record ContentItemBase
		{
			[JsonPropertyName("token")]
			public string Token { get; set; }

			[JsonPropertyName("logprob")]
			public double LogProb { get; set; }

			[JsonPropertyName("bytes")]
			public List<int> Bytes { get; set; }
		}

		public record ContentItem : ContentItemBase
		{
			[JsonPropertyName("top_logprobs")]
			public List<ContentItemBase> TopLogProbs { get; set; }
		}

		[JsonPropertyName("delta")]
		public Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage Delta
		{
			get
			{
				return Message;
			}
			set
			{
				Message = value;
			}
		}

		[JsonPropertyName("message")]
		public Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage Message { get; set; }

		[JsonPropertyName("index")]
		public int? Index { get; set; }

		[JsonPropertyName("finish_reason")]
		public string FinishReason { get; set; }

		[JsonPropertyName("finish_details")]
		public FinishDetailsResponse? FinishDetails { get; set; }

		[JsonPropertyName("logprobs")]
		public ChatLogProbsResponse LogProbs { get; set; }
	}
	public record ChoiceResponse : IOpenAIModels.ILogProbsResponse
	{
		[JsonPropertyName("text")]
		public string Text { get; set; }

		[JsonPropertyName("index")]
		public int? Index { get; set; }

		[JsonPropertyName("finish_reason")]
		public string FinishReason { get; set; }

		[JsonPropertyName("logprobs")]
		public LogProbsResponse LogProbs { get; set; }
	}
	public record DeletionStatusResponse : BaseResponse, IOpenAIModels.IId
	{
		[JsonPropertyName("deleted")]
		public bool IsDeleted { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
	public record EventResponse : IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("object")]
		public string? ObjectTypeName { get; set; }

		[JsonPropertyName("id")]
		public string? Id { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("level")]
		public string Level { get; set; }

		[JsonPropertyName("message")]
		public string Message { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }
	}
	public record FileResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("bytes")]
		public int? Bytes { get; set; }

		[JsonPropertyName("filename")]
		public string FileName { get; set; }

		public UploadFilePurposes.UploadFilePurpose PurposeEnum => UploadFilePurposes.ToEnum(Purpose);

		[JsonPropertyName("purpose")]
		public string Purpose { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
	public class PropertyDefinition
	{
		public enum FunctionObjectTypes
		{
			String,
			Integer,
			Number,
			Object,
			Array,
			Boolean,
			Null
		}

		[JsonIgnore]
		public string? Type
		{
			get
			{
				IList<string?>? typeList = TypeList;
				if (typeList != null && typeList.Count == 1)
				{
					return TypeList[0];
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					TypeList = null;
					return;
				}
				int num = 1;
				List<string> list = new List<string>(num);
				CollectionsMarshal.SetCount(list, num);
				Span<string> span = CollectionsMarshal.AsSpan(list);
				int index = 0;
				span[index] = value;
				TypeList = list;
			}
		}

		[JsonPropertyName("type")]
		[JsonConverter(typeof(SingleOrArrayToListConverter))]
		public IList<string?>? TypeList { get; set; }

		[JsonPropertyName("const")]
		public string? Constant { get; set; }

		[JsonPropertyName("properties")]
		public IDictionary<string, PropertyDefinition>? Properties { get; set; }

		[JsonPropertyName("required")]
		public IList<string>? Required { get; set; }

		[JsonPropertyName("additionalProperties")]
		public bool? AdditionalProperties { get; set; }

		[JsonPropertyName("title")]
		public string? Title { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("enum")]
		public IList<string>? Enum { get; set; }

		[JsonPropertyName("minProperties")]
		public int? MinProperties { get; set; }

		[JsonPropertyName("maxProperties")]
		public int? MaxProperties { get; set; }

		[JsonPropertyName("multipleOf")]
		public float? MultipleOf { get; set; }

		[JsonPropertyName("minimum")]
		public float? Minimum { get; set; }

		[JsonPropertyName("exclusiveMinimum")]
		public float? ExclusiveMinimum { get; set; }

		[JsonPropertyName("maximum")]
		public float? Maximum { get; set; }

		[JsonPropertyName("exclusiveMaximum")]
		public float? ExclusiveMaximum { get; set; }

		[JsonPropertyName("format")]
		public string? Format { get; set; }

		[JsonPropertyName("pattern")]
		public string? Pattern { get; set; }

		[JsonPropertyName("minItems")]
		public int? MinItems { get; set; }

		[JsonPropertyName("maxItems")]
		public int? MaxItems { get; set; }

		[JsonPropertyName("items")]
		public PropertyDefinition? Items { get; set; }

		[JsonPropertyName("$defs")]
		public IDictionary<string, PropertyDefinition>? Defs { get; set; }

		[JsonPropertyName("definitions")]
		public IDictionary<string, PropertyDefinition>? Definitions { get; set; }

		[JsonPropertyName("$ref")]
		public string? Ref { get; set; }

		[JsonPropertyName("anyOf")]
		public IList<PropertyDefinition>? AnyOf { get; set; }

		[JsonPropertyName("oneOf")]
		public IList<PropertyDefinition>? OneOf { get; set; }

		public static PropertyDefinition DefineArray(PropertyDefinition? arrayItems = null)
		{
			return new PropertyDefinition
			{
				Items = arrayItems,
				Type = ConvertTypeToString(FunctionObjectTypes.Array)
			};
		}

		public static PropertyDefinition DefineEnum(List<string> enumList, string? description = null)
		{
			return new PropertyDefinition
			{
				Description = description,
				Enum = enumList,
				Type = ConvertTypeToString(FunctionObjectTypes.String)
			};
		}

		public static PropertyDefinition DefineInteger(string? description = null)
		{
			return new PropertyDefinition
			{
				Description = description,
				Type = ConvertTypeToString(FunctionObjectTypes.Integer)
			};
		}

		public static PropertyDefinition DefineNumber(string? description = null)
		{
			return new PropertyDefinition
			{
				Description = description,
				Type = ConvertTypeToString(FunctionObjectTypes.Number)
			};
		}

		public static PropertyDefinition DefineString(string? description = null)
		{
			return new PropertyDefinition
			{
				Description = description,
				Type = ConvertTypeToString(FunctionObjectTypes.String)
			};
		}

		public static PropertyDefinition DefineBoolean(string? description = null)
		{
			return new PropertyDefinition
			{
				Description = description,
				Type = ConvertTypeToString(FunctionObjectTypes.Boolean)
			};
		}

		public static PropertyDefinition DefineNull(string? description = null)
		{
			return new PropertyDefinition
			{
				Description = description,
				Type = ConvertTypeToString(FunctionObjectTypes.Null)
			};
		}

		public static PropertyDefinition DefineObject(IDictionary<string, PropertyDefinition>? properties, IList<string>? required, bool? additionalProperties, string? description, IList<string>? @enum)
		{
			return new PropertyDefinition
			{
				Properties = properties,
				Required = required,
				AdditionalProperties = additionalProperties,
				Description = description,
				Enum = @enum,
				Type = ConvertTypeToString(FunctionObjectTypes.Object)
			};
		}

		public static string ConvertTypeToString(FunctionObjectTypes type)
		{
			return type switch
			{
				FunctionObjectTypes.String => "string", 
				FunctionObjectTypes.Integer => "integer", 
				FunctionObjectTypes.Number => "number", 
				FunctionObjectTypes.Object => "object", 
				FunctionObjectTypes.Array => "array", 
				FunctionObjectTypes.Boolean => "boolean", 
				FunctionObjectTypes.Null => "null", 
				_ => throw new ArgumentOutOfRangeException("type", $"Unknown type: {type}"), 
			};
		}
	}
	public record HyperParametersResponse
	{
		[JsonPropertyName("batch_size")]
		public int? BatchSize { get; set; }

		[JsonPropertyName("learning_rate_multiplier")]
		public float? LearningRateMultiplier { get; set; }

		[JsonPropertyName("n_epochs")]
		[JsonConverter(typeof(NEpochsConverter))]
		public int? NEpochs { get; set; }

		[JsonPropertyName("prompt_loss_weight")]
		public float? PromptLossWeight { get; set; }
	}
	public interface IOpenAIModels
	{
		public interface IId
		{
			string Id { get; set; }
		}

		public interface IModel
		{
			string? Model { get; set; }
		}

		public interface ILogProbsRequest
		{
			int? LogProbs { get; set; }
		}

		public interface ILogProbsResponse
		{
			LogProbsResponse LogProbs { get; set; }
		}

		public interface ITemperature
		{
			float? Temperature { get; set; }
		}

		public interface IAssistantId
		{
			string AssistantId { get; set; }
		}

		public interface ICreatedAt
		{
			long CreatedAtUnix { get; set; }

			DateTimeOffset CreatedAt { get; }
		}

		public interface ICompletedAt
		{
			int CompletedAt { get; set; }
		}

		public interface IUser
		{
			string User { get; set; }
		}

		public interface IFile
		{
			byte[] File { get; set; }

			Stream FileStream { get; set; }

			string FileName { get; set; }
		}

		public interface IMetaData
		{
			Dictionary<string, string> Metadata { get; set; }
		}

		public interface IFileIds
		{
			List<string> FileIds { get; set; }
		}

		public interface ITools
		{
			List<ToolDefinition> Tools { get; set; }
		}
	}
	public record LogProbsResponse
	{
		[JsonPropertyName("tokens")]
		public List<string> Tokens { get; set; }

		[JsonPropertyName("token_logprobs")]
		public List<double> TokenLogProbs { get; set; }

		[JsonPropertyName("top_logprobs")]
		public List<Dictionary<string, double>> TopLogProbsRaw { get; set; }

		public List<TopLogProbResponse> TopLogProbs => TopLogProbsRaw.SelectMany((Dictionary<string, double> r) => r.Select((KeyValuePair<string, double> a) => new TopLogProbResponse
		{
			Key = a.Key,
			LogProp = a.Value
		})).ToList();

		[JsonPropertyName("text_offset")]
		public List<int> TextOffset { get; set; }
	}
	public class TopLogProbResponse
	{
		public string Key { get; set; }

		public double LogProp { get; set; }
	}
	public record MessageAnnotation
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("text")]
		public string Text { get; set; }

		[JsonPropertyName("start_index")]
		public int StartIndex { get; set; }

		[JsonPropertyName("end_index")]
		public int EndIndex { get; set; }

		[JsonPropertyName("file_citation")]
		public FileCitation FileCitation { get; set; }
	}
	public record FileCitation
	{
		[JsonPropertyName("file_id")]
		public string FileId { get; set; }

		[JsonPropertyName("quote")]
		public string Quote { get; set; }
	}
	public record MessageResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt, IOpenAIModels.IMetaData, IOpenAIModels.IAssistantId
	{
		public record MessageContentResponse
		{
			[JsonPropertyName("type")]
			public string Type { get; set; }

			[JsonPropertyName("image_file")]
			public MessageImageFile? ImageFile { get; set; }

			[JsonPropertyName("text")]
			public MessageText? Text { get; set; }

			[JsonPropertyName("image_url")]
			public MessageImageUrl? ImageUrl { get; set; }
		}

		[JsonPropertyName("delta")]
		public MessageResponse Delta
		{
			set
			{
				Content = value.Content;
			}
		}

		[JsonPropertyName("thread_id")]
		public string ThreadId { get; set; }

		[JsonPropertyName("role")]
		public string Role { get; set; }

		[JsonPropertyName("content")]
		public List<MessageContentResponse>? Content { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("incomplete_details")]
		public IncompleteDetails? IncompleteDetails { get; set; }

		[JsonPropertyName("completed_at")]
		public int? CompletedAt { get; set; }

		[JsonPropertyName("incomplete_at")]
		public int? IncompleteAt { get; set; }

		[JsonPropertyName("run_id")]
		public string? RunId { get; set; }

		[JsonPropertyName("attachments")]
		public List<Attachment> Attachments { get; set; }

		[JsonPropertyName("assistant_id")]
		public string? AssistantId { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[CompilerGenerated]
		protected override bool PrintMembers(StringBuilder builder)
		{
			if (base.PrintMembers(builder))
			{
				builder.Append(", ");
			}
			builder.Append("ThreadId = ");
			builder.Append((object?)ThreadId);
			builder.Append(", Role = ");
			builder.Append((object?)Role);
			builder.Append(", Content = ");
			builder.Append(Content);
			builder.Append(", Status = ");
			builder.Append((object?)Status);
			builder.Append(", IncompleteDetails = ");
			builder.Append(IncompleteDetails);
			builder.Append(", CompletedAt = ");
			builder.Append(CompletedAt.ToString());
			builder.Append(", IncompleteAt = ");
			builder.Append(IncompleteAt.ToString());
			builder.Append(", RunId = ");
			builder.Append((object?)RunId);
			builder.Append(", Attachments = ");
			builder.Append(Attachments);
			builder.Append(", AssistantId = ");
			builder.Append((object?)AssistantId);
			builder.Append(", CreatedAtUnix = ");
			builder.Append(CreatedAtUnix.ToString());
			builder.Append(", CreatedAt = ");
			builder.Append(CreatedAt.ToString());
			builder.Append(", Id = ");
			builder.Append((object?)Id);
			builder.Append(", Metadata = ");
			builder.Append(Metadata);
			return true;
		}
	}
	public record MessageText
	{
		[JsonPropertyName("value")]
		public string Value { get; set; }

		[JsonPropertyName("annotations")]
		public List<MessageAnnotation> Annotations { get; set; }
	}
	public class RequiredAction
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("submit_tool_outputs")]
		public SubmitToolOutputs SubmitToolOutputs { get; set; }
	}
	public class SubmitToolOutputs
	{
		[JsonPropertyName("tool_calls")]
		public List<ToolCall> ToolCalls { get; set; }
	}
	public record RunListResponse : DataWithPagingBaseResponse<List<RunResponse>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected RunListResponse(RunListResponse original)
			: base((DataWithPagingBaseResponse<List<RunResponse>>)original)
		{
		}
	}
	public record RunResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.IModel, IOpenAIModels.ICreatedAt, IOpenAIModels.IFileIds, IOpenAIModels.IMetaData
	{
		[JsonPropertyName("thread_id")]
		public string ThreadId { get; set; }

		[JsonPropertyName("assistant_id")]
		public string AssistantId { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("required_action")]
		public RequiredAction? RequiredAction { get; set; }

		[JsonPropertyName("last_error")]
		public Error? LastError { get; set; }

		[JsonPropertyName("incomplete_details")]
		public IncompleteDetails? IncompleteDetails { get; set; }

		[JsonPropertyName("expires_at")]
		public int? ExpiresAt { get; set; }

		[JsonPropertyName("started_at")]
		public int? StartedAt { get; set; }

		[JsonPropertyName("cancelled_at")]
		public int? CancelledAt { get; set; }

		[JsonPropertyName("failed_at")]
		public int? FailedAt { get; set; }

		[JsonPropertyName("completed_at")]
		public int? CompletedAt { get; set; }

		[JsonPropertyName("instructions")]
		public string Instructions { get; set; }

		[JsonPropertyName("tools")]
		public List<ToolDefinition>? Tools { get; set; }

		[JsonPropertyName("usage")]
		public UsageResponse? Usage { get; set; }

		[JsonPropertyName("temperature")]
		public double? Temperature { get; set; }

		[JsonPropertyName("max_prompt_tokens")]
		public int? MaxPromptTokens { get; set; }

		[JsonPropertyName("max_completion_tokens")]
		public int? MaxCompletionTokens { get; set; }

		[JsonPropertyName("truncation_strategy")]
		public TruncationStrategy? TruncationStrategy { get; set; }

		[JsonPropertyName("tool_choice")]
		public object? ToolChoice { get; set; }

		[JsonPropertyName("response_format")]
		public object? ResponseFormat { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("file_ids")]
		public List<string>? FileIds { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
	public class IncompleteDetails
	{
		[JsonPropertyName("reason")]
		public string Reason { get; set; }
	}
	public record SharedImageRequestBaseModel
	{
		[JsonPropertyName("n")]
		public int? N { get; set; }

		[JsonPropertyName("size")]
		public string? Size { get; set; }

		[JsonPropertyName("response_format")]
		public string? ResponseFormat { get; set; }

		[JsonPropertyName("user")]
		public string? User { get; set; }

		[JsonPropertyName("model")]
		public string? Model { get; set; }
	}
	public record ThreadResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt, IOpenAIModels.IMetaData
	{
		[JsonPropertyName("tool_resources")]
		public ToolResources? ToolResources { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public class TruncationStrategy
	{
		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("last_messages")]
		public int? LastMessages { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels
{
	public record AssistantFileListResponse : DataWithPagingBaseResponse<List<AssistantFileResponse>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected AssistantFileListResponse(AssistantFileListResponse original)
			: base((DataWithPagingBaseResponse<List<AssistantFileResponse>>)original)
		{
		}
	}
	public record AssistantListResponse : DataWithPagingBaseResponse<List<AssistantResponse>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected AssistantListResponse(AssistantListResponse original)
			: base((DataWithPagingBaseResponse<List<AssistantResponse>>)original)
		{
		}
	}
	public record AudioCreateSpeechResponse<T> : DataBaseResponse<T>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected AudioCreateSpeechResponse(AudioCreateSpeechResponse<T> original)
			: base((DataBaseResponse<T>)original)
		{
		}
	}
	public record AudioCreateTranscriptionResponse : BaseResponse
	{
		public class WordSegment
		{
			[JsonPropertyName("word")]
			public string Word { get; set; }

			[JsonPropertyName("start")]
			public float Start { get; set; }

			[JsonPropertyName("end")]
			public float End { get; set; }
		}

		public class Segment
		{
			[JsonPropertyName("id")]
			public int Id { get; set; }

			[JsonPropertyName("seek")]
			public int Seek { get; set; }

			[JsonPropertyName("start")]
			public float Start { get; set; }

			[JsonPropertyName("end")]
			public float End { get; set; }

			[JsonPropertyName("text")]
			public string Text { get; set; }

			[JsonPropertyName("tokens")]
			public List<int> Tokens { get; set; }

			[JsonPropertyName("temperature")]
			public float Temperature { get; set; }

			[JsonPropertyName("avg_logprob")]
			public float Avglogprob { get; set; }

			[JsonPropertyName("compression_ratio")]
			public float CompressionRatio { get; set; }

			[JsonPropertyName("no_speech_prob")]
			public float Nospeechprob { get; set; }

			[JsonPropertyName("transient")]
			public bool Transient { get; set; }
		}

		[JsonPropertyName("text")]
		public string Text { get; set; }

		[JsonPropertyName("task")]
		public string Task { get; set; }

		[JsonPropertyName("language")]
		public string Language { get; set; }

		[JsonPropertyName("duration")]
		public float Duration { get; set; }

		[JsonPropertyName("words")]
		public List<WordSegment> Words { get; set; }

		[JsonPropertyName("segments")]
		public List<Segment> Segments { get; set; }
	}
	public record ObjectBaseResponse
	{
		[JsonPropertyName("object")]
		public string? ObjectTypeName { get; set; }
	}
	public record BaseResponse : ObjectBaseResponse
	{
		[JsonPropertyName("StreamEvent")]
		public string? StreamEvent { get; set; }

		public bool IsDelta => StreamEvent?.EndsWith("delta") ?? false;

		public bool Successful => Error == null;

		[JsonPropertyName("error")]
		public Error? Error { get; set; }

		public HttpStatusCode HttpStatusCode { get; set; }

		public ResponseHeaderValues? HeaderValues { get; set; }
	}
	public record RateLimitInfo
	{
		public string? LimitRequests { get; set; }

		public string? LimitTokens { get; set; }

		public string? LimitTokensUsageBased { get; set; }

		public string? RemainingRequests { get; set; }

		public string? RemainingTokens { get; set; }

		public string? RemainingTokensUsageBased { get; set; }

		public string? ResetRequests { get; set; }

		public string? ResetTokens { get; set; }

		public string? ResetTokensUsageBased { get; set; }
	}
	public record OpenAIInfo
	{
		public string? Model { get; set; }

		public string? Organization { get; set; }

		public string? ProcessingMs { get; set; }

		public string? Version { get; set; }
	}
	public record ResponseHeaderValues
	{
		public DateTimeOffset? Date { get; set; }

		public string? Connection { get; set; }

		public string? AccessControlAllowOrigin { get; set; }

		public string? CacheControl { get; set; }

		public string? Vary { get; set; }

		public string? XRequestId { get; set; }

		public string? StrictTransportSecurity { get; set; }

		public string? CFCacheStatus { get; set; }

		public List<string>? SetCookie { get; set; }

		public string? Server { get; set; }

		public string? CF_RAY { get; set; }

		public string? AltSvc { get; set; }

		public Dictionary<string, IEnumerable<string>>? All { get; set; }

		public RateLimitInfo? RateLimits { get; set; }

		public OpenAIInfo? OpenAI { get; set; }
	}
	public record DataWithPagingBaseResponse<T> : BaseResponse where T : IList
	{
		[JsonPropertyName("data")]
		public T? Data { get; set; }

		[JsonPropertyName("first_id")]
		public string FirstId { get; set; }

		[JsonPropertyName("last_id")]
		public string LastId { get; set; }

		[JsonPropertyName("has_more")]
		public bool HasMore { get; set; }
	}
	public record DataBaseResponse<T> : BaseResponse
	{
		[JsonPropertyName("data")]
		public T? Data { get; set; }
	}
	public record ErrorList : DataBaseResponse<List<Error>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected ErrorList(ErrorList original)
			: base((DataBaseResponse<List<Error>>)original)
		{
		}
	}
	public class Error
	{
		public class MessageConverter : JsonConverter<object>
		{
			public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				if (reader.TokenType == JsonTokenType.String)
				{
					return reader.GetString();
				}
				if (reader.TokenType == JsonTokenType.StartArray)
				{
					return JsonSerializer.Deserialize<List<object>>(ref reader, options);
				}
				throw new JsonException();
			}

			public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
			{
				JsonSerializer.Serialize(writer, value, options);
			}
		}

		[JsonPropertyName("code")]
		public string? Code { get; set; }

		[JsonPropertyName("param")]
		public string? Param { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("line")]
		public int? Line { get; set; }

		[JsonIgnore]
		public string? Message { get; private set; }

		[JsonIgnore]
		public List<string?> Messages { get; private set; }

		[JsonPropertyName("message")]
		[JsonConverter(typeof(MessageConverter))]
		public object MessageObject
		{
			set
			{
				if (!(value is string text))
				{
					if (value is List<object> source && source.All((object i) => i is JsonElement))
					{
						Messages = (from JsonElement e in source
							select e.GetString()).ToList();
						Message = string.Join(Environment.NewLine, Messages);
					}
				}
				else
				{
					Message = text;
					Messages = new List<string> { text };
				}
			}
		}

		[JsonPropertyName("event_id")]
		public string? EventId { get; set; }
	}
	public record ChatCompletionCreateResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("choices")]
		public List<ChatChoiceResponse> Choices { get; set; }

		[JsonPropertyName("usage")]
		public UsageResponse Usage { get; set; }

		[JsonPropertyName("system_fingerprint")]
		public string SystemFingerPrint { get; set; }

		[JsonPropertyName("service_tier")]
		public string? ServiceTier { get; set; }

		[JsonPropertyName("created")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
	public record CompletionCreateResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("choices")]
		public List<ChoiceResponse> Choices { get; set; }

		[JsonPropertyName("usage")]
		public UsageResponse Usage { get; set; }

		[JsonPropertyName("created")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
	public record CompletionTokensDetails
	{
		[JsonPropertyName("reasoning_tokens")]
		public int ReasoningTokens { get; set; }

		[JsonPropertyName("audio_tokens")]
		public int AudioTokens { get; set; }
	}
	public record CreateModerationResponse : BaseResponse, IOpenAIModels.IModel, IOpenAIModels.IId
	{
		[JsonPropertyName("results")]
		public List<Result> Results { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
	public record Result
	{
		[JsonPropertyName("categories")]
		public Categories Categories { get; set; }

		[JsonPropertyName("category_scores")]
		public CategoryScores CategoryScores { get; set; }

		[JsonPropertyName("flagged")]
		public bool Flagged { get; set; }
	}
	public record Categories
	{
		[JsonPropertyName("hate")]
		public bool Hate { get; set; }

		[JsonPropertyName("hate/threatening")]
		public bool HateThreatening { get; set; }

		[JsonPropertyName("harassment")]
		public bool Harassment { get; set; }

		[JsonPropertyName("harassment/threatening")]
		public bool HarassmentThreatening { get; set; }

		[JsonPropertyName("self-harm")]
		public bool SelfHarm { get; set; }

		[JsonPropertyName("self-harm/intent")]
		public bool SelfHarmIntent { get; set; }

		[JsonPropertyName("self-harm/instructions")]
		public bool SelfHarmInstructions { get; set; }

		[JsonPropertyName("sexual")]
		public bool Sexual { get; set; }

		[JsonPropertyName("sexual/minors")]
		public bool SexualMinors { get; set; }

		[JsonPropertyName("violence")]
		public bool Violence { get; set; }

		[JsonPropertyName("violence/graphic")]
		public bool ViolenceGraphic { get; set; }
	}
	public record CategoryScores
	{
		[JsonPropertyName("hate")]
		public float Hate { get; set; }

		[JsonPropertyName("hate/threatening")]
		public float HateThreatening { get; set; }

		[JsonPropertyName("harassment")]
		public float Harassment { get; set; }

		[JsonPropertyName("harassment/threatening")]
		public float HarassmentThreatening { get; set; }

		[JsonPropertyName("self-harm")]
		public float SelfHarm { get; set; }

		[JsonPropertyName("self-harm/intent")]
		public float SelfHarmIntent { get; set; }

		[JsonPropertyName("self-harm/instructions")]
		public float SelfHarmInstructions { get; set; }

		[JsonPropertyName("sexual")]
		public float Sexual { get; set; }

		[JsonPropertyName("sexual/minors")]
		public float SexualMinors { get; set; }

		[JsonPropertyName("violence")]
		public float Violence { get; set; }

		[JsonPropertyName("violence/graphic")]
		public float ViolenceGraphic { get; set; }
	}
	public record EditCreateResponse : BaseResponse, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("choices")]
		public List<ChoiceResponse> Choices { get; set; }

		[JsonPropertyName("usage")]
		public UsageResponse Usage { get; set; }

		[JsonPropertyName("created")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);
	}
	public record EmbeddingCreateResponse : BaseResponse
	{
		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("data")]
		public List<EmbeddingResponse> Data { get; set; }

		[JsonPropertyName("usage")]
		public UsageResponse Usage { get; set; }
	}
	public record EmbeddingResponse
	{
		[JsonPropertyName("index")]
		public int? Index { get; set; }

		[JsonPropertyName("embedding")]
		public List<double> Embedding { get; set; }
	}
	public record MessageListResponse : DataWithPagingBaseResponse<List<MessageResponse>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected MessageListResponse(MessageListResponse original)
			: base((DataWithPagingBaseResponse<List<MessageResponse>>)original)
		{
		}
	}
	public class PromptTokensDetails
	{
		[JsonPropertyName("cached_tokens")]
		public int? CachedTokens { get; set; }

		[JsonPropertyName("audio_tokens")]
		public int? AudioTokens { get; set; }
	}
	public record RunStepListResponse : DataWithPagingBaseResponse<List<RunStepResponse>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected RunStepListResponse(RunStepListResponse original)
			: base((DataWithPagingBaseResponse<List<RunStepResponse>>)original)
		{
		}
	}
	public record RunStepResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("assistant_id")]
		public string AssistantId { get; set; }

		[JsonPropertyName("thread_id")]
		public string ThreadId { get; set; }

		[JsonPropertyName("run_id")]
		public string RunId { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("step_details")]
		public RunStepDetails? StepDetails { get; set; }

		[JsonPropertyName("last_error")]
		public Error? LastError { get; set; }

		[JsonPropertyName("expired_at")]
		public int? ExpiredAt { get; set; }

		[JsonPropertyName("cancelled_at")]
		public int? CancelledAt { get; set; }

		[JsonPropertyName("failed_at")]
		public int? FailedAt { get; set; }

		[JsonPropertyName("completed_at")]
		public int? CompletedAt { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("usage")]
		public UsageResponse? Usage { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
	public record RunStepDetails
	{
		public class RunStepMessageCreation
		{
			[JsonPropertyName("message_id")]
			public string MessageId { get; set; }
		}

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("message_creation")]
		public RunStepMessageCreation MessageCreation { get; set; }
	}
	public record UsageResponse
	{
		[JsonPropertyName("prompt_tokens")]
		public int PromptTokens { get; set; }

		[JsonPropertyName("completion_tokens")]
		public int? CompletionTokens { get; set; }

		[JsonPropertyName("total_tokens")]
		public int TotalTokens { get; set; }

		[JsonPropertyName("completion_tokens_details")]
		public CompletionTokensDetails? CompletionTokensDetails { get; set; }

		[JsonPropertyName("prompt_tokens_details")]
		public PromptTokensDetails? PromptTokensDetails { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.VectorStoreResponseModels
{
	public record ExpiresAfter
	{
		[JsonPropertyName("anchor")]
		public string Anchor { get; set; }

		[JsonPropertyName("days")]
		public int Days { get; set; }
	}
	public record FileCounts
	{
		[JsonPropertyName("in_progress")]
		public int InProgress { get; set; }

		[JsonPropertyName("completed")]
		public int Completed { get; set; }

		[JsonPropertyName("failed")]
		public int Failed { get; set; }

		[JsonPropertyName("cancelled")]
		public int Cancelled { get; set; }

		[JsonPropertyName("total")]
		public int Total { get; set; }
	}
	public record VectorStoreFileBatchListObjectResponse : DataWithPagingBaseResponse<List<VectorStoreFileBatchObject>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected VectorStoreFileBatchListObjectResponse(VectorStoreFileBatchListObjectResponse original)
			: base((DataWithPagingBaseResponse<List<VectorStoreFileBatchObject>>)original)
		{
		}
	}
	public record VectorStoreFileBatchObject : BaseResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("vector_store_id")]
		public string VectorStoreId { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("file_counts")]
		public FileCounts FileCounts { get; set; }
	}
	public record VectorStoreFileListObject : DataWithPagingBaseResponse<List<VectorStoreFileObject>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected VectorStoreFileListObject(VectorStoreFileListObject original)
			: base((DataWithPagingBaseResponse<List<VectorStoreFileObject>>)original)
		{
		}
	}
	public record VectorStoreFileObject : BaseResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("usage_bytes")]
		public int UsageBytes { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("vector_store_id")]
		public string VectorStoreId { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("last_error")]
		public Error? LastError { get; set; }

		[JsonPropertyName("chunking_strategy")]
		public ChunkingStrategy? ChunkingStrategy { get; set; }
	}
	public record VectorStoreListObjectResponse : DataWithPagingBaseResponse<List<VectorStoreObjectResponse>>
	{
		[CompilerGenerated]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[CompilerGenerated]
		protected VectorStoreListObjectResponse(VectorStoreListObjectResponse original)
			: base((DataWithPagingBaseResponse<List<VectorStoreObjectResponse>>)original)
		{
		}
	}
	public record VectorStoreObjectResponse : BaseResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("usage_bytes")]
		public int UsageBytes { get; set; }

		[JsonPropertyName("file_counts")]
		public FileCounts FileCounts { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("expires_after")]
		public ExpiresAfter ExpiresAfter { get; set; }

		[JsonPropertyName("expires_at")]
		public int? ExpiresAt { get; set; }

		[JsonPropertyName("last_active_at")]
		public int? LastActiveAt { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("chunking_strategy")]
		public ChunkingStrategy? ChunkingStrategy { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.ModelResponseModels
{
	public record ModelDeleteResponse : BaseResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("deleted")]
		public bool Deleted { get; set; }
	}
	public record ModelListResponse : BaseResponse
	{
		[JsonPropertyName("data")]
		public List<ModelResponse> Models { get; set; }
	}
	public record ModelRetrieveResponse : ModelResponse;
	public record ModelResponse : BaseResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("owned_by")]
		public string Owner { get; set; }

		[JsonPropertyName("permission")]
		public List<Permission> Permissions { get; set; } = new List<Permission>();

		[JsonPropertyName("created")]
		public int Created { get; set; }

		public DateTimeOffset CreatedTime => DateTimeOffset.FromUnixTimeSeconds(Created);

		[JsonPropertyName("root")]
		public string? Root { get; set; }

		[JsonPropertyName("parent")]
		public string? Parent { get; set; }
	}
	public record Permission : BaseResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("created")]
		public int Created { get; set; }

		public DateTimeOffset CreatedTime => DateTimeOffset.FromUnixTimeSeconds(Created);

		[JsonPropertyName("allow_create_engine")]
		public bool AllowCreateEngine { get; set; }

		[JsonPropertyName("allow_sampling")]
		public bool AllowSampling { get; set; }

		[JsonPropertyName("allow_logprobs")]
		public bool AllowLogprobs { get; set; }

		[JsonPropertyName("allow_search_indices")]
		public bool AllowSearchIndices { get; set; }

		[JsonPropertyName("allow_view")]
		public bool AllowView { get; set; }

		[JsonPropertyName("allow_fine_tuning")]
		public bool AllowFineTuning { get; set; }

		[JsonPropertyName("organization")]
		public string Organization { get; set; }

		[JsonPropertyName("group")]
		public object Group { get; set; }

		[JsonPropertyName("is_blocking")]
		public bool IsBlocking { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.ImageResponseModel
{
	public record ImageCreateResponse : BaseResponse, IOpenAIModels.ICreatedAt
	{
		public record ImageDataResult
		{
			[JsonPropertyName("url")]
			public string Url { get; set; }

			[JsonPropertyName("b64_json")]
			public string B64 { get; set; }

			[JsonPropertyName("revised_prompt")]
			public string RevisedPrompt { get; set; }
		}

		public class UsageModel
		{
			public class InputTokensDetailsModel
			{
				[JsonPropertyName("text_tokens")]
				public int TextTokens { get; set; }

				[JsonPropertyName("image_tokens")]
				public int ImageTokens { get; set; }

				public InputTokensDetailsModel()
				{
				}

				public InputTokensDetailsModel(int textTokens, int imageTokens)
				{
					TextTokens = textTokens;
					ImageTokens = imageTokens;
				}
			}

			[JsonPropertyName("total_tokens")]
			public int TotalTokens { get; set; }

			[JsonPropertyName("input_tokens")]
			public int InputTokens { get; set; }

			[JsonPropertyName("output_tokens")]
			public int OutputTokens { get; set; }

			[JsonPropertyName("input_tokens_details")]
			public InputTokensDetailsModel InputTokensDetails { get; set; }

			public UsageModel()
			{
			}

			public UsageModel(int totalTokens, int inputTokens, int outputTokens, InputTokensDetailsModel inputTokensDetails)
			{
				TotalTokens = totalTokens;
				InputTokens = inputTokens;
				OutputTokens = outputTokens;
				InputTokensDetails = inputTokensDetails;
			}
		}

		[JsonPropertyName("data")]
		public List<ImageDataResult> Results { get; set; }

		[JsonPropertyName("created")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("usage")]
		public UsageModel? Usage { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.FineTuningJobResponseModels
{
	public record FineTuningJobListEventsResponse : BaseResponse
	{
		[JsonPropertyName("data")]
		public List<EventResponse> Data { get; set; }

		[JsonPropertyName("has_more")]
		public bool HasMore { get; set; }
	}
	public record FineTuningJobListResponse : BaseResponse
	{
		[JsonPropertyName("data")]
		public List<FineTuningJobResponse> Data { get; set; }

		[JsonPropertyName("has_more")]
		public bool HasMore { get; set; }
	}
	public record FineTuningJobResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.IModel, IOpenAIModels.ICreatedAt
	{
		public class Hyperparameters
		{
			[JsonPropertyName("n_epochs")]
			[JsonConverter(typeof(NEpochsConverter))]
			public int? NEpochs { get; set; }
		}

		[JsonPropertyName("finished_at")]
		public int? FinishedAt { get; set; }

		[JsonPropertyName("fine_tuned_model")]
		public string? FineTunedModel { get; set; }

		[JsonPropertyName("organization_id")]
		public string? OrganizationId { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("hyperparameters")]
		public Hyperparameters HyperparametersData { get; set; }

		[JsonPropertyName("training_file")]
		public string TrainingFile { get; set; }

		[JsonPropertyName("validation_file")]
		public string? ValidationFile { get; set; }

		[JsonPropertyName("result_files")]
		public List<string> ResultFiles { get; set; }

		[JsonPropertyName("trained_tokens")]
		public int? TrainedTokens { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
	public class NEpochsConverter : JsonConverter<int?>
	{
		public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			switch (reader.TokenType)
			{
			case JsonTokenType.String:
				if (reader.GetString()?.ToLower() == "auto")
				{
					return -1;
				}
				break;
			case JsonTokenType.Number:
				return reader.GetInt32();
			case JsonTokenType.Null:
				return null;
			}
			throw new JsonException($"Unexpected token type: {reader.TokenType}");
		}

		public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
		{
			if (value.HasValue)
			{
				if (value.Value == -1)
				{
					writer.WriteStringValue("auto");
				}
				else
				{
					writer.WriteNumberValue(value.Value);
				}
			}
			else
			{
				writer.WriteNullValue();
			}
		}
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.FineTuneResponseModels
{
	public record FineTuneListEventsResponse : BaseResponse
	{
		[JsonPropertyName("data")]
		public List<EventResponse> Data { get; set; }
	}
	public record FineTuneListResponse : BaseResponse
	{
		[JsonPropertyName("data")]
		public List<FineTuneResponse> Data { get; set; }
	}
	public record FineTuneResponse : BaseResponse, IOpenAIModels.IId, IOpenAIModels.IModel, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("events")]
		public List<EventResponse> Events { get; set; }

		[JsonPropertyName("fine_tuned_model")]
		public string FineTunedModel { get; set; }

		[JsonPropertyName("hyperparams")]
		public HyperParametersResponse HyperParams { get; set; }

		[JsonPropertyName("organization_id")]
		public string OrganizationId { get; set; }

		[JsonPropertyName("result_files")]
		public List<FileResponse> ResultFiles { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("validation_files")]
		public List<FileResponse> ValidationFiles { get; set; }

		[JsonPropertyName("training_files")]
		public List<FileResponse> TrainingFiles { get; set; }

		[JsonPropertyName("updated_at")]
		public int? UpdatedAt { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.FileResponseModels
{
	public class FileContentResponse<T>
	{
		public T? Content { get; set; }

		public bool Successful => Error == null;

		[JsonPropertyName("error")]
		public Error? Error { get; set; }
	}
	public record FileDeleteResponse : BaseResponse, IOpenAIModels.IId
	{
		[JsonPropertyName("deleted")]
		public bool Deleted { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; set; }
	}
	public record FileListResponse : BaseResponse
	{
		[JsonPropertyName("data")]
		public List<FileResponse> Data { get; set; }
	}
	public record FileUploadResponse : BaseResponse, IOpenAIModels.ICreatedAt
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("bytes")]
		public int Bytes { get; set; }

		[JsonPropertyName("filename")]
		public string FileName { get; set; }

		[JsonPropertyName("purpose")]
		public string Purpose { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.ResponseModels.BatchResponseModel
{
	public record BatchResponse : BaseResponse, IOpenAIModels.IMetaData
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("endpoint")]
		public string Endpoint { get; set; }

		[JsonPropertyName("errors")]
		public ErrorList? Errors { get; set; }

		[JsonPropertyName("input_file_id")]
		public string InputFileId { get; set; }

		[JsonPropertyName("completion_window")]
		public string CompletionWindow { get; set; }

		[JsonPropertyName("status")]
		public string Status { get; set; }

		[JsonPropertyName("output_file_id")]
		public string? OutputFileId { get; set; }

		[JsonPropertyName("error_file_id")]
		public string? ErrorFileId { get; set; }

		[JsonPropertyName("created_at")]
		public long CreatedAtUnix { get; set; }

		public DateTimeOffset CreatedAt => DateTimeOffset.FromUnixTimeSeconds(CreatedAtUnix);

		[JsonPropertyName("in_progress_at")]
		public int? InProgressAt { get; set; }

		[JsonPropertyName("expires_at")]
		public int? ExpiresAt { get; set; }

		[JsonPropertyName("finalizing_at")]
		public int? FinalizingAt { get; set; }

		[JsonPropertyName("completed_at")]
		public int? CompletedAt { get; set; }

		[JsonPropertyName("failed_at")]
		public int? FailedAt { get; set; }

		[JsonPropertyName("expired_at")]
		public int? ExpiredAt { get; set; }

		[JsonPropertyName("cancelling_at")]
		public int? CancellingAt { get; set; }

		[JsonPropertyName("cancelled_at")]
		public int? CancelledAt { get; set; }

		[JsonPropertyName("request_counts")]
		public RequestCountsResponse RequestCounts { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public record RequestCountsResponse
	{
		[JsonPropertyName("total")]
		public int Total { get; set; }

		[JsonPropertyName("completed")]
		public int Completed { get; set; }

		[JsonPropertyName("failed")]
		public int Failed { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.RequestModels
{
	public class AssistantCreateRequest : IOpenAIModels.IModel, IOpenAIModels.IMetaData, IOpenAIModels.ITemperature
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("tools")]
		public List<ToolDefinition>? Tools { get; set; }

		[JsonPropertyName("tool_resources")]
		public ToolResources? ToolResources { get; set; }

		[JsonPropertyName("top_p")]
		public double? TopP { get; set; }

		[JsonPropertyName("reasoning_effort")]
		public string? ReasoningEffort { get; set; }

		[JsonPropertyName("response_format")]
		public ResponseFormatOneOfType? ResponseFormat { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("temperature")]
		public float? Temperature { get; set; }
	}
	public class AssistantFileCreateRequest
	{
		[JsonPropertyName("file_id")]
		public string FileId { get; set; }
	}
	public class AssistantModifyRequest : IOpenAIModels.IModel, IOpenAIModels.IMetaData, IOpenAIModels.ITemperature
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("tools")]
		public List<ToolDefinition>? Tools { get; set; }

		[JsonPropertyName("tool_resources")]
		public ToolResources? ToolResources { get; set; }

		[JsonPropertyName("top_p")]
		public double? TopP { get; set; }

		[JsonPropertyName("reasoning_effort")]
		public string? ReasoningEffort { get; set; }

		[JsonPropertyName("response_format")]
		public ResponseFormatOneOfType? ResponseFormat { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("temperature")]
		public float? Temperature { get; set; }
	}
	public record AudioCreateSpeechRequest : IOpenAIModels.IModel
	{
		[JsonPropertyName("input")]
		public string Input { get; set; }

		[JsonPropertyName("voice")]
		public string Voice { get; set; }

		[JsonPropertyName("response_format")]
		public string? ResponseFormat { get; set; }

		[JsonPropertyName("speed")]
		public float? Speed { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
	public record AudioCreateTranscriptionRequest : IOpenAIModels.IModel, IOpenAIModels.ITemperature, IOpenAIModels.IFile
	{
		public string? Prompt { get; set; }

		public string? ResponseFormat { get; set; }

		public string? Language { get; set; }

		public List<string>? TimestampGranularities { get; set; }

		public byte[]? File { get; set; }

		public Stream? FileStream { get; set; }

		public string FileName { get; set; }

		public string Model { get; set; }

		public float? Temperature { get; set; }
	}
	public record BatchCreateRequest : IOpenAIModels.IMetaData
	{
		[JsonPropertyName("input_file_id")]
		public string InputFileId { get; set; }

		[JsonPropertyName("endpoint")]
		public string Endpoint { get; set; }

		[JsonPropertyName("completion_window")]
		public string CompletionWindow { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public class ChatCompletionCreateRequest : IModelValidate, IOpenAIModels.ITemperature, IOpenAIModels.IModel, IOpenAIModels.IUser
	{
		public enum ResponseFormats
		{
			Text,
			Json,
			JsonSchema
		}

		public enum ReasoningEfforts
		{
			Low,
			Medium,
			High
		}

		[JsonPropertyName("messages")]
		public IList<ChatMessage> Messages { get; set; }

		[JsonPropertyName("top_p")]
		public float? TopP { get; set; }

		[JsonPropertyName("n")]
		public int? N { get; set; }

		[JsonPropertyName("stream")]
		public bool? Stream { get; set; }

		[JsonPropertyName("stream_options")]
		public StreamOptions? StreamOptions { get; set; }

		[JsonIgnore]
		public string? Stop { get; set; }

		[JsonIgnore]
		public IList<string>? StopAsList { get; set; }

		[JsonPropertyName("stop")]
		public IList<string>? StopCalculated
		{
			get
			{
				if (Stop != null && StopAsList != null)
				{
					throw new ValidationException("Stop and StopAsList can not be assigned at the same time. One of them is should be null.");
				}
				if (Stop != null)
				{
					return new List<string> { Stop };
				}
				return StopAsList;
			}
		}

		[JsonPropertyName("max_tokens")]
		public int? MaxTokens { get; set; }

		[JsonPropertyName("max_completion_tokens")]
		public int? MaxCompletionTokens { get; set; }

		[JsonPropertyName("presence_penalty")]
		public float? PresencePenalty { get; set; }

		[JsonPropertyName("frequency_penalty")]
		public float? FrequencyPenalty { get; set; }

		[JsonPropertyName("logit_bias")]
		public object? LogitBias { get; set; }

		[JsonIgnore]
		public IList<ToolDefinition>? Tools { get; set; }

		[JsonIgnore]
		public object? ToolsAsObject { get; set; }

		[JsonPropertyName("tools")]
		public object? ToolsCalculated
		{
			get
			{
				if (ToolsAsObject != null && Tools != null)
				{
					throw new ValidationException("ToolsAsObject and Tools can not be assigned at the same time. One of them is should be null.");
				}
				return Tools ?? ToolsAsObject;
			}
		}

		[JsonIgnore]
		public ToolChoice? ToolChoice { get; set; }

		[JsonPropertyName("tool_choice")]
		public object? ToolChoiceCalculated
		{
			get
			{
				if (ToolChoice != null && ToolChoice.Type != StaticValues.CompletionStatics.ToolChoiceType.Function && ToolChoice.Function != null)
				{
					throw new ValidationException("You cannot choose another type besides \"function\" while ToolChoice.Function is not null.");
				}
				if (ToolChoice?.Type == StaticValues.CompletionStatics.ToolChoiceType.Function)
				{
					return ToolChoice;
				}
				return ToolChoice?.Type;
			}
		}

		[JsonPropertyName("response_format")]
		public ResponseFormat? ResponseFormat { get; set; }

		[JsonIgnore]
		public ResponseFormats? ChatResponseFormat
		{
			set
			{
				if (value.HasValue)
				{
					if (ResponseFormat?.Type != null)
					{
						throw new ValidationException("ResponseFormat and ChatResponseFormat can not be assigned at the same time. One of them is should be null.");
					}
					ResponseFormat responseFormat = new ResponseFormat();
					ResponseFormat responseFormat2 = responseFormat;
					responseFormat2.Type = value switch
					{
						ResponseFormats.Json => StaticValues.CompletionStatics.ResponseFormat.Json, 
						ResponseFormats.Text => StaticValues.CompletionStatics.ResponseFormat.Text, 
						ResponseFormats.JsonSchema => StaticValues.CompletionStatics.ResponseFormat.JsonSchema, 
						_ => throw new ArgumentOutOfRangeException("value", value, null), 
					};
					ResponseFormat = responseFormat;
				}
			}
		}

		[JsonPropertyName("seed")]
		public int? Seed { get; set; }

		[JsonPropertyName("logprobs")]
		public bool? LogProbs { get; set; }

		[JsonPropertyName("top_logprobs")]
		public int? TopLogprobs { get; set; }

		[JsonPropertyName("parallel_tool_calls")]
		public bool? ParallelToolCalls { get; set; }

		[JsonPropertyName("model")]
		public string? Model { get; set; }

		[JsonPropertyName("reasoning_effort")]
		public string? ReasoningEffort { get; set; }

		[JsonIgnore]
		public ReasoningEfforts? ChatReasoningEffort
		{
			set
			{
				if (value.HasValue)
				{
					if (ReasoningEffort != null)
					{
						throw new ValidationException("ReasoningEffort and ChatReasoningEffort can not be assigned at the same time. One of them should be null.");
					}
					ReasoningEffort = value switch
					{
						ReasoningEfforts.Low => StaticValues.CompletionStatics.ReasoningEffort.Low, 
						ReasoningEfforts.Medium => StaticValues.CompletionStatics.ReasoningEffort.Medium, 
						ReasoningEfforts.High => StaticValues.CompletionStatics.ReasoningEffort.High, 
						_ => throw new ArgumentOutOfRangeException("value", value, null), 
					};
				}
			}
		}

		[JsonPropertyName("temperature")]
		public float? Temperature { get; set; }

		[JsonPropertyName("user")]
		public string User { get; set; }

		[JsonPropertyName("service_tier")]
		public string? ServiceTier { get; set; }

		[JsonPropertyName("store")]
		public bool? Store { get; set; }

		public IEnumerable<ValidationResult> Validate()
		{
			throw new NotImplementedException();
		}
	}
	public class ChatMessage
	{
		[JsonPropertyName("role")]
		public string Role { get; set; }

		[JsonIgnore]
		public string? Content { get; set; }

		[JsonPropertyName("reasoning_content")]
		public string? ReasoningContent { get; set; }

		[JsonIgnore]
		public IList<MessageContent>? Contents { get; set; }

		[JsonPropertyName("content")]
		public object ContentCalculated
		{
			get
			{
				if (Content != null && Contents != null)
				{
					throw new ValidationException("Content and Contents can not be assigned at the same time. One of them must be null.");
				}
				if (Content != null)
				{
					return Content;
				}
				return Contents;
			}
			set
			{
				Content = value?.ToString();
			}
		}

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("tool_call_id")]
		public string? ToolCallId { get; set; }

		[JsonPropertyName("function_call")]
		public FunctionCall? FunctionCall { get; set; }

		[JsonPropertyName("tool_calls")]
		public IList<ToolCall>? ToolCalls { get; set; }

		public ChatMessage()
		{
		}

		public ChatMessage(string role, string content, string? name = null, IList<ToolCall>? toolCalls = null, string? toolCallId = null)
		{
			Role = role;
			Content = content;
			Name = name;
			ToolCalls = toolCalls;
			ToolCallId = toolCallId;
		}

		public ChatMessage(string role, IList<MessageContent> contents, string? name = null, IList<ToolCall>? toolCalls = null, string? toolCallId = null)
		{
			Role = role;
			Contents = contents;
			Name = name;
			ToolCalls = toolCalls;
			ToolCallId = toolCallId;
		}

		public static ChatMessage FromAssistant(string content, string? name = null, IList<ToolCall>? toolCalls = null)
		{
			return new ChatMessage(StaticValues.ChatMessageRoles.Assistant, content, name, toolCalls);
		}

		public static ChatMessage FromTool(string content, string toolCallId)
		{
			return new ChatMessage(StaticValues.ChatMessageRoles.Tool, content, null, null, toolCallId);
		}

		public static ChatMessage FromUser(string content, string? name = null)
		{
			return new ChatMessage(StaticValues.ChatMessageRoles.User, content, name);
		}

		public static ChatMessage FromSystem(string content, string? name = null)
		{
			return new ChatMessage(StaticValues.ChatMessageRoles.System, content, name);
		}

		public static ChatMessage FromUser(IList<MessageContent> contents)
		{
			return new ChatMessage(StaticValues.ChatMessageRoles.User, contents);
		}
	}
	public record CompletionCreateRequest : IModelValidate, IOpenAIModels.ITemperature, IOpenAIModels.IModel, IOpenAIModels.ILogProbsRequest, IOpenAIModels.IUser
	{
		[JsonIgnore]
		public string? Prompt { get; set; }

		[JsonIgnore]
		public IList<string>? PromptAsList { get; set; }

		[JsonPropertyName("prompt")]
		public IList<string>? PromptCalculated
		{
			get
			{
				if (Prompt != null && PromptAsList != null)
				{
					throw new ValidationException("Prompt and PromptAsList can not be assigned at the same time. One of them is should be null.");
				}
				if (Prompt != null)
				{
					return new List<string> { Prompt };
				}
				return PromptAsList;
			}
		}

		[JsonPropertyName("suffix")]
		public string? Suffix { get; set; }

		[JsonPropertyName("max_tokens")]
		public int? MaxTokens { get; set; }

		[JsonPropertyName("top_p")]
		public float? TopP { get; set; }

		[JsonPropertyName("n")]
		public int? N { get; set; }

		[JsonPropertyName("stream")]
		public bool? Stream { get; set; }

		[JsonPropertyName("echo")]
		public bool? Echo { get; set; }

		[JsonIgnore]
		public string? Stop { get; set; }

		[JsonIgnore]
		public IList<string>? StopAsList { get; set; }

		[JsonPropertyName("stop")]
		public IList<string>? StopCalculated
		{
			get
			{
				if (Stop != null && StopAsList != null)
				{
					throw new ValidationException("Stop and StopAsList can not be assigned at the same time. One of them is should be null.");
				}
				if (Stop != null)
				{
					return new List<string> { Stop };
				}
				return StopAsList;
			}
		}

		[JsonPropertyName("presence_penalty")]
		public float? PresencePenalty { get; set; }

		[JsonPropertyName("frequency_penalty")]
		public float? FrequencyPenalty { get; set; }

		[JsonPropertyName("best_of")]
		public int? BestOf { get; set; }

		[JsonPropertyName("logit_bias")]
		public object? LogitBias { get; set; }

		[JsonPropertyName("logprobs")]
		public int? LogProbs { get; set; }

		[JsonPropertyName("model")]
		public string? Model { get; set; }

		[JsonPropertyName("temperature")]
		public float? Temperature { get; set; }

		[JsonPropertyName("user")]
		public string? User { get; set; }

		public IEnumerable<ValidationResult> Validate()
		{
			throw new NotImplementedException();
		}
	}
	public record CreateModerationRequest : IOpenAIModels.IModel
	{
		[JsonIgnore]
		public List<string>? InputAsList { get; set; }

		[JsonIgnore]
		public string? Input { get; set; }

		[JsonPropertyName("input")]
		public IList<string>? InputCalculated
		{
			get
			{
				if (Input != null && InputAsList != null)
				{
					throw new ValidationException("Input and InputAsList can not be assigned at the same time. One of them is should be null.");
				}
				if (Input != null)
				{
					return new List<string> { Input };
				}
				return InputAsList;
			}
		}

		[JsonPropertyName("model")]
		public string? Model { get; set; }
	}
	public class CreateThreadAndRunRequest : IOpenAIModels.IAssistantId, IOpenAIModels.IModel
	{
		[JsonPropertyName("thread")]
		public ThreadCreateRequest Thread { get; set; }

		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("tools")]
		public List<ToolsItem>? Tools { get; set; }

		[JsonPropertyName("tool_resources")]
		public ToolResources? ToolResources { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("temperature")]
		public double? Temperature { get; set; }

		[JsonPropertyName("top_p")]
		public double? TopP { get; set; }

		[JsonPropertyName("stream")]
		public bool? Stream { get; set; }

		[JsonPropertyName("max_prompt_tokens")]
		public int? MaxPromptTokens { get; set; }

		[JsonPropertyName("max_completion_tokens")]
		public int? MaxCompletionTokens { get; set; }

		[JsonPropertyName("truncation_strategy")]
		public TruncationStrategy TruncationStrategy { get; set; }

		[JsonPropertyName("tool_choice")]
		public AssistantsApiToolChoiceOneOfType ToolChoice { get; set; }

		[JsonPropertyName("reasoning_effort")]
		public string? ReasoningEffort { get; set; }

		[JsonPropertyName("response_format")]
		public ResponseFormatOneOfType ResponseFormat { get; set; }

		[JsonPropertyName("assistant_id")]
		public string AssistantId { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
	[JsonConverter(typeof(AssistantsApiToolChoiceConverter))]
	public class AssistantsApiToolChoiceOneOfType
	{
		[JsonIgnore]
		public string? AsString { get; set; }

		[JsonIgnore]
		public ToolChoice? AsObject { get; set; }
	}
	public class ToolResources
	{
		[JsonPropertyName("code_interpreter")]
		public CodeInterpreter CodeInterpreter { get; set; }

		[JsonPropertyName("file_search")]
		public FileSearch FileSearch { get; set; }
	}
	public class FileSearch
	{
		[JsonPropertyName("vector_store_ids")]
		public List<string>? VectorStoreIds { get; set; }

		[JsonPropertyName("vector_stores")]
		public List<VectorStores>? VectorStores { get; set; }
	}
	public class VectorStores : IOpenAIModels.IFileIds, IOpenAIModels.IMetaData
	{
		[JsonPropertyName("file_ids")]
		public List<string>? FileIds { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public class CodeInterpreter : IOpenAIModels.IFileIds
	{
		[JsonPropertyName("file_ids")]
		public List<string>? FileIds { get; set; }
	}
	public class ToolsItem
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("function")]
		public Function Function { get; set; }
	}
	public class Function
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("arguments")]
		public string Arguments { get; set; }

		[JsonPropertyName("output")]
		public string? Output { get; set; }
	}
	public class CreateVectorStoreFileBatchRequest
	{
		[JsonPropertyName("file_ids")]
		public List<string> FileIds { get; set; }

		[JsonPropertyName("chunking_strategy")]
		public ChunkingStrategy? ChunkingStrategy { get; set; }
	}
	public class CreateVectorStoreFileRequest
	{
		[JsonPropertyName("file_id")]
		public string FileId { get; set; }

		[JsonPropertyName("attributes")]
		public Dictionary<string, object>? Attributes { get; set; }
	}
	public class CreateVectorStoreRequest
	{
		[JsonPropertyName("file_ids")]
		public List<string>? FileIds { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("expires_after")]
		public ExpiresAfter? ExpiresAfter { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("chunking_strategy")]
		public ChunkingStrategy? ChunkingStrategy { get; set; }
	}
	public class ChunkingStrategy
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("static")]
		public StaticChunkingParameters? StaticParameters { get; set; }
	}
	public class StaticChunkingParameters
	{
		[JsonPropertyName("max_chunk_size_tokens")]
		public int MaxChunkSizeTokens { get; set; }

		[JsonPropertyName("chunk_overlap_tokens")]
		public int ChunkOverlapTokens { get; set; }
	}
	public record EditCreateRequest : IModelValidate, IOpenAIModels.ITemperature, IOpenAIModels.IModel
	{
		[JsonPropertyName("input")]
		public string? Input { get; set; }

		[JsonPropertyName("instruction")]
		public string Instruction { get; set; }

		[JsonPropertyName("n")]
		public int? N { get; set; }

		[JsonPropertyName("top_p")]
		public float? TopP { get; set; }

		[JsonPropertyName("model")]
		public string? Model { get; set; }

		[JsonPropertyName("temperature")]
		public float? Temperature { get; set; }

		public IEnumerable<ValidationResult> Validate()
		{
			throw new NotImplementedException();
		}
	}
	public record EmbeddingCreateRequest : IModelValidate, IOpenAIModels.IModel
	{
		[JsonIgnore]
		public List<string>? InputAsList { get; set; }

		[JsonIgnore]
		public string? Input { get; set; }

		[JsonPropertyName("input")]
		public IList<string>? InputCalculated
		{
			get
			{
				if (Input != null && InputAsList != null)
				{
					throw new ValidationException("Input and InputAsList can not be assigned at the same time. One of them is should be null.");
				}
				if (Input != null)
				{
					return new List<string> { Input };
				}
				return InputAsList;
			}
		}

		[JsonPropertyName("dimensions")]
		public int? Dimensions { get; set; }

		[JsonPropertyName("encoding_format")]
		public string? EncodingFormat { get; set; }

		[JsonPropertyName("model")]
		public string? Model { get; set; }

		public IEnumerable<ValidationResult> Validate()
		{
			throw new NotImplementedException();
		}
	}
	public record FineTuneCancelRequest
	{
		[JsonPropertyName("fine_tune_id")]
		public string FineTuneId { get; set; }
	}
	public record FineTuneCreateRequest : IOpenAIModels.IModel
	{
		[JsonPropertyName("training_file")]
		public string TrainingFile { get; set; }

		[JsonPropertyName("validation_file")]
		public string? ValidationFile { get; set; }

		[JsonPropertyName("n_epochs")]
		[JsonConverter(typeof(NEpochsConverter))]
		public int? NEpochs { get; set; }

		[JsonPropertyName("batch_size")]
		public int? BatchSize { get; set; }

		[JsonPropertyName("learning_rate_multiplier")]
		public float? LearningRateMultiplier { get; set; }

		[JsonPropertyName("prompt_loss_weight")]
		public float? PromptLossWeight { get; set; }

		[JsonPropertyName("compute_classification_metrics")]
		public bool? ComputeClassificationMetrics { get; set; }

		[JsonPropertyName("classification_n_classes")]
		public int? ClassificationNClasses { get; set; }

		[JsonPropertyName("classification_positive_class")]
		public string? ClassificationPositiveClass { get; set; }

		[JsonPropertyName("classification_betas")]
		public List<string>? ClassificationBetas { get; set; }

		[JsonPropertyName("suffix")]
		public string? Suffix { get; set; }

		[JsonPropertyName("model")]
		public string? Model { get; set; }
	}
	public record FineTuningJobCancelRequest
	{
		[JsonPropertyName("fine_tuning_job_id")]
		public string FineTuningJobId { get; set; }
	}
	public record FineTuningJobCreateRequest : IOpenAIModels.IModel
	{
		[JsonPropertyName("training_file")]
		public string TrainingFile { get; set; }

		[JsonPropertyName("validation_file")]
		public string? ValidationFile { get; set; }

		[JsonPropertyName("hyperparameters")]
		public HyperparametersRequestModel? Hyperparameters { get; set; }

		[JsonPropertyName("suffix")]
		public string? Suffix { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
	public class HyperparametersRequestModel
	{
		[JsonPropertyName("n_epochs")]
		[JsonConverter(typeof(NEpochsConverter))]
		public int? NEpochs { get; set; }
	}
	public class FineTuningJobListEventsRequest : FineTuningJobListRequest
	{
		[JsonIgnore]
		public string FineTuningJobId { get; set; }
	}
	public class FineTuningJobListRequest
	{
		[JsonPropertyName("after")]
		public string? After { get; set; }

		[JsonPropertyName("limit")]
		public int? Limit { get; set; }
	}
	public class FunctionCall
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("arguments")]
		public string? Arguments { get; set; }

		public Dictionary<string, object> ParseArguments()
		{
			return ((!string.IsNullOrWhiteSpace(Arguments)) ? JsonSerializer.Deserialize<Dictionary<string, object>>(Arguments) : null) ?? new Dictionary<string, object>();
		}
	}
	public class FunctionDefinition
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("parameters")]
		public PropertyDefinition Parameters { get; set; }

		[JsonPropertyName("strict")]
		public bool? Strict { get; set; }
	}
	public record ImageCreateRequest : SharedImageRequestBaseModel, IOpenAIModels.IUser
	{
		[JsonPropertyName("prompt")]
		public string Prompt { get; set; }

		[JsonPropertyName("quality")]
		public string? Quality { get; set; }

		[JsonPropertyName("style")]
		public string? Style { get; set; }

		public ImageCreateRequest()
		{
		}

		public ImageCreateRequest(string prompt)
		{
			Prompt = prompt;
		}
	}
	public record ImageEditCreateRequest : SharedImageRequestBaseModel
	{
		public byte[] Image { get; set; }

		public string ImageName { get; set; }

		public byte[]? Mask { get; set; }

		public string? MaskName { get; set; }

		[JsonPropertyName("prompt")]
		public string Prompt { get; set; }
	}
	public record ImageVariationCreateRequest : SharedImageRequestBaseModel
	{
		public byte[] Image { get; set; }

		public string ImageName { get; set; }
	}
	public class MessageContent
	{
		public class MessageFile
		{
			[JsonPropertyName("filename")]
			public string Filename { get; set; }

			[JsonPropertyName("file_data")]
			public string FileData { get; set; }

			[JsonPropertyName("file_id")]
			public string FileId { get; set; }

			public MessageFile()
			{
			}

			public MessageFile(string filename, string fileData, string fileId)
			{
				Filename = filename;
				FileData = fileData;
				FileId = fileId;
			}
		}

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("text")]
		public string? Text { get; set; }

		[JsonPropertyName("image_url")]
		public MessageImageUrl? ImageUrl { get; set; }

		[JsonPropertyName("image_file")]
		public MessageImageFile? ImageFile { get; set; }

		[JsonPropertyName("file")]
		public MessageFile? File { get; set; }

		public static MessageContent TextContent(string text)
		{
			return new MessageContent
			{
				Type = "text",
				Text = text
			};
		}

		public static MessageContent ImageUrlContent(string imageUrl, string? detail = null)
		{
			return new MessageContent
			{
				Type = "image_url",
				ImageUrl = new MessageImageUrl
				{
					Url = imageUrl,
					Detail = detail
				}
			};
		}

		public static MessageContent ImageFileContent(string fileId, string detail)
		{
			return new MessageContent
			{
				Type = "image_file",
				ImageFile = new MessageImageFile
				{
					FileId = fileId,
					Detail = detail
				}
			};
		}

		public static MessageContent ImageBinaryContent(byte[] binaryImage, string imageType, string? detail = "auto")
		{
			return new MessageContent
			{
				Type = "image_url",
				ImageUrl = new MessageImageUrl
				{
					Url = "data:image/" + imageType + ";base64," + Convert.ToBase64String(binaryImage),
					Detail = detail
				}
			};
		}

		public static MessageContent FileBinaryContent(byte[] binaryFile, string fileType, string fileName)
		{
			return new MessageContent
			{
				Type = "file",
				File = new MessageFile
				{
					FileData = "data:application/" + fileType + ";base64," + Convert.ToBase64String(binaryFile),
					Filename = fileName
				}
			};
		}
	}
	public class MessageCreateRequest : IOpenAIModels.IMetaData
	{
		[JsonPropertyName("role")]
		public string Role { get; set; } = StaticValues.AssistantsStatics.MessageStatics.Roles.User;

		[JsonPropertyName("content")]
		public MessageContentOneOfType Content { get; set; }

		[JsonPropertyName("attachments")]
		public List<Attachment>? Attachments { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		public MessageCreateRequest()
		{
		}

		public MessageCreateRequest(string role, MessageContentOneOfType content, List<Attachment>? attachments = null, Dictionary<string, string>? metaData = null)
		{
			Role = role;
			Content = content;
			Attachments = attachments;
			Metadata = metaData;
		}
	}
	public class Attachment
	{
		[JsonPropertyName("file_id")]
		public string FileId { get; set; }

		[JsonPropertyName("tools")]
		public List<ToolDefinition> Tools { get; set; }
	}
	public class ModifyMessageRequest
	{
		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public class ModifyThreadRequest
	{
		[JsonPropertyName("tool_resources")]
		public ToolResources? ToolResources { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public class VectorStoreFileListRequest : PaginationRequest
	{
		[JsonPropertyName("filter")]
		public string? Filter { get; set; }

		public override string? GetQueryParameters()
		{
			string queryParameters = base.GetQueryParameters();
			if (Filter == null)
			{
				return queryParameters;
			}
			if (queryParameters != null)
			{
				return queryParameters + "&filter=" + WebUtility.UrlEncode(Filter);
			}
			return "filter=" + WebUtility.UrlEncode(Filter);
		}
	}
	public class PaginationRequest
	{
		[JsonPropertyName("limit")]
		public int? Limit { get; set; }

		[JsonPropertyName("order")]
		public string? Order { get; set; }

		[JsonPropertyName("after")]
		public string? After { get; set; }

		[JsonPropertyName("before")]
		public string? Before { get; set; }

		public virtual string? GetQueryParameters()
		{
			List<string> list = new List<string>();
			if (Limit.HasValue)
			{
				list.Add($"limit={Limit}");
			}
			if (Order != null)
			{
				list.Add("order=" + WebUtility.UrlEncode(Order));
			}
			if (After != null)
			{
				list.Add("after=" + WebUtility.UrlEncode(After));
			}
			if (Before != null)
			{
				list.Add("before=" + WebUtility.UrlEncode(Before));
			}
			if (list.Count <= 0)
			{
				return null;
			}
			return string.Join("&", list);
		}
	}
	public class MessageListRequest : PaginationRequest
	{
		[JsonPropertyName("run_ID")]
		public string? RunId { get; set; }

		public override string? GetQueryParameters()
		{
			string queryParameters = base.GetQueryParameters();
			if (string.IsNullOrWhiteSpace(RunId))
			{
				return queryParameters;
			}
			if (queryParameters != null)
			{
				return queryParameters + "&run_id=" + WebUtility.UrlEncode(RunId);
			}
			return "run_id=" + WebUtility.UrlEncode(RunId);
		}
	}
	public class ResponseFormat
	{
		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("json_schema")]
		public JsonSchema JsonSchema { get; set; }
	}
	public class JsonSchema
	{
		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("strict")]
		public bool? Strict { get; set; }

		[JsonPropertyName("schema")]
		public PropertyDefinition? Schema { get; set; }
	}
	[JsonConverter(typeof(ResponseFormatOptionConverter))]
	public class ResponseFormatOneOfType
	{
		[JsonIgnore]
		public string? AsString { get; set; }

		[JsonIgnore]
		public ResponseFormat? AsObject { get; set; }

		public ResponseFormatOneOfType()
		{
		}

		public ResponseFormatOneOfType(string asString)
		{
			AsString = asString;
		}

		public ResponseFormatOneOfType(ResponseFormat asObject)
		{
			AsObject = asObject;
		}
	}
	public class RunCreateRequest : IOpenAIModels.IModel, IOpenAIModels.IMetaData, IOpenAIModels.ITemperature, IOpenAIModels.IAssistantId
	{
		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("additional_instructions")]
		public string? AdditionalInstructions { get; set; }

		[JsonPropertyName("additional_messages")]
		public List<MessageCreateRequest>? AdditionalMessages { get; set; }

		[JsonPropertyName("tools")]
		public List<ToolDefinition>? Tools { get; set; }

		[JsonPropertyName("top_p")]
		public float? TopP { get; set; }

		[JsonPropertyName("stream")]
		public bool? Stream { get; set; }

		[JsonPropertyName("max_prompt_tokens")]
		public int? MaxPromptTokens { get; set; }

		[JsonPropertyName("max_completion_tokens")]
		public int? MaxCompletionTokens { get; set; }

		[JsonPropertyName("truncation_strategy")]
		public TruncationStrategy? TruncationStrategy { get; set; }

		[JsonPropertyName("tool_choice")]
		public ToolChoiceOneOfType? ToolChoice { get; set; }

		[JsonPropertyName("response_format")]
		public ResponseFormatOneOfType? ResponseFormat { get; set; }

		[JsonPropertyName("assistant_id")]
		public string AssistantId { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }

		[JsonPropertyName("model")]
		public string? Model { get; set; }

		[JsonPropertyName("temperature")]
		public float? Temperature { get; set; }

		[JsonPropertyName("reasoning_effort")]
		public string? ReasoningEffort { get; set; }
	}
	public class RunModifyRequest : IOpenAIModels.IMetaData
	{
		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public sealed class StreamOptions
	{
		[JsonPropertyName("include_usage")]
		public bool IncludeUsage { get; set; }
	}
	public class SubmitToolOutputsToRunRequest
	{
		[Required]
		[JsonPropertyName("tool_outputs")]
		public List<ToolOutput> ToolOutputs { get; set; }

		[JsonPropertyName("stream")]
		public bool? Stream { get; set; }
	}
	public class ToolOutput
	{
		[JsonPropertyName("tool_call_id")]
		public string? ToolCallId { get; set; }

		[JsonPropertyName("output")]
		public string? Output { get; set; }
	}
	public class ThreadCreateRequest : IOpenAIModels.IMetaData
	{
		[JsonPropertyName("messages")]
		public List<MessageCreateRequest>? Messages { get; set; }

		[JsonPropertyName("tool_resources")]
		public ToolResources? ToolResources { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public class ToolCall
	{
		[JsonPropertyName("index")]
		public int Index { get; set; }

		[JsonPropertyName("id")]
		public string? Id { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }

		[JsonPropertyName("function")]
		public FunctionCall? FunctionCall { get; set; }
	}
	public class ToolChoice
	{
		public class FunctionTool
		{
			[JsonPropertyName("name")]
			public string Name { get; set; }
		}

		public static ToolChoice None => new ToolChoice
		{
			Type = StaticValues.CompletionStatics.ToolChoiceType.None
		};

		public static ToolChoice Auto => new ToolChoice
		{
			Type = StaticValues.CompletionStatics.ToolChoiceType.Auto
		};

		public static ToolChoice Required => new ToolChoice
		{
			Type = StaticValues.CompletionStatics.ToolChoiceType.Required
		};

		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("function")]
		public FunctionTool? Function { get; set; }

		public static ToolChoice FunctionChoice(string functionName)
		{
			return new ToolChoice
			{
				Type = StaticValues.CompletionStatics.ToolChoiceType.Function,
				Function = new FunctionTool
				{
					Name = functionName
				}
			};
		}
	}
	[JsonConverter(typeof(ToolChoiceOneOfTypeConverter))]
	public class ToolChoiceOneOfType
	{
		public class ToolChoiceOneOfTypeConverter : JsonConverter<ToolChoiceOneOfType>
		{
			public override ToolChoiceOneOfType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
			{
				return reader.TokenType switch
				{
					JsonTokenType.String => new ToolChoiceOneOfType
					{
						AsString = reader.GetString()
					}, 
					JsonTokenType.StartArray => new ToolChoiceOneOfType
					{
						AsObject = JsonSerializer.Deserialize<ToolChoice>(ref reader, options)
					}, 
					_ => throw new JsonException(), 
				};
			}

			public override void Write(Utf8JsonWriter writer, ToolChoiceOneOfType? value, JsonSerializerOptions options)
			{
				if (value != null && value.AsString != null)
				{
					writer.WriteStringValue(value.AsString);
				}
				else if (value?.AsObject != null)
				{
					JsonSerializer.Serialize(writer, value.AsObject, options);
				}
				else
				{
					writer.WriteNullValue();
				}
			}
		}

		[JsonIgnore]
		public string? AsString { get; set; }

		[JsonIgnore]
		public ToolChoice? AsObject { get; set; }

		public ToolChoiceOneOfType(string toolChoiceAsString)
		{
			AsString = toolChoiceAsString;
		}

		public ToolChoiceOneOfType(ToolChoice toolChoiceAsObject)
		{
			AsObject = toolChoiceAsObject;
		}

		public ToolChoiceOneOfType()
		{
		}
	}
	public class ToolDefinition
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("file_search")]
		public FileSearchTool? FileSearchTool { get; set; }

		[JsonIgnore]
		public FunctionDefinition? Function { get; set; }

		[JsonIgnore]
		public object? FunctionsAsObject { get; set; }

		[JsonPropertyName("function")]
		public object? FunctionCalculated
		{
			get
			{
				if (FunctionsAsObject != null && Function != null)
				{
					throw new ValidationException("FunctionAsObject and Function can not be assigned at the same time. One of them is should be null.");
				}
				return Function ?? FunctionsAsObject;
			}
		}

		public static ToolDefinition DefineFunction(FunctionDefinition function)
		{
			return new ToolDefinition
			{
				Type = StaticValues.CompletionStatics.ToolType.Function,
				Function = function
			};
		}

		public static ToolDefinition DefineCodeInterpreter()
		{
			return new ToolDefinition
			{
				Type = StaticValues.AssistantsStatics.ToolCallTypes.CodeInterpreter
			};
		}

		[Obsolete("Retrieval is now called FileSearch")]
		public static ToolDefinition DefineRetrieval()
		{
			return new ToolDefinition
			{
				Type = StaticValues.AssistantsStatics.ToolCallTypes.FileSearch
			};
		}

		public static ToolDefinition DefineFileSearch(FileSearchTool? fileSearchTool = null)
		{
			return new ToolDefinition
			{
				Type = StaticValues.AssistantsStatics.ToolCallTypes.FileSearch,
				FileSearchTool = fileSearchTool
			};
		}
	}
	public class FileSearchTool
	{
		[JsonPropertyName("max_num_results")]
		public int? MaxNumberResults { get; set; }

		[JsonPropertyName("ranking_options")]
		public RankingOptions? RankingOptions { get; set; }

		[JsonPropertyName("filters")]
		public FileSearchFilter? Filters { get; set; }
	}
	public class RankingOptions
	{
		[JsonPropertyName("ranker")]
		public string? Ranker { get; set; }

		[JsonPropertyName("score_threshold")]
		public float ScoreThreshold { get; set; }
	}
	public class FileSearchFilter
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("key")]
		public string? Key { get; set; }

		[JsonPropertyName("value")]
		public object? Value { get; set; }

		[JsonPropertyName("filters")]
		public List<FileSearchFilter>? Filters { get; set; }

		public FileSearchFilter(string type)
		{
			Type = type;
		}

		public static FileSearchFilter DefineComparisonFilter(string property, string condition, object value)
		{
			return new FileSearchFilter(condition)
			{
				Key = property,
				Value = value
			};
		}

		public static FileSearchFilter DefineCompoundFilter(List<FileSearchFilter> filters, string condition)
		{
			return new FileSearchFilter(condition)
			{
				Filters = filters
			};
		}
	}
	public static class ComparisonFilter
	{
		public const string Equal = "eq";

		public const string NotEqual = "ne";

		public const string Greater = "gt";

		public const string GreaterOrEqual = "gte";

		public const string Less = "lt";

		public const string LessOrEqual = "lte";
	}
	public static class CompoundFilter
	{
		public const string And = "and";

		public const string Or = "or";
	}
	public class UpdateVectorStoreRequest
	{
		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("expires_after")]
		public ExpiresAfter ExpiresAfter { get; set; }

		[JsonPropertyName("metadata")]
		public Dictionary<string, string>? Metadata { get; set; }
	}
	public class MessageImageUrl
	{
		[JsonPropertyName("url")]
		public string Url { get; set; }

		[JsonPropertyName("detail")]
		public string? Detail { get; set; }
	}
	public class MessageImageFile
	{
		[JsonPropertyName("file_id")]
		public string FileId { get; set; }

		[JsonPropertyName("detail")]
		public string Detail { get; set; }
	}
}
namespace Betalgo.Ranul.OpenAI.ObjectModels.RealtimeModels
{
	public static class RealtimeConstants
	{
		public static class SubProtocols
		{
			public const string Realtime = "realtime";

			public const string Beta = "openai-beta.realtime-v1";
		}

		public static class Headers
		{
			public const string Authorization = "Authorization";

			public const string OpenAIBeta = "OpenAI-Beta";

			public const string OpenAIOrganization = "OpenAI-Organization";
		}

		public static class Audio
		{
			public const string FormatPcm16 = "pcm16";

			public const string FormatG711Ulaw = "g711_ulaw";

			public const string FormatG711Alaw = "g711_alaw";

			public const int DefaultSampleRate = 24000;

			public const int DefaultBitsPerSample = 16;

			public const int DefaultChannels = 1;
		}

		public static class TurnDetection
		{
			public const string TypeServerVad = "server_vad";

			public const double DefaultThreshold = 0.5;

			public const int DefaultPrefixPaddingMs = 300;

			public const int DefaultSilenceDurationMs = 200;
		}
	}
	internal class StatusJsonConverter : JsonConverter<Status>
	{
		public override Status Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString() switch
			{
				"completed" => Status.Completed, 
				"in_progress" => Status.InProgress, 
				"incomplete" => Status.Incomplete, 
				"cancelled" => Status.Cancelled, 
				"failed" => Status.Failed, 
				_ => Status.Unimplemented, 
			};
		}

		public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value switch
			{
				Status.Completed => "completed", 
				Status.InProgress => "in_progress", 
				Status.Incomplete => "incomplete", 
				Status.Cancelled => "cancelled", 
				Status.Failed => "failed", 
				_ => "unimplemented", 
			});
		}
	}
	internal class AudioFormatJsonConverter : JsonConverter<AudioFormat>
	{
		public override AudioFormat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString() switch
			{
				"pcm16" => AudioFormat.PCM16, 
				"g711_ulaw" => AudioFormat.G711_ULAW, 
				"g711_alaw" => AudioFormat.G711_ALAW, 
				_ => AudioFormat.Unimplemented, 
			};
		}

		public override void Write(Utf8JsonWriter writer, AudioFormat value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value switch
			{
				AudioFormat.PCM16 => "pcm16", 
				AudioFormat.G711_ULAW => "g711_ulaw", 
				AudioFormat.G711_ALAW => "g711_alaw", 
				_ => "unimplemented", 
			});
		}
	}
	internal class ContentTypeJsonConverter : JsonConverter<ContentType>
	{
		public override ContentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString() switch
			{
				"input_text" => ContentType.InputText, 
				"input_audio" => ContentType.InputAudio, 
				"text" => ContentType.Text, 
				"audio" => ContentType.Audio, 
				_ => ContentType.Unimplemented, 
			};
		}

		public override void Write(Utf8JsonWriter writer, ContentType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value switch
			{
				ContentType.InputText => "input_text", 
				ContentType.InputAudio => "input_audio", 
				ContentType.Text => "text", 
				ContentType.Audio => "audio", 
				_ => "unimplemented", 
			});
		}
	}
	internal class ItemTypeJsonConverter : JsonConverter<ItemType>
	{
		public override ItemType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString() switch
			{
				"message" => ItemType.Message, 
				"function_call" => ItemType.FunctionCall, 
				"function_call_output" => ItemType.FunctionCallOutput, 
				_ => ItemType.Unimplemented, 
			};
		}

		public override void Write(Utf8JsonWriter writer, ItemType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value switch
			{
				ItemType.Message => "message", 
				ItemType.FunctionCall => "function_call", 
				ItemType.FunctionCallOutput => "function_call_output", 
				_ => "unimplemented", 
			});
		}
	}
	internal class RoleJsonConverter : JsonConverter<Role>
	{
		public override Role Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return reader.GetString() switch
			{
				"user" => Role.User, 
				"assistant" => Role.Assistant, 
				"system" => Role.System, 
				_ => Role.Unimplemented, 
			};
		}

		public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value switch
			{
				Role.User => "user", 
				Role.Assistant => "assistant", 
				Role.System => "system", 
				_ => "unimplemented", 
			});
		}
	}
	[JsonConverter(typeof(StatusJsonConverter))]
	public enum Status
	{
		Unimplemented,
		Completed,
		InProgress,
		Incomplete,
		Cancelled,
		Failed
	}
	[JsonConverter(typeof(AudioFormatJsonConverter))]
	public enum AudioFormat
	{
		Unimplemented,
		PCM16,
		G711_ULAW,
		G711_ALAW
	}
	[JsonConverter(typeof(ContentTypeJsonConverter))]
	public enum ContentType
	{
		Unimplemented,
		InputText,
		InputAudio,
		Text,
		Audio
	}
	[JsonConverter(typeof(ItemTypeJsonConverter))]
	public enum ItemType
	{
		Unimplemented,
		Message,
		FunctionCall,
		FunctionCallOutput
	}
	[JsonConverter(typeof(RoleJsonConverter))]
	public enum Role
	{
		Unimplemented,
		User,
		Assistant,
		System
	}
	public static class RealtimeEventTypes
	{
		public static class Client
		{
			public static class Session
			{
				public const string Update = "session.update";
			}

			public static class InputAudioBuffer
			{
				public const string Append = "input_audio_buffer.append";

				public const string Commit = "input_audio_buffer.commit";

				public const string Clear = "input_audio_buffer.clear";
			}

			public static class Conversation
			{
				public static class Item
				{
					public const string Create = "conversation.item.create";

					public const string Truncate = "conversation.item.truncate";

					public const string Delete = "conversation.item.delete";
				}
			}

			public static class Response
			{
				public const string Create = "response.create";

				public const string Cancel = "response.cancel";
			}
		}

		public static class Server
		{
			public static class Session
			{
				public const string Created = "session.created";

				public const string Updated = "session.updated";
			}

			public static class Conversation
			{
				public static class Item
				{
					public static class InputAudioTranscription
					{
						public const string Completed = "conversation.item.input_audio_transcription.completed";

						public const string Failed = "conversation.item.input_audio_transcription.failed";
					}

					public const string Created = "conversation.item.created";

					public const string Truncated = "conversation.item.truncated";

					public const string Deleted = "conversation.item.deleted";
				}

				public const string Created = "conversation.created";
			}

			public static class InputAudioBuffer
			{
				public const string Committed = "input_audio_buffer.committed";

				public const string Cleared = "input_audio_buffer.cleared";

				public const string SpeechStarted = "input_audio_buffer.speech_started";

				public const string SpeechStopped = "input_audio_buffer.speech_stopped";
			}

			public static class Response
			{
				public static class OutputItem
				{
					public const string Added = "response.output_item.added";

					public const string Done = "response.output_item.done";
				}

				public static class ContentPart
				{
					public const string Added = "response.content_part.added";

					public const string Done = "response.content_part.done";
				}

				public static class Text
				{
					public const string Delta = "response.text.delta";

					public const string Done = "response.text.done";
				}

				public static class AudioTranscript
				{
					public const string Delta = "response.audio_transcript.delta";

					public const string Done = "response.audio_transcript.done";
				}

				public static class Audio
				{
					public const string Delta = "response.audio.delta";

					public const string Done = "response.audio.done";
				}

				public static class FunctionCallArguments
				{
					public const string Delta = "response.function_call_arguments.delta";

					public const string Done = "response.function_call_arguments.done";
				}

				public const string Created = "response.created";

				public const string Done = "response.done";
			}

			public static class RateLimits
			{
				public const string Updated = "rate_limits.updated";
			}

			public const string Error = "error";
		}
	}
	public abstract class EventBase
	{
		[JsonPropertyName("event_id")]
		public string? EventId { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; }

		protected EventBase()
		{
		}

		protected EventBase(string clientEventType)
		{
			Type = clientEventType;
		}
	}
	public abstract class ErrorEventBase : EventBase
	{
		[JsonPropertyName("error")]
		public Error Error { get; set; }
	}
	public class SessionConfig
	{
		[JsonPropertyName("modalities")]
		public List<string>? Modalities { get; set; }

		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("voice")]
		public string? Voice { get; set; }

		[JsonPropertyName("input_audio_format")]
		public AudioFormat? InputAudioFormat { get; set; }

		[JsonPropertyName("output_audio_format")]
		public AudioFormat? OutputAudioFormat { get; set; }

		[JsonPropertyName("input_audio_transcription")]
		public AudioTranscriptionConfig? InputAudioTranscription { get; set; }

		[JsonPropertyName("turn_detection")]
		public TurnDetectionConfig? TurnDetection { get; set; }

		[JsonPropertyName("tools")]
		public List<RealtimeToolDefinition>? Tools { get; set; }

		[JsonPropertyName("tool_choice")]
		public string? ToolChoice { get; set; }

		[JsonPropertyName("temperature")]
		public double? Temperature { get; set; }

		[JsonPropertyName("max_output_tokens")]
		public MaxOutputTokens? MaxOutputTokens { get; set; }

		public void SetMaxTokens(int tokens)
		{
			MaxOutputTokens = Betalgo.Ranul.OpenAI.ObjectModels.RealtimeModels.MaxOutputTokens.FromInt(tokens);
		}

		public void SetInfiniteTokens()
		{
			MaxOutputTokens = Betalgo.Ranul.OpenAI.ObjectModels.RealtimeModels.MaxOutputTokens.Infinite();
		}
	}
	public class RealtimeToolDefinition
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		[JsonPropertyName("parameters")]
		public PropertyDefinition Parameters { get; set; }
	}
	public class AudioTranscriptionConfig
	{
		[JsonPropertyName("model")]
		public string Model { get; set; }
	}
	public class TurnDetectionConfig
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("threshold")]
		public double Threshold { get; set; }

		[JsonPropertyName("prefix_padding_ms")]
		public int PrefixPaddingMs { get; set; }

		[JsonPropertyName("silence_duration_ms")]
		public int SilenceDurationMs { get; set; }
	}
	public class JsonSchema
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("properties")]
		public Dictionary<string, JsonSchemaProperty> Properties { get; set; }

		[JsonPropertyName("required")]
		public List<string>? Required { get; set; }
	}
	public class JsonSchemaProperty
	{
		[JsonPropertyName("type")]
		public string Type { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }
	}
	public class ConversationItem
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("type")]
		public ItemType Type { get; set; }

		[JsonPropertyName("status")]
		public Status? Status { get; set; }

		[JsonPropertyName("role")]
		public Role? Role { get; set; }

		[JsonPropertyName("content")]
		public List<ContentPart>? Content { get; set; }

		[JsonPropertyName("call_id")]
		public string? CallId { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("arguments")]
		public string? Arguments { get; set; }

		[JsonPropertyName("output")]
		public string? Output { get; set; }
	}
	public class ContentPart
	{
		[JsonPropertyName("type")]
		public ContentType Type { get; set; }

		[JsonPropertyName("text")]
		public string? Text { get; set; }

		[JsonPropertyName("audio")]
		public string? Audio { get; set; }

		[JsonPropertyName("transcript")]
		public string? Transcript { get; set; }
	}
	public class SessionUpdateRequest : EventBase
	{
		[JsonPropertyName("session")]
		public SessionConfig Session { get; set; }

		public SessionUpdateRequest()
			: base("session.update")
		{
		}
	}
	public class AudioBufferAppendRequest : EventBase
	{
		[JsonPropertyName("audio")]
		public string Audio { get; set; }

		public AudioBufferAppendRequest()
			: base("input_audio_buffer.append")
		{
		}
	}
	public class AudioBufferCommitRequest : EventBase
	{
		public AudioBufferCommitRequest()
			: base("input_audio_buffer.commit")
		{
		}
	}
	public class AudioBufferClearRequest : EventBase
	{
		public AudioBufferClearRequest()
			: base("input_audio_buffer.clear")
		{
		}
	}
	public class ConversationItemCreateRequest : EventBase
	{
		[JsonPropertyName("previous_item_id")]
		public string? PreviousItemId { get; set; }

		[JsonPropertyName("item")]
		public ConversationItem Item { get; set; }

		public ConversationItemCreateRequest()
			: base("conversation.item.create")
		{
		}
	}
	public class ConversationItemTruncateRequest : EventBase
	{
		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		[JsonPropertyName("content_index")]
		public int ContentIndex { get; set; }

		[JsonPropertyName("audio_end_ms")]
		public int AudioEndMs { get; set; }

		public ConversationItemTruncateRequest()
			: base("conversation.item.truncate")
		{
		}
	}
	public class ConversationItemDeleteRequest : EventBase
	{
		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		public ConversationItemDeleteRequest()
			: base("conversation.item.delete")
		{
		}
	}
	public class ResponseCreateRequest : EventBase
	{
		[JsonPropertyName("response")]
		public ResponseConfig Response { get; set; }

		public ResponseCreateRequest()
			: base("response.create")
		{
		}
	}
	public class ResponseConfig
	{
		[JsonPropertyName("modalities")]
		public List<string>? Modalities { get; set; }

		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("voice")]
		public string? Voice { get; set; }

		[JsonPropertyName("output_audio_format")]
		public AudioFormat? OutputAudioFormat { get; set; }

		[JsonPropertyName("tools")]
		public List<FunctionDefinition>? Tools { get; set; }

		[JsonPropertyName("tool_choice")]
		public string? ToolChoice { get; set; }

		[JsonPropertyName("temperature")]
		public double? Temperature { get; set; }

		[JsonPropertyName("max_output_tokens")]
		public MaxOutputTokens? MaxOutputTokens { get; set; }
	}
	public class ResponseCancelRequest : EventBase
	{
		public ResponseCancelRequest()
			: base("response.cancel")
		{
		}
	}
	public class ErrorEvent : ErrorEventBase
	{
	}
	public class SessionEvent : EventBase
	{
		[JsonPropertyName("session")]
		public SessionResource Session { get; set; }
	}
	public class SessionResource
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("object")]
		public string Object { get; set; } = "realtime.session";

		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("modalities")]
		public List<string> Modalities { get; set; }

		[JsonPropertyName("instructions")]
		public string? Instructions { get; set; }

		[JsonPropertyName("voice")]
		public string Voice { get; set; }

		[JsonPropertyName("input_audio_format")]
		public AudioFormat InputAudioFormat { get; set; }

		[JsonPropertyName("output_audio_format")]
		public AudioFormat OutputAudioFormat { get; set; }

		[JsonPropertyName("input_audio_transcription")]
		public AudioTranscriptionConfig? InputAudioTranscription { get; set; }

		[JsonPropertyName("turn_detection")]
		public TurnDetectionConfig? TurnDetection { get; set; }

		[JsonPropertyName("tools")]
		public List<FunctionDefinition> Tools { get; set; }

		[JsonPropertyName("tool_choice")]
		public string ToolChoice { get; set; }

		[JsonPropertyName("temperature")]
		public double Temperature { get; set; }

		[JsonPropertyName("max_output_tokens")]
		public MaxOutputTokens? MaxOutputTokens { get; set; }
	}
	public class ConversationCreatedEvent : EventBase
	{
		[JsonPropertyName("conversation")]
		public ConversationResource Conversation { get; set; }
	}
	public class ConversationResource
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("object")]
		public string Object { get; set; } = "realtime.conversation";
	}
	public class ConversationItemCreatedEvent : EventBase
	{
		[JsonPropertyName("previous_item_id")]
		public string? PreviousItemId { get; set; }

		[JsonPropertyName("item")]
		public ConversationItem Item { get; set; }
	}
	public class InputAudioTranscriptionCompletedEvent : EventBase
	{
		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		[JsonPropertyName("content_index")]
		public int ContentIndex { get; set; }

		[JsonPropertyName("transcript")]
		public string Transcript { get; set; }
	}
	public class InputAudioTranscriptionFailedEvent : EventBase
	{
		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		[JsonPropertyName("content_index")]
		public int ContentIndex { get; set; }

		[JsonPropertyName("error")]
		public Error Error { get; set; }
	}
	public class ConversationItemTruncatedEvent : EventBase
	{
		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		[JsonPropertyName("content_index")]
		public int ContentIndex { get; set; }

		[JsonPropertyName("audio_end_ms")]
		public int AudioEndMs { get; set; }
	}
	public class ConversationItemDeletedEvent : EventBase
	{
		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }
	}
	public class AudioBufferCommittedEvent : EventBase
	{
		[JsonPropertyName("previous_item_id")]
		public string PreviousItemId { get; set; }

		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }
	}
	public class AudioBufferClearedEvent : EventBase
	{
	}
	public class AudioBufferSpeechStartedEvent : EventBase
	{
		[JsonPropertyName("audio_start_ms")]
		public int AudioStartMs { get; set; }

		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }
	}
	public class AudioBufferSpeechStoppedEvent : EventBase
	{
		[JsonPropertyName("audio_end_ms")]
		public int AudioEndMs { get; set; }

		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }
	}
	public class ResponseEvent : EventBase
	{
		[JsonPropertyName("response")]
		public ResponseResource Response { get; set; }
	}
	public class ResponseResource
	{
		[JsonPropertyName("id")]
		public string Id { get; set; }

		[JsonPropertyName("object")]
		public string Object { get; set; } = "realtime.response";

		[JsonPropertyName("status")]
		public Status Status { get; set; }

		[JsonPropertyName("status_details")]
		public Dictionary<string, string>? StatusDetails { get; set; }

		[JsonPropertyName("output")]
		public List<ConversationItem> Output { get; set; }

		[JsonPropertyName("usage")]
		public UsageResponse? Usage { get; set; }
	}
	public class ResponseOutputItemAddedEvent : EventBase
	{
		[JsonPropertyName("response_id")]
		public string ResponseId { get; set; }

		[JsonPropertyName("output_index")]
		public int OutputIndex { get; set; }

		[JsonPropertyName("item")]
		public ConversationItem Item { get; set; }
	}
	public class ResponseOutputItemDoneEvent : EventBase
	{
		[JsonPropertyName("response_id")]
		public string ResponseId { get; set; }

		[JsonPropertyName("output_index")]
		public int OutputIndex { get; set; }

		[JsonPropertyName("item")]
		public ConversationItem Item { get; set; }
	}
	public class ResponseContentPartEvent : EventBase
	{
		[JsonPropertyName("response_id")]
		public string ResponseId { get; set; }

		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		[JsonPropertyName("output_index")]
		public int OutputIndex { get; set; }

		[JsonPropertyName("content_index")]
		public int ContentIndex { get; set; }

		[JsonPropertyName("part")]
		public ContentPart Part { get; set; }
	}
	public abstract class ContentStreamEventBase : EventBase
	{
		[JsonPropertyName("response_id")]
		public string ResponseId { get; set; }

		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		[JsonPropertyName("output_index")]
		public int OutputIndex { get; set; }

		[JsonPropertyName("content_index")]
		public int ContentIndex { get; set; }
	}
	public class TextStreamEvent : ContentStreamEventBase
	{
		[JsonPropertyName("delta")]
		public string? Delta { get; set; }

		[JsonPropertyName("text")]
		public string? Text { get; set; }
	}
	public class AudioTranscriptStreamEvent : ContentStreamEventBase
	{
		[JsonPropertyName("delta")]
		public string? Delta { get; set; }

		[JsonPropertyName("transcript")]
		public string? Transcript { get; set; }
	}
	public class AudioStreamEvent : ContentStreamEventBase
	{
		[JsonPropertyName("delta")]
		public string? Delta { get; set; }
	}
	public class FunctionCallStreamEvent : EventBase
	{
		[JsonPropertyName("response_id")]
		public string ResponseId { get; set; }

		[JsonPropertyName("item_id")]
		public string ItemId { get; set; }

		[JsonPropertyName("output_index")]
		public int OutputIndex { get; set; }

		[JsonPropertyName("call_id")]
		public string CallId { get; set; }

		[JsonPropertyName("delta")]
		public string? Delta { get; set; }

		[JsonPropertyName("arguments")]
		public string? Arguments { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }
	}
	public class RateLimitsEvent : EventBase
	{
		[JsonPropertyName("rate_limits")]
		public List<RateLimit> RateLimits { get; set; }
	}
	public class RateLimit
	{
		[JsonPropertyName("name")]
		public string Name { get; set; }

		[JsonPropertyName("limit")]
		public int Limit { get; set; }

		[JsonPropertyName("remaining")]
		public int Remaining { get; set; }

		[JsonPropertyName("reset_seconds")]
		public double ResetSeconds { get; set; }
	}
	[JsonConverter(typeof(MaxOutputTokensConverter))]
	public class MaxOutputTokens
	{
		private readonly bool _isInfinite;

		private readonly int? _value;

		public int? Value => _value;

		public bool IsInfinite => _isInfinite;

		private MaxOutputTokens(int? value, bool isInfinite)
		{
			_value = value;
			_isInfinite = isInfinite;
		}

		public static MaxOutputTokens FromInt(int value)
		{
			return new MaxOutputTokens(value, isInfinite: false);
		}

		public static MaxOutputTokens Infinite()
		{
			return new MaxOutputTokens(null, isInfinite: true);
		}

		public override string ToString()
		{
			string text;
			if (!IsInfinite)
			{
				text = Value?.ToString();
				if (text == null)
				{
					return "";
				}
			}
			else
			{
				text = "inf";
			}
			return text;
		}
	}
	public class MaxOutputTokensConverter : JsonConverter<MaxOutputTokens>
	{
		public override MaxOutputTokens Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			switch (reader.TokenType)
			{
			case JsonTokenType.String:
				if (reader.GetString() == "inf")
				{
					return MaxOutputTokens.Infinite();
				}
				break;
			case JsonTokenType.Number:
				return MaxOutputTokens.FromInt(reader.GetInt32());
			}
			throw new JsonException("Value must be an integer or 'inf'");
		}

		public override void Write(Utf8JsonWriter writer, MaxOutputTokens value, JsonSerializerOptions options)
		{
			if (value.IsInfinite)
			{
				writer.WriteStringValue("inf");
			}
			else if (value.Value.HasValue)
			{
				writer.WriteNumberValue(value.Value.Value);
			}
			else
			{
				writer.WriteNullValue();
			}
		}
	}
	[JsonSerializable(typeof(ErrorEvent))]
	[JsonSerializable(typeof(SessionEvent))]
	[JsonSerializable(typeof(ConversationCreatedEvent))]
	[JsonSerializable(typeof(ConversationItemCreatedEvent))]
	[JsonSerializable(typeof(InputAudioTranscriptionCompletedEvent))]
	[JsonSerializable(typeof(InputAudioTranscriptionFailedEvent))]
	[JsonSerializable(typeof(ConversationItemTruncatedEvent))]
	[JsonSerializable(typeof(ConversationItemDeletedEvent))]
	[JsonSerializable(typeof(AudioBufferCommittedEvent))]
	[JsonSerializable(typeof(AudioBufferClearedEvent))]
	[JsonSerializable(typeof(AudioBufferSpeechStartedEvent))]
	[JsonSerializable(typeof(AudioBufferSpeechStoppedEvent))]
	[JsonSerializable(typeof(ResponseEvent))]
	[JsonSerializable(typeof(ResponseOutputItemAddedEvent))]
	[JsonSerializable(typeof(ResponseOutputItemDoneEvent))]
	[JsonSerializable(typeof(ResponseContentPartEvent))]
	[JsonSerializable(typeof(TextStreamEvent))]
	[JsonSerializable(typeof(AudioTranscriptStreamEvent))]
	[JsonSerializable(typeof(AudioStreamEvent))]
	[JsonSerializable(typeof(FunctionCallStreamEvent))]
	[JsonSerializable(typeof(RateLimitsEvent))]
	[JsonSerializable(typeof(SessionUpdateRequest))]
	[JsonSerializable(typeof(AudioBufferAppendRequest))]
	[JsonSerializable(typeof(AudioBufferCommitRequest))]
	[JsonSerializable(typeof(AudioBufferClearRequest))]
	[JsonSerializable(typeof(ConversationItemCreateRequest))]
	[JsonSerializable(typeof(ConversationItemTruncateRequest))]
	[JsonSerializable(typeof(ConversationItemDeleteRequest))]
	[JsonSerializable(typeof(ResponseCreateRequest))]
	[JsonSerializable(typeof(ResponseCancelRequest))]
	[JsonSerializable(typeof(ResponseConfig))]
	[JsonSerializable(typeof(SessionConfig))]
	[JsonSerializable(typeof(AudioTranscriptionConfig))]
	[JsonSerializable(typeof(TurnDetectionConfig))]
	[JsonSerializable(typeof(JsonSchema))]
	[JsonSerializable(typeof(JsonSchemaProperty))]
	[JsonSerializable(typeof(ConversationItem))]
	[JsonSerializable(typeof(ContentPart))]
	[JsonSerializable(typeof(SessionResource))]
	[JsonSerializable(typeof(ConversationResource))]
	[JsonSerializable(typeof(ResponseResource))]
	[JsonSerializable(typeof(RateLimit))]
	[JsonSerializable(typeof(MaxOutputTokens))]
	[JsonSerializable(typeof(AudioFormat))]
	[JsonSerializable(typeof(Status))]
	[JsonSerializable(typeof(ContentType))]
	[JsonSerializable(typeof(ItemType))]
	[JsonSerializable(typeof(Role))]
	[JsonSerializable(typeof(List<string>))]
	[JsonSerializable(typeof(List<ContentPart>))]
	[JsonSerializable(typeof(List<FunctionDefinition>))]
	[JsonSerializable(typeof(List<ConversationItem>))]
	[JsonSerializable(typeof(List<RateLimit>))]
	[JsonSerializable(typeof(Dictionary<string, JsonSchemaProperty>))]
	[JsonSerializable(typeof(Dictionary<string, string>))]
	[JsonSourceGenerationOptions(WriteIndented = false, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, AllowTrailingCommas = false, PropertyNameCaseInsensitive = false, ReadCommentHandling = JsonCommentHandling.Skip)]
	[GeneratedCode("System.Text.Json.SourceGeneration", "9.0.12.31616")]
	internal class RealtimeServiceJsonContext : JsonSerializerContext, IJsonTypeInfoResolver
	{
		private JsonTypeInfo<bool>? _Boolean;

		private JsonTypeInfo<bool?>? _NullableBoolean;

		private JsonTypeInfo<double>? _Double;

		private JsonTypeInfo<double?>? _NullableDouble;

		private JsonTypeInfo<float>? _Single;

		private JsonTypeInfo<float?>? _NullableSingle;

		private JsonTypeInfo<AudioBufferAppendRequest>? _AudioBufferAppendRequest;

		private JsonTypeInfo<AudioBufferClearedEvent>? _AudioBufferClearedEvent;

		private JsonTypeInfo<AudioBufferClearRequest>? _AudioBufferClearRequest;

		private JsonTypeInfo<AudioBufferCommitRequest>? _AudioBufferCommitRequest;

		private JsonTypeInfo<AudioBufferCommittedEvent>? _AudioBufferCommittedEvent;

		private JsonTypeInfo<AudioBufferSpeechStartedEvent>? _AudioBufferSpeechStartedEvent;

		private JsonTypeInfo<AudioBufferSpeechStoppedEvent>? _AudioBufferSpeechStoppedEvent;

		private JsonTypeInfo<AudioFormat>? _AudioFormat;

		private JsonTypeInfo<AudioFormat?>? _NullableAudioFormat;

		private JsonTypeInfo<AudioStreamEvent>? _AudioStreamEvent;

		private JsonTypeInfo<AudioTranscriptionConfig>? _AudioTranscriptionConfig;

		private JsonTypeInfo<AudioTranscriptStreamEvent>? _AudioTranscriptStreamEvent;

		private JsonTypeInfo<ContentPart>? _ContentPart;

		private JsonTypeInfo<ContentType>? _ContentType;

		private JsonTypeInfo<ConversationCreatedEvent>? _ConversationCreatedEvent;

		private JsonTypeInfo<ConversationItem>? _ConversationItem;

		private JsonTypeInfo<ConversationItemCreatedEvent>? _ConversationItemCreatedEvent;

		private JsonTypeInfo<ConversationItemCreateRequest>? _ConversationItemCreateRequest;

		private JsonTypeInfo<ConversationItemDeletedEvent>? _ConversationItemDeletedEvent;

		private JsonTypeInfo<ConversationItemDeleteRequest>? _ConversationItemDeleteRequest;

		private JsonTypeInfo<ConversationItemTruncatedEvent>? _ConversationItemTruncatedEvent;

		private JsonTypeInfo<ConversationItemTruncateRequest>? _ConversationItemTruncateRequest;

		private JsonTypeInfo<ConversationResource>? _ConversationResource;

		private JsonTypeInfo<ErrorEvent>? _ErrorEvent;

		private JsonTypeInfo<FunctionCallStreamEvent>? _FunctionCallStreamEvent;

		private JsonTypeInfo<InputAudioTranscriptionCompletedEvent>? _InputAudioTranscriptionCompletedEvent;

		private JsonTypeInfo<InputAudioTranscriptionFailedEvent>? _InputAudioTranscriptionFailedEvent;

		private JsonTypeInfo<ItemType>? _ItemType;

		private JsonTypeInfo<JsonSchema>? _JsonSchema;

		private JsonTypeInfo<JsonSchemaProperty>? _JsonSchemaProperty;

		private JsonTypeInfo<MaxOutputTokens>? _MaxOutputTokens;

		private JsonTypeInfo<RateLimit>? _RateLimit;

		private JsonTypeInfo<RateLimitsEvent>? _RateLimitsEvent;

		private JsonTypeInfo<RealtimeToolDefinition>? _RealtimeToolDefinition;

		private JsonTypeInfo<ResponseCancelRequest>? _ResponseCancelRequest;

		private JsonTypeInfo<ResponseConfig>? _ResponseConfig;

		private JsonTypeInfo<ResponseContentPartEvent>? _ResponseContentPartEvent;

		private JsonTypeInfo<ResponseCreateRequest>? _ResponseCreateRequest;

		private JsonTypeInfo<ResponseEvent>? _ResponseEvent;

		private JsonTypeInfo<ResponseOutputItemAddedEvent>? _ResponseOutputItemAddedEvent;

		private JsonTypeInfo<ResponseOutputItemDoneEvent>? _ResponseOutputItemDoneEvent;

		private JsonTypeInfo<ResponseResource>? _ResponseResource;

		private JsonTypeInfo<Role>? _Role;

		private JsonTypeInfo<Role?>? _NullableRole;

		private JsonTypeInfo<SessionConfig>? _SessionConfig;

		private JsonTypeInfo<SessionEvent>? _SessionEvent;

		private JsonTypeInfo<SessionResource>? _SessionResource;

		private JsonTypeInfo<SessionUpdateRequest>? _SessionUpdateRequest;

		private JsonTypeInfo<Status>? _Status;

		private JsonTypeInfo<Status?>? _NullableStatus;

		private JsonTypeInfo<TextStreamEvent>? _TextStreamEvent;

		private JsonTypeInfo<TurnDetectionConfig>? _TurnDetectionConfig;

		private JsonTypeInfo<FunctionDefinition>? _FunctionDefinition;

		private JsonTypeInfo<CompletionTokensDetails>? _CompletionTokensDetails;

		private JsonTypeInfo<Error>? _Error;

		private JsonTypeInfo<PromptTokensDetails>? _PromptTokensDetails;

		private JsonTypeInfo<UsageResponse>? _UsageResponse;

		private JsonTypeInfo<PropertyDefinition>? _PropertyDefinition;

		private JsonTypeInfo<Dictionary<string, JsonSchemaProperty>>? _DictionaryStringJsonSchemaProperty;

		private JsonTypeInfo<Dictionary<string, string>>? _DictionaryStringString;

		private JsonTypeInfo<IDictionary<string, PropertyDefinition>>? _IDictionaryStringPropertyDefinition;

		private JsonTypeInfo<IList<PropertyDefinition>>? _IListPropertyDefinition;

		private JsonTypeInfo<IList<string>>? _IListString;

		private JsonTypeInfo<List<ContentPart>>? _ListContentPart;

		private JsonTypeInfo<List<ConversationItem>>? _ListConversationItem;

		private JsonTypeInfo<List<RateLimit>>? _ListRateLimit;

		private JsonTypeInfo<List<RealtimeToolDefinition>>? _ListRealtimeToolDefinition;

		private JsonTypeInfo<List<FunctionDefinition>>? _ListFunctionDefinition;

		private JsonTypeInfo<List<string>>? _ListString;

		private JsonTypeInfo<int>? _Int32;

		private JsonTypeInfo<int?>? _NullableInt32;

		private JsonTypeInfo<object>? _Object;

		private JsonTypeInfo<string>? _String;

		private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions
		{
			AllowTrailingCommas = false,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			PropertyNameCaseInsensitive = false,
			ReadCommentHandling = JsonCommentHandling.Skip,
			WriteIndented = false
		};

		private const BindingFlags InstanceMemberBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		private static readonly JsonEncodedText PropName_audio = JsonEncodedText.Encode("audio");

		private static readonly JsonEncodedText PropName_event_id = JsonEncodedText.Encode("event_id");

		private static readonly JsonEncodedText PropName_type = JsonEncodedText.Encode("type");

		private static readonly JsonEncodedText PropName_previous_item_id = JsonEncodedText.Encode("previous_item_id");

		private static readonly JsonEncodedText PropName_item_id = JsonEncodedText.Encode("item_id");

		private static readonly JsonEncodedText PropName_audio_start_ms = JsonEncodedText.Encode("audio_start_ms");

		private static readonly JsonEncodedText PropName_audio_end_ms = JsonEncodedText.Encode("audio_end_ms");

		private static readonly JsonEncodedText PropName_delta = JsonEncodedText.Encode("delta");

		private static readonly JsonEncodedText PropName_response_id = JsonEncodedText.Encode("response_id");

		private static readonly JsonEncodedText PropName_output_index = JsonEncodedText.Encode("output_index");

		private static readonly JsonEncodedText PropName_content_index = JsonEncodedText.Encode("content_index");

		private static readonly JsonEncodedText PropName_model = JsonEncodedText.Encode("model");

		private static readonly JsonEncodedText PropName_transcript = JsonEncodedText.Encode("transcript");

		private static readonly JsonEncodedText PropName_text = JsonEncodedText.Encode("text");

		private static readonly JsonEncodedText PropName_conversation = JsonEncodedText.Encode("conversation");

		private static readonly JsonEncodedText PropName_id = JsonEncodedText.Encode("id");

		private static readonly JsonEncodedText PropName_status = JsonEncodedText.Encode("status");

		private static readonly JsonEncodedText PropName_role = JsonEncodedText.Encode("role");

		private static readonly JsonEncodedText PropName_content = JsonEncodedText.Encode("content");

		private static readonly JsonEncodedText PropName_call_id = JsonEncodedText.Encode("call_id");

		private static readonly JsonEncodedText PropName_name = JsonEncodedText.Encode("name");

		private static readonly JsonEncodedText PropName_arguments = JsonEncodedText.Encode("arguments");

		private static readonly JsonEncodedText PropName_output = JsonEncodedText.Encode("output");

		private static readonly JsonEncodedText PropName_item = JsonEncodedText.Encode("item");

		private static readonly JsonEncodedText PropName_object = JsonEncodedText.Encode("object");

		private static readonly JsonEncodedText PropName_error = JsonEncodedText.Encode("error");

		private static readonly JsonEncodedText PropName_properties = JsonEncodedText.Encode("properties");

		private static readonly JsonEncodedText PropName_required = JsonEncodedText.Encode("required");

		private static readonly JsonEncodedText PropName_description = JsonEncodedText.Encode("description");

		private static readonly JsonEncodedText PropName_limit = JsonEncodedText.Encode("limit");

		private static readonly JsonEncodedText PropName_remaining = JsonEncodedText.Encode("remaining");

		private static readonly JsonEncodedText PropName_reset_seconds = JsonEncodedText.Encode("reset_seconds");

		private static readonly JsonEncodedText PropName_rate_limits = JsonEncodedText.Encode("rate_limits");

		private static readonly JsonEncodedText PropName_parameters = JsonEncodedText.Encode("parameters");

		private static readonly JsonEncodedText PropName_modalities = JsonEncodedText.Encode("modalities");

		private static readonly JsonEncodedText PropName_instructions = JsonEncodedText.Encode("instructions");

		private static readonly JsonEncodedText PropName_voice = JsonEncodedText.Encode("voice");

		private static readonly JsonEncodedText PropName_output_audio_format = JsonEncodedText.Encode("output_audio_format");

		private static readonly JsonEncodedText PropName_tools = JsonEncodedText.Encode("tools");

		private static readonly JsonEncodedText PropName_tool_choice = JsonEncodedText.Encode("tool_choice");

		private static readonly JsonEncodedText PropName_temperature = JsonEncodedText.Encode("temperature");

		private static readonly JsonEncodedText PropName_max_output_tokens = JsonEncodedText.Encode("max_output_tokens");

		private static readonly JsonEncodedText PropName_part = JsonEncodedText.Encode("part");

		private static readonly JsonEncodedText PropName_response = JsonEncodedText.Encode("response");

		private static readonly JsonEncodedText PropName_status_details = JsonEncodedText.Encode("status_details");

		private static readonly JsonEncodedText PropName_usage = JsonEncodedText.Encode("usage");

		private static readonly JsonEncodedText PropName_input_audio_format = JsonEncodedText.Encode("input_audio_format");

		private static readonly JsonEncodedText PropName_input_audio_transcription = JsonEncodedText.Encode("input_audio_transcription");

		private static readonly JsonEncodedText PropName_turn_detection = JsonEncodedText.Encode("turn_detection");

		private static readonly JsonEncodedText PropName_session = JsonEncodedText.Encode("session");

		private static readonly JsonEncodedText PropName_threshold = JsonEncodedText.Encode("threshold");

		private static readonly JsonEncodedText PropName_prefix_padding_ms = JsonEncodedText.Encode("prefix_padding_ms");

		private static readonly JsonEncodedText PropName_silence_duration_ms = JsonEncodedText.Encode("silence_duration_ms");

		private static readonly JsonEncodedText PropName_strict = JsonEncodedText.Encode("strict");

		private static readonly JsonEncodedText PropName_reasoning_tokens = JsonEncodedText.Encode("reasoning_tokens");

		private static readonly JsonEncodedText PropName_audio_tokens = JsonEncodedText.Encode("audio_tokens");

		private static readonly JsonEncodedText PropName_cached_tokens = JsonEncodedText.Encode("cached_tokens");

		private static readonly JsonEncodedText PropName_prompt_tokens = JsonEncodedText.Encode("prompt_tokens");

		private static readonly JsonEncodedText PropName_completion_tokens = JsonEncodedText.Encode("completion_tokens");

		private static readonly JsonEncodedText PropName_total_tokens = JsonEncodedText.Encode("total_tokens");

		private static readonly JsonEncodedText PropName_completion_tokens_details = JsonEncodedText.Encode("completion_tokens_details");

		private static readonly JsonEncodedText PropName_prompt_tokens_details = JsonEncodedText.Encode("prompt_tokens_details");

		public JsonTypeInfo<bool> Boolean => _Boolean ?? (_Boolean = (JsonTypeInfo<bool>)Options.GetTypeInfo(typeof(bool)));

		public JsonTypeInfo<bool?> NullableBoolean => _NullableBoolean ?? (_NullableBoolean = (JsonTypeInfo<bool?>)Options.GetTypeInfo(typeof(bool?)));

		public JsonTypeInfo<double> Double => _Double ?? (_Double = (JsonTypeInfo<double>)Options.GetTypeInfo(typeof(double)));

		public JsonTypeInfo<double?> NullableDouble => _NullableDouble ?? (_NullableDouble = (JsonTypeInfo<double?>)Options.GetTypeInfo(typeof(double?)));

		public JsonTypeInfo<float> Single => _Single ?? (_Single = (JsonTypeInfo<float>)Options.GetTypeInfo(typeof(float)));

		public JsonTypeInfo<float?> NullableSingle => _NullableSingle ?? (_NullableSingle = (JsonTypeInfo<float?>)Options.GetTypeInfo(typeof(float?)));

		public JsonTypeInfo<AudioBufferAppendRequest> AudioBufferAppendRequest => _AudioBufferAppendRequest ?? (_AudioBufferAppendRequest = (JsonTypeInfo<AudioBufferAppendRequest>)Options.GetTypeInfo(typeof(AudioBufferAppendRequest)));

		public JsonTypeInfo<AudioBufferClearedEvent> AudioBufferClearedEvent => _AudioBufferClearedEvent ?? (_AudioBufferClearedEvent = (JsonTypeInfo<AudioBufferClearedEvent>)Options.GetTypeInfo(typeof(AudioBufferClearedEvent)));

		public JsonTypeInfo<AudioBufferClearRequest> AudioBufferClearRequest => _AudioBufferClearRequest ?? (_AudioBufferClearRequest = (JsonTypeInfo<AudioBufferClearRequest>)Options.GetTypeInfo(typeof(AudioBufferClearRequest)));

		public JsonTypeInfo<AudioBufferCommitRequest> AudioBufferCommitRequest => _AudioBufferCommitRequest ?? (_AudioBufferCommitRequest = (JsonTypeInfo<AudioBufferCommitRequest>)Options.GetTypeInfo(typeof(AudioBufferCommitRequest)));

		public JsonTypeInfo<AudioBufferCommittedEvent> AudioBufferCommittedEvent => _AudioBufferCommittedEvent ?? (_AudioBufferCommittedEvent = (JsonTypeInfo<AudioBufferCommittedEvent>)Options.GetTypeInfo(typeof(AudioBufferCommittedEvent)));

		public JsonTypeInfo<AudioBufferSpeechStartedEvent> AudioBufferSpeechStartedEvent => _AudioBufferSpeechStartedEvent ?? (_AudioBufferSpeechStartedEvent = (JsonTypeInfo<AudioBufferSpeechStartedEvent>)Options.GetTypeInfo(typeof(AudioBufferSpeechStartedEvent)));

		public JsonTypeInfo<AudioBufferSpeechStoppedEvent> AudioBufferSpeechStoppedEvent => _AudioBufferSpeechStoppedEvent ?? (_AudioBufferSpeechStoppedEvent = (JsonTypeInfo<AudioBufferSpeechStoppedEvent>)Options.GetTypeInfo(typeof(AudioBufferSpeechStoppedEvent)));

		public JsonTypeInfo<AudioFormat> AudioFormat => _AudioFormat ?? (_AudioFormat = (JsonTypeInfo<AudioFormat>)Options.GetTypeInfo(typeof(AudioFormat)));

		public JsonTypeInfo<AudioFormat?> NullableAudioFormat => _NullableAudioFormat ?? (_NullableAudioFormat = (JsonTypeInfo<AudioFormat?>)Options.GetTypeInfo(typeof(AudioFormat?)));

		public JsonTypeInfo<AudioStreamEvent> AudioStreamEvent => _AudioStreamEvent ?? (_AudioStreamEvent = (JsonTypeInfo<AudioStreamEvent>)Options.GetTypeInfo(typeof(AudioStreamEvent)));

		public JsonTypeInfo<AudioTranscriptionConfig> AudioTranscriptionConfig => _AudioTranscriptionConfig ?? (_AudioTranscriptionConfig = (JsonTypeInfo<AudioTranscriptionConfig>)Options.GetTypeInfo(typeof(AudioTranscriptionConfig)));

		public JsonTypeInfo<AudioTranscriptStreamEvent> AudioTranscriptStreamEvent => _AudioTranscriptStreamEvent ?? (_AudioTranscriptStreamEvent = (JsonTypeInfo<AudioTranscriptStreamEvent>)Options.GetTypeInfo(typeof(AudioTranscriptStreamEvent)));

		public JsonTypeInfo<ContentPart> ContentPart => _ContentPart ?? (_ContentPart = (JsonTypeInfo<ContentPart>)Options.GetTypeInfo(typeof(ContentPart)));

		public JsonTypeInfo<ContentType> ContentType => _ContentType ?? (_ContentType = (JsonTypeInfo<ContentType>)Options.GetTypeInfo(typeof(ContentType)));

		public JsonTypeInfo<ConversationCreatedEvent> ConversationCreatedEvent => _ConversationCreatedEvent ?? (_ConversationCreatedEvent = (JsonTypeInfo<ConversationCreatedEvent>)Options.GetTypeInfo(typeof(ConversationCreatedEvent)));

		public JsonTypeInfo<ConversationItem> ConversationItem => _ConversationItem ?? (_ConversationItem = (JsonTypeInfo<ConversationItem>)Options.GetTypeInfo(typeof(ConversationItem)));

		public JsonTypeInfo<ConversationItemCreatedEvent> ConversationItemCreatedEvent => _ConversationItemCreatedEvent ?? (_ConversationItemCreatedEvent = (JsonTypeInfo<ConversationItemCreatedEvent>)Options.GetTypeInfo(typeof(ConversationItemCreatedEvent)));

		public JsonTypeInfo<ConversationItemCreateRequest> ConversationItemCreateRequest => _ConversationItemCreateRequest ?? (_ConversationItemCreateRequest = (JsonTypeInfo<ConversationItemCreateRequest>)Options.GetTypeInfo(typeof(ConversationItemCreateRequest)));

		public JsonTypeInfo<ConversationItemDeletedEvent> ConversationItemDeletedEvent => _ConversationItemDeletedEvent ?? (_ConversationItemDeletedEvent = (JsonTypeInfo<ConversationItemDeletedEvent>)Options.GetTypeInfo(typeof(ConversationItemDeletedEvent)));

		public JsonTypeInfo<ConversationItemDeleteRequest> ConversationItemDeleteRequest => _ConversationItemDeleteRequest ?? (_ConversationItemDeleteRequest = (JsonTypeInfo<ConversationItemDeleteRequest>)Options.GetTypeInfo(typeof(ConversationItemDeleteRequest)));

		public JsonTypeInfo<ConversationItemTruncatedEvent> ConversationItemTruncatedEvent => _ConversationItemTruncatedEvent ?? (_ConversationItemTruncatedEvent = (JsonTypeInfo<ConversationItemTruncatedEvent>)Options.GetTypeInfo(typeof(ConversationItemTruncatedEvent)));

		public JsonTypeInfo<ConversationItemTruncateRequest> ConversationItemTruncateRequest => _ConversationItemTruncateRequest ?? (_ConversationItemTruncateRequest = (JsonTypeInfo<ConversationItemTruncateRequest>)Options.GetTypeInfo(typeof(ConversationItemTruncateRequest)));

		public JsonTypeInfo<ConversationResource> ConversationResource => _ConversationResource ?? (_ConversationResource = (JsonTypeInfo<ConversationResource>)Options.GetTypeInfo(typeof(ConversationResource)));

		public JsonTypeInfo<ErrorEvent> ErrorEvent => _ErrorEvent ?? (_ErrorEvent = (JsonTypeInfo<ErrorEvent>)Options.GetTypeInfo(typeof(ErrorEvent)));

		public JsonTypeInfo<FunctionCallStreamEvent> FunctionCallStreamEvent => _FunctionCallStreamEvent ?? (_FunctionCallStreamEvent = (JsonTypeInfo<FunctionCallStreamEvent>)Options.GetTypeInfo(typeof(FunctionCallStreamEvent)));

		public JsonTypeInfo<InputAudioTranscriptionCompletedEvent> InputAudioTranscriptionCompletedEvent => _InputAudioTranscriptionCompletedEvent ?? (_InputAudioTranscriptionCompletedEvent = (JsonTypeInfo<InputAudioTranscriptionCompletedEvent>)Options.GetTypeInfo(typeof(InputAudioTranscriptionCompletedEvent)));

		public JsonTypeInfo<InputAudioTranscriptionFailedEvent> InputAudioTranscriptionFailedEvent => _InputAudioTranscriptionFailedEvent ?? (_InputAudioTranscriptionFailedEvent = (JsonTypeInfo<InputAudioTranscriptionFailedEvent>)Options.GetTypeInfo(typeof(InputAudioTranscriptionFailedEvent)));

		public JsonTypeInfo<ItemType> ItemType => _ItemType ?? (_ItemType = (JsonTypeInfo<ItemType>)Options.GetTypeInfo(typeof(ItemType)));

		public JsonTypeInfo<JsonSchema> JsonSchema => _JsonSchema ?? (_JsonSchema = (JsonTypeInfo<JsonSchema>)Options.GetTypeInfo(typeof(JsonSchema)));

		public JsonTypeInfo<JsonSchemaProperty> JsonSchemaProperty => _JsonSchemaProperty ?? (_JsonSchemaProperty = (JsonTypeInfo<JsonSchemaProperty>)Options.GetTypeInfo(typeof(JsonSchemaProperty)));

		public JsonTypeInfo<MaxOutputTokens> MaxOutputTokens => _MaxOutputTokens ?? (_MaxOutputTokens = (JsonTypeInfo<MaxOutputTokens>)Options.GetTypeInfo(typeof(MaxOutputTokens)));

		public JsonTypeInfo<RateLimit> RateLimit => _RateLimit ?? (_RateLimit = (JsonTypeInfo<RateLimit>)Options.GetTypeInfo(typeof(RateLimit)));

		public JsonTypeInfo<RateLimitsEvent> RateLimitsEvent => _RateLimitsEvent ?? (_RateLimitsEvent = (JsonTypeInfo<RateLimitsEvent>)Options.GetTypeInfo(typeof(RateLimitsEvent)));

		public JsonTypeInfo<RealtimeToolDefinition> RealtimeToolDefinition => _RealtimeToolDefinition ?? (_RealtimeToolDefinition = (JsonTypeInfo<RealtimeToolDefinition>)Options.GetTypeInfo(typeof(RealtimeToolDefinition)));

		public JsonTypeInfo<ResponseCancelRequest> ResponseCancelRequest => _ResponseCancelRequest ?? (_ResponseCancelRequest = (JsonTypeInfo<ResponseCancelRequest>)Options.GetTypeInfo(typeof(ResponseCancelRequest)));

		public JsonTypeInfo<ResponseConfig> ResponseConfig => _ResponseConfig ?? (_ResponseConfig = (JsonTypeInfo<ResponseConfig>)Options.GetTypeInfo(typeof(ResponseConfig)));

		public JsonTypeInfo<ResponseContentPartEvent> ResponseContentPartEvent => _ResponseContentPartEvent ?? (_ResponseContentPartEvent = (JsonTypeInfo<ResponseContentPartEvent>)Options.GetTypeInfo(typeof(ResponseContentPartEvent)));

		public JsonTypeInfo<ResponseCreateRequest> ResponseCreateRequest => _ResponseCreateRequest ?? (_ResponseCreateRequest = (JsonTypeInfo<ResponseCreateRequest>)Options.GetTypeInfo(typeof(ResponseCreateRequest)));

		public JsonTypeInfo<ResponseEvent> ResponseEvent => _ResponseEvent ?? (_ResponseEvent = (JsonTypeInfo<ResponseEvent>)Options.GetTypeInfo(typeof(ResponseEvent)));

		public JsonTypeInfo<ResponseOutputItemAddedEvent> ResponseOutputItemAddedEvent => _ResponseOutputItemAddedEvent ?? (_ResponseOutputItemAddedEvent = (JsonTypeInfo<ResponseOutputItemAddedEvent>)Options.GetTypeInfo(typeof(ResponseOutputItemAddedEvent)));

		public JsonTypeInfo<ResponseOutputItemDoneEvent> ResponseOutputItemDoneEvent => _ResponseOutputItemDoneEvent ?? (_ResponseOutputItemDoneEvent = (JsonTypeInfo<ResponseOutputItemDoneEvent>)Options.GetTypeInfo(typeof(ResponseOutputItemDoneEvent)));

		public JsonTypeInfo<ResponseResource> ResponseResource => _ResponseResource ?? (_ResponseResource = (JsonTypeInfo<ResponseResource>)Options.GetTypeInfo(typeof(ResponseResource)));

		public JsonTypeInfo<Role> Role => _Role ?? (_Role = (JsonTypeInfo<Role>)Options.GetTypeInfo(typeof(Role)));

		public JsonTypeInfo<Role?> NullableRole => _NullableRole ?? (_NullableRole = (JsonTypeInfo<Role?>)Options.GetTypeInfo(typeof(Role?)));

		public JsonTypeInfo<SessionConfig> SessionConfig => _SessionConfig ?? (_SessionConfig = (JsonTypeInfo<SessionConfig>)Options.GetTypeInfo(typeof(SessionConfig)));

		public JsonTypeInfo<SessionEvent> SessionEvent => _SessionEvent ?? (_SessionEvent = (JsonTypeInfo<SessionEvent>)Options.GetTypeInfo(typeof(SessionEvent)));

		public JsonTypeInfo<SessionResource> SessionResource => _SessionResource ?? (_SessionResource = (JsonTypeInfo<SessionResource>)Options.GetTypeInfo(typeof(SessionResource)));

		public JsonTypeInfo<SessionUpdateRequest> SessionUpdateRequest => _SessionUpdateRequest ?? (_SessionUpdateRequest = (JsonTypeInfo<SessionUpdateRequest>)Options.GetTypeInfo(typeof(SessionUpdateRequest)));

		public JsonTypeInfo<Status> Status => _Status ?? (_Status = (JsonTypeInfo<Status>)Options.GetTypeInfo(typeof(Status)));

		public JsonTypeInfo<Status?> NullableStatus => _NullableStatus ?? (_NullableStatus = (JsonTypeInfo<Status?>)Options.GetTypeInfo(typeof(Status?)));

		public JsonTypeInfo<TextStreamEvent> TextStreamEvent => _TextStreamEvent ?? (_TextStreamEvent = (JsonTypeInfo<TextStreamEvent>)Options.GetTypeInfo(typeof(TextStreamEvent)));

		public JsonTypeInfo<TurnDetectionConfig> TurnDetectionConfig => _TurnDetectionConfig ?? (_TurnDetectionConfig = (JsonTypeInfo<TurnDetectionConfig>)Options.GetTypeInfo(typeof(TurnDetectionConfig)));

		public JsonTypeInfo<FunctionDefinition> FunctionDefinition => _FunctionDefinition ?? (_FunctionDefinition = (JsonTypeInfo<FunctionDefinition>)Options.GetTypeInfo(typeof(FunctionDefinition)));

		public JsonTypeInfo<CompletionTokensDetails> CompletionTokensDetails => _CompletionTokensDetails ?? (_CompletionTokensDetails = (JsonTypeInfo<CompletionTokensDetails>)Options.GetTypeInfo(typeof(CompletionTokensDetails)));

		public JsonTypeInfo<Error> Error => _Error ?? (_Error = (JsonTypeInfo<Error>)Options.GetTypeInfo(typeof(Error)));

		public JsonTypeInfo<PromptTokensDetails> PromptTokensDetails => _PromptTokensDetails ?? (_PromptTokensDetails = (JsonTypeInfo<PromptTokensDetails>)Options.GetTypeInfo(typeof(PromptTokensDetails)));

		public JsonTypeInfo<UsageResponse> UsageResponse => _UsageResponse ?? (_UsageResponse = (JsonTypeInfo<UsageResponse>)Options.GetTypeInfo(typeof(UsageResponse)));

		public JsonTypeInfo<PropertyDefinition> PropertyDefinition => _PropertyDefinition ?? (_PropertyDefinition = (JsonTypeInfo<PropertyDefinition>)Options.GetTypeInfo(typeof(PropertyDefinition)));

		public JsonTypeInfo<Dictionary<string, JsonSchemaProperty>> DictionaryStringJsonSchemaProperty => _DictionaryStringJsonSchemaProperty ?? (_DictionaryStringJsonSchemaProperty = (JsonTypeInfo<Dictionary<string, JsonSchemaProperty>>)Options.GetTypeInfo(typeof(Dictionary<string, JsonSchemaProperty>)));

		public JsonTypeInfo<Dictionary<string, string>> DictionaryStringString => _DictionaryStringString ?? (_DictionaryStringString = (JsonTypeInfo<Dictionary<string, string>>)Options.GetTypeInfo(typeof(Dictionary<string, string>)));

		public JsonTypeInfo<IDictionary<string, PropertyDefinition>> IDictionaryStringPropertyDefinition => _IDictionaryStringPropertyDefinition ?? (_IDictionaryStringPropertyDefinition = (JsonTypeInfo<IDictionary<string, PropertyDefinition>>)Options.GetTypeInfo(typeof(IDictionary<string, PropertyDefinition>)));

		public JsonTypeInfo<IList<PropertyDefinition>> IListPropertyDefinition => _IListPropertyDefinition ?? (_IListPropertyDefinition = (JsonTypeInfo<IList<PropertyDefinition>>)Options.GetTypeInfo(typeof(IList<PropertyDefinition>)));

		public JsonTypeInfo<IList<string>> IListString => _IListString ?? (_IListString = (JsonTypeInfo<IList<string>>)Options.GetTypeInfo(typeof(IList<string>)));

		public JsonTypeInfo<List<ContentPart>> ListContentPart => _ListContentPart ?? (_ListContentPart = (JsonTypeInfo<List<ContentPart>>)Options.GetTypeInfo(typeof(List<ContentPart>)));

		public JsonTypeInfo<List<ConversationItem>> ListConversationItem => _ListConversationItem ?? (_ListConversationItem = (JsonTypeInfo<List<ConversationItem>>)Options.GetTypeInfo(typeof(List<ConversationItem>)));

		public JsonTypeInfo<List<RateLimit>> ListRateLimit => _ListRateLimit ?? (_ListRateLimit = (JsonTypeInfo<List<RateLimit>>)Options.GetTypeInfo(typeof(List<RateLimit>)));

		public JsonTypeInfo<List<RealtimeToolDefinition>> ListRealtimeToolDefinition => _ListRealtimeToolDefinition ?? (_ListRealtimeToolDefinition = (JsonTypeInfo<List<RealtimeToolDefinition>>)Options.GetTypeInfo(typeof(List<RealtimeToolDefinition>)));

		public JsonTypeInfo<List<FunctionDefinition>> ListFunctionDefinition => _ListFunctionDefinition ?? (_ListFunctionDefinition = (JsonTypeInfo<List<FunctionDefinition>>)Options.GetTypeInfo(typeof(List<FunctionDefinition>)));

		public JsonTypeInfo<List<string>> ListString => _ListString ?? (_ListString = (JsonTypeInfo<List<string>>)Options.GetTypeInfo(typeof(List<string>)));

		public JsonTypeInfo<int> Int32 => _Int32 ?? (_Int32 = (JsonTypeInfo<int>)Options.GetTypeInfo(typeof(int)));

		public JsonTypeInfo<int?> NullableInt32 => _NullableInt32 ?? (_NullableInt32 = (JsonTypeInfo<int?>)Options.GetTypeInfo(typeof(int?)));

		public JsonTypeInfo<object> Object => _Object ?? (_Object = (JsonTypeInfo<object>)Options.GetTypeInfo(typeof(object)));

		public JsonTypeInfo<string> String => _String ?? (_String = (JsonTypeInfo<string>)Options.GetTypeInfo(typeof(string)));

		public static RealtimeServiceJsonContext Default { get; } = new RealtimeServiceJsonContext(new JsonSerializerOptions(s_defaultOptions));

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

		private JsonTypeInfo<AudioBufferAppendRequest> Create_AudioBufferAppendRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioBufferAppendRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioBufferAppendRequest> objectInfo = new JsonObjectInfoValues<AudioBufferAppendRequest>
				{
					ObjectCreator = () => new AudioBufferAppendRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioBufferAppendRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioBufferAppendRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioBufferAppendRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioBufferAppendRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioBufferAppendRequest),
				Converter = null,
				Getter = (object obj) => ((AudioBufferAppendRequest)obj).Audio,
				Setter = (object obj, string? value) =>
				{
					((AudioBufferAppendRequest)obj).Audio = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Audio",
				JsonPropertyName = "audio",
				AttributeProviderFactory = () => typeof(AudioBufferAppendRequest).GetProperty("Audio", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void AudioBufferAppendRequestSerializeHandler(Utf8JsonWriter writer, AudioBufferAppendRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string audio = value.Audio;
			if (audio != null)
			{
				writer.WriteString(PropName_audio, audio);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioBufferClearedEvent> Create_AudioBufferClearedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioBufferClearedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioBufferClearedEvent> objectInfo = new JsonObjectInfoValues<AudioBufferClearedEvent>
				{
					ObjectCreator = () => new AudioBufferClearedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioBufferClearedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioBufferClearedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioBufferClearedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioBufferClearedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		private void AudioBufferClearedEventSerializeHandler(Utf8JsonWriter writer, AudioBufferClearedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioBufferClearRequest> Create_AudioBufferClearRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioBufferClearRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioBufferClearRequest> objectInfo = new JsonObjectInfoValues<AudioBufferClearRequest>
				{
					ObjectCreator = () => new AudioBufferClearRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioBufferClearRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioBufferClearRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioBufferClearRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioBufferClearRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		private void AudioBufferClearRequestSerializeHandler(Utf8JsonWriter writer, AudioBufferClearRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioBufferCommitRequest> Create_AudioBufferCommitRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioBufferCommitRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioBufferCommitRequest> objectInfo = new JsonObjectInfoValues<AudioBufferCommitRequest>
				{
					ObjectCreator = () => new AudioBufferCommitRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioBufferCommitRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioBufferCommitRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioBufferCommitRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioBufferCommitRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		private void AudioBufferCommitRequestSerializeHandler(Utf8JsonWriter writer, AudioBufferCommitRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioBufferCommittedEvent> Create_AudioBufferCommittedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioBufferCommittedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioBufferCommittedEvent> objectInfo = new JsonObjectInfoValues<AudioBufferCommittedEvent>
				{
					ObjectCreator = () => new AudioBufferCommittedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioBufferCommittedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioBufferCommittedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioBufferCommittedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioBufferCommittedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioBufferCommittedEvent),
				Converter = null,
				Getter = (object obj) => ((AudioBufferCommittedEvent)obj).PreviousItemId,
				Setter = (object obj, string? value) =>
				{
					((AudioBufferCommittedEvent)obj).PreviousItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PreviousItemId",
				JsonPropertyName = "previous_item_id",
				AttributeProviderFactory = () => typeof(AudioBufferCommittedEvent).GetProperty("PreviousItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioBufferCommittedEvent),
				Converter = null,
				Getter = (object obj) => ((AudioBufferCommittedEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((AudioBufferCommittedEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(AudioBufferCommittedEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			return array;
		}

		private void AudioBufferCommittedEventSerializeHandler(Utf8JsonWriter writer, AudioBufferCommittedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string previousItemId = value.PreviousItemId;
			if (previousItemId != null)
			{
				writer.WriteString(PropName_previous_item_id, previousItemId);
			}
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioBufferSpeechStartedEvent> Create_AudioBufferSpeechStartedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioBufferSpeechStartedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioBufferSpeechStartedEvent> objectInfo = new JsonObjectInfoValues<AudioBufferSpeechStartedEvent>
				{
					ObjectCreator = () => new AudioBufferSpeechStartedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioBufferSpeechStartedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioBufferSpeechStartedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioBufferSpeechStartedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioBufferSpeechStartedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<int> propertyInfo = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioBufferSpeechStartedEvent),
				Converter = null,
				Getter = (object obj) => ((AudioBufferSpeechStartedEvent)obj).AudioStartMs,
				Setter = (object obj, int value) =>
				{
					((AudioBufferSpeechStartedEvent)obj).AudioStartMs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AudioStartMs",
				JsonPropertyName = "audio_start_ms",
				AttributeProviderFactory = () => typeof(AudioBufferSpeechStartedEvent).GetProperty("AudioStartMs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioBufferSpeechStartedEvent),
				Converter = null,
				Getter = (object obj) => ((AudioBufferSpeechStartedEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((AudioBufferSpeechStartedEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(AudioBufferSpeechStartedEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			return array;
		}

		private void AudioBufferSpeechStartedEventSerializeHandler(Utf8JsonWriter writer, AudioBufferSpeechStartedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteNumber(PropName_audio_start_ms, value.AudioStartMs);
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioBufferSpeechStoppedEvent> Create_AudioBufferSpeechStoppedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioBufferSpeechStoppedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioBufferSpeechStoppedEvent> objectInfo = new JsonObjectInfoValues<AudioBufferSpeechStoppedEvent>
				{
					ObjectCreator = () => new AudioBufferSpeechStoppedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioBufferSpeechStoppedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioBufferSpeechStoppedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioBufferSpeechStoppedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioBufferSpeechStoppedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<int> propertyInfo = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioBufferSpeechStoppedEvent),
				Converter = null,
				Getter = (object obj) => ((AudioBufferSpeechStoppedEvent)obj).AudioEndMs,
				Setter = (object obj, int value) =>
				{
					((AudioBufferSpeechStoppedEvent)obj).AudioEndMs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AudioEndMs",
				JsonPropertyName = "audio_end_ms",
				AttributeProviderFactory = () => typeof(AudioBufferSpeechStoppedEvent).GetProperty("AudioEndMs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioBufferSpeechStoppedEvent),
				Converter = null,
				Getter = (object obj) => ((AudioBufferSpeechStoppedEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((AudioBufferSpeechStoppedEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(AudioBufferSpeechStoppedEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			return array;
		}

		private void AudioBufferSpeechStoppedEventSerializeHandler(Utf8JsonWriter writer, AudioBufferSpeechStoppedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteNumber(PropName_audio_end_ms, value.AudioEndMs);
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioFormat> Create_AudioFormat(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioFormat> jsonTypeInfo))
			{
				JsonConverter converter = ExpandConverter(typeof(AudioFormat), new AudioFormatJsonConverter(), options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<AudioFormat>(options, converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<AudioFormat?> Create_NullableAudioFormat(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioFormat?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<AudioFormat>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<AudioFormat?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<AudioStreamEvent> Create_AudioStreamEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioStreamEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioStreamEvent> objectInfo = new JsonObjectInfoValues<AudioStreamEvent>
				{
					ObjectCreator = () => new AudioStreamEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioStreamEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioStreamEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioStreamEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioStreamEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[7];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioStreamEvent),
				Converter = null,
				Getter = (object obj) => ((AudioStreamEvent)obj).Delta,
				Setter = (object obj, string? value) =>
				{
					((AudioStreamEvent)obj).Delta = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Delta",
				JsonPropertyName = "delta",
				AttributeProviderFactory = () => typeof(AudioStreamEvent).GetProperty("Delta", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ResponseId,
				Setter = (object obj, string? value) =>
				{
					((ContentStreamEventBase)obj).ResponseId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseId",
				JsonPropertyName = "response_id",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ResponseId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ContentStreamEventBase)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo4 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).OutputIndex,
				Setter = (object obj, int value) =>
				{
					((ContentStreamEventBase)obj).OutputIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputIndex",
				JsonPropertyName = "output_index",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("OutputIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<int> propertyInfo5 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((ContentStreamEventBase)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			array[6].IsGetNullable = false;
			array[6].IsSetNullable = false;
			return array;
		}

		private void AudioStreamEventSerializeHandler(Utf8JsonWriter writer, AudioStreamEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string delta = value.Delta;
			if (delta != null)
			{
				writer.WriteString(PropName_delta, delta);
			}
			string responseId = value.ResponseId;
			if (responseId != null)
			{
				writer.WriteString(PropName_response_id, responseId);
			}
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_output_index, value.OutputIndex);
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioTranscriptionConfig> Create_AudioTranscriptionConfig(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioTranscriptionConfig> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioTranscriptionConfig> objectInfo = new JsonObjectInfoValues<AudioTranscriptionConfig>
				{
					ObjectCreator = () => new AudioTranscriptionConfig(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioTranscriptionConfigPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioTranscriptionConfig).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioTranscriptionConfigSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioTranscriptionConfigPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[1];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioTranscriptionConfig),
				Converter = null,
				Getter = (object obj) => ((AudioTranscriptionConfig)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((AudioTranscriptionConfig)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = "model",
				AttributeProviderFactory = () => typeof(AudioTranscriptionConfig).GetProperty("Model", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			return array;
		}

		private void AudioTranscriptionConfigSerializeHandler(Utf8JsonWriter writer, AudioTranscriptionConfig? value)
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
			writer.WriteEndObject();
		}

		private JsonTypeInfo<AudioTranscriptStreamEvent> Create_AudioTranscriptStreamEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<AudioTranscriptStreamEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<AudioTranscriptStreamEvent> objectInfo = new JsonObjectInfoValues<AudioTranscriptStreamEvent>
				{
					ObjectCreator = () => new AudioTranscriptStreamEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => AudioTranscriptStreamEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(AudioTranscriptStreamEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = AudioTranscriptStreamEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] AudioTranscriptStreamEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[8];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioTranscriptStreamEvent),
				Converter = null,
				Getter = (object obj) => ((AudioTranscriptStreamEvent)obj).Delta,
				Setter = (object obj, string? value) =>
				{
					((AudioTranscriptStreamEvent)obj).Delta = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Delta",
				JsonPropertyName = "delta",
				AttributeProviderFactory = () => typeof(AudioTranscriptStreamEvent).GetProperty("Delta", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(AudioTranscriptStreamEvent),
				Converter = null,
				Getter = (object obj) => ((AudioTranscriptStreamEvent)obj).Transcript,
				Setter = (object obj, string? value) =>
				{
					((AudioTranscriptStreamEvent)obj).Transcript = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Transcript",
				JsonPropertyName = "transcript",
				AttributeProviderFactory = () => typeof(AudioTranscriptStreamEvent).GetProperty("Transcript", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ResponseId,
				Setter = (object obj, string? value) =>
				{
					((ContentStreamEventBase)obj).ResponseId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseId",
				JsonPropertyName = "response_id",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ResponseId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ContentStreamEventBase)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo5 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).OutputIndex,
				Setter = (object obj, int value) =>
				{
					((ContentStreamEventBase)obj).OutputIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputIndex",
				JsonPropertyName = "output_index",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("OutputIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<int> propertyInfo6 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((ContentStreamEventBase)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			array[7].IsGetNullable = false;
			array[7].IsSetNullable = false;
			return array;
		}

		private void AudioTranscriptStreamEventSerializeHandler(Utf8JsonWriter writer, AudioTranscriptStreamEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string delta = value.Delta;
			if (delta != null)
			{
				writer.WriteString(PropName_delta, delta);
			}
			string transcript = value.Transcript;
			if (transcript != null)
			{
				writer.WriteString(PropName_transcript, transcript);
			}
			string responseId = value.ResponseId;
			if (responseId != null)
			{
				writer.WriteString(PropName_response_id, responseId);
			}
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_output_index, value.OutputIndex);
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ContentPart> Create_ContentPart(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ContentPart> jsonTypeInfo))
			{
				JsonObjectInfoValues<ContentPart> objectInfo = new JsonObjectInfoValues<ContentPart>
				{
					ObjectCreator = () => new ContentPart(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ContentPartPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ContentPart).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ContentPartSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ContentPartPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<ContentType> propertyInfo = new JsonPropertyInfoValues<ContentType>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentPart),
				Converter = null,
				Getter = (object obj) => ((ContentPart)obj).Type,
				Setter = (object obj, ContentType value) =>
				{
					((ContentPart)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(ContentPart).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ContentType), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentPart),
				Converter = null,
				Getter = (object obj) => ((ContentPart)obj).Text,
				Setter = (object obj, string? value) =>
				{
					((ContentPart)obj).Text = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Text",
				JsonPropertyName = "text",
				AttributeProviderFactory = () => typeof(ContentPart).GetProperty("Text", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentPart),
				Converter = null,
				Getter = (object obj) => ((ContentPart)obj).Audio,
				Setter = (object obj, string? value) =>
				{
					((ContentPart)obj).Audio = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Audio",
				JsonPropertyName = "audio",
				AttributeProviderFactory = () => typeof(ContentPart).GetProperty("Audio", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentPart),
				Converter = null,
				Getter = (object obj) => ((ContentPart)obj).Transcript,
				Setter = (object obj, string? value) =>
				{
					((ContentPart)obj).Transcript = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Transcript",
				JsonPropertyName = "transcript",
				AttributeProviderFactory = () => typeof(ContentPart).GetProperty("Transcript", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void ContentPartSerializeHandler(Utf8JsonWriter writer, ContentPart? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WritePropertyName(PropName_type);
			JsonSerializer.Serialize(writer, value.Type, ContentType);
			string text = value.Text;
			if (text != null)
			{
				writer.WriteString(PropName_text, text);
			}
			string audio = value.Audio;
			if (audio != null)
			{
				writer.WriteString(PropName_audio, audio);
			}
			string transcript = value.Transcript;
			if (transcript != null)
			{
				writer.WriteString(PropName_transcript, transcript);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ContentType> Create_ContentType(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ContentType> jsonTypeInfo))
			{
				JsonConverter converter = ExpandConverter(typeof(ContentType), new ContentTypeJsonConverter(), options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<ContentType>(options, converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<ConversationCreatedEvent> Create_ConversationCreatedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationCreatedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationCreatedEvent> objectInfo = new JsonObjectInfoValues<ConversationCreatedEvent>
				{
					ObjectCreator = () => new ConversationCreatedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationCreatedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationCreatedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationCreatedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationCreatedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<ConversationResource> propertyInfo = new JsonPropertyInfoValues<ConversationResource>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationCreatedEvent),
				Converter = null,
				Getter = (object obj) => ((ConversationCreatedEvent)obj).Conversation,
				Setter = (object obj, ConversationResource? value) =>
				{
					((ConversationCreatedEvent)obj).Conversation = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Conversation",
				JsonPropertyName = "conversation",
				AttributeProviderFactory = () => typeof(ConversationCreatedEvent).GetProperty("Conversation", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ConversationResource), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void ConversationCreatedEventSerializeHandler(Utf8JsonWriter writer, ConversationCreatedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			ConversationResource conversation = value.Conversation;
			if (conversation != null)
			{
				writer.WritePropertyName(PropName_conversation);
				ConversationResourceSerializeHandler(writer, conversation);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationItem> Create_ConversationItem(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationItem> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationItem> objectInfo = new JsonObjectInfoValues<ConversationItem>
				{
					ObjectCreator = () => new ConversationItem(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationItemPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationItem).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationItemSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationItemPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[9];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Id,
				Setter = (object obj, string? value) =>
				{
					((ConversationItem)obj).Id = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<ItemType> propertyInfo2 = new JsonPropertyInfoValues<ItemType>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Type,
				Setter = (object obj, ItemType value) =>
				{
					((ConversationItem)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ItemType), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<Status?> propertyInfo3 = new JsonPropertyInfoValues<Status?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Status,
				Setter = (object obj, Status? value) =>
				{
					((ConversationItem)obj).Status = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Status",
				JsonPropertyName = "status",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Status?), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<Role?> propertyInfo4 = new JsonPropertyInfoValues<Role?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Role,
				Setter = (object obj, Role? value) =>
				{
					((ConversationItem)obj).Role = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Role",
				JsonPropertyName = "role",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Role", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Role?), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<List<ContentPart>> propertyInfo5 = new JsonPropertyInfoValues<List<ContentPart>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Content,
				Setter = (object obj, List<ContentPart>? value) =>
				{
					((ConversationItem)obj).Content = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Content",
				JsonPropertyName = "content",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Content", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<ContentPart>), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).CallId,
				Setter = (object obj, string? value) =>
				{
					((ConversationItem)obj).CallId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CallId",
				JsonPropertyName = "call_id",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("CallId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((ConversationItem)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Arguments,
				Setter = (object obj, string? value) =>
				{
					((ConversationItem)obj).Arguments = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Arguments",
				JsonPropertyName = "arguments",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Arguments", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItem),
				Converter = null,
				Getter = (object obj) => ((ConversationItem)obj).Output,
				Setter = (object obj, string? value) =>
				{
					((ConversationItem)obj).Output = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Output",
				JsonPropertyName = "output",
				AttributeProviderFactory = () => typeof(ConversationItem).GetProperty("Output", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			return array;
		}

		private void ConversationItemSerializeHandler(Utf8JsonWriter writer, ConversationItem? value)
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
			writer.WritePropertyName(PropName_type);
			JsonSerializer.Serialize(writer, value.Type, ItemType);
			Status? status = value.Status;
			if (status.HasValue)
			{
				writer.WritePropertyName(PropName_status);
				JsonSerializer.Serialize(writer, status, NullableStatus);
			}
			Role? role = value.Role;
			if (role.HasValue)
			{
				writer.WritePropertyName(PropName_role);
				JsonSerializer.Serialize(writer, role, NullableRole);
			}
			List<ContentPart> content = value.Content;
			if (content != null)
			{
				writer.WritePropertyName(PropName_content);
				ListContentPartSerializeHandler(writer, content);
			}
			string callId = value.CallId;
			if (callId != null)
			{
				writer.WriteString(PropName_call_id, callId);
			}
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
			string output = value.Output;
			if (output != null)
			{
				writer.WriteString(PropName_output, output);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationItemCreatedEvent> Create_ConversationItemCreatedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationItemCreatedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationItemCreatedEvent> objectInfo = new JsonObjectInfoValues<ConversationItemCreatedEvent>
				{
					ObjectCreator = () => new ConversationItemCreatedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationItemCreatedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationItemCreatedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationItemCreatedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationItemCreatedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemCreatedEvent),
				Converter = null,
				Getter = (object obj) => ((ConversationItemCreatedEvent)obj).PreviousItemId,
				Setter = (object obj, string? value) =>
				{
					((ConversationItemCreatedEvent)obj).PreviousItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PreviousItemId",
				JsonPropertyName = "previous_item_id",
				AttributeProviderFactory = () => typeof(ConversationItemCreatedEvent).GetProperty("PreviousItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<ConversationItem> propertyInfo2 = new JsonPropertyInfoValues<ConversationItem>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemCreatedEvent),
				Converter = null,
				Getter = (object obj) => ((ConversationItemCreatedEvent)obj).Item,
				Setter = (object obj, ConversationItem? value) =>
				{
					((ConversationItemCreatedEvent)obj).Item = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Item",
				JsonPropertyName = "item",
				AttributeProviderFactory = () => typeof(ConversationItemCreatedEvent).GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ConversationItem), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			return array;
		}

		private void ConversationItemCreatedEventSerializeHandler(Utf8JsonWriter writer, ConversationItemCreatedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string previousItemId = value.PreviousItemId;
			if (previousItemId != null)
			{
				writer.WriteString(PropName_previous_item_id, previousItemId);
			}
			ConversationItem item = value.Item;
			if (item != null)
			{
				writer.WritePropertyName(PropName_item);
				ConversationItemSerializeHandler(writer, item);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationItemCreateRequest> Create_ConversationItemCreateRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationItemCreateRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationItemCreateRequest> objectInfo = new JsonObjectInfoValues<ConversationItemCreateRequest>
				{
					ObjectCreator = () => new ConversationItemCreateRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationItemCreateRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationItemCreateRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationItemCreateRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationItemCreateRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ConversationItemCreateRequest)obj).PreviousItemId,
				Setter = (object obj, string? value) =>
				{
					((ConversationItemCreateRequest)obj).PreviousItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PreviousItemId",
				JsonPropertyName = "previous_item_id",
				AttributeProviderFactory = () => typeof(ConversationItemCreateRequest).GetProperty("PreviousItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<ConversationItem> propertyInfo2 = new JsonPropertyInfoValues<ConversationItem>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ConversationItemCreateRequest)obj).Item,
				Setter = (object obj, ConversationItem? value) =>
				{
					((ConversationItemCreateRequest)obj).Item = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Item",
				JsonPropertyName = "item",
				AttributeProviderFactory = () => typeof(ConversationItemCreateRequest).GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ConversationItem), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			return array;
		}

		private void ConversationItemCreateRequestSerializeHandler(Utf8JsonWriter writer, ConversationItemCreateRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string previousItemId = value.PreviousItemId;
			if (previousItemId != null)
			{
				writer.WriteString(PropName_previous_item_id, previousItemId);
			}
			ConversationItem item = value.Item;
			if (item != null)
			{
				writer.WritePropertyName(PropName_item);
				ConversationItemSerializeHandler(writer, item);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationItemDeletedEvent> Create_ConversationItemDeletedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationItemDeletedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationItemDeletedEvent> objectInfo = new JsonObjectInfoValues<ConversationItemDeletedEvent>
				{
					ObjectCreator = () => new ConversationItemDeletedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationItemDeletedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationItemDeletedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationItemDeletedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationItemDeletedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemDeletedEvent),
				Converter = null,
				Getter = (object obj) => ((ConversationItemDeletedEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ConversationItemDeletedEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ConversationItemDeletedEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void ConversationItemDeletedEventSerializeHandler(Utf8JsonWriter writer, ConversationItemDeletedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationItemDeleteRequest> Create_ConversationItemDeleteRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationItemDeleteRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationItemDeleteRequest> objectInfo = new JsonObjectInfoValues<ConversationItemDeleteRequest>
				{
					ObjectCreator = () => new ConversationItemDeleteRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationItemDeleteRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationItemDeleteRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationItemDeleteRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationItemDeleteRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemDeleteRequest),
				Converter = null,
				Getter = (object obj) => ((ConversationItemDeleteRequest)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ConversationItemDeleteRequest)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ConversationItemDeleteRequest).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void ConversationItemDeleteRequestSerializeHandler(Utf8JsonWriter writer, ConversationItemDeleteRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationItemTruncatedEvent> Create_ConversationItemTruncatedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationItemTruncatedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationItemTruncatedEvent> objectInfo = new JsonObjectInfoValues<ConversationItemTruncatedEvent>
				{
					ObjectCreator = () => new ConversationItemTruncatedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationItemTruncatedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationItemTruncatedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationItemTruncatedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationItemTruncatedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemTruncatedEvent),
				Converter = null,
				Getter = (object obj) => ((ConversationItemTruncatedEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ConversationItemTruncatedEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ConversationItemTruncatedEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemTruncatedEvent),
				Converter = null,
				Getter = (object obj) => ((ConversationItemTruncatedEvent)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((ConversationItemTruncatedEvent)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(ConversationItemTruncatedEvent).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemTruncatedEvent),
				Converter = null,
				Getter = (object obj) => ((ConversationItemTruncatedEvent)obj).AudioEndMs,
				Setter = (object obj, int value) =>
				{
					((ConversationItemTruncatedEvent)obj).AudioEndMs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AudioEndMs",
				JsonPropertyName = "audio_end_ms",
				AttributeProviderFactory = () => typeof(ConversationItemTruncatedEvent).GetProperty("AudioEndMs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			return array;
		}

		private void ConversationItemTruncatedEventSerializeHandler(Utf8JsonWriter writer, ConversationItemTruncatedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			writer.WriteNumber(PropName_audio_end_ms, value.AudioEndMs);
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationItemTruncateRequest> Create_ConversationItemTruncateRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationItemTruncateRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationItemTruncateRequest> objectInfo = new JsonObjectInfoValues<ConversationItemTruncateRequest>
				{
					ObjectCreator = () => new ConversationItemTruncateRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationItemTruncateRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationItemTruncateRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationItemTruncateRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationItemTruncateRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemTruncateRequest),
				Converter = null,
				Getter = (object obj) => ((ConversationItemTruncateRequest)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ConversationItemTruncateRequest)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ConversationItemTruncateRequest).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemTruncateRequest),
				Converter = null,
				Getter = (object obj) => ((ConversationItemTruncateRequest)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((ConversationItemTruncateRequest)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(ConversationItemTruncateRequest).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationItemTruncateRequest),
				Converter = null,
				Getter = (object obj) => ((ConversationItemTruncateRequest)obj).AudioEndMs,
				Setter = (object obj, int value) =>
				{
					((ConversationItemTruncateRequest)obj).AudioEndMs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "AudioEndMs",
				JsonPropertyName = "audio_end_ms",
				AttributeProviderFactory = () => typeof(ConversationItemTruncateRequest).GetProperty("AudioEndMs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			return array;
		}

		private void ConversationItemTruncateRequestSerializeHandler(Utf8JsonWriter writer, ConversationItemTruncateRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			writer.WriteNumber(PropName_audio_end_ms, value.AudioEndMs);
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ConversationResource> Create_ConversationResource(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ConversationResource> jsonTypeInfo))
			{
				JsonObjectInfoValues<ConversationResource> objectInfo = new JsonObjectInfoValues<ConversationResource>
				{
					ObjectCreator = () => new ConversationResource(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ConversationResourcePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ConversationResource).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ConversationResourceSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ConversationResourcePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationResource),
				Converter = null,
				Getter = (object obj) => ((ConversationResource)obj).Id,
				Setter = (object obj, string? value) =>
				{
					((ConversationResource)obj).Id = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id",
				AttributeProviderFactory = () => typeof(ConversationResource).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ConversationResource),
				Converter = null,
				Getter = (object obj) => ((ConversationResource)obj).Object,
				Setter = (object obj, string? value) =>
				{
					((ConversationResource)obj).Object = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Object",
				JsonPropertyName = "object",
				AttributeProviderFactory = () => typeof(ConversationResource).GetProperty("Object", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		private void ConversationResourceSerializeHandler(Utf8JsonWriter writer, ConversationResource? value)
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
			string text = value.Object;
			if (text != null)
			{
				writer.WriteString(PropName_object, text);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ErrorEvent> Create_ErrorEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ErrorEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ErrorEvent> objectInfo = new JsonObjectInfoValues<ErrorEvent>
				{
					ObjectCreator = () => new ErrorEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ErrorEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ErrorEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ErrorEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ErrorEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<Error> propertyInfo = new JsonPropertyInfoValues<Error>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ErrorEventBase),
				Converter = null,
				Getter = (object obj) => ((ErrorEventBase)obj).Error,
				Setter = (object obj, Error? value) =>
				{
					((ErrorEventBase)obj).Error = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Error",
				JsonPropertyName = "error",
				AttributeProviderFactory = () => typeof(ErrorEventBase).GetProperty("Error", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Error), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void ErrorEventSerializeHandler(Utf8JsonWriter writer, ErrorEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			Error error = value.Error;
			if (error != null)
			{
				writer.WritePropertyName(PropName_error);
				JsonSerializer.Serialize(writer, error, Error);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<FunctionCallStreamEvent> Create_FunctionCallStreamEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<FunctionCallStreamEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<FunctionCallStreamEvent> objectInfo = new JsonObjectInfoValues<FunctionCallStreamEvent>
				{
					ObjectCreator = () => new FunctionCallStreamEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => FunctionCallStreamEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = FunctionCallStreamEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] FunctionCallStreamEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[9];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCallStreamEvent),
				Converter = null,
				Getter = (object obj) => ((FunctionCallStreamEvent)obj).ResponseId,
				Setter = (object obj, string? value) =>
				{
					((FunctionCallStreamEvent)obj).ResponseId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseId",
				JsonPropertyName = "response_id",
				AttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetProperty("ResponseId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCallStreamEvent),
				Converter = null,
				Getter = (object obj) => ((FunctionCallStreamEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((FunctionCallStreamEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCallStreamEvent),
				Converter = null,
				Getter = (object obj) => ((FunctionCallStreamEvent)obj).OutputIndex,
				Setter = (object obj, int value) =>
				{
					((FunctionCallStreamEvent)obj).OutputIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputIndex",
				JsonPropertyName = "output_index",
				AttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetProperty("OutputIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCallStreamEvent),
				Converter = null,
				Getter = (object obj) => ((FunctionCallStreamEvent)obj).CallId,
				Setter = (object obj, string? value) =>
				{
					((FunctionCallStreamEvent)obj).CallId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "CallId",
				JsonPropertyName = "call_id",
				AttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetProperty("CallId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCallStreamEvent),
				Converter = null,
				Getter = (object obj) => ((FunctionCallStreamEvent)obj).Delta,
				Setter = (object obj, string? value) =>
				{
					((FunctionCallStreamEvent)obj).Delta = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Delta",
				JsonPropertyName = "delta",
				AttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetProperty("Delta", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCallStreamEvent),
				Converter = null,
				Getter = (object obj) => ((FunctionCallStreamEvent)obj).Arguments,
				Setter = (object obj, string? value) =>
				{
					((FunctionCallStreamEvent)obj).Arguments = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Arguments",
				JsonPropertyName = "arguments",
				AttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetProperty("Arguments", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(FunctionCallStreamEvent),
				Converter = null,
				Getter = (object obj) => ((FunctionCallStreamEvent)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((FunctionCallStreamEvent)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name",
				AttributeProviderFactory = () => typeof(FunctionCallStreamEvent).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			array[8].IsGetNullable = false;
			array[8].IsSetNullable = false;
			return array;
		}

		private void FunctionCallStreamEventSerializeHandler(Utf8JsonWriter writer, FunctionCallStreamEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string responseId = value.ResponseId;
			if (responseId != null)
			{
				writer.WriteString(PropName_response_id, responseId);
			}
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_output_index, value.OutputIndex);
			string callId = value.CallId;
			if (callId != null)
			{
				writer.WriteString(PropName_call_id, callId);
			}
			string delta = value.Delta;
			if (delta != null)
			{
				writer.WriteString(PropName_delta, delta);
			}
			string arguments = value.Arguments;
			if (arguments != null)
			{
				writer.WriteString(PropName_arguments, arguments);
			}
			string name = value.Name;
			if (name != null)
			{
				writer.WriteString(PropName_name, name);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<InputAudioTranscriptionCompletedEvent> Create_InputAudioTranscriptionCompletedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<InputAudioTranscriptionCompletedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<InputAudioTranscriptionCompletedEvent> objectInfo = new JsonObjectInfoValues<InputAudioTranscriptionCompletedEvent>
				{
					ObjectCreator = () => new InputAudioTranscriptionCompletedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => InputAudioTranscriptionCompletedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(InputAudioTranscriptionCompletedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = InputAudioTranscriptionCompletedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] InputAudioTranscriptionCompletedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(InputAudioTranscriptionCompletedEvent),
				Converter = null,
				Getter = (object obj) => ((InputAudioTranscriptionCompletedEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((InputAudioTranscriptionCompletedEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(InputAudioTranscriptionCompletedEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(InputAudioTranscriptionCompletedEvent),
				Converter = null,
				Getter = (object obj) => ((InputAudioTranscriptionCompletedEvent)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((InputAudioTranscriptionCompletedEvent)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(InputAudioTranscriptionCompletedEvent).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(InputAudioTranscriptionCompletedEvent),
				Converter = null,
				Getter = (object obj) => ((InputAudioTranscriptionCompletedEvent)obj).Transcript,
				Setter = (object obj, string? value) =>
				{
					((InputAudioTranscriptionCompletedEvent)obj).Transcript = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Transcript",
				JsonPropertyName = "transcript",
				AttributeProviderFactory = () => typeof(InputAudioTranscriptionCompletedEvent).GetProperty("Transcript", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			return array;
		}

		private void InputAudioTranscriptionCompletedEventSerializeHandler(Utf8JsonWriter writer, InputAudioTranscriptionCompletedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			string transcript = value.Transcript;
			if (transcript != null)
			{
				writer.WriteString(PropName_transcript, transcript);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<InputAudioTranscriptionFailedEvent> Create_InputAudioTranscriptionFailedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<InputAudioTranscriptionFailedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<InputAudioTranscriptionFailedEvent> objectInfo = new JsonObjectInfoValues<InputAudioTranscriptionFailedEvent>
				{
					ObjectCreator = () => new InputAudioTranscriptionFailedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => InputAudioTranscriptionFailedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(InputAudioTranscriptionFailedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = InputAudioTranscriptionFailedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] InputAudioTranscriptionFailedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(InputAudioTranscriptionFailedEvent),
				Converter = null,
				Getter = (object obj) => ((InputAudioTranscriptionFailedEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((InputAudioTranscriptionFailedEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(InputAudioTranscriptionFailedEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(InputAudioTranscriptionFailedEvent),
				Converter = null,
				Getter = (object obj) => ((InputAudioTranscriptionFailedEvent)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((InputAudioTranscriptionFailedEvent)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(InputAudioTranscriptionFailedEvent).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<Error> propertyInfo3 = new JsonPropertyInfoValues<Error>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(InputAudioTranscriptionFailedEvent),
				Converter = null,
				Getter = (object obj) => ((InputAudioTranscriptionFailedEvent)obj).Error,
				Setter = (object obj, Error? value) =>
				{
					((InputAudioTranscriptionFailedEvent)obj).Error = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Error",
				JsonPropertyName = "error",
				AttributeProviderFactory = () => typeof(InputAudioTranscriptionFailedEvent).GetProperty("Error", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Error), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			return array;
		}

		private void InputAudioTranscriptionFailedEventSerializeHandler(Utf8JsonWriter writer, InputAudioTranscriptionFailedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			Error error = value.Error;
			if (error != null)
			{
				writer.WritePropertyName(PropName_error);
				JsonSerializer.Serialize(writer, error, Error);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ItemType> Create_ItemType(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ItemType> jsonTypeInfo))
			{
				JsonConverter converter = ExpandConverter(typeof(ItemType), new ItemTypeJsonConverter(), options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<ItemType>(options, converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<JsonSchema> Create_JsonSchema(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<JsonSchema> jsonTypeInfo))
			{
				JsonObjectInfoValues<JsonSchema> objectInfo = new JsonObjectInfoValues<JsonSchema>
				{
					ObjectCreator = () => new JsonSchema(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => JsonSchemaPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(JsonSchema).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
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
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(JsonSchema),
				Converter = null,
				Getter = (object obj) => ((JsonSchema)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((JsonSchema)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(JsonSchema).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<Dictionary<string, JsonSchemaProperty>> propertyInfo2 = new JsonPropertyInfoValues<Dictionary<string, JsonSchemaProperty>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(JsonSchema),
				Converter = null,
				Getter = (object obj) => ((JsonSchema)obj).Properties,
				Setter = (object obj, Dictionary<string, JsonSchemaProperty>? value) =>
				{
					((JsonSchema)obj).Properties = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Properties",
				JsonPropertyName = "properties",
				AttributeProviderFactory = () => typeof(JsonSchema).GetProperty("Properties", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, JsonSchemaProperty>), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<List<string>> propertyInfo3 = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(JsonSchema),
				Converter = null,
				Getter = (object obj) => ((JsonSchema)obj).Required,
				Setter = (object obj, List<string>? value) =>
				{
					((JsonSchema)obj).Required = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Required",
				JsonPropertyName = "required",
				AttributeProviderFactory = () => typeof(JsonSchema).GetProperty("Required", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			return array;
		}

		private void JsonSchemaSerializeHandler(Utf8JsonWriter writer, JsonSchema? value)
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
			Dictionary<string, JsonSchemaProperty> properties = value.Properties;
			if (properties != null)
			{
				writer.WritePropertyName(PropName_properties);
				DictionaryStringJsonSchemaPropertySerializeHandler(writer, properties);
			}
			List<string> required = value.Required;
			if (required != null)
			{
				writer.WritePropertyName(PropName_required);
				ListStringSerializeHandler(writer, required);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<JsonSchemaProperty> Create_JsonSchemaProperty(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<JsonSchemaProperty> jsonTypeInfo))
			{
				JsonObjectInfoValues<JsonSchemaProperty> objectInfo = new JsonObjectInfoValues<JsonSchemaProperty>
				{
					ObjectCreator = () => new JsonSchemaProperty(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => JsonSchemaPropertyPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(JsonSchemaProperty).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = JsonSchemaPropertySerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] JsonSchemaPropertyPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(JsonSchemaProperty),
				Converter = null,
				Getter = (object obj) => ((JsonSchemaProperty)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((JsonSchemaProperty)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(JsonSchemaProperty).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(JsonSchemaProperty),
				Converter = null,
				Getter = (object obj) => ((JsonSchemaProperty)obj).Description,
				Setter = (object obj, string? value) =>
				{
					((JsonSchemaProperty)obj).Description = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Description",
				JsonPropertyName = "description",
				AttributeProviderFactory = () => typeof(JsonSchemaProperty).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void JsonSchemaPropertySerializeHandler(Utf8JsonWriter writer, JsonSchemaProperty? value)
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
			string description = value.Description;
			if (description != null)
			{
				writer.WriteString(PropName_description, description);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<MaxOutputTokens> Create_MaxOutputTokens(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<MaxOutputTokens> jsonTypeInfo))
			{
				JsonConverter converter = ExpandConverter(typeof(MaxOutputTokens), new MaxOutputTokensConverter(), options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<MaxOutputTokens>(options, converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<RateLimit> Create_RateLimit(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RateLimit> jsonTypeInfo))
			{
				JsonObjectInfoValues<RateLimit> objectInfo = new JsonObjectInfoValues<RateLimit>
				{
					ObjectCreator = () => new RateLimit(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => RateLimitPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(RateLimit).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = RateLimitSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] RateLimitPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimit),
				Converter = null,
				Getter = (object obj) => ((RateLimit)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((RateLimit)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name",
				AttributeProviderFactory = () => typeof(RateLimit).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimit),
				Converter = null,
				Getter = (object obj) => ((RateLimit)obj).Limit,
				Setter = (object obj, int value) =>
				{
					((RateLimit)obj).Limit = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Limit",
				JsonPropertyName = "limit",
				AttributeProviderFactory = () => typeof(RateLimit).GetProperty("Limit", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimit),
				Converter = null,
				Getter = (object obj) => ((RateLimit)obj).Remaining,
				Setter = (object obj, int value) =>
				{
					((RateLimit)obj).Remaining = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Remaining",
				JsonPropertyName = "remaining",
				AttributeProviderFactory = () => typeof(RateLimit).GetProperty("Remaining", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<double> propertyInfo4 = new JsonPropertyInfoValues<double>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimit),
				Converter = null,
				Getter = (object obj) => ((RateLimit)obj).ResetSeconds,
				Setter = (object obj, double value) =>
				{
					((RateLimit)obj).ResetSeconds = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResetSeconds",
				JsonPropertyName = "reset_seconds",
				AttributeProviderFactory = () => typeof(RateLimit).GetProperty("ResetSeconds", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(double), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void RateLimitSerializeHandler(Utf8JsonWriter writer, RateLimit? value)
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
			writer.WriteNumber(PropName_limit, value.Limit);
			writer.WriteNumber(PropName_remaining, value.Remaining);
			writer.WriteNumber(PropName_reset_seconds, value.ResetSeconds);
			writer.WriteEndObject();
		}

		private JsonTypeInfo<RateLimitsEvent> Create_RateLimitsEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RateLimitsEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<RateLimitsEvent> objectInfo = new JsonObjectInfoValues<RateLimitsEvent>
				{
					ObjectCreator = () => new RateLimitsEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => RateLimitsEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(RateLimitsEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = RateLimitsEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] RateLimitsEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<List<RateLimit>> propertyInfo = new JsonPropertyInfoValues<List<RateLimit>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RateLimitsEvent),
				Converter = null,
				Getter = (object obj) => ((RateLimitsEvent)obj).RateLimits,
				Setter = (object obj, List<RateLimit>? value) =>
				{
					((RateLimitsEvent)obj).RateLimits = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "RateLimits",
				JsonPropertyName = "rate_limits",
				AttributeProviderFactory = () => typeof(RateLimitsEvent).GetProperty("RateLimits", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<RateLimit>), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void RateLimitsEventSerializeHandler(Utf8JsonWriter writer, RateLimitsEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			List<RateLimit> rateLimits = value.RateLimits;
			if (rateLimits != null)
			{
				writer.WritePropertyName(PropName_rate_limits);
				ListRateLimitSerializeHandler(writer, rateLimits);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<RealtimeToolDefinition> Create_RealtimeToolDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<RealtimeToolDefinition> jsonTypeInfo))
			{
				JsonObjectInfoValues<RealtimeToolDefinition> objectInfo = new JsonObjectInfoValues<RealtimeToolDefinition>
				{
					ObjectCreator = () => new RealtimeToolDefinition(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => RealtimeToolDefinitionPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(RealtimeToolDefinition).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = RealtimeToolDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] RealtimeToolDefinitionPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RealtimeToolDefinition),
				Converter = null,
				Getter = (object obj) => ((RealtimeToolDefinition)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((RealtimeToolDefinition)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(RealtimeToolDefinition).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RealtimeToolDefinition),
				Converter = null,
				Getter = (object obj) => ((RealtimeToolDefinition)obj).Name,
				Setter = (object obj, string? value) =>
				{
					((RealtimeToolDefinition)obj).Name = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Name",
				JsonPropertyName = "name",
				AttributeProviderFactory = () => typeof(RealtimeToolDefinition).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RealtimeToolDefinition),
				Converter = null,
				Getter = (object obj) => ((RealtimeToolDefinition)obj).Description,
				Setter = (object obj, string? value) =>
				{
					((RealtimeToolDefinition)obj).Description = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Description",
				JsonPropertyName = "description",
				AttributeProviderFactory = () => typeof(RealtimeToolDefinition).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<PropertyDefinition> propertyInfo4 = new JsonPropertyInfoValues<PropertyDefinition>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(RealtimeToolDefinition),
				Converter = null,
				Getter = (object obj) => ((RealtimeToolDefinition)obj).Parameters,
				Setter = (object obj, PropertyDefinition? value) =>
				{
					((RealtimeToolDefinition)obj).Parameters = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Parameters",
				JsonPropertyName = "parameters",
				AttributeProviderFactory = () => typeof(RealtimeToolDefinition).GetProperty("Parameters", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(PropertyDefinition), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			return array;
		}

		private void RealtimeToolDefinitionSerializeHandler(Utf8JsonWriter writer, RealtimeToolDefinition? value)
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
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseCancelRequest> Create_ResponseCancelRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseCancelRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseCancelRequest> objectInfo = new JsonObjectInfoValues<ResponseCancelRequest>
				{
					ObjectCreator = () => new ResponseCancelRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseCancelRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseCancelRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseCancelRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseCancelRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		private void ResponseCancelRequestSerializeHandler(Utf8JsonWriter writer, ResponseCancelRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseConfig> Create_ResponseConfig(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseConfig> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseConfig> objectInfo = new JsonObjectInfoValues<ResponseConfig>
				{
					ObjectCreator = () => new ResponseConfig(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseConfigPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseConfig).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseConfigSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseConfigPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[8];
			JsonPropertyInfoValues<List<string>> propertyInfo = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).Modalities,
				Setter = (object obj, List<string>? value) =>
				{
					((ResponseConfig)obj).Modalities = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Modalities",
				JsonPropertyName = "modalities",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("Modalities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).Instructions,
				Setter = (object obj, string? value) =>
				{
					((ResponseConfig)obj).Instructions = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Instructions",
				JsonPropertyName = "instructions",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("Instructions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).Voice,
				Setter = (object obj, string? value) =>
				{
					((ResponseConfig)obj).Voice = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Voice",
				JsonPropertyName = "voice",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("Voice", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<AudioFormat?> propertyInfo4 = new JsonPropertyInfoValues<AudioFormat?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).OutputAudioFormat,
				Setter = (object obj, AudioFormat? value) =>
				{
					((ResponseConfig)obj).OutputAudioFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputAudioFormat",
				JsonPropertyName = "output_audio_format",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("OutputAudioFormat", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AudioFormat?), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<List<FunctionDefinition>> propertyInfo5 = new JsonPropertyInfoValues<List<FunctionDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).Tools,
				Setter = (object obj, List<FunctionDefinition>? value) =>
				{
					((ResponseConfig)obj).Tools = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Tools",
				JsonPropertyName = "tools",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("Tools", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<FunctionDefinition>), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).ToolChoice,
				Setter = (object obj, string? value) =>
				{
					((ResponseConfig)obj).ToolChoice = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolChoice",
				JsonPropertyName = "tool_choice",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("ToolChoice", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<double?> propertyInfo7 = new JsonPropertyInfoValues<double?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).Temperature,
				Setter = (object obj, double? value) =>
				{
					((ResponseConfig)obj).Temperature = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Temperature",
				JsonPropertyName = "temperature",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("Temperature", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(double?), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<MaxOutputTokens> propertyInfo8 = new JsonPropertyInfoValues<MaxOutputTokens>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseConfig),
				Converter = null,
				Getter = (object obj) => ((ResponseConfig)obj).MaxOutputTokens,
				Setter = (object obj, MaxOutputTokens? value) =>
				{
					((ResponseConfig)obj).MaxOutputTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxOutputTokens",
				JsonPropertyName = "max_output_tokens",
				AttributeProviderFactory = () => typeof(ResponseConfig).GetProperty("MaxOutputTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(MaxOutputTokens), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			return array;
		}

		private void ResponseConfigSerializeHandler(Utf8JsonWriter writer, ResponseConfig? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			List<string> modalities = value.Modalities;
			if (modalities != null)
			{
				writer.WritePropertyName(PropName_modalities);
				ListStringSerializeHandler(writer, modalities);
			}
			string instructions = value.Instructions;
			if (instructions != null)
			{
				writer.WriteString(PropName_instructions, instructions);
			}
			string voice = value.Voice;
			if (voice != null)
			{
				writer.WriteString(PropName_voice, voice);
			}
			AudioFormat? outputAudioFormat = value.OutputAudioFormat;
			if (outputAudioFormat.HasValue)
			{
				writer.WritePropertyName(PropName_output_audio_format);
				JsonSerializer.Serialize(writer, outputAudioFormat, NullableAudioFormat);
			}
			List<FunctionDefinition> tools = value.Tools;
			if (tools != null)
			{
				writer.WritePropertyName(PropName_tools);
				ListFunctionDefinitionSerializeHandler(writer, tools);
			}
			string toolChoice = value.ToolChoice;
			if (toolChoice != null)
			{
				writer.WriteString(PropName_tool_choice, toolChoice);
			}
			double? temperature = value.Temperature;
			if (temperature.HasValue)
			{
				writer.WritePropertyName(PropName_temperature);
				JsonSerializer.Serialize(writer, temperature, NullableDouble);
			}
			MaxOutputTokens maxOutputTokens = value.MaxOutputTokens;
			if (maxOutputTokens != null)
			{
				writer.WritePropertyName(PropName_max_output_tokens);
				JsonSerializer.Serialize(writer, maxOutputTokens, MaxOutputTokens);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseContentPartEvent> Create_ResponseContentPartEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseContentPartEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseContentPartEvent> objectInfo = new JsonObjectInfoValues<ResponseContentPartEvent>
				{
					ObjectCreator = () => new ResponseContentPartEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseContentPartEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseContentPartEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseContentPartEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseContentPartEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[7];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseContentPartEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseContentPartEvent)obj).ResponseId,
				Setter = (object obj, string? value) =>
				{
					((ResponseContentPartEvent)obj).ResponseId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseId",
				JsonPropertyName = "response_id",
				AttributeProviderFactory = () => typeof(ResponseContentPartEvent).GetProperty("ResponseId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseContentPartEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseContentPartEvent)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ResponseContentPartEvent)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ResponseContentPartEvent).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseContentPartEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseContentPartEvent)obj).OutputIndex,
				Setter = (object obj, int value) =>
				{
					((ResponseContentPartEvent)obj).OutputIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputIndex",
				JsonPropertyName = "output_index",
				AttributeProviderFactory = () => typeof(ResponseContentPartEvent).GetProperty("OutputIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<int> propertyInfo4 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseContentPartEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseContentPartEvent)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((ResponseContentPartEvent)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(ResponseContentPartEvent).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<ContentPart> propertyInfo5 = new JsonPropertyInfoValues<ContentPart>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseContentPartEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseContentPartEvent)obj).Part,
				Setter = (object obj, ContentPart? value) =>
				{
					((ResponseContentPartEvent)obj).Part = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Part",
				JsonPropertyName = "part",
				AttributeProviderFactory = () => typeof(ResponseContentPartEvent).GetProperty("Part", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ContentPart), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			array[6].IsGetNullable = false;
			array[6].IsSetNullable = false;
			return array;
		}

		private void ResponseContentPartEventSerializeHandler(Utf8JsonWriter writer, ResponseContentPartEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string responseId = value.ResponseId;
			if (responseId != null)
			{
				writer.WriteString(PropName_response_id, responseId);
			}
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_output_index, value.OutputIndex);
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			ContentPart part = value.Part;
			if (part != null)
			{
				writer.WritePropertyName(PropName_part);
				ContentPartSerializeHandler(writer, part);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseCreateRequest> Create_ResponseCreateRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseCreateRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseCreateRequest> objectInfo = new JsonObjectInfoValues<ResponseCreateRequest>
				{
					ObjectCreator = () => new ResponseCreateRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseCreateRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseCreateRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseCreateRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseCreateRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<ResponseConfig> propertyInfo = new JsonPropertyInfoValues<ResponseConfig>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseCreateRequest),
				Converter = null,
				Getter = (object obj) => ((ResponseCreateRequest)obj).Response,
				Setter = (object obj, ResponseConfig? value) =>
				{
					((ResponseCreateRequest)obj).Response = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Response",
				JsonPropertyName = "response",
				AttributeProviderFactory = () => typeof(ResponseCreateRequest).GetProperty("Response", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ResponseConfig), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void ResponseCreateRequestSerializeHandler(Utf8JsonWriter writer, ResponseCreateRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			ResponseConfig response = value.Response;
			if (response != null)
			{
				writer.WritePropertyName(PropName_response);
				ResponseConfigSerializeHandler(writer, response);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseEvent> Create_ResponseEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseEvent> objectInfo = new JsonObjectInfoValues<ResponseEvent>
				{
					ObjectCreator = () => new ResponseEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<ResponseResource> propertyInfo = new JsonPropertyInfoValues<ResponseResource>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseEvent)obj).Response,
				Setter = (object obj, ResponseResource? value) =>
				{
					((ResponseEvent)obj).Response = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Response",
				JsonPropertyName = "response",
				AttributeProviderFactory = () => typeof(ResponseEvent).GetProperty("Response", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ResponseResource), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void ResponseEventSerializeHandler(Utf8JsonWriter writer, ResponseEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			ResponseResource response = value.Response;
			if (response != null)
			{
				writer.WritePropertyName(PropName_response);
				ResponseResourceSerializeHandler(writer, response);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseOutputItemAddedEvent> Create_ResponseOutputItemAddedEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseOutputItemAddedEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseOutputItemAddedEvent> objectInfo = new JsonObjectInfoValues<ResponseOutputItemAddedEvent>
				{
					ObjectCreator = () => new ResponseOutputItemAddedEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseOutputItemAddedEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseOutputItemAddedEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseOutputItemAddedEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseOutputItemAddedEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseOutputItemAddedEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseOutputItemAddedEvent)obj).ResponseId,
				Setter = (object obj, string? value) =>
				{
					((ResponseOutputItemAddedEvent)obj).ResponseId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseId",
				JsonPropertyName = "response_id",
				AttributeProviderFactory = () => typeof(ResponseOutputItemAddedEvent).GetProperty("ResponseId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseOutputItemAddedEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseOutputItemAddedEvent)obj).OutputIndex,
				Setter = (object obj, int value) =>
				{
					((ResponseOutputItemAddedEvent)obj).OutputIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputIndex",
				JsonPropertyName = "output_index",
				AttributeProviderFactory = () => typeof(ResponseOutputItemAddedEvent).GetProperty("OutputIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<ConversationItem> propertyInfo3 = new JsonPropertyInfoValues<ConversationItem>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseOutputItemAddedEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseOutputItemAddedEvent)obj).Item,
				Setter = (object obj, ConversationItem? value) =>
				{
					((ResponseOutputItemAddedEvent)obj).Item = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Item",
				JsonPropertyName = "item",
				AttributeProviderFactory = () => typeof(ResponseOutputItemAddedEvent).GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ConversationItem), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			return array;
		}

		private void ResponseOutputItemAddedEventSerializeHandler(Utf8JsonWriter writer, ResponseOutputItemAddedEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string responseId = value.ResponseId;
			if (responseId != null)
			{
				writer.WriteString(PropName_response_id, responseId);
			}
			writer.WriteNumber(PropName_output_index, value.OutputIndex);
			ConversationItem item = value.Item;
			if (item != null)
			{
				writer.WritePropertyName(PropName_item);
				ConversationItemSerializeHandler(writer, item);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseOutputItemDoneEvent> Create_ResponseOutputItemDoneEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseOutputItemDoneEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseOutputItemDoneEvent> objectInfo = new JsonObjectInfoValues<ResponseOutputItemDoneEvent>
				{
					ObjectCreator = () => new ResponseOutputItemDoneEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseOutputItemDoneEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseOutputItemDoneEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseOutputItemDoneEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseOutputItemDoneEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseOutputItemDoneEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseOutputItemDoneEvent)obj).ResponseId,
				Setter = (object obj, string? value) =>
				{
					((ResponseOutputItemDoneEvent)obj).ResponseId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseId",
				JsonPropertyName = "response_id",
				AttributeProviderFactory = () => typeof(ResponseOutputItemDoneEvent).GetProperty("ResponseId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo2 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseOutputItemDoneEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseOutputItemDoneEvent)obj).OutputIndex,
				Setter = (object obj, int value) =>
				{
					((ResponseOutputItemDoneEvent)obj).OutputIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputIndex",
				JsonPropertyName = "output_index",
				AttributeProviderFactory = () => typeof(ResponseOutputItemDoneEvent).GetProperty("OutputIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<ConversationItem> propertyInfo3 = new JsonPropertyInfoValues<ConversationItem>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseOutputItemDoneEvent),
				Converter = null,
				Getter = (object obj) => ((ResponseOutputItemDoneEvent)obj).Item,
				Setter = (object obj, ConversationItem? value) =>
				{
					((ResponseOutputItemDoneEvent)obj).Item = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Item",
				JsonPropertyName = "item",
				AttributeProviderFactory = () => typeof(ResponseOutputItemDoneEvent).GetProperty("Item", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(ConversationItem), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			return array;
		}

		private void ResponseOutputItemDoneEventSerializeHandler(Utf8JsonWriter writer, ResponseOutputItemDoneEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string responseId = value.ResponseId;
			if (responseId != null)
			{
				writer.WriteString(PropName_response_id, responseId);
			}
			writer.WriteNumber(PropName_output_index, value.OutputIndex);
			ConversationItem item = value.Item;
			if (item != null)
			{
				writer.WritePropertyName(PropName_item);
				ConversationItemSerializeHandler(writer, item);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<ResponseResource> Create_ResponseResource(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<ResponseResource> jsonTypeInfo))
			{
				JsonObjectInfoValues<ResponseResource> objectInfo = new JsonObjectInfoValues<ResponseResource>
				{
					ObjectCreator = () => new ResponseResource(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => ResponseResourcePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(ResponseResource).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = ResponseResourceSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] ResponseResourcePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[6];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseResource),
				Converter = null,
				Getter = (object obj) => ((ResponseResource)obj).Id,
				Setter = (object obj, string? value) =>
				{
					((ResponseResource)obj).Id = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id",
				AttributeProviderFactory = () => typeof(ResponseResource).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseResource),
				Converter = null,
				Getter = (object obj) => ((ResponseResource)obj).Object,
				Setter = (object obj, string? value) =>
				{
					((ResponseResource)obj).Object = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Object",
				JsonPropertyName = "object",
				AttributeProviderFactory = () => typeof(ResponseResource).GetProperty("Object", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<Status> propertyInfo3 = new JsonPropertyInfoValues<Status>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseResource),
				Converter = null,
				Getter = (object obj) => ((ResponseResource)obj).Status,
				Setter = (object obj, Status value) =>
				{
					((ResponseResource)obj).Status = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Status",
				JsonPropertyName = "status",
				AttributeProviderFactory = () => typeof(ResponseResource).GetProperty("Status", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Status), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<Dictionary<string, string>> propertyInfo4 = new JsonPropertyInfoValues<Dictionary<string, string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseResource),
				Converter = null,
				Getter = (object obj) => ((ResponseResource)obj).StatusDetails,
				Setter = (object obj, Dictionary<string, string>? value) =>
				{
					((ResponseResource)obj).StatusDetails = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "StatusDetails",
				JsonPropertyName = "status_details",
				AttributeProviderFactory = () => typeof(ResponseResource).GetProperty("StatusDetails", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<string, string>), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<List<ConversationItem>> propertyInfo5 = new JsonPropertyInfoValues<List<ConversationItem>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseResource),
				Converter = null,
				Getter = (object obj) => ((ResponseResource)obj).Output,
				Setter = (object obj, List<ConversationItem>? value) =>
				{
					((ResponseResource)obj).Output = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Output",
				JsonPropertyName = "output",
				AttributeProviderFactory = () => typeof(ResponseResource).GetProperty("Output", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<ConversationItem>), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			JsonPropertyInfoValues<UsageResponse> propertyInfo6 = new JsonPropertyInfoValues<UsageResponse>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ResponseResource),
				Converter = null,
				Getter = (object obj) => ((ResponseResource)obj).Usage,
				Setter = (object obj, UsageResponse? value) =>
				{
					((ResponseResource)obj).Usage = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Usage",
				JsonPropertyName = "usage",
				AttributeProviderFactory = () => typeof(ResponseResource).GetProperty("Usage", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(UsageResponse), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			return array;
		}

		private void ResponseResourceSerializeHandler(Utf8JsonWriter writer, ResponseResource? value)
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
			string text = value.Object;
			if (text != null)
			{
				writer.WriteString(PropName_object, text);
			}
			writer.WritePropertyName(PropName_status);
			JsonSerializer.Serialize(writer, value.Status, Status);
			Dictionary<string, string> statusDetails = value.StatusDetails;
			if (statusDetails != null)
			{
				writer.WritePropertyName(PropName_status_details);
				DictionaryStringStringSerializeHandler(writer, statusDetails);
			}
			List<ConversationItem> output = value.Output;
			if (output != null)
			{
				writer.WritePropertyName(PropName_output);
				ListConversationItemSerializeHandler(writer, output);
			}
			UsageResponse usage = value.Usage;
			if ((object)usage != null)
			{
				writer.WritePropertyName(PropName_usage);
				UsageResponseSerializeHandler(writer, usage);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<Role> Create_Role(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Role> jsonTypeInfo))
			{
				JsonConverter converter = ExpandConverter(typeof(Role), new RoleJsonConverter(), options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<Role>(options, converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<Role?> Create_NullableRole(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Role?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<Role>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<Role?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<SessionConfig> Create_SessionConfig(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<SessionConfig> jsonTypeInfo))
			{
				JsonObjectInfoValues<SessionConfig> objectInfo = new JsonObjectInfoValues<SessionConfig>
				{
					ObjectCreator = () => new SessionConfig(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => SessionConfigPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(SessionConfig).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = SessionConfigSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] SessionConfigPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[11];
			JsonPropertyInfoValues<List<string>> propertyInfo = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).Modalities,
				Setter = (object obj, List<string>? value) =>
				{
					((SessionConfig)obj).Modalities = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Modalities",
				JsonPropertyName = "modalities",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("Modalities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).Instructions,
				Setter = (object obj, string? value) =>
				{
					((SessionConfig)obj).Instructions = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Instructions",
				JsonPropertyName = "instructions",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("Instructions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).Voice,
				Setter = (object obj, string? value) =>
				{
					((SessionConfig)obj).Voice = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Voice",
				JsonPropertyName = "voice",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("Voice", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<AudioFormat?> propertyInfo4 = new JsonPropertyInfoValues<AudioFormat?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).InputAudioFormat,
				Setter = (object obj, AudioFormat? value) =>
				{
					((SessionConfig)obj).InputAudioFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "InputAudioFormat",
				JsonPropertyName = "input_audio_format",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("InputAudioFormat", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AudioFormat?), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			JsonPropertyInfoValues<AudioFormat?> propertyInfo5 = new JsonPropertyInfoValues<AudioFormat?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).OutputAudioFormat,
				Setter = (object obj, AudioFormat? value) =>
				{
					((SessionConfig)obj).OutputAudioFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputAudioFormat",
				JsonPropertyName = "output_audio_format",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("OutputAudioFormat", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AudioFormat?), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<AudioTranscriptionConfig> propertyInfo6 = new JsonPropertyInfoValues<AudioTranscriptionConfig>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).InputAudioTranscription,
				Setter = (object obj, AudioTranscriptionConfig? value) =>
				{
					((SessionConfig)obj).InputAudioTranscription = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "InputAudioTranscription",
				JsonPropertyName = "input_audio_transcription",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("InputAudioTranscription", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AudioTranscriptionConfig), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<TurnDetectionConfig> propertyInfo7 = new JsonPropertyInfoValues<TurnDetectionConfig>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).TurnDetection,
				Setter = (object obj, TurnDetectionConfig? value) =>
				{
					((SessionConfig)obj).TurnDetection = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TurnDetection",
				JsonPropertyName = "turn_detection",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("TurnDetection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(TurnDetectionConfig), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<List<RealtimeToolDefinition>> propertyInfo8 = new JsonPropertyInfoValues<List<RealtimeToolDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).Tools,
				Setter = (object obj, List<RealtimeToolDefinition>? value) =>
				{
					((SessionConfig)obj).Tools = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Tools",
				JsonPropertyName = "tools",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("Tools", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<RealtimeToolDefinition>), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<string> propertyInfo9 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).ToolChoice,
				Setter = (object obj, string? value) =>
				{
					((SessionConfig)obj).ToolChoice = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolChoice",
				JsonPropertyName = "tool_choice",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("ToolChoice", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<double?> propertyInfo10 = new JsonPropertyInfoValues<double?>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).Temperature,
				Setter = (object obj, double? value) =>
				{
					((SessionConfig)obj).Temperature = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Temperature",
				JsonPropertyName = "temperature",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("Temperature", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(double?), Array.Empty<Type>(), null)
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<MaxOutputTokens> propertyInfo11 = new JsonPropertyInfoValues<MaxOutputTokens>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionConfig),
				Converter = null,
				Getter = (object obj) => ((SessionConfig)obj).MaxOutputTokens,
				Setter = (object obj, MaxOutputTokens? value) =>
				{
					((SessionConfig)obj).MaxOutputTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxOutputTokens",
				JsonPropertyName = "max_output_tokens",
				AttributeProviderFactory = () => typeof(SessionConfig).GetProperty("MaxOutputTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(MaxOutputTokens), Array.Empty<Type>(), null)
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			return array;
		}

		private void SessionConfigSerializeHandler(Utf8JsonWriter writer, SessionConfig? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			List<string> modalities = value.Modalities;
			if (modalities != null)
			{
				writer.WritePropertyName(PropName_modalities);
				ListStringSerializeHandler(writer, modalities);
			}
			string instructions = value.Instructions;
			if (instructions != null)
			{
				writer.WriteString(PropName_instructions, instructions);
			}
			string voice = value.Voice;
			if (voice != null)
			{
				writer.WriteString(PropName_voice, voice);
			}
			AudioFormat? inputAudioFormat = value.InputAudioFormat;
			if (inputAudioFormat.HasValue)
			{
				writer.WritePropertyName(PropName_input_audio_format);
				JsonSerializer.Serialize(writer, inputAudioFormat, NullableAudioFormat);
			}
			AudioFormat? outputAudioFormat = value.OutputAudioFormat;
			if (outputAudioFormat.HasValue)
			{
				writer.WritePropertyName(PropName_output_audio_format);
				JsonSerializer.Serialize(writer, outputAudioFormat, NullableAudioFormat);
			}
			AudioTranscriptionConfig inputAudioTranscription = value.InputAudioTranscription;
			if (inputAudioTranscription != null)
			{
				writer.WritePropertyName(PropName_input_audio_transcription);
				AudioTranscriptionConfigSerializeHandler(writer, inputAudioTranscription);
			}
			TurnDetectionConfig turnDetection = value.TurnDetection;
			if (turnDetection != null)
			{
				writer.WritePropertyName(PropName_turn_detection);
				TurnDetectionConfigSerializeHandler(writer, turnDetection);
			}
			List<RealtimeToolDefinition> tools = value.Tools;
			if (tools != null)
			{
				writer.WritePropertyName(PropName_tools);
				ListRealtimeToolDefinitionSerializeHandler(writer, tools);
			}
			string toolChoice = value.ToolChoice;
			if (toolChoice != null)
			{
				writer.WriteString(PropName_tool_choice, toolChoice);
			}
			double? temperature = value.Temperature;
			if (temperature.HasValue)
			{
				writer.WritePropertyName(PropName_temperature);
				JsonSerializer.Serialize(writer, temperature, NullableDouble);
			}
			MaxOutputTokens maxOutputTokens = value.MaxOutputTokens;
			if (maxOutputTokens != null)
			{
				writer.WritePropertyName(PropName_max_output_tokens);
				JsonSerializer.Serialize(writer, maxOutputTokens, MaxOutputTokens);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<SessionEvent> Create_SessionEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<SessionEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<SessionEvent> objectInfo = new JsonObjectInfoValues<SessionEvent>
				{
					ObjectCreator = () => new SessionEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => SessionEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(SessionEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = SessionEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] SessionEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<SessionResource> propertyInfo = new JsonPropertyInfoValues<SessionResource>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionEvent),
				Converter = null,
				Getter = (object obj) => ((SessionEvent)obj).Session,
				Setter = (object obj, SessionResource? value) =>
				{
					((SessionEvent)obj).Session = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Session",
				JsonPropertyName = "session",
				AttributeProviderFactory = () => typeof(SessionEvent).GetProperty("Session", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(SessionResource), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void SessionEventSerializeHandler(Utf8JsonWriter writer, SessionEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			SessionResource session = value.Session;
			if (session != null)
			{
				writer.WritePropertyName(PropName_session);
				SessionResourceSerializeHandler(writer, session);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<SessionResource> Create_SessionResource(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<SessionResource> jsonTypeInfo))
			{
				JsonObjectInfoValues<SessionResource> objectInfo = new JsonObjectInfoValues<SessionResource>
				{
					ObjectCreator = () => new SessionResource(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => SessionResourcePropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(SessionResource).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = SessionResourceSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] SessionResourcePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[14];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Id,
				Setter = (object obj, string? value) =>
				{
					((SessionResource)obj).Id = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Id",
				JsonPropertyName = "id",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Id", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Object,
				Setter = (object obj, string? value) =>
				{
					((SessionResource)obj).Object = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Object",
				JsonPropertyName = "object",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Object", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Model,
				Setter = (object obj, string? value) =>
				{
					((SessionResource)obj).Model = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Model",
				JsonPropertyName = "model",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Model", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<List<string>> propertyInfo4 = new JsonPropertyInfoValues<List<string>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Modalities,
				Setter = (object obj, List<string>? value) =>
				{
					((SessionResource)obj).Modalities = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Modalities",
				JsonPropertyName = "modalities",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Modalities", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo5 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Instructions,
				Setter = (object obj, string? value) =>
				{
					((SessionResource)obj).Instructions = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Instructions",
				JsonPropertyName = "instructions",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Instructions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<string> propertyInfo6 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Voice,
				Setter = (object obj, string? value) =>
				{
					((SessionResource)obj).Voice = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Voice",
				JsonPropertyName = "voice",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Voice", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			array[5].IsGetNullable = false;
			array[5].IsSetNullable = false;
			JsonPropertyInfoValues<AudioFormat> propertyInfo7 = new JsonPropertyInfoValues<AudioFormat>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).InputAudioFormat,
				Setter = (object obj, AudioFormat value) =>
				{
					((SessionResource)obj).InputAudioFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "InputAudioFormat",
				JsonPropertyName = "input_audio_format",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("InputAudioFormat", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AudioFormat), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<AudioFormat> propertyInfo8 = new JsonPropertyInfoValues<AudioFormat>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).OutputAudioFormat,
				Setter = (object obj, AudioFormat value) =>
				{
					((SessionResource)obj).OutputAudioFormat = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputAudioFormat",
				JsonPropertyName = "output_audio_format",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("OutputAudioFormat", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AudioFormat), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			JsonPropertyInfoValues<AudioTranscriptionConfig> propertyInfo9 = new JsonPropertyInfoValues<AudioTranscriptionConfig>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).InputAudioTranscription,
				Setter = (object obj, AudioTranscriptionConfig? value) =>
				{
					((SessionResource)obj).InputAudioTranscription = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "InputAudioTranscription",
				JsonPropertyName = "input_audio_transcription",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("InputAudioTranscription", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(AudioTranscriptionConfig), Array.Empty<Type>(), null)
			};
			array[8] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo9);
			JsonPropertyInfoValues<TurnDetectionConfig> propertyInfo10 = new JsonPropertyInfoValues<TurnDetectionConfig>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).TurnDetection,
				Setter = (object obj, TurnDetectionConfig? value) =>
				{
					((SessionResource)obj).TurnDetection = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "TurnDetection",
				JsonPropertyName = "turn_detection",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("TurnDetection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(TurnDetectionConfig), Array.Empty<Type>(), null)
			};
			array[9] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo10);
			JsonPropertyInfoValues<List<FunctionDefinition>> propertyInfo11 = new JsonPropertyInfoValues<List<FunctionDefinition>>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Tools,
				Setter = (object obj, List<FunctionDefinition>? value) =>
				{
					((SessionResource)obj).Tools = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Tools",
				JsonPropertyName = "tools",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Tools", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<FunctionDefinition>), Array.Empty<Type>(), null)
			};
			array[10] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo11);
			array[10].IsGetNullable = false;
			array[10].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo12 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).ToolChoice,
				Setter = (object obj, string? value) =>
				{
					((SessionResource)obj).ToolChoice = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ToolChoice",
				JsonPropertyName = "tool_choice",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("ToolChoice", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[11] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo12);
			array[11].IsGetNullable = false;
			array[11].IsSetNullable = false;
			JsonPropertyInfoValues<double> propertyInfo13 = new JsonPropertyInfoValues<double>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).Temperature,
				Setter = (object obj, double value) =>
				{
					((SessionResource)obj).Temperature = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Temperature",
				JsonPropertyName = "temperature",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("Temperature", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(double), Array.Empty<Type>(), null)
			};
			array[12] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo13);
			JsonPropertyInfoValues<MaxOutputTokens> propertyInfo14 = new JsonPropertyInfoValues<MaxOutputTokens>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionResource),
				Converter = null,
				Getter = (object obj) => ((SessionResource)obj).MaxOutputTokens,
				Setter = (object obj, MaxOutputTokens? value) =>
				{
					((SessionResource)obj).MaxOutputTokens = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "MaxOutputTokens",
				JsonPropertyName = "max_output_tokens",
				AttributeProviderFactory = () => typeof(SessionResource).GetProperty("MaxOutputTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(MaxOutputTokens), Array.Empty<Type>(), null)
			};
			array[13] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo14);
			return array;
		}

		private void SessionResourceSerializeHandler(Utf8JsonWriter writer, SessionResource? value)
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
			string text = value.Object;
			if (text != null)
			{
				writer.WriteString(PropName_object, text);
			}
			string model = value.Model;
			if (model != null)
			{
				writer.WriteString(PropName_model, model);
			}
			List<string> modalities = value.Modalities;
			if (modalities != null)
			{
				writer.WritePropertyName(PropName_modalities);
				ListStringSerializeHandler(writer, modalities);
			}
			string instructions = value.Instructions;
			if (instructions != null)
			{
				writer.WriteString(PropName_instructions, instructions);
			}
			string voice = value.Voice;
			if (voice != null)
			{
				writer.WriteString(PropName_voice, voice);
			}
			writer.WritePropertyName(PropName_input_audio_format);
			JsonSerializer.Serialize(writer, value.InputAudioFormat, AudioFormat);
			writer.WritePropertyName(PropName_output_audio_format);
			JsonSerializer.Serialize(writer, value.OutputAudioFormat, AudioFormat);
			AudioTranscriptionConfig inputAudioTranscription = value.InputAudioTranscription;
			if (inputAudioTranscription != null)
			{
				writer.WritePropertyName(PropName_input_audio_transcription);
				AudioTranscriptionConfigSerializeHandler(writer, inputAudioTranscription);
			}
			TurnDetectionConfig turnDetection = value.TurnDetection;
			if (turnDetection != null)
			{
				writer.WritePropertyName(PropName_turn_detection);
				TurnDetectionConfigSerializeHandler(writer, turnDetection);
			}
			List<FunctionDefinition> tools = value.Tools;
			if (tools != null)
			{
				writer.WritePropertyName(PropName_tools);
				ListFunctionDefinitionSerializeHandler(writer, tools);
			}
			string toolChoice = value.ToolChoice;
			if (toolChoice != null)
			{
				writer.WriteString(PropName_tool_choice, toolChoice);
			}
			writer.WriteNumber(PropName_temperature, value.Temperature);
			MaxOutputTokens maxOutputTokens = value.MaxOutputTokens;
			if (maxOutputTokens != null)
			{
				writer.WritePropertyName(PropName_max_output_tokens);
				JsonSerializer.Serialize(writer, maxOutputTokens, MaxOutputTokens);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<SessionUpdateRequest> Create_SessionUpdateRequest(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<SessionUpdateRequest> jsonTypeInfo))
			{
				JsonObjectInfoValues<SessionUpdateRequest> objectInfo = new JsonObjectInfoValues<SessionUpdateRequest>
				{
					ObjectCreator = () => new SessionUpdateRequest(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => SessionUpdateRequestPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(SessionUpdateRequest).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = SessionUpdateRequestSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] SessionUpdateRequestPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[3];
			JsonPropertyInfoValues<SessionConfig> propertyInfo = new JsonPropertyInfoValues<SessionConfig>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(SessionUpdateRequest),
				Converter = null,
				Getter = (object obj) => ((SessionUpdateRequest)obj).Session,
				Setter = (object obj, SessionConfig? value) =>
				{
					((SessionUpdateRequest)obj).Session = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Session",
				JsonPropertyName = "session",
				AttributeProviderFactory = () => typeof(SessionUpdateRequest).GetProperty("Session", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(SessionConfig), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			return array;
		}

		private void SessionUpdateRequestSerializeHandler(Utf8JsonWriter writer, SessionUpdateRequest? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			SessionConfig session = value.Session;
			if (session != null)
			{
				writer.WritePropertyName(PropName_session);
				SessionConfigSerializeHandler(writer, session);
			}
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<Status> Create_Status(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Status> jsonTypeInfo))
			{
				JsonConverter converter = ExpandConverter(typeof(Status), new StatusJsonConverter(), options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<Status>(options, converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<Status?> Create_NullableStatus(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Status?> jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<Status>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<Status?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private JsonTypeInfo<TextStreamEvent> Create_TextStreamEvent(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<TextStreamEvent> jsonTypeInfo))
			{
				JsonObjectInfoValues<TextStreamEvent> objectInfo = new JsonObjectInfoValues<TextStreamEvent>
				{
					ObjectCreator = () => new TextStreamEvent(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => TextStreamEventPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(TextStreamEvent).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = TextStreamEventSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] TextStreamEventPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[8];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(TextStreamEvent),
				Converter = null,
				Getter = (object obj) => ((TextStreamEvent)obj).Delta,
				Setter = (object obj, string? value) =>
				{
					((TextStreamEvent)obj).Delta = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Delta",
				JsonPropertyName = "delta",
				AttributeProviderFactory = () => typeof(TextStreamEvent).GetProperty("Delta", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			JsonPropertyInfoValues<string> propertyInfo2 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(TextStreamEvent),
				Converter = null,
				Getter = (object obj) => ((TextStreamEvent)obj).Text,
				Setter = (object obj, string? value) =>
				{
					((TextStreamEvent)obj).Text = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Text",
				JsonPropertyName = "text",
				AttributeProviderFactory = () => typeof(TextStreamEvent).GetProperty("Text", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<string> propertyInfo3 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ResponseId,
				Setter = (object obj, string? value) =>
				{
					((ContentStreamEventBase)obj).ResponseId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ResponseId",
				JsonPropertyName = "response_id",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ResponseId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
			JsonPropertyInfoValues<string> propertyInfo4 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ItemId,
				Setter = (object obj, string? value) =>
				{
					((ContentStreamEventBase)obj).ItemId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ItemId",
				JsonPropertyName = "item_id",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ItemId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			array[3].IsGetNullable = false;
			array[3].IsSetNullable = false;
			JsonPropertyInfoValues<int> propertyInfo5 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).OutputIndex,
				Setter = (object obj, int value) =>
				{
					((ContentStreamEventBase)obj).OutputIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "OutputIndex",
				JsonPropertyName = "output_index",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("OutputIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			JsonPropertyInfoValues<int> propertyInfo6 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(ContentStreamEventBase),
				Converter = null,
				Getter = (object obj) => ((ContentStreamEventBase)obj).ContentIndex,
				Setter = (object obj, int value) =>
				{
					((ContentStreamEventBase)obj).ContentIndex = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "ContentIndex",
				JsonPropertyName = "content_index",
				AttributeProviderFactory = () => typeof(ContentStreamEventBase).GetProperty("ContentIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			JsonPropertyInfoValues<string> propertyInfo7 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).EventId,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).EventId = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "EventId",
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			JsonPropertyInfoValues<string> propertyInfo8 = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(EventBase),
				Converter = null,
				Getter = (object obj) => ((EventBase)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((EventBase)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(EventBase).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			array[7].IsGetNullable = false;
			array[7].IsSetNullable = false;
			return array;
		}

		private void TextStreamEventSerializeHandler(Utf8JsonWriter writer, TextStreamEvent? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			string delta = value.Delta;
			if (delta != null)
			{
				writer.WriteString(PropName_delta, delta);
			}
			string text = value.Text;
			if (text != null)
			{
				writer.WriteString(PropName_text, text);
			}
			string responseId = value.ResponseId;
			if (responseId != null)
			{
				writer.WriteString(PropName_response_id, responseId);
			}
			string itemId = value.ItemId;
			if (itemId != null)
			{
				writer.WriteString(PropName_item_id, itemId);
			}
			writer.WriteNumber(PropName_output_index, value.OutputIndex);
			writer.WriteNumber(PropName_content_index, value.ContentIndex);
			string eventId = value.EventId;
			if (eventId != null)
			{
				writer.WriteString(PropName_event_id, eventId);
			}
			string type = value.Type;
			if (type != null)
			{
				writer.WriteString(PropName_type, type);
			}
			writer.WriteEndObject();
		}

		private JsonTypeInfo<TurnDetectionConfig> Create_TurnDetectionConfig(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<TurnDetectionConfig> jsonTypeInfo))
			{
				JsonObjectInfoValues<TurnDetectionConfig> objectInfo = new JsonObjectInfoValues<TurnDetectionConfig>
				{
					ObjectCreator = () => new TurnDetectionConfig(),
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = (JsonSerializerContext _) => TurnDetectionConfigPropInit(options),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = () => typeof(TurnDetectionConfig).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
					SerializeHandler = TurnDetectionConfigSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private static JsonPropertyInfo[] TurnDetectionConfigPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<string> propertyInfo = new JsonPropertyInfoValues<string>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(TurnDetectionConfig),
				Converter = null,
				Getter = (object obj) => ((TurnDetectionConfig)obj).Type,
				Setter = (object obj, string? value) =>
				{
					((TurnDetectionConfig)obj).Type = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Type",
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(TurnDetectionConfig).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<double> propertyInfo2 = new JsonPropertyInfoValues<double>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(TurnDetectionConfig),
				Converter = null,
				Getter = (object obj) => ((TurnDetectionConfig)obj).Threshold,
				Setter = (object obj, double value) =>
				{
					((TurnDetectionConfig)obj).Threshold = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "Threshold",
				JsonPropertyName = "threshold",
				AttributeProviderFactory = () => typeof(TurnDetectionConfig).GetProperty("Threshold", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(double), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			JsonPropertyInfoValues<int> propertyInfo3 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(TurnDetectionConfig),
				Converter = null,
				Getter = (object obj) => ((TurnDetectionConfig)obj).PrefixPaddingMs,
				Setter = (object obj, int value) =>
				{
					((TurnDetectionConfig)obj).PrefixPaddingMs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "PrefixPaddingMs",
				JsonPropertyName = "prefix_padding_ms",
				AttributeProviderFactory = () => typeof(TurnDetectionConfig).GetProperty("PrefixPaddingMs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			JsonPropertyInfoValues<int> propertyInfo4 = new JsonPropertyInfoValues<int>
			{
				IsProperty = true,
				IsPublic = true,
				IsVirtual = false,
				DeclaringType = typeof(TurnDetectionConfig),
				Converter = null,
				Getter = (object obj) => ((TurnDetectionConfig)obj).SilenceDurationMs,
				Setter = (object obj, int value) =>
				{
					((TurnDetectionConfig)obj).SilenceDurationMs = value;
				},
				IgnoreCondition = null,
				HasJsonInclude = false,
				IsExtensionData = false,
				NumberHandling = null,
				PropertyName = "SilenceDurationMs",
				JsonPropertyName = "silence_duration_ms",
				AttributeProviderFactory = () => typeof(TurnDetectionConfig).GetProperty("SilenceDurationMs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[3] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo4);
			return array;
		}

		private void TurnDetectionConfigSerializeHandler(Utf8JsonWriter writer, TurnDetectionConfig? value)
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
			writer.WriteNumber(PropName_threshold, value.Threshold);
			writer.WriteNumber(PropName_prefix_padding_ms, value.PrefixPaddingMs);
			writer.WriteNumber(PropName_silence_duration_ms, value.SilenceDurationMs);
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
					ConstructorAttributeProviderFactory = () => typeof(FunctionDefinition).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
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
				JsonPropertyName = "name",
				AttributeProviderFactory = () => typeof(FunctionDefinition).GetProperty("Name", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[0] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
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
				JsonPropertyName = "description",
				AttributeProviderFactory = () => typeof(FunctionDefinition).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "parameters",
				AttributeProviderFactory = () => typeof(FunctionDefinition).GetProperty("Parameters", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(PropertyDefinition), Array.Empty<Type>(), null)
			};
			array[2] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo3);
			array[2].IsGetNullable = false;
			array[2].IsSetNullable = false;
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
				JsonPropertyName = "strict",
				AttributeProviderFactory = () => typeof(FunctionDefinition).GetProperty("Strict", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool?), Array.Empty<Type>(), null)
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
					ConstructorAttributeProviderFactory = () => typeof(CompletionTokensDetails).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
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
				JsonPropertyName = "reasoning_tokens",
				AttributeProviderFactory = () => typeof(CompletionTokensDetails).GetProperty("ReasoningTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
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
				JsonPropertyName = "audio_tokens",
				AttributeProviderFactory = () => typeof(CompletionTokensDetails).GetProperty("AudioTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
			};
			array[1] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo2);
			return array;
		}

		private void CompletionTokensDetailsSerializeHandler(Utf8JsonWriter writer, CompletionTokensDetails? value)
		{
			if ((object)value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteNumber(PropName_reasoning_tokens, value.ReasoningTokens);
			writer.WriteNumber(PropName_audio_tokens, value.AudioTokens);
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
					ConstructorAttributeProviderFactory = () => typeof(Error).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
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
				JsonPropertyName = "code",
				AttributeProviderFactory = () => typeof(Error).GetProperty("Code", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "param",
				AttributeProviderFactory = () => typeof(Error).GetProperty("Param", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(Error).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "line",
				AttributeProviderFactory = () => typeof(Error).GetProperty("Line", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
				JsonPropertyName = null,
				AttributeProviderFactory = () => typeof(Error).GetProperty("Message", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = null,
				AttributeProviderFactory = () => typeof(Error).GetProperty("Messages", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<string>), Array.Empty<Type>(), null)
			};
			array[5] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo6);
			array[5].IsGetNullable = false;
			array[5].IsSetNullable = false;
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
				JsonPropertyName = "message",
				AttributeProviderFactory = () => typeof(Error).GetProperty("MessageObject", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(object), Array.Empty<Type>(), null)
			};
			array[6] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo7);
			array[6].IsSetNullable = false;
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
				JsonPropertyName = "event_id",
				AttributeProviderFactory = () => typeof(Error).GetProperty("EventId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
			};
			array[7] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo8);
			return array;
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
					ConstructorAttributeProviderFactory = () => typeof(PromptTokensDetails).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
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
				JsonPropertyName = "cached_tokens",
				AttributeProviderFactory = () => typeof(PromptTokensDetails).GetProperty("CachedTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "audio_tokens",
				AttributeProviderFactory = () => typeof(PromptTokensDetails).GetProperty("AudioTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
					ConstructorAttributeProviderFactory = () => typeof(UsageResponse).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
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
				JsonPropertyName = "prompt_tokens",
				AttributeProviderFactory = () => typeof(UsageResponse).GetProperty("PromptTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
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
				JsonPropertyName = "completion_tokens",
				AttributeProviderFactory = () => typeof(UsageResponse).GetProperty("CompletionTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "total_tokens",
				AttributeProviderFactory = () => typeof(UsageResponse).GetProperty("TotalTokens", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null)
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
				JsonPropertyName = "completion_tokens_details",
				AttributeProviderFactory = () => typeof(UsageResponse).GetProperty("CompletionTokensDetails", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(CompletionTokensDetails), Array.Empty<Type>(), null)
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
				JsonPropertyName = "prompt_tokens_details",
				AttributeProviderFactory = () => typeof(UsageResponse).GetProperty("PromptTokensDetails", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(PromptTokensDetails), Array.Empty<Type>(), null)
			};
			array[4] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo5);
			return array;
		}

		private void UsageResponseSerializeHandler(Utf8JsonWriter writer, UsageResponse? value)
		{
			if ((object)value == null)
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
			if ((object)completionTokensDetails != null)
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
					ConstructorAttributeProviderFactory = () => typeof(PropertyDefinition).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null),
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
				JsonPropertyName = null,
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Type", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "type",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("TypeList", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IList<string>), Array.Empty<Type>(), null)
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
				JsonPropertyName = "const",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Constant", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "properties",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Properties", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IDictionary<string, PropertyDefinition>), Array.Empty<Type>(), null)
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
				JsonPropertyName = "required",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Required", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IList<string>), Array.Empty<Type>(), null)
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
				JsonPropertyName = "additionalProperties",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("AdditionalProperties", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "title",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Title", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "description",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Description", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "enum",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Enum", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IList<string>), Array.Empty<Type>(), null)
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
				JsonPropertyName = "minProperties",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("MinProperties", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "maxProperties",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("MaxProperties", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "multipleOf",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("MultipleOf", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(float?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "minimum",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Minimum", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(float?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "exclusiveMinimum",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("ExclusiveMinimum", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(float?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "maximum",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Maximum", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(float?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "exclusiveMaximum",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("ExclusiveMaximum", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(float?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "format",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Format", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "pattern",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Pattern", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "minItems",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("MinItems", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "maxItems",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("MaxItems", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null)
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
				JsonPropertyName = "items",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Items", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(PropertyDefinition), Array.Empty<Type>(), null)
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
				JsonPropertyName = "$defs",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Defs", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IDictionary<string, PropertyDefinition>), Array.Empty<Type>(), null)
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
				JsonPropertyName = "definitions",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Definitions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IDictionary<string, PropertyDefinition>), Array.Empty<Type>(), null)
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
				JsonPropertyName = "$ref",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("Ref", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(string), Array.Empty<Type>(), null)
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
				JsonPropertyName = "anyOf",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("AnyOf", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IList<PropertyDefinition>), Array.Empty<Type>(), null)
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
				JsonPropertyName = "oneOf",
				AttributeProviderFactory = () => typeof(PropertyDefinition).GetProperty("OneOf", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(IList<PropertyDefinition>), Array.Empty<Type>(), null)
			};
			array[25] = JsonMetadataServices.CreatePropertyInfo(options, propertyInfo26);
			return array;
		}

		private JsonTypeInfo<Dictionary<string, JsonSchemaProperty>> Create_DictionaryStringJsonSchemaProperty(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<Dictionary<string, JsonSchemaProperty>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, JsonSchemaProperty>> collectionInfo = new JsonCollectionInfoValues<Dictionary<string, JsonSchemaProperty>>
				{
					ObjectCreator = () => new Dictionary<string, JsonSchemaProperty>(),
					SerializeHandler = DictionaryStringJsonSchemaPropertySerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, JsonSchemaProperty>, string, JsonSchemaProperty>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void DictionaryStringJsonSchemaPropertySerializeHandler(Utf8JsonWriter writer, Dictionary<string, JsonSchemaProperty>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			foreach (KeyValuePair<string, JsonSchemaProperty> item in value)
			{
				writer.WritePropertyName(item.Key);
				JsonSchemaPropertySerializeHandler(writer, item.Value);
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

		private JsonTypeInfo<List<ContentPart>> Create_ListContentPart(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ContentPart>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<ContentPart>> collectionInfo = new JsonCollectionInfoValues<List<ContentPart>>
				{
					ObjectCreator = () => new List<ContentPart>(),
					SerializeHandler = ListContentPartSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ContentPart>, ContentPart>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListContentPartSerializeHandler(Utf8JsonWriter writer, List<ContentPart>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				ContentPartSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<ConversationItem>> Create_ListConversationItem(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<ConversationItem>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<ConversationItem>> collectionInfo = new JsonCollectionInfoValues<List<ConversationItem>>
				{
					ObjectCreator = () => new List<ConversationItem>(),
					SerializeHandler = ListConversationItemSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ConversationItem>, ConversationItem>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListConversationItemSerializeHandler(Utf8JsonWriter writer, List<ConversationItem>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				ConversationItemSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<RateLimit>> Create_ListRateLimit(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<RateLimit>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<RateLimit>> collectionInfo = new JsonCollectionInfoValues<List<RateLimit>>
				{
					ObjectCreator = () => new List<RateLimit>(),
					SerializeHandler = ListRateLimitSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<RateLimit>, RateLimit>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListRateLimitSerializeHandler(Utf8JsonWriter writer, List<RateLimit>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				RateLimitSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<RealtimeToolDefinition>> Create_ListRealtimeToolDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<RealtimeToolDefinition>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<RealtimeToolDefinition>> collectionInfo = new JsonCollectionInfoValues<List<RealtimeToolDefinition>>
				{
					ObjectCreator = () => new List<RealtimeToolDefinition>(),
					SerializeHandler = ListRealtimeToolDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<RealtimeToolDefinition>, RealtimeToolDefinition>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListRealtimeToolDefinitionSerializeHandler(Utf8JsonWriter writer, List<RealtimeToolDefinition>? value)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartArray();
			for (int i = 0; i < value.Count; i++)
			{
				RealtimeToolDefinitionSerializeHandler(writer, value[i]);
			}
			writer.WriteEndArray();
		}

		private JsonTypeInfo<List<FunctionDefinition>> Create_ListFunctionDefinition(JsonSerializerOptions options)
		{
			if (!TryGetTypeInfoForRuntimeCustomConverter(options, out JsonTypeInfo<List<FunctionDefinition>> jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<FunctionDefinition>> collectionInfo = new JsonCollectionInfoValues<List<FunctionDefinition>>
				{
					ObjectCreator = () => new List<FunctionDefinition>(),
					SerializeHandler = ListFunctionDefinitionSerializeHandler
				};
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<FunctionDefinition>, FunctionDefinition>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		private void ListFunctionDefinitionSerializeHandler(Utf8JsonWriter writer, List<FunctionDefinition>? value)
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

		public RealtimeServiceJsonContext()
			: base(null)
		{
		}

		public RealtimeServiceJsonContext(JsonSerializerOptions options)
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
			if (type == typeof(AudioBufferAppendRequest))
			{
				return Create_AudioBufferAppendRequest(options);
			}
			if (type == typeof(AudioBufferClearedEvent))
			{
				return Create_AudioBufferClearedEvent(options);
			}
			if (type == typeof(AudioBufferClearRequest))
			{
				return Create_AudioBufferClearRequest(options);
			}
			if (type == typeof(AudioBufferCommitRequest))
			{
				return Create_AudioBufferCommitRequest(options);
			}
			if (type == typeof(AudioBufferCommittedEvent))
			{
				return Create_AudioBufferCommittedEvent(options);
			}
			if (type == typeof(AudioBufferSpeechStartedEvent))
			{
				return Create_AudioBufferSpeechStartedEvent(options);
			}
			if (type == typeof(AudioBufferSpeechStoppedEvent))
			{
				return Create_AudioBufferSpeechStoppedEvent(options);
			}
			if (type == typeof(AudioFormat))
			{
				return Create_AudioFormat(options);
			}
			if (type == typeof(AudioFormat?))
			{
				return Create_NullableAudioFormat(options);
			}
			if (type == typeof(AudioStreamEvent))
			{
				return Create_AudioStreamEvent(options);
			}
			if (type == typeof(AudioTranscriptionConfig))
			{
				return Create_AudioTranscriptionConfig(options);
			}
			if (type == typeof(AudioTranscriptStreamEvent))
			{
				return Create_AudioTranscriptStreamEvent(options);
			}
			if (type == typeof(ContentPart))
			{
				return Create_ContentPart(options);
			}
			if (type == typeof(ContentType))
			{
				return Create_ContentType(options);
			}
			if (type == typeof(ConversationCreatedEvent))
			{
				return Create_ConversationCreatedEvent(options);
			}
			if (type == typeof(ConversationItem))
			{
				return Create_ConversationItem(options);
			}
			if (type == typeof(ConversationItemCreatedEvent))
			{
				return Create_ConversationItemCreatedEvent(options);
			}
			if (type == typeof(ConversationItemCreateRequest))
			{
				return Create_ConversationItemCreateRequest(options);
			}
			if (type == typeof(ConversationItemDeletedEvent))
			{
				return Create_ConversationItemDeletedEvent(options);
			}
			if (type == typeof(ConversationItemDeleteRequest))
			{
				return Create_ConversationItemDeleteRequest(options);
			}
			if (type == typeof(ConversationItemTruncatedEvent))
			{
				return Create_ConversationItemTruncatedEvent(options);
			}
			if (type == typeof(ConversationItemTruncateRequest))
			{
				return Create_ConversationItemTruncateRequest(options);
			}
			if (type == typeof(ConversationResource))
			{
				return Create_ConversationResource(options);
			}
			if (type == typeof(ErrorEvent))
			{
				return Create_ErrorEvent(options);
			}
			if (type == typeof(FunctionCallStreamEvent))
			{
				return Create_FunctionCallStreamEvent(options);
			}
			if (type == typeof(InputAudioTranscriptionCompletedEvent))
			{
				return Create_InputAudioTranscriptionCompletedEvent(options);
			}
			if (type == typeof(InputAudioTranscriptionFailedEvent))
			{
				return Create_InputAudioTranscriptionFailedEvent(options);
			}
			if (type == typeof(ItemType))
			{
				return Create_ItemType(options);
			}
			if (type == typeof(JsonSchema))
			{
				return Create_JsonSchema(options);
			}
			if (type == typeof(JsonSchemaProperty))
			{
				return Create_JsonSchemaProperty(options);
			}
			if (type == typeof(MaxOutputTokens))
			{
				return Create_MaxOutputTokens(options);
			}
			if (type == typeof(RateLimit))
			{
				return Create_RateLimit(options);
			}
			if (type == typeof(RateLimitsEvent))
			{
				return Create_RateLimitsEvent(options);
			}
			if (type == typeof(RealtimeToolDefinition))
			{
				return Create_RealtimeToolDefinition(options);
			}
			if (type == typeof(ResponseCancelRequest))
			{
				return Create_ResponseCancelRequest(options);
			}
			if (type == typeof(ResponseConfig))
			{
				return Create_ResponseConfig(options);
			}
			if (type == typeof(ResponseContentPartEvent))
			{
				return Create_ResponseContentPartEvent(options);
			}
			if (type == typeof(ResponseCreateRequest))
			{
				return Create_ResponseCreateRequest(options);
			}
			if (type == typeof(ResponseEvent))
			{
				return Create_ResponseEvent(options);
			}
			if (type == typeof(ResponseOutputItemAddedEvent))
			{
				return Create_ResponseOutputItemAddedEvent(options);
			}
			if (type == typeof(ResponseOutputItemDoneEvent))
			{
				return Create_ResponseOutputItemDoneEvent(options);
			}
			if (type == typeof(ResponseResource))
			{
				return Create_ResponseResource(options);
			}
			if (type == typeof(Role))
			{
				return Create_Role(options);
			}
			if (type == typeof(Role?))
			{
				return Create_NullableRole(options);
			}
			if (type == typeof(SessionConfig))
			{
				return Create_SessionConfig(options);
			}
			if (type == typeof(SessionEvent))
			{
				return Create_SessionEvent(options);
			}
			if (type == typeof(SessionResource))
			{
				return Create_SessionResource(options);
			}
			if (type == typeof(SessionUpdateRequest))
			{
				return Create_SessionUpdateRequest(options);
			}
			if (type == typeof(Status))
			{
				return Create_Status(options);
			}
			if (type == typeof(Status?))
			{
				return Create_NullableStatus(options);
			}
			if (type == typeof(TextStreamEvent))
			{
				return Create_TextStreamEvent(options);
			}
			if (type == typeof(TurnDetectionConfig))
			{
				return Create_TurnDetectionConfig(options);
			}
			if (type == typeof(FunctionDefinition))
			{
				return Create_FunctionDefinition(options);
			}
			if (type == typeof(CompletionTokensDetails))
			{
				return Create_CompletionTokensDetails(options);
			}
			if (type == typeof(Error))
			{
				return Create_Error(options);
			}
			if (type == typeof(PromptTokensDetails))
			{
				return Create_PromptTokensDetails(options);
			}
			if (type == typeof(UsageResponse))
			{
				return Create_UsageResponse(options);
			}
			if (type == typeof(PropertyDefinition))
			{
				return Create_PropertyDefinition(options);
			}
			if (type == typeof(Dictionary<string, JsonSchemaProperty>))
			{
				return Create_DictionaryStringJsonSchemaProperty(options);
			}
			if (type == typeof(Dictionary<string, string>))
			{
				return Create_DictionaryStringString(options);
			}
			if (type == typeof(IDictionary<string, PropertyDefinition>))
			{
				return Create_IDictionaryStringPropertyDefinition(options);
			}
			if (type == typeof(IList<PropertyDefinition>))
			{
				return Create_IListPropertyDefinition(options);
			}
			if (type == typeof(IList<string>))
			{
				return Create_IListString(options);
			}
			if (type == typeof(List<ContentPart>))
			{
				return Create_ListContentPart(options);
			}
			if (type == typeof(List<ConversationItem>))
			{
				return Create_ListConversationItem(options);
			}
			if (type == typeof(List<RateLimit>))
			{
				return Create_ListRateLimit(options);
			}
			if (type == typeof(List<RealtimeToolDefinition>))
			{
				return Create_ListRealtimeToolDefinition(options);
			}
			if (type == typeof(List<FunctionDefinition>))
			{
				return Create_ListFunctionDefinition(options);
			}
			if (type == typeof(List<string>))
			{
				return Create_ListString(options);
			}
			if (type == typeof(int))
			{
				return Create_Int32(options);
			}
			if (type == typeof(int?))
			{
				return Create_NullableInt32(options);
			}
			if (type == typeof(object))
			{
				return Create_Object(options);
			}
			if (type == typeof(string))
			{
				return Create_String(options);
			}
			return null;
		}
	}
}
namespace Betalgo.Ranul.OpenAI.Managers
{
	public class OpenAIService : IAssistantService, IAudioService, IBatchService, IBetaService, IChatClient, IDisposable, IChatCompletionService, ICompletionService, IEditService, IEmbeddingService, IEmbeddingGenerator<string, Embedding<float>>, IEmbeddingGenerator, IFileService, IFineTuneService, IFineTuningJobService, IImageService, IMessageService, IModelService, IModerationService, IRunService, IRunStepService, IOpenAIService, IThreadService, IVectorStores, IVectorStoreFiles
	{
		private static readonly AIJsonSchemaTransformCache s_schemaTransformCache = new AIJsonSchemaTransformCache(new AIJsonSchemaTransformOptions
		{
			DisallowAdditionalProperties = true,
			RequireAllProperties = true,
			MoveDefaultKeywordToDescription = true
		});

		private ChatClientMetadata? _chatMetadata;

		private EmbeddingGeneratorMetadata? _embeddingMetadata;

		private readonly bool _disposeHttpClient;

		private readonly IOpenAIEndpointProvider _endpointProvider;

		private readonly HttpClient _httpClient;

		private string? _defaultModelId;

		public IAssistantService Assistants => this;

		public IMessageService Messages => this;

		public IThreadService Threads => this;

		public IRunService Runs => this;

		public IRunStepService RunSteps => this;

		public IVectorStores VectorStores => this;

		public IVectorStoreFiles VectorStoreFiles => this;

		public IModelService Models => this;

		public ICompletionService Completions => this;

		public IEmbeddingService Embeddings => this;

		public IFileService Files => this;

		public IFineTuneService FineTunes => this;

		public IFineTuningJobService FineTuningJob => this;

		public IModerationService Moderation => this;

		public IImageService Image => this;

		public IEditService Edit => this;

		public IChatCompletionService ChatCompletion => this;

		public IAudioService Audio => this;

		public IBatchService Batch => this;

		public IBetaService Beta => this;

		public async Task<AssistantResponse> AssistantCreate(AssistantCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			request.ProcessModelId(modelId, _defaultModelId);
			return await _httpClient.PostAndReadAsAsync<AssistantResponse>(_endpointProvider.AssistantCreate(), request, cancellationToken);
		}

		public async Task<AssistantListResponse> AssistantList(PaginationRequest? request = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<AssistantListResponse>(_endpointProvider.AssistantList(request), cancellationToken);
		}

		public async Task<AssistantResponse> AssistantRetrieve(string assistantId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(assistantId))
			{
				throw new ArgumentNullException("assistantId");
			}
			return await _httpClient.GetReadAsAsync<AssistantResponse>(_endpointProvider.AssistantRetrieve(assistantId), cancellationToken);
		}

		public async Task<AssistantResponse> AssistantModify(string assistantId, AssistantModifyRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(assistantId))
			{
				throw new ArgumentNullException("assistantId");
			}
			return await _httpClient.PostAndReadAsAsync<AssistantResponse>(_endpointProvider.AssistantModify(assistantId), request, cancellationToken);
		}

		public async Task<DeletionStatusResponse> AssistantDelete(string assistantId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(assistantId))
			{
				throw new ArgumentNullException("assistantId");
			}
			return await _httpClient.DeleteAndReadAsAsync<DeletionStatusResponse>(_endpointProvider.AssistantDelete(assistantId), cancellationToken);
		}

		public async Task<AudioCreateTranscriptionResponse> CreateTranscription(AudioCreateTranscriptionRequest audioCreateTranscriptionRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Create(audioCreateTranscriptionRequest, _endpointProvider.AudioCreateTranscription(), cancellationToken);
		}

		public async Task<AudioCreateTranscriptionResponse> CreateTranslation(AudioCreateTranscriptionRequest audioCreateTranscriptionRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Create(audioCreateTranscriptionRequest, _endpointProvider.AudioCreateTranslation(), cancellationToken);
		}

		public async Task<AudioCreateSpeechResponse<T>> CreateSpeech<T>(AudioCreateSpeechRequest audioCreateSpeechRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsDataAsync<AudioCreateSpeechResponse<T>, T>(_endpointProvider.AudioCreateSpeech(), audioCreateSpeechRequest, cancellationToken);
		}

		private async Task<AudioCreateTranscriptionResponse> Create(AudioCreateTranscriptionRequest audioCreateTranscriptionRequest, string uri, CancellationToken cancellationToken = default(CancellationToken))
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			if ((object)audioCreateTranscriptionRequest != null && audioCreateTranscriptionRequest.File != null && audioCreateTranscriptionRequest.FileStream != null)
			{
				throw new ArgumentException("Either File or FileStream must be set, but not both.");
			}
			if (audioCreateTranscriptionRequest.File != null)
			{
				multipartFormDataContent.Add(new ByteArrayContent(audioCreateTranscriptionRequest.File), "file", audioCreateTranscriptionRequest.FileName);
			}
			else if (audioCreateTranscriptionRequest.FileStream != null)
			{
				multipartFormDataContent.Add(new StreamContent(audioCreateTranscriptionRequest.FileStream), "file", audioCreateTranscriptionRequest.FileName);
			}
			multipartFormDataContent.Add(new StringContent(audioCreateTranscriptionRequest.Model), "model");
			if (audioCreateTranscriptionRequest.TimestampGranularities != null)
			{
				foreach (string timestampGranularity in audioCreateTranscriptionRequest.TimestampGranularities)
				{
					multipartFormDataContent.Add(new StringContent(timestampGranularity), "timestamp_granularities[]");
				}
			}
			if (audioCreateTranscriptionRequest.Language != null)
			{
				multipartFormDataContent.Add(new StringContent(audioCreateTranscriptionRequest.Language), "language");
			}
			if (audioCreateTranscriptionRequest.Prompt != null)
			{
				multipartFormDataContent.Add(new StringContent(audioCreateTranscriptionRequest.Prompt), "prompt");
			}
			if (audioCreateTranscriptionRequest.ResponseFormat != null)
			{
				multipartFormDataContent.Add(new StringContent(audioCreateTranscriptionRequest.ResponseFormat), "response_format");
			}
			if (audioCreateTranscriptionRequest.Temperature.HasValue)
			{
				multipartFormDataContent.Add(new StringContent(audioCreateTranscriptionRequest.Temperature.Value.ToString(CultureInfo.InvariantCulture)), "temperature");
			}
			if (audioCreateTranscriptionRequest.ResponseFormat == null || StaticValues.AudioStatics.ResponseFormat.Json == audioCreateTranscriptionRequest.ResponseFormat || StaticValues.AudioStatics.ResponseFormat.VerboseJson == audioCreateTranscriptionRequest.ResponseFormat)
			{
				return await _httpClient.PostFileAndReadAsAsync<AudioCreateTranscriptionResponse>(uri, multipartFormDataContent, cancellationToken);
			}
			(string, AudioCreateTranscriptionResponse) tuple = await _httpClient.PostFileAndReadAsStringAsync<AudioCreateTranscriptionResponse>(uri, multipartFormDataContent, cancellationToken);
			if (tuple.Item1 != null)
			{
				tuple.Item2.Text = tuple.Item1;
			}
			return tuple.Item2;
		}

		public async Task<BatchResponse> BatchCreate(BatchCreateRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<BatchResponse>(_endpointProvider.BatchCreate(), request, cancellationToken);
		}

		public async Task<BatchResponse?> BatchRetrieve(string batchId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<BatchResponse>(_endpointProvider.BatchRetrieve(batchId), cancellationToken);
		}

		public async Task<BatchResponse> BatchCancel(string batchId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<BatchResponse>(_endpointProvider.BatchCancel(batchId), null, cancellationToken);
		}

		object? IChatClient.GetService(Type serviceType, object? serviceKey)
		{
			object obj;
			if (serviceKey == null)
			{
				if (!(serviceType == typeof(ChatClientMetadata)))
				{
					if ((!(serviceType?.IsInstanceOfType(this))) ?? true)
					{
						return null;
					}
					return this;
				}
				obj = _chatMetadata;
				if (obj == null)
				{
					return _chatMetadata = new ChatClientMetadata("OpenAIService", _httpClient.BaseAddress, _defaultModelId);
				}
			}
			else
			{
				obj = null;
			}
			return obj;
		}

		void IDisposable.Dispose()
		{
		}

		async Task<ChatResponse> IChatClient.GetResponseAsync(IEnumerable<Microsoft.Extensions.AI.ChatMessage> messages, ChatOptions? options, CancellationToken cancellationToken)
		{
			ChatCompletionCreateRequest chatCompletionCreate = CreateRequest(messages, options);
			ChatCompletionCreateResponse chatCompletionCreateResponse = await ChatCompletion.CreateCompletion(chatCompletionCreate, options?.ModelId, cancellationToken);
			ThrowIfNotSuccessful(chatCompletionCreateResponse);
			string text = null;
			List<Microsoft.Extensions.AI.ChatMessage> list = new List<Microsoft.Extensions.AI.ChatMessage>();
			foreach (ChatChoiceResponse choice in chatCompletionCreateResponse.Choices)
			{
				if (text == null)
				{
					text = choice.FinishReason;
				}
				Microsoft.Extensions.AI.ChatMessage chatMessage = new Microsoft.Extensions.AI.ChatMessage
				{
					Role = new ChatRole(choice.Message.Role),
					AuthorName = choice.Message.Name,
					RawRepresentation = choice,
					MessageId = chatCompletionCreateResponse.Id
				};
				PopulateContents(choice.Message, chatMessage.Contents);
				string serviceTier = chatCompletionCreateResponse.ServiceTier;
				if (serviceTier != null)
				{
					Microsoft.Extensions.AI.ChatMessage chatMessage2 = chatMessage;
					(chatMessage2.AdditionalProperties ?? (chatMessage2.AdditionalProperties = new AdditionalPropertiesDictionary()))["ServiceTier"] = serviceTier;
				}
				string systemFingerPrint = chatCompletionCreateResponse.SystemFingerPrint;
				if (systemFingerPrint != null)
				{
					Microsoft.Extensions.AI.ChatMessage chatMessage2 = chatMessage;
					(chatMessage2.AdditionalProperties ?? (chatMessage2.AdditionalProperties = new AdditionalPropertiesDictionary()))["SystemFingerPrint"] = systemFingerPrint;
				}
				list.Add(chatMessage);
			}
			ChatResponse chatResponse = new ChatResponse(list)
			{
				CreatedAt = chatCompletionCreateResponse.CreatedAt,
				FinishReason = ((text != null) ? new ChatFinishReason?(new ChatFinishReason(text)) : ((ChatFinishReason?)null)),
				ModelId = chatCompletionCreateResponse.Model,
				RawRepresentation = chatCompletionCreateResponse,
				ResponseId = chatCompletionCreateResponse.Id
			};
			UsageResponse usage = chatCompletionCreateResponse.Usage;
			chatResponse.Usage = (((object)usage != null) ? GetUsageDetails(usage) : null);
			return chatResponse;
		}

		async IAsyncEnumerable<ChatResponseUpdate> IChatClient.GetStreamingResponseAsync(IEnumerable<Microsoft.Extensions.AI.ChatMessage> messages, ChatOptions? options, [EnumeratorCancellation] CancellationToken cancellationToken)
		{
			ChatCompletionCreateRequest chatCompletionCreate = CreateRequest(messages, options);
			await foreach (ChatCompletionCreateResponse response in ChatCompletion.CreateCompletionAsStream(chatCompletionCreate, options?.ModelId, justDataMode: true, cancellationToken))
			{
				ThrowIfNotSuccessful(response);
				foreach (ChatChoiceResponse choice in response.Choices)
				{
					ChatResponseUpdate chatResponseUpdate = new ChatResponseUpdate
					{
						AuthorName = choice.Delta.Name,
						CreatedAt = response.CreatedAt,
						FinishReason = ((choice.FinishReason != null) ? new ChatFinishReason?(new ChatFinishReason(choice.FinishReason)) : ((ChatFinishReason?)null)),
						ModelId = response.Model,
						RawRepresentation = response,
						ResponseId = response.Id,
						MessageId = response.Id,
						Role = ((choice.Delta.Role != null) ? new ChatRole?(new ChatRole(choice.Delta.Role)) : ((ChatRole?)null))
					};
					string serviceTier = response.ServiceTier;
					if (serviceTier != null)
					{
						ChatResponseUpdate chatResponseUpdate2 = chatResponseUpdate;
						(chatResponseUpdate2.AdditionalProperties ?? (chatResponseUpdate2.AdditionalProperties = new AdditionalPropertiesDictionary()))["ServiceTier"] = serviceTier;
					}
					string systemFingerPrint = response.SystemFingerPrint;
					if (systemFingerPrint != null)
					{
						ChatResponseUpdate chatResponseUpdate2 = chatResponseUpdate;
						(chatResponseUpdate2.AdditionalProperties ?? (chatResponseUpdate2.AdditionalProperties = new AdditionalPropertiesDictionary()))["SystemFingerPrint"] = systemFingerPrint;
					}
					PopulateContents(choice.Delta, chatResponseUpdate.Contents);
					yield return chatResponseUpdate;
					UsageResponse usage = response.Usage;
					if ((object)usage != null)
					{
						yield return new ChatResponseUpdate
						{
							AuthorName = choice.Delta.Name,
							Contents = new List<AIContent>(1)
							{
								new UsageContent(GetUsageDetails(usage))
							},
							CreatedAt = response.CreatedAt,
							FinishReason = ((choice.FinishReason != null) ? new ChatFinishReason?(new ChatFinishReason(choice.FinishReason)) : ((ChatFinishReason?)null)),
							ModelId = response.Model,
							ResponseId = response.Id,
							MessageId = response.Id,
							Role = ((choice.Delta.Role != null) ? new ChatRole?(new ChatRole(choice.Delta.Role)) : ((ChatRole?)null))
						};
					}
				}
			}
		}

		private static void ThrowIfNotSuccessful(ChatCompletionCreateResponse response)
		{
			if (!response.Successful)
			{
				throw new InvalidOperationException((response.Error != null) ? (response.Error.Code + ": " + response.Error.Message) : "Betalgo.Ranul Unknown error");
			}
		}

		private ChatCompletionCreateRequest CreateRequest(IEnumerable<Microsoft.Extensions.AI.ChatMessage> chatMessages, ChatOptions? options)
		{
			ChatCompletionCreateRequest chatCompletionCreateRequest = new ChatCompletionCreateRequest
			{
				Model = (options?.ModelId ?? _defaultModelId)
			};
			if (options != null)
			{
				chatCompletionCreateRequest.MaxCompletionTokens = options.MaxOutputTokens;
				chatCompletionCreateRequest.Temperature = options.Temperature;
				chatCompletionCreateRequest.TopP = options.TopP;
				chatCompletionCreateRequest.FrequencyPenalty = options.FrequencyPenalty;
				chatCompletionCreateRequest.PresencePenalty = options.PresencePenalty;
				chatCompletionCreateRequest.Seed = (int?)options.Seed;
				chatCompletionCreateRequest.StopAsList = options.StopSequences;
				chatCompletionCreateRequest.ParallelToolCalls = options.AllowMultipleToolCalls;
				object value = default;
				chatCompletionCreateRequest.LogitBias = ((options.AdditionalProperties?.TryGetValue("LogitBias", out value) ?? false) ? value : null);
				bool value2 = default;
				chatCompletionCreateRequest.LogProbs = ((options.AdditionalProperties?.TryGetValue("LogProbs", out value2) ?? false) ? new bool?(value2) : ((bool?)null));
				int value3 = default;
				chatCompletionCreateRequest.N = ((options.AdditionalProperties?.TryGetValue("N", out value3) ?? false) ? new int?(value3) : ((int?)null));
				string value4 = default;
				chatCompletionCreateRequest.ServiceTier = ((options.AdditionalProperties?.TryGetValue("ServiceTier", out value4) ?? false) ? value4 : null);
				string value5 = default;
				chatCompletionCreateRequest.User = ((options.AdditionalProperties?.TryGetValue("User", out value5) ?? false) ? value5 : null);
				int value6 = default;
				chatCompletionCreateRequest.TopLogprobs = ((options.AdditionalProperties?.TryGetValue("TopLogprobs", out value6) ?? false) ? new int?(value6) : ((int?)null));
				ChatResponseFormat responseFormat = options.ResponseFormat;
				if (!(responseFormat is ChatResponseFormatText))
				{
					if (responseFormat is ChatResponseFormatJson { Schema: var schema } chatResponseFormatJson)
					{
						if (schema.HasValue)
						{
							chatCompletionCreateRequest.ResponseFormat = new ResponseFormat
							{
								Type = StaticValues.CompletionStatics.ResponseFormat.JsonSchema,
								JsonSchema = new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.JsonSchema
								{
									Name = (chatResponseFormatJson.SchemaName ?? "JsonSchema"),
									Schema = chatResponseFormatJson.Schema.Value.Deserialize<PropertyDefinition>(),
									Description = chatResponseFormatJson.SchemaDescription
								}
							};
						}
						else
						{
							chatCompletionCreateRequest.ResponseFormat = new ResponseFormat
							{
								Type = StaticValues.CompletionStatics.ResponseFormat.Json
							};
						}
					}
				}
				else
				{
					chatCompletionCreateRequest.ResponseFormat = new ResponseFormat
					{
						Type = StaticValues.CompletionStatics.ResponseFormat.Text
					};
				}
				IList<AITool>? tools = options.Tools;
				List<ToolDefinition> list = ((tools != null) ? (from f in tools.OfType<AIFunction>()
					select ToolDefinition.DefineFunction(new FunctionDefinition
					{
						Name = f.Name,
						Description = f.Description,
						Parameters = CreateParameters(f)
					})).ToList() : null);
				chatCompletionCreateRequest.Tools = ((list != null && list.Count > 0) ? list : null);
				if (chatCompletionCreateRequest.Tools != null)
				{
					ToolChoice toolChoice;
					if (options.ToolMode is RequiredChatToolMode requiredChatToolMode)
					{
						toolChoice = new ToolChoice
						{
							Type = StaticValues.CompletionStatics.ToolChoiceType.Required,
							Function = ((requiredChatToolMode.RequiredFunctionName == null) ? null : new ToolChoice.FunctionTool
							{
								Name = requiredChatToolMode.RequiredFunctionName
							})
						};
					}
					else
					{
						ChatToolMode toolMode = options.ToolMode;
						bool flag = ((toolMode is AutoChatToolMode || toolMode == null) ? true : false);
						toolChoice = (flag ? new ToolChoice
						{
							Type = StaticValues.CompletionStatics.ToolChoiceType.Auto
						} : new ToolChoice
						{
							Type = StaticValues.CompletionStatics.ToolChoiceType.None
						});
					}
					chatCompletionCreateRequest.ToolChoice = toolChoice;
				}
			}
			chatCompletionCreateRequest.Messages = new List<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage>();
			string value7 = default;
			foreach (Microsoft.Extensions.AI.ChatMessage chatMessage3 in chatMessages)
			{
				foreach (AIContent content in chatMessage3.Contents)
				{
					if (!(content is TextContent textContent))
					{
						if (!(content is UriContent uriContent))
						{
							if (!(content is DataContent dataContent))
							{
								if (content is FunctionResultContent functionResultContent)
								{
									chatCompletionCreateRequest.Messages.Add(new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage
									{
										ToolCallId = functionResultContent.CallId,
										Content = functionResultContent.Result?.ToString(),
										Name = chatMessage3.AuthorName,
										Role = chatMessage3.Role.ToString()
									});
								}
								continue;
							}
							IList<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage> messages = chatCompletionCreateRequest.Messages;
							Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage chatMessage = new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage();
							int num = 1;
							List<MessageContent> list2 = new List<MessageContent>(num);
							CollectionsMarshal.SetCount(list2, num);
							Span<MessageContent> span = CollectionsMarshal.AsSpan(list2);
							int index = 0;
							span[index] = new MessageContent
							{
								Type = "image_url",
								ImageUrl = new MessageImageUrl
								{
									Url = dataContent.Uri.ToString(),
									Detail = ((dataContent.AdditionalProperties?.TryGetValue("Detail", out value7) ?? false) ? value7 : null)
								}
							};
							chatMessage.Contents = list2;
							chatMessage.Name = chatMessage3.AuthorName;
							chatMessage.Role = chatMessage3.Role.ToString();
							messages.Add(chatMessage);
						}
						else
						{
							IList<Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage> messages2 = chatCompletionCreateRequest.Messages;
							Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage chatMessage2 = new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage();
							int index = 1;
							List<MessageContent> list3 = new List<MessageContent>(index);
							CollectionsMarshal.SetCount(list3, index);
							Span<MessageContent> span = CollectionsMarshal.AsSpan(list3);
							int num = 0;
							span[num] = new MessageContent
							{
								Type = "image_url",
								ImageUrl = new MessageImageUrl
								{
									Url = uriContent.Uri.ToString(),
									Detail = ((uriContent.AdditionalProperties?.TryGetValue("Detail", out value7) ?? false) ? value7 : null)
								}
							};
							chatMessage2.Contents = list3;
							chatMessage2.Name = chatMessage3.AuthorName;
							chatMessage2.Role = chatMessage3.Role.ToString();
							messages2.Add(chatMessage2);
						}
					}
					else
					{
						chatCompletionCreateRequest.Messages.Add(new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage
						{
							Content = textContent.Text,
							Name = chatMessage3.AuthorName,
							Role = chatMessage3.Role.ToString()
						});
					}
				}
				FunctionCallContent[] array = chatMessage3.Contents.OfType<FunctionCallContent>().ToArray();
				if (array.Length != 0)
				{
					chatCompletionCreateRequest.Messages.Add(new Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage
					{
						Name = chatMessage3.AuthorName,
						Role = chatMessage3.Role.ToString(),
						ToolCalls = array.Select((FunctionCallContent fcc) => new ToolCall
						{
							Type = "function",
							Id = fcc.CallId,
							FunctionCall = new FunctionCall
							{
								Name = fcc.Name,
								Arguments = JsonSerializer.Serialize(fcc.Arguments)
							}
						}).ToList()
					});
				}
			}
			return chatCompletionCreateRequest;
		}

		private static PropertyDefinition CreateParameters(AIFunction f)
		{
			return s_schemaTransformCache.GetOrCreateTransformedSchema(f).Deserialize<PropertyDefinition>() ?? new PropertyDefinition();
		}

		private static void PopulateContents(Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage source, IList<AIContent> destination)
		{
			if (source.Content != null)
			{
				destination.Add(new TextContent(source.Content));
			}
			IList<MessageContent> contents = source.Contents;
			if (contents != null)
			{
				foreach (MessageContent item in contents)
				{
					string text = item.Text;
					if (text != null)
					{
						destination.Add(new TextContent(text));
					}
					MessageImageUrl imageUrl = item.ImageUrl;
					if (imageUrl != null)
					{
						destination.Add(new UriContent(imageUrl.Url, "image/*"));
					}
				}
			}
			IList<ToolCall> toolCalls = source.ToolCalls;
			if (toolCalls == null)
			{
				return;
			}
			foreach (ToolCall item2 in toolCalls)
			{
				string? callId = item2.Id ?? string.Empty;
				string? name = item2.FunctionCall?.Name ?? string.Empty;
				string text2 = item2.FunctionCall?.Arguments;
				destination.Add(new FunctionCallContent(callId, name, (text2 != null) ? JsonSerializer.Deserialize<Dictionary<string, object>>(text2) : null));
			}
		}

		private static UsageDetails GetUsageDetails(UsageResponse usage)
		{
			UsageDetails usageDetails = new UsageDetails
			{
				InputTokenCount = usage.PromptTokens,
				OutputTokenCount = usage.CompletionTokens,
				TotalTokenCount = usage.TotalTokens
			};
			PromptTokensDetails promptTokensDetails = usage.PromptTokensDetails;
			if (promptTokensDetails != null)
			{
				int? cachedTokens = promptTokensDetails.CachedTokens;
				if (cachedTokens.HasValue)
				{
					int valueOrDefault = cachedTokens.GetValueOrDefault();
					UsageDetails usageDetails2 = usageDetails;
					(usageDetails2.AdditionalCounts ?? (usageDetails2.AdditionalCounts = new AdditionalPropertiesDictionary<long>()))["PromptTokensDetails.CachedTokens"] = valueOrDefault;
				}
				cachedTokens = promptTokensDetails.AudioTokens;
				if (cachedTokens.HasValue)
				{
					int valueOrDefault2 = cachedTokens.GetValueOrDefault();
					UsageDetails usageDetails2 = usageDetails;
					(usageDetails2.AdditionalCounts ?? (usageDetails2.AdditionalCounts = new AdditionalPropertiesDictionary<long>()))["PromptTokensDetails.AudioTokens"] = valueOrDefault2;
				}
			}
			CompletionTokensDetails completionTokensDetails = usage.CompletionTokensDetails;
			if ((object)completionTokensDetails != null)
			{
				int reasoningTokens = completionTokensDetails.ReasoningTokens;
				UsageDetails usageDetails2 = usageDetails;
				(usageDetails2.AdditionalCounts ?? (usageDetails2.AdditionalCounts = new AdditionalPropertiesDictionary<long>()))["CompletionTokensDetails.ReasoningTokens"] = reasoningTokens;
				int audioTokens = completionTokensDetails.AudioTokens;
				usageDetails2 = usageDetails;
				(usageDetails2.AdditionalCounts ?? (usageDetails2.AdditionalCounts = new AdditionalPropertiesDictionary<long>()))["CompletionTokensDetails.AudioTokens"] = audioTokens;
			}
			return usageDetails;
		}

		public async Task<ChatCompletionCreateResponse> CreateCompletion(ChatCompletionCreateRequest chatCompletionCreateRequest, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			chatCompletionCreateRequest.ProcessModelId(modelId, _defaultModelId);
			return await _httpClient.PostAndReadAsAsync<ChatCompletionCreateResponse>(_endpointProvider.ChatCompletionCreate(), chatCompletionCreateRequest, cancellationToken);
		}

		public async IAsyncEnumerable<ChatCompletionCreateResponse> CreateCompletionAsStream(ChatCompletionCreateRequest chatCompletionCreateRequest, string? modelId = null, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
		{
			chatCompletionCreateRequest.Stream = true;
			chatCompletionCreateRequest.ProcessModelId(modelId, _defaultModelId);
			using HttpResponseMessage response = _httpClient.PostAsStreamAsync(_endpointProvider.ChatCompletionCreate(), chatCompletionCreateRequest, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				yield return await response.HandleResponseContent<ChatCompletionCreateResponse>(cancellationToken);
				yield break;
			}
			await foreach (ChatCompletionCreateResponse item in response.AsStream<ChatCompletionCreateResponse>(justDataMode: true, cancellationToken))
			{
				yield return item;
			}
		}

		public async Task<CompletionCreateResponse> CreateCompletion(CompletionCreateRequest createCompletionRequest, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			createCompletionRequest.ProcessModelId(modelId, _defaultModelId);
			return await _httpClient.PostAndReadAsAsync<CompletionCreateResponse>(_endpointProvider.CompletionCreate(), createCompletionRequest, cancellationToken);
		}

		public async IAsyncEnumerable<CompletionCreateResponse> CreateCompletionAsStream(CompletionCreateRequest createCompletionRequest, string? modelId = null, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
		{
			createCompletionRequest.Stream = true;
			createCompletionRequest.ProcessModelId(modelId, _defaultModelId);
			using HttpResponseMessage response = _httpClient.PostAsStreamAsync(_endpointProvider.CompletionCreate(), createCompletionRequest, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				yield return await response.HandleResponseContent<CompletionCreateResponse>(cancellationToken);
				yield break;
			}
			HttpStatusCode httpStatusCode = response.StatusCode;
			ResponseHeaderValues headerValues = response.ParseHeaders();
			await using Stream stream = await response.Content.ReadAsStreamAsync();
			using StreamReader reader = new StreamReader(stream);
			while (!reader.EndOfStream)
			{
				cancellationToken.ThrowIfCancellationRequested();
				string text = await reader.ReadLineAsync();
				if (!string.IsNullOrEmpty(text))
				{
					text = text.RemoveIfStartWith("data: ");
					if (text.StartsWith("[DONE]"))
					{
						break;
					}
					CompletionCreateResponse block;
					try
					{
						block = JsonSerializer.Deserialize<CompletionCreateResponse>(text);
					}
					catch (Exception)
					{
						string text2 = text;
						text = text2 + await reader.ReadToEndAsync();
						block = JsonSerializer.Deserialize<CompletionCreateResponse>(text);
					}
					if (null != block)
					{
						block.HttpStatusCode = httpStatusCode;
						block.HeaderValues = headerValues;
						yield return block;
					}
				}
			}
		}

		public async Task<EditCreateResponse> CreateEdit(EditCreateRequest editCreate, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			editCreate.ProcessModelId(modelId, _defaultModelId);
			return await _httpClient.PostAndReadAsAsync<EditCreateResponse>(_endpointProvider.EditCreate(), editCreate, cancellationToken);
		}

		public async Task<EmbeddingCreateResponse> CreateEmbedding(EmbeddingCreateRequest createEmbeddingRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<EmbeddingCreateResponse>(_endpointProvider.EmbeddingCreate(), createEmbeddingRequest, cancellationToken);
		}

		object? IEmbeddingGenerator.GetService(Type serviceType, object? serviceKey)
		{
			object obj;
			if (serviceKey == null)
			{
				if (!(serviceType == typeof(EmbeddingGeneratorMetadata)))
				{
					if ((!(serviceType?.IsInstanceOfType(this))) ?? true)
					{
						return null;
					}
					return this;
				}
				obj = _embeddingMetadata;
				if (obj == null)
				{
					return _embeddingMetadata = new EmbeddingGeneratorMetadata("OpenAIService", _httpClient.BaseAddress, _defaultModelId);
				}
			}
			else
			{
				obj = null;
			}
			return obj;
		}

		async Task<GeneratedEmbeddings<Embedding<float>>> IEmbeddingGenerator<string, Embedding<float>>.GenerateAsync(IEnumerable<string> values, EmbeddingGenerationOptions? options, CancellationToken cancellationToken)
		{
			EmbeddingCreateResponse response = await Embeddings.CreateEmbedding(new EmbeddingCreateRequest
			{
				Model = (options?.ModelId ?? _defaultModelId),
				Dimensions = options?.Dimensions,
				InputAsList = values.ToList()
			}, cancellationToken);
			if (!response.Successful)
			{
				throw new InvalidOperationException((response.Error != null) ? (response.Error.Code + ": " + response.Error.Message) : "Betalgo.Ranul Unknown error");
			}
			GeneratedEmbeddings<Embedding<float>> generatedEmbeddings = new GeneratedEmbeddings<Embedding<float>>(response.Data.Select((EmbeddingResponse e) => new Embedding<float>(e.Embedding.Select((double d) => (float)d).ToArray())
			{
				ModelId = response.Model
			}));
			UsageResponse usage = response.Usage;
			generatedEmbeddings.Usage = (((object)usage != null) ? new UsageDetails
			{
				InputTokenCount = usage.PromptTokens,
				OutputTokenCount = usage.CompletionTokens,
				TotalTokenCount = usage.TotalTokens
			} : null);
			return generatedEmbeddings;
		}

		public async Task<FileListResponse> ListFile(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<FileListResponse>(_endpointProvider.FilesList(), cancellationToken);
		}

		public async Task<FileUploadResponse> UploadFile(string purpose, byte[] file, string fileName, CancellationToken cancellationToken = default(CancellationToken))
		{
			MultipartFormDataContent content = new MultipartFormDataContent
			{
				{
					new StringContent(purpose),
					"purpose"
				},
				{
					new ByteArrayContent(file),
					"file",
					fileName
				}
			};
			return await _httpClient.PostFileAndReadAsAsync<FileUploadResponse>(_endpointProvider.FilesUpload(), content, cancellationToken);
		}

		public async Task<FileDeleteResponse> DeleteFile(string fileId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.DeleteAndReadAsAsync<FileDeleteResponse>(_endpointProvider.FileDelete(fileId), cancellationToken);
		}

		public async Task<FileResponse> RetrieveFile(string fileId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<FileResponse>(_endpointProvider.FileRetrieve(fileId), cancellationToken);
		}

		public async Task<FileContentResponse<T?>> RetrieveFileContent<T>(string fileId, CancellationToken cancellationToken = default(CancellationToken))
		{
			HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(_endpointProvider.FileRetrieveContent(fileId), cancellationToken);
			FileContentResponse<T?> fileContentResponse2;
			FileContentResponse<T?> fileContentResponse;
			if (typeof(T) == typeof(string))
			{
				fileContentResponse = new FileContentResponse<T>();
				fileContentResponse2 = fileContentResponse;
				fileContentResponse2.Content = (T)(object)(await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));
				return fileContentResponse;
			}
			if (typeof(T) == typeof(byte[]))
			{
				fileContentResponse2 = new FileContentResponse<T>();
				fileContentResponse = fileContentResponse2;
				fileContentResponse.Content = (T)(object)(await httpResponseMessage.Content.ReadAsByteArrayAsync(cancellationToken));
				return fileContentResponse2;
			}
			if (typeof(T) == typeof(Stream))
			{
				fileContentResponse = new FileContentResponse<T>();
				fileContentResponse2 = fileContentResponse;
				fileContentResponse2.Content = (T)(object)(await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken));
				return fileContentResponse;
			}
			fileContentResponse2 = new FileContentResponse<T>();
			fileContentResponse = fileContentResponse2;
			fileContentResponse.Content = await httpResponseMessage.Content.ReadFromJsonAsync<T>(cancellationToken);
			return fileContentResponse2;
		}

		public async Task<FineTuneResponse> CreateFineTune(FineTuneCreateRequest createFineTuneRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<FineTuneResponse>(_endpointProvider.FineTuneCreate(), createFineTuneRequest, cancellationToken);
		}

		public async Task<FineTuneListResponse> ListFineTunes(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<FineTuneListResponse>(_endpointProvider.FineTuneList(), cancellationToken);
		}

		public async Task<FineTuneResponse> RetrieveFineTune(string fineTuneId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<FineTuneResponse>(_endpointProvider.FineTuneRetrieve(fineTuneId), cancellationToken);
		}

		public async Task<FineTuneResponse> CancelFineTune(string fineTuneId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<FineTuneResponse>(_endpointProvider.FineTuneCancel(fineTuneId), new FineTuneCancelRequest
			{
				FineTuneId = fineTuneId
			}, cancellationToken);
		}

		public async Task<Stream> ListFineTuneEvents(string fineTuneId, bool? stream = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetStreamAsync(_endpointProvider.FineTuneListEvents(fineTuneId), cancellationToken);
		}

		public async Task DeleteFineTune(string fineTuneId, CancellationToken cancellationToken = default(CancellationToken))
		{
			await _httpClient.DeleteAsync(_endpointProvider.FineTuneDelete(fineTuneId), cancellationToken);
		}

		public async Task<FineTuningJobResponse> CreateFineTuningJob(FineTuningJobCreateRequest createFineTuningJobRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<FineTuningJobResponse>(_endpointProvider.FineTuningJobCreate(), createFineTuningJobRequest, cancellationToken);
		}

		public async Task<FineTuningJobListResponse> ListFineTuningJobs(FineTuningJobListRequest? fineTuningJobListRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<FineTuningJobListResponse>(_endpointProvider.FineTuningJobList(fineTuningJobListRequest), cancellationToken);
		}

		public async Task<FineTuningJobResponse> RetrieveFineTuningJob(string fineTuningJobId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<FineTuningJobResponse>(_endpointProvider.FineTuningJobRetrieve(fineTuningJobId), cancellationToken);
		}

		public async Task<FineTuningJobResponse> CancelFineTuningJob(string fineTuningJobId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<FineTuningJobResponse>(_endpointProvider.FineTuningJobCancel(fineTuningJobId), null, cancellationToken);
		}

		public async Task<Stream> ListFineTuningJobEvents(FineTuningJobListEventsRequest fineTuningJobRequestModel, bool? stream = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetStreamAsync(_endpointProvider.FineTuningJobListEvents(fineTuningJobRequestModel.FineTuningJobId), cancellationToken);
		}

		public async Task<ImageCreateResponse> CreateImage(ImageCreateRequest imageCreateModel, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<ImageCreateResponse>(_endpointProvider.ImageCreate(), imageCreateModel, cancellationToken);
		}

		public async Task<ImageCreateResponse> CreateImageEdit(ImageEditCreateRequest imageEditCreateRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			if (imageEditCreateRequest.User != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.User), "user");
			}
			if (imageEditCreateRequest.ResponseFormat != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.ResponseFormat), "response_format");
			}
			if (imageEditCreateRequest.Size != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.Size), "size");
			}
			if (imageEditCreateRequest.N.HasValue)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.N.Value.ToString(CultureInfo.InvariantCulture)), "n");
			}
			if (imageEditCreateRequest.Model != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.Model), "model");
			}
			if (imageEditCreateRequest.Mask != null)
			{
				multipartFormDataContent.Add(new ByteArrayContent(imageEditCreateRequest.Mask), "mask", imageEditCreateRequest.MaskName);
			}
			multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.Prompt), "prompt");
			multipartFormDataContent.Add(new ByteArrayContent(imageEditCreateRequest.Image), "image", imageEditCreateRequest.ImageName);
			return await _httpClient.PostFileAndReadAsAsync<ImageCreateResponse>(_endpointProvider.ImageEditCreate(), multipartFormDataContent, cancellationToken);
		}

		public async Task<ImageCreateResponse> CreateImageVariation(ImageVariationCreateRequest imageEditCreateRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			if (imageEditCreateRequest.User != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.User), "user");
			}
			if (imageEditCreateRequest.ResponseFormat != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.ResponseFormat), "response_format");
			}
			if (imageEditCreateRequest.Size != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.Size), "size");
			}
			if (imageEditCreateRequest.N.HasValue)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.N.Value.ToString(CultureInfo.InvariantCulture)), "n");
			}
			if (imageEditCreateRequest.Model != null)
			{
				multipartFormDataContent.Add(new StringContent(imageEditCreateRequest.Model), "model");
			}
			multipartFormDataContent.Add(new ByteArrayContent(imageEditCreateRequest.Image), "image", imageEditCreateRequest.ImageName);
			return await _httpClient.PostFileAndReadAsAsync<ImageCreateResponse>(_endpointProvider.ImageVariationCreate(), multipartFormDataContent, cancellationToken);
		}

		public async Task<MessageResponse> CreateMessage(string threadId, MessageCreateRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			return await _httpClient.PostAndReadAsAsync<MessageResponse>(_endpointProvider.MessageCreate(threadId), request, cancellationToken);
		}

		public async Task<MessageListResponse> ListMessages(string threadId, MessageListRequest? request = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			return await _httpClient.GetReadAsAsync<MessageListResponse>(_endpointProvider.MessageList(threadId, request), cancellationToken);
		}

		public async Task<MessageResponse> RetrieveMessage(string threadId, string messageId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<MessageResponse>(_endpointProvider.MessageRetrieve(threadId, messageId), cancellationToken);
		}

		public async Task<MessageResponse> ModifyMessage(string threadId, string messageId, ModifyMessageRequest requestBody, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<MessageResponse>(_endpointProvider.MessageModify(threadId, messageId), requestBody, cancellationToken);
		}

		public async Task<DeletionStatusResponse> DeleteMessage(string threadId, string messageId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.DeleteAndReadAsAsync<DeletionStatusResponse>(_endpointProvider.MessageDelete(threadId, messageId), cancellationToken);
		}

		public async Task<ModelListResponse> ListModel(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<ModelListResponse>(_endpointProvider.ModelsList(), cancellationToken);
		}

		public async Task<ModelRetrieveResponse> RetrieveModel(string model, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetFromJsonAsync<ModelRetrieveResponse>(_endpointProvider.ModelRetrieve(model), cancellationToken);
		}

		public async Task<ModelDeleteResponse?> DeleteModel(string modelId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await (await _httpClient.DeleteAsync(_endpointProvider.ModelsDelete(modelId), cancellationToken)).Content.ReadFromJsonAsync<ModelDeleteResponse>(cancellationToken);
		}

		public async Task<CreateModerationResponse> CreateModeration(CreateModerationRequest createModerationRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<CreateModerationResponse>(_endpointProvider.ModerationCreate(), createModerationRequest, cancellationToken);
		}

		public async Task<RunResponse> RunCreate(string threadId, RunCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			request.ProcessModelId(modelId, _defaultModelId, allowNull: true);
			return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.RunCreate(threadId), request, cancellationToken);
		}

		public async IAsyncEnumerable<BaseResponse> RunCreateAsStream(string threadId, RunCreateRequest request, string? modelId = null, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
		{
			request.Stream = true;
			request.ProcessModelId(modelId, _defaultModelId, allowNull: true);
			using HttpResponseMessage response = _httpClient.PostAsStreamAsync(_endpointProvider.RunCreate(threadId), request, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				yield return await response.HandleResponseContent<RunResponse>(cancellationToken);
				yield break;
			}
			await foreach (BaseResponse item in response.AsStream(justDataMode, cancellationToken))
			{
				yield return item;
			}
		}

		public async Task<RunResponse> RunModify(string threadId, string runId, RunModifyRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			if (string.IsNullOrWhiteSpace(runId))
			{
				throw new ArgumentNullException("runId");
			}
			return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.RunModify(threadId, runId), request, cancellationToken);
		}

		public async Task<RunResponse> RunRetrieve(string threadId, string runId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			if (string.IsNullOrWhiteSpace(runId))
			{
				throw new ArgumentNullException("runId");
			}
			return await _httpClient.GetReadAsAsync<RunResponse>(_endpointProvider.RunRetrieve(threadId, runId), cancellationToken);
		}

		public async Task<RunResponse> RunCancel(string threadId, string runId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.RunCancel(threadId, runId), null, cancellationToken);
		}

		public async Task<RunResponse> RunSubmitToolOutputs(string threadId, string runId, SubmitToolOutputsToRunRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			if (string.IsNullOrWhiteSpace(runId))
			{
				throw new ArgumentNullException("runId");
			}
			return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.RunSubmitToolOutputs(threadId, runId), request, cancellationToken);
		}

		public async IAsyncEnumerable<BaseResponse> RunSubmitToolOutputsAsStream(string threadId, string runId, SubmitToolOutputsToRunRequest request, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
		{
			request.Stream = true;
			using HttpResponseMessage response = _httpClient.PostAsStreamAsync(_endpointProvider.RunSubmitToolOutputs(threadId, runId), request, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				yield return await response.HandleResponseContent<BaseResponse>(cancellationToken);
				yield break;
			}
			await foreach (BaseResponse item in response.AsStream(justDataMode, cancellationToken))
			{
				yield return item;
			}
		}

		public async Task<RunResponse> CreateThreadAndRun(CreateThreadAndRunRequest requestBody, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<RunResponse>(_endpointProvider.ThreadAndRunCreate(), requestBody, cancellationToken);
		}

		public async IAsyncEnumerable<BaseResponse> CreateThreadAndRunAsStream(CreateThreadAndRunRequest createThreadAndRunRequest, string? modelId = null, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
		{
			createThreadAndRunRequest.Stream = true;
			createThreadAndRunRequest.ProcessModelId(modelId, _defaultModelId, allowNull: true);
			using HttpResponseMessage response = _httpClient.PostAsStreamAsync(_endpointProvider.ThreadAndRunCreate(), createThreadAndRunRequest, cancellationToken);
			if (!response.IsSuccessStatusCode)
			{
				yield return await response.HandleResponseContent<BaseResponse>(cancellationToken);
				yield break;
			}
			await foreach (BaseResponse item in response.AsStream(justDataMode, cancellationToken))
			{
				yield return item;
			}
		}

		public async Task<RunListResponse> ListRuns(string threadId, PaginationRequest runListRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<RunListResponse>(_endpointProvider.RunList(threadId, runListRequest), cancellationToken);
		}

		public async Task<RunStepListResponse> RunStepsList(string threadId, string runId, PaginationRequest? request = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<RunStepListResponse>(_endpointProvider.RunStepList(threadId, runId, request), cancellationToken);
		}

		public async Task<RunStepResponse> RunStepRetrieve(string threadId, string runId, string stepId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<RunStepResponse>(_endpointProvider.RunStepRetrieve(threadId, runId, stepId), cancellationToken);
		}

		[ActivatorUtilitiesConstructor]
		public OpenAIService(IOptions<OpenAIOptions> settings, HttpClient httpClient)
			: this(settings.Value, httpClient)
		{
		}

		public OpenAIService(OpenAIOptions settings, HttpClient? httpClient = null)
		{
			settings.Validate();
			if (httpClient == null)
			{
				_disposeHttpClient = true;
				_httpClient = new HttpClient();
			}
			else
			{
				_httpClient = httpClient;
			}
			_httpClient.BaseAddress = new Uri(settings.BaseDomain);
			ProviderType providerType = settings.ProviderType;
			if (providerType != ProviderType.OpenAI && providerType == ProviderType.Azure)
			{
				_httpClient.DefaultRequestHeaders.Add("api-key", settings.ApiKey);
			}
			else
			{
				_httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + settings.ApiKey);
				if (settings.UseBeta)
				{
					_httpClient.DefaultRequestHeaders.Add("OpenAI-Beta", settings.Assistants);
				}
			}
			if (!string.IsNullOrEmpty(settings.Organization))
			{
				_httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", settings.Organization ?? "");
			}
			_endpointProvider = ((settings.ProviderType != ProviderType.Azure) ? ((IOpenAIEndpointProvider)new OpenAIEndpointProvider(settings.ApiVersion)) : ((IOpenAIEndpointProvider)new AzureOpenAIEndpointProvider(settings.ApiVersion, settings.DeploymentId)));
			_defaultModelId = settings.DefaultModelId;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public void SetDefaultModelId(string modelId)
		{
			_defaultModelId = modelId;
		}

		public string? GetDefaultModelId()
		{
			return _defaultModelId;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && _disposeHttpClient && _httpClient != null)
			{
				_httpClient.Dispose();
			}
		}

		public async Task<ThreadResponse> ThreadCreate(ThreadCreateRequest? request = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<ThreadResponse>(_endpointProvider.ThreadCreate(), request, cancellationToken);
		}

		public async Task<ThreadResponse> ThreadRetrieve(string threadId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			return await _httpClient.GetReadAsAsync<ThreadResponse>(_endpointProvider.ThreadRetrieve(threadId), cancellationToken);
		}

		public async Task<DeletionStatusResponse> ThreadDelete(string threadId, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (string.IsNullOrWhiteSpace(threadId))
			{
				throw new ArgumentNullException("threadId");
			}
			return await _httpClient.DeleteAndReadAsAsync<DeletionStatusResponse>(_endpointProvider.ThreadDelete(threadId), cancellationToken);
		}

		public async Task<ThreadResponse> ModifyThread(string threadId, ModifyThreadRequest requestBody, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<ThreadResponse>(_endpointProvider.ThreadModify(threadId), requestBody, cancellationToken);
		}

		public async Task<VectorStoreListObjectResponse> ListVectorStores(PaginationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<VectorStoreListObjectResponse>(_endpointProvider.VectorStoreList(request), cancellationToken);
		}

		public async Task<VectorStoreObjectResponse> CreateVectorStore(CreateVectorStoreRequest requestBody, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<VectorStoreObjectResponse>(_endpointProvider.VectorStoreCreate(), requestBody, cancellationToken);
		}

		public async Task<VectorStoreObjectResponse> RetrieveVectorStore(string vectorStoreId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<VectorStoreObjectResponse>(_endpointProvider.VectorStoreRetrieve(vectorStoreId), cancellationToken);
		}

		public async Task<VectorStoreObjectResponse> ModifyVectorStore(string vectorStoreId, UpdateVectorStoreRequest requestBody, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<VectorStoreObjectResponse>(_endpointProvider.VectorStoreModify(vectorStoreId), requestBody, cancellationToken);
		}

		public async Task<DeletionStatusResponse> DeleteVectorStore(string vectorStoreId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.DeleteAndReadAsAsync<DeletionStatusResponse>(_endpointProvider.VectorStoreDelete(vectorStoreId), cancellationToken);
		}

		public async Task<VectorStoreFileListObject> ListVectorStoreFiles(string vectorStoreId, VectorStoreFileListRequest vectorStoreFileListRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<VectorStoreFileListObject>(_endpointProvider.VectorStoreFileList(vectorStoreId, vectorStoreFileListRequest), cancellationToken);
		}

		public async Task<VectorStoreFileObject> CreateVectorStoreFile(string vectorStoreId, CreateVectorStoreFileRequest requestBody, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<VectorStoreFileObject>(_endpointProvider.VectorStoreFileCreate(vectorStoreId), requestBody, cancellationToken);
		}

		public async Task<VectorStoreFileObject> GetVectorStoreFile(string vectorStoreId, string fileId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<VectorStoreFileObject>(_endpointProvider.VectorStoreFileRetrieve(vectorStoreId, fileId), cancellationToken);
		}

		public async Task<DeletionStatusResponse> DeleteVectorStoreFile(string vectorStoreId, string fileId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.DeleteAndReadAsAsync<DeletionStatusResponse>(_endpointProvider.VectorStoreFileDelete(vectorStoreId, fileId), cancellationToken);
		}

		public async Task<VectorStoreFileBatchObject> CreateVectorStoreFileBatch(string vectorStoreId, CreateVectorStoreFileBatchRequest requestBody, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<VectorStoreFileBatchObject>(_endpointProvider.VectorStoreFileBatchCreate(vectorStoreId), requestBody, cancellationToken);
		}

		public async Task<VectorStoreFileBatchObject> GetVectorStoreFileBatch(string vectorStoreId, string batchId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<VectorStoreFileBatchObject>(_endpointProvider.VectorStoreFileBatchRetrieve(vectorStoreId, batchId), cancellationToken);
		}

		public async Task<VectorStoreFileBatchObject> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.PostAndReadAsAsync<VectorStoreFileBatchObject>(_endpointProvider.VectorStoreFileBatchCancel(vectorStoreId, batchId), null, cancellationToken);
		}

		public async Task<VectorStoreFileBatchListObjectResponse> ListFilesInVectorStoreBatch(string vectorStoreId, string batchId, PaginationRequest baseListRequest, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await _httpClient.GetReadAsAsync<VectorStoreFileBatchListObjectResponse>(_endpointProvider.VectorStoreFileBatchList(vectorStoreId, batchId, baseListRequest), cancellationToken);
		}
	}
	public class OpenAIWebSocketClient
	{
		public ClientWebSocket WebSocket { get; } = new ClientWebSocket();

		public void ConfigureWebSocket(Action<ClientWebSocket> configure)
		{
			configure(WebSocket);
		}
	}
	public interface IOpenAIRealtimeService : IDisposable, IAsyncDisposable
	{
		bool IsConnected { get; }

		IOpenAIRealtimeServiceClientEvents ClientEvents { get; }

		IOpenAIRealtimeServiceServerEvents ServerEvents { get; }

		Task ConnectAsync(CancellationToken cancellationToken = default(CancellationToken));

		Task DisconnectAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
	public class OpenAIRealtimeService : IOpenAIRealtimeService, IDisposable, IAsyncDisposable
	{
		private class ClientEventsImplementation(OpenAIRealtimeService client) : IOpenAIRealtimeServiceClientEvents
		{
			private readonly ConversationImplementation _conversation = new ConversationImplementation(client);

			private readonly InputAudioBufferImplementation _inputAudioBuffer = new InputAudioBufferImplementation(client);

			private readonly ResponseImplementation _response = new ResponseImplementation(client);

			private readonly SessionImplementation _session = new SessionImplementation(client);

			public IOpenAIRealtimeServiceClientEvents.ISession Session => _session;

			public IOpenAIRealtimeServiceClientEvents.IInputAudioBuffer InputAudioBuffer => _inputAudioBuffer;

			public IOpenAIRealtimeServiceClientEvents.IConversation Conversation => _conversation;

			public IOpenAIRealtimeServiceClientEvents.IResponse Response => _response;
		}

		private class SessionImplementation(OpenAIRealtimeService client) : IOpenAIRealtimeServiceClientEvents.ISession
		{
			public Task Update(SessionUpdateRequest request, CancellationToken cancellationToken = default(CancellationToken))
			{
				if (!client.IsConnected)
				{
					throw new InvalidOperationException("Not connected to Realtime API.");
				}
				return client.SendEvent(request, cancellationToken);
			}
		}

		private class InputAudioBufferImplementation(OpenAIRealtimeService client) : IOpenAIRealtimeServiceClientEvents.IInputAudioBuffer
		{
			public Task Append(ReadOnlyMemory<byte> audioData, CancellationToken cancellationToken = default(CancellationToken))
			{
				if (!client.IsConnected)
				{
					throw new InvalidOperationException("Not connected to Realtime API.");
				}
				AudioBufferAppendRequest message = new AudioBufferAppendRequest
				{
					Audio = Convert.ToBase64String(audioData.ToArray())
				};
				return client.SendEvent(message, cancellationToken);
			}

			public Task Commit(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (!client.IsConnected)
				{
					throw new InvalidOperationException("Not connected to Realtime API.");
				}
				return client.SendEvent(new AudioBufferCommitRequest(), cancellationToken);
			}

			public Task Clear(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (!client.IsConnected)
				{
					throw new InvalidOperationException("Not connected to Realtime API.");
				}
				return client.SendEvent(new AudioBufferClearRequest(), cancellationToken);
			}
		}

		private class ConversationImplementation(OpenAIRealtimeService client) : IOpenAIRealtimeServiceClientEvents.IConversation
		{
			private class ConversationItemImplementation(OpenAIRealtimeService client) : IOpenAIRealtimeServiceClientEvents.IConversation.IItem
			{
				public Task Create(ConversationItemCreateRequest request, CancellationToken cancellationToken = default(CancellationToken))
				{
					if (!client.IsConnected)
					{
						throw new InvalidOperationException("Not connected to Realtime API.");
					}
					return client.SendEvent(request, cancellationToken);
				}

				public Task Truncate(string itemId, int contentIndex, int audioEndMs, CancellationToken cancellationToken = default(CancellationToken))
				{
					if (!client.IsConnected)
					{
						throw new InvalidOperationException("Not connected to Realtime API.");
					}
					ConversationItemTruncateRequest message = new ConversationItemTruncateRequest
					{
						ItemId = itemId,
						ContentIndex = contentIndex,
						AudioEndMs = audioEndMs
					};
					return client.SendEvent(message, cancellationToken);
				}

				public Task Delete(string itemId, CancellationToken cancellationToken = default(CancellationToken))
				{
					if (!client.IsConnected)
					{
						throw new InvalidOperationException("Not connected to Realtime API.");
					}
					ConversationItemDeleteRequest message = new ConversationItemDeleteRequest
					{
						ItemId = itemId
					};
					return client.SendEvent(message, cancellationToken);
				}
			}

			private readonly ConversationItemImplementation _item = new ConversationItemImplementation(client);

			public IOpenAIRealtimeServiceClientEvents.IConversation.IItem Item => _item;
		}

		private class ResponseImplementation(OpenAIRealtimeService client) : IOpenAIRealtimeServiceClientEvents.IResponse
		{
			public Task Create(CancellationToken cancellationToken = default(CancellationToken))
			{
				return Create(new ResponseCreateRequest(), cancellationToken);
			}

			public Task Create(ResponseCreateRequest request, CancellationToken cancellationToken = default(CancellationToken))
			{
				if (!client.IsConnected)
				{
					throw new InvalidOperationException("Not connected to Realtime API.");
				}
				return client.SendEvent(request, cancellationToken);
			}

			public Task Cancel(CancellationToken cancellationToken = default(CancellationToken))
			{
				if (!client.IsConnected)
				{
					throw new InvalidOperationException("Not connected to Realtime API.");
				}
				return client.SendEvent(new ResponseCancelRequest(), cancellationToken);
			}
		}

		private readonly CancellationTokenSource _disposeCts = new CancellationTokenSource();

		private readonly ILogger<OpenAIRealtimeService> _logger;

		private readonly OpenAIOptions _openAIOptions;

		private readonly SemaphoreSlim _sendLock = new SemaphoreSlim(1, 1);

		private Task? _receiveTask;

		private ClientWebSocket? _webSocket;

		private readonly object _webSocketLock = new object();

		private readonly ClientEventsImplementation _clientEvents;

		private readonly OpenAIRealtimeServiceServerEvents _serverEvents;

		private readonly OpenAIWebSocketClient _webSocketClient;

		private static readonly Dictionary<string, Action<OpenAIRealtimeService, JsonElement>> EventHandlers = InitializeEventHandlers();

		public bool IsConnected
		{
			get
			{
				lock (_webSocketLock)
				{
					ClientWebSocket? webSocket = _webSocket;
					return webSocket != null && webSocket.State == WebSocketState.Open;
				}
			}
		}

		public IOpenAIRealtimeServiceClientEvents ClientEvents => _clientEvents;

		public IOpenAIRealtimeServiceServerEvents ServerEvents => _serverEvents;

		public OpenAIRealtimeService(IOptions<OpenAIOptions> settings, ILogger<OpenAIRealtimeService> logger, OpenAIWebSocketClient webSocketClient)
		{
			_openAIOptions = settings.Value;
			_logger = logger;
			_webSocketClient = webSocketClient;
			_clientEvents = new ClientEventsImplementation(this);
			_serverEvents = new OpenAIRealtimeServiceServerEvents();
			ConfigureBaseWebSocket();
		}

		public OpenAIRealtimeService(OpenAIOptions options)
			: this(Options.Create(options), NullLogger<OpenAIRealtimeService>.Instance, new OpenAIWebSocketClient())
		{
		}

		public OpenAIRealtimeService(OpenAIOptions options, ILogger<OpenAIRealtimeService> logger)
			: this(Options.Create(options), logger, new OpenAIWebSocketClient())
		{
		}

		public OpenAIRealtimeService(OpenAIOptions options, Action<ClientWebSocket>? configureWebSocket = null)
			: this(options)
		{
			if (configureWebSocket != null)
			{
				_webSocketClient.ConfigureWebSocket(configureWebSocket);
			}
		}

		public OpenAIRealtimeService(string apiKey)
			: this(new OpenAIOptions
			{
				ApiKey = apiKey
			})
		{
		}

		public static OpenAIRealtimeServiceBuilder Create(string apiKey)
		{
			return new OpenAIRealtimeServiceBuilder(apiKey);
		}

		public static OpenAIRealtimeServiceBuilder Create(OpenAIOptions options)
		{
			return new OpenAIRealtimeServiceBuilder(options);
		}

		private void ConfigureBaseWebSocket()
		{
			Dictionary<string, string> headers = new Dictionary<string, string> { 
			{
				"Authorization",
				"Bearer " + _openAIOptions.ApiKey
			} };
			if (!string.IsNullOrEmpty(_openAIOptions.Organization))
			{
				headers["OpenAI-Organization"] = _openAIOptions.Organization;
			}
			_webSocketClient.ConfigureWebSocket((ClientWebSocket ws) =>
			{
				WebSocketConfigurationHelper.ConfigureWebSocket(ws, null, headers);
			});
		}

		private static Dictionary<string, Action<OpenAIRealtimeService, JsonElement>> InitializeEventHandlers()
		{
			return new Dictionary<string, Action<OpenAIRealtimeService, JsonElement>>
			{
				{
					"error",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.RaiseOnError(service, service.DeserializeEvent<ErrorEvent>(element));
					}
				},
				{
					"session.created",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.SessionImpl.RaiseOnCreated(service, service.DeserializeEvent<SessionEvent>(element));
					}
				},
				{
					"session.updated",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.SessionImpl.RaiseOnUpdated(service, service.DeserializeEvent<SessionEvent>(element));
					}
				},
				{
					"conversation.created",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ConversationImpl.RaiseOnCreated(service, service.DeserializeEvent<ConversationCreatedEvent>(element));
					}
				},
				{
					"conversation.item.created",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ConversationImpl.ItemImpl.RaiseOnCreated(service, service.DeserializeEvent<ConversationItemCreatedEvent>(element));
					}
				},
				{
					"conversation.item.truncated",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ConversationImpl.ItemImpl.RaiseOnTruncated(service, service.DeserializeEvent<ConversationItemTruncatedEvent>(element));
					}
				},
				{
					"conversation.item.deleted",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ConversationImpl.ItemImpl.RaiseOnDeleted(service, service.DeserializeEvent<ConversationItemDeletedEvent>(element));
					}
				},
				{
					"conversation.item.input_audio_transcription.completed",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ConversationImpl.ItemImpl.InputAudioTranscriptionImpl.RaiseOnCompleted(service, service.DeserializeEvent<InputAudioTranscriptionCompletedEvent>(element));
					}
				},
				{
					"conversation.item.input_audio_transcription.failed",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ConversationImpl.ItemImpl.InputAudioTranscriptionImpl.RaiseOnFailed(service, service.DeserializeEvent<InputAudioTranscriptionFailedEvent>(element));
					}
				},
				{
					"input_audio_buffer.committed",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.InputAudioBufferImpl.RaiseOnCommitted(service, service.DeserializeEvent<AudioBufferCommittedEvent>(element));
					}
				},
				{
					"input_audio_buffer.cleared",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.InputAudioBufferImpl.RaiseOnCleared(service, service.DeserializeEvent<AudioBufferClearedEvent>(element));
					}
				},
				{
					"input_audio_buffer.speech_started",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.InputAudioBufferImpl.RaiseOnSpeechStarted(service, service.DeserializeEvent<AudioBufferSpeechStartedEvent>(element));
					}
				},
				{
					"input_audio_buffer.speech_stopped",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.InputAudioBufferImpl.RaiseOnSpeechStopped(service, service.DeserializeEvent<AudioBufferSpeechStoppedEvent>(element));
					}
				},
				{
					"response.created",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.RaiseOnCreated(service, service.DeserializeEvent<ResponseEvent>(element));
					}
				},
				{
					"response.done",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.RaiseOnDone(service, service.DeserializeEvent<ResponseEvent>(element));
					}
				},
				{
					"response.output_item.added",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.OutputItemImpl.RaiseOnAdded(service, service.DeserializeEvent<ResponseOutputItemAddedEvent>(element));
					}
				},
				{
					"response.output_item.done",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.OutputItemImpl.RaiseOnDone(service, service.DeserializeEvent<ResponseOutputItemDoneEvent>(element));
					}
				},
				{
					"response.content_part.added",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.ContentPartImpl.RaiseOnAdded(service, service.DeserializeEvent<ResponseContentPartEvent>(element));
					}
				},
				{
					"response.content_part.done",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.ContentPartImpl.RaiseOnDone(service, service.DeserializeEvent<ResponseContentPartEvent>(element));
					}
				},
				{
					"response.text.delta",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.TextImpl.RaiseOnDelta(service, service.DeserializeEvent<TextStreamEvent>(element));
					}
				},
				{
					"response.text.done",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.TextImpl.RaiseOnDone(service, service.DeserializeEvent<TextStreamEvent>(element));
					}
				},
				{
					"response.audio_transcript.delta",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.AudioTranscriptImpl.RaiseOnDelta(service, service.DeserializeEvent<AudioTranscriptStreamEvent>(element));
					}
				},
				{
					"response.audio_transcript.done",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.AudioTranscriptImpl.RaiseOnDone(service, service.DeserializeEvent<AudioTranscriptStreamEvent>(element));
					}
				},
				{
					"response.audio.delta",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.AudioImpl.RaiseOnDelta(service, service.DeserializeEvent<AudioStreamEvent>(element));
					}
				},
				{
					"response.audio.done",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.AudioImpl.RaiseOnDone(service, service.DeserializeEvent<AudioStreamEvent>(element));
					}
				},
				{
					"response.function_call_arguments.delta",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.FunctionCallArgumentsImpl.RaiseOnDelta(service, service.DeserializeEvent<FunctionCallStreamEvent>(element));
					}
				},
				{
					"response.function_call_arguments.done",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.ResponseImpl.FunctionCallArgumentsImpl.RaiseOnDone(service, service.DeserializeEvent<FunctionCallStreamEvent>(element));
					}
				},
				{
					"rate_limits.updated",
					(OpenAIRealtimeService service, JsonElement element) =>
					{
						service._serverEvents.RateLimitsImpl.RaiseOnUpdated(service, service.DeserializeEvent<RateLimitsEvent>(element));
					}
				}
			};
		}

		public async Task ConnectAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			using CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _disposeCts.Token);
			linkedCts.Token.ThrowIfCancellationRequested();
			if (IsConnected)
			{
				throw new InvalidOperationException("Already connected to Realtime API.");
			}
			try
			{
				ClientWebSocket webSocket = _webSocketClient.WebSocket;
				Uri uri = new Uri(_openAIOptions.BaseRealTimeSocketUrl + "?model=" + (_openAIOptions.DefaultModelId ?? Models.Gpt_4o_realtime_preview_2024_10_01));
				await webSocket.ConnectAsync(uri, linkedCts.Token).ConfigureAwait(continueOnCapturedContext: false);
				if (webSocket.State != WebSocketState.Open)
				{
					throw new InvalidOperationException($"WebSocket connection failed. Current state: {webSocket.State}");
				}
				lock (_webSocketLock)
				{
					_webSocket = webSocket;
				}
				_logger.LogInformation("Successfully connected to Realtime API");
				_receiveTask = StartReceiving(linkedCts.Token);
			}
			catch (OperationCanceledException)
			{
				_logger.LogInformation("Connection canceled.");
				throw;
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, "Failed to connect to Realtime API");
				throw;
			}
		}

		public async Task DisconnectAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			using CancellationTokenSource linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, _disposeCts.Token);
			linkedCts.Token.ThrowIfCancellationRequested();
			ClientWebSocket webSocket;
			lock (_webSocketLock)
			{
				webSocket = _webSocket;
			}
			if (webSocket == null || webSocket.State != WebSocketState.Open)
			{
				return;
			}
			try
			{
				await webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Disconnecting", linkedCts.Token).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (OperationCanceledException)
			{
				_logger.LogInformation("Disconnection canceled.");
				throw;
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, "Error during disconnection");
				throw;
			}
			finally
			{
				CleanupWebSocket();
			}
		}

		private Task HandleMessage(string message)
		{
			_serverEvents.RaiseOnAll(this, message);
			try
			{
				using JsonDocument jsonDocument = JsonDocument.Parse(message);
				JsonElement rootElement = jsonDocument.RootElement;
				if (!rootElement.TryGetProperty("type", out var value))
				{
					_logger.LogWarning("Received message without type");
					return Task.CompletedTask;
				}
				string text = value.GetString();
				if (text != null && EventHandlers.TryGetValue(text, out Action<OpenAIRealtimeService, JsonElement> value2))
				{
					value2(this, rootElement);
				}
				else
				{
					_logger.LogWarning("Received unknown event type: {Type}", text);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error processing message");
				ErrorEvent e = new ErrorEvent
				{
					Error = new Error
					{
						Type = "Ranul.OpenAI_processing_error",
						MessageObject = ex.Message
					}
				};
				_serverEvents.RaiseOnError(this, e);
			}
			return Task.CompletedTask;
		}

		private async Task SendEvent<T>(T message, CancellationToken cancellationToken) where T : class
		{
			_ = 1;
			try
			{
				await _sendLock.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				try
				{
					string s = JsonSerializer.Serialize(message, message.GetType(), RealtimeServiceJsonContext.Default);
					byte[] bytes = Encoding.UTF8.GetBytes(s);
					ClientWebSocket webSocket;
					lock (_webSocketLock)
					{
						webSocket = _webSocket;
					}
					if (webSocket == null)
					{
						throw new InvalidOperationException("WebSocket is not initialized.");
					}
					await webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, endOfMessage: true, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				finally
				{
					_sendLock.Release();
				}
			}
			catch (Exception exception)
			{
				_logger.LogError(exception, "Error sending message");
				throw;
			}
		}

		private T DeserializeEvent<T>(JsonElement jsonElement) where T : class
		{
			JsonTypeInfo typeInfo = RealtimeServiceJsonContext.Default.GetTypeInfo(typeof(T));
			if (typeInfo == null)
			{
				return jsonElement.Deserialize<T>();
			}
			return jsonElement.Deserialize((JsonTypeInfo<T>)typeInfo);
		}

		private async Task StartReceiving(CancellationToken cancellationToken)
		{
			ClientWebSocket webSocket;
			lock (_webSocketLock)
			{
				webSocket = _webSocket;
			}
			if (webSocket == null)
			{
				throw new InvalidOperationException("WebSocket is not initialized.");
			}
			byte[] buffer = ArrayPool<byte>.Shared.Rent(16);
			StringBuilder textBuffer = new StringBuilder();
			try
			{
				while (!cancellationToken.IsCancellationRequested)
				{
					WebSocketReceiveResult webSocketReceiveResult;
					try
					{
						webSocketReceiveResult = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
					{
						_logger.LogWarning("WebSocket connection closed prematurely.");
						break;
					}
					catch (ObjectDisposedException)
					{
						break;
					}
					if (webSocketReceiveResult.MessageType == WebSocketMessageType.Close)
					{
						await HandleCloseMessage().ConfigureAwait(continueOnCapturedContext: false);
						break;
					}
					if (webSocketReceiveResult.MessageType == WebSocketMessageType.Text)
					{
						textBuffer.Append(Encoding.UTF8.GetString(buffer, 0, webSocketReceiveResult.Count));
						if (webSocketReceiveResult.EndOfMessage)
						{
							await HandleMessage(textBuffer.ToString()).ConfigureAwait(continueOnCapturedContext: false);
							textBuffer.Clear();
						}
					}
				}
			}
			catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
			{
			}
			catch (Exception ex4)
			{
				_logger.LogError(ex4, "Error in receive loop");
				_serverEvents.RaiseOnError(this, new ErrorEvent
				{
					Error = new Error
					{
						MessageObject = ex4.Message,
						Type = "Ranul.OpenAI_receive_error"
					}
				});
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(buffer);
			}
		}

		private async Task HandleCloseMessage()
		{
			await DisconnectAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		private void CleanupWebSocket()
		{
			ClientWebSocket webSocket;
			lock (_webSocketLock)
			{
				webSocket = _webSocket;
				_webSocket = null;
			}
			if (webSocket == null)
			{
				return;
			}
			if (webSocket.State == WebSocketState.Open)
			{
				try
				{
					webSocket.Abort();
				}
				catch (Exception exception)
				{
					_logger.LogError(exception, "Error aborting WebSocket");
				}
			}
			webSocket.Dispose();
		}

		public void Dispose()
		{
			_disposeCts.Cancel();
			CleanupWebSocket();
			_sendLock.Dispose();
			_disposeCts.Dispose();
		}

		public async ValueTask DisposeAsync()
		{
			_disposeCts.Cancel();
			if (_receiveTask != null)
			{
				await _receiveTask.ConfigureAwait(continueOnCapturedContext: false);
			}
			CleanupWebSocket();
			_sendLock.Dispose();
			_disposeCts.Dispose();
		}
	}
	public interface IOpenAIRealtimeServiceClientEvents
	{
		public interface ISession
		{
			Task Update(SessionUpdateRequest request, CancellationToken cancellationToken = default(CancellationToken));
		}

		public interface IInputAudioBuffer
		{
			Task Append(ReadOnlyMemory<byte> audioData, CancellationToken cancellationToken = default(CancellationToken));

			Task Commit(CancellationToken cancellationToken = default(CancellationToken));

			Task Clear(CancellationToken cancellationToken = default(CancellationToken));
		}

		public interface IConversation
		{
			public interface IItem
			{
				Task Create(ConversationItemCreateRequest request, CancellationToken cancellationToken = default(CancellationToken));

				Task Truncate(string itemId, int contentIndex, int audioEndMs, CancellationToken cancellationToken = default(CancellationToken));

				Task Delete(string itemId, CancellationToken cancellationToken = default(CancellationToken));
			}

			IItem Item { get; }
		}

		public interface IResponse
		{
			Task Create(ResponseCreateRequest request, CancellationToken cancellationToken = default(CancellationToken));

			Task Create(CancellationToken cancellationToken = default(CancellationToken));

			Task Cancel(CancellationToken cancellationToken = default(CancellationToken));
		}

		ISession Session { get; }

		IInputAudioBuffer InputAudioBuffer { get; }

		IConversation Conversation { get; }

		IResponse Response { get; }
	}
	public class OpenAIRealtimeServiceServerEvents : IOpenAIRealtimeServiceServerEvents
	{
		internal class SessionImplementation : IOpenAIRealtimeServiceServerEvents.ISession
		{
			public event EventHandler<SessionEvent>? OnCreated;

			public event EventHandler<SessionEvent>? OnUpdated;

			internal void RaiseOnCreated(object sender, SessionEvent e)
			{
				OnCreated?.Invoke(sender, e);
			}

			internal void RaiseOnUpdated(object sender, SessionEvent e)
			{
				OnUpdated?.Invoke(sender, e);
			}
		}

		internal class ConversationImplementation : IOpenAIRealtimeServiceServerEvents.IConversation
		{
			internal class ItemImplementation : IOpenAIRealtimeServiceServerEvents.IConversation.IItem
			{
				internal class InputAudioTranscriptionImplementation : IOpenAIRealtimeServiceServerEvents.IConversation.IItem.IInputAudioTranscription
				{
					public event EventHandler<InputAudioTranscriptionCompletedEvent>? OnCompleted;

					public event EventHandler<InputAudioTranscriptionFailedEvent>? OnFailed;

					internal void RaiseOnCompleted(object sender, InputAudioTranscriptionCompletedEvent e)
					{
						OnCompleted?.Invoke(sender, e);
					}

					internal void RaiseOnFailed(object sender, InputAudioTranscriptionFailedEvent e)
					{
						OnFailed?.Invoke(sender, e);
					}
				}

				internal readonly InputAudioTranscriptionImplementation InputAudioTranscriptionImpl = new InputAudioTranscriptionImplementation();

				public IOpenAIRealtimeServiceServerEvents.IConversation.IItem.IInputAudioTranscription InputAudioTranscription => InputAudioTranscriptionImpl;

				public event EventHandler<ConversationItemCreatedEvent>? OnCreated;

				public event EventHandler<ConversationItemTruncatedEvent>? OnTruncated;

				public event EventHandler<ConversationItemDeletedEvent>? OnDeleted;

				internal void RaiseOnCreated(object sender, ConversationItemCreatedEvent e)
				{
					OnCreated?.Invoke(sender, e);
				}

				internal void RaiseOnTruncated(object sender, ConversationItemTruncatedEvent e)
				{
					OnTruncated?.Invoke(sender, e);
				}

				internal void RaiseOnDeleted(object sender, ConversationItemDeletedEvent e)
				{
					OnDeleted?.Invoke(sender, e);
				}
			}

			internal readonly ItemImplementation ItemImpl = new ItemImplementation();

			public IOpenAIRealtimeServiceServerEvents.IConversation.IItem Item => ItemImpl;

			public event EventHandler<ConversationCreatedEvent>? OnCreated;

			internal void RaiseOnCreated(object sender, ConversationCreatedEvent e)
			{
				OnCreated?.Invoke(sender, e);
			}
		}

		internal class InputAudioBufferImplementation : IOpenAIRealtimeServiceServerEvents.IInputAudioBuffer
		{
			public event EventHandler<AudioBufferCommittedEvent>? OnCommitted;

			public event EventHandler<AudioBufferClearedEvent>? OnCleared;

			public event EventHandler<AudioBufferSpeechStartedEvent>? OnSpeechStarted;

			public event EventHandler<AudioBufferSpeechStoppedEvent>? OnSpeechStopped;

			internal void RaiseOnCommitted(object sender, AudioBufferCommittedEvent e)
			{
				OnCommitted?.Invoke(sender, e);
			}

			internal void RaiseOnCleared(object sender, AudioBufferClearedEvent e)
			{
				OnCleared?.Invoke(sender, e);
			}

			internal void RaiseOnSpeechStarted(object sender, AudioBufferSpeechStartedEvent e)
			{
				OnSpeechStarted?.Invoke(sender, e);
			}

			internal void RaiseOnSpeechStopped(object sender, AudioBufferSpeechStoppedEvent e)
			{
				OnSpeechStopped?.Invoke(sender, e);
			}
		}

		internal class ResponseImplementation : IOpenAIRealtimeServiceServerEvents.IResponse
		{
			internal class OutputItemImplementation : IOpenAIRealtimeServiceServerEvents.IResponse.IOutputItem
			{
				public event EventHandler<ResponseOutputItemAddedEvent>? OnAdded;

				public event EventHandler<ResponseOutputItemDoneEvent>? OnDone;

				internal void RaiseOnAdded(object sender, ResponseOutputItemAddedEvent e)
				{
					OnAdded?.Invoke(sender, e);
				}

				internal void RaiseOnDone(object sender, ResponseOutputItemDoneEvent e)
				{
					OnDone?.Invoke(sender, e);
				}
			}

			internal class ContentPartImplementation : IOpenAIRealtimeServiceServerEvents.IResponse.IContentPart
			{
				public event EventHandler<ResponseContentPartEvent>? OnAdded;

				public event EventHandler<ResponseContentPartEvent>? OnDone;

				internal void RaiseOnAdded(object sender, ResponseContentPartEvent e)
				{
					OnAdded?.Invoke(sender, e);
				}

				internal void RaiseOnDone(object sender, ResponseContentPartEvent e)
				{
					OnDone?.Invoke(sender, e);
				}
			}

			internal class TextImplementation : IOpenAIRealtimeServiceServerEvents.IResponse.IText
			{
				public event EventHandler<TextStreamEvent>? OnDelta;

				public event EventHandler<TextStreamEvent>? OnDone;

				internal void RaiseOnDelta(object sender, TextStreamEvent e)
				{
					OnDelta?.Invoke(sender, e);
				}

				internal void RaiseOnDone(object sender, TextStreamEvent e)
				{
					OnDone?.Invoke(sender, e);
				}
			}

			internal class AudioTranscriptImplementation : IOpenAIRealtimeServiceServerEvents.IResponse.IAudioTranscript
			{
				public event EventHandler<AudioTranscriptStreamEvent>? OnDelta;

				public event EventHandler<AudioTranscriptStreamEvent>? OnDone;

				internal void RaiseOnDelta(object sender, AudioTranscriptStreamEvent e)
				{
					OnDelta?.Invoke(sender, e);
				}

				internal void RaiseOnDone(object sender, AudioTranscriptStreamEvent e)
				{
					OnDone?.Invoke(sender, e);
				}
			}

			internal class AudioImplementation : IOpenAIRealtimeServiceServerEvents.IResponse.IAudio
			{
				public event EventHandler<AudioStreamEvent>? OnDelta;

				public event EventHandler<AudioStreamEvent>? OnDone;

				internal void RaiseOnDelta(object sender, AudioStreamEvent e)
				{
					OnDelta?.Invoke(sender, e);
				}

				internal void RaiseOnDone(object sender, AudioStreamEvent e)
				{
					OnDone?.Invoke(sender, e);
				}
			}

			internal class FunctionCallArgumentsImplementation : IOpenAIRealtimeServiceServerEvents.IResponse.IFunctionCallArguments
			{
				public event EventHandler<FunctionCallStreamEvent>? OnDelta;

				public event EventHandler<FunctionCallStreamEvent>? OnDone;

				internal void RaiseOnDelta(object sender, FunctionCallStreamEvent e)
				{
					OnDelta?.Invoke(sender, e);
				}

				internal void RaiseOnDone(object sender, FunctionCallStreamEvent e)
				{
					OnDone?.Invoke(sender, e);
				}
			}

			internal readonly AudioImplementation AudioImpl = new AudioImplementation();

			internal readonly AudioTranscriptImplementation AudioTranscriptImpl = new AudioTranscriptImplementation();

			internal readonly ContentPartImplementation ContentPartImpl = new ContentPartImplementation();

			internal readonly FunctionCallArgumentsImplementation FunctionCallArgumentsImpl = new FunctionCallArgumentsImplementation();

			internal readonly OutputItemImplementation OutputItemImpl = new OutputItemImplementation();

			internal readonly TextImplementation TextImpl = new TextImplementation();

			public IOpenAIRealtimeServiceServerEvents.IResponse.IOutputItem OutputItem => OutputItemImpl;

			public IOpenAIRealtimeServiceServerEvents.IResponse.IContentPart ContentPart => ContentPartImpl;

			public IOpenAIRealtimeServiceServerEvents.IResponse.IText Text => TextImpl;

			public IOpenAIRealtimeServiceServerEvents.IResponse.IAudioTranscript AudioTranscript => AudioTranscriptImpl;

			public IOpenAIRealtimeServiceServerEvents.IResponse.IAudio Audio => AudioImpl;

			public IOpenAIRealtimeServiceServerEvents.IResponse.IFunctionCallArguments FunctionCallArguments => FunctionCallArgumentsImpl;

			public event EventHandler<ResponseEvent>? OnCreated;

			public event EventHandler<ResponseEvent>? OnDone;

			internal void RaiseOnCreated(object sender, ResponseEvent e)
			{
				OnCreated?.Invoke(sender, e);
			}

			internal void RaiseOnDone(object sender, ResponseEvent e)
			{
				OnDone?.Invoke(sender, e);
			}
		}

		internal class RateLimitsImplementation : IOpenAIRealtimeServiceServerEvents.IRateLimits
		{
			public event EventHandler<RateLimitsEvent>? OnUpdated;

			internal void RaiseOnUpdated(object sender, RateLimitsEvent e)
			{
				OnUpdated?.Invoke(sender, e);
			}
		}

		internal readonly ConversationImplementation ConversationImpl = new ConversationImplementation();

		internal readonly InputAudioBufferImplementation InputAudioBufferImpl = new InputAudioBufferImplementation();

		internal readonly RateLimitsImplementation RateLimitsImpl = new RateLimitsImplementation();

		internal readonly ResponseImplementation ResponseImpl = new ResponseImplementation();

		internal readonly SessionImplementation SessionImpl = new SessionImplementation();

		public IOpenAIRealtimeServiceServerEvents.ISession Session => SessionImpl;

		public IOpenAIRealtimeServiceServerEvents.IConversation Conversation => ConversationImpl;

		public IOpenAIRealtimeServiceServerEvents.IInputAudioBuffer InputAudioBuffer => InputAudioBufferImpl;

		public IOpenAIRealtimeServiceServerEvents.IResponse Response => ResponseImpl;

		public IOpenAIRealtimeServiceServerEvents.IRateLimits RateLimits => RateLimitsImpl;

		public event EventHandler<ErrorEvent>? OnError;

		public event EventHandler<string>? OnAll;

		internal void RaiseOnError(object sender, ErrorEvent e)
		{
			OnError?.Invoke(sender, e);
		}

		internal void RaiseOnAll(object sender, string message)
		{
			OnAll?.Invoke(sender, message);
		}
	}
	public interface IOpenAIRealtimeServiceServerEvents
	{
		public interface ISession
		{
			event EventHandler<SessionEvent>? OnCreated;

			event EventHandler<SessionEvent>? OnUpdated;
		}

		public interface IConversation
		{
			public interface IItem
			{
				public interface IInputAudioTranscription
				{
					event EventHandler<InputAudioTranscriptionCompletedEvent>? OnCompleted;

					event EventHandler<InputAudioTranscriptionFailedEvent>? OnFailed;
				}

				IInputAudioTranscription InputAudioTranscription { get; }

				event EventHandler<ConversationItemCreatedEvent>? OnCreated;

				event EventHandler<ConversationItemTruncatedEvent>? OnTruncated;

				event EventHandler<ConversationItemDeletedEvent>? OnDeleted;
			}

			IItem Item { get; }

			event EventHandler<ConversationCreatedEvent>? OnCreated;
		}

		public interface IInputAudioBuffer
		{
			event EventHandler<AudioBufferCommittedEvent>? OnCommitted;

			event EventHandler<AudioBufferClearedEvent>? OnCleared;

			event EventHandler<AudioBufferSpeechStartedEvent>? OnSpeechStarted;

			event EventHandler<AudioBufferSpeechStoppedEvent>? OnSpeechStopped;
		}

		public interface IResponse
		{
			public interface IOutputItem
			{
				event EventHandler<ResponseOutputItemAddedEvent>? OnAdded;

				event EventHandler<ResponseOutputItemDoneEvent>? OnDone;
			}

			public interface IContentPart
			{
				event EventHandler<ResponseContentPartEvent>? OnAdded;

				event EventHandler<ResponseContentPartEvent>? OnDone;
			}

			public interface IText
			{
				event EventHandler<TextStreamEvent>? OnDelta;

				event EventHandler<TextStreamEvent>? OnDone;
			}

			public interface IAudioTranscript
			{
				event EventHandler<AudioTranscriptStreamEvent>? OnDelta;

				event EventHandler<AudioTranscriptStreamEvent>? OnDone;
			}

			public interface IAudio
			{
				event EventHandler<AudioStreamEvent>? OnDelta;

				event EventHandler<AudioStreamEvent>? OnDone;
			}

			public interface IFunctionCallArguments
			{
				event EventHandler<FunctionCallStreamEvent>? OnDelta;

				event EventHandler<FunctionCallStreamEvent>? OnDone;
			}

			IOutputItem OutputItem { get; }

			IContentPart ContentPart { get; }

			IText Text { get; }

			IAudioTranscript AudioTranscript { get; }

			IAudio Audio { get; }

			IFunctionCallArguments FunctionCallArguments { get; }

			event EventHandler<ResponseEvent>? OnCreated;

			event EventHandler<ResponseEvent>? OnDone;
		}

		public interface IRateLimits
		{
			event EventHandler<RateLimitsEvent>? OnUpdated;
		}

		ISession Session { get; }

		IConversation Conversation { get; }

		IInputAudioBuffer InputAudioBuffer { get; }

		IResponse Response { get; }

		IRateLimits RateLimits { get; }

		event EventHandler<ErrorEvent>? OnError;

		event EventHandler<string>? OnAll;
	}
}
namespace Betalgo.Ranul.OpenAI.Interfaces
{
	public interface IAssistantService
	{
		Task<AssistantResponse> AssistantCreate(AssistantCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<AssistantListResponse> AssistantList(PaginationRequest? request = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<AssistantResponse> AssistantRetrieve(string assistantId, CancellationToken cancellationToken = default(CancellationToken));

		Task<AssistantResponse> AssistantModify(string assistantId, AssistantModifyRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<DeletionStatusResponse> AssistantDelete(string assistantId, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IAudioService
	{
		Task<AudioCreateTranscriptionResponse> CreateTranscription(AudioCreateTranscriptionRequest audioCreateTranscriptionRequest, CancellationToken cancellationToken = default(CancellationToken));

		Task<AudioCreateTranscriptionResponse> CreateTranslation(AudioCreateTranscriptionRequest audioCreateTranscriptionRequest, CancellationToken cancellationToken = default(CancellationToken));

		Task<AudioCreateSpeechResponse<T>> CreateSpeech<T>(AudioCreateSpeechRequest audioCreateSpeechRequest, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IBatchService
	{
		Task<BatchResponse> BatchCreate(BatchCreateRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<BatchResponse?> BatchRetrieve(string batchId, CancellationToken cancellationToken = default(CancellationToken));

		Task<BatchResponse> BatchCancel(string batchId, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IBetaService
	{
		IAssistantService Assistants { get; }

		IMessageService Messages { get; }

		IThreadService Threads { get; }

		IRunService Runs { get; }

		IRunStepService RunSteps { get; }

		IVectorStores VectorStores { get; }

		IVectorStoreFiles VectorStoreFiles { get; }
	}
	public interface IChatCompletionService
	{
		Task<ChatCompletionCreateResponse> CreateCompletion(ChatCompletionCreateRequest chatCompletionCreate, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken));

		IAsyncEnumerable<ChatCompletionCreateResponse> CreateCompletionAsStream(ChatCompletionCreateRequest chatCompletionCreate, string? modelId = null, bool justDataMode = true, CancellationToken cancellationToken = default(CancellationToken));
	}
	public static class IChatCompletionServiceExtension
	{
		public static Task<ChatCompletionCreateResponse> Create(this IChatCompletionService service, ChatCompletionCreateRequest chatCompletionCreate, Models.Model modelId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.CreateCompletion(chatCompletionCreate, modelId.EnumToString(), cancellationToken);
		}
	}
	public interface ICompletionService
	{
		Task<CompletionCreateResponse> CreateCompletion(CompletionCreateRequest createCompletionModel, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken));

		IAsyncEnumerable<CompletionCreateResponse> CreateCompletionAsStream(CompletionCreateRequest createCompletionModel, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken));
	}
	public static class ICompletionServiceExtension
	{
		public static Task<CompletionCreateResponse> Create(this ICompletionService service, CompletionCreateRequest createCompletionModel, Models.Model modelId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.CreateCompletion(createCompletionModel, modelId.EnumToString(), cancellationToken);
		}
	}
	public interface IEditService
	{
		Task<EditCreateResponse> CreateEdit(EditCreateRequest editCreate, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken));
	}
	public static class IEditServiceExtension
	{
		public static Task<EditCreateResponse> Edit(this IEditService service, EditCreateRequest editCreate, Models.Model modelId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.CreateEdit(editCreate, modelId.EnumToString(), cancellationToken);
		}
	}
	public interface IEmbeddingService
	{
		Task<EmbeddingCreateResponse> CreateEmbedding(EmbeddingCreateRequest createEmbeddingModel, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IFileService
	{
		Task<FileListResponse> ListFile(CancellationToken cancellationToken = default(CancellationToken));

		Task<FileUploadResponse> UploadFile(string purpose, byte[] file, string fileName, CancellationToken cancellationToken = default(CancellationToken));

		Task<FileDeleteResponse> DeleteFile(string fileId, CancellationToken cancellationToken = default(CancellationToken));

		Task<FileResponse> RetrieveFile(string fileId, CancellationToken cancellationToken = default(CancellationToken));

		Task<FileContentResponse<T?>> RetrieveFileContent<T>(string fileId, CancellationToken cancellationToken = default(CancellationToken));
	}
	public static class IFileServiceExtension
	{
		public static Task<FileUploadResponse> FileUpload(this IFileService service, string purpose, Stream file, string fileName, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.UploadFile(purpose, file.ToByteArray(), fileName, cancellationToken);
		}

		public static Task<FileUploadResponse> FileUpload(this IFileService service, UploadFilePurposes.UploadFilePurpose purpose, Stream file, string fileName, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.UploadFile(purpose.EnumToString(), file.ToByteArray(), fileName, cancellationToken);
		}

		public static Task<FileUploadResponse> FileUpload(this IFileService service, UploadFilePurposes.UploadFilePurpose purpose, byte[] file, string fileName, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.UploadFile(purpose.EnumToString(), file, fileName, cancellationToken);
		}

		public static Task<FileContentResponse<string?>> RetrieveFileContent(this IFileService service, string fileId, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.RetrieveFileContent<string>(fileId, cancellationToken);
		}
	}
	public interface IFineTuneService
	{
		Task<FineTuneResponse> CreateFineTune(FineTuneCreateRequest createFineTuneRequest, CancellationToken cancellationToken = default(CancellationToken));

		Task<FineTuneListResponse> ListFineTunes(CancellationToken cancellationToken = default(CancellationToken));

		Task<FineTuneResponse> RetrieveFineTune(string fineTuneId, CancellationToken cancellationToken = default(CancellationToken));

		Task<FineTuneResponse> CancelFineTune(string fineTuneId, CancellationToken cancellationToken = default(CancellationToken));

		Task<Stream> ListFineTuneEvents(string fineTuneId, bool? stream = null, CancellationToken cancellationToken = default(CancellationToken));

		Task DeleteFineTune(string fineTuneId, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IFineTuningJobService
	{
		Task<FineTuningJobResponse> CreateFineTuningJob(FineTuningJobCreateRequest createFineTuningJobRequest, CancellationToken cancellationToken = default(CancellationToken));

		Task<FineTuningJobListResponse> ListFineTuningJobs(FineTuningJobListRequest? fineTuningJobListRequest = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<FineTuningJobResponse> RetrieveFineTuningJob(string fineTuningJobId, CancellationToken cancellationToken = default(CancellationToken));

		Task<FineTuningJobResponse> CancelFineTuningJob(string fineTuningJobId, CancellationToken cancellationToken = default(CancellationToken));

		Task<Stream> ListFineTuningJobEvents(FineTuningJobListEventsRequest model, bool? stream = null, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IImageService
	{
		Task<ImageCreateResponse> CreateImage(ImageCreateRequest imageCreate, CancellationToken cancellationToken = default(CancellationToken));

		Task<ImageCreateResponse> CreateImageEdit(ImageEditCreateRequest imageEditCreateRequest, CancellationToken cancellationToken = default(CancellationToken));

		Task<ImageCreateResponse> CreateImageVariation(ImageVariationCreateRequest imageEditCreateRequest, CancellationToken cancellationToken = default(CancellationToken));
	}
	public static class IImageServiceExtension
	{
		public static Task<ImageCreateResponse> CreateImage(this IImageService service, string prompt, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.CreateImage(new ImageCreateRequest(prompt), cancellationToken);
		}
	}
	public interface IMessageService
	{
		Task<MessageResponse> CreateMessage(string threadId, MessageCreateRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<MessageListResponse> ListMessages(string threadId, MessageListRequest? request = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<MessageResponse> RetrieveMessage(string threadId, string messageId, CancellationToken cancellationToken = default(CancellationToken));

		Task<MessageResponse> ModifyMessage(string threadId, string messageId, ModifyMessageRequest requestBody, CancellationToken cancellationToken = default(CancellationToken));

		Task<DeletionStatusResponse> DeleteMessage(string threadId, string messageId, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IModelService
	{
		Task<ModelListResponse> ListModel(CancellationToken cancellationToken = default(CancellationToken));

		Task<ModelRetrieveResponse> RetrieveModel(string model, CancellationToken cancellationToken = default(CancellationToken));

		Task<ModelDeleteResponse?> DeleteModel(string modelId, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IModelValidate
	{
		IEnumerable<ValidationResult> Validate();
	}
	public interface IModerationService
	{
		Task<CreateModerationResponse> CreateModeration(CreateModerationRequest createModerationRequest, CancellationToken cancellationToken = default(CancellationToken));
	}
	public static class IModerationServiceExtension
	{
		public static Task<CreateModerationResponse> CreateModeration(this IModerationService service, string input, string? model = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return service.CreateModeration(new CreateModerationRequest
			{
				Input = input,
				Model = model
			}, cancellationToken);
		}
	}
	public interface IOpenAIService
	{
		IModelService Models { get; }

		ICompletionService Completions { get; }

		IEmbeddingService Embeddings { get; }

		IFileService Files { get; }

		IFineTuneService FineTunes { get; }

		IFineTuningJobService FineTuningJob { get; }

		IModerationService Moderation { get; }

		IImageService Image { get; }

		IEditService Edit { get; }

		IChatCompletionService ChatCompletion { get; }

		IAudioService Audio { get; }

		IBatchService Batch { get; }

		IBetaService Beta { get; }

		void SetDefaultModelId(string modelId);
	}
	public interface IRunService
	{
		Task<RunResponse> RunCreate(string threadId, RunCreateRequest request, string? modelId = null, CancellationToken cancellationToken = default(CancellationToken));

		IAsyncEnumerable<BaseResponse> RunCreateAsStream(string threadId, RunCreateRequest request, string? modelId = null, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken));

		Task<RunResponse> RunRetrieve(string threadId, string runId, CancellationToken cancellationToken = default(CancellationToken));

		Task<RunResponse> RunCancel(string threadId, string runId, CancellationToken cancellationToken = default(CancellationToken));

		Task<RunResponse> RunSubmitToolOutputs(string threadId, string runId, SubmitToolOutputsToRunRequest request, CancellationToken cancellationToken = default(CancellationToken));

		IAsyncEnumerable<BaseResponse> RunSubmitToolOutputsAsStream(string threadId, string runId, SubmitToolOutputsToRunRequest request, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken));

		Task<RunResponse> RunModify(string threadId, string runId, RunModifyRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<RunResponse> CreateThreadAndRun(CreateThreadAndRunRequest requestBody, CancellationToken cancellationToken = default(CancellationToken));

		IAsyncEnumerable<BaseResponse> CreateThreadAndRunAsStream(CreateThreadAndRunRequest createThreadAndRunRequest, string? modelId = null, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken));

		Task<RunListResponse> ListRuns(string threadId, PaginationRequest runListRequest, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IRunStepService
	{
		Task<RunStepListResponse> RunStepsList(string threadId, string runId, PaginationRequest? request = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<RunStepResponse> RunStepRetrieve(string threadId, string runId, string stepId, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IThreadService
	{
		Task<ThreadResponse> ThreadCreate(ThreadCreateRequest? request = null, CancellationToken cancellationToken = default(CancellationToken));

		Task<ThreadResponse> ThreadRetrieve(string threadId, CancellationToken cancellationToken = default(CancellationToken));

		Task<DeletionStatusResponse> ThreadDelete(string threadId, CancellationToken cancellationToken = default(CancellationToken));

		Task<ThreadResponse> ModifyThread(string threadId, ModifyThreadRequest requestBody, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IVectorStoreFiles
	{
		Task<VectorStoreFileListObject> ListVectorStoreFiles(string vectorStoreId, VectorStoreFileListRequest baseListRequest, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreFileObject> CreateVectorStoreFile(string vectorStoreId, CreateVectorStoreFileRequest requestBody, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreFileObject> GetVectorStoreFile(string vectorStoreId, string fileId, CancellationToken cancellationToken = default(CancellationToken));

		Task<DeletionStatusResponse> DeleteVectorStoreFile(string vectorStoreId, string fileId, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreFileBatchObject> CreateVectorStoreFileBatch(string vectorStoreId, CreateVectorStoreFileBatchRequest requestBody, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreFileBatchObject> GetVectorStoreFileBatch(string vectorStoreId, string batchId, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreFileBatchObject> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreFileBatchListObjectResponse> ListFilesInVectorStoreBatch(string vectorStoreId, string batchId, PaginationRequest baseListRequest, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IVectorStores
	{
		Task<VectorStoreListObjectResponse> ListVectorStores(PaginationRequest request, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreObjectResponse> CreateVectorStore(CreateVectorStoreRequest requestBody, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreObjectResponse> RetrieveVectorStore(string vectorStoreId, CancellationToken cancellationToken = default(CancellationToken));

		Task<VectorStoreObjectResponse> ModifyVectorStore(string vectorStoreId, UpdateVectorStoreRequest requestBody, CancellationToken cancellationToken = default(CancellationToken));

		Task<DeletionStatusResponse> DeleteVectorStore(string vectorStoreId, CancellationToken cancellationToken = default(CancellationToken));
	}
}
namespace Betalgo.Ranul.OpenAI.Extensions
{
	internal static class FileExtensions
	{
		internal static byte[] ToByteArray(this Stream input)
		{
			byte[] array = new byte[16384];
			using MemoryStream memoryStream = new MemoryStream();
			int count;
			while ((count = input.Read(array, 0, array.Length)) > 0)
			{
				memoryStream.Write(array, 0, count);
			}
			return memoryStream.ToArray();
		}
	}
	internal static class HttpClientExtensions
	{
		public static async Task<TResponse> GetReadAsAsync<TResponse>(this HttpClient client, string uri, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponse, new()
		{
			return await (await client.GetAsync(uri, cancellationToken)).HandleResponseContent<TResponse>(cancellationToken);
		}

		public static async Task<TResponse> PostAndReadAsAsync<TResponse>(this HttpClient client, string uri, object? requestModel, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponse, new()
		{
			return await (await client.PostAsJsonAsync(uri, requestModel, new JsonSerializerOptions
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
			}, cancellationToken)).HandleResponseContent<TResponse>(cancellationToken);
		}

		public static string? GetHeaderValue(this HttpResponseHeaders headers, string headerName)
		{
			if (!headers.Contains(headerName))
			{
				return null;
			}
			return headers.GetValues(headerName).FirstOrDefault();
		}

		public static async Task<TResponse> PostAndReadAsDataAsync<TResponse, TData>(this HttpClient client, string uri, object? requestModel, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : DataBaseResponse<TData>, new()
		{
			HttpResponseMessage httpResponseMessage = await client.PostAsJsonAsync(uri, requestModel, new JsonSerializerOptions
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
			}, cancellationToken);
			if (!httpResponseMessage.IsSuccessStatusCode)
			{
				return await httpResponseMessage.HandleResponseContent<TResponse>(cancellationToken);
			}
			TData data;
			if (typeof(TData) == typeof(byte[]))
			{
				data = (TData)(object)(await httpResponseMessage.Content.ReadAsByteArrayAsync(cancellationToken));
			}
			else if (typeof(TData) == typeof(Stream))
			{
				data = (TData)(object)(await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken));
			}
			else
			{
				if (!(typeof(TData) == typeof(string)))
				{
					throw new NotSupportedException("Unsupported type for TData");
				}
				data = (TData)(object)(await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));
			}
			return new TResponse
			{
				Data = data
			};
		}

		public static HttpResponseMessage PostAsStreamAsync(this HttpClient client, string uri, object requestModel, CancellationToken cancellationToken = default(CancellationToken))
		{
			JsonSerializerOptions options = new JsonSerializerOptions
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
			};
			JsonContent content = JsonContent.Create(requestModel, null, options);
			using HttpRequestMessage request = CreatePostEventStreamRequest(uri, content);
			try
			{
				return client.Send(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
			}
			catch (PlatformNotSupportedException)
			{
				using HttpRequestMessage request2 = CreatePostEventStreamRequest(uri, content);
				return SendRequestPreNet6(client, request2, cancellationToken);
			}
		}

		private static HttpResponseMessage SendRequestPreNet6(HttpClient client, HttpRequestMessage request, CancellationToken cancellationToken)
		{
			return client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).GetAwaiter().GetResult();
		}

		private static HttpRequestMessage CreatePostEventStreamRequest(string uri, HttpContent content)
		{
			return new HttpRequestMessage(HttpMethod.Post, uri)
			{
				Headers = 
				{
					Accept = 
					{
						new MediaTypeWithQualityHeaderValue("text/event-stream")
					}
				},
				Content = content
			};
		}

		public static async Task<TResponse> PostFileAndReadAsAsync<TResponse>(this HttpClient client, string uri, HttpContent content, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponse, new()
		{
			return await (await client.PostAsync(uri, content, cancellationToken)).HandleResponseContent<TResponse>(cancellationToken);
		}

		public static async Task<(string? stringResponse, TResponse baseResponse)> PostFileAndReadAsStringAsync<TResponse>(this HttpClient client, string uri, HttpContent content, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponse, new()
		{
			HttpResponseMessage httpResponseMessage = await client.PostAsync(uri, content, cancellationToken);
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				return new ValueTuple<string, TResponse>(item2: new TResponse
				{
					HttpStatusCode = httpResponseMessage.StatusCode,
					HeaderValues = httpResponseMessage.ParseHeaders()
				}, item1: await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));
			}
			return (stringResponse: null, baseResponse: await httpResponseMessage.HandleResponseContent<TResponse>(cancellationToken));
		}

		public static async Task<TResponse> DeleteAndReadAsAsync<TResponse>(this HttpClient client, string uri, CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponse, new()
		{
			return await (await client.DeleteAsync(uri, cancellationToken)).HandleResponseContent<TResponse>(cancellationToken);
		}

		public static async Task<TResponse> HandleResponseContent<TResponse>(this HttpResponseMessage response, CancellationToken cancellationToken) where TResponse : BaseResponse, new()
		{
			MediaTypeHeaderValue? contentType = response.Content.Headers.ContentType;
			bool? flag;
			if (contentType == null)
			{
				flag = null;
			}
			else
			{
				string? mediaType = contentType.MediaType;
				flag = ((mediaType != null) ? new bool?(!mediaType.Equals("application/json", StringComparison.OrdinalIgnoreCase)) : ((bool?)null));
			}
			TResponse val3;
			if (flag ?? true)
			{
				TResponse val = new TResponse();
				TResponse val2 = val;
				Error error = new Error();
				Error error2 = error;
				error2.MessageObject = await response.Content.ReadAsStringAsync(cancellationToken);
				val2.Error = error;
				val3 = val;
			}
			else
			{
				val3 = (await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken)) ?? throw new InvalidOperationException();
			}
			val3.HttpStatusCode = response.StatusCode;
			val3.HeaderValues = response.ParseHeaders();
			return val3;
		}

		public static ResponseHeaderValues ParseHeaders(this HttpResponseMessage response)
		{
			return new ResponseHeaderValues
			{
				Date = response.Headers.Date,
				Connection = response.Headers.Connection?.ToString(),
				AccessControlAllowOrigin = response.Headers.GetHeaderValue("access-control-allow-origin"),
				CacheControl = response.Headers.GetHeaderValue("cache-control"),
				Vary = response.Headers.Vary?.ToString(),
				XRequestId = response.Headers.GetHeaderValue("x-request-id"),
				StrictTransportSecurity = response.Headers.GetHeaderValue("strict-transport-security"),
				CFCacheStatus = response.Headers.GetHeaderValue("cf-cache-status"),
				SetCookie = (response.Headers.Contains("set-cookie") ? response.Headers.GetValues("set-cookie").ToList() : null),
				Server = response.Headers.Server?.ToString(),
				CF_RAY = response.Headers.GetHeaderValue("cf-ray"),
				AltSvc = response.Headers.GetHeaderValue("alt-svc"),
				All = response.Headers.ToDictionary((KeyValuePair<string, IEnumerable<string>> x) => x.Key, (KeyValuePair<string, IEnumerable<string>> x) => x.Value.AsEnumerable()),
				RateLimits = new RateLimitInfo
				{
					LimitRequests = response.Headers.GetHeaderValue("x-ratelimit-limit-requests"),
					LimitTokens = response.Headers.GetHeaderValue("x-ratelimit-limit-tokens"),
					LimitTokensUsageBased = response.Headers.GetHeaderValue("x-ratelimit-limit-tokens_usage_based"),
					RemainingRequests = response.Headers.GetHeaderValue("x-ratelimit-remaining-requests"),
					RemainingTokens = response.Headers.GetHeaderValue("x-ratelimit-remaining-tokens"),
					RemainingTokensUsageBased = response.Headers.GetHeaderValue("x-ratelimit-remaining-tokens_usage_based"),
					ResetRequests = response.Headers.GetHeaderValue("x-ratelimit-reset-requests"),
					ResetTokens = response.Headers.GetHeaderValue("x-ratelimit-reset-tokens"),
					ResetTokensUsageBased = response.Headers.GetHeaderValue("x-ratelimit-reset-tokens_usage_based")
				},
				OpenAI = new OpenAIInfo
				{
					Model = response.Headers.GetHeaderValue("openai-model"),
					Organization = response.Headers.GetHeaderValue("openai-organization"),
					ProcessingMs = response.Headers.GetHeaderValue("openai-processing-ms"),
					Version = response.Headers.GetHeaderValue("openai-version")
				}
			};
		}
	}
	public static class JsonToObjectRouterExtension
	{
		public static Type Route(string json)
		{
			return JsonSerializer.Deserialize<ObjectBaseResponse>(json)?.ObjectTypeName switch
			{
				"thread.run.step" => typeof(RunStepResponse), 
				"thread.run" => typeof(RunResponse), 
				"thread.message" => typeof(MessageResponse), 
				"thread.message.delta" => typeof(MessageResponse), 
				_ => typeof(BaseResponse), 
			};
		}
	}
	public static class ModelExtension
	{
		public static void ProcessModelId(this IOpenAIModels.IModel modelFromObject, string? modelFromParameter, string? defaultModelId, bool allowNull = false)
		{
			if (allowNull)
			{
				modelFromObject.Model = modelFromParameter ?? modelFromObject.Model ?? defaultModelId;
			}
			else
			{
				modelFromObject.Model = modelFromParameter ?? modelFromObject.Model ?? defaultModelId ?? throw new ArgumentNullException("Model Id");
			}
		}
	}
	public static class OpenAIRealtimeServiceCollectionExtensions
	{
		public static OpenAIRealtimeServiceBuilder AddOpenAIRealtimeService(this IServiceCollection services)
		{
			services.AddOptions<OpenAIOptions>().BindConfiguration(OpenAIOptions.SettingKey);
			OpenAIRealtimeServiceBuilder openAIRealtimeServiceBuilder = new OpenAIRealtimeServiceBuilder(services);
			openAIRealtimeServiceBuilder.Build();
			return openAIRealtimeServiceBuilder;
		}

		public static OpenAIRealtimeServiceBuilder AddOpenAIRealtimeService(this IServiceCollection services, Action<OpenAIOptions> configureOptions)
		{
			services.Configure(configureOptions);
			OpenAIRealtimeServiceBuilder openAIRealtimeServiceBuilder = new OpenAIRealtimeServiceBuilder(services);
			openAIRealtimeServiceBuilder.Build();
			return openAIRealtimeServiceBuilder;
		}

		public static OpenAIRealtimeServiceBuilder AddOpenAIRealtimeService(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<OpenAIOptions>(configuration.GetSection(OpenAIOptions.SettingKey));
			OpenAIRealtimeServiceBuilder openAIRealtimeServiceBuilder = new OpenAIRealtimeServiceBuilder(services);
			openAIRealtimeServiceBuilder.Build();
			return openAIRealtimeServiceBuilder;
		}
	}
	public static class OpenAIServiceCollectionExtensions
	{
		public static IHttpClientBuilder AddOpenAIService(this IServiceCollection services, Action<OpenAIOptions>? setupAction = null)
		{
			OptionsBuilder<OpenAIOptions> optionsBuilder = services.AddOptions<OpenAIOptions>();
			optionsBuilder.BindConfiguration(OpenAIOptions.SettingKey);
			if (setupAction != null)
			{
				optionsBuilder.Configure(setupAction);
			}
			return services.AddHttpClient<IOpenAIService, OpenAIService>();
		}

		public static IHttpClientBuilder AddOpenAIService<TServiceInterface>(this IServiceCollection services, string name, Action<OpenAIOptions>? setupAction = null) where TServiceInterface : class, IOpenAIService
		{
			OptionsBuilder<OpenAIOptions> optionsBuilder = services.AddOptions<OpenAIOptions>(name);
			optionsBuilder.BindConfiguration(OpenAIOptions.SettingKey + ":" + name);
			if (setupAction != null)
			{
				optionsBuilder.Configure(setupAction);
			}
			return services.AddHttpClient<TServiceInterface>();
		}
	}
	public static class StreamHandleExtension
	{
		private class ReassemblyContext
		{
			private IList<ToolCall> _deltaFnCallList = new List<ToolCall>();

			public bool IsFnAssemblyActive => _deltaFnCallList.Count > 0;

			public void Process(ChatCompletionCreateResponse block)
			{
				ChatChoiceResponse firstChoice = block.Choices?.FirstOrDefault();
				if (firstChoice == null)
				{
					return;
				}
				bool flag = IsStreamingFunctionCall();
				bool flag2 = firstChoice.FinishReason != null;
				bool flag3 = false;
				if (flag)
				{
					foreach (ToolCall toolCall2 in firstChoice.Message.ToolCalls)
					{
						if (toolCall2.FunctionCall != null && toolCall2.Type == StaticValues.CompletionStatics.ToolType.Function)
						{
							_deltaFnCallList.Add(toolCall2);
						}
					}
					flag3 = true;
				}
				if (IsFnAssemblyActive && !flag3)
				{
					(int index, string? id, string? type) tcMetadata = GetToolCallMetadata();
					if (tcMetadata.index > -1)
					{
						using IEnumerator<string> enumerator2 = ExtractArgsSoFar().GetEnumerator();
						if (enumerator2.MoveNext())
						{
							_deltaFnCallList.First((ToolCall t) => t.Index == tcMetadata.index).FunctionCall.Arguments += enumerator2.Current;
							enumerator2.MoveNext();
						}
					}
				}
				if (IsFnAssemblyActive & flag2)
				{
					ChatChoiceResponse chatChoiceResponse = firstChoice;
					Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage chatMessage;
					if (chatChoiceResponse.Message == null)
					{
						chatMessage = (chatChoiceResponse.Message = Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage.FromAssistant(""));
					}
					chatMessage = firstChoice.Message;
					if (chatMessage.Role == null)
					{
						string text = (chatMessage.Role = "assistant");
					}
					firstChoice.Message.ToolCalls = new List<ToolCall>(_deltaFnCallList);
					_deltaFnCallList.Clear();
				}
				IEnumerable<string> ExtractArgsSoFar()
				{
					IList<ToolCall> list = block.Choices?.FirstOrDefault()?.Message?.ToolCalls;
					if (list != null)
					{
						IEnumerable<FunctionCall> enumerable = from t in list
							where t.FunctionCall != null
							select t.FunctionCall;
						foreach (FunctionCall item in enumerable)
						{
							yield return item.Arguments ?? "";
						}
					}
				}
				(int index, string? id, string? type) GetToolCallMetadata()
				{
					ToolCall toolCall = block.Choices?.FirstOrDefault()?.Message?.ToolCalls?.Where((ToolCall t) => t.FunctionCall != null).Select((ToolCall t) => t).FirstOrDefault();
					if (toolCall != null)
					{
						return (index: toolCall.Index, id: toolCall.Id, type: toolCall.Type);
					}
					return (index: -1, id: null, type: null);
				}
				bool IsStreamingFunctionCall()
				{
					if (firstChoice.FinishReason == null)
					{
						Betalgo.Ranul.OpenAI.ObjectModels.RequestModels.ChatMessage message = firstChoice.Message;
						if (message != null && message.ToolCalls?.Count > 0)
						{
							return firstChoice.Message?.ToolCalls.Any((ToolCall t) => t.FunctionCall != null && !string.IsNullOrEmpty(t.Id) && t.Type == StaticValues.CompletionStatics.ToolType.Function) ?? false;
						}
					}
					return false;
				}
			}
		}

		public static async IAsyncEnumerable<BaseResponse> AsStream(this HttpResponseMessage response, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
		{
			await foreach (BaseResponse item in response.AsStream<BaseResponse>(justDataMode, cancellationToken))
			{
				yield return item;
			}
		}

		public static async IAsyncEnumerable<TResponse> AsStream<TResponse>(this HttpResponseMessage response, bool justDataMode = true, [EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken)) where TResponse : BaseResponse, new()
		{
			ReassemblyContext ctx = new ReassemblyContext();
			HttpStatusCode httpStatusCode = response.StatusCode;
			ResponseHeaderValues headerValues = response.ParseHeaders();
			await using Stream stream = await response.Content.ReadAsStreamAsync(cancellationToken);
			using StreamReader reader = new StreamReader(stream);
			string tempStreamEvent = null;
			while (true)
			{
				cancellationToken.ThrowIfCancellationRequested();
				string text = await reader.ReadLineAsync();
				if (text == null)
				{
					break;
				}
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				bool flag;
				if (text.StartsWith("event: "))
				{
					text = text.RemoveIfStartWith("event: ");
					tempStreamEvent = text;
					flag = true;
				}
				else
				{
					flag = false;
				}
				if (justDataMode && !text.StartsWith("data: "))
				{
					continue;
				}
				if (!justDataMode & flag)
				{
					yield return new TResponse
					{
						ObjectTypeName = "base.stream.event",
						StreamEvent = tempStreamEvent
					};
					continue;
				}
				text = text.RemoveIfStartWith("data: ");
				if (text.StartsWith("[DONE]"))
				{
					break;
				}
				TResponse block;
				try
				{
					block = ((!(typeof(TResponse) == typeof(BaseResponse))) ? JsonSerializer.Deserialize<TResponse>(text) : (JsonSerializer.Deserialize(text, JsonToObjectRouterExtension.Route(text), new JsonSerializerOptions()) as TResponse));
				}
				catch (Exception)
				{
					string text2 = text;
					text = text2 + await reader.ReadToEndAsync();
					block = JsonSerializer.Deserialize<TResponse>(text);
				}
				if (null != block)
				{
					if (typeof(TResponse) == typeof(ChatCompletionCreateResponse))
					{
						ctx.Process((block as ChatCompletionCreateResponse) ?? throw new InvalidOperationException());
					}
					if (!ctx.IsFnAssemblyActive)
					{
						block.HttpStatusCode = httpStatusCode;
						block.HeaderValues = headerValues;
						block.StreamEvent = tempStreamEvent;
						tempStreamEvent = null;
						yield return block;
					}
				}
			}
		}
	}
	public static class StringExtensions
	{
		public static string RemoveIfStartWith(this string text, string search)
		{
			if (text.IndexOf(search, StringComparison.Ordinal) == 0)
			{
				return text.Substring(search.Length);
			}
			return text;
		}
	}
}
namespace Betalgo.Ranul.OpenAI.EndpointProviders
{
	internal class AzureOpenAIEndpointProvider : IOpenAIEndpointProvider
	{
		private const string DeploymentsPrefix = "deployments";

		private const string ApiPrefix = "openai";

		private readonly string _apiVersion;

		private readonly string _deploymentId;

		private string Prefix => $"{"openai"}/{"deployments"}/{WebUtility.UrlEncode(_deploymentId)}";

		private string AzureVersionQueryString => "?api-version=" + _apiVersion;

		private string AssistantPrefix => "openai/";

		private string DataPlanePrefix => "openai/";

		public AzureOpenAIEndpointProvider(string apiVersion, string deploymentId)
		{
			_apiVersion = apiVersion;
			_deploymentId = deploymentId;
		}

		public string ModelRetrieve(string model)
		{
			return DataPlanePrefix + "/models/" + model + AzureVersionQueryString;
		}

		public string FileDelete(string fileId)
		{
			return DataPlanePrefix + "/files/" + fileId + AzureVersionQueryString;
		}

		public string CompletionCreate()
		{
			return Prefix + "/completions" + AzureVersionQueryString;
		}

		public string EditCreate()
		{
			return Prefix + "/edits" + AzureVersionQueryString;
		}

		public string ModelsList()
		{
			return DataPlanePrefix + "/models" + AzureVersionQueryString;
		}

		public string FilesList()
		{
			return Files();
		}

		public string FilesUpload()
		{
			return Files();
		}

		public string FileRetrieve(string fileId)
		{
			return DataPlanePrefix + "/files/" + fileId + AzureVersionQueryString;
		}

		public string FileRetrieveContent(string fileId)
		{
			return $"{DataPlanePrefix}/files/{fileId}/content{AzureVersionQueryString}";
		}

		public string FineTuneCreate()
		{
			return Prefix + "/fine-tunes" + AzureVersionQueryString;
		}

		public string FineTuneList()
		{
			return Prefix + "/fine-tunes" + AzureVersionQueryString;
		}

		public string FineTuneRetrieve(string fineTuneId)
		{
			return Prefix + "/fine-tunes/" + fineTuneId + AzureVersionQueryString;
		}

		public string FineTuneCancel(string fineTuneId)
		{
			return $"{Prefix}/fine-tunes/{fineTuneId}/cancel{AzureVersionQueryString}";
		}

		public string FineTuneListEvents(string fineTuneId)
		{
			return $"{Prefix}/fine-tunes/{fineTuneId}/events{AzureVersionQueryString}";
		}

		public string FineTuneDelete(string fineTuneId)
		{
			return DataPlanePrefix + "/fine_tuning/jobs/" + fineTuneId + AzureVersionQueryString;
		}

		public string FineTuningJobCreate()
		{
			return DataPlanePrefix + "/fine_tuning/jobs" + AzureVersionQueryString;
		}

		public string FineTuningJobList(FineTuningJobListRequest? fineTuningJobListRequest)
		{
			string text = DataPlanePrefix + "/fine_tuning/jobs";
			if (fineTuningJobListRequest != null)
			{
				List<string> list = new List<string>();
				if (fineTuningJobListRequest.After != null)
				{
					list.Add("after=" + WebUtility.UrlEncode(fineTuningJobListRequest.After));
				}
				if (fineTuningJobListRequest.Limit.HasValue)
				{
					list.Add($"limit={fineTuningJobListRequest.Limit.Value}");
				}
				if (list.Any())
				{
					text = text + AzureVersionQueryString + "&" + string.Join("&", list);
				}
			}
			return text;
		}

		public string FineTuningJobRetrieve(string fineTuningJobId)
		{
			return DataPlanePrefix + "/fine_tuning/jobs/" + fineTuningJobId + AzureVersionQueryString;
		}

		public string FineTuningJobCancel(string fineTuningJobId)
		{
			return $"{DataPlanePrefix}/fine_tuning/jobs/{fineTuningJobId}/cancel{AzureVersionQueryString}";
		}

		public string FineTuningJobListEvents(string fineTuningJobId)
		{
			return $"{DataPlanePrefix}/fine_tuning/jobs/{fineTuningJobId}/events{AzureVersionQueryString}";
		}

		public string ModelsDelete(string modelId)
		{
			return DataPlanePrefix + "/models/" + modelId + AzureVersionQueryString;
		}

		public string EmbeddingCreate()
		{
			return Prefix + "/embeddings" + AzureVersionQueryString;
		}

		public string ModerationCreate()
		{
			return Prefix + "/moderations" + AzureVersionQueryString;
		}

		public string ImageCreate()
		{
			return Prefix + "/images/generations" + AzureVersionQueryString;
		}

		public string ImageEditCreate()
		{
			return Prefix + "/images/edits" + AzureVersionQueryString;
		}

		public string ImageVariationCreate()
		{
			return Prefix + "/images/variations" + AzureVersionQueryString;
		}

		public string ChatCompletionCreate()
		{
			return Prefix + "/chat/completions" + AzureVersionQueryString;
		}

		public string AudioCreateTranscription()
		{
			return Prefix + "/audio/transcriptions" + AzureVersionQueryString;
		}

		public string AudioCreateTranslation()
		{
			return Prefix + "/audio/translation" + AzureVersionQueryString;
		}

		public string AudioCreateSpeech()
		{
			return Prefix + "/audio/speech" + AzureVersionQueryString;
		}

		public string AssistantCreate()
		{
			return AssistantPrefix + "/assistants" + AzureVersionQueryString;
		}

		public string AssistantRetrieve(string assistantId)
		{
			return AssistantPrefix + "/assistants/" + assistantId + AzureVersionQueryString;
		}

		public string AssistantModify(string assistantId)
		{
			return AssistantPrefix + "/assistants/" + assistantId + AzureVersionQueryString;
		}

		public string AssistantDelete(string assistantId)
		{
			return AssistantPrefix + "/assistants/" + assistantId + AzureVersionQueryString;
		}

		public string AssistantList(PaginationRequest? assistantListRequest)
		{
			string text = AssistantPrefix + "/assistants" + AzureVersionQueryString;
			string text2 = assistantListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string AssistantFileCreate(string assistantId)
		{
			return $"{AssistantPrefix}/assistants/{assistantId}/files{AzureVersionQueryString}";
		}

		public string AssistantFileRetrieve(string assistantId, string fileId)
		{
			return $"{AssistantPrefix}/assistants/{assistantId}/files/{fileId}{AzureVersionQueryString}";
		}

		public string AssistantFileDelete(string assistantId, string fileId)
		{
			return $"{AssistantPrefix}/assistants/{assistantId}/files/{fileId}{AzureVersionQueryString}";
		}

		public string AssistantFileList(string assistantId, PaginationRequest? assistantFileListRequest)
		{
			string text = AssistantPrefix + "/assistants/files" + AzureVersionQueryString;
			string text2 = assistantFileListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string ThreadCreate()
		{
			return AssistantPrefix + "/threads" + AzureVersionQueryString;
		}

		public string ThreadRetrieve(string threadId)
		{
			return AssistantPrefix + "/threads/" + threadId + AzureVersionQueryString;
		}

		public string ThreadModify(string threadId)
		{
			return AssistantPrefix + "/threads/" + threadId + AzureVersionQueryString;
		}

		public string ThreadDelete(string threadId)
		{
			return AssistantPrefix + "/threads/" + threadId + AzureVersionQueryString;
		}

		public string MessageCreate(string threadId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/messages{AzureVersionQueryString}";
		}

		public string MessageRetrieve(string threadId, string messageId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/messages/{messageId}{AzureVersionQueryString}";
		}

		public string MessageModify(string threadId, string messageId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/messages/{messageId}{AzureVersionQueryString}";
		}

		public string MessageList(string threadId, MessageListRequest? messageListRequest)
		{
			string text = $"{AssistantPrefix}/threads/{threadId}/messages{AzureVersionQueryString}";
			string text2 = messageListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string MessageDelete(string threadId, string messageId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/messages/{messageId}{AzureVersionQueryString}";
		}

		public string RunCreate(string threadId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/runs{AzureVersionQueryString}";
		}

		public string RunRetrieve(string threadId, string runId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/runs/{runId}{AzureVersionQueryString}";
		}

		public string RunModify(string threadId, string runId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/runs/{runId}{AzureVersionQueryString}";
		}

		public string RunList(string threadId, PaginationRequest? runListRequest)
		{
			string text = $"{AssistantPrefix}/threads/{threadId}/runs{AzureVersionQueryString}";
			string text2 = runListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string RunSubmitToolOutputs(string threadId, string runId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/runs/{runId}/submit_tool_outputs{AzureVersionQueryString}";
		}

		public string RunCancel(string threadId, string runId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/runs/{runId}/cancel{AzureVersionQueryString}";
		}

		public string ThreadAndRunCreate()
		{
			return AssistantPrefix + "/threads/runs" + AzureVersionQueryString;
		}

		public string RunStepRetrieve(string threadId, string runId, string stepId)
		{
			return $"{AssistantPrefix}/threads/{threadId}/runs/{runId}/steps/{stepId}{AzureVersionQueryString}";
		}

		public string RunStepList(string threadId, string runId, PaginationRequest? runStepListRequest)
		{
			string text = $"{AssistantPrefix}/threads/{threadId}/runs/{runId}/steps{AzureVersionQueryString}";
			string text2 = runStepListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string VectorStoreCreate()
		{
			return AssistantPrefix + "/vector_stores" + AzureVersionQueryString;
		}

		public string VectorStoreList(PaginationRequest baseListRequest)
		{
			string text = AssistantPrefix + "/vector_stores" + AzureVersionQueryString;
			string text2 = baseListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string VectorStoreRetrieve(string vectorStoreId)
		{
			return AssistantPrefix + "/vector_stores/" + vectorStoreId + AzureVersionQueryString;
		}

		public string VectorStoreModify(string vectorStoreId)
		{
			return AssistantPrefix + "/vector_stores/" + vectorStoreId + AzureVersionQueryString;
		}

		public string VectorStoreDelete(string vectorStoreId)
		{
			return AssistantPrefix + "/vector_stores/" + vectorStoreId + AzureVersionQueryString;
		}

		public string VectorStoreFileCreate(string vectorStoreId)
		{
			return $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files{AzureVersionQueryString}";
		}

		public string VectorStoreFileRetrieve(string vectorStoreId, string fileId)
		{
			return $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files/{fileId}{AzureVersionQueryString}";
		}

		public string VectorStoreFileDelete(string vectorStoreId, string fileId)
		{
			return $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files/{fileId}{AzureVersionQueryString}";
		}

		public string VectorStoreFileList(string vectorStoreId, VectorStoreFileListRequest? baseListRequest)
		{
			string text = $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files{AzureVersionQueryString}";
			string text2 = baseListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string VectorStoreFileBatchCreate(string vectorStoreId)
		{
			return $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files/batches{AzureVersionQueryString}";
		}

		public string VectorStoreFileBatchRetrieve(string vectorStoreId, string batchId)
		{
			return $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files/batches/{batchId}{AzureVersionQueryString}";
		}

		public string VectorStoreFileBatchCancel(string vectorStoreId, string batchId)
		{
			return $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files/batches/{batchId}/cancel{AzureVersionQueryString}";
		}

		public string VectorStoreFileBatchList(string vectorStoreId, string batchId, PaginationRequest? baseListRequest)
		{
			string text = $"{AssistantPrefix}/vector_stores/{vectorStoreId}/files/batches{AzureVersionQueryString}";
			string text2 = baseListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "&" + text2;
			}
			return text;
		}

		public string BatchCreate()
		{
			return DataPlanePrefix + "/batches" + AzureVersionQueryString;
		}

		public string BatchRetrieve(string batchId)
		{
			return DataPlanePrefix + "/batches/" + batchId + AzureVersionQueryString;
		}

		public string BatchCancel(string batchId)
		{
			return $"{DataPlanePrefix}/batches/{batchId}/cancel{AzureVersionQueryString}";
		}

		public string FineTuningJobList()
		{
			return DataPlanePrefix + "/fine_tuning/jobs" + AzureVersionQueryString;
		}

		private string Files()
		{
			return DataPlanePrefix + "/files" + AzureVersionQueryString;
		}
	}
	internal interface IOpenAIEndpointProvider
	{
		string ModelRetrieve(string model);

		string CompletionCreate();

		string EditCreate();

		string ModelsList();

		string ModelsDelete(string modelId);

		string FilesList();

		string FilesUpload();

		string FileDelete(string fileId);

		string FileRetrieve(string fileId);

		string FileRetrieveContent(string fileId);

		string FineTuneCreate();

		string FineTuneList();

		string FineTuneRetrieve(string fineTuneId);

		string FineTuneCancel(string fineTuneId);

		string FineTuneListEvents(string fineTuneId);

		string FineTuneDelete(string fineTuneId);

		string FineTuningJobCreate();

		string FineTuningJobList(FineTuningJobListRequest? fineTuningJobListRequest);

		string FineTuningJobRetrieve(string fineTuningJobId);

		string FineTuningJobCancel(string fineTuningJobId);

		string FineTuningJobListEvents(string fineTuningJobId);

		string EmbeddingCreate();

		string ModerationCreate();

		string ImageCreate();

		string ImageEditCreate();

		string ImageVariationCreate();

		string ChatCompletionCreate();

		string AudioCreateTranscription();

		string AudioCreateTranslation();

		string AudioCreateSpeech();

		string BatchCreate();

		string BatchRetrieve(string batchId);

		string BatchCancel(string batchId);

		string AssistantCreate();

		string AssistantRetrieve(string assistantId);

		string AssistantModify(string assistantId);

		string AssistantDelete(string assistantId);

		string AssistantList(PaginationRequest? assistantListRequest);

		string AssistantFileCreate(string assistantId);

		string AssistantFileRetrieve(string assistantId, string fileId);

		string AssistantFileDelete(string assistantId, string fileId);

		string AssistantFileList(string assistantId, PaginationRequest? assistantFileListRequest);

		string ThreadCreate();

		string ThreadRetrieve(string threadId);

		string ThreadModify(string threadId);

		string ThreadDelete(string threadId);

		string MessageCreate(string threadId);

		string MessageRetrieve(string threadId, string messageId);

		string MessageModify(string threadId, string messageId);

		string MessageList(string threadId, MessageListRequest? messageListRequest);

		string RunCreate(string threadId);

		string RunRetrieve(string threadId, string runId);

		string RunModify(string threadId, string runId);

		string RunList(string threadId, PaginationRequest? runListRequest);

		string RunSubmitToolOutputs(string threadId, string runId);

		string RunCancel(string threadId, string runId);

		string ThreadAndRunCreate();

		string RunStepRetrieve(string threadId, string runId, string stepId);

		string RunStepList(string threadId, string runId, PaginationRequest? runStepListRequest);

		string VectorStoreCreate();

		string VectorStoreList(PaginationRequest baseListRequest);

		string VectorStoreRetrieve(string vectorStoreId);

		string VectorStoreModify(string vectorStoreId);

		string VectorStoreDelete(string vectorStoreId);

		string VectorStoreFileCreate(string vectorStoreId);

		string VectorStoreFileRetrieve(string vectorStoreId, string fileId);

		string VectorStoreFileDelete(string vectorStoreId, string fileId);

		string VectorStoreFileList(string vectorStoreId, VectorStoreFileListRequest? baseListRequest);

		string VectorStoreFileBatchCreate(string vectorStoreId);

		string VectorStoreFileBatchRetrieve(string vectorStoreId, string batchId);

		string VectorStoreFileBatchCancel(string vectorStoreId, string batchId);

		string VectorStoreFileBatchList(string vectorStoreId, string batchId, PaginationRequest? baseListRequest);

		string MessageDelete(string threadId, string messageId);
	}
	internal class OpenAIEndpointProvider : IOpenAIEndpointProvider
	{
		private readonly string _apiVersion;

		public OpenAIEndpointProvider(string apiVersion)
		{
			_apiVersion = apiVersion;
		}

		public string ModelRetrieve(string model)
		{
			return _apiVersion + "/models/" + model;
		}

		public string FileDelete(string fileId)
		{
			return _apiVersion + "/files/" + fileId;
		}

		public string CompletionCreate()
		{
			return _apiVersion + "/completions";
		}

		public string ChatCompletionCreate()
		{
			return _apiVersion + "/chat/completions";
		}

		public string AudioCreateTranscription()
		{
			return _apiVersion + "/audio/transcriptions";
		}

		public string AudioCreateTranslation()
		{
			return _apiVersion + "/audio/translations";
		}

		public string AudioCreateSpeech()
		{
			return _apiVersion + "/audio/speech";
		}

		public string BatchCreate()
		{
			return _apiVersion + "/batches";
		}

		public string BatchRetrieve(string batchId)
		{
			return _apiVersion + "/batches/" + batchId;
		}

		public string BatchCancel(string batchId)
		{
			return _apiVersion + "/batches/" + batchId + "/cancel";
		}

		public string EditCreate()
		{
			return _apiVersion + "/edits";
		}

		public string ModelsList()
		{
			return _apiVersion + "/models";
		}

		public string FilesList()
		{
			return _apiVersion + "/files";
		}

		public string FilesUpload()
		{
			return _apiVersion + "/files";
		}

		public string FileRetrieve(string fileId)
		{
			return _apiVersion + "/files/" + fileId;
		}

		public string FileRetrieveContent(string fileId)
		{
			return _apiVersion + "/files/" + fileId + "/content";
		}

		public string FineTuneCreate()
		{
			return _apiVersion + "/fine-tunes";
		}

		public string FineTuneList()
		{
			return _apiVersion + "/fine-tunes";
		}

		public string FineTuneRetrieve(string fineTuneId)
		{
			return _apiVersion + "/fine-tunes/" + fineTuneId;
		}

		public string FineTuneCancel(string fineTuneId)
		{
			return _apiVersion + "/fine-tunes/" + fineTuneId + "/cancel";
		}

		public string FineTuneListEvents(string fineTuneId)
		{
			return _apiVersion + "/fine-tunes/" + fineTuneId + "/events";
		}

		public string FineTuneDelete(string fineTuneId)
		{
			return _apiVersion + "/models/" + fineTuneId;
		}

		public string FineTuningJobCreate()
		{
			return _apiVersion + "/fine_tuning/jobs";
		}

		public string FineTuningJobList(FineTuningJobListRequest? fineTuningJobListRequest)
		{
			string text = _apiVersion + "/fine_tuning/jobs";
			if (fineTuningJobListRequest != null)
			{
				List<string> list = new List<string>();
				if (fineTuningJobListRequest.After != null)
				{
					list.Add("after=" + WebUtility.UrlEncode(fineTuningJobListRequest.After));
				}
				if (fineTuningJobListRequest.Limit.HasValue)
				{
					list.Add($"limit={fineTuningJobListRequest.Limit.Value}");
				}
				if (list.Any())
				{
					text = text + "?" + string.Join("&", list);
				}
			}
			return text;
		}

		public string FineTuningJobRetrieve(string fineTuningJobId)
		{
			return _apiVersion + "/fine_tuning/jobs/" + fineTuningJobId;
		}

		public string FineTuningJobCancel(string fineTuningJobId)
		{
			return _apiVersion + "/fine_tuning/jobs/" + fineTuningJobId + "/cancel";
		}

		public string FineTuningJobListEvents(string fineTuningJobId)
		{
			return _apiVersion + "/fine_tuning/jobs/" + fineTuningJobId + "/events";
		}

		public string ModelsDelete(string modelId)
		{
			return _apiVersion + "/models/" + modelId;
		}

		public string EmbeddingCreate()
		{
			return _apiVersion + "/embeddings";
		}

		public string ModerationCreate()
		{
			return _apiVersion + "/moderations";
		}

		public string ImageCreate()
		{
			return _apiVersion + "/images/generations";
		}

		public string ImageEditCreate()
		{
			return _apiVersion + "/images/edits";
		}

		public string ImageVariationCreate()
		{
			return _apiVersion + "/images/variations";
		}

		public string AssistantCreate()
		{
			return _apiVersion + "/assistants";
		}

		public string AssistantRetrieve(string assistantId)
		{
			return _apiVersion + "/assistants/" + assistantId;
		}

		public string AssistantModify(string assistantId)
		{
			return _apiVersion + "/assistants/" + assistantId;
		}

		public string AssistantDelete(string assistantId)
		{
			return _apiVersion + "/assistants/" + assistantId;
		}

		public string AssistantList(PaginationRequest? assistantListRequest)
		{
			string text = _apiVersion + "/assistants";
			string text2 = assistantListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}

		public string AssistantFileCreate(string assistantId)
		{
			return _apiVersion + "/assistants/" + assistantId + "/files";
		}

		public string AssistantFileRetrieve(string assistantId, string fileId)
		{
			return $"{_apiVersion}/assistants/{assistantId}/files/{fileId}";
		}

		public string AssistantFileDelete(string assistantId, string fileId)
		{
			return $"{_apiVersion}/assistants/{assistantId}/files/{fileId}";
		}

		public string AssistantFileList(string assistantId, PaginationRequest? assistantFileListRequest)
		{
			string text = _apiVersion + "/assistants/" + assistantId + "/files";
			string text2 = assistantFileListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}

		public string ThreadCreate()
		{
			return _apiVersion + "/threads";
		}

		public string ThreadRetrieve(string threadId)
		{
			return _apiVersion + "/threads/" + threadId;
		}

		public string ThreadModify(string threadId)
		{
			return _apiVersion + "/threads/" + threadId;
		}

		public string ThreadDelete(string threadId)
		{
			return _apiVersion + "/threads/" + threadId;
		}

		public string MessageCreate(string threadId)
		{
			return _apiVersion + "/threads/" + threadId + "/messages";
		}

		public string MessageRetrieve(string threadId, string messageId)
		{
			return $"{_apiVersion}/threads/{threadId}/messages/{messageId}";
		}

		public string MessageModify(string threadId, string messageId)
		{
			return $"{_apiVersion}/threads/{threadId}/messages/{messageId}";
		}

		public string MessageList(string threadId, MessageListRequest? messageListRequest)
		{
			string text = _apiVersion + "/threads/" + threadId + "/messages";
			string text2 = messageListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}

		public string MessageDelete(string threadId, string messageId)
		{
			return $"{_apiVersion}/threads/{threadId}/messages/{messageId}";
		}

		public string RunCreate(string threadId)
		{
			return _apiVersion + "/threads/" + threadId + "/runs";
		}

		public string RunRetrieve(string threadId, string runId)
		{
			return $"{_apiVersion}/threads/{threadId}/runs/{runId}";
		}

		public string RunModify(string threadId, string runId)
		{
			return $"{_apiVersion}/threads/{threadId}/runs/{runId}";
		}

		public string RunList(string threadId, PaginationRequest? runListRequest)
		{
			string text = _apiVersion + "/threads/" + threadId + "/runs";
			string text2 = runListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}

		public string RunSubmitToolOutputs(string threadId, string runId)
		{
			return $"{_apiVersion}/threads/{threadId}/runs/{runId}/submit_tool_outputs";
		}

		public string RunCancel(string threadId, string runId)
		{
			return $"{_apiVersion}/threads/{threadId}/runs/{runId}/cancel";
		}

		public string ThreadAndRunCreate()
		{
			return _apiVersion + "/threads/runs";
		}

		public string RunStepRetrieve(string threadId, string runId, string stepId)
		{
			return $"{_apiVersion}/threads/{threadId}/runs/{runId}/steps/{stepId}";
		}

		public string RunStepList(string threadId, string runId, PaginationRequest? runStepListRequest)
		{
			string text = $"{_apiVersion}/threads/{threadId}/runs/{runId}/steps";
			string text2 = runStepListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}

		public string VectorStoreCreate()
		{
			return _apiVersion + "/vector_stores";
		}

		public string VectorStoreList(PaginationRequest baseListRequest)
		{
			string text = _apiVersion + "/vector_stores";
			string text2 = baseListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}

		public string VectorStoreRetrieve(string vectorStoreId)
		{
			return _apiVersion + "/vector_stores/" + vectorStoreId;
		}

		public string VectorStoreModify(string vectorStoreId)
		{
			return _apiVersion + "/vector_stores/" + vectorStoreId;
		}

		public string VectorStoreDelete(string vectorStoreId)
		{
			return _apiVersion + "/vector_stores/" + vectorStoreId;
		}

		public string VectorStoreFileCreate(string vectorStoreId)
		{
			return _apiVersion + "/vector_stores/" + vectorStoreId + "/files";
		}

		public string VectorStoreFileRetrieve(string vectorStoreId, string fileId)
		{
			return $"{_apiVersion}/vector_stores/{vectorStoreId}/files/{fileId}";
		}

		public string VectorStoreFileDelete(string vectorStoreId, string fileId)
		{
			return $"{_apiVersion}/vector_stores/{vectorStoreId}/files/{fileId}";
		}

		public string VectorStoreFileList(string vectorStoreId, VectorStoreFileListRequest? baseListRequest)
		{
			string text = _apiVersion + "/vector_stores/" + vectorStoreId + "/files";
			string text2 = baseListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}

		public string VectorStoreFileBatchCreate(string vectorStoreId)
		{
			return _apiVersion + "/vector_stores/" + vectorStoreId + "/file_batches";
		}

		public string VectorStoreFileBatchRetrieve(string vectorStoreId, string batchId)
		{
			return $"{_apiVersion}/vector_stores/{vectorStoreId}/file_batches/{batchId}";
		}

		public string VectorStoreFileBatchCancel(string vectorStoreId, string batchId)
		{
			return $"{_apiVersion}/vector_stores/{vectorStoreId}/file_batches/{batchId}/cancel";
		}

		public string VectorStoreFileBatchList(string vectorStoreId, string batchId, PaginationRequest? baseListRequest)
		{
			string text = $"{_apiVersion}/vector_stores/{vectorStoreId}/file_batches/{batchId}/files";
			string text2 = baseListRequest?.GetQueryParameters();
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = text + "?" + text2;
			}
			return text;
		}
	}
}
namespace Betalgo.Ranul.OpenAI.Builders
{
	public class FunctionDefinitionBuilder
	{
		private const string ValidNameChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";

		private readonly FunctionDefinition _definition;

		public FunctionDefinitionBuilder(string name, string? description = null, bool? strict = null)
		{
			_definition = new FunctionDefinition
			{
				Name = name,
				Description = description,
				Strict = strict,
				Parameters = new PropertyDefinition
				{
					Properties = new Dictionary<string, PropertyDefinition>()
				}
			};
		}

		public FunctionDefinitionBuilder AddParameter(string name, PropertyDefinition value, bool required = true)
		{
			PropertyDefinition parameters = _definition.Parameters;
			parameters.Properties[name] = value;
			if (required)
			{
				PropertyDefinition propertyDefinition = parameters;
				if (propertyDefinition.Required == null)
				{
					IList<string> list = (propertyDefinition.Required = new List<string>());
				}
				parameters.Required.Add(name);
			}
			return this;
		}

		public FunctionDefinitionBuilder Validate()
		{
			ValidateName(_definition.Name);
			return this;
		}

		public FunctionDefinition Build()
		{
			return _definition;
		}

		public static void ValidateName(string functionName)
		{
			List<char> list = functionName.Where((char ch) => !"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_".Contains(ch)).ToList();
			if (functionName.Length > 64 || list.Count > 0)
			{
				string text = "The name of the function must be a-z, A-Z, 0-9, or contain underscores and dashes, with a maximum length of 64.";
				if (functionName.Length > 64)
				{
					text = "Function name is too long. " + text;
				}
				if (list.Count > 0)
				{
					text = "Function name contains invalid characters: " + string.Join(",", list) + ". " + text;
				}
				throw new ArgumentOutOfRangeException("functionName", text);
			}
		}
	}
	public class OpenAIRealtimeServiceBuilder
	{
		private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();

		private readonly OpenAIOptions _options;

		private readonly IServiceCollection? _services;

		private Action<ClientWebSocketOptions>? _configureOptions;

		private Action<ClientWebSocket>? _configureWebSocket;

		private ILogger<OpenAIRealtimeService>? _logger;

		private ServiceLifetime _serviceLifetime;

		public OpenAIRealtimeServiceBuilder(string apiKey)
			: this(new OpenAIOptions
			{
				ApiKey = apiKey
			})
		{
		}

		public OpenAIRealtimeServiceBuilder(OpenAIOptions options, ILogger<OpenAIRealtimeService>? logger = null)
		{
			_options = options;
			_logger = logger;
		}

		public OpenAIRealtimeServiceBuilder(IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Singleton)
		{
			_services = services;
			_serviceLifetime = lifetime;
		}

		public OpenAIRealtimeServiceBuilder ConfigureWebSocket(Action<ClientWebSocket> configure)
		{
			_configureWebSocket = configure;
			return this;
		}

		public OpenAIRealtimeServiceBuilder ConfigureOptions(Action<ClientWebSocketOptions> configure)
		{
			_configureOptions = configure;
			return this;
		}

		public OpenAIRealtimeServiceBuilder AddHeader(string name, string value)
		{
			_headers[name] = value;
			return this;
		}

		public OpenAIRealtimeServiceBuilder WithLogger(ILogger<OpenAIRealtimeService> logger)
		{
			_logger = logger;
			return this;
		}

		public OpenAIRealtimeServiceBuilder AsSingleton()
		{
			_serviceLifetime = ServiceLifetime.Singleton;
			return this;
		}

		public OpenAIRealtimeServiceBuilder AsScoped()
		{
			_serviceLifetime = ServiceLifetime.Scoped;
			return this;
		}

		public OpenAIRealtimeServiceBuilder AsTransient()
		{
			_serviceLifetime = ServiceLifetime.Transient;
			return this;
		}

		public IOpenAIRealtimeService? Build()
		{
			if (_services == null)
			{
				OpenAIWebSocketClient openAIWebSocketClient = new OpenAIWebSocketClient();
				ConfigureClient(openAIWebSocketClient);
				return new OpenAIRealtimeService(Options.Create(_options), _logger ?? NullLogger<OpenAIRealtimeService>.Instance, openAIWebSocketClient);
			}
			switch (_serviceLifetime)
			{
			case ServiceLifetime.Singleton:
				_services.AddSingleton((IServiceProvider sp) =>
				{
					OpenAIWebSocketClient openAIWebSocketClient2 = new OpenAIWebSocketClient();
					ConfigureClient(openAIWebSocketClient2);
					return openAIWebSocketClient2;
				});
				_services.AddSingleton<IOpenAIRealtimeService, OpenAIRealtimeService>();
				break;
			case ServiceLifetime.Scoped:
				_services.AddScoped((IServiceProvider sp) =>
				{
					OpenAIWebSocketClient openAIWebSocketClient2 = new OpenAIWebSocketClient();
					ConfigureClient(openAIWebSocketClient2);
					return openAIWebSocketClient2;
				});
				_services.AddScoped<IOpenAIRealtimeService, OpenAIRealtimeService>();
				break;
			case ServiceLifetime.Transient:
				_services.AddTransient((IServiceProvider sp) =>
				{
					OpenAIWebSocketClient openAIWebSocketClient2 = new OpenAIWebSocketClient();
					ConfigureClient(openAIWebSocketClient2);
					return openAIWebSocketClient2;
				});
				_services.AddTransient<IOpenAIRealtimeService, OpenAIRealtimeService>();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return null;
		}

		private void ConfigureClient(OpenAIWebSocketClient client)
		{
			client.ConfigureWebSocket((ClientWebSocket ws) =>
			{
				WebSocketConfigurationHelper.ConfigureWebSocket(ws, _configureOptions, _headers, _configureWebSocket);
			});
		}
	}
	public static class WebSocketConfigurationHelper
	{
		public static void ConfigureWebSocket(ClientWebSocket webSocket, Action<ClientWebSocketOptions>? configureOptions = null, IReadOnlyDictionary<string, string>? headers = null, Action<ClientWebSocket>? configureWebSocket = null)
		{
			try
			{
				webSocket.Options.AddSubProtocol("realtime");
				webSocket.Options.AddSubProtocol("openai-beta.realtime-v1");
			}
			catch (ArgumentException)
			{
			}
			configureOptions?.Invoke(webSocket.Options);
			if (headers != null)
			{
				foreach (KeyValuePair<string, string> header in headers)
				{
					try
					{
						webSocket.Options.SetRequestHeader(header.Key, header.Value);
					}
					catch (ArgumentException)
					{
					}
				}
			}
			configureWebSocket?.Invoke(webSocket);
		}
	}
}
