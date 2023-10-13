namespace Itmo.ObjectOrientedProgramming.Lab1.Models.RouteSegmentResults;

public record RouteSegmentResult(
    bool Success,
    Fuel FuelTypeConsumed,
    double FuelConsumption,
    double TimeTaken,
    bool ShipLost,
    bool CrewLost,
    bool ShipDestroyed,
    bool DeflectorDestroyed)
{
    public RouteSegmentResult(
        ShipTravelResult travelResult,
        ShipDeflectionResult deflectionResult)
        : this(
            Success: travelResult.TravelResult.Success &&
                     (deflectionResult.DeflectorResult?.Success is true ||
                      deflectionResult.HullResult?.Success is true),
            travelResult.TravelResult.FuelTypeConsumed,
            travelResult.TravelResult.TravelFuelConsumption,
            travelResult.TravelResult.TravelTimeTaken,
            travelResult.TravelResult.ShipLost,
            CrewLost: travelResult.CrewState is CrewState.Dead,
            ShipDestroyed: deflectionResult.HullResult?.Success is false,
            DeflectorDestroyed: deflectionResult.DeflectorResult?.DeflectorDestroyed is true)
    {
    }
}