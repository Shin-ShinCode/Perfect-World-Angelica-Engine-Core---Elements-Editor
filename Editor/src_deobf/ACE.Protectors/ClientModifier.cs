using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Cpk;
using ACE.Pck;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Protectors;

public class ClientModifier
{
	public static CommonStorage CStorage;

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool PatchTasksLoading(string FileName, GAMES Game, string sVersion, int adding_key)
	{
		bool result = false;
		if (Game <= GAMES.UNKNOWN_GAME)
		{
			TextStorage.TEXTS.ShowErrorMessage(636);
			return false;
		}
		RSExeModifier rSExeModifier = new RSExeModifier(FileName);
		if (!rSExeModifier.FileLoaded)
		{
			return false;
		}
		try
		{
			switch (Game)
			{
			case GAMES.JD:
				ACE.RSGlobal.RSGlobal.ThrowExceptionG(Class16.smethod_0(1649175685));
				break;
			case GAMES.PW:
			{
				byte[] pW_TASKS_CHECKING_1_5_ = CLIENT_OFFSETS_MARKERS.PW_TASKS_CHECKING_1_5_3;
				if (rSExeModifier.SeekToMarker(pW_TASKS_CHECKING_1_5_, 0, IsMask: false, 0))
				{
					int int_ = Convert.ToInt32(Math.Floor(ACE.RSGlobal.RSGlobal.GetSecretNumber_unmanaged(adding_key, 71)));
					rSExeModifier.bw.Write(smethod_1(int_));
				}
				else
				{
					TextStorage.TEXTS.ThrowEcxeptionT(663, null);
				}
				break;
			}
			}
			result = true;
		}
		catch (Exception ex)
		{
			smethod_0(ex, Class16.smethod_0(1649175731));
			if (ex.GetType() == typeof(ApplicationException))
			{
				object[] vars = new object[1] { ex.Message };
				TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars);
			}
			else
			{
				ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			}
			result = false;
		}
		finally
		{
			rSExeModifier.Close();
		}
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool PatchElementsLoading(string FileName, GAMES Game, string sVersion, int adding_key)
	{
		bool result = false;
		if (Game <= GAMES.UNKNOWN_GAME)
		{
			TextStorage.TEXTS.ShowErrorMessage(636);
			return false;
		}
		RSExeModifier rSExeModifier = new RSExeModifier(FileName);
		if (!rSExeModifier.FileLoaded)
		{
			return false;
		}
		try
		{
			if (sVersion == Class16.smethod_0(1649007050) || sVersion == Class16.smethod_0(1649007050))
			{
				sVersion = null;
			}
			int position;
			byte[] pW_ELEMENTS_COUNT_1_5_3_FULL;
			switch (Game)
			{
			case GAMES.PW:
			{
				byte[] pW_ELEMENTS_SIGNATURE_UNIVERSAL = CLIENT_OFFSETS_MARKERS.PW_ELEMENTS_SIGNATURE_UNIVERSAL;
				if (!rSExeModifier.SeekToMarker(pW_ELEMENTS_SIGNATURE_UNIVERSAL, 0, IsMask: true, 173))
				{
					byte[] pW_ELEMENTS_SIGNATURE_UNIVERSAL_1_5_5_plus = CLIENT_OFFSETS_MARKERS.PW_ELEMENTS_SIGNATURE_UNIVERSAL_1_5_5_plus;
					if (!rSExeModifier.SeekToMarker(pW_ELEMENTS_SIGNATURE_UNIVERSAL_1_5_5_plus, 0, IsMask: true, 173))
					{
						TextStorage.TEXTS.ThrowEcxeptionT(661, null);
						goto IL_00ce;
					}
				}
				byte[] buffer4 = new byte[4];
				rSExeModifier.bw.Write(buffer4);
				rSExeModifier.bw.Write((byte)117);
				goto IL_00ce;
			}
			case GAMES.FW:
			{
				byte[] fW_ELEMENTS_SIGNATURE_UNIVERSAL = CLIENT_OFFSETS_MARKERS.FW_ELEMENTS_SIGNATURE_UNIVERSAL;
				if (rSExeModifier.SeekToMarker(fW_ELEMENTS_SIGNATURE_UNIVERSAL, 0, IsMask: true, 173))
				{
					byte[] buffer5 = new byte[4];
					rSExeModifier.bw.Write(buffer5);
					rSExeModifier.bw.Write((byte)117);
				}
				else
				{
					TextStorage.TEXTS.ThrowEcxeptionT(661, null);
				}
				break;
			}
			case GAMES.JD:
				{
					byte[] jD_ELEMENTS_SIGNATURE_158_ = CLIENT_OFFSETS_MARKERS.JD_ELEMENTS_SIGNATURE_158_1;
					if (rSExeModifier.SeekToMarker(jD_ELEMENTS_SIGNATURE_158_, 0, IsMask: false, 0))
					{
						byte[] buffer = new byte[4];
						rSExeModifier.bw.Write(buffer);
						byte b = rSExeModifier.ReadBytes(1)[0];
						if (b == 15)
						{
							byte[] buffer2 = new byte[2] { 15, 132 };
							rSExeModifier.bw.Write(buffer2);
						}
						else
						{
							rSExeModifier.bw.Write((byte)116);
						}
					}
					else
					{
						byte[] jD_ELEMENTS_SIGNATURE_ = CLIENT_OFFSETS_MARKERS.JD_ELEMENTS_SIGNATURE_150;
						if (rSExeModifier.SeekToMarker(jD_ELEMENTS_SIGNATURE_, 0, IsMask: false, 0))
						{
							byte[] buffer3 = new byte[4];
							rSExeModifier.bw.Write(buffer3);
							rSExeModifier.bw.Write((byte)117);
						}
						else
						{
							TextStorage.TEXTS.ThrowEcxeptionT(661, null);
						}
					}
					break;
				}
				IL_00ce:
				position = (int)rSExeModifier.fs.Position;
				pW_ELEMENTS_COUNT_1_5_3_FULL = CLIENT_OFFSETS_MARKERS.PW_ELEMENTS_COUNT_1_5_3_FULL;
				if (rSExeModifier.SeekToMarker(pW_ELEMENTS_COUNT_1_5_3_FULL, position, IsMask: false, 0))
				{
					rSExeModifier.bw.Write(smethod_2(ACE.RSGlobal.RSGlobal.GetElementsSecretNumber(adding_key, 0)));
					for (int i = 1; i <= 40; i++)
					{
						bool flag = false;
						int num = 0;
						int num2 = 0;
						while (true)
						{
							if (!flag)
							{
								int position2 = (int)rSExeModifier.fs.Position;
								byte[] pW_ELEMENTS_COUNT_NEXT_1_5_ = CLIENT_OFFSETS_MARKERS.PW_ELEMENTS_COUNT_NEXT_1_5_3;
								if (rSExeModifier.SeekToMarker(pW_ELEMENTS_COUNT_NEXT_1_5_, position2, IsMask: false, 0))
								{
									num2 = (int)rSExeModifier.fs.Position;
									long position3 = rSExeModifier.fs.Position + 9L;
									rSExeModifier.fs.Position = position3;
									byte[] array = rSExeModifier.ReadBytes(4);
									byte[] array2 = new byte[4] { 139, 68, 36, 16 };
									byte[] array3 = new byte[4] { 137, 68, 228, 16 };
									int num3 = ((ACE.RSGlobal.RSGlobal.IsArraysEquals(array2, array) || ACE.RSGlobal.RSGlobal.IsArraysEquals(array3, array)) ? 1 : 0);
									flag = (byte)num3 != 0;
									num++;
									if (num <= 5)
									{
										continue;
									}
									if (flag)
									{
										goto IL_0207;
									}
								}
								object[] vars = new object[1] { 1 };
								TextStorage.TEXTS.ThrowEcxeptionT(658, vars);
								break;
							}
							goto IL_0207;
							IL_0207:
							rSExeModifier.fs.Position = num2;
							rSExeModifier.bw.Write(smethod_2(ACE.RSGlobal.RSGlobal.GetElementsSecretNumber(adding_key, i)));
							break;
						}
					}
				}
				else
				{
					object[] vars2 = new object[1] { 0 };
					TextStorage.TEXTS.ThrowEcxeptionT(658, vars2);
				}
				break;
			}
			result = true;
		}
		catch (Exception ex)
		{
			smethod_0(ex, Class16.smethod_0(1649175770));
			if (ex.GetType() == typeof(ApplicationException))
			{
				object[] vars3 = new object[1] { ex.Message };
				TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars3);
			}
			else
			{
				ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			}
			result = false;
		}
		finally
		{
			rSExeModifier.Close();
		}
		return result;
	}

	public static byte[] GetFileTableXorInjectionPW(int FTO_KEY, [MarshalAs(UnmanagedType.U1)] bool bWithEnigmaMarkers, string sVer, int inject_len)
	{
		byte[] array = new byte[10] { 104, 228, 29, 67, 0, 233, 102, 168, 216, 0 };
		byte[] buffer = new byte[10] { 104, 124, 60, 67, 0, 233, 206, 137, 216, 0 };
		MemoryStream memoryStream = new MemoryStream();
		if (bWithEnigmaMarkers)
		{
			memoryStream.Write(array, 0, array.Length);
		}
		memoryStream.WriteByte(104);
		memoryStream.Write(BitConverter.GetBytes(FTO_KEY), 0, 4);
		byte value = (byte)((sVer == Class16.smethod_0(1649175820) || sVer == Class16.smethod_0(1649175824)) ? 88u : 89u);
		memoryStream.WriteByte(value);
		if (bWithEnigmaMarkers)
		{
			memoryStream.Write(buffer, 0, array.Length);
		}
		byte[] array2 = new byte[inject_len - (int)memoryStream.Length];
		int num = 0;
		if (0 < (nint)array2.LongLength)
		{
			do
			{
				array2[num] = 144;
				num++;
			}
			while (num < (nint)array2.LongLength);
		}
		memoryStream.Write(array2, 0, array2.Length);
		memoryStream.Close();
		return memoryStream.ToArray();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool ApplyClientPckPatch(string FileName, GAMES Game, string sVersion, PCK_PROTECTION_OPTIONS options, Hashtable ExtraFiles, string CustomFile, string CustomFile2, [MarshalAs(UnmanagedType.U1)] bool bUnprotect)
	{
		if (Game <= GAMES.UNKNOWN_GAME)
		{
			TextStorage.TEXTS.ShowErrorMessage(636);
			return false;
		}
		RSExeModifier rSExeModifier = new RSExeModifier(FileName);
		if (!rSExeModifier.FileLoaded)
		{
			return false;
		}
		bool result = false;
		try
		{
			if (!(sVersion == Class16.smethod_0(1649175840)))
			{
				if (sVersion == Class16.smethod_0(1649007050) || sVersion == Class16.smethod_0(1648897915))
				{
					sVersion = null;
				}
			}
			else
			{
				sVersion = Class16.smethod_0(1649175860);
			}
			if (bUnprotect)
			{
				PCK_PROTECTION_SETTINGS defaultKeys = PCK.GetDefaultKeys(Game);
				options.KEY_1 = defaultKeys.KEY_1;
				options.KEY_2 = defaultKeys.KEY_2;
				options.FTO_KEY = defaultKeys.FTO_KEY;
				options.MetaDataShift = defaultKeys.MetaDataShift;
			}
			if (options.KeysChanged)
			{
				int kEY_ = options.KEY_1;
				if (rSExeModifier.Write(CLIENT_OFFSETS_MARKERS.PCK_KEY1_UNIVERSAL, kEY_))
				{
					int value = options.KEY_2 ^ options.KEY_1;
					rSExeModifier.bw.Write(value);
				}
				else
				{
					TextStorage.TEXTS.ThrowEcxeptionT(637, null);
				}
			}
			if (Game == GAMES.PW)
			{
				if (options.MetaDataShifted)
				{
					int value2 = (int)(0 - options.MetaDataShift);
					if (sVersion == null || sVersion == Class16.smethod_0(1649175860) || sVersion == Class16.smethod_0(1649175840))
					{
						byte[] pW_PCK_METADATA_1_5_ = CLIENT_OFFSETS_MARKERS.PW_PCK_METADATA_1_5_3;
						if (rSExeModifier.SeekToMarker(pW_PCK_METADATA_1_5_, 0, IsMask: false, 0))
						{
							rSExeModifier.bw.Write(value2);
							goto IL_028e;
						}
					}
					if (sVersion == null || sVersion == Class16.smethod_0(1649175824))
					{
						byte[] pW_PCK_METADATA_1_4_8_v = CLIENT_OFFSETS_MARKERS.PW_PCK_METADATA_1_4_8_v85;
						if (rSExeModifier.SeekToMarker(pW_PCK_METADATA_1_4_8_v, 0, IsMask: false, 0))
						{
							rSExeModifier.bw.Write(value2);
							goto IL_028e;
						}
					}
					if (sVersion == null || sVersion == Class16.smethod_0(1649175864))
					{
						byte[] pW_PCK_METADATA_1_5_2 = CLIENT_OFFSETS_MARKERS.PW_PCK_METADATA_1_5_1;
						if (rSExeModifier.SeekToMarker(pW_PCK_METADATA_1_5_2, 0, IsMask: false, 0))
						{
							rSExeModifier.bw.Write(value2);
							goto IL_028e;
						}
					}
					if (sVersion == null || sVersion == Class16.smethod_0(1649175820))
					{
						byte[] pW_PCK_METADATA_1_3_ = CLIENT_OFFSETS_MARKERS.PW_PCK_METADATA_1_3_4;
						if (rSExeModifier.SeekToMarker(pW_PCK_METADATA_1_3_, 0, IsMask: false, 0))
						{
							rSExeModifier.bw.Write(value2);
							goto IL_028e;
						}
					}
					if (sVersion == null || sVersion == Class16.smethod_0(1649175884))
					{
						byte[] pW_PCK_METADATA_1_3_4_ = CLIENT_OFFSETS_MARKERS.PW_PCK_METADATA_1_3_4_2;
						if (rSExeModifier.SeekToMarker(pW_PCK_METADATA_1_3_4_, 0, IsMask: false, 0))
						{
							rSExeModifier.bw.Write(value2);
							goto IL_028e;
						}
					}
					if (sVersion == null || sVersion == Class16.smethod_0(1649175890))
					{
						byte[] pW_PCK_METADATA_1_4_5_v = CLIENT_OFFSETS_MARKERS.PW_PCK_METADATA_1_4_5_v69;
						if (rSExeModifier.SeekToMarker(pW_PCK_METADATA_1_4_5_v, 0, IsMask: false, 0))
						{
							rSExeModifier.bw.Write(value2);
							goto IL_028e;
						}
					}
					TextStorage.TEXTS.ThrowEcxeptionT(638, null);
				}
				goto IL_028e;
			}
			switch (Game)
			{
			case GAMES.JD:
				if (options.MetaDataShifted)
				{
					int value4 = (int)(0 - options.MetaDataShift);
					byte[] jD_PCK_METADATA_ = CLIENT_OFFSETS_MARKERS.JD_PCK_METADATA_422;
					if (rSExeModifier.SeekToMarker(jD_PCK_METADATA_, 0, IsMask: false, 0))
					{
						rSExeModifier.bw.Write(value4);
					}
					else
					{
						TextStorage.TEXTS.ThrowEcxeptionT(638, null);
					}
				}
				break;
			case GAMES.FW:
				if (options.MetaDataShifted)
				{
					int value3 = (int)(0 - options.MetaDataShift);
					byte[] fW_PCK_METADATA = CLIENT_OFFSETS_MARKERS.FW_PCK_METADATA;
					if (rSExeModifier.SeekToMarker(fW_PCK_METADATA, 0, IsMask: false, 0))
					{
						rSExeModifier.bw.Write(value3);
					}
					else
					{
						TextStorage.TEXTS.ThrowEcxeptionT(638, null);
					}
				}
				break;
			}
			goto IL_0604;
			IL_028e:
			string text3;
			int num;
			int num2;
			if (options.FTO_KEY_Changed)
			{
				if (sVersion == Class16.smethod_0(1649175884))
				{
					ACE.RSGlobal.RSGlobal.ThrowExceptionG(Class16.smethod_0(1649175906));
				}
				string text = Class16.smethod_0(1649144963);
				string text2 = Class16.smethod_0(1648927580);
				text3 = string.Concat(string.Concat(System.IO.Path.GetDirectoryName(FileName) + text2, System.IO.Path.GetFileNameWithoutExtension(FileName)), text);
				num = 0;
				if (File.Exists(text3) && new FileInfo(text3).Length > 70L)
				{
					FileStream fileStream = File.OpenRead(text3);
					BinaryReader binaryReader = new BinaryReader(fileStream);
					fileStream.Position = 8L;
					long position = binaryReader.ReadInt32();
					rSExeModifier.fs.Position = position;
					num = binaryReader.ReadInt32();
					if (bUnprotect)
					{
						byte[] buffer = binaryReader.ReadBytes(num);
						rSExeModifier.bw.Write(buffer);
					}
					binaryReader.Close();
					fileStream.Close();
					goto IL_0524;
				}
				if (sVersion == null || sVersion == Class16.smethod_0(1649175864) || sVersion == Class16.smethod_0(1649175860) || sVersion == Class16.smethod_0(1649175840))
				{
					byte[] pW_FILETABLE_1_5_3_Plus = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_5_3_Plus;
					if (rSExeModifier.SeekToMarker(pW_FILETABLE_1_5_3_Plus, 0, IsMask: false, 0))
					{
						num = 103;
						num2 = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_5_3_Plus.Length;
						sVersion = Class16.smethod_0(1649175860);
						goto IL_04b2;
					}
				}
				if (sVersion == null || sVersion == Class16.smethod_0(1649175820))
				{
					byte[] pW_FILETABLE_1_3_ = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_3_4;
					if (rSExeModifier.SeekToMarker(pW_FILETABLE_1_3_, 0, IsMask: false, 0))
					{
						num = 69;
						num2 = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_3_4.Length;
						sVersion = Class16.smethod_0(1649175820);
						goto IL_04b2;
					}
				}
				if (sVersion == null || sVersion == Class16.smethod_0(1649175890))
				{
					byte[] pW_FILETABLE_1_4_5_v = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_4_5_v69;
					if (rSExeModifier.SeekToMarker(pW_FILETABLE_1_4_5_v, 0, IsMask: false, 0))
					{
						num = 74;
						num2 = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_4_5_v69.Length;
						sVersion = Class16.smethod_0(1649175890);
						goto IL_04b2;
					}
				}
				if (sVersion == null || sVersion == Class16.smethod_0(1649175824))
				{
					byte[] pW_FILETABLE_1_4_8_v = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_4_8_v85;
					if (rSExeModifier.SeekToMarker(pW_FILETABLE_1_4_8_v, 0, IsMask: false, 0))
					{
						num = 77;
						num2 = CLIENT_OFFSETS_MARKERS.PW_FILETABLE_1_4_8_v85.Length;
						goto IL_04b2;
					}
				}
				TextStorage.TEXTS.ThrowEcxeptionT(639, null);
			}
			goto IL_0604;
			IL_0604:
			if (bUnprotect)
			{
				goto IL_060b;
			}
			goto IL_07e2;
			IL_0524:
			if (num <= 0)
			{
				goto IL_0604;
			}
			if (bUnprotect)
			{
				goto IL_060b;
			}
			rSExeModifier.bw.Write(GetFileTableXorInjectionPW(options.FTO_KEY, options.IsEnigmaEnabled, sVersion, num));
			goto IL_07e2;
			IL_07e2:
			string serverlistPath = options.ServerlistPath;
			if (serverlistPath != null)
			{
				string text4 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(Class16.smethod_0(1649199435), string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1649048735)]) + text4, serverlistPath)))
				{
					object[] vars = new object[1] { Class16.smethod_0(1649048735) };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars);
				}
				if (Game == GAMES.PW && (sVersion == null || !sVersion.StartsWith(Class16.smethod_0(1649175820), StringComparison.Ordinal)))
				{
					string serverlistPath2 = options.ServerlistPath;
					string text5 = Class16.smethod_0(1648927580);
					if (!rSExeModifier.ReplaceASCII(Class16.smethod_0(1649176026), string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1649048735)]) + text5, serverlistPath2)))
					{
						object[] vars2 = new object[1] { Class16.smethod_0(1649175041) };
						TextStorage.TEXTS.ThrowEcxeptionT(643, vars2);
					}
				}
			}
			string gShopPath = options.GShopPath;
			if (gShopPath != null)
			{
				string text6 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(Class16.smethod_0(1649175975), string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1648906382)]) + text6, gShopPath)))
				{
					object[] vars3 = new object[1] { Class16.smethod_0(1648906382) };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars3);
				}
			}
			string customFilePath = options.CustomFilePath;
			if (customFilePath != null)
			{
				string text7 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(CustomFile, string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1649175997)]) + text7, customFilePath)))
				{
					object[] vars4 = new object[1] { CustomFile };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars4);
				}
			}
			string customFile2Path = options.CustomFile2Path;
			if (customFile2Path != null)
			{
				string text8 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(CustomFile2, string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1649176015)]) + text8, customFile2Path)))
				{
					object[] vars5 = new object[1] { CustomFile2 };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars5);
				}
			}
			string pathDataPath = options.PathDataPath;
			if (pathDataPath != null)
			{
				string text9 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(Class16.smethod_0(1649116102), string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1648906425)]) + text9, pathDataPath)))
				{
					object[] vars6 = new object[1] { Class16.smethod_0(1648906425) };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars6);
				}
			}
			string elementsPath = options.ElementsPath;
			if (elementsPath != null)
			{
				string text10 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(Class16.smethod_0(1649199472), string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1648906367)]) + text10, elementsPath)))
				{
					object[] vars7 = new object[1] { Class16.smethod_0(1648906367) };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars7);
				}
			}
			string tasksPath = options.TasksPath;
			if (tasksPath != null)
			{
				string text11 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(Class16.smethod_0(1649199527), string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1648906421)]) + text11, tasksPath)))
				{
					object[] vars8 = new object[1] { Class16.smethod_0(1648906421) };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars8);
				}
			}
			goto IL_0ba6;
			IL_060b:
			string gShopPath2 = options.GShopPath;
			if (gShopPath2 != null)
			{
				string newValue = Class16.smethod_0(1649175975);
				string text12 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1648906382)]) + text12, gShopPath2), newValue))
				{
					object[] vars9 = new object[1] { Class16.smethod_0(1648906382) };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars9);
				}
			}
			string customFilePath2 = options.CustomFilePath;
			if (customFilePath2 != null)
			{
				string text13 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1649175997)]) + text13, customFilePath2), CustomFile))
				{
					object[] vars10 = new object[1] { CustomFile };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars10);
				}
			}
			string customFile2Path2 = options.CustomFile2Path;
			if (customFile2Path2 != null)
			{
				string text14 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1649176015)]) + text14, customFile2Path2), CustomFile2))
				{
					object[] vars11 = new object[1] { CustomFile2 };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars11);
				}
			}
			string pathDataPath2 = options.PathDataPath;
			if (pathDataPath2 != null)
			{
				string newValue2 = Class16.smethod_0(1649116102);
				string text15 = Class16.smethod_0(1648927580);
				if (!rSExeModifier.ReplaceASCII(string.Concat(ACE.RSGlobal.RSGlobal.GetFileBaseName((string)ExtraFiles[Class16.smethod_0(1648906425)]) + text15, pathDataPath2), newValue2))
				{
					object[] vars12 = new object[1] { Class16.smethod_0(1648906425) };
					TextStorage.TEXTS.ThrowEcxeptionT(643, vars12);
				}
			}
			goto IL_0ba6;
			IL_04b2:
			long position2 = rSExeModifier.fs.Position - (num2 + num);
			rSExeModifier.fs.Position = position2;
			FileStream fileStream2 = File.OpenWrite(text3);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream2);
			binaryWriter.Write(0);
			binaryWriter.Write(0);
			binaryWriter.Write((int)rSExeModifier.fs.Position);
			binaryWriter.Write(num);
			binaryWriter.Write(rSExeModifier.ReadBytes(num));
			binaryWriter.Close();
			fileStream2.Close();
			goto IL_0524;
			IL_0ba6:
			result = true;
		}
		catch (Exception ex)
		{
			smethod_0(ex, Class16.smethod_0(1649175076));
			if (ex.GetType() == typeof(ApplicationException))
			{
				object[] vars13 = new object[1] { ex.Message };
				TextStorage.TEXTS.ShowMessage(5, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, vars13);
			}
			else
			{
				ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			}
			result = false;
		}
		finally
		{
			rSExeModifier.Close();
		}
		return result;
	}

	private static void smethod_0(Exception exception_0, string string_0)
	{
		if (!(exception_0 is ApplicationException) && !(exception_0 is InvalidDataException) && !(exception_0 is EndOfStreamException) && !(exception_0 is IOException))
		{
			SentryHelper.CaptureException(exception_0, string_0);
			return;
		}
		string message = string_0 + Class16.smethod_0(1648908709) + exception_0.Message;
		SentryHelper.AddBreadcrumb(message, string_0 ?? Class16.smethod_0(1649175076), (BreadcrumbLevel)1);
	}

	public static PROTECTION_STATUS GetClientProtectionStatus(string FileName, GAMES Game, string sVersion)
	{
		if (Game <= GAMES.UNKNOWN_GAME)
		{
			return PROTECTION_STATUS.AVAILABLE;
		}
		RSExeModifier rSExeModifier = new RSExeModifier(FileName);
		if (!rSExeModifier.FileLoaded)
		{
			return PROTECTION_STATUS.AVAILABLE;
		}
		PROTECTION_STATUS result = PROTECTION_STATUS.AVAILABLE;
		try
		{
			if (sVersion == Class16.smethod_0(1649007050) || sVersion == Class16.smethod_0(1649007050))
			{
				sVersion = null;
			}
			PCK_PROTECTION_OPTIONS pCK_PROTECTION_OPTIONS = new PCK_PROTECTION_OPTIONS(PCK.GetDefaultKeys(Game), null);
			if (Game == GAMES.PW)
			{
				byte[] pCK_KEY1_UNIVERSAL = CLIENT_OFFSETS_MARKERS.PCK_KEY1_UNIVERSAL;
				if (rSExeModifier.SeekToMarker(pCK_KEY1_UNIVERSAL, 0, IsMask: false, 0))
				{
					int num = 0;
					num = BitConverter.ToInt32(rSExeModifier.ReadBytes(4), 0);
					result = ((num != pCK_PROTECTION_OPTIONS.KEY_1 && num != 9096951) ? PROTECTION_STATUS.PROTECTED : PROTECTION_STATUS.UNPROTECTED);
				}
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649175089));
		}
		finally
		{
			rSExeModifier.Close();
		}
		return result;
	}

	private static byte[] smethod_1(int int_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(new byte[3] { 131, 196, 16 });
		binaryWriter.Write(new byte[4] { 139, 68, 36, 32 });
		binaryWriter.Write((byte)5);
		binaryWriter.Write(BitConverter.GetBytes(int_0));
		binaryWriter.Write(new byte[4] { 137, 68, 228, 32 });
		byte[] array = new byte[39 - (int)memoryStream.Length];
		int num = 0;
		if (0 < (nint)array.LongLength)
		{
			do
			{
				array[num] = 144;
				num++;
			}
			while (num < (nint)array.LongLength);
		}
		memoryStream.Write(array, 0, array.Length);
		binaryWriter.Close();
		memoryStream.Close();
		return memoryStream.ToArray();
	}

	private static byte[] smethod_2(int int_0)
	{
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(new byte[4] { 139, 68, 36, 16 });
		binaryWriter.Write((byte)5);
		binaryWriter.Write(BitConverter.GetBytes(int_0));
		binaryWriter.Write(new byte[4] { 137, 68, 228, 16 });
		binaryWriter.Close();
		memoryStream.Close();
		return memoryStream.ToArray();
	}
}
