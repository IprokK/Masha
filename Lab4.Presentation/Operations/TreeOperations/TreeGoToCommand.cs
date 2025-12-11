using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.TreeOperations;

public class TreeGoToCommand : ICommand
{
    private readonly FilePath _path;

    public TreeGoToCommand(FilePath path)
    {
        _path = path;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        return context.ChangeDirectory(_path);
    }
}