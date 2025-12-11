using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;

public class FileNode : INode
{
    public string Name { get; }

    public FileNode(string name)
    {
        Name = name;
    }

    public void Apply(IFileSystemVisitor visitor)
    {
        visitor.Visit(this);
    }
}