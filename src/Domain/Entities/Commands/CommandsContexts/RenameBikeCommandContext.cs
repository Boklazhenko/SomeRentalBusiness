using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class RenameBikeCommandContext :ICommandContext
    {
        public Bike Bike { get; set; }
        public string NewName { get; set; }
    }
}
