using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IIDGenerator
    {
        int Generate<TEntity>()
            where TEntity : IEntity;
    }
}
