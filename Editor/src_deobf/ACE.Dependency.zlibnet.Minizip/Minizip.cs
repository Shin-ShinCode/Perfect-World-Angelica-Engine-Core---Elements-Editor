using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACE.Dependency.zlibnet.Minizip;

internal static class Minizip
{
	public static Encoding OEMEncoding;

	static Minizip()
	{
		OEMEncoding = Encoding.GetEncoding((int)GetOEMCP());
		DllLoader.Load();
	}

	[DllImport("zlib32.dll", EntryPoint = "setOpenUnicode", ExactSpelling = true)]
	private static extern int setOpenUnicode_1(int int_0);

	[DllImport("zlib64.dll", EntryPoint = "setOpenUnicode", ExactSpelling = true)]
	private static extern int setOpenUnicode_2(int int_0);

	internal static bool setOpenUnicode(bool openUnicode)
	{
		int num = ((!ZLibDll.Is64) ? setOpenUnicode_1(openUnicode ? 1 : 0) : setOpenUnicode_2(openUnicode ? 1 : 0));
		return num == 1;
	}

	[DllImport("zlib32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
	private static extern IntPtr zipOpen64(string string_0, int int_0);

	[DllImport("zlib64.dll", CharSet = CharSet.Unicode, EntryPoint = "zipOpen64", ExactSpelling = true)]
	private static extern IntPtr zipOpen64_1(string string_0, int int_0);

	internal static IntPtr zipOpen(string fileName, bool append)
	{
		setOpenUnicode(openUnicode: true);
		if (ZLibDll.Is64)
		{
			return zipOpen64_1(fileName, append ? 1 : 0);
		}
		return zipOpen64(fileName, append ? 1 : 0);
	}

	[DllImport("zlib32.dll", EntryPoint = "zipOpenNewFileInZip4_64", ExactSpelling = true)]
	private static extern int zipOpenNewFileInZip4_64_1(IntPtr intptr_0, byte[] byte_0, ref ZipFileEntryInfo zipFileEntryInfo_0, byte[] byte_1, uint uint_0, byte[] byte_2, uint uint_1, byte[] byte_3, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_4, uint uint_2, uint uint_3, uint uint_4, int int_6);

	[DllImport("zlib64.dll", EntryPoint = "zipOpenNewFileInZip4_64", ExactSpelling = true)]
	private static extern int zipOpenNewFileInZip4_64_2(IntPtr intptr_0, byte[] byte_0, ref ZipFileEntryInfo zipFileEntryInfo_0, byte[] byte_1, uint uint_0, byte[] byte_2, uint uint_1, byte[] byte_3, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, byte[] byte_4, uint uint_2, uint uint_3, uint uint_4, int int_6);

	public static int zipOpenNewFileInZip4_64(IntPtr handle, byte[] entryName, ref ZipFileEntryInfo entryInfoPtr, byte[] extraField, uint extraFieldLength, byte[] extraFieldGlobal, uint extraFieldGlobalLength, byte[] comment, int method, int level, uint flagBase, bool zip64)
	{
		if (ZLibDll.Is64)
		{
			return zipOpenNewFileInZip4_64_2(handle, entryName, ref entryInfoPtr, extraField, extraFieldLength, extraFieldGlobal, extraFieldGlobalLength, comment, method, level, 0, -15, 8, 0, null, 0u, 0u, flagBase, zip64 ? 1 : 0);
		}
		return zipOpenNewFileInZip4_64_1(handle, entryName, ref entryInfoPtr, extraField, extraFieldLength, extraFieldGlobal, extraFieldGlobalLength, comment, method, level, 0, -15, 8, 0, null, 0u, 0u, flagBase, zip64 ? 1 : 0);
	}

	[DllImport("zlib32.dll", EntryPoint = "zipWriteInFileInZip", ExactSpelling = true)]
	private static extern int zipWriteInFileInZip_1(IntPtr intptr_0, IntPtr intptr_1, uint uint_0);

	[DllImport("zlib64.dll", EntryPoint = "zipWriteInFileInZip", ExactSpelling = true)]
	private static extern int zipWriteInFileInZip_2(IntPtr intptr_0, IntPtr intptr_1, uint uint_0);

	internal static int zipWriteInFileInZip(IntPtr handle, IntPtr buffer, uint count)
	{
		if (ZLibDll.Is64)
		{
			return zipWriteInFileInZip_2(handle, buffer, count);
		}
		return zipWriteInFileInZip_1(handle, buffer, count);
	}

	[DllImport("zlib32.dll", EntryPoint = "zipCloseFileInZip", ExactSpelling = true)]
	private static extern int zipCloseFileInZip_1(IntPtr intptr_0);

	[DllImport("zlib64.dll", EntryPoint = "zipCloseFileInZip", ExactSpelling = true)]
	private static extern int zipCloseFileInZip_2(IntPtr intptr_0);

	internal static int zipCloseFileInZip(IntPtr handle)
	{
		if (ZLibDll.Is64)
		{
			return zipCloseFileInZip_2(handle);
		}
		return zipCloseFileInZip_1(handle);
	}

	[DllImport("zlib32.dll", CharSet = CharSet.Ansi, EntryPoint = "zipClose", ExactSpelling = true)]
	private static extern int zipClose_1(IntPtr intptr_0, string string_0);

	[DllImport("zlib64.dll", CharSet = CharSet.Ansi, EntryPoint = "zipClose", ExactSpelling = true)]
	private static extern int zipClose_2(IntPtr intptr_0, string string_0);

	internal static int zipClose(IntPtr handle, string comment)
	{
		if (ZLibDll.Is64)
		{
			return zipClose_2(handle, comment);
		}
		return zipClose_1(handle, comment);
	}

	[DllImport("zlib32.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
	private static extern IntPtr unzOpen64(string string_0);

	[DllImport("zlib64.dll", CharSet = CharSet.Unicode, EntryPoint = "unzOpen64", ExactSpelling = true)]
	private static extern IntPtr unzOpen64_1(string string_0);

	internal static IntPtr unzOpen(string fileName)
	{
		setOpenUnicode(openUnicode: true);
		if (ZLibDll.Is64)
		{
			return unzOpen64_1(fileName);
		}
		return unzOpen64(fileName);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzClose", ExactSpelling = true)]
	private static extern int unzClose_1(IntPtr intptr_0);

	[DllImport("zlib64.dll", EntryPoint = "unzClose", ExactSpelling = true)]
	private static extern int unzClose_2(IntPtr intptr_0);

	internal static int unzClose(IntPtr handle)
	{
		if (ZLibDll.Is64)
		{
			return unzClose_2(handle);
		}
		return unzClose_1(handle);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzGetGlobalInfo", ExactSpelling = true)]
	private static extern int unzGetGlobalInfo_1(IntPtr intptr_0, out ZipFileInfo zipFileInfo_0);

	[DllImport("zlib64.dll", EntryPoint = "unzGetGlobalInfo", ExactSpelling = true)]
	private static extern int unzGetGlobalInfo_2(IntPtr intptr_0, out ZipFileInfo zipFileInfo_0);

	internal static int unzGetGlobalInfo(IntPtr handle, out ZipFileInfo globalInfoPtr)
	{
		if (ZLibDll.Is64)
		{
			return unzGetGlobalInfo_2(handle, out globalInfoPtr);
		}
		return unzGetGlobalInfo_1(handle, out globalInfoPtr);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzGetGlobalComment", ExactSpelling = true)]
	private static extern int unzGetGlobalComment_1(IntPtr intptr_0, byte[] byte_0, uint uint_0);

	[DllImport("zlib64.dll", EntryPoint = "unzGetGlobalComment", ExactSpelling = true)]
	private static extern int unzGetGlobalComment_2(IntPtr intptr_0, byte[] byte_0, uint uint_0);

	internal static int unzGetGlobalComment(IntPtr handle, byte[] commentBuffer, uint commentBufferLength)
	{
		if (ZLibDll.Is64)
		{
			return unzGetGlobalComment_2(handle, commentBuffer, commentBufferLength);
		}
		return unzGetGlobalComment_1(handle, commentBuffer, commentBufferLength);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzGoToFirstFile", ExactSpelling = true)]
	private static extern int unzGoToFirstFile_1(IntPtr intptr_0);

	[DllImport("zlib64.dll", EntryPoint = "unzGoToFirstFile", ExactSpelling = true)]
	private static extern int unzGoToFirstFile_2(IntPtr intptr_0);

	internal static int unzGoToFirstFile(IntPtr handle)
	{
		if (ZLibDll.Is64)
		{
			return unzGoToFirstFile_2(handle);
		}
		return unzGoToFirstFile_1(handle);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzGoToNextFile", ExactSpelling = true)]
	private static extern int unzGoToNextFile_1(IntPtr intptr_0);

	[DllImport("zlib64.dll", EntryPoint = "unzGoToNextFile", ExactSpelling = true)]
	private static extern int unzGoToNextFile_2(IntPtr intptr_0);

	internal static int unzGoToNextFile(IntPtr handle)
	{
		if (ZLibDll.Is64)
		{
			return unzGoToNextFile_2(handle);
		}
		return unzGoToNextFile_1(handle);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzGetCurrentFileInfo64", ExactSpelling = true)]
	private static extern int unzGetCurrentFileInfo64_1(IntPtr intptr_0, out ZipEntryInfo64 zipEntryInfo64_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1, byte[] byte_2, uint uint_2);

	[DllImport("zlib64.dll", EntryPoint = "unzGetCurrentFileInfo64", ExactSpelling = true)]
	private static extern int unzGetCurrentFileInfo64_2(IntPtr intptr_0, out ZipEntryInfo64 zipEntryInfo64_0, byte[] byte_0, uint uint_0, byte[] byte_1, uint uint_1, byte[] byte_2, uint uint_2);

	internal static int unzGetCurrentFileInfo64(IntPtr handle, out ZipEntryInfo64 entryInfoPtr, byte[] entryNameBuffer, uint entryNameBufferLength, byte[] extraField, uint extraFieldLength, byte[] commentBuffer, uint commentBufferLength)
	{
		if (ZLibDll.Is64)
		{
			return unzGetCurrentFileInfo64_2(handle, out entryInfoPtr, entryNameBuffer, entryNameBufferLength, extraField, extraFieldLength, commentBuffer, commentBufferLength);
		}
		return unzGetCurrentFileInfo64_1(handle, out entryInfoPtr, entryNameBuffer, entryNameBufferLength, extraField, extraFieldLength, commentBuffer, commentBufferLength);
	}

	[DllImport("kernel32.dll")]
	public static extern uint GetOEMCP();

	[DllImport("zlib32.dll", EntryPoint = "unzOpenCurrentFile", ExactSpelling = true)]
	public static extern int unzOpenCurrentFile_1(IntPtr handle);

	[DllImport("zlib64.dll", EntryPoint = "unzOpenCurrentFile", ExactSpelling = true)]
	public static extern int unzOpenCurrentFile_2(IntPtr handle);

	internal static int unzOpenCurrentFile(IntPtr handle)
	{
		if (ZLibDll.Is64)
		{
			return unzOpenCurrentFile_2(handle);
		}
		return unzOpenCurrentFile_1(handle);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzCloseCurrentFile", ExactSpelling = true)]
	public static extern int unzCloseCurrentFile_1(IntPtr handle);

	[DllImport("zlib64.dll", EntryPoint = "unzCloseCurrentFile", ExactSpelling = true)]
	public static extern int unzCloseCurrentFile_2(IntPtr handle);

	internal static int unzCloseCurrentFile(IntPtr handle)
	{
		if (ZLibDll.Is64)
		{
			return unzCloseCurrentFile_2(handle);
		}
		return unzCloseCurrentFile_1(handle);
	}

	[DllImport("zlib32.dll", EntryPoint = "unzReadCurrentFile", ExactSpelling = true)]
	private static extern int unzReadCurrentFile_1(IntPtr intptr_0, IntPtr intptr_1, uint uint_0);

	[DllImport("zlib64.dll", EntryPoint = "unzReadCurrentFile", ExactSpelling = true)]
	private static extern int unzReadCurrentFile_2(IntPtr intptr_0, IntPtr intptr_1, uint uint_0);

	internal static int unzReadCurrentFile(IntPtr handle, IntPtr buffer, uint count)
	{
		if (ZLibDll.Is64)
		{
			return unzReadCurrentFile_2(handle, buffer, count);
		}
		return unzReadCurrentFile_1(handle, buffer, count);
	}
}
