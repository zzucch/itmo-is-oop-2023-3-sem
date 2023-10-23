namespace Itmo.ObjectOrientedProgramming.Lab2.Pcs.Entities;

public interface IPc : IPcBuilderDirector
{
    public bool IsSingleOrNoneWiFiModule();
    public bool IsAtLeastOneDiskDrivePresent();
    public bool IsCpuWithGpuOrPcWithGraphicsCard();

    public bool IsBiosAndCpuCompatible();
    public bool IsCpuAndRamProfileCompatible();
    public bool IsMotherboardAndRamXmpCompatible();
    public bool IsMotherboardAndCpuSocketCompatible();
    public bool IsMotherboardAndRamDdrVersionCompatible();
    public bool IsCpuCoolingSystemAndCpuSocketCompatible();
    public bool IsCpuCoolingSystemTdpAndCpuTdpCompatible();

    public bool IsMotherboardPciEAmountEnough();
    public bool IsMotherboardSataAmountEnough();
    public bool IsMotherboardRamSocketsAmountEnough();

    public bool IsGpuSizeAndPcCaseCompatible();
    public bool IsCpuCoolingSystemSizeAndPcCaseCompatible();
    public bool IsMotherboardFormFactorAndPcCaseCompatible();

    public bool IsPsuPowerEnough();
    public bool IsRecommendedPsuPower();
}