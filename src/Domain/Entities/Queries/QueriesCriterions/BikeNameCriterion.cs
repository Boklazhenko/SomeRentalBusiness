﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Queries.QueriesCriterions
{
    public class BikeNameCriterion : ICriterion
    {
        public string BikeName { get; set; }
    }
}
