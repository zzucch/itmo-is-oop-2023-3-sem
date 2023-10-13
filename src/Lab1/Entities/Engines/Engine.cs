using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class Engine : IEngine
{
    public Engine(ITravellingStrategy travellingStrategy)
    {
        TravellingStrategy = travellingStrategy;
    }

    private ITravellingStrategy TravellingStrategy { get; }

    public TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType)
    {
        return TravellingStrategy.TryTravel(distanceLightYear, environmentType);
    }
}