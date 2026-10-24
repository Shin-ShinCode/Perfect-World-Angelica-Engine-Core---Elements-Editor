using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.sTASKedit.tasks.tasks.data;

public class TSMNPCServices
{
	private uint uint_0;

	private uint uint_1;

	private uint uint_2;

	private uint uint_3;

	public uint service1
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

	public uint service2
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

	public uint service3
	{
		[CompilerGenerated]
		get
		{
			return uint_2;
		}
		[CompilerGenerated]
		set
		{
			uint_2 = value;
		}
	}

	public uint service4
	{
		[CompilerGenerated]
		get
		{
			return uint_3;
		}
		[CompilerGenerated]
		set
		{
			uint_3 = value;
		}
	}

	internal static void Read(int version, BinaryReader br, TSMNPCServices tns)
	{
		tns.service1 = br.ReadUInt32();
		tns.service2 = br.ReadUInt32();
		tns.service3 = br.ReadUInt32();
		tns.service4 = br.ReadUInt32();
	}

	internal static void Write(int version, BinaryWriter bw, TSMNPCServices tns)
	{
		bw.Write(tns.service1);
		bw.Write(tns.service2);
		bw.Write(tns.service3);
		bw.Write(tns.service4);
	}
}
