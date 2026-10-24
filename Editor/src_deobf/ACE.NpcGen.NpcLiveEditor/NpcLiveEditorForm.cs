using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.RSGlobal;

namespace ACE.NpcGen.NpcLiveEditor;

public class NpcLiveEditorForm : Form
{
	private sealed class Class292
	{
		private int int_0;

		private int int_1;

		private string string_0;

		public int method_0()
		{
			return int_0;
		}

		public void method_1(int int_2)
		{
			int_0 = int_2;
		}

		public int method_2()
		{
			return int_1;
		}

		public void method_3(int int_2)
		{
			int_1 = int_2;
		}

		public string method_4()
		{
			return string_0;
		}

		public void method_5(string string_1)
		{
			string_0 = string_1;
		}

		public override string ToString()
		{
			return string.Format(Class16.smethod_0(1649092392), method_2(), method_4());
		}
	}

	public delegate void InsertPositionDataHandler(float posX, float posY, float posZ, float rotX, float rotZ);

	private Client client_0;

	private bool bool_0;

	private float float_0;

	private int? nullable_0;

	private InsertPositionDataHandler insertPositionDataHandler_0;

	private IContainer icontainer_0;

	private Label label_0;

	private TrackBar trackBar_0;

	private ComboBox comboBox_0;

	private Label label_1;

	private Button button_0;

	private Label label_2;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private Label label_3;

	private TextBox textBox_2;

	private Label label_4;

	private TextBox textBox_3;

	private Label label_5;

	private TextBox textBox_4;

	private Label label_6;

	private TextBox textBox_5;

	private Label label_7;

	private NumericUpDown numericUpDown_0;

	private TrackBar trackBar_1;

	private TrackBar trackBar_2;

	private TrackBar trackBar_3;

	private Button button_1;

	private Button button_2;

	public event InsertPositionDataHandler OnInsertPositionData
	{
		[CompilerGenerated]
		add
		{
			InsertPositionDataHandler insertPositionDataHandler = insertPositionDataHandler_0;
			InsertPositionDataHandler insertPositionDataHandler2;
			do
			{
				insertPositionDataHandler2 = insertPositionDataHandler;
				InsertPositionDataHandler value2 = (InsertPositionDataHandler)Delegate.Combine(insertPositionDataHandler2, value);
				insertPositionDataHandler = Interlocked.CompareExchange(ref insertPositionDataHandler_0, value2, insertPositionDataHandler2);
			}
			while ((object)insertPositionDataHandler != insertPositionDataHandler2);
		}
		[CompilerGenerated]
		remove
		{
			InsertPositionDataHandler insertPositionDataHandler = insertPositionDataHandler_0;
			InsertPositionDataHandler insertPositionDataHandler2;
			do
			{
				insertPositionDataHandler2 = insertPositionDataHandler;
				InsertPositionDataHandler value2 = (InsertPositionDataHandler)Delegate.Remove(insertPositionDataHandler2, value);
				insertPositionDataHandler = Interlocked.CompareExchange(ref insertPositionDataHandler_0, value2, insertPositionDataHandler2);
			}
			while ((object)insertPositionDataHandler != insertPositionDataHandler2);
		}
	}

	public NpcLiveEditorForm(int? npcElementIdFilter = null)
	{
		method_3();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this, null);
		nullable_0 = npcElementIdFilter;
		numericUpDown_0.Minimum = 0m;
		numericUpDown_0.Maximum = 360m;
		numericUpDown_0.DecimalPlaces = 0;
		numericUpDown_0.Value = 0m;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		trackBar_0.Minimum = 0;
		trackBar_0.Maximum = 360;
		trackBar_0.SmallChange = 1;
		trackBar_0.LargeChange = 1;
		trackBar_0.TickFrequency = 1;
		trackBar_0.Value = 0;
		trackBar_0.ValueChanged += trackBar_0_ValueChanged;
		trackBar_1.ValueChanged += trackBar_3_ValueChanged;
		trackBar_2.ValueChanged += trackBar_3_ValueChanged;
		trackBar_3.ValueChanged += trackBar_3_ValueChanged;
		textBox_5.Leave += textBox_4_Leave;
		textBox_3.Leave += textBox_4_Leave;
		textBox_4.Leave += textBox_4_Leave;
		textBox_5.KeyDown += textBox_4_KeyDown;
		textBox_3.KeyDown += textBox_4_KeyDown;
		textBox_4.KeyDown += textBox_4_KeyDown;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		base.Load += NpcLiveEditorForm_Load;
	}

	private void NpcLiveEditorForm_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_NpcLiveEditorForm != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_NpcLiveEditorForm = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void NpcLiveEditorForm_Load(object sender, EventArgs e)
	{
		if (OffsetManager.SelectedOffsets == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649092410)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			Close();
			return;
		}
		if (OffsetManager.SelectedOffsets.World == 0)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649092442)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			Close();
			return;
		}
		Process process = method_0();
		if (process == null)
		{
			Close();
			return;
		}
		try
		{
			client_0 = new Client(process);
			method_1();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649092474));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649092521), Class16.smethod_0(1649092560)), ex.Message), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			Close();
		}
	}

	private Process method_0()
	{
		string[] array = new string[3]
		{
			Class16.smethod_0(1649099780),
			Class16.smethod_0(1649099795),
			Class16.smethod_0(1649099831)
		};
		string[] array2 = array;
		int num = 0;
		Process[] processesByName;
		while (true)
		{
			if (num < array2.Length)
			{
				string processName = array2[num];
				processesByName = Process.GetProcessesByName(processName);
				if (processesByName.Length != 0)
				{
					break;
				}
				num++;
				continue;
			}
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649099843)) + Class16.smethod_0(1649092605), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			return null;
		}
		return processesByName[0];
	}

	private void method_1()
	{
		comboBox_0.Items.Clear();
		try
		{
			int nPCCount = client_0.GetNPCCount();
			Text = string.Format(Class16.smethod_0(1649091649), client_0.GetProcessName(), nPCCount);
			if (nPCCount > 0 && nPCCount <= 10000)
			{
				int num = 0;
				int num2 = 0;
				for (int i = 0; i < nPCCount; i++)
				{
					try
					{
						int npcUid = client_0.GetNpcUid(i);
						string npcName = client_0.GetNpcName(i);
						if (npcUid == 0 && string.IsNullOrEmpty(npcName))
						{
							num2++;
							continue;
						}
						ComboBox.ObjectCollection items = comboBox_0.Items;
						Class292 @class = new Class292();
						@class.method_1(i);
						@class.method_3(npcUid);
						@class.method_5(npcName ?? Class16.smethod_0(1648936686));
						items.Add(@class);
						num++;
					}
					catch
					{
						num2++;
					}
				}
				if (comboBox_0.Items.Count > 0)
				{
					comboBox_0.SelectedIndex = 0;
					return;
				}
				string debugInfo = client_0.GetDebugInfo();
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649091755), Class16.smethod_0(1649091804)), nPCCount, num, num2, debugInfo), Class16.smethod_0(1649091857), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				string debugInfo2 = client_0.GetDebugInfo();
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649091689), Class16.smethod_0(1649091712)), nPCCount, debugInfo2), Class16.smethod_0(1649091738), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649091885));
			string debugInfo3 = client_0.GetDebugInfo();
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649091915), Class16.smethod_0(1649091959)), ex.Message, debugInfo3), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_2(int int_0)
	{
		try
		{
			float[] skinMatrix = client_0.GetSkinMatrix(int_0);
			float num = ((Math.Abs(skinMatrix[8]) < 1E-06f) ? 0f : skinMatrix[8]);
			float num2 = ((Math.Abs(skinMatrix[10]) < 1E-06f) ? 0f : skinMatrix[10]);
			textBox_0.Text = num.ToString(Class16.smethod_0(1649091998), CultureInfo.CurrentCulture);
			textBox_1.Text = num2.ToString(Class16.smethod_0(1649091998), CultureInfo.CurrentCulture);
			double num3 = Math.Atan2(0f - num, num2) * (180.0 / Math.PI);
			if (num3 < 0.0)
			{
				num3 += 360.0;
			}
			if (Math.Abs(num3 - 360.0) < 1E-06)
			{
				num3 = 0.0;
			}
			if (!trackBar_0.Focused && !numericUpDown_0.Focused)
			{
				bool_0 = true;
				numericUpDown_0.Value = (decimal)num3;
				trackBar_0.Value = (int)num3;
				bool_0 = false;
			}
			method_5(int_0);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649092007));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649092042), Class16.smethod_0(1649092092)), ex.Message), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_3()
	{
		new ComponentResourceManager(typeof(NpcLiveEditorForm));
		label_0 = new Label();
		trackBar_0 = new TrackBar();
		comboBox_0 = new ComboBox();
		label_1 = new Label();
		button_0 = new Button();
		label_2 = new Label();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		label_3 = new Label();
		textBox_2 = new TextBox();
		label_4 = new Label();
		textBox_3 = new TextBox();
		label_5 = new Label();
		textBox_4 = new TextBox();
		label_6 = new Label();
		textBox_5 = new TextBox();
		label_7 = new Label();
		numericUpDown_0 = new NumericUpDown();
		trackBar_1 = new TrackBar();
		trackBar_2 = new TrackBar();
		trackBar_3 = new TrackBar();
		button_1 = new Button();
		button_2 = new Button();
		((ISupportInitialize)trackBar_0).BeginInit();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)trackBar_1).BeginInit();
		((ISupportInitialize)trackBar_2).BeginInit();
		((ISupportInitialize)trackBar_3).BeginInit();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(12, 120);
		label_0.Name = Class16.smethod_0(1649091108);
		label_0.Size = new Size(50, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1649111021);
		trackBar_0.Location = new Point(68, 110);
		trackBar_0.Maximum = 360;
		trackBar_0.Name = Class16.smethod_0(1649091120);
		trackBar_0.Size = new Size(300, 45);
		trackBar_0.TabIndex = 1;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(50, 12);
		comboBox_0.Name = Class16.smethod_0(1649091151);
		comboBox_0.Size = new Size(237, 21);
		comboBox_0.TabIndex = 2;
		label_1.AutoSize = true;
		label_1.Location = new Point(12, 15);
		label_1.Name = Class16.smethod_0(1649091162);
		label_1.Size = new Size(32, 13);
		label_1.TabIndex = 3;
		label_1.Text = Class16.smethod_0(1649091178);
		button_0.Location = new Point(293, 10);
		button_0.Name = Class16.smethod_0(1649091197);
		button_0.Size = new Size(75, 23);
		button_0.TabIndex = 4;
		button_0.Text = Class16.smethod_0(1648991736);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		label_2.AutoSize = true;
		label_2.Location = new Point(12, 165);
		label_2.Name = Class16.smethod_0(1649091221);
		label_2.Size = new Size(37, 13);
		label_2.TabIndex = 5;
		label_2.Text = Class16.smethod_0(1649091234);
		textBox_0.Location = new Point(58, 162);
		textBox_0.Name = Class16.smethod_0(1649091255);
		textBox_0.ReadOnly = true;
		textBox_0.Size = new Size(100, 20);
		textBox_0.TabIndex = 6;
		textBox_1.Location = new Point(268, 162);
		textBox_1.Name = Class16.smethod_0(1649091278);
		textBox_1.ReadOnly = true;
		textBox_1.Size = new Size(100, 20);
		textBox_1.TabIndex = 7;
		label_3.AutoSize = true;
		label_3.Location = new Point(222, 165);
		label_3.Name = Class16.smethod_0(1649091301);
		label_3.Size = new Size(37, 13);
		label_3.TabIndex = 8;
		label_3.Text = Class16.smethod_0(1649091314);
		textBox_2.Location = new Point(58, 162);
		textBox_2.Name = Class16.smethod_0(1649091335);
		textBox_2.Size = new Size(100, 20);
		textBox_2.TabIndex = 9;
		textBox_2.Visible = false;
		label_4.AutoSize = true;
		label_4.Location = new Point(12, 165);
		label_4.Name = Class16.smethod_0(1649091358);
		label_4.Size = new Size(37, 13);
		label_4.TabIndex = 10;
		label_4.Text = Class16.smethod_0(1649091371);
		label_4.Visible = false;
		textBox_3.Location = new Point(163, 58);
		textBox_3.Name = Class16.smethod_0(1649091384);
		textBox_3.Size = new Size(100, 20);
		textBox_3.TabIndex = 11;
		label_5.AutoSize = true;
		label_5.Location = new Point(128, 61);
		label_5.Name = Class16.smethod_0(1649091402);
		label_5.Size = new Size(17, 13);
		label_5.TabIndex = 12;
		label_5.Text = Class16.smethod_0(1649013950);
		textBox_4.Location = new Point(268, 58);
		textBox_4.Name = Class16.smethod_0(1649091418);
		textBox_4.Size = new Size(100, 20);
		textBox_4.TabIndex = 13;
		label_6.AutoSize = true;
		label_6.Location = new Point(245, 61);
		label_6.Name = Class16.smethod_0(1649091444);
		label_6.Size = new Size(17, 13);
		label_6.TabIndex = 14;
		label_6.Text = Class16.smethod_0(1649111438);
		textBox_5.Location = new Point(50, 58);
		textBox_5.Name = Class16.smethod_0(1649091460);
		textBox_5.Size = new Size(75, 20);
		textBox_5.TabIndex = 15;
		label_7.AutoSize = true;
		label_7.Location = new Point(12, 61);
		label_7.Name = Class16.smethod_0(1649091478);
		label_7.Size = new Size(28, 13);
		label_7.TabIndex = 16;
		label_7.Text = Class16.smethod_0(1649091494);
		numericUpDown_0.Location = new Point(163, 162);
		numericUpDown_0.Maximum = new decimal(new int[4] { 360, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1649091497);
		numericUpDown_0.Size = new Size(53, 20);
		numericUpDown_0.TabIndex = 17;
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		trackBar_1.Location = new Point(12, 84);
		trackBar_1.Name = Class16.smethod_0(1649091527);
		trackBar_1.Size = new Size(120, 45);
		trackBar_1.TabIndex = 18;
		trackBar_2.Location = new Point(128, 84);
		trackBar_2.Name = Class16.smethod_0(1649091538);
		trackBar_2.Size = new Size(120, 45);
		trackBar_2.TabIndex = 19;
		trackBar_3.Location = new Point(248, 84);
		trackBar_3.Name = Class16.smethod_0(1649091565);
		trackBar_3.Size = new Size(120, 45);
		trackBar_3.TabIndex = 20;
		button_1.Location = new Point(12, 195);
		button_1.Name = Class16.smethod_0(1649091576);
		button_1.Size = new Size(170, 30);
		button_1.TabIndex = 21;
		button_1.Text = Class16.smethod_0(1649090571);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		button_2.Location = new Point(188, 195);
		button_2.Name = Class16.smethod_0(1649090594);
		button_2.Size = new Size(180, 30);
		button_2.TabIndex = 22;
		button_2.Text = Class16.smethod_0(1649090629);
		button_2.UseVisualStyleBackColor = true;
		button_2.Click += button_2_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(384, 236);
		base.Controls.Add(button_2);
		base.Controls.Add(button_1);
		base.Controls.Add(trackBar_3);
		base.Controls.Add(trackBar_2);
		base.Controls.Add(trackBar_1);
		base.Controls.Add(numericUpDown_0);
		base.Controls.Add(textBox_3);
		base.Controls.Add(label_5);
		base.Controls.Add(textBox_4);
		base.Controls.Add(label_6);
		base.Controls.Add(textBox_5);
		base.Controls.Add(label_7);
		base.Controls.Add(textBox_2);
		base.Controls.Add(label_4);
		base.Controls.Add(textBox_1);
		base.Controls.Add(label_3);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_2);
		base.Controls.Add(label_0);
		base.Controls.Add(trackBar_0);
		base.Controls.Add(comboBox_0);
		base.Controls.Add(label_1);
		base.Controls.Add(button_0);
		base.FormBorderStyle = FormBorderStyle.FixedSingle;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.Name = Class16.smethod_0(1649090661);
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649090685);
		base.Activated += NpcLiveEditorForm_Activated;
		((ISupportInitialize)trackBar_0).EndInit();
		((ISupportInitialize)numericUpDown_0).EndInit();
		((ISupportInitialize)trackBar_1).EndInit();
		((ISupportInitialize)trackBar_2).EndInit();
		((ISupportInitialize)trackBar_3).EndInit();
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0 && comboBox_0.SelectedIndex >= 0)
		{
			bool_0 = true;
			trackBar_0.Value = (int)numericUpDown_0.Value;
			int num = ((Class292)comboBox_0.SelectedItem).method_0();
			float angle = (float_0 = (float)numericUpDown_0.Value);
			client_0.RotateNPC(num, angle);
			method_2(num);
			bool_0 = false;
		}
	}

	private void trackBar_0_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0 && comboBox_0.SelectedIndex >= 0)
		{
			bool_0 = true;
			numericUpDown_0.Value = trackBar_0.Value;
			int num = ((Class292)comboBox_0.SelectedItem).method_0();
			float angle = (float_0 = trackBar_0.Value);
			client_0.RotateNPC(num, angle);
			method_2(num);
			bool_0 = false;
		}
	}

	private void trackBar_3_ValueChanged(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex >= 0)
		{
			int npcIndex = ((Class292)comboBox_0.SelectedItem).method_0();
			float num = (float)trackBar_1.Value / 10f;
			float float_ = (float)trackBar_2.Value / 10f;
			float float_2 = (float)trackBar_3.Value / 10f;
			client_0.UpdateNPCPosition(npcIndex, num, float_, float_2);
			textBox_5.Text = num.ToString(Class16.smethod_0(1649090699), CultureInfo.CurrentCulture);
			textBox_3.Text = float_.ToString(Class16.smethod_0(1649090699), CultureInfo.CurrentCulture);
			textBox_4.Text = float_2.ToString(Class16.smethod_0(1649090699), CultureInfo.CurrentCulture);
		}
	}

	private void textBox_4_Leave(object sender, EventArgs e)
	{
		method_4();
	}

	private void textBox_4_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			method_4();
			e.SuppressKeyPress = true;
		}
	}

	private void method_4()
	{
		if (comboBox_0.SelectedIndex >= 0)
		{
			int npcIndex = ((Class292)comboBox_0.SelectedItem).method_0();
			float result;
			bool flag = float.TryParse(textBox_5.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result) || float.TryParse(textBox_5.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
			float result2;
			bool flag2 = float.TryParse(textBox_3.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result2) || float.TryParse(textBox_3.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result2);
			float result3;
			bool flag3 = float.TryParse(textBox_4.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result3) || float.TryParse(textBox_4.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result3);
			if (flag && flag2 && flag3)
			{
				client_0.UpdateNPCPosition(npcIndex, result, result2, result3);
				trackBar_1.Value = (int)(result * 10f);
				trackBar_2.Value = (int)(result2 * 10f);
				trackBar_3.Value = (int)(result3 * 10f);
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649090716)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBox_0.SelectedIndex >= 0 && comboBox_0.SelectedItem is Class292 @class)
		{
			method_2(@class.method_0());
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_1();
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		float result;
		bool flag = float.TryParse(textBox_5.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result) || float.TryParse(textBox_5.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
		float result2;
		bool flag2 = float.TryParse(textBox_3.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result2) || float.TryParse(textBox_3.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result2);
		float result3;
		bool flag3 = float.TryParse(textBox_4.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result3) || float.TryParse(textBox_4.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result3);
		float result4;
		bool flag4 = float.TryParse(textBox_0.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result4) || float.TryParse(textBox_0.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result4);
		float result5;
		bool flag5 = float.TryParse(textBox_1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out result5) || float.TryParse(textBox_1.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out result5);
		if (flag && flag2 && flag3 && flag4 && flag5)
		{
			insertPositionDataHandler_0?.Invoke(result, result2, result3, result4, result5);
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649090738)), Class16.smethod_0(1649115628), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649090769)), Class16.smethod_0(1648934892), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		(float, float, float) hostPlayerPosition = client_0.GetHostPlayerPosition();
		(float, float, float) hostPlayerDirection = client_0.GetHostPlayerDirection();
		float num = (float)Math.Atan2(0f - hostPlayerDirection.Item1, hostPlayerDirection.Item3);
		float num2 = num * 180f / (float)Math.PI;
		if (num2 < 0f)
		{
			num2 += 360f;
		}
		if (comboBox_0.SelectedIndex >= 0)
		{
			int num3 = ((Class292)comboBox_0.SelectedItem).method_0();
			client_0.UpdateNPCPosition(num3, hostPlayerPosition.Item1, hostPlayerPosition.Item2, hostPlayerPosition.Item3);
			client_0.RotateNPC(num3, num2);
			method_2(num3);
		}
	}

	private void method_5(int int_0)
	{
		(float, float, float) tuple = client_0.GetNPCPosition(int_0);
		if (float.IsNaN(tuple.Item1) || float.IsInfinity(tuple.Item1) || float.IsNaN(tuple.Item2) || float.IsInfinity(tuple.Item2) || float.IsNaN(tuple.Item3) || float.IsInfinity(tuple.Item3))
		{
			tuple = (0f, 0f, 0f);
		}
		trackBar_1.ValueChanged -= trackBar_3_ValueChanged;
		trackBar_2.ValueChanged -= trackBar_3_ValueChanged;
		trackBar_3.ValueChanged -= trackBar_3_ValueChanged;
		trackBar_1.Minimum = (int)((tuple.Item1 - 100f) * 10f);
		trackBar_1.Maximum = (int)((tuple.Item1 + 100f) * 10f);
		trackBar_2.Minimum = (int)((tuple.Item2 - 100f) * 10f);
		trackBar_2.Maximum = (int)((tuple.Item2 + 100f) * 10f);
		trackBar_3.Minimum = (int)((tuple.Item3 - 100f) * 10f);
		trackBar_3.Maximum = (int)((tuple.Item3 + 100f) * 10f);
		trackBar_1.Value = Math.Min(trackBar_1.Maximum, Math.Max(trackBar_1.Minimum, (int)(tuple.Item1 * 10f)));
		trackBar_2.Value = Math.Min(trackBar_2.Maximum, Math.Max(trackBar_2.Minimum, (int)(tuple.Item2 * 10f)));
		trackBar_3.Value = Math.Min(trackBar_3.Maximum, Math.Max(trackBar_3.Minimum, (int)(tuple.Item3 * 10f)));
		textBox_5.Text = tuple.Item1.ToString(Class16.smethod_0(1649090699), CultureInfo.CurrentCulture);
		textBox_3.Text = tuple.Item2.ToString(Class16.smethod_0(1649090699), CultureInfo.CurrentCulture);
		textBox_4.Text = tuple.Item3.ToString(Class16.smethod_0(1649090699), CultureInfo.CurrentCulture);
		trackBar_1.ValueChanged += trackBar_3_ValueChanged;
		trackBar_2.ValueChanged += trackBar_3_ValueChanged;
		trackBar_3.ValueChanged += trackBar_3_ValueChanged;
	}
}
