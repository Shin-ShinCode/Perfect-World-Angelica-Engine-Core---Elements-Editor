using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using ACE.Classes;
using ACE.Classes.ACE;
using ACE.MainWindow;
using ACE.RSGlobal;

namespace ACE.ExtraDrops;

public class EXTRA_DROPS
{
	public string FileName;

	public bool FileLoaded;

	public bool FileChanged;

	public DateTime TimeChange;

	public int version;

	public int TableCount;

	public List<EXTRADROPTABLE> Tables;

	public byte[] BytesAfterEndOfFile;

	public EXTRA_DROPS(string fn)
	{
		Load(fn);
	}

	public void Load(string fn)
	{
		if (!File.Exists(fn))
		{
			GC.KeepAlive(this);
			return;
		}
		EditorSessionTracker.LogFolderAccess(fn, Class16.smethod_0(1648903793), Class16.smethod_0(1649074224));
		FileName = fn;
		FileStream fileStream = null;
		BinaryReader binaryReader = null;
		try
		{
			fileStream = File.OpenRead(fn);
			binaryReader = new BinaryReader(fileStream);
			if ((version = binaryReader.ReadInt32()) != 1)
			{
				binaryReader.Close();
				int num = version;
				ACE.MainWindow.MainWindow.ShowBackgroundMessageOutside(Class16.smethod_0(1649074242) + num, IsAlert: true, 5000);
				return;
			}
			Tables = new List<EXTRADROPTABLE>(TableCount = binaryReader.ReadInt32());
			for (int i = 0; i < TableCount; i++)
			{
				Tables.Add(new EXTRADROPTABLE(binaryReader));
			}
			DateTime lastWriteTime = File.GetLastWriteTime(fn);
			TimeChange = lastWriteTime;
			FileLoaded = true;
		}
		catch (Exception ex)
		{
			string key = Class16.smethod_0(1648893578);
			ex.Data.Add(key, fn);
			if (fileStream != null)
			{
				IntPtr intPtr = fileStream.SafeFileHandle.DangerousGetHandle();
				if (intPtr != IntPtr.Zero)
				{
					string key2 = Class16.smethod_0(1648893587);
					ex.Data.Add(key2, fileStream.Position);
				}
			}
			string key3 = Class16.smethod_0(1648893602);
			ex.Data.Add(key3, true);
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649074294));
			ACE.RSGlobal.RSGlobal.ShowHandledException(ex);
			FileLoaded = false;
		}
		finally
		{
			binaryReader?.Close();
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFileChanged()
	{
		int num = ((FileLoaded && (FileChanged || IsFileOnDiscChanged())) ? 1 : 0);
		return (byte)num != 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsFileOnDiscChanged()
	{
		bool result = false;
		try
		{
			if (!string.IsNullOrWhiteSpace(FileName) && File.Exists(FileName))
			{
				DateTime lastWriteTime = File.GetLastWriteTime(FileName);
				result = !TimeChange.Equals(lastWriteTime);
			}
		}
		catch (UnauthorizedAccessException ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1649074317));
		}
		catch (IOException ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649074317));
		}
		GC.KeepAlive(this);
		return result;
	}

	public void Save()
	{
		if (string.IsNullOrWhiteSpace(FileName))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649074347));
		}
		EditorSessionTracker.LogFolderAccess(FileName, Class16.smethod_0(1649006856), Class16.smethod_0(1649074224));
		if (version == 0)
		{
			version = 1;
		}
		if (Tables == null)
		{
			Tables = new List<EXTRADROPTABLE>();
		}
		string text = System.IO.Path.GetDirectoryName(FileName);
		if (string.IsNullOrEmpty(text))
		{
			text = Environment.CurrentDirectory;
		}
		string text2 = System.IO.Path.Combine(text, System.IO.Path.GetFileName(FileName) + Class16.smethod_0(1648928036) + Guid.NewGuid().ToString(Class16.smethod_0(1648930778)) + Class16.smethod_0(1648930786));
		string destinationBackupFileName = FileName + Class16.smethod_0(1648898363);
		try
		{
			FileStream fileStream = new FileStream(text2, FileMode.Create, FileAccess.Write, FileShare.None);
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				try
				{
					binaryWriter.Write(version);
					binaryWriter.Write(Tables.Count);
					for (int i = 0; i < Tables.Count; i++)
					{
						EXTRADROPTABLE eXTRADROPTABLE = Tables[i];
						if (eXTRADROPTABLE != null)
						{
							eXTRADROPTABLE.Save(binaryWriter);
							continue;
						}
						throw new InvalidDataException(string.Format(Class16.smethod_0(1649074419), i));
					}
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)fileStream).Dispose();
			}
			if (!smethod_0(text2, out var string_))
			{
				try
				{
					File.Delete(text2);
				}
				catch
				{
				}
				throw new InvalidDataException(Class16.smethod_0(1649074465) + string_);
			}
			if (File.Exists(FileName))
			{
				File.Replace(text2, FileName, destinationBackupFileName, ignoreMetadataErrors: true);
			}
			else
			{
				File.Move(text2, FileName);
			}
			FileChanged = false;
			TimeChange = File.GetLastWriteTime(FileName);
		}
		finally
		{
			try
			{
				if (File.Exists(text2))
				{
					File.Delete(text2);
				}
			}
			catch
			{
			}
			GC.KeepAlive(this);
		}
	}

	private static bool smethod_0(string string_0, out string string_1)
	{
		string_1 = string.Empty;
		try
		{
			using (FileStream input = File.OpenRead(string_0))
			{
				BinaryReader binaryReader = new BinaryReader(input);
				try
				{
					int num = binaryReader.ReadInt32();
					if (num != 1)
					{
						string_1 = Class16.smethod_0(1649074510) + num;
						return false;
					}
					int num2 = binaryReader.ReadInt32();
					if (num2 < 0)
					{
						string_1 = Class16.smethod_0(1649074530) + num2;
						return false;
					}
					for (int i = 0; i < num2; i++)
					{
						int num3 = binaryReader.ReadInt32();
						if (num3 >= 0)
						{
							for (int j = 0; j < num3; j++)
							{
								binaryReader.ReadInt32();
							}
							for (int k = 0; k < 256; k++)
							{
								binaryReader.ReadInt32();
								binaryReader.ReadSingle();
							}
							byte[] array = binaryReader.ReadBytes(128);
							if (array.Length == 128)
							{
								binaryReader.ReadInt32();
								for (int l = 0; l < 8; l++)
								{
									binaryReader.ReadSingle();
								}
								continue;
							}
							string_1 = string.Format(Class16.smethod_0(1649074612), i, array.Length);
							return false;
						}
						string_1 = string.Format(Class16.smethod_0(1649074567), i, num3);
						return false;
					}
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			return true;
		}
		catch (EndOfStreamException)
		{
			string_1 = Class16.smethod_0(1649074650);
			return false;
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1649074682));
			string_1 = ex2.Message;
			return false;
		}
	}

	public void CreateReferences(ELEMENTS_REFERENCES References)
	{
		if (!FileLoaded)
		{
			return;
		}
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES = References.NewRefs(ReferenceType.EXTRA_DROPS_MONSTERS);
		ELEMENTS_IDS_REFERENCES eLEMENTS_IDS_REFERENCES2 = References.NewRefs(ReferenceType.EXTRA_DROPS_MATTERS);
		int num = Tables.Count - 1;
		if (num >= 0)
		{
			INDICES ind = default(INDICES);
			INDICES ind2 = default(INDICES);
			do
			{
				EXTRADROPTABLE eXTRADROPTABLE = Tables[num];
				string name = eXTRADROPTABLE.Name;
				int num2 = eXTRADROPTABLE.id_monsters.Count - 1;
				if (num2 >= 0)
				{
					do
					{
						ind.int_0 = num;
						ind.int_1 = num2;
						eLEMENTS_IDS_REFERENCES.AddRef(ReferenceSubType.EXTRA_DROPS_MONSTERS, null, ind, eXTRADROPTABLE, num, name, eXTRADROPTABLE.id_monsters[num2]);
						num2--;
					}
					while (num2 >= 0);
				}
				int num3 = (int)((nint)eXTRADROPTABLE.drop_items.LongLength - 1);
				if (num3 >= 0)
				{
					do
					{
						DROP_ITEMS[] drop_items = eXTRADROPTABLE.drop_items;
						int id = drop_items[num3].id;
						if (id > 0)
						{
							float probability = drop_items[num3].probability;
							ind2.int_0 = num;
							ind2.int_1 = num3;
							eLEMENTS_IDS_REFERENCES2.AddRef(ReferenceSubType.EXTRA_DROPS_MATTERS, null, ind2, eXTRADROPTABLE, num, name, id, probability);
						}
						num3--;
					}
					while (num3 >= 0);
				}
				num--;
			}
			while (num >= 0);
		}
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool ChangeValueFromReference(REFERENCE_TYPE_EX RefType, ref REFERENCE_ENTRY reference, int new_id, string val1, string val2)
	{
		INDICES indices = reference.indices;
		EXTRADROPTABLE eXTRADROPTABLE = Tables[indices.int_0];
		switch (RefType.SectionType)
		{
		case ReferenceType.EXTRA_DROPS_MATTERS:
			if (new_id > -1)
			{
				eXTRADROPTABLE.drop_items[indices.int_1].id = new_id;
			}
			if (val1 != null)
			{
				float result = 0f;
				if (float.TryParse(val1, out result))
				{
					eXTRADROPTABLE.drop_items[indices.int_1].probability = result;
					reference.extra_value1 = result;
				}
			}
			break;
		case ReferenceType.EXTRA_DROPS_MONSTERS:
			if (new_id > -1)
			{
				eXTRADROPTABLE.id_monsters[indices.int_1] = new_id;
			}
			break;
		}
		FileChanged = true;
		return true;
	}
}
