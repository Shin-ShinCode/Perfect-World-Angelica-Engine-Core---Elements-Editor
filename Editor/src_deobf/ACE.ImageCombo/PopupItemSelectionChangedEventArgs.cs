using System.Runtime.CompilerServices;

namespace ACE.ImageCombo;

public class PopupItemSelectionChangedEventArgs
{
	private int int_0;

	private bool bool_0;

	public int ItemIndex
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
	}

	public bool IsSelected
	{
		[CompilerGenerated]
		get
		{
			return bool_0;
		}
	}

	public PopupItemSelectionChangedEventArgs(int ItemIndex, bool IsSelected)
	{
		method_0(ItemIndex);
		method_1(IsSelected);
	}

	private void method_0(int int_1)
	{
		int_0 = int_1;
	}

	private void method_1(bool bool_1)
	{
		bool_0 = bool_1;
	}
}
