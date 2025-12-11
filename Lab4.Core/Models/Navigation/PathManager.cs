using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Navigation;

public class PathManager
{
    public FilePath Manage(FilePath currentPath, FilePath inputPath)
    {
        string basePath = currentPath.Value;
        string target = inputPath.Value;

        string rawSequence = target.StartsWith('/')
            ? target
            : $"{basePath}/{target}";

        var segments = new List<string>();
        string[] tokens = rawSequence.Split('/', StringSplitOptions.RemoveEmptyEntries);

        foreach (string token in tokens)
        {
            if (token == "..")
            {
                if (segments.Count > 0)
                {
                    segments.RemoveAt(segments.Count - 1);
                }
            }
            else if (token != ".")
            {
                segments.Add(token);
            }
        }

        string finalPath = "/" + string.Join("/", segments);

        return new FilePath(finalPath);
    }
}