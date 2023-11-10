namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public abstract record UserMessageStatus()
{
    public sealed record Read() : UserMessageStatus;

    public sealed record Unread() : UserMessageStatus;
}