using System.Collections.Generic;
using ACE.Models.ECM;

namespace ACE.GFX;

public class GfxKeyPointSet
{
	public uint TimeStart;

	public int RepeatCount = 1;

	public uint RepeatDelay;

	public List<GfxKeyPoint> KeyPoints = new List<GfxKeyPoint>();

	private int int_0;

	private uint uint_0;

	private int int_1 = -1;

	private bool bool_0;

	private bool bool_1;

	private uint uint_1;

	private KPProcData kpprocData_0 = new KPProcData();

	public int ActKeyPoint => int_1;

	public bool IsFinished => bool_0;

	public KPProcData ProcData => kpprocData_0;

	public void Load(GfxFileReader gfxFileReader_0, uint version)
	{
		TimeStart = (uint)gfxFileReader_0.ReadInt();
		int num = gfxFileReader_0.ReadInt();
		for (int i = 0; i < num; i++)
		{
			GfxKeyPoint gfxKeyPoint = new GfxKeyPoint();
			gfxKeyPoint.Load(gfxFileReader_0, version);
			KeyPoints.Add(gfxKeyPoint);
		}
	}

	public void Resume(bool checkRepeat = false)
	{
		if (checkRepeat)
		{
			int_0++;
			if (RepeatCount > 0 && int_0 >= RepeatCount)
			{
				bool_0 = true;
				return;
			}
			if (RepeatDelay != 0)
			{
				bool_1 = true;
			}
		}
		uint_0 = 0u;
		int_1 = -1;
		if (KeyPoints.Count > 0)
		{
			kpprocData_0.Position = KeyPoints[0].Org.Position;
			kpprocData_0.Direction = KeyPoints[0].Org.Direction;
			kpprocData_0.Color = KeyPoints[0].Org.Color;
			kpprocData_0.Scale = KeyPoints[0].Org.Scale;
			kpprocData_0.Rad2D = KeyPoints[0].Org.Rad2D;
		}
		kpprocData_0.AxisOff = GfxMath.Zero;
		kpprocData_0.ScaleNoise = 0f;
		foreach (GfxKeyPoint keyPoint in KeyPoints)
		{
			foreach (KPController controller in keyPoint.Controllers)
			{
				controller.Resume();
			}
		}
	}

	public void Start()
	{
		int_0 = 0;
		bool_0 = false;
		bool_1 = false;
		uint_1 = 0u;
		Resume();
	}

	public void TickAnimation(uint dwTickTime)
	{
		if (bool_0)
		{
			return;
		}
		if (KeyPoints.Count == 0)
		{
			bool_0 = true;
			return;
		}
		if (bool_1)
		{
			uint_1 += dwTickTime;
			if (uint_1 < RepeatDelay)
			{
				return;
			}
			uint_1 = 0u;
			bool_1 = false;
		}
		uint_0 += dwTickTime;
		if (uint_0 < TimeStart)
		{
			return;
		}
		uint num = uint_0 - TimeStart;
		uint num2 = 0u;
		int i;
		for (i = 0; i < KeyPoints.Count && !KeyPoints[i].IsInfinite; i++)
		{
			uint timeSpan = KeyPoints[i].TimeSpan;
			if (num < timeSpan)
			{
				break;
			}
			num -= timeSpan;
			num2 += timeSpan;
		}
		if (i == KeyPoints.Count)
		{
			Resume(checkRepeat: true);
			if (num2 != 0)
			{
				TickAnimation(num % num2);
			}
		}
		else if (KeyPoints[i].Mode != KPInterpolateMode.None)
		{
			int_1 = i;
			kpprocData_0.TimeSpan = (float)num / 1000f;
			if (i == KeyPoints.Count - 1)
			{
				kpprocData_0.Position = KeyPoints[i].Org.Position;
				kpprocData_0.Direction = KeyPoints[i].Org.Direction;
				kpprocData_0.Color = KeyPoints[i].Org.Color;
				kpprocData_0.Scale = KeyPoints[i].Org.Scale;
				kpprocData_0.Rad2D = KeyPoints[i].Org.Rad2D;
			}
			else
			{
				float float_ = ((KeyPoints[i].TimeSpan != 0) ? ((float)num / (float)KeyPoints[i].TimeSpan) : 1f);
				method_0(i, float_);
			}
		}
		else
		{
			if (int_1 != i)
			{
				int_1 = i;
			}
			kpprocData_0.TimeSpan = (float)num / 1000f;
			KeyPoints[i].Process(kpprocData_0, dwTickTime);
		}
	}

	private void method_0(int int_2, float float_0)
	{
		KeyPointOrg org = KeyPoints[int_2].Org;
		KeyPointOrg org2 = KeyPoints[int_2 + 1].Org;
		float num = 1f - float_0;
		kpprocData_0.Color = GfxColor.Lerp(new GfxColor(org.Color), new GfxColor(org2.Color), float_0).Value;
		kpprocData_0.Rad2D = org2.Rad2D * float_0 + org.Rad2D * num;
		kpprocData_0.Scale = org2.Scale * float_0 + org.Scale * num;
		kpprocData_0.Position = Vector3f.Lerp(org.Position, org2.Position, float_0);
		if (KeyPoints[int_2].Mode == KPInterpolateMode.All)
		{
			kpprocData_0.Direction = GfxMath.Slerp(org.Direction, org2.Direction, float_0);
		}
	}
}
