using System.Collections.Generic;
using ACE.Classes.ACE;

namespace ACE.sTASKedit.Classes;

public class TASK_PROPS_PART
{
	public ReferenceType section;

	public Dictionary<string, int> Props;

	public List<TASKS_ITEM_ENTRY> Items;

	public float[] AwardTeleportPos;
}
