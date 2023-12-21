using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Accounts;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? FindAccountById(long id)
    {
        throw new NotImplementedException();
    }

    public void AddAccount(Account account)
    {
        throw new NotImplementedException();
    }

    public decimal GetBalance(long id)
    {
        throw new NotImplementedException();
    }

    public void WithdrawMoney(long id, decimal amount)
    {
        throw new NotImplementedException();
    }

    public void ReplenishMoney(long id, decimal amount)
    {
        throw new NotImplementedException();
    }
}