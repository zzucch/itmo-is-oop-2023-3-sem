namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

public abstract record RamFormFactor
{
    public sealed record SoDimm : RamFormFactor;

    public sealed record Dimm : RamFormFactor;
}