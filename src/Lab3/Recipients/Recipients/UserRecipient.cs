using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Recipients;

public class UserRecipient : IRecipient
{
    private readonly IUser _user;

    public UserRecipient(IUser user)
    {
        _user = user;
    }

    public void ReceiveMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }
}