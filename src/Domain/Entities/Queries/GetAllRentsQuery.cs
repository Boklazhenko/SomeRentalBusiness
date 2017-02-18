using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetAllRentsQuery : IQuery<AllEntitiesCriterion, IEnumerable<Rent>>
    {
        private readonly IRentService _rentService;

        public GetAllRentsQuery(IRentService rentService)
        {
            _rentService = rentService;
        }

        public IEnumerable<Rent> Ask(AllEntitiesCriterion criterion)
            => _rentService.GetAllRents();
    }
}
