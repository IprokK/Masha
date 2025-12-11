using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;

public interface INode
{
    string Name { get; }

    void Apply(IFileSystemVisitor visitor);
}
