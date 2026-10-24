using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using ACE.EcmEditor.Models;
using ACE.EcmEditor.Services;

namespace ACE.EcmEditor;

public class EcmExtractPckDialog : Form
{
	[StructLayout(LayoutKind.Auto)]
	private struct Struct52 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public EcmExtractPckDialog ecmExtractPckDialog_0;

		private TaskAwaiter<(int, int)> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			EcmExtractPckDialog ecmExtractPckDialog = ecmExtractPckDialog_0;
			try
			{
				if (num == 0)
				{
					goto IL_00b7;
				}
				if (ecmExtractPckDialog.ecmPckReader_0 != null && ecmExtractPckDialog.list_0.Count != 0)
				{
					if (!string.IsNullOrEmpty(ecmExtractPckDialog.textBox_1.Text))
					{
						ecmExtractPckDialog.button_3.Enabled = false;
						ecmExtractPckDialog.progressBar_0.Maximum = ecmExtractPckDialog.list_0.Count;
						ecmExtractPckDialog.progressBar_0.Value = 0;
						goto IL_00b7;
					}
					MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648993552), Class16.smethod_0(1648993576)), TextStorage.Msg(Class16.smethod_0(1648996854), Class16.smethod_0(1648999936)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				goto end_IL_000e;
				IL_00b7:
				try
				{
					TaskAwaiter<(int, int)> awaiter;
					if (num != 0)
					{
						awaiter = Task.Run((Func<(int, int)>)ecmExtractPckDialog.method_3).GetAwaiter();
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
						taskAwaiter_0 = default(TaskAwaiter<(int, int)>);
						num = -1;
						int_0 = -1;
					}
					(int, int) result = awaiter.GetResult();
					(int, int) tuple = result;
					ecmExtractPckDialog.method_0(ecmExtractPckDialog.textBox_1.Text);
					ecmExtractPckDialog.label_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648993614), Class16.smethod_0(1648993637)), tuple.Item1, tuple.Item2);
					ecmExtractPckDialog.progressBar_0.Value = ecmExtractPckDialog.progressBar_0.Maximum;
					if (tuple.Item1 > 0)
					{
						DialogResult dialogResult = MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648993667), Class16.smethod_0(1648993700)), TextStorage.Msg(Class16.smethod_0(1648996854), Class16.smethod_0(1648999936)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dialogResult == DialogResult.Yes)
						{
							ecmExtractPckDialog.DialogResult = DialogResult.OK;
							ecmExtractPckDialog.Close();
						}
					}
				}
				catch (Exception ex)
				{
					ecmExtractPckDialog.label_4.Text = Class16.smethod_0(1648935998) + ex.Message;
				}
				finally
				{
					if (num < 0)
					{
						ecmExtractPckDialog.button_3.Enabled = true;
					}
				}
				end_IL_000e:;
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

	private sealed class Class113
	{
		public int int_0;

		public int int_1;

		public EcmExtractPckDialog ecmExtractPckDialog_0;

		internal void method_0()
		{
			ecmExtractPckDialog_0.progressBar_0.Value = int_0;
			ecmExtractPckDialog_0.label_4.Text = string.Format(Class16.smethod_0(1648993543), int_0, int_1);
		}
	}

	private string string_0 = string.Empty;

	private int int_0;

	private EcmPckReader ecmPckReader_0;

	private List<EcmPckEntry> list_0 = new List<EcmPckEntry>();

	private IContainer icontainer_0;

	private GroupBox groupBox_0;

	private Label label_0;

	private TextBox textBox_0;

	private Button button_0;

	private Label label_1;

	private ComboBox comboBox_0;

	private Button button_1;

	private Label label_2;

	private TextBox textBox_1;

	private Button button_2;

	private GroupBox groupBox_1;

	private ListBox listBox_0;

	private Label label_3;

	private Label label_4;

	private ProgressBar progressBar_0;

	private Button button_3;

	private Button button_4;

	public string OutputDirectory
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public int VersionFilter
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public EcmExtractPckDialog()
	{
		method_1();
		comboBox_0.Items.Clear();
		comboBox_0.Items.Add(Class16.smethod_0(1648993714));
		foreach (EcmPckKey allKey in EcmPckKey.AllKeys)
		{
			comboBox_0.Items.Add(allKey.Name);
		}
		comboBox_0.SelectedIndex = 0;
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
	}

	private void method_0(string string_1)
	{
		string_0 = string_1;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_1()
	{
		groupBox_0 = new GroupBox();
		label_0 = new Label();
		textBox_0 = new TextBox();
		button_0 = new Button();
		label_1 = new Label();
		comboBox_0 = new ComboBox();
		button_1 = new Button();
		label_2 = new Label();
		textBox_1 = new TextBox();
		button_2 = new Button();
		groupBox_1 = new GroupBox();
		listBox_0 = new ListBox();
		label_3 = new Label();
		label_4 = new Label();
		progressBar_0 = new ProgressBar();
		button_3 = new Button();
		button_4 = new Button();
		groupBox_0.SuspendLayout();
		groupBox_1.SuspendLayout();
		SuspendLayout();
		groupBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(textBox_0);
		groupBox_0.Controls.Add(button_0);
		groupBox_0.Controls.Add(label_1);
		groupBox_0.Controls.Add(comboBox_0);
		groupBox_0.Controls.Add(button_1);
		groupBox_0.Controls.Add(label_2);
		groupBox_0.Controls.Add(textBox_1);
		groupBox_0.Controls.Add(button_2);
		groupBox_0.Location = new Point(12, 12);
		groupBox_0.Name = Class16.smethod_0(1648993740);
		groupBox_0.Padding = new Padding(12, 8, 12, 8);
		groupBox_0.Size = new Size(626, 140);
		groupBox_0.Text = Class16.smethod_0(1648993753);
		label_0.AutoSize = true;
		label_0.Location = new Point(16, 28);
		label_0.Name = Class16.smethod_0(1648993780);
		label_0.Size = new Size(55, 15);
		label_0.Text = Class16.smethod_0(1648992773);
		textBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.Location = new Point(86, 25);
		textBox_0.Name = Class16.smethod_0(1648992789);
		textBox_0.Size = new Size(484, 23);
		button_0.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_0.FlatStyle = FlatStyle.Flat;
		button_0.Location = new Point(578, 24);
		button_0.Name = Class16.smethod_0(1648992806);
		button_0.Size = new Size(34, 25);
		button_0.Text = Class16.smethod_0(1648924410);
		button_0.Click += button_0_Click;
		label_1.AutoSize = true;
		label_1.Location = new Point(16, 64);
		label_1.Name = Class16.smethod_0(1648892969);
		label_1.Size = new Size(29, 15);
		label_1.Text = Class16.smethod_0(1648992817);
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Location = new Point(86, 61);
		comboBox_0.Name = Class16.smethod_0(1648992836);
		comboBox_0.Size = new Size(180, 23);
		button_1.FlatStyle = FlatStyle.Flat;
		button_1.Location = new Point(278, 60);
		button_1.Name = Class16.smethod_0(1648992841);
		button_1.Size = new Size(110, 25);
		button_1.Text = Class16.smethod_0(1648992869);
		button_1.Click += button_1_Click;
		label_2.AutoSize = true;
		label_2.Location = new Point(16, 100);
		label_2.Name = Class16.smethod_0(1648992882);
		label_2.Size = new Size(48, 15);
		label_2.Text = Class16.smethod_0(1648992909);
		textBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
		textBox_1.BorderStyle = BorderStyle.FixedSingle;
		textBox_1.Location = new Point(86, 97);
		textBox_1.Name = Class16.smethod_0(1648992915);
		textBox_1.Size = new Size(484, 23);
		button_2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
		button_2.FlatStyle = FlatStyle.Flat;
		button_2.Location = new Point(578, 96);
		button_2.Name = Class16.smethod_0(1648992942);
		button_2.Size = new Size(34, 25);
		button_2.Text = Class16.smethod_0(1648924410);
		button_2.Click += button_2_Click;
		groupBox_1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		groupBox_1.Controls.Add(listBox_0);
		groupBox_1.Controls.Add(label_3);
		groupBox_1.Controls.Add(label_4);
		groupBox_1.Location = new Point(12, 160);
		groupBox_1.Name = Class16.smethod_0(1648992964);
		groupBox_1.Padding = new Padding(12, 8, 12, 8);
		groupBox_1.Size = new Size(626, 250);
		groupBox_1.Text = Class16.smethod_0(1648992981);
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listBox_0.BorderStyle = BorderStyle.None;
		listBox_0.Font = new Font(Class16.smethod_0(1648929975), 9f);
		listBox_0.Location = new Point(16, 24);
		listBox_0.Name = Class16.smethod_0(1648992995);
		listBox_0.Size = new Size(596, 180);
		label_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_3.AutoSize = true;
		label_3.Font = new Font(Class16.smethod_0(1648942905), 8.5f);
		label_3.Location = new Point(16, 210);
		label_3.Name = Class16.smethod_0(1648993023);
		label_3.Size = new Size(0, 15);
		label_3.Text = string.Empty;
		label_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_4.AutoSize = true;
		label_4.Location = new Point(16, 228);
		label_4.Name = Class16.smethod_0(1648993032);
		label_4.Size = new Size(160, 15);
		label_4.Text = Class16.smethod_0(1648993060);
		progressBar_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		progressBar_0.Location = new Point(12, 420);
		progressBar_0.Name = Class16.smethod_0(1648993093);
		progressBar_0.Size = new Size(434, 10);
		button_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_3.Enabled = false;
		button_3.FlatStyle = FlatStyle.Flat;
		button_3.Location = new Point(454, 414);
		button_3.Name = Class16.smethod_0(1648993111);
		button_3.Size = new Size(88, 30);
		button_3.Text = Class16.smethod_0(1648999936);
		button_3.Click += button_3_Click;
		button_4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		button_4.FlatStyle = FlatStyle.Flat;
		button_4.Location = new Point(550, 414);
		button_4.Name = Class16.smethod_0(1648993120);
		button_4.Size = new Size(88, 30);
		button_4.Text = Class16.smethod_0(1649014457);
		button_4.Click += button_4_Click;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(650, 460);
		base.Controls.Add(groupBox_0);
		base.Controls.Add(groupBox_1);
		base.Controls.Add(progressBar_0);
		base.Controls.Add(button_3);
		base.Controls.Add(button_4);
		base.MinimizeBox = false;
		MinimumSize = new Size(560, 420);
		base.Name = Class16.smethod_0(1648993149);
		base.StartPosition = FormStartPosition.CenterParent;
		Text = Class16.smethod_0(1648993175);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_1.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		using OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Title = TextStorage.Msg(Class16.smethod_0(1648996579), Class16.smethod_0(1648996613)),
			Filter = Class16.smethod_0(1648996627),
			FilterIndex = 1
		};
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			textBox_0.Text = openFileDialog.FileName;
		}
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			Description = TextStorage.Msg(Class16.smethod_0(1648993552), Class16.smethod_0(1648993576))
		};
		if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
		{
			textBox_1.Text = folderBrowserDialog.SelectedPath;
		}
	}

	private void button_1_Click(object sender, EventArgs e)
	{
		method_2();
	}

	private void method_2()
	{
		listBox_0.Items.Clear();
		list_0.Clear();
		button_3.Enabled = false;
		label_3.Text = string.Empty;
		if (!File.Exists(textBox_0.Text))
		{
			label_4.Text = TextStorage.Msg(Class16.smethod_0(1648993194), Class16.smethod_0(1648993218));
			return;
		}
		label_4.Text = TextStorage.Msg(Class16.smethod_0(1648996685), Class16.smethod_0(1648996696));
		Application.DoEvents();
		try
		{
			ecmPckReader_0?.Dispose();
			ecmPckReader_0 = new EcmPckReader(textBox_0.Text);
			string text = string.Empty;
			bool flag;
			string name;
			if (comboBox_0.SelectedIndex == 0)
			{
				EcmPckOpenResult ecmPckOpenResult = ecmPckReader_0.OpenWithAutoKey();
				if (!(flag = ecmPckOpenResult.Success) || ecmPckOpenResult.DetectedKey == null)
				{
					label_4.Text = ecmPckOpenResult.ErrorMessage;
					label_3.Text = string.Join(Class16.smethod_0(1648942920), ecmPckOpenResult.TriedKeys);
					return;
				}
				name = ecmPckOpenResult.DetectedKey.Name;
				text = ((ecmPckOpenResult.PathFormat == EcmPckPathFormat.Standard256) ? Class16.smethod_0(1648993256) : Class16.smethod_0(1648993243));
				if (ecmPckOpenResult.HasPkxFiles)
				{
					text += Class16.smethod_0(1648993277);
				}
			}
			else
			{
				EcmPckKey ecmPckKey = EcmPckKey.AllKeys[comboBox_0.SelectedIndex - 1];
				ecmPckReader_0 = new EcmPckReader(textBox_0.Text, ecmPckKey);
				flag = ecmPckReader_0.Open();
				name = ecmPckKey.Name;
			}
			if (!flag)
			{
				label_4.Text = TextStorage.Msg(Class16.smethod_0(1648996723), Class16.smethod_0(1648996744));
				return;
			}
			label_3.Text = Class16.smethod_0(1648992259) + name + text;
			list_0 = ((VersionFilter > 0) ? ecmPckReader_0.FindEcmFiles((EcmVersion)VersionFilter) : ecmPckReader_0.FindAllEcmFiles());
			foreach (EcmPckEntry item in list_0)
			{
				listBox_0.Items.Add(item.Path);
			}
			label_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648992279), Class16.smethod_0(1648992291)), list_0.Count, ecmPckReader_0.FileCount);
			button_3.Enabled = list_0.Count > 0;
		}
		catch (Exception ex)
		{
			label_4.Text = Class16.smethod_0(1648935998) + ex.Message;
		}
	}

	private async void button_3_Click(object sender, EventArgs e)
	{
		if (ecmPckReader_0 == null || list_0.Count == 0)
		{
			return;
		}
		if (string.IsNullOrEmpty(textBox_1.Text))
		{
			MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648993552), Class16.smethod_0(1648993576)), TextStorage.Msg(Class16.smethod_0(1648996854), Class16.smethod_0(1648999936)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		button_3.Enabled = false;
		progressBar_0.Maximum = list_0.Count;
		progressBar_0.Value = 0;
		try
		{
			(int, int) tuple = await Task.Run((Func<(int, int)>)method_3);
			method_0(textBox_1.Text);
			label_4.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648993614), Class16.smethod_0(1648993637)), tuple.Item1, tuple.Item2);
			progressBar_0.Value = progressBar_0.Maximum;
			if (tuple.Item1 > 0)
			{
				DialogResult dialogResult = MessageBox.Show(TextStorage.Msg(Class16.smethod_0(1648993667), Class16.smethod_0(1648993700)), TextStorage.Msg(Class16.smethod_0(1648996854), Class16.smethod_0(1648999936)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					base.DialogResult = DialogResult.OK;
					Close();
				}
			}
		}
		catch (Exception ex)
		{
			label_4.Text = Class16.smethod_0(1648935998) + ex.Message;
		}
		finally
		{
			button_3.Enabled = true;
		}
	}

	protected override void OnFormClosing(FormClosingEventArgs formClosingEventArgs_0)
	{
		ecmPckReader_0?.Dispose();
		base.OnFormClosing(formClosingEventArgs_0);
	}

	private void button_4_Click(object sender, EventArgs e)
	{
		Close();
	}

	private (int, int) method_3()
	{
		return ecmPckReader_0.ExtractEcmFiles(list_0, textBox_1.Text, method_4);
	}

	private void method_4(int int_1, int int_2)
	{
		Class113 @class = new Class113();
		@class.ecmExtractPckDialog_0 = this;
		@class.int_0 = int_1;
		@class.int_1 = int_2;
		Invoke(new Action(@class.method_0));
	}
}
