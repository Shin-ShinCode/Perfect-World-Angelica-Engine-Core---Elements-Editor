using System;
using System.Globalization;
using System.IO;
using System.Text;
using ACE.AIPolicyEditor.AIPolicy;
using ACE.Classes;
using ACE.Elements.eListCollection;
using ACE.sTASKedit.Classes;
using Newtonsoft.Json;

namespace ACE.Mcp;

internal sealed class AceMcpFileService : IAceMcpFileService
{
	public object GetLoadedModules()
	{
		return new
		{
			ok = true,
			modules = new object[4]
			{
				AceMcpRuntime.GetModuleStatus(Class16.smethod_0(1648906367)),
				AceMcpRuntime.GetModuleStatus(Class16.smethod_0(1648906421)),
				AceMcpRuntime.GetModuleStatus(Class16.smethod_0(1648942729)),
				AceMcpRuntime.GetModuleStatus(Class16.smethod_0(1648906400))
			}
		};
	}

	public object LoadModule(string module, string path)
	{
		module = AceMcpRuntime.NormalizeModule(module);
		if (string.IsNullOrWhiteSpace(module))
		{
			throw new ArgumentException(Class16.smethod_0(1649130922));
		}
		if (string.IsNullOrWhiteSpace(path))
		{
			throw new ArgumentException(Class16.smethod_0(1649130960));
		}
		if (!File.Exists(path))
		{
			throw new FileNotFoundException(Class16.smethod_0(1649131004), path);
		}
		if (!(module == Class16.smethod_0(1648906367)))
		{
			if (!(module == Class16.smethod_0(1648906421)))
			{
				if (!(module == Class16.smethod_0(1648942729)))
				{
					if (!(module == Class16.smethod_0(1648906400)))
					{
						throw new ArgumentOutOfRangeException(Class16.smethod_0(1649130072), Class16.smethod_0(1649130083) + module + Class16.smethod_0(1648928156));
					}
					AceMcpRuntime.LoadNpcGenDocument(path);
					if (CommonStorage.Params == null)
					{
						CommonStorage.Params = new ParamsClass();
					}
					CommonStorage.Params.NPCGenPath = path;
					return new
					{
						ok = true,
						module = module,
						path = path,
						status = AceMcpRuntime.GetModuleStatus(module)
					};
				}
				AIFile aIFile = new AIFile
				{
					InAnotherThread = false
				};
				aIFile.Read(path);
				DataFiles.AIPolicy = aIFile;
				if (CommonStorage.Params == null)
				{
					CommonStorage.Params = new ParamsClass();
				}
				CommonStorage.Params.AIPolicyPath = path;
				return new
				{
					ok = true,
					module = module,
					path = path,
					status = AceMcpRuntime.GetModuleStatus(module)
				};
			}
			TASKS tASKS = new TASKS(path);
			if (!tASKS.FileLoaded)
			{
				throw new InvalidOperationException(Class16.smethod_0(1649130046) + path + Class16.smethod_0(1648928156));
			}
			DataFiles.Tasks = tASKS;
			if (CommonStorage.Params == null)
			{
				CommonStorage.Params = new ParamsClass();
			}
			CommonStorage.Params.TasksPath = path;
			return new
			{
				ok = true,
				module = module,
				path = path,
				status = AceMcpRuntime.GetModuleStatus(module)
			};
		}
		eListCollection eListCollection2 = new eListCollection(path, bMultithread: false);
		if (!eListCollection2.FileLoaded)
		{
			throw new InvalidOperationException(Class16.smethod_0(1649130001) + path + Class16.smethod_0(1648928156));
		}
		DataFiles.Elements = eListCollection2;
		if (CommonStorage.Params == null)
		{
			CommonStorage.Params = new ParamsClass();
		}
		CommonStorage.Params.ElementsPath = path;
		return new
		{
			ok = true,
			module = module,
			path = path,
			status = AceMcpRuntime.GetModuleStatus(module)
		};
	}

	public object ReloadModule(string module)
	{
		module = AceMcpRuntime.NormalizeModule(module);
		string modulePath = AceMcpRuntime.GetModulePath(module);
		if (string.IsNullOrWhiteSpace(modulePath))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649130118) + module + Class16.smethod_0(1649130133));
		}
		return LoadModule(module, modulePath);
	}

	public object SaveModule(string module, string path, bool saveAs)
	{
		module = AceMcpRuntime.NormalizeModule(module);
		if (!(module == Class16.smethod_0(1648906367)))
		{
			if (!(module == Class16.smethod_0(1648906421)))
			{
				if (!(module == Class16.smethod_0(1648942729)))
				{
					if (!(module == Class16.smethod_0(1648906400)))
					{
						throw new ArgumentOutOfRangeException(Class16.smethod_0(1649130335), Class16.smethod_0(1649130083) + module + Class16.smethod_0(1648928156));
					}
					AceMcpNpcGenDocument aceMcpNpcGenDocument = AceMcpRuntime.RequireNpcGenDocument();
					string text = (string.IsNullOrWhiteSpace(path) ? aceMcpNpcGenDocument.FileName : path);
					if (string.IsNullOrWhiteSpace(text))
					{
						throw new InvalidOperationException(Class16.smethod_0(1649130303));
					}
					AceMcpRuntime.SaveNpcGenDocument(aceMcpNpcGenDocument, text);
					if (saveAs)
					{
						aceMcpNpcGenDocument.FileName = text;
					}
					return new
					{
						ok = true,
						module = module,
						path = text,
						save_as = saveAs
					};
				}
				AIFile aIFile = AceMcpRuntime.RequireAIPolicy();
				string text2 = (string.IsNullOrWhiteSpace(path) ? aIFile.FilePath : path);
				if (string.IsNullOrWhiteSpace(text2))
				{
					throw new InvalidOperationException(Class16.smethod_0(1649130269));
				}
				if (saveAs && !string.Equals(text2, aIFile.FilePath, StringComparison.OrdinalIgnoreCase))
				{
					aIFile.SaveAs(text2);
				}
				else
				{
					aIFile.Save();
				}
				if (!string.IsNullOrWhiteSpace(path))
				{
					aIFile.Read(text2);
				}
				return new
				{
					ok = true,
					module = module,
					path = text2,
					save_as = saveAs
				};
			}
			TASKS tASKS = AceMcpRuntime.RequireTasks();
			string text3 = (string.IsNullOrWhiteSpace(path) ? tASKS.FileName : path);
			if (string.IsNullOrWhiteSpace(text3))
			{
				throw new InvalidOperationException(Class16.smethod_0(1649130238));
			}
			if (saveAs && !string.Equals(text3, tASKS.FileName, StringComparison.OrdinalIgnoreCase))
			{
				string fileName = tASKS.FileName;
				tASKS.FileName = text3;
				tASKS.Save();
				tASKS.FileName = text3;
				if (!string.IsNullOrWhiteSpace(fileName) && File.Exists(fileName) && !string.Equals(fileName, text3, StringComparison.OrdinalIgnoreCase))
				{
					tASKS.FileName = text3;
				}
			}
			else
			{
				tASKS.Save();
			}
			tASKS.TimeChange = File.GetLastWriteTime(tASKS.FileName);
			return new
			{
				ok = true,
				module = module,
				path = tASKS.FileName,
				save_as = saveAs
			};
		}
		eListCollection eListCollection2 = AceMcpRuntime.RequireElements();
		string text4 = (string.IsNullOrWhiteSpace(path) ? eListCollection2.FileName : path);
		if (string.IsNullOrWhiteSpace(text4))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649130161));
		}
		if (!eListCollection2.Save(text4, null, bEncryptElements: false, ELEMENTS_SAVE_TYPE.FULL_SIGNATURE))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649130195) + text4 + Class16.smethod_0(1648928156));
		}
		eListCollection2.FileName = text4;
		eListCollection2.TimeChange = File.GetLastWriteTime(text4);
		eListCollection2.FileChanged = false;
		return new
		{
			ok = true,
			module = module,
			path = text4,
			save_as = saveAs
		};
	}

	public object BackupModule(string module, string path)
	{
		module = AceMcpRuntime.NormalizeModule(module);
		string modulePath = AceMcpRuntime.GetModulePath(module);
		if (string.IsNullOrWhiteSpace(modulePath))
		{
			throw new InvalidOperationException(Class16.smethod_0(1649130118) + module + Class16.smethod_0(1649130338));
		}
		string text = (string.IsNullOrWhiteSpace(path) ? (modulePath + Class16.smethod_0(1649130389) + DateTime.UtcNow.ToString(Class16.smethod_0(1649130393), CultureInfo.InvariantCulture) + Class16.smethod_0(1648898363)) : path);
		File.Copy(modulePath, text, overwrite: true);
		return new
		{
			ok = true,
			module = module,
			source_path = modulePath,
			backup_path = text
		};
	}

	public object ExportModuleJson(string module, string path, bool includeData)
	{
		module = AceMcpRuntime.NormalizeModule(module);
		if (string.IsNullOrWhiteSpace(path))
		{
			throw new ArgumentException(Class16.smethod_0(1649130960));
		}
		object obj;
		if (!(module == Class16.smethod_0(1648906367)))
		{
			if (!(module == Class16.smethod_0(1648906421)))
			{
				if (!(module == Class16.smethod_0(1648942729)))
				{
					if (!(module == Class16.smethod_0(1648906400)))
					{
						throw new ArgumentOutOfRangeException(Class16.smethod_0(1649130422), Class16.smethod_0(1649130083) + module + Class16.smethod_0(1648928156));
					}
					obj = AceMcpRuntime.ExportNpcGen(includeData);
				}
				else
				{
					obj = AceMcpRuntime.ExportAipolicy(includeData);
				}
			}
			else
			{
				obj = AceMcpRuntime.ExportTasks(includeData);
			}
		}
		else
		{
			obj = AceMcpRuntime.ExportElements(includeData);
		}
		object obj2 = obj;
		File.WriteAllText(path, JsonConvert.SerializeObject(obj2, (Formatting)1), Encoding.UTF8);
		return new
		{
			ok = true,
			module = module,
			path = path,
			include_data = includeData
		};
	}
}
