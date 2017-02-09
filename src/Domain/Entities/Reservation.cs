using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Services;

namespace Domain.Entities
{
    public class Reservation : IEntity
    {
        public readonly Bike Bike;
        public readonly Client Client;
        public readonly int HoursCount;
        public readonly DateTime CreatedDate;
        public DateTime EndDate => CreatedDate.AddHours(HoursCount);

        public Reservation(Bike bike, Client client, int hoursCount)
        {
            Bike = bike;
            Client = client;
            HoursCount = hoursCount;
            CreatedDate = DateTime.UtcNow;
        }
    }
}
