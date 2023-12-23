using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Models.Accounts;
using Lab5.Application.Models.Transactions;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TransactionTests
{
    [Fact]
    public void WithdrawMoney_ShouldWithdraw_WhenBalanceIsEnough()
    {
        // Arrange
        decimal amount = new(100);
        const int id = 10001;
        var account = new Account(Username: "username", Id: id, "password");

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository.GetBalance(Arg.Any<long>()).Returns(1000);

        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();

        ICurrentAccountService accountManager = new CurrentAccountManager(
            account,
            accountRepository,
            transactionRepository);

        // Act
        TransactionResult result = accountManager.WithdrawMoney(amount);

        // Assert
        Assert.True(result is TransactionResult.Success);
        accountRepository.Received().WithdrawMoney(id, amount);

        transactionRepository.Received().AddTransaction(id, new Transaction(
            amount,
            TransactionType.Withdrawal));
    }

    [Fact]
    public void WithdrawMoney_ShouldNotWithdraw_WhenBalanceIsNotEnough()
    {
        // Arrange
        decimal amount = new(10000);
        const int id = 10001;
        var account = new Account(Username: "username", Id: id, "password");

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository.GetBalance(Arg.Any<long>()).Returns(10);

        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();

        ICurrentAccountService accountManager = new CurrentAccountManager(
            account,
            accountRepository,
            transactionRepository);

        // Act
        TransactionResult result = accountManager.WithdrawMoney(amount);

        // Assert
        Assert.True(result is TransactionResult.Failure);
        accountRepository.DidNotReceive().WithdrawMoney(id, amount);

        transactionRepository.DidNotReceive().AddTransaction(id, new Transaction(
            amount,
            TransactionType.Withdrawal));
    }

    [Fact]
    public void ReplenishMoney_ShouldReplenishAccountMoney()
    {
        // Arrange
        decimal amount = new(10000);
        const int id = 10001;
        var account = new Account(Username: "username", Id: id, "password");

        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        accountRepository.GetBalance(Arg.Any<long>()).Returns(10);

        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();

        ICurrentAccountService accountManager = new CurrentAccountManager(
            account,
            accountRepository,
            transactionRepository);

        // Act
        TransactionResult result = accountManager.ReplenishMoney(amount);

        // Assert
        Assert.True(result is TransactionResult.Success);
        accountRepository.Received().ReplenishMoney(id, amount);

        transactionRepository.Received().AddTransaction(id, new Transaction(
            amount,
            TransactionType.Replenishment));
    }
}