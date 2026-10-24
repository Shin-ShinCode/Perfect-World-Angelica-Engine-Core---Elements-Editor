using System;
using System.Runtime.CompilerServices;

namespace ACE.PWMap;

public sealed class TransformChange : PwMapChangeItem
{
	private readonly object object_0;

	private readonly float[] float_0;

	private readonly float[] float_1;

	private readonly Action<object, float[]> action_0;

	public object Target
	{
		[CompilerGenerated]
		get
		{
			return object_0;
		}
	}

	public float[] OldValues
	{
		[CompilerGenerated]
		get
		{
			return float_0;
		}
	}

	public float[] NewValues
	{
		[CompilerGenerated]
		get
		{
			return float_1;
		}
	}

	public TransformChange(string desc, object target, float[] oldVals, float[] newVals, Action<object, float[]> applyAction)
		: base(desc)
	{
		object_0 = target;
		float_0 = oldVals;
		float_1 = newVals;
		action_0 = applyAction;
	}

	public override void Apply()
	{
		action_0?.Invoke(Target, NewValues);
	}

	public override void Revert()
	{
		action_0?.Invoke(Target, OldValues);
	}
}
