using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.States;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;

public interface IFileSystemContext
{
    void TransitionTo(IAppState state);

    void SetFileSystem(IFileSystem? fileSystem);

    IFileSystem? FileSystem { get; }

    IFileSystemFactory? FindFactory(string scheme);

    CommandResult Connect(FilePath address, string mode);

    CommandResult Disconnect();

    CommandResult ListDirectory(int depth);

    CommandResult ChangeDirectory(FilePath path);

    CommandResult ShowFile(FilePath path);

    CommandResult MoveFile(FilePath source, FilePath destination);

    CommandResult CopyFile(FilePath source, FilePath destination);

    CommandResult DeleteFile(FilePath path);

    CommandResult RenameFile(FilePath path, string newName);
}