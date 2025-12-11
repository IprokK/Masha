using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Visitors;

public interface IFileSystemVisitor
{
    void Visit(FileNode file);

    void Visit(DirectoryNode directory);
}