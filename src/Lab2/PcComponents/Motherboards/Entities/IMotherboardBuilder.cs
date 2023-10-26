using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithCpuSocket(CpuSocket socket);
    IMotherboardBuilder WithPciEAmount(MotherboardPciEAmount amount);
    IMotherboardBuilder WithSataAmount(MotherboardSataAmount amount);
    IMotherboardBuilder WithChipset(Chipset chipset);
    IMotherboardBuilder WithDdrVersion(RamDdrVersion version);
    IMotherboardBuilder WithRamSocketAmount(MotherboardRamAmount amount);
    IMotherboardBuilder WithFormFactor(MotherboardFormFactor formFactor);
    IMotherboardBuilder WithWiFiModule(bool wifi);
    IMotherboardBuilder WithBios(IBios bios);
    IMotherboard Build();
}