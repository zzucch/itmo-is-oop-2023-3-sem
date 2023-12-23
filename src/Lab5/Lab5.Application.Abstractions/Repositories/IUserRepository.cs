using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByName(string username);
    User? TryAdminLogin(string password);
    void AddUser(User user);
}