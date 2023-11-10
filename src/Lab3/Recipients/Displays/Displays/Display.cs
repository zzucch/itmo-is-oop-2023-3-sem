using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Drivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;
    private IMessage? _message;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void ReceiveMessage(IMessage message)
    {
        _message = message;
    }

    public void DisplayMessage()
    {
        if (_message is null)
        {
            throw new InvalidOperationException("display does not contain a message");
        }

        _driver.Clear();
        _driver.Write(_message);

        _message = null;
    }
}