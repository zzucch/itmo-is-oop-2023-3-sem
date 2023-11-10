using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.ColorModifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Drivers;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;
    private IModifier? _colorModifier;

    public FileDisplayDriver(string filePath)
    {
        _filePath = filePath;
    }

    public void Clear()
    {
        File.Create(_filePath).Close();
    }

    public void SetColorModifier(IModifier colorModifier)
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

        StreamWriter writer = File.AppendText(_filePath);
        writer.WriteLine(value);
    }
}