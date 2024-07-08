using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string full_name { get; set; }
        public string user_type {  get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set;}
        public decimal total_usage_time {  get; set; }
        public decimal Balance_Account {  get; set; }
        public string status    { get; set; }
    }
}
