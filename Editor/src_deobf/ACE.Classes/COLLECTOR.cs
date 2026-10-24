using System.Collections.Generic;

namespace ACE.Classes;

public class COLLECTOR
{
	public static HashSet<string> Values = new HashSet<string>();

	public static void AddVal(string Val)
	{
		if (!Values.Contains(Val))
		{
			Values.Add(Val);
		}
	}
}
