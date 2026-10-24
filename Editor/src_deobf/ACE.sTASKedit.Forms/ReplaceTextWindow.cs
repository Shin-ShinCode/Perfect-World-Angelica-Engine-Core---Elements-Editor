using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;
using ACE.sTASKedit.Classes.Extensions;
using ACE.sTASKedit.Classes.GlobalProgramData;
using ACE.sTASKedit.MainEditor;
using ACE.sTASKedit.tasks;
using ACE.sTASKedit.tasks.tasks.data;

namespace ACE.sTASKedit.Forms;

public class ReplaceTextWindow : Form
{
	private ACE.sTASKedit.MainEditor.MainEditor mainEditor_0;

	private TreeNodeCollection treeNodeCollection_0;

	private IContainer icontainer_0;

	private RadioButton radioButton_0;

	private RadioButton radioButton_1;

	private RadioButton radioButton_2;

	private RadioButton radioButton_3;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private CheckBox checkBox_3;

	private CheckBox checkBox_4;

	private CheckBox checkBox_5;

	private CheckBox checkBox_6;

	private CheckBox checkBox_7;

	private CheckBox checkBox_8;

	private CheckBox checkBox_9;

	private Label label_0;

	private TextBox textBox_0;

	private Label label_1;

	private TextBox textBox_1;

	private Button button_0;

	private Button button_1;

	private CheckBox checkBox_10;

	private CheckBox checkBox_11;

	private CheckBox checkBox_12;

	public ReplaceTextWindow(ACE.sTASKedit.MainEditor.MainEditor MainWindow, TreeNodeCollection Nodes)
	{
		method_0();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		mainEditor_0 = MainWindow;
		treeNodeCollection_0 = Nodes;
		SetLocalization();
	}

	private void radioButton_0_Click(object sender, EventArgs e)
	{
		if (!radioButton_0.Checked)
		{
			radioButton_0.Checked = true;
			radioButton_1.Checked = false;
		}
	}

	private void radioButton_1_Click(object sender, EventArgs e)
	{
		if (!radioButton_1.Checked)
		{
			radioButton_1.Checked = true;
			radioButton_0.Checked = false;
		}
	}

	private void radioButton_2_Click(object sender, EventArgs e)
	{
		if (!radioButton_2.Checked)
		{
			radioButton_2.Checked = true;
			radioButton_3.Checked = false;
		}
	}

	private void radioButton_3_Click(object sender, EventArgs e)
	{
		if (!radioButton_3.Checked)
		{
			radioButton_3.Checked = true;
			radioButton_2.Checked = false;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		mainEditor_0.treeView_tasks.BeginBulkUpdate();
		for (int i = 0; i < GProD.Tasks.Length; i++)
		{
			method_1(GProD.Tasks[i], treeNodeCollection_0[i]);
		}
		mainEditor_0.treeView_tasks.EndBulkUpdate();
		mainEditor_0.select_task(null, null);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_0()
	{
		new ComponentResourceManager(typeof(ReplaceTextWindow));
		radioButton_0 = new RadioButton();
		radioButton_1 = new RadioButton();
		radioButton_2 = new RadioButton();
		radioButton_3 = new RadioButton();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		checkBox_3 = new CheckBox();
		checkBox_4 = new CheckBox();
		checkBox_5 = new CheckBox();
		checkBox_6 = new CheckBox();
		checkBox_7 = new CheckBox();
		checkBox_9 = new CheckBox();
		checkBox_8 = new CheckBox();
		label_0 = new Label();
		textBox_0 = new TextBox();
		label_1 = new Label();
		textBox_1 = new TextBox();
		button_0 = new Button();
		button_1 = new Button();
		checkBox_10 = new CheckBox();
		checkBox_11 = new CheckBox();
		checkBox_12 = new CheckBox();
		SuspendLayout();
		radioButton_0.AutoCheck = false;
		radioButton_0.AutoSize = true;
		radioButton_0.Location = new Point(12, 10);
		radioButton_0.Name = Class16.smethod_0(1649258827);
		radioButton_0.Size = new Size(36, 17);
		radioButton_0.TabIndex = 0;
		radioButton_0.TabStop = true;
		radioButton_0.Text = Class16.smethod_0(1648973883);
		radioButton_0.UseVisualStyleBackColor = true;
		radioButton_0.Click += radioButton_0_Click;
		radioButton_1.AutoCheck = false;
		radioButton_1.AutoSize = true;
		radioButton_1.Checked = true;
		radioButton_1.Location = new Point(244, 10);
		radioButton_1.Name = Class16.smethod_0(1649258865);
		radioButton_1.Size = new Size(61, 17);
		radioButton_1.TabIndex = 1;
		radioButton_1.TabStop = true;
		radioButton_1.Text = Class16.smethod_0(1649253096);
		radioButton_1.UseVisualStyleBackColor = true;
		radioButton_1.Click += radioButton_1_Click;
		radioButton_2.AutoCheck = false;
		radioButton_2.AutoSize = true;
		radioButton_2.Checked = true;
		radioButton_2.Location = new Point(12, 33);
		radioButton_2.Name = Class16.smethod_0(1649253117);
		radioButton_2.Size = new Size(96, 17);
		radioButton_2.TabIndex = 2;
		radioButton_2.TabStop = true;
		radioButton_2.Text = Class16.smethod_0(1649253139);
		radioButton_2.UseVisualStyleBackColor = true;
		radioButton_2.Click += radioButton_2_Click;
		radioButton_3.AutoCheck = false;
		radioButton_3.AutoSize = true;
		radioButton_3.Location = new Point(244, 33);
		radioButton_3.Name = Class16.smethod_0(1649253167);
		radioButton_3.Size = new Size(114, 17);
		radioButton_3.TabIndex = 3;
		radioButton_3.Text = Class16.smethod_0(1649253193);
		radioButton_3.UseVisualStyleBackColor = true;
		radioButton_3.Click += radioButton_3_Click;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(12, 56);
		checkBox_0.Name = Class16.smethod_0(1649253217);
		checkBox_0.Size = new Size(54, 17);
		checkBox_0.TabIndex = 4;
		checkBox_0.Text = Class16.smethod_0(1648936731);
		checkBox_0.UseVisualStyleBackColor = true;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(244, 56);
		checkBox_1.Name = Class16.smethod_0(1649253241);
		checkBox_1.Size = new Size(71, 17);
		checkBox_1.TabIndex = 5;
		checkBox_1.Text = Class16.smethod_0(1649253279);
		checkBox_1.UseVisualStyleBackColor = true;
		checkBox_2.AutoSize = true;
		checkBox_2.Location = new Point(12, 79);
		checkBox_2.Name = Class16.smethod_0(1649253295);
		checkBox_2.Size = new Size(75, 17);
		checkBox_2.TabIndex = 6;
		checkBox_2.Text = Class16.smethod_0(1649253314);
		checkBox_2.UseVisualStyleBackColor = true;
		checkBox_3.AutoSize = true;
		checkBox_3.Location = new Point(12, 125);
		checkBox_3.Name = Class16.smethod_0(1649253330);
		checkBox_3.Size = new Size(106, 17);
		checkBox_3.TabIndex = 10;
		checkBox_3.Text = Class16.smethod_0(1649253367);
		checkBox_3.UseVisualStyleBackColor = true;
		checkBox_4.AutoSize = true;
		checkBox_4.Location = new Point(244, 125);
		checkBox_4.Name = Class16.smethod_0(1649252365);
		checkBox_4.Size = new Size(65, 17);
		checkBox_4.TabIndex = 11;
		checkBox_4.Text = Class16.smethod_0(1649252396);
		checkBox_4.UseVisualStyleBackColor = true;
		checkBox_5.AutoSize = true;
		checkBox_5.Location = new Point(12, 148);
		checkBox_5.Name = Class16.smethod_0(1649252403);
		checkBox_5.Size = new Size(64, 17);
		checkBox_5.TabIndex = 12;
		checkBox_5.Text = Class16.smethod_0(1649252432);
		checkBox_5.UseVisualStyleBackColor = true;
		checkBox_6.AutoSize = true;
		checkBox_6.Location = new Point(244, 148);
		checkBox_6.Name = Class16.smethod_0(1649252454);
		checkBox_6.Size = new Size(64, 17);
		checkBox_6.TabIndex = 13;
		checkBox_6.Text = Class16.smethod_0(1649252475);
		checkBox_6.UseVisualStyleBackColor = true;
		checkBox_7.AutoSize = true;
		checkBox_7.Location = new Point(12, 171);
		checkBox_7.Name = Class16.smethod_0(1649252489);
		checkBox_7.Size = new Size(59, 17);
		checkBox_7.TabIndex = 14;
		checkBox_7.Text = Class16.smethod_0(1649252527);
		checkBox_7.UseVisualStyleBackColor = true;
		checkBox_9.AutoSize = true;
		checkBox_9.Location = new Point(244, 171);
		checkBox_9.Name = Class16.smethod_0(1649252541);
		checkBox_9.Size = new Size(71, 17);
		checkBox_9.TabIndex = 15;
		checkBox_9.Text = Class16.smethod_0(1649252568);
		checkBox_9.UseVisualStyleBackColor = true;
		checkBox_8.AutoSize = true;
		checkBox_8.Location = new Point(12, 194);
		checkBox_8.Name = Class16.smethod_0(1649252584);
		checkBox_8.Size = new Size(47, 17);
		checkBox_8.TabIndex = 16;
		checkBox_8.Text = Class16.smethod_0(1649023959);
		checkBox_8.UseVisualStyleBackColor = true;
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_0.AutoSize = true;
		label_0.Location = new Point(9, 224);
		label_0.Name = Class16.smethod_0(1648919238);
		label_0.Size = new Size(56, 13);
		label_0.TabIndex = 17;
		label_0.Text = Class16.smethod_0(1649252611);
		textBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_0.Location = new Point(112, 220);
		textBox_0.Multiline = true;
		textBox_0.Name = Class16.smethod_0(1649252636);
		textBox_0.ScrollBars = ScrollBars.Both;
		textBox_0.Size = new Size(350, 46);
		textBox_0.TabIndex = 18;
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.AutoSize = true;
		label_1.Location = new Point(9, 276);
		label_1.Name = Class16.smethod_0(1648912083);
		label_1.Size = new Size(62, 13);
		label_1.TabIndex = 19;
		label_1.Text = Class16.smethod_0(1649252651);
		textBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_1.Location = new Point(112, 272);
		textBox_1.Multiline = true;
		textBox_1.Name = Class16.smethod_0(1649252676);
		textBox_1.ScrollBars = ScrollBars.Both;
		textBox_1.Size = new Size(350, 46);
		textBox_1.TabIndex = 20;
		button_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_0.Location = new Point(11, 324);
		button_0.Name = Class16.smethod_0(1649262453);
		button_0.Size = new Size(219, 23);
		button_0.TabIndex = 21;
		button_0.Text = Class16.smethod_0(1648999325);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		button_1.Location = new Point(244, 324);
		button_1.Name = Class16.smethod_0(1649262492);
		button_1.Size = new Size(219, 23);
		button_1.TabIndex = 22;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		button_1.Click += button_1_Click;
		checkBox_10.AutoSize = true;
		checkBox_10.Location = new Point(244, 79);
		checkBox_10.Name = Class16.smethod_0(1649252691);
		checkBox_10.Size = new Size(111, 17);
		checkBox_10.TabIndex = 7;
		checkBox_10.Text = Class16.smethod_0(1649252721);
		checkBox_10.UseVisualStyleBackColor = true;
		checkBox_11.AutoSize = true;
		checkBox_11.Location = new Point(244, 102);
		checkBox_11.Name = Class16.smethod_0(1649252744);
		checkBox_11.Size = new Size(56, 17);
		checkBox_11.TabIndex = 9;
		checkBox_11.Text = Class16.smethod_0(1649146276);
		checkBox_11.UseVisualStyleBackColor = true;
		checkBox_12.AutoSize = true;
		checkBox_12.Location = new Point(12, 102);
		checkBox_12.Name = Class16.smethod_0(1649252774);
		checkBox_12.Size = new Size(110, 17);
		checkBox_12.TabIndex = 8;
		checkBox_12.Text = Class16.smethod_0(1649252805);
		checkBox_12.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = SystemColors.Window;
		base.ClientSize = new Size(474, 358);
		base.Controls.Add(checkBox_12);
		base.Controls.Add(checkBox_11);
		base.Controls.Add(checkBox_10);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_1);
		base.Controls.Add(label_1);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_0);
		base.Controls.Add(checkBox_8);
		base.Controls.Add(checkBox_9);
		base.Controls.Add(radioButton_3);
		base.Controls.Add(checkBox_7);
		base.Controls.Add(radioButton_2);
		base.Controls.Add(checkBox_6);
		base.Controls.Add(radioButton_1);
		base.Controls.Add(checkBox_5);
		base.Controls.Add(radioButton_0);
		base.Controls.Add(checkBox_4);
		base.Controls.Add(checkBox_0);
		base.Controls.Add(checkBox_3);
		base.Controls.Add(checkBox_1);
		base.Controls.Add(checkBox_2);
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		MaximumSize = new Size(490, 397);
		MinimumSize = new Size(490, 397);
		base.Name = Class16.smethod_0(1649252829);
		base.ShowIcon = false;
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1649252829);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_1(ATaskTempl ataskTempl_0, TreeNode treeNode_0)
	{
		string text = textBox_0.Text;
		string text2 = textBox_1.Text;
		text = text.ToLower();
		bool flag = true;
		if (radioButton_1.Checked && !treeNode_0.Checked)
		{
			flag = false;
		}
		if (flag)
		{
			if (checkBox_0.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.Name = text2;
						treeNode_0.Text = ataskTempl_0.m_ID + Class16.smethod_0(1648942627) + GlobalFunctions.ColorClean(ataskTempl_0.Name);
						treeNode_0.ForeColor = Extensions.GetColor(ataskTempl_0);
					}
					else
					{
						string name = ataskTempl_0.Name;
						name = name.ToLower();
						if (name.Contains(text))
						{
							ataskTempl_0.Name = ataskTempl_0.Name.Replace(text, text2);
							ataskTempl_0.Name = ataskTempl_0.Name.Replace(textBox_0.Text, text2);
							treeNode_0.Text = ataskTempl_0.m_ID + Class16.smethod_0(1648942627) + GlobalFunctions.ColorClean(ataskTempl_0.Name);
							treeNode_0.ForeColor = Extensions.GetColor(ataskTempl_0);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_1.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.Signature = text2;
					}
					else
					{
						string signature = ataskTempl_0.Signature;
						signature = signature.ToLower();
						if (signature.Contains(text))
						{
							ataskTempl_0.Signature = ataskTempl_0.Signature.Replace(text, text2);
							ataskTempl_0.Signature = ataskTempl_0.Signature.Replace(textBox_0.Text, text2);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_2.Checked)
			{
				for (int i = 0; i < ataskTempl_0.m_pTaskChar.Length; i++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.m_pTaskChar[i] = tasksConvert.UnicodeStringToShorts(text2, 64);
							continue;
						}
						string text3 = tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_pTaskChar[i]);
						text3 = text3.ToLower();
						if (text3.Contains(text))
						{
							ataskTempl_0.m_pTaskChar[i] = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_pTaskChar[i]).Replace(text, text2), 64);
							ataskTempl_0.m_pTaskChar[i] = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_pTaskChar[i]).Replace(textBox_0.Text, text2), 64);
						}
					}
					catch
					{
					}
				}
			}
			if (checkBox_10.Checked)
			{
				for (int j = 0; j < ataskTempl_0.PersonTaskChar.Length; j++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.PersonTaskChar[j] = tasksConvert.UnicodeStringToShorts(text2, 64);
							continue;
						}
						string text4 = tasksConvert.ShortsToUnicodeString(ataskTempl_0.PersonTaskChar[j]);
						text4 = text4.ToLower();
						if (text4.Contains(text))
						{
							ataskTempl_0.PersonTaskChar[j] = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.PersonTaskChar[j]).Replace(text, text2), 64);
							ataskTempl_0.PersonTaskChar[j] = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.PersonTaskChar[j]).Replace(textBox_0.Text, text2), 64);
						}
					}
					catch
					{
					}
				}
			}
			if (checkBox_12.Checked)
			{
				for (int k = 0; k < ataskTempl_0.HistoryTaskChar.Length; k++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.HistoryTaskChar[k] = tasksConvert.UnicodeStringToShorts(text2, 64);
							continue;
						}
						string text5 = tasksConvert.ShortsToUnicodeString(ataskTempl_0.HistoryTaskChar[k]);
						text5 = text5.ToLower();
						if (text5.Contains(text))
						{
							ataskTempl_0.HistoryTaskChar[k] = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.HistoryTaskChar[k]).Replace(text, text2), 64);
							ataskTempl_0.HistoryTaskChar[k] = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.HistoryTaskChar[k]).Replace(textBox_0.Text, text2), 64);
						}
					}
					catch
					{
					}
				}
			}
			if (checkBox_11.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.m_szShowDialogName = tasksConvert.GbkStringToShorts(text2, 20);
					}
					else
					{
						string text6 = tasksConvert.ShortsToGbkString(ataskTempl_0.m_szShowDialogName);
						text6 = text6.ToLower();
						if (text6.Contains(text))
						{
							ataskTempl_0.m_szShowDialogName = tasksConvert.GbkStringToShorts(tasksConvert.ShortsToGbkString(ataskTempl_0.m_szShowDialogName).Replace(text, text2), 20);
							ataskTempl_0.m_szShowDialogName = tasksConvert.GbkStringToShorts(tasksConvert.ShortsToGbkString(ataskTempl_0.m_szShowDialogName).Replace(textBox_0.Text, text2), 20);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_3.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.m_TaskEventName = tasksConvert.UnicodeStringToShorts(text2, 30);
					}
					else
					{
						string text7 = tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName);
						text7 = text7.ToLower();
						if (text7.Contains(text))
						{
							ataskTempl_0.m_TaskEventName = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName).Replace(text, text2), 30);
							ataskTempl_0.m_TaskEventName = tasksConvert.UnicodeStringToShorts(tasksConvert.ShortsToUnicodeString(ataskTempl_0.m_TaskEventName).Replace(textBox_0.Text, text2), 30);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_4.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.Descript = text2;
					}
					else
					{
						string descript = ataskTempl_0.Descript;
						descript = descript.ToLower();
						if (descript.Contains(text))
						{
							ataskTempl_0.Descript = ataskTempl_0.Descript.Replace(text, text2);
							ataskTempl_0.Descript = ataskTempl_0.Descript.Replace(textBox_0.Text, text2);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_5.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.OkText = text2;
					}
					else
					{
						string okText = ataskTempl_0.OkText;
						okText = okText.ToLower();
						if (okText.Contains(text))
						{
							ataskTempl_0.OkText = ataskTempl_0.OkText.Replace(text, text2);
							ataskTempl_0.OkText = ataskTempl_0.OkText.Replace(textBox_0.Text, text2);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_6.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.NoText = text2;
					}
					else
					{
						string noText = ataskTempl_0.NoText;
						noText = noText.ToLower();
						if (noText.Contains(text))
						{
							ataskTempl_0.NoText = ataskTempl_0.NoText.Replace(text, text2);
							ataskTempl_0.NoText = ataskTempl_0.NoText.Replace(textBox_0.Text, text2);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_7.Checked)
			{
				try
				{
					if (radioButton_2.Checked)
					{
						ataskTempl_0.Tribute = text2;
					}
					else
					{
						string tribute = ataskTempl_0.Tribute;
						tribute = tribute.ToLower();
						if (tribute.Contains(text))
						{
							ataskTempl_0.Tribute = ataskTempl_0.Tribute.Replace(text, text2);
							ataskTempl_0.Tribute = ataskTempl_0.Tribute.Replace(textBox_0.Text, text2);
						}
					}
				}
				catch
				{
				}
			}
			if (checkBox_9.Checked)
			{
				for (int l = 0; l < ataskTempl_0.m_DelvTaskTalk.windows.Length; l++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.m_DelvTaskTalk.windows[l].talktext = text2;
							continue;
						}
						string talktext = ataskTempl_0.m_DelvTaskTalk.windows[l].talktext;
						talktext = talktext.ToLower();
						if (talktext.Contains(text))
						{
							ataskTempl_0.m_DelvTaskTalk.windows[l].talktext = ataskTempl_0.m_DelvTaskTalk.windows[l].talktext.Replace(text, text2);
							ataskTempl_0.m_DelvTaskTalk.windows[l].talktext = ataskTempl_0.m_DelvTaskTalk.windows[l].talktext.Replace(textBox_0.Text, text2);
						}
					}
					catch
					{
					}
				}
				for (int m = 0; m < ataskTempl_0.m_UnqualifiedTaskTalk.windows.Length; m++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.m_UnqualifiedTaskTalk.windows[m].talktext = text2;
							continue;
						}
						string talktext2 = ataskTempl_0.m_UnqualifiedTaskTalk.windows[m].talktext;
						talktext2 = talktext2.ToLower();
						if (talktext2.Contains(text))
						{
							ataskTempl_0.m_UnqualifiedTaskTalk.windows[m].talktext = ataskTempl_0.m_UnqualifiedTaskTalk.windows[m].talktext.Replace(text, text2);
							ataskTempl_0.m_UnqualifiedTaskTalk.windows[m].talktext = ataskTempl_0.m_UnqualifiedTaskTalk.windows[m].talktext.Replace(textBox_0.Text, text2);
						}
					}
					catch
					{
					}
				}
				for (int n = 0; n < ataskTempl_0.m_DelvItemTalk.windows.Length; n++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.m_DelvItemTalk.windows[n].talktext = text2;
							continue;
						}
						string talktext3 = ataskTempl_0.m_DelvItemTalk.windows[n].talktext;
						talktext3 = talktext3.ToLower();
						if (talktext3.Contains(text))
						{
							ataskTempl_0.m_DelvItemTalk.windows[n].talktext = ataskTempl_0.m_DelvItemTalk.windows[n].talktext.Replace(text, text2);
							ataskTempl_0.m_DelvItemTalk.windows[n].talktext = ataskTempl_0.m_DelvItemTalk.windows[n].talktext.Replace(textBox_0.Text, text2);
						}
					}
					catch
					{
					}
				}
				for (int num = 0; num < ataskTempl_0.m_ExeTalk.windows.Length; num++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.m_ExeTalk.windows[num].talktext = text2;
							continue;
						}
						string talktext4 = ataskTempl_0.m_ExeTalk.windows[num].talktext;
						talktext4 = talktext4.ToLower();
						if (talktext4.Contains(text))
						{
							ataskTempl_0.m_ExeTalk.windows[num].talktext = ataskTempl_0.m_ExeTalk.windows[num].talktext.Replace(text, text2);
							ataskTempl_0.m_ExeTalk.windows[num].talktext = ataskTempl_0.m_ExeTalk.windows[num].talktext.Replace(textBox_0.Text, text2);
						}
					}
					catch
					{
					}
				}
				for (int num2 = 0; num2 < ataskTempl_0.m_AwardTalk.windows.Length; num2++)
				{
					try
					{
						if (radioButton_2.Checked)
						{
							ataskTempl_0.m_AwardTalk.windows[num2].talktext = text2;
							continue;
						}
						string talktext5 = ataskTempl_0.m_AwardTalk.windows[num2].talktext;
						talktext5 = talktext5.ToLower();
						if (talktext5.Contains(text))
						{
							ataskTempl_0.m_AwardTalk.windows[num2].talktext = ataskTempl_0.m_AwardTalk.windows[num2].talktext.Replace(text, text2);
							ataskTempl_0.m_AwardTalk.windows[num2].talktext = ataskTempl_0.m_AwardTalk.windows[num2].talktext.Replace(textBox_0.Text, text2);
						}
					}
					catch
					{
					}
				}
			}
			if (checkBox_8.Checked)
			{
				for (int num3 = 0; num3 < ataskTempl_0.m_DelvTaskTalk.windows.Length; num3++)
				{
					for (int num4 = 0; num4 < ataskTempl_0.m_DelvTaskTalk.windows[num3].options.Length; num4++)
					{
						try
						{
							if (radioButton_2.Checked)
							{
								ataskTempl_0.m_DelvTaskTalk.windows[num3].options[num4].optiontext = text2;
								continue;
							}
							string optiontext = ataskTempl_0.m_DelvTaskTalk.windows[num3].options[num4].optiontext;
							optiontext = optiontext.ToLower();
							if (optiontext.Contains(text))
							{
								ataskTempl_0.m_DelvTaskTalk.windows[num3].options[num4].optiontext = ataskTempl_0.m_DelvTaskTalk.windows[num3].options[num4].optiontext.Replace(text, text2);
								ataskTempl_0.m_DelvTaskTalk.windows[num3].options[num4].optiontext = ataskTempl_0.m_DelvTaskTalk.windows[num3].options[num4].optiontext.Replace(textBox_0.Text, text2);
							}
						}
						catch
						{
						}
					}
				}
				for (int num5 = 0; num5 < ataskTempl_0.m_UnqualifiedTaskTalk.windows.Length; num5++)
				{
					for (int num6 = 0; num6 < ataskTempl_0.m_UnqualifiedTaskTalk.windows[num5].options.Length; num6++)
					{
						try
						{
							if (radioButton_2.Checked)
							{
								ataskTempl_0.m_UnqualifiedTaskTalk.windows[num5].options[num6].optiontext = text2;
								continue;
							}
							string optiontext2 = ataskTempl_0.m_UnqualifiedTaskTalk.windows[num5].options[num6].optiontext;
							optiontext2 = optiontext2.ToLower();
							if (optiontext2.Contains(text))
							{
								ataskTempl_0.m_UnqualifiedTaskTalk.windows[num5].options[num6].optiontext = ataskTempl_0.m_UnqualifiedTaskTalk.windows[num5].options[num6].optiontext.Replace(text, text2);
								ataskTempl_0.m_UnqualifiedTaskTalk.windows[num5].options[num6].optiontext = ataskTempl_0.m_UnqualifiedTaskTalk.windows[num5].options[num6].optiontext.Replace(textBox_0.Text, text2);
							}
						}
						catch
						{
						}
					}
				}
				for (int num7 = 0; num7 < ataskTempl_0.m_DelvItemTalk.windows.Length; num7++)
				{
					for (int num8 = 0; num8 < ataskTempl_0.m_DelvItemTalk.windows[num7].options.Length; num8++)
					{
						try
						{
							if (radioButton_2.Checked)
							{
								ataskTempl_0.m_DelvItemTalk.windows[num7].options[num8].optiontext = text2;
								continue;
							}
							string optiontext3 = ataskTempl_0.m_DelvItemTalk.windows[num7].options[num8].optiontext;
							optiontext3 = optiontext3.ToLower();
							if (optiontext3.Contains(text))
							{
								ataskTempl_0.m_DelvItemTalk.windows[num7].options[num8].optiontext = ataskTempl_0.m_DelvItemTalk.windows[num7].options[num8].optiontext.Replace(text, text2);
								ataskTempl_0.m_DelvItemTalk.windows[num7].options[num8].optiontext = ataskTempl_0.m_DelvItemTalk.windows[num7].options[num8].optiontext.Replace(textBox_0.Text, text2);
							}
						}
						catch
						{
						}
					}
				}
				for (int num9 = 0; num9 < ataskTempl_0.m_ExeTalk.windows.Length; num9++)
				{
					for (int num10 = 0; num10 < ataskTempl_0.m_ExeTalk.windows[num9].options.Length; num10++)
					{
						try
						{
							if (radioButton_2.Checked)
							{
								ataskTempl_0.m_ExeTalk.windows[num9].options[num10].optiontext = text2;
								continue;
							}
							string optiontext4 = ataskTempl_0.m_ExeTalk.windows[num9].options[num10].optiontext;
							optiontext4 = optiontext4.ToLower();
							if (optiontext4.Contains(text))
							{
								ataskTempl_0.m_ExeTalk.windows[num9].options[num10].optiontext = ataskTempl_0.m_ExeTalk.windows[num9].options[num10].optiontext.Replace(text, text2);
								ataskTempl_0.m_ExeTalk.windows[num9].options[num10].optiontext = ataskTempl_0.m_ExeTalk.windows[num9].options[num10].optiontext.Replace(textBox_0.Text, text2);
							}
						}
						catch
						{
						}
					}
				}
				for (int num11 = 0; num11 < ataskTempl_0.m_AwardTalk.windows.Length; num11++)
				{
					for (int num12 = 0; num12 < ataskTempl_0.m_AwardTalk.windows[num11].options.Length; num12++)
					{
						try
						{
							if (radioButton_2.Checked)
							{
								ataskTempl_0.m_AwardTalk.windows[num11].options[num12].optiontext = text2;
								continue;
							}
							string optiontext5 = ataskTempl_0.m_AwardTalk.windows[num11].options[num12].optiontext;
							optiontext5 = optiontext5.ToLower();
							if (optiontext5.Contains(text))
							{
								ataskTempl_0.m_AwardTalk.windows[num11].options[num12].optiontext = ataskTempl_0.m_AwardTalk.windows[num11].options[num12].optiontext.Replace(text, text2);
								ataskTempl_0.m_AwardTalk.windows[num11].options[num12].optiontext = ataskTempl_0.m_AwardTalk.windows[num11].options[num12].optiontext.Replace(textBox_0.Text, text2);
							}
						}
						catch
						{
						}
					}
				}
			}
		}
		for (int num13 = 0; num13 < ataskTempl_0.pSub.Length; num13++)
		{
			method_1(ataskTempl_0.pSub[num13], treeNode_0.Nodes[num13]);
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		Close();
	}

	public void SetLocalization()
	{
		Text = GProD.TX(6112);
		radioButton_0.Text = GProD.TX(6056);
		radioButton_1.Text = GProD.TX(6057);
		radioButton_2.Text = GProD.TX(6058);
		radioButton_3.Text = GProD.TX(6059);
		checkBox_0.Text = GProD.TX(6113);
		checkBox_1.Text = GProD.TX(6114);
		checkBox_2.Text = GProD.TX(6115);
		checkBox_10.Text = GProD.TX(6188);
		checkBox_12.Text = GProD.TX(6191);
		checkBox_11.Text = GProD.TX(6189);
		checkBox_3.Text = GProD.TX(6116);
		checkBox_4.Text = GProD.TX(6117);
		checkBox_5.Text = GProD.TX(6118);
		checkBox_6.Text = GProD.TX(6119);
		checkBox_7.Text = GProD.TX(6120);
		checkBox_9.Text = GProD.TX(6121);
		checkBox_8.Text = GProD.TX(6122);
		label_0.Text = GProD.TX(6068);
		label_1.Text = GProD.TX(6069);
		button_0.Text = GProD.TX(6070);
		button_1.Text = GProD.TX(6002);
	}
}
