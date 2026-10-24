using System;
using System.Collections.Generic;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ACE.Mcp;

public static class McpRequestHandler
{
	public static string HandleRequest(string json)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			JObject val = JObject.Parse(json);
			if (val[Class16.smethod_0(1649014943)] == null && val[Class16.smethod_0(1649126614)] == null && val[Class16.smethod_0(1649121266)] == null)
			{
				string string_ = ((JToken)val).Value<string>((object)Class16.smethod_0(1649120265));
				JObject jobject_ = (JObject)(((object)((JToken)val).Value<JObject>((object)Class16.smethod_0(1649126677))) ?? ((object)new JObject()));
				object result = smethod_0(string_, jobject_);
				return JsonConvert.SerializeObject((object)new { result });
			}
			object result2 = AceMcpRuntime.DispatchV2(val);
			return JsonConvert.SerializeObject((object)new
			{
				result = result2
			});
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649120286));
			return JsonConvert.SerializeObject((object)new
			{
				error = new
				{
					code = -1,
					message = ex.Message
				}
			});
		}
	}

	private static object smethod_0(string string_0, JObject jobject_0)
	{
		eListCollection elements = DataFiles.Elements;
		if (elements == null && string_0 != Class16.smethod_0(1649120324))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649120341));
		}
		if (string_0 != null)
		{
			switch (string_0.Length)
			{
			case 37:
				if (string_0 == Class16.smethod_0(1649120693))
				{
					return smethod_18(elements, jobject_0);
				}
				break;
			case 10:
				if (string_0 == Class16.smethod_0(1649120324))
				{
					return smethod_1();
				}
				break;
			case 13:
				if (string_0 == Class16.smethod_0(1649120417))
				{
					return smethod_4(elements);
				}
				break;
			case 14:
				if (string_0 == Class16.smethod_0(1649120504))
				{
					return smethod_22(elements, jobject_0);
				}
				break;
			case 15:
				switch (string_0[9])
				{
				case 'g':
					if (string_0 == Class16.smethod_0(1649120482))
					{
						return smethod_9(elements);
					}
					break;
				case 'b':
					if (string_0 == Class16.smethod_0(1649120468))
					{
						return smethod_8(elements, jobject_0);
					}
					break;
				}
				break;
			case 16:
				if (string_0 == Class16.smethod_0(1649120445))
				{
					return smethod_7(elements, jobject_0);
				}
				break;
			case 17:
				if (string_0 == Class16.smethod_0(1649120533))
				{
					return smethod_12(elements, jobject_0);
				}
				break;
			case 18:
				if (string_0 == Class16.smethod_0(1649120601))
				{
					return smethod_14(elements, jobject_0);
				}
				break;
			case 19:
				switch (string_0[4])
				{
				case 'i':
					if (string_0 == Class16.smethod_0(1649120557))
					{
						return smethod_13(elements, jobject_0);
					}
					break;
				case 'f':
					if (string_0 == Class16.smethod_0(1649120583))
					{
						return smethod_16(elements, jobject_0);
					}
					break;
				}
				break;
			case 20:
				switch (string_0[0])
				{
				case 's':
					if (string_0 == Class16.smethod_0(1649120398))
					{
						return smethod_19(elements, jobject_0);
					}
					break;
				case 'g':
					if (string_0 == Class16.smethod_0(1649120363))
					{
						return smethod_3(elements);
					}
					break;
				}
				break;
			case 22:
				if (string_0 == Class16.smethod_0(1649120626))
				{
					return smethod_15(elements, jobject_0);
				}
				break;
			case 23:
				if (string_0 == Class16.smethod_0(1649120663))
				{
					return smethod_17(elements, jobject_0);
				}
				break;
			case 24:
				if (string_0 == Class16.smethod_0(1649120763))
				{
					return smethod_21(elements, jobject_0);
				}
				break;
			case 27:
				if (string_0 == Class16.smethod_0(1649120729))
				{
					return smethod_20(elements, jobject_0);
				}
				break;
			}
		}
		throw new ArgumentException(Class16.smethod_0(1649119770) + string_0);
	}

	private static object smethod_1()
	{
		eListCollection elements = DataFiles.Elements;
		return new
		{
			running = true,
			elements_loaded = (elements != null),
			list_count = (elements?.ListCount ?? 0),
			total_items = (elements?.ItemCount ?? 0)
		};
	}

	private static ITEMPOS smethod_2(eListCollection eListCollection_0, int int_0, int int_1)
	{
		if (eListCollection_0 == null)
		{
			return null;
		}
		if (int_1 >= 0)
		{
			if (int_1 >= eListCollection_0.ListCount)
			{
				return null;
			}
			int num = eListCollection_0.FindItemIndexByID(int_1, int_0);
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

	private static object smethod_3(eListCollection eListCollection_0)
	{
		return new
		{
			file_name = eListCollection_0.FileName,
			game = eListCollection_0.Game.ToString(),
			game_prefix = eListCollection_0.GamePrefix,
			version = (int)eListCollection_0.Version,
			config_version = eListCollection_0.ConfigVersion,
			list_count = eListCollection_0.ListCount,
			total_items = eListCollection_0.ItemCount,
			timestamp = eListCollection_0.TimeStamp,
			file_loaded = eListCollection_0.FileLoaded
		};
	}

	private static object smethod_4(eListCollection eListCollection_0)
	{
		List<object> list = new List<object>(eListCollection_0.ListCount);
		for (int i = 0; i < eListCollection_0.ListCount; i++)
		{
			eList eList2 = eListCollection_0.Lists[i];
			if (eList2 != null)
			{
				list.Add(new
				{
					index = i,
					name = eList2.ListName,
					universal_name = eList2.uListName,
					item_count = eList2.ItemCount,
					field_count = eList2.FieldCount
				});
			}
		}
		return new
		{
			lists = list
		};
	}

	private static object smethod_5(eList eList_0)
	{
		return new
		{
			index = eList_0.ListIndex,
			name = eList_0.ListName,
			universal_name = eList_0.uListName,
			item_count = eList_0.ItemCount,
			field_count = eList_0.FieldCount,
			fields = smethod_6(eList_0)
		};
	}

	private static object[] smethod_6(eList eList_0)
	{
		object[] array = new object[eList_0.FieldCount];
		for (int i = 0; i < eList_0.FieldCount; i++)
		{
			array[i] = new
			{
				index = i,
				name = eList_0.elementFields[i],
				type = eList_0.elementTypes[i],
				data_type = eList_0.FieldDataTypes[i].data_type.ToString(),
				size = eList_0.FieldDataTypes[i].size
			};
		}
		return array;
	}

	private static object smethod_7(eListCollection eListCollection_0, JObject jobject_0)
	{
		string text = ((JToken)jobject_0).Value<string>((object)Class16.smethod_0(1648905100));
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new ArgumentException(Class16.smethod_0(1649125069));
		}
		eList eList2 = eListCollection_0[text];
		if (eList2 == null)
		{
			for (int i = 0; i < eListCollection_0.ListCount; i++)
			{
				eList eList3 = eListCollection_0.Lists[i];
				if (eList3 != null && (string.Equals(eList3.ListName, text, StringComparison.OrdinalIgnoreCase) || string.Equals(eList3.uListName, text, StringComparison.OrdinalIgnoreCase)))
				{
					eList2 = eList3;
					break;
				}
			}
		}
		if (eList2 == null)
		{
			throw new ArgumentException(Class16.smethod_0(1649119793) + text);
		}
		return smethod_5(eList2);
	}

	private static object smethod_8(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1648899902));
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			return smethod_5(eList2);
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_9(eListCollection eListCollection_0)
	{
		return new
		{
			matters_lists = smethod_10(eListCollection_0, eListCollection_0.MattersLists),
			equipment_lists = smethod_10(eListCollection_0, eListCollection_0.EquipmentLists),
			npc_mob_mine_lists = smethod_10(eListCollection_0, eListCollection_0.NpcMobMineLists),
			all_lists = eListCollection_0.AllLists
		};
	}

	private static object[] smethod_10(eListCollection eListCollection_0, int[] int_0)
	{
		if (int_0 == null)
		{
			return Array.Empty<object>();
		}
		object[] array = new object[int_0.Length];
		for (int i = 0; i < int_0.Length; i++)
		{
			int num = int_0[i];
			eList eList2 = ((eListCollection_0.Lists == null || num < 0 || num >= eListCollection_0.Lists.Length) ? null : eListCollection_0.Lists[num]);
			array[i] = new
			{
				index = num,
				name = eList2?.ListName,
				universal_name = eList2?.uListName
			};
		}
		return array;
	}

	private static object smethod_11(ITEMINFO iteminfo_0, ITEMPOS itempos_0)
	{
		return new
		{
			id = iteminfo_0.id,
			name = iteminfo_0.name,
			list_index = itempos_0.int_0,
			item_index = itempos_0.int_1,
			item_type = iteminfo_0.item_type.ToString(),
			icon_name = iteminfo_0.IconName,
			ref_count = iteminfo_0.RefCount,
			has_references = iteminfo_0.bHasReferences,
			sub_items_count = iteminfo_0.SubItemsCount,
			category_name = iteminfo_0.CatName
		};
	}

	private static object smethod_12(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649124680));
		int num2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649119883)).GetValueOrDefault();
		int num3 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124676)) ?? 100;
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			int num4 = Math.Min(num3, eList2.ItemCount - num2);
			if (num4 <= 0)
			{
				return new
				{
					items = Array.Empty<object>(),
					total = eList2.ItemCount
				};
			}
			object[] array = new object[num4];
			for (int i = 0; i < num4; i++)
			{
				int num5 = num2 + i;
				int id = eList2.getid(num5);
				string name = ((eList2.NamesCache == null || num5 >= eList2.NamesCache.Length) ? null : eList2.NamesCache[num5]);
				array[i] = new
				{
					index = num5,
					id = id,
					name = name
				};
			}
			return new
			{
				items = array,
				total = eList2.ItemCount
			};
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_13(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649124680));
		int num2 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649078545));
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			int num3 = -1;
			num3 = ((eList2.IDsFast == null || !eList2.IDsFast.TryGetValue(num2, out var value)) ? eListCollection_0.FindItemIndexByID(num, num2) : value);
			if (num3 < 0)
			{
				return new
				{
					found = false,
					list_index = num,
					list_name = eList2.uListName,
					item_id = num2,
					field_count = eList2.FieldCount,
					fields = new Dictionary<string, object>()
				};
			}
			Dictionary<string, object> dictionary = new Dictionary<string, object>(eList2.FieldCount);
			for (int i = 0; i < eList2.FieldCount; i++)
			{
				string key = eList2.elementFields[i];
				string value2 = eListCollection_0.GetValue(num, num3, i);
				dictionary[key] = value2;
			}
			string item_name = ((eList2.NamesCache == null || num3 >= eList2.NamesCache.Length) ? null : eList2.NamesCache[num3]);
			return new
			{
				found = true,
				list_index = num,
				list_name = eList2.uListName,
				item_index = num3,
				item_id = num2,
				item_name = item_name,
				field_count = eList2.FieldCount,
				fields = dictionary
			};
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_14(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649124680));
		JArray val = ((JToken)jobject_0).Value<JArray>((object)Class16.smethod_0(1649124719));
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			List<object> list = new List<object>();
			foreach (JToken item in val)
			{
				int num2 = Extensions.Value<int>((IEnumerable<JToken>)item);
				int num3 = -1;
				if (eList2.IDsFast != null && eList2.IDsFast.TryGetValue(num2, out var value))
				{
					num3 = value;
				}
				if (num3 < 0)
				{
					list.Add(new
					{
						id = num2,
						found = false
					});
					continue;
				}
				string text = ((eList2.NamesCache == null || num3 >= eList2.NamesCache.Length) ? null : eList2.NamesCache[num3]);
				ITEMPOS itemPos = new ITEMPOS(num, num3);
				ITEMINFO itemInfo = eListCollection_0.GetItemInfo(itemPos);
				object obj;
				if (itemInfo == null)
				{
					obj = null;
				}
				else
				{
					obj = itemInfo.name;
					if (obj != null)
					{
						goto IL_0101;
					}
				}
				obj = text;
				goto IL_0101;
				IL_0101:
				list.Add(new
				{
					id = num2,
					found = true,
					name = (string)obj,
					item_index = num3,
					item_type = itemInfo?.item_type.ToString(),
					category_name = itemInfo?.CatName
				});
			}
			return new
			{
				items = list
			};
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_15(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649124680));
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			return new
			{
				list_index = num,
				list_name = eList2.uListName,
				field_count = eList2.FieldCount,
				fields = smethod_6(eList2)
			};
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_16(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649124680));
		int num2 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649123963));
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			if (num2 < 0 || num2 >= eList2.FieldCount)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119896), num2));
			}
			return new
			{
				list_index = num,
				field_index = num2,
				name = eList2.elementFields[num2],
				type = eList2.elementTypes[num2],
				data_type = eList2.FieldDataTypes[num2].data_type.ToString(),
				size = eList2.FieldDataTypes[num2].size
			};
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_17(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649124680));
		int num2 = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649119940));
		string text = ((JToken)jobject_0).Value<string>((object)Class16.smethod_0(1649124633));
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			if (num2 >= 0 && num2 < eList2.ItemCount)
			{
				if (string.IsNullOrWhiteSpace(text))
				{
					throw new ArgumentException(Class16.smethod_0(1649119990));
				}
				string value = eListCollection_0.GetValue(num, num2, text);
				return new
				{
					list_idx = num,
					item_idx = num2,
					field_name = text,
					value = value
				};
			}
			throw new ArgumentException(string.Format(Class16.smethod_0(1649119947), num2));
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_18(eListCollection eListCollection_0, JObject jobject_0)
	{
		string text = ((JToken)jobject_0).Value<string>((object)Class16.smethod_0(1649124633));
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649078545));
		int num2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124680)) ?? (-1);
		ITEMPOS iTEMPOS = smethod_2(eListCollection_0, num, num2);
		if (iTEMPOS == null)
		{
			return new
			{
				found = false,
				list_idx = num2,
				item_id = num,
				field_name = text,
				value = (string)null
			};
		}
		string value = eListCollection_0.GetValue(iTEMPOS.int_0, iTEMPOS.int_1, text);
		return new
		{
			found = true,
			list_idx = iTEMPOS.int_0,
			list_name = eListCollection_0.Lists[iTEMPOS.int_0]?.uListName,
			item_idx = iTEMPOS.int_1,
			item_id = num,
			field_name = text,
			value = value
		};
	}

	private static object smethod_19(eListCollection eListCollection_0, JObject jobject_0)
	{
		string text = ((JToken)jobject_0).Value<string>((object)Class16.smethod_0(1649124629));
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new ArgumentException(Class16.smethod_0(1649120024));
		}
		string text2 = text.ToLowerInvariant();
		int num = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124680)) ?? (-1);
		int num2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124676)) ?? 50;
		if (num >= eListCollection_0.ListCount)
		{
			throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		List<object> list = new List<object>();
		int num3 = ((num >= 0) ? num : 0);
		int num4 = ((num >= 0) ? (num + 1) : eListCollection_0.ListCount);
		for (int i = num3; i < num4; i++)
		{
			if (list.Count >= num2)
			{
				break;
			}
			eList eList2 = eListCollection_0.Lists[i];
			if (eList2 == null || eList2.NamesCache == null)
			{
				continue;
			}
			for (int j = 0; j < eList2.ItemCount; j++)
			{
				if (list.Count >= num2)
				{
					break;
				}
				string text3 = ((j < eList2.NamesCache.Length) ? eList2.NamesCache[j] : null);
				if (text3 != null && text3.ToLowerInvariant().Contains(text2))
				{
					list.Add(new
					{
						list_index = i,
						list_name = eList2.uListName,
						item_index = j,
						id = eList2.getid(j),
						name = text3
					});
				}
			}
		}
		return new
		{
			query = text2,
			count = list.Count,
			items = list
		};
	}

	private static object smethod_20(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649124680));
		string text = ((JToken)jobject_0).Value<string>((object)Class16.smethod_0(1649124633));
		string text2 = ((JToken)jobject_0).Value<string>((object)Class16.smethod_0(1648905186));
		int num2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124676)) ?? 50;
		if (num >= 0 && num < eListCollection_0.ListCount)
		{
			eList eList2 = eListCollection_0.Lists[num];
			if (eList2 == null)
			{
				throw new ArgumentException(string.Format(Class16.smethod_0(1649119851), num));
			}
			int num3 = eList2.get_fields(text);
			if (num3 < 0)
			{
				throw new ArgumentException(Class16.smethod_0(1649120069) + text);
			}
			List<object> list = new List<object>();
			for (int i = 0; i < eList2.ItemCount; i++)
			{
				if (list.Count >= num2)
				{
					break;
				}
				string value = eListCollection_0.GetValue(num, i, num3);
				if (value == text2)
				{
					string name = ((eList2.NamesCache == null || i >= eList2.NamesCache.Length) ? null : eList2.NamesCache[i]);
					list.Add(new
					{
						item_index = i,
						id = eList2.getid(i),
						name = name,
						value = value
					});
				}
			}
			return new
			{
				list_idx = num,
				field_name = text,
				target_value = text2,
				count = list.Count,
				items = list
			};
		}
		throw new ArgumentException(string.Format(Class16.smethod_0(1649119816), num));
	}

	private static object smethod_21(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1649078545));
		int int_ = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124680)) ?? (-1);
		ELEMENTS_REFERENCES references = eListCollection_0.References;
		if (references == null)
		{
			return new
			{
				item_id = num,
				has_references = false,
				references = Array.Empty<object>()
			};
		}
		ITEMPOS iTEMPOS = smethod_2(eListCollection_0, num, int_);
		if (iTEMPOS == null)
		{
			return new
			{
				found = false,
				item_id = num,
				has_references = false,
				total_count = 0,
				references = Array.Empty<object>()
			};
		}
		ITEMINFO itemInfo = eListCollection_0.GetItemInfo(iTEMPOS);
		List<ELEMENTS_REFERENCES_SUITE> references2 = references.GetReferences(iTEMPOS.int_0, itemInfo.item_type, num);
		if (references2 != null && references2.Count != 0)
		{
			List<object> list = new List<object>();
			int num2 = 0;
			foreach (ELEMENTS_REFERENCES_SUITE item in references2)
			{
				num2 += item.Count;
				List<object> list2 = new List<object>();
				if (item.refs != null)
				{
					foreach (REFERENCE_ENTRY @ref in item.refs)
					{
						list2.Add(new
						{
							id = @ref.id,
							name = @ref.Name,
							value1 = @ref.CleanValue1,
							value2 = @ref.CleanValue2
						});
					}
				}
				list.Add(new
				{
					type = item.RefType.ToString(),
					count = item.Count,
					entries = list2
				});
			}
			return new
			{
				found = true,
				item_id = num,
				has_references = true,
				total_count = num2,
				references = list
			};
		}
		return new
		{
			item_id = num,
			has_references = false,
			total_count = 0,
			references = Array.Empty<object>()
		};
	}

	private static object smethod_22(eListCollection eListCollection_0, JObject jobject_0)
	{
		int num = ((JToken)jobject_0).Value<int>((object)Class16.smethod_0(1648932143));
		int num2 = ((JToken)jobject_0).Value<int?>((object)Class16.smethod_0(1649124680)) ?? (-1);
		ITEMPOS iTEMPOS = smethod_2(eListCollection_0, num, num2);
		if (iTEMPOS == null)
		{
			return new
			{
				found = false,
				id = num,
				list_idx = num2
			};
		}
		ITEMINFO itemInfo = eListCollection_0.GetItemInfo(iTEMPOS);
		return new
		{
			found = true,
			data = smethod_11(itemInfo, iTEMPOS)
		};
	}
}
