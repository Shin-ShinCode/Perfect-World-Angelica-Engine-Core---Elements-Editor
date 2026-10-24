using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class ListBoxWindow : Form
{
	public static CommonStorage CStorage;

	private NumericUpDown numericUpDown_0;

	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private int int_0;

	private uint uint_0;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private ListView listView_0;

	public Container components;

	public ListBoxWindow(Size MaxWSize, string[] captions, int selected_index, [MarshalAs(UnmanagedType.U1)] bool IsMask, decimal mask, [MarshalAs(UnmanagedType.U1)] bool bMultiplieSelection)
	{
		try
		{
			Init(MaxWSize, captions, selected_index, IsMask, mask, bMultiplieSelection);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public static DialogResult ShowSelectMaskDialog(Form owner, Size MaxWSize, string[] captions, decimal mask)
	{
		ListBoxWindow listBoxWindow = new ListBoxWindow(MaxWSize, captions, 0, IsMask: true, mask, bMultiplieSelection: false);
		try
		{
			return listBoxWindow.ShowDialog(owner);
		}
		finally
		{
			((IDisposable)listBoxWindow).Dispose();
		}
	}

	public static DialogResult ShowSelectListDialog(Form owner, Size MaxWSize, string[] captions, int selected_index, [MarshalAs(UnmanagedType.U1)] bool bMultiplieSelection)
	{
		ListBoxWindow listBoxWindow = new ListBoxWindow(MaxWSize, captions, selected_index, IsMask: false, default(decimal), bMultiplieSelection);
		try
		{
			return listBoxWindow.ShowDialog(owner);
		}
		finally
		{
			((IDisposable)listBoxWindow).Dispose();
		}
	}

	public void Init(Size MaxWSize, string[] captions, int selected_index, [MarshalAs(UnmanagedType.U1)] bool IsMask, decimal mask, [MarshalAs(UnmanagedType.U1)] bool bMultiplieSelection)
	{
		bool_2 = true;
		bool_3 = false;
		method_2();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		Size clientSize = new Size(203, 73);
		base.ClientSize = clientSize;
		bool_0 = IsMask;
		bool_1 = bMultiplieSelection;
		int_0 = -1;
		uint_0 = 0u;
		MaxWSize.Width -= 30;
		MaxWSize.Height -= 50;
		int num = 0;
		if (captions == null)
		{
			GC.KeepAlive(this);
			return;
		}
		int num2 = captions.Length;
		ListViewItem[] array = new ListViewItem[num2];
		int num3 = 0;
		if (0 < num2)
		{
			do
			{
				array[num3] = new ListViewItem(captions[num3]);
				int num4 = TextRenderer.MeasureText(captions[num3], listView_0.Font).Width;
				num = ((num4 > num) ? num4 : num);
				num3++;
			}
			while (num3 < (nint)captions.LongLength);
		}
		listView_0.Items.AddRange(array);
		int num5 = listView_0.GetItemRect(0).Height + 1;
		int num6 = -50 - SystemInformation.CaptionHeight;
		int num7 = (MaxWSize.Height + num6) / num5;
		num = ((num < 180) ? 180 : num);
		if ((IsMask || bMultiplieSelection) && (nint)captions.LongLength >= num7)
		{
			num = num * 2 + 40;
		}
		num2 = captions.Length;
		if (num2 >= num7 && !IsMask && !bMultiplieSelection)
		{
			num = (int)Math.Ceiling((double)num2 / (double)num7) * num + 15;
			int num8 = ((num >= MaxWSize.Width) ? MaxWSize.Width : num);
			base.Width = num8;
			base.Height = MaxWSize.Height - 50;
			listView_0.Dock = DockStyle.Fill;
		}
		else
		{
			base.Width = num + listView_0.Left + 20;
			int num9 = (int)((listView_0.Top + SystemInformation.HorizontalScrollBarHeight + (nint)captions.LongLength * num5 + 25 >= MaxWSize.Height) ? MaxWSize.Height : (listView_0.Top + SystemInformation.HorizontalScrollBarHeight + (nint)captions.LongLength * num5 + 25));
			base.Height = num9;
			if (IsMask || bMultiplieSelection)
			{
				string text = TextStorage.TEXTS.GetText(Class16.smethod_0(1648974790));
				Text = text;
				base.Width += 10;
				if (base.Width < 262)
				{
					base.Width = 262;
				}
				base.Height += 80;
				listView_0.CheckBoxes = true;
				listView_0.Cursor = Cursors.Default;
				numericUpDown_0.Visible = true;
				button_0.Visible = true;
				button_1.Visible = true;
				button_2.Visible = true;
				if (IsMask)
				{
					ulong num10 = (ulong)array.LongLength;
					ulong num11;
					if (num10 == 0L)
					{
						num11 = 1uL;
					}
					else
					{
						ulong num12 = 2uL;
						int num13 = 1;
						if (1L < num10)
						{
							do
							{
								num12 *= 2L;
								num13++;
							}
							while ((ulong)num13 < num10);
						}
						num11 = num12;
					}
					decimal maximum = num11 + ulong.MaxValue;
					numericUpDown_0.Maximum = maximum;
					if (mask < default(decimal))
					{
						mask = default(decimal);
					}
					decimal maximum2 = numericUpDown_0.Maximum;
					if (mask > maximum2)
					{
						mask = numericUpDown_0.Maximum;
					}
					numericUpDown_0.Value = mask;
					method_3();
				}
				else
				{
					numericUpDown_0.Enabled = false;
					if (CommonStorage.iarr1 != null && (nint)CommonStorage.iarr1.LongLength > 0)
					{
						int[] iarr = CommonStorage.iarr1;
						int num14 = 0;
						if (0 < (nint)iarr.LongLength)
						{
							do
							{
								int num15 = iarr[num14];
								if (num15 > -1 && num15 < listView_0.Items.Count)
								{
									listView_0.Items[num15].Checked = true;
								}
								num14++;
							}
							while (num14 < (nint)iarr.LongLength);
						}
						CommonStorage.iarr1 = null;
					}
				}
				goto IL_045f;
			}
			listView_0.Dock = DockStyle.Fill;
		}
		string text2 = TextStorage.TEXTS.GetText(Class16.smethod_0(1648974813));
		Text = text2;
		goto IL_045f;
		IL_045f:
		if (selected_index < 0 || selected_index >= listView_0.Items.Count)
		{
			selected_index = 0;
		}
		byte b = (((nint)captions.LongLength < 40) ? ((byte)1) : ((byte)0));
		listView_0.HotTracking = b != 0;
		byte b2 = (((nint)captions.LongLength < 40) ? ((byte)1) : ((byte)0));
		listView_0.HoverSelection = b2 != 0;
		listView_0.Items[selected_index].Selected = true;
		listView_0.Items[selected_index].EnsureVisible();
		listView_0.Items[selected_index].Focused = true;
		GC.KeepAlive(this);
	}

	private void method_0(object sender, EventArgs e)
	{
		Close();
	}

	private void method_1()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		new ComponentResourceManager(typeof(ListBoxWindow));
		listView_0 = new ListView();
		numericUpDown_0 = new NumericUpDown();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		listView_0.Activation = ItemActivation.OneClick;
		listView_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listView_0.AutoArrange = false;
		listView_0.BackColor = SystemColors.Window;
		listView_0.BorderStyle = BorderStyle.None;
		listView_0.Cursor = Cursors.Hand;
		listView_0.Font = new Font(Class16.smethod_0(1648942905), 15.75f, FontStyle.Underline, GraphicsUnit.Point, 204);
		listView_0.ForeColor = SystemColors.WindowText;
		listView_0.FullRowSelect = true;
		listView_0.GridLines = true;
		listView_0.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		listView_0.HideSelection = false;
		listView_0.HotTracking = true;
		listView_0.HoverSelection = true;
		listView_0.LabelWrap = false;
		listView_0.Location = new Point(10, 9);
		listView_0.MultiSelect = false;
		listView_0.Name = Class16.smethod_0(1648974836);
		listView_0.ShowGroups = false;
		listView_0.Size = new Size(231, 264);
		listView_0.TabIndex = 12;
		listView_0.Tag = string.Empty;
		listView_0.UseCompatibleStateImageBehavior = false;
		listView_0.View = View.List;
		listView_0.ItemCheck += listView_0_ItemCheck;
		listView_0.ItemChecked += listView_0_ItemChecked;
		listView_0.KeyUp += listView_0_KeyUp;
		listView_0.MouseClick += listView_0_MouseClick;
		numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		numericUpDown_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		numericUpDown_0.Location = new Point(0, 279);
		numericUpDown_0.Maximum = new decimal(new int[4] { 0, 1, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648973828);
		numericUpDown_0.Size = new Size(125, 25);
		numericUpDown_0.TabIndex = 13;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.ThousandsSeparator = true;
		numericUpDown_0.Visible = false;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		numericUpDown_0.KeyPress += numericUpDown_0_KeyPress;
		numericUpDown_0.KeyUp += numericUpDown_0_KeyUp;
		button_0.BackColor = Color.Transparent;
		button_0.DialogResult = DialogResult.OK;
		button_0.Dock = DockStyle.Bottom;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.ListBoxWindow_cmdOk;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(0, 304);
		button_0.Name = Class16.smethod_0(1648973834);
		button_0.Size = new Size(250, 35);
		button_0.TabIndex = 14;
		button_0.Text = Class16.smethod_0(1648973854);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = false;
		button_0.Visible = false;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_1.ForeColor = Color.Blue;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(125, 279);
		button_1.Name = Class16.smethod_0(1648973878);
		button_1.Size = new Size(62, 25);
		button_1.TabIndex = 15;
		button_1.Text = Class16.smethod_0(1648973883);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Visible = false;
		button_1.Click += button_1_Click;
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Underline, GraphicsUnit.Point, 204);
		button_2.ForeColor = Color.Red;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(186, 279);
		button_2.Name = Class16.smethod_0(1648973901);
		button_2.Size = new Size(63, 25);
		button_2.TabIndex = 16;
		button_2.Text = Class16.smethod_0(1648973907);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Visible = false;
		button_2.Click += button_2_Click;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 17f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(250, 339);
		base.Controls.Add(button_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(listView_0);
		BackColor = SystemColors.Control;
		Font = new Font(Class16.smethod_0(1648942905), 10f);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.ListBoxWindow_Icon;
		base.Margin = new Padding(4);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648973921);
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648973949);
		base.Shown += ListBoxWindow_Shown;
		base.KeyUp += ListBoxWindow_KeyUp;
		((ISupportInitialize)numericUpDown_0).EndInit();
		ResumeLayout(performLayout: false);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_1();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void listView_0_MouseClick(object sender, MouseEventArgs e)
	{
		if (!bool_0 && !listView_0.CheckBoxes)
		{
			if (listView_0.SelectedIndices != null && listView_0.SelectedIndices.Count > 0)
			{
				base.DialogResult = DialogResult.OK;
				CommonStorage.iData = listView_0.SelectedIndices[0];
			}
			Close();
			return;
		}
		ListViewItem itemAt = listView_0.GetItemAt(e.X, e.Y);
		if (itemAt != null)
		{
			byte b = ((!itemAt.Checked) ? ((byte)1) : ((byte)0));
			itemAt.Checked = b != 0;
		}
		GC.KeepAlive(this);
	}

	private void listView_0_ItemCheck(object sender, ItemCheckEventArgs e)
	{
		if (int_0 == e.Index)
		{
			uint num = uint_0;
			if (ACE.RSGlobal.RSGlobal.GetTickCount() - num < 200)
			{
				e.NewValue = e.CurrentValue;
			}
		}
		uint_0 = ACE.RSGlobal.RSGlobal.GetTickCount();
		int_0 = e.Index;
		GC.KeepAlive(this);
	}

	private void listView_0_ItemChecked(object sender, ItemCheckedEventArgs e)
	{
		if (!bool_2 && bool_3)
		{
			method_4();
		}
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_2)
		{
			method_3();
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (bool_0)
		{
			CommonStorage.sData = numericUpDown_0.Value.ToString();
		}
		else if (bool_1)
		{
			List<int> list = new List<int>();
			int num = 0;
			if (0 < listView_0.Items.Count)
			{
				do
				{
					if (listView_0.Items[num].Checked)
					{
						list.Add(num);
					}
					num++;
				}
				while (num < listView_0.Items.Count);
			}
			CommonStorage.iarr1 = list.ToArray();
		}
		Close();
	}

	private void method_3()
	{
		if (!bool_0)
		{
			return;
		}
		ulong num = (ulong)numericUpDown_0.Value;
		bool_2 = true;
		int num2 = listView_0.Items.Count - 1;
		if (num2 >= 0)
		{
			do
			{
				ulong num3 = (ulong)num2;
				ulong num4 = num3;
				ulong num5;
				if (num4 == 0L)
				{
					num5 = 1uL;
				}
				else
				{
					ulong num6 = 2uL;
					int num7 = 1;
					if (1L < num4)
					{
						do
						{
							num6 *= 2L;
							num7++;
						}
						while ((ulong)num7 < num4);
					}
					num5 = num6;
				}
				if (num / num5 > 0L)
				{
					listView_0.Items[num2].Checked = true;
					ulong num8 = num3;
					ulong num9;
					if (num8 == 0L)
					{
						num9 = 1uL;
					}
					else
					{
						ulong num10 = 2uL;
						int num11 = 1;
						if (1L < num8)
						{
							do
							{
								num10 *= 2L;
								num11++;
							}
							while ((ulong)num11 < num8);
						}
						num9 = num10;
					}
					num %= num9;
				}
				else
				{
					listView_0.Items[num2].Checked = false;
				}
				num2--;
			}
			while (num2 >= 0);
		}
		bool_2 = false;
	}

	private void method_4()
	{
		if (!bool_0)
		{
			return;
		}
		ulong num = 0uL;
		int num2 = 0;
		if (0 < listView_0.Items.Count)
		{
			do
			{
				if (listView_0.Items[num2].Checked)
				{
					ulong num3 = (ulong)num2;
					ulong num4;
					if (num3 == 0L)
					{
						num4 = 1uL;
					}
					else
					{
						ulong num5 = 2uL;
						int num6 = 1;
						if (1L < num3)
						{
							do
							{
								num5 *= 2L;
								num6++;
							}
							while ((ulong)num6 < num3);
						}
						num4 = num5;
					}
					num += num4;
				}
				num2++;
			}
			while (num2 < listView_0.Items.Count);
		}
		bool_2 = true;
		decimal value = num;
		numericUpDown_0.Value = value;
		bool_2 = false;
	}

	private void ListBoxWindow_Shown(object sender, EventArgs e)
	{
		bool_3 = true;
		bool_2 = false;
	}

	private void numericUpDown_0_KeyPress(object sender, KeyPressEventArgs e)
	{
	}

	private void numericUpDown_0_KeyUp(object sender, KeyEventArgs e)
	{
		method_3();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		bool_2 = true;
		int num = listView_0.Items.Count - 1;
		if (num >= 0)
		{
			do
			{
				listView_0.Items[num].Checked = true;
				num--;
			}
			while (num >= 0);
		}
		bool_2 = false;
		method_4();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		bool_2 = true;
		int num = listView_0.Items.Count - 1;
		if (num >= 0)
		{
			do
			{
				listView_0.Items[num].Checked = false;
				num--;
			}
			while (num >= 0);
		}
		bool_2 = false;
		method_4();
	}

	private void method_5(object sender, EventArgs e)
	{
		Close();
	}

	private void ListBoxWindow_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}

	private void listView_0_KeyUp(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Escape)
		{
			Close();
		}
	}
}
