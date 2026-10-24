using System;
using System.Collections.Generic;

namespace ACE.Classes;

[Serializable]
public class ACE_DATA_LIST
{
	public int ListIndex;

	public string ListName;

	public int ItemCount;

	public bool IsSubitems;

	public string[] elementFields;

	public string[] elementTypes;

	public List<object[]> elementValues;

	public Dictionary<int, string> Descriptions;

	public Dictionary<int, int> Colors;

	public List<int> IDs;

	public ACE_DATA_LIST(string ListName, string[] elementFields, string[] elementTypes)
	{
		this.ListName = ListName;
		this.elementFields = elementFields;
		this.elementTypes = elementTypes;
		elementValues = new List<object[]>();
		Descriptions = new Dictionary<int, string>();
		Colors = new Dictionary<int, int>();
		IDs = new List<int>();
	}

	public void AddItem(object[] itemValues, string description, int color)
	{
		int num = (int)((nint)itemValues.LongLength - 1);
		itemValues[num] = new object();
		elementValues.Add(itemValues);
		int num2 = (int)itemValues[0];
		IDs.Add(num2);
		if (description == null)
		{
			if (color <= -1)
			{
				goto IL_0093;
			}
		}
		else if (Descriptions.ContainsKey(num2))
		{
			Descriptions[num2] = description;
		}
		else
		{
			Descriptions.Add(num2, description);
		}
		if (color > -1)
		{
			if (Colors.ContainsKey(num2))
			{
				Colors[num2] = color;
			}
			else
			{
				Colors.Add(num2, color);
			}
		}
		goto IL_0093;
		IL_0093:
		ItemCount++;
	}
}
