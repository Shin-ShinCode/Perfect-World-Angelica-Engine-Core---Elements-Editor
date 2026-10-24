using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Models.ECM;

public class CombinedAct
{
	private string string_0;

	private int int_0;

	private List<BaseAct> list_0 = new List<BaseAct>();

	public string Name
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

	public int BaseActNum
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

	public List<BaseAct> BaseActs
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
}
