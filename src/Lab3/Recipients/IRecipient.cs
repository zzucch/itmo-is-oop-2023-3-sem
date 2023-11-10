using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public interface IRecipient
{
    void ReceiveMessage(IMessage message);
}