using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ACE.Cpk;
using ACE.RSGlobal;

namespace ACE.Classes;

public class REFERENCE_ENTRY
{
	public int id;

	public string Name;

	public object oSpecial;

	public object extra_value1;

	public object extra_value2;

	public object oParent;

	public INDICES indices;

	public string CleanValue2
	{
		get
		{
			object object_ = extra_value2;
			return method_3(object_);
		}
	}

	public string CleanValue1
	{
		get
		{
			object object_ = extra_value1;
			return method_3(object_);
		}
	}

	public string Value2 => method_2(2);

	public string Value1 => method_2(1);

	public object oValue2 => extra_value2;

	public object oValue1 => extra_value1;

	public FIELDPOS FieldPos => new FIELDPOS(indices.int_0, indices.int_1, indices.int_2);

	public float[] vPos => (float[])oSpecial;

	public QUEST_INFO QuestInfo => (QUEST_INFO)oSpecial;

	public REFERENCE_ENTRY(object oParent, INDICES indices, object oSpecial, int id, string Name, object val1, object val2)
	{
		this.oParent = oParent;
		this.indices = indices;
		this.oSpecial = oSpecial;
		this.id = id;
		this.Name = Name;
		extra_value1 = val1;
		extra_value2 = val2;
	}

	public string GetNpcCoords([MarshalAs(UnmanagedType.U1)] bool bWithRealCoords)
	{
		if (bWithRealCoords)
		{
			object[] array = new object[6];
			float[] array2 = (float[])oSpecial;
			array[0] = (int)((double)array2[0] + 4000.0) / 10;
			float[] array3 = (float[])oSpecial;
			array[1] = (int)((double)array3[2] + 5500.0) / 10;
			float[] array4 = (float[])oSpecial;
			array[2] = (int)(double)array4[1] / 10;
			float[] array5 = (float[])oSpecial;
			array[3] = array5[0];
			float[] array6 = (float[])oSpecial;
			array[4] = array6[1];
			float[] array7 = (float[])oSpecial;
			array[5] = array7[2];
			string result = string.Format(Class16.smethod_0(1648898580), array);
			GC.KeepAlive(this);
			return result;
		}
		object obj = oSpecial;
		float[] array8 = (float[])obj;
		float[] array9 = (float[])obj;
		float[] array10 = (float[])obj;
		string result2 = string.Format(Class16.smethod_0(1648898633), (int)((double)array10[0] + 4000.0) / 10, (int)((double)array9[2] + 5500.0) / 10, (int)(double)array8[1] / 10);
		GC.KeepAlive(this);
		return result2;
	}

	public PointF GetNpcPoint()
	{
		object obj = oSpecial;
		float[] array = (float[])obj;
		float[] array2 = (float[])obj;
		PointF result = new PointF(array2[0], array[2]);
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsValuePresented(int index)
	{
		if (index == 1)
		{
			return extra_value1 != null;
		}
		return extra_value2 != null;
	}

	private object method_0(int int_0)
	{
		object result = null;
		switch (int_0)
		{
		case 2:
			result = extra_value2;
			break;
		case 1:
			result = extra_value1;
			break;
		}
		return result;
	}

	private string method_1(object object_0)
	{
		string result = null;
		if (object_0 != null)
		{
			Type type = object_0.GetType();
			if (type == typeof(int))
			{
				result = ((int)object_0).ToString(Class16.smethod_0(1648909972));
			}
			else if (type == typeof(uint))
			{
				result = ((uint)object_0).ToString(Class16.smethod_0(1648909972));
			}
			else if (type == typeof(float))
			{
				float value = (float)object_0;
				result = global::ACE.RSGlobal.RSGlobal.ToPercent(value, 4);
			}
			else
			{
				result = object_0.ToString();
			}
		}
		GC.KeepAlive(this);
		return result;
	}

	private string method_2(int int_0)
	{
		object obj = null;
		switch (int_0)
		{
		case 2:
			obj = extra_value2;
			if (oSpecial != null && oSpecial.GetType() == typeof(float[]))
			{
				string result = CommonStorage.SecondsToString((int)obj);
				GC.KeepAlive(this);
				return result;
			}
			break;
		case 1:
			obj = extra_value1;
			break;
		}
		GC.KeepAlive(this);
		return method_1(obj);
	}

	private string method_3(object object_0)
	{
		string result = null;
		if (object_0 != null)
		{
			Type type = object_0.GetType();
			result = ((type == typeof(int)) ? ((int)object_0).ToString() : ((type == typeof(uint)) ? ((uint)object_0).ToString() : ((!(type == typeof(float))) ? object_0.ToString() : ((float)object_0).ToString())));
		}
		GC.KeepAlive(this);
		return result;
	}
}
