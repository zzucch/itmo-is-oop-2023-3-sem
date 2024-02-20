using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Transactions;

public class ReplenishMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public ReplenishMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Replenish account money";

    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("How much to replenish:");

        TransactionResult result = _userService.ReplenishMoney(amount);

        string message = result switch
        {
            TransactionResult.Success => "Successfully replenish.",
            TransactionResult.Failure => "Failed to replenish.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}