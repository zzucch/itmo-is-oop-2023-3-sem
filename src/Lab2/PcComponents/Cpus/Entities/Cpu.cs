using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public class Cpu : ICpu
{
    private readonly int _coreSpeed;
    private readonly int _coreAmount;
    private readonly string _socket;
    private readonly bool _integratedGraphicsProcessor;
    private readonly List<int> _supportedMemoryFrequencies;
    private readonly int _tdp;
    private readonly int _powerConsumption;

    public Cpu(
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
        _socket = socket;
        _integratedGraphicsProcessor = integratedGraphicsProcessor;
        _supportedMemoryFrequencies = new List<int>(supportedMemoryFrequencies);
        _tdp = tdp;
        _powerConsumption = powerConsumption;
    }

    public ICpuBuilder Direct(ICpuBuilder builder)
    {
        builder
            .WithCoreSpeed(_coreSpeed)
            .WithCoreAmount(_coreAmount)
            .WithSocket(_socket)
            .WithIntegratedGraphicsProcessor(_integratedGraphicsProcessor)
            .WithTdp(_tdp)
            .WithPowerConsumption(_powerConsumption);

        foreach (int frequency in _supportedMemoryFrequencies)
        {
            builder.AddSupportedMemoryFrequency(frequency);
        }

        return builder;
    }
}