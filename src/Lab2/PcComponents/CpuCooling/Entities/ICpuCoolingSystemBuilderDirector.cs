namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public interface ICpuCoolingSystemBuilderDirector
{
    ICpuCoolingSystemBuilder Direct(ICpuCoolingSystemBuilder builder);
}