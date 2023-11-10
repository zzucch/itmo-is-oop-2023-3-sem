using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Drivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private IColorModifier? _colorModifier;

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColorModifier(IColorModifier colorModifier)
    {
        _colorModifier = colorModifier;
    }

    public void Write(Message message)
    {
        string value = message.Render();

        if (_colorModifier is not null)
        {
            value = _colorModifier.Modify(value);
        }

        Console.WriteLine(value);
    }
}