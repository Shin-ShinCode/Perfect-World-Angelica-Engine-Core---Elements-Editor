using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.Settings;
using ACE.sTASKedit.Classes;
using mshtml;

namespace ACE.Elements;

public class ItemsToolTip : Form
{
	private bool bool_0;

	public static CommonStorage CStorage;

	public static double CustomLineHeight = -1.0;

	public static double CustomWordsMultiplier = -1.0;

	public static double DefaultLineHeight;

	public static ACE.Elements.eListCollection.eListCollection eLC;

	public static Form ElementsWindow;

	public static Graphics gfxMeasurer;

	public static WindowProc PrevWindowProc;

	public bool bCancel;

	public bool bDisableSmooth;

	public bool bHiding;

	public bool bShowing;

	public bool bSmoothShow = true;

	public Point CustomLocation;

	public TOOLTIP_TYPE HintType;

	public Point InitialCursorPosition;

	public bool IsCleanHtml;

	public bool IsItemOrTaskToolTip;

	public bool IsOnlyImage;

	public ItemsToolTip ItemsToolTip1;

	public string LastText;

	public Control OwnerControl;

	public IntPtr OwnerControlHandle = IntPtr.Zero;

	public ItemType Prev_item_type;

	public IntPtr PrevControlHandle;

	public int ShiftToLeft;

	public int ShowedItemID;

	public ITEMPOS ShowedItemPos;

	private IContainer icontainer_0;

	private Label label_0;

	private Label label_1;

	private PictureBox pictureBox_0;

	private PictureBox pictureBox_1;

	private PictureBox pictureBox_2;

	private PictureBox pictureBox_3;

	private PictureBox pictureBox_4;

	private PictureBox pictureBox_5;

	private PictureBox pictureBox_6;

	private PictureBox pictureBox_7;

	private PictureBox pictureBox_8;

	private PictureBox pictureBox_9;

	private PictureBox pictureBox_10;

	private Timer timer_0;

	private Timer timer_1;

	private Timer timer_2;

	private TextBox textBox_0;

	private WebBrowser webBrowser_0;

	protected override bool ShowWithoutActivation
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return HintType != TOOLTIP_TYPE.PinnedWindow;
		}
	}

	public ItemsToolTip(TOOLTIP_TYPE HintType)
	{
		try
		{
			bDisableSmooth = true;
			this.HintType = HintType;
			if (HintType == TOOLTIP_TYPE.Pinned)
			{
				bDisableSmooth = true;
			}
			method_1();
			TDark.StoreOriginalColors(this);
			TDark.ApplyTheme(this);
		}
		catch
		{
			base.Dispose(true);
			throw;
		}
	}

	public void AnullItem()
	{
		ShowedItemPos = null;
		ShowedItemID = 0;
		LastText = null;
	}

	public void ClonePinnedWindow()
	{
		ItemsToolTip itemsToolTip = new ItemsToolTip(TOOLTIP_TYPE.PinnedWindow);
		itemsToolTip.Text = Text;
		Size size = (itemsToolTip.ClientSize = base.ClientSize);
		Size size2 = size;
		_ = Cursor;
		Point position = Cursor.Position;
		int num = size2.Width / 2;
		int left = position.X - num;
		_ = Cursor;
		Point position2 = Cursor.Position;
		int num2 = SystemInformation.ToolWindowCaptionHeight / 2;
		int top = position2.Y - num2;
		itemsToolTip.Left = left;
		itemsToolTip.Top = top;
		string innerHtml = webBrowser_0.Document.Body.InnerHtml;
		Size size3 = webBrowser_0.Size;
		itemsToolTip.webBrowser_0.Size = size3;
		itemsToolTip.CreatePinnedWindow(OwnerControlHandle, innerHtml, ShowedItemPos);
		GC.KeepAlive(this);
	}

	public void CreatePinnedWindow(IntPtr ControlHandle, string HtmlText, ITEMPOS ItemPos)
	{
		timer_0.Enabled = false;
		timer_2.Enabled = false;
		OwnerControlHandle = ControlHandle;
		Application.DoEvents();
		string text = null;
		if (ItemPos != null)
		{
			string text2 = eLC.GenerateHTMLPreview(ItemPos, IsShopPrice: false, IsCleanHtml: false, bUnlimited: true);
			if (text2.Length > HtmlText.Length)
			{
				text = text2;
			}
		}
		if (text == null)
		{
			text = HtmlText;
		}
		text = Regex.Replace(text, Class16.smethod_0(1648976260), Class16.smethod_0(1648898209));
		if (ItemPos != null)
		{
			int num = ACE.RSGlobal.RSGlobal.CountWords(text, Class16.smethod_0(1648908417));
			string search = Class16.smethod_0(1648908417);
			int num2 = num - ACE.RSGlobal.RSGlobal.CountWords(HtmlText.ToLowerInvariant(), search);
			if (num2 > 0)
			{
				if (num < 50)
				{
					SetTextAndAutoSize(text);
				}
				else
				{
					webBrowser_0.Document.Body.InnerHtml = text;
					Application.DoEvents();
					base.Width += 50;
					int num3 = webBrowser_0.Height + (int)(DefaultLineHeight * (double)num2) + 50;
					webBrowser_0.Height = num3;
					if (num > 200)
					{
						int num4 = webBrowser_0.Height + 500;
						webBrowser_0.Height = num4;
					}
					base.HorizontalScroll.Enabled = false;
					base.HorizontalScroll.Maximum = 0;
					AutoScroll = false;
					base.VerticalScroll.Visible = false;
					AutoScroll = true;
					SubscribeLinkEvents();
				}
			}
			else
			{
				SetHtml(text);
			}
		}
		else
		{
			SetHtml(text);
		}
		Application.DoEvents();
		IntPtr foregroundWindow = ACE.RSGlobal.RSGlobal.GetForegroundWindow();
		IntPtr handle = ElementsWindow.Handle;
		if (foregroundWindow == handle)
		{
			Show();
		}
		else
		{
			ACE.RSGlobal.RSGlobal.ShowWindow(this);
			ACE.RSGlobal.RSGlobal.SetWindowLongA(base.Handle, -8, foregroundWindow);
			ACE.RSGlobal.RSGlobal.SetWindowPos(base.Handle, new IntPtr(-1), 0, 0, 0, 0, 67u);
		}
		webBrowser_0.IsWebBrowserContextMenuEnabled = true;
		GC.KeepAlive(this);
	}

	public void DisableHotKeys([MarshalAs(UnmanagedType.U1)] bool HideButtons)
	{
		if (HideButtons)
		{
			label_1.Visible = false;
			label_0.Visible = false;
		}
		ACE.RSGlobal.RSGlobal.UnregisterHotKey(base.Handle, HOTKEY_ID.Pin);
		ACE.RSGlobal.RSGlobal.UnregisterHotKey(base.Handle, HOTKEY_ID.F1);
		ACE.RSGlobal.RSGlobal.UnregisterHotKey(base.Handle, HOTKEY_ID.F2);
		GC.KeepAlive(this);
	}

	public void InitWindow()
	{
		if (HintType == TOOLTIP_TYPE.PinnedWindow)
		{
			pictureBox_3.Visible = false;
			pictureBox_4.Visible = false;
			pictureBox_5.Visible = false;
			pictureBox_6.Visible = false;
			pictureBox_7.Visible = false;
			pictureBox_8.Visible = false;
			pictureBox_9.Visible = false;
			pictureBox_10.Visible = false;
			base.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			base.ShowInTaskbar = true;
		}
		if (HintType != TOOLTIP_TYPE.Fly)
		{
			(ItemsToolTip1 = new ItemsToolTip(TOOLTIP_TYPE.Fly)).bDisableSmooth = true;
		}
	}

	private void method_0()
	{
		if (bool_0)
		{
			return;
		}
		bool_0 = true;
		try
		{
			timer_0?.Stop();
			timer_2?.Stop();
			timer_1?.Stop();
		}
		catch
		{
		}
		try
		{
			if (webBrowser_0 != null)
			{
				webBrowser_0.Navigating -= webBrowser_0_Navigating;
				webBrowser_0.Stop();
				webBrowser_0.DocumentText = string.Empty;
			}
		}
		catch
		{
		}
		if (ItemsToolTip1 != null && ItemsToolTip1 != this)
		{
			ItemsToolTip itemsToolTip = ItemsToolTip1;
			ItemsToolTip1 = null;
			try
			{
				itemsToolTip.Dispose();
			}
			catch
			{
			}
		}
		OwnerControl = null;
		OwnerControlHandle = IntPtr.Zero;
		PrevControlHandle = IntPtr.Zero;
		ShowedItemPos = null;
		LastText = null;
	}

	[HandleProcessCorruptedStateExceptions]
	protected override void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			try
			{
				method_0();
				method_2();
				return;
			}
			finally
			{
				base.Dispose(true);
			}
		}
		base.Dispose(false);
	}

	private void method_1()
	{
		icontainer_0 = new Container();
		webBrowser_0 = new WebBrowser();
		pictureBox_3 = new PictureBox();
		pictureBox_4 = new PictureBox();
		pictureBox_5 = new PictureBox();
		pictureBox_6 = new PictureBox();
		pictureBox_7 = new PictureBox();
		pictureBox_8 = new PictureBox();
		pictureBox_9 = new PictureBox();
		pictureBox_10 = new PictureBox();
		timer_0 = new Timer(icontainer_0);
		timer_2 = new Timer(icontainer_0);
		timer_1 = new Timer(icontainer_0);
		label_1 = new Label();
		pictureBox_0 = new PictureBox();
		pictureBox_1 = new PictureBox();
		pictureBox_2 = new PictureBox();
		textBox_0 = new TextBox();
		label_0 = new Label();
		((ISupportInitialize)pictureBox_3).BeginInit();
		((ISupportInitialize)pictureBox_4).BeginInit();
		((ISupportInitialize)pictureBox_5).BeginInit();
		((ISupportInitialize)pictureBox_6).BeginInit();
		((ISupportInitialize)pictureBox_7).BeginInit();
		((ISupportInitialize)pictureBox_8).BeginInit();
		((ISupportInitialize)pictureBox_9).BeginInit();
		((ISupportInitialize)pictureBox_10).BeginInit();
		((ISupportInitialize)pictureBox_0).BeginInit();
		((ISupportInitialize)pictureBox_1).BeginInit();
		((ISupportInitialize)pictureBox_2).BeginInit();
		SuspendLayout();
		webBrowser_0.AllowNavigation = false;
		webBrowser_0.IsWebBrowserContextMenuEnabled = false;
		Point location = new Point(-7, -13);
		webBrowser_0.Location = location;
		Size minimumSize = new Size(23, 20);
		webBrowser_0.MinimumSize = minimumSize;
		webBrowser_0.Name = Class16.smethod_0(1648976300);
		webBrowser_0.ScriptErrorsSuppressed = true;
		Size size = new Size(1920, 591);
		webBrowser_0.Size = size;
		webBrowser_0.TabIndex = 2;
		// TODO(recovered): the decoded initial Url may not be a valid absolute URI in this build,
		// and new Uri(..., UriKind.Absolute) throws UriFormatException during construction
		// (ItemsToolTip..ctor -> MainWindow..ctor). The browser content is set via DocumentText
		// at display time, so skip an invalid initial Url instead of crashing.
		if (Uri.TryCreate(Class16.smethod_0(1648976309), UriKind.Absolute, out Uri uri_initial))
		{
			webBrowser_0.Url = uri_initial;
		}
		webBrowser_0.WebBrowserShortcutsEnabled = false;
		webBrowser_0.Navigating += webBrowser_0_Navigating;
		pictureBox_3.BackgroundImageLayout = ImageLayout.None;
		pictureBox_3.Dock = DockStyle.Top;
		pictureBox_3.Image = Resources.pictureBox11;
		Point location2 = new Point(0, 0);
		pictureBox_3.Location = location2;
		pictureBox_3.Name = Class16.smethod_0(1648976327);
		Size size2 = new Size(854, 3);
		pictureBox_3.Size = size2;
		pictureBox_3.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_3.TabIndex = 3;
		pictureBox_3.TabStop = false;
		pictureBox_4.Image = Resources.pictureBox22;
		Point location3 = new Point(0, 0);
		pictureBox_4.Location = location3;
		pictureBox_4.Name = Class16.smethod_0(1648977021);
		Size size3 = new Size(3, 3);
		pictureBox_4.Size = size3;
		pictureBox_4.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_4.TabIndex = 4;
		pictureBox_4.TabStop = false;
		pictureBox_5.BackgroundImageLayout = ImageLayout.None;
		pictureBox_5.Dock = DockStyle.Left;
		pictureBox_5.Image = Resources.pictureBox33;
		Point location4 = new Point(0, 3);
		pictureBox_5.Location = location4;
		pictureBox_5.Name = Class16.smethod_0(1648976984);
		Size size4 = new Size(3, 576);
		pictureBox_5.Size = size4;
		pictureBox_5.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_5.TabIndex = 5;
		pictureBox_5.TabStop = false;
		pictureBox_6.BackgroundImageLayout = ImageLayout.None;
		pictureBox_6.Dock = DockStyle.Bottom;
		pictureBox_6.Image = Resources.pictureBox44;
		Point location5 = new Point(0, 579);
		pictureBox_6.Location = location5;
		pictureBox_6.Name = Class16.smethod_0(1648976974);
		Size size5 = new Size(854, 3);
		pictureBox_6.Size = size5;
		pictureBox_6.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_6.TabIndex = 6;
		pictureBox_6.TabStop = false;
		pictureBox_7.BackgroundImageLayout = ImageLayout.None;
		pictureBox_7.Dock = DockStyle.Right;
		pictureBox_7.Image = Resources.pictureBox5;
		Point location6 = new Point(851, 3);
		pictureBox_7.Location = location6;
		pictureBox_7.Name = Class16.smethod_0(1648976337);
		Size size6 = new Size(3, 576);
		pictureBox_7.Size = size6;
		pictureBox_7.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox_7.TabIndex = 7;
		pictureBox_7.TabStop = false;
		pictureBox_8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox_8.Image = Resources.pictureBox6;
		Point location7 = new Point(850, 0);
		pictureBox_8.Location = location7;
		pictureBox_8.Name = Class16.smethod_0(1648976355);
		Size size7 = new Size(3, 3);
		pictureBox_8.Size = size7;
		pictureBox_8.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_8.TabIndex = 8;
		pictureBox_8.TabStop = false;
		pictureBox_9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		pictureBox_9.Image = Resources.pictureBox7;
		Point location8 = new Point(850, 579);
		pictureBox_9.Location = location8;
		pictureBox_9.Name = Class16.smethod_0(1648976381);
		Size size8 = new Size(3, 3);
		pictureBox_9.Size = size8;
		pictureBox_9.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_9.TabIndex = 9;
		pictureBox_9.TabStop = false;
		pictureBox_10.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		pictureBox_10.Image = Resources.pictureBox8;
		Point location9 = new Point(0, 579);
		pictureBox_10.Location = location9;
		pictureBox_10.Name = Class16.smethod_0(1648979471);
		Size size9 = new Size(3, 3);
		pictureBox_10.Size = size9;
		pictureBox_10.SizeMode = PictureBoxSizeMode.AutoSize;
		pictureBox_10.TabIndex = 10;
		pictureBox_10.TabStop = false;
		timer_0.Interval = 5000;
		timer_0.Tick += timer_0_Tick;
		timer_2.Enabled = true;
		timer_2.Interval = 500;
		timer_2.Tick += timer_2_Tick;
		timer_1.Enabled = true;
		timer_1.Interval = 20;
		timer_1.Tick += timer_1_Tick;
		label_1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Color transparent = Color.Transparent;
		label_1.BackColor = transparent;
		label_1.BorderStyle = BorderStyle.FixedSingle;
		label_1.Cursor = Cursors.Hand;
		label_1.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		Color foreColor = Color.FromArgb(239, 191, 72);
		label_1.ForeColor = foreColor;
		label_1.Image = Resources.lblPin;
		label_1.ImageAlign = ContentAlignment.MiddleLeft;
		Point location10 = new Point(815, 0);
		label_1.Location = location10;
		label_1.Name = Class16.smethod_0(1648979481);
		Size size10 = new Size(38, 21);
		label_1.Size = size10;
		label_1.TabIndex = 54;
		label_1.Text = Class16.smethod_0(1648979502);
		label_1.TextAlign = ContentAlignment.MiddleRight;
		label_1.Visible = false;
		label_1.Click += label_1_Click;
		pictureBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		pictureBox_0.Image = Resources.picExit;
		Point location11 = new Point(835, 4);
		pictureBox_0.Location = location11;
		pictureBox_0.Name = Class16.smethod_0(1648988021);
		Size size11 = new Size(16, 16);
		pictureBox_0.Size = size11;
		pictureBox_0.TabIndex = 53;
		pictureBox_0.TabStop = false;
		pictureBox_0.Visible = false;
		pictureBox_1.Image = Resources.picExit_mousemove;
		Point location12 = new Point(559, 9);
		pictureBox_1.Location = location12;
		pictureBox_1.Name = Class16.smethod_0(1648987997);
		Size size12 = new Size(16, 16);
		pictureBox_1.Size = size12;
		pictureBox_1.TabIndex = 52;
		pictureBox_1.TabStop = false;
		pictureBox_1.Visible = false;
		pictureBox_2.Image = Resources.picExit_normal;
		Point location13 = new Point(537, 9);
		pictureBox_2.Location = location13;
		pictureBox_2.Name = Class16.smethod_0(1648987968);
		Size size13 = new Size(16, 16);
		pictureBox_2.Size = size13;
		pictureBox_2.TabIndex = 51;
		pictureBox_2.TabStop = false;
		pictureBox_2.Visible = false;
		Point location14 = new Point(0, 0);
		textBox_0.Location = location14;
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1648979511);
		Size size14 = new Size(263, 170);
		textBox_0.Size = size14;
		textBox_0.TabIndex = 55;
		textBox_0.Text = Class16.smethod_0(1648979524);
		textBox_0.Visible = false;
		label_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		Color transparent2 = Color.Transparent;
		label_0.BackColor = transparent2;
		label_0.BorderStyle = BorderStyle.FixedSingle;
		label_0.Cursor = Cursors.Hand;
		label_0.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		Color foreColor2 = Color.FromArgb(239, 191, 72);
		label_0.ForeColor = foreColor2;
		label_0.Image = Resources.lblDisable;
		label_0.ImageAlign = ContentAlignment.MiddleLeft;
		Point location15 = new Point(779, 0);
		label_0.Location = location15;
		label_0.Name = Class16.smethod_0(1648979731);
		Size size15 = new Size(38, 21);
		label_0.Size = size15;
		label_0.TabIndex = 56;
		label_0.Text = Class16.smethod_0(1648922976);
		label_0.TextAlign = ContentAlignment.MiddleRight;
		label_0.Visible = false;
		label_0.Click += label_0_Click;
		SizeF sizeF = new SizeF(7f, 13f);
		base.AutoScaleDimensions = sizeF;
		base.AutoScaleMode = AutoScaleMode.Font;
		Color backColor = Color.FromArgb(32, 32, 32);
		BackColor = backColor;
		Size clientSize = new Size(854, 582);
		base.ClientSize = clientSize;
		Label value = label_0;
		base.Controls.Add(value);
		TextBox value2 = textBox_0;
		base.Controls.Add(value2);
		PictureBox value3 = pictureBox_8;
		base.Controls.Add(value3);
		Label value4 = label_1;
		base.Controls.Add(value4);
		PictureBox value5 = pictureBox_0;
		base.Controls.Add(value5);
		PictureBox value6 = pictureBox_1;
		base.Controls.Add(value6);
		PictureBox value7 = pictureBox_2;
		base.Controls.Add(value7);
		PictureBox value8 = pictureBox_10;
		base.Controls.Add(value8);
		PictureBox value9 = pictureBox_9;
		base.Controls.Add(value9);
		PictureBox value10 = pictureBox_4;
		base.Controls.Add(value10);
		PictureBox value11 = pictureBox_7;
		base.Controls.Add(value11);
		PictureBox value12 = pictureBox_5;
		base.Controls.Add(value12);
		PictureBox value13 = pictureBox_3;
		base.Controls.Add(value13);
		PictureBox value14 = pictureBox_6;
		base.Controls.Add(value14);
		WebBrowser value15 = webBrowser_0;
		base.Controls.Add(value15);
		DoubleBuffered = true;
		Font = new Font(Class16.smethod_0(1648942905), 8f, FontStyle.Bold, GraphicsUnit.Point, 204);
		Color white = Color.White;
		ForeColor = white;
		base.FormBorderStyle = FormBorderStyle.None;
		base.Icon = Resources.ItemsToolTip_Icon;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648901278);
		base.Opacity = 0.95;
		base.ShowInTaskbar = false;
		base.StartPosition = FormStartPosition.Manual;
		Text = Class16.smethod_0(1648898209);
		Color transparencyKey = Color.FromArgb(15, 22, 29);
		base.TransparencyKey = transparencyKey;
		base.FormClosing += ItemsToolTip_FormClosing;
		base.Load += ItemsToolTip_Load;
		base.Shown += ItemsToolTip_Shown;
		base.VisibleChanged += ItemsToolTip_VisibleChanged;
		base.MouseEnter += ItemsToolTip_MouseEnter;
		((ISupportInitialize)pictureBox_3).EndInit();
		((ISupportInitialize)pictureBox_4).EndInit();
		((ISupportInitialize)pictureBox_5).EndInit();
		((ISupportInitialize)pictureBox_6).EndInit();
		((ISupportInitialize)pictureBox_7).EndInit();
		((ISupportInitialize)pictureBox_8).EndInit();
		((ISupportInitialize)pictureBox_9).EndInit();
		((ISupportInitialize)pictureBox_10).EndInit();
		((ISupportInitialize)pictureBox_0).EndInit();
		((ISupportInitialize)pictureBox_1).EndInit();
		((ISupportInitialize)pictureBox_2).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_2()
	{
		icontainer_0?.Dispose();
		GC.KeepAlive(this);
	}

	public void NormalShow(int ToolTipNewX, int ToolTipNewY)
	{
		base.Left = 5000;
		base.Top = 5000;
		ACE.RSGlobal.RSGlobal.SetWindowPos(base.Handle, new IntPtr(1), 0, 0, 0, 0, 19u);
		Show();
		Application.DoEvents();
		base.Left = ToolTipNewX;
		base.Top = ToolTipNewY;
		Application.DoEvents();
		Show();
	}

	public void PinWindow()
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
		}
		else
		{
			label_1.Visible = false;
			label_0.Visible = false;
			HintType = TOOLTIP_TYPE.PinnedWindow;
			webBrowser_0.IsWebBrowserContextMenuEnabled = true;
			InitWindow();
		}
	}

	public void RestoreOpacity()
	{
	}

	public void SetHtml(string html)
	{
		if (base.IsDisposed || base.Disposing || webBrowser_0 == null || webBrowser_0.IsDisposed || webBrowser_0.Disposing)
		{
			return;
		}
		try
		{
			HtmlElement htmlElement = webBrowser_0.Document?.Body;
			if (!(htmlElement == null))
			{
				htmlElement.InnerHtml = html ?? string.Empty;
				SubscribeLinkEvents();
			}
		}
		catch (ObjectDisposedException ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648979756));
		}
		catch (InvalidOperationException ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1648979756));
		}
	}

	public void SetOwnerHandle(IntPtr Handle)
	{
		OwnerControlHandle = Handle;
	}

	public void SetTextAndAutoSize(string Text)
	{
		if (string.IsNullOrWhiteSpace(Text) || base.IsDisposed || base.Disposing || webBrowser_0 == null || webBrowser_0.IsDisposed || webBrowser_0.Disposing)
		{
			return;
		}
		try
		{
			if (!webBrowser_0.IsHandleCreated)
			{
				return;
			}
			HtmlElement htmlElement = webBrowser_0.Document?.Body;
			if (htmlElement == null)
			{
				return;
			}
			IsOnlyImage = Text.StartsWith(Class16.smethod_0(1648979783));
			htmlElement.InnerHtml = Text;
			if (htmlElement.ScrollLeft > 0)
			{
				htmlElement.ScrollLeft = 0;
			}
			if (htmlElement.ScrollTop > 0)
			{
				htmlElement.ScrollTop = 0;
			}
			bool flag = Text.Contains(Class16.smethod_0(1648979898));
			int num = 0;
			int num2 = 0;
			if (flag)
			{
				MatchCollection matchCollection = Regex.Matches(Text, Class16.smethod_0(1648979935));
				if (matchCollection.Count > 0)
				{
					num = ACE.RSGlobal.RSGlobal.UIntParseFast(matchCollection[0].Groups[1].Value);
					num2 = ACE.RSGlobal.RSGlobal.UIntParseFast(matchCollection[0].Groups[2].Value);
					flag = matchCollection.Count <= 1 && flag;
				}
				else
				{
					flag = false;
				}
			}
			if (IsOnlyImage)
			{
				webBrowser_0.Height = num2 + 20;
				Size clientSize = new Size(num + 6, num2 + 3);
				base.ClientSize = clientSize;
				label_1.Visible = false;
				label_0.Visible = false;
			}
			else
			{
				Font font = Font;
				if (gfxMeasurer == null)
				{
					gfxMeasurer = webBrowser_0.CreateGraphics();
					double defaultLineHeight = (double)gfxMeasurer.MeasureString(Class16.smethod_0(1648979963), font).Height + 0.6;
					DefaultLineHeight = defaultLineHeight;
				}
				Text = Text.Replace(Class16.smethod_0(1648978947), Class16.smethod_0(1648942211));
				Text = Text.Replace(Class16.smethod_0(1648978960), Class16.smethod_0(1648942211));
				Text = Text.Replace(Class16.smethod_0(1648978983), Class16.smethod_0(1648978986));
				bool flag2 = Text.Contains(Class16.smethod_0(1648978995));
				Text = Regex.Replace(Text, Class16.smethod_0(1648979028), Class16.smethod_0(1648979101));
				Text = Regex.Replace(Text, Class16.smethod_0(1648979117), Class16.smethod_0(1648979138));
				Text = Regex.Replace(Text, Class16.smethod_0(1648979159), Class16.smethod_0(1648979188));
				Text = Regex.Replace(Text, Class16.smethod_0(1648979197), Class16.smethod_0(1648978986));
				Text = Regex.Replace(Text, Class16.smethod_0(1648941987), string.Empty);
				Text = Regex.Replace(Text, Class16.smethod_0(1648903120), Class16.smethod_0(1648941987));
				Text = Regex.Replace(Text, Class16.smethod_0(1648979212), string.Empty);
				Text = Text.Trim();
				string[] array = Text.Split('\n');
				double num3 = 0.0;
				int num4 = array.Length;
				int num5 = num4 - 1;
				int num6 = 0;
				int num7 = 0;
				int num8 = 0;
				if (0 < num4)
				{
					do
					{
						ref string reference = ref array[num8];
						bool flag3;
						if (flag3 = ACE.RSGlobal.RSGlobal.IsChinese(reference))
						{
							reference = ACE.RSGlobal.RSGlobal.ReplaceChineseLongChars(reference = reference.Replace(Class16.smethod_0(1648942211), Class16.smethod_0(1648979216)));
						}
						int num9 = 0;
						Match match = Regex.Match(reference, Class16.smethod_0(1648979226));
						if (match.Success)
						{
							num9 = ACE.RSGlobal.RSGlobal.UIntParseFast(match.Groups[1].Value);
							ACE.RSGlobal.RSGlobal.UIntParseFast(match.Groups[2].Value);
							reference = Regex.Replace(reference, Class16.smethod_0(1648979226), string.Empty);
						}
						string text = reference;
						SizeF sizeF = gfxMeasurer.MeasureString(text + Class16.smethod_0(1648979963), font);
						num3 = (double)sizeF.Height + 0.56 + num3;
						if ((flag3 && reference.Contains(Class16.smethod_0(1648979188))) || ACE.RSGlobal.RSGlobal.IsTallCharsExist(reference))
						{
							num3 += 1.0;
						}
						if ((double)reference.Length > (double)num6 / 1.3 || (num8 == num5 && flag))
						{
							int num10 = (int)Math.Ceiling(sizeF.Width);
							if (flag2)
							{
								num10 = reference.Length / 2 + num10;
							}
							if (flag3)
							{
								num10 = (int)((double)num10 * 1.04);
							}
							if (num8 == 0)
							{
								int num11 = (((nint)array.LongLength > 1) ? label_1.Width : 0);
								ADDITIONAL_PARAMS aParams = CommonStorage.AParams;
								num10 = ((aParams == null || !aParams.DisableAllHints) ? label_0.Width : 0) + num11 + num10;
							}
							if (num8 == num5 && flag)
							{
								num10 = num + num10 + 23;
							}
							else if (num9 > 0)
							{
								num10 = num9 + num10;
							}
							if (num10 > num7)
							{
								num7 = num10;
								num6 = reference.Length;
							}
						}
						num8++;
					}
					while (num8 < (nint)array.LongLength);
				}
				double num12 = 0.0;
				if (CustomWordsMultiplier != -1.0)
				{
					num12 = CustomWordsMultiplier;
				}
				int num13 = (flag2 ? 10 : 0);
				int num14 = (int)((double)num6 * num12) + num13 + num7;
				int num15 = (flag ? (num2 - 12) : 0) + (int)num3 + 5;
				if ((nint)array.LongLength == 1)
				{
					num15 = ((!flag) ? 22 : num15);
				}
				webBrowser_0.Height = num15 + 10;
				if (num14 > SystemInformation.VirtualScreen.Width - 200)
				{
					num14 = SystemInformation.VirtualScreen.Width - 200;
				}
				if (num15 > SystemInformation.VirtualScreen.Height - 100)
				{
					num15 = SystemInformation.VirtualScreen.Height - 100;
				}
				Size clientSize2 = new Size(num14 + 7, num15);
				base.ClientSize = clientSize2;
				byte b = (byte)((HintType != TOOLTIP_TYPE.PinnedWindow && (nint)array.LongLength > 1) ? 1u : 0u);
				label_1.Visible = b != 0;
				ADDITIONAL_PARAMS aParams2 = CommonStorage.AParams;
				if (aParams2 != null && aParams2.DisableAllHints)
				{
					label_0.Visible = false;
				}
				else
				{
					byte b2 = (byte)((HintType == TOOLTIP_TYPE.Fly && IsItemOrTaskToolTip) ? 1u : 0u);
					label_0.Visible = b2 != 0;
				}
				byte b3 = (byte)((HintType != TOOLTIP_TYPE.Fly || (nint)array.LongLength > 1) ? 1u : 0u);
				base.Enabled = b3 != 0;
			}
			if (HintType != TOOLTIP_TYPE.Fly)
			{
				SubscribeLinkEvents();
			}
		}
		catch (ObjectDisposedException ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648979260));
		}
		catch (InvalidOperationException ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1648979260));
		}
		catch (NullReferenceException ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1648979260));
		}
		catch (Exception ex4)
		{
			SentryHelper.CaptureException(ex4, Class16.smethod_0(1648979260));
		}
	}

	public void ShowImage(Control Owner, Bitmap image)
	{
		string text = Class16.smethod_0(1648979290);
		string text2 = Class16.smethod_0(1648979309);
		int num = image.Height + 1;
		string text3 = Class16.smethod_0(1648923968);
		string text4 = string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(Class16.smethod_0(1648979898) + image.Width, text3), num), text2), ACE.RSGlobal.RSGlobal.ImageToBase64(image)), text);
		ShowToolTip(Owner, text4);
	}

	public unsafe void ShowItemToolTip(IntPtr ControlHandle, ITEMPOS ip, string html, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool bSmooth)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (ip == null || CStorage == null || CStorage.IsElementsBusy || base.IsDisposed || base.Disposing || webBrowser_0 == null || webBrowser_0.IsDisposed || webBrowser_0.Disposing || eLC == null)
		{
			return;
		}
		bSmoothShow = bSmooth;
		OwnerControlHandle = ControlHandle;
		if (OwnerControlHandle != IntPtr.Zero)
		{
			tagPOINT tagPOINT_ = default(tagPOINT);
			ACE.RSGlobal.RSGlobal.GetCursorPos(&tagPOINT_);
			if (ACE.RSGlobal.RSGlobal.WindowFromPoint(tagPOINT_) != OwnerControlHandle)
			{
				GC.KeepAlive(this);
				return;
			}
		}
		OwnerControlHandle = ControlHandle;
		timer_0.Enabled = false;
		_ = Cursor;
		Point position = Cursor.Position;
		InitialCursorPosition = position;
		IsItemOrTaskToolTip = true;
		if (ACE.RSGlobal.RSGlobal.AntiRecurse_ShowToolTip_ItemsToolTip)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.AntiRecurse_ShowToolTip_ItemsToolTip = true;
		try
		{
			RestoreOpacity();
			LastText = null;
			if (!string.IsNullOrWhiteSpace(html) && !base.IsDisposed && !base.Disposing)
			{
				SetTextAndAutoSize(html);
			}
			if (!base.IsDisposed && !base.Disposing)
			{
				UpdatePos();
				string text = Class16.smethod_0(1648979337);
				Text = string.Concat(eLC.GetParsedItemName(ip) + text, eLC.GetItemID(ip));
				ShowedItemPos = ip;
				ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
				ShowedItemID = eListCollection2.getid(ip.int_0, ip.int_1);
				GC.KeepAlive(this);
			}
		}
		catch (ObjectDisposedException ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648979357));
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.AntiRecurse_ShowToolTip_ItemsToolTip = false;
		}
	}

	public void ShowItemToolTip(IntPtr ControlHandle, ITEMPOS ip, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool bSmooth)
	{
		if (ip == null || CStorage == null || CStorage.IsElementsBusy || base.IsDisposed || base.Disposing)
		{
			return;
		}
		if (eLC != null && eLC.Lists != null && eLC.IsItemExist(ip))
		{
			if (ACE.RSGlobal.RSGlobal.AntiRecurse_ShowItemToolTip_ItemsToolTip_ITEMPOS)
			{
				return;
			}
			ACE.RSGlobal.RSGlobal.AntiRecurse_ShowItemToolTip_ItemsToolTip_ITEMPOS = true;
			try
			{
				string html = null;
				ITEMPOS showedItemPos = ShowedItemPos;
				if (showedItemPos == null || !showedItemPos.Equals(ip))
				{
					html = eLC.GenerateHTMLPreview(ip, IsShopPrice, IsCleanHtml: false, bUnlimited: false);
				}
				ShowItemToolTip(ControlHandle, ip, html, IsShopPrice, bSmooth);
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648979357));
				ShowedItemPos = null;
				ShowedItemID = 0;
				IsItemOrTaskToolTip = false;
			}
			ACE.RSGlobal.RSGlobal.AntiRecurse_ShowItemToolTip_ItemsToolTip_ITEMPOS = false;
			GC.KeepAlive(this);
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public void ShowItemToolTip(Control OwnerControl, ITEMPOS ip, [MarshalAs(UnmanagedType.U1)] bool IsShopPrice, [MarshalAs(UnmanagedType.U1)] bool bSmooth)
	{
		if (OwnerControl != null && !OwnerControl.IsDisposed && !OwnerControl.Disposing)
		{
			IntPtr handle = OwnerControl.Handle;
			ShowItemToolTip(handle, ip, IsShopPrice, bSmooth);
			GC.KeepAlive(this);
		}
	}

	public void ShowItemToolTip(ITEMPOS ip)
	{
		ShowItemToolTip(OwnerControlHandle, ip, IsCleanHtml, bSmooth: false);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ShowItemToolTip(int ItemID, ItemType item_type)
	{
		if (eLC == null)
		{
			return false;
		}
		ITEMPOS iTEMPOS = ShowedItemPos;
		if (item_type != Prev_item_type || ItemID != ShowedItemID || iTEMPOS == null)
		{
			ACE.Elements.eListCollection.eListCollection eListCollection2 = eLC;
			iTEMPOS = eListCollection2.FindItemPos(eListCollection2.GetLists(item_type), ItemID);
			if (iTEMPOS == null)
			{
				GC.KeepAlive(this);
				return false;
			}
		}
		ShowItemToolTip(OwnerControlHandle, iTEMPOS, IsCleanHtml, bSmooth: true);
		ShowedItemID = ItemID;
		ShowedItemPos = iTEMPOS;
		Prev_item_type = item_type;
		return true;
	}

	private static IntPtr smethod_0(Control control_0)
	{
		if (control_0 != null && !control_0.IsDisposed)
		{
			try
			{
				return control_0.IsHandleCreated ? control_0.Handle : IntPtr.Zero;
			}
			catch (ObjectDisposedException)
			{
				return IntPtr.Zero;
			}
			catch (InvalidOperationException)
			{
				return IntPtr.Zero;
			}
		}
		return IntPtr.Zero;
	}

	public void ShowToolTip(IntPtr ControlHandle, string Text)
	{
		ShowToolTip(ControlHandle, Text, 0, -1.0, -1.0);
	}

	public void ShowToolTip(IntPtr ControlHandle, string Text, int TimeOut)
	{
		ShowToolTip(ControlHandle, Text, TimeOut, -1.0, -1.0);
	}

	public void ShowToolTip(Control Owner, string text, int TimeOut)
	{
		IntPtr controlHandle = smethod_0(Owner);
		ShowToolTip(controlHandle, text, TimeOut, -1.0, -1.0);
		GC.KeepAlive(this);
	}

	public void ShowToolTip(Control Owner, int str_id, int TimeOut)
	{
		IntPtr controlHandle = smethod_0(Owner);
		string text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_id, 0), null);
		ShowToolTip(controlHandle, text, TimeOut, -1.0, -1.0);
		GC.KeepAlive(this);
	}

	public void ShowToolTip(IntPtr ControlHandle, int str_id, int TimeOut)
	{
		string text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_id, 0), null);
		ShowToolTip(ControlHandle, text, TimeOut, -1.0, -1.0);
		GC.KeepAlive(this);
	}

	public void ShowToolTip(IntPtr ControlHandle, int str_id)
	{
		string text = TextStorage.TEXTS.GetText(TextStorage.TEXTS.ResolveLegacyMessageKey(str_id, 0), null);
		ShowToolTip(ControlHandle, text, 0, -1.0, -1.0);
		GC.KeepAlive(this);
	}

	public void ShowToolTip(Control Owner, string text)
	{
		OwnerControl = ((Owner == null || Owner.IsDisposed) ? null : Owner);
		IntPtr intPtr = smethod_0(Owner);
		if (intPtr == IntPtr.Zero)
		{
			intPtr = OwnerControlHandle;
		}
		ShowToolTip(intPtr, text, 0, -1.0, -1.0);
	}

	public void ShowToolTip(string text)
	{
		ShowToolTip(OwnerControlHandle, text, 0, -1.0, -1.0);
	}

	public void SmoothHide()
	{
		if (base.IsDisposed)
		{
			return;
		}
		if (bDisableSmooth)
		{
			Hide();
		}
		else
		{
			if (bHiding)
			{
				return;
			}
			bHiding = true;
			bShowing = false;
			double num = 0.85;
			while (true)
			{
				base.Opacity = num;
				ACE.RSGlobal.RSGlobal.Sleep(20u);
				Application.DoEvents();
				if (!bShowing && bHiding)
				{
					num -= 0.05;
					if (!(num >= 0.05))
					{
						Hide();
						timer_0.Enabled = false;
						bHiding = false;
						bShowing = false;
						break;
					}
					continue;
				}
				break;
			}
		}
	}

	public void SmoothShow()
	{
		if (base.IsDisposed || bShowing || base.Visible)
		{
			return;
		}
		if (bDisableSmooth)
		{
			Show();
			return;
		}
		bShowing = true;
		bHiding = false;
		base.Opacity = 0.05;
		Show();
		double num = 0.15;
		while (true)
		{
			base.Opacity = num;
			ACE.RSGlobal.RSGlobal.Sleep(20u);
			Application.DoEvents();
			if (bHiding || !bShowing)
			{
				break;
			}
			num += 0.1;
			if (!(num < 0.95))
			{
				bHiding = false;
				bShowing = false;
				timer_2_Tick(null, null);
				if (base.Visible)
				{
					UpdatePos();
				}
				break;
			}
		}
	}

	public void SubscribeLinkEvents()
	{
		int num = 0;
		if (0 < webBrowser_0.Document.Links.Count)
		{
			do
			{
				webBrowser_0.Document.Links[num].Click += method_4;
				webBrowser_0.Document.Links[num].MouseMove += method_6;
				webBrowser_0.Document.Links[num].MouseLeave += method_5;
				num++;
			}
			while (num < webBrowser_0.Document.Links.Count);
		}
		GC.KeepAlive(this);
	}

	public void UpdatePos()
	{
		_ = Cursor;
		int num = Cursor.Position.X + 20;
		_ = Cursor;
		int num2 = Cursor.Position.Y + 15;
		if (CustomLocation.X > 0)
		{
			num = CustomLocation.X;
			num2 = CustomLocation.Y;
		}
		bool flag = false;
		Rectangle virtualScreen = SystemInformation.VirtualScreen;
		if (num + base.Width > virtualScreen.Width)
		{
			num = SystemInformation.VirtualScreen.Width - base.Width;
			flag = true;
		}
		Rectangle virtualScreen2 = SystemInformation.VirtualScreen;
		if (num2 + base.Height > virtualScreen2.Height)
		{
			num2 = SystemInformation.VirtualScreen.Height - base.Height;
		}
		else if (!flag)
		{
			goto IL_0119;
		}
		_ = Cursor;
		if (Cursor.Position.X >= num)
		{
			_ = Cursor;
			if (Cursor.Position.Y >= num2)
			{
				_ = Cursor;
				num = Cursor.Position.X + 20;
				_ = Cursor;
				num2 = Cursor.Position.Y + 15;
			}
		}
		goto IL_0119;
		IL_0119:
		int shiftToLeft = ShiftToLeft;
		if (shiftToLeft > 0)
		{
			num -= shiftToLeft;
		}
		if (num != base.Left || num2 != base.Top)
		{
			base.Left = num;
			base.Top = num2;
		}
		if (!base.Visible)
		{
			if (!bDisableSmooth && bSmoothShow)
			{
				base.Opacity = 0.0;
				base.Left = num;
				base.Top = num2;
				SmoothShow();
			}
			else
			{
				NormalShow(num, num2);
			}
			ACE.RSGlobal.RSGlobal.SetWindowPos(base.Handle, new IntPtr(-1), 0, 0, 0, 0, 19u);
		}
		GC.KeepAlive(this);
	}

	protected override void WndProc(ref Message message_0)
	{
		if (message_0.Msg == 786 && base.Visible)
		{
			if (ACE.RSGlobal.RSGlobal.antirecurse_WndProc_ItemsToolTip)
			{
				return;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_WndProc_ItemsToolTip = true;
			switch (message_0.WParam.ToInt32())
			{
			case 1:
				if (ShowedItemPos != null)
				{
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST, ShowedItemPos.int_0, 0);
					IntPtr objectPointer = ACE.RSGlobal.RSGlobal.GetObjectPointer(new int[1] { ShowedItemPos.int_1 });
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS, new int[1] { ShowedItemPos.int_1 }.Length, objectPointer);
					Hide();
				}
				break;
			case 2:
				if (HintType != TOOLTIP_TYPE.PinnedWindow && label_1.Visible)
				{
					if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
					{
						object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
						TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
						GC.KeepAlive(this);
						return;
					}
					ClonePinnedWindow();
					Hide();
				}
				break;
			case 3:
				if (HintType == TOOLTIP_TYPE.Fly && label_0.Visible)
				{
					CommonStorage.AParams.DisableAllHints = true;
					Hide();
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_HINTS_DISABLED, 0, 0);
				}
				break;
			case 4:
				Hide();
				break;
			}
			ACE.RSGlobal.RSGlobal.antirecurse_WndProc_ItemsToolTip = false;
		}
		base.WndProc(ref message_0);
	}

	private void method_3()
	{
		CommonStorage.AParams.DisableAllHints = true;
		ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_ACE_HINTS_DISABLED, 0, 0);
		Hide();
	}

	private void ItemsToolTip_FormClosing(object sender, FormClosingEventArgs e)
	{
		DisableHotKeys(HideButtons: false);
	}

	private void ItemsToolTip_Load(object sender, EventArgs e)
	{
		try
		{
			if (webBrowser_0 == null || webBrowser_0.IsDisposed || webBrowser_0.Disposing || webBrowser_0.Document == null)
			{
				return;
			}
			webBrowser_0.Document.BackColor = SpecialColors.ItemDark;
			Color white = Color.White;
			webBrowser_0.Document.ForeColor = white;
		}
		catch (ObjectDisposedException)
		{
		}
		GC.KeepAlive(this);
	}

	private void ItemsToolTip_MouseEnter(object sender, EventArgs e)
	{
		if (HintType == TOOLTIP_TYPE.Fly)
		{
			SmoothHide();
		}
	}

	private void ItemsToolTip_Shown(object sender, EventArgs e)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (webBrowser_0 != null && !webBrowser_0.IsDisposed && !webBrowser_0.Disposing && webBrowser_0.Document != null && webBrowser_0.Document.DomDocument != null)
			{
				((IHTMLDocument2)webBrowser_0.Document.DomDocument).createStyleSheet(string.Empty, 0).cssText = textBox_0.Text;
			}
			InitWindow();
		}
		catch (ObjectDisposedException)
		{
		}
	}

	private void ItemsToolTip_VisibleChanged(object sender, EventArgs e)
	{
		if (HintType != TOOLTIP_TYPE.PinnedWindow)
		{
			if (base.Visible)
			{
				ACE.RSGlobal.RSGlobal.RegisterHotKey(base.Handle, HOTKEY_ID.Pin, 6u, 71u);
				ACE.RSGlobal.RSGlobal.RegisterHotKey(base.Handle, HOTKEY_ID.F1, 0u, 112u);
				ACE.RSGlobal.RSGlobal.RegisterHotKey(base.Handle, HOTKEY_ID.F2, 0u, 113u);
			}
			else
			{
				DisableHotKeys(HideButtons: false);
			}
			if (HintType == TOOLTIP_TYPE.Pinned)
			{
				if (base.Visible)
				{
					ACE.RSGlobal.RSGlobal.RegisterHotKey(base.Handle, HOTKEY_ID.Esc, 0u, 27u);
				}
				else
				{
					ACE.RSGlobal.RSGlobal.UnregisterHotKey(base.Handle, HOTKEY_ID.Esc);
				}
			}
		}
		GC.KeepAlive(this);
	}

	private void label_0_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private void label_1_Click(object sender, EventArgs e)
	{
		if (LICENSE_INFO.Info.LicenseType < LICENSE_TYPE.STANDART)
		{
			object[] vars = new object[1] { Enum.GetName(typeof(LICENSE_TYPE), LICENSE_TYPE.STANDART) };
			TextStorage.TEXTS.ShowMessage(913, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, vars);
			GC.KeepAlive(this);
		}
		else
		{
			ClonePinnedWindow();
			Hide();
		}
	}

	private unsafe void method_4(object sender, HtmlElementEventArgs e)
	{
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		if (Form.ActiveForm == null)
		{
			GC.KeepAlive(this);
			return;
		}
		HtmlElement htmlElement = (HtmlElement)sender;
		string name = htmlElement.Name;
		string attribute = htmlElement.GetAttribute(Class16.smethod_0(1648979384));
		char[] separator = new char[1] { '-' };
		int[] array = ACE.RSGlobal.RSGlobal.StringArray2IntArray(attribute.Substring(4).Split(separator));
		ITEMPOS iTEMPOS = null;
		if (name == Class16.smethod_0(1648979395) || name == Class16.smethod_0(1648979409))
		{
			iTEMPOS = new ITEMPOS(array[0], array[1]);
		}
		if (!(name == Class16.smethod_0(1648979395)))
		{
			if (!(name == Class16.smethod_0(1648979409)))
			{
				if (!(name == Class16.smethod_0(1648979426)))
				{
					if (!(name == Class16.smethod_0(1648979441)))
					{
						if (name == Class16.smethod_0(1648978438))
						{
							ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEM, array[0], 0);
						}
					}
					else
					{
						int taskID = array[0];
						CStorage.GoToTask(taskID, ReferenceSubType.NONE);
					}
				}
				else
				{
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_FIELD_SET_ITEM, array[0], array[1]);
					ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_FIELD_SET_FIELD, array[2], 0);
				}
			}
			else
			{
				tagPOINT tagPOINT_ = default(tagPOINT);
				ACE.RSGlobal.RSGlobal.GetCursorPos(&tagPOINT_);
				IntPtr controlHandle = ACE.RSGlobal.RSGlobal.WindowFromPoint(tagPOINT_);
				ItemsToolTip1.ShowItemToolTip(controlHandle, iTEMPOS, IsShopPrice: false, bSmooth: false);
			}
		}
		else
		{
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_LIST, iTEMPOS.int_0, 0);
			IntPtr objectPointer = ACE.RSGlobal.RSGlobal.GetObjectPointer(new int[1] { iTEMPOS.int_1 });
			ACE.RSGlobal.RSGlobal.SendMessage(ElementsWindow.Handle, ACE.RSGlobal.RSGlobal.WM_SELECT_ITEMS_SET_ITEMS, new int[1] { iTEMPOS.int_1 }.Length, objectPointer);
		}
		bCancel = true;
		if (HintType == TOOLTIP_TYPE.Pinned)
		{
			Hide();
		}
	}

	private void method_5(object sender, HtmlElementEventArgs e)
	{
		ItemsToolTip1.Hide();
		GC.KeepAlive(this);
	}

	private void method_6(object sender, HtmlElementEventArgs e)
	{
		if (HintType == TOOLTIP_TYPE.Fly)
		{
			Hide();
		}
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (HintType == TOOLTIP_TYPE.Fly && !IsItemOrTaskToolTip)
		{
			SmoothHide();
		}
		timer_0.Enabled = false;
		GC.KeepAlive(this);
	}

	private void timer_1_Tick(object sender, EventArgs e)
	{
	}

	private unsafe void timer_2_Tick(object sender, EventArgs e)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		if (!base.Visible)
		{
			return;
		}
		switch (HintType)
		{
		case TOOLTIP_TYPE.Pinned:
		{
			Control ownerControl = OwnerControl;
			if (ownerControl != null && !ownerControl.Focused)
			{
				IntPtr handle = base.Handle;
				if (ACE.RSGlobal.RSGlobal.GetForegroundWindow() != handle)
				{
					Hide();
				}
			}
			break;
		}
		case TOOLTIP_TYPE.Fly:
		{
			tagPOINT tagPOINT_ = default(tagPOINT);
			ACE.RSGlobal.RSGlobal.GetCursorPos(&tagPOINT_);
			IntPtr intPtr = ACE.RSGlobal.RSGlobal.WindowFromPoint(tagPOINT_);
			if (!(OwnerControlHandle != IntPtr.Zero) || !(intPtr != OwnerControlHandle))
			{
				if (!IsItemOrTaskToolTip)
				{
					break;
				}
				_ = Cursor;
				if (Math.Abs(Cursor.Position.Y - InitialCursorPosition.Y) <= 10)
				{
					break;
				}
			}
			if (base.Visible)
			{
				SmoothHide();
			}
			break;
		}
		}
	}

	private void webBrowser_0_Navigating(object sender, WebBrowserNavigatingEventArgs e)
	{
		if (bCancel)
		{
			e.Cancel = true;
			bCancel = false;
		}
	}

	public unsafe void ShowToolTip(IntPtr ControlHandle, string Text, int TimeOut, double LineHeight, double WordsMultiplier)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(Text))
		{
			GC.KeepAlive(this);
		}
		else if (!base.IsDisposed && !base.Disposing && webBrowser_0 != null && !webBrowser_0.IsDisposed && !webBrowser_0.Disposing)
		{
			if (HintType == TOOLTIP_TYPE.Fly)
			{
				OwnerControlHandle = ControlHandle;
				if (OwnerControlHandle != IntPtr.Zero)
				{
					tagPOINT tagPOINT_ = default(tagPOINT);
					ACE.RSGlobal.RSGlobal.GetCursorPos(&tagPOINT_);
					if (ACE.RSGlobal.RSGlobal.WindowFromPoint(tagPOINT_) != OwnerControlHandle)
					{
						GC.KeepAlive(this);
						return;
					}
				}
			}
			if (!ACE.RSGlobal.RSGlobal.AntiRecurse_ShowItemToolTip_ItemsToolTip)
			{
				ACE.RSGlobal.RSGlobal.AntiRecurse_ShowItemToolTip_ItemsToolTip = true;
				int num = ((!bDisableSmooth) ? 1 : 0);
				bSmoothShow = (byte)num != 0;
				RestoreOpacity();
				IsItemOrTaskToolTip = false;
				timer_0.Enabled = false;
				_ = Cursor;
				Point position = Cursor.Position;
				InitialCursorPosition = position;
				if (!Text.Contains(Class16.smethod_0(1648908417)) && (Text.Contains(Class16.smethod_0(1648941987)) || Text.Contains(Class16.smethod_0(1648904221)) || Text.Contains(Class16.smethod_0(1648935659))))
				{
					Text = ACE.RSGlobal.RSGlobal.ToHTML(Text, bCutLine: false);
				}
				if (LastText != Text)
				{
					CustomLineHeight = LineHeight;
					CustomWordsMultiplier = WordsMultiplier;
					string text = Class16.smethod_0(1648902286);
					SetTextAndAutoSize(string.Concat(Class16.smethod_0(1648978454) + Text, text));
					CustomLineHeight = -1.0;
					CustomWordsMultiplier = -1.0;
				}
				UpdatePos();
				if (TimeOut > 0)
				{
					timer_0.Interval = TimeOut;
					timer_0.Enabled = true;
				}
				ShowedItemPos = null;
				ShowedItemID = 0;
				LastText = Text;
				Text = (Text.Contains(Class16.smethod_0(1648978573)) ? Regex.Match(Text, Class16.smethod_0(1648978591)).Groups[1].ToString() : ((base.Width >= 150) ? Class16.smethod_0(1648898209) : Class16.smethod_0(1648978611)));
				ACE.RSGlobal.RSGlobal.AntiRecurse_ShowItemToolTip_ItemsToolTip = false;
			}
		}
		else
		{
			GC.KeepAlive(this);
		}
	}

	public void ShowToolTip(IntPtr ControlHandle, string Text, double LineHeight, double WordsMultiplier)
	{
		ShowToolTip(ControlHandle, Text, 0, LineHeight, WordsMultiplier);
	}
}
