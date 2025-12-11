using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ValueObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.FileOperations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.FileOperations;

public class RenameParser : BaseParser
{
    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "rename")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();
        string path = iterator.Current;

        iterator.MoveNext();
        string name = iterator.Current;

        return new RenameCommand(new FilePath(path), name);
    }
}