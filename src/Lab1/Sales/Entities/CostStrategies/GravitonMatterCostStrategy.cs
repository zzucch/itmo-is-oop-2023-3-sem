using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.CostStrategies;

public class GravitonMatterCostStrategy : IFuelCostStrategy
{
    private readonly decimal _gravitonMatterCost;

    public GravitonMatterCostStrategy(decimal gravitonMatterCost)
    {
        _gravitonMatterCost = gravitonMatterCost;
    }

    public decimal GetCost(Fuel fuel)
    {
        return _gravitonMatterCost * (decimal)fuel.Amount;
    }
}