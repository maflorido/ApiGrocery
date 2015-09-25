using Autofac;
using Autofac.Integration.Mvc;
using Grocery.Data;
using System.Web.Mvc;

namespace Grocery.Web.App_Start
{
    public class DependencyResolverConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().AsSelf().InstancePerHttpRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}