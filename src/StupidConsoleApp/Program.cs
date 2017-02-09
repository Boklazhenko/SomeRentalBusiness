using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Autofac.Builder;
using Domain.Entities.Deposits;
using Domain.Factories;

namespace StupidConsoleApp
{
    using App;
    using Domain.Entities;
    using Domain.Repositories;
    using Domain.Services;
    using Autofac;

    public class Program
    {
        public static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new MyFirstModule());
            IContainer container = builder.Build();

            App app = container.Resolve<App>();

            app.AddBike("Кама", 50);
            app.AddBike("Урал", 100);
            app.AddBike("Олимпик", 25);

            app.AddEmployee("Yaev", "Ya", "Yaevich");

            Employee ya = app.GetEmployees().FirstOrDefault();
            app.AddRentPoint(ya, 1000);
            RentPoint rentPoint = app.GetRentPoints().FirstOrDefault();

            Bike kama = app.GetBikes().FirstOrDefault(b => b.Name == "Кама");
            app.PlaceBikeIntoRentPoint(kama, rentPoint);

            app.AddClient("Tiev", "Ti", "Tievich");
            app.AddClient("1", "2", "3");
            Client client = app.GetClients().FirstOrDefault(c => c.FirstName == "Ti");
            Client client2 = app.GetClients().FirstOrDefault(c => c.FullName == "1 2 3");
            Console.WriteLine(rentPoint.CashRegister.Money);
            app.ReserveBike(kama, client, 3);
            app.RemoveReservation(kama, client);
            app.StartRent(client2, kama, new MoneyDeposit(6000));
            Console.WriteLine(rentPoint.CashRegister.Money);

            app.EndRent(kama, rentPoint);
            Console.WriteLine(rentPoint.CashRegister.Money);

            IEnumerable<Rent> rents = app.GetAllRents();
            foreach (var rent in rents)
            {
                Console.WriteLine(rent.StartRentPoint.Employee.FullName);
            }
            Console.ReadKey();
        }

        class MyFirstModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);
                builder.RegisterType<EmployeeService>().As<IEmployeeService>();
                builder.RegisterType<RentService>().As<IRentService>();
                builder.RegisterType<ClientService>().As<IClientService>();
                builder.RegisterType<RentPointService>().As<IRentPointService>();
                builder.RegisterType<BikeService>().As<IBikeService>();
                builder.RegisterType<ReservationService>().As<IReservationService>().SingleInstance();

                builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).SingleInstance();

                builder.RegisterType<BikeNameVerifier>().As<IBikeNameVerifier>();
                builder.RegisterType<EmployeeVerifier>().As<IEmployeeVerifier>();
                builder.RegisterType<DepositCalculator>().As<IDepositCalculator>();

                builder.RegisterType<RentSumCalculatorFactory>().As<IRentSumCalculatorFactory>();

                builder.RegisterType<App>().AsSelf();
            }
        }
    }
}
