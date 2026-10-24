using System.ComponentModel;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class LocalizedDisplayNameAttribute : DisplayNameAttribute
{
	private string string_0;

	public override string DisplayName
	{
		get
		{
			string localizedString = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938914) + method_0());
			return localizedString ?? method_0();
		}
	}

	public LocalizedDisplayNameAttribute(string nameKey)
		: base(nameKey)
	{
		method_1(nameKey);
	}

	private string method_0()
	{
		return string_0;
	}

	private void method_1(string string_1)
	{
		string_0 = string_1;
	}
}
