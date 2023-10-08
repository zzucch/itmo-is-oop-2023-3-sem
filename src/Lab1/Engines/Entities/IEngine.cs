using Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Entities;

public interface IEngine
{
    TravelResult Travel(int lightYear, Environment environment);
}