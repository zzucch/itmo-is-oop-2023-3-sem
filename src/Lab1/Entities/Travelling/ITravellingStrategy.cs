using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public interface ITravellingStrategy
{
    TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType);
}