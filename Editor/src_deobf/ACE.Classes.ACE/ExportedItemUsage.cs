using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public abstract class ExportedItemUsage
{
	public class Elements : ExportedItemUsage
	{
		public class UsageEntry
		{
			private object[] object_0;

			private string[] string_0;

			private string[] string_1;

			private object[] object_1;

			public object[] item
			{
				[CompilerGenerated]
				get
				{
					return object_0;
				}
				[CompilerGenerated]
				set
				{
					object_0 = value;
				}
			}

			public string[] field
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

			public string[] extraField
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

			public object[] extraVal
			{
				[CompilerGenerated]
				get
				{
					return object_1;
				}
				[CompilerGenerated]
				set
				{
					object_1 = value;
				}
			}

			public UsageEntry(int itemId, string itemName, string itemColor, string[] field, string[] extraField, object[] extraVal)
			{
				item = ((itemColor != null) ? new object[3] { itemId, itemName, itemColor } : new object[2] { itemId, itemName });
				this.field = field;
				this.extraField = extraField;
				this.extraVal = extraVal;
			}
		}

		private ReferenceType referenceType_0;

		private string string_1;

		private List<UsageEntry> list_0;

		public ReferenceType type
		{
			[CompilerGenerated]
			get
			{
				return referenceType_0;
			}
			[CompilerGenerated]
			set
			{
				referenceType_0 = value;
			}
		}

		public string listName
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

		public List<UsageEntry> entries
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

		public Elements(ReferenceType type, string caption, string listName, List<UsageEntry> entries)
			: base(caption)
		{
			this.type = type;
			this.listName = listName;
			this.entries = entries;
		}
	}

	public class ExtraDrops : ExportedItemUsage
	{
		public class UsageEntry
		{
			private int int_0;

			private float float_0;

			public int monsterId
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

			public UsageEntry(int monsterId, float prob)
			{
				this.monsterId = monsterId;
				this.prob = prob;
			}
		}

		private List<UsageEntry> list_0;

		public List<UsageEntry> entries
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

		public ExtraDrops(string caption, List<UsageEntry> entries)
			: base(caption)
		{
			this.entries = entries;
		}
	}

	public class Npcgen : ExportedItemUsage
	{
		public class Area : ExportedItemUsage
		{
			public class UsageEntry
			{
				private bool bool_0;

				private int int_0;

				private int int_1;

				private float float_0;

				private float float_1;

				private float float_2;

				public bool isNpc
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

				public int count
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

				public int respawnSec
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

				public float Single_0
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

				public float Single_1
				{
					[CompilerGenerated]
					get
					{
						return float_1;
					}
					[CompilerGenerated]
					set
					{
						float_1 = value;
					}
				}

				public float Single_2
				{
					[CompilerGenerated]
					get
					{
						return float_2;
					}
					[CompilerGenerated]
					set
					{
						float_2 = value;
					}
				}

				public UsageEntry(bool isNpc, int count, int respawnSec, float float_3, float float_4, float float_5)
				{
					this.isNpc = isNpc;
					this.count = count;
					this.respawnSec = respawnSec;
					Single_0 = float_3;
					Single_1 = float_4;
					Single_2 = float_5;
				}
			}

			private List<UsageEntry> list_0;

			public List<UsageEntry> entries
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

			public Area(string caption, List<UsageEntry> entries)
				: base(caption)
			{
				this.entries = entries;
			}
		}

		private string string_1;

		private int int_0;

		private List<Area> list_0;

		public string tag
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

		public int instanceId
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

		public List<Area> areas
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

		public Npcgen(string caption, string tag, int instanceId, List<Area> areas)
			: base(caption)
		{
			this.tag = tag;
			this.instanceId = instanceId;
			this.areas = areas;
		}
	}

	public class Shop : ExportedItemUsage
	{
		public class UsageEntry
		{
			private int int_0;

			private string string_0;

			private int int_1;

			private double? nullable_0;

			public int id
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

			public string name
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

			public int count
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

			public double? price
			{
				[CompilerGenerated]
				get
				{
					return nullable_0;
				}
				[CompilerGenerated]
				set
				{
					nullable_0 = value;
				}
			}

			public UsageEntry(int id, string name, int count, double? price)
			{
				this.id = id;
				this.name = name;
				this.count = count;
				this.price = price;
			}

			public UsageEntry(int id, string name, int count)
			{
				this.id = id;
				this.name = name;
				this.count = count;
			}
		}

		private ReferenceType referenceType_0;

		private ReferenceSubType referenceSubType_0;

		private List<UsageEntry> list_0;

		public ReferenceType type
		{
			[CompilerGenerated]
			get
			{
				return referenceType_0;
			}
			[CompilerGenerated]
			set
			{
				referenceType_0 = value;
			}
		}

		public ReferenceSubType subtype
		{
			[CompilerGenerated]
			get
			{
				return referenceSubType_0;
			}
			[CompilerGenerated]
			set
			{
				referenceSubType_0 = value;
			}
		}

		public List<UsageEntry> entries
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

		public Shop(string caption, ReferenceType type, ReferenceSubType subtype, List<UsageEntry> entries)
			: base(caption)
		{
			this.type = type;
			this.subtype = subtype;
			this.entries = entries;
		}
	}

	public class Tasks : ExportedItemUsage
	{
		public class UsageEntry
		{
			private object[] object_0;

			private int int_0;

			private int int_1;

			private float? nullable_0;

			public object[] task
			{
				[CompilerGenerated]
				get
				{
					return object_0;
				}
				[CompilerGenerated]
				set
				{
					object_0 = value;
				}
			}

			public int image
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

			public int count
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

			public float? prob
			{
				[CompilerGenerated]
				get
				{
					return nullable_0;
				}
				[CompilerGenerated]
				set
				{
					nullable_0 = value;
				}
			}

			public UsageEntry(int id, string name, string color, int image, int count, float? prob)
			{
				task = ((color != null) ? new object[3] { id, name, color } : new object[2] { id, name });
				this.image = image;
				this.count = count;
				this.prob = prob;
			}

			public UsageEntry(int id, string name, string color, int image, int count)
			{
				task = ((color != null) ? new object[3] { id, name, color } : new object[2] { id, name });
				this.image = image;
				this.count = count;
			}

			public UsageEntry(int id, string name, string color, int image)
			{
				task = ((color != null) ? new object[3] { id, name, color } : new object[2] { id, name });
				this.image = image;
			}
		}

		private ReferenceType referenceType_0;

		private ReferenceSubType referenceSubType_0;

		private List<UsageEntry> list_0;

		public ReferenceType type
		{
			[CompilerGenerated]
			get
			{
				return referenceType_0;
			}
			[CompilerGenerated]
			set
			{
				referenceType_0 = value;
			}
		}

		public ReferenceSubType subtype
		{
			[CompilerGenerated]
			get
			{
				return referenceSubType_0;
			}
			[CompilerGenerated]
			set
			{
				referenceSubType_0 = value;
			}
		}

		public List<UsageEntry> entries
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

		public Tasks(string caption, ReferenceType type, ReferenceSubType subtype, List<UsageEntry> entries)
			: base(caption)
		{
			this.type = type;
			this.subtype = subtype;
			this.entries = entries;
		}
	}

	private string string_0;

	public string caption
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

	protected ExportedItemUsage(string caption)
	{
		this.caption = caption;
	}
}
