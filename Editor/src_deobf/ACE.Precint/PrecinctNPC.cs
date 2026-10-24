using System.Runtime.CompilerServices;

namespace ACE.Precint;

public class PrecinctNPC
{
	private string string_0 = string.Empty;

	private PrecinctVector3 precinctVector3_0 = new PrecinctVector3();

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public PrecinctVector3 position
	{
		[CompilerGenerated]
		get
		{
			return precinctVector3_0;
		}
		[CompilerGenerated]
		set
		{
			precinctVector3_0 = value;
		}
	}

	public string ToLine()
	{
		return Class16.smethod_0(1648904453) + Name + Class16.smethod_0(1649191300) + position.ToStringSpaced();
	}

	public PrecinctNPC Clone()
	{
		return new PrecinctNPC
		{
			Name = Name,
			position = position.Clone()
		};
	}
}
