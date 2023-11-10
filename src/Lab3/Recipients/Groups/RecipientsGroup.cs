using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Groups;

public class RecipientsGroup : IRecipient
{
    private readonly IReadOnlyList<IRecipient> _recipients;

    public RecipientsGroup(IReadOnlyList<IRecipient> recipients)
    {
        _recipients = recipients;
    }

    public void ReceiveMessage(IMessage message)
    {
        foreach (IRecipient recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}