using System;
using System.Reflection;
using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;

namespace AutofacContainer
{
    class Program
    {
        

        static void Main(string[] args)
        {
            //NormalUse();

            //PassByMethod();
            //PassByProperty();
            Lifetime();
            //LoadFromConfig();
            //LoadFromAssembly();

            Console.ReadLine();


            //    Console.ReadLine();
        }

        private static void LoadFromAssembly()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces();
            var container = builder.Build();
            var service = container.Resolve<Service>();
            service.Write();
            service.Read();
        }

        private static void LoadFromConfig()
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("autofac.json");
            //config.AddXmlFile("autofac.xml");
            var module = new ConfigurationModule(config.Build());
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);
            var container = builder.Build();
            var service = container.Resolve<Service>();
            service.Write();
            service.Read();
        }

        private static void Lifetime()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileWriter>().As<IWriter>();
            builder.RegisterType<DBReader>().As<IReader>();
            //builder.RegisterType<Service4>();
            builder.RegisterType<Service4>().SingleInstance();

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                for (int i = 0; i < 10; i++)
                {
                    var service4 = scope.Resolve<Service4>();
                    service4.Read();
                }
            }
        }

        private static void PassByProperty()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileWriter>().As<IWriter>();
            builder.RegisterType<DBReader>().As<IReader>();
            //service.Read();
            builder.RegisterType<Service3>().AsSelf().PropertiesAutowired();
            var container = builder.Build();
            var service3 = container.Resolve<Service3>();
            service3.Read();
            service3.Write();
        }

        private static void PassByMethod()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileWriter>().As<IWriter>();
            builder.RegisterType<DBReader>().As<IReader>();
            builder.Register(c =>
            {
                var result = new Service2();
                var writer = c.Resolve<IWriter>();
                result.Write(writer);
                var reader = c.Resolve<IReader>();
                result.Read(reader);
                return result;
            });
            var container = builder.Build();
            var service = container.Resolve<Service2>();
            service.TryRead();
            service.TryWrite();

            var service2 = container.Resolve<Service2>();
            service2.TryRead();
            service2.TryWrite();
        }
        //autofac registration
        private static void NormalUse()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileWriter>().As<IWriter>();
            builder.RegisterType<DBReader>().As<IReader>();
            builder.RegisterType<Service>();
            var container = builder.Build();
            var service = container.Resolve<Service>();
            service.Read();
            service.Write();
        }
    }
}
