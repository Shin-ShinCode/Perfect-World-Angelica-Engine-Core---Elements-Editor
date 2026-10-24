using System.Drawing;

namespace ACE.sTASKedit.Classes;

public class Fields
{
	public bool EnableChangeConf;

	public bool EnableShowTips = true;

	public int PWDBLang;

	public bool EnableBackups = true;

	public bool EnableToClipboard = true;

	public int Language = -1;

	public bool EnableShowDigits;

	public bool EnableShowPercents;

	public bool EnableAutoLoadTasks;

	public bool EnableAutoLoadElements;

	public bool EnableShowInfo = true;

	public bool EnableSetNewID = true;

	public bool EnableAutoDetectNewID = true;

	public bool EnableShowMarks = true;

	public bool EnableShowGreeting = true;

	public bool IgnoreColorCod;

	public bool UseAce = true;

	public bool ShowOriginalFieldNames;

	public Size PWDBWindow_Size = new Size(0, 0);

	public Size SelectIdWindow_Size = new Size(0, 0);

	public Size SelectItemIdWindow_Size = new Size(0, 0);

	public Size SelectBuffIdWindow_Size = new Size(0, 0);

	public Size SelectWorldIdWindow_Size = new Size(0, 0);

	public Size SelectSkillIdWindow_Size = new Size(0, 0);

	public Size SelectTaskDescriptionIdWindow_Size = new Size(0, 0);

	public Size SelectRelayStationIdWindow_Size = new Size(0, 0);

	public Size SelectTransformedFormIdWindow_Size = new Size(0, 0);

	public Size SelectGrowthTargetWindow_Size = new Size(0, 0);

	public FilesPath FilesPath = new FilesPath();

	public TranslationSettings TranslationSettings = new TranslationSettings();
}
