using System.Drawing;

namespace ACE.Classes.ACE;

public interface IImageResizer
{
	Bitmap Resize(int width, int height);
}
