using Domain.Entities.Deposits;

namespace Domain.Entities
{
    using System;

    public class Bike : Entity
    {
        protected internal Bike(string name, decimal hourCost)
        {
            Rename(name);
            ChangeHourCost(hourCost);
            IsFree = true;
        }

        public string Name { get; protected set; }

        public decimal HourCost { get; protected set; }

        public bool IsFree { get; protected set; }

        public bool IsReserved { get; protected set; }

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
            if (!IsFree)
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
            if (!IsFree)
                throw new InvalidOperationException("Bike is not free");

            IsFree = false;
            RentPoint.RemoveBike(this);
            RentPoint = null;
        }

        protected internal void Return(RentPoint endRentPoint)
        {
            if (IsFree)
                throw new InvalidOperationException("Bike is free");
            if (IsReserved)
                throw new InvalidOperationException("This bike is reserved");

            IsFree = true;
            RentPoint = endRentPoint;
            RentPoint.AddBike(this);
        }

        protected internal void Reserve()
        {
            if (IsReserved)
                throw new InvalidOperationException("This bike is already reserved!");
            if (!IsFree)
                throw new InvalidOperationException("This bike is not free!");
            IsReserved = true;
        }

        protected internal void UnReserve()
        {
            if (!IsReserved)
                throw new InvalidOperationException("This Bike is not already reserved");
            if (!IsFree)
                throw new InvalidOperationException("This bike is in the rental");
            IsReserved = false;
        }
    }
}
