using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ACE.UIEdit.Services;

internal static class UiEditorSettingsStore
{
	private static readonly string string_0 = System.IO.Path.Combine(Application.StartupPath, Class16.smethod_0(1649075606), Class16.smethod_0(1649276660));

	public static UiEditorSettings Load()
	{
		try
		{
			if (!File.Exists(string_0))
			{
				return new UiEditorSettings();
			}
			string text = File.ReadAllText(string_0, Encoding.UTF8);
			UiEditorSettings uiEditorSettings = JsonConvert.DeserializeObject<UiEditorSettings>(text);
			return uiEditorSettings ?? new UiEditorSettings();
		}
		catch
		{
			return new UiEditorSettings();
		}
	}

	public static void Save(UiEditorSettings settings)
	{
		try
		{
			Directory.CreateDirectory(System.IO.Path.GetDirectoryName(string_0) ?? Application.StartupPath);
			string contents = JsonConvert.SerializeObject((object)settings, (Formatting)1);
			File.WriteAllText(string_0, contents, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
		}
		catch
		{
		}
	}
}
