using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.AIPolicyEditor.AIPolicy.Operations.CustomEditors;

public class CustomDataSelectorForm : Form, INotifyPropertyChanged
{
	private string string_0 = string.Empty;

	private int int_0 = -1;

	private ObservableCollection<CustomDataCollection> observableCollection_0 = new ObservableCollection<CustomDataCollection>();

	private SetIntValue setIntValue_0;

	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private IContainer icontainer_0;

	private Label label_0;

	private TextBox textBox_0;

	private ListBox listBox_0;

	private RichTextBox richTextBox_0;

	private Button button_0;

	public string Filter
	{
		get
		{
			return string_0;
		}
		set
		{
			if (string_0 != value)
			{
				string_0 = value;
				OnPropertyChanged(Class16.smethod_0(1648935595));
				method_0();
			}
		}
	}

	public int Index
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 == value)
			{
				return;
			}
			int_0 = value;
			OnPropertyChanged(Class16.smethod_0(1648935608));
			CustomDataCollection item = Item;
			object obj;
			if (item == null)
			{
				obj = null;
			}
			else
			{
				obj = item.Desc;
				if (obj != null)
				{
					goto IL_003c;
				}
			}
			obj = string.Empty;
			goto IL_003c;
			IL_003c:
			ProItemDesc((string)obj);
		}
	}

	public CustomDataCollection Item
	{
		get
		{
			if (Index > -1 && Index < listBox_0.Items.Count)
			{
				return listBox_0.Items[Index] as CustomDataCollection;
			}
			return null;
		}
	}

	public ObservableCollection<CustomDataCollection> Items
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			if (observableCollection_0 != value)
			{
				observableCollection_0 = value;
				OnPropertyChanged(Class16.smethod_0(1648935628));
				method_0();
			}
		}
	}

	public event SetIntValue ChangeValue
	{
		[CompilerGenerated]
		add
		{
			SetIntValue setIntValue = setIntValue_0;
			SetIntValue setIntValue2;
			do
			{
				setIntValue2 = setIntValue;
				SetIntValue value2 = (SetIntValue)Delegate.Combine(setIntValue2, value);
				setIntValue = Interlocked.CompareExchange(ref setIntValue_0, value2, setIntValue2);
			}
			while ((object)setIntValue != setIntValue2);
		}
		[CompilerGenerated]
		remove
		{
			SetIntValue setIntValue = setIntValue_0;
			SetIntValue setIntValue2;
			do
			{
				setIntValue2 = setIntValue;
				SetIntValue value2 = (SetIntValue)Delegate.Remove(setIntValue2, value);
				setIntValue = Interlocked.CompareExchange(ref setIntValue_0, value2, setIntValue2);
			}
			while ((object)setIntValue != setIntValue2);
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public CustomDataSelectorForm(List<CustomDataCollection> items)
	{
		method_1();
		TDark.StoreOriginalColors(this);
		TDark.ApplyThemeToForm(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		Items = new ObservableCollection<CustomDataCollection>(items);
		method_0();
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		Filter = textBox_0.Text;
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		Index = listBox_0.SelectedIndex;
	}

	private void method_0()
	{
		listBox_0.Items.Clear();
		IEnumerable<CustomDataCollection> enumerable2;
		if (Filter.Length <= 0)
		{
			IEnumerable<CustomDataCollection> enumerable = observableCollection_0;
			enumerable2 = enumerable;
		}
		else
		{
			enumerable2 = observableCollection_0.Where(method_2);
		}
		IEnumerable<CustomDataCollection> enumerable3 = enumerable2;
		foreach (CustomDataCollection item in enumerable3)
		{
			listBox_0.Items.Add(item);
		}
	}

	public void OnPropertyChanged(string prop = "")
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(prop));
	}

	public void ProItemDesc(string desc)
	{
		if (desc.Length < 2)
		{
			return;
		}
		try
		{
			string text = desc.Replace(Class16.smethod_0(1648935632), Class16.smethod_0(1648935641));
			text = text.Replace(Class16.smethod_0(1648935651), string.Empty);
			text = text.Replace('\\', '\n');
			List<string> list = new List<string>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < text.Length; i++)
			{
				int num = text.IndexOf(Class16.smethod_0(1648935659), i);
				if (num >= 0)
				{
					list.Add(text.Substring(num + 1, 6));
					text = text.Remove(num, 7);
					if (num == 0)
					{
						list2.Add(num);
					}
					else
					{
						list2.Add(num - 1);
					}
				}
			}
			richTextBox_0.Text = text;
			richTextBox_0.SelectAll();
			richTextBox_0.SelectionColor = Color.White;
			for (int j = 0; j < list2.Count; j++)
			{
				richTextBox_0.Select(list2[j], richTextBox_0.Text.Length - list2[j]);
				richTextBox_0.SelectionColor = Color.FromArgb(int.Parse(list[j].Substring(0, 2), NumberStyles.AllowHexSpecifier), int.Parse(list[j].Substring(2, 2), NumberStyles.AllowHexSpecifier), int.Parse(list[j].Substring(4, 2), NumberStyles.AllowHexSpecifier));
			}
		}
		catch
		{
			richTextBox_0.Text = TextStorage.Msg(Class16.smethod_0(1648935667));
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		CustomDataCollection item = Item;
		if (item != null)
		{
			setIntValue_0?.Invoke(item.ID);
			base.DialogResult = DialogResult.OK;
			Close();
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

	private void method_1()
	{
		new ComponentResourceManager(typeof(CustomDataSelectorForm));
		label_0 = new Label();
		textBox_0 = new TextBox();
		listBox_0 = new ListBox();
		richTextBox_0 = new RichTextBox();
		button_0 = new Button();
		SuspendLayout();
		label_0.AutoSize = true;
		label_0.Location = new Point(10, 10);
		label_0.Name = Class16.smethod_0(1648935699);
		label_0.Size = new Size(36, 13);
		label_0.TabIndex = 0;
		label_0.Text = Class16.smethod_0(1648935725);
		textBox_0.Location = new Point(80, 10);
		textBox_0.Name = Class16.smethod_0(1648935731);
		textBox_0.Size = new Size(185, 22);
		textBox_0.TabIndex = 1;
		textBox_0.TextChanged += textBox_0_TextChanged;
		listBox_0.BackColor = Color.FromArgb(32, 32, 32);
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		listBox_0.ForeColor = Color.White;
		listBox_0.FormattingEnabled = true;
		listBox_0.ItemHeight = 15;
		listBox_0.Location = new Point(10, 41);
		listBox_0.Name = Class16.smethod_0(1648935759);
		listBox_0.Size = new Size(255, 229);
		listBox_0.TabIndex = 2;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		richTextBox_0.BackColor = Color.FromArgb(32, 32, 32);
		richTextBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		richTextBox_0.ForeColor = Color.White;
		richTextBox_0.Location = new Point(270, 10);
		richTextBox_0.Name = Class16.smethod_0(1648935770);
		richTextBox_0.ReadOnly = true;
		richTextBox_0.Size = new Size(364, 240);
		richTextBox_0.TabIndex = 3;
		richTextBox_0.Text = string.Empty;
		button_0.Location = new Point(10, 294);
		button_0.Name = Class16.smethod_0(1648935792);
		button_0.Size = new Size(624, 23);
		button_0.TabIndex = 4;
		button_0.Text = Class16.smethod_0(1648935811);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(650, 360);
		base.Controls.Add(button_0);
		base.Controls.Add(richTextBox_0);
		base.Controls.Add(listBox_0);
		base.Controls.Add(textBox_0);
		base.Controls.Add(label_0);
		Font = new Font(Class16.smethod_0(1648942905), 8f);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648935824);
		Text = Class16.smethod_0(1648935861);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private bool method_2(CustomDataCollection customDataCollection_0)
	{
		if (!customDataCollection_0.ID.ToString().Contains(Filter) && !customDataCollection_0.Name.Contains(Filter))
		{
			return customDataCollection_0.Desc.Contains(Filter);
		}
		return true;
	}
}
