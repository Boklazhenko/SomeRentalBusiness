using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class EndRentCommand : ICommand<EndRentCommandContext>
    {
        private readonly IRentService _rentService;

        public EndRentCommand(IRentService rentService)
        {
            _rentService = rentService;
        }

        public void Execute(EndRentCommandContext commandContex)
        {
            _rentService.Return(commandContex.Bike, commandContex.RentPoint);
        }
    }
}
