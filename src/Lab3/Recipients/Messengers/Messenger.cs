using System;
using Itmo.ObjectOrientedProgramming.Lab3.Messages.Messages.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipients.Messengers;

public class Messenger : IMessenger
{
    public void ReceiveMessage(IMessage message)
    {
        Console.WriteLine("Messenger:");
        Console.WriteLine(message.Render());
    }
}