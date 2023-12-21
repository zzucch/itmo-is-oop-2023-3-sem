namespace Lab5.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string password);
    CreateResult CreateUser(string username, string password);
    CreateResult CreateAccount(string username, long id, string password);
}