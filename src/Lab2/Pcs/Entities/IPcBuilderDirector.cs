namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;

public interface IPcBuilderDirector
{
    IPcBuilder Direct(IPcBuilder builder);
}