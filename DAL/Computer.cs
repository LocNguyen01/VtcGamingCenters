using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Computer
    {
        public string computer_name { get; set; }
        public string status { get; set; }
        public string username { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
    }
}
