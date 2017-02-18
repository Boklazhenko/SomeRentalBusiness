using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class RemoveReservationCommand : ICommand<RemoveReservationCommandContext>
    {
        private readonly IReservationService _reservationService;

        public RemoveReservationCommand(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public void Execute(RemoveReservationCommandContext commandContex)
        {
            _reservationService.RemoveReservation(commandContex.Bike, commandContex.Client);
        }
    }
}
