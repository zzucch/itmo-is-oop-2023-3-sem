using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Entities;

public interface IUser : IRecipient
{
    MarkMessageAsReadResult MarkMessageAsRead(Message message);
    UserMessageStatus? FindMessageStatus(Message message);
}