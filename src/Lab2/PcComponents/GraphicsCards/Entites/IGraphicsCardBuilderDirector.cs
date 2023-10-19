namespace Itmo.ObjectOrientedProgramming.Lab2.PcComponents.GraphicsCards.Entites;

public interface IGraphicsCardBuilderDirector
{
    IGraphicsCardBuilder Direct(IGraphicsCardBuilder builder);
}