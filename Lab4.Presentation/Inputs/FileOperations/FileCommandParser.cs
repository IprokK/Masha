using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.FileOperations;

public class FileCommandParser : BaseParser
{
    private readonly ShowParser _subChain;

    public FileCommandParser()
    {
        var show = new ShowParser();
        show.AddNext(new MoveParser())
            .AddNext(new CopyParser())
            .AddNext(new DeleteParser())
            .AddNext(new RenameParser());
        _subChain = show;
    }

    public override ICommand Handle(ITokenIterator iterator)
    {
        if (iterator.Current != "file")
        {
            return CallNext(iterator);
        }

        iterator.MoveNext();

        return _subChain.Handle(iterator);
    }
}