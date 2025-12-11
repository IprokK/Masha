using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs;

public interface IParser
{
    IParser AddNext(IParser link);

    ICommand Handle(ITokenIterator iterator);
}