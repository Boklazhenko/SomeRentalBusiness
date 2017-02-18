using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetAllRentPointsQuery : IQuery<AllEntitiesCriterion, IEnumerable<RentPoint>>
    {
        private readonly IRentPointService _rentPointService;

        public GetAllRentPointsQuery(IRentPointService rentPointService)
        {
            _rentPointService = rentPointService;
        }

        public IEnumerable<RentPoint> Ask(AllEntitiesCriterion criterion)
            => _rentPointService.GetAllRentPoints();
    }
}
