using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Domain.Entities;
using Domain.Entities.Deposits;
using Domain.Repositories;

namespace Domain.Services
{
    public class ReservationService : IReservationService
    {
        private List<Reservation> _list;

        public ReservationService(IRepository<Reservation> repository)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));
            _list = repository.All().ToList();
           // StartMonitoringReservations();
        }

        public void ReserveBike(Bike bike, Client client, int hoursCount)
        {
            if (bike == null)
                throw new ArgumentNullException(nameof(bike));
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (hoursCount < 1)
                throw new InvalidOperationException("Do not reserve the bike less than an hour");
            if (!bike.IsFree)
                throw new InvalidOperationException("This bike is not free");
            bike.Reserve();
            _list.Add(new Reservation(bike, client, hoursCount));
        }

        public void RemoveReservation(Bike bike, Client client)
        {
            if (bike == null)
                throw new ArgumentNullException(nameof(bike));
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            Reservation reservation = _list.FirstOrDefault(r => r.Bike.Name == bike.Name);
            if (reservation == null)
                throw new ArgumentNullException("This bike not reserved");
            if (reservation.Client.FullName != client.FullName)
                throw new InvalidOperationException("This client did not reserve this bike");
            bike.UnReserve();
            _list.Remove(reservation);
        }

        public bool IsReservedForClient(Bike bike, Client client)
            => _list.Any(r => r.Bike.Name == bike.Name && r.Client.FullName == client.FullName);

        private void StartMonitoringReservations()
        {
            new Timer(CheckReservations, null, 0, 180000);
        }

        private void CheckReservations(object obj)
        {
            IEnumerable<Bike> removedBikes = _list.Where(r => r.EndDate <= DateTime.Now).Select(r => r.Bike).ToList();
            removedBikes.ToList().ForEach(b => b.UnReserve());
            _list = _list.Where(r => r.EndDate >= DateTime.Now).ToList();
        }
    }
}