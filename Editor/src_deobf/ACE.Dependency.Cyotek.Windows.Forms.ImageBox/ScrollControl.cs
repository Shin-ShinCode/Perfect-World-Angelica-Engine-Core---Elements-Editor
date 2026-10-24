using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

[ToolboxItem(false)]
public class ScrollControl : Control
{
	public class HScrollProperties : ScrollProperties
	{
		public HScrollProperties(ScrollControl container)
			: base(container)
		{
		}
	}

	public abstract class ScrollProperties
	{
		private readonly ScrollControl scrollControl_0;

		private bool bool_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private bool bool_1;

		[DefaultValue(true)]
		public bool Enabled
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

		[DefaultValue(10)]
		public int LargeChange
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

		[DefaultValue(100)]
		public int Maximum
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

		[DefaultValue(0)]
		public int Minimum
		{
			[CompilerGenerated]
			get
			{
				return int_2;
			}
			[CompilerGenerated]
			set
			{
				int_2 = value;
			}
		}

		public ScrollControl ParentControl => scrollControl_0;

		[DefaultValue(1)]
		public int SmallChange
		{
			[CompilerGenerated]
			get
			{
				return int_3;
			}
			[CompilerGenerated]
			set
			{
				int_3 = value;
			}
		}

		[DefaultValue(0)]
		[Bindable(true)]
		public int Value
		{
			[CompilerGenerated]
			get
			{
				return int_4;
			}
			[CompilerGenerated]
			set
			{
				int_4 = value;
			}
		}

		[DefaultValue(false)]
		public bool Visible
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

		protected ScrollProperties(ScrollControl container)
		{
			scrollControl_0 = container;
		}
	}

	public class VScrollProperties : ScrollProperties
	{
		public VScrollProperties(ScrollControl container)
			: base(container)
		{
		}
	}

	private bool bool_0;

	private bool bool_1;

	private BorderStyle borderStyle_0;

	private Size size_0;

	private Size size_1;

	private Size size_2;

	private EventHandler eventHandler_0;

	private MouseEventHandler mouseEventHandler_0;

	private EventHandler eventHandler_1;

	private ScrollEventHandler scrollEventHandler_0;

	private EventHandler eventHandler_2;

	private EventHandler eventHandler_3;

	private HScrollProperties hscrollProperties_0;

	private VScrollProperties vscrollProperties_0;

	private bool bool_2;

	protected override CreateParams CreateParams
	{
		get
		{
			CreateParams createParams = base.CreateParams;
			switch (borderStyle_0)
			{
			case BorderStyle.Fixed3D:
				createParams.ExStyle |= 512;
				break;
			case BorderStyle.FixedSingle:
				createParams.Style |= 8388608;
				break;
			}
			return createParams;
		}
	}

	[DefaultValue(false)]
	[Category("Layout")]
	public bool AlwaysShowHScroll
	{
		get
		{
			return bool_0;
		}
		set
		{
			if (bool_0 != value)
			{
				bool_0 = value;
				if (value)
				{
					NativeMethods.SCROLLINFO sCROLLINFO = new NativeMethods.SCROLLINFO();
					sCROLLINFO.fMask = NativeMethods.SIF.SIF_RANGE | NativeMethods.SIF.SIF_DISABLENOSCROLL;
					sCROLLINFO.nMin = 0;
					sCROLLINFO.nMax = 0;
					sCROLLINFO.nPage = 1;
					method_1(ScrollOrientation.HorizontalScroll, sCROLLINFO, bool_3: false);
					Invalidate();
				}
				else
				{
					UpdateHorizontalScrollbar();
				}
			}
		}
	}

	[DefaultValue(false)]
	[Category("Layout")]
	public bool AlwaysShowVScroll
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool vScroll = VScroll;
			bool_1 = value;
			if (bool_1 != vScroll)
			{
				if (bool_1)
				{
					NativeMethods.SCROLLINFO sCROLLINFO = new NativeMethods.SCROLLINFO();
					sCROLLINFO.fMask = NativeMethods.SIF.SIF_RANGE | NativeMethods.SIF.SIF_DISABLENOSCROLL;
					sCROLLINFO.nMin = 0;
					sCROLLINFO.nMax = 0;
					sCROLLINFO.nPage = 1;
					method_1(ScrollOrientation.VerticalScroll, sCROLLINFO, bool_3: false);
					Invalidate();
				}
				else
				{
					UpdateVerticalScrollbar();
				}
			}
		}
	}

	[Category("Appearance")]
	[DefaultValue(typeof(BorderStyle), "Fixed3D")]
	public virtual BorderStyle BorderStyle
	{
		get
		{
			return borderStyle_0;
		}
		set
		{
			if (BorderStyle != value)
			{
				borderStyle_0 = value;
				OnBorderStyleChanged(EventArgs.Empty);
			}
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public HScrollProperties HorizontalScroll
	{
		[CompilerGenerated]
		get
		{
			return hscrollProperties_0;
		}
		[CompilerGenerated]
		protected set
		{
			hscrollProperties_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual Size PageSize
	{
		get
		{
			return size_0;
		}
		set
		{
			if (value.Width < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893231), Class16.smethod_0(1648893234));
			}
			if (value.Height < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893274), Class16.smethod_0(1648893293));
			}
			if (PageSize != value)
			{
				size_0 = value;
				OnPageSizeChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual Size ScrollSize
	{
		get
		{
			return size_1;
		}
		set
		{
			if (value.Width < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893334), Class16.smethod_0(1648893234));
			}
			if (value.Height < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893337), Class16.smethod_0(1648893293));
			}
			if (ScrollSize != value)
			{
				size_1 = value;
				OnScrollSizeChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Layout")]
	[DefaultValue(typeof(Size), "10, 10")]
	public virtual Size StepSize
	{
		get
		{
			return size_2;
		}
		set
		{
			if (value.Width < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893356), Class16.smethod_0(1648893234));
			}
			if (value.Height < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893367), Class16.smethod_0(1648893293));
			}
			if (StepSize != value)
			{
				size_2 = value;
				OnStepSizeChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public VScrollProperties VerticalScroll
	{
		[CompilerGenerated]
		get
		{
			return vscrollProperties_0;
		}
		[CompilerGenerated]
		protected set
		{
			vscrollProperties_0 = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected bool HScroll
	{
		get
		{
			return (NativeMethods.GetWindowLong(base.Handle, -16) & 0x100000) == 1048576;
		}
		set
		{
			uint windowLong = NativeMethods.GetWindowLong(base.Handle, -16);
			windowLong = ((!value) ? (windowLong & 0xFFEFFFFFu) : (windowLong | 0x100000));
			NativeMethods.SetWindowLong(base.Handle, -16, windowLong);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected bool VScroll
	{
		get
		{
			return (NativeMethods.GetWindowLong(base.Handle, -16) & 0x200000) == 2097152;
		}
		set
		{
			uint windowLong = NativeMethods.GetWindowLong(base.Handle, -16);
			windowLong = ((!value) ? (windowLong & 0xFFDFFFFFu) : (windowLong | 0x200000));
			NativeMethods.SetWindowLong(base.Handle, -16, windowLong);
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	protected bool WheelScrollsControl
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

	[Category("Property Changed")]
	public event EventHandler BorderStyleChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_0;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[Browsable(true)]
	[Category("Mouse")]
	public new event MouseEventHandler MouseWheel
	{
		[CompilerGenerated]
		add
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_0;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Combine(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			MouseEventHandler mouseEventHandler = mouseEventHandler_0;
			MouseEventHandler mouseEventHandler2;
			do
			{
				mouseEventHandler2 = mouseEventHandler;
				MouseEventHandler value2 = (MouseEventHandler)Delegate.Remove(mouseEventHandler2, value);
				mouseEventHandler = Interlocked.CompareExchange(ref mouseEventHandler_0, value2, mouseEventHandler2);
			}
			while ((object)mouseEventHandler != mouseEventHandler2);
		}
	}

	[Category("Property Changed")]
	public event EventHandler PageSizeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_1;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Category("Action")]
	public event ScrollEventHandler Scroll
	{
		[CompilerGenerated]
		add
		{
			ScrollEventHandler scrollEventHandler = scrollEventHandler_0;
			ScrollEventHandler scrollEventHandler2;
			do
			{
				scrollEventHandler2 = scrollEventHandler;
				ScrollEventHandler value2 = (ScrollEventHandler)Delegate.Combine(scrollEventHandler2, value);
				scrollEventHandler = Interlocked.CompareExchange(ref scrollEventHandler_0, value2, scrollEventHandler2);
			}
			while ((object)scrollEventHandler != scrollEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ScrollEventHandler scrollEventHandler = scrollEventHandler_0;
			ScrollEventHandler scrollEventHandler2;
			do
			{
				scrollEventHandler2 = scrollEventHandler;
				ScrollEventHandler value2 = (ScrollEventHandler)Delegate.Remove(scrollEventHandler2, value);
				scrollEventHandler = Interlocked.CompareExchange(ref scrollEventHandler_0, value2, scrollEventHandler2);
			}
			while ((object)scrollEventHandler != scrollEventHandler2);
		}
	}

	[Category("Property Changed")]
	public event EventHandler ScrollSizeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_2;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Category("Property Changed")]
	public event EventHandler StepSizeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_3;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public ScrollControl()
	{
		BorderStyle = BorderStyle.Fixed3D;
		ScrollSize = Size.Empty;
		PageSize = Size.Empty;
		StepSize = new Size(10, 10);
		HorizontalScroll = new HScrollProperties(this);
		VerticalScroll = new VScrollProperties(this);
	}

	protected override void OnEnabledChanged(EventArgs eventArgs_0)
	{
		base.OnEnabledChanged(eventArgs_0);
		UpdateScrollbars();
	}

	protected override void OnMouseDown(MouseEventArgs mouseEventArgs_0)
	{
		base.OnMouseDown(mouseEventArgs_0);
		if (!Focused)
		{
			Focus();
		}
	}

	protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
	{
		if (WheelScrollsControl)
		{
			int num = HorizontalScroll.Value;
			int num2 = VerticalScroll.Value;
			if (VerticalScroll.Visible && VerticalScroll.Enabled)
			{
				int num3 = ((Control.ModifierKeys != Keys.Control) ? (SystemInformation.MouseWheelScrollLines * VerticalScroll.SmallChange) : VerticalScroll.LargeChange);
				num2 += ((mouseEventArgs_0.Delta > 0) ? (-num3) : num3);
			}
			else if (HorizontalScroll.Visible && HorizontalScroll.Enabled)
			{
				int num3 = ((Control.ModifierKeys != Keys.Control) ? (SystemInformation.MouseWheelScrollLines * HorizontalScroll.SmallChange) : HorizontalScroll.LargeChange);
				num += ((mouseEventArgs_0.Delta > 0) ? (-num3) : num3);
			}
			ScrollTo(num, num2);
		}
		mouseEventHandler_0?.Invoke(this, mouseEventArgs_0);
		base.OnMouseWheel(mouseEventArgs_0);
	}

	[DebuggerStepThrough]
	protected override void WndProc(ref Message msg)
	{
		int msg2 = msg.Msg;
		if ((uint)(msg2 - 276) <= 1u)
		{
			WmScroll(ref msg);
		}
		else
		{
			base.WndProc(ref msg);
		}
	}

	public void ScrollTo(int int_0, int int_1)
	{
		ScrollTo(ScrollOrientation.HorizontalScroll, int_0);
		ScrollTo(ScrollOrientation.VerticalScroll, int_1);
	}

	protected ScrollEventType GetEventType(IntPtr wParam)
	{
		return (wParam.ToInt32() & 0xFFFF) switch
		{
			0 => ScrollEventType.SmallDecrement, 
			1 => ScrollEventType.SmallIncrement, 
			2 => ScrollEventType.LargeDecrement, 
			3 => ScrollEventType.LargeIncrement, 
			4 => ScrollEventType.ThumbPosition, 
			5 => ScrollEventType.ThumbTrack, 
			6 => ScrollEventType.First, 
			7 => ScrollEventType.Last, 
			8 => ScrollEventType.EndScroll, 
			_ => throw new ArgumentException(string.Format(Class16.smethod_0(1648893370), wParam), Class16.smethod_0(1648893421)), 
		};
	}

	protected virtual void OnBorderStyleChanged(EventArgs eventArgs_0)
	{
		UpdateStyles();
		eventHandler_0?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnPageSizeChanged(EventArgs eventArgs_0)
	{
		UpdateScrollbars();
		eventHandler_1?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnScroll(ScrollEventArgs se)
	{
		UpdateHorizontalScroll();
		UpdateVerticalScroll();
		scrollEventHandler_0?.Invoke(this, se);
	}

	protected virtual void OnScrollSizeChanged(EventArgs eventArgs_0)
	{
		UpdateScrollbars();
		eventHandler_2?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnStepSizeChanged(EventArgs eventArgs_0)
	{
		eventHandler_3?.Invoke(this, eventArgs_0);
	}

	protected virtual void ScrollTo(ScrollOrientation scrollbar, int value)
	{
		NativeMethods.SCROLLINFO sCROLLINFO = method_0(scrollbar);
		if (value > sCROLLINFO.nMax - sCROLLINFO.nMin + 1 - sCROLLINFO.nPage)
		{
			value = sCROLLINFO.nMax - sCROLLINFO.nMin + 1 - sCROLLINFO.nPage;
		}
		if (value < sCROLLINFO.nMin)
		{
			value = sCROLLINFO.nMin;
		}
		if (sCROLLINFO.nPos != value)
		{
			NativeMethods.SCROLLINFO sCROLLINFO2 = new NativeMethods.SCROLLINFO();
			sCROLLINFO2.fMask = NativeMethods.SIF.SIF_POS;
			sCROLLINFO2.nPos = value;
			method_1(scrollbar, sCROLLINFO2, bool_3: true);
			OnScroll(new ScrollEventArgs(ScrollEventType.ThumbPosition, sCROLLINFO.nPos, value, scrollbar));
		}
	}

	protected virtual void UpdateHorizontalScroll()
	{
		NativeMethods.SCROLLINFO sCROLLINFO = method_0(ScrollOrientation.HorizontalScroll);
		HorizontalScroll.Enabled = base.Enabled;
		HorizontalScroll.LargeChange = sCROLLINFO.nPage;
		HorizontalScroll.Maximum = sCROLLINFO.nMax;
		HorizontalScroll.Minimum = sCROLLINFO.nMin;
		HorizontalScroll.SmallChange = StepSize.Width;
		HorizontalScroll.Value = sCROLLINFO.nPos;
		HorizontalScroll.Visible = true;
	}

	protected virtual void UpdateHorizontalScrollbar()
	{
		int num = ScrollSize.Width - 1;
		int nPage = PageSize.Width;
		if (num < 1)
		{
			num = 0;
			nPage = 1;
		}
		NativeMethods.SCROLLINFO sCROLLINFO = new NativeMethods.SCROLLINFO();
		sCROLLINFO.fMask = NativeMethods.SIF.SIF_RANGE | NativeMethods.SIF.SIF_PAGE;
		if (AlwaysShowHScroll || !base.Enabled)
		{
			sCROLLINFO.fMask |= NativeMethods.SIF.SIF_DISABLENOSCROLL;
		}
		sCROLLINFO.nMin = 0;
		sCROLLINFO.nMax = num;
		sCROLLINFO.nPage = nPage;
		method_1(ScrollOrientation.HorizontalScroll, sCROLLINFO, bool_3: true);
	}

	protected void UpdateScrollbars()
	{
		UpdateHorizontalScrollbar();
		UpdateVerticalScrollbar();
	}

	protected virtual void UpdateVerticalScroll()
	{
		NativeMethods.SCROLLINFO sCROLLINFO = method_0(ScrollOrientation.VerticalScroll);
		VerticalScroll.Enabled = base.Enabled;
		VerticalScroll.LargeChange = sCROLLINFO.nPage;
		VerticalScroll.Maximum = sCROLLINFO.nMax;
		VerticalScroll.Minimum = sCROLLINFO.nMin;
		VerticalScroll.SmallChange = StepSize.Height;
		VerticalScroll.Value = sCROLLINFO.nPos;
		VerticalScroll.Visible = true;
	}

	protected virtual void UpdateVerticalScrollbar()
	{
		int num = ScrollSize.Height - 1;
		int nPage = PageSize.Height;
		if (num < 1)
		{
			num = 0;
			nPage = 1;
		}
		NativeMethods.SCROLLINFO sCROLLINFO = new NativeMethods.SCROLLINFO();
		sCROLLINFO.fMask = NativeMethods.SIF.SIF_RANGE | NativeMethods.SIF.SIF_PAGE;
		if (AlwaysShowVScroll)
		{
			sCROLLINFO.fMask |= NativeMethods.SIF.SIF_DISABLENOSCROLL;
		}
		sCROLLINFO.nMin = 0;
		sCROLLINFO.nMax = num;
		sCROLLINFO.nPage = nPage;
		method_1(ScrollOrientation.VerticalScroll, sCROLLINFO, bool_3: true);
	}

	protected virtual void WmScroll(ref Message msg)
	{
		ScrollEventType eventType = GetEventType(msg.WParam);
		ScrollOrientation scrollOrientation = ((msg.Msg != 276) ? ScrollOrientation.VerticalScroll : ScrollOrientation.HorizontalScroll);
		int num2;
		int newValue;
		if (eventType != ScrollEventType.EndScroll)
		{
			int num = ((scrollOrientation == ScrollOrientation.HorizontalScroll) ? StepSize.Width : StepSize.Height);
			NativeMethods.SCROLLINFO sCROLLINFO = method_0(scrollOrientation);
			sCROLLINFO.fMask = NativeMethods.SIF.SIF_POS;
			num2 = sCROLLINFO.nPos;
			switch (eventType)
			{
			case ScrollEventType.SmallDecrement:
				sCROLLINFO.nPos = num2 - num;
				break;
			case ScrollEventType.SmallIncrement:
				sCROLLINFO.nPos = num2 + num;
				break;
			case ScrollEventType.LargeDecrement:
				sCROLLINFO.nPos = num2 - sCROLLINFO.nPage;
				break;
			case ScrollEventType.LargeIncrement:
				sCROLLINFO.nPos = num2 + sCROLLINFO.nPage;
				break;
			case ScrollEventType.ThumbPosition:
			case ScrollEventType.ThumbTrack:
				sCROLLINFO.nPos = sCROLLINFO.nTrackPos;
				break;
			case ScrollEventType.First:
				sCROLLINFO.nPos = sCROLLINFO.nMin;
				break;
			case ScrollEventType.Last:
				sCROLLINFO.nPos = sCROLLINFO.nMax;
				break;
			}
			if (sCROLLINFO.nPos > sCROLLINFO.nMax - sCROLLINFO.nMin + 1 - sCROLLINFO.nPage)
			{
				sCROLLINFO.nPos = sCROLLINFO.nMax - sCROLLINFO.nMin + 1 - sCROLLINFO.nPage;
			}
			if (sCROLLINFO.nPos < sCROLLINFO.nMin)
			{
				sCROLLINFO.nPos = sCROLLINFO.nMin;
			}
			newValue = sCROLLINFO.nPos;
			method_1(scrollOrientation, sCROLLINFO, bool_3: true);
		}
		else
		{
			num2 = 0;
			newValue = 0;
		}
		OnScroll(new ScrollEventArgs(eventType, num2, newValue, scrollOrientation));
	}

	private NativeMethods.SCROLLINFO method_0(ScrollOrientation scrollOrientation_0)
	{
		NativeMethods.SCROLLINFO sCROLLINFO = new NativeMethods.SCROLLINFO();
		sCROLLINFO.fMask = NativeMethods.SIF.SIF_ALL;
		NativeMethods.GetScrollInfo(base.Handle, (int)scrollOrientation_0, sCROLLINFO);
		return sCROLLINFO;
	}

	private int method_1(ScrollOrientation scrollOrientation_0, NativeMethods.SCROLLINFO scrollinfo_0, bool bool_3)
	{
		return NativeMethods.SetScrollInfo(base.Handle, (int)scrollOrientation_0, scrollinfo_0, bool_3);
	}
}
