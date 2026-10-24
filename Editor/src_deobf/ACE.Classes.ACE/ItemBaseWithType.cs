using System.Runtime.CompilerServices;

namespace ACE.Classes.ACE;

public class ItemBaseWithType : ItemBase
{
	private int? nullable_0;

	private int? nullable_1;

	public int? typeId
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

	public int? subtypeId
	{
		[CompilerGenerated]
		get
		{
			return nullable_1;
		}
		[CompilerGenerated]
		set
		{
			nullable_1 = value;
		}
	}

	public ItemBaseWithType(int id, string name, string color, int? typeId, int? subtypeId)
		: base(id, name, color)
	{
		this.typeId = typeId;
		this.subtypeId = subtypeId;
	}
}
