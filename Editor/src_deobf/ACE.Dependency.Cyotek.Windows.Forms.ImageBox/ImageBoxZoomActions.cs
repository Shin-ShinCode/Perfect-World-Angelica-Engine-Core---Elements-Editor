using System;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

[Flags]
public enum ImageBoxZoomActions
{
	None = 0,
	ZoomIn = 1,
	ZoomOut = 2,
	ActualSize = 4
}
