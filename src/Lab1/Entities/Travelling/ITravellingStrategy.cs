using Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Travelling;

public interface ITravellingStrategy
{
    TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType);
}