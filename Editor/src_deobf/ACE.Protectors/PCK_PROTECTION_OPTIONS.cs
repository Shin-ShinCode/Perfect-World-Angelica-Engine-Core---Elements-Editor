using System;
using System.Collections.Generic;
using System.Text;
using ACE.Classes;
using ACE.RSGlobal;

namespace ACE.Protectors;

public class PCK_PROTECTION_OPTIONS
{
	public GAMES Game;

	public string ProjectName;

	public byte[] ProjectUnique;

	public bool IsProtected;

	public bool TrashBeforeFileTableOffset;

	public bool TrashInTheEOF;

	public bool RandomizedFTCompressionLevel;

	public bool RandomizedFileTableAdded;

	public bool IsEnigmaEnabled;

	public bool FTO_KEY_Changed;

	public bool KeysChanged;

	public bool Sign1_Changed;

	public bool Sign2_Changed;

	public bool Sign3_Changed;

	public bool AngelicaSignChanged;

	public bool MetaDataShifted;

	public uint MetaDataTrashLen;

	public uint MetaDataShift = 280u;

	public int KEY_1;

	public int KEY_2;

	public int FTO_KEY;

	public int TrashSizeKey;

	public byte[] AngelicaSign;

	public int ExtraFillesMask;

	public string ServerlistPath;

	public string ElementsPath;

	public string GShopPath;

	public string TasksPath;

	public string CustomFilePath;

	public string CustomFile2Path;

	public string PathDataPath;

	public PCK_PROTECTION_OPTIONS(PCK_PROTECTION_SETTINGS settings, string ProjectName)
	{
		this.ProjectName = ProjectName;
		ImportFromSettings(settings);
	}

	public PCK_PROTECTION_OPTIONS(string ProtectedKey)
	{
		PCK_PROTECTION_SETTINGS settings = PCK_PROTECTION_SETTINGS.Deserialize(ProtectedKey);
		ImportFromSettings(settings);
		IsProtected = true;
	}

	public PCK_PROTECTION_OPTIONS(int KEY_1, int KEY_2)
	{
		KeysChanged = true;
		this.KEY_1 = KEY_1;
		this.KEY_2 = KEY_2;
	}

	public static PCK_PROTECTION_OPTIONS ImportFromParams(ParamsClass Params)
	{
		PCK_PROTECTION_OPTIONS pCK_PROTECTION_OPTIONS = null;
		PCK_KEY_MODE pckKeyMode = Params.PckKeyMode;
		if (pckKeyMode != PCK_KEY_MODE.NONE)
		{
			switch (pckKeyMode)
			{
			case PCK_KEY_MODE.ADVANCED:
				pCK_PROTECTION_OPTIONS = new PCK_PROTECTION_OPTIONS(Params.PckProtectedKey);
				break;
			case PCK_KEY_MODE.SIMPLE:
				pCK_PROTECTION_OPTIONS = new PCK_PROTECTION_OPTIONS(Params.PckKey1, Params.PckKey2);
				break;
			}
			pCK_PROTECTION_OPTIONS.IsProtected = true;
			pCK_PROTECTION_OPTIONS.Game = Params.Game;
			return pCK_PROTECTION_OPTIONS;
		}
		return null;
	}

	public void ImportFromSettings(PCK_PROTECTION_SETTINGS settings)
	{
		TrashBeforeFileTableOffset = true;
		KEY_1 = settings.KEY_1;
		KEY_2 = settings.KEY_2;
		FTO_KEY = settings.FTO_KEY;
		MetaDataTrashLen = (MetaDataShift = settings.MetaDataShift) - 280;
		sbyte protectionLevel = settings.ProtectionLevel;
		if (protectionLevel >= 1)
		{
			TrashInTheEOF = true;
		}
		if (protectionLevel >= 2)
		{
			KeysChanged = true;
		}
		if (protectionLevel >= 3)
		{
			RandomizedFTCompressionLevel = true;
			RandomizedFileTableAdded = true;
		}
		if (protectionLevel >= 4)
		{
			MetaDataShifted = true;
		}
		if (protectionLevel >= 5)
		{
			FTO_KEY_Changed = true;
			AngelicaSignChanged = true;
		}
		if (protectionLevel >= 6)
		{
			IsEnigmaEnabled = true;
		}
		ExtraFillesMask = settings.ExtraFilesMask;
		string projectName = ProjectName;
		if (projectName != null)
		{
			string text = Class16.smethod_0(1648934967);
			string text2 = Class16.smethod_0(1648934925);
			ProjectUnique = RSMD5._md5.ComputeHash(Encoding.ASCII.GetBytes(RSCrypt.GetActKey(string.Concat(text2 + projectName, text))));
			SetExtraFilesPaths();
		}
	}

	public override string ToString()
	{
		List<string> list = new List<string>();
		list.Add(Class16.smethod_0(1649170697) + KEY_1);
		list.Add(Class16.smethod_0(1649170719) + KEY_2);
		list.Add(Class16.smethod_0(1649170733) + MetaDataShift);
		list.Add(Class16.smethod_0(1649170747) + FTO_KEY);
		list.Add(Class16.smethod_0(1649170777) + GShopPath);
		list.Add(Class16.smethod_0(1649170795) + CustomFilePath);
		list.Add(Class16.smethod_0(1649170818) + CustomFile2Path);
		list.Add(Class16.smethod_0(1649170842) + PathDataPath);
		string result = string.Join(Environment.NewLine, list);
		GC.KeepAlive(this);
		return result;
	}

	public void SetExtraFilesPaths()
	{
		string chars = RSMD5.Encode(RSCrypt.GetActKey(ProjectName));
		if (ACE.RSGlobal.RSGlobal.IsFlagExistP((ulong)ExtraFillesMask, 0))
		{
			ServerlistPath = GenerateProtectedPath(chars, 0);
		}
		if (ACE.RSGlobal.RSGlobal.IsFlagExistP((ulong)ExtraFillesMask, 1))
		{
			ElementsPath = GenerateProtectedPath(chars, 1);
		}
		if (ACE.RSGlobal.RSGlobal.IsFlagExistP((ulong)ExtraFillesMask, 2))
		{
			GShopPath = GenerateProtectedPath(chars, 2);
		}
		if (ACE.RSGlobal.RSGlobal.IsFlagExistP((ulong)ExtraFillesMask, 3))
		{
			TasksPath = GenerateProtectedPath(chars, 3);
		}
		if (ACE.RSGlobal.RSGlobal.IsFlagExistP((ulong)ExtraFillesMask, 4))
		{
			CustomFilePath = GenerateProtectedPath(chars, 4);
		}
		if (ACE.RSGlobal.RSGlobal.IsFlagExistP((ulong)ExtraFillesMask, 5))
		{
			CustomFile2Path = GenerateProtectedPath(chars, 5);
		}
		if (ACE.RSGlobal.RSGlobal.IsFlagExistP((ulong)ExtraFillesMask, 6))
		{
			PathDataPath = GenerateProtectedPath(chars, 6);
		}
	}

	public string GenerateProtectedPath(string chars, int start_index)
	{
		string text = string.Empty;
		int num = start_index * 2 + 1;
		int num2 = start_index;
		uint num3 = 2u;
		do
		{
			int index = chars[num2 % chars.Length] % chars.Length;
			text += chars[index];
			num2 = num + num2;
			num3--;
		}
		while (num3 != 0);
		string result = text + start_index;
		GC.KeepAlive(this);
		return result;
	}

	public static uint GetDefaultAngeEncryptionFlag()
	{
		return 0u;
	}

	public static byte[] GetDefaultSign()
	{
		return ACE.RSGlobal.RSGlobal.ToBytesA(Class16.smethod_0(1649170871), 252);
	}
}
