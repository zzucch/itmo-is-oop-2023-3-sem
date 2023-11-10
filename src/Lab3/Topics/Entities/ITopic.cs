using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public interface ITopic
{
    void ForwardMessage(IMessage message);
}