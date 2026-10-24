using ACE.Models.ECM;

namespace ACE.GFX;

public class GfxEmitterData
{
	public float EmissionRate;

	public float Angle;

	public float Speed;

	public float ParAcc;

	public Vector3f AccDir = new Vector3f(0f, 0f, -1f);

	public float Acc;

	public float TTL;

	public uint ColorMin = uint.MaxValue;

	public uint ColorMax = uint.MaxValue;

	public float ScaleMin = 1f;

	public float ScaleMax = 1f;

	public float RotMin;

	public float RotMax;

	public bool Surface;

	public bool Bind = true;

	public bool Drag;

	public float DragIntensity = 1f;

	public Vector3f ParticleInitDir;

	public bool UseHSVInterp;

	public EmitterType Type;

	public EmitterSpecificData SpecificData;

	public void Load(GfxFileReader gfxFileReader_0, uint version, GfxElementType elementType)
	{
		EmissionRate = gfxFileReader_0.ReadFloat();
		Angle = gfxFileReader_0.ReadFloat();
		Speed = gfxFileReader_0.ReadFloat();
		if (version >= 20)
		{
			ParAcc = gfxFileReader_0.ReadFloat();
		}
		(float x, float y, float z) tuple = gfxFileReader_0.ReadVector3();
		float item = tuple.x;
		float item2 = tuple.y;
		float item3 = tuple.z;
		AccDir = new Vector3f(item, item2, item3);
		Acc = gfxFileReader_0.ReadFloat();
		TTL = gfxFileReader_0.ReadFloat();
		ColorMin = gfxFileReader_0.ReadColor();
		ColorMax = gfxFileReader_0.ReadColor();
		if (version <= 1)
		{
			ScaleMin = gfxFileReader_0.ReadFloat();
			ScaleMax = ScaleMin;
		}
		else
		{
			ScaleMin = gfxFileReader_0.ReadFloat();
			ScaleMax = gfxFileReader_0.ReadFloat();
		}
		if (version >= 10)
		{
			RotMin = gfxFileReader_0.ReadFloat();
			RotMax = gfxFileReader_0.ReadFloat();
		}
		Surface = gfxFileReader_0.ReadBool();
		Bind = gfxFileReader_0.ReadBool();
		if (version >= 43)
		{
			Drag = gfxFileReader_0.ReadBool();
		}
		if (version >= 48)
		{
			DragIntensity = gfxFileReader_0.ReadFloat();
		}
		if (version >= 62)
		{
			(float x, float y, float z) tuple2 = gfxFileReader_0.ReadVector3();
			float item4 = tuple2.x;
			float item5 = tuple2.y;
			float item6 = tuple2.z;
			ParticleInitDir = new Vector3f(item4, item5, item6);
		}
		if (version >= 70)
		{
			UseHSVInterp = gfxFileReader_0.ReadBool();
		}
		SpecificData = EmitterSpecificData.LoadFromFile(gfxFileReader_0, version, elementType);
	}
}
