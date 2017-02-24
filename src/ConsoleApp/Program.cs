using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Autofac.Builder;
using Domain.Entities.Deposits;
using AutofacExstensions;
using Domain.Entities.Commands;
using Domain.Entities.Queries;
using Domain.Objects;

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
            builder.RegisterAssemblyModules(typeof(Program).GetTypeInfo().Assembly);
            IContainer container = builder.Build();

            App app = container.Resolve<App>();

            app.AddBike("Кама", 50);
            app.AddBike("Урал", 100);
            app.AddBike("Олимпик", 25);

            app.AddEmployee("Yaev", "Ya", "Yaevich");

            Employee ya = app.GetEmployees().FirstOrDefault();
            app.AddRentPoint(ya, 1000);
            RentPoint rentPoint = app.GetRentPoints().FirstOrDefault();

            Bike kama = app.GetBike("Кама");
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
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
            Rent r = app.GetOpenRent(kama);
            Console.WriteLine($"{r.Deposit.Type} {r.StartedAt}");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++");
            app.EndRent(kama, rentPoint);
            Console.WriteLine(rentPoint.ID);

            IEnumerable<Rent> rents = app.GetAllRents().ToList();
            foreach (var rent in rents)
            {
                Console.WriteLine(rent.StartRentPoint.Employee.FullName);
            }
            Console.WriteLine("-----------------------------------------------");
            IEnumerable<Bike> bikes = app.GetBikesOnRentPoint(rentPoint).ToList();
            foreach (Bike bike in bikes)
            {
                Console.WriteLine(bike.ID);
            }
            container.Dispose();
            Console.ReadKey();
        }

        class MyFirstModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);
                builder.RegisterType<EmployeeService>().As<IEmployeeService>().SingleInstance();
                builder.RegisterType<RentService>().As<IRentService>().SingleInstance();
                builder.RegisterType<ClientService>().As<IClientService>().SingleInstance();
                builder.RegisterType<RentPointService>().As<IRentPointService>().SingleInstance();
                builder.RegisterType<BikeService>().As<IBikeService>().SingleInstance();
                builder.RegisterType<ReservationService>().As<IReservationService>().SingleInstance();

                builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).SingleInstance();

                builder.RegisterType<BikeNameVerifier>().As<IBikeNameVerifier>().SingleInstance();
                builder.RegisterType<EmployeeVerifier>().As<IEmployeeVerifier>().SingleInstance();
                builder.RegisterType<DepositCalculator>().As<IDepositCalculator>().SingleInstance();
                builder.RegisterType<RentSumCalculator>().As<IRentSumCalculator>().SingleInstance();
                builder.RegisterType<IDGenerator>().As<IIDGenerator>().SingleInstance();

                builder.RegisterType<App>().AsSelf();
            }
        }

        class CommandsRegistrationModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);
                builder.RegisterAssemblyTypes(typeof(AddBikeCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(ICommand<>))
                    .AsImplementedInterfaces();

                builder.RegisterTypedFactory<ICommandFactory>().SingleInstance();

                builder.RegisterType<CommandBuilder>().As<ICommandBuilder>().SingleInstance();
            }
        }

        class QueriesRegistrationModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);
                builder.RegisterAssemblyTypes(typeof(GetBikeQuery).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IQuery<,>))
                    .AsImplementedInterfaces();

                builder.RegisterGeneric(typeof(QueryFor<>)).As(typeof(IQueryFor<>));

                builder.RegisterTypedFactory<IQueryFactory>().SingleInstance();
                builder.RegisterTypedFactory<IQueryBuilder>().SingleInstance();
            }
        }
    }
}
