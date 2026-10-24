using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

[TypeConverter(typeof(MineIDTypeConverter))]
[Editor(typeof(MineSelector), typeof(UITypeEditor))]
public class MineID : ICloneable
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

	public MineID()
	{
		Value = 0u;
	}

	public override string ToString()
	{
		string mineName = CustomData.GetMineName((int)Value);
		return string.Format(Class16.smethod_0(1648938828), Value, mineName);
	}

	public object Clone()
	{
		return new MineID
		{
			Value = Value
		};
	}
}
