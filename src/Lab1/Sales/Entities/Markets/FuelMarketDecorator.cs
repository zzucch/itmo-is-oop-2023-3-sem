using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.Markets;

public abstract class FuelMarketDecorator : IFuelMarket
{
    protected FuelMarketDecorator(IFuelMarket fuelMarket)
    {
        FuelMarket = fuelMarket;
    }

    private IFuelMarket FuelMarket { get; }

    public virtual decimal GetCost(Fuel fuel)
    {
        return FuelMarket.GetCost(fuel);
    }
}