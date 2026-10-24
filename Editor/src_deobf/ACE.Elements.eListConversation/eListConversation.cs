using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ACE.Elements.eListConversation;

public class eListConversation : IDisposable
{
	public int DialogCount;

	public eDialog[] Dialogs;

	public eListConversation(byte[] Bytes)
	{
		MemoryStream memoryStream = new MemoryStream(Bytes);
		BinaryReader binaryReader = new BinaryReader(memoryStream);
		int num = (DialogCount = binaryReader.ReadInt32());
		Dialogs = new eDialog[num];
		int num2 = 0;
		if (0 < num)
		{
			do
			{
				Dialogs[num2] = new eDialog();
				Dialogs[num2].DialogID = binaryReader.ReadInt32();
				Dialogs[num2].DialogName = binaryReader.ReadBytes(128);
				Dialogs[num2].QuestionCount = binaryReader.ReadInt32();
				eDialog eDialog2 = Dialogs[num2];
				eDialog2.Questions = new eQuestion[eDialog2.QuestionCount];
				int num3 = 0;
				if (0 < Dialogs[num2].QuestionCount)
				{
					do
					{
						Dialogs[num2].Questions[num3] = new eQuestion();
						Dialogs[num2].Questions[num3].QuestionID = binaryReader.ReadInt32();
						Dialogs[num2].Questions[num3].Control = binaryReader.ReadInt32();
						Dialogs[num2].Questions[num3].QuestionTextLength = binaryReader.ReadInt32();
						Dialogs[num2].Questions[num3].QuestionText = binaryReader.ReadBytes(Dialogs[num2].Questions[num3].QuestionTextLength << 1);
						Dialogs[num2].Questions[num3].ChoiceQount = binaryReader.ReadInt32();
						eQuestion eQuestion2 = Dialogs[num2].Questions[num3];
						eQuestion2.Choices = new eChoice[eQuestion2.ChoiceQount];
						int num4 = 0;
						if (0 < Dialogs[num2].Questions[num3].ChoiceQount)
						{
							do
							{
								Dialogs[num2].Questions[num3].Choices[num4] = new eChoice();
								Dialogs[num2].Questions[num3].Choices[num4].Control = binaryReader.ReadInt32();
								Dialogs[num2].Questions[num3].Choices[num4].ChoiceText = binaryReader.ReadBytes(128);
								Dialogs[num2].Questions[num3].Choices[num4].Id = binaryReader.ReadInt32();
								num4++;
							}
							while (num4 < Dialogs[num2].Questions[num3].ChoiceQount);
						}
						num3++;
					}
					while (num3 < Dialogs[num2].QuestionCount);
				}
				num2++;
			}
			while (num2 < DialogCount);
		}
		binaryReader.Close();
		memoryStream.Close();
	}

	private void method_0()
	{
		DialogCount = 0;
		Dialogs = null;
	}

	public int GetIndexByDialogID(int dialogID)
	{
		if (Dialogs == null)
		{
			return -1;
		}
		int num = 0;
		while (true)
		{
			if (num < DialogCount)
			{
				if (Dialogs[num].DialogID == dialogID)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	public int GetDialogIDByIndex(int index)
	{
		if (Dialogs != null && index >= 0 && index < DialogCount)
		{
			return Dialogs[index].DialogID;
		}
		return -1;
	}

	public string GetDialogNameByDialogID(int dialogID)
	{
		int indexByDialogID = GetIndexByDialogID(dialogID);
		if (indexByDialogID < 0)
		{
			return null;
		}
		return Dialogs[indexByDialogID].GetText();
	}

	public string GetDialogNameByIndex(int index)
	{
		if (Dialogs != null && index >= 0 && index < DialogCount)
		{
			return Dialogs[index].GetText();
		}
		return null;
	}

	public byte[] GetBytes()
	{
		MemoryStream memoryStream = new MemoryStream(DialogCount);
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(DialogCount);
		int num = 0;
		if (0 < DialogCount)
		{
			eDialog[] dialogs = Dialogs;
			do
			{
				binaryWriter.Write(dialogs[num].DialogID);
				binaryWriter.Write(Dialogs[num].DialogName);
				binaryWriter.Write(Dialogs[num].QuestionCount);
				int num2 = 0;
				dialogs = Dialogs;
				eDialog eDialog2 = dialogs[num];
				if (0 < eDialog2.QuestionCount)
				{
					eQuestion[] questions = eDialog2.Questions;
					do
					{
						binaryWriter.Write(questions[num2].QuestionID);
						binaryWriter.Write(Dialogs[num].Questions[num2].Control);
						binaryWriter.Write(Dialogs[num].Questions[num2].QuestionTextLength);
						binaryWriter.Write(Dialogs[num].Questions[num2].QuestionText);
						binaryWriter.Write(Dialogs[num].Questions[num2].ChoiceQount);
						int num3 = 0;
						questions = Dialogs[num].Questions;
						eQuestion eQuestion2 = questions[num2];
						if (0 < eQuestion2.ChoiceQount)
						{
							do
							{
								binaryWriter.Write(eQuestion2.Choices[num3].Control);
								binaryWriter.Write(Dialogs[num].Questions[num2].Choices[num3].ChoiceText);
								binaryWriter.Write(Dialogs[num].Questions[num2].Choices[num3].Id);
								num3++;
								questions = Dialogs[num].Questions;
								eQuestion2 = questions[num2];
							}
							while (num3 < eQuestion2.ChoiceQount);
						}
						num2++;
						dialogs = Dialogs;
					}
					while (num2 < dialogs[num].QuestionCount);
				}
				num++;
			}
			while (num < DialogCount);
		}
		byte[] result = memoryStream.ToArray();
		binaryWriter.Close();
		memoryStream.Close();
		return result;
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			DialogCount = 0;
			Dialogs = null;
		}
	}

	public virtual void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
	}
}
