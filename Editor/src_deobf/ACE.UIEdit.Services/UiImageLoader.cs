#nullable enable annotations
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ACE.Classes.ACE;

namespace ACE.UIEdit.Services;

internal sealed class UiImageLoader : IDisposable
{
	private readonly PfimImageReader pfimImageReader_0 = new PfimImageReader();

	private readonly Dictionary<string, Image> dictionary_0 = new Dictionary<string, Image>(StringComparer.OrdinalIgnoreCase);

	private UiPckProvider? uiPckProvider_0;

	public void SetPckProvider(UiPckProvider? provider)
	{
		uiPckProvider_0 = provider;
	}

	public Image? TryLoad(string preferredPath)
	{
		if (string.IsNullOrWhiteSpace(preferredPath))
		{
			return null;
		}
		if (dictionary_0.TryGetValue(preferredPath, out Image value))
		{
			return value;
		}
		try
		{
			Image image = method_0(preferredPath);
			if (image != null)
			{
				dictionary_0[preferredPath] = image;
				return image;
			}
			string text = smethod_0(preferredPath);
			if (!File.Exists(text))
			{
				return null;
			}
			string text2 = System.IO.Path.GetExtension(text).ToLowerInvariant();
			Image image2 = ((text2 == Class16.smethod_0(1648904847)) ? method_1(text) : ((text2 == Class16.smethod_0(1648904836)) ? method_2(text) : smethod_1(text)));
			image = image2;
			if (image == null)
			{
				return null;
			}
			dictionary_0[preferredPath] = image;
			return image;
		}
		catch
		{
			return null;
		}
	}

	private Image? method_0(string string_0)
	{
		if (uiPckProvider_0 == null)
		{
			return null;
		}
		byte[] array = uiPckProvider_0.ReadSurfacesFile(string_0);
		if (array == null)
		{
			array = uiPckProvider_0.ReadInterfacesFile(string_0);
		}
		if (array != null && array.Length != 0)
		{
			try
			{
				string text = System.IO.Path.GetExtension(string_0).ToLowerInvariant();
				MemoryStream memoryStream = new MemoryStream(array);
				try
				{
					return (text == Class16.smethod_0(1648904847)) ? pfimImageReader_0.ReadDds(memoryStream) : ((text == Class16.smethod_0(1648904836)) ? pfimImageReader_0.ReadTga(memoryStream) : smethod_2(memoryStream));
				}
				finally
				{
					((IDisposable)memoryStream).Dispose();
				}
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	private static string smethod_0(string string_0)
	{
		return string_0.Replace('/', '\\');
	}

	private Image? method_1(string string_0)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		try
		{
			return pfimImageReader_0.ReadDds(fileStream);
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	private Image? method_2(string string_0)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		try
		{
			return pfimImageReader_0.ReadTga(fileStream);
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	private static Image? smethod_1(string string_0)
	{
		FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
		try
		{
			return smethod_2(fileStream);
		}
		finally
		{
			((IDisposable)fileStream).Dispose();
		}
	}

	private static Image? smethod_2(Stream stream_0)
	{
		using Image original = Image.FromStream(stream_0, useEmbeddedColorManagement: false, validateImageData: false);
		return new Bitmap(original);
	}

	public void ClearCache()
	{
		foreach (KeyValuePair<string, Image> item in dictionary_0)
		{
			item.Value.Dispose();
		}
		dictionary_0.Clear();
	}

	public void Dispose()
	{
		foreach (KeyValuePair<string, Image> item in dictionary_0)
		{
			item.Value.Dispose();
		}
		dictionary_0.Clear();
	}
}
