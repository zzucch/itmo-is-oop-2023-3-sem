namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;

public record RouteSegmentResult
{
    public int TimeTaken { get; set; }
    public double FuelConsumed { get; set; }
    public bool Success { get; set; } = true;
    public bool ShipLost { get; set; }
    public bool ShipDestroyed { get; set; }
    public bool CrewLost { get; set; }
}