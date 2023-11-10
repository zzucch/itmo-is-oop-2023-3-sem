using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public interface IRecipient
{
    void ReceiveMessage(Message message);
}