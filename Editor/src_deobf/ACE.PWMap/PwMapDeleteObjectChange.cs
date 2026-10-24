using System;
using System.Collections.Generic;

namespace ACE.PWMap;

public sealed class PwMapDeleteObjectChange : PwMapChangeItem
{
	private readonly List<PwMapSharpDxEditorForm.ISceneObjectList> list_0;

	private readonly PwMapSharpDxEditorForm.SceneObjectSnapshot[] sceneObjectSnapshot_0;

	private readonly Action action_0;

	public PwMapDeleteObjectChange(List<PwMapSharpDxEditorForm.ISceneObjectList> targetLists, PwMapSharpDxEditorForm.SceneObjectSnapshot[] snapshots, Action rebuild)
		: base(Class16.smethod_0(1649087481) + snapshots.Length + Class16.smethod_0(1649093154))
	{
		list_0 = targetLists;
		sceneObjectSnapshot_0 = snapshots;
		action_0 = rebuild;
	}

	public override void Apply()
	{
		PwMapSharpDxEditorForm.SceneObjectSnapshot[] array = sceneObjectSnapshot_0;
		foreach (PwMapSharpDxEditorForm.SceneObjectSnapshot snap in array)
		{
			foreach (PwMapSharpDxEditorForm.ISceneObjectList item in list_0)
			{
				item.RemoveBySnapshot(snap);
			}
		}
		action_0?.Invoke();
	}

	public override void Revert()
	{
		PwMapSharpDxEditorForm.SceneObjectSnapshot[] array = sceneObjectSnapshot_0;
		foreach (PwMapSharpDxEditorForm.SceneObjectSnapshot snap in array)
		{
			foreach (PwMapSharpDxEditorForm.ISceneObjectList item in list_0)
			{
				item.AddFromSnapshot(snap);
			}
		}
		action_0?.Invoke();
	}
}
