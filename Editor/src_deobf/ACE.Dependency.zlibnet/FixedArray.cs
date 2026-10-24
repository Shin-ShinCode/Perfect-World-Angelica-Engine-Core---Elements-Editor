using System;
using System.Runtime.InteropServices;

namespace ACE.Dependency.zlibnet;

internal class FixedArray : IDisposable
{
	private GCHandle gchandle_0;

	private Array array_0;

	public IntPtr this[int idx] => Marshal.UnsafeAddrOfPinnedArrayElement(array_0, idx);

	public FixedArray(Array array)
	{
		array_0 = array;
		gchandle_0 = GCHandle.Alloc(array, GCHandleType.Pinned);
	}

	~FixedArray()
	{
		gchandle_0.Free();
	}

	public void Dispose()
	{
		gchandle_0.Free();
		GC.SuppressFinalize(this);
	}

	public static implicit operator IntPtr(FixedArray fixedArray)
	{
		return fixedArray[0];
	}
}
