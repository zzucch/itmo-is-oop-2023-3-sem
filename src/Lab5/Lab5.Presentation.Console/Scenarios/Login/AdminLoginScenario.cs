using Lab5.Application.Contracts.Users;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Admin login";

    public void Run()
    {
        string password = AnsiConsole.Prompt(new TextPrompt<string>("Enter your password:")
            .Secret());

        LoginResult result = _adminService.Login(password);

        string message = result switch
        {
            LoginResult.Success => "Logged in as admin.",
            LoginResult.Failure => "Wrong password.",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}