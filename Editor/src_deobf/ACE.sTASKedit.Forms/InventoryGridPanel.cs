using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

namespace ACE.sTASKedit.Forms;

public class InventoryGridPanel : Panel
{
	public struct SlotItem
	{
		public int ItemId;

		public string Name;

		public Image Icon;

		public int Count;
	}

	public const int Columns = 8;

	public const int MaxSlots = 128;

	public const int CellSize = 44;

	public const int IconSize = 32;

	private readonly Dictionary<int, SlotItem> dictionary_0 = new Dictionary<int, SlotItem>();

	private readonly List<int> list_0 = new List<int>();

	private int int_0 = -1;

	private Action<int, int> action_0;

	private Action action_1;

	public int UniqueItemCount => dictionary_0.Count;

	public int TotalItemCount
	{
		get
		{
			int num = 0;
			foreach (KeyValuePair<int, SlotItem> item in dictionary_0)
			{
				num += item.Value.Count;
			}
			return num;
		}
	}

	public Dictionary<int, SlotItem> Items => dictionary_0;

	public List<int> OrderedIds => list_0;

	public event Action<int, int> SlotHovered
	{
		[CompilerGenerated]
		add
		{
			Action<int, int> action = action_0;
			Action<int, int> action2;
			do
			{
				action2 = action;
				Action<int, int> value2 = (Action<int, int>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<int, int> action = action_0;
			Action<int, int> action2;
			do
			{
				action2 = action;
				Action<int, int> value2 = (Action<int, int>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_0, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public event Action SlotLeft
	{
		[CompilerGenerated]
		add
		{
			Action action = action_1;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = action_1;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref action_1, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public InventoryGridPanel()
	{
		DoubleBuffered = true;
		AutoScroll = true;
		SetStyle(ControlStyles.Selectable, value: false);
		base.AutoScrollMinSize = new Size(352, 704);
	}

	public void SetToolTipText(string text)
	{
	}

	public int GetItemIdAtSlot(int slot)
	{
		if (slot >= 0 && slot < list_0.Count)
		{
			return list_0[slot];
		}
		return 0;
	}

	public void AddItem(int itemId, string name, Image icon, int count)
	{
		if (dictionary_0.TryGetValue(itemId, out var value))
		{
			value.Count += count;
			dictionary_0[itemId] = value;
		}
		else if (dictionary_0.Count < 128)
		{
			dictionary_0[itemId] = new SlotItem
			{
				ItemId = itemId,
				Name = name,
				Icon = icon,
				Count = count
			};
			list_0.Add(itemId);
		}
	}

	public void ClearItems()
	{
		dictionary_0.Clear();
		list_0.Clear();
		int_0 = -1;
		Invalidate();
	}

	public void RefreshGrid()
	{
		Invalidate();
	}

	private int method_0(int int_1, int int_2)
	{
		int num = int_1 - base.AutoScrollPosition.X;
		int num2 = int_2 - base.AutoScrollPosition.Y;
		if (num >= 0 && num2 >= 0)
		{
			int num3 = num / 44;
			int num4 = num2 / 44;
			if (num3 >= 8)
			{
				return -1;
			}
			int num5 = num4 * 8 + num3;
			if (num5 >= 128)
			{
				return -1;
			}
			return num5;
		}
		return -1;
	}

	protected override void OnMouseMove(MouseEventArgs mea)
	{
		base.OnMouseMove(mea);
		int num = method_0(mea.X, mea.Y);
		if (num != int_0)
		{
			int_0 = num;
			if (num >= 0 && num < list_0.Count)
			{
				action_0?.Invoke(num, list_0[num]);
			}
			else
			{
				action_1?.Invoke();
			}
			Invalidate();
		}
	}

	protected override void OnMouseLeave(EventArgs eventArgs_0)
	{
		base.OnMouseLeave(eventArgs_0);
		if (int_0 != -1)
		{
			int_0 = -1;
			action_1?.Invoke();
			Invalidate();
		}
	}

	protected override void OnPaint(PaintEventArgs paintEventArgs_0)
	{
		base.OnPaint(paintEventArgs_0);
		try
		{
			method_1(paintEventArgs_0.Graphics);
		}
		catch
		{
		}
	}

	private void method_1(Graphics graphics_0)
	{
		graphics_0.TranslateTransform(base.AutoScrollPosition.X, base.AutoScrollPosition.Y);
		graphics_0.InterpolationMode = InterpolationMode.HighQualityBicubic;
		Pen pen = new Pen(Color.FromArgb(60, 60, 60));
		try
		{
			Pen pen2 = new Pen(Color.FromArgb(120, 180, 255), 2f);
			try
			{
				SolidBrush solidBrush = new SolidBrush(Color.FromArgb(35, 35, 40));
				try
				{
					SolidBrush solidBrush2 = new SolidBrush(Color.FromArgb(45, 45, 55));
					try
					{
						Font font = new Font(Class16.smethod_0(1648942905), 7.5f, FontStyle.Bold);
						try
						{
							SolidBrush solidBrush3 = new SolidBrush(Color.FromArgb(180, 0, 0, 0));
							try
							{
								for (int i = 0; i < 128; i++)
								{
									int num = i % 8;
									int num2 = i / 8;
									Rectangle rectangle = new Rectangle(num * 44, num2 * 44, 43, 43);
									if (i < list_0.Count)
									{
										graphics_0.FillRectangle(solidBrush2, rectangle);
										SlotItem slotItem = dictionary_0[list_0[i]];
										int num3 = rectangle.X + 5;
										int num4 = rectangle.Y + 5;
										if (slotItem.Icon != null)
										{
											graphics_0.DrawImage(slotItem.Icon, num3, num4, 32, 32);
										}
										smethod_0(graphics_0, font, solidBrush3, rectangle, slotItem.Count);
									}
									else
									{
										graphics_0.FillRectangle(solidBrush, rectangle);
									}
									graphics_0.DrawRectangle((i == int_0) ? pen2 : pen, rectangle);
								}
							}
							finally
							{
								((IDisposable)solidBrush3).Dispose();
							}
						}
						finally
						{
							((IDisposable)font).Dispose();
						}
					}
					finally
					{
						((IDisposable)solidBrush2).Dispose();
					}
				}
				finally
				{
					((IDisposable)solidBrush).Dispose();
				}
			}
			finally
			{
				((IDisposable)pen2).Dispose();
			}
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private static void smethod_0(Graphics graphics_0, Font font_0, Brush brush_0, Rectangle rectangle_0, int int_1)
	{
		if (int_1 > 0)
		{
			string s = ((int_1 > 999999) ? (int_1 / 1000 + Class16.smethod_0(1649250716)) : int_1.ToString());
			SizeF sizeF = graphics_0.MeasureString(s, font_0);
			float num = (float)rectangle_0.Right - sizeF.Width - 1f;
			float num2 = (float)rectangle_0.Bottom - sizeF.Height;
			graphics_0.DrawString(s, font_0, brush_0, num + 1f, num2 + 1f);
			graphics_0.DrawString(s, font_0, Brushes.White, num, num2);
		}
	}
}
