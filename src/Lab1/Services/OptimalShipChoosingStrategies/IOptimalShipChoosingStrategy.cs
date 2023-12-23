using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShipChoosingStrategies;

public interface IOptimalShipChoosingStrategy
{
    ISpaceShip? FindOptimalShip(ISpaceShip first, ISpaceShip second, Route route);
}