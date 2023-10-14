using System;
using Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.FuelMarket.Entities;

public class FuelMarket : IFuelMarket
{
    public FuelMarket(decimal activePlasmaCost, decimal gravitonMatterCost)
    {
        ActivePlasmaCost = activePlasmaCost;
        GravitonMatterCost = gravitonMatterCost;
    }

    private decimal ActivePlasmaCost { get; }
    private decimal GravitonMatterCost { get; }

    public decimal GetCost(Fuel fuel)
    {
        decimal amount1 = (decimal)fuel.Amount;
        return fuel.FuelType switch
        {
            FuelType.ActivePlasma => ActivePlasmaCost * amount1,
            FuelType.GravitonMatter => GravitonMatterCost * amount1,
            _ => throw new ArgumentOutOfRangeException(nameof(fuel.FuelType), fuel.FuelType, "this type of fuel does not exist on Fuel Market"),
        };
    }
}