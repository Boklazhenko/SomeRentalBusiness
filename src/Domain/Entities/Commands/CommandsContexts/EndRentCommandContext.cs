using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class EndRentCommandContext : ICommandContext
    {
        public Bike Bike { get; set; }
        public RentPoint RentPoint { get; set; }
    }
}
