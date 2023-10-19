namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public interface ISsdBuilderDirector
{
    ISsdBuilder Direct(ISsdBuilder builder);
}