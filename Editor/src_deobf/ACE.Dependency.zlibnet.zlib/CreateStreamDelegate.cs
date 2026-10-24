using System.IO;
using ACE.Dependency.zlibnet.Minizip;

namespace ACE.Dependency.zlibnet.zlib;

internal delegate DeflateStream CreateStreamDelegate(Stream stream_0, CompressionMode cm, bool leaveOpen);
