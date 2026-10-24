using System.Text;

namespace ACE.EcmEditor.Services;

internal static class EcmStringConverter
{
	public static string ToGBK(this byte[] value)
	{
		try
		{
			string text = Encoding.GetEncoding(936).GetString(value);
			int num = text.IndexOf('\0');
			if (num >= 0)
			{
				text = text.Substring(0, num);
			}
			return text;
		}
		catch
		{
			return Encoding.UTF8.GetString(value).Split(default(char))[0];
		}
	}
}
