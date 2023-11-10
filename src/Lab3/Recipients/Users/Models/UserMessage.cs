using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

public record UserMessage(Message Message, UserMessageStatus MessageStatus)
{
    public UserMessageStatus MessageStatus { get; set; } = MessageStatus;
}