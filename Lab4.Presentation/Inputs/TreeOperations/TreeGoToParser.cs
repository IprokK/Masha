using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.TreeOperations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.TreeOperations;

public class TreeGoToParser : BaseParser
{
    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "goto")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        string path = iterator.Current;

        return new TreeGoToCommand(new FilePath(path));
    }
}