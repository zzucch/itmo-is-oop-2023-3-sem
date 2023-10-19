namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;

public interface IPcCaseBuilderDirector
{
    IPcCaseBuilder Direct(IPcCaseBuilder builder);
}