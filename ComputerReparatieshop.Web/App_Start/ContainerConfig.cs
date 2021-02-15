using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ComputerReparatieshop.Domain.Services;
using ComputerReparatieshop.Infrastructure.Services;

namespace ComputerReparatieshop.Web
{
    public class ContainerConfig
    {
        enum InfrastructureOrigin
        {
            InMemory,
            Sql
        }
        const InfrastructureOrigin infrastructureOrigin = InfrastructureOrigin.Sql;

        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            switch (infrastructureOrigin)
            {
                case InfrastructureOrigin.Sql:
                    builder.RegisterType<ComputerReparatieshopDbContext>().InstancePerRequest();
                    builder.RegisterType<SqlCustomerData>().As<ICustomerData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<SqlEmployeeData>().As<IEmployeeData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<SqlImageData>().As<IImageData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<SqlOrderData>().As<IOrderData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<SqlPartData>().As<IPartData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<SqlPartsListData>().As<IPartsListData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<SqlStatusData>().As<IStatusData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    break;
                case InfrastructureOrigin.InMemory:
                    builder.RegisterType<InMemoryCustomerData>().As<ICustomerData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<InMemoryEmployeeData>().As<IEmployeeData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<InMemoryImageData>().As<IImageData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<InMemoryOrderData>().As<IOrderData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<InMemoryPartData>().As<IPartData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<InMemoryPartsListData>().As<IPartsListData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    builder.RegisterType<InMemoryStatusData>().As<IStatusData>().InstancePerRequest();/*.InstancePerHttpRequest()*/
                    break;
            }

            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}