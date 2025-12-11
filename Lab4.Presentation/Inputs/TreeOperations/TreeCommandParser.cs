using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.TreeOperations;

public class TreeCommandParser : BaseParser
{
    private readonly TreeListParser _subChain;

    public TreeCommandParser()
    {
        var list = new TreeListParser();
        list.AddNext(new TreeGoToParser());
        _subChain = list;
    }

    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "tree")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        return _subChain.Handle(iterator);
    }
}