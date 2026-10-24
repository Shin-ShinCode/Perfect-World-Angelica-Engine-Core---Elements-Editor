using System.Collections.Generic;

namespace ACE.NMD;

public class NmdExportResult
{
	public bool Success;

	public int NpcMineCount;

	public int DynamicCount;

	public string ErrorMessage;

	public string OutputPath;

	public List<int> FailedNpcMine = new List<int>();

	public List<int> FailedDynamic = new List<int>();

	public List<string> Errors = new List<string>();
}
