using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.States;

public class ConnectState : IAppState
{
    private readonly IFileSystemContext _context;

    public ConnectState(IFileSystemContext context)
    {
        _context = context;
    }

    public CommandResult Connect(FilePath address, string mode)
    {
        return new CommandResult.Failure("Already connected");
    }

    public CommandResult Disconnect()
    {
        _context.SetFileSystem(null);
        _context.TransitionTo(new DisconnectState(_context));
        return new CommandResult.Success();
    }

    public CommandResult ListDirectory(int depth)
    {
        return _context.FileSystem is null
            ? new CommandResult.Failure("File system is unavailable")
            : _context.FileSystem.ListDirectory(depth);
    }

    public CommandResult ChangeDirectory(FilePath path)
    {
        return _context.FileSystem is null
            ? new CommandResult.Failure("File system is unavailable")
            : _context.FileSystem.ChangeDirectory(path);
    }

    public CommandResult ShowFile(FilePath path)
    {
        return _context.FileSystem is null
            ? new CommandResult.Failure("File system is unavailable")
            : _context.FileSystem.ShowFile(path);
    }

    public CommandResult MoveFile(FilePath source, FilePath destination)
    {
        return _context.FileSystem is null
            ? new CommandResult.Failure("File system is unavailable")
            : _context.FileSystem.MoveFile(source, destination);
    }

    public CommandResult CopyFile(FilePath source, FilePath destination)
    {
        return _context.FileSystem is null
            ? new CommandResult.Failure("File system is unavailable")
            : _context.FileSystem.CopyFile(source, destination);
    }

    public CommandResult DeleteFile(FilePath path)
    {
        return _context.FileSystem is null
            ? new CommandResult.Failure("File system is unavailable")
            : _context.FileSystem.DeleteFile(path);
    }

    public CommandResult RenameFile(FilePath path, string newName)
    {
        return _context.FileSystem is null
            ? new CommandResult.Failure("File system is unavailable")
            : _context.FileSystem.RenameFile(path, newName);
    }
}
