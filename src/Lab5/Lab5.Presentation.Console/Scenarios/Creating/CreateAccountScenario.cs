using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Creating;

public class CreateAccountScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateAccountScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create account";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter new account owner's name:");
        string password = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password:")
            .Secret());

        CreateAccountResult result = _adminService.CreateAccount(username, password);

        string message = result switch
        {
            CreateAccountResult.Success success => $"Account created with ID {success.Id}.",
            CreateAccountResult.Failure => "Failed to create an account.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}