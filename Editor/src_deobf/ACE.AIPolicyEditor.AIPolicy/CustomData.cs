using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;
using ACE.Classes;
using ACE.Elements.eListCollection;
using LiteDB;
using Sentry;

namespace ACE.AIPolicyEditor.AIPolicy;

public class CustomData
{
	private sealed class Class23
	{
		public int int_0;

		internal bool method_0(CustomDataCollection customDataCollection_0)
		{
			return customDataCollection_0.ID == int_0;
		}
	}

	private sealed class Class24
	{
		public int int_0;

		internal bool method_0(CustomDataCollection customDataCollection_0)
		{
			return customDataCollection_0.ID == int_0;
		}
	}

	private sealed class Class25
	{
		public int int_0;

		internal bool method_0(CustomDataCollection customDataCollection_0)
		{
			return customDataCollection_0.ID == int_0;
		}
	}

	private sealed class Class26
	{
		public int int_0;

		internal bool method_0(CustomDataCollection customDataCollection_0)
		{
			return customDataCollection_0.ID == int_0;
		}
	}

	private sealed class Class27
	{
		public int int_0;

		internal bool method_0(CustomDataCollection customDataCollection_0)
		{
			return customDataCollection_0.ID == int_0;
		}
	}

	private static eListCollection eListCollection_0;

	private static readonly object object_0 = new object();

	private static LiteDatabase liteDatabase_0;

	private static bool bool_0;

	public static List<CustomDataCollection> Mines
	{
		get
		{
			LiteDatabase val = smethod_0();
			if (val != null && val.CollectionExists(Class16.smethod_0(1648936610)))
			{
				return val.GetCollection<CustomDataCollection>(Class16.smethod_0(1648936610), (BsonAutoId)10).FindAll().ToList();
			}
			return new List<CustomDataCollection>();
		}
	}

	public static List<CustomDataCollection> Mobs
	{
		get
		{
			LiteDatabase val = smethod_0();
			if (val != null && val.CollectionExists(Class16.smethod_0(1648936630)))
			{
				return val.GetCollection<CustomDataCollection>(Class16.smethod_0(1648936630), (BsonAutoId)10).FindAll().ToList();
			}
			return new List<CustomDataCollection>();
		}
	}

	public static List<CustomDataCollection> Npcs
	{
		get
		{
			LiteDatabase val = smethod_0();
			if (val != null && val.CollectionExists(Class16.smethod_0(1648936633)))
			{
				return val.GetCollection<CustomDataCollection>(Class16.smethod_0(1648936633), (BsonAutoId)10).FindAll().ToList();
			}
			return new List<CustomDataCollection>();
		}
	}

	public static List<CustomDataCollection> Skills
	{
		get
		{
			LiteDatabase val = smethod_0();
			if (val != null && val.CollectionExists(Class16.smethod_0(1648936652)))
			{
				return val.GetCollection<CustomDataCollection>(Class16.smethod_0(1648936652), (BsonAutoId)10).FindAll().ToList();
			}
			return new List<CustomDataCollection>();
		}
	}

	public CustomData(eListCollection eLC)
	{
		eListCollection_0 = eLC;
	}

	private static LiteDatabase smethod_0()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		lock (object_0)
		{
			if (liteDatabase_0 == null)
			{
				try
				{
					liteDatabase_0 = new LiteDatabase(new ConnectionString
					{
						Filename = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Class16.smethod_0(1648936514)),
						Connection = (ConnectionType)1
					}, (BsonMapper)null);
					return liteDatabase_0;
				}
				catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
				{
					if (!bool_0)
					{
						bool_0 = true;
						SentryHelper.CaptureMessage(Class16.smethod_0(1648936529) + ex.Message, (SentryLevel)2, Class16.smethod_0(1648936575));
					}
					return null;
				}
			}
			return liteDatabase_0;
		}
	}

	public static string GetMineDesc(int id)
	{
		Class26 @class = new Class26();
		@class.int_0 = id;
		List<CustomDataCollection> list = Mines.Where(@class.method_0).ToList();
		if (list.Count <= 0)
		{
			return Class16.smethod_0(1648936657);
		}
		return list.First().Desc;
	}

	public static string GetMineName(int id)
	{
		if (id <= 0)
		{
			return Class16.smethod_0(1648936686);
		}
		eListCollection eListCollection2 = eListCollection_0;
		if (eListCollection2 == null)
		{
			return Class16.smethod_0(1648936686);
		}
		ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.GetLists(ItemType.NpcOrMobOrMine), id);
		if (iTEMPOS == null)
		{
			return Class16.smethod_0(1648936686);
		}
		ITEMINFO itemInfo = eListCollection2.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		object obj;
		if (itemInfo == null)
		{
			obj = null;
		}
		else
		{
			obj = itemInfo.name;
			if (obj != null)
			{
				goto IL_006b;
			}
		}
		obj = Class16.smethod_0(1648936686);
		goto IL_006b;
		IL_006b:
		return (string)obj;
	}

	public static string GetMobDesc(int id)
	{
		Class23 @class = new Class23();
		@class.int_0 = id;
		List<CustomDataCollection> list = Mobs.Where(@class.method_0).ToList();
		if (list.Count <= 0)
		{
			return Class16.smethod_0(1648936657);
		}
		return list.First().Desc;
	}

	public static string GetMobName(int id)
	{
		if (id <= 0)
		{
			return Class16.smethod_0(1648936686);
		}
		eListCollection eListCollection2 = eListCollection_0;
		if (eListCollection2 == null)
		{
			return Class16.smethod_0(1648936686);
		}
		ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.GetLists(ItemType.NpcOrMobOrMine), id);
		if (iTEMPOS == null)
		{
			return Class16.smethod_0(1648936686);
		}
		ITEMINFO itemInfo = eListCollection2.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		object obj;
		if (itemInfo == null)
		{
			obj = null;
		}
		else
		{
			obj = itemInfo.name;
			if (obj != null)
			{
				goto IL_006b;
			}
		}
		obj = Class16.smethod_0(1648936686);
		goto IL_006b;
		IL_006b:
		return (string)obj;
	}

	public static string GetNpcDesc(int id)
	{
		Class25 @class = new Class25();
		@class.int_0 = id;
		List<CustomDataCollection> list = Npcs.Where(@class.method_0).ToList();
		if (list.Count <= 0)
		{
			return Class16.smethod_0(1648936657);
		}
		return list.First().Desc;
	}

	public static string GetNpcName(int id)
	{
		if (id <= 0)
		{
			return Class16.smethod_0(1648936686);
		}
		eListCollection eListCollection2 = eListCollection_0;
		if (eListCollection2 == null)
		{
			return Class16.smethod_0(1648936686);
		}
		ITEMPOS iTEMPOS = eListCollection2.FindItemPos(eListCollection2.GetLists(ItemType.NpcOrMobOrMine), id);
		if (iTEMPOS == null)
		{
			return Class16.smethod_0(1648936686);
		}
		ITEMINFO itemInfo = eListCollection2.GetItemInfo(iTEMPOS, bUseCache: true, bCheckIsFreeID: true, bCheckHasReferences: true);
		object obj;
		if (itemInfo == null)
		{
			obj = null;
		}
		else
		{
			obj = itemInfo.name;
			if (obj != null)
			{
				goto IL_006b;
			}
		}
		obj = Class16.smethod_0(1648936686);
		goto IL_006b;
		IL_006b:
		return (string)obj;
	}

	public static string GetSkillDesc(int id)
	{
		Class27 @class = new Class27();
		@class.int_0 = id;
		List<CustomDataCollection> list = Skills.Where(@class.method_0).ToList();
		if (list.Count <= 0)
		{
			return Class16.smethod_0(1648936657);
		}
		return list.First().Desc;
	}

	public static string GetSkillName(int id)
	{
		Class24 @class = new Class24();
		@class.int_0 = id;
		List<CustomDataCollection> list = Skills.Where(@class.method_0).ToList();
		if (list.Count <= 0)
		{
			return Class16.smethod_0(1648936686);
		}
		return list.First().Name;
	}

	public static void Init()
	{
	}
}
