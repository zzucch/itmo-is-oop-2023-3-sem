namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;

public interface IPsuBuilderDirector
{
    IPsuBuilder Direct(IPsuBuilder builder);
}