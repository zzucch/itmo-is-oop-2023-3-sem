using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public interface IGraphicsCardBuilder
{
    IGraphicsCardBuilder WithDimensions(GraphicsCardDimensions dimensions);
    IGraphicsCardBuilder WithVideoMemory(GraphicsCardVideoMemory memory);
    IGraphicsCardBuilder WithPciEVersion(int version);
    IGraphicsCardBuilder WithClockFrequency(GraphicsCardClockFrequency clockFrequency);
    IGraphicsCardBuilder WithPowerConsumption(PowerConsumption powerConsumption);
    IGraphicsCard Build();
}