using System.Collections.Generic;
using ACE.Models.ECM;

namespace ACE.GFX;

public class EmitterSpecificData
{
	public float ExtentX;

	public float ExtentY;

	public float ExtentZ;

	public List<(Vector3f pos, Vector3f normal)> Planes = new List<(Vector3f, Vector3f)>();

	public List<Vector3f> CurvePoints = new List<Vector3f>();

	public static EmitterSpecificData LoadFromFile(GfxFileReader gfxFileReader_0, uint version, GfxElementType elementType)
	{
		EmitterSpecificData emitterSpecificData = new EmitterSpecificData();
		switch (elementType)
		{
		case GfxElementType.ParticleMultiPlane:
		{
			int num2 = gfxFileReader_0.ReadInt();
			for (int j = 0; j < num2; j++)
			{
				var (float_4, float_5, float_6) = gfxFileReader_0.ReadVector3();
				var (float_7, float_8, float_9) = gfxFileReader_0.ReadVector3();
				emitterSpecificData.Planes.Add((new Vector3f(float_4, float_5, float_6), new Vector3f(float_7, float_8, float_9)));
			}
			break;
		}
		case GfxElementType.ParticleEllipsoid:
		{
			(float x, float y, float z) tuple2 = gfxFileReader_0.ReadVector3();
			float item = tuple2.x;
			float item2 = tuple2.y;
			float item3 = tuple2.z;
			emitterSpecificData.ExtentX = item;
			emitterSpecificData.ExtentY = item2;
			emitterSpecificData.ExtentZ = item3;
			if (version >= 104)
			{
				gfxFileReader_0.ReadBool();
			}
			if (version >= 104)
			{
				gfxFileReader_0.ReadInt();
				gfxFileReader_0.ReadInt();
			}
			break;
		}
		case GfxElementType.ParticleBox:
		case GfxElementType.ParticleCylinder:
		{
			(float x, float y, float z) tuple3 = gfxFileReader_0.ReadVector3();
			float item4 = tuple3.x;
			float item5 = tuple3.y;
			float item6 = tuple3.z;
			emitterSpecificData.ExtentX = item4;
			emitterSpecificData.ExtentY = item5;
			emitterSpecificData.ExtentZ = item6;
			if (version >= 104)
			{
				gfxFileReader_0.ReadBool();
			}
			break;
		}
		case GfxElementType.ParticleCurve:
		{
			int num = gfxFileReader_0.ReadInt();
			for (int i = 0; i < num; i++)
			{
				var (float_, float_2, float_3) = gfxFileReader_0.ReadVector3();
				emitterSpecificData.CurvePoints.Add(new Vector3f(float_, float_2, float_3));
			}
			break;
		}
		}
		return emitterSpecificData;
	}
}
