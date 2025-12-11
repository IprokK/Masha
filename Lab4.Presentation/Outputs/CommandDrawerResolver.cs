using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.Others;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.TreeOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.FileOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.Others;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.TreeOperations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs;

public static class CommandDrawerResolver
{
    public static ICommandResultVisitor Resolve(ICommand command)
    {
        return command switch
        {
            ConnectCommand => new ConnectDrawer(),
            DisconnectCommand => new DisconnectDrawer(),
            TreeListCommand => new TreeListDrawer(),
            TreeGoToCommand => new TreeGoToDrawer(),
            MoveCommand => new MoveDrawer(),
            CopyCommand => new CopyDrawer(),
            DeleteCommand => new DeleteDrawer(),
            RenameCommand => new RenameDrawer(),
            ShowCommand showCommand when showCommand.Mode == "console" => new ShowDrawer(),
            ShowCommand => new NoOpDrawer(),
            _ => throw new InvalidOperationException("No drawer registered for the given command"),
        };
    }

    private sealed class NoOpDrawer : ICommandResultVisitor
    {
        public void Visit(CommandResult.Success result)
        {
        }

        public void Visit(CommandResult.Failure result)
        {
        }
    }
}
