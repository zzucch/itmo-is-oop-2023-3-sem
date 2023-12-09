namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.Xmps.Entities;

public interface IXmpBuilderDirector
{
    IXmpBuilder Direct(IXmpBuilder builder);
}