using System;
using Autofac;

namespace AutofacExstensions
{
    public abstract class TypedFactoryBase
    {
        protected readonly IComponentContext ComponentContext;



        protected TypedFactoryBase(IComponentContext componentContext)
        {
            ComponentContext = componentContext;
        }



        protected object Resolve(Type type)
        {
            return ComponentContext.Resolve(type);
        }
    }
}
