using System.Drawing;
using System.Windows.Forms;
using ACE.Classes;

namespace ACE.PWMap;

public sealed class PwMapShortcutHelpDialog : Form
{
	public PwMapShortcutHelpDialog()
	{
		Text = Class16.smethod_0(1649204444);
		base.Size = new Size(520, 560);
		base.StartPosition = FormStartPosition.CenterParent;
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.MinimizeBox = false;
		base.MaximizeBox = false;
		base.ShowInTaskbar = false;
		method_1();
		method_0();
		TextStorage.TEXTS.SetFormLanguage(this, null);
	}

	private void method_0()
	{
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		if (base.IsHandleCreated)
		{
			TDark.ApplyImmersiveDarkMode(base.Handle, TDark.IsDarkMode);
		}
		TDark.ApplyNativeDarkThemeRecursive(this);
	}

	private void method_1()
	{
		ListView listView = new ListView
		{
			Location = new Point(12, 12),
			Size = new Size(base.ClientSize.Width - 24, base.ClientSize.Height - 60),
			View = View.Details,
			FullRowSelect = true,
			GridLines = true,
			HeaderStyle = ColumnHeaderStyle.Nonclickable
		};
		listView.Columns.Add(Class16.smethod_0(1649204469), 130);
		listView.Columns.Add(Class16.smethod_0(1648930017), 330);
		(string, string)[] array = new(string, string)[35]
		{
			(Class16.smethod_0(1649204484), Class16.smethod_0(1649204496)),
			(Class16.smethod_0(1649204546), Class16.smethod_0(1649204574)),
			(Class16.smethod_0(1649204587), Class16.smethod_0(1649204613)),
			(Class16.smethod_0(1649204636), Class16.smethod_0(1649204653)),
			(Class16.smethod_0(1649204680), Class16.smethod_0(1649204711)),
			(Class16.smethod_0(1649204723), Class16.smethod_0(1649203721)),
			(Class16.smethod_0(1649203738), Class16.smethod_0(1649203764)),
			(Class16.smethod_0(1649203782), Class16.smethod_0(1649203799)),
			(Class16.smethod_0(1649203811), Class16.smethod_0(1649203838)),
			(Class16.smethod_0(1649203857), Class16.smethod_0(1649203875)),
			(string.Empty, string.Empty),
			(Class16.smethod_0(1649105893), Class16.smethod_0(1649203925)),
			(Class16.smethod_0(1648915818), Class16.smethod_0(1649203955)),
			(Class16.smethod_0(1649104901), Class16.smethod_0(1649203979)),
			(Class16.smethod_0(1649105853), Class16.smethod_0(1649204018)),
			(Class16.smethod_0(1648925718), Class16.smethod_0(1649204041)),
			(Class16.smethod_0(1648992393), Class16.smethod_0(1649204079)),
			(string.Empty, string.Empty),
			(Class16.smethod_0(1649204103), Class16.smethod_0(1648903487)),
			(Class16.smethod_0(1649204118), Class16.smethod_0(1648903490)),
			(Class16.smethod_0(1649204133), Class16.smethod_0(1649204148)),
			(Class16.smethod_0(1649204169), Class16.smethod_0(1649204184)),
			(Class16.smethod_0(1649204213), Class16.smethod_0(1649203204)),
			(Class16.smethod_0(1649203219), Class16.smethod_0(1649203234)),
			(string.Empty, string.Empty),
			(Class16.smethod_0(1649203249), Class16.smethod_0(1649203267)),
			(Class16.smethod_0(1649203302), Class16.smethod_0(1649203319)),
			(string.Empty, string.Empty),
			(Class16.smethod_0(1648979502), Class16.smethod_0(1649203349)),
			(Class16.smethod_0(1649203369), Class16.smethod_0(1649203378)),
			(Class16.smethod_0(1649203415), Class16.smethod_0(1649203418)),
			(Class16.smethod_0(1649203457), Class16.smethod_0(1649203477)),
			(Class16.smethod_0(1649203496), Class16.smethod_0(1649203527)),
			(Class16.smethod_0(1649203546), Class16.smethod_0(1649203570)),
			(Class16.smethod_0(1648995835), Class16.smethod_0(1649203607))
		};
		(string, string)[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			var (text, text2) = array2[i];
			if (string.IsNullOrEmpty(text))
			{
				listView.Items.Add(new ListViewItem(new string[2]
				{
					string.Empty,
					string.Empty
				}));
			}
			else
			{
				listView.Items.Add(new ListViewItem(new string[2] { text, text2 }));
			}
		}
		base.Controls.Add(listView);
		Button button = new Button
		{
			Text = Class16.smethod_0(1649014457),
			Width = 90,
			Height = 28,
			Location = new Point(base.ClientSize.Width / 2 - 45, base.ClientSize.Height - 40),
			DialogResult = DialogResult.OK
		};
		base.Controls.Add(button);
		base.AcceptButton = button;
		base.CancelButton = button;
	}
}
