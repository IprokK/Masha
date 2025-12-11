using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.TreeOperations;

public class TreeVisitor : IFileSystemVisitor
{
    private readonly TreeViewSettings _settings;
    private int _depth;

    public TreeVisitor(TreeViewSettings? settings = null)
    {
        _settings = settings ?? TreeViewSettings.Default;
    }

    public void Visit(FileNode file)
    {
        PrintWithSpace($"{_settings.FileIcon} {file.Name}");
    }

    public void Visit(DirectoryNode directory)
    {
        PrintWithSpace($"{_settings.FolderIcon} {directory.Name}");

        _depth++;
        foreach (INode component in directory.Nodes)
        {
            component.Apply(this);
        }

        _depth--;
    }

    private void PrintWithSpace(string text)
    {
        string space = string.Concat(Enumerable.Repeat(_settings.IndentationSymbol, _depth));
        Console.WriteLine($"{space}{text}");
    }
}
