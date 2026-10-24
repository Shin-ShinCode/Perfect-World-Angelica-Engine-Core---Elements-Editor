#nullable enable annotations
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ACE.Pck;

namespace ACE.UIEdit.Services;

internal sealed class UiPckProvider : IDisposable
{
	[Serializable]
	private sealed class Class369
	{
		public static readonly Class369 class369_0 = new Class369();

		public static Func<string, bool> func_0;

		public static Func<string, string> func_1;

		public static Func<string, bool> func_2;

		public static Func<string, bool> func_3;

		internal bool method_0(string string_0)
		{
			return string_0.EndsWith(Class16.smethod_0(1649189989), StringComparison.OrdinalIgnoreCase);
		}

		internal string method_1(string string_0)
		{
			return string_0;
		}

		internal bool method_2(string string_0)
		{
			return string_0.StartsWith(Class16.smethod_0(1649275403), StringComparison.Ordinal);
		}

		internal bool method_3(string string_0)
		{
			return string_0.StartsWith(Class16.smethod_0(1649275420), StringComparison.Ordinal);
		}
	}

	private PCKArchiveManager? pckarchiveManager_0;

	private PCKArchiveManager? pckarchiveManager_1;

	private string string_0 = string.Empty;

	private string string_1 = string.Empty;

	private readonly Dictionary<string, byte[]> dictionary_0 = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);

	public bool InterfacesPckLoaded => pckarchiveManager_0?.IsLoaded ?? false;

	public bool SurfacesPckLoaded => pckarchiveManager_1?.IsLoaded ?? false;

	public string InterfacesPckPath => string_0;

	public string SurfacesPckPath => string_1;

	public bool OpenInterfacesPck(string path)
	{
		if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
		{
			if (string.Equals(string_0, path, StringComparison.OrdinalIgnoreCase) && InterfacesPckLoaded)
			{
				return true;
			}
			CloseInterfacesPck();
			pckarchiveManager_0 = new PCKArchiveManager();
			bool result;
			if (result = pckarchiveManager_0.Open(path))
			{
				string_0 = path;
			}
			return result;
		}
		return false;
	}

	public bool OpenSurfacesPck(string path)
	{
		if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
		{
			if (string.Equals(string_1, path, StringComparison.OrdinalIgnoreCase) && SurfacesPckLoaded)
			{
				return true;
			}
			CloseSurfacesPck();
			pckarchiveManager_1 = new PCKArchiveManager();
			bool result;
			if (result = pckarchiveManager_1.Open(path))
			{
				string_1 = path;
			}
			return result;
		}
		return false;
	}

	public string[] GetInterfacesXmlPaths()
	{
		if (pckarchiveManager_0 != null && pckarchiveManager_0.IsLoaded)
		{
			return pckarchiveManager_0.GetFilePaths().Where(Class369.class369_0.method_0).OrderBy(Class369.class369_0.method_1, StringComparer.OrdinalIgnoreCase)
				.ToArray();
		}
		return Array.Empty<string>();
	}

	public string[] GetInterfacesAllPaths()
	{
		if (pckarchiveManager_0 != null && pckarchiveManager_0.IsLoaded)
		{
			return pckarchiveManager_0.GetFilePaths();
		}
		return Array.Empty<string>();
	}

	public byte[]? ReadInterfacesFile(string relativePath)
	{
		if (pckarchiveManager_0 != null && pckarchiveManager_0.IsLoaded && !string.IsNullOrWhiteSpace(relativePath))
		{
			string key = Class16.smethod_0(1649275403) + relativePath.Replace('/', '\\').TrimStart('\\');
			if (dictionary_0.TryGetValue(key, out byte[] value))
			{
				return value;
			}
			try
			{
				byte[] file = pckarchiveManager_0.GetFile(relativePath);
				if (file != null)
				{
					dictionary_0[key] = file;
				}
				return file;
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	public byte[]? ReadSurfacesFile(string relativePath)
	{
		if (pckarchiveManager_1 != null && pckarchiveManager_1.IsLoaded && !string.IsNullOrWhiteSpace(relativePath))
		{
			string text = relativePath.Replace('/', '\\').TrimStart('\\');
			string key = Class16.smethod_0(1649275420) + text;
			if (dictionary_0.TryGetValue(key, out byte[] value))
			{
				return value;
			}
			try
			{
				byte[] file = pckarchiveManager_1.GetFile(text);
				if (file == null)
				{
					file = pckarchiveManager_1.GetFile(Class16.smethod_0(1648904820) + text);
				}
				if (file != null)
				{
					dictionary_0[key] = file;
				}
				return file;
			}
			catch
			{
				return null;
			}
		}
		return null;
	}

	public string? ReadInterfacesText(string relativePath)
	{
		byte[] array = ReadInterfacesFile(relativePath);
		if (array != null && array.Length != 0)
		{
			return smethod_0(array);
		}
		return null;
	}

	public bool WriteInterfacesFile(string relativePath, string textContent)
	{
		byte[] bytes = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true).GetBytes(textContent ?? string.Empty);
		return WriteInterfacesFile(relativePath, bytes);
	}

	public bool WriteInterfacesFile(string relativePath, byte[] data)
	{
		if (pckarchiveManager_0 != null && pckarchiveManager_0.IsLoaded)
		{
			try
			{
				string text = relativePath.Replace('/', '\\').TrimStart('\\');
				if (!pckarchiveManager_0.AddFile(text, data))
				{
					return false;
				}
				pckarchiveManager_0.Save(truncateFile: false);
				string key = Class16.smethod_0(1649275403) + text;
				dictionary_0.Remove(key);
				dictionary_0[key] = data;
				return true;
			}
			catch
			{
				return false;
			}
		}
		return false;
	}

	public bool InterfacesFileExists(string relativePath)
	{
		if (pckarchiveManager_0 != null && pckarchiveManager_0.IsLoaded)
		{
			return pckarchiveManager_0.FileExists(relativePath.Replace('/', '\\').TrimStart('\\'));
		}
		return false;
	}

	public bool SurfacesFileExists(string relativePath)
	{
		if (pckarchiveManager_1 != null && pckarchiveManager_1.IsLoaded)
		{
			return pckarchiveManager_1.FileExists(relativePath.Replace('/', '\\').TrimStart('\\'));
		}
		return false;
	}

	public void ClearCache()
	{
		dictionary_0.Clear();
	}

	public void CloseInterfacesPck()
	{
		try
		{
			pckarchiveManager_0?.Dispose();
		}
		catch
		{
		}
		pckarchiveManager_0 = null;
		string_0 = string.Empty;
		List<string> list = dictionary_0.Keys.Where(Class369.class369_0.method_2).ToList();
		foreach (string item in list)
		{
			dictionary_0.Remove(item);
		}
	}

	public void CloseSurfacesPck()
	{
		try
		{
			pckarchiveManager_1?.Dispose();
		}
		catch
		{
		}
		pckarchiveManager_1 = null;
		string_1 = string.Empty;
		List<string> list = dictionary_0.Keys.Where(Class369.class369_0.method_3).ToList();
		foreach (string item in list)
		{
			dictionary_0.Remove(item);
		}
	}

	public void Dispose()
	{
		CloseInterfacesPck();
		CloseSurfacesPck();
		dictionary_0.Clear();
	}

	private static string smethod_0(byte[] byte_0)
	{
		if (byte_0.Length >= 2 && byte_0[0] == byte.MaxValue && byte_0[1] == 254)
		{
			return Encoding.Unicode.GetString(byte_0, 2, byte_0.Length - 2);
		}
		if (byte_0.Length >= 2 && byte_0[0] == 254 && byte_0[1] == byte.MaxValue)
		{
			return Encoding.BigEndianUnicode.GetString(byte_0, 2, byte_0.Length - 2);
		}
		if (byte_0.Length >= 3 && byte_0[0] == 239 && byte_0[1] == 187 && byte_0[2] == 191)
		{
			return Encoding.UTF8.GetString(byte_0, 3, byte_0.Length - 3);
		}
		if (byte_0.Length >= 2 && byte_0[0] == 60 && byte_0[1] == 0)
		{
			return Encoding.Unicode.GetString(byte_0);
		}
		if (byte_0.Length >= 2 && byte_0[0] == 0 && byte_0[1] == 60)
		{
			return Encoding.BigEndianUnicode.GetString(byte_0);
		}
		return Encoding.UTF8.GetString(byte_0);
	}
}
