using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Properties;

namespace ACE.Classes;

public static class TDark
{
	private struct Struct48
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;
	}

	private enum Enum2
	{

	}

	private static class Class89
	{
		public static DrawToolTipEventHandler drawToolTipEventHandler_0;

		public static PopupEventHandler popupEventHandler_0;

		public static Delegate0 delegate0_0;

		public static EventHandler eventHandler_0;

		public static EventHandler eventHandler_1;

		public static EventHandler eventHandler_2;

		public static EventHandler eventHandler_3;

		public static EventHandler eventHandler_4;

		public static EventHandler eventHandler_5;

		public static EventHandler eventHandler_6;

		public static EventHandler eventHandler_7;

		public static EventHandler eventHandler_8;

		public static EventHandler eventHandler_9;

		public static ControlEventHandler controlEventHandler_0;

		public static EventHandler eventHandler_10;

		public static EventHandler eventHandler_11;

		public static EventHandler eventHandler_12;

		public static EventHandler eventHandler_13;

		public static EventHandler eventHandler_14;

		public static EventHandler eventHandler_15;

		public static EventHandler eventHandler_16;

		public static Delegate0 delegate0_1;

		public static DataGridViewEditingControlShowingEventHandler dataGridViewEditingControlShowingEventHandler_0;

		public static DataGridViewDataErrorEventHandler dataGridViewDataErrorEventHandler_0;

		public static DataGridViewRowsAddedEventHandler dataGridViewRowsAddedEventHandler_0;

		public static DataGridViewBindingCompleteEventHandler dataGridViewBindingCompleteEventHandler_0;

		public static PaintEventHandler paintEventHandler_0;

		public static DataGridViewCellPaintingEventHandler dataGridViewCellPaintingEventHandler_0;

		public static EventHandler eventHandler_17;

		public static DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler_0;

		public static EventHandler eventHandler_18;

		public static WebBrowserDocumentCompletedEventHandler webBrowserDocumentCompletedEventHandler_0;

		public static EventHandler eventHandler_19;

		public static ControlEventHandler controlEventHandler_1;

		public static EventHandler eventHandler_20;

		public static EventHandler eventHandler_21;

		public static EventHandler eventHandler_22;

		public static EventHandler eventHandler_23;

		public static EventHandler eventHandler_24;

		public static EventHandler eventHandler_25;

		public static PaintEventHandler paintEventHandler_1;

		public static PaintEventHandler paintEventHandler_2;

		public static PaintEventHandler paintEventHandler_3;

		public static DrawItemEventHandler drawItemEventHandler_0;

		public static DrawItemEventHandler drawItemEventHandler_1;

		public static DrawListViewColumnHeaderEventHandler drawListViewColumnHeaderEventHandler_0;

		public static DrawListViewItemEventHandler drawListViewItemEventHandler_0;

		public static DrawListViewSubItemEventHandler drawListViewSubItemEventHandler_0;

		public static DrawItemEventHandler drawItemEventHandler_2;

		public static ControlEventHandler controlEventHandler_2;

		public static EventHandler eventHandler_26;

		public static EventHandler eventHandler_27;

		public static EventHandler eventHandler_28;

		public static PaintEventHandler paintEventHandler_4;

		public static PaintEventHandler paintEventHandler_5;

		public static EventHandler eventHandler_29;

		public static EventHandler eventHandler_30;

		public static EventHandler eventHandler_31;

		public static EventHandler eventHandler_32;

		public static EventHandler eventHandler_33;

		public static EventHandler eventHandler_34;

		public static EventHandler eventHandler_35;

		public static EventHandler eventHandler_36;

		public static EventHandler eventHandler_37;

		public static EventHandler eventHandler_38;

		public static CancelEventHandler cancelEventHandler_0;

		public static EventHandler eventHandler_39;

		public static EventHandler eventHandler_40;

		public static EventHandler eventHandler_41;
	}

	private struct Struct49
	{
		public Color color_0;

		public Color color_1;

		public FlatStyle flatStyle_0;

		public BorderStyle borderStyle_0;

		public bool bool_0;

		public bool bool_1;

		public Image image_0;

		public Image image_1;
	}

	private delegate bool Delegate0(IntPtr intptr_0, IntPtr intptr_1);

	private sealed class Class90 : IMessageFilter
	{
		private sealed class Class91
		{
			public Form form_0;

			internal void method_0()
			{
				try
				{
					if (!form_0.IsDisposed && !form_0.Disposing && form_0.IsHandleCreated && !IsControlStored(form_0))
					{
						StoreOriginalColors(form_0);
						ApplyThemeToForm(form_0);
						smethod_1(form_0);
					}
				}
				catch
				{
				}
			}
		}

		public bool PreFilterMessage(ref Message message_0)
		{
			if (message_0.Msg == 272 || message_0.Msg == 1 || message_0.Msg == 24)
			{
				try
				{
					smethod_0(Control.FromHandle(message_0.HWnd) as Form);
					smethod_3(message_0.HWnd);
					smethod_2();
				}
				catch
				{
				}
			}
			return false;
		}

		private static void smethod_0(Form form_0)
		{
			Class91 @class = new Class91();
			@class.form_0 = form_0;
			if (@class.form_0 != null && !IsControlStored(@class.form_0))
			{
				@class.form_0.BeginInvokeSafe(@class.method_0);
			}
		}

		private static void smethod_1(Form form_0)
		{
			if (form_0 == null || !IsDarkMode)
			{
				return;
			}
			try
			{
				FieldInfo[] fields = form_0.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				FieldInfo[] array = fields;
				foreach (FieldInfo fieldInfo in array)
				{
					if (fieldInfo.FieldType == typeof(ToolTip) && fieldInfo.GetValue(form_0) is ToolTip toolTip)
					{
						ApplyThemeToToolTip(toolTip);
					}
				}
				FieldInfo field = form_0.GetType().GetField(Class16.smethod_0(1648902113), BindingFlags.Instance | BindingFlags.NonPublic);
				if (!(field != null) || !(field.GetValue(form_0) is IContainer container))
				{
					return;
				}
				foreach (IComponent component in container.Components)
				{
					if (component is ToolTip toolTip2)
					{
						ApplyThemeToToolTip(toolTip2);
					}
				}
			}
			catch
			{
			}
		}

		private static void smethod_2()
		{
			try
			{
				foreach (Form openForm in Application.OpenForms)
				{
					smethod_0(openForm);
				}
			}
			catch
			{
			}
		}

		private static void smethod_3(IntPtr intptr_0)
		{
			smethod_5(intptr_0);
		}
	}

	private struct Struct50
	{
		public Color color_0;

		public Color color_1;

		public DataGridViewCellStyle dataGridViewCellStyle_0;

		public DataGridViewCellStyle dataGridViewCellStyle_1;

		public DataGridViewCellStyle dataGridViewCellStyle_2;

		public DataGridViewCellStyle dataGridViewCellStyle_3;

		public DataGridViewCellStyle dataGridViewCellStyle_4;

		public bool bool_0;
	}

	private sealed class Class92 : ProfessionalColorTable
	{
		public override Color MenuItemSelected => Color.FromArgb(62, 62, 64);

		public override Color MenuItemBorder => DarkBorder;

		public override Color MenuBorder => DarkBorder;

		public override Color MenuItemPressedGradientBegin => DarkHeaderBack;

		public override Color MenuItemPressedGradientEnd => DarkHeaderBack;

		public override Color MenuItemSelectedGradientBegin => Color.FromArgb(62, 62, 64);

		public override Color MenuItemSelectedGradientEnd => Color.FromArgb(62, 62, 64);

		public override Color ToolStripDropDownBackground => DarkControlBack;

		public override Color ImageMarginGradientBegin => Color.FromArgb(42, 42, 44);

		public override Color ImageMarginGradientMiddle => Color.FromArgb(42, 42, 44);

		public override Color ImageMarginGradientEnd => Color.FromArgb(42, 42, 44);

		public override Color ToolStripGradientBegin => DarkHeaderBack;

		public override Color ToolStripGradientMiddle => DarkHeaderBack;

		public override Color ToolStripGradientEnd => DarkHeaderBack;

		public override Color ToolStripContentPanelGradientBegin => DarkBack;

		public override Color ToolStripContentPanelGradientEnd => DarkBack;

		public override Color ToolStripPanelGradientBegin => DarkBack;

		public override Color ToolStripPanelGradientEnd => DarkBack;

		public override Color SeparatorDark => Color.FromArgb(51, 51, 55);

		public override Color SeparatorLight => Color.FromArgb(51, 51, 55);

		public override Color ButtonSelectedBorder => DarkBorder;

		public override Color ButtonPressedBorder => DarkBorder;

		public override Color ButtonSelectedHighlight => Color.FromArgb(62, 62, 64);

		public override Color ButtonCheckedHighlight => Color.FromArgb(62, 62, 64);

		public override Color ButtonPressedHighlight => DarkHeaderBack;

		public override Color ButtonCheckedGradientBegin => DarkHeaderBack;

		public override Color ButtonCheckedGradientEnd => DarkHeaderBack;

		public override Color ButtonCheckedGradientMiddle => DarkHeaderBack;

		public override Color ButtonPressedGradientBegin => DarkHeaderBack;

		public override Color ButtonPressedGradientEnd => DarkHeaderBack;

		public override Color ButtonPressedGradientMiddle => DarkHeaderBack;

		public override Color ButtonSelectedGradientBegin => Color.FromArgb(62, 62, 64);

		public override Color ButtonSelectedGradientEnd => Color.FromArgb(62, 62, 64);

		public override Color ButtonSelectedGradientMiddle => Color.FromArgb(62, 62, 64);
	}

	private struct Struct51
	{
		public int int_0;

		public Struct48 struct48_0;

		public Struct48 struct48_1;

		public int int_1;

		public IntPtr intptr_0;

		public IntPtr intptr_1;

		public IntPtr intptr_2;
	}

	private sealed class Class93 : ToolStripProfessionalRenderer
	{
		public Class93()
			: base(new Class92())
		{
			base.RoundedEdges = false;
		}

		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
		{
			if (!IsDarkMode)
			{
				base.OnRenderToolStripBackground(toolStripRenderEventArgs_0);
				return;
			}
			Color color = ((toolStripRenderEventArgs_0.ToolStrip is StatusStrip) ? DarkHeaderBack : DarkControlBack);
			SolidBrush solidBrush = new SolidBrush(color);
			try
			{
				toolStripRenderEventArgs_0.Graphics.FillRectangle(solidBrush, toolStripRenderEventArgs_0.AffectedBounds);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}

		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs toolStripRenderEventArgs_0)
		{
			if (!IsDarkMode)
			{
				base.OnRenderToolStripBorder(toolStripRenderEventArgs_0);
				return;
			}
			Pen pen = new Pen(DarkBorderSoft);
			try
			{
				Rectangle affectedBounds = toolStripRenderEventArgs_0.AffectedBounds;
				toolStripRenderEventArgs_0.Graphics.DrawLine(pen, affectedBounds.Left, affectedBounds.Top, affectedBounds.Right - 1, affectedBounds.Top);
				toolStripRenderEventArgs_0.Graphics.DrawLine(pen, affectedBounds.Left, affectedBounds.Bottom - 1, affectedBounds.Right - 1, affectedBounds.Bottom - 1);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}

		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs toolStripItemRenderEventArgs_0)
		{
			if (IsDarkMode && toolStripItemRenderEventArgs_0.Item != null)
			{
				Rectangle rect = new Rectangle(Point.Empty, toolStripItemRenderEventArgs_0.Item.Size);
				Color color = DarkControlBack;
				if (toolStripItemRenderEventArgs_0.Item.Enabled)
				{
					if (toolStripItemRenderEventArgs_0.Item.Pressed)
					{
						color = DarkHeaderBack;
					}
					else if (toolStripItemRenderEventArgs_0.Item.Selected)
					{
						color = DarkSelectionBack;
					}
				}
				SolidBrush solidBrush = new SolidBrush(color);
				try
				{
					toolStripItemRenderEventArgs_0.Graphics.FillRectangle(solidBrush, rect);
				}
				finally
				{
					((IDisposable)solidBrush).Dispose();
				}
				if (toolStripItemRenderEventArgs_0.Item.Selected || toolStripItemRenderEventArgs_0.Item.Pressed)
				{
					Pen pen = new Pen(DarkBorder);
					try
					{
						toolStripItemRenderEventArgs_0.Graphics.DrawRectangle(pen, 0, 0, rect.Width - 1, rect.Height - 1);
					}
					finally
					{
						((IDisposable)pen).Dispose();
					}
				}
			}
			else
			{
				base.OnRenderMenuItemBackground(toolStripItemRenderEventArgs_0);
			}
		}

		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs toolStripItemTextRenderEventArgs_0)
		{
			if (IsDarkMode && toolStripItemTextRenderEventArgs_0?.Item != null)
			{
				toolStripItemTextRenderEventArgs_0.TextColor = ((!toolStripItemTextRenderEventArgs_0.Item.Enabled) ? DarkDisabledFore : (HasCustomTextColor(toolStripItemTextRenderEventArgs_0.Item) ? toolStripItemTextRenderEventArgs_0.Item.ForeColor : DarkFore));
			}
			base.OnRenderItemText(toolStripItemTextRenderEventArgs_0);
		}

		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs toolStripArrowRenderEventArgs_0)
		{
			if (IsDarkMode)
			{
				toolStripArrowRenderEventArgs_0.ArrowColor = (toolStripArrowRenderEventArgs_0.Item.Enabled ? Color.FromArgb(180, 180, 180) : DarkDisabledFore);
			}
			base.OnRenderArrow(toolStripArrowRenderEventArgs_0);
		}

		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs toolStripItemImageRenderEventArgs_0)
		{
			if (IsDarkMode)
			{
				Rectangle imageRectangle = toolStripItemImageRenderEventArgs_0.ImageRectangle;
				imageRectangle.Inflate(1, 1);
				SolidBrush solidBrush = new SolidBrush(DarkBorder);
				try
				{
					toolStripItemImageRenderEventArgs_0.Graphics.FillRectangle(solidBrush, imageRectangle);
				}
				finally
				{
					((IDisposable)solidBrush).Dispose();
				}
			}
			base.OnRenderItemCheck(toolStripItemImageRenderEventArgs_0);
		}
	}

	private sealed class Class94
	{
		public DateTimePicker dateTimePicker_0;

		public int int_0;

		public Timer timer_0;

		internal void method_0(object sender, EventArgs e)
		{
			try
			{
				smethod_30(dateTimePicker_0);
				smethod_32();
				int_0++;
				if (int_0 >= 3 || dateTimePicker_0.IsDisposed)
				{
					timer_0.Stop();
					timer_0.Dispose();
				}
			}
			catch
			{
				timer_0.Stop();
				timer_0.Dispose();
			}
		}
	}

	private static bool bool_0;

	private static readonly string string_0;

	private static Dictionary<Control, Struct49> dictionary_0;

	private static Dictionary<ToolStrip, ToolStripRenderer> dictionary_1;

	private static Dictionary<ToolStripItem, Image> dictionary_2;

	private static Dictionary<DataGridView, Struct50> dictionary_3;

	private static readonly HashSet<ComboBox> hashSet_0;

	private static readonly HashSet<RadioButton> hashSet_1;

	private static readonly HashSet<DateTimePicker> hashSet_2;

	private static readonly HashSet<DataGridView> hashSet_3;

	private static readonly HashSet<WebBrowser> hashSet_4;

	private static readonly HashSet<NumericUpDown> hashSet_5;

	private static readonly HashSet<MonthCalendar> hashSet_6;

	private static readonly HashSet<Control> hashSet_7;

	private static readonly HashSet<Control> hashSet_8;

	public static readonly Color DarkBack;

	public static readonly Color DarkFore;

	public static readonly Color DarkControlBack;

	public static readonly Color DarkControlFore;

	public static readonly Color DarkDisabledFore;

	public static readonly Color DarkButtonDisabledBack;

	public static readonly Color DarkCheckAccent;

	public static readonly Color DarkDisabledCheckAccent;

	public static readonly Color DarkButtonBack;

	public static readonly Color DarkButtonFore;

	public static readonly Color DarkBorder;

	public static readonly Color DarkBorderSoft;

	public static readonly Color DarkGroupBoxTitleFore;

	public static readonly Color DarkLabelFore;

	public static readonly Color DarkNameCardBack;

	public static readonly Color DarkGridLine;

	public static readonly Color DarkSelectionBack;

	public static readonly Color DarkSelectionFore;

	public static readonly Color DarkAlternateRowBack;

	public static readonly Color DarkHeaderBack;

	public static readonly Color DarkHover;

	public static readonly Color DarkReadOnlyBack;

	private static readonly ToolStripRenderer toolStripRenderer_0;

	private static readonly HashSet<ToolStripDropDown> hashSet_9;

	public static readonly Color DarkFieldDefault;

	public static readonly Color DarkFieldReference;

	public static readonly Color DarkFieldFloat;

	public static readonly Color DarkFieldString;

	public static readonly Color DarkFieldDouble;

	public static readonly Color DarkFieldSeparator;

	public static readonly Color DarkFieldFore;

	public static readonly Color DarkFieldForeBlue;

	public static readonly Color DarkFieldForeBlack;

	public static readonly Color DarkIdFieldBack;

	public static readonly Color DarkIdFieldCyan;

	public static readonly Color LightFieldDefault;

	public static readonly Color LightFieldReference;

	public static readonly Color LightFieldFloat;

	public static readonly Color LightFieldString;

	public static readonly Color LightFieldDouble;

	public static readonly Color LightFieldSeparator;

	public static readonly Color LightFieldFore;

	public static readonly Color LightFieldForeBlue;

	public static readonly Color LightIdFieldBack;

	public static readonly Color LightIdFieldCyan;

	private static readonly Dictionary<ListView, bool> dictionary_4;

	private static readonly HashSet<int> hashSet_10;

	private static readonly Dictionary<int, Color> dictionary_5;

	private static readonly Dictionary<int, Color> dictionary_6;

	private static readonly Dictionary<int, Color> dictionary_7;

	private static readonly Dictionary<int, Color> dictionary_8;

	private static readonly HashSet<TabControl> hashSet_11;

	private static readonly HashSet<TabControl> hashSet_12;

	private static readonly HashSet<GroupBox> hashSet_13;

	private static readonly HashSet<Button> hashSet_14;

	private static readonly HashSet<CheckBox> hashSet_15;

	private static readonly HashSet<RadioButton> hashSet_16;

	private static readonly HashSet<CheckedListBox> hashSet_17;

	private static readonly HashSet<ListBox> hashSet_18;

	private static readonly HashSet<TextBoxBase> hashSet_19;

	private static readonly HashSet<long> hashSet_20;

	private static readonly Dictionary<long, Image> dictionary_9;

	private static readonly object object_0;

	public static bool IsDarkMode
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
			smethod_4();
			smethod_0();
		}
	}

	public static Color FieldDefaultBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldDefault;
			}
			return DarkFieldDefault;
		}
	}

	public static Color FieldReferenceBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldReference;
			}
			return DarkFieldReference;
		}
	}

	public static Color FieldFloatBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldFloat;
			}
			return DarkFieldFloat;
		}
	}

	public static Color FieldStringBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldString;
			}
			return DarkFieldString;
		}
	}

	public static Color FieldDoubleBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldDouble;
			}
			return DarkFieldDouble;
		}
	}

	public static Color FieldSeparatorBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldSeparator;
			}
			return DarkFieldSeparator;
		}
	}

	public static Color FieldFore
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldFore;
			}
			return DarkFieldForeBlack;
		}
	}

	public static Color FieldForeBlue
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightFieldForeBlue;
			}
			return DarkFieldForeBlue;
		}
	}

	public static Color IdFieldBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightIdFieldBack;
			}
			return DarkIdFieldBack;
		}
	}

	public static Color IdFieldCyanBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return LightIdFieldCyan;
			}
			return DarkIdFieldCyan;
		}
	}

	public static Color SearchIdleBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return Color.FromArgb(220, 255, 255);
			}
			return Color.FromArgb(35, 52, 58);
		}
	}

	public static Color SearchMatchBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return Color.FromArgb(220, 255, 255);
			}
			return Color.FromArgb(36, 78, 56);
		}
	}

	public static Color SearchErrorBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return Color.FromArgb(255, 100, 100);
			}
			return Color.FromArgb(99, 50, 50);
		}
	}

	public static Color SearchEditBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return Color.LightGreen;
			}
			return Color.FromArgb(48, 64, 74);
		}
	}

	public static Color NumericDefaultBack
	{
		get
		{
			if (!IsDarkMode)
			{
				return Color.White;
			}
			return DarkControlBack;
		}
	}

	static TDark()
	{
		bool_0 = false;
		string_0 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648902130));
		dictionary_0 = new Dictionary<Control, Struct49>();
		dictionary_1 = new Dictionary<ToolStrip, ToolStripRenderer>();
		dictionary_2 = new Dictionary<ToolStripItem, Image>();
		dictionary_3 = new Dictionary<DataGridView, Struct50>();
		hashSet_0 = new HashSet<ComboBox>();
		hashSet_1 = new HashSet<RadioButton>();
		hashSet_2 = new HashSet<DateTimePicker>();
		hashSet_3 = new HashSet<DataGridView>();
		hashSet_4 = new HashSet<WebBrowser>();
		hashSet_5 = new HashSet<NumericUpDown>();
		hashSet_6 = new HashSet<MonthCalendar>();
		hashSet_7 = new HashSet<Control>();
		hashSet_8 = new HashSet<Control>();
		DarkBack = Color.FromArgb(30, 30, 30);
		DarkFore = Color.FromArgb(236, 236, 236);
		DarkControlBack = Color.FromArgb(37, 37, 38);
		DarkControlFore = Color.FromArgb(238, 238, 238);
		DarkDisabledFore = Color.FromArgb(168, 168, 168);
		DarkButtonDisabledBack = Color.FromArgb(42, 42, 45);
		DarkCheckAccent = Color.FromArgb(0, 120, 215);
		DarkDisabledCheckAccent = Color.FromArgb(60, 60, 65);
		DarkButtonBack = Color.FromArgb(50, 50, 54);
		DarkButtonFore = Color.FromArgb(232, 232, 232);
		DarkBorder = Color.FromArgb(60, 60, 65);
		DarkBorderSoft = Color.FromArgb(40, 40, 44);
		DarkGroupBoxTitleFore = Color.FromArgb(214, 214, 214);
		DarkLabelFore = Color.FromArgb(200, 200, 200);
		DarkNameCardBack = Color.FromArgb(32, 36, 44);
		DarkGridLine = Color.FromArgb(45, 45, 48);
		DarkSelectionBack = Color.FromArgb(43, 85, 117);
		DarkSelectionFore = Color.FromArgb(255, 255, 255);
		DarkAlternateRowBack = Color.FromArgb(42, 42, 44);
		DarkHeaderBack = Color.FromArgb(45, 45, 48);
		DarkHover = Color.FromArgb(64, 64, 72);
		DarkReadOnlyBack = Color.FromArgb(33, 33, 36);
		toolStripRenderer_0 = new Class93();
		hashSet_9 = new HashSet<ToolStripDropDown>();
		DarkFieldDefault = Color.FromArgb(37, 37, 38);
		DarkFieldReference = Color.FromArgb(32, 56, 42);
		DarkFieldFloat = Color.FromArgb(58, 54, 34);
		DarkFieldString = Color.FromArgb(32, 54, 58);
		DarkFieldDouble = Color.FromArgb(34, 48, 70);
		DarkFieldSeparator = Color.FromArgb(58, 58, 62);
		DarkFieldFore = Color.FromArgb(224, 224, 224);
		DarkFieldForeBlue = Color.FromArgb(103, 181, 255);
		DarkFieldForeBlack = Color.FromArgb(238, 238, 238);
		DarkIdFieldBack = Color.FromArgb(48, 46, 30);
		DarkIdFieldCyan = Color.FromArgb(30, 46, 48);
		LightFieldDefault = Color.White;
		LightFieldReference = Color.FromArgb(225, 255, 225);
		LightFieldFloat = Color.FromArgb(255, 255, 230);
		LightFieldString = Color.FromArgb(230, 255, 255);
		LightFieldDouble = Color.LightBlue;
		LightFieldSeparator = Color.WhiteSmoke;
		LightFieldFore = Color.Black;
		LightFieldForeBlue = Color.Blue;
		LightIdFieldBack = Color.FromArgb(255, 255, 225);
		LightIdFieldCyan = Color.LightCyan;
		dictionary_4 = new Dictionary<ListView, bool>();
		hashSet_10 = new HashSet<int>
		{
			Color.Blue.ToArgb(),
			Color.Red.ToArgb(),
			Color.Green.ToArgb(),
			Color.Yellow.ToArgb(),
			Color.Orange.ToArgb(),
			Color.Purple.ToArgb(),
			Color.Gold.ToArgb(),
			Color.Cyan.ToArgb(),
			Color.Magenta.ToArgb(),
			Color.LightBlue.ToArgb(),
			Color.LightGreen.ToArgb(),
			Color.LightCoral.ToArgb(),
			Color.DodgerBlue.ToArgb(),
			Color.CornflowerBlue.ToArgb(),
			Color.Lime.ToArgb(),
			Color.Crimson.ToArgb(),
			Color.DarkOrange.ToArgb(),
			Color.FromArgb(0, 191, 179).ToArgb(),
			Color.FromArgb(0, 122, 204).ToArgb(),
			Color.FromArgb(220, 220, 220).ToArgb()
		};
		dictionary_5 = new Dictionary<int, Color>();
		dictionary_6 = new Dictionary<int, Color>();
		dictionary_7 = new Dictionary<int, Color>();
		dictionary_8 = new Dictionary<int, Color>();
		hashSet_11 = new HashSet<TabControl>();
		hashSet_12 = new HashSet<TabControl>();
		hashSet_13 = new HashSet<GroupBox>();
		hashSet_14 = new HashSet<Button>();
		hashSet_15 = new HashSet<CheckBox>();
		hashSet_16 = new HashSet<RadioButton>();
		hashSet_17 = new HashSet<CheckedListBox>();
		hashSet_18 = new HashSet<ListBox>();
		hashSet_19 = new HashSet<TextBoxBase>();
		hashSet_20 = new HashSet<long>();
		dictionary_9 = new Dictionary<long, Image>();
		object_0 = new object();
		dictionary_5[Color.White.ToArgb()] = DarkFieldDefault;
		dictionary_5[Color.FromArgb(225, 255, 225).ToArgb()] = DarkFieldReference;
		dictionary_5[Color.FromArgb(192, 255, 192).ToArgb()] = DarkFieldReference;
		dictionary_5[Color.FromArgb(255, 255, 230).ToArgb()] = DarkFieldFloat;
		dictionary_5[Color.LightYellow.ToArgb()] = DarkFieldFloat;
		dictionary_5[Color.FromArgb(230, 255, 255).ToArgb()] = DarkFieldString;
		dictionary_5[Color.LightBlue.ToArgb()] = DarkFieldDouble;
		dictionary_5[Color.WhiteSmoke.ToArgb()] = DarkFieldSeparator;
		dictionary_5[Color.FromArgb(255, 255, 225).ToArgb()] = DarkIdFieldBack;
		dictionary_5[Color.LightCyan.ToArgb()] = DarkIdFieldCyan;
		dictionary_5[SystemColors.Control.ToArgb()] = DarkHeaderBack;
		dictionary_5[Color.FromArgb(239, 244, 250).ToArgb()] = DarkBack;
		dictionary_5[Color.FromArgb(238, 245, 250).ToArgb()] = DarkControlBack;
		dictionary_5[Color.FromArgb(240, 244, 250).ToArgb()] = DarkControlBack;
		dictionary_5[Color.FromArgb(232, 240, 249).ToArgb()] = DarkControlBack;
		dictionary_5[Color.FromArgb(127, 255, 255, 255).ToArgb()] = DarkControlBack;
		dictionary_5[Color.FromArgb(220, 255, 255).ToArgb()] = DarkFieldString;
		dictionary_5[Color.FromArgb(255, 255, 128).ToArgb()] = DarkIdFieldBack;
		dictionary_5[SystemColors.Window.ToArgb()] = DarkControlBack;
		dictionary_5[Color.FromArgb(255, 255, 192).ToArgb()] = DarkIdFieldBack;
		dictionary_5[Color.FromArgb(192, 255, 255).ToArgb()] = DarkFieldString;
		dictionary_5[SystemColors.InactiveBorder.ToArgb()] = DarkHeaderBack;
		dictionary_5[SystemColors.ButtonFace.ToArgb()] = DarkButtonBack;
		dictionary_5[SystemColors.ControlLight.ToArgb()] = DarkControlBack;
		dictionary_5[SystemColors.ControlLightLight.ToArgb()] = DarkControlBack;
		dictionary_5[SystemColors.Menu.ToArgb()] = DarkHeaderBack;
		dictionary_5[SystemColors.MenuBar.ToArgb()] = DarkHeaderBack;
		dictionary_5[Color.Gainsboro.ToArgb()] = DarkControlBack;
		dictionary_5[Color.LightGray.ToArgb()] = DarkControlBack;
		dictionary_5[Color.FromArgb(240, 240, 240).ToArgb()] = DarkControlBack;
		dictionary_5[Color.FromArgb(245, 245, 245).ToArgb()] = DarkControlBack;
		dictionary_6[DarkFieldDefault.ToArgb()] = Color.White;
		dictionary_6[DarkFieldReference.ToArgb()] = Color.FromArgb(225, 255, 225);
		dictionary_6[DarkFieldFloat.ToArgb()] = Color.FromArgb(255, 255, 230);
		dictionary_6[DarkFieldString.ToArgb()] = Color.FromArgb(230, 255, 255);
		dictionary_6[DarkFieldDouble.ToArgb()] = Color.LightBlue;
		dictionary_6[DarkFieldSeparator.ToArgb()] = Color.WhiteSmoke;
		dictionary_6[DarkIdFieldBack.ToArgb()] = Color.FromArgb(255, 255, 225);
		dictionary_6[DarkIdFieldCyan.ToArgb()] = Color.LightCyan;
		dictionary_6[DarkHeaderBack.ToArgb()] = SystemColors.Control;
		dictionary_6[DarkBack.ToArgb()] = Color.FromArgb(239, 244, 250);
		dictionary_6[DarkControlBack.ToArgb()] = SystemColors.Window;
		dictionary_6[DarkButtonBack.ToArgb()] = SystemColors.ButtonFace;
		dictionary_7[Color.Black.ToArgb()] = DarkFieldFore;
		dictionary_7[Color.Blue.ToArgb()] = DarkFieldForeBlue;
		dictionary_7[Color.DarkGray.ToArgb()] = Color.FromArgb(188, 188, 188);
		dictionary_7[Color.DimGray.ToArgb()] = Color.FromArgb(174, 174, 174);
		dictionary_7[Color.Gray.ToArgb()] = Color.FromArgb(192, 192, 192);
		dictionary_7[Color.FromArgb(64, 64, 64).ToArgb()] = Color.FromArgb(182, 182, 182);
		dictionary_7[Color.FromArgb(80, 80, 80).ToArgb()] = Color.FromArgb(188, 188, 188);
		dictionary_7[Color.FromArgb(96, 96, 96).ToArgb()] = Color.FromArgb(196, 196, 196);
		dictionary_7[SystemColors.ControlText.ToArgb()] = DarkFieldFore;
		dictionary_7[SystemColors.WindowText.ToArgb()] = DarkFieldFore;
		dictionary_8[DarkFieldFore.ToArgb()] = Color.Black;
		dictionary_8[DarkFieldForeBlue.ToArgb()] = Color.Blue;
	}

	public static void LoadThemePreference()
	{
		smethod_119();
		try
		{
			if (File.Exists(string_0))
			{
				string text = File.ReadAllText(string_0).Trim();
				bool_0 = text == Class16.smethod_0(1648901129);
			}
			smethod_4();
		}
		catch
		{
		}
	}

	private static void smethod_0()
	{
		try
		{
			File.WriteAllText(string_0, bool_0 ? Class16.smethod_0(1648901129) : Class16.smethod_0(1648901148));
		}
		catch
		{
		}
	}

	public static void StoreOriginalColors(Control control)
	{
		if (control == null)
		{
			return;
		}
		if (!dictionary_0.ContainsKey(control))
		{
			Struct49 value = new Struct49
			{
				color_0 = control.BackColor,
				color_1 = control.ForeColor
			};
			if (control is Button button)
			{
				value.flatStyle_0 = button.FlatStyle;
				value.image_0 = button.Image;
				value.image_1 = button.BackgroundImage;
			}
			else if (control is ComboBox comboBox)
			{
				value.flatStyle_0 = comboBox.FlatStyle;
			}
			else if (control is TextBox textBox)
			{
				value.borderStyle_0 = textBox.BorderStyle;
			}
			else if (control is TabPage tabPage)
			{
				value.borderStyle_0 = tabPage.BorderStyle;
				value.bool_0 = tabPage.UseVisualStyleBackColor;
				value.bool_1 = true;
				value.image_1 = tabPage.BackgroundImage;
			}
			else if (control is CheckBox checkBox)
			{
				value.flatStyle_0 = checkBox.FlatStyle;
				value.image_0 = checkBox.Image;
				value.image_1 = checkBox.BackgroundImage;
			}
			else if (control is RadioButton radioButton)
			{
				value.flatStyle_0 = radioButton.FlatStyle;
				value.image_0 = radioButton.Image;
				value.image_1 = radioButton.BackgroundImage;
			}
			else if (control is PictureBox pictureBox)
			{
				value.image_0 = pictureBox.Image;
				value.image_1 = pictureBox.BackgroundImage;
			}
			else if (control is Label label)
			{
				value.image_0 = label.Image;
			}
			else if (control is Panel panel)
			{
				value.image_1 = panel.BackgroundImage;
			}
			else if (control is ToolStrip toolStrip)
			{
				foreach (ToolStripItem item in toolStrip.Items)
				{
					smethod_1(item);
				}
			}
			dictionary_0[control] = value;
		}
		if (control is DataGridView dataGridView && !dictionary_3.ContainsKey(dataGridView))
		{
			dictionary_3[dataGridView] = new Struct50
			{
				color_0 = dataGridView.BackgroundColor,
				color_1 = dataGridView.GridColor,
				dataGridViewCellStyle_0 = dataGridView.DefaultCellStyle.Clone(),
				dataGridViewCellStyle_1 = dataGridView.ColumnHeadersDefaultCellStyle.Clone(),
				dataGridViewCellStyle_2 = dataGridView.RowHeadersDefaultCellStyle.Clone(),
				dataGridViewCellStyle_3 = dataGridView.AlternatingRowsDefaultCellStyle.Clone(),
				dataGridViewCellStyle_4 = dataGridView.RowTemplate.DefaultCellStyle.Clone(),
				bool_0 = dataGridView.EnableHeadersVisualStyles
			};
		}
		if (control is ToolStrip toolStrip2 && !dictionary_1.ContainsKey(toolStrip2))
		{
			dictionary_1[toolStrip2] = toolStrip2.Renderer;
		}
		if (!control.HasChildren)
		{
			return;
		}
		foreach (Control control2 in control.Controls)
		{
			StoreOriginalColors(control2);
		}
	}

	private static void smethod_1(ToolStripItem toolStripItem_0)
	{
		if (toolStripItem_0.Image != null && !dictionary_2.ContainsKey(toolStripItem_0))
		{
			dictionary_2[toolStripItem_0] = toolStripItem_0.Image;
		}
		if (!(toolStripItem_0 is ToolStripDropDownItem toolStripDropDownItem))
		{
			return;
		}
		foreach (ToolStripItem dropDownItem in toolStripDropDownItem.DropDownItems)
		{
			smethod_1(dropDownItem);
		}
	}

	public static void ToggleTheme()
	{
		IsDarkMode = !IsDarkMode;
	}

	public static void ApplyThemeToDynamicControl(Control control)
	{
		if (control != null)
		{
			if (!dictionary_0.ContainsKey(control))
			{
				StoreOriginalColors(control);
			}
			ApplyTheme(control);
		}
	}

	public static void ApplyThemeToToolTip(ToolTip toolTip)
	{
		if (toolTip != null)
		{
			toolTip.Draw -= smethod_3;
			toolTip.Popup -= smethod_2;
			if (!IsDarkMode)
			{
				toolTip.OwnerDraw = false;
				return;
			}
			toolTip.OwnerDraw = true;
			toolTip.BackColor = Color.FromArgb(37, 37, 38);
			toolTip.ForeColor = Color.FromArgb(212, 212, 212);
			toolTip.Draw += smethod_3;
			toolTip.Popup += smethod_2;
		}
	}

	private static void smethod_2(object sender, PopupEventArgs e)
	{
		if (!IsDarkMode || !(sender is ToolTip toolTip))
		{
			return;
		}
		bool flag = !string.IsNullOrWhiteSpace(toolTip.ToolTipTitle);
		bool flag2 = toolTip.ToolTipIcon != ToolTipIcon.None;
		if (flag || flag2)
		{
			Size toolTipSize = e.ToolTipSize;
			int num = (flag2 ? 22 : 0);
			if (flag)
			{
				num += 16;
			}
			int num2 = (flag ? 20 : 0);
			e.ToolTipSize = new Size(toolTipSize.Width + num, toolTipSize.Height + num2);
		}
	}

	private static void smethod_3(object sender, DrawToolTipEventArgs e)
	{
		SolidBrush solidBrush = new SolidBrush(Color.FromArgb(37, 37, 38));
		try
		{
			e.Graphics.FillRectangle(solidBrush, e.Bounds);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		Pen pen = new Pen(DarkBorder);
		try
		{
			e.Graphics.DrawRectangle(pen, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		ToolTip toolTip = sender as ToolTip;
		string text = toolTip?.ToolTipTitle;
		Icon icon = (toolTip?.ToolTipIcon ?? ToolTipIcon.None) switch
		{
			ToolTipIcon.Info => SystemIcons.Information, 
			ToolTipIcon.Warning => SystemIcons.Warning, 
			ToolTipIcon.Error => SystemIcons.Error, 
			_ => null, 
		};
		Font font = e.Font ?? SystemFonts.DefaultFont;
		Rectangle rectangle = new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 4, e.Bounds.Width - 12, e.Bounds.Height - 8);
		int num = rectangle.Y;
		int num2 = rectangle.X;
		bool flag = !string.IsNullOrWhiteSpace(text);
		int num3 = 0;
		if (icon != null)
		{
			int y = (flag ? (rectangle.Y + 1) : (rectangle.Y + Math.Max(0, (font.Height - 16) / 2)));
			Rectangle rect = new Rectangle(rectangle.X, y, 16, 16);
			Icon icon2 = new Icon(icon, rect.Size);
			try
			{
				using Bitmap image = icon2.ToBitmap();
				InterpolationMode interpolationMode = e.Graphics.InterpolationMode;
				SmoothingMode smoothingMode = e.Graphics.SmoothingMode;
				PixelOffsetMode pixelOffsetMode = e.Graphics.PixelOffsetMode;
				CompositingQuality compositingQuality = e.Graphics.CompositingQuality;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
				e.Graphics.DrawImage(image, rect);
				e.Graphics.InterpolationMode = interpolationMode;
				e.Graphics.SmoothingMode = smoothingMode;
				e.Graphics.PixelOffsetMode = pixelOffsetMode;
				e.Graphics.CompositingQuality = compositingQuality;
				num3 = 20;
			}
			finally
			{
				((IDisposable)icon2).Dispose();
			}
		}
		if (flag)
		{
			Font font2 = new Font(font, FontStyle.Bold);
			try
			{
				int num4 = rectangle.X + num3;
				Rectangle bounds = new Rectangle(num4, rectangle.Y, Math.Max(0, rectangle.Width - num3), font.Height + 6);
				TextRenderer.DrawText(e.Graphics, text, font2, bounds, Color.FromArgb(226, 226, 226), TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
				num = Math.Max(bounds.Bottom + 1, rectangle.Y + 18);
				num2 = num4;
			}
			finally
			{
				((IDisposable)font2).Dispose();
			}
		}
		else if (num3 > 0)
		{
			num2 = rectangle.X + num3;
		}
		TextRenderer.DrawText(bounds: new Rectangle(num2, num, Math.Max(0, rectangle.Right - num2), Math.Max(0, rectangle.Bottom - num)), dc: e.Graphics, text: e.ToolTipText ?? string.Empty, font: font, foreColor: Color.FromArgb(212, 212, 212), flags: TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
	}

	public static bool IsControlStored(Control control)
	{
		if (control != null)
		{
			return dictionary_0.ContainsKey(control);
		}
		return false;
	}

	public static void ClearStoredStates()
	{
		dictionary_0.Clear();
		dictionary_1.Clear();
		dictionary_3.Clear();
		hashSet_3.Clear();
		hashSet_4.Clear();
		hashSet_5.Clear();
		hashSet_0.Clear();
		hashSet_1.Clear();
		hashSet_2.Clear();
		hashSet_9.Clear();
		hashSet_6.Clear();
		hashSet_14.Clear();
		hashSet_15.Clear();
		hashSet_16.Clear();
		hashSet_17.Clear();
		hashSet_18.Clear();
		hashSet_19.Clear();
	}

	public static void EnableAutomaticFormTheming()
	{
		if (IsDarkMode)
		{
			smethod_4();
			Application.AddMessageFilter(new Class90());
		}
	}

	[DllImport("dwmapi.dll")]
	private static extern int DwmSetWindowAttribute(IntPtr intptr_0, int int_0, ref int int_1, int int_2);

	[DllImport("uxtheme.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
	private static extern int SetWindowTheme(IntPtr intptr_0, string string_1, string string_2);

	[DllImport("user32.dll", CharSet = CharSet.Unicode)]
	private static extern int GetClassName(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_0);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool EnumChildWindows(IntPtr intptr_0, Delegate0 delegate0_0, IntPtr intptr_1);

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool EnumThreadWindows(uint uint_0, Delegate0 delegate0_0, IntPtr intptr_0);

	[DllImport("kernel32.dll")]
	private static extern uint GetCurrentThreadId();

	[DllImport("uxtheme.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "#133")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool uxtheme_133(IntPtr intptr_0, [MarshalAs(UnmanagedType.Bool)] bool bool_1);

	[DllImport("uxtheme.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "#135")]
	private static extern Enum2 uxtheme_135(Enum2 enum2_0);

	[DllImport("uxtheme.dll", CallingConvention = CallingConvention.StdCall, EntryPoint = "#136")]
	private static extern void uxtheme_136();

	[DllImport("user32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool GetComboBoxInfo(IntPtr intptr_0, ref Struct51 struct51_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	private static void smethod_4()
	{
		try
		{
			uxtheme_135(IsDarkMode ? ((Enum2)1) : ((Enum2)0));
			uxtheme_136();
		}
		catch (EntryPointNotFoundException)
		{
		}
		catch (DllNotFoundException)
		{
		}
		catch
		{
		}
	}

	private static void smethod_5(IntPtr intptr_0)
	{
		if (!IsDarkMode || intptr_0 == IntPtr.Zero)
		{
			return;
		}
		try
		{
			if (!(Control.FromHandle(intptr_0) is Form) && smethod_8(intptr_0))
			{
				ApplyImmersiveDarkMode(intptr_0, enabled: true);
				smethod_7(intptr_0, bool_1: true);
				SetWindowTheme(intptr_0, Class16.smethod_0(1648901152), null);
				EnumChildWindows(intptr_0, smethod_6, IntPtr.Zero);
				SendMessage(intptr_0, 794, IntPtr.Zero, IntPtr.Zero);
			}
		}
		catch
		{
		}
	}

	private static bool smethod_6(IntPtr intptr_0, IntPtr intptr_1)
	{
		try
		{
			smethod_7(intptr_0, bool_1: true);
			SetWindowTheme(intptr_0, Class16.smethod_0(1648901152), null);
			StringBuilder stringBuilder = new StringBuilder(64);
			if (GetClassName(intptr_0, stringBuilder, stringBuilder.Capacity) > 0 && string.Equals(stringBuilder.ToString(), Class16.smethod_0(1648901176), StringComparison.Ordinal))
			{
				smethod_37(intptr_0);
			}
			SendMessage(intptr_0, 794, IntPtr.Zero, IntPtr.Zero);
		}
		catch
		{
		}
		return true;
	}

	private static void smethod_7(IntPtr intptr_0, bool bool_1)
	{
		if (intptr_0 == IntPtr.Zero)
		{
			return;
		}
		try
		{
			uxtheme_133(intptr_0, bool_1);
		}
		catch (EntryPointNotFoundException)
		{
		}
		catch (DllNotFoundException)
		{
		}
		catch
		{
		}
	}

	private static bool smethod_8(IntPtr intptr_0)
	{
		StringBuilder stringBuilder = new StringBuilder(64);
		try
		{
			if (GetClassName(intptr_0, stringBuilder, stringBuilder.Capacity) <= 0)
			{
				return false;
			}
			return string.Equals(stringBuilder.ToString(), Class16.smethod_0(1648901204), StringComparison.Ordinal);
		}
		catch
		{
			return false;
		}
	}

	public static void ApplyImmersiveDarkMode(IntPtr handle, bool enabled)
	{
		if (handle == IntPtr.Zero)
		{
			return;
		}
		try
		{
			int int_ = (enabled ? 1 : 0);
			DwmSetWindowAttribute(handle, 20, ref int_, 4);
		}
		catch
		{
		}
	}

	public static void SetControlDarkExplorerTheme(Control control)
	{
		if (control != null && IsDarkMode && control.IsHandleCreated)
		{
			try
			{
				IntPtr handle = control.Handle;
				smethod_7(handle, bool_1: true);
				SetWindowTheme(handle, Class16.smethod_0(1648901152), null);
			}
			catch
			{
			}
		}
	}

	public static void EnsureDarkComboBox(ComboBox comboBox)
	{
		if (comboBox != null && !hashSet_0.Contains(comboBox))
		{
			hashSet_0.Add(comboBox);
			comboBox.HandleCreated += smethod_9;
			comboBox.DropDown += smethod_10;
			comboBox.EnabledChanged += smethod_11;
			comboBox.Disposed += smethod_12;
			smethod_29(comboBox);
		}
	}

	private static void smethod_9(object sender, EventArgs e)
	{
		if (sender is ComboBox comboBox_)
		{
			smethod_29(comboBox_);
		}
	}

	private static void smethod_10(object sender, EventArgs e)
	{
		if (sender is ComboBox comboBox_)
		{
			smethod_29(comboBox_);
		}
	}

	private static void smethod_11(object sender, EventArgs e)
	{
		if (sender is ComboBox comboBox)
		{
			comboBox.BackColor = DarkControlBack;
			comboBox.ForeColor = (comboBox.Enabled ? DarkControlFore : DarkDisabledFore);
			smethod_29(comboBox);
		}
	}

	private static void smethod_12(object sender, EventArgs e)
	{
		if (sender is ComboBox comboBox)
		{
			comboBox.HandleCreated -= smethod_9;
			comboBox.DropDown -= smethod_10;
			comboBox.EnabledChanged -= smethod_11;
			comboBox.Disposed -= smethod_12;
			hashSet_0.Remove(comboBox);
		}
	}

	public static void EnsureDarkDateTimePicker(DateTimePicker dateTimePicker)
	{
		if (dateTimePicker != null && IsDarkMode)
		{
			if (!hashSet_2.Contains(dateTimePicker))
			{
				hashSet_2.Add(dateTimePicker);
				dateTimePicker.HandleCreated += smethod_13;
				dateTimePicker.DropDown += smethod_14;
				dateTimePicker.CloseUp += smethod_15;
				dateTimePicker.EnabledChanged += smethod_16;
				dateTimePicker.Disposed += smethod_17;
			}
			smethod_30(dateTimePicker);
		}
	}

	public static void EnsureDarkNumericUpDown(NumericUpDown numericUpDown)
	{
		if (numericUpDown != null && IsDarkMode)
		{
			if (!hashSet_5.Contains(numericUpDown))
			{
				hashSet_5.Add(numericUpDown);
				numericUpDown.HandleCreated += smethod_18;
				numericUpDown.ControlAdded += smethod_19;
				numericUpDown.EnabledChanged += smethod_20;
				numericUpDown.ValueChanged += smethod_21;
				numericUpDown.Disposed += smethod_22;
			}
			smethod_34(numericUpDown);
		}
	}

	private static void smethod_13(object sender, EventArgs e)
	{
		if (sender is DateTimePicker dateTimePicker_)
		{
			smethod_30(dateTimePicker_);
			smethod_31(dateTimePicker_);
		}
	}

	private static void smethod_14(object sender, EventArgs e)
	{
		if (sender is DateTimePicker dateTimePicker_)
		{
			smethod_30(dateTimePicker_);
			smethod_31(dateTimePicker_);
		}
	}

	private static void smethod_15(object sender, EventArgs e)
	{
		if (sender is DateTimePicker dateTimePicker_)
		{
			smethod_30(dateTimePicker_);
		}
	}

	private static void smethod_16(object sender, EventArgs e)
	{
		if (sender is DateTimePicker dateTimePicker_)
		{
			smethod_30(dateTimePicker_);
		}
	}

	private static void smethod_17(object sender, EventArgs e)
	{
		if (sender is DateTimePicker dateTimePicker)
		{
			dateTimePicker.HandleCreated -= smethod_13;
			dateTimePicker.DropDown -= smethod_14;
			dateTimePicker.CloseUp -= smethod_15;
			dateTimePicker.EnabledChanged -= smethod_16;
			dateTimePicker.Disposed -= smethod_17;
			hashSet_2.Remove(dateTimePicker);
		}
	}

	private static void smethod_18(object sender, EventArgs e)
	{
		if (sender is NumericUpDown numericUpDown_)
		{
			smethod_34(numericUpDown_);
		}
	}

	private static void smethod_19(object sender, ControlEventArgs e)
	{
		if (sender is NumericUpDown numericUpDown_)
		{
			smethod_34(numericUpDown_);
		}
	}

	private static void smethod_20(object sender, EventArgs e)
	{
		if (sender is NumericUpDown numericUpDown_)
		{
			smethod_34(numericUpDown_);
		}
	}

	private static void smethod_21(object sender, EventArgs e)
	{
		if (sender is NumericUpDown numericUpDown_)
		{
			smethod_34(numericUpDown_);
		}
	}

	private static void smethod_22(object sender, EventArgs e)
	{
		if (sender is NumericUpDown numericUpDown)
		{
			numericUpDown.HandleCreated -= smethod_18;
			numericUpDown.ControlAdded -= smethod_19;
			numericUpDown.EnabledChanged -= smethod_20;
			numericUpDown.ValueChanged -= smethod_21;
			numericUpDown.Disposed -= smethod_22;
			hashSet_5.Remove(numericUpDown);
		}
	}

	public static void EnsureDarkMonthCalendar(MonthCalendar monthCalendar)
	{
		if (monthCalendar != null && IsDarkMode)
		{
			if (!hashSet_6.Contains(monthCalendar))
			{
				hashSet_6.Add(monthCalendar);
				monthCalendar.HandleCreated += smethod_23;
				monthCalendar.Disposed += smethod_24;
			}
			smethod_25(monthCalendar);
		}
	}

	private static void smethod_23(object sender, EventArgs e)
	{
		if (sender is MonthCalendar monthCalendar_)
		{
			smethod_25(monthCalendar_);
		}
	}

	private static void smethod_24(object sender, EventArgs e)
	{
		if (sender is MonthCalendar monthCalendar)
		{
			monthCalendar.HandleCreated -= smethod_23;
			monthCalendar.Disposed -= smethod_24;
			hashSet_6.Remove(monthCalendar);
		}
	}

	private static void smethod_25(MonthCalendar monthCalendar_0)
	{
		if (monthCalendar_0 == null || !IsDarkMode)
		{
			return;
		}
		try
		{
			SetControlDarkExplorerTheme(monthCalendar_0);
			if (monthCalendar_0.IsHandleCreated)
			{
				smethod_7(monthCalendar_0.Handle, bool_1: true);
				SetWindowTheme(monthCalendar_0.Handle, Class16.smethod_0(1648901209), null);
				SetWindowTheme(monthCalendar_0.Handle, Class16.smethod_0(1648901236), null);
				SetWindowTheme(monthCalendar_0.Handle, Class16.smethod_0(1648901152), null);
				SendMessage(monthCalendar_0.Handle, 4106, new IntPtr(0), smethod_35(DarkBack));
				SendMessage(monthCalendar_0.Handle, 4106, new IntPtr(4), smethod_35(DarkControlBack));
				SendMessage(monthCalendar_0.Handle, 4106, new IntPtr(1), smethod_35(DarkControlFore));
				SendMessage(monthCalendar_0.Handle, 4106, new IntPtr(2), smethod_35(DarkHeaderBack));
				SendMessage(monthCalendar_0.Handle, 4106, new IntPtr(3), smethod_35(DarkFore));
				SendMessage(monthCalendar_0.Handle, 4106, new IntPtr(5), smethod_35(Color.FromArgb(128, 128, 128)));
				SendMessage(monthCalendar_0.Handle, 794, IntPtr.Zero, IntPtr.Zero);
			}
		}
		catch
		{
		}
	}

	public static void EnsureDarkButtonRadio(RadioButton radioButton)
	{
		if (radioButton != null && radioButton.Appearance == Appearance.Button)
		{
			if (!hashSet_1.Contains(radioButton))
			{
				hashSet_1.Add(radioButton);
				radioButton.CheckedChanged += smethod_26;
				radioButton.Disposed += smethod_27;
			}
			smethod_28(radioButton);
		}
	}

	private static void smethod_26(object sender, EventArgs e)
	{
		if (sender is RadioButton radioButton_)
		{
			smethod_28(radioButton_);
		}
	}

	private static void smethod_27(object sender, EventArgs e)
	{
		if (sender is RadioButton radioButton)
		{
			radioButton.CheckedChanged -= smethod_26;
			radioButton.Disposed -= smethod_27;
			hashSet_1.Remove(radioButton);
		}
	}

	private static void smethod_28(RadioButton radioButton_0)
	{
		if (radioButton_0 == null)
		{
			return;
		}
		if (!IsDarkMode)
		{
			radioButton_0.UseVisualStyleBackColor = true;
			return;
		}
		radioButton_0.UseVisualStyleBackColor = false;
		radioButton_0.FlatStyle = FlatStyle.Flat;
		radioButton_0.FlatAppearance.BorderSize = 1;
		radioButton_0.FlatAppearance.BorderColor = DarkBorder;
		radioButton_0.FlatAppearance.MouseOverBackColor = DarkHover;
		radioButton_0.FlatAppearance.CheckedBackColor = DarkSelectionBack;
		radioButton_0.BackColor = (radioButton_0.Checked ? DarkSelectionBack : DarkButtonBack);
		if (!HasCustomTextColor(radioButton_0))
		{
			radioButton_0.ForeColor = DarkButtonFore;
		}
	}

	private static void smethod_29(ComboBox comboBox_0)
	{
		if (comboBox_0 == null || !IsDarkMode)
		{
			return;
		}
		try
		{
			SetControlDarkExplorerTheme(comboBox_0);
			if (!comboBox_0.IsHandleCreated)
			{
				return;
			}
			smethod_7(comboBox_0.Handle, bool_1: true);
			SetWindowTheme(comboBox_0.Handle, Class16.smethod_0(1648901209), null);
			SetWindowTheme(comboBox_0.Handle, Class16.smethod_0(1648901236), null);
			SetWindowTheme(comboBox_0.Handle, Class16.smethod_0(1648901152), null);
			comboBox_0.BackColor = DarkControlBack;
			comboBox_0.ForeColor = (comboBox_0.Enabled ? DarkControlFore : DarkDisabledFore);
			Struct51 struct51_ = new Struct51
			{
				int_0 = Marshal.SizeOf(typeof(Struct51))
			};
			if (GetComboBoxInfo(comboBox_0.Handle, ref struct51_))
			{
				if (struct51_.intptr_1 != IntPtr.Zero)
				{
					smethod_7(struct51_.intptr_1, bool_1: true);
					SetWindowTheme(struct51_.intptr_1, Class16.smethod_0(1648901209), null);
					SetWindowTheme(struct51_.intptr_1, Class16.smethod_0(1648901236), null);
					SetWindowTheme(struct51_.intptr_1, Class16.smethod_0(1648901152), null);
					SendMessage(struct51_.intptr_1, 794, IntPtr.Zero, IntPtr.Zero);
				}
				if (struct51_.intptr_2 != IntPtr.Zero)
				{
					smethod_7(struct51_.intptr_2, bool_1: true);
					SetWindowTheme(struct51_.intptr_2, Class16.smethod_0(1648901209), null);
					SetWindowTheme(struct51_.intptr_2, Class16.smethod_0(1648901236), null);
					SetWindowTheme(struct51_.intptr_2, Class16.smethod_0(1648901152), null);
					SendMessage(struct51_.intptr_2, 794, IntPtr.Zero, IntPtr.Zero);
				}
				SendMessage(comboBox_0.Handle, 794, IntPtr.Zero, IntPtr.Zero);
			}
		}
		catch
		{
		}
	}

	private static void smethod_30(DateTimePicker dateTimePicker_0)
	{
		if (dateTimePicker_0 == null || !IsDarkMode)
		{
			return;
		}
		try
		{
			SetControlDarkExplorerTheme(dateTimePicker_0);
			if (dateTimePicker_0.IsHandleCreated)
			{
				smethod_7(dateTimePicker_0.Handle, bool_1: true);
				SetWindowTheme(dateTimePicker_0.Handle, Class16.smethod_0(1648901209), null);
				SetWindowTheme(dateTimePicker_0.Handle, Class16.smethod_0(1648901236), null);
				SetWindowTheme(dateTimePicker_0.Handle, Class16.smethod_0(1648901152), null);
				SendMessage(dateTimePicker_0.Handle, 794, IntPtr.Zero, IntPtr.Zero);
				smethod_36(dateTimePicker_0);
				IntPtr intPtr = SendMessage(dateTimePicker_0.Handle, 4104, IntPtr.Zero, IntPtr.Zero);
				if (intPtr != IntPtr.Zero)
				{
					smethod_7(intPtr, bool_1: true);
					SetWindowTheme(intPtr, Class16.smethod_0(1648901209), null);
					SetWindowTheme(intPtr, Class16.smethod_0(1648901236), null);
					SetWindowTheme(intPtr, Class16.smethod_0(1648901152), null);
					smethod_37(intPtr);
					SendMessage(intPtr, 794, IntPtr.Zero, IntPtr.Zero);
				}
			}
		}
		catch
		{
		}
	}

	private static void smethod_31(DateTimePicker dateTimePicker_0)
	{
		Class94 @class = new Class94();
		@class.dateTimePicker_0 = dateTimePicker_0;
		if (@class.dateTimePicker_0 != null && IsDarkMode)
		{
			try
			{
				@class.int_0 = 0;
				@class.timer_0 = new Timer
				{
					Interval = 30
				};
				@class.timer_0.Tick += @class.method_0;
				@class.timer_0.Start();
			}
			catch
			{
			}
		}
	}

	private static void smethod_32()
	{
		if (!IsDarkMode)
		{
			return;
		}
		try
		{
			EnumThreadWindows(GetCurrentThreadId(), smethod_33, IntPtr.Zero);
		}
		catch
		{
		}
	}

	private static bool smethod_33(IntPtr intptr_0, IntPtr intptr_1)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			if (GetClassName(intptr_0, stringBuilder, stringBuilder.Capacity) <= 0)
			{
				return true;
			}
			string a = stringBuilder.ToString();
			if (string.Equals(a, Class16.smethod_0(1648901176), StringComparison.Ordinal) || string.Equals(a, Class16.smethod_0(1648901243), StringComparison.Ordinal) || string.Equals(a, Class16.smethod_0(1648901204), StringComparison.Ordinal))
			{
				smethod_7(intptr_0, bool_1: true);
				SetWindowTheme(intptr_0, Class16.smethod_0(1648901209), null);
				SetWindowTheme(intptr_0, Class16.smethod_0(1648901236), null);
				SetWindowTheme(intptr_0, Class16.smethod_0(1648901152), null);
				if (string.Equals(a, Class16.smethod_0(1648901176), StringComparison.Ordinal))
				{
					smethod_37(intptr_0);
				}
				EnumChildWindows(intptr_0, smethod_6, IntPtr.Zero);
				SendMessage(intptr_0, 794, IntPtr.Zero, IntPtr.Zero);
			}
		}
		catch
		{
		}
		return true;
	}

	private static void smethod_34(NumericUpDown numericUpDown_0)
	{
		if (numericUpDown_0 == null || !IsDarkMode)
		{
			return;
		}
		try
		{
			SetControlDarkExplorerTheme(numericUpDown_0);
			smethod_7(numericUpDown_0.Handle, bool_1: true);
			SetWindowTheme(numericUpDown_0.Handle, Class16.smethod_0(1648901209), null);
			SetWindowTheme(numericUpDown_0.Handle, Class16.smethod_0(1648901236), null);
			SetWindowTheme(numericUpDown_0.Handle, Class16.smethod_0(1648901152), null);
			numericUpDown_0.BackColor = DarkControlBack;
			numericUpDown_0.ForeColor = (numericUpDown_0.Enabled ? DarkControlFore : DarkDisabledFore);
			foreach (Control control in numericUpDown_0.Controls)
			{
				if (control != null)
				{
					control.BackColor = DarkControlBack;
					control.ForeColor = (numericUpDown_0.Enabled ? DarkControlFore : DarkDisabledFore);
					smethod_7(control.Handle, bool_1: true);
					SetWindowTheme(control.Handle, Class16.smethod_0(1648901209), null);
					SetWindowTheme(control.Handle, Class16.smethod_0(1648901236), null);
					SetWindowTheme(control.Handle, Class16.smethod_0(1648901152), null);
					SendMessage(control.Handle, 794, IntPtr.Zero, IntPtr.Zero);
				}
			}
			SendMessage(numericUpDown_0.Handle, 794, IntPtr.Zero, IntPtr.Zero);
		}
		catch
		{
		}
	}

	private static IntPtr smethod_35(Color color_0)
	{
		return new IntPtr(ColorTranslator.ToWin32(color_0));
	}

	private static void smethod_36(DateTimePicker dateTimePicker_0)
	{
		if (dateTimePicker_0 != null && dateTimePicker_0.IsHandleCreated)
		{
			SendMessage(dateTimePicker_0.Handle, 4102, new IntPtr(0), smethod_35(DarkBack));
			SendMessage(dateTimePicker_0.Handle, 4102, new IntPtr(4), smethod_35(DarkControlBack));
			SendMessage(dateTimePicker_0.Handle, 4102, new IntPtr(1), smethod_35(DarkControlFore));
			SendMessage(dateTimePicker_0.Handle, 4102, new IntPtr(2), smethod_35(DarkHeaderBack));
			SendMessage(dateTimePicker_0.Handle, 4102, new IntPtr(3), smethod_35(DarkFore));
			SendMessage(dateTimePicker_0.Handle, 4102, new IntPtr(5), smethod_35(Color.FromArgb(140, 140, 140)));
		}
	}

	private static void smethod_37(IntPtr intptr_0)
	{
		if (!(intptr_0 == IntPtr.Zero))
		{
			SendMessage(intptr_0, 4106, new IntPtr(0), smethod_35(DarkBack));
			SendMessage(intptr_0, 4106, new IntPtr(4), smethod_35(DarkControlBack));
			SendMessage(intptr_0, 4106, new IntPtr(1), smethod_35(DarkControlFore));
			SendMessage(intptr_0, 4106, new IntPtr(2), smethod_35(DarkHeaderBack));
			SendMessage(intptr_0, 4106, new IntPtr(3), smethod_35(DarkFore));
			SendMessage(intptr_0, 4106, new IntPtr(5), smethod_35(Color.FromArgb(140, 140, 140)));
		}
	}

	public static void EnsureDarkDataGridView(DataGridView dataGridView)
	{
		if (dataGridView != null && IsDarkMode)
		{
			if (!hashSet_3.Contains(dataGridView))
			{
				hashSet_3.Add(dataGridView);
				dataGridView.EditingControlShowing += smethod_38;
				dataGridView.DataError += smethod_41;
				dataGridView.RowsAdded += smethod_39;
				dataGridView.DataBindingComplete += smethod_40;
				dataGridView.Paint += smethod_42;
				dataGridView.CellPainting += smethod_44;
				dataGridView.CurrentCellDirtyStateChanged += smethod_45;
				dataGridView.CellMouseUp += smethod_46;
				dataGridView.Disposed += smethod_47;
			}
			smethod_48(dataGridView);
		}
	}

	private static void smethod_38(object sender, DataGridViewEditingControlShowingEventArgs e)
	{
		if (!IsDarkMode || !(sender is DataGridView))
		{
			return;
		}
		try
		{
			e.Control.BackColor = DarkControlBack;
			e.Control.ForeColor = Color.White;
			e.CellStyle.BackColor = DarkControlBack;
			e.CellStyle.ForeColor = Color.White;
			e.CellStyle.SelectionBackColor = DarkSelectionBack;
			e.CellStyle.SelectionForeColor = Color.White;
			if (e.Control is ComboBox comboBox)
			{
				comboBox.BackColor = DarkControlBack;
				comboBox.ForeColor = Color.White;
				comboBox.FlatStyle = FlatStyle.Flat;
				EnsureDarkComboBox(comboBox);
			}
			else if (e.Control is TextBoxBase textBoxBase)
			{
				textBoxBase.BackColor = DarkControlBack;
				textBoxBase.ForeColor = Color.White;
			}
		}
		catch
		{
		}
	}

	private static void smethod_39(object sender, DataGridViewRowsAddedEventArgs e)
	{
		if (!IsDarkMode || !(sender is DataGridView dataGridView))
		{
			return;
		}
		try
		{
			smethod_111(dataGridView);
			int num = Math.Min(dataGridView.Rows.Count, e.RowIndex + e.RowCount);
			for (int i = e.RowIndex; i < num; i++)
			{
				smethod_51(dataGridView.Rows[i]);
			}
		}
		catch
		{
		}
	}

	private static void smethod_40(object sender, DataGridViewBindingCompleteEventArgs e)
	{
		if (IsDarkMode && sender is DataGridView dataGridView_)
		{
			try
			{
				smethod_111(dataGridView_);
				smethod_48(dataGridView_);
				smethod_74(dataGridView_);
			}
			catch
			{
			}
		}
	}

	private static void smethod_41(object sender, DataGridViewDataErrorEventArgs e)
	{
		if (sender is DataGridView && e != null && e.Exception is Win32Exception)
		{
			e.ThrowException = false;
			e.Cancel = false;
		}
	}

	private static void smethod_42(object sender, PaintEventArgs e)
	{
		if (!IsDarkMode || !(sender is DataGridView dataGridView))
		{
			return;
		}
		try
		{
			if (!smethod_43(dataGridView, out var hscrollBar_, out var vscrollBar_))
			{
				return;
			}
			SolidBrush solidBrush = new SolidBrush(DarkHeaderBack);
			try
			{
				e.Graphics.FillRectangle(solidBrush, dataGridView.ClientRectangle.X + dataGridView.ClientRectangle.Width - vscrollBar_.Width - 1, dataGridView.ClientRectangle.Y + dataGridView.ClientRectangle.Height - hscrollBar_.Height - 1, vscrollBar_.Width, hscrollBar_.Height);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}
		catch
		{
		}
	}

	private static bool smethod_43(DataGridView dataGridView_0, out HScrollBar hscrollBar_0, out VScrollBar vscrollBar_0)
	{
		hscrollBar_0 = null;
		vscrollBar_0 = null;
		foreach (Control control in dataGridView_0.Controls)
		{
			if (control is HScrollBar { Visible: not false } hScrollBar)
			{
				hscrollBar_0 = hScrollBar;
			}
			else if (control is VScrollBar { Visible: not false } vScrollBar)
			{
				vscrollBar_0 = vScrollBar;
			}
		}
		if (hscrollBar_0 != null)
		{
			return vscrollBar_0 != null;
		}
		return false;
	}

	private static void smethod_44(object sender, DataGridViewCellPaintingEventArgs e)
	{
		if (!IsDarkMode || e.RowIndex < 0 || e.ColumnIndex < 0 || !(sender is DataGridView dataGridView) || e.RowIndex >= dataGridView.Rows.Count || e.ColumnIndex >= dataGridView.Columns.Count || (!(dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn) && !(dataGridView[e.ColumnIndex, e.RowIndex] is DataGridViewCheckBoxCell)))
		{
			return;
		}
		bool flag = false;
		object value = e.Value;
		if (value is bool)
		{
			flag = (bool)value;
		}
		else if (value is int num)
		{
			flag = num == 1;
		}
		else if (value is string text)
		{
			flag = text.Equals(Class16.smethod_0(1648901259), StringComparison.OrdinalIgnoreCase) || text.Equals(Class16.smethod_0(1648934925));
		}
		else if (value is CheckState checkState)
		{
			flag = checkState == CheckState.Checked;
		}
		e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border | DataGridViewPaintParts.ContentBackground | DataGridViewPaintParts.ErrorIcon | DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground);
		int num2 = e.CellBounds.X + (e.CellBounds.Width - 14) / 2;
		int num3 = e.CellBounds.Y + (e.CellBounds.Height - 14) / 2;
		Rectangle rect = new Rectangle(num2, num3, 14, 14);
		using (SolidBrush brush = new SolidBrush(flag ? Color.FromArgb(0, 120, 215) : DarkControlBack))
		{
			using Pen pen = new Pen(flag ? Color.FromArgb(0, 120, 215) : Color.FromArgb(100, 100, 100));
			e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			e.Graphics.FillRectangle(brush, rect);
			e.Graphics.DrawRectangle(pen, rect);
			if (flag)
			{
				Pen pen2 = new Pen(Color.White, 2f);
				try
				{
					Point point = new Point(num2 + 3, num3 + 6);
					Point point2 = new Point(num2 + 6, num3 + 9);
					Point point3 = new Point(num2 + 10, num3 + 3);
					e.Graphics.DrawLines(pen2, new Point[3] { point, point2, point3 });
				}
				finally
				{
					((IDisposable)pen2).Dispose();
				}
			}
			e.Graphics.SmoothingMode = SmoothingMode.Default;
		}
		e.Handled = true;
	}

	private static void smethod_45(object sender, EventArgs e)
	{
		if (sender is DataGridView { IsCurrentCellDirty: not false, CurrentCell: not null } dataGridView && (dataGridView.CurrentCell is DataGridViewCheckBoxCell || dataGridView.CurrentCell is DataGridViewComboBoxCell))
		{
			dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
		}
	}

	private static void smethod_46(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.RowIndex < 0 || e.ColumnIndex < 0 || !(sender is DataGridView dataGridView) || e.RowIndex >= dataGridView.Rows.Count || e.ColumnIndex >= dataGridView.Columns.Count || !(dataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn))
		{
			return;
		}
		if (dataGridView.IsCurrentCellDirty)
		{
			dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
			return;
		}
		try
		{
			DataGridViewCell dataGridViewCell = dataGridView[e.ColumnIndex, e.RowIndex];
			if (!dataGridViewCell.ReadOnly)
			{
				bool flag = false;
				object value = dataGridViewCell.Value;
				if (value is bool)
				{
					flag = (bool)value;
				}
				else if (dataGridViewCell.Value is int num)
				{
					flag = num != 0;
				}
				else if (dataGridViewCell.Value is string text)
				{
					flag = text == Class16.smethod_0(1648934925) || text.ToLower() == Class16.smethod_0(1648901259);
				}
				dataGridViewCell.Value = !flag;
				dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
				dataGridView.InvalidateCell(e.ColumnIndex, e.RowIndex);
			}
		}
		catch
		{
		}
	}

	private static void smethod_47(object sender, EventArgs e)
	{
		if (sender is DataGridView dataGridView)
		{
			dataGridView.EditingControlShowing -= smethod_38;
			dataGridView.DataError -= smethod_41;
			dataGridView.RowsAdded -= smethod_39;
			dataGridView.DataBindingComplete -= smethod_40;
			dataGridView.Paint -= smethod_42;
			dataGridView.CellPainting -= smethod_44;
			dataGridView.CurrentCellDirtyStateChanged -= smethod_45;
			dataGridView.CellMouseUp -= smethod_46;
			dataGridView.Disposed -= smethod_47;
			hashSet_3.Remove(dataGridView);
		}
	}

	private static void smethod_48(DataGridView dataGridView_0)
	{
		if (dataGridView_0 == null)
		{
			return;
		}
		smethod_111(dataGridView_0);
		foreach (DataGridViewRow item in (IEnumerable)dataGridView_0.Rows)
		{
			smethod_51(item);
		}
	}

	private static bool smethod_49(Color color_0)
	{
		if (!(color_0 == Color.Empty) && !(color_0 == Color.Transparent) && !(color_0 == Color.Black) && !(color_0 == SystemColors.ControlText) && !(color_0 == SystemColors.WindowText))
		{
			return smethod_66(color_0);
		}
		return true;
	}

	private static bool smethod_50(Color color_0)
	{
		if (!(color_0 == Color.Empty) && !(color_0 == Color.Transparent) && !(color_0 == Color.White) && !(color_0 == SystemColors.Window) && !(color_0 == SystemColors.Control))
		{
			return color_0 == SystemColors.InactiveBorder;
		}
		return true;
	}

	private static void smethod_51(DataGridViewRow dataGridViewRow_0)
	{
		if (dataGridViewRow_0 == null || dataGridViewRow_0.IsNewRow)
		{
			return;
		}
		if (smethod_50(dataGridViewRow_0.DefaultCellStyle.BackColor))
		{
			dataGridViewRow_0.DefaultCellStyle.BackColor = DarkControlBack;
		}
		if (smethod_49(dataGridViewRow_0.DefaultCellStyle.ForeColor))
		{
			dataGridViewRow_0.DefaultCellStyle.ForeColor = DarkControlFore;
		}
		dataGridViewRow_0.DefaultCellStyle.SelectionBackColor = DarkSelectionBack;
		dataGridViewRow_0.DefaultCellStyle.SelectionForeColor = DarkSelectionFore;
		foreach (DataGridViewCell cell in dataGridViewRow_0.Cells)
		{
			if (cell != null)
			{
				if (smethod_50(cell.Style.BackColor))
				{
					cell.Style.BackColor = DarkControlBack;
				}
				if (smethod_49(cell.Style.ForeColor))
				{
					cell.Style.ForeColor = DarkControlFore;
				}
				if (cell.Style.SelectionBackColor == Color.Empty || cell.Style.SelectionBackColor == SystemColors.Highlight)
				{
					cell.Style.SelectionBackColor = DarkSelectionBack;
				}
				if (cell.Style.SelectionForeColor == Color.Empty || cell.Style.SelectionForeColor == SystemColors.HighlightText)
				{
					cell.Style.SelectionForeColor = DarkSelectionFore;
				}
				if (cell is DataGridViewComboBoxCell dataGridViewComboBoxCell)
				{
					dataGridViewComboBoxCell.FlatStyle = FlatStyle.Flat;
					dataGridViewComboBoxCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
				}
				else if (cell is DataGridViewCheckBoxCell dataGridViewCheckBoxCell)
				{
					dataGridViewCheckBoxCell.FlatStyle = FlatStyle.Flat;
				}
			}
		}
	}

	public static void EnsureDarkWebBrowser(WebBrowser webBrowser)
	{
		if (webBrowser != null && IsDarkMode)
		{
			if (!hashSet_4.Contains(webBrowser))
			{
				hashSet_4.Add(webBrowser);
				webBrowser.DocumentCompleted += smethod_52;
				webBrowser.Disposed += smethod_103;
			}
			smethod_104(webBrowser);
		}
	}

	private static void smethod_52(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		if (sender is WebBrowser webBrowser_)
		{
			smethod_104(webBrowser_);
		}
	}

	public static void ApplyTheme(Control control)
	{
		if (control == null || (control is Form form && form.GetType().Name == Class16.smethod_0(1648901278)) || !IsDarkMode)
		{
			return;
		}
		smethod_53(control);
		smethod_105(control);
		if (control.HasChildren)
		{
			foreach (Control control2 in control.Controls)
			{
				ApplyTheme(control2);
			}
		}
		smethod_58(control);
		if (control.ContextMenuStrip != null)
		{
			smethod_106(control.ContextMenuStrip);
		}
		control.Invalidate(invalidateChildren: true);
		control.Refresh();
	}

	private static void smethod_53(Control control_0)
	{
		if (control_0 != null && !hashSet_8.Contains(control_0))
		{
			control_0.ControlAdded += smethod_54;
			control_0.EnabledChanged += smethod_55;
			control_0.HandleCreated += smethod_56;
			control_0.Disposed += smethod_57;
			hashSet_8.Add(control_0);
		}
	}

	private static void smethod_54(object sender, ControlEventArgs e)
	{
		if (!IsDarkMode || e?.Control == null)
		{
			return;
		}
		try
		{
			if (!(e.Control is IDataGridViewEditingControl))
			{
				StoreOriginalColors(e.Control);
				ApplyTheme(e.Control);
				ApplyNativeDarkThemeRecursive(e.Control);
			}
		}
		catch
		{
		}
	}

	private static void smethod_55(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is Control control)
		{
			try
			{
				smethod_105(control);
				ApplyNativeDarkThemeRecursive(control);
				control.Invalidate(invalidateChildren: true);
			}
			catch
			{
			}
		}
	}

	private static void smethod_56(object sender, EventArgs e)
	{
		if (!IsDarkMode || !(sender is Control control))
		{
			return;
		}
		try
		{
			SetControlDarkExplorerTheme(control);
			smethod_105(control);
			if (control is TabControl tab)
			{
				ApplyThemeToTabControl(tab);
			}
		}
		catch
		{
		}
	}

	private static void smethod_57(object sender, EventArgs e)
	{
		if (sender is Control control)
		{
			control.ControlAdded -= smethod_54;
			control.EnabledChanged -= smethod_55;
			control.HandleCreated -= smethod_56;
			control.Disposed -= smethod_57;
			hashSet_8.Remove(control);
		}
	}

	private static void smethod_58(Control control_0)
	{
		if (control_0 != null && !hashSet_7.Contains(control_0))
		{
			control_0.ContextMenuStripChanged += smethod_59;
			control_0.Disposed += smethod_60;
			hashSet_7.Add(control_0);
		}
	}

	private static void smethod_59(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is Control { ContextMenuStrip: not null } control)
		{
			smethod_106(control.ContextMenuStrip);
		}
	}

	private static void smethod_60(object sender, EventArgs e)
	{
		if (sender is Control control)
		{
			control.ContextMenuStripChanged -= smethod_59;
			control.Disposed -= smethod_60;
			hashSet_7.Remove(control);
		}
	}

	private static void smethod_61(Control control_0)
	{
		if (control_0 is Form { IsHandleCreated: not false } form)
		{
			ApplyImmersiveDarkMode(form.Handle, enabled: false);
		}
		if (dictionary_0.TryGetValue(control_0, out var value))
		{
			control_0.BackColor = value.color_0;
			control_0.ForeColor = value.color_1;
			control_0.BackgroundImage = value.image_1;
			control_0.EnabledChanged -= smethod_67;
			if (control_0 is Button button)
			{
				button.FlatStyle = value.flatStyle_0;
				button.FlatAppearance.BorderSize = 1;
				button.Image = value.image_0;
				button.Paint -= smethod_89;
				hashSet_14.Remove(button);
			}
			else if (control_0 is ComboBox comboBox)
			{
				comboBox.FlatStyle = value.flatStyle_0;
			}
			else if (control_0 is TextBox textBox)
			{
				textBox.BorderStyle = value.borderStyle_0;
			}
			else if (control_0 is TabPage tabPage)
			{
				tabPage.BorderStyle = value.borderStyle_0;
				if (value.bool_1)
				{
					tabPage.UseVisualStyleBackColor = value.bool_0;
				}
				tabPage.BackgroundImage = value.image_1;
			}
			else if (control_0 is CheckBox checkBox)
			{
				checkBox.FlatStyle = value.flatStyle_0;
				checkBox.Image = value.image_0;
				checkBox.Paint -= smethod_118;
				hashSet_15.Remove(checkBox);
			}
			else if (control_0 is RadioButton radioButton)
			{
				radioButton.FlatStyle = value.flatStyle_0;
				radioButton.Image = value.image_0;
				radioButton.Paint -= smethod_92;
				hashSet_16.Remove(radioButton);
			}
			else if (control_0 is PictureBox pictureBox)
			{
				pictureBox.Image = value.image_0;
			}
			else if (control_0 is Label label)
			{
				label.Image = value.image_0;
			}
			else if (control_0 is Panel panel)
			{
				panel.BackgroundImage = value.image_1;
			}
			else if (control_0 is CheckedListBox checkedListBox)
			{
				checkedListBox.DrawMode = DrawMode.Normal;
				checkedListBox.DrawItem -= smethod_94;
				hashSet_17.Remove(checkedListBox);
			}
			else if (control_0 is ListBox listBox)
			{
				listBox.DrawMode = DrawMode.Normal;
				listBox.DrawItem -= smethod_96;
				hashSet_18.Remove(listBox);
			}
			else if (control_0 is ListView listView)
			{
				listView.OwnerDraw = false;
				listView.DrawColumnHeader -= smethod_68;
				listView.DrawItem -= smethod_69;
				listView.DrawSubItem -= smethod_70;
				if (dictionary_4.TryGetValue(listView, out var value2))
				{
					listView.GridLines = value2;
					dictionary_4.Remove(listView);
				}
			}
			else if (control_0 is ToolStrip toolStrip)
			{
				foreach (ToolStripItem item in toolStrip.Items)
				{
					smethod_63(item);
				}
			}
		}
		if (control_0 is DataGridView dataGridView && dictionary_3.TryGetValue(dataGridView, out var value3))
		{
			dataGridView.BackgroundColor = value3.color_0;
			dataGridView.GridColor = value3.color_1;
			dataGridView.EnableHeadersVisualStyles = value3.bool_0;
			dataGridView.DefaultCellStyle = value3.dataGridViewCellStyle_0.Clone();
			dataGridView.ColumnHeadersDefaultCellStyle = value3.dataGridViewCellStyle_1.Clone();
			dataGridView.RowHeadersDefaultCellStyle = value3.dataGridViewCellStyle_2.Clone();
			dataGridView.AlternatingRowsDefaultCellStyle = value3.dataGridViewCellStyle_3.Clone();
			if (value3.dataGridViewCellStyle_4 != null)
			{
				dataGridView.RowTemplate.DefaultCellStyle = value3.dataGridViewCellStyle_4.Clone();
			}
		}
		if (control_0 is TabControl tabControl)
		{
			RemoveTabControlTheme(tabControl);
			foreach (TabPage tabPage2 in tabControl.TabPages)
			{
				if (dictionary_0.TryGetValue(tabPage2, out var value4))
				{
					tabPage2.BackColor = value4.color_0;
					tabPage2.ForeColor = value4.color_1;
					tabPage2.BorderStyle = value4.borderStyle_0;
					if (value4.bool_1)
					{
						tabPage2.UseVisualStyleBackColor = value4.bool_0;
					}
				}
			}
		}
		if (control_0 is GroupBox groupBox)
		{
			RemoveDarkGroupBoxTheme(groupBox);
		}
		if (control_0 is ToolStrip toolStrip2 && dictionary_1.TryGetValue(toolStrip2, out var value5))
		{
			toolStrip2.Renderer = value5;
			if (dictionary_0.TryGetValue(control_0, out var value6))
			{
				toolStrip2.BackColor = value6.color_0;
				toolStrip2.ForeColor = value6.color_1;
			}
			foreach (ToolStripItem item2 in toolStrip2.Items)
			{
				smethod_62(item2);
			}
		}
		control_0.Invalidate(invalidateChildren: true);
		control_0.Refresh();
		ApplyNativeDarkThemeRecursive(control_0);
	}

	private static void smethod_62(ToolStripItem toolStripItem_0)
	{
		toolStripItem_0.ResetBackColor();
		toolStripItem_0.ResetForeColor();
		if (!(toolStripItem_0 is ToolStripMenuItem toolStripMenuItem))
		{
			return;
		}
		foreach (ToolStripItem dropDownItem in toolStripMenuItem.DropDownItems)
		{
			smethod_62(dropDownItem);
		}
	}

	private static void smethod_63(ToolStripItem toolStripItem_0)
	{
		if (dictionary_2.TryGetValue(toolStripItem_0, out var value))
		{
			toolStripItem_0.Image = value;
		}
		if (!(toolStripItem_0 is ToolStripDropDownItem toolStripDropDownItem))
		{
			return;
		}
		foreach (ToolStripItem dropDownItem in toolStripDropDownItem.DropDownItems)
		{
			smethod_63(dropDownItem);
		}
	}

	public static void ApplyThemeToForm(Form form)
	{
		if (form == null || form.GetType().Name == Class16.smethod_0(1648901278) || !IsDarkMode)
		{
			return;
		}
		try
		{
			form.SuspendLayout();
			if (form.IsHandleCreated)
			{
				ApplyImmersiveDarkMode(form.Handle, IsDarkMode);
			}
			ApplyTheme(form);
			ApplyNativeDarkThemeRecursive(form);
			smethod_64(form);
			smethod_65(form);
		}
		finally
		{
			form.ResumeLayout(performLayout: true);
			form.PerformLayout();
		}
	}

	private static void smethod_64(Form form_0)
	{
		try
		{
			FieldInfo[] fields = form_0.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				if (fieldInfo.FieldType == typeof(ToolTip) && fieldInfo.GetValue(form_0) is ToolTip toolTip)
				{
					ApplyThemeToToolTip(toolTip);
				}
			}
		}
		catch
		{
		}
	}

	private static void smethod_65(Form form_0)
	{
		if (!IsDarkMode || form_0 == null)
		{
			return;
		}
		try
		{
			FieldInfo[] fields = form_0.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			FieldInfo[] array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				if (fieldInfo.FieldType == typeof(ContextMenuStrip) && fieldInfo.GetValue(form_0) is ContextMenuStrip toolStrip_)
				{
					smethod_106(toolStrip_);
				}
			}
		}
		catch
		{
		}
	}

	private static bool smethod_66(Color color_0)
	{
		if (!(color_0 == Color.Empty) && !(color_0 == Color.Transparent))
		{
			int num = (color_0.R + color_0.G + color_0.B) / 3;
			return num < 100;
		}
		return true;
	}

	private static void smethod_67(object sender, EventArgs e)
	{
		if (!IsDarkMode || !(sender is Control control))
		{
			return;
		}
		if (!control.Enabled)
		{
			if (!HasCustomTextColor(control) || smethod_66(control.ForeColor))
			{
				control.ForeColor = DarkDisabledFore;
			}
			if (control is Button button)
			{
				if (!HasCustomButtonColor(button))
				{
					button.BackColor = DarkButtonDisabledBack;
				}
				button.FlatAppearance.BorderColor = Color.FromArgb(55, 55, 58);
			}
			else if (control is TextBox)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is RichTextBox)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is ComboBox comboBox)
			{
				comboBox.ForeColor = DarkDisabledFore;
				comboBox.BackColor = DarkControlBack;
			}
			else if (control is NumericUpDown numericUpDown)
			{
				numericUpDown.ForeColor = DarkDisabledFore;
				foreach (Control control4 in numericUpDown.Controls)
				{
					control4.ForeColor = DarkDisabledFore;
				}
			}
			else if (control is CheckedListBox)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is ListBox)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is TreeView)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is DateTimePicker)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is LinkLabel linkLabel)
			{
				if (!HasCustomTextColor(linkLabel) || smethod_66(linkLabel.ForeColor))
				{
					linkLabel.ForeColor = DarkDisabledFore;
					linkLabel.LinkColor = DarkDisabledFore;
					linkLabel.ActiveLinkColor = DarkDisabledFore;
					linkLabel.VisitedLinkColor = DarkDisabledFore;
				}
			}
			else if (control is Label || control is CheckBox || control is RadioButton)
			{
				if (!HasCustomTextColor(control) || smethod_66(control.ForeColor))
				{
					control.ForeColor = DarkDisabledFore;
				}
			}
			else if (control is GroupBox)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is ListView)
			{
				control.ForeColor = DarkDisabledFore;
			}
			else if (control is DataGridView dataGridView)
			{
				dataGridView.DefaultCellStyle.ForeColor = DarkDisabledFore;
			}
		}
		else if (control is Button button2)
		{
			button2.ForeColor = DarkButtonFore;
			if (!HasCustomButtonColor(button2))
			{
				button2.BackColor = DarkButtonBack;
			}
			button2.FlatAppearance.BorderColor = DarkBorder;
		}
		else if (control is TextBox)
		{
			control.ForeColor = DarkControlFore;
		}
		else if (control is RichTextBox)
		{
			control.ForeColor = DarkControlFore;
		}
		else if (control is ComboBox comboBox2)
		{
			comboBox2.ForeColor = DarkControlFore;
			comboBox2.BackColor = GetMappedDarkColor(comboBox2.BackColor, DarkControlBack);
		}
		else if (control is NumericUpDown numericUpDown2)
		{
			numericUpDown2.ForeColor = DarkControlFore;
			numericUpDown2.BackColor = DarkControlBack;
			foreach (Control control5 in numericUpDown2.Controls)
			{
				control5.ForeColor = DarkControlFore;
				control5.BackColor = DarkControlBack;
			}
		}
		else if (control is CheckedListBox)
		{
			control.ForeColor = DarkControlFore;
		}
		else if (control is ListBox)
		{
			control.ForeColor = DarkControlFore;
		}
		else if (control is TreeView)
		{
			control.ForeColor = DarkControlFore;
		}
		else if (control is DateTimePicker)
		{
			control.ForeColor = DarkControlFore;
		}
		else if (control is LinkLabel linkLabel2)
		{
			linkLabel2.ForeColor = DarkControlFore;
			linkLabel2.LinkColor = Color.FromArgb(78, 201, 176);
			linkLabel2.ActiveLinkColor = Color.FromArgb(86, 156, 214);
			linkLabel2.VisitedLinkColor = Color.FromArgb(181, 206, 168);
		}
		else if (control is Label label)
		{
			label.ForeColor = (HasCustomTextColor(label) ? label.ForeColor : DarkLabelFore);
		}
		else if (control is GroupBox)
		{
			control.ForeColor = DarkGroupBoxTitleFore;
		}
		else if (control is CheckBox checkBox)
		{
			checkBox.ForeColor = (HasCustomTextColor(checkBox) ? checkBox.ForeColor : DarkControlFore);
		}
		else if (control is RadioButton radioButton)
		{
			radioButton.ForeColor = (HasCustomTextColor(radioButton) ? radioButton.ForeColor : DarkControlFore);
		}
		else if (control is ListView)
		{
			control.ForeColor = DarkControlFore;
		}
		else if (control is DataGridView dataGridView2)
		{
			dataGridView2.DefaultCellStyle.ForeColor = DarkControlFore;
		}
		else if (!HasCustomTextColor(control))
		{
			control.ForeColor = DarkControlFore;
		}
		control.Invalidate();
	}

	private static void smethod_68(object sender, DrawListViewColumnHeaderEventArgs e)
	{
		if (!IsDarkMode)
		{
			e.DrawDefault = true;
			return;
		}
		SolidBrush solidBrush = new SolidBrush(DarkHeaderBack);
		try
		{
			e.Graphics.FillRectangle(solidBrush, e.Bounds);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		Pen pen = new Pen(DarkBorder);
		try
		{
			e.Graphics.DrawLine(pen, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
			e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right - 1, e.Bounds.Bottom - 1);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
		textFormatFlags = e.Header.TextAlign switch
		{
			HorizontalAlignment.Center => textFormatFlags | TextFormatFlags.HorizontalCenter, 
			HorizontalAlignment.Right => textFormatFlags | TextFormatFlags.Right, 
			_ => textFormatFlags, 
		};
		Rectangle bounds = new Rectangle(e.Bounds.X + 4, e.Bounds.Y, e.Bounds.Width - 8, e.Bounds.Height);
		TextRenderer.DrawText(e.Graphics, e.Header.Text, e.Font, bounds, DarkFore, textFormatFlags);
	}

	private static void smethod_69(object sender, DrawListViewItemEventArgs e)
	{
		if (IsDarkMode && sender is ListView listView)
		{
			if (listView.VirtualMode)
			{
				e.DrawDefault = true;
				return;
			}
			if (listView.View == View.Details)
			{
				Color color = (e.Item.Selected ? DarkSelectionBack : listView.BackColor);
				SolidBrush solidBrush = new SolidBrush(color);
				try
				{
					e.Graphics.FillRectangle(solidBrush, e.Bounds);
					return;
				}
				finally
				{
					((IDisposable)solidBrush).Dispose();
				}
			}
			Color color2 = (e.Item.Selected ? DarkSelectionBack : listView.BackColor);
			Color foreColor = (e.Item.Selected ? DarkSelectionFore : listView.ForeColor);
			SolidBrush solidBrush2 = new SolidBrush(color2);
			try
			{
				e.Graphics.FillRectangle(solidBrush2, e.Bounds);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
			int num = e.Bounds.X + 4;
			if (listView.CheckBoxes)
			{
				int num2 = 14;
				int x = e.Bounds.X + 4;
				int y = e.Bounds.Y + (e.Bounds.Height - 14) / 2;
				Rectangle rectangle = new Rectangle(x, y, 14, 14);
				bool flag;
				Color color3 = ((flag = e.Item.Checked) ? DarkCheckAccent : DarkControlBack);
				Color color4 = (flag ? DarkCheckAccent : DarkBorder);
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				RectangleF rect = new RectangleF((float)rectangle.X + 0.5f, (float)rectangle.Y + 0.5f, (float)rectangle.Width - 1f, (float)rectangle.Height - 1f);
				using (GraphicsPath path = CreateRoundedRect(rect, 2f))
				{
					SolidBrush solidBrush3 = new SolidBrush(color3);
					try
					{
						e.Graphics.FillPath(solidBrush3, path);
					}
					finally
					{
						((IDisposable)solidBrush3).Dispose();
					}
					Pen pen = new Pen(color4);
					try
					{
						e.Graphics.DrawPath(pen, path);
					}
					finally
					{
						((IDisposable)pen).Dispose();
					}
				}
				if (flag)
				{
					Pen pen2 = new Pen(Color.White, 2f);
					try
					{
						Point point = new Point(rectangle.X + 3, rectangle.Y + num2 / 2);
						Point point2 = new Point(rectangle.X + num2 / 2 - 1, rectangle.Bottom - 4);
						Point point3 = new Point(rectangle.Right - 3, rectangle.Y + 3);
						e.Graphics.DrawLines(pen2, new Point[3] { point, point2, point3 });
					}
					finally
					{
						((IDisposable)pen2).Dispose();
					}
				}
				e.Graphics.SmoothingMode = SmoothingMode.Default;
				num = rectangle.Right + 4;
			}
			Rectangle bounds = new Rectangle(num, e.Bounds.Y, Math.Max(0, e.Bounds.Right - num), e.Bounds.Height);
			TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter;
			TextRenderer.DrawText(e.Graphics, e.Item.Text, e.Item.Font ?? listView.Font, bounds, foreColor, flags);
			if (e.Item.Focused)
			{
				Rectangle rectangle2 = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 2, e.Bounds.Height - 2);
				ControlPaint.DrawFocusRectangle(e.Graphics, rectangle2);
			}
		}
		else
		{
			e.DrawDefault = true;
		}
	}

	private static void smethod_70(object sender, DrawListViewSubItemEventArgs e)
	{
		if (sender is ListView listView)
		{
			_ = listView.VirtualMode;
			e.DrawDefault = true;
		}
		else
		{
			e.DrawDefault = true;
		}
	}

	private static bool smethod_71(Color color_0)
	{
		int num = (color_0.R + color_0.G + color_0.B) / 3;
		return num < 100;
	}

	private static bool smethod_72(Color color_0, int int_0)
	{
		if (Math.Abs(color_0.R - color_0.G) <= int_0 && Math.Abs(color_0.G - color_0.B) <= int_0)
		{
			return Math.Abs(color_0.R - color_0.B) <= int_0;
		}
		return false;
	}

	public static bool HasCustomButtonColor(Control control_0)
	{
		if (!(control_0.BackColor == Color.Empty) && !(control_0.BackColor == Color.Transparent))
		{
			if (!(control_0.BackColor == SystemColors.Control) && !(control_0.BackColor == SystemColors.Window) && !(control_0.BackColor == SystemColors.ButtonFace))
			{
				int r = control_0.BackColor.R;
				int g = control_0.BackColor.G;
				int b = control_0.BackColor.B;
				int num = Math.Max(r, Math.Max(g, b));
				int num2 = Math.Min(r, Math.Min(g, b));
				int num3 = num - num2;
				if (num3 > 40)
				{
					return true;
				}
				return hashSet_10.Contains(control_0.BackColor.ToArgb());
			}
			return false;
		}
		return false;
	}

	public static bool HasCustomTextColor(Control control_0)
	{
		if (control_0.ForeColor == Color.Empty)
		{
			return false;
		}
		if (!(control_0.ForeColor == SystemColors.ControlText) && !(control_0.ForeColor == SystemColors.WindowText))
		{
			Color foreColor = control_0.ForeColor;
			int r = foreColor.R;
			int g = foreColor.G;
			int b = foreColor.B;
			if (r < 30 && g < 30 && b < 30)
			{
				return false;
			}
			if (smethod_71(foreColor))
			{
				return false;
			}
			if (r > 245 && g > 245 && b > 245)
			{
				return false;
			}
			if (smethod_72(foreColor, 16))
			{
				return false;
			}
			int num = Math.Max(r, Math.Max(g, b));
			int num2 = Math.Min(r, Math.Min(g, b));
			int num3 = num - num2;
			return num3 > 35;
		}
		return false;
	}

	public static bool HasCustomButtonColor(ToolStripItem item)
	{
		if (!(item.BackColor == Color.Empty) && !(item.BackColor == Color.Transparent))
		{
			int r = item.BackColor.R;
			int g = item.BackColor.G;
			int b = item.BackColor.B;
			int num = Math.Max(r, Math.Max(g, b));
			int num2 = Math.Min(r, Math.Min(g, b));
			int num3 = num - num2;
			if (num3 <= 40)
			{
				return hashSet_10.Contains(item.BackColor.ToArgb());
			}
			return true;
		}
		return false;
	}

	public static bool HasCustomTextColor(ToolStripItem item)
	{
		if (item.ForeColor == Color.Empty)
		{
			return false;
		}
		Color foreColor = item.ForeColor;
		int r = foreColor.R;
		int g = foreColor.G;
		int b = foreColor.B;
		if (r < 30 && g < 30 && b < 30)
		{
			return false;
		}
		if (smethod_71(foreColor))
		{
			return false;
		}
		if (r > 245 && g > 245 && b > 245)
		{
			return false;
		}
		if (smethod_72(foreColor, 16))
		{
			return false;
		}
		int num = Math.Max(r, Math.Max(g, b));
		int num2 = Math.Min(r, Math.Min(g, b));
		int num3 = num - num2;
		return num3 > 35;
	}

	private static Color smethod_73(Color color_0)
	{
		if (!(color_0 == Color.Empty) && !(color_0 == Color.Transparent))
		{
			int num = (color_0.R + color_0.G + color_0.B) / 3;
			if (num <= 35)
			{
				return Color.FromArgb(172, 172, 172);
			}
			if (num <= 75)
			{
				return Color.FromArgb(184, 184, 184);
			}
			if (num <= 95)
			{
				return Color.FromArgb(196, 196, 196);
			}
			return color_0;
		}
		return DarkFieldFore;
	}

	private static void smethod_74(DataGridView dataGridView_0)
	{
		if (dataGridView_0.Rows.Count == 0)
		{
			return;
		}
		bool isDarkMode = IsDarkMode;
		Dictionary<int, Color> dictionary = (IsDarkMode ? dictionary_5 : dictionary_6);
		Dictionary<int, Color> dictionary2 = (IsDarkMode ? dictionary_7 : dictionary_8);
		try
		{
			dataGridView_0.SuspendLayout();
			foreach (DataGridViewRow item in (IEnumerable)dataGridView_0.Rows)
			{
				if (item.DefaultCellStyle.BackColor != Color.Empty)
				{
					int key = item.DefaultCellStyle.BackColor.ToArgb();
					if (dictionary.TryGetValue(key, out var value))
					{
						item.DefaultCellStyle.BackColor = value;
					}
				}
				if (item.DefaultCellStyle.ForeColor != Color.Empty)
				{
					int key2 = item.DefaultCellStyle.ForeColor.ToArgb();
					if (dictionary2.TryGetValue(key2, out var value2))
					{
						item.DefaultCellStyle.ForeColor = value2;
					}
					else if (isDarkMode)
					{
						item.DefaultCellStyle.ForeColor = smethod_73(item.DefaultCellStyle.ForeColor);
					}
				}
				foreach (DataGridViewCell cell in item.Cells)
				{
					if (!cell.HasStyle)
					{
						continue;
					}
					if (cell.Style.BackColor != Color.Empty)
					{
						int key3 = cell.Style.BackColor.ToArgb();
						if (dictionary.TryGetValue(key3, out var value3))
						{
							cell.Style.BackColor = value3;
						}
					}
					if (cell.Style.ForeColor != Color.Empty)
					{
						int key4 = cell.Style.ForeColor.ToArgb();
						if (dictionary2.TryGetValue(key4, out var value4))
						{
							cell.Style.ForeColor = value4;
						}
						else if (isDarkMode)
						{
							cell.Style.ForeColor = smethod_73(cell.Style.ForeColor);
						}
					}
				}
			}
		}
		catch
		{
		}
		finally
		{
			dataGridView_0.ResumeLayout(performLayout: true);
		}
	}

	public static void ApplyThemeToTabControl(TabControl tab)
	{
		if (tab == null)
		{
			return;
		}
		if (IsDarkMode)
		{
			tab.Appearance = TabAppearance.Normal;
			tab.DrawMode = TabDrawMode.OwnerDrawFixed;
			tab.BackColor = DarkBack;
			tab.ForeColor = DarkFore;
			try
			{
				tab.GetType().InvokeMember(Class16.smethod_0(1648901289), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, tab, new object[2]
				{
					ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer,
					true
				});
				tab.GetType().InvokeMember(Class16.smethod_0(1648901304), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, tab, null);
			}
			catch
			{
			}
			smethod_77(tab);
			if (!hashSet_11.Contains(tab))
			{
				tab.DrawItem += smethod_84;
				tab.ControlAdded += smethod_81;
				tab.SelectedIndexChanged += smethod_82;
				tab.HandleCreated += smethod_75;
				tab.Disposed += smethod_76;
				hashSet_11.Add(tab);
			}
			if (!hashSet_12.Contains(tab))
			{
				tab.Paint += smethod_83;
				hashSet_12.Add(tab);
			}
			smethod_78(tab);
			tab.Invalidate();
		}
		else
		{
			RemoveTabControlTheme(tab);
		}
	}

	public static void RemoveTabControlTheme(TabControl tab)
	{
		if (tab != null)
		{
			tab.DrawMode = TabDrawMode.Normal;
			if (hashSet_11.Contains(tab))
			{
				tab.DrawItem -= smethod_84;
				tab.ControlAdded -= smethod_81;
				tab.SelectedIndexChanged -= smethod_82;
				tab.HandleCreated -= smethod_75;
				tab.Disposed -= smethod_76;
				hashSet_11.Remove(tab);
			}
			if (hashSet_12.Contains(tab))
			{
				tab.Paint -= smethod_83;
				hashSet_12.Remove(tab);
			}
			tab.Invalidate();
		}
	}

	private static void smethod_75(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is TabControl tabControl)
		{
			smethod_77(tabControl);
			smethod_78(tabControl);
			tabControl.Invalidate();
		}
	}

	private static void smethod_76(object sender, EventArgs e)
	{
		if (sender is TabControl tab)
		{
			RemoveTabControlTheme(tab);
		}
	}

	private static void smethod_77(TabControl tabControl_0)
	{
		if (IsDarkMode && tabControl_0 != null && tabControl_0.IsHandleCreated)
		{
			try
			{
				smethod_7(tabControl_0.Handle, bool_1: true);
				SetWindowTheme(tabControl_0.Handle, Class16.smethod_0(1648901152), null);
				SendMessage(tabControl_0.Handle, 794, IntPtr.Zero, IntPtr.Zero);
			}
			catch
			{
			}
		}
	}

	private static void smethod_78(TabControl tabControl_0)
	{
		foreach (TabPage tabPage in tabControl_0.TabPages)
		{
			smethod_79(tabPage);
		}
	}

	private static void smethod_79(TabPage tabPage_0)
	{
		if (tabPage_0 != null)
		{
			tabPage_0.UseVisualStyleBackColor = false;
			tabPage_0.BackColor = DarkBack;
			tabPage_0.ForeColor = DarkFore;
			tabPage_0.BorderStyle = BorderStyle.None;
			smethod_80(tabPage_0);
		}
	}

	private static void smethod_80(Control control_0)
	{
		if (control_0 == null || !control_0.HasChildren)
		{
			return;
		}
		foreach (Control control in control_0.Controls)
		{
			if (control is Panel || control is GroupBox || control is FlowLayoutPanel || control is TableLayoutPanel || control is UserControl || control is ContainerControl || control is ScrollableControl)
			{
				if (control.BackColor == SystemColors.Control || control.BackColor == Color.Transparent || control.BackColor == Color.White || control.BackColor == Color.Empty || control.BackColor == Color.FromArgb(240, 240, 240))
				{
					control.BackColor = DarkBack;
				}
				if (control.ForeColor == SystemColors.ControlText || control.ForeColor == Color.Black || control.ForeColor == Color.Empty)
				{
					control.ForeColor = (control.Enabled ? DarkFore : DarkDisabledFore);
				}
				if (control.HasChildren)
				{
					smethod_80(control);
				}
			}
		}
	}

	private static void smethod_81(object sender, ControlEventArgs e)
	{
		if (IsDarkMode && e.Control is TabPage tabPage)
		{
			smethod_79(tabPage);
			ApplyTheme(tabPage);
			if (sender is TabControl tabControl)
			{
				tabControl.Invalidate();
			}
		}
	}

	private static void smethod_82(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is TabControl tabControl)
		{
			smethod_78(tabControl);
			tabControl.Invalidate();
		}
	}

	private static void smethod_83(object sender, PaintEventArgs e)
	{
		if (!(sender is TabControl tabControl) || !IsDarkMode)
		{
			return;
		}
		smethod_78(tabControl);
		Rectangle clientRectangle = tabControl.ClientRectangle;
		if (clientRectangle.Width <= 0 || clientRectangle.Height <= 0)
		{
			return;
		}
		Color color = DarkHeaderBack;
		if (tabControl.Parent != null && tabControl.Parent.BackColor != Color.Empty && tabControl.Parent.BackColor != Color.Transparent)
		{
			color = GetMappedDarkColor(tabControl.Parent.BackColor, DarkHeaderBack);
		}
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			e.Graphics.FillRectangle(solidBrush, clientRectangle);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		Rectangle displayRectangle = tabControl.DisplayRectangle;
		if (displayRectangle.Width > 0 && displayRectangle.Height > 0)
		{
			Rectangle rect = new Rectangle(displayRectangle.X - 2, displayRectangle.Y - 2, displayRectangle.Width + 4, displayRectangle.Height + 4);
			rect.Intersect(clientRectangle);
			SolidBrush solidBrush2 = new SolidBrush(DarkBack);
			try
			{
				e.Graphics.FillRectangle(solidBrush2, rect);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
			Pen pen = new Pen(DarkBorder);
			try
			{
				e.Graphics.DrawRectangle(pen, rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}
		for (int i = 0; i < tabControl.TabCount; i++)
		{
			Rectangle tabRect = tabControl.GetTabRect(i);
			DrawItemState state = ((tabControl.SelectedIndex == i) ? DrawItemState.Selected : DrawItemState.Default);
			DrawItemEventArgs e2 = new DrawItemEventArgs(e.Graphics, tabControl.Font, tabRect, i, state, tabControl.ForeColor, tabControl.BackColor);
			smethod_84(tabControl, e2);
		}
	}

	private static void smethod_84(object sender, DrawItemEventArgs e)
	{
		if (!(sender is TabControl tabControl) || e.Index < 0 || e.Index >= tabControl.TabCount)
		{
			return;
		}
		TabPage tabPage = tabControl.TabPages[e.Index];
		bool flag = tabControl.SelectedIndex == e.Index;
		Color color;
		Color foreColor;
		if (IsDarkMode)
		{
			color = (flag ? DarkBack : DarkHeaderBack);
			foreColor = (flag ? Color.White : Color.FromArgb(170, 170, 170));
		}
		else
		{
			color = (flag ? SystemColors.Window : SystemColors.Control);
			foreColor = (flag ? SystemColors.WindowText : SystemColors.ControlText);
		}
		Rectangle bounds = e.Bounds;
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			e.Graphics.FillRectangle(solidBrush, bounds);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		if (IsDarkMode)
		{
			Pen pen = new Pen(DarkBorder);
			try
			{
				e.Graphics.DrawLine(pen, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
				e.Graphics.DrawLine(pen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
				e.Graphics.DrawLine(pen, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
				if (!flag)
				{
					e.Graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
				}
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
			if (flag)
			{
				Pen pen2 = new Pen(DarkBack);
				try
				{
					e.Graphics.DrawLine(pen2, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
				}
				finally
				{
					((IDisposable)pen2).Dispose();
				}
			}
		}
		TextRenderer.DrawText(e.Graphics, tabPage.Text, tabControl.Font, bounds, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
	}

	public static void EnsureDarkGroupBox(GroupBox groupBox)
	{
		if (groupBox == null)
		{
			return;
		}
		if (!IsDarkMode)
		{
			RemoveDarkGroupBoxTheme(groupBox);
			return;
		}
		groupBox.FlatStyle = FlatStyle.Flat;
		if (!hashSet_13.Contains(groupBox))
		{
			hashSet_13.Add(groupBox);
			groupBox.Paint += smethod_87;
			groupBox.HandleCreated += smethod_85;
			groupBox.Disposed += smethod_86;
			groupBox.Invalidate();
		}
	}

	public static void RemoveDarkGroupBoxTheme(GroupBox groupBox)
	{
		if (groupBox != null && hashSet_13.Contains(groupBox))
		{
			groupBox.Paint -= smethod_87;
			groupBox.HandleCreated -= smethod_85;
			groupBox.Disposed -= smethod_86;
			hashSet_13.Remove(groupBox);
			groupBox.Invalidate();
		}
	}

	private static void smethod_85(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is GroupBox groupBox)
		{
			groupBox.Invalidate();
		}
	}

	private static void smethod_86(object sender, EventArgs e)
	{
		if (sender is GroupBox groupBox)
		{
			RemoveDarkGroupBoxTheme(groupBox);
		}
	}

	private static void smethod_87(object sender, PaintEventArgs e)
	{
		if (!IsDarkMode || !(sender is GroupBox { ClientRectangle: { Width: >=4, Height: >=4 } clientRectangle } groupBox))
		{
			return;
		}
		string text = groupBox.Text ?? string.Empty;
		int num = 8;
		Size size = TextRenderer.MeasureText(e.Graphics, string.IsNullOrEmpty(text) ? Class16.smethod_0(1648942211) : text, groupBox.Font, new Size(Math.Max(1, clientRectangle.Width - 16), clientRectangle.Height), TextFormatFlags.SingleLine);
		int num2 = Math.Max(1, size.Height / 2);
		int num3 = clientRectangle.Right - 1;
		int num4 = clientRectangle.Bottom - 1;
		int left = clientRectangle.Left;
		int num5 = num + Math.Max(0, size.Width);
		if (num5 > num3 - 4)
		{
			num5 = num3 - 4;
		}
		Color backColor = groupBox.BackColor;
		SolidBrush solidBrush = new SolidBrush(backColor);
		try
		{
			e.Graphics.FillRectangle(solidBrush, clientRectangle);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		Pen pen = new Pen(DarkBorderSoft);
		try
		{
			e.Graphics.DrawLine(pen, left, num2, Math.Max(left, num - 2), num2);
			if (num5 + 2 < num3)
			{
				e.Graphics.DrawLine(pen, num5 + 2, num2, num3, num2);
			}
			e.Graphics.DrawLine(pen, left, num2, left, num4);
			e.Graphics.DrawLine(pen, num3, num2, num3, num4);
			e.Graphics.DrawLine(pen, left, num4, num3, num4);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		if (!string.IsNullOrEmpty(text))
		{
			Rectangle rectangle = new Rectangle(num, 0, Math.Max(0, clientRectangle.Width - num - 8), size.Height);
			SolidBrush solidBrush2 = new SolidBrush(backColor);
			try
			{
				e.Graphics.FillRectangle(solidBrush2, rectangle);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
			TextRenderer.DrawText(e.Graphics, text, groupBox.Font, rectangle, DarkGroupBoxTitleFore, TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
		}
	}

	public static void EnsureDarkButton(Button button)
	{
		if (button != null && IsDarkMode && !hashSet_14.Contains(button))
		{
			hashSet_14.Add(button);
			button.FlatAppearance.BorderSize = 0;
			button.Paint += smethod_89;
			button.Disposed += smethod_88;
		}
	}

	private static void smethod_88(object sender, EventArgs e)
	{
		if (sender is Button button)
		{
			button.Paint -= smethod_89;
			button.Disposed -= smethod_88;
			hashSet_14.Remove(button);
		}
	}

	private static void smethod_89(object sender, PaintEventArgs e)
	{
		if (!IsDarkMode || !(sender is Button button))
		{
			return;
		}
		Graphics graphics = e.Graphics;
		Rectangle clientRectangle = button.ClientRectangle;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = !button.Enabled;
		bool focused = button.Focused;
		if (!flag3)
		{
			try
			{
				Point pt = button.PointToClient(Cursor.Position);
				flag2 = (flag = button.ClientRectangle.Contains(pt)) && (Control.MouseButtons & MouseButtons.Left) != 0;
			}
			catch
			{
			}
		}
		Color color;
		Color color2;
		if (flag3)
		{
			color = (HasCustomButtonColor(button) ? GetMappedDarkColor(button.BackColor, DarkButtonDisabledBack) : DarkButtonDisabledBack);
			color2 = Color.FromArgb(55, 55, 58);
		}
		else if (flag2)
		{
			color = DarkSelectionBack;
			color2 = Color.FromArgb(0, 100, 180);
		}
		else if (flag)
		{
			color = DarkHover;
			color2 = Color.FromArgb(80, 80, 88);
		}
		else
		{
			color = (HasCustomButtonColor(button) ? button.BackColor : DarkButtonBack);
			color2 = (focused ? Color.FromArgb(0, 120, 215) : DarkBorder);
		}
		Color color3 = button.Parent?.BackColor ?? DarkBack;
		if (color3 == Color.Transparent)
		{
			color3 = DarkBack;
		}
		SolidBrush solidBrush = new SolidBrush(color3);
		try
		{
			graphics.FillRectangle(solidBrush, clientRectangle);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		RectangleF rect = new RectangleF((float)clientRectangle.X + 0.5f, (float)clientRectangle.Y + 0.5f, (float)clientRectangle.Width - 1.5f, (float)clientRectangle.Height - 1.5f);
		graphics.SmoothingMode = SmoothingMode.AntiAlias;
		using (GraphicsPath path = CreateRoundedRect(rect, 3f))
		{
			SolidBrush solidBrush2 = new SolidBrush(color);
			try
			{
				graphics.FillPath(solidBrush2, path);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
			Pen pen = new Pen(color2);
			try
			{
				graphics.DrawPath(pen, path);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}
		graphics.SmoothingMode = SmoothingMode.Default;
		Rectangle rectangle_ = new Rectangle(clientRectangle.X + 3, clientRectangle.Y + 3, clientRectangle.Width - 6, clientRectangle.Height - 6);
		smethod_90(graphics, button, rectangle_, flag3);
		if (focused && !flag3)
		{
			ControlPaint.DrawFocusRectangle(rectangle: new Rectangle(clientRectangle.X + 3, clientRectangle.Y + 3, clientRectangle.Width - 7, clientRectangle.Height - 7), graphics: e.Graphics);
		}
	}

	private static void smethod_90(Graphics graphics_0, Button button_0, Rectangle rectangle_0, bool bool_1)
	{
		Image image = button_0.Image;
		string text = button_0.Text;
		bool flag = image != null;
		bool flag2 = !string.IsNullOrEmpty(text);
		Color color = (bool_1 ? DarkDisabledFore : (HasCustomTextColor(button_0) ? button_0.ForeColor : DarkButtonFore));
		if (flag && flag2)
		{
			smethod_113(graphics_0, button_0, image, text, rectangle_0, color, bool_1);
		}
		else if (flag)
		{
			Rectangle rectangle_1 = smethod_114(image, rectangle_0, button_0.ImageAlign);
			smethod_115(graphics_0, image, rectangle_1, bool_1);
		}
		else if (flag2)
		{
			TextFormatFlags flags = smethod_116(button_0.TextAlign);
			TextRenderer.DrawText(graphics_0, text, button_0.Font, rectangle_0, color, flags);
		}
	}

	public static void EnsureDarkRadioButton(RadioButton radioButton)
	{
		if (radioButton == null || !IsDarkMode || radioButton.Appearance == Appearance.Button || hashSet_16.Contains(radioButton))
		{
			return;
		}
		hashSet_16.Add(radioButton);
		if (radioButton.BackColor == Color.Transparent || radioButton.BackColor == Color.Empty)
		{
			Color color = radioButton.Parent?.BackColor ?? DarkBack;
			if (color == Color.Transparent || color == Color.Empty)
			{
				color = DarkBack;
			}
			radioButton.BackColor = color;
		}
		smethod_97(radioButton);
		radioButton.Paint += smethod_92;
		radioButton.Disposed += smethod_91;
	}

	private static void smethod_91(object sender, EventArgs e)
	{
		if (sender is RadioButton radioButton)
		{
			radioButton.Paint -= smethod_92;
			radioButton.Disposed -= smethod_91;
			hashSet_16.Remove(radioButton);
		}
	}

	private static void smethod_92(object sender, PaintEventArgs e)
	{
		if (!IsDarkMode || !(sender is RadioButton { Appearance: not Appearance.Button, BackColor: var color } radioButton))
		{
			return;
		}
		if (color == Color.Transparent || color == Color.Empty)
		{
			color = radioButton.Parent?.BackColor ?? DarkBack;
		}
		if (color == Color.Transparent)
		{
			color = DarkBack;
		}
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			e.Graphics.FillRectangle(solidBrush, radioButton.ClientRectangle);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		int num = 14;
		int num2 = (radioButton.Height - 14) / 2;
		int num3 = radioButton.Padding.Left + 1;
		Rectangle rect = new Rectangle(num3, num2, 14, 14);
		Color color2 = (radioButton.Checked ? DarkCheckAccent : Color.FromArgb(100, 100, 100));
		Color color3 = (radioButton.Checked ? DarkCheckAccent : DarkControlBack);
		if (!radioButton.Enabled)
		{
			color2 = Color.FromArgb(75, 75, 78);
			color3 = (radioButton.Checked ? DarkDisabledCheckAccent : Color.FromArgb(45, 45, 48));
		}
		e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
		SolidBrush solidBrush2 = new SolidBrush(color3);
		try
		{
			e.Graphics.FillEllipse(solidBrush2, rect);
		}
		finally
		{
			((IDisposable)solidBrush2).Dispose();
		}
		Pen pen = new Pen(color2, 1.2f);
		try
		{
			e.Graphics.DrawEllipse(pen, rect);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		if (radioButton.Checked)
		{
			int num4 = 6;
			int x = num3 + (num - 6) / 2;
			int y = num2 + (num - 6) / 2;
			Color color4 = (radioButton.Enabled ? Color.White : DarkDisabledFore);
			SolidBrush solidBrush3 = new SolidBrush(color4);
			try
			{
				e.Graphics.FillEllipse(solidBrush3, x, y, num4, num4);
			}
			finally
			{
				((IDisposable)solidBrush3).Dispose();
			}
		}
		e.Graphics.SmoothingMode = SmoothingMode.Default;
		int num5 = num3 + num + 4;
		Rectangle bounds = new Rectangle(num5, 0, Math.Max(0, radioButton.Width - num5 + 3), radioButton.Height);
		Color foreColor = ((!radioButton.Enabled) ? DarkDisabledFore : (HasCustomTextColor(radioButton) ? radioButton.ForeColor : DarkControlFore));
		TextRenderer.DrawText(e.Graphics, radioButton.Text, radioButton.Font, bounds, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
		if (radioButton.Focused)
		{
			ControlPaint.DrawFocusRectangle(rectangle: new Rectangle(num5 - 1, 1, Math.Max(0, radioButton.Width - num5), radioButton.Height - 2), graphics: e.Graphics);
		}
	}

	public static void EnsureDarkCheckedListBox(CheckedListBox checkedListBox)
	{
		if (checkedListBox != null && IsDarkMode && !hashSet_17.Contains(checkedListBox))
		{
			hashSet_17.Add(checkedListBox);
			checkedListBox.DrawMode = DrawMode.OwnerDrawFixed;
			checkedListBox.DrawItem += smethod_94;
			checkedListBox.Disposed += smethod_93;
		}
	}

	private static void smethod_93(object sender, EventArgs e)
	{
		if (sender is CheckedListBox checkedListBox)
		{
			checkedListBox.DrawItem -= smethod_94;
			checkedListBox.Disposed -= smethod_93;
			hashSet_17.Remove(checkedListBox);
		}
	}

	private static void smethod_94(object sender, DrawItemEventArgs e)
	{
		if (!IsDarkMode || !(sender is CheckedListBox checkedListBox) || e.Index < 0 || e.Index >= checkedListBox.Items.Count)
		{
			return;
		}
		bool flag;
		Color color = ((flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected) ? DarkSelectionBack : DarkControlBack);
		Color foreColor = (flag ? DarkSelectionFore : DarkControlFore);
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			e.Graphics.FillRectangle(solidBrush, e.Bounds);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		bool itemChecked = checkedListBox.GetItemChecked(e.Index);
		int num = 13;
		int num2 = e.Bounds.X + 3;
		int y = e.Bounds.Y + (e.Bounds.Height - 13) / 2;
		Rectangle rect = new Rectangle(num2, y, 13, 13);
		Color color2 = (itemChecked ? DarkCheckAccent : DarkControlBack);
		Color color3 = (itemChecked ? DarkCheckAccent : Color.FromArgb(100, 100, 100));
		SolidBrush solidBrush2 = new SolidBrush(color2);
		try
		{
			e.Graphics.FillRectangle(solidBrush2, rect);
		}
		finally
		{
			((IDisposable)solidBrush2).Dispose();
		}
		Pen pen = new Pen(color3);
		try
		{
			e.Graphics.DrawRectangle(pen, rect);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
		if (itemChecked)
		{
			Pen pen2 = new Pen(Color.White, 1.6f);
			try
			{
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				Point point = new Point(rect.X + 2, rect.Y + num / 2);
				Point point2 = new Point(rect.X + num / 2 - 1, rect.Bottom - 3);
				Point point3 = new Point(rect.Right - 2, rect.Y + 3);
				e.Graphics.DrawLines(pen2, new Point[3] { point, point2, point3 });
				e.Graphics.SmoothingMode = SmoothingMode.Default;
			}
			finally
			{
				((IDisposable)pen2).Dispose();
			}
		}
		object obj = checkedListBox.Items[e.Index];
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = obj.ToString();
			if (obj2 != null)
			{
				goto IL_022e;
			}
		}
		obj2 = string.Empty;
		goto IL_022e;
		IL_022e:
		string text = (string)obj2;
		int num3 = num2 + num + 5;
		Rectangle bounds = new Rectangle(num3, e.Bounds.Y, Math.Max(0, e.Bounds.Width - num3), e.Bounds.Height);
		TextRenderer.DrawText(e.Graphics, text, e.Font ?? checkedListBox.Font, bounds, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
		if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
		{
			ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, foreColor, color);
		}
	}

	public static void ApplyDarkScrollBarsToControl(Control control)
	{
		if (control == null || !IsDarkMode)
		{
			return;
		}
		try
		{
			if (control.IsHandleCreated)
			{
				smethod_7(control.Handle, bool_1: true);
			}
			foreach (Control control2 in control.Controls)
			{
				if (control2 is VScrollBar vScrollBar)
				{
					SetControlDarkExplorerTheme(vScrollBar);
					if (vScrollBar.IsHandleCreated)
					{
						smethod_7(vScrollBar.Handle, bool_1: true);
					}
				}
				else if (control2 is HScrollBar hScrollBar)
				{
					SetControlDarkExplorerTheme(hScrollBar);
					if (hScrollBar.IsHandleCreated)
					{
						smethod_7(hScrollBar.Handle, bool_1: true);
					}
				}
				if (control2.HasChildren)
				{
					ApplyDarkScrollBarsToControl(control2);
				}
			}
		}
		catch
		{
		}
	}

	public static void EnsureDarkListBox(ListBox listBox)
	{
		if (listBox != null && IsDarkMode && !(listBox is CheckedListBox) && !hashSet_18.Contains(listBox) && listBox.DrawMode == DrawMode.Normal && (!listBox.IsHandleCreated || listBox.Items.Count <= 0))
		{
			hashSet_18.Add(listBox);
			listBox.DrawMode = DrawMode.OwnerDrawFixed;
			listBox.DrawItem += smethod_96;
			listBox.Disposed += smethod_95;
		}
	}

	private static void smethod_95(object sender, EventArgs e)
	{
		if (sender is ListBox listBox)
		{
			listBox.DrawItem -= smethod_96;
			listBox.Disposed -= smethod_95;
			hashSet_18.Remove(listBox);
		}
	}

	private static void smethod_96(object sender, DrawItemEventArgs e)
	{
		if (!IsDarkMode || !(sender is ListBox listBox) || e.Index < 0 || e.Index >= listBox.Items.Count)
		{
			return;
		}
		bool flag;
		Color color = ((flag = (e.State & DrawItemState.Selected) == DrawItemState.Selected) ? DarkSelectionBack : DarkControlBack);
		Color foreColor = (flag ? DarkSelectionFore : DarkControlFore);
		if (!flag && e.Index % 2 == 1)
		{
			color = DarkAlternateRowBack;
		}
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			e.Graphics.FillRectangle(solidBrush, e.Bounds);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		object obj = listBox.Items[e.Index];
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = obj.ToString();
			if (obj2 != null)
			{
				goto IL_00c5;
			}
		}
		obj2 = string.Empty;
		goto IL_00c5;
		IL_00c5:
		string text = (string)obj2;
		Rectangle bounds = new Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height);
		TextRenderer.DrawText(e.Graphics, text, e.Font ?? listBox.Font, bounds, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
		if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
		{
			ControlPaint.DrawFocusRectangle(e.Graphics, e.Bounds, foreColor, color);
		}
	}

	public static void EnsureDarkTrackBar(TrackBar trackBar)
	{
		if (trackBar != null && IsDarkMode)
		{
			trackBar.BackColor = DarkBack;
			SetControlDarkExplorerTheme(trackBar);
			if (trackBar.IsHandleCreated)
			{
				smethod_7(trackBar.Handle, bool_1: true);
				SendMessage(trackBar.Handle, 794, IntPtr.Zero, IntPtr.Zero);
			}
		}
	}

	private static void smethod_97(Control control_0)
	{
		try
		{
			typeof(Control).GetProperty(Class16.smethod_0(1648901323), BindingFlags.Instance | BindingFlags.NonPublic)?.SetValue(control_0, true);
		}
		catch
		{
		}
	}

	internal static GraphicsPath CreateRoundedRect(RectangleF rect, float radius)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		float num = radius * 2f;
		if (num > rect.Width)
		{
			num = rect.Width;
		}
		if (num > rect.Height)
		{
			num = rect.Height;
		}
		graphicsPath.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
		graphicsPath.AddArc(rect.Right - num, rect.Y, num, num, 270f, 90f);
		graphicsPath.AddArc(rect.Right - num, rect.Bottom - num, num, num, 0f, 90f);
		graphicsPath.AddArc(rect.X, rect.Bottom - num, num, num, 90f, 90f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	public static void EnsureDarkTextBoxBase(TextBoxBase textBox)
	{
		if (textBox != null && IsDarkMode && !hashSet_19.Contains(textBox))
		{
			hashSet_19.Add(textBox);
			textBox.ReadOnlyChanged -= smethod_98;
			textBox.EnabledChanged -= smethod_99;
			textBox.HandleCreated -= smethod_100;
			textBox.Disposed -= smethod_101;
			textBox.ReadOnlyChanged += smethod_98;
			textBox.EnabledChanged += smethod_99;
			textBox.HandleCreated += smethod_100;
			textBox.Disposed += smethod_101;
			if (textBox.IsHandleCreated)
			{
				SetControlDarkExplorerTheme(textBox);
				smethod_102(textBox);
			}
		}
	}

	private static void smethod_98(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is TextBoxBase { Enabled: not false } textBoxBase)
		{
			textBoxBase.BackColor = (textBoxBase.ReadOnly ? DarkReadOnlyBack : DarkControlBack);
			textBoxBase.Invalidate();
		}
	}

	private static void smethod_99(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is TextBoxBase textBoxBase)
		{
			if (textBoxBase.Enabled)
			{
				textBoxBase.BackColor = (textBoxBase.ReadOnly ? DarkReadOnlyBack : DarkControlBack);
				textBoxBase.ForeColor = DarkControlFore;
			}
			else
			{
				textBoxBase.BackColor = DarkControlBack;
				textBoxBase.ForeColor = DarkDisabledFore;
			}
			smethod_102(textBoxBase);
			textBoxBase.Invalidate();
		}
	}

	private static void smethod_100(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is TextBoxBase textBoxBase)
		{
			SetControlDarkExplorerTheme(textBoxBase);
			smethod_102(textBoxBase);
		}
	}

	private static void smethod_101(object sender, EventArgs e)
	{
		if (sender is TextBoxBase textBoxBase)
		{
			textBoxBase.ReadOnlyChanged -= smethod_98;
			textBoxBase.EnabledChanged -= smethod_99;
			textBoxBase.HandleCreated -= smethod_100;
			textBoxBase.Disposed -= smethod_101;
			hashSet_19.Remove(textBoxBase);
		}
	}

	public static void EnsureDarkTreeView(TreeView treeView)
	{
		if (treeView != null && IsDarkMode && treeView.IsHandleCreated)
		{
			try
			{
				smethod_7(treeView.Handle, bool_1: true);
				SetWindowTheme(treeView.Handle, Class16.smethod_0(1648901152), null);
				SendMessage(treeView.Handle, 794, IntPtr.Zero, IntPtr.Zero);
			}
			catch
			{
			}
		}
	}

	private static void smethod_102(Control control_0)
	{
		if (control_0 != null && IsDarkMode && control_0.IsHandleCreated)
		{
			try
			{
				SendMessage(control_0.Handle, 794, IntPtr.Zero, IntPtr.Zero);
			}
			catch
			{
			}
		}
	}

	private static void smethod_103(object sender, EventArgs e)
	{
		if (sender is WebBrowser webBrowser)
		{
			webBrowser.DocumentCompleted -= smethod_52;
			webBrowser.Disposed -= smethod_103;
			hashSet_4.Remove(webBrowser);
		}
	}

	private static void smethod_104(WebBrowser webBrowser_0)
	{
		if (webBrowser_0?.Document == null)
		{
			return;
		}
		try
		{
			webBrowser_0.Document.BackColor = DarkControlBack;
			webBrowser_0.Document.ForeColor = DarkControlFore;
			HtmlElement body = webBrowser_0.Document.Body;
			if (body != null)
			{
				body.Style = string.Format(Class16.smethod_0(1648901344), DarkControlBack.R, DarkControlBack.G, DarkControlBack.B, DarkControlFore.R, DarkControlFore.G, DarkControlFore.B, DarkBack.R, DarkBack.G, DarkBack.B, DarkButtonBack.R, DarkButtonBack.G, DarkButtonBack.B, DarkBack.R, DarkBack.G, DarkBack.B, DarkFore.R, DarkFore.G, DarkFore.B, DarkBack.R, DarkBack.G, DarkBack.B);
			}
		}
		catch
		{
		}
	}

	public static void ApplyNativeDarkThemeRecursive(Control control)
	{
		if (control == null || !IsDarkMode)
		{
			return;
		}
		if (control is TextBox || control is RichTextBox || control is ListBox || control is CheckedListBox || control is ComboBox || control is NumericUpDown || control is TreeView || control is DataGridView || control is ListView || control is CheckBox || control is RadioButton || control is ScrollBar || control is ProgressBar || control is DateTimePicker || control is TabControl || control is TabPage || control is Panel || control is FlowLayoutPanel || control is TableLayoutPanel || control is SplitContainer || control is SplitterPanel || control is UserControl)
		{
			SetControlDarkExplorerTheme(control);
		}
		if (control is DateTimePicker dateTimePicker)
		{
			EnsureDarkDateTimePicker(dateTimePicker);
		}
		else if (control is ComboBox comboBox)
		{
			EnsureDarkComboBox(comboBox);
		}
		else if (control is NumericUpDown numericUpDown)
		{
			EnsureDarkNumericUpDown(numericUpDown);
		}
		else if (control is DataGridView dataGridView)
		{
			EnsureDarkDataGridView(dataGridView);
		}
		else if (control is WebBrowser webBrowser)
		{
			EnsureDarkWebBrowser(webBrowser);
		}
		else if (control is MonthCalendar monthCalendar)
		{
			EnsureDarkMonthCalendar(monthCalendar);
		}
		else if (control is TextBoxBase textBox)
		{
			EnsureDarkTextBoxBase(textBox);
		}
		else if (control is TreeView treeView)
		{
			EnsureDarkTreeView(treeView);
		}
		else if (control is ListBox)
		{
			smethod_102(control);
		}
		else if (control is ProgressBar)
		{
			smethod_102(control);
		}
		if (!control.HasChildren)
		{
			return;
		}
		foreach (Control control2 in control.Controls)
		{
			ApplyNativeDarkThemeRecursive(control2);
		}
	}

	public static Color GetMappedDarkColor(Color color, Color fallbackColor)
	{
		if (dictionary_6.ContainsKey(color.ToArgb()))
		{
			return color;
		}
		if (dictionary_5.TryGetValue(color.ToArgb(), out var value))
		{
			return value;
		}
		int num = (color.R + color.G + color.B) / 3;
		if (num < 80)
		{
			return color;
		}
		return fallbackColor;
	}

	private static void smethod_105(Control control_0)
	{
		if (control_0 is Form form && form.GetType().Name == Class16.smethod_0(1648901278))
		{
			return;
		}
		if (control_0 is Form form2)
		{
			form2.BackColor = DarkBack;
			form2.ForeColor = DarkFore;
			if (form2.IsHandleCreated)
			{
				ApplyImmersiveDarkMode(form2.Handle, enabled: true);
			}
		}
		else if (control_0 is Button button)
		{
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderColor = DarkBorder;
			button.FlatAppearance.BorderSize = 1;
			button.FlatAppearance.MouseOverBackColor = DarkHover;
			button.FlatAppearance.MouseDownBackColor = DarkSelectionBack;
			if (!HasCustomButtonColor(button))
			{
				button.BackColor = DarkButtonBack;
				button.ForeColor = DarkButtonFore;
			}
			else
			{
				button.BackColor = GetMappedDarkColor(button.BackColor, DarkButtonBack);
				if (!HasCustomTextColor(button) || smethod_66(button.ForeColor))
				{
					button.ForeColor = DarkButtonFore;
				}
			}
			if (button.Image != null)
			{
				button.Image = GetInvertedImage(button.Image);
			}
			if (button.BackgroundImage != null)
			{
				button.BackgroundImage = GetInvertedImage(button.BackgroundImage);
			}
			EnsureDarkButton(button);
		}
		else if (control_0 is TextBox textBox)
		{
			bool flag = !string.IsNullOrEmpty(textBox.Name) && textBox.Name.IndexOf(Class16.smethod_0(1648905100), StringComparison.OrdinalIgnoreCase) >= 0;
			if (textBox.ReadOnly && !flag)
			{
				textBox.BackColor = DarkReadOnlyBack;
			}
			else if (flag)
			{
				textBox.BackColor = DarkNameCardBack;
			}
			else
			{
				textBox.BackColor = GetMappedDarkColor(textBox.BackColor, DarkControlBack);
			}
			textBox.ForeColor = (textBox.Enabled ? DarkControlFore : DarkDisabledFore);
			textBox.BorderStyle = BorderStyle.FixedSingle;
			EnsureDarkTextBoxBase(textBox);
		}
		else if (control_0 is RichTextBox richTextBox)
		{
			if (richTextBox.ReadOnly)
			{
				richTextBox.BackColor = DarkReadOnlyBack;
			}
			else
			{
				richTextBox.BackColor = GetMappedDarkColor(richTextBox.BackColor, DarkControlBack);
			}
			richTextBox.ForeColor = (richTextBox.Enabled ? DarkControlFore : DarkDisabledFore);
			richTextBox.BorderStyle = BorderStyle.FixedSingle;
			EnsureDarkTextBoxBase(richTextBox);
		}
		else if (control_0 is CheckedListBox checkedListBox)
		{
			checkedListBox.BackColor = GetMappedDarkColor(checkedListBox.BackColor, DarkControlBack);
			checkedListBox.ForeColor = (checkedListBox.Enabled ? DarkControlFore : DarkDisabledFore);
			checkedListBox.BorderStyle = BorderStyle.FixedSingle;
			EnsureDarkCheckedListBox(checkedListBox);
		}
		else if (control_0 is ListBox listBox)
		{
			listBox.BackColor = GetMappedDarkColor(listBox.BackColor, DarkControlBack);
			listBox.ForeColor = (listBox.Enabled ? DarkControlFore : DarkDisabledFore);
			listBox.BorderStyle = BorderStyle.FixedSingle;
			EnsureDarkListBox(listBox);
		}
		else if (control_0 is ComboBox comboBox)
		{
			comboBox.BackColor = GetMappedDarkColor(comboBox.BackColor, DarkControlBack);
			comboBox.ForeColor = (comboBox.Enabled ? DarkControlFore : DarkDisabledFore);
			comboBox.FlatStyle = FlatStyle.Flat;
			EnsureDarkComboBox(comboBox);
		}
		else if (control_0 is NumericUpDown numericUpDown)
		{
			numericUpDown.BackColor = GetMappedDarkColor(numericUpDown.BackColor, DarkControlBack);
			numericUpDown.ForeColor = (numericUpDown.Enabled ? DarkControlFore : DarkDisabledFore);
			numericUpDown.BorderStyle = BorderStyle.FixedSingle;
			EnsureDarkNumericUpDown(numericUpDown);
		}
		else if (control_0 is TreeView treeView)
		{
			treeView.BackColor = DarkControlBack;
			treeView.ForeColor = DarkControlFore;
			treeView.BorderStyle = BorderStyle.FixedSingle;
			treeView.LineColor = DarkBorder;
			EnsureDarkTreeView(treeView);
		}
		else if (control_0 is DataGridView dataGridView)
		{
			dataGridView.BackgroundColor = GetMappedDarkColor(dataGridView.BackgroundColor, DarkControlBack);
			dataGridView.GridColor = DarkGridLine;
			dataGridView.EnableHeadersVisualStyles = false;
			dataGridView.BorderStyle = BorderStyle.None;
			dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
			dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridView.DefaultCellStyle.BackColor = DarkControlBack;
			dataGridView.DefaultCellStyle.ForeColor = DarkControlFore;
			dataGridView.DefaultCellStyle.SelectionBackColor = DarkSelectionBack;
			dataGridView.DefaultCellStyle.SelectionForeColor = DarkSelectionFore;
			dataGridView.ColumnHeadersDefaultCellStyle.BackColor = DarkHeaderBack;
			dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = DarkFore;
			dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = DarkHeaderBack;
			dataGridView.ColumnHeadersDefaultCellStyle.SelectionForeColor = DarkFore;
			dataGridView.RowTemplate.DefaultCellStyle.BackColor = DarkControlBack;
			dataGridView.RowTemplate.DefaultCellStyle.ForeColor = DarkControlFore;
			dataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = DarkSelectionBack;
			dataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = DarkSelectionFore;
			dataGridView.RowHeadersDefaultCellStyle.BackColor = DarkHeaderBack;
			dataGridView.RowHeadersDefaultCellStyle.ForeColor = DarkFore;
			dataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = DarkSelectionBack;
			dataGridView.RowHeadersDefaultCellStyle.SelectionForeColor = DarkSelectionFore;
			dataGridView.AlternatingRowsDefaultCellStyle.BackColor = DarkAlternateRowBack;
			dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = DarkControlFore;
			dataGridView.AlternatingRowsDefaultCellStyle.SelectionBackColor = DarkSelectionBack;
			dataGridView.AlternatingRowsDefaultCellStyle.SelectionForeColor = DarkSelectionFore;
			smethod_111(dataGridView);
			smethod_74(dataGridView);
			EnsureDarkDataGridView(dataGridView);
		}
		else if (control_0 is TabControl tabControl)
		{
			tabControl.BackColor = DarkBack;
			tabControl.ForeColor = DarkFore;
			ApplyThemeToTabControl(tabControl);
			foreach (TabPage tabPage3 in tabControl.TabPages)
			{
				tabPage3.UseVisualStyleBackColor = false;
				tabPage3.BackColor = DarkBack;
				tabPage3.ForeColor = DarkFore;
				tabPage3.BorderStyle = BorderStyle.None;
				ApplyTheme(tabPage3);
			}
		}
		else if (control_0 is TabPage tabPage2)
		{
			tabPage2.UseVisualStyleBackColor = false;
			tabPage2.BackColor = DarkBack;
			tabPage2.ForeColor = DarkFore;
			tabPage2.BorderStyle = BorderStyle.None;
			if (tabPage2.BackgroundImage != null)
			{
				tabPage2.BackgroundImage = GetInvertedImage(tabPage2.BackgroundImage);
			}
		}
		else if (control_0 is ToolStripContainer toolStripContainer)
		{
			toolStripContainer.BackColor = DarkBack;
			toolStripContainer.ForeColor = DarkFore;
			toolStripContainer.ContentPanel.BackColor = DarkBack;
			toolStripContainer.ContentPanel.ForeColor = DarkFore;
			toolStripContainer.TopToolStripPanel.BackColor = DarkBack;
			toolStripContainer.TopToolStripPanel.ForeColor = DarkFore;
			toolStripContainer.BottomToolStripPanel.BackColor = DarkBack;
			toolStripContainer.BottomToolStripPanel.ForeColor = DarkFore;
			toolStripContainer.LeftToolStripPanel.BackColor = DarkBack;
			toolStripContainer.LeftToolStripPanel.ForeColor = DarkFore;
			toolStripContainer.RightToolStripPanel.BackColor = DarkBack;
			toolStripContainer.RightToolStripPanel.ForeColor = DarkFore;
		}
		else if (control_0 is ToolStripContentPanel toolStripContentPanel)
		{
			toolStripContentPanel.BackColor = toolStripContentPanel.Parent?.BackColor ?? DarkBack;
			toolStripContentPanel.ForeColor = DarkFore;
		}
		else if (control_0 is ToolStripPanel toolStripPanel)
		{
			toolStripPanel.BackColor = toolStripPanel.Parent?.BackColor ?? DarkBack;
			toolStripPanel.ForeColor = DarkFore;
		}
		else if (control_0 is Panel panel)
		{
			panel.BackColor = DarkBack;
			panel.ForeColor = DarkFore;
			if (panel.BackgroundImage != null)
			{
				panel.BackgroundImage = GetInvertedImage(panel.BackgroundImage);
			}
		}
		else if (control_0 is GroupBox groupBox)
		{
			Color backColor = ((groupBox.Parent != null) ? GetMappedDarkColor(groupBox.Parent.BackColor, DarkBack) : DarkBack);
			groupBox.BackColor = backColor;
			groupBox.ForeColor = DarkGroupBoxTitleFore;
			groupBox.FlatStyle = FlatStyle.Flat;
			EnsureDarkGroupBox(groupBox);
		}
		else if (control_0 is FlowLayoutPanel flowLayoutPanel)
		{
			Color backColor2 = ((flowLayoutPanel.Parent != null) ? GetMappedDarkColor(flowLayoutPanel.Parent.BackColor, DarkBack) : DarkBack);
			flowLayoutPanel.BackColor = backColor2;
			flowLayoutPanel.ForeColor = DarkFore;
			flowLayoutPanel.BorderStyle = BorderStyle.None;
		}
		else if (control_0 is TableLayoutPanel tableLayoutPanel)
		{
			Color backColor3 = ((tableLayoutPanel.Parent != null) ? GetMappedDarkColor(tableLayoutPanel.Parent.BackColor, DarkBack) : DarkBack);
			tableLayoutPanel.BackColor = backColor3;
			tableLayoutPanel.ForeColor = DarkFore;
			tableLayoutPanel.BorderStyle = BorderStyle.None;
		}
		else if (control_0 is UserControl userControl)
		{
			userControl.BackColor = DarkBack;
			userControl.ForeColor = DarkFore;
		}
		else if (control_0 is SplitContainer splitContainer)
		{
			splitContainer.BackColor = DarkBorder;
			splitContainer.ForeColor = DarkFore;
			splitContainer.Panel1.BackColor = DarkBack;
			splitContainer.Panel2.BackColor = DarkBack;
		}
		else if (control_0 is SplitterPanel splitterPanel)
		{
			splitterPanel.BackColor = DarkBack;
			splitterPanel.ForeColor = DarkFore;
		}
		else if (control_0 is PictureBox { BackColor: var backColor4 } pictureBox)
		{
			int num = (backColor4.R + pictureBox.BackColor.G + pictureBox.BackColor.B) / 3;
			if (pictureBox.BackColor == Color.White || pictureBox.BackColor == SystemColors.Control || pictureBox.BackColor == SystemColors.Window || pictureBox.BackColor == SystemColors.InactiveBorder || num > 200)
			{
				pictureBox.BackColor = GetMappedDarkColor(pictureBox.BackColor, DarkBack);
			}
			if (pictureBox.Image != null)
			{
				pictureBox.Image = GetInvertedImage(pictureBox.Image);
			}
			if (pictureBox.BackgroundImage != null)
			{
				pictureBox.BackgroundImage = GetInvertedImage(pictureBox.BackgroundImage);
			}
		}
		else if (control_0 is MdiClient mdiClient)
		{
			mdiClient.BackColor = DarkBack;
		}
		else if (control_0 is Label label)
		{
			if (!label.Enabled)
			{
				label.ForeColor = DarkDisabledFore;
			}
			else if (!HasCustomTextColor(label))
			{
				label.ForeColor = DarkLabelFore;
			}
			if (!(label.BackColor == SystemColors.Control) && !(label.BackColor == Color.White) && !(label.BackColor == Color.Transparent) && !(label.BackColor == SystemColors.Window) && !(label.BackColor == SystemColors.InactiveBorder) && !(label.BackColor == Color.FromArgb(240, 240, 240)))
			{
				int num2 = (label.BackColor.R + label.BackColor.G + label.BackColor.B) / 3;
				if (num2 > 180)
				{
					label.BackColor = GetMappedDarkColor(label.BackColor, DarkBack);
				}
			}
			else if (label.Parent != null && (label.Parent is GroupBox || label.Parent is Panel || label.Parent is TabPage))
			{
				label.BackColor = Color.Transparent;
			}
			else
			{
				label.BackColor = DarkBack;
			}
			if (label.Image != null)
			{
				label.Image = GetInvertedImage(label.Image);
			}
		}
		else if (control_0 is LinkLabel linkLabel)
		{
			if (!linkLabel.Enabled)
			{
				linkLabel.LinkColor = DarkDisabledFore;
				linkLabel.ForeColor = DarkDisabledFore;
			}
			else
			{
				linkLabel.LinkColor = Color.FromArgb(78, 201, 176);
				linkLabel.ActiveLinkColor = Color.FromArgb(86, 156, 214);
				linkLabel.VisitedLinkColor = Color.FromArgb(181, 206, 168);
			}
			if (linkLabel.BackColor == SystemColors.Control || linkLabel.BackColor == Color.White || linkLabel.BackColor == Color.Transparent || linkLabel.BackColor == SystemColors.Window || linkLabel.BackColor == Color.FromArgb(240, 240, 240))
			{
				if (linkLabel.Parent != null && (linkLabel.Parent is GroupBox || linkLabel.Parent is Panel || linkLabel.Parent is TabPage))
				{
					linkLabel.BackColor = Color.Transparent;
				}
				else
				{
					linkLabel.BackColor = DarkBack;
				}
			}
		}
		else if (control_0 is CheckBox checkBox)
		{
			if (checkBox.Appearance == Appearance.Button)
			{
				checkBox.BackColor = DarkButtonBack;
				checkBox.ForeColor = DarkButtonFore;
				checkBox.FlatStyle = FlatStyle.Flat;
				checkBox.FlatAppearance.BorderColor = DarkBorder;
				checkBox.FlatAppearance.BorderSize = 1;
				checkBox.FlatAppearance.MouseOverBackColor = DarkHover;
				checkBox.FlatAppearance.CheckedBackColor = DarkSelectionBack;
			}
			else
			{
				Control parent = checkBox.Parent;
				if ((parent is GroupBox || parent is Panel) ? true : false)
				{
					checkBox.BackColor = Color.Transparent;
				}
				else
				{
					checkBox.BackColor = DarkBack;
				}
				if (!HasCustomTextColor(checkBox))
				{
					checkBox.ForeColor = DarkControlFore;
				}
				EnsureDarkCheckBox(checkBox);
			}
			if (checkBox.Image != null)
			{
				checkBox.Image = GetInvertedImage(checkBox.Image);
			}
			if (checkBox.BackgroundImage != null)
			{
				checkBox.BackgroundImage = GetInvertedImage(checkBox.BackgroundImage);
			}
		}
		else if (control_0 is RadioButton radioButton)
		{
			if (radioButton.Appearance == Appearance.Button)
			{
				EnsureDarkButtonRadio(radioButton);
			}
			else
			{
				Control parent = radioButton.Parent;
				if ((parent is GroupBox || parent is Panel) ? true : false)
				{
					radioButton.BackColor = Color.Transparent;
				}
				else
				{
					radioButton.BackColor = DarkBack;
				}
				if (!HasCustomTextColor(radioButton))
				{
					radioButton.ForeColor = DarkControlFore;
				}
				EnsureDarkRadioButton(radioButton);
			}
			if (radioButton.Image != null)
			{
				radioButton.Image = GetInvertedImage(radioButton.Image);
			}
			if (radioButton.BackgroundImage != null)
			{
				radioButton.BackgroundImage = GetInvertedImage(radioButton.BackgroundImage);
			}
		}
		else if (control_0 is ProgressBar progressBar)
		{
			progressBar.BackColor = DarkBack;
			progressBar.ForeColor = DarkCheckAccent;
		}
		else if (control_0 is TrackBar trackBar)
		{
			trackBar.BackColor = DarkBack;
			EnsureDarkTrackBar(trackBar);
		}
		else if (control_0 is StatusStrip statusStrip)
		{
			statusStrip.BackColor = DarkHeaderBack;
			statusStrip.ForeColor = DarkFore;
			statusStrip.SizingGrip = false;
			statusStrip.RenderMode = ToolStripRenderMode.Professional;
			statusStrip.Renderer = toolStripRenderer_0;
			foreach (ToolStripItem item in statusStrip.Items)
			{
				if (!HasCustomTextColor(item))
				{
					item.ForeColor = DarkFore;
				}
				if (!HasCustomButtonColor(item))
				{
					item.BackColor = DarkHeaderBack;
				}
				if (item is ToolStripStatusLabel toolStripStatusLabel)
				{
					toolStripStatusLabel.BorderSides = ToolStripStatusLabelBorderSides.None;
					toolStripStatusLabel.BorderStyle = Border3DStyle.Flat;
					toolStripStatusLabel.BackColor = Color.FromArgb(40, 40, 43);
					if (!HasCustomTextColor(toolStripStatusLabel) || smethod_66(toolStripStatusLabel.ForeColor))
					{
						toolStripStatusLabel.ForeColor = DarkFore;
					}
				}
				if (item is ToolStripProgressBar { ProgressBar: not null } toolStripProgressBar)
				{
					toolStripProgressBar.BackColor = DarkHeaderBack;
					toolStripProgressBar.ForeColor = DarkFore;
					toolStripProgressBar.ProgressBar.BackColor = DarkBack;
					toolStripProgressBar.ProgressBar.ForeColor = DarkSelectionBack;
					SetControlDarkExplorerTheme(toolStripProgressBar.ProgressBar);
				}
			}
		}
		else if (control_0 is ToolStrip toolStrip_)
		{
			smethod_106(toolStrip_);
		}
		else if (control_0 is PropertyGrid propertyGrid)
		{
			propertyGrid.BackColor = DarkBack;
			propertyGrid.ViewBackColor = DarkControlBack;
			propertyGrid.ViewForeColor = DarkControlFore;
			propertyGrid.LineColor = DarkBorder;
			propertyGrid.CategoryForeColor = DarkFore;
			propertyGrid.CategorySplitterColor = DarkBorder;
			propertyGrid.CommandsForeColor = DarkFore;
			propertyGrid.CommandsBackColor = DarkBack;
			propertyGrid.HelpBackColor = DarkBack;
			propertyGrid.HelpForeColor = DarkFore;
			propertyGrid.HelpBorderColor = DarkBorder;
			propertyGrid.ViewBorderColor = DarkBorder;
		}
		else if (control_0 is DateTimePicker dateTimePicker)
		{
			dateTimePicker.BackColor = DarkControlBack;
			dateTimePicker.ForeColor = (dateTimePicker.Enabled ? DarkControlFore : DarkDisabledFore);
			dateTimePicker.CalendarMonthBackground = DarkControlBack;
			dateTimePicker.CalendarForeColor = DarkControlFore;
			dateTimePicker.CalendarTitleBackColor = DarkHeaderBack;
			dateTimePicker.CalendarTitleForeColor = DarkFore;
			dateTimePicker.CalendarTrailingForeColor = Color.FromArgb(128, 128, 128);
			EnsureDarkDateTimePicker(dateTimePicker);
		}
		else if (control_0 is MonthCalendar monthCalendar)
		{
			monthCalendar.BackColor = DarkControlBack;
			monthCalendar.ForeColor = DarkControlFore;
			monthCalendar.TitleBackColor = DarkHeaderBack;
			monthCalendar.TitleForeColor = DarkFore;
			monthCalendar.TrailingForeColor = Color.FromArgb(128, 128, 128);
			EnsureDarkMonthCalendar(monthCalendar);
		}
		else if (control_0 is ListView listView)
		{
			listView.BackColor = DarkControlBack;
			listView.ForeColor = DarkControlFore;
			listView.BorderStyle = BorderStyle.FixedSingle;
			dictionary_4[listView] = listView.GridLines;
			listView.GridLines = false;
			listView.DrawColumnHeader -= smethod_68;
			listView.DrawItem -= smethod_69;
			listView.DrawSubItem -= smethod_70;
			listView.OwnerDraw = true;
			listView.DrawColumnHeader += smethod_68;
			listView.DrawItem += smethod_69;
			listView.DrawSubItem += smethod_70;
			if (listView.IsHandleCreated)
			{
				SetWindowTheme(listView.Handle, Class16.smethod_0(1648901152), null);
				smethod_7(listView.Handle, bool_1: true);
				IntPtr intPtr = SendMessage(listView.Handle, 4127, IntPtr.Zero, IntPtr.Zero);
				if (intPtr != IntPtr.Zero)
				{
					smethod_7(intPtr, bool_1: true);
					SetWindowTheme(intPtr, Class16.smethod_0(1648901549), null);
					SendMessage(intPtr, 794, IntPtr.Zero, IntPtr.Zero);
				}
			}
		}
		else if (control_0 is WebBrowser)
		{
			EnsureDarkWebBrowser((WebBrowser)control_0);
		}
		else
		{
			try
			{
				if (control_0.BackColor != Color.Transparent && !HasCustomButtonColor(control_0) && (control_0.BackColor == Color.White || control_0.BackColor == SystemColors.Control || control_0.BackColor == SystemColors.Window || control_0.BackColor == SystemColors.InactiveBorder || control_0.BackColor == Color.FromArgb(240, 240, 240) || control_0.BackColor == Color.FromArgb(255, 255, 255)))
				{
					control_0.BackColor = DarkBack;
				}
				if (!HasCustomTextColor(control_0))
				{
					control_0.ForeColor = DarkFore;
				}
			}
			catch
			{
			}
		}
		if (control_0 is TextBox || control_0 is RichTextBox || control_0 is ListBox || control_0 is CheckedListBox || control_0 is ComboBox || control_0 is NumericUpDown || control_0 is TreeView || control_0 is DataGridView || control_0 is CheckBox || control_0 is RadioButton || control_0 is ScrollBar || control_0 is ProgressBar || control_0 is DateTimePicker || control_0 is Button || control_0 is ListView || control_0 is TabControl || control_0 is TabPage || control_0 is Panel || control_0 is TrackBar || control_0 is FlowLayoutPanel || control_0 is TableLayoutPanel || control_0 is SplitContainer || control_0 is SplitterPanel || control_0 is UserControl)
		{
			SetControlDarkExplorerTheme(control_0);
		}
		if (!control_0.Enabled && (!HasCustomTextColor(control_0) || smethod_66(control_0.ForeColor)))
		{
			control_0.ForeColor = DarkDisabledFore;
		}
		control_0.EnabledChanged -= smethod_67;
		control_0.EnabledChanged += smethod_67;
	}

	private static void smethod_106(ToolStrip toolStrip_0)
	{
		if (IsDarkMode)
		{
			toolStrip_0.BackColor = DarkControlBack;
			toolStrip_0.ForeColor = DarkFore;
			toolStrip_0.RenderMode = ToolStripRenderMode.Professional;
			toolStrip_0.Renderer = toolStripRenderer_0;
			if (toolStrip_0 is ToolStripDropDown toolStripDropDown)
			{
				toolStripDropDown.BackColor = DarkControlBack;
				toolStripDropDown.ForeColor = DarkFore;
				smethod_107(toolStripDropDown);
			}
			foreach (ToolStripItem item in toolStrip_0.Items)
			{
				smethod_112(item);
				if (item is ToolStripComboBox toolStripComboBox)
				{
					toolStripComboBox.BackColor = DarkControlBack;
					toolStripComboBox.ForeColor = DarkFore;
					toolStripComboBox.ComboBox.BackColor = DarkControlBack;
					toolStripComboBox.ComboBox.ForeColor = DarkControlFore;
					toolStripComboBox.ComboBox.FlatStyle = FlatStyle.Flat;
					EnsureDarkComboBox(toolStripComboBox.ComboBox);
				}
				else if (item is ToolStripTextBox toolStripTextBox)
				{
					toolStripTextBox.BackColor = DarkControlBack;
					toolStripTextBox.ForeColor = DarkControlFore;
					toolStripTextBox.BorderStyle = BorderStyle.FixedSingle;
					toolStripTextBox.TextBox.BackColor = DarkControlBack;
					toolStripTextBox.TextBox.ForeColor = DarkControlFore;
					toolStripTextBox.TextBox.BorderStyle = BorderStyle.FixedSingle;
					SetControlDarkExplorerTheme(toolStripTextBox.TextBox);
				}
			}
		}
		try
		{
			if (typeof(ToolStrip).GetField(Class16.smethod_0(1648901574), BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(toolStrip_0) is ToolTip toolTip)
			{
				ApplyThemeToToolTip(toolTip);
			}
		}
		catch
		{
		}
	}

	private static void smethod_107(ToolStripDropDown toolStripDropDown_0)
	{
		if (toolStripDropDown_0 != null && !hashSet_9.Contains(toolStripDropDown_0))
		{
			toolStripDropDown_0.Opening += smethod_109;
			toolStripDropDown_0.Disposed += smethod_108;
			hashSet_9.Add(toolStripDropDown_0);
		}
	}

	private static void smethod_108(object sender, EventArgs e)
	{
		if (sender is ToolStripDropDown toolStripDropDown)
		{
			toolStripDropDown.Opening -= smethod_109;
			toolStripDropDown.Disposed -= smethod_108;
			hashSet_9.Remove(toolStripDropDown);
		}
	}

	private static void smethod_109(object sender, CancelEventArgs e)
	{
		if (!IsDarkMode || !(sender is ToolStripDropDown toolStripDropDown))
		{
			return;
		}
		smethod_106(toolStripDropDown);
		foreach (ToolStripItem item in toolStripDropDown.Items)
		{
			if (item is ToolStripMenuItem toolStripMenuItem)
			{
				toolStripMenuItem.DropDownOpening -= smethod_110;
				toolStripMenuItem.DropDownOpening += smethod_110;
			}
		}
	}

	private static void smethod_110(object sender, EventArgs e)
	{
		if (IsDarkMode && sender is ToolStripMenuItem { DropDown: not null } toolStripMenuItem)
		{
			smethod_106(toolStripMenuItem.DropDown);
		}
	}

	private static void smethod_111(DataGridView dataGridView_0)
	{
		foreach (DataGridViewColumn column in dataGridView_0.Columns)
		{
			DataGridViewCellStyle defaultCellStyle = column.DefaultCellStyle;
			if (defaultCellStyle != null)
			{
				defaultCellStyle.BackColor = ((defaultCellStyle.BackColor == Color.Empty) ? DarkControlBack : GetMappedDarkColor(defaultCellStyle.BackColor, DarkControlBack));
				if (defaultCellStyle.ForeColor == Color.Empty || defaultCellStyle.ForeColor == Color.Black || defaultCellStyle.ForeColor == SystemColors.ControlText || defaultCellStyle.ForeColor == SystemColors.WindowText || smethod_66(defaultCellStyle.ForeColor))
				{
					defaultCellStyle.ForeColor = DarkControlFore;
				}
				defaultCellStyle.SelectionBackColor = DarkSelectionBack;
				defaultCellStyle.SelectionForeColor = DarkSelectionFore;
			}
			if (column.HeaderCell?.Style != null)
			{
				Color color = (((!string.IsNullOrEmpty(column.Name) && column.Name.IndexOf(Class16.smethod_0(1648905100), StringComparison.OrdinalIgnoreCase) >= 0) || (!string.IsNullOrEmpty(column.HeaderText) && column.HeaderText.IndexOf(Class16.smethod_0(1648905100), StringComparison.OrdinalIgnoreCase) >= 0)) ? DarkNameCardBack : DarkHeaderBack);
				column.HeaderCell.Style.BackColor = color;
				column.HeaderCell.Style.ForeColor = DarkFore;
				column.HeaderCell.Style.SelectionBackColor = color;
				column.HeaderCell.Style.SelectionForeColor = DarkFore;
			}
			if (column is DataGridViewComboBoxColumn dataGridViewComboBoxColumn)
			{
				dataGridViewComboBoxColumn.FlatStyle = FlatStyle.Flat;
				dataGridViewComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
				dataGridViewComboBoxColumn.DisplayStyleForCurrentCellOnly = true;
			}
			else if (column is DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn)
			{
				dataGridViewCheckBoxColumn.FlatStyle = FlatStyle.Flat;
			}
			else if (column is DataGridViewButtonColumn dataGridViewButtonColumn)
			{
				dataGridViewButtonColumn.FlatStyle = FlatStyle.Flat;
				dataGridViewButtonColumn.DefaultCellStyle.BackColor = DarkButtonBack;
				dataGridViewButtonColumn.DefaultCellStyle.ForeColor = DarkButtonFore;
				dataGridViewButtonColumn.DefaultCellStyle.SelectionBackColor = DarkButtonBack;
				dataGridViewButtonColumn.DefaultCellStyle.SelectionForeColor = DarkButtonFore;
			}
		}
	}

	private static void smethod_112(ToolStripItem toolStripItem_0)
	{
		if (IsDarkMode)
		{
			if (!HasCustomButtonColor(toolStripItem_0))
			{
				toolStripItem_0.BackColor = DarkControlBack;
			}
			toolStripItem_0.ForeColor = ((!toolStripItem_0.Enabled) ? DarkDisabledFore : (HasCustomTextColor(toolStripItem_0) ? toolStripItem_0.ForeColor : DarkFore));
			if (toolStripItem_0.Image != null)
			{
				toolStripItem_0.Image = GetInvertedImage(toolStripItem_0.Image);
			}
		}
		if (toolStripItem_0 is ToolStripMenuItem toolStripMenuItem)
		{
			if (toolStripMenuItem.DropDown != null)
			{
				smethod_106(toolStripMenuItem.DropDown);
			}
			{
				foreach (ToolStripItem dropDownItem in toolStripMenuItem.DropDownItems)
				{
					smethod_112(dropDownItem);
				}
				return;
			}
		}
		if (!(toolStripItem_0 is ToolStripDropDownButton toolStripDropDownButton))
		{
			return;
		}
		if (toolStripDropDownButton.DropDown != null)
		{
			smethod_106(toolStripDropDownButton.DropDown);
		}
		foreach (ToolStripItem dropDownItem2 in toolStripDropDownButton.DropDownItems)
		{
			smethod_112(dropDownItem2);
		}
	}

	private static void smethod_113(Graphics graphics_0, Button button_0, Image image_0, string string_1, Rectangle rectangle_0, Color color_0, bool bool_1)
	{
		int width = image_0.Width;
		int height = image_0.Height;
		Rectangle rectangle_1;
		Rectangle bounds;
		switch (button_0.TextImageRelation)
		{
		case TextImageRelation.ImageAboveText:
		{
			int num6 = height + 2 + TextRenderer.MeasureText(string_1, button_0.Font).Height;
			int y = rectangle_0.Y + Math.Max(0, (rectangle_0.Height - num6) / 2);
			rectangle_1 = new Rectangle(rectangle_0.X + (rectangle_0.Width - width) / 2, y, width, height);
			int num7 = rectangle_1.Bottom + 2;
			bounds = new Rectangle(rectangle_0.X, num7, rectangle_0.Width, Math.Max(0, rectangle_0.Bottom - num7));
			break;
		}
		case TextImageRelation.TextAboveImage:
		{
			Size size3 = TextRenderer.MeasureText(string_1, button_0.Font);
			int num4 = size3.Height + 2 + height;
			int num5 = rectangle_0.Y + Math.Max(0, (rectangle_0.Height - num4) / 2);
			bounds = new Rectangle(rectangle_0.X, num5, rectangle_0.Width, size3.Height);
			rectangle_1 = new Rectangle(rectangle_0.X + (rectangle_0.Width - width) / 2, num5 + size3.Height + 2, width, height);
			break;
		}
		case TextImageRelation.ImageBeforeText:
		{
			Size size2 = TextRenderer.MeasureText(string_1, button_0.Font, new Size(int.MaxValue, rectangle_0.Height), TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
			int num3 = width + 4 + size2.Width;
			int x = rectangle_0.X + Math.Max(0, (rectangle_0.Width - num3) / 2);
			rectangle_1 = new Rectangle(x, rectangle_0.Y + (rectangle_0.Height - height) / 2, width, height);
			int x2 = rectangle_1.Right + 4;
			bounds = new Rectangle(x2, rectangle_0.Y, size2.Width + 2, rectangle_0.Height);
			break;
		}
		default:
			rectangle_1 = smethod_114(image_0, rectangle_0, button_0.ImageAlign);
			bounds = rectangle_0;
			break;
		case TextImageRelation.TextBeforeImage:
		{
			Size size = TextRenderer.MeasureText(string_1, button_0.Font, new Size(int.MaxValue, rectangle_0.Height), TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
			int num = size.Width + 4 + width;
			int num2 = rectangle_0.X + Math.Max(0, (rectangle_0.Width - num) / 2);
			bounds = new Rectangle(num2, rectangle_0.Y, size.Width + 2, rectangle_0.Height);
			rectangle_1 = new Rectangle(num2 + size.Width + 4, rectangle_0.Y + (rectangle_0.Height - height) / 2, width, height);
			break;
		}
		}
		smethod_115(graphics_0, image_0, rectangle_1, bool_1);
		TextImageRelation textImageRelation = button_0.TextImageRelation;
		TextRenderer.DrawText(flags: (textImageRelation == TextImageRelation.ImageBeforeText || textImageRelation == TextImageRelation.TextBeforeImage) ? (TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding) : smethod_116(button_0.TextAlign), dc: graphics_0, text: string_1, font: button_0.Font, bounds: bounds, foreColor: color_0);
	}

	private static Rectangle smethod_114(Image image_0, Rectangle rectangle_0, ContentAlignment contentAlignment_0)
	{
		int width = image_0.Width;
		int height = image_0.Height;
		int x;
		if ((contentAlignment_0 != ContentAlignment.TopLeft && contentAlignment_0 != ContentAlignment.MiddleLeft && contentAlignment_0 != ContentAlignment.BottomLeft) || 1 == 0)
		{
			bool flag = ((contentAlignment_0 == ContentAlignment.TopRight || contentAlignment_0 == ContentAlignment.MiddleRight || contentAlignment_0 == ContentAlignment.BottomRight) ? true : false);
			x = ((!flag) ? (rectangle_0.X + (rectangle_0.Width - width) / 2) : (rectangle_0.Right - width));
		}
		else
		{
			x = rectangle_0.X;
		}
		int y;
		if (((uint)(contentAlignment_0 - 1) > 1u && contentAlignment_0 != ContentAlignment.TopRight) || 1 == 0)
		{
			bool flag = ((contentAlignment_0 == ContentAlignment.BottomLeft || contentAlignment_0 == ContentAlignment.BottomCenter || contentAlignment_0 == ContentAlignment.BottomRight) ? true : false);
			y = ((!flag) ? (rectangle_0.Y + (rectangle_0.Height - height) / 2) : (rectangle_0.Bottom - height));
		}
		else
		{
			y = rectangle_0.Y;
		}
		return new Rectangle(x, y, width, height);
	}

	private static void smethod_115(Graphics graphics_0, Image image_0, Rectangle rectangle_0, bool bool_1)
	{
		if (bool_1)
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			try
			{
				float[][] newColorMatrix = new float[5][]
				{
					new float[5] { 0.33f, 0.33f, 0.33f, 0f, 0f },
					new float[5] { 0.33f, 0.33f, 0.33f, 0f, 0f },
					new float[5] { 0.33f, 0.33f, 0.33f, 0f, 0f },
					new float[5] { 0f, 0f, 0f, 0.5f, 0f },
					new float[5] { 0f, 0f, 0f, 0f, 1f }
				};
				imageAttributes.SetColorMatrix(new ColorMatrix(newColorMatrix));
				graphics_0.DrawImage(image_0, rectangle_0, 0, 0, image_0.Width, image_0.Height, GraphicsUnit.Pixel, imageAttributes);
				return;
			}
			finally
			{
				((IDisposable)imageAttributes).Dispose();
			}
		}
		graphics_0.DrawImage(image_0, rectangle_0);
	}

	private static TextFormatFlags smethod_116(ContentAlignment contentAlignment_0)
	{
		TextFormatFlags textFormatFlags = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine;
		return contentAlignment_0 switch
		{
			ContentAlignment.MiddleLeft => textFormatFlags | TextFormatFlags.VerticalCenter, 
			ContentAlignment.TopLeft => textFormatFlags, 
			ContentAlignment.TopCenter => textFormatFlags | TextFormatFlags.HorizontalCenter, 
			ContentAlignment.TopRight => textFormatFlags | TextFormatFlags.Right, 
			ContentAlignment.BottomLeft => textFormatFlags | TextFormatFlags.Bottom, 
			ContentAlignment.MiddleRight => textFormatFlags | (TextFormatFlags.Right | TextFormatFlags.VerticalCenter), 
			ContentAlignment.BottomRight => textFormatFlags | (TextFormatFlags.Bottom | TextFormatFlags.Right), 
			ContentAlignment.BottomCenter => textFormatFlags | (TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter), 
			_ => textFormatFlags | (TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter), 
		};
	}

	public static void EnsureDarkCheckBox(CheckBox checkBox)
	{
		if (checkBox == null || !IsDarkMode || checkBox.Appearance == Appearance.Button || hashSet_15.Contains(checkBox))
		{
			return;
		}
		hashSet_15.Add(checkBox);
		if (checkBox.BackColor == Color.Transparent || checkBox.BackColor == Color.Empty)
		{
			Color color = checkBox.Parent?.BackColor ?? DarkBack;
			if (color == Color.Transparent || color == Color.Empty)
			{
				color = DarkBack;
			}
			checkBox.BackColor = color;
		}
		smethod_97(checkBox);
		checkBox.Paint += smethod_118;
		checkBox.Disposed += smethod_117;
	}

	private static void smethod_117(object sender, EventArgs e)
	{
		if (sender is CheckBox checkBox)
		{
			checkBox.Paint -= smethod_118;
			checkBox.Disposed -= smethod_117;
			hashSet_15.Remove(checkBox);
		}
	}

	private static void smethod_118(object sender, PaintEventArgs e)
	{
		if (!IsDarkMode || !(sender is CheckBox { Appearance: not Appearance.Button, BackColor: var color } checkBox))
		{
			return;
		}
		if (color == Color.Transparent || color == Color.Empty)
		{
			color = checkBox.Parent?.BackColor ?? DarkBack;
		}
		if (color == Color.Transparent)
		{
			color = DarkBack;
		}
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			e.Graphics.FillRectangle(solidBrush, checkBox.ClientRectangle);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		int num = 14;
		int y = (checkBox.Height - 14) / 2;
		int num2 = checkBox.Padding.Left + 1;
		Rectangle rectangle = new Rectangle(num2, y, 14, 14);
		bool flag = checkBox.CheckState == CheckState.Checked;
		bool flag2 = checkBox.CheckState == CheckState.Indeterminate;
		Color color2 = ((flag || flag2) ? DarkCheckAccent : DarkControlBack);
		Color color3 = ((flag || flag2) ? DarkCheckAccent : DarkBorder);
		if (!checkBox.Enabled)
		{
			color2 = ((flag || flag2) ? DarkDisabledCheckAccent : Color.FromArgb(45, 45, 48));
			color3 = Color.FromArgb(75, 75, 78);
		}
		bool flag3 = false;
		try
		{
			Point pt = checkBox.PointToClient(Cursor.Position);
			flag3 = checkBox.ClientRectangle.Contains(pt);
		}
		catch
		{
		}
		if (flag3 && checkBox.Enabled && !flag && !flag2)
		{
			color3 = DarkCheckAccent;
		}
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		RectangleF rect = new RectangleF((float)rectangle.X + 0.5f, (float)rectangle.Y + 0.5f, (float)rectangle.Width - 1f, (float)rectangle.Height - 1f);
		using (GraphicsPath path = CreateRoundedRect(rect, 2f))
		{
			SolidBrush solidBrush2 = new SolidBrush(color2);
			try
			{
				e.Graphics.FillPath(solidBrush2, path);
			}
			finally
			{
				((IDisposable)solidBrush2).Dispose();
			}
			Pen pen = new Pen(color3);
			try
			{
				e.Graphics.DrawPath(pen, path);
			}
			finally
			{
				((IDisposable)pen).Dispose();
			}
		}
		if (flag || flag2)
		{
			Color color4 = (checkBox.Enabled ? Color.White : DarkDisabledFore);
			Pen pen2 = new Pen(color4, 2f);
			try
			{
				if (flag2)
				{
					int num3 = rectangle.Y + rectangle.Height / 2;
					e.Graphics.DrawLine(pen2, rectangle.X + 3, num3, rectangle.Right - 3, num3);
				}
				else
				{
					Point point = new Point(rectangle.X + 3, rectangle.Y + num / 2);
					Point point2 = new Point(rectangle.X + num / 2 - 1, rectangle.Bottom - 4);
					Point point3 = new Point(rectangle.Right - 3, rectangle.Y + 3);
					e.Graphics.DrawLines(pen2, new Point[3] { point, point2, point3 });
				}
			}
			finally
			{
				((IDisposable)pen2).Dispose();
			}
		}
		e.Graphics.SmoothingMode = SmoothingMode.Default;
		int num4 = num2 + num + 4;
		Rectangle bounds = new Rectangle(num4, 0, Math.Max(0, checkBox.Width - num4 + 3), checkBox.Height);
		Color foreColor = ((!checkBox.Enabled) ? DarkDisabledFore : (HasCustomTextColor(checkBox) ? checkBox.ForeColor : DarkControlFore));
		TextRenderer.DrawText(e.Graphics, checkBox.Text, checkBox.Font, bounds, foreColor, TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
		if (checkBox.Focused)
		{
			ControlPaint.DrawFocusRectangle(rectangle: new Rectangle(num4 - 1, 1, Math.Max(0, checkBox.Width - num4), checkBox.Height - 2), graphics: e.Graphics);
		}
	}

	private static void smethod_119()
	{
		lock (object_0)
		{
			if (hashSet_20.Count > 0)
			{
				return;
			}
			string[] array = new string[68]
			{
				Class16.smethod_0(1648901588),
				Class16.smethod_0(1648901620),
				Class16.smethod_0(1648900614),
				Class16.smethod_0(1648900624),
				Class16.smethod_0(1648900652),
				Class16.smethod_0(1648900669),
				Class16.smethod_0(1648900672),
				Class16.smethod_0(1648900700),
				Class16.smethod_0(1648900707),
				Class16.smethod_0(1648900721),
				Class16.smethod_0(1648900745),
				Class16.smethod_0(1648900781),
				Class16.smethod_0(1648900812),
				Class16.smethod_0(1648900816),
				Class16.smethod_0(1648900837),
				Class16.smethod_0(1648900860),
				Class16.smethod_0(1648900879),
				Class16.smethod_0(1648900888),
				Class16.smethod_0(1648900906),
				Class16.smethod_0(1648900940),
				Class16.smethod_0(1648900961),
				Class16.smethod_0(1648900989),
				Class16.smethod_0(1648901030),
				Class16.smethod_0(1648901061),
				Class16.smethod_0(1648901092),
				Class16.smethod_0(1648900106),
				Class16.smethod_0(1648900136),
				Class16.smethod_0(1648900183),
				Class16.smethod_0(1648900193),
				Class16.smethod_0(1648900224),
				Class16.smethod_0(1648900257),
				Class16.smethod_0(1648900300),
				Class16.smethod_0(1648900329),
				Class16.smethod_0(1648900354),
				Class16.smethod_0(1648900388),
				Class16.smethod_0(1648900409),
				Class16.smethod_0(1648900445),
				Class16.smethod_0(1648900465),
				Class16.smethod_0(1648900502),
				Class16.smethod_0(1648900543),
				Class16.smethod_0(1648900581),
				Class16.smethod_0(1648895496),
				Class16.smethod_0(1648895512),
				Class16.smethod_0(1648895542),
				Class16.smethod_0(1648895561),
				Class16.smethod_0(1648895586),
				Class16.smethod_0(1648895620),
				Class16.smethod_0(1648895654),
				Class16.smethod_0(1648895672),
				Class16.smethod_0(1648895702),
				Class16.smethod_0(1648895726),
				Class16.smethod_0(1648895739),
				Class16.smethod_0(1648895767),
				Class16.smethod_0(1648895790),
				Class16.smethod_0(1648895813),
				Class16.smethod_0(1648895826),
				Class16.smethod_0(1648895850),
				Class16.smethod_0(1648895878),
				Class16.smethod_0(1648895903),
				Class16.smethod_0(1648895924),
				Class16.smethod_0(1648895938),
				Class16.smethod_0(1648895961),
				Class16.smethod_0(1648895984),
				Class16.smethod_0(1648894986),
				Class16.smethod_0(1648895010),
				Class16.smethod_0(1648895039),
				Class16.smethod_0(1648895057),
				Class16.smethod_0(1648895083)
			};
			string[] array2 = array;
			foreach (string name in array2)
			{
				if (Resources.ResourceManager.GetObject(name) is Image image_)
				{
					smethod_121(image_);
				}
			}
			string text = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1648895110));
			if (!Directory.Exists(text))
			{
				return;
			}
			smethod_120(System.IO.Path.Combine(text, Class16.smethod_0(1648895125)));
			smethod_120(System.IO.Path.Combine(text, Class16.smethod_0(1648895140)));
			string text2 = System.IO.Path.Combine(text, Class16.smethod_0(1648895157));
			if (!Directory.Exists(text2))
			{
				return;
			}
			smethod_120(System.IO.Path.Combine(text2, Class16.smethod_0(1648895168)));
			try
			{
				string[] files = Directory.GetFiles(text2, Class16.smethod_0(1648895194));
				foreach (string string_ in files)
				{
					smethod_120(string_);
				}
			}
			catch
			{
			}
		}
	}

	private static void smethod_120(string string_1)
	{
		if (!File.Exists(string_1))
		{
			return;
		}
		try
		{
			using Image image_ = Image.FromFile(string_1);
			smethod_121(image_);
		}
		catch
		{
		}
	}

	private static void smethod_121(Image image_0)
	{
		long item = smethod_122(image_0);
		hashSet_20.Add(item);
	}

	private static long smethod_122(Image image_0)
	{
		if (image_0 == null)
		{
			return 0L;
		}
		try
		{
			Bitmap bitmap = new Bitmap(image_0);
			try
			{
				Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
				ulong num = 14695981039346656037uL;
				num = (ulong)((-3750763034362895579L ^ bitmap.Width) * 1099511628211L);
				num = (num ^ (ulong)bitmap.Height) * 1099511628211L;
				int num2 = Math.Abs(bitmapData.Stride) * bitmap.Height;
				byte[] array = new byte[num2];
				Marshal.Copy(bitmapData.Scan0, array, 0, num2);
				bitmap.UnlockBits(bitmapData);
				int num3 = 1;
				if (num2 > 4096)
				{
					num3 = 4;
				}
				for (int i = 0; i < num2; i += num3)
				{
					num = (num ^ array[i]) * 1099511628211L;
				}
				return (long)num;
			}
			finally
			{
				((IDisposable)bitmap).Dispose();
			}
		}
		catch
		{
			return 0L;
		}
	}

	public static Image GetInvertedImage(Image original)
	{
		if (original == null)
		{
			return null;
		}
		long num = smethod_122(original);
		if (!hashSet_20.Contains(num))
		{
			return original;
		}
		lock (dictionary_9)
		{
			if (dictionary_9.TryGetValue(num, out var value))
			{
				return value;
			}
			Image image = smethod_123(original);
			dictionary_9[num] = image;
			return image;
		}
	}

	private static Image smethod_123(Image image_0)
	{
		Bitmap bitmap = new Bitmap(image_0);
		Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
		BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
		int num = Math.Abs(bitmapData.Stride) * bitmap.Height;
		byte[] array = new byte[num];
		Marshal.Copy(bitmapData.Scan0, array, 0, num);
		for (int i = 0; i < num; i += 4)
		{
			array[i] = (byte)(255 - array[i]);
			array[i + 1] = (byte)(255 - array[i + 1]);
			array[i + 2] = (byte)(255 - array[i + 2]);
		}
		Marshal.Copy(array, 0, bitmapData.Scan0, num);
		bitmap.UnlockBits(bitmapData);
		return bitmap;
	}
}
