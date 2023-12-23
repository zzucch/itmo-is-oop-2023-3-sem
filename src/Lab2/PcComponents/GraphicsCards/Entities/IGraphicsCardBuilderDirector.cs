namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entities;

public interface IGraphicsCardBuilderDirector
{
    IGraphicsCardBuilder Direct(IGraphicsCardBuilder builder);
}