using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Service
    {
        public int service_id { get; set; }
        public string service_name { get; set; }
        public decimal price { get; set; }
        public int stock_quantity { get; set; }
    }
}
