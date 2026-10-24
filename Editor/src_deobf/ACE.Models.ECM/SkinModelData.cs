using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using ACE.Classes;

namespace ACE.Models.ECM;

public class SkinModelData
{
	public const string HEADER_SIGNATURE = "MOXBDMSA";

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private int int_4;

	private string string_0;

	private List<string> list_0 = new List<string>();

	private string string_1;

	private string string_2;

	private List<SkinModelAction> list_1 = new List<SkinModelAction>();

	private List<Hanger> list_2 = new List<Hanger>();

	private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

	private Skeleton skeleton_0;

	private string string_3;

	private string string_4;

	private string string_5;

	public int Version
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

	public int NumSkins
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

	public int NumAction
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int NumHanger
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int NumProperty
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public string BonPath
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

	public List<string> SkiPaths
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

	public string PhyPath
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public string AnimationFilePath
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public List<SkinModelAction> Animations
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public List<Hanger> Hangers
	{
		[CompilerGenerated]
		get
		{
			return list_2;
		}
		[CompilerGenerated]
		set
		{
			list_2 = value;
		}
	}

	public Dictionary<string, string> Properties
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
		[CompilerGenerated]
		set
		{
			dictionary_0 = value;
		}
	}

	public Skeleton Skeleton
	{
		[CompilerGenerated]
		get
		{
			return skeleton_0;
		}
		[CompilerGenerated]
		set
		{
			skeleton_0 = value;
		}
	}

	public string FilePath
	{
		[CompilerGenerated]
		get
		{
			return string_3;
		}
		[CompilerGenerated]
		set
		{
			string_3 = value;
		}
	}

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_4;
		}
		[CompilerGenerated]
		set
		{
			string_4 = value;
		}
	}

	public string RelativePath
	{
		[CompilerGenerated]
		get
		{
			return string_5;
		}
		[CompilerGenerated]
		set
		{
			string_5 = value;
		}
	}

	public static SkinModelData Load(byte[] data, string filePath, Func<string, byte[]> fileLoader = null)
	{
		if (data != null && data.Length >= 8)
		{
			MemoryStream memoryStream = new MemoryStream(data);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					return Load(binaryReader, filePath, fileLoader);
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		return null;
	}

	public static SkinModelData Load(BinaryReader reader, string filePath, Func<string, byte[]> fileLoader = null)
	{
		SkinModelData skinModelData = new SkinModelData();
		skinModelData.FilePath = filePath;
		if (!string.IsNullOrEmpty(filePath))
		{
			skinModelData.Name = System.IO.Path.GetFileNameWithoutExtension(filePath);
			skinModelData.RelativePath = System.IO.Path.GetDirectoryName(filePath);
		}
		byte[] bytes = reader.ReadBytes(8);
		string text = Encoding.ASCII.GetString(bytes);
		if (!text.StartsWith(Class16.smethod_0(1648918753)))
		{
			return null;
		}
		skinModelData.Version = reader.ReadInt32();
		skinModelData.NumSkins = reader.ReadInt32();
		skinModelData.NumAction = reader.ReadInt32();
		skinModelData.NumHanger = reader.ReadInt32();
		skinModelData.NumProperty = reader.ReadInt32();
		reader.ReadBytes(60);
		skinModelData.BonPath = smethod_0(reader);
		if (fileLoader != null && !string.IsNullOrEmpty(skinModelData.BonPath))
		{
			string text2 = smethod_2(skinModelData.RelativePath, skinModelData.BonPath);
			byte[] array = fileLoader(text2);
			if (array != null)
			{
				skinModelData.Skeleton = Skeleton.Load(array, text2);
			}
		}
		for (int i = 0; i < skinModelData.NumSkins; i++)
		{
			string text3 = smethod_0(reader);
			if (!string.IsNullOrEmpty(text3))
			{
				skinModelData.SkiPaths.Add(text3);
			}
		}
		int num = reader.ReadInt32();
		if (num > 0)
		{
			skinModelData.PhyPath = smethod_1(reader, num);
		}
		if (skinModelData.Version >= 8)
		{
			skinModelData.AnimationFilePath = smethod_0(reader);
		}
		else
		{
			skinModelData.AnimationFilePath = Class16.smethod_0(1649122471) + skinModelData.Name;
		}
		try
		{
			for (int j = 0; j < skinModelData.NumAction; j++)
			{
				_ = reader.BaseStream.Position;
				SkinModelAction skinModelAction = SkinModelAction.Read(reader, skinModelData.Version, skinModelData.AnimationFilePath, skinModelData.RelativePath);
				if (skinModelAction != null && (skinModelAction.Name != null || skinModelAction.EndFrame > 0f))
				{
					skinModelData.Animations.Add(skinModelAction);
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649122475));
		}
		try
		{
			for (int k = 0; k < skinModelData.NumHanger; k++)
			{
				skinModelData.Hangers.Add(Hanger.Read(reader));
			}
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649122475));
		}
		try
		{
			for (int l = 0; l < skinModelData.NumProperty; l++)
			{
				string text4 = smethod_0(reader);
				string value = smethod_0(reader);
				if (!string.IsNullOrEmpty(text4))
				{
					skinModelData.Properties[text4] = value;
				}
			}
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649122475));
		}
		return skinModelData;
	}

	private static string smethod_0(BinaryReader binaryReader_0)
	{
		int int_ = binaryReader_0.ReadInt32();
		return smethod_1(binaryReader_0, int_);
	}

	private static string smethod_1(BinaryReader binaryReader_0, int int_5)
	{
		if (int_5 > 0 && int_5 <= 1024)
		{
			byte[] bytes = binaryReader_0.ReadBytes(int_5);
			return Encoding.GetEncoding(936).GetString(bytes).TrimEnd(default(char));
		}
		return null;
	}

	private static string smethod_2(string string_6, string string_7)
	{
		if (string.IsNullOrEmpty(string_6))
		{
			return string_7;
		}
		string_7 = string_7.Replace('/', '\\');
		if (!string_7.Contains(Class16.smethod_0(1648927580)) && !string_7.Contains(Class16.smethod_0(1648892117)))
		{
			return System.IO.Path.Combine(string_6, string_7);
		}
		return string_7;
	}
}
