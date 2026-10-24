using System;

namespace ACE.PWMap;

public sealed class PropertyChange<T> : PwMapChangeItem
{
	private readonly Action<T> action_0;

	private readonly T gparam_0;

	private readonly T gparam_1;

	public PropertyChange(string desc, T oldValue, T newValue, Action<T> setter)
		: base(desc)
	{
		gparam_0 = oldValue;
		gparam_1 = newValue;
		action_0 = setter;
	}

	public override void Apply()
	{
		action_0?.Invoke(gparam_1);
	}

	public override void Revert()
	{
		action_0?.Invoke(gparam_0);
	}
}
