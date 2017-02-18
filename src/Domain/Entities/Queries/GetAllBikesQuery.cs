using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetAllBikesQuery : IQuery<AllEntitiesCriterion, IEnumerable<Bike>>
    {
        private readonly IBikeService _bikeService;

        public GetAllBikesQuery(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public IEnumerable<Bike> Ask(AllEntitiesCriterion criterion)
            => _bikeService.GetAllBikes();
    }
}
