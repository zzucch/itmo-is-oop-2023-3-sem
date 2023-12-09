using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

public record RamTimings
{
    public RamTimings(int cl, int rcd, int rp, int ras)
    {
        if (cl <= 0 || rcd <= 0 || rp <= 0 || ras <= 0)
        {
            throw new ArgumentException("timings must be positive");
        }

        Cl = cl;
        Rcd = rcd;
        Rp = rp;
        Ras = ras;
    }

    public int Cl { get; }
    public int Rcd { get; }
    public int Rp { get; }
    public int Ras { get; }
}