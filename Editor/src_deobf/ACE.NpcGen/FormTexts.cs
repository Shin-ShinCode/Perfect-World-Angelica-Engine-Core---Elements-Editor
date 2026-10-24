using System.Collections.Generic;

namespace ACE.NpcGen;

public class FormTexts
{
	public string FormName;

	public IDictionary<string, string[]> Controls;

	public IDictionary<string, string[]> ToolTips;

	public FormTexts(string FormName)
	{
		this.FormName = FormName;
		Controls = new Dictionary<string, string[]>();
		ToolTips = new Dictionary<string, string[]>();
	}
}
