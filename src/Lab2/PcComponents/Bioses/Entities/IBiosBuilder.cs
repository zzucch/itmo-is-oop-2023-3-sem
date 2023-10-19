using Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Cpus.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Bioses.Entities;

public interface IBiosBuilder
{
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(string version);
    IBiosBuilder AddSupportedCpu(ICpu cpu);
    IBios Build();
}