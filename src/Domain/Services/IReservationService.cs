using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Services
{
    public interface IReservationService
    {
        void ReserveBike(Bike bike, Client client, int hoursCount);
        void RemoveReservation(Bike bike, Client client);
        bool IsReservedForClient(Bike bike, Client client);
    }
}
