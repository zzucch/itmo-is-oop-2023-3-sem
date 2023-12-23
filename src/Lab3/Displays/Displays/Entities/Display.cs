using Itmo.ObjectOrientedProgramming.Lab3.Displays.Drivers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.Displays.Entities;

public class Display : IDisplay
{
    private readonly IDisplayDriver _driver;

    public Display(IDisplayDriver driver)
    {
        _driver = driver;
    }

    public void DisplayInformation(string value)
    {
        _driver.Clear();
        _driver.Write(value);
    }
}