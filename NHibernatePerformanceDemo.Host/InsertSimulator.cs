﻿using NHibernate;
using NHibernatePerformanceDemo.Host.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePerformanceDemo.Host
{
    public class InsertSimulator
    {
        private const int AmountOfInserts = 200;
        private ISessionFactory _sessionFactory;

        public InsertSimulator(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Simulate()
        {
            var stopWatch = new System.Diagnostics.Stopwatch();

            InsertProductWithIdGeneratedByDatabase(_sessionFactory, stopWatch);
            stopWatch.Reset();

            InsertProductWithHiLo(_sessionFactory, stopWatch);
            stopWatch.Reset();

            InsertProductWithGuidId(_sessionFactory, stopWatch);
        }


        private static void InsertProductWithGuidId(ISessionFactory sessionFactory, System.Diagnostics.Stopwatch stopWatch)
        {

            Console.WriteLine("Start executing insert product with guid id");

            stopWatch.Start();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {

                for (var i = 0; i < AmountOfInserts; i++)
                {
                    var product = new ProductWithGuid()
                    {
                        Id = Guid.NewGuid(),
                        Name = "skfjlkdsjflkdsfj",
                        Description = "skldjflksdjflkdsjfklsdjfkldsjfklsdfjklsdfjldkjfkldsjfldsfjkdfjsdlf",
                        Price = 22,
                        Category = "slkdjflksdjfklsdfl"
                    };
                    session.Save(product);
                }

                transaction.Commit();
            }

            stopWatch.Stop();
            var result = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Total time (in milliseconds) for executing query: " + result);
        }

        private static void InsertProductWithHiLo(ISessionFactory sessionFactory, System.Diagnostics.Stopwatch stopWatch)
        {
            Console.WriteLine("Start executing insert product with HiLo");

            stopWatch.Start();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {

                for (var i = 0; i < AmountOfInserts; i++)
                {
                    var product = new ProductWithHiLo()
                    {
                        Name = "skfjlkdsjflkdsfj",
                        Description = "skldjflksdjflkdsjfklsdjfkldsjfklsdfjklsdfjldkjfkldsjfldsfjkdfjsdlf",
                        Price = 22,
                        Category = "slkdjflksdjfklsdfl"
                    };
                    session.Save(product);
                }

                transaction.Commit();
            }

            stopWatch.Stop();
            var result = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Total time (in milliseconds) for executing query: " + result);
        }

        private static void InsertProductWithIdGeneratedByDatabase(ISessionFactory sessionFactory, System.Diagnostics.Stopwatch stopWatch)
        {
            Console.WriteLine("Start executing insert product with id generated by database.");
            stopWatch.Start();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                for (var i = 0; i < AmountOfInserts; i++)
                {
                    var product = new Product()
                    {
                        Name = "sdlkfjsdklfjsdklfjsdklfdsklfjklfjdslfjlkfjsdklf",
                        Description = "sdfsdfsdfdsfsdfdsfsdfdsffsdfdsf",
                        Price = 22,
                        Category = "dksjflkjdslfjdlsf"
                    };

                    session.Save(product);
                }

                transaction.Commit();
            }

            stopWatch.Stop();

            var result = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("Total time (milliseconds) for executing query: " + result);
        }

    }
}