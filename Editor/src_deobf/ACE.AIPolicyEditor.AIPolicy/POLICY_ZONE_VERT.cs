using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy;

public class POLICY_ZONE_VERT
{
	private float float_0;

	private float float_1;

	private float float_2;

	public float Single_0
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
		[CompilerGenerated]
		set
		{
			float_0 = value;
		}
	}

	public float Single_1
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
		[CompilerGenerated]
		set
		{
			float_1 = value;
		}
	}

	public float Single_2
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
		[CompilerGenerated]
		set
		{
			float_2 = value;
		}
	}

	public POLICY_ZONE_VERT()
	{
	}

	public POLICY_ZONE_VERT(BinaryReader br)
	{
		Single_0 = br.ReadSingle();
		Single_1 = br.ReadSingle();
		Single_2 = br.ReadSingle();
	}

	public void Write(BinaryWriter bw)
	{
		bw.Write(Single_0);
		bw.Write(Single_1);
		bw.Write(Single_2);
	}
}
