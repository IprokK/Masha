using Itmo.ObjectOrientedProgramming.Lab4.Core.Models.Iterators;
using Itmo.ObjectOrientedProgramming.Lab4.Core.ResultTypes.Types;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.AppManagement.Context;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.FileOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.Others;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Inputs.TreeOperations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Operations;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public static class Program
{
    public static void Main()
    {
        IFileSystemContext context = new FileSystemContext();

        var parserChain = new ConnectParser();
        parserChain
            .AddNext(new DisconnectParser())
            .AddNext(new TreeCommandParser())
            .AddNext(new FileCommandParser());

        while (true)
        {
            string? input = Console.ReadLine();

            if (input is null)
            {
                break;
            }

            string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var iterator = new TokenIterator(arguments);

            if (!iterator.MoveNext()) continue;
            try
            {
                ICommand command = parserChain.Handle(iterator);
                CommandResult result = command.Execute(context);
                var drawer = CommandDrawerResolver.Resolve(command);
                result.Accept(drawer);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error: {exception.Message}");
            }
        }
    }
}