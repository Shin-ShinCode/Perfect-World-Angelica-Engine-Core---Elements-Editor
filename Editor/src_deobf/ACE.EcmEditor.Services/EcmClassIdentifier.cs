using System;
using System.Collections.Generic;
using System.Linq;
using ACE.EcmEditor.Models;

namespace ACE.EcmEditor.Services;

public static class EcmClassIdentifier
{
	private sealed class Class118
	{
		public string string_0;

		internal string method_0(string string_1)
		{
			return string_1 + string_0;
		}
	}

	private static readonly Dictionary<string, (string, EcmGender)> dictionary_0 = new Dictionary<string, (string, EcmGender)>
	{
		{
			Class16.smethod_0(1648994999),
			(Class16.smethod_0(1648995012), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995019),
			(Class16.smethod_0(1648995012), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648995032),
			(Class16.smethod_0(1648995053), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995059),
			(Class16.smethod_0(1648995053), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648995072),
			(Class16.smethod_0(1648995093), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995098),
			(Class16.smethod_0(1648995093), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648995119),
			(Class16.smethod_0(1648995132), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995137),
			(Class16.smethod_0(1648995132), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648995158),
			(Class16.smethod_0(1648995163), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648995179),
			(Class16.smethod_0(1648995163), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995192),
			(Class16.smethod_0(1648995203), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995228),
			(Class16.smethod_0(1648995233), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995251),
			(Class16.smethod_0(1648995233), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648995264),
			(Class16.smethod_0(1648995285), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648995290),
			(Class16.smethod_0(1648995285), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648995311),
			(Class16.smethod_0(1648995324), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648994305),
			(Class16.smethod_0(1648995324), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648994326),
			(Class16.smethod_0(1648994331), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648994344),
			(Class16.smethod_0(1648994331), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648994365),
			(Class16.smethod_0(1648994370), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648994386),
			(Class16.smethod_0(1648994370), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648994407),
			(Class16.smethod_0(1648994420), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648994439),
			(Class16.smethod_0(1648994420), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648994452),
			(Class16.smethod_0(1648994457), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648994474),
			(Class16.smethod_0(1648994495), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648994504),
			(Class16.smethod_0(1648994525), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648994542),
			(Class16.smethod_0(1648994547), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648994566),
			(Class16.smethod_0(1648994547), EcmGender.Male)
		},
		{
			Class16.smethod_0(1648994571),
			(Class16.smethod_0(1648994584), EcmGender.Female)
		},
		{
			Class16.smethod_0(1648994605),
			(Class16.smethod_0(1648994584), EcmGender.Male)
		}
	};

	public static List<string> GetAllEcmNames(EcmVersion version)
	{
		Class118 @class = new Class118();
		@class.string_0 = ((version == EcmVersion.Extended) ? Class16.smethod_0(1648994610) : Class16.smethod_0(1648906325));
		return dictionary_0.Keys.Select(@class.method_0).ToList();
	}

	public static List<string> GetAllBaseNames()
	{
		return dictionary_0.Keys.ToList();
	}

	public static (string ClassName, EcmGender Gender) Identify(string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			return (ClassName: Class16.smethod_0(1648936686), Gender: EcmGender.Unisex);
		}
		string text = fileName;
		if (text.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase))
		{
			string text2 = text;
			text = text2.Substring(0, text2.Length - 4);
		}
		if (text.EndsWith(Class16.smethod_0(1648994631), StringComparison.OrdinalIgnoreCase))
		{
			string text2 = text;
			text = text2.Substring(0, text2.Length - 2);
		}
		if (dictionary_0.TryGetValue(text, out var value))
		{
			return value;
		}
		if (fileName.Contains(Class16.smethod_0(1648994632)))
		{
			return (ClassName: Class16.smethod_0(1648936686), Gender: EcmGender.Male);
		}
		if (fileName.Contains(Class16.smethod_0(1648994641)))
		{
			return (ClassName: Class16.smethod_0(1648936686), Gender: EcmGender.Female);
		}
		return (ClassName: Class16.smethod_0(1648936686), Gender: EcmGender.Unisex);
	}

	public static bool IsKnownEcm(string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			return false;
		}
		string text = fileName;
		if (text.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase))
		{
			string text2 = text;
			text = text2.Substring(0, text2.Length - 4);
		}
		if (text.EndsWith(Class16.smethod_0(1648994631), StringComparison.OrdinalIgnoreCase))
		{
			string text2 = text;
			text = text2.Substring(0, text2.Length - 2);
		}
		return dictionary_0.ContainsKey(text);
	}

	public static EcmVersion DetectVersion(string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			return EcmVersion.Standard;
		}
		if (fileName.EndsWith(Class16.smethod_0(1648994610), StringComparison.OrdinalIgnoreCase))
		{
			return EcmVersion.Extended;
		}
		return EcmVersion.Standard;
	}

	public static bool IsMale(string fileName)
	{
		return Identify(fileName).Gender == EcmGender.Male;
	}

	public static bool IsFemale(string fileName)
	{
		return Identify(fileName).Gender == EcmGender.Female;
	}
}
