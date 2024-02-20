using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public class Hdd : IHdd
{
    private readonly int _capacity;
    private readonly int _speed;

    internal Hdd(PowerConsumption powerConsumption, int capacity, int speed, PcComponentName name)
    {
        PowerConsumption = powerConsumption;
        _capacity = capacity;
        _speed = speed;
        Name = name;
    }

    public PcComponentName Name { get; }
    public PowerConsumption PowerConsumption { get; }

    public IHddBuilder Direct(IHddBuilder builder)
    {
        builder
            .WithCapacity(_capacity)
            .WithSpeed(_speed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}