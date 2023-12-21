using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Contracts.Results;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username, string password);
    LoginResult ChangeAccount(long id, string password);
    BalanceResult GetBalance();
    TransactionResult WithdrawMoney(decimal amount);
    TransactionResult ReplenishMoney(decimal amount);
    TransactionsLogResult GetTransactionsLog();
}