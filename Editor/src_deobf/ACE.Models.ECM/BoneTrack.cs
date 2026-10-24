using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ACE.Models.ECM;

public class BoneTrack
{
	private int int_0;

	private int int_1;

	private List<Vector3f> list_0 = new List<Vector3f>();

	private int int_2;

	private List<Quaternion> list_1 = new List<Quaternion>();

	public int BoneIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int NumPositionKeyframes
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public List<Vector3f> PositionTrack
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public int NumRotationKeyframes
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public List<Quaternion> RotationTrack
	{
		[CompilerGenerated]
		get
		{
			return list_1;
		}
		[CompilerGenerated]
		set
		{
			list_1 = value;
		}
	}

	public Vector3f GetPosition(int frame)
	{
		if (PositionTrack.Count == 0)
		{
			return new Vector3f(0f, 0f, 0f);
		}
		if (PositionTrack.Count == 1)
		{
			return PositionTrack[0];
		}
		frame = MathHelper.Clamp(frame, 0, PositionTrack.Count - 1);
		return PositionTrack[frame];
	}

	public Vector3f GetPositionLerp(float time, int fps)
	{
		if (PositionTrack.Count == 0)
		{
			return new Vector3f(0f, 0f, 0f);
		}
		if (PositionTrack.Count == 1)
		{
			return PositionTrack[0];
		}
		float num = time * (float)fps;
		int num2 = (int)Math.Floor(num);
		int value = num2 + 1;
		float float_ = num - (float)num2;
		num2 = MathHelper.Clamp(num2, 0, PositionTrack.Count - 1);
		value = MathHelper.Clamp(value, 0, PositionTrack.Count - 1);
		return Vector3f.Lerp(PositionTrack[num2], PositionTrack[value], float_);
	}

	public Quaternion GetRotation(int frame)
	{
		if (RotationTrack.Count == 0)
		{
			return Quaternion.Identity;
		}
		if (RotationTrack.Count == 1)
		{
			return RotationTrack[0];
		}
		frame = MathHelper.Clamp(frame, 0, RotationTrack.Count - 1);
		return RotationTrack[frame];
	}

	public Quaternion GetRotationSlerp(float time, int fps)
	{
		if (RotationTrack.Count == 0)
		{
			return Quaternion.Identity;
		}
		if (RotationTrack.Count == 1)
		{
			return RotationTrack[0];
		}
		float num = time * (float)fps;
		int num2 = (int)Math.Floor(num);
		int value = num2 + 1;
		float float_ = num - (float)num2;
		num2 = MathHelper.Clamp(num2, 0, RotationTrack.Count - 1);
		value = MathHelper.Clamp(value, 0, RotationTrack.Count - 1);
		return Quaternion.Slerp(RotationTrack[num2], RotationTrack[value], float_);
	}
}
