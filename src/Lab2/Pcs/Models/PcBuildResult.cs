using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Models;

public abstract record PcBuildResult
{
    public sealed record Success(IPc Pc) : PcBuildResult;

    public sealed record WarrantyDisclaimed(IPc Pc, IReadOnlyCollection<string> Comments) : PcBuildResult;

    public sealed record Failure(IReadOnlyCollection<string> Comments) : PcBuildResult;
}