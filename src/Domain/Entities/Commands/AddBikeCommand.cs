using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Objects;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class AddBikeCommand : ICommand<AddBikeCommandContext>
    {
        private readonly IBikeService _bikeService;

        public AddBikeCommand(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public void Execute(AddBikeCommandContext commandContex)
        {
            _bikeService.AddBike(commandContex.BikeName, commandContex.HourCost);
        }
    }
}
