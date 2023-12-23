using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public class SsdBuilder : ISsdBuilder
{
    private PcComponentName? _name;
    private SsdConnectionInterface? _connectionInterface;
    private int? _capacity;
    private int? _speed;
    private PowerConsumption? _powerConsumption;

    public ISsdBuilder WithName(PcComponentName name)
    {
        _name = name;
        return this;
    }

    public ISsdBuilder WithInterface(SsdConnectionInterface connectionInterface)
    {
        _connectionInterface = connectionInterface;
        return this;
    }

    public ISsdBuilder WithCapacity(int gBytes)
    {
        _capacity = gBytes;
        return this;
    }

    public ISsdBuilder WithSpeed(int mbps)
    {
        _speed = mbps;
        return this;
    }

    public ISsdBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public ISsd Build()
    {
        return new Ssd(
            _connectionInterface ?? throw new ArgumentNullException(nameof(_connectionInterface)),
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _speed ?? throw new ArgumentNullException(nameof(_speed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}