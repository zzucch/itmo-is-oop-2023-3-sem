using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;

public class Hull
{
    public Hull(HullStrength hullStrength, double hitPointsLeft)
    {
        HullStrength = hullStrength;
        HitPointsLeft = hitPointsLeft;
    }

    private double HitPointsLeft { get; set; }
    private HullStrength HullStrength { get; init; }

    public bool TryHullDeflect(double damageDealt)
    {
        switch (HullStrength)
        {
            case HullStrength.Class1:
                damageDealt *= 0.9;
                break;
            case HullStrength.Class2:
                damageDealt *= 0.8;
                break;
            case HullStrength.Class3:
                damageDealt *= 0.7;
                break;
            default:
                damageDealt *= 1;
                break;
        }

        if (damageDealt >= HitPointsLeft)
        {
            HitPointsLeft = 0;
            return false;
        }

        HitPointsLeft -= damageDealt;
        return true;
    }
}