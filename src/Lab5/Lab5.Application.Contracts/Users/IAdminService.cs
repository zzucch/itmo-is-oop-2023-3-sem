namespace Lab5.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string password);
    LoginResult CreateUser(string username, string password);
    LoginResult CreateAccount(string username, long id, string password);
}