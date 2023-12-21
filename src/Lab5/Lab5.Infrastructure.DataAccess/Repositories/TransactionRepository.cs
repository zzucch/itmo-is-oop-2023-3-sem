using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    public IEnumerable<Transaction> GetAllAccountTransactions(long accountId)
    {
        throw new NotImplementedException();
    }

    public void AddTransaction(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}