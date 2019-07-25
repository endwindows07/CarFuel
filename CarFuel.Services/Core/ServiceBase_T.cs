using CarFuel.Services;
using System;
using System.Linq;
using CarFuel.Services.Core;
using CarFuel.Services.Data;

namespace CarFuel.Services.Core
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        public ServiceBase(AppDB db) => Db = db;
        protected readonly AppDB Db;

        public IQueryable<T> All => Query(x => true);
        public virtual T Find(params object[] keys) => Db.Set<T>().Find(keys);
        public virtual IQueryable<T> Query(Func<T, bool> condition) => Db.Set<T>().Where(condition).AsQueryable();

        public virtual T Add(T item) => Db.Set<T>().Add(item).Entity;
        public virtual T Delete(T item) => Db.Set<T>().Remove(item).Entity;
        public virtual T Update(T item) => Db.Set<T>().Update(item).Entity;
    }
}
