using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ComputerReparatieshop.Data.Services;

namespace ComputerReparatieshop.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryCustomerData>().As<ICustomerData>().SingleInstance();
            builder.RegisterType<InMemoryEmployeeData>().As<IEmployeeData>().SingleInstance();
            builder.RegisterType<InMemoryImageListData>().As<IImageListData>().SingleInstance();
            builder.RegisterType<InMemoryOrderData>().As<IOrderData>().SingleInstance();
            builder.RegisterType<InMemoryPartData>().As<IPartData>().SingleInstance();
            builder.RegisterType<InMemoryPartsListData>().As<IPartsListData>().SingleInstance();
            builder.RegisterType<InMemoryStatusData>().As<IStatusData>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}