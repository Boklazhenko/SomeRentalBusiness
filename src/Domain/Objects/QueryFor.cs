using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Objects
{
    public class QueryFor<TResult> : IQueryFor<TResult>
    {
        private readonly IQueryFactory _queryFactory;

        public QueryFor(IQueryFactory queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public TResult With<TCriterion>(TCriterion criterion) 
            where TCriterion : ICriterion
        {
            return _queryFactory.Create<TCriterion, TResult>().Ask(criterion);
        }
    }
}
