using Itmo.ObjectOrientedProgramming.Lab1.Hulls.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Hulls.Entities;

public class Hull
{
    public Hull(HullStrength hullStrength, double hitPointsLeft, MassDimensional massDimensional)
    {
        HullStrength = hullStrength;
        HitPointsLeft = hitPointsLeft;
        MassDimensional = massDimensional;
    }

    private HullStrength HullStrength { get; }
    private double HitPointsLeft { get; set; }
    private MassDimensional MassDimensional { get; }

    public bool TryHullDeflect(double damageDealt)
    {
        damageDealt *= HullStrength switch
        {
            HullStrength.Class1 => 0.9,
            HullStrength.Class2 => 0.8,
            HullStrength.Class3 => 0.7,
            _ => 1,
        };

        damageDealt *= MassDimensional switch
        {
            MassDimensional.Low => 0.9,
            MassDimensional.Medium => 0.8,
            MassDimensional.High => 0.7,
            _ => 1,
        };

        if (damageDealt >= HitPointsLeft)
        {
            HitPointsLeft = 0;
            return false;
        }

        HitPointsLeft -= damageDealt;
        return true;
    }
}