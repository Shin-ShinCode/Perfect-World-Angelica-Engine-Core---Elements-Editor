using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

public class ImageBoxCancelEventArgs : CancelEventArgs
{
	private Point point_0;

	public Point Location
	{
		[CompilerGenerated]
		get
		{
			return point_0;
		}
		[CompilerGenerated]
		protected set
		{
			point_0 = value;
		}
	}

	public ImageBoxCancelEventArgs(Point location)
		: this()
	{
		Location = location;
	}

	protected ImageBoxCancelEventArgs()
	{
	}
}
