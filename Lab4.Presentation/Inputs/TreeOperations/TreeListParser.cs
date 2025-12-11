using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.TreeOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.TreeOperations;

public class TreeListParser : BaseParser
{
    private readonly IFlagParser<TreeListCommandOptions> _flagParser;

    public TreeListParser()
    {
        _flagParser = new TreeListDepthFlagParser();
    }

    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "list")
        {
            return CallNext(iterator);
        }

        var options = new TreeListCommandOptions();

        while (iterator.MoveNext())
        {
            _flagParser.Handle(options, iterator);
        }

        return new TreeListCommand(options.Depth);
    }
}

internal class TreeListCommandOptions
{
    public int Depth { get; set; } = 1;
}

internal class TreeListDepthFlagParser : BaseFlagParser<TreeListCommandOptions>
{
    public override void Handle(TreeListCommandOptions options, ITokenIterator iterator)
    {
        if (iterator.Current != "-d")
        {
            CallNext(options, iterator);
            return;
        }

        if (!iterator.MoveNext())
        {
            throw new InvalidOperationException("Depth is not specified");
        }

        options.Depth = int.Parse(iterator.Current);
    }
}