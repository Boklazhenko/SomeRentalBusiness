namespace StupidConsoleApp
{
    using App;
    using Domain.Entities;
    using Domain.Repositories;
    using Domain.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            IRepository<Employee> employeeRepository = new Repository<Employee>();
            IRepository<Bike> bikeRepository = new Repository<Bike>();
            IBikeNameVerifier bikeNameVerifier = new BikeNameVerifier(bikeRepository);
            IBikeService bikeService = new BikeService(bikeRepository, bikeNameVerifier);
            IEmployeeVerifier empVerifier = new EmployeeVerifier(employeeRepository);
            IEmployeeService employeeService = new EmployeeService(empVerifier, employeeRepository);

            App app = new App(bikeService, employeeService);

            app.AddBike("Кама", 50);
            app.AddBike("Кама", 100);
        }
    }
}
