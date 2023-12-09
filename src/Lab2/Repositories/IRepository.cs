using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
    where T : class
{
    T? FindByName(string name);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Delete(T entity);
}