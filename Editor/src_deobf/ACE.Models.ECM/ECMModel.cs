using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Models.ECM;

public class ECMModel
{
	public const string HEADER = "MOXTVersion";

	private int int_0;

	private string string_0;

	private int int_1;

	private List<CombinedAct> list_0 = new List<CombinedAct>();

	private int int_2;

	private List<string> list_1 = new List<string>();

	private int int_3;

	private List<ChildEcm> list_2 = new List<ChildEcm>();

	private int int_4;

	private List<EcmEvent> list_3 = new List<EcmEvent>();

	private string string_1;

	private int int_5;

	private List<EcmBone> list_4 = new List<EcmBone>();

	private int int_6;

	private int int_7;

	private float float_0 = 1f;

	private bool bool_0;

	private bool bool_1 = true;

	private string string_2;

	private string string_3;

	private string string_4;

	private SkinModelData skinModelData_0;

	private List<pwMeshContainer> list_5 = new List<pwMeshContainer>();

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

	public string SkinModelPath
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

	public int ActCount
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

	public List<CombinedAct> Acts
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

	public int AdditionalSkinCount
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

	public List<string> AdditionalSkins
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

	public int ChildCount
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

	public List<ChildEcm> ChildEcms
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

	public int GfxNum
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

	public List<EcmEvent> Events
	{
		[CompilerGenerated]
		get
		{
			return list_3;
		}
		[CompilerGenerated]
		set
		{
			list_3 = value;
		}
	}

	public string OrgColor
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

	public int BoneNum
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public List<EcmBone> Bones
	{
		[CompilerGenerated]
		get
		{
			return list_4;
		}
		[CompilerGenerated]
		set
		{
			list_4 = value;
		}
	}

	public int SrcBlend
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int DstBlend
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public float DefaultSpeed
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

	public bool CanCastShadow
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

	public bool RenderModel
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public string FilePath
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

	public string Name
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

	public string RelativePath
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

	public SkinModelData SMD
	{
		[CompilerGenerated]
		get
		{
			return skinModelData_0;
		}
		[CompilerGenerated]
		set
		{
			skinModelData_0 = value;
		}
	}

	public List<pwMeshContainer> SkiModels
	{
		[CompilerGenerated]
		get
		{
			return list_5;
		}
		[CompilerGenerated]
		set
		{
			list_5 = value;
		}
	}

	public static ECMModel Load(byte[] data, string filePath, Func<string, byte[]> fileLoader = null)
	{
		if (data != null && data.Length != 0)
		{
			string content = Encoding.GetEncoding(936).GetString(data);
			return Parse(content, filePath, fileLoader);
		}
		return null;
	}

	public static ECMModel Parse(string content, string filePath, Func<string, byte[]> fileLoader = null)
	{
		ECMModel eCMModel = new ECMModel();
		eCMModel.FilePath = filePath;
		if (!string.IsNullOrEmpty(filePath))
		{
			eCMModel.Name = System.IO.Path.GetFileNameWithoutExtension(filePath);
			eCMModel.RelativePath = System.IO.Path.GetDirectoryName(filePath);
		}
		StringReader stringReader = new StringReader(content);
		try
		{
			int num = 0;
			string text;
			while ((text = stringReader.ReadLine()) != null)
			{
				num++;
				text = text.Trim();
				if (string.IsNullOrEmpty(text))
				{
					continue;
				}
				string[] array = text.Split(new char[1] { ':' }, 2);
				if (array.Length < 2)
				{
					continue;
				}
				string text2 = array[0].Trim();
				string text3 = array[1].Trim();
				try
				{
					if (text2 == null)
					{
						continue;
					}
					switch (text2.Length)
					{
					case 6:
						if (text2 == Class16.smethod_0(1649123267))
						{
							eCMModel.GfxNum = int.Parse(text3);
						}
						break;
					case 7:
						if (text2 == Class16.smethod_0(1649123280))
						{
							eCMModel.BoneNum = int.Parse(text3);
						}
						break;
					case 8:
						switch (text2[0])
						{
						case 'D':
							if (text2 == Class16.smethod_0(1649123163))
							{
								eCMModel.DstBlend = int.Parse(text3);
							}
							break;
						case 'A':
							if (text2 == Class16.smethod_0(1649123126))
							{
								eCMModel.ActCount = int.Parse(text3);
							}
							break;
						case 'S':
							if (text2 == Class16.smethod_0(1649123156))
							{
								eCMModel.SrcBlend = int.Parse(text3);
							}
							break;
						case 'O':
							if (text2 == Class16.smethod_0(1649123141))
							{
								eCMModel.OrgColor = text3;
							}
							break;
						}
						break;
					case 10:
						switch (text2[0])
						{
						case 'A':
							if (text2 == Class16.smethod_0(1649123233))
							{
							}
							break;
						case 'B':
							if (text2 == Class16.smethod_0(1649123250))
							{
							}
							break;
						case 'C':
							if (text2 == Class16.smethod_0(1649123216))
							{
								eCMModel.ChildCount = int.Parse(text3);
							}
							break;
						}
						break;
					case 11:
						switch (text2[0])
						{
						case 'R':
							if (text2 == Class16.smethod_0(1649123040))
							{
								eCMModel.RenderModel = text3 == Class16.smethod_0(1648934925) || text3.ToLower() == Class16.smethod_0(1648901259);
							}
							break;
						case 'M':
							if (text2 == Class16.smethod_0(1649123030))
							{
								eCMModel.Version = int.Parse(text3);
							}
							break;
						}
						break;
					case 12:
						switch (text2[0])
						{
						case 'D':
							if (text2 == Class16.smethod_0(1649123205))
							{
								eCMModel.DefaultSpeed = float.Parse(text3, CultureInfo.InvariantCulture);
							}
							break;
						case 'A':
							if (text2 == Class16.smethod_0(1649123178))
							{
								eCMModel.AdditionalSkins.Add(text3);
							}
							break;
						}
						break;
					case 13:
						switch (text2[0])
						{
						case 'S':
							if (text2 == Class16.smethod_0(1649123058))
							{
								eCMModel.SkinModelPath = text3.ToLowerInvariant();
							}
							break;
						case 'C':
							if (text2 == Class16.smethod_0(1649123098))
							{
								eCMModel.CanCastShadow = text3 == Class16.smethod_0(1648934925) || text3.ToLower() == Class16.smethod_0(1648901259);
							}
							break;
						case 'A':
							if (text2 == Class16.smethod_0(1649123086))
							{
								eCMModel.AdditionalSkinCount = int.Parse(text3);
							}
							break;
						}
						break;
					case 9:
						break;
					}
				}
				catch
				{
				}
			}
			if (fileLoader != null && !string.IsNullOrEmpty(eCMModel.SkinModelPath))
			{
				eCMModel.method_0(fileLoader);
			}
			return eCMModel;
		}
		finally
		{
			((IDisposable)stringReader).Dispose();
		}
	}

	private void method_0(Func<string, byte[]> func_0)
	{
		string text = SkinModelPath;
		if (!text.Contains(Class16.smethod_0(1648927580)) && !text.Contains(Class16.smethod_0(1648892117)))
		{
			text = smethod_0(RelativePath, text);
		}
		byte[] array = func_0(text);
		if (array == null)
		{
			return;
		}
		SMD = SkinModelData.Load(array, text, func_0);
		if (SMD == null)
		{
			return;
		}
		foreach (string skiPath in SMD.SkiPaths)
		{
			string arg = smethod_0(SMD.RelativePath, skiPath);
			byte[] array2 = func_0(arg);
			if (array2 == null)
			{
				continue;
			}
			MemoryStream memoryStream = new MemoryStream(array2);
			try
			{
				if (PWMeshReader.ReadFile(memoryStream))
				{
					SkiModels.Add(PWMeshReader.pwMesh);
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		if (SkiModels.Count == 0)
		{
			string arg2 = FilePath.Replace(Class16.smethod_0(1648906325), Class16.smethod_0(1648906306)).Replace(Class16.smethod_0(1649123302), Class16.smethod_0(1648906306));
			byte[] array3 = func_0(arg2);
			if (array3 != null)
			{
				MemoryStream memoryStream2 = new MemoryStream(array3);
				try
				{
					if (PWMeshReader.ReadFile(memoryStream2))
					{
						SkiModels.Add(PWMeshReader.pwMesh);
					}
				}
				finally
				{
					((IDisposable)memoryStream2).Dispose();
				}
			}
		}
		foreach (string additionalSkin in AdditionalSkins)
		{
			if (!additionalSkin.EndsWith(Class16.smethod_0(1648906306), StringComparison.OrdinalIgnoreCase))
			{
				continue;
			}
			string text2 = additionalSkin;
			if (!text2.Contains(Class16.smethod_0(1648927580)) && !text2.Contains(Class16.smethod_0(1648892117)))
			{
				text2 = smethod_0(RelativePath, additionalSkin);
			}
			byte[] array4 = func_0(text2);
			if (array4 == null)
			{
				continue;
			}
			MemoryStream memoryStream3 = new MemoryStream(array4);
			try
			{
				if (PWMeshReader.ReadFile(memoryStream3))
				{
					SkiModels.Add(PWMeshReader.pwMesh);
				}
			}
			finally
			{
				((IDisposable)memoryStream3).Dispose();
			}
		}
	}

	private static string smethod_0(string string_5, string string_6)
	{
		if (string.IsNullOrEmpty(string_5))
		{
			return string_6;
		}
		string_6 = string_6.Replace('/', '\\');
		return System.IO.Path.Combine(string_5, string_6);
	}
}
