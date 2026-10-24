#nullable enable annotations
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ExportedItemUsages
{
	private int int_0;

	private List<ExportedItemUsage.Elements>? list_0;

	private List<ExportedItemUsage.Shop>? list_1;

	private List<ExportedItemUsage.Shop>? list_2;

	private List<ExportedItemUsage.Shop>? list_3;

	private List<ExportedItemUsage.Npcgen>? list_4;

	private List<ExportedItemUsage.Tasks>? list_5;

	private List<ExportedItemUsage.ExtraDrops>? list_6;

	public int totalCount
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

	public List<ExportedItemUsage.Elements>? inElements
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

	public List<ExportedItemUsage.Shop>? inShop
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

	public List<ExportedItemUsage.Shop>? inShop1
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

	public List<ExportedItemUsage.Shop>? inShop2
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

	public List<ExportedItemUsage.Npcgen>? inNpcgen
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

	public List<ExportedItemUsage.Tasks>? inTasks
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

	public List<ExportedItemUsage.ExtraDrops>? inExtraDrops
	{
		[CompilerGenerated]
		get
		{
			return list_6;
		}
		[CompilerGenerated]
		set
		{
			list_6 = value;
		}
	}

	public ExportedItemUsages(int totalCount, List<ExportedItemUsage.Elements> inElements, List<ExportedItemUsage.Shop> inShop, List<ExportedItemUsage.Shop> inShop1, List<ExportedItemUsage.Shop> inShop2, List<ExportedItemUsage.Npcgen> inNpcgen, List<ExportedItemUsage.Tasks> inTasks, List<ExportedItemUsage.ExtraDrops> inExtraDrops)
	{
		this.totalCount = totalCount;
	}
}
