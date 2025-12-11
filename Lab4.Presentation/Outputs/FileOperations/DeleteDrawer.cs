using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.FileOperations;

public class DeleteDrawer : ICommandResultVisitor
{
    public void Visit(CommandResult.Success result)
    {
        Console.WriteLine("File deleted successfully");
    }

    public void Visit(CommandResult.Failure result)
    {
        Console.WriteLine(result.Message ?? "Failed to delete file");
    }
}