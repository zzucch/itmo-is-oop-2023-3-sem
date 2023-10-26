using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public class GraphicsCard : IGraphicsCard
{
    private readonly GraphicsCardVideoMemory _videoMemory;
    private readonly int _pciEVersion;
    private readonly GraphicsCardClockFrequency _clockFrequency;

    internal GraphicsCard(
        GraphicsCardDimensions dimensions,
        GraphicsCardVideoMemory videoMemory,
        int pciEVersion,
        GraphicsCardClockFrequency clockFrequency,
        PowerConsumption powerConsumption)
    {
        Dimensions = dimensions;
        _videoMemory = videoMemory;
        _pciEVersion = pciEVersion;
        _clockFrequency = clockFrequency;
        PowerConsumption = powerConsumption;
    }

    public PowerConsumption PowerConsumption { get; }
    public GraphicsCardDimensions Dimensions { get; }

    public IGraphicsCardBuilder Direct(IGraphicsCardBuilder builder)
    {
        builder
            .WithDimensions(Dimensions)
            .WithVideoMemory(_videoMemory)
            .WithPciEVersion(_pciEVersion)
            .WithClockFrequency(_clockFrequency)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}