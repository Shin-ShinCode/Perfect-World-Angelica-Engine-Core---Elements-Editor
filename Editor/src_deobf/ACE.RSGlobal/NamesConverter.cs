using System.Text.RegularExpressions;

namespace ACE.RSGlobal;

public class NamesConverter
{
	private static Regex regex_0 = new Regex(Class16.smethod_0(1649167164), RegexOptions.Compiled);

	private static Regex regex_1 = new Regex(Class16.smethod_0(1649167176), RegexOptions.Compiled);

	private static Regex regex_2 = new Regex(Class16.smethod_0(1649167200), RegexOptions.Compiled);

	public static string RemoveIndices(string field)
	{
		field = Regex.Replace(field, Class16.smethod_0(1648902914), string.Empty);
		field = Regex.Replace(field, Class16.smethod_0(1649167218), string.Empty);
		field = field.Replace(Class16.smethod_0(1648922929), Class16.smethod_0(1648942211));
		field = field.Replace(Class16.smethod_0(1649043292), Class16.smethod_0(1648942211));
		return field.Trim();
	}

	public static string GetFieldFriendlyName(string field)
	{
		if (field != null)
		{
			switch (field.Length)
			{
			case 7:
				if (!(field == Class16.smethod_0(1648956099)))
				{
					break;
				}
				goto IL_0124;
			case 9:
				if (field == Class16.smethod_0(1648960592))
				{
					return Class16.smethod_0(1648960225);
				}
				break;
			case 11:
				switch (field[0])
				{
				case 'i':
					if (field == Class16.smethod_0(1648960564))
					{
						return Class16.smethod_0(1648960211);
					}
					break;
				case 'e':
					if (field == Class16.smethod_0(1649167250))
					{
						return Class16.smethod_0(1649166369);
					}
					break;
				case 'd':
					if (field == Class16.smethod_0(1649167232))
					{
						return Class16.smethod_0(1649167353);
					}
					break;
				}
				break;
			case 13:
			{
				char c = field[0];
				if (c != 'd')
				{
					if (c != 'e')
					{
						if (c != 'i' || !(field == Class16.smethod_0(1648960536)))
						{
							break;
						}
						goto IL_0124;
					}
					if (field == Class16.smethod_0(1649167288))
					{
						return Class16.smethod_0(1649166397);
					}
					break;
				}
				if (field == Class16.smethod_0(1649167276))
				{
					return Class16.smethod_0(1649166357);
				}
				break;
			}
			case 2:
				{
					switch (field[0])
					{
					case 'h':
						if (field == Class16.smethod_0(1649167334))
						{
							return Class16.smethod_0(1649166427);
						}
						break;
					case 'd':
						if (field == Class16.smethod_0(1649167316))
						{
							return Class16.smethod_0(1649166409);
						}
						break;
					case 'v':
						if (field == Class16.smethod_0(1649167344))
						{
							return Class16.smethod_0(1649166453);
						}
						break;
					case 's':
						if (field == Class16.smethod_0(1649167343))
						{
							return Class16.smethod_0(1649166444);
						}
						break;
					case 'm':
						if (field == Class16.smethod_0(1649167325))
						{
							return Class16.smethod_0(1649166418);
						}
						break;
					}
					break;
				}
				IL_0124:
				return Class16.smethod_0(1648936875);
			}
		}
		field = field.Replace('_', ' ');
		field = field.Replace(Class16.smethod_0(1649141675), Class16.smethod_0(1649141693));
		field = field.Replace(Class16.smethod_0(1649141703), Class16.smethod_0(1649141705));
		field = field.Replace(Class16.smethod_0(1649078567), Class16.smethod_0(1649166462));
		field = field.Replace(Class16.smethod_0(1649166476), Class16.smethod_0(1649166483));
		field = field.Replace(Class16.smethod_0(1649166499), Class16.smethod_0(1649166515));
		field = RSGlobal.ToTitleCase(field);
		field = field.Replace(Class16.smethod_0(1649127051), Class16.smethod_0(1649007040));
		field = field.Replace(Class16.smethod_0(1649166540), Class16.smethod_0(1649166427));
		field = field.Replace(Class16.smethod_0(1649166549), Class16.smethod_0(1649166418));
		field = field.Replace(Class16.smethod_0(1649166558), Class16.smethod_0(1649166453));
		field = field.Replace(Class16.smethod_0(1649166567), Class16.smethod_0(1649166569));
		if (field.IndexOf(Class16.smethod_0(1648942211)) > -1)
		{
			field = field.Replace(Class16.smethod_0(1649166579), Class16.smethod_0(1649166597));
			field = field.Replace(Class16.smethod_0(1649166607), Class16.smethod_0(1649166609));
			field = field.Replace(Class16.smethod_0(1649166619), Class16.smethod_0(1649166637));
			field = field.Replace(Class16.smethod_0(1649166647), Class16.smethod_0(1649166649));
			if (field.EndsWith(Class16.smethod_0(1649166659)))
			{
				field = field.Replace(Class16.smethod_0(1649166659), Class16.smethod_0(1649166677));
			}
			if (field.EndsWith(Class16.smethod_0(1649166687)))
			{
				field = field.Replace(Class16.smethod_0(1649166687), Class16.smethod_0(1648952349));
			}
			if (field.EndsWith(Class16.smethod_0(1649166690)))
			{
				field = field.Replace(Class16.smethod_0(1649166690), Class16.smethod_0(1649166709));
			}
			field = field.Replace(Class16.smethod_0(1649166714), Class16.smethod_0(1649166732));
			int num = 0;
			if (0 < field.Length)
			{
				do
				{
					char c2 = field[num];
					if ((uint)c2 > 57u || (uint)c2 < 48u)
					{
						num++;
						continue;
					}
					field = regex_0.Replace(field, Class16.smethod_0(1649166742));
					field = regex_1.Replace(field, Class16.smethod_0(1649166746));
					field = regex_2.Replace(field, Class16.smethod_0(1649166761));
					break;
				}
				while (num < field.Length);
			}
		}
		return field;
	}
}
