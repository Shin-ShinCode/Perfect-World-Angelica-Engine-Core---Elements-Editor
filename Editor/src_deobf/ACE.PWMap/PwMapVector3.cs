using System.Runtime.CompilerServices;

namespace ACE.PWMap;

public readonly struct PwMapVector3(float float_3, float float_4, float float_5)
{
	public static readonly PwMapVector3 Zero = new PwMapVector3(0f, 0f, 0f);

	private readonly float float_0 = float_3;

	private readonly float float_1 = float_4;

	private readonly float float_2 = float_5;

	public float Single_0
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
	}

	public float Single_1
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
	}

	public float Single_2
	{
		[CompilerGenerated]
		get
		{
			return float_2;
		}
	}
}
