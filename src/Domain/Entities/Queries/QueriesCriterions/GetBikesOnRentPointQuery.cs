using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries.QueriesCriterions
{
    public class GetBikesOnRentPointQuery : IQuery<RentPointCriterion, IEnumerable<Bike>>
    {
        private readonly IBikeService _bikeService;

        public GetBikesOnRentPointQuery(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public IEnumerable<Bike> Ask(RentPointCriterion criterion)
            => _bikeService.GetAllBikes().Where(b => b.RentPoint == criterion.RentPoint);
    }
}
