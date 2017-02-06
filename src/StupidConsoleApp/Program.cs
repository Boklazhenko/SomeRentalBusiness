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
            IRepository<RentPoint> rentPointRepository = new Repository<RentPoint>();
            IRepository<Client> clientRepository = new Repository<Client>();
            IRepository<Rent> rentRepository = new Repository<Rent>();
            IDepositCalculator depositCalculator = new DepositCalculator();
            IBikeNameVerifier bikeNameVerifier = new BikeNameVerifier(bikeRepository);
            IBikeService bikeService = new BikeService(bikeRepository, bikeNameVerifier);
            IEmployeeVerifier empVerifier = new EmployeeVerifier(employeeRepository);
            IEmployeeService employeeService = new EmployeeService(empVerifier, employeeRepository);
            IRentPointService rentPointService = new RentPointService(rentPointRepository);
            IClientService clientService = new ClientService(clientRepository);
            IRentService rentService = new RentService(depositCalculator, rentRepository);

            App app = new App(bikeService, employeeService, rentPointService, clientService, rentService);

            app.AddBike("Кама", 50);
            app.AddBike("Кама", 100);
        }
    }
}
