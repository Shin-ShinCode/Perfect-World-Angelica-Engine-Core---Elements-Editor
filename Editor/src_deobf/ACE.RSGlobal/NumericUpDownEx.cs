using System.Windows.Forms;

namespace ACE.RSGlobal;

public class NumericUpDownEx : NumericUpDown
{
	public bool bDisableMouseWheel = true;

	public bool IsPercent;

	protected override void WndProc(ref Message message_0)
	{
		if (!bDisableMouseWheel || message_0.Msg != 522)
		{
			base.WndProc(ref message_0);
		}
	}

	protected override void UpdateEditText()
	{
		if (RSGlobal.antirecurse_UpdateEditText_NumericUpDownEx_RSGlobal || base.ChangingText)
		{
			return;
		}
		base.ChangingText = true;
		string universalFloated = Text;
		if (string.IsNullOrWhiteSpace(universalFloated))
		{
			return;
		}
		RSGlobal.antirecurse_UpdateEditText_NumericUpDownEx_RSGlobal = true;
		int num;
		if (IsPercent)
		{
			string text = universalFloated;
			if (text[text.Length - 1] == '%' || base.UserEdit)
			{
				num = 1;
				goto IL_005f;
			}
		}
		num = 0;
		goto IL_005f;
		IL_005f:
		bool isPercent;
		if ((isPercent = (byte)num != 0) || base.DecimalPlaces > 0)
		{
			universalFloated = NumberConverter.GetUniversalFloated(universalFloated, isPercent);
		}
		if (universalFloated != Text)
		{
			Text = universalFloated;
		}
		base.ChangingText = false;
		base.UpdateEditText();
		if (IsPercent)
		{
			base.ChangingText = true;
			decimal value = base.Value;
			int num2 = 2;
			decimal num3 = 0.0001m;
			num2 = ((value < num3) ? 4 : num2);
			string text2 = RSGlobal.ToPercent(value, num2);
			Text = text2;
		}
		RSGlobal.antirecurse_UpdateEditText_NumericUpDownEx_RSGlobal = false;
	}
}
