using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public void DisplayInformation(string value)
    {
        Console.WriteLine($"Messenger: {value}");
    }
}