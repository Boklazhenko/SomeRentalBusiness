using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetFreeBikesQuery :IQuery<FreeBikesCriterion, IEnumerable<Bike>>
    {
        private readonly IBikeService _bikeService;

        public GetFreeBikesQuery(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public IEnumerable<Bike> Ask(FreeBikesCriterion criterion)
        {
            return _bikeService.GetAllBikes().Where(b => b.IsFree);
        }
    }
}
