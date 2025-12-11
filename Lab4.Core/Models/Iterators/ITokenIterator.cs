namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;

public interface ITokenIterator
{
    string Current { get; }

    bool MoveNext();
}