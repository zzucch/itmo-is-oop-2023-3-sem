namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public interface IWiFiAdapterBuilder
{
    IWiFiAdapterBuilder WithWiFiVersion(int version);
    IWiFiAdapterBuilder WithBluetooth(bool bt);
    IWiFiAdapterBuilder WithPciEVersion(int version);
    IWiFiAdapterBuilder WithPowerConsumption(int watts);
    IWiFiAdapter Build();
}