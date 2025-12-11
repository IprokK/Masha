using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.FileOperations;

public class DeleteParser : BaseParser
{
    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "delete")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        string path = iterator.Current;

        return new DeleteCommand(new FilePath(path));
    }
}