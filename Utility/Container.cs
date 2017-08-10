using Autofac;
using Autofac.Integration.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public sealed class ContainerFactory
    {
        private static readonly IContainer _ioccontainer;

        private ContainerFactory()
        {
        }
        static ContainerFactory()
        {
            //var dataAccess = Assembly.GetExecutingAssembly();
            var builder = new ContainerBuilder();
            var daoAssembly = Assembly.LoadFile("DTO");
            var bizAssembly = Assembly.LoadFile("Biz");
            var serviceAssemby = Assembly.LoadFile("MyServiceTest");
            builder.RegisterAssemblyTypes(daoAssembly).Where(t => t.Name.EndsWith("Dao")).AsImplementedInterfaces().AsSelf().SingleInstance();
            builder.RegisterAssemblyTypes(bizAssembly).Where(t => t.Name.EndsWith("Biz")).AsImplementedInterfaces().AsSelf().SingleInstance();
            builder.RegisterAssemblyTypes(serviceAssemby).Where(t => t.Name.EndsWith("Biz")).AsImplementedInterfaces().AsSelf().SingleInstance();
            AutofacHostFactory.Container = _ioccontainer = builder.Build();
        }
        public static IContainer GetContainer()
        {
            return _ioccontainer;
        }

    }
}
