using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

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
        IReadOnlyCollection<ShipDeflectionResult> deflectionResults)
        : this(
            Success: travelResult.TravelResult.Success &&
                     (deflectionResults.All(i => i.DeflectorResult?.Success is true) ||
                      deflectionResults.All(i => i.HullResult?.Success is true)),
            travelResult.TravelResult.FuelTypeConsumed,
            travelResult.TravelResult.TravelFuelConsumption,
            travelResult.TravelResult.TravelTimeTaken,
            travelResult.TravelResult.ShipLost,
            CrewLost: travelResult.CrewState is CrewState.Dead,
            ShipDestroyed: deflectionResults.All(i => i.HullResult?.Success is false),
            DeflectorDestroyed: deflectionResults.All(i => i.DeflectorResult?.DeflectorDestroyed is true))
    {
    }
}