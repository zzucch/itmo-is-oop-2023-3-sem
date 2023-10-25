using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public interface IRam : IRamBuilderDirector
{
    public int DdrVersion { get; }
    public decimal PowerConsumption { get; }
    public IReadOnlyList<IXmp> Xmps { get; }
    public IReadOnlyList<JedecProfile> JedecProfiles { get; }
}