using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public class GraphicsCard : IGraphicsCard
{
    private readonly int _videoMemory;
    private readonly int _pciEVersion;
    private readonly int _clockFrequency;

    internal GraphicsCard(
        GraphicsCardDimensions dimensions,
        int videoMemory,
        int pciEVersion,
        int clockFrequency,
        int powerConsumption)
    {
        Dimensions = dimensions;
        _videoMemory = videoMemory;
        _pciEVersion = pciEVersion;
        _clockFrequency = clockFrequency;
        PowerConsumption = powerConsumption;
    }

    public int PowerConsumption { get; }
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