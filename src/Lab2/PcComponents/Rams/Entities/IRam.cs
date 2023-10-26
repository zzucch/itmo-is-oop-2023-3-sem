using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public interface IRam : IRamBuilderDirector
{
    public RamDdrVersion DdrVersion { get; }
    public PowerConsumption PowerConsumption { get; }
    public IReadOnlyList<IXmp> Xmps { get; }
    public IReadOnlyList<JedecProfile> JedecProfiles { get; }
}