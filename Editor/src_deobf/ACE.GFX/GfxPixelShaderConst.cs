using System.Collections.Generic;

namespace ACE.GFX;

public class GfxPixelShaderConst
{
	public class GfxPSTarget
	{
		public int Interval;

		public float float_0;

		public float float_1;

		public float float_2;

		public float float_3;
	}

	public int Index;

	public float InitR;

	public float InitG;

	public float InitB;

	public float InitA;

	public int LoopCount = 1;

	public List<GfxPSTarget> Targets = new List<GfxPSTarget>();
}
