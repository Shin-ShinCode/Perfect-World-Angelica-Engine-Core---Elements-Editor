using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Operations;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;
using ACE.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACE.AIPolicyEditor.AIPolicy;

public static class JsonImporter
{
	[Serializable]
	private sealed class Class30
	{
		public static readonly Class30 class30_0 = new Class30();

		public static Func<PropertyInfo, bool> func_0;

		internal bool method_0(PropertyInfo propertyInfo_0)
		{
			if (propertyInfo_0.CanWrite && propertyInfo_0.Name != Class16.smethod_0(1648936726) && propertyInfo_0.Name != Class16.smethod_0(1648936731))
			{
				return propertyInfo_0.Name != Class16.smethod_0(1648936750);
			}
			return false;
		}
	}

	private static string smethod_0(string string_0, string string_1, object[] object_0)
	{
		string text = TextStorage.Msg(string_0, string_1);
		if (object_0 != null && object_0.Length != 0)
		{
			return string.Format(text, object_0);
		}
		return text;
	}

	private static JToken smethod_1(string string_0)
	{
		//IL_00dc: Expected O, but got Unknown
		if (!File.Exists(string_0))
		{
			throw new InvalidDataException(smethod_0(Class16.smethod_0(1648936102), Class16.smethod_0(1648936136), new object[1] { System.IO.Path.GetFileName(string_0) }));
		}
		StreamReader streamReader = new StreamReader(string_0, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
		string text;
		try
		{
			text = streamReader.ReadToEnd();
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new InvalidDataException(smethod_0(Class16.smethod_0(1648936179), Class16.smethod_0(1648936220), new object[1] { System.IO.Path.GetFileName(string_0) }));
		}
		text = text.Trim();
		char c = text[0];
		if (c != '{' && c != '[')
		{
			throw new InvalidDataException(smethod_0(Class16.smethod_0(1648936250), Class16.smethod_0(1648936294), new object[1] { System.IO.Path.GetFileName(string_0) }));
		}
		try
		{
			return JToken.Parse(text);
		}
		catch (JsonReaderException ex)
		{
			JsonReaderException innerException = ex;
			throw new InvalidDataException(smethod_0(Class16.smethod_0(1648936350), Class16.smethod_0(1648936377), new object[1] { System.IO.Path.GetFileName(string_0) }), (Exception)(object)innerException);
		}
	}

	public static List<CPolicyData> ImportPoliciesFromJsonFile(string filePath)
	{
		JToken val = smethod_1(filePath);
		List<CPolicyData> list = new List<CPolicyData>();
		JArray val2 = (JArray)(object)((val is JArray) ? val : null);
		if (val2 != null)
		{
			foreach (JObject item in ((IEnumerable)val2).OfType<JObject>())
			{
				list.Add(smethod_2(item));
			}
		}
		else
		{
			JObject val3 = (JObject)(object)((val is JObject) ? val : null);
			if (val3 != null)
			{
				list.Add(smethod_2(val3));
			}
		}
		return list;
	}

	public static List<CTriggerData> ImportTriggersFromJsonFile(string filePath, int defaultVersion = 0)
	{
		JToken val = smethod_1(filePath);
		List<CTriggerData> list = new List<CTriggerData>();
		JArray val2 = (JArray)(object)((val is JArray) ? val : null);
		if (val2 != null)
		{
			foreach (JObject item in ((IEnumerable)val2).OfType<JObject>())
			{
				list.Add(smethod_3(item, defaultVersion));
			}
		}
		else
		{
			JObject val3 = (JObject)(object)((val is JObject) ? val : null);
			if (val3 != null)
			{
				list.Add(smethod_3(val3, defaultVersion));
			}
		}
		return list;
	}

	public static OperationImportResult ImportOperationsFromJsonFile(string filePath)
	{
		JToken val = smethod_1(filePath);
		int num = 0;
		JArray val2 = null;
		JObject val3 = (JObject)(object)((val is JObject) ? val : null);
		if (val3 != null)
		{
			JToken obj = val3[Class16.smethod_0(1648936793)];
			num = ((obj != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj) : 0);
			JToken obj2 = val3[Class16.smethod_0(1648942657)];
			val2 = (JArray)(object)((obj2 is JArray) ? obj2 : null);
		}
		else
		{
			JArray val4 = (JArray)(object)((val is JArray) ? val : null);
			if (val4 != null)
			{
				val2 = val4;
			}
		}
		List<IOperation> list = new List<IOperation>();
		if (val2 != null)
		{
			foreach (JObject item in ((IEnumerable)val2).OfType<JObject>())
			{
				IOperation operation = smethod_6(item, num);
				if (operation != null)
				{
					list.Add(operation);
				}
			}
		}
		return new OperationImportResult
		{
			TriggerVersion = num,
			Operations = list
		};
	}

	private static CPolicyData smethod_2(JObject jobject_0)
	{
		CPolicyData cPolicyData = new CPolicyData();
		JToken obj = jobject_0[Class16.smethod_0(1648941057)];
		cPolicyData.ID = ((obj != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj) : 0);
		JToken obj2 = jobject_0[Class16.smethod_0(1648942674)];
		cPolicyData.Version = ((obj2 != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj2) : 0);
		CPolicyData cPolicyData2 = cPolicyData;
		JToken obj3 = jobject_0[Class16.smethod_0(1648942688)];
		JArray val = (JArray)(object)((obj3 is JArray) ? obj3 : null);
		if (val != null)
		{
			foreach (JObject item2 in ((IEnumerable)val).OfType<JObject>())
			{
				CTriggerData item = smethod_3(item2, cPolicyData2.Version);
				cPolicyData2.Triggers.Add(item);
			}
		}
		return cPolicyData2;
	}

	private static CTriggerData smethod_3(JObject jobject_0, int int_0)
	{
		if (jobject_0 == null)
		{
			return new CTriggerData();
		}
		CTriggerData cTriggerData = new CTriggerData();
		JToken obj = jobject_0[Class16.smethod_0(1648941057)];
		cTriggerData.ID = ((obj == null) ? 1 : Extensions.Value<int>((IEnumerable<JToken>)obj));
		JToken obj2 = jobject_0[Class16.smethod_0(1648942674)];
		cTriggerData.Version = ((obj2 != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj2) : int_0);
		JToken obj3 = jobject_0[Class16.smethod_0(1648936731)];
		object obj4;
		if (obj3 == null)
		{
			obj4 = null;
		}
		else
		{
			obj4 = Extensions.Value<string>((IEnumerable<JToken>)obj3);
			if (obj4 != null)
			{
				goto IL_007d;
			}
		}
		obj4 = Class16.smethod_0(1648936409);
		goto IL_007d;
		IL_007d:
		cTriggerData.Name = (string)obj4;
		JToken obj5 = jobject_0[Class16.smethod_0(1648936822)];
		cTriggerData.Active = obj5 != null && Extensions.Value<bool>((IEnumerable<JToken>)obj5);
		JToken obj6 = jobject_0[Class16.smethod_0(1648936827)];
		cTriggerData.Run = obj6 != null && Extensions.Value<bool>((IEnumerable<JToken>)obj6);
		JToken obj7 = jobject_0[Class16.smethod_0(1648936845)];
		cTriggerData.AttackValid = obj7 != null && Extensions.Value<bool>((IEnumerable<JToken>)obj7);
		CTriggerData cTriggerData2 = cTriggerData;
		JToken obj8 = jobject_0[Class16.smethod_0(1648936863)];
		JObject val = (JObject)(object)((obj8 is JObject) ? obj8 : null);
		if (val != null)
		{
			cTriggerData2.RootConditon = smethod_4(val);
		}
		JToken obj9 = jobject_0[Class16.smethod_0(1648942657)];
		JArray val2 = (JArray)(object)((obj9 is JArray) ? obj9 : null);
		if (val2 != null)
		{
			foreach (JObject item in ((IEnumerable)val2).OfType<JObject>())
			{
				IOperation operation = smethod_6(item, cTriggerData2.Version);
				if (operation != null)
				{
					cTriggerData2.Operations.Add(operation);
				}
			}
		}
		return cTriggerData2;
	}

	private static Condition smethod_4(JObject jobject_0)
	{
		if (jobject_0 == null)
		{
			return new Condition();
		}
		Condition condition = new Condition();
		JToken obj = jobject_0[Class16.smethod_0(1648941057)];
		condition.ID = ((obj != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj) : 2);
		JToken obj2 = jobject_0[Class16.smethod_0(1648936875)];
		condition.Type = ((obj2 != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj2) : 3);
		JToken obj3 = jobject_0[Class16.smethod_0(1648936909)];
		condition.SubNodeL = ((obj3 != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj3) : 0);
		JToken obj4 = jobject_0[Class16.smethod_0(1648936924)];
		condition.SubNodeR = ((obj4 != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj4) : 0);
		Condition condition2 = condition;
		JToken obj5 = jobject_0[Class16.smethod_0(1648941098)];
		JArray val = (JArray)(object)((obj5 is JArray) ? obj5 : null);
		if (val != null)
		{
			condition2.Value = smethod_5(val);
		}
		else
		{
			condition2.Value = new object[0];
		}
		JToken obj6 = jobject_0[Class16.smethod_0(1648936931)];
		JObject val2 = (JObject)(object)((obj6 is JObject) ? obj6 : null);
		if (val2 != null)
		{
			condition2.ConditionLeft = smethod_4(val2);
		}
		JToken obj7 = jobject_0[Class16.smethod_0(1648936959)];
		JObject val3 = (JObject)(object)((obj7 is JObject) ? obj7 : null);
		if (val3 != null)
		{
			condition2.ConditionRight = smethod_4(val3);
		}
		condition2.NormalizeTreeMetadata();
		return condition2;
	}

	private static object[] smethod_5(JArray jarray_0)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Invalid comparison between Unknown and I4
		object[] array = new object[((JContainer)jarray_0).Count];
		for (int i = 0; i < ((JContainer)jarray_0).Count; i++)
		{
			JToken val = jarray_0[i];
			if ((int)val.Type == 6)
			{
				array[i] = Extensions.Value<int>((IEnumerable<JToken>)val);
			}
			else if ((int)val.Type == 7)
			{
				array[i] = Extensions.Value<float>((IEnumerable<JToken>)val);
			}
			else if ((int)val.Type == 8)
			{
				array[i] = Extensions.Value<string>((IEnumerable<JToken>)val);
			}
			else if ((int)val.Type == 9)
			{
				array[i] = Extensions.Value<bool>((IEnumerable<JToken>)val);
			}
			else
			{
				array[i] = ((object)val).ToString();
			}
		}
		return array;
	}

	private static IOperation smethod_6(JObject jobject_0, int int_0)
	{
		if (jobject_0 == null)
		{
			return null;
		}
		JToken obj = jobject_0[Class16.smethod_0(1648936726)];
		int num = ((obj != null) ? Extensions.Value<int>((IEnumerable<JToken>)obj) : 0);
		IOperation operation = smethod_7(num, int_0);
		if (operation == null)
		{
			throw new Exception(string.Format(Class16.smethod_0(1648936432), num));
		}
		Type type = operation.GetType();
		IEnumerable<PropertyInfo> enumerable = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(Class30.class30_0.method_0);
		foreach (PropertyInfo item in enumerable)
		{
			if (jobject_0[item.Name] == null)
			{
				continue;
			}
			try
			{
				object obj2 = smethod_8(jobject_0[item.Name], item.PropertyType);
				if (obj2 != null)
				{
					item.SetValue(operation, obj2);
				}
			}
			catch
			{
			}
		}
		return operation;
	}

	private static IOperation smethod_7(int int_0, int int_1)
	{
		switch (int_0)
		{
		case 0:
			return new O_ATTACK_TYPE();
		case 1:
			return new O_USE_SKILL();
		case 2:
			if (int_1 <= 16)
			{
				return new O_TALK_TEXT_OLD();
			}
			return new O_TALK_TEXT();
		case 3:
			return new O_RESET_HATE_LIST();
		case 4:
			return new O_RUN_TRIGGER();
		case 5:
			return new O_STOP_TRIGGER();
		case 6:
			return new O_ACTIVE_TRIGGER();
		case 7:
			return new O_CREATE_TIMER();
		case 8:
			return new O_KILL_TIMER();
		case 9:
			return new O_FLEE();
		case 10:
			return new O_SET_HATE_TO_FIRST();
		case 11:
			return new O_SET_HATE_TO_LAST();
		case 12:
			return new O_SET_HATE_FIFTY_PERCENT();
		case 13:
			return new O_SKIP_OPERATION();
		case 14:
			return new O_ACTIVE_CONTROLLER();
		case 15:
			if (int_1 <= 3)
			{
				return new O_SET_GLOBAL_VERSION3();
			}
			return new O_SET_GLOBAL();
		case 16:
			return new O_REVISE_GLOBAL();
		case 17:
			if (int_1 <= 6)
			{
				return new O_SUMMON_MONSTER_VERSION6();
			}
			return new O_SUMMON_MONSTER();
		case 18:
			return new O_WALK_ALONG();
		case 19:
			if (int_1 <= 8)
			{
				return new O_PLAY_ACTION_VERSION8();
			}
			if (int_1 >= 38)
			{
				return new O_PLAY_ACTION_VERSION40();
			}
			return new O_PLAY_ACTION();
		case 20:
			return new O_REVISE_HISTORY();
		case 21:
			return new O_SET_HISTORY();
		case 22:
			return new O_DELIVER_FACTION_PVP_POINTS();
		case 23:
			return new O_CALC_VAR();
		case 24:
			return new O_SUMMON_MONSTER_2();
		case 25:
			return new O_WALK_ALONG_2();
		case 26:
			return new O_USE_SKILL_2();
		case 27:
			return new O_ACTIVE_CONTROLLER_2();
		case 28:
			return new O_DELIVER_TASK();
		case 29:
			if (int_1 <= 23)
			{
				return new O_SUMMON_MINE_VERSION23();
			}
			return new O_SUMMON_MINE();
		case 30:
			return new O_SUMMON_NPC();
		case 31:
			return new O_DELIVER_RANDOM_TASK_IN_REGION();
		case 32:
			return new O_DELIVER_TASK_IN_HATE_LIST();
		case 33:
			return new O_CLEAR_TOWER_TASK_IN_REGION();
		case 34:
			return new O_SAVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
		case 35:
			return new O_SAVE_PLAYER_COUNT_IN_REGION_TO_PARAM();
		case 36:
			return new O_SKILL_WITH_TALK();
		case 37:
			return new O_USE_SKILL_3();
		case 38:
			return new O_SORT_NUM();
		case 39:
			return new O_GET_POS_NUM();
		case 40:
			return new O_AUTO_BIND_CARRIER();
		case 41:
			return new O_ADD_RANGE_TO_HATE_LIST();
		case 42:
			return new O_SAVE_ALIVE_PLAYER_COUNT_IN_RADIUS_TO_PARAM();
		case 43:
			return new O_SAVE_ALIVE_PLAYER_COUNT_IN_REGION_TO_PARAM();
		case 44:
			return new O_WALK_ALONG_3();
		case 45:
			return new O_WALK_ALONG_4();
		case 46:
			return new O_SAVE_TIME();
		case 47:
			return new O_RANDOM_ASSIGNMENT();
		case 48:
			return new O_CARRIER_VOTING();
		case 49:
			return new O_VOTING_RESULT();
		case 50:
			return new O_VOTING_SHOW();
		case 51:
			return new O_CARRIER_DELIVERY_TASK();
		case 52:
			return new O_CARRIER_NOENTRY();
		case 53:
			return new O_TALK_TEXT_2();
		case 54:
			return new O_CREATE_TIMER_2();
		case 55:
			return new O_KILL_TIMER_2();
		case 56:
			return new O_CHANGE_MONSTER_FIGHTING_STATE();
		case 57:
			return new O_CHANGE_MONSTER_ACTIVE_PASSIVE();
		case 58:
			return new O_CHILD_CARRIER_PARENT_MONSTER();
		case 59:
			return new O_CLOSE_CHILD_MONSTER();
		case 60:
			return new O_DELIVER_HATE_TARGETS();
		case 61:
			return new O_CHANGE_MONSTER_ATTACK_POLICY();
		case 62:
			return new O_SPECIFY_FAILED_TASK_ID();
		case 63:
			return new O_SPECIFY_FAILED_TASK_ID_REGIONAL();
		case 64:
			return new O_MASS_ACTIVE_CONTROLLER();
		case 65:
			return new O_BOSS_RUSH_AWARD();
		case 66:
			return new O_BOSS_RUSH_END();
		case 67:
			return new O_USE_SKILL_IN_REGION();
		case 68:
			return new O_BIRTH_SIZE();
		case 69:
			return new O_REVISE_GLOBAL_2();
		case 70:
			return new O_70();
		case 71:
			return new O_GET_HP_NUM();
		case 72:
			return new O_TALK_TEXT_IN_REGION();
		case 73:
			return new O_ACTIVE_WHITELIST();
		case 74:
			return new O_USE_SKILL_IN_STRATEGY_ZONE();
		case 75:
			return new O_75();
		case 76:
			return new O_76();
		case 77:
			return new O_USE_SKILL_4();
		case 78:
			return new O_78();
		case 79:
			return new O_79();
		case 80:
			return new O_80();
		case 81:
			return new O_81();
		case 82:
			return new O_82();
		case 83:
			return new O_83();
		case 84:
			return new O_84();
		case 85:
			return new O_85();
		case 86:
			return new O_86();
		case 87:
			return new O_87();
		case 88:
			return new O_PET_POLICY();
		case 89:
			return new O_89();
		case 90:
			return new O_90();
		case 91:
			return new O_91();
		case 92:
			return new O_92();
		case 93:
			return new O_93();
		case 94:
			return new O_94();
		case 95:
			return new O_95();
		case 96:
			return new O_96();
		case 97:
			return new O_97();
		case 98:
			return new O_98();
		case 99:
			return new O_COPY_VALUE_TO_MULTIPLE();
		case 100:
			return new O_FAKE_MONSTER_POS();
		case 101:
			return new O_101();
		case 102:
			return new O_CHECK_FACTION_DEATH();
		case 103:
			return new O_103();
		case 104:
			return new O_104();
		case 105:
			return new O_105();
		case 106:
			return new O_106();
		case 107:
			return new O_107();
		case 108:
			return new O_108();
		case 109:
			return new O_109();
		case 110:
			return new O_GIVE_TASK_FOR_RADIUS();
		case 111:
			return new O_111();
		case 112:
			return new O_112();
		case 113:
			return new O_113();
		case 114:
			return new O_114();
		default:
			return null;
		case 200:
			return new O_CALC_VAR_FLOAT();
		case 201:
			return new O_CALC_VAR_MULTI();
		case 202:
			return new O_SET_VAR_STRING();
		case 203:
			return new O_TALK_FROM_VAR_STRING();
		case 204:
			return new O_ADJUST_PROP_BY_ANYTHING();
		case 205:
			return new O_REFRESH_PROP();
		case 206:
			return new O_ACTIVE_PEACE_ZONE();
		}
	}

	private static object smethod_8(JToken jtoken_0, Type type_0)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Invalid comparison between Unknown and I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Invalid comparison between Unknown and I4
		if (jtoken_0 != null && (int)jtoken_0.Type != 10)
		{
			if (type_0 == typeof(TargetParam))
			{
				return smethod_9((JObject)(object)((jtoken_0 is JObject) ? jtoken_0 : null));
			}
			if (type_0.IsEnum)
			{
				JObject val = (JObject)(object)((jtoken_0 is JObject) ? jtoken_0 : null);
				if (val != null && val[Class16.smethod_0(1648941098)] != null)
				{
					int value = Extensions.Value<int>((IEnumerable<JToken>)val[Class16.smethod_0(1648941098)]);
					return Enum.ToObject(type_0, value);
				}
				if ((int)jtoken_0.Type == 6)
				{
					return Enum.ToObject(type_0, Extensions.Value<int>((IEnumerable<JToken>)jtoken_0));
				}
				if ((int)jtoken_0.Type == 8)
				{
					return Enum.Parse(type_0, Extensions.Value<string>((IEnumerable<JToken>)jtoken_0));
				}
			}
			if (!(type_0 == typeof(int)) && !(type_0 == typeof(int?)))
			{
				if (!(type_0 == typeof(uint)) && !(type_0 == typeof(uint?)))
				{
					if (!(type_0 == typeof(long)) && !(type_0 == typeof(long?)))
					{
						if (!(type_0 == typeof(ulong)) && !(type_0 == typeof(ulong?)))
						{
							if (!(type_0 == typeof(float)) && !(type_0 == typeof(float?)))
							{
								if (!(type_0 == typeof(double)) && !(type_0 == typeof(double?)))
								{
									if (!(type_0 == typeof(bool)) && !(type_0 == typeof(bool?)))
									{
										if (type_0 == typeof(string))
										{
											return Extensions.Value<string>((IEnumerable<JToken>)jtoken_0);
										}
										if (type_0.IsArray)
										{
											JArray val2 = (JArray)(object)((jtoken_0 is JArray) ? jtoken_0 : null);
											if (val2 != null)
											{
												Type elementType = type_0.GetElementType();
												Array array = Array.CreateInstance(elementType, ((JContainer)val2).Count);
												for (int i = 0; i < ((JContainer)val2).Count; i++)
												{
													object value2 = smethod_8(val2[i], elementType);
													array.SetValue(value2, i);
												}
												return array;
											}
										}
										if (type_0.IsClass)
										{
											string text = type_0.Namespace;
											if (text != null && text.StartsWith(Class16.smethod_0(1648941399)))
											{
												return jtoken_0.ToObject(type_0);
											}
										}
										try
										{
											return jtoken_0.ToObject(type_0);
										}
										catch
										{
											return null;
										}
									}
									return Extensions.Value<bool>((IEnumerable<JToken>)jtoken_0);
								}
								return Extensions.Value<double>((IEnumerable<JToken>)jtoken_0);
							}
							return Extensions.Value<float>((IEnumerable<JToken>)jtoken_0);
						}
						return Extensions.Value<ulong>((IEnumerable<JToken>)jtoken_0);
					}
					return Extensions.Value<long>((IEnumerable<JToken>)jtoken_0);
				}
				return Extensions.Value<uint>((IEnumerable<JToken>)jtoken_0);
			}
			return Extensions.Value<int>((IEnumerable<JToken>)jtoken_0);
		}
		return null;
	}

	private static TargetParam smethod_9(JObject jobject_0)
	{
		if (jobject_0 == null)
		{
			return null;
		}
		TargetParam targetParam = new TargetParam();
		JToken obj = jobject_0[Class16.smethod_0(1648936012)];
		JObject val = (JObject)(object)((obj is JObject) ? obj : null);
		if (val != null && val[Class16.smethod_0(1648941098)] != null)
		{
			targetParam.Target = (EnumTarget)Extensions.Value<int>((IEnumerable<JToken>)val[Class16.smethod_0(1648941098)]);
		}
		JToken obj2 = jobject_0[Class16.smethod_0(1648936017)];
		targetParam.Occupations = ((obj2 != null) ? Extensions.Value<uint>((IEnumerable<JToken>)obj2) : 0u);
		JToken obj3 = jobject_0[Class16.smethod_0(1648936055)];
		int players;
		if (obj3 == null)
		{
			JToken obj4 = jobject_0[Class16.smethod_0(1648936035)];
			players = (int)((obj4 != null) ? Extensions.Value<uint>((IEnumerable<JToken>)obj4) : 0);
		}
		else
		{
			players = (int)Extensions.Value<uint>((IEnumerable<JToken>)obj3);
		}
		targetParam.Players = (uint)players;
		JToken obj5 = jobject_0[Class16.smethod_0(1648936069)];
		targetParam.Unk2 = ((obj5 != null) ? Extensions.Value<uint>((IEnumerable<JToken>)obj5) : 0u);
		JToken obj6 = jobject_0[Class16.smethod_0(1648936072)];
		targetParam.Unk3 = ((obj6 != null) ? Extensions.Value<uint>((IEnumerable<JToken>)obj6) : 0u);
		JToken obj7 = jobject_0[Class16.smethod_0(1648936083)];
		targetParam.Unk4 = ((obj7 != null) ? Extensions.Value<uint>((IEnumerable<JToken>)obj7) : 0u);
		return targetParam;
	}
}
