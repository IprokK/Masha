using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

public interface ICommandResultVisitor
{
    void Visit(CommandResult.Success result);
    void Visit(CommandResult.Failure result);
}
