using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Components;

public class TextBoxEx : TextBox
{
	[Serializable]
	private sealed class Class253
	{
		public static readonly Class253 class253_0 = new Class253();

		public static Func<char, bool> func_0;

		internal bool method_0(char char_0)
		{
			return char_0 == '-';
		}
	}

	public int DecimalPlaces;

	public string FormatedText;

	public decimal LastValue;

	public bool ThousandsSeparator;

	public bool allowSpace;

	public bool BackSpace;

	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private decimal decimal_0;

	private decimal decimal_1;

	public decimal MaximalValue
	{
		[CompilerGenerated]
		get
		{
			return decimal_0;
		}
		[CompilerGenerated]
		set
		{
			decimal_0 = value;
		}
	}

	public decimal MinimalValue
	{
		[CompilerGenerated]
		get
		{
			return decimal_1;
		}
		[CompilerGenerated]
		set
		{
			decimal_1 = value;
		}
	}

	public int SetDecimalPlaces
	{
		get
		{
			return DecimalPlaces;
		}
		set
		{
			DecimalPlaces = value;
			if (value != 0)
			{
				Text = Class16.smethod_0(1649117881) + new string('0', value);
				FormatedText = Class16.smethod_0(1649117890);
				for (int i = 0; i < value; i++)
				{
					FormatedText += Class16.smethod_0(1648924112);
				}
				FormatedText += Class16.smethod_0(1648908132);
			}
			else
			{
				Text = Text.Split(',')[0];
			}
		}
	}

	public void FormatValue()
	{
		if (ThousandsSeparator && DecimalPlaces != 0)
		{
			Text = string.Format(FormatedText, decimal.Parse(Text.Replace(Class16.smethod_0(1649117873), string.Empty)));
		}
	}

	public void SetButtonsNames(string s1, string s2)
	{
		string_0 = s1;
		string_1 = s2;
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern IntPtr GetFocus();

	protected override void OnEnter(EventArgs eventArgs_0)
	{
		base.OnEnter(eventArgs_0);
		try
		{
			LastValue = Convert.ToDecimal(Text);
		}
		catch
		{
		}
	}

	protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
	{
		base.OnKeyDown(keyEventArgs_0);
		if (keyEventArgs_0.Control & (keyEventArgs_0.KeyCode == Keys.A))
		{
			SelectAll();
		}
	}

	protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
	{
		base.OnKeyPress(keyPressEventArgs_0);
		if (keyPressEventArgs_0.KeyChar != '\b')
		{
			BackSpace = true;
			NumberFormatInfo numberFormat = CultureInfo.CurrentCulture.NumberFormat;
			string numberDecimalSeparator = numberFormat.NumberDecimalSeparator;
			string numberGroupSeparator = numberFormat.NumberGroupSeparator;
			string negativeSign = numberFormat.NegativeSign;
			string text = keyPressEventArgs_0.KeyChar.ToString();
			if (!char.IsDigit(keyPressEventArgs_0.KeyChar) && !text.Equals(numberDecimalSeparator) && !text.Equals(numberGroupSeparator) && !text.Equals(negativeSign) && keyPressEventArgs_0.KeyChar != '\b' && (!allowSpace || keyPressEventArgs_0.KeyChar != ' '))
			{
				keyPressEventArgs_0.Handled = true;
			}
		}
	}

	protected override void OnLeave(EventArgs eventArgs_0)
	{
		Control control = Control.FromHandle(GetFocus());
		try
		{
			if (Convert.ToDecimal(Text) < MinimalValue)
			{
				Text = MinimalValue.ToString();
			}
		}
		catch
		{
		}
		if (control.Name.ToString().Length == 0)
		{
			return;
		}
		string text = control.Name.ToString();
		if (!(text != string_0) || !(text != string_1))
		{
			return;
		}
		if (string.IsNullOrWhiteSpace(Text))
		{
			Text = Class16.smethod_0(1649117881) + new string('0', DecimalPlaces);
		}
		if (Text.Where(Class253.class253_0.method_0).Count() > 1)
		{
			Text = LastValue.ToString();
		}
		base.OnLeave(eventArgs_0);
		if (ThousandsSeparator && DecimalPlaces != 0)
		{
			if (Text.Contains(Class16.smethod_0(1648928028)))
			{
				string[] array = Text.Split(',');
				Text = array[0] + Class16.smethod_0(1648928028) + array[1];
			}
			Text = string.Format(FormatedText, decimal.Parse(Text.Replace(Class16.smethod_0(1649117873), string.Empty)));
		}
	}

	protected override void OnTextChanged(EventArgs eventArgs_0)
	{
		base.OnTextChanged(eventArgs_0);
		if (DecimalPlaces == 0 && Text.Contains(Class16.smethod_0(1648928028)))
		{
			Text = Text.Remove(Text.IndexOf(','), 1);
		}
	}
}
