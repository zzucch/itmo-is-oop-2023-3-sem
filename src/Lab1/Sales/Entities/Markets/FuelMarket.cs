using System;
using Itmo.ObjectOrientedProgramming.Lab1.Sales.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sales.Entities.Markets;

public class FuelMarket : IFuelMarket
{
    private readonly decimal _activePlasmaCost;
    private readonly decimal _gravitonMatterCost;

    public FuelMarket(decimal activePlasmaCost, decimal gravitonMatterCost)
    {
        _activePlasmaCost = activePlasmaCost;
        _gravitonMatterCost = gravitonMatterCost;
    }

    public decimal GetCost(Fuel fuel)
    {
        return fuel.FuelType switch
        {
            FuelType.None => 0,
            FuelType.ActivePlasma => GetActivePlasmaCost(fuel),
            FuelType.GravitonMatter => GetGravitonMatterCost(fuel),
            _ => throw new ArgumentOutOfRangeException(nameof(fuel)),
        };
    }

    private decimal GetActivePlasmaCost(Fuel fuel)
    {
        return _activePlasmaCost * (decimal)fuel.Amount;
    }

    private decimal GetGravitonMatterCost(Fuel fuel)
    {
        return _gravitonMatterCost * (decimal)fuel.Amount;
    }
}