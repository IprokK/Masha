using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;

public class DirectoryNode : INode
{
    public string Name { get; }

    public IEnumerable<INode> Nodes { get; }

    public DirectoryNode(string name, IEnumerable<INode> nodes)
    {
        Name = name;
        Nodes = nodes;
    }

    public void Apply(IFileSystemVisitor visitor)
    {
        visitor.Visit(this);
    }
}