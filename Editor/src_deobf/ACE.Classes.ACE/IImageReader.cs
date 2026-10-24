#nullable enable annotations
using System.Drawing;
using System.IO;

namespace ACE.Classes.ACE;

public interface IImageReader
{
	Bitmap ReadDds(Stream stream);

	Bitmap ReadTga(Stream stream);

	bool TryReadShopIcon(Stream stream, int checkWith, out Bitmap? result);
}
