using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ACE.Dependency.Cyotek.Windows.Forms.ImageBox;

[ToolboxItem(false)]
public class VirtualScrollableControl : ScrollControl
{
	private bool bool_3;

	private Size size_3;

	private Size size_4;

	private Point point_0;

	private EventHandler eventHandler_4;

	private EventHandler eventHandler_5;

	private EventHandler eventHandler_6;

	private EventHandler eventHandler_7;

	[Category("Layout")]
	[DefaultValue(true)]
	public virtual bool AutoScroll
	{
		get
		{
			return bool_3;
		}
		set
		{
			if (AutoScroll != value)
			{
				bool_3 = value;
				OnAutoScrollChanged(EventArgs.Empty);
			}
		}
	}

	[Category("Layout")]
	[DefaultValue(typeof(Size), "0, 0")]
	public virtual Size AutoScrollMargin
	{
		get
		{
			return size_3;
		}
		set
		{
			if (value.Width < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648893426), Class16.smethod_0(1648893234));
			}
			if (value.Height < 0)
			{
				throw new ArgumentOutOfRangeException(Class16.smethod_0(1648892421), Class16.smethod_0(1648893293));
			}
			if (AutoScrollMargin != value)
			{
				size_3 = value;
				OnAutoScrollMarginChanged(EventArgs.Empty);
			}
		}
	}

	[DefaultValue(typeof(Size), "0, 0")]
	[Category("Layout")]
	public virtual Size AutoScrollMinSize
	{
		get
		{
			return size_4;
		}
		set
		{
			if (AutoScrollMinSize != value)
			{
				size_4 = value;
				OnAutoScrollMinSizeChanged(EventArgs.Empty);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public virtual Point AutoScrollPosition
	{
		get
		{
			return point_0;
		}
		set
		{
			Point point = AdjustPositionToSize(new Point(-value.X, -value.Y));
			if (AutoScrollPosition != point)
			{
				method_3(new Size(point_0.X - point.X, point_0.Y - point.Y));
				point_0 = point;
				OnAutoScrollPositionChanged(EventArgs.Empty);
			}
		}
	}

	protected Rectangle ScrollArea
	{
		get
		{
			Rectangle rectangle = Rectangle.Empty;
			foreach (Control control in base.Controls)
			{
				if (control.Visible)
				{
					rectangle = Rectangle.Union(control.Bounds, rectangle);
				}
			}
			return Rectangle.Union(rectangle, new Rectangle(point_0, size_4));
		}
	}

	protected Rectangle ViewPortRectangle => new Rectangle(-point_0.X, -point_0.Y, DisplayRectangle.Width, DisplayRectangle.Height);

	[Category("Property Changed")]
	public event EventHandler AutoScrollChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_4;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AutoScrollMarginChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_5;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_5;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AutoScrollMinSizeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	[Category("Property Changed")]
	public event EventHandler AutoScrollPositionChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_7;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public VirtualScrollableControl()
	{
		AutoScrollMargin = Size.Empty;
		AutoScrollMinSize = Size.Empty;
		AutoScrollPosition = Point.Empty;
		AutoScroll = true;
		SetStyle(ControlStyles.ContainerControl, value: true);
	}

	protected override void OnResize(EventArgs eventArgs_0)
	{
		base.OnResize(eventArgs_0);
		method_2();
		if (AutoScroll && !AutoScrollPosition.IsEmpty)
		{
			Rectangle scrollArea = ScrollArea;
			int num = scrollArea.Right - DisplayRectangle.Right;
			int num2 = scrollArea.Bottom - DisplayRectangle.Bottom;
			num2 = ((AutoScrollPosition.Y < 0 && num2 < 0) ? Math.Max(num2, AutoScrollPosition.Y) : 0);
			num = ((AutoScrollPosition.X < 0 && num < 0) ? Math.Max(num, AutoScrollPosition.X) : 0);
			method_3(new Size(num, num2));
		}
	}

	protected override void OnScroll(ScrollEventArgs se)
	{
		if (se.Type != ScrollEventType.EndScroll)
		{
			switch (se.ScrollOrientation)
			{
			case ScrollOrientation.VerticalScroll:
				method_3(new Size(0, se.NewValue + AutoScrollPosition.Y));
				break;
			case ScrollOrientation.HorizontalScroll:
				method_3(new Size(se.NewValue + AutoScrollPosition.X, 0));
				break;
			}
		}
		base.OnScroll(se);
	}

	protected override void OnVisibleChanged(EventArgs eventArgs_0)
	{
		if (base.Visible)
		{
			PerformLayout();
		}
		base.OnVisibleChanged(eventArgs_0);
	}

	public void ScrollControlIntoView(Control activeControl)
	{
		if (activeControl.Visible && AutoScroll && (base.HorizontalScroll.Visible || base.VerticalScroll.Visible))
		{
			Point point = AdjustPositionToSize(new Point(AutoScrollPosition.X + activeControl.Left, AutoScrollPosition.Y + activeControl.Top));
			if (point.X != AutoScrollPosition.X || point.Y != AutoScrollPosition.Y)
			{
				method_3(new Size(AutoScrollPosition.X - point.X, AutoScrollPosition.Y - point.Y));
			}
		}
	}

	protected Point AdjustPositionToSize(Point position)
	{
		int num = position.X;
		int num2 = position.Y;
		if (num < -(AutoScrollMinSize.Width - base.ClientRectangle.Width))
		{
			num = -(AutoScrollMinSize.Width - base.ClientRectangle.Width);
		}
		if (num2 < -(AutoScrollMinSize.Height - base.ClientRectangle.Height))
		{
			num2 = -(AutoScrollMinSize.Height - base.ClientRectangle.Height);
		}
		if (num > 0)
		{
			num = 0;
		}
		if (num2 > 0)
		{
			num2 = 0;
		}
		return new Point(num, num2);
	}

	protected virtual void OnAutoScrollChanged(EventArgs eventArgs_0)
	{
		eventHandler_4?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAutoScrollMarginChanged(EventArgs eventArgs_0)
	{
		eventHandler_5?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAutoScrollMinSizeChanged(EventArgs eventArgs_0)
	{
		AutoScrollPosition = AdjustPositionToSize(AutoScrollPosition);
		method_2();
		eventHandler_6?.Invoke(this, eventArgs_0);
	}

	protected virtual void OnAutoScrollPositionChanged(EventArgs eventArgs_0)
	{
		eventHandler_7?.Invoke(this, eventArgs_0);
	}

	private void method_2()
	{
		Rectangle clientRectangle = base.ClientRectangle;
		if (clientRectangle.Width > 1 && clientRectangle.Height > 1)
		{
			Size empty = Size.Empty;
			Size empty2 = Size.Empty;
			bool flag = AutoScroll && AutoScrollMinSize.Width > clientRectangle.Width;
			if (AutoScroll && AutoScrollMinSize.Height > clientRectangle.Height)
			{
				empty.Height = AutoScrollMinSize.Height;
				empty2.Height = clientRectangle.Height - 1;
			}
			if (flag)
			{
				empty.Width = AutoScrollMinSize.Width;
				empty2.Width = clientRectangle.Width - 1;
			}
			ScrollSize = empty;
			PageSize = empty2;
		}
	}

	private void method_3(Size size_5)
	{
		if (size_5.IsEmpty)
		{
			return;
		}
		SuspendLayout();
		foreach (Control control in base.Controls)
		{
			control.Location -= size_5;
		}
		point_0 = new Point(point_0.X - size_5.Width, point_0.Y - size_5.Height);
		ScrollTo(-point_0.X, -point_0.Y);
		ResumeLayout();
		Invalidate();
	}
}
