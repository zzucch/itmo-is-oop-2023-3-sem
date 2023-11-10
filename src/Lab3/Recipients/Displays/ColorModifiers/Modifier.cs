using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.ColorModifiers;

public class Modifier : IModifier
{
    private readonly Color _color;

    public Modifier(Color color)
    {
        _color = color;
    }

    public string Modify(string value)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(value);
    }
}