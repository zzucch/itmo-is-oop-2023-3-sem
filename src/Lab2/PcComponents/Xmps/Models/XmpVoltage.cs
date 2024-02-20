using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;

public record XmpVoltage
{
    public XmpVoltage(decimal volts)
    {
        if (volts <= 0)
        {
            throw new ArgumentException("xmp voltage must be positive");
        }

        Voltage = volts;
    }

    public decimal Voltage { get; }
}