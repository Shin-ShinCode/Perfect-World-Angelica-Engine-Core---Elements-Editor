using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

public class GZipStream : DeflateStream
{
	protected override ZLibOpenType OpenType => ZLibOpenType.GZip;

	protected override ZLibWriteType WriteType => ZLibWriteType.GZip;

	public GZipStream(Stream stream, CompressionMode mode)
		: base(stream, mode)
	{
	}

	public GZipStream(Stream stream, CompressionMode mode, bool leaveOpen)
		: base(stream, mode, leaveOpen)
	{
	}

	public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level)
		: base(stream, mode, level)
	{
	}

	public GZipStream(Stream stream, CompressionMode mode, CompressionLevel level, bool leaveOpen)
		: base(stream, mode, level, leaveOpen)
	{
	}
}
