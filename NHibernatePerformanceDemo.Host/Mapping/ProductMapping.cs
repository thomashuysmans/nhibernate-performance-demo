using FluentNHibernate.Mapping;
using NHibernatePerformanceDemo.Host.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePerformanceDemo.Host.Mapping
{
    public class ProductMapping : ClassMap<Product>
    {
        public ProductMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.Category);
        }

    }
}
