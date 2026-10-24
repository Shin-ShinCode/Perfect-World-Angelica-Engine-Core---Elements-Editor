using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class TSMTargetTask
{
	private uint uint_0;

	private uint uint_1;

	public uint target1
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public uint target2
	{
		[CompilerGenerated]
		get
		{
			return uint_1;
		}
		[CompilerGenerated]
		set
		{
			uint_1 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, TSMTargetTask tts)
	{
		tts.target1 = br.ReadUInt32();
		tts.target2 = br.ReadUInt32();
	}

	internal static void Write(int version, BinaryWriter bw, TSMTargetTask tts)
	{
		bw.Write(tts.target1);
		bw.Write(tts.target2);
	}
}
