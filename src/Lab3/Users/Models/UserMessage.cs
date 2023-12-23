using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

public record UserMessage(Message Message, UserMessageStatus MessageStatus);