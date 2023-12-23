using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<UserRole>();
        builder.MapEnum<TransactionType>();
    }
}