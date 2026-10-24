using System.Collections.Generic;

namespace ACE.Models;

public class AddonsParts
{
	public string Caption;

	public string[] IDs;

	public string[] values;

	public HashSet<int> IdsHashes = new HashSet<int>();

	public int[] realvalues;

	public string[] captions;

	public bool bFloat;

	public bool bPercent;

	public int Index;

	public AddonsParts()
	{
		bFloat = false;
		bPercent = false;
		Index = 0;
	}
}
