using Autofac;
using AutofacExstensions;
using Domain.Entities.Commands;
using Domain.Objects;
using IntrospectionExtensions = System.Reflection.IntrospectionExtensions;

namespace WebApplication.Modules
{
    class CommandsRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(AddBikeCommand)).Assembly)
                .AsClosedTypesOf(typeof(ICommand<>))
                .AsImplementedInterfaces();

            builder.RegisterTypedFactory<ICommandFactory>().SingleInstance();

            builder.RegisterType<CommandBuilder>().As<ICommandBuilder>().SingleInstance();
        }
    }
}