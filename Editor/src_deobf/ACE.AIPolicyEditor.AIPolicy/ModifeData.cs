using System.Runtime.CompilerServices;

namespace ACE.AIPolicyEditor.AIPolicy;

public class ModifeData
{
	private long long_0;

	private byte[] byte_0;

	public long Address
	{
		[CompilerGenerated]
		get
		{
			return long_0;
		}
		[CompilerGenerated]
		set
		{
			long_0 = value;
		}
	}

	public byte[] Bytes
	{
		[CompilerGenerated]
		get
		{
			return byte_0;
		}
		[CompilerGenerated]
		set
		{
			byte_0 = value;
		}
	}
}
