using Autofac;
using Domain.Repositories;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace WebApplication.Modules
{
    class ServicesRegistrationModule : Module
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
        }
    }
}
