using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

public record UserMessage(IMessage Message, UserMessageStatus MessageStatus)
{
    public UserMessageStatus MessageStatus { get; set; } = MessageStatus;
}