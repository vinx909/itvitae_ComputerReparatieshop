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

            /*
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ComputerReparatieshopDbContext>().InstancePerRequest();
            builder.RegisterType<SqlCustomerData>().As<ICustomerData>().InstancePerHttpRequest();
            builder.RegisterType<SqlEmployeeData>().As<IEmployeeData>().InstancePerHttpRequest();
            builder.RegisterType<SqlImageData>().As<IImageData>().InstancePerHttpRequest();
            builder.RegisterType<SqlOrderData>().As<IOrderData>().InstancePerHttpRequest();
            builder.RegisterType<SqlPartData>().As<IPartData>().InstancePerHttpRequest();
            builder.RegisterType<SqlPartsListData>().As<IPartsListData>().InstancePerHttpRequest();
            builder.RegisterType<SqlStatusData>().As<IStatusData>().InstancePerHttpRequest();
            */

            ///*
            builder.RegisterType<InMemoryCustomerData>().As<ICustomerData>().SingleInstance();
            builder.RegisterType<InMemoryEmployeeData>().As<IEmployeeData>().SingleInstance();
            builder.RegisterType<InMemoryImageData>().As<IImageData>().SingleInstance();
            builder.RegisterType<InMemoryOrderData>().As<IOrderData>().SingleInstance();
            builder.RegisterType<InMemoryPartData>().As<IPartData>().SingleInstance();
            builder.RegisterType<InMemoryPartsListData>().As<IPartsListData>().SingleInstance();
            builder.RegisterType<InMemoryStatusData>().As<IStatusData>().SingleInstance();
             //*/

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}