using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;

public interface IPc : IPcBuilderDirector
{
    public ICpuCoolingSystem CpuCoolingSystem { get; }
    public ICpu Cpu { get; }
    public IGraphicsCard? GraphicsCard { get; }
    public IReadOnlyList<IHdd> Hdds { get; }
    public IMotherboard Motherboard { get; }
    public IPcCase PcCase { get; }
    public IPsu Psu { get; }
    public IReadOnlyList<IRam> Rams { get; }
    public IReadOnlyList<ISsd> Ssds { get; }
    public IWiFiAdapter? WiFiAdapter { get; }
}