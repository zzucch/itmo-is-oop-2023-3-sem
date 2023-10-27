namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

public abstract record PcCompatibilityCheckResult
{
    private PcCompatibilityCheckResult() { }

    public sealed record Success() : PcCompatibilityCheckResult;

    public sealed record WarrantyDisclaimed(string Comment) : PcCompatibilityCheckResult;

    public sealed record Failure(string Comment) : PcCompatibilityCheckResult;
}