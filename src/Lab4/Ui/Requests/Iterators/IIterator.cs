namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests.Iterators;

public interface IIterator<out T>
{
    bool TryMove();

    T GetCurrent();
}