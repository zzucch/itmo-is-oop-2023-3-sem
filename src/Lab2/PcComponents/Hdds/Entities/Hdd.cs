namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Hdds.Entities;

public class Hdd : IHdd
{
    private readonly int _capacity;
    private readonly int _speed;
    private readonly int _powerConsumption;

    public Hdd(int powerConsumption, int capacity, int speed)
    {
        _powerConsumption = powerConsumption;
        _capacity = capacity;
        _speed = speed;
    }

    public IHddBuilder Direct(IHddBuilder builder)
    {
        builder
            .WithCapacity(_capacity)
            .WithSpeed(_speed)
            .WithPowerConsumption(_powerConsumption);

        return builder;
    }
}