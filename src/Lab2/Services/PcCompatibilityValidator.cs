using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class PcCompatibilityValidator
{
    private readonly IPc _pc;

    public PcCompatibilityValidator(IPc pc)
    {
        _pc = pc;
    }

    public BuildResult Validate()
    {
        bool success = true;
        var comments = new List<string>();
        bool warrantyDisclaimer = false;

        if (_pc.IsSingleOrNoneWiFiModule() is false)
        {
            success = false;
            comments.Add("two conflicting Wi-Fi modules");
        }

        if (_pc.IsAtLeastOneDiskDrivePresent() is false)
        {
            success = false;
            comments.Add("no disk drive");
        }

        if (_pc.IsCpuWithGpuOrPcWithGraphicsCard() is false)
        {
            success = false;
            comments.Add("no CPU's IGP or graphics card");
        }

        if (_pc.IsRamXmpSupportedOrNoXmp() is false)
        {
            success = false;
            comments.Add("no RAM's XMP support");
        }

        if (_pc.IsBiosAndCpuCompatible() is false)
        {
            success = false;
            comments.Add("incompatible BIOS and CPU");
        }

        if (_pc.IsCpuAndRamProfileCompatible() is false)
        {
            success = false;
            comments.Add("incompatible CPU and RAM profile");
        }

        if (_pc.IsMotherboardAndRamProfileCompatible() is false)
        {
            success = false;
            comments.Add("incompatible RAM and motherboard");
        }

        if (_pc.IsMotherboardAndRamXmpCompatible() is false)
        {
            success = false;
            comments.Add("incompatible motherboard and RAM XMP");
        }

        if (_pc.IsMotherboardAndCpuSocketCompatible() is false)
        {
            success = false;
            comments.Add("incompatible motherboard CPU socket and CPU");
        }

        if (_pc.IsMotherboardAndRamDdrVersionCompatible() is false)
        {
            success = false;
            comments.Add("incompatible motherboard and RAM DDR version");
        }

        if (_pc.IsCpuCoolingSystemAndCpuSocketCompatible() is false)
        {
            success = false;
            comments.Add("incompatible CPU cooling system and CPU socket");
        }

        if (_pc.IsCpuCoolingSystemTdpAndCpuTdpCompatible() is false)
        {
            comments.Add("incompatible CPU cooling system and CPU TDP");
            warrantyDisclaimer = true;
        }

        if (_pc.IsMotherboardPciEAmountEnough() is false)
        {
            success = false;
            comments.Add("not enough motherboard PCIe slots");
        }

        if (_pc.IsMotherboardSataAmountEnough() is false)
        {
            success = false;
            comments.Add("not enough motherboard SATA slots");
        }

        if (_pc.IsMotherboardRamSocketsAmountEnough() is false)
        {
            success = false;
            comments.Add("not enough motherboard RAM sockets");
        }

        if (_pc.IsGraphicsCardSizeAndPcCaseCompatible() is false)
        {
            success = false;
            comments.Add("incompatible graphics card and PC case");
        }

        if (_pc.IsCpuCoolingSystemSizeAndPcCaseCompatible() is false)
        {
            success = false;
            comments.Add("incompatible CPU cooling system and PC case");
        }

        if (_pc.IsMotherboardFormFactorAndPcCaseCompatible() is false)
        {
            success = false;
            comments.Add("incompatible motherboard form factor and PC case");
        }

        if (_pc.IsRecommendedPsuPower() is false)
        {
            if (_pc.IsPsuPowerEnough())
            {
                comments.Add("PSU power is below recommended, warranty is disclaimed");
                warrantyDisclaimer = true;
            }
            else
            {
                success = false;
                comments.Add("PSU power is below needed");
            }
        }

        if (success is false)
        {
            warrantyDisclaimer = true;
        }

        return new BuildResult(
            Success: success,
            Comments: new ReadOnlyCollection<string>(comments),
            WarrantyDisclaimer: warrantyDisclaimer);
    }
}