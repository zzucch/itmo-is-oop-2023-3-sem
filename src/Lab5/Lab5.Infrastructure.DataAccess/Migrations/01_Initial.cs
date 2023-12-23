using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
#pragma warning disable SA1649
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type user_role as enum
    (
        'admin',
        'customer'
    );
    
    create type transaction_type as enum
    (
        'withdrawal',
        'replenishment'
    );
    
    create table users
    (
        user_id bigint primary key generated always as identity,
        user_name text not null,
        user_password text not null,
        user_role user_role not null
    );
    
    create table accounts
    (
        account_id bigint primary key generated always as identity,
        user_id bigint not null references users(user_id),
        account_balance numeric(100, 2) not null,
        account_password text not null
    );
    
    create table transactions
    (
        transaction_id bigint primary key generated always as identity,
        account_id bigint not null references accounts(account_id),
        transaction_amount numeric(100, 2) not null,
        transaction_type transaction_type not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table users cascade;
        drop table accounts cascade;
        drop table transactions cascade;

        drop type user_role;
        drop type transaction_type;
        """;
}
#pragma warning restore SA1649
