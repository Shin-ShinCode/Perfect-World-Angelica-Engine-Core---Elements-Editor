using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ACE.Models.ECM;

namespace ACE.Models;

public class ModelClass
{
	private ModelType modelType_0;

	public byte[] skyfile = new byte[0];

	public Dictionary<string, byte[]> DDSIMAGE = new Dictionary<string, byte[]>();

	private ECMModel ecmmodel_0;

	private Skeleton skeleton_0;

	private Animator animator_0;

	private List<TrackSet> list_0 = new List<TrackSet>();

	private int int_0 = -1;

	public ModelType Type
	{
		[CompilerGenerated]
		get
		{
			return modelType_0;
		}
		[CompilerGenerated]
		set
		{
			modelType_0 = value;
		}
	}

	public ECMModel ECM
	{
		[CompilerGenerated]
		get
		{
			return ecmmodel_0;
		}
		[CompilerGenerated]
		set
		{
			ecmmodel_0 = value;
		}
	}

	public Skeleton Skeleton
	{
		[CompilerGenerated]
		get
		{
			return skeleton_0;
		}
		[CompilerGenerated]
		set
		{
			skeleton_0 = value;
		}
	}

	public Animator Animator
	{
		[CompilerGenerated]
		get
		{
			return animator_0;
		}
		[CompilerGenerated]
		set
		{
			animator_0 = value;
		}
	}

	public List<TrackSet> Animations
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

	public int CurrentAnimationIndex
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

	public void PlayAnimation(int index)
	{
		if (Animator != null && index >= 0 && index < Animations.Count)
		{
			CurrentAnimationIndex = index;
			Animator.SetAnimation(Animations[index]);
		}
	}

	public void UpdateAnimation(float deltaTime)
	{
		Animator?.Update(deltaTime);
	}
}
