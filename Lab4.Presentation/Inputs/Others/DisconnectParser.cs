using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations.Others;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Others;

public class DisconnectParser : BaseParser
{
    public override ICommand Handle(ITokenIterator iterator)
    {
        return iterator.Current != "disconnect" ? CallNext(iterator) : new DisconnectCommand();
    }
}