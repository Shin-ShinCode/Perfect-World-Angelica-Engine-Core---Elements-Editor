using System;
using System.Collections.Generic;
using System.Reflection;

namespace ACE.PWMap;

public sealed class SkyboxChange : PwMapChangeItem
{
	private readonly PwMapBoxArea pwMapBoxArea_0;

	private readonly Dictionary<string, object> dictionary_0;

	private readonly Dictionary<string, object> dictionary_1;

	private readonly Action<PwMapBoxArea> action_0;

	public SkyboxChange(PwMapBoxArea area, Dictionary<string, object> oldValues, Dictionary<string, object> newValues, Action<PwMapBoxArea> refreshAction)
		: base(Class16.smethod_0(1649203657))
	{
		pwMapBoxArea_0 = area;
		dictionary_0 = oldValues;
		dictionary_1 = newValues;
		action_0 = refreshAction;
	}

	public override void Apply()
	{
		method_0(dictionary_1);
		action_0?.Invoke(pwMapBoxArea_0);
	}

	public override void Revert()
	{
		method_0(dictionary_0);
		action_0?.Invoke(pwMapBoxArea_0);
	}

	private void method_0(Dictionary<string, object> dictionary_2)
	{
		if (pwMapBoxArea_0 == null || dictionary_2 == null)
		{
			return;
		}
		Type type = pwMapBoxArea_0.GetType();
		foreach (KeyValuePair<string, object> item in dictionary_2)
		{
			type.GetField(item.Key, BindingFlags.Instance | BindingFlags.Public)?.SetValue(pwMapBoxArea_0, item.Value);
		}
	}
}
