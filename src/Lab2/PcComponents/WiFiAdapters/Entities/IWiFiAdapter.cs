using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Psus.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.WiFiAdapters.Entities;

public interface IWiFiAdapter : IWiFiAdapterBuilderDirector
{
    public PowerConsumption PowerConsumption { get; }
}