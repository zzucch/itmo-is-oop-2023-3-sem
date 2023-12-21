using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Accounts;

public class CurrentAccountManager : ICurrentAccountService
{
    private readonly Account _account;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public CurrentAccountManager(
        Account account,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        _account = account;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public BalanceResult GetBalance()
    {
        return new BalanceResult.Success(_accountRepository.GetBalance(_account.Id));
    }

    public TransactionResult WithdrawMoney(decimal amount)
    {
        decimal balance = _accountRepository.GetBalance(_account.Id);

        if (balance < amount)
        {
            return new TransactionResult.Failure();
        }

        _accountRepository.WithdrawMoney(_account.Id, amount);
        _transactionRepository.AddTransaction(
            _account.Id, new Transaction(amount, TransactionType.Withdrawal));

        return new TransactionResult.Success();
    }

    public TransactionResult ReplenishMoney(decimal amount)
    {
        _accountRepository.ReplenishMoney(_account.Id, amount);
        _transactionRepository.AddTransaction(
            _account.Id, new Transaction(amount, TransactionType.Replenishment));

        return new TransactionResult.Success();
    }

    public TransactionsLogResult GetTransactionsLog()
    {
        return new TransactionsLogResult.Success(
            _transactionRepository.GetAllAccountTransactions(_account.Id));
    }
}