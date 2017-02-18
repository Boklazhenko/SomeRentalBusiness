using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Objects;
using Domain.Services;

namespace Domain.Entities.Commands
{
    public class ReserveBikeCommand : ICommand<ReserveBikeCommandContext>
    {
        private readonly IReservationService _reservationService;

        public ReserveBikeCommand(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public void Execute(ReserveBikeCommandContext commandContex)
        {
            _reservationService.ReserveBike(commandContex.Bike, commandContex.Client, commandContex.HoursCount);
        }
    }
}
