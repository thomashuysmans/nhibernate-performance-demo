using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePerformanceDemo.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            App_Start.NHibernateProfilerBootstrapper.PreStart();

            Console.WriteLine("Welcome to the tester. Press enter if you want to run another test. Type exit if you want to stop. Happy testing :-).");

            var sessionFactory = CreateSessionFactory();
            var insertSimulator = new InsertSimulator(sessionFactory);

            var inputCommand = string.Empty;

            Console.WriteLine("Warming up test.");

            do
            {
                //Warming up
                insertSimulator.Simulate();
                inputCommand = Console.ReadLine();
            } while (inputCommand != "exit");
        }

        private static ISessionFactory CreateSessionFactory()
        {

            var dbSetup = MsSqlConfiguration.MsSql2012.ConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["NHibernatePerfConnectionString"].ConnectionString).AdoNetBatchSize(80);

            return Fluently.Configure()
              .Database(dbSetup)
              .Mappings(m =>
                m.FluentMappings.AddFromAssemblyOf<Program>()).BuildSessionFactory()
              ;
        }
    }
}
