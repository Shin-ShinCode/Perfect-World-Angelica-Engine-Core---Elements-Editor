using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ACE.Classes.ACE;

public record ListData
{
	public string ListName
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
	}

	public Dictionary<string, string> Fields
	{
		[CompilerGenerated]
		get
		{
			return dictionary_0;
		}
	}

	private readonly string string_0;

	private readonly Dictionary<string, string> dictionary_0;

	public ListData(string ListName, string[] ElementFields, string[] ElementValues)
	{
		string_0 = ListName;
		for (int i = 0; i < ElementFields.Length; i++)
		{
			string key = ElementFields[i];
			string value = ElementValues[i];
			Fields[key] = value;
		}
	}

	[CompilerGenerated]
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(Class16.smethod_0(1648907384));
		stringBuilder.Append(Class16.smethod_0(1648907407));
		if (PrintMembers(stringBuilder))
		{
			stringBuilder.Append(' ');
		}
		stringBuilder.Append('}');
		return stringBuilder.ToString();
	}

	[CompilerGenerated]
	protected virtual bool PrintMembers(StringBuilder builder)
	{
		RuntimeHelpers.EnsureSufficientExecutionStack();
		builder.Append(Class16.smethod_0(1648907409));
		builder.Append((object)ListName);
		builder.Append(Class16.smethod_0(1648907427));
		builder.Append(Fields);
		return true;
	}
}
