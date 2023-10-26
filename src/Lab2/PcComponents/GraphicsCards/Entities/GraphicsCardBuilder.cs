using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public class GraphicsCardBuilder : IGraphicsCardBuilder
{
    private GraphicsCardDimensions? _dimensions;
    private GraphicsCardVideoMemory? _videoMemory;
    private int? _pciEVersion;
    private GraphicsCardClockFrequency? _clockFrequency;
    private PowerConsumption? _powerConsumption;

    public IGraphicsCardBuilder WithDimensions(GraphicsCardDimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IGraphicsCardBuilder WithVideoMemory(GraphicsCardVideoMemory memory)
    {
        _videoMemory = memory;
        return this;
    }

    public IGraphicsCardBuilder WithPciEVersion(int version)
    {
        _pciEVersion = version;
        return this;
    }

    public IGraphicsCardBuilder WithClockFrequency(GraphicsCardClockFrequency clockFrequency)
    {
        _clockFrequency = clockFrequency;
        return this;
    }

    public IGraphicsCardBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IGraphicsCard Build()
    {
        return new GraphicsCard(
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _videoMemory ?? throw new ArgumentNullException(nameof(_videoMemory)),
            _pciEVersion ?? throw new ArgumentNullException(nameof(_pciEVersion)),
            _clockFrequency ?? throw new ArgumentNullException(nameof(_clockFrequency)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}