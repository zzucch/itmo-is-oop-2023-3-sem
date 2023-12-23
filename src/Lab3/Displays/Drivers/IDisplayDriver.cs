using Itmo.ObjectOrientedProgramming.Lab3.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Drivers;

public interface IDisplayDriver
{
    void Clear();
    void SetColorModifier(IModifier modifier);
    void Write(string value);
}