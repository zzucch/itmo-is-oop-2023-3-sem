using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Travelling.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Travelling.Entities;

public interface ITravellingStrategy
{
    TravelResult TryTravel(int distanceLightYear, EnvironmentType environmentType);
}