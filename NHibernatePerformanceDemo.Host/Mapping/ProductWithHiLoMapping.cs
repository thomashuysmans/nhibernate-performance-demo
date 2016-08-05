using FluentNHibernate.Mapping;
using NHibernatePerformanceDemo.Host.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernatePerformanceDemo.Host.Mapping
{
    public class ProductWithHiLoMapping : ClassMap<ProductWithHiLo>
    {
        public ProductWithHiLoMapping()
        {
            Id(x => x.Id).Column("Id")
                        .GeneratedBy
                        .HiLo("NH_HiLo", "NextHi", "5000", "TableKey = 'ProductWithHiLo'");
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.Category);
        }
    }
}
