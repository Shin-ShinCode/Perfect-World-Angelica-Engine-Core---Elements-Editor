using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

[TypeConverter(typeof(TargetParamTypeConverter))]
[Editor(typeof(TargetEditor), typeof(UITypeEditor))]
public class TargetParam : ICloneable
{
	private uint uint_0;

	private uint uint_1;

	private EnumTarget enumTarget_0;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	public uint Occupations
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public uint Meter
	{
		get
		{
			return Players;
		}
		set
		{
			Players = value;
		}
	}

	public uint Players
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	public EnumTarget Target
	{
		[CompilerGenerated]
		get
		{
			return enumTarget_0;
		}
		[CompilerGenerated]
		set
		{
			enumTarget_0 = value;
		}
	}

	public uint Unk2
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	public uint Unk3
	{
		[CompilerGenerated]
		get
		{
			return uint_3;
		}
		[CompilerGenerated]
		set
		{
			uint_3 = value;
		}
	}

	public uint Unk4
	{
		[CompilerGenerated]
		get
		{
			return uint_4;
		}
		[CompilerGenerated]
		set
		{
			uint_4 = value;
		}
	}

	public TargetParam()
	{
		Target = EnumTarget.hate_first;
		Occupations = 0u;
		Players = 0u;
		Unk2 = 0u;
		Unk3 = 0u;
		Unk4 = 0u;
	}

	public override string ToString()
	{
		string text = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938914) + Target) ?? Target.ToString();
		if (Target == EnumTarget.occupation_list)
		{
			return string.Format(Class16.smethod_0(1648938987), text, Occupations);
		}
		if (Target != EnumTarget.t_random_in_range && Target != EnumTarget.t_nearest_in_range && Target != EnumTarget.t_farthest_in_range)
		{
			if (Target == EnumTarget.unk_18)
			{
				return string.Format(Class16.smethod_0(1648938002), text, Players, Unk2, Unk3);
			}
			if (Target == EnumTarget.unk_20)
			{
				return string.Format(Class16.smethod_0(1648938036), text, Players, Unk2, Unk3, Unk4);
			}
			return text;
		}
		return string.Format(Class16.smethod_0(1648937985), text, Meter);
	}

	public object Clone()
	{
		return new TargetParam
		{
			Target = Target,
			Occupations = Occupations,
			Players = Players,
			Unk2 = Unk2,
			Unk3 = Unk3,
			Unk4 = Unk4
		};
	}
}
