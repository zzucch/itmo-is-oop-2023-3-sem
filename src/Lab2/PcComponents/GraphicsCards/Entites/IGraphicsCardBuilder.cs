namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entites;

public interface IGraphicsCardBuilder
{
    IGraphicsCardBuilder WithDimensions(int height, int length);
    IGraphicsCardBuilder WithVideoMemory(int gBytes);
    IGraphicsCardBuilder WithPciEVersion();
    IGraphicsCardBuilder WithClockFrequency(int hertz);
    IGraphicsCardBuilder WithPowerConsumption(int watts);
    IGraphicsCard Build();
}