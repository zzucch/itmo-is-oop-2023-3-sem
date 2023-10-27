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
    internal Pc(
        ICpuCoolingSystem cpuCoolingSystem,
        ICpu cpu,
        IGraphicsCard? graphicsCard,
        IEnumerable<IHdd> hdds,
        IMotherboard motherboard,
        IPcCase pcCase,
        IPsu psu,
        IEnumerable<IRam> rams,
        IEnumerable<ISsd> ssds,
        IWiFiAdapter? wifiAdapter)
    {
        CpuCoolingSystem = cpuCoolingSystem;
        Cpu = cpu;
        GraphicsCard = graphicsCard;
        Hdds = hdds.ToArray();
        Motherboard = motherboard;
        PcCase = pcCase;
        Psu = psu;
        Rams = rams.ToArray();
        Ssds = ssds.ToArray();
        WiFiAdapter = wifiAdapter;
    }

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

    public IPcBuilder Direct(IPcBuilder builder)
    {
        builder
            .WithCpuCooling(CpuCoolingSystem)
            .WithCpu(Cpu)
            .WithMotherboard(Motherboard)
            .WithPcCase(PcCase)
            .WithPsu(Psu);

        if (GraphicsCard is not null)
        {
            builder.WithGraphicsCard(GraphicsCard);
        }

        if (WiFiAdapter is not null)
        {
            builder.WithWiFiAdapter(WiFiAdapter);
        }

        foreach (IHdd hdd in Hdds)
        {
            builder.AddHdd(hdd);
        }

        foreach (IRam ram in Rams)
        {
            builder.AddRam(ram);
        }

        foreach (ISsd ssd in Ssds)
        {
            builder.AddSsd(ssd);
        }

        return builder;
    }
}