using Autofac;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeymenCodeCase.IoC
{
    public class AutofacIoC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("BeymenCodeCase.Services"))
                 .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Factory"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            builder
            .Register(cx => ConnectionMultiplexer.Connect("localhost"))
            .As<IConnectionMultiplexer>()
            .SingleInstance();
        }
    }
}
