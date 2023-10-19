namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder WithWiFiVersion(int version);
    IWiFiAdapterBuilder WithBuiltInBluetooth(bool bluetooth);
    IWiFiAdapterBuilder WithPciEVersion(int version);
    IWiFiAdapterBuilder WithPowerConsumption(int watts);
    IWiFiAdapter Build();
}