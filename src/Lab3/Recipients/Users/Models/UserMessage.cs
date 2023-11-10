using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

public record UserMessage(IMessage Message, UserMessageStatus MessageStatus)
{
    private UserMessageStatus _messageStatus = MessageStatus;

    public UserMessageStatus MessageStatus
    {
        get => _messageStatus;
        set
        {
            if (_messageStatus is UserMessageStatus.Read)
            {
                throw new InvalidOperationException("message is already read");
            }

            _messageStatus = value;
        }
    }
}