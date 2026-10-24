using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ACE.NpcGen.LBLIBRARY.LBLIBRARY.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
[CompilerGenerated]
[DebuggerNonUserCode]
internal class Resources
{
	private static CultureInfo cultureInfo_0;

	private static ResourceManager resourceManager_0;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return cultureInfo_0;
		}
		set
		{
			cultureInfo_0 = value;
		}
	}

	internal static Bitmap English => (Bitmap)ResourceManager.GetObject(Class16.smethod_0(1648899236), cultureInfo_0);

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceManager_0 == null)
			{
				resourceManager_0 = new ResourceManager(Class16.smethod_0(1649117218), typeof(Resources).Assembly);
			}
			return resourceManager_0;
		}
	}

	internal static Bitmap Russian => (Bitmap)ResourceManager.GetObject(Class16.smethod_0(1648896752), cultureInfo_0);

	internal static Bitmap silver => (Bitmap)ResourceManager.GetObject(Class16.smethod_0(1649117237), cultureInfo_0);

	internal Resources()
	{
	}
}
