namespace ACE.Pck;

public enum PckOperationStage
{
	Idle,
	Opening,
	Reading,
	Writing,
	Compressing,
	Extracting,
	Adding,
	Removing,
	Defragmenting,
	Saving,
	Completed,
	Error,
	Cancelled
}
