using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;

public class CopyCommand : ICommand
{
    private readonly FilePath _source;
    private readonly FilePath _destination;

    public CopyCommand(FilePath source, FilePath destination)
    {
        _source = source;
        _destination = destination;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        return context.CopyFile(_source, _destination);
    }
}