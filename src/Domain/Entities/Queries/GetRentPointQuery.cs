using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetRentPointQuery : IQuery<IdCriterion, RentPoint>
    {
        private readonly IRentPointService _rentPointService;

        public GetRentPointQuery(IRentPointService rentPointService)
        {
            _rentPointService = rentPointService;
        }

        public RentPoint Ask(IdCriterion criterion)
        {
            return _rentPointService.GetRentPoint(criterion.ID);
        }
    }
}
