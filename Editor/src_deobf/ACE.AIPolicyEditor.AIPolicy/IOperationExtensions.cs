namespace ACE.AIPolicyEditor.AIPolicy;

public static class IOperationExtensions
{
	public static string GetDisplayText(this IOperation op)
	{
		return string.Format(Class16.smethod_0(1648936700), op.OperID, op.Name, MainForm.Provider.GetLocalizedString(Class16.smethod_0(1648942674)), op.FromVersion);
	}
}
