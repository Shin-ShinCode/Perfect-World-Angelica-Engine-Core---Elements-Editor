using ACE.Protectors;

namespace ACE.Classes;

public class ParamsClass
{
	public class OUT_EDITORS
	{
		public string TasksEditor;

		public string NPCGenEditor;
	}

	public class SSH_Data
	{
		public string _pscp;

		public string _putty;

		public string _plink;

		public string ToolsDirectory;

		public string Address;

		public string Port;

		public string Login;

		public string Pass;

		public string ElementsPath;

		public string NPCGenPath;

		public string GShopPath;

		public string GShop1Path;

		public string GShop2Path;

		public string GShop3Path;

		public string _restart_txt;

		public string RestartCommand;

		public string CustomCommand;

		public bool UseCompression;

		public string _custom_txt;

		public SERVER_BUTTON_ACTIONS ServerButtonAction;

		public string ConfigPath;

		public string AIPolicyPath;

		public string DomainSevPath;

		public string Domain2SevPath;

		public string TasksPath;

		public string ExtraDropPath;
	}

	public PCK_KEY_MODE PckKeyMode;

	public string PckProtectedKey;

	public int PckKey1;

	public int PckKey2;

	public int MaxBackupsCount;

	public int ToolTipFieldsNumLimit;

	public bool LoadLastElements;

	public bool LoadLastList;

	public bool DontChangeUniqueID;

	public bool LoadLastNPCGen;

	public bool AutoCheckID;

	public bool ShowItemsColor;

	public bool ShowMobsColor;

	public bool UseAlternativeRecipesNames;

	public bool ShowRealValues;

	public bool UseAddonsFilter;

	public bool UseSkillsFilter;

	public bool ShowContactValues;

	public bool ShowUnknownFields;

	public bool UseAltFont;

	public bool DisableFastSearch;

	public bool FirstListIndexIs1;

	public bool AutoUpdate;

	public bool WarnWhenDeletingItemWithEntries;

	public bool ExportIconsWithName;

	public bool PreviewRefine;

	public bool IgnoreApiFileNameDifference;

	public bool CompressBackups;

	public bool SaveActionsHistory;

	public bool WarnAboutUnsavedElements;

	public bool SaveDescAndColors;

	public bool SendErrorsAutomatically;

	public bool ShowModelPreview;

	public int ActionsHistoryLimit;

	public int AHistoryDropDownMenuLimit;

	public bool ShowMainPreviewWindow;

	public int MinMobLevel;

	public int MaxMobLevel;

	public bool ShowIcons;

	public bool ShowThumbs;

	public bool SortIcons;

	public bool EnableCustomCursors = true;

	public int ThumbSize;

	public int FieldHeight;

	public string IconsPath;

	public string IconsNamesPath;

	public string ColorsPath;

	public string DescriptionsPath;

	public string PathDataPath;

	public string DefaultCreator;

	public int FieldDoubleClickAction;

	public int NewItemsPlace;

	public string ShopDescPath;

	public string ShopdirLua;

	public string SurfacesPckDir;

	public string ElementsPath;

	public string TasksPath;

	public string NPCGenPath;

	public string GShopPath;

	public string GShop1Path;

	public string GShop2Path;

	public string GShop3Path;

	public string AIPolicyPath;

	public string GShopSevPath;

	public string GShopSev1Path;

	public string GShopSev2Path;

	public string GShopSev3Path;

	public string DomainSevPath;

	public string Domain2SevPath;

	public string ExtraDropSevPath;

	public bool UsePck;

	public string FileIconTitle;

	public int PreviewRefineLevel;

	public string ClientPath;

	public string ConfigsPckPath;

	public string SurfacesPckPath;

	public string ModelsPckPath;

	public OUT_EDITORS OutEditorsPath;

	public SSH_Data SSH;

	public GAMES Game;

	public string[] PckFiles;

	public ParamsClass()
	{
		SSH = new SSH_Data();
		OutEditorsPath = new OUT_EDITORS();
	}

	public void AutoDetectFileIconTitle()
	{
		switch (Game)
		{
		case GAMES.FW:
			FileIconTitle = Class16.smethod_0(1648899542);
			break;
		case GAMES.PW:
			FileIconTitle = Class16.smethod_0(1648899513);
			break;
		default:
			FileIconTitle = Class16.smethod_0(1648899576);
			break;
		case GAMES.SW:
		case GAMES.ROG:
		case GAMES.TOS:
			FileIconTitle = Class16.smethod_0(1648899555);
			break;
		}
	}
}
