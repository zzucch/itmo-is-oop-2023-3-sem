namespace Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

public record RouteSegmentResult
{
    public bool Success { get; set; }
    public double TimeTaken { get; set; }
    public double FuelConsumed { get; set; }
    public bool ShipLost { get; set; }
    public bool CrewLost { get; set; }
    public bool ShipDestroyed { get; set; }
    public bool DeflectorDestroyed { get; set; }
    public bool FacedObstacle { get; set; }
}