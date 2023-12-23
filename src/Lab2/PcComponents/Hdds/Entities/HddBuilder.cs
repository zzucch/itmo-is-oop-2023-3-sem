using System;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public class HddBuilder : IHddBuilder
{
    private PcComponentName? _name;
    private int? _capacity;
    private int? _speed;
    private PowerConsumption? _powerConsumption;

    public IHddBuilder WithName(PcComponentName name)
    {
        _name = name;
        return this;
    }

    public IHddBuilder WithCapacity(int gBytes)
    {
        _capacity = gBytes;
        return this;
    }

    public IHddBuilder WithSpeed(int rpm)
    {
        _speed = rpm;
        return this;
    }

    public IHddBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IHdd Build()
    {
        return new Hdd(
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _speed ?? throw new ArgumentNullException(nameof(_speed)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}