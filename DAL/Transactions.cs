using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Transactions
    {
        public int transaction_id {  get; set; }
        public int user_id { get; set; }
        public string computer_name { get; set; }
        public int service_id { get; set; }
        public  int quantity { get; set; }
        public  decimal total_price { get; set; }
        public  DateTime transaction_time { get; set; }
        public string status { get; set; }
    }
}
