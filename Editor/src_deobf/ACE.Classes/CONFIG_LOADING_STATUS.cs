namespace ACE.Classes;

public enum CONFIG_LOADING_STATUS
{
	Success = 0,
	UnknownVersion = 1,
	VersionNotSupported = 2,
	Loading = 3,
	ProtectectedFile = 4,
	LicenseExpired = 5,
	LicenseBlocked = 6,
	LicenseReseted = 7,
	AuthenticationFailed = 8,
	LicenseNotSet = 254,
	GameNotSupported = 255,
	Error = 256
}
