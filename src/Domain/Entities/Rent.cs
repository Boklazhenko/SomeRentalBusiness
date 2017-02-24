using Domain.Services;

namespace Domain.Entities
{
    using System;
    using Deposits;

    public class Rent : Entity
    {
        protected internal Rent(Client client, Bike bike, Deposit deposit)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (bike == null)
                throw new ArgumentNullException(nameof(bike));

            if (deposit == null)
                throw new ArgumentNullException(nameof(deposit));

            StartedAt = DateTime.UtcNow;
            StartRentPoint = bike.RentPoint;
            Client = client;
            Bike = bike;
            Deposit = deposit;
            HourCost = bike.HourCost;
            bike.Take();
        }

        public readonly RentPoint StartRentPoint;

        public readonly DateTime StartedAt;

        public RentPoint EndRentPoint { get; protected set; }

        public DateTime? EndedAt { get; protected set; }

        public bool IsEnded => EndedAt.HasValue;

        public decimal? Sum { get; protected set; }

        public readonly Client Client;

        public readonly Bike Bike;

        public readonly Deposit Deposit;

        public readonly decimal HourCost;


        protected internal void End(RentPoint rentPoint, decimal rentSum)
        {
            if (rentPoint == null)
                throw new ArgumentNullException(nameof(rentPoint));
            if (IsEnded)
                throw new InvalidOperationException("Rent is already ended");
            if (rentSum < 0)
                throw new InvalidOperationException("The sum can not be less than 0");

            Sum = rentSum;
            EndedAt = DateTime.UtcNow;
            EndRentPoint = rentPoint;
            EndRentPoint.CashRegister.PutMoney(Sum.Value);
            Bike.Return(EndRentPoint);
            if (Deposit is PassportDeposit)
                EndRentPoint.SafetyDepositBox.ReturnPassport((PassportDeposit)Deposit);
            if (Deposit is MoneyDeposit)
                EndRentPoint.CashRegister.TakeMoney(((MoneyDeposit)Deposit).Sum);
        }
    }
}
