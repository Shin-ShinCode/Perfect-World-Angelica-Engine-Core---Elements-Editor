namespace ACE.Dependency.zlibnet.Minizip;

internal static class ZipReturnCode
{
	internal const int Ok = 0;

	internal const int Error = -1;

	internal const int EndOfListOfFile = -100;

	internal const int ParameterError = -102;

	internal const int BadZipFile = -103;

	internal const int InternalError = -104;

	internal const int CrcError = -105;

	public static string GetMessage(int retCode)
	{
		return retCode switch
		{
			0 => Class16.smethod_0(1648889739), 
			-1 => Class16.smethod_0(1648889754), 
			-105 => Class16.smethod_0(1648888865), 
			-104 => Class16.smethod_0(1648888844), 
			-103 => Class16.smethod_0(1648889834), 
			-102 => Class16.smethod_0(1648889820), 
			-100 => Class16.smethod_0(1648889782), 
			_ => Class16.smethod_0(1648888903) + retCode, 
		};
	}
}
