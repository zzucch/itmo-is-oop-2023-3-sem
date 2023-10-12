using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public interface IEngine
{
    TravelResult Travel(int lightYear, Environment environment);
}