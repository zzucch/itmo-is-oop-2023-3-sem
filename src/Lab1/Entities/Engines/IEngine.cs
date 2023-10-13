using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IEngine
{
    TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType);
}