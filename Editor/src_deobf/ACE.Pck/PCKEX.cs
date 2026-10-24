using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.Protectors;
using ACE.RSGlobal;

namespace ACE.Pck;

public class PCKEX
{
	public class PCKDir
	{
		public string Name;

		public IDictionary<string, PCKDir> Dirs = new Dictionary<string, PCKDir>();

		public IDictionary<string, int> Files;

		public int _files_start_index;

		public int FileCount
		{
			get
			{
				int num = 0;
				IDictionary<string, int> files = Files;
				if (files != null)
				{
					num = files.Count;
				}
				IDictionary<string, PCKDir> dirs = Dirs;
				if (dirs != null)
				{
					foreach (PCKDir value in dirs.Values)
					{
						num = value.FileCount + num;
					}
				}
				GC.KeepAlive(this);
				return num;
			}
		}

		public PCKDir(string Name)
		{
			this.Name = Name;
		}

		public PCKDir GetOrAddSubDir(string DirName)
		{
			PCKDir value = null;
			if (!Dirs.TryGetValue(DirName, out value))
			{
				value = new PCKDir(DirName);
				Dirs.Add(DirName, value);
			}
			GC.KeepAlive(this);
			return value;
		}

		public void AddFileToHierarchy(string path, int index)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				return;
			}
			string[] array = path.Split('\\');
			if (array == null || array.Length == 0)
			{
				return;
			}
			PCKDir pCKDir = this;
			int num = (int)((nint)array.LongLength - 1);
			int num2 = _files_start_index;
			if (num2 < num)
			{
				do
				{
					if (!string.IsNullOrWhiteSpace(array[num2]))
					{
						pCKDir = pCKDir.GetOrAddSubDir(array[num2]);
						num2++;
					}
					else
					{
						num2++;
					}
				}
				while (num2 < num);
			}
			string text = array[num];
			if (!string.IsNullOrWhiteSpace(text))
			{
				if (pCKDir.Files == null)
				{
					pCKDir.Files = new Dictionary<string, int>();
				}
				if (!pCKDir.Files.ContainsKey(text))
				{
					pCKDir.Files.Add(text, index);
				}
				GC.KeepAlive(this);
			}
		}
	}

	public PckProgressHandler PH;

	public PCK Pck;

	public eListCollection eLC;

	private PckExtractorProgressEventArgs pckExtractorProgressEventArgs_0;

	private ulong ulong_0;

	public PCKDir Hierarchy;

	public string RemainingTime
	{
		get
		{
			PckExtractorProgressEventArgs e = pckExtractorProgressEventArgs_0;
			long totalSize = e.TotalSize;
			long passedSize = e.PassedSize;
			if (passedSize < totalSize / 10L)
			{
				return null;
			}
			double num = (double)passedSize / (double)totalSize;
			ulong num2 = ulong_0;
			double num3 = (double)(ACE.RSGlobal.RSGlobal.GetTickCount64() - num2) / (num * 100.0) / 1000.0;
			uint num4 = (uint)Math.Round((1.0 - num) * 100.0 * num3);
			if (num4 == 0)
			{
				GC.KeepAlive(this);
				return null;
			}
			string result = CommonStorage.SecondsToString(num4, bShowSeconds: false, bZeroIsNotForever: true);
			GC.KeepAlive(this);
			return result;
		}
	}

	[SpecialName]
	public event PckProgressHandler OnExtractProgress
	{
		add
		{
			PH = (PckProgressHandler)Delegate.Combine(PH, value);
			GC.KeepAlive(this);
		}
		remove
		{
			PH = (PckProgressHandler)Delegate.Remove(PH, value);
			GC.KeepAlive(this);
		}
	}

	public PCKEX(PCK Pck)
	{
		this.Pck = Pck;
		CreateHierarchy();
	}

	public PCKEX(PCK Pck, eListCollection eLC)
	{
		this.Pck = Pck;
		this.eLC = eLC;
		CreateHierarchy();
	}

	[SpecialName]
	public void raise_OnExtractProgress(object sender, PckExtractorProgressEventArgs e)
	{
		if (PH != null)
		{
			PH(sender, e);
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ExtractAll(ref string Path)
	{
		bool result = false;
		try
		{
			if (Directory.Exists(Path = Path + Class16.smethod_0(1648927580) + Pck.BaseName + Class16.smethod_0(1649060563)))
			{
				Directory.Delete(Path, recursive: true);
			}
			Directory.CreateDirectory(Path);
			ExtractFiles(Hierarchy, Path, bCreateDir: true);
			result = true;
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649196649));
			DKBox.Show(ex.Message, Class16.smethod_0(1648924056), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		GC.KeepAlive(this);
		return result;
	}

	public void ExtractFiles(PCKDir PckDir, string Path, [MarshalAs(UnmanagedType.U1)] bool bCreateDir, [MarshalAs(UnmanagedType.U1)] bool bExtractSubdirs)
	{
		if (PckDir == null || Pck == null || string.IsNullOrWhiteSpace(Path))
		{
			return;
		}
		if (!Path.EndsWith(Class16.smethod_0(1648927580)))
		{
			Path += Class16.smethod_0(1648927580);
		}
		if (bCreateDir)
		{
			Path = string.Concat(Path, PckDir.Name + Class16.smethod_0(1648927580));
			if (!Directory.Exists(Path))
			{
				Directory.CreateDirectory(Path);
			}
		}
		if (PckDir.Files != null)
		{
			pckExtractorProgressEventArgs_0.CurrentDir = PckDir.Name;
			foreach (KeyValuePair<string, int> file in PckDir.Files)
			{
				ValueType valueType = file;
				string key = ((KeyValuePair<string, int>)(object)valueType).Key;
				int value = ((KeyValuePair<string, int>)(object)valueType).Value;
				if (string.IsNullOrWhiteSpace(key))
				{
					pckExtractorProgressEventArgs_0.CurrentIndex++;
					if (PH != null)
					{
						PH(this, pckExtractorProgressEventArgs_0);
					}
					continue;
				}
				byte[] fileB = Pck.GetFileB(value);
				if (fileB != null)
				{
					string path = System.IO.Path.Combine(Path, key);
					string directoryName = System.IO.Path.GetDirectoryName(path);
					if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					File.WriteAllBytes(path, fileB);
					long num = Pck.GetFileSize(value, bCompressed: false);
					pckExtractorProgressEventArgs_0.PassedSize += num;
				}
				pckExtractorProgressEventArgs_0.CurrentIndex++;
				if (PH != null)
				{
					PH(this, pckExtractorProgressEventArgs_0);
				}
			}
		}
		if (bExtractSubdirs && PckDir.Dirs.Count > 0)
		{
			foreach (KeyValuePair<string, PCKDir> dir in PckDir.Dirs)
			{
				PCKDir value2 = ((KeyValuePair<string, PCKDir>)(object)dir).Value;
				ExtractFiles(value2, Path, bCreateDir, bExtractSubdirs);
			}
		}
		GC.KeepAlive(this);
	}

	public void ExtractFiles(PCKDir PckDir, string Path, [MarshalAs(UnmanagedType.U1)] bool bCreateDir)
	{
		pckExtractorProgressEventArgs_0 = new PckExtractorProgressEventArgs(PckDir.FileCount, GetDirSize(PckDir, bCompressed: false));
		ulong_0 = ACE.RSGlobal.RSGlobal.GetTickCount64();
		pckExtractorProgressEventArgs_0.Stage = PckExtractorStage.Extracting;
		ExtractFiles(PckDir, Path, bCreateDir, bExtractSubdirs: true);
	}

	public long GetDirSize(PCKDir PckDir, [MarshalAs(UnmanagedType.U1)] bool bCompressed)
	{
		long num = 0L;
		IDictionary<string, int> files = PckDir.Files;
		if (files != null)
		{
			foreach (int value in files.Values)
			{
				num += Pck.GetFileSize(value, bCompressed);
			}
		}
		IDictionary<string, PCKDir> dirs = PckDir.Dirs;
		if (dirs != null)
		{
			foreach (PCKDir value2 in dirs.Values)
			{
				num += GetDirSize(value2, bCompressed);
			}
		}
		GC.KeepAlive(this);
		return num;
	}

	public void CreateHierarchy()
	{
		if (Pck == null)
		{
			Hierarchy = new PCKDir(Class16.smethod_0(1649198241));
			return;
		}
		string name = (string.IsNullOrWhiteSpace(Pck.BaseName) ? Class16.smethod_0(1649198241) : Pck.BaseName);
		PCKDir pCKDir = (Hierarchy = new PCKDir(name));
		if (Pck.Game == GAMES.PW)
		{
			pCKDir._files_start_index = 1;
		}
		if (Pck.FileTableIndices == null)
		{
			return;
		}
		foreach (KeyValuePair<string, int> fileTableIndex in Pck.FileTableIndices)
		{
			string key = fileTableIndex.Key;
			int value = fileTableIndex.Value;
			if (!string.IsNullOrWhiteSpace(key) && value >= 0 && value < Pck.FileCount)
			{
				try
				{
					Hierarchy.AddFileToHierarchy(key, value);
				}
				catch (Exception ex)
				{
					SentryHelper.CaptureException(ex, Class16.smethod_0(1649196672));
				}
			}
		}
		GC.KeepAlive(this);
	}
}
