using System.ComponentModel;

namespace ACE.AIPolicyEditor.AIPolicy.Operations;

public class LocalizedCategoryAttribute : CategoryAttribute
{
	public LocalizedCategoryAttribute(string categoryKey)
		: base(categoryKey)
	{
	}

	protected override string GetLocalizedString(string value)
	{
		string localizedString = MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648938914) + value);
		return localizedString ?? value;
	}
}
