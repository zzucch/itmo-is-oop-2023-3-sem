namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

public abstract record CompatibilityCheckResult
{
    private CompatibilityCheckResult() { }

    public sealed record Success() : CompatibilityCheckResult;

    public sealed record WarrantyDisclaimed(string Comment) : CompatibilityCheckResult;

    public sealed record Failure(string Comment) : CompatibilityCheckResult;
}