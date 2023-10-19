namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public interface IMotherBoardBuilderDirector
{
    IMotherboardBuilder Direct(IMotherboardBuilder builder);
}