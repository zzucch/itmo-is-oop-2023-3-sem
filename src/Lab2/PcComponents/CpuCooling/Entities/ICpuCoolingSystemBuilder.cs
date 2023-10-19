using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public interface ICpuCoolingSystemBuilder
{
    ICpuCoolingSystemBuilder WithDimensions(CoolingSystemDimensions dimensions);
    ICpuCoolingSystemBuilder AddSocket(string socket);
    ICpuCoolingSystemBuilder WithTdp(int watts);
    ICpuCoolingSystem Build();
}