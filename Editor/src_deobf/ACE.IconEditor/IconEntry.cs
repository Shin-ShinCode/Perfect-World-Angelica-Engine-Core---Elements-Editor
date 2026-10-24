using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ACE.IconEditor;

public sealed class IconEntry
{
	private static readonly Regex regex_0 = new Regex(Class16.smethod_0(1649053426), RegexOptions.Compiled);

	private int int_0;

	private int int_1;

	private string string_0 = string.Empty;

	private List<int> list_0 = new List<int>();

	public int StartIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int FrameCount
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public List<int> Durations
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public override string ToString()
	{
		return string.Format(Class16.smethod_0(1649053196), StartIndex, Name, FrameCount);
	}

	public string ToTxtLine()
	{
		string text = ((Durations.Count == 0) ? string.Empty : (Class16.smethod_0(1648942211) + string.Join(Class16.smethod_0(1648942211), Durations)));
		return string.Format(Class16.smethod_0(1649053499), StartIndex, FrameCount, Name, text);
	}

	public static bool TryParseLegacy(string line, out IconEntry entry)
	{
		entry = null;
		if (string.IsNullOrWhiteSpace(line))
		{
			return false;
		}
		Match match = regex_0.Match(line);
		if (!match.Success)
		{
			return false;
		}
		if (!int.TryParse(match.Groups[Class16.smethod_0(1649053522)].Value, out var result))
		{
			return false;
		}
		if (!int.TryParse(match.Groups[Class16.smethod_0(1649053542)].Value, out var result2))
		{
			return false;
		}
		List<int> list = new List<int>();
		string text = match.Groups[Class16.smethod_0(1649053547)].Value.Trim();
		if (text.Length > 0)
		{
			string[] array = text.Split(new char[2] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			foreach (string s in array2)
			{
				if (int.TryParse(s, out var result3))
				{
					list.Add(result3);
				}
			}
		}
		entry = new IconEntry
		{
			StartIndex = result,
			FrameCount = Math.Max(1, result2),
			Name = match.Groups[Class16.smethod_0(1648905100)].Value,
			Durations = list
		};
		return true;
	}
}
