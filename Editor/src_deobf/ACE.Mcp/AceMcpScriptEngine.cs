using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ACE.Mcp;

internal sealed class AceMcpScriptEngine : IAceMcpScriptEngine
{
	[Serializable]
	private sealed class Class235
	{
		public static readonly Class235 class235_0 = new Class235();

		public static Func<IAceMcpChangeOperation, object> func_0;

		internal object method_0(IAceMcpChangeOperation iaceMcpChangeOperation_0)
		{
			return iaceMcpChangeOperation_0.Describe();
		}
	}

	private readonly IAceMcpChangeSetStore iaceMcpChangeSetStore_0;

	public AceMcpScriptEngine(IAceMcpChangeSetStore changeSetStore)
	{
		iaceMcpChangeSetStore_0 = changeSetStore;
	}

	public object Run(JObject parameters)
	{
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		string text = AceMcpRuntime.GetString(parameters, Class16.smethod_0(1648962188));
		string text2 = AceMcpRuntime.GetString(parameters, Class16.smethod_0(1648906425));
		string text3 = AceMcpRuntime.GetString(parameters, Class16.smethod_0(1649126739));
		if (string.IsNullOrWhiteSpace(text) && string.IsNullOrWhiteSpace(text2))
		{
			throw new ArgumentException(Class16.smethod_0(1649125841));
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = File.ReadAllText(text2, Encoding.UTF8);
		}
		JObject val = smethod_0(text);
		string text4 = AceMcpRuntime.GetString(val, Class16.smethod_0(1649120769));
		string text5 = ((!string.IsNullOrWhiteSpace(text3)) ? text3 : text4);
		string text6 = (string.IsNullOrWhiteSpace(text5) ? Class16.smethod_0(1649130444) : text5.Trim().ToLowerInvariant());
		int num = ((JToken)val).Value<int?>((object)Class16.smethod_0(1649074689)) ?? 1;
		if (num != 1)
		{
			throw new InvalidOperationException(string.Format(Class16.smethod_0(1649120788), num));
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		JObject val2 = ((JToken)val).Value<JObject>((object)Class16.smethod_0(1649120824));
		if (val2 != null)
		{
			foreach (JProperty item in val2.Properties())
			{
				dictionary[item.Name] = item.Value.ToObject<object>();
			}
		}
		List<object> list = new List<object>();
		List<string> list2 = new List<string>();
		List<IAceMcpChangeOperation> list3 = new List<IAceMcpChangeOperation>();
		JArray val3 = ((JToken)val).Value<JArray>((object)Class16.smethod_0(1649120840));
		if (val3 != null && ((JContainer)val3).Count != 0)
		{
			int num2 = 0;
			string mode;
			string id;
			string[] domains;
			Dictionary<string, string> sourceFingerprints;
			int count;
			List<IAceMcpChangeOperation> operations;
			Func<IAceMcpChangeOperation, object> selector;
			while (true)
			{
				if (num2 < ((JContainer)val3).Count)
				{
					JToken obj = val3[num2];
					JObject val4 = (JObject)(object)((obj is JObject) ? obj : null);
					if (val4 != null)
					{
						string text7 = AceMcpRuntime.GetString(val4, Class16.smethod_0(1649014943));
						string text8 = AceMcpRuntime.GetString(val4, Class16.smethod_0(1649126614));
						if (!string.IsNullOrWhiteSpace(text7) && !string.IsNullOrWhiteSpace(text8))
						{
							JObject token = (JObject)(((object)((JToken)val4).Value<JObject>((object)Class16.smethod_0(1649126677))) ?? ((object)new JObject()));
							JObject parameters2 = (JObject)AceMcpRuntime.ResolveScriptToken((JToken)(object)token, dictionary);
							AceMcpCommandResult aceMcpCommandResult = AceMcpRuntime.DispatchInternal(text7, text8, parameters2);
							foreach (string warning in aceMcpCommandResult.Warnings)
							{
								list2.Add(warning);
							}
							object data = aceMcpCommandResult.Data;
							if (aceMcpCommandResult.HasOperations)
							{
								if ((text6 == Class16.smethod_0(1649130450) || text6 == Class16.smethod_0(1649130471) || text6 == Class16.smethod_0(1649130484)) ? true : false)
								{
									foreach (IAceMcpChangeOperation operation in aceMcpCommandResult.Operations)
									{
										operation.Apply();
									}
								}
								else
								{
									list3.AddRange(aceMcpCommandResult.Operations);
								}
							}
							dictionary[Class16.smethod_0(1649121004)] = data;
							dictionary[Class16.smethod_0(1649121015) + num2.ToString(CultureInfo.InvariantCulture)] = data;
							list.Add(new
							{
								index = num2,
								domain = text7,
								action = text8,
								operation_count = aceMcpCommandResult.Operations.Count,
								data = data
							});
							num2++;
							continue;
						}
						throw new InvalidOperationException(string.Format(Class16.smethod_0(1649120948), num2));
					}
					throw new InvalidOperationException(string.Format(Class16.smethod_0(1649120897), num2));
				}
				if ((text6 == Class16.smethod_0(1649130450) || text6 == Class16.smethod_0(1649130471) || text6 == Class16.smethod_0(1649130484)) ? true : false)
				{
					return new
					{
						ok = true,
						mode = Class16.smethod_0(1649130450),
						logs = list,
						warnings = list2,
						applied = true
					};
				}
				if (list3.Count == 0)
				{
					return new
					{
						ok = true,
						mode = Class16.smethod_0(1649130444),
						logs = list,
						warnings = list2,
						change_set_id = (string)null,
						can_apply = false,
						expires_on_reload = true
					};
				}
				AceMcpChangeSet aceMcpChangeSet = iaceMcpChangeSetStore_0.Create(list3, list2);
				mode = Class16.smethod_0(1649130444);
				id = aceMcpChangeSet.Id;
				domains = aceMcpChangeSet.SourceFingerprints.Keys.ToArray();
				sourceFingerprints = aceMcpChangeSet.SourceFingerprints;
				count = aceMcpChangeSet.Operations.Count;
				operations = aceMcpChangeSet.Operations;
				selector = Class235.class235_0.method_0;
				break;
			}
			return new
			{
				ok = true,
				mode = mode,
				logs = list,
				warnings = list2,
				change_set_id = id,
				domains = domains,
				source_fingerprints = sourceFingerprints,
				preview = new
				{
					operation_count = count,
					operations = operations.Select(selector).ToArray()
				},
				can_apply = true,
				expires_on_reload = true
			};
		}
		throw new InvalidOperationException(Class16.smethod_0(1649120860));
	}

	private static JObject smethod_0(string string_0)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		string text = string_0?.Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649121019));
		}
		if (!text.StartsWith(Class16.smethod_0(1648908124), StringComparison.Ordinal) && !text.StartsWith(Class16.smethod_0(1648924364), StringComparison.Ordinal))
		{
			IDeserializer val = ((BuilderSkeleton<DeserializerBuilder>)new DeserializerBuilder()).WithNamingConvention(CamelCaseNamingConvention.Instance).Build();
			object obj = val.Deserialize((TextReader)new StringReader(text));
			JToken val2 = JToken.FromObject(obj ?? new object());
			JObject val3 = (JObject)(object)((val2 is JObject) ? val2 : null);
			if (val3 != null)
			{
				return val3;
			}
			throw new InvalidOperationException(Class16.smethod_0(1649121095));
		}
		JToken val4 = JToken.Parse(text);
		JObject val5 = (JObject)(object)((val4 is JObject) ? val4 : null);
		if (val5 == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649121054));
		}
		return val5;
	}
}
