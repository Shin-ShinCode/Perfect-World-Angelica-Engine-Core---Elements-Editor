using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Cpk;
using ACE.RSGlobal;
using Sentry;

namespace ACE.GShop;

public class GSHOP
{
	public static CommonStorage CStorage;

	public GAMES Game;

	public string FileName;

	public bool FileLoaded;

	public int Stamp1;

	public int Stamp2;

	public uint TimeStamp;

	public int Version;

	public uint ItemsCount;

	public GSHOP_ITEM[] Items;

	public GSHOP_ITEM EmptyItem;

	public Category[] Categories;

	public byte[] BytesAfterEndOfFile;

	public PW_GSHOP_VERSION VersionPW;

	public bool IsExported;

	public bool FileChanged;

	public bool b_gshop2;

	public bool b_gshop3;

	public ReferenceType ExtraGshopTypePlus;

	public ReferenceSubType ExtraGshopSubTypePlus;

	public GSHOP(string fn, PW_GSHOP_VERSION vPW)
	{
		Game = GAMES.PW;
		Load(fn, vPW, 0);
	}

	public GSHOP(string fn)
	{
		Load(fn, PW_GSHOP_VERSION.AUTO, 0);
	}

	public GSHOP()
	{
		FileLoaded = false;
	}

	public static byte[] GetBytesStatic(string str, int int_0, Encoding encoding_0)
	{
		if (str == null)
		{
			return new byte[int_0];
		}
		str = str.Split(default(char))[0];
		byte[] array = new byte[int_0];
		if (encoding_0.GetByteCount(str) > int_0)
		{
			Array.Copy(encoding_0.GetBytes(str), 0, array, 0, int_0);
		}
		else
		{
			Array.Copy(encoding_0.GetBytes(str), array, encoding_0.GetByteCount(str));
		}
		return array;
	}

	public static void WriteItem_FW(BinaryWriter binaryWriter_0, GSHOP_ITEM_FW gshop_ITEM_FW_0, int Index, int Version)
	{
		binaryWriter_0.Write(Index);
		binaryWriter_0.Write(gshop_ITEM_FW_0.name);
		binaryWriter_0.Write(gshop_ITEM_FW_0.FileIcon);
		binaryWriter_0.Write(gshop_ITEM_FW_0.ItemID);
		binaryWriter_0.Write(gshop_ITEM_FW_0.Count);
		binaryWriter_0.Write(gshop_ITEM_FW_0.IsHide);
		binaryWriter_0.Write(gshop_ITEM_FW_0.CanGetConsumeScore);
		if (Version > 184)
		{
			binaryWriter_0.Write(gshop_ITEM_FW_0.uint_0);
		}
		binaryWriter_0.Write(gshop_ITEM_FW_0.GiftID);
		binaryWriter_0.Write(gshop_ITEM_FW_0.GiftRate);
		binaryWriter_0.Write(gshop_ITEM_FW_0.BuyTypeMask);
		binaryWriter_0.Write(gshop_ITEM_FW_0.price);
		binaryWriter_0.Write(gshop_ITEM_FW_0.ExpireDate);
		binaryWriter_0.Write(gshop_ITEM_FW_0.ext_search);
		binaryWriter_0.Write(gshop_ITEM_FW_0.NewItemIndex);
		binaryWriter_0.Write(gshop_ITEM_FW_0.SellBeginTime);
		binaryWriter_0.Write(gshop_ITEM_FW_0.SellEndTime);
		binaryWriter_0.Write(gshop_ITEM_FW_0.DiscountBeginTime);
		binaryWriter_0.Write(gshop_ITEM_FW_0.DiscountEndTime);
		binaryWriter_0.Write(gshop_ITEM_FW_0.DiscountPrice);
		binaryWriter_0.Write(gshop_ITEM_FW_0.LogoIcon);
		binaryWriter_0.Write(gshop_ITEM_FW_0.PreviewBackgroundPic);
		binaryWriter_0.Write(gshop_ITEM_FW_0.PreviewPriority);
		binaryWriter_0.Write(gshop_ITEM_FW_0.DiscountItemShowIndex);
		binaryWriter_0.Write(gshop_ITEM_FW_0.PriorityPreviewModel);
		if (Version >= 192)
		{
			binaryWriter_0.Write(gshop_ITEM_FW_0.LimitTimesTaskId);
		}
	}

	public static GSHOP_ITEM_PW ReadItem_PW(BinaryReader br, PW_GSHOP_VERSION VersionPW)
	{
		GSHOP_ITEM_PW gSHOP_ITEM_PW = new GSHOP_ITEM_PW();
		gSHOP_ITEM_PW.SaleOptions = new SALE_OPTION[4];
		for (int i = 0; i < 4; i++)
		{
			gSHOP_ITEM_PW.SaleOptions[i] = new SALE_OPTION();
		}
		gSHOP_ITEM_PW.icon_path = string.Empty;
		gSHOP_ITEM_PW.description = string.Empty;
		gSHOP_ITEM_PW.name = string.Empty;
		gSHOP_ITEM_PW.Occupation = -1;
		gSHOP_ITEM_PW.Version = VersionPW;
		gSHOP_ITEM_PW.ID = br.ReadInt32();
		gSHOP_ITEM_PW.CatIndex = (uint)br.ReadInt32();
		gSHOP_ITEM_PW.SubCatIndex = (uint)br.ReadInt32();
		gSHOP_ITEM_PW.icon_path = Encoding.GetEncoding(936).GetString(br.ReadBytes(128)).Split(default(char))[0];
		gSHOP_ITEM_PW.ItemID = (int)br.ReadUInt32();
		gSHOP_ITEM_PW.Count = (int)br.ReadUInt32();
		for (int j = 0; j < 4; j++)
		{
			gSHOP_ITEM_PW.SaleOptions[j].Price = br.ReadUInt32();
			gSHOP_ITEM_PW.SaleOptions[j].ExpireDate = br.ReadUInt32();
			gSHOP_ITEM_PW.SaleOptions[j].Duration = br.ReadUInt32();
			if (VersionPW > PW_GSHOP_VERSION.PW_1_2_6)
			{
				gSHOP_ITEM_PW.SaleOptions[j].StartDate = br.ReadUInt32();
				gSHOP_ITEM_PW.SaleOptions[j].ControlType = br.ReadInt32();
				gSHOP_ITEM_PW.SaleOptions[j].Day = br.ReadUInt32();
				gSHOP_ITEM_PW.SaleOptions[j].Status = br.ReadUInt32();
				gSHOP_ITEM_PW.SaleOptions[j].Flags = br.ReadUInt32();
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156)
				{
					gSHOP_ITEM_PW.SaleOptions[j].MinVipLevel = br.ReadUInt32();
				}
			}
		}
		if (VersionPW == PW_GSHOP_VERSION.PW_1_2_6)
		{
			gSHOP_ITEM_PW.SaleOptions[0].Status = br.ReadUInt32();
		}
		gSHOP_ITEM_PW.description = Encoding.Unicode.GetString(br.ReadBytes(1024)).Split(default(char))[0].TrimEnd(default(char));
		gSHOP_ITEM_PW.name = Encoding.Unicode.GetString(br.ReadBytes(64)).Split(default(char))[0].TrimEnd(default(char));
		if (VersionPW > PW_GSHOP_VERSION.PW_1_4_2_v27)
		{
			gSHOP_ITEM_PW.GiftID = (int)br.ReadUInt32();
			gSHOP_ITEM_PW.GiftCount = (int)br.ReadUInt32();
			gSHOP_ITEM_PW.GiftDuration = br.ReadUInt32();
			if (VersionPW >= PW_GSHOP_VERSION.PW_1_4_4)
			{
				gSHOP_ITEM_PW.LogPrice = br.ReadUInt32();
			}
			if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
			{
				gSHOP_ITEM_PW.owner_npcs = new int[8];
				for (int k = 0; k < 8; k++)
				{
					gSHOP_ITEM_PW.owner_npcs[k] = (int)br.ReadUInt32();
				}
			}
			if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156)
			{
				gSHOP_ITEM_PW.BuyTimesLimit = br.ReadInt32();
				gSHOP_ITEM_PW.BuyTimesLimitMode = br.ReadInt32();
			}
			if (VersionPW >= PW_GSHOP_VERSION.PW_1_7_6)
			{
				gSHOP_ITEM_PW.tasks_id = br.ReadInt32();
				gSHOP_ITEM_PW.tasks_space = br.ReadInt32();
				gSHOP_ITEM_PW.Occupation = br.ReadInt32();
			}
			else
			{
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v181)
				{
					gSHOP_ITEM_PW.Occupation = br.ReadInt32();
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_6_0)
				{
					gSHOP_ITEM_PW.tasks_id = br.ReadInt32();
					gSHOP_ITEM_PW.tasks_space = br.ReadInt32();
				}
			}
			if (VersionPW >= PW_GSHOP_VERSION.PW_1_7_6)
			{
				gSHOP_ITEM_PW.reserved1 = br.ReadInt32();
				gSHOP_ITEM_PW.reserved2 = br.ReadInt32();
				gSHOP_ITEM_PW.reserved3 = br.ReadInt32();
				gSHOP_ITEM_PW.reserved4 = br.ReadInt32();
			}
			if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_3)
			{
				gSHOP_ITEM_PW.special_server_forbid = br.ReadInt32();
				gSHOP_ITEM_PW.in_green_shop = br.ReadByte();
				if (VersionPW == PW_GSHOP_VERSION.PW_1_8_3)
				{
					gSHOP_ITEM_PW.unk184 = br.ReadByte();
				}
			}
			if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_6)
			{
				gSHOP_ITEM_PW.add_trade_time = br.ReadInt32();
				gSHOP_ITEM_PW.reserved6 = br.ReadInt32();
			}
		}
		return gSHOP_ITEM_PW;
	}

	public static void WriteItem_PW(BinaryWriter bw, GSHOP_ITEM_PW item, PW_GSHOP_VERSION VersionPW)
	{
		if (item.SaleOptions == null)
		{
			item.SaleOptions = new SALE_OPTION[4];
		}
		if (item.SaleOptions.Length < 4)
		{
			SALE_OPTION[] array = new SALE_OPTION[4];
			for (int i = 0; i < item.SaleOptions.Length; i++)
			{
				array[i] = item.SaleOptions[i];
			}
			item.SaleOptions = array;
		}
		for (int j = 0; j < 4; j++)
		{
			if (item.SaleOptions[j] == null)
			{
				item.SaleOptions[j] = new SALE_OPTION();
			}
		}
		bw.Write(item.ID);
		bw.Write((int)item.CatIndex);
		bw.Write((int)item.SubCatIndex);
		bw.Write(GetBytesStatic(item.icon_path, 128, Encoding.GetEncoding(936)));
		bw.Write((uint)item.ItemID);
		bw.Write((uint)item.Count);
		int num = 0;
		do
		{
			bw.Write(item.SaleOptions[num].Price);
			bw.Write(item.SaleOptions[num].ExpireDate);
			bw.Write(item.SaleOptions[num].Duration);
			if (VersionPW > PW_GSHOP_VERSION.PW_1_2_6)
			{
				bw.Write(item.SaleOptions[num].StartDate);
				bw.Write(item.SaleOptions[num].ControlType);
				bw.Write(item.SaleOptions[num].Day);
				bw.Write(item.SaleOptions[num].Status);
				bw.Write(item.SaleOptions[num].Flags);
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156)
				{
					bw.Write(item.SaleOptions[num].MinVipLevel);
				}
			}
			num++;
		}
		while (num < 4);
		if (VersionPW == PW_GSHOP_VERSION.PW_1_2_6)
		{
			bw.Write(item.SaleOptions[0].Status);
		}
		bw.Write(GetBytesStatic(item.description, 1024, Encoding.Unicode));
		bw.Write(GetBytesStatic(item.name, 64, Encoding.Unicode));
		if (VersionPW <= PW_GSHOP_VERSION.PW_1_4_2_v27)
		{
			return;
		}
		bw.Write((uint)item.GiftID);
		bw.Write((uint)item.GiftCount);
		bw.Write(item.GiftDuration);
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_4_4)
		{
			bw.Write(item.LogPrice);
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
		{
			if (item.owner_npcs == null || item.owner_npcs.Length != 8)
			{
				int[] array2 = new int[8];
				if (item.owner_npcs != null)
				{
					for (int k = 0; k < Math.Min(item.owner_npcs.Length, 8); k++)
					{
						array2[k] = item.owner_npcs[k];
					}
				}
				item.owner_npcs = array2;
			}
			for (int l = 0; l < 8; l++)
			{
				bw.Write((uint)item.owner_npcs[l]);
			}
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156)
		{
			bw.Write(item.BuyTimesLimit);
			bw.Write(item.BuyTimesLimitMode);
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v181)
		{
			bw.Write(item.Occupation);
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_6_0)
		{
			bw.Write(item.tasks_id);
			bw.Write(item.tasks_space);
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_7_6)
		{
			bw.Write(item.reserved1);
			bw.Write(item.reserved2);
			bw.Write(item.reserved3);
			bw.Write(item.reserved4);
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_3)
		{
			bw.Write(item.special_server_forbid);
			bw.Write(item.in_green_shop);
			if (VersionPW == PW_GSHOP_VERSION.PW_1_8_3)
			{
				bw.Write(item.unk184);
			}
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_6)
		{
			bw.Write(item.add_trade_time);
			bw.Write(item.reserved6);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Load(string fn, PW_GSHOP_VERSION vPW, int gshop_index)
	{
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1648903793), Class16.smethod_0(1648906382));
		if (!string.IsNullOrWhiteSpace(fn) && File.Exists(fn) && (fn.EndsWith(Class16.smethod_0(1648909430)) || fn.EndsWith(Class16.smethod_0(1648898363)) || fn.EndsWith(Class16.smethod_0(1649071314))))
		{
			if (Game == GAMES.JD)
			{
				return false;
			}
			FileName = fn;
			FileLoaded = false;
			Items = Array.Empty<GSHOP_ITEM>();
			ItemsCount = 0u;
			Categories = Array.Empty<Category>();
			VersionPW = vPW;
			FileStream fileStream = null;
			BinaryReader binaryReader = null;
			try
			{
				fileStream = File.OpenRead(fn);
				binaryReader = new BinaryReader(fileStream);
				if (Game == GAMES.UNKNOWN_GAME)
				{
					DetectGame(binaryReader);
				}
				if (!IsExported)
				{
					switch (Game)
					{
					case GAMES.FW:
					{
						Stamp1 = binaryReader.ReadInt32();
						Stamp2 = binaryReader.ReadInt32();
						TimeStamp = binaryReader.ReadUInt32();
						int num = (Version = binaryReader.ReadInt32());
						if (num > 1000)
						{
							int num2 = num;
							ACE.RSGlobal.RSGlobal.ThrowExceptionG(Class16.smethod_0(1649071330) + num2);
						}
						break;
					}
					case GAMES.PW:
						TimeStamp = binaryReader.ReadUInt32();
						break;
					}
				}
				int num3 = (int)(ItemsCount = (uint)binaryReader.ReadInt32());
				if ((uint)num3 > 30000u)
				{
					uint num4 = (uint)num3;
					ACE.RSGlobal.RSGlobal.ThrowExceptionG(Class16.smethod_0(1649071354) + num4);
				}
				Items = new GSHOP_ITEM[ItemsCount];
				switch (Game)
				{
				case GAMES.FW:
					ReadItems_FW(binaryReader);
					if (ItemsCount != 0)
					{
						EmptyItem = ((GSHOP_ITEM_FW)Items[0]).Clone();
					}
					else
					{
						EmptyItem = new GSHOP_ITEM();
					}
					break;
				case GAMES.PW:
				{
					if (VersionPW == PW_GSHOP_VERSION.AUTO)
					{
						DetectVersion_PW(binaryReader);
					}
					ReadItems_PW(binaryReader);
					if (!IsExported)
					{
						ReadCategories_PW(binaryReader);
					}
					((GSHOP_ITEM_PW)(EmptyItem = new GSHOP_ITEM_PW())).description = string.Empty;
					((GSHOP_ITEM_PW)EmptyItem).Version = VersionPW;
					((GSHOP_ITEM_PW)EmptyItem).GiftCount = 0;
					((GSHOP_ITEM_PW)EmptyItem).GiftDuration = 0u;
					((GSHOP_ITEM_PW)EmptyItem).LogPrice = 0u;
					((GSHOP_ITEM_PW)EmptyItem).BuyTimesLimit = 0;
					((GSHOP_ITEM_PW)EmptyItem).BuyTimesLimitMode = 0;
					((GSHOP_ITEM_PW)EmptyItem).CatIndex = 0u;
					((GSHOP_ITEM_PW)EmptyItem).SubCatIndex = 0u;
					((GSHOP_ITEM_PW)EmptyItem).icon_path = Class16.smethod_0(1649071385);
					((GSHOP_ITEM_PW)EmptyItem).SaleOptions = new SALE_OPTION[4];
					for (int i = 0; i < 4; i++)
					{
						((GSHOP_ITEM_PW)EmptyItem).SaleOptions[i] = new SALE_OPTION();
					}
					((GSHOP_ITEM_PW)EmptyItem).Count = 1;
					((GSHOP_ITEM_PW)EmptyItem).Price = 100.0;
					((GSHOP_ITEM_PW)EmptyItem).name = string.Empty;
					((GSHOP_ITEM_PW)EmptyItem).ControlType = -1;
					if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
					{
						((GSHOP_ITEM_PW)EmptyItem).owner_npcs = new int[8];
					}
					if (VersionPW >= PW_GSHOP_VERSION.PW_1_6_0)
					{
						((GSHOP_ITEM_PW)EmptyItem).tasks_id = 0;
						((GSHOP_ITEM_PW)EmptyItem).tasks_space = 0;
					}
					if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v181)
					{
						((GSHOP_ITEM_PW)EmptyItem).Occupation = -1;
					}
					if (VersionPW >= PW_GSHOP_VERSION.PW_1_7_6)
					{
						((GSHOP_ITEM_PW)EmptyItem).reserved1 = 0;
						((GSHOP_ITEM_PW)EmptyItem).reserved2 = 0;
						((GSHOP_ITEM_PW)EmptyItem).reserved3 = 0;
						((GSHOP_ITEM_PW)EmptyItem).reserved4 = 0;
					}
					if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_3)
					{
						((GSHOP_ITEM_PW)EmptyItem).special_server_forbid = 0;
						((GSHOP_ITEM_PW)EmptyItem).in_green_shop = 0;
						if (VersionPW == PW_GSHOP_VERSION.PW_1_8_3)
						{
							((GSHOP_ITEM_PW)EmptyItem).unk184 = 0;
						}
					}
					if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_6)
					{
						((GSHOP_ITEM_PW)EmptyItem).add_trade_time = 0;
						((GSHOP_ITEM_PW)EmptyItem).reserved6 = 0;
					}
					break;
				}
				}
				if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
				{
					BinaryReader binaryReader2 = binaryReader;
					BytesAfterEndOfFile = binaryReader2.ReadBytes((int)(binaryReader2.BaseStream.Length - binaryReader.BaseStream.Position));
				}
				SortItemsByID();
				if (Game == GAMES.PW)
				{
					SetIdsFromIndexes();
				}
				string fileBaseName = ACE.RSGlobal.RSGlobal.GetFileBaseName(FileName);
				if (gshop_index != 1 && !fileBaseName.EndsWith(Class16.smethod_0(1648934925)))
				{
					if (gshop_index != 2 && !fileBaseName.EndsWith(Class16.smethod_0(1648934967)))
					{
						ExtraGshopTypePlus = ReferenceType.NONE;
						ExtraGshopSubTypePlus = ReferenceSubType.NONE;
					}
					else
					{
						ExtraGshopTypePlus = ReferenceType.GSHOP_NPCS;
						ExtraGshopSubTypePlus = ReferenceSubType.GSHOP1_NPC_OWNER;
					}
				}
				else
				{
					ExtraGshopTypePlus = ReferenceType.ELEMENTS_MATTERS;
					ExtraGshopSubTypePlus = ReferenceSubType.GSHOP_NPC_OWNER;
				}
				FileLoaded = true;
			}
			catch (EndOfStreamException ex)
			{
				string text = (string.IsNullOrWhiteSpace(FileName) ? Class16.smethod_0(1649004126) : FileName);
				SentryHelper.CaptureMessage(Class16.smethod_0(1649071440) + text + Class16.smethod_0(1648927638) + ex.Message, (SentryLevel)2, Class16.smethod_0(1649071473));
				Items = Array.Empty<GSHOP_ITEM>();
				ItemsCount = 0u;
				Categories = Array.Empty<Category>();
				object[] vars = new object[1] { Class16.smethod_0(1649071510) + ex.Message };
				TextStorage.TEXTS.ShowMessage(326, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
				FileLoaded = false;
			}
			catch (InvalidDataException ex2)
			{
				string text2 = (string.IsNullOrWhiteSpace(FileName) ? Class16.smethod_0(1649004126) : FileName);
				SentryHelper.CaptureMessage(Class16.smethod_0(1649071574) + text2 + Class16.smethod_0(1648927638) + ex2.Message, (SentryLevel)2, Class16.smethod_0(1649071606));
				Items = Array.Empty<GSHOP_ITEM>();
				ItemsCount = 0u;
				Categories = Array.Empty<Category>();
				object[] vars2 = new object[1] { Class16.smethod_0(1649070603) + ex2.Message };
				TextStorage.TEXTS.ShowMessage(326, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars2);
				FileLoaded = false;
			}
			catch (Exception ex3)
			{
				SentryHelper.CaptureException(ex3, Class16.smethod_0(1649070663));
				Items = Array.Empty<GSHOP_ITEM>();
				ItemsCount = 0u;
				Categories = Array.Empty<Category>();
				if (ex3.GetType() == typeof(ApplicationException))
				{
					object[] vars3 = new object[1] { ex3.Message };
					TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars3);
				}
				else
				{
					object[] vars4 = new object[1] { ex3.Message };
					TextStorage.TEXTS.ShowMessage(326, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars4);
				}
				FileLoaded = false;
			}
			finally
			{
				binaryReader?.Close();
				fileStream?.Close();
			}
			GC.KeepAlive(this);
			return FileLoaded;
		}
		GC.KeepAlive(this);
		return false;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Load(string fn, int gshop_index)
	{
		return Load(fn, PW_GSHOP_VERSION.AUTO, gshop_index);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Load(string fn)
	{
		return Load(fn, PW_GSHOP_VERSION.AUTO, 0);
	}

	public void DetectVersion_PW(BinaryReader br)
	{
		if (IsExported)
		{
			return;
		}
		if (ItemsCount != 0)
		{
			if (TryToReadItems(CommonStorage.AParams.PWGShopDefaultVersion, br))
			{
				GC.KeepAlive(this);
				return;
			}
			List<PW_GSHOP_VERSION> list = new List<PW_GSHOP_VERSION>(new PW_GSHOP_VERSION[12]
			{
				PW_GSHOP_VERSION.PW_1_5_5_v156,
				PW_GSHOP_VERSION.PW_1_5_3,
				PW_GSHOP_VERSION.PW_1_4_4,
				PW_GSHOP_VERSION.PW_1_2_6,
				PW_GSHOP_VERSION.PW_1_4_2_v29,
				PW_GSHOP_VERSION.PW_1_4_2_v29,
				PW_GSHOP_VERSION.PW_1_4_2_v27,
				PW_GSHOP_VERSION.PW_1_5_5_v181,
				PW_GSHOP_VERSION.PW_1_6_0,
				PW_GSHOP_VERSION.PW_1_7_6,
				PW_GSHOP_VERSION.PW_1_8_3,
				PW_GSHOP_VERSION.PW_1_8_6
			});
			list.Remove(CommonStorage.AParams.PWGShopDefaultVersion);
			if (FileName.EndsWith(Class16.smethod_0(1648909735)) || FileName.EndsWith(Class16.smethod_0(1648909745)))
			{
				list.Insert(0, PW_GSHOP_VERSION.PW_1_5_5_v156);
				list.Insert(1, PW_GSHOP_VERSION.PW_1_5_5_v181);
				list.Insert(2, PW_GSHOP_VERSION.PW_1_6_0);
				list.Insert(3, PW_GSHOP_VERSION.PW_1_7_6);
				list.Insert(4, PW_GSHOP_VERSION.PW_1_8_3);
				list.Insert(5, PW_GSHOP_VERSION.PW_1_8_6);
				list = new List<PW_GSHOP_VERSION>(new HashSet<PW_GSHOP_VERSION>(list));
			}
			List<PW_GSHOP_VERSION>.Enumerator enumerator = list.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					PW_GSHOP_VERSION current = enumerator.Current;
					if (TryToReadItems(current, br))
					{
						GC.KeepAlive(this);
						return;
					}
				}
				while (enumerator.MoveNext());
			}
		}
		VersionPW = CommonStorage.AParams.PWGShopDefaultVersion;
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryToReadItems(PW_GSHOP_VERSION ver, BinaryReader br)
	{
		VersionPW = ver;
		long position = br.BaseStream.Position;
		uint itemsCount = ItemsCount;
		uint num = ((100 < itemsCount) ? 100u : itemsCount);
		uint num2 = 0u;
		try
		{
			bool result;
			try
			{
				uint num3 = 0u;
				while (true)
				{
					if (num3 < num)
					{
						GSHOP_ITEM_PW gSHOP_ITEM_PW = ReadItem_PW(br, VersionPW);
						if (gSHOP_ITEM_PW.CatIndex <= 9999 && gSHOP_ITEM_PW.SubCatIndex <= 9999 && Math.Abs(gSHOP_ITEM_PW.BuyTimesLimitMode) <= 10)
						{
							int itemID = gSHOP_ITEM_PW.ItemID;
							if (itemID > 0 && itemID <= 1000000)
							{
								goto IL_0080;
							}
						}
						num2++;
						goto IL_0080;
					}
					if (!IsExported)
					{
						ReadCategories_PW(br);
					}
					return true;
					IL_0080:
					uint num4 = ((num < 2) ? num : 2u);
					if (num2 >= num4)
					{
						break;
					}
					num3++;
				}
				br.BaseStream.Position = position;
				return false;
			}
			catch (EndOfStreamException)
			{
				result = false;
			}
			catch (IOException)
			{
				result = false;
			}
			catch (InvalidDataException)
			{
				result = false;
			}
			catch (Exception ex4)
			{
				SentryHelper.CaptureException(ex4, Class16.smethod_0(1649070672));
				Console.WriteLine(ex4.Message);
				result = false;
			}
			return result;
		}
		finally
		{
			br.BaseStream.Position = position;
		}
	}

	public void DetectGame(BinaryReader br)
	{
		switch (br.ReadInt32())
		{
		default:
			if (br.ReadUInt32() < 50000)
			{
				Game = GAMES.PW;
			}
			else
			{
				Game = GAMES.FW;
			}
			br.BaseStream.Position = 0L;
			break;
		case 2:
			switch (Game = (GAMES)br.ReadInt32())
			{
			case GAMES.FW:
				Version = br.ReadInt32();
				break;
			case GAMES.PW:
				VersionPW = (PW_GSHOP_VERSION)br.ReadInt32();
				break;
			}
			IsExported = true;
			break;
		case 1:
			Game = GAMES.PW;
			IsExported = true;
			break;
		}
		GC.KeepAlive(this);
	}

	private static string CreateSiblingTemporaryFileName(string destinationFileName)
	{
		string fullPath = System.IO.Path.GetFullPath(destinationFileName);
		return System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fullPath), System.IO.Path.GetFileName(fullPath) + "." + Guid.NewGuid().ToString("N") + ".tmp");
	}

	private static void CommitSiblingTemporaryFile(string temporaryFileName, string destinationFileName)
	{
		if (File.Exists(destinationFileName))
		{
			File.Replace(temporaryFileName, destinationFileName, null);
		}
		else
		{
			File.Move(temporaryFileName, destinationFileName);
		}
	}

	private void ValidateGshopHeader(string fileName, int expectedItemCount)
	{
		using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
		using (BinaryReader reader = new BinaryReader(stream))
		{
			if (Game == GAMES.FW)
			{
				if (reader.ReadInt32() != Stamp1 || reader.ReadInt32() != Stamp2 || reader.ReadUInt32() != TimeStamp || reader.ReadInt32() != Version)
				{
					throw new InvalidDataException("O cabeçalho FW do GShop temporário está inconsistente.");
				}
			}
			else if (Game == GAMES.PW)
			{
				if (reader.ReadUInt32() != TimeStamp)
				{
					throw new InvalidDataException("O cabeçalho PW do GShop temporário está inconsistente.");
				}
			}
			else
			{
				throw new InvalidDataException("O tipo de jogo do GShop não é reconhecido.");
			}

			if (reader.ReadInt32() != expectedItemCount || stream.Length < stream.Position)
			{
				throw new InvalidDataException("A contagem de itens do GShop temporário está inconsistente.");
			}
		}
	}

	private static void DeleteTemporaryFile(string temporaryFileName)
	{
		if (!string.IsNullOrEmpty(temporaryFileName) && File.Exists(temporaryFileName))
		{
			File.Delete(temporaryFileName);
		}
	}

	public void Save(string FileName, PW_GSHOP_VERSION ToVersion)
	{
		EditorSessionTracker.LogFolderAccess(FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1648906382));
		CStorage.CreateBackup(FileName);
		string fullPath = System.IO.Path.GetFullPath(FileName);
		string temporaryFileName = CreateSiblingTemporaryFileName(fullPath);
		try
		{
			using (FileStream fileStream = new FileStream(temporaryFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				switch (Game)
				{
				case GAMES.FW:
					binaryWriter.Write(Stamp1);
					binaryWriter.Write(Stamp2);
					binaryWriter.Write(TimeStamp);
					binaryWriter.Write(Version);
					break;
				case GAMES.PW:
					binaryWriter.Write(TimeStamp);
					break;
				default:
					throw new InvalidDataException("O tipo de jogo do GShop não é reconhecido.");
				}
				binaryWriter.Write(Items.Length);
				switch (Game)
				{
				case GAMES.FW:
					WriteItems_FW(binaryWriter);
					break;
				case GAMES.PW:
					for (int i = 0; i < Items.Length; i++)
					{
						WriteItem_PW(binaryWriter, (GSHOP_ITEM_PW)Items[i], ToVersion);
					}
					WriteCategories_PW(binaryWriter);
					break;
				}
				if (BytesAfterEndOfFile != null)
				{
					binaryWriter.Write(BytesAfterEndOfFile);
				}
				binaryWriter.Flush();
				fileStream.Flush(true);
			}

			ValidateGshopHeader(temporaryFileName, Items.Length);
			CommitSiblingTemporaryFile(temporaryFileName, fullPath);
			GC.KeepAlive(this);
		}
		catch
		{
			try
			{
				DeleteTemporaryFile(temporaryFileName);
			}
			catch
			{
			}
			throw;
		}
	}

	public void Save()
	{
		Save(FileName, VersionPW);
	}

	public string GetSevName()
	{
		string fileBaseName = ACE.RSGlobal.RSGlobal.GetFileBaseName(FileName);
		string result;
		if (fileBaseName.Length > 0 && ACE.RSGlobal.RSGlobal.IsUIntFast(fileBaseName.Substring(fileBaseName.Length - 1)))
		{
			string text = Class16.smethod_0(1648909430);
			int startIndex = fileBaseName.Length - 1;
			string text2 = Class16.smethod_0(1649070699);
			result = string.Concat(string.Concat(ACE.RSGlobal.RSGlobal.GetFileDir(FileName) + text2, fileBaseName.Substring(startIndex)), text);
		}
		else
		{
			string text3 = Class16.smethod_0(1648909763);
			result = ACE.RSGlobal.RSGlobal.GetFileDir(FileName) + text3;
		}
		GC.KeepAlive(this);
		return result;
	}

	public string SaveToSev(string fn_sev)
	{
		if (string.IsNullOrWhiteSpace(fn_sev))
		{
			fn_sev = GetSevName();
		}
		EditorSessionTracker.LogFolderAccess(fn_sev, Class16.smethod_0(1649006856), Class16.smethod_0(1648906382));
		CStorage.CreateBackup(fn_sev);
		string fullPath = System.IO.Path.GetFullPath(fn_sev);
		string temporaryFileName = CreateSiblingTemporaryFileName(fullPath);
		try
		{
			using (FileStream fileStream = new FileStream(temporaryFileName, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
			{
				binaryWriter.Write(TimeStamp);
				binaryWriter.Write(Items.Length);
				WriteItems_PW_Sev(binaryWriter);
				binaryWriter.Flush();
				fileStream.Flush(true);
			}
			using (FileStream stream = new FileStream(temporaryFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
			using (BinaryReader reader = new BinaryReader(stream))
			{
				if (reader.ReadUInt32() != TimeStamp || reader.ReadInt32() != Items.Length || stream.Length < stream.Position)
				{
					throw new InvalidDataException("O cabeçalho do arquivo SEV temporário está inconsistente.");
				}
			}
			CommitSiblingTemporaryFile(temporaryFileName, fullPath);
			GC.KeepAlive(this);
			return fn_sev;
		}
		catch
		{
			try
			{
				DeleteTemporaryFile(temporaryFileName);
			}
			catch
			{
			}
			throw;
		}
	}

	public void ReadCategories_PW(BinaryReader br)
	{
		Categories = new Category[8];
		int num = 0;
		do
		{
			Categories[num] = new Category();
			if (br.BaseStream.Position + 128L <= br.BaseStream.Length)
			{
				Categories[num].name = Class5.smethod_1(Encoding.Unicode.GetString(br.ReadBytes(128)).TrimEnd(default(char)).Split(new string[1] { Class16.smethod_0(1648938185) }, StringSplitOptions.RemoveEmptyEntries));
				if (Categories[num].name == null)
				{
					Categories[num].name = string.Empty;
				}
				if (br.BaseStream.Position + 4L > br.BaseStream.Length)
				{
					Categories[num].SubCatsCount = 0u;
					Categories[num].SubCats = new string[0];
					num++;
					continue;
				}
				Categories[num].SubCatsCount = br.ReadUInt32();
				Category category = Categories[num];
				if (category.SubCatsCount > 999)
				{
					category.SubCatsCount = 0u;
				}
				Category category2 = Categories[num];
				category2.SubCats = new string[category2.SubCatsCount];
				int num2 = 0;
				if (0 < (int)Categories[num].SubCatsCount)
				{
					do
					{
						if (br.BaseStream.Position + 128L <= br.BaseStream.Length)
						{
							Categories[num].SubCats[num2] = Class5.smethod_1(Encoding.Unicode.GetString(br.ReadBytes(128)).Split(new string[1] { Class16.smethod_0(1648938185) }, StringSplitOptions.RemoveEmptyEntries));
							if (Categories[num].SubCats[num2] == null)
							{
								Categories[num].SubCats[num2] = string.Empty;
							}
							num2++;
							continue;
						}
						for (int i = num2; i < Categories[num].SubCatsCount; i++)
						{
							Categories[num].SubCats[i] = string.Empty;
						}
						break;
					}
					while (num2 < (int)Categories[num].SubCatsCount);
				}
				num++;
			}
			else
			{
				Categories[num].name = string.Empty;
				Categories[num].SubCatsCount = 0u;
				Categories[num].SubCats = new string[0];
				num++;
			}
		}
		while (num < 8);
		GC.KeepAlive(this);
	}

	public void WriteCategories_PW(BinaryWriter bw)
	{
		if (Categories == null || Categories.Length != 8)
		{
			Categories = new Category[8];
		}
		for (int i = 0; i < 8; i++)
		{
			if (Categories[i] == null)
			{
				Categories[i] = new Category();
				Categories[i].name = string.Empty;
				Categories[i].SubCats = new string[0];
			}
			else if (Categories[i].SubCats == null)
			{
				Categories[i].SubCats = new string[0];
			}
		}
		int num = 0;
		Category[] categories = Categories;
		do
		{
			bw.Write(GetBytes(Categories[num].name, 128, Encoding.Unicode));
			bw.Write((uint)Categories[num].SubCats.Length);
			int num2 = 0;
			categories = Categories;
			string[] subCats = categories[num].SubCats;
			if (0 < (nint)subCats.LongLength)
			{
				do
				{
					bw.Write(subCats[num2].GetBytesFromString(128, Encoding.Unicode));
					num2++;
					categories = Categories;
					subCats = categories[num].SubCats;
				}
				while (num2 < (nint)subCats.LongLength);
			}
			num++;
		}
		while (num < 8);
		GC.KeepAlive(this);
	}

	public byte[] GetBytes(string str, int int_0, Encoding encoding_0)
	{
		str = str.Split(default(char))[0];
		byte[] array = new byte[int_0];
		if (encoding_0.GetByteCount(str) > int_0)
		{
			Array.Copy(encoding_0.GetBytes(str), 0, array, 0, int_0);
		}
		else
		{
			Array.Copy(encoding_0.GetBytes(str), array, encoding_0.GetByteCount(str));
		}
		return array;
	}

	public void WriteItems_FW(BinaryWriter bw)
	{
		int num = 0;
		GSHOP_ITEM[] items = Items;
		if (0 < (nint)items.LongLength)
		{
			do
			{
				GSHOP_ITEM_FW gSHOP_ITEM_FW = (GSHOP_ITEM_FW)items[num];
				WriteItem_FW(bw, gSHOP_ITEM_FW, gSHOP_ITEM_FW.ID, Version);
				num++;
				items = Items;
			}
			while (num < (nint)items.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void AddNewItem(int ItemID)
	{
		Array.Resize(ref Items, (int)((nint)Items.LongLength + 1));
		int num = (int)((nint)Items.LongLength - 1);
		switch (Game)
		{
		case GAMES.FW:
			Items[num] = ((GSHOP_ITEM_FW)EmptyItem).Clone();
			break;
		case GAMES.PW:
			Items[num] = ((GSHOP_ITEM_PW)EmptyItem).Clone();
			break;
		}
		Items[num].ID = GetUniqueID();
		Items[num].ItemID = ItemID;
	}

	public void AddItem(GSHOP_ITEM Item)
	{
		Item.ID = GetUniqueID();
		Array.Resize(ref Items, (int)((nint)Items.LongLength + 1));
		GSHOP_ITEM[] items = Items;
		items[(nint)items.LongLength - 1] = Item;
		if (Game != GAMES.PW)
		{
			return;
		}
		GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)Item;
		if (gSHOP_ITEM_PW.SaleOptions == null)
		{
			gSHOP_ITEM_PW.SaleOptions = new SALE_OPTION[4];
			for (int i = 0; i < 4; i++)
			{
				gSHOP_ITEM_PW.SaleOptions[i] = new SALE_OPTION();
			}
		}
		else
		{
			for (int j = 0; j < gSHOP_ITEM_PW.SaleOptions.Length && j < 4; j++)
			{
				if (gSHOP_ITEM_PW.SaleOptions[j] == null)
				{
					gSHOP_ITEM_PW.SaleOptions[j] = new SALE_OPTION();
				}
			}
		}
		if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_3 && (gSHOP_ITEM_PW.owner_npcs == null || gSHOP_ITEM_PW.owner_npcs.Length != 8))
		{
			gSHOP_ITEM_PW.owner_npcs = new int[8];
		}
	}

	private static void smethod_0(BinaryReader binaryReader_0, int int_0, string string_0)
	{
		if (int_0 < 0)
		{
			throw new InvalidDataException(string.Format(Class16.smethod_0(1648921204), string_0, int_0));
		}
		long num = binaryReader_0.BaseStream.Length - binaryReader_0.BaseStream.Position;
		if (num < int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921238), string_0, int_0, num));
		}
	}

	private static byte[] smethod_1(BinaryReader binaryReader_0, int int_0, string string_0)
	{
		smethod_0(binaryReader_0, int_0, string_0);
		byte[] array = binaryReader_0.ReadBytes(int_0);
		if (array.Length != int_0)
		{
			throw new EndOfStreamException(string.Format(Class16.smethod_0(1648921300), string_0, int_0, array.Length));
		}
		return array;
	}

	public GSHOP_ITEM AddItem(int SourceIndex)
	{
		Array.Resize(ref Items, (int)((nint)Items.LongLength + 1));
		GSHOP_ITEM[] items = Items;
		ref GSHOP_ITEM reference = ref items[(nint)items.LongLength - 1];
		switch (Game)
		{
		case GAMES.FW:
			reference = ((GSHOP_ITEM_FW)items[SourceIndex]).Clone();
			break;
		case GAMES.PW:
			reference = ((GSHOP_ITEM_PW)items[SourceIndex]).Clone();
			break;
		}
		reference.ID = GetUniqueID();
		return reference;
	}

	public int DeleteItem(int Index)
	{
		GSHOP_ITEM[] items = Items;
		int iD = items[Index].ID;
		GSHOP_ITEM[] array = new GSHOP_ITEM[(nint)items.LongLength - 1];
		Array.Copy(items, 0, array, 0, Index);
		GSHOP_ITEM[] items2 = Items;
		Array.Copy(items2, Index + 1, array, Index, (int)((nint)items2.LongLength - Index - 1));
		Items = array;
		return iD;
	}

	public void ReadItems_FW(BinaryReader br)
	{
		uint num = 0u;
		if (0 >= ItemsCount)
		{
			return;
		}
		do
		{
			try
			{
				GSHOP_ITEM_FW gSHOP_ITEM_FW = new GSHOP_ITEM_FW();
				gSHOP_ITEM_FW.ID = br.ReadInt32();
				gSHOP_ITEM_FW.name = Encoding.Unicode.GetString(smethod_1(br, 64, string.Format(Class16.smethod_0(1649070714), num))).Split(default(char))[0];
				gSHOP_ITEM_FW.FileIcon = br.ReadInt32();
				gSHOP_ITEM_FW.ItemID = br.ReadInt32();
				gSHOP_ITEM_FW.Count = br.ReadInt32();
				gSHOP_ITEM_FW.IsHide = br.ReadUInt32();
				gSHOP_ITEM_FW.CanGetConsumeScore = br.ReadUInt32();
				if (Version > 184)
				{
					gSHOP_ITEM_FW.uint_0 = (uint)br.ReadInt32();
				}
				gSHOP_ITEM_FW.GiftID = br.ReadInt32();
				gSHOP_ITEM_FW.GiftRate = br.ReadSingle();
				gSHOP_ITEM_FW.BuyTypeMask = br.ReadUInt32();
				gSHOP_ITEM_FW.price = br.ReadInt32();
				gSHOP_ITEM_FW.ExpireDate = br.ReadUInt32();
				gSHOP_ITEM_FW.ext_search = smethod_1(br, 32, string.Format(Class16.smethod_0(1649070751), num));
				gSHOP_ITEM_FW.NewItemIndex = br.ReadUInt32();
				gSHOP_ITEM_FW.SellBeginTime = br.ReadUInt32();
				gSHOP_ITEM_FW.SellEndTime = br.ReadUInt32();
				gSHOP_ITEM_FW.DiscountBeginTime = br.ReadUInt32();
				gSHOP_ITEM_FW.DiscountEndTime = br.ReadUInt32();
				gSHOP_ITEM_FW.DiscountPrice = br.ReadInt32();
				gSHOP_ITEM_FW.LogoIcon = br.ReadInt32();
				gSHOP_ITEM_FW.PreviewBackgroundPic = br.ReadInt32();
				gSHOP_ITEM_FW.PreviewPriority = br.ReadInt32();
				gSHOP_ITEM_FW.DiscountItemShowIndex = br.ReadUInt32();
				gSHOP_ITEM_FW.PriorityPreviewModel = br.ReadInt32();
				if (Version >= 192)
				{
					gSHOP_ITEM_FW.LimitTimesTaskId = (uint)br.ReadInt32();
				}
				Items[num] = gSHOP_ITEM_FW;
			}
			catch (EndOfStreamException ex)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649070778), num, ex.Message), ex);
			}
			catch (InvalidDataException ex2)
			{
				throw new InvalidDataException(string.Format(Class16.smethod_0(1649070850), num, ex2.Message), ex2);
			}
			num++;
		}
		while (num < ItemsCount);
	}

	public void ReadItems_PW(BinaryReader br)
	{
		uint num = 0u;
		if (0 >= ItemsCount)
		{
			return;
		}
		do
		{
			try
			{
				Items[num] = ReadItem_PW(br, VersionPW);
			}
			catch (EndOfStreamException ex)
			{
				throw new EndOfStreamException(string.Format(Class16.smethod_0(1649070915), num, ex.Message), ex);
			}
			catch (InvalidDataException ex2)
			{
				throw new InvalidDataException(string.Format(Class16.smethod_0(1649070987), num, ex2.Message), ex2);
			}
			num++;
		}
		while (num < ItemsCount);
	}

	public void WriteItems_PW_Sev(BinaryWriter binaryWriter_0)
	{
		int num = 0;
		GSHOP_ITEM[] items = Items;
		if (0 < (nint)items.LongLength)
		{
			do
			{
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)items[num];
				binaryWriter_0.Write(num);
				binaryWriter_0.Write(gSHOP_ITEM_PW.CatIndex);
				binaryWriter_0.Write(gSHOP_ITEM_PW.SubCatIndex);
				binaryWriter_0.Write(gSHOP_ITEM_PW.ItemID);
				binaryWriter_0.Write(gSHOP_ITEM_PW.Count);
				int num2 = 0;
				do
				{
					if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156)
					{
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Price);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].ExpireDate);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Duration);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].StartDate);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].ControlType);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Day);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Status);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Flags);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].MinVipLevel);
					}
					else
					{
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Price);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].ExpireDate);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Duration);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].StartDate);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].ControlType);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Day);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Status);
						binaryWriter_0.Write(gSHOP_ITEM_PW.SaleOptions[num2].Flags);
					}
					num2++;
				}
				while (num2 < 4);
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_4_4)
				{
					binaryWriter_0.Write(gSHOP_ITEM_PW.GiftID);
					binaryWriter_0.Write(gSHOP_ITEM_PW.GiftCount);
					binaryWriter_0.Write(gSHOP_ITEM_PW.GiftDuration);
					binaryWriter_0.Write(gSHOP_ITEM_PW.LogPrice);
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_3)
				{
					if (gSHOP_ITEM_PW.owner_npcs == null)
					{
						gSHOP_ITEM_PW.owner_npcs = new int[8];
					}
					int num3 = 0;
					do
					{
						binaryWriter_0.Write(gSHOP_ITEM_PW.owner_npcs[num3]);
						num3++;
					}
					while (num3 < 8);
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v156)
				{
					binaryWriter_0.Write(gSHOP_ITEM_PW.BuyTimesLimit);
					binaryWriter_0.Write(gSHOP_ITEM_PW.BuyTimesLimitMode);
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_6_0)
				{
					binaryWriter_0.Write(gSHOP_ITEM_PW.tasks_id);
					binaryWriter_0.Write(gSHOP_ITEM_PW.tasks_space);
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_5_5_v181)
				{
					binaryWriter_0.Write(gSHOP_ITEM_PW.Occupation);
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_7_6)
				{
					binaryWriter_0.Write(gSHOP_ITEM_PW.reserved1);
					binaryWriter_0.Write(gSHOP_ITEM_PW.reserved2);
					binaryWriter_0.Write(gSHOP_ITEM_PW.reserved3);
					binaryWriter_0.Write(gSHOP_ITEM_PW.reserved4);
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_3)
				{
					binaryWriter_0.Write(gSHOP_ITEM_PW.special_server_forbid);
					binaryWriter_0.Write(gSHOP_ITEM_PW.in_green_shop);
					if (VersionPW == PW_GSHOP_VERSION.PW_1_8_3)
					{
						binaryWriter_0.Write(gSHOP_ITEM_PW.unk184);
					}
				}
				if (VersionPW >= PW_GSHOP_VERSION.PW_1_8_6)
				{
					binaryWriter_0.Write(gSHOP_ITEM_PW.add_trade_time);
					binaryWriter_0.Write(gSHOP_ITEM_PW.reserved6);
				}
				num++;
				items = Items;
			}
			while (num < (nint)items.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void SetIdsFromIndexes()
	{
		int num = 0;
		GSHOP_ITEM[] items = Items;
		if (0 < (nint)items.LongLength)
		{
			do
			{
				items[num].ID = num;
				num++;
				items = Items;
			}
			while (num < (nint)items.LongLength);
		}
	}

	public int GetUniqueID()
	{
		HashSet<int> hashSet = new HashSet<int>(Items.Length);
		int num = 0;
		GSHOP_ITEM[] items = Items;
		if (0 < (nint)items.LongLength)
		{
			do
			{
				hashSet.Add(items[num].ID);
				num++;
				items = Items;
			}
			while (num < (nint)items.LongLength);
		}
		int num2 = (int)((nint)Items.LongLength - 1);
		if (hashSet.Contains(num2))
		{
			do
			{
				num2++;
			}
			while (hashSet.Contains(num2));
		}
		GC.KeepAlive(this);
		return num2;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFreeID(int id)
	{
		int num = 0;
		GSHOP_ITEM[] items = Items;
		int num2 = items.Length;
		if (0 < num2)
		{
			do
			{
				if (id != items[num].ID)
				{
					num++;
					continue;
				}
				return false;
			}
			while (num < num2);
		}
		return true;
	}

	public string GetItemCategory(GSHOP_ITEM_PW Item)
	{
		string text = Class16.smethod_0(1649071060);
		string text2 = text;
		string text3 = text;
		Category[] categories = Categories;
		uint catIndex = Item.CatIndex;
		if ((nuint)(int)catIndex < (nuint)categories.LongLength)
		{
			text2 = categories[catIndex].name;
			string[] subCats = Categories[Item.CatIndex].SubCats;
			uint subCatIndex = Item.SubCatIndex;
			if ((nuint)(int)subCatIndex < (nuint)subCats.LongLength)
			{
				text3 = subCats[subCatIndex];
			}
		}
		string result = string.Concat(text2 + Class16.smethod_0(1649078775), text3);
		GC.KeepAlive(this);
		return result;
	}

	public string GetItemCategory(int Index)
	{
		if (Game == GAMES.FW)
		{
			return Class16.smethod_0(1649071077);
		}
		return GetItemCategory((GSHOP_ITEM_PW)Items[Index]);
	}

	public void DeleteSubCat(uint CatIndex, uint SubCatIndex)
	{
		Categories[CatIndex].SubCats = ACE.RSGlobal.RSGlobal.RemoveArrayElement(Categories[CatIndex].SubCats, (int)SubCatIndex);
		Categories[CatIndex].SubCatsCount--;
		int num = 0;
		GSHOP_ITEM[] items = Items;
		if (0 >= (nint)items.LongLength)
		{
			return;
		}
		do
		{
			GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)items[num];
			if (gSHOP_ITEM_PW.CatIndex == CatIndex)
			{
				uint subCatIndex = gSHOP_ITEM_PW.SubCatIndex;
				if (subCatIndex > SubCatIndex)
				{
					gSHOP_ITEM_PW.SubCatIndex = subCatIndex - 1;
				}
			}
			num++;
			items = Items;
		}
		while (num < (nint)items.LongLength);
	}

	public void ExchangeSubCats(uint Cat1, uint SubCat1, uint Cat2, uint SubCat2, [MarshalAs(UnmanagedType.U1)] bool IsExchange)
	{
		if (IsExchange)
		{
			Category[] categories = Categories;
			string[] subCats = categories[Cat1].SubCats;
			string text = subCats[SubCat1];
			subCats[SubCat1] = categories[Cat2].SubCats[SubCat2];
			Categories[Cat2].SubCats[SubCat2] = text;
			int num = 0;
			GSHOP_ITEM[] items = Items;
			if (0 >= (nint)items.LongLength)
			{
				return;
			}
			do
			{
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)items[num];
				uint catIndex = gSHOP_ITEM_PW.CatIndex;
				if (catIndex != Cat1 || gSHOP_ITEM_PW.SubCatIndex != SubCat1)
				{
					if (catIndex == Cat2 && gSHOP_ITEM_PW.SubCatIndex == SubCat2)
					{
						gSHOP_ITEM_PW.CatIndex = Cat1;
						gSHOP_ITEM_PW.SubCatIndex = SubCat1;
					}
				}
				else
				{
					gSHOP_ITEM_PW.CatIndex = Cat2;
					gSHOP_ITEM_PW.SubCatIndex = SubCat2;
				}
				num++;
				items = Items;
			}
			while (num < (nint)items.LongLength);
			return;
		}
		Category[] categories2 = Categories;
		categories2[Cat2].SubCats[SubCat2] = categories2[Cat1].SubCats[SubCat1];
		int num2 = 0;
		GSHOP_ITEM[] items2 = Items;
		if (0 < (nint)items2.LongLength)
		{
			do
			{
				GSHOP_ITEM_PW gSHOP_ITEM_PW2 = (GSHOP_ITEM_PW)items2[num2];
				if (gSHOP_ITEM_PW2.CatIndex == Cat1 && gSHOP_ITEM_PW2.SubCatIndex == SubCat1)
				{
					gSHOP_ITEM_PW2.CatIndex = Cat2;
					gSHOP_ITEM_PW2.SubCatIndex = SubCat2;
				}
				num2++;
				items2 = Items;
			}
			while (num2 < (nint)items2.LongLength);
		}
		DeleteSubCat(Cat1, SubCat1);
	}

	public void ExchangeCats(uint Cat1, uint Cat2)
	{
		Category[] categories = Categories;
		Category category = categories[Cat1];
		categories[Cat1] = categories[Cat2];
		Categories[Cat2] = category;
		int num = 0;
		GSHOP_ITEM[] items = Items;
		if (0 >= (nint)items.LongLength)
		{
			return;
		}
		do
		{
			GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)items[num];
			uint catIndex = gSHOP_ITEM_PW.CatIndex;
			if (catIndex == Cat1)
			{
				gSHOP_ITEM_PW.CatIndex = Cat2;
			}
			else if (catIndex == Cat2)
			{
				gSHOP_ITEM_PW.CatIndex = Cat1;
			}
			num++;
			items = Items;
		}
		while (num < (nint)items.LongLength);
	}

	public int GetCatItemsCount(uint CatIndex, uint SubCatIndex)
	{
		if (CatIndex == uint.MaxValue)
		{
			return Items.Length;
		}
		int num = 0;
		int num2 = 0;
		GSHOP_ITEM[] items = Items;
		int num3 = items.Length;
		if (0 < num3)
		{
			do
			{
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)items[num2];
				if (gSHOP_ITEM_PW.CatIndex == CatIndex && (gSHOP_ITEM_PW.SubCatIndex == SubCatIndex || SubCatIndex == uint.MaxValue))
				{
					num++;
				}
				num2++;
			}
			while (num2 < num3);
		}
		return num;
	}

	public int[] MoveItemsToFirstPlace(int[] ItemsIndicies, int FirstItemIndex)
	{
		int num = 0;
		if (0 < (nint)ItemsIndicies.LongLength)
		{
			do
			{
				int num2 = ItemsIndicies[num];
				if (num2 > FirstItemIndex + num)
				{
					int num3 = num2 - 1;
					do
					{
						GSHOP_ITEM[] items = Items;
						GSHOP_ITEM gSHOP_ITEM = items[num2];
						items[num2] = items[num3];
						Items[num3] = gSHOP_ITEM;
						num2--;
						num3--;
					}
					while (num2 > FirstItemIndex + num);
				}
				num++;
			}
			while (num < (nint)ItemsIndicies.LongLength);
		}
		int endval = (int)((nint)ItemsIndicies.LongLength - 1);
		int[] result = ACE.RSGlobal.RSGlobal.IntArray(0, endval, 1);
		GC.KeepAlive(this);
		return result;
	}

	public void MoveItemsToLastPlace(int[] ItemsIndices, int LastItemIndex)
	{
		Array.Reverse(ItemsIndices);
		int num = 0;
		if (0 >= (nint)ItemsIndices.LongLength)
		{
			return;
		}
		int num2 = LastItemIndex;
		do
		{
			int num3 = ItemsIndices[num];
			if (num3 < num2)
			{
				int num4 = num3 + 1;
				do
				{
					GSHOP_ITEM[] items = Items;
					GSHOP_ITEM gSHOP_ITEM = items[num3];
					items[num3] = items[num4];
					Items[num4] = gSHOP_ITEM;
					num3++;
					num4++;
				}
				while (num3 < num2);
			}
			num++;
			num2--;
		}
		while (num < (nint)ItemsIndices.LongLength);
	}

	public int[] MoveItems(int[] SelectedRowsIndicies, int PosOffset, DataGridViewRowCollection Rows)
	{
		int[] array = ACE.RSGlobal.RSGlobal.CloneArray(SelectedRowsIndicies);
		List<int> list = new List<int>(array.Length);
		int num = Math.Sign(PosOffset);
		if (num == 1)
		{
			Array.Reverse(array);
		}
		int num2 = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				int num3 = array[num2];
				int num4 = (int)Rows[num3].Tag;
				int num5 = 0;
				if (0 < Math.Abs(PosOffset))
				{
					int num6 = num3 + num;
					do
					{
						int num7 = (int)Rows[num6].Tag;
						GSHOP_ITEM[] items = Items;
						GSHOP_ITEM gSHOP_ITEM = items[num4];
						items[num4] = items[num7];
						Items[num7] = gSHOP_ITEM;
						num4 = num7;
						num5++;
						num6 = num + num6;
					}
					while (num5 < Math.Abs(PosOffset));
				}
				list.Add(num4);
				num2++;
			}
			while (num2 < (nint)array.LongLength);
		}
		int[] array2 = list.ToArray();
		Array.Sort(array2);
		GC.KeepAlive(this);
		return array2;
	}

	public int GetItemPosInCat(int ItemIndex, int CatIndex, int SubCatIndex)
	{
		int num = 1;
		int num2 = 0;
		GSHOP_ITEM[] items = Items;
		int num3 = items.Length;
		if (0 < num3)
		{
			do
			{
				if (num2 != ItemIndex)
				{
					GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)items[num2];
					if (gSHOP_ITEM_PW.CatIndex == (uint)CatIndex && (SubCatIndex < 0 || gSHOP_ITEM_PW.SubCatIndex == (uint)SubCatIndex))
					{
						num++;
					}
					num2++;
					continue;
				}
				return num;
			}
			while (num2 < num3);
		}
		return num;
	}

	public void SortItemsByID()
	{
		int num = Items.Length;
		GSHOP_ITEM[] array = new GSHOP_ITEM[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				object obj = null;
				int num3 = 0;
				int num4 = 0;
				GSHOP_ITEM[] items = Items;
				int num5 = items.Length;
				if (0 < num5)
				{
					do
					{
						GSHOP_ITEM gSHOP_ITEM = items[num4];
						if (gSHOP_ITEM != null && (obj == null || gSHOP_ITEM.ID < (int)obj))
						{
							obj = gSHOP_ITEM.ID;
							num3 = num4;
						}
						num4++;
					}
					while (num4 < num5);
				}
				array[num2] = items[num3];
				Items[num3] = null;
				num2++;
			}
			while (num2 < (nint)Items.LongLength);
		}
		Items = array;
	}

	public void ReorderItems(int[] indices)
	{
		int num = Items.Length;
		GSHOP_ITEM[] array = new GSHOP_ITEM[num];
		int num2 = 0;
		int num3 = 0;
		if (0 < num)
		{
			do
			{
				if (indices == null || indices.Length == 0 || Array.IndexOf(indices, num3) <= -1)
				{
					array[num3] = Items[num3];
				}
				else
				{
					array[num3] = Items[indices[num2]];
					num2++;
				}
				num3++;
			}
			while (num3 < (nint)Items.LongLength);
		}
		Items = array;
	}

	public int ReplaceItemID(int oldid, int newid)
	{
		int num = 0;
		GSHOP_ITEM[] items = Items;
		int num2 = 0;
		if (0 < (nint)items.LongLength)
		{
			do
			{
				GSHOP_ITEM gSHOP_ITEM = items[num2];
				if (gSHOP_ITEM.ItemID == oldid)
				{
					gSHOP_ITEM.ItemID = newid;
					num++;
				}
				if (gSHOP_ITEM.GiftID == oldid)
				{
					gSHOP_ITEM.GiftID = newid;
					num++;
				}
				num2++;
			}
			while (num2 < (nint)items.LongLength);
			if (num > 0)
			{
				FileChanged = true;
			}
		}
		return num;
	}

	public int ReplaceNpcID(int oldid, int newid)
	{
		if (VersionPW < PW_GSHOP_VERSION.PW_1_5_3)
		{
			return 0;
		}
		int num = 0;
		GSHOP_ITEM[] items = Items;
		int num2 = 0;
		if (0 < (nint)items.LongLength)
		{
			do
			{
				GSHOP_ITEM_PW gSHOP_ITEM_PW = (GSHOP_ITEM_PW)items[num2];
				int num3 = 0;
				int[] owner_npcs = gSHOP_ITEM_PW.owner_npcs;
				if (0 < (nint)owner_npcs.LongLength)
				{
					do
					{
						if (owner_npcs[num3] == oldid)
						{
							owner_npcs[num3] = newid;
							num++;
						}
						num3++;
						owner_npcs = gSHOP_ITEM_PW.owner_npcs;
					}
					while (num3 < (nint)owner_npcs.LongLength);
				}
				num2++;
			}
			while (num2 < (nint)items.LongLength);
			if (num > 0)
			{
				FileChanged = true;
			}
		}
		return num;
	}

	public void UpdateReferences(ELEMENTS_REFERENCES References)
	{
		if (!FileLoaded || References == null || Items == null)
		{
			return;
		}
		int num = ((Game == GAMES.PW && VersionPW >= PW_GSHOP_VERSION.PW_1_5_3) ? 1 : 0);
		bool flag = (byte)num != 0;
		ReferenceType extraGshopTypePlus = ExtraGshopTypePlus;
		ReferenceType refType = extraGshopTypePlus + 3;
		ReferenceType refType2 = extraGshopTypePlus + 4;
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES = References.NewRefs(refType);
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES2 = References.NewRefs(refType2);
		int num2 = 0;
		GSHOP_ITEM[] items = Items;
		if (0 < (nint)items.LongLength)
		{
			INDICES indices = default(INDICES);
			REFERENCE_TYPE_EX refType3 = default(REFERENCE_TYPE_EX);
			INDICES ind = default(INDICES);
			INDICES ind2 = default(INDICES);
			INDICES ind3 = default(INDICES);
			do
			{
				GSHOP_ITEM gSHOP_ITEM = items[num2];
				if (gSHOP_ITEM != null)
				{
					string text = gSHOP_ITEM.sName ?? string.Empty;
					double num3 = 0.0;
					GSHOP_ITEM_PW gSHOP_ITEM_PW = null;
					switch (Game)
					{
					case GAMES.FW:
						if (gSHOP_ITEM is GSHOP_ITEM_FW gSHOP_ITEM_FW)
						{
							num3 = gSHOP_ITEM_FW.Price;
						}
						break;
					case GAMES.PW:
					{
						gSHOP_ITEM_PW = gSHOP_ITEM as GSHOP_ITEM_PW;
						if (gSHOP_ITEM_PW == null)
						{
							num2++;
							items = Items;
							continue;
						}
						num3 = gSHOP_ITEM_PW.Price;
						string itemCategory = GetItemCategory(gSHOP_ITEM_PW);
						string text2 = Class16.smethod_0(1648942897);
						text = string.Concat(text, string.Concat(Class16.smethod_0(1648899468) + itemCategory, text2));
						break;
					}
					}
					indices.int_0 = num2;
					object val = num3;
					GSHOP_ITEM gSHOP_ITEM2 = gSHOP_ITEM;
					object val2 = gSHOP_ITEM2.Count;
					int itemID = gSHOP_ITEM2.ItemID;
					refType3.DataFileType = eLEMENTS_IDS_REFERENCES.DataFileType;
					refType3.SectionType = eLEMENTS_IDS_REFERENCES.RefSectionType;
					refType3.SubType = ExtraGshopSubTypePlus + 3;
					REFERENCE_ENTRY entry = new REFERENCE_ENTRY(null, indices, null, num2, text, val2, val);
					eLEMENTS_IDS_REFERENCES.AddReference(refType3, itemID, entry);
					if (Game == GAMES.PW && gSHOP_ITEM_PW != null)
					{
						ind.int_0 = num2;
						eLEMENTS_IDS_REFERENCES.AddRef(ExtraGshopSubTypePlus + 4, null, ind, null, num2, text, gSHOP_ITEM.GiftID, gSHOP_ITEM_PW.GiftCount);
					}
					else
					{
						ind2.int_0 = num2;
						eLEMENTS_IDS_REFERENCES.AddRef(ExtraGshopSubTypePlus + 4, null, ind2, null, num2, text, gSHOP_ITEM.GiftID);
					}
					if (flag && gSHOP_ITEM_PW != null && gSHOP_ITEM_PW.owner_npcs != null)
					{
						int num4 = 0;
						int[] owner_npcs = gSHOP_ITEM_PW.owner_npcs;
						if (0 < (nint)owner_npcs.LongLength)
						{
							do
							{
								int num5 = owner_npcs[num4];
								if (num5 > 0)
								{
									ind3.int_0 = num2;
									ind3.int_1 = num4;
									eLEMENTS_IDS_REFERENCES2.AddRef(ExtraGshopSubTypePlus + 5, owner_npcs, ind3, null, num2, text, num5);
								}
								num4++;
								owner_npcs = gSHOP_ITEM_PW.owner_npcs;
							}
							while (num4 < (nint)owner_npcs.LongLength);
						}
					}
					num2++;
					items = Items;
				}
				else
				{
					num2++;
					items = Items;
				}
			}
			while (num2 < (nint)items.LongLength);
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ChangeValueFromReference(REFERENCE_TYPE_EX RefType, ref REFERENCE_ENTRY reference, int new_id, string val1, string val2, [MarshalAs(UnmanagedType.U1)] bool bRemove)
	{
		INDICES indices = reference.indices;
		GSHOP_ITEM gSHOP_ITEM = Items[indices.int_0];
		if (gSHOP_ITEM == null)
		{
			return false;
		}
		object obj = null;
		object obj2 = null;
		if (val1 != null)
		{
			obj = ACE.RSGlobal.RSGlobal.UIntParseFast(val1);
		}
		double result = 0.0;
		if (val2 != null)
		{
			if (!double.TryParse(val2, out result))
			{
				GC.KeepAlive(this);
				return false;
			}
			obj2 = result;
		}
		ReferenceSubType subType = RefType.SubType;
		if (subType != ReferenceSubType.GSHOP_GOODS)
		{
			if (subType != ReferenceSubType.GSHOP_GIFT)
			{
				if (subType == ReferenceSubType.GSHOP_NPC_OWNER)
				{
					((GSHOP_ITEM_PW)gSHOP_ITEM).owner_npcs[indices.int_1] = new_id;
				}
			}
			else
			{
				if (new_id > -1)
				{
					gSHOP_ITEM.GiftID = new_id;
				}
				if (obj == null)
				{
					goto IL_0105;
				}
				if (Game == GAMES.PW)
				{
					((GSHOP_ITEM_PW)gSHOP_ITEM).GiftCount = (int)obj;
				}
			}
		}
		else
		{
			if (new_id > -1)
			{
				gSHOP_ITEM.ItemID = new_id;
			}
			if (obj != null)
			{
				gSHOP_ITEM.Count = (int)obj;
			}
			if (val2 != null)
			{
				if (Game == GAMES.PW)
				{
					((GSHOP_ITEM_PW)gSHOP_ITEM).Price = result;
				}
				else
				{
					((GSHOP_ITEM_FW)gSHOP_ITEM).Price = ACE.RSGlobal.RSGlobal.UIntParseFast(val2);
				}
			}
		}
		if (obj != null)
		{
			reference.extra_value1 = obj;
		}
		goto IL_0105;
		IL_0105:
		if (obj2 != null)
		{
			reference.extra_value2 = obj2;
		}
		FileChanged = true;
		return true;
	}
}
