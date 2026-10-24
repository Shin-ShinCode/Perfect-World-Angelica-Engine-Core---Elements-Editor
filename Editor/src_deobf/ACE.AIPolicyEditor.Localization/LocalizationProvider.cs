using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using ACE.Classes;
using ACE.Classes.Localization;

namespace ACE.AIPolicyEditor.Localization;

public class LocalizationProvider
{
	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

	public ObservableCollection<CultureInfo> AvailableCultures => new ObservableCollection<CultureInfo>
	{
		new CultureInfo(Class16.smethod_0(1648931960)),
		new CultureInfo(Class16.smethod_0(1648931980)),
		new CultureInfo(Class16.smethod_0(1648931984)),
		new CultureInfo(Class16.smethod_0(1648932004)),
		new CultureInfo(Class16.smethod_0(1648932008)),
		new CultureInfo(Class16.smethod_0(1648932028))
	};

	public LocalizationProvider()
	{
		method_0(Class16.smethod_0(1648931959));
	}

	public void ChangeLanguage(string lang)
	{
		method_0(smethod_0(lang));
	}

	public string GetLocalizedString(string key)
	{
		if (string.IsNullOrWhiteSpace(key))
		{
			return null;
		}
		if (!dictionary_0.TryGetValue(key, out var value))
		{
			return null;
		}
		return value;
	}

	private void method_0(string string_0)
	{
		try
		{
			Dictionary<string, string> aipolicyDictionary = LocalizationBridge.GetAipolicyDictionary(string_0);
			if ((aipolicyDictionary == null || aipolicyDictionary.Count == 0) && !string_0.Equals(Class16.smethod_0(1648931959), StringComparison.OrdinalIgnoreCase))
			{
				aipolicyDictionary = LocalizationBridge.GetAipolicyDictionary(Class16.smethod_0(1648931959));
			}
			dictionary_0 = ((aipolicyDictionary != null) ? new Dictionary<string, string>(aipolicyDictionary, StringComparer.OrdinalIgnoreCase) : new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648932032));
			dictionary_0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}
	}

	private static string smethod_0(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return Class16.smethod_0(1648931959);
		}
		string text = string_0.Trim();
		if (text != null)
		{
			int length = text.Length;
			if (length != 2)
			{
				if (length == 5)
				{
					switch (text[3])
					{
					case 'C':
						break;
					case 'B':
						goto IL_006d;
					case 'R':
						goto IL_00b6;
					case 'U':
						goto IL_00d0;
					case 'V':
						goto IL_00ea;
					case 'I':
						goto IL_0104;
					case 'G':
						goto IL_011e;
					default:
						goto IL_0287;
					}
					if (text == Class16.smethod_0(1648931984))
					{
						goto IL_023c;
					}
				}
			}
			else
			{
				switch (text[0])
				{
				case 'p':
					break;
				case 'i':
					goto IL_0187;
				case 'b':
					goto IL_01ac;
				case 'c':
					goto IL_01d1;
				case 'e':
					goto IL_01fa;
				case 'z':
					goto IL_022a;
				case 'v':
					goto IL_0249;
				case 'r':
					goto IL_0268;
				default:
					goto IL_0287;
				}
				if (text == Class16.smethod_0(1648932116))
				{
					goto IL_01c1;
				}
			}
		}
		goto IL_0287;
		IL_00ea:
		if (text == Class16.smethod_0(1648932008))
		{
			goto IL_025b;
		}
		goto IL_0287;
		IL_025b:
		return Class16.smethod_0(1648932134);
		IL_01c1:
		return Class16.smethod_0(1648932004);
		IL_0268:
		if (text == Class16.smethod_0(1648932072))
		{
			goto IL_027a;
		}
		goto IL_0287;
		IL_0249:
		if (text == Class16.smethod_0(1648932134))
		{
			goto IL_025b;
		}
		goto IL_0287;
		IL_022a:
		if (text == Class16.smethod_0(1648932081))
		{
			goto IL_023c;
		}
		goto IL_0287;
		IL_01ac:
		if (text == Class16.smethod_0(1648932125))
		{
			goto IL_01c1;
		}
		goto IL_0287;
		IL_01d1:
		if (text == Class16.smethod_0(1648932090) || text == Class16.smethod_0(1648932099))
		{
			goto IL_023c;
		}
		goto IL_0287;
		IL_020c:
		return Class16.smethod_0(1648931959);
		IL_01fa:
		if (text == Class16.smethod_0(1648931959))
		{
			goto IL_020c;
		}
		goto IL_0287;
		IL_0187:
		if (text == Class16.smethod_0(1648932143))
		{
			goto IL_019c;
		}
		goto IL_0287;
		IL_0287:
		return text;
		IL_006d:
		if (text == Class16.smethod_0(1648932004))
		{
			goto IL_01c1;
		}
		goto IL_0287;
		IL_023c:
		return Class16.smethod_0(1648931984);
		IL_011e:
		if (text == Class16.smethod_0(1648932144))
		{
			goto IL_020c;
		}
		goto IL_0287;
		IL_0104:
		if (text == Class16.smethod_0(1648932028))
		{
			goto IL_019c;
		}
		goto IL_0287;
		IL_019c:
		return Class16.smethod_0(1648932143);
		IL_00b6:
		if (text == Class16.smethod_0(1648931960))
		{
			goto IL_027a;
		}
		goto IL_0287;
		IL_027a:
		return Class16.smethod_0(1648932072);
		IL_00d0:
		if (text == Class16.smethod_0(1648931980))
		{
			goto IL_020c;
		}
		goto IL_0287;
	}
}
