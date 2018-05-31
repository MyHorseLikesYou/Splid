﻿using System;
using System.Linq;

namespace MyApp.Core.Contracts
{
    public interface IRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity id);
        void Remove(Guid id);        
    }
}
