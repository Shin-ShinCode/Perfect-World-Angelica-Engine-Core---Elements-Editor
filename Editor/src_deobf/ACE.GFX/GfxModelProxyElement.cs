using System.Runtime.CompilerServices;

namespace ACE.GFX;

public class GfxModelProxyElement : GfxElement
{
	private int int_3;

	public int ProxyId
	{
		[CompilerGenerated]
		get
		{
			return int_3;
		}
		[CompilerGenerated]
		set
		{
			int_3 = value;
		}
	}

	public GfxModelProxyElement()
	{
		base.ElementType = GfxElementType.ModelProxy;
	}

	public override void LoadSpecific(GfxFileReader gfxFileReader_0, uint version)
	{
		ProxyId = gfxFileReader_0.ReadInt();
	}
}
