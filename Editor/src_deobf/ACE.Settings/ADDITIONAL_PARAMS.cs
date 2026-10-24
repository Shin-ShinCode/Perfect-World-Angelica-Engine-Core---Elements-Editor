using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using ACE.Classes;
using ACE.Cpk;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;

namespace ACE.Settings;

[Serializable]
public class ADDITIONAL_PARAMS
{
	public Color[] colors;

	public Dictionary<int, int> CustomAddonsTypes;

	public Dictionary<LISTandID, int> ElementsFavoriteItems;

	public Dictionary<int, int[]> ElementsRecentItems;

	public vITEMPOS[] ElementsRecentItemsGlobal;

	[NonSerialized]
	public ObservableCollection<ITEMS_CATEGORY> ItemsCategories;

	public vFIELDPOS LatestFieldPos;

	public ADDITIONAL_PARAMS PrevParams;

	private bool _AllowToEditAddonsId;

	private int _AppVersion;

	private bool _AutoDownloadUpdates;

	private bool _AutoSaveFieldTypes;

	private bool _AutoSetUniqueID;

	private bool _BackupItemColor;

	private string _BackupItemColorDir;

	private bool _BackupItemDesc;

	private string _BackupItemDescDir;

	private bool _bShowItemIdOnHint;

	private bool _ConvertVersion12To7WhenSendToServer_PW;

	private bool _ConvertVersion29To27WhenSendToServer_PW;

	private uint _CurrentGShopSaleOption;

	private string _DialogInitialDirectory;

	private bool _DisableAllHints;

	private bool _DisableIconsDictCache;

	private bool _DisableNewIconsWindow;

	private bool _DisableParallelElementsLoading;

	private bool _DisableACEwatemark;

	private bool _DisableShopPriceTaxCalculation;

	private bool _DisableTooHighIdErrors;

	private int _Domain2TimeBetweenMaps;

	private bool _DontLoadLuaFromPck;

	private bool _DontOpenFieldTypesAfterSaving;

	private bool _DontRandomizeNpcTalk;

	private bool _DontUpdateRealTimestamp;

	private int _EditorSplitterDistance;

	private string _ElementsFileName2;

	private string _ElementsFileName3;

	private bool _AutoLoadElements2Data;

	private string _Cfg2DefaultPath;

	private vITEMPOS[] _ElementsShortcuts;

	private bool _EnableFieldNameChange;

	private bool _EnableFieldsTabs;

	private bool _EnableSimpleProtection;

	private bool _ExperimentalIcons;

	private int _FavoriteItemsLimit;

	private Font _FieldsFont;

	private bool _HighlightLiveSearchMatches;

	private int _HintIdDuplicatesLimit;

	private bool _IgnoreItemCountOnLoading;

	private bool _IncludeQuestFromSubitems;

	private bool _IncludeQuestIntoItemHint;

	private Font _ItemsFont;

	private bool _ItemsImportCompatibilityAce;

	private int _ItemsListIdColumnWidth;

	private int _ItemsListNameColumnWidth;

	private int _ItemsListRefCountColumnWidth;

	private int _LineIconsCount;

	private int _ListHintItemsLimit;

	private int _LiveSearchMatchesLimit;

	private bool _LoadFieldPos;

	private bool _LockFieldsScales;

	private string _ModelsPath;

	private string _ModelsPckBaseName;

	private string _MoneyFields;

	private string _NewTitleGiftIcon;

	private string[] _NpcGenPaths;

	private bool _PasteAutoSetUniqueID;

	private DEPENDENCIES_PASTE_MODE _PasteDependenciesMode;

	private bool _PasteWithDependencies;

	private bool _PasteWithDesc;

	private string[] _PreinctPaths;

	private string _ProjectName;

	private string _PWDBLang;

	private PW_GSHOP_VERSION _PWGShopDefaultVersion;

	private int _RecentElementsLimit;

	private int _RecentItemsLimit;

	private int _RecentProfilesLimit;

	private string _RestoredElementsFN;

	private bool _SaveGshopSevIntoCurrentDir;

	private string _Server7zCommand;

	private string _ServerPath;

	private bool _ShowHintsInPinnedHint;

	private bool _ShowItemAmountInGshop;

	private bool _ShowItemCountInTabTitle;

	private bool _ShowLicenseEmailInsteadOfName;

	private bool _ShowOriginalFieldsToo;

	private bool _ShowPercentageInMainWindow;

	private bool _ShowRefCountInItemList;

	private bool _ShowSubitemsCountInListView;

	private int _TasksHintItemsLimit;

	private int _ToolTipReferencesNumLimit;

	private bool _UpdateElementsTimeStamp;

	private bool _UseAutoSizeForNewIconsWindow;

	private bool _UseBetaUpdateChannel;

	private bool _UseInvariantCulture;

	private bool _UseNewLineWhenCopyFields;

	private bool _UseSimpleFolderPicker;

	private bool _UseSmartUniqueID;

	private bool _ViewOnlyUniqueReferences;

	private bool _WaitBeforeLoadIcons;

	private string _WorldTargetsPath;

	private string _OpenAIApiKey;

	private string _OpenAIBaseUrl;

	[LCategory("CatMisc", -1)]
	[LDisplayName("AllowToEditAddonsId")]
	[LDescription("AllowToEditAddonsId")]
	public bool AllowToEditAddonsId
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _AllowToEditAddonsId;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_AllowToEditAddonsId = value;
		}
	}

	[Browsable(false)]
	public int AppVersion
	{
		get
		{
			return _AppVersion;
		}
		set
		{
			_AppVersion = value;
		}
	}

	[LDisplayName("AutoDownloadUpdates")]
	[LDescription("AutoDownloadUpdates")]
	[LCategory("CatMain", 1)]
	public bool AutoDownloadUpdates
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _AutoDownloadUpdates;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_AutoDownloadUpdates = value;
		}
	}

	[LDescription("AutoSaveFieldTypes")]
	[Browsable(false)]
	[LCategory("CatDevelopment", -2)]
	[LDisplayName("AutoSaveFieldTypes")]
	public bool AutoSaveFieldTypes
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _AutoSaveFieldTypes;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_AutoSaveFieldTypes = value;
		}
	}

	[LDisplayName("AutoSetUniqueID")]
	[LCategory("CatElementsEditor")]
	[LDescription("AutoSetUniqueID")]
	public bool AutoSetUniqueID
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _AutoSetUniqueID;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_AutoSetUniqueID = value;
		}
	}

	[LDisplayName("BackupItemColor")]
	[LDescription("BackupItemColor")]
	[LCategory("CatFiles")]
	public bool BackupItemColor
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _BackupItemColor;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_BackupItemColor = value;
		}
	}

	[LCategory("CatFiles")]
	[LDisplayName("BackupItemColorDir")]
	[LDescription("BackupItemColorDir")]
	public string BackupItemColorDir
	{
		get
		{
			return _BackupItemColorDir;
		}
		set
		{
			_BackupItemColorDir = value;
		}
	}

	[LDisplayName("BackupItemDesc")]
	[LDescription("BackupItemDesc")]
	[LCategory("CatFiles")]
	public bool BackupItemDesc
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _BackupItemDesc;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_BackupItemDesc = value;
		}
	}

	[LDescription("BackupItemDescDir")]
	[LDisplayName("BackupItemDescDir")]
	[LCategory("CatFiles")]
	public string BackupItemDescDir
	{
		get
		{
			return _BackupItemDescDir;
		}
		set
		{
			_BackupItemDescDir = value;
		}
	}

	[LDescription("bShowItemIdOnHint")]
	[LCategory("CatHints")]
	[LDisplayName("bShowItemIdOnHint")]
	public bool bShowItemIdOnHint
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _bShowItemIdOnHint;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_bShowItemIdOnHint = value;
		}
	}

	[LDisplayName("ItemColors")]
	[LDescription("ItemColors")]
	[LCategory("CatMisc", -1)]
	public Color[] Colors
	{
		get
		{
			return colors;
		}
		set
		{
			colors = value;
		}
	}

	[LDescription("ConvertVersion12To7WhenSendToServer_PW")]
	[LDisplayName("ConvertVersion12To7WhenSendToServer_PW")]
	[LCategory("CatPW")]
	public bool ConvertVersion12To7WhenSendToServer_PW
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ConvertVersion12To7WhenSendToServer_PW;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ConvertVersion12To7WhenSendToServer_PW = value;
		}
	}

	[LCategory("CatPW")]
	[LDescription("ConvertVersion29To27WhenSendToServer_PW")]
	[LDisplayName("ConvertVersion29To27WhenSendToServer_PW")]
	public bool ConvertVersion29To27WhenSendToServer_PW
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ConvertVersion29To27WhenSendToServer_PW;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ConvertVersion29To27WhenSendToServer_PW = value;
		}
	}

	[LDisplayName("CurrentGShopSaleOption")]
	[LCategory("CatPW")]
	[LDescription("CurrentGShopSaleOption")]
	public uint CurrentGShopSaleOption
	{
		get
		{
			return _CurrentGShopSaleOption;
		}
		set
		{
			_CurrentGShopSaleOption = value;
		}
	}

	[Browsable(false)]
	public string DialogInitialDirectory
	{
		get
		{
			return _DialogInitialDirectory;
		}
		set
		{
			_DialogInitialDirectory = value;
		}
	}

	[LDisplayName("DisableAllHints")]
	[LDescription("DisableAllHints")]
	[LCategory("CatHints")]
	public bool DisableAllHints
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DisableAllHints;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DisableAllHints = value;
		}
	}

	[LDisplayName("DisableIconsDictCache")]
	[LDescription("DisableIconsDictCache")]
	[LCategory("CatSystem", -2)]
	public bool DisableIconsDictCache
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DisableIconsDictCache;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DisableIconsDictCache = value;
		}
	}

	[LDescription("DisableNewIconsWindow")]
	[LDisplayName("DisableNewIconsWindow")]
	[LCategory("CatElementsEditor")]
	public bool DisableNewIconsWindow
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DisableNewIconsWindow;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DisableNewIconsWindow = value;
		}
	}

	[LDisplayName("DisableParallelElementsLoading")]
	[LDescription("DisableParallelElementsLoading")]
	[LCategory("CatSystem", -2)]
	public bool DisableParallelElementsLoading
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DisableParallelElementsLoading;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DisableParallelElementsLoading = value;
		}
	}

	[LDisplayName("DisableACEwatemark")]
	[LDescription("DisableACEwatemark")]
	[LCategory("CatMisc", -1)]
	public bool DisableACEwatemark
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DisableACEwatemark;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DisableACEwatemark = value;
		}
	}

	[LCategory("CatMisc", -1)]
	[LDisplayName("DisableShopPriceTaxCalculation")]
	[LDescription("DisableShopPriceTaxCalculation")]
	public bool DisableShopPriceTaxCalculation
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DisableShopPriceTaxCalculation;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DisableShopPriceTaxCalculation = value;
		}
	}

	[LDisplayName("DisableTooHighIdErrors")]
	[LCategory("CatElementsEditor")]
	[LDescription("DisableTooHighIdErrors")]
	public bool DisableTooHighIdErrors
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DisableTooHighIdErrors;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DisableTooHighIdErrors = value;
		}
	}

	[LDisplayName("Domain2TimeBetweenMaps")]
	[LCategory("CatMisc", -1)]
	[LDescription("Domain2TimeBetweenMaps")]
	[Browsable(false)]
	public int Domain2TimeBetweenMaps
	{
		get
		{
			return _Domain2TimeBetweenMaps;
		}
		set
		{
			_Domain2TimeBetweenMaps = value;
		}
	}

	[LDescription("DontLoadLuaFromPck")]
	[LDisplayName("DontLoadLuaFromPck")]
	[LCategory("CatMisc", -1)]
	public bool DontLoadLuaFromPck
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DontLoadLuaFromPck;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DontLoadLuaFromPck = value;
		}
	}

	[LDisplayName("DontOpenFieldTypesAfterSaving")]
	[LCategory("CatDevelopment", -2)]
	[LDescription("DontRandomizeNpcTalk")]
	public bool DontOpenFieldTypesAfterSaving
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DontOpenFieldTypesAfterSaving;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DontOpenFieldTypesAfterSaving = value;
		}
	}

	[LCategory("CatSystem", -2)]
	[Browsable(false)]
	[LDescription("DontRandomizeNpcTalk")]
	[LDisplayName("DontRandomizeNpcTalk")]
	public bool DontRandomizeNpcTalk
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DontRandomizeNpcTalk;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DontRandomizeNpcTalk = value;
		}
	}

	[LCategory("CatSystem", -2)]
	[LDisplayName("DontUpdateRealTimestamp")]
	[LDescription("DontUpdateRealTimestamp")]
	public bool DontUpdateRealTimestamp
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _DontUpdateRealTimestamp;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_DontUpdateRealTimestamp = value;
		}
	}

	[LCategory("CatElementsEditor")]
	[Browsable(false)]
	[LDisplayName("EditorLeftPartWidth")]
	[LDescription("EditorLeftPartWidth")]
	public int EditorSplitterDistance
	{
		get
		{
			return _EditorSplitterDistance;
		}
		set
		{
			_EditorSplitterDistance = value;
		}
	}

	[LDescription("ElementsFileName2")]
	[LDisplayName("ElementsFileName2")]
	[Browsable(false)]
	[LCategory("CatMain", 1)]
	public string ElementsFileName2
	{
		get
		{
			return _ElementsFileName2;
		}
		set
		{
			_ElementsFileName2 = value;
		}
	}

	[LDescription("ElementsFileName3")]
	[LDisplayName("ElementsFileName3")]
	[Browsable(false)]
	[LCategory("CatMain", 1)]
	public string ElementsFileName3
	{
		get
		{
			return _ElementsFileName3;
		}
		set
		{
			_ElementsFileName3 = value;
		}
	}

	[LDisplayName("AutoLoadElements2Data")]
	[LDescription("AutoLoadElements2Data")]
	[LCategory("CatFiles")]
	public bool AutoLoadElements2Data
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _AutoLoadElements2Data;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_AutoLoadElements2Data = value;
		}
	}

	[LCategory("CatFiles")]
	[LDisplayName("Cfg2DefaultPath")]
	[LDescription("Cfg2DefaultPath")]
	public string Cfg2DefaultPath
	{
		get
		{
			return _Cfg2DefaultPath;
		}
		set
		{
			_Cfg2DefaultPath = value;
		}
	}

	[Browsable(false)]
	public vITEMPOS[] ElementsShortcuts
	{
		get
		{
			return _ElementsShortcuts;
		}
		set
		{
			_ElementsShortcuts = value;
		}
	}

	[LDisplayName("EnableFieldNameChange")]
	[LCategory("CatDevelopment", -2)]
	[LDescription("EnableFieldNameChange")]
	public bool EnableFieldNameChange
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _EnableFieldNameChange;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_EnableFieldNameChange = value;
		}
	}

	[LDisplayName("EnableFieldsTabs")]
	[LCategory("CatElementsEditor")]
	[LDescription("EnableFieldsTabs")]
	public bool EnableFieldsTabs
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _EnableFieldsTabs;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_EnableFieldsTabs = value;
		}
	}

	[Browsable(false)]
	[LDescription("_simple-prot")]
	[LCategory("CatSystem", -2)]
	[LDisplayName("_simple-prot")]
	public bool EnableSimpleProtection
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _EnableSimpleProtection;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_EnableSimpleProtection = value;
		}
	}

	[LCategory("CatElementsEditor")]
	[LDescription("ExperimentalIcons")]
	[LDisplayName("ExperimentalIcons")]
	public bool ExperimentalIcons
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ExperimentalIcons;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ExperimentalIcons = value;
		}
	}

	[LDisplayName("FavoriteItemsLimit")]
	[LCategory("CatLimits")]
	[LDescription("FavoriteItemsLimit")]
	public int FavoriteItemsLimit
	{
		get
		{
			return _FavoriteItemsLimit;
		}
		set
		{
			_FavoriteItemsLimit = value;
		}
	}

	[Browsable(false)]
	[LDescription("FieldsFont")]
	[LDisplayName("FieldsFont")]
	[LCategory("CatElementsEditor")]
	public Font FieldsFont
	{
		get
		{
			return _FieldsFont;
		}
		set
		{
			_FieldsFont = value;
		}
	}

	[LCategory("CatLiveSearch")]
	[LDisplayName("HighlightLiveSearchMatches")]
	[LDescription("HighlightLiveSearchMatches")]
	public bool HighlightLiveSearchMatches
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _HighlightLiveSearchMatches;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_HighlightLiveSearchMatches = value;
		}
	}

	[LCategory("CatHints")]
	[LDescription("HintDuplicatesLimit")]
	[LDisplayName("HintIdDuplicatesLimit")]
	public int HintIdDuplicatesLimit
	{
		get
		{
			return _HintIdDuplicatesLimit;
		}
		set
		{
			_HintIdDuplicatesLimit = value;
		}
	}

	[LCategory("CatSystem", -2)]
	[LDescription("IgnoreItemCountOnLoading")]
	[LDisplayName("IgnoreItemCountOnLoading")]
	public bool IgnoreItemCountOnLoading
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _IgnoreItemCountOnLoading;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_IgnoreItemCountOnLoading = value;
		}
	}

	[LCategory("CatHints")]
	[LDescription("IncludeQuestFromSubitems")]
	[LDisplayName("IncludeQuestFromSubitems")]
	public bool IncludeQuestFromSubitems
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _IncludeQuestFromSubitems;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_IncludeQuestFromSubitems = value;
		}
	}

	[LDescription("IncludeQuestIntoItemHint")]
	[LDisplayName("IncludeQuestIntoItemHint")]
	[LCategory("CatHints")]
	public bool IncludeQuestIntoItemHint
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _IncludeQuestIntoItemHint;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_IncludeQuestIntoItemHint = value;
		}
	}

	[LDescription("ItemsFont")]
	[LDisplayName("ItemsFont")]
	[LCategory("CatElementsEditor")]
	public Font ItemsFont
	{
		get
		{
			return _ItemsFont;
		}
		set
		{
			_ItemsFont = value;
		}
	}

	[LCategory("CatMisc", -1)]
	[LDisplayName("ItemsImportCompatibilityAce")]
	[LDescription("ItemsImportCompatibilityAce")]
	public bool ItemsImportCompatibilityAce
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ItemsImportCompatibilityAce;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ItemsImportCompatibilityAce = value;
		}
	}

	[LDisplayName("ItemsListIdColumnWidth")]
	[LDescription("ItemsListIdColumnWidth")]
	[LCategory("CatElementsEditor")]
	[Browsable(false)]
	public int ItemsListIdColumnWidth
	{
		get
		{
			return _ItemsListIdColumnWidth;
		}
		set
		{
			_ItemsListIdColumnWidth = value;
		}
	}

	[LDescription("ItemsListNameColumnWidth")]
	[Browsable(false)]
	[LCategory("CatElementsEditor")]
	[LDisplayName("ItemsListNameColumnWidth")]
	public int ItemsListNameColumnWidth
	{
		get
		{
			return _ItemsListNameColumnWidth;
		}
		set
		{
			_ItemsListNameColumnWidth = value;
		}
	}

	[Browsable(false)]
	[LCategory("CatElementsEditor")]
	[LDescription("ItemsListRefCountColumnWidth")]
	[LDisplayName("ItemsListRefCountColumnWidth")]
	public int ItemsListRefCountColumnWidth
	{
		get
		{
			return _ItemsListRefCountColumnWidth;
		}
		set
		{
			_ItemsListRefCountColumnWidth = value;
		}
	}

	[LDisplayName("LineIconsCount")]
	[LDescription("LineIconsCount")]
	[LCategory("CatMisc", -1)]
	public int LineIconsCount
	{
		get
		{
			return _LineIconsCount;
		}
		set
		{
			_LineIconsCount = value;
		}
	}

	[LCategory("CatHints")]
	[LDescription("ListHintItemsLimit")]
	[LDisplayName("ListHintItemsLimit")]
	public int ListHintItemsLimit
	{
		get
		{
			return _ListHintItemsLimit;
		}
		set
		{
			_ListHintItemsLimit = value;
		}
	}

	[LDescription("LiveSearchMatchesLimit")]
	[LCategory("CatLiveSearch")]
	[LDisplayName("LiveSearchMatchesLimit")]
	public int LiveSearchMatchesLimit
	{
		get
		{
			return _LiveSearchMatchesLimit;
		}
		set
		{
			_LiveSearchMatchesLimit = value;
		}
	}

	[LDisplayName("LoadFieldPos")]
	[LCategory("CatMain", 1)]
	[LDescription("LoadFieldPos")]
	public bool LoadFieldPos
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _LoadFieldPos;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_LoadFieldPos = value;
		}
	}

	[Browsable(false)]
	[LCategory("CatMisc", -1)]
	[LDisplayName("LockScales")]
	[LDescription("LockScales")]
	public bool LockFieldsScales
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _LockFieldsScales;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_LockFieldsScales = value;
		}
	}

	[LDescription("ModelsPath")]
	[LDisplayName("ModelsPath")]
	[LCategory("CatFiles")]
	public string ModelsPath
	{
		get
		{
			return _ModelsPath;
		}
		set
		{
			_ModelsPath = value;
		}
	}

	[LDisplayName("ModelsPckBaseName")]
	[LCategory("CatFiles")]
	[LDescription("ModelsPckBaseName")]
	public string ModelsPckBaseName
	{
		get
		{
			return _ModelsPckBaseName;
		}
		set
		{
			_ModelsPckBaseName = value;
		}
	}

	[LDescription("MoneyFields")]
	[LDisplayName("MoneyFields")]
	[LCategory("CatMisc", -1)]
	public string MoneyFields
	{
		get
		{
			return _MoneyFields;
		}
		set
		{
			_MoneyFields = value;
		}
	}

	[LCategory("CatElementsEditor")]
	[LDescription("NewTitleGiftIcon")]
	[LDisplayName("NewTitleGiftIcon")]
	public string NewTitleGiftIcon
	{
		get
		{
			return _NewTitleGiftIcon;
		}
		set
		{
			_NewTitleGiftIcon = value;
		}
	}

	[LDescription("NpcGenPaths")]
	[Browsable(false)]
	[LDisplayName("NpcGenPaths")]
	[LCategory("CatFiles")]
	public string[] NpcGenPaths
	{
		get
		{
			return _NpcGenPaths;
		}
		set
		{
			_NpcGenPaths = value;
		}
	}

	[LCategory("CatCopyPaste")]
	[LDisplayName("PasteAutoSetUniqueID")]
	[LDescription("PasteAutoSetUniqueID")]
	public bool PasteAutoSetUniqueID
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _PasteAutoSetUniqueID;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_PasteAutoSetUniqueID = value;
		}
	}

	[LDisplayName("PasteDependenciesMode")]
	[LCategory("CatCopyPaste")]
	[LDescription("PasteDependenciesModeDesc")]
	public DEPENDENCIES_PASTE_MODE PasteDependenciesMode
	{
		get
		{
			return _PasteDependenciesMode;
		}
		set
		{
			_PasteDependenciesMode = value;
		}
	}

	[LDescription("PasteWithDependencies")]
	[LDisplayName("PasteWithDependencies")]
	[LCategory("CatCopyPaste")]
	public bool PasteWithDependencies
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _PasteWithDependencies;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_PasteWithDependencies = value;
		}
	}

	[LDisplayName("PasteWithDesc")]
	[LCategory("CatCopyPaste")]
	[LDescription("PasteWithDesc")]
	public bool PasteWithDesc
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _PasteWithDesc;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_PasteWithDesc = value;
		}
	}

	[LCategory("CatFiles")]
	[LDescription("PreinctPaths")]
	[Browsable(false)]
	[LDisplayName("PreinctPaths")]
	public string[] PreinctPaths
	{
		get
		{
			return _PreinctPaths;
		}
		set
		{
			_PreinctPaths = value;
		}
	}

	[LDescription("ProjectName")]
	[LCategory("CatMain", 1)]
	[LDisplayName("ProjectName")]
	public string ProjectName
	{
		get
		{
			return _ProjectName;
		}
		set
		{
			_ProjectName = value;
		}
	}

	[LCategory("CatMisc", -1)]
	[LDisplayName("PWDBLang")]
	[LDescription("PWDBLang")]
	[Browsable(false)]
	public string PWDBLang
	{
		get
		{
			return _PWDBLang;
		}
		set
		{
			_PWDBLang = value;
		}
	}

	[LDisplayName("PWGShopDefaultVersion")]
	[LCategory("CatPW")]
	[LDescription("PWGShopDefaultVersion")]
	public PW_GSHOP_VERSION PWGShopDefaultVersion
	{
		get
		{
			return _PWGShopDefaultVersion;
		}
		set
		{
			_PWGShopDefaultVersion = value;
		}
	}

	[LDisplayName("RecentElementsLimit")]
	[LDescription("RecentElementsLimit")]
	[LCategory("CatLimits")]
	public int RecentElementsLimit
	{
		get
		{
			return _RecentElementsLimit;
		}
		set
		{
			_RecentElementsLimit = value;
		}
	}

	[LCategory("CatLimits")]
	[LDisplayName("RecentItemsLimit")]
	[LDescription("RecentItemsLimit")]
	public int RecentItemsLimit
	{
		get
		{
			return _RecentItemsLimit;
		}
		set
		{
			_RecentItemsLimit = value;
		}
	}

	[LDisplayName("RecentProfilesLimit")]
	[LCategory("CatLimits")]
	[LDescription("RecentProfilesLimit")]
	public int RecentProfilesLimit
	{
		get
		{
			return _RecentProfilesLimit;
		}
		set
		{
			_RecentProfilesLimit = value;
		}
	}

	[Browsable(false)]
	public string RestoredElementsFN
	{
		get
		{
			return _RestoredElementsFN;
		}
		set
		{
			_RestoredElementsFN = value;
		}
	}

	[LCategory("CatPW")]
	[LDescription("SaveGshopSevIntoCurrentDir")]
	[LDisplayName("SaveGshopSevIntoCurrentDir")]
	public bool SaveGshopSevIntoCurrentDir
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _SaveGshopSevIntoCurrentDir;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_SaveGshopSevIntoCurrentDir = value;
		}
	}

	[LDisplayName("Server7zCommand")]
	[LCategory("SSH")]
	[LDescription("Server7zCommand")]
	public string Server7zCommand
	{
		get
		{
			return _Server7zCommand;
		}
		set
		{
			_Server7zCommand = value;
		}
	}

	[LCategory("CatFiles")]
	[LDescription("ServerPath")]
	[LDisplayName("ServerPath")]
	public string ServerPath
	{
		get
		{
			return _ServerPath;
		}
		set
		{
			_ServerPath = value;
		}
	}

	[LDescription("ShowHintsInPinnedHint")]
	[LCategory("CatHints")]
	[LDisplayName("ShowHintsInPinnedHint")]
	public bool ShowHintsInPinnedHint
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowHintsInPinnedHint;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowHintsInPinnedHint = value;
		}
	}

	[Browsable(false)]
	public bool ShowItemAmountInGshop
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowItemAmountInGshop;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowItemAmountInGshop = value;
		}
	}

	[LDescription("ShowItemCountInTabTitle")]
	[LCategory("CatElementsEditor")]
	[LDisplayName("ShowItemCountInTabTitle")]
	public bool ShowItemCountInTabTitle
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowItemCountInTabTitle;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowItemCountInTabTitle = value;
		}
	}

	[LDescription("ShowLicenseEmailInsteadOfName")]
	[LDisplayName("ShowLicenseEmailInsteadOfName")]
	[LCategory("CatMain", 1)]
	public bool ShowLicenseEmailInsteadOfName
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowLicenseEmailInsteadOfName;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowLicenseEmailInsteadOfName = value;
		}
	}

	[LDescription("ShowOriginalFieldsToo")]
	[LDisplayName("ShowOriginalFieldsToo")]
	[LCategory("CatMisc", -1)]
	public bool ShowOriginalFieldsToo
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowOriginalFieldsToo;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowOriginalFieldsToo = value;
		}
	}

	[Browsable(false)]
	[LDescription("ShowPercentsInMainWindow")]
	[LCategory("CatMisc", -1)]
	[LDisplayName("ShowPercentageInMainWindow")]
	public bool ShowPercentageInMainWindow
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowPercentageInMainWindow;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowPercentageInMainWindow = value;
		}
	}

	[LDisplayName("ShowRefCountInItemList")]
	[LDescription("ShowRefCountInItemList")]
	[Browsable(false)]
	[LCategory("CatElementsEditor")]
	public bool ShowRefCountInItemList
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowRefCountInItemList;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowRefCountInItemList = value;
		}
	}

	[LDisplayName("ShowSubitemsCountInListView")]
	[LDescription("ShowSubitemsCountInListView")]
	[LCategory("CatElementsEditor")]
	public bool ShowSubitemsCountInListView
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ShowSubitemsCountInListView;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ShowSubitemsCountInListView = value;
		}
	}

	[LDescription("TasksHintItemsLimit")]
	[LDisplayName("TasksHintItemsLimit")]
	[LCategory("CatHints")]
	public int TasksHintItemsLimit
	{
		get
		{
			return _TasksHintItemsLimit;
		}
		set
		{
			_TasksHintItemsLimit = value;
		}
	}

	[LDescription("ToolTipReferencesNumLimit")]
	[LDisplayName("ToolTipReferencesNumLimit")]
	[LCategory("CatHints")]
	public int ToolTipReferencesNumLimit
	{
		get
		{
			return _ToolTipReferencesNumLimit;
		}
		set
		{
			_ToolTipReferencesNumLimit = value;
		}
	}

	[LDescription("UpdateElementsTimeStamp")]
	[LCategory("CatMisc", -1)]
	[LDisplayName("UpdateElementsTimeStamp")]
	public bool UpdateElementsTimeStamp
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _UpdateElementsTimeStamp;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_UpdateElementsTimeStamp = value;
		}
	}

	[LDisplayName("UseAutoSizeForNewIconsWindow")]
	[LDescription("UseAutoSizeForNewIconsWindow")]
	[LCategory("CatMain", 1)]
	public bool UseAutoSizeForNewIconsWindow
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _UseAutoSizeForNewIconsWindow;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_UseAutoSizeForNewIconsWindow = value;
		}
	}

	[LDescription("UseBetaUpdateChannel")]
	[LDisplayName("UseBetaUpdateChannel")]
	[LCategory("CatMain", 1)]
	public bool UseBetaUpdateChannel
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _UseBetaUpdateChannel;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_UseBetaUpdateChannel = value;
		}
	}

	[LDisplayName("UseInvariantCulture")]
	[LCategory("CatSystem", -2)]
	[LDescription("UseInvariantCulture")]
	public bool UseInvariantCulture
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _UseInvariantCulture;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_UseInvariantCulture = value;
		}
	}

	[LDescription("UseNewLineWhenCopyFields")]
	[LCategory("CatCopyPaste")]
	[LDisplayName("UseNewLineWhenCopyFields")]
	public bool UseNewLineWhenCopyFields
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _UseNewLineWhenCopyFields;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_UseNewLineWhenCopyFields = value;
		}
	}

	[LCategory("CatSystem", -2)]
	[LDescription("UseSimpleFolderPicker")]
	[LDisplayName("UseSimpleFolderPicker")]
	public bool UseSimpleFolderPicker
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _UseSimpleFolderPicker;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_UseSimpleFolderPicker = value;
		}
	}

	[LCategory("CatElementsEditor")]
	[LDescription("UseSmartUniqueID")]
	[LDisplayName("UseSmartUniqueID")]
	public bool UseSmartUniqueID
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _UseSmartUniqueID;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_UseSmartUniqueID = value;
		}
	}

	[LDisplayName("ViewOnlyUniqueReferences")]
	[LCategory("CatElementsEditor")]
	[LDescription("ViewOnlyUniqueReferences")]
	public bool ViewOnlyUniqueReferences
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _ViewOnlyUniqueReferences;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_ViewOnlyUniqueReferences = value;
		}
	}

	[LDisplayName("WaitBeforeLoadIcons")]
	[LCategory("CatSystem", -2)]
	[LDescription("WaitBeforeLoadIcons")]
	public bool WaitBeforeLoadIcons
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			return _WaitBeforeLoadIcons;
		}
		[param: MarshalAs(UnmanagedType.U1)]
		set
		{
			_WaitBeforeLoadIcons = value;
		}
	}

	[LDisplayName("WorldTargetsPath")]
	[LCategory("CatFiles")]
	[LDescription("WorldTargetsPath")]
	public string WorldTargetsPath
	{
		get
		{
			return _WorldTargetsPath;
		}
		set
		{
			_WorldTargetsPath = value;
		}
	}

	[LDescription("OpenAIApiKey")]
	[LCategory("CatMisc", -1)]
	[LDisplayName("OpenAIApiKey")]
	public string OpenAIApiKey
	{
		get
		{
			return _OpenAIApiKey;
		}
		set
		{
			_OpenAIApiKey = value;
		}
	}

	[LCategory("CatMisc", -1)]
	[LDisplayName("OpenAIBaseUrl")]
	[LDescription("OpenAIBaseUrl")]
	public string OpenAIBaseUrl
	{
		get
		{
			return _OpenAIBaseUrl;
		}
		set
		{
			_OpenAIBaseUrl = value;
		}
	}

	public ADDITIONAL_PARAMS()
	{
		RestoreByDefault();
	}

	public static ADDITIONAL_PARAMS LoadFromBase64(string sBase64)
	{
		ADDITIONAL_PARAMS aDDITIONAL_PARAMS = null;
		if (!string.IsNullOrWhiteSpace(sBase64) && sBase64.Length > 1500)
		{
			MemoryStream memoryStream = null;
			try
			{
				memoryStream = new MemoryStream(Convert.FromBase64String(sBase64));
				aDDITIONAL_PARAMS = new BinaryFormatter().Deserialize(memoryStream) as ADDITIONAL_PARAMS;
			}
			catch (Exception ex)
			{
				SentryHelper.CaptureException(ex, Class16.smethod_0(1649157316));
				string title = Class16.smethod_0(1649157347);
				string text = Class16.smethod_0(1649157385);
				ACE.RSGlobal.RSGlobal.msgbox_err(string.Concat(Class16.smethod_0(1648935998) + ex.Message, text), title);
			}
			finally
			{
				memoryStream?.Close();
			}
		}
		if (aDDITIONAL_PARAMS == null)
		{
			aDDITIONAL_PARAMS = new ADDITIONAL_PARAMS();
		}
		if (string.IsNullOrWhiteSpace(aDDITIONAL_PARAMS._ModelsPckBaseName))
		{
			aDDITIONAL_PARAMS._ModelsPckBaseName = Class16.smethod_0(1649138031);
		}
		if (string.IsNullOrWhiteSpace(aDDITIONAL_PARAMS._OpenAIBaseUrl))
		{
			aDDITIONAL_PARAMS._OpenAIBaseUrl = Class16.smethod_0(1648896317);
		}
		return aDDITIONAL_PARAMS;
	}

	public static string SerializeToBase64(ADDITIONAL_PARAMS additional_PARAMS_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		new BinaryFormatter().Serialize(memoryStream, additional_PARAMS_0);
		return Convert.ToBase64String(memoryStream.ToArray());
	}

	public ADDITIONAL_PARAMS GetClone()
	{
		ADDITIONAL_PARAMS result = LoadFromBase64(SerializeToBase64(this));
		GC.KeepAlive(this);
		return result;
	}

	public Color GetColor(int color_id)
	{
		Color[] array = colors;
		if (array != null && color_id < (nint)array.LongLength)
		{
			return array[color_id];
		}
		Color white = Color.White;
		GC.KeepAlive(this);
		return white;
	}

	public FIELD_DATA_TYPE_ENUM GetCustomAddonType(int id)
	{
		int value = 0;
		Dictionary<int, int> customAddonsTypes = CustomAddonsTypes;
		if (customAddonsTypes != null && !customAddonsTypes.TryGetValue(id, out value))
		{
			value = 0;
		}
		GC.KeepAlive(this);
		return (FIELD_DATA_TYPE_ENUM)value;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsPropertyChanged(string propName)
	{
		PropertyInfo[] properties = PrevParams.GetType().GetProperties();
		int num = 0;
		if (0 < (nint)properties.LongLength)
		{
			do
			{
				PropertyInfo propertyInfo = properties[num];
				if (!(propertyInfo.Name == propName) || propertyInfo.GetValue(PrevParams, null) == propertyInfo.GetValue(this, null))
				{
					num++;
					continue;
				}
				GC.KeepAlive(this);
				return true;
			}
			while (num < (nint)properties.LongLength);
		}
		return false;
	}

	public void RestoreByDefault()
	{
		_AppVersion = 202502;
		_DisableIconsDictCache = false;
		_BackupItemDesc = true;
		_BackupItemColor = true;
		_AutoSetUniqueID = true;
		_AutoLoadElements2Data = false;
		_Cfg2DefaultPath = string.Empty;
		_OpenAIBaseUrl = Class16.smethod_0(1648896317);
		_PWGShopDefaultVersion = PW_GSHOP_VERSION.PW_1_8_6;
		_ConvertVersion29To27WhenSendToServer_PW = true;
		_ConvertVersion12To7WhenSendToServer_PW = true;
		Color[] array = new Color[15];
		Color white = Color.White;
		array[0] = white;
		colors = array;
		Color color = Color.FromArgb(140, 140, 239);
		colors[1] = color;
		Color gold = Color.Gold;
		colors[2] = gold;
		Color color2 = Color.FromArgb(170, 50, 255);
		colors[3] = color2;
		ref Color reference = ref colors[4];
		reference = SpecialColors.OrangeColorPW;
		Color white2 = Color.White;
		colors[5] = white2;
		Color darkGray = Color.DarkGray;
		colors[6] = darkGray;
		Color mediumSpringGreen = Color.MediumSpringGreen;
		colors[7] = mediumSpringGreen;
		Color red = Color.Red;
		colors[8] = red;
		int num = 9;
		do
		{
			Color white3 = Color.White;
			colors[num] = white3;
			num++;
		}
		while (num < 15);
		SetDefaults(201740);
		SetDefaults(201750);
		int num2 = 201790;
		do
		{
			SetDefaults(num2);
			num2++;
		}
		while (num2 <= 202502);
	}

	public void SetDefaults(int app_version)
	{
		switch (app_version)
		{
		case 201750:
			_TasksHintItemsLimit = 40;
			_AutoDownloadUpdates = true;
			_LoadFieldPos = true;
			break;
		case 201740:
			_LineIconsCount = 30;
			_ShowRefCountInItemList = true;
			break;
		case 201801:
			_RecentItemsLimit = 30;
			break;
		case 201800:
			_FavoriteItemsLimit = 30;
			_ModelsPckBaseName = Class16.smethod_0(1649138031);
			break;
		case 201790:
			_ToolTipReferencesNumLimit = 5;
			_PWDBLang = Class16.smethod_0(1648931959);
			break;
		case 201792:
			_ShowHintsInPinnedHint = true;
			_LiveSearchMatchesLimit = 20;
			_ShowOriginalFieldsToo = false;
			break;
		case 201793:
			_WaitBeforeLoadIcons = false;
			break;
		case 201795:
		{
			string text = ((LANG_INFO.CurrentLang == null) ? Class16.smethod_0(1648931959) : LANG_INFO.CurrentLang.Prefix);
			_DontRandomizeNpcTalk = text == Class16.smethod_0(1648932099);
			break;
		}
		case 201821:
			_NewTitleGiftIcon = Class16.smethod_0(1649132903);
			_RecentElementsLimit = 30;
			_RecentProfilesLimit = 20;
			break;
		case 201809:
			_bShowItemIdOnHint = true;
			_PasteDependenciesMode = DEPENDENCIES_PASTE_MODE.SKIP_EXISTED_DEPENDENCIES;
			_PasteWithDependencies = true;
			_PasteWithDesc = false;
			_PasteAutoSetUniqueID = false;
			break;
		case 201805:
			_DisableShopPriceTaxCalculation = false;
			_UpdateElementsTimeStamp = false;
			_UseBetaUpdateChannel = false;
			ACE.RSGlobal.RSGlobal.KeepOnlyUniqueValues(ref ElementsRecentItemsGlobal);
			break;
		case 201836:
			_ShowItemAmountInGshop = true;
			break;
		case 201837:
			_CurrentGShopSaleOption = 0u;
			_HighlightLiveSearchMatches = true;
			break;
		case 201839:
			_HintIdDuplicatesLimit = 10;
			_ShowSubitemsCountInListView = true;
			_ListHintItemsLimit = 20;
			break;
		case 201842:
			_SaveGshopSevIntoCurrentDir = false;
			_DisableAllHints = false;
			break;
		case 201831:
			_UseNewLineWhenCopyFields = false;
			_MoneyFields = Class16.smethod_0(1649157429);
			break;
		case 201825:
			_UseSimpleFolderPicker = false;
			_UseSmartUniqueID = false;
			_IncludeQuestIntoItemHint = true;
			_IncludeQuestFromSubitems = true;
			break;
		case 201874:
			_ShowLicenseEmailInsteadOfName = false;
			_Domain2TimeBetweenMaps = 20;
			break;
		case 201851:
			_LockFieldsScales = false;
			break;
		case 201850:
			_AllowToEditAddonsId = false;
			_ShowPercentageInMainWindow = true;
			_UseInvariantCulture = false;
			break;
		case 201910:
			_ItemsFont = new Font(Class16.smethod_0(1649143423), 9.5f);
			break;
		case 201901:
			_ItemsImportCompatibilityAce = false;
			_ShowItemCountInTabTitle = true;
			_DontOpenFieldTypesAfterSaving = false;
			_DisableParallelElementsLoading = false;
			_AutoSaveFieldTypes = true;
			_EnableFieldNameChange = true;
			_ItemsListNameColumnWidth = 232;
			_ItemsListIdColumnWidth = 57;
			_ItemsListRefCountColumnWidth = 36;
			_EditorSplitterDistance = 363;
			_IgnoreItemCountOnLoading = false;
			_DontUpdateRealTimestamp = false;
			break;
		case 201903:
			_FieldsFont = new Font(Class16.smethod_0(1649143423), 9.5f);
			break;
		case 201904:
			_Server7zCommand = Class16.smethod_0(1649128841);
			break;
		case 201881:
			_ExperimentalIcons = false;
			_EnableSimpleProtection = false;
			break;
		case 202000:
			_EnableFieldsTabs = true;
			break;
		case 201960:
			_ShowPercentageInMainWindow = false;
			break;
		case 201940:
			_ViewOnlyUniqueReferences = false;
			_DontLoadLuaFromPck = false;
			break;
		case 202400:
			_UseAutoSizeForNewIconsWindow = true;
			break;
		case 202300:
			_ModelsPath = Class16.smethod_0(1649122522);
			_DisableNewIconsWindow = false;
			break;
		case 202133:
			_DisableTooHighIdErrors = false;
			break;
		}
	}
}
