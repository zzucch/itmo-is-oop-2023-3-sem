using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Drivers;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;
    private IModifier? _modifier;

    public FileDisplayDriver(string filePath)
    {
        _filePath = filePath;
    }

    public void Clear()
    {
        File.Create(_filePath).Close();
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

        StreamWriter writer = File.AppendText(_filePath);
        writer.WriteLine(value);
    }
}