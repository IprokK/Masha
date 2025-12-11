namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;

public class TokenIterator : ITokenIterator
{
    private readonly List<string> _tokens;
    private int _index;

    public TokenIterator(IEnumerable<string> tokens)
    {
        _tokens = tokens.ToList() ?? throw new ArgumentNullException(nameof(tokens));
        _index = -1;
    }

    public string Current => IsValidPosition
        ? _tokens[_index]
        : throw new InvalidOperationException("No current token available.");

    private bool IsValidPosition => _index >= 0 && _index < _tokens.Count;

    public bool MoveNext()
    {
        _index++;
        return _index < _tokens.Count;
    }
}