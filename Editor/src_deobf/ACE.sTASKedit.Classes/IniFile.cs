using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ACE.sTASKedit.Classes;

public class IniFile
{
	private string string_0;

	public IniFile(string IniPath)
	{
		string_0 = new FileInfo(IniPath).FullName.ToString();
	}

	[DllImport("kernel32")]
	private static extern long WritePrivateProfileString(string string_1, string string_2, string string_3, string string_4);

	[DllImport("kernel32")]
	private static extern int GetPrivateProfileString(string string_1, string string_2, string string_3, StringBuilder stringBuilder_0, int int_0, string string_4);

	public string Read(string Section, string Key)
	{
		StringBuilder stringBuilder = new StringBuilder(255);
		GetPrivateProfileString(Section, Key, string.Empty, stringBuilder, 255, string_0);
		return stringBuilder.ToString();
	}

	public void Write(string Section, string Key, string Value)
	{
		WritePrivateProfileString(Section, Key, Value, string_0);
	}

	public bool KeyExists(string Key, string Section = null)
	{
		return Read(Section, Key).Length > 0;
	}
}
