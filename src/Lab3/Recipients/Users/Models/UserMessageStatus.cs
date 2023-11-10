namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

public abstract record UserMessageStatus()
{
    public sealed record Read() : UserMessageStatus;

    public sealed record Unread() : UserMessageStatus;
}