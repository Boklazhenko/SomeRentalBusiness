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

        public App(
            IBikeService bikeService, IEmployeeService empService)
        {
            _bikeService = bikeService;
            _empService = empService;
        }

        public void AddBike(string name, decimal hourCost) => _bikeService.AddBike(name, hourCost);

        public IEnumerable<Bike> GetBikes() => _bikeService.GetAllBikes();

        public void AddEmployee(string surname, string firstName, string patronymic)
            => _empService.AddEmployee(surname, firstName, patronymic);

        public IEnumerable<Employee> GetEmployees() => _empService.GetAllEmployees();
    }
}
