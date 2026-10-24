using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;

namespace ACE.Elements;

public class OctetsWindow : Form
{
	private string string_0;

	private string string_1;

	private string string_2;

	private ACE.Elements.eListCollection.eListCollection eListCollection_0;

	public CommonStorage CStorage;

	private int int_0;

	private int[] int_1;

	private SettingsClass settingsClass_0;

	private ToolTip toolTip_0;

	private TextBox textBox_0;

	private Label label_0;

	private Button button_0;

	private Button button_1;

	private WebBrowser webBrowser_0;

	private Button button_2;

	private TextBox textBox_1;

	private NumericUpDown numericUpDown_0;

	private Label label_1;

	private Button button_3;

	private Button button_4;

	private IContainer icontainer_0;

	public OctetsWindow(CommonStorage CStorage, ACE.Elements.eListCollection.eListCollection ref_eLC, int ref_l, int[] ref_itemsindices)
	{
		try
		{
			method_4();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this, null);
			eListCollection_0 = ref_eLC;
			int_0 = ref_l;
			int_1 = ref_itemsindices;
			string setting = (settingsClass_0 = CommonStorage.Profile).GetSetting(Class16.smethod_0(1648968786), Class16.smethod_0(1648968813), string.Empty);
			textBox_0.Text = setting;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.CtrlC(textBox_1.Text);
		Close();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void OctetsWindow_Shown(object sender, EventArgs e)
	{
		webBrowser_0.Document.BackColor = SpecialColors.ItemDark;
		Color white = Color.White;
		webBrowser_0.Document.ForeColor = white;
		method_0();
		method_2();
	}

	private void method_0()
	{
		if (!(webBrowser_0?.Document?.Body == null))
		{
			Color darkControlBack = TDark.DarkControlBack;
			Color darkControlFore = TDark.DarkControlFore;
			string text = string.Format(Class16.smethod_0(1648968819), darkControlBack.R, darkControlBack.G, darkControlBack.B);
			string text2 = string.Format(Class16.smethod_0(1648968819), darkControlFore.R, darkControlFore.G, darkControlFore.B);
			webBrowser_0.Document.BackColor = darkControlBack;
			webBrowser_0.Document.ForeColor = darkControlFore;
			webBrowser_0.Document.Body.Style = Class16.smethod_0(1648968842) + text + Class16.smethod_0(1648968866) + text2 + Class16.smethod_0(1648968881);
		}
	}

	private void method_1(string string_3)
	{
		if (!(webBrowser_0?.Document?.Body == null))
		{
			Color darkControlBack = TDark.DarkControlBack;
			Color darkControlFore = TDark.DarkControlFore;
			string text = string.Format(Class16.smethod_0(1648968819), darkControlBack.R, darkControlBack.G, darkControlBack.B);
			string text2 = string.Format(Class16.smethod_0(1648968819), darkControlFore.R, darkControlFore.G, darkControlFore.B);
			webBrowser_0.Document.Body.InnerHtml = Class16.smethod_0(1648969092) + text + Class16.smethod_0(1648968866) + text2 + Class16.smethod_0(1648969120) + string_3 + Class16.smethod_0(1648969190);
			method_0();
		}
	}

	private unsafe void method_2()
	{
		string text = null;
		DESC_EX dESC_EX = null;
		string_1 = string.Empty;
		string_0 = string.Empty;
		string_2 = string.Empty;
		ITEMDATA data = default(ITEMDATA);
		ACE.RSGlobal.RSGlobal.ITEMDATA(&data);
		int[] array = int_1;
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				int itemIndex = array[num];
				ITEMPOS itemPos = new ITEMPOS(int_0, itemIndex);
				text = null;
				decimal value = numericUpDown_0.Value;
				string text2 = Class16.smethod_0(1648924428);
				TextBox textBox = textBox_0;
				ACE.Elements.eListCollection.eListCollection eListCollection2 = eListCollection_0;
				string text3 = string_1;
				string_1 = string.Concat(text3, eListCollection2.GenerateXML(itemPos, (int)value, textBox.Text, &data, ref text) + text2);
				string text4 = (((nint)int_1.LongLength <= 1) ? string.Empty : Class16.smethod_0(1648898460));
				string text5 = string_0;
				string_0 = string.Concat(text5, text + text4);
				dESC_EX = new DESC_EX(bBuild: true);
				ACE.Elements.eListCollection.eListCollection eListCollection3 = eListCollection_0;
				string text6 = string_2;
				string_2 = text6 + eListCollection3.GenerateHTMLPreview(itemPos, data, textBox_0.Text, IsShopPrice: false, IsCleanHtml: true, bUnlimited: false, bViewIcon: false, ref dESC_EX);
				string text7 = (((nint)int_1.LongLength <= 1) ? string.Empty : Class16.smethod_0(1648969195));
				string text8 = string_2;
				string_2 = string.Concat(text8, text7 + Class16.smethod_0(1648924428));
				num++;
			}
			while (num < (nint)array.LongLength);
		}
		textBox_1.Text = string_1;
		textBox_1.Focus();
		textBox_1.SelectAll();
		method_1(string_2);
		settingsClass_0.SaveSetting(Class16.smethod_0(1648968786), Class16.smethod_0(1648968813), textBox_0.Text);
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		string text = Class16.smethod_0(1648969210);
		ACE.RSGlobal.RSGlobal.CtrlC(string.Concat(Class16.smethod_0(1648968215) + string_2, text));
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		ACE.RSGlobal.RSGlobal.CtrlC(string_0);
		GC.KeepAlive(this);
	}

	private void method_3()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	private void method_4()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(OctetsWindow));
		textBox_1 = new TextBox();
		numericUpDown_0 = new NumericUpDown();
		label_1 = new Label();
		button_3 = new Button();
		button_4 = new Button();
		button_2 = new Button();
		toolTip_0 = new ToolTip(icontainer_0);
		textBox_0 = new TextBox();
		label_0 = new Label();
		button_0 = new Button();
		button_1 = new Button();
		webBrowser_0 = new WebBrowser();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		SuspendLayout();
		textBox_1.AcceptsReturn = true;
		textBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.CharacterCasing = CharacterCasing.Lower;
		textBox_1.Location = new Point(2, 491);
		textBox_1.MaxLength = 1000000;
		textBox_1.Multiline = true;
		textBox_1.Name = Class16.smethod_0(1648968290);
		textBox_1.ScrollBars = ScrollBars.Both;
		textBox_1.Size = new Size(861, 84);
		textBox_1.TabIndex = 0;
		numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_0.Location = new Point(145, 581);
		numericUpDown_0.Maximum = new decimal(new int[4] { 1000000, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648968311);
		numericUpDown_0.Size = new Size(109, 20);
		numericUpDown_0.TabIndex = 1;
		numericUpDown_0.TextAlign = HorizontalAlignment.Center;
		numericUpDown_0.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_1.Location = new Point(6, 584);
		label_1.Name = Class16.smethod_0(1648968315);
		label_1.Size = new Size(136, 13);
		label_1.TabIndex = 2;
		label_1.Text = Class16.smethod_0(1648968341);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		button_3.DialogResult = DialogResult.OK;
		button_3.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_3.Image = Resources.cmdCopyAsXml;
		button_3.ImageAlign = ContentAlignment.MiddleRight;
		button_3.Location = new Point(2, 606);
		button_3.Name = Class16.smethod_0(1648968364);
		button_3.Size = new Size(201, 27);
		button_3.TabIndex = 7;
		button_3.TabStop = false;
		button_3.Text = Class16.smethod_0(1648968383);
		button_3.TextImageRelation = TextImageRelation.ImageBeforeText;
		toolTip_0.SetToolTip(button_3, Class16.smethod_0(1648968393));
		button_3.UseVisualStyleBackColor = true;
		button_3.Click += button_3_Click;
		button_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_4.AutoSize = true;
		button_4.DialogResult = DialogResult.Cancel;
		button_4.Font = new Font(Class16.smethod_0(1648942905), 9f);
		button_4.Image = Resources.OctetsWindow_cmdCancel;
		button_4.ImageAlign = ContentAlignment.MiddleRight;
		button_4.Location = new Point(695, 606);
		button_4.Name = Class16.smethod_0(1649000848);
		button_4.Size = new Size(170, 26);
		button_4.TabIndex = 8;
		button_4.TabStop = false;
		button_4.Text = Class16.smethod_0(1648941799);
		button_4.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_4.UseVisualStyleBackColor = true;
		button_4.Click += button_4_Click;
		button_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_2.Image = Resources.cmdGenerate;
		button_2.ImageAlign = ContentAlignment.MiddleRight;
		button_2.Location = new Point(738, 579);
		button_2.Name = Class16.smethod_0(1648968553);
		button_2.Size = new Size(127, 23);
		button_2.TabIndex = 9;
		button_2.Text = Class16.smethod_0(1648968571);
		button_2.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		toolTip_0.AutoPopDelay = 10000;
		toolTip_0.InitialDelay = 500;
		toolTip_0.ReshowDelay = 100;
		textBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.Location = new Point(339, 581);
		textBox_0.MaxLength = 127;
		textBox_0.Name = Class16.smethod_0(1648968586);
		textBox_0.Size = new Size(393, 20);
		textBox_0.TabIndex = 10;
		toolTip_0.SetToolTip(textBox_0, Class16.smethod_0(1648968603));
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Regular, GraphicsUnit.Point, 204);
		label_0.Location = new Point(268, 584);
		label_0.Name = Class16.smethod_0(1648968678);
		label_0.Size = new Size(66, 13);
		label_0.TabIndex = 11;
		label_0.Text = Class16.smethod_0(1648968695);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_0.AutoSize = true;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_0.Image = Resources.cmdCopyOctets;
		button_0.ImageAlign = ContentAlignment.MiddleRight;
		button_0.Location = new Point(209, 606);
		button_0.Name = Class16.smethod_0(1648967686);
		button_0.Size = new Size(236, 27);
		button_0.TabIndex = 13;
		button_0.TabStop = false;
		button_0.Text = Class16.smethod_0(1648967698);
		button_0.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_1.AutoSize = true;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Regular, GraphicsUnit.Point, 204);
		button_1.Image = Resources.cmdCopyAsHtml;
		button_1.ImageAlign = ContentAlignment.MiddleRight;
		button_1.Location = new Point(450, 606);
		button_1.Name = Class16.smethod_0(1648967721);
		button_1.Size = new Size(236, 27);
		button_1.TabIndex = 14;
		button_1.TabStop = false;
		button_1.Text = Class16.smethod_0(1648967749);
		button_1.TextImageRelation = TextImageRelation.ImageBeforeText;
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		webBrowser_0.AllowNavigation = false;
		webBrowser_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		webBrowser_0.IsWebBrowserContextMenuEnabled = false;
		webBrowser_0.Location = new Point(0, 0);
		webBrowser_0.MinimumSize = new Size(20, 20);
		webBrowser_0.Name = Class16.smethod_0(1648976300);
		webBrowser_0.Size = new Size(868, 485);
		webBrowser_0.TabIndex = 12;
		webBrowser_0.Url = new Uri(Class16.smethod_0(1648976309), UriKind.Absolute);
		webBrowser_0.WebBrowserShortcutsEnabled = false;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(868, 637);
		base.Controls.Add(webBrowser_0);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(button_2);
		base.Controls.Add(button_3);
		base.Controls.Add(button_4);
		base.Controls.Add(label_1);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(textBox_1);
		base.Icon = Resources.OctetsWindow_Icon;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648968786);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648967760);
		base.Shown += OctetsWindow_Shown;
		((ISupportInitialize)numericUpDown_0).EndInit();
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
				method_3();
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
