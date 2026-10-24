using ACE.Dependency.zlibnet.zlib;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace ACE.RSGlobal;

public class ZlibHelpers
{
	public static byte[] CompressDataZlib(byte[] data)
	{
		return DeflateCompressor.CompressZlib(data);
	}

	public static byte[] Uncompress_SharpZipLib(byte[] packed, int resultSize)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		Inflater val = new Inflater(false);
		val.SetInput(packed);
		byte[] array = new byte[resultSize];
		val.Inflate(array);
		return array;
	}
}
