using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.TreeOperations;

public class TreeListCommand : ICommand
{
    private readonly int _depth;

    public TreeListCommand(int depth)
    {
        _depth = depth;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        return context.ListDirectory(_depth);
    }
}