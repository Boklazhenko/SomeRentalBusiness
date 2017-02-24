using Autofac;
using AutofacExstensions;
using Domain.Entities.Queries;
using Domain.Objects;
using IntrospectionExtensions = System.Reflection.IntrospectionExtensions;

namespace WebApplication.Modules
{
    class QueriesRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyTypes(IntrospectionExtensions.GetTypeInfo(typeof(GetBikeQuery)).Assembly)
                .AsClosedTypesOf(typeof(IQuery<,>))
                .AsImplementedInterfaces();

            builder.RegisterGeneric(typeof(QueryFor<>)).As(typeof(IQueryFor<>));

            builder.RegisterTypedFactory<IQueryFactory>().SingleInstance();
            builder.RegisterTypedFactory<IQueryBuilder>().SingleInstance();
        }
    }
}