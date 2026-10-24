using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

[Editor(typeof(MobSelector), typeof(UITypeEditor))]
[TypeConverter(typeof(MobIDTypeConverter))]
public class MobID : ICloneable
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

	public MobID()
	{
		Value = 0u;
	}

	public override string ToString()
	{
		string mobName = CustomData.GetMobName((int)Value);
		return string.Format(Class16.smethod_0(1648938828), Value, mobName);
	}

	public object Clone()
	{
		return new MobID
		{
			Value = Value
		};
	}
}
