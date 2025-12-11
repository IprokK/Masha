using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Types;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Factories;

public interface IFileSystemFactory
{
    string Scheme { get; }

    IFileSystem Create(string path);
}