using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.States;

public interface IAppState
{
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