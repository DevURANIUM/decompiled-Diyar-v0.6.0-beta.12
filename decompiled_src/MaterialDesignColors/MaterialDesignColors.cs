using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignColors.Recommended;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: XmlnsPrefix("http://materialdesigninxaml.net/winfx/xaml/colors", "materialDesignColor")]
[assembly: XmlnsDefinition("http://materialdesigninxaml.net/winfx/xaml/colors", "MaterialDesignColors.Wpf")]
[assembly: ComVisible(false)]
[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]
[assembly: TargetFramework(".NETCoreApp,Version=v10.0", FrameworkDisplayName = ".NET 10.0")]
[assembly: AssemblyMetadata("MDIXColorsVersion", "5.3.2")]
[assembly: AssemblyCompany("Mulholland Software/James Willock")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright © 2022")]
[assembly: AssemblyDescription("Material Design in XAML Toolkit - Colors")]
[assembly: AssemblyFileVersion("5.3.2")]
[assembly: AssemblyInformationalVersion("5.3.2+7ea409750f32de9ad6647921d54e4971e2621e5e")]
[assembly: AssemblyProduct("MaterialDesignColors.Wpf")]
[assembly: AssemblyTitle("MaterialDesignColors.Wpf")]
[assembly: TargetPlatform("Windows7.0")]
[assembly: SupportedOSPlatform("Windows7.0")]
[assembly: AssemblyVersion("5.3.2.0")]
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
namespace MaterialDesignColors
{
	[DebuggerDisplay("Color: {Color}; Foreground: {ForegroundColor}")]
	public readonly struct ColorPair(Color color, Color? foregroundColor)
	{
		public Color Color => color;

		public Color? ForegroundColor => foregroundColor;

		public static implicit operator ColorPair(Color color)
		{
			return new ColorPair(color, null);
		}

		public ColorPair(Color color)
			: this(color, null)
		{
		}

		public Color GetForegroundColor()
		{
			return ForegroundColor ?? Color.ContrastingForegroundColor();
		}
	}
	public class Hue
	{
		public string Name { get; }

		public Color Color { get; }

		public Color Foreground { get; }

		public Hue(string name, Color color, Color foreground)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			Name = name;
			Color = color;
			Foreground = foreground;
		}

		public override string ToString()
		{
			return Name;
		}
	}
	public interface ISwatch
	{
		string Name { get; }

		IDictionary<MaterialDesignColor, Color> Lookup { get; }
	}
	public enum PrimaryColor
	{
		Inherit = 0,
		Red = 5,
		Pink = 19,
		Purple = 33,
		DeepPurple = 47,
		Indigo = 61,
		Blue = 75,
		LightBlue = 89,
		Cyan = 103,
		Teal = 117,
		Green = 131,
		LightGreen = 145,
		Lime = 159,
		Yellow = 173,
		Amber = 187,
		Orange = 201,
		DeepOrange = 215,
		Brown = 229,
		Grey = 239,
		BlueGrey = 249
	}
	public enum SecondaryColor
	{
		Inherit = 0,
		Red = 13,
		Pink = 27,
		Purple = 41,
		DeepPurple = 55,
		Indigo = 69,
		Blue = 83,
		LightBlue = 97,
		Cyan = 111,
		Teal = 125,
		Green = 139,
		LightGreen = 153,
		Lime = 167,
		Yellow = 181,
		Amber = 195,
		Orange = 209,
		DeepOrange = 223
	}
	public enum MaterialDesignColor
	{
		Red50 = 0,
		Red100 = 1,
		Red200 = 2,
		Red300 = 3,
		Red400 = 4,
		Red500 = 5,
		Red600 = 6,
		Red700 = 7,
		Red800 = 8,
		Red900 = 9,
		RedA100 = 10,
		RedA200 = 11,
		RedA400 = 12,
		RedA700 = 13,
		Pink50 = 14,
		Pink100 = 15,
		Pink200 = 16,
		Pink300 = 17,
		Pink400 = 18,
		Pink500 = 19,
		Pink600 = 20,
		Pink700 = 21,
		Pink800 = 22,
		Pink900 = 23,
		PinkA100 = 24,
		PinkA200 = 25,
		PinkA400 = 26,
		PinkA700 = 27,
		Purple50 = 28,
		Purple100 = 29,
		Purple200 = 30,
		Purple300 = 31,
		Purple400 = 32,
		Purple500 = 33,
		Purple600 = 34,
		Purple700 = 35,
		Purple800 = 36,
		Purple900 = 37,
		PurpleA100 = 38,
		PurpleA200 = 39,
		PurpleA400 = 40,
		PurpleA700 = 41,
		DeepPurple50 = 42,
		DeepPurple100 = 43,
		DeepPurple200 = 44,
		DeepPurple300 = 45,
		DeepPurple400 = 46,
		DeepPurple500 = 47,
		DeepPurple600 = 48,
		DeepPurple700 = 49,
		DeepPurple800 = 50,
		DeepPurple900 = 51,
		DeepPurpleA100 = 52,
		DeepPurpleA200 = 53,
		DeepPurpleA400 = 54,
		DeepPurpleA700 = 55,
		Indigo50 = 56,
		Indigo100 = 57,
		Indigo200 = 58,
		Indigo300 = 59,
		Indigo400 = 60,
		Indigo500 = 61,
		Indigo600 = 62,
		Indigo700 = 63,
		Indigo800 = 64,
		Indigo900 = 65,
		IndigoA100 = 66,
		IndigoA200 = 67,
		IndigoA400 = 68,
		IndigoA700 = 69,
		Blue50 = 70,
		Blue100 = 71,
		Blue200 = 72,
		Blue300 = 73,
		Blue400 = 74,
		Blue500 = 75,
		Blue600 = 76,
		Blue700 = 77,
		Blue800 = 78,
		Blue900 = 79,
		BlueA100 = 80,
		BlueA200 = 81,
		BlueA400 = 82,
		BlueA700 = 83,
		LightBlue50 = 84,
		LightBlue100 = 85,
		LightBlue200 = 86,
		LightBlue300 = 87,
		LightBlue400 = 88,
		LightBlue500 = 89,
		LightBlue600 = 90,
		LightBlue700 = 91,
		LightBlue800 = 92,
		LightBlue900 = 93,
		LightBlueA100 = 94,
		LightBlueA200 = 95,
		LightBlueA400 = 96,
		LightBlueA700 = 97,
		Cyan50 = 98,
		Cyan100 = 99,
		Cyan200 = 100,
		Cyan300 = 101,
		Cyan400 = 102,
		Cyan500 = 103,
		Cyan600 = 104,
		Cyan700 = 105,
		Cyan800 = 106,
		Cyan900 = 107,
		CyanA100 = 108,
		CyanA200 = 109,
		CyanA400 = 110,
		CyanA700 = 111,
		Teal50 = 112,
		Teal100 = 113,
		Teal200 = 114,
		Teal300 = 115,
		Teal400 = 116,
		Teal500 = 117,
		Teal600 = 118,
		Teal700 = 119,
		Teal800 = 120,
		Teal900 = 121,
		TealA100 = 122,
		TealA200 = 123,
		TealA400 = 124,
		TealA700 = 125,
		Green50 = 126,
		Green100 = 127,
		Green200 = 128,
		Green300 = 129,
		Green400 = 130,
		Green500 = 131,
		Green600 = 132,
		Green700 = 133,
		Green800 = 134,
		Green900 = 135,
		GreenA100 = 136,
		GreenA200 = 137,
		GreenA400 = 138,
		GreenA700 = 139,
		LightGreen50 = 140,
		LightGreen100 = 141,
		LightGreen200 = 142,
		LightGreen300 = 143,
		LightGreen400 = 144,
		LightGreen500 = 145,
		LightGreen600 = 146,
		LightGreen700 = 147,
		LightGreen800 = 148,
		LightGreen900 = 149,
		LightGreenA100 = 150,
		LightGreenA200 = 151,
		LightGreenA400 = 152,
		LightGreenA700 = 153,
		Lime50 = 154,
		Lime100 = 155,
		Lime200 = 156,
		Lime300 = 157,
		Lime400 = 158,
		Lime500 = 159,
		Lime600 = 160,
		Lime700 = 161,
		Lime800 = 162,
		Lime900 = 163,
		LimeA100 = 164,
		LimeA200 = 165,
		LimeA400 = 166,
		LimeA700 = 167,
		Yellow50 = 168,
		Yellow100 = 169,
		Yellow200 = 170,
		Yellow300 = 171,
		Yellow400 = 172,
		Yellow500 = 173,
		Yellow600 = 174,
		Yellow700 = 175,
		Yellow800 = 176,
		Yellow900 = 177,
		YellowA100 = 178,
		YellowA200 = 179,
		YellowA400 = 180,
		YellowA700 = 181,
		Amber50 = 182,
		Amber100 = 183,
		Amber200 = 184,
		Amber300 = 185,
		Amber400 = 186,
		Amber500 = 187,
		Amber600 = 188,
		Amber700 = 189,
		Amber800 = 190,
		Amber900 = 191,
		AmberA100 = 192,
		AmberA200 = 193,
		AmberA400 = 194,
		AmberA700 = 195,
		Orange50 = 196,
		Orange100 = 197,
		Orange200 = 198,
		Orange300 = 199,
		Orange400 = 200,
		Orange500 = 201,
		Orange600 = 202,
		Orange700 = 203,
		Orange800 = 204,
		Orange900 = 205,
		OrangeA100 = 206,
		OrangeA200 = 207,
		OrangeA400 = 208,
		OrangeA700 = 209,
		DeepOrange50 = 210,
		DeepOrange100 = 211,
		DeepOrange200 = 212,
		DeepOrange300 = 213,
		DeepOrange400 = 214,
		DeepOrange500 = 215,
		DeepOrange600 = 216,
		DeepOrange700 = 217,
		DeepOrange800 = 218,
		DeepOrange900 = 219,
		DeepOrangeA100 = 220,
		DeepOrangeA200 = 221,
		DeepOrangeA400 = 222,
		DeepOrangeA700 = 223,
		Brown50 = 224,
		Brown100 = 225,
		Brown200 = 226,
		Brown300 = 227,
		Brown400 = 228,
		Brown500 = 229,
		Brown600 = 230,
		Brown700 = 231,
		Brown800 = 232,
		Brown900 = 233,
		Grey50 = 234,
		Grey100 = 235,
		Grey200 = 236,
		Grey300 = 237,
		Grey400 = 238,
		Grey500 = 239,
		Grey600 = 240,
		Grey700 = 241,
		Grey800 = 242,
		Grey900 = 243,
		BlueGrey50 = 244,
		BlueGrey100 = 245,
		BlueGrey200 = 246,
		BlueGrey300 = 247,
		BlueGrey400 = 248,
		BlueGrey500 = 249,
		BlueGrey600 = 250,
		BlueGrey700 = 251,
		BlueGrey800 = 252,
		BlueGrey900 = 253,
		Red = Red500,
		Pink = Pink500,
		Purple = Purple500,
		DeepPurple = DeepPurple500,
		Indigo = Indigo500,
		Blue = Blue500,
		LightBlue = LightBlue500,
		Cyan = Cyan500,
		Teal = Teal500,
		Green = Green500,
		LightGreen = LightGreen500,
		Lime = Lime500,
		Yellow = Yellow500,
		Amber = Amber500,
		Orange = Orange500,
		DeepOrange = DeepOrange500,
		Brown = Brown500,
		Grey = Grey500,
		BlueGrey = BlueGrey500,
		RedSecondary = RedA700,
		PinkSecondary = PinkA700,
		PurpleSecondary = PurpleA700,
		DeepPurpleSecondary = DeepPurpleA700,
		IndigoSecondary = IndigoA700,
		BlueSecondary = BlueA700,
		LightBlueSecondary = LightBlueA700,
		CyanSecondary = CyanA700,
		TealSecondary = TealA700,
		GreenSecondary = GreenA700,
		LightGreenSecondary = LightGreenA700,
		LimeSecondary = LimeA700,
		YellowSecondary = YellowA700,
		AmberSecondary = AmberA700,
		OrangeSecondary = OrangeA700,
		DeepOrangeSecondary = DeepOrangeA700
	}
	[MarkupExtensionReturnType(typeof(object))]
	[Localizability(LocalizationCategory.NeverLocalize)]
	public class StaticResourceExtension : System.Windows.StaticResourceExtension
	{
		public StaticResourceExtension()
		{
		}

		public StaticResourceExtension(object resourceKey)
			: base(resourceKey)
		{
		}
	}
	public class Swatch
	{
		public string Name { get; }

		public Hue ExemplarHue { get; }

		public Hue? SecondaryExemplarHue { get; }

		public IList<Hue> PrimaryHues { get; }

		public IList<Hue> SecondaryHues { get; }

		public int ExemplarHueIndex => Math.Min(5, PrimaryHues.Count - 1);

		public int SecondaryHueIndex => Math.Min(2, SecondaryHues.Count - 1);

		public Swatch(string name, IEnumerable<Hue> primaryHues, IEnumerable<Hue> secondaryHues)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (primaryHues == null)
			{
				throw new ArgumentNullException("primaryHues");
			}
			if (secondaryHues == null)
			{
				throw new ArgumentNullException("secondaryHues");
			}
			List<Hue> list = primaryHues.ToList();
			if (list.Count == 0)
			{
				throw new ArgumentException("Non primary hues provided.", "primaryHues");
			}
			Name = name;
			PrimaryHues = list;
			List<Hue> list2 = (List<Hue>)(SecondaryHues = secondaryHues.ToList());
			ExemplarHue = list[ExemplarHueIndex];
			if (SecondaryHueIndex >= 0 && SecondaryHueIndex < list2.Count)
			{
				SecondaryExemplarHue = list2[SecondaryHueIndex];
			}
		}

		public override string ToString()
		{
			return Name;
		}
	}
	public class SwatchesProvider
	{
		private static readonly object _syncLock = new object();

		public IEnumerable<Swatch> Swatches { get; }

		public SwatchesProvider(Assembly assembly)
		{
			ResourceSet? resourceSet = new ResourceManager(assembly.GetName().Name + ".g", assembly).GetResourceSet(CultureInfo.CurrentUICulture, createIfNotExists: true, tryParents: true);
			List<DictionaryEntry> list = ((resourceSet != null) ? resourceSet.OfType<DictionaryEntry>().ToList() : null);
			string assemblyName = assembly.GetName().Name;
			Regex regex = new Regex("^themes\\/materialdesigncolor\\.(?<name>[a-z]+)\\.(?<type>primary|secondary)\\.baml$");
			Swatches = ((list != null) ? (from x in list
				select new
				{
					key = x.Key.ToString(),
					match = regex.Match(x.Key.ToString() ?? "")
				} into x
				where x.match.Success && x.match.Groups["name"].Value != "black"
				group x by x.match.Groups["name"].Value into x
				select CreateSwatch(x.Key, Read(assemblyName, x.SingleOrDefault(y => y.match.Groups["type"].Value == "primary")?.key), Read(assemblyName, x.SingleOrDefault(y => y.match.Groups["type"].Value == "secondary")?.key))).ToList() : null) ?? new List<Swatch>();
		}

		public SwatchesProvider()
			: this(Assembly.GetExecutingAssembly())
		{
		}

		private static Swatch CreateSwatch(string name, ResourceDictionary? primaryDictionary, ResourceDictionary? secondaryDictionary)
		{
			return new Swatch(name, GetHues(primaryDictionary), GetHues(secondaryDictionary));
			static Hue GetHue(ResourceDictionary dictionary, DictionaryEntry entry)
			{
				if (!(entry.Value is Color color))
				{
					throw new InvalidOperationException($"Entry {entry.Key} was not of type {"Color"}");
				}
				string foregroundKey = entry.Key?.ToString() + "Foreground";
				if (!(dictionary.OfType<DictionaryEntry>().Single((DictionaryEntry de) => string.Equals(de.Key.ToString(), foregroundKey, StringComparison.Ordinal)).Value is Color foreground))
				{
					throw new InvalidOperationException("Entry " + foregroundKey + " was not of type Color");
				}
				return new Hue(entry.Key?.ToString() ?? "", color, foreground);
			}
			static List<Hue> GetHues(ResourceDictionary? resourceDictionary)
			{
				List<Hue> list = new List<Hue>();
				if (resourceDictionary != null)
				{
					foreach (DictionaryEntry item in from de in resourceDictionary.OfType<DictionaryEntry>()
						orderby de.Key
						where !(de.Key.ToString() ?? "").EndsWith("Foreground", StringComparison.Ordinal)
						select de)
					{
						list.Add(GetHue(resourceDictionary, item));
					}
				}
				return list;
			}
		}

		private static ResourceDictionary? Read(string? assemblyName, string? path)
		{
			if (assemblyName == null || path == null)
			{
				return null;
			}
			lock (_syncLock)
			{
				return (ResourceDictionary)Application.LoadComponent(new Uri("/" + assemblyName + ";component/" + path.Replace(".baml", ".xaml"), UriKind.RelativeOrAbsolute));
			}
		}
	}
	public static class SwatchHelper
	{
		public static IEnumerable<ISwatch> Swatches { get; } = new <>z__ReadOnlyArray<ISwatch>(new ISwatch[19]
		{
			new RedSwatch(),
			new PinkSwatch(),
			new PurpleSwatch(),
			new DeepPurpleSwatch(),
			new IndigoSwatch(),
			new BlueSwatch(),
			new LightBlueSwatch(),
			new CyanSwatch(),
			new TealSwatch(),
			new GreenSwatch(),
			new LightGreenSwatch(),
			new LimeSwatch(),
			new YellowSwatch(),
			new AmberSwatch(),
			new OrangeSwatch(),
			new DeepOrangeSwatch(),
			new BrownSwatch(),
			new GreySwatch(),
			new BlueGreySwatch()
		});

		public static IDictionary<MaterialDesignColor, Color> Lookup { get; } = Swatches.SelectMany((ISwatch o) => o.Lookup).ToDictionary((KeyValuePair<MaterialDesignColor, Color> o) => o.Key, (KeyValuePair<MaterialDesignColor, Color> o) => o.Value);
	}
}
namespace MaterialDesignColors.Recommended
{
	public class AmberSwatch : ISwatch
	{
		public static Color Amber50 { get; } = (Color)ColorConverter.ConvertFromString("#FFF8E1");

		public static Color Amber100 { get; } = (Color)ColorConverter.ConvertFromString("#FFECB3");

		public static Color Amber200 { get; } = (Color)ColorConverter.ConvertFromString("#FFE082");

		public static Color Amber300 { get; } = (Color)ColorConverter.ConvertFromString("#FFD54F");

		public static Color Amber400 { get; } = (Color)ColorConverter.ConvertFromString("#FFCA28");

		public static Color Amber500 { get; } = (Color)ColorConverter.ConvertFromString("#FFC107");

		public static Color Amber600 { get; } = (Color)ColorConverter.ConvertFromString("#FFB300");

		public static Color Amber700 { get; } = (Color)ColorConverter.ConvertFromString("#FFA000");

		public static Color Amber800 { get; } = (Color)ColorConverter.ConvertFromString("#FF8F00");

		public static Color Amber900 { get; } = (Color)ColorConverter.ConvertFromString("#FF6F00");

		public static Color AmberA100 { get; } = (Color)ColorConverter.ConvertFromString("#FFE57F");

		public static Color AmberA200 { get; } = (Color)ColorConverter.ConvertFromString("#FFD740");

		public static Color AmberA400 { get; } = (Color)ColorConverter.ConvertFromString("#FFC400");

		public static Color AmberA700 { get; } = (Color)ColorConverter.ConvertFromString("#FFAB00");

		public string Name { get; } = "Amber";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Amber50,
				Amber50
			},
			{
				MaterialDesignColor.Amber100,
				Amber100
			},
			{
				MaterialDesignColor.Amber200,
				Amber200
			},
			{
				MaterialDesignColor.Amber300,
				Amber300
			},
			{
				MaterialDesignColor.Amber400,
				Amber400
			},
			{
				MaterialDesignColor.Amber500,
				Amber500
			},
			{
				MaterialDesignColor.Amber600,
				Amber600
			},
			{
				MaterialDesignColor.Amber700,
				Amber700
			},
			{
				MaterialDesignColor.Amber800,
				Amber800
			},
			{
				MaterialDesignColor.Amber900,
				Amber900
			},
			{
				MaterialDesignColor.AmberA100,
				AmberA100
			},
			{
				MaterialDesignColor.AmberA200,
				AmberA200
			},
			{
				MaterialDesignColor.AmberA400,
				AmberA400
			},
			{
				MaterialDesignColor.AmberA700,
				AmberA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class BlueGreySwatch : ISwatch
	{
		public static Color BlueGrey50 { get; } = (Color)ColorConverter.ConvertFromString("#ECEFF1");

		public static Color BlueGrey100 { get; } = (Color)ColorConverter.ConvertFromString("#CFD8DC");

		public static Color BlueGrey200 { get; } = (Color)ColorConverter.ConvertFromString("#B0BEC5");

		public static Color BlueGrey300 { get; } = (Color)ColorConverter.ConvertFromString("#90A4AE");

		public static Color BlueGrey400 { get; } = (Color)ColorConverter.ConvertFromString("#78909C");

		public static Color BlueGrey500 { get; } = (Color)ColorConverter.ConvertFromString("#607D8B");

		public static Color BlueGrey600 { get; } = (Color)ColorConverter.ConvertFromString("#546E7A");

		public static Color BlueGrey700 { get; } = (Color)ColorConverter.ConvertFromString("#455A64");

		public static Color BlueGrey800 { get; } = (Color)ColorConverter.ConvertFromString("#37474F");

		public static Color BlueGrey900 { get; } = (Color)ColorConverter.ConvertFromString("#263238");

		public string Name { get; } = "BlueGrey";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.BlueGrey50,
				BlueGrey50
			},
			{
				MaterialDesignColor.BlueGrey100,
				BlueGrey100
			},
			{
				MaterialDesignColor.BlueGrey200,
				BlueGrey200
			},
			{
				MaterialDesignColor.BlueGrey300,
				BlueGrey300
			},
			{
				MaterialDesignColor.BlueGrey400,
				BlueGrey400
			},
			{
				MaterialDesignColor.BlueGrey500,
				BlueGrey500
			},
			{
				MaterialDesignColor.BlueGrey600,
				BlueGrey600
			},
			{
				MaterialDesignColor.BlueGrey700,
				BlueGrey700
			},
			{
				MaterialDesignColor.BlueGrey800,
				BlueGrey800
			},
			{
				MaterialDesignColor.BlueGrey900,
				BlueGrey900
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class BlueSwatch : ISwatch
	{
		public static Color Blue50 { get; } = (Color)ColorConverter.ConvertFromString("#E3F2FD");

		public static Color Blue100 { get; } = (Color)ColorConverter.ConvertFromString("#BBDEFB");

		public static Color Blue200 { get; } = (Color)ColorConverter.ConvertFromString("#90CAF9");

		public static Color Blue300 { get; } = (Color)ColorConverter.ConvertFromString("#64B5F6");

		public static Color Blue400 { get; } = (Color)ColorConverter.ConvertFromString("#42A5F5");

		public static Color Blue500 { get; } = (Color)ColorConverter.ConvertFromString("#2196F3");

		public static Color Blue600 { get; } = (Color)ColorConverter.ConvertFromString("#1E88E5");

		public static Color Blue700 { get; } = (Color)ColorConverter.ConvertFromString("#1976D2");

		public static Color Blue800 { get; } = (Color)ColorConverter.ConvertFromString("#1565C0");

		public static Color Blue900 { get; } = (Color)ColorConverter.ConvertFromString("#0D47A1");

		public static Color BlueA100 { get; } = (Color)ColorConverter.ConvertFromString("#82B1FF");

		public static Color BlueA200 { get; } = (Color)ColorConverter.ConvertFromString("#448AFF");

		public static Color BlueA400 { get; } = (Color)ColorConverter.ConvertFromString("#2979FF");

		public static Color BlueA700 { get; } = (Color)ColorConverter.ConvertFromString("#2962FF");

		public string Name { get; } = "Blue";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Blue50,
				Blue50
			},
			{
				MaterialDesignColor.Blue100,
				Blue100
			},
			{
				MaterialDesignColor.Blue200,
				Blue200
			},
			{
				MaterialDesignColor.Blue300,
				Blue300
			},
			{
				MaterialDesignColor.Blue400,
				Blue400
			},
			{
				MaterialDesignColor.Blue500,
				Blue500
			},
			{
				MaterialDesignColor.Blue600,
				Blue600
			},
			{
				MaterialDesignColor.Blue700,
				Blue700
			},
			{
				MaterialDesignColor.Blue800,
				Blue800
			},
			{
				MaterialDesignColor.Blue900,
				Blue900
			},
			{
				MaterialDesignColor.BlueA100,
				BlueA100
			},
			{
				MaterialDesignColor.BlueA200,
				BlueA200
			},
			{
				MaterialDesignColor.BlueA400,
				BlueA400
			},
			{
				MaterialDesignColor.BlueA700,
				BlueA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class BrownSwatch : ISwatch
	{
		public static Color Brown50 { get; } = (Color)ColorConverter.ConvertFromString("#EFEBE9");

		public static Color Brown100 { get; } = (Color)ColorConverter.ConvertFromString("#D7CCC8");

		public static Color Brown200 { get; } = (Color)ColorConverter.ConvertFromString("#BCAAA4");

		public static Color Brown300 { get; } = (Color)ColorConverter.ConvertFromString("#A1887F");

		public static Color Brown400 { get; } = (Color)ColorConverter.ConvertFromString("#8D6E63");

		public static Color Brown500 { get; } = (Color)ColorConverter.ConvertFromString("#795548");

		public static Color Brown600 { get; } = (Color)ColorConverter.ConvertFromString("#6D4C41");

		public static Color Brown700 { get; } = (Color)ColorConverter.ConvertFromString("#5D4037");

		public static Color Brown800 { get; } = (Color)ColorConverter.ConvertFromString("#4E342E");

		public static Color Brown900 { get; } = (Color)ColorConverter.ConvertFromString("#3E2723");

		public string Name { get; } = "Brown";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Brown50,
				Brown50
			},
			{
				MaterialDesignColor.Brown100,
				Brown100
			},
			{
				MaterialDesignColor.Brown200,
				Brown200
			},
			{
				MaterialDesignColor.Brown300,
				Brown300
			},
			{
				MaterialDesignColor.Brown400,
				Brown400
			},
			{
				MaterialDesignColor.Brown500,
				Brown500
			},
			{
				MaterialDesignColor.Brown600,
				Brown600
			},
			{
				MaterialDesignColor.Brown700,
				Brown700
			},
			{
				MaterialDesignColor.Brown800,
				Brown800
			},
			{
				MaterialDesignColor.Brown900,
				Brown900
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class CyanSwatch : ISwatch
	{
		public static Color Cyan50 { get; } = (Color)ColorConverter.ConvertFromString("#E0F7FA");

		public static Color Cyan100 { get; } = (Color)ColorConverter.ConvertFromString("#B2EBF2");

		public static Color Cyan200 { get; } = (Color)ColorConverter.ConvertFromString("#80DEEA");

		public static Color Cyan300 { get; } = (Color)ColorConverter.ConvertFromString("#4DD0E1");

		public static Color Cyan400 { get; } = (Color)ColorConverter.ConvertFromString("#26C6DA");

		public static Color Cyan500 { get; } = (Color)ColorConverter.ConvertFromString("#00BCD4");

		public static Color Cyan600 { get; } = (Color)ColorConverter.ConvertFromString("#00ACC1");

		public static Color Cyan700 { get; } = (Color)ColorConverter.ConvertFromString("#0097A7");

		public static Color Cyan800 { get; } = (Color)ColorConverter.ConvertFromString("#00838F");

		public static Color Cyan900 { get; } = (Color)ColorConverter.ConvertFromString("#006064");

		public static Color CyanA100 { get; } = (Color)ColorConverter.ConvertFromString("#84FFFF");

		public static Color CyanA200 { get; } = (Color)ColorConverter.ConvertFromString("#18FFFF");

		public static Color CyanA400 { get; } = (Color)ColorConverter.ConvertFromString("#00E5FF");

		public static Color CyanA700 { get; } = (Color)ColorConverter.ConvertFromString("#00B8D4");

		public string Name { get; } = "Cyan";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Cyan50,
				Cyan50
			},
			{
				MaterialDesignColor.Cyan100,
				Cyan100
			},
			{
				MaterialDesignColor.Cyan200,
				Cyan200
			},
			{
				MaterialDesignColor.Cyan300,
				Cyan300
			},
			{
				MaterialDesignColor.Cyan400,
				Cyan400
			},
			{
				MaterialDesignColor.Cyan500,
				Cyan500
			},
			{
				MaterialDesignColor.Cyan600,
				Cyan600
			},
			{
				MaterialDesignColor.Cyan700,
				Cyan700
			},
			{
				MaterialDesignColor.Cyan800,
				Cyan800
			},
			{
				MaterialDesignColor.Cyan900,
				Cyan900
			},
			{
				MaterialDesignColor.CyanA100,
				CyanA100
			},
			{
				MaterialDesignColor.CyanA200,
				CyanA200
			},
			{
				MaterialDesignColor.CyanA400,
				CyanA400
			},
			{
				MaterialDesignColor.CyanA700,
				CyanA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class DeepOrangeSwatch : ISwatch
	{
		public static Color DeepOrange50 { get; } = (Color)ColorConverter.ConvertFromString("#FBE9E7");

		public static Color DeepOrange100 { get; } = (Color)ColorConverter.ConvertFromString("#FFCCBC");

		public static Color DeepOrange200 { get; } = (Color)ColorConverter.ConvertFromString("#FFAB91");

		public static Color DeepOrange300 { get; } = (Color)ColorConverter.ConvertFromString("#FF8A65");

		public static Color DeepOrange400 { get; } = (Color)ColorConverter.ConvertFromString("#FF7043");

		public static Color DeepOrange500 { get; } = (Color)ColorConverter.ConvertFromString("#FF5722");

		public static Color DeepOrange600 { get; } = (Color)ColorConverter.ConvertFromString("#F4511E");

		public static Color DeepOrange700 { get; } = (Color)ColorConverter.ConvertFromString("#E64A19");

		public static Color DeepOrange800 { get; } = (Color)ColorConverter.ConvertFromString("#D84315");

		public static Color DeepOrange900 { get; } = (Color)ColorConverter.ConvertFromString("#BF360C");

		public static Color DeepOrangeA100 { get; } = (Color)ColorConverter.ConvertFromString("#FF9E80");

		public static Color DeepOrangeA200 { get; } = (Color)ColorConverter.ConvertFromString("#FF6E40");

		public static Color DeepOrangeA400 { get; } = (Color)ColorConverter.ConvertFromString("#FF3D00");

		public static Color DeepOrangeA700 { get; } = (Color)ColorConverter.ConvertFromString("#DD2C00");

		public string Name { get; } = "DeepOrange";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.DeepOrange50,
				DeepOrange50
			},
			{
				MaterialDesignColor.DeepOrange100,
				DeepOrange100
			},
			{
				MaterialDesignColor.DeepOrange200,
				DeepOrange200
			},
			{
				MaterialDesignColor.DeepOrange300,
				DeepOrange300
			},
			{
				MaterialDesignColor.DeepOrange400,
				DeepOrange400
			},
			{
				MaterialDesignColor.DeepOrange500,
				DeepOrange500
			},
			{
				MaterialDesignColor.DeepOrange600,
				DeepOrange600
			},
			{
				MaterialDesignColor.DeepOrange700,
				DeepOrange700
			},
			{
				MaterialDesignColor.DeepOrange800,
				DeepOrange800
			},
			{
				MaterialDesignColor.DeepOrange900,
				DeepOrange900
			},
			{
				MaterialDesignColor.DeepOrangeA100,
				DeepOrangeA100
			},
			{
				MaterialDesignColor.DeepOrangeA200,
				DeepOrangeA200
			},
			{
				MaterialDesignColor.DeepOrangeA400,
				DeepOrangeA400
			},
			{
				MaterialDesignColor.DeepOrangeA700,
				DeepOrangeA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class DeepPurpleSwatch : ISwatch
	{
		public static Color DeepPurple50 { get; } = (Color)ColorConverter.ConvertFromString("#EDE7F6");

		public static Color DeepPurple100 { get; } = (Color)ColorConverter.ConvertFromString("#D1C4E9");

		public static Color DeepPurple200 { get; } = (Color)ColorConverter.ConvertFromString("#B39DDB");

		public static Color DeepPurple300 { get; } = (Color)ColorConverter.ConvertFromString("#9575CD");

		public static Color DeepPurple400 { get; } = (Color)ColorConverter.ConvertFromString("#7E57C2");

		public static Color DeepPurple500 { get; } = (Color)ColorConverter.ConvertFromString("#673AB7");

		public static Color DeepPurple600 { get; } = (Color)ColorConverter.ConvertFromString("#5E35B1");

		public static Color DeepPurple700 { get; } = (Color)ColorConverter.ConvertFromString("#512DA8");

		public static Color DeepPurple800 { get; } = (Color)ColorConverter.ConvertFromString("#4527A0");

		public static Color DeepPurple900 { get; } = (Color)ColorConverter.ConvertFromString("#311B92");

		public static Color DeepPurpleA100 { get; } = (Color)ColorConverter.ConvertFromString("#B388FF");

		public static Color DeepPurpleA200 { get; } = (Color)ColorConverter.ConvertFromString("#7C4DFF");

		public static Color DeepPurpleA400 { get; } = (Color)ColorConverter.ConvertFromString("#651FFF");

		public static Color DeepPurpleA700 { get; } = (Color)ColorConverter.ConvertFromString("#6200EA");

		public string Name { get; } = "DeepPurple";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.DeepPurple50,
				DeepPurple50
			},
			{
				MaterialDesignColor.DeepPurple100,
				DeepPurple100
			},
			{
				MaterialDesignColor.DeepPurple200,
				DeepPurple200
			},
			{
				MaterialDesignColor.DeepPurple300,
				DeepPurple300
			},
			{
				MaterialDesignColor.DeepPurple400,
				DeepPurple400
			},
			{
				MaterialDesignColor.DeepPurple500,
				DeepPurple500
			},
			{
				MaterialDesignColor.DeepPurple600,
				DeepPurple600
			},
			{
				MaterialDesignColor.DeepPurple700,
				DeepPurple700
			},
			{
				MaterialDesignColor.DeepPurple800,
				DeepPurple800
			},
			{
				MaterialDesignColor.DeepPurple900,
				DeepPurple900
			},
			{
				MaterialDesignColor.DeepPurpleA100,
				DeepPurpleA100
			},
			{
				MaterialDesignColor.DeepPurpleA200,
				DeepPurpleA200
			},
			{
				MaterialDesignColor.DeepPurpleA400,
				DeepPurpleA400
			},
			{
				MaterialDesignColor.DeepPurpleA700,
				DeepPurpleA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class GreenSwatch : ISwatch
	{
		public static Color Green50 { get; } = (Color)ColorConverter.ConvertFromString("#E8F5E9");

		public static Color Green100 { get; } = (Color)ColorConverter.ConvertFromString("#C8E6C9");

		public static Color Green200 { get; } = (Color)ColorConverter.ConvertFromString("#A5D6A7");

		public static Color Green300 { get; } = (Color)ColorConverter.ConvertFromString("#81C784");

		public static Color Green400 { get; } = (Color)ColorConverter.ConvertFromString("#66BB6A");

		public static Color Green500 { get; } = (Color)ColorConverter.ConvertFromString("#4CAF50");

		public static Color Green600 { get; } = (Color)ColorConverter.ConvertFromString("#43A047");

		public static Color Green700 { get; } = (Color)ColorConverter.ConvertFromString("#388E3C");

		public static Color Green800 { get; } = (Color)ColorConverter.ConvertFromString("#2E7D32");

		public static Color Green900 { get; } = (Color)ColorConverter.ConvertFromString("#1B5E20");

		public static Color GreenA100 { get; } = (Color)ColorConverter.ConvertFromString("#B9F6CA");

		public static Color GreenA200 { get; } = (Color)ColorConverter.ConvertFromString("#69F0AE");

		public static Color GreenA400 { get; } = (Color)ColorConverter.ConvertFromString("#00E676");

		public static Color GreenA700 { get; } = (Color)ColorConverter.ConvertFromString("#00C853");

		public string Name { get; } = "Green";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Green50,
				Green50
			},
			{
				MaterialDesignColor.Green100,
				Green100
			},
			{
				MaterialDesignColor.Green200,
				Green200
			},
			{
				MaterialDesignColor.Green300,
				Green300
			},
			{
				MaterialDesignColor.Green400,
				Green400
			},
			{
				MaterialDesignColor.Green500,
				Green500
			},
			{
				MaterialDesignColor.Green600,
				Green600
			},
			{
				MaterialDesignColor.Green700,
				Green700
			},
			{
				MaterialDesignColor.Green800,
				Green800
			},
			{
				MaterialDesignColor.Green900,
				Green900
			},
			{
				MaterialDesignColor.GreenA100,
				GreenA100
			},
			{
				MaterialDesignColor.GreenA200,
				GreenA200
			},
			{
				MaterialDesignColor.GreenA400,
				GreenA400
			},
			{
				MaterialDesignColor.GreenA700,
				GreenA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class GreySwatch : ISwatch
	{
		public static Color Grey50 { get; } = (Color)ColorConverter.ConvertFromString("#FAFAFA");

		public static Color Grey100 { get; } = (Color)ColorConverter.ConvertFromString("#F5F5F5");

		public static Color Grey200 { get; } = (Color)ColorConverter.ConvertFromString("#EEEEEE");

		public static Color Grey300 { get; } = (Color)ColorConverter.ConvertFromString("#E0E0E0");

		public static Color Grey400 { get; } = (Color)ColorConverter.ConvertFromString("#BDBDBD");

		public static Color Grey500 { get; } = (Color)ColorConverter.ConvertFromString("#9E9E9E");

		public static Color Grey600 { get; } = (Color)ColorConverter.ConvertFromString("#757575");

		public static Color Grey700 { get; } = (Color)ColorConverter.ConvertFromString("#616161");

		public static Color Grey800 { get; } = (Color)ColorConverter.ConvertFromString("#424242");

		public static Color Grey900 { get; } = (Color)ColorConverter.ConvertFromString("#212121");

		public string Name { get; } = "Grey";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Grey50,
				Grey50
			},
			{
				MaterialDesignColor.Grey100,
				Grey100
			},
			{
				MaterialDesignColor.Grey200,
				Grey200
			},
			{
				MaterialDesignColor.Grey300,
				Grey300
			},
			{
				MaterialDesignColor.Grey400,
				Grey400
			},
			{
				MaterialDesignColor.Grey500,
				Grey500
			},
			{
				MaterialDesignColor.Grey600,
				Grey600
			},
			{
				MaterialDesignColor.Grey700,
				Grey700
			},
			{
				MaterialDesignColor.Grey800,
				Grey800
			},
			{
				MaterialDesignColor.Grey900,
				Grey900
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class IndigoSwatch : ISwatch
	{
		public static Color Indigo50 { get; } = (Color)ColorConverter.ConvertFromString("#E8EAF6");

		public static Color Indigo100 { get; } = (Color)ColorConverter.ConvertFromString("#C5CAE9");

		public static Color Indigo200 { get; } = (Color)ColorConverter.ConvertFromString("#9FA8DA");

		public static Color Indigo300 { get; } = (Color)ColorConverter.ConvertFromString("#7986CB");

		public static Color Indigo400 { get; } = (Color)ColorConverter.ConvertFromString("#5C6BC0");

		public static Color Indigo500 { get; } = (Color)ColorConverter.ConvertFromString("#3F51B5");

		public static Color Indigo600 { get; } = (Color)ColorConverter.ConvertFromString("#3949AB");

		public static Color Indigo700 { get; } = (Color)ColorConverter.ConvertFromString("#303F9F");

		public static Color Indigo800 { get; } = (Color)ColorConverter.ConvertFromString("#283593");

		public static Color Indigo900 { get; } = (Color)ColorConverter.ConvertFromString("#1A237E");

		public static Color IndigoA100 { get; } = (Color)ColorConverter.ConvertFromString("#8C9EFF");

		public static Color IndigoA200 { get; } = (Color)ColorConverter.ConvertFromString("#536DFE");

		public static Color IndigoA400 { get; } = (Color)ColorConverter.ConvertFromString("#3D5AFE");

		public static Color IndigoA700 { get; } = (Color)ColorConverter.ConvertFromString("#304FFE");

		public string Name { get; } = "Indigo";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Indigo50,
				Indigo50
			},
			{
				MaterialDesignColor.Indigo100,
				Indigo100
			},
			{
				MaterialDesignColor.Indigo200,
				Indigo200
			},
			{
				MaterialDesignColor.Indigo300,
				Indigo300
			},
			{
				MaterialDesignColor.Indigo400,
				Indigo400
			},
			{
				MaterialDesignColor.Indigo500,
				Indigo500
			},
			{
				MaterialDesignColor.Indigo600,
				Indigo600
			},
			{
				MaterialDesignColor.Indigo700,
				Indigo700
			},
			{
				MaterialDesignColor.Indigo800,
				Indigo800
			},
			{
				MaterialDesignColor.Indigo900,
				Indigo900
			},
			{
				MaterialDesignColor.IndigoA100,
				IndigoA100
			},
			{
				MaterialDesignColor.IndigoA200,
				IndigoA200
			},
			{
				MaterialDesignColor.IndigoA400,
				IndigoA400
			},
			{
				MaterialDesignColor.IndigoA700,
				IndigoA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class LightBlueSwatch : ISwatch
	{
		public static Color LightBlue50 { get; } = (Color)ColorConverter.ConvertFromString("#E1F5FE");

		public static Color LightBlue100 { get; } = (Color)ColorConverter.ConvertFromString("#B3E5FC");

		public static Color LightBlue200 { get; } = (Color)ColorConverter.ConvertFromString("#81D4FA");

		public static Color LightBlue300 { get; } = (Color)ColorConverter.ConvertFromString("#4FC3F7");

		public static Color LightBlue400 { get; } = (Color)ColorConverter.ConvertFromString("#29B6F6");

		public static Color LightBlue500 { get; } = (Color)ColorConverter.ConvertFromString("#03A9F4");

		public static Color LightBlue600 { get; } = (Color)ColorConverter.ConvertFromString("#039BE5");

		public static Color LightBlue700 { get; } = (Color)ColorConverter.ConvertFromString("#0288D1");

		public static Color LightBlue800 { get; } = (Color)ColorConverter.ConvertFromString("#0277BD");

		public static Color LightBlue900 { get; } = (Color)ColorConverter.ConvertFromString("#01579B");

		public static Color LightBlueA100 { get; } = (Color)ColorConverter.ConvertFromString("#80D8FF");

		public static Color LightBlueA200 { get; } = (Color)ColorConverter.ConvertFromString("#40C4FF");

		public static Color LightBlueA400 { get; } = (Color)ColorConverter.ConvertFromString("#00B0FF");

		public static Color LightBlueA700 { get; } = (Color)ColorConverter.ConvertFromString("#0091EA");

		public string Name { get; } = "LightBlue";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.LightBlue50,
				LightBlue50
			},
			{
				MaterialDesignColor.LightBlue100,
				LightBlue100
			},
			{
				MaterialDesignColor.LightBlue200,
				LightBlue200
			},
			{
				MaterialDesignColor.LightBlue300,
				LightBlue300
			},
			{
				MaterialDesignColor.LightBlue400,
				LightBlue400
			},
			{
				MaterialDesignColor.LightBlue500,
				LightBlue500
			},
			{
				MaterialDesignColor.LightBlue600,
				LightBlue600
			},
			{
				MaterialDesignColor.LightBlue700,
				LightBlue700
			},
			{
				MaterialDesignColor.LightBlue800,
				LightBlue800
			},
			{
				MaterialDesignColor.LightBlue900,
				LightBlue900
			},
			{
				MaterialDesignColor.LightBlueA100,
				LightBlueA100
			},
			{
				MaterialDesignColor.LightBlueA200,
				LightBlueA200
			},
			{
				MaterialDesignColor.LightBlueA400,
				LightBlueA400
			},
			{
				MaterialDesignColor.LightBlueA700,
				LightBlueA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class LightGreenSwatch : ISwatch
	{
		public static Color LightGreen50 { get; } = (Color)ColorConverter.ConvertFromString("#F1F8E9");

		public static Color LightGreen100 { get; } = (Color)ColorConverter.ConvertFromString("#DCEDC8");

		public static Color LightGreen200 { get; } = (Color)ColorConverter.ConvertFromString("#C5E1A5");

		public static Color LightGreen300 { get; } = (Color)ColorConverter.ConvertFromString("#AED581");

		public static Color LightGreen400 { get; } = (Color)ColorConverter.ConvertFromString("#9CCC65");

		public static Color LightGreen500 { get; } = (Color)ColorConverter.ConvertFromString("#8BC34A");

		public static Color LightGreen600 { get; } = (Color)ColorConverter.ConvertFromString("#7CB342");

		public static Color LightGreen700 { get; } = (Color)ColorConverter.ConvertFromString("#689F38");

		public static Color LightGreen800 { get; } = (Color)ColorConverter.ConvertFromString("#558B2F");

		public static Color LightGreen900 { get; } = (Color)ColorConverter.ConvertFromString("#33691E");

		public static Color LightGreenA100 { get; } = (Color)ColorConverter.ConvertFromString("#CCFF90");

		public static Color LightGreenA200 { get; } = (Color)ColorConverter.ConvertFromString("#B2FF59");

		public static Color LightGreenA400 { get; } = (Color)ColorConverter.ConvertFromString("#76FF03");

		public static Color LightGreenA700 { get; } = (Color)ColorConverter.ConvertFromString("#64DD17");

		public string Name { get; } = "LightGreen";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.LightGreen50,
				LightGreen50
			},
			{
				MaterialDesignColor.LightGreen100,
				LightGreen100
			},
			{
				MaterialDesignColor.LightGreen200,
				LightGreen200
			},
			{
				MaterialDesignColor.LightGreen300,
				LightGreen300
			},
			{
				MaterialDesignColor.LightGreen400,
				LightGreen400
			},
			{
				MaterialDesignColor.LightGreen500,
				LightGreen500
			},
			{
				MaterialDesignColor.LightGreen600,
				LightGreen600
			},
			{
				MaterialDesignColor.LightGreen700,
				LightGreen700
			},
			{
				MaterialDesignColor.LightGreen800,
				LightGreen800
			},
			{
				MaterialDesignColor.LightGreen900,
				LightGreen900
			},
			{
				MaterialDesignColor.LightGreenA100,
				LightGreenA100
			},
			{
				MaterialDesignColor.LightGreenA200,
				LightGreenA200
			},
			{
				MaterialDesignColor.LightGreenA400,
				LightGreenA400
			},
			{
				MaterialDesignColor.LightGreenA700,
				LightGreenA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class LimeSwatch : ISwatch
	{
		public static Color Lime50 { get; } = (Color)ColorConverter.ConvertFromString("#F9FBE7");

		public static Color Lime100 { get; } = (Color)ColorConverter.ConvertFromString("#F0F4C3");

		public static Color Lime200 { get; } = (Color)ColorConverter.ConvertFromString("#E6EE9C");

		public static Color Lime300 { get; } = (Color)ColorConverter.ConvertFromString("#DCE775");

		public static Color Lime400 { get; } = (Color)ColorConverter.ConvertFromString("#D4E157");

		public static Color Lime500 { get; } = (Color)ColorConverter.ConvertFromString("#CDDC39");

		public static Color Lime600 { get; } = (Color)ColorConverter.ConvertFromString("#C0CA33");

		public static Color Lime700 { get; } = (Color)ColorConverter.ConvertFromString("#AFB42B");

		public static Color Lime800 { get; } = (Color)ColorConverter.ConvertFromString("#9E9D24");

		public static Color Lime900 { get; } = (Color)ColorConverter.ConvertFromString("#827717");

		public static Color LimeA100 { get; } = (Color)ColorConverter.ConvertFromString("#F4FF81");

		public static Color LimeA200 { get; } = (Color)ColorConverter.ConvertFromString("#EEFF41");

		public static Color LimeA400 { get; } = (Color)ColorConverter.ConvertFromString("#C6FF00");

		public static Color LimeA700 { get; } = (Color)ColorConverter.ConvertFromString("#AEEA00");

		public string Name { get; } = "Lime";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Lime50,
				Lime50
			},
			{
				MaterialDesignColor.Lime100,
				Lime100
			},
			{
				MaterialDesignColor.Lime200,
				Lime200
			},
			{
				MaterialDesignColor.Lime300,
				Lime300
			},
			{
				MaterialDesignColor.Lime400,
				Lime400
			},
			{
				MaterialDesignColor.Lime500,
				Lime500
			},
			{
				MaterialDesignColor.Lime600,
				Lime600
			},
			{
				MaterialDesignColor.Lime700,
				Lime700
			},
			{
				MaterialDesignColor.Lime800,
				Lime800
			},
			{
				MaterialDesignColor.Lime900,
				Lime900
			},
			{
				MaterialDesignColor.LimeA100,
				LimeA100
			},
			{
				MaterialDesignColor.LimeA200,
				LimeA200
			},
			{
				MaterialDesignColor.LimeA400,
				LimeA400
			},
			{
				MaterialDesignColor.LimeA700,
				LimeA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class OrangeSwatch : ISwatch
	{
		public static Color Orange50 { get; } = (Color)ColorConverter.ConvertFromString("#FFF3E0");

		public static Color Orange100 { get; } = (Color)ColorConverter.ConvertFromString("#FFE0B2");

		public static Color Orange200 { get; } = (Color)ColorConverter.ConvertFromString("#FFCC80");

		public static Color Orange300 { get; } = (Color)ColorConverter.ConvertFromString("#FFB74D");

		public static Color Orange400 { get; } = (Color)ColorConverter.ConvertFromString("#FFA726");

		public static Color Orange500 { get; } = (Color)ColorConverter.ConvertFromString("#FF9800");

		public static Color Orange600 { get; } = (Color)ColorConverter.ConvertFromString("#FB8C00");

		public static Color Orange700 { get; } = (Color)ColorConverter.ConvertFromString("#F57C00");

		public static Color Orange800 { get; } = (Color)ColorConverter.ConvertFromString("#EF6C00");

		public static Color Orange900 { get; } = (Color)ColorConverter.ConvertFromString("#E65100");

		public static Color OrangeA100 { get; } = (Color)ColorConverter.ConvertFromString("#FFD180");

		public static Color OrangeA200 { get; } = (Color)ColorConverter.ConvertFromString("#FFAB40");

		public static Color OrangeA400 { get; } = (Color)ColorConverter.ConvertFromString("#FF9100");

		public static Color OrangeA700 { get; } = (Color)ColorConverter.ConvertFromString("#FF6D00");

		public string Name { get; } = "Orange";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Orange50,
				Orange50
			},
			{
				MaterialDesignColor.Orange100,
				Orange100
			},
			{
				MaterialDesignColor.Orange200,
				Orange200
			},
			{
				MaterialDesignColor.Orange300,
				Orange300
			},
			{
				MaterialDesignColor.Orange400,
				Orange400
			},
			{
				MaterialDesignColor.Orange500,
				Orange500
			},
			{
				MaterialDesignColor.Orange600,
				Orange600
			},
			{
				MaterialDesignColor.Orange700,
				Orange700
			},
			{
				MaterialDesignColor.Orange800,
				Orange800
			},
			{
				MaterialDesignColor.Orange900,
				Orange900
			},
			{
				MaterialDesignColor.OrangeA100,
				OrangeA100
			},
			{
				MaterialDesignColor.OrangeA200,
				OrangeA200
			},
			{
				MaterialDesignColor.OrangeA400,
				OrangeA400
			},
			{
				MaterialDesignColor.OrangeA700,
				OrangeA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class PinkSwatch : ISwatch
	{
		public static Color Pink50 { get; } = (Color)ColorConverter.ConvertFromString("#FCE4EC");

		public static Color Pink100 { get; } = (Color)ColorConverter.ConvertFromString("#F8BBD0");

		public static Color Pink200 { get; } = (Color)ColorConverter.ConvertFromString("#F48FB1");

		public static Color Pink300 { get; } = (Color)ColorConverter.ConvertFromString("#F06292");

		public static Color Pink400 { get; } = (Color)ColorConverter.ConvertFromString("#EC407A");

		public static Color Pink500 { get; } = (Color)ColorConverter.ConvertFromString("#E91E63");

		public static Color Pink600 { get; } = (Color)ColorConverter.ConvertFromString("#D81B60");

		public static Color Pink700 { get; } = (Color)ColorConverter.ConvertFromString("#C2185B");

		public static Color Pink800 { get; } = (Color)ColorConverter.ConvertFromString("#AD1457");

		public static Color Pink900 { get; } = (Color)ColorConverter.ConvertFromString("#880E4F");

		public static Color PinkA100 { get; } = (Color)ColorConverter.ConvertFromString("#FF80AB");

		public static Color PinkA200 { get; } = (Color)ColorConverter.ConvertFromString("#FF4081");

		public static Color PinkA400 { get; } = (Color)ColorConverter.ConvertFromString("#F50057");

		public static Color PinkA700 { get; } = (Color)ColorConverter.ConvertFromString("#C51162");

		public string Name { get; } = "Pink";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Pink50,
				Pink50
			},
			{
				MaterialDesignColor.Pink100,
				Pink100
			},
			{
				MaterialDesignColor.Pink200,
				Pink200
			},
			{
				MaterialDesignColor.Pink300,
				Pink300
			},
			{
				MaterialDesignColor.Pink400,
				Pink400
			},
			{
				MaterialDesignColor.Pink500,
				Pink500
			},
			{
				MaterialDesignColor.Pink600,
				Pink600
			},
			{
				MaterialDesignColor.Pink700,
				Pink700
			},
			{
				MaterialDesignColor.Pink800,
				Pink800
			},
			{
				MaterialDesignColor.Pink900,
				Pink900
			},
			{
				MaterialDesignColor.PinkA100,
				PinkA100
			},
			{
				MaterialDesignColor.PinkA200,
				PinkA200
			},
			{
				MaterialDesignColor.PinkA400,
				PinkA400
			},
			{
				MaterialDesignColor.PinkA700,
				PinkA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class PurpleSwatch : ISwatch
	{
		public static Color Purple50 { get; } = (Color)ColorConverter.ConvertFromString("#F3E5F5");

		public static Color Purple100 { get; } = (Color)ColorConverter.ConvertFromString("#E1BEE7");

		public static Color Purple200 { get; } = (Color)ColorConverter.ConvertFromString("#CE93D8");

		public static Color Purple300 { get; } = (Color)ColorConverter.ConvertFromString("#BA68C8");

		public static Color Purple400 { get; } = (Color)ColorConverter.ConvertFromString("#AB47BC");

		public static Color Purple500 { get; } = (Color)ColorConverter.ConvertFromString("#9C27B0");

		public static Color Purple600 { get; } = (Color)ColorConverter.ConvertFromString("#8E24AA");

		public static Color Purple700 { get; } = (Color)ColorConverter.ConvertFromString("#7B1FA2");

		public static Color Purple800 { get; } = (Color)ColorConverter.ConvertFromString("#6A1B9A");

		public static Color Purple900 { get; } = (Color)ColorConverter.ConvertFromString("#4A148C");

		public static Color PurpleA100 { get; } = (Color)ColorConverter.ConvertFromString("#EA80FC");

		public static Color PurpleA200 { get; } = (Color)ColorConverter.ConvertFromString("#E040FB");

		public static Color PurpleA400 { get; } = (Color)ColorConverter.ConvertFromString("#D500F9");

		public static Color PurpleA700 { get; } = (Color)ColorConverter.ConvertFromString("#AA00FF");

		public string Name { get; } = "Purple";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Purple50,
				Purple50
			},
			{
				MaterialDesignColor.Purple100,
				Purple100
			},
			{
				MaterialDesignColor.Purple200,
				Purple200
			},
			{
				MaterialDesignColor.Purple300,
				Purple300
			},
			{
				MaterialDesignColor.Purple400,
				Purple400
			},
			{
				MaterialDesignColor.Purple500,
				Purple500
			},
			{
				MaterialDesignColor.Purple600,
				Purple600
			},
			{
				MaterialDesignColor.Purple700,
				Purple700
			},
			{
				MaterialDesignColor.Purple800,
				Purple800
			},
			{
				MaterialDesignColor.Purple900,
				Purple900
			},
			{
				MaterialDesignColor.PurpleA100,
				PurpleA100
			},
			{
				MaterialDesignColor.PurpleA200,
				PurpleA200
			},
			{
				MaterialDesignColor.PurpleA400,
				PurpleA400
			},
			{
				MaterialDesignColor.PurpleA700,
				PurpleA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class RedSwatch : ISwatch
	{
		public static Color Red50 { get; } = (Color)ColorConverter.ConvertFromString("#FFEBEE");

		public static Color Red100 { get; } = (Color)ColorConverter.ConvertFromString("#FFCDD2");

		public static Color Red200 { get; } = (Color)ColorConverter.ConvertFromString("#EF9A9A");

		public static Color Red300 { get; } = (Color)ColorConverter.ConvertFromString("#E57373");

		public static Color Red400 { get; } = (Color)ColorConverter.ConvertFromString("#EF5350");

		public static Color Red500 { get; } = (Color)ColorConverter.ConvertFromString("#F44336");

		public static Color Red600 { get; } = (Color)ColorConverter.ConvertFromString("#E53935");

		public static Color Red700 { get; } = (Color)ColorConverter.ConvertFromString("#D32F2F");

		public static Color Red800 { get; } = (Color)ColorConverter.ConvertFromString("#C62828");

		public static Color Red900 { get; } = (Color)ColorConverter.ConvertFromString("#B71C1C");

		public static Color RedA100 { get; } = (Color)ColorConverter.ConvertFromString("#FF8A80");

		public static Color RedA200 { get; } = (Color)ColorConverter.ConvertFromString("#FF5252");

		public static Color RedA400 { get; } = (Color)ColorConverter.ConvertFromString("#FF1744");

		public static Color RedA700 { get; } = (Color)ColorConverter.ConvertFromString("#D50000");

		public string Name { get; } = "Red";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Red50,
				Red50
			},
			{
				MaterialDesignColor.Red100,
				Red100
			},
			{
				MaterialDesignColor.Red200,
				Red200
			},
			{
				MaterialDesignColor.Red300,
				Red300
			},
			{
				MaterialDesignColor.Red400,
				Red400
			},
			{
				MaterialDesignColor.Red500,
				Red500
			},
			{
				MaterialDesignColor.Red600,
				Red600
			},
			{
				MaterialDesignColor.Red700,
				Red700
			},
			{
				MaterialDesignColor.Red800,
				Red800
			},
			{
				MaterialDesignColor.Red900,
				Red900
			},
			{
				MaterialDesignColor.RedA100,
				RedA100
			},
			{
				MaterialDesignColor.RedA200,
				RedA200
			},
			{
				MaterialDesignColor.RedA400,
				RedA400
			},
			{
				MaterialDesignColor.RedA700,
				RedA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class TealSwatch : ISwatch
	{
		public static Color Teal50 { get; } = (Color)ColorConverter.ConvertFromString("#E0F2F1");

		public static Color Teal100 { get; } = (Color)ColorConverter.ConvertFromString("#B2DFDB");

		public static Color Teal200 { get; } = (Color)ColorConverter.ConvertFromString("#80CBC4");

		public static Color Teal300 { get; } = (Color)ColorConverter.ConvertFromString("#4DB6AC");

		public static Color Teal400 { get; } = (Color)ColorConverter.ConvertFromString("#26A69A");

		public static Color Teal500 { get; } = (Color)ColorConverter.ConvertFromString("#009688");

		public static Color Teal600 { get; } = (Color)ColorConverter.ConvertFromString("#00897B");

		public static Color Teal700 { get; } = (Color)ColorConverter.ConvertFromString("#00796B");

		public static Color Teal800 { get; } = (Color)ColorConverter.ConvertFromString("#00695C");

		public static Color Teal900 { get; } = (Color)ColorConverter.ConvertFromString("#004D40");

		public static Color TealA100 { get; } = (Color)ColorConverter.ConvertFromString("#A7FFEB");

		public static Color TealA200 { get; } = (Color)ColorConverter.ConvertFromString("#64FFDA");

		public static Color TealA400 { get; } = (Color)ColorConverter.ConvertFromString("#1DE9B6");

		public static Color TealA700 { get; } = (Color)ColorConverter.ConvertFromString("#00BFA5");

		public string Name { get; } = "Teal";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Teal50,
				Teal50
			},
			{
				MaterialDesignColor.Teal100,
				Teal100
			},
			{
				MaterialDesignColor.Teal200,
				Teal200
			},
			{
				MaterialDesignColor.Teal300,
				Teal300
			},
			{
				MaterialDesignColor.Teal400,
				Teal400
			},
			{
				MaterialDesignColor.Teal500,
				Teal500
			},
			{
				MaterialDesignColor.Teal600,
				Teal600
			},
			{
				MaterialDesignColor.Teal700,
				Teal700
			},
			{
				MaterialDesignColor.Teal800,
				Teal800
			},
			{
				MaterialDesignColor.Teal900,
				Teal900
			},
			{
				MaterialDesignColor.TealA100,
				TealA100
			},
			{
				MaterialDesignColor.TealA200,
				TealA200
			},
			{
				MaterialDesignColor.TealA400,
				TealA400
			},
			{
				MaterialDesignColor.TealA700,
				TealA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
	public class YellowSwatch : ISwatch
	{
		public static Color Yellow50 { get; } = (Color)ColorConverter.ConvertFromString("#FFFDE7");

		public static Color Yellow100 { get; } = (Color)ColorConverter.ConvertFromString("#FFF9C4");

		public static Color Yellow200 { get; } = (Color)ColorConverter.ConvertFromString("#FFF59D");

		public static Color Yellow300 { get; } = (Color)ColorConverter.ConvertFromString("#FFF176");

		public static Color Yellow400 { get; } = (Color)ColorConverter.ConvertFromString("#FFEE58");

		public static Color Yellow500 { get; } = (Color)ColorConverter.ConvertFromString("#FFEB3B");

		public static Color Yellow600 { get; } = (Color)ColorConverter.ConvertFromString("#FDD835");

		public static Color Yellow700 { get; } = (Color)ColorConverter.ConvertFromString("#FBC02D");

		public static Color Yellow800 { get; } = (Color)ColorConverter.ConvertFromString("#F9A825");

		public static Color Yellow900 { get; } = (Color)ColorConverter.ConvertFromString("#F57F17");

		public static Color YellowA100 { get; } = (Color)ColorConverter.ConvertFromString("#FFFF8D");

		public static Color YellowA200 { get; } = (Color)ColorConverter.ConvertFromString("#FFFF00");

		public static Color YellowA400 { get; } = (Color)ColorConverter.ConvertFromString("#FFEA00");

		public static Color YellowA700 { get; } = (Color)ColorConverter.ConvertFromString("#FFD600");

		public string Name { get; } = "Yellow";

		public IDictionary<MaterialDesignColor, Color> Lookup { get; } = new Dictionary<MaterialDesignColor, Color>
		{
			{
				MaterialDesignColor.Yellow50,
				Yellow50
			},
			{
				MaterialDesignColor.Yellow100,
				Yellow100
			},
			{
				MaterialDesignColor.Yellow200,
				Yellow200
			},
			{
				MaterialDesignColor.Yellow300,
				Yellow300
			},
			{
				MaterialDesignColor.Yellow400,
				Yellow400
			},
			{
				MaterialDesignColor.Yellow500,
				Yellow500
			},
			{
				MaterialDesignColor.Yellow600,
				Yellow600
			},
			{
				MaterialDesignColor.Yellow700,
				Yellow700
			},
			{
				MaterialDesignColor.Yellow800,
				Yellow800
			},
			{
				MaterialDesignColor.Yellow900,
				Yellow900
			},
			{
				MaterialDesignColor.YellowA100,
				YellowA100
			},
			{
				MaterialDesignColor.YellowA200,
				YellowA200
			},
			{
				MaterialDesignColor.YellowA400,
				YellowA400
			},
			{
				MaterialDesignColor.YellowA700,
				YellowA700
			}
		};

		public IEnumerable<Color> Hues => Lookup.Values;
	}
}
namespace MaterialDesignColors.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("MaterialDesignColors.Properties.Resources", typeof(Resources).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal Resources()
		{
		}
	}
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.2.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => defaultInstance;
	}
}
namespace MaterialDesignColors.ColorManipulation
{
	public static class ColorAssist
	{
		public static float RelativeLuminance(this Color color)
		{
			return 0.2126f * Calc((float)(int)color.R / 255f) + 0.7152f * Calc((float)(int)color.G / 255f) + 0.0722f * Calc((float)(int)color.B / 255f);
			static float Calc(float colorValue)
			{
				if (!(colorValue <= 0.03928f))
				{
					return (float)Math.Pow((colorValue + 0.055f) / 1.055f, 2.4);
				}
				return colorValue / 12.92f;
			}
		}

		public static float ContrastRatio(this Color color, Color color2)
		{
			float num = color.RelativeLuminance();
			float num2 = color2.RelativeLuminance();
			if (num2 > num)
			{
				float num3 = num;
				num = num2;
				num2 = num3;
			}
			return (num + 0.05f) / (num2 + 0.05f);
		}

		public static Color EnsureContrastRatio(this Color foreground, Color background, float targetRatio, float tolerance = 0.1f)
		{
			double offset;
			return foreground.EnsureContrastRatio(background, targetRatio, out offset, tolerance);
		}

		public static Color EnsureContrastRatio(this Color foreground, Color background, float targetRatio, out double offset, float tolerance = 0.1f)
		{
			offset = 0.0;
			float num = foreground.ContrastRatio(background);
			if (num > targetRatio)
			{
				return foreground;
			}
			float num2 = background.ContrastRatio(Colors.White);
			bool flag = background.ContrastRatio(Colors.Black) > num2;
			Color color = foreground;
			double? num3 = null;
			while ((num < targetRatio - tolerance || num > targetRatio + tolerance) && color != Colors.White && color != Colors.Black)
			{
				if ((double)(num - targetRatio) < 0.0)
				{
					if (flag)
					{
						if (num3 < 0.0)
						{
							num3 /= -2.0;
						}
						else
						{
							double valueOrDefault = num3.GetValueOrDefault();
							if (!num3.HasValue)
							{
								valueOrDefault = 1.0;
								num3 = valueOrDefault;
							}
						}
					}
					else if (num3 > 0.0)
					{
						num3 /= -2.0;
					}
					else
					{
						double valueOrDefault = num3.GetValueOrDefault();
						if (!num3.HasValue)
						{
							valueOrDefault = -1.0;
							num3 = valueOrDefault;
						}
					}
				}
				else if (flag)
				{
					if (num3 > 0.0)
					{
						num3 /= -2.0;
					}
					else
					{
						double valueOrDefault = num3.GetValueOrDefault();
						if (!num3.HasValue)
						{
							valueOrDefault = -1.0;
							num3 = valueOrDefault;
						}
					}
				}
				else if (num3 < 0.0)
				{
					num3 /= -2.0;
				}
				else
				{
					double valueOrDefault = num3.GetValueOrDefault();
					if (!num3.HasValue)
					{
						valueOrDefault = 1.0;
						num3 = valueOrDefault;
					}
				}
				offset += num3.Value;
				color = foreground.ShiftLightness(offset);
				num = color.ContrastRatio(background);
			}
			return color;
		}

		public static Color ContrastingForegroundColor(this Color color)
		{
			if (!color.IsLightColor())
			{
				return Colors.White;
			}
			return Colors.Black;
		}

		public static bool IsLightColor(this Color color)
		{
			double num = rgb_srgb((int)color.R);
			double num2 = rgb_srgb((int)color.G);
			double num3 = rgb_srgb((int)color.B);
			return 0.2126 * num + 0.7152 * num2 + 0.0722 * num3 > 0.179;
			static double rgb_srgb(double d)
			{
				d /= 255.0;
				if (!(d > 0.03928))
				{
					return d / 12.92;
				}
				return Math.Pow((d + 0.055) / 1.055, 2.4);
			}
		}

		public static bool IsDarkColor(this Color color)
		{
			return !color.IsLightColor();
		}

		public static Color ShiftLightness(this Color color, double amount = 1.0)
		{
			Lab lab = color.ToLab();
			return new Lab(lab.L - 18.0 * amount, lab.A, lab.B).ToColor();
		}

		public static Color ShiftLightness(this Color color, int amount = 1)
		{
			Lab lab = color.ToLab();
			return new Lab(lab.L - 18.0 * (double)amount, lab.A, lab.B).ToColor();
		}

		public static Color Darken(this Color color, int amount = 1)
		{
			return color.ShiftLightness(amount);
		}

		public static Color Lighten(this Color color, int amount = 1)
		{
			return color.ShiftLightness(-amount);
		}
	}
	public record struct Hsb(double Hue, double Saturation, double Brightness);
	public static class HsbExtensions
	{
		public static Color ToColor(this Hsb hsv)
		{
			double num = hsv.Hue;
			double saturation = hsv.Saturation;
			double brightness = hsv.Brightness;
			brightness *= 255.0;
			if (saturation.IsCloseTo(0.0))
			{
				return Color.FromRgb((byte)brightness, (byte)brightness, (byte)brightness);
			}
			if (num.IsCloseTo(360.0))
			{
				num = 0.0;
			}
			while (num > 360.0)
			{
				num -= 360.0;
			}
			for (; num < 0.0; num += 360.0)
			{
			}
			num /= 60.0;
			int num2 = (int)Math.Floor(num);
			double num3 = num - (double)num2;
			double num4 = brightness * (1.0 - saturation);
			double num5 = brightness * (1.0 - saturation * num3);
			double num6 = brightness * (1.0 - saturation * (1.0 - num3));
			return num2 switch
			{
				0 => Color.FromRgb((byte)brightness, (byte)num6, (byte)num4), 
				1 => Color.FromRgb((byte)num5, (byte)brightness, (byte)num4), 
				2 => Color.FromRgb((byte)num4, (byte)brightness, (byte)num6), 
				3 => Color.FromRgb((byte)num4, (byte)num5, (byte)brightness), 
				4 => Color.FromRgb((byte)num6, (byte)num4, (byte)brightness), 
				5 => Color.FromRgb((byte)brightness, (byte)num4, (byte)num5), 
				_ => throw new InvalidOperationException("Invalid HSB values"), 
			};
		}

		public static Hsb ToHsb(this Color color)
		{
			double num = (int)color.R;
			double num2 = (int)color.G;
			double num3 = (int)color.B;
			num /= 255.0;
			num2 /= 255.0;
			num3 /= 255.0;
			double[] source = new double[3] { num, num2, num3 };
			double num4 = source.Max();
			double num5 = source.Min();
			double brightness = num4;
			double num6 = num4;
			double num7 = num4 - num5;
			double saturation = (num4.IsCloseTo(0.0) ? 0.0 : (num7 / num4));
			if (num4.IsCloseTo(num5))
			{
				num6 = 0.0;
			}
			else
			{
				if (num4.IsCloseTo(num))
				{
					num6 = (num2 - num3) / num7 + (double)((num2 < num3) ? 6 : 0);
				}
				else if (num4.IsCloseTo(num2))
				{
					num6 = (num3 - num) / num7 + 2.0;
				}
				else if (num4.IsCloseTo(num3))
				{
					num6 = (num - num2) / num7 + 4.0;
				}
				num6 *= 60.0;
			}
			return new Hsb(num6, saturation, brightness);
		}

		private static bool IsCloseTo(this double value, double target, double tolerance = double.Epsilon)
		{
			return Math.Abs(value - target) < tolerance;
		}
	}
	internal record struct Hsl(double H, double S, double L);
	internal static class HslExtensions
	{
		public static Color ToColor(this Hsl hsl)
		{
			double num = hsl.H * (1.0 / 360.0);
			double num2 = hsl.S * 0.01;
			double num3 = hsl.L * 0.01;
			double a;
			double a2;
			double a3;
			if (num2 == 0.0)
			{
				a = num3 * 255.0;
				a2 = num3 * 255.0;
				a3 = num3 * 255.0;
			}
			else
			{
				double num4 = ((!(num3 < 0.5)) ? (num3 + num2 - num2 * num3) : (num3 * (1.0 + num2)));
				double v = 2.0 * num3 - num4;
				a = 255.0 * hsv_rbg(v, num4, num + 1.0 / 3.0);
				a2 = 255.0 * hsv_rbg(v, num4, num);
				a3 = 255.0 * hsv_rbg(v, num4, num - 1.0 / 3.0);
			}
			return Color.FromRgb((byte)Math.Round(a), (byte)Math.Round(a2), (byte)Math.Round(a3));
			static double hsv_rbg(double num5, double num6, double vH)
			{
				if (vH < 0.0)
				{
					vH++;
				}
				if (vH > 1.0)
				{
					vH--;
				}
				if (6.0 * vH < 1.0)
				{
					return num5 + (num6 - num5) * 6.0 * vH;
				}
				if (2.0 * vH < 1.0)
				{
					return num6;
				}
				if (3.0 * vH < 2.0)
				{
					return num5 + (num6 - num5) * (2.0 / 3.0 - vH) * 6.0;
				}
				return num5;
			}
		}
	}
	internal record struct Lab(double L, double A, double B);
	internal class LabConstants
	{
		public const double Kn = 18.0;

		public const double WhitePointX = 0.95047;

		public const double WhitePointY = 1.0;

		public const double WhitePointZ = 1.08883;

		public static readonly double eCubedRoot = Math.Pow(0.008856451679035631, 1.0 / 3.0);

		public const double k = 903.2962962962963;

		public const double e = 0.008856451679035631;
	}
	internal static class LabExtensions
	{
		public static Lab ToLab(this Color c)
		{
			return c.ToXyz().ToLab();
		}

		public static Lab ToLab(this Xyz xyz)
		{
			double num = xyz_lab(xyz.X / 0.95047);
			double num2 = xyz_lab(xyz.Y / 1.0);
			double num3 = xyz_lab(xyz.Z / 1.08883);
			double l = 116.0 * num2 - 16.0;
			double a = 500.0 * (num - num2);
			double b = 200.0 * (num2 - num3);
			return new Lab(l, a, b);
			static double xyz_lab(double v)
			{
				if (v > 0.008856451679035631)
				{
					return Math.Pow(v, 1.0 / 3.0);
				}
				return (v * 903.2962962962963 + 16.0) / 116.0;
			}
		}

		public static Color ToColor(this Lab lab)
		{
			return lab.ToXyz().ToColor();
		}
	}
	internal record struct Xyz(double X, double Y, double Z);
	internal static class XyzExtensions
	{
		public static Color ToColor(this Xyz xyz)
		{
			double d = xyz_rgb(3.2404542 * xyz.X - 1.5371385 * xyz.Y - 0.4985314 * xyz.Z);
			double d2 = xyz_rgb(-0.969266 * xyz.X + 1.8760108 * xyz.Y + 0.041556 * xyz.Z);
			return Color.FromRgb(b: clip(xyz_rgb(0.0556434 * xyz.X - 0.2040259 * xyz.Y + 1.0572252 * xyz.Z)), r: clip(d), g: clip(d2));
			static byte clip(double num)
			{
				if (num < 0.0)
				{
					return 0;
				}
				if (num > 255.0)
				{
					return byte.MaxValue;
				}
				return (byte)Math.Round(num);
			}
			static double xyz_rgb(double num)
			{
				if (num > 0.0031308)
				{
					return 255.0 * (1.055 * Math.Pow(num, 5.0 / 12.0) - 0.055);
				}
				return 255.0 * (12.92 * num);
			}
		}

		public static Xyz ToXyz(this Color c)
		{
			double num = rgb_xyz((int)c.R);
			double num2 = rgb_xyz((int)c.G);
			double num3 = rgb_xyz((int)c.B);
			double x = 0.4124564 * num + 0.3575761 * num2 + 0.1804375 * num3;
			double y = 0.2126729 * num + 0.7151522 * num2 + 0.072175 * num3;
			double z = 0.0193339 * num + 0.119192 * num2 + 0.9503041 * num3;
			return new Xyz(x, y, z);
			static double rgb_xyz(double v)
			{
				v /= 255.0;
				if (v > 0.04045)
				{
					return Math.Pow((v + 0.055) / 1.055, 2.4);
				}
				return v / 12.92;
			}
		}

		public static Xyz ToXyz(this Lab lab)
		{
			double num = (lab.L + 16.0) / 116.0;
			double d = (double.IsNaN(lab.A) ? num : (num + lab.A / 500.0));
			double d2 = (double.IsNaN(lab.B) ? num : (num - lab.B / 200.0));
			num = 1.0 * lab_xyz(num);
			d = 0.95047 * lab_xyz(d);
			d2 = 1.08883 * lab_xyz(d2);
			return new Xyz(d, num, d2);
			static double lab_xyz(double num2)
			{
				if (num2 > LabConstants.eCubedRoot)
				{
					return num2 * num2 * num2;
				}
				return (116.0 * num2 - 16.0) / 903.2962962962963;
			}
		}
	}
}
