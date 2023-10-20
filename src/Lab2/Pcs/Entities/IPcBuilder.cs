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

public interface IPcBuilder
{
    IPcBuilder WithCpuCooling(ICpuCoolingSystem cpuCoolingSystem);
    IPcBuilder WithCpu(ICpu cpu);
    IPcBuilder WithGraphicsCard(IGraphicsCard graphicsCard);
    IPcBuilder AddHdd(IHdd hdd);
    IPcBuilder WithMotherboard(IMotherboard motherboard);
    IPcBuilder WithPcCase(IPcCase pcCase);
    IPcBuilder WithPsu(IPsu psu);
    IPcBuilder AddRam(IRam ram);
    IPcBuilder AddSsd(ISsd ssd);
    IPcBuilder WithWiFiAdapter(IWiFiAdapter wifiAdapter);
    IPc Build();
}