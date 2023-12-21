using Lab5.Application.Contracts.Results;

namespace Lab5.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string password);
    CreateUserResult CreateUser(string username, string password);
    CreateAccountResult CreateAccount(string username, string password);
}