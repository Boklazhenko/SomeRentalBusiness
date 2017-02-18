using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class RemoveReservationCommandContext :ICommandContext
    {
        public Bike Bike { get; set; }
        public Client Client { get; set; }
    }
}
