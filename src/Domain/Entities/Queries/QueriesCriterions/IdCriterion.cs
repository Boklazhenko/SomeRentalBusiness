﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Queries.QueriesCriterions
{
    public class IdCriterion : ICriterion
    {
        public int ID { get; set; }
    }
}
