using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Flags;

public interface IFlagParser<TOptions>
{
    IFlagParser<TOptions> AddNext(IFlagParser<TOptions> link);

    void Handle(TOptions options, ITokenIterator iterator);
}
