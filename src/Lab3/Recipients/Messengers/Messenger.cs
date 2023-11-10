using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Messengers;

public class Messenger : IMessenger
{
    public void ReceiveMessage(Message message)
    {
        Console.WriteLine("Messenger:");
        Console.WriteLine(message.Render());
    }
}