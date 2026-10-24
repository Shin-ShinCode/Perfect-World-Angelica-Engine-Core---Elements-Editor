using System;
using System.Collections.Generic;

namespace ACE.PWMap;

public sealed class PwMapCloneObjectChange : PwMapChangeItem
{
	private readonly List<PwMapSharpDxEditorForm.ISceneObjectList> list_0;

	private readonly PwMapSharpDxEditorForm.SceneObjectSnapshot[] sceneObjectSnapshot_0;

	private readonly Action action_0;

	public PwMapCloneObjectChange(List<PwMapSharpDxEditorForm.ISceneObjectList> targetLists, PwMapSharpDxEditorForm.SceneObjectSnapshot[] clones, Action rebuild)
		: base(Class16.smethod_0(1649093149) + clones.Length + Class16.smethod_0(1649093154))
	{
		list_0 = targetLists;
		sceneObjectSnapshot_0 = clones;
		action_0 = rebuild;
	}

	public override void Apply()
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

	public override void Revert()
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
}
