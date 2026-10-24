#nullable enable annotations
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.UIEdit.Models;

namespace ACE.UIEdit;

internal sealed class PreviewItemPanel : Panel
{
	private UiControlModel? uiControlModel_0;

	private bool bool_0;

	private bool bool_1 = true;

	private Image? image_0;

	private string string_0 = string.Empty;

	private bool bool_2;

	private bool bool_3;

	private Color color_0 = Color.FromArgb(48, 48, 48);

	private bool bool_4;

	private Padding padding_0 = new Padding(0);

	private bool bool_5 = true;

	private int int_0;

	private int int_1;

	private bool bool_6;

	private Color color_1 = Color.FromArgb(180, 0, 0, 0);

	private Color color_2 = Color.White;

	private ContentAlignment contentAlignment_0 = ContentAlignment.MiddleLeft;

	public UiControlModel? Model
	{
		[CompilerGenerated]
		get
		{
			return uiControlModel_0;
		}
		[CompilerGenerated]
		set
		{
			uiControlModel_0 = value;
		}
	}

	public bool Selected
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

	public bool ShowOutline
	{
		[CompilerGenerated]
		get
		{
			return bool_1;
		}
		[CompilerGenerated]
		set
		{
			bool_1 = value;
		}
	}

	public Image? PreviewImage
	{
		[CompilerGenerated]
		get
		{
			return image_0;
		}
		[CompilerGenerated]
		set
		{
			image_0 = value;
		}
	}

	public string Caption
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

	public bool DrawCaption
	{
		[CompilerGenerated]
		get
		{
			return bool_2;
		}
		[CompilerGenerated]
		set
		{
			bool_2 = value;
		}
	}

	public bool FillFallbackBackground
	{
		[CompilerGenerated]
		get
		{
			return bool_3;
		}
		[CompilerGenerated]
		set
		{
			bool_3 = value;
		}
	}

	public Color FallbackBackgroundColor
	{
		[CompilerGenerated]
		get
		{
			return color_0;
		}
		[CompilerGenerated]
		set
		{
			color_0 = value;
		}
	}

	public bool UseNineSlice
	{
		[CompilerGenerated]
		get
		{
			return bool_4;
		}
		[CompilerGenerated]
		set
		{
			bool_4 = value;
		}
	}

	public Padding NineSlicePadding
	{
		[CompilerGenerated]
		get
		{
			return padding_0;
		}
		[CompilerGenerated]
		set
		{
			padding_0 = value;
		}
	}

	public bool CaptionWordWrap
	{
		[CompilerGenerated]
		get
		{
			return bool_5;
		}
		[CompilerGenerated]
		set
		{
			bool_5 = value;
		}
	}

	public int CaptionOffsetX
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

	public int CaptionOffsetY
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public bool OutlineEnabled
	{
		[CompilerGenerated]
		get
		{
			return bool_6;
		}
		[CompilerGenerated]
		set
		{
			bool_6 = value;
		}
	}

	public Color OutlineColor
	{
		[CompilerGenerated]
		get
		{
			return color_1;
		}
		[CompilerGenerated]
		set
		{
			color_1 = value;
		}
	}

	public Color CaptionColor
	{
		[CompilerGenerated]
		get
		{
			return color_2;
		}
		[CompilerGenerated]
		set
		{
			color_2 = value;
		}
	}

	public ContentAlignment CaptionAlignment
	{
		[CompilerGenerated]
		get
		{
			return contentAlignment_0;
		}
		[CompilerGenerated]
		set
		{
			contentAlignment_0 = value;
		}
	}

	public PreviewItemPanel()
	{
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		DoubleBuffered = true;
		base.ResizeRedraw = true;
		BackColor = Color.Transparent;
	}

	protected override void OnPaintBackground(PaintEventArgs paintEventArgs_0)
	{
		if (base.Parent is PreviewCanvasPanel previewCanvasPanel)
		{
			previewCanvasPanel.PaintBackgroundRegion(paintEventArgs_0.Graphics, new Rectangle(base.Left, base.Top, base.Width, base.Height));
		}
		else
		{
			base.OnPaintBackground(paintEventArgs_0);
		}
		if (FillFallbackBackground && PreviewImage == null)
		{
			using (Pen pen = new Pen(Color.FromArgb(60, FallbackBackgroundColor), 1f)
			{
				DashStyle = DashStyle.Dot
			})
			{
				paintEventArgs_0.Graphics.DrawRectangle(pen, 0, 0, Math.Max(0, base.Width - 1), Math.Max(0, base.Height - 1));
			}
		}
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		base.OnPaint(paintEventArgs_0);
		try
		{
			Rectangle rectangle = new Rectangle(0, 0, Math.Max(0, base.Width - 1), Math.Max(0, base.Height - 1));
			if (rectangle.Width <= 0 || rectangle.Height <= 0)
			{
				return;
			}
			if (PreviewImage != null)
			{
				paintEventArgs_0.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				paintEventArgs_0.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
				if (UseNineSlice)
				{
					PreviewCanvasPanel.DrawNineSliceImage(paintEventArgs_0.Graphics, PreviewImage, rectangle, NineSlicePadding);
				}
				else
				{
					paintEventArgs_0.Graphics.DrawImage(PreviewImage, rectangle);
				}
			}
			if (DrawCaption && !string.IsNullOrWhiteSpace(Caption))
			{
				Rectangle bounds = Rectangle.Inflate(rectangle, -3, -2);
				bounds.Offset(CaptionOffsetX, CaptionOffsetY);
				if (bounds.Width > 1 && bounds.Height > 1)
				{
					TextFormatFlags textFormatFlags = smethod_0(CaptionAlignment, CaptionWordWrap) | TextFormatFlags.NoPrefix;
					if (!CaptionWordWrap)
					{
						textFormatFlags |= TextFormatFlags.EndEllipsis;
					}
					if (OutlineEnabled)
					{
						int[,] array = new int[8, 2]
						{
							{ -1, -1 },
							{ 0, -1 },
							{ 1, -1 },
							{ -1, 0 },
							{ 1, 0 },
							{ -1, 1 },
							{ 0, 1 },
							{ 1, 1 }
						};
						for (int i = 0; i < array.GetLength(0); i++)
						{
							TextRenderer.DrawText(paintEventArgs_0.Graphics, Caption, Font, new Rectangle(bounds.X + array[i, 0], bounds.Y + array[i, 1], bounds.Width, bounds.Height), OutlineColor, textFormatFlags);
						}
					}
					else
					{
						int alpha = Math.Min(220, (int)CaptionColor.A);
						Color foreColor = Color.FromArgb(alpha, 0, 0, 0);
						TextRenderer.DrawText(paintEventArgs_0.Graphics, Caption, Font, new Rectangle(bounds.X + 1, bounds.Y + 1, bounds.Width, bounds.Height), foreColor, textFormatFlags);
					}
					TextRenderer.DrawText(paintEventArgs_0.Graphics, Caption, Font, bounds, CaptionColor, textFormatFlags);
				}
			}
			if (ShowOutline || Selected)
			{
				Color color = (Selected ? Color.FromArgb(64, 214, 137) : Color.FromArgb(100, 125, 125, 125));
				using Pen pen = new Pen(color, Selected ? 2f : 1f);
				paintEventArgs_0.Graphics.DrawRectangle(pen, 0, 0, Math.Max(0, base.Width - 1), Math.Max(0, base.Height - 1));
				return;
			}
		}
		catch
		{
		}
	}

	private static TextFormatFlags smethod_0(ContentAlignment contentAlignment_1, bool bool_7)
	{
		TextFormatFlags textFormatFlags = (bool_7 ? TextFormatFlags.WordBreak : TextFormatFlags.SingleLine);
		TextFormatFlags textFormatFlags2 = textFormatFlags;
		return (TextFormatFlags)((int)textFormatFlags2 | (contentAlignment_1 switch
		{
			ContentAlignment.MiddleCenter => 5, 
			ContentAlignment.MiddleLeft => 4, 
			ContentAlignment.TopLeft => 0, 
			ContentAlignment.TopCenter => 1, 
			ContentAlignment.TopRight => 2, 
			ContentAlignment.BottomLeft => 8, 
			ContentAlignment.MiddleRight => 6, 
			ContentAlignment.BottomRight => 10, 
			ContentAlignment.BottomCenter => 9, 
			_ => 4, 
		}));
	}
}
