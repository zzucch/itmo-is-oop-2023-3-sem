using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;

public class Motherboard : IMotherboard
{
    private readonly CpuSocket _cpuSocket;
    private readonly RamDdrVersion _ddrVersion;

    internal Motherboard(
        CpuSocket cpuSocket,
        MotherboardPciEAmount pciEAmount,
        MotherboardSataAmount sataAmount,
        Chipset chipset,
        RamDdrVersion ddrVersion,
        MotherboardRamAmount ramSocketAmount,
        MotherboardFormFactor formFactor,
        bool wiFiModule,
        IBios bios,
        PcComponentName name)
    {
        _cpuSocket = cpuSocket;
        PciEAmount = pciEAmount;
        SataAmount = sataAmount;
        Chipset = chipset;
        _ddrVersion = ddrVersion;
        RamSocketAmount = ramSocketAmount;
        FormFactor = formFactor;
        WiFiModule = wiFiModule;
        Bios = bios;
        Name = name;
    }

    public IBios Bios { get; }
    public PcComponentName Name { get; }
    public MotherboardSataAmount SataAmount { get; }
    public MotherboardPciEAmount PciEAmount { get; }
    public Chipset Chipset { get; }
    public bool WiFiModule { get; }
    public MotherboardFormFactor FormFactor { get; }
    public MotherboardRamAmount RamSocketAmount { get; }

    public bool IsCompatibleWithSocket(CpuSocket socket)
    {
        return socket == _cpuSocket;
    }

    public bool IsCompatibleWithDdrVersion(RamDdrVersion ddrVersion)
    {
        return ddrVersion == _ddrVersion;
    }

    public IMotherboardBuilder Direct(IMotherboardBuilder builder)
    {
        builder
            .WithCpuSocket(_cpuSocket)
            .WithPciEAmount(PciEAmount)
            .WithSataAmount(SataAmount)
            .WithChipset(Chipset)
            .WithDdrVersion(_ddrVersion)
            .WithRamSocketAmount(RamSocketAmount)
            .WithFormFactor(FormFactor)
            .WithWiFiModule(WiFiModule)
            .WithBios(Bios);

        return builder;
    }
}