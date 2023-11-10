using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Drivers;

public interface IDisplayDriver
{
    void Clear();
    void SetColorModifier(IColorModifier colorModifier);
    void Write(IMessage message);
}