using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.TreeOperations;

public class TreeGoToDrawer : ICommandResultVisitor
{
    public void Visit(CommandResult.Success result)
    {
        Console.WriteLine("Directory changed successfully");
    }

    public void Visit(CommandResult.Failure result)
    {
        Console.WriteLine(result.Message ?? "Failed to change directory (path not found)");
    }
}