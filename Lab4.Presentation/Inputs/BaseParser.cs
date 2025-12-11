using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs;

public abstract class BaseParser : IParser
{
    private IParser? _next;

    public IParser AddNext(IParser link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    public abstract ICommand Handle(ITokenIterator iterator);

    protected ICommand CallNext(ITokenIterator iterator)
    {
        return _next is not null ? _next.Handle(iterator) : throw new InvalidOperationException("Unknown command");
    }
}