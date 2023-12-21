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
        long id = AnsiConsole.Ask<long>("Enter new account ID:");
        string password = AnsiConsole.Ask<string>("Enter the password:");

        LoginResult result = _adminService.CreateAccount(username, id, password);

        string message = result switch
        {
            LoginResult.Success => "Account created.",
            LoginResult.NotFound => "Failed to create an account.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}