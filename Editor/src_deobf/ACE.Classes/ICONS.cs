using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ACE.Classes.ACE;
using ACE.Pck;
using ACE.RSGlobal;
using Sentry;

namespace ACE.Classes;

public class ICONS : IDisposable
{
	private sealed class Class73
	{
		public ICONS icons_0;

		public string string_0;

		public bool bool_0;

		public int int_0;

		internal Bitmap method_0()
		{
			return icons_0.method_4(string_0, bool_0, int_0);
		}
	}

	private sealed class Class74<T>
	{
		public Func<T> func_0;

		public T gparam_0;

		internal void method_0(object object_0)
		{
			gparam_0 = func_0();
		}
	}

	private sealed class Class75
	{
		public ICONS icons_0;

		public string string_0;

		public bool bool_0;

		internal Bitmap method_0()
		{
			return icons_0.method_3(string_0, bool_0);
		}
	}

	public static PCK_LIST PCKs;

	public static string CachePath;

	private Debouncer debouncer_0;

	public bool IsGShop;

	public string FileMD5;

	public string ImagePath;

	public string SortedImagePath;

	public string ImagePathIcons;

	public Bitmap MainImage;

	public Bitmap SortedImage;

	public IDictionary<string, Bitmap> Icons = new Dictionary<string, Bitmap>();

	public ImageList imageList;

	public int FirstIconIndex;

	public CommonStorage CStorage;

	public static Bitmap UnknownIcon;

	public static Bitmap NopeIcon;

	public static Bitmap NopeIcon18;

	public static Bitmap FreeItemIcon;

	public static Bitmap FreeItemIcon18;

	public static Bitmap MonsterIcon;

	public static Bitmap NpcIcon;

	public static Bitmap ConfigIcon;

	public int icon_width;

	public int icon_height;

	public int lines_count;

	public int icons_per_line;

	public int icons_count;

	public static int OldIconsWindowIconsLimit;

	private List<string> list_0 = new List<string>();

	private Dictionary<string, int> dictionary_0 = new Dictionary<string, int>();

	private readonly HashSet<string> hashSet_0 = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private IImageReader iimageReader_0 = new PfimImageReader();

	private IconsService iconsService_0 = new IconsService();

	private readonly SynchronizationContext synchronizationContext_0;

	public volatile bool _disposed;

	public bool PreparedForDispose;

	public int IconNamesCount
	{
		get
		{
			int count = list_0.Count;
			GC.KeepAlive(this);
			return count;
		}
	}

	public bool IconsLoaded
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get
		{
			IDictionary<string, Bitmap> icons = Icons;
			int num = ((icons != null && icons.Count > 20) ? 1 : 0);
			GC.KeepAlive(this);
			return (byte)num != 0;
		}
	}

	public ICONS(CommonStorage CStorage, int thumb_size, Action notifyImageListChanged)
	{
		this.CStorage = CStorage;
		synchronizationContext_0 = SynchronizationContext.Current;
		if (notifyImageListChanged != null)
		{
			TimeSpan delay = TimeSpan.FromMilliseconds(500.0);
			debouncer_0 = new Debouncer(notifyImageListChanged, delay);
		}
		string text = Class16.smethod_0(1648905544);
		UnknownIcon = global::ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text);
		string text2 = Class16.smethod_0(1648905580);
		NopeIcon = global::ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text2);
		string text3 = Class16.smethod_0(1648905605);
		FreeItemIcon = global::ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text3);
		string text4 = Class16.smethod_0(1648905630);
		MonsterIcon = global::ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text4);
		string text5 = Class16.smethod_0(1648905669);
		NpcIcon = global::ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text5);
		string text6 = Class16.smethod_0(1648905696);
		ConfigIcon = global::ACE.RSGlobal.RSGlobal.LoadImageW(Application.StartupPath + text6);
		NopeIcon.Tag = Class16.smethod_0(1648904718);
		NopeIcon18 = ResizeImage(NopeIcon, 18, 18);
		FreeItemIcon18 = ResizeImage(FreeItemIcon, 18, 18);
		Icons.Clear();
		TryAddInitialIcons(Icons);
		imageList = new ImageList();
		InitImageList(thumb_size);
	}

	public ICONS(CommonStorage CStorage)
	{
		this.CStorage = CStorage;
		synchronizationContext_0 = SynchronizationContext.Current;
		Icons.Clear();
		GC.KeepAlive(this);
	}

	static ICONS()
	{
		string text = Class16.smethod_0(1648904721);
		CachePath = Application.StartupPath + text;
		OldIconsWindowIconsLimit = 30000;
	}

	private T method_0<T>(Func<T> func_0)
	{
		Class74<T> @class = new Class74<T>();
		@class.func_0 = func_0;
		if (synchronizationContext_0 != null && synchronizationContext_0 != SynchronizationContext.Current)
		{
			@class.gparam_0 = default(T);
			synchronizationContext_0.Send(@class.method_0, null);
			return @class.gparam_0;
		}
		return @class.func_0();
	}

	public static void TryAddInitialIcons(IDictionary<string, Bitmap> icons)
	{
		if (!icons.ContainsKey(string.Empty))
		{
			icons[string.Empty] = NopeIcon;
		}
		if (!icons.ContainsKey(Class16.smethod_0(1648904743)))
		{
			icons[Class16.smethod_0(1648904743)] = UnknownIcon;
		}
	}

	private void method_1()
	{
		_disposed = true;
		((IDisposable)MainImage)?.Dispose();
		((IDisposable)SortedImage)?.Dispose();
		MainImage = null;
		SortedImage = null;
		ImageList imageList = this.imageList;
		if (imageList != null && imageList.Images.Count > 0)
		{
			foreach (object image in imageList.Images)
			{
				if (image is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			imageList.Images.Clear();
		}
		((IDisposable)imageList)?.Dispose();
		foreach (Bitmap value in Icons.Values)
		{
			((IDisposable)value)?.Dispose();
		}
		Icons.Clear();
		Icons = null;
		if (iimageReader_0 is IDisposable disposable2)
		{
			disposable2.Dispose();
		}
		if (iconsService_0 is IDisposable disposable3)
		{
			disposable3.Dispose();
		}
		((IDisposable)debouncer_0)?.Dispose();
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryAddIcon(string iconName, Bitmap image)
	{
		if (!Icons.ContainsKey(iconName))
		{
			Icons[iconName] = image;
			list_0.Add(iconName);
			int value = list_0.Count - 1;
			dictionary_0[iconName] = value;
			icons_count = list_0.Count;
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	public void Load(Stream iconsfile_fs, Stream iconlisfile_fs, int thumbsSize, AdaptedImageStrategy adaptedImageStrategy)
	{
		IconsService.IconReadResult iconReadResult = iconsService_0.ReadIconsAndRebuild(iconsfile_fs, iconlisfile_fs, CommonStorage.AParams.LineIconsCount, adaptedImageStrategy, OldIconsWindowIconsLimit);
		Icons = iconReadResult.Icons;
		CommonStorage.AParams.LineIconsCount = iconReadResult.AdaptedIconsPerLine;
		icons_per_line = iconReadResult.AdaptedIconsPerLine;
		icon_width = iconReadResult.IconsInfo.IconWidth;
		icon_height = iconReadResult.IconsInfo.IconHeight;
		icons_count = iconReadResult.IconsInfo.IconsCount;
		lines_count = iconReadResult.IconsInfo.LinesCount;
		list_0 = iconReadResult.IconsInfo.IconsNames;
		dictionary_0 = iconReadResult.IconsInfo.IconsNamesDict;
		MainImage = iconReadResult.ScreenAdapted;
		SortedImage = iconReadResult.ScreenAdapted;
		TryAddInitialIcons(Icons);
		UnknownIcon = Icons[list_0[0]];
		InitImageList(thumbsSize);
	}

	public void InitImageList(int size)
	{
		imageList.Images.Clear();
		Size imageSize = new Size(size, size);
		imageList.ImageSize = imageSize;
		Size imageSize2 = imageList.ImageSize;
		Size imageSize3 = imageList.ImageSize;
		string empty = string.Empty;
		imageList.Images.Add(empty, ResizeImage(NopeIcon, imageSize3.Width, imageSize2.Height));
		Size imageSize4 = imageList.ImageSize;
		Size imageSize5 = imageList.ImageSize;
		string key = Class16.smethod_0(1648904743);
		imageList.Images.Add(key, ResizeImage(UnknownIcon, imageSize5.Width, imageSize4.Height));
		Size imageSize6 = imageList.ImageSize;
		Size imageSize7 = imageList.ImageSize;
		string key2 = Class16.smethod_0(1648904753);
		imageList.Images.Add(key2, ResizeImage(FreeItemIcon, imageSize7.Width, imageSize6.Height));
		Size imageSize8 = imageList.ImageSize;
		Size imageSize9 = imageList.ImageSize;
		string key3 = Class16.smethod_0(1648904769);
		imageList.Images.Add(key3, ResizeImage(MonsterIcon, imageSize9.Width, imageSize8.Height));
		Size imageSize10 = imageList.ImageSize;
		Size imageSize11 = imageList.ImageSize;
		string key4 = Class16.smethod_0(1648904785);
		imageList.Images.Add(key4, ResizeImage(NpcIcon, imageSize11.Width, imageSize10.Height));
		Size imageSize12 = imageList.ImageSize;
		Size imageSize13 = imageList.ImageSize;
		string key5 = Class16.smethod_0(1648904805);
		imageList.Images.Add(key5, ResizeImage(ConfigIcon, imageSize13.Width, imageSize12.Height));
		FirstIconIndex = imageList.Images.Count;
		GC.KeepAlive(this);
	}

	public string GetIconName(int line_icons_count, int int_0, int int_1)
	{
		int num = int_1 / icon_height * line_icons_count + int_0 / icon_width;
		if (num > icons_count - 1)
		{
			string result = list_0[0];
			GC.KeepAlive(this);
			return result;
		}
		string result2 = list_0[num];
		GC.KeepAlive(this);
		return result2;
	}

	public string GetIconName(int icon_index_in_file)
	{
		string result = list_0[icon_index_in_file];
		GC.KeepAlive(this);
		return result;
	}

	public void SetThumbsSize(int size)
	{
		InitImageList(size);
	}

	public int GetIconIndex(string iconName)
	{
		Bitmap bitmap = null;
		if (IconsLoaded && iconName != null)
		{
			if (string.IsNullOrWhiteSpace(iconName))
			{
				GC.KeepAlive(this);
				return 1;
			}
			if (iconName == Class16.smethod_0(1648904753))
			{
				GC.KeepAlive(this);
				return 2;
			}
			int num = imageList.Images.IndexOfKey(iconName);
			if (num == -1)
			{
				bitmap = null;
				if (!Icons.TryGetValue(iconName, out bitmap))
				{
					return 1;
				}
				AddIconToImageListAndNotify(iconName, bitmap);
				num = Icons.Count - 1;
			}
			GC.KeepAlive(this);
			return num;
		}
		return 0;
	}

	public int GetPckIconIndex(string IconPath)
	{
		if (string.IsNullOrWhiteSpace(IconPath))
		{
			GC.KeepAlive(this);
			return 0;
		}
		int num = imageList.Images.IndexOfKey(IconPath);
		if (num == -1)
		{
			string path = IconPath;
			string pathRoot = global::ACE.RSGlobal.RSGlobal.GetPathRoot(IconPath);
			if (!PCKs.IsPckExist(pathRoot))
			{
				path = Class16.smethod_0(1648904820) + IconPath;
			}
			byte[] fileB = PCKs.GetFileB(path);
			if (fileB != null)
			{
				Bitmap bitmap = ReadImageUniversal(IconPath, fileB);
				if (bitmap != null)
				{
					CacheIcon(IconPath, bitmap);
					num = imageList.Images.IndexOfKey(IconPath);
					if (num < 0)
					{
						num = 1;
					}
				}
				else
				{
					num = 1;
				}
			}
			else
			{
				num = 0;
			}
		}
		GC.KeepAlive(this);
		return num;
	}

	public Bitmap ReadImageUniversal(string path, byte[] icon_bytes)
	{
		if (icon_bytes != null && icon_bytes.Length >= 4)
		{
			string text = (System.IO.Path.GetExtension(path) ?? string.Empty).ToLowerInvariant();
			if (text == Class16.smethod_0(1648904836))
			{
				try
				{
					MemoryStream memoryStream = new MemoryStream(icon_bytes, writable: false);
					try
					{
						Bitmap result = iimageReader_0.ReadTga(memoryStream);
						GC.KeepAlive(this);
						return result;
					}
					finally
					{
						((IDisposable)memoryStream).Dispose();
					}
				}
				catch (Exception exception_)
				{
					method_2(path, exception_);
				}
				// TODO(recovered): cross-format fallback (licensed ReadImageUniversal). PW client icons
				// are frequently byte-DDS but named .tga (or vice-versa); without the fallback the primary
				// decoder throws and the icon renders blank/placeholder. Retry as the other format.
				try
				{
					MemoryStream memoryStreamFb = new MemoryStream(icon_bytes, writable: false);
					try { Bitmap resultFb = iimageReader_0.ReadDds(memoryStreamFb); GC.KeepAlive(this); return resultFb; }
					finally { ((IDisposable)memoryStreamFb).Dispose(); }
				}
				catch (Exception)
				{
				}
				return null;
			}
			if (text == Class16.smethod_0(1648904847))
			{
				try
				{
					MemoryStream memoryStream2 = new MemoryStream(icon_bytes, writable: false);
					try
					{
						Bitmap result2 = iimageReader_0.ReadDds(memoryStream2);
						GC.KeepAlive(this);
						return result2;
					}
					finally
					{
						((IDisposable)memoryStream2).Dispose();
					}
				}
				catch (Exception exception_2)
				{
					method_2(path, exception_2);
				}
				// TODO(recovered): cross-format fallback (licensed) - retry a failed .dds as TGA.
				try
				{
					MemoryStream memoryStreamFb2 = new MemoryStream(icon_bytes, writable: false);
					try { Bitmap resultFb2 = iimageReader_0.ReadTga(memoryStreamFb2); GC.KeepAlive(this); return resultFb2; }
					finally { ((IDisposable)memoryStreamFb2).Dispose(); }
				}
				catch (Exception)
				{
				}
				return null;
			}
			try
			{
				MemoryStream memoryStream3 = new MemoryStream(icon_bytes, writable: false);
				try
				{
					using Image original = Image.FromStream(memoryStream3, useEmbeddedColorManagement: false, validateImageData: true);
					GC.KeepAlive(this);
					return new Bitmap(original);
				}
				finally
				{
					((IDisposable)memoryStream3).Dispose();
				}
			}
			catch (Exception exception_3)
			{
				method_2(path, exception_3);
				return null;
			}
		}
		return null;
	}

	private void method_2(string string_0, Exception exception_0)
	{
		string text = (string.IsNullOrWhiteSpace(string_0) ? Class16.smethod_0(1648904850) : string_0);
		if (hashSet_0.Add(text))
		{
			SentryHelper.CaptureMessage(Class16.smethod_0(1648904864) + text + Class16.smethod_0(1648927638) + exception_0.GetType().Name + Class16.smethod_0(1648908709) + exception_0.Message, (SentryLevel)2, Class16.smethod_0(1648904893));
		}
	}

	public int GetIconIndexInFile(string IconName)
	{
		int value = 0;
		if (dictionary_0.TryGetValue(IconName, out value))
		{
			GC.KeepAlive(this);
			return value;
		}
		return -1;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool TryGetIcon(string IconName, [MarshalAs(UnmanagedType.U1)] bool IsTga, int size, ref Bitmap result)
	{
		Bitmap bitmap = GetIcon(IconName, IsTga);
		if (bitmap != NopeIcon && bitmap != UnknownIcon)
		{
			if (bitmap.Width != size)
			{
				try
				{
					bitmap = ResizeImage(bitmap, size, size);
				}
				catch (Exception exception_)
				{
					method_2(IconName, exception_);
				}
			}
			result = bitmap;
			GC.KeepAlive(this);
			return true;
		}
		return false;
	}

	public Bitmap GetIcon(string IconName, [MarshalAs(UnmanagedType.U1)] bool IsTga)
	{
		Class75 @class = new Class75();
		@class.icons_0 = this;
		@class.string_0 = IconName;
		@class.bool_0 = IsTga;
		return method_0(@class.method_0);
	}

	private Bitmap method_3(string string_0, bool bool_0)
	{
		Bitmap bitmap = null;
		if (!IsGShop && !IconsLoaded)
		{
			return NopeIcon;
		}
		if (string_0 == null)
		{
			return NopeIcon;
		}
		if (!string.IsNullOrWhiteSpace(string_0))
		{
			if (string_0 == Class16.smethod_0(1648904769))
			{
				GC.KeepAlive(this);
				return MonsterIcon;
			}
			if (string_0 == Class16.smethod_0(1648904785))
			{
				GC.KeepAlive(this);
				return NpcIcon;
			}
			if (string_0 == Class16.smethod_0(1648904805))
			{
				GC.KeepAlive(this);
				return ConfigIcon;
			}
			if (!(string_0 == Class16.smethod_0(1648924112)) && !(string_0 == Class16.smethod_0(1648904743)))
			{
				bitmap = null;
				if (!Icons.TryGetValue(string_0, out bitmap))
				{
					if (!bool_0)
					{
						return UnknownIcon;
					}
					if (PCKs == null)
					{
						return NopeIcon;
					}
					string path = string_0;
					string pathRoot = global::ACE.RSGlobal.RSGlobal.GetPathRoot(string_0);
					if (!PCKs.IsPckExist(pathRoot))
					{
						path = Class16.smethod_0(1648904820) + string_0;
					}
					byte[] fileB = PCKs.GetFileB(path);
					if (fileB != null)
					{
						bitmap = ReadImageUniversal(string_0, fileB);
					}
					if (bitmap != null)
					{
						CacheIcon(string_0, bitmap);
					}
					else
					{
						bitmap = NopeIcon;
					}
				}
				return bitmap;
			}
		}
		GC.KeepAlive(this);
		return UnknownIcon;
	}

	public Bitmap GetIcon(string IconName, [MarshalAs(UnmanagedType.U1)] bool IsTga, int size)
	{
		Class73 @class = new Class73();
		@class.icons_0 = this;
		@class.string_0 = IconName;
		@class.bool_0 = IsTga;
		@class.int_0 = size;
		return method_0(@class.method_0);
	}

	private Bitmap method_4(string string_0, bool bool_0, int int_0)
	{
		Bitmap bitmap = method_3(string_0, bool_0);
		if (int_0 > 0 && bitmap != null && bitmap.Width > 0 && bitmap.Height > 0 && bitmap.Width != int_0)
		{
			try
			{
				bitmap = ResizeImage(bitmap, int_0, int_0);
			}
			catch (Exception exception_)
			{
				method_2(string_0, exception_);
				bitmap = NopeIcon;
			}
		}
		if (string_0 == null)
		{
			bitmap.Tag = Class16.smethod_0(1648904718);
		}
		GC.KeepAlive(this);
		return bitmap;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Exists(string IconName, [MarshalAs(UnmanagedType.U1)] bool IsTga)
	{
		if (string.IsNullOrWhiteSpace(IconName))
		{
			GC.KeepAlive(this);
			return false;
		}
		if (IsTga)
		{
			string path = IconName;
			string pathRoot = global::ACE.RSGlobal.RSGlobal.GetPathRoot(IconName);
			if (!PCKs.IsPckExist(pathRoot))
			{
				path = Class16.smethod_0(1648904820) + IconName;
			}
			bool result = PCKs.IsFileExist(path);
			GC.KeepAlive(this);
			return result;
		}
		bool result2 = dictionary_0.ContainsKey(IconName);
		GC.KeepAlive(this);
		return result2;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Exists(string IconName)
	{
		return Exists(IconName, IsTga: false);
	}

	public void CacheIcon(string IconName, Bitmap icon)
	{
		if (!Icons.ContainsKey(IconName) && IconName.EndsWith(Class16.smethod_0(1648904836)))
		{
			Icons.Add(IconName, icon);
		}
		Size imageSize = imageList.ImageSize;
		if (icon.Width != imageSize.Width)
		{
			Size imageSize2 = imageList.ImageSize;
			icon = ResizeImage(icon, imageList.ImageSize.Width, imageSize2.Height);
		}
		AddIconToImageListAndNotify(IconName, icon);
	}

	public void AddIconToImageListAndNotify(string iconName, Bitmap icon)
	{
		if (!_disposed && !PreparedForDispose && !string.IsNullOrEmpty(iconName))
		{
			if (!imageList.Images.ContainsKey(iconName))
			{
				imageList.Images.Add(iconName, icon);
				debouncer_0?.Schedule();
			}
			GC.KeepAlive(this);
		}
	}

	public Image GetIconByIndex(int index_in_file)
	{
		Bitmap bitmap = null;
		string key = list_0[index_in_file];
		bitmap = null;
		if (Icons.TryGetValue(key, out bitmap))
		{
			GC.KeepAlive(this);
			return bitmap;
		}
		return UnknownIcon;
	}

	public Point GetIconCoords(string IconName, int line_icons_count)
	{
		int value = 0;
		dictionary_0.TryGetValue(IconName, out value);
		if (value <= 0)
		{
			Point result = new Point(0, 0);
			GC.KeepAlive(this);
			return result;
		}
		Point result2 = new Point(icon_width * (value % line_icons_count), icon_height * (value / line_icons_count));
		GC.KeepAlive(this);
		return result2;
	}

	public Bitmap CreateScreenAdaptedImage(int requiredIconsPerLine)
	{
		int iconHeight = icon_height;
		int iconWidth = icon_width;
		List<string> iconNames = list_0;
		Bitmap result = IconsService.CreateScreenAdaptedImageUnsafe(Icons, iconNames, Icons.Count, iconWidth, iconHeight, requiredIconsPerLine);
		GC.KeepAlive(this);
		return result;
	}

	public static Bitmap ResizeImage(Bitmap image, int nWidth, int nHeight)
	{
		if (image == null)
		{
			return null;
		}
		Bitmap bitmap = (Bitmap)image.Clone();
		if (bitmap.Width == nWidth && bitmap.Height == nHeight)
		{
			return bitmap;
		}
		try
		{
			return ((IImageResizer)new NativeImageResizer(bitmap)).Resize(nWidth, nHeight);
		}
		finally
		{
			bitmap.Dispose();
		}
	}

	protected virtual void Dispose([MarshalAs(UnmanagedType.U1)] bool A_0)
	{
		if (A_0)
		{
			method_1();
		}
	}

	public virtual void Dispose()
	{
		Dispose(A_0: true);
		GC.SuppressFinalize(this);
		GC.KeepAlive(this);
	}
}
