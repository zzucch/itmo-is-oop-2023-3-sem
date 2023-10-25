using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.CpuCooling.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Motherboards.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.PcCases.Models;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Entities;
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
            coreSpeed: 3700,
            coreAmount: 4,
            socket: "AM4",
            integratedGraphicsProcessor: true,
            supportedMemoryFrequencies: new[] { 2933 },
            tdp: 65,
            powerConsumption: 65);

        pcBuilder
            .WithCpu(ryzen2200G)
            .WithCpuCooling(new CpuCoolingSystem(
                new CoolingSystemDimensions(
                    Height: 131,
                    Width: 121,
                    Length: 77),
                sockets: new[]
                {
                    "AM2",
                    "AM2+",
                    "AM3",
                    "AM3+",
                    "AM4",
                    "AM5",
                    "FM1",
                    "FM2",
                    "FM2+",
                    "LGA 1150",
                    "LGA 1151",
                    "LGA 1151-v2",
                    "LGA 1155",
                    "LGA 1156",
                    "LGA 1200",
                },
                tdp: 130))
            .WithMotherboard(new Motherboard(
                cpuSocket: "AM4",
                pciEAmount: 1,
                sataAmount: 4,
                new Chipset(
                    SupportedRamSpeeds: new[] { 2933, 3200 },
                    SupportsXmp: false),
                ddrVersion: 4,
                ramSocketAmount: 2,
                formFactor: "Micro-ATX",
                wiFiModule: false,
                new Bios(
                    type: "AMI UEFI",
                    version: "P1.30",
                    cpus: new[]
                    {
                        ryzen2200G,
                    })))
            .WithPcCase(new PcCase(
                motherboardFormFactors: new[] { "Micro-ATX", "Mini-ITX" },
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
                peakLoad: 500))
            .WithWiFiAdapter(new WiFiAdapter(
                wifiVersion: 4,
                builtInBluetooth: false,
                pciEVersion: 1,
                powerConsumption: 0));

        pcBuilder.AddRam(new Ram(
            capacity: 16,
            jedecProfiles: new[]
            {
                new JedecProfile(FrequencyKHz: 2933, new RamTimings(Cl: 19, Rcd: 19, Rp: 19, Ras: 32)),
                new JedecProfile(FrequencyKHz: 3200, new RamTimings(Cl: 16, Rcd: 18, Rp: 18, Ras: 36)),
            },
            xmps: new List<IXmp>(),
            formFactor: new RamFormFactor.Dimm(),
            ddrVersion: 4,
            powerConsumption: new decimal(2.0)));

        pcBuilder.AddSsd(new Ssd(
            connectionInterface: SsdConnectionInterface.Sata,
            capacity: 480,
            speed: 7440,
            powerConsumption: 15));

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
            coreSpeed: 3700,
            coreAmount: 4,
            socket: "AM4",
            integratedGraphicsProcessor: true,
            supportedMemoryFrequencies: new[] { 2933 },
            tdp: 65,
            powerConsumption: 480);

        pcBuilder
            .WithCpu(ryzen2200GWithMorePowerConsumption)
            .WithCpuCooling(new CpuCoolingSystem(
                new CoolingSystemDimensions(
                    Height: 131,
                    Width: 121,
                    Length: 77),
                sockets: new[]
                {
                    "AM2",
                    "AM2+",
                    "AM3",
                    "AM3+",
                    "AM4",
                    "AM5",
                    "FM1",
                    "FM2",
                    "FM2+",
                    "LGA 1150",
                    "LGA 1151",
                    "LGA 1151-v2",
                    "LGA 1155",
                    "LGA 1156",
                    "LGA 1200",
                },
                tdp: 130))
            .WithMotherboard(new Motherboard(
                cpuSocket: "AM4",
                pciEAmount: 1,
                sataAmount: 4,
                new Chipset(
                    SupportedRamSpeeds: new[] { 2933, 3200 },
                    SupportsXmp: false),
                ddrVersion: 4,
                ramSocketAmount: 2,
                formFactor: "Micro-ATX",
                wiFiModule: false,
                new Bios(
                    type: "AMI UEFI",
                    version: "P1.30",
                    cpus: new[]
                    {
                        ryzen2200GWithMorePowerConsumption,
                    })))
            .WithPcCase(new PcCase(
                motherboardFormFactors: new[] { "Micro-ATX", "Mini-ITX" },
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
                peakLoad: 500))
            .WithWiFiAdapter(new WiFiAdapter(
                wifiVersion: 4,
                builtInBluetooth: false,
                pciEVersion: 1,
                powerConsumption: 0));

        pcBuilder.AddRam(new Ram(
            capacity: 16,
            jedecProfiles: new[]
            {
                new JedecProfile(FrequencyKHz: 2933, new RamTimings(Cl: 19, Rcd: 19, Rp: 19, Ras: 32)),
                new JedecProfile(FrequencyKHz: 3200, new RamTimings(Cl: 16, Rcd: 18, Rp: 18, Ras: 36)),
            },
            xmps: new List<IXmp>(),
            formFactor: new RamFormFactor.Dimm(),
            ddrVersion: 4,
            powerConsumption: new decimal(2.0)));

        pcBuilder.AddSsd(new Ssd(
            connectionInterface: SsdConnectionInterface.Sata,
            capacity: 480,
            speed: 7440,
            powerConsumption: 15));

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
}