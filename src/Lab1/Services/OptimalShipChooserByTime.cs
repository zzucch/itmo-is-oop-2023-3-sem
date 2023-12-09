using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.Markets;
using Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShipChoosingStrategies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class OptimalShipChooserByTime : OptimalShipChooser
{
    private const decimal ActivePlasmaCost = 100;
    private const decimal GravitonMatterCost = 200;

    public OptimalShipChooserByTime(Route route)
        : base(route, new OptimalShipChoosingStrategyByTime(new FuelMarket(ActivePlasmaCost, GravitonMatterCost)))
    {
    }
}