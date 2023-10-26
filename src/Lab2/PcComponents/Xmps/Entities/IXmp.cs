using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public interface IXmp : IXmpBuilderDirector
{
    public RamFrequency Frequency { get; }
}