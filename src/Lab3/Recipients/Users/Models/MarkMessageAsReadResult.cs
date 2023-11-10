namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

public abstract record MarkMessageAsReadResult
{
    public sealed record Success() : MarkMessageAsReadResult;

    public sealed record Failure() : MarkMessageAsReadResult;
}