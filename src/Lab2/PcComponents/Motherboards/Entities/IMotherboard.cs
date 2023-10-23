using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public interface IMotherboard : IMotherboardBuilderDirector
{
    public IBios Bios { get; }
    public int SataAmount { get; }
    public int PciEAmount { get; }
    public bool WiFiModule { get; }
    public string FormFactor { get; }
    public int RamSocketAmount { get; }
    public bool IsCompatibleWithSocket(string socket);
    public bool IsCompatibleWithDdrVersion(int ddrVersion);
}