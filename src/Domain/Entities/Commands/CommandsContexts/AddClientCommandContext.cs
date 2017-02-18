using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;

namespace Domain.Entities.Commands.CommandsContexts
{
    public class AddClientCommandContext : ICommandContext
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
    }
}
