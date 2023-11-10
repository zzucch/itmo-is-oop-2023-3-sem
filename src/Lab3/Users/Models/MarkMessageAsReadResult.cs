namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public abstract record MarkMessageAsReadResult
{
    public sealed record Success() : MarkMessageAsReadResult;

    public sealed record Failure() : MarkMessageAsReadResult;
}