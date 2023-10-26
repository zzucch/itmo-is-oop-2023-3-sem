using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Rams.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Ssds.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PcCompatibilityValidatorTest
{
    [Fact]
    public void Validate_ShouldReturnSuccessWithWarranty_WhenUsingCompatibleComponents()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder();

        var ryzen2200G = new Cpu(
            coreSpeed: new CpuCoreSpeed(mHz: 3700),
            coreAmount: new CpuCoreAmount(4),
            socket: new CpuSocket("AM4"),
            integratedGraphicsProcessor: true,
            supportedMemoryFrequencies: new[] { new RamFrequency(kHz: 2933) },
            tdp: new Tdp(watts: 65),
            powerConsumption: new PowerConsumption(watts: 65));

        pcBuilder
            .WithCpu(ryzen2200G)
            .WithCpuCooling(new CpuCoolingSystem(
                new CoolingSystemDimensions(
                    Height: 131,
                    Width: 121,
                    Length: 77),
                sockets: new[]
                {
                    new CpuSocket("AM2"),
                    new CpuSocket("AM2+"),
                    new CpuSocket("AM3"),
                    new CpuSocket("AM3+"),
                    new CpuSocket("AM4"),
                    new CpuSocket("AM5"),
                    new CpuSocket("FM1"),
                    new CpuSocket("FM2"),
                    new CpuSocket("FM2+"),
                    new CpuSocket("LGA 1150"),
                    new CpuSocket("LGA 1151"),
                    new CpuSocket("LGA 1151-v2"),
                    new CpuSocket("LGA 1155"),
                    new CpuSocket("LGA 1156"),
                    new CpuSocket("LGA 1200"),
                },
                tdp: new Tdp(watts: 130)))
            .WithMotherboard(new Motherboard(
                cpuSocket: new CpuSocket("AM4"),
                pciEAmount: new MotherboardPciEAmount(1),
                sataAmount: new MotherboardSataAmount(4),
                new Chipset(
                    SupportedRamFrequencies: new[]
                    {
                        new RamFrequency(kHz: 2933),
                        new RamFrequency(kHz: 3200),
                    },
                    SupportsXmp: false),
                ddrVersion: new RamDdrVersion(4),
                ramSocketAmount: new MotherboardRamAmount(2),
                formFactor: new MotherboardFormFactor("Micro-ATX"),
                wiFiModule: false,
                new Bios(
                    type: new BiosType("AMI UEFI"),
                    version: new BiosVersion("P1.30"),
                    cpus: new[]
                    {
                        ryzen2200G,
                    })))
            .WithPcCase(new PcCase(
                motherboardFormFactors: new[]
                {
                    new MotherboardFormFactor("Micro-ATX"),
                    new MotherboardFormFactor("Mini-ITX"),
                },
                dimensions: new PcCaseDimensions(
                    Width: 205,
                    Length: 380,
                    Height: 390,
                    MaxCpuCoolingSystemUnitHeight: 155,
                    MaxCpuCoolingSystemUnitLength: 130,
                    MaxCpuCoolingSystemUnitWidth: 130,
                    GraphicsCardMaxHeight: 100,
                    GraphicsCardMaxLenght: 350,
                    GraphicsCardMaxWidth: 100)))
            .WithPsu(new Psu(
                peakLoad: new PowerConsumption(500)))
            .WithWiFiAdapter(new WiFiAdapter(
                wifiVersion: 4,
                builtInBluetooth: false,
                pciEVersion: 1,
                powerConsumption: new PowerConsumption(1)));

        pcBuilder.AddRam(new Ram(
            capacity: new RamCapacity(16),
            jedecProfiles: new[]
            {
                new JedecProfile(new RamFrequency(kHz: 2933), new RamTimings(cl: 19, rcd: 19, rp: 19, ras: 32)),
                new JedecProfile(new RamFrequency(kHz: 3200), new RamTimings(cl: 16, rcd: 18, rp: 18, ras: 36)),
            },
            xmps: new List<IXmp>(),
            formFactor: new RamFormFactor.Dimm(),
            ddrVersion: new RamDdrVersion(4),
            powerConsumption: new PowerConsumption(watts: new decimal(2.0))));

        pcBuilder.AddSsd(new Ssd(
            connectionInterface: SsdConnectionInterface.Sata,
            capacity: 480,
            speed: 7440,
            powerConsumption: new PowerConsumption(watts: 15)));

        IPc pc = pcBuilder.Build();

        var validator = new PcCompatibilityValidator(pc);

        // Act
        BuildResult result = validator.Validate();

        // Assert
        Assert.True(result.Success);
        Assert.Empty(result.Comments);
        Assert.False(result.WarrantyDisclaimer);
    }

    [Fact]
    public void Validate_ShouldEndWithWarrantyDisclaimer_WhenPsuPowerIsBelowRecommendedButEnough()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder();

        var ryzen2200GWithMorePowerConsumption = new Cpu(
            coreSpeed: new CpuCoreSpeed(mHz: 3700),
            coreAmount: new CpuCoreAmount(4),
            socket: new CpuSocket("AM4"),
            integratedGraphicsProcessor: true,
            supportedMemoryFrequencies: new[] { new RamFrequency(kHz: 2933) },
            tdp: new Tdp(watts: 65),
            powerConsumption: new PowerConsumption(watts: 480));

        pcBuilder
            .WithCpu(ryzen2200GWithMorePowerConsumption)
            .WithCpuCooling(new CpuCoolingSystem(
                new CoolingSystemDimensions(
                    Height: 131,
                    Width: 121,
                    Length: 77),
                sockets: new[]
                {
                    new CpuSocket("AM2"),
                    new CpuSocket("AM2+"),
                    new CpuSocket("AM3"),
                    new CpuSocket("AM3+"),
                    new CpuSocket("AM4"),
                    new CpuSocket("AM5"),
                    new CpuSocket("FM1"),
                    new CpuSocket("FM2"),
                    new CpuSocket("FM2+"),
                    new CpuSocket("LGA 1150"),
                    new CpuSocket("LGA 1151"),
                    new CpuSocket("LGA 1151-v2"),
                    new CpuSocket("LGA 1155"),
                    new CpuSocket("LGA 1156"),
                    new CpuSocket("LGA 1200"),
                },
                tdp: new Tdp(watts: 130)))
            .WithMotherboard(new Motherboard(
                cpuSocket: new CpuSocket("AM4"),
                pciEAmount: new MotherboardPciEAmount(1),
                sataAmount: new MotherboardSataAmount(4),
                new Chipset(
                    SupportedRamFrequencies: new[]
                    {
                        new RamFrequency(kHz: 2933),
                        new RamFrequency(kHz: 3200),
                    },
                    SupportsXmp: false),
                ddrVersion: new RamDdrVersion(4),
                ramSocketAmount: new MotherboardRamAmount(2),
                formFactor: new MotherboardFormFactor("Micro-ATX"),
                wiFiModule: false,
                new Bios(
                    type: new BiosType("AMI UEFI"),
                    version: new BiosVersion("P1.30"),
                    cpus: new[]
                    {
                        ryzen2200GWithMorePowerConsumption,
                    })))
            .WithPcCase(new PcCase(
                motherboardFormFactors: new[]
                {
                    new MotherboardFormFactor("Micro-ATX"),
                    new MotherboardFormFactor("Mini-ITX"),
                },
                dimensions: new PcCaseDimensions(
                    Width: 205,
                    Length: 380,
                    Height: 390,
                    MaxCpuCoolingSystemUnitHeight: 155,
                    MaxCpuCoolingSystemUnitLength: 130,
                    MaxCpuCoolingSystemUnitWidth: 130,
                    GraphicsCardMaxHeight: 100,
                    GraphicsCardMaxLenght: 350,
                    GraphicsCardMaxWidth: 100)))
            .WithPsu(new Psu(
                peakLoad: new PowerConsumption(watts: 500)))
            .WithWiFiAdapter(new WiFiAdapter(
                wifiVersion: 4,
                builtInBluetooth: false,
                pciEVersion: 1,
                powerConsumption: new PowerConsumption(watts: 1)));

        pcBuilder.AddRam(new Ram(
            capacity: new RamCapacity(gBytes: 16),
            jedecProfiles: new[]
            {
                new JedecProfile(new RamFrequency(kHz: 2933), new RamTimings(cl: 19, rcd: 19, rp: 19, ras: 32)),
                new JedecProfile(new RamFrequency(kHz: 3200), new RamTimings(cl: 16, rcd: 18, rp: 18, ras: 36)),
            },
            xmps: new List<IXmp>(),
            formFactor: new RamFormFactor.Dimm(),
            ddrVersion: new RamDdrVersion(4),
            powerConsumption: new PowerConsumption(watts: new decimal(2.0))));

        pcBuilder.AddSsd(new Ssd(
            connectionInterface: SsdConnectionInterface.Sata,
            capacity: 480,
            speed: 7440,
            powerConsumption: new PowerConsumption(watts: 15)));

        IPc pc = pcBuilder.Build();

        var validator = new PcCompatibilityValidator(pc);

        // Act
        BuildResult result = validator.Validate();

        // Assert
        Assert.True(result.Success);
        Assert.Contains(
            collection: result.Comments,
            filter: s => s == "PSU power is below recommended, warranty is disclaimed");
        Assert.True(result.WarrantyDisclaimer);
    }

    [Fact]
    public void Validate_ShouldEndWithWarrantyDisclaimer_WhenCpuCoolingSystemMaxTdpIsBelowCpuTdp()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder();

        var ryzen2200GWithMoreTdp = new Cpu(
            coreSpeed: new CpuCoreSpeed(mHz: 3700),
            coreAmount: new CpuCoreAmount(4),
            socket: new CpuSocket("AM4"),
            integratedGraphicsProcessor: true,
            supportedMemoryFrequencies: new[] { new RamFrequency(kHz: 2933) },
            tdp: new Tdp(watts: 1000),
            powerConsumption: new PowerConsumption(watts: 65));

        pcBuilder
            .WithCpu(ryzen2200GWithMoreTdp)
            .WithCpuCooling(new CpuCoolingSystem(
                new CoolingSystemDimensions(
                    Height: 131,
                    Width: 121,
                    Length: 77),
                sockets: new[]
                {
                    new CpuSocket("AM2"),
                    new CpuSocket("AM2+"),
                    new CpuSocket("AM3"),
                    new CpuSocket("AM3+"),
                    new CpuSocket("AM4"),
                    new CpuSocket("AM5"),
                    new CpuSocket("FM1"),
                    new CpuSocket("FM2"),
                    new CpuSocket("FM2+"),
                    new CpuSocket("LGA 1150"),
                    new CpuSocket("LGA 1151"),
                    new CpuSocket("LGA 1151-v2"),
                    new CpuSocket("LGA 1155"),
                    new CpuSocket("LGA 1156"),
                    new CpuSocket("LGA 1200"),
                },
                tdp: new Tdp(watts: 130)))
            .WithMotherboard(new Motherboard(
                cpuSocket: new CpuSocket("AM4"),
                pciEAmount: new MotherboardPciEAmount(1),
                sataAmount: new MotherboardSataAmount(4),
                new Chipset(
                    SupportedRamFrequencies: new[]
                    {
                        new RamFrequency(kHz: 2933),
                        new RamFrequency(kHz: 3200),
                    },
                    SupportsXmp: false),
                ddrVersion: new RamDdrVersion(4),
                ramSocketAmount: new MotherboardRamAmount(2),
                formFactor: new MotherboardFormFactor("Micro-ATX"),
                wiFiModule: false,
                new Bios(
                    type: new BiosType("AMI UEFI"),
                    version: new BiosVersion("P1.30"),
                    cpus: new[]
                    {
                        ryzen2200GWithMoreTdp,
                    })))
            .WithPcCase(new PcCase(
                motherboardFormFactors: new[]
                {
                    new MotherboardFormFactor("Micro-ATX"),
                    new MotherboardFormFactor("Mini-ITX"),
                },
                dimensions: new PcCaseDimensions(
                    Width: 205,
                    Length: 380,
                    Height: 390,
                    MaxCpuCoolingSystemUnitHeight: 155,
                    MaxCpuCoolingSystemUnitLength: 130,
                    MaxCpuCoolingSystemUnitWidth: 130,
                    GraphicsCardMaxHeight: 100,
                    GraphicsCardMaxLenght: 350,
                    GraphicsCardMaxWidth: 100)))
            .WithPsu(new Psu(
                peakLoad: new PowerConsumption(watts: 500)))
            .WithWiFiAdapter(new WiFiAdapter(
                wifiVersion: 4,
                builtInBluetooth: false,
                pciEVersion: 1,
                powerConsumption: new PowerConsumption(watts: 1)));

        pcBuilder.AddRam(new Ram(
            capacity: new RamCapacity(gBytes: 16),
            jedecProfiles: new[]
            {
                new JedecProfile(new RamFrequency(kHz: 2933), new RamTimings(cl: 19, rcd: 19, rp: 19, ras: 32)),
                new JedecProfile(new RamFrequency(kHz: 3200), new RamTimings(cl: 16, rcd: 18, rp: 18, ras: 36)),
            },
            xmps: new List<IXmp>(),
            formFactor: new RamFormFactor.Dimm(),
            ddrVersion: new RamDdrVersion(4),
            powerConsumption: new PowerConsumption(watts: new decimal(2.0))));

        pcBuilder.AddSsd(new Ssd(
            connectionInterface: SsdConnectionInterface.Sata,
            capacity: 480,
            speed: 7440,
            powerConsumption: new PowerConsumption(watts: 15)));

        IPc pc = pcBuilder.Build();

        var validator = new PcCompatibilityValidator(pc);

        // Act
        BuildResult result = validator.Validate();

        // Assert
        Assert.True(result.Success);
        Assert.Contains(
            collection: result.Comments,
            filter: s => s == "incompatible CPU cooling system and CPU TDP, warranty is disclaimed");
        Assert.True(result.WarrantyDisclaimer);
    }

    [Fact]
    public void Validate_ShouldReturnFailure_WhenUsingIncompatibleCpuAndMotherboard()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder();

        var ryzen2200G = new Cpu(
            coreSpeed: new CpuCoreSpeed(mHz: 3700),
            coreAmount: new CpuCoreAmount(4),
            socket: new CpuSocket("AM4"),
            integratedGraphicsProcessor: true,
            supportedMemoryFrequencies: new[] { new RamFrequency(kHz: 2933) },
            tdp: new Tdp(watts: 1000),
            powerConsumption: new PowerConsumption(watts: 65));

        pcBuilder
            .WithCpu(ryzen2200G)
            .WithCpuCooling(new CpuCoolingSystem(
                new CoolingSystemDimensions(
                    Height: 131,
                    Width: 121,
                    Length: 77),
                sockets: new[]
                {
                    new CpuSocket("AM2"),
                    new CpuSocket("AM2+"),
                    new CpuSocket("AM3"),
                    new CpuSocket("AM3+"),
                    new CpuSocket("FM1"),
                    new CpuSocket("FM2"),
                    new CpuSocket("FM2+"),
                },
                tdp: new Tdp(watts: 130)))
            .WithMotherboard(new Motherboard(
                cpuSocket: new CpuSocket("AM5"),
                pciEAmount: new MotherboardPciEAmount(1),
                sataAmount: new MotherboardSataAmount(4),
                new Chipset(
                    SupportedRamFrequencies: new[]
                    {
                        new RamFrequency(kHz: 2933),
                        new RamFrequency(kHz: 3200),
                    },
                    SupportsXmp: false),
                ddrVersion: new RamDdrVersion(4),
                ramSocketAmount: new MotherboardRamAmount(2),
                formFactor: new MotherboardFormFactor("Micro-ATX"),
                wiFiModule: false,
                new Bios(
                    type: new BiosType("AMI UEFI"),
                    version: new BiosVersion("P1.30"),
                    cpus: new[]
                    {
                        ryzen2200G,
                    })))
            .WithPcCase(new PcCase(
                motherboardFormFactors: new[]
                {
                    new MotherboardFormFactor("Micro-ATX"),
                    new MotherboardFormFactor("Mini-ITX"),
                },
                dimensions: new PcCaseDimensions(
                    Width: 205,
                    Length: 380,
                    Height: 390,
                    MaxCpuCoolingSystemUnitHeight: 155,
                    MaxCpuCoolingSystemUnitLength: 130,
                    MaxCpuCoolingSystemUnitWidth: 130,
                    GraphicsCardMaxHeight: 100,
                    GraphicsCardMaxLenght: 350,
                    GraphicsCardMaxWidth: 100)))
            .WithPsu(new Psu(
                peakLoad: new PowerConsumption(watts: 500)))
            .WithWiFiAdapter(new WiFiAdapter(
                wifiVersion: 4,
                builtInBluetooth: false,
                pciEVersion: 1,
                powerConsumption: new PowerConsumption(watts: 1)));

        pcBuilder.AddRam(new Ram(
            capacity: new RamCapacity(gBytes: 16),
            jedecProfiles: new[]
            {
                new JedecProfile(new RamFrequency(kHz: 2933), new RamTimings(cl: 19, rcd: 19, rp: 19, ras: 32)),
                new JedecProfile(new RamFrequency(kHz: 3200), new RamTimings(cl: 16, rcd: 18, rp: 18, ras: 36)),
            },
            xmps: new List<IXmp>(),
            formFactor: new RamFormFactor.Dimm(),
            ddrVersion: new RamDdrVersion(4),
            powerConsumption: new PowerConsumption(watts: new decimal(2.0))));

        pcBuilder.AddSsd(new Ssd(
            connectionInterface: SsdConnectionInterface.Sata,
            capacity: 480,
            speed: 7440,
            powerConsumption: new PowerConsumption(watts: 15)));

        IPc pc = pcBuilder.Build();

        var validator = new PcCompatibilityValidator(pc);

        // Act
        BuildResult result = validator.Validate();

        // Assert
        Assert.False(result.Success);
        Assert.Contains(
            collection: result.Comments,
            filter: s => s == "incompatible CPU cooling system and CPU socket");
        Assert.Contains(
            collection: result.Comments,
            filter: s => s == "incompatible motherboard CPU socket and CPU");
        Assert.True(result.WarrantyDisclaimer);
    }

    [Fact]
    public void Validate_ShouldReturnFailure_WhenUsingIncompatibleMotherboardSlotsAmount()
    {
        // Arrange
        IPcBuilder pcBuilder = new PcBuilder();

        var ryzen2200G = new Cpu(
            coreSpeed: new CpuCoreSpeed(3700),
            coreAmount: new CpuCoreAmount(4),
            socket: new CpuSocket("AM4"),
            integratedGraphicsProcessor: true,
            supportedMemoryFrequencies: new[] { new RamFrequency(kHz: 2933) },
            tdp: new Tdp(watts: 65),
            powerConsumption: new PowerConsumption(watts: 65));

        pcBuilder
            .WithCpu(ryzen2200G)
            .WithCpuCooling(new CpuCoolingSystem(
                new CoolingSystemDimensions(
                    Height: 131,
                    Width: 121,
                    Length: 77),
                sockets: new[]
                {
                    new CpuSocket("AM2"),
                    new CpuSocket("AM2+"),
                    new CpuSocket("AM3"),
                    new CpuSocket("AM3+"),
                    new CpuSocket("AM4"),
                    new CpuSocket("AM5"),
                    new CpuSocket("FM1"),
                    new CpuSocket("FM2"),
                    new CpuSocket("FM2+"),
                    new CpuSocket("LGA 1150"),
                    new CpuSocket("LGA 1151"),
                    new CpuSocket("LGA 1151-v2"),
                    new CpuSocket("LGA 1155"),
                    new CpuSocket("LGA 1156"),
                    new CpuSocket("LGA 1200"),
                },
                tdp: new Tdp(watts: 130)))
            .WithMotherboard(new Motherboard(
                cpuSocket: new CpuSocket("AM4"),
                pciEAmount: new MotherboardPciEAmount(0),
                sataAmount: new MotherboardSataAmount(0),
                new Chipset(
                    SupportedRamFrequencies: new[]
                    {
                        new RamFrequency(kHz: 2933),
                        new RamFrequency(kHz: 3200),
                    },
                    SupportsXmp: false),
                ddrVersion: new RamDdrVersion(4),
                ramSocketAmount: new MotherboardRamAmount(2),
                formFactor: new MotherboardFormFactor("Micro-ATX"),
                wiFiModule: false,
                new Bios(
                    type: new BiosType("AMI UEFI"),
                    version: new BiosVersion("P1.30"),
                    cpus: new[]
                    {
                        ryzen2200G,
                    })))
            .WithPcCase(new PcCase(
                motherboardFormFactors: new[]
                {
                    new MotherboardFormFactor("Micro-ATX"),
                    new MotherboardFormFactor("Mini-ITX"),
                },
                dimensions: new PcCaseDimensions(
                    Width: 205,
                    Length: 380,
                    Height: 390,
                    MaxCpuCoolingSystemUnitHeight: 155,
                    MaxCpuCoolingSystemUnitLength: 130,
                    MaxCpuCoolingSystemUnitWidth: 130,
                    GraphicsCardMaxHeight: 100,
                    GraphicsCardMaxLenght: 350,
                    GraphicsCardMaxWidth: 100)))
            .WithPsu(new Psu(
                peakLoad: new PowerConsumption(watts: 500)))
            .WithWiFiAdapter(new WiFiAdapter(
                wifiVersion: 4,
                builtInBluetooth: false,
                pciEVersion: 1,
                powerConsumption: new PowerConsumption(watts: 1)));

        pcBuilder.AddRam(new Ram(
            capacity: new RamCapacity(16),
            jedecProfiles: new[]
            {
                new JedecProfile(new RamFrequency(kHz: 2933), new RamTimings(cl: 19, rcd: 19, rp: 19, ras: 32)),
                new JedecProfile(new RamFrequency(kHz: 3200), new RamTimings(cl: 16, rcd: 18, rp: 18, ras: 36)),
            },
            xmps: new List<IXmp>(),
            formFactor: new RamFormFactor.Dimm(),
            ddrVersion: new RamDdrVersion(4),
            powerConsumption: new PowerConsumption(watts: new decimal(2.0))));

        pcBuilder.AddSsd(new Ssd(
            connectionInterface: SsdConnectionInterface.Sata,
            capacity: 480,
            speed: 7440,
            powerConsumption: new PowerConsumption(watts: 15)));

        IPc pc = pcBuilder.Build();

        var validator = new PcCompatibilityValidator(pc);

        // Act
        BuildResult result = validator.Validate();

        // Assert
        Assert.False(result.Success);
        Assert.Contains(
            collection: result.Comments,
            filter: s => s == "not enough motherboard SATA slots");
        Assert.Contains(
            collection: result.Comments,
            filter: s => s == "not enough motherboard PCIe slots");
        Assert.True(result.WarrantyDisclaimer);
    }
}