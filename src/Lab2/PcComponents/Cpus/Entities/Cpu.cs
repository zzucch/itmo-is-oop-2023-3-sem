using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public class Cpu : ICpu
{
    private readonly int _coreSpeed;
    private readonly int _coreAmount;

    internal Cpu(
        int coreSpeed,
        int coreAmount,
        string socket,
        bool integratedGraphicsProcessor,
        IEnumerable<int> supportedMemoryFrequencies,
        int tdp,
        int powerConsumption)
    {
        _coreSpeed = coreSpeed;
        _coreAmount = coreAmount;
        Socket = socket;
        IntegratedGraphicsProcessor = integratedGraphicsProcessor;
        SupportedMemoryFrequencies = supportedMemoryFrequencies.ToArray();
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public int Tdp { get; }

    public string Socket { get; }

    public int PowerConsumption { get; }

    public bool IntegratedGraphicsProcessor { get; }

    public IReadOnlyList<int> SupportedMemoryFrequencies { get; }

    public override bool Equals(object? obj)
    {
        if (obj is not Cpu other)
        {
            return false;
        }

        return _coreSpeed == other._coreSpeed
               && _coreAmount == other._coreAmount
               && Socket == other.Socket
               && IntegratedGraphicsProcessor == other.IntegratedGraphicsProcessor
               && Equals(SupportedMemoryFrequencies, other.SupportedMemoryFrequencies)
               && Tdp == other.Tdp
               && PowerConsumption == other.PowerConsumption;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(_coreSpeed, _coreAmount, Tdp, Socket, PowerConsumption, IntegratedGraphicsProcessor, SupportedMemoryFrequencies);
    }

    public ICpuBuilder Direct(ICpuBuilder builder)
    {
        builder
            .WithCoreSpeed(_coreSpeed)
            .WithCoreAmount(_coreAmount)
            .WithSocket(Socket)
            .WithIntegratedGraphicsProcessor(IntegratedGraphicsProcessor)
            .WithTdp(Tdp)
            .WithPowerConsumption(PowerConsumption);

        foreach (int frequency in SupportedMemoryFrequencies)
        {
            builder.AddSupportedMemoryFrequency(frequency);
        }

        return builder;
    }

    protected bool Equals(Cpu other)
    {
        return _coreSpeed == other._coreSpeed
               && _coreAmount == other._coreAmount
               && Tdp == other.Tdp
               && Socket == other.Socket
               && PowerConsumption == other.PowerConsumption
               && IntegratedGraphicsProcessor == other.IntegratedGraphicsProcessor
               && SupportedMemoryFrequencies.Equals(other.SupportedMemoryFrequencies);
    }
}