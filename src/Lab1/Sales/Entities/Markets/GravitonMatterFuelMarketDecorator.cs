using Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.CostStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.Markets;

public class GravitonMatterFuelMarketDecorator : FuelMarketDecorator
{
    private readonly GravitonMatterCostStrategy _gravitonMatterCostStrategy;

    public GravitonMatterFuelMarketDecorator(IFuelMarket fuelMarket, GravitonMatterCostStrategy gravitonMatterCostStrategy)
        : base(fuelMarket)
    {
        _gravitonMatterCostStrategy = gravitonMatterCostStrategy;
    }

    public override decimal GetCost(Fuel fuel)
    {
        if (fuel.FuelType is FuelType.GravitonMatter)
        {
            _gravitonMatterCostStrategy.GetCost(fuel);
        }

        return base.GetCost(fuel);
    }
}