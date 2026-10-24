using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.Protectors;

public class VMProtectorWindow : Form
{
	private sealed class Class358
	{
		public VMProtectorWindow vmprotectorWindow_0;

		public string string_0;

		public Color? nullable_0;

		internal void method_0()
		{
			vmprotectorWindow_0.method_2(string_0, nullable_0);
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct110 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public VMProtectorWindow vmprotectorWindow_0;

		public string string_0;

		public string string_1;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			VMProtectorWindow vMProtectorWindow = vmprotectorWindow_0;
			try
			{
				if (num != 0)
				{
					vMProtectorWindow.bool_0 = true;
					vMProtectorWindow.method_0();
					vMProtectorWindow.progressBar_0.Style = ProgressBarStyle.Marquee;
				}
				try
				{
					TaskAwaiter awaiter;
					if (num != 0)
					{
						vMProtectorWindow.process_0 = new Process
						{
							StartInfo = new ProcessStartInfo
							{
								FileName = string_0,
								Arguments = string_1,
								UseShellExecute = false,
								RedirectStandardOutput = true,
								RedirectStandardError = true,
								CreateNoWindow = true,
								WorkingDirectory = System.IO.Path.GetDirectoryName(string_0)
							},
							EnableRaisingEvents = true
						};
						vMProtectorWindow.process_0.OutputDataReceived += vMProtectorWindow.method_8;
						vMProtectorWindow.process_0.ErrorDataReceived += vMProtectorWindow.method_9;
						vMProtectorWindow.process_0.Start();
						vMProtectorWindow.process_0.BeginOutputReadLine();
						vMProtectorWindow.process_0.BeginErrorReadLine();
						awaiter = Task.Run((Action)vMProtectorWindow.method_10).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = 0;
							int_0 = 0;
							taskAwaiter_0 = awaiter;
							asyncVoidMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
							return;
						}
					}
					else
					{
						awaiter = taskAwaiter_0;
						taskAwaiter_0 = default(TaskAwaiter);
						num = -1;
						int_0 = -1;
					}
					awaiter.GetResult();
					int exitCode = vMProtectorWindow.process_0.ExitCode;
					if (exitCode == 0)
					{
						vMProtectorWindow.method_2(Class16.smethod_0(1649166107), null);
						vMProtectorWindow.method_2(Class16.smethod_0(1649166125), Color.LimeGreen);
						vMProtectorWindow.progressBar_0.Style = ProgressBarStyle.Continuous;
						vMProtectorWindow.progressBar_0.Value = 100;
					}
					else
					{
						vMProtectorWindow.method_2(Class16.smethod_0(1649166107), null);
						vMProtectorWindow.method_2(string.Format(Class16.smethod_0(1649166180), exitCode), Color.Red);
						vMProtectorWindow.progressBar_0.Style = ProgressBarStyle.Continuous;
						vMProtectorWindow.progressBar_0.Value = 0;
					}
				}
				catch (Exception ex)
				{
					vMProtectorWindow.method_2(Class16.smethod_0(1649166236) + ex.Message, Color.Red);
					vMProtectorWindow.progressBar_0.Style = ProgressBarStyle.Continuous;
				}
				finally
				{
					if (num < 0)
					{
						vMProtectorWindow.bool_0 = false;
						vMProtectorWindow.process_0?.Dispose();
						vMProtectorWindow.process_0 = null;
						vMProtectorWindow.method_0();
					}
				}
			}
			catch (Exception exception)
			{
				int_0 = -2;
				asyncVoidMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			asyncVoidMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncVoidMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public CommonStorage CStorage;

	public Form ElementsWindow;

	private Process process_0;

	private bool bool_0;

	private IContainer icontainer_0;

	private ToolTip toolTip_0;

	private GroupBox groupBox_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private Label label_1;

	private TextBox textBox_1;

	private Button button_1;

	private GroupBox groupBox_1;

	private Label label_2;

	private TextBox textBox_2;

	private Button button_2;

	private Label label_3;

	private TextBox textBox_3;

	private Button button_3;

	private Label label_4;

	private TextBox textBox_4;

	private Button button_4;

	private Label label_5;

	private TextBox textBox_5;

	private Label label_6;

	private DateTimePicker dateTimePicker_0;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private GroupBox groupBox_2;

	private RichTextBox richTextBox_0;

	private ProgressBar progressBar_0;

	private Button button_5;

	private Button button_6;

	public VMProtectorWindow(CommonStorage cStorage, Form elementsWindow)
	{
		method_3();
		CStorage = cStorage;
		ElementsWindow = elementsWindow;
		ToolTip toolTip = toolTip_0;
		TextStorage.TEXTS.SetFormLanguage(this, toolTip);
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
		dateTimePicker_0.Value = DateTime.Now;
		checkBox_0.Checked = false;
		dateTimePicker_0.Enabled = false;
		method_0();
	}

	protected override void OnHandleCreated(EventArgs eventArgs_0)
	{
		base.OnHandleCreated(eventArgs_0);
		TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = Class16.smethod_0(1649166256),
			Filter = Class16.smethod_0(1649166294)
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			textBox_0.Text = openFileDialog.FileName;
			if (string.IsNullOrWhiteSpace(textBox_1.Text))
			{
				string directoryName = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
				string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
				string extension = System.IO.Path.GetExtension(openFileDialog.FileName);
				textBox_1.Text = System.IO.Path.Combine(directoryName, fileNameWithoutExtension + Class16.smethod_0(1649165319) + extension);
			}
			method_0();
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		using SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			Title = Class16.smethod_0(1649165328),
			Filter = Class16.smethod_0(1649166294)
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			textBox_1.Text = saveFileDialog.FileName;
			method_0();
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = Class16.smethod_0(1649165353),
			Filter = Class16.smethod_0(1649165397)
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			textBox_2.Text = openFileDialog.FileName;
		}
	}

	private void button_3_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = Class16.smethod_0(1649165427),
			Filter = Class16.smethod_0(1649165460)
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			textBox_3.Text = openFileDialog.FileName;
		}
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = Class16.smethod_0(1649165497),
			Filter = Class16.smethod_0(1649165536)
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			textBox_4.Text = openFileDialog.FileName;
		}
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		dateTimePicker_0.Enabled = checkBox_0.Checked;
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		method_0();
	}

	private void method_0()
	{
		button_5.Enabled = !bool_0 && !string.IsNullOrWhiteSpace(textBox_0.Text) && File.Exists(textBox_0.Text);
		button_6.Enabled = bool_0;
	}

	protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
	{
		if (bool_0)
		{
			DialogResult dialogResult = MessageBox.Show(Class16.smethod_0(1649165564), Class16.smethod_0(1649165615), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
			if (dialogResult == DialogResult.No)
			{
				formClosingEventArgs_0.Cancel = true;
				return;
			}
			method_7();
		}
		base.OnFormClosing(formClosingEventArgs_0);
	}

	private void method_1()
	{
		richTextBox_0.Clear();
		progressBar_0.Value = 0;
	}

	private void method_2(string string_0, Color? nullable_0)
	{
		Class358 @class = new Class358();
		@class.vmprotectorWindow_0 = this;
		@class.string_0 = string_0;
		@class.nullable_0 = nullable_0;
		if (base.InvokeRequired)
		{
			Invoke(new Action(@class.method_0));
			return;
		}
		richTextBox_0.SelectionStart = richTextBox_0.TextLength;
		richTextBox_0.SelectionLength = 0;
		richTextBox_0.SelectionColor = @class.nullable_0 ?? richTextBox_0.ForeColor;
		richTextBox_0.AppendText(@class.string_0 + Environment.NewLine);
		richTextBox_0.ScrollToCaret();
	}

	private void method_3()
	{
		icontainer_0 = new Container();
		toolTip_0 = new ToolTip(icontainer_0);
		groupBox_0 = new GroupBox();
		label_0 = new Label();
		textBox_0 = new TextBox();
		button_0 = new Button();
		label_1 = new Label();
		textBox_1 = new TextBox();
		button_1 = new Button();
		groupBox_1 = new GroupBox();
		label_2 = new Label();
		textBox_2 = new TextBox();
		button_2 = new Button();
		label_3 = new Label();
		textBox_3 = new TextBox();
		button_3 = new Button();
		label_4 = new Label();
		textBox_4 = new TextBox();
		button_4 = new Button();
		label_5 = new Label();
		textBox_5 = new TextBox();
		label_6 = new Label();
		dateTimePicker_0 = new DateTimePicker();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		groupBox_2 = new GroupBox();
		richTextBox_0 = new RichTextBox();
		progressBar_0 = new ProgressBar();
		button_5 = new Button();
		button_6 = new Button();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		groupBox_2.SuspendLayout();
		SuspendLayout();
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Location = new Point(12, 12);
		groupBox_0.Name = Class16.smethod_0(1649165625);
		groupBox_0.Size = new Size(710, 85);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1649165654);
		label_0.AutoSize = true;
		label_0.Location = new Point(6, 25);
		label_0.Name = Class16.smethod_0(1649165667);
		label_0.Size = new Size(60, 15);
		label_0.Text = Class16.smethod_0(1649165694);
		textBox_0.Location = new Point(100, 22);
		textBox_0.Name = Class16.smethod_0(1649165704);
		textBox_0.Size = new Size(520, 23);
		textBox_0.TabIndex = 1;
		textBox_0.TextChanged += textBox_0_TextChanged;
		button_0.Location = new Point(626, 21);
		button_0.Name = Class16.smethod_0(1649165723);
		button_0.Size = new Size(75, 25);
		button_0.TabIndex = 2;
		button_0.Text = Class16.smethod_0(1648978102);
		button_0.Click += button_0_Click;
		label_1.AutoSize = true;
		label_1.Location = new Point(6, 55);
		label_1.Name = Class16.smethod_0(1649165744);
		label_1.Size = new Size(70, 15);
		label_1.Text = Class16.smethod_0(1649165772);
		textBox_1.Location = new Point(100, 52);
		textBox_1.Name = Class16.smethod_0(1649165791);
		textBox_1.Size = new Size(520, 23);
		textBox_1.TabIndex = 3;
		button_1.Location = new Point(626, 51);
		button_1.Name = Class16.smethod_0(1649165803);
		button_1.Size = new Size(75, 25);
		button_1.TabIndex = 4;
		button_1.Text = Class16.smethod_0(1648978102);
		button_1.Click += button_1_Click;
		groupBox_1.Controls.Add(checkBox_1);
		groupBox_1.Controls.Add(checkBox_0);
		groupBox_1.Controls.Add(dateTimePicker_0);
		groupBox_1.Controls.Add(label_6);
		groupBox_1.Controls.Add(textBox_5);
		groupBox_1.Controls.Add(label_5);
		groupBox_1.Controls.Add(button_4);
		groupBox_1.Controls.Add(textBox_4);
		groupBox_1.Controls.Add(label_4);
		groupBox_1.Controls.Add(button_3);
		groupBox_1.Controls.Add(textBox_3);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Controls.Add(button_2);
		groupBox_1.Controls.Add(textBox_2);
		groupBox_1.Controls.Add(label_2);
		groupBox_1.Location = new Point(12, 103);
		groupBox_1.Name = Class16.smethod_0(1649164801);
		groupBox_1.Size = new Size(710, 200);
		groupBox_1.TabIndex = 1;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1649164819);
		label_2.AutoSize = true;
		label_2.Location = new Point(6, 25);
		label_2.Name = Class16.smethod_0(1649164856);
		label_2.Size = new Size(80, 15);
		label_2.Text = Class16.smethod_0(1649164885);
		textBox_2.Location = new Point(100, 22);
		textBox_2.Name = Class16.smethod_0(1649164899);
		textBox_2.Size = new Size(520, 23);
		textBox_2.TabIndex = 5;
		button_2.Location = new Point(626, 21);
		button_2.Name = Class16.smethod_0(1649164920);
		button_2.Size = new Size(75, 25);
		button_2.TabIndex = 6;
		button_2.Text = Class16.smethod_0(1648978102);
		button_2.Click += button_2_Click;
		label_3.AutoSize = true;
		label_3.Location = new Point(6, 55);
		label_3.Name = Class16.smethod_0(1649164951);
		label_3.Size = new Size(65, 15);
		label_3.Text = Class16.smethod_0(1649164963);
		textBox_3.Location = new Point(100, 52);
		textBox_3.Name = Class16.smethod_0(1649164990);
		textBox_3.Size = new Size(520, 23);
		textBox_3.TabIndex = 7;
		button_3.Location = new Point(626, 51);
		button_3.Name = Class16.smethod_0(1649165002);
		button_3.Size = new Size(75, 25);
		button_3.TabIndex = 8;
		button_3.Text = Class16.smethod_0(1648978102);
		button_3.Click += button_3_Click;
		label_4.AutoSize = true;
		label_4.Location = new Point(6, 85);
		label_4.Name = Class16.smethod_0(1649165024);
		label_4.Size = new Size(85, 15);
		label_4.Text = Class16.smethod_0(1649165055);
		textBox_4.Location = new Point(100, 82);
		textBox_4.Name = Class16.smethod_0(1649165077);
		textBox_4.Size = new Size(520, 23);
		textBox_4.TabIndex = 9;
		button_4.Location = new Point(626, 81);
		button_4.Name = Class16.smethod_0(1649165100);
		button_4.Size = new Size(75, 25);
		button_4.TabIndex = 10;
		button_4.Text = Class16.smethod_0(1648978102);
		button_4.Click += button_4_Click;
		label_5.AutoSize = true;
		label_5.Location = new Point(6, 115);
		label_5.Name = Class16.smethod_0(1649165125);
		label_5.Size = new Size(70, 15);
		label_5.Text = Class16.smethod_0(1649165136);
		textBox_5.Location = new Point(100, 112);
		textBox_5.Name = Class16.smethod_0(1649165153);
		textBox_5.Size = new Size(300, 23);
		textBox_5.TabIndex = 11;
		label_6.AutoSize = true;
		label_6.Location = new Point(420, 115);
		label_6.Name = Class16.smethod_0(1649165180);
		label_6.Size = new Size(65, 15);
		label_6.Text = Class16.smethod_0(1649165199);
		dateTimePicker_0.Format = DateTimePickerFormat.Short;
		dateTimePicker_0.Location = new Point(530, 112);
		dateTimePicker_0.Name = Class16.smethod_0(1649165209);
		dateTimePicker_0.Size = new Size(120, 23);
		dateTimePicker_0.TabIndex = 12;
		dateTimePicker_0.Enabled = false;
		checkBox_0.AutoSize = true;
		checkBox_0.Location = new Point(490, 115);
		checkBox_0.Name = Class16.smethod_0(1649165236);
		checkBox_0.Size = new Size(15, 14);
		checkBox_0.TabIndex = 13;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		checkBox_1.AutoSize = true;
		checkBox_1.Location = new Point(9, 145);
		checkBox_1.Name = Class16.smethod_0(1649165261);
		checkBox_1.Size = new Size(160, 19);
		checkBox_1.TabIndex = 14;
		checkBox_1.Text = Class16.smethod_0(1649165287);
		groupBox_2.Controls.Add(richTextBox_0);
		groupBox_2.Controls.Add(progressBar_0);
		groupBox_2.Location = new Point(12, 309);
		groupBox_2.Name = Class16.smethod_0(1649164294);
		groupBox_2.Size = new Size(710, 230);
		groupBox_2.TabIndex = 2;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1649164310);
		richTextBox_0.BackColor = Color.FromArgb(30, 30, 30);
		richTextBox_0.ForeColor = Color.White;
		richTextBox_0.Font = new Font(Class16.smethod_0(1648929975), 9f);
		richTextBox_0.Location = new Point(6, 22);
		richTextBox_0.Name = Class16.smethod_0(1649164327);
		richTextBox_0.ReadOnly = true;
		richTextBox_0.Size = new Size(698, 175);
		richTextBox_0.TabIndex = 0;
		richTextBox_0.Text = string.Empty;
		progressBar_0.Location = new Point(6, 203);
		progressBar_0.Name = Class16.smethod_0(1649032508);
		progressBar_0.Size = new Size(698, 20);
		progressBar_0.TabIndex = 1;
		button_5.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
		button_5.Location = new Point(12, 545);
		button_5.Name = Class16.smethod_0(1649164340);
		button_5.Size = new Size(350, 38);
		button_5.TabIndex = 3;
		button_5.Text = Class16.smethod_0(1649164357);
		button_5.Enabled = false;
		button_5.Click += button_5_Click;
		button_6.Location = new Point(372, 545);
		button_6.Name = Class16.smethod_0(1649000848);
		button_6.Size = new Size(350, 38);
		button_6.TabIndex = 4;
		button_6.Text = Class16.smethod_0(1648941799);
		button_6.Enabled = false;
		button_6.Click += button_6_Click;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(734, 595);
		base.Controls.Add(button_6);
		base.Controls.Add(button_5);
		base.Controls.Add(groupBox_2);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(groupBox_0);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MaximizeBox = false;
		base.MinimizeBox = true;
		base.Name = Class16.smethod_0(1649164363);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1649164387);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		groupBox_2.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
	}

	private void button_5_Click(object sender, EventArgs e)
	{
		string text = method_4();
		if (text == null)
		{
			MessageBox.Show(Class16.smethod_0(1649164416), Class16.smethod_0(1649165615), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			return;
		}
		method_1();
		method_2(Class16.smethod_0(1649164488) + text, null);
		method_2(Class16.smethod_0(1649164524) + textBox_0.Text, null);
		string text2 = method_5();
		if (text2 != null)
		{
			method_2(Class16.smethod_0(1649164544) + text2, null);
			method_2(Class16.smethod_0(1649166107), null);
			method_6(text, text2);
		}
	}

	private void button_6_Click(object sender, EventArgs e)
	{
		method_7();
	}

	private string method_4()
	{
		string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
		string[] array = new string[7]
		{
			System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649164576)),
			System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649164607)),
			System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649164650)),
			System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649164704)),
			System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649164772)),
			System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649167899)),
			System.IO.Path.Combine(baseDirectory, Class16.smethod_0(1649167962))
		};
		string[] array2 = array;
		int num = 0;
		string fullPath;
		while (true)
		{
			if (num < array2.Length)
			{
				string path = array2[num];
				fullPath = System.IO.Path.GetFullPath(path);
				if (File.Exists(fullPath))
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return fullPath;
	}

	private string method_5()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(Class16.smethod_0(1648904453) + textBox_0.Text + Class16.smethod_0(1648904453));
		if (!string.IsNullOrWhiteSpace(textBox_1.Text))
		{
			stringBuilder.Append(Class16.smethod_0(1649127941) + textBox_1.Text + Class16.smethod_0(1648904453));
		}
		if (!string.IsNullOrWhiteSpace(textBox_2.Text))
		{
			if (!File.Exists(textBox_2.Text))
			{
				MessageBox.Show(Class16.smethod_0(1649168036), Class16.smethod_0(1649165615), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null;
			}
			stringBuilder.Append(Class16.smethod_0(1649168058) + textBox_2.Text + Class16.smethod_0(1648904453));
		}
		if (!string.IsNullOrWhiteSpace(textBox_3.Text))
		{
			if (!File.Exists(textBox_3.Text))
			{
				MessageBox.Show(Class16.smethod_0(1649168079), Class16.smethod_0(1649165615), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return null;
			}
			stringBuilder.Append(Class16.smethod_0(1649168108) + textBox_3.Text + Class16.smethod_0(1648904453));
		}
		if (!string.IsNullOrWhiteSpace(textBox_4.Text))
		{
			if (!File.Exists(textBox_4.Text))
			{
				method_2(Class16.smethod_0(1649168113), Color.Orange);
				return null;
			}
			stringBuilder.Append(Class16.smethod_0(1649168167) + textBox_4.Text + Class16.smethod_0(1648904453));
		}
		if (!string.IsNullOrWhiteSpace(textBox_5.Text))
		{
			stringBuilder.Append(Class16.smethod_0(1649168180) + textBox_5.Text + Class16.smethod_0(1648904453));
		}
		if (checkBox_0.Checked)
		{
			stringBuilder.Append(string.Format(Class16.smethod_0(1649168185), dateTimePicker_0.Value));
		}
		if (checkBox_1.Checked)
		{
			stringBuilder.Append(Class16.smethod_0(1649168211));
		}
		return stringBuilder.ToString();
	}

	private async void method_6(string string_0, string string_1)
	{
		bool_0 = true;
		method_0();
		progressBar_0.Style = ProgressBarStyle.Marquee;
		try
		{
			process_0 = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = string_0,
					Arguments = string_1,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					WorkingDirectory = System.IO.Path.GetDirectoryName(string_0)
				},
				EnableRaisingEvents = true
			};
			process_0.OutputDataReceived += method_8;
			process_0.ErrorDataReceived += method_9;
			process_0.Start();
			process_0.BeginOutputReadLine();
			process_0.BeginErrorReadLine();
			await Task.Run((Action)method_10);
			int exitCode = process_0.ExitCode;
			if (exitCode == 0)
			{
				method_2(Class16.smethod_0(1649166107), null);
				method_2(Class16.smethod_0(1649166125), Color.LimeGreen);
				progressBar_0.Style = ProgressBarStyle.Continuous;
				progressBar_0.Value = 100;
			}
			else
			{
				method_2(Class16.smethod_0(1649166107), null);
				method_2(string.Format(Class16.smethod_0(1649166180), exitCode), Color.Red);
				progressBar_0.Style = ProgressBarStyle.Continuous;
				progressBar_0.Value = 0;
			}
		}
		catch (Exception ex)
		{
			method_2(Class16.smethod_0(1649166236) + ex.Message, Color.Red);
			progressBar_0.Style = ProgressBarStyle.Continuous;
		}
		finally
		{
			bool_0 = false;
			process_0?.Dispose();
			process_0 = null;
			method_0();
		}
	}

	private void method_7()
	{
		if (process_0 != null && !process_0.HasExited)
		{
			try
			{
				process_0.Kill();
				method_2(Class16.smethod_0(1649168230), Color.Orange);
			}
			catch
			{
			}
		}
	}

	private void method_8(object sender, DataReceivedEventArgs e)
	{
		if (e.Data != null)
		{
			method_2(e.Data, null);
		}
	}

	private void method_9(object sender, DataReceivedEventArgs e)
	{
		if (e.Data != null)
		{
			method_2(e.Data, Color.Red);
		}
	}

	private void method_10()
	{
		process_0.WaitForExit();
	}
}
