namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public record RouteSegmentResult(
    bool Success,
    Fuel FuelTypeConsumed,
    double FuelConsumptionAmount,
    double TimeTaken,
    bool ShipLost,
    bool CrewLost,
    bool ShipDestroyed,
    bool DeflectorDestroyed);