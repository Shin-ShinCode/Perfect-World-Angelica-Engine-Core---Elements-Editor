using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Properties;

namespace ACE.AIPolicyEditor.AIPolicy.Conditions;

public class ConditionEditForm : Form, INotifyPropertyChanged
{
	private readonly List<int> list_0 = new List<int>();

	private readonly StringFormatToIntConverter stringFormatToIntConverter_0 = new StringFormatToIntConverter();

	private readonly Condition condition_0;

	private readonly Condition condition_1;

	private readonly Label[] label_0;

	private readonly TextBox[] textBox_0;

	private bool bool_0;

	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private Reload reload_0;

	private Condition condition_2;

	private IContainer icontainer_0;

	private ComboBox comboBox_0;

	private Label label_1;

	private TextBox textBox_1;

	private Label label_2;

	private TextBox textBox_2;

	private Label label_3;

	private TextBox textBox_3;

	private Label label_4;

	private TextBox textBox_4;

	private Label label_5;

	private TextBox textBox_5;

	private Button button_0;

	private Button button_1;

	public Condition Condition_0
	{
		[CompilerGenerated]
		get
		{
			return condition_2;
		}
		[CompilerGenerated]
		set
		{
			condition_2 = value;
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

	public event Reload Reload
	{
		[CompilerGenerated]
		add
		{
			Reload reload = reload_0;
			Reload reload2;
			do
			{
				reload2 = reload;
				Reload value2 = (Reload)Delegate.Combine(reload2, value);
				reload = Interlocked.CompareExchange(ref reload_0, value2, reload2);
			}
			while ((object)reload != reload2);
		}
		[CompilerGenerated]
		remove
		{
			Reload reload = reload_0;
			Reload reload2;
			do
			{
				reload2 = reload;
				Reload value2 = (Reload)Delegate.Remove(reload2, value);
				reload = Interlocked.CompareExchange(ref reload_0, value2, reload2);
			}
			while ((object)reload != reload2);
		}
	}

	public ConditionEditForm(Condition condition_3)
	{
		if (condition_3 == null)
		{
			throw new ArgumentNullException(Class16.smethod_0(1648942986));
		}
		method_8();
		condition_0 = condition_3;
		condition_1 = (Condition)condition_3.Clone();
		Condition_0 = condition_3;
		label_0 = new Label[5] { label_1, label_2, label_3, label_4, label_5 };
		textBox_0 = new TextBox[5] { textBox_1, textBox_2, textBox_3, textBox_4, textBox_5 };
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_0();
		list_0.AddRange(Conditions.GetConditionIds());
		comboBox_0.BeginUpdate();
		foreach (int item in list_0)
		{
			comboBox_0.Items.Add(Conditions.GetName(item));
		}
		comboBox_0.EndUpdate();
		method_1();
	}

	private void method_0()
	{
		base.StartPosition = FormStartPosition.CenterParent;
		base.ClientSize = new Size(320, base.ClientSize.Height);
		comboBox_0.Left = 14;
		comboBox_0.Top = 14;
		comboBox_0.Width = base.ClientSize.Width - 28;
		comboBox_0.DropDownWidth = 420;
		for (int i = 0; i < label_0.Length; i++)
		{
			label_0[i].Left = 14;
			label_0[i].Width = base.ClientSize.Width - 28;
			label_0[i].TextAlign = ContentAlignment.MiddleLeft;
			textBox_0[i].Left = 14;
			textBox_0[i].Width = base.ClientSize.Width - 28;
		}
		smethod_0(button_0, Color.FromArgb(0, 122, 204), Color.White);
		smethod_0(button_1, TDark.IsDarkMode ? Color.FromArgb(70, 70, 70) : Color.FromArgb(92, 92, 92), Color.White);
		button_0.Size = new Size(136, 30);
		button_1.Size = new Size(136, 30);
	}

	private static void smethod_0(Button button_2, Color color_0, Color color_1)
	{
		button_2.FlatStyle = FlatStyle.Flat;
		button_2.FlatAppearance.BorderSize = 0;
		button_2.BackColor = color_0;
		button_2.ForeColor = color_1;
		button_2.Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Bold);
	}

	private void method_1()
	{
		bool_0 = true;
		int num = list_0.IndexOf(condition_1.ID);
		comboBox_0.SelectedIndex = ((num >= 0) ? num : ((list_0.Count <= 0) ? (-1) : 0));
		method_5();
		method_6();
		method_7();
		bool_0 = false;
	}

	private void comboBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0 || comboBox_0.SelectedIndex < 0 || comboBox_0.SelectedIndex >= list_0.Count)
		{
			return;
		}
		int num = list_0[comboBox_0.SelectedIndex];
		if (condition_1.ID == num)
		{
			return;
		}
		int num2 = Conditions.TypeByID(num);
		condition_1.ID = num;
		condition_1.Type = num2;
		condition_1.Value = Conditions.CreateEmptyValue(num);
		switch (num2)
		{
		case 1:
		{
			Condition condition = condition_1;
			if (condition.ConditionLeft == null)
			{
				condition.ConditionLeft = Conditions.CreateEmpty();
			}
			condition = condition_1;
			if (condition.ConditionRight == null)
			{
				condition.ConditionRight = Conditions.CreateEmpty();
			}
			break;
		}
		case 2:
		{
			condition_1.ConditionLeft = null;
			Condition condition = condition_1;
			if (condition.ConditionRight == null)
			{
				condition.ConditionRight = Conditions.CreateEmpty();
			}
			break;
		}
		default:
			condition_1.ConditionLeft = null;
			condition_1.ConditionRight = null;
			break;
		}
		(condition_1.SubNodeL, condition_1.SubNodeR) = Conditions.GetSubNodeByType(num2);
		method_5();
		method_6();
		method_7();
	}

	private void textBox_1_TextChanged(object sender, EventArgs e)
	{
		smethod_1(textBox_1);
	}

	private void textBox_2_TextChanged(object sender, EventArgs e)
	{
		smethod_1(textBox_2);
	}

	private void textBox_3_TextChanged(object sender, EventArgs e)
	{
		smethod_1(textBox_3);
	}

	private void textBox_4_TextChanged(object sender, EventArgs e)
	{
		smethod_1(textBox_4);
	}

	private void textBox_5_TextChanged(object sender, EventArgs e)
	{
		smethod_1(textBox_5);
	}

	private static void smethod_1(TextBox textBox_6)
	{
		if (!(TDark.IsDarkMode ? (textBox_6.BackColor != Color.FromArgb(100, 56, 56)) : (textBox_6.BackColor == SystemColors.Window)))
		{
			if (TDark.IsDarkMode)
			{
				TDark.ApplyThemeToDynamicControl(textBox_6);
				return;
			}
			textBox_6.BackColor = SystemColors.Window;
			textBox_6.ForeColor = SystemColors.WindowText;
		}
	}

	private void button_0_Click(object sender, EventArgs e)
	{
		if (!method_2(out var string_, out var textBox_))
		{
			if (textBox_ != null)
			{
				textBox_.BackColor = (TDark.IsDarkMode ? Color.FromArgb(100, 56, 56) : Color.FromArgb(255, 232, 232));
				textBox_.ForeColor = (TDark.IsDarkMode ? Color.White : SystemColors.WindowText);
				textBox_.Focus();
				textBox_.SelectAll();
			}
			DKBox.Show(string_, TextStorage.Msg(Class16.smethod_0(1648943005), Class16.smethod_0(1648943018)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		else
		{
			condition_0.CopyFrom(condition_1);
			reload_0?.Invoke();
			base.DialogResult = DialogResult.OK;
			Close();
		}
	}

	private bool method_2(out string string_0, out TextBox textBox_6)
	{
		textBox_6 = null;
		string_0 = null;
		object[] value = condition_1.Value;
		object obj;
		if (value == null)
		{
			obj = null;
		}
		else
		{
			obj = value.Clone();
			if (obj != null)
			{
				goto IL_0026;
			}
		}
		obj = Array.Empty<object>();
		goto IL_0026;
		IL_0026:
		object[] array = (object[])obj;
		for (int i = 0; i < array.Length && i < textBox_0.Length; i++)
		{
			if (method_3(i, textBox_0[i].Text, out var object_, out string_0))
			{
				array[i] = object_;
				continue;
			}
			textBox_6 = textBox_0[i];
			return false;
		}
		try
		{
			Conditions.Write(array, condition_1.ID);
		}
		catch (Exception ex) when (ex is FormatException || ex is InvalidCastException || ex is OverflowException || ex is IndexOutOfRangeException)
		{
			string_0 = TextStorage.Msg(Class16.smethod_0(1648943032), Class16.smethod_0(1648943079));
			return false;
		}
		condition_1.Value = array;
		condition_1.NormalizeTreeMetadata();
		return true;
	}

	private bool method_3(int int_0, string string_0, out object object_0, out string string_1)
	{
		object obj = condition_1.Value[int_0];
		if (string_0 == null)
		{
			string_0 = string.Empty;
		}
		if (condition_1.ID == 37)
		{
			return smethod_5(string_0, out object_0, out string_1);
		}
		if (obj is string)
		{
			if (smethod_2(condition_1.ID))
			{
				return smethod_3(string_0, out object_0, out string_1);
			}
			object_0 = string_0;
			string_1 = null;
			return true;
		}
		if (!(obj is float) && !(obj is double))
		{
			if (obj is byte)
			{
				return smethod_5(string_0, out object_0, out string_1);
			}
			return smethod_4(string_0, out object_0, out string_1);
		}
		return method_4(string_0, out object_0, out string_1);
	}

	private static bool smethod_2(int int_0)
	{
		if (int_0 != 28)
		{
			return int_0 == 36;
		}
		return true;
	}

	private static bool smethod_3(string string_0, out object object_0, out string string_1)
	{
		string[] array = string_0.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length != 3)
		{
			object_0 = null;
			string_1 = TextStorage.Msg(Class16.smethod_0(1648942103), Class16.smethod_0(1648942143));
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < array.Length)
			{
				if (!float.TryParse(array[num], NumberStyles.Float, CultureInfo.CurrentCulture, out var _))
				{
					break;
				}
				num++;
				continue;
			}
			object_0 = string.Join(Class16.smethod_0(1648942211), array);
			string_1 = null;
			return true;
		}
		object_0 = null;
		string_1 = TextStorage.Msg(Class16.smethod_0(1648942103), Class16.smethod_0(1648942143));
		return false;
	}

	private bool method_4(string string_0, out object object_0, out string string_1)
	{
		if (float.TryParse(string_0, NumberStyles.Float, CultureInfo.CurrentCulture, out var result))
		{
			object_0 = result;
			string_1 = null;
			return true;
		}
		object_0 = null;
		string_1 = TextStorage.Msg(Class16.smethod_0(1648942219), Class16.smethod_0(1648942259));
		return false;
	}

	private static bool smethod_4(string string_0, out object object_0, out string string_1)
	{
		if (int.TryParse(string_0, NumberStyles.Integer, CultureInfo.CurrentCulture, out var result))
		{
			object_0 = result;
			string_1 = null;
			return true;
		}
		object_0 = null;
		string_1 = TextStorage.Msg(Class16.smethod_0(1648942302), Class16.smethod_0(1648942343));
		return false;
	}

	private static bool smethod_5(string string_0, out object object_0, out string string_1)
	{
		if (byte.TryParse(string_0, NumberStyles.Integer, CultureInfo.CurrentCulture, out var result))
		{
			object_0 = result;
			string_1 = null;
			return true;
		}
		object_0 = null;
		string_1 = TextStorage.Msg(Class16.smethod_0(1648942370), Class16.smethod_0(1648942408));
		return false;
	}

	private void method_5()
	{
		bool_0 = true;
		string[] fileds = Conditions.GetFileds(condition_1.ID);
		TextBox obj;
		object obj2;
		for (int i = 0; i < label_0.Length; obj.Text = (string)obj2, i++)
		{
			bool flag = condition_1.Value != null && i < condition_1.Value.Length;
			label_0[i].Text = (flag ? smethod_6(fileds, i) : string.Empty);
			obj = textBox_0[i];
			if (!flag)
			{
				obj2 = string.Empty;
				continue;
			}
			object obj3 = stringFormatToIntConverter_0.Convert(condition_1.Value[i], typeof(string), null, CultureInfo.CurrentCulture);
			if (obj3 == null)
			{
				obj2 = null;
			}
			else
			{
				obj2 = obj3.ToString();
				if (obj2 != null)
				{
					continue;
				}
			}
			obj2 = string.Empty;
		}
		bool_0 = false;
	}

	private static string smethod_6(string[] string_0, int int_0)
	{
		if (string_0 != null && int_0 < string_0.Length && !string.IsNullOrWhiteSpace(string_0[int_0]))
		{
			return string_0[int_0];
		}
		return string.Format(Class16.smethod_0(1648942455), int_0 + 1);
	}

	private void method_6()
	{
		object[] value = condition_1.Value;
		int num = ((value != null) ? value.Length : 0);
		int num2 = comboBox_0.Bottom + 14;
		for (int i = 0; i < label_0.Length; i++)
		{
			bool flag = i < num;
			label_0[i].Visible = flag;
			textBox_0[i].Visible = flag;
			if (flag)
			{
				label_0[i].Top = num2;
				textBox_0[i].Top = label_0[i].Bottom + 4;
				num2 = textBox_0[i].Bottom + 10;
			}
		}
		button_0.Left = 14;
		button_1.Left = base.ClientSize.Width - button_1.Width - 14;
		button_0.Top = num2 + 4;
		button_1.Top = button_0.Top;
		base.ClientSize = new Size(base.ClientSize.Width, button_0.Bottom + 14);
	}

	private void method_7()
	{
		Text = Class16.smethod_0(1648942471) + Conditions.GetName(condition_1.ID);
	}

	public void OnPropertyChanged(string prop = "")
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(prop));
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void method_8()
	{
		new ComponentResourceManager(typeof(ConditionEditForm));
		comboBox_0 = new ComboBox();
		label_1 = new Label();
		textBox_1 = new TextBox();
		label_2 = new Label();
		textBox_2 = new TextBox();
		label_3 = new Label();
		textBox_3 = new TextBox();
		label_4 = new Label();
		textBox_4 = new TextBox();
		label_5 = new Label();
		textBox_5 = new TextBox();
		button_0 = new Button();
		button_1 = new Button();
		SuspendLayout();
		comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
		comboBox_0.FormattingEnabled = true;
		comboBox_0.Location = new Point(10, 10);
		comboBox_0.Name = Class16.smethod_0(1648942489);
		comboBox_0.Size = new Size(172, 23);
		comboBox_0.TabIndex = 0;
		comboBox_0.SelectedIndexChanged += comboBox_0_SelectedIndexChanged;
		label_1.Location = new Point(10, 41);
		label_1.Name = Class16.smethod_0(1648942513);
		label_1.Size = new Size(172, 26);
		label_1.TabIndex = 1;
		label_1.Text = Class16.smethod_0(1648942531);
		label_1.TextAlign = ContentAlignment.MiddleCenter;
		textBox_1.Location = new Point(10, 72);
		textBox_1.Name = Class16.smethod_0(1648942544);
		textBox_1.Size = new Size(172, 23);
		textBox_1.TabIndex = 2;
		textBox_1.TextChanged += textBox_1_TextChanged;
		label_2.Location = new Point(10, 103);
		label_2.Name = Class16.smethod_0(1648942572);
		label_2.Size = new Size(172, 26);
		label_2.TabIndex = 3;
		label_2.Text = Class16.smethod_0(1648942590);
		label_2.TextAlign = ContentAlignment.MiddleCenter;
		textBox_2.Location = new Point(10, 134);
		textBox_2.Name = Class16.smethod_0(1648941571);
		textBox_2.Size = new Size(172, 23);
		textBox_2.TabIndex = 4;
		textBox_2.TextChanged += textBox_2_TextChanged;
		label_3.Location = new Point(10, 165);
		label_3.Name = Class16.smethod_0(1648941599);
		label_3.Size = new Size(172, 26);
		label_3.TabIndex = 5;
		label_3.Text = Class16.smethod_0(1648941609);
		label_3.TextAlign = ContentAlignment.MiddleCenter;
		textBox_3.Location = new Point(10, 199);
		textBox_3.Name = Class16.smethod_0(1648941630);
		textBox_3.Size = new Size(172, 23);
		textBox_3.TabIndex = 6;
		textBox_3.TextChanged += textBox_3_TextChanged;
		label_4.Location = new Point(10, 229);
		label_4.Name = Class16.smethod_0(1648941642);
		label_4.Size = new Size(172, 26);
		label_4.TabIndex = 7;
		label_4.Text = Class16.smethod_0(1648941668);
		label_4.TextAlign = ContentAlignment.MiddleCenter;
		textBox_4.Location = new Point(10, 264);
		textBox_4.Name = Class16.smethod_0(1648941673);
		textBox_4.Size = new Size(172, 23);
		textBox_4.TabIndex = 8;
		textBox_4.TextChanged += textBox_4_TextChanged;
		label_5.Location = new Point(10, 293);
		label_5.Name = Class16.smethod_0(1648941701);
		label_5.Size = new Size(172, 26);
		label_5.TabIndex = 9;
		label_5.Text = Class16.smethod_0(1648941719);
		label_5.TextAlign = ContentAlignment.MiddleCenter;
		textBox_5.Location = new Point(10, 326);
		textBox_5.Name = Class16.smethod_0(1648941732);
		textBox_5.Size = new Size(172, 23);
		textBox_5.TabIndex = 10;
		textBox_5.TextChanged += textBox_5_TextChanged;
		button_0.Location = new Point(10, 357);
		button_0.Name = Class16.smethod_0(1648941744);
		button_0.Size = new Size(82, 26);
		button_0.TabIndex = 11;
		button_0.Text = Class16.smethod_0(1648941761);
		button_0.UseVisualStyleBackColor = true;
		button_0.Click += button_0_Click;
		button_1.DialogResult = DialogResult.Cancel;
		button_1.Location = new Point(100, 357);
		button_1.Name = Class16.smethod_0(1648941780);
		button_1.Size = new Size(82, 26);
		button_1.TabIndex = 12;
		button_1.Text = Class16.smethod_0(1648941799);
		button_1.UseVisualStyleBackColor = true;
		base.AcceptButton = button_0;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.CancelButton = button_1;
		base.ClientSize = new Size(200, 395);
		base.Controls.Add(button_1);
		base.Controls.Add(button_0);
		base.Controls.Add(textBox_5);
		base.Controls.Add(label_5);
		base.Controls.Add(textBox_4);
		base.Controls.Add(label_4);
		base.Controls.Add(textBox_3);
		base.Controls.Add(label_3);
		base.Controls.Add(textBox_2);
		base.Controls.Add(label_2);
		base.Controls.Add(textBox_1);
		base.Controls.Add(label_1);
		base.Controls.Add(comboBox_0);
		Font = new Font(Class16.smethod_0(1648942905), 9f);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Resources.edit;
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = Class16.smethod_0(1648941812);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648941836);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}
}
