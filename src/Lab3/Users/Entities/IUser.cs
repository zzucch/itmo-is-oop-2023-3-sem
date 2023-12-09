using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

public interface IUser
{
    public void ReceiveMessage(Message message);
    MarkMessageAsReadResult MarkMessageAsRead(Message message);
    UserMessageStatus? FindMessageStatus(Message message);
}