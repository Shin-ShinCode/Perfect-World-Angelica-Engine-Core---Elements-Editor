using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ACE.EcmEditor.Services;

public class EcmPckKey
{
	private string string_0 = Class16.smethod_0(1648929202);

	private int int_0;

	private int int_1;

	private static List<EcmPckKey> list_0;

	public string Name
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public int KEY_1
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

	public int KEY_2
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

	public static List<EcmPckKey> DefaultKeys => new List<EcmPckKey>
	{
		new EcmPckKey
		{
			Name = Class16.smethod_0(1648994670),
			KEY_1 = -1466731422,
			KEY_2 = -240896429
		},
		new EcmPckKey
		{
			Name = Class16.smethod_0(1648994682),
			KEY_1 = 566434367,
			KEY_2 = 408690725
		},
		new EcmPckKey
		{
			Name = Class16.smethod_0(1648994711),
			KEY_1 = -1228069623,
			KEY_2 = 1822409141
		},
		new EcmPckKey
		{
			Name = Class16.smethod_0(1648994720),
			KEY_1 = 711164174,
			KEY_2 = 839959661
		},
		new EcmPckKey
		{
			Name = Class16.smethod_0(1648994731),
			KEY_1 = -1466731422,
			KEY_2 = -240896429
		},
		new EcmPckKey
		{
			Name = Class16.smethod_0(1648994758),
			KEY_1 = 1654979041,
			KEY_2 = 891339733
		}
	};

	public static List<EcmPckKey> AllKeys
	{
		get
		{
			if (list_0 != null)
			{
				return list_0;
			}
			list_0 = smethod_0();
			if (list_0.Count == 0)
			{
				list_0 = new List<EcmPckKey>(DefaultKeys);
			}
			return list_0;
		}
	}

	private static List<EcmPckKey> smethod_0()
	{
		List<EcmPckKey> list = new List<EcmPckKey>();
		string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Class16.smethod_0(1648994773));
		if (!File.Exists(path))
		{
			return list;
		}
		try
		{
			string[] array = File.ReadAllLines(path);
			string text = null;
			EcmPckKey ecmPckKey = new EcmPckKey();
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				string text3 = text2.Trim();
				if (text3.StartsWith(Class16.smethod_0(1648924364)) && text3.EndsWith(Class16.smethod_0(1649008474)))
				{
					if (text != null && text.StartsWith(Class16.smethod_0(1648994796)) && !string.IsNullOrEmpty(ecmPckKey.Name) && ecmPckKey.Name != Class16.smethod_0(1648929202))
					{
						list.Add(ecmPckKey);
						ecmPckKey = new EcmPckKey();
					}
					string text4 = text3;
					text = text4.Substring(1, text4.Length - 1 - 1);
					continue;
				}
				int num = text3.IndexOf('=');
				if (num <= 0 || text == null || !text.StartsWith(Class16.smethod_0(1648994796)))
				{
					continue;
				}
				string text5 = text3.Substring(0, num).Trim();
				string text6 = text3.Substring(num + 1).Trim();
				string text7 = text5.ToUpperInvariant();
				if (!(text7 == Class16.smethod_0(1648994807)))
				{
					int result2;
					if (!(text7 == Class16.smethod_0(1648994810)))
					{
						if (text7 == Class16.smethod_0(1648989709) && int.TryParse(text6, out var result))
						{
							ecmPckKey.KEY_2 = result;
						}
					}
					else if (int.TryParse(text6, out result2))
					{
						ecmPckKey.KEY_1 = result2;
					}
				}
				else
				{
					ecmPckKey.Name = text6;
				}
			}
			if (text != null && text.StartsWith(Class16.smethod_0(1648994796)) && !string.IsNullOrEmpty(ecmPckKey.Name) && ecmPckKey.Name != Class16.smethod_0(1648929202))
			{
				list.Add(ecmPckKey);
			}
		}
		catch
		{
		}
		return list;
	}
}
