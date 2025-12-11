using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;

public class ShowCommand : ICommand
{
    private readonly FilePath _path;
    private readonly string _mode;

    public ShowCommand(FilePath path, string mode)
    {
        _path = path;
        _mode = mode;
    }

    public string Mode => _mode;

    public CommandResult Execute(IFileSystemContext context)
    {
        return context.ShowFile(_path);
    }
}