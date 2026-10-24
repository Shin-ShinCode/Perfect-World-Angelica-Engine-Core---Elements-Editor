using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class ConfigsComparer : Form
{
	private string string_0;

	private string string_1;

	private List<string> list_0;

	private List<string> list_1;

	private Button button_0;

	private RichTextBox richTextBox_0;

	private RichTextBox richTextBox_1;

	private Button button_1;

	private Button button_2;

	public Container components;

	public ConfigsComparer()
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_1_DragDrop(object sender, DragEventArgs e)
	{
		StreamReader streamReader = new StreamReader(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
		list_0 = new List<string>(500);
		string text = streamReader.ReadLine();
		if (text != null)
		{
			do
			{
				list_0.Add(text);
				text = streamReader.ReadLine();
			}
			while (text != null);
		}
		string text2 = (string_0 = string.Join(Class16.smethod_0(1648924428), list_0));
		richTextBox_0.Text = text2;
		streamReader.Close();
		GC.KeepAlive(this);
	}

	private void button_1_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop, autoConvert: false))
		{
			e.Effect = DragDropEffects.All;
		}
		GC.KeepAlive(this);
	}

	private void button_2_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.FileDrop, autoConvert: false))
		{
			e.Effect = DragDropEffects.All;
		}
		GC.KeepAlive(this);
	}

	private void button_2_DragDrop(object sender, DragEventArgs e)
	{
		StreamReader streamReader = new StreamReader(((string[])e.Data.GetData(DataFormats.FileDrop))[0]);
		list_1 = new List<string>(500);
		string text = streamReader.ReadLine();
		if (text != null)
		{
			do
			{
				list_1.Add(text);
				text = streamReader.ReadLine();
			}
			while (text != null);
		}
		string text2 = (string_1 = string.Join(Class16.smethod_0(1648924428), list_1));
		richTextBox_1.Text = text2;
		streamReader.Close();
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		if (0 < list_0.Count)
		{
			do
			{
				if (num <= list_1.Count - 1)
				{
					string search = Class16.smethod_0(1648898262);
					List<string> list = list_1;
					string search2 = Class16.smethod_0(1648898262);
					if (ACE.RSGlobal.RSGlobal.CountWords(list_0[num], search2) == ACE.RSGlobal.RSGlobal.CountWords(list[num], search))
					{
						num++;
						continue;
					}
					num2 = num + 1;
					break;
				}
				return;
			}
			while (num < list_0.Count);
		}
		int firstCharIndexFromLine = richTextBox_0.GetFirstCharIndexFromLine(num2);
		richTextBox_0.Select(firstCharIndexFromLine, list_0[num2 - 1].Length);
		richTextBox_0.ScrollToCaret();
		richTextBox_0.Focus();
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(ConfigsComparer));
		richTextBox_0 = new RichTextBox();
		richTextBox_1 = new RichTextBox();
		button_1 = new Button();
		button_2 = new Button();
		button_0 = new Button();
		SuspendLayout();
		richTextBox_0.Location = new Point(0, 85);
		richTextBox_0.Name = Class16.smethod_0(1648984127);
		richTextBox_0.Size = new Size(611, 597);
		richTextBox_0.TabIndex = 0;
		richTextBox_0.Text = string.Empty;
		richTextBox_1.Location = new Point(617, 85);
		richTextBox_1.Name = Class16.smethod_0(1648984141);
		richTextBox_1.Size = new Size(576, 597);
		richTextBox_1.TabIndex = 1;
		richTextBox_1.Text = string.Empty;
		button_1.AllowDrop = true;
		button_1.Location = new Point(0, -1);
		button_1.Name = Class16.smethod_0(1648991094);
		button_1.Size = new Size(611, 53);
		button_1.TabIndex = 2;
		button_1.Text = Class16.smethod_0(1648984147);
		button_1.UseVisualStyleBackColor = true;
		button_1.DragDrop += button_1_DragDrop;
		button_1.DragEnter += button_1_DragEnter;
		button_2.AllowDrop = true;
		button_2.Location = new Point(617, -1);
		button_2.Name = Class16.smethod_0(1648991134);
		button_2.Size = new Size(576, 53);
		button_2.TabIndex = 3;
		button_2.Text = Class16.smethod_0(1648984169);
		button_2.UseVisualStyleBackColor = true;
		button_2.DragDrop += button_2_DragDrop;
		button_2.DragEnter += button_2_DragEnter;
		button_0.AllowDrop = true;
		button_0.Location = new Point(0, 56);
		button_0.Name = Class16.smethod_0(1648990257);
		button_0.Size = new Size(1193, 23);
		button_0.TabIndex = 4;
		button_0.Text = Class16.smethod_0(1648984199);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1193, 682);
		base.Controls.Add(button_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(richTextBox_1);
		base.Controls.Add(richTextBox_0);
		base.Icon = Resources.edit;
		base.Name = Class16.smethod_0(1648984216);
		Text = Class16.smethod_0(1648984246);
		ResumeLayout(performLayout: false);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_0();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}
}
