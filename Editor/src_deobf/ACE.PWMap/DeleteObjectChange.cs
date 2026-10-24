using System;

namespace ACE.PWMap;

public sealed class DeleteObjectChange : PwMapChangeItem
{
	private readonly object object_0;

	private readonly Action<object> action_0;

	private readonly Action<object> action_1;

	public DeleteObjectChange(string desc, object target, Action<object> addAction, Action<object> removeAction)
		: base(desc)
	{
		object_0 = target;
		action_0 = addAction;
		action_1 = removeAction;
	}

	public override void Apply()
	{
		action_1?.Invoke(object_0);
	}

	public override void Revert()
	{
		action_0?.Invoke(object_0);
	}
}
