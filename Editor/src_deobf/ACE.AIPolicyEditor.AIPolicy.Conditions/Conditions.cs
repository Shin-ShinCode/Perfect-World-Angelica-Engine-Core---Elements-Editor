using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy.Conditions;

public static class Conditions
{
	private sealed class Class21
	{
		public string string_0;

		internal bool method_0(object object_0)
		{
			return object_0.ToString().Contains(string_0);
		}
	}

	[Serializable]
	private sealed class Class22
	{
		public static readonly Class22 class22_0 = new Class22();

		public static Action<object> action_0;

		internal void method_0(object object_0)
		{
			object_0.ToString().Replace('.', ',');
		}
	}

	private static readonly int[] int_0 = new int[49]
	{
		0, 1, 2, 3, 4, 8, 16, 17, 18, 19,
		20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
		30, 31, 32, 33, 34, 35, 36, 37, 38, 39,
		40, 41, 42, 43, 44, 45, 46, 47, 48, 49,
		50, 51, 52, 53, 54, 55, 56, 200, 201
	};

	private static readonly HashSet<int> hashSet_0 = new HashSet<int>(int_0);

	public static int[] Non_central => int_0;

	public static bool IsNonCentral(int id)
	{
		return hashSet_0.Contains(id);
	}

	public static Condition CreateEmpty()
	{
		Condition condition = new Condition();
		condition.ID = 2;
		condition.Type = 3;
		condition.Value = new object[0];
		return condition;
	}

	public static object[] CreateEmptyValue(int type)
	{
		switch (type)
		{
		case 29:
			return new object[5] { 0, 0, 0, 0, 0 };
		case 28:
		case 36:
			return new object[2]
			{
				Class16.smethod_0(1648942077),
				Class16.smethod_0(1648942077)
			};
		case 30:
		case 39:
			return new object[3] { 0, 0, 0 };
		case 0:
		case 1:
		case 3:
		case 16:
		case 17:
		case 19:
		case 20:
		case 21:
		case 23:
		case 25:
		case 27:
		case 35:
		case 37:
		case 38:
		case 41:
		case 42:
		case 43:
		case 44:
		case 200:
		case 201:
			return new object[1] { 0 };
		default:
			return new object[0];
		case 18:
		case 24:
		case 32:
		case 34:
		case 47:
			return new object[2] { 0, 0 };
		}
	}

	public static List<int> GetConditionIds()
	{
		List<int> list = new List<int>();
		int num = 55;
		num = ((CTriggerData.MaxVersion <= 1) ? 9 : ((CTriggerData.MaxVersion <= 9) ? 19 : ((CTriggerData.MaxVersion <= 10) ? 20 : ((CTriggerData.MaxVersion <= 14) ? 23 : ((CTriggerData.MaxVersion <= 20) ? 26 : ((CTriggerData.MaxVersion <= 22) ? 27 : ((CTriggerData.MaxVersion <= 23) ? 28 : ((CTriggerData.MaxVersion <= 30) ? 35 : ((CTriggerData.MaxVersion <= 33) ? 40 : ((CTriggerData.MaxVersion <= 35) ? 45 : ((CTriggerData.MaxVersion <= 39) ? 45 : ((CTriggerData.MaxVersion > 40) ? 57 : 48))))))))))));
		for (int i = 0; i < num; i++)
		{
			list.Add(i);
		}
		if (CTriggerData.MaxVersion > 100)
		{
			list.Add(200);
			list.Add(201);
		}
		return list;
	}

	public static List<string> GetConditions()
	{
		List<string> list = new List<string>();
		foreach (int conditionId in GetConditionIds())
		{
			list.Add(GetName(conditionId));
		}
		return list;
	}

	public static string[] GetFileds(int Type)
	{
		switch (Type)
		{
		case 201:
			return new string[1] { Class16.smethod_0(1648941304) };
		case 200:
			return new string[1] { Class16.smethod_0(1648941288) };
		case 0:
			return new string[1] { Class16.smethod_0(1648941057) };
		case 1:
			return new string[1] { Class16.smethod_0(1648941066) };
		case 3:
			return new string[1] { Class16.smethod_0(1648941080) };
		case 16:
			return new string[1] { Class16.smethod_0(1648941057) };
		case 17:
			return new string[1] { Class16.smethod_0(1648941098) };
		case 18:
			return new string[2]
			{
				Class16.smethod_0(1648941118),
				Class16.smethod_0(1648941135)
			};
		case 19:
			return new string[1] { Class16.smethod_0(1648941144) };
		case 20:
			return new string[1] { Class16.smethod_0(1648941057) };
		case 21:
			return new string[1] { Class16.smethod_0(1648941098) };
		case 23:
			return new string[1] { Class16.smethod_0(1648941057) };
		case 24:
			return new string[2]
			{
				Class16.smethod_0(1648941144),
				Class16.smethod_0(1648941165)
			};
		case 25:
			return new string[1] { Class16.smethod_0(1648941057) };
		case 27:
			return new string[1] { Class16.smethod_0(1648941182) };
		case 29:
			return new string[5]
			{
				Class16.smethod_0(1648941215),
				Class16.smethod_0(1648941218),
				Class16.smethod_0(1648941238),
				Class16.smethod_0(1648941240),
				Class16.smethod_0(1648941251)
			};
		case 30:
			return new string[3]
			{
				Class16.smethod_0(1648941264),
				Class16.smethod_0(1648941240),
				Class16.smethod_0(1648941251)
			};
		case 32:
			return new string[2]
			{
				Class16.smethod_0(1648941144),
				Class16.smethod_0(1648941165)
			};
		case 34:
			return new string[2]
			{
				Class16.smethod_0(1648941057),
				Class16.smethod_0(1648941275)
			};
		case 35:
			return new string[1] { Class16.smethod_0(1648941182) };
		case 28:
		case 36:
			return new string[2]
			{
				Class16.smethod_0(1648941187),
				Class16.smethod_0(1648941205)
			};
		default:
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648941327), Class16.smethod_0(1648941365)), Type), Class16.smethod_0(1648941399), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return new string[0];
		case 2:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 22:
		case 26:
		case 31:
		case 33:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 55:
		case 56:
			return new string[0];
		}
	}

	public static object[] Read(byte[] data, int type)
	{
		if (data != null && data.Length != 0)
		{
			byte[] array = new byte[4];
			byte[] array2 = new byte[4];
			byte[] array3 = new byte[4];
			byte[] array4 = new byte[4];
			byte[] array5 = new byte[4];
			try
			{
				switch (type)
				{
				case 29:
					Array.Copy(data, array, 4);
					Array.Copy(data, 4, array2, 0, 4);
					Array.Copy(data, 8, array3, 0, 4);
					Array.Copy(data, 12, array4, 0, 4);
					Array.Copy(data, 16, array5, 0, 4);
					return new object[5]
					{
						BitConverter.ToInt32(array, 0),
						BitConverter.ToInt32(array2, 0),
						BitConverter.ToInt32(array3, 0),
						BitConverter.ToInt32(array4, 0),
						BitConverter.ToInt32(array5, 0)
					};
				case 18:
				case 24:
				case 32:
				case 34:
					Array.Copy(data, array, 4);
					Array.Copy(data, 4, array2, 0, 4);
					return new object[2]
					{
						BitConverter.ToInt32(array, 0),
						BitConverter.ToInt32(array2, 0)
					};
				case 28:
				case 36:
					return new object[2]
					{
						string.Format(Class16.smethod_0(1648941420), BitConverter.ToSingle(data, 0), BitConverter.ToSingle(data, 4), BitConverter.ToSingle(data, 8)),
						string.Format(Class16.smethod_0(1648941420), BitConverter.ToSingle(data, 12), BitConverter.ToSingle(data, 16), BitConverter.ToSingle(data, 20))
					};
				case 37:
				{
					byte value = data[0];
					return new object[1] { Convert.ToInt32(value) };
				}
				case 30:
				case 39:
					Array.Copy(data, array, 4);
					Array.Copy(data, 4, array2, 0, 4);
					Array.Copy(data, 8, array3, 0, 4);
					return new object[3]
					{
						BitConverter.ToInt32(array, 0),
						BitConverter.ToInt32(array2, 0),
						BitConverter.ToInt32(array3, 0)
					};
				case 0:
				case 16:
				case 17:
				case 19:
				case 20:
				case 21:
				case 23:
				case 25:
				case 38:
				case 41:
				case 42:
				case 43:
				case 200:
				case 201:
					Array.Copy(data, array, 4);
					return new object[1] { BitConverter.ToInt32(array, 0) };
				case 1:
				case 3:
				case 27:
				case 35:
				case 44:
					Array.Copy(data, array, 4);
					return new object[1] { BitConverter.ToSingle(array, 0) };
				default:
					return new object[0];
				case 47:
					Array.Copy(data, array, 4);
					Array.Copy(data, 4, array2, 0, 4);
					return new object[2]
					{
						BitConverter.ToInt32(array, 0),
						BitConverter.ToSingle(array2, 0)
					};
				}
			}
			catch (ArgumentException)
			{
				return new object[0];
			}
		}
		return new object[0];
	}

	public static bool Search(Condition condition_0, string str)
	{
		Class21 @class = new Class21();
		@class.string_0 = str;
		if (condition_0.Value.Where(@class.method_0).Count() > 0)
		{
			return true;
		}
		if (condition_0.ConditionLeft != null && Search(condition_0.ConditionLeft, @class.string_0))
		{
			return true;
		}
		if (condition_0.ConditionRight != null && Search(condition_0.ConditionRight, @class.string_0))
		{
			return true;
		}
		return false;
	}

	public static bool Search(Condition condition_0, int id)
	{
		if (condition_0.ID == id)
		{
			return true;
		}
		if (condition_0.ConditionLeft != null && Search(condition_0.ConditionLeft, id))
		{
			return true;
		}
		if (condition_0.ConditionRight != null && Search(condition_0.ConditionRight, id))
		{
			return true;
		}
		return false;
	}

	public static int TypeByID(int id)
	{
		switch (id)
		{
		default:
			return 1;
		case 5:
			return 2;
		case 6:
		case 7:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
			return 1;
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 8:
		case 16:
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 200:
		case 201:
			return 3;
		}
	}

	public static byte[] Write(object[] param, int type)
	{
		Array.ForEach(param, Class22.class22_0.method_0);
		switch (type)
		{
		case 29:
		{
			byte[] array = new byte[20];
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[0])), array, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[1])), 0, array, 4, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[2])), 0, array, 8, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[3])), 0, array, 12, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[4])), 0, array, 16, 4);
			return array;
		}
		case 18:
		case 24:
		case 32:
		case 34:
		{
			byte[] array = new byte[8];
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[0])), array, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[1])), 0, array, 4, 4);
			return array;
		}
		case 28:
		case 36:
		{
			byte[] array = new byte[24];
			string[] array2 = param[0].ToString().Split(' ');
			string[] array3 = param[1].ToString().Split(' ');
			Array.Copy(BitConverter.GetBytes(Convert.ToSingle(array2[0])), array, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToSingle(array2[1])), 0, array, 4, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToSingle(array2[2])), 0, array, 8, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToSingle(array3[0])), 0, array, 12, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToSingle(array3[1])), 0, array, 16, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToSingle(array3[2])), 0, array, 20, 4);
			return array;
		}
		case 37:
		{
			byte b = (byte)(int)param[0];
			return new byte[1] { b };
		}
		case 30:
		case 39:
		{
			byte[] array = new byte[12];
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[0])), array, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[1])), 0, array, 4, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[2])), 0, array, 8, 4);
			return array;
		}
		case 0:
		case 16:
		case 17:
		case 19:
		case 20:
		case 21:
		case 23:
		case 25:
		case 38:
		case 41:
		case 42:
		case 43:
		case 200:
		case 201:
			return BitConverter.GetBytes(Convert.ToInt32(param[0]));
		case 1:
		case 3:
		case 27:
		case 35:
		case 44:
			return BitConverter.GetBytes(Convert.ToSingle(param[0]));
		default:
			return new byte[0];
		case 47:
		{
			byte[] array = new byte[8];
			Array.Copy(BitConverter.GetBytes(Convert.ToInt32(param[0])), array, 4);
			Array.Copy(BitConverter.GetBytes(Convert.ToSingle(param[1])), 0, array, 4, 4);
			return array;
		}
		}
	}

	public static string GetName(int id)
	{
		return id switch
		{
			201 => Class16.smethod_0(1648941304), 
			200 => Class16.smethod_0(1648941288), 
			5 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648941447) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941438)), 
			6 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648941456) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941455)), 
			7 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648941474) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941465)), 
			9 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648941500) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941483)), 
			10 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648941518) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941508)), 
			11 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648941528) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941526)), 
			12 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648941546) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941536)), 
			13 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648936452) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648941554)), 
			14 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648936470) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648936460)), 
			15 => (MainForm.ConditionType == 0) ? Class16.smethod_0(1648936480) : MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648936478)), 
			_ => MainForm.Provider.GetLocalizedString(string.Format(Class16.smethod_0(1648936489), id)) ?? Class16.smethod_0(1648936508), 
		};
	}

	public static (int, int) GetSubNodeByType(int type)
	{
		return type switch
		{
			2 => (4, 0), 
			1 => (2, 4), 
			_ => (0, 0), 
		};
	}
}
