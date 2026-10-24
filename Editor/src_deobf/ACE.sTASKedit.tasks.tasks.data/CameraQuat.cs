using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class CameraQuat
{
	private float float_0 = 1f;

	private float float_1 = 1f;

	private float float_2 = 1f;

	private float float_3 = 1f;

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

	public float Single_3
	{
		[CompilerGenerated]
		get
		{
			return float_3;
		}
		[CompilerGenerated]
		set
		{
			float_3 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, CameraQuat CQ)
	{
		CQ.Single_0 = br.ReadSingle();
		CQ.Single_1 = br.ReadSingle();
		CQ.Single_2 = br.ReadSingle();
		CQ.Single_3 = br.ReadSingle();
	}

	internal static void Write(int version, BinaryWriter bw, CameraQuat CQ)
	{
		bw.Write(CQ.Single_0);
		bw.Write(CQ.Single_1);
		bw.Write(CQ.Single_2);
		bw.Write(CQ.Single_3);
	}
}
