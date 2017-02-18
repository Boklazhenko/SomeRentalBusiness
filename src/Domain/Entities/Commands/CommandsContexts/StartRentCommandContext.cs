using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;
using Domain.Entities.Deposits;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class StartRentCommandContext : ICommandContext
    {
        public Client Client { get; set; }
        public Bike Bike { get; set; }
        public Deposit Deposit { get; set; }
    }
}
