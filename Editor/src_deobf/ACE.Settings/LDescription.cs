using System.ComponentModel;
using ACE.Classes;

namespace ACE.Settings;

public class LDescription : DescriptionAttribute
{
	public static TextStorage Texts;

	private string string_0;

	public LDescription(string propertyName)
	{
		string_0 = propertyName;
	}
}
