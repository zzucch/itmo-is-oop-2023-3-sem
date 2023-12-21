using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Results;

namespace Lab5.Application.Accounts;

public class CurrentAccountManager : ICurrentAccountService
{
    public BalanceResult GetBalance()
    {
        throw new NotImplementedException();
    }

    public TransactionResult WithdrawMoney(decimal amount)
    {
        throw new NotImplementedException();
    }

    public TransactionResult ReplenishMoney(decimal amount)
    {
        throw new NotImplementedException();
    }

    public TransactionsLogResult GetTransactionsLog()
    {
        throw new NotImplementedException();
    }
}