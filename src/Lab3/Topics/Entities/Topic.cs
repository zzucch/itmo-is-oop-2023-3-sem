using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients;
using Itmo.ObjectOrientedProgramming.Lab3.Topics.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics.Entities;

public class Topic : ITopic
{
    private readonly TopicName _name;
    private readonly IRecipient _recipient;

    public Topic(TopicName name, IRecipient recipient)
    {
        _name = name;
        _recipient = recipient;
    }

    public void ForwardMessage(Message message)
    {
        _recipient.ReceiveMessage(message);
    }
}