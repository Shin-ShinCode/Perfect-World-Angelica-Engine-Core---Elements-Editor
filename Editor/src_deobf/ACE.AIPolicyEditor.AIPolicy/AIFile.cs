using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using ACE.Classes;

namespace ACE.AIPolicyEditor.AIPolicy;

public class AIFile : INotifyPropertyChanged
{
	private sealed class Class19
	{
		public AIFile aifile_0;

		public string string_0;

		internal void method_0()
		{
			aifile_0.method_0(string_0);
		}
	}

	public bool InAnotherThread = true;

	private int int_0 = -1;

	private ObservableCollection<CPolicyData> observableCollection_0 = new ObservableCollection<CPolicyData>();

	private int int_1 = -1;

	private int int_2 = -1;

	private string string_0 = string.Empty;

	private PropertyChangedEventHandler propertyChangedEventHandler_0;

	private uint uint_0;

	public int ControllerIndex
	{
		get
		{
			return int_0;
		}
		set
		{
			if (int_0 != value)
			{
				int_0 = value;
				TriggerIndex = -1;
				OperationIndex = -1;
				OnPropertyChanged(Class16.smethod_0(1648939325));
				OnPropertyChanged(Class16.smethod_0(1648939339));
				OnPropertyChanged(Class16.smethod_0(1648939361));
				OnPropertyChanged(Class16.smethod_0(1648939385));
				OnPropertyChanged(Class16.smethod_0(1648939414));
			}
		}
	}

	public ObservableCollection<CPolicyData> Controllers
	{
		get
		{
			return observableCollection_0;
		}
		set
		{
			if (observableCollection_0 != value)
			{
				observableCollection_0 = value;
				OnPropertyChanged(Class16.smethod_0(1648939437));
			}
		}
	}

	public CPolicyData CurrentController
	{
		get
		{
			if (ControllerIndex > -1)
			{
				return Controllers[ControllerIndex];
			}
			return null;
		}
		set
		{
			if (ControllerIndex > -1 && Controllers[ControllerIndex] != value)
			{
				Controllers[ControllerIndex] = value;
			}
		}
	}

	public IOperation CurrentOperation
	{
		get
		{
			if (TriggerIndex > -1 && OperationIndex > -1)
			{
				return Controllers[ControllerIndex].Triggers[TriggerIndex].Operations[OperationIndex];
			}
			return null;
		}
		set
		{
			if (TriggerIndex > -1 && OperationIndex > -1 && Controllers[ControllerIndex].Triggers[TriggerIndex].Operations[OperationIndex] != value)
			{
				Controllers[ControllerIndex].Triggers[TriggerIndex].Operations[OperationIndex] = value;
			}
		}
	}

	public ObservableCollection<IOperation> CurrentOperations
	{
		get
		{
			if (ControllerIndex > -1 && TriggerIndex > -1)
			{
				return Controllers[ControllerIndex].Triggers[TriggerIndex].Operations;
			}
			return null;
		}
		set
		{
			if (ControllerIndex > -1 && TriggerIndex > -1 && Controllers[ControllerIndex].Triggers[TriggerIndex].Operations != value)
			{
				Controllers[ControllerIndex].Triggers[TriggerIndex].Operations = value;
			}
		}
	}

	public CTriggerData CurrentTrigger
	{
		get
		{
			if (ControllerIndex > -1 && TriggerIndex > -1)
			{
				return Controllers[ControllerIndex].Triggers[TriggerIndex];
			}
			return null;
		}
		set
		{
			if (ControllerIndex > -1 && TriggerIndex > -1 && Controllers[ControllerIndex].Triggers[TriggerIndex] != value)
			{
				Controllers[ControllerIndex].Triggers[TriggerIndex] = value;
			}
		}
	}

	public ObservableCollection<CTriggerData> CurrentTriggers
	{
		get
		{
			if (ControllerIndex > -1)
			{
				return Controllers[ControllerIndex].Triggers;
			}
			return null;
		}
		set
		{
			if (ControllerIndex > -1 && Controllers[ControllerIndex].Triggers != value)
			{
				Controllers[ControllerIndex].Triggers = value;
			}
		}
	}

	public int OperationIndex
	{
		get
		{
			return int_1;
		}
		set
		{
			if (int_1 != value)
			{
				int_1 = value;
				OnPropertyChanged(Class16.smethod_0(1648939455));
				OnPropertyChanged(Class16.smethod_0(1648939476));
				OnPropertyChanged(Class16.smethod_0(1648939414));
			}
		}
	}

	public int TriggerIndex
	{
		get
		{
			return int_2;
		}
		set
		{
			if (int_2 != value)
			{
				int_2 = value;
				OperationIndex = -1;
				OnPropertyChanged(Class16.smethod_0(1648939491));
				OnPropertyChanged(Class16.smethod_0(1648939518));
				OnPropertyChanged(Class16.smethod_0(1648942603));
				OnPropertyChanged(Class16.smethod_0(1648939414));
			}
		}
	}

	public string FilePath => string_0;

	public uint Header
	{
		[CompilerGenerated]
		get
		{
			return uint_0;
		}
		[CompilerGenerated]
		set
		{
			uint_0 = value;
		}
	}

	public string OperationsHeader
	{
		get
		{
			return string.Format(Class16.smethod_0(1648942645), MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648942657)), MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648942674)), CurrentTrigger?.Version);
		}
		private set
		{
		}
	}

	public string TriggersHeader
	{
		get
		{
			return string.Format(Class16.smethod_0(1648942645), MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648942688)), MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648942674)), CurrentController?.Version);
		}
		private set
		{
		}
	}

	public event PropertyChangedEventHandler PropertyChanged
	{
		[CompilerGenerated]
		add
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PropertyChangedEventHandler propertyChangedEventHandler = propertyChangedEventHandler_0;
			PropertyChangedEventHandler propertyChangedEventHandler2;
			do
			{
				propertyChangedEventHandler2 = propertyChangedEventHandler;
				PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
				propertyChangedEventHandler = Interlocked.CompareExchange(ref propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
			}
			while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
		}
	}

	public void OnPropertyChanged(string prop = "")
	{
		propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(prop));
	}

	public void Read(string path)
	{
		Class19 @class = new Class19();
		@class.aifile_0 = this;
		@class.string_0 = path;
		string_0 = @class.string_0;
		if (InAnotherThread)
		{
			new Thread(@class.method_0).Start();
		}
		else
		{
			method_0(@class.string_0);
		}
	}

	public void Save()
	{
		string string_ = method_2(string_0);
		method_1(string_);
	}

	public void SaveAs(string path)
	{
		method_1(path);
	}

	public int FindControllerIndexById(int controllerId)
	{
		ObservableCollection<CPolicyData> controllers = Controllers;
		if (controllers != null && controllers.Count != 0)
		{
			int num = 0;
			while (true)
			{
				if (num < controllers.Count)
				{
					if (controllers[num] != null && controllers[num].ID == controllerId)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}
		return -1;
	}

	public CPolicyData GetControllerById(int controllerId)
	{
		int num = FindControllerIndexById(controllerId);
		if (num < 0)
		{
			return null;
		}
		return Controllers[num];
	}

	public string GetControllerDisplayText(int controllerId)
	{
		CPolicyData controllerById = GetControllerById(controllerId);
		if (controllerById == null)
		{
			return controllerId.ToString();
		}
		string text = controllerId.ToString();
		ObservableCollection<CTriggerData> triggers = controllerById.Triggers;
		if (triggers != null && triggers.Count > 0 && !string.IsNullOrWhiteSpace(triggers[0].Name))
		{
			text = text + Class16.smethod_0(1648942627) + triggers[0].Name;
		}
		return text;
	}

	private void method_0(string string_1)
	{
		EditorSessionTracker.LogFolderAccess(string_1, Class16.smethod_0(1648942711), Class16.smethod_0(1648942729));
		CPolicyData.MaxVersion = 0;
		CTriggerData.MaxVersion = 0;
		BinaryReader binaryReader = new BinaryReader(new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read));
		try
		{
			Header = binaryReader.ReadUInt32();
			int num = binaryReader.ReadInt32();
			ObservableCollection<CPolicyData> observableCollection = new ObservableCollection<CPolicyData>();
			for (int i = 0; i < num; i++)
			{
				CPolicyData cPolicyData = new CPolicyData();
				cPolicyData.Read(binaryReader);
				observableCollection.Add(cPolicyData);
			}
			observableCollection_0 = new ObservableCollection<CPolicyData>(observableCollection);
		}
		finally
		{
			((IDisposable)binaryReader).Dispose();
		}
		OnPropertyChanged(Class16.smethod_0(1648939437));
	}

	private void method_1(string string_1)
	{
		EditorSessionTracker.LogFolderAccess(string_1, Class16.smethod_0(1648942744), Class16.smethod_0(1648942729));
		BinaryWriter binaryWriter = new BinaryWriter(new FileStream(string_1, FileMode.Create, FileAccess.Write, FileShare.Write));
		try
		{
			binaryWriter.Write(Header);
			binaryWriter.Write(Controllers.Count);
			for (int i = 0; i < Controllers.Count; i++)
			{
				Controllers[i].Write(binaryWriter);
			}
		}
		finally
		{
			((IDisposable)binaryWriter).Dispose();
		}
	}

	private string method_2(string string_1)
	{
		string directoryName = System.IO.Path.GetDirectoryName(string_1);
		System.IO.Path.GetFileName(string_1);
		string text = System.IO.Path.Combine(directoryName, Class16.smethod_0(1648942770));
		if (File.Exists(text))
		{
			File.Delete(text);
		}
		File.Move(string_1, text);
		return string_1;
	}
}
