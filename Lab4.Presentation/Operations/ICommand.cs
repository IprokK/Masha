using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;

public interface ICommand
{
    CommandResult Execute(IFileSystemContext context);
}