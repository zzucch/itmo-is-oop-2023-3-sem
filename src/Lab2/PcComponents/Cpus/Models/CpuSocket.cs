using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

public record CpuSocket
{
    public CpuSocket(string socket)
    {
        if (string.IsNullOrEmpty(socket))
        {
            throw new ArgumentException("bios version must not be empty");
        }

        Socket = socket;
    }

    public string Socket { get; }
}