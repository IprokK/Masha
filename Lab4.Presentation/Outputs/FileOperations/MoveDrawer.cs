using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.FileOperations;

public class MoveDrawer : ICommandResultVisitor
{
    public void Visit(CommandResult.Success result)
    {
        Console.WriteLine("File moved successfully");
    }

    public void Visit(CommandResult.Failure result)
    {
        Console.WriteLine(result.Message ?? "Failed to move file");
    }
}