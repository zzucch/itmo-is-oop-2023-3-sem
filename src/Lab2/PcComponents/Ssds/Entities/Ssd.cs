using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;

public class Ssd : ISsd
{
    private readonly SsdConnectionInterface _connectionInterface;
    private readonly int _capacity;
    private readonly int _speed;
    private readonly int _powerConsumption;

    public Ssd(
        SsdConnectionInterface connectionInterface,
        int capacity,
        int speed,
        int powerConsumption)
    {
        _connectionInterface = connectionInterface;
        _capacity = capacity;
        _speed = speed;
        _powerConsumption = powerConsumption;
    }

    public ISsdBuilder Direct(ISsdBuilder builder)
    {
        builder
            .WithInterface(_connectionInterface)
            .WithCapacity(_capacity)
            .WithSpeed(_speed)
            .WithPowerConsumption(_powerConsumption);

        return builder;
    }
}