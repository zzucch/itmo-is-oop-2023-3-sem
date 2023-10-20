using System.Collections.Generic;
using System.Linq;
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

public class Pc : IPc
{
    private readonly ICpuCoolingSystem _cpuCoolingSystem;
    private readonly ICpu _cpu;
    private readonly IGraphicsCard _graphicsCard;
    private readonly IReadOnlyList<IHdd> _hdds;
    private readonly IMotherboard _motherboard;
    private readonly IPcCase _pcCase;
    private readonly IPsu _psu;
    private readonly IReadOnlyList<IRam> _rams;
    private readonly IReadOnlyList<ISsd> _ssds;
    private readonly IWiFiAdapter _wifiAdapter;

    public Pc(
        ICpuCoolingSystem cpuCoolingSystem,
        ICpu cpu,
        IGraphicsCard graphicsCard,
        IEnumerable<IHdd> hdds,
        IMotherboard motherboard,
        IPcCase pcCase,
        IPsu psu,
        IEnumerable<IRam> rams,
        IEnumerable<ISsd> ssds,
        IWiFiAdapter wifiAdapter)
    {
        _cpuCoolingSystem = cpuCoolingSystem;
        _cpu = cpu;
        _graphicsCard = graphicsCard;
        _hdds = hdds.ToArray();
        _motherboard = motherboard;
        _pcCase = pcCase;
        _psu = psu;
        _rams = rams.ToArray();
        _ssds = ssds.ToArray();
        _wifiAdapter = wifiAdapter;
    }

    public IPcBuilder Direct(IPcBuilder builder)
    {
        builder
            .WithCpuCooling(_cpuCoolingSystem)
            .WithCpu(_cpu)
            .WithGraphicsCard(_graphicsCard)
            .WithMotherboard(_motherboard)
            .WithPcCase(_pcCase)
            .WithPsu(_psu)
            .WithWiFiAdapter(_wifiAdapter);

        foreach (IHdd hdd in _hdds)
        {
            builder.AddHdd(hdd);
        }

        foreach (IRam ram in _rams)
        {
            builder.AddRam(ram);
        }

        foreach (ISsd ssd in _ssds)
        {
            builder.AddSsd(ssd);
        }

        return builder;
    }
}