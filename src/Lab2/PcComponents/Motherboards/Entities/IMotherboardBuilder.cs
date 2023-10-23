using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithCpuSocket(string socket);
    IMotherboardBuilder WithPciEAmount(int amount);
    IMotherboardBuilder WithSataAmount(int amount);
    IMotherboardBuilder WithChipset(Chipset chipset);
    IMotherboardBuilder WithDdrVersion(int version);
    IMotherboardBuilder WithRamSocketAmount(int amount);
    IMotherboardBuilder WithFormFactor(string formFactor);
    IMotherboardBuilder WithWiFiModule(bool wifi);
    IMotherboardBuilder WithBios(IBios bios);
    IMotherboard Build();
}