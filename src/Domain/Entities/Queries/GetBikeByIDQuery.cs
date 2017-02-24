using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Queries
{
    public class GetBikeByIDQuery : IQuery<IdCriterion, Bike>
    {
        private readonly IBikeService _bikeService;

        public GetBikeByIDQuery(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public Bike Ask(IdCriterion criterion)
        {
            return _bikeService.GetBikeByID(criterion.ID);
        }
    }
}
