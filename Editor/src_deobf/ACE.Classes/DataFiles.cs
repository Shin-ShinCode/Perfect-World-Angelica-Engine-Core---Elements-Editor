using System;
using System.Runtime.InteropServices;
using ACE.AIPolicyEditor.AIPolicy;
using ACE.Elements.eListCollection;
using ACE.GShop;
using ACE.sTASKedit.Classes;

namespace ACE.Classes;

public class DataFiles
{
	public static eListCollection Elements;

	public static TASKS Tasks;

	public static AIFile AIPolicy;

	public static GSHOP GShopMain = new GSHOP();

	public static GSHOP GShop1 = new GSHOP();

	public static GSHOP GShop2 = new GSHOP();

	public static GSHOP GShop3 = new GSHOP();

	public static DATA_FILES_ENUM CurrentGShop = DATA_FILES_ENUM.GSHOP;

	public static GAMES Game
	{
		get
		{
			GAMES result = GAMES.UNKNOWN_GAME;
			if (Elements != null)
			{
				result = Elements.Game;
			}
			else if (GShop != null)
			{
				result = GShop.Game;
			}
			return result;
		}
	}

	public static GSHOP GShop
	{
		get
		{
			return CurrentGShop switch
			{
				DATA_FILES_ENUM.GSHOP3 => GShop3, 
				DATA_FILES_ENUM.GSHOP => GShopMain, 
				DATA_FILES_ENUM.GSHOP1 => GShop1, 
				DATA_FILES_ENUM.GSHOP2 => GShop2, 
				_ => throw new ArgumentOutOfRangeException(Class16.smethod_0(1648908559)), 
			};
		}
		set
		{
			switch (CurrentGShop)
			{
			case DATA_FILES_ENUM.GSHOP3:
				GShop3 = value;
				break;
			default:
				GShopMain = value;
				break;
			case DATA_FILES_ENUM.GSHOP2:
				GShop2 = value;
				break;
			case DATA_FILES_ENUM.GSHOP1:
				GShop1 = value;
				break;
			}
		}
	}

	public static void SetGShop(string BaseName)
	{
		if (BaseName == Class16.smethod_0(1648908570))
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP1;
		}
		else if (BaseName == Class16.smethod_0(1648908591))
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP2;
		}
		else if (BaseName == Class16.smethod_0(1648908604))
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP3;
		}
		else
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP;
		}
	}

	public static void SetGShop(DATA_FILES_ENUM file)
	{
		CurrentGShop = file;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool TrySetGShop(string fn)
	{
		if (GShopMain.FileName == fn)
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP;
			return true;
		}
		if (GShop1.FileName == fn)
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP1;
			return true;
		}
		if (GShop2.FileName == fn)
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP2;
			return true;
		}
		if (GShop3.FileName == fn)
		{
			CurrentGShop = DATA_FILES_ENUM.GSHOP3;
			return true;
		}
		return false;
	}

	public static int LI(string LIST_NAME)
	{
		return Elements?.get_LI(LIST_NAME) ?? (-1);
	}

	public static string LN(int list_index)
	{
		if (Elements != null && Elements.Lists != null && list_index >= 0 && list_index < Elements.Lists.Length && Elements.Lists[list_index] != null)
		{
			return Elements.Lists[list_index].uListName;
		}
		return null;
	}
}
