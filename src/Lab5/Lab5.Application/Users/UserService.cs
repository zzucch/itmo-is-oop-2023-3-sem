using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Contracts.Results;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Users;

namespace Lab5.Application.Users;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(
        IUserRepository userRepository,
        CurrentUserManager currentUserManager,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        _userRepository = userRepository;
        _currentUserManager = currentUserManager;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public LoginResult Login(string username, string password)
    {
        User? user = _userRepository.FindUserByName(username);

        if (user is null)
        {
            return new LoginResult.Failure();
        }

        if (string.Equals(password, user.Password, StringComparison.Ordinal) is false)
        {
            return new LoginResult.Failure();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public LoginResult ChangeAccount(long id, string password)
    {
        if (_currentUserManager.User is null)
        {
            return new LoginResult.Failure();
        }

        Account? account = _accountRepository.FindAccountById(id);

        if (account is null)
        {
            return new LoginResult.Failure();
        }

        if (string.Equals(password, account.Password, StringComparison.Ordinal) is false)
        {
            return new LoginResult.Failure();
        }

        _currentUserManager.CurrentAccountService = new CurrentAccountManager(
            account,
            _accountRepository,
            _transactionRepository);

        return new LoginResult.Success();
    }

    public BalanceResult GetBalance()
    {
        return _currentUserManager.CurrentAccountService is null
            ? new BalanceResult.Failure()
            : _currentUserManager.CurrentAccountService.GetBalance();
    }

    public TransactionResult WithdrawMoney(decimal amount)
    {
        return _currentUserManager.CurrentAccountService is null
            ? new TransactionResult.Failure()
            : _currentUserManager.CurrentAccountService.WithdrawMoney(amount);
    }

    public TransactionResult ReplenishMoney(decimal amount)
    {
        return _currentUserManager.CurrentAccountService is null
            ? new TransactionResult.Failure()
            : _currentUserManager.CurrentAccountService.ReplenishMoney(amount);
    }

    public TransactionsLogResult GetTransactionsLog()
    {
        return _currentUserManager.CurrentAccountService is null
            ? new TransactionsLogResult.Failure()
            : _currentUserManager.CurrentAccountService.GetTransactionsLog();
    }
}