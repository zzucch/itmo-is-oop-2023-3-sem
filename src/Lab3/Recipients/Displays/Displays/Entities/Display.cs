using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Displays.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Drivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Displays.Displays.Entities;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;
    private Message? _message;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void ReceiveMessage(Message message)
    {
        _message = message;
    }

    public DisplayMessageResult TryDisplayMessage()
    {
        if (_message is null)
        {
            return new DisplayMessageResult.Failure();
        }

        _driver.Clear();
        _driver.Write(_message);

        _message = null;

        return new DisplayMessageResult.Success();
    }
}