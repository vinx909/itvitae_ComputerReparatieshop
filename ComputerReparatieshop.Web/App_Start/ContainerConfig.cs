using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Infrastructure.InMemory.Services;
using ComputerReparatieshop.Infrastructure.Sql.Services;

namespace ComputerReparatieshop.Web
{
    public class ContainerConfig
    {
        private enum InfrastructureOrigin
        {
            InMemory,
            Sql
        }
        private const InfrastructureOrigin infrastructureOrigin = InfrastructureOrigin.InMemory;

        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            switch (infrastructureOrigin)
            {
                case InfrastructureOrigin.Sql:
                    builder.RegisterType<ComputerReparatieshopDbContext>().InstancePerRequest();
                    builder.RegisterType<SqlCustomerData>().As<ICustomerData>().InstancePerRequest();
                    builder.RegisterType<SqlEmployeeData>().As<IEmployeeData>().InstancePerRequest();
                    builder.RegisterType<SqlImageData>().As<IImageData>().InstancePerRequest();
                    builder.RegisterType<SqlOrderData>().As<IOrderData>().InstancePerRequest();
                    builder.RegisterType<SqlPartData>().As<IPartData>().InstancePerRequest();
                    builder.RegisterType<SqlOrderPartData>().As<IOrderPartData>().InstancePerRequest();
                    builder.RegisterType<SqlStatusData>().As<IStatusData>().InstancePerRequest();
                    break;
                case InfrastructureOrigin.InMemory:
                    builder.RegisterType<InMemoryCustomerData>().As<ICustomerData>().SingleInstance();
                    builder.RegisterType<InMemoryEmployeeData>().As<IEmployeeData>().SingleInstance();
                    builder.RegisterType<InMemoryImageData>().As<IImageData>().SingleInstance();
                    builder.RegisterType<InMemoryOrderData>().As<IOrderData>().SingleInstance();
                    builder.RegisterType<InMemoryPartData>().As<IPartData>().SingleInstance();
                    builder.RegisterType<InMemoryOrderPartData>().As<IOrderPartData>().SingleInstance();
                    builder.RegisterType<InMemoryStatusData>().As<IStatusData>().SingleInstance();
                    break;
            }

            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}