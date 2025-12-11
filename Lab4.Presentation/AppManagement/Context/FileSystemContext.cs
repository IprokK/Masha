using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.States;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;

public class FileSystemContext : IFileSystemContext
{
    private IAppState _state;
    private IFileSystem? _fileSystem;
    private readonly IReadOnlyCollection<IFileSystemFactory> _factories;

    public FileSystemContext()
    {
        _factories = new List<IFileSystemFactory> { new FileSystemFactory() };
        _state = new DisconnectState(this);
    }

    public IFileSystem? FileSystem => _fileSystem;

    public void TransitionTo(IAppState state)
    {
        _state = state;
    }

    public void SetFileSystem(IFileSystem? fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IFileSystemFactory? FindFactory(string scheme)
    {
        return _factories.FirstOrDefault(factory => factory.Scheme == scheme);
    }

    public CommandResult Connect(FilePath address, string mode)
    {
        return _state.Connect(address, mode);
    }

    public CommandResult Disconnect()
    {
        return _state.Disconnect();
    }

    public CommandResult ListDirectory(int depth)
    {
        return _state.ListDirectory(depth);
    }

    public CommandResult ChangeDirectory(FilePath path)
    {
        return _state.ChangeDirectory(path);
    }

    public CommandResult ShowFile(FilePath path)
    {
        return _state.ShowFile(path);
    }

    public CommandResult MoveFile(FilePath source, FilePath destination)
    {
        return _state.MoveFile(source, destination);
    }

    public CommandResult CopyFile(FilePath source, FilePath destination)
    {
        return _state.CopyFile(source, destination);
    }

    public CommandResult DeleteFile(FilePath path)
    {
        return _state.DeleteFile(path);
    }

    public CommandResult RenameFile(FilePath path, string newName)
    {
        return _state.RenameFile(path, newName);
    }
}