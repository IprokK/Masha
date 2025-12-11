using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.TreeOperations;

public class TreeListDrawer : ICommandResultVisitor
{
    public void Visit(CommandResult.Success result)
    {
        var treeVisitor = new TreeVisitor();
        if (result.Payload is DirectoryNode root)
        {
            root.Apply(treeVisitor);
            return;
        }

        Console.WriteLine("Directory tree is unavailable");
    }

    public void Visit(CommandResult.Failure result)
    {
        Console.WriteLine(result.Message ?? "Failed to list directory");
    }
}