using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ACE.AIPolicyEditor.AIPolicy;
using ACE.AIPolicyEditor.AIPolicy.Conditions;
using ACE.AIPolicyEditor.AIPolicy.Operations;
using ACE.AIPolicyEditor.Localization;
using ACE.Classes;
using ACE.Elements;
using ACE.Elements.eListCollection;
using ACE.License;
using ACE.Pck;
using ACE.Properties;
using ACE.RSGlobal;
using ACE.sTASKedit.Classes;
using Newtonsoft.Json;

namespace ACE.AIPolicyEditor;

public class MainForm : Form
{
	private sealed class Class38
	{
		public CTriggerData ctriggerData_0;

		internal bool method_0(CTriggerData ctriggerData_1)
		{
			return ctriggerData_1.ID == ctriggerData_0.ID;
		}
	}

	private sealed class Class39
	{
		public MainForm mainForm_0;

		public ToolStripMenuItem toolStripMenuItem_0;

		public ToolStripMenuItem toolStripMenuItem_1;

		internal void method_0(object sender, EventArgs e)
		{
			byte[] currentState = mainForm_0.method_49();
			byte[] array = mainForm_0.fileBasedUndoManager_0.Undo(currentState);
			if (array != null)
			{
				mainForm_0.method_50(array);
			}
		}

		internal void method_1(object sender, EventArgs e)
		{
			byte[] currentState = mainForm_0.method_49();
			byte[] array = mainForm_0.fileBasedUndoManager_0.Redo(currentState);
			if (array != null)
			{
				mainForm_0.method_50(array);
			}
		}

		internal void method_2()
		{
			toolStripMenuItem_0.Enabled = mainForm_0.fileBasedUndoManager_0.CanUndo;
			toolStripMenuItem_1.Enabled = mainForm_0.fileBasedUndoManager_0.CanRedo;
		}
	}

	private sealed class Class40
	{
		public MainForm mainForm_0;

		public ListBox listBox_0;

		public int int_0;

		public Func<int> func_0;

		public int int_1;

		public bool bool_0;

		internal void method_0()
		{
			if (!mainForm_0.IsDisposed && !listBox_0.IsDisposed && listBox_0.IsHandleCreated && int_0 == func_0())
			{
				smethod_4(listBox_0, int_1, bool_0);
			}
		}
	}

	private sealed class Class41
	{
		public MainForm mainForm_0;

		public object object_0;

		public PropertyChangedEventArgs propertyChangedEventArgs_0;

		internal void method_0()
		{
			mainForm_0.method_46(object_0, propertyChangedEventArgs_0);
		}
	}

	private sealed class Class42
	{
		public CPolicyData cpolicyData_0;

		internal bool method_0(CPolicyData cpolicyData_1)
		{
			return cpolicyData_1.ID == cpolicyData_0.ID;
		}
	}

	private sealed class Class43
	{
		public MainForm mainForm_0;

		public object object_0;

		public NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs_0;

		internal void method_0()
		{
			mainForm_0.inotifyCollectionChanged_0_CollectionChanged(object_0, notifyCollectionChangedEventArgs_0);
		}
	}

	private sealed class Class44
	{
		public MainForm mainForm_0;

		public ListBox listBox_0;

		public int int_0;

		public Func<int> func_0;

		public int int_1;

		public Action<int> action_0;

		internal void method_0()
		{
			if (!mainForm_0.IsDisposed && !listBox_0.IsDisposed && listBox_0.IsHandleCreated && int_0 == func_0())
			{
				mainForm_0.bool_0 = true;
				try
				{
					int num = smethod_1(listBox_0);
					int num2 = ((num == 0) ? (-1) : Math.Min(Math.Max(int_1, -1), num - 1));
					action_0(num2);
					smethod_3(listBox_0, num2);
				}
				finally
				{
					mainForm_0.bool_0 = false;
				}
			}
		}
	}

	[Serializable]
	private sealed class Class45
	{
		public static readonly Class45 class45_0 = new Class45();

		public static Func<CPolicyData, int> func_0;

		public static Func<CPolicyData, CPolicyData> func_1;

		public static Func<CPolicyData, bool> func_2;

		public static Func<CPolicyData, int> func_3;

		public static Func<CTriggerData, int> func_4;

		public static Func<CTriggerData, CTriggerData> func_5;

		public static Func<CTriggerData, bool> func_6;

		public static Func<CTriggerData, int> func_7;

		public static Func<IOperation, IOperation> func_8;

		public static Func<IOperation, bool> func_9;

		public static Func<ToolStripMenuItem, bool> func_10;

		internal int method_0(CPolicyData cpolicyData_0)
		{
			return cpolicyData_0.ID;
		}

		internal CPolicyData method_1(CPolicyData cpolicyData_0)
		{
			return cpolicyData_0.Clone() as CPolicyData;
		}

		internal bool method_2(CPolicyData cpolicyData_0)
		{
			return cpolicyData_0 != null;
		}

		internal int method_3(CPolicyData cpolicyData_0)
		{
			return cpolicyData_0.ID;
		}

		internal int method_4(CTriggerData ctriggerData_0)
		{
			return ctriggerData_0.ID;
		}

		internal CTriggerData method_5(CTriggerData ctriggerData_0)
		{
			return ctriggerData_0.Clone() as CTriggerData;
		}

		internal bool method_6(CTriggerData ctriggerData_0)
		{
			return ctriggerData_0 != null;
		}

		internal int method_7(CTriggerData ctriggerData_0)
		{
			return ctriggerData_0.ID;
		}

		internal IOperation method_8(IOperation ioperation_0)
		{
			return ((ioperation_0 as ICloneable)?.Clone() as IOperation) ?? ioperation_0;
		}

		internal bool method_9(IOperation ioperation_0)
		{
			return ioperation_0 != null;
		}

		internal bool method_10(ToolStripMenuItem toolStripMenuItem_0)
		{
			if (!toolStripMenuItem_0.Text.Contains(Class16.smethod_0(1648932164)))
			{
				return toolStripMenuItem_0.Name.Contains(Class16.smethod_0(1648932175));
			}
			return true;
		}
	}

	private readonly eListCollection eListCollection_0;

	private readonly ItemsWindow itemsWindow_0;

	private readonly CommonStorage commonStorage_0;

	private readonly Form form_0;

	private readonly ItemsToolTip itemsToolTip_0;

	private readonly PCK_LIST pck_LIST_0;

	public static LocalizationProvider Provider = new LocalizationProvider();

	private static int int_0 = 0;

	private AIFile aifile_0;

	private INotifyCollectionChanged inotifyCollectionChanged_0;

	private bool bool_0;

	private BindingSource bindingSource_0;

	private BindingSource bindingSource_1;

	private BindingSource bindingSource_2;

	private int int_1;

	private int int_2;

	private int int_3;

	private TooltipForm tooltipForm_0;

	private CustomData customData_0;

	private static readonly JsonSerializerSettings jsonSerializerSettings_0 = new JsonSerializerSettings
	{
		TypeNameHandling = (TypeNameHandling)4,
		TypeNameAssemblyFormatHandling = (TypeNameAssemblyFormatHandling)0,
		NullValueHandling = (NullValueHandling)1,
		Formatting = (Formatting)1
	};

	private IContainer icontainer_0;

	private MenuStrip menuStrip_0;

	private ToolStripMenuItem toolStripMenuItem_0;

	private ToolStripMenuItem toolStripMenuItem_1;

	private ToolStripMenuItem toolStripMenuItem_2;

	private ToolStripMenuItem toolStripMenuItem_3;

	private ToolStripMenuItem toolStripMenuItem_4;

	private ToolStripMenuItem toolStripMenuItem_5;

	private ToolStripMenuItem toolStripMenuItem_6;

	private ToolStripMenuItem toolStripMenuItem_7;

	private SplitContainer splitContainer_0;

	private SplitContainer splitContainer_1;

	private GroupBox groupBox_0;

	private ListBox listBox_0;

	private Label label_0;

	private NumericUpDown numericUpDown_0;

	private ConditionControl conditionControl_0;

	private Label label_1;

	private TextBox textBox_0;

	private Label label_2;

	private NumericUpDown numericUpDown_1;

	private Label label_3;

	private NumericUpDown numericUpDown_2;

	private CheckBox checkBox_0;

	private CheckBox checkBox_1;

	private CheckBox checkBox_2;

	private SplitContainer splitContainer_2;

	private GroupBox groupBox_1;

	private ListBox listBox_1;

	private GroupBox groupBox_2;

	private SplitContainer splitContainer_3;

	private ListBox listBox_2;

	private PropertyGrid propertyGrid_0;

	private FileBasedUndoManager fileBasedUndoManager_0;

	private bool bool_1;

	public static int ConditionType
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

	public AIFile Aipolicy
	{
		[CompilerGenerated]
		get
		{
			return aifile_0;
		}
		[CompilerGenerated]
		set
		{
			aifile_0 = value;
		}
	}

	internal eListCollection Elements => eListCollection_0;

	internal ItemsWindow ItemsWindow1 => itemsWindow_0;

	internal CommonStorage CStorage => commonStorage_0;

	public MainForm(eListCollection eLC, ItemsWindow ItemsWindow1, CommonStorage CStorage, Form ElementsWindow, ItemsToolTip ItemsToolTip1, PCK_LIST PCKs)
	{
		eListCollection_0 = eLC;
		itemsWindow_0 = ItemsWindow1;
		commonStorage_0 = CStorage;
		form_0 = ElementsWindow;
		itemsToolTip_0 = ItemsToolTip1;
		pck_LIST_0 = PCKs;
		DataFiles.Elements = eListCollection_0;
		HINTS.CStorage = commonStorage_0;
		HINTS.ToolTipWindow = itemsToolTip_0;
		TASKS_HINT.CStorage = commonStorage_0;
		TASKS_HINT.ToolTipWindow = itemsToolTip_0;
		ItemsToolTip.CStorage = commonStorage_0;
		ItemsToolTip.eLC = eListCollection_0;
		ItemsToolTip.ElementsWindow = form_0;
		if (itemsWindow_0 != null)
		{
			itemsWindow_0.eLC = eListCollection_0;
		}
		if (eListCollection_0 == null || commonStorage_0 == null || itemsToolTip_0 == null || form_0 == null)
		{
			throw new InvalidOperationException(Class16.smethod_0(1648932178));
		}
		method_9();
		TDark.StoreOriginalColors(this);
		TDark.ApplyTheme(this);
		method_3();
		method_4();
		TDark.ApplyTheme(this);
		TextStorage.TEXTS.SetFormLanguage(this);
		method_5();
		method_10();
		method_6();
		method_7();
		tooltipForm_0 = new TooltipForm(eListCollection_0, itemsToolTip_0);
		customData_0 = new CustomData(eListCollection_0);
	}

	private static string smethod_0()
	{
		string text = TextStorage.TEXTS?.CurrentLocaleCode;
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return Class16.smethod_0(1648931959);
	}

	private void method_0(AIFile aifile_1)
	{
		if (Aipolicy == aifile_1)
		{
			if (Aipolicy != null)
			{
				Aipolicy.InAnotherThread = false;
			}
			return;
		}
		if (Aipolicy != null)
		{
			Aipolicy.PropertyChanged -= method_46;
		}
		Aipolicy = aifile_1 ?? new AIFile();
		Aipolicy.InAnotherThread = false;
		Aipolicy.PropertyChanged += method_46;
		DataFiles.AIPolicy = Aipolicy;
	}

	public bool EnsureAIPolicyLoaded(string path)
	{
		if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
		{
			try
			{
				AIFile aIPolicy = DataFiles.AIPolicy;
				if (aIPolicy != null && Aipolicy != aIPolicy)
				{
					method_0(aIPolicy);
					method_45();
				}
				else if (Aipolicy == null)
				{
					method_0(aIPolicy ?? new AIFile());
					method_45();
				}
				if (!string.Equals(Aipolicy.FilePath, path, StringComparison.OrdinalIgnoreCase) || Aipolicy.Controllers == null || Aipolicy.Controllers.Count == 0)
				{
					Aipolicy.Read(path);
					DataFiles.AIPolicy = Aipolicy;
					method_45();
				}
			}
			catch (Exception ex)
			{
				if (Aipolicy != null)
				{
					Aipolicy.Controllers = new ObservableCollection<CPolicyData>();
					Aipolicy.Header = 0u;
					Aipolicy.OnPropertyChanged(Class16.smethod_0(1648939437));
				}
				DataFiles.AIPolicy = null;
				SentryHelper.CaptureException(ex, Class16.smethod_0(1648932237));
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648932279), Class16.smethod_0(1648932299)), TextStorage.Msg(Class16.smethod_0(1648932328), Class16.smethod_0(1648931330)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}
		return false;
	}

	public bool TrySelectControllerById(int controllerId)
	{
		if (Aipolicy == null)
		{
			return false;
		}
		int num = Aipolicy.FindControllerIndexById(controllerId);
		if (num < 0)
		{
			return false;
		}
		method_42(num, -1, -1);
		method_39(num, bool_2: false);
		return true;
	}

	public bool NavigateToController(string path, int controllerId)
	{
		if (!EnsureAIPolicyLoaded(path))
		{
			return false;
		}
		return TrySelectControllerById(controllerId);
	}

	private static int smethod_1(ListBox listBox_3)
	{
		if (listBox_3 != null && !listBox_3.IsDisposed)
		{
			try
			{
				return listBox_3.Items.Count;
			}
			catch (Exception ex) when (((ex is ArgumentOutOfRangeException || ex is IndexOutOfRangeException || ex is InvalidOperationException) ? 1 : 0) != 0)
			{
				return 0;
			}
		}
		return 0;
	}

	private static int smethod_2(ListBox listBox_3)
	{
		if (listBox_3 != null && !listBox_3.IsDisposed)
		{
			try
			{
				return listBox_3.SelectedIndex;
			}
			catch (Exception ex) when (((ex is ArgumentOutOfRangeException || ex is IndexOutOfRangeException || ex is InvalidOperationException) ? 1 : 0) != 0)
			{
				return -1;
			}
		}
		return -1;
	}

	private static void smethod_3(ListBox listBox_3, int int_4)
	{
		int num = smethod_1(listBox_3);
		if (num == 0)
		{
			return;
		}
		int selectedIndex = ((int_4 < 0) ? (-1) : Math.Min(int_4, num - 1));
		try
		{
			listBox_3.SelectedIndex = selectedIndex;
		}
		catch (Exception ex) when (((ex is ArgumentOutOfRangeException || ex is IndexOutOfRangeException || ex is InvalidOperationException) ? 1 : 0) != 0)
		{
		}
	}

	private static void smethod_4(ListBox listBox_3, int int_4, bool bool_2)
	{
		int num = smethod_1(listBox_3);
		if (num != 0 && int_4 >= 0 && int_4 < num)
		{
			try
			{
				listBox_3.TopIndex = int_4;
			}
			catch (Exception ex) when (((ex is ArgumentOutOfRangeException || ex is IndexOutOfRangeException || ex is InvalidOperationException) ? 1 : 0) != 0)
			{
				return;
			}
			if (bool_2)
			{
				smethod_3(listBox_3, int_4);
			}
		}
	}

	private void method_1(ListBox listBox_3, int int_4, Action<int> action_0, Func<int> func_0, int int_5)
	{
		Class44 @class = new Class44();
		@class.mainForm_0 = this;
		@class.listBox_0 = listBox_3;
		@class.int_0 = int_5;
		@class.func_0 = func_0;
		@class.int_1 = int_4;
		@class.action_0 = action_0;
		if (@class.listBox_0 != null && !@class.listBox_0.IsDisposed && !base.IsDisposed && base.IsHandleCreated)
		{
			BeginInvoke(new Action(@class.method_0));
		}
	}

	private void method_2(ListBox listBox_3, int int_4, bool bool_2, Func<int> func_0, int int_5)
	{
		Class40 @class = new Class40();
		@class.mainForm_0 = this;
		@class.listBox_0 = listBox_3;
		@class.int_0 = int_5;
		@class.func_0 = func_0;
		@class.int_1 = int_4;
		@class.bool_0 = bool_2;
		if (@class.listBox_0 != null && !@class.listBox_0.IsDisposed && !base.IsDisposed && base.IsHandleCreated)
		{
			BeginInvoke(new Action(@class.method_0));
		}
	}

	private void method_3()
	{
		bindingSource_0 = new BindingSource();
		bindingSource_1 = new BindingSource();
		bindingSource_2 = new BindingSource();
		listBox_0.DataSource = bindingSource_0;
		listBox_1.DataSource = bindingSource_1;
		listBox_2.DataSource = bindingSource_2;
	}

	private void method_4()
	{
		string localizedString = Provider.GetLocalizedString(Class16.smethod_0(1648931357));
		string localizedString2 = Provider.GetLocalizedString(Class16.smethod_0(1648931361));
		string localizedString3 = Provider.GetLocalizedString(Class16.smethod_0(1648931371));
		string localizedString4 = Provider.GetLocalizedString(Class16.smethod_0(1648931384));
		string localizedString5 = Provider.GetLocalizedString(Class16.smethod_0(1648931405));
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		contextMenuStrip.Items.Add(localizedString, null, method_17);
		contextMenuStrip.Items.Add(localizedString2, null, method_16);
		contextMenuStrip.Items.Add(localizedString3, null, method_22);
		contextMenuStrip.Items.Add(new ToolStripSeparator());
		contextMenuStrip.Items.Add(localizedString4, null, method_20);
		contextMenuStrip.Items.Add(localizedString5, null, method_21);
		smethod_5(listBox_0, contextMenuStrip);
		ContextMenuStrip contextMenuStrip2 = new ContextMenuStrip();
		contextMenuStrip2.Items.Add(localizedString, null, method_24);
		contextMenuStrip2.Items.Add(localizedString2, null, method_23);
		contextMenuStrip2.Items.Add(localizedString3, null, method_27);
		contextMenuStrip2.Items.Add(new ToolStripSeparator());
		contextMenuStrip2.Items.Add(localizedString4, null, method_25);
		contextMenuStrip2.Items.Add(localizedString5, null, method_26);
		smethod_5(listBox_1, contextMenuStrip2);
		ContextMenuStrip contextMenuStrip3 = new ContextMenuStrip();
		contextMenuStrip3.Items.Add(localizedString, null, method_31);
		contextMenuStrip3.Items.Add(localizedString2, null, method_30);
		contextMenuStrip3.Items.Add(localizedString3, null, method_35);
		contextMenuStrip3.Items.Add(new ToolStripSeparator());
		contextMenuStrip3.Items.Add(localizedString4, null, method_32);
		contextMenuStrip3.Items.Add(localizedString5, null, method_33);
		smethod_5(listBox_2, contextMenuStrip3);
	}

	private static void smethod_5(ListBox listBox_3, ContextMenuStrip contextMenuStrip_0)
	{
		ContextMenuStrip contextMenuStrip = listBox_3.ContextMenuStrip;
		listBox_3.ContextMenuStrip = contextMenuStrip_0;
		if (contextMenuStrip != null && contextMenuStrip != contextMenuStrip_0)
		{
			contextMenuStrip.Dispose();
		}
	}

	private void method_5()
	{
		numericUpDown_0.ValueChanged += numericUpDown_0_ValueChanged;
		numericUpDown_1.ValueChanged += numericUpDown_1_ValueChanged;
		numericUpDown_2.ValueChanged += numericUpDown_2_ValueChanged;
		textBox_0.TextChanged += textBox_0_TextChanged;
		textBox_0.Leave += textBox_0_Leave;
	}

	private void method_6()
	{
		conditionControl_0.Anchor = AnchorStyles.Top;
		splitContainer_1.Panel1.Resize += method_51;
		method_29();
	}

	private void method_7()
	{
		listBox_0.KeyDown += listBox_2_KeyDown;
		listBox_1.KeyDown += listBox_2_KeyDown;
		listBox_2.KeyDown += listBox_2_KeyDown;
	}

	private void method_8(ListBox listBox_3)
	{
		if (listBox_3.Items.Count == 0)
		{
			return;
		}
		bool_0 = true;
		listBox_3.BeginUpdate();
		try
		{
			for (int i = 0; i < listBox_3.Items.Count; i++)
			{
				listBox_3.SetSelected(i, value: true);
			}
		}
		finally
		{
			listBox_3.EndUpdate();
			bool_0 = false;
		}
	}

	private void listBox_2_KeyDown(object sender, KeyEventArgs e)
	{
		if (!(sender is ListBox listBox_))
		{
			return;
		}
		if (e.Control && e.KeyCode == Keys.A)
		{
			e.Handled = true;
			e.SuppressKeyPress = true;
			method_8(listBox_);
		}
		else if (e.KeyCode == Keys.Right)
		{
			e.Handled = true;
			if (sender == listBox_0)
			{
				listBox_1.Focus();
				if (listBox_1.Items.Count > 0 && listBox_1.SelectedIndex < 0)
				{
					listBox_1.SelectedIndex = 0;
				}
			}
			else if (sender == listBox_1)
			{
				listBox_2.Focus();
				if (listBox_2.Items.Count > 0 && listBox_2.SelectedIndex < 0)
				{
					listBox_2.SelectedIndex = 0;
				}
			}
		}
		else
		{
			if (e.KeyCode != Keys.Left)
			{
				return;
			}
			e.Handled = true;
			if (sender == listBox_2)
			{
				listBox_1.Focus();
				if (listBox_1.Items.Count > 0 && listBox_1.SelectedIndex < 0)
				{
					listBox_1.SelectedIndex = 0;
				}
			}
			else if (sender == listBox_1)
			{
				listBox_0.Focus();
				if (listBox_0.Items.Count > 0 && listBox_0.SelectedIndex < 0)
				{
					listBox_0.SelectedIndex = 0;
				}
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (Aipolicy != null)
			{
				Aipolicy.PropertyChanged -= method_46;
			}
			ContextMenuStrip contextMenuStrip = listBox_0?.ContextMenuStrip;
			ContextMenuStrip contextMenuStrip2 = listBox_1?.ContextMenuStrip;
			ContextMenuStrip contextMenuStrip3 = listBox_2?.ContextMenuStrip;
			if (listBox_0 != null)
			{
				listBox_0.ContextMenuStrip = null;
			}
			if (listBox_1 != null)
			{
				listBox_1.ContextMenuStrip = null;
			}
			if (listBox_2 != null)
			{
				listBox_2.ContextMenuStrip = null;
			}
			contextMenuStrip?.Dispose();
			contextMenuStrip2?.Dispose();
			contextMenuStrip3?.Dispose();
			tooltipForm_0?.Dispose();
			if (icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
		}
		base.Dispose(disposing);
	}

	private void method_9()
	{
		new ComponentResourceManager(typeof(MainForm));
		menuStrip_0 = new MenuStrip();
		toolStripMenuItem_0 = new ToolStripMenuItem();
		toolStripMenuItem_1 = new ToolStripMenuItem();
		toolStripMenuItem_2 = new ToolStripMenuItem();
		toolStripMenuItem_3 = new ToolStripMenuItem();
		toolStripMenuItem_4 = new ToolStripMenuItem();
		toolStripMenuItem_5 = new ToolStripMenuItem();
		toolStripMenuItem_6 = new ToolStripMenuItem();
		toolStripMenuItem_7 = new ToolStripMenuItem();
		splitContainer_0 = new SplitContainer();
		groupBox_0 = new GroupBox();
		listBox_0 = new ListBox();
		label_0 = new Label();
		numericUpDown_0 = new NumericUpDown();
		splitContainer_1 = new SplitContainer();
		conditionControl_0 = new ConditionControl();
		label_1 = new Label();
		textBox_0 = new TextBox();
		label_2 = new Label();
		numericUpDown_1 = new NumericUpDown();
		label_3 = new Label();
		numericUpDown_2 = new NumericUpDown();
		checkBox_0 = new CheckBox();
		checkBox_1 = new CheckBox();
		checkBox_2 = new CheckBox();
		splitContainer_2 = new SplitContainer();
		groupBox_1 = new GroupBox();
		listBox_1 = new ListBox();
		groupBox_2 = new GroupBox();
		splitContainer_3 = new SplitContainer();
		listBox_2 = new ListBox();
		propertyGrid_0 = new PropertyGrid();
		menuStrip_0.SuspendLayout();
		((ISupportInitialize)splitContainer_0).BeginInit();
		splitContainer_0.Panel1.SuspendLayout();
		splitContainer_0.Panel2.SuspendLayout();
		splitContainer_0.SuspendLayout();
		groupBox_0.SuspendLayout();
		((ISupportInitialize)numericUpDown_0).BeginInit();
		((ISupportInitialize)splitContainer_1).BeginInit();
		splitContainer_1.Panel1.SuspendLayout();
		splitContainer_1.Panel2.SuspendLayout();
		splitContainer_1.SuspendLayout();
		((ISupportInitialize)numericUpDown_1).BeginInit();
		((ISupportInitialize)numericUpDown_2).BeginInit();
		((ISupportInitialize)splitContainer_2).BeginInit();
		splitContainer_2.Panel1.SuspendLayout();
		splitContainer_2.Panel2.SuspendLayout();
		splitContainer_2.SuspendLayout();
		groupBox_1.SuspendLayout();
		groupBox_2.SuspendLayout();
		((ISupportInitialize)splitContainer_3).BeginInit();
		splitContainer_3.Panel1.SuspendLayout();
		splitContainer_3.Panel2.SuspendLayout();
		splitContainer_3.SuspendLayout();
		SuspendLayout();
		menuStrip_0.BackColor = SystemColors.InactiveBorder;
		menuStrip_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		menuStrip_0.Items.AddRange(new ToolStripItem[3] { toolStripMenuItem_0, toolStripMenuItem_4, toolStripMenuItem_6 });
		menuStrip_0.Location = new Point(0, 0);
		menuStrip_0.Name = Class16.smethod_0(1648931410);
		menuStrip_0.Size = new Size(981, 24);
		menuStrip_0.TabIndex = 0;
		menuStrip_0.Text = Class16.smethod_0(1648931410);
		toolStripMenuItem_0.DropDownItems.AddRange(new ToolStripItem[3] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripMenuItem_3 });
		toolStripMenuItem_0.Name = Class16.smethod_0(1648931427);
		toolStripMenuItem_0.Size = new Size(37, 20);
		toolStripMenuItem_0.Text = Class16.smethod_0(1648931458);
		toolStripMenuItem_1.Name = Class16.smethod_0(1648931477);
		toolStripMenuItem_1.Size = new Size(114, 22);
		toolStripMenuItem_1.Text = Class16.smethod_0(1648931498);
		toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
		toolStripMenuItem_2.Name = Class16.smethod_0(1648931517);
		toolStripMenuItem_2.Size = new Size(114, 22);
		toolStripMenuItem_2.Text = Class16.smethod_0(1648941761);
		toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
		toolStripMenuItem_3.Name = Class16.smethod_0(1648931539);
		toolStripMenuItem_3.Size = new Size(114, 22);
		toolStripMenuItem_3.Text = Class16.smethod_0(1648931581);
		toolStripMenuItem_3.Click += toolStripMenuItem_3_Click;
		toolStripMenuItem_4.DropDownItems.AddRange(new ToolStripItem[1] { toolStripMenuItem_5 });
		toolStripMenuItem_4.Name = Class16.smethod_0(1648931587);
		toolStripMenuItem_4.Size = new Size(39, 20);
		toolStripMenuItem_4.Text = Class16.smethod_0(1648932164);
		toolStripMenuItem_5.Name = Class16.smethod_0(1648931617);
		toolStripMenuItem_5.Size = new Size(109, 22);
		toolStripMenuItem_5.Text = Class16.smethod_0(1648931650);
		toolStripMenuItem_5.Click += toolStripMenuItem_5_Click;
		toolStripMenuItem_6.DropDownItems.AddRange(new ToolStripItem[1] { toolStripMenuItem_7 });
		toolStripMenuItem_6.Name = Class16.smethod_0(1648931671);
		toolStripMenuItem_6.Size = new Size(44, 20);
		toolStripMenuItem_6.Text = Class16.smethod_0(1648931701);
		toolStripMenuItem_7.Name = Class16.smethod_0(1648931704);
		toolStripMenuItem_7.Size = new Size(102, 22);
		toolStripMenuItem_7.Text = Class16.smethod_0(1648931739);
		toolStripMenuItem_7.Click += toolStripMenuItem_7_Click;
		splitContainer_0.Dock = DockStyle.Fill;
		splitContainer_0.Location = new Point(0, 24);
		splitContainer_0.Name = Class16.smethod_0(1648931759);
		splitContainer_0.Panel1.Controls.Add(groupBox_0);
		splitContainer_0.Panel2.Controls.Add(splitContainer_1);
		splitContainer_0.Size = new Size(981, 576);
		splitContainer_0.SplitterDistance = 230;
		splitContainer_0.TabIndex = 1;
		groupBox_0.Controls.Add(listBox_0);
		groupBox_0.Controls.Add(label_0);
		groupBox_0.Controls.Add(numericUpDown_0);
		groupBox_0.Dock = DockStyle.Fill;
		groupBox_0.Location = new Point(0, 0);
		groupBox_0.Name = Class16.smethod_0(1648931781);
		groupBox_0.Size = new Size(230, 576);
		groupBox_0.TabIndex = 0;
		groupBox_0.TabStop = false;
		groupBox_0.Text = Class16.smethod_0(1648931807);
		listBox_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		listBox_0.BackColor = SystemColors.Window;
		listBox_0.BorderStyle = BorderStyle.None;
		listBox_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		listBox_0.ForeColor = SystemColors.WindowText;
		listBox_0.FormattingEnabled = true;
		listBox_0.IntegralHeight = false;
		listBox_0.ItemHeight = 15;
		listBox_0.Location = new Point(6, 19);
		listBox_0.Name = Class16.smethod_0(1648931823);
		listBox_0.SelectionMode = SelectionMode.MultiExtended;
		listBox_0.Size = new Size(218, 498);
		listBox_0.TabIndex = 0;
		listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
		label_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_0.AutoSize = true;
		label_0.Location = new Point(8, 525);
		label_0.Name = Class16.smethod_0(1648930816);
		label_0.Size = new Size(21, 15);
		label_0.TabIndex = 1;
		label_0.Text = Class16.smethod_0(1648930840);
		numericUpDown_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		numericUpDown_0.Location = new Point(8, 541);
		numericUpDown_0.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_0.Name = Class16.smethod_0(1648930850);
		numericUpDown_0.Size = new Size(218, 23);
		numericUpDown_0.TabIndex = 2;
		splitContainer_1.Dock = DockStyle.Fill;
		splitContainer_1.Location = new Point(0, 0);
		splitContainer_1.Name = Class16.smethod_0(1648930884);
		splitContainer_1.Orientation = Orientation.Horizontal;
		splitContainer_1.Panel1.Controls.Add(conditionControl_0);
		splitContainer_1.Panel1.Controls.Add(label_1);
		splitContainer_1.Panel1.Controls.Add(textBox_0);
		splitContainer_1.Panel1.Controls.Add(label_2);
		splitContainer_1.Panel1.Controls.Add(numericUpDown_1);
		splitContainer_1.Panel1.Controls.Add(label_3);
		splitContainer_1.Panel1.Controls.Add(numericUpDown_2);
		splitContainer_1.Panel1.Controls.Add(checkBox_0);
		splitContainer_1.Panel1.Controls.Add(checkBox_1);
		splitContainer_1.Panel1.Controls.Add(checkBox_2);
		splitContainer_1.Panel2.Controls.Add(splitContainer_2);
		splitContainer_1.Size = new Size(747, 576);
		splitContainer_1.SplitterDistance = 170;
		splitContainer_1.TabIndex = 0;
		conditionControl_0.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		conditionControl_0.BackColor = SystemColors.Control;
		conditionControl_0.Cond = null;
		conditionControl_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		conditionControl_0.Location = new Point(10, 5);
		conditionControl_0.MinimumSize = new Size(600, 44);
		conditionControl_0.Name = Class16.smethod_0(1648930898);
		conditionControl_0.Padding = new Padding(4);
		conditionControl_0.Size = new Size(727, 300);
		conditionControl_0.TabIndex = 0;
		label_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_1.AutoSize = true;
		label_1.Location = new Point(124, 120);
		label_1.Name = Class16.smethod_0(1648930921);
		label_1.Size = new Size(42, 15);
		label_1.TabIndex = 1;
		label_1.Text = Class16.smethod_0(1648930944);
		textBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		textBox_0.BackColor = SystemColors.Window;
		textBox_0.BorderStyle = BorderStyle.FixedSingle;
		textBox_0.ForeColor = SystemColors.WindowText;
		textBox_0.Location = new Point(124, 138);
		textBox_0.Name = Class16.smethod_0(1648930964);
		textBox_0.Size = new Size(220, 23);
		textBox_0.TabIndex = 2;
		label_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_2.AutoSize = true;
		label_2.Location = new Point(12, 120);
		label_2.Name = Class16.smethod_0(1648930989);
		label_2.Size = new Size(21, 15);
		label_2.TabIndex = 3;
		label_2.Text = Class16.smethod_0(1648930840);
		numericUpDown_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_1.BackColor = SystemColors.Window;
		numericUpDown_1.ForeColor = SystemColors.WindowText;
		numericUpDown_1.Location = new Point(12, 138);
		numericUpDown_1.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_1.Name = Class16.smethod_0(1648931002);
		numericUpDown_1.Size = new Size(100, 23);
		numericUpDown_1.TabIndex = 4;
		label_3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		label_3.AutoSize = true;
		label_3.Location = new Point(356, 120);
		label_3.Name = Class16.smethod_0(1648931025);
		label_3.Size = new Size(48, 15);
		label_3.TabIndex = 5;
		label_3.Text = Class16.smethod_0(1648931051);
		numericUpDown_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		numericUpDown_2.BackColor = SystemColors.Window;
		numericUpDown_2.ForeColor = SystemColors.WindowText;
		numericUpDown_2.Location = new Point(356, 138);
		numericUpDown_2.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		numericUpDown_2.Name = Class16.smethod_0(1648931066);
		numericUpDown_2.Size = new Size(80, 23);
		numericUpDown_2.TabIndex = 6;
		checkBox_0.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		checkBox_0.Appearance = Appearance.Button;
		checkBox_0.FlatStyle = FlatStyle.Flat;
		checkBox_0.Location = new Point(448, 132);
		checkBox_0.Name = Class16.smethod_0(1648931102);
		checkBox_0.Size = new Size(90, 30);
		checkBox_0.TabIndex = 7;
		checkBox_0.Text = Class16.smethod_0(1648931127);
		checkBox_0.TextAlign = ContentAlignment.MiddleCenter;
		checkBox_0.UseVisualStyleBackColor = false;
		checkBox_1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		checkBox_1.Appearance = Appearance.Button;
		checkBox_1.FlatStyle = FlatStyle.Flat;
		checkBox_1.Location = new Point(546, 132);
		checkBox_1.Name = Class16.smethod_0(1648931137);
		checkBox_1.Size = new Size(90, 30);
		checkBox_1.TabIndex = 8;
		checkBox_1.Text = Class16.smethod_0(1648931167);
		checkBox_1.TextAlign = ContentAlignment.MiddleCenter;
		checkBox_1.UseVisualStyleBackColor = false;
		checkBox_2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
		checkBox_2.Appearance = Appearance.Button;
		checkBox_2.FlatStyle = FlatStyle.Flat;
		checkBox_2.Location = new Point(644, 132);
		checkBox_2.Name = Class16.smethod_0(1648931182);
		checkBox_2.Size = new Size(100, 30);
		checkBox_2.TabIndex = 9;
		checkBox_2.Text = Class16.smethod_0(1648931212);
		checkBox_2.TextAlign = ContentAlignment.MiddleCenter;
		checkBox_2.UseVisualStyleBackColor = false;
		splitContainer_2.Dock = DockStyle.Fill;
		splitContainer_2.Location = new Point(0, 0);
		splitContainer_2.Name = Class16.smethod_0(1648931230);
		splitContainer_2.Panel1.Controls.Add(groupBox_1);
		splitContainer_2.Panel2.Controls.Add(groupBox_2);
		splitContainer_2.Size = new Size(747, 402);
		splitContainer_2.SplitterDistance = 230;
		splitContainer_2.TabIndex = 0;
		groupBox_1.Controls.Add(listBox_1);
		groupBox_1.Dock = DockStyle.Fill;
		groupBox_1.Location = new Point(0, 0);
		groupBox_1.Name = Class16.smethod_0(1648931252);
		groupBox_1.Size = new Size(230, 402);
		groupBox_1.TabIndex = 0;
		groupBox_1.TabStop = false;
		groupBox_1.Text = Class16.smethod_0(1648942688);
		listBox_1.BackColor = SystemColors.Window;
		listBox_1.BorderStyle = BorderStyle.None;
		listBox_1.Dock = DockStyle.Fill;
		listBox_1.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold);
		listBox_1.ForeColor = SystemColors.WindowText;
		listBox_1.FormattingEnabled = true;
		listBox_1.IntegralHeight = false;
		listBox_1.ItemHeight = 17;
		listBox_1.Location = new Point(3, 19);
		listBox_1.Name = Class16.smethod_0(1648931267);
		listBox_1.SelectionMode = SelectionMode.MultiExtended;
		listBox_1.Size = new Size(224, 380);
		listBox_1.TabIndex = 0;
		listBox_1.SelectedIndexChanged += listBox_1_SelectedIndexChanged;
		groupBox_2.Controls.Add(splitContainer_3);
		groupBox_2.Dock = DockStyle.Fill;
		groupBox_2.Location = new Point(0, 0);
		groupBox_2.Name = Class16.smethod_0(1648931289);
		groupBox_2.Size = new Size(513, 402);
		groupBox_2.TabIndex = 1;
		groupBox_2.TabStop = false;
		groupBox_2.Text = Class16.smethod_0(1648942657);
		splitContainer_3.Dock = DockStyle.Fill;
		splitContainer_3.Location = new Point(3, 19);
		splitContainer_3.Name = Class16.smethod_0(1648931314);
		splitContainer_3.Panel1.Controls.Add(listBox_2);
		splitContainer_3.Panel2.Controls.Add(propertyGrid_0);
		splitContainer_3.Size = new Size(507, 380);
		splitContainer_3.SplitterDistance = 178;
		splitContainer_3.TabIndex = 0;
		listBox_2.BackColor = SystemColors.Window;
		listBox_2.BorderStyle = BorderStyle.None;
		listBox_2.Dock = DockStyle.Fill;
		listBox_2.Font = new Font(Class16.smethod_0(1648942905), 9.75f, FontStyle.Bold);
		listBox_2.ForeColor = SystemColors.WindowText;
		listBox_2.FormattingEnabled = true;
		listBox_2.IntegralHeight = false;
		listBox_2.ItemHeight = 17;
		listBox_2.Location = new Point(0, 0);
		listBox_2.Name = Class16.smethod_0(1648934408);
		listBox_2.SelectionMode = SelectionMode.MultiExtended;
		listBox_2.Size = new Size(178, 380);
		listBox_2.TabIndex = 0;
		listBox_2.SelectedIndexChanged += listBox_2_SelectedIndexChanged;
		propertyGrid_0.CategoryForeColor = SystemColors.ControlText;
		propertyGrid_0.CommandsBackColor = SystemColors.Control;
		propertyGrid_0.CommandsForeColor = SystemColors.ControlText;
		propertyGrid_0.Dock = DockStyle.Fill;
		propertyGrid_0.Font = new Font(Class16.smethod_0(1648942905), 9f);
		propertyGrid_0.HelpBackColor = SystemColors.Control;
		propertyGrid_0.HelpForeColor = SystemColors.ControlText;
		propertyGrid_0.HelpVisible = false;
		propertyGrid_0.LineColor = SystemColors.InactiveBorder;
		propertyGrid_0.Location = new Point(0, 0);
		propertyGrid_0.Name = Class16.smethod_0(1648934432);
		propertyGrid_0.Size = new Size(325, 380);
		propertyGrid_0.TabIndex = 0;
		propertyGrid_0.ViewBackColor = SystemColors.Window;
		propertyGrid_0.ViewForeColor = SystemColors.WindowText;
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		BackColor = Color.FromArgb(239, 244, 250);
		base.ClientSize = new Size(981, 600);
		base.Controls.Add(splitContainer_0);
		base.Controls.Add(menuStrip_0);
		Font = new Font(Class16.smethod_0(1648942905), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
		base.Icon = Resources.PerfectAIEditor;
		base.MainMenuStrip = menuStrip_0;
		base.Name = Class16.smethod_0(1648934468);
		base.StartPosition = FormStartPosition.CenterScreen;
		Text = Class16.smethod_0(1648934475);
		base.Load += MainForm_Load;
		base.Activated += MainForm_Activated;
		menuStrip_0.ResumeLayout(performLayout: false);
		menuStrip_0.PerformLayout();
		splitContainer_0.Panel1.ResumeLayout(performLayout: false);
		splitContainer_0.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_0).EndInit();
		splitContainer_0.ResumeLayout(performLayout: false);
		groupBox_0.ResumeLayout(performLayout: false);
		groupBox_0.PerformLayout();
		((ISupportInitialize)numericUpDown_0).EndInit();
		splitContainer_1.Panel1.ResumeLayout(performLayout: false);
		splitContainer_1.Panel1.PerformLayout();
		splitContainer_1.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_1).EndInit();
		splitContainer_1.ResumeLayout(performLayout: false);
		((ISupportInitialize)numericUpDown_1).EndInit();
		((ISupportInitialize)numericUpDown_2).EndInit();
		splitContainer_2.Panel1.ResumeLayout(performLayout: false);
		splitContainer_2.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_2).EndInit();
		splitContainer_2.ResumeLayout(performLayout: false);
		groupBox_1.ResumeLayout(performLayout: false);
		groupBox_2.ResumeLayout(performLayout: false);
		splitContainer_3.Panel1.ResumeLayout(performLayout: false);
		splitContainer_3.Panel2.ResumeLayout(performLayout: false);
		((ISupportInitialize)splitContainer_3).EndInit();
		splitContainer_3.ResumeLayout(performLayout: false);
		ResumeLayout(performLayout: false);
		PerformLayout();
	}

	private void method_10()
	{
		method_11(checkBox_0);
		method_11(checkBox_1);
		method_11(checkBox_2);
		method_14();
	}

	private void method_11(CheckBox checkBox_3)
	{
		checkBox_3.Appearance = Appearance.Button;
		checkBox_3.FlatStyle = FlatStyle.Flat;
		checkBox_3.FlatAppearance.BorderSize = 0;
		checkBox_3.FlatAppearance.CheckedBackColor = Color.Transparent;
		checkBox_3.FlatAppearance.MouseDownBackColor = Color.Transparent;
		checkBox_3.FlatAppearance.MouseOverBackColor = Color.Transparent;
		checkBox_3.UseVisualStyleBackColor = false;
		checkBox_3.Cursor = Cursors.Hand;
		checkBox_3.Paint += method_12;
	}

	private void method_12(object sender, PaintEventArgs e)
	{
		CheckBox checkBox = (CheckBox)sender;
		e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		e.Graphics.Clear(checkBox.Parent.BackColor);
		Rectangle rectangle = new Rectangle(0, 0, checkBox.Width - 1, checkBox.Height - 1);
		int num = rectangle.Height - 1;
		Color color = (checkBox.Checked ? Color.FromArgb(0, 122, 204) : Color.FromArgb(60, 63, 65));
		GraphicsPath graphicsPath = new GraphicsPath();
		try
		{
			graphicsPath.AddArc(rectangle.X, rectangle.Y, num, num, 180f, 90f);
			graphicsPath.AddArc(rectangle.Right - num, rectangle.Y, num, num, 270f, 90f);
			graphicsPath.AddArc(rectangle.Right - num, rectangle.Bottom - num, num, num, 0f, 90f);
			graphicsPath.AddArc(rectangle.X, rectangle.Bottom - num, num, num, 90f, 90f);
			graphicsPath.CloseFigure();
			SolidBrush solidBrush = new SolidBrush(color);
			try
			{
				e.Graphics.FillPath(solidBrush, graphicsPath);
			}
			finally
			{
				((IDisposable)solidBrush).Dispose();
			}
		}
		finally
		{
			((IDisposable)graphicsPath).Dispose();
		}
		int num2 = rectangle.Height - 8;
		int num3 = (checkBox.Checked ? (rectangle.Right - num2 - 4) : (rectangle.X + 4));
		SolidBrush solidBrush2 = new SolidBrush(Color.White);
		try
		{
			e.Graphics.FillEllipse(solidBrush2, num3, rectangle.Y + 4, num2, num2);
		}
		finally
		{
			((IDisposable)solidBrush2).Dispose();
		}
		Rectangle bounds = new Rectangle(checkBox.Checked ? 8 : (num2 + 8), 0, checkBox.Width - num2 - 16, checkBox.Height);
		TextRenderer.DrawText(e.Graphics, checkBox.Text, new Font(Class16.smethod_0(1648934511), 8.5f, FontStyle.Bold), bounds, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
	}

	private void method_13(CheckBox checkBox_3, string string_0)
	{
		checkBox_3.Text = string_0;
		checkBox_3.Invalidate();
	}

	private void method_14()
	{
		string localizedString = Provider.GetLocalizedString(Class16.smethod_0(1648936822));
		string localizedString2 = Provider.GetLocalizedString(Class16.smethod_0(1648936827));
		string localizedString3 = Provider.GetLocalizedString(Class16.smethod_0(1648936845));
		method_13(checkBox_0, localizedString);
		method_13(checkBox_1, localizedString2);
		method_13(checkBox_2, localizedString3);
	}

	private void textBox_0_TextChanged(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentTrigger != null)
		{
			Aipolicy.CurrentTrigger.Name = textBox_0.Text;
		}
	}

	private void textBox_0_Leave(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentTrigger != null)
		{
			Aipolicy.CurrentTrigger.Name = textBox_0.Text;
			bindingSource_1?.ResetCurrentItem();
			listBox_1.Refresh();
		}
		method_29();
	}

	private void numericUpDown_0_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentController != null)
		{
			Aipolicy.CurrentController.ID = (int)numericUpDown_0.Value;
			bindingSource_0?.ResetCurrentItem();
			listBox_0.Refresh();
		}
	}

	private void numericUpDown_1_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentTrigger != null)
		{
			Aipolicy.CurrentTrigger.ID = (int)numericUpDown_1.Value;
			bindingSource_1?.ResetCurrentItem();
			listBox_1.Refresh();
		}
	}

	private void numericUpDown_2_ValueChanged(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentTrigger != null)
		{
			Aipolicy.CurrentTrigger.Version = (int)numericUpDown_2.Value;
		}
	}

	private void MainForm_Load(object sender, EventArgs e)
	{
		try
		{
			Provider.ChangeLanguage(smethod_0());
			method_0(DataFiles.AIPolicy ?? new AIFile());
			method_15();
			conditionControl_0.IsCentral = true;
			method_48();
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648934535));
			string text = Class16.smethod_0(1648934564) + ex.Message + Class16.smethod_0(1648934582) + ex.StackTrace + Class16.smethod_0(1648934604);
			foreach (DictionaryEntry datum in ex.Data)
			{
				text += string.Format(Class16.smethod_0(1648934622), datum.Key, datum.Value);
			}
			DKBox.Show(text, Class16.smethod_0(1648934638), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void method_15()
	{
		bindingSource_0.DataSource = Aipolicy.Controllers;
		listBox_0.DisplayMember = Class16.smethod_0(1648941057);
		listBox_0.FormattingEnabled = true;
		listBox_0.Format += listBox_0_Format;
		method_43();
		listBox_1.FormattingEnabled = true;
		listBox_1.Format += listBox_1_Format;
		listBox_2.DrawMode = DrawMode.OwnerDrawFixed;
		listBox_2.DrawItem += listBox_2_DrawItem;
		checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
		checkBox_1.CheckedChanged += checkBox_1_CheckedChanged;
		checkBox_2.CheckedChanged += checkBox_2_CheckedChanged;
		conditionControl_0.Visible = false;
	}

	private void checkBox_0_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentTrigger != null)
		{
			Aipolicy.CurrentTrigger.Active = checkBox_0.Checked;
		}
		method_14();
	}

	private void checkBox_1_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentTrigger != null)
		{
			Aipolicy.CurrentTrigger.Run = checkBox_1.Checked;
		}
		method_14();
	}

	private void checkBox_2_CheckedChanged(object sender, EventArgs e)
	{
		if (!bool_0 && Aipolicy.CurrentTrigger != null)
		{
			Aipolicy.CurrentTrigger.AttackValid = checkBox_2.Checked;
		}
		method_14();
	}

	private void toolStripMenuItem_1_Click(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1648934684);
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (System.IO.Path.GetFileName(openFileDialog.FileName).Equals(Class16.smethod_0(1648934719), StringComparison.OrdinalIgnoreCase))
				{
					CommonStorage.Params.AIPolicyPath = openFileDialog.FileName;
					EnsureAIPolicyLoaded(openFileDialog.FileName);
				}
				else
				{
					DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648932279)), TextStorage.Msg(Class16.smethod_0(1648932328)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void toolStripMenuItem_2_Click(object sender, EventArgs e)
	{
		if (AceNative.IsSuccess(AceNative.IsLicenseValid()))
		{
			Aipolicy.Save();
		}
	}

	private void toolStripMenuItem_3_Click(object sender, EventArgs e)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		try
		{
			saveFileDialog.Filter = Class16.smethod_0(1648934684);
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Aipolicy.SaveAs(saveFileDialog.FileName);
				DKBox.Show(Provider.GetLocalizedString(Class16.smethod_0(1648934731)), Provider.GetLocalizedString(Class16.smethod_0(1648934747)), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		finally
		{
			((IDisposable)saveFileDialog).Dispose();
		}
	}

	private void toolStripMenuItem_5_Click(object sender, EventArgs e)
	{
		SearchForm searchForm = new SearchForm();
		searchForm.Aipolicy = Aipolicy;
		searchForm.Show();
	}

	private void toolStripMenuItem_7_Click(object sender, EventArgs e)
	{
		AdditionalForm additionalForm = new AdditionalForm();
		additionalForm.Aipolicy = Aipolicy;
		additionalForm.ShowDialog();
	}

	private void method_16(object sender, EventArgs e)
	{
		CPolicyData item = new CPolicyData
		{
			Version = CPolicyData.MaxVersion,
			ID = ((Aipolicy.Controllers.Count <= 0) ? 1 : (Aipolicy.Controllers.Last().ID + 1))
		};
		Aipolicy.Controllers.Add(item);
		method_45();
	}

	private void method_17(object sender, EventArgs e)
	{
		List<CPolicyData> list = listBox_0.SelectedItems.Cast<CPolicyData>().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int count = Aipolicy.Controllers.Count;
		foreach (CPolicyData item in list)
		{
			if (item.Clone() is CPolicyData cPolicyData)
			{
				cPolicyData.ID = ((Aipolicy.Controllers.Count <= 0) ? 1 : (((IEnumerable<CPolicyData>)Aipolicy.Controllers).Max((Func<CPolicyData, int>)Class45.class45_0.method_0) + 1));
				Aipolicy.Controllers.Add(cPolicyData);
			}
		}
		bool_0 = true;
		try
		{
			bindingSource_0.ResetBindings(metadataChanged: false);
			method_43();
			smethod_3(listBox_0, count);
			smethod_4(listBox_0, count, bool_2: false);
			Aipolicy.ControllerIndex = count;
		}
		finally
		{
			bool_0 = false;
		}
		method_18();
		method_19();
	}

	private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			int num = smethod_2(listBox_0);
			if (Aipolicy.ControllerIndex != num)
			{
				Aipolicy.ControllerIndex = num;
			}
			method_18();
			method_19();
			conditionControl_0.Visible = false;
			conditionControl_0.Cond = null;
			conditionControl_0.Reload();
		}
	}

	private void method_18()
	{
		bool_0 = true;
		try
		{
			if (Aipolicy.CurrentController != null)
			{
				numericUpDown_0.Value = Aipolicy.CurrentController.ID;
				numericUpDown_0.Enabled = true;
			}
			else
			{
				numericUpDown_0.Value = 0m;
				numericUpDown_0.Enabled = false;
			}
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void method_19()
	{
		bool_0 = true;
		try
		{
			bindingSource_1.DataSource = null;
			if (Aipolicy.CurrentTriggers != null)
			{
				bindingSource_1.DataSource = Aipolicy.CurrentTriggers;
				listBox_1.DisplayMember = Class16.smethod_0(1648934774);
				if (Aipolicy.CurrentTriggers.Count > 0)
				{
					int triggerIndex = Aipolicy.TriggerIndex;
					if (triggerIndex >= 0 && triggerIndex < Aipolicy.CurrentTriggers.Count)
					{
						Aipolicy.TriggerIndex = triggerIndex;
						smethod_3(listBox_1, triggerIndex);
					}
					else
					{
						Aipolicy.TriggerIndex = -1;
						smethod_3(listBox_1, -1);
					}
				}
				else
				{
					Aipolicy.TriggerIndex = -1;
					smethod_3(listBox_1, -1);
				}
			}
			groupBox_1.Text = ((Aipolicy.CurrentTriggers != null) ? string.Format(Class16.smethod_0(1648934784), Aipolicy.CurrentTriggers.Count) : Class16.smethod_0(1648942688));
		}
		finally
		{
			bool_0 = false;
		}
		method_28();
		method_44();
		if (Aipolicy.CurrentTrigger != null)
		{
			conditionControl_0.Visible = true;
			conditionControl_0.Cond = Aipolicy.CurrentTrigger.RootConditon;
			method_29();
		}
		else
		{
			conditionControl_0.Visible = false;
			conditionControl_0.Cond = null;
		}
	}

	private void method_20(object sender, EventArgs e)
	{
		if (listBox_0.SelectedItems.Count < 1)
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1648934813);
		saveFileDialog.FileName = string.Format(Class16.smethod_0(1648934846), listBox_0.SelectedItems.Count);
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			List<CPolicyData> policies = listBox_0.SelectedItems.Cast<CPolicyData>().Select(Class45.class45_0.method_1).Where(Class45.class45_0.method_2)
				.ToList();
			JsonExporter.ExportPoliciesToJsonFile(policies, saveFileDialog.FileName);
		}
	}

	private static string smethod_6()
	{
		return TextStorage.Msg(Class16.smethod_0(1648934865), Class16.smethod_0(1648934892));
	}

	private static string smethod_7()
	{
		return TextStorage.Msg(Class16.smethod_0(1648934896), Class16.smethod_0(1648933912));
	}

	private static string smethod_8(string string_0, string string_1, object[] object_0)
	{
		return string.Format(TextStorage.Msg(string_0, string_1), object_0);
	}

	private void method_21(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1648934813);
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			List<string> list = new List<string>();
			try
			{
				string[] fileNames = openFileDialog.FileNames;
				foreach (string filePath in fileNames)
				{
					try
					{
						List<CPolicyData> list2 = JsonImporter.ImportPoliciesFromJsonFile(filePath);
						using List<CPolicyData>.Enumerator enumerator = list2.GetEnumerator();
						while (enumerator.MoveNext())
						{
							Class42 @class = new Class42();
							@class.cpolicyData_0 = enumerator.Current;
							if (@class.cpolicyData_0 == null)
							{
								continue;
							}
							CPolicyData cPolicyData = Aipolicy.Controllers.FirstOrDefault(@class.method_0);
							if (cPolicyData != null)
							{
								switch (DKBox.Show(smethod_8(Class16.smethod_0(1648933930), Class16.smethod_0(1648933983), new object[2]
								{
									@class.cpolicyData_0.ID,
									Environment.NewLine
								}), smethod_7(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
								{
								case DialogResult.Yes:
								{
									int index = Aipolicy.Controllers.IndexOf(cPolicyData);
									Aipolicy.Controllers[index] = @class.cpolicyData_0;
									break;
								}
								case DialogResult.No:
									@class.cpolicyData_0.ID = ((Aipolicy.Controllers.Count <= 0) ? 1 : (((IEnumerable<CPolicyData>)Aipolicy.Controllers).Max((Func<CPolicyData, int>)Class45.class45_0.method_3) + 1));
									Aipolicy.Controllers.Add(@class.cpolicyData_0);
									break;
								}
							}
							else
							{
								Aipolicy.Controllers.Add(@class.cpolicyData_0);
							}
						}
					}
					catch (InvalidDataException ex)
					{
						list.Add(ex.Message);
					}
				}
				method_45();
				if (list.Count > 0)
				{
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648934082), Class16.smethod_0(1648934133)), string.Join(Environment.NewLine, list)), smethod_6(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1648934172));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648934082), Class16.smethod_0(1648934133)), ex2.Message), smethod_6(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void method_22(object sender, EventArgs e)
	{
		List<CPolicyData> list = listBox_0.SelectedItems.Cast<CPolicyData>().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int num = listBox_0.SelectedIndices.Cast<int>().Min();
		foreach (CPolicyData item in list)
		{
			Aipolicy.Controllers.Remove(item);
		}
		int num2 = -1;
		if (Aipolicy.Controllers.Count > 0)
		{
			num2 = Math.Max(0, num - 1);
			if (num2 >= Aipolicy.Controllers.Count)
			{
				num2 = Aipolicy.Controllers.Count - 1;
			}
		}
		method_42(-1, -1, -1);
		if (num2 >= 0)
		{
			method_39(num2, bool_2: false);
		}
	}

	private void method_23(object sender, EventArgs e)
	{
		CTriggerData item = new CTriggerData
		{
			Version = CTriggerData.MaxVersion,
			ID = ((Aipolicy.CurrentTriggers.Count > 0) ? (Aipolicy.CurrentTriggers.Last().ID + 1) : 0)
		};
		Aipolicy.CurrentTriggers.Add(item);
		method_45();
	}

	private void method_24(object sender, EventArgs e)
	{
		if (Aipolicy.CurrentTriggers == null)
		{
			return;
		}
		List<CTriggerData> list = listBox_1.SelectedItems.Cast<CTriggerData>().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int count = Aipolicy.CurrentTriggers.Count;
		foreach (CTriggerData item in list)
		{
			if (item.Clone() is CTriggerData cTriggerData)
			{
				cTriggerData.ID = ((Aipolicy.CurrentTriggers.Count > 0) ? (((IEnumerable<CTriggerData>)Aipolicy.CurrentTriggers).Max((Func<CTriggerData, int>)Class45.class45_0.method_4) + 1) : 0);
				Aipolicy.CurrentTriggers.Add(cTriggerData);
			}
		}
		bool_0 = true;
		try
		{
			bindingSource_1.ResetBindings(metadataChanged: false);
			groupBox_1.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648934204), Class16.smethod_0(1648934784)), Aipolicy.CurrentTriggers.Count);
			smethod_3(listBox_1, count);
			smethod_4(listBox_1, count, bool_2: false);
			Aipolicy.TriggerIndex = count;
		}
		finally
		{
			bool_0 = false;
		}
		method_28();
		method_44();
		if (Aipolicy.CurrentTrigger != null)
		{
			conditionControl_0.Visible = true;
			conditionControl_0.Cond = Aipolicy.CurrentTrigger.RootConditon;
			method_29();
		}
	}

	private void method_25(object sender, EventArgs e)
	{
		if (listBox_1.SelectedItems.Count < 1)
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1648934813);
		saveFileDialog.FileName = string.Format(Class16.smethod_0(1648934228), listBox_1.SelectedItems.Count);
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			List<CTriggerData> triggers = listBox_1.SelectedItems.Cast<CTriggerData>().Select(Class45.class45_0.method_5).Where(Class45.class45_0.method_6)
				.ToList();
			JsonExporter.ExportTriggersToJsonFile(triggers, saveFileDialog.FileName);
		}
	}

	private void method_26(object sender, EventArgs e)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		try
		{
			openFileDialog.Filter = Class16.smethod_0(1648934813);
			openFileDialog.Multiselect = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			List<string> list = new List<string>();
			try
			{
				string[] fileNames = openFileDialog.FileNames;
				foreach (string filePath in fileNames)
				{
					try
					{
						List<CTriggerData> list2 = JsonImporter.ImportTriggersFromJsonFile(filePath, Aipolicy.CurrentTrigger?.Version ?? 0);
						using List<CTriggerData>.Enumerator enumerator = list2.GetEnumerator();
						while (enumerator.MoveNext())
						{
							Class38 @class = new Class38();
							@class.ctriggerData_0 = enumerator.Current;
							if (@class.ctriggerData_0 == null)
							{
								continue;
							}
							CTriggerData cTriggerData = Aipolicy.CurrentTriggers.FirstOrDefault(@class.method_0);
							if (cTriggerData != null)
							{
								switch (DKBox.Show(smethod_8(Class16.smethod_0(1648934252), Class16.smethod_0(1648934294), new object[2]
								{
									@class.ctriggerData_0.ID,
									Environment.NewLine
								}), smethod_7(), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
								{
								case DialogResult.Yes:
								{
									int index = Aipolicy.CurrentTriggers.IndexOf(cTriggerData);
									Aipolicy.CurrentTriggers[index] = @class.ctriggerData_0;
									break;
								}
								case DialogResult.No:
									@class.ctriggerData_0.ID = ((Aipolicy.CurrentTriggers.Count > 0) ? (((IEnumerable<CTriggerData>)Aipolicy.CurrentTriggers).Max((Func<CTriggerData, int>)Class45.class45_0.method_7) + 1) : 0);
									Aipolicy.CurrentTriggers.Add(@class.ctriggerData_0);
									break;
								}
							}
							else
							{
								Aipolicy.CurrentTriggers.Add(@class.ctriggerData_0);
							}
						}
					}
					catch (InvalidDataException ex)
					{
						list.Add(ex.Message);
					}
				}
				method_45();
				if (list.Count > 0)
				{
					DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648934398), Class16.smethod_0(1648933414)), string.Join(Environment.NewLine, list)), smethod_6(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			catch (Exception ex2)
			{
				SentryHelper.CaptureException(ex2, Class16.smethod_0(1648933442));
				DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648934398), Class16.smethod_0(1648933414)), ex2.Message), smethod_6(), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		finally
		{
			((IDisposable)openFileDialog).Dispose();
		}
	}

	private void method_27(object sender, EventArgs e)
	{
		if (Aipolicy.CurrentTriggers == null)
		{
			return;
		}
		List<CTriggerData> list = listBox_1.SelectedItems.Cast<CTriggerData>().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int num = listBox_1.SelectedIndices.Cast<int>().Min();
		foreach (CTriggerData item in list)
		{
			Aipolicy.CurrentTriggers.Remove(item);
		}
		int num2 = -1;
		if (Aipolicy.CurrentTriggers.Count > 0)
		{
			num2 = Math.Max(0, num - 1);
			if (num2 >= Aipolicy.CurrentTriggers.Count)
			{
				num2 = Aipolicy.CurrentTriggers.Count - 1;
			}
		}
		method_42(Aipolicy.ControllerIndex, -1, -1);
		if (num2 >= 0)
		{
			method_40(num2, bool_2: false);
		}
	}

	private void listBox_1_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (bool_0)
		{
			return;
		}
		int num = smethod_2(listBox_1);
		if (num > -1)
		{
			smethod_4(listBox_1, num, bool_2: false);
		}
		if (Aipolicy.TriggerIndex != num)
		{
			Aipolicy.TriggerIndex = num;
		}
		method_28();
		if (Aipolicy.CurrentTrigger != null)
		{
			conditionControl_0.Visible = true;
			if (base.InvokeRequired)
			{
				Invoke(new Action(method_52));
			}
			else
			{
				conditionControl_0.Cond = Aipolicy.CurrentTrigger.RootConditon;
			}
			method_29();
		}
		else
		{
			conditionControl_0.Visible = false;
			conditionControl_0.Cond = null;
		}
		method_44();
	}

	private void method_28()
	{
		bool_0 = true;
		try
		{
			if (Aipolicy.CurrentTrigger != null)
			{
				textBox_0.Text = Aipolicy.CurrentTrigger.Name ?? string.Empty;
				numericUpDown_1.Value = Aipolicy.CurrentTrigger.ID;
				numericUpDown_2.Value = Aipolicy.CurrentTrigger.Version;
				checkBox_0.Checked = Aipolicy.CurrentTrigger.Active;
				checkBox_1.Checked = Aipolicy.CurrentTrigger.Run;
				checkBox_2.Checked = Aipolicy.CurrentTrigger.AttackValid;
				textBox_0.Enabled = true;
				numericUpDown_1.Enabled = true;
				numericUpDown_2.Enabled = true;
				checkBox_0.Enabled = true;
				checkBox_1.Enabled = true;
				checkBox_2.Enabled = true;
			}
			else
			{
				textBox_0.Text = string.Empty;
				numericUpDown_1.Value = 0m;
				numericUpDown_2.Value = 0m;
				checkBox_0.Checked = false;
				checkBox_1.Checked = false;
				checkBox_2.Checked = false;
				textBox_0.Enabled = false;
				numericUpDown_1.Enabled = false;
				numericUpDown_2.Enabled = false;
				checkBox_0.Enabled = false;
				checkBox_1.Enabled = false;
				checkBox_2.Enabled = false;
			}
			method_14();
			method_29();
		}
		finally
		{
			bool_0 = false;
		}
	}

	private void method_29()
	{
		if (conditionControl_0 != null)
		{
			conditionControl_0.Refresh();
		}
	}

	private void method_30(object sender, EventArgs e)
	{
		if (Aipolicy.CurrentTrigger == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648933479)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		OperationSelectorForm operationSelectorForm = new OperationSelectorForm(Aipolicy.CurrentTrigger.Version);
		if (operationSelectorForm.ShowDialog() == DialogResult.OK && operationSelectorForm.Op != null)
		{
			Aipolicy.CurrentTrigger.Version = operationSelectorForm.GetUpdatedVersion();
			Aipolicy.CurrentTrigger.Operations.Add(operationSelectorForm.Op);
			Aipolicy.OnPropertyChanged(Class16.smethod_0(1648939491));
			Aipolicy.OnPropertyChanged(Class16.smethod_0(1648939518));
			Aipolicy.OnPropertyChanged(Class16.smethod_0(1648942603));
			Aipolicy.OnPropertyChanged(Class16.smethod_0(1648939414));
		}
	}

	private void method_31(object sender, EventArgs e)
	{
		if (Aipolicy.CurrentOperations == null)
		{
			return;
		}
		List<IOperation> list = listBox_2.SelectedItems.Cast<IOperation>().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int count = Aipolicy.CurrentOperations.Count;
		foreach (IOperation item2 in list)
		{
			if ((item2 as ICloneable)?.Clone() is IOperation item)
			{
				Aipolicy.CurrentOperations.Add(item);
			}
		}
		bool_0 = true;
		try
		{
			bindingSource_2.ResetBindings(metadataChanged: false);
			groupBox_2.Text = string.Format(TextStorage.Msg(Class16.smethod_0(1648933509), Class16.smethod_0(1648933535)), Aipolicy.CurrentOperations.Count);
			smethod_3(listBox_2, count);
			smethod_4(listBox_2, count, bool_2: false);
			Aipolicy.OperationIndex = count;
		}
		finally
		{
			bool_0 = false;
		}
		method_34();
	}

	private void method_32(object sender, EventArgs e)
	{
		if (listBox_2.SelectedItems.Count < 1 || Aipolicy.CurrentTrigger == null)
		{
			return;
		}
		using SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = Class16.smethod_0(1648934813);
		saveFileDialog.FileName = string.Format(Class16.smethod_0(1648933558), listBox_2.SelectedItems.Count);
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			List<IOperation> operations = listBox_2.SelectedItems.Cast<IOperation>().Select(Class45.class45_0.method_8).Where(Class45.class45_0.method_9)
				.ToList();
			JsonExporter.ExportOperationsToJsonFile(operations, Aipolicy.CurrentTrigger.Version, saveFileDialog.FileName);
		}
	}

	private void method_33(object sender, EventArgs e)
	{
		if (Aipolicy.CurrentOperations == null)
		{
			DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648933576)), TextStorage.Msg(Class16.smethod_0(1648943005)), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		using OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Filter = Class16.smethod_0(1648933621);
		if (openFileDialog.ShowDialog() != DialogResult.OK)
		{
			return;
		}
		try
		{
			OperationImportResult operationImportResult = JsonImporter.ImportOperationsFromJsonFile(openFileDialog.FileName);
			if (operationImportResult?.Operations != null && operationImportResult.Operations.Count > 0)
			{
				foreach (IOperation operation in operationImportResult.Operations)
				{
					Aipolicy.CurrentOperations.Add(operation);
				}
				if (Aipolicy.CurrentTrigger != null && operationImportResult.TriggerVersion > Aipolicy.CurrentTrigger.Version)
				{
					Aipolicy.CurrentTrigger.Version = operationImportResult.TriggerVersion;
				}
				method_45();
			}
			else
			{
				DKBox.Show(TextStorage.Msg(Class16.smethod_0(1648933665)), TextStorage.Msg(Class16.smethod_0(1648934865)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
		catch (InvalidDataException ex)
		{
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648933701), Class16.smethod_0(1648933743)), ex.Message), TextStorage.Msg(Class16.smethod_0(1648934865), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
		catch (Exception ex2)
		{
			SentryHelper.CaptureException(ex2, Class16.smethod_0(1648933781));
			DKBox.Show(string.Format(TextStorage.Msg(Class16.smethod_0(1648933701), Class16.smethod_0(1648933743)), ex2.Message), TextStorage.Msg(Class16.smethod_0(1648934865), Class16.smethod_0(1648934892)), MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}

	private void listBox_2_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!bool_0)
		{
			int num = smethod_2(listBox_2);
			if (num > -1)
			{
				smethod_4(listBox_2, num, bool_2: false);
			}
			if (Aipolicy.OperationIndex != num)
			{
				Aipolicy.OperationIndex = num;
			}
			method_34();
		}
	}

	private void method_34()
	{
		propertyGrid_0.SelectedObject = Aipolicy.CurrentOperation;
		propertyGrid_0.Refresh();
		try
		{
			propertyGrid_0.ExpandAllGridItems();
		}
		catch
		{
		}
	}

	private void method_35(object sender, EventArgs e)
	{
		if (Aipolicy.CurrentTrigger == null || Aipolicy.CurrentOperations == null)
		{
			return;
		}
		List<IOperation> list = listBox_2.SelectedItems.Cast<IOperation>().ToList();
		if (list.Count == 0)
		{
			return;
		}
		int num = listBox_2.SelectedIndices.Cast<int>().Min();
		foreach (IOperation item in list)
		{
			Aipolicy.CurrentTrigger.Operations.Remove(item);
		}
		int num2 = -1;
		if (Aipolicy.CurrentOperations.Count > 0)
		{
			num2 = Math.Max(0, num - 1);
			if (num2 >= Aipolicy.CurrentOperations.Count)
			{
				num2 = Aipolicy.CurrentOperations.Count - 1;
			}
		}
		Aipolicy.OperationIndex = num2;
		method_44();
	}

	private void method_36(int int_4)
	{
		method_1(listBox_0, int_4, method_53, method_54, Interlocked.Increment(ref int_1));
	}

	private void method_37(int int_4)
	{
		method_1(listBox_1, int_4, method_55, method_56, Interlocked.Increment(ref int_2));
	}

	private void method_38(int int_4)
	{
		method_1(listBox_2, int_4, method_57, method_58, Interlocked.Increment(ref int_3));
	}

	private void method_39(int int_4, bool bool_2)
	{
		method_2(listBox_0, int_4, bool_2, method_59, Interlocked.Increment(ref int_1));
	}

	private void method_40(int int_4, bool bool_2)
	{
		method_2(listBox_1, int_4, bool_2, method_60, Interlocked.Increment(ref int_2));
	}

	private void method_41(int int_4)
	{
		method_2(listBox_2, int_4, bool_2: true, method_61, Interlocked.Increment(ref int_3));
	}

	private void method_42(int int_4, int int_5, int int_6)
	{
		bool_0 = true;
		try
		{
			bindingSource_0.DataSource = null;
			bindingSource_0.DataSource = Aipolicy.Controllers;
			listBox_0.DisplayMember = Class16.smethod_0(1648941057);
			method_43();
			if (Aipolicy.Controllers.Count > 0 && int_4 >= 0)
			{
				int num = Math.Min(int_4, Aipolicy.Controllers.Count - 1);
				Aipolicy.ControllerIndex = num;
				smethod_3(listBox_0, num);
			}
			else
			{
				Aipolicy.ControllerIndex = -1;
				smethod_3(listBox_0, -1);
			}
			bindingSource_1.DataSource = null;
			if (Aipolicy.CurrentTriggers != null)
			{
				bindingSource_1.DataSource = Aipolicy.CurrentTriggers;
				listBox_1.DisplayMember = Class16.smethod_0(1648934774);
				if (Aipolicy.CurrentTriggers.Count > 0 && int_5 >= 0)
				{
					int num2 = Math.Min(int_5, Aipolicy.CurrentTriggers.Count - 1);
					Aipolicy.TriggerIndex = num2;
					smethod_3(listBox_1, num2);
				}
				else
				{
					Aipolicy.TriggerIndex = -1;
					smethod_3(listBox_1, -1);
				}
			}
			groupBox_1.Text = ((Aipolicy.CurrentTriggers != null) ? string.Format(Class16.smethod_0(1648934784), Aipolicy.CurrentTriggers.Count) : Class16.smethod_0(1648942688));
		}
		finally
		{
			bool_0 = false;
		}
		method_18();
		method_28();
		method_44();
		if (int_6 >= 0 && Aipolicy.CurrentOperations != null && Aipolicy.CurrentOperations.Count > 0)
		{
			int num3 = Math.Min(int_6, Aipolicy.CurrentOperations.Count - 1);
			Aipolicy.OperationIndex = num3;
			method_38(num3);
		}
	}

	private void listBox_0_Format(object sender, ListControlConvertEventArgs e)
	{
		if (e.Value is CPolicyData cPolicyData)
		{
			e.Value = cPolicyData.ID;
		}
	}

	private void method_43()
	{
		if (groupBox_0 != null)
		{
			groupBox_0.Text = ((Aipolicy?.Controllers != null) ? string.Format(Class16.smethod_0(1648933812), Aipolicy.Controllers.Count) : Class16.smethod_0(1648931807));
		}
	}

	private void listBox_1_Format(object sender, ListControlConvertEventArgs e)
	{
		if (e.Value is CTriggerData cTriggerData)
		{
			e.Value = string.Format(Class16.smethod_0(1648942820), cTriggerData.ID, cTriggerData.Name);
		}
	}

	private void listBox_2_DrawItem(object sender, DrawItemEventArgs e)
	{
		e.DrawBackground();
		if (e.Index >= 0 && e.Index < listBox_2.Items.Count)
		{
			object obj = listBox_2.Items[e.Index];
			string text = ((obj is IOperation op) ? op.GetDisplayText() : obj.ToString());
			TextRenderer.DrawText(e.Graphics, text, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.VerticalCenter);
		}
		e.DrawFocusRectangle();
	}

	private void method_44()
	{
		bool_0 = true;
		try
		{
			if (inotifyCollectionChanged_0 != null)
			{
				inotifyCollectionChanged_0.CollectionChanged -= inotifyCollectionChanged_0_CollectionChanged;
				inotifyCollectionChanged_0 = null;
			}
			bindingSource_2.DataSource = null;
			if (Aipolicy.CurrentOperations != null)
			{
				inotifyCollectionChanged_0 = Aipolicy.CurrentOperations;
				if (inotifyCollectionChanged_0 != null)
				{
					inotifyCollectionChanged_0.CollectionChanged += inotifyCollectionChanged_0_CollectionChanged;
				}
				bindingSource_2.DataSource = Aipolicy.CurrentOperations;
				if (Aipolicy.CurrentOperations.Count > 0)
				{
					if (Aipolicy.OperationIndex >= 0 && Aipolicy.OperationIndex < Aipolicy.CurrentOperations.Count)
					{
						smethod_3(listBox_2, Aipolicy.OperationIndex);
					}
					else
					{
						Aipolicy.OperationIndex = -1;
						smethod_3(listBox_2, -1);
					}
				}
				else
				{
					Aipolicy.OperationIndex = -1;
					smethod_3(listBox_2, -1);
				}
			}
			else
			{
				Aipolicy.OperationIndex = -1;
			}
			groupBox_2.Text = ((Aipolicy.CurrentOperations != null) ? string.Format(Class16.smethod_0(1648933535), Aipolicy.CurrentOperations.Count) : Class16.smethod_0(1648942657));
		}
		finally
		{
			bool_0 = false;
		}
		method_34();
	}

	private void method_45()
	{
		bool_0 = true;
		try
		{
			int controllerIndex = Aipolicy.ControllerIndex;
			int triggerIndex = Aipolicy.TriggerIndex;
			bindingSource_0.DataSource = null;
			bindingSource_0.DataSource = Aipolicy.Controllers;
			listBox_0.DisplayMember = Class16.smethod_0(1648941057);
			method_43();
			if (Aipolicy.Controllers.Count > 0)
			{
				if (controllerIndex >= 0 && controllerIndex < Aipolicy.Controllers.Count)
				{
					Aipolicy.ControllerIndex = controllerIndex;
					smethod_3(listBox_0, controllerIndex);
				}
				else
				{
					Aipolicy.ControllerIndex = -1;
					smethod_3(listBox_0, -1);
				}
			}
			else
			{
				Aipolicy.ControllerIndex = -1;
				smethod_3(listBox_0, -1);
			}
			bindingSource_1.DataSource = null;
			if (Aipolicy.CurrentTriggers != null)
			{
				bindingSource_1.DataSource = Aipolicy.CurrentTriggers;
				listBox_1.DisplayMember = Class16.smethod_0(1648934774);
				if (Aipolicy.CurrentTriggers.Count > 0)
				{
					if (triggerIndex >= 0 && triggerIndex < Aipolicy.CurrentTriggers.Count)
					{
						Aipolicy.TriggerIndex = triggerIndex;
						smethod_3(listBox_1, triggerIndex);
					}
					else
					{
						Aipolicy.TriggerIndex = -1;
						smethod_3(listBox_1, -1);
					}
				}
				else
				{
					Aipolicy.TriggerIndex = -1;
					smethod_3(listBox_1, -1);
				}
			}
			groupBox_1.Text = ((Aipolicy.CurrentTriggers != null) ? string.Format(Class16.smethod_0(1648934784), Aipolicy.CurrentTriggers.Count) : Class16.smethod_0(1648942688));
		}
		finally
		{
			bool_0 = false;
		}
		method_18();
		method_28();
		method_44();
	}

	private void method_46(object sender, PropertyChangedEventArgs e)
	{
		Class41 @class = new Class41();
		@class.mainForm_0 = this;
		@class.object_0 = sender;
		@class.propertyChangedEventArgs_0 = e;
		if (base.InvokeRequired)
		{
			BeginInvoke(new Action(@class.method_0));
		}
		else
		{
			if (bool_0)
			{
				return;
			}
			string propertyName = @class.propertyChangedEventArgs_0.PropertyName;
			if (propertyName == null)
			{
				return;
			}
			switch (propertyName.Length)
			{
			case 11:
				if (propertyName == Class16.smethod_0(1648939437))
				{
					method_45();
				}
				break;
			case 12:
				if (propertyName == Class16.smethod_0(1648939491) && !bool_0)
				{
					method_37(Aipolicy.TriggerIndex);
				}
				break;
			case 14:
				switch (propertyName[0])
				{
				case 'O':
					if (propertyName == Class16.smethod_0(1648939455) && !bool_0)
					{
						method_38(Aipolicy.OperationIndex);
					}
					break;
				case 'C':
					if (propertyName == Class16.smethod_0(1648939518))
					{
						method_28();
					}
					break;
				}
				break;
			case 15:
				switch (propertyName[1])
				{
				case 'u':
					if (propertyName == Class16.smethod_0(1648939339))
					{
						method_19();
					}
					break;
				case 'o':
					if (propertyName == Class16.smethod_0(1648939325) && !bool_0)
					{
						method_36(Aipolicy.ControllerIndex);
					}
					break;
				}
				break;
			case 16:
				if (propertyName == Class16.smethod_0(1648939476))
				{
					method_34();
				}
				break;
			case 17:
				switch (propertyName[7])
				{
				case 'O':
					if (propertyName == Class16.smethod_0(1648942603))
					{
						method_44();
					}
					break;
				case 'C':
					if (propertyName == Class16.smethod_0(1648939361))
					{
						method_18();
					}
					break;
				}
				break;
			case 13:
				break;
			}
		}
	}

	private void inotifyCollectionChanged_0_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
	{
		Class43 @class = new Class43();
		@class.mainForm_0 = this;
		@class.object_0 = sender;
		@class.notifyCollectionChangedEventArgs_0 = e;
		if (base.InvokeRequired)
		{
			BeginInvoke(new Action(@class.method_0));
		}
		else
		{
			method_44();
		}
	}

	private void MainForm_Activated(object sender, EventArgs e)
	{
		method_47();
	}

	private void method_47()
	{
		if (ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_AIPolicyEditor != CommonStorage.Texts.LangIndex)
		{
			TextStorage.TEXTS.SetFormLanguage(this);
			Provider.ChangeLanguage(smethod_0());
			method_4();
			method_14();
			ACE.RSGlobal.RSGlobal.FormLang_UpdateLanguage_AIPolicyEditor = CommonStorage.Texts.LangIndex;
		}
		GC.KeepAlive(this);
	}

	private void method_48()
	{
		Class39 @class = new Class39();
		@class.mainForm_0 = this;
		fileBasedUndoManager_0 = new FileBasedUndoManager(Class16.smethod_0(1648933826));
		fileBasedUndoManager_0.AttachKeyboardShortcuts(this, method_49, method_50);
		@class.toolStripMenuItem_0 = new ToolStripMenuItem(Class16.smethod_0(1648933841));
		@class.toolStripMenuItem_0.ShortcutKeys = Keys.Z | Keys.Control;
		@class.toolStripMenuItem_0.Click += @class.method_0;
		@class.toolStripMenuItem_1 = new ToolStripMenuItem(Class16.smethod_0(1648933869));
		@class.toolStripMenuItem_1.ShortcutKeys = Keys.Y | Keys.Control;
		@class.toolStripMenuItem_1.Click += @class.method_1;
		ToolStripMenuItem toolStripMenuItem = menuStrip_0.Items.OfType<ToolStripMenuItem>().FirstOrDefault(Class45.class45_0.method_10);
		if (toolStripMenuItem != null)
		{
			toolStripMenuItem.DropDownItems.Insert(0, new ToolStripSeparator());
			toolStripMenuItem.DropDownItems.Insert(0, @class.toolStripMenuItem_1);
			toolStripMenuItem.DropDownItems.Insert(0, @class.toolStripMenuItem_0);
		}
		fileBasedUndoManager_0.SetStateChangedCallback(@class.method_2);
	}

	private byte[] method_49()
	{
		if (Aipolicy?.Controllers == null)
		{
			return null;
		}
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			try
			{
				BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
				try
				{
					binaryWriter.Write(Aipolicy.Header);
					binaryWriter.Write(Aipolicy.Controllers.Count);
					for (int i = 0; i < Aipolicy.Controllers.Count; i++)
					{
						Aipolicy.Controllers[i].Write(binaryWriter);
					}
					binaryWriter.Flush();
					return memoryStream.ToArray();
				}
				finally
				{
					((IDisposable)binaryWriter).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch
		{
			return null;
		}
	}

	private void method_50(byte[] byte_0)
	{
		if (byte_0 == null || byte_0.Length == 0)
		{
			return;
		}
		bool_1 = true;
		try
		{
			MemoryStream memoryStream = new MemoryStream(byte_0);
			try
			{
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				try
				{
					uint header = binaryReader.ReadUInt32();
					int num = binaryReader.ReadInt32();
					ObservableCollection<CPolicyData> observableCollection = new ObservableCollection<CPolicyData>();
					for (int i = 0; i < num; i++)
					{
						CPolicyData cPolicyData = new CPolicyData();
						cPolicyData.Read(binaryReader);
						observableCollection.Add(cPolicyData);
					}
					Aipolicy.Header = header;
					Aipolicy.Controllers.Clear();
					foreach (CPolicyData item in observableCollection)
					{
						Aipolicy.Controllers.Add(item);
					}
					SuspendLayout();
					method_15();
					ResumeLayout(performLayout: false);
				}
				finally
				{
					((IDisposable)binaryReader).Dispose();
				}
			}
			finally
			{
				((IDisposable)memoryStream).Dispose();
			}
		}
		catch (Exception ex)
		{
			SentryHelper.CaptureException(ex, Class16.smethod_0(1648933881));
		}
		finally
		{
			bool_1 = false;
		}
	}

	public void PushAIPolicyUndo()
	{
		if (!bool_1)
		{
			byte[] array = method_49();
			if (array != null)
			{
				fileBasedUndoManager_0?.PushUndo(array);
			}
		}
	}

	private void method_51(object sender, EventArgs e)
	{
		method_29();
	}

	private void method_52()
	{
		conditionControl_0.Cond = Aipolicy.CurrentTrigger.RootConditon;
	}

	private void method_53(int int_4)
	{
		Aipolicy.ControllerIndex = int_4;
	}

	private int method_54()
	{
		return int_1;
	}

	private void method_55(int int_4)
	{
		Aipolicy.TriggerIndex = int_4;
	}

	private int method_56()
	{
		return int_2;
	}

	private void method_57(int int_4)
	{
		Aipolicy.OperationIndex = int_4;
	}

	private int method_58()
	{
		return int_3;
	}

	private int method_59()
	{
		return int_1;
	}

	private int method_60()
	{
		return int_2;
	}

	private int method_61()
	{
		return int_3;
	}
}
