using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.Elements;

public class DebugWindow : Form
{
	private TextBox textBox_0;

	public Container components;

	public DebugWindow(string Title, string Message)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this);
			Text = Title;
			textBox_0.Text = Message;
			textBox_0.SelectionStart = 0;
			textBox_0.SelectionLength = 0;
			Show();
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public DebugWindow()
	{
		try
		{
			method_1();
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(DebugWindow));
		textBox_0 = new TextBox();
		SuspendLayout();
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Font = new Font(Class16.smethod_0(1648987774), 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
		textBox_0.Location = new Point(0, 2);
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1648894248);
		textBox_0.ScrollBars = ScrollBars.Both;
		textBox_0.Size = new Size(320, 478);
		textBox_0.TabIndex = 0;
		textBox_0.WordWrap = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(320, 480);
		base.Controls.Add(textBox_0);
		base.Icon = Resources.edit;
		base.Name = Class16.smethod_0(1648987787);
		base.ShowIcon = false;
		Text = Class16.smethod_0(1648987787);
		ResumeLayout(performLayout: false);
		PerformLayout();
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
