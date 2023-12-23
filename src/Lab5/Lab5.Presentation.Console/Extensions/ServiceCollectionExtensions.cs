using Lab5.Presentation.Console.Scenarios.Balance;
using Lab5.Presentation.Console.Scenarios.Creating;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CustomerLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AccountLoginScenarioProvider>();

        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();

        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateUserScenarioProvider>();

        collection.AddScoped<IScenarioProvider, GetTransactionHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ReplenishMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();

        return collection;
    }
}