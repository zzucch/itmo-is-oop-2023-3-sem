using Itmo.ObjectOrientedProgramming.Lab1.Routes.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.CostStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.Markets;
using Itmo.ObjectOrientedProgramming.Lab1.Services.OptimalShipChoosingStrategies;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class OptimalShipChooserByMoney : OptimalShipChooser
{
    private const decimal ActivePlasmaCost = 100;
    private const decimal GravitonMatterCost = 200;

    public OptimalShipChooserByMoney(Route route)
        : base(route, new OptimalShipChoosingStrategyByTime(new GravitonMatterFuelMarketDecorator(
            new FuelMarket(new ActivePlasmaCostStrategy(ActivePlasmaCost)),
            new GravitonMatterCostStrategy(GravitonMatterCost))))
    {
    }
}