using Itmo.ObjectOrientedProgramming.Lab3.Displays.Displays.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Recipients;

public class DisplayRecipient : IRecipient
{
    private readonly IDisplay _display;

    public DisplayRecipient(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        _display.DisplayInformation(message.Render());
    }
}