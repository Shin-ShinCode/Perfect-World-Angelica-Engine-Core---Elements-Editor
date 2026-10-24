using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class SPECIAL_PARAMETERS
{
	private int[] int_0 = new int[0];

	private int[] int_1 = new int[0];

	private int int_2;

	private int int_3;

	private int int_4;

	private int int_5;

	private int int_6;

	private int int_7;

	private int[] int_8 = new int[0];

	private int int_9;

	private int int_10;

	private int int_11;

	private int[] int_12 = new int[0];

	private int[] int_13 = new int[0];

	private int int_14;

	private int int_15;

	private int int_16;

	public int UseItemIDsPointer;

	public int CompleteTaskIDsPointer;

	public int CompleteTaskIDsSpacePointer;

	public int[] ParameterTypes
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int[] unk176
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int FailWhenGetOffCarrier
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int TimeWhenRideCarrier
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public int GetOffCarrierID
	{
		[CompilerGenerated]
		get
		{
			return int_4;
		}
		[CompilerGenerated]
		set
		{
			int_4 = value;
		}
	}

	public int RideCarrierID
	{
		[CompilerGenerated]
		get
		{
			return int_5;
		}
		[CompilerGenerated]
		set
		{
			int_5 = value;
		}
	}

	public int UseItemTimes
	{
		[CompilerGenerated]
		get
		{
			return int_6;
		}
		[CompilerGenerated]
		set
		{
			int_6 = value;
		}
	}

	public int UseItemCount
	{
		[CompilerGenerated]
		get
		{
			return int_7;
		}
		[CompilerGenerated]
		set
		{
			int_7 = value;
		}
	}

	public int[] UseItemIDs
	{
		[CompilerGenerated]
		get
		{
			return int_8;
		}
		[CompilerGenerated]
		set
		{
			int_8 = value;
		}
	}

	public int CompleteTaskTimes
	{
		[CompilerGenerated]
		get
		{
			return int_9;
		}
		[CompilerGenerated]
		set
		{
			int_9 = value;
		}
	}

	public int CompleteTaskCount
	{
		[CompilerGenerated]
		get
		{
			return int_10;
		}
		[CompilerGenerated]
		set
		{
			int_10 = value;
		}
	}

	public int ByCompleteTask
	{
		[CompilerGenerated]
		get
		{
			return int_11;
		}
		[CompilerGenerated]
		set
		{
			int_11 = value;
		}
	}

	public int[] CompleteTaskIDs
	{
		[CompilerGenerated]
		get
		{
			return int_12;
		}
		[CompilerGenerated]
		set
		{
			int_12 = value;
		}
	}

	public int[] CompleteTaskIDsSpace
	{
		[CompilerGenerated]
		get
		{
			return int_13;
		}
		[CompilerGenerated]
		set
		{
			int_13 = value;
		}
	}

	public int Parameter9
	{
		[CompilerGenerated]
		get
		{
			return int_14;
		}
		[CompilerGenerated]
		set
		{
			int_14 = value;
		}
	}

	public int need_story_book_collection
	{
		[CompilerGenerated]
		get
		{
			return int_15;
		}
		[CompilerGenerated]
		set
		{
			int_15 = value;
		}
	}

	public int story_book_collection_count
	{
		[CompilerGenerated]
		get
		{
			return int_16;
		}
		[CompilerGenerated]
		set
		{
			int_16 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, int ParametersCount, SPECIAL_PARAMETERS SP, int m_ID)
	{
		SP.ParameterTypes = new int[ParametersCount];
		SP.unk176 = new int[ParametersCount];
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < ParametersCount; i++)
		{
			SP.ParameterTypes[i] = br.ReadInt32();
			switch (SP.ParameterTypes[i])
			{
			case 0:
				SP.FailWhenGetOffCarrier = br.ReadInt32();
				break;
			case 1:
				SP.TimeWhenRideCarrier = br.ReadInt32();
				break;
			case 2:
				SP.UseItemTimes = br.ReadInt32();
				break;
			case 3:
				SP.UseItemCount = br.ReadInt32();
				num = SP.UseItemCount;
				break;
			case 4:
				SP.UseItemIDsPointer = br.ReadInt32();
				break;
			case 5:
				SP.CompleteTaskTimes = br.ReadInt32();
				break;
			case 6:
				SP.CompleteTaskCount = br.ReadInt32();
				num2 = SP.CompleteTaskCount;
				break;
			case 7:
				SP.CompleteTaskIDsPointer = br.ReadInt32();
				break;
			case 8:
				SP.ByCompleteTask = br.ReadInt32();
				break;
			case 9:
				SP.Parameter9 = br.ReadInt32();
				break;
			case 10:
				SP.GetOffCarrierID = br.ReadInt32();
				break;
			case 11:
				SP.RideCarrierID = br.ReadInt32();
				break;
			case 12:
				SP.need_story_book_collection = br.ReadInt32();
				break;
			case 13:
				SP.story_book_collection_count = br.ReadInt32();
				break;
			case 14:
				SP.CompleteTaskIDsSpacePointer = br.ReadInt32();
				break;
			}
			if (version >= 176)
			{
				SP.unk176[i] = br.ReadInt32();
			}
		}
		if (num > 0)
		{
			SP.UseItemIDs = new int[num];
			for (int j = 0; j < num; j++)
			{
				SP.UseItemIDs[j] = br.ReadInt32();
			}
		}
		if (num2 <= 0)
		{
			return;
		}
		SP.CompleteTaskIDs = new int[num2];
		SP.CompleteTaskIDsSpace = new int[num2];
		for (int k = 0; k < num2; k++)
		{
			SP.CompleteTaskIDs[k] = br.ReadInt32();
		}
		if (version >= 153)
		{
			for (int l = 0; l < num2; l++)
			{
				SP.CompleteTaskIDsSpace[l] = br.ReadInt32();
			}
		}
	}

	internal static void Write(int version, BinaryWriter bw, int ParametersCount, SPECIAL_PARAMETERS SP, int m_ID)
	{
		for (int i = 0; i < ParametersCount; i++)
		{
			bw.Write(SP.ParameterTypes[i]);
			switch (SP.ParameterTypes[i])
			{
			case 0:
				bw.Write(SP.FailWhenGetOffCarrier);
				break;
			case 1:
				bw.Write(SP.TimeWhenRideCarrier);
				break;
			case 2:
				bw.Write(SP.UseItemTimes);
				break;
			case 3:
				bw.Write(SP.UseItemCount);
				break;
			case 4:
				bw.Write(SP.UseItemIDsPointer);
				break;
			case 5:
				bw.Write(SP.CompleteTaskTimes);
				break;
			case 6:
				bw.Write(SP.CompleteTaskCount);
				break;
			case 7:
				bw.Write(SP.CompleteTaskIDsPointer);
				break;
			case 8:
				bw.Write(SP.ByCompleteTask);
				break;
			case 9:
				bw.Write(SP.Parameter9);
				break;
			case 10:
				bw.Write(SP.GetOffCarrierID);
				break;
			case 11:
				bw.Write(SP.RideCarrierID);
				break;
			case 12:
				bw.Write(SP.need_story_book_collection);
				break;
			case 13:
				bw.Write(SP.story_book_collection_count);
				break;
			case 14:
				bw.Write(SP.CompleteTaskIDsSpacePointer);
				break;
			}
			if (version >= 176)
			{
				bw.Write(SP.unk176[i]);
			}
		}
		if (SP.UseItemIDs != null && SP.UseItemIDs.Length != 0)
		{
			for (int j = 0; j < SP.UseItemIDs.Length; j++)
			{
				bw.Write(SP.UseItemIDs[j]);
			}
		}
		if (SP.CompleteTaskIDs == null || SP.CompleteTaskIDs.Length == 0)
		{
			return;
		}
		for (int k = 0; k < SP.CompleteTaskIDs.Length; k++)
		{
			bw.Write(SP.CompleteTaskIDs[k]);
		}
		if (version >= 153 && SP.CompleteTaskIDsSpace != null && SP.CompleteTaskIDsSpace.Length != 0)
		{
			for (int l = 0; l < SP.CompleteTaskIDsSpace.Length; l++)
			{
				bw.Write(SP.CompleteTaskIDsSpace[l]);
			}
		}
	}

	public static bool CheckParameter(int version, int Type)
	{
		if (Type == 12 && version < 147)
		{
			return false;
		}
		if (Type == 13 && version < 147)
		{
			return false;
		}
		if (Type == 14 && version < 153)
		{
			return false;
		}
		return true;
	}
}
