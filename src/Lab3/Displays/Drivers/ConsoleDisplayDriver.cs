using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Drivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private IModifier? _modifier;

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColorModifier(IModifier modifier)
    {
        _modifier = modifier;
    }

    public void Write(string value)
    {
        if (_modifier is not null)
        {
            value = _modifier.Modify(value);
        }

        Console.WriteLine(value);
    }
}