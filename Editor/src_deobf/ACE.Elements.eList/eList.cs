using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes;
using ACE.MppcLibrary;
using ACE.Protectors;
using ACE.RSGlobal;
using ACE.Settings;

namespace ACE.Elements.eList;

public class eList
{
	public sealed class FieldIndexer
	{
		private readonly eList eList_0;

		private readonly bool bool_0;

		public FieldIndexer(eList owner, bool useUnderscoreArrays)
		{
			eList_0 = owner;
			bool_0 = useUnderscoreArrays;
		}

		public int get(string name)
		{
			if (string.Equals(name, Class16.smethod_0(1648941057), StringComparison.OrdinalIgnoreCase))
			{
				return 0;
			}
			string[] array = (bool_0 ? eList_0._elementFields : eList_0.elementFields);
			if (array != null)
			{
				return Array.IndexOf(array, name);
			}
			return -1;
		}
	}

	public static Encoding GBK = Encoding.GetEncoding(Class16.smethod_0(1648985403));

	private int int_0;

	private string string_0;

	private readonly FieldIndexer fieldIndexer_0;

	private readonly FieldIndexer fieldIndexer_1;

	public static CommonStorage CStorage;

	public static ELEMENTS_CRYPTER ElementsCrypter;

	public GAMES Game;

	public FIELDS_TRANSLATER TranslationGlobal;

	public FIELDS_TRANSLATER FieldsTranslation;

	public int ListIndex;

	public ItemType ListType;

	public int _list_type;

	public int _idSpace;

	public int item_size;

	public ID_SPACE SpaceId = ID_SPACE.invalid;

	public bool bMatters;

	public bool bItemsOrderingChanged;

	public bool bListStructChanged;

	public string[] NamesCache;

	public bool IdsMakingNow;

	public List<int> IDs;

	private HashSet<int> hashSet_0;

	private Dictionary<int, int> dictionary_0;

	public FIELD_TYPES_DB FieldTypesDB;

	public List<FIELD_SET> FieldSets;

	public List<string> HintFields;

	public Dictionary<int, FIELD_LIMITS> FieldLimits;

	public EL_COMPUTER_DATA NPC_TALK;

	public object[] SourceItemStruct;

	public string sAutoOffset;

	public string ListName;

	public string uListName;

	public long listOffset;

	public byte[] listOffsetData;

	public string[] elementFields;

	public string[] elementTypes;

	public object[][] elementValues;

	public FIELD_DATA_TYPE[] FieldDataTypes;

	public string[] _elementFields;

	public string[] _elementTypes;

	public long d_ListOffset;

	public byte[][] d_elementBytes;

	public long[] d_elementOffsets;

	public int NameFieldIndex;

	public int TypeFieldIndex;

	public int SubTypeFieldIndex;

	public int ColorFieldIndex;

	public int IconFieldIndex;

	public int ModelFieldIndex;

	public bool IsTgaIcon;

	public FIELDTYPE[] fieldtypes;

	public Dictionary<int, int> fieldtypes_extra;

	public Dictionary<int, int[]> FieldsBindedLists;

	public Dictionary<int, List<int>> References;

	public static List<byte> saveValidator;

	public static object i0 = 0;

	public static object f0 = 0f;

	public pw_mppc mppc_unmanaged = new pw_mppc_unmanaged();

	public pw_mppc mppc_managed = new pw_mppc_managed();

	public int LastFieldIndex => (int)((nint)elementTypes.LongLength - 1);

	public int FieldCount => elementTypes.Length;

	public int ItemCount
	{
		get
		{
			object[][] array = elementValues;
			return (int)((array != null) ? array.LongLength : 0L);
		}
	}

	public string FriendlyFields
	{
		get
		{
			string result = null;
			if (int_0 < elementTypes.Length)
			{
				result = NamesConverter.GetFieldFriendlyName(elementFields[int_0]);
			}
			GC.KeepAlive(this);
			return result;
		}
	}

	public string Name
	{
		get
		{
			if (ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES)
			{
				return uListName;
			}
			if (!string.IsNullOrEmpty(ListName) && !(ListName == uListName))
			{
				return ListName;
			}
			return ACE.RSGlobal.RSGlobal.GetListFriendlyName(uListName);
		}
	}

	public FIELD_DATA_TYPE_ENUM dtype
	{
		get
		{
			if (!(string_0 == Class16.smethod_0(1648941057)) && !(string_0 == Class16.smethod_0(1648932143)))
			{
				int num = Array.IndexOf(elementFields, string_0);
				if (num > -1)
				{
					GC.KeepAlive(this);
					return FieldDataTypes[num].data_type;
				}
				return FIELD_DATA_TYPE_ENUM.Unknown;
			}
			GC.KeepAlive(this);
			return FIELD_DATA_TYPE_ENUM.Int;
		}
	}

	public FieldIndexer _fields => fieldIndexer_1;

	public FieldIndexer fields => fieldIndexer_0;

	public string this[string field_name, string type]
	{
		get
		{
			string result = null;
			string[] array = elementFields;
			if (array != null)
			{
				int num = Array.IndexOf(array, field_name);
				if (num > -1)
				{
					if (type == Class16.smethod_0(1648893461))
					{
						result = elementTypes[num];
					}
					else if (type == Class16.smethod_0(1648905100))
					{
						result = elementFields[num];
					}
				}
			}
			return result;
		}
		set
		{
			string[] array = elementFields;
			if (array == null)
			{
				return;
			}
			int num = Array.IndexOf(array, field_name);
			if (num > -1)
			{
				if (type == Class16.smethod_0(1648893461))
				{
					elementTypes[num] = value;
				}
				else if (type == Class16.smethod_0(1648905100))
				{
					elementFields[num] = value;
				}
			}
		}
	}

	public object this[int int_1, string field_name]
	{
		get
		{
			object result = null;
			if (elementValues != null)
			{
				int num = Array.IndexOf(elementFields, field_name);
				if (num > -1)
				{
					result = elementValues[int_1][num];
				}
			}
			return result;
		}
		set
		{
			string[] array = elementFields;
			if (array != null)
			{
				int num = Array.IndexOf(array, field_name);
				if (num > -1)
				{
					elementValues[int_1][num] = value;
				}
			}
		}
	}

	public int this[string field_name] => this.get_fields(field_name);

	public Dictionary<int, int> IDsFast
	{
		get
		{
			if (dictionary_0 == null)
			{
				UpdateFastIDs();
			}
			return dictionary_0;
		}
	}

	public HashSet<int> IDsHashSet
	{
		get
		{
			if (hashSet_0 == null)
			{
				UpdateIDsHashSet();
			}
			return hashSet_0;
		}
	}

	// TODO(recovered): ILSpy rendered the field-name->index lookup method get_fields(string)
	// as a malformed parameterless property duplicating the `fields` member. Restored as the
	// method its call sites (this[string], get_fields(...)) expect.
	public int get_fields(string name) => this.fields.get(name);

	public eList()
	{
		fieldIndexer_0 = new FieldIndexer(this, useUnderscoreArrays: false);
		fieldIndexer_1 = new FieldIndexer(this, useUnderscoreArrays: true);
		NameFieldIndex = -1;
		TypeFieldIndex = -1;
		SubTypeFieldIndex = -1;
		IconFieldIndex = -1;
		ColorFieldIndex = -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFieldExist(string field)
	{
		return this.get_fields(field) > -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Exists(string field)
	{
		return this.get_fields(field) > -1;
	}

	public void AddFieldSets(string line, [MarshalAs(UnmanagedType.U1)] bool bNotInterrelated)
	{
		if (FieldSets == null)
		{
			FieldSets = new List<FIELD_SET>();
		}
		string[] array = line.Split(';');
		int num = 0;
		int nameID = 854;
		if (ACE.RSGlobal.RSGlobal.IsUIntFast(array[0]))
		{
			nameID = ACE.RSGlobal.RSGlobal.UIntParseFast(array[0]);
			num = 1;
		}
		FIELD_SET fIELD_SET = new FIELD_SET(nameID, array.Length - num);
		int num2 = num;
		if (num < array.Length)
		{
			do
			{
				char[] separator = new char[1] { '=' };
				string[] array2 = array[num2].Split(separator);
				int num3 = this.get_fields(array2[0]);
				if (num3 > 0)
				{
					fIELD_SET.Fields.Add(num3, ACE.RSGlobal.RSGlobal.UIntParseFast(array2[1]));
				}
				num2++;
			}
			while (num2 < array.Length);
		}
		if (fIELD_SET.Fields.Count > 0)
		{
			FieldSets.Add(fIELD_SET);
		}
		GC.KeepAlive(this);
	}

	public static string GetFieldName(ref FIELDS_TRANSLATER GlobalTranslation, ref FIELDS_TRANSLATER FieldsTranslation, ref string[] elementFields, int int_1, ref bool bTranslationExist)
	{
		string text = null;
		string text2 = elementFields[int_1];
		if (ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES)
		{
			return text2;
		}
		if (GlobalTranslation != null)
		{
			text = null;
			FIELDS_TRANSLATER fIELDS_TRANSLATER = FieldsTranslation;
			if (fIELDS_TRANSLATER == null)
			{
				goto IL_0038;
			}
			if (!fIELDS_TRANSLATER.TryGetTranslation(text2, ref text))
			{
				FIELDS_TRANSLATER fIELDS_TRANSLATER2 = FieldsTranslation;
				if (fIELDS_TRANSLATER2 == null || !fIELDS_TRANSLATER2.TryGetTranslationRegEx(text2, ref text))
				{
					goto IL_0038;
				}
			}
			goto IL_0057;
		}
		text2 = NamesConverter.GetFieldFriendlyName(text2);
		goto IL_0094;
		IL_0094:
		return text2;
		IL_0038:
		if (!GlobalTranslation.TryGetTranslation(text2, ref text) && !GlobalTranslation.TryGetTranslationRegEx(text2, ref text))
		{
			text2 = NamesConverter.GetFieldFriendlyName(text2);
		}
		goto IL_0057;
		IL_0057:
		if (text != null)
		{
			text2 = text;
			if (CommonStorage.AParams.ShowOriginalFieldsToo)
			{
				text2 = text + Class16.smethod_0(1648961184) + elementFields[int_1] + Class16.smethod_0(1649008474);
			}
			bTranslationExist = true;
		}
		goto IL_0094;
	}

	public string GetFieldName(int int_1, ref bool bTranslationExist)
	{
		string fieldName = GetFieldName(ref TranslationGlobal, ref FieldsTranslation, ref elementFields, int_1, ref bTranslationExist);
		GC.KeepAlive(this);
		return fieldName;
	}

	public string GetFieldName(int int_1)
	{
		bool bTranslationExist = false;
		return GetFieldName(int_1, ref bTranslationExist);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFieldTranslationExist(int int_1)
	{
		bool bTranslationExist = false;
		GetFieldName(int_1, ref bTranslationExist);
		return bTranslationExist;
	}

	private bool method_0(int int_1, int int_2)
	{
		if (elementValues != null && elementTypes != null && FieldDataTypes != null && int_1 >= 0 && int_1 < elementValues.Length && int_2 >= 0 && int_2 < elementTypes.Length && int_2 < FieldDataTypes.Length && elementValues[int_1] != null)
		{
			return int_2 < elementValues[int_1].Length;
		}
		return false;
	}

	private static byte[] smethod_0(object object_0)
	{
		return (object_0 as byte[]) ?? Array.Empty<byte>();
	}

	public static string GetValue(object obj_val, string type, [MarshalAs(UnmanagedType.U1)] bool roundTrip)
	{
		if (obj_val != null && !string.IsNullOrEmpty(type))
		{
			if (obj_val is byte[] array)
			{
				if (type[0] == 'w')
				{
					string text = Encoding.Unicode.GetString(smethod_0(obj_val));
					int num = text.IndexOf('\0');
					if (num < 0)
					{
						return text;
					}
					return text.Substring(0, num);
				}
				if (type[0] == 's')
				{
					string text2 = GBK.GetString(smethod_0(obj_val));
					int num2 = text2.IndexOf('\0');
					if (num2 < 0)
					{
						return text2;
					}
					return text2.Substring(0, num2);
				}
				if (type[0] == 'b')
				{
					return BitConverter.ToString(smethod_0(obj_val));
				}
				if (type == Class16.smethod_0(1648989776) && array.Length >= 4)
				{
					return BitConverter.ToInt32(array, 0).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989786) && array.Length >= 4)
				{
					return BitConverter.ToUInt32(array, 0).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989805) && array.Length >= 2)
				{
					return BitConverter.ToInt16(array, 0).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989809) && array.Length >= 2)
				{
					return BitConverter.ToUInt16(array, 0).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989830) && array.Length >= 8)
				{
					return BitConverter.ToInt64(array, 0).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989834) && array.Length >= 8)
				{
					return BitConverter.ToUInt64(array, 0).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648902744) && array.Length >= 4)
				{
					float num3 = BitConverter.ToSingle(array, 0);
					if (!roundTrip)
					{
						return num3.ToString(Class16.smethod_0(1648961193), CultureInfo.InvariantCulture);
					}
					return num3.ToString(Class16.smethod_0(1648983526), CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989855) && array.Length >= 8)
				{
					double num4 = BitConverter.ToDouble(array, 0);
					if (!roundTrip)
					{
						return num4.ToString(Class16.smethod_0(1648961202), CultureInfo.InvariantCulture);
					}
					return num4.ToString(Class16.smethod_0(1648983535), CultureInfo.InvariantCulture);
				}
				return string.Empty;
			}
			if (obj_val is string value && string.IsNullOrWhiteSpace(value))
			{
				return string.Empty;
			}
			if (!(obj_val is IConvertible))
			{
				return string.Empty;
			}
			try
			{
				if (type == Class16.smethod_0(1648989776))
				{
					return Convert.ToInt32(obj_val, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989786))
				{
					return Convert.ToUInt32(obj_val, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989830))
				{
					return Convert.ToInt64(obj_val, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989834))
				{
					return Convert.ToUInt64(obj_val, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648902744))
				{
					float num5 = Convert.ToSingle(obj_val, CultureInfo.InvariantCulture);
					if (roundTrip)
					{
						float num6 = num5;
						return num6.ToString(Class16.smethod_0(1648983526), CultureInfo.InvariantCulture);
					}
					float num7 = num5;
					return num7.ToString(Class16.smethod_0(1648961193), CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989855))
				{
					double num8 = Convert.ToDouble(obj_val, CultureInfo.InvariantCulture);
					if (roundTrip)
					{
						double num9 = num8;
						return num9.ToString(Class16.smethod_0(1648983535), CultureInfo.InvariantCulture);
					}
					double num10 = num8;
					return num10.ToString(Class16.smethod_0(1648961202), CultureInfo.InvariantCulture);
				}
				if (type[0] == 'w')
				{
					string text3 = Encoding.Unicode.GetString(smethod_0(obj_val));
					int num11 = text3.IndexOf('\0');
					return (num11 >= 0) ? text3.Substring(0, num11) : text3;
				}
				if (type[0] == 's')
				{
					string text4 = GBK.GetString(smethod_0(obj_val));
					int num12 = text4.IndexOf('\0');
					return (num12 >= 0) ? text4.Substring(0, num12) : text4;
				}
				if (type[0] == 'b')
				{
					return BitConverter.ToString(smethod_0(obj_val));
				}
				if (type == Class16.smethod_0(1648989805))
				{
					return Convert.ToInt16(obj_val, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
				}
				if (type == Class16.smethod_0(1648989809))
				{
					return Convert.ToUInt16(obj_val, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture);
				}
			}
			catch (Exception ex) when (((ex is InvalidCastException || ex is FormatException || ex is OverflowException) ? 1 : 0) != 0)
			{
				return string.Empty;
			}
			return string.Empty;
		}
		return string.Empty;
	}

	public double GetValueDouble(int int_1, int int_2)
	{
		if (!method_0(int_1, int_2))
		{
			return 0.0;
		}
		ref object reference = ref elementValues[int_1][int_2];
		if (reference is byte[] array)
		{
			return FieldDataTypes[int_2].data_type switch
			{
				FIELD_DATA_TYPE_ENUM.Int => (array.Length >= 4) ? ((double)BitConverter.ToInt32(array, 0)) : 0.0, 
				FIELD_DATA_TYPE_ENUM.Int16 => (array.Length >= 2) ? ((double)BitConverter.ToInt16(array, 0)) : 0.0, 
				FIELD_DATA_TYPE_ENUM.UInt => (array.Length >= 4) ? ((double)BitConverter.ToUInt32(array, 0)) : 0.0, 
				FIELD_DATA_TYPE_ENUM.Int64 => (array.Length >= 8) ? ((double)BitConverter.ToInt64(array, 0)) : 0.0, 
				FIELD_DATA_TYPE_ENUM.UInt64 => (array.Length >= 8) ? ((double)BitConverter.ToUInt64(array, 0)) : 0.0, 
				FIELD_DATA_TYPE_ENUM.Float => (array.Length >= 4) ? ((double)BitConverter.ToSingle(array, 0)) : 0.0, 
				FIELD_DATA_TYPE_ENUM.Double => (array.Length >= 8) ? BitConverter.ToDouble(array, 0) : 0.0, 
				_ => 0.0, 
			};
		}
		double result = 0.0;
		try
		{
			switch (FieldDataTypes[int_2].data_type)
			{
			case FIELD_DATA_TYPE_ENUM.Int:
				result = (int)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Int16:
				result = (short)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.UInt:
				result = (uint)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Int64:
				result = (long)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.UInt64:
				result = (ulong)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Float:
				result = (float)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Double:
				result = (double)reference;
				break;
			}
		}
		catch (InvalidCastException)
		{
		}
		return result;
	}

	public float GetValueFloat(int int_1, int int_2)
	{
		if (!method_0(int_1, int_2))
		{
			return 0f;
		}
		ref object reference = ref elementValues[int_1][int_2];
		if (reference is byte[] array)
		{
			return FieldDataTypes[int_2].data_type switch
			{
				FIELD_DATA_TYPE_ENUM.Int => (array.Length >= 4) ? ((float)BitConverter.ToInt32(array, 0)) : 0f, 
				FIELD_DATA_TYPE_ENUM.Int16 => (array.Length >= 2) ? ((float)BitConverter.ToInt16(array, 0)) : 0f, 
				FIELD_DATA_TYPE_ENUM.UInt => (array.Length >= 4) ? ((float)BitConverter.ToUInt32(array, 0)) : 0f, 
				FIELD_DATA_TYPE_ENUM.Int64 => (array.Length >= 8) ? ((float)BitConverter.ToInt64(array, 0)) : 0f, 
				FIELD_DATA_TYPE_ENUM.UInt64 => (array.Length >= 8) ? ((float)BitConverter.ToUInt64(array, 0)) : 0f, 
				FIELD_DATA_TYPE_ENUM.Float => (array.Length >= 4) ? BitConverter.ToSingle(array, 0) : 0f, 
				FIELD_DATA_TYPE_ENUM.Double => (array.Length >= 8) ? ((float)BitConverter.ToDouble(array, 0)) : 0f, 
				_ => 0f, 
			};
		}
		float result = 0f;
		try
		{
			switch (FieldDataTypes[int_2].data_type)
			{
			case FIELD_DATA_TYPE_ENUM.Int:
				result = (int)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Int16:
				result = (short)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.UInt:
				result = (uint)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Int64:
				result = (long)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.UInt64:
				result = (ulong)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Float:
				result = (float)reference;
				break;
			case FIELD_DATA_TYPE_ENUM.Double:
				result = (float)(double)reference;
				break;
			}
		}
		catch (InvalidCastException)
		{
		}
		return result;
	}

	public string GetValue(int ElementIndex, int FieldIndex, [MarshalAs(UnmanagedType.U1)] bool roundTrip)
	{
		if (!method_0(ElementIndex, FieldIndex))
		{
			return string.Empty;
		}
		string value = GetValue(elementValues[ElementIndex][FieldIndex], elementTypes[FieldIndex], roundTrip);
		GC.KeepAlive(this);
		return value;
	}

	public string GetValue(int ElementIndex, int FieldIndex)
	{
		if (!method_0(ElementIndex, FieldIndex))
		{
			return string.Empty;
		}
		string value = GetValue(elementValues[ElementIndex][FieldIndex], elementTypes[FieldIndex], roundTrip: false);
		GC.KeepAlive(this);
		return value;
	}

	public float GetValueF(int ElementIndex, int FieldIndex)
	{
		return GetValueFloat(ElementIndex, FieldIndex);
	}

	public decimal GetValueDecimal(int int_1, int int_2)
	{
		if (!method_0(int_1, int_2))
		{
			return 0m;
		}
		decimal result = default(decimal);
		ref object reference = ref elementValues[int_1][int_2];
		if (reference is byte[] array)
		{
			return FieldDataTypes[int_2].data_type switch
			{
				FIELD_DATA_TYPE_ENUM.Int => (array.Length >= 4) ? ((decimal)BitConverter.ToInt32(array, 0)) : 0m, 
				FIELD_DATA_TYPE_ENUM.Int16 => (array.Length >= 2) ? ((decimal)BitConverter.ToInt16(array, 0)) : 0m, 
				FIELD_DATA_TYPE_ENUM.UInt => (array.Length >= 4) ? ((decimal)BitConverter.ToUInt32(array, 0)) : 0m, 
				FIELD_DATA_TYPE_ENUM.Int64 => (array.Length >= 8) ? ((decimal)BitConverter.ToInt64(array, 0)) : 0m, 
				FIELD_DATA_TYPE_ENUM.UInt64 => (array.Length >= 8) ? ((decimal)BitConverter.ToUInt64(array, 0)) : 0m, 
				FIELD_DATA_TYPE_ENUM.Float => (array.Length >= 4) ? ACE.RSGlobal.RSGlobal.ToDecimalSafe(BitConverter.ToSingle(array, 0)) : 0m, 
				FIELD_DATA_TYPE_ENUM.Double => (array.Length >= 8) ? ACE.RSGlobal.RSGlobal.ToDecimalSafe(BitConverter.ToDouble(array, 0)) : 0m, 
				_ => 0m, 
			};
		}
		try
		{
			result = FieldDataTypes[int_2].data_type switch
			{
				FIELD_DATA_TYPE_ENUM.Int => (int)reference, 
				FIELD_DATA_TYPE_ENUM.Int16 => (short)reference, 
				FIELD_DATA_TYPE_ENUM.UInt => (uint)reference, 
				FIELD_DATA_TYPE_ENUM.Int64 => (long)reference, 
				FIELD_DATA_TYPE_ENUM.UInt64 => (ulong)reference, 
				FIELD_DATA_TYPE_ENUM.Float => ACE.RSGlobal.RSGlobal.ToDecimalSafe((float)reference), 
				FIELD_DATA_TYPE_ENUM.Double => ACE.RSGlobal.RSGlobal.ToDecimalSafe((double)reference), 
				_ => default(decimal), 
			};
		}
		catch (InvalidCastException)
		{
		}
		GC.KeepAlive(this);
		return result;
	}

	public double GetValueD(int ElementIndex, int FieldIndex)
	{
		return GetValueDouble(ElementIndex, FieldIndex);
	}

	public void CheckFieldLimits(int int_1, ref double value)
	{
		Dictionary<int, FIELD_LIMITS> fieldLimits = FieldLimits;
		if (fieldLimits != null && fieldLimits.ContainsKey(int_1))
		{
			FIELD_LIMITS fIELD_LIMITS = FieldLimits[int_1];
			long minimum = fIELD_LIMITS.minimum;
			double num = minimum;
			long maximum = fIELD_LIMITS.maximum;
			double num2 = maximum;
			double num3 = value;
			if (num3 < num || num3 > num2)
			{
				object[] array = new object[3];
				bool bTranslationExist = false;
				string fieldName = GetFieldName(int_1, ref bTranslationExist);
				array[0] = fieldName;
				array[1] = minimum;
				array[2] = maximum;
				CStorage.Alert(945, array);
				num3 = value;
				if (num3 < num)
				{
					value = num;
				}
				else if (num3 < num2)
				{
					value = num2;
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void CheckFieldLimits(int int_1, ref int value)
	{
		Dictionary<int, FIELD_LIMITS> fieldLimits = FieldLimits;
		if (fieldLimits != null && fieldLimits.ContainsKey(int_1))
		{
			FIELD_LIMITS fIELD_LIMITS = FieldLimits[int_1];
			long minimum = fIELD_LIMITS.minimum;
			int num = (int)minimum;
			long maximum = fIELD_LIMITS.maximum;
			int num2 = (int)maximum;
			int num3 = value;
			if (num3 < num || num3 > num2)
			{
				object[] array = new object[3];
				bool bTranslationExist = false;
				string fieldName = GetFieldName(int_1, ref bTranslationExist);
				array[0] = fieldName;
				array[1] = minimum;
				array[2] = maximum;
				CStorage.Alert(945, array);
				int num4 = value;
				if (num4 < num)
				{
					value = num;
				}
				else if (num4 < num2)
				{
					value = num2;
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void CheckFieldLimits(int int_1, ref float value)
	{
		Dictionary<int, FIELD_LIMITS> fieldLimits = FieldLimits;
		if (fieldLimits != null && fieldLimits.ContainsKey(int_1))
		{
			FIELD_LIMITS fIELD_LIMITS = FieldLimits[int_1];
			long minimum = fIELD_LIMITS.minimum;
			float num = minimum;
			long maximum = fIELD_LIMITS.maximum;
			float num2 = maximum;
			float num3 = value;
			if ((double)num3 < (double)num || (double)num3 > (double)num2)
			{
				object[] array = new object[3];
				bool bTranslationExist = false;
				string fieldName = GetFieldName(int_1, ref bTranslationExist);
				array[0] = fieldName;
				array[1] = minimum;
				array[2] = maximum;
				CStorage.Alert(945, array);
				num3 = value;
				if ((double)num3 < (double)num)
				{
					value = num;
				}
				else if ((double)num3 < (double)num2)
				{
					value = num2;
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void CheckFieldLimits(int int_1, ref short value)
	{
		Dictionary<int, FIELD_LIMITS> fieldLimits = FieldLimits;
		if (fieldLimits != null && fieldLimits.ContainsKey(int_1))
		{
			FIELD_LIMITS fIELD_LIMITS = FieldLimits[int_1];
			long minimum = fIELD_LIMITS.minimum;
			short num = (short)minimum;
			long maximum = fIELD_LIMITS.maximum;
			short num2 = (short)maximum;
			short num3 = value;
			if (num3 < num || num3 > num2)
			{
				object[] array = new object[3];
				bool bTranslationExist = false;
				string fieldName = GetFieldName(int_1, ref bTranslationExist);
				array[0] = fieldName;
				array[1] = minimum;
				array[2] = maximum;
				CStorage.Alert(945, array);
				short num4 = value;
				if (num4 < num)
				{
					value = num;
				}
				else if (num4 < num2)
				{
					value = num2;
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void CheckFieldLimits(int int_1, ref uint value)
	{
		Dictionary<int, FIELD_LIMITS> fieldLimits = FieldLimits;
		if (fieldLimits != null && fieldLimits.ContainsKey(int_1))
		{
			FIELD_LIMITS fIELD_LIMITS = FieldLimits[int_1];
			long minimum = fIELD_LIMITS.minimum;
			uint num = (uint)minimum;
			long maximum = fIELD_LIMITS.maximum;
			uint num2 = (uint)maximum;
			uint num3 = value;
			if (num3 < num || num3 > num2)
			{
				object[] array = new object[3];
				bool bTranslationExist = false;
				string fieldName = GetFieldName(int_1, ref bTranslationExist);
				array[0] = fieldName;
				array[1] = minimum;
				array[2] = maximum;
				CStorage.Alert(945, array);
				uint num4 = value;
				if (num4 < num)
				{
					value = num;
				}
				else if (num4 < num2)
				{
					value = num2;
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void CheckFieldLimits(int int_1, ref long value)
	{
		Dictionary<int, FIELD_LIMITS> fieldLimits = FieldLimits;
		if (fieldLimits != null && fieldLimits.ContainsKey(int_1))
		{
			FIELD_LIMITS fIELD_LIMITS = FieldLimits[int_1];
			long minimum = fIELD_LIMITS.minimum;
			long num = minimum;
			long maximum = fIELD_LIMITS.maximum;
			long num2 = maximum;
			long num3 = value;
			if (num3 < num || num3 > num2)
			{
				object[] array = new object[3];
				bool bTranslationExist = false;
				string fieldName = GetFieldName(int_1, ref bTranslationExist);
				array[0] = fieldName;
				array[1] = minimum;
				array[2] = maximum;
				CStorage.Alert(945, array);
				long num4 = value;
				if (num4 < num)
				{
					value = num;
				}
				else if (num4 < num2)
				{
					value = num2;
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void CheckFieldLimits(int int_1, ref ulong value)
	{
		Dictionary<int, FIELD_LIMITS> fieldLimits = FieldLimits;
		if (fieldLimits != null && fieldLimits.ContainsKey(int_1))
		{
			FIELD_LIMITS fIELD_LIMITS = FieldLimits[int_1];
			long minimum = fIELD_LIMITS.minimum;
			ulong num = (ulong)minimum;
			long maximum = fIELD_LIMITS.maximum;
			ulong num2 = (ulong)maximum;
			ulong num3 = value;
			if (num3 < num || num3 > num2)
			{
				object[] array = new object[3];
				bool bTranslationExist = false;
				string fieldName = GetFieldName(int_1, ref bTranslationExist);
				array[0] = fieldName;
				array[1] = minimum;
				array[2] = maximum;
				CStorage.Alert(945, array);
				ulong num4 = value;
				if (num4 < num)
				{
					value = num;
				}
				else if (num4 < num2)
				{
					value = num2;
				}
			}
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValue(int ElementIndex, int FieldIndex, decimal dvalue)
	{
		switch (FieldDataTypes[FieldIndex].data_type)
		{
		default:
			GC.KeepAlive(this);
			return false;
		case FIELD_DATA_TYPE_ENUM.Int:
		{
			decimal num4 = 2147483647m;
			if (dvalue > num4)
			{
				dvalue = 2147483647m;
			}
			int num5 = (int)dvalue;
			object[] array3 = elementValues[ElementIndex];
			if (num5 == (int)array3[FieldIndex])
			{
				return false;
			}
			array3[FieldIndex] = num5;
			return true;
		}
		case FIELD_DATA_TYPE_ENUM.Int16:
		{
			decimal num6 = 32767m;
			if (dvalue > num6)
			{
				dvalue = 32767m;
			}
			short num7 = Convert.ToInt16(dvalue);
			object[] array4 = elementValues[ElementIndex];
			if (num7 == (short)array4[FieldIndex])
			{
				return false;
			}
			array4[FieldIndex] = num7;
			return true;
		}
		case FIELD_DATA_TYPE_ENUM.UInt:
		{
			decimal num9 = 4294967295m;
			_ = dvalue > num9;
			uint num10 = (uint)dvalue;
			object[] array6 = elementValues[ElementIndex];
			if (num10 == (uint)array6[FieldIndex])
			{
				return false;
			}
			array6[FieldIndex] = num10;
			return true;
		}
		case FIELD_DATA_TYPE_ENUM.Int64:
		{
			long num2 = (long)dvalue;
			object[] array = elementValues[ElementIndex];
			if (num2 == (long)array[FieldIndex])
			{
				return false;
			}
			array[FieldIndex] = num2;
			return true;
		}
		case FIELD_DATA_TYPE_ENUM.UInt64:
		{
			ulong num8 = (ulong)dvalue;
			object[] array5 = elementValues[ElementIndex];
			if (num8 == (ulong)array5[FieldIndex])
			{
				return false;
			}
			array5[FieldIndex] = num8;
			return true;
		}
		case FIELD_DATA_TYPE_ENUM.Float:
		{
			float num3 = (float)dvalue;
			object[] array2 = elementValues[ElementIndex];
			if ((double)num3 == (double)(float)array2[FieldIndex])
			{
				return false;
			}
			array2[FieldIndex] = num3;
			return true;
		}
		case FIELD_DATA_TYPE_ENUM.Double:
		{
			double num = (double)elementValues[ElementIndex][FieldIndex];
			if ((double)dvalue == num)
			{
				return false;
			}
			elementValues[ElementIndex][FieldIndex] = (double)dvalue;
			return true;
		}
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValue(int int_1, int int_2, string Value)
	{
		FIELD_DATA_TYPE[] fieldDataTypes = FieldDataTypes;
		switch (fieldDataTypes[int_2].data_type)
		{
		case FIELD_DATA_TYPE_ENUM.Int:
			return SetValueInt(int_1, int_2, Value);
		case FIELD_DATA_TYPE_ENUM.Int16:
			return SetValueShort(int_1, int_2, Value);
		case FIELD_DATA_TYPE_ENUM.UInt:
			return SetValueUInt(int_1, int_2, Value);
		case FIELD_DATA_TYPE_ENUM.Int64:
			return SetValueLong(int_1, int_2, Value);
		case FIELD_DATA_TYPE_ENUM.UInt64:
			return SetValueULong(int_1, int_2, Value);
		case FIELD_DATA_TYPE_ENUM.Float:
			return SetValueFloat(int_1, int_2, Value);
		case FIELD_DATA_TYPE_ENUM.Double:
			return SetValueDouble(int_1, int_2, Value);
		case FIELD_DATA_TYPE_ENUM.String:
		{
			byte[] array4 = new byte[fieldDataTypes[int_2].size];
			byte[] bytes2 = Encoding.GetEncoding(Class16.smethod_0(1648985403)).GetBytes(Value);
			int num4 = bytes2.Length;
			int num5 = array4.Length;
			if (num4 >= num5)
			{
				num4 = num5 - 1;
			}
			Array.Copy(bytes2, array4, num4);
			elementValues[int_1][int_2] = array4;
			return true;
		}
		case FIELD_DATA_TYPE_ENUM.WString:
		{
			byte[] array3 = new byte[fieldDataTypes[int_2].size];
			byte[] bytes = Encoding.Unicode.GetBytes(Value);
			int num2 = bytes.Length;
			int num3 = array3.Length;
			if (num2 >= num3)
			{
				num2 = num3 - 2;
			}
			Array.Copy(bytes, array3, num2);
			elementValues[int_1][int_2] = array3;
			return true;
		}
		default:
			return false;
		case FIELD_DATA_TYPE_ENUM.Bool:
		{
			string[] array = Value.Split('-');
			byte[] array2 = new byte[FieldDataTypes[int_2].size];
			int num = 0;
			if (array.Length != 0)
			{
				do
				{
					array2[num] = Convert.ToByte(array[num], 16);
					num++;
				}
				while (num < array.Length);
			}
			elementValues[int_1][int_2] = array2;
			return true;
		}
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValueDouble(int int_1, int int_2, string Value)
	{
		if (!double.TryParse(Value, out var result))
		{
			GC.KeepAlive(this);
			return false;
		}
		object[] array = elementValues[int_1];
		if (result == (double)array[int_2])
		{
			return false;
		}
		array[int_2] = result;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValueInt(int int_1, int int_2, string Value)
	{
		if (!int.TryParse(Value, out var result))
		{
			GC.KeepAlive(this);
			return false;
		}
		object[] array = elementValues[int_1];
		if (result == (int)array[int_2])
		{
			return false;
		}
		array[int_2] = result;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValueFloat(int int_1, int int_2, string Value)
	{
		if (!float.TryParse(Value, out var result))
		{
			GC.KeepAlive(this);
			return false;
		}
		object[] array = elementValues[int_1];
		if ((double)result == (double)(float)array[int_2])
		{
			return false;
		}
		array[int_2] = result;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValueShort(int int_1, int int_2, string Value)
	{
		if (!short.TryParse(Value, out var result))
		{
			GC.KeepAlive(this);
			return false;
		}
		object[] array = elementValues[int_1];
		if (result == (short)array[int_2])
		{
			return false;
		}
		array[int_2] = result;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValueUInt(int int_1, int int_2, string Value)
	{
		if (!uint.TryParse(Value, out var result))
		{
			GC.KeepAlive(this);
			return false;
		}
		object[] array = elementValues[int_1];
		if (result == (uint)array[int_2])
		{
			return false;
		}
		array[int_2] = result;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValueLong(int int_1, int int_2, string Value)
	{
		if (!long.TryParse(Value, out var result))
		{
			GC.KeepAlive(this);
			return false;
		}
		object[] array = elementValues[int_1];
		if (result == (long)array[int_2])
		{
			return false;
		}
		array[int_2] = result;
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool SetValueULong(int int_1, int int_2, string Value)
	{
		if (!ulong.TryParse(Value, out var result))
		{
			GC.KeepAlive(this);
			return false;
		}
		object[] array = elementValues[int_1];
		if (result == (ulong)array[int_2])
		{
			return false;
		}
		array[int_2] = result;
		return true;
	}

	public string GetType(int FieldIndex)
	{
		if (FieldIndex > -1)
		{
			return elementTypes[FieldIndex];
		}
		return string.Empty;
	}

	public void RemoveItem(int itemIndex)
	{
		object[][] array = elementValues;
		object[][] array2 = new object[array.Length - 1][];
		Array.Copy(array, 0, array2, 0, itemIndex);
		Array.Copy(elementValues, itemIndex + 1, array2, itemIndex, array2.Length - itemIndex);
		elementValues = array2;
		IDs.RemoveAt(itemIndex);
		GC.KeepAlive(this);
	}

	public int AddItems(List<object[]> newItems)
	{
		int num = elementValues.Length;
		int num2 = elementValues.Length;
		Array.Resize(ref elementValues, newItems.Count + num2);
		int num3 = elementValues.Length;
		int num4 = 0;
		int num5 = num;
		if (num < num3)
		{
			do
			{
				elementValues[num5] = newItems[num4];
				num4++;
				IDs.Add((int)elementValues[num5][0]);
				num5++;
			}
			while (num5 < num3);
		}
		GC.KeepAlive(this);
		return num3 - 1;
	}

	public void AddItem(int int_1, object[] itemValues)
	{
		if (itemValues == null)
		{
			itemValues = new object[elementTypes.Length];
		}
		else if (itemValues.Length != elementTypes.Length)
		{
			object[] array = new object[elementTypes.Length];
			Array.Copy(itemValues, 0, array, 0, Math.Min(itemValues.Length, array.Length));
			itemValues = array;
		}
		object[][] array2 = elementValues;
		if (int_1 < 0)
		{
			int_1 = 0;
		}
		else if (int_1 > array2.Length)
		{
			int_1 = array2.Length;
		}
		object[][] array3 = new object[array2.Length + 1][];
		Array.Copy(array2, 0, array3, 0, int_1);
		array3[int_1] = itemValues;
		Array.Copy(elementValues, int_1, array3, int_1 + 1, array3.Length - int_1 - 1);
		elementValues = array3;
		UpdateIDs();
	}

	public int AddItem(object[] itemValues)
	{
		Array.Resize(ref elementValues, elementValues.Length + 1);
		object[][] array = elementValues;
		array[array.Length - 1] = itemValues;
		IDs.Add((int)itemValues[0]);
		GC.KeepAlive(this);
		return elementValues.Length - 1;
	}

	public void MoveItem(int src_e, int dest_e)
	{
		object[][] array = elementValues;
		object[][] array2 = new object[array.Length][];
		object[] array3 = array[src_e];
		object[] array4 = new object[array3.Length];
		array3.CopyTo(array4, 0);
		if (src_e > dest_e)
		{
			Array.Copy(elementValues, 0, array2, 0, dest_e);
			array2[dest_e] = array4;
			Array.Copy(elementValues, dest_e, array2, dest_e + 1, src_e - dest_e);
			object[][] array5 = elementValues;
			Array.Copy(array5, src_e + 1, array2, src_e + 1, array5.Length - src_e - 1);
		}
		else
		{
			Array.Copy(elementValues, 0, array2, 0, src_e);
			Array.Copy(elementValues, src_e + 1, array2, src_e, dest_e - src_e);
			array2[dest_e] = array4;
			object[][] array6 = elementValues;
			int num = dest_e + 1;
			Array.Copy(array6, num, array2, num, array6.Length - dest_e - 1);
		}
		elementValues = array2;
		bItemsOrderingChanged = true;
		UpdateIDs();
	}

	public string GetParsedItemName(int int_1)
	{
		string parsedItemName = RSCommon.GetParsedItemName(GetValue(int_1, NameFieldIndex));
		GC.KeepAlive(this);
		return parsedItemName;
	}

	public unsafe static void WriteList(BinaryWriter bw, int int_1, eList[] Lists, int ConversationListIndex, ToolStripProgressBar progress, long* PrevPos, int* pInt_0, int* pInt_1, int[] fields_encrypt, ELEMENTS_SAVE_TYPE SaveType, int adding_key, GAMES Game, int Version, [MarshalAs(UnmanagedType.U1)] bool skipStrings, [MarshalAs(UnmanagedType.U1)] bool isRealm)
	{
		eList eList2 = Lists[int_1];
		bool flag = IsElementsPacked(Game, Version);
		int num = ((Game == GAMES.ROG || Game == GAMES.TOS) ? 1 : 0);
		int listItemSize;
		if (int_1 != ConversationListIndex && !isRealm)
		{
			if ((byte)num != 0)
			{
				bw.Write(eList2._idSpace);
				bw.Write(eList2._list_type);
				bw.Write(eList2.item_size);
			}
			else if (Game == GAMES.PW && Version - 191 <= 158 && !skipStrings)
			{
				bw.Write(eList2._list_type);
			}
			int num2 = eList2.elementValues.Length;
			if (SaveType == ELEMENTS_SAVE_TYPE.PROTECT_WITH_LOGIN && int_1 <= 40)
			{
				num2 -= Convert.ToInt32(Math.Floor(ACE.RSGlobal.RSGlobal.GetSecretNumber_unmanaged(adding_key, int_1)));
			}
			if (int_1 < 20)
			{
				bw.Write(CommonStorage.ValidateValue(num2));
			}
			else
			{
				bw.Write(num2);
			}
			if (Game == GAMES.PW && Version >= 191 && Version < 350)
			{
				if (!skipStrings)
				{
					listItemSize = eList2.item_size;
					goto IL_00f0;
				}
			}
			else if (!skipStrings)
			{
				goto IL_00f7;
			}
			listItemSize = GetListItemSize(eList2, skipStrings);
			goto IL_00f0;
		}
		goto IL_00f7;
		IL_00f0:
		bw.Write(listItemSize);
		goto IL_00f7;
		IL_00f7:
		if (eList2.elementValues.Length != 0)
		{
			if (flag && int_1 != ConversationListIndex && !isRealm)
			{
				WriteItemsPacked(bw, int_1, Lists, ConversationListIndex, PrevPos, pInt_0, pInt_1, fields_encrypt, Game, Version, skipStrings);
			}
			else
			{
				WriteItems(bw, int_1, ref Lists, ConversationListIndex, PrevPos, pInt_0, pInt_1, fields_encrypt, Game, Version, skipStrings);
			}
		}
	}

	public unsafe static void WriteList(BinaryWriter bw, int int_1, eList[] Lists, int ConversationListIndex, GAMES Game, int Version, [MarshalAs(UnmanagedType.U1)] bool skipStrings, [MarshalAs(UnmanagedType.U1)] bool isRealm)
	{
		long num = 0L;
		int num2 = 0;
		int num3 = 0;
		WriteList(bw, int_1, Lists, ConversationListIndex, null, &num, &num2, &num3, null, ELEMENTS_SAVE_TYPE.FULL_SIGNATURE, 0, Game, Version, skipStrings, isRealm);
	}

	public unsafe static void WriteList(BinaryWriter bw, int int_1, ref eList[] Lists, int ConversationListIndex, GAMES Game, int Version)
	{
		long num = 0L;
		int num2 = 0;
		int num3 = 0;
		WriteList(bw, int_1, Lists, ConversationListIndex, null, &num, &num2, &num3, null, ELEMENTS_SAVE_TYPE.FULL_SIGNATURE, 0, Game, Version, skipStrings: false, isRealm: false);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsElementsPacked(GAMES Game, int Version)
	{
		if (Game == GAMES.ROG || Game == GAMES.TOS || Game == GAMES.SW)
		{
			goto IL_0037;
		}
		if (Game == GAMES.PW && Version >= 350)
		{
			int num = ((Version == 1488 || Version >= 30000) ? 1 : 0);
			if ((byte)num == 0)
			{
				goto IL_0037;
			}
		}
		int num2 = 0;
		goto IL_0039;
		IL_0039:
		return (byte)num2 != 0;
		IL_0037:
		num2 = 1;
		goto IL_0039;
	}

	public unsafe static void WriteItems(BinaryWriter bw, int int_1, ref eList[] Lists, int ConversationListIndex, long* PrevPos, int* pInt_0, int* pInt_1, int[] fields_encrypt, GAMES Game, int Version, [MarshalAs(UnmanagedType.U1)] bool skipStrings)
	{
		eList eList2 = Lists[int_1];
		*pInt_0 = 0;
		if (0 >= (nint)eList2.elementValues.LongLength)
		{
			return;
		}
		do
		{
			*pInt_1 = 0;
			object[] array = eList2.elementValues[*pInt_0];
			int num = ((array != null) ? array.Length : 0);
			if (0 < (nint)eList2.elementTypes.LongLength)
			{
				do
				{
					if (skipStrings)
					{
						FIELD_DATA_TYPE_ENUM fIELD_DATA_TYPE_ENUM = smethod_1(eList2, *pInt_1);
						if (fIELD_DATA_TYPE_ENUM == FIELD_DATA_TYPE_ENUM.WString || fIELD_DATA_TYPE_ENUM == FIELD_DATA_TYPE_ENUM.String)
						{
							goto IL_005c;
						}
					}
					int num2 = *pInt_1;
					FIELD_DATA_TYPE_ENUM type = smethod_1(eList2, num2);
					if (array != null && num2 < num)
					{
						writeValue(bw, array[num2], type, num2, fields_encrypt);
					}
					else
					{
						writeValue(bw, null, type, num2, fields_encrypt);
					}
					goto IL_005c;
					IL_005c:
					(*pInt_1)++;
				}
				while (*pInt_1 < (nint)eList2.elementTypes.LongLength);
			}
			if (int_1 != ConversationListIndex)
			{
				int num3 = (int)eList2.elementTypes.LongLength;
				if (array != null && num3 < array.Length)
				{
					array[num3] = null;
				}
			}
			(*pInt_0)++;
		}
		while (*pInt_0 < (nint)eList2.elementValues.LongLength);
	}

	private static FIELD_DATA_TYPE_ENUM smethod_1(eList eList_0, int int_1)
	{
		if (eList_0 != null && int_1 >= 0)
		{
			if (eList_0.FieldDataTypes == null || (eList_0.elementTypes != null && eList_0.FieldDataTypes.Length != eList_0.elementTypes.Length))
			{
				try
				{
					eList_0.CreateFastDataTypes();
				}
				catch
				{
				}
			}
			if (eList_0.FieldDataTypes != null && int_1 < eList_0.FieldDataTypes.Length)
			{
				FIELD_DATA_TYPE_ENUM data_type = eList_0.FieldDataTypes[int_1].data_type;
				if (data_type != FIELD_DATA_TYPE_ENUM.Unknown)
				{
					return data_type;
				}
			}
			if (eList_0.elementTypes != null && int_1 < eList_0.elementTypes.Length)
			{
				string text = eList_0.elementTypes[int_1];
				if (text == Class16.smethod_0(1648989776))
				{
					return FIELD_DATA_TYPE_ENUM.Int;
				}
				if (text == Class16.smethod_0(1648989805))
				{
					return FIELD_DATA_TYPE_ENUM.Int16;
				}
				if (text == Class16.smethod_0(1648989786))
				{
					return FIELD_DATA_TYPE_ENUM.UInt;
				}
				if (text == Class16.smethod_0(1648989809))
				{
					return FIELD_DATA_TYPE_ENUM.UInt16;
				}
				if (text == Class16.smethod_0(1648989830))
				{
					return FIELD_DATA_TYPE_ENUM.Int64;
				}
				if (text == Class16.smethod_0(1648989834))
				{
					return FIELD_DATA_TYPE_ENUM.UInt64;
				}
				if (text == Class16.smethod_0(1648902744))
				{
					return FIELD_DATA_TYPE_ENUM.Float;
				}
				if (text == Class16.smethod_0(1648989855))
				{
					return FIELD_DATA_TYPE_ENUM.Double;
				}
				if (!string.IsNullOrWhiteSpace(text) && text.StartsWith(Class16.smethod_0(1648985317), StringComparison.Ordinal))
				{
					return FIELD_DATA_TYPE_ENUM.String;
				}
				if (!string.IsNullOrWhiteSpace(text) && text.StartsWith(Class16.smethod_0(1648985302), StringComparison.Ordinal))
				{
					return FIELD_DATA_TYPE_ENUM.WString;
				}
				if (!string.IsNullOrWhiteSpace(text) && text.StartsWith(Class16.smethod_0(1648985282), StringComparison.Ordinal))
				{
					return FIELD_DATA_TYPE_ENUM.Bool;
				}
			}
			return FIELD_DATA_TYPE_ENUM.Int;
		}
		return FIELD_DATA_TYPE_ENUM.Int;
	}

	public unsafe static void WriteItemsPacked(BinaryWriter bw, int int_1, eList[] Lists, int ConversationListIndex, long* PrevPos, int* pInt_0, int* pInt_1, int[] fields_encrypt, GAMES Game, int Version, [MarshalAs(UnmanagedType.U1)] bool skipStrings)
	{
		eList eList2 = Lists[int_1];
		int listItemSize = GetListItemSize(eList2, skipStrings: false);
		uint num = 0u;
		using MemoryStream memoryStream = new MemoryStream();
		using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		using BinaryReader binaryReader = new BinaryReader(memoryStream);
		int num2 = ((Game == GAMES.ROG || Game == GAMES.TOS) ? 1 : 0);
		bool flag = (byte)num2 != 0;
		*pInt_0 = 0;
		if (0 < (nint)eList2.elementValues.LongLength)
		{
			do
			{
				object[] array = eList2.elementValues[*pInt_0];
				int num3 = ((array != null) ? array.Length : 0);
				using MemoryStream memoryStream2 = new MemoryStream();
				using BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				using BinaryReader binaryReader2 = new BinaryReader(memoryStream2);
				int num4 = 0;
				if (0 < (nint)eList2.elementTypes.LongLength)
				{
					do
					{
						object value = ((array != null && num4 < num3) ? array[num4] : null);
						writeValue(binaryWriter2, value, smethod_1(eList2, num4), num4, null);
						num4++;
					}
					while (num4 < (nint)eList2.elementTypes.LongLength);
				}
				memoryStream2.Position = 0L;
				byte[] array2 = binaryReader2.ReadBytes(listItemSize);
				byte[] array3 = ((!flag) ? ACE.RSGlobal.RSGlobal.MPPCCompress(array2) : ZlibHelpers.CompressDataZlib(array2));
				binaryWriter2.Close();
				binaryReader2.Close();
				binaryWriter.Write(array3);
				if (array3.Length > short.MaxValue) throw new InvalidDataException("Packed element exceeds supported signed 16-bit length.");
				short num5 = (short)array3.Length;
				bw.Write(eList2.getid(*pInt_0));
				bw.Write(num5);
				num = checked((uint)num5 + num);
				if (array != null && eList2.elementTypes != null && eList2.elementTypes.Length < array.Length)
				{
					array[(nint)eList2.elementTypes.LongLength] = null;
				}
				(*pInt_0)++;
			}
			while (*pInt_0 < (nint)eList2.elementValues.LongLength);
		}
		memoryStream.Position = 0L;
		bw.Write(num);
		binaryWriter.Flush();
		memoryStream.CopyTo(bw.BaseStream, 81920);
		binaryWriter.Close();
		binaryReader.Close();
	}

	private static bool smethod_2(object object_0)
	{
		if (object_0 != null && object_0 != DBNull.Value && !(object_0.GetType() == typeof(object)))
		{
			if (object_0 is string value)
			{
				return string.IsNullOrWhiteSpace(value);
			}
			return false;
		}
		return true;
	}

	private static byte[] smethod_3(FIELD_DATA_TYPE_ENUM field_DATA_TYPE_ENUM_0)
	{
		switch (field_DATA_TYPE_ENUM_0)
		{
		case FIELD_DATA_TYPE_ENUM.Int:
			return BitConverter.GetBytes(0);
		case FIELD_DATA_TYPE_ENUM.Int16:
			return BitConverter.GetBytes((short)0);
		case FIELD_DATA_TYPE_ENUM.UInt:
			return BitConverter.GetBytes(0u);
		case FIELD_DATA_TYPE_ENUM.Int64:
			return BitConverter.GetBytes(0L);
		case FIELD_DATA_TYPE_ENUM.UInt64:
			return BitConverter.GetBytes(0uL);
		case FIELD_DATA_TYPE_ENUM.Float:
			return BitConverter.GetBytes(0f);
		case FIELD_DATA_TYPE_ENUM.Double:
			return BitConverter.GetBytes(0.0);
		default:
			return null;
		case FIELD_DATA_TYPE_ENUM.String:
		case FIELD_DATA_TYPE_ENUM.WString:
		case FIELD_DATA_TYPE_ENUM.Bool:
			return Array.Empty<byte>();
		}
	}

	private static void smethod_4(BinaryWriter binaryWriter_0, FIELD_DATA_TYPE_ENUM field_DATA_TYPE_ENUM_0, object object_0)
	{
		switch (field_DATA_TYPE_ENUM_0)
		{
		case FIELD_DATA_TYPE_ENUM.Int:
			binaryWriter_0.Write(0);
			break;
		case FIELD_DATA_TYPE_ENUM.Int16:
			binaryWriter_0.Write((short)0);
			break;
		case FIELD_DATA_TYPE_ENUM.UInt:
			binaryWriter_0.Write(0u);
			break;
		case FIELD_DATA_TYPE_ENUM.Int64:
			binaryWriter_0.Write(0L);
			break;
		case FIELD_DATA_TYPE_ENUM.UInt64:
			binaryWriter_0.Write(0uL);
			break;
		case FIELD_DATA_TYPE_ENUM.Float:
			binaryWriter_0.Write(0f);
			break;
		case FIELD_DATA_TYPE_ENUM.Double:
			binaryWriter_0.Write(0.0);
			break;
		case FIELD_DATA_TYPE_ENUM.String:
		case FIELD_DATA_TYPE_ENUM.WString:
		case FIELD_DATA_TYPE_ENUM.Bool:
			if (object_0 is byte[] buffer)
			{
				binaryWriter_0.Write(buffer);
			}
			break;
		case FIELD_DATA_TYPE_ENUM.UInt16:
			break;
		}
	}

	public static byte[] GetValueBytes(object value, FIELD_DATA_TYPE_ENUM type)
	{
		if (value is byte[] result)
		{
			return result;
		}
		if (smethod_2(value))
		{
			return smethod_3(type);
		}
		try
		{
			switch (type)
			{
			case FIELD_DATA_TYPE_ENUM.Int:
				return BitConverter.GetBytes(Convert.ToInt32(value));
			case FIELD_DATA_TYPE_ENUM.Int16:
				return BitConverter.GetBytes(Convert.ToInt16(value));
			case FIELD_DATA_TYPE_ENUM.UInt:
				return BitConverter.GetBytes(Convert.ToUInt32(value));
			case FIELD_DATA_TYPE_ENUM.Int64:
				return BitConverter.GetBytes(Convert.ToInt64(value));
			case FIELD_DATA_TYPE_ENUM.UInt64:
				return BitConverter.GetBytes(Convert.ToUInt64(value));
			case FIELD_DATA_TYPE_ENUM.Float:
				return BitConverter.GetBytes(Convert.ToSingle(value));
			case FIELD_DATA_TYPE_ENUM.Double:
				return BitConverter.GetBytes(Convert.ToDouble(value));
			case FIELD_DATA_TYPE_ENUM.UInt16:
				break;
			case FIELD_DATA_TYPE_ENUM.String:
			case FIELD_DATA_TYPE_ENUM.WString:
			case FIELD_DATA_TYPE_ENUM.Bool:
				return (value as byte[]) ?? Array.Empty<byte>();
			}
		}
		catch (Exception ex) when (((ex is InvalidCastException || ex is FormatException || ex is OverflowException) ? 1 : 0) != 0)
		{
			return smethod_3(type);
		}
		return smethod_3(type);
	}

	public static void writeValue(BinaryWriter bw, object value, FIELD_DATA_TYPE_ENUM type, int int_1, int[] fields_encrypt)
	{
		if (value is byte[] array && type >= FIELD_DATA_TYPE_ENUM.Int)
		{
			switch (type)
			{
			case FIELD_DATA_TYPE_ENUM.Int:
				bw.Write((array.Length >= 4) ? BitConverter.ToInt32(array, 0) : 0);
				return;
			case FIELD_DATA_TYPE_ENUM.Int16:
				bw.Write((short)((array.Length >= 2) ? BitConverter.ToInt16(array, 0) : 0));
				return;
			case FIELD_DATA_TYPE_ENUM.UInt:
				bw.Write((array.Length >= 4) ? BitConverter.ToUInt32(array, 0) : 0u);
				return;
			case FIELD_DATA_TYPE_ENUM.Int64:
				bw.Write((array.Length >= 8) ? BitConverter.ToInt64(array, 0) : 0L);
				return;
			case FIELD_DATA_TYPE_ENUM.UInt64:
				bw.Write((array.Length >= 8) ? BitConverter.ToUInt64(array, 0) : 0uL);
				return;
			case FIELD_DATA_TYPE_ENUM.Float:
				bw.Write((array.Length >= 4) ? BitConverter.ToSingle(array, 0) : 0f);
				return;
			case FIELD_DATA_TYPE_ENUM.Double:
				bw.Write((array.Length >= 8) ? BitConverter.ToDouble(array, 0) : 0.0);
				return;
			}
		}
		if (smethod_2(value) && type >= FIELD_DATA_TYPE_ENUM.Int && type <= FIELD_DATA_TYPE_ENUM.Double)
		{
			smethod_4(bw, type, value);
			return;
		}
		try
		{
			switch (type)
			{
			case FIELD_DATA_TYPE_ENUM.Int:
				bw.Write(Convert.ToInt32(value));
				break;
			case FIELD_DATA_TYPE_ENUM.Int16:
				bw.Write(Convert.ToInt16(value));
				break;
			case FIELD_DATA_TYPE_ENUM.UInt:
				bw.Write(Convert.ToUInt32(value));
				break;
			case FIELD_DATA_TYPE_ENUM.Int64:
				bw.Write(Convert.ToInt64(value));
				break;
			case FIELD_DATA_TYPE_ENUM.UInt64:
				bw.Write(Convert.ToUInt64(value));
				break;
			case FIELD_DATA_TYPE_ENUM.Float:
				bw.Write(Convert.ToSingle(value));
				break;
			case FIELD_DATA_TYPE_ENUM.Double:
				bw.Write(Convert.ToDouble(value));
				break;
			case FIELD_DATA_TYPE_ENUM.String:
			case FIELD_DATA_TYPE_ENUM.WString:
			case FIELD_DATA_TYPE_ENUM.Bool:
				if (value is byte[] buffer)
				{
					bw.Write(buffer);
				}
				break;
			case FIELD_DATA_TYPE_ENUM.UInt16:
				break;
			}
		}
		catch (Exception ex)
		{
			ex.Data[Class16.smethod_0(1648961220)] = int_1;
			ex.Data[Class16.smethod_0(1648961237)] = type.ToString();
			IDictionary data = ex.Data;
			string key = Class16.smethod_0(1648961253);
			object obj;
			if (value == null)
			{
				obj = null;
			}
			else
			{
				obj = value.GetType().FullName;
				if (obj != null)
				{
					goto IL_0236;
				}
			}
			obj = Class16.smethod_0(1648961269);
			goto IL_0236;
			IL_0236:
			data[key] = obj;
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648961272));
			smethod_4(bw, type, value);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool ReadList(BinaryReader br, int int_1, ref eList[] Lists, int ConversationListIndex, GAMES Game, int Version)
	{
		eList eList2 = Lists[int_1];
		eList2.Game = Game;
		if (int_1 == ConversationListIndex)
		{
			int conversationListLength = GetConversationListLength(br);
			eList2.elementTypes[0] = Class16.smethod_0(1648985282) + conversationListLength;
			(eList2.elementValues = new object[1][])[0] = new object[(nint)eList2.elementTypes.LongLength];
			eList2.elementValues[0][0] = readValue(br, eList2.elementTypes[0]);
		}
		else
		{
			bool flag = ((Game == GAMES.PW && (uint)(Version - 191) <= 158u) ? true : false);
			if (IsElementsPacked(Game, Version))
			{
				eList2._idSpace = br.ReadInt32();
				eList2._list_type = br.ReadInt32();
				eList2.item_size = br.ReadInt32();
			}
			else if (flag)
			{
				eList2._list_type = br.ReadInt32();
			}
			uint num = br.ReadUInt32();
			if (num > 500000)
			{
				ADDITIONAL_PARAMS aParams = CommonStorage.AParams;
				if (aParams == null || !aParams.IgnoreItemCountOnLoading)
				{
					throw new ApplicationException(string.Format(Class16.smethod_0(1648961303), num, int_1));
				}
			}
			if (flag)
			{
				eList2.item_size = (int)br.ReadUInt32();
			}
			if (num > int.MaxValue) throw new InvalidDataException("Elements record count exceeds supported range.");
            int recordSize = GetListItemSize(eList2);
            if (recordSize <= 0 && num != 0) throw new InvalidDataException("Invalid elements record size.");
            ElementsBinary.Require(br, (long)num * recordSize);
            int[] byteLengths = new int[eList2.elementTypes.Length];
            for (int f = 0; f < byteLengths.Length; f++)
            {
                string type = eList2.elementTypes[f];
                int colon = type.IndexOf(':');
                byteLengths[f] = -1;
                if (colon >= 0)
                {
                    if (!type.StartsWith("byte:", StringComparison.Ordinal) && !type.StartsWith("string:", StringComparison.Ordinal) && !type.StartsWith("wstring:", StringComparison.Ordinal))
                        throw new InvalidDataException("Unsupported elements field: " + type);
                    byteLengths[f] = int.Parse(type.Substring(colon + 1), System.Globalization.CultureInfo.InvariantCulture);
                    if (byteLengths[f] < 0) throw new InvalidDataException("Negative elements field length.");
                }
            }
            eList2.elementValues = new object[num][];
			int num2 = 0;
			if (0 < (int)num)
			{
				do
				{
					eList2.elementValues[num2] = new object[(nint)eList2.elementTypes.LongLength + 1];
					int num3 = 0;
					if (0 < (nint)eList2.elementTypes.LongLength)
					{
						do
						{
							eList2.elementValues[num2][num3] = byteLengths[num3] >= 0 ? ElementsBinary.ReadExact(br, byteLengths[num3]) : readValue(br, eList2.elementTypes[num3]);
							num3++;
						}
						while (num3 < (nint)eList2.elementTypes.LongLength);
					}
					num2++;
				}
				while (num2 < (int)num);
			}
		}
		if (int_1 != ConversationListIndex)
		{
			eList2.UpdateIDs();
		}
		return true;
	}

	public static object readValue(BinaryReader br, string type)
	{
		switch (type)
		{
		case "int":
			return ElementsBinary.Box(br.ReadInt32());
		case "float":
			return ElementsBinary.Box(br.ReadSingle());
		case "uint":
			return ElementsBinary.Box(br.ReadUInt32());
		case "int16":
			return br.ReadInt16();
		case "uint16":
			return br.ReadUInt16();
		case "int64":
			return br.ReadInt64();
		case "uint64":
			return br.ReadUInt64();
		case "double":
			return br.ReadDouble();
		default:
		{
			string text = "byte:";
			if (type.StartsWith(text, StringComparison.Ordinal))
			{
				return ElementsBinary.ReadExact(br, int.Parse(type.Substring(5), System.Globalization.CultureInfo.InvariantCulture));
			}
			string text2 = "wstring:";
			if (type.StartsWith(text2, StringComparison.Ordinal))
			{
				return ElementsBinary.ReadExact(br, int.Parse(type.Substring(8), System.Globalization.CultureInfo.InvariantCulture));
			}
			string text3 = "string:";
			if (type.StartsWith(text3, StringComparison.Ordinal))
			{
				return ElementsBinary.ReadExact(br, int.Parse(type.Substring(7), System.Globalization.CultureInfo.InvariantCulture));
			}
			throw new InvalidDataException("不支持的 elements 字段类型：" + type);
		}
		}
	}

	public static int GetConversationListLength(BinaryReader br)
	{
		long position = br.BaseStream.Position;
		try
		{
			int count = ElementsBinary.Count(br, 136);
			for (int i = 0; i < count; i++)
			{
				ElementsBinary.Skip(br, 132);
				int windows = ElementsBinary.Count(br, 16);
				for (int j = 0; j < windows; j++)
				{
					ElementsBinary.Skip(br, 8);
					int chars = ElementsBinary.Count(br, 2);
					ElementsBinary.Skip(br, (long)chars * 2);
					int options = ElementsBinary.Count(br, 136);
					ElementsBinary.Skip(br, (long)options * 136);
				}
			}
			return checked((int)(br.BaseStream.Position - position));
		}
		finally { br.BaseStream.Position = position; }
	}

	public static int GetListItemSize(eList list, [MarshalAs(UnmanagedType.U1)] bool skipStrings)
	{
		int num = 0;
		int num2 = 0;
		string[] array = list.elementTypes;
		if (array.Length != 0)
		{
			do
			{
				string text = array[num2];
				if (!skipStrings || (text[0] != 's' && text[0] != 'w'))
				{
					num = checked(GetFieldSize(text) + num);
				}
				num2++;
				array = list.elementTypes;
			}
			while (num2 < array.Length);
		}
		return num;
	}

	public static int GetListItemSize(eList list)
	{
		return GetListItemSize(list, skipStrings: false);
	}

	public int GetListItemSize([MarshalAs(UnmanagedType.U1)] bool skipStrings)
	{
		return GetListItemSize(this, skipStrings);
	}

	public int GetListItemSize()
	{
		return GetListItemSize(this, skipStrings: false);
	}

	public static int GetListFieldOffset(eList List, int int_1)
	{
		int num = 0;
		int num2 = 0;
		if (0 < int_1)
		{
			do
			{
				num = checked(GetFieldSize(List.elementTypes[num2]) + num);
				num2++;
			}
			while (num2 < int_1);
		}
		return num;
	}

	public int GetListFieldOffset(int int_1)
	{
		return GetListFieldOffset(this, int_1);
	}

	public static int GetFieldSize(string type)
	{
		if (string.IsNullOrEmpty(type))
		{
			return 0;
		}
		if (!(type == Class16.smethod_0(1648989776)) && !(type == Class16.smethod_0(1648902744)) && !(type == Class16.smethod_0(1648989786)))
		{
			if (type == Class16.smethod_0(1648985265))
			{
				return 64;
			}
			if (type == Class16.smethod_0(1648961453))
			{
				return 128;
			}
			if (!(type == Class16.smethod_0(1648989830)) && !(type == Class16.smethod_0(1648989834)) && !(type == Class16.smethod_0(1648989855)))
			{
				if (!(type == Class16.smethod_0(1648989805)) && !(type == Class16.smethod_0(1648989809)))
				{
					return type[0] switch
					{
						'w' => ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(8)), 
						's' => ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(7)), 
						'b' => ACE.RSGlobal.RSGlobal.String2Int_ext(type.Substring(5)), 
						_ => 4, 
					};
				}
				return 2;
			}
			return 8;
		}
		return 4;
	}

	public void UpdateIDs()
	{
		IdsMakingNow = true;
		object[][] array = elementValues;
		if (array != null)
		{
			int num = array.Length;
			IDs = new List<int>(num);
			int num2 = 0;
			if (0 < num)
			{
				do
				{
					object obj = elementValues[num2][0];
					int item = ((!(obj is byte[])) ? Convert.ToInt32(obj) : ((((byte[])obj).Length >= 4) ? BitConverter.ToInt32((byte[])obj, 0) : 0));
					IDs.Add(item);
					num2++;
				}
				while (num2 < num);
			}
		}
		IdsMakingNow = false;
	}

	public void UpdateFastIDs()
	{
		if (IDs == null)
		{
			UpdateIDs();
		}
		dictionary_0 = new Dictionary<int, int>(IDs.Count);
		int num = 0;
		if (0 < IDs.Count)
		{
			do
			{
				if (!dictionary_0.ContainsKey(IDs[num]))
				{
					dictionary_0.Add(IDs[num], num);
				}
				num++;
			}
			while (num < IDs.Count);
		}
		GC.KeepAlive(this);
	}

	public void UpdateIDsHashSet()
	{
		hashSet_0 = new HashSet<int>();
		int num = 0;
		if (0 < IDs.Count)
		{
			do
			{
				if (!hashSet_0.Contains(IDs[num]))
				{
					hashSet_0.Add(IDs[num]);
				}
				num++;
			}
			while (num < IDs.Count);
		}
		GC.KeepAlive(this);
	}

	public void UpdateNamesCache()
	{
		if (elementValues != null)
		{
			string[] namesCache = NamesCache;
			if (namesCache != null)
			{
				Array array = namesCache;
				Array.Clear(array, 0, array.Length);
			}
			int num = elementValues.Length;
			NamesCache = new string[num];
			if (NameFieldIndex > 0)
			{
				int num2 = 0;
				if (0 < num)
				{
					do
					{
						try
						{
							string text = ACE.RSGlobal.RSGlobal.Bytes2StringW((byte[])elementValues[num2][NameFieldIndex]);
							NamesCache[num2] = text.ToLowerInvariant();
						}
						catch (InvalidCastException)
						{
							NamesCache[num2] = string.Empty;
						}
						catch (IndexOutOfRangeException)
						{
							NamesCache[num2] = string.Empty;
						}
						num2++;
					}
					while (num2 < num);
				}
			}
		}
		GC.KeepAlive(this);
	}

	public int GetValueIFast(int int_1, int int_2)
	{
		int result = 0;
		if (elementValues != null && int_1 >= 0 && int_1 < elementValues.Length)
		{
			object[] array = elementValues[int_1];
			if (array != null && int_2 >= 0 && int_2 < array.Length)
			{
				if (FieldDataTypes != null && int_2 < FieldDataTypes.Length)
				{
					object obj = array[int_2];
					if (obj != null && obj != i0)
					{
						try
						{
							switch (FieldDataTypes[int_2].data_type)
							{
							case FIELD_DATA_TYPE_ENUM.String:
							case FIELD_DATA_TYPE_ENUM.WString:
								result = ACE.RSGlobal.RSGlobal.UIntParseFast(GetValue(int_1, int_2).Split(',')[0]);
								break;
							case FIELD_DATA_TYPE_ENUM.UInt:
								result = ((!(obj is uint num2)) ? Convert.ToInt32(obj, CultureInfo.InvariantCulture) : ((int)num2));
								break;
							case FIELD_DATA_TYPE_ENUM.Int:
								result = ((!(obj is int num)) ? Convert.ToInt32(obj, CultureInfo.InvariantCulture) : num);
								break;
							}
						}
						catch (InvalidCastException)
						{
						}
						catch (IndexOutOfRangeException)
						{
						}
						catch (FormatException)
						{
						}
						catch (OverflowException)
						{
						}
					}
					GC.KeepAlive(this);
					return result;
				}
				return result;
			}
			return result;
		}
		return result;
	}

	public int GetValueI(int int_1, int int_2)
	{
		return GetValueIFast(int_1, int_2);
	}

	public void Close()
	{
		FIELDS_TRANSLATER fieldsTranslation = FieldsTranslation;
		if (fieldsTranslation != null)
		{
			fieldsTranslation.TranslatedFields.Clear();
			((IDisposable)FieldsTranslation.TranslatedFieldsRegEx).Dispose();
		}
		string[] namesCache = NamesCache;
		if (namesCache != null)
		{
			Array array = namesCache;
			Array.Clear(array, 0, array.Length);
		}
		NamesCache = null;
		dictionary_0?.Clear();
		hashSet_0?.Clear();
		IDs?.Clear();
		FIELD_TYPES_DB fieldTypesDB = FieldTypesDB;
		if (fieldTypesDB != null)
		{
			fieldTypesDB.Fields.Clear();
			FieldTypesDB = null;
		}
		List<FIELD_SET> fieldSets = FieldSets;
		if (fieldSets != null)
		{
			List<FIELD_SET>.Enumerator enumerator = fieldSets.GetEnumerator();
			if (enumerator.MoveNext())
			{
				do
				{
					enumerator.Current.Fields.Clear();
				}
				while (enumerator.MoveNext());
			}
			FieldSets.Clear();
			FieldSets = null;
		}
		List<string> hintFields = HintFields;
		if (hintFields != null)
		{
			hintFields.Clear();
			HintFields = null;
		}
		Array sourceItemStruct = SourceItemStruct;
		if (sourceItemStruct != null)
		{
			Array.Clear(sourceItemStruct, 0, sourceItemStruct.Length);
		}
		Array array2 = elementFields;
		if (array2 != null)
		{
			Array.Clear(array2, 0, array2.Length);
		}
		Array array3 = elementTypes;
		if (array3 != null)
		{
			Array.Clear(array3, 0, array3.Length);
		}
		object[][] array4 = elementValues;
		if (array4 != null)
		{
			object[][] array5 = array4;
			int num = 0;
			if (array5.Length != 0)
			{
				do
				{
					ref object[] reference = ref array5[num];
					Array array6 = reference;
					if (array6 != null)
					{
						Array.Clear(array6, 0, array6.Length);
					}
					reference = null;
					num++;
				}
				while (num < array5.Length);
			}
		}
		Array array7 = elementValues;
		if (array7 != null)
		{
			Array.Clear(array7, 0, array7.Length);
		}
		elementValues = null;
		Array array8 = _elementFields;
		if (array8 != null)
		{
			Array.Clear(array8, 0, array8.Length);
		}
		Array array9 = _elementTypes;
		if (array9 != null)
		{
			Array.Clear(array9, 0, array9.Length);
		}
		byte[][] array10 = d_elementBytes;
		if (array10 != null)
		{
			byte[][] array11 = array10;
			int num2 = 0;
			if (array11.Length != 0)
			{
				do
				{
					byte[] array12 = array11[num2];
					if (array12 != null)
					{
						Array.Clear(array12, 0, array12.Length);
					}
					num2++;
				}
				while (num2 < array11.Length);
			}
			Array array13 = d_elementBytes;
			if (array13 != null)
			{
				Array.Clear(array13, 0, array13.Length);
			}
		}
		d_elementOffsets = null;
		fieldtypes = null;
		fieldtypes_extra?.Clear();
		fieldtypes_extra = null;
		FieldsBindedLists?.Clear();
		FieldsBindedLists = null;
		Dictionary<int, List<int>> references = References;
		if (references != null)
		{
			Dictionary<int, List<int>>.ValueCollection.Enumerator enumerator2 = references.Values.GetEnumerator();
			if (enumerator2.MoveNext())
			{
				do
				{
					enumerator2.Current?.Clear();
				}
				while (enumerator2.MoveNext());
			}
			References.Clear();
			References = null;
		}
		FieldDataTypes = null;
	}

	public void CreateFastDataTypes()
	{
		string[] array = elementTypes;
		if (array == null)
		{
			return;
		}
		FieldDataTypes = new FIELD_DATA_TYPE[array.Length];
		int num = 0;
		if (array.Length != 0)
		{
			FIELD_DATA_TYPE fIELD_DATA_TYPE = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE2 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE3 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE4 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE5 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE6 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE7 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE8 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE9 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE10 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE11 = default(FIELD_DATA_TYPE);
			FIELD_DATA_TYPE fIELD_DATA_TYPE12 = default(FIELD_DATA_TYPE);
			do
			{
				ref string reference = ref elementTypes[num];
				ref FIELD_DATA_TYPE reference2 = ref FieldDataTypes[num];
				if (!(reference == Class16.smethod_0(1648989776)))
				{
					if (reference == Class16.smethod_0(1648989786))
					{
						fIELD_DATA_TYPE.data_type = FIELD_DATA_TYPE_ENUM.UInt;
						fIELD_DATA_TYPE.size = 4;
						reference2 = fIELD_DATA_TYPE;
					}
					else if (reference == Class16.smethod_0(1648989830))
					{
						fIELD_DATA_TYPE2.data_type = FIELD_DATA_TYPE_ENUM.Int64;
						fIELD_DATA_TYPE2.size = 8;
						reference2 = fIELD_DATA_TYPE2;
					}
					else if (reference == Class16.smethod_0(1648989834))
					{
						fIELD_DATA_TYPE3.data_type = FIELD_DATA_TYPE_ENUM.UInt64;
						fIELD_DATA_TYPE3.size = 8;
						reference2 = fIELD_DATA_TYPE3;
					}
					else if (reference == Class16.smethod_0(1648902744))
					{
						fIELD_DATA_TYPE4.data_type = FIELD_DATA_TYPE_ENUM.Float;
						fIELD_DATA_TYPE4.size = 4;
						reference2 = fIELD_DATA_TYPE4;
					}
					else if (reference == Class16.smethod_0(1648989855))
					{
						fIELD_DATA_TYPE5.data_type = FIELD_DATA_TYPE_ENUM.Double;
						fIELD_DATA_TYPE5.size = 8;
						reference2 = fIELD_DATA_TYPE5;
					}
					else if (reference[0] == 's')
					{
						fIELD_DATA_TYPE6.data_type = FIELD_DATA_TYPE_ENUM.String;
						fIELD_DATA_TYPE6.size = ACE.RSGlobal.RSGlobal.String2Int_ext(reference.Substring(7));
						reference2 = fIELD_DATA_TYPE6;
					}
					else if (reference[0] == 'w')
					{
						fIELD_DATA_TYPE7.data_type = FIELD_DATA_TYPE_ENUM.WString;
						fIELD_DATA_TYPE7.size = ACE.RSGlobal.RSGlobal.String2Int_ext(reference.Substring(8));
						reference2 = fIELD_DATA_TYPE7;
					}
					else if (reference[0] == 'b')
					{
						fIELD_DATA_TYPE8.data_type = FIELD_DATA_TYPE_ENUM.Bool;
						fIELD_DATA_TYPE8.size = ACE.RSGlobal.RSGlobal.String2Int_ext(reference.Substring(5));
						reference2 = fIELD_DATA_TYPE8;
					}
					else if (reference == Class16.smethod_0(1648989805))
					{
						fIELD_DATA_TYPE9.data_type = FIELD_DATA_TYPE_ENUM.Int16;
						fIELD_DATA_TYPE9.size = 2;
						reference2 = fIELD_DATA_TYPE9;
					}
					else if (reference == Class16.smethod_0(1648989809))
					{
						fIELD_DATA_TYPE10.data_type = FIELD_DATA_TYPE_ENUM.UInt16;
						fIELD_DATA_TYPE10.size = 2;
						reference2 = fIELD_DATA_TYPE10;
					}
					else
					{
						fIELD_DATA_TYPE11.data_type = FIELD_DATA_TYPE_ENUM.Unknown;
						fIELD_DATA_TYPE11.size = 4;
						reference2 = fIELD_DATA_TYPE11;
					}
				}
				else
				{
					fIELD_DATA_TYPE12.data_type = FIELD_DATA_TYPE_ENUM.Int;
					fIELD_DATA_TYPE12.size = 4;
					reference2 = fIELD_DATA_TYPE12;
				}
				num++;
			}
			while (num < elementTypes.Length);
		}
		GC.KeepAlive(this);
	}

	public int getid(int int_1)
	{
		if (int_1 < 0)
		{
			return -1;
		}
		if (!IdsMakingNow && IDs != null && int_1 < IDs.Count)
		{
			int result = IDs[int_1];
			GC.KeepAlive(this);
			return result;
		}
		object[][] array = elementValues;
		if (int_1 < array.Length)
		{
			object obj = array[int_1][0];
			if (obj is byte[])
			{
				byte[] array2 = (byte[])obj;
				if (array2.Length >= 4)
				{
					return BitConverter.ToInt32(array2, 0);
				}
				int num = 0;
				for (int i = 0; i < array2.Length && i < 4; i++)
				{
					num |= array2[i] << i * 8;
				}
				return num;
			}
			return Convert.ToInt32(obj);
		}
		return -1;
	}

	public int GetFieldMaxTextLength(int int_1)
	{
		FIELD_DATA_TYPE[] fieldDataTypes = FieldDataTypes;
		int num = fieldDataTypes[int_1].size;
		switch (fieldDataTypes[int_1].data_type)
		{
		case FIELD_DATA_TYPE_ENUM.Bool:
			return num * 3;
		case FIELD_DATA_TYPE_ENUM.WString:
			num /= 2;
			break;
		}
		return num - 1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsCountField(int int_1)
	{
		ref string reference = ref elementFields[int_1];
		int num = ((reference.EndsWith(Class16.smethod_0(1648961470)) || reference.Contains(Class16.smethod_0(1648961473)) || reference.Contains(Class16.smethod_0(1648961493))) ? 1 : 0);
		GC.KeepAlive(this);
		return (byte)num != 0;
	}

	public List<int> GetFields(string pattern, [MarshalAs(UnmanagedType.U1)] bool IsRegex)
	{
		List<int> list = new List<int>();
		if (IsRegex)
		{
			pattern = pattern.Replace(Class16.smethod_0(1648938114), Class16.smethod_0(1648902914));
			pattern = Class16.smethod_0(1648935659) + pattern + Class16.smethod_0(1648938114);
			int num = 0;
			if (elementTypes.Length != 0)
			{
				do
				{
					if (Regex.IsMatch(elementFields[num], pattern))
					{
						list.Add(num);
					}
					num++;
				}
				while (num < elementTypes.Length);
			}
		}
		else
		{
			int num2 = this.get_fields(pattern);
			if (num2 > -1)
			{
				list.Add(num2);
			}
		}
		GC.KeepAlive(this);
		return list;
	}

	public FIELDTYPE GetFieldType(int int_1)
	{
		if (int_1 >= 0)
		{
			FIELDTYPE[] array = fieldtypes;
			if (array != null)
			{
				return array[int_1];
			}
		}
		return FIELDTYPE.not_set;
	}
}
