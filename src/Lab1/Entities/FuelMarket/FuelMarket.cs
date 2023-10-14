using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.FuelMarket;

public class FuelMarket
{
    public FuelMarket(decimal activePlasmaCost, decimal gravitonMatterCost)
    {
        ActivePlasmaCost = activePlasmaCost;
        GravitonMatterCost = gravitonMatterCost;
    }

    private decimal ActivePlasmaCost { get; }
    private decimal GravitonMatterCost { get; }

    public decimal GetCost(Fuel fuel, double amount)
    {
        decimal amount1 = (decimal)amount;
        return fuel switch
        {
            Fuel.ActivePlasma => ActivePlasmaCost * amount1,
            Fuel.GravitonMatter => GravitonMatterCost * amount1,
            _ => throw new ArgumentOutOfRangeException(nameof(fuel), fuel, "this type of fuel does not exist on Fuel Market"),
        };
    }
}