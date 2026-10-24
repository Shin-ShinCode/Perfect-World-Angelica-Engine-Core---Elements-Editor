using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.FastImageSelector;

public class FastImageSelectorWindow : Form
{
	private sealed class Class138
	{
		public FastImageSelectorWindow fastImageSelectorWindow_0;

		public int int_0;

		public EventHandler eventHandler_0;

		public EventHandler eventHandler_1;

		internal void method_0(object sender, EventArgs e)
		{
			fastImageSelectorWindow_0.method_9((int)((PictureBox)sender).Tag);
		}

		internal void method_1(object sender, EventArgs e)
		{
			fastImageSelectorWindow_0.method_7((PictureBox)sender);
		}

		internal int method_2(int int_1)
		{
			return int_1 * fastImageSelectorWindow_0.imageSelectorConfig_0.ImageSize.Height + int_0 * int_1;
		}
	}

	private readonly ImageSelectorConfig imageSelectorConfig_0;

	private readonly int? nullable_0;

	public bool IsInitialized;

	private List<Control> list_0 = new List<Control>();

	private readonly Dictionary<PictureBox, bool> dictionary_0 = new Dictionary<PictureBox, bool>();

	private readonly Debounce debounce_0;

	private readonly PictureBox pictureBox_0;

	private bool bool_0;

	private int int_0 = -1;

	public IContainer components;

	private Button button_0;

	private VScrollBar vscrollBar_0;

	private Panel panel_0;

	private Panel panel_1;

	private Panel panel_2;

	private int int_1;

	private int int_2 = -1;

	public int HImageCount => panel_0.Width / imageSelectorConfig_0.ImageSize.Width;

	public int VImageCount => panel_0.Height / imageSelectorConfig_0.ImageSize.Height;

	public int LayoutImageCount => HImageCount * VImageCount;

	public int CurrentLineIndex => vscrollBar_0.Value;

	public int FirstImageIndex
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
	}

	public bool IsLayoutOutdated => list_0.Count != LayoutImageCount;

	public int ResultImageIndex
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
	}

	public FastImageSelectorWindow(ImageSelectorConfig config, int? currentImageIndex)
	{
		imageSelectorConfig_0 = config;
		nullable_0 = currentImageIndex;
		method_15();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		method_2();
		if (imageSelectorConfig_0.HImageCount.HasValue)
		{
			base.Width = (imageSelectorConfig_0.HImageCount.HasValue ? (imageSelectorConfig_0.HImageCount.Value * imageSelectorConfig_0.ImageSize.Width + base.Width - panel_0.Width) : base.Width);
		}
		if (imageSelectorConfig_0.VImageCount.HasValue)
		{
			base.Height = (imageSelectorConfig_0.VImageCount.HasValue ? (imageSelectorConfig_0.VImageCount.Value * imageSelectorConfig_0.ImageSize.Height + base.Height - panel_0.Height) : base.Height);
		}
		pictureBox_0 = method_6();
		method_5();
		if (currentImageIndex.HasValue)
		{
			method_3(currentImageIndex.Value);
		}
		else
		{
			method_10();
		}
		debounce_0 = new Debounce(method_16, 500);
		IsInitialized = true;
	}

	private void method_0(int int_3)
	{
		int_1 = int_3;
	}

	private void method_1(int int_3)
	{
		int_2 = int_3;
	}

	private void method_2()
	{
		panel_1.MouseWheel += panel_1_MouseWheel;
	}

	private void panel_1_MouseWheel(object sender, MouseEventArgs e)
	{
		int value = vscrollBar_0.Value;
		int num = ((e.Delta > 0) ? (-VImageCount / 2) : (VImageCount / 2));
		int num2 = value + num;
		if (num2 > vscrollBar_0.Maximum)
		{
			num2 = vscrollBar_0.Maximum;
		}
		if (num2 < vscrollBar_0.Minimum)
		{
			num2 = vscrollBar_0.Minimum;
		}
		vscrollBar_0.Value = num2;
	}

	private void method_3(int int_3)
	{
		int num = int_3 / HImageCount;
		if (num != CurrentLineIndex)
		{
			method_4(num);
		}
		else
		{
			method_10();
		}
	}

	private void method_4(int int_3)
	{
		vscrollBar_0.Value = int_3;
	}

	private void vscrollBar_0_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			method_10();
			Application.DoEvents();
		}
	}

	private void panel_0_Resize(object sender, EventArgs e)
	{
		if (IsInitialized)
		{
			debounce_0.Launch();
		}
	}

	private bool method_5()
	{
		Class138 @class = new Class138();
		@class.fastImageSelectorWindow_0 = this;
		if (base.WindowState == FormWindowState.Minimized)
		{
			return false;
		}
		if (LayoutImageCount == int_0)
		{
			return false;
		}
		pictureBox_0.Visible = false;
		method_8();
		int num = panel_0.Width - HImageCount * imageSelectorConfig_0.ImageSize.Width;
		int num2 = panel_0.Height - VImageCount * imageSelectorConfig_0.ImageSize.Height;
		int num3 = (int)Math.Round((double)num / (double)HImageCount);
		@class.int_0 = (int)Math.Round((double)num2 / (double)VImageCount);
		List<Control> list = new List<Control>();
		for (int i = 0; i < VImageCount; i++)
		{
			Label item = new Label
			{
				Left = 0,
				Top = @class.method_2(i),
				Size = imageSelectorConfig_0.ImageSize,
				TextAlign = ContentAlignment.MiddleCenter,
				BorderStyle = BorderStyle.FixedSingle,
				Visible = false
			};
			list.Add(item);
		}
		List<Control> list2 = new List<Control>(LayoutImageCount);
		for (int j = 0; j < VImageCount; j++)
		{
			int top = @class.method_2(j);
			for (int k = 0; k < HImageCount; k++)
			{
				int left = k * imageSelectorConfig_0.ImageSize.Width + num3 * k;
				PictureBox pictureBox = new PictureBox
				{
					Size = imageSelectorConfig_0.ImageSize,
					Left = left,
					Top = top,
					Visible = false,
					Cursor = Cursors.Hand
				};
				pictureBox.Click += @class.method_0;
				pictureBox.MouseEnter += @class.method_1;
				list2.Add(pictureBox);
			}
		}
		panel_2.Controls.AddRange(list.ToArray());
		list_0 = list2;
		panel_0.Controls.AddRange(list2.Append(pictureBox_0).ToArray());
		int_0 = LayoutImageCount;
		bool_0 = true;
		vscrollBar_0.LargeChange = VImageCount;
		vscrollBar_0.Maximum = imageSelectorConfig_0.TotalImageCount / HImageCount;
		bool_0 = false;
		return true;
	}

	private PictureBox method_6()
	{
		Size size = new Size(imageSelectorConfig_0.ImageSize.Width, 2);
		return new PictureBox
		{
			Image = CustomDrawer.CreateRectangle(size, Color.White),
			Size = size,
			Cursor = Cursors.Hand,
			Visible = false
		};
	}

	private void method_7(PictureBox pictureBox_1)
	{
		pictureBox_0.Left = pictureBox_1.Left;
		pictureBox_0.Top = pictureBox_1.Top + pictureBox_1.Height - pictureBox_0.Height;
		pictureBox_0.Visible = true;
		pictureBox_0.BringToFront();
	}

	private void method_8()
	{
		Control[] array = new Control[panel_0.Controls.Count];
		panel_0.Controls.CopyTo(array, 0);
		Control[] array2 = array;
		foreach (Control control in array2)
		{
			if (control != pictureBox_0)
			{
				if (control is PictureBox pictureBox_)
				{
					method_14(pictureBox_);
				}
				control.Dispose();
			}
		}
		panel_0.Controls.Clear();
		Control[] array3 = new Control[panel_2.Controls.Count];
		panel_2.Controls.CopyTo(array3, 0);
		Control[] array4 = array3;
		foreach (Control control2 in array4)
		{
			control2.Dispose();
		}
		panel_2.Controls.Clear();
		list_0.Clear();
		dictionary_0.Clear();
	}

	private void method_9(int int_3)
	{
		method_1(int_3);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	private void method_10()
	{
		if (IsLayoutOutdated)
		{
			debounce_0.CancelSchedule();
			method_5();
			method_3(FirstImageIndex);
			return;
		}
		for (int i = 0; i < VImageCount; i++)
		{
			int int_ = CurrentLineIndex + i;
			method_11(i, int_);
		}
		method_0(CurrentLineIndex * HImageCount);
		for (int j = 0; j < LayoutImageCount; j++)
		{
			int num = FirstImageIndex + j;
			method_12(j, num, num < imageSelectorConfig_0.TotalImageCount);
		}
	}

	private void method_11(int int_3, int int_4)
	{
		Label label = (Label)panel_2.Controls[int_3];
		label.Text = int_4.ToString();
		label.Visible = true;
	}

	private void method_12(int int_3, int int_4, bool bool_1)
	{
		PictureBox pictureBox = (PictureBox)list_0[int_3];
		method_14(pictureBox);
		if (bool_1)
		{
			(Image, bool) tuple = method_13(int_4);
			Image item = tuple.Item1;
			bool item2 = tuple.Item2;
			pictureBox.Tag = int_4;
			pictureBox.Image = item;
			dictionary_0[pictureBox] = item2;
			pictureBox.Visible = true;
		}
		else
		{
			pictureBox.Tag = null;
			pictureBox.Image = null;
			pictureBox.Visible = false;
		}
	}

	private (Image, bool) method_13(int int_3)
	{
		Image image = imageSelectorConfig_0.ImageGetter(int_3);
		if (int_3 == nullable_0)
		{
			return (CustomDrawer.DrawCheck(imageSelectorConfig_0.ImageSize, image), true);
		}
		return (image, false);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		base.DialogResult = DialogResult.Cancel;
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			debounce_0?.Dispose();
			foreach (Control item in list_0)
			{
				if (item is PictureBox pictureBox_)
				{
					method_14(pictureBox_);
				}
			}
			list_0.Clear();
			dictionary_0.Clear();
			if (pictureBox_0?.Image != null)
			{
				try
				{
					Image image = pictureBox_0.Image;
					pictureBox_0.Image = null;
					image.Dispose();
				}
				catch
				{
				}
			}
		}
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_14(PictureBox pictureBox_1)
	{
		if (pictureBox_1 == null)
		{
			return;
		}
		if (dictionary_0.TryGetValue(pictureBox_1, out var value) && value && pictureBox_1.Image != null)
		{
			try
			{
				pictureBox_1.Image.Dispose();
			}
			catch
			{
			}
		}
		dictionary_0[pictureBox_1] = false;
	}

	private void method_15()
	{
		new ComponentResourceManager(typeof(FastImageSelectorWindow));
		panel_1 = new Panel();
		panel_2 = new Panel();
		button_0 = new Button();
		panel_0 = new Panel();
		vscrollBar_0 = new VScrollBar();
		panel_1.SuspendLayout();
		SuspendLayout();
		panel_1.Controls.Add(panel_2);
		panel_1.Controls.Add(button_0);
		panel_1.Controls.Add(panel_0);
		panel_1.Controls.Add(vscrollBar_0);
		panel_1.Dock = DockStyle.Fill;
		panel_1.Location = new Point(0, 0);
		panel_1.Name = Class16.smethod_0(1649071815);
		panel_1.Size = new Size(845, 494);
		panel_1.TabIndex = 0;
		panel_2.BackColor = Color.FromArgb(64, 64, 64);
		panel_2.Dock = DockStyle.Left;
		panel_2.ForeColor = Color.White;
		panel_2.Location = new Point(0, 0);
		panel_2.Name = Class16.smethod_0(1649071839);
		panel_2.Size = new Size(34, 494);
		panel_2.TabIndex = 3;
		button_0.DialogResult = DialogResult.Cancel;
		button_0.Location = new Point(-100, -100);
		button_0.Name = Class16.smethod_0(1649071860);
		button_0.Size = new Size(76, 23);
		button_0.TabIndex = 0;
		button_0.Text = Class16.smethod_0(1648941799);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		panel_0.BackColor = Color.FromArgb(32, 32, 32);
		panel_0.Dock = DockStyle.Fill;
		panel_0.Location = new Point(0, 0);
		panel_0.Name = Class16.smethod_0(1649071879);
		panel_0.Size = new Size(828, 494);
		panel_0.TabIndex = 2;
		panel_0.Resize += panel_0_Resize;
		vscrollBar_0.Dock = DockStyle.Right;
		vscrollBar_0.LargeChange = 5;
		vscrollBar_0.Location = new Point(828, 0);
		vscrollBar_0.Maximum = 60000;
		vscrollBar_0.Name = Class16.smethod_0(1649071900);
		vscrollBar_0.Size = new Size(17, 494);
		vscrollBar_0.TabIndex = 1;
		vscrollBar_0.ValueChanged += vscrollBar_0_ValueChanged;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.CancelButton = button_0;
		base.ClientSize = new Size(845, 494);
		base.Controls.Add(panel_1);
		base.Icon = Resources.edit;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1649071914);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649071944);
		panel_1.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void method_16()
	{
		if (method_5())
		{
			method_3(FirstImageIndex);
		}
	}
}
