using System;
using System.Linq;
namespace CarFuel.Services.Core
{
    public interface IService<T> where T : class
    {
        IQueryable<T> Query(Func<T, bool> condition);
        IQueryable<T> All { get; }
        T Find(params object[] keys);

        T Add(T item);
        T Update(T item);
        T Delete(T item);
    }
}
