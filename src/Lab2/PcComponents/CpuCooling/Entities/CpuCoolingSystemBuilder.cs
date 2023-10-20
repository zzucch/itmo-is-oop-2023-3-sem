using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public class CpuCoolingSystemBuilder : ICpuCoolingSystemBuilder
{
    private readonly List<string> _sockets = new();
    private CoolingSystemDimensions? _dimensions;
    private int? _tdp;

    public ICpuCoolingSystemBuilder WithDimensions(CoolingSystemDimensions dimensions)
    {
        _dimensions = dimensions;
        return this;
    }

    public ICpuCoolingSystemBuilder AddSocket(string socket)
    {
        _sockets.Add(socket);
        return this;
    }

    public ICpuCoolingSystemBuilder WithTdp(int watts)
    {
        _tdp = watts;
        return this;
    }

    public ICpuCoolingSystem Build()
    {
        return new CpuCoolingSystem(
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _sockets,
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)));
    }
}