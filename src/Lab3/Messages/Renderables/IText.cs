namespace Itmo.ObjectOrientedProgramming.Lab3.Messages.Renderables;

public interface IText<out T> : IRenderable
    where T : IText<T>
{
    T Clone();
}