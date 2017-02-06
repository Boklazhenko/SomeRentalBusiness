using Domain.Objects;

namespace Domain.Entities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Deposits;

    public class RentPoint : IEntity
    {
        protected readonly IList<Bike> _bikes = new List<Bike>();
        public readonly CashRegister CashRegister;
        public readonly SafetyDepositBox SafetyDepositBox;

        protected internal RentPoint(
            Employee employee,
            decimal money)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));
            if (money < 0)
                throw new ArgumentOutOfRangeException(nameof(money));

            Employee = employee;
            CashRegister = new CashRegister(money);
            SafetyDepositBox = new SafetyDepositBox();
        }

        public readonly Employee Employee;
        
        public IEnumerable<Bike> Bikes => _bikes.AsEnumerable();

        public IEnumerable<PassportDeposit> PassportDeposits => SafetyDepositBox.GetAllPassports();

        protected internal void AddBike(Bike bike)
        {
            if (bike == null)
                throw new ArgumentNullException(nameof(bike));

            _bikes.Add(bike);
        }

        protected internal void RemoveBike(Bike bike)
        {
            if (bike == null)
                throw new ArgumentNullException(nameof(bike));

            _bikes.Remove(bike);
        }
    }
}