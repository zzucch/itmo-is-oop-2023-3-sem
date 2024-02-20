using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class CustomerLoginScenario : IScenario
{
    private readonly IUserService _userService;

    public CustomerLoginScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Customer login";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username:");
        string password = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password:")
            .Secret());

        LoginResult result = _userService.Login(username, password);

        string message = result switch
        {
            LoginResult.Success => "Logged in.",
            LoginResult.Failure => "User not found.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}