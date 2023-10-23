using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public class CpuCoolingSystem : ICpuCoolingSystem
{
    private readonly IReadOnlyList<string> _sockets;
    private readonly int _tdp;

    internal CpuCoolingSystem(CoolingSystemDimensions dimensions, IEnumerable<string> sockets, int tdp)
    {
        Dimensions = dimensions;
        _sockets = sockets.ToArray();
        _tdp = tdp;
    }

    public CoolingSystemDimensions Dimensions { get; }

    public ICpuCoolingSystemBuilder Direct(ICpuCoolingSystemBuilder builder)
    {
        builder
            .WithDimensions(Dimensions)
            .WithTdp(_tdp);

        foreach (string socket in _sockets)
        {
            builder.AddSocket(socket);
        }

        return builder;
    }

    public bool IsCompatibleWithCpuSocket(string socket)
    {
        return _sockets.Any(s => s == socket);
    }

    public bool IsCompatibleWithCpuTdp(int tdp)
    {
        return tdp <= _tdp;
    }
}