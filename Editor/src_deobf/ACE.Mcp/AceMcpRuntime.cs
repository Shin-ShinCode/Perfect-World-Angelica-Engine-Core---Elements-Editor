using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.AIPolicyEditor.AIPolicy;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.MainWindow;
using ACE.NpcGen;
using ACE.NpcGen.Classes;
using ACE.sTASKedit.Classes;
using ACE.sTASKedit.tasks.tasks.data;
using NCalc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACE.Mcp;

internal static class AceMcpRuntime
{
	private sealed class Class172
	{
		public eList eList_0;

		public Class190 class190_0;

		internal _003C_003Ef__AnonymousType24<int, int, string[]> method_0(int int_0)
		{
			Class191 @class = new Class191();
			@class.class172_0 = this;
			@class.int_0 = int_0;
			return _003C_003Ef__AnonymousType24.Create(
				@class.int_0,
				eList_0.getid(@class.int_0),
				eList_0.elementFields.Select(@class.method_0).ToArray()
			);
		}
	}

	private sealed class Class173 : IAceMcpDomainHandler
	{
		private sealed class Class174
		{
			public CTriggerData ctriggerData_0;

			public int int_0;

			public int int_1;

			public List<IOperation> list_0;

			public Func<CTriggerData, bool> func_0;

			internal bool method_0(int int_2)
			{
				if (int_2 >= 0)
				{
					return int_2 < ctriggerData_0.Operations.Count;
				}
				return false;
			}

			internal IOperation method_1(int int_2)
			{
				return (ctriggerData_0.Operations[int_2] as ICloneable)?.Clone() as IOperation;
			}

			internal void method_2()
			{
				CTriggerData cTriggerData = RequireAIPolicy().GetControllerById(int_0).Triggers.First(method_3);
				foreach (IOperation item in list_0)
				{
					cTriggerData.Operations.Add(((item as ICloneable)?.Clone() as IOperation) ?? item);
				}
			}

			internal bool method_3(CTriggerData ctriggerData_1)
			{
				return ctriggerData_1.ID == int_1;
			}
		}

		private sealed class Class175
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public Func<CTriggerData, bool> func_0;

			internal void method_0()
			{
				CTriggerData cTriggerData = RequireAIPolicy().GetControllerById(int_0).Triggers.First(method_1);
				cTriggerData.Operations.Add(Operation.Read(null, cTriggerData.Version, int_2));
			}

			internal bool method_1(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_1;
			}
		}

		private sealed class Class176
		{
			public int int_0;

			public int int_1;

			internal void method_0()
			{
				CPolicyData controllerById = RequireAIPolicy().GetControllerById(int_0);
				controllerById.Triggers.Add(new CTriggerData
				{
					ID = int_1,
					Version = CTriggerData.MaxVersion
				});
			}
		}

		private sealed class Class177
		{
			public int int_0;

			internal bool method_0(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_0;
			}
		}

		private sealed class Class178
		{
			public List<CPolicyData> list_0;

			internal void method_0()
			{
				AIFile aIFile = RequireAIPolicy();
				foreach (CPolicyData item in list_0)
				{
					aIFile.Controllers.Add(item.Clone() as CPolicyData);
				}
			}
		}

		private sealed class Class179
		{
			public int int_0;

			public int[] int_1;

			internal void method_0()
			{
				CPolicyData controllerById = RequireAIPolicy().GetControllerById(int_0);
				int[] array = int_1;
				for (int i = 0; i < array.Length; i++)
				{
					Class183 @class = new Class183();
					@class.int_0 = array[i];
					CTriggerData cTriggerData = controllerById.Triggers.FirstOrDefault(@class.method_0);
					if (cTriggerData != null)
					{
						controllerById.Triggers.Remove(cTriggerData);
					}
				}
			}
		}

		private sealed class Class180
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public Dictionary<string, JToken> dictionary_0;

			public Func<CTriggerData, bool> func_0;

			internal void method_0()
			{
				IOperation target = RequireAIPolicy().GetControllerById(int_0).Triggers.First(method_1).Operations[int_2];
				foreach (KeyValuePair<string, JToken> item in dictionary_0)
				{
					SetMemberValue(target, item.Key, item.Value);
				}
			}

			internal bool method_1(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_1;
			}
		}

		private sealed class Class181
		{
			public int int_0;

			public int int_1;

			public string string_0;

			public Func<CTriggerData, bool> func_0;

			internal void method_0()
			{
				CTriggerData cTriggerData = RequireAIPolicy().GetControllerById(int_0).Triggers.First(method_1);
				cTriggerData.Name = string_0;
			}

			internal bool method_1(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_1;
			}
		}

		private sealed class Class182
		{
			public int int_0;

			internal bool method_0(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_0;
			}
		}

		private sealed class Class183
		{
			public int int_0;

			internal bool method_0(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_0;
			}
		}

		private sealed class Class184
		{
			public int int_0;

			public int int_1;

			public int[] int_2;

			public Func<CTriggerData, bool> func_0;

			internal void method_0()
			{
				CTriggerData cTriggerData = RequireAIPolicy().GetControllerById(int_0).Triggers.First(method_1);
				int[] array = int_2;
				foreach (int num in array)
				{
					if (num >= 0 && num < cTriggerData.Operations.Count)
					{
						cTriggerData.Operations.RemoveAt(num);
					}
				}
			}

			internal bool method_1(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_1;
			}
		}

		private sealed class Class185
		{
			public int int_0;

			internal void method_0()
			{
				AIFile aIFile = RequireAIPolicy();
				aIFile.Controllers.Add(new CPolicyData
				{
					ID = int_0,
					Version = CPolicyData.MaxVersion
				});
			}
		}

		private sealed class Class186
		{
			public int int_0;

			public List<CTriggerData> list_0;

			internal void method_0()
			{
				CPolicyData controllerById = RequireAIPolicy().GetControllerById(int_0);
				foreach (CTriggerData item in list_0)
				{
					controllerById.Triggers.Add(item.Clone() as CTriggerData);
				}
			}
		}

		[Serializable]
		private sealed class Class187
		{
			public static readonly Class187 class187_0 = new Class187();

			public static Func<CPolicyData, _003C_003Ef__AnonymousType27<int, int, int>> func_0;

			public static Func<CPolicyData, int> func_1;

			public static Func<CPolicyData, int> func_2;

			public static Func<CPolicyData, _003C_003Ef__AnonymousType82<int, int>> func_3;

			public static Func<CPolicyData, int> func_4;

			public static Func<CTriggerData, int> func_5;

			public static Func<CTriggerData, int> func_6;

			public static Func<CTriggerData, _003C_003Ef__AnonymousType86<int, string>> func_7;

			public static Func<CTriggerData, int> func_8;

			public static Func<IOperation, bool> func_9;

			public static Func<IOperation, string> func_10;

			public static Func<int, int> func_11;

			public static Func<KeyValuePair<string, JToken>, string> func_12;

			public static Func<KeyValuePair<string, JToken>, JToken> func_13;

			internal _003C_003Ef__AnonymousType27<int, int, int> method_0(CPolicyData cpolicyData_0)
			{
				return _003C_003Ef__AnonymousType27.Create(
					cpolicyData_0.ID,
					cpolicyData_0.Version,
					(cpolicyData_0.Triggers?.Count ?? 0)
				);
			}

			internal int method_1(CPolicyData cpolicyData_0)
			{
				return cpolicyData_0.ID;
			}

			internal int method_2(CPolicyData cpolicyData_0)
			{
				return cpolicyData_0.ID;
			}

			internal _003C_003Ef__AnonymousType82<int, int> method_3(CPolicyData cpolicyData_0)
			{
				return _003C_003Ef__AnonymousType82.Create(
					cpolicyData_0.ID,
					(cpolicyData_0.Triggers?.Count ?? 0)
				);
			}

			internal int method_4(CPolicyData cpolicyData_0)
			{
				return cpolicyData_0.ID;
			}

			internal int method_5(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID;
			}

			internal int method_6(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID;
			}

			internal _003C_003Ef__AnonymousType86<int, string> method_7(CTriggerData ctriggerData_0)
			{
				return _003C_003Ef__AnonymousType86.Create(
					ctriggerData_0.ID,
					ctriggerData_0.Name
				);
			}

			internal int method_8(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID;
			}

			internal bool method_9(IOperation ioperation_0)
			{
				return ioperation_0 != null;
			}

			internal string method_10(IOperation ioperation_0)
			{
				return ioperation_0.GetType().Name;
			}

			internal int method_11(int int_0)
			{
				return int_0;
			}

			internal string method_12(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}

			internal JToken method_13(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Value.DeepClone();
			}
		}

		private sealed class Class188
		{
			public int int_0;

			internal bool method_0(CTriggerData ctriggerData_0)
			{
				return ctriggerData_0.ID == int_0;
			}
		}

		private sealed class Class189
		{
			public int[] int_0;

			internal void method_0()
			{
				AIFile aIFile = RequireAIPolicy();
				int[] array = int_0;
				foreach (int controllerId in array)
				{
					CPolicyData controllerById = aIFile.GetControllerById(controllerId);
					if (controllerById != null)
					{
						aIFile.Controllers.Remove(controllerById);
					}
				}
			}
		}

		public string Domain => Class16.smethod_0(1648942729);

		public string GetFingerprint()
		{
			return AceMcpRuntime.smethod_7();
		}

		public AceMcpCommandResult Execute(string action, JObject parameters)
		{
			string text = (action ?? string.Empty).Trim().ToLowerInvariant();
			if (text != null)
			{
				switch (text.Length)
				{
				case 11:
					switch (text[0])
					{
					case 'g':
						if (text == Class16.smethod_0(1649129720))
						{
							return smethod_2(parameters);
						}
						break;
					case 'a':
						if (text == Class16.smethod_0(1649129738))
						{
							return smethod_7(parameters);
						}
						break;
					}
					break;
				case 13:
					switch (text[0])
					{
					case 'g':
						if (text == Class16.smethod_0(1649129764))
						{
							return smethod_3(parameters);
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649129776))
						{
							return smethod_8(parameters);
						}
						break;
					case 'a':
						if (text == Class16.smethod_0(1649129804))
						{
							return smethod_11(parameters);
						}
						break;
					}
					break;
				case 14:
					switch (text[2])
					{
					case 'm':
						if (text == Class16.smethod_0(1649129686))
						{
							return smethod_9(parameters);
						}
						break;
					case 'd':
						if (text == Class16.smethod_0(1649129657))
						{
							return smethod_4();
						}
						break;
					case 't':
						if (text == Class16.smethod_0(1649129644))
						{
							return smethod_1(parameters);
						}
						break;
					case 'n':
						if (text == Class16.smethod_0(1649129699))
						{
							return smethod_10(parameters);
						}
						break;
					}
					break;
				case 15:
					switch (text[0])
					{
					case 'g':
						if (text == Class16.smethod_0(1649129592))
						{
							return smethod_0();
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649129622))
						{
							return smethod_12(parameters);
						}
						break;
					}
					break;
				case 16:
					switch (text[0])
					{
					case 'r':
						if (text == Class16.smethod_0(1649129847))
						{
							return smethod_13(parameters);
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649129816))
						{
							return smethod_5(parameters);
						}
						break;
					}
					break;
				case 17:
					if (text == Class16.smethod_0(1649129870))
					{
						return smethod_6(parameters);
					}
					break;
				case 20:
					if (text == Class16.smethod_0(1649129894))
					{
						return smethod_14(parameters);
					}
					break;
				}
			}
			throw new InvalidOperationException(Class16.smethod_0(1649129913) + action + Class16.smethod_0(1648928156));
		}

		private static AceMcpCommandResult smethod_0()
		{
			AIFile aIFile = RequireAIPolicy();
			return new AceMcpCommandResult
			{
				Data = new
				{
					header = aIFile.Header,
					controllers = aIFile.Controllers.Select((CPolicyData cpolicyData_0) => _003C_003Ef__AnonymousType27.Create(
						cpolicyData_0.ID,
						cpolicyData_0.Version,
						(cpolicyData_0.Triggers?.Count ?? 0)
					)).ToArray()
				}
			};
		}

		private static AceMcpCommandResult smethod_1(JObject jobject_0)
		{
			AIFile aIFile = RequireAIPolicy();
			int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649129957)) ?? throw new InvalidOperationException(Class16.smethod_0(1649129969));
			CPolicyData controllerById = aIFile.GetControllerById(num);
			return new AceMcpCommandResult
			{
				Data = new
				{
					found = (controllerById != null),
					controller_id = num,
					controller = controllerById
				}
			};
		}

		private static AceMcpCommandResult smethod_2(JObject jobject_0)
		{
			Class177 @class = new Class177();
			CPolicyData cPolicyData = smethod_15(jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124902)) ?? throw new InvalidOperationException(Class16.smethod_0(1649124919));
			CTriggerData cTriggerData = cPolicyData.Triggers?.FirstOrDefault(@class.method_0);
			return new AceMcpCommandResult
			{
				Data = new
				{
					found = (cTriggerData != null),
					controller_id = cPolicyData.ID,
					trigger_id = @class.int_0,
					trigger = cTriggerData
				}
			};
		}

		private static AceMcpCommandResult smethod_3(JObject jobject_0)
		{
			CTriggerData cTriggerData = smethod_16(jobject_0);
			int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124953)) ?? throw new InvalidOperationException(Class16.smethod_0(1649124983));
			IOperation operation = ((num < 0 || num >= cTriggerData.Operations.Count) ? null : cTriggerData.Operations[num]);
			return new AceMcpCommandResult
			{
				Data = new
				{
					found = (operation != null),
					operation_index = num,
					operation = operation
				}
			};
		}

		private static AceMcpCommandResult smethod_4()
		{
			Class185 @class = new Class185();
			AIFile aIFile = RequireAIPolicy();
			@class.int_0 = ((aIFile.Controllers.Count <= 0) ? 1 : (((IEnumerable<CPolicyData>)aIFile.Controllers).Max((Func<CPolicyData, int>)Class187.class187_0.method_1) + 1));
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = @class.int_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129657), new
			{
				controller_id = @class.int_0
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_5(JObject jobject_0)
		{
			Class178 @class = new Class178();
			AIFile aIFile = RequireAIPolicy();
			@class.list_0 = new List<CPolicyData>();
			int num = ((aIFile.Controllers.Count <= 0) ? 1 : (((IEnumerable<CPolicyData>)aIFile.Controllers).Max((Func<CPolicyData, int>)Class187.class187_0.method_2) + 1));
			foreach (int item in ParseIntList(jobject_0, Class16.smethod_0(1649125030)))
			{
				CPolicyData controllerById = aIFile.GetControllerById(item);
				if (controllerById != null)
				{
					CPolicyData cPolicyData = controllerById.Clone() as CPolicyData;
					cPolicyData.ID = num++;
					@class.list_0.Add(cPolicyData);
				}
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controllers = @class.list_0.Select((CPolicyData cpolicyData_0) => _003C_003Ef__AnonymousType82.Create(
						cpolicyData_0.ID,
						(cpolicyData_0.Triggers?.Count ?? 0)
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129816), new
			{
				controller_ids = @class.list_0.Select(Class187.class187_0.method_4).ToArray()
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_6(JObject jobject_0)
		{
			Class189 @class = new Class189();
			@class.int_0 = ParseIntList(jobject_0, Class16.smethod_0(1649125030)).ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_ids = @class.int_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129870), new
			{
				controller_ids = @class.int_0
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_7(JObject jobject_0)
		{
			Class176 @class = new Class176();
			CPolicyData cPolicyData = smethod_15(jobject_0);
			@class.int_1 = ((cPolicyData.Triggers.Count > 0) ? (((IEnumerable<CTriggerData>)cPolicyData.Triggers).Max((Func<CTriggerData, int>)Class187.class187_0.method_5) + 1) : 0);
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = cPolicyData.ID,
					trigger_id = @class.int_1
				}
			};
			@class.int_0 = cPolicyData.ID;
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129738), new
			{
				controller_id = @class.int_0,
				trigger_id = @class.int_1
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_8(JObject jobject_0)
		{
			Class186 @class = new Class186();
			CPolicyData cPolicyData = smethod_15(jobject_0);
			@class.list_0 = new List<CTriggerData>();
			int num = ((cPolicyData.Triggers.Count > 0) ? (((IEnumerable<CTriggerData>)cPolicyData.Triggers).Max((Func<CTriggerData, int>)Class187.class187_0.method_6) + 1) : 0);
			using (List<int>.Enumerator enumerator = ParseIntList(jobject_0, Class16.smethod_0(1649125043)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Class182 class2 = new Class182();
					class2.int_0 = enumerator.Current;
					CTriggerData cTriggerData = cPolicyData.Triggers.FirstOrDefault(class2.method_0);
					if (cTriggerData != null)
					{
						CTriggerData cTriggerData2 = cTriggerData.Clone() as CTriggerData;
						cTriggerData2.ID = num++;
						@class.list_0.Add(cTriggerData2);
					}
				}
			}
			@class.int_0 = cPolicyData.ID;
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = @class.int_0,
					triggers = @class.list_0.Select((CTriggerData ctriggerData_0) => _003C_003Ef__AnonymousType86.Create(
						ctriggerData_0.ID,
						ctriggerData_0.Name
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129776), new
			{
				controller_id = @class.int_0,
				trigger_ids = @class.list_0.Select(Class187.class187_0.method_8).ToArray()
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_9(JObject jobject_0)
		{
			Class179 @class = new Class179();
			CPolicyData cPolicyData = smethod_15(jobject_0);
			@class.int_0 = cPolicyData.ID;
			@class.int_1 = ParseIntList(jobject_0, Class16.smethod_0(1649125043)).ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = @class.int_0,
					trigger_ids = @class.int_1
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129686), new
			{
				controller_id = @class.int_0,
				trigger_ids = @class.int_1
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_10(JObject jobject_0)
		{
			Class181 @class = new Class181();
			CTriggerData cTriggerData = smethod_16(jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649129957));
			@class.int_1 = cTriggerData.ID;
			@class.string_0 = GetString(jobject_0, Class16.smethod_0(1648905100)) ?? throw new InvalidOperationException(Class16.smethod_0(1649125069));
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = @class.int_0,
					trigger_id = @class.int_1,
					old_name = cTriggerData.Name,
					new_name = @class.string_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129699), new
			{
				controller_id = @class.int_0,
				trigger_id = @class.int_1,
				new_name = @class.string_0
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_11(JObject jobject_0)
		{
			Class175 @class = new Class175();
			CTriggerData cTriggerData = smethod_16(jobject_0);
			@class.int_2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649125097)) ?? throw new InvalidOperationException(Class16.smethod_0(1649125124));
			IOperation operation = Operation.Read(null, cTriggerData.Version, @class.int_2);
			if (operation == null)
			{
				throw new InvalidOperationException(string.Format(Class16.smethod_0(1649125160), @class.int_2));
			}
			@class.int_0 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649129957));
			@class.int_1 = cTriggerData.ID;
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = @class.int_0,
					trigger_id = @class.int_1,
					operation_id = @class.int_2,
					operation_type = operation.GetType().Name
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129804), new
			{
				controller_id = @class.int_0,
				trigger_id = @class.int_1,
				operation_id = @class.int_2
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_12(JObject jobject_0)
		{
			Class174 @class = new Class174();
			@class.ctriggerData_0 = smethod_16(jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649129957));
			@class.int_1 = @class.ctriggerData_0.ID;
			@class.list_0 = ParseIntList(jobject_0, Class16.smethod_0(1649125194)).Where(@class.method_0).Select(@class.method_1).Where(Class187.class187_0.method_9)
				.ToList();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = @class.int_0,
					trigger_id = @class.int_1,
					cloned = @class.list_0.Select(Class187.class187_0.method_10).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129622), new
			{
				controller_id = @class.int_0,
				trigger_id = @class.int_1,
				operation_count = @class.list_0.Count
			}, @class.method_2));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_13(JObject jobject_0)
		{
			Class184 @class = new Class184();
			CTriggerData cTriggerData = smethod_16(jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649129957));
			@class.int_1 = cTriggerData.ID;
			@class.int_2 = ParseIntList(jobject_0, Class16.smethod_0(1649125194)).Distinct().OrderByDescending(Class187.class187_0.method_11).ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					controller_id = @class.int_0,
					trigger_id = @class.int_1,
					operation_indexes = @class.int_2
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129847), new
			{
				controller_id = @class.int_0,
				trigger_id = @class.int_1,
				operation_indexes = @class.int_2
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_14(JObject jobject_0)
		{
			Class180 @class = new Class180();
			CTriggerData cTriggerData = smethod_16(jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649129957));
			@class.int_1 = cTriggerData.ID;
			@class.int_2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124953)) ?? throw new InvalidOperationException(Class16.smethod_0(1649124983));
			if (@class.int_2 >= 0 && @class.int_2 < cTriggerData.Operations.Count)
			{
				Dictionary<string, JToken> dictionary = ParseFieldMap(jobject_0, Class16.smethod_0(1649125271));
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
				IOperation target = cTriggerData.Operations[@class.int_2];
				foreach (KeyValuePair<string, JToken> item in dictionary)
				{
					dictionary2[item.Key] = GetMemberValue(target, item.Key);
				}
				@class.dictionary_0 = dictionary.ToDictionary(Class187.class187_0.method_12, Class187.class187_0.method_13, StringComparer.OrdinalIgnoreCase);
				AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
				{
					Data = new
					{
						controller_id = @class.int_0,
						trigger_id = @class.int_1,
						operation_index = @class.int_2,
						old_values = dictionary2,
						new_values = @class.dictionary_0
					}
				};
				aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648942729), Class16.smethod_0(1649129894), new
				{
					controller_id = @class.int_0,
					trigger_id = @class.int_1,
					operation_index = @class.int_2,
					fields = @class.dictionary_0.Keys.ToArray()
				}, @class.method_0));
				return aceMcpCommandResult;
			}
			throw new InvalidOperationException(string.Format(Class16.smethod_0(1649125218), @class.int_2));
		}

		private static CPolicyData smethod_15(JObject jobject_0)
		{
			AIFile aIFile = RequireAIPolicy();
			int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649129957)) ?? throw new InvalidOperationException(Class16.smethod_0(1649129969));
			CPolicyData controllerById = aIFile.GetControllerById(num);
			if (controllerById == null)
			{
				throw new InvalidOperationException(string.Format(Class16.smethod_0(1649125281), num));
			}
			return controllerById;
		}

		private static CTriggerData smethod_16(JObject jobject_0)
		{
			Class188 @class = new Class188();
			CPolicyData cPolicyData = smethod_15(jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124902)) ?? throw new InvalidOperationException(Class16.smethod_0(1649124919));
			CTriggerData cTriggerData = cPolicyData.Triggers?.FirstOrDefault(@class.method_0);
			if (cTriggerData == null)
			{
				throw new InvalidOperationException(string.Format(Class16.smethod_0(1649125327), @class.int_0, cPolicyData.ID));
			}
			return cTriggerData;
		}
	}

	private sealed class Class190
	{
		public eListCollection eListCollection_0;

		internal eList method_0(int int_0)
		{
			return eListCollection_0.Lists[int_0];
		}

		internal eList method_1(int int_0)
		{
			return eListCollection_0.Lists[int_0];
		}

		internal _003C_003Ef__AnonymousType23<int, string, string[], _003C_003Ef__AnonymousType24<int, int, string[]>[]> method_2(eList eList_0)
		{
			Class172 CS_0024_003C_003E8__locals9 = new Class172();
			CS_0024_003C_003E8__locals9.class190_0 = this;
			CS_0024_003C_003E8__locals9.eList_0 = eList_0;
			return _003C_003Ef__AnonymousType23.Create(
				CS_0024_003C_003E8__locals9.eList_0.ListIndex,
				CS_0024_003C_003E8__locals9.eList_0.uListName,
				CS_0024_003C_003E8__locals9.eList_0.elementFields,
				Enumerable.Range(0, CS_0024_003C_003E8__locals9.eList_0.ItemCount).Select(delegate(int int_0)
				{
					Class191 @class = new Class191();
					@class.class172_0 = CS_0024_003C_003E8__locals9;
					@class.int_0 = int_0;
					return _003C_003Ef__AnonymousType24.Create(
						@class.int_0,
						CS_0024_003C_003E8__locals9.eList_0.getid(@class.int_0),
						CS_0024_003C_003E8__locals9.eList_0.elementFields.Select(@class.method_0).ToArray()
					);
				}).ToArray()
			);
		}
	}

	private sealed class Class191
	{
		public int int_0;

		public Class172 class172_0;

		internal string method_0(string string_0)
		{
			return class172_0.class190_0.eListCollection_0.GetValue(class172_0.eList_0.ListIndex, int_0, string_0);
		}
	}

	private sealed class Class192 : IAceMcpDomainHandler
	{
		private sealed class Class193 : IEnumerable, IEnumerator, IDisposable, IEnumerable<ATaskTempl>, IEnumerator<ATaskTempl>
		{
			private int int_0;

			private ATaskTempl ataskTempl_0;

			private int int_1;

			private IEnumerable<ATaskTempl> ienumerable_0;

			public IEnumerable<ATaskTempl> ienumerable_1;

			private IEnumerator<ATaskTempl> ienumerator_0;

			private ATaskTempl ataskTempl_1;

			private IEnumerator<ATaskTempl> ienumerator_1;

			ATaskTempl IEnumerator<ATaskTempl>.Current
			{
				[DebuggerHidden]
				get
				{
					return ataskTempl_0;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ataskTempl_0;
				}
			}

			[DebuggerHidden]
			public Class193(int int_2)
			{
				int_0 = int_2;
				int_1 = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = int_0;
				if ((uint)(num - -4) <= 1u || (uint)(num - 1) <= 1u)
				{
					try
					{
						if (num == -4 || num == 2)
						{
							try
							{
							}
							finally
							{
								method_1();
							}
						}
					}
					finally
					{
						method_0();
					}
				}
				ienumerator_0 = null;
				ataskTempl_1 = null;
				ienumerator_1 = null;
				int_0 = -2;
			}

			private bool MoveNext()
			{
				try
				{
					ATaskTempl current;
					switch (int_0)
					{
					default:
						return false;
					case 0:
						int_0 = -1;
						if (ienumerable_0 == null)
						{
							return false;
						}
						ienumerator_0 = ienumerable_0.GetEnumerator();
						int_0 = -3;
						goto IL_00cf;
					case 1:
						int_0 = -3;
						if (ataskTempl_1.pSub != null)
						{
							ienumerator_1 = smethod_9(ataskTempl_1.pSub).GetEnumerator();
							int_0 = -4;
							goto IL_0093;
						}
						goto IL_00cf;
					case 2:
						{
							int_0 = -4;
							goto IL_0093;
						}
						IL_0093:
						if (!ienumerator_1.MoveNext())
						{
							method_1();
							ienumerator_1 = null;
							ataskTempl_1 = null;
							goto IL_00cf;
						}
						current = ienumerator_1.Current;
						ataskTempl_0 = current;
						int_0 = 2;
						return true;
						IL_00cf:
						do
						{
							if (ienumerator_0.MoveNext())
							{
								ataskTempl_1 = ienumerator_0.Current;
								continue;
							}
							method_0();
							ienumerator_0 = null;
							return false;
						}
						while (ataskTempl_1 == null);
						ataskTempl_0 = ataskTempl_1;
						int_0 = 1;
						return true;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void method_0()
			{
				int_0 = -1;
				if (ienumerator_0 != null)
				{
					ienumerator_0.Dispose();
				}
			}

			private void method_1()
			{
				int_0 = -3;
				if (ienumerator_1 != null)
				{
					ienumerator_1.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ATaskTempl> IEnumerable<ATaskTempl>.GetEnumerator()
			{
				Class193 @class;
				if (int_0 == -2 && int_1 == Environment.CurrentManagedThreadId)
				{
					int_0 = 0;
					@class = this;
				}
				else
				{
					@class = new Class193(0);
				}
				@class.ienumerable_0 = ienumerable_1;
				return @class;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ATaskTempl>)this).GetEnumerator();
			}
		}

		private sealed class Class194
		{
			public int int_0;

			public int int_1;

			internal void method_0()
			{
				TASKS tASKS = RequireTasks();
				Class198 @class = smethod_10(tASKS.QuestsArray, null, int_0, 0);
				if (@class == null)
				{
					throw new InvalidOperationException(string.Format(Class16.smethod_0(1649127140), int_0));
				}
				ATaskTempl gparam_ = @class.method_0();
				if (@class.method_2() == null)
				{
					tASKS.QuestsArray = smethod_25(tASKS.QuestsArray, @class.method_6());
				}
				else
				{
					@class.method_2().pSub = smethod_25(@class.method_2().pSub, @class.method_6());
					@class.method_2().m_nSubCount = @class.method_2().pSub.Length;
					smethod_23(@class.method_2());
				}
				if (int_1 > 0)
				{
					ATaskTempl quest = tASKS.GetQuest(int_1);
					if (quest == null)
					{
						throw new InvalidOperationException(string.Format(Class16.smethod_0(1649127172), int_1));
					}
					quest.pSub = smethod_24(quest.pSub, gparam_);
					quest.m_nSubCount = quest.pSub.Length;
					smethod_23(quest);
				}
				else
				{
					tASKS.QuestsArray = smethod_24(tASKS.QuestsArray, gparam_);
				}
				smethod_22(tASKS.QuestsArray, null);
				smethod_11(tASKS);
			}
		}

		private sealed class Class195
		{
			public int int_0;

			public ATaskTempl ataskTempl_0;

			internal void method_0()
			{
				TASKS tASKS = RequireTasks();
				if (int_0 > 0)
				{
					ATaskTempl quest = tASKS.GetQuest(int_0);
					if (quest == null)
					{
						throw new InvalidOperationException(string.Format(Class16.smethod_0(1649127172), int_0));
					}
					quest.pSub = smethod_24(quest.pSub, smethod_26(ataskTempl_0));
					quest.m_nSubCount = quest.pSub.Length;
					smethod_23(quest);
				}
				else
				{
					tASKS.QuestsArray = smethod_24(tASKS.QuestsArray, smethod_26(ataskTempl_0));
				}
				smethod_22(tASKS.QuestsArray, null);
				smethod_11(tASKS);
			}
		}

		private sealed class Class196
		{
			public int int_0;

			public Dictionary<string, JToken> dictionary_0;

			internal void method_0()
			{
				TASKS tASKS = RequireTasks();
				ATaskTempl quest = tASKS.GetQuest(int_0);
				if (quest == null)
				{
					throw new InvalidOperationException(string.Format(Class16.smethod_0(1649127140), int_0));
				}
				foreach (KeyValuePair<string, JToken> item in dictionary_0)
				{
					SetMemberValue(quest, item.Key, item.Value);
				}
				smethod_11(tASKS);
			}
		}

		private sealed class Class197
		{
			public List<(int, ATaskTempl)> list_0;

			public int int_0;

			internal void method_0()
			{
				TASKS tASKS = RequireTasks();
				foreach (var item in list_0)
				{
					if (int_0 > 0)
					{
						ATaskTempl quest = tASKS.GetQuest(int_0);
						if (quest == null)
						{
							throw new InvalidOperationException(string.Format(Class16.smethod_0(1649127172), int_0));
						}
						quest.pSub = smethod_24(quest.pSub, smethod_26(item.Item2));
						quest.m_nSubCount = quest.pSub.Length;
						smethod_23(quest);
					}
					else
					{
						tASKS.QuestsArray = smethod_24(tASKS.QuestsArray, smethod_26(item.Item2));
					}
				}
				smethod_22(tASKS.QuestsArray, null);
				smethod_11(tASKS);
			}
		}

		private sealed class Class198
		{
			private ATaskTempl ataskTempl_0;

			private ATaskTempl ataskTempl_1;

			private ATaskTempl[] ataskTempl_2;

			private int int_0;

			private int int_1;

			public ATaskTempl method_0()
			{
				return ataskTempl_0;
			}

			public void method_1(ATaskTempl ataskTempl_3)
			{
				ataskTempl_0 = ataskTempl_3;
			}

			public ATaskTempl method_2()
			{
				return ataskTempl_1;
			}

			public void method_3(ATaskTempl ataskTempl_3)
			{
				ataskTempl_1 = ataskTempl_3;
			}

			public ATaskTempl[] method_4()
			{
				return ataskTempl_2;
			}

			public void method_5(ATaskTempl[] ataskTempl_3)
			{
				ataskTempl_2 = ataskTempl_3;
			}

			public int method_6()
			{
				return int_0;
			}

			public void method_7(int int_2)
			{
				int_0 = int_2;
			}

			public int method_8()
			{
				return int_1;
			}

			public void method_9(int int_2)
			{
				int_1 = int_2;
			}
		}

		private sealed class Class199
		{
			public Dictionary<int, int> dictionary_0;

			internal void method_0()
			{
				TASKS tASKS = RequireTasks();
				foreach (ATaskTempl item in smethod_9(tASKS.QuestsArray))
				{
					smethod_15(item, dictionary_0);
				}
				foreach (ATaskTempl item2 in smethod_9(tASKS.QuestsArray))
				{
					int? num = FindTaskIdInReplacementMap(dictionary_0, item2.ID);
					if (num.HasValue)
					{
						int iD = item2.ID;
						item2.ID = num.Value;
						smethod_19(item2, iD, num.Value);
					}
				}
				smethod_22(tASKS.QuestsArray, null);
				smethod_11(tASKS);
			}
		}

		[Serializable]
		private sealed class Class200
		{
			public static readonly Class200 class200_0 = new Class200();

			public static Func<KeyValuePair<string, JToken>, string> func_0;

			public static Func<KeyValuePair<string, JToken>, JToken> func_1;

			public static Func<KeyValuePair<string, JToken>, string> func_2;

			public static Func<KeyValuePair<string, JToken>, JToken> func_3;

			public static Func<(int, ATaskTempl), _003C_003Ef__AnonymousType65<int, int, string>> func_4;

			public static Func<(int, ATaskTempl), int> func_5;

			public static Func<Class198, bool> func_6;

			public static Func<Class198, int> func_7;

			public static Func<Class198, _003C_003Ef__AnonymousType69<int, int, int>> func_8;

			public static Func<Class198, int> func_9;

			public static Func<Class198, int> func_10;

			public static Func<JProperty, int> func_11;

			public static Func<JProperty, int> func_12;

			public static Func<KeyValuePair<int, int>, _003C_003Ef__AnonymousType74<int, int>> func_13;

			internal string method_0(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}

			internal JToken method_1(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Value;
			}

			internal string method_2(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}

			internal JToken method_3(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Value.DeepClone();
			}

			internal _003C_003Ef__AnonymousType65<int, int, string> method_4((int, ATaskTempl) valueTuple_0)
			{
				return _003C_003Ef__AnonymousType65.Create(
					valueTuple_0.Item1,
					valueTuple_0.Item2.ID,
					valueTuple_0.Item2.Name
				);
			}

			internal int method_5((int, ATaskTempl) valueTuple_0)
			{
				return valueTuple_0.Item1;
			}

			internal bool method_6(Class198 class198_0)
			{
				return class198_0 != null;
			}

			internal int method_7(Class198 class198_0)
			{
				return class198_0.method_8();
			}

			internal _003C_003Ef__AnonymousType69<int, int, int> method_8(Class198 class198_0)
			{
				return _003C_003Ef__AnonymousType69.Create(
					class198_0.method_0().ID,
					class198_0.method_8(),
					(class198_0.method_2()?.ID ?? 0)
				);
			}

			internal int method_9(Class198 class198_0)
			{
				return class198_0.method_0().ID;
			}

			internal int method_10(Class198 class198_0)
			{
				return class198_0.method_8();
			}

			internal int method_11(JProperty jproperty_0)
			{
				return int.Parse(jproperty_0.Name, CultureInfo.InvariantCulture);
			}

			internal int method_12(JProperty jproperty_0)
			{
				return Extensions.Value<int>((IEnumerable<JToken>)jproperty_0.Value);
			}

			internal _003C_003Ef__AnonymousType74<int, int> method_13(KeyValuePair<int, int> keyValuePair_0)
			{
				return _003C_003Ef__AnonymousType74.Create(
					keyValuePair_0.Key,
					keyValuePair_0.Value
				);
			}
		}

		private sealed class Class201
		{
			public TASKS tasks_0;

			public List<Class198> list_0;

			internal Class198 method_0(int int_0)
			{
				return smethod_10(tasks_0.QuestsArray, null, int_0, 0);
			}

			internal void method_1()
			{
				TASKS tASKS = RequireTasks();
				foreach (Class198 item in list_0.OrderByDescending(Class200.class200_0.method_10))
				{
					Class198 @class = smethod_10(tASKS.QuestsArray, null, item.method_0().ID, 0);
					if (@class != null)
					{
						if (@class.method_2() == null)
						{
							tASKS.QuestsArray = smethod_25(tASKS.QuestsArray, @class.method_6());
							continue;
						}
						@class.method_2().pSub = smethod_25(@class.method_2().pSub, @class.method_6());
						@class.method_2().m_nSubCount = @class.method_2().pSub.Length;
						smethod_23(@class.method_2());
					}
				}
				smethod_22(tASKS.QuestsArray, null);
				smethod_11(tASKS);
			}
		}

		public string Domain => Class16.smethod_0(1648906421);

		public string GetFingerprint()
		{
			return AceMcpRuntime.smethod_6();
		}

		public AceMcpCommandResult Execute(string action, JObject parameters)
		{
			string text = (action ?? string.Empty).Trim().ToLowerInvariant();
			if (text != null)
			{
				switch (text.Length)
				{
				case 8:
					if (text == Class16.smethod_0(1649127311))
					{
						return smethod_5(parameters);
					}
					break;
				case 11:
					switch (text[0])
					{
					case 'r':
						if (text == Class16.smethod_0(1649124422))
						{
							return smethod_2(parameters);
						}
						break;
					case 'q':
						if (text == Class16.smethod_0(1649127253))
						{
							return smethod_1(parameters);
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649127271))
						{
							return smethod_4(parameters);
						}
						break;
					}
					break;
				case 12:
					if (text == Class16.smethod_0(1649127326))
					{
						return smethod_6(parameters);
					}
					break;
				case 14:
					switch (text[0])
					{
					case 'r':
						if (text == Class16.smethod_0(1649127224))
						{
							return smethod_7(parameters);
						}
						break;
					case 'g':
						if (text == Class16.smethod_0(1649127203))
						{
							return smethod_0(parameters);
						}
						break;
					}
					break;
				case 15:
					if (text == Class16.smethod_0(1649127281))
					{
						return smethod_3(parameters);
					}
					break;
				case 16:
					if (text == Class16.smethod_0(1649127337))
					{
						return smethod_8(parameters);
					}
					break;
				}
			}
			throw new InvalidOperationException(Class16.smethod_0(1649127360) + action + Class16.smethod_0(1648928156));
		}

		private static AceMcpCommandResult smethod_0(JObject jobject_0)
		{
			TASKS tASKS = RequireTasks();
			int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649127393)) ?? throw new InvalidOperationException(Class16.smethod_0(1649127415));
			ATaskTempl quest = tASKS.GetQuest(num);
			return new AceMcpCommandResult
			{
				Data = new
				{
					found = (quest != null),
					task_id = num,
					task = quest
				}
			};
		}

		private static AceMcpCommandResult smethod_1(JObject jobject_0)
		{
			TASKS tASKS = RequireTasks();
			string text = GetString(jobject_0, Class16.smethod_0(1649124629));
			int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124676)) ?? 50;
			List<object> list = new List<object>();
			foreach (ATaskTempl item in smethod_9(tASKS.QuestsArray))
			{
				string text2 = item.Name ?? string.Empty;
				if (string.IsNullOrWhiteSpace(text) || text2.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					list.Add(new
					{
						id = item.ID,
						name = text2,
						parent_id = item.m_ulParent,
						sub_count = item.m_nSubCount
					});
					if (list.Count >= num)
					{
						break;
					}
				}
			}
			return new AceMcpCommandResult
			{
				Data = new
				{
					query = text,
					count = list.Count,
					tasks = list
				}
			};
		}

		private static AceMcpCommandResult smethod_2(JObject jobject_0)
		{
			TASKS tASKS = RequireTasks();
			string[] array = ((JContainer)GetJsonArrayParameter(jobject_0, Class16.smethod_0(1649126430))).Values<string>().ToArray();
			if (array.Length == 0)
			{
				array = new string[4]
				{
					Class16.smethod_0(1648941057),
					Class16.smethod_0(1648936731),
					Class16.smethod_0(1649126440),
					Class16.smethod_0(1649126457)
				};
			}
			List<object> list = new List<object>();
			foreach (int item in ParseIntList(jobject_0, Class16.smethod_0(1649126475)))
			{
				ATaskTempl quest = tASKS.GetQuest(item);
				if (quest != null)
				{
					Dictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
					string[] array2 = array;
					foreach (string text in array2)
					{
						dictionary[text] = GetMemberValue(quest, text);
					}
					list.Add(new
					{
						task_id = item,
						fields = dictionary
					});
				}
			}
			return new AceMcpCommandResult
			{
				Data = new
				{
					field_paths = array,
					tasks = list
				}
			};
		}

		private static AceMcpCommandResult smethod_3(JObject jobject_0)
		{
			TASKS tASKS = RequireTasks();
			Dictionary<string, JToken> dictionary = ParseFieldMap(jobject_0, Class16.smethod_0(1649125271));
			List<object> list = new List<object>();
			List<IAceMcpChangeOperation> list2 = new List<IAceMcpChangeOperation>();
			using (List<int>.Enumerator enumerator = ParseIntList(jobject_0, Class16.smethod_0(1649126475)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Class196 @class = new Class196();
					@class.int_0 = enumerator.Current;
					ATaskTempl quest = tASKS.GetQuest(@class.int_0);
					if (quest == null)
					{
						continue;
					}
					Dictionary<string, object> dictionary2 = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
					foreach (KeyValuePair<string, JToken> item in dictionary)
					{
						dictionary2[item.Key] = GetMemberValue(quest, item.Key);
					}
					list.Add(new
					{
						task_id = @class.int_0,
						old_values = dictionary2,
						new_values = dictionary.ToDictionary(Class200.class200_0.method_0, Class200.class200_0.method_1)
					});
					@class.dictionary_0 = dictionary.ToDictionary(Class200.class200_0.method_2, Class200.class200_0.method_3, StringComparer.OrdinalIgnoreCase);
					list2.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906421), Class16.smethod_0(1649127281), new
					{
						task_id = @class.int_0,
						fields = @class.dictionary_0.Keys.ToArray()
					}, @class.method_0));
				}
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					tasks = list
				}
			};
			aceMcpCommandResult.Operations.AddRange(list2);
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_4(JObject jobject_0)
		{
			Class197 @class = new Class197();
			TASKS tASKS = RequireTasks();
			bool flag = ((JToken)jobject_0).Value<bool?>((object)Class16.smethod_0(1649124783)) ?? true;
			@class.int_0 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649126490)) ?? (-1);
			@class.list_0 = new List<(int, ATaskTempl)>();
			foreach (int item in ParseIntList(jobject_0, Class16.smethod_0(1649126475)))
			{
				ATaskTempl quest = tASKS.GetQuest(item);
				if (quest != null)
				{
					ATaskTempl aTaskTempl = quest.Clone();
					if (flag)
					{
						Dictionary<int, int> idictionary_ = new Dictionary<int, int>();
						smethod_13(aTaskTempl, tASKS, idictionary_, null, 0);
						smethod_14(aTaskTempl, idictionary_);
					}
					@class.list_0.Add((item, aTaskTempl));
				}
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					clones = @class.list_0.Select(((int, ATaskTempl) valueTuple_0) => _003C_003Ef__AnonymousType65.Create(
						valueTuple_0.Item1,
						valueTuple_0.Item2.ID,
						valueTuple_0.Item2.Name
					)).ToArray(),
					parent_id = @class.int_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906421), Class16.smethod_0(1649127271), new
			{
				task_ids = @class.list_0.Select(Class200.class200_0.method_5).ToArray(),
				parent_id = @class.int_0,
				assign_new_ids = flag
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_5(JObject jobject_0)
		{
			Class195 @class = new Class195();
			TASKS tASKS = RequireTasks();
			@class.int_0 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649126490)) ?? (-1);
			ATaskTempl aTaskTempl = smethod_12(tASKS);
			Dictionary<string, JToken> dictionary = ParseFieldMap(jobject_0, Class16.smethod_0(1649125271));
			foreach (KeyValuePair<string, JToken> item in dictionary)
			{
				SetMemberValue(aTaskTempl, item.Key, item.Value);
			}
			if (aTaskTempl.ID <= 0)
			{
				aTaskTempl.ID = tASKS.GetFreeID();
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					parent_id = @class.int_0,
					task_id = aTaskTempl.ID,
					name = aTaskTempl.Name
				}
			};
			@class.ataskTempl_0 = smethod_26(aTaskTempl);
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906421), Class16.smethod_0(1649127311), new
			{
				parent_id = @class.int_0,
				task_id = aTaskTempl.ID,
				name = aTaskTempl.Name
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_6(JObject jobject_0)
		{
			Class201 @class = new Class201();
			@class.tasks_0 = RequireTasks();
			@class.list_0 = ParseIntList(jobject_0, Class16.smethod_0(1649126475)).Select(@class.method_0).Where(Class200.class200_0.method_6).OrderByDescending(Class200.class200_0.method_7)
				.ToList();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					deleted = @class.list_0.Select((Class198 class198_0) => _003C_003Ef__AnonymousType69.Create(
						class198_0.method_0().ID,
						class198_0.method_8(),
						(class198_0.method_2()?.ID ?? 0)
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906421), Class16.smethod_0(1649127326), new
			{
				task_ids = @class.list_0.Select(Class200.class200_0.method_9).ToArray()
			}, @class.method_1));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_7(JObject jobject_0)
		{
			Class194 @class = new Class194();
			@class.int_0 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649127393)) ?? throw new InvalidOperationException(Class16.smethod_0(1649127415));
			@class.int_1 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649126506)) ?? (-1);
			TASKS tASKS = RequireTasks();
			Class198 class2 = smethod_10(tASKS.QuestsArray, null, @class.int_0, 0);
			if (class2 == null)
			{
				throw new InvalidOperationException(string.Format(Class16.smethod_0(1649127140), @class.int_0));
			}
			if (@class.int_1 > 0 && @class.int_1 == @class.int_0)
			{
				throw new InvalidOperationException(Class16.smethod_0(1649126534));
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					task_id = @class.int_0,
					old_parent_id = (class2.method_2()?.ID ?? 0),
					new_parent_id = @class.int_1
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906421), Class16.smethod_0(1649127224), new
			{
				task_id = @class.int_0,
				new_parent_id = @class.int_1
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_8(JObject jobject_0)
		{
			Class199 @class = new Class199();
			RequireTasks();
			JObject jsonObjectParameter = GetJsonObjectParameter(jobject_0, Class16.smethod_0(1649126569));
			@class.dictionary_0 = jsonObjectParameter.Properties().ToDictionary(Class200.class200_0.method_11, Class200.class200_0.method_12);
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					replacements = @class.dictionary_0.Select((KeyValuePair<int, int> keyValuePair_0) => _003C_003Ef__AnonymousType74.Create(
						keyValuePair_0.Key,
						keyValuePair_0.Value
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906421), Class16.smethod_0(1649127337), new
			{
				replacement_count = @class.dictionary_0.Count
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static IEnumerable<ATaskTempl> smethod_9(IEnumerable<ATaskTempl> ienumerable_0)
		{
			return new Class193(-2)
			{
				ienumerable_1 = ienumerable_0
			};
		}

		private static Class198 smethod_10(ATaskTempl[] ataskTempl_0, ATaskTempl ataskTempl_1, int int_0, int int_1)
		{
			if (ataskTempl_0 == null)
			{
				return null;
			}
			int num = 0;
			Class198 class2;
			while (true)
			{
				if (num < ataskTempl_0.Length)
				{
					ATaskTempl aTaskTempl = ataskTempl_0[num];
					if (aTaskTempl != null)
					{
						if (aTaskTempl.ID == int_0)
						{
							Class198 @class = new Class198();
							@class.method_1(aTaskTempl);
							@class.method_3(ataskTempl_1);
							@class.method_5(ataskTempl_0);
							@class.method_7(num);
							@class.method_9(int_1);
							return @class;
						}
						class2 = smethod_10(aTaskTempl.pSub, aTaskTempl, int_0, int_1 + 1);
						if (class2 != null)
						{
							break;
						}
					}
					num++;
					continue;
				}
				return null;
			}
			return class2;
		}

		private static void smethod_11(TASKS tasks_0)
		{
			ATaskTempl[] questsArray = tasks_0.QuestsArray;
			tasks_0.Count = ((questsArray != null) ? questsArray.Length : 0);
			tasks_0.QuestsInfo = null;
			tasks_0.infos = null;
			tasks_0.FileChanged = true;
			tasks_0.UpdateTasksDict();
		}

		private static ATaskTempl smethod_12(TASKS tasks_0)
		{
			ATaskTempl aTaskTempl = new ATaskTempl();
			if (tasks_0.version >= 120)
			{
				aTaskTempl.m_ulType = 103;
			}
			aTaskTempl.PropMonsterSummoned.m_Monsters = MONSTERS_SUMMONED.NewArray(32);
			aTaskTempl.ID = tasks_0.GetFreeID();
			aTaskTempl.Name = string.Format(Class16.smethod_0(1649126587), aTaskTempl.ID);
			return aTaskTempl;
		}

		private static void smethod_13(ATaskTempl ataskTempl_0, TASKS tasks_0, IDictionary<int, int> idictionary_0, ATaskTempl ataskTempl_1, int int_0)
		{
			if (ataskTempl_0 == null)
			{
				return;
			}
			int iD = ataskTempl_0.ID;
			int i;
			for (i = tasks_0.GetFreeID(); idictionary_0.Values.Contains(i) || tasks_0.IsQuestExist(i); i++)
			{
			}
			idictionary_0[iD] = i;
			ataskTempl_0.ID = i;
			ataskTempl_0.m_ulParent = ataskTempl_1?.ID ?? 0;
			ataskTempl_0.m_ulPrevSibling = 0;
			ataskTempl_0.m_ulNextSibling = 0;
			ataskTempl_0.m_ulFirstChild = 0;
			if (ataskTempl_0.pSub != null)
			{
				for (int j = 0; j < ataskTempl_0.pSub.Length; j++)
				{
					smethod_13(ataskTempl_0.pSub[j], tasks_0, idictionary_0, ataskTempl_0, j);
				}
			}
			smethod_23(ataskTempl_0);
		}

		private static void smethod_14(ATaskTempl ataskTempl_0, IDictionary<int, int> idictionary_0)
		{
			foreach (ATaskTempl item in smethod_9(new ATaskTempl[1] { ataskTempl_0 }))
			{
				smethod_15(item, idictionary_0);
			}
			smethod_23(ataskTempl_0);
		}

		private static void smethod_15(ATaskTempl ataskTempl_0, IDictionary<int, int> idictionary_0)
		{
			if (ataskTempl_0 == null || idictionary_0 == null || idictionary_0.Count == 0)
			{
				return;
			}
			smethod_16(ataskTempl_0.m_ulPremise_Tasks, idictionary_0);
			smethod_16(ataskTempl_0.m_ulMutexTasks, idictionary_0);
			smethod_16(ataskTempl_0.m_ulNeededTasks, idictionary_0);
			smethod_16(ataskTempl_0.SpecialParameters?.CompleteTaskIDs, idictionary_0);
			if (ataskTempl_0.m_TeamMemsWanted != null)
			{
				for (int i = 0; i < ataskTempl_0.m_TeamMemsWanted.Length; i++)
				{
					int? num = FindTaskIdInReplacementMap(idictionary_0, ataskTempl_0.m_TeamMemsWanted[i].m_ulTask);
					if (num.HasValue)
					{
						ataskTempl_0.m_TeamMemsWanted[i].m_ulTask = num.Value;
					}
				}
			}
			if (ataskTempl_0.TaskEventTaskData != null)
			{
				for (int j = 0; j < ataskTempl_0.TaskEventTaskData.Length; j++)
				{
					int? num2 = FindTaskIdInReplacementMap(idictionary_0, ataskTempl_0.TaskEventTaskData[j].Id);
					if (num2.HasValue)
					{
						ataskTempl_0.TaskEventTaskData[j].Id = num2.Value;
					}
				}
			}
			smethod_17(ataskTempl_0.m_Award_S, idictionary_0);
			smethod_17(ataskTempl_0.m_Award_F, idictionary_0);
			smethod_18(ataskTempl_0.m_AwByRatio_S?.m_Awards, idictionary_0);
			smethod_18(ataskTempl_0.m_AwByRatio_F?.m_Awards, idictionary_0);
			smethod_18(ataskTempl_0.m_AwByItems_S?.m_Awards, idictionary_0);
			smethod_18(ataskTempl_0.m_AwByItems_F?.m_Awards, idictionary_0);
			smethod_21(ataskTempl_0.m_DelvTaskTalk, idictionary_0);
			smethod_21(ataskTempl_0.m_UnqualifiedTaskTalk, idictionary_0);
			smethod_21(ataskTempl_0.m_DelvItemTalk, idictionary_0);
			smethod_21(ataskTempl_0.m_ExeTalk, idictionary_0);
			smethod_21(ataskTempl_0.m_AwardTalk, idictionary_0);
		}

		private static void smethod_16(int[] int_0, IDictionary<int, int> idictionary_0)
		{
			if (int_0 == null)
			{
				return;
			}
			for (int i = 0; i < int_0.Length; i++)
			{
				int? num = FindTaskIdInReplacementMap(idictionary_0, int_0[i]);
				if (num.HasValue)
				{
					int_0[i] = num.Value;
				}
			}
		}

		private static void smethod_17(AWARD_DATA award_DATA_0, IDictionary<int, int> idictionary_0)
		{
			if (award_DATA_0 != null)
			{
				int? num = FindTaskIdInReplacementMap(idictionary_0, award_DATA_0.m_ulNewTask);
				if (num.HasValue)
				{
					award_DATA_0.m_ulNewTask = num.Value;
				}
			}
		}

		private static void smethod_18(AWARD_DATA[] award_DATA_0, IDictionary<int, int> idictionary_0)
		{
			if (award_DATA_0 != null)
			{
				foreach (AWARD_DATA award_DATA_1 in award_DATA_0)
				{
					smethod_17(award_DATA_1, idictionary_0);
				}
			}
		}

		private static void smethod_19(ATaskTempl ataskTempl_0, int int_0, int int_1)
		{
			smethod_20(ataskTempl_0.m_DelvTaskTalk, int_0, int_1);
			smethod_20(ataskTempl_0.m_UnqualifiedTaskTalk, int_0, int_1);
			smethod_20(ataskTempl_0.m_DelvItemTalk, int_0, int_1);
			smethod_20(ataskTempl_0.m_ExeTalk, int_0, int_1);
			smethod_20(ataskTempl_0.m_AwardTalk, int_0, int_1);
			if (ataskTempl_0.pSub != null)
			{
				ATaskTempl[] pSub = ataskTempl_0.pSub;
				foreach (ATaskTempl ataskTempl_1 in pSub)
				{
					smethod_19(ataskTempl_1, int_0, int_1);
				}
			}
		}

		private static void smethod_20(talk_proc talk_proc_0, int int_0, int int_1)
		{
			if (talk_proc_0?.windows == null)
			{
				return;
			}
			for (int i = 0; i < talk_proc_0.windows.Length; i++)
			{
				if (talk_proc_0.windows[i]?.options == null)
				{
					continue;
				}
				for (int j = 0; j < talk_proc_0.windows[i].options.Length; j++)
				{
					if (talk_proc_0.windows[i].options[j].id == int_0)
					{
						talk_proc_0.windows[i].options[j].id = int_1;
					}
				}
			}
		}

		private static void smethod_21(talk_proc talk_proc_0, IDictionary<int, int> idictionary_0)
		{
			if (talk_proc_0?.windows == null)
			{
				return;
			}
			for (int i = 0; i < talk_proc_0.windows.Length; i++)
			{
				if (talk_proc_0.windows[i]?.options == null)
				{
					continue;
				}
				for (int j = 0; j < talk_proc_0.windows[i].options.Length; j++)
				{
					int? num = FindTaskIdInReplacementMap(idictionary_0, talk_proc_0.windows[i].options[j].id);
					if (num.HasValue)
					{
						talk_proc_0.windows[i].options[j].id = num.Value;
					}
				}
			}
		}

		private static void smethod_22(ATaskTempl[] ataskTempl_0, ATaskTempl ataskTempl_1)
		{
			if (ataskTempl_0 != null)
			{
				for (int i = 0; i < ataskTempl_0.Length; i++)
				{
					ATaskTempl aTaskTempl = ataskTempl_0[i];
					aTaskTempl.m_ulParent = ataskTempl_1?.ID ?? 0;
					aTaskTempl.m_ulPrevSibling = ((i > 0) ? ataskTempl_0[i - 1].ID : 0);
					aTaskTempl.m_ulNextSibling = ((i < ataskTempl_0.Length - 1) ? ataskTempl_0[i + 1].ID : 0);
					aTaskTempl.m_ulFirstChild = ((aTaskTempl.pSub != null && aTaskTempl.pSub.Length != 0) ? aTaskTempl.pSub[0].ID : 0);
					ATaskTempl[] pSub = aTaskTempl.pSub;
					aTaskTempl.m_nSubCount = ((pSub != null) ? pSub.Length : 0);
					smethod_22(aTaskTempl.pSub, aTaskTempl);
				}
			}
		}

		private static void smethod_23(ATaskTempl ataskTempl_0)
		{
			if (ataskTempl_0 != null)
			{
				ATaskTempl[] pSub = ataskTempl_0.pSub;
				ataskTempl_0.m_nSubCount = ((pSub != null) ? pSub.Length : 0);
				ataskTempl_0.m_ulFirstChild = ((ataskTempl_0.m_nSubCount > 0) ? ataskTempl_0.pSub[0].ID : 0);
				smethod_22(ataskTempl_0.pSub, ataskTempl_0);
			}
		}

		private static T[] smethod_24<T>(T[] gparam_0, T gparam_1)
		{
			if (gparam_0 == null)
			{
				gparam_0 = Array.Empty<T>();
			}
			T[] array = new T[gparam_0.Length + 1];
			if (gparam_0.Length != 0)
			{
				Array.Copy(gparam_0, array, gparam_0.Length);
			}
			array[array.Length - 1] = gparam_1;
			return array;
		}

		private static T[] smethod_25<T>(T[] gparam_0, int int_0)
		{
			if (gparam_0 != null && gparam_0.Length != 0 && int_0 >= 0 && int_0 < gparam_0.Length)
			{
				if (gparam_0.Length == 1)
				{
					return Array.Empty<T>();
				}
				T[] array = new T[gparam_0.Length - 1];
				if (int_0 > 0)
				{
					Array.Copy(gparam_0, 0, array, 0, int_0);
				}
				int num = gparam_0.Length - int_0 - 1;
				if (num > 0)
				{
					Array.Copy(gparam_0, int_0 + 1, array, int_0, num);
				}
				return array;
			}
			return gparam_0 ?? Array.Empty<T>();
		}

		private static ATaskTempl smethod_26(ATaskTempl ataskTempl_0)
		{
			return ataskTempl_0?.Clone();
		}
	}

	private sealed class Class202 : IAceMcpDomainHandler
	{
		private sealed class Class203
		{
			public ClassDynamicObject classDynamicObject_0;

			internal void method_0()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				aceMcpNpcGenDocument.Data.DynamicsList.Add(smethod_21(classDynamicObject_0));
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class204
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public int[] int_0;

			internal bool method_0(int int_1)
			{
				if (int_1 >= 0)
				{
					return int_1 < aceMcpNpcGenDocument_0.Data.TriggersList.Count;
				}
				return false;
			}

			internal void method_1()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				int[] array = int_0;
				foreach (int index in array)
				{
					aceMcpNpcGenDocument.Data.TriggersList.RemoveAt(index);
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class205
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public List<_003C_003Ef__AnonymousType103<int, ClassDefaultResources>> list_0;

			internal bool method_0(int int_0)
			{
				if (int_0 >= 0)
				{
					return int_0 < aceMcpNpcGenDocument_0.Data.ResourcesList.Count;
				}
				return false;
			}

			internal _003C_003Ef__AnonymousType103<int, ClassDefaultResources> method_1(int int_0)
			{
				return _003C_003Ef__AnonymousType103.Create(
					int_0,
					smethod_21(aceMcpNpcGenDocument_0.Data.ResourcesList[int_0])
				);
			}

			internal void method_2()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				foreach (var item in list_0)
				{
					aceMcpNpcGenDocument.Data.ResourcesList.Add(smethod_21(item.clone));
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class206
		{
			public IList ilist_0;

			internal bool method_0(int int_0)
			{
				if (int_0 >= 0)
				{
					return int_0 < ilist_0.Count;
				}
				return false;
			}

			internal object method_1(int int_0)
			{
				return ilist_0[int_0];
			}
		}

		private sealed class Class207
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public int[] int_0;

			internal bool method_0(int int_1)
			{
				if (int_1 >= 0)
				{
					return int_1 < aceMcpNpcGenDocument_0.Data.NpcMobList.Count;
				}
				return false;
			}

			internal void method_1()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				int[] array = int_0;
				foreach (int index in array)
				{
					aceMcpNpcGenDocument.Data.NpcMobList.RemoveAt(index);
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class208
		{
			public ClassTrigger classTrigger_0;

			internal void method_0()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				aceMcpNpcGenDocument.Data.TriggersList.Add(smethod_21(classTrigger_0));
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class209
		{
			public ClassDefaultMonsters classDefaultMonsters_0;

			internal void method_0()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				aceMcpNpcGenDocument.Data.NpcMobList.Add(smethod_21(classDefaultMonsters_0));
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class210
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public int[] int_0;

			internal bool method_0(int int_1)
			{
				if (int_1 >= 0)
				{
					return int_1 < aceMcpNpcGenDocument_0.Data.DynamicsList.Count;
				}
				return false;
			}

			internal void method_1()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				int[] array = int_0;
				foreach (int index in array)
				{
					aceMcpNpcGenDocument.Data.DynamicsList.RemoveAt(index);
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class211
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public int int_0;

			public int int_1;

			public List<_003C_003Ef__AnonymousType103<int, ClassTrigger>> list_0;

			internal bool method_0(int int_2)
			{
				if (int_2 >= 0)
				{
					return int_2 < aceMcpNpcGenDocument_0.Data.TriggersList.Count;
				}
				return false;
			}

			internal _003C_003Ef__AnonymousType103<int, ClassTrigger> method_1(int int_2)
			{
				ClassTrigger classTrigger = smethod_21(aceMcpNpcGenDocument_0.Data.TriggersList[int_2]);
				classTrigger.Id = int_0++;
				classTrigger.GmID = int_1++;
				return _003C_003Ef__AnonymousType103.Create(
					int_2,
					classTrigger
				);
			}

			internal void method_2()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				foreach (var item in list_0)
				{
					aceMcpNpcGenDocument.Data.TriggersList.Add(smethod_21(item.clone));
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class212
		{
			public string string_0;

			internal bool method_0(object object_0)
			{
				return JsonConvert.SerializeObject(object_0).IndexOf(string_0, StringComparison.OrdinalIgnoreCase) >= 0;
			}
		}

		private sealed class Class213
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public List<_003C_003Ef__AnonymousType103<int, ClassDynamicObject>> list_0;

			internal bool method_0(int int_0)
			{
				if (int_0 >= 0)
				{
					return int_0 < aceMcpNpcGenDocument_0.Data.DynamicsList.Count;
				}
				return false;
			}

			internal _003C_003Ef__AnonymousType103<int, ClassDynamicObject> method_1(int int_0)
			{
				return _003C_003Ef__AnonymousType103.Create(
					int_0,
					smethod_21(aceMcpNpcGenDocument_0.Data.DynamicsList[int_0])
				);
			}

			internal void method_2()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				foreach (var item in list_0)
				{
					aceMcpNpcGenDocument.Data.DynamicsList.Add(smethod_21(item.clone));
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class214
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public List<_003C_003Ef__AnonymousType103<int, ClassDefaultMonsters>> list_0;

			internal bool method_0(int int_0)
			{
				if (int_0 >= 0)
				{
					return int_0 < aceMcpNpcGenDocument_0.Data.NpcMobList.Count;
				}
				return false;
			}

			internal _003C_003Ef__AnonymousType103<int, ClassDefaultMonsters> method_1(int int_0)
			{
				return _003C_003Ef__AnonymousType103.Create(
					int_0,
					smethod_21(aceMcpNpcGenDocument_0.Data.NpcMobList[int_0])
				);
			}

			internal void method_2()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				foreach (var item in list_0)
				{
					aceMcpNpcGenDocument.Data.NpcMobList.Add(smethod_21(item.clone));
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class215
		{
			public string string_0;

			public int[] int_0;

			public int int_1;

			internal void method_0()
			{
				Class206 @class = new Class206();
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				string text = string_0;
				IList ilist_;
				if (!(text == Class16.smethod_0(1649124179)))
				{
					if (!(text == Class16.smethod_0(1649124195)))
					{
						if (!(text == Class16.smethod_0(1649081621)))
						{
							if (!(text == Class16.smethod_0(1649124210)))
							{
								throw new InvalidOperationException(Class16.smethod_0(1649124239) + string_0 + Class16.smethod_0(1648928156));
							}
							ilist_ = aceMcpNpcGenDocument.Data.DynamicsList;
						}
						else
						{
							ilist_ = aceMcpNpcGenDocument.Data.TriggersList;
						}
					}
					else
					{
						ilist_ = aceMcpNpcGenDocument.Data.ResourcesList;
					}
				}
				else
				{
					ilist_ = aceMcpNpcGenDocument.Data.NpcMobList;
				}
				@class.ilist_0 = ilist_;
				List<object> list = int_0.Where(@class.method_0).Select(@class.method_1).ToList();
				for (int num = int_0.Length - 1; num >= 0; num--)
				{
					if (int_0[num] >= 0 && int_0[num] < @class.ilist_0.Count)
					{
						@class.ilist_0.RemoveAt(int_0[num]);
					}
				}
				int num2 = Math.Max(0, Math.Min(int_1, @class.ilist_0.Count));
				foreach (object item in list)
				{
					@class.ilist_0.Insert(num2++, item);
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class216
		{
			public AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

			public int[] int_0;

			internal bool method_0(int int_1)
			{
				if (int_1 >= 0)
				{
					return int_1 < aceMcpNpcGenDocument_0.Data.ResourcesList.Count;
				}
				return false;
			}

			internal void method_1()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				int[] array = int_0;
				foreach (int index in array)
				{
					aceMcpNpcGenDocument.Data.ResourcesList.RemoveAt(index);
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		[Serializable]
		private sealed class Class217
		{
			public static readonly Class217 class217_0 = new Class217();

			public static Func<ClassDefaultMonsters, int, _003C_003Ef__AnonymousType98<int, int, int, string, int>> func_0;

			public static Func<ClassDefaultResources, int, _003C_003Ef__AnonymousType98<int, int, int, string, int>> func_1;

			public static Func<ClassDynamicObject, int, _003C_003Ef__AnonymousType98<int, int, int, string, int>> func_2;

			public static Func<ClassTrigger, int, _003C_003Ef__AnonymousType98<int, int, int, string, int>> func_3;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassDefaultMonsters>, _003C_003Ef__AnonymousType105<int, int>> func_4;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassDefaultMonsters>, int> func_5;

			public static Func<int, int> func_6;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassDefaultResources>, _003C_003Ef__AnonymousType105<int, int>> func_7;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassDefaultResources>, int> func_8;

			public static Func<int, int> func_9;

			public static Func<ClassTrigger, int> func_10;

			public static Func<ClassTrigger, int> func_11;

			public static Func<ClassTrigger, int> func_12;

			public static Func<ClassTrigger, int> func_13;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassTrigger>, _003C_003Ef__AnonymousType109<int, int, int, string>> func_14;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassTrigger>, int> func_15;

			public static Func<int, int> func_16;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassDynamicObject>, _003C_003Ef__AnonymousType111<int, int, int>> func_17;

			public static Func<_003C_003Ef__AnonymousType103<int, ClassDynamicObject>, int> func_18;

			public static Func<int, int> func_19;

			public static Func<int, int> func_20;

			public static Func<KeyValuePair<string, JToken>, string> func_21;

			public static Func<KeyValuePair<string, JToken>, JToken> func_22;

			internal _003C_003Ef__AnonymousType98<int, int, int, string, int> method_0(ClassDefaultMonsters classDefaultMonsters_0, int int_0)
			{
				List<ClassExtraMonsters> mobDops = classDefaultMonsters_0.MobDops;
				int valueOrDefault = ((mobDops == null) ? ((int?)null) : Class5.smethod_0(mobDops)?.Id).GetValueOrDefault();
				int trigger_id = classDefaultMonsters_0.Trigger_id;
				List<ClassExtraMonsters> mobDops2 = classDefaultMonsters_0.MobDops;
				return _003C_003Ef__AnonymousType98.Create(
					int_0,
					valueOrDefault,
					trigger_id,
					smethod_20(((mobDops2 == null) ? ((int?)null) : Class5.smethod_0(mobDops2)?.Id).GetValueOrDefault()),
					classDefaultMonsters_0.Amount_in_group
				);
			}

			internal _003C_003Ef__AnonymousType98<int, int, int, string, int> method_1(ClassDefaultResources classDefaultResources_0, int int_0)
			{
				List<ClassExtraResources> resExtra = classDefaultResources_0.ResExtra;
				int valueOrDefault = ((resExtra == null) ? ((int?)null) : Class5.smethod_0(resExtra)?.Id).GetValueOrDefault();
				int trigger_id = classDefaultResources_0.Trigger_id;
				List<ClassExtraResources> resExtra2 = classDefaultResources_0.ResExtra;
				return _003C_003Ef__AnonymousType98.Create(
					int_0,
					valueOrDefault,
					trigger_id,
					smethod_20(((resExtra2 == null) ? ((int?)null) : Class5.smethod_0(resExtra2)?.Id).GetValueOrDefault()),
					classDefaultResources_0.Amount_in_group
				);
			}

			internal _003C_003Ef__AnonymousType98<int, int, int, string, int> method_2(ClassDynamicObject classDynamicObject_0, int int_0)
			{
				return _003C_003Ef__AnonymousType98.Create(
					int_0,
					classDynamicObject_0.Id,
					classDynamicObject_0.TriggerId,
					classDynamicObject_0.Id.ToString(CultureInfo.InvariantCulture),
					1
				);
			}

			internal _003C_003Ef__AnonymousType98<int, int, int, string, int> method_3(ClassTrigger classTrigger_0, int int_0)
			{
				return _003C_003Ef__AnonymousType98.Create(
					int_0,
					classTrigger_0.Id,
					classTrigger_0.Id,
					classTrigger_0.TriggerName,
					1
				);
			}

			internal _003C_003Ef__AnonymousType105<int, int> method_4(_003C_003Ef__AnonymousType103<int, ClassDefaultMonsters> _003C_003Ef__AnonymousType103_0)
			{
				int index = _003C_003Ef__AnonymousType103_0.index;
				List<ClassExtraMonsters> mobDops = _003C_003Ef__AnonymousType103_0.clone.MobDops;
				return _003C_003Ef__AnonymousType105.Create(
					index,
					((mobDops == null) ? ((int?)null) : Class5.smethod_0(mobDops)?.Id).GetValueOrDefault()
				);
			}

			internal int method_5(_003C_003Ef__AnonymousType103<int, ClassDefaultMonsters> _003C_003Ef__AnonymousType103_0)
			{
				return _003C_003Ef__AnonymousType103_0.index;
			}

			internal int method_6(int int_0)
			{
				return int_0;
			}

			internal _003C_003Ef__AnonymousType105<int, int> method_7(_003C_003Ef__AnonymousType103<int, ClassDefaultResources> _003C_003Ef__AnonymousType103_0)
			{
				int index = _003C_003Ef__AnonymousType103_0.index;
				List<ClassExtraResources> resExtra = _003C_003Ef__AnonymousType103_0.clone.ResExtra;
				return _003C_003Ef__AnonymousType105.Create(
					index,
					((resExtra == null) ? ((int?)null) : Class5.smethod_0(resExtra)?.Id).GetValueOrDefault()
				);
			}

			internal int method_8(_003C_003Ef__AnonymousType103<int, ClassDefaultResources> _003C_003Ef__AnonymousType103_0)
			{
				return _003C_003Ef__AnonymousType103_0.index;
			}

			internal int method_9(int int_0)
			{
				return int_0;
			}

			internal int method_10(ClassTrigger classTrigger_0)
			{
				return classTrigger_0.Id;
			}

			internal int method_11(ClassTrigger classTrigger_0)
			{
				return classTrigger_0.GmID;
			}

			internal int method_12(ClassTrigger classTrigger_0)
			{
				return classTrigger_0.Id;
			}

			internal int method_13(ClassTrigger classTrigger_0)
			{
				return classTrigger_0.GmID;
			}

			internal _003C_003Ef__AnonymousType109<int, int, int, string> method_14(_003C_003Ef__AnonymousType103<int, ClassTrigger> _003C_003Ef__AnonymousType103_0)
			{
				return _003C_003Ef__AnonymousType109.Create(
					_003C_003Ef__AnonymousType103_0.index,
					_003C_003Ef__AnonymousType103_0.clone.Id,
					_003C_003Ef__AnonymousType103_0.clone.GmID,
					_003C_003Ef__AnonymousType103_0.clone.TriggerName
				);
			}

			internal int method_15(_003C_003Ef__AnonymousType103<int, ClassTrigger> _003C_003Ef__AnonymousType103_0)
			{
				return _003C_003Ef__AnonymousType103_0.index;
			}

			internal int method_16(int int_0)
			{
				return int_0;
			}

			internal _003C_003Ef__AnonymousType111<int, int, int> method_17(_003C_003Ef__AnonymousType103<int, ClassDynamicObject> _003C_003Ef__AnonymousType103_0)
			{
				return _003C_003Ef__AnonymousType111.Create(
					_003C_003Ef__AnonymousType103_0.index,
					_003C_003Ef__AnonymousType103_0.clone.Id,
					_003C_003Ef__AnonymousType103_0.clone.TriggerId
				);
			}

			internal int method_18(_003C_003Ef__AnonymousType103<int, ClassDynamicObject> _003C_003Ef__AnonymousType103_0)
			{
				return _003C_003Ef__AnonymousType103_0.index;
			}

			internal int method_19(int int_0)
			{
				return int_0;
			}

			internal int method_20(int int_0)
			{
				return int_0;
			}

			internal string method_21(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}

			internal JToken method_22(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Value.DeepClone();
			}
		}

		private sealed class Class218
		{
			public int[] int_0;

			public string string_0;

			public Dictionary<string, JToken> dictionary_0;

			internal void method_0()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				int[] array = int_0;
				foreach (int num in array)
				{
					string text = string_0;
					object obj = ((text == Class16.smethod_0(1649124179)) ? ((num < 0 || num >= aceMcpNpcGenDocument.Data.NpcMobList.Count) ? null : aceMcpNpcGenDocument.Data.NpcMobList[num]) : ((text == Class16.smethod_0(1649124195)) ? ((num < 0 || num >= aceMcpNpcGenDocument.Data.ResourcesList.Count) ? null : aceMcpNpcGenDocument.Data.ResourcesList[num]) : ((text == Class16.smethod_0(1649081621)) ? ((object)((num < 0 || num >= aceMcpNpcGenDocument.Data.TriggersList.Count) ? null : aceMcpNpcGenDocument.Data.TriggersList[num])) : ((object)((text == Class16.smethod_0(1649124210)) ? ((num < 0 || num >= aceMcpNpcGenDocument.Data.DynamicsList.Count) ? null : aceMcpNpcGenDocument.Data.DynamicsList[num]) : null)))));
					object obj2 = obj;
					if (obj2 == null)
					{
						continue;
					}
					foreach (KeyValuePair<string, JToken> item in dictionary_0)
					{
						SetMemberValue(obj2, item.Key, item.Value);
					}
				}
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		private sealed class Class219
		{
			public ClassDefaultResources classDefaultResources_0;

			internal void method_0()
			{
				AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
				aceMcpNpcGenDocument.Data.ResourcesList.Add(smethod_21(classDefaultResources_0));
				SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
				MarkNpcGenChanged();
			}
		}

		public string Domain => Class16.smethod_0(1648906400);

		public string GetFingerprint()
		{
			return AceMcpRuntime.smethod_8();
		}

		public AceMcpCommandResult Execute(string action, JObject parameters)
		{
			string text = (action ?? string.Empty).Trim().ToLowerInvariant();
			if (text != null)
			{
				switch (text.Length)
				{
				case 9:
					if (text == Class16.smethod_0(1649123370))
					{
						return smethod_2(parameters);
					}
					break;
				case 11:
					if (text == Class16.smethod_0(1649129738))
					{
						return smethod_9(parameters);
					}
					break;
				case 12:
					switch (text[0])
					{
					case 'm':
						if (text == Class16.smethod_0(1649123568))
						{
							return smethod_15(parameters, Class16.smethod_0(1649081621));
						}
						break;
					case 'a':
						if (text == Class16.smethod_0(1649123557))
						{
							return smethod_6(parameters);
						}
						break;
					}
					break;
				case 13:
					switch (text[0])
					{
					case 'c':
						if (text == Class16.smethod_0(1649129776))
						{
							return smethod_10(parameters);
						}
						break;
					case 'a':
						if (text == Class16.smethod_0(1649123330))
						{
							return smethod_3(parameters);
						}
						break;
					case 'q':
						if (text == Class16.smethod_0(1649124342))
						{
							return smethod_1(parameters);
						}
						break;
					case 'm':
						if (text == Class16.smethod_0(1649123358))
						{
							return smethod_15(parameters, Class16.smethod_0(1649124195));
						}
						break;
					}
					break;
				case 14:
					switch (text[0])
					{
					case 'r':
						if (text == Class16.smethod_0(1649129686))
						{
							return smethod_11(parameters);
						}
						break;
					case 'm':
						if (text == Class16.smethod_0(1649123461))
						{
							return smethod_15(parameters, Class16.smethod_0(1649124179));
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649123474))
						{
							return smethod_7(parameters);
						}
						break;
					}
					break;
				case 15:
					switch (text[0])
					{
					case 'r':
						if (text == Class16.smethod_0(1649123408))
						{
							return smethod_8(parameters);
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649123386))
						{
							return smethod_4(parameters);
						}
						break;
					}
					break;
				case 16:
					if (text == Class16.smethod_0(1649123438))
					{
						return smethod_5(parameters);
					}
					break;
				case 18:
					switch (text[0])
					{
					case 's':
						if (text == Class16.smethod_0(1649123587))
						{
							return smethod_16(parameters, Class16.smethod_0(1649081621));
						}
						break;
					case 'a':
						if (text == Class16.smethod_0(1649123620))
						{
							return smethod_12(parameters);
						}
						break;
					}
					break;
				case 19:
					switch (text[0])
					{
					case 's':
						if (text == Class16.smethod_0(1649124282))
						{
							return smethod_16(parameters, Class16.smethod_0(1649124195));
						}
						break;
					case 'm':
						if (text == Class16.smethod_0(1649124316))
						{
							return smethod_15(parameters, Class16.smethod_0(1649124210));
						}
						break;
					case 'g':
						if (text == Class16.smethod_0(1649124256))
						{
							return smethod_0();
						}
						break;
					}
					break;
				case 20:
					switch (text[0])
					{
					case 's':
						if (text == Class16.smethod_0(1649123503))
						{
							return smethod_16(parameters, Class16.smethod_0(1649124179));
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649123522))
						{
							return smethod_13(parameters);
						}
						break;
					}
					break;
				case 21:
					if (text == Class16.smethod_0(1649123645))
					{
						return smethod_14(parameters);
					}
					break;
				case 25:
					if (text == Class16.smethod_0(1649123665))
					{
						return smethod_16(parameters, Class16.smethod_0(1649124210));
					}
					break;
				}
			}
			throw new InvalidOperationException(Class16.smethod_0(1649123697) + action + Class16.smethod_0(1648928156));
		}

		private static AceMcpCommandResult smethod_0()
		{
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
			return new AceMcpCommandResult
			{
				Data = new
				{
					path = aceMcpNpcGenDocument.FileName,
					version = aceMcpNpcGenDocument.Data.File_version,
					npc_mobs_amount = aceMcpNpcGenDocument.Data.NpcMobsAmount,
					resources_amount = aceMcpNpcGenDocument.Data.ResourcesAmount,
					dynobject_amount = aceMcpNpcGenDocument.Data.DynobjectAmount,
					triggers_amount = aceMcpNpcGenDocument.Data.TriggersAmount
				}
			};
		}

		private static AceMcpCommandResult smethod_1(JObject jobject_0)
		{
			Class212 @class = new Class212();
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			string text = smethod_19(GetString(jobject_0, Class16.smethod_0(1649123731)));
			@class.string_0 = GetString(jobject_0, Class16.smethod_0(1649124629));
			int count = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124676)) ?? 50;
			IEnumerable<_003C_003Ef__AnonymousType98<int, int, int, string, int>> enumerable;
			if (!(text == Class16.smethod_0(1649124179)))
			{
				if (!(text == Class16.smethod_0(1649124195)))
				{
					if (!(text == Class16.smethod_0(1649124210)))
					{
						if (!(text == Class16.smethod_0(1649081621)))
						{
							throw new InvalidOperationException(Class16.smethod_0(1649124239) + text + Class16.smethod_0(1648928156));
						}
						enumerable = aceMcpNpcGenDocument.Data.TriggersList.Select((ClassTrigger classTrigger_0, int int_0) => _003C_003Ef__AnonymousType98.Create(
							int_0,
							classTrigger_0.Id,
							classTrigger_0.Id,
							classTrigger_0.TriggerName,
							1
						));
					}
					else
					{
						enumerable = aceMcpNpcGenDocument.Data.DynamicsList.Select((ClassDynamicObject classDynamicObject_0, int int_0) => _003C_003Ef__AnonymousType98.Create(
							int_0,
							classDynamicObject_0.Id,
							classDynamicObject_0.TriggerId,
							classDynamicObject_0.Id.ToString(CultureInfo.InvariantCulture),
							1
						));
					}
				}
				else
				{
					enumerable = aceMcpNpcGenDocument.Data.ResourcesList.Select(delegate(ClassDefaultResources classDefaultResources_0, int int_0)
					{
						List<ClassExtraResources> resExtra = classDefaultResources_0.ResExtra;
						int valueOrDefault = ((resExtra == null) ? ((int?)null) : Class5.smethod_0(resExtra)?.Id).GetValueOrDefault();
						int trigger_id = classDefaultResources_0.Trigger_id;
						List<ClassExtraResources> resExtra2 = classDefaultResources_0.ResExtra;
						return _003C_003Ef__AnonymousType98.Create(
							int_0,
							valueOrDefault,
							trigger_id,
							smethod_20(((resExtra2 == null) ? ((int?)null) : Class5.smethod_0(resExtra2)?.Id).GetValueOrDefault()),
							classDefaultResources_0.Amount_in_group
						);
					});
				}
			}
			else
			{
				enumerable = aceMcpNpcGenDocument.Data.NpcMobList.Select(delegate(ClassDefaultMonsters classDefaultMonsters_0, int int_0)
				{
					List<ClassExtraMonsters> mobDops = classDefaultMonsters_0.MobDops;
					int valueOrDefault = ((mobDops == null) ? ((int?)null) : Class5.smethod_0(mobDops)?.Id).GetValueOrDefault();
					int trigger_id = classDefaultMonsters_0.Trigger_id;
					List<ClassExtraMonsters> mobDops2 = classDefaultMonsters_0.MobDops;
					return _003C_003Ef__AnonymousType98.Create(
						int_0,
						valueOrDefault,
						trigger_id,
						smethod_20(((mobDops2 == null) ? ((int?)null) : Class5.smethod_0(mobDops2)?.Id).GetValueOrDefault()),
						classDefaultMonsters_0.Amount_in_group
					);
				});
			}
			IEnumerable<object> source = enumerable;
			if (!string.IsNullOrWhiteSpace(@class.string_0))
			{
				source = source.Where(@class.method_0);
			}
			return new AceMcpCommandResult
			{
				Data = new
				{
					kind = text,
					query = @class.string_0,
					entries = source.Take(count).ToArray()
				}
			};
		}

		private static AceMcpCommandResult smethod_2(JObject jobject_0)
		{
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			string text = smethod_19(GetString(jobject_0, Class16.smethod_0(1649123731)));
			int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1648899902)) ?? throw new InvalidOperationException(Class16.smethod_0(1649123750));
			object obj;
			if (!(text == Class16.smethod_0(1649124179)))
			{
				if (!(text == Class16.smethod_0(1649124195)))
				{
					if (!(text == Class16.smethod_0(1649124210)))
					{
						if (!(text == Class16.smethod_0(1649081621)))
						{
							throw new InvalidOperationException(Class16.smethod_0(1649124239) + text + Class16.smethod_0(1648928156));
						}
						obj = ((num < 0 || num >= aceMcpNpcGenDocument.Data.TriggersList.Count) ? null : aceMcpNpcGenDocument.Data.TriggersList[num]);
					}
					else
					{
						obj = ((num < 0 || num >= aceMcpNpcGenDocument.Data.DynamicsList.Count) ? null : aceMcpNpcGenDocument.Data.DynamicsList[num]);
					}
				}
				else
				{
					obj = ((num < 0 || num >= aceMcpNpcGenDocument.Data.ResourcesList.Count) ? null : aceMcpNpcGenDocument.Data.ResourcesList[num]);
				}
			}
			else
			{
				obj = ((num < 0 || num >= aceMcpNpcGenDocument.Data.NpcMobList.Count) ? null : aceMcpNpcGenDocument.Data.NpcMobList[num]);
			}
			object obj2 = obj;
			return new AceMcpCommandResult
			{
				Data = new
				{
					found = (obj2 != null),
					kind = text,
					index = num,
					entry = obj2
				}
			};
		}

		private static AceMcpCommandResult smethod_3(JObject jobject_0)
		{
			Class209 @class = new Class209();
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			@class.classDefaultMonsters_0 = smethod_18<ClassDefaultMonsters>(jobject_0, Class16.smethod_0(1649123779)) ?? new ClassDefaultMonsters
			{
				Location = 0,
				Type = 0,
				Amount_in_group = 1,
				MobDops = new List<ClassExtraMonsters>
				{
					new ClassExtraMonsters
					{
						Id = 16,
						Amount = 1,
						Respawn = 30
					}
				}
			};
			ClassDefaultMonsters classDefaultMonsters_ = @class.classDefaultMonsters_0;
			if (classDefaultMonsters_.MobDops == null)
			{
				classDefaultMonsters_.MobDops = new List<ClassExtraMonsters>();
			}
			if (@class.classDefaultMonsters_0.MobDops.Count == 0)
			{
				@class.classDefaultMonsters_0.MobDops.Add(new ClassExtraMonsters
				{
					Id = 16,
					Amount = 1,
					Respawn = 30
				});
			}
			@class.classDefaultMonsters_0.Amount_in_group = @class.classDefaultMonsters_0.MobDops.Count;
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124179),
					index = aceMcpNpcGenDocument.Data.NpcMobList.Count,
					entry = @class.classDefaultMonsters_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123330), new
			{
				index = aceMcpNpcGenDocument.Data.NpcMobList.Count,
				first_id = (Class5.smethod_0(@class.classDefaultMonsters_0.MobDops)?.Id ?? 0)
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_4(JObject jobject_0)
		{
			Class214 CS_0024_003C_003E8__locals7 = new Class214();
			CS_0024_003C_003E8__locals7.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			CS_0024_003C_003E8__locals7.list_0 = (from int_0 in smethod_17(jobject_0).Where(CS_0024_003C_003E8__locals7.method_0)
				select _003C_003Ef__AnonymousType103.Create(
					int_0,
					smethod_21(CS_0024_003C_003E8__locals7.aceMcpNpcGenDocument_0.Data.NpcMobList[int_0])
				)).ToList();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124179),
					entries = CS_0024_003C_003E8__locals7.list_0.Select(_003C_003Ef__AnonymousType103_0 =>
					{
						int index = _003C_003Ef__AnonymousType103_0.index;
						List<ClassExtraMonsters> mobDops = _003C_003Ef__AnonymousType103_0.clone.MobDops;
						return _003C_003Ef__AnonymousType105.Create(
							index,
							((mobDops == null) ? ((int?)null) : Class5.smethod_0(mobDops)?.Id).GetValueOrDefault()
						);
					}).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123386), new
			{
				indexes = CS_0024_003C_003E8__locals7.list_0.Select(_003C_003Ef__AnonymousType103_0 => _003C_003Ef__AnonymousType103_0.index).ToArray()
			}, CS_0024_003C_003E8__locals7.method_2));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_5(JObject jobject_0)
		{
			Class207 @class = new Class207();
			@class.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			@class.int_0 = smethod_17(jobject_0).Where(@class.method_0).Distinct().OrderByDescending(Class217.class217_0.method_6)
				.ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124179),
					indexes = @class.int_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123438), new
			{
				indexes = @class.int_0
			}, @class.method_1));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_6(JObject jobject_0)
		{
			Class219 @class = new Class219();
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			@class.classDefaultResources_0 = smethod_18<ClassDefaultResources>(jobject_0, Class16.smethod_0(1649123779)) ?? new ClassDefaultResources
			{
				Amount_in_group = 1,
				ResExtra = new List<ClassExtraResources>
				{
					new ClassExtraResources
					{
						Id = 16,
						Amount = 1,
						Respawntime = 30
					}
				}
			};
			ClassDefaultResources classDefaultResources_ = @class.classDefaultResources_0;
			if (classDefaultResources_.ResExtra == null)
			{
				classDefaultResources_.ResExtra = new List<ClassExtraResources>();
			}
			if (@class.classDefaultResources_0.ResExtra.Count == 0)
			{
				@class.classDefaultResources_0.ResExtra.Add(new ClassExtraResources
				{
					Id = 16,
					Amount = 1,
					Respawntime = 30
				});
			}
			@class.classDefaultResources_0.Amount_in_group = @class.classDefaultResources_0.ResExtra.Count;
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124195),
					index = aceMcpNpcGenDocument.Data.ResourcesList.Count,
					entry = @class.classDefaultResources_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123557), new
			{
				index = aceMcpNpcGenDocument.Data.ResourcesList.Count,
				first_id = (Class5.smethod_0(@class.classDefaultResources_0.ResExtra)?.Id ?? 0)
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_7(JObject jobject_0)
		{
			Class205 CS_0024_003C_003E8__locals7 = new Class205();
			CS_0024_003C_003E8__locals7.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			CS_0024_003C_003E8__locals7.list_0 = (from int_0 in smethod_17(jobject_0).Where(CS_0024_003C_003E8__locals7.method_0)
				select _003C_003Ef__AnonymousType103.Create(
					int_0,
					smethod_21(CS_0024_003C_003E8__locals7.aceMcpNpcGenDocument_0.Data.ResourcesList[int_0])
				)).ToList();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124195),
					entries = CS_0024_003C_003E8__locals7.list_0.Select(_003C_003Ef__AnonymousType103_0 =>
					{
						int index = _003C_003Ef__AnonymousType103_0.index;
						List<ClassExtraResources> resExtra = _003C_003Ef__AnonymousType103_0.clone.ResExtra;
						return _003C_003Ef__AnonymousType105.Create(
							index,
							((resExtra == null) ? ((int?)null) : Class5.smethod_0(resExtra)?.Id).GetValueOrDefault()
						);
					}).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123474), new
			{
				indexes = CS_0024_003C_003E8__locals7.list_0.Select(_003C_003Ef__AnonymousType103_0 => _003C_003Ef__AnonymousType103_0.index).ToArray()
			}, CS_0024_003C_003E8__locals7.method_2));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_8(JObject jobject_0)
		{
			Class216 @class = new Class216();
			@class.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			@class.int_0 = smethod_17(jobject_0).Where(@class.method_0).Distinct().OrderByDescending(Class217.class217_0.method_9)
				.ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124195),
					indexes = @class.int_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123408), new
			{
				indexes = @class.int_0
			}, @class.method_1));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_9(JObject jobject_0)
		{
			Class208 @class = new Class208();
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			@class.classTrigger_0 = smethod_18<ClassTrigger>(jobject_0, Class16.smethod_0(1649123779)) ?? new ClassTrigger
			{
				Id = ((aceMcpNpcGenDocument.Data.TriggersList.Count <= 0) ? 1 : (((IEnumerable<ClassTrigger>)aceMcpNpcGenDocument.Data.TriggersList).Max((Func<ClassTrigger, int>)Class217.class217_0.method_10) + 1)),
				GmID = ((aceMcpNpcGenDocument.Data.TriggersList.Count > 0) ? (((IEnumerable<ClassTrigger>)aceMcpNpcGenDocument.Data.TriggersList).Max((Func<ClassTrigger, int>)Class217.class217_0.method_11) + 1) : 2),
				TriggerName = Class16.smethod_0(1649123804),
				Duration = 60,
				StartYear = -1,
				StartMonth = -1,
				StartWeekDay = -1,
				StartDay = -1,
				StartHour = -1,
				StartMinute = -1,
				StopYear = -1,
				StopMonth = -1,
				StopWeekDay = -1,
				StopDay = -1,
				StopHour = -1,
				StopMinute = -1
			};
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649081621),
					index = aceMcpNpcGenDocument.Data.TriggersList.Count,
					entry = @class.classTrigger_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649129738), new
			{
				index = aceMcpNpcGenDocument.Data.TriggersList.Count,
				trigger_id = @class.classTrigger_0.Id,
				gm_id = @class.classTrigger_0.GmID
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_10(JObject jobject_0)
		{
			Class211 CS_0024_003C_003E8__locals15 = new Class211();
			CS_0024_003C_003E8__locals15.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			CS_0024_003C_003E8__locals15.int_0 = ((CS_0024_003C_003E8__locals15.aceMcpNpcGenDocument_0.Data.TriggersList.Count <= 0) ? 1 : (((IEnumerable<ClassTrigger>)CS_0024_003C_003E8__locals15.aceMcpNpcGenDocument_0.Data.TriggersList).Max((Func<ClassTrigger, int>)Class217.class217_0.method_12) + 1));
			CS_0024_003C_003E8__locals15.int_1 = ((CS_0024_003C_003E8__locals15.aceMcpNpcGenDocument_0.Data.TriggersList.Count > 0) ? (((IEnumerable<ClassTrigger>)CS_0024_003C_003E8__locals15.aceMcpNpcGenDocument_0.Data.TriggersList).Max((Func<ClassTrigger, int>)Class217.class217_0.method_13) + 1) : 2);
			CS_0024_003C_003E8__locals15.list_0 = smethod_17(jobject_0).Where(CS_0024_003C_003E8__locals15.method_0).Select(delegate(int int_2)
			{
				ClassTrigger classTrigger = smethod_21(CS_0024_003C_003E8__locals15.aceMcpNpcGenDocument_0.Data.TriggersList[int_2]);
				classTrigger.Id = CS_0024_003C_003E8__locals15.int_0++;
				classTrigger.GmID = CS_0024_003C_003E8__locals15.int_1++;
				return _003C_003Ef__AnonymousType103.Create(
					int_2,
					classTrigger
				);
			}).ToList();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649081621),
					entries = CS_0024_003C_003E8__locals15.list_0.Select(_003C_003Ef__AnonymousType103_0 => _003C_003Ef__AnonymousType109.Create(
						_003C_003Ef__AnonymousType103_0.index,
						_003C_003Ef__AnonymousType103_0.clone.Id,
						_003C_003Ef__AnonymousType103_0.clone.GmID,
						_003C_003Ef__AnonymousType103_0.clone.TriggerName
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649129776), new
			{
				indexes = CS_0024_003C_003E8__locals15.list_0.Select(_003C_003Ef__AnonymousType103_0 => _003C_003Ef__AnonymousType103_0.index).ToArray()
			}, CS_0024_003C_003E8__locals15.method_2));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_11(JObject jobject_0)
		{
			Class204 @class = new Class204();
			@class.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			@class.int_0 = smethod_17(jobject_0).Where(@class.method_0).Distinct().OrderByDescending(Class217.class217_0.method_16)
				.ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649081621),
					indexes = @class.int_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649129686), new
			{
				indexes = @class.int_0
			}, @class.method_1));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_12(JObject jobject_0)
		{
			Class203 @class = new Class203();
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			@class.classDynamicObject_0 = smethod_18<ClassDynamicObject>(jobject_0, Class16.smethod_0(1649123779)) ?? new ClassDynamicObject
			{
				Id = 16
			};
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124210),
					index = aceMcpNpcGenDocument.Data.DynamicsList.Count,
					entry = @class.classDynamicObject_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123620), new
			{
				index = aceMcpNpcGenDocument.Data.DynamicsList.Count,
				id = @class.classDynamicObject_0.Id,
				trigger_id = @class.classDynamicObject_0.TriggerId
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_13(JObject jobject_0)
		{
			Class213 CS_0024_003C_003E8__locals7 = new Class213();
			CS_0024_003C_003E8__locals7.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			CS_0024_003C_003E8__locals7.list_0 = (from int_0 in smethod_17(jobject_0).Where(CS_0024_003C_003E8__locals7.method_0)
				select _003C_003Ef__AnonymousType103.Create(
					int_0,
					smethod_21(CS_0024_003C_003E8__locals7.aceMcpNpcGenDocument_0.Data.DynamicsList[int_0])
				)).ToList();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124210),
					entries = CS_0024_003C_003E8__locals7.list_0.Select(_003C_003Ef__AnonymousType103_0 => _003C_003Ef__AnonymousType111.Create(
						_003C_003Ef__AnonymousType103_0.index,
						_003C_003Ef__AnonymousType103_0.clone.Id,
						_003C_003Ef__AnonymousType103_0.clone.TriggerId
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123522), new
			{
				indexes = CS_0024_003C_003E8__locals7.list_0.Select(_003C_003Ef__AnonymousType103_0 => _003C_003Ef__AnonymousType103_0.index).ToArray()
			}, CS_0024_003C_003E8__locals7.method_2));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_14(JObject jobject_0)
		{
			Class210 @class = new Class210();
			@class.aceMcpNpcGenDocument_0 = RequireNpcGenDocument();
			@class.int_0 = smethod_17(jobject_0).Where(@class.method_0).Distinct().OrderByDescending(Class217.class217_0.method_19)
				.ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = Class16.smethod_0(1649124210),
					indexes = @class.int_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649123645), new
			{
				indexes = @class.int_0
			}, @class.method_1));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_15(JObject jobject_0, string string_0)
		{
			Class215 @class = new Class215();
			@class.string_0 = string_0;
			RequireNpcGenDocument();
			@class.int_1 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649123821)) ?? throw new InvalidOperationException(Class16.smethod_0(1649123832));
			@class.int_0 = smethod_17(jobject_0).Distinct().OrderBy(Class217.class217_0.method_20).ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = @class.string_0,
					indexes = @class.int_0,
					target_index = @class.int_1
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649126956) + @class.string_0, new
			{
				kind = @class.string_0,
				indexes = @class.int_0,
				target_index = @class.int_1
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_16(JObject jobject_0, string string_0)
		{
			Class218 @class = new Class218();
			@class.string_0 = string_0;
			AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
			Dictionary<string, JToken> dictionary = ParseFieldMap(jobject_0, Class16.smethod_0(1649125271));
			@class.int_0 = smethod_17(jobject_0).ToArray();
			List<object> list = new List<object>();
			int[] int_ = @class.int_0;
			foreach (int num in int_)
			{
				string string_1 = @class.string_0;
				object obj = ((string_1 == Class16.smethod_0(1649124179)) ? ((num < 0 || num >= aceMcpNpcGenDocument.Data.NpcMobList.Count) ? null : aceMcpNpcGenDocument.Data.NpcMobList[num]) : ((string_1 == Class16.smethod_0(1649124195)) ? ((num < 0 || num >= aceMcpNpcGenDocument.Data.ResourcesList.Count) ? null : aceMcpNpcGenDocument.Data.ResourcesList[num]) : ((string_1 == Class16.smethod_0(1649081621)) ? ((object)((num < 0 || num >= aceMcpNpcGenDocument.Data.TriggersList.Count) ? null : aceMcpNpcGenDocument.Data.TriggersList[num])) : ((object)((string_1 == Class16.smethod_0(1649124210)) ? ((num < 0 || num >= aceMcpNpcGenDocument.Data.DynamicsList.Count) ? null : aceMcpNpcGenDocument.Data.DynamicsList[num]) : null)))));
				object obj2 = obj;
				if (obj2 == null)
				{
					continue;
				}
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
				foreach (KeyValuePair<string, JToken> item in dictionary)
				{
					dictionary2[item.Key] = GetMemberValue(obj2, item.Key);
				}
				list.Add(new
				{
					kind = @class.string_0,
					index = num,
					old_values = dictionary2,
					new_values = dictionary
				});
			}
			@class.dictionary_0 = dictionary.ToDictionary(Class217.class217_0.method_21, Class217.class217_0.method_22, StringComparer.OrdinalIgnoreCase);
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					kind = @class.string_0,
					indexes = @class.int_0,
					entries = list
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906400), Class16.smethod_0(1649126960) + @class.string_0 + Class16.smethod_0(1649126971), new
			{
				kind = @class.string_0,
				indexes = @class.int_0,
				fields = @class.dictionary_0.Keys.ToArray()
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static int[] smethod_17(JObject jobject_0)
		{
			return ParseIntList(jobject_0, Class16.smethod_0(1649126985)).ToArray();
		}

		private static T smethod_18<T>(JObject jobject_0, string string_0) where T : class
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Invalid comparison between Unknown and I4
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Invalid comparison between Unknown and I4
			JToken val = jobject_0[string_0];
			if (val != null && (int)val.Type != 10)
			{
				if ((int)val.Type == 8)
				{
					string text = Extensions.Value<string>((IEnumerable<JToken>)val);
					if (!string.IsNullOrWhiteSpace(text))
					{
						return JsonConvert.DeserializeObject<T>(text);
					}
					return null;
				}
				return val.ToObject<T>();
			}
			return null;
		}

		private static string smethod_19(string string_0)
		{
			if (string.IsNullOrWhiteSpace(string_0))
			{
				throw new InvalidOperationException(Class16.smethod_0(1649127007));
			}
			string_0 = string_0.Trim().ToLowerInvariant();
			if (string_0 != null)
			{
				switch (string_0.Length)
				{
				case 14:
					if (!(string_0 == Class16.smethod_0(1649124210)))
					{
						break;
					}
					goto IL_01c6;
				case 3:
				{
					char c = string_0[0];
					if (c != 'm')
					{
						if (c != 'n' || !(string_0 == Class16.smethod_0(1649127051)))
						{
							break;
						}
					}
					else if (!(string_0 == Class16.smethod_0(1649127069)))
					{
						break;
					}
					goto IL_01a7;
				}
				case 7:
				{
					char c = string_0[0];
					if (c != 'd')
					{
						if (c != 't' || !(string_0 == Class16.smethod_0(1649081621)))
						{
							break;
						}
						goto IL_0139;
					}
					if (!(string_0 == Class16.smethod_0(1649127094)))
					{
						break;
					}
					goto IL_01c6;
				}
				case 8:
				{
					char c = string_0[0];
					if (c != 'r')
					{
						if (c != 't' || !(string_0 == Class16.smethod_0(1649127079)))
						{
							break;
						}
						goto IL_0139;
					}
					if (!(string_0 == Class16.smethod_0(1649124195)))
					{
						break;
					}
					goto IL_0188;
				}
				case 9:
					{
						char c = string_0[0];
						if (c != 'd')
						{
							if (c != 'e')
							{
								if (c != 'r' || !(string_0 == Class16.smethod_0(1648908941)))
								{
									break;
								}
								goto IL_0188;
							}
							if (!(string_0 == Class16.smethod_0(1649124179)))
							{
								break;
							}
							goto IL_01a7;
						}
						if (!(string_0 == Class16.smethod_0(1649127035)))
						{
							break;
						}
						goto IL_01c6;
					}
					IL_01c6:
					return Class16.smethod_0(1649124210);
					IL_01a7:
					return Class16.smethod_0(1649124179);
					IL_0188:
					return Class16.smethod_0(1649124195);
					IL_0139:
					return Class16.smethod_0(1649081621);
				}
			}
			throw new InvalidOperationException(Class16.smethod_0(1649127108) + string_0 + Class16.smethod_0(1648928156));
		}

		private static string smethod_20(int int_0)
		{
			eListCollection elements = DataFiles.Elements;
			if (elements != null && int_0 > 0)
			{
				ITEMPOS iTEMPOS = elements.FindItemPos(elements.NpcMobMineLists, int_0);
				if (!(iTEMPOS != null))
				{
					return int_0.ToString(CultureInfo.InvariantCulture);
				}
				return elements.GetParsedItemName(iTEMPOS);
			}
			return int_0.ToString(CultureInfo.InvariantCulture);
		}

		private static T smethod_21<T>(T gparam_0)
		{
			if (gparam_0 == null)
			{
				return default(T);
			}
			return JToken.FromObject((object)gparam_0).ToObject<T>();
		}
	}

	private sealed class Class220
	{
		public IDictionary<string, object> idictionary_0;

		public IDictionary<string, object> idictionary_1;

		public int? nullable_0;

		public string string_0;

		internal void method_0(string string_1, ParameterArgs parameterArgs_0)
		{
			object value2;
			if (idictionary_0 != null && idictionary_0.TryGetValue(string_1, out var value))
			{
				parameterArgs_0.Result = value;
			}
			else if (idictionary_1 != null && idictionary_1.TryGetValue(string_1, out value2))
			{
				parameterArgs_0.Result = value2;
			}
			else if (string.Equals(string_1, Class16.smethod_0(1649129496), StringComparison.OrdinalIgnoreCase))
			{
				parameterArgs_0.Result = nullable_0.GetValueOrDefault();
			}
			else if (string.Equals(string_1, Class16.smethod_0(1649129513), StringComparison.OrdinalIgnoreCase))
			{
				parameterArgs_0.Result = string_0 ?? string.Empty;
			}
			else
			{
				parameterArgs_0.Result = null;
			}
		}

		internal void method_1(string string_1, FunctionArgs functionArgs_0)
		{
			string text = string_1.ToLowerInvariant();
			object obj3;
			if (!(text == Class16.smethod_0(1648932143)))
			{
				if (!(text == Class16.smethod_0(1648905100)))
				{
					if (!(text == Class16.smethod_0(1649133125)))
					{
						if (!(text == Class16.smethod_0(1649129540)))
						{
							if (!(text == Class16.smethod_0(1649129547)))
							{
								if (text == Class16.smethod_0(1649129562))
								{
									decimal d = Convert.ToDecimal(functionArgs_0.Parameters[0].Evaluate(), CultureInfo.InvariantCulture);
									int decimals = ((functionArgs_0.Parameters.Length > 1) ? Convert.ToInt32(functionArgs_0.Parameters[1].Evaluate(), CultureInfo.InvariantCulture) : 0);
									functionArgs_0.Result = Math.Round(d, decimals);
								}
								return;
							}
							Expression[] parameters = functionArgs_0.Parameters;
							int num = 0;
							object obj;
							while (true)
							{
								if (num < parameters.Length)
								{
									Expression val = parameters[num];
									obj = val.Evaluate();
									if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
									{
										break;
									}
									num++;
									continue;
								}
								functionArgs_0.Result = string.Empty;
								return;
							}
							functionArgs_0.Result = obj;
							return;
						}
						object obj2 = functionArgs_0.Parameters[0].Evaluate();
						if (obj2 == null)
						{
							obj3 = null;
						}
						else
						{
							obj3 = obj2.ToString();
							if (obj3 != null)
							{
								goto IL_013e;
							}
						}
						obj3 = string.Empty;
						goto IL_013e;
					}
					functionArgs_0.Result = ((idictionary_1 == null || !idictionary_1.TryGetValue(Class16.smethod_0(1649129582), out var value)) ? string.Empty : value);
					return;
				}
				functionArgs_0.Result = string_0 ?? string.Empty;
				return;
			}
			functionArgs_0.Result = nullable_0.GetValueOrDefault();
			return;
			IL_013e:
			object obj4 = functionArgs_0.Parameters[1].Evaluate();
			object obj5;
			if (obj4 == null)
			{
				obj5 = null;
			}
			else
			{
				obj5 = obj4.ToString();
				if (obj5 != null)
				{
					goto IL_0160;
				}
			}
			obj5 = string.Empty;
			goto IL_0160;
			IL_0160:
			functionArgs_0.Result = ((string)obj3).IndexOf((string)obj5, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}

	private sealed class Class221
	{
		public IDictionary<string, object> idictionary_0;

		internal string method_0(Match match_0)
		{
			object value = EvaluateExpression(match_0.Groups[1].Value, idictionary_0, null, null, null);
			return ConvertToInvariantString(value);
		}
	}

	private sealed class Class222 : IAceMcpDomainHandler
	{
		private sealed class Class223
		{
			public int int_0;

			public Dictionary<string, string> dictionary_0;

			public Class225 class225_0;

			internal void method_0()
			{
				eListCollection eListCollection2 = RequireElements();
				int num = FindElementsItemIndexById(eListCollection2, class225_0.int_0, int_0);
				if (num < 0)
				{
					throw new InvalidOperationException(string.Format(Class16.smethod_0(1649124358), int_0, class225_0.int_0));
				}
				foreach (KeyValuePair<string, string> item in dictionary_0)
				{
					eListCollection2.SetValue(class225_0.int_0, num, eListCollection2.Lists[class225_0.int_0].get_fields(item.Key), item.Value, AutoSaveStage: false);
				}
				eListCollection2.UpdateElementsReferences(class225_0.int_0);
				eListCollection2.UpdateItemCount();
			}
		}

		private sealed class Class224
		{
			public eListCollection eListCollection_0;

			public int int_0;

			public int[] int_1;

			public int int_2;

			public bool bool_0;

			internal int method_0(int int_3)
			{
				return FindElementsItemIndexById(eListCollection_0, int_0, int_3);
			}

			internal int method_1(int int_3)
			{
				return eListCollection_0.Lists[int_0].getid(int_3);
			}

			internal void method_2()
			{
				eListCollection eListCollection2 = RequireElements();
				eListCollection2.SortItemsByFieldValue(int_0, int_1, int_2, bool_0);
				eListCollection2.UpdateNamesCache(int_0);
				eListCollection2.UpdateElementsReferences(int_0);
			}
		}

		private sealed class Class225
		{
			public int int_0;
		}

		private sealed class Class226
		{
			public eListCollection eListCollection_0;

			public int int_0;

			public List<_003C_003Ef__AnonymousType43<int, int>> list_0;

			internal _003C_003Ef__AnonymousType43<int, int> method_0(int int_1)
			{
				return _003C_003Ef__AnonymousType43.Create(
					int_1,
					FindElementsItemIndexById(eListCollection_0, int_0, int_1)
				);
			}

			internal void method_1()
			{
				eListCollection eListCollection2 = RequireElements();
				foreach (var item in list_0.OrderByDescending(_003C_003Ef__AnonymousType43_0 => _003C_003Ef__AnonymousType43_0.itemIndex))
				{
					int num = FindElementsItemIndexById(eListCollection2, int_0, item.itemId);
					if (num >= 0)
					{
						eListCollection2.RemoveItem(int_0, num);
					}
				}
				eListCollection2.UpdateNamesCache(int_0);
				eListCollection2.UpdateElementsReferences(int_0);
				eListCollection2.UpdateItemCount();
			}
		}

		private sealed class Class227
		{
			public int int_0;

			public AceMcpCommandResult aceMcpCommandResult_0;
		}

		private sealed class Class228
		{
			public int int_0;

			public int int_1;

			public int int_2;

			public Dictionary<string, string> dictionary_0;

			internal void method_0()
			{
				eListCollection eListCollection2 = RequireElements();
				int num = Math.Max(0, Math.Min(int_0, eListCollection2.GetItemsCount(int_1)));
				object[] array = eListCollection2.CreateEmptyItem(int_1);
				array[0] = int_2;
				eListCollection2.AddItem(int_1, num, array);
				foreach (KeyValuePair<string, string> item in dictionary_0)
				{
					int num2 = eListCollection2.Lists[int_1].get_fields(item.Key);
					if (num2 >= 0)
					{
						eListCollection2.SetValue(int_1, num, num2, item.Value, AutoSaveStage: false);
					}
				}
				eListCollection2.UpdateNamesCache(int_1);
				eListCollection2.UpdateElementsReferences(int_1);
				eListCollection2.UpdateItemCount();
			}
		}

		private sealed class Class229
		{
			public int int_0;

			public int int_1;

			public Class227 class227_0;

			internal void method_0()
			{
				eListCollection eListCollection_ = RequireElements();
				smethod_11(eListCollection_, class227_0.int_0, int_0, int_1, class227_0.aceMcpCommandResult_0.Warnings);
			}
		}

		private sealed class Class230
		{
			public int int_0;

			public int int_1;

			public List<(int, int, int, object[])> list_0;

			public bool bool_0;

			public bool bool_1;

			internal void method_0()
			{
				eListCollection eListCollection2 = RequireElements();
				int num = Math.Max(0, Math.Min(int_0, eListCollection2.GetItemsCount(int_1)));
				foreach (var item in list_0)
				{
					eListCollection2.AddItem(int_1, num, (object[])item.Item4.Clone());
					num++;
					if ((bool_0 & bool_1) && item.Item3 != item.Item1)
					{
						smethod_11(eListCollection2, int_1, item.Item1, item.Item3, null);
					}
				}
				eListCollection2.UpdateNamesCache(int_1);
				eListCollection2.UpdateElementsReferences(int_1);
				eListCollection2.UpdateItemCount();
			}
		}

		private sealed class Class231
		{
			public List<(int, int, string, string)> list_0;

			public int int_0;

			public string string_0;

			internal void method_0()
			{
				eListCollection eListCollection2 = RequireElements();
				foreach (var item in list_0)
				{
					int num = FindElementsItemIndexById(eListCollection2, int_0, item.Item1);
					if (num >= 0)
					{
						eListCollection2.SetValue(int_0, num, eListCollection2.Lists[int_0].get_fields(string_0), item.Item4, AutoSaveStage: false);
					}
				}
				eListCollection2.UpdateNamesCache(int_0);
				eListCollection2.UpdateElementsReferences(int_0);
			}
		}

		[Serializable]
		private sealed class Class232
		{
			public static readonly Class232 class232_0 = new Class232();

			public static Func<KeyValuePair<string, JToken>, string> func_0;

			public static Func<KeyValuePair<string, JToken>, string> func_1;

			public static Func<KeyValuePair<string, JToken>, string> func_2;

			public static Func<KeyValuePair<string, JToken>, string> func_3;

			public static Func<(int, int, int, object[]), _003C_003Ef__AnonymousType41<int, int, int>> func_4;

			public static Func<_003C_003Ef__AnonymousType43<int, int>, bool> func_5;

			public static Func<_003C_003Ef__AnonymousType43<int, int>, int> func_6;

			public static Func<_003C_003Ef__AnonymousType43<int, int>, _003C_003Ef__AnonymousType45<int, int>> func_7;

			public static Func<_003C_003Ef__AnonymousType43<int, int>, int> func_8;

			public static Func<_003C_003Ef__AnonymousType43<int, int>, int> func_9;

			public static Func<(int, int, string, string), _003C_003Ef__AnonymousType47<int, int, string, string>> func_10;

			public static Func<int, bool> func_11;

			public static Func<(int, int, string, string), _003C_003Ef__AnonymousType52<int, int, string, string>> func_12;

			internal string method_0(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}

			internal string method_1(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return ConvertToInvariantString(ConvertJTokenToClrValue(keyValuePair_0.Value, typeof(object)));
			}

			internal string method_2(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return keyValuePair_0.Key;
			}

			internal string method_3(KeyValuePair<string, JToken> keyValuePair_0)
			{
				return ConvertToInvariantString(ConvertJTokenToClrValue(keyValuePair_0.Value, typeof(object)));
			}

			internal _003C_003Ef__AnonymousType41<int, int, int> method_4((int, int, int, object[]) valueTuple_0)
			{
				return _003C_003Ef__AnonymousType41.Create(
					valueTuple_0.Item1,
					valueTuple_0.Item2,
					valueTuple_0.Item3
				);
			}

			internal bool method_5(_003C_003Ef__AnonymousType43<int, int> _003C_003Ef__AnonymousType43_0)
			{
				return _003C_003Ef__AnonymousType43_0.itemIndex >= 0;
			}

			internal int method_6(_003C_003Ef__AnonymousType43<int, int> _003C_003Ef__AnonymousType43_0)
			{
				return _003C_003Ef__AnonymousType43_0.itemIndex;
			}

			internal _003C_003Ef__AnonymousType45<int, int> method_7(_003C_003Ef__AnonymousType43<int, int> _003C_003Ef__AnonymousType43_0)
			{
				return _003C_003Ef__AnonymousType45.Create(
					_003C_003Ef__AnonymousType43_0.itemId,
					_003C_003Ef__AnonymousType43_0.itemIndex
				);
			}

			internal int method_8(_003C_003Ef__AnonymousType43<int, int> _003C_003Ef__AnonymousType43_0)
			{
				return _003C_003Ef__AnonymousType43_0.itemId;
			}

			internal int method_9(_003C_003Ef__AnonymousType43<int, int> _003C_003Ef__AnonymousType43_0)
			{
				return _003C_003Ef__AnonymousType43_0.itemIndex;
			}

			internal _003C_003Ef__AnonymousType47<int, int, string, string> method_10((int, int, string, string) valueTuple_0)
			{
				return _003C_003Ef__AnonymousType47.Create(
					valueTuple_0.Item1,
					valueTuple_0.Item2,
					valueTuple_0.Item3,
					valueTuple_0.Item4
				);
			}

			internal bool method_11(int int_0)
			{
				return int_0 >= 0;
			}

			internal _003C_003Ef__AnonymousType52<int, int, string, string> method_12((int, int, string, string) valueTuple_0)
			{
				return _003C_003Ef__AnonymousType52.Create(
					valueTuple_0.Item1,
					valueTuple_0.Item2,
					valueTuple_0.Item3,
					valueTuple_0.Item4
				);
			}
		}

		private sealed class Class233
		{
			public List<(int, int, string, string)> list_0;

			public int int_0;

			internal void method_0()
			{
				eListCollection eListCollection2 = RequireElements();
				foreach (var item in list_0)
				{
					int num = FindElementsItemIndexById(eListCollection2, int_0, item.Item1);
					if (num >= 0)
					{
						eListCollection2.SetValue(int_0, num, eListCollection2.Lists[int_0].NameFieldIndex, item.Item4, AutoSaveStage: false);
					}
				}
				eListCollection2.UpdateNamesCache(int_0);
			}
		}

		public string Domain => Class16.smethod_0(1648906367);

		public string GetFingerprint()
		{
			return AceMcpRuntime.smethod_5();
		}

		public AceMcpCommandResult Execute(string action, JObject parameters)
		{
			string text = (action ?? string.Empty).Trim().ToLowerInvariant();
			if (text != null)
			{
				switch (text.Length)
				{
				case 8:
					if (text == Class16.smethod_0(1649124492))
					{
						return smethod_3(parameters);
					}
					break;
				case 10:
					switch (text[1])
					{
					case 'o':
						if (text == Class16.smethod_0(1649124467))
						{
							return smethod_7(parameters);
						}
						break;
					case 'e':
						if (text == Class16.smethod_0(1649124450))
						{
							return smethod_2(parameters);
						}
						break;
					}
					break;
				case 11:
					switch (text[0])
					{
					case 'r':
						if (text == Class16.smethod_0(1649124422))
						{
							return smethod_1(parameters);
						}
						break;
					case 'q':
						if (text == Class16.smethod_0(1649124404))
						{
							return smethod_0(parameters);
						}
						break;
					case 'c':
						if (text == Class16.smethod_0(1649124432))
						{
							return smethod_4(parameters);
						}
						break;
					}
					break;
				case 12:
					switch (text[0])
					{
					case 'r':
						if (text == Class16.smethod_0(1649124526))
						{
							return smethod_6(parameters);
						}
						break;
					case 'd':
						if (text == Class16.smethod_0(1649124499))
						{
							return smethod_5(parameters);
						}
						break;
					}
					break;
				case 16:
					if (text == Class16.smethod_0(1649124537))
					{
						return smethod_8(parameters);
					}
					break;
				case 18:
					if (text == Class16.smethod_0(1649124560))
					{
						return smethod_9(parameters);
					}
					break;
				}
			}
			throw new InvalidOperationException(Class16.smethod_0(1649124585) + action + Class16.smethod_0(1648928156));
		}

		private static AceMcpCommandResult smethod_0(JObject jobject_0)
		{
			eListCollection eListCollection2 = RequireElements();
			string text = GetString(jobject_0, Class16.smethod_0(1649124629));
			string text2 = GetString(jobject_0, Class16.smethod_0(1649124633));
			string text3 = GetString(jobject_0, Class16.smethod_0(1649124650));
			int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124676)) ?? 50;
			int num2 = -1;
			if (jobject_0[Class16.smethod_0(1649124680)] != null || jobject_0[Class16.smethod_0(1649124703)] != null)
			{
				num2 = ResolveElementsListIndex(eListCollection2, jobject_0);
			}
			List<object> list = new List<object>();
			int num3 = ((num2 >= 0) ? num2 : 0);
			int num4 = ((num2 >= 0) ? (num2 + 1) : eListCollection2.ListCount);
			for (int i = num3; i < num4; i++)
			{
				if (list.Count >= num)
				{
					break;
				}
				eList eList2 = eListCollection2.Lists[i];
				if (eList2 == null)
				{
					continue;
				}
				int num5 = ((!string.IsNullOrWhiteSpace(text2)) ? eList2.get_fields(text2) : (-1));
				for (int j = 0; j < eList2.ItemCount && list.Count < num; j++)
				{
					string text4 = ((eList2.NamesCache == null || j >= eList2.NamesCache.Length) ? eListCollection2.GetValue(i, j, eList2.NameFieldIndex) : eList2.NamesCache[j]);
					if (!string.IsNullOrWhiteSpace(text) && (text4 == null || text4.IndexOf(text, StringComparison.OrdinalIgnoreCase) < 0))
					{
						continue;
					}
					if (num5 >= 0)
					{
						string value = eListCollection2.GetValue(i, j, num5);
						if (!string.Equals(value, text3, StringComparison.OrdinalIgnoreCase))
						{
							continue;
						}
					}
					list.Add(new
					{
						list_index = i,
						list_name = eList2.uListName,
						item_index = j,
						id = eList2.getid(j),
						name = text4
					});
				}
			}
			return new AceMcpCommandResult
			{
				Data = new
				{
					query = text,
					field_name = text2,
					field_value = text3,
					count = list.Count,
					items = list
				}
			};
		}

		private static AceMcpCommandResult smethod_1(JObject jobject_0)
		{
			eListCollection eListCollection2 = RequireElements();
			int num = ResolveElementsListIndex(eListCollection2, jobject_0);
			string[] array = ResolveElementsFieldNames(eListCollection2, num, jobject_0);
			List<object> list = new List<object>();
			foreach (int item in ParseIntList(jobject_0, Class16.smethod_0(1649124719)))
			{
				int num2 = FindElementsItemIndexById(eListCollection2, num, item);
				if (num2 >= 0)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
					string[] array2 = array;
					foreach (string text in array2)
					{
						dictionary[text] = eListCollection2.GetValue(num, num2, text);
					}
					list.Add(new
					{
						item_id = item,
						item_index = num2,
						fields = dictionary
					});
				}
			}
			return new AceMcpCommandResult
			{
				Data = new
				{
					list_idx = num,
					field_names = array,
					items = list
				}
			};
		}

		private static AceMcpCommandResult smethod_2(JObject jobject_0)
		{
			Class225 @class = new Class225();
			eListCollection eListCollection2 = RequireElements();
			@class.int_0 = ResolveElementsListIndex(eListCollection2, jobject_0);
			Dictionary<string, JToken> dictionary = ParseFieldMap(jobject_0, Class16.smethod_0(1649125271));
			List<IAceMcpChangeOperation> list = new List<IAceMcpChangeOperation>();
			List<object> list2 = new List<object>();
			using (List<int>.Enumerator enumerator = ParseIntList(jobject_0, Class16.smethod_0(1649124719)).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Class223 class2 = new Class223();
					class2.class225_0 = @class;
					class2.int_0 = enumerator.Current;
					int num = FindElementsItemIndexById(eListCollection2, class2.class225_0.int_0, class2.int_0);
					if (num < 0)
					{
						continue;
					}
					Dictionary<string, string> dictionary2 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
					Dictionary<string, string> dictionary3 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
					foreach (KeyValuePair<string, JToken> item in dictionary)
					{
						dictionary2[item.Key] = eListCollection2.GetValue(class2.class225_0.int_0, num, item.Key);
						dictionary3[item.Key] = ConvertToInvariantString(ConvertJTokenToClrValue(item.Value, typeof(object)));
					}
					list2.Add(new
					{
						item_id = class2.int_0,
						item_index = num,
						old_values = dictionary2,
						new_values = dictionary3
					});
					class2.dictionary_0 = new Dictionary<string, string>(dictionary3, StringComparer.OrdinalIgnoreCase);
					list.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124450), new
					{
						list_idx = class2.class225_0.int_0,
						item_id = class2.int_0,
						fields = class2.dictionary_0
					}, class2.method_0));
				}
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					list_idx = @class.int_0,
					items = list2
				}
			};
			aceMcpCommandResult.Operations.AddRange(list);
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_3(JObject jobject_0)
		{
			Class228 @class = new Class228();
			eListCollection eListCollection2 = RequireElements();
			@class.int_1 = ResolveElementsListIndex(eListCollection2, jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124734)) ?? eListCollection2.GetItemsCount(@class.int_1);
			int firstnewid = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124750)).GetValueOrDefault();
			bool flag = ((JToken)jobject_0).Value<bool?>((object)Class16.smethod_0(1649124755)) ?? true;
			Dictionary<string, JToken> dictionary = ParseFieldMap(jobject_0, Class16.smethod_0(1649125271));
			@class.int_2 = (flag ? eListCollection2.GetFreeID(@class.int_1, ref firstnewid) : ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124750)).GetValueOrDefault());
			int nameFieldIndex = eListCollection2.Lists[@class.int_1].NameFieldIndex;
			string text = ((nameFieldIndex >= 0) ? eListCollection2.Lists[@class.int_1].elementFields[nameFieldIndex] : null);
			JToken value;
			string name = ((string.IsNullOrWhiteSpace(text) || !dictionary.TryGetValue(text, out value)) ? null : ConvertToInvariantString(ConvertJTokenToClrValue(value, typeof(object))));
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					list_idx = @class.int_1,
					insert_at = @class.int_0,
					new_id = @class.int_2,
					name = name,
					fields = dictionary.ToDictionary(Class232.class232_0.method_0, Class232.class232_0.method_1)
				}
			};
			@class.dictionary_0 = dictionary.ToDictionary(Class232.class232_0.method_2, Class232.class232_0.method_3, StringComparer.OrdinalIgnoreCase);
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124492), new
			{
				list_idx = @class.int_1,
				insert_at = @class.int_0,
				new_id = @class.int_2,
				name = name
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_4(JObject jobject_0)
		{
			Class230 @class = new Class230();
			eListCollection eListCollection2 = RequireElements();
			@class.int_1 = ResolveElementsListIndex(eListCollection2, jobject_0);
			@class.int_0 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124734)) ?? eListCollection2.GetItemsCount(@class.int_1);
			@class.bool_1 = ((JToken)jobject_0).Value<bool?>((object)Class16.smethod_0(1649124783)) ?? true;
			@class.bool_0 = ((JToken)jobject_0).Value<bool?>((object)Class16.smethod_0(1649124804)) == true;
			int firstnewid = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124830)).GetValueOrDefault();
			@class.list_0 = new List<(int, int, int, object[])>();
			foreach (int item in ParseIntList(jobject_0, Class16.smethod_0(1649124719)))
			{
				int num = FindElementsItemIndexById(eListCollection2, @class.int_1, item);
				if (num >= 0)
				{
					object[] array = (object[])eListCollection2.Lists[@class.int_1].elementValues[num].Clone();
					int num2 = item;
					if (@class.bool_1)
					{
						num2 = eListCollection2.GetFreeID(@class.int_1, ref firstnewid);
						array[0] = num2;
					}
					@class.list_0.Add((item, num, num2, array));
				}
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					list_idx = @class.int_1,
					clones = @class.list_0.Select(((int, int, int, object[]) valueTuple_0) => _003C_003Ef__AnonymousType41.Create(
						valueTuple_0.Item1,
						valueTuple_0.Item2,
						valueTuple_0.Item3
					)).ToArray(),
					refactor_references = @class.bool_0
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124432), new
			{
				list_idx = @class.int_1,
				clone_count = @class.list_0.Count,
				refactor_references = @class.bool_0
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_5(JObject jobject_0)
		{
			Class226 CS_0024_003C_003E8__locals11 = new Class226();
			CS_0024_003C_003E8__locals11.eListCollection_0 = RequireElements();
			CS_0024_003C_003E8__locals11.int_0 = ResolveElementsListIndex(CS_0024_003C_003E8__locals11.eListCollection_0, jobject_0);
			CS_0024_003C_003E8__locals11.list_0 = (from int_1 in ParseIntList(jobject_0, Class16.smethod_0(1649124719))
				select _003C_003Ef__AnonymousType43.Create(
					int_1,
					FindElementsItemIndexById(CS_0024_003C_003E8__locals11.eListCollection_0, CS_0024_003C_003E8__locals11.int_0, int_1)
				) into _003C_003Ef__AnonymousType43_0
				where _003C_003Ef__AnonymousType43_0.itemIndex >= 0
				orderby _003C_003Ef__AnonymousType43_0.itemIndex descending
				select _003C_003Ef__AnonymousType43_0).ToList();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					list_idx = CS_0024_003C_003E8__locals11.int_0,
					deleted = CS_0024_003C_003E8__locals11.list_0.Select(_003C_003Ef__AnonymousType43_0 => _003C_003Ef__AnonymousType45.Create(
						_003C_003Ef__AnonymousType43_0.itemId,
						_003C_003Ef__AnonymousType43_0.itemIndex
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124499), new
			{
				list_idx = CS_0024_003C_003E8__locals11.int_0,
				item_ids = CS_0024_003C_003E8__locals11.list_0.Select(_003C_003Ef__AnonymousType43_0 => _003C_003Ef__AnonymousType43_0.itemId).ToArray()
			}, CS_0024_003C_003E8__locals11.method_1));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_6(JObject jobject_0)
		{
			Class233 @class = new Class233();
			eListCollection eListCollection2 = RequireElements();
			@class.int_0 = ResolveElementsListIndex(eListCollection2, jobject_0);
			string text = GetString(jobject_0, Class16.smethod_0(1649124841));
			JObject jsonObjectParameter = GetJsonObjectParameter(jobject_0, Class16.smethod_0(1649123845));
			if (string.IsNullOrWhiteSpace(text) && !jsonObjectParameter.Properties().Any())
			{
				throw new InvalidOperationException(Class16.smethod_0(1649123857));
			}
			@class.list_0 = new List<(int, int, string, string)>();
			foreach (int item2 in ParseIntList(jobject_0, Class16.smethod_0(1649124719)))
			{
				int num = FindElementsItemIndexById(eListCollection2, @class.int_0, item2);
				if (num >= 0)
				{
					string value = eListCollection2.GetValue(@class.int_0, num, eListCollection2.Lists[@class.int_0].NameFieldIndex);
					string text2 = ((JToken)jsonObjectParameter).Value<string>((object)item2.ToString(CultureInfo.InvariantCulture));
					string item = ((!string.IsNullOrWhiteSpace(text2)) ? text2 : (text ?? string.Empty).Replace(Class16.smethod_0(1649123921), value ?? string.Empty).Replace(Class16.smethod_0(1649123938), item2.ToString(CultureInfo.InvariantCulture)).Replace(Class16.smethod_0(1649123957), num.ToString(CultureInfo.InvariantCulture)));
					@class.list_0.Add((item2, num, value, item));
				}
			}
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					list_idx = @class.int_0,
					items = @class.list_0.Select(((int, int, string, string) valueTuple_0) => _003C_003Ef__AnonymousType47.Create(
						valueTuple_0.Item1,
						valueTuple_0.Item2,
						valueTuple_0.Item3,
						valueTuple_0.Item4
					)).ToArray()
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124526), new
			{
				list_idx = @class.int_0,
				count = @class.list_0.Count
			}, @class.method_0));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_7(JObject jobject_0)
		{
			Class224 @class = new Class224();
			@class.eListCollection_0 = RequireElements();
			@class.int_0 = ResolveElementsListIndex(@class.eListCollection_0, jobject_0);
			string text = GetString(jobject_0, Class16.smethod_0(1649124633));
			@class.int_2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649123963)) ?? (-1);
			@class.bool_0 = ((JToken)jobject_0).Value<bool?>((object)Class16.smethod_0(1649123979)) == true;
			if (@class.int_2 < 0)
			{
				@class.int_2 = ((!string.IsNullOrWhiteSpace(text)) ? @class.eListCollection_0.Lists[@class.int_0].get_fields(text) : @class.eListCollection_0.Lists[@class.int_0].NameFieldIndex);
			}
			List<int> list = ParseIntList(jobject_0, Class16.smethod_0(1649124719));
			@class.int_1 = ((list.Count > 0) ? list.Select(@class.method_0).Where(Class232.class232_0.method_11).ToArray() : Enumerable.Range(0, @class.eListCollection_0.Lists[@class.int_0].ItemCount).ToArray());
			int[] order = @class.int_1.Select(@class.method_1).ToArray();
			AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
			{
				Data = new
				{
					list_idx = @class.int_0,
					field_idx = @class.int_2,
					field_name = @class.eListCollection_0.Lists[@class.int_0].elementFields[@class.int_2],
					descending = @class.bool_0,
					order = order
				}
			};
			aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124467), new
			{
				list_idx = @class.int_0,
				field_idx = @class.int_2,
				descending = @class.bool_0,
				item_count = @class.int_1.Length
			}, @class.method_2));
			return aceMcpCommandResult;
		}

		private static AceMcpCommandResult smethod_8(JObject jobject_0)
		{
			Class231 @class = new Class231();
			eListCollection eListCollection2 = RequireElements();
			@class.int_0 = ResolveElementsListIndex(eListCollection2, jobject_0);
			@class.string_0 = GetString(jobject_0, Class16.smethod_0(1649124004));
			string text = GetString(jobject_0, Class16.smethod_0(1649124023));
			if (!string.IsNullOrWhiteSpace(@class.string_0) && !string.IsNullOrWhiteSpace(text))
			{
				@class.list_0 = new List<(int, int, string, string)>();
				string uListName = eListCollection2.Lists[@class.int_0].uListName;
				foreach (int item2 in ParseIntList(jobject_0, Class16.smethod_0(1649124719)))
				{
					int num = FindElementsItemIndexById(eListCollection2, @class.int_0, item2);
					if (num >= 0)
					{
						Dictionary<string, object> fields = ReadElementsFieldContext(eListCollection2, @class.int_0, num);
						Dictionary<string, object> variables = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase) { [Class16.smethod_0(1649129582)] = uListName };
						string value = eListCollection2.GetValue(@class.int_0, num, eListCollection2.Lists[@class.int_0].NameFieldIndex);
						string value2 = eListCollection2.GetValue(@class.int_0, num, @class.string_0);
						object value3 = EvaluateExpression(text, variables, fields, item2, value);
						string item = ConvertToInvariantString(value3);
						@class.list_0.Add((item2, num, value2, item));
					}
				}
				AceMcpCommandResult aceMcpCommandResult = new AceMcpCommandResult
				{
					Data = new
					{
						list_idx = @class.int_0,
						target_field = @class.string_0,
						expression = text,
						items = @class.list_0.Select(((int, int, string, string) valueTuple_0) => _003C_003Ef__AnonymousType52.Create(
							valueTuple_0.Item1,
							valueTuple_0.Item2,
							valueTuple_0.Item3,
							valueTuple_0.Item4
						)).ToArray()
					}
				};
				aceMcpCommandResult.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124537), new
				{
					list_idx = @class.int_0,
					target_field = @class.string_0,
					expression = text,
					item_count = @class.list_0.Count
				}, @class.method_0));
				return aceMcpCommandResult;
			}
			throw new InvalidOperationException(Class16.smethod_0(1649124032));
		}

		private static AceMcpCommandResult smethod_9(JObject jobject_0)
		{
			Class227 @class = new Class227();
			eListCollection eListCollection2 = RequireElements();
			@class.int_0 = ResolveElementsListIndex(eListCollection2, jobject_0);
			JObject jsonObjectParameter = GetJsonObjectParameter(jobject_0, Class16.smethod_0(1649124103));
			List<object> list = new List<object>();
			@class.aceMcpCommandResult_0 = new AceMcpCommandResult();
			foreach (JProperty item in jsonObjectParameter.Properties())
			{
				Class229 class2 = new Class229();
				class2.class227_0 = @class;
				class2.int_0 = int.Parse(item.Name, CultureInfo.InvariantCulture);
				class2.int_1 = Extensions.Value<int>((IEnumerable<JToken>)item.Value);
				ITEMPOS iTEMPOS = smethod_10(eListCollection2, class2.int_0, class2.class227_0.int_0);
				if (iTEMPOS == null)
				{
					class2.class227_0.aceMcpCommandResult_0.Warnings.Add(string.Format(Class16.smethod_0(1649124358), class2.int_0, class2.class227_0.int_0));
					continue;
				}
				List<ELEMENTS_REFERENCES_SUITE> dest = null;
				int references = eListCollection2.GetReferences(ref dest, iTEMPOS);
				list.Add(new
				{
					old_id = class2.int_0,
					new_id = class2.int_1,
					references = references
				});
				class2.class227_0.aceMcpCommandResult_0.Operations.Add(new AceMcpDelegateChangeOperation(Class16.smethod_0(1648906367), Class16.smethod_0(1649124560), new
				{
					list_idx = class2.class227_0.int_0,
					old_id = class2.int_0,
					new_id = class2.int_1,
					references = references
				}, class2.method_0));
			}
			@class.aceMcpCommandResult_0.Data = new
			{
				list_idx = @class.int_0,
				rewrites = list
			};
			return @class.aceMcpCommandResult_0;
		}

		private static ITEMPOS smethod_10(eListCollection eListCollection_0, int int_0, int int_1)
		{
			if (int_1 >= 0)
			{
				int num = FindElementsItemIndexById(eListCollection_0, int_1, int_0);
				if (num < 0)
				{
					return null;
				}
				return new ITEMPOS(int_1, num);
			}
			ITEMPOS iTEMPOS = eListCollection_0.FindItemPos(eListCollection_0.MattersLists, int_0);
			if (iTEMPOS == null && eListCollection_0.AllLists != null)
			{
				iTEMPOS = eListCollection_0.FindItemPos(eListCollection_0.AllLists, int_0);
			}
			return iTEMPOS;
		}

		private static void smethod_11(eListCollection eListCollection_0, int int_0, int int_1, int int_2, ICollection<string> icollection_0)
		{
			ITEMPOS iTEMPOS = smethod_10(eListCollection_0, int_1, int_0);
			if (iTEMPOS == null)
			{
				throw new InvalidOperationException(string.Format(Class16.smethod_0(1649124358), int_1, int_0));
			}
			List<ELEMENTS_REFERENCES_SUITE> dest = null;
			eListCollection_0.GetReferences(ref dest, iTEMPOS);
			if (dest == null)
			{
				return;
			}
			foreach (ELEMENTS_REFERENCES_SUITE item in dest)
			{
				if (item?.refs == null)
				{
					continue;
				}
				foreach (REFERENCE_ENTRY @ref in item.refs)
				{
					REFERENCE_ENTRY reference_ENTRY_ = @ref;
					if (!smethod_13(eListCollection_0, item.RefType, ref reference_ENTRY_, int_2, null, null))
					{
						icollection_0?.Add(string.Format(Class16.smethod_0(1649124126), item.RefType.DataFileType, int_1));
					}
				}
			}
			eListCollection_0.UpdateElementsReferences();
		}
	}

	[Serializable]
	private sealed class Class234
	{
		public static readonly Class234 class234_0 = new Class234();

		public static Func<eList, bool> func_0;

		public static Func<eList, _003C_003Ef__AnonymousType21<int, string, int, int>> func_1;

		public static Func<eList, bool> func_2;

		public static Func<ATaskTempl, _003C_003Ef__AnonymousType25<int, string, int>> func_3;

		public static Func<CPolicyData, _003C_003Ef__AnonymousType27<int, int, int>> func_4;

		public static Func<JProperty, string> func_5;

		public static Func<JProperty, JToken> func_6;

		public static Func<string, int> func_7;

		public static Func<Form, bool> func_8;

		internal bool method_0(eList eList_0)
		{
			return eList_0 != null;
		}

		internal _003C_003Ef__AnonymousType21<int, string, int, int> method_1(eList eList_0)
		{
			return _003C_003Ef__AnonymousType21.Create(
				eList_0.ListIndex,
				eList_0.uListName,
				eList_0.ItemCount,
				eList_0.FieldCount
			);
		}

		internal bool method_2(eList eList_0)
		{
			return eList_0 != null;
		}

		internal _003C_003Ef__AnonymousType25<int, string, int> method_3(ATaskTempl ataskTempl_0)
		{
			return _003C_003Ef__AnonymousType25.Create(
				ataskTempl_0.ID,
				ataskTempl_0.Name,
				ataskTempl_0.m_nSubCount
			);
		}

		internal _003C_003Ef__AnonymousType27<int, int, int> method_4(CPolicyData cpolicyData_0)
		{
			return _003C_003Ef__AnonymousType27.Create(
				cpolicyData_0.ID,
				cpolicyData_0.Version,
				(cpolicyData_0.Triggers?.Count ?? 0)
			);
		}

		internal string method_5(JProperty jproperty_0)
		{
			return jproperty_0.Name;
		}

		internal JToken method_6(JProperty jproperty_0)
		{
			return jproperty_0.Value;
		}

		internal int method_7(string string_0)
		{
			return int.Parse(string_0.Trim(), CultureInfo.InvariantCulture);
		}

		internal bool method_8(Form form_0)
		{
			return form_0.GetType().FullName == Class16.smethod_0(1649130488);
		}
	}

	private static readonly object object_0 = new object();

	private static readonly IAceMcpChangeSetStore iaceMcpChangeSetStore_0 = new AceMcpChangeSetStore();

	private static readonly IAceMcpMutationPlanner iaceMcpMutationPlanner_0 = new AceMcpMutationPlanner(iaceMcpChangeSetStore_0);

	private static readonly IAceMcpFileService iaceMcpFileService_0 = new AceMcpFileService();

	private static readonly IAceMcpScriptEngine iaceMcpScriptEngine_0 = new AceMcpScriptEngine(iaceMcpChangeSetStore_0);

	private static readonly Dictionary<string, IAceMcpDomainHandler> dictionary_0 = new Dictionary<string, IAceMcpDomainHandler>(StringComparer.OrdinalIgnoreCase);

	private static AceMcpNpcGenDocument aceMcpNpcGenDocument_0;

	private static bool bool_0;

	internal static object DispatchV2(JObject request)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		smethod_1();
		string text = GetString(request, Class16.smethod_0(1649014943));
		string text2 = GetString(request, Class16.smethod_0(1649126614));
		if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(text2))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649126619));
		}
		JObject parameters = (JObject)(((object)((JToken)request).Value<JObject>((object)Class16.smethod_0(1649126677))) ?? ((object)new JObject()));
		return Dispatch(text, text2, parameters);
	}

	internal static object Dispatch(string domain, string action, JObject parameters)
	{
		smethod_1();
		domain = domain?.Trim().ToLowerInvariant();
		action = action?.Trim();
		if (!(domain == Class16.smethod_0(1649126682)))
		{
			if (!(domain == Class16.smethod_0(1648962188)))
			{
				AceMcpCommandResult aceMcpCommandResult = DispatchInternal(domain, action, parameters);
				return iaceMcpMutationPlanner_0.Complete(GetString(parameters, Class16.smethod_0(1649126739)), aceMcpCommandResult, aceMcpCommandResult.PreferredDomain ?? domain);
			}
			if (!string.Equals(action, Class16.smethod_0(1649126703), StringComparison.OrdinalIgnoreCase))
			{
				throw new InvalidOperationException(Class16.smethod_0(1649126705) + action + Class16.smethod_0(1648928156));
			}
			return iaceMcpScriptEngine_0.Run(parameters);
		}
		return smethod_2(action, parameters);
	}

	internal static AceMcpCommandResult DispatchInternal(string domain, string action, JObject parameters)
	{
		smethod_1();
		if (string.IsNullOrWhiteSpace(domain))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649126760));
		}
		if (string.IsNullOrWhiteSpace(action))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649126806));
		}
		if (!dictionary_0.TryGetValue(domain, out var value))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649126844) + domain + Class16.smethod_0(1648928156));
		}
		AceMcpCommandResult aceMcpCommandResult = value.Execute(action, parameters) ?? new AceMcpCommandResult();
		AceMcpCommandResult aceMcpCommandResult2 = aceMcpCommandResult;
		if (aceMcpCommandResult2.PreferredDomain == null)
		{
			aceMcpCommandResult2.PreferredDomain = value.Domain;
		}
		return aceMcpCommandResult;
	}

	internal static string GetDomainFingerprint(string domain)
	{
		smethod_1();
		domain = domain?.Trim().ToLowerInvariant();
		if (string.Equals(domain, Class16.smethod_0(1648906400), StringComparison.OrdinalIgnoreCase))
		{
			return smethod_8();
		}
		if (domain != null && dictionary_0.TryGetValue(domain, out var value))
		{
			return value.GetFingerprint();
		}
		return Class16.smethod_0(1649126871);
	}

	internal static object GetModuleStatus(string module)
	{
		module = NormalizeModule(module);
		if (!(module == Class16.smethod_0(1648906367)))
		{
			if (!(module == Class16.smethod_0(1648906421)))
			{
				if (!(module == Class16.smethod_0(1648942729)))
				{
					if (!(module == Class16.smethod_0(1648906400)))
					{
						return new
						{
							module = module,
							loaded = false,
							path = (string)null,
							fingerprint = Class16.smethod_0(1649126881)
						};
					}
					return new
					{
						module = module,
						loaded = (aceMcpNpcGenDocument_0?.Data != null),
						path = aceMcpNpcGenDocument_0?.FileName,
						file_changed = (aceMcpNpcGenDocument_0?.FileChanged ?? false),
						fingerprint = GetDomainFingerprint(module)
					};
				}
				return new
				{
					module = module,
					loaded = (DataFiles.AIPolicy != null),
					path = DataFiles.AIPolicy?.FilePath,
					fingerprint = GetDomainFingerprint(module)
				};
			}
			return new
			{
				module = module,
				loaded = (DataFiles.Tasks != null && DataFiles.Tasks.FileLoaded),
				path = DataFiles.Tasks?.FileName,
				file_changed = (DataFiles.Tasks?.FileChanged ?? false),
				fingerprint = GetDomainFingerprint(module)
			};
		}
		return new
		{
			module = module,
			loaded = (DataFiles.Elements != null && DataFiles.Elements.FileLoaded),
			path = DataFiles.Elements?.FileName,
			file_changed = (DataFiles.Elements?.FileChanged ?? false),
			fingerprint = GetDomainFingerprint(module)
		};
	}

	internal static string NormalizeModule(string module)
	{
		if (!string.IsNullOrWhiteSpace(module))
		{
			return module.Trim().ToLowerInvariant();
		}
		return null;
	}

	internal static string GetModulePath(string module)
	{
		module = NormalizeModule(module);
		object obj;
		object obj2;
		object obj3;
		if (!(module == Class16.smethod_0(1648906367)))
		{
			if (!(module == Class16.smethod_0(1648906421)))
			{
				if (!(module == Class16.smethod_0(1648942729)))
				{
					if (!(module == Class16.smethod_0(1648906400)))
					{
						return null;
					}
					AceMcpNpcGenDocument aceMcpNpcGenDocument = aceMcpNpcGenDocument_0;
					if (aceMcpNpcGenDocument == null)
					{
						obj = null;
					}
					else
					{
						obj = aceMcpNpcGenDocument.FileName;
						if (obj != null)
						{
							goto IL_0080;
						}
					}
					obj = CommonStorage.Params?.NPCGenPath;
					goto IL_0080;
				}
				AIFile aIPolicy = DataFiles.AIPolicy;
				if (aIPolicy == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = aIPolicy.FilePath;
					if (obj2 != null)
					{
						goto IL_00a9;
					}
				}
				obj2 = CommonStorage.Params?.AIPolicyPath;
				goto IL_00a9;
			}
			TASKS tasks = DataFiles.Tasks;
			if (tasks == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = tasks.FileName;
				if (obj3 != null)
				{
					goto IL_00d2;
				}
			}
			obj3 = CommonStorage.Params?.TasksPath;
			goto IL_00d2;
		}
		eListCollection elements = DataFiles.Elements;
		object obj4;
		if (elements == null)
		{
			obj4 = null;
		}
		else
		{
			obj4 = elements.FileName;
			if (obj4 != null)
			{
				goto IL_00fb;
			}
		}
		obj4 = CommonStorage.Params?.ElementsPath;
		goto IL_00fb;
		IL_0080:
		return (string)obj;
		IL_00fb:
		return (string)obj4;
		IL_00a9:
		return (string)obj2;
		IL_00d2:
		return (string)obj3;
	}

	internal static eListCollection RequireElements()
	{
		eListCollection elements = DataFiles.Elements;
		if (elements == null || !elements.FileLoaded)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649126899));
		}
		return elements;
	}

	internal static TASKS RequireTasks()
	{
		TASKS tasks = DataFiles.Tasks;
		if (tasks == null || !tasks.FileLoaded)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649125912));
		}
		return tasks;
	}

	internal static AIFile RequireAIPolicy()
	{
		AIFile aIPolicy = DataFiles.AIPolicy;
		if (aIPolicy == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649125946));
		}
		return aIPolicy;
	}

	internal static AceMcpNpcGenDocument RequireNpcGenDocument()
	{
		if (aceMcpNpcGenDocument_0?.Data == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649125991));
		}
		return aceMcpNpcGenDocument_0;
	}

	internal static AceMcpNpcGenDocument LoadNpcGenDocument(string path)
	{
		AceMcpNpcGenDocument aceMcpNpcGenDocument = new AceMcpNpcGenDocument
		{
			FileName = path,
			TimeChange = File.GetLastWriteTime(path),
			Data = new ACE.NpcGen.Classes.NpcGen()
		};
		using (FileStream input = File.OpenRead(path))
		{
			BinaryReader binaryReader = new BinaryReader(input);
			try
			{
				aceMcpNpcGenDocument.Data.ReadNpcgen(binaryReader);
			}
			finally
			{
				((IDisposable)binaryReader).Dispose();
			}
		}
		SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
		aceMcpNpcGenDocument.FileChanged = false;
		aceMcpNpcGenDocument_0 = aceMcpNpcGenDocument;
		return aceMcpNpcGenDocument;
	}

	internal static void SaveNpcGenDocument(AceMcpNpcGenDocument document, string path)
	{
		SyncNpcGenCounts(document.Data);
		using (FileStream output = File.Create(path))
		{
			BinaryWriter binaryWriter = new BinaryWriter(output);
			try
			{
				document.Data.WriteNpcgen(binaryWriter, document.Data.File_version);
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		document.TimeChange = File.GetLastWriteTime(path);
		document.FileChanged = false;
	}

	internal static void MarkNpcGenChanged()
	{
		if (aceMcpNpcGenDocument_0 != null)
		{
			aceMcpNpcGenDocument_0.FileChanged = true;
		}
	}

	internal static JToken ResolveScriptToken(JToken token, IDictionary<string, object> variables)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		if (token == null)
		{
			return (JToken)(object)JValue.CreateNull();
		}
		JTokenType type = token.Type;
		if ((int)type != 1)
		{
			if ((int)type != 2)
			{
				if ((int)type != 8)
				{
					return token.DeepClone();
				}
				string string_ = Extensions.Value<string>((IEnumerable<JToken>)token);
				return smethod_0(string_, variables);
			}
			JArray val = new JArray();
			{
				foreach (JToken item in (JArray)token)
				{
					val.Add(ResolveScriptToken(item, variables));
				}
				return (JToken)(object)val;
			}
		}
		JObject val2 = new JObject();
		foreach (JProperty item2 in ((JObject)token).Properties())
		{
			val2[item2.Name] = ResolveScriptToken(item2.Value, variables);
		}
		return (JToken)(object)val2;
	}

	private static JToken smethod_0(string string_0, IDictionary<string, object> idictionary_0)
	{
		Class221 @class = new Class221();
		@class.idictionary_0 = idictionary_0;
		if (string.IsNullOrEmpty(string_0))
		{
			return (string_0);
		}
		if (string_0.StartsWith(Class16.smethod_0(1648908627), StringComparison.Ordinal))
		{
			object obj = EvaluateExpression(string_0.Substring(1), @class.idictionary_0, null, null, null);
			if (obj != null)
			{
				return JToken.FromObject(obj);
			}
			return (JToken)(object)JValue.CreateNull();
		}
		string text = Regex.Replace(string_0, Class16.smethod_0(1649126018), @class.method_0);
		return (text);
	}

	private static void smethod_1()
	{
		lock (object_0)
		{
			if (!bool_0)
			{
				dictionary_0[Class16.smethod_0(1648906367)] = new Class222();
				dictionary_0[Class16.smethod_0(1648906421)] = new Class192();
				dictionary_0[Class16.smethod_0(1648942729)] = new Class173();
				dictionary_0[Class16.smethod_0(1648906400)] = new Class202();
				bool_0 = true;
			}
		}
	}

	private static object smethod_2(string string_0, JObject jobject_0)
	{
		string text = (string_0 ?? string.Empty).Trim().ToLowerInvariant();
		if (text != null)
		{
			switch (text.Length)
			{
			case 11:
				switch (text[0])
				{
				case 's':
					if (text == Class16.smethod_0(1649126131))
					{
						return iaceMcpFileService_0.SaveModule(GetString(jobject_0, Class16.smethod_0(1649126233)), GetString(jobject_0, Class16.smethod_0(1648906425)), saveAs: false);
					}
					break;
				case 'l':
					if (text == Class16.smethod_0(1649126113))
					{
						return iaceMcpFileService_0.LoadModule(GetString(jobject_0, Class16.smethod_0(1649126233)), GetString(jobject_0, Class16.smethod_0(1648906425)));
					}
					break;
				}
				break;
			case 13:
				switch (text[0])
				{
				case 'r':
					if (text == Class16.smethod_0(1649126157))
					{
						return iaceMcpFileService_0.ReloadModule(GetString(jobject_0, Class16.smethod_0(1649126233)));
					}
					break;
				case 'b':
					if (text == Class16.smethod_0(1649126169))
					{
						return iaceMcpFileService_0.BackupModule(GetString(jobject_0, Class16.smethod_0(1649126233)), GetString(jobject_0, Class16.smethod_0(1648906425)));
					}
					break;
				}
				break;
			case 14:
				if (text == Class16.smethod_0(1649126197))
				{
					return iaceMcpFileService_0.SaveModule(GetString(jobject_0, Class16.smethod_0(1649126233)), GetString(jobject_0, Class16.smethod_0(1648906425)), saveAs: true);
				}
				break;
			case 16:
				if (text == Class16.smethod_0(1649126210))
				{
					return smethod_3(GetString(jobject_0, Class16.smethod_0(1649126265)));
				}
				break;
			case 18:
				switch (text[0])
				{
				case 'd':
					if (text == Class16.smethod_0(1649126088))
					{
						return smethod_4(GetString(jobject_0, Class16.smethod_0(1649126265)));
					}
					break;
				case 'e':
					if (text == Class16.smethod_0(1649126071))
					{
						return iaceMcpFileService_0.ExportModuleJson(GetString(jobject_0, Class16.smethod_0(1649126233)), GetString(jobject_0, Class16.smethod_0(1648906425)), ((JToken)jobject_0).Value<bool?>((object)Class16.smethod_0(1649126254)) == true);
					}
					break;
				case 'g':
					if (text == Class16.smethod_0(1649126046))
					{
						return iaceMcpFileService_0.GetLoadedModules();
					}
					break;
				}
				break;
			}
		}
		throw new InvalidOperationException(Class16.smethod_0(1649126293) + string_0 + Class16.smethod_0(1648928156));
	}

	private static object smethod_3(string string_0)
	{
		AceMcpChangeSet aceMcpChangeSet = iaceMcpChangeSetStore_0.Get(string_0);
		if (aceMcpChangeSet == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649126327) + string_0 + Class16.smethod_0(1649126338));
		}
		foreach (KeyValuePair<string, string> sourceFingerprint in aceMcpChangeSet.SourceFingerprints)
		{
			string domainFingerprint = GetDomainFingerprint(sourceFingerprint.Key);
			if (!string.Equals(domainFingerprint, sourceFingerprint.Value, StringComparison.Ordinal))
			{
				return new
				{
					ok = false,
					change_set_id = string_0,
					applied = false,
					reason = Class16.smethod_0(1649126361),
					domain = sourceFingerprint.Key,
					expected = sourceFingerprint.Value,
					current = domainFingerprint
				};
			}
		}
		foreach (IAceMcpChangeOperation operation in aceMcpChangeSet.Operations)
		{
			operation.Apply();
		}
		iaceMcpChangeSetStore_0.Remove(string_0);
		return new
		{
			ok = true,
			change_set_id = string_0,
			applied = true,
			operation_count = aceMcpChangeSet.Operations.Count
		};
	}

	private static object smethod_4(string string_0)
	{
		return new
		{
			ok = iaceMcpChangeSetStore_0.Remove(string_0),
			change_set_id = string_0,
			discarded = true
		};
	}

	private static string smethod_5()
	{
		eListCollection elements = DataFiles.Elements;
		if (elements != null && elements.FileLoaded && elements.Lists != null)
		{
			long num = 0L;
			for (int i = 0; i < elements.ListCount; i++)
			{
				eList eList2 = elements.Lists[i];
				if (eList2 != null && eList2.ItemCount > 0)
				{
					num += eList2.ItemCount;
					num += eList2.getid(0);
					num += eList2.getid(eList2.ItemCount - 1);
				}
			}
			return string.Format(CultureInfo.InvariantCulture, Class16.smethod_0(1649125379), elements.FileName ?? string.Empty, elements.ListCount, elements.ItemCount, elements.FileChanged ? 1 : 0, num);
		}
		return Class16.smethod_0(1649126396);
	}

	private static string smethod_6()
	{
		TASKS tasks = DataFiles.Tasks;
		if (tasks != null && tasks.FileLoaded && tasks.QuestsArray != null)
		{
			long num = 0L;
			ATaskTempl[] questsArray = tasks.QuestsArray;
			foreach (ATaskTempl aTaskTempl in questsArray)
			{
				num += aTaskTempl.ID;
				num += aTaskTempl.m_nSubCount;
			}
			return string.Format(CultureInfo.InvariantCulture, Class16.smethod_0(1648899703), tasks.FileName ?? string.Empty, tasks.QuestsArray.Length, tasks.FileChanged ? 1 : 0, num);
		}
		return Class16.smethod_0(1649126396);
	}

	private static string smethod_7()
	{
		AIFile aIPolicy = DataFiles.AIPolicy;
		if (aIPolicy != null && aIPolicy.Controllers != null)
		{
			long num = 0L;
			foreach (CPolicyData controller in aIPolicy.Controllers)
			{
				num += controller.ID;
				num += controller.Version;
				num += controller.Triggers?.Count ?? 0;
			}
			return string.Format(CultureInfo.InvariantCulture, Class16.smethod_0(1648899703), aIPolicy.FilePath ?? string.Empty, aIPolicy.Header, aIPolicy.Controllers.Count, num);
		}
		return Class16.smethod_0(1649126396);
	}

	private static string smethod_8()
	{
		AceMcpNpcGenDocument aceMcpNpcGenDocument = aceMcpNpcGenDocument_0;
		if (aceMcpNpcGenDocument?.Data == null)
		{
			return Class16.smethod_0(1649126396);
		}
		SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
		long num = 0L;
		foreach (ClassDefaultMonsters npcMob in aceMcpNpcGenDocument.Data.NpcMobList)
		{
			num += npcMob.dwGenId;
			num += npcMob.Amount_in_group;
		}
		foreach (ClassDefaultResources resources in aceMcpNpcGenDocument.Data.ResourcesList)
		{
			num += resources.dwGenID;
			num += resources.Amount_in_group;
		}
		foreach (ClassDynamicObject dynamics in aceMcpNpcGenDocument.Data.DynamicsList)
		{
			num += dynamics.Id;
			num += dynamics.TriggerId;
		}
		foreach (ClassTrigger triggers in aceMcpNpcGenDocument.Data.TriggersList)
		{
			num += triggers.Id;
			num += triggers.GmID;
		}
		return string.Format(CultureInfo.InvariantCulture, Class16.smethod_0(1649125413), aceMcpNpcGenDocument.FileName ?? string.Empty, aceMcpNpcGenDocument.Data.NpcMobsAmount, aceMcpNpcGenDocument.Data.ResourcesAmount, aceMcpNpcGenDocument.Data.DynobjectAmount, aceMcpNpcGenDocument.Data.TriggersAmount, num);
	}

	internal static object ExportElements(bool includeData)
	{
		Class190 CS_0024_003C_003E8__locals12 = new Class190();
		CS_0024_003C_003E8__locals12.eListCollection_0 = RequireElements();
		if (!includeData)
		{
			return new
			{
				module = Class16.smethod_0(1648906367),
				path = CS_0024_003C_003E8__locals12.eListCollection_0.FileName,
				game = CS_0024_003C_003E8__locals12.eListCollection_0.Game.ToString(),
				version = CS_0024_003C_003E8__locals12.eListCollection_0.Version,
				lists = (from eList_0 in Enumerable.Range(0, CS_0024_003C_003E8__locals12.eListCollection_0.ListCount).Select(CS_0024_003C_003E8__locals12.method_0).Where(Class234.class234_0.method_0)
					select _003C_003Ef__AnonymousType21.Create(
						eList_0.ListIndex,
						eList_0.uListName,
						eList_0.ItemCount,
						eList_0.FieldCount
					)).ToArray()
			};
		}
		return new
		{
			module = Class16.smethod_0(1648906367),
			path = CS_0024_003C_003E8__locals12.eListCollection_0.FileName,
			lists = Enumerable.Range(0, CS_0024_003C_003E8__locals12.eListCollection_0.ListCount).Select(CS_0024_003C_003E8__locals12.method_1).Where(Class234.class234_0.method_2)
				.Select(delegate(eList eList_0)
				{
					Class172 CS_0024_003C_003E8__locals20 = new Class172();
					CS_0024_003C_003E8__locals20.class190_0 = CS_0024_003C_003E8__locals12;
					CS_0024_003C_003E8__locals20.eList_0 = eList_0;
					return _003C_003Ef__AnonymousType23.Create(
						CS_0024_003C_003E8__locals20.eList_0.ListIndex,
						CS_0024_003C_003E8__locals20.eList_0.uListName,
						CS_0024_003C_003E8__locals20.eList_0.elementFields,
						Enumerable.Range(0, CS_0024_003C_003E8__locals20.eList_0.ItemCount).Select(delegate(int int_0)
						{
							Class191 @class = new Class191();
							@class.class172_0 = CS_0024_003C_003E8__locals20;
							@class.int_0 = int_0;
							return new
							{
								index = @class.int_0,
								id = CS_0024_003C_003E8__locals20.eList_0.getid(@class.int_0),
								values = CS_0024_003C_003E8__locals20.eList_0.elementFields.Select(@class.method_0).ToArray()
							};
						}).ToArray()
					);
				})
				.ToArray()
		};
	}

	internal static object ExportTasks(bool includeData)
	{
		TASKS tASKS = RequireTasks();
		object tasks = (includeData ? ((object)tASKS.QuestsArray) : ((object)tASKS.QuestsArray?.Select((ATaskTempl ataskTempl_0) => _003C_003Ef__AnonymousType25.Create(
			ataskTempl_0.ID,
			ataskTempl_0.Name,
			ataskTempl_0.m_nSubCount
		)).ToArray()));
		string module = Class16.smethod_0(1648906421);
		string fileName = tASKS.FileName;
		int version = tASKS.version;
		ATaskTempl[] questsArray = tASKS.QuestsArray;
		return new
		{
			module = module,
			path = fileName,
			version = version,
			count = ((questsArray != null) ? questsArray.Length : 0),
			tasks = tasks
		};
	}

	internal static object ExportAipolicy(bool includeData)
	{
		AIFile aIFile = RequireAIPolicy();
		object controllers = (includeData ? ((object)aIFile.Controllers) : ((object)aIFile.Controllers?.Select((CPolicyData cpolicyData_0) => _003C_003Ef__AnonymousType27.Create(
			cpolicyData_0.ID,
			cpolicyData_0.Version,
			(cpolicyData_0.Triggers?.Count ?? 0)
		)).ToArray()));
		return new
		{
			module = Class16.smethod_0(1648942729),
			path = aIFile.FilePath,
			header = aIFile.Header,
			controllers = controllers
		};
	}

	internal static object ExportNpcGen(bool includeData)
	{
		AceMcpNpcGenDocument aceMcpNpcGenDocument = RequireNpcGenDocument();
		SyncNpcGenCounts(aceMcpNpcGenDocument.Data);
		return new
		{
			module = Class16.smethod_0(1648906400),
			path = aceMcpNpcGenDocument.FileName,
			version = aceMcpNpcGenDocument.Data.File_version,
			npc_mobs_amount = aceMcpNpcGenDocument.Data.NpcMobsAmount,
			resources_amount = aceMcpNpcGenDocument.Data.ResourcesAmount,
			dynobject_amount = aceMcpNpcGenDocument.Data.DynobjectAmount,
			triggers_amount = aceMcpNpcGenDocument.Data.TriggersAmount,
			data = ((!includeData) ? null : new
			{
				existence = aceMcpNpcGenDocument.Data.NpcMobList,
				resources = aceMcpNpcGenDocument.Data.ResourcesList,
				dynamic_objects = aceMcpNpcGenDocument.Data.DynamicsList,
				triggers = aceMcpNpcGenDocument.Data.TriggersList
			})
		};
	}

	internal static string GetString(JObject source, string propertyName)
	{
		if (source == null)
		{
			return null;
		}
		return ((JToken)source).Value<string>((object)propertyName);
	}

	internal static JObject GetJsonObjectParameter(JObject source, string propertyName)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		JToken val = ((source != null) ? source[propertyName] : null);
		if (val != null && (int)val.Type != 10)
		{
			JObject val2 = (JObject)(object)((val is JObject) ? val : null);
			if (val2 != null)
			{
				return (JObject)((JToken)val2).DeepClone();
			}
			if ((int)val.Type == 8)
			{
				string text = Extensions.Value<string>((IEnumerable<JToken>)val);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return JObject.Parse(text);
				}
				return new JObject();
			}
			throw new InvalidOperationException(Class16.smethod_0(1649125435) + propertyName + Class16.smethod_0(1649125461));
		}
		return new JObject();
	}

	internal static JArray GetJsonArrayParameter(JObject source, string propertyName)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		JToken val = ((source != null) ? source[propertyName] : null);
		if (val != null && (int)val.Type != 10)
		{
			JArray val2 = (JArray)(object)((val is JArray) ? val : null);
			if (val2 != null)
			{
				return (JArray)((JToken)val2).DeepClone();
			}
			if ((int)val.Type == 8)
			{
				string text = Extensions.Value<string>((IEnumerable<JToken>)val);
				if (!string.IsNullOrWhiteSpace(text))
				{
					return JArray.Parse(text);
				}
				return new JArray();
			}
			throw new InvalidOperationException(Class16.smethod_0(1649125435) + propertyName + Class16.smethod_0(1649125499));
		}
		return new JArray();
	}

	internal static string ConvertToInvariantString(object value)
	{
		if (value == null)
		{
			return string.Empty;
		}
		if (!(value is string result))
		{
			if (value is bool)
			{
				if (!(bool)value)
				{
					return Class16.smethod_0(1648924112);
				}
				return Class16.smethod_0(1648934925);
			}
			if (!(value is IFormattable formattable))
			{
				return value.ToString();
			}
			return formattable.ToString(null, CultureInfo.InvariantCulture);
		}
		return result;
	}

	internal static object ConvertJTokenToClrValue(JToken token, Type targetType)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Invalid comparison between Unknown and I4
		if (targetType == null)
		{
			if (token == null)
			{
				return null;
			}
			return token.ToObject<object>();
		}
		if (token != null && (int)token.Type != 10)
		{
			Type type = Nullable.GetUnderlyingType(targetType) ?? targetType;
			if (type.IsEnum)
			{
				if ((int)token.Type == 8)
				{
					return Enum.Parse(type, Extensions.Value<string>((IEnumerable<JToken>)token), ignoreCase: true);
				}
				return Enum.ToObject(type, token.ToObject(typeof(int)));
			}
			if (type == typeof(string))
			{
				return Extensions.Value<string>((IEnumerable<JToken>)token);
			}
			if (type == typeof(bool))
			{
				return ((int)token.Type == 8) ? ParseBoolean(Extensions.Value<string>((IEnumerable<JToken>)token)) : token.ToObject<bool>();
			}
			if (!(type == typeof(byte)) && !(type == typeof(sbyte)))
			{
				if (!(type == typeof(short)) && !(type == typeof(ushort)) && !(type == typeof(int)) && !(type == typeof(uint)) && !(type == typeof(long)) && !(type == typeof(ulong)) && !(type == typeof(float)) && !(type == typeof(double)) && !(type == typeof(decimal)))
				{
					return token.ToObject(type);
				}
				return Convert.ChangeType(token.ToObject<object>(), type, CultureInfo.InvariantCulture);
			}
			return Convert.ChangeType(token.ToObject<int>(), type, CultureInfo.InvariantCulture);
		}
		if (targetType.IsValueType && Nullable.GetUnderlyingType(targetType) == null)
		{
			return Activator.CreateInstance(targetType);
		}
		return null;
	}

	internal static bool ParseBoolean(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		value = value.Trim();
		if (!(value == Class16.smethod_0(1648934925)) && !value.Equals(Class16.smethod_0(1648901259), StringComparison.OrdinalIgnoreCase))
		{
			return value.Equals(Class16.smethod_0(1648898323), StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	internal static bool TryGetListByName(eListCollection elements, string name, out int listIndex)
	{
		listIndex = -1;
		if (elements?.Lists != null && !string.IsNullOrWhiteSpace(name))
		{
			int num = 0;
			while (true)
			{
				if (num < elements.ListCount)
				{
					eList eList2 = elements.Lists[num];
					if (eList2 != null && (string.Equals(eList2.uListName, name, StringComparison.OrdinalIgnoreCase) || string.Equals(eList2.ListName, name, StringComparison.OrdinalIgnoreCase)))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			listIndex = num;
			return true;
		}
		return false;
	}

	internal static int ResolveElementsListIndex(eListCollection elements, JObject parameters)
	{
		int? num = ((JToken)parameters).Value<int?>((object)Class16.smethod_0(1649124680));
		if (num.HasValue && num.Value >= 0)
		{
			return num.Value;
		}
		string name = GetString(parameters, Class16.smethod_0(1649124703));
		if (!TryGetListByName(elements, name, out var listIndex))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649125544));
		}
		return listIndex;
	}

	internal static Dictionary<string, JToken> ParseFieldMap(JObject parameters, string propertyName = "fields_json")
	{
		JObject jsonObjectParameter = GetJsonObjectParameter(parameters, propertyName);
		return jsonObjectParameter.Properties().ToDictionary(Class234.class234_0.method_5, Class234.class234_0.method_6, StringComparer.OrdinalIgnoreCase);
	}

	internal static List<int> ParseIntList(JObject parameters, string propertyName)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Invalid comparison between Unknown and I4
		JToken val = ((parameters != null) ? parameters[propertyName] : null);
		if (val != null && (int)val.Type != 10)
		{
			JArray val2 = (JArray)(object)((val is JArray) ? val : null);
			if (val2 != null)
			{
				return ((JContainer)val2).Values<int>().ToList();
			}
			if ((int)val.Type == 8)
			{
				string text = Extensions.Value<string>((IEnumerable<JToken>)val);
				if (string.IsNullOrWhiteSpace(text))
				{
					return new List<int>();
				}
				if (text.TrimStart().StartsWith(Class16.smethod_0(1648924364), StringComparison.Ordinal))
				{
					return ((JContainer)JArray.Parse(text)).Values<int>().ToList();
				}
				return text.Split(new char[2] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).Select(Class234.class234_0.method_7).ToList();
			}
			return new List<int> { Extensions.Value<int>((IEnumerable<JToken>)val) };
		}
		return new List<int>();
	}

	internal static int? FindTaskIdInReplacementMap(IDictionary<int, int> replacementMap, int currentId)
	{
		if (replacementMap != null && replacementMap.TryGetValue(currentId, out var value))
		{
			return value;
		}
		return null;
	}

	internal static object EvaluateExpression(string expression, IDictionary<string, object> variables, IDictionary<string, object> fields, int? currentId, string currentName)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		Class220 @class = new Class220();
		@class.idictionary_0 = fields;
		@class.idictionary_1 = variables;
		@class.nullable_0 = currentId;
		@class.string_0 = currentName;
		Expression val = new Expression(expression, (EvaluateOptions)2);
		val.EvaluateParameter += new EvaluateParameterHandler(@class.method_0);
		val.EvaluateFunction += new EvaluateFunctionHandler(@class.method_1);
		return val.Evaluate();
	}

	internal static Dictionary<string, object> ReadElementsFieldContext(eListCollection elements, int listIndex, int itemIndex)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
		eList eList2 = elements.Lists[listIndex];
		for (int i = 0; i < eList2.FieldCount; i++)
		{
			string key = eList2.elementFields[i];
			string value = elements.GetValue(listIndex, itemIndex, i);
			dictionary[key] = ParseScalarValue(value);
		}
		return dictionary;
	}

	internal static object ParseScalarValue(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return string.Empty;
		}
		if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result;
		}
		if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out var result2))
		{
			return result2;
		}
		if (bool.TryParse(value, out var result3))
		{
			return result3;
		}
		return value;
	}

	internal static string[] ResolveElementsFieldNames(eListCollection elements, int listIndex, JObject parameters)
	{
		JArray jsonArrayParameter = GetJsonArrayParameter(parameters, Class16.smethod_0(1649125607));
		if (((JContainer)jsonArrayParameter).Count > 0)
		{
			return ((JContainer)jsonArrayParameter).Values<string>().ToArray();
		}
		return elements.Lists[listIndex].elementFields.ToArray();
	}

	internal static int FindElementsItemIndexById(eListCollection elements, int listIndex, int itemId)
	{
		int num = -1;
		eList eList2 = elements.Lists[listIndex];
		if (eList2?.IDsFast != null && eList2.IDsFast.TryGetValue(itemId, out var value))
		{
			num = value;
		}
		if (num < 0)
		{
			num = elements.FindItemIndexByID(listIndex, itemId);
		}
		return num;
	}

	internal static void SyncNpcGenCounts(ACE.NpcGen.Classes.NpcGen data)
	{
		if (data == null)
		{
			return;
		}
		data.NpcMobsAmount = data.NpcMobList?.Count ?? 0;
		data.ResourcesAmount = data.ResourcesList?.Count ?? 0;
		data.DynobjectAmount = data.DynamicsList?.Count ?? 0;
		data.TriggersAmount = data.TriggersList?.Count ?? 0;
		if (data.NpcMobList != null)
		{
			foreach (ClassDefaultMonsters npcMob in data.NpcMobList)
			{
				npcMob.Amount_in_group = npcMob.MobDops?.Count ?? 0;
			}
		}
		if (data.ResourcesList == null)
		{
			return;
		}
		foreach (ClassDefaultResources resources in data.ResourcesList)
		{
			resources.Amount_in_group = resources.ResExtra?.Count ?? 0;
		}
	}

	internal static object GetMemberValue(object target, string path)
	{
		smethod_10(target, path, out var object_, out var memberInfo_, out var nullable_);
		if (nullable_.HasValue)
		{
			IList list = (IList)smethod_9(object_, memberInfo_);
			return list[nullable_.Value];
		}
		return smethod_9(object_, memberInfo_);
	}

	internal static void SetMemberValue(object target, string path, JToken value)
	{
		smethod_10(target, path, out var object_, out var memberInfo_, out var nullable_);
		if (nullable_.HasValue)
		{
			IList list = (IList)smethod_9(object_, memberInfo_);
			Type targetType = typeof(object);
			if (memberInfo_ is PropertyInfo propertyInfo && propertyInfo.PropertyType.IsArray)
			{
				targetType = propertyInfo.PropertyType.GetElementType();
			}
			else if (memberInfo_ is PropertyInfo propertyInfo2 && propertyInfo2.PropertyType.IsGenericType)
			{
				targetType = propertyInfo2.PropertyType.GetGenericArguments()[0];
			}
			else if (memberInfo_ is FieldInfo fieldInfo && fieldInfo.FieldType.IsArray)
			{
				targetType = fieldInfo.FieldType.GetElementType();
			}
			else if (memberInfo_ is FieldInfo fieldInfo2 && fieldInfo2.FieldType.IsGenericType)
			{
				targetType = fieldInfo2.FieldType.GetGenericArguments()[0];
			}
			list[nullable_.Value] = ConvertJTokenToClrValue(value, targetType);
			return;
		}
		Type type = ((memberInfo_ is PropertyInfo propertyInfo3) ? propertyInfo3.PropertyType : ((memberInfo_ is FieldInfo fieldInfo3) ? fieldInfo3.FieldType : typeof(object)));
		Type targetType2 = type;
		object value2 = ConvertJTokenToClrValue(value, targetType2);
		if (!(memberInfo_ is PropertyInfo propertyInfo4))
		{
			if (memberInfo_ is FieldInfo fieldInfo4)
			{
				fieldInfo4.SetValue(object_, value2);
			}
		}
		else
		{
			propertyInfo4.SetValue(object_, value2);
		}
	}

	private static object smethod_9(object object_1, MemberInfo memberInfo_0)
	{
		if (!(memberInfo_0 is PropertyInfo propertyInfo))
		{
			if (!(memberInfo_0 is FieldInfo fieldInfo))
			{
				return null;
			}
			return fieldInfo.GetValue(object_1);
		}
		return propertyInfo.GetValue(object_1);
	}

	private static void smethod_10(object object_1, string string_0, out object object_2, out MemberInfo memberInfo_0, out int? nullable_0)
	{
		if (object_1 == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1649125617));
		}
		if (string.IsNullOrWhiteSpace(string_0))
		{
			throw new ArgumentException(Class16.smethod_0(1649125636), Class16.smethod_0(1649125660));
		}
		string[] array = string_0.Split('.');
		object obj = object_1;
		int num = 0;
		int? nullable_1;
		while (true)
		{
			if (num < array.Length)
			{
				smethod_12(array[num], out var string_1, out nullable_1);
				memberInfo_0 = smethod_11(obj.GetType(), string_1);
				if (!(memberInfo_0 == null))
				{
					if (num == array.Length - 1)
					{
						break;
					}
					object obj2 = smethod_9(obj, memberInfo_0);
					if (nullable_1.HasValue)
					{
						if (!(obj2 is IList list))
						{
							throw new InvalidOperationException(Class16.smethod_0(1649125671) + string_1 + Class16.smethod_0(1649125705));
						}
						obj2 = list[nullable_1.Value];
					}
					obj = obj2 ?? throw new InvalidOperationException(Class16.smethod_0(1649125671) + string_1 + Class16.smethod_0(1649125742));
					num++;
					continue;
				}
				throw new InvalidOperationException(Class16.smethod_0(1649125671) + string_1 + Class16.smethod_0(1649125686) + obj.GetType().FullName + Class16.smethod_0(1648928156));
			}
			throw new InvalidOperationException(Class16.smethod_0(1649125760) + string_0 + Class16.smethod_0(1648928156));
		}
		object_2 = obj;
		nullable_0 = nullable_1;
	}

	private static MemberInfo smethod_11(Type type_0, string string_0)
	{
		BindingFlags bindingAttr = BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		PropertyInfo property = type_0.GetProperty(string_0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (property != null)
		{
			return property;
		}
		return type_0.GetField(string_0, bindingAttr);
	}

	private static void smethod_12(string string_0, out string string_1, out int? nullable_0)
	{
		int num = string_0.IndexOf('[');
		if (num < 0)
		{
			string_1 = string_0;
			nullable_0 = null;
			return;
		}
		int num2 = string_0.IndexOf(']', num + 1);
		if (num2 < 0)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649125789) + string_0 + Class16.smethod_0(1648928156));
		}
		string_1 = string_0.Substring(0, num);
		nullable_0 = int.Parse(string_0.Substring(num + 1, num2 - num - 1), CultureInfo.InvariantCulture);
	}

	private static bool smethod_13(eListCollection eListCollection_0, REFERENCE_TYPE_EX reference_TYPE_EX_0, ref REFERENCE_ENTRY reference_ENTRY_0, int int_0, string string_0, string string_1)
	{
		switch (reference_TYPE_EX_0.DataFileType)
		{
		case DATA_FILES_ENUM.ELEMENTS:
			if (int_0 > -1)
			{
				eListCollection_0.SetValue(reference_ENTRY_0.FieldPos, int_0.ToString(CultureInfo.InvariantCulture));
			}
			if (string_0 != null)
			{
				eListCollection_0.SetValue(reference_ENTRY_0.FieldPos, string_0);
			}
			return true;
		default:
			return false;
		case DATA_FILES_ENUM.TASKS:
			return DataFiles.Tasks?.ChangeValueFromReference(reference_TYPE_EX_0, ref reference_ENTRY_0, int_0, string_0, string_1, bRemove: false) ?? false;
		case DATA_FILES_ENUM.NPCGEN:
		{
			NPCGEN_LIST npcGenList = eListCollection_0.NpcGenList;
			if (npcGenList == null)
			{
				return false;
			}
			return npcGenList.GetNpcGenByInstanceID(reference_TYPE_EX_0.param1, reference_TYPE_EX_0.param2)?.ChangeValueFromReference(reference_TYPE_EX_0, ref reference_ENTRY_0, int_0, string_0, string_1) ?? false;
		}
		case DATA_FILES_ENUM.EXTRA_DROPS:
		{
			FieldInfo field = typeof(ACE.MainWindow.MainWindow).GetField(Class16.smethod_0(1649071707), BindingFlags.Instance | BindingFlags.NonPublic);
			object obj = Application.OpenForms.Cast<Form>().FirstOrDefault(Class234.class234_0.method_8);
			object obj2 = field?.GetValue(obj);
			MethodInfo methodInfo = obj2?.GetType().GetMethod(Class16.smethod_0(1649125810), BindingFlags.Instance | BindingFlags.Public);
			if (methodInfo == null)
			{
				return false;
			}
			object[] array = new object[5] { reference_TYPE_EX_0, reference_ENTRY_0, int_0, string_0, string_1 };
			bool result = (bool)methodInfo.Invoke(obj2, array);
			if (array[1] is REFERENCE_ENTRY rEFERENCE_ENTRY)
			{
				reference_ENTRY_0 = rEFERENCE_ENTRY;
			}
			return result;
		}
		}
	}
}
