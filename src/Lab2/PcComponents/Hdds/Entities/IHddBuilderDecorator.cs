namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public interface IHddBuilderDecorator
{
    IHddBuilder Direct(IHddBuilder builder);
}