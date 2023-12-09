using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public interface ICpuCoolingSystem : ICpuCoolingSystemBuilderDirector, IPcComponent
{
    public CoolingSystemDimensions Dimensions { get; }
    public bool IsCompatibleWithCpuSocket(CpuSocket socket);
    public bool IsCompatibleWithCpuTdp(Tdp tdp);
}