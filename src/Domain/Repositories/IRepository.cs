﻿namespace Domain.Repositories
{
    using System.Collections.Generic;
    using Entities;

    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        void Add(TEntity entity);

        IEnumerable<TEntity> All();

        TEntity Get(int ID);
    }
}
