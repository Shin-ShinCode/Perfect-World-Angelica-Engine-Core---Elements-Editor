using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class ZONE_VERT
{
	private float[] float_0 = new float[3];

	public float[] Single_0
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

	internal static void Read(int version, BinaryReader br, ZONE_VERT ZONE_VERT)
	{
		for (int i = 0; i < 3; i++)
		{
			ZONE_VERT.Single_0[i] = br.ReadSingle();
		}
	}

	internal static void Write(int version, BinaryWriter bw, ZONE_VERT ZONE_VERT)
	{
		for (int i = 0; i < 3; i++)
		{
			bw.Write(ZONE_VERT.Single_0[i]);
		}
	}
}
