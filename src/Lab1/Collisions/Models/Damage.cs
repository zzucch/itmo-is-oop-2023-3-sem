namespace Itmo.ObjectOrientedProgramming.Lab1.Collisions.Models;

public abstract record Damage
{
    public sealed record Physical(int Amount) : Damage;

    public sealed record Photon(int Amount) : Damage;
}