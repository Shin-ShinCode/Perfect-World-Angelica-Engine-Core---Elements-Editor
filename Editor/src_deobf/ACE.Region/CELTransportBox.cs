using System.Runtime.CompilerServices;

namespace ACE.Region;

public class CELTransportBox
{
	private int int_0 = 1;

	private int int_1;

	private int int_2;

	private int int_3;

	private RegionVector3 regionVector3_0 = new RegionVector3();

	private RegionVector3 regionVector3_1 = new RegionVector3();

	private RegionVector3 regionVector3_2 = new RegionVector3();

	public int m_iType
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public int m_idInst
	{
		[CompilerGenerated]
		get
		{
			return int_1;
		}
		[CompilerGenerated]
		set
		{
			int_1 = value;
		}
	}

	public int m_idSrcInst
	{
		[CompilerGenerated]
		get
		{
			return int_2;
		}
		[CompilerGenerated]
		set
		{
			int_2 = value;
		}
	}

	public int m_iLevelLmt
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

	public RegionVector3 tm_vPos
	{
		[CompilerGenerated]
		get
		{
			return regionVector3_0;
		}
		[CompilerGenerated]
		set
		{
			regionVector3_0 = value;
		}
	}

	public RegionVector3 m_vExts
	{
		[CompilerGenerated]
		get
		{
			return regionVector3_1;
		}
		[CompilerGenerated]
		set
		{
			regionVector3_1 = value;
		}
	}

	public RegionVector3 m_vTarge
	{
		[CompilerGenerated]
		get
		{
			return regionVector3_2;
		}
		[CompilerGenerated]
		set
		{
			regionVector3_2 = value;
		}
	}

	public CELTransportBox Clone()
	{
		return new CELTransportBox
		{
			m_iType = m_iType,
			m_idInst = m_idInst,
			m_idSrcInst = m_idSrcInst,
			m_iLevelLmt = m_iLevelLmt,
			tm_vPos = tm_vPos.Clone(),
			m_vExts = m_vExts.Clone(),
			m_vTarge = m_vTarge.Clone()
		};
	}
}
