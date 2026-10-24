using System.Text.RegularExpressions;

namespace ACE.RSGlobal;

public class RSMySQL
{
	private static class Class360
	{
		public static MatchEvaluator matchEvaluator_0;
	}

	public static string EscapeCharacters(string string_0)
	{
		MatchEvaluator evaluator = smethod_0;
		return Regex.Replace(string_0, Class16.smethod_0(1649162968), evaluator);
	}

	private static string smethod_0(Match match_0)
	{
		string value = match_0.Value;
		if (!(value == Class16.smethod_0(1648938185)))
		{
			if (!(value == Class16.smethod_0(1649163007)))
			{
				if (!(value == Class16.smethod_0(1648941987)))
				{
					if (!(value == Class16.smethod_0(1648904221)))
					{
						if (!(value == Class16.smethod_0(1648904383)))
						{
							if (!(value == Class16.smethod_0(1649163015)))
							{
								return Class16.smethod_0(1648927580) + value;
							}
							return Class16.smethod_0(1649163024);
						}
						return Class16.smethod_0(1648903421);
					}
					return Class16.smethod_0(1648935632);
				}
				return Class16.smethod_0(1648903412);
			}
			return Class16.smethod_0(1648905146);
		}
		return Class16.smethod_0(1649163023);
	}
}
