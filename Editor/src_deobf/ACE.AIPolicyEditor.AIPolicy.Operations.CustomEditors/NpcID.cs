using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

[Editor(typeof(NpcSelector), typeof(UITypeEditor))]
[TypeConverter(typeof(NpcIDTypeConverter))]
public class NpcID : ICloneable
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

	public NpcID()
	{
		Value = 0u;
	}

	public override string ToString()
	{
		string npcName = CustomData.GetNpcName((int)Value);
		return string.Format(Class16.smethod_0(1648938828), Value, npcName);
	}

	public object Clone()
	{
		return new NpcID
		{
			Value = Value
		};
	}
}
