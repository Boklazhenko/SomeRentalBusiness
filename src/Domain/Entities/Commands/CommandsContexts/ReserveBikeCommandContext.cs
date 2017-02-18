using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class ReserveBikeCommandContext :ICommandContext
    {
        public Bike Bike { get; set; }
        public Client Client { get; set; }
        public int HoursCount { get; set; }
    }
}
