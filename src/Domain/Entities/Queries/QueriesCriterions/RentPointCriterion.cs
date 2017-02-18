using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Queries.QueriesCriterions
{
    public class RentPointCriterion :ICriterion
    {
        public RentPoint RentPoint { get; set; }
    }
}
