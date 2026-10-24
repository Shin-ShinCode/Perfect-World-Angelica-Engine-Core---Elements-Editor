using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACE.Classes;
using ACE.Elements.eListCollection;

namespace ACE.ActionHistory;

public class NAVIGATION_HISTORY
{
	public List<ITEMPOS> History = new List<ITEMPOS>(40);

	public int CurrentStep = -1;

	public eListCollection eLC;

	public NAVIGATION_HISTORY(eListCollection eLC)
	{
		this.eLC = eLC;
	}

	public NAVIGATION_HISTORY()
	{
	}

	public void AddStep(ITEMPOS ItemPos)
	{
		int currentStep = CurrentStep;
		if (currentStep > -1 && History[currentStep].Equals(ItemPos))
		{
			GC.KeepAlive(this);
			return;
		}
		CurrentStep++;
		if (CurrentStep < History.Count)
		{
			int currentStep2 = CurrentStep;
			int count = History.Count - currentStep2;
			History.RemoveRange(currentStep2, count);
		}
		ITEMPOS item = new ITEMPOS(ItemPos.int_0, ItemPos.int_1);
		History.Add(item);
		GC.KeepAlive(this);
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsStepBackAvailable()
	{
		return CurrentStep > 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsStepForwardAvailable()
	{
		int num = History.Count - 1;
		bool result = CurrentStep < num;
		GC.KeepAlive(this);
		return result;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsStepBackAvailableL()
	{
		int currentStep = CurrentStep;
		if (currentStep <= 0)
		{
			return false;
		}
		int int_ = History[currentStep].int_0;
		int num = CurrentStep;
		do
		{
			if (num > 0)
			{
				num--;
				continue;
			}
			return false;
		}
		while (!eLC.IsItemExist(History[num]) || int_ == History[num].int_0);
		GC.KeepAlive(this);
		return num + 1 > 0;
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool IsStepForwardAvailableL()
	{
		if (!IsStepForwardAvailable())
		{
			return false;
		}
		int int_ = History[CurrentStep].int_0;
		int num = CurrentStep;
		do
		{
			if (num < History.Count - 1)
			{
				num++;
				continue;
			}
			return false;
		}
		while (!eLC.IsItemExist(History[num]) || int_ == History[num].int_0);
		bool result = num - 1 < History.Count - 1;
		GC.KeepAlive(this);
		return result;
	}

	public ITEMPOS StepBack([MarshalAs(UnmanagedType.U1)] bool bAnotherList)
	{
		int num = -1;
		if (bAnotherList)
		{
			List<ITEMPOS> history = History;
			if (history != null)
			{
				int currentStep = CurrentStep;
				if (currentStep < history.Count)
				{
					num = History[currentStep].int_0;
				}
			}
		}
		while (true)
		{
			int currentStep2 = CurrentStep;
			if (currentStep2 <= 0)
			{
				break;
			}
			int index = (CurrentStep = currentStep2 - 1);
			if (eLC.IsItemExist(History[index]) && num != History[CurrentStep].int_0)
			{
				ITEMPOS result = History[CurrentStep];
				GC.KeepAlive(this);
				return result;
			}
		}
		GC.KeepAlive(this);
		return null;
	}

	public ITEMPOS StepForward([MarshalAs(UnmanagedType.U1)] bool bAnotherList)
	{
		int num = -1;
		if (bAnotherList)
		{
			List<ITEMPOS> history = History;
			if (history != null)
			{
				int currentStep = CurrentStep;
				if (currentStep < history.Count)
				{
					num = History[currentStep].int_0;
				}
			}
		}
		int index;
		do
		{
			if (IsStepForwardAvailable())
			{
				index = ++CurrentStep;
				continue;
			}
			GC.KeepAlive(this);
			return null;
		}
		while (!eLC.IsItemExist(History[index]) || num == History[CurrentStep].int_0);
		ITEMPOS result = History[CurrentStep];
		GC.KeepAlive(this);
		return result;
	}
}
