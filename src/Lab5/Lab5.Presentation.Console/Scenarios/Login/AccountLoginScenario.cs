using Lab5.Application.Contracts.Results;
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

        LoginResult result = _userService.ChangeAccount(id, password);

        string message = result switch
        {
            LoginResult.Success => "Logged in.",
            LoginResult.Failure => "Invalid id or password.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}