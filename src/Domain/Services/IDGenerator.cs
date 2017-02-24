using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Domain.Entities;

namespace Domain.Services
{
    public class IDGenerator : IIDGenerator
    {
        private readonly Dictionary<Type, int> _dictionary = new Dictionary<Type, int>();

        public IDGenerator()
        {
            List<Type> types = typeof(IEntity).GetTypeInfo().Assembly.GetTypes()
                .Where(t => t.GetTypeInfo().IsSubclassOf(typeof(Entity))).ToList();
            types.ForEach(t => _dictionary[t] = 0);
        }

        public int Generate<TEntity>()
            where TEntity : IEntity
            => ++_dictionary[typeof(TEntity)];
    }
}