using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

[ToolboxBitmap(typeof(ImageBox), "ImageBox.bmp")]
[ToolboxItem(true)]
[DefaultProperty("Image")]
public class ImageBox : VirtualScrollableControl
{
	private static readonly object object_0 = new object();

	private static readonly object object_1 = new object();

	private static readonly object object_2 = new object();

	private static readonly object object_3 = new object();

	private static readonly object object_4 = new object();

	private static readonly object object_5 = new object();

	private static readonly object object_6 = new object();

	private static readonly object object_7 = new object();

	private static readonly object object_8 = new object();

	private static readonly object object_9 = new object();

	private static readonly object object_10 = new object();

	private static readonly object object_11 = new object();

	private static readonly object object_12 = new object();

	private static readonly object object_13 = new object();

	private static readonly object object_14 = new object();

	private static readonly object object_15 = new object();

	private static readonly object object_16 = new object();

	private static readonly object object_17 = new object();

	private static readonly object object_18 = new object();

	private static readonly object object_19 = new object();

	private static readonly object object_20 = new object();

	private static readonly object object_21 = new object();

	private static readonly object object_22 = new object();

	private static readonly object object_23 = new object();

	private static readonly object object_24 = new object();

	private static readonly object object_25 = new object();

	private static readonly object object_26 = new object();

	private static readonly object object_27 = new object();

	private static readonly object object_28 = new object();

	private static readonly object object_29 = new object();

	private static readonly object object_30 = new object();

	private static readonly object object_31 = new object();

	private static readonly object object_32 = new object();

	private static readonly object object_33 = new object();

	private static readonly object object_34 = new object();

	private static readonly object object_35 = new object();

	private static readonly object object_36 = new object();

	private static readonly object object_37 = new object();

	private static readonly object object_38 = new object();

	private static readonly object object_39 = new object();

	private static readonly object object_40 = new object();

	private static readonly object object_41 = new object();

	private static readonly object object_42 = new object();

	private static readonly object object_43 = new object();

	private static readonly object object_44 = new object();

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private Cursor cursor_0;

	private int int_0;

	private Timer timer_0;

	private int int_1;

	private Color color_0;

	private Color color_1;

	private ImageBoxGridDisplayMode imageBoxGridDisplayMode_0;

	private ImageBoxGridScale imageBoxGridScale_0;

	private Bitmap bitmap_0;

	private Image image_0;

	private Color color_2;

	private ImageBoxBorderStyle imageBoxBorderStyle_0;

	private InterpolationMode interpolationMode_0;

	private bool bool_10;

	private bool bool_11;

	private double double_0;

	private ImageBoxMouseWheelMode imageBoxMouseWheelMode_0;

	private ImageBoxPanMode imageBoxPanMode_0;

	private ImageBoxPanStyle imageBoxPanStyle_0;

	private Color color_3;

	private int int_2;

	private bool bool_12;

	private Color color_4;

	private ImageBoxSelectionMode imageBoxSelectionMode_0;

	private RectangleF rectangleF_0;

	private bool bool_13;

	private bool bool_14;

	private ImageBoxSizeMode imageBoxSizeMode_0;

	private Point point_1;

	private Point point_2;

	private ContentAlignment contentAlignment_0;

	private Color color_5;

	private ImageBoxGridDisplayMode imageBoxGridDisplayMode_1;

	private Padding padding_0;

	private Brush brush_0;

	private int int_3;

	private bool bool_15;

	private Size size_5;

	private int int_4;

	private ZoomLevelCollection zoomLevelCollection_0;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private static Cursor cursor_1;

	private static Bitmap bitmap_1;

	[Category("Behavior")]
	[DefaultValue(false)]
	public virtual bool AllowClickZoom
	{
		get
		{
			return bool_4;
		}
		set
		{
			if (bool_4 != value)
			{
				bool_4 = value;
				OnAllowClickZoomChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	public virtual bool AllowDoubleClick
	{
		get
		{
			return bool_5;
		}
		set
		{
			if (AllowDoubleClick != value)
			{
				bool_5 = value;
				OnAllowDoubleClickChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	[Category("Behavior")]
	public virtual bool AllowFreePan
	{
		get
		{
			return bool_6;
		}
		set
		{
			if (bool_6 != value)
			{
				bool_6 = value;
				OnAllowFreePanChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(false)]
	public virtual bool AllowUnfocusedMouseWheel
	{
		get
		{
			return bool_7;
		}
		set
		{
			if (AllowUnfocusedMouseWheel != value)
			{
				bool_7 = value;
				OnAllowUnfocusedMouseWheelChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(true)]
	public virtual bool AllowZoom
	{
		get
		{
			return bool_8;
		}
		set
		{
			if (AllowZoom != value)
			{
				bool_8 = value;
				OnAllowZoomChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(true)]
	public virtual bool AutoCenter
	{
		get
		{
			return bool_9;
		}
		set
		{
			if (bool_9 != value)
			{
				bool_9 = value;
				OnAutoCenterChanged(EventArgs.Empty);
			}
		}
	}

	[Obsolete("Use the PanMode property instead", false)]
	[Category("Behavior")]
	[DefaultValue(true)]
	public virtual bool AutoPan
	{
		get
		{
			return (imageBoxPanMode_0 & ImageBoxPanMode.Left) != 0;
		}
		set
		{
			if (AutoPan != value)
			{
				PanMode = (value ? (imageBoxPanMode_0 & ImageBoxPanMode.Left) : (imageBoxPanMode_0 & ~ImageBoxPanMode.Left));
				OnAutoPanChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(true)]
	public override bool AutoScroll
	{
		get
		{
			return base.AutoScroll;
		}
		set
		{
			base.AutoScroll = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new Size AutoScrollMinSize
	{
		get
		{
			return base.AutoScrollMinSize;
		}
		set
		{
			base.AutoScrollMinSize = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	[DefaultValue(false)]
	[Browsable(true)]
	[EditorBrowsable(EditorBrowsableState.Always)]
	public override bool AutoSize
	{
		get
		{
			return base.AutoSize;
		}
		set
		{
			if (base.AutoSize != value)
			{
				base.AutoSize = value;
				AdjustLayout();
			}
		}
	}

	[DefaultValue(typeof(Color), "White")]
	public override Color BackColor
	{
		get
		{
			return base.BackColor;
		}
		set
		{
			base.BackColor = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public override Image BackgroundImage
	{
		get
		{
			return base.BackgroundImage;
		}
		set
		{
			base.BackgroundImage = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override ImageLayout BackgroundImageLayout
	{
		get
		{
			return base.BackgroundImageLayout;
		}
		set
		{
			base.BackgroundImageLayout = value;
		}
	}

	[Browsable(false)]
	public Point CenterPoint
	{
		get
		{
			Rectangle imageViewPort = GetImageViewPort();
			return new Point(imageViewPort.Width / 2, imageViewPort.Height / 2);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public override Cursor Cursor
	{
		get
		{
			return base.Cursor;
		}
		set
		{
			base.Cursor = value;
		}
	}

	[DefaultValue(3)]
	[Category("Appearance")]
	public virtual int DropShadowSize
	{
		get
		{
			return int_0;
		}
		set
		{
			if (DropShadowSize != value)
			{
				int_0 = value;
				OnDropShadowSizeChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(8)]
	public virtual int GridCellSize
	{
		get
		{
			return int_1;
		}
		set
		{
			if (int_1 != value)
			{
				int_1 = value;
				OnGridCellSizeChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(Color), "Gainsboro")]
	public virtual Color GridColor
	{
		get
		{
			return color_0;
		}
		set
		{
			if (color_0 != value)
			{
				color_0 = value;
				OnGridColorChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Color), "White")]
	[Category("Appearance")]
	public virtual Color GridColorAlternate
	{
		get
		{
			return color_1;
		}
		set
		{
			if (color_1 != value)
			{
				color_1 = value;
				OnGridColorAlternateChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(ImageBoxGridDisplayMode.Client)]
	[Category("Appearance")]
	public virtual ImageBoxGridDisplayMode GridDisplayMode
	{
		get
		{
			return imageBoxGridDisplayMode_0;
		}
		set
		{
			if (imageBoxGridDisplayMode_0 != value)
			{
				imageBoxGridDisplayMode_0 = value;
				OnGridDisplayModeChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(ImageBoxGridScale), "Small")]
	public virtual ImageBoxGridScale GridScale
	{
		get
		{
			return imageBoxGridScale_0;
		}
		set
		{
			if (imageBoxGridScale_0 != value)
			{
				imageBoxGridScale_0 = value;
				OnGridScaleChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(null)]
	public virtual Image Image
	{
		get
		{
			return image_0;
		}
		set
		{
			if (image_0 != value)
			{
				if (IsAnimating)
				{
					ImageAnimator.StopAnimate(Image, method_15);
				}
				image_0 = value;
				OnImageChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Color), "ControlDark")]
	[Category("Appearance")]
	public virtual Color ImageBorderColor
	{
		get
		{
			return color_2;
		}
		set
		{
			if (ImageBorderColor != value)
			{
				color_2 = value;
				OnImageBorderColorChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(ImageBoxBorderStyle), "None")]
	public virtual ImageBoxBorderStyle ImageBorderStyle
	{
		get
		{
			return imageBoxBorderStyle_0;
		}
		set
		{
			if (ImageBorderStyle != value)
			{
				imageBoxBorderStyle_0 = value;
				OnImageBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(InterpolationMode.NearestNeighbor)]
	public virtual InterpolationMode InterpolationMode
	{
		get
		{
			return interpolationMode_0;
		}
		set
		{
			if (value == InterpolationMode.Invalid)
			{
				value = InterpolationMode.Default;
			}
			if (interpolationMode_0 != value)
			{
				interpolationMode_0 = value;
				OnInterpolationModeChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	public virtual bool InvertMouse
	{
		get
		{
			return bool_10;
		}
		set
		{
			if (bool_10 != value)
			{
				bool_10 = value;
				OnInvertMouseChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	public virtual bool IsActualSize => Zoom == 100;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[DefaultValue(false)]
	[Browsable(false)]
	public virtual bool IsPanning
	{
		get
		{
			return imageBoxPanStyle_0 != ImageBoxPanStyle.None;
		}
		protected set
		{
			method_21(value ? ImageBoxPanStyle.Standard : ImageBoxPanStyle.None);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual bool IsSelecting
	{
		get
		{
			return bool_16;
		}
		protected set
		{
			bool_16 = value;
		}
	}

	[Category("Behavior")]
	[DefaultValue(true)]
	public virtual bool LimitSelectionToImage
	{
		get
		{
			return bool_11;
		}
		set
		{
			if (LimitSelectionToImage != value)
			{
				bool_11 = value;
				OnLimitSelectionToImageChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(typeof(ImageBoxMouseWheelMode), "Zoom")]
	public virtual ImageBoxMouseWheelMode MouseWheelMode
	{
		get
		{
			return imageBoxMouseWheelMode_0;
		}
		set
		{
			if (imageBoxMouseWheelMode_0 != value)
			{
				imageBoxMouseWheelMode_0 = value;
				OnMouseWheelModeChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(typeof(ImageBoxPanMode), "Both")]
	public virtual ImageBoxPanMode PanMode
	{
		get
		{
			return imageBoxPanMode_0;
		}
		set
		{
			if (imageBoxPanMode_0 != value)
			{
				imageBoxPanMode_0 = value;
				OnPanModeChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Color), "DimGray")]
	[Category("Appearance")]
	public virtual Color PixelGridColor
	{
		get
		{
			return color_3;
		}
		set
		{
			if (PixelGridColor != value)
			{
				color_3 = value;
				OnPixelGridColorChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(5)]
	public virtual int PixelGridThreshold
	{
		get
		{
			return int_2;
		}
		set
		{
			if (PixelGridThreshold != value)
			{
				int_2 = value;
				OnPixelGridThresholdChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(false)]
	public virtual bool ScaleText
	{
		get
		{
			return bool_12;
		}
		set
		{
			if (ScaleText != value)
			{
				bool_12 = value;
				OnScaleTextChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Color), "Highlight")]
	[Category("Appearance")]
	public virtual Color SelectionColor
	{
		get
		{
			return color_4;
		}
		set
		{
			if (SelectionColor != value)
			{
				color_4 = value;
				OnSelectionColorChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(typeof(ImageBoxSelectionMode), "None")]
	public virtual ImageBoxSelectionMode SelectionMode
	{
		get
		{
			return imageBoxSelectionMode_0;
		}
		set
		{
			if (SelectionMode != value)
			{
				imageBoxSelectionMode_0 = value;
				OnSelectionModeChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual RectangleF SelectionRegion
	{
		get
		{
			return rectangleF_0;
		}
		set
		{
			if (SelectionRegion != value)
			{
				rectangleF_0 = value;
				OnSelectionRegionChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(true)]
	public virtual bool ShortcutsEnabled
	{
		get
		{
			return bool_13;
		}
		set
		{
			if (ShortcutsEnabled != value)
			{
				bool_13 = value;
				OnShortcutsEnabledChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	[Category("Appearance")]
	public virtual bool ShowPixelGrid
	{
		get
		{
			return bool_14;
		}
		set
		{
			if (ShowPixelGrid != value)
			{
				bool_14 = value;
				OnShowPixelGridChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Behavior")]
	[DefaultValue(typeof(ImageBoxSizeMode), "Normal")]
	public virtual ImageBoxSizeMode SizeMode
	{
		get
		{
			return imageBoxSizeMode_0;
		}
		set
		{
			if (SizeMode != value)
			{
				imageBoxSizeMode_0 = value;
				OnSizeModeChanged(EventArgs.Empty);
			}
		}
	}

	[Obsolete("This property is deprecated and will be removed in a future version of the component. Implementors should use the SizeMode property instead.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Appearance")]
	[DefaultValue(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public virtual bool SizeToFit
	{
		get
		{
			return SizeMode == ImageBoxSizeMode.Fit;
		}
		set
		{
			if (SizeMode == ImageBoxSizeMode.Fit != value)
			{
				SizeMode = (value ? ImageBoxSizeMode.Fit : ImageBoxSizeMode.Normal);
				OnSizeToFitChanged(EventArgs.Empty);
				if (value)
				{
					AutoPan = false;
				}
				else
				{
					ActualSize();
				}
			}
		}
	}

	[DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
	[Category("Appearance")]
	public virtual ContentAlignment TextAlign
	{
		get
		{
			return contentAlignment_0;
		}
		set
		{
			if (TextAlign != value)
			{
				contentAlignment_0 = value;
				OnTextAlignChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Color), "Transparent")]
	[Category("Appearance")]
	public virtual Color TextBackColor
	{
		get
		{
			return color_5;
		}
		set
		{
			if (TextBackColor != value)
			{
				color_5 = value;
				OnTextBackColorChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(ImageBoxGridDisplayMode), "Client")]
	[Category("Appearance")]
	public virtual ImageBoxGridDisplayMode TextDisplayMode
	{
		get
		{
			return imageBoxGridDisplayMode_1;
		}
		set
		{
			if (TextDisplayMode != value)
			{
				imageBoxGridDisplayMode_1 = value;
				OnTextDisplayModeChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Padding), "0, 0, 0, 0")]
	[Category("Appearance")]
	public virtual Padding TextPadding
	{
		get
		{
			return padding_0;
		}
		set
		{
			if (TextPadding != value)
			{
				padding_0 = value;
				OnTextPaddingChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(false)]
	[Category("Behavior")]
	public virtual bool VirtualMode
	{
		get
		{
			return bool_15;
		}
		set
		{
			if (VirtualMode != value)
			{
				bool_15 = value;
				OnVirtualModeChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Size), "0, 0")]
	[Category("Appearance")]
	public virtual Size VirtualSize
	{
		get
		{
			return size_5;
		}
		set
		{
			if (VirtualSize != value)
			{
				size_5 = value;
				OnVirtualSizeChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(100)]
	[Category("Appearance")]
	public virtual int Zoom
	{
		get
		{
			return int_4;
		}
		set
		{
			method_23(value, (value > Zoom) ? ImageBoxZoomActions.ZoomIn : ImageBoxZoomActions.ZoomOut, ImageBoxActionSources.Unknown);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual double ZoomFactor => (double)Zoom / 100.0;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual ZoomLevelCollection ZoomLevels
	{
		get
		{
			return zoomLevelCollection_0;
		}
		set
		{
			if (ZoomLevels != value)
			{
				zoomLevelCollection_0 = value;
				OnZoomLevelsChanged(EventArgs.Empty);
			}
		}
	}

	protected virtual bool AllowPainting => int_3 == 0;

	protected bool IsAnimating
	{
		[CompilerGenerated]
		get
		{
			return bool_17;
		}
		[CompilerGenerated]
		set
		{
			bool_17 = value;
		}
	}

	protected virtual int ScaledImageHeight => Convert.ToInt32((double)ViewSize.Height * ZoomFactor);

	protected virtual int ScaledImageWidth => Convert.ToInt32((double)ViewSize.Width * ZoomFactor);

	protected virtual Size ViewSize
	{
		get
		{
			if (!VirtualMode)
			{
				return method_10();
			}
			return VirtualSize;
		}
	}

	protected bool WasDragCancelled
	{
		[CompilerGenerated]
		get
		{
			return bool_18;
		}
		[CompilerGenerated]
		set
		{
			bool_18 = value;
		}
	}

	[Category("Property Changed")]
	public event EventHandler AllowClickZoomChanged
	{
		add
		{
			base.Events.AddHandler(object_0, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_0, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AllowDoubleClickChanged
	{
		add
		{
			base.Events.AddHandler(object_1, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_1, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AllowFreePanChanged
	{
		add
		{
			base.Events.AddHandler(object_2, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_2, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AllowUnfocusedMouseWheelChanged
	{
		add
		{
			base.Events.AddHandler(object_3, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_3, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AllowZoomChanged
	{
		add
		{
			base.Events.AddHandler(object_4, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_4, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AutoCenterChanged
	{
		add
		{
			base.Events.AddHandler(object_5, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_5, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AutoPanChanged
	{
		add
		{
			base.Events.AddHandler(object_6, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_6, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler DropShadowSizeChanged
	{
		add
		{
			base.Events.AddHandler(object_7, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_7, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler GridCellSizeChanged
	{
		add
		{
			base.Events.AddHandler(object_8, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_8, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler GridColorAlternateChanged
	{
		add
		{
			base.Events.AddHandler(object_9, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_9, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler GridColorChanged
	{
		add
		{
			base.Events.AddHandler(object_10, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_10, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler GridDisplayModeChanged
	{
		add
		{
			base.Events.AddHandler(object_11, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_11, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler GridScaleChanged
	{
		add
		{
			base.Events.AddHandler(object_12, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_12, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ImageBorderColorChanged
	{
		add
		{
			base.Events.AddHandler(object_13, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_13, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ImageBorderStyleChanged
	{
		add
		{
			base.Events.AddHandler(object_14, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_14, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ImageChanged
	{
		add
		{
			base.Events.AddHandler(object_15, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_15, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler InterpolationModeChanged
	{
		add
		{
			base.Events.AddHandler(object_16, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_16, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler InvertMouseChanged
	{
		add
		{
			base.Events.AddHandler(object_17, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_17, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler LimitSelectionToImageChanged
	{
		add
		{
			base.Events.AddHandler(object_18, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_18, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler MouseWheelModeChanged
	{
		add
		{
			base.Events.AddHandler(object_19, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_19, value);
		}
	}

	[Category("Action")]
	public event EventHandler PanEnd
	{
		add
		{
			base.Events.AddHandler(object_20, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_20, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler PanModeChanged
	{
		add
		{
			base.Events.AddHandler(object_21, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_21, value);
		}
	}

	[Category("Action")]
	public event EventHandler PanStart
	{
		add
		{
			base.Events.AddHandler(object_22, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_22, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler PixelGridColorChanged
	{
		add
		{
			base.Events.AddHandler(object_23, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_23, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler PixelGridThresholdChanged
	{
		add
		{
			base.Events.AddHandler(object_24, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_24, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ScaleTextChanged
	{
		add
		{
			base.Events.AddHandler(object_25, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_25, value);
		}
	}

	[Category("Action")]
	public event EventHandler<EventArgs> Selected
	{
		add
		{
			base.Events.AddHandler(object_26, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_26, value);
		}
	}

	[Category("Action")]
	public event EventHandler<ImageBoxCancelEventArgs> Selecting
	{
		add
		{
			base.Events.AddHandler(object_27, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_27, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler SelectionColorChanged
	{
		add
		{
			base.Events.AddHandler(object_28, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_28, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler SelectionModeChanged
	{
		add
		{
			base.Events.AddHandler(object_29, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_29, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler SelectionRegionChanged
	{
		add
		{
			base.Events.AddHandler(object_30, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_30, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ShortcutsEnabledChanged
	{
		add
		{
			base.Events.AddHandler(object_31, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_31, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ShowPixelGridChanged
	{
		add
		{
			base.Events.AddHandler(object_32, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_32, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler SizeModeChanged
	{
		add
		{
			base.Events.AddHandler(object_33, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_33, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler SizeToFitChanged
	{
		add
		{
			base.Events.AddHandler(object_34, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_34, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler TextAlignChanged
	{
		add
		{
			base.Events.AddHandler(object_35, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_35, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler TextBackColorChanged
	{
		add
		{
			base.Events.AddHandler(object_36, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_36, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler TextDisplayModeChanged
	{
		add
		{
			base.Events.AddHandler(object_37, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_37, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler TextPaddingChanged
	{
		add
		{
			base.Events.AddHandler(object_38, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_38, value);
		}
	}

	[Category("Appearance")]
	public event PaintEventHandler VirtualDraw
	{
		add
		{
			base.Events.AddHandler(object_39, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_39, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler VirtualModeChanged
	{
		add
		{
			base.Events.AddHandler(object_40, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_40, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler VirtualSizeChanged
	{
		add
		{
			base.Events.AddHandler(object_41, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_41, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ZoomChanged
	{
		add
		{
			base.Events.AddHandler(object_42, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_42, value);
		}
	}

	[Category("Action")]
	public event EventHandler<ImageBoxZoomEventArgs> Zoomed
	{
		add
		{
			base.Events.AddHandler(object_43, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_43, value);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ZoomLevelsChanged
	{
		add
		{
			base.Events.AddHandler(object_44, value);
		}
		remove
		{
			base.Events.RemoveHandler(object_44, value);
		}
	}

	public ImageBox()
	{
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
		SetStyle(ControlStyles.StandardDoubleClick, value: false);
		BeginUpdate();
		imageBoxPanMode_0 = ImageBoxPanMode.Both;
		bool_6 = true;
		base.WheelScrollsControl = false;
		AllowZoom = true;
		MouseWheelMode = ImageBoxMouseWheelMode.Zoom;
		LimitSelectionToImage = true;
		DropShadowSize = 3;
		ImageBorderStyle = ImageBoxBorderStyle.None;
		BackColor = Color.White;
		AutoSize = false;
		AutoScroll = true;
		GridScale = ImageBoxGridScale.Small;
		GridDisplayMode = ImageBoxGridDisplayMode.Client;
		GridColor = Color.Gainsboro;
		GridColorAlternate = Color.White;
		GridCellSize = 8;
		InterpolationMode = InterpolationMode.NearestNeighbor;
		AutoCenter = true;
		SelectionColor = SystemColors.Highlight;
		ActualSize();
		ShortcutsEnabled = true;
		ZoomLevels = ZoomLevelCollection.Default;
		ImageBorderColor = SystemColors.ControlDark;
		PixelGridColor = Color.DimGray;
		PixelGridThreshold = 5;
		TextAlign = ContentAlignment.MiddleCenter;
		TextBackColor = Color.Transparent;
		TextDisplayMode = ImageBoxGridDisplayMode.Client;
		EndUpdate();
	}

	public static Bitmap CreateCheckerBoxTile(int cellSize, Color cellColor, Color alternateCellColor)
	{
		int num = cellSize * 2;
		int num2 = cellSize * 2;
		Bitmap bitmap = new Bitmap(num, num2);
		using Graphics graphics = Graphics.FromImage(bitmap);
		Brush brush = new SolidBrush(cellColor);
		try
		{
			graphics.FillRectangle(brush, new Rectangle(cellSize, 0, cellSize, cellSize));
			graphics.FillRectangle(brush, new Rectangle(0, cellSize, cellSize, cellSize));
		}
		finally
		{
			((IDisposable)brush).Dispose();
		}
		Brush brush2 = new SolidBrush(alternateCellColor);
		try
		{
			graphics.FillRectangle(brush2, new Rectangle(0, 0, cellSize, cellSize));
			graphics.FillRectangle(brush2, new Rectangle(cellSize, cellSize, cellSize, cellSize));
			return bitmap;
		}
		finally
		{
			((IDisposable)brush2).Dispose();
		}
	}

	public static Bitmap CreateCheckerBoxTile()
	{
		return CreateCheckerBoxTile(8, Color.Gainsboro, Color.WhiteSmoke);
	}

	private static Cursor smethod_0()
	{
		Type typeFromHandle = typeof(ImageBox);
		return new Cursor(typeFromHandle.Assembly.GetManifestResourceStream(typeFromHandle.Namespace + Class16.smethod_0(1648893167)));
	}

	private static Bitmap smethod_1()
	{
		Type typeFromHandle = typeof(ImageBox);
		using Stream stream = typeFromHandle.Assembly.GetManifestResourceStream(typeFromHandle.Namespace + Class16.smethod_0(1648893177));
		return new Bitmap(stream);
	}

	private static void smethod_2()
	{
		if (cursor_1 == null)
		{
			cursor_1 = smethod_0();
		}
		if (bitmap_1 == null)
		{
			bitmap_1 = smethod_1();
		}
	}

	public virtual void ActualSize()
	{
		method_16(ImageBoxActionSources.Unknown);
	}

	public virtual void BeginUpdate()
	{
		int_3++;
	}

	public virtual void CenterAt(Point imageLocation)
	{
		ScrollTo(imageLocation, new Point(base.ClientSize.Width / 2, base.ClientSize.Height / 2));
	}

	public void CenterAt(int int_5, int int_6)
	{
		CenterAt(new Point(int_5, int_6));
	}

	public void CenterAt(float float_0, float float_1)
	{
		CenterAt(new Point((int)float_0, (int)float_1));
	}

	public virtual void CenterToImage()
	{
		AutoScrollPosition = new Point((AutoScrollMinSize.Width - base.ClientSize.Width) / 2, (AutoScrollMinSize.Height - base.ClientSize.Height) / 2);
	}

	public virtual void EndUpdate()
	{
		if (int_3 > 0)
		{
			int_3--;
		}
		if (AllowPainting)
		{
			Invalidate();
		}
	}

	public Rectangle FitRectangle(Rectangle rectangle)
	{
		int num = rectangle.X;
		int num2 = rectangle.Y;
		int num3 = rectangle.Width;
		int num4 = rectangle.Height;
		if (num < 0)
		{
			num = 0;
		}
		if (num2 < 0)
		{
			num2 = 0;
		}
		if (num + num3 > ViewSize.Width)
		{
			num3 = ViewSize.Width - num;
		}
		if (num2 + num4 > ViewSize.Height)
		{
			num4 = ViewSize.Height - num2;
		}
		return new Rectangle(num, num2, num3, num4);
	}

	public RectangleF FitRectangle(RectangleF rectangle)
	{
		float num = rectangle.X;
		float num2 = rectangle.Y;
		float num3 = rectangle.Width;
		float num4 = rectangle.Height;
		if (num < 0f)
		{
			num3 -= 0f - num;
			num = 0f;
		}
		if (num2 < 0f)
		{
			num4 -= 0f - num2;
			num2 = 0f;
		}
		if (num + num3 > (float)ViewSize.Width)
		{
			num3 = (float)ViewSize.Width - num;
		}
		if (num2 + num4 > (float)ViewSize.Height)
		{
			num4 = (float)ViewSize.Height - num2;
		}
		return new RectangleF(num, num2, num3, num4);
	}

	public virtual Rectangle GetImageViewPort()
	{
		if (!ViewSize.IsEmpty)
		{
			Rectangle insideViewPort = GetInsideViewPort(includePadding: true);
			if (!base.HScroll && !base.VScroll)
			{
				insideViewPort.Inflate(-GetImageBorderOffset(), -GetImageBorderOffset());
			}
			Point point;
			int num3;
			int num4;
			if (SizeMode != ImageBoxSizeMode.Stretch)
			{
				if (AutoCenter)
				{
					int num = ((!base.HScroll) ? ((insideViewPort.Width - (ScaledImageWidth + base.Padding.Horizontal)) / 2) : 0);
					int num2 = ((!base.VScroll) ? ((insideViewPort.Height - (ScaledImageHeight + base.Padding.Vertical)) / 2) : 0);
					point = new Point(num, num2);
				}
				else
				{
					point = Point.Empty;
				}
				num3 = Math.Min(ScaledImageWidth - Math.Abs(AutoScrollPosition.X), insideViewPort.Width);
				num4 = Math.Min(ScaledImageHeight - Math.Abs(AutoScrollPosition.Y), insideViewPort.Height);
			}
			else
			{
				point = Point.Empty;
				num3 = insideViewPort.Width;
				num4 = insideViewPort.Height;
			}
			return new Rectangle(point.X + insideViewPort.Left, point.Y + insideViewPort.Top, num3, num4);
		}
		return Rectangle.Empty;
	}

	public Rectangle GetInsideViewPort()
	{
		return GetInsideViewPort(includePadding: false);
	}

	public virtual Rectangle GetInsideViewPort(bool includePadding)
	{
		int num = 0;
		int num2 = 0;
		int num3 = base.ClientSize.Width;
		int num4 = base.ClientSize.Height;
		if (includePadding)
		{
			num += base.Padding.Left;
			num2 += base.Padding.Top;
			num3 -= base.Padding.Horizontal;
			num4 -= base.Padding.Vertical;
		}
		return new Rectangle(num, num2, num3, num4);
	}

	public virtual Point GetOffsetPoint(Point source)
	{
		PointF offsetPoint = GetOffsetPoint(new PointF(source.X, source.Y));
		return new Point((int)offsetPoint.X, (int)offsetPoint.Y);
	}

	public Point GetOffsetPoint(int int_5, int int_6)
	{
		return GetOffsetPoint(new Point(int_5, int_6));
	}

	public PointF GetOffsetPoint(float float_0, float float_1)
	{
		return GetOffsetPoint(new PointF(float_0, float_1));
	}

	public virtual PointF GetOffsetPoint(PointF source)
	{
		Rectangle imageViewPort = GetImageViewPort();
		PointF scaledPoint = GetScaledPoint(source);
		int num = imageViewPort.Left + base.Padding.Left + AutoScrollPosition.X;
		int num2 = imageViewPort.Top + base.Padding.Top + AutoScrollPosition.Y;
		return new PointF(scaledPoint.X + (float)num, scaledPoint.Y + (float)num2);
	}

	public virtual RectangleF GetOffsetRectangle(RectangleF source)
	{
		RectangleF rectangleF = GetImageViewPort();
		RectangleF scaledRectangle = GetScaledRectangle(source);
		float num = rectangleF.Left + (float)base.Padding.Left + (float)AutoScrollPosition.X;
		float num2 = rectangleF.Top + (float)base.Padding.Top + (float)AutoScrollPosition.Y;
		return new RectangleF(new PointF(scaledRectangle.Left + num, scaledRectangle.Top + num2), scaledRectangle.Size);
	}

	public Rectangle GetOffsetRectangle(int int_5, int int_6, int width, int height)
	{
		return GetOffsetRectangle(new Rectangle(int_5, int_6, width, height));
	}

	public RectangleF GetOffsetRectangle(float float_0, float float_1, float width, float height)
	{
		return GetOffsetRectangle(new RectangleF(float_0, float_1, width, height));
	}

	public virtual Rectangle GetOffsetRectangle(Rectangle source)
	{
		Rectangle imageViewPort = GetImageViewPort();
		Rectangle scaledRectangle = GetScaledRectangle(source);
		int num = imageViewPort.Left + base.Padding.Left + AutoScrollPosition.X;
		int num2 = imageViewPort.Top + base.Padding.Top + AutoScrollPosition.Y;
		return new Rectangle(new Point(scaledRectangle.Left + num, scaledRectangle.Top + num2), scaledRectangle.Size);
	}

	public override Size GetPreferredSize(Size proposedSize)
	{
		if (!ViewSize.IsEmpty)
		{
			int scaledImageWidth = ScaledImageWidth;
			int scaledImageHeight = ScaledImageHeight;
			scaledImageWidth += base.Padding.Horizontal;
			scaledImageHeight += base.Padding.Vertical;
			scaledImageWidth += GetImageBorderOffset();
			scaledImageHeight += GetImageBorderOffset();
			return new Size(scaledImageWidth, scaledImageHeight);
		}
		return base.GetPreferredSize(proposedSize);
	}

	public Point GetScaledPoint(int int_5, int int_6)
	{
		return GetScaledPoint(new Point(int_5, int_6));
	}

	public PointF GetScaledPoint(float float_0, float float_1)
	{
		return GetScaledPoint(new PointF(float_0, float_1));
	}

	public virtual Point GetScaledPoint(Point source)
	{
		return new Point((int)((double)source.X * ZoomFactor), (int)((double)source.Y * ZoomFactor));
	}

	public virtual PointF GetScaledPoint(PointF source)
	{
		return new PointF((float)((double)source.X * ZoomFactor), (float)((double)source.Y * ZoomFactor));
	}

	public Rectangle GetScaledRectangle(int int_5, int int_6, int width, int height)
	{
		return GetScaledRectangle(new Rectangle(int_5, int_6, width, height));
	}

	public RectangleF GetScaledRectangle(float float_0, float float_1, float width, float height)
	{
		return GetScaledRectangle(new RectangleF(float_0, float_1, width, height));
	}

	public Rectangle GetScaledRectangle(Point location, Size size)
	{
		return GetScaledRectangle(new Rectangle(location, size));
	}

	public RectangleF GetScaledRectangle(PointF location, SizeF size)
	{
		return GetScaledRectangle(new RectangleF(location, size));
	}

	public virtual Rectangle GetScaledRectangle(Rectangle source)
	{
		return new Rectangle((int)((double)source.Left * ZoomFactor), (int)((double)source.Top * ZoomFactor), (int)((double)source.Width * ZoomFactor), (int)((double)source.Height * ZoomFactor));
	}

	public virtual RectangleF GetScaledRectangle(RectangleF source)
	{
		return new RectangleF((float)((double)source.Left * ZoomFactor), (float)((double)source.Top * ZoomFactor), (float)((double)source.Width * ZoomFactor), (float)((double)source.Height * ZoomFactor));
	}

	public SizeF GetScaledSize(float width, float height)
	{
		return GetScaledSize(new SizeF(width, height));
	}

	public Size GetScaledSize(int width, int height)
	{
		return GetScaledSize(new Size(width, height));
	}

	public virtual SizeF GetScaledSize(SizeF source)
	{
		return new SizeF((float)((double)source.Width * ZoomFactor), (float)((double)source.Height * ZoomFactor));
	}

	public virtual Size GetScaledSize(Size source)
	{
		return new Size((int)((double)source.Width * ZoomFactor), (int)((double)source.Height * ZoomFactor));
	}

	public Image GetSelectedImage()
	{
		Image image = null;
		if (!SelectionRegion.IsEmpty)
		{
			Rectangle srcRect = FitRectangle(new Rectangle((int)SelectionRegion.X, (int)SelectionRegion.Y, (int)SelectionRegion.Width, (int)SelectionRegion.Height));
			if (srcRect.Width > 0 && srcRect.Height > 0)
			{
				image = new Bitmap(srcRect.Width, srcRect.Height);
				using Graphics graphics = Graphics.FromImage(image);
				graphics.DrawImage(Image, new Rectangle(Point.Empty, srcRect.Size), srcRect, GraphicsUnit.Pixel);
			}
		}
		return image;
	}

	public virtual RectangleF GetSourceImageRegion()
	{
		if (!ViewSize.IsEmpty)
		{
			RectangleF result;
			if (SizeMode != ImageBoxSizeMode.Stretch)
			{
				Rectangle imageViewPort = GetImageViewPort();
				float num = (float)((double)(-AutoScrollPosition.X) / ZoomFactor);
				float num2 = (float)((double)(-AutoScrollPosition.Y) / ZoomFactor);
				float num3 = (float)((double)imageViewPort.Width / ZoomFactor);
				float num4 = (float)((double)imageViewPort.Height / ZoomFactor);
				result = new RectangleF(num, num2, num3, num4);
			}
			else
			{
				result = new RectangleF(PointF.Empty, ViewSize);
			}
			return result;
		}
		return RectangleF.Empty;
	}

	public virtual bool IsPointInImage(Point point)
	{
		return GetImageViewPort().Contains(point);
	}

	public bool IsPointInImage(int int_5, int int_6)
	{
		return IsPointInImage(new Point(int_5, int_6));
	}

	public bool IsPointInImage(float float_0, float float_1)
	{
		return IsPointInImage(new Point((int)float_0, (int)float_1));
	}

	public Point PointToImage(Point point)
	{
		return PointToImage(point, fitToBounds: false);
	}

	public Point PointToImage(float float_0, float float_1)
	{
		return PointToImage(float_0, float_1, fitToBounds: false);
	}

	public Point PointToImage(float float_0, float float_1, bool fitToBounds)
	{
		return PointToImage(new Point((int)float_0, (int)float_1), fitToBounds);
	}

	public Point PointToImage(int int_5, int int_6)
	{
		return PointToImage(int_5, int_6, fitToBounds: false);
	}

	public Point PointToImage(int int_5, int int_6, bool fitToBounds)
	{
		return PointToImage(new Point(int_5, int_6), fitToBounds);
	}

	public virtual Point PointToImage(Point point, bool fitToBounds)
	{
		Rectangle imageViewPort = GetImageViewPort();
		int num;
		int num2;
		if (fitToBounds && !imageViewPort.Contains(point))
		{
			num = 0;
			num2 = 0;
		}
		else
		{
			if (AutoScrollPosition != Point.Empty)
			{
				point = new Point(point.X - AutoScrollPosition.X, point.Y - AutoScrollPosition.Y);
			}
			num = (int)((double)(point.X - imageViewPort.X) / ZoomFactor);
			num2 = (int)((double)(point.Y - imageViewPort.Y) / ZoomFactor);
			if (fitToBounds)
			{
				if (num < 0)
				{
					num = 0;
				}
				else if (num > ViewSize.Width)
				{
					num = ViewSize.Width;
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				else if (num2 > ViewSize.Height)
				{
					num2 = ViewSize.Height;
				}
			}
		}
		return new Point(num, num2);
	}

	public void ScrollTo(int int_5, int int_6, int relativeX, int relativeY)
	{
		ScrollTo(new Point(int_5, int_6), new Point(relativeX, relativeY));
	}

	public void ScrollTo(float float_0, float float_1, float relativeX, float relativeY)
	{
		ScrollTo(new Point((int)float_0, (int)float_1), new Point((int)relativeX, (int)relativeY));
	}

	public virtual void ScrollTo(Point imageLocation, Point relativeDisplayPoint)
	{
		int num = (int)((double)imageLocation.X * ZoomFactor) - relativeDisplayPoint.X;
		int num2 = (int)((double)imageLocation.Y * ZoomFactor) - relativeDisplayPoint.Y;
		AutoScrollPosition = new Point(num, num2);
	}

	public virtual void SelectAll()
	{
		SelectionRegion = new RectangleF(PointF.Empty, ViewSize);
	}

	public virtual void SelectNone()
	{
		SelectionRegion = RectangleF.Empty;
	}

	public virtual void ZoomIn()
	{
		ZoomIn(preservePosition: true);
	}

	public virtual void ZoomIn(bool preservePosition)
	{
		method_19(ImageBoxActionSources.Unknown, preservePosition);
	}

	public virtual void ZoomOut()
	{
		ZoomOut(preservePosition: true);
	}

	public virtual void ZoomOut(bool preservePosition)
	{
		method_20(ImageBoxActionSources.Unknown, preservePosition);
	}

	public virtual void ZoomToFit()
	{
		if (ViewSize.IsEmpty)
		{
			return;
		}
		AutoScrollMinSize = Size.Empty;
		Rectangle insideViewPort = GetInsideViewPort(includePadding: true);
		double num2;
		if (ViewSize.Width > ViewSize.Height)
		{
			double num = (double)insideViewPort.Width / (double)ViewSize.Width;
			num2 = num * 100.0;
			if ((double)insideViewPort.Height < (double)ViewSize.Height * num2 / 100.0)
			{
				num = (double)insideViewPort.Height / (double)ViewSize.Height;
				num2 = num * 100.0;
			}
		}
		else
		{
			double num = (double)insideViewPort.Height / (double)ViewSize.Height;
			num2 = num * 100.0;
			if ((double)insideViewPort.Width < (double)ViewSize.Width * num2 / 100.0)
			{
				num = (double)insideViewPort.Width / (double)ViewSize.Width;
				num2 = num * 100.0;
			}
		}
		Zoom = (int)Math.Round(Math.Floor(num2));
	}

	public void ZoomToRegion(float float_0, float float_1, float width, float height)
	{
		ZoomToRegion(new RectangleF(float_0, float_1, width, height));
	}

	public void ZoomToRegion(int int_5, int int_6, int width, int height)
	{
		ZoomToRegion(new RectangleF(int_5, int_6, width, height));
	}

	public virtual void ZoomToRegion(RectangleF rectangle)
	{
		double val = (float)base.ClientSize.Width / rectangle.Width;
		double val2 = (float)base.ClientSize.Height / rectangle.Height;
		double num = Math.Min(val, val2);
		int num2 = (int)(rectangle.X + rectangle.Width / 2f);
		int num3 = (int)(rectangle.Y + rectangle.Height / 2f);
		Zoom = (int)(num * 100.0);
		CenterAt(new Point(num2, num3));
	}

	protected virtual void AdjustLayout()
	{
		if (AllowPainting)
		{
			if (AutoSize)
			{
				AdjustSize();
			}
			else if (SizeMode != ImageBoxSizeMode.Normal)
			{
				ZoomToFit();
			}
			else if (AutoScroll)
			{
				AdjustViewPort();
			}
			Invalidate();
		}
	}

	protected virtual void AdjustScroll(int int_5, int int_6)
	{
		Point position = new Point(base.HorizontalScroll.Value + int_5, base.VerticalScroll.Value + int_6);
		UpdateScrollPosition(position);
	}

	protected virtual void AdjustSize()
	{
		if (AutoSize && Dock == DockStyle.None)
		{
			base.Size = base.PreferredSize;
		}
	}

	protected virtual void AdjustViewPort()
	{
		if (AutoScroll && !ViewSize.IsEmpty)
		{
			AutoScrollMinSize = new Size(ScaledImageWidth + base.Padding.Horizontal, ScaledImageHeight + base.Padding.Vertical);
		}
	}

	protected virtual Bitmap CreateGridTileImage(int cellSize, Color firstColor, Color secondColor)
	{
		cellSize = (int)((float)cellSize * GridScale switch
		{
			ImageBoxGridScale.Tiny => 0.5f, 
			ImageBoxGridScale.Medium => 1.5f, 
			ImageBoxGridScale.Large => 2f, 
			_ => 1f, 
		});
		return CreateCheckerBoxTile(cellSize, firstColor, secondColor);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (IsAnimating)
			{
				ImageAnimator.StopAnimate(Image, method_15);
			}
			if (brush_0 != null)
			{
				brush_0.Dispose();
				brush_0 = null;
			}
			if (bitmap_0 != null)
			{
				bitmap_0.Dispose();
				bitmap_0 = null;
			}
			method_14();
		}
		base.Dispose(disposing);
	}

	protected virtual void DrawBackground(PaintEventArgs paintEventArgs_0)
	{
		Rectangle insideViewPort = GetInsideViewPort();
		SolidBrush solidBrush = new SolidBrush(BackColor);
		try
		{
			paintEventArgs_0.Graphics.FillRectangle(solidBrush, insideViewPort);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		if (brush_0 != null && GridDisplayMode != ImageBoxGridDisplayMode.None)
		{
			switch (GridDisplayMode)
			{
			case ImageBoxGridDisplayMode.Image:
			{
				Rectangle imageViewPort = GetImageViewPort();
				paintEventArgs_0.Graphics.FillRectangle(brush_0, imageViewPort);
				break;
			}
			case ImageBoxGridDisplayMode.Client:
				paintEventArgs_0.Graphics.FillRectangle(brush_0, insideViewPort);
				break;
			}
		}
	}

	protected virtual void DrawDropShadow(Graphics graphics_0, Rectangle viewPort)
	{
		Rectangle rectangle = new Rectangle(viewPort.Right + 1, viewPort.Top + DropShadowSize, DropShadowSize, viewPort.Height);
		Rectangle rectangle2 = new Rectangle(viewPort.Left + DropShadowSize, viewPort.Bottom + 1, viewPort.Width + 1, DropShadowSize);
		Brush brush = new SolidBrush(ImageBorderColor);
		try
		{
			graphics_0.FillRectangles(brush, new Rectangle[2] { rectangle, rectangle2 });
		}
		finally
		{
			((IDisposable)brush).Dispose();
		}
	}

	protected virtual void DrawGlowShadow(Graphics graphics_0, Rectangle viewPort)
	{
		graphics_0.SetClip(viewPort, CombineMode.Exclude);
		GraphicsPath graphicsPath = new GraphicsPath();
		try
		{
			graphicsPath.AddRectangle(viewPort);
			int num = DropShadowSize * 3;
			int num2 = 50;
			for (int i = 1; i <= num; i += 2)
			{
				int alpha = num2 - num2 / num * i;
				using Pen pen = new Pen(Color.FromArgb(alpha, ImageBorderColor), i)
				{
					LineJoin = LineJoin.Round
				};
				graphics_0.DrawPath(pen, graphicsPath);
			}
		}
		finally
		{
			((IDisposable)graphicsPath).Dispose();
		}
	}

	protected virtual void DrawImage(Graphics graphics_0)
	{
		InterpolationMode interpolationMode = graphics_0.InterpolationMode;
		PixelOffsetMode pixelOffsetMode = graphics_0.PixelOffsetMode;
		graphics_0.InterpolationMode = GetInterpolationMode();
		graphics_0.PixelOffsetMode = PixelOffsetMode.HighQuality;
		try
		{
			if (IsAnimating && !base.DesignMode)
			{
				ImageAnimator.UpdateFrames(Image);
			}
			graphics_0.DrawImage(Image, GetImageViewPort(), GetSourceImageRegion(), GraphicsUnit.Pixel);
		}
		catch (Exception ex)
		{
			TextRenderer.DrawText(graphics_0, ex.Message, Font, base.ClientRectangle, ForeColor, BackColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
		}
		graphics_0.PixelOffsetMode = pixelOffsetMode;
		graphics_0.InterpolationMode = interpolationMode;
	}

	protected virtual void DrawImageBorder(Graphics graphics)
	{
		if (ImageBorderStyle != ImageBoxBorderStyle.None)
		{
			graphics.SetClip(GetInsideViewPort());
			Rectangle imageViewPort = GetImageViewPort();
			imageViewPort = new Rectangle(imageViewPort.Left - 1, imageViewPort.Top - 1, imageViewPort.Width + 1, imageViewPort.Height + 1);
			Pen pen = new Pen(ImageBorderColor);
			try
			{
				graphics.DrawRectangle(pen, imageViewPort);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
			switch (ImageBorderStyle)
			{
			case ImageBoxBorderStyle.FixedSingleGlowShadow:
				DrawGlowShadow(graphics, imageViewPort);
				break;
			case ImageBoxBorderStyle.FixedSingleDropShadow:
				DrawDropShadow(graphics, imageViewPort);
				break;
			}
			graphics.ResetClip();
		}
	}

	protected void DrawLabel(Graphics graphics, string text, Rectangle bounds)
	{
		DrawLabel(graphics, text, Font, ForeColor, TextBackColor, TextAlign, bounds);
	}

	protected void DrawLabel(Graphics graphics, string text, Font font, Rectangle bounds)
	{
		DrawLabel(graphics, text, font, ForeColor, TextBackColor, TextAlign, bounds);
	}

	protected void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Rectangle bounds)
	{
		DrawLabel(graphics, text, font, foreColor, TextBackColor, TextAlign, bounds);
	}

	protected void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, Rectangle bounds)
	{
		DrawLabel(graphics, text, font, foreColor, backColor, TextAlign, bounds);
	}

	protected void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, ContentAlignment textAlign, Rectangle bounds)
	{
		DrawLabel(graphics, text, font, foreColor, backColor, textAlign, bounds, ScaleText);
	}

	protected virtual void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, ContentAlignment textAlign, Rectangle bounds, bool scaleText)
	{
		DrawLabel(graphics, text, font, foreColor, backColor, textAlign, bounds, scaleText, Padding.Empty);
	}

	protected virtual void DrawLabel(Graphics graphics, string text, Font font, Color foreColor, Color backColor, ContentAlignment textAlign, Rectangle bounds, bool scaleText, Padding padding)
	{
		if (scaleText)
		{
			font = new Font(font.FontFamily, (float)((double)font.Size * ZoomFactor), font.Style);
		}
		TextFormatFlags textFormatFlags = TextFormatFlags.NoPrefix | TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis | TextFormatFlags.NoPadding;
		switch (textAlign)
		{
		default:
			textFormatFlags |= TextFormatFlags.HorizontalCenter;
			break;
		case ContentAlignment.TopLeft:
		case ContentAlignment.MiddleLeft:
		case ContentAlignment.BottomLeft:
			break;
		case ContentAlignment.TopRight:
		case ContentAlignment.MiddleRight:
		case ContentAlignment.BottomRight:
			textFormatFlags |= TextFormatFlags.Right;
			break;
		}
		switch (textAlign)
		{
		case ContentAlignment.TopLeft:
		case ContentAlignment.TopCenter:
		case ContentAlignment.TopRight:
			break;
		default:
			textFormatFlags |= TextFormatFlags.VerticalCenter;
			break;
		case ContentAlignment.BottomLeft:
		case ContentAlignment.BottomCenter:
		case ContentAlignment.BottomRight:
			textFormatFlags |= TextFormatFlags.Bottom;
			break;
		}
		if (padding.Horizontal != 0 || padding.Vertical != 0)
		{
			Size size = TextRenderer.MeasureText(graphics, text, font, bounds.Size, textFormatFlags);
			int num = size.Width;
			int num2 = size.Height;
			int num3;
			int num4;
			switch (textAlign)
			{
			case ContentAlignment.MiddleCenter:
				num3 = bounds.Left + padding.Left + ((bounds.Width - num) / 2 - padding.Right);
				num4 = bounds.Top + padding.Top + (bounds.Height - num2) / 2;
				break;
			case ContentAlignment.MiddleLeft:
				num3 = bounds.Left + padding.Left;
				num4 = bounds.Top + padding.Top + (bounds.Height - num2) / 2;
				break;
			case ContentAlignment.TopLeft:
				num3 = bounds.Left + padding.Left;
				num4 = bounds.Top + padding.Top;
				break;
			case ContentAlignment.TopCenter:
				num3 = bounds.Left + padding.Left + ((bounds.Width - num) / 2 - padding.Right);
				num4 = bounds.Top + padding.Top;
				break;
			case ContentAlignment.TopRight:
				num3 = bounds.Right - (padding.Right + num);
				num4 = bounds.Top + padding.Top;
				break;
			case ContentAlignment.BottomLeft:
				num3 = bounds.Left + padding.Left;
				num4 = bounds.Bottom - (padding.Bottom + num2);
				break;
			case ContentAlignment.MiddleRight:
				num3 = bounds.Right - (padding.Right + num);
				num4 = bounds.Top + padding.Top + (bounds.Height - num2) / 2;
				break;
			default:
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893201));
			case ContentAlignment.BottomRight:
				num3 = bounds.Right - (padding.Right + num);
				num4 = bounds.Bottom - (padding.Bottom + num2);
				break;
			case ContentAlignment.BottomCenter:
				num3 = bounds.Left + padding.Left + ((bounds.Width - num) / 2 - padding.Right);
				num4 = bounds.Bottom - (padding.Bottom + num2);
				break;
			}
			if (backColor != Color.Empty && backColor.A > 0)
			{
				Brush brush = new SolidBrush(backColor);
				try
				{
					graphics.FillRectangle(brush, num3 - padding.Left, num4 - padding.Top, num + padding.Horizontal, num2 + padding.Vertical);
				}
				finally
				{
					((IDisposable)brush).Dispose();
				}
			}
			bounds = new Rectangle(num3, num4, num, num2);
		}
		TextRenderer.DrawText(graphics, text, font, bounds, foreColor, backColor, textFormatFlags);
		if (scaleText)
		{
			font.Dispose();
		}
	}

	protected virtual void DrawPixelGrid(Graphics graphics_0)
	{
		float num = (float)ZoomFactor;
		if (!(num > (float)PixelGridThreshold))
		{
			return;
		}
		Rectangle imageViewPort = GetImageViewPort();
		float num2 = (float)Math.Abs(AutoScrollPosition.X) % num;
		float num3 = (float)Math.Abs(AutoScrollPosition.Y) % num;
		using Pen pen = new Pen(PixelGridColor)
		{
			DashStyle = DashStyle.Dot
		};
		for (float num4 = (float)imageViewPort.Left + num - num2; num4 < (float)imageViewPort.Right; num4 += num)
		{
			graphics_0.DrawLine(pen, num4, imageViewPort.Top, num4, imageViewPort.Bottom);
		}
		for (float num5 = (float)imageViewPort.Top + num - num3; num5 < (float)imageViewPort.Bottom; num5 += num)
		{
			graphics_0.DrawLine(pen, imageViewPort.Left, num5, imageViewPort.Right, num5);
		}
		graphics_0.DrawRectangle(pen, imageViewPort);
	}

	protected virtual void DrawSelection(PaintEventArgs paintEventArgs_0)
	{
		paintEventArgs_0.Graphics.SetClip(GetInsideViewPort(includePadding: true));
		RectangleF offsetRectangle = GetOffsetRectangle(SelectionRegion);
		Brush brush = new SolidBrush(Color.FromArgb(128, SelectionColor));
		try
		{
			paintEventArgs_0.Graphics.FillRectangle(brush, offsetRectangle);
		}
		finally
		{
			((IDisposable)brush).Dispose();
		}
		Pen pen = new Pen(SelectionColor);
		try
		{
			paintEventArgs_0.Graphics.DrawRectangle(pen, offsetRectangle.X, offsetRectangle.Y, offsetRectangle.Width, offsetRectangle.Height);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		paintEventArgs_0.Graphics.ResetClip();
	}

	protected virtual void DrawText(PaintEventArgs paintEventArgs_0)
	{
		Rectangle bounds = ((TextDisplayMode == ImageBoxGridDisplayMode.Client) ? GetInsideViewPort() : GetImageViewPort());
		DrawLabel(paintEventArgs_0.Graphics, Text, Font, ForeColor, TextBackColor, TextAlign, bounds, ScaleText, TextPadding);
	}

	protected virtual void EndDrag()
	{
		IsSelecting = false;
		OnSelected(EventArgs.Empty);
	}

	protected virtual Cursor GetCursor(Point location)
	{
		return imageBoxPanStyle_0 switch
		{
			ImageBoxPanStyle.None => Cursors.Default, 
			ImageBoxPanStyle.Standard => Cursors.SizeAll, 
			ImageBoxPanStyle.Free => method_11(location) switch
			{
				ImageBoxPanDirection.None => cursor_1, 
				ImageBoxPanDirection.Up => Cursors.PanNorth, 
				ImageBoxPanDirection.Down => Cursors.PanSouth, 
				ImageBoxPanDirection.Left => Cursors.PanWest, 
				ImageBoxPanDirection.Right => Cursors.PanEast, 
				_ => cursor_1, 
			}, 
			_ => Cursors.Default, 
		};
	}

	protected virtual int GetImageBorderOffset()
	{
		return ImageBorderStyle switch
		{
			ImageBoxBorderStyle.FixedSingleDropShadow => DropShadowSize + 1, 
			ImageBoxBorderStyle.FixedSingle => 1, 
			_ => 0, 
		};
	}

	protected virtual InterpolationMode GetInterpolationMode()
	{
		InterpolationMode interpolationMode = InterpolationMode;
		if (interpolationMode == InterpolationMode.Default)
		{
			interpolationMode = ((Zoom >= 100) ? InterpolationMode.NearestNeighbor : InterpolationMode.HighQualityBicubic);
		}
		return interpolationMode;
	}

	protected override bool IsInputKey(Keys keyData)
	{
		if ((keyData & Keys.Right) == Keys.Right || (keyData & Keys.Left) == Keys.Left || (keyData & Keys.Up) == Keys.Up || (keyData & Keys.Down) == Keys.Down)
		{
			return true;
		}
		return base.IsInputKey(keyData);
	}

	protected virtual void OnAllowClickZoomChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_0])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAllowDoubleClickChanged(EventArgs eventArgs_0)
	{
		SetStyle(ControlStyles.StandardDoubleClick, AllowDoubleClick);
		((EventHandler)base.Events[object_1])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAllowFreePanChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_2])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAllowUnfocusedMouseWheelChanged(EventArgs eventArgs_0)
	{
		if (AllowUnfocusedMouseWheel)
		{
			ImageBoxMouseWheelMessageFilter.Active = true;
		}
		((EventHandler)base.Events[object_3])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAllowZoomChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_4])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAutoCenterChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_5])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAutoPanChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_6])?.Invoke(this, eventArgs_0);
	}

	protected override void OnBackColorChanged(EventArgs eventArgs_0)
	{
		base.OnBackColorChanged(eventArgs_0);
		Invalidate();
	}

	protected override void OnBorderStyleChanged(EventArgs eventArgs_0)
	{
		base.OnBorderStyleChanged(eventArgs_0);
		AdjustLayout();
	}

	protected override void OnDockChanged(EventArgs eventArgs_0)
	{
		base.OnDockChanged(eventArgs_0);
		if (Dock != DockStyle.None)
		{
			AutoSize = false;
		}
	}

	protected virtual void OnDropShadowSizeChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_7])?.Invoke(this, eventArgs_0);
	}

	protected override void OnFontChanged(EventArgs eventArgs_0)
	{
		base.OnFontChanged(eventArgs_0);
		Invalidate();
	}

	protected override void OnForeColorChanged(EventArgs eventArgs_0)
	{
		base.OnForeColorChanged(eventArgs_0);
		Invalidate();
	}

	protected virtual void OnGridCellSizeChanged(EventArgs eventArgs_0)
	{
		method_13();
		((EventHandler)base.Events[object_8])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnGridColorAlternateChanged(EventArgs eventArgs_0)
	{
		method_13();
		((EventHandler)base.Events[object_9])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnGridColorChanged(EventArgs eventArgs_0)
	{
		method_13();
		((EventHandler)base.Events[object_10])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnGridDisplayModeChanged(EventArgs eventArgs_0)
	{
		method_13();
		Invalidate();
		((EventHandler)base.Events[object_11])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnGridScaleChanged(EventArgs eventArgs_0)
	{
		method_13();
		((EventHandler)base.Events[object_12])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnImageBorderColorChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_13])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnImageBorderStyleChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_14])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnImageChanged(EventArgs eventArgs_0)
	{
		IsAnimating = false;
		if (Image != null)
		{
			try
			{
				IsAnimating = ImageAnimator.CanAnimate(Image);
				if (IsAnimating)
				{
					ImageAnimator.Animate(Image, method_15);
				}
			}
			catch (ArgumentException)
			{
			}
		}
		AdjustLayout();
		((EventHandler)base.Events[object_15])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnInterpolationModeChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_16])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnInvertMouseChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_17])?.Invoke(this, eventArgs_0);
	}

	protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
	{
		base.OnKeyDown(keyEventArgs_0);
		ProcessScrollingShortcuts(keyEventArgs_0);
		if (ShortcutsEnabled && AllowZoom && SizeMode == ImageBoxSizeMode.Normal)
		{
			ProcessImageShortcuts(keyEventArgs_0);
		}
	}

	protected virtual void OnLimitSelectionToImageChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_18])?.Invoke(this, eventArgs_0);
	}

	protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
	{
		base.OnMouseDown(mouseEventArgs_0);
		if (!Focused)
		{
			Focus();
		}
		if (mouseEventArgs_0.Button != MouseButtons.None)
		{
			if (imageBoxPanStyle_0 == ImageBoxPanStyle.Free)
			{
				method_21(ImageBoxPanStyle.None);
			}
			else
			{
				double_0 = NativeMethods.GetTickCount();
				if (AllowFreePan && mouseEventArgs_0.Button == MouseButtons.Middle)
				{
					ProcessPanning(mouseEventArgs_0);
				}
			}
		}
		method_22(mouseEventArgs_0.Location);
	}

	protected override void OnMouseMove(MouseEventArgs mea)
	{
		base.OnMouseMove(mea);
		if (mea.Button != MouseButtons.None)
		{
			ProcessPanning(mea);
			ProcessSelection(mea);
		}
		method_22(mea.Location);
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
		bool flag = imageBoxPanStyle_0 != ImageBoxPanStyle.None || IsSelecting;
		if (imageBoxPanStyle_0 == ImageBoxPanStyle.Standard || (imageBoxPanStyle_0 == ImageBoxPanStyle.Free && (double)NativeMethods.GetTickCount() > double_0 + (double)SystemInformation.DoubleClickTime))
		{
			method_21(ImageBoxPanStyle.None);
		}
		if (IsSelecting)
		{
			EndDrag();
		}
		WasDragCancelled = false;
		if (!flag && AllowZoom && AllowClickZoom && imageBoxPanStyle_0 == ImageBoxPanStyle.None && SizeMode == ImageBoxSizeMode.Normal)
		{
			if (mevent.Button == MouseButtons.Left && Control.ModifierKeys == Keys.None)
			{
				ProcessMouseZoom(isZoomIn: true, mevent.Location);
			}
			else if (mevent.Button == MouseButtons.Right || (mevent.Button == MouseButtons.Left && Control.ModifierKeys != Keys.None))
			{
				ProcessMouseZoom(isZoomIn: false, mevent.Location);
			}
		}
	}

	protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
	{
		base.OnMouseWheel(mouseEventArgs_0);
		if (MouseWheelMode == ImageBoxMouseWheelMode.Zoom)
		{
			method_6(mouseEventArgs_0);
		}
		else if (MouseWheelMode == ImageBoxMouseWheelMode.ScrollAndZoom)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				method_6(mouseEventArgs_0);
			}
			else if (base.VScroll && Control.ModifierKeys == Keys.None)
			{
				int num = SystemInformation.MouseWheelScrollLines * base.VerticalScroll.SmallChange;
				ScrollTo(base.HorizontalScroll.Value, base.VerticalScroll.Value + ((mouseEventArgs_0.Delta > 0) ? (-num) : num));
			}
			else if (base.HScroll && Control.ModifierKeys == Keys.Shift)
			{
				int num2 = SystemInformation.MouseWheelScrollLines * base.HorizontalScroll.SmallChange;
				ScrollTo(base.HorizontalScroll.Value + ((mouseEventArgs_0.Delta > 0) ? (-num2) : num2), base.VerticalScroll.Value);
			}
		}
	}

	protected virtual void OnMouseWheelModeChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_19])?.Invoke(this, eventArgs_0);
	}

	protected override void OnPaddingChanged(EventArgs eventArgs_0)
	{
		base.OnPaddingChanged(eventArgs_0);
		AdjustLayout();
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		if (AllowPainting)
		{
			DrawBackground(paintEventArgs_0);
			if (!ViewSize.IsEmpty)
			{
				DrawImageBorder(paintEventArgs_0.Graphics);
			}
			if (VirtualMode)
			{
				OnVirtualDraw(paintEventArgs_0);
			}
			else if (Image != null)
			{
				DrawImage(paintEventArgs_0.Graphics);
			}
			if (ShowPixelGrid && !VirtualMode)
			{
				DrawPixelGrid(paintEventArgs_0.Graphics);
			}
			if (SelectionRegion != Rectangle.Empty)
			{
				DrawSelection(paintEventArgs_0);
			}
			if (!string.IsNullOrEmpty(Text) && TextDisplayMode != ImageBoxGridDisplayMode.None)
			{
				DrawText(paintEventArgs_0);
			}
			if (imageBoxPanStyle_0 == ImageBoxPanStyle.Free)
			{
				method_7(paintEventArgs_0);
			}
			base.OnPaint(paintEventArgs_0);
		}
	}

	protected virtual void OnPanEnd(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_20])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnPanModeChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_21])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnPanStart(CancelEventArgs cancelEventArgs_0)
	{
		((EventHandler)base.Events[object_22])?.Invoke(this, cancelEventArgs_0);
	}

	protected override void OnParentChanged(EventArgs eventArgs_0)
	{
		base.OnParentChanged(eventArgs_0);
		AdjustLayout();
	}

	protected virtual void OnPixelGridColorChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_23])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnPixelGridThresholdChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_24])?.Invoke(this, eventArgs_0);
	}

	protected override void OnResize(EventArgs eventArgs_0)
	{
		AdjustLayout();
		base.OnResize(eventArgs_0);
	}

	protected virtual void OnScaleTextChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_25])?.Invoke(this, eventArgs_0);
	}

	protected override void OnScroll(ScrollEventArgs se)
	{
		Invalidate();
		base.OnScroll(se);
	}

	protected virtual void OnSelected(EventArgs eventArgs_0)
	{
		ImageBoxSelectionMode selectionMode = SelectionMode;
		if (selectionMode == ImageBoxSelectionMode.Zoom && SelectionRegion.Width > 5f && SelectionRegion.Height > 5f)
		{
			ZoomToRegion(SelectionRegion);
			SelectNone();
		}
		((EventHandler<EventArgs>)base.Events[object_26])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnSelecting(ImageBoxCancelEventArgs imageBoxCancelEventArgs_0)
	{
		((EventHandler<ImageBoxCancelEventArgs>)base.Events[object_27])?.Invoke(this, imageBoxCancelEventArgs_0);
	}

	protected virtual void OnSelectionColorChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_28])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnSelectionModeChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_29])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnSelectionRegionChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_30])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnShortcutsEnabledChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_31])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnShowPixelGridChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_32])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnSizeModeChanged(EventArgs eventArgs_0)
	{
		AdjustLayout();
		((EventHandler)base.Events[object_33])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnSizeToFitChanged(EventArgs eventArgs_0)
	{
		AdjustLayout();
		((EventHandler)base.Events[object_34])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnTextAlignChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_35])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnTextBackColorChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_36])?.Invoke(this, eventArgs_0);
	}

	protected override void OnTextChanged(EventArgs eventArgs_0)
	{
		base.OnTextChanged(eventArgs_0);
		Invalidate();
	}

	protected virtual void OnTextDisplayModeChanged(EventArgs eventArgs_0)
	{
		Invalidate();
		((EventHandler)base.Events[object_37])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnTextPaddingChanged(EventArgs eventArgs_0)
	{
		EventHandler eventHandler = (EventHandler)base.Events[object_38];
		Invalidate();
		eventHandler?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnVirtualDraw(PaintEventArgs paintEventArgs_0)
	{
		((PaintEventHandler)base.Events[object_39])?.Invoke(this, paintEventArgs_0);
	}

	protected virtual void OnVirtualModeChanged(EventArgs eventArgs_0)
	{
		AdjustLayout();
		((EventHandler)base.Events[object_40])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnVirtualSizeChanged(EventArgs eventArgs_0)
	{
		AdjustLayout();
		((EventHandler)base.Events[object_41])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnZoomChanged(EventArgs eventArgs_0)
	{
		AdjustLayout();
		((EventHandler)base.Events[object_42])?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnZoomed(ImageBoxZoomEventArgs imageBoxZoomEventArgs_0)
	{
		((EventHandler<ImageBoxZoomEventArgs>)base.Events[object_43])?.Invoke(this, imageBoxZoomEventArgs_0);
	}

	protected virtual void OnZoomLevelsChanged(EventArgs eventArgs_0)
	{
		((EventHandler)base.Events[object_44])?.Invoke(this, eventArgs_0);
	}

	protected virtual void ProcessImageShortcuts(KeyEventArgs keyEventArgs_0)
	{
		Point centerPoint = CenterPoint;
		Point imageLocation = PointToImage(centerPoint);
		int zoom = Zoom;
		switch (keyEventArgs_0.KeyCode)
		{
		case Keys.Prior:
		case Keys.OemMinus:
			if (AllowZoom)
			{
				method_20(ImageBoxActionSources.User, bool_19: true);
			}
			break;
		case Keys.Next:
		case Keys.Oemplus:
			if (AllowZoom)
			{
				method_19(ImageBoxActionSources.User, bool_19: true);
			}
			break;
		case Keys.Home:
			if (AllowZoom)
			{
				method_16(ImageBoxActionSources.User);
			}
			break;
		}
		if (Zoom != zoom)
		{
			ScrollTo(imageLocation, centerPoint);
		}
	}

	protected virtual void ProcessMouseZoom(bool isZoomIn, Point cursorPosition)
	{
		method_18(isZoomIn ? ImageBoxZoomActions.ZoomIn : ImageBoxZoomActions.ZoomOut, ImageBoxActionSources.User, bool_19: true, cursorPosition);
	}

	protected virtual void ProcessPanning(MouseEventArgs mouseEventArgs_0)
	{
		if (method_4(mouseEventArgs_0.Button) && imageBoxPanStyle_0 == ImageBoxPanStyle.None && (base.HScroll || base.VScroll))
		{
			point_1 = mouseEventArgs_0.Location;
			method_21((mouseEventArgs_0.Button != MouseButtons.Middle || !bool_6) ? ImageBoxPanStyle.Standard : ImageBoxPanStyle.Free);
		}
		if (imageBoxPanStyle_0 == ImageBoxPanStyle.Standard)
		{
			int num;
			int num2;
			if (!InvertMouse)
			{
				num = -point_2.X + (point_1.X - mouseEventArgs_0.Location.X);
				num2 = -point_2.Y + (point_1.Y - mouseEventArgs_0.Location.Y);
			}
			else
			{
				num = -(point_2.X + (point_1.X - mouseEventArgs_0.Location.X));
				num2 = -(point_2.Y + (point_1.Y - mouseEventArgs_0.Location.Y));
			}
			Point position = new Point(num, num2);
			UpdateScrollPosition(position);
		}
	}

	protected virtual void ProcessScrollingShortcuts(KeyEventArgs keyEventArgs_0)
	{
		switch (keyEventArgs_0.KeyCode)
		{
		case Keys.Left:
			AdjustScroll(-((keyEventArgs_0.Modifiers == Keys.None) ? base.HorizontalScroll.SmallChange : base.HorizontalScroll.LargeChange), 0);
			break;
		case Keys.Up:
			AdjustScroll(0, -((keyEventArgs_0.Modifiers == Keys.None) ? base.VerticalScroll.SmallChange : base.VerticalScroll.LargeChange));
			break;
		case Keys.Right:
			AdjustScroll((keyEventArgs_0.Modifiers == Keys.None) ? base.HorizontalScroll.SmallChange : base.HorizontalScroll.LargeChange, 0);
			break;
		case Keys.Down:
			AdjustScroll(0, (keyEventArgs_0.Modifiers == Keys.None) ? base.VerticalScroll.SmallChange : base.VerticalScroll.LargeChange);
			break;
		}
	}

	protected virtual void ProcessSelection(MouseEventArgs mouseEventArgs_0)
	{
		if (SelectionMode == ImageBoxSelectionMode.None || mouseEventArgs_0.Button != MouseButtons.Left || WasDragCancelled)
		{
			return;
		}
		if (!IsSelecting)
		{
			StartDrag(mouseEventArgs_0);
		}
		if (!IsSelecting)
		{
			return;
		}
		Point location = GetImageViewPort().Location;
		float num;
		float num2;
		if (mouseEventArgs_0.X < point_1.X)
		{
			num = mouseEventArgs_0.X;
			num2 = point_1.X - mouseEventArgs_0.X;
		}
		else
		{
			num = point_1.X;
			num2 = mouseEventArgs_0.X - point_1.X;
		}
		float num3;
		float num4;
		if (mouseEventArgs_0.Y < point_1.Y)
		{
			num3 = mouseEventArgs_0.Y;
			num4 = point_1.Y - mouseEventArgs_0.Y;
		}
		else
		{
			num3 = point_1.Y;
			num4 = mouseEventArgs_0.Y - point_1.Y;
		}
		num = num - (float)location.X - (float)AutoScrollPosition.X;
		num3 = num3 - (float)location.Y - (float)AutoScrollPosition.Y;
		num /= (float)ZoomFactor;
		num3 /= (float)ZoomFactor;
		num2 /= (float)ZoomFactor;
		num4 /= (float)ZoomFactor;
		if (num2 != 0f && num4 != 0f)
		{
			RectangleF rectangleF = new RectangleF(num, num3, num2, num4);
			if (LimitSelectionToImage)
			{
				rectangleF = FitRectangle(rectangleF);
			}
			SelectionRegion = rectangleF;
		}
	}

	protected void RestoreSizeMode()
	{
		if (SizeMode != ImageBoxSizeMode.Normal)
		{
			int zoom = Zoom;
			SizeMode = ImageBoxSizeMode.Normal;
			Zoom = zoom;
		}
	}

	protected virtual void StartDrag(MouseEventArgs mouseEventArgs_0)
	{
		ImageBoxCancelEventArgs e = new ImageBoxCancelEventArgs(mouseEventArgs_0.Location);
		OnSelecting(e);
		WasDragCancelled = e.Cancel;
		IsSelecting = !e.Cancel;
		if (IsSelecting)
		{
			SelectNone();
			point_1 = mouseEventArgs_0.Location;
		}
	}

	protected virtual void UpdateScrollPosition(Point position)
	{
		AutoScrollPosition = position;
		Invalidate();
		OnScroll(new ScrollEventArgs(ScrollEventType.EndScroll, 0));
	}

	private bool method_4(MouseButtons mouseButtons_0)
	{
		if ((base.HScroll || base.VScroll) && ((uint)imageBoxPanMode_0 & (uint)mouseButtons_0) != 0 && !ViewSize.IsEmpty)
		{
			if (imageBoxSelectionMode_0 != ImageBoxSelectionMode.None)
			{
				return mouseButtons_0 != MouseButtons.Left;
			}
			return true;
		}
		return false;
	}

	private void method_5()
	{
		timer_0 = new Timer
		{
			Enabled = true,
			Interval = 250
		};
		timer_0.Tick += timer_0_Tick;
		timer_0.Start();
	}

	private void method_6(MouseEventArgs mouseEventArgs_0)
	{
		if (AllowZoom && SizeMode == ImageBoxSizeMode.Normal)
		{
			int num = Math.Abs(mouseEventArgs_0.Delta / SystemInformation.MouseWheelScrollDelta);
			for (int i = 0; i < num; i++)
			{
				ProcessMouseZoom(mouseEventArgs_0.Delta > 0, mouseEventArgs_0.Location);
			}
		}
	}

	private void method_7(PaintEventArgs paintEventArgs_0)
	{
		Graphics graphics = paintEventArgs_0.Graphics;
		int num = point_1.X - (bitmap_1.Width >> 1);
		int num2 = point_1.Y - (bitmap_1.Height >> 1);
		graphics.DrawImage(bitmap_1, num, num2);
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		Point point_ = PointToClient(Control.MousePosition);
		ImageBoxPanDirection imageBoxPanDirection = method_11(point_);
		int num = method_8(point_1.X, point_1.Y, point_.X, point_.Y);
		int num2 = 0;
		int num3 = 0;
		switch (imageBoxPanDirection)
		{
		case ImageBoxPanDirection.Up:
			num3 = -num;
			break;
		case ImageBoxPanDirection.Down:
			num3 = num;
			break;
		case ImageBoxPanDirection.Left:
			num2 = -num;
			break;
		case ImageBoxPanDirection.Right:
			num2 = num;
			break;
		}
		if (num2 != 0 || num3 != 0)
		{
			AdjustScroll(num2, num3);
		}
	}

	private int method_8(int int_5, int int_6, int int_7, int int_8)
	{
		int num = int_7 - int_5;
		int num2 = int_8 - int_6;
		double value = Math.Sqrt(num * num + num2 * num2);
		return Convert.ToInt32(value);
	}

	private int method_9(int int_5, int int_6)
	{
		int num = int_6 - int_5;
		double value = Math.Sqrt(num * num);
		return Convert.ToInt32(value);
	}

	private Size method_10()
	{
		if (Image != null)
		{
			try
			{
				return Image.Size;
			}
			catch
			{
				return Size.Empty;
			}
		}
		return Size.Empty;
	}

	private ImageBoxPanDirection method_11(Point point_3)
	{
		int num = point_3.X - point_1.X;
		int num2 = point_3.Y - point_1.Y;
		if (num >= -32 && num <= 32 && num2 >= -32 && num2 <= 32)
		{
			return ImageBoxPanDirection.None;
		}
		int num3 = point_3.X - point_1.X;
		if (-num2 > Math.Abs(num3))
		{
			return ImageBoxPanDirection.Up;
		}
		if (num2 > Math.Abs(num3))
		{
			return ImageBoxPanDirection.Down;
		}
		return (num3 < 0) ? ImageBoxPanDirection.Left : ImageBoxPanDirection.Right;
	}

	private int method_12(ImageBoxZoomActions imageBoxZoomActions_0)
	{
		return imageBoxZoomActions_0 switch
		{
			ImageBoxZoomActions.None => Zoom, 
			ImageBoxZoomActions.ZoomIn => ZoomLevels.NextZoom(Zoom), 
			ImageBoxZoomActions.ZoomOut => ZoomLevels.PreviousZoom(Zoom), 
			ImageBoxZoomActions.ActualSize => 100, 
			_ => throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893220)), 
		};
	}

	private void method_13()
	{
		brush_0?.Dispose();
		bitmap_0?.Dispose();
		if (GridDisplayMode != ImageBoxGridDisplayMode.None && GridCellSize != 0)
		{
			if (GridScale != ImageBoxGridScale.None)
			{
				bitmap_0 = CreateGridTileImage(GridCellSize, GridColor, GridColorAlternate);
				brush_0 = new TextureBrush(bitmap_0);
			}
			else
			{
				brush_0 = new SolidBrush(GridColor);
			}
		}
		Invalidate();
	}

	private void method_14()
	{
		if (timer_0 != null)
		{
			timer_0.Stop();
			timer_0.Tick -= timer_0_Tick;
			timer_0.Dispose();
			timer_0 = null;
		}
	}

	private void method_15(object sender, EventArgs e)
	{
		Invalidate();
	}

	private void method_16(ImageBoxActionSources imageBoxActionSources_0)
	{
		SizeMode = ImageBoxSizeMode.Normal;
		method_23(100, (ImageBoxZoomActions)(4 | ((Zoom < 100) ? 1 : 2)), imageBoxActionSources_0);
	}

	private void method_17(ImageBoxZoomActions imageBoxZoomActions_0, ImageBoxActionSources imageBoxActionSources_0, bool bool_19)
	{
		method_18(imageBoxZoomActions_0, imageBoxActionSources_0, bool_19, CenterPoint);
	}

	private void method_18(ImageBoxZoomActions imageBoxZoomActions_0, ImageBoxActionSources imageBoxActionSources_0, bool bool_19, Point point_3)
	{
		Point imageLocation = PointToImage(point_3);
		int zoom = Zoom;
		int int_ = method_12(imageBoxZoomActions_0);
		RestoreSizeMode();
		method_23(int_, imageBoxZoomActions_0, imageBoxActionSources_0);
		if (bool_19 && Zoom != zoom)
		{
			ScrollTo(imageLocation, point_3);
		}
	}

	private void method_19(ImageBoxActionSources imageBoxActionSources_0, bool bool_19)
	{
		method_17(ImageBoxZoomActions.ZoomIn, imageBoxActionSources_0, bool_19);
	}

	private void method_20(ImageBoxActionSources imageBoxActionSources_0, bool bool_19)
	{
		method_17(ImageBoxZoomActions.ZoomOut, imageBoxActionSources_0, bool_19);
	}

	private void method_21(ImageBoxPanStyle imageBoxPanStyle_1)
	{
		if (imageBoxPanStyle_0 == imageBoxPanStyle_1)
		{
			return;
		}
		method_14();
		if (imageBoxPanStyle_1 == ImageBoxPanStyle.None)
		{
			imageBoxPanStyle_0 = ImageBoxPanStyle.None;
			Invalidate();
			OnPanEnd(EventArgs.Empty);
			return;
		}
		CancelEventArgs e = new CancelEventArgs();
		OnPanStart(e);
		if (!e.Cancel)
		{
			imageBoxPanStyle_0 = imageBoxPanStyle_1;
			if (imageBoxPanStyle_1 == ImageBoxPanStyle.Free)
			{
				smethod_2();
				method_5();
			}
			point_2 = AutoScrollPosition;
		}
		Invalidate();
	}

	private void method_22(Point point_3)
	{
		Cursor cursor = GetCursor(point_3);
		if (cursor_0 != cursor)
		{
			cursor_0 = cursor;
			Cursor = cursor;
		}
	}

	private void method_23(int int_5, ImageBoxZoomActions imageBoxZoomActions_0, ImageBoxActionSources imageBoxActionSources_0)
	{
		int zoom = Zoom;
		if (int_5 < 1)
		{
			int_5 = 1;
		}
		else if (int_5 > 3500)
		{
			int_5 = 3500;
		}
		if (int_4 != int_5)
		{
			int_4 = int_5;
			OnZoomChanged(EventArgs.Empty);
			OnZoomed(new ImageBoxZoomEventArgs(imageBoxZoomActions_0, imageBoxActionSources_0, zoom, Zoom));
		}
	}
}
