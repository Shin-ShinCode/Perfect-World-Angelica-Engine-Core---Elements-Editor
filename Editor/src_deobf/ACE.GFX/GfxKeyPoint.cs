using System.Collections.Generic;
using ACE.Models.ECM;

namespace ACE.GFX;

public class GfxKeyPoint
{
	public KPInterpolateMode Mode;

	public uint TimeSpan;

	public KeyPointOrg Org;

	public List<KPController> Controllers = new List<KPController>();

	public bool IsInfinite
	{
		get
		{
			if (TimeSpan != uint.MaxValue)
			{
				return TimeSpan == 0;
			}
			return true;
		}
	}

	public void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		Mode = (KPInterpolateMode)gfxFileReader_0.ReadInt();
		TimeSpan = (uint)gfxFileReader_0.ReadInt();
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		Org.Position = new Vector3f(item, item2, item3);
		Org.Color = gfxFileReader_0.ReadColor();
		Org.Scale = gfxFileReader_0.ReadFloat();
		(float x, float y, float z, float w) tuple2 = gfxFileReader_0.ReadVector4();
		float item4 = tuple2.x;
		float item5 = tuple2.y;
		float item6 = tuple2.z;
		float item7 = tuple2.w;
		Org.Direction = GfxMath.NormalizeQuat(new Quaternion(item4, item5, item6, item7));
		Org.Rad2D = gfxFileReader_0.ReadFloat();
		int num = gfxFileReader_0.ReadInt();
		for (int i = 0; i < num; i++)
		{
			KPController kPController = KPController.LoadFromFile(gfxFileReader_0, version);
			if (kPController != null)
			{
				Controllers.Add(kPController);
			}
		}
	}

	public void Process(KPProcData data, float fTimeSpan)
	{
		float fTimeSpan2 = fTimeSpan / 1000f;
		foreach (KPController controller in Controllers)
		{
			controller.Process(data, fTimeSpan2);
		}
	}
}
