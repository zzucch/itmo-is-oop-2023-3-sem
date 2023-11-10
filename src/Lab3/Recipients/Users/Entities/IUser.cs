using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Users.Entities;

public interface IUser : IRecipient
{
    void MarkMessageAsRead(IMessage message);
    UserMessageStatus? FindMessageStatus(IMessage message);
}