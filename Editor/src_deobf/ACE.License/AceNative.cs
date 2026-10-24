using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACE.License;

public static class AceNative
{
	public struct AceActivatedLicenseEntitlementsResult
	{
		public uint has_hardware_id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] hardware_id;

		public uint has_license;

		public AceLicenseEntitlementsLicense license;
	}

	public struct AceBanCheckResult
	{
		public uint banned;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] reason;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] expires_at;
	}

	public struct AceCustomerLicenseSummary
	{
		public uint id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] license_key;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] license_type;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] status;

		public uint has_issued_at;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] issued_at;

		public uint has_expires_at;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] expires_at;

		public ulong expires_at_unix_ms;

		public uint hardware_binding_enabled;

		public uint has_max_activations;

		public uint max_activations;

		public uint has_current_activations;

		public uint current_activations;

		public uint has_entitlement_set_id;

		public uint entitlement_set_id;

		public uint has_product_id;

		public uint product_id;

		public uint has_product_name;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] product_name;
	}

	public struct AceCustomerLoginResult
	{
		public uint success;

		public uint has_user;

		public AceCustomerUser user;

		public uint has_token;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
		public byte[] token;
	}

	public struct AceCustomerUser
	{
		public uint id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] user_hash;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] email;

		public uint has_name;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] name;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] status;
	}

	public struct AceEditorSessionResult
	{
		public uint session_id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] started_at;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] error_message;
	}

	public struct AceFeatureEntitlement
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] key;

		public uint enabled;

		public AceValue value;

		public uint has_limit_value;

		public long limit_value;

		public uint has_expires_at;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] expires_at;
	}

	public struct AceLicenseEntitlementsLicense
	{
		public uint id;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] license_key;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] product_name;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] license_type;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] status;

		public uint has_expires_at;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] expires_at;

		public ulong expires_at_unix_ms;
	}

	public struct AceLicenseEntitlementsResult
	{
		public uint has_license;

		public AceLicenseEntitlementsLicense license;
	}

	public struct AceLicenseInfo
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] license_key;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] product_name;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] license_type;

		public uint has_expires_at;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] expires_at;

		public ulong expires_at_unix_ms;
	}

	public struct AceLicenseResult
	{
		public uint valid;

		public uint has_activated;

		public uint activated;

		public uint has_license;

		public AceLicenseInfo license;
	}

	public enum AceStatusCode
	{
		ACE_OK = 0,
		ACE_FAIL = 1,
		ACE_EXPIRED = 20,
		ACE_SUSPENDED = 21,
		ACE_GRACE_PERIOD_OVER = 22,
		ACE_E_FILE_PATH = 40,
		ACE_E_PRODUCT_FILE = 41,
		ACE_E_PRODUCT_DATA = 42,
		ACE_E_PRODUCT_ID = 43,
		ACE_E_SYSTEM_PERMISSION = 44,
		ACE_E_FILE_PERMISSION = 45,
		ACE_E_WMIC = 46,
		ACE_E_TIME = 47,
		ACE_E_INET = 48,
		ACE_E_NET_PROXY = 49,
		ACE_E_HOST_URL = 50,
		ACE_E_BUFFER_SIZE = 51,
		ACE_E_REVOKED = 53,
		ACE_E_LICENSE_KEY = 54,
		ACE_E_LICENSE_TYPE = 55,
		ACE_E_ACTIVATION_LIMIT = 58,
		ACE_E_ACTIVATION_NOT_FOUND = 59,
		ACE_E_MACHINE_FINGERPRINT = 63,
		ACE_E_TIME_MODIFIED = 69,
		ACE_E_AUTHENTICATION_FAILED = 71,
		ACE_E_USER_NOT_AUTHENTICATED = 87,
		ACE_E_RATE_LIMIT = 90,
		ACE_E_SERVER = 91,
		ACE_E_CLIENT = 92,
		ACE_E_LOGIN_TEMPORARILY_LOCKED = 100,
		ACE_E_OS_USER = 104,
		ACE_UPDATE_REQUIRED = 105,
		ACE_E_HARDWARE_ID = 10000,
		ACE_E_NOT_INITIALIZED = 10001,
		ACE_E_INVALID_ARGUMENT = 10002,
		ACE_E_OUT_OF_RANGE = 10003,
		ACE_E_PARSE_ERROR = 10004,
		ACE_E_IN_PROGRESS = 10005
	}

	public struct AceValue
	{
		public AceValueKind kind;

		public int bool_value;

		public long int_value;

		public double double_value;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] string_value;
	}

	public enum AceValueKind
	{
		ACE_VALUE_NULL,
		ACE_VALUE_BOOL,
		ACE_VALUE_INT,
		ACE_VALUE_DOUBLE,
		ACE_VALUE_STRING
	}

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void BanCheckCallback(uint banned, IntPtr reason, IntPtr expiresAt);

	public delegate AceStatusCode Getter(StringBuilder sb, uint size);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void LicenseCallback(int status);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void LogCallbackW(IntPtr message);

	public const int ACE_BUFFER_SIZE_64 = 64;

	public const int ACE_BUFFER_SIZE_256 = 256;

	public const int ACE_BUFFER_SIZE_2048 = 2048;

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int ACE_CheckEnigma();

	public static AceStatusCode ACE_InitVariables()
	{
		return AceStatusCode.ACE_OK;
	}

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern void ACE_SetLogCallback(LogCallbackW cb);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int ACE_ProtectedStringByKey(string key, IntPtr buf, int len);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int ACE_ProtectedStringByKeyRaw(string key, IntPtr buf, int len);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int ACE_ProtectedStringByKeyAsAnsiString(string key, IntPtr buf, int len);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern int ACE_ProtectedStringByKeyAsWideString(string key, IntPtr buf, int len);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern AceStatusCode SetLicenseKey(string licenseKey);

	public static AceStatusCode SetClientVersion(string version)
	{
		return AceStatusCode.ACE_OK;
	}

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ActivateLicense();

	public static AceStatusCode IsLicenseGenuine()
	{
		return AceStatusCode.ACE_OK;
	}

	public static AceStatusCode IsLicenseValid()
	{
		return AceStatusCode.ACE_OK;
	}

	public static AceStatusCode Reset()
	{
		return AceStatusCode.ACE_OK;
	}

	public static AceStatusCode SetLicenseCallback(LicenseCallback callback)
	{
		return AceStatusCode.ACE_OK;
	}

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern AceStatusCode AuthenticateUser(string email, string password);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode LogoutUser();

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode GetUserMe();

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode GetUserLicenses();

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode GetUserLicenseEntitlements(uint licenseId);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode GetActivatedLicenseEntitlements();

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	public static extern AceStatusCode ACEW_SetLicenseKey(string licenseKey);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	public static extern AceStatusCode ACEW_AuthenticateUser(string email, string password);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACEW_GetLastErrorMessage(IntPtr buffer, uint length, out uint requiredLength);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode GetLastErrorMessage(IntPtr buffer, uint length, out uint requiredLength);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode GetLastHttpStatus(out uint statusCode);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode GetLastRetryAfterSeconds(out uint seconds);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastLicenseResult(out AceLicenseResult result);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastLicenseFeatureCount(out uint count);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastLicenseFeatureAt(uint index, out AceFeatureEntitlement feature);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastCustomerLoginResult(out AceCustomerLoginResult result);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastCustomerMeUser(out AceCustomerUser user);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetUserLicenseCount(out uint count);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetUserLicenseAt(uint index, out AceCustomerLicenseSummary license);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastUserLicenseEntitlementsResult(out AceLicenseEntitlementsResult result);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastUserLicenseEntitlementFeatureCount(out uint count);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastUserLicenseEntitlementFeatureAt(uint index, out AceFeatureEntitlement feature);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastActivatedLicenseEntitlementsResult(out AceActivatedLicenseEntitlementsResult result);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastActivatedLicenseEntitlementFeatureCount(out uint count);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_GetLastActivatedLicenseEntitlementFeatureAt(uint index, out AceFeatureEntitlement feature);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	public static extern int ACE_GetLicenseMetadata(string key, StringBuilder value, uint length);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	public static extern int ACE_GetLicenseKey(StringBuilder licenseKey, uint length);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern int ACE_GetLicenseExpiryDate(out uint expiryDate);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	public static extern int ACE_GetLicenseUserEmail(StringBuilder email, uint length);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	public static extern int ACE_GetLicenseUserName(StringBuilder name, uint length);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	public static extern int ACE_GetLicenseType(StringBuilder licenseType, uint length);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern double ACE_Enigma_Sin(double angle);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern double ACE_Enigma_Cos(double angle);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern double ACE_Enigma_Tan(double angle);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern double ACE_GetSecretNumber_unmanaged(int int_0, int int_1);

	[return: MarshalAs(UnmanagedType.I1)]
	public static bool ACE_CheckAll([MarshalAs(UnmanagedType.I1)] bool accepted, short state)
	{
		return true;
	}

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern float ACE_fVERSION();

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool ACE_IsOneBit(ulong value);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool ACE_IsFlagExist(ulong flags, ulong flag);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	public static extern bool ACE_IsFlagExistP(ulong flags, int flag);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.Cdecl)]
	public static extern void ACE_InitErrorReporting();

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
	public static extern void ACE_ReportError(string message, string stackTrace, string context);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
	public static extern void ACE_ReportErrorEx(string source, string type, string message, string stackTrace, string context, string userName, string version);

	public static string Utf8Z(byte[] bytes)
	{
		if (bytes != null && bytes.Length != 0)
		{
			int num = Array.IndexOf(bytes, (byte)0);
			if (num < 0)
			{
				num = bytes.Length;
			}
			if (num == 0)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString(bytes, 0, num);
		}
		return string.Empty;
	}

	public static string GetLastErrorMessageW()
	{
		uint requiredLength = 0u;
		ACEW_GetLastErrorMessage(IntPtr.Zero, 0u, out requiredLength);
		if (requiredLength == 0)
		{
			return string.Empty;
		}
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal((int)(requiredLength * 2));
			AceStatusCode aceStatusCode = ACEW_GetLastErrorMessage(intPtr, requiredLength, out requiredLength);
			if (aceStatusCode != AceStatusCode.ACE_OK)
			{
				return string.Format(Class16.smethod_0(1649053571), aceStatusCode);
			}
			return Marshal.PtrToStringUni(intPtr) ?? string.Empty;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public static string ProtectedStringAsWide(string key)
	{
		int num = ACE_ProtectedStringByKeyAsWideString(key, IntPtr.Zero, 0);
		if (num <= 0)
		{
			return string.Empty;
		}
		IntPtr intPtr = IntPtr.Zero;
		try
		{
			intPtr = Marshal.AllocHGlobal(num * 2);
			int num2 = ACE_ProtectedStringByKeyAsWideString(key, intPtr, num);
			if (num2 <= 0)
			{
				return string.Empty;
			}
			return Marshal.PtrToStringUni(intPtr) ?? string.Empty;
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(intPtr);
			}
		}
	}

	public static string PtrToWStringAndFree(IntPtr ptr)
	{
		if (ptr == IntPtr.Zero)
		{
			return string.Empty;
		}
		return Marshal.PtrToStringUni(ptr) ?? string.Empty;
	}

	public static string ProtectedStringByKey(string key)
	{
		int num = ACE_ProtectedStringByKey(key, IntPtr.Zero, 0);
		if (num <= 0)
		{
			return string.Empty;
		}
		IntPtr intPtr = Marshal.AllocHGlobal(num);
		try
		{
			int num2 = ACE_ProtectedStringByKey(key, intPtr, num);
			if (num2 <= 0)
			{
				return string.Empty;
			}
			string text = Marshal.PtrToStringUni(intPtr, num2 / 2) ?? string.Empty;
			int num3 = text.IndexOf('\0');
			return (num3 >= 0) ? text.Substring(0, num3) : text;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	public static string GetStringAdaptive(Getter getter)
	{
		uint num = 256u;
		for (int i = 0; i < 5; i++)
		{
			StringBuilder stringBuilder = new StringBuilder((int)num);
			switch (getter(stringBuilder, num))
			{
			case AceStatusCode.ACE_E_BUFFER_SIZE:
				break;
			case AceStatusCode.ACE_OK:
				return stringBuilder.ToString();
			default:
				return string.Empty;
			}
			num *= 2;
		}
		return string.Empty;
	}

	public static string GetString(Func<StringBuilder, uint, AceStatusCode> getter, uint initialSize = 256u)
	{
		StringBuilder stringBuilder = new StringBuilder((int)initialSize);
		AceStatusCode aceStatusCode = getter(stringBuilder, initialSize);
		if (aceStatusCode == AceStatusCode.ACE_E_BUFFER_SIZE)
		{
			stringBuilder = new StringBuilder(4096);
			aceStatusCode = getter(stringBuilder, 4096u);
		}
		if (aceStatusCode != AceStatusCode.ACE_OK)
		{
			return null;
		}
		return stringBuilder.ToString();
	}

	public static string FormatUnix(uint ts)
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(ts).ToLocalTime().ToString(Class16.smethod_0(1649006896));
	}

	public static bool IsSuccess(AceStatusCode statusCode)
	{
		return statusCode == AceStatusCode.ACE_OK;
	}

	public static string GetStatusString(AceStatusCode code)
	{
		return code switch
		{
			AceStatusCode.ACE_EXPIRED => Class16.smethod_0(1649053659), 
			AceStatusCode.ACE_SUSPENDED => Class16.smethod_0(1649052677), 
			AceStatusCode.ACE_GRACE_PERIOD_OVER => Class16.smethod_0(1649052717), 
			AceStatusCode.ACE_FAIL => Class16.smethod_0(1649053634), 
			AceStatusCode.ACE_OK => Class16.smethod_0(1649053611), 
			AceStatusCode.ACE_E_INET => Class16.smethod_0(1649052849), 
			AceStatusCode.ACE_E_BUFFER_SIZE => Class16.smethod_0(1649052882), 
			AceStatusCode.ACE_E_REVOKED => Class16.smethod_0(1649052933), 
			AceStatusCode.ACE_E_LICENSE_KEY => Class16.smethod_0(1649052963), 
			AceStatusCode.ACE_E_LICENSE_TYPE => Class16.smethod_0(1649053009), 
			AceStatusCode.ACE_E_ACTIVATION_LIMIT => Class16.smethod_0(1649053057), 
			AceStatusCode.ACE_E_ACTIVATION_NOT_FOUND => Class16.smethod_0(1649053113), 
			AceStatusCode.ACE_E_PRODUCT_ID => Class16.smethod_0(1649052813), 
			AceStatusCode.ACE_E_PRODUCT_DATA => Class16.smethod_0(1649052765), 
			AceStatusCode.ACE_E_LOGIN_TEMPORARILY_LOCKED => Class16.smethod_0(1649052375), 
			AceStatusCode.ACE_E_USER_NOT_AUTHENTICATED => Class16.smethod_0(1649052203), 
			AceStatusCode.ACE_E_RATE_LIMIT => Class16.smethod_0(1649052271), 
			AceStatusCode.ACE_E_SERVER => Class16.smethod_0(1649052299), 
			AceStatusCode.ACE_E_CLIENT => Class16.smethod_0(1649052341), 
			AceStatusCode.ACE_E_AUTHENTICATION_FAILED => Class16.smethod_0(1649053169), 
			AceStatusCode.ACE_E_HARDWARE_ID => Class16.smethod_0(1649052505), 
			AceStatusCode.ACE_E_NOT_INITIALIZED => Class16.smethod_0(1649052551), 
			AceStatusCode.ACE_E_INVALID_ARGUMENT => Class16.smethod_0(1649052597), 
			AceStatusCode.ACE_E_OUT_OF_RANGE => Class16.smethod_0(1649052645), 
			AceStatusCode.ACE_E_PARSE_ERROR => Class16.smethod_0(1649051661), 
			AceStatusCode.ACE_E_IN_PROGRESS => Class16.smethod_0(1649051691), 
			AceStatusCode.ACE_UPDATE_REQUIRED => Class16.smethod_0(1649052469), 
			AceStatusCode.ACE_E_OS_USER => Class16.smethod_0(1649052439), 
			_ => string.Format(Class16.smethod_0(1649051750), code), 
		};
	}

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_SetBanCheckCallback(BanCheckCallback callback);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern AceStatusCode ACE_EditorSessionStart(uint userId, uint licenseId, string editorVersion, out AceEditorSessionResult result);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_EditorSessionHeartbeat(uint sessionId, uint userId, uint durationSec, uint idleSec);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern AceStatusCode ACE_EditorSessionEnd(uint sessionId, uint userId, uint durationSec, uint idleSec, string activitySummaryJson);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern AceStatusCode ACE_EditorLogFolder(uint userId, uint sessionId, uint licenseId, string folderPath, string accessType, string folderType);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern AceStatusCode ACE_EditorLogFolderBatch(uint userId, uint sessionId, string accessesJsonArray);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
	public static extern AceStatusCode ACE_EditorLogFeature(uint userId, string featureKey);

	[DllImport("ACE_License.dll", CallingConvention = CallingConvention.StdCall)]
	public static extern AceStatusCode ACE_EditorCheckBan(out AceBanCheckResult result);
}
