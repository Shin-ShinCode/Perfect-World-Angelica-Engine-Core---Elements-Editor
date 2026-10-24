using System;
using System.Runtime.InteropServices;

namespace ACE.Dependency.zlibnet.zlib;

internal struct z_stream
{
	public IntPtr next_in;

	public uint avail_in;

	public uint total_in;

	public IntPtr next_out;

	public uint avail_out;

	public uint total_out;

	private IntPtr intptr_0;

	private IntPtr intptr_1;

	private IntPtr intptr_2;

	private IntPtr intptr_3;

	private IntPtr intptr_4;

	public ZLibDataType data_type;

	public uint adler;

	private uint uint_0;

	public string lasterrormsg => Marshal.PtrToStringAnsi(intptr_0);
}
