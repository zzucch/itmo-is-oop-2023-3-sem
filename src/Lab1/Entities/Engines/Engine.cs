using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class Engine
{
    public Engine(ITravellingStrategy travellingStrategy)
    {
        TravellingStrategy = travellingStrategy;
    }

    private ITravellingStrategy TravellingStrategy { get; }

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType, double environmentAcceleration)
    {
        return TravellingStrategy.TryTravel(distanceLightYear, environmentType, environmentAcceleration);
    }
}