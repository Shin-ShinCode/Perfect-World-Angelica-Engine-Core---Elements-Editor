using System.Collections.Generic;
using ACE.Classes;

namespace ACE.Models;

public class ModelExportItem
{
	public int Id;

	public string Name;

	public string ModelPath;

	public ItemType ListType;

	public int ListIndex;

	public int ElementIndex;

	public List<string> CollectedFiles = new List<string>();
}
