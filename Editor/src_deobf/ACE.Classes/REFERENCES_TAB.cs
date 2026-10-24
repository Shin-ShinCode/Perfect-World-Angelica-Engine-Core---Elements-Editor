using System.Collections.Generic;
using System.Windows.Forms;

namespace ACE.Classes;

public class REFERENCES_TAB
{
	public List<DataGridViewRow> Rows;

	public int RefCount;

	public REFERENCE_TYPE_EX RefType;

	public bool bRowsCreated;

	public TabPage tabPage;

	public DataGridView dgvReferences;

	public REFERENCES_TAB()
	{
		Rows = new List<DataGridViewRow>();
	}

	public void FinishAddingItems()
	{
		List<DataGridViewRow> rows = Rows;
		dgvReferences.Rows.AddRange(rows.ToArray());
		bRowsCreated = true;
		Rows = null;
	}
}
