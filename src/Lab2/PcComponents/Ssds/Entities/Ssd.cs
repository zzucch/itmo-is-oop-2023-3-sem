using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public class Ssd : ISsd
{
    private readonly int _capacity;
    private readonly int _speed;

    internal Ssd(
        SsdConnectionInterface connectionInterface,
        int capacity,
        int speed,
        int powerConsumption)
    {
        ConnectionInterface = connectionInterface;
        _capacity = capacity;
        _speed = speed;
        PowerConsumption = powerConsumption;
    }

    public int PowerConsumption { get; }
    public SsdConnectionInterface ConnectionInterface { get; }

    public ISsdBuilder Direct(ISsdBuilder builder)
    {
        builder
            .WithInterface(ConnectionInterface)
            .WithCapacity(_capacity)
            .WithSpeed(_speed)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}