using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;
using System.Collections;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;

public class DirectoryScanner : IEnumerable<INode>
{
    private readonly string _rootPath;
    private readonly int _limit;
    private readonly int _startDepth;

    public DirectoryScanner(string path, int maxDepth, int currentDepth = 0)
    {
        _rootPath = path;
        _limit = maxDepth;
        _startDepth = currentDepth;
    }

    public IEnumerator<INode> GetEnumerator()
    {
        return new ScannerIterator(_rootPath, _limit, _startDepth);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}