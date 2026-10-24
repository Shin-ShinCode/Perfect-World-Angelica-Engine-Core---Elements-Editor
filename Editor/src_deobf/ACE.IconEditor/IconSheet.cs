using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;

namespace ACE.IconEditor;

public sealed class IconSheet
{
	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private Bitmap bitmap_0;

	private int int_0 = 32;

	private List<IconEntry> list_0 = new List<IconEntry>();

	private bool bool_0;

	private string[] string_2 = Array.Empty<string>();

	public string DdsPath
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public string TxtPath
	{
		[CompilerGenerated]
		get
		{
			return string_1;
		}
		[CompilerGenerated]
		set
		{
			string_1 = value;
		}
	}

	public Bitmap Image
	{
		[CompilerGenerated]
		get
		{
			return bitmap_0;
		}
		[CompilerGenerated]
		set
		{
			bitmap_0 = value;
		}
	}

	public int IconSize
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public List<IconEntry> Entries
	{
		[CompilerGenerated]
		get
		{
			return list_0;
		}
		[CompilerGenerated]
		set
		{
			list_0 = value;
		}
	}

	public bool IsIconListFormat
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
		[CompilerGenerated]
		set
		{
			bool_0 = value;
		}
	}

	public string[] IconListHeaderLines
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		[CompilerGenerated]
		set
		{
			string_2 = value;
		}
	}

	public int Width => Image?.Width ?? 0;

	public int Height => Image?.Height ?? 0;

	public int Columns
	{
		get
		{
			if (IconSize <= 0)
			{
				return 0;
			}
			return Width / IconSize;
		}
	}

	public int Rows
	{
		get
		{
			if (IconSize <= 0)
			{
				return 0;
			}
			return Height / IconSize;
		}
	}

	public int TotalFrames => Columns * Rows;

	public Point GetFramePosition(int frameIndex)
	{
		if (Columns <= 0)
		{
			return Point.Empty;
		}
		int num = frameIndex / Columns;
		int num2 = frameIndex % Columns;
		return new Point(num2 * IconSize, num * IconSize);
	}

	public Bitmap GetFrame(int frameIndex)
	{
		if (Image != null && IconSize > 0)
		{
			Point framePosition = GetFramePosition(frameIndex);
			if (framePosition.X >= 0 && framePosition.Y >= 0 && framePosition.X + IconSize <= Width && framePosition.Y + IconSize <= Height)
			{
				Bitmap bitmap = new Bitmap(IconSize, IconSize, PixelFormat.Format32bppArgb);
				using Graphics graphics = Graphics.FromImage(bitmap);
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
				graphics.PixelOffsetMode = PixelOffsetMode.Half;
				graphics.DrawImage(Image, new Rectangle(0, 0, IconSize, IconSize), new Rectangle(framePosition.X, framePosition.Y, IconSize, IconSize), GraphicsUnit.Pixel);
				return bitmap;
			}
			return null;
		}
		return null;
	}
}
