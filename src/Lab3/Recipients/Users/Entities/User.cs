using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Entities;

public class User : IUser
{
    private readonly List<UserMessage> _messages = new();

    public void ReceiveMessage(Message message)
    {
        _messages.Add(new UserMessage(
            message,
            new UserMessageStatus.Unread()));
    }

    public MarkMessageAsReadResult MarkMessageAsRead(Message message)
    {
        foreach (UserMessage userMessage in _messages)
        {
            if (userMessage.Message != message) continue;
            if (userMessage.MessageStatus is UserMessageStatus.Read)
            {
                return new MarkMessageAsReadResult.Failure();
            }

            userMessage.MessageStatus = new UserMessageStatus.Read();
            return new MarkMessageAsReadResult.Success();
        }

        return new MarkMessageAsReadResult.Failure();
    }

    public UserMessageStatus? FindMessageStatus(Message message)
    {
        return _messages.Find(userMessage => userMessage.Message == message)?.MessageStatus;
    }
}