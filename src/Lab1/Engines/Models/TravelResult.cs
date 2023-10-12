namespace Itmo.ObjectOrientedProgramming.Lab1.Engines.Models;

public record TravelResult()
{
    public TravelResult(double travelTimeTaken, Fuel fuelTypeConsumed, double travelFuelConsumption)
        : this()
    {
        TravelTimeTaken = travelTimeTaken;
        FuelTypeConsumed = fuelTypeConsumed;
        TravelFuelConsumption = travelFuelConsumption;
    }

    public double TravelTimeTaken { get; init; }
    public Fuel FuelTypeConsumed { get; set; }
    public double TravelFuelConsumption { get; init; }
}