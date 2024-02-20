using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Drivers.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    public void Write(string value)
    {
        Console.WriteLine(value);
    }
}