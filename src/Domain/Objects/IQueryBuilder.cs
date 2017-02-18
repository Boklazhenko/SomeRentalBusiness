using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Objects
{
    public interface IQueryBuilder
    {
        IQueryFor<TResult> For<TResult>();
    }
}
