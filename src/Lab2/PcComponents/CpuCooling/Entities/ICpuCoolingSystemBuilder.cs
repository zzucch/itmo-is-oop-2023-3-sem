using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public interface ICpuCoolingSystemBuilder
{
    ICpuCoolingSystemBuilder WithDimensions(CoolingSystemDimensions dimensions);
    ICpuCoolingSystemBuilder AddSocket(CpuSocket socket);
    ICpuCoolingSystemBuilder WithTdp(Tdp watts);
    ICpuCoolingSystem Build();
}