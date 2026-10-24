using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ACE.BonFileEditor;

public class ClientWindow
{
	private string string_0;

	private int int_0;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int ProcessId
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public Process Process => Process.GetProcessById(ProcessId);

	public ClientWindow(string name, int process_id)
	{
		Name = name;
		ProcessId = process_id;
	}

	public override string ToString()
	{
		return Name;
	}
}
