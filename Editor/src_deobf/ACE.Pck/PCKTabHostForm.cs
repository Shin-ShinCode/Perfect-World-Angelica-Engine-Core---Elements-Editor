using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Pck;

public class PCKTabHostForm : Form
{
	[Serializable]
	private sealed class Class346
	{
		public static readonly Class346 class346_0 = new Class346();

		public static Func<string, bool> func_0;

		internal bool method_0(string string_0)
		{
			string text = System.IO.Path.GetExtension(string_0).ToLower();
			if (!(text == Class16.smethod_0(1648909411)))
			{
				return text == Class16.smethod_0(1648989712);
			}
			return true;
		}
	}

	private TabControl tabControl_0;

	private Panel panel_0;

	public PCKTabHostForm()
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
	}

	public PCKTabHostForm(string filePath)
		: this()
	{
		if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
		{
			AddTab(filePath);
		}
		else
		{
			AddTab(null);
		}
	}

	public PCKTabHostForm(string[] filePaths)
		: this()
	{
		if (filePaths != null && filePaths.Length != 0)
		{
			foreach (string text in filePaths)
			{
				if (!string.IsNullOrEmpty(text) && File.Exists(text))
				{
					AddTab(text);
				}
			}
		}
		else
		{
			AddTab(null);
		}
	}

	private void method_0()
	{
		Text = Class16.smethod_0(1649039596);
		base.Icon = Resources.pckmodule_1;
		base.Size = new Size(900, 620);
		MinimumSize = new Size(700, 450);
		base.StartPosition = FormStartPosition.CenterScreen;
		AllowDrop = true;
		base.DragEnter += PCKTabHostForm_DragEnter;
		base.DragDrop += PCKTabHostForm_DragDrop;
		tabControl_0 = new TabControl
		{
			Dock = DockStyle.Fill,
			Padding = new Point(12, 4)
		};
		tabControl_0.MouseUp += tabControl_0_MouseUp;
		tabControl_0.DrawMode = TabDrawMode.OwnerDrawFixed;
		tabControl_0.DrawItem += tabControl_0_DrawItem;
		tabControl_0.SizeMode = TabSizeMode.Normal;
		tabControl_0.ItemSize = new Size(180, 24);
		tabControl_0.Visible = false;
		panel_0 = new Panel
		{
			Dock = DockStyle.Fill
		};
		base.Controls.Add(panel_0);
		base.Controls.Add(tabControl_0);
		if (TDark.IsDarkMode)
		{
			BackColor = Color.FromArgb(30, 30, 30);
		}
	}

	public void AddTab(string filePath)
	{
		PCKEditorForm pCKEditorForm = ((filePath != null) ? new PCKEditorForm(filePath) : new PCKEditorForm());
		pCKEditorForm.TopLevel = false;
		pCKEditorForm.FormBorderStyle = FormBorderStyle.None;
		pCKEditorForm.Dock = DockStyle.Fill;
		pCKEditorForm.Visible = true;
		pCKEditorForm.OpenedNewFile += method_2;
		if (tabControl_0.TabPages.Count == 0 && !tabControl_0.Visible)
		{
			panel_0.Controls.Add(pCKEditorForm);
			panel_0.Tag = pCKEditorForm;
			string text = ((filePath != null) ? System.IO.Path.GetFileName(filePath) : TextStorage.Msg(Class16.smethod_0(1649189866), Class16.smethod_0(1649188869)));
			TabPage value = new TabPage(text + Class16.smethod_0(1649188884))
			{
				Tag = pCKEditorForm
			};
			tabControl_0.TabPages.Add(value);
		}
		else
		{
			method_1();
			string text2 = ((filePath != null) ? System.IO.Path.GetFileName(filePath) : TextStorage.Msg(Class16.smethod_0(1649189866), Class16.smethod_0(1649188869)));
			TabPage tabPage = new TabPage(text2 + Class16.smethod_0(1649188884))
			{
				Tag = pCKEditorForm
			};
			tabPage.Controls.Add(pCKEditorForm);
			tabControl_0.TabPages.Add(tabPage);
			tabControl_0.SelectedTab = tabPage;
		}
		method_3();
	}

	private void method_1()
	{
		if (!tabControl_0.Visible)
		{
			if (panel_0.Tag is PCKEditorForm value)
			{
				panel_0.Controls.Remove(value);
				panel_0.Tag = null;
				TabPage tabPage = tabControl_0.TabPages[0];
				tabPage.Controls.Add(value);
			}
			panel_0.Visible = false;
			tabControl_0.Visible = true;
			tabControl_0.BringToFront();
		}
	}

	private void method_2(object object_0, string string_0)
	{
		if (tabControl_0.Visible)
		{
			for (int i = 0; i < tabControl_0.TabPages.Count; i++)
			{
				if (tabControl_0.TabPages[i].Tag == object_0)
				{
					string fileName = System.IO.Path.GetFileName(string_0);
					tabControl_0.TabPages[i].Text = fileName + Class16.smethod_0(1649188884);
					break;
				}
			}
		}
		method_3();
	}

	private void method_3()
	{
		if (tabControl_0.Visible && tabControl_0.SelectedTab?.Tag is PCKEditorForm pCKEditorForm)
		{
			Text = Class16.smethod_0(1649188895) + pCKEditorForm.Text.Replace(Class16.smethod_0(1649196243), string.Empty);
		}
		else if (panel_0.Tag is PCKEditorForm pCKEditorForm2)
		{
			Text = Class16.smethod_0(1649188895) + pCKEditorForm2.Text.Replace(Class16.smethod_0(1649196243), string.Empty);
		}
		else
		{
			Text = Class16.smethod_0(1649039596);
		}
	}

	private void tabControl_0_MouseUp(object sender, MouseEventArgs e)
	{
		if (e.Button != MouseButtons.Middle)
		{
			return;
		}
		int num = 0;
		while (true)
		{
			if (num < tabControl_0.TabPages.Count)
			{
				if (tabControl_0.GetTabRect(num).Contains(e.Location))
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		method_4(num);
	}

	private void tabControl_0_DrawItem(object sender, DrawItemEventArgs e)
	{
		TabPage tabPage = tabControl_0.TabPages[e.Index];
		Rectangle tabRect = tabControl_0.GetTabRect(e.Index);
		bool flag = tabControl_0.SelectedIndex == e.Index;
		Color color = ((!TDark.IsDarkMode) ? (flag ? SystemColors.Window : SystemColors.Control) : (flag ? Color.FromArgb(45, 45, 48) : Color.FromArgb(30, 30, 30)));
		Color foreColor = (TDark.IsDarkMode ? Color.White : SystemColors.ControlText);
		SolidBrush solidBrush = new SolidBrush(color);
		try
		{
			e.Graphics.FillRectangle(solidBrush, tabRect);
		}
		finally
		{
			((IDisposable)solidBrush).Dispose();
		}
		TextRenderer.DrawText(bounds: new Rectangle(tabRect.X + 4, tabRect.Y + 4, tabRect.Width - 22, tabRect.Height - 6), dc: e.Graphics, text: tabPage.Text.TrimEnd(), font: e.Font, foreColor: foreColor, flags: TextFormatFlags.VerticalCenter);
		Rectangle rectangle = new Rectangle(tabRect.Right - 20, tabRect.Y + 4, 16, 16);
		Color color2 = (TDark.IsDarkMode ? Color.FromArgb(160, 160, 160) : Color.Gray);
		Pen pen = new Pen(color2, 1.5f);
		try
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.DrawLine(pen, rectangle.X + 3, rectangle.Y + 3, rectangle.Right - 3, rectangle.Bottom - 3);
			e.Graphics.DrawLine(pen, rectangle.Right - 3, rectangle.Y + 3, rectangle.X + 3, rectangle.Bottom - 3);
		}
		finally
		{
			((IDisposable)pen).Dispose();
		}
	}

	private void method_4(int int_0)
	{
		if (int_0 >= 0 && int_0 < tabControl_0.TabPages.Count)
		{
			TabPage tabPage = tabControl_0.TabPages[int_0];
			if (tabPage.Tag is PCKEditorForm pCKEditorForm)
			{
				pCKEditorForm.Close();
			}
			tabControl_0.TabPages.RemoveAt(int_0);
			if (tabControl_0.TabPages.Count == 0)
			{
				Close();
			}
		}
	}

	private void PCKTabHostForm_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (array != null && array.Any(Class346.class346_0.method_0))
			{
				e.Effect = DragDropEffects.Copy;
				return;
			}
		}
		e.Effect = DragDropEffects.None;
	}

	private void PCKTabHostForm_DragDrop(object sender, DragEventArgs e)
	{
		if (!e.Data.GetDataPresent(DataFormats.FileDrop))
		{
			return;
		}
		string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
		if (array == null)
		{
			return;
		}
		string[] array2 = array;
		foreach (string text in array2)
		{
			string text2 = System.IO.Path.GetExtension(text).ToLower();
			if (text2 == Class16.smethod_0(1648909411) || text2 == Class16.smethod_0(1648989712))
			{
				AddTab(text);
			}
		}
	}

	protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
	{
		for (int num = tabControl_0.TabPages.Count - 1; num >= 0; num--)
		{
			if (tabControl_0.TabPages[num].Tag is PCKEditorForm pCKEditorForm)
			{
				pCKEditorForm.Close();
			}
		}
		base.OnFormClosing(formClosingEventArgs_0);
	}
}
