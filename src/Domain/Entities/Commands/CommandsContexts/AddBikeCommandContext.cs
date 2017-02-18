using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class AddBikeCommandContext : ICommandContext
    {
        public string BikeName { get; set; }
        public decimal HourCost { get; set; }
    }
}
