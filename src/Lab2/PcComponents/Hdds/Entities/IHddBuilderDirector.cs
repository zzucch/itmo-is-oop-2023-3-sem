namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public interface IHddBuilderDirector
{
    IHddBuilder Direct(IHddBuilder builder);
}