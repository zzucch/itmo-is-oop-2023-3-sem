using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    User? FindAccountById(long id);
    void AddAccount(Account account);
}