using Domain.Entities.Deposits;

namespace App
{
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.Repositories;
    using Domain.Services;

    public class App
    {
        private readonly IBikeService _bikeService;
        private readonly IEmployeeService _empService;
        private readonly IRentPointService _rentPointService;
        private readonly IClientService _clientService;
        private readonly IRentService _rentService;

        public App(
            IBikeService bikeService,
            IEmployeeService empService,
            IRentPointService rentPointService,
            IClientService clientService,
            IRentService rentService)
        {
            _bikeService = bikeService;
            _empService = empService;
            _rentPointService = rentPointService;
            _clientService = clientService;
            _rentService = rentService;
        }

        public void AddBike(string name, decimal hourCost) => _bikeService.AddBike(name, hourCost);

        public IEnumerable<Bike> GetBikes() => _bikeService.GetAllBikes();

        public void AddEmployee(string surname, string firstName, string patronymic)
            => _empService.AddEmployee(surname, firstName, patronymic);

        public IEnumerable<Employee> GetEmployees() => _empService.GetAllEmployees();

        public void AddRentPoint(Employee employee, decimal money)
            => _rentPointService.AddRentPoint(employee, money);

        public IEnumerable<RentPoint> GetRentPoints()
            => _rentPointService.GetAllRentPoints();

        public void PlaceBikeIntoRentPoint(Bike bike, RentPoint rentPoint)
            => bike.MoveTo(rentPoint);

        public void AddClient(string surname, string firstName, string patronymic)
            => _clientService.AddClient(surname, firstName, patronymic);

        public void StartRent(Client client, Bike bike, Deposit deposit)
            => _rentService.Take(client, bike, deposit);

        public void EndRent(Bike bike, RentPoint rentPoint)
            => _rentService.Return(bike, rentPoint);
    }
}
