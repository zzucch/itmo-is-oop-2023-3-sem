using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Entities;

public class User : IUser
{
    private readonly List<UserMessage> _messages = new();

    public void ReceiveMessage(IMessage message)
    {
        _messages.Add(new UserMessage(
            message,
            new UserMessageStatus.Unread()));
    }

    public void MarkMessageAsRead(IMessage message)
    {
        foreach (UserMessage userMessage in _messages)
        {
            if (userMessage.Message == message)
            {
                userMessage.MessageStatus = new UserMessageStatus.Read();
            }
        }
    }

    public UserMessageStatus? FindMessageStatus(IMessage message)
    {
        return _messages.Find(userMessage => userMessage.Message == message)?.MessageStatus;
    }
}