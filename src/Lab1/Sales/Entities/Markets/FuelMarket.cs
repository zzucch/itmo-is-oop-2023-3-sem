using Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.CostStrategies;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.Markets;

public class FuelMarket : IFuelMarket
{
    private readonly IFuelCostStrategy _fuelCostStrategy;

    public FuelMarket(IFuelCostStrategy fuelCostStrategy)
    {
        _fuelCostStrategy = fuelCostStrategy;
    }

    public decimal GetCost(Fuel fuel)
    {
        return _fuelCostStrategy.GetCost(fuel);
    }
}