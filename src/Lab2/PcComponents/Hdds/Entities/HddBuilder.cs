using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public class HddBuilder : IHddBuilder
{
    private int? _capacity;
    private int? _speed;
    private int? _powerConsumption;

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

    public IHddBuilder WithPowerConsumption(int watts)
    {
        _powerConsumption = watts;
        return this;
    }

    public IHdd Build()
    {
        return new Hdd(
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _speed ?? throw new ArgumentNullException(nameof(_speed)));
    }
}