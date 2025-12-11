using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.Others;

public class DisconnectCommand : ICommand
{
    public CommandResult Execute(IFileSystemContext context)
    {
        return context.Disconnect();
    }
}