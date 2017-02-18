using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class AddRentPointCommandContext : ICommandContext
    {
        public Employee Employee { get; set; }
        public decimal Money { get; set; }
    }
}
