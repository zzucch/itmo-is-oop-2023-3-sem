using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Recipients;

public class MessengerRecipient : IRecipient
{
    private readonly IMessenger _messenger;

    public MessengerRecipient(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void ReceiveMessage(Message message)
    {
        _messenger.DisplayInformation(message.Render());
    }
}