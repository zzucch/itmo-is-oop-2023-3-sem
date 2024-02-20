namespace Itmo.ObjectOrientedProgramming.Lab4.Execution.Results;

public abstract record TreeElement
{
    private TreeElement()
    {
    }

    public sealed record File(string Name, int Depth) : TreeElement;

    public sealed record Directory(string Name, int Depth) : TreeElement;
}