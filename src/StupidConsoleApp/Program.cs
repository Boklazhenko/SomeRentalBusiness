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
            app.AddBike("Кама", 100);
        }

        private void Reg()
        {
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

                builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).SingleInstance();

                builder.RegisterType<BikeNameVerifier>().As<IBikeNameVerifier>();
                builder.RegisterType<EmployeeVerifier>().As<IEmployeeVerifier>();
                builder.RegisterType<DepositCalculator>().As<IDepositCalculator>();

                builder.RegisterType<App>().AsSelf();
            }
        }
    }
}
