using System;
using System.Collections.Generic;
using ACE.Classes;
using ACE.Models;

namespace ACE.ActionHistory;

[Serializable]
public class HISTORYSTAGE
{
	public uint stage_id;

	public int CaptionIndex;

	public object[] CaptionVars;

	public string CustomCaption;

	public string Description;

	public string CachedCaption;

	public int CaptionLang;

	public string BackupFileName;

	public AH_ACTIONS action;

	public int int_0;

	public int[] fieldsindices;

	public int[] itemsindices;

	private ITEMS_COLLECTION _items;

	public object[][] values_old;

	public object[][] values_new;

	public int[] listsindices;

	public int[] IDs;

	public int[] colors_old;

	public string[] descriptions_old;

	public int color_new;

	public string[] descriptions_new;

	[NonSerialized]
	public bool IsRedo;

	public bool IsMoveItems;

	public int[] selecteditems_before;

	public int[] selecteditems_after;

	public int l_before;

	public int l_after;

	[NonSerialized]
	public List<HISTORYSTAGE> SubStages;

	public bool IsSubStage;

	public int SubStageIndex = -1;

	public int UserIndex;

	public uint TimeStamp;

	public bool IsElementsSnapshot;

	public HashSet<uint> SavedTimeStamps;

	public ITEMS_COLLECTION Items
	{
		get
		{
			if (_items == null)
			{
				int[] array = itemsindices;
				if (array != null)
				{
					ITEMS_COLLECTION iTEMS_COLLECTION = (_items = new ITEMS_COLLECTION(int_0, array));
					int[] array2 = fieldsindices;
					if (array2 != null)
					{
						iTEMS_COLLECTION.SetFields(array2);
					}
				}
			}
			GC.KeepAlive(this);
			return _items;
		}
		set
		{
			_items = value;
		}
	}

	public HISTORYSTAGE(AH_ACTIONS StageAction)
	{
		action = StageAction;
		if (StageAction == (AH_ACTIONS)8)
		{
			SubStages = new List<HISTORYSTAGE>(8);
		}
	}

	public string GetStageUndoFileName()
	{
		uint timeStamp = TimeStamp;
		uint num = stage_id;
		string text = Class16.smethod_0(1648923956);
		string text2 = Class16.smethod_0(1648923968);
		string result = string.Concat(string.Concat(num + text2, timeStamp.ToString()), text);
		GC.KeepAlive(this);
		return result;
	}

	public string GetStageRedoFileName()
	{
		uint timeStamp = TimeStamp;
		uint num = stage_id;
		string text = Class16.smethod_0(1648923976);
		string text2 = Class16.smethod_0(1648923968);
		string result = string.Concat(string.Concat(num + text2, timeStamp.ToString()), text);
		GC.KeepAlive(this);
		return result;
	}

	public string GetSubStagesFileName()
	{
		uint timeStamp = TimeStamp;
		uint num = stage_id;
		string text = Class16.smethod_0(1648924004);
		string text2 = Class16.smethod_0(1648923968);
		string result = string.Concat(string.Concat(num + text2, timeStamp.ToString()), text);
		GC.KeepAlive(this);
		return result;
	}
}
