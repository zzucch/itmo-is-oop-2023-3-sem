using Itmo.ObjectOrientedProgramming.Lab3.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Drivers;

public interface IDisplayDriver
{
    void Clear();
    void SetColorModifier(IModifier colorModifier);
    void Write(string value);
}