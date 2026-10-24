using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy.Conditions;
using ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;
using ACE.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACE.AIPolicyEditor.AIPolicy;

public static class JsonExporter
{
	private static class Class28
	{
		public static Func<CPolicyData, JObject> func_0;

		public static Func<CTriggerData, JObject> func_1;

		public static Func<IOperation, JObject> func_2;
	}

	[Serializable]
	private sealed class Class29
	{
		public static readonly Class29 class29_0 = new Class29();

		public static Func<BrowsableAttribute, bool> func_0;

		public static Func<PropertyInfo, bool> func_1;

		internal bool method_0(PropertyInfo propertyInfo_0)
		{
			if (propertyInfo_0.CanRead && propertyInfo_0.Name != Class16.smethod_0(1648936726) && propertyInfo_0.Name != Class16.smethod_0(1648936731) && propertyInfo_0.Name != Class16.smethod_0(1648936750))
			{
				return !propertyInfo_0.GetCustomAttributes(typeof(BrowsableAttribute), inherit: false).Cast<BrowsableAttribute>().Any(class29_0.method_1);
			}
			return false;
		}

		internal bool method_1(BrowsableAttribute browsableAttribute_0)
		{
			return !browsableAttribute_0.Browsable;
		}
	}

	public static void ExportPoliciesToJsonFile(IEnumerable<CPolicyData> policies, string filePath)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		if (policies == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648936760));
		}
		JArray val = new JArray((object)policies.Select(smethod_0));
		File.WriteAllText(filePath, ((JToken)val).ToString((Formatting)1), Encoding.UTF8);
	}

	public static void ExportTriggersToJsonFile(IEnumerable<CTriggerData> triggers, string filePath)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		if (triggers == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648936771));
		}
		JArray val = new JArray((object)triggers.Select(ConvertTriggerToJson));
		File.WriteAllText(filePath, ((JToken)val).ToString((Formatting)1), Encoding.UTF8);
	}

	public static void ExportOperationsToJsonFile(IEnumerable<IOperation> operations, int triggerVersion, string filePath)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		if (operations == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648936790));
		}
		JObject val = new JObject();
		val[Class16.smethod_0(1648936793)] = (triggerVersion);
		val[Class16.smethod_0(1648942657)] = (JToken)new JArray((object)operations.Select(ConvertOperationToJson));
		JObject val2 = val;
		File.WriteAllText(filePath, ((JToken)val2).ToString((Formatting)1), Encoding.UTF8);
	}

	private static JObject smethod_0(CPolicyData cpolicyData_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		JObject val = new JObject();
		val[Class16.smethod_0(1648941057)] = (cpolicyData_0.ID);
		val[Class16.smethod_0(1648942674)] = (cpolicyData_0.Version);
		val[Class16.smethod_0(1648942688)] = (JToken)new JArray((object)cpolicyData_0.Triggers.Select(ConvertTriggerToJson));
		return val;
	}

	public static JObject ConvertTriggerToJson(CTriggerData trigger)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected O, but got Unknown
		JObject val = new JObject();
		val[Class16.smethod_0(1648941057)] = (trigger.ID);
		val[Class16.smethod_0(1648942674)] = (trigger.Version);
		val[Class16.smethod_0(1648936731)] = (trigger.Name);
		val[Class16.smethod_0(1648936822)] = (trigger.Active);
		val[Class16.smethod_0(1648936827)] = (trigger.Run);
		val[Class16.smethod_0(1648936845)] = (trigger.AttackValid);
		val[Class16.smethod_0(1648936863)] = (JToken)(object)ConvertConditionToJson(trigger.RootConditon);
		val[Class16.smethod_0(1648942657)] = (JToken)new JArray((object)trigger.Operations.Select(ConvertOperationToJson));
		return val;
	}

	public static JObject ConvertConditionToJson(Condition condition)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		if (condition == null)
		{
			return null;
		}
		JObject val = new JObject();
		val[Class16.smethod_0(1648941057)] = (condition.ID);
		val[Class16.smethod_0(1648936875)] = (condition.Type);
		val[Class16.smethod_0(1648936894)] = (ACE.AIPolicyEditor.AIPolicy.Conditions.Conditions.GetName(condition.ID));
		val[Class16.smethod_0(1648941098)] = (JToken)new JArray(condition.Value ?? new object[0]);
		val[Class16.smethod_0(1648936909)] = (condition.SubNodeL);
		val[Class16.smethod_0(1648936924)] = (condition.SubNodeR);
		JObject val2 = val;
		if (condition.ConditionLeft != null)
		{
			val2[Class16.smethod_0(1648936931)] = (JToken)(object)ConvertConditionToJson(condition.ConditionLeft);
		}
		if (condition.ConditionRight != null)
		{
			val2[Class16.smethod_0(1648936959)] = (JToken)(object)ConvertConditionToJson(condition.ConditionRight);
		}
		return val2;
	}

	public static JObject ConvertOperationToJson(IOperation operation)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		JObject val = new JObject
		{
			[Class16.smethod_0(1648936726)] = (operation.OperID),
			[Class16.smethod_0(1648936731)] = (operation.Name),
			[Class16.smethod_0(1648936750)] = (operation.FromVersion),
			[Class16.smethod_0(1648936875)] = (operation.GetType().Name)
		};
		IEnumerable<PropertyInfo> enumerable = operation.GetType().GetProperties().Where(Class29.class29_0.method_0);
		foreach (PropertyInfo item in enumerable)
		{
			try
			{
				object value = item.GetValue(operation);
				if (value == null)
				{
					continue;
				}
				if (value is TargetParam targetParam_)
				{
					val[item.Name] = (JToken)(object)smethod_1(targetParam_);
					continue;
				}
				if (value is Enum)
				{
					val[item.Name] = (JToken)new JObject
					{
						[Class16.smethod_0(1648941098)] = (Convert.ToInt32(value)),
						[Class16.smethod_0(1648936731)] = (value.ToString())
					};
					continue;
				}
				if (!value.GetType().IsClass)
				{
					goto IL_0186;
				}
				string text = value.GetType().Namespace;
				if (text == null || !text.StartsWith(Class16.smethod_0(1648941399)))
				{
					goto IL_0186;
				}
				val[item.Name] = (JToken)(object)JObject.FromObject(value);
				goto end_IL_00bd;
				IL_0186:
				val[item.Name] = JToken.FromObject(value);
				end_IL_00bd:;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648935956));
				val[item.Name] = (Class16.smethod_0(1648935998) + ex.Message);
			}
		}
		return val;
	}

	private static JObject smethod_1(TargetParam targetParam_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		return new JObject
		{
			[Class16.smethod_0(1648936012)] = (JToken)new JObject
			{
				[Class16.smethod_0(1648941098)] = ((int)targetParam_0.Target),
				[Class16.smethod_0(1648936731)] = (targetParam_0.Target.ToString())
			},
			[Class16.smethod_0(1648936017)] = (targetParam_0.Occupations),
			[Class16.smethod_0(1648936035)] = (targetParam_0.Meter),
			[Class16.smethod_0(1648936055)] = (targetParam_0.Players),
			[Class16.smethod_0(1648936069)] = (targetParam_0.Unk2),
			[Class16.smethod_0(1648936072)] = (targetParam_0.Unk3),
			[Class16.smethod_0(1648936083)] = (targetParam_0.Unk4)
		};
	}
}
