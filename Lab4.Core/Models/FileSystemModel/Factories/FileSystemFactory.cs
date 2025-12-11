using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Factories;

public class FileSystemFactory : IFileSystemFactory
{
    public string Scheme => "local";

    public IFileSystem Create(string path)
    {
        return new FileSystem(path);
    }
}