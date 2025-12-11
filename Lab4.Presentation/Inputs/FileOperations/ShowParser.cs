using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.FileOperations;

public class ShowParser : BaseParser
{
    private readonly IFlagParser<ShowCommandOptions> _flagParser;

    public ShowParser()
    {
        _flagParser = new ShowModeFlagParser();
    }

    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "show")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        string path = iterator.Current;

        var options = new ShowCommandOptions(new FilePath(path));

        while (iterator.MoveNext())
        {
            _flagParser.Handle(options, iterator);
        }

        return new ShowCommand(options.Path, options.Mode);
    }
}

internal class ShowCommandOptions
{
    public ShowCommandOptions(FilePath path)
    {
        Path = path;
    }

    public FilePath Path { get; }

    public string Mode { get; set; } = "console";
}

internal class ShowModeFlagParser : BaseFlagParser<ShowCommandOptions>
{
    public override void Handle(ShowCommandOptions options, ITokenIterator iterator)
    {
        if (iterator.Current != "-m")
        {
            CallNext(options, iterator);
            return;
        }

        if (!iterator.MoveNext())
        {
            throw new InvalidOperationException("Mode is not specified");
        }

        options.Mode = iterator.Current;
    }
}