using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class AddClientCommand : ICommand<AddClientCommandContext>
    {
        private readonly IClientService _clientService;

        public AddClientCommand(IClientService clientService)
        {
            _clientService = clientService;
        }

        public void Execute(AddClientCommandContext commandContex)
        {
            _clientService.AddClient(commandContex.Surname, commandContex.Name, commandContex.Patronymic);
        }
    }
}
