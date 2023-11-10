namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Displays.Models;

public abstract record DisplayMessageResult
{
    public sealed record Success() : DisplayMessageResult;

    public sealed record Failure() : DisplayMessageResult;
}