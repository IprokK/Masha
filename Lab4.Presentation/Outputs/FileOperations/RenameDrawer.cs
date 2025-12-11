using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.FileOperations;

public class RenameDrawer : ICommandResultVisitor
{
    public void Visit(CommandResult.Success result)
    {
        Console.WriteLine("File renamed successfully");
    }

    public void Visit(CommandResult.Failure result)
    {
        Console.WriteLine(result.Message ?? "Failed to rename file");
    }
}