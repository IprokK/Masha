using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Navigation;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Types;

public class FileSystem : IFileSystem
{
    private readonly PathManager _navigator;
    private FilePath _workingDirectory;

    public FileSystem(string rootPath)
    {
        _navigator = new PathManager(rootPath);
        _workingDirectory = new FilePath(rootPath);
    }

    public CommandResult ListDirectory(int depth)
    {
        var dirInfo = new DirectoryInfo(_workingDirectory.Value);

        if (!dirInfo.Exists)
        {
            return new CommandResult.Failure("Directory does not exist");
        }

        var scanner = new DirectoryScanner(dirInfo.FullName, depth, 0);
        return new CommandResult.Success(new DirectoryNode(dirInfo.Name, scanner));
    }

    public CommandResult ChangeDirectory(FilePath path)
    {
        FilePath targetPath = _navigator.Manage(_workingDirectory, path);

        if (!Directory.Exists(targetPath.Value)) return new CommandResult.Failure("Path not found");
        _workingDirectory = targetPath;
        return new CommandResult.Success();
    }

    public CommandResult CopyFile(FilePath source, FilePath destination)
    {
        string srcPath  = GetAbsolutePath(source);
        string destPath = GetAbsolutePath(destination);

        if (!File.Exists(srcPath))
            return new CommandResult.Failure("Source file does not exist");

        if (!Directory.Exists(destPath))
            return new CommandResult.Failure("Destination directory does not exist");

        string fileName       = Path.GetFileName(srcPath);
        string targetFilePath = Path.Combine(destPath, fileName);

        if (File.Exists(targetFilePath))
            return new CommandResult.Failure("Destination file already exists");

        try
        {
            File.Copy(srcPath, targetFilePath);
            return new CommandResult.Success();
        }
        catch (Exception ex)
        {
            return new CommandResult.Failure($"Copy operation failed: {ex.Message}");
        }
    }

    public CommandResult DeleteFile(FilePath path)
    {
        string target = GetAbsolutePath(path);

        if (!File.Exists(target))
        {
            return new CommandResult.Failure("File not found");
        }

        File.Delete(target);
        return new CommandResult.Success();
    }

    public CommandResult MoveFile(FilePath source, FilePath destination)
    {
        string srcPath  = GetAbsolutePath(source);
        string destPath = GetAbsolutePath(destination);

        if (!File.Exists(srcPath))
            return new CommandResult.Failure("Source file does not exist");

        if (!Directory.Exists(destPath))
            return new CommandResult.Failure("Destination directory does not exist");

        string fileName       = Path.GetFileName(srcPath);
        string targetFilePath = Path.Combine(destPath, fileName);

        if (File.Exists(targetFilePath))
            return new CommandResult.Failure("Destination file already exists");

        try
        {
            File.Move(srcPath, targetFilePath);
            return new CommandResult.Success();
        }
        catch (Exception ex)
        {
            return new CommandResult.Failure($"Move operation failed: {ex.Message}");
        }
    }


    public CommandResult RenameFile(FilePath path, string newName)
    {
        var oldFile = new FileInfo(GetAbsolutePath(path));

        if (!oldFile.Exists || oldFile.DirectoryName == null)
        {
            return new CommandResult.Failure("File not found");
        }

        string newFullPath = Path.Combine(oldFile.DirectoryName, newName);

        if (File.Exists(newFullPath))
        {
            return new CommandResult.Failure("Target file already exists");
        }

        oldFile.MoveTo(newFullPath);
        return new CommandResult.Success();
    }

    public CommandResult ShowFile(FilePath path)
    {
        string fullPath = GetAbsolutePath(path);
        var fileInfo = new FileInfo(fullPath);

        return fileInfo.Exists
            ? new CommandResult.Success(File.ReadAllText(fileInfo.FullName))
            : new CommandResult.Failure("File not found");
    }

    private string GetAbsolutePath(FilePath relativePath)
    {
        return _navigator.Manage(_workingDirectory, relativePath).Value;
    }
}