using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ACE.Classes;
using ACE.RSGlobal;
using ACE.UIEdit.Models;
using ACE.UIEdit.Services;

namespace ACE.UIEdit;

public sealed class AITranslationEditorForm : Form
{
	[StructLayout(LayoutKind.Auto)]
	private struct Struct112 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncVoidMethodBuilder asyncVoidMethodBuilder_0;

		public AITranslationEditorForm aitranslationEditorForm_0;

		private TaskAwaiter taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			AITranslationEditorForm aITranslationEditorForm = aitranslationEditorForm_0;
			try
			{
				TaskAwaiter awaiter;
				if (num != 0)
				{
					awaiter = aITranslationEditorForm.method_4().GetAwaiter();
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

	private sealed class Class363
	{
		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		public string method_0()
		{
			return string_0;
		}

		public void method_1(string string_2)
		{
			string_0 = string_2;
		}

		public string method_2()
		{
			return string_1;
		}

		public void method_3(string string_2)
		{
			string_1 = string_2;
		}

		public override string ToString()
		{
			return method_2();
		}
	}

	[StructLayout(LayoutKind.Auto)]
	private struct Struct113 : IAsyncStateMachine
	{
		public int int_0;

		public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;

		public AITranslationEditorForm aitranslationEditorForm_0;

		private string string_0;

		private string string_1;

		private IAiTranslationProvider iaiTranslationProvider_0;

		private int int_1;

		private IEnumerator ienumerator_0;

		private DataGridViewRow dataGridViewRow_0;

		private UiAiTranslationEntry uiAiTranslationEntry_0;

		private TaskAwaiter<string> taskAwaiter_0;

		private void MoveNext()
		{
			int num = int_0;
			AITranslationEditorForm aITranslationEditorForm = aitranslationEditorForm_0;
			try
			{
				if (num == 0)
				{
					goto IL_00e9;
				}
				object obj;
				if (aITranslationEditorForm.list_0.Count != 0)
				{
					object selectedItem = aITranslationEditorForm.comboBox_1.SelectedItem;
					if (selectedItem == null)
					{
						obj = null;
					}
					else
					{
						obj = selectedItem.ToString();
						if (obj != null)
						{
							goto IL_004c;
						}
					}
					obj = Class16.smethod_0(1648931959);
					goto IL_004c;
				}
				goto end_IL_000e;
				IL_00e9:
				try
				{
					if (num != 0)
					{
						goto IL_02f6;
					}
					goto IL_00f4;
					IL_02f6:
					bool flag = default(bool);
					while (ienumerator_0.MoveNext())
					{
						dataGridViewRow_0 = (DataGridViewRow)ienumerator_0.Current;
						object tag = dataGridViewRow_0.Tag;
						uiAiTranslationEntry_0 = tag as UiAiTranslationEntry;
						if (uiAiTranslationEntry_0 == null)
						{
							continue;
						}
						tag = dataGridViewRow_0.Cells[Class16.smethod_0(1649150817)].Value;
						int num2;
						if (tag is bool)
						{
							flag = (bool)tag;
							num2 = 1;
						}
						else
						{
							num2 = 0;
						}
						bool flag2 = (byte)((uint)num2 & (flag ? 1u : 0u)) != 0;
						uiAiTranslationEntry_0.Selected = flag2;
						if (!flag2)
						{
							continue;
						}
						goto IL_00f4;
					}
					goto end_IL_00e9;
					IL_00f4:
					try
					{
						TaskAwaiter<string> awaiter;
						if (num != 0)
						{
							aITranslationEditorForm.label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649150832), Class16.smethod_0(1649150857)), int_1 + 1, aITranslationEditorForm.list_0.Count);
							awaiter = iaiTranslationProvider_0.TranslateAsync(uiAiTranslationEntry_0.SourceText, string_0, string_1, aITranslationEditorForm.ApiKey, aITranslationEditorForm.Model, CancellationToken.None).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = 0;
								int_0 = 0;
								taskAwaiter_0 = awaiter;
								asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted(ref awaiter, ref this);
								return;
							}
						}
						else
						{
							awaiter = taskAwaiter_0;
							taskAwaiter_0 = default(TaskAwaiter<string>);
							num = -1;
							int_0 = -1;
						}
						string result = awaiter.GetResult();
						string text = result;
						uiAiTranslationEntry_0.TranslatedText = text;
						dataGridViewRow_0.Cells[Class16.smethod_0(1649150894)].Value = text;
					}
					catch (Exception ex)
					{
						SentryHelper.CaptureException(ex, Class16.smethod_0(1649150911));
						DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649150964), Class16.smethod_0(1649149963)), ex.Message), Class16.smethod_0(1649150804), MessageBoxButtons.OK, MessageBoxIcon.Hand);
						goto end_IL_00e9;
					}
					int_1++;
					Application.DoEvents();
					uiAiTranslationEntry_0 = null;
					dataGridViewRow_0 = null;
					goto IL_02f6;
					end_IL_00e9:;
				}
				finally
				{
					if (num < 0 && ienumerator_0 is IDisposable disposable)
					{
						disposable.Dispose();
					}
				}
				ienumerator_0 = null;
				aITranslationEditorForm.label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649149992), Class16.smethod_0(1649150031)), int_1);
				goto end_IL_000e;
				IL_004c:
				string_0 = (string)obj;
				object selectedItem2 = aITranslationEditorForm.comboBox_2.SelectedItem;
				object obj2;
				if (selectedItem2 == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = selectedItem2.ToString();
					if (obj2 != null)
					{
						goto IL_0077;
					}
				}
				obj2 = Class16.smethod_0(1648932116);
				goto IL_0077;
				IL_0077:
				string_1 = (string)obj2;
				if (!string.IsNullOrWhiteSpace(aITranslationEditorForm.ApiKey))
				{
					iaiTranslationProvider_0 = AiTranslationProviderFactory.GetById(aITranslationEditorForm.SelectedProviderId);
					int_1 = 0;
					ienumerator_0 = ((IEnumerable)aITranslationEditorForm.dataGridView_0.Rows).GetEnumerator();
					goto IL_00e9;
				}
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649150722), Class16.smethod_0(1649150762)), Class16.smethod_0(1649150804), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				end_IL_000e:;
			}
			catch (Exception exception)
			{
				int_0 = -2;
				string_0 = null;
				string_1 = null;
				iaiTranslationProvider_0 = null;
				asyncTaskMethodBuilder_0.SetException(exception);
				return;
			}
			int_0 = -2;
			string_0 = null;
			string_1 = null;
			iaiTranslationProvider_0 = null;
			asyncTaskMethodBuilder_0.SetResult();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private readonly string string_0;

	private readonly string string_1;

	private readonly List<UiAiTranslationEntry> list_0 = new List<UiAiTranslationEntry>();

	private string string_2 = string.Empty;

	private IContainer icontainer_0;

	private TableLayoutPanel tableLayoutPanel_0;

	private ComboBox comboBox_0;

	private TextBox textBox_0;

	private TextBox textBox_1;

	private ComboBox comboBox_1;

	private ComboBox comboBox_2;

	private Button button_0;

	private Button button_1;

	private Button button_2;

	private DataGridView dataGridView_0;

	private Label label_0;

	private Label label_1;

	private Label label_2;

	private Label label_3;

	private Label label_4;

	private Label label_5;

	private FlowLayoutPanel flowLayoutPanel_0;

	private FlowLayoutPanel flowLayoutPanel_1;

	public string ResultText
	{
		[CompilerGenerated]
		get
		{
			return string_2;
		}
		private set
		{
			string_2 = value;
		}
	}

	public string SelectedProviderId
	{
		get
		{
			Class363 obj = comboBox_0.SelectedItem as Class363;
			object obj2;
			if (obj == null)
			{
				obj2 = null;
			}
			else
			{
				obj2 = obj.method_0();
				if (obj2 != null)
				{
					goto IL_002a;
				}
			}
			obj2 = Class16.smethod_0(1649150061);
			goto IL_002a;
			IL_002a:
			return (string)obj2;
		}
	}

	public string ApiKey => textBox_0.Text.Trim();

	public string Model => textBox_1.Text.Trim();

	public AITranslationEditorForm(string sourceText, string filePath, string apiKey, string model)
	{
		method_6();
		method_0();
		TextStorage.TEXTS.SetFormLanguage(this, null);
		string_0 = sourceText ?? string.Empty;
		string_1 = filePath ?? string.Empty;
		ResultText = string_0;
		textBox_0.Text = apiKey ?? string.Empty;
		textBox_1.Text = (string.IsNullOrWhiteSpace(model) ? Class16.smethod_0(1648896900) : model);
		method_1();
		method_2();
		button_0.Click += button_0_Click;
		button_1.Click += button_1_Click;
		button_2.Click += button_2_Click;
		method_3();
	}

	private void method_0()
	{
		if (dataGridView_0.Columns.Count == 0)
		{
			dataGridView_0.Columns.Add(new DataGridViewCheckBoxColumn
			{
				Name = Class16.smethod_0(1649150817),
				HeaderText = Class16.smethod_0(1649089161),
				FillWeight = 28f
			});
			dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = Class16.smethod_0(1649150066),
				HeaderText = Class16.smethod_0(1648936875),
				FillWeight = 35f,
				ReadOnly = true
			});
			dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = Class16.smethod_0(1649162437),
				HeaderText = Class16.smethod_0(1649162437),
				FillWeight = 200f,
				ReadOnly = true
			});
			dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = Class16.smethod_0(1649150894),
				HeaderText = Class16.smethod_0(1649150894),
				FillWeight = 220f
			});
			dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
			{
				Name = Class16.smethod_0(1648992688),
				HeaderText = Class16.smethod_0(1649150085),
				FillWeight = 160f,
				ReadOnly = true
			});
		}
	}

	private void method_1()
	{
		foreach (IAiTranslationProvider provider in AiTranslationProviderFactory.GetProviders())
		{
			ComboBox.ObjectCollection items = comboBox_0.Items;
			Class363 @class = new Class363();
			@class.method_1(provider.ProviderId);
			@class.method_3(provider.DisplayName);
			items.Add(@class);
		}
		if (comboBox_0.Items.Count > 0)
		{
			comboBox_0.SelectedIndex = 0;
		}
	}

	private void method_2()
	{
		string[] languagesCodes = UniversalTranslator.GetLanguagesCodes();
		string[] array = languagesCodes;
		foreach (string item in array)
		{
			comboBox_1.Items.Add(item);
			comboBox_2.Items.Add(item);
		}
		comboBox_1.SelectedItem = Class16.smethod_0(1648931959);
		comboBox_2.SelectedItem = Class16.smethod_0(1648932116);
		if (comboBox_1.SelectedIndex < 0 && comboBox_1.Items.Count > 0)
		{
			comboBox_1.SelectedIndex = 0;
		}
		if (comboBox_2.SelectedIndex < 0 && comboBox_2.Items.Count > 0)
		{
			comboBox_2.SelectedIndex = Math.Min(1, comboBox_2.Items.Count - 1);
		}
	}

	private void method_3()
	{
		list_0.Clear();
		list_0.AddRange(UiTranslatableTextExtractor.DetectEntries(string_0, string_1));
		dataGridView_0.Rows.Clear();
		foreach (UiAiTranslationEntry item in list_0)
		{
			int index = dataGridView_0.Rows.Add(item.Selected, item.Kind, item.SourceText, item.TranslatedText, item.Preview);
			dataGridView_0.Rows[index].Tag = item;
		}
		label_0.Text = ((list_0.Count == 0) ? Class16.smethod_0(1649150172) : string.Format(Class16.smethod_0(1649150091), list_0.Count));
	}

	private async Task method_4()
	{
		if (list_0.Count == 0)
		{
			return;
		}
		object selectedItem = comboBox_1.SelectedItem;
		string obj;
		if (selectedItem != null)
		{
			obj = selectedItem.ToString();
			if (obj != null)
			{
				goto IL_004c;
			}
		}
		obj = Class16.smethod_0(1648931959);
		goto IL_004c;
		IL_004c:
		string sourceLanguageCode = obj;
		object selectedItem2 = comboBox_2.SelectedItem;
		string obj2;
		if (selectedItem2 != null)
		{
			obj2 = selectedItem2.ToString();
			if (obj2 != null)
			{
				goto IL_0077;
			}
		}
		obj2 = Class16.smethod_0(1648932116);
		goto IL_0077;
		IL_0077:
		string targetLanguageCode = obj2;
		if (string.IsNullOrWhiteSpace(ApiKey))
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649150722), Class16.smethod_0(1649150762)), Class16.smethod_0(1649150804), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		IAiTranslationProvider byId = AiTranslationProviderFactory.GetById(SelectedProviderId);
		int num = 0;
		bool flag = default(bool);
		foreach (DataGridViewRow item in (IEnumerable)dataGridView_0.Rows)
		{
			object tag = item.Tag;
			if (!(tag is UiAiTranslationEntry uiAiTranslationEntry))
			{
				continue;
			}
			tag = item.Cells[Class16.smethod_0(1649150817)].Value;
			int num2;
			if (tag is bool)
			{
				flag = (bool)tag;
				num2 = 1;
			}
			else
			{
				num2 = 0;
			}
			bool flag2 = (byte)((uint)num2 & (flag ? 1u : 0u)) != 0;
			uiAiTranslationEntry.Selected = flag2;
			if (flag2)
			{
				try
				{
					label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649150832), Class16.smethod_0(1649150857)), num + 1, list_0.Count);
					string value = (uiAiTranslationEntry.TranslatedText = await byId.TranslateAsync(uiAiTranslationEntry.SourceText, sourceLanguageCode, targetLanguageCode, ApiKey, Model, CancellationToken.None));
					item.Cells[Class16.smethod_0(1649150894)].Value = value;
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649150911));
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1649150964), Class16.smethod_0(1649149963)), ex.Message), Class16.smethod_0(1649150804), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					break;
				}
				num++;
				Application.DoEvents();
			}
		}
		label_0.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1649149992), Class16.smethod_0(1649150031)), num);
	}

	private void method_5()
	{
		bool flag = default(bool);
		foreach (DataGridViewRow item in (IEnumerable)dataGridView_0.Rows)
		{
			if (!(item.Tag is UiAiTranslationEntry uiAiTranslationEntry))
			{
				continue;
			}
			object value = item.Cells[Class16.smethod_0(1649150817)].Value;
			int num;
			if (value is bool)
			{
				flag = (bool)value;
				num = 1;
			}
			else
			{
				num = 0;
			}
			uiAiTranslationEntry.Selected = (byte)((uint)num & (flag ? 1u : 0u)) != 0;
			object value2 = item.Cells[Class16.smethod_0(1649150894)].Value;
			object obj;
			if (value2 == null)
			{
				obj = null;
			}
			else
			{
				obj = value2.ToString();
				if (obj != null)
				{
					goto IL_009a;
				}
			}
			obj = string.Empty;
			goto IL_009a;
			IL_009a:
			uiAiTranslationEntry.TranslatedText = (string)obj;
		}
		ResultText = UiTranslatableTextExtractor.ApplyTranslations(string_0, list_0);
		base.DialogResult = DialogResult.OK;
		Close();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_6()
	{
		icontainer_0 = new Container();
		tableLayoutPanel_0 = new TableLayoutPanel();
		comboBox_0 = new ComboBox();
		textBox_0 = new TextBox();
		textBox_1 = new TextBox();
		comboBox_1 = new ComboBox();
		comboBox_2 = new ComboBox();
		button_0 = new Button();
		button_1 = new Button();
		button_2 = new Button();
		dataGridView_0 = new DataGridView();
		label_0 = new Label();
		label_1 = new Label();
		label_2 = new Label();
		label_3 = new Label();
		label_4 = new Label();
		label_5 = new Label();
		flowLayoutPanel_0 = new FlowLayoutPanel();
		flowLayoutPanel_1 = new FlowLayoutPanel();
		((ISupportInitialize)dataGridView_0).BeginInit();
		SuspendLayout();
		tableLayoutPanel_0.ColumnCount = 8;
		tableLayoutPanel_0.RowCount = 3;
		tableLayoutPanel_0.Dock = DockStyle.Fill;
		tableLayoutPanel_0.Padding = new Padding(8);
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30f));
		tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
		tableLayoutPanel_0.Controls.Add(label_1, 0, 0);
		tableLayoutPanel_0.Controls.Add(comboBox_0, 1, 0);
		tableLayoutPanel_0.Controls.Add(label_2, 2, 0);
		tableLayoutPanel_0.Controls.Add(textBox_0, 3, 0);
		tableLayoutPanel_0.Controls.Add(label_3, 4, 0);
		tableLayoutPanel_0.Controls.Add(textBox_1, 5, 0);
		tableLayoutPanel_0.Controls.Add(flowLayoutPanel_0, 6, 0);
		tableLayoutPanel_0.Controls.Add(flowLayoutPanel_1, 7, 0);
		tableLayoutPanel_0.SetColumnSpan(dataGridView_0, 8);
		tableLayoutPanel_0.Controls.Add(dataGridView_0, 0, 1);
		tableLayoutPanel_0.SetColumnSpan(label_0, 8);
		tableLayoutPanel_0.Controls.Add(label_0, 0, 2);
		label_1.Text = Class16.smethod_0(1649150222);
		label_1.Anchor = AnchorStyles.Left;
		label_1.AutoSize = true;
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.Dock = DockStyle.Fill;
		label_2.Text = Class16.smethod_0(1649150238);
		label_2.Anchor = AnchorStyles.Left;
		label_2.AutoSize = true;
		textBox_0.Dock = DockStyle.Fill;
		textBox_0.UseSystemPasswordChar = true;
		label_3.Text = Class16.smethod_0(1649150253);
		label_3.Anchor = AnchorStyles.Left;
		label_3.AutoSize = true;
		textBox_1.Dock = DockStyle.Fill;
		flowLayoutPanel_0.Dock = DockStyle.Fill;
		flowLayoutPanel_0.AutoSize = true;
		flowLayoutPanel_0.WrapContents = false;
		flowLayoutPanel_0.Controls.Add(label_4);
		flowLayoutPanel_0.Controls.Add(comboBox_1);
		flowLayoutPanel_0.Controls.Add(label_5);
		flowLayoutPanel_0.Controls.Add(comboBox_2);
		label_4.Text = Class16.smethod_0(1648965979);
		label_4.AutoSize = true;
		label_4.Margin = new Padding(0, 6, 6, 0);
		comboBox_1.Width = 90;
		comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
		label_5.Text = Class16.smethod_0(1648965998);
		label_5.AutoSize = true;
		label_5.Margin = new Padding(10, 6, 6, 0);
		comboBox_2.Width = 90;
		comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
		flowLayoutPanel_1.Dock = DockStyle.Fill;
		flowLayoutPanel_1.AutoSize = true;
		flowLayoutPanel_1.WrapContents = false;
		flowLayoutPanel_1.Controls.Add(button_0);
		flowLayoutPanel_1.Controls.Add(button_1);
		flowLayoutPanel_1.Controls.Add(button_2);
		button_0.Text = Class16.smethod_0(1649150258);
		button_0.AutoSize = true;
		button_1.Text = Class16.smethod_0(1649150287);
		button_1.AutoSize = true;
		button_2.Text = Class16.smethod_0(1648996201);
		button_2.AutoSize = true;
		dataGridView_0.Dock = DockStyle.Fill;
		dataGridView_0.AllowUserToAddRows = false;
		dataGridView_0.AllowUserToDeleteRows = false;
		dataGridView_0.AllowUserToResizeRows = false;
		dataGridView_0.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
		dataGridView_0.RowHeadersVisible = false;
		dataGridView_0.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
		label_0.AutoSize = true;
		label_0.Dock = DockStyle.Fill;
		label_0.Text = Class16.smethod_0(1649150304);
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.ClientSize = new Size(1180, 620);
		MinimumSize = new Size(980, 520);
		base.StartPosition = FormStartPosition.CenterParent;
		base.Name = Class16.smethod_0(1649150331);
		Text = Class16.smethod_0(1649150361);
		base.Controls.Add(tableLayoutPanel_0);
		base.Activated += AITranslationEditorForm_Activated;
		((ISupportInitialize)dataGridView_0).EndInit();
		ResumeLayout(performLayout: false);
	}

	private void AITranslationEditorForm_Activated(object sender, EventArgs e)
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_AITranslationEditorForm != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_AITranslationEditorForm = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		method_3();
	}

	private async void button_1_Click(object sender, EventArgs e)
	{
		await method_4();
	}

	private void button_2_Click(object sender, EventArgs e)
	{
		method_5();
	}
}
