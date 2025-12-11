using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.States;

public class DisconnectState : IAppState
{
    private readonly IFileSystemContext _context;

    public DisconnectState(IFileSystemContext context)
    {
        _context = context;
    }

    public CommandResult Connect(FilePath address, string mode)
    {
        IFileSystemFactory? factory = _context.FindFactory(mode);

        if (factory is null)
        {
            return new CommandResult.Failure("Unsupported mode");
        }

        IFileSystem fileSystem = factory.Create(address.Value);

        _context.SetFileSystem(fileSystem);
        _context.TransitionTo(new ConnectState(_context));

        return new CommandResult.Success();
    }

    public CommandResult Disconnect()
    {
        return new CommandResult.Failure("Not connected");
    }

    public CommandResult ListDirectory(int depth)
    {
        return new CommandResult.Failure("Not connected");
    }

    public CommandResult ChangeDirectory(FilePath path)
    {
        return new CommandResult.Failure("Not connected");
    }

    public CommandResult ShowFile(FilePath path)
    {
        return new CommandResult.Failure("Not connected");
    }

    public CommandResult MoveFile(FilePath source, FilePath destination)
    {
        return new CommandResult.Failure("Not connected");
    }

    public CommandResult CopyFile(FilePath source, FilePath destination)
    {
        return new CommandResult.Failure("Not connected");
    }

    public CommandResult DeleteFile(FilePath path)
    {
        return new CommandResult.Failure("Not connected");
    }

    public CommandResult RenameFile(FilePath path, string newName)
    {
        return new CommandResult.Failure("Not connected");
    }
}