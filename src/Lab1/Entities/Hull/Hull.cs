using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

public class Hull
{
    public Hull(HullStrength hullStrength, MassDimensional massDimensional)
    {
        HullStrength = hullStrength;
        MassDimensional = massDimensional;
    }

    private double HitPointsLeft { get; set; } = 100;
    private HullStrength HullStrength { get; }
    private MassDimensional MassDimensional { get; }

    public bool TryHullDeflect(double damageDealt)
    {
        damageDealt *= HullStrength switch
        {
            HullStrength.Class1 => 0.9,
            HullStrength.Class2 => 0.75,
            HullStrength.Class3 => 0.25,
            _ => 1,
        };

        damageDealt *= MassDimensional switch
        {
            MassDimensional.Low => 0.9,
            MassDimensional.Medium => 0.75,
            MassDimensional.High => 0.25,
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