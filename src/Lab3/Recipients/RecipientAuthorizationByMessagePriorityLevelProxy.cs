using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients;

public class RecipientAuthorizationByMessagePriorityLevelProxy : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly MessagePriorityLevel _priorityLevel;

    public RecipientAuthorizationByMessagePriorityLevelProxy(IRecipient recipient, MessagePriorityLevel priorityLevel)
    {
        _recipient = recipient;
        _priorityLevel = priorityLevel;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.IsAuthorizedToPassPriorityLevel(_priorityLevel))
        {
            _recipient.ReceiveMessage(message);
        }
    }
}