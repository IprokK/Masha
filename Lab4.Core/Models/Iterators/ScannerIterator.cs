using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.FileSystemModel.Nodes;
using System.Collections;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;

public class ScannerIterator : IEnumerator<INode>
{
    private readonly FileSystemInfo[] _fileSystemInfos;
    private readonly int _depthLimit;
    private readonly int _currentLevel;
    private int _currentIndex;

    public ScannerIterator(string rootPath, int depthLimit, int currentLevel)
    {
        _depthLimit = depthLimit;
        _currentLevel = currentLevel;
        _currentIndex = -1;

        bool shouldScan = Directory.Exists(rootPath) && _currentLevel < _depthLimit;

        _fileSystemInfos = shouldScan
            ? new DirectoryInfo(rootPath).GetFileSystemInfos()
            : Array.Empty<FileSystemInfo>();
    }

    public INode Current => _currentIndex >= 0 && _currentIndex < _fileSystemInfos.Length
        ? MapToNode(_fileSystemInfos[_currentIndex])
        : throw new InvalidOperationException("Iterator is out of bounds.");

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_currentIndex < _fileSystemInfos.Length)
        {
            _currentIndex++;
        }

        return _currentIndex < _fileSystemInfos.Length;
    }

    public void Reset()
    {
        _currentIndex = -1;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    private INode MapToNode(FileSystemInfo info)
    {
        return info switch
        {
            DirectoryInfo => new DirectoryNode(
                info.Name,
                new DirectoryScanner(info.FullName, _depthLimit, _currentLevel + 1)),

            _ => new FileNode(info.Name),
        };
    }
}