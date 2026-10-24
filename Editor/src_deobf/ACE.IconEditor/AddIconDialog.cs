using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.IconEditor;

public sealed class AddIconDialog : Form
{
	private sealed class Class143
	{
		private readonly int int_0;

		private readonly string string_0;

		public Class143(int int_1, string string_1)
		{
			int_0 = int_1;
			string_0 = string_1;
		}

		public int method_0()
		{
			return int_0;
		}

		public string method_1()
		{
			return string_0;
		}

		public override string ToString()
		{
			return method_1();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct60
	{
		public HashSet<int> hashSet_0;

		public AddIconDialog addIconDialog_0;
	}

	[Serializable]
	private sealed class Class144
	{
		public static readonly Class144 class144_0 = new Class144();

		public static Func<IconEntry, int> func_0;

		internal int method_0(IconEntry iconEntry_0)
		{
			return iconEntry_0.StartIndex + iconEntry_0.FrameCount;
		}
	}

	private readonly IconSheet iconSheet_0;

	private Bitmap bitmap_0;

	private int int_0 = 1;

	private readonly TextBox textBox_0;

	private readonly PictureBox pictureBox_0;

	private readonly Label label_0;

	private readonly ComboBox comboBox_0;

	private readonly TextBox textBox_1;

	private readonly TextBox textBox_2;

	private readonly Button button_0;

	private IconEntry iconEntry_0;

	private Bitmap bitmap_1;

	private int int_1;

	public IconEntry NewEntry
	{
		[CompilerGenerated]
		get
		{
			return iconEntry_0;
		}
	}

	public Bitmap ImageToAdd
	{
		[CompilerGenerated]
		get
		{
			return bitmap_1;
		}
	}

	public int SourceFrameSize
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
	}

	public AddIconDialog(IconSheet sheet)
	{
		iconSheet_0 = sheet ?? throw new ArgumentNullException(Class16.smethod_0(1649056337));
		Text = Class16.smethod_0(1649056356);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.StartPosition = FormStartPosition.CenterParent;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		base.ClientSize = new Size(560, 430);
		TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
		{
			Dock = DockStyle.Fill,
			ColumnCount = 3,
			RowCount = 8,
			Padding = new Padding(12)
		};
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
		tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 140f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		base.Controls.Add(tableLayoutPanel);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649056363),
			Anchor = AnchorStyles.Left,
			AutoSize = true
		}, 0, 0);
		textBox_0 = new TextBox
		{
			ReadOnly = true,
			Dock = DockStyle.Fill
		};
		tableLayoutPanel.Controls.Add(textBox_0, 1, 0);
		Button button = new Button
		{
			Text = Class16.smethod_0(1648978102),
			AutoSize = true,
			Anchor = AnchorStyles.Left
		};
		button.Click += method_5;
		tableLayoutPanel.Controls.Add(button, 2, 0);
		label_0 = new Label
		{
			Text = Class16.smethod_0(1649056383),
			AutoSize = true,
			ForeColor = SystemColors.GrayText
		};
		tableLayoutPanel.Controls.Add(label_0, 0, 1);
		tableLayoutPanel.SetColumnSpan(label_0, 3);
		Panel panel = new Panel
		{
			BorderStyle = BorderStyle.FixedSingle,
			Dock = DockStyle.Fill,
			BackColor = Color.FromArgb(26, 26, 26)
		};
		tableLayoutPanel.Controls.Add(panel, 0, 2);
		tableLayoutPanel.SetColumnSpan(panel, 3);
		pictureBox_0 = new PictureBox
		{
			Dock = DockStyle.Fill,
			SizeMode = PictureBoxSizeMode.CenterImage,
			BackColor = Color.Transparent
		};
		panel.Controls.Add(pictureBox_0);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649056407),
			Anchor = AnchorStyles.Left,
			AutoSize = true
		}, 0, 3);
		comboBox_0 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Dock = DockStyle.Left,
			Width = 260
		};
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		tableLayoutPanel.Controls.Add(comboBox_0, 1, 3);
		tableLayoutPanel.SetColumnSpan(comboBox_0, 2);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1649056431),
			Anchor = AnchorStyles.Left,
			AutoSize = true
		}, 0, 4);
		textBox_1 = new TextBox
		{
			Dock = DockStyle.Left,
			Width = 120
		};
		tableLayoutPanel.Controls.Add(textBox_1, 1, 4);
		tableLayoutPanel.SetColumnSpan(textBox_1, 2);
		tableLayoutPanel.Controls.Add(new Label
		{
			Text = Class16.smethod_0(1648936731),
			Anchor = AnchorStyles.Left,
			AutoSize = true
		}, 0, 5);
		textBox_2 = new TextBox
		{
			Dock = DockStyle.Fill
		};
		tableLayoutPanel.Controls.Add(textBox_2, 1, 5);
		tableLayoutPanel.SetColumnSpan(textBox_2, 2);
		FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
		{
			FlowDirection = FlowDirection.RightToLeft,
			Dock = DockStyle.Fill
		};
		tableLayoutPanel.Controls.Add(flowLayoutPanel, 0, 7);
		tableLayoutPanel.SetColumnSpan(flowLayoutPanel, 3);
		button_0 = new Button
		{
			Text = Class16.smethod_0(1648931361),
			AutoSize = true
		};
		button_0.Click += button_0_Click;
		flowLayoutPanel.Controls.Add(button_0);
		Button button2 = new Button
		{
			Text = Class16.smethod_0(1648941799),
			AutoSize = true
		};
		button2.Click += method_9;
		flowLayoutPanel.Controls.Add(button2);
		method_3();
		method_4();
		TextStorage.TEXTS.SetFormLanguage(this);
	}

	private void method_0(IconEntry iconEntry_1)
	{
		iconEntry_0 = iconEntry_1;
	}

	private void method_1(Bitmap bitmap_2)
	{
		bitmap_1 = bitmap_2;
	}

	private void method_2(int int_2)
	{
		int_1 = int_2;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			bitmap_0?.Dispose();
			if (pictureBox_0.Image != null)
			{
				pictureBox_0.Image.Dispose();
				pictureBox_0.Image = null;
			}
			ImageToAdd?.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_3()
	{
		Struct60 struct60_ = default(Struct60);
		struct60_.addIconDialog_0 = this;
		struct60_.hashSet_0 = new HashSet<int>();
		method_10(iconSheet_0.IconSize, string.Format(TextStorage.Msg(Class16.smethod_0(1649056441), Class16.smethod_0(1649056473)), iconSheet_0.IconSize), ref struct60_);
		method_10(16, Class16.smethod_0(1649056504), ref struct60_);
		method_10(26, Class16.smethod_0(1649056524), ref struct60_);
		method_10(32, Class16.smethod_0(1649056528), ref struct60_);
		comboBox_0.Items.Add(new Class143(0, TextStorage.Msg(Class16.smethod_0(1649056548), Class16.smethod_0(1649056586))));
		comboBox_0.SelectedIndex = 0;
	}

	private void method_4()
	{
		int num = 0;
		if (iconSheet_0.Entries.Count > 0)
		{
			IconEntry iconEntry = iconSheet_0.Entries.OrderByDescending(Class144.class144_0.method_0).First();
			num = iconEntry.StartIndex + Math.Max(1, iconEntry.FrameCount);
		}
		textBox_1.Text = num.ToString();
	}

	private void method_5(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = Class16.smethod_0(1649056629),
			Title = Class16.smethod_0(1649056696)
		};
		if (openFileDialog.ShowDialog(this) == DialogResult.OK)
		{
			method_6(openFileDialog.FileName);
		}
	}

	private void method_6(string string_0)
	{
		try
		{
			string extension = System.IO.Path.GetExtension(string_0);
			Bitmap bitmap;
			if (extension.Equals(Class16.smethod_0(1648904847), StringComparison.OrdinalIgnoreCase))
			{
				bitmap = DdsLoader.Load(string_0);
			}
			else
			{
				using Image original = Image.FromFile(string_0);
				bitmap = new Bitmap(original);
			}
			if (bitmap == null)
			{
				MessageBox.Show(this, TextStorage.Msg(Class16.smethod_0(1649056715), Class16.smethod_0(1649056753)), TextStorage.Msg(Class16.smethod_0(1648934865), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return;
			}
			bitmap_0?.Dispose();
			bitmap_0 = bitmap;
			if (pictureBox_0.Image != null)
			{
				pictureBox_0.Image.Dispose();
				pictureBox_0.Image = null;
			}
			pictureBox_0.Image = new Bitmap(bitmap);
			textBox_0.Text = string_0;
			if (string.IsNullOrWhiteSpace(textBox_2.Text))
			{
				textBox_2.Text = System.IO.Path.GetFileNameWithoutExtension(string_0);
			}
			method_7();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649055765));
			MessageBox.Show(this, ex.Message, TextStorage.Msg(Class16.smethod_0(1648934865), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_7()
	{
		if (bitmap_0 == null)
		{
			label_0.Text = TextStorage.Msg(Class16.smethod_0(1649055787));
			int_0 = 1;
			return;
		}
		int num = method_8();
		if (num <= 0)
		{
			int_0 = 1;
			label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649055821), Class16.smethod_0(1649055841)), bitmap_0.Width, bitmap_0.Height);
			return;
		}
		int num2 = bitmap_0.Width / num;
		int num3 = bitmap_0.Height / num;
		int num4 = num2 * num3;
		if (num4 <= 0)
		{
			int_0 = 1;
			label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649055867), Class16.smethod_0(1649055907)), bitmap_0.Width, bitmap_0.Height, iconSheet_0.IconSize, iconSheet_0.IconSize);
		}
		else
		{
			int_0 = num4;
			label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649055974), Class16.smethod_0(1649056007)), bitmap_0.Width, bitmap_0.Height, num2, num3, int_0);
		}
	}

	private int method_8()
	{
		if (comboBox_0.SelectedItem is Class143 @class)
		{
			return @class.method_0();
		}
		return iconSheet_0.IconSize;
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (bitmap_0 == null)
		{
			MessageBox.Show(this, TextStorage.Msg(Class16.smethod_0(1649056042), Class16.smethod_0(1649056086)), TextStorage.Msg(Class16.smethod_0(1649056107), Class16.smethod_0(1649056149)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		List<int> list;
		IconEntry obj;
		object obj3;
		if (int.TryParse(textBox_1.Text, out var result) && result >= 0)
		{
			int num = Math.Max(1, int_0);
			if (iconSheet_0.IsIconListFormat && num != 1)
			{
				MessageBox.Show(this, TextStorage.Msg(Class16.smethod_0(1649056230), Class16.smethod_0(1649051146)), TextStorage.Msg(Class16.smethod_0(1649056107), Class16.smethod_0(1649056149)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (result + num > iconSheet_0.TotalFrames)
			{
				MessageBox.Show(this, string.Format(TextStorage.Msg(Class16.smethod_0(1649051212), Class16.smethod_0(1649051255)), num, result, iconSheet_0.TotalFrames - 1), TextStorage.Msg(Class16.smethod_0(1649056107), Class16.smethod_0(1649056149)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			int num2 = result + num - 1;
			foreach (IconEntry entry in iconSheet_0.Entries)
			{
				int num3 = entry.StartIndex + Math.Max(1, entry.FrameCount) - 1;
				if (num2 >= entry.StartIndex && result <= num3)
				{
					MessageBox.Show(this, string.Format(TextStorage.Msg(Class16.smethod_0(1649051334), Class16.smethod_0(1649051381)), entry.Name, entry.StartIndex, num3), TextStorage.Msg(Class16.smethod_0(1649056107), Class16.smethod_0(1649056149)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			list = new List<int>();
			for (int i = 0; i < num; i++)
			{
				list.Add(10);
			}
			obj = new IconEntry
			{
				StartIndex = result,
				FrameCount = num
			};
			string obj2 = textBox_2.Text;
			if (obj2 == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = obj2.Trim();
				if (obj3 != null)
				{
					goto IL_024f;
				}
			}
			obj3 = string.Empty;
			goto IL_024f;
		}
		MessageBox.Show(this, TextStorage.Msg(Class16.smethod_0(1649056166), Class16.smethod_0(1649056195)), TextStorage.Msg(Class16.smethod_0(1649056107), Class16.smethod_0(1649056149)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		return;
		IL_024f:
		obj.Name = (string)obj3;
		obj.Durations = list;
		method_0(obj);
		ImageToAdd?.Dispose();
		method_1(new Bitmap(bitmap_0));
		method_2(method_8());
		base.DialogResult = DialogResult.OK;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		method_7();
	}

	private void method_9(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
	}

	private void method_10(int int_2, string string_0, ref Struct60 struct60_0)
	{
		if (!struct60_0.hashSet_0.Contains(int_2))
		{
			comboBox_0.Items.Add(new Class143(int_2, string_0));
			struct60_0.hashSet_0.Add(int_2);
		}
	}
}
