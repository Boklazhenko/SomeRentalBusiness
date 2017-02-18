using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetOpenRentOnBikeQuery : IQuery<BikeCriterion, Rent>
    {
        private readonly IRentService _rentService;

        public GetOpenRentOnBikeQuery(IRentService rentService)
        {
            _rentService = rentService;
        }

        public Rent Ask(BikeCriterion criterion)
            => _rentService.GetAllRents().FirstOrDefault(r => r.Bike == criterion.Bike && r.EndedAt == null);
    }
}
