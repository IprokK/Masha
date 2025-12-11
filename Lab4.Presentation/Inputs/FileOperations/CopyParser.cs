using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.FileOperations;

public class CopyParser : BaseParser
{
    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "copy")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        string source = iterator.Current;

        iterator.MoveNext();
        string dest = iterator.Current;

        return new CopyCommand(new FilePath(source), new FilePath(dest));
    }
}