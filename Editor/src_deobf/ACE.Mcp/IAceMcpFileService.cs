namespace ACE.Mcp;

internal interface IAceMcpFileService
{
	object GetLoadedModules();

	object LoadModule(string module, string path);

	object ReloadModule(string module);

	object SaveModule(string module, string path, bool saveAs);

	object BackupModule(string module, string path);

	object ExportModuleJson(string module, string path, bool includeData);
}
