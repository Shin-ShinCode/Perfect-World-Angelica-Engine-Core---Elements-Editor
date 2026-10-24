namespace ACE.Classes;

public class SkillInfo
{
	public int id;

	public string Name;

	public string Desciption;

	public SkillInfo(int id, string Name)
	{
		this.id = id;
		this.Name = Name;
	}

	public SkillInfo(int id, string Name, string Description)
	{
		this.id = id;
		if (string.IsNullOrWhiteSpace(Name))
		{
			Name = Desciption;
		}
		this.Name = Name;
		Desciption = Description;
	}
}
