using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents;

public record PcComponentName
{
    public PcComponentName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("pc component name must is invalid");
        }

        Name = name;
    }

    public string Name { get; }
}