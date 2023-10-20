using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public class CpuBuilder : ICpuBuilder
{
    private readonly List<int> _supportedMemoryFrequencies = new();
    private int? _coreSpeed;
    private int? _coreAmount;
    private string? _socket;
    private bool? _integratedGraphicsProcessor;
    private int? _tdp;
    private int? _powerConsumption;

    public ICpuBuilder WithCoreSpeed(int mHz)
    {
        _coreSpeed = mHz;
        return this;
    }

    public ICpuBuilder WithCoreAmount(int cores)
    {
        _coreAmount = cores;
        return this;
    }

    public ICpuBuilder WithSocket(string socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithIntegratedGraphicsProcessor(bool igp)
    {
        _integratedGraphicsProcessor = igp;
        return this;
    }

    public ICpuBuilder AddSupportedMemoryFrequency(int speed)
    {
        _supportedMemoryFrequencies.Add(speed);
        return this;
    }

    public ICpuBuilder WithTdp(int tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(int watts)
    {
        _powerConsumption = watts;
        return this;
    }

    public ICpu Build()
    {
        return new Cpu(
            _coreSpeed ?? throw new ArgumentNullException(nameof(_coreSpeed)),
            _coreAmount ?? throw new ArgumentNullException(nameof(_coreAmount)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _integratedGraphicsProcessor ?? throw new ArgumentNullException(nameof(_integratedGraphicsProcessor)),
            _supportedMemoryFrequencies,
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}