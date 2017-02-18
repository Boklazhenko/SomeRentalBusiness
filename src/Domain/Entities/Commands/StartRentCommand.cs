using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class StartRentCommand : ICommand<StartRentCommandContext>
    {
        private readonly IRentService _rentService;

        public StartRentCommand(IRentService rentService)
        {
            _rentService = rentService;
        }

        public void Execute(StartRentCommandContext commandContex)
        {
            _rentService.Take(commandContex.Client, commandContex.Bike, commandContex.Deposit);
        }
    }
}
