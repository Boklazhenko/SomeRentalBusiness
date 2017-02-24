using System.Linq;
using Domain.Services;

namespace Domain.Repositories
{
    using System;
    using System.Collections.Generic;
    using Entities;

    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly Dictionary<int, TEntity> _dictionary = new Dictionary<int, TEntity>();
        private readonly IIDGenerator _idGenerator;

        public Repository(IIDGenerator idGenerator)
        {
            _idGenerator = idGenerator;
        }

        public void Add(TEntity entity)
        {
            entity.ID = _idGenerator.Generate<TEntity>();
            _dictionary[entity.ID] = entity;
        }

        public IEnumerable<TEntity> All()
        {
            return _dictionary.Select(p => p.Value);
        }

        public TEntity Get(int ID)
        {
            return _dictionary[ID];
        }
    }
}
