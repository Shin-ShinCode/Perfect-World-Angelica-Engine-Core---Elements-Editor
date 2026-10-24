using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

[Editor(typeof(SkillSelector), typeof(UITypeEditor))]
[TypeConverter(typeof(SkillIDTypeConverter))]
public class SkillID : ICloneable
{
	private uint uint_0;

	public uint Value
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

	public SkillID()
	{
		Value = 0u;
	}

	public override string ToString()
	{
		string skillName = CustomData.GetSkillName((int)Value);
		return string.Format(Class16.smethod_0(1648938828), Value, skillName);
	}

	public object Clone()
	{
		return new SkillID
		{
			Value = Value
		};
	}
}
