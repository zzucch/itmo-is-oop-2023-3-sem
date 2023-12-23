using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Users;
using Lab5.Application.Users;

namespace Lab5.Application.Admins;

internal class AdminService : IAdminService
{
    private readonly CurrentUserManager _currentUserManager;
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;

    public AdminService(
        IAccountRepository accountRepository,
        CurrentUserManager currentUserManager,
        IUserRepository userRepository)
    {
        _accountRepository = accountRepository;
        _currentUserManager = currentUserManager;
        _userRepository = userRepository;
    }

    public LoginResult Login(string password)
    {
        User? user = _userRepository.TryAdminLogin(password);

        if (user is null)
        {
            return new LoginResult.Failure();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public CreateUserResult CreateUser(string username, string password)
    {
        _userRepository.AddUser(new User(username, password, UserRole.Customer));
        return new CreateUserResult.Success();
    }

    public CreateAccountResult CreateAccount(string username, string password)
    {
        Account? account = _accountRepository.AddAccount(username, password);

        if (account is null)
        {
            return new CreateAccountResult.Failure();
        }

        return new CreateAccountResult.Success(account.Id);
    }
}