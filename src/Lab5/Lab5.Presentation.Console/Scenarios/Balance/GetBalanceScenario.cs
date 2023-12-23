using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Balance;

public class GetBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public GetBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Get account balance";

    public void Run()
    {
        BalanceResult result = _userService.GetBalance();

        string message = result switch
        {
            BalanceResult.Success success => $"Account Balance is {success.Balance}.",
            BalanceResult.Failure => "Failed to get the balance.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}