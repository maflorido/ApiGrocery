using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Grocery.Data;
using Grocery.Repository;
using System.Web.Http;

namespace Grocery.Web
{
    public class DependencyResolverConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();
            var assembly = typeof(PedidoRepository).Assembly;

            builder.RegisterApiControllers(typeof(DependencyResolverConfig).Assembly);            
            builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterType<UnitOfWork>().AsSelf().InstancePerApiRequest();
            builder.RegisterType<GroceryContext>().AsSelf().InstancePerApiRequest();

            var container = builder.Build();
            
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}