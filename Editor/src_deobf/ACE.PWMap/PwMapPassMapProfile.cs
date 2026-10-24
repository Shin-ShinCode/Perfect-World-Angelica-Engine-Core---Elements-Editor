using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace ACE.PWMap;

public sealed class PwMapPassMapProfile
{
	private string string_0 = Class16.smethod_0(1649089211);

	private bool bool_0;

	private float float_0 = 45f;

	private int int_0 = 1;

	private List<PwMapPassMapSector> list_0 = new List<PwMapPassMapSector>();

	[JsonProperty("name")]
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

	[JsonProperty("saveImages")]
	public bool SaveImages
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	[JsonProperty("clipAngle")]
	public float ClipAngle
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	[JsonProperty("rmapRadius")]
	public int RmapRadius
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

	[JsonProperty("sectors")]
	public List<PwMapPassMapSector> Sectors
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

	public void EnsureSectorCount(int totalSectors)
	{
		while (Sectors.Count < totalSectors)
		{
			Sectors.Add(new PwMapPassMapSector());
		}
		if (Sectors.Count > totalSectors)
		{
			Sectors.RemoveRange(totalSectors, Sectors.Count - totalSectors);
		}
	}

	public static PwMapPassMapProfile LoadOrCreate(string path)
	{
		try
		{
			if (File.Exists(path))
			{
				string text = File.ReadAllText(path);
				return JsonConvert.DeserializeObject<PwMapPassMapProfile>(text) ?? new PwMapPassMapProfile();
			}
		}
		catch
		{
		}
		return new PwMapPassMapProfile();
	}

	public void Save(string path)
	{
		Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path) ?? string.Empty);
		string contents = JsonConvert.SerializeObject((object)this, (Formatting)1);
		File.WriteAllText(path, contents);
	}
}
