using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public interface IMotherboard : IMotherboardBuilderDirector
{
    public IBios Bios { get; }
    public MotherboardSataAmount SataAmount { get; }
    public MotherboardPciEAmount PciEAmount { get; }
    public bool WiFiModule { get; }
    public Chipset Chipset { get; }
    public MotherboardFormFactor FormFactor { get; }
    public MotherboardRamAmount RamSocketAmount { get; }
    public bool IsCompatibleWithSocket(CpuSocket socket);
    public bool IsCompatibleWithDdrVersion(RamDdrVersion ddrVersion);
}