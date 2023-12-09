namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;

public interface IBiosBuilderDirector
{
    IBiosBuilder Direct(IBiosBuilder builder);
}