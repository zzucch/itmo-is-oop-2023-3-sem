using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShipChoosingStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public abstract class OptimalShipChooser
{
    private readonly Route _route;

    protected OptimalShipChooser(
        Route route,
        IOptimalShipChoosingStrategy shipChoosingStrategy)
    {
        _route = route;
        ShipChoosingStrategy = shipChoosingStrategy;
    }

    private IOptimalShipChoosingStrategy ShipChoosingStrategy { get; }

    public ISpaceShip? ChooseOptimalShip(ISpaceShip first, ISpaceShip second)
    {
        return ShipChoosingStrategy.FindOptimalShip(first, second, _route);
    }
}