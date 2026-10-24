using System.Drawing;

namespace ACE.NpcGen;

public class HighlightInfo
{
	public int highlight_id;

	public string highlight_text;

	public string[] splitted_text;

	public Color color;

	public HighlightInfo(int highlight_id, string highlight_text, string[] splitted_text, Color color)
	{
		this.highlight_id = highlight_id;
		this.highlight_text = highlight_text;
		this.splitted_text = splitted_text;
		this.color = color;
	}

	public HighlightInfo(int highlight_id, Color color)
	{
		this.highlight_id = highlight_id;
		this.color = color;
	}
}
