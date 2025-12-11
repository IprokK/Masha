using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.Others;

public class ConnectDrawer : ICommandResultVisitor
{
    public void Visit(CommandResult.Success result)
    {
        Console.WriteLine("Connected successfully");
    }

    public void Visit(CommandResult.Failure result)
    {
        Console.WriteLine(result.Message ?? "Failed to connect");
    }
}