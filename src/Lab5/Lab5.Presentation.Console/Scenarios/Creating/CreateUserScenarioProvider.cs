using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Presentation.Console.Scenarios.Creating;

public class CreateUserScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentUserService _currentUser;

    public CreateUserScenarioProvider(
        IAdminService adminService, ICurrentUserService currentUser)
    {
        _adminService = adminService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.User.Role is not UserRole.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new CreateUserScenario(_adminService);
        return true;
    }
}