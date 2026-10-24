using System.Collections.Generic;

namespace ACE.Path;

public sealed class PathDataSnapshot
{
	public string FileName;

	public bool FileChanged;

	public uint TimeStamp;

	public int Count;

	public uint LastId;

	public int ReservedFieldCount;

	public List<PathDataEntrySnapshot> Entries;
}
