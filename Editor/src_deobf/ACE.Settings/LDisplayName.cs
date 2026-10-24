using System.ComponentModel;
using ACE.Classes;

namespace ACE.Settings;

public class LDisplayName : DisplayNameAttribute
{
	public static TextStorage Texts;

	private string string_0;

	public LDisplayName(string propertyName)
	{
		string_0 = propertyName;
	}
}
