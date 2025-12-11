namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs.TreeOperations;

public record TreeViewSettings(string FileIcon, string FolderIcon, string IndentationSymbol)
{
    public static TreeViewSettings Default { get; } = new("[File]", "[Folder]", " ");
}
