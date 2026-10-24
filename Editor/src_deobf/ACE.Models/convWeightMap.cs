namespace ACE.Models;

public struct convWeightMap(int VertexID, int JointID, float Weight)
{
	public int VertexID = VertexID;

	public int JointID = JointID;

	public float Weight = Weight;
}
