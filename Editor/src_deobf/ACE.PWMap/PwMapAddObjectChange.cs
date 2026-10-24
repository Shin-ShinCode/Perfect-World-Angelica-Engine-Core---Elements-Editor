using System;
using System.Collections.Generic;

namespace ACE.PWMap;

public sealed class PwMapAddObjectChange : PwMapChangeItem
{
	private readonly List<PwMapSharpDxEditorForm.ISceneObjectList> list_0;

	private readonly PwMapSharpDxEditorForm.SceneObjectSnapshot sceneObjectSnapshot_0;

	private readonly Action action_0;

	public PwMapAddObjectChange(List<PwMapSharpDxEditorForm.ISceneObjectList> targetLists, PwMapSharpDxEditorForm.SceneObjectSnapshot snapshot, Action rebuild)
		: base(Class16.smethod_0(1649091015) + snapshot.Label)
	{
		list_0 = targetLists;
		sceneObjectSnapshot_0 = snapshot;
		action_0 = rebuild;
	}

	public override void Apply()
	{
		foreach (PwMapSharpDxEditorForm.ISceneObjectList item in list_0)
		{
			item.AddFromSnapshot(sceneObjectSnapshot_0);
		}
		action_0?.Invoke();
	}

	public override void Revert()
	{
		foreach (PwMapSharpDxEditorForm.ISceneObjectList item in list_0)
		{
			item.RemoveBySnapshot(sceneObjectSnapshot_0);
		}
		action_0?.Invoke();
	}
}
