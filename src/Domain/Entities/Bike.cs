using Domain.Entities.Deposits;

namespace Domain.Entities
{
    using System;

    public class Bike : IEntity
    {
        protected internal Bike(string name, decimal hourCost)
        {
            Rename(name);
            ChangeHourCost(hourCost);
            Status = BikeStatus.Free;
        }

        public string Name { get; protected set; }

        public decimal HourCost { get; protected set; }

        public BikeStatus Status { get; protected set; }

        public RentPoint RentPoint { get; protected set; }

        protected internal void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Name = name;
        }

        public void ChangeHourCost(decimal hourCost)
        {
            if (hourCost <= 0)
                throw new ArgumentOutOfRangeException(nameof(hourCost), "Hour cost must be more than 0");

            HourCost = hourCost;
        }

        public void MoveTo(RentPoint rentPoint)
        {
            if (Status == BikeStatus.Rental)
                throw new InvalidOperationException("Bike is not free");

            if (rentPoint == null)
                throw new ArgumentNullException(nameof(rentPoint));

            if (rentPoint == RentPoint)
                return;

            RentPoint?.RemoveBike(this);

            rentPoint.AddBike(this);

            RentPoint = rentPoint;
        }

        protected internal void Take()
        {
            if (Status == BikeStatus.Rental)
                throw new InvalidOperationException("Bike is not free");
            if (Status == BikeStatus.Broken)
                throw new InvalidOperationException("This bike broken");

            Status = BikeStatus.Rental;
            RentPoint.RemoveBike(this);
            RentPoint = null;
        }

        protected internal void Return(RentPoint endRentPoint)
        {
            if (Status == BikeStatus.Free || Status == BikeStatus.Reserved)
                throw new InvalidOperationException("Bike is free");

            if (Status != BikeStatus.Broken)
                Status = BikeStatus.Free;
            RentPoint = endRentPoint;
            RentPoint.AddBike(this);
        }

        protected internal void Reserve()
        {
            if (Status != BikeStatus.Free)
                throw new InvalidOperationException("This bike is not to be reserved");
            Status = BikeStatus.Reserved;
        }

        protected internal void UnReserve()
        {
            if(Status != BikeStatus.Reserved)
                throw new InvalidOperationException("This Bike is not reserved");
            Status = BikeStatus.Free;
        }
    }
}
