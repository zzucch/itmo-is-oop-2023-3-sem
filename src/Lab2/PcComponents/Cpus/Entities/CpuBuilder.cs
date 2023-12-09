using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public class CpuBuilder : ICpuBuilder
{
    private readonly List<RamFrequency> _supportedMemoryFrequencies = new();
    private PcComponentName? _name;
    private CpuCoreSpeed? _coreSpeed;
    private CpuCoreAmount? _coreAmount;
    private CpuSocket? _socket;
    private bool? _integratedGraphicsProcessor;
    private Tdp? _tdp;
    private PowerConsumption? _powerConsumption;

    public ICpuBuilder WithName(PcComponentName name)
    {
        _name = name;
        return this;
    }

    public ICpuBuilder WithCoreSpeed(CpuCoreSpeed speed)
    {
        _coreSpeed = speed;
        return this;
    }

    public ICpuBuilder WithCoreAmount(CpuCoreAmount cores)
    {
        _coreAmount = cores;
        return this;
    }

    public ICpuBuilder WithSocket(CpuSocket socket)
    {
        _socket = socket;
        return this;
    }

    public ICpuBuilder WithIntegratedGraphicsProcessor(bool igp)
    {
        _integratedGraphicsProcessor = igp;
        return this;
    }

    public ICpuBuilder AddSupportedMemoryFrequency(RamFrequency frequency)
    {
        _supportedMemoryFrequencies.Add(frequency);
        return this;
    }

    public ICpuBuilder WithTdp(Tdp tdp)
    {
        _tdp = tdp;
        return this;
    }

    public ICpuBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
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
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _name ?? throw new ArgumentNullException(nameof(_name)));
    }
}