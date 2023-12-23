namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public interface ICpuBuilderDirector
{
    ICpuBuilder Direct(ICpuBuilder builder);
}