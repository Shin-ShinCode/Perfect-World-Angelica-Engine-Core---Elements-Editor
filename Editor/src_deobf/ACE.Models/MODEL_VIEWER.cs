using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Models.ECM;
using ACE.NpcGen;
using ACE.Pck;
using ACE.RSGlobal;

namespace ACE.Models;

public class MODEL_VIEWER
{
	public static CommonStorage CStorage;

	public static BuildInModelView SKIPreview;

	public static Process process;

	public static Point Pos = default(Point);

	public static PCK_LIST PCKs;

	public static Form ParentWindow;

	public static IntPtr ParentHandle = default(IntPtr);

	public static IDictionary<string, List<vITEMPOS>> ModelsCache;

	public static PCK CurrentPck;

	public static IDictionary<int, List<int>> ModelFields;

	public static string sMALE = Class16.smethod_0(1648994632);

	public static string sFEMALE = Class16.smethod_0(1648994641);

	public static string[] ClassPrefixes = new string[3]
	{
		Class16.smethod_0(1649122508),
		Class16.smethod_0(1649122519),
		Class16.smethod_0(1648995192)
	};

	public string pck_name;

	public int ItemCount;

	public GENDER gender;

	public MODEL_TYPE model_type;

	public List<string> Paths;

	public static bool bWinPosHidden = false;

	public string LastShowedModel;

	public bool bLocalFile;

	private static object object_0 = new object();

	private static Font font_0;

	private static string string_0;

	public string sGender
	{
		get
		{
			if (gender == GENDER.MALE)
			{
				return sMALE;
			}
			return sFEMALE;
		}
	}

	public string ArmorPath
	{
		get
		{
			if (gender == GENDER.MALE)
			{
				return MalePath;
			}
			return FemalePath;
		}
	}

	public string FemalePath
	{
		get
		{
			string text = Class16.smethod_0(1648927580);
			string text2 = Class16.smethod_0(1648927580);
			string result = string.Concat(string.Concat(ModelsPath + text2, sFEMALE), text);
			GC.KeepAlive(this);
			return result;
		}
	}

	public string MalePath
	{
		get
		{
			string text = Class16.smethod_0(1648927580);
			string text2 = Class16.smethod_0(1648927580);
			string result = string.Concat(string.Concat(ModelsPath + text2, sMALE), text);
			GC.KeepAlive(this);
			return result;
		}
	}

	public string ModelsPath
	{
		get
		{
			string text = CommonStorage.AParams.ModelsPath;
			if (string.IsNullOrWhiteSpace(text))
			{
				text = Class16.smethod_0(1649122522);
			}
			string text2 = Class16.smethod_0(1648927580);
			string result = string.Concat(CommonStorage.AParams.ModelsPckBaseName + text2, text);
			GC.KeepAlive(this);
			return result;
		}
	}

	public MODEL_VIEWER(Form ParentWindow)
	{
		SetPackage(pck_name);
		InitViewerWindow();
		SetOwner(ParentWindow);
		int x = ParentWindow.Width + ParentWindow.Left;
		Pos.X = x;
		Pos.Y = -1;
		GC.KeepAlive(this);
	}

	public MODEL_VIEWER()
	{
		InitViewerWindow();
	}

	public void InitViewerWindow()
	{
	}

	public void SetOwner(Form owner)
	{
		if (owner != null && (owner.IsDisposed || owner.Disposing))
		{
			owner = null;
		}
		ParentWindow = owner;
		bool flag = false;
		try
		{
			bool num = owner?.IsHandleCreated ?? false;
			flag = num;
			ParentHandle = (num ? owner.Handle : IntPtr.Zero);
		}
		catch (ObjectDisposedException)
		{
			ParentWindow = null;
			ParentHandle = IntPtr.Zero;
			owner = null;
		}
		if (SKIPreview != null && !SKIPreview.IsDisposed && !SKIPreview.Disposing)
		{
			if (flag && owner != SKIPreview && !smethod_0(SKIPreview, owner))
			{
				try
				{
					SKIPreview.Owner = owner;
				}
				catch (OutOfMemoryException ex2)
				{
					SentryHelper.CaptureException(ex2, Class16.smethod_0(1649122557));
					if (CommonStorage.Params != null)
					{
						CommonStorage.Params.ShowModelPreview = false;
					}
					try
					{
						SKIPreview.Owner = null;
					}
					catch
					{
					}
				}
				catch (ArgumentException)
				{
					try
					{
						SKIPreview.Owner = null;
					}
					catch
					{
					}
				}
				catch (Exception) when (owner == null || owner.IsDisposed || owner.Disposing)
				{
				}
			}
			else
			{
				try
				{
					SKIPreview.Owner = null;
				}
				catch
				{
				}
			}
		}
		GC.KeepAlive(this);
	}

	private static bool smethod_0(Form form_0, Form form_1)
	{
		if (form_0 != null && form_1 != null)
		{
			if (form_0 == form_1)
			{
				return true;
			}
			Form form = form_1;
			while (true)
			{
				if (form != null)
				{
					if (form == form_0)
					{
						break;
					}
					form = form.Owner;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	private static Font smethod_1(Font font_1)
	{
		Font font = font_1 ?? SystemFonts.DefaultFont;
		string text = font.Name + Class16.smethod_0(1648905535) + font.SizeInPoints.ToString(Class16.smethod_0(1648952282)) + Class16.smethod_0(1648905535) + (int)font.Unit;
		lock (object_0)
		{
			if (font_0 == null || string_0 != text)
			{
				try
				{
					font_0?.Dispose();
				}
				catch
				{
				}
				font_0 = new Font(font, FontStyle.Bold);
				string_0 = text;
			}
			return font_0;
		}
	}

	private static void smethod_2()
	{
		lock (object_0)
		{
			if (font_0 != null)
			{
				try
				{
					font_0.Dispose();
				}
				catch
				{
				}
				font_0 = null;
			}
			string_0 = null;
		}
	}

	public void ResetPaths()
	{
		SetModelType(model_type);
	}

	public void SetGender(GENDER gender, [MarshalAs(UnmanagedType.U1)] bool bUpdateCache)
	{
		if (CurrentPck != null)
		{
			if (this.gender != gender)
			{
				this.gender = gender;
				SetModelType(model_type);
			}
			if (bUpdateCache)
			{
				UpdateElementsModelsCache();
			}
			LastShowedModel = null;
		}
	}

	public void SetPackage(string pck_name)
	{
		if (this.pck_name == pck_name)
		{
			GC.KeepAlive(this);
			return;
		}
		this.pck_name = pck_name;
		if (PCKs != null && !string.IsNullOrWhiteSpace(pck_name))
		{
			CurrentPck = PCKs[pck_name];
			if (CurrentPck == null)
			{
				Paths = null;
				GC.KeepAlive(this);
				return;
			}
			if (CurrentPck.Paths == null)
			{
				CurrentPck.CreatePathsArray();
			}
			if (CommonStorage.License.Special.ModelSelection)
			{
				UpdateElementsModelsCache();
				SetModelType(model_type);
			}
		}
		else
		{
			CurrentPck = null;
			Paths = null;
			GC.KeepAlive(this);
		}
	}

	public void UpdateDictionaries()
	{
		CreateSkiDictionary();
		CreateEcmDictionary();
		if (DataFiles.Game == GAMES.PW)
		{
			CreateArmorDictionary();
		}
		else
		{
			CreateSkiAndEcmDictionary();
		}
	}

	public void CreateSkiAndEcmDictionary()
	{
		if (CurrentPck == null)
		{
			return;
		}
		PCK currentPck = CurrentPck;
		currentPck.SkiAndEcmPaths = new List<string>(currentPck.Paths.Length);
		string[] paths = CurrentPck.Paths;
		int num = 0;
		if (0 < (nint)paths.LongLength)
		{
			do
			{
				ref string reference = ref paths[num];
				if (!string.IsNullOrWhiteSpace(reference) && (reference.EndsWith(Class16.smethod_0(1648906306)) || reference.EndsWith(Class16.smethod_0(1648906325))))
				{
					CurrentPck.SkiAndEcmPaths.Add(MakePath(ref reference));
				}
				num++;
			}
			while (num < (nint)paths.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void CreateSkiDictionary()
	{
		if (CurrentPck == null)
		{
			return;
		}
		CurrentPck.SkiPaths = new List<string>();
		string[] paths = CurrentPck.Paths;
		int num = 0;
		if (0 < (nint)paths.LongLength)
		{
			do
			{
				ref string reference = ref paths[num];
				if (!string.IsNullOrWhiteSpace(reference) && reference.EndsWith(Class16.smethod_0(1648906306)))
				{
					CurrentPck.SkiPaths.Add(MakePath(ref reference));
				}
				num++;
			}
			while (num < (nint)paths.LongLength);
		}
		GC.KeepAlive(this);
	}

	public void CreateArmorDictionary(string ArmorPath, ref List<string> dict)
	{
		if (CurrentPck == null)
		{
			return;
		}
		int length = ArmorPath.Length;
		int num = CurrentPck.Paths.Length;
		int num2 = 0;
		if (0 < num)
		{
			while (num2 < num)
			{
				ref string reference = ref CurrentPck.Paths[num2];
				if (reference.StartsWith(ArmorPath))
				{
					int length2 = reference.IndexOf(Class16.smethod_0(1648927580), length) + 1;
					string text = reference.Substring(0, length2);
					int length3 = text.Length - length - 1;
					string item = text.Substring(length, length3);
					if (!dict.Contains(item))
					{
						dict.Add(item);
					}
					num2++;
					if (num2 < num && CurrentPck.Paths[num2].StartsWith(text))
					{
						int num3 = num2 + 1;
						while (num3 < num)
						{
							num2++;
							num3++;
							if (num2 >= num || !CurrentPck.Paths[num2].StartsWith(text))
							{
								break;
							}
						}
					}
					num2--;
				}
				num2++;
				if (num2 >= num)
				{
					break;
				}
			}
		}
		GC.KeepAlive(this);
	}

	public void CreateArmorDictionary()
	{
		if (CurrentPck != null)
		{
			CurrentPck.MalePaths = new List<string>();
			CurrentPck.FemalePaths = new List<string>();
			if (pck_name.StartsWith(Class16.smethod_0(1649138031)))
			{
				CreateArmorDictionary(MalePath, ref CurrentPck.MalePaths);
				CreateArmorDictionary(FemalePath, ref CurrentPck.FemalePaths);
			}
		}
	}

	public void CreateEcmDictionary()
	{
		if (CurrentPck != null)
		{
			CurrentPck.EcmPaths = new List<string>();
			string[] paths = CurrentPck.Paths;
			int num = 0;
			if (0 < (nint)paths.LongLength)
			{
				do
				{
					ref string reference = ref paths[num];
					if (reference.EndsWith(Class16.smethod_0(1648906325)))
					{
						CurrentPck.EcmPaths.Add(MakePath(ref reference));
					}
					num++;
				}
				while (num < (nint)paths.LongLength);
			}
		}
		GC.KeepAlive(this);
	}

	public string MakePath(ref string path)
	{
		if (DataFiles.Game == GAMES.FW)
		{
			string text = path;
			string result = string.Concat(CurrentPck.BaseName + Class16.smethod_0(1648927580), text);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return path;
	}

	public void RunInBackground()
	{
		GC.KeepAlive(this);
	}

	public void HidePreviewWindow([MarshalAs(UnmanagedType.U1)] bool bCloseWindow)
	{
		if (SKIPreview != null && !SKIPreview.IsDisposed)
		{
			if (bCloseWindow)
			{
				try
				{
					SKIPreview.Close();
					SKIPreview.Dispose();
				}
				catch
				{
				}
				SKIPreview = null;
				smethod_2();
			}
			else
			{
				SKIPreview.Hide();
			}
		}
		LastShowedModel = null;
	}

	public void Show()
	{
		if (SKIPreview != null && !SKIPreview.IsDisposed)
		{
			SKIPreview.Show();
			if (ParentHandle != IntPtr.Zero)
			{
				ACE.RSGlobal.RSGlobal.SetForegroundWindow(ParentHandle);
			}
		}
		GC.KeepAlive(this);
	}

	private static bool smethod_3(ModelClass modelClass_0, string string_1)
	{
		if (modelClass_0 == null)
		{
			return false;
		}
		try
		{
			pwMeshContainer pwMeshContainer2 = null;
			if (modelClass_0.Type == ModelType.ECM && modelClass_0.ECM != null)
			{
				pwMeshContainer2 = CombineECMSkinMeshes(modelClass_0.ECM, modelClass_0.Skeleton);
			}
			else if (modelClass_0.skyfile != null && modelClass_0.skyfile.Length != 0)
			{
				MemoryStream memoryStream = new MemoryStream(modelClass_0.skyfile);
				try
				{
					if (!PWMeshReader.ReadFile(memoryStream))
					{
						return false;
					}
				}
				finally
				{
					((IDisposable)memoryStream).Dispose();
				}
				pwMeshContainer2 = PWMeshReader.pwMesh;
			}
			if (pwMeshContainer2 == null)
			{
				return false;
			}
			string text = string_1 ?? Class16.smethod_0(1649119432);
			smethod_4(modelClass_0, text);
			if (SKIPreview != null && !SKIPreview.IsDisposed)
			{
				SKIPreview.LoadModel(modelClass_0, text, pwMeshContainer2);
				SKIPreview.Show();
				SKIPreview.BringToFront();
				if (ParentHandle != IntPtr.Zero)
				{
					ACE.RSGlobal.RSGlobal.SetForegroundWindow(ParentHandle);
				}
				bWinPosHidden = false;
				return true;
			}
			return false;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649122597));
			return false;
		}
	}

	internal static pwMeshContainer CombineECMSkinMeshes(ECMModel ecm, Skeleton skeleton)
	{
		if (ecm?.SkiModels != null && ecm.SkiModels.Count != 0)
		{
			pwMeshContainer pwMeshContainer2 = ecm.SkiModels[0];
			if (pwMeshContainer2 == null)
			{
				return null;
			}
			if (skeleton != null)
			{
				pwMeshContainer2.BindSkeleton(skeleton);
			}
			return pwMeshContainer2;
		}
		return null;
	}

	public void SaveWindowPos([MarshalAs(UnmanagedType.U1)] bool writeSettings)
	{
		if (!bWinPosHidden && SKIPreview != null && !SKIPreview.IsDisposed && SKIPreview.Visible)
		{
			Pos = SKIPreview.Location;
			if (writeSettings)
			{
				CommonStorage.Profile.SaveSetting(Class16.smethod_0(1649144905), Pos);
			}
		}
		GC.KeepAlive(this);
	}

	public static void RunViewer([MarshalAs(UnmanagedType.U1)] bool bHideWindow)
	{
	}

	public static bool IsViewerAvailable()
	{
		if (SKIPreview != null && !SKIPreview.IsDisposed)
		{
			return SKIPreview.Visible;
		}
		return false;
	}

	private static void smethod_4(ModelClass modelClass_0, string string_1)
	{
		if (SKIPreview != null && !SKIPreview.IsDisposed)
		{
			if (SKIPreview == null)
			{
				return;
			}
			if (ParentWindow != null && !ParentWindow.IsDisposed && ParentWindow.IsHandleCreated && SKIPreview.Owner != ParentWindow && !smethod_0(SKIPreview, ParentWindow))
			{
				try
				{
					SKIPreview.Owner = ParentWindow;
				}
				catch (OutOfMemoryException ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649122788));
					if (CommonStorage.Params != null)
					{
						CommonStorage.Params.ShowModelPreview = false;
					}
				}
				catch
				{
				}
			}
			if (!string.IsNullOrWhiteSpace(string_1))
			{
				SKIPreview.Text = string_1;
			}
			return;
		}
		try
		{
			SKIPreview = new BuildInModelView(modelClass_0, string_1);
		}
		catch (OutOfMemoryException ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649122633));
			CommonStorage.Params.ShowModelPreview = false;
			SKIPreview = null;
			return;
		}
		catch (Exception ex3)
		{
			SentryHelper.CaptureException(ex3, Class16.smethod_0(1649122692));
			SKIPreview = null;
			return;
		}
		if (ParentWindow != null && !ParentWindow.IsDisposed && ParentWindow.IsHandleCreated)
		{
			try
			{
				SKIPreview.Owner = ParentWindow;
			}
			catch (OutOfMemoryException ex4)
			{
				SentryHelper.CaptureException(ex4, Class16.smethod_0(1649122723));
				if (CommonStorage.Params != null)
				{
					CommonStorage.Params.ShowModelPreview = false;
				}
			}
			catch
			{
			}
		}
		if (Pos.X > 0 || Pos.Y > 0)
		{
			SKIPreview.StartPosition = FormStartPosition.Manual;
			SKIPreview.Location = new Point(Pos.X, Pos.Y);
		}
	}

	public void ShowModelPreview(string ModelName, [MarshalAs(UnmanagedType.U1)] bool IsDir, string Caption)
	{
		string text = null;
		string text2 = null;
		if (!bLocalFile)
		{
			if (LastShowedModel == ModelName && IsViewerAvailable())
			{
				GC.KeepAlive(this);
				return;
			}
		}
		if (ACE.RSGlobal.RSGlobal.antirecurse_ShowModelPreview_MODEL_VIEWER)
		{
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_ShowModelPreview_MODEL_VIEWER = true;
		try
		{
			text = null;
			text2 = null;
			string text3 = null;
			if (!string.IsNullOrWhiteSpace(ModelName))
			{
				GENDER model_gender = GENDER.MALE;
				text3 = GetModelSkiPath(ModelName, IsDir, ref text, ref text2, ref model_gender);
				ModelClass modelClass = null;
				if (!string.IsNullOrWhiteSpace(text3))
				{
					if (!text3.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase) && !ModelName.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase))
					{
						modelClass = method_1(text, text2);
					}
					else
					{
						string string_ = (text3.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase) ? text3 : (text + Class16.smethod_0(1648927580) + text2 + Class16.smethod_0(1648906325)));
						modelClass = method_3(string_);
					}
					if (modelClass != null && ((modelClass.skyfile != null && modelClass.skyfile.Length != 0) || modelClass.ECM != null))
					{
						if (smethod_3(modelClass, Caption))
						{
							LastShowedModel = ModelName;
						}
						else
						{
							HidePreviewWindow(bCloseWindow: false);
						}
					}
					else
					{
						HidePreviewWindow(bCloseWindow: false);
					}
				}
				else
				{
					HidePreviewWindow(bCloseWindow: false);
				}
			}
			else
			{
				HidePreviewWindow(bCloseWindow: false);
				LastShowedModel = ModelName;
			}
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.antirecurse_ShowModelPreview_MODEL_VIEWER = false;
		}
	}

	public void ShowModelPreview(string ModelName, [MarshalAs(UnmanagedType.U1)] bool IsDir, ITEMPOS ItemPos)
	{
		string caption = ModelName;
		if (ItemPos != null)
		{
			caption = DataFiles.Elements.GetParsedItemName(ItemPos);
		}
		ShowModelPreview(ModelName, IsDir, caption);
	}

	public void ShowModelPreview(string ModelName, ITEMPOS ItemPos, int index)
	{
		string text = ModelName;
		string text2 = null;
		if (ItemPos != null)
		{
			text2 = DataFiles.Elements.GetParsedItemName(ItemPos);
		}
		if (!string.IsNullOrWhiteSpace(text2))
		{
			text = text2;
		}
		if (index > -1)
		{
			string text3 = Class16.smethod_0(1648924347);
			text = string.Concat(string.Concat(Class16.smethod_0(1648924364) + index, text3), text);
		}
		byte b = ((model_type == MODEL_TYPE.FASHION) ? ((byte)1) : ((byte)0));
		ShowModelPreview(ModelName, b != 0, text);
	}

	public void ShowModelPreview(string ModelName, ITEMPOS ItemPos)
	{
		string caption = ModelName;
		if (ItemPos != null)
		{
			caption = DataFiles.Elements.GetParsedItemName(ItemPos);
		}
		byte b = ((model_type == MODEL_TYPE.FASHION) ? ((byte)1) : ((byte)0));
		ShowModelPreview(ModelName, b != 0, caption);
	}

	public unsafe void ShowModelPreview(ITEMPOS ip, int int_0)
	{
		bLocalFile = false;
		if (int_0 != -1 && DataFiles.Elements.GetFieldType(ip.int_0, ip.int_1, int_0) == FIELDTYPE.file_model)
		{
			int int_1 = ip.int_1;
			int int_2 = ip.int_0;
			bool flag = default(bool);
			string text = DataFiles.Elements.GetFilePath(int_2, int_1, int_0, &flag);
			bool isDir = false;
			if (DataFiles.Elements.Game == GAMES.PW)
			{
				int int_3 = ip.int_0;
				ItemType listType = DataFiles.Elements.Lists[int_3].ListType;
				int int_4 = ip.int_0;
				string text2 = DataFiles.Elements.Lists[int_4].elementFields[int_0];
				isDir = IsDirModel(listType, text2);
				if ((listType == ItemType.PW_FASHION_ESSENCE || listType == ItemType.PW_FASHION2_ESSENCE) && text2 == Class16.smethod_0(1648960631))
				{
					switch (DataFiles.Elements.GetValueI(ip, Class16.smethod_0(1649055483)))
					{
					default:
						SetGender((GENDER)DataFiles.Elements.GetValueI(ip, Class16.smethod_0(1648956046)), bUpdateCache: false);
						break;
					case 10:
					{
						isDir = false;
						int int_6 = ip.int_1;
						int int_7 = ip.int_0;
						text = DataFiles.Elements.GetValue(int_7, int_6, Class16.smethod_0(1649136338));
						if (string.IsNullOrWhiteSpace(text))
						{
							int int_8 = ip.int_1;
							int int_9 = ip.int_0;
							text = DataFiles.Elements.GetValue(int_9, int_8, Class16.smethod_0(1649136361));
						}
						break;
					}
					case 9:
						ip = DataFiles.Elements.FindItemPos(ip, Class16.smethod_0(1649121818));
						if (ip != null)
						{
							int int_5 = ip.int_0;
							eListCollection elements = DataFiles.Elements;
							ShowModelPreview(ip, elements.Lists[int_5].ModelFieldIndex);
						}
						else
						{
							HidePreviewWindow(bCloseWindow: false);
						}
						GC.KeepAlive(this);
						return;
					}
				}
			}
			text = PCK.FixPath(text);
			string caption = text;
			if (ip != null)
			{
				caption = DataFiles.Elements.GetParsedItemName(ip);
			}
			ShowModelPreview(text, isDir, caption);
		}
		else
		{
			ShowModelPreview(ip);
		}
	}

	public void ShowModelPreview(ITEMPOS ip)
	{
		if (ip != null && DataFiles.Elements.Lists[ip.int_0].ModelFieldIndex > 0)
		{
			int itemModelIndex = DataFiles.Elements.GetItemModelIndex(ip.int_0, ip.int_1);
			ShowModelPreview(ip, itemModelIndex);
		}
		GC.KeepAlive(this);
	}

	public unsafe string GetModelFilePath(int int_0, int int_1, int int_2)
	{
		string text = null;
		string text2 = null;
		bool flag = default(bool);
		string filePath = DataFiles.Elements.GetFilePath(int_0, int_1, int_2, &flag);
		filePath = PCK.FixPath(filePath);
		bool isDir;
		if (!(isDir = IsDirModel(int_0, int_2)))
		{
			return filePath;
		}
		text = null;
		text2 = null;
		GENDER model_gender = (GENDER)(-1);
		object obj = null;
		if (!string.IsNullOrWhiteSpace(filePath))
		{
			obj = GetModelSkiPath(filePath, isDir, ref text, ref text2, ref model_gender);
		}
		return (string)obj;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public static bool IsDirModel(ItemType listType, string field)
	{
		int num = ((field == Class16.smethod_0(1648960631) && (listType == ItemType.PW_ARMOR_ESSENCE || listType == ItemType.PW_NEW_ARMOR_ESSENCE || listType == ItemType.PW_FASHION_ESSENCE || listType == ItemType.PW_FASHION2_ESSENCE)) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsDirModel(int int_0, int int_1)
	{
		if (DataFiles.Elements.Game == GAMES.PW)
		{
			ItemType listType = DataFiles.Elements.Lists[int_0].ListType;
			string field = DataFiles.Elements.Lists[int_0].elementFields[int_1];
			bool result = IsDirModel(listType, field);
			GC.KeepAlive(this);
			return result;
		}
		GC.KeepAlive(this);
		return false;
	}

	public GENDER GetModelGender(string ModelName)
	{
		string text = null;
		string ModelDir = null;
		text = ACE.RSGlobal.RSGlobal.GetFileBaseName(ModelName);
		GENDER model_gender = (GENDER)(-1);
		if (ModelName != null)
		{
			byte b = ((!ModelName.Contains(Class16.smethod_0(1648927580))) ? ((byte)1) : ((byte)0));
			GetModelSkiPath(ModelName, b != 0, ref ModelDir, ref text, ref model_gender);
		}
		GC.KeepAlive(this);
		return model_gender;
	}

	public unsafe string GetModelSkiPath(string ModelName, [MarshalAs(UnmanagedType.U1)] bool IsDir, ref string ModelDir, ref string ModelBaseName, ref GENDER model_gender)
	{
		string text = null;
		if (ModelName.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
		{
			GC.KeepAlive(this);
			return null;
		}
		ModelBaseName = ACE.RSGlobal.RSGlobal.GetFileBaseName(ModelName);
		string text2 = null;
		if (!bLocalFile)
		{
			string package = CommonStorage.AParams.ModelsPckBaseName;
			if (ModelName.Contains(Class16.smethod_0(1648927580)))
			{
				package = ACE.RSGlobal.RSGlobal.GetPathRoot(ModelName);
			}
			SetPackage(package);
		}
		if (!string.IsNullOrWhiteSpace(ModelName) && (CurrentPck != null || bLocalFile))
		{
			// ECM files are complete model entry points, not model names that should be
			// resolved to a sibling SKI first. Returning the ECM path lets
			// ShowModelPreview route it through method_3, which loads its skeleton,
			// animations, and referenced skin model.
			if (!IsDir && ModelName.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase))
			{
				ModelDir = System.IO.Path.GetDirectoryName(ModelName);
				model_gender = gender;
				// Let the ECM loader perform the actual read. PCK path lookup can reject
				// valid Unicode/relative entries even though GetFileB can resolve them.
				text2 = ModelName;
			}
			else if (IsDir)
			{
				GENDER gENDER = gender;
				int num = 0;
				if (0 < (nint)ClassPrefixes.LongLength)
				{
					do
					{
						string text3 = ClassPrefixes[num];
						if (num == 0)
						{
							text3 = sGender + text3;
						}
						else if (num == 2)
						{
							gender = GENDER.FEMALE;
						}
						string text4 = Class16.smethod_0(1649121832);
						ModelBaseName = string.Concat(text3 + ModelName, text4);
						string text5 = (ModelDir = ArmorPath + ModelName);
						string text6 = Class16.smethod_0(1648906306);
						string text7 = ModelBaseName;
						text2 = string.Concat(string.Concat(text5 + Class16.smethod_0(1648927580), text7), text6);
						text = text2;
						PCK currentPck = CurrentPck;
						int num2 = -1;
						if (currentPck.TryGetFileIndex(ref text, &num2))
						{
							break;
						}
						num++;
					}
					while (num < (nint)ClassPrefixes.LongLength);
				}
				model_gender = gender;
				gender = gENDER;
			}
			else
			{
				model_gender = gender;
				if (!bLocalFile && !ModelName.StartsWith(pck_name))
				{
					ModelName = string.Concat(pck_name + Class16.smethod_0(1648927580), ModelName);
				}
				ModelDir = System.IO.Path.GetDirectoryName(ModelName);
				if (ModelName.EndsWith(Class16.smethod_0(1648906306)))
				{
					FileExists(ModelName);
					text2 = ModelName;
				}
				else
				{
					string text8 = Class16.smethod_0(1648906306);
					string text9 = ModelBaseName;
					text2 = string.Concat(string.Concat(ModelDir + Class16.smethod_0(1648927580), text9), text8);
					bool flag;
					if (!(flag = FileExists(text2)))
					{
						string text10 = (ModelBaseName += Class16.smethod_0(1649121843));
						string text11 = Class16.smethod_0(1648906306);
						text2 = string.Concat(string.Concat(ModelDir + Class16.smethod_0(1648927580), text10), text11);
						flag = FileExists(text2);
					}
					byte[] array = null;
					if (!flag)
					{
						array = GetFileB(ModelName);
					}
					if (array != null && (nint)array.LongLength > 0)
					{
						string name = Class16.smethod_0(1648921191);
						string text12 = null;
						text2 = null;
						MemoryStream memoryStream = new MemoryStream(array);
						try
						{
							StreamReader streamReader = new StreamReader(memoryStream, Encoding.GetEncoding(name));
							try
							{
								string text13 = streamReader.ReadLine();
								if (text13 != null)
								{
									do
									{
										if (text13.StartsWith(Class16.smethod_0(1649121851)))
										{
											string text14 = text13;
											text12 = text14.Substring(text14.IndexOf(Class16.smethod_0(1648924402)) + 1).Trim().ToLowerInvariant();
										}
										else if (text13.StartsWith(Class16.smethod_0(1649121872)))
										{
											string text15 = text13;
											text2 = text15.Substring(text15.IndexOf(Class16.smethod_0(1648924402)) + 1).Trim().ToLowerInvariant();
										}
										text13 = streamReader.ReadLine();
									}
									while (text13 != null);
								}
							}
							finally
							{
								((IDisposable)streamReader).Dispose();
							}
						}
						finally
						{
							((IDisposable)memoryStream).Dispose();
						}
						if (text12 != null)
						{
							byte[] fileB = GetFileB(text12);
							if (fileB != null && !string.IsNullOrWhiteSpace(ModelBaseName = SMD.GetSkiName(fileB)))
							{
								if (ModelBaseName.EndsWith(Class16.smethod_0(1648906306)))
								{
									int length = ModelBaseName.Length - 4;
									ModelBaseName = ModelBaseName.Substring(0, length);
								}
								string text16 = Class16.smethod_0(1648906306);
								string text17 = ModelBaseName;
								flag = FileExists(string.Concat(string.Concat(ModelDir + Class16.smethod_0(1648927580), text17), text16));
							}
						}
						if (!flag && text2 != null)
						{
							FileExists(text2);
							ModelBaseName = ACE.RSGlobal.RSGlobal.GetFileBaseName(text2);
						}
					}
				}
			}
		}
		GC.KeepAlive(this);
		return text2;
	}

	public void ResetModel()
	{
		LastShowedModel = null;
	}

	public static void ShowModelFromFile(string fn)
	{
		new MODEL_VIEWER().ShowModelPreviewLocal(fn);
	}

	public void ShowModelPreviewLocal(string fn)
	{
		bLocalFile = true;
		if (fn.EndsWith(Class16.smethod_0(1648906325), StringComparison.OrdinalIgnoreCase))
		{
			ModelClass modelClass = method_3(fn);
			if (modelClass != null)
			{
				if (!smethod_3(modelClass, fn))
				{
					HidePreviewWindow(bCloseWindow: false);
				}
				bLocalFile = false;
				return;
			}
		}
		ShowModelPreview(fn, IsDir: false, fn);
		if (SKIPreview != null && !SKIPreview.IsDisposed)
		{
			SKIPreview.Show();
		}
		bLocalFile = false;
	}

	private byte[] method_0()
	{
		return method_7(SKI.emptySki, null, null);
	}

	private ModelClass method_1(string string_1, string string_2)
	{
		string text = Class16.smethod_0(1648906306);
		byte[] fileB = GetFileB(string.Concat(string.Concat(string_1 + Class16.smethod_0(1648927580), string_2), text));
		return method_2(fileB, string_1, string_2);
	}

	private ModelClass method_2(byte[] byte_0, string string_1, string string_2)
	{
		if (byte_0 != null && byte_0.Length != 0)
		{
			ModelClass modelClass = new ModelClass();
			modelClass.skyfile = byte_0;
			modelClass.Type = ModelType.SKI;
			SKI sKI = new SKI(byte_0);
			if (!sKI.Loaded)
			{
				return null;
			}
			if (sKI.metadata.textCount > 0 && sKI.Textures != null)
			{
				byte[][] textures = sKI.Textures;
				foreach (byte[] array in textures)
				{
					if (array == null)
					{
						continue;
					}
					string text = ACE.RSGlobal.RSGlobal.ToStringGBK(array);
					int num = text.IndexOf('\0');
					string text2 = ((num >= 0) ? text.Substring(0, num) : text).ToLowerInvariant();
					if (string.IsNullOrWhiteSpace(text2) || modelClass.DDSIMAGE.ContainsKey(text2))
					{
						continue;
					}
					string[] array2 = new string[2];
					string text3 = Class16.smethod_0(1648927580);
					array2[0] = string.Concat(string.Concat(string.Concat(string_1 + Class16.smethod_0(1649121900), string_2), text3), text2);
					array2[1] = string.Concat(string_1 + Class16.smethod_0(1649121904), text2);
					byte[] array3 = null;
					foreach (string fn in array2)
					{
						array3 = GetFileB(fn);
						if (array3 != null)
						{
							break;
						}
					}
					if (array3 != null)
					{
						modelClass.DDSIMAGE[text2] = array3;
					}
				}
			}
			return modelClass;
		}
		return null;
	}

	private ModelClass method_3(string string_1)
	{
		try
		{
			string directoryName = System.IO.Path.GetDirectoryName(string_1);
			string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(string_1);
			ModelClass modelClass = new ModelClass();
			modelClass.Type = ModelType.ECM;
			string[] array = new string[2]
			{
				string_1.Replace(Class16.smethod_0(1648906325), Class16.smethod_0(1648906306)).Replace(Class16.smethod_0(1649123302), Class16.smethod_0(1648906306)),
				System.IO.Path.Combine(directoryName, fileNameWithoutExtension + Class16.smethod_0(1648906306))
			};
			string[] array2 = array;
			foreach (string fn in array2)
			{
				byte[] fileB = GetFileB(fn);
				if (fileB != null && fileB.Length != 0)
				{
					modelClass.skyfile = fileB;
					break;
				}
			}
			byte[] fileB2 = GetFileB(string_1);
			string text = null;
			if (fileB2 != null && fileB2.Length != 0)
			{
				Func<string, byte[]> fileLoader = method_10;
				try
				{
					ECMModel eCMModel = (modelClass.ECM = ECMModel.Load(fileB2, string_1, fileLoader));
					if (eCMModel != null && eCMModel.SkinModelPath != null)
					{
						text = eCMModel.SkinModelPath;
					}
					if (eCMModel?.SMD?.Skeleton != null)
					{
						modelClass.Skeleton = eCMModel.SMD.Skeleton;
						modelClass.Animator = new Animator(eCMModel.SMD.Skeleton);
						if (eCMModel.SMD.Animations != null)
						{
							foreach (SkinModelAction animation in eCMModel.SMD.Animations)
							{
								if (string.IsNullOrEmpty(animation.TrackFileName))
								{
									continue;
								}
								string[] array3 = new string[3]
								{
									string.Empty,
									Class16.smethod_0(1649121921),
									Class16.smethod_0(1649121941)
								};
								string[] array4 = array3;
								foreach (string text2 in array4)
								{
									string text3 = animation.TrackFileName;
									if (!string.IsNullOrEmpty(text2) && !text3.EndsWith(text2, StringComparison.OrdinalIgnoreCase))
									{
										text3 = System.IO.Path.GetFileNameWithoutExtension(text3) + text2;
									}
									string text4 = System.IO.Path.Combine(eCMModel.SMD.RelativePath ?? directoryName, eCMModel.SMD.AnimationFilePath ?? string.Empty, text3);
									byte[] fileB3 = GetFileB(text4);
									if (fileB3 != null)
									{
										TrackSet trackSet = TrackSet.Load(fileB3, text4);
										if (trackSet != null)
										{
											modelClass.Animations.Add(trackSet);
											break;
										}
									}
								}
							}
						}
						if (modelClass.Animations.Count == 0 && !string.IsNullOrEmpty(eCMModel.SMD.AnimationFilePath))
						{
							string string_2 = System.IO.Path.Combine(eCMModel.SMD.RelativePath ?? directoryName, eCMModel.SMD.AnimationFilePath);
							method_4(modelClass, string_2);
						}
					}
				}
				catch
				{
				}
			}
			if (modelClass.Skeleton == null)
			{
				string[] array5 = new string[3]
				{
					(text == null) ? null : (text.Contains(Class16.smethod_0(1648927580)) ? text : System.IO.Path.Combine(directoryName, text)),
					string_1.Replace(Class16.smethod_0(1648906325), Class16.smethod_0(1649121944)).Replace(Class16.smethod_0(1649123302), Class16.smethod_0(1649121944)),
					System.IO.Path.Combine(directoryName, fileNameWithoutExtension + Class16.smethod_0(1649121944))
				};
				string[] array6 = array5;
				foreach (string text5 in array6)
				{
					if (string.IsNullOrEmpty(text5))
					{
						continue;
					}
					byte[] fileB4 = GetFileB(text5);
					if (fileB4 == null || fileB4.Length == 0)
					{
						continue;
					}
					try
					{
						Func<string, byte[]> fileLoader2 = method_11;
						SkinModelData skinModelData = SkinModelData.Load(fileB4, text5, fileLoader2);
						if (skinModelData?.Skeleton == null)
						{
							continue;
						}
						modelClass.Skeleton = skinModelData.Skeleton;
						modelClass.Animator = new Animator(skinModelData.Skeleton);
						if (skinModelData.Animations == null)
						{
							break;
						}
						foreach (SkinModelAction animation2 in skinModelData.Animations)
						{
							if (string.IsNullOrEmpty(animation2.TrackFileName))
							{
								continue;
							}
							string text6 = System.IO.Path.Combine(skinModelData.RelativePath ?? directoryName, skinModelData.AnimationFilePath ?? string.Empty, animation2.TrackFileName);
							byte[] fileB5 = GetFileB(text6);
							if (fileB5 != null)
							{
								TrackSet trackSet2 = TrackSet.Load(fileB5, text6);
								if (trackSet2 != null)
								{
									modelClass.Animations.Add(trackSet2);
								}
							}
						}
						break;
					}
					catch
					{
					}
				}
			}
			if (modelClass.Skeleton == null)
			{
				string[] array7 = new string[2]
				{
					string_1.Replace(Class16.smethod_0(1648906325), Class16.smethod_0(1649121955)).Replace(Class16.smethod_0(1649123302), Class16.smethod_0(1649121955)),
					System.IO.Path.Combine(directoryName, fileNameWithoutExtension + Class16.smethod_0(1649121955))
				};
				string[] array8 = array7;
				foreach (string text7 in array8)
				{
					byte[] fileB6 = GetFileB(text7);
					if (fileB6 != null && fileB6.Length != 0)
					{
						Skeleton skeleton = Skeleton.Load(fileB6, text7);
						if (skeleton != null)
						{
							modelClass.Skeleton = skeleton;
							modelClass.Animator = new Animator(skeleton);
							string string_3 = System.IO.Path.Combine(directoryName, Class16.smethod_0(1649122471) + fileNameWithoutExtension);
							method_4(modelClass, string_3);
							break;
						}
					}
				}
			}
			if (modelClass.Animator != null && modelClass.Animations.Count > 0)
			{
				modelClass.PlayAnimation(0);
			}
			if (modelClass.ECM != null)
			{
				method_6(modelClass, modelClass.ECM);
			}
			if (modelClass.skyfile != null)
			{
				method_5(modelClass, directoryName, fileNameWithoutExtension);
			}
			return modelClass;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649121974));
			return null;
		}
	}

	private void method_4(ModelClass modelClass_0, string string_1)
	{
		string[] array = new string[41]
		{
			Class16.smethod_0(1649122012),
			Class16.smethod_0(1649122019),
			Class16.smethod_0(1649122034),
			Class16.smethod_0(1649122048),
			Class16.smethod_0(1649122065),
			Class16.smethod_0(1649122081),
			Class16.smethod_0(1649122097),
			Class16.smethod_0(1649122119),
			Class16.smethod_0(1649122119),
			Class16.smethod_0(1649122119),
			Class16.smethod_0(1649122119),
			Class16.smethod_0(1649122119),
			Class16.smethod_0(1649122119),
			Class16.smethod_0(1649122132),
			Class16.smethod_0(1649122138),
			Class16.smethod_0(1649122152),
			Class16.smethod_0(1649122174),
			Class16.smethod_0(1649122189),
			Class16.smethod_0(1649122204),
			Class16.smethod_0(1649122211),
			Class16.smethod_0(1649122237),
			Class16.smethod_0(1649122255),
			Class16.smethod_0(1649122265),
			Class16.smethod_0(1649122292),
			Class16.smethod_0(1649121287),
			Class16.smethod_0(1649121298),
			Class16.smethod_0(1649121314),
			Class16.smethod_0(1649121330),
			Class16.smethod_0(1649121345),
			Class16.smethod_0(1649121363),
			Class16.smethod_0(1649121388),
			Class16.smethod_0(1649121405),
			Class16.smethod_0(1649121420),
			Class16.smethod_0(1649121420),
			Class16.smethod_0(1649121420),
			Class16.smethod_0(1649121420),
			Class16.smethod_0(1649121420),
			Class16.smethod_0(1649121420),
			Class16.smethod_0(1649121426),
			Class16.smethod_0(1649121442),
			Class16.smethod_0(1649121459)
		};
		string[] array2 = array;
		foreach (string path in array2)
		{
			string text = System.IO.Path.Combine(string_1, path);
			byte[] fileB = GetFileB(text);
			if (fileB != null)
			{
				TrackSet trackSet = TrackSet.Load(fileB, text);
				if (trackSet != null)
				{
					modelClass_0.Animations.Add(trackSet);
				}
			}
		}
	}

	private void method_5(ModelClass modelClass_0, string string_1, string string_2)
	{
		try
		{
			SKI sKI = new SKI(modelClass_0.skyfile);
			if (!sKI.Loaded || sKI.Textures == null)
			{
				return;
			}
			byte[][] textures = sKI.Textures;
			foreach (byte[] array in textures)
			{
				if (array == null)
				{
					continue;
				}
				string text = ACE.RSGlobal.RSGlobal.ToStringGBK(array);
				int num = text.IndexOf('\0');
				if (num >= 0)
				{
					text = text.Substring(0, num);
				}
				text = text.Trim().ToLowerInvariant();
				if (string.IsNullOrEmpty(text) || modelClass_0.DDSIMAGE.ContainsKey(text))
				{
					continue;
				}
				string[] array2 = new string[2]
				{
					System.IO.Path.Combine(string_1, Class16.smethod_0(1649121484), text),
					System.IO.Path.Combine(string_1, Class16.smethod_0(1649121491) + string_2, text)
				};
				string[] array3 = array2;
				foreach (string fn in array3)
				{
					byte[] fileB = GetFileB(fn);
					if (fileB != null)
					{
						modelClass_0.DDSIMAGE[text] = fileB;
						break;
					}
				}
			}
		}
		catch
		{
		}
	}

	private void method_6(ModelClass modelClass_0, ECMModel ecmmodel_0)
	{
		if (ecmmodel_0?.SkiModels == null)
		{
			return;
		}
		foreach (pwMeshContainer skiModel in ecmmodel_0.SkiModels)
		{
			if (skiModel?.Textures == null)
			{
				continue;
			}
			pwTextures[] textures = skiModel.Textures;
			foreach (pwTextures pwTextures2 in textures)
			{
				if (pwTextures2?.TexFileName == null)
				{
					continue;
				}
				string text = ACE.RSGlobal.RSGlobal.ToStringGBK(pwTextures2.TexFileName);
				int num = text.IndexOf('\0');
				if (num >= 0)
				{
					text = text.Substring(0, num);
				}
				text = text.Trim().ToLowerInvariant();
				if (string.IsNullOrEmpty(text) || modelClass_0.DDSIMAGE.ContainsKey(text))
				{
					continue;
				}
				string[] obj = new string[3]
				{
					System.IO.Path.Combine(ecmmodel_0.RelativePath, Class16.smethod_0(1649121484), text),
					System.IO.Path.Combine(ecmmodel_0.RelativePath, Class16.smethod_0(1649121491) + ecmmodel_0.Name, text),
					null
				};
				SkinModelData sMD = ecmmodel_0.SMD;
				object obj2;
				if (sMD == null)
				{
					obj2 = null;
				}
				else
				{
					obj2 = sMD.RelativePath;
					if (obj2 != null)
					{
						goto IL_0110;
					}
				}
				obj2 = string.Empty;
				goto IL_0110;
				IL_0110:
				obj[2] = System.IO.Path.Combine((string)obj2, Class16.smethod_0(1649121484), text);
				string[] array = obj;
				string[] array2 = array;
				foreach (string fn in array2)
				{
					byte[] fileB = GetFileB(fn);
					if (fileB != null)
					{
						modelClass_0.DDSIMAGE[text] = fileB;
						break;
					}
				}
			}
		}
	}

	private byte[] method_7(byte[] byte_0, string string_1, string string_2)
	{
		if (byte_0 != null && byte_0.Length != 0)
		{
			SKI sKI = new SKI(byte_0);
			if (!sKI.Loaded)
			{
				return null;
			}
			List<byte[]> list = new List<byte[]>(sKI.metadata.textCount);
			if (sKI.metadata.textCount > 0)
			{
				byte[][] textures = sKI.Textures;
				int num = 0;
				if (0 < (nint)textures.LongLength)
				{
					do
					{
						byte[] array = textures[num];
						if (array != null)
						{
							string text = ACE.RSGlobal.RSGlobal.ToStringGBK(array);
							int num2 = text.IndexOf('\0');
							string text2 = ((num2 >= 0) ? text.Substring(0, num2) : text).ToLowerInvariant();
							if (!string.IsNullOrWhiteSpace(text2))
							{
								string[] array2 = new string[2];
								string text3 = Class16.smethod_0(1648927580);
								array2[0] = string.Concat(string.Concat(string.Concat(string_1 + Class16.smethod_0(1649121900), string_2), text3), text2);
								array2[1] = string.Concat(string_1 + Class16.smethod_0(1649121904), text2);
								byte[] array3 = null;
								int num3 = 0;
								if (0 < (nint)array2.LongLength)
								{
									do
									{
										string fn = array2[num3];
										array3 = GetFileB(fn);
										if (array3 != null)
										{
											break;
										}
										num3++;
									}
									while (num3 < (nint)array2.LongLength);
								}
								list.Add(array3);
							}
						}
						num++;
					}
					while (num < (nint)textures.LongLength);
				}
			}
			using MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			try
			{
				binaryWriter.Write(0);
				binaryWriter.Write(byte_0.Length);
				binaryWriter.Write(byte_0);
				binaryWriter.Write(list.Count);
				int num4 = 0;
				if (0 < list.Count)
				{
					do
					{
						if (list[num4] != null)
						{
							binaryWriter.Write((byte)1);
							binaryWriter.Write(list[num4].Length);
							binaryWriter.Write(list[num4]);
						}
						else
						{
							binaryWriter.Write((byte)0);
						}
						num4++;
					}
					while (num4 < list.Count);
				}
				byte[] result = memoryStream.ToArray();
				GC.KeepAlive(this);
				return result;
			}
			finally
			{
				((IDisposable)binaryWriter).Dispose();
			}
		}
		return null;
	}

	private byte[] method_8(string string_1, string string_2)
	{
		string text = Class16.smethod_0(1648906306);
		byte[] fileB = GetFileB(string.Concat(string.Concat(string_1 + Class16.smethod_0(1648927580), string_2), text));
		GC.KeepAlive(this);
		return method_7(fileB, string_1, string_2);
	}

	public byte[] GetFileB(string fn)
	{
		byte[] result = null;
		if (bLocalFile)
		{
			if (File.Exists(fn))
			{
				result = File.ReadAllBytes(fn);
			}
		}
		else if (CurrentPck != null)
		{
			result = CurrentPck.GetFileB(fn);
		}
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public unsafe bool FileExists(string fn)
	{
		string text = null;
		bool result;
		if (bLocalFile)
		{
			result = File.Exists(fn);
			goto IL_003e;
		}
		int num2;
		if (CurrentPck != null)
		{
			text = fn;
			PCK currentPck = CurrentPck;
			int num = -1;
			if (currentPck.TryGetFileIndex(ref text, &num))
			{
				num2 = 1;
				goto IL_0038;
			}
		}
		num2 = 0;
		goto IL_0038;
		IL_003e:
		GC.KeepAlive(this);
		return result;
		IL_0038:
		result = (byte)num2 != 0;
		goto IL_003e;
	}

	public void Close()
	{
		if (SKIPreview != null && !SKIPreview.IsDisposed)
		{
			try
			{
				SKIPreview.Close();
				SKIPreview.Dispose();
			}
			catch
			{
			}
			SKIPreview = null;
		}
		smethod_2();
		GC.KeepAlive(this);
	}

	public void SetSource(int int_0, int int_1, int int_2)
	{
		string text = DataFiles.LN(int_0);
		string text2 = DataFiles.Elements.Lists[int_0].elementFields[int_2];
		if (DataFiles.Game == GAMES.PW)
		{
			if (text == Class16.smethod_0(1648923245))
			{
				SetModelType(MODEL_TYPE.WEAPON);
				return;
			}
			if (ACE.RSGlobal.RSGlobal.IsStringContainsAnyStringInArray(text, new string[4]
			{
				Class16.smethod_0(1648923258),
				Class16.smethod_0(1649078890),
				Class16.smethod_0(1648923096),
				Class16.smethod_0(1649078912)
			}))
			{
				if (text2 == Class16.smethod_0(1648960631))
				{
					SetModelType(MODEL_TYPE.FASHION);
				}
				else
				{
					SetModelType(MODEL_TYPE.ITEM);
				}
				return;
			}
			if (ACE.RSGlobal.RSGlobal.IsStringContainsAnyStringInArray(text, new string[4]
			{
				Class16.smethod_0(1648960167),
				Class16.smethod_0(1648963546),
				Class16.smethod_0(1648963535),
				Class16.smethod_0(1649143343)
			}))
			{
				SetModelType(MODEL_TYPE.NPC);
				return;
			}
			string text3 = Class16.smethod_0(1649121510);
			string text4 = Class16.smethod_0(1649121528);
			int num = ((text == Class16.smethod_0(1649121565) || text == text4 || text == text3) ? 1 : 0);
			if ((byte)num != 0)
			{
				SetModelType(MODEL_TYPE.UNKNOWN);
			}
			else
			{
				SetModelType(MODEL_TYPE.ITEM);
			}
		}
		else
		{
			MODEL_TYPE modelType = MODEL_TYPE.ITEM;
			if (text == Class16.smethod_0(1649121589) || (text == Class16.smethod_0(1649140044) && text2 != Class16.smethod_0(1648960582)))
			{
				modelType = MODEL_TYPE.EQUIPMENT;
			}
			SetModelType(modelType);
		}
	}

	public void SetModelType(MODEL_TYPE mt)
	{
		if (CurrentPck == null)
		{
			return;
		}
		model_type = mt;
		switch (mt)
		{
		case MODEL_TYPE.UNKNOWN:
			if (CurrentPck.SkiPaths == null)
			{
				CreateSkiDictionary();
			}
			Paths = CurrentPck.SkiPaths;
			break;
		case MODEL_TYPE.EQUIPMENT:
			if (CurrentPck.SkiAndEcmPaths == null)
			{
				CreateSkiAndEcmDictionary();
			}
			Paths = CurrentPck.SkiAndEcmPaths;
			break;
		case MODEL_TYPE.FASHION:
			if (CurrentPck.MalePaths == null)
			{
				CreateArmorDictionary();
			}
			if (gender == GENDER.FEMALE)
			{
				Paths = CurrentPck.FemalePaths;
			}
			else
			{
				Paths = CurrentPck.MalePaths;
			}
			break;
		case MODEL_TYPE.ITEM:
		case MODEL_TYPE.WEAPON:
		case MODEL_TYPE.NPC:
			if (CurrentPck.EcmPaths == null)
			{
				CreateEcmDictionary();
			}
			Paths = CurrentPck.EcmPaths;
			break;
		}
		if (DataFiles.Elements != null && ItemCount != DataFiles.Elements.ItemCount)
		{
			UpdateElementsModelsCache();
		}
	}

	public int GetModelsCount()
	{
		if (CurrentPck != null && CurrentPck.FileLoaded)
		{
			List<string> paths = Paths;
			if (paths != null)
			{
				int count = paths.Count;
				GC.KeepAlive(this);
				return count;
			}
		}
		GC.KeepAlive(this);
		return -1;
	}

	public unsafe void UpdateElementsModelsCache()
	{
		List<vITEMPOS> list = null;
		if (ACE.RSGlobal.RSGlobal.antirecurse_UpdateElementsModelsCache_MODEL_VIEWER)
		{
			GC.KeepAlive(this);
			return;
		}
		ACE.RSGlobal.RSGlobal.antirecurse_UpdateElementsModelsCache_MODEL_VIEWER = true;
		try
		{
			if (DataFiles.Elements != null && DataFiles.Elements.Lists != null)
			{
				if (ModelFields == null)
				{
					ModelFields = new Dictionary<int, List<int>>();
					int num = 1;
					if (1 < DataFiles.Elements.ListCount)
					{
						do
						{
							int modelFieldIndex = DataFiles.Elements.Lists[num].ModelFieldIndex;
							if (modelFieldIndex > 0)
							{
								List<int> list2 = new List<int>();
								list2.Add(modelFieldIndex);
								int num2 = DataFiles.Elements.Lists[num].elementTypes.Length;
								int num3 = modelFieldIndex + 1;
								if (num3 < num2)
								{
									do
									{
										if (DataFiles.Elements.GetFieldType(num, num3) == FIELDTYPE.file_model)
										{
											list2.Add(num3);
										}
										num3++;
									}
									while (num3 < num2);
								}
								if (ModelFields == null)
								{
									GC.KeepAlive(this);
									return;
								}
								ModelFields.Add(num, list2);
							}
							num++;
						}
						while (num < DataFiles.Elements.ListCount);
					}
				}
				ModelsCache = new Dictionary<string, List<vITEMPOS>>();
				vITEMPOS item = default(vITEMPOS);
				bool flag = default(bool);
				foreach (KeyValuePair<int, List<int>> modelField in ModelFields)
				{
					ValueType valueType = modelField;
					int key = ((KeyValuePair<int, List<int>>)(object)valueType).Key;
					List<int> value = ((KeyValuePair<int, List<int>>)(object)valueType).Value;
					int itemsCount = DataFiles.Elements.GetItemsCount(key);
					List<int>.Enumerator enumerator2 = value.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						int current2 = enumerator2.Current;
						for (int i = 0; i < itemsCount; i++)
						{
							string text = PCK.FixPath(DataFiles.Elements.GetFilePath(key, i, current2, &flag));
							if (!string.IsNullOrWhiteSpace(text))
							{
								list = null;
								if (ModelsCache != null && !ModelsCache.TryGetValue(text, out list))
								{
									list = new List<vITEMPOS>(1);
									ModelsCache.Add(text, list);
								}
								if (list != null)
								{
									item.Int32_1 = key;
									item.Int32_0 = i;
									list.Add(item);
								}
							}
						}
					}
				}
				if (DataFiles.Elements != null)
				{
					ItemCount = DataFiles.Elements.ItemCount;
				}
			}
			else
			{
				ModelsCache = new Dictionary<string, List<vITEMPOS>>();
				ItemCount = 0;
				GC.KeepAlive(this);
			}
		}
		finally
		{
			ACE.RSGlobal.RSGlobal.antirecurse_UpdateElementsModelsCache_MODEL_VIEWER = false;
		}
	}

	public unsafe ListViewItem CreateListViewItem(int index, int int_0)
	{
		List<vITEMPOS> list = null;
		ListViewItem listViewItem = new ListViewItem();
		if (index < 0)
		{
			GC.KeepAlive(this);
			return listViewItem;
		}
		if (ModelsCache == null)
		{
			UpdateElementsModelsCache();
		}
		if (ModelsCache == null)
		{
			ModelsCache = new Dictionary<string, List<vITEMPOS>>();
		}
		listViewItem.UseItemStyleForSubItems = false;
		string text = string.Empty;
		List<string> paths = Paths;
		if (paths != null && index < paths.Count)
		{
			text = Paths[index];
		}
		int num = 0;
		int imageIndex = 0;
		list = null;
		string text2 = null;
		if (model_type == MODEL_TYPE.FASHION)
		{
			text2 = text;
		}
		else if (!string.IsNullOrWhiteSpace(text) && text.Contains(Class16.smethod_0(1648927580)))
		{
			string text3 = text;
			text2 = text3.Substring(ACE.RSGlobal.RSGlobal.GetPathRoot(text3).Length + 1);
		}
		int num2 = index;
		listViewItem.SubItems.Add(num2.ToString());
		listViewItem.SubItems.Add(text2);
		if (!string.IsNullOrWhiteSpace(text) && ModelsCache.TryGetValue(text, out list) && DataFiles.Elements != null)
		{
			num = list.Count;
			vITEMPOS vITEMPOS2 = list[0];
			ITEMPOS iTEMPOS = new ITEMPOS(vITEMPOS2.Int32_1, vITEMPOS2.Int32_0);
			ListViewItem.ListViewSubItem[] subItems = DataFiles.Elements.GetSubItems(listViewItem, iTEMPOS, &imageIndex);
			listViewItem.Text = subItems[0].Text;
			Color foreColor = subItems[0].ForeColor;
			listViewItem.ForeColor = foreColor;
			listViewItem.Tag = iTEMPOS;
			ListViewItem.ListViewSubItem item = subItems[1];
			listViewItem.SubItems.Add(item);
			int num3 = num;
			listViewItem.SubItems.Add(num3.ToString());
			Color cyan = Color.Cyan;
			listViewItem.SubItems[4].ForeColor = cyan;
			if (num > 1)
			{
				int num4 = ((num < 20) ? num : 20);
				List<string> list2 = new List<string>(num4 - 1);
				string text4 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649121600));
				list2.Add(text4);
				int num5 = 0;
				int num6 = 1;
				if (1 < num4)
				{
					do
					{
						vITEMPOS vITEMPOS3 = list[num6];
						ITEMPOS pos = new ITEMPOS(vITEMPOS3.Int32_1, vITEMPOS3.Int32_0);
						string parsedItemName = DataFiles.Elements.GetParsedItemName(pos);
						if (!string.IsNullOrWhiteSpace(parsedItemName))
						{
							num5++;
							int num7 = num5;
							string text5 = Class16.smethod_0(1648952989);
							list2.Add(string.Concat(num7 + text5, parsedItemName));
						}
						num6++;
					}
					while (num6 < num4);
				}
				if (num > 20)
				{
					list2.Add(Class16.smethod_0(1648924410));
				}
				listViewItem.ToolTipText = string.Join(Class16.smethod_0(1648924428), list2);
			}
		}
		else
		{
			string text6 = TextStorage.TEXTS.GetText(Class16.smethod_0(1649121631));
			listViewItem.Text = text6;
			Color green = Color.Green;
			listViewItem.ForeColor = green;
			listViewItem.Font = smethod_1(listViewItem.Font);
			string[] items = new string[3]
			{
				string.Empty,
				string.Empty,
				Class16.smethod_0(1648924112)
			};
			listViewItem.SubItems.AddRange(items);
		}
		if (!string.IsNullOrWhiteSpace(text2))
		{
			switch (model_type)
			{
			case MODEL_TYPE.FASHION:
			{
				Color lightGreen2 = Color.LightGreen;
				listViewItem.SubItems[2].ForeColor = lightGreen2;
				break;
			}
			case MODEL_TYPE.WEAPON:
				if (text2.StartsWith(Class16.smethod_0(1649121658)))
				{
					Color lightGreen3 = Color.LightGreen;
					listViewItem.SubItems[2].ForeColor = lightGreen3;
				}
				break;
			case MODEL_TYPE.NPC:
				if (text2.StartsWith(Class16.smethod_0(1649121654)))
				{
					Color lightGreen = Color.LightGreen;
					listViewItem.SubItems[2].ForeColor = lightGreen;
				}
				break;
			}
		}
		if (num > 0)
		{
			listViewItem.ImageIndex = imageIndex;
		}
		else
		{
			listViewItem.ImageIndex = 2;
		}
		GC.KeepAlive(this);
		return listViewItem;
	}

	public string GetModelName(int index)
	{
		List<string> paths = Paths;
		if (paths == null)
		{
			return Class16.smethod_0(1649121673);
		}
		if (index >= 0 && index < paths.Count)
		{
			string result = paths[index];
			GC.KeepAlive(this);
			return result;
		}
		return string.Empty;
	}

	public int GetModelIndex(string ModelName, [MarshalAs(UnmanagedType.U1)] bool bContains, int start_index)
	{
		if (CurrentPck == null)
		{
			return -1;
		}
		if (Paths == null)
		{
			SetModelType(model_type);
		}
		if (!string.IsNullOrWhiteSpace(ModelName))
		{
			List<string> paths = Paths;
			if (paths != null)
			{
				if (bContains)
				{
					int count = paths.Count;
					int num = start_index;
					if (start_index < count)
					{
						do
						{
							if (!ACE.RSGlobal.RSGlobal.ContainsIgnoreCase(Paths[num], ModelName))
							{
								num++;
								continue;
							}
							GC.KeepAlive(this);
							return num;
						}
						while (num < count);
					}
					return -1;
				}
				int result = paths.IndexOf(ModelName);
				GC.KeepAlive(this);
				return result;
			}
		}
		return -1;
	}

	public void FilterPaths()
	{
		UpdateElementsModelsCache();
		List<string> list = new List<string>();
		List<string>.Enumerator enumerator = Paths.GetEnumerator();
		if (enumerator.MoveNext())
		{
			do
			{
				string current = enumerator.Current;
				if (!ModelsCache.ContainsKey(current))
				{
					list.Add(current);
				}
			}
			while (enumerator.MoveNext());
		}
		Paths = list;
	}

	private int method_9(int int_0, string string_1, ref ITEMPOS itempos_0)
	{
		int num = 0;
		int modelFieldIndex = DataFiles.Elements.Lists[int_0].ModelFieldIndex;
		int itemsCount = DataFiles.Elements.GetItemsCount(int_0);
		int num2 = 0;
		if (0 < itemsCount)
		{
			do
			{
				if (DataFiles.Elements.GetValue(int_0, num2, modelFieldIndex).ToLowerInvariant() == string_1)
				{
					num++;
					if (itempos_0 == null)
					{
						itempos_0 = new ITEMPOS(int_0, num2);
					}
				}
				num2++;
			}
			while (num2 < itemsCount);
		}
		GC.KeepAlive(this);
		return num;
	}

	public void Reset()
	{
		ModelFields = null;
		ModelsCache = null;
		CurrentPck = null;
		Paths = null;
		pck_name = null;
		if (PCKs != null && CommonStorage.AParams != null && PCKs.IsPckLoaded(CommonStorage.AParams.ModelsPckBaseName))
		{
			SetPackage(CommonStorage.AParams.ModelsPckBaseName);
		}
		GC.KeepAlive(this);
	}

	private byte[] method_10(string string_1)
	{
		return GetFileB(string_1);
	}

	private byte[] method_11(string string_1)
	{
		return GetFileB(string_1);
	}
}
