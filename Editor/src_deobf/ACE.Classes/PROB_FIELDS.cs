using System.Runtime.InteropServices;

namespace ACE.Classes;

public struct PROB_FIELDS
{
	public int id_f;

	public int prob_f;

	public int val1_f;

	public int val2_f;

	public PROB_FIELDS(int count, int prob_f, int id_offset, int val1_offset, int val2_offset)
	{
		this.prob_f = prob_f;
		id_f = 0;
		val1_f = 0;
		val2_f = 0;
		if (id_offset != 0)
		{
			id_f = prob_f + id_offset;
		}
		if (val1_offset != 0)
		{
			val1_f = prob_f + val1_offset;
		}
		if (val2_offset != 0)
		{
			val2_f = prob_f + val2_offset;
		}
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsSomeFieldsPresent()
	{
		int num = ((id_f > 0 || val1_f > 0 || val2_f > 0) ? 1 : 0);
		return (byte)num != 0;
	}
}
