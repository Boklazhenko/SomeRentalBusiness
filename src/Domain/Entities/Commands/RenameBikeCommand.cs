using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class RenameBikeCommand : ICommand<RenameBikeCommandContext>
    {
        private readonly IBikeService _bikeService;

        public RenameBikeCommand(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        public void Execute(RenameBikeCommandContext commandContex)
        {
            _bikeService.Rename(commandContex.Bike, commandContex.NewName);
        }
    }
}
