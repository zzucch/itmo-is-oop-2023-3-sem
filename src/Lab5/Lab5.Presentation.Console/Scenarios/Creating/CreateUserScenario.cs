using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Creating;

public class CreateUserScenario : IScenario
{
    private readonly IAdminService _adminService;

    public CreateUserScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Create user";

    public void Run()
    {
        string username = AnsiConsole.Ask<string>("Enter username:");
        string password = AnsiConsole.Ask<string>("Enter the password:");

        CreateUserResult result = _adminService.CreateUser(username, password);

        string message = result switch
        {
            CreateUserResult.Success => "User created.",
            CreateUserResult.Failure => "Failed to create the user.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}