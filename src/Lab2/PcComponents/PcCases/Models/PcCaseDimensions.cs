namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;

public record PcCaseDimensions(
    int Width,
    int Length,
    int Height,
    int MaxCpuCoolingSystemUnitHeight,
    int MaxCpuCoolingSystemUnitLength,
    int MaxCpuCoolingSystemUnitWidth,
    int GraphicsCardMaxHeight,
    int GraphicsCardMaxLenght,
    int GraphicsCardMaxWidth);