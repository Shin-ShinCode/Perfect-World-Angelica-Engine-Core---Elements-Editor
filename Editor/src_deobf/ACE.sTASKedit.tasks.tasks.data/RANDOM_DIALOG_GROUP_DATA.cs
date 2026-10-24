using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class RANDOM_DIALOG_GROUP_DATA
{
	private List<short[]> list_0 = new List<short[]>();

	public List<short[]> TextGroups
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, int group_num, int num_per_group, RANDOM_DIALOG_GROUP_DATA randomDialogGroupData)
	{
		randomDialogGroupData.TextGroups.Clear();
		for (int i = 0; i < group_num; i++)
		{
			for (int j = 0; j < num_per_group; j++)
			{
				short[] item = GlobalFunctions.ReadNameChars(100, br);
				randomDialogGroupData.TextGroups.Add(item);
			}
		}
	}

	internal static void Write(int version, BinaryWriter bw, int group_num, int num_per_group, RANDOM_DIALOG_GROUP_DATA randomDialogGroupData)
	{
		for (int i = 0; i < group_num; i++)
		{
			for (int j = 0; j < num_per_group; j++)
			{
				int num = i * num_per_group + j;
				if (num < randomDialogGroupData.TextGroups.Count)
				{
					GlobalFunctions.WriteNameChars(bw, randomDialogGroupData.TextGroups[num]);
				}
			}
		}
	}
}
