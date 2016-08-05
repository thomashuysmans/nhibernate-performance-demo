using FluentNHibernate.Mapping;
using NHibernatePerformanceDemo.Host.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePerformanceDemo.Host.Mapping
{
    public class ProductWithGuidMapping : ClassMap<ProductWithGuid>
    {
        public ProductWithGuidMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.Category);

        }
    }
}
