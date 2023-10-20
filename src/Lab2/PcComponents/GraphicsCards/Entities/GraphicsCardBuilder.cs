using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public class GraphicsCardBuilder : IGraphicsCardBuilder
{
    private GraphicsCardDimensions? _dimensions;
    private int? _videoMemory;
    private int? _pciEVersion;
    private int? _clockFrequency;
    private int? _powerConsumption;

    public IGraphicsCardBuilder WithDimensions(GraphicsCardDimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public IGraphicsCardBuilder WithVideoMemory(int gBytes)
    {
        _videoMemory = gBytes;
        return this;
    }

    public IGraphicsCardBuilder WithPciEVersion(int version)
    {
        _pciEVersion = version;
        return this;
    }

    public IGraphicsCardBuilder WithClockFrequency(int hertz)
    {
        _clockFrequency = hertz;
        return this;
    }

    public IGraphicsCardBuilder WithPowerConsumption(int watts)
    {
        _powerConsumption = watts;
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