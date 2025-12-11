using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.Others;

public class ConnectCommand : ICommand
{
    private readonly FilePath _address;
    private readonly string _mode;

    public ConnectCommand(FilePath address, string mode)
    {
        _address = address;
        _mode = mode;
    }

    public CommandResult Execute(IFileSystemContext context)
    {
        return context.Connect(_address, _mode);
    }
}