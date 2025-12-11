using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.Others;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Others;

public class ConnectParser : BaseParser
{
    private readonly IFlagParser<ConnectCommandOptions> _flagParser;

    public ConnectParser()
    {
        _flagParser = new ConnectModeFlagParser();
    }

    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "connect")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        var options = new ConnectCommandOptions(new FilePath(iterator.Current));

        while (iterator.MoveNext())
        {
            _flagParser.Handle(options, iterator);
        }

        return new ConnectCommand(options.Address, options.Mode);
    }
}

internal class ConnectCommandOptions
{
    public ConnectCommandOptions(FilePath address)
    {
        Address = address;
    }

    public FilePath Address { get; }

    public string Mode { get; set; } = "local";
}

internal class ConnectModeFlagParser : BaseFlagParser<ConnectCommandOptions>
{
    public override void Handle(ConnectCommandOptions options, ITokenIterator iterator)
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