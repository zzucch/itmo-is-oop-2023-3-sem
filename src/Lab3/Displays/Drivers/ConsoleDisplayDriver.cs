using System;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Drivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private IModifier? _colorModifier;

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColorModifier(IModifier colorModifier)
    {
        _colorModifier = colorModifier;
    }

    public void Write(string value)
    {
        if (_colorModifier is not null)
        {
            value = _colorModifier.Modify(value);
        }

        Console.WriteLine(value);
    }
}