using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetBikeQuery : IQuery<BikeNameCriterion, Bike>
    {
        private readonly IBikeService _bikeService;

        public GetBikeQuery(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public Bike Ask(BikeNameCriterion criterion)
            => _bikeService.GetAllBikes().SingleOrDefault(b => b.Name == criterion.BikeName);
    }
}
