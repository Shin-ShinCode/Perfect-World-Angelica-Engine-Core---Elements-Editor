using System;
using System.Text;

namespace ACE.Elements.eListConversation;

public class eChoice
{
	public int Control;

	public byte[] ChoiceText;

	public int Id;

	public string GetText()
	{
		string result = Encoding.GetEncoding(Class16.smethod_0(1649074210)).GetString(ChoiceText);
		GC.KeepAlive(this);
		return result;
	}

	public void SetText(string Value)
	{
		Encoding encoding = Encoding.GetEncoding(Class16.smethod_0(1649074210));
		byte[] array = new byte[128];
		byte[] bytes = encoding.GetBytes(Value);
		int num = bytes.Length;
		int num2 = array.Length;
		if (num2 > num)
		{
			Array.Copy(bytes, array, num);
		}
		else
		{
			Array.Copy(bytes, array, num2);
		}
		ChoiceText = array;
	}
}
