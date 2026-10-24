using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using ACE.Classes;

namespace ACE.sTASKedit.Classes;

public class Settings
{
	public static Fields Fields;

	public static string XMLFileName = Application.StartupPath + Class16.smethod_0(1649254441);

	public static void WriteXml()
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(Fields), typeof(Fields).GetNestedTypes());
		TextWriter textWriter = new StreamWriter(XMLFileName);
		try
		{
			xmlSerializer.Serialize(textWriter, Fields);
		}
		finally
		{
			((IDisposable)textWriter).Dispose();
		}
	}

	public static void ReadXml()
	{
		Fields = new Fields();
		if (!File.Exists(XMLFileName))
		{
			return;
		}
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Fields), typeof(Fields).GetNestedTypes());
			TextReader textReader = new StreamReader(XMLFileName);
			try
			{
				if (xmlSerializer.Deserialize(textReader) is Fields fields)
				{
					Fields = fields;
				}
			}
			finally
			{
				((IDisposable)textReader).Dispose();
			}
		}
		catch
		{
		}
	}

	public static void CheckLanguage()
	{
		CultureInfo installedUICulture = CultureInfo.InstalledUICulture;
		string twoLetterISOLanguageName = installedUICulture.TwoLetterISOLanguageName;
		Fields fields;
		int language;
		if (Fields.Language == -1)
		{
			fields = Fields;
			if (twoLetterISOLanguageName != null)
			{
				int length = twoLetterISOLanguageName.Length;
				if (length == 2)
				{
					switch (twoLetterISOLanguageName[0])
					{
					case 'm':
						if (!(twoLetterISOLanguageName == Class16.smethod_0(1648907719)))
						{
							break;
						}
						goto IL_0082;
					case 'i':
						if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932143)))
						{
							break;
						}
						goto IL_0082;
					case 'z':
						if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932081)))
						{
							break;
						}
						language = 2;
						goto IL_0123;
					case 'p':
						if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932116)))
						{
							break;
						}
						language = 3;
						goto IL_0123;
					case 'r':
						if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932072)))
						{
							break;
						}
						goto IL_0107;
					case 'u':
						if (!(twoLetterISOLanguageName == Class16.smethod_0(1648907710)))
						{
							break;
						}
						goto IL_0107;
					case 'v':
						{
							if (!(twoLetterISOLanguageName == Class16.smethod_0(1648932134)))
							{
								break;
							}
							language = 4;
							goto IL_0123;
						}
						IL_0107:
						language = 1;
						goto IL_0123;
						IL_0082:
						language = 5;
						goto IL_0123;
					}
				}
			}
			language = 0;
			goto IL_0123;
		}
		goto IL_012b;
		IL_012b:
		if (twoLetterISOLanguageName == Class16.smethod_0(1648932081) && Fields.Language != 2 && DKBox.Show(TextStorage.Msg(Class16.smethod_0(1649254469)), TextStorage.Msg(Class16.smethod_0(1649254488)), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
		{
			Fields.Language = 2;
		}
		return;
		IL_0123:
		fields.Language = language;
		goto IL_012b;
	}
}
