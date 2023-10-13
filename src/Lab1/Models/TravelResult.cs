namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public record TravelResult(bool Success)
{
    public TravelResult(double travelTimeTaken, Fuel fuelTypeConsumed, double travelFuelConsumption, bool success)
        : this(success)
    {
        TravelTimeTaken = travelTimeTaken;
        FuelTypeConsumed = fuelTypeConsumed;
        TravelFuelConsumption = travelFuelConsumption;
    }

    public bool Success { get; set; } = Success;
    public double TravelTimeTaken { get; init; }
    public Fuel FuelTypeConsumed { get; set; }
    public double TravelFuelConsumption { get; init; }
}