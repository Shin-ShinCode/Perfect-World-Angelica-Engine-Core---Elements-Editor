using System;
using System.IO;
using System.Runtime.CompilerServices;
using ACE.AIPolicyEditor.AIPolicy.Conditions;

namespace ACE.AIPolicyEditor.AIPolicy;

public class Condition : ICloneable
{
	public Condition ConditionLeft;

	public Condition ConditionRight;

	private int int_0;

	private int int_1;

	private int int_2;

	private int int_3;

	private object[] object_0;

	public int ID
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

	public int SubNodeL
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

	public int SubNodeR
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int Type
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public object[] Value
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

	public Condition()
	{
		ID = 2;
		Value = new object[0];
		Type = 3;
	}

	public object Clone()
	{
		Condition obj = new Condition
		{
			ID = ID,
			SubNodeL = SubNodeL,
			SubNodeR = SubNodeR,
			Type = Type
		};
		object[] value = Value;
		object obj2;
		if (value == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = value.Clone();
			if (obj2 != null)
			{
				goto IL_0051;
			}
		}
		obj2 = Array.Empty<object>();
		goto IL_0051;
		IL_0051:
		obj.Value = (object[])obj2;
		Condition condition = obj;
		if (ConditionLeft != null)
		{
			condition.ConditionLeft = (Condition)ConditionLeft.Clone();
		}
		if (ConditionRight != null)
		{
			condition.ConditionRight = (Condition)ConditionRight.Clone();
		}
		return condition;
	}

	public void CopyFrom(Condition source)
	{
		if (source == null)
		{
			source = ACE.AIPolicyEditor.AIPolicy.Conditions.Conditions.CreateEmpty();
		}
		ID = source.ID;
		SubNodeL = source.SubNodeL;
		SubNodeR = source.SubNodeR;
		Type = source.Type;
		object[] value = source.Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.Clone();
			if (obj != null)
			{
				goto IL_0056;
			}
		}
		obj = Array.Empty<object>();
		goto IL_0056;
		IL_0056:
		Value = (object[])obj;
		ConditionLeft = ((source.ConditionLeft != null) ? ((Condition)source.ConditionLeft.Clone()) : null);
		ConditionRight = ((source.ConditionRight != null) ? ((Condition)source.ConditionRight.Clone()) : null);
	}

	public void NormalizeTreeMetadata(bool recursive = true)
	{
		if (recursive)
		{
			ConditionLeft?.NormalizeTreeMetadata();
			ConditionRight?.NormalizeTreeMetadata();
		}
		bool flag = ConditionLeft != null;
		bool flag2 = ConditionRight != null;
		if (flag && flag2)
		{
			Type = 1;
		}
		else if (flag2)
		{
			Type = 2;
		}
		else if (flag)
		{
			Type = 1;
		}
		else
		{
			Type = ACE.AIPolicyEditor.AIPolicy.Conditions.Conditions.TypeByID(ID);
		}
		(SubNodeL, SubNodeR) = ACE.AIPolicyEditor.AIPolicy.Conditions.Conditions.GetSubNodeByType(Type);
		if (Value == null)
		{
			Value = Array.Empty<object>();
		}
	}

	public void Read(BinaryReader br)
	{
		ID = br.ReadInt32();
		Value = ACE.AIPolicyEditor.AIPolicy.Conditions.Conditions.Read(br.ReadBytes(br.ReadInt32()), ID);
		ConditionLeft = null;
		ConditionRight = null;
		while (true)
		{
			int num = br.ReadInt32();
			switch (num)
			{
			case 1:
				ConditionLeft = new Condition();
				ConditionLeft.Read(br);
				break;
			case 2:
				ConditionRight = new Condition();
				ConditionRight.Read(br);
				break;
			default:
				throw new InvalidDataException(string.Format(Class16.smethod_0(1648942836), num));
			case 3:
			case 4:
				NormalizeTreeMetadata(recursive: false);
				return;
			}
		}
	}

	public void Save(BinaryWriter bw)
	{
		NormalizeTreeMetadata();
		bw.Write(ID);
		byte[] array = ACE.AIPolicyEditor.AIPolicy.Conditions.Conditions.Write(Value, ID);
		bw.Write(array.Length);
		bw.Write(array);
		if (ConditionLeft == null && ConditionRight == null)
		{
			bw.Write(3);
			return;
		}
		if (ConditionLeft != null)
		{
			bw.Write(1);
			ConditionLeft.Save(bw);
		}
		if (ConditionRight != null)
		{
			bw.Write(2);
			ConditionRight.Save(bw);
		}
		bw.Write(4);
	}
}
