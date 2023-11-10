using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public interface ITopic
{
    void ForwardMessage(Message message);
}