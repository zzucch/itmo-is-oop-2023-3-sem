namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public interface IMotherboardBuilderDirector
{
    IMotherboardBuilder Direct(IMotherboardBuilder builder);
}