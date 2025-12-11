using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Navigation;

public class PathManager
{
    private readonly IReadOnlyList<string> _rootSegments;

    public PathManager(FilePath rootPath)
    {
        _rootSegments = ParseSegments(rootPath.Value);
    }

    public PathManager(string rootPath)
        : this(new FilePath(rootPath))
    {
    }

    public FilePath Manage(FilePath currentPath, FilePath inputPath)
    {
        string target = inputPath.Value;
        bool isAbsolute = target.StartsWith('/');

        List<string> segments = isAbsolute || !IsWithinRoot(currentPath)
            ? new List<string>(_rootSegments)
            : new List<string>(ParseSegments(currentPath.Value));

        List<string> tokens = ParseSegments(target);

        if (isAbsolute && StartsWithRoot(tokens))
        {
            tokens = tokens.Skip(_rootSegments.Count).ToList();
        }

        foreach (string token in tokens)
        {
            if (token == "..")
            {
                if (segments.Count > _rootSegments.Count)
                {
                    segments.RemoveAt(segments.Count - 1);
                }

                continue;
            }

            if (token == ".")
            {
                continue;
            }

            segments.Add(token);
        }

        string finalPath = "/" + string.Join("/", segments);
        return new FilePath(finalPath);
    }

    private static List<string> ParseSegments(string path)
    {
        return path
            .Split('/', StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }

    private bool StartsWithRoot(IReadOnlyList<string> tokens)
    {
        if (tokens.Count < _rootSegments.Count) return false;

        for (int i = 0; i < _rootSegments.Count; i++)
        {
            if (!string.Equals(tokens[i], _rootSegments[i], StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    private bool IsWithinRoot(FilePath currentPath)
    {
        List<string> currentSegments = ParseSegments(currentPath.Value);

        if (currentSegments.Count < _rootSegments.Count)
        {
            return false;
        }

        for (int i = 0; i < _rootSegments.Count; i++)
        {
            if (!string.Equals(currentSegments[i], _rootSegments[i], StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }
}
