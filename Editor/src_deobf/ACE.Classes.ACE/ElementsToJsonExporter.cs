using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ACE.Classes.ACE;

public class ElementsToJsonExporter
{
	public static void ExportToFile(List<ListData> lists, string fileName)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		using StreamWriter streamWriter = File.CreateText(fileName);
		JsonSerializer val = new JsonSerializer();
		val.Formatting = (Formatting)1;
		val.Serialize((TextWriter)streamWriter, (object)new { lists });
	}
}
