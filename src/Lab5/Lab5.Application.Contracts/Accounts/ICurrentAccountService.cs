using Lab5.Application.Contracts.Accounts.Results;

namespace Lab5.Application.Contracts.Accounts;

public interface ICurrentAccountService
{
    BalanceResult GetBalance();
    TransactionResult WithdrawMoney(decimal amount);
    TransactionResult ReplenishMoney(decimal amount);
    TransactionsLogResult GetTransactionsLog();
}