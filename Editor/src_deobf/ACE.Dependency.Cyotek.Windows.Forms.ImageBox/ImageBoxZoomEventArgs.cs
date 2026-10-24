using System;
using System.Runtime.CompilerServices;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

public class ImageBoxZoomEventArgs : EventArgs
{
	private ImageBoxZoomActions imageBoxZoomActions_0;

	private int int_0;

	private int int_1;

	private ImageBoxActionSources imageBoxActionSources_0;

	public ImageBoxZoomActions Actions
	{
		[CompilerGenerated]
		get
		{
			return imageBoxZoomActions_0;
		}
		[CompilerGenerated]
		protected set
		{
			imageBoxZoomActions_0 = value;
		}
	}

	public int NewZoom
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		protected set
		{
			int_0 = value;
		}
	}

	public int OldZoom
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		protected set
		{
			int_1 = value;
		}
	}

	public ImageBoxActionSources Source
	{
		[CompilerGenerated]
		get
		{
			return imageBoxActionSources_0;
		}
		[CompilerGenerated]
		protected set
		{
			imageBoxActionSources_0 = value;
		}
	}

	public ImageBoxZoomEventArgs(ImageBoxZoomActions actions, ImageBoxActionSources source, int oldZoom, int newZoom)
		: this()
	{
		Actions = actions;
		Source = source;
		OldZoom = oldZoom;
		NewZoom = newZoom;
	}

	protected ImageBoxZoomEventArgs()
	{
	}
}
