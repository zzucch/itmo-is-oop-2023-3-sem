using Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.Results;

public record ShipDeflectionResult(
    DeflectionResult? DeflectorResult,
    DeflectionResult? HullResult);