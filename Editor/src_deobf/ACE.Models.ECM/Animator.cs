using System.Runtime.CompilerServices;

namespace ACE.Models.ECM;

public class Animator
{
	private Skeleton skeleton_0;

	private TrackSet trackSet_0;

	private float float_0;

	private bool bool_0;

	private bool bool_1 = true;

	private Matrix4x4[] matrix4x4_0;

	private Matrix4x4[] matrix4x4_1;

	public Matrix4x4[] BoneMatrices
	{
		[CompilerGenerated]
		get
		{
			return matrix4x4_0;
		}
	}

	public Matrix4x4[] FinalBoneMatrices
	{
		[CompilerGenerated]
		get
		{
			return matrix4x4_1;
		}
	}

	public float AnimationTime => float_0;

	public bool IsPlaying => bool_0;

	public float Duration => trackSet_0?.Duration ?? 0f;

	public Animator(Skeleton skeleton)
	{
		skeleton_0 = skeleton;
		method_0(new Matrix4x4[skeleton.Bones.Count]);
		method_1(new Matrix4x4[skeleton.Bones.Count]);
		for (int i = 0; i < skeleton.Bones.Count; i++)
		{
			BoneMatrices[i] = Matrix4x4.Identity;
			FinalBoneMatrices[i] = Matrix4x4.Identity;
		}
	}

	private void method_0(Matrix4x4[] matrix4x4_2)
	{
		matrix4x4_0 = matrix4x4_2;
	}

	private void method_1(Matrix4x4[] matrix4x4_2)
	{
		matrix4x4_1 = matrix4x4_2;
	}

	public void SetAnimation(TrackSet trackSet)
	{
		trackSet_0 = trackSet;
		float_0 = 0f;
		bool_0 = true;
	}

	public void Update(float deltaTime)
	{
		if (!bool_0 || trackSet_0 == null)
		{
			return;
		}
		float_0 += deltaTime;
		if (float_0 >= trackSet_0.Duration)
		{
			if (bool_1)
			{
				float_0 %= trackSet_0.Duration;
			}
			else
			{
				float_0 = trackSet_0.Duration;
				bool_0 = false;
			}
		}
		method_2();
	}

	private void method_2()
	{
		int num = trackSet_0.AnimFPS;
		if (num <= 0)
		{
			num = 30;
		}
		foreach (Bone bone in skeleton_0.Bones)
		{
			BoneTrack track = trackSet_0.GetTrack(bone.Index);
			Matrix4x4 matrix4x;
			if (track != null && track.PositionTrack.Count > 0)
			{
				Vector3f positionLerp = track.GetPositionLerp(float_0, num);
				matrix4x = track.GetRotationSlerp(float_0, num).ToMatrix();
				matrix4x.M41 = positionLerp.float_0;
				matrix4x.M42 = positionLerp.float_1;
				matrix4x.M43 = positionLerp.float_2;
			}
			else
			{
				matrix4x = bone.RelativeMatrix;
			}
			BoneMatrices[bone.Index] = matrix4x;
		}
		foreach (Bone rootBone in skeleton_0.RootBones)
		{
			method_3(rootBone, Matrix4x4.Identity);
		}
		for (int i = 0; i < skeleton_0.Bones.Count; i++)
		{
			FinalBoneMatrices[i] = skeleton_0.Bones[i].InitialBoneMatrix * BoneMatrices[i];
		}
	}

	private void method_3(Bone bone_0, Matrix4x4 matrix4x4_2)
	{
		Matrix4x4 matrix4x = BoneMatrices[bone_0.Index] * matrix4x4_2;
		BoneMatrices[bone_0.Index] = matrix4x;
		foreach (int childBone in bone_0.ChildBones)
		{
			if (childBone >= 0 && childBone < skeleton_0.Bones.Count)
			{
				method_3(skeleton_0.Bones[childBone], matrix4x);
			}
		}
	}

	public void Play()
	{
		bool_0 = true;
	}

	public void Pause()
	{
		bool_0 = false;
	}

	public void Stop()
	{
		bool_0 = false;
		float_0 = 0f;
	}

	public void SetLoop(bool loop)
	{
		bool_1 = loop;
	}

	public void SetTime(float time)
	{
		float_0 = MathHelper.Clamp(time, 0f, Duration);
	}
}
