using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Types;

public interface IFileSystem
{
    CommandResult ListDirectory(int depth);

    CommandResult ChangeDirectory(FilePath path);

    CommandResult CopyFile(FilePath source, FilePath destination);

    CommandResult DeleteFile(FilePath path);

    CommandResult MoveFile(FilePath source, FilePath destination);

    CommandResult RenameFile(FilePath path, string newName);

    CommandResult ShowFile(FilePath path);
}