namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

public record TravelResult()
{
    public TravelResult(double travelTimeTaken, double travelFuelConsumption)
        : this()
    {
        TravelTimeTaken = travelTimeTaken;
        TravelFuelConsumption = travelFuelConsumption;
    }

    public double TravelTimeTaken { get; init; }
    public double TravelFuelConsumption { get; init; }
}