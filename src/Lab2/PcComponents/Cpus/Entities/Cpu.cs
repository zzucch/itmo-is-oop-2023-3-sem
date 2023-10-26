using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public class Cpu : ICpu
{
    private readonly CpuCoreSpeed _coreSpeed;
    private readonly CpuCoreAmount _coreAmount;

    internal Cpu(
        CpuCoreSpeed coreSpeed,
        CpuCoreAmount coreAmount,
        CpuSocket socket,
        bool integratedGraphicsProcessor,
        IEnumerable<RamFrequency> supportedMemoryFrequencies,
        Tdp tdp,
        PowerConsumption powerConsumption)
    {
        _coreSpeed = coreSpeed;
        _coreAmount = coreAmount;
        Socket = socket;
        IntegratedGraphicsProcessor = integratedGraphicsProcessor;
        SupportedMemoryFrequencies = supportedMemoryFrequencies.ToArray();
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public Tdp Tdp { get; }

    public CpuSocket Socket { get; }

    public PowerConsumption PowerConsumption { get; }

    public bool IntegratedGraphicsProcessor { get; }

    public IReadOnlyList<RamFrequency> SupportedMemoryFrequencies { get; }

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

        foreach (RamFrequency frequency in SupportedMemoryFrequencies)
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