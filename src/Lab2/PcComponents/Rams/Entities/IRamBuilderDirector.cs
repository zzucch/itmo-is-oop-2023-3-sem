namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;

public interface IRamBuilderDirector
{
    IRamBuilder Direct(IRamBuilder builder);
}