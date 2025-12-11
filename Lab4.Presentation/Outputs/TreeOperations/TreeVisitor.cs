using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.TreeOperations;

public class TreeVisitor : IFileSystemVisitor
{
    private const string Space = " ";
    private const string FileIcon = "[File]";
    private const string FolderIcon = "[Folder]";
    private int _depth;

    public void Visit(FileNode file)
    {
        PrintWithSpace($"{FileIcon} {file.Name}");
    }

    public void Visit(DirectoryNode directory)
    {
        PrintWithSpace($"{FolderIcon} {directory.Name}");

        _depth++;
        foreach (INode component in directory.Nodes)
        {
            component.Apply(this);
        }

        _depth--;
    }

    private void PrintWithSpace(string text)
    {
        string space = string.Concat(Enumerable.Repeat(Space, _depth));
        Console.WriteLine($"{space}{text}");
    }
}