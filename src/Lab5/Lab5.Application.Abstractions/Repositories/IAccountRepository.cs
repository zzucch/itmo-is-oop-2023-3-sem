using Lab5.Application.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account? FindAccountById(long id);
    void AddAccount(Account account);
    decimal GetBalance(long id);
    void WithdrawMoney(long id, decimal amount);
    void ReplenishMoney(long id, decimal amount);
}