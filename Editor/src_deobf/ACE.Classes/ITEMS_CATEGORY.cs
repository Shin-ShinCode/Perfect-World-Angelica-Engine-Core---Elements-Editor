using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.InteropServices;
using ACE.sTASKedit.Classes;

namespace ACE.Classes;

[Serializable]
public class ITEMS_CATEGORY
{
	private string _Name;

	private Color _IDBackColor;

	private Color _IDForeColor;

	private ObservableCollection<LISTandID> _Items;

	public ObservableCollection<LISTandID> Items
	{
		get
		{
			return _Items;
		}
		set
		{
			_Items = value;
		}
	}

	public Color IDForeColor
	{
		get
		{
			return _IDForeColor;
		}
		set
		{
			_IDForeColor = value;
		}
	}

	public Color IDBackColor
	{
		get
		{
			return _IDBackColor;
		}
		set
		{
			_IDBackColor = value;
		}
	}

	public string Name
	{
		get
		{
			return _Name;
		}
		set
		{
			_Name = value;
		}
	}

	public ITEMS_CATEGORY(string Name)
	{
		Init(Name);
	}

	public ITEMS_CATEGORY()
	{
		Init(Class16.smethod_0(1648904254));
	}

	public void Init(string Name)
	{
		_Name = Name;
		Color itemDark = SpecialColors.ItemDark;
		_IDBackColor = itemDark;
		Color gray = Color.Gray;
		_IDForeColor = gray;
		_Items = new ObservableCollection<LISTandID>();
	}

	[return: MarshalAs(UnmanagedType.U1)]
	public bool Contains(LISTandID item)
	{
		bool result = _Items.Contains(item);
		GC.KeepAlive(this);
		return result;
	}
}
