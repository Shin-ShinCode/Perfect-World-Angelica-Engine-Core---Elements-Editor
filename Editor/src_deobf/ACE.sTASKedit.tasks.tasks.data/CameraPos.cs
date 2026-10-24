using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class CameraPos
{
	private float float_0 = 1f;

	private float float_1 = 1f;

	private float float_2 = 1f;

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

	internal static void Read(int version, BinaryReader br, CameraPos CameraPos)
	{
		CameraPos.Single_0 = br.ReadSingle();
		CameraPos.Single_1 = br.ReadSingle();
		CameraPos.Single_2 = br.ReadSingle();
	}

	internal static void Write(int version, BinaryWriter bw, CameraPos CameraPos)
	{
		bw.Write(CameraPos.Single_0);
		bw.Write(CameraPos.Single_1);
		bw.Write(CameraPos.Single_2);
	}
}
