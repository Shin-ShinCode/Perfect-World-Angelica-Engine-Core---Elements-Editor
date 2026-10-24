using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Elements.eListConversation;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.Elements;

public class DialogPreview : Form
{
	public static bool TabsPaused;

	public int SelectedDialogID;

	public int SelectedDialogIndex;

	public bool norefresh;

	public CommonStorage CStorage;

	public ITEMPOS ServicePos;

	public ACE.Elements.eListCollection.eListCollection eLC;

	public ACE.Elements.eListConversation.eListConversation ConversationList;

	public Form ElementsWindow;

	private static bool bool_0;

	private int int_0 = -1;

	private int int_1 = -1;

	private PictureBox pictureBox_0;

	private PictureBox pictureBox_1;

	private PictureBox pictureBox_2;

	private PictureBox pictureBox_3;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private Label label_6;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private ListBox listBox_0;

	private ListBox listBox_1;

	private TextBox textBox_2;

	private Button button_0;

	private Button button_1;

	private IContainer icontainer_0;

	private Point point_0;

	protected override bool ShowWithoutActivation
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return true;
		}
	}

	public DialogPreview(CommonStorage ref_CStorage, Form ElementsWindow)
	{
		try
		{
			method_2();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
			TextStorage.TEXTS.SetFormLanguage(this);
			CStorage = ref_CStorage;
			this.ElementsWindow = ElementsWindow;
			new ElipseFormAngles(this);
			Cursor = CommonStorage.PWCursor1;
			norefresh = false;
			GC.KeepAlive(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public void CreatePreview(ITEMPOS ip, ACE.Elements.eListConversation.eListConversation conversationList)
	{
		if (!(ip == null) && ip.int_1 >= 0 && ip.int_1 < eLC.GetItemsCount(ip.int_0))
		{
			ServicePos = ip;
			ConversationList = conversationList;
			int num = eLC.findex(ip.int_0, Class16.smethod_0(1648987813));
			if (num < 0)
			{
				label_5.Visible = true;
				method_0();
				return;
			}
			int num2 = (SelectedDialogID = eLC.GetValueI(ip.int_0, ip.int_1, num));
			if (conversationList != null && conversationList.DialogCount != 0)
			{
				SelectedDialogIndex = conversationList.GetIndexByDialogID(num2);
				if (SelectedDialogIndex < 0)
				{
					label_5.Visible = true;
					label_5.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648987886), Class16.smethod_0(1648987913)), num2);
					method_0();
				}
				else
				{
					label_5.Visible = false;
					method_1(SelectedDialogIndex);
				}
			}
			else
			{
				label_5.Visible = true;
				label_5.Text = TextStorage.Msg(Class16.smethod_0(1648987829), Class16.smethod_0(1648987862));
				method_0();
			}
		}
		else if (base.Visible)
		{
			Close();
		}
	}

	private void method_0()
	{
		textBox_0.Text = string.Empty;
		textBox_1.Text = string.Empty;
		listBox_0.Items.Clear();
		listBox_1.Items.Clear();
		textBox_2.Text = string.Empty;
		int_0 = -1;
		int_1 = -1;
	}

	private void method_1(int int_2)
	{
		if (ConversationList == null || int_2 < 0 || int_2 >= ConversationList.DialogCount)
		{
			return;
		}
		norefresh = true;
		eDialog eDialog2 = ConversationList.Dialogs[int_2];
		textBox_0.Text = eDialog2.DialogID.ToString();
		TextBox textBox = textBox_1;
		string obj = eDialog2.GetText();
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = obj.TrimEnd(default(char));
			if (obj2 != null)
			{
				goto IL_0075;
			}
		}
		obj2 = string.Empty;
		goto IL_0075;
		IL_0075:
		textBox.Text = (string)obj2;
		listBox_0.Items.Clear();
		listBox_1.Items.Clear();
		textBox_2.Text = string.Empty;
		if (eDialog2.Questions != null && eDialog2.QuestionCount > 0)
		{
			for (int num = 0; num < eDialog2.QuestionCount; num++)
			{
				eQuestion eQuestion2 = eDialog2.Questions[num];
				string obj3 = eQuestion2.GetText();
				object obj4;
				if (obj3 == null)
				{
					obj4 = null;
				}
				else
				{
					obj4 = obj3.TrimEnd(default(char));
					if (obj4 != null)
					{
						goto IL_00ef;
					}
				}
				obj4 = string.Empty;
				goto IL_00ef;
				IL_00ef:
				string text = (string)obj4;
				if (text.Length > 40)
				{
					text = text.Substring(0, 40) + Class16.smethod_0(1648924410);
				}
				listBox_0.Items.Add(string.Format(Class16.smethod_0(1648942820), eQuestion2.QuestionID, text));
			}
			if (listBox_0.Items.Count > 0)
			{
				listBox_0.SelectedIndex = 0;
			}
		}
		norefresh = false;
		GC.KeepAlive(this);
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (norefresh || ConversationList == null || SelectedDialogIndex < 0)
		{
			return;
		}
		int_0 = listBox_0.SelectedIndex;
		if (int_0 < 0)
		{
			return;
		}
		eDialog eDialog2 = ConversationList.Dialogs[SelectedDialogIndex];
		if (eDialog2.Questions == null || int_0 >= eDialog2.QuestionCount)
		{
			return;
		}
		eQuestion eQuestion2 = eDialog2.Questions[int_0];
		TextBox textBox = textBox_2;
		string obj = eQuestion2.GetText();
		object obj2;
		if (obj == null)
		{
			obj2 = null;
		}
		else
		{
			obj2 = obj.TrimEnd(default(char));
			if (obj2 != null)
			{
				goto IL_00a1;
			}
		}
		obj2 = string.Empty;
		goto IL_00a1;
		IL_00a1:
		textBox.Text = (string)obj2;
		listBox_1.Items.Clear();
		if (eQuestion2.Choices != null && eQuestion2.ChoiceQount > 0)
		{
			for (int num = 0; num < eQuestion2.ChoiceQount; num++)
			{
				eChoice eChoice2 = eQuestion2.Choices[num];
				string obj3 = eChoice2.GetText();
				object obj4;
				if (obj3 == null)
				{
					obj4 = null;
				}
				else
				{
					obj4 = obj3.TrimEnd(default(char));
					if (obj4 != null)
					{
						goto IL_0100;
					}
				}
				obj4 = string.Empty;
				goto IL_0100;
				IL_0100:
				string text = (string)obj4;
				if (text.Length > 35)
				{
					text = text.Substring(0, 35) + Class16.smethod_0(1648924410);
				}
				listBox_1.Items.Add(string.Format(Class16.smethod_0(1648987951), text, eChoice2.Id));
			}
		}
		GC.KeepAlive(this);
	}

	private void listBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!norefresh)
		{
			int_1 = listBox_1.SelectedIndex;
			GC.KeepAlive(this);
		}
	}

	private void DialogPreview_FormClosing(object sender, FormClosingEventArgs e)
	{
		Hide();
		e.Cancel = true;
		GC.KeepAlive(this);
	}

	private void DialogPreview_MouseDown(object sender, MouseEventArgs e)
	{
		point_0 = Cursor.Position;
		bool_0 = true;
		GC.KeepAlive(this);
	}

	private void DialogPreview_MouseUp(object sender, MouseEventArgs e)
	{
		bool_0 = false;
	}

	private void DialogPreview_MouseMove(object sender, MouseEventArgs e)
	{
		if (bool_0)
		{
			Point position = Cursor.Position;
			int num = base.Left - point_0.X;
			base.Left = position.X + num;
			int num2 = base.Top - point_0.Y;
			base.Top = position.Y + num2;
			point_0 = Cursor.Position;
		}
		GC.KeepAlive(this);
	}

	private void method_2()
	{
		icontainer_0 = new Container();
		new ComponentResourceManager(typeof(RecipesPreview));
		pictureBox_0 = new PictureBox();
		pictureBox_1 = new PictureBox();
		pictureBox_2 = new PictureBox();
		pictureBox_3 = new PictureBox();
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		label_3 = new Label();
		label_4 = new Label();
		label_5 = new Label();
		label_6 = new Label();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		listBox_0 = new ListBox();
		listBox_1 = new ListBox();
		textBox_2 = new TextBox();
		button_0 = new Button();
		button_1 = new Button();
		((ISupportInitialize)pictureBox_0).BeginInit();
		((ISupportInitialize)pictureBox_1).BeginInit();
		((ISupportInitialize)pictureBox_2).BeginInit();
		((ISupportInitialize)pictureBox_3).BeginInit();
		SuspendLayout();
		pictureBox_0.Image = Resources.picExit_normal;
		pictureBox_0.Location = new Point(12, 10);
		pictureBox_0.Name = Class16.smethod_0(1648987968);
		pictureBox_0.Size = new Size(16, 16);
		pictureBox_0.TabIndex = 0;
		pictureBox_0.TabStop = false;
		pictureBox_0.Visible = false;
		pictureBox_1.Image = Resources.picExit_mousemove;
		pictureBox_1.Location = new Point(34, 10);
		pictureBox_1.Name = Class16.smethod_0(1648987997);
		pictureBox_1.Size = new Size(16, 16);
		pictureBox_1.TabIndex = 1;
		pictureBox_1.TabStop = false;
		pictureBox_1.Visible = false;
		pictureBox_2.Image = Resources.picExit;
		pictureBox_2.Location = new Point(280, 10);
		pictureBox_2.Name = Class16.smethod_0(1648988021);
		pictureBox_2.Size = new Size(16, 16);
		pictureBox_2.TabIndex = 2;
		pictureBox_2.TabStop = false;
		pictureBox_2.Click += button_1_Click;
		pictureBox_2.MouseEnter += pictureBox_2_MouseEnter;
		pictureBox_2.MouseLeave += pictureBox_2_MouseLeave;
		label_6.BackColor = Color.FromArgb(36, 42, 50);
		label_6.Font = new Font(Class16.smethod_0(1648942905), 10.5f, FontStyle.Bold);
		label_6.ForeColor = Color.FromArgb(239, 191, 72);
		label_6.Location = new Point(80, 6);
		label_6.Name = Class16.smethod_0(1648992332);
		label_6.Size = new Size(140, 20);
		label_6.TabIndex = 3;
		label_6.Text = Class16.smethod_0(1648988027);
		label_6.TextAlign = ContentAlignment.MiddleCenter;
		label_6.MouseDown += DialogPreview_MouseDown;
		label_6.MouseMove += DialogPreview_MouseMove;
		label_6.MouseUp += DialogPreview_MouseUp;
		label_0.AutoSize = true;
		label_0.BackColor = Color.Transparent;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_0.ForeColor = Color.FromArgb(239, 191, 72);
		label_0.Location = new Point(15, 35);
		label_0.Name = Class16.smethod_0(1648988048);
		label_0.Size = new Size(55, 13);
		label_0.TabIndex = 4;
		label_0.Text = Class16.smethod_0(1648988066);
		textBox_0.BackColor = Color.FromArgb(20, 30, 37);
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f);
		textBox_0.ForeColor = Color.FromArgb(240, 240, 240);
		textBox_0.Location = new Point(80, 32);
		textBox_0.Name = Class16.smethod_0(1648988083);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(70, 22);
		textBox_0.TabIndex = 5;
		label_1.AutoSize = true;
		label_1.BackColor = Color.Transparent;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_1.ForeColor = Color.FromArgb(239, 191, 72);
		label_1.Location = new Point(160, 35);
		label_1.Name = Class16.smethod_0(1648988109);
		label_1.Size = new Size(38, 13);
		label_1.TabIndex = 6;
		label_1.Text = Class16.smethod_0(1648930944);
		textBox_1.BackColor = Color.FromArgb(20, 30, 37);
		textBox_1.BorderStyle = BorderStyle.FixedSingle;
		textBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f);
		textBox_1.ForeColor = Color.FromArgb(240, 240, 240);
		textBox_1.Location = new Point(200, 32);
		textBox_1.Name = Class16.smethod_0(1648988121);
		textBox_1.ReadOnly = true;
		textBox_1.Size = new Size(95, 22);
		textBox_1.TabIndex = 7;
		label_2.AutoSize = true;
		label_2.BackColor = Color.Transparent;
		label_2.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_2.ForeColor = Color.FromArgb(239, 191, 72);
		label_2.Location = new Point(15, 60);
		label_2.Name = Class16.smethod_0(1648988149);
		label_2.Size = new Size(58, 13);
		label_2.TabIndex = 8;
		label_2.Text = Class16.smethod_0(1648987136);
		listBox_0.BackColor = Color.FromArgb(20, 30, 37);
		listBox_0.BorderStyle = BorderStyle.FixedSingle;
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 8f);
		listBox_0.ForeColor = Color.FromArgb(240, 240, 240);
		listBox_0.FormattingEnabled = true;
		listBox_0.ItemHeight = 13;
		listBox_0.Location = new Point(15, 76);
		listBox_0.Name = Class16.smethod_0(1648987159);
		listBox_0.Size = new Size(280, 80);
		listBox_0.TabIndex = 9;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		label_4.AutoSize = true;
		label_4.BackColor = Color.Transparent;
		label_4.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_4.ForeColor = Color.FromArgb(239, 191, 72);
		label_4.Location = new Point(15, 162);
		label_4.Name = Class16.smethod_0(1648987170);
		label_4.Size = new Size(75, 13);
		label_4.TabIndex = 10;
		label_4.Text = Class16.smethod_0(1648987192);
		textBox_2.BackColor = Color.FromArgb(20, 30, 37);
		textBox_2.BorderStyle = BorderStyle.FixedSingle;
		textBox_2.Font = new Font(Class16.smethod_0(1648942905), 8f);
		textBox_2.ForeColor = Color.FromArgb(240, 240, 240);
		textBox_2.Location = new Point(15, 178);
		textBox_2.Multiline = true;
		textBox_2.Name = Class16.smethod_0(1648987211);
		textBox_2.ReadOnly = true;
		textBox_2.ScrollBars = ScrollBars.Vertical;
		textBox_2.Size = new Size(280, 60);
		textBox_2.TabIndex = 11;
		label_3.AutoSize = true;
		label_3.BackColor = Color.Transparent;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		label_3.ForeColor = Color.FromArgb(239, 191, 72);
		label_3.Location = new Point(15, 244);
		label_3.Name = Class16.smethod_0(1648987233);
		label_3.Size = new Size(50, 13);
		label_3.TabIndex = 12;
		label_3.Text = Class16.smethod_0(1648987250);
		listBox_1.BackColor = Color.FromArgb(20, 30, 37);
		listBox_1.BorderStyle = BorderStyle.FixedSingle;
		listBox_1.Font = new Font(Class16.smethod_0(1648942905), 8f);
		listBox_1.ForeColor = Color.FromArgb(240, 240, 240);
		listBox_1.FormattingEnabled = true;
		listBox_1.ItemHeight = 13;
		listBox_1.Location = new Point(15, 260);
		listBox_1.Name = Class16.smethod_0(1648987265);
		listBox_1.Size = new Size(280, 80);
		listBox_1.TabIndex = 13;
		listBox_1.SelectedIndexChanged += listBox_1_SelectedIndexChanged;
		button_0.BackColor = Color.FromArgb(50, 60, 70);
		button_0.FlatAppearance.BorderColor = Color.FromArgb(80, 90, 100);
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		button_0.ForeColor = Color.FromArgb(239, 191, 72);
		button_0.Location = new Point(15, 350);
		button_0.Name = Class16.smethod_0(1648987282);
		button_0.Size = new Size(100, 25);
		button_0.TabIndex = 14;
		button_0.Text = Class16.smethod_0(1648987310);
		button_0.UseVisualStyleBackColor = false;
		button_0.Click += button_0_Click;
		button_1.BackColor = Color.FromArgb(50, 60, 70);
		button_1.FlatAppearance.BorderColor = Color.FromArgb(80, 90, 100);
		button_1.FlatStyle = FlatStyle.Flat;
		button_1.Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold);
		button_1.ForeColor = Color.FromArgb(119, 119, 94);
		button_1.Location = new Point(195, 350);
		button_1.Name = Class16.smethod_0(1648987321);
		button_1.Size = new Size(100, 25);
		button_1.TabIndex = 15;
		button_1.Text = Class16.smethod_0(1648987343);
		button_1.UseVisualStyleBackColor = false;
		button_1.Click += button_1_Click;
		label_5.BackColor = Color.Transparent;
		label_5.Font = new Font(Class16.smethod_0(1648942905), 12f, FontStyle.Bold);
		label_5.ForeColor = Color.FromArgb(192, 64, 64);
		label_5.Location = new Point(15, 180);
		label_5.Name = Class16.smethod_0(1648987346);
		label_5.Size = new Size(280, 50);
		label_5.TabIndex = 16;
		label_5.Text = Class16.smethod_0(1648987372);
		label_5.TextAlign = ContentAlignment.MiddleCenter;
		label_5.Visible = false;
		pictureBox_3.Dock = DockStyle.Fill;
		pictureBox_3.Image = Resources.dialog;
		pictureBox_3.Location = new Point(0, 0);
		pictureBox_3.Name = Class16.smethod_0(1648987386);
		pictureBox_3.Size = new Size(310, 390);
		pictureBox_3.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_3.TabIndex = 17;
		pictureBox_3.TabStop = false;
		pictureBox_3.MouseDown += DialogPreview_MouseDown;
		pictureBox_3.MouseMove += DialogPreview_MouseMove;
		pictureBox_3.MouseUp += DialogPreview_MouseUp;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(20, 27, 37);
		BackgroundImageLayout = ImageLayout.None;
		base.ClientSize = new Size(310, 390);
		base.Controls.Add(label_6);
		base.Controls.Add(pictureBox_2);
		base.Controls.Add(pictureBox_1);
		base.Controls.Add(pictureBox_0);
		base.Controls.Add(label_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_1);
		base.Controls.Add(textBox_1);
		base.Controls.Add(label_2);
		base.Controls.Add(listBox_0);
		base.Controls.Add(label_4);
		base.Controls.Add(textBox_2);
		base.Controls.Add(label_3);
		base.Controls.Add(listBox_1);
		base.Controls.Add(button_0);
		base.Controls.Add(button_1);
		base.Controls.Add(label_5);
		base.Controls.Add(pictureBox_3);
		base.FormBorderStyle = FormBorderStyle.None;
		base.KeyPreview = true;
		base.Name = Class16.smethod_0(1648987414);
		base.Opacity = 0.97;
		base.ShowIcon = false;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		Text = Class16.smethod_0(1648987426);
		base.FormClosing += DialogPreview_FormClosing;
		base.MouseDown += DialogPreview_MouseDown;
		base.MouseMove += DialogPreview_MouseMove;
		base.MouseUp += DialogPreview_MouseUp;
		((ISupportInitialize)pictureBox_0).EndInit();
		((ISupportInitialize)pictureBox_1).EndInit();
		((ISupportInitialize)pictureBox_2).EndInit();
		((ISupportInitialize)pictureBox_3).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_3()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool disposing)
	{
		if (disposing)
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

	private void pictureBox_2_MouseEnter(object sender, EventArgs e)
	{
		pictureBox_2.Image = pictureBox_1.Image;
		GC.KeepAlive(this);
	}

	private void pictureBox_2_MouseLeave(object sender, EventArgs e)
	{
		pictureBox_2.Image = pictureBox_0.Image;
		GC.KeepAlive(this);
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		DialogPreview_FormClosing(null, new FormClosingEventArgs(CloseReason.UserClosing, cancel: false));
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (ConversationList == null || SelectedDialogIndex < 0)
		{
			return;
		}
		int num = eLC.get_LI(Class16.smethod_0(1648987478));
		if (num < 0)
		{
			return;
		}
		int dialogID = ConversationList.Dialogs[SelectedDialogIndex].DialogID;
		int num2 = -1;
		int num3 = eLC.findex(num, Class16.smethod_0(1648932143));
		if (num3 >= 0)
		{
			for (int i = 0; i < eLC.GetItemsCount(num); i++)
			{
				if (eLC.GetValueI(num, i, num3) == dialogID)
				{
					num2 = i;
					break;
				}
			}
		}
		if (num2 >= 0)
		{
			SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST, num, 0);
			IntPtr intptr_ = smethod_0(new int[1] { num2 });
			SendMessage_1(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS, 1, intptr_);
		}
		GC.KeepAlive(this);
	}

	[DllImport("user32.dll")]
	private static extern IntPtr SendMessage(IntPtr intptr_0, int int_2, int int_3, int int_4);

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern IntPtr SendMessage_1(IntPtr intptr_0, int int_2, int int_3, IntPtr intptr_1);

	private static IntPtr smethod_0(int[] int_2)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(int_2.Length * 4);
		Marshal.Copy(int_2, 0, intPtr, int_2.Length);
		return intPtr;
	}
}
