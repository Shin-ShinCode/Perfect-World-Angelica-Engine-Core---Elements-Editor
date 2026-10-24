using System.ComponentModel;
using System.IO;

namespace ACE.AIPolicyEditor.AIPolicy;

[TypeConverter(typeof(ExpandableObjectConverter))]
public interface IOperation
{
	int FromVersion { get; }

	string Name { get; }

	int OperID { get; }

	void Read(BinaryReader br);

	bool Search(string str);

	void Write(BinaryWriter bw);
}
