namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public class Hdd : IHdd
{
    private readonly int _capacity;
    private readonly int _speed;

    internal Hdd(int powerConsumption, int capacity, int speed)
    {
        PowerConsumption = powerConsumption;
        _capacity = capacity;
        _speed = speed;
    }

    public int PowerConsumption { get; }

    public IHddBuilder Direct(IHddBuilder builder)
    {
        builder
            .WithCapacity(_capacity)
            .WithSpeed(_speed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}