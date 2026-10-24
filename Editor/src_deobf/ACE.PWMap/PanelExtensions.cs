using System.Reflection;
using System.Windows.Forms;

namespace ACE.PWMap;

internal static class PanelExtensions
{
	public static void DoubleBuffered(this Panel panel)
	{
		typeof(Panel).InvokeMember(Class16.smethod_0(1648901323), BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetProperty, null, panel, new object[1] { true });
	}
}
