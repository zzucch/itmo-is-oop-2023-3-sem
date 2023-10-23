using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public interface ICpuCoolingSystem : ICpuCoolingSystemBuilderDirector
{
    public CoolingSystemDimensions Dimensions { get; }
    public bool IsCompatibleWithCpuSocket(string socket);
    public bool IsCompatibleWithCpuTdp(int tdp);
}