using System;
using System.Text;

namespace ACE.Elements.eListConversation;

public class eQuestion
{
	public int QuestionID;

	public int Control;

	public int QuestionTextLength;

	public byte[] QuestionText;

	public int ChoiceQount;

	public eChoice[] Choices;

	public string GetText()
	{
		string result = Encoding.GetEncoding(Class16.smethod_0(1649074210)).GetString(QuestionText);
		GC.KeepAlive(this);
		return result;
	}

	public void SetText(string Value)
	{
		QuestionTextLength = (int)((nint)(QuestionText = Encoding.GetEncoding(Class16.smethod_0(1649074210)).GetBytes(Value + Class16.smethod_0(1648938185))).LongLength / 2);
	}
}
