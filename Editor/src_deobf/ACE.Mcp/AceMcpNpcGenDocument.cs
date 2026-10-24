using System;
using System.Runtime.CompilerServices;
using ACE.NpcGen.Classes;

namespace ACE.Mcp;

internal sealed class AceMcpNpcGenDocument
{
	private string string_0;

	private DateTime dateTime_0;

	private bool bool_0;

	private ACE.NpcGen.Classes.NpcGen npcGen_0;

	public string FileName
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

	public DateTime TimeChange
	{
		[CompilerGenerated]
		get
		{
			return dateTime_0;
		}
		[CompilerGenerated]
		set
		{
			dateTime_0 = value;
		}
	}

	public bool FileChanged
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public ACE.NpcGen.Classes.NpcGen Data
	{
		[CompilerGenerated]
		get
		{
			return npcGen_0;
		}
		[CompilerGenerated]
		set
		{
			npcGen_0 = value;
		}
	}
}
