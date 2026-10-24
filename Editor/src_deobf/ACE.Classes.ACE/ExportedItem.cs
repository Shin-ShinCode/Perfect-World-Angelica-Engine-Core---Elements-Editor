#nullable enable annotations
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ExportedItem : ItemBaseWithType
{
	public class Monster : ExportedItem
	{
		public class DropItem : ItemBase
		{
			private float float_0;

			public float prob
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

			public DropItem(int id, string name, string color, float prob)
				: base(id, name, color)
			{
				this.prob = prob;
			}
		}

		private List<DropItem> list_0;

		public List<DropItem> extraDrops
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

		public Monster(int id, string name, string color, int typeId, Dictionary<string, object[]> fields, string html, ExportedItemUsages usages, List<DropItem> extraDrops)
			: base(id, name, color, null, typeId, null, fields, new Dictionary<string, object[]>(), html, usages)
		{
			this.extraDrops = extraDrops;
		}
	}

	private Dictionary<string, object[]> dictionary_0;

	private Dictionary<string, object[]> dictionary_1;

	private string? string_2;

	private string? string_3;

	private ExportedItemUsages exportedItemUsages_0;

	public Dictionary<string, object[]> fields
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

	public Dictionary<string, object[]> extraFields
	{
		[CompilerGenerated]
		get
		{
			return dictionary_1;
		}
		[CompilerGenerated]
		set
		{
			dictionary_1 = value;
		}
	}

	public string? html
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

	public string? desc
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

	public ExportedItemUsages usages
	{
		[CompilerGenerated]
		get
		{
			return exportedItemUsages_0;
		}
		[CompilerGenerated]
		set
		{
			exportedItemUsages_0 = value;
		}
	}

	public ExportedItem(int id, string name, string color, string? desc, int? typeId, int? subtypeId, Dictionary<string, object[]> fields, Dictionary<string, object[]> extraFields, string? html, ExportedItemUsages usages)
		: base(id, name, color, typeId, subtypeId)
	{
		this.fields = fields;
		this.extraFields = extraFields;
		this.desc = desc;
		this.html = html;
		this.usages = usages;
	}
}
