using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;

public abstract record CommandResult
{
    private CommandResult() { }

    public abstract void Accept(ICommandResultVisitor visitor);

    public sealed record Success(object? Payload = null) : CommandResult
    {
        public override void Accept(ICommandResultVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed record Failure(string? Message = null) : CommandResult
    {
        public override void Accept(ICommandResultVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
