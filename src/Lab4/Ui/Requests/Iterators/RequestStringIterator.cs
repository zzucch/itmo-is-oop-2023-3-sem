using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Ui.Requests.Iterators;

public class RequestStringIterator : IIterator<string>
{
    private readonly IReadOnlyList<string> _data;
    private int _current;

    public RequestStringIterator(IEnumerable<string> data)
    {
        _data = data.ToArray();
        _current = 0;
    }

    public bool TryMove()
    {
        if (_current + 1 >= _data.Count)
        {
            return false;
        }

        _current += 1;
        return true;
    }

    public string GetCurrent()
    {
        return _data.ElementAt(_current);
    }
}