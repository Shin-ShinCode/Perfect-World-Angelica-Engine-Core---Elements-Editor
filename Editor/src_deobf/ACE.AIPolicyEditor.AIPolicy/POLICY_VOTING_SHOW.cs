using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy;

public class POLICY_VOTING_SHOW
{
	private int int_0;

	private int int_1;

	public int iSelect
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

	public int iVoteID
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

	public POLICY_VOTING_SHOW()
	{
	}

	public POLICY_VOTING_SHOW(BinaryReader br)
	{
		iVoteID = br.ReadInt32();
		iSelect = br.ReadInt32();
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(iVoteID);
		bw.Write(iSelect);
	}
}
