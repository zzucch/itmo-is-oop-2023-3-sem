using System.Globalization;
using System.Text;
using Lab5.Application.Contracts.Accounts.Results;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Transactions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Transactions;

public class GetTransactionHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public GetTransactionHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Get transactions history";

    public void Run()
    {
        TransactionsLogResult result = _userService.GetTransactionsLog();

        string message;
        switch (result)
        {
            case TransactionsLogResult.Success success:
                var builder = new StringBuilder();

                builder.AppendLine("Transaction history:");

                foreach (Transaction transaction in success.Transactions)
                {
                    switch (transaction.Type)
                    {
                        case TransactionType.Withdrawal:
                            builder.Append("Withdrawn ");
                            break;
                        case TransactionType.Replenishment:
                            builder.Append("Replenished ");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    builder.Append(
                        CultureInfo.InvariantCulture,
                        $"Amount: {transaction.Amount}");
                }

                message = builder.ToString();

                break;
            case TransactionsLogResult.Failure:
                message = "Failed to replenish.";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(result));
        }

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}