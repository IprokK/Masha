using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.FileOperations;

public class MoveParser : BaseParser
{
    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "move")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        string source = iterator.Current;

        iterator.MoveNext();
        string dest = iterator.Current;

        return new MoveCommand(new FilePath(source), new FilePath(dest));
    }
}