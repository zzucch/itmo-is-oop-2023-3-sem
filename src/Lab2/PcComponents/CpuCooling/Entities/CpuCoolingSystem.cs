using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public class CpuCoolingSystem : ICpuCoolingSystem
{
    private readonly IReadOnlyList<CpuSocket> _sockets;
    private readonly Tdp _tdp;

    internal CpuCoolingSystem(
        CoolingSystemDimensions dimensions,
        IEnumerable<CpuSocket> sockets,
        Tdp tdp)
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

        foreach (CpuSocket socket in _sockets)
        {
            builder.AddSocket(socket);
        }

        return builder;
    }

    public bool IsCompatibleWithCpuSocket(CpuSocket socket)
    {
        return _sockets.Any(s => s == socket);
    }

    public bool IsCompatibleWithCpuTdp(Tdp tdp)
    {
        return tdp.Watts <= _tdp.Watts;
    }
}