using System;
using System.Collections.Generic;
using ACE.Models.ECM;

namespace ACE.GFX;

public class KPCtrlCurveMove : KPController
{
	public bool CalcDir;

	public List<Vector3f> Vertices = new List<Vector3f>();

	public KPCtrlCurveMove()
	{
		base.Type = KPCtrlType.CurveMove;
	}

	public override void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		if (version >= 44)
		{
			CalcDir = gfxFileReader_0.ReadBool();
		}
		int num = gfxFileReader_0.ReadInt();
		for (int i = 0; i < num; i++)
		{
			var (float_, float_2, float_3) = gfxFileReader_0.ReadVector3();
			Vertices.Add(new Vector3f(float_, float_2, float_3));
		}
	}

	public override void Process(KPProcData data, float fTimeSpan)
	{
		if (Tick(data.TimeSpan) && Vertices.Count >= 2)
		{
			float num = Math.Min(Math.Max(data.TimeSpan, 0f), 1f);
			float num2 = Vertices.Count - 1;
			float num3 = num * num2;
			int num4 = (int)num3;
			float float_ = num3 - (float)num4;
			if (num4 >= Vertices.Count - 1)
			{
				List<Vector3f> vertices = Vertices;
				data.Position = vertices[vertices.Count - 1];
			}
			else
			{
				data.Position = Vector3f.Lerp(Vertices[num4], Vertices[num4 + 1], float_);
			}
		}
	}
}
