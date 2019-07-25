using CarFuel.Services;
using System;
using System.Linq;
using CarFuel.Services.Core;
using CarFuel.Services.Data;

namespace CarFuel.Services.Core
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        public ServiceBase(App app) => this.app = app;
        protected readonly App app;

        public IQueryable<T> All => Query(x => true);
        public virtual T Find(params object[] keys) => app.Db.Set<T>().Find(keys);
        public virtual IQueryable<T> Query(Func<T, bool> condition) => app.Db.Set<T>().Where(condition).AsQueryable();

        public virtual T Add(T item) => app.Db.Set<T>().Add(item).Entity;
        public virtual T Delete(T item) => app.Db.Set<T>().Remove(item).Entity;
        public virtual T Update(T item) => app.Db.Set<T>().Update(item).Entity;
    }
}
