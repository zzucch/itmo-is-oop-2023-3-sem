using Itmo.ObjectOrientedProgramming.Lab4.Execution.CommandContexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Commands;

public interface ICommand
{
    void Execute(CommandContext context);
}