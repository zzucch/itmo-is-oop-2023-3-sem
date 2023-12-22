using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class AccountLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public AccountLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Account login";

    public void Run()
    {
        long id = AnsiConsole.Ask<long>("Enter your account id:");
        string password = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password:")
            .Secret());

        _userService.ChangeAccount(id, password);
    }
}