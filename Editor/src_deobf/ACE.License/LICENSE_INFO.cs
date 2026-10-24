#nullable enable annotations
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ACE.Classes;
using ACE.RSGlobal;
using Microsoft.Win32;

namespace ACE.License;

public class LICENSE_INFO
{
	[Serializable]
	private sealed class Class151
	{
		public static readonly Class151 class151_0 = new Class151();

		public static Func<StringBuilder, uint, AceNative.AceStatusCode> func_0;

		internal AceNative.AceStatusCode method_0(StringBuilder stringBuilder_0, uint uint_0)
		{
			return (AceNative.AceStatusCode)AceNative.ACE_GetLicenseType(stringBuilder_0, uint_0);
		}
	}

	public struct KEY2
	{
		public string license_md5;

		public byte[] license_encrypted;

		public ulong flags;

		public uint global_date_expired;

		public string WinGUID;

		public bool bSL;

		public uint date_created;

		public IDictionary<ulong, uint> funcs_expired;

		public IDictionary<ulong, uint> spec_funcs_expired;

		public uint funcs_max_date;

		public LICENSE_TYPE LicenseType;

		public bool AngelicaCoreEditor;

		public int SubscriptionStatus;

		public bool bTrial;

		public string RName;

		public string Email;

		public bool bAccepted;
	}

	public struct LICENSES
	{
		public struct LICENSES_FW
		{
			public bool Elements;

			public bool GShop;

			public bool NPCGen;

			public bool Tasks;
		}

		public struct LICENSES_JD
		{
			public bool Elements;

			public bool GShop;

			public bool NPCGen;

			public bool Tasks;
		}

		public struct LICENSES_PW
		{
			public bool Elements;

			public bool GShop;

			public bool Domain2;

			public bool Tasks;

			public bool ExtraDrops;
		}

		public LICENSES_PW PW;

		public LICENSES_FW FW;

		public LICENSES_JD JD;

		public bool SW;

		public bool Chibi;

		public bool ESO;

		public bool PathData;

		public bool PCKProtection;

		public bool CPKProtection;

		public bool IgnoreElProtectionByLogin;

		public bool ttcz;

		public bool TOS;
	}

	public struct SPECIAL
	{
		public struct SPECIAL_PCK
		{
			public bool Elements;

			public bool GShop;

			public bool Tasks;

			public bool Serverlist;

			public bool CustomFile;

			public bool PathData;

			public bool CustomFile2;

			public bool AllowAnyProject;
		}

		public struct SPECIAL_PW
		{
			public bool ElCorruption;

			public bool PreviewRefine;

			public bool TasksJoining;
		}

		public SPECIAL_PW PW;

		public SPECIAL_PCK PCK;

		public ulong TrialFunctionsMask;

		public bool Ultimate;

		public bool AHistoryViewer;

		public bool ElProtectionByLogin;

		public bool RefactoringItemsID;

		public bool ElementsUltimateProtection;

		public bool UseOpenAITranslator;

		public bool ModelPreview;

		public bool ModelSelection;

		public bool ModelImport;

		public bool EnableFTSaving;

		public bool EnableFieldNameChange;

		public bool DisableSC;

		public bool dev;

		public bool livenpceditor;

		public bool npcgen_mapview;

		public bool precinct_editor;

		public bool region_editor;

		public bool domain_editor;

		public bool domain2_mapview;

		public bool aipolicy_editor;

		public bool worldtargets_editor;

		public bool tasks_npc_editor;

		public bool bon_editor;

		public bool pck_editor;

		public bool nmd_export;

		public bool bmd_editor;

		public bool dyn_tasks_editor;

		public bool icon_editor;

		public bool pck_unpack;

		public bool ui_xml_editor;

		public bool pw_map_editor;
	}

	public struct UserLicense
	{
		public uint id;

		public string key;

		public string type;
	}

	public RSCrypt SecretEncoder;

	public RSCrypt SecretDecoder;

	public bool bActivatedOnServer;

	public short State;

	public ulong enigma_flags;

	public string UserName = string.Empty;

	public string KeyEnigma;

	public string HardwareEnigma;

	public uint ServerUserId;

	public uint ServerLicenseId;

	public string ServerHardwareId = string.Empty;

	public uint server_time;

	public bool bTemporaryLicense;

	public bool bShowSpecialOffer;

	public ulong special_mask;

	public bool bDateAccepted;

	public bool InDepthCheckingFailed;

	public static KEY2 Info;

	public LICENSES Licenses;

	public SPECIAL Special;

	public bool bFastCheckChached;

	private readonly object object_0 = new object();

	private readonly Dictionary<string, AceNative.AceFeatureEntitlement> dictionary_0 = new Dictionary<string, AceNative.AceFeatureEntitlement>(StringComparer.OrdinalIgnoreCase);

	private DateTime dateTime_0 = DateTime.MinValue;

	private bool bool_0;

	private static int int_0;

	private static AceNative.LicenseCallback? licenseCallback_0;

	public bool UpdateRequiredBlocked
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public LICENSE_INFO([MarshalAs(UnmanagedType.U1)] bool bFastCheck)
	{
		try
		{
			bActivatedOnServer = false;
			if (UserName == null)
			{
				UserName = string.Empty;
			}
			if (string.IsNullOrEmpty(Info.license_md5))
			{
				Info.license_md5 = Class16.smethod_0(1649049318);
			}
			RSCompression.Init();
			GrantOfflineLicense();
			GC.KeepAlive(this);
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649049328));
			throw new Exception(Class16.smethod_0(1649049360) + ex.Message);
		}
	}

	private void GrantOfflineLicense()
	{
		method_0(bool_1: false);
		if (string.IsNullOrWhiteSpace(UserName))
		{
			UserName = "Angelica Core";
		}
		Info.LicenseType = LICENSE_TYPE.ULTIMATE;
		Info.AngelicaCoreEditor = true;
		Info.bAccepted = true;
		Info.bTrial = false;
		Info.bSL = true;
		Info.global_date_expired = 0u;
		Info.date_created = (uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
		Info.SubscriptionStatus = 1;
		Info.RName = UserName;
		if (Info.Email == null)
		{
			Info.Email = string.Empty;
		}
		bDateAccepted = true;
		bActivatedOnServer = true;
		bTemporaryLicense = false;
		bShowSpecialOffer = false;
		State = 4;
		ServerUserId = 0u;
		ServerLicenseId = 0u;
		ServerHardwareId = string.Empty;
		special_mask = ulong.MaxValue;
		Info.flags = ulong.MaxValue;
		Licenses = default(LICENSES);
		Special = default(SPECIAL);
		SetLicenseFlags();
		SetLicenseSpecFlags();
	}

	private void method_0(bool bool_1)
	{
		bool_0 = bool_1;
	}

	private void method_1(int int_1)
	{
		try
		{
			if (int_1 == 0)
			{
				method_0(bool_1: false);
				method_3(bool_1: true);
				method_6();
				Info.bAccepted = true;
				bDateAccepted = true;
				bActivatedOnServer = true;
				State = 4;
				SetLicenseFlags();
				SetLicenseSpecFlags();
			}
			else if (!method_5((AceNative.AceStatusCode)int_1) && (int_1 == 20 || int_1 == 21 || int_1 == 53 || int_1 == 22 || int_1 == 54 || int_1 == 59 || int_1 == 58))
			{
				Unregister(bDeleteLicense: true);
				Info.bAccepted = false;
				bDateAccepted = false;
				bActivatedOnServer = false;
				State = 0;
				Licenses = default(LICENSES);
				Special = default(SPECIAL);
				method_4();
				throw new Exception(Class16.smethod_0(1649049387));
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649049428));
			throw new Exception(Class16.smethod_0(1648935998) + ex.Message);
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsValid()
	{
		GrantOfflineLicense();
		GC.KeepAlive(this);
		return true;
	}

	public void Unregister([MarshalAs(UnmanagedType.U1)] bool bDeleteLicense)
	{
		GrantOfflineLicense();
	}

	public string GetArrayValueSafe(string[] arr, int index)
	{
		if (index < (nint)arr.LongLength)
		{
			return arr[index];
		}
		return string.Empty;
	}

	public void ReadExpiredDates(ref IDictionary<ulong, uint> db, string source)
	{
		if (source.Contains(Class16.smethod_0(1648898262)))
		{
			string[] array = source.Split(' ');
			int num = 0;
			if (0 < (nint)array.LongLength)
			{
				do
				{
					if (!string.IsNullOrWhiteSpace(array[num]) && array[num].Contains(Class16.smethod_0(1648898262)))
					{
						char[] separator = new char[1] { ';' };
						string[] array2 = array[num].Split(separator);
						ulong key = Convert.ToUInt64(array2[0]);
						uint num2 = Convert.ToUInt32(array2[1]);
						db.Add(key, num2);
						uint funcs_max_date = Info.funcs_max_date;
						uint funcs_max_date2 = ((funcs_max_date > num2) ? funcs_max_date : num2);
						Info.funcs_max_date = funcs_max_date2;
					}
					num++;
				}
				while (num < (nint)array.LongLength);
			}
		}
		GC.KeepAlive(this);
	}

	public void SetLicenseFlags()
	{
		if (GetFeatureEntitlementsByName(Class16.smethod_0(1649049470)))
		{
			Licenses.PW.Elements = GetFeatureEntitlementsByName(Class16.smethod_0(1648906367));
			Licenses.PW.GShop = GetFeatureEntitlementsByName(Class16.smethod_0(1648906382));
			Licenses.PW.Domain2 = GetFeatureEntitlementsByName(Class16.smethod_0(1648906386));
			Licenses.PW.Tasks = GetFeatureEntitlementsByName(Class16.smethod_0(1648906421));
			Licenses.PW.ExtraDrops = GetFeatureEntitlementsByName(Class16.smethod_0(1649049479));
		}
		if (GetFeatureEntitlementsByName(Class16.smethod_0(1649049488)))
		{
			Licenses.FW.Elements = GetFeatureEntitlementsByName(Class16.smethod_0(1648906367));
			Licenses.FW.NPCGen = GetFeatureEntitlementsByName(Class16.smethod_0(1648906400));
			Licenses.FW.GShop = GetFeatureEntitlementsByName(Class16.smethod_0(1648906382));
			Licenses.FW.Tasks = GetFeatureEntitlementsByName(Class16.smethod_0(1648906421));
		}
		if (GetFeatureEntitlementsByName(Class16.smethod_0(1649049497)))
		{
			Licenses.JD.Elements = GetFeatureEntitlementsByName(Class16.smethod_0(1648906367));
			Licenses.JD.GShop = GetFeatureEntitlementsByName(Class16.smethod_0(1648906382));
			Licenses.JD.NPCGen = GetFeatureEntitlementsByName(Class16.smethod_0(1648906400));
			Licenses.JD.Tasks = GetFeatureEntitlementsByName(Class16.smethod_0(1648906421));
		}
		Licenses.SW = GetFeatureEntitlementsByName(Class16.smethod_0(1649049506));
		Licenses.Chibi = GetFeatureEntitlementsByName(Class16.smethod_0(1649049515));
		Licenses.ESO = GetFeatureEntitlementsByName(Class16.smethod_0(1649049535));
		Licenses.PathData = GetFeatureEntitlementsByName(Class16.smethod_0(1649049537));
		Licenses.PCKProtection = GetFeatureEntitlementsByName(Class16.smethod_0(1649049552));
		Licenses.CPKProtection = GetFeatureEntitlementsByName(Class16.smethod_0(1649049580));
		Licenses.IgnoreElProtectionByLogin = GetFeatureEntitlementsByName(Class16.smethod_0(1649049592));
		Licenses.ttcz = GetFeatureEntitlementsByName(Class16.smethod_0(1649048600));
		Licenses.TOS = GetFeatureEntitlementsByName(Class16.smethod_0(1649048611));
	}

	public void SetLicenseSpecFlags()
	{
		if (GetFeatureEntitlementsByName(Class16.smethod_0(1649049470)))
		{
			Special.PW.ElCorruption = GetFeatureEntitlementsByName(Class16.smethod_0(1649048629));
			Special.PW.PreviewRefine = GetFeatureEntitlementsByName(Class16.smethod_0(1649048640));
			Special.PW.TasksJoining = GetFeatureEntitlementsByName(Class16.smethod_0(1649048668));
		}
		if (GetFeatureEntitlementsByName(Class16.smethod_0(1649049552)))
		{
			Special.PCK.Elements = GetFeatureEntitlementsByName(Class16.smethod_0(1649048687));
			Special.PCK.GShop = GetFeatureEntitlementsByName(Class16.smethod_0(1649048697));
			Special.PCK.Tasks = GetFeatureEntitlementsByName(Class16.smethod_0(1649048712));
			Special.PCK.Serverlist = GetFeatureEntitlementsByName(Class16.smethod_0(1649048735));
			Special.PCK.CustomFile = GetFeatureEntitlementsByName(Class16.smethod_0(1649048744));
			Special.PCK.PathData = GetFeatureEntitlementsByName(Class16.smethod_0(1649048761));
			Special.PCK.CustomFile2 = GetFeatureEntitlementsByName(Class16.smethod_0(1649048779));
			Special.PCK.AllowAnyProject = GetFeatureEntitlementsByName(Class16.smethod_0(1649048805));
		}
		Special.Ultimate = GetFeatureEntitlementsByName(Class16.smethod_0(1649048819));
		Special.AHistoryViewer = GetFeatureEntitlementsByName(Class16.smethod_0(1649048834));
		Special.ElProtectionByLogin = GetFeatureEntitlementsByName(Class16.smethod_0(1649048863));
		Special.RefactoringItemsID = GetFeatureEntitlementsByName(Class16.smethod_0(1649048881));
		Special.ElementsUltimateProtection = GetFeatureEntitlementsByName(Class16.smethod_0(1649048906));
		Special.UseOpenAITranslator = GetFeatureEntitlementsByName(Class16.smethod_0(1649048939));
		Special.ModelPreview = GetFeatureEntitlementsByName(Class16.smethod_0(1649048973));
		Special.ModelSelection = GetFeatureEntitlementsByName(Class16.smethod_0(1649048984));
		Special.ModelImport = GetFeatureEntitlementsByName(Class16.smethod_0(1649049013));
		Special.EnableFTSaving = GetFeatureEntitlementsByName(Class16.smethod_0(1649049031));
		Special.EnableFieldNameChange = GetFeatureEntitlementsByName(Class16.smethod_0(1649049052));
		Special.DisableSC = GetFeatureEntitlementsByName(Class16.smethod_0(1649049072));
		Special.dev = GetFeatureEntitlementsByName(Class16.smethod_0(1648893727));
		Special.livenpceditor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048064));
		Special.npcgen_mapview = GetFeatureEntitlementsByName(Class16.smethod_0(1649048092));
		Special.precinct_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048105));
		Special.region_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048135));
		Special.domain_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048147));
		Special.domain2_mapview = GetFeatureEntitlementsByName(Class16.smethod_0(1649048175));
		Special.aipolicy_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048197));
		Special.worldtargets_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048211));
		Special.tasks_npc_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048245));
		Special.bon_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048268));
		Special.pck_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048285));
		Special.nmd_export = GetFeatureEntitlementsByName(Class16.smethod_0(1649048302));
		Special.bmd_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048319));
		Special.dyn_tasks_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048328));
		Special.icon_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048359));
		Special.pck_unpack = GetFeatureEntitlementsByName(Class16.smethod_0(1649048369));
		Special.ui_xml_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048386));
		Special.pw_map_editor = GetFeatureEntitlementsByName(Class16.smethod_0(1649048414));
	}

	public static string GetStaticUserName(string UserName)
	{
		if (string.IsNullOrEmpty(UserName))
		{
			return string.Empty;
		}
		if (UserName.Length > 4)
		{
			string text = Class16.smethod_0(1648923968);
			string text2 = UserName;
			if (text2.Substring(text2.Length - 2, 1) == text)
			{
				string text3 = UserName;
				if (ACE.RSGlobal.RSGlobal.IsUIntFast(text3.Substring(text3.Length - 1)))
				{
					UserName = UserName.Substring(0, UserName.Length - 2);
				}
			}
			if (UserName.EndsWith(Class16.smethod_0(1648978611)) || (UserName.EndsWith(Class16.smethod_0(1648978611)) && UserName.Length > 4))
			{
				return UserName.Substring(0, UserName.Length - 4);
			}
		}
		return UserName;
	}

	public string GetStaticUserName()
	{
		string staticUserName = GetStaticUserName(UserName);
		GC.KeepAlive(this);
		return staticUserName;
	}

	public AceNative.AceStatusCode AuthenticateUser(string email, string password, out UserLicense[] licenses)
	{
		licenses = Array.Empty<UserLicense>();
		GrantOfflineLicense();
		return AceNative.AceStatusCode.ACE_OK;
	}

	public bool ActivateWithKey(string licenseKey)
	{
		GrantOfflineLicense();
		return true;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool CheckLicense([MarshalAs(UnmanagedType.U1)] bool bFastCheck)
	{
		GrantOfflineLicense();
		GC.KeepAlive(this);
		return true;
	}

	private LICENSE_TYPE method_2(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return LICENSE_TYPE.UNKNOWN;
		}
		string_0 = string_0.ToLower();
		if (string_0.Contains(Class16.smethod_0(1649048501)))
		{
			return LICENSE_TYPE.TRIAL;
		}
		if (!string_0.Contains(Class16.smethod_0(1649048505)) && !string_0.Contains(Class16.smethod_0(1648893727)))
		{
			if (!string_0.Contains(Class16.smethod_0(1649048521)) && !string_0.Contains(Class16.smethod_0(1649048536)))
			{
				if (string_0.Contains(Class16.smethod_0(1649048819)))
				{
					return LICENSE_TYPE.ULTIMATE;
				}
				if (!string_0.Contains(Class16.smethod_0(1649048559)) && !(string_0 == Class16.smethod_0(1649048570)))
				{
					if (!string_0.Contains(Class16.smethod_0(1649047564)) && !string_0.Contains(Class16.smethod_0(1649047568)))
					{
						if (string_0.Contains(Class16.smethod_0(1649047591)))
						{
							return LICENSE_TYPE.BRAZILIAN_EDITION;
						}
						if (string_0.Contains(Class16.smethod_0(1649047607)))
						{
							return LICENSE_TYPE.LITE;
						}
						if (string_0.Contains(Class16.smethod_0(1649047610)))
						{
							return LICENSE_TYPE.ACE;
						}
						return LICENSE_TYPE.UNKNOWN;
					}
					return LICENSE_TYPE.STANDART;
				}
				return LICENSE_TYPE.PROFESSIONAL;
			}
			return LICENSE_TYPE.ULTIMATE;
		}
		return LICENSE_TYPE.DEV;
	}

	public string GetWinGUID()
	{
		RegistryKey registryKey = ((!Environment.Is64BitOperatingSystem) ? RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32) : RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64));
		string name = Class16.smethod_0(1649047628);
		string result = (string)registryKey.OpenSubKey(Class16.smethod_0(1649047646)).GetValue(name, null);
		GC.KeepAlive(this);
		return result;
	}

	public string GetActivationKey(string UserName)
	{
		string actKey = RSCrypt.GetActKey(UserName);
		GC.KeepAlive(this);
		return actKey;
	}

	public uint GetRealTime()
	{
		DateTime utcNow = DateTime.UtcNow;
		uint num = server_time;
		uint result = ((num <= ACE.RSGlobal.RSGlobal.DateTime2Timestamp(utcNow)) ? ACE.RSGlobal.RSGlobal.DateTime2Timestamp(DateTime.UtcNow) : num);
		GC.KeepAlive(this);
		return result;
	}

	private static bool smethod_0(string string_0)
	{
		if (string.IsNullOrWhiteSpace(string_0))
		{
			return false;
		}
		string_0 = string_0.Trim();
		if (!string_0.Equals(Class16.smethod_0(1648901259), StringComparison.OrdinalIgnoreCase) && !string_0.Equals(Class16.smethod_0(1648934925), StringComparison.OrdinalIgnoreCase) && !string_0.Equals(Class16.smethod_0(1648898323), StringComparison.OrdinalIgnoreCase) && !string_0.Equals(Class16.smethod_0(1649047684), StringComparison.OrdinalIgnoreCase))
		{
			return string_0.Equals(Class16.smethod_0(1649047692), StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static string smethod_1(AceNative.AceValue aceValue_0)
	{
		switch (aceValue_0.kind)
		{
		default:
			return string.Empty;
		case AceNative.AceValueKind.ACE_VALUE_BOOL:
			if (aceValue_0.bool_value == 0)
			{
				return Class16.smethod_0(1648924112);
			}
			return Class16.smethod_0(1648934925);
		case AceNative.AceValueKind.ACE_VALUE_INT:
			return aceValue_0.int_value.ToString(CultureInfo.InvariantCulture);
		case AceNative.AceValueKind.ACE_VALUE_DOUBLE:
			return aceValue_0.double_value.ToString(CultureInfo.InvariantCulture);
		case AceNative.AceValueKind.ACE_VALUE_STRING:
			return AceNative.Utf8Z(aceValue_0.string_value);
		}
	}

	private void method_3(bool bool_1)
	{
		lock (object_0)
		{
			if (!bool_1 && dictionary_0.Count > 0 && DateTime.UtcNow - dateTime_0 < TimeSpan.FromSeconds(10.0))
			{
				return;
			}
			dictionary_0.Clear();
			try
			{
				if (AceNative.GetActivatedLicenseEntitlements() == AceNative.AceStatusCode.ACE_OK && AceNative.ACE_GetLastActivatedLicenseEntitlementFeatureCount(out var count) == AceNative.AceStatusCode.ACE_OK)
				{
					for (uint num = 0u; num < count; num++)
					{
						if (AceNative.ACE_GetLastActivatedLicenseEntitlementFeatureAt(num, out var feature) == AceNative.AceStatusCode.ACE_OK)
						{
							string text = AceNative.Utf8Z(feature.key);
							if (!string.IsNullOrWhiteSpace(text))
							{
								dictionary_0[text.Trim()] = feature;
							}
						}
					}
				}
			}
			catch
			{
			}
			if (dictionary_0.Count == 0)
			{
				try
				{
					if (AceNative.ACE_GetLastLicenseFeatureCount(out var count2) == AceNative.AceStatusCode.ACE_OK)
					{
						for (uint num2 = 0u; num2 < count2; num2++)
						{
							if (AceNative.ACE_GetLastLicenseFeatureAt(num2, out var feature2) == AceNative.AceStatusCode.ACE_OK)
							{
								string text2 = AceNative.Utf8Z(feature2.key);
								if (!string.IsNullOrWhiteSpace(text2))
								{
									dictionary_0[text2.Trim()] = feature2;
								}
							}
						}
					}
				}
				catch
				{
				}
			}
			dateTime_0 = DateTime.UtcNow;
		}
	}

	private void method_4()
	{
		lock (object_0)
		{
			dictionary_0.Clear();
			dateTime_0 = DateTime.MinValue;
		}
	}

	public bool TryGetFeatureEntitlementString(string key, out string value)
	{
		value = "1";
		if (string.IsNullOrWhiteSpace(key))
		{
			value = string.Empty;
			return false;
		}
		GC.KeepAlive(this);
		return true;
	}

	public bool TryGetFeatureEntitlementInt(string key, out int value)
	{
		value = int.MaxValue;
		if (string.IsNullOrWhiteSpace(key))
		{
			value = 0;
			return false;
		}
		GC.KeepAlive(this);
		return true;
	}

	public bool GetFeatureEntitlementsByName(string featureName)
	{
		if (string.IsNullOrWhiteSpace(featureName))
		{
			return false;
		}
		GC.KeepAlive(this);
		return true;
	}

	public DateTime GetDateExpired()
	{
		if (Info.global_date_expired == 0)
		{
			return DateTime.MaxValue;
		}
		uint timestamp = ((Info.global_date_expired > 11) ? (Info.global_date_expired - 11) : 0u);
		DateTime result = ACE.RSGlobal.RSGlobal.Timestamp2DateTime(timestamp).ToLocalTime();
		GC.KeepAlive(this);
		return result;
	}

	private bool method_5(AceNative.AceStatusCode aceStatusCode_0)
	{
		if (aceStatusCode_0 != AceNative.AceStatusCode.ACE_UPDATE_REQUIRED)
		{
			return false;
		}
		method_0(bool_1: true);
		smethod_2();
		return true;
	}

	private static void smethod_2()
	{
		if (Interlocked.Exchange(ref int_0, 1) != 0)
		{
			return;
		}
		try
		{
			string updaterExePath = CommonStorage.UpdaterExePath;
			if (File.Exists(updaterExePath))
			{
				Process.Start(updaterExePath, Class16.smethod_0(1649045524))?.Close();
				return;
			}
			Process.Start(new ProcessStartInfo(Class16.smethod_0(1649045591))
			{
				UseShellExecute = true
			});
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649047706));
		}
	}

	private bool method_6()
	{
		try
		{
			string text = smethod_3(out var aceStatusCode_);
			if (!string.IsNullOrWhiteSpace(text))
			{
				UserName = text.Trim();
			}
			if (string.IsNullOrWhiteSpace(UserName))
			{
				if (AceNative.GetUserMe() != AceNative.AceStatusCode.ACE_OK)
				{
					Unregister(bDeleteLicense: true);
					return false;
				}
				text = smethod_3(out aceStatusCode_);
				if (!string.IsNullOrWhiteSpace(text))
				{
					UserName = text.Trim();
				}
			}
			if (string.IsNullOrWhiteSpace(UserName))
			{
				Unregister(bDeleteLicense: true);
				return false;
			}
			AceNative.AceStatusCode aceStatusCode_2;
			string text2 = smethod_4(out aceStatusCode_2);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				Info.Email = text2.Trim();
			}
			Info.RName = UserName;
			uint num = 0u;
			if (AceNative.ACE_GetLastCustomerMeUser(out var user) == AceNative.AceStatusCode.ACE_OK && user.id != 0)
			{
				num = user.id;
			}
			if (num == 0 && AceNative.ACE_GetLastCustomerLoginResult(out var result) == AceNative.AceStatusCode.ACE_OK && result.has_user != 0 && result.user.id != 0)
			{
				num = result.user.id;
			}
			if (num == 0 && AceNative.GetUserMe() == AceNative.AceStatusCode.ACE_OK && AceNative.ACE_GetLastCustomerMeUser(out user) == AceNative.AceStatusCode.ACE_OK && user.id != 0)
			{
				num = user.id;
			}
			ServerUserId = num;
			if (AceNative.ACE_GetLastActivatedLicenseEntitlementsResult(out var result2) == AceNative.AceStatusCode.ACE_OK)
			{
				if (result2.has_hardware_id != 0)
				{
					ServerHardwareId = AceNative.Utf8Z(result2.hardware_id) ?? string.Empty;
				}
				if (result2.has_license != 0)
				{
					ServerLicenseId = result2.license.id;
				}
			}
			string text3 = AceNative.GetString(Class151.class151_0.method_0);
			Info.LicenseType = method_2(text3);
			Info.bTrial = !string.IsNullOrEmpty(text3) && text3.IndexOf(Class16.smethod_0(1649048501), StringComparison.OrdinalIgnoreCase) >= 0;
			if (Info.bTrial)
			{
				bShowSpecialOffer = true;
				bTemporaryLicense = true;
			}
			if (AceNative.ACE_GetLicenseExpiryDate(out var expiryDate) == 0)
			{
				Info.global_date_expired = expiryDate;
			}
			else
			{
				Info.global_date_expired = 0u;
			}
			Info.date_created = (uint)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
			Info.SubscriptionStatus = 1;
			Info.bSL = true;
			if (string.IsNullOrEmpty(Info.license_md5))
			{
				Info.license_md5 = Class16.smethod_0(1649049318);
			}
			Info.AngelicaCoreEditor = GetFeatureEntitlementsByName(Class16.smethod_0(1649047759));
			return true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649047776));
		}
		return false;
	}

	private static string smethod_3(out AceNative.AceStatusCode aceStatusCode_0)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder(512);
			aceStatusCode_0 = (AceNative.AceStatusCode)AceNative.ACE_GetLicenseUserName(stringBuilder, (uint)stringBuilder.Capacity);
			return (aceStatusCode_0 == AceNative.AceStatusCode.ACE_OK) ? stringBuilder.ToString() : string.Empty;
		}
		catch
		{
			aceStatusCode_0 = AceNative.AceStatusCode.ACE_FAIL;
			return string.Empty;
		}
	}

	private static string smethod_4(out AceNative.AceStatusCode aceStatusCode_0)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder(512);
			aceStatusCode_0 = (AceNative.AceStatusCode)AceNative.ACE_GetLicenseUserEmail(stringBuilder, (uint)stringBuilder.Capacity);
			return (aceStatusCode_0 == AceNative.AceStatusCode.ACE_OK) ? stringBuilder.ToString() : string.Empty;
		}
		catch
		{
			aceStatusCode_0 = AceNative.AceStatusCode.ACE_FAIL;
			return string.Empty;
		}
	}
}
