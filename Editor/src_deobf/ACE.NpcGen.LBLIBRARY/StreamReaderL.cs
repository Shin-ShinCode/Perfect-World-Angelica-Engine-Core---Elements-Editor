using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACE.NpcGen.LBLIBRARY;

public class StreamReaderL : StreamReader
{
	public StreamReaderL(string path, Encoding encoding_0)
		: base(path, encoding_0)
	{
	}

	public string ReadWhile(string string_0, List<string> below)
	{
		string text = ReadLine();
		if (text.StartsWith(string_0))
		{
			return text;
		}
		below?.Add(text);
		return ReadWhile(string_0, below);
	}
}
