﻿using .CarFuel.Services;
using System;
using System.Linq;
using CarFuel.Services.Core;
using CarFuel.Services.Data;

namespace CarFuel.Services.Core
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        public ServiceBase(AppDB db) => Db = db;
        public AppDB Db { get; }

        public IQueryable<T> All => throw new NotImplementedException();
        public T Find(params object[] keys) => Db.Set<T>().Find(keys);
        public IQueryable<T> Query(Func<T, bool> condition)
          => Db.Set<T>().Where(condition).AsQueryable();

        public T Add(T item) => Db.Set<T>().Add(item).Entity;
        public T Delete(T item) => Db.Set<T>().Remove(item).Entity;
        public T Update(T item) => Db.Set<T>().Update(item).Entity;

    }
}
