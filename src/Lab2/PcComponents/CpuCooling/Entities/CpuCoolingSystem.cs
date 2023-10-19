using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;

public class CpuCoolingSystem : ICpuCoolingSystem
{
    private readonly CoolingSystemDimensions _dimensions;
    private readonly List<string> _sockets;
    private readonly int _tdp;

    public CpuCoolingSystem(CoolingSystemDimensions dimensions, IEnumerable<string> sockets, int tdp)
    {
        _dimensions = dimensions;
        _sockets = new List<string>(sockets);
        _tdp = tdp;
    }

    public ICpuCoolingSystemBuilder Direct(ICpuCoolingSystemBuilder builder)
    {
        builder
            .WithDimensions(_dimensions)
            .WithTdp(_tdp);

        foreach (string socket in _sockets)
        {
            builder.AddSocket(socket);
        }

        return builder;
    }
}