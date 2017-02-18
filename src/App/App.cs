using Domain.Entities.Commands;
using Domain.Entities.Commands.CommandsContexts;
using Domain.Entities.Deposits;
using Domain.Entities.Queries.QueriesCriterions;
using Domain.Objects;

namespace App
{
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.Repositories;
    using Domain.Services;

    public class App
    {
        private readonly ICommandBuilder _commandBuilder;
        private readonly IQueryBuilder _queryBuilder;

        public App(
            ICommandBuilder commandBuilder,
            IQueryBuilder queryBuilder)
        {
            _commandBuilder = commandBuilder;
            _queryBuilder = queryBuilder;
        }

        public void AddBike(string name, decimal hourCost)
            => _commandBuilder.Execute(new AddBikeCommandContext
            {
                BikeName = name,
                HourCost = hourCost
            });

        public Bike GetBike(string name)
            => _queryBuilder.For<Bike>().With(new BikeNameCriterion
            {
                BikeName = name
            });

        public IEnumerable<Bike> GetBikes()
            => _queryBuilder.For<IEnumerable<Bike>>().With(new AllEntitiesCriterion());

        public IEnumerable<Bike> GetBikesOnRentPoint(RentPoint rentPoint)
            => _queryBuilder.For<IEnumerable<Bike>>().With(new RentPointCriterion
            {
                RentPoint = rentPoint
            });

        public Rent GetOpenRent(Bike bike)
            => _queryBuilder.For<Rent>().With(new BikeCriterion
            {
                Bike = bike
            });

        public void AddEmployee(string surname, string firstName, string patronymic)
            => _commandBuilder.Execute(new AddEmployeeCommandContext
            {
                Surname = surname,
                Name = firstName,
                Patronymic = patronymic
            });

        public IEnumerable<Employee> GetEmployees()
            => _queryBuilder.For<IEnumerable<Employee>>().With(new AllEntitiesCriterion());

        public void AddRentPoint(Employee employee, decimal money)
            => _commandBuilder.Execute(new AddRentPointCommandContext
            {
                Employee = employee,
                Money = money
            });

        public IEnumerable<RentPoint> GetRentPoints()
            => _queryBuilder.For<IEnumerable<RentPoint>>().With(new AllEntitiesCriterion());

        public void PlaceBikeIntoRentPoint(Bike bike, RentPoint rentPoint)
            => bike.MoveTo(rentPoint);

        public void AddClient(string surname, string firstName, string patronymic)
            => _commandBuilder.Execute(new AddClientCommandContext
            {
                Surname = surname,
                Name = firstName,
                Patronymic = patronymic
            });

        public IEnumerable<Client> GetClients()
            => _queryBuilder.For<IEnumerable<Client>>().With(new AllEntitiesCriterion());

        public void StartRent(Client client, Bike bike, Deposit deposit)
            => _commandBuilder.Execute(new StartRentCommandContext
            {
                Client = client,
                Bike = bike,
                Deposit = deposit
            });

        public void EndRent(Bike bike, RentPoint rentPoint)
            => _commandBuilder.Execute(new EndRentCommandContext
            {
                Bike = bike,
                RentPoint = rentPoint
            });

        public void RenameBike(Bike bike, string newName)
            => _commandBuilder.Execute(new RenameBikeCommandContext
            {
                Bike = bike,
                NewName = newName
            });

        public void TakeMoney(RentPoint rentPoint, decimal money)
            => rentPoint.CashRegister.TakeMoney(money);

        public void PutMoney(RentPoint rentPoint, decimal money)
            => rentPoint.CashRegister.PutMoney(money);

        public IEnumerable<Rent> GetAllRents()
            => _queryBuilder.For<IEnumerable<Rent>>().With(new AllEntitiesCriterion());

        public void ReserveBike(Bike bike, Client client, int hoursCount)
            => _commandBuilder.Execute(new ReserveBikeCommandContext
            {
                Bike = bike,
                Client = client,
                HoursCount = hoursCount
            });

        public void RemoveReservation(Bike bike, Client client)
            => _commandBuilder.Execute(new RemoveReservationCommandContext
            {
                Bike = bike,
                Client = client
            });
    }
}
