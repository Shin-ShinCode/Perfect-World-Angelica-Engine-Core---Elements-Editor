using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

public class ZLibStream : DeflateStream
{
	protected override ZLibOpenType OpenType => ZLibOpenType.ZLib;

	protected override ZLibWriteType WriteType => ZLibWriteType.ZLib;

	public ZLibStream(Stream stream, CompressionMode mode)
		: base(stream, mode)
	{
	}

	public ZLibStream(Stream stream, CompressionMode mode, bool leaveOpen)
		: base(stream, mode, leaveOpen)
	{
	}

	public ZLibStream(Stream stream, CompressionMode mode, CompressionLevel level)
		: base(stream, mode, level)
	{
	}

	public ZLibStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		: base(stream, mode, level, leaveOpen)
	{
	}
}
