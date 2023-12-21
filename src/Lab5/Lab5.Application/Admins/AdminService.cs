using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;

namespace Lab5.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _repository;

    public AdminService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public LoginResult Login(string password)
    {
        throw new NotImplementedException();
    }

    public LoginResult CreateUser(string username, string password)
    {
        throw new NotImplementedException();
    }

    public LoginResult CreateAccount(string username, long id, string password)
    {
        throw new NotImplementedException();
    }
}