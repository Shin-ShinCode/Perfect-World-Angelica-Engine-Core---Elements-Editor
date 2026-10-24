namespace ACE.PWMap;

public interface IPwMapChangeLogListener
{
	void OnChangeLogUpdated(PwMapChangeLog log);
}
