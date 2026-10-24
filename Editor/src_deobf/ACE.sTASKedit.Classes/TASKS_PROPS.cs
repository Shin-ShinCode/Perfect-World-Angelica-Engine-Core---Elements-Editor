using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Classes.Localization;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.sTASKedit.tasks.tasks.data;
using Newtonsoft.Json.Linq;

namespace ACE.sTASKedit.Classes;

public class TASKS_PROPS
{
	public static Dictionary<string, int> AwardHintFlags;

	public static Dictionary<string, string> AwardHintProps;

	public static CommonStorage CStorage;

	[ThreadStatic]
	public static Dictionary<ReferenceSubType, TASK_PROPS_PART> CurrentTaskProps;

	public static Dictionary<string, int> HintDefaultVals;

	public static Dictionary<string, string> MainHintProps;

	private static readonly object object_0 = new object();

	public static void AddTaskItem(ReferenceType section, ReferenceSubType sub_type, int item_id, REFERENCE_ENTRY ref_info)
	{
		lock (object_0)
		{
			if (CurrentTaskProps == null)
			{
				CurrentTaskProps = new Dictionary<ReferenceSubType, TASK_PROPS_PART>();
			}
			if (CurrentTaskProps.TryGetValue(sub_type, out var value) && value != null)
			{
				if (value.Items == null)
				{
					value.Items = new List<TASKS_ITEM_ENTRY>();
				}
			}
			else
			{
				value = new TASK_PROPS_PART
				{
					section = section,
					Items = new List<TASKS_ITEM_ENTRY>()
				};
				CurrentTaskProps[sub_type] = value;
			}
			TASKS_ITEM_ENTRY item = new TASKS_ITEM_ENTRY
			{
				item_id = item_id,
				ref_info = ref_info
			};
			value.Items.Add(item);
		}
	}

	public static TASK_PROPS_PART AddTaskProp(ReferenceSubType referenceSubType_0, string prop, int val)
	{
		lock (object_0)
		{
			if (CurrentTaskProps == null)
			{
				CurrentTaskProps = new Dictionary<ReferenceSubType, TASK_PROPS_PART>();
			}
			if (CurrentTaskProps.TryGetValue(referenceSubType_0, out var value) && value != null)
			{
				if (value.Props == null)
				{
					value.Props = new Dictionary<string, int>();
				}
			}
			else
			{
				value = new TASK_PROPS_PART
				{
					Props = new Dictionary<string, int>()
				};
				CurrentTaskProps[referenceSubType_0] = value;
			}
			if (!value.Props.ContainsKey(prop))
			{
				value.Props[prop] = val;
			}
			return value;
		}
	}

	public static void CreateTaskProps(int task_id)
	{
		CurrentTaskProps = new Dictionary<ReferenceSubType, TASK_PROPS_PART>();
	}

	public static void FillProperties(PropertyInfo[] Props, Dictionary<string, string> HintProps, Dictionary<string, int> HintFlags, [MarshalAs(UnmanagedType.U1)] bool IsMain)
	{
		int num = 0;
		if (0 >= (nint)Props.LongLength)
		{
			return;
		}
		do
		{
			PropertyInfo propertyInfo = Props[num];
			string name = propertyInfo.Name;
			bool flag;
			if (!HintProps.ContainsKey(name) && !name.EndsWith(Class16.smethod_0(1649257907)) && !name.EndsWith(Class16.smethod_0(1649257915)) && !name.EndsWith(Class16.smethod_0(1649257933)) && ((flag = propertyInfo.PropertyType == typeof(bool)) || !(propertyInfo.PropertyType != typeof(int))))
			{
				HintProps.Add(name, MakeTaskPropCaption(name));
				if (IsMain)
				{
					HintFlags.Add(name, 0);
				}
				else if (flag)
				{
					HintFlags.Add(name, 1);
				}
			}
			num++;
		}
		while (num < (nint)Props.LongLength);
	}

	public static void LoadHints()
	{
		MainHintProps = new Dictionary<string, string>();
		HintDefaultVals = new Dictionary<string, int>();
		AwardHintProps = new Dictionary<string, string>();
		AwardHintFlags = new Dictionary<string, int>();
		string text = smethod_0();
		string path = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648899207), Class16.smethod_0(1649257943), text + Class16.smethod_0(1648899122));
		if (File.Exists(path))
		{
			JObject val = null;
			try
			{
				val = JObject.Parse(File.ReadAllText(path, Encoding.UTF8));
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649257973));
				return;
			}
			JToken obj = val[Class16.smethod_0(1649256969)];
			smethod_1((JObject)(object)((obj is JObject) ? obj : null), MainHintProps);
			JToken obj2 = val[Class16.smethod_0(1649256985)];
			smethod_2((JObject)(object)((obj2 is JObject) ? obj2 : null), HintDefaultVals);
			JToken obj3 = val[Class16.smethod_0(1649257012)];
			smethod_1((JObject)(object)((obj3 is JObject) ? obj3 : null), AwardHintProps);
			JToken obj4 = val[Class16.smethod_0(1649257029)];
			smethod_2((JObject)(object)((obj4 is JObject) ? obj4 : null), AwardHintFlags);
			smethod_3();
			smethod_4();
			FillProperties(typeof(AWARD_DATA).GetProperties(), AwardHintProps, AwardHintFlags, IsMain: false);
		}
	}

	private static string smethod_0()
	{
		string text = LANG_INFO.CurrentLang?.Code;
		if (string.IsNullOrWhiteSpace(text))
		{
			text = LANG_INFO.CurrentLang?.Prefix;
		}
		string text2 = LocalizationBridge.ResolveLocaleCodeFromLegacyPrefix(text);
		if (string.IsNullOrWhiteSpace(text2))
		{
			text2 = Class16.smethod_0(1648931959);
		}
		return text2;
	}

	private static void smethod_1(JObject jobject_0, Dictionary<string, string> dictionary_0)
	{
		if (jobject_0 == null || dictionary_0 == null)
		{
			return;
		}
		foreach (JProperty item in jobject_0.Properties())
		{
			string text = item.Name?.Trim();
			if (string.IsNullOrWhiteSpace(text))
			{
				continue;
			}
			JToken value = item.Value;
			object obj;
			if (value == null)
			{
				obj = null;
			}
			else
			{
				obj = ((object)value).ToString();
				if (obj != null)
				{
					goto IL_0054;
				}
			}
			obj = string.Empty;
			goto IL_0054;
			IL_0054:
			dictionary_0[text] = (string)obj;
		}
	}

	private static void smethod_2(JObject jobject_0, Dictionary<string, int> dictionary_0)
	{
		if (jobject_0 == null || dictionary_0 == null)
		{
			return;
		}
		foreach (JProperty item in jobject_0.Properties())
		{
			string text = item.Name?.Trim();
			if (!string.IsNullOrWhiteSpace(text) && int.TryParse(((object)item.Value)?.ToString(), out var result))
			{
				dictionary_0[text] = result;
			}
		}
	}

	private static void smethod_3()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, string> mainHintProp in MainHintProps)
		{
			if ((object)typeof(ATaskTempl).GetProperty(mainHintProp.Key) == null)
			{
				list.Add(mainHintProp.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			string text = list[i];
			MainHintProps.Remove(text);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649257046)) + Class16.smethod_0(1649257077) + text + Class16.smethod_0(1649257086), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private static void smethod_4()
	{
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, string> awardHintProp in AwardHintProps)
		{
			PropertyInfo property = typeof(AWARD_DATA).GetProperty(awardHintProp.Key);
			if ((object)property == null)
			{
				list.Add(awardHintProp.Key);
			}
			else if (property.PropertyType == typeof(bool) && !AwardHintFlags.ContainsKey(awardHintProp.Key))
			{
				AwardHintFlags[awardHintProp.Key] = 1;
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			string text = list[i];
			AwardHintProps.Remove(text);
			AwardHintFlags.Remove(text);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649257095)) + Class16.smethod_0(1649257077) + text + Class16.smethod_0(1649257086), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	public static string MakeTaskPropCaption(string prop)
	{
		string empty = string.Empty;
		string oldValue = Class16.smethod_0(1649257132);
		string oldValue2 = Class16.smethod_0(1649257142);
		string oldValue3 = Class16.smethod_0(1649257144);
		string oldValue4 = Class16.smethod_0(1649257154);
		return ACE.RSGlobal.RSGlobal.ConvertTitleCasedPropToNormalEnglish(prop.Replace(Class16.smethod_0(1649257172), empty).Replace(oldValue4, empty).Replace(oldValue3, empty)
			.Replace(oldValue2, empty)
			.Replace(oldValue, empty));
	}
}
