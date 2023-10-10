using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

public abstract class SpaceShip : ISpaceShip
{
    protected IEngine? ImpulseEngine { get; init; }
    protected IEngine? JumpEngine { get; init; }
    protected IDeflector? Deflector { get; init; }
    protected Hull Hull { get; init; }
    protected ShipState ShipState { get; set; } = ShipState.Ready;
    private CrewState CrewState { get; set; } = CrewState.Alive;

    public RouteSegmentResult Travel(RouteSegment routeSegment)
    {
        var result = new RouteSegmentResult
        {
            FacedObstacle = routeSegment.Obstacles.Count > 0,
        };

        if (ImpulseEngine is not null)
        {
            TravelResult travelResult = ImpulseEngine.Travel(routeSegment.DistanceLightYear, routeSegment.Environment);
        }

        routeSegment.Obstacles.ToList().ForEach(Deflect);

        result.CrewLost = CrewState == CrewState.Dead;
        result.FuelConsumed = travelResult.TravelFuelConsumption;
        result.TimeTaken = travelResult.TravelTimeTaken;

        return result;
    }
}