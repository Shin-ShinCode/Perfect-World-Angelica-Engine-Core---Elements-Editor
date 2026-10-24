using System;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

[Flags]
public enum ImageBoxPanMode
{
	None = 0,
	Left = 0x100000,
	Middle = 0x400000,
	Both = 0x500000
}
