using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eList;
using ACE.Elements.eListCollection;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class FavoritesEditor : Form
{
	private ACE.Elements.eListCollection.eListCollection eListCollection_0;

	private CommonStorage commonStorage_0;

	private Button button_0;

	private ComboBox comboBox_0;

	private Button button_1;

	private Button button_2;

	private TextBox textBox_0;

	public Container components;

	public FavoritesEditor(ACE.Elements.eListCollection.eListCollection ref_eLC, CommonStorage ref_CStorage)
	{
		try
		{
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			commonStorage_0 = ref_CStorage;
			TextStorage.TEXTS.SetFormLanguage(this, null);
			eListCollection_0 = ref_eLC;
			int num = 0;
			if (0 < (nint)ref_eLC.Lists.LongLength)
			{
				do
				{
					ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
					if (num == eListCollection2.ConversationListIndex)
					{
						string item = TextStorage.TEXTS.GetText(Class16.smethod_0(1648981451));
						comboBox_0.Items.Add(item);
					}
					else
					{
						ACE.Elements.eList.eList eList2 = eListCollection2.Lists[num];
						string text = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
						string text2 = Class16.smethod_0(1648942897);
						string text3 = Class16.smethod_0(1648899468);
						string text4 = Class16.smethod_0(1648985628);
						string text5 = Class16.smethod_0(1648924364);
						comboBox_0.Items.Add(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text5 + num, text4), text), text3), eListCollection2.GetItemsCount(num)), text2));
					}
					num++;
				}
				while (num < (nint)eListCollection_0.Lists.LongLength);
			}
			comboBox_0.SelectedIndex = 0;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		CommonStorage.sData = textBox_0.Text;
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		int selectionStart = textBox_0.SelectionStart;
		string text = textBox_0.Text;
		int selectedIndex = comboBox_0.SelectedIndex;
		ACE.Elements.eList.eList eList2 = eListCollection_0.Lists[selectedIndex];
		string text2 = ((!ACE.RSGlobal.RSGlobal.SHOW_UNIVERSAL_NAMES) ? eList2.ListName : eList2.uListName);
		string text3 = Class16.smethod_0(1648924428);
		TextBox textBox = textBox_0;
		textBox_0.Text = text.Insert(textBox.SelectionStart, string.Concat(text3 + text2, text3));
		int selectionStart2 = selectionStart + comboBox_0.SelectedIndex.ToString().Length + 4;
		textBox_0.SelectionStart = selectionStart2;
		textBox_0.Focus();
		GC.KeepAlive(this);
	}

	private void FavoritesEditor_Shown(object sender, EventArgs e)
	{
		textBox_0.Text = CommonStorage.sData;
		GC.KeepAlive(this);
	}

	private void method_0()
	{
		((IDisposable)components)?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_1()
	{
		new ComponentResourceManager(typeof(FavoritesEditor));
		button_1 = new Button();
		button_2 = new Button();
		textBox_0 = new TextBox();
		button_0 = new Button();
		comboBox_0 = new ComboBox();
		SuspendLayout();
		button_1.AutoSize = true;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.FavoritesEditor_cmdcancel;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(187, 493);
		button_1.Name = Class16.smethod_0(1648925752);
		button_1.Size = new Size(177, 38);
		button_1.TabIndex = 35;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648989215);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.AutoSize = true;
		button_2.DialogResult = DialogResult.OK;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 11f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.FavoritesEditor_cmdok;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(4, 493);
		button_2.Name = Class16.smethod_0(1648925748);
		button_2.Size = new Size(177, 38);
		button_2.TabIndex = 34;
		button_2.TabStop = false;
		button_2.Text = Class16.smethod_0(1648981473);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		textBox_0.AcceptsReturn = true;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		textBox_0.Location = new Point(4, 38);
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1648981500);
		textBox_0.ScrollBars = ScrollBars.Vertical;
		textBox_0.Size = new Size(360, 449);
		textBox_0.TabIndex = 36;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Location = new Point(285, 6);
		button_0.Name = Class16.smethod_0(1648980495);
		button_0.Size = new Size(79, 26);
		button_0.TabIndex = 54;
		button_0.Text = Class16.smethod_0(1648980510);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(4, 7);
		comboBox_0.Name = Class16.smethod_0(1648980514);
		comboBox_0.Size = new Size(277, 25);
		comboBox_0.TabIndex = 53;
		base.AcceptButton = button_2;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_1;
		base.ClientSize = new Size(368, 536);
		base.Controls.Add(button_0);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_1);
		base.Controls.Add(button_2);
		base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648980535);
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648980557);
		base.TopMost = true;
		base.Shown += FavoritesEditor_Shown;
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
