using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.FileOperations;

public class ShowDrawer : ICommandResultVisitor
{
    public void Visit(CommandResult.Success result)
    {
        if (result.Payload is string content)
        {
            Console.WriteLine(content);
            return;
        }

        Console.WriteLine("File content is unavailable");
    }

    public void Visit(CommandResult.Failure result)
    {
        Console.WriteLine(result.Message ?? "Failed to read file");
    }
}