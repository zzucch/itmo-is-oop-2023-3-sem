using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.PcComponents;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class PcComponentRepository : IRepository<IPcComponent>
{
    private readonly Collection<IPcComponent> _components = new();

    public IPcComponent? FindByName(string name)
    {
        return _components.FirstOrDefault(component => component.Name.Name == name);
    }

    public IEnumerable<IPcComponent> GetAll()
    {
        return _components;
    }

    public void Add(IPcComponent entity)
    {
        _components.Add(entity);
    }

    public void Delete(IPcComponent entity)
    {
        _components.Remove(entity);
    }
}