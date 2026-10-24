using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ACE.Classes.ACE;

public static class Extensions
{
	public static string ToJsonIndented(this object @this)
	{
		return JsonConvert.SerializeObject(@this, (Formatting)1);
	}

	public static string ToJson(this object @this)
	{
		return JsonConvert.SerializeObject(@this);
	}

	public static void ToJsonFile(this object @this, string fileName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		using StreamWriter streamWriter = File.CreateText(fileName);
		new JsonSerializer().Serialize((TextWriter)streamWriter, @this);
	}

	public static T FromJson<T>(this string @this)
	{
		return JsonConvert.DeserializeObject<T>(@this);
	}

	public static List<T> NullIfEmpty<T>(this List<T> @this)
	{
		if (@this != null && @this.Count != 0)
		{
			return @this;
		}
		return null;
	}
}
