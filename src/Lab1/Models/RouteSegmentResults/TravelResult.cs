namespace Itmo.ObjectOrientedProgramming.Lab1.Models.RouteSegmentResults;

public record TravelResult(
    bool Success,
    double TravelTimeTaken,
    Fuel FuelTypeConsumed,
    double TravelFuelConsumption,
    bool ShipLost);