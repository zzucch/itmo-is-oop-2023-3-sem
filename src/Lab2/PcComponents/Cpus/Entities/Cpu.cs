using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

public class Cpu : ICpu
{
    private readonly int _coreSpeed;
    private readonly int _coreAmount;

    internal Cpu(
        int coreSpeed,
        int coreAmount,
        string socket,
        bool integratedGraphicsProcessor,
        IEnumerable<int> supportedMemoryFrequencies,
        int tdp,
        int powerConsumption)
    {
        _coreSpeed = coreSpeed;
        _coreAmount = coreAmount;
        Socket = socket;
        IntegratedGraphicsProcessor = integratedGraphicsProcessor;
        SupportedMemoryFrequencies = supportedMemoryFrequencies.ToArray();
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public int Tdp { get; }
    public string Socket { get; }
    public int PowerConsumption { get; }
    public bool IntegratedGraphicsProcessor { get; }
    public IReadOnlyList<int> SupportedMemoryFrequencies { get; }

    public ICpuBuilder Direct(ICpuBuilder builder)
    {
        builder
            .WithCoreSpeed(_coreSpeed)
            .WithCoreAmount(_coreAmount)
            .WithSocket(Socket)
            .WithIntegratedGraphicsProcessor(IntegratedGraphicsProcessor)
            .WithTdp(Tdp)
            .WithPowerConsumption(PowerConsumption);

        foreach (int frequency in SupportedMemoryFrequencies)
        {
            builder.AddSupportedMemoryFrequency(frequency);
        }

        return builder;
    }
}