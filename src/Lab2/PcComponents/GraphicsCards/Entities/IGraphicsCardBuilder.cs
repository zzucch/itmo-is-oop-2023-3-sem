using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public interface IGraphicsCardBuilder
{
    IGraphicsCardBuilder WithDimensions(GraphicsCardDimensions dimensions);
    IGraphicsCardBuilder WithVideoMemory(int gBytes);
    IGraphicsCardBuilder WithPciEVersion(int version);
    IGraphicsCardBuilder WithClockFrequency(int hertz);
    IGraphicsCardBuilder WithPowerConsumption(int watts);
    IGraphicsCard Build();
}