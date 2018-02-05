using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMst.Models
{
    class OrderMapper : ClassMap<Order>
    {
        public OrderMapper()
        {
            Map(x => x.店舗).Index(0);
            Map(x => x.SKU).Index(1);
            Map(x => x.数量).Index(2);
        }
    }
}
