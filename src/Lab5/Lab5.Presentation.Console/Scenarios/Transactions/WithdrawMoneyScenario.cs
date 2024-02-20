using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Transactions;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw account money";

    public void Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("How much to withdraw:");

        TransactionResult result = _userService.WithdrawMoney(amount);

        string message = result switch
        {
            TransactionResult.Success => "Successfully withdrawn.",
            TransactionResult.Failure => "Failed to withdraw.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}