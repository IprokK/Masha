using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Flags;

public abstract class BaseFlagParser<TOptions> : IFlagParser<TOptions>
{
    private IFlagParser<TOptions>? _next;

    public IFlagParser<TOptions> AddNext(IFlagParser<TOptions> link)
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

    public abstract void Handle(TOptions options, ITokenIterator iterator);

    protected void CallNext(TOptions options, ITokenIterator iterator)
    {
        _next?.Handle(options, iterator);
    }
}
