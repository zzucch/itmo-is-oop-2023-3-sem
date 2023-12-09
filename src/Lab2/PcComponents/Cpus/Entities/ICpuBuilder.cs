using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public interface ICpuBuilder
{
    ICpuBuilder WithName(PcComponentName name);
    ICpuBuilder WithCoreSpeed(CpuCoreSpeed speed);
    ICpuBuilder WithCoreAmount(CpuCoreAmount cores);
    ICpuBuilder WithSocket(CpuSocket socket);
    ICpuBuilder WithIntegratedGraphicsProcessor(bool igp);
    ICpuBuilder AddSupportedMemoryFrequency(RamFrequency frequency);
    ICpuBuilder WithTdp(Tdp tdp);
    ICpuBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    ICpu Build();
}