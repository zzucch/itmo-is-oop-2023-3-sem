using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Users;

namespace Lab5.Presentation.Console.Scenarios.Transactions;

public class GetTransactionHistoryScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;

    public GetTransactionHistoryScenarioProvider(
        IUserService userService, ICurrentUserService currentUser)
    {
        _userService = userService;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null || _currentUser.User.Role is not UserRole.Customer)
        {
            scenario = null;
            return false;
        }

        scenario = new GetTransactionHistoryScenario(_userService);
        return true;
    }
}