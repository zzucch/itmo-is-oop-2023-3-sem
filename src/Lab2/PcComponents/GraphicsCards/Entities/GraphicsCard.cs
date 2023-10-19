using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public class GraphicsCard : IGraphicsCard
{
    private readonly GraphicsCardDimensions _dimensions;
    private readonly int _videoMemory;
    private readonly int _pciEVersion;
    private readonly int _clockFrequency;
    private readonly int _powerConsumption;

    public GraphicsCard(
        GraphicsCardDimensions dimensions,
        int videoMemory,
        int pciEVersion,
        int clockFrequency,
        int powerConsumption)
    {
        _dimensions = dimensions;
        _videoMemory = videoMemory;
        _pciEVersion = pciEVersion;
        _clockFrequency = clockFrequency;
        _powerConsumption = powerConsumption;
    }

    public IGraphicsCardBuilder Direct(IGraphicsCardBuilder builder)
    {
        builder
            .WithDimensions(_dimensions)
            .WithVideoMemory(_videoMemory)
            .WithPciEVersion(_pciEVersion)
            .WithClockFrequency(_clockFrequency)
            .WithPowerConsumption(_powerConsumption);

        return builder;
    }
}